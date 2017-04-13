using System.IO;
using BenchmarkDotNet.Attributes;

namespace SerializerBenchmark
{
    public abstract class AbstractBenchmark<T>
    {
        public abstract string Name { get; set; }

        protected T obj;

        protected MemoryStream internalStream = new MemoryStream();
        [Setup]
        public abstract void Setup();

        [Benchmark]
        public abstract byte[] Serialize();

        [Benchmark]
        public abstract T Deserialize();
    }
}
