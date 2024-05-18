using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteUInt16BigEndian(ushort value)
    {
        const int size = sizeof(ushort);
        BinaryPrimitives.WriteUInt16BigEndian(Span.Slice(Position, size), value);
        Position += size;
    }

    public void WriteUInt16LittleEndian(ushort value)
    {
        const int size = sizeof(ushort);
        BinaryPrimitives.WriteUInt16LittleEndian(Span.Slice(Position, size), value);
        Position += size;
    }
}
