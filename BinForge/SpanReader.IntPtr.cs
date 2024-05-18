using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public nint ReadIntPtrBigEndian()
    {
        int size = nint.Size;
        IntPtr temp = BinaryPrimitives.ReadIntPtrBigEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }

    public nint ReadIntPtrLittleEndian()
    {
        int size = nint.Size;
        IntPtr temp = BinaryPrimitives.ReadIntPtrLittleEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }
}
