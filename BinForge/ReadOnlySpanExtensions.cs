// Copyright (c) GregDom LLC. All Rights Reserved.
// This file is licensed for use under the MIT license.

namespace BinForge;

public static class ReadOnlySpanExtensions
{
    public static ReadOnlySpanByteChunker<T> Chunk<T>(this ReadOnlySpan<T> data, int numberOfBytes) =>
        new(data, numberOfBytes);

    public static ReadOnlyBitChunker BitChunk(this ReadOnlySpan<byte> data, int numberOfBits) =>
        new(data, numberOfBits);

    public static TResult Aggregate<TResult>(
        this ReadOnlySpan<byte> memory,
        TResult seed,
        Func<TResult, byte, TResult> func)
    {
        TResult result = seed;

        foreach (byte b in memory) { result = func(result, b); }

        return result;
    }
}
