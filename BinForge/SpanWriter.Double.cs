using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteDoubleBigEndian(double value)
    {
        const int size = sizeof(double);
        BinaryPrimitives.WriteDoubleBigEndian(Span.Slice(Position, size), value);
        Position += size;
    }

    public void WriteDoubleLittleEndian(double value)
    {
        const int size = sizeof(double);
        BinaryPrimitives.WriteDoubleLittleEndian(Span.Slice(Position, size), value);
        Position += size;
    }
}
