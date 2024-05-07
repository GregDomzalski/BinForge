using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteDoubleBigEndian(Span<byte> buffer, double value)
    {
        const int size = sizeof(double);
        BinaryPrimitives.WriteDoubleBigEndian(buffer.Slice(Position, size), value);
        Position += size;
    }

    public void WriteDoubleLittleEndian(Span<byte> buffer, double value)
    {
        const int size = sizeof(double);
        BinaryPrimitives.WriteDoubleLittleEndian(buffer.Slice(Position, size), value);
        Position += size;
    }
}
