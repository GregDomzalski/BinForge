// Copyright (c) GregDom LLC. All Rights Reserved.
// This file is licensed for use under the MIT license.

namespace BinForge.BinaryText;

public class Base32Encoding : IBaseDecoder, IBaseEncoder
{
    public const string Base32Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
    public const string Base32HexAlphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUV";

    private static readonly HashSet<char> Base32HashSet = new(Base32Alphabet);
    private static readonly HashSet<char> Base32HexHashSet = new(Base32HexAlphabet);

    public string Alphabet { get; }
    private HashSet<char> HashedAlphabet { get; }
    public char PaddingChar { get; set; } = '=';

    public Base32Encoding(string alphabet = Base32Alphabet)
    {
        Alphabet = alphabet;
        HashedAlphabet = Alphabet == Base32Alphabet ? Base32HashSet : Base32HexHashSet;
    }

    public byte[] DecodeFromString(string encoding)
    {
        encoding = encoding.TrimEnd(PaddingChar);

        if (!IsValidString(encoding))
        {
            throw new ArgumentException(
                $"Not a valid Base32 encoding using the alphabet {Alphabet}.",
                nameof(encoding));
        }

        byte[] decoded = new byte[GetDecodedLength(encoding)];

        byte currentByte = 0;
        byte bits = 8;
        int index = 0;

        foreach (int block in encoding.Select(c => Alphabet.IndexOf(c)))
        {
            int mask;

            if (bits > 5)
            {
                mask = block << (bits - 5);
                currentByte = (byte)(currentByte | mask);
                bits -= 5;
            }
            else
            {
                mask = block >> (5 - bits);
                currentByte = (byte)(currentByte | mask);
                decoded[index++] = currentByte;
                currentByte = (byte)(block << (3 + bits));
                bits += 3;
            }
        }

        if (index != decoded.Length)
        {
            decoded[index] = currentByte;
        }

        return decoded;
    }

    public bool IsValidString(string encoding) =>
        HashedAlphabet.IsProperSupersetOf(encoding);

    public int GetDecodedLength(string encoding) =>
        encoding.TrimEnd(PaddingChar).Length * 5 / 8;

    public string EncodeToString(ReadOnlySpan<byte> bytes)
    {
        char[] encoded = new char[GetEncodedLength(bytes)];

        int i = 0;

        foreach (byte b in bytes.BitChunk(5))
        {
            encoded[i++] = Alphabet[b];
        }

        Array.Fill(encoded, PaddingChar, i, encoded.Length - i);

        return new(encoded);
    }

    public int GetEncodedLength(ReadOnlySpan<byte> bytes) =>
        (bytes.Length + 4) / 5 * 8;
}
