using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteInt128BigEndian(Span<byte> buffer, Int128 value)
    {
        const int size = 16;
        BinaryPrimitives.WriteInt128BigEndian(buffer.Slice(Position, size), value);
        Position += size;
    }

    public void WriteInt128LittleEndian(Span<byte> buffer, Int128 value)
    {
        const int size = 16;
        BinaryPrimitives.WriteInt128LittleEndian(buffer.Slice(Position, size), value);
        Position += size;
    }
}
