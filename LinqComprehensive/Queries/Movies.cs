using System;
using System.Collections.Generic;
using System.Text;

namespace Queries
{
    class Movies
    {
        public string Title { get; set; }
        public float Rating { get; set; }
        int _year;

        public int Year {
            get { 
                Console.WriteLine($"Returning {Title} for {_year}");
                return _year;
            }
            set {
                _year = value;
            }
        }
    }
}
