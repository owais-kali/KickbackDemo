#define Server //Local

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TestPipesCSharp.Properties;
using static TestPipesCSharp.TestInputs.InputPacket.InputObject.Info;

namespace TestPipesCSharp
{
    internal class Program
    {
        public static readonly string RootPath = // Directory.GetCurrentDirectory()+"/";
            // "/media/owais/Kickback/KickBack/Main/KickBack-SSR-DOTS/TestPipesCSharp/TestUnityBuild/TestDemoHDRP/";
            //"/home/owais/KickBack/Builds/TestInputs/";
            "/home/owais/Downloads/servers/unity/";

        public unsafe static void Main(string[] args)
        {
            #region MyRegion

#if Local
Console.WriteLine("Local");
#elif Server
            Console.WriteLine("Server");
#endif


            //RootPath = Directory.GetCurrentDirectory();

            Pipes pipes =
                new Pipes(
                    /*RootPath + "Pipe_ToEngine",
                    RootPath + "Pipe_FromEngine");*/
                    RootPath + "Pipe_FromEngine",
                    RootPath + "Pipe_ToEngine");

            #region Sample Packets

            TestInputs testInputs = new TestInputs();
            byte[] MoveUpKeyBytes = testInputs.MoveUp();
            byte[] MoveUpKeyBytesClient2 = testInputs.MoveUp(2);

            IPCBase.PrintBytes(MoveUpKeyBytesClient2, false);

            TestWebcamStremer testWebcamStremer = new TestWebcamStremer();
            testWebcamStremer.ReadImageBytes();
            byte[] imageBinaryPacket = testWebcamStremer.GetImageBinaryPacket();
            byte[] imageBinaryPacket2 = testWebcamStremer.GetImageBinaryPacket(2);
            Console.WriteLine("ImageBytes Size: " + imageBinaryPacket.Length);

            int msgSize = BitConverter.ToInt32(imageBinaryPacket, 0);
            Console.WriteLine("msgSize: " + msgSize);

            #endregion

            #region RPC

            TestRPC testRpc = new TestRPC();
            TestRPC.AddPrimary addPrimary = new TestRPC.AddPrimary()
            {
                name = TestRPC.AddPrimary.Name,
                data = new TestRPC.AddPrimary.Data()
                {
                    ClientID = 1,
                    RenderWidth = 1280,
                    RenderHeight = 720,
                    WebCamWidth = 1280,
                    WebCamHeight = 720,
                    MaxFPS = 30
                },
                tag = 1,
                error = "y"
            };
            byte[] AddPrimaryBytes = testRpc.GetAddPrimaryPacketBytes(addPrimary);

            TestRPC.AddPrimary addPrimary2 = new TestRPC.AddPrimary()
            {
                name = TestRPC.AddPrimary.Name,
                data = new TestRPC.AddPrimary.Data()
                {
                    ClientID = 2,
                    RenderWidth = 1280,
                    RenderHeight = 720,
                    WebCamWidth = 1280,
                    WebCamHeight = 720,
                    MaxFPS = 60
                },
                tag = 2,
                error = ""
            };
            //byte[] AddPrimary2Bytes = testRpc.GetAddPrimaryPacketBytes(addPrimary2);

            TestRPC.AddPrimary addPrimary3 = new TestRPC.AddPrimary()
            {
                name = TestRPC.AddPrimary.Name,
                data = new TestRPC.AddPrimary.Data()
                {
                    ClientID = 3,
                    RenderWidth = 1280,
                    RenderHeight = 720,
                    WebCamWidth = 1280,
                    WebCamHeight = 720,
                    MaxFPS = 60
                },
                tag = 3,
                error = ""
            };

            TestRPC.RPCJsonObject response = new TestRPC.RPCJsonObject();
            response.name = TestRPC.RPCJsonObject.PacketTypeEnum.response.ToString();
            response.data = "";
            response.error = "";
            response.tag = 1.ToString();

            var responseJson = JsonConvert.SerializeObject(response);
            byte[] responseJsonBytes = Encoding.UTF8.GetBytes(responseJson);
            IPCBase ipcBase = new IPCBase();
            byte[] RPCResponseBytes = ipcBase.GetRPCMsg(responseJsonBytes);
            IPCBase.PrintBytes(RPCResponseBytes);
            byte[] RPCResponseBytes2 = new byte[RPCResponseBytes.Length-5];
            Array.Copy(RPCResponseBytes,5,RPCResponseBytes2,0,RPCResponseBytes2.Length);
            Console.WriteLine("RPC response: "+Encoding.UTF8.GetString(RPCResponseBytes2));
            #endregion

            Console.WriteLine(RootPath);

            #region PipeServer

            //pipes.ReCreatePipes();
            pipes.StartPipeServer();
            Console.WriteLine("Pipes Opened");
            /*Thread readThread = new Thread(Read);
            Thread writeThread = new Thread(Write);*/

            //readThread.Start();
            //writeThread.Start();

            #endregion

            #endregion

            void DumpReadBytes(IntPtr Pipe,int noOfBytes)
            {
                unsafe
                {
                    IntPtr Temp = Marshal.AllocHGlobal(noOfBytes);
                    NamedPipeCPPLib.PipeReadAll(Pipe, Temp, noOfBytes);
                    Marshal.FreeHGlobal(Temp);
                }
            }

            void Read()
            {
                try
                {
                    bool Client1WriteToFileComplete = false;
                    bool Client2WriteToFileComplete = false;

                    uint Client1LastTimeStamp = 0;
                    uint Client2LastTimeStamp = 0;

                    int renderAfter = 10;
                    while (true)
                    {
                        byte[] ReadByte = pipes.ReadAllBytes();
                        Console.WriteLine("ReadByte length: " + ReadByte.Length);

                        if (ReadByte.Length > 0)
                        {
                            if (ReadByte[0] == 1)
                            {
                                byte[] RPCBytes = new byte[ReadByte.Length - 1];
                                Array.Copy(ReadByte, 1, RPCBytes, 0, RPCBytes.Length);
                                Console.WriteLine("Got RPC Response");
                                string RPCJsonString = Encoding.UTF8.GetString(RPCBytes);
                                Console.WriteLine(RPCJsonString);
                            }
                        }

                        if (ReadByte[0] == 0)
                        {
                            //Read Client ID
                            byte[] ClientIDBytes = new byte[8];
                            Array.Copy(ReadByte, 1, ClientIDBytes, 0, ClientIDBytes.Length);
                            ulong ClientID = BitConverter.ToUInt64(ClientIDBytes, 0);

                            //Read Video Timestamp
                            byte[] TimeStampBytes = new byte[4];
                            Array.Copy(ReadByte, 10, TimeStampBytes, 0, TimeStampBytes.Length);

                            for (int i = 0; i < TimeStampBytes.Length / 2; i++)
                            {
                                (TimeStampBytes[TimeStampBytes.Length - i - 1], TimeStampBytes[i]) = (TimeStampBytes[i],
                                    TimeStampBytes[TimeStampBytes.Length - i - 1]);
                            }

                            uint TimeStamp = BitConverter.ToUInt32(TimeStampBytes, 0);
                            Console.WriteLine("ClientID: " + ClientID + " TimeStamp: " + TimeStamp);

                            if (renderAfter < 0)
                            {
                                byte[] imgBytes = new byte[ReadByte.Length - 14];
                                Array.Copy(ReadByte, 14, imgBytes, 0, imgBytes.Length);

                                if (ClientID == 1)
                                {
                                    if (!Client1WriteToFileComplete)
                                    {
                                        exportimage(imgBytes, imageFs);
                                        Client1WriteToFileComplete = true;
                                    }

                                    uint fps = 1000 / (TimeStamp - Client1LastTimeStamp);

                                    Console.WriteLine("ClientID: " + ClientID + " FPS: " + fps);

                                    Client1LastTimeStamp = TimeStamp;
                                }
                                else if (ClientID == 2)
                                {
                                    if (!Client2WriteToFileComplete)
                                    {
                                        exportimage(imgBytes, image2Fs);
                                        Client2WriteToFileComplete = true;
                                    }

                                    uint FPS = 1000 / (TimeStamp - Client2LastTimeStamp);

                                    Console.WriteLine("ClientID: " + ClientID + " FPS: " + FPS);

                                    Client2LastTimeStamp = TimeStamp;
                                }
                            }

                            renderAfter--;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            void Write()
            {
                try
                {
                    int WriteNoOfTimes = 200;
                    pipes.SendAllBytes(AddPrimaryBytes, 0, AddPrimaryBytes.Length);
                    //pipes.SendAllBytes(AddPrimary2Bytes, 0, AddPrimary2Bytes.Length);
                    //pipes.SendAllBytes(AddPrimary3Bytes, 0, AddPrimary3Bytes.Length);
                    while (true)
                    {
                        //Webcam image
                        pipes.SendAllBytes(imageBinaryPacket, 0, imageBinaryPacket.Length);
                        //pipes.SendAllBytes(imageBinaryPacket2, 0, imageBinaryPacket2.Length);
                        //Console.WriteLine("Write Complete");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        static FileStream DebugLogFS = File.Open(
            RootPath + "DebugLog.txt",
            FileMode.OpenOrCreate);

        public static void DebugLog(string str)
        {
            byte[] writebytes = Encoding.ASCII.GetBytes("hellow world");
            DebugLogFS.Write(writebytes, 0, writebytes.Length);
        }

        public static void DebugLog(byte[] str)
        {
            byte[] writebytes = Encoding.ASCII.GetBytes(Convert.ToBase64String(str));
            DebugLogFS.Write(writebytes, 0, writebytes.Length);
        }

        static FileStream imageFs = File.Open(
            RootPath + "Rendered.raw",
            FileMode.OpenOrCreate);

        static FileStream image2Fs = File.Open(
            RootPath + "Rendered2.raw",
            FileMode.OpenOrCreate);

        public static void exportimage(byte[] bin, FileStream fs)
        {
            fs.Write(bin, 0, bin.Length);
        }
    }
}