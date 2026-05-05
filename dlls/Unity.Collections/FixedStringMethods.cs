using System;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Collections
{
	// Token: 0x0200007F RID: 127
	[BurstCompatible]
	[BurstCompatible]
	[BurstCompatible]
	[BurstCompatible]
	public static class FixedStringMethods
	{
		// Token: 0x06000407 RID: 1031 RVA: 0x0000ABA0 File Offset: 0x00008DA0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public static FormatError Append<T>(this T fs, Unicode.Rune rune) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			int length = fs.Length;
			int num = rune.LengthInUtf8Bytes();
			if (!fs.TryResize(length + num, NativeArrayOptions.UninitializedMemory))
			{
				return FormatError.Overflow;
			}
			return ref fs.Write(ref length, rune);
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0000ABDF File Offset: 0x00008DDF
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public static FormatError Append<T>(this T fs, char ch) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			return ref fs.Append((Unicode.Rune)ch);
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0000ABF0 File Offset: 0x00008DF0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public unsafe static FormatError AppendRawByte<T>(this T fs, byte a) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			int length = fs.Length;
			if (!fs.TryResize(length + 1, NativeArrayOptions.UninitializedMemory))
			{
				return FormatError.Overflow;
			}
			fs.GetUnsafePtr()[length] = a;
			return FormatError.None;
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0000AC30 File Offset: 0x00008E30
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public unsafe static FormatError Append<T>(this T fs, Unicode.Rune rune, int count) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			int length = fs.Length;
			if (!fs.TryResize(length + rune.LengthInUtf8Bytes() * count, NativeArrayOptions.UninitializedMemory))
			{
				return FormatError.Overflow;
			}
			int capacity = fs.Capacity;
			byte* unsafePtr = fs.GetUnsafePtr();
			int num = length;
			for (int i = 0; i < count; i++)
			{
				if (Unicode.UcsToUtf8(unsafePtr, ref num, capacity, rune) != ConversionError.None)
				{
					return FormatError.Overflow;
				}
			}
			return FormatError.None;
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0000ACA4 File Offset: 0x00008EA4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public unsafe static FormatError Append<T>(this T fs, long input) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			byte* ptr = stackalloc byte[(UIntPtr)20];
			int num = 20;
			if (input >= 0L)
			{
				do
				{
					byte b = (byte)(input % 10L);
					ptr[--num] = 48 + b;
					input /= 10L;
				}
				while (input != 0L);
			}
			else
			{
				do
				{
					byte b2 = (byte)(input % 10L);
					ptr[--num] = 48 - b2;
					input /= 10L;
				}
				while (input != 0L);
				ptr[--num] = 45;
			}
			return ref fs.Append(ptr + num, 20 - num);
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0000AD14 File Offset: 0x00008F14
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public static FormatError Append<T>(this T fs, int input) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			return ref fs.Append((long)input);
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x0000AD20 File Offset: 0x00008F20
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public unsafe static FormatError Append<T>(this T fs, ulong input) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			byte* ptr = stackalloc byte[(UIntPtr)20];
			int num = 20;
			do
			{
				byte b = (byte)(input % 10UL);
				ptr[--num] = 48 + b;
				input /= 10UL;
			}
			while (input != 0UL);
			return ref fs.Append(ptr + num, 20 - num);
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x0000AD61 File Offset: 0x00008F61
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public static FormatError Append<T>(this T fs, uint input) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			return ref fs.Append((ulong)input);
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0000AD6C File Offset: 0x00008F6C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public unsafe static FormatError Append<T>(this T fs, float input, char decimalSeparator = '.') where T : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedStringUtils.UintFloatUnion uintFloatUnion = new FixedStringUtils.UintFloatUnion
			{
				floatValue = input
			};
			uint num = uintFloatUnion.uintValue >> 31;
			uintFloatUnion.uintValue &= 2147483647U;
			if ((uintFloatUnion.uintValue & 2139095040U) == 2139095040U)
			{
				if (uintFloatUnion.uintValue != 2139095040U)
				{
					return ref fs.Append('N', 'a', 'N');
				}
				FormatError result;
				if (num != 0U && (result = ref fs.Append('-')) != FormatError.None)
				{
					return result;
				}
				return ref fs.Append('I', 'n', 'f', 'i', 'n', 'i', 't', 'y');
			}
			else
			{
				FormatError result;
				if (num != 0U && uintFloatUnion.uintValue != 0U && (result = ref fs.Append('-')) != FormatError.None)
				{
					return result;
				}
				ulong num2 = 0UL;
				int num3 = 0;
				FixedStringUtils.Base2ToBase10(ref num2, ref num3, uintFloatUnion.floatValue);
				char* ptr = stackalloc char[(UIntPtr)18];
				int i = 0;
				while (i < 9)
				{
					ulong num4 = num2 % 10UL;
					ptr[(IntPtr)(8 - i++) * 2] = (char)(48UL + num4);
					num2 /= 10UL;
					if (num2 <= 0UL)
					{
						char* ptr2 = ptr + 9 - i;
						int j = -num3 - i + 1;
						if (j > 0)
						{
							if (j > 4)
							{
								return ref fs.AppendScientific(ptr2, i, num3, decimalSeparator);
							}
							if ((result = ref fs.Append('0', decimalSeparator)) != FormatError.None)
							{
								return result;
							}
							for (j--; j > 0; j--)
							{
								if ((result = ref fs.Append('0')) != FormatError.None)
								{
									return result;
								}
							}
							for (int k = 0; k < i; k++)
							{
								if ((result = ref fs.Append(ptr2[k])) != FormatError.None)
								{
									return result;
								}
							}
							return FormatError.None;
						}
						else
						{
							int l = num3;
							if (l <= 0)
							{
								int num5 = i + num3;
								for (int m = 0; m < i; m++)
								{
									if (m == num5 && (result = ref fs.Append(decimalSeparator)) != FormatError.None)
									{
										return result;
									}
									if ((result = ref fs.Append(ptr2[m])) != FormatError.None)
									{
										return result;
									}
								}
								return FormatError.None;
							}
							if (l > 4)
							{
								return ref fs.AppendScientific(ptr2, i, num3, decimalSeparator);
							}
							for (int n = 0; n < i; n++)
							{
								if ((result = ref fs.Append(ptr2[n])) != FormatError.None)
								{
									return result;
								}
							}
							while (l > 0)
							{
								if ((result = ref fs.Append('0')) != FormatError.None)
								{
									return result;
								}
								l--;
							}
							return FormatError.None;
						}
					}
				}
				return FormatError.Overflow;
			}
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0000AF8C File Offset: 0x0000918C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public static FormatError Append<T, T2>(this T fs, in T2 input) where T : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			ref T2 ptr = ref UnsafeUtilityExtensions.AsRef<T2>(input);
			return ref fs.Append(ptr.GetUnsafePtr(), ptr.Length);
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x0000AFBE File Offset: 0x000091BE
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public static CopyError CopyFrom<T, T2>(this T fs, in T2 input) where T : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			fs.Length = 0;
			if (ref fs.Append(input) != FormatError.None)
			{
				return CopyError.Truncation;
			}
			return CopyError.None;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0000AFDC File Offset: 0x000091DC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public unsafe static FormatError Append<T>(this T fs, byte* utf8Bytes, int utf8BytesLength) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			int length = fs.Length;
			if (!fs.TryResize(length + utf8BytesLength, NativeArrayOptions.UninitializedMemory))
			{
				return FormatError.Overflow;
			}
			UnsafeUtility.MemCpy((void*)(fs.GetUnsafePtr() + length), (void*)utf8Bytes, (long)utf8BytesLength);
			return FormatError.None;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x0000B024 File Offset: 0x00009224
		[NotBurstCompatible]
		public unsafe static FormatError Append<T>(this T fs, string s) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			int num = s.Length * 4;
			byte* ptr = stackalloc byte[(UIntPtr)num];
			int utf8BytesLength;
			fixed (string text = s)
			{
				char* ptr2 = text;
				if (ptr2 != null)
				{
					ptr2 += RuntimeHelpers.OffsetToStringData / 2;
				}
				if (UTF8ArrayUnsafeUtility.Copy(ptr, out utf8BytesLength, num, ptr2, s.Length) != CopyError.None)
				{
					return FormatError.Overflow;
				}
			}
			return ref fs.Append(ptr, utf8BytesLength);
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x0000B070 File Offset: 0x00009270
		[NotBurstCompatible]
		public static CopyError CopyFrom<T>(this T fs, string s) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			fs.Length = 0;
			if (ref fs.Append(s) != FormatError.None)
			{
				return CopyError.Truncation;
			}
			return CopyError.None;
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x0000B08C File Offset: 0x0000928C
		[NotBurstCompatible]
		public unsafe static void CopyFromTruncated<T>(this T fs, string s) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			fixed (string text = s)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				int length;
				UTF8ArrayUnsafeUtility.Copy(fs.GetUnsafePtr(), out length, fs.Capacity, ptr, s.Length);
				fs.Length = length;
			}
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x0000B0E0 File Offset: 0x000092E0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public unsafe static void AppendFormat<T, U, T0>(this T dest, in U format, in T0 arg0) where T : struct, INativeList<byte>, IUTF8Bytes where U : struct, INativeList<byte>, IUTF8Bytes where T0 : struct, INativeList<byte>, IUTF8Bytes
		{
			ref U ptr = ref UnsafeUtilityExtensions.AsRef<U>(format);
			int length = ptr.Length;
			byte* unsafePtr = ptr.GetUnsafePtr();
			for (int i = 0; i < length; i++)
			{
				if (unsafePtr[i] == 123)
				{
					if (length - i >= 3 && unsafePtr[i + 1] != 123)
					{
						if (unsafePtr[i + 1] - 48 == 0)
						{
							ref dest.Append(arg0);
							i += 2;
						}
						else
						{
							ref dest.AppendRawByte(unsafePtr[i]);
						}
					}
				}
				else
				{
					ref dest.AppendRawByte(unsafePtr[i]);
				}
			}
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x0000B164 File Offset: 0x00009364
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public unsafe static void AppendFormat<T, U, T0, T1>(this T dest, in U format, in T0 arg0, in T1 arg1) where T : struct, INativeList<byte>, IUTF8Bytes where U : struct, INativeList<byte>, IUTF8Bytes where T0 : struct, INativeList<byte>, IUTF8Bytes where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			ref U ptr = ref UnsafeUtilityExtensions.AsRef<U>(format);
			int length = ptr.Length;
			byte* unsafePtr = ptr.GetUnsafePtr();
			for (int i = 0; i < length; i++)
			{
				if (unsafePtr[i] == 123)
				{
					if (length - i >= 3 && unsafePtr[i + 1] != 123)
					{
						int num = (int)(unsafePtr[i + 1] - 48);
						if (num != 0)
						{
							if (num != 1)
							{
								ref dest.AppendRawByte(unsafePtr[i]);
							}
							else
							{
								ref dest.Append(arg1);
								i += 2;
							}
						}
						else
						{
							ref dest.Append(arg0);
							i += 2;
						}
					}
				}
				else
				{
					ref dest.AppendRawByte(unsafePtr[i]);
				}
			}
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x0000B1FC File Offset: 0x000093FC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public unsafe static void AppendFormat<T, U, T0, T1, T2>(this T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2) where T : struct, INativeList<byte>, IUTF8Bytes where U : struct, INativeList<byte>, IUTF8Bytes where T0 : struct, INativeList<byte>, IUTF8Bytes where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			ref U ptr = ref UnsafeUtilityExtensions.AsRef<U>(format);
			int length = ptr.Length;
			byte* unsafePtr = ptr.GetUnsafePtr();
			for (int i = 0; i < length; i++)
			{
				if (unsafePtr[i] == 123)
				{
					if (length - i >= 3 && unsafePtr[i + 1] != 123)
					{
						switch (unsafePtr[i + 1])
						{
						case 48:
							ref dest.Append(arg0);
							i += 2;
							break;
						case 49:
							ref dest.Append(arg1);
							i += 2;
							break;
						case 50:
							ref dest.Append(arg2);
							i += 2;
							break;
						default:
							ref dest.AppendRawByte(unsafePtr[i]);
							break;
						}
					}
				}
				else
				{
					ref dest.AppendRawByte(unsafePtr[i]);
				}
			}
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x0000B2B0 File Offset: 0x000094B0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public unsafe static void AppendFormat<T, U, T0, T1, T2, T3>(this T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3) where T : struct, INativeList<byte>, IUTF8Bytes where U : struct, INativeList<byte>, IUTF8Bytes where T0 : struct, INativeList<byte>, IUTF8Bytes where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes
		{
			ref U ptr = ref UnsafeUtilityExtensions.AsRef<U>(format);
			int length = ptr.Length;
			byte* unsafePtr = ptr.GetUnsafePtr();
			for (int i = 0; i < length; i++)
			{
				if (unsafePtr[i] == 123)
				{
					if (length - i >= 3 && unsafePtr[i + 1] != 123)
					{
						switch (unsafePtr[i + 1])
						{
						case 48:
							ref dest.Append(arg0);
							i += 2;
							break;
						case 49:
							ref dest.Append(arg1);
							i += 2;
							break;
						case 50:
							ref dest.Append(arg2);
							i += 2;
							break;
						case 51:
							ref dest.Append(arg3);
							i += 2;
							break;
						default:
							ref dest.AppendRawByte(unsafePtr[i]);
							break;
						}
					}
				}
				else
				{
					ref dest.AppendRawByte(unsafePtr[i]);
				}
			}
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x0000B37C File Offset: 0x0000957C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public unsafe static void AppendFormat<T, U, T0, T1, T2, T3, T4>(this T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4) where T : struct, INativeList<byte>, IUTF8Bytes where U : struct, INativeList<byte>, IUTF8Bytes where T0 : struct, INativeList<byte>, IUTF8Bytes where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes where T4 : struct, INativeList<byte>, IUTF8Bytes
		{
			ref U ptr = ref UnsafeUtilityExtensions.AsRef<U>(format);
			int length = ptr.Length;
			byte* unsafePtr = ptr.GetUnsafePtr();
			for (int i = 0; i < length; i++)
			{
				if (unsafePtr[i] == 123)
				{
					if (length - i >= 3 && unsafePtr[i + 1] != 123)
					{
						switch (unsafePtr[i + 1])
						{
						case 48:
							ref dest.Append(arg0);
							i += 2;
							break;
						case 49:
							ref dest.Append(arg1);
							i += 2;
							break;
						case 50:
							ref dest.Append(arg2);
							i += 2;
							break;
						case 51:
							ref dest.Append(arg3);
							i += 2;
							break;
						case 52:
							ref dest.Append(arg4);
							i += 2;
							break;
						default:
							ref dest.AppendRawByte(unsafePtr[i]);
							break;
						}
					}
				}
				else
				{
					ref dest.AppendRawByte(unsafePtr[i]);
				}
			}
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x0000B464 File Offset: 0x00009664
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public unsafe static void AppendFormat<T, U, T0, T1, T2, T3, T4, T5>(this T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5) where T : struct, INativeList<byte>, IUTF8Bytes where U : struct, INativeList<byte>, IUTF8Bytes where T0 : struct, INativeList<byte>, IUTF8Bytes where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes where T4 : struct, INativeList<byte>, IUTF8Bytes where T5 : struct, INativeList<byte>, IUTF8Bytes
		{
			ref U ptr = ref UnsafeUtilityExtensions.AsRef<U>(format);
			int length = ptr.Length;
			byte* unsafePtr = ptr.GetUnsafePtr();
			for (int i = 0; i < length; i++)
			{
				if (unsafePtr[i] == 123)
				{
					if (length - i >= 3 && unsafePtr[i + 1] != 123)
					{
						switch (unsafePtr[i + 1])
						{
						case 48:
							ref dest.Append(arg0);
							i += 2;
							break;
						case 49:
							ref dest.Append(arg1);
							i += 2;
							break;
						case 50:
							ref dest.Append(arg2);
							i += 2;
							break;
						case 51:
							ref dest.Append(arg3);
							i += 2;
							break;
						case 52:
							ref dest.Append(arg4);
							i += 2;
							break;
						case 53:
							ref dest.Append(arg5);
							i += 2;
							break;
						default:
							ref dest.AppendRawByte(unsafePtr[i]);
							break;
						}
					}
				}
				else
				{
					ref dest.AppendRawByte(unsafePtr[i]);
				}
			}
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x0000B560 File Offset: 0x00009760
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public unsafe static void AppendFormat<T, U, T0, T1, T2, T3, T4, T5, T6>(this T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6) where T : struct, INativeList<byte>, IUTF8Bytes where U : struct, INativeList<byte>, IUTF8Bytes where T0 : struct, INativeList<byte>, IUTF8Bytes where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes where T4 : struct, INativeList<byte>, IUTF8Bytes where T5 : struct, INativeList<byte>, IUTF8Bytes where T6 : struct, INativeList<byte>, IUTF8Bytes
		{
			ref U ptr = ref UnsafeUtilityExtensions.AsRef<U>(format);
			int length = ptr.Length;
			byte* unsafePtr = ptr.GetUnsafePtr();
			for (int i = 0; i < length; i++)
			{
				if (unsafePtr[i] == 123)
				{
					if (length - i >= 3 && unsafePtr[i + 1] != 123)
					{
						switch (unsafePtr[i + 1])
						{
						case 48:
							ref dest.Append(arg0);
							i += 2;
							break;
						case 49:
							ref dest.Append(arg1);
							i += 2;
							break;
						case 50:
							ref dest.Append(arg2);
							i += 2;
							break;
						case 51:
							ref dest.Append(arg3);
							i += 2;
							break;
						case 52:
							ref dest.Append(arg4);
							i += 2;
							break;
						case 53:
							ref dest.Append(arg5);
							i += 2;
							break;
						case 54:
							ref dest.Append(arg6);
							i += 2;
							break;
						default:
							ref dest.AppendRawByte(unsafePtr[i]);
							break;
						}
					}
				}
				else
				{
					ref dest.AppendRawByte(unsafePtr[i]);
				}
			}
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x0000B66C File Offset: 0x0000986C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public unsafe static void AppendFormat<T, U, T0, T1, T2, T3, T4, T5, T6, T7>(this T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6, in T7 arg7) where T : struct, INativeList<byte>, IUTF8Bytes where U : struct, INativeList<byte>, IUTF8Bytes where T0 : struct, INativeList<byte>, IUTF8Bytes where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes where T4 : struct, INativeList<byte>, IUTF8Bytes where T5 : struct, INativeList<byte>, IUTF8Bytes where T6 : struct, INativeList<byte>, IUTF8Bytes where T7 : struct, INativeList<byte>, IUTF8Bytes
		{
			ref U ptr = ref UnsafeUtilityExtensions.AsRef<U>(format);
			int length = ptr.Length;
			byte* unsafePtr = ptr.GetUnsafePtr();
			for (int i = 0; i < length; i++)
			{
				if (unsafePtr[i] == 123)
				{
					if (length - i >= 3 && unsafePtr[i + 1] != 123)
					{
						switch (unsafePtr[i + 1])
						{
						case 48:
							ref dest.Append(arg0);
							i += 2;
							break;
						case 49:
							ref dest.Append(arg1);
							i += 2;
							break;
						case 50:
							ref dest.Append(arg2);
							i += 2;
							break;
						case 51:
							ref dest.Append(arg3);
							i += 2;
							break;
						case 52:
							ref dest.Append(arg4);
							i += 2;
							break;
						case 53:
							ref dest.Append(arg5);
							i += 2;
							break;
						case 54:
							ref dest.Append(arg6);
							i += 2;
							break;
						case 55:
							ref dest.Append(arg7);
							i += 2;
							break;
						default:
							ref dest.AppendRawByte(unsafePtr[i]);
							break;
						}
					}
				}
				else
				{
					ref dest.AppendRawByte(unsafePtr[i]);
				}
			}
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x0000B790 File Offset: 0x00009990
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public unsafe static void AppendFormat<T, U, T0, T1, T2, T3, T4, T5, T6, T7, T8>(this T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8) where T : struct, INativeList<byte>, IUTF8Bytes where U : struct, INativeList<byte>, IUTF8Bytes where T0 : struct, INativeList<byte>, IUTF8Bytes where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes where T4 : struct, INativeList<byte>, IUTF8Bytes where T5 : struct, INativeList<byte>, IUTF8Bytes where T6 : struct, INativeList<byte>, IUTF8Bytes where T7 : struct, INativeList<byte>, IUTF8Bytes where T8 : struct, INativeList<byte>, IUTF8Bytes
		{
			ref U ptr = ref UnsafeUtilityExtensions.AsRef<U>(format);
			int length = ptr.Length;
			byte* unsafePtr = ptr.GetUnsafePtr();
			for (int i = 0; i < length; i++)
			{
				if (unsafePtr[i] == 123)
				{
					if (length - i >= 3 && unsafePtr[i + 1] != 123)
					{
						switch (unsafePtr[i + 1])
						{
						case 48:
							ref dest.Append(arg0);
							i += 2;
							break;
						case 49:
							ref dest.Append(arg1);
							i += 2;
							break;
						case 50:
							ref dest.Append(arg2);
							i += 2;
							break;
						case 51:
							ref dest.Append(arg3);
							i += 2;
							break;
						case 52:
							ref dest.Append(arg4);
							i += 2;
							break;
						case 53:
							ref dest.Append(arg5);
							i += 2;
							break;
						case 54:
							ref dest.Append(arg6);
							i += 2;
							break;
						case 55:
							ref dest.Append(arg7);
							i += 2;
							break;
						case 56:
							ref dest.Append(arg8);
							i += 2;
							break;
						default:
							ref dest.AppendRawByte(unsafePtr[i]);
							break;
						}
					}
				}
				else
				{
					ref dest.AppendRawByte(unsafePtr[i]);
				}
			}
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0000B8CC File Offset: 0x00009ACC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public unsafe static void AppendFormat<T, U, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9) where T : struct, INativeList<byte>, IUTF8Bytes where U : struct, INativeList<byte>, IUTF8Bytes where T0 : struct, INativeList<byte>, IUTF8Bytes where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes where T4 : struct, INativeList<byte>, IUTF8Bytes where T5 : struct, INativeList<byte>, IUTF8Bytes where T6 : struct, INativeList<byte>, IUTF8Bytes where T7 : struct, INativeList<byte>, IUTF8Bytes where T8 : struct, INativeList<byte>, IUTF8Bytes where T9 : struct, INativeList<byte>, IUTF8Bytes
		{
			ref U ptr = ref UnsafeUtilityExtensions.AsRef<U>(format);
			int length = ptr.Length;
			byte* unsafePtr = ptr.GetUnsafePtr();
			for (int i = 0; i < length; i++)
			{
				if (unsafePtr[i] == 123)
				{
					if (length - i >= 3 && unsafePtr[i + 1] != 123)
					{
						switch (unsafePtr[i + 1])
						{
						case 48:
							ref dest.Append(arg0);
							i += 2;
							break;
						case 49:
							ref dest.Append(arg1);
							i += 2;
							break;
						case 50:
							ref dest.Append(arg2);
							i += 2;
							break;
						case 51:
							ref dest.Append(arg3);
							i += 2;
							break;
						case 52:
							ref dest.Append(arg4);
							i += 2;
							break;
						case 53:
							ref dest.Append(arg5);
							i += 2;
							break;
						case 54:
							ref dest.Append(arg6);
							i += 2;
							break;
						case 55:
							ref dest.Append(arg7);
							i += 2;
							break;
						case 56:
							ref dest.Append(arg8);
							i += 2;
							break;
						case 57:
							ref dest.Append(arg9);
							i += 2;
							break;
						default:
							ref dest.AppendRawByte(unsafePtr[i]);
							break;
						}
					}
				}
				else
				{
					ref dest.AppendRawByte(unsafePtr[i]);
				}
			}
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0000BA1D File Offset: 0x00009C1D
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		internal static FormatError Append<T>(this T fs, char a, char b) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			if ((FormatError.None | ref fs.Append((Unicode.Rune)a) | ref fs.Append((Unicode.Rune)b)) != FormatError.None)
			{
				return FormatError.Overflow;
			}
			return FormatError.None;
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0000BA3F File Offset: 0x00009C3F
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		internal static FormatError Append<T>(this T fs, char a, char b, char c) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			if ((FormatError.None | ref fs.Append((Unicode.Rune)a) | ref fs.Append((Unicode.Rune)b) | ref fs.Append((Unicode.Rune)c)) != FormatError.None)
			{
				return FormatError.Overflow;
			}
			return FormatError.None;
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x0000BA70 File Offset: 0x00009C70
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		internal static FormatError Append<T>(this T fs, char a, char b, char c, char d, char e, char f, char g, char h) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			if ((FormatError.None | ref fs.Append((Unicode.Rune)a) | ref fs.Append((Unicode.Rune)b) | ref fs.Append((Unicode.Rune)c) | ref fs.Append((Unicode.Rune)d) | ref fs.Append((Unicode.Rune)e) | ref fs.Append((Unicode.Rune)f) | ref fs.Append((Unicode.Rune)g) | ref fs.Append((Unicode.Rune)h)) != FormatError.None)
			{
				return FormatError.Overflow;
			}
			return FormatError.None;
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x0000BAF0 File Offset: 0x00009CF0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		internal unsafe static FormatError AppendScientific<T>(this T fs, char* source, int sourceLength, int decimalExponent, char decimalSeparator = '.') where T : struct, INativeList<byte>, IUTF8Bytes
		{
			FormatError result;
			if ((result = ref fs.Append(*source)) != FormatError.None)
			{
				return result;
			}
			if (sourceLength > 1)
			{
				if ((result = ref fs.Append(decimalSeparator)) != FormatError.None)
				{
					return result;
				}
				for (int i = 1; i < sourceLength; i++)
				{
					if ((result = ref fs.Append(source[i])) != FormatError.None)
					{
						return result;
					}
				}
			}
			if ((result = ref fs.Append('E')) != FormatError.None)
			{
				return result;
			}
			if (decimalExponent < 0)
			{
				if ((result = ref fs.Append('-')) != FormatError.None)
				{
					return result;
				}
				decimalExponent *= -1;
				decimalExponent -= sourceLength - 1;
			}
			else
			{
				if ((result = ref fs.Append('+')) != FormatError.None)
				{
					return result;
				}
				decimalExponent += sourceLength - 1;
			}
			char* ptr = stackalloc char[(UIntPtr)4];
			for (int j = 0; j < 2; j++)
			{
				int num = decimalExponent % 10;
				ptr[1 - j] = (char)(48 + num);
				decimalExponent /= 10;
			}
			for (int k = 0; k < 2; k++)
			{
				if ((result = ref fs.Append(ptr[k])) != FormatError.None)
				{
					return result;
				}
			}
			return FormatError.None;
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x0000BBD0 File Offset: 0x00009DD0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		internal static bool Found<T>(this T fs, ref int offset, char a, char b, char c) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			int num = offset;
			if ((ref fs.Read(ref offset).value | 32) == (int)a && (ref fs.Read(ref offset).value | 32) == (int)b && (ref fs.Read(ref offset).value | 32) == (int)c)
			{
				return true;
			}
			offset = num;
			return false;
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0000BC20 File Offset: 0x00009E20
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		internal static bool Found<T>(this T fs, ref int offset, char a, char b, char c, char d, char e, char f, char g, char h) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			int num = offset;
			if ((ref fs.Read(ref offset).value | 32) == (int)a && (ref fs.Read(ref offset).value | 32) == (int)b && (ref fs.Read(ref offset).value | 32) == (int)c && (ref fs.Read(ref offset).value | 32) == (int)d && (ref fs.Read(ref offset).value | 32) == (int)e && (ref fs.Read(ref offset).value | 32) == (int)f && (ref fs.Read(ref offset).value | 32) == (int)g && (ref fs.Read(ref offset).value | 32) == (int)h)
			{
				return true;
			}
			offset = num;
			return false;
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0000BCD0 File Offset: 0x00009ED0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public unsafe static int IndexOf<T>(this T fs, byte* bytes, int bytesLen) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			byte* unsafePtr = fs.GetUnsafePtr();
			int length = fs.Length;
			int i = 0;
			IL_3C:
			while (i <= length - bytesLen)
			{
				for (int j = 0; j < bytesLen; j++)
				{
					if (unsafePtr[i + j] != bytes[j])
					{
						i++;
						goto IL_3C;
					}
				}
				return i;
			}
			return -1;
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x0000BD20 File Offset: 0x00009F20
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public unsafe static int IndexOf<T>(this T fs, byte* bytes, int bytesLen, int startIndex, int distance = 2147483647) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			byte* unsafePtr = fs.GetUnsafePtr();
			int length = fs.Length;
			int num = Math.Min(distance - 1, length - bytesLen);
			int i = startIndex;
			IL_4F:
			while (i <= num)
			{
				for (int j = 0; j < bytesLen; j++)
				{
					if (unsafePtr[i + j] != bytes[j])
					{
						i++;
						goto IL_4F;
					}
				}
				return i;
			}
			return -1;
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0000BD84 File Offset: 0x00009F84
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public static int IndexOf<T, T2>(this T fs, in T2 other) where T : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			ref T2 ptr = ref UnsafeUtilityExtensions.AsRef<T2>(other);
			return ref fs.IndexOf(ptr.GetUnsafePtr(), ptr.Length);
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0000BDB8 File Offset: 0x00009FB8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public static int IndexOf<T, T2>(this T fs, in T2 other, int startIndex, int distance = 2147483647) where T : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			ref T2 ptr = ref UnsafeUtilityExtensions.AsRef<T2>(other);
			return ref fs.IndexOf(ptr.GetUnsafePtr(), ptr.Length, startIndex, distance);
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0000BDEC File Offset: 0x00009FEC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public static bool Contains<T, T2>(this T fs, in T2 other) where T : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			return ref fs.IndexOf(other) != -1;
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x0000BDFC File Offset: 0x00009FFC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public unsafe static int LastIndexOf<T>(this T fs, byte* bytes, int bytesLen) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			byte* unsafePtr = fs.GetUnsafePtr();
			int i = fs.Length - bytesLen;
			IL_3C:
			while (i >= 0)
			{
				for (int j = 0; j < bytesLen; j++)
				{
					if (unsafePtr[i + j] != bytes[j])
					{
						i--;
						goto IL_3C;
					}
				}
				return i;
			}
			return -1;
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0000BE4C File Offset: 0x0000A04C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public unsafe static int LastIndexOf<T>(this T fs, byte* bytes, int bytesLen, int startIndex, int distance = 2147483647) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			byte* unsafePtr = fs.GetUnsafePtr();
			startIndex = Math.Min(fs.Length - bytesLen, startIndex);
			int num = Math.Max(0, startIndex - distance);
			int i = startIndex;
			IL_50:
			while (i >= num)
			{
				for (int j = 0; j < bytesLen; j++)
				{
					if (unsafePtr[i + j] != bytes[j])
					{
						i--;
						goto IL_50;
					}
				}
				return i;
			}
			return -1;
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0000BEB0 File Offset: 0x0000A0B0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public static int LastIndexOf<T, T2>(this T fs, in T2 other) where T : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			ref T2 ptr = ref UnsafeUtilityExtensions.AsRef<T2>(other);
			return ref fs.LastIndexOf(ptr.GetUnsafePtr(), ptr.Length);
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0000BEE4 File Offset: 0x0000A0E4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public static int LastIndexOf<T, T2>(this T fs, in T2 other, int startIndex, int distance = 2147483647) where T : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			ref T2 ptr = ref UnsafeUtilityExtensions.AsRef<T2>(other);
			return ref fs.LastIndexOf(ptr.GetUnsafePtr(), ptr.Length, startIndex, distance);
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0000BF18 File Offset: 0x0000A118
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public unsafe static int CompareTo<T>(this T fs, byte* bytes, int bytesLen) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			byte* unsafePtr = fs.GetUnsafePtr();
			int length = fs.Length;
			int num = (length < bytesLen) ? length : bytesLen;
			for (int i = 0; i < num; i++)
			{
				if (unsafePtr[i] < bytes[i])
				{
					return -1;
				}
				if (unsafePtr[i] > bytes[i])
				{
					return 1;
				}
			}
			if (length < bytesLen)
			{
				return -1;
			}
			if (length > bytesLen)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x0000BF7C File Offset: 0x0000A17C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public static int CompareTo<T, T2>(this T fs, in T2 other) where T : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			ref T2 ptr = ref UnsafeUtilityExtensions.AsRef<T2>(other);
			return ref fs.CompareTo(ptr.GetUnsafePtr(), ptr.Length);
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x0000BFB0 File Offset: 0x0000A1B0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public unsafe static bool Equals<T>(this T fs, byte* bytes, int bytesLen) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			byte* unsafePtr = fs.GetUnsafePtr();
			return fs.Length == bytesLen && (unsafePtr == bytes || ref fs.CompareTo(bytes, bytesLen) == 0);
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x0000BFEC File Offset: 0x0000A1EC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes),
			typeof(FixedString128Bytes)
		})]
		public static bool Equals<T, T2>(this T fs, in T2 other) where T : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			ref T2 ptr = ref UnsafeUtilityExtensions.AsRef<T2>(other);
			return ref fs.Equals(ptr.GetUnsafePtr(), ptr.Length);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x0000C020 File Offset: 0x0000A220
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public static Unicode.Rune Peek<T>(this T fs, int index) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			if (index >= fs.Length)
			{
				return Unicode.BadRune;
			}
			Unicode.Rune result;
			Unicode.Utf8ToUcs(out result, fs.GetUnsafePtr(), ref index, fs.Capacity);
			return result;
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x0000C068 File Offset: 0x0000A268
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public static Unicode.Rune Read<T>(this T fs, ref int index) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			if (index >= fs.Length)
			{
				return Unicode.BadRune;
			}
			Unicode.Rune result;
			Unicode.Utf8ToUcs(out result, fs.GetUnsafePtr(), ref index, fs.Capacity);
			return result;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0000C0AD File Offset: 0x0000A2AD
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public static FormatError Write<T>(this T fs, ref int index, Unicode.Rune rune) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			if (Unicode.UcsToUtf8(fs.GetUnsafePtr(), ref index, fs.Capacity, rune) != ConversionError.None)
			{
				return FormatError.Overflow;
			}
			return FormatError.None;
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x0000C0D4 File Offset: 0x0000A2D4
		[NotBurstCompatible]
		public unsafe static string ConvertToString<T>(this T fs) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			char* ptr = stackalloc char[checked(unchecked((UIntPtr)(fs.Length * 2)) * 2)];
			int length = 0;
			Unicode.Utf8ToUtf16(fs.GetUnsafePtr(), fs.Length, ptr, out length, fs.Length * 2);
			return new string(ptr, 0, length);
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x0000C12E File Offset: 0x0000A32E
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public unsafe static int ComputeHashCode<T>(this T fs) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			return (int)CollectionHelper.Hash((void*)fs.GetUnsafePtr(), fs.Length);
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x0000C14D File Offset: 0x0000A34D
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public static int EffectiveSizeOf<T>(this T fs) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			return 2 + fs.Length + 1;
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x0000C160 File Offset: 0x0000A360
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool ParseLongInternal<T>(ref T fs, ref int offset, out long value) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			int num = offset;
			int num2 = 1;
			if (offset < fs.Length)
			{
				if (ref fs.Peek(offset).value == 43)
				{
					ref fs.Read(ref offset);
				}
				else if (ref fs.Peek(offset).value == 45)
				{
					num2 = -1;
					ref fs.Read(ref offset);
				}
			}
			int num3 = offset;
			value = 0L;
			while (offset < fs.Length && Unicode.Rune.IsDigit(ref fs.Peek(offset)))
			{
				value *= 10L;
				value += (long)(ref fs.Read(ref offset).value - 48);
			}
			value = (long)num2 * value;
			if (offset == num3)
			{
				offset = num;
				return false;
			}
			return true;
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x0000C210 File Offset: 0x0000A410
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public static ParseError Parse<T>(this T fs, ref int offset, ref int output) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			long num;
			if (!FixedStringMethods.ParseLongInternal<T>(ref fs, ref offset, out num))
			{
				return ParseError.Syntax;
			}
			if (num > 2147483647L)
			{
				return ParseError.Overflow;
			}
			if (num < -2147483648L)
			{
				return ParseError.Overflow;
			}
			output = (int)num;
			return ParseError.None;
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x0000C248 File Offset: 0x0000A448
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public static ParseError Parse<T>(this T fs, ref int offset, ref uint output) where T : struct, INativeList<byte>, IUTF8Bytes
		{
			long num;
			if (!FixedStringMethods.ParseLongInternal<T>(ref fs, ref offset, out num))
			{
				return ParseError.Syntax;
			}
			if (num > (long)((ulong)-1))
			{
				return ParseError.Overflow;
			}
			if (num < 0L)
			{
				return ParseError.Overflow;
			}
			output = (uint)num;
			return ParseError.None;
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x0000C278 File Offset: 0x0000A478
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString128Bytes)
		})]
		public static ParseError Parse<T>(this T fs, ref int offset, ref float output, char decimalSeparator = '.') where T : struct, INativeList<byte>, IUTF8Bytes
		{
			int num = offset;
			int num2 = 1;
			if (offset < fs.Length)
			{
				if (ref fs.Peek(offset).value == 43)
				{
					ref fs.Read(ref offset);
				}
				else if (ref fs.Peek(offset).value == 45)
				{
					num2 = -1;
					ref fs.Read(ref offset);
				}
			}
			if (ref fs.Found(ref offset, 'n', 'a', 'n'))
			{
				output = new FixedStringUtils.UintFloatUnion
				{
					uintValue = 4290772992U
				}.floatValue;
				return ParseError.None;
			}
			if (ref fs.Found(ref offset, 'i', 'n', 'f', 'i', 'n', 'i', 't', 'y'))
			{
				output = ((num2 == 1) ? float.PositiveInfinity : float.NegativeInfinity);
				return ParseError.None;
			}
			ulong num3 = 0UL;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			while (offset < fs.Length && Unicode.Rune.IsDigit(ref fs.Peek(offset)))
			{
				num6++;
				if (num4 < 9)
				{
					ulong num7 = num3 * 10UL + (ulong)((long)(ref fs.Peek(offset).value - 48));
					if (num7 > num3)
					{
						num4++;
					}
					num3 = num7;
				}
				else
				{
					num5--;
				}
				ref fs.Read(ref offset);
			}
			if (offset < fs.Length && ref fs.Peek(offset).value == (int)decimalSeparator)
			{
				ref fs.Read(ref offset);
				while (offset < fs.Length && Unicode.Rune.IsDigit(ref fs.Peek(offset)))
				{
					num6++;
					if (num4 < 9)
					{
						ulong num8 = num3 * 10UL + (ulong)((long)(ref fs.Peek(offset).value - 48));
						if (num8 > num3)
						{
							num4++;
						}
						num3 = num8;
						num5++;
					}
					ref fs.Read(ref offset);
				}
			}
			if (num6 == 0)
			{
				offset = num;
				return ParseError.Syntax;
			}
			int num9 = 0;
			int num10 = 1;
			if (offset < fs.Length && (ref fs.Peek(offset).value | 32) == 101)
			{
				ref fs.Read(ref offset);
				if (offset < fs.Length)
				{
					if (ref fs.Peek(offset).value == 43)
					{
						ref fs.Read(ref offset);
					}
					else if (ref fs.Peek(offset).value == 45)
					{
						num10 = -1;
						ref fs.Read(ref offset);
					}
				}
				int num11 = offset;
				while (offset < fs.Length && Unicode.Rune.IsDigit(ref fs.Peek(offset)))
				{
					num9 = num9 * 10 + (ref fs.Peek(offset).value - 48);
					ref fs.Read(ref offset);
				}
				if (offset == num11)
				{
					offset = num;
					return ParseError.Syntax;
				}
				if (num9 > 38)
				{
					if (num10 == 1)
					{
						return ParseError.Overflow;
					}
					return ParseError.Underflow;
				}
			}
			num9 = num9 * num10 - num5;
			ParseError parseError = FixedStringUtils.Base10ToBase2(ref output, num3, num9);
			if (parseError != ParseError.None)
			{
				return parseError;
			}
			output *= (float)num2;
			return ParseError.None;
		}
	}
}
