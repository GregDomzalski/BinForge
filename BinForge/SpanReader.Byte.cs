namespace BinForge;

public partial struct SpanReader
{
    public byte ReadByte()
    {
        byte temp = Span[Position];
        Position++;
        return temp;
    }

    public sbyte ReadSByte()
    {
        sbyte temp = (sbyte)Span[Position];
        Position++;
        return temp;
    }
}
