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
        private static object _lock = new object();
        public static void Main()
        {
            BlockingCollection<string> sharedata = new BlockingCollection<string>(10);
            Thread producer = new Thread(() =>
            {
                var directory = Directory.GetCurrentDirectory();
                string projectDirectory = Directory.GetParent(directory).Parent.FullName;
                string[] files;
                bool waiting = true;
                while (waiting)
                { 
                    files = Directory.GetFiles(projectDirectory + "\\Files\\");
                    if (files.Length >= 10)
                    {
                        files = SortFiles.SortingFiles(files);
                        foreach (string input in files.Take(10))
                        {
                            sharedata.Add(input);
                            sharedata.Add(ReadFile(input));
                        }
                    sharedata.CompleteAdding();
                    waiting = false;
                }
                }
            });
                
            Thread consumer = new Thread(() =>
            {
                string text = null;
                string[] data = new string[20];
                int i = 0;

                while (!sharedata.IsCompleted)
                {
                    try
                    {
                        text = sharedata.Take();
                    }
                    catch (InvalidOperationException) {}
                    if (text != null)
                    {
                        data[i] = text;
                        Console.WriteLine(text);
                        i++;
                    }
                }
                foreach (var value in data)
                {
                    Console.WriteLine(value);
                }
            });

            producer.Start();
            consumer.Start();
            Console.ReadLine();
        }

     static string ReadFile(string file)
        {
            StringBuilder text = new StringBuilder();
            lock (_lock)
            { 
                using (PdfReader reader = new PdfReader(file))
                {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                      text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                    }
                }
            }
            return text.ToString();
        }
    }
}