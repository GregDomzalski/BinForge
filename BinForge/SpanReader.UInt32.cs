using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public uint ReadUInt32BigEndian()
    {
        const int size = sizeof(uint);
        uint temp = BinaryPrimitives.ReadUInt32BigEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }

    public uint ReadUInt32LittleEndian()
    {
        const int size = sizeof(uint);
        uint temp = BinaryPrimitives.ReadUInt32LittleEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }
}
