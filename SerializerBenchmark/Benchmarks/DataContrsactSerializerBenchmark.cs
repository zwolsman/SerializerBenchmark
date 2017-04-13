using System.IO;
using System.Runtime.Serialization;
using BenchmarkDotNet.Attributes;

namespace SerializerBenchmark
{
    public class DataContrsactSerializerPersonBenchmark : AbstractBenchmark<ChainObject>
    {
        public override string Name { get; set; } = "DataContractSerializer";


        private DataContractSerializer serializer;

        [Setup]
        public override void Setup()
        {
            obj = ChainObject.Serializable;

            serializer = new DataContractSerializer(obj.GetType());
            serializer.WriteObject(internalStream, obj);
        }

        [Benchmark]
        public override byte[] Serialize()
        {

            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                return ms.ToArray();
            }
        }

        [Benchmark]
        public override ChainObject Deserialize()
        {
            internalStream.Seek(0, SeekOrigin.Begin);

            return (ChainObject)serializer.ReadObject(internalStream);
        }
    }
}
