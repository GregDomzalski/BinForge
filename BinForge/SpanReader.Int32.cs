using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public int ReadInt32BigEndian()
    {
        const int size = sizeof(int);
        int temp = BinaryPrimitives.ReadInt32BigEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }

    public int ReadInt32LittleEndian()
    {
        const int size = sizeof(int);
        int temp = BinaryPrimitives.ReadInt32LittleEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }
}
