using System;
using System.Threading.Tasks;

namespace DataStructureProject.Singleton
{
    public class SingleTonPattern
    {
        public static async Task GetSingleTonPattern()
        {
            var outer = new Task(() =>
            {
                var singleTon = Singleton.GetInstanceBasic();
                var singleTon2 = Singleton.GetInstanceBasic();

                Console.WriteLine($"Instance 1: {singleTon}");
                Console.WriteLine($"Instance 2: {singleTon2}");

                var singleTonThread = Singleton.GetInstanceThreadSafe();
                var singleTonThread2 = Singleton.GetInstanceThreadSafe();

                Console.WriteLine($"Instance (thread safe) 1: {singleTonThread}");
                Console.WriteLine($"Instance (thread safe) 2: {singleTonThread2}");

            });

            outer.Start();
            await outer;
        }

    }

    public class Singleton
    {
        private static string _instance;
        private static string _instanceThread;

        // Lock synchronization object
        private static object syncLock = new object();

        protected Singleton() { }

        public static string GetInstanceBasic()
        {
            if (_instance == null)
            {
                var random = new Random(DateTime.Now.Millisecond);
                var number = random.Next(0, 100);
                _instance = $"Creating random number: {number}";
            }

            return _instance;
        }

        public static string GetInstanceThreadSafe()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if (_instanceThread == null)
            {
                lock (syncLock)
                {
                    if (_instanceThread == null)
                    {
                        var random = new Random(DateTime.Now.Millisecond);
                        var number = random.Next(0, 100);
                        _instanceThread = $"Creating random number: {number}";
                    }
                }
            }

            return _instanceThread;
        }
    }
}
