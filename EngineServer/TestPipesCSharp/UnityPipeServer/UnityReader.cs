using System;

namespace TestPipesCSharp
{
    public class UnityReader
    {
        private IntPtr _toEngineIntPtr;
        
        public UnityReader(IntPtr toEngineIntPtr)
        {
            _toEngineIntPtr = toEngineIntPtr;
        }

        public void Update()
        {
            
        }
    }
}