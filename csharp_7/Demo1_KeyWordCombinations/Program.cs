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
            //var id2 = new StackOnlyId(Guid.NewGuid());
            
            
            // Value tuples
            var result = MyMethod(id);
            Console.WriteLine($"Value tuple return {result.Item1.Id}, {result.Item2}");

            var (newId, id2) = MyMethod(id);
            Console.WriteLine($"Value tuple return {newId.Id}, {id2}");

            
            // In parameter
            var count = 5;
            var newcount = MyCountMethod(count);
            
            
            // Ref
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

        // ref returns
        private static ref int RefReturns()
        {
            int[] ints = new int[4] {1, 2, 3, 4};
            return ref ints[2];
        }

        private static void TestRef(ref Vehicle vehicle)
        {
                
        }
    }
}