
using Alerts.Model;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public  partial class Form1 : Form
    {
        private delegate void CallDelegate(Control control, string text);

        public  Form1()
        {
            InitializeComponent();
            Methods.InitDb();
            if (Methods.CheckAutorun()) checkBox1.CheckState = CheckState.Checked;
            alertWords.Lines = Methods.InitAlertWords();
            alertApps.Lines = Methods.InitAlertApps();
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            WordsMonitor.MonitorAsync();
            AppsMonitor.Monitor();



        }




        private void SaveAutorun(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Methods.SetAutorunValue(true);
            }
            else
            {
                Methods.SetAutorunValue(false);
            }
        }

        private void SaveAlertApps(object sender, EventArgs e)
        {
            string query = "";
            foreach (string o in alertApps.Lines)
            {
                query += String.Format("INSERT INTO[AlertApps]([AlertApp]) VALUES('{0}'); ", o);
            }
            using (SQLiteConnection Connect = new SQLiteConnection(Settings.Con))
            {
                string commandText = "DELETE FROM [AlertApps]";
                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                Connect.Open();
                Command.ExecuteNonQuery();
                Command = new SQLiteCommand(query, Connect);
                Command.ExecuteNonQuery();
                Connect.Close();
            }
            alertApps.Lines = Methods.InitAlertApps();
            AppsMonitor.MonitorAsync();
        }

        private void SaveAlertWords(object sender, EventArgs e)
        {
            string query = "";
            foreach (string o in alertWords.Lines)
            {
                query += String.Format("INSERT INTO[AlertWords]([AlertWord]) VALUES('{0}'); ", o);
            }
            using (SQLiteConnection Connect = new SQLiteConnection(Settings.Con))
            {
                string commandText = "DELETE FROM [AlertWords]";
                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                Connect.Open();
                Command.ExecuteNonQuery();
                Command = new SQLiteCommand(query, Connect);
                Command.ExecuteNonQuery();
                Connect.Close();
            }
            alertWords.Lines = Methods.InitAlertWords();
        }




        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
            }
        }

        private void ClickTray(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        public void BufKeyFill(string[] items)
        {
            System.Action action = () => bufKey.Lines=items;
            
           
            if (InvokeRequired)
                Invoke(action);
            else
                action();

        }

        public string[] GetWords()
        {
            return alertWords.Lines;
        }

    }
}

