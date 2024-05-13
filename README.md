<div align="center">
    <img alt="BinForge logo" height="200px" src="./logo.png" />
</div>

# BinForge

### A comprehensive .NET library for bits and bytes. Supports efficient buffer manipulation, encoding and decoding various formats, and much more!

![GitHub license](https://img.shields.io/github/license/GregDomzalski/BinForge)
![GitHub stars](https://img.shields.io/github/stars/GregDomzalski/BinForge?style=flat)
![GitHub forks](https://img.shields.io/github/forks/GregDomzalski/BinForge?style=flat)
![GitHub watchers](https://img.shields.io/github/watchers/GregDomzalski/BinForge?style=flat)
![GitHub repo size](https://img.shields.io/github/repo-size/GregDomzalski/BinForge)
![GitHub last commit](https://img.shields.io/github/last-commit/GregDomzalski/BinForge?color=green)

# Getting started

Simply add the NuGet package to your project: `dotnet add package BinForge`

Love this library? Show your support by giving this project a star!

# Using the library

## Enhancements to Spans

### Chunking spans

Problem: I want to iterate X number of items in a span at a time. For example, the API I call can only accept 64 bytes
at a time.

```csharp
public void SendPacketsToDevice(ReadOnlySpan<byte> data, IDevice dev)
{
    const int packetSize = 64;
    
    // Chunk data into groups of packetSize (64 bytes in this example).
    // An enumerator is returned by Chunk allowing you to iterate over
    // the results in a foreach loop like this:
    foreach (ReadOnlySpan<byte> packet in data.Chunk(packetSize))
    {
        dev.Write(packet);
    }
}
```

No data is copied, no extra allocations are made. Chunking is essentially `Slice` iterated over until there is no more
data left. If the buffer size is not a multiple of the chunk size, the final chunk will only contain the number of
remaining bytes and will not be padded.

### Chunking bit-wise

Problem: I want to iterate over a byte array and pull out N number of bits at a time. Perhaps I have a unique encoding
scheme that requires 7 bits written at a time.

```csharp
public int[] EncodeAs7Bits(ReadOnlySpan<byte> data)
{
    return data.BitChunk(7).ToArray();
}
```

Bits are picked off of the array and stored into as an integer. This means that you can only chunk up to 32 bits at a
time. This is done unsigned - any leading, unused bits in the integer will be `0`. Like regular chunking, if the
original byte array is not a multiple of the bit length, the result will not be padded. We will simply return an integer
with the remaining bits.

### LINQ-like methods

Added support for methods that mimic the following LINQ methods:

- Aggregate
- more coming soon...

### Directly interpret bytes

Interpret bytes as numeric datatypes: `ushort`, `short`, `uint`, `int`, etc. And as Little or Big endian. Just like you
would with `BinaryPrimitives` with the one exception that the length of the array does not need to match the expected
size of the target type. For example, if `AsInt32BigEndian` is called on a `Span<byte>` with only 3 bytes of data, the
value returned will assume that the rest of the missing bytes were zero.

## SpanReader / SpanWriter

Problem: I want to deserialize a data structure that I get as a span, but I don't want to have to deal with manually
specifying lengths and offsets. Can't I just read data like I can with `BinaryReader`?

```csharp
public static MyDataStruct Deserialize(ReadOnlySpan<byte> data)
{
    SpanReader reader = new(data);
    
    return new()
    {
        MessageId = reader.ReadUInt16BigEndian();
        Size = reader.ReadUInt16BigEndian();
        Command = reader.ReadByte();
        Arg1 = reader.ReadUInt32LittleEndian();
        Arg2 = reader.ReadUInt32LittleEndian();
    }
}
```

Read and write spanned data just like you would with something like a `BinaryReader` or `BinaryWriter` on top of a
stream. No span data is copied while reading, and no extra allocations are made during writing.

## BinaryText

This library includes multiple base encodings. Presently we support Base16 (Hex) and Base32, along with alternate and
custom alphabets. For example, "modhex" is supported by the `Base16Encoding` class.

Support for a wide variety of binary text encoding formats will be added, such as Base36, Base45, Base58, Base62, and
Base64.

## Formats

Additional common encoding formats are supported that go beyond what the .NET Base Class Library support out of the box.
For example, a generic `TlvReader` and `TlvWriter` is supported that does not enforce any specific ASN1 encoding such as
`BER`, `DER`, etc. It simply provides a customizable Tag | Length | Value encoder.

More formats will be added upon request.

# License

This project is licensed by GregDom LLC under the terms of the
[MIT](https://github.com/GregDomzalski/BinForge/blob/main/LICENSE) license.
