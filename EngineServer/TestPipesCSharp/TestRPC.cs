using System;
using System.Reflection.Emit;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TestPipesCSharp.Properties;

namespace TestPipesCSharp
{
    public class TestRPC: IPCBase
    {
        public class RPCJsonObject
        {
            public enum PacketTypeEnum: byte
            {
                response,
                AddPrimary,
                RemovePrimary,
                AddSecondary,
                RemoveSecondary
            }
            
            public string name;
            public string data;
            public string tag;
            public string error;

            public byte[] ToByteArray()
            {
                byte[] jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this));
                return jsonBytes;
            }
        }
        
        #region AddPrimaryData
        public struct AddPrimary
        {
            public const string Name = "AddPrimary";
            public string name;
            public Data data;
            public byte tag;
            public string error;
            public struct Data
            {
                public ulong ClientID;
                public UInt16 RenderWidth;
                public UInt16 RenderHeight;
                public UInt16 WebCamWidth;
                public UInt16 WebCamHeight;
                public byte MaxFPS;
            }
            
            /// <summary>
            /// Primary Client Already exist
            /// </summary>
            public const string Error1 = "Primary Client Already exist";

            /// <summary>
            /// Secondary Client exist with same clientID
            /// </summary>
            public const string Error2 = "Secondary Client exist with same clientID";

            /// <summary>
            /// Invalid ClientID
            /// </summary>
            public const string Error3 = "Invalid ClientID";
        }

            

        #endregion

        public byte[] GetAddPrimaryPacketBytes(AddPrimary addPrimaryRPC)
        {
            string jsonStr = JsonConvert.SerializeObject(addPrimaryRPC);
            Console.WriteLine("jsonStr: "+jsonStr);
            return GetRPCMsg(Encoding.UTF8.GetBytes(jsonStr));
        }

        public T RPCPacketToRPCObject<T>(byte[] rpcPacketBytes)
        {
            byte[] rpcBytes = new byte[rpcPacketBytes.Length-5];
            Array.Copy(rpcPacketBytes,5,rpcBytes,0,rpcBytes.Length);
            string jsonStr = Encoding.UTF8.GetString(rpcBytes);
            return JsonConvert.DeserializeObject<T>(jsonStr);
        }

        #region Response

        #endregion
    }
}