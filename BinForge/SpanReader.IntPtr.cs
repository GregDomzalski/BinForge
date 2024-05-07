using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public nint ReadIntPtrBigEndian(ReadOnlySpan<byte> data)
    {
        int size = nint.Size;
        IntPtr temp = BinaryPrimitives.ReadIntPtrBigEndian(data.Slice(Position, size));
        Position += size;
        return temp;
    }

    public nint ReadIntPtrLittleEndian(ReadOnlySpan<byte> data)
    {
        int size = nint.Size;
        IntPtr temp = BinaryPrimitives.ReadIntPtrLittleEndian(data.Slice(Position, size));
        Position += size;
        return temp;
    }
}
