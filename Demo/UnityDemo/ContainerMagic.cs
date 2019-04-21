using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

namespace UnityDemo
{
    class ContainerMagic
    {
        public static void RegisterElements(IUnityContainer container)
        {
            var dial = new Dial("Linear");
            //We RegisterInstance this object. 
            //In other words, we tell Unity to return this object whenever the client asks for an object of type Dial.
            container.RegisterInstance(dial);

            //We RegisterType the IBattery with Battery. 
            //We are telling Unity to create and return an object of type Battery whenever the client asks for an object of type IBattery.
            container.RegisterType<IBattery, Battery>();
            container.RegisterType<ITuner, Tuner>();

            var batteryType = typeof(IBattery);
            var tunerType = typeof(ITuner);
            container.RegisterType<IRadio, Radio>(new InjectionConstructor(batteryType, tunerType, typeof(string)));

            container.RegisterType<ISpeaker, CheapSpeaker>("Cheap");
            container.RegisterType<ISpeaker, PriceySpeaker>("Expensive");
        }
    }
}
