using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateSample
{
    //热水器
    public class Heater
    {
        private int temperature;
        public string type = "ReadFire 001";//添加型号作为演示
        public string area = "China Xian";//添加产地作为演示

        //声明委托
        public delegate void BoiledEventHandler(object sender,BoiledEventArgs args);
        //声明事件
        public event BoiledEventHandler Boiled;

        //可以提供继承自Heater的类重写，以便继承类拒绝其他对象对它的监视
        protected virtual void OnBoiled(BoiledEventArgs args)
        {
            //如果有对象注册
            Boiled?.Invoke(this, args);//调用所有注册对象的方法
        }

        //烧水
        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    //建立BoiledEventArgs对象
                    BoiledEventArgs args = new BoiledEventArgs(temperature);
                    OnBoiled(args);
                }
            }
        }
    }

    // 警报器
    public class Alarm
    {
        public void MakeAlert(Object sender, BoiledEventArgs e)
        {
            Heater heater = (Heater)sender;     //这里是不是很熟悉呢？
            //访问 sender 中的公共字段
            Console.WriteLine("Alarm：{0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Alarm: 嘀嘀嘀，水已经 {0} 度了：", e.temperature);
            Console.WriteLine();
        }
    }

    // 显示器
    public class Display
    {
        public static void ShowMsg(Object sender, BoiledEventArgs e)
        {   //静态方法
            Heater heater = (Heater)sender;
            Console.WriteLine("Display：{0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Display：水快烧开了，当前温度：{0}度。", e.temperature);
            Console.WriteLine();
        }
    }

    //定义BoiledEventArgs类,传递给Observer所感兴趣的信息
    public class BoiledEventArgs:EventArgs
    {
        public readonly int temperature;
        public BoiledEventArgs(int temperature)
        {
            this.temperature = temperature;
        }
    }
}
