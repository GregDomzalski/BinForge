using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteIntPtrBigEndian(IntPtr value)
    {
        var size = nint.Size;
        BinaryPrimitives.WriteIntPtrBigEndian(Span.Slice(Position, size), value);
        Position += size;
    }

    public void WriteIntPtrLittleEndian(IntPtr value)
    {
        var size = nint.Size;
        BinaryPrimitives.WriteIntPtrLittleEndian(Span.Slice(Position, size), value);
        Position += size;
    }
}
