using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteInt128BigEndian(Int128 value)
    {
        const int size = 16;
        BinaryPrimitives.WriteInt128BigEndian(Span.Slice(Position, size), value);
        Position += size;
    }

    public void WriteInt128LittleEndian(Int128 value)
    {
        const int size = 16;
        BinaryPrimitives.WriteInt128LittleEndian(Span.Slice(Position, size), value);
        Position += size;
    }
}
