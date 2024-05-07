namespace BinForge.BinaryText;

public interface IBaseEncoder
{
    public string EncodeToString(ReadOnlySpan<byte> bytes);
    public int GetEncodedLength(ReadOnlySpan<byte> bytes);
}
