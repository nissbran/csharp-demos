using System;
using Demo3_PatternMatching.Model;

namespace Demo3_PatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Car 500 kg, price: {GetTollCharge(new Car(500))}");
            Console.WriteLine($"Car 1500 kg, price: {GetTollCharge(new Car(1500))}");
            Console.WriteLine($"Motorcycle 500 kg, price: {GetTollCharge(new Motorcycle(500))}");
            Console.WriteLine($"Truck EnvironmentFriendly, price: {GetTollCharge(new Truck(true))}");
            Console.WriteLine($"Truck Not EnvironmentFriendly, price: {GetTollCharge(new Truck(false))}");
            Console.WriteLine($"Bicycle (Default), price: {GetTollCharge(new Bicycle(20))}");

            Console.ReadLine();
        }

        private static decimal GetTollCharge(Vehicle vehicle)
        {
            switch (vehicle)
            {
                case Car car when car.Weight < 1000:
                    return 50;
                case Car car when car.Weight >= 1000:
                    return 100;
                case Motorcycle _: // Discard 
                    return 30;
                case Truck truck when truck.IsEnviromentFriendly:
                    return 100;
                case Truck truck when !truck.IsEnviromentFriendly:
                    return 200;
                case null:
                    throw new NullReferenceException();
                default:
                    return 0;
            }
        }
    }
}