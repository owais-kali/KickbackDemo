using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestPipesCSharp
{
    public class EchoWebcam
    {
        private List<PrimaryUser> PrimaryUsers = new List<PrimaryUser>();

        public void Test()
        {
            TestRPC.RPCJsonObject response = new TestRPC.RPCJsonObject();
            response.name = TestRPC.RPCJsonObject.PacketTypeEnum.response.ToString();
            response.data = "";
            response.error = "";
            response.tag = 1.ToString();

            var responseJson =JsonConvert.SerializeObject(response);

            Console.WriteLine(responseJson);
        }
        
        public void Read()
        {
            
        }

        void HandleRPC()
        {
            
        }
    }
}