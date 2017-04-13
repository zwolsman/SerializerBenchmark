using System.IO;
using System.Xml.Serialization;

namespace SerializerBenchmark.Benchmarks
{
    public class XmlSerializerBenchmark : AbstractBenchmark<ChainObject>
    {
        public override string Name { get; set; } = "XmlSerializer";
        private XmlSerializer serializer;
        public override void Setup()
        {
            obj = ChainObject.Serializable;
            serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(internalStream, obj);
        }

        public override byte[] Serialize()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public override ChainObject Deserialize()
        {
            internalStream.Seek(0, SeekOrigin.Begin);
            return (ChainObject) serializer.Deserialize(internalStream);
        }
    }
}
