namespace UnityDemo
{
    interface ITuner
    {
        string Manufacturer();
        int TunedFrequency();
        bool SelfCheck();
        string SerialNumber();
    }
}
