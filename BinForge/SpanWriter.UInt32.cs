using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteUInt32BigEndian(Span<byte> buffer, uint value)
    {
        const int size = sizeof(uint);
        BinaryPrimitives.WriteUInt32BigEndian(buffer.Slice(Position, size), value);
        Position += size;
    }

    public void WriteUInt32LittleEndian(Span<byte> buffer, uint value)
    {
        const int size = sizeof(uint);
        BinaryPrimitives.WriteUInt32LittleEndian(buffer.Slice(Position, size), value);
        Position += size;
    }
}
