using System.Net;
using System.Net.Sockets;
using System.Text;

class UDPClient
{
    static void Main()
    {
        Task1Client();
        //Task2Client();
        //Task3Client();
    }

    static void Task1Client()
    {
        Socket clientSocket = new Socket(
            AddressFamily.InterNetwork,
            SocketType.Dgram,
            ProtocolType.Udp);
        IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6666);

        Console.Write("Enter a message to send to the server: ");
        string message = Console.ReadLine()!;
        byte[] messageBytes = Encoding.UTF8.GetBytes(message);

        clientSocket.SendTo(messageBytes, serverEndPoint);
        Console.WriteLine("Message sent to the server.");

        byte[] buffer = new byte[1024];
        EndPoint serverResponseEndPoint = new IPEndPoint(IPAddress.Any, 0);
        int receivedBytes = clientSocket.ReceiveFrom(buffer, ref serverResponseEndPoint);
        string serverTime = Encoding.UTF8.GetString(buffer, 0, receivedBytes);
        Console.WriteLine($"Sent the current time to server: {serverTime}");

        clientSocket.Close();
    }

    static void Task2Client()
    {
        UdpClient udpClient = new UdpClient();
        IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6667);

        Console.Write("Enter a message to send to the server: ");
        string message = Console.ReadLine()!;
        byte[] messageBytes = Encoding.UTF8.GetBytes(message);

        udpClient.Send(messageBytes, messageBytes.Length, serverEndPoint);
        Console.WriteLine("Message sent to the server.");

        IPEndPoint serverResponseEndPoint = new IPEndPoint(IPAddress.Any, 0);
        byte[] buffer = udpClient.Receive(ref serverResponseEndPoint);
        string serverTime = Encoding.UTF8.GetString(buffer);
        Console.WriteLine($"Server sent the current time: {serverTime}");

        udpClient.Close();
    }

    static void Task3Client()
    {
        UdpClient udpClient = new UdpClient();
        IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6668);

        Console.WriteLine($"Client sending request to server at {serverEndPoint}...");

        while (true)
        {
            string requestMessage = "Requesting current time";
            byte[] requestData = Encoding.UTF8.GetBytes(requestMessage);
            udpClient.Send(requestData, requestData.Length, serverEndPoint);
            Console.WriteLine($"[Client] Sent: {requestMessage}");

            byte[] receivedData = udpClient.Receive(ref serverEndPoint);
            string currentTime = Encoding.UTF8.GetString(receivedData);
            Console.WriteLine($"[Client] Received Time: {currentTime}");

            Thread.Sleep(1000);
        }
    }
}
