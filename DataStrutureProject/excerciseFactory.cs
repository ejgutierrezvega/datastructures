using DataStructureProject.BubbleSort;
using DataStructureProject.LinkedListStructure;
using DataStructureProject.MergeSort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProject
{
    public class excerciseFactory
    {
        public static IExercise<T> GetExercise<T>(int option)
        {
            IExercise<T> exercise = null;

            switch(option)
            {
                case 5:
                    exercise = new BubbleSortAlgorithm<T>();
                    break;
                case 6:
                    exercise = new MergeSortRecursive<T>();
                    break;
                case 7:
                    exercise = new MergeSortIterative<T>();
                    break;
                case 8:
                    exercise = new LinkedListStructure<T>();
                    break;
                default:
                    break;
            }

            return exercise;
        }
    }
}
