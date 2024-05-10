using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;
using UnityEngine;
using System.Collections.Generic;

public class ClientCode : MonoBehaviour 
{
    UDPClient client;

    private void Start()
    {
        client = new UDPClient();
        client.Initialize(IPAddress.Loopback, UDPServer.PORT);
    }

    async void Update()
    {
        client.StartMessageLoop();
        await client.Send(Encoding.UTF8.GetBytes("Hello!"));
        UnityEngine.Debug.Log("Msg Sent");

        UnityEngine.Debug.Log(Console.ReadLine());
    }


}
