using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanWriter
{
    public void WriteIntPtrBigEndian(Span<byte> buffer, IntPtr value)
    {
        var size = nint.Size;
        BinaryPrimitives.WriteIntPtrBigEndian(buffer.Slice(Position, size), value);
        Position += size;
    }

    public void WriteIntPtrLittleEndian(Span<byte> buffer, IntPtr value)
    {
        var size = nint.Size;
        BinaryPrimitives.WriteIntPtrLittleEndian(buffer.Slice(Position, size), value);
        Position += size;
    }
}
