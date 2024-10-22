using System.Net;
using System.Net.Sockets;
using System.Text;

class UDPServer
{
    static void Main()
    {
        Task1Server();
        //Task2Server();
        //Task3Server();
    }

    static void Task1Server()
    {
        Socket serverSocket = new Socket(
            AddressFamily.InterNetwork,
            SocketType.Dgram,
            ProtocolType.Udp);
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 6666);
        serverSocket.Bind(endPoint);

        Console.WriteLine("UDP Server is running and waiting for messages on port 6666...");

        byte[] buffer = new byte[1024];
        EndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);

        while (true)
        {
            int receivedBytes = serverSocket.ReceiveFrom(buffer, ref clientEndPoint);
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, receivedBytes);
            Console.WriteLine($"Received message: {receivedMessage} from {((IPEndPoint)clientEndPoint).Address}:{((IPEndPoint)clientEndPoint).Port}");

            string currentTime = DateTime.Now.ToString();
            byte[] timeBytes = Encoding.UTF8.GetBytes(currentTime);
            serverSocket.SendTo(timeBytes, clientEndPoint);
            Console.WriteLine($"Sent current time: {currentTime}");
        }
    }

    static void Task2Server()
    {
        UdpClient udpServer = new UdpClient(6667);
        IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
        Console.WriteLine("UDP server is running and waiting for messages on port 6667...");

        while (true)
        {
            byte[] clientData = udpServer.Receive(ref clientEndPoint);
            string receivedMessage = Encoding.UTF8.GetString(clientData);
            Console.WriteLine($"Received from {clientEndPoint.Address}:{clientEndPoint.Port}: {receivedMessage}");

            string currentTime = DateTime.Now.ToString();
            byte[] timeMessage = Encoding.UTF8.GetBytes(currentTime);
            udpServer.Send(timeMessage, timeMessage.Length, clientEndPoint);

            Console.WriteLine($"Sent current time: {currentTime}");

            break;
        }

        udpServer.Close();
    }

    static void Task3Server()
    {
        UdpClient udpServer = new UdpClient(6668);
        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 6668);

        Console.WriteLine($"Server started on port 6668. Waiting for client requests...");

        while (true)
        {
            byte[] receivedData = udpServer.Receive(ref remoteEndPoint);
            string receivedMessage = Encoding.UTF8.GetString(receivedData);

            Console.WriteLine($"[Server] Received message from {remoteEndPoint}: {receivedMessage}");

            string currentTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            byte[] data = Encoding.UTF8.GetBytes(currentTime);

            udpServer.Send(data, data.Length, remoteEndPoint);
            Console.WriteLine($"[Server] Sent Time: {currentTime} to {remoteEndPoint}");

            Thread.Sleep(1000);
        }
    }
}
