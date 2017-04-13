using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ProtoBuf;

namespace SerializerBenchmark
{
    [Bond.Schema]
    [ProtoContract]
    [Serializable]
    [DataContract]
    public class ChainObject
    {
        public static ChainObject Serializable = new ChainObject()
        {
            ChainId = "51681684-7DCC-4114-A4B9-0CA88A4D36C4",
            AttributeTypeId = 1,
            Value = 10,
            Coordinates = new List<C1>(new[]
            {
                new C1(96419, 411075),
                new C1(96412, 411065),
                new C1(96394, 411029),
                new C1(96382, 410988),
                new C1(96377, 410956),
                new C1(96377, 410908),
                new C1(96383, 410870),
                new C1(96403, 410791),
                new C1(96430, 410593),
                new C1(96441, 410555),
                new C1(96456, 410522),
                new C1(96548, 410398),
                new C1(96577, 410368),
                new C1(96611, 410351),
                new C1(96634, 410341),
                new C1(96666, 410334),
                new C1(96696, 410331),
                new C1(96723, 410334),
                new C1(96760, 410340),
                new C1(96902, 410381),
                new C1(96942, 410384),
                new C1(96977, 410382),
                new C1(97014, 410375),
                new C1(97041, 410365),
                new C1(97067, 410351),
                new C1(97092, 410336),
                new C1(97123, 410311),
                new C1(97166, 410257),
            })
        };

        [Bond.Id(1)]
        [ProtoMember(1)]
        [DataMember(Name = "atid")]
        public int AttributeTypeId { get; set; }

        [Bond.Id(2)]
        [ProtoMember(2)]
        [DataMember(Name = "cid")]
        public string ChainId { get; set; }

        [Bond.Id(3)]
        [ProtoMember(3)]
        [DataMember(Name = "value")]
        public decimal Value { get; set; }

        [Bond.Id(4)]
        [ProtoMember(4)]
        [DataMember(Name = "coordinates")]
        public List<C1> Coordinates { get; set; }
    }

    [Bond.Schema]
    [ProtoContract]
    [Serializable]
    [DataContract]
    public class C1
    {
        [Bond.Id(1)]
        [ProtoMember(1)]
        [DataMember(Name = "x")]
        public double X { get; set; }

        [Bond.Id(2)]
        [ProtoMember(2)]
        [DataMember(Name = "y")]
        public double Y { get; set; }

        public C1()
        {
        }

        public C1(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "{" + $"{X} {Y}" + "}";
        }
    }
}