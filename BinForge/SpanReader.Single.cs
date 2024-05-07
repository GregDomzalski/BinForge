using System.Buffers.Binary;

namespace BinForge;

public partial struct SpanReader
{
    public float ReadSingleBigEndian(ReadOnlySpan<byte> data)
    {
        const int size = sizeof(float);
        float temp = BinaryPrimitives.ReadSingleBigEndian(data.Slice(Position, size));
        Position += size;
        return temp;
    }

    public float ReadSingleLittleEndian(ReadOnlySpan<byte> data)
    {
        const int size = sizeof(float);
        float temp = BinaryPrimitives.ReadSingleLittleEndian(data.Slice(Position, size));
        Position += size;
        return temp;
    }
}
