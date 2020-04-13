using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate
{
    public class Heater
    {
        private int temperature;
        public string type = "RealFire 001";
        public string area = "China Xian";

        public delegate void BoiledEventHandler(Object sender, BoiledEventArgs e);
        public event BoiledEventHandler Boiled;

        public class BoiledEventArgs : EventArgs
        {
            public readonly int temperature;

            public BoiledEventArgs(int temperature)
            {
                this.temperature = temperature;
            }
        }
        // 方法的触发器
        protected virtual void OnBoiled(BoiledEventArgs e)
        {
            if (Boiled != null)
            {
                Boiled(this, e);
            }
        }

        public void BoilWater()
        {
            for (int i = 0; i <= 200; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    BoiledEventArgs e = new BoiledEventArgs(temperature);
                    OnBoiled(e);
                }
            }
        }
    }

    public class Alarm
    {
        public void MakeAlert(Object sender, Heater.BoiledEventArgs e)
        {
            Heater heater = (Heater)sender;
            Console.WriteLine("Alarm: {0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Alarm: Water has been boiled! Temperature: {0}°C", e.temperature);
            Console.WriteLine();
        }
    }

    public class Display
    {
        // 静态的可被委托的方法。
        public static void ShowMsg(Object sender, Heater.BoiledEventArgs e)
        {
            Heater heater = (Heater)sender;
            Console.WriteLine("Display: {0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Display: Water is {0}°C now", e.temperature);
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            Heater heater = new Heater();
            Alarm alarm = new Alarm();

            heater.Boiled += alarm.MakeAlert;
            // heater.Boiled += (new Alarm()).MakeAlert;
            // heater.Boiled += new Heater.BoiledEventHandler(alarm.MakeAlert);

            heater.Boiled += Display.ShowMsg;

            heater.BoilWater();
        }
    }
}