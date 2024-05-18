using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteSingleBigEndian(float value)
    {
        const int size = sizeof(float);
        BinaryPrimitives.WriteSingleBigEndian(Span.Slice(Position, size), value);
        Position += size;
    }

    public void WriteSingleLittleEndian(float value)
    {
        const int size = sizeof(float);
        BinaryPrimitives.WriteSingleLittleEndian(Span.Slice(Position, size), value);
        Position += size;
    }
}
