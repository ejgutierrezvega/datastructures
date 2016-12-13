using System;

namespace DataStructureProject.Delegates
{
    public abstract class baseStructure<T>
    {
        protected Func<T[]> GetNumbers;
        protected Action<T[]> Execute;

        public void RunExercise(T[] numbers)
        {
            //var numbers = GetNumbers();
            Execute(numbers);
        }
    }
}
