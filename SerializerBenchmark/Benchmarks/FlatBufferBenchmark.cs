using System.IO;
using FlatBuffers;

namespace SerializerBenchmark.Benchmarks
{
    public class FlatBufferBenchmark : AbstractBenchmark<FlatBufferBuilder>
    {
        public override string Name { get; set; } = "Flat Buffers";
        public override void Setup()
        {
            obj = new FlatBufferBuilder(1);
            ChainObjectFbs.StartCoordinatesVector(obj, ChainObject.Serializable.Coordinates.Count);
            foreach (C1 coord in ChainObject.Serializable.Coordinates)
            {
                C1Fbs.CreateC1Fbs(obj, coord.X, coord.Y);
            }
            var coordsOffset = obj.EndVector();
            
            StringOffset chainIdOffset = obj.CreateString("51681684-7DCC-4114-A4B9-0CA88A4D36C4");

            ChainObjectFbs.StartChainObjectFbs(obj);
            ChainObjectFbs.AddChainId(obj, chainIdOffset);
            ChainObjectFbs.AddAttributeTypeid(obj, 1);

            ChainObjectFbs.AddValue(obj, 10);
            ChainObjectFbs.AddCoordinates(obj, coordsOffset);
            var end = ChainObjectFbs.EndChainObjectFbs(obj);
            ChainObjectFbs.FinishChainObjectFbsBuffer(obj, end);
            
        }
        public override byte[] Serialize()
        {
            using (MemoryStream ms = new MemoryStream(obj.DataBuffer.Data, obj.DataBuffer.Position, obj.Offset))
            {
                return ms.ToArray();
            }
        }

        public override FlatBufferBuilder Deserialize()
        {
            var temp = ChainObjectFbs.GetRootAsChainObjectFbs(obj.DataBuffer);
            return null;
        }
    }
}
