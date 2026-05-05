using System;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Unity.Networking.Transport
{
	// Token: 0x02000006 RID: 6
	internal static class Base64
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000020CC File Offset: 0x000002CC
		private unsafe static int FromBase64_Decode_UTF16(byte* startInputPtr, int inputLength, byte* startDestPtr, int destLength)
		{
			if (inputLength == 0)
			{
				return 0;
			}
			if (inputLength % 4 != 0)
			{
				Debug.LogError("Base64 string's length must be multiple of 4");
				return -1;
			}
			if (destLength < inputLength / 4 * 3 - 2)
			{
				Debug.LogError("Dest array is too small");
				return -1;
			}
			byte* ptr = startDestPtr;
			int num = inputLength / 4;
			byte* ptr2 = stackalloc byte[(UIntPtr)256];
			UnsafeUtility.MemSet((void*)ptr2, byte.MaxValue, 256L);
			byte b = 0;
			while ((int)b < "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/".Length)
			{
				ptr2["ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"[(int)b]] = b;
				b += 1;
			}
			ptr2[61] = 0;
			for (int i = 0; i < num - 1; i++)
			{
				byte b2 = ptr2[*startInputPtr];
				byte b3 = ptr2[startInputPtr[2]];
				byte b4 = ptr2[startInputPtr[4]];
				byte b5 = ptr2[startInputPtr[6]];
				if (b2 == 255 || b3 == 255 || b4 == 255 || b5 == 255)
				{
					Debug.LogError("Invalid Base64 symbol");
					return -1;
				}
				*(startDestPtr++) = (byte)((int)b2 << 2 | b3 >> 4);
				*(startDestPtr++) = (byte)((int)b3 << 4 | b4 >> 2);
				*(startDestPtr++) = (byte)((int)b4 << 6 | (int)b5);
				startInputPtr += 8;
			}
			byte b6 = startInputPtr[4];
			byte b7 = startInputPtr[6];
			byte b8 = ptr2[*startInputPtr];
			byte b9 = ptr2[startInputPtr[2]];
			byte b10 = ptr2[b6];
			byte b11 = ptr2[b7];
			if (b8 == 255 || b9 == 255 || b10 == 255 || b11 == 255)
			{
				Debug.LogError("Invalid Base64 symbol");
				return -1;
			}
			*(startDestPtr++) = (byte)((int)b8 << 2 | b9 >> 4);
			if (b6 != 61)
			{
				if (b7 == 61)
				{
					if (destLength < inputLength / 4 * 3 - 1)
					{
						Debug.LogError("Dest array is too small");
						return -1;
					}
					*(startDestPtr++) = (byte)((int)b9 << 4 | b10 >> 2);
				}
				else
				{
					if (destLength < inputLength / 4 * 3)
					{
						Debug.LogError("Dest array is too small");
						return -1;
					}
					*(startDestPtr++) = (byte)((int)b9 << 4 | b10 >> 2);
					*(startDestPtr++) = (byte)((int)b10 << 6 | (int)b11);
				}
			}
			return (int)((long)(startDestPtr - ptr));
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000022D0 File Offset: 0x000004D0
		public unsafe static int FromBase64String(string base64, byte* dest, int destMaxLength)
		{
			int result;
			fixed (string text = base64)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = Base64.FromBase64_Decode_UTF16((byte*)ptr, base64.Length, dest, destMaxLength);
			}
			return result;
		}
	}
}
