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

            //Observer
            Heater heater = new Heater();
            Alarm alarm = new Alarm();
            heater.Boiled += alarm.MakeAlert;
            //heater.Boiled += (new Alarm()).MakeAlert;
            //heater.Boiled += new Heater.BoiledEventHandler(alarm.MakeAlert);    //也可以这么注册
            heater.Boiled += Display.ShowMsg;

            heater.BoilWater();   //烧水，会自动调用注册过对象的方法

            Console.ReadLine();
        }
    }
}
