using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteHalfBigEndian(Span<byte> buffer, Half value)
    {
        const int size = 2;
        BinaryPrimitives.WriteHalfBigEndian(buffer.Slice(Position, size), value);
        Position += size;
    }

    public void WriteHalfLittleEndian(Span<byte> buffer, Half value)
    {
        const int size = 2;
        BinaryPrimitives.WriteHalfLittleEndian(buffer.Slice(Position, size), value);
        Position += size;
    }
}
