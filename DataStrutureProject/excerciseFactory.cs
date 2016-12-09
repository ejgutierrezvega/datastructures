using DataStructureProject.LinkedListStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProject
{
    public class excerciseFactory
    {
        public static IExercise<T, J>  GetExercise<T, J>(int option)
        {
            IExercise<T, J> exercise = null;

            switch(option)
            {
                case 8:
                    //exercise = new LinkedListExcercise<LinkedList<int>, int>() as IExercise<T, J>;
                    break;
            }

            return exercise;
        }
    }
}
