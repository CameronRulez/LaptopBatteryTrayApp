using LaptopBatteryTrayApp.Properties;
using System;
using System.Windows.Forms;
using System.Timers;

namespace LaptopBatteryTrayApp
{
    static class Program
    {
        public static MyCustomApplicationContext ctx;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ctx = new MyCustomApplicationContext();
            Application.Run(ctx);
        }
    }


    public class MyCustomApplicationContext : ApplicationContext
    {
        public NotifyIcon trayIcon;

        public MyCustomApplicationContext()
        {
            int batteryLevel = (int)(SystemInformation.PowerStatus.BatteryLifePercent * 100);
            trayIcon = new NotifyIcon()
            {
                Icon = (System.Drawing.Icon)Resources.ResourceManager.GetObject("battery" + batteryLevel.ToString()),
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Exit", Exit)
            }),
                Visible = true
            };
            new Monitoring();
        }
        void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }
    }
    public class Monitoring
    {
        private System.Timers.Timer aTimer;
        private int prevBatteryLevel;
        public Monitoring()
        {
            prevBatteryLevel = (int)Math.Round(SystemInformation.PowerStatus.BatteryLifePercent * 100);
            aTimer = new System.Timers.Timer(10000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            int newPow = (int)Math.Round(SystemInformation.PowerStatus.BatteryLifePercent * 100);
            if (newPow != prevBatteryLevel)
            {
                prevBatteryLevel = newPow;
                Program.ctx.trayIcon.Icon = (System.Drawing.Icon)Resources.ResourceManager.GetObject("battery" + newPow.ToString());
            }
        }
    }
}
