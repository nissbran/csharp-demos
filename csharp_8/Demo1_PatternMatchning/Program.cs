using System;
using Demo1_PatternMatching.Model;

namespace Demo1_PatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Car 500 kg, price: {GetTollCharge(new Car(500))}");
            Console.WriteLine($"Car 1500 kg, price: {GetTollCharge(new Car(1500))}");
            Console.WriteLine($"Motorcycle 500 kg, price: {GetTollCharge(new Motorcycle(500))}");
            Console.WriteLine($"Truck EnviromentFriendly, price: {GetTollCharge(new Truck(true))}");
            Console.WriteLine($"Truck Not EnviromentFriendly, price: {GetTollCharge(new Truck(false))}");
            Console.WriteLine($"Bicycle (Default), price: {GetTollCharge(new Bicycle(20))}");

            Console.WriteLine(new Bicycle(20).Description);
            Console.WriteLine(new Truck(true).Description);
            Console.WriteLine(new Truck(false).Description);

            Console.ReadLine();

            var car = new Car(800);

            car.ChangeRegistration(RegistrationAction.Activate);
            car.ChangeRegistration(RegistrationAction.Terminate);
            //car.ChangeRegistration(RegistrationAction.Activate);

            Console.ReadLine();
        }

        private static decimal GetTollCharge(Vehicle vehicle)
        {
            return vehicle switch
            {
                Car car when car.Weight < 1000 => 50,
                Car car when car.Weight >= 1000 => 100,
                Motorcycle _ => 30,
                Truck truck when truck.IsEnvironmentFriendly => 100,
                Truck truck when !truck.IsEnvironmentFriendly => 200,
                null => throw new NullReferenceException(),
                _ => 0
            };
        }
    }
}
