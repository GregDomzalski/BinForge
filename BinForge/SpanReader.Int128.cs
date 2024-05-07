using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public Int128 ReadInt128BigEndian(ReadOnlySpan<byte> data)
    {
        const int size = 16;
        Int128 temp = BinaryPrimitives.ReadInt128BigEndian(data.Slice(Position, size));
        Position += size;
        return temp;
    }

    public Int128 ReadInt128LittleEndian(ReadOnlySpan<byte> data)
    {
        const int size = 16;
        Int128 temp = BinaryPrimitives.ReadInt128LittleEndian(data.Slice(Position, size));
        Position += size;
        return temp;
    }
}
