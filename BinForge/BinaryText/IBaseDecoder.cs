namespace BinForge.BinaryText;

public interface IBaseDecoder
{
    public byte[] DecodeFromString(string encoding);
    public bool IsValidString(string encoding);
    public int GetDecodedLength(string encoding);
}
