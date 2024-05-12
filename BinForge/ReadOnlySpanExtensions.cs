// Copyright (c) GregDom LLC. All Rights Reserved.
// This file is licensed for use under the MIT license.

namespace BinForge;

/// <summary>
/// Provides useful extension methods on top of <see cref="ReadOnlySpan{T}"/> that provide both LINQ-like experiences
/// and useful bit and byte manipulation of the span data.
/// </summary>
/// <remarks>
/// As a class that is exposing extension methods, it is expected that you do not refer to this class directly. Instead,
/// the compiler will offer these methods as "extensions" to your <see cref="ReadOnlySpan{T}"/> instances. For example,
/// instead of calling:
/// <code>
/// var enumerator = ReadOnlySpanExtensions.Chunk(mySpan, 2);
/// </code>
/// You can simply call:
/// <code>
/// var enumerator = mySpan.Chunk(2);
/// </code>
/// </remarks>
public static class ReadOnlySpanExtensions
{
    /// <summary>
    /// Splits the span into chunks or slices of a certain size, the result of which may be enumerated.
    /// </summary>
    /// <param name="data">
    /// The <see cref="ReadOnlySpan{T}"/> that we're chunking. Note that as an extension method, you should not need
    /// to provide this parameter yourself as it will be automatically filled by the compiler.
    /// </param>
    /// <param name="numberOfBytes">
    /// The number of bytes that should be contained within each chunk.
    /// </param>
    /// <typeparam name="T">
    /// A generic type parameter denoting the kind of ReadOnlySpan we're operating over. This parameter will be inferred
    /// and does not need to be specified explicitly.
    /// </typeparam>
    /// <returns>
    /// A <see cref="ReadOnlySpanByteChunker{T}"/> that exposes a <c>GetEnumerator</c> method. This will allow the result
    /// to be used as an enumerable (i.e. in a foreach statement).
    /// </returns>
    public static ReadOnlySpanByteChunker<T> Chunk<T>(this ReadOnlySpan<T> data, int numberOfBytes) =>
        new(data, numberOfBytes);

    /// <summary>
    /// Splits the span into chunks or slices of a certain bit-width, the result of which can be enumerated. Each chunk
    /// is placed in an <see cref="int"/>.
    /// </summary>
    /// <param name="data">
    /// The <see cref="ReadOnlySpan{T}"/> that we're chunking. Note that as an extension method, you should not need
    /// to provide this parameter yourself as it will be automatically filled in by the compiler.
    /// </param>
    /// <param name="numberOfBits">
    /// The number of bits that should be contained within each chunk. The valid values are between 1 and 32 bits.
    /// </param>
    /// <returns>
    /// A <see cref="ReadOnlyBitChunker"/> that exposes a <c>GetEnumerator</c> method. This will allow the result to be
    /// used as an enumerable (i.e. in a foreach statement).
    /// </returns>
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
