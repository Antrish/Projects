using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Car
    {
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Displacement { get; set; }
        public int Cylinders { get; set; }
        public int City { get; set; }
        public int Highway { get; set; }
        public int Combined { get; set; }
        //internal static Car ParseFromCsv(string line)
        //{
        //    var coloumns = line.Split(",");
        //    return new Car()
        //    {
        //        Year = int.Parse(coloumns[0]),
        //        Manufacturer = coloumns[1],
        //        Name = coloumns[2],
        //        Displacement = double.Parse(coloumns[3]),
        //        Cylinders = int.Parse(coloumns[4]),
        //        City = int.Parse(coloumns[5]),
        //        Highway = int.Parse(coloumns[6]),
        //        Combined = int.Parse(coloumns[7])
                

        //    };
        //}

       
    }   
}
