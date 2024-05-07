using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteUInt16BigEndian(Span<byte> buffer, ushort value)
    {
        const int size = sizeof(ushort);
        BinaryPrimitives.WriteUInt16BigEndian(buffer.Slice(Position, size), value);
        Position += size;
    }

    public void WriteUInt16LittleEndian(Span<byte> buffer, ushort value)
    {
        const int size = sizeof(ushort);
        BinaryPrimitives.WriteUInt16LittleEndian(buffer.Slice(Position, size), value);
        Position += size;
    }
}
