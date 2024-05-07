// Copyright (c) GregDom LLC. All Rights Reserved.
// This file is licensed for use under the MIT license.

using FluentAssertions;

namespace BinForge.UnitTests;

public class ReadOnlyBitSpanTests
{
    [Fact]
    public void EnumeratorTests_4BitChunks()
    {
        byte[] bytes =
        [
            0b1111_0000,
            0b1010_0101,
            0b1100_0011,
        ];

        ReadOnlyBitChunker chunker = new(bytes.AsSpan(), 4);
        ReadOnlyBitChunker.Enumerator enumerator = chunker.GetEnumerator();

        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(0b1111);

        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(0x0000);

        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(0b1010);

        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(0b0101);

        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(0b1100);

        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(0b0011);

        enumerator.MoveNext().Should().BeFalse();
    }

    [Fact]
    public void EnumeratorTests_6BitChunks()
    {
        byte[] bytes =
        [
            0b1111_0000,
            0b1010_0101,
            0b1100_0011,
        ];

        ReadOnlyBitChunker chunker = new(bytes.AsSpan(), 6);
        ReadOnlyBitChunker.Enumerator enumerator = chunker.GetEnumerator();

        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(0b1111_00);

        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(0b00_1010);

        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(0b0101_11);

        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(0b00_0011);

        enumerator.MoveNext().Should().BeFalse();
    }

    [Fact]
    public void EnumeratorTests_5BitChunks()
    {
        byte[] bytes =
        [
            0b1111_0000,
            0b1010_0101,
            0b1100_0011,
        ];

        ReadOnlyBitChunker chunker = new(bytes.AsSpan(), 5);
        ReadOnlyBitChunker.Enumerator enumerator = chunker.GetEnumerator();

        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(0b1111_0);

        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(0b000_10);

        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(0b10_010);

        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(0b11_100);

        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(0b00_110);

        enumerator.MoveNext().Should().BeFalse();
    }

    [Fact]
    public void EnumeratorTests_12BitChunks()
    {
        byte[] bytes =
        [
            0b1111_0000,
            0b1010_0101,
            0b1100_0011,
        ];

        ReadOnlyBitChunker chunker = new(bytes.AsSpan(), 12);
        ReadOnlyBitChunker.Enumerator enumerator = chunker.GetEnumerator();

        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(0b1111_0000_1010);

        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(0b0101_1100_0011);

        enumerator.MoveNext().Should().BeFalse();
    }
}
