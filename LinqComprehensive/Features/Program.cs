using System;
using System.Collections.Generic;
using System.Linq;
using Features;
namespace Features
{
    class Program
    {
       

        static void Main(string[] args)
        {
            Func<int, int> f =  number =>  number * number; // computing square
            Func<int, int, int> add = (n,m) => (n + m);// computing addition
        //* in Func the last data type is meant for return type whe
            Console.WriteLine(square(add(10,0)));
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee { Id=1, Name="Antrish"},
                new Employee { Id=2, Name="Anand"},
                new Employee { Id=3, Name="Ajeet"},
            };
            IEnumerable<Employee> sales = new List<Employee>()
            { 
            new Employee {Id=4,Name="Pawan"},
            new Employee {Id=4,Name="Chandra"},

            };
            //foreach (Employee emp in sales)
            //{
            //    Console.WriteLine(emp.Name);
            //}
            //IEnumerator<Employee> enumerator = sales.GetEnumerator();
            //Console.WriteLine(developers.GetCount()); // extention method getCount 
            //while (enumerator.MoveNext()) 
            //{
            //    Console.WriteLine(enumerator.Current.Name);
            //}
            //foreach (var emp in developers.Where(e => e.Name.EndsWith("d")))
            //{
            //    Console.WriteLine(emp.Name);
            //}
            var query = developers.Where(e => e.Name.Length >= 5).OrderByDescending(e => e.Name);
            var query2 = from developer in developers
                         where developer.Name.Length >= 5
                         orderby developer.Name descending
                         select developer;
            foreach (var emp in query)
            {
                Console.WriteLine(emp.Name);
            }
            Console.WriteLine("-----------------------------------------");
            foreach (var emp in query2)
            {
                Console.WriteLine(emp.Name);
            }
        }

        private static int square(int number)
        {
            
            return number * number;
        }

        private static bool NameStartWithA(Employee emp)
        {
           return emp.Name.EndsWith("d"); 
        }
    }
}
