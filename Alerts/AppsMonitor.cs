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

        }
        static void startWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            Methods.Blocking();
        }

        public static async void MonitorAsync()
        {

                await Task.Run(() => Monitor());

        }


    }
}
