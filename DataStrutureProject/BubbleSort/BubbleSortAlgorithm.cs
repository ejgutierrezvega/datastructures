using DataStructureProject.Delegates;
using DataStructureProject.Shared;
using System;
using System.Threading.Tasks;

namespace DataStructureProject.BubbleSort
{
    public class BubbleSortAlgorithm<T> : baseStructure<T>, IExercise<T>
    {
        public BubbleSortAlgorithm()
        {
            base.Execute = BubbleSortNumbers;
        }

        public async Task<bool> ExecuteTask(T[] numbers)
        {
            var task = new Task(() =>
            {
                base.RunExercise(numbers);
            });

            task.Start();
            await task;

            return true;
        }

        public bool ExecuteExercise(T[] numbers)
        {
            base.RunExercise(numbers);

            return true;
        }

        private void BubbleSortNumbers(T[] input)
        {
            var count = input.Length;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < (count - 1); j++)
                {
                    if (int.Parse(input[j].ToString()) > int.Parse(input[j + 1].ToString())) //ToDo: IComparable implementation
                    {
                        T temp = input[j];
                        input[j] = input[j + 1];
                        input[j + 1] = temp;
                    }
                }
                Console.WriteLine("After iteration " + i.ToString() + ": " + GeneralHelper.PrintListOfNumbers(input));
            }
        }
    }
}
