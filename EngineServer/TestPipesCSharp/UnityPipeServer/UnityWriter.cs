using System;

namespace TestPipesCSharp.UnityPipeServer
{
    public class UnityWriter
    {
        
        
        private IntPtr _fromEngineIntPtr;
        public UnityWriter(IntPtr fromEngineIntPtr)
        {
            _fromEngineIntPtr = fromEngineIntPtr;
        }
    }
}