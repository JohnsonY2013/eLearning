namespace UnityDemo
{
    class Battery : IBattery
    {
        public int ChargeRemaining()
        {
            return 70;
        }

        public string Manufacturer()
        {
            return "Sony";
        }

        public bool SelfCheck()
        {
            return true;
        }

        public string SerialNumber()
        {
            return "ABC123XXX";
        }
    }
}
