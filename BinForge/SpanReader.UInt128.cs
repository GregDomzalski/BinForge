using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public UInt128 ReadUInt128BigEndian()
    {
        const int size = 16;
        UInt128 temp = BinaryPrimitives.ReadUInt128BigEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }

    public UInt128 ReadUInt128LittleEndian()
    {
        const int size = 16;
        UInt128 temp = BinaryPrimitives.ReadUInt128LittleEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }
}
