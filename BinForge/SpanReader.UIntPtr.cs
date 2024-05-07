using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public nuint ReadUIntPtrBigEndian()
    {
        int size = nuint.Size;
        UIntPtr temp = BinaryPrimitives.ReadUIntPtrBigEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }

    public nuint ReadUIntPtrLittleEndian()
    {
        int size = nuint.Size;
        UIntPtr temp = BinaryPrimitives.ReadUIntPtrLittleEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }
}
