using System;

namespace TestPipesCSharp
{
    public unsafe struct PrimaryUser
    {
        public ulong ClientID;
        public UInt16 RenderWidth, RenderHeight;
        public UInt16 WebCamWidth, WebCamHeight;
        public byte MaxFPS;

        public IntPtr WebCamIntPtr;
        public uint WebCamSize;
    }
}