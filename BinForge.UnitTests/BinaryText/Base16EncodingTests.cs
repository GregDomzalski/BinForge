// Copyright (c) GregDom LLC. All Rights Reserved.
// This file is licensed for use under the MIT license.

using BinForge.BinaryText;
using FluentAssertions;

namespace BinForge.UnitTests.BinaryText;

public class Base16EncodingTests
{
    public static IEnumerable<object[]> TestData => new List<object[]>
    {
        new object[] { "", Array.Empty<byte>() },
        new object[] { "66", "f"u8.ToArray() },
        new object[] { "666F", "fo"u8.ToArray() },
        new object[] { "666F6F", "foo"u8.ToArray() },
        new object[] { "666F6F62", "foob"u8.ToArray() },
        new object[] { "666F6F6261", "fooba"u8.ToArray() },
        new object[] { "666F6F626172", "foobar"u8.ToArray() },
    };

    public static IEnumerable<object[]> CaseTestData => new List<object[]>
    {
        new object[] { "AABBCCDDEEFF", new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF }, true },
        new object[] { "aabbccddeeff", new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF }, false },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void EncodeTest(string expectedOutput, byte[] input)
    {
        Base16Encoding base16Encoding = new();

        string encoded = base16Encoding.EncodeToString(input);

        encoded.Should().Be(expectedOutput);
    }

    [Theory]
    [MemberData(nameof(CaseTestData))]
    public void CasedEncodeTest(string expectedOutput, byte[] input, bool upperCase)
    {
        Base16Encoding base16Encoding = new() { EncodesAsUppercase = upperCase };

        string encoded = base16Encoding.EncodeToString(input);

        encoded.Should().Be(expectedOutput);
    }


    [Theory]
    [MemberData(nameof(TestData))]
    public void DecodeTest(string input, byte[] expectedOutput)
    {
        Base16Encoding base16Encoding = new();

        byte[] decoded = base16Encoding.DecodeFromString(input);

        decoded.Should().BeEquivalentTo(expectedOutput);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void CasedDecodeTest(string input, byte[] expectedOutput)
    {
        Base16Encoding base16Encoding = new();

        byte[] decoded = base16Encoding.DecodeFromString(input);

        decoded.Should().BeEquivalentTo(expectedOutput);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void GetEncodedLengthTest(string expectedOutput, byte[] input)
    {
        Base16Encoding base16Encoding = new();

        base16Encoding.GetEncodedLength(input).Should().Be(expectedOutput.Length);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void GetDecodedLengthTest(string input, byte[] expectedOutput)
    {
        Base16Encoding base16Encoding = new();

        base16Encoding.GetDecodedLength(input).Should().Be(expectedOutput.Length);
    }
}
