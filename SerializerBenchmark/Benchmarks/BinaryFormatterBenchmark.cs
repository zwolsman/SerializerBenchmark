using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializerBenchmark.Benchmarks
{
    public class BinaryFormatterBenchmark : AbstractBenchmark<ChainObject>
    {
        public override string Name { get; set; }

        private IFormatter formatter;
        public override void Setup()
        {
            obj = ChainObject.Serializable;

            formatter = new BinaryFormatter();
            formatter.Serialize(internalStream, obj);
        }

        public override byte[] Serialize()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public override ChainObject Deserialize()
        {
            internalStream.Seek(0, SeekOrigin.Begin);

            return (ChainObject) formatter.Deserialize(internalStream);
        }
    }
}
