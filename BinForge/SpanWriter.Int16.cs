using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteInt16BigEndian(Span<byte> buffer, short value)
    {
        const int size = sizeof(short);
        BinaryPrimitives.WriteInt16BigEndian(buffer.Slice(Position, size), value);
        Position += size;
    }

    public void WriteInt16LittleEndian(Span<byte> buffer, short value)
    {
        const int size = sizeof(short);
        BinaryPrimitives.WriteInt16LittleEndian(buffer.Slice(Position, size), value);
        Position += size;
    }
}
