// Copyright (c) GregDom LLC. All Rights Reserved.
// This file is licensed for use under the MIT license.

namespace BinForge;

public static class BytesNeeded
{
    public static int For(int value)
    {
        if (value > 0xFFFF)
        {
            return value > 0xFFFFFF ? 4 : 3;
        }

        return value > 0xFF ? 2 : 1;
    }
}
