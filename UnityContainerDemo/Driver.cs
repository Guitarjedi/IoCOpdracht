using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using UnityContainerDemo.Interfaces;

namespace UnityContainerDemo
{
    public class Driver
    {
        private ICar _car = null;
        private ICarKey _key = null;
        private string _name = string.Empty;

        [InjectionConstructor]
        public Driver(ICar car)
        {
            _car = car;
        }

        public Driver(ICar car, string name)
        {
            _car = car;
            _name = name;
        }
        public Driver(ICar car, ICarKey key)
        {
            _car = car;
            _key = key;
        }
        public void RunCar()
        {
            if (_key != null)
                Console.WriteLine("Running {0} with {1}- {2} mile ", _car.GetType().Name, _key.GetType().Name, _car.Run());
            else if(_name != string.Empty)
                Console.WriteLine("{0} is running {1} - {2} mile ",_name, _car.GetType().Name, _car.Run());
            else
                Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
        }
    }
}
