using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteSingleBigEndian(Span<byte> buffer, float value)
    {
        const int size = sizeof(float);
        BinaryPrimitives.WriteSingleBigEndian(buffer.Slice(Position, size), value);
        Position += size;
    }

    public void WriteSingleLittleEndian(Span<byte> buffer, float value)
    {
        const int size = sizeof(float);
        BinaryPrimitives.WriteSingleLittleEndian(buffer.Slice(Position, size), value);
        Position += size;
    }
}
