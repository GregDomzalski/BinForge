// Copyright (c) GregDom LLC. All Rights Reserved.
// This file is licensed for use under the MIT license.

using BinForge.BinaryText;
using FluentAssertions;

namespace BinForge.UnitTests.BinaryText;

public class Base16EncodingTests
{
    public static IEnumerable<object[]> TestData => new List<object[]>
    {
        new object[] { "", new byte[0] },
        new object[] { "0F", new byte[] { 0x0F } },
        new object[] { "0F30", new byte[] { 0x0F, 0x30 } },
        new object[] { "0F3030", new byte[] { 0x0F, 0x30, 0x30 } },
        new object[] { "0F303062", new byte[] { 0x0F, 0x30, 0x30, 0x62 } },
        new object[] { "0F30306261", new byte[] { 0x0F, 0x30, 0x30, 0x62, 0x61 } },
        new object[] { "0F3030626172", new byte[] { 0x0F, 0x30, 0x30, 0x62, 0x61, 0x72 } },
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
