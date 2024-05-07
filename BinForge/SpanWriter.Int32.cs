using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteInt32BigEndian(Span<byte> buffer, int value)
    {
        const int size = sizeof(int);
        BinaryPrimitives.WriteInt32BigEndian(buffer.Slice(Position, size), value);
        Position += size;
    }

    public void WriteInt32LittleEndian(Span<byte> buffer, int value)
    {
        const int size = sizeof(int);
        BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(Position, size), value);
        Position += size;
    }
}
