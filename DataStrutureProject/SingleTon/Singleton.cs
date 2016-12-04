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
                var singleTon = Singleton.GetInstance();
                var singleTon2 = Singleton.GetInstance();

                if (singleTon == singleTon2)
                    Console.WriteLine("Same instance");
            });

            outer.Start();
            await outer;
        }

    }

    public class Singleton
    {
        private static Singleton _instance;

        // Lock synchronization object
        private static object syncLock = new object();

        protected Singleton() { }

        public static Singleton GetInstance()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        Console.WriteLine("Creating instance");
                        _instance = new Singleton();
                    }
                }
            }

            return _instance;
        }
    }
}
