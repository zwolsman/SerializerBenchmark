using System.IO;
using MsgPack.Serialization;

namespace SerializerBenchmark.Benchmarks
{
    public class MessagePackBenchmark : AbstractBenchmark<ChainObject>
    {
        public override string Name { get; set; } = "Message Pack";

        private MessagePackSerializer serializer;
        public override void Setup()
        {
            serializer = MessagePackSerializer.Get<ChainObject>();
            obj = ChainObject.Serializable;

            serializer.Pack(internalStream, obj);
        }

        public override byte[] Serialize()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Pack(ms, obj);
                return ms.ToArray();
            }
        }

        public override ChainObject Deserialize()
        {
            internalStream.Seek(0, SeekOrigin.Begin);
            return (ChainObject)serializer.Unpack(internalStream);
        }
    }
}
