// automatically generated by the FlatBuffers compiler, do not modify

using FlatBuffers;

public struct C1Fbs : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static C1Fbs GetRootAsC1Fbs(ByteBuffer _bb) { return GetRootAsC1Fbs(_bb, new C1Fbs()); }
  public static C1Fbs GetRootAsC1Fbs(ByteBuffer _bb, C1Fbs obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public C1Fbs __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public double X { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetDouble(o + __p.bb_pos) : (double)0.0; } }
  public double Y { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetDouble(o + __p.bb_pos) : (double)0.0; } }

  public static Offset<C1Fbs> CreateC1Fbs(FlatBufferBuilder builder,
      double x = 0.0,
      double y = 0.0) {
    builder.StartObject(2);
    C1Fbs.AddY(builder, y);
    C1Fbs.AddX(builder, x);
    return C1Fbs.EndC1Fbs(builder);
  }

  public static void StartC1Fbs(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddX(FlatBufferBuilder builder, double x) { builder.AddDouble(0, x, 0.0); }
  public static void AddY(FlatBufferBuilder builder, double y) { builder.AddDouble(1, y, 0.0); }
  public static Offset<C1Fbs> EndC1Fbs(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<C1Fbs>(o);
  }
};

