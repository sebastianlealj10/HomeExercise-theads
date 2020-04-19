using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace HomeExercise_theads
{

    class Program
    {
        static void Main()
        {
            int n = 100;
            for (int i = 1; i <= n; i++)
                if (n % i == 0)
                    Console.WriteLine(i + " ");
            Console.ReadLine();
        }
        
    }
 
}