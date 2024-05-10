using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;
using UnityEngine;
using System.Collections.Generic;

public class NetworkManager
{
    void Start()
    {
        var server = new UDPServer();
        server.Initialize();
        server.StartMessageLoop();
        UnityEngine.Debug.Log("Server Listening");

        UnityEngine.Debug.Log(Console.ReadLine());
    }


}
