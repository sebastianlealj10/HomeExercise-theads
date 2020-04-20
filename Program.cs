using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeExercise_theads
{

    class Program
    {
        private const int total = 100000;

        static void Main()
        {
            Run().Wait();
            Console.ReadLine();
        }

        public static async Task Run()
        {
            List<Task<int>> mytasks = new List<Task<int>>(total);
            Dictionary<int, int> divisors = new Dictionary<int, int>();
            for (int i = 1; i <= total; i++)
                mytasks.Add(GetDivisors(i));
            var result = await Task.WhenAll<int>(mytasks.ToArray());
            divisors.Add(0, 1);
            int index = 1;
            foreach (int divisorsnumber in result)
            {
                divisors.Add(index, divisorsnumber);
                index++;
            }
            var sorteddivisors = from entry in divisors orderby entry.Value ascending select entry;
                Console.WriteLine("Number = {0}, Divisors = {1}",
                    sorteddivisors.Last().Key, sorteddivisors.Last().Value);
        }

        private static async Task<int> GetDivisors(int number)
        {
            int divisorsNumber = 0;
            for (int i = 1; i <= number; i++)
                if (number % i == 0)
                    divisorsNumber++;
            return divisorsNumber;
        }

    }

}