# SerializerBenchmark
``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i5-6500T CPU 2.50GHz, ProcessorCount=4
Frequency=2437502 Hz, Resolution=410.2561 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1586.0
  DefaultJob : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1586.0


```
 |                                Method |            Mean |        StdDev | Output |  Gen 0 | Allocated |
 |-------------------------------------- |---------------- |-------------- |------- |------- |---------- |
 |              BinaryFormatterSerialize |  45,207.7954 ns |   474.6527 ns |  1616b | 3.0111 |  18.23 kB |
 |            BinaryFormatterDeserialize |  45,028.6926 ns |   346.8463 ns |      - | 4.0527 |  21.23 kB |
 |                         BondSerialize |   1,652.4125 ns |    15.8630 ns | 65536b |      - |      72 B |
 |                       BondDeserialize |   2,174.1734 ns |    17.3254 ns |      - | 0.6811 |   2.44 kB |
 |      DataConstractSerializerSerialize |  43,583.8569 ns |   385.6592 ns |  1204b |      - |   8.69 kB |
 |    DataConstractSerializerDeserialize |  33,829.9068 ns |   299.4621 ns |      - | 4.2725 |  18.35 kB |
 |   DataContractJsonSerializerSerialize |  54,028.1040 ns |   508.8275 ns |   726b |      - |   5.78 kB |
 | DataContractJsonSerializerDeserialize |  60,718.3830 ns |   462.8886 ns |      - | 2.3275 |  16.63 kB |
 |                   FlatBufferSerialize |     117.3787 ns |     0.9957 ns |   776b | 0.2731 |     880 B |
 |                 FlatBufferDeserialize |      22.8099 ns |     0.1330 ns |      - |      - |       0 B |
 |         JavaScriptSerializerSerialize | 282,309.9981 ns | 1,490.9076 ns |   741b | 7.9427 |   57.8 kB |
 |       JavaScriptSerializerDeserialize | 303,142.3528 ns | 1,299.6925 ns |      - | 8.4635 |  57.59 kB |
 |                  MessagePackSerialize |   6,351.2785 ns |   150.1400 ns |   578b | 0.8260 |    3.7 kB |
 |                MessagePackDeserialize |  16,815.4326 ns |    85.3982 ns |      - | 2.6123 |   10.5 kB |
 |               ProtobufGoogleSerialize |   1,524.8400 ns |    69.1671 ns |   609b | 1.6749 |   5.56 kB |
 |             ProtobufGoogleDeserialize |   3,266.2304 ns |    34.9460 ns |      - | 1.6439 |    5.8 kB |
 |                  ProtoBufNetSerialize |   2,774.7282 ns |    19.7106 ns |   604b | 0.3011 |   1.56 kB |
 |                ProtobufNetDeserialize |   5,167.9271 ns |    23.9829 ns |      - | 0.1444 |   1.67 kB |
 |                    SalarBoisSerialize |   6,757.4680 ns |    50.7804 ns |   349b | 1.8087 |   6.82 kB |
 |                  SalarBoisDeserialize |  11,195.6222 ns |    83.4732 ns |      - | 1.6683 |   7.35 kB |
 |                XmlSerializerSerialize |  58,324.8854 ns |   512.1586 ns |  2042b | 2.2135 |  15.97 kB |
 |              XmlSerializerDeserialize |  52,527.8348 ns |   300.9458 ns |      - | 2.4577 |  16.75 kB |
