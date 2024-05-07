// Copyright (c) GregDom LLC. All Rights Reserved.
// This file is licensed for use under the MIT license.

namespace BinForge.BinaryText;

public static class BinaryText
{
    public static Base16Encoding Base16 => new();
    public static Base16Encoding ModHex => new(Base16Encoding.ModHexAlphabet);
}
