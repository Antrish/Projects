using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("fuel.csv");
            var manufactureres = ProcessMAnufacturer("manufacturers.csv");
            //var query = cars.OrderByDescending(c => c.Combined)
            //    .ThenBy(c => c.Name);
            //var query = (from car in cars where car.Manufacturer=="BMW" && car.Year==2016
            //            orderby car.Combined descending, car.Name ascending
            //            select car);

            //foreach (var car in query.Take(10))
            //{
            //    Console.WriteLine($"{car.Manufacturer}: {car.Name} : {car.Combined}: {car.Year}");

            //}

            //***Joining two tables and projection with anonymous class and query syntax.
            var query = from car in cars
                        join manufacturer in manufactureres on car.Manufacturer
                        equals manufacturer.Name
                        orderby car.Combined descending, car.Name ascending
                        select new
                        {
                            car.Name,
                            car.Combined,
                            manufacturer.HeadQuarters,
                            manufacturer.Year

                        };
            //***Joining two tables and projection with anonymous class and extention method syntax.
            var query2 = cars.Join(manufactureres,
                        c => c.Manufacturer,
                        m => m.Name, (c, m) => new
                        {
                            m.HeadQuarters,
                            c.Name,
                            c.Combined,
                            c.Year

                        }).OrderByDescending(c=>c.Name).ThenBy(c=>c.Combined);

            foreach (var car in query2.Take(10))
            {
                Console.WriteLine($"{car.HeadQuarters}: {car.Name} : {car.Combined}: {car.Year}");

            }

            static List<Manufacturer> ProcessMAnufacturer(string path)
            {
                var query = File.ReadAllLines(path).Where(l => l.Length > 1)
                            .Select(l =>
                            {
                                var coloumn = l.Split(",");
                                return new Manufacturer
                                {
                                    Name = coloumn[0],
                                    HeadQuarters = coloumn[1],
                                    Year = int.Parse(coloumn[2])
                                };
                            });
                return query.ToList();
            }

            static List<Car> ProcessFile(string path)
            {
                //return File.ReadAllLines(path).Skip(1).Where(line => line.Length > 1)
                //    .Select(Car.ParseFromCsv).ToList();

                //var query = from line in File.ReadAllLines(path).Skip(1)
                //            where line.Length > 1
                //            select Car.ParseFromCsv(line);
                //return query.ToList();

                //**Custom projection, rather having a separte implementation in Car class,
                //**we can use projection dedicated to the query result.
                var projectionQuery = File.ReadAllLines(path).Skip(1).Where(l => l.Length > 1).ToCar();
                return projectionQuery.ToList();
            }

        }
    }
    public static class CarExtention
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> lines)
        {

            foreach (var line in lines)
            {
                var coloumns = line.Split(",");
                yield return new Car()
                {
                    Year = int.Parse(coloumns[0]),
                    Manufacturer = coloumns[1],
                    Name = coloumns[2],
                    Displacement = double.Parse(coloumns[3]),
                    Cylinders = int.Parse(coloumns[4]),
                    City = int.Parse(coloumns[5]),
                    Highway = int.Parse(coloumns[6]),
                    Combined = int.Parse(coloumns[7])


                };
            }
        }
    }
}
