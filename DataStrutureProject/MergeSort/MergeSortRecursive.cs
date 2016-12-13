using System;
using System.Threading.Tasks;
using DataStructureProject.Shared;
using DataStructureProject.Delegates;

namespace DataStructureProject.MergeSort
{
    public class MergeSortRecursive<T> : baseStructure<T>, IExercise<T>
    {
        public MergeSortRecursive()
        {
            base.Execute = MergeSortNumbers;
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

        private void MergeSortNumbers(T[] numbers)
        {
            MergeSort(numbers);
        }

        private void MergeSort(T[] input)
        {
            Console.WriteLine("Starting...");
            MergeSort(input, 0, (input.Length - 1));
            Console.WriteLine("Completed: " + GeneralHelper.PrintListOfNumbers(input));
        }

        private void MergeSort(T[] input, int l, int r)
        {
            int mid;

            if (r > l)
            {
                mid = (r + l) / 2;
                MergeSort(input, l, mid);
                MergeSort(input, (mid + 1), r);

                DoMerge(input, l, (mid + 1), r);
            }
        }

        private void DoMerge(T[] input, int left, int mid, int right)
        {
            T[] temp = new T[input.Length];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (int.Parse(input[left].ToString()) <= int.Parse(input[mid].ToString()))
                    temp[tmp_pos++] = input[left++];
                else
                    temp[tmp_pos++] = input[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = input[left++];

            while (mid <= right)
                temp[tmp_pos++] = input[mid++];

            for (i = 0; i < num_elements; i++)
            {
                input[right] = temp[right];
                right--;
            }
        }
    }
}
