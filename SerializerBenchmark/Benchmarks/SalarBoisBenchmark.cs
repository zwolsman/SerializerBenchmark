using System.IO;
using Salar.Bois;

namespace SerializerBenchmark
{
    public class SalarBoisBenchmark : AbstractBenchmark<ChainObject>
    {
        public override string Name { get; set; } = "Salar.BOIS";

        private BoisSerializer serializer;
        public override void Setup()
        {
            obj = ChainObject.Serializable;

            serializer = new BoisSerializer();
            serializer.Serialize(obj, internalStream);
        }

        public override byte[] Serialize()
        {

            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(obj, ms);
                return ms.ToArray();
            }
        }

        public override ChainObject Deserialize()
        {
            internalStream.Seek(0, SeekOrigin.Begin);

            return serializer.Deserialize<ChainObject>(internalStream);
        }
    }
}
