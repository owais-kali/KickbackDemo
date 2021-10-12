using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using TestPipesCSharp.Properties;

namespace TestPipesCSharp
{
    public class Pipes
    {
        private string ToEnginePath =
            "/home/owais/KickBack/Main/KickBack-SSR-DOTS/UnitySource/Build/Pipe_ToEngine";

        private string FromEnginePath =
            "/home/owais/KickBack/Main/KickBack-SSR-DOTS/UnitySource/Build/Pipe_FromEngine";

        /*private FileStream ToEngineFS;
        private FileStream FromEngineFS;*/
        public IntPtr ToEngineFS, FromEngineFS;


        public bool IsPipesServerStarted = false;

        public Pipes()
        {
        }

        public Pipes(string toEnginePath, string fromEnginePath)
        {
            ToEnginePath = toEnginePath;
            FromEnginePath = fromEnginePath;
        }

        public void Hello(IntPtr num1)
        {
            NamedPipeCPPLib.hello(num1);
        }

        public void DeleteAllPipes()
        {
            try
            {
                //Delete To Engine
                ProcessStartInfo BashProcess = new ProcessStartInfo()
                {
                    FileName = "/bin/rm", Arguments = ToEnginePath,
                    UseShellExecute = false,
                };
                Process proc = new Process() {StartInfo = BashProcess,};
                proc.Start();

                //Delete From Engine
                BashProcess = new ProcessStartInfo()
                {
                    FileName = "/bin/rm", Arguments = FromEnginePath,
                    UseShellExecute = false,
                };
                proc = new Process() {StartInfo = BashProcess,};
                proc.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void CreateAllPipes()
        {
            //Create ToEngine File
            var BashProcess = new ProcessStartInfo()
            {
                FileName = "/usr/bin/mkfifo", Arguments = ToEnginePath,
                UseShellExecute = false,
            };
            var proc = new Process() {StartInfo = BashProcess,};
            proc.Start();

            //Create FromEngine File
            BashProcess = new ProcessStartInfo()
            {
                FileName = "/usr/bin/mkfifo", Arguments = FromEnginePath,
                UseShellExecute = false,
            };
            proc = new Process() {StartInfo = BashProcess,};
            proc.Start();
        }

        public void ReCreatePipes()
        {
            DeleteAllPipes();
            CreateAllPipes();
        }

        public void StartPipeServer()
        {
            if (IsPipesServerStarted)
            {
                Console.WriteLine("PipeServer is Already Running!");
                return;
            }

            //ToEngineFS = File.OpenWrite(ToEnginePath);
            ToEngineFS = Marshal.AllocHGlobal(4);
            FromEngineFS = Marshal.AllocHGlobal(4);
            ;

            NamedPipeCPPLib.PipeOpen(new StringBuilder(ToEnginePath), 'W', ToEngineFS);
            Console.WriteLine("Opened ToEngine Pipe");

            //FromEngineFS = File.OpenRead(FromEnginePath);
            NamedPipeCPPLib.PipeOpen(new StringBuilder(FromEnginePath), 'R', FromEngineFS);
            Console.WriteLine("Opened FromEngine Pipe");

            IsPipesServerStarted = true;
        }

        //SendBytes
        public void SendAllBytes(byte[] buff, int offset, int count)
        {
            if (count == 0)
            {
                Console.WriteLine("Abort SendBytes: Sending Zero Byte is not allowed");
                return;
            }

            try
            {
                //ToEngineFS.Write(buff,offset, count);
                IntPtr buffPtr = Marshal.AllocHGlobal(count);
                Marshal.Copy(buff, offset, buffPtr, count);
                NamedPipeCPPLib.PipeWriteAll(ToEngineFS, buffPtr, count);
                Marshal.FreeHGlobal(buffPtr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        //ReadBytes

        public byte[] ReadAllBytes()
        {
            //Read msgLength
            IntPtr readLenPtr = Marshal.AllocHGlobal(4);
            NamedPipeCPPLib.PipeReadAll(FromEngineFS, readLenPtr, 4);
            int readLen = Marshal.ReadInt32(readLenPtr) + 1;
            byte[] aswddw = new byte[4];
            Marshal.Copy(readLenPtr,aswddw,0,4);
            Console.WriteLine("ReadAllBytes size(binary): ");
            IPCBase.PrintBytes(aswddw);
            Marshal.FreeHGlobal(readLenPtr);

            //Read MsgBuff
            IntPtr readMsgPtr = Marshal.AllocHGlobal(readLen);
            NamedPipeCPPLib.PipeReadAll(FromEngineFS, readMsgPtr, readLen);
            byte[] readMsg = new byte[readLen];
            Marshal.Copy(readMsgPtr, readMsg, 0, readLen);
            Marshal.FreeHGlobal(readMsgPtr);
            return readMsg;
        }

        public bool ReadAllBytes(IntPtr readMsgPtr, int readMaxSize, out int readLen)
        {
            IntPtr readLenPtr = Marshal.AllocHGlobal(4);
            NamedPipeCPPLib.PipeReadAll(FromEngineFS, readLenPtr, 4);
            readLen = Marshal.ReadInt32(readLenPtr) + 1;
            Marshal.FreeHGlobal(readLenPtr);

            if (readLen > readMaxSize) return false;
            NamedPipeCPPLib.PipeReadAll(FromEngineFS, readMsgPtr, readLen);

            return true;
        }
        
        public byte ReadByte()
        {
            IntPtr readLenPtr = Marshal.AllocHGlobal(1);
            NamedPipeCPPLib.PipeReadAll(FromEngineFS, readLenPtr, 1);
            byte outByte = Marshal.ReadByte(readLenPtr);
            Marshal.FreeHGlobal(readLenPtr);

            return outByte;
        }
        public byte[] ReadBytes(int size)
        {
            IntPtr readLenPtr = Marshal.AllocHGlobal(size);
            NamedPipeCPPLib.PipeReadAll(FromEngineFS, readLenPtr, size);
            byte[] outByte = new byte[size];
            Marshal.Copy(readLenPtr,outByte,0,size);
            Marshal.FreeHGlobal(readLenPtr);

            return outByte;
        }
        
        //Close Pipes
        public void CloseAllPipes(bool deleteFiles = true)
        {
            /*ToEngineFS.Close();
            FromEngineFS.Close();*/

            NamedPipeCPPLib.PipeClose(ToEngineFS);
            NamedPipeCPPLib.PipeClose(FromEngineFS);

            if (deleteFiles) DeleteAllPipes();
        }
    }
}