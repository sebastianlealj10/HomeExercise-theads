using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExercise_theads
{
    static class SortFiles
    {
        public static string[] SortingFiles(string[] files)
        {
            for (int i = 0; i < files.Length - 1; i++)
            { 
                
                for (int j = 0; j<files.Length - i - 1; j++)
                {   
                   DateTime current = File.GetCreationTime(files[j]);
                   DateTime next = File.GetCreationTime(files[j+1]);
                     if (current > next)
                     {
                        string temp = files[j];
                        files[j] = files[j+1];
                        files[j+1] = temp;
                     }
                }
            
            }


            return files;
            }
    }
}
