using ClientNetLib;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class NetworkManager
{
    public const int MTUSize = 1000;

    Socket Socket;

    ConcurrentQueue<byte[]> SendQueue;
    ConcurrentQueue<byte[]> RecvQueue;

    ConcurrentQueue<PacketDef.PacketData> PacketQueue;

    PacketBufferManager PacketBufferManager;

    Thread              NetworkThread;

    public bool IsConnected { get; private set;}

    public void Initalize()
    {
        if(Socket != null)
        {
            return;
        }

        Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        SendQueue = new ConcurrentQueue<byte[]>();
        RecvQueue = new ConcurrentQueue<byte[]>();
        PacketQueue = new ConcurrentQueue<PacketDef.PacketData>();

        PacketBufferManager = new PacketBufferManager();
        PacketBufferManager.Init(MTUSize * 8, 5, MTUSize);

        NetworkThread = new Thread(NetworkProcess);
    }

    public bool Connect(string ip, int port)
    {
        if(IsConnected == true)
        {
            return false;
        }

        try
        {
            Console.WriteLine($"Try to Connect IP : {ip}, Port : {port}");

            IPAddress serverIP = IPAddress.Parse(ip);
            
            Socket.Connect(new IPEndPoint(serverIP, port));

            if(Socket == null
                || Socket.Connected == false)
            {
                Debug.Log($"Connect Fail");
                return false;
            }

            Debug.Log($"Connect Success");

            NetworkThread.Start();

            IsConnected = true;

            return true;
        }
        catch(Exception ex)
        {
            Socket = null;
            Console.WriteLine($"Connect Error {ex.ToString()}");
            return false;
        }
    }

    public void Disconnect()
    {
        IsConnected = false;

        if(Socket != null)
        {
            Socket.Shutdown(SocketShutdown.Both);
            Socket.Close();
            Socket = null;
        }
    }

    void NetworkProcess()
    {
        while(IsConnected == true 
            && Socket != null)
        {
            DispatchSend();

            DispatchRecv();

            MakePacket();
        }
    }

    void DispatchSend()
    {
        try
        {
            if(Socket.Poll(0, SelectMode.SelectWrite))
            {
                byte[] packet;
                if(SendQueue.TryDequeue(out packet) == true)
                {
                    Socket.Send(packet);
                }
            }
        }
        catch(Exception ex)
        {
            Debug.LogError($"DispatchSend Error Reason : {ex.Message}");
        }
    }

    void DispatchRecv()
    {
        try
        {
            byte[] packets = new byte[MTUSize];

            while (Socket.Poll(0, SelectMode.SelectRead))
            {
                var recvSize = Socket.Receive(packets);
                if(recvSize == 0)
                {
                    // TODO : 연결끊김 처리
                    Disconnect();
                    break;
                }
                else
                {
                    var recvPacket = new byte[recvSize];
                    Buffer.BlockCopy(packets, 0, recvPacket, 0, recvSize);
                    RecvQueue.Enqueue(recvPacket);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"DispatchRecv Error Reason : {ex.Message}");
        }
    }

    void MakePacket()
    {
        byte[] recvData;
        var headerSize = PacketDef.PacketHeader.PacketHeaderSize;

        while (RecvQueue.TryDequeue(out recvData) == true)
        {
            PacketBufferManager.Write(recvData, 0, recvData.Length);

            var packet = PacketBufferManager.Read();
            if(packet.Count < 1)
            {
                break;
            }

            var packetData = new PacketDef.PacketData();

            packetData.PacketHeader.PacketSize = (UInt16)(packet.Count - headerSize);
            packetData.PacketHeader.PacketID = BitConverter.ToUInt16(packet.Array, packet.Offset + 2);
            packetData.PacketHeader.PacketType = packet.Array[4];
            packetData.PacketBody = new byte[packetData.PacketHeader.PacketSize];
            Buffer.BlockCopy(packet.Array, packet.Offset + headerSize, packetData.PacketBody, 0, packet.Count - headerSize);

            PacketQueue.Enqueue(packetData);
            //var needPacketSize = BitConverter.ToUInt16(recvData, 0);

            //PacketDef.PacketData newPacketData = new PacketDef.PacketData();

            //newPacketData.PacketHeader.PacketSize = needPacketSize;
            //newPacketData.PacketHeader.PacketID = BitConverter.ToUInt16(recvData, 2);
            //newPacketData.PacketHeader.PacketType = recvData[4];

            //newPacketData.PacketBody = new byte[needPacketSize - headerSize];
            //Buffer.BlockCopy(recvData, headerSize, newPacketData.PacketBody, 5, recvData.Length - headerSize);

            //needPacketSize -= (UInt16)recvData.Length;

            //while(needPacketSize != 0)
            //{
            //    if(RecvQueue.TryDequeue(out recvData) == true)
            //    {

            //    }
            //}

            //PacketQueue.Enqueue(newPacketData);
        }
    }

    public bool GetPacket(out PacketDef.PacketData packetData)
    {
        return PacketQueue.TryDequeue(out packetData);
    }

    public void Send(byte[] packet)
    {
        SendQueue.Enqueue(packet);
    }
}
