using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityDemo
{
    class Tuner : ITuner
    {
        public string Manufacturer()
        {
            return "Tesla";
        }

        public bool SelfCheck()
        {
            return true;
        }

        public string SerialNumber()
        {
            return "00009999";
        }

        public int TunedFrequency()
        {
            return (int)99.8;
        }
    }
}
