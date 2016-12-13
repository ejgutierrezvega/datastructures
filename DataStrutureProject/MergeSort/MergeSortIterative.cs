using DataStructureProject.Delegates;
using DataStructureProject.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataStructureProject.MergeSort
{
    public class MergeSortIterative<T> : baseStructure<T>, IExercise<T>
    {
        public MergeSortIterative()
        {
            base.Execute = MergeSort;
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

        private void MergeSort(T[] numbers)
        {
            Console.WriteLine("Starting...");
            MergeSort(numbers, 0, (numbers.Length - 1));
            Console.WriteLine("Completed: " + GeneralHelper.PrintListOfNumbers(numbers));
        }

        private void MergeSort(T[] numbers, int left, int right)
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
                DoMergeIterative(numbers, list2[i].left, list2[2].mid, list2[2].right);
            }

        }

        private void DoMergeIterative(T[] numbers, int left, int mid, int right)
        {
            T[] temp = new T[25];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (int.Parse(numbers[left].ToString()) <= int.Parse(numbers[mid].ToString())) //ToDo: this needs to have an IComparable in order to compare using generics.
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
