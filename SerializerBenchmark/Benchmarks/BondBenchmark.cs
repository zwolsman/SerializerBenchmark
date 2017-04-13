using System.Collections.Generic;
using Bond;
using Bond.IO.Unsafe;
using Bond.Protocols;

namespace SerializerBenchmark.Benchmarks
{
    public class BondBenchmark : AbstractBenchmark<ChainObjectBond>
    {
        public override string Name { get; set; } = "Microsoft Bond";

        private CompactBinaryWriter<OutputBuffer> writer;
        private OutputBuffer outputBuffer;
        private InputBuffer input;
        private CompactBinaryReader<InputBuffer> reader;

        public override void Setup()
        {
            outputBuffer = new OutputBuffer();
            writer = new CompactBinaryWriter<OutputBuffer>(outputBuffer);


            obj = new ChainObjectBond()
            {
                chainId = "51681684-7DCC-4114-A4B9-0CA88A4D36C4",
                attributeTypeId = 1,
                value = 10,
                coordinates = new LinkedList<C1Bond>(new[]
            {
                new C1Bond(){x = 96419, y = 411075},
                new C1Bond(){x = 96412, y = 411065},
                new C1Bond(){x = 96394, y = 411029},
                new C1Bond(){x = 96382, y = 410988},
                new C1Bond(){x = 96377, y = 410956},
                new C1Bond(){x = 96377, y = 410908},
                new C1Bond(){x = 96383, y = 410870},
                new C1Bond(){x = 96403, y = 410791},
                new C1Bond(){x = 96430, y = 410593},
                new C1Bond(){x = 96441, y = 410555},
                new C1Bond(){x = 96456, y = 410522},
                new C1Bond(){x = 96548, y = 410398},
                new C1Bond(){x = 96577, y = 410368},
                new C1Bond(){x = 96611, y = 410351},
                new C1Bond(){x = 96634, y = 410341},
                new C1Bond(){x = 96666, y = 410334},
                new C1Bond(){x = 96696, y = 410331},
                new C1Bond(){x = 96723, y = 410334},
                new C1Bond(){x = 96760, y = 410340},
                new C1Bond(){x = 96902, y = 410381},
                new C1Bond(){x = 96942, y = 410384},
                new C1Bond(){x = 96977, y = 410382},
                new C1Bond(){x = 97014, y = 410375},
                new C1Bond(){x = 97041, y = 410365},
                new C1Bond(){x = 97067, y = 410351},
                new C1Bond(){x = 97092, y = 410336},
                new C1Bond(){x = 97123, y = 410311},
                new C1Bond(){x = 97166, y = 410257},
            })
            };


            Bond.Serialize.To(writer, obj);
            input = new InputBuffer(outputBuffer.Data);
            reader = new CompactBinaryReader<InputBuffer>(input);
        }

        public override byte[] Serialize()
        {
            outputBuffer.Position = 0;
            Bond.Serialize.To(writer, obj);
            return outputBuffer.Data.Array;
        }

        public override ChainObjectBond Deserialize()
        {
            input.Position = 0;
            return Deserialize<ChainObjectBond>.From(reader);
        }
    }
}
