using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Demo2_AsyncStreams
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var results = GetFilteredDataResults();

            await foreach (var data in results)
            {
                Console.WriteLine($"Recieved filtered data {data}");
            }

            Console.WriteLine("done");
        }

        private static async IAsyncEnumerable<int> GetFilteredDataResults()
        {
            await foreach (var data in GetData())
            {
                if (data > 700)
                    yield return data;
            }
        }
        
        static async IAsyncEnumerable<int> GetData(CancellationToken cancellationToken = default)
        {
            //while (true)
            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(new Random().Next(0, 1000), cancellationToken);

                var dataValue = new Random().Next(0, 1000);
                Console.WriteLine($"Getting data: {dataValue}");

                yield return dataValue;
            }
        }
    }
}
