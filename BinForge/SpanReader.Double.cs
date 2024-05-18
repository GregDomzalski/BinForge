using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public double ReadDoubleBigEndian()
    {
        const int size = sizeof(double);
        double temp = BinaryPrimitives.ReadDoubleBigEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }

    public double ReadDoubleLittleEndian()
    {
        const int size = sizeof(double);
        double temp = BinaryPrimitives.ReadDoubleLittleEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }
}
