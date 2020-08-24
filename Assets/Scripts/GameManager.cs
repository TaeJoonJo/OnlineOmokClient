using APIServer;
using MessagePack;
using MessagePack.Resolvers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public delegate void PacketFunc(object data);

    public static PacketFunc RecvLoginResult;
    public static PacketFunc RecvLobbyEnter;
    public static PacketFunc RecvLobbyChat;
    public static PacketFunc RecvMatchingResult;
    public static PacketFunc RecvRoomEnter;
    public static PacketFunc RecvGameInfo;
    public static PacketFunc RecvGamePut;
    public static PacketFunc RecvGameResult;

    public static NetworkManager ClientNetworkManager;

    public static UserInfo UserInfo;

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

    //void OnApplicationQuit()
    //{
    //    ClientNetworkManager.Disconnect();
    //}

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
                case PacketDef.ClientGatePacketID.ResLobbyEnter:
                    {
                        Debug.Log("Recv ResLobbyEnter");
                        var packet = MessagePackSerializer.Deserialize<GatewayServer.Packet.PKTResLobbyEnter>(packetData.PacketBody);

                        RecvLobbyEnter(packet.Result);
                    } break;
                case PacketDef.ClientGatePacketID.NTFLobbyChat:
                    {
                        Debug.Log("Recv NTFLobbyChat");
                        var packet = MessagePackSerializer.Deserialize<GatewayServer.Packet.PKTNTFLobbyChat>(packetData.PacketBody);

                        RecvLobbyChat(packet.Chat);
                    } break;
                case PacketDef.ClientGatePacketID.NTFMatchingResult:
                    {
                        Debug.Log("Recv NTFMatchingReuslt");
                        var packet = MessagePackSerializer.Deserialize<GatewayServer.Packet.PKTNTFMatchingResult>(packetData.PacketBody);

                        RecvMatchingResult(packet.Result);
                    } break;
                case PacketDef.ClientGatePacketID.ResRoomEnter:
                    {
                        Debug.Log("Recv ResRoomEnter");
                        var packet = MessagePackSerializer.Deserialize<GatewayServer.Packet.PKTResRoomEnter>(packetData.PacketBody);

                        RecvRoomEnter(packet.Result);
                    } break;
                case PacketDef.ClientGatePacketID.NTFGameInfo:
                    {
                        Debug.Log("Recv NTFGameInfo");
                        var packet = MessagePackSerializer.Deserialize<GatewayServer.Packet.PKTNTFGameInfo>(packetData.PacketBody);

                        //StartCoroutine(Sleep());
                        Thread.Sleep(5000);
                        RecvGameInfo(packet);
                    } break;
                case PacketDef.ClientGatePacketID.NTFGamePut:
                    {
                        var packet = MessagePackSerializer.Deserialize<GatewayServer.Packet.PKTNTFGamePut>(packetData.PacketBody);

                        RecvGamePut(packet);
                    } break;
                case PacketDef.ClientGatePacketID.NTFGameResult:
                    {
                        var packet = MessagePackSerializer.Deserialize<GatewayServer.Packet.PKTNTFGameResult>(packetData.PacketBody);

                        RecvGameResult(packet.Result);
                    } break;
            }

        }
        
        IEnumerator Sleep()
        {
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator Sleep()
    {
        yield return new WaitForSeconds(5f);
    }
}
