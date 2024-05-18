using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public Half ReadHalfBigEndian()
    {
        const int size = 2;
        Half temp = BinaryPrimitives.ReadHalfBigEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }

    public Half ReadHalfLittleEndian()
    {
        const int size = 2;
        Half temp = BinaryPrimitives.ReadHalfLittleEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }
}
