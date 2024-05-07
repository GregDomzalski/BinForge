using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public short ReadInt16BigEndian(ReadOnlySpan<byte> data)
    {
        const int size = sizeof(short);
        short temp = BinaryPrimitives.ReadInt16BigEndian(data.Slice(Position, size));
        Position += size;
        return temp;
    }

    public short ReadInt16LittleEndian(ReadOnlySpan<byte> data)
    {
        const int size = sizeof(short);
        short temp = BinaryPrimitives.ReadInt16LittleEndian(data.Slice(Position, size));
        Position += size;
        return temp;
    }
}
