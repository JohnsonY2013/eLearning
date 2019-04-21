using System;

namespace UnityDemo
{
    class CheapSpeaker : ISpeaker
    {
        public void Start()
        {
            Console.WriteLine("Sounds cheap");
        }
    }
}
