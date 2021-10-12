#define Server //Local

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace TestPipesCSharp
{
    internal class Program
    {
        public static readonly string RootPath = "/home/owais/Downloads/servers/unity/";

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
                    RootPath + "Pipe_ToEngine",
                    RootPath + "Pipe_FromEngine");

            #region PipeServer

            //pipes.ReCreatePipes();
            pipes.StartPipeServer();
            Console.WriteLine("Pipes Opened");

            #endregion

            #endregion
        }
    }
}