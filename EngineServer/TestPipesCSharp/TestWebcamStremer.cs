using System.IO;
using TestPipesCSharp.Properties;

namespace TestPipesCSharp
{
    public class TestWebcamStremer: IPCBase
    {
        public byte[] ImageBytes;
        
        public void ReadImageBytes(string path="/home/owais/Downloads/servers/unity/RenderedRead.raw")
        //public void ReadImageBytes(string path="/home/owais/unity/RenderedRead.raw")
        {
            FileInfo fileInfo = new FileInfo(path);
            ImageBytes = new byte[fileInfo.Length];
            using (var fs = fileInfo.OpenRead())
            {
                fs.Read(ImageBytes, 0, ImageBytes.Length);
            }
        }

        public byte[] GetImageBinaryPacket(int clientId = 1)
        {
            return GetBinMsg(ImageBytes, BinType.Video, clientId);
        }
    }
}