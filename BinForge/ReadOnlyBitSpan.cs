// Copyright (c) GregDom LLC. All Rights Reserved.
// This file is licensed for use under the MIT license.

namespace BinForge;

public readonly ref struct ReadOnlyBitChunker
{
    private const int BitsPerByte = 8;
    private readonly ReadOnlySpan<byte> _span;
    private readonly int _chunkSize;

    public ReadOnlyBitChunker(ReadOnlySpan<byte> span, int chunkSize)
    {
        _span = span;
        _chunkSize = chunkSize;
    }

    public Enumerator GetEnumerator() =>
        new(this);

    public ref struct Enumerator
    {
        private readonly ReadOnlyBitChunker _chunker;

        private int _index;
        private int _current;

        internal Enumerator(ReadOnlyBitChunker chunker)
        {
            _chunker = chunker;
        }

        public bool MoveNext()
        {
            _current = 0;

            if (_index >= _chunker._span.Length * BitsPerByte)
            {
                return false;
            }

            for (int i = 0; i < _chunker._chunkSize; i++)
            {
                _current <<= 1;

                int byteIndex = _index / BitsPerByte;
                int shift = 7 - (_index % BitsPerByte);

                _current |= (_chunker._span[byteIndex] >> shift) & 0x1;

                if (++_index / BitsPerByte < _chunker._span.Length) { continue; }

                _current <<= _chunker._chunkSize - i - 1;
                break;
            }

            return true;
        }

        public int Current => _current;
    }
}
