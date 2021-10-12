using System;
using System.Runtime.InteropServices;
using System.Text;

namespace TestPipesCSharp
{
    public class NamedPipeCPPLib
    {
        private const string
            LIBRARY_NAME = 
                //"/media/owais/Kickback/KickBack/Main/KickBack-SSR-DOTS/UnitySource/Assets/Plugins/Linux/libNamedPipe3.so";
                "/home/owais/Downloads/servers/unity/libNamedPipe3.so";

        /*[DllImport(LIBRARY_NAME)]
    public static extern void test5(IntPtr val1);*/

        [DllImport(LIBRARY_NAME)]
        public static extern void PipeOpen(StringBuilder path, char RWOpt, IntPtr PipePtr);

        [DllImport(LIBRARY_NAME)]
        public static extern void PipeClose(IntPtr PipePtr);

        [DllImport(LIBRARY_NAME)]
        public static extern int PipeReadChar(IntPtr Pipe, IntPtr ReadBuf, int size);

        [DllImport(LIBRARY_NAME)]
        public static extern void PipeReadAll(IntPtr Pipe, IntPtr ReadBuf, int size);

        [DllImport(LIBRARY_NAME)]
        public static extern void PipeWriteAll(IntPtr Pipe, IntPtr WriteBuf, int size);
    
        [DllImport(LIBRARY_NAME)]
        public static extern void hello(IntPtr val1);
    }
}