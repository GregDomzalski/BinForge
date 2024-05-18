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

    public readonly byte PeekByte() =>
        Span[Position];

    public readonly byte PeekByte(int offset) =>
        Span[Position + offset];

    public readonly ReadOnlySpan<byte> PeekBytes(int length) =>
        Span[..length];

    public readonly ReadOnlySpan<byte> PeekBytes(int length, int offset) =>
        Span.Slice(offset, length);

}
