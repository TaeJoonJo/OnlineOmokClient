using MessagePack;
using System;
using System.Collections.Generic;

namespace GatewayServer.Packet
{

    #region Client-GatewayServer

    [MessagePackObject]
    public class PKTReqLogin
    {
        [Key(0)]
        public String UserID;
        [Key(1)]
        public String AuthToken;
        [Key(2)]
        public UInt64 UniqueIndex;
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

    [MessagePackObject]
    public class PKTNTFLobbyChat
    {
        [Key(0)]
        public String Chat;
    }

    [MessagePackObject]
    public class PKTReqLobbyChat
    {
        [Key(0)]
        public String Chat;
    }

    [MessagePackObject]
    public class PKTReqMatching
    {
        [Key(0)]
        public Byte MatchingType;
    }

    [MessagePackObject]
    public class PKTNTFMatchingResult
    {
        [Key(0)]
        public UInt16 Result;
    }


    [MessagePackObject]
    public class PKTReqRoomEnter
    {
        [Key(0)]
        public String AuthToken;
    }

    [MessagePackObject]
    public class PKTResRoomEnter
    {
        [Key(0)]
        public UInt16 Result;
    }

    [MessagePackObject]
    public class PKTNTFGameInfo
    {
        [Key(0)]
        public UInt16 Result;
        [Key(1)]
        public String OpponentID;
        [Key(2)]
        public bool IsBlack;
    }

    [MessagePackObject]
    public class PKTReqGamePut
    {
        [Key(0)]
        public (int, int) ClickPos;
    }

    [MessagePackObject]
    public class PKTNTFGamePut
    {
        [Key(0)]
        public UInt16 Result;
        [Key(1)]
        public (int, int) PutPos;
        [Key(2)]
        public Byte Type;
    }

    [MessagePackObject]
    public class PKTNTFGameResult
    {
        [Key(0)]
        public UInt16 Result;
    }

    #endregion

}