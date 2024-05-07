using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public int ReadInt32BigEndian(ReadOnlySpan<byte> data)
    {
        const int size = sizeof(int);
        int temp = BinaryPrimitives.ReadInt32BigEndian(data.Slice(Position, size));
        Position += size;
        return temp;
    }

    public int ReadInt32LittleEndian(ReadOnlySpan<byte> data)
    {
        const int size = sizeof(int);
        int temp = BinaryPrimitives.ReadInt32LittleEndian(data.Slice(Position, size));
        Position += size;
        return temp;
    }
}
