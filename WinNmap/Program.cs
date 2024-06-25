using System.Net;
using System.Net.Sockets;

/// <summary> 
/// The following file contains a basic example of a port scanner.
/// This scanner uses C#
/// </summary>
class WinNmap
{
    static void Main(String[] args)
    {
        //Main function, checks for given args correctness
        //then forwards to check the connection
        string ipAddress = null;
        int port = 0;
        if (args.Length < 2)
        {
            HelpPrinter();
            System.Environment.Exit(1);
            return;
        }
        else
        {
            ipAddress = args[0];
            port = Convert.ToInt32(args[1]);
        }
       
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
    
    static void HelpPrinter()
    {
        //Placeholder for a proper print usage function
        Console.WriteLine("USAGE Info:\n" +
            "WinNmap <IP> <Port>");
    }
}
