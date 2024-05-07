namespace BinForge;

public partial struct SpanWriter
{
    public void WriteByte(Span<byte> buffer, byte value)
    {
        buffer[Position] = value;
        Position++;
    }

    public void WriteSByte(Span<byte> buffer, sbyte value)
    {
        buffer[Position] = (byte)value;
        Position++;
    }
}
