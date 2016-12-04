using System;
using System.Collections;
using System.Threading.Tasks;
using DataStructureProject.Shared;

namespace DataStructureProject.MergeSort
{
    public class MergeSortAlgorithm
    {
        public static async Task MergeSort()
        {
            ArrayList input = GeneralHelper.GetListOfNumbers(20);
            var task = MergeSort(input);
            task.Start();
            await task;
        }

        private static Task MergeSort(ArrayList input)
        {
            var task = new Task(() =>
            {
                Console.WriteLine("Starting...");
                MergeSort(input, 0, (input.Count - 1));
                Console.WriteLine("Completed: " + GeneralHelper.PrintListOfNumbers(input));

            });

            return task;
        }

        private static void MergeSort(ArrayList input, int l, int r)
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

        private static void DoMerge(ArrayList input, int left, int mid, int right)
        {
            int[] temp = new int[input.Count];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if ((int)input[left] <= (int)input[mid])
                    temp[tmp_pos++] = (int)input[left++];
                else
                    temp[tmp_pos++] = (int)input[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = (int)input[left++];

            while (mid <= right)
                temp[tmp_pos++] = (int)input[mid++];

            for (i = 0; i < num_elements; i++)
            {
                input[right] = temp[right];
                right--;
            }
        }
    }
}
