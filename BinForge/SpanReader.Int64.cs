using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public long ReadInt64BigEndian(ReadOnlySpan<byte> data)
    {
        const int size = sizeof(long);
        long temp = BinaryPrimitives.ReadInt64BigEndian(data.Slice(Position, size));
        Position += size;
        return temp;
    }

    public long ReadInt64LittleEndian(ReadOnlySpan<byte> data)
    {
        const int size = sizeof(long);
        long temp = BinaryPrimitives.ReadInt64LittleEndian(data.Slice(Position, size));
        Position += size;
        return temp;
    }
}
