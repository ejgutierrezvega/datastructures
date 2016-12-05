using System;
using System.Collections;
using System.Threading.Tasks;
using DataStructureProject.Shared;
using System.Collections.Generic;

namespace DataStructureProject.MergeSort
{
    public class MergeSortAlgorithm
    {
        public static async Task MergeSortRecursive()
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

        public static async Task MergeSortIterative()
        {
            int[] input = GeneralHelper.GetListOfNumbersArray(20);
            var task = MergeSortIterative(input);
            task.Start();
            await task;
        }

        private static Task MergeSortIterative(int[] input)
        {
            var task = new Task(() =>
            {
                Console.WriteLine("Starting...");
                MergeSortIterative(input, 0, (input.Length - 1));
                Console.WriteLine("Completed: " + GeneralHelper.PrintListOfNumbers(input));

            });

            return task;
        }

        private static void MergeSortIterative(int[] numbers, int left, int right)
        {
            int mid;
            if (right <= left)
                return;

            List<MergePosInfo> list1 = new List<MergePosInfo>();
            List<MergePosInfo> list2 = new List<MergePosInfo>();

            MergePosInfo info;
            info.left = left;
            info.right = right;
            info.mid = -1;

            list1.Insert(list1.Count, info);

            while (true)
            {
                if (list1.Count == 0)
                    break;

                left = list1[0].left;
                right = list1[0].right;
                list1.RemoveAt(0);
                mid = (right + left) / 2;

                if (left < right)
                {
                    MergePosInfo info2;
                    info2.left = left;
                    info2.right = right;
                    info2.mid = mid + 1;
                    list2.Insert(list2.Count, info2);

                    info.left = left;
                    info.right = mid;
                    list1.Insert(list1.Count, info);

                    info.left = mid + 1;
                    info.right = right;
                    list1.Insert(list1.Count, info);
                }
            }


            for (int i = 0; i < list2.Count; i++)
            {
                DoMerge(numbers, list2[i].left, list2[2].mid, list2[2].right);
            }

        }

        private static void DoMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];

            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];

            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }

        private struct MergePosInfo
        {
            public int left;
            public int mid;
            public int right;
        };
    }
}
