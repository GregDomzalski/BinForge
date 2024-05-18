using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteInt64BigEndian(long value)
    {
        const int size = sizeof(long);
        BinaryPrimitives.WriteInt64BigEndian(Span.Slice(Position, size), value);
        Position += size;
    }

    public void WriteInt64LittleEndian(long value)
    {
        const int size = sizeof(long);
        BinaryPrimitives.WriteInt64LittleEndian(Span.Slice(Position, size), value);
        Position += size;
    }
}
