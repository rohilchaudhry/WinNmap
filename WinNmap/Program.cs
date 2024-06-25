using System.Net;
using System.Net.Sockets;
using CommandLine;

/// <summary> 
/// The following file contains a basic example of a port scanner.
/// This scanner uses C#
/// </summary>
class WinNmap
{
    public class Options
    {
        [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }

        [Option('i', "ip", Required = true, HelpText = "The IP address of the target host.")]
        public string Ip { get; set; }

        [Option('p', "port", Required = true, HelpText = "The port of the target host.")]
        public int Port { get; set; }
    }

    static void Main(String[] args)
    {
        //Main function, checks for given args correctness
        //then forwards to check the connection
        string ipAddress = null;
        int port = 0;
        
        Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    if (o.Verbose)
                    {
                        //placeholder for a verbose output mode
                        Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                    }
                    if (o.Ip != null)
                    {
                        //TODO: Perform Ip checking
                        ipAddress = o.Ip;
                    }
                    if (o.Port != null) 
                    {
                        //TODO: Perform bounds check
                        port = o.Port;
                    }
                });
        
       
        if (CheckConnect(ipAddress, port))
        {
            Console.WriteLine("Port Open");
        }
        else
        {
            Console.WriteLine("Port Closed");
        }
        return;
        
    }

    public static bool CheckConnect(string ipAddress, int port)
    {
        //Use raw sockets
        //send a simple tcp syn
        //wait for the response

        //Parse IP, and create an endpoint
        //IPEndPoint host = new IPEndPoint(IPAddress.Parse(ipAddress),port);

        //Create an INET TCP socket
        Socket connectSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //Check if able to connect or not and return status accordingly
        try
        {
            connectSocket.ReceiveTimeout = 1;
            connectSocket.Connect(IPAddress.Parse(ipAddress), port);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
