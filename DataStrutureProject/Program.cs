using DataStructureProject.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DataStructureProject
{
    public class Program
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
                {
                    if (option < 0)
                    {
                        Console.Clear();
                        GetOptions();
                    }
                    else if (option == 0)
                    {
                        Console.WriteLine("bye...");
                        correctSelection = true;
                    }
                    else
                        Console.WriteLine("Option not available");
                }
                else
                {
                    if (option != 0)
                    {
                        Console.WriteLine("....");
                        correctSelection = false;
                    }
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
            list.Add(6, "Merge sort recursive");
            list.Add(7, "Merge sort iterative");
            list.Add(8, "Linked list");

            return list;            
        }

        private static void PrintList(SortedList<int, string> list)
        {
            foreach(var item in list)
                Console.WriteLine($"{item.Key}: {item.Value}");
        }

        private static bool RunSelected(int option)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            bool result = true;

            var exercise = excerciseFactory.GetExercise<int>(option);
            if (exercise != null)
            {
                int[] data = GeneralHelper.GetListOfNumbersArray(20);
                result = exercise.ExecuteExercise(data);
            }
            else
                result = false;


            //switch (option)
            //{
            //    case -1:
            //        Console.Clear();
            //        GetOptions();
            //        break;
            //    case 0:
            //        break;
            //    case 1:
            //        Fibonacci.Fibonacci.GetFibonacci().GetAwaiter().GetResult();
            //        break;
            //    case 2:
            //        Singleton.SingleTonPattern.GetSingleTonPattern().GetAwaiter().GetResult();
            //        break;
            //    case 3:
            //        var input = "(a[]{}([{}]d))";
            //        Exercises.BracketFormat.ValidateStringBrackets(input).GetAwaiter().GetResult();
            //        break;
            //    case 4:
            //        BinarySearchTree.BinarySearchAlgorithm.BinarySearch().GetAwaiter().GetResult();
            //        break;
            //    default:
            //        result = false;
            //        break;
            //}


            stopWatch.Stop();

            if (result)
            {
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                Console.WriteLine($"Elapsed: {elapsedTime}");
            }

            return result;
        }
    }
}
