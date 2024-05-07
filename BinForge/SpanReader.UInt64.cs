using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public ulong ReadUInt64BigEndian()
    {
        const int size = sizeof(ulong);
        ulong temp = BinaryPrimitives.ReadUInt64BigEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }

    public ulong ReadUInt64LittleEndian()
    {
        const int size = sizeof(ulong);
        ulong temp = BinaryPrimitives.ReadUInt64LittleEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }
}
