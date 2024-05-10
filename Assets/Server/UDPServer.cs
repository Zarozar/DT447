using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Text;

public class UDPServer
{
    public const int PORT = 5000;

    private Socket _socket;
    private EndPoint _ep;

    private byte[] _buffer_recv;
    private ArraySegment<byte> _buffer_recv_segment;

    public void Initialize()
    {
        _buffer_recv = new byte[4096];
        _buffer_recv_segment = new(_buffer_recv);

        _ep = new IPEndPoint(IPAddress.Any, PORT);

        _socket = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        /*_socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.PacketInformation, true);*/
        _socket.Bind(_ep);
    }

    public void StartMessageLoop()
    {
        _ = Task.Run(async () =>
        {
            SocketReceiveMessageFromResult res;
            while (true)
            {
                res = await _socket.ReceiveMessageFromAsync(_buffer_recv_segment, SocketFlags.None, _ep);
                await SendTo(res.RemoteEndPoint, Encoding.UTF8.GetBytes("Hello back!"));
            }
        });
    }

    public async Task SendTo(EndPoint recipient, byte[] data)
    {
        var s = new ArraySegment<byte>(data);
        await _socket.SendToAsync(s, SocketFlags.None, recipient);
    }

}

class Program
{
    public static void Main(string[] args)
    {
        var server = new UDPServer();
        server.Initialize();
        server.StartMessageLoop();
        Console.WriteLine("Server Listening");

        Console.ReadLine();

    }

}