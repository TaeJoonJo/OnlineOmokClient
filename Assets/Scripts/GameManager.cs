using MessagePack;
using MessagePack.Resolvers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static NetworkManager ClientNetworkManager;

    // Start is called before the first frame update
    void Start()
    {
        //StaticCompositeResolver.Register(new IFormatterResolver[] { MessagePack.Resolvers.Gen });
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
    void Update()
    {
        if (ClientNetworkManager.IsConnected)
        {
            DispatchPacket();
        }
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
            switch ((GatewayServer.ClientGatePacketID)packetData.PacketHeader.PacketID)
            {
                case GatewayServer.ClientGatePacketID.ResLogin:
                    {
                        var packet = MessagePackSerializer.Deserialize<GatewayServer.PKTResLogin>(packetData.PacketBody);
                        SendMessage("RecvLoginResult", packet.Result);
                    } break;
            }
        }
    }
}
