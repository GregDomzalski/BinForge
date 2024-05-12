// Copyright (c) GregDom LLC. All Rights Reserved.
// This file is licensed for use under the MIT license.

namespace BinForge;

public static class IntegerMath
{
    /// <summary>
    /// Finds the Greatest Common Divisor between two integer numbers.
    /// </summary>
    public static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    /// <summary>
    /// Finds the Least Common Multiple between two integer numbers.
    /// </summary>
    public static int LeastCommonMultiple(int a, int b) =>
        a / Gcd(a, b) * b;
}
