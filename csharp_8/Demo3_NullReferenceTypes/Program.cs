using Demo3_NullReferenceTypes.Services;
using System;
using Demo3_NullReferenceTypes.Model;

namespace Demo3_NullReferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string? test = null;
            var calulator = new TollCalculator();

            calulator.Calculate(new Car(500));

            Console.WriteLine($"Test {test}");

            Console.WriteLine("Hello World!");
        }

    }
    
}
