using System.IO;
using BenchmarkDotNet.Attributes;
using ProtoBuf;

namespace SerializerBenchmark
{
    public class ProtobufnetBenchmark : AbstractBenchmark<ChainObject>
    {
       
        public override string Name { get; set; } = "Protobuf-net";

        [Setup]
        public override void Setup()
        {
            obj = ChainObject.Serializable;

            Serializer.Serialize(internalStream, obj);
        }

        [Benchmark]
        public override byte[] Serialize()
        {

            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        [Benchmark]
        public override ChainObject Deserialize()
        {
            internalStream.Seek(0, SeekOrigin.Begin);

            return Serializer.Deserialize<ChainObject>(internalStream);
        }
    }
}
