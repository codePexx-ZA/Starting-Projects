using System;
using System.Threading;

namespace ThreadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Dotnet world!");
        }
    }
}

namespace ThreadingDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = Thread.CurrentThread;



            t.Name = "Main Thread";

            Console.WriteLine("Current Executing Thread Name :" + t.Name);

            Console.WriteLine("Current Executing Thread Name :" + Thread.CurrentThread.Name);

            Console.Read();
        }
    }
}

namespace ThreadingDemo3
{
    class Program
    {
        static void Main(string[] args)
        {
            Method1();

            Method2();

            Method3();

            Console.Read();
        }

        static void Method1()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method1 :" + i);
            }
        }

        static void Method2()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method2 :" + i);
            }
        }

        static void Method3()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method3 :" + i);
            }
        }
    }
}
