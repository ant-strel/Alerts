
using System;
using System.Windows.Forms;

namespace Alerts
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bufKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveAlertWordsBtn = new System.Windows.Forms.Button();
            this.alertWords = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.saveAlertAppsBtn = new System.Windows.Forms.Button();
            this.alertApps = new System.Windows.Forms.TextBox();
            this.saveAutorunBtn = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(36, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(195, 19);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Запускать при старте Windows";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bufKey);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.saveAlertWordsBtn);
            this.panel1.Controls.Add(this.alertWords);
            this.panel1.Location = new System.Drawing.Point(-2, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 402);
            this.panel1.TabIndex = 1;
            // 
            // bufKey
            // 
            this.bufKey.Location = new System.Drawing.Point(25, 34);
            this.bufKey.Multiline = true;
            this.bufKey.Name = "bufKey";
            this.bufKey.Size = new System.Drawing.Size(328, 60);
            this.bufKey.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = " Буфер клавиатуры";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Alert-слова";
            // 
            // saveAlertWordsBtn
            // 
            this.saveAlertWordsBtn.Location = new System.Drawing.Point(278, 352);
            this.saveAlertWordsBtn.Name = "saveAlertWordsBtn";
            this.saveAlertWordsBtn.Size = new System.Drawing.Size(75, 23);
            this.saveAlertWordsBtn.TabIndex = 1;
            this.saveAlertWordsBtn.Text = "Сохранить";
            this.saveAlertWordsBtn.UseVisualStyleBackColor = true;
            this.saveAlertWordsBtn.Click += new System.EventHandler(this.SaveAlertWords);
            // 
            // alertWords
            // 
            this.alertWords.Location = new System.Drawing.Point(25, 133);
            this.alertWords.Multiline = true;
            this.alertWords.Name = "alertWords";
            this.alertWords.Size = new System.Drawing.Size(328, 195);
            this.alertWords.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.saveAlertAppsBtn);
            this.panel2.Controls.Add(this.alertApps);
            this.panel2.Location = new System.Drawing.Point(390, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 402);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Alert-приложения";
            // 
            // saveAlertAppsBtn
            // 
            this.saveAlertAppsBtn.Location = new System.Drawing.Point(288, 352);
            this.saveAlertAppsBtn.Name = "saveAlertAppsBtn";
            this.saveAlertAppsBtn.Size = new System.Drawing.Size(75, 23);
            this.saveAlertAppsBtn.TabIndex = 1;
            this.saveAlertAppsBtn.Text = "Сохранить";
            this.saveAlertAppsBtn.UseVisualStyleBackColor = true;
            this.saveAlertAppsBtn.Click += new System.EventHandler(this.SaveAlertApps);
            // 
            // alertApps
            // 
            this.alertApps.Location = new System.Drawing.Point(35, 133);
            this.alertApps.Multiline = true;
            this.alertApps.Name = "alertApps";
            this.alertApps.Size = new System.Drawing.Size(328, 195);
            this.alertApps.TabIndex = 0;
            // 
            // saveAutorunBtn
            // 
            this.saveAutorunBtn.Location = new System.Drawing.Point(259, 29);
            this.saveAutorunBtn.Name = "saveAutorunBtn";
            this.saveAutorunBtn.Size = new System.Drawing.Size(75, 23);
            this.saveAutorunBtn.TabIndex = 3;
            this.saveAutorunBtn.Text = "Сохранить";
            this.saveAutorunBtn.UseVisualStyleBackColor = true;
            this.saveAutorunBtn.Click += new System.EventHandler(this.SaveAutorun);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Alerts";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.ClickTray);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveAutorunBtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }




        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveAlertWordsBtn;
        public  System.Windows.Forms.TextBox alertWords;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button saveAlertAppsBtn;
        private System.Windows.Forms.TextBox alertApps;
        private System.Windows.Forms.Button saveAutorunBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public NotifyIcon notifyIcon1;
        private Label label3;
        public TextBox bufKey;

        
    }
}

