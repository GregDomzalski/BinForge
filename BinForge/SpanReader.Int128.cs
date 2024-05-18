using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public Int128 ReadInt128BigEndian()
    {
        const int size = 16;
        Int128 temp = BinaryPrimitives.ReadInt128BigEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }

    public Int128 ReadInt128LittleEndian()
    {
        const int size = 16;
        Int128 temp = BinaryPrimitives.ReadInt128LittleEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }
}
