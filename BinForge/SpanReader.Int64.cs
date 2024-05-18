using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public long ReadInt64BigEndian()
    {
        const int size = sizeof(long);
        long temp = BinaryPrimitives.ReadInt64BigEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }

    public long ReadInt64LittleEndian()
    {
        const int size = sizeof(long);
        long temp = BinaryPrimitives.ReadInt64LittleEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }
}
