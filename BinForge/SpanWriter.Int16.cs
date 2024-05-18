using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteInt16BigEndian(short value)
    {
        const int size = sizeof(short);
        BinaryPrimitives.WriteInt16BigEndian(Span.Slice(Position, size), value);
        Position += size;
    }

    public void WriteInt16LittleEndian(short value)
    {
        const int size = sizeof(short);
        BinaryPrimitives.WriteInt16LittleEndian(Span.Slice(Position, size), value);
        Position += size;
    }
}
