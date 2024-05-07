using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteInt64BigEndian(Span<byte> buffer, long value)
    {
        const int size = sizeof(long);
        BinaryPrimitives.WriteInt64BigEndian(buffer.Slice(Position, size), value);
        Position += size;
    }

    public void WriteInt64LittleEndian(Span<byte> buffer, long value)
    {
        const int size = sizeof(long);
        BinaryPrimitives.WriteInt64LittleEndian(buffer.Slice(Position, size), value);
        Position += size;
    }
}
