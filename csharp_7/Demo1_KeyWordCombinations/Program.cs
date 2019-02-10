using System;
using System.Threading.Tasks;
using Demo1_KeyWordCombinations.Model;

namespace Demo1_KeyWordCombinations
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var id = new ReadOnlyId(Guid.NewGuid());
            // var id2 = new StackOnlyId(Guid.NewGuid());
            var result = MyMethod(id);
            
            Console.WriteLine($"Value tuple return {result.Item1.Id}, {result.Item2}");

            var (newId, id2) = MyMethod(id);
            Console.WriteLine($"Value tuple return {newId.Id}, {id2}");

            var count = 5;
            var newcount = MyCountMethod(count);
            
            var car = new Car(12, true);
            //TestRef(ref car);
        }

        // Value tuple return
        private static (ReadOnlyId, Guid) MyMethod(ReadOnlyId id)
        {
            var id2 = new StackOnlyId(Guid.NewGuid());
            return (id, id2.Id);
        }

        // 'in' keyword stops modification
        private static int MyCountMethod(in int count)
        {
            //count = 1;
            return count * 2;
        }

        private static ref Vehicle RefReturns()
        {
            var vehicles = new Vehicle[] { new Car(12, true)};
            return ref vehicles[0];
        }

        private static void TestEnum<T>(T inenum) where T : Enum
        {
            
        }

        private static void TestRef(ref Vehicle vehicle)
        {
                
        }
    }
}