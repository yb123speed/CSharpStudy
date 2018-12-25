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


            //让事件只允许一个客户订阅
            //方法一：
            Publisher publisher = new Publisher();
            publisher.Register(new GeneralEventHandler(Hello));
            publisher.Register(new GeneralEventHandler((new Program()).Bye));
            publisher.DoSomething();

            //方法二：
            Publisher1 publisher1 = new Publisher1();
            publisher1.NumberChanged += (new Subscriber1()).OnNumberChanged;
            publisher1.NumberChanged += (new Subscriber2()).OnNumberChanged;
            publisher1.DoSomething();

            Console.ReadLine();
        }

        static string Hello()
        {
            return "Hello,World!";
        }

        string Bye()
        {
            return "Bye!Bye!";
        }
    }
}
