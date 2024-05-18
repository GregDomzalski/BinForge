using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteUInt32BigEndian(uint value)
    {
        const int size = sizeof(uint);
        BinaryPrimitives.WriteUInt32BigEndian(Span.Slice(Position, size), value);
        Position += size;
    }

    public void WriteUInt32LittleEndian(uint value)
    {
        const int size = sizeof(uint);
        BinaryPrimitives.WriteUInt32LittleEndian(Span.Slice(Position, size), value);
        Position += size;
    }
}
