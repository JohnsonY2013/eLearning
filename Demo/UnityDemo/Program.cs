using System;
using Unity;

namespace UnityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Unity.IUnityContainer container = new Unity.UnityContainer();
            ContainerMagic.RegisterElements(container);

            var battery = container.Resolve<IBattery>();
            Console.WriteLine($"Battery object: SerialNumber - {battery.SerialNumber()}");

            var tuner = container.Resolve<ITuner>();
            Console.WriteLine($"Tuner object: SerialNumber - {tuner.SerialNumber()}");

            var dial = container.Resolve<Dial>();
            Console.WriteLine($"Dial object: DialType - {dial.DialType()}");

            var radio = container.Resolve<IRadio>(new Unity.Resolution.ParameterOverride("radioBattery", battery),
                new Unity.Resolution.ParameterOverride("radioTuner", tuner),
                new Unity.Resolution.ParameterOverride("radioName", "RocketRadio"));
            radio.Start();

            var cheapSpeaker = container.Resolve<ISpeaker>("Cheap");
            var priceySpeaker = container.Resolve<ISpeaker>("Expensive");
            cheapSpeaker.Start();
            priceySpeaker.Start();

            Console.ReadLine();
        }
    }
}
