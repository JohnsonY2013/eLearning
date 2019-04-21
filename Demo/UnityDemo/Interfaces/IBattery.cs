namespace UnityDemo
{
    interface IBattery
    {
        bool SelfCheck();
        int ChargeRemaining();
        string Manufacturer();
        string SerialNumber();
    }
}
