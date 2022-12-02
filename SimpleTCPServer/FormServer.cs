using SuperSimpleTcp;
using System.Text;

namespace SimpleTCPServer
{
    public partial class FormServer : Form
    {
        public FormServer()
        {
            InitializeComponent();
        }

        SimpleTcpServer _server;
        private void FormServer_Load(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            _server = new SimpleTcpServer(txtServerName.Text);
            _server.Events.ClientConnected += Events_ClientConnected;
            _server.Events.ClientDisconnected += Events_ClientDisconnected;
            _server.Events.DataReceived += Events_DataReceived;
        }



        private void btnStart_Click(object sender, EventArgs e)
        {
            _server.Start();
            txtBody.Text += $"Starting server...{Environment.NewLine}";
            btnStart.Enabled = false;
            btnSend.Enabled = true;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            // Check the server
            if (_server.IsListening)
            {
                //Check the message and one of the listed ips is selected
                if (!string.IsNullOrEmpty(txtMessage.Text) && listConnectedIP.SelectedItem != null)
                {
                    _server.Send(listConnectedIP.SelectedItem.ToString(), txtMessage.Text);
                    txtBody.Text += $"Server:{txtMessage.Text}{Environment.NewLine}";
                    txtMessage.Text = string.Empty;
                }
            }
        }
        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            txtBody.Text += $"{e.IpPort}: {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
        }
        private void Events_ClientConnected(object? sender, ConnectionEventArgs e)
        {
            listConnectedIP.Items.Add(e.IpPort);
            txtBody.Text += $"{e.IpPort}: connected to the server {Environment.NewLine}";
        }
        private void Events_ClientDisconnected(object? sender, ConnectionEventArgs e)
        {
            listConnectedIP.Items.Remove(e.IpPort);
            txtBody.Text += $"{e.IpPort}: disconnected from the server {Environment.NewLine}";
        }


    }
}