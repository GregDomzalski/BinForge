namespace BinForge;

public ref partial struct SpanReader
{
    public ReadOnlySpan<byte> Span { get; init; }
    public int Position { get; private set; }

    public SpanReader()
    {

    }

    public SpanReader(ReadOnlySpan<byte> span)
    {
        Span = span;
    }

    public void Skip(int count) =>
        Position += count;
}
