using System;
using System.Collections.Generic;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            //** oderby is deferred 'NON-STREAMING' operator which executes
            //through entire datasource before filtering it.

            //** Take() is a deferred streaming operator which fetches only the limited values from datasource.
            // It does not execute  for the entire datasource.

            var number = CustomLinq.Random().Where(n => n > 0.5).Take(10);
            number = number.OrderByDescending(number => number);// since we need to sort the result in desending,
                                                                //we are calling order by on the filtered result rather calling it on datasource.

            foreach (var num in number)
            {
                Console.WriteLine(num);
            }
            var movies = new List<Movies>
            {
             new Movies { Title="Bajirao Mastani",Rating=9.5f,Year=2018},

             new Movies { Title="Padmavati",Rating=9.5f,Year=2019},
             new Movies { Title="Bahubali The Conclusion",Rating=10.0f,Year=2017},
             new Movies { Title="URI- The Surgical Strike",Rating=9.5f,Year=2018}
            };
            var moviesB42020 = movies.Filter(m => m.Year>2017);
            foreach ( var movie in moviesB42020) 
            {
                Console.WriteLine(movie.Title);
            };
        }
    }
}
