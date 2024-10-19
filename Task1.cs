using System.Net;
using System.Net.NetworkInformation;

class Program
{
    static void Main()
    {
        string hostname = Dns.GetHostName();
        Console.WriteLine($"Host name: {hostname}");

        NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

        foreach (NetworkInterface netInterface in interfaces)
        {
            Console.WriteLine($"\nNet netInterface: {netInterface.Name}\nMAC-Address: {netInterface.GetPhysicalAddress()}");

            IPInterfaceProperties properties = netInterface.GetIPProperties();
            foreach (UnicastIPAddressInformation ipInfo in properties.UnicastAddresses)
            {
                if (ipInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    Console.WriteLine($"IP-Address: {ipInfo.Address}");
                }
            }
            Console.WriteLine($"Status: {netInterface.OperationalStatus}");
        }
    }
}
