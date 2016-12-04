using System;
using System.Collections.Generic;

namespace DataStructureProject
{
    class Program
    {
        static void Main(string[] args)
        {
            GetOptions();

            bool correctSelection = false;
            while (!correctSelection)
            {
                Console.Write("Choose an option: ");
                string input = Console.ReadLine();
                int option;
                if (int.TryParse(input, out option))
                    correctSelection = RunSelected(option);

                if (!correctSelection)
                    Console.WriteLine("Option not available");
                else
                {
                    if (option != 0)
                    {
                        Console.WriteLine("....");
                        correctSelection = false;
                    }
                    else
                        Console.WriteLine("bye...");
                }
            }
        }

        private static  void GetOptions()
        {
            var options = ListOfOptions();
            PrintList(options);
        }

        private static SortedList<int, string> ListOfOptions()
        {
            var list = new SortedList<int, string>();
            list.Add(-1, "Clear");
            list.Add(0, "Exit");
            list.Add(1, "Fibonacci");
            list.Add(2, "Singleton");
            list.Add(3, "Bracket exercise");
            list.Add(4, "Binary search tree");
            list.Add(5, "Bubble sort");
            list.Add(6, "Merge sort");

            return list;            
        }

        private static void PrintList(SortedList<int, string> list)
        {
            foreach(var item in list)
                Console.WriteLine($"{item.Key}: {item.Value}");
        }

        private static bool RunSelected(int option)
        {
            bool result = true;
            switch(option)
            {
                case -1:
                    Console.Clear();
                    GetOptions();
                    break;
                case 0:
                    break;
                case 1:
                    Fibonacci.Fibonacci.GetFibonacci().GetAwaiter().GetResult();
                    break;
                case 2:
                    Singleton.SingleTonPattern.GetSingleTonPattern().GetAwaiter().GetResult();
                    break;
                case 3:
                    var input = "(a[]{}([{}]d))";
                    Exercises.BracketFormat.ValidateStringBrackets(input).GetAwaiter().GetResult();
                    break;
                case 4:
                    BinarySearchTree.BinarySearchAlgorithm.BinarySearch().GetAwaiter().GetResult();
                    break;
                case 5:
                    BubbleSort.BubbleSortAlgorithm.InitializeBubleSort().GetAwaiter().GetResult();
                    break;
                case 6:
                    MergeSort.MergeSortAlgorithm.MergeSort().GetAwaiter().GetResult();
                    break;
                default:
                    result = false;
                    break;
            }
            return result;
        }
    }
}
