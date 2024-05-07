using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public Half ReadHalfBigEndian(ReadOnlySpan<byte> data)
    {
        const int size = 2;
        Half temp = BinaryPrimitives.ReadHalfBigEndian(data.Slice(Position, size));
        Position += size;
        return temp;
    }

    public Half ReadHalfLittleEndian(ReadOnlySpan<byte> data)
    {
        const int size = 2;
        Half temp = BinaryPrimitives.ReadHalfLittleEndian(data.Slice(Position, size));
        Position += size;
        return temp;
    }
}
