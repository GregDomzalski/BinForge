using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteUIntPtrBigEndian(UIntPtr value)
    {
        int size = nuint.Size;
        BinaryPrimitives.WriteUIntPtrBigEndian(Span.Slice(Position, size), value);
        Position += size;
    }

    public void WriteUIntPtrLittleEndian(UIntPtr value)
    {
        int size = nuint.Size;
        BinaryPrimitives.WriteUIntPtrLittleEndian(Span.Slice(Position, size), value);
        Position += size;
    }
}
