﻿using MessagePack;
using MessagePack.Resolvers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public delegate void PacketFunc(object data);

    public static PacketFunc RecvLoginResult;

    public static NetworkManager ClientNetworkManager;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Initalize();
        
    }

    public void Initalize()
    {
        InitMsgPack();

        ClientNetworkManager = new NetworkManager();

        ClientNetworkManager.Initalize();
    }

    static void InitMsgPack()
    {
        StaticCompositeResolver.Instance.Register(new IFormatterResolver[]
        {
            MessagePack.Resolvers.GeneratedResolver.Instance,
            MessagePack.Resolvers.StandardResolver.Instance
        });

        var resolver = StaticCompositeResolver.Instance;
        MessagePackSerializer.DefaultOptions = MessagePackSerializerOptions.Standard.WithResolver(resolver);
    }

    // Update is called once per frame
    public void Update()
    {
        if (ClientNetworkManager.IsConnected)
        {
            DispatchPacket();
        }
    }

    void OnApplicationQuit()
    {
        ClientNetworkManager.Disconnect();
    }

    void OnDestroy()
    {
        ClientNetworkManager.Disconnect();
    }

    void DispatchPacket()
    {
        PacketDef.PacketData packetData = null;

        while(ClientNetworkManager.GetPacket(out packetData) == true)
        {
            switch ((PacketDef.ClientGatePacketID)packetData.PacketHeader.PacketID)
            {
                case PacketDef.ClientGatePacketID.ResLogin:
                    {
                        Debug.Log("Recv ResLogin");
                        var packet = MessagePackSerializer.Deserialize<GatewayServer.Packet.PKTResLogin>(packetData.PacketBody);
                        
                        RecvLoginResult(packet.Result);
                    } break;
            }
        }
    }
}
