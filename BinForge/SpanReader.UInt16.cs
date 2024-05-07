using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public ushort ReadUInt16BigEndian(ReadOnlySpan<byte> data)
    {
        const int size = sizeof(ushort);
        ushort temp = BinaryPrimitives.ReadUInt16BigEndian(data.Slice(Position, size));
        Position += size;
        return temp;
    }

    public ushort ReadUInt16LittleEndian(ReadOnlySpan<byte> data)
    {
        const int size = sizeof(ushort);
        ushort temp = BinaryPrimitives.ReadUInt16LittleEndian(data.Slice(Position, size));
        Position += size;
        return temp;
    }
}
