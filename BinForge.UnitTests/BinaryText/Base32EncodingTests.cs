// Copyright (c) GregDom LLC. All Rights Reserved.
// This file is licensed for use under the MIT license.

using BinForge.BinaryText;
using FluentAssertions;

namespace BinForge.UnitTests.BinaryText;

public class Base32EncodingTests
{
    public static IEnumerable<object[]> TestData => new List<object[]>
    {
        new object[] { "", Array.Empty<byte>() },
        new object[] { "MY======", "f"u8.ToArray() },
        new object[] { "MZXQ====", "fo"u8.ToArray() },
        new object[] { "MZXW6===", "foo"u8.ToArray() },
        new object[] { "MZXW6YQ=", "foob"u8.ToArray() },
        new object[] { "MZXW6YTB", "fooba"u8.ToArray() },
        new object[] { "MZXW6YTBOI======", "foobar"u8.ToArray() },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void EncodeTest(string expectedOutput, byte[] input)
    {
        Base32Encoding base32Encoding = new();

        string encoded = base32Encoding.EncodeToString(input);

        encoded.Should().Be(expectedOutput);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void GetEncodedLengthTest(string expectedOutput, byte[] input)
    {
        Base32Encoding base32Encoding = new();

        base32Encoding.GetEncodedLength(input).Should().Be(expectedOutput.Length);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void DecodeTest(string input, byte[] expectedOutput)
    {
        Base32Encoding base32Encoding = new();

        byte[] decoded = base32Encoding.DecodeFromString(input);

        decoded.Should().BeEquivalentTo(expectedOutput);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void GetDecodedLengthTest(string input, byte[] expectedOutput)
    {
        Base32Encoding base32Encoding = new();

        base32Encoding.GetDecodedLength(input).Should().Be(expectedOutput.Length);
    }
}
