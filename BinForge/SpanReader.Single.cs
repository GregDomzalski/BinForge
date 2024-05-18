using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public float ReadSingleBigEndian()
    {
        const int size = sizeof(float);
        float temp = BinaryPrimitives.ReadSingleBigEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }

    public float ReadSingleLittleEndian()
    {
        const int size = sizeof(float);
        float temp = BinaryPrimitives.ReadSingleLittleEndian(Span.Slice(Position, size));
        Position += size;
        return temp;
    }
}
