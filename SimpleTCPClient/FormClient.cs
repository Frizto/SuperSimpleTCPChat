using SuperSimpleTcp;
using System.Text;

namespace SimpleTCPClient
{
    public partial class FormClient : Form
    {
        public FormClient()
        {
            InitializeComponent();
        }

        SimpleTcpClient _client;
        private void FormClient_Load(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (_client.IsConnected)
            {
                if (!string.IsNullOrEmpty(txtMsgInput.Text))
                {
                    _client.Send(txtMsgInput.Text);
                    txtBox.Text += $"Me: {txtMsgInput.Text}{Environment.NewLine}";
                    txtMsgInput.Text = string.Empty;
                }
            }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            txtBox.Text += $"Connecting to the server...{Environment.NewLine}";
            try
            {
                _client = new SimpleTcpClient(txtIp.Text);
                _client.Events.Connected += Events_Connected;
                _client.Events.DataReceived += Events_DataReceived;
                _client.Events.Disconnected += Events_Disconnected;
                _client.Connect();
                btnSend.Enabled = true;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            txtBox.Text += $"Disconnecting from the server...{Environment.NewLine}";
            
            btnSend.Enabled = false;
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            //_client.Disconnect();

        }
        private void Events_Connected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtBox.Text += $"Server connected. {Environment.NewLine}";
            });
        }
        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtBox.Text += $"Server Admin: {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
            });
        }

        private void Events_Disconnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtBox.Text += $"disconnected from the server. {Environment.NewLine}";
            });
        }


    }
}