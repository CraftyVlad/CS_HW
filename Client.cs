using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class TcpClientApp
{
    static Socket? clientSocket;
    static TcpClient? client;
    static NetworkStream? stream;

    static void Main()
    {
        Task1Client();
        //Task2Client();
        //Task3Client();
    }

    static void Task1Client()
    {
        IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6666);
        clientSocket = new Socket(
            AddressFamily.InterNetwork,
            SocketType.Stream,
            ProtocolType.Tcp);

        clientSocket.Connect(serverEndPoint);
        Console.WriteLine("Connected to server.");

        while (true)
        {
            Console.Write("Enter message (or EXIT to disconnect): ");
            string message = Console.ReadLine()!;
            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
            clientSocket.Send(messageBuffer);

            if (message.ToUpper() == "EXIT")
            {
                clientSocket.Close();
                break;
            }
        }
    }

    static void Task2Client()
    {
        client = new TcpClient("127.0.0.1", 6667);
        NetworkStream stream = client.GetStream();
        Console.WriteLine("Connected to server.");

        while (true)
        {
            Console.Write("Enter message (or EXIT to disconnect): ");
            string message = Console.ReadLine()!;
            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
            stream.Write(messageBuffer, 0, messageBuffer.Length);

            if (message.ToUpper() == "EXIT")
            {
                client.Close();
                break;
            }
        }
    }

    static void Task3Client()
    {
        client = new TcpClient();
        Console.WriteLine("Connecting to server...");
        client.Connect("127.0.0.1", 6668);
        Console.WriteLine("Connected to server.");
        stream = client.GetStream();

        Thread receiveThread = new Thread(ReceiveMessages);
        receiveThread.Start();

        while (true)
        {
            string message = Console.ReadLine()!;
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);

            if (message.ToUpper() == "EXIT")
            {
                break;
            }
        }

        client.Close();
        Console.WriteLine("Disconnected from server.");

        static void ReceiveMessages()
        {
            byte[] buffer = new byte[1024];
            while (true)
            {
                try
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Message from user: {message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error receiving message: {ex.Message}");
                    break;
                }
            }
        }
    }
}
