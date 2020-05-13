using System;
using System.ComponentModel;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using UnityContainerDemo.Interfaces;
using UnityContainerDemo.Manufacturers;
using UnityContainerDemo.ManufacturersKeys;

namespace UnityContainerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //IUnityContainer container = new UnityContainer();

            ////With extra string
            //container.RegisterType<ICar, BMW>();
            //container.RegisterType<ICar, Audi>("LuxuryCar");

            //container.RegisterType<Driver>("LuxuryCarDriver", new InjectionConstructor(container.Resolve<ICar>("LuxuryCar")));

            //var driver1 = container.Resolve<Driver>();
            //driver1.RunCar();

            //var driver2 = container.Resolve<Driver>("LuxuryCarDriver");
            //driver2.RunCar();



            ////Instance
            //ICar audi = new Audi();
            //container.RegisterInstance<ICar>(audi);

            //var driver1 = container.Resolve<Driver>();
            //driver1.RunCar();
            //driver1.RunCar();

            //var driver2 = container.Resolve<Driver>();
            //driver2.RunCar();



            ////Multiple parameters
            //container.RegisterType<ICar, Audi>();
            //container.RegisterType<ICarKey, AudiKey>();

            //var driver = container.Resolve<Driver>();
            //driver.RunCar();



            ////Multiple constuctors
            //container.RegisterType<ICar, Ford>();
            //container.RegisterType<Driver>(new InjectionConstructor(container.Resolve<ICar>()));



            ////Primitive Parameters
            //container.RegisterType<Driver>(new InjectionConstructor(new object[] { new Audi(), "Steve" }));
            //var driver = container.Resolve<Driver>();
            //driver.RunCar();



            ////TransientLifeTimeManager
            //var container = new UnityContainer().RegisterType<ICar, BMW>(new TransientLifetimeManager());
            //var driver1 = container.Resolve<Driver>();
            //driver1.RunCar();
            //var driver2 = container.Resolve<Driver>();
            //driver2.RunCar();



            ////ContainerControlledLifeTimeManager
            //var container = new UnityContainer().RegisterType<ICar, BMW>(new ContainerControlledLifetimeManager());
            //var driver1 = container.Resolve<Driver>();
            //driver1.RunCar();
            //var driver2 = container.Resolve<Driver>();
            //driver2.RunCar();

            //HierachicalLifetimeManager
            var container = new UnityContainer().RegisterType<ICar, BMW>(new HierarchicalLifetimeManager());
            var childContainer = container.CreateChildContainer();
            var driver1 = container.Resolve<Driver>();
            driver1.RunCar();
            var driver2 = container.Resolve<Driver>();
            driver2.RunCar();
            var driver3 = childContainer.Resolve<Driver>();
            driver3.RunCar();
            var driver4 = childContainer.Resolve<Driver>();
            driver4.RunCar();





        }
    }
}
