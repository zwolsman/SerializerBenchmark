using System.Collections.Generic;
using System.IO;
using BenchmarkDotNet.Attributes;
using Google.Protobuf;

namespace SerializerBenchmark
{
    public class ProtobufGoogleBenchmark : AbstractBenchmark<ChainObjectProto>
    {
       
        public override string Name { get; set; } = "Protobuf.Google";

        public override void Setup()
        {
            obj = new ChainObjectProto
            {
                ChainId = "51681684-7DCC-4114-A4B9-0CA88A4D36C4",
                AttributeTypeid = 1,
                Value = 10
            };

            obj.Coordinates.Add(new List<C1Proto>(new[]
                {
                    new C1Proto() {X = 96419, Y = 411075},
                    new C1Proto() {X = 96412, Y = 411065},
                    new C1Proto() {X = 96394, Y = 411029},
                    new C1Proto() {X = 96382, Y = 410988},
                    new C1Proto() {X = 96377, Y = 410956},
                    new C1Proto() {X = 96377, Y = 410908},
                    new C1Proto() {X = 96383, Y = 410870},
                    new C1Proto() {X = 96403, Y = 410791},
                    new C1Proto() {X = 96430, Y = 410593},
                    new C1Proto() {X = 96441, Y = 410555},
                    new C1Proto() {X = 96456, Y = 410522},
                    new C1Proto() {X = 96548, Y = 410398},
                    new C1Proto() {X = 96577, Y = 410368},
                    new C1Proto() {X = 96611, Y = 410351},
                    new C1Proto() {X = 96634, Y = 410341},
                    new C1Proto() {X = 96666, Y = 410334},
                    new C1Proto() {X = 96696, Y = 410331},
                    new C1Proto() {X = 96723, Y = 410334},
                    new C1Proto() {X = 96760, Y = 410340},
                    new C1Proto() {X = 96902, Y = 410381},
                    new C1Proto() {X = 96942, Y = 410384},
                    new C1Proto() {X = 96977, Y = 410382},
                    new C1Proto() {X = 97014, Y = 410375},
                    new C1Proto() {X = 97041, Y = 410365},
                    new C1Proto() {X = 97067, Y = 410351},
                    new C1Proto() {X = 97092, Y = 410336},
                    new C1Proto() {X = 97123, Y = 410311},
                    new C1Proto() {X = 97166, Y = 410257},
                }));
       

        obj.WriteTo(internalStream);
        }

        [Benchmark]
        public override byte[] Serialize()
        {

            using (MemoryStream ms = new MemoryStream())
            {
                obj.WriteTo(ms);
                return ms.ToArray();
            }
        }

        [Benchmark]
        public override ChainObjectProto Deserialize()
        {
            internalStream.Seek(0, SeekOrigin.Begin);

            return ChainObjectProto.Parser.ParseFrom(internalStream);
        }
    }
}
