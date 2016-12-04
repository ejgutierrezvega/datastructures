using DataStructureProject.Shared;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace DataStructureProject.BubbleSort
{
    public class BubbleSortAlgorithm
    {
        public static async Task InitializeBubleSort()
        {
            var items = GeneralHelper.GetListOfNumbers();
            var task = BubbleSort(items);
            task.Start();
            await task;
        }

        private static Task BubbleSort(ArrayList input)
        {
            var task = new Task(() =>
            {
                var count = input.Count;
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < (count - 1); j++)
                    {
                        if ((int)input[j] > (int)input[j + 1])
                        {
                            int temp = (int)input[j];
                            input[j] = input[j + 1];
                            input[j + 1] = temp;
                        }
                    }
                    Console.WriteLine("After iteration " + i.ToString() + ": " + GeneralHelper.PrintListOfNumbers(input));
                }
            });

            return task;
        }
    }
}
