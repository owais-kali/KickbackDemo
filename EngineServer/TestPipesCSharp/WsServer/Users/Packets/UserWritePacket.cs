using System;
using System.Runtime.InteropServices;

namespace TestPipesCSharp.WsServer.Users.Packets
{
    public unsafe struct UserWritePacket
    {
        public ulong ClientID;
        public VideoStreamPacket* VideoStreamPacketPtr;

        public UserWritePacket* AllocateMem(ulong clientId,VideoStreamPacket videoStreamPacket)
        {
            UserWritePacket* userWritePacketPtr = (UserWritePacket*)Marshal.AllocHGlobal(sizeof(UserWritePacket));
            userWritePacketPtr->ClientID = clientId;
            userWritePacketPtr->VideoStreamPacketPtr = videoStreamPacket.AllocateMem(false);
            return userWritePacketPtr;
        }

        public void Dispose(UserWritePacket* userWritePacketPtr)
        {
            userWritePacketPtr->VideoStreamPacketPtr->Dispose(userWritePacketPtr->VideoStreamPacketPtr);
            Marshal.FreeHGlobal((IntPtr)userWritePacketPtr);
        }
    }
}