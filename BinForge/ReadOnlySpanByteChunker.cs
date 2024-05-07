// Copyright (c) GregDom LLC. All Rights Reserved.
// This file is licensed for use under the MIT license.

namespace BinForge;

public ref struct ReadOnlySpanByteChunker<T>
{
    private ReadOnlySpan<T> _span;
    private readonly int _chunkSize;

    public ReadOnlySpanByteChunker(ReadOnlySpan<T> span, int chunkSize)
    {
        _span = span;
        _chunkSize = chunkSize;
    }

    public Enumerator GetEnumerator() =>
        new(this);

    public ref struct Enumerator
    {
        private ReadOnlySpanByteChunker<T> _chunker;

        public Enumerator(ReadOnlySpanByteChunker<T> chunker)
        {
            _chunker = chunker;
        }

        public bool MoveNext()
        {
            int take = Math.Min(_chunker._chunkSize, _chunker._span.Length);

            if (take == 0) { return false; }

            Current = _chunker._span[..take];
            _chunker._span = _chunker._span[take..];

            return true;
        }

        public ReadOnlySpan<T> Current { get; private set; }
    }
}
