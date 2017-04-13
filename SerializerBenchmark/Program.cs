using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using SerializerBenchmark.Benchmarks;

namespace SerializerBenchmark
{

    [Config(typeof(Config))]
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Program>();
        }

        private static DataContrsactSerializerPersonBenchmark dcsBenchmark = new DataContrsactSerializerPersonBenchmark();
        private static DataContractJsonSerializerBenchmark dcjsBenchmark = new DataContractJsonSerializerBenchmark();
        private static ProtobufnetBenchmark pbnBenchmark = new ProtobufnetBenchmark();
        private static ProtobufGoogleBenchmark pbgBenchmark = new ProtobufGoogleBenchmark();
        private static SalarBoisBenchmark sbBenchmark = new SalarBoisBenchmark();
        private static BinaryFormatterBenchmark bfBenchmark = new BinaryFormatterBenchmark();
        private static JavaScriptSerializerBenchmark jssBenchmark = new JavaScriptSerializerBenchmark();
        private static MessagePackBenchmark mpBenchmark = new MessagePackBenchmark();
        private static BondBenchmark bBenchmark = new BondBenchmark();
        private static FlatBufferBenchmark fbBenchmark = new FlatBufferBenchmark();
        private static XmlSerializerBenchmark xmlBenchmark = new XmlSerializerBenchmark();
        public class Config : ManualConfig
        {
            public Config()
            {
                Add(new TagColumn("Output", delegate(string method)
                {
                    switch (method)
                    {
                        case "DataConstractSerializerSerialize":
                            dcsBenchmark.Setup();
                            return dcsBenchmark.Serialize().Length + "b";
                        case "ProtoBufNetSerialize":
                            pbnBenchmark.Setup();
                            return pbnBenchmark.Serialize().Length + "b";
                        case "ProtobufGoogleSerialize":
                            pbgBenchmark.Setup();
                            return pbgBenchmark.Serialize().Length + "b";
                        case "SalarBoisSerialize":
                            sbBenchmark.Setup();
                            return sbBenchmark.Serialize().Length + "b";
                        case "BinaryFormatterSerialize":
                            bfBenchmark.Setup();
                            return bfBenchmark.Serialize().Length + "b";
                        case "JavaScriptSerializerSerialize":
                            jssBenchmark.Setup();
                            return jssBenchmark.Serialize().Length + "b";
                        case "MessagePackSerialize":
                            mpBenchmark.Setup();
                            return mpBenchmark.Serialize().Length + "b";
                        case "BondSerialize":
                            bBenchmark.Setup();
                            return bBenchmark.Serialize().Length + "b";
                        case "FlatBufferSerialize":
                            fbBenchmark.Setup();
                            return fbBenchmark.Serialize().Length + "b";
                        case "DataContractJsonSerializerSerialize":
                            dcjsBenchmark.Setup();
                            return dcjsBenchmark.Serialize().Length + "b";
                        case "XmlSerializerSerialize":
                            xmlBenchmark.Setup();
                            return xmlBenchmark.Serialize().Length + "b";
                        default:
                            return "-";
                    }
                }));

                Add(MemoryDiagnoser.Default);
            }
        }
        [Setup]
        public void Setup()
        {
            dcsBenchmark.Setup();
            pbnBenchmark.Setup();
            pbgBenchmark.Setup();
            sbBenchmark.Setup();
            bfBenchmark.Setup();
            jssBenchmark.Setup();
            bBenchmark.Setup();
            mpBenchmark.Setup();
            fbBenchmark.Setup();
            dcjsBenchmark.Setup();
            xmlBenchmark.Setup();
        }

        #region Binary Formatter


                [Benchmark]
                public byte[] BinaryFormatterSerialize()
                {
                    return bfBenchmark.Serialize();
                }

                [Benchmark]
                public object BinaryFormatterDeserialize()
                {
                    return bfBenchmark.Deserialize();
                }


        #endregion

        #region Microsoft Bond
        [Benchmark]
        public byte[] BondSerialize()
        {
            return bBenchmark.Serialize();
        }

        [Benchmark]
        public object BondDeserialize()
        {
            return bBenchmark.Deserialize();
        }
        #endregion
        
        #region DataContractSerializer

        [Benchmark]
        public byte[] DataConstractSerializerSerialize()
        {
            return dcsBenchmark.Serialize();
        }

        [Benchmark]
        public object DataConstractSerializerDeserialize()
        {
            return dcsBenchmark.Deserialize();
        }

        #endregion

        #region DataContractJsonSerializer

        [Benchmark]
        public byte[] DataContractJsonSerializerSerialize()
        {
            return dcjsBenchmark.Serialize();
        }

        [Benchmark]
        public object DataContractJsonSerializerDeserialize()
        {
            return dcjsBenchmark.Deserialize();
        }
        
        #endregion

        #region FlatBuffer 

        [Benchmark]
        public byte[] FlatBufferSerialize()
        {
            return fbBenchmark.Serialize();
        }

        [Benchmark]
        public object FlatBufferDeserialize()
        {
            return fbBenchmark.Deserialize();
        }
        #endregion

        #region JavaScript Serializer

        [Benchmark]
                public byte[] JavaScriptSerializerSerialize()
                {
                    return jssBenchmark.Serialize();
                }

                [Benchmark]
                public object JavaScriptSerializerDeserialize()
                {
                    return jssBenchmark.Deserialize();
                }

        #endregion

        #region MessagePack

        [Benchmark]
        public byte[] MessagePackSerialize()
        {
            return mpBenchmark.Serialize();
        }

        [Benchmark]
        public object MessagePackDeserialize()
        {
            return mpBenchmark.Deserialize();
        }
        
        #endregion

        #region Protobuf Google

        [Benchmark]
                public byte[] ProtobufGoogleSerialize()
                {
                    return pbgBenchmark.Serialize();
                }

                [Benchmark]
                public object ProtobufGoogleDeserialize()
                {
                    return pbgBenchmark.Deserialize();
                }

                #endregion

        #region Protobuf-net

        [Benchmark]
        public byte[] ProtoBufNetSerialize()
        {
            return pbnBenchmark.Serialize();
        }

        [Benchmark]
        public object ProtobufNetDeserialize()
        {
            return pbnBenchmark.Deserialize();
        }
        #endregion
        
        #region Salar.BOIS 

        [Benchmark]
        public byte[] SalarBoisSerialize()
        {
            return sbBenchmark.Serialize();
        }

        [Benchmark]
        public object SalarBoisDeserialize()
        {
            return sbBenchmark.Deserialize();
        }

        #endregion

        #region XML Serializer

        [Benchmark]
        public byte[] XmlSerializerSerialize()
        {
            return xmlBenchmark.Serialize();
        }

        [Benchmark]
        public object XmlSerializerDeserialize()
        {
            return xmlBenchmark.Deserialize();
        }

        #endregion
    }

    /* public class SerializerComparison
     {
         //Person objects
         private readonly Person person = new Person()
         {
             FirstName = "Marvin",
             LastName = "Zwolsman",
             Age = 21,
             Gender = Person.GenderEnum.Male
         };

         private readonly Person personEmpty = new Person();
         private readonly PersonProtoBuf personProto = new PersonProtoBuf()
         {
             FirstName = "Marvin",
             LastName = "Zwolsman",
             Age = 21,
             Gender = GenderType.Male
         };

         private readonly PersonProtoBuf personProtoEmpty = new PersonProtoBuf();
         private readonly FlatBufferBuilder personFlatbuffer = new FlatBufferBuilder(1);
         private readonly FlatBufferBuilder personFlatbufferEmpty = new FlatBufferBuilder(1);

         //.NET serializers
         private readonly BinaryFormatter _binaryFormatter = new BinaryFormatter();
         private readonly DataContractSerializer _dataContractSerializer = new DataContractSerializer(typeof(Person));
         private readonly JavaScriptSerializer _javaScriptSerializer = new JavaScriptSerializer();
         private readonly DataContractJsonSerializer _dataContractJsonSerializer = new DataContractJsonSerializer(typeof(Person));
         private readonly XmlSerializer _xmlSerializer = new XmlSerializer(typeof(Person));

         //Third party serializers
         private readonly MessagePackSerializer _messagePackSerializer = MessagePackSerializer.Get<Person>();
         private readonly BoisSerializer _boisSerializer = new BoisSerializer();

         [Setup]
         public void Setup()
         {

             StringOffset firstName = personFlatbuffer.CreateString("Marvin");
             StringOffset lastName = personFlatbuffer.CreateString("Zwolsman");
             PersonFlatbuffer.StartPerson(personFlatbuffer);
             PersonFlatbuffer.AddFirstName(personFlatbuffer, firstName);
             PersonFlatbuffer.AddLastName(personFlatbuffer, lastName);
             PersonFlatbuffer.AddAge(personFlatbuffer, 21);
             PersonFlatbuffer.AddGender(personFlatbuffer, GenderFlatbuffer.Male);
             var offset = PersonFlatbuffer.EndPerson(personFlatbuffer);
             PersonFlatbuffer.FinishPersonBuffer(personFlatbuffer, offset);

             PersonFlatbuffer.StartPerson(personFlatbufferEmpty);
             var offset2 = PersonFlatbuffer.EndPerson(personFlatbufferEmpty);
             PersonFlatbuffer.FinishPersonBuffer(personFlatbufferEmpty, offset2);

             personProto.Age = 10;

         }

         #region "Person"
         [Benchmark]
         public byte[] BinaryFormatterPerson()
         {
             using (MemoryStream ms = new MemoryStream())
             {
                 _binaryFormatter.Serialize(ms, person);
                 return ms.ToArray();
             }
         }

         [Benchmark]
         public byte[] DataContractSerializerPerson()
         {
             using (MemoryStream ms = new MemoryStream())
             {
                 _dataContractSerializer.WriteObject(ms, person);
                 return ms.ToArray();
             }
         }

         [Benchmark]
         public byte[] JavaScriptSerializerPerson()
         {
            byte[] result = Encoding.Default.GetBytes(_javaScriptSerializer.Serialize(person));
            return result;
         }

         [Benchmark]
         public byte[] DataContractJsonSerializerPerson()
         {
             using (MemoryStream ms = new MemoryStream())
             {
                 _dataContractJsonSerializer.WriteObject(ms, person);
                 return ms.ToArray();
             }
         }

         [Benchmark]
         public byte[] XmlSerializerPerson()
         {
             using (MemoryStream ms = new MemoryStream())
             {
                 _xmlSerializer.Serialize(ms, person);
                 return ms.ToArray();
             }
         }

         [Benchmark]
         public byte[] ProtobufNetPerson()
         {
             using (MemoryStream ms = new MemoryStream())
             {
                 Serializer.Serialize(ms, person);
                 return ms.ToArray();
             }
         }

         [Benchmark]
         public byte[] ProtoBufGooglePerson()
         {
             using (MemoryStream ms = new MemoryStream())
             {
                 personProto.WriteTo(ms);
                 return ms.ToArray();
             }
         }

         [Benchmark]
         public byte[] FlatbufferPerson()
         {
             using (MemoryStream ms = new MemoryStream(personFlatbuffer.DataBuffer.Data, personFlatbuffer.DataBuffer.Position, personFlatbuffer.Offset))
             {
                 return ms.ToArray();
             }
         }

         [Benchmark]
         public byte[] MsgPackPerson()
         {
             using (MemoryStream ms = new MemoryStream())
             {
                 _messagePackSerializer.Pack(ms, person);
                 return ms.ToArray();
             }
         }

         [Benchmark]
         public byte[] BoisPerson()
         {
             using (MemoryStream ms = new MemoryStream())
             {
                 _boisSerializer.Serialize(person, ms);
                 return ms.ToArray();
             }
         }
         #endregion

         #region "Empty Person"
         [Benchmark]
         public byte[] BinaryFormatterPersonEmpty()
         {
             using (MemoryStream ms = new MemoryStream())
             {
                 _binaryFormatter.Serialize(ms, personEmpty);
                 return ms.ToArray();
             }
         }

         [Benchmark]
         public byte[] DataContractSerializerPersonEmpty()
         {
             using (MemoryStream ms = new MemoryStream())
             {
                 _dataContractSerializer.WriteObject(ms, personEmpty);
                 return ms.ToArray();
             }
         }

         [Benchmark]
         public byte[] ProtobufNetPersonEmpty()
         {
             using (MemoryStream ms = new MemoryStream())
             {
                 Serializer.Serialize(ms, personEmpty);
                 return ms.ToArray();
             }
         }

         [Benchmark]
         public byte[] ProtoBufGooglePersonEmpty()
         {
             using (MemoryStream ms = new MemoryStream())
             {
                 personProtoEmpty.WriteTo(ms);
                 return ms.ToArray();
             }
         }

         [Benchmark]
         public byte[] FlatbufferPersonEmpty()
         {
             using (MemoryStream ms = new MemoryStream(personFlatbufferEmpty.DataBuffer.Data, personFlatbufferEmpty.DataBuffer.Position, personFlatbufferEmpty.Offset))
             {
                 return ms.ToArray();
             }
         }

         [Benchmark]
         public byte[] MsgPackPersonEmpty()
         {
             using (MemoryStream ms = new MemoryStream())
             {
                 _messagePackSerializer.Pack(ms, personEmpty);
                 return ms.ToArray();
             }
         }

         [Benchmark]
         public byte[] BoisPersonEmpty()
         {
             using (MemoryStream ms = new MemoryStream())
             {
                 _boisSerializer.Serialize(personEmpty, ms);
                 return ms.ToArray();
             }
         }

         [Benchmark]
         public byte[] JavaScriptSerializerPersonEmpty()
         {
             byte[] result = Encoding.Default.GetBytes(_javaScriptSerializer.Serialize(personEmpty));
             return result;
         }

         [Benchmark]
         public byte[] DataContractJsonSerializerPersonEmpty()
         {
             using (MemoryStream ms = new MemoryStream())
             {
                 _dataContractJsonSerializer.WriteObject(ms, personEmpty);
                 return ms.ToArray();
             }
         }

         [Benchmark]
         public byte[] XmlSerializerPersonEmpty()
         {
             using (MemoryStream ms = new MemoryStream())
             {
                 _xmlSerializer.Serialize(ms, personEmpty);
                 return ms.ToArray();
             }
         }

         #endregion

     }*/


/*    [Serializable]
    [DataContract]
    [ProtoContract]
    public class Person
    {
        [DataMember]
        [ProtoMember(1)]
        public string FirstName { get; set; }

        [DataMember]
        [ProtoMember(2)]
        public string LastName { get; set; }

        [DataMember]
        [ProtoMember(3)]
        public int Age { get; set; }

        [DataMember]
        [ProtoMember(4)]
        public GenderEnum Gender { get; set; } = GenderEnum.Unkown;


        [DataContract]
        [ProtoContract]
        public enum GenderEnum
        {
            [EnumMember]
            [ProtoEnum]
            Male,

            [EnumMember]
            [ProtoEnum]
            Female,

            [EnumMember]
            [ProtoEnum]
            Unkown
        }
    }*/
}
