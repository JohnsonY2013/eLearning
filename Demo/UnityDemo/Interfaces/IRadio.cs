namespace UnityDemo
{
    interface IRadio
    {
        IBattery Battery { get; set; }
        ITuner Tuner { get; set; }
        string Name { get; set; }
        string RadioName();
        void Start();
    }
}
