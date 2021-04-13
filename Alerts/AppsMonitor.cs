using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Alerts
{
    class AppsMonitor
    {
       public static void Monitor()
        {
            string query = "";
            string[] apps = Methods.InitAlertApps();
            foreach (string app in apps)
            {
                ManagementEventWatcher startWatch = new ManagementEventWatcher(new WqlEventQuery("Win32_ProcessStartTrace", String.Format("ProcessName = \"{0}\"",app)));
                startWatch.EventArrived += startWatch_EventArrived;
                startWatch.Start();
            }
           /* ManagementEventWatcher startWatch = new ManagementEventWatcher(new WqlEventQuery(String.Format("SELECT * FROM Win32_ProcessStartTrace WHERE ProcessName in ({0})",app)));
               // new WqlEventQuery("Win32_ProcessStartTrace", String.Format("ProcessName = \"{0}\"",args)));
            startWatch.EventArrived += startWatch_EventArrived;
            startWatch.Start();*/
           // Console.ReadLine();
            //startWatch.Stop();
        }
        static void startWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            //Console.WriteLine("Process started: {0}", e.NewEvent.Properties["ProcessName"].Value);
            //e.NewEvent.Properties.OfType<PropertyData>().Select(p => new { p.Name, p.Value }).Dump();
            Methods.Blocking();
        }

        public static async void MonitorAsync()
        {
           /* string[] apps = Methods.InitAlertApps();
            foreach (string app in apps)
            {*/
                await Task.Run(() => Monitor());
           // }

        }


    }
}
