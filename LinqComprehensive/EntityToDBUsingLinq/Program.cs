using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace EntityToDBUsingLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertDataToDb();
            SelectDataFromDb();
        }

        private static void SelectDataFromDb()
        {
            var db = new CarDb();
            db.Database.Log = Console.WriteLine;
            var query = from car in db.Cars
                        orderby car.Combined descending, car.Name ascending
                        select car;
            foreach (var car in query.Take(20))
            {
                Console.WriteLine($"Car Name {car.Name} \t:{car.Combined}");
            }
        }

        private static void InsertDataToDb()
        {
            var Cars = ProcessCarsFromCSV("fuel.csv");
            var db = new CarDb();
            if (!db.Cars.Any())
            {
                foreach (var car in Cars)
                {
                    db.Cars.Add(car);
                }
            }
            db.SaveChanges();
        }

        private static List<Car> ProcessCarsFromCSV(string filePath)
        {
            var projectionQuery = File.ReadAllLines(filePath).Skip(1).Where(l => l.Length > 1).ToCar();
            return projectionQuery.ToList();
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
    public class CarDb : DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }


}
