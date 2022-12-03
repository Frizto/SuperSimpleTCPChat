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
            btnClose.Enabled = false;
        }


        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtBox.Text += $"{e.IpPort} (User): {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
            });
        }
        private void Events_ClientConnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                listConnectedIP.Items.Add(e.IpPort);
                txtBox.Text += $"{e.IpPort} (User): connected to the server {Environment.NewLine}";
            });

        }
        private void Events_ClientDisconnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                listConnectedIP.Items.Remove(e.IpPort);
                txtBox.Text += $"{e.IpPort} (User): disconnected to the server {Environment.NewLine}";
            });
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            txtBox.Text += $"Starting server...{Environment.NewLine}";
            try
            {
                _server = new SimpleTcpServer(txtIp.Text);
                _server.Events.ClientConnected += Events_ClientConnected;
                _server.Events.ClientDisconnected += Events_ClientDisconnected;
                _server.Events.DataReceived += Events_DataReceived;

                _server.Start();
                txtBox.Text += $"Server open.{Environment.NewLine}";
                btnStart.Enabled = false;
                btnClose.Enabled = true;
                btnSend.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnSend_Click_1(object sender, EventArgs e)
        {
            // Check the server
            if (_server.IsListening)
            {
                //Check the message and one of the listed ips is selected
                if (!string.IsNullOrEmpty(txtMsgInput.Text) && listConnectedIP.SelectedItem != null)
                {
                    _server.Send(listConnectedIP.SelectedItem.ToString(), txtMsgInput.Text);
                    txtBox.Text += $"Server Admin: {txtMsgInput.Text}{Environment.NewLine}";
                    txtMsgInput.Text = string.Empty;
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            txtBox.Text += $"Stopping server...{Environment.NewLine}";
            try
            {
                _server.Stop();
                txtBox.Text += $"Server closed.{Environment.NewLine}";
                btnStart.Enabled = true;
                btnClose.Enabled = false;
                btnSend.Enabled = false;

                foreach (string client in listConnectedIP.Items)
                {
                    _server.DisconnectClient(client);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}