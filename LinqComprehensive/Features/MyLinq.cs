using System;
using System.Collections.Generic;
using System.Text;

namespace Features
{
   public static class MyLinq
    {
        public static int GetCount<T>(this IEnumerable<T> items)
        {
            int count = 0;
            foreach (var item in items)
            {
                count += 1;
            }
            return count;

        }
    }
}
