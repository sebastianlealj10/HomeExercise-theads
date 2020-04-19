using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExercise_theads
{
    static class Divisors
    {
        public static async Task<int> GetDivisors(int number)
        {
            int divisorsNumber = 0;
            for (int i = 1; i <= number; i++)
                if (number % i == 0)
                    divisorsNumber++;
            return divisorsNumber;
        }
    }
}
