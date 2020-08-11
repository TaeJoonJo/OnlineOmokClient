using MessagePack;
using System;
using System.Collections.Generic;

namespace GatewayServer.Packet
{
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
    public class PKTReqLogin 
    {
        [Key(0)]
        public String UserID;
        [Key(1)]
        public String AuthToken;
    }

    [MessagePackObject]
    public class PKTResLogin 
    {
        [Key(0)]
        public UInt16 Result;
    }

    [MessagePackObject]
    public class PKTReqLobbyEnter
    {
        [Key(0)]
        public String AuthToken;
    }

    [MessagePackObject]
    public class PKTResLobbyEnter
    {
        [Key(0)]
        public UInt16 Result;
    }

    #endregion

}