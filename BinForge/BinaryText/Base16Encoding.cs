// Copyright (c) GregDom LLC. All Rights Reserved.
// This file is licensed for use under the MIT license.

namespace BinForge.BinaryText;

public class Base16Encoding : IBaseDecoder, IBaseEncoder
{
    public const string Base16Alphabet = "0123456789abcdef0123456789ABCDEF";
    public const string ModHexAlphabet = "cbdefghijklnrtuvCBDEFGHIJKLNRTUV";

    private static readonly HashSet<char> Base16HashSet = new(Base16Alphabet);
    private static readonly HashSet<char> ModHexHashSet = new(ModHexAlphabet);

    public string Alphabet { get; }
    public bool EncodesAsUppercase { get; set; } = true;

    private HashSet<char> HashedAlphabet { get; }

    public Base16Encoding(string alphabet = Base16Alphabet)
    {
        Alphabet = alphabet;
        HashedAlphabet = Alphabet == Base16Alphabet ? Base16HashSet : ModHexHashSet;
    }

    public byte[] DecodeFromString(string encoding)
    {
        if (!IsValidString(encoding))
        {
            throw new ArgumentException(
                $"Not a valid Base16 encoding using the alphabet {Alphabet}.",
                nameof(encoding));
        }

        byte[] decoded = new byte[GetDecodedLength(encoding)];

        for (int i = 0; i < GetDecodedLength(encoding); i++)
        {
            decoded[i] = (byte)(Alphabet.IndexOf(encoding[i * 2], StringComparison.Ordinal) << 4);
            decoded[i] |= (byte)(Alphabet.IndexOf(encoding[(i * 2) + 1], StringComparison.Ordinal) & 0xF);
        }

        return decoded;
    }

    public bool IsValidString(string encoding) =>
        HashedAlphabet.IsProperSupersetOf(encoding);

    public int GetDecodedLength(string encoding) =>
        encoding.Length / 2;

    public string EncodeToString(ReadOnlySpan<byte> bytes)
    {
        char[] encoded = new char[GetEncodedLength(bytes)];

        int i = 0;
        int upperBit = EncodesAsUppercase ? 0x10 : 0x00;

        foreach (byte b in bytes)
        {
            encoded[i++] = Alphabet[(b >> 4) | upperBit];
            encoded[i++] = Alphabet[(b & 0xF) | upperBit];
        }

        return new(encoded);
    }

    public int GetEncodedLength(ReadOnlySpan<byte> bytes) =>
        bytes.Length * 2;
}
