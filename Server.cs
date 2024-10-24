using System.Data.SQLite;
using System.Net;
using System.Net.Sockets;
using System.Text;

class TcpServer
{
    static Socket? serverSocket;
    static TcpListener? listener;
    static SQLiteConnection? sqliteConnection;
    static List<TcpClient> clients = new List<TcpClient>();

    static void Main()
    {
        Task1Server();
        //Task2Server();
        //Task3Server();
    }

    static void Task1Server()
    {
        sqliteConnection = new SQLiteConnection("Data Source=../../../messages.db;");
        sqliteConnection.Open();
        var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Messages (Id INTEGER PRIMARY KEY AUTOINCREMENT, Content TEXT)", sqliteConnection);
        command.ExecuteNonQuery();

        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 6666);
        serverSocket = new Socket(
            AddressFamily.InterNetwork,
            SocketType.Stream,
            ProtocolType.Tcp);
        serverSocket.Bind(endPoint);
        serverSocket.Listen(10);

        Console.WriteLine("Server started. Waiting for connections...");

        while (true)
        {
            Socket clientSocket = serverSocket.Accept();
            Thread clientThread = new Thread(HandleClient);
            clientThread.Start(clientSocket);
        }

        static void HandleClient(object clientObject)
        {
            Socket clientSocket = (Socket)clientObject;
            byte[] buffer = new byte[1024];
            string receivedMessage;

            while (true)
            {
                int receivedBytes = clientSocket.Receive(buffer);
                receivedMessage = Encoding.UTF8.GetString(buffer, 0, receivedBytes);

                if (receivedMessage.ToUpper() == "EXIT")
                {
                    Console.WriteLine("Client disconnected.");
                    clientSocket.Close();
                    serverSocket.Close();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine($"Received: {receivedMessage}");
                    SaveMessageToDatabase(receivedMessage);
                }
            }
        }
    }

    static void Task2Server()
    {
        sqliteConnection = new SQLiteConnection("Data Source=../../../messages.db;");
        sqliteConnection.Open();
        var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Messages (Id INTEGER PRIMARY KEY AUTOINCREMENT, Content TEXT)", sqliteConnection);
        command.ExecuteNonQuery();

        listener = new TcpListener(IPAddress.Any, 6667);
        listener.Start();
        Console.WriteLine("Server started. Waiting for connections...");

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            Thread clientThread = new Thread(HandleClient);
            clientThread.Start(client);
        }

        static void HandleClient(object clientObject)
        {
            TcpClient client = (TcpClient)clientObject;
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            string receivedMessage;

            while (true)
            {
                int receivedBytes = stream.Read(buffer, 0, buffer.Length);
                receivedMessage = Encoding.UTF8.GetString(buffer, 0, receivedBytes);

                if (receivedMessage.ToUpper() == "EXIT")
                {
                    Console.WriteLine("Client disconnected.");
                    client.Close();
                    listener.Stop();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine($"Received: {receivedMessage}");
                    SaveMessageToDatabase(receivedMessage);
                }
            }
        }
    }

    private static void SaveMessageToDatabase(string message)
    {
        var command = new SQLiteCommand("INSERT INTO Messages (Content) VALUES (@content)", sqliteConnection);
        command.Parameters.AddWithValue("@content", message);
        command.ExecuteNonQuery();
        Console.WriteLine("Message saved to database.");
    }

    static void Task3Server()
    {
        listener = new TcpListener(IPAddress.Any, 6668);
        listener.Start();
        Console.WriteLine("Server started on port 6668.");

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            lock (clients)
            {
                clients.Add(client);
            }
            Console.WriteLine("New client connected.");
            Thread clientThread = new Thread(HandleClient);
            clientThread.Start(client);
        }

        static void HandleClient(object clientObject)
        {
            TcpClient client = (TcpClient)clientObject;
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Received: {message}");

                    BroadcastMessage(message, client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Client error: {ex.Message}");
            }
            finally
            {
                lock (clients)
                {
                    clients.Remove(client);
                }
                client.Close();
                Console.WriteLine("Client disconnected.");
            }
        }

        static void BroadcastMessage(string message, TcpClient sender)
        {
            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);

            lock (clients)
            {
                foreach (var client in clients)
                {
                    if (client != sender)
                    {
                        try
                        {
                            NetworkStream stream = client.GetStream();
                            stream.Write(messageBuffer, 0, messageBuffer.Length);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error sending message to client: {ex.Message}");
                        }
                    }
                }
            }
        }
    }
}
