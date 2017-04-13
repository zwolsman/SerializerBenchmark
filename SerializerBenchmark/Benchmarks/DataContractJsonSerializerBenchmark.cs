using System.IO;
using System.Runtime.Serialization.Json;

namespace SerializerBenchmark.Benchmarks
{
    public class DataContractJsonSerializerBenchmark : AbstractBenchmark<ChainObject>
    {

        public override string Name { get; set; } = "DataContactJsonSerializer";

        private DataContractJsonSerializer serializer;
        public override void Setup()
        {
            obj = ChainObject.Serializable;
            serializer = new DataContractJsonSerializer(obj.GetType());
            serializer.WriteObject(internalStream, obj);
        }

        public override byte[] Serialize()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                return ms.ToArray();
            }
        }

        public override ChainObject Deserialize()
        {
            internalStream.Seek(0, SeekOrigin.Begin);
            return (ChainObject)serializer.ReadObject(internalStream);
        }
    }
}
