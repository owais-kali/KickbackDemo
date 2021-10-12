using System;
using System.Text;
using Newtonsoft.Json;

namespace TestPipesCSharp.Properties
{
    public class IPCBase
    {
        public enum MsgType{Bin = 0, Rpc = 1}
        public enum BinType{Video=0, Audio=1, Input=2 }
        
        public byte[] GetIpcMsg(int msgLen, MsgType msgType)
        {
            byte[] returnMsg = new byte[5];

            //Add MsgLen to ReturnMsg
            Array.Copy(BitConverter.GetBytes((uint)msgLen), 0, returnMsg,0, 4);
            
            //Add MsgType
            returnMsg[4] = (byte)msgType;

            return returnMsg;
        }

        public byte[] GetBinMsg(byte[] msg, BinType binType, long cLientId)
        {
            byte[] clientIDBytes = BitConverter.GetBytes(cLientId);
            byte binTypeByte = (byte) binType;

            byte[] returnArray = new byte[14+msg.Length];

            int msgLen = msg.Length + 9; // Plus 9 for clientID and Binary data type
            
            //Add IPC Msg
            Array.Copy(GetIpcMsg(msgLen,MsgType.Bin),0,returnArray,0,5);
            
            //Add Client ID
            Array.Copy(clientIDBytes,0,returnArray,5,8);
            
            //Add Bin Type
            returnArray[13] = binTypeByte;

            //Add msg
            Array.Copy(msg,0,returnArray,14,msg.Length);
            return returnArray;
        }

        public byte[] GetRPCMsg(byte[] msg)
        {
            byte[] IPCBytes = GetIpcMsg(msg.Length,MsgType.Rpc);
            byte[] OutRPCPacket = new byte[msg.Length + IPCBytes.Length];
            
            int offset = 0;
            Array.Copy(IPCBytes,0,OutRPCPacket,offset,IPCBytes.Length);
            offset += IPCBytes.Length;
            Array.Copy(msg,0,OutRPCPacket,offset,msg.Length);
            
            return OutRPCPacket;
        }

        public static byte[] RemoveBytesFromStart(byte[] bytes,int offset)
        {
            byte[] OutBytes = new byte[bytes.Length - offset];
            Array.Copy(bytes,offset,OutBytes,0,OutBytes.Length);
            return OutBytes;
        }
        
        public static void PrintBytes(byte[] bytes, int PrintSize ,bool InBinary = false)
        {
            string ByteString = "";
            if (InBinary)
            {
                for (int i = 0; i < PrintSize; i++)
                {
                    ByteString += ByteToString(bytes[i]) + " ";
                }
            }
            else
            {
                for (int i = 0; i < PrintSize; i++)
                {
                    ByteString += bytes[i] + ", ";
                }
            }
            Console.WriteLine(ByteString);
        }

        public static void PrintBytes(byte[] bytes, bool InBinary = false)
        {
            PrintBytes(bytes, bytes.Length, InBinary);
        }


        public static string ByteToString(byte b)
        {
            string byteString = "";

            for (int i = 0; i < 8; i++)
            {
                byte bit = (byte)Math.Pow(2, 7-i);
                if ((b & bit)==bit)
                {
                    byteString += 1;
                }
                else
                {
                    byteString += 0;
                }
            }

            return byteString;
        }
        
        public void Test()
        {
            MsgType msgType1 = MsgType.Bin;
            MsgType msgType2 = MsgType.Rpc;
            Console.WriteLine("Bin: "+(byte)msgType1);
            Console.WriteLine("RPC: "+(byte)msgType2);
        }
    }
}