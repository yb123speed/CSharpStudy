using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateSample
{
    // 定义委托
    public delegate string GeneralEventHandler1();
    // 定义事件发布者
    public class Publisher1
    {
        // 声明一个委托变量
        private GeneralEventHandler1 numberChanged;
        // 事件访问器的定义
        public event GeneralEventHandler1 NumberChanged
        {
            add
            {
                numberChanged = value;
            }
            remove
            {
                numberChanged -= value;
            }
        }

        public void DoSomething()
        {
            numberChanged?.Invoke();// 通过委托变量触发事件
        }
    }

    // 定义事件订阅者
    public class Subscriber1
    {
        public string OnNumberChanged()
        {
            Console.WriteLine("Subscriber1 Invoked!");
            return "Subscriber1";
        }
    }
    public class Subscriber2
    {
        public string OnNumberChanged()
        {
            Console.WriteLine("Subscriber2 Invoked!");
            return "Subscriber2";
        }
    }
}
