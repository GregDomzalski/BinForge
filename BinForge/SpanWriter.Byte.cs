namespace BinForge;

public partial struct SpanWriter
{
    public void WriteByte(byte value)
    {
        Span[Position] = value;
        Position++;
    }

    public void WriteSByte(sbyte value)
    {
        Span[Position] = (byte)value;
        Position++;
    }
}
