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

}