using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteHalfBigEndian(Half value)
    {
        const int size = 2;
        BinaryPrimitives.WriteHalfBigEndian(Span.Slice(Position, size), value);
        Position += size;
    }

    public void WriteHalfLittleEndian(Half value)
    {
        const int size = 2;
        BinaryPrimitives.WriteHalfLittleEndian(Span.Slice(Position, size), value);
        Position += size;
    }
}
