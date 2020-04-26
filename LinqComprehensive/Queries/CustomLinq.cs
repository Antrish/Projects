using System;
using System.Collections.Generic;
using System.Text;

namespace Queries
{
    public static class CustomLinq
    {
        public static IEnumerable<double> Random() 
        {
            var random = new Random();
            while (true) {
                Console.WriteLine("still here..!!");
                yield return random.NextDouble();
            }
        }
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> input,Func<T,bool> predicate)
        {

            
            foreach (var item in input)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
            
        }
    }
}
