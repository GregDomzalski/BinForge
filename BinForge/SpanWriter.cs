namespace BinForge;

public ref partial struct SpanWriter
{
    public Span<byte> Span { get; init; }
    public int Position { get; private set; }

    public SpanWriter()
    {

    }

    public SpanWriter(Span<byte> span)
    {
        Span = span;
    }

    public void Skip(int count) =>
        Position += count;
}
