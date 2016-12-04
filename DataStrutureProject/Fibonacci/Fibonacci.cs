using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataStructureProject.Fibonacci
{
    public class Fibonacci
    {
        public static async Task GetFibonacci()
        {
            var outer = new Task(() =>
            {
                int number = 0;
                int count = 0;
                var numbers = new List<int>();
                int index = 0;

                numbers.Add(number);

                for (count = 0; count < 15; count++)
                {
                    if (index > 0)
                    {
                        number = numbers[index] + numbers[index - 1];
                    }
                    else
                        number = 1;

                    index++;

                    numbers.Add(number);
                }

                Console.WriteLine(string.Join(",", numbers.ToArray()));
            });

            outer.Start();
            await outer;
        }
    }
}
