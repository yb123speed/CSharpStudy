using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateSample
{
    delegate void InformInfoHandler(string name);
    class UseDelegate
    {
        InformInfoHandler myInform;

        public UseDelegate()
        {
            //3.委托注册
            myInform = new InformInfoHandler(InformA);
            myInform += InformB;
        }

        public void SendInfo()
        {
            myInform("I am cx");
        }

        private void InformA(string name)
        {
            Console.WriteLine("{0},Hello A", name);
        }
        private void InformB(string name)
        {
            Console.WriteLine("{0},Hello B", name);
        }


    }
}
