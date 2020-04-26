using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";
            ShowLargetFileWithoutLinq(path);
            Console.WriteLine("********************");
            ShowLargetFileWithLinq(path);
        }

        private static void ShowLargetFileWithLinq(string path)
        {
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;
            //or
            //var query = new DirectoryInfo(path).GetFiles().OrderByDescending(n => n.Length).Take(5);

            foreach (var file in query.Take(10))
            {
                Console.WriteLine($"{file.Name,-20}: {file.Length,10:N0}");
            }
        }

        private static void ShowLargetFileWithoutLinq(string path)
        {

            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles(); // sort the array accroding to file length desc
            Array.Sort(files, new FileComparer());
            //foreach (FileInfo file in files)
            //{
            //    Console.WriteLine($"{file.Name}: {file.Length}");
            //}
            for (int i = 0; i <= 5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name,-20}: {file.Length,10:N0}");
            }

        }
        public class FileComparer : IComparer<FileInfo>
        {
            public int Compare(FileInfo x, FileInfo y)
            {
                return y.Length.CompareTo(x.Length);
            }
        }
    }
}
