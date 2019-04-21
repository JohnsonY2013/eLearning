namespace UnityDemo
{
    class Dial
    {
        public string TypeofDial { get; set; }
        public Dial(string typeofDial)
        {
            TypeofDial = typeofDial;
        }
        public string DialType()
        {
            return TypeofDial;
        }
    }
}
