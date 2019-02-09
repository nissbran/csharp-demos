using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Demo2_SpanMemory
{
    public class MyMemoryHolder
    {
        public MyMemoryHolder(Memory<byte> memory)
        {
            Memory = memory;
        }

        public Memory<byte> Memory { get; }

        public void Slice()
        {
            var span = Memory.Span.Slice(sizeof(char) * 165, sizeof(char) * 54);

            var test = Encoding.UTF8.GetString(span);
            Console.WriteLine(test);
        }
    }
}