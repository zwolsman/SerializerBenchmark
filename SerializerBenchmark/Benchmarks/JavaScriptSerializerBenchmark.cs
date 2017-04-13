using System.Text;
using System.Web.Script.Serialization;

namespace SerializerBenchmark.Benchmarks
{
    public class JavaScriptSerializerBenchmark : AbstractBenchmark<ChainObject>
    {
        public override string Name { get; set; } = "JavaScript Serializer";

        private JavaScriptSerializer serializer;
        public override void Setup()
        {
            obj = ChainObject.Serializable;
            serializer = new JavaScriptSerializer();

            byte[] result = Encoding.UTF8.GetBytes(serializer.Serialize(obj));
            internalStream.Write(result, 0 , result.Length);
        }

        public override byte[] Serialize()
        {
            return Encoding.UTF8.GetBytes(serializer.Serialize(obj));
        }

        public override ChainObject Deserialize()
        {
            string json = Encoding.UTF8.GetString(internalStream.ToArray());
            return serializer.Deserialize<ChainObject>(json);
        }
    }
}
