using NotesClasses;
using System.Net.Sockets;
using System.Text.Json;
using System.Text;
using System.Web;

namespace Notes_WF
{
    public partial class Notes : Form
    {
        private const int PORT = 4444;
        private const string IP = "127.0.0.1";
        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private List<Note> notes = new List<Note>();
        public Notes()
        {
            InitializeComponent();
            ConnectAndGetData();
        }

        private async void ConnectAndGetData()
        {
            notes.Clear();
            this.NotesList_lb.Items.Clear();
            try
            {
                await socket.ConnectAsync(IP, PORT);
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        if (socket.Available > 0)
                        {
                            byte[] data = ReceiveAll(socket);
                            notes = JsonSerializer.Deserialize<List<Note>>(Encoding.Unicode.GetString(data));
                            break;
                        }
                    }
                }).Wait();
                notes.ForEach(note => NotesList_lb.Items.Add(note.name));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void SetDataOnIndexChange(object sender, EventArgs e)
        {
            if (NotesList_lb.SelectedIndex > -1)
            {
                this.Name_tb.Text = NotesList_lb.SelectedItem.ToString();
                this.Text_tb.Text = notes.FirstOrDefault(n => n.name.Equals(this.Name_tb.Text)).text;
                this.Date_dp.Value = notes.FirstOrDefault(n => n.name.Equals(this.Name_tb.Text)).modified;
            }
            else
            {
                this.Name_tb.Text = string.Empty;
                this.Text_tb.Text = string.Empty;
                this.Date_dp.Value = DateTime.Now;
            }
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if (this.Name_tb.Text.Equals(string.Empty) || this.Text_tb.Text.Equals(string.Empty)) return;
            if (!notes.Any(n => n.name.Equals(this.Name_tb.Text)))
            {
                Note temp = new Note() { name = this.Name_tb.Text, text = this.Text_tb.Text, modified = this.Date_dp.Value };
                notes.Add(temp);
                NotesList_lb.Items.Add(temp.name);
                SendUpdates();
            }
            else
            {
                Note temp = notes.Find(n => n.name.Equals(this.Name_tb.Text));
                temp.name = this.Name_tb.Text;
                temp.text = this.Text_tb.Text;
                temp.modified = this.Date_dp.Value;
                NotesList_lb.SelectedItem = this.Name_tb.Text;
                SendUpdates();
            }
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            Note temp = notes.FirstOrDefault(n => n.name.Equals(this.Name_tb.Text));
            NotesList_lb.Items.Remove(this.Name_tb.Text);
            notes.Remove(temp);
            SendUpdates();
        }

        private void NewClick(object sender, EventArgs e)
        {
            this.Name_tb.Text = string.Empty;
            this.Text_tb.Text = string.Empty;
            this.Date_dp.Value = DateTime.Now;
        }


        private async void SendUpdates()
        {
            byte[] data = new byte[1024];
            string temp = JsonSerializer.Serialize(notes);
            data = Encoding.Unicode.GetBytes(temp);
            socket.Send(data);
        }

        private byte[] ReceiveAll(Socket socket)
        {
            List<byte> buffer = new List<byte>();

            while (socket.Available > 0)
            {
                var currByte = new Byte[1];
                var byteCounter = socket.Receive(currByte, currByte.Length, SocketFlags.None);

                if (byteCounter.Equals(1))
                {
                    buffer.Add(currByte[0]);
                }
            }

            return buffer.ToArray();
        }
    }
}