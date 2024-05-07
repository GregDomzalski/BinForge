using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteUInt128BigEndian(UInt128 value)
    {
        const int size = 16;
        BinaryPrimitives.WriteUInt128BigEndian(Span.Slice(Position, size), value);
        Position += size;
    }

    public void WriteUInt128LittleEndian(UInt128 value)
    {
        const int size = 16;
        BinaryPrimitives.WriteUInt128LittleEndian(Span.Slice(Position, size), value);
        Position += size;
    }
}
