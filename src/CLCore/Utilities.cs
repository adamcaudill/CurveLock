﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveLock.Core
{
  public class Utilities
  {
    // Copyright (c) 2008-2013 Hafthor Stefansson
    // Distributed under the MIT/X11 software license
    // Ref: http://www.opensource.org/licenses/mit-license.php.
    public static unsafe bool ByteArrayCompare(byte[] a1, byte[] a2)
    {
      if (a1 == null || a2 == null || a1.Length != a2.Length)
        return false;

      fixed (byte* p1 = a1, p2 = a2)
      {
        byte* x1 = p1, x2 = p2;
        int l = a1.Length;
        for (int i = 0; i < l / 8; i++, x1 += 8, x2 += 8)
          if (*((long*)x1) != *((long*)x2)) return false;
        if ((l & 4) != 0) { if (*((int*)x1) != *((int*)x2)) return false; x1 += 4; x2 += 4; }
        if ((l & 2) != 0) { if (*((short*)x1) != *((short*)x2)) return false; x1 += 2; x2 += 2; }
        if ((l & 1) != 0) if (*((byte*)x1) != *((byte*)x2)) return false;

        return true;
      }
    }

    public static int Clamp(int value, int min, int max)
    {
      return (value < min) ? min : (value > max) ? max : value;
    }
  }
}
