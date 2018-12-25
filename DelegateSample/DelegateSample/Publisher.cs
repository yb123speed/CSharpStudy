using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateSample
{
    //如何让事件只允许一个客户订阅？
    //方法一：将事件声明为private的，然后提供两个方法来进行注册和取消注册
    public class Publisher
    {
        //声明一个私有事件
        private event GeneralEventHandler NumberChanged;//将NumberChanged声明为委托变量还是事件都无所谓了，因为它是私有的。

        //注册事件
        public void Register(GeneralEventHandler handler)
        {
            NumberChanged = handler;//“=”，通过这种方式就避免了多个方法注册
        }

        public void UnRegister(GeneralEventHandler handler)
        {
            NumberChanged -= handler;//即使method方法没有进行过注册，也不会抛出异常，仅仅是不会产生任何效果而已。
        }

        public void DoSomething()
        {
            if (NumberChanged != null)
            {
                //触发事件
                string rtn = NumberChanged();
                Console.WriteLine("Return: {0}",rtn);
            }
        }
    }

    public delegate string GeneralEventHandler();
}
