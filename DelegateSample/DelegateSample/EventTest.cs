using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateSample
{
    class EventTest
    {
        //1.定义delegate对象
        public delegate void MyEventHandler(object sender, EventArgs args);

        //2.(定义事件参数类)省略
        public class MyEventCls
        {
            //3.定义事件处理方法，它与delegate对象具有相同的参数和返回值类型
            public void MyEventFunc(object sender, EventArgs args)
            {
                Console.WriteLine("My event is ok!");
            }
        }

        //4.使用event关键字定义事件对象
        private event MyEventHandler myevent;

        private MyEventCls myecls;

        public EventTest()
        {
            myecls = new MyEventCls();
            //5.用+=操作符将事件添加到队列中
            //this.myevent += new MyEventHandler(myecls.MyEventFunc);
            this.myevent += myecls.MyEventFunc;
        }

        //6.以调用delegate的方式写事件触发函数
        public void OnMyEvent(EventArgs args)
        {
            if (args != null)
            {
                myevent(this, args);
            }
        }

        public void RaiseEvent()
        {
            EventArgs args = new EventArgs();
            //7.触发事件
            OnMyEvent(args);
        }
    }
}
