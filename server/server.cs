using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace server
{
    public partial class server : Form
    {
        public server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            connect();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Socket item in clientlist)
            {
                send(item);
            }
            addMessage("Server:   " + textBox1.Text);
            textBox1.Clear();
        }

        IPEndPoint IP;
        Socket server1;
        //khai báo 1 list các client
        List<Socket> clientlist;
        void connect()
        {
            //khởi tạo 1 list nhiều client
            clientlist = new List<Socket>();
            //khởi tạo địa chỉ IP và socket để kết nối
            IP = new IPEndPoint(IPAddress.Any, 8765);
            server1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //đợi kết nối từ client
            server1.Bind(IP);

            //tạo 1 luồng lăng nghe từ client
            Thread listen = new Thread(() =>

            {
                try
                {
                    while (true)
                    {
                        server1.Listen(100);
                        Socket client = server1.Accept();//nếu lăng nghe thành công thì server chấp nhận kết nối
                        clientlist.Add(client);//thêm các client được server accept vào list
                        //tạo luồng nhận thông tin từ client
                        Thread receive1 = new Thread(Receive);
                        receive1.IsBackground = true;
                        receive1.Start(client);
                    }

                }
                /*khi kết nối đến n client mà có 1 client disconnect thì server sẽ chạy vòng lặp while liên tục để
                 chương trình ko bị crash*/
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 8888);
                    server1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                }
            });

            listen.IsBackground = true;
            listen.Start();

        }
        void close()
        {
            server1.Close();
        }
        //gui message
        void send(Socket client)
        {
            //nếu textboc khác rỗng thì mới gửi tin
            if (textBox1.Text != string.Empty && client != null)
                client.Send(Serialize("Server:   " + textBox1.Text));

        }
        void Receive(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    //khởi tạo mảng byte để nhận dữ liệu
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data, 0, data.Length, SocketFlags.None);
                    //chuyển data từ dạng byte sang dạng string
                    string message = (string)Deserialize(data);
                    addMessage(message);
                }
            }
            catch
            {
                clientlist.Remove(client);
                client.Close();
            }



        }
        void addMessage(string s)
        {
            listserver.Items.Add(new ListViewItem() { Text = s });
        }
        byte[] Serialize(object obj)
        {
            //khởi tạo stream để lưu các byte phân mảnh
            MemoryStream stream = new MemoryStream();
            //khởi tạo đối tượng BinaryFormatter để phân mảnh dữ liệu sang kiểu byte
            BinaryFormatter formatter = new BinaryFormatter();
            //phân mảnh rồi ghi vào stream
            formatter.Serialize(stream, obj);
            //từ stream chuyển các các byte thành dãy rồi cbi gửi đi
            return stream.ToArray();
        }
        //Hàm gom mảnh các byte nhận được rồi chuyển sang kiểu string để hiện thị lên màn hình
        object Deserialize(byte[] data)
        {
            //khởi tạo stream đọc kết quả của quá trình phân mảnh 
            MemoryStream stream = new MemoryStream(data);
            //khởi tạo đối tượng chuyển đổi
            BinaryFormatter formatter = new BinaryFormatter();
            //chuyển đổi dữ liệu và lưu lại kết quả 
            return formatter.Deserialize(stream);

        }
    }
}
