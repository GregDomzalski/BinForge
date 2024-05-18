using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public ushort ReadUInt16BigEndian()
    {
        const int size = sizeof(ushort);
        ushort temp = BinaryPrimitives.ReadUInt16BigEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }

    public ushort ReadUInt16LittleEndian()
    {
        const int size = sizeof(ushort);
        ushort temp = BinaryPrimitives.ReadUInt16LittleEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }
}
