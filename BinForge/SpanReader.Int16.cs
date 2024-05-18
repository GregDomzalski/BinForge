using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public short ReadInt16BigEndian()
    {
        const int size = sizeof(short);
        short temp = BinaryPrimitives.ReadInt16BigEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }

    public short ReadInt16LittleEndian()
    {
        const int size = sizeof(short);
        short temp = BinaryPrimitives.ReadInt16LittleEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }
}
