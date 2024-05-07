using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public double ReadDoubleBigEndian(ReadOnlySpan<byte> data)
    {
        const int size = sizeof(double);
        double temp = BinaryPrimitives.ReadDoubleBigEndian(data.Slice(Position, size));
        Position += size;
        return temp;
    }

    public double ReadDoubleLittleEndian(ReadOnlySpan<byte> data)
    {
        const int size = sizeof(double);
        double temp = BinaryPrimitives.ReadDoubleLittleEndian(data.Slice(Position, size));
        Position += size;
        return temp;
    }
}
