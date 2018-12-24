using System;

namespace DelegateSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Use Delegate
            UseDelegate ud = new UseDelegate();
            ud.SendInfo();

            //Use Event
            EventTest eventTest = new EventTest();
            eventTest.RaiseEvent();

            Console.ReadLine();
        }
    }
}
