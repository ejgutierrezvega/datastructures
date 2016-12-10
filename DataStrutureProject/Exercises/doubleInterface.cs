namespace DataStructureProject.Exercises
{
    /// <summary>
    /// This is to validate what happens when a class derive from two interfaces with the same methods.
    /// </summary>
    internal interface IStack
    {
        int Get();
        void Push(int value);
        int Pop();
    }

    internal interface IQueue
    {
        int Get();
        void Push(int value);
        int Pop();
    }

    public class structureClass : IStack, IQueue
    {
        public int Get()
        {
            return 1;
        }

        public void Push(int value)
        {
            var _value = value;
        }

        public int Pop()
        {
            return 1;
        }
    }
}
