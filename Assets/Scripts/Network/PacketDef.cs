using UnityEngine;
using UnityEditor;
using System;

public class PacketDef 
{
    public struct PacketHeader
    {
        public const UInt16 PacketHeaderSize = 5;

        public UInt16 PacketSize;
        public UInt16 PacketID;
        public Byte PacketType;
    }

    public class PacketData
    {
        public PacketHeader PacketHeader;
        public byte[] PacketBody;
    }

    public class PKTHandleHelper
    {
        public static byte[] MakePacket(UInt16 packetID, byte[] body)
        {
            UInt16 bodyDataSize = 0;
            if (body != null)
            {
                unchecked
                {
                    bodyDataSize = (UInt16)body.Length;
                }
            }
            var packetSize = bodyDataSize + PacketHeader.PacketHeaderSize;

            var dataSource = new byte[packetSize];
            Buffer.BlockCopy(BitConverter.GetBytes(packetSize), 0, dataSource, 0, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(packetID), 0, dataSource, 2, 2);
            //dataSource[4] = packetType;

            if (body != null)
            {
                Buffer.BlockCopy(body, 0, dataSource, 5, body.Length);
            }

            return dataSource;
        }
    }


    #region Client-GatewayServer

    // Client - GatewayServer PacketID 정의 
    // 101 ~ 500
    public enum ClientGatePacketID : UInt16
    {
        ReqLogin = 101,
        ResLogin = 102,

        Connect = 103,
        Disconnect = 104,

        ReqLobbyEnter = 105,
        ResLobbyEnter = 106,

        NTFLobbyChat = 107,
        ReqLobbyChat = 108,

        ReqRoomEnter = 109,
        ResRoomEnter = 110,

        ReqMatching = 111,
        NTFMatchingResult = 112,

        NTFGameInfo = 114,

        ReqGamePut = 120,
        NTFGamePut = 121,

        NTFGameResult = 125,
        //LobbyAddUser = 109,
        //LobbyDeleteUser = 110,
    }

    #endregion
}