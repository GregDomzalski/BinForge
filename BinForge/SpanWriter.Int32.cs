using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteInt32BigEndian(int value)
    {
        const int size = sizeof(int);
        BinaryPrimitives.WriteInt32BigEndian(Span.Slice(Position, size), value);
        Position += size;
    }

    public void WriteInt32LittleEndian(int value)
    {
        const int size = sizeof(int);
        BinaryPrimitives.WriteInt32LittleEndian(Span.Slice(Position, size), value);
        Position += size;
    }
}
