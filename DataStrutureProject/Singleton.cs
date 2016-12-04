using System;

namespace Practice
{
    class Singleton
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
