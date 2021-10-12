using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace TestPipesCSharp.WsServer.Users.Packets
{
    public unsafe struct VideoStreamPacket
    {
        public const TextureFormat Format = TextureFormat.RGBA32;
        public int Width;
        public int Height;
        public int VideoSize;

        public uint TotalNoOfFramesSinceStartup;
        public int MaxNoOfFrames;

        /// <summary>
        /// Video Binary Size + Timestamp size 
        /// </summary>
        public int VideoPacketSize;

        public IntPtr VideoBuffer;
        public int CurrentBufferIndex, LastVideoBufferIndex;

        public uint TimeStamp;
        public bool IsVideoUpdated;
        public bool IsVideoBufferAllocated;

        public VideoStreamPacket(int width, int height, IntPtr videoBuffer, int maxNoOfFrames = 1,
            TextureFormat format = Format)
        {
            Width = width;
            Height = height;
            MaxNoOfFrames = maxNoOfFrames;
            LastVideoBufferIndex = 0;
            if (format == TextureFormat.RGB24)
            {
                VideoSize = Width * Height * 3;
            }
            else
            {
                VideoSize = Width * Height * 4;
            }

            VideoBuffer = videoBuffer;
            CurrentBufferIndex = 0;
            VideoPacketSize = 1;
            IsVideoBufferAllocated = false;
            IsVideoUpdated = false;
            TotalNoOfFramesSinceStartup = 0;

            TimeStamp = 0;
        }

        public int GetVideoPacketIndex(VideoStreamPacket* videoStreamPacket, int start, int offset)
        {
            return ((start + offset) % videoStreamPacket->MaxNoOfFrames);
        }

        public int GetNextVideoPacketIndex(VideoStreamPacket* videoStreamPacket)
        {
            int NextIndex = (videoStreamPacket->CurrentBufferIndex + 1);
            if (NextIndex >= videoStreamPacket->MaxNoOfFrames) return 0;
            return NextIndex;
        }

        public VideoPacket GetVideoPacket(VideoStreamPacket* videoStreamPacket, int index)
        {
            if (index > videoStreamPacket->MaxNoOfFrames)
            {
                throw new Exception();
            }

            byte* videoPacketPtr =
                &((byte*) videoStreamPacket->VideoBuffer)[index * videoStreamPacket->VideoPacketSize];
            uint timeStamp = (uint) Marshal.ReadInt32((IntPtr) videoPacketPtr);
            byte* videoBinPtr = &videoPacketPtr[4];

            VideoPacket videoPacket = new VideoPacket(timeStamp, (IntPtr) videoBinPtr);
            return videoPacket;
        }

        public VideoPacket* GetVideoPacketPtr(VideoStreamPacket* videoStreamPacket, int index)
        {
            byte* VideoBufferPtr = (byte*) videoStreamPacket->VideoBuffer;
            VideoBufferPtr = &VideoBufferPtr[index * videoStreamPacket->VideoPacketSize];
            return (VideoPacket*) VideoBufferPtr;
        }

        public VideoStreamPacket* AllocateMem(bool allocateVideoBuff = true)
        {
            IntPtr intPtr = Marshal.AllocHGlobal(sizeof(VideoStreamPacket));
            VideoStreamPacket* ptr = (VideoStreamPacket*) intPtr;

            #region Initialize Variables

            ptr->Width = Width;
            ptr->Height = Height;
            ptr->VideoSize = VideoSize;
            ptr->TimeStamp = TimeStamp;
            ptr->MaxNoOfFrames = MaxNoOfFrames;
            ptr->LastVideoBufferIndex = LastVideoBufferIndex;

            #endregion


            if (allocateVideoBuff)
            {
                ptr->VideoBuffer = Marshal.AllocHGlobal(VideoSize);
                ptr->IsVideoBufferAllocated = true;
            }
            else
            {
                ptr->IsVideoBufferAllocated = false;
            }

            ptr->IsVideoUpdated = IsVideoUpdated;

            return ptr;
        }

        public void Dispose(VideoStreamPacket* videoStreamPacketPtr)
        {
            if (videoStreamPacketPtr->IsVideoBufferAllocated)
            {
                Marshal.FreeHGlobal(videoStreamPacketPtr->VideoBuffer);
            }

            Marshal.FreeHGlobal((IntPtr) videoStreamPacketPtr);
        }
    }

    public struct VideoPacket
    {
        public uint TimeStamp;
        public IntPtr VideoBin;

        public VideoPacket(uint timeStamp, IntPtr videoBin)
        {
            TimeStamp = timeStamp;
            VideoBin = videoBin;
        }
    }
}