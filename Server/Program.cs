using System.Data;
using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using System.Text;
using Server;
using NotesClasses;
using Microsoft.IdentityModel.Tokens;

const int PORT = 4444;
IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, PORT);
var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(endPoint);
socket.Listen();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Server start...");

using (Context context = new Context())
{
    using (Socket clientSocket = await socket.AcceptAsync())
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Client connect... {clientSocket.RemoteEndPoint}");
        if (clientSocket.Connected)
        {
            SendData(context, clientSocket);
            while (true)
            {
                byte[] data = ReceiveAll(clientSocket);
                if (data.Length > 0)
                {
                    string s = Encoding.Unicode.GetString(data);
                    List<Note> n = JsonSerializer.Deserialize<List<Note>>(s);
                    context.Notes.RemoveRange(context.Notes);
                    context.Notes.AddRange(n);
                    context.SaveChanges();
                }
            }
        }
    }
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Client disconnect...");
socket.Close();
Console.WriteLine("Server end...");
Console.ReadLine();

void SendData(Context context, Socket socket)
{
    byte[] data = Encoding.Unicode.GetBytes(JsonSerializer.Serialize(context.Notes.ToList()));
    socket.Send(data);
    Console.WriteLine($"Data has been sent to the Client");
}

byte[] ReceiveAll(Socket socket)
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