using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpellboundControl
{
    public class NetworkManager
    {
        private TcpListener _server;
        private readonly string _ipAddress;
        private readonly int _port;
        private Dictionary<string, TcpClient> deviceClientMap = new Dictionary<string, TcpClient>();
        public event Action<string> DebugMessageReceived;
        public event Action<string, string, string, string, string, string> DeviceInfoReceived;
        public event Action<string> ClientDisconnected;

        public event Action<List<Contact>> ContactsDataReceived;
        



        public NetworkManager(string ipAddress, int port)
        {
            _ipAddress = ipAddress;
            _port = port;
        }

        public async Task Start()
        {
            if (_server != null)
            {
                throw new InvalidOperationException("Server is already running!");
            }

            IPAddress localAddr = IPAddress.Parse(_ipAddress);
            _server = new TcpListener(localAddr, _port);
            _server.Start();

            DebugMessageReceived?.Invoke("Server started. Waiting for a connection...");

            while (true)
            {
                TcpClient client = await _server.AcceptTcpClientAsync();
                DebugMessageReceived?.Invoke($"Connected! Client IP: {client.Client.RemoteEndPoint}");
                _ = HandleClientAsync(client);
            }
        }

        public void Stop()
        {
            _server?.Stop();
            _server = null;
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                StringBuilder messageBuilder = new StringBuilder();

                string id = null;
                IPEndPoint clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;

                while (true)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        DebugMessageReceived?.Invoke($"Client {clientEndPoint} disconnected.");
                        if (id != null)
                        {
                            deviceClientMap.Remove(id);
                        }
                        ClientDisconnected?.Invoke(id);
                        break;
                    }

                    string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    messageBuilder.Append(data);

                    if (data.Length > 0)
                    {
                        string receivedMessage = messageBuilder.ToString().TrimEnd();
                        DebugMessageReceived?.Invoke($"{clientEndPoint}: {receivedMessage}");

                        if (receivedMessage.StartsWith("45666"))
                        {
                            DebugMessageReceived?.Invoke("#45666 received");

                            // Parsing the data
                            string clearMessage = receivedMessage.Substring(5); // Remove "45666"
                            List<Contact> contacts = ParseContactsData(clearMessage);

                            // Invoke the event with the parsed contacts
                            ContactsDataReceived?.Invoke(contacts);
                        }
                        else if (receivedMessage.StartsWith("#"))
                        {
                            string clearMessage = receivedMessage.Substring(1);
                            string[] parts = clearMessage.Split(',');

                            if (parts.Length == 6)
                            {
                                id = parts[0];
                                deviceClientMap[id] = client;
                                DeviceInfoReceived?.Invoke(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5]);
                            }
                            else
                            {
                                DebugMessageReceived?.Invoke($"{clientEndPoint}: Invalid data format.");
                            }
                        }
                        else if (receivedMessage.StartsWith("55555"))
                        {
                            // Remove "55555" prefix
                            string clearMessage = receivedMessage.Substring(5);

                            // Assuming the format is "55555(long,lat)"
                            // Remove the parentheses and split by comma
                            string[] coordinates = clearMessage.Trim('(', ')').Split(',');

                            if (coordinates.Length == 2)
                            {
                                // Parse the coordinates
                                if (double.TryParse(coordinates[0], out double longitude) && double.TryParse(coordinates[1], out double latitude))
                                {
                                    // Successfully parsed longitude and latitude
                                    Console.WriteLine($"Longitude: {longitude}, Latitude: {latitude}");
                                    //SetLongLatt
                                }
                                else
                                {
                                    Console.WriteLine("Invalid coordinates format.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid message format.");
                            }

                        }
                            byte[] response = Encoding.ASCII.GetBytes(receivedMessage.ToUpper() + Environment.NewLine);
                        await stream.WriteAsync(response, 0, response.Length);

                        messageBuilder.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                DebugMessageReceived?.Invoke($"Exception: {ex.Message}");
            }
        }


        // parse contact data from the string   
        private List<Contact> ParseContactsData(string data)
        {
            var contacts = new List<Contact>();

            // Remove any unwanted characters
            string cleanedData = data.Trim().Trim(new[] { '{', '}', '(', ')' });

            // Split entries
            string[] contactEntries = cleanedData.Split(new[] { "), (" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var entry in contactEntries)
            {
                string trimmedEntry = entry.Trim('(', ')');
                string[] parts = trimmedEntry.Split(new[] { ", " }, StringSplitOptions.None);

                // Validate parts length and format
                if (parts.Length == 4)
                {
                    contacts.Add(new Contact
                    {
                        Id = parts[0].Trim(),
                        Name = parts[1].Trim(),
                        Number = parts[2].Trim(),
                        Email = parts[3].Trim()
                    });
                }
                else
                {
                    DebugMessageReceived?.Invoke($"Invalid contact format: {entry}");
                }
            }

            return contacts;
        }




        public void SendCommandToDevice(string deviceId, string command)
        {
            if (deviceClientMap.TryGetValue(deviceId, out TcpClient client))
            {
                NetworkStream stream = client.GetStream();
                byte[] commandBytes = Encoding.ASCII.GetBytes(command + Environment.NewLine);
                stream.Write(commandBytes, 0, commandBytes.Length);
                DebugMessageReceived?.Invoke($"Command sent to device with ID: {deviceId}");
            }
            else
            {
                DebugMessageReceived?.Invoke($"Failed to send command. Device with ID: {deviceId} not found.");
            }
        }

    }
}
