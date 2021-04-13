using Alerts.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alerts
{
    class Methods
    {


        [DllImport("user32")]
        public static extern void LockWorkStation();

        public static string[] InitAlertWords()
        {
            List<string> alertWords = new List<string>();
            using (SQLiteConnection Connect = new SQLiteConnection(Settings.Con))
            {
                Connect.Open();
                SQLiteCommand Command = new SQLiteCommand
                {
                    Connection = Connect,
                    CommandText = @"SELECT * FROM [AlertWords]"
                };
                SQLiteDataReader sqlReader = Command.ExecuteReader();
                while (sqlReader.Read())
                {
                    alertWords.Add(sqlReader["AlertWord"].ToString());
                }
            }
            return alertWords.ToArray();
        }

        public static string[] InitAlertApps()
        {
            List<string> alertWords = new List<string>();
            using (SQLiteConnection Connect = new SQLiteConnection(Settings.Con))
            {
                Connect.Open();
                SQLiteCommand Command = new SQLiteCommand
                {
                    Connection = Connect,
                    CommandText = @"SELECT * FROM [AlertApps]"
                };
                SQLiteDataReader sqlReader = Command.ExecuteReader();
                while (sqlReader.Read())
                {
                    alertWords.Add(sqlReader["AlertApp"].ToString());
                }
            }
            return alertWords.ToArray();
        }

        public static void InitDb()
        {
            if (!File.Exists(@"AlertDB.db")) // если базы данных нету, то...
            {
                SQLiteConnection.CreateFile(@"AlertDB.db");
            }
            using (SQLiteConnection Connect = new SQLiteConnection(Settings.Con)) // в строке указывается к какой базе подключаемся
            {
                // строка запроса, который надо будет выполнить
                string commandText = "CREATE TABLE IF NOT EXISTS [AlertWords] ( [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [AlertWord] NVARCHAR(255))"; // создать таблицу, если её нет
                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                Connect.Open(); // открыть соединение
                Command.ExecuteNonQuery(); // выполнить запрос
                Connect.Close(); // закрыть соединение
                commandText = "CREATE TABLE IF NOT EXISTS [AlertApps] ( [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [AlertApp] NVARCHAR(255))"; // создать таблицу, если её нет
                Command = new SQLiteCommand(commandText, Connect);
                Connect.Open(); // открыть соединение
                Command.ExecuteNonQuery(); // выполнить запрос
                Connect.Close(); // закрыть соединение
            }
        }

        public static bool SetAutorunValue(bool autorun)
        {
            string executablePath = Application.ExecutablePath;
            var nameApp = "Alerts.exe";
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (autorun)
            {
                if (reg.GetValue(nameApp) == null)
                {
                    reg.SetValue(nameApp, executablePath);
                    reg.Close();
                    return true;
                }
                else
                    return false;
            }
            else
            {
                if (reg.GetValue(nameApp) != null)
                {
                    reg.DeleteValue(nameApp);
                    reg.Close();
                    return true;
                }
                else
                    return false;
            }
        }

        public static bool CheckAutorun()
        {
            var nameApp = "Alerts.exe";
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (reg.GetValue(nameApp) != null)
                return true;
            else
                return false;

        }


        public static void ScreenShot()
        {

            if (!System.IO.Directory.Exists(@"SavedScreens\"))
            {
                System.IO.Directory.CreateDirectory(@"SavedScreens\");
            }
            string fileName = String.Format(@"SavedScreens\{0}.jpg", DateTime.Now.ToString().Replace(".", "_").Replace(":", "_"));
            Bitmap BM = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics GH = Graphics.FromImage(BM as Image);
            GH.CopyFromScreen(0, 0, 0, 0, BM.Size);
            BM.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);

        }

        public static void Blocking()
        {
            LockWorkStation();
        }


    }
}
