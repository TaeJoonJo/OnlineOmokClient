using MessagePack;
using System;


namespace GatewayServer
{
    #region Client-GatewayServer

    // Client - GatewayServer PacketID 정의 
    // 101 ~ 500
    public enum ClientGatePacketID : UInt16
    {
        ReqLogin = 101,
        ResLogin = 102,


    }

    #endregion


    [MessagePackObject]
    public class PKTHeader
    {
        [Key(0)]
        public UInt16 PacketSize;
        [Key(1)]
        public UInt16 PacketID;
        [Key(2)]
        public Byte PacketType;
    }

    #region Client-GatewayServer

    [MessagePackObject]
    public class PKTReqLogin //: PKTHeader
    {
        [Key(0)]
        public String UserID;
        [Key(1)]
        public String AuthToken;
    }

    [MessagePackObject]
    public class PKTResLogin //: PKTHeader
    {
        [Key(0)]
        public UInt16 Result;
    }

    #endregion

    #region Redis-GatewayServer

    [MessagePackObject]
    public class PKTResLoginResult //: PKTHeader
    {
        [Key(0)]
        public String UserID;
        [Key(1)]
        public bool isLoginOK;
    }

    #endregion
}