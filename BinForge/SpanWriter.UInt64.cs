using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteUInt64BigEndian(ulong value)
    {
        const int size = sizeof(ulong);
        BinaryPrimitives.WriteUInt64BigEndian(Span.Slice(Position, size), value);
        Position += size;
    }

    public void WriteUInt64LittleEndian(ulong value)
    {
        const int size = sizeof(ulong);
        BinaryPrimitives.WriteUInt64LittleEndian(Span.Slice(Position, size), value);
        Position += size;
    }
}
