using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class client : Form
    {
        
        public client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            connect();

        }

        // ket noi server

        IPEndPoint IP;
        Socket client1;



        void connect()
        {

            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8765);
            client1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client1.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối với server!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Thread listen = new Thread(receive);
            listen.IsBackground = true;
            listen.Start();
        }
        private void btnclient_Click(object sender, EventArgs e)
        {
            //
        }

        void receive()
        {
            try
            {
                while (true)
                {

                    byte[] data = new byte[1024 * 5000];
                    client1.Receive(data, 0, data.Length, SocketFlags.None);

                    string message = (string)Deserialize(data);
                    addMessage(message);
                }
            }
            catch
            {
                Close();
            }



        }

        void close()
        {
            client1.Close();
        }

        //add mesage vào khung chat
        void addMessage(string s)
        {
            listclient.Items.Add(new ListViewItem() { Text = s });
            txtbclient.Clear();
        }
        object Deserialize(byte[] data)
        {
            //khởi tạo stream đọc kết quả của quá trình phân mảnh 
            MemoryStream stream = new MemoryStream(data);
            //khởi tạo đối tượng chuyển đổi
            BinaryFormatter formatter = new BinaryFormatter();
            //chuyển đổi dữ liệu và lưu lại kết quả 

            return formatter.Deserialize(stream);

        }

        private void client_Load(object sender, EventArgs e)
        {

        }
    }
}
