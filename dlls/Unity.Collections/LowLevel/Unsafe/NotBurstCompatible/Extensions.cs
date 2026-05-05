using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections.LowLevel.Unsafe.NotBurstCompatible
{
	// Token: 0x0200012A RID: 298
	public static class Extensions
	{
		// Token: 0x06000B12 RID: 2834 RVA: 0x00022D0C File Offset: 0x00020F0C
		public static T[] ToArray<[IsUnmanaged] T>(this UnsafeHashSet<T> set) where T : struct, ValueType, IEquatable<T>
		{
			NativeArray<T> nativeArray = set.ToNativeArray(Allocator.TempJob);
			T[] result = nativeArray.ToArray();
			nativeArray.Dispose();
			return result;
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x00022D38 File Offset: 0x00020F38
		[NotBurstCompatible]
		public unsafe static void AddNBC(this UnsafeAppendBuffer buffer, string value)
		{
			if (value != null)
			{
				buffer.Add<int>(value.Length);
				fixed (string text = value)
				{
					char* ptr = text;
					if (ptr != null)
					{
						ptr += RuntimeHelpers.OffsetToStringData / 2;
					}
					buffer.Add((void*)ptr, 2 * value.Length);
				}
				return;
			}
			buffer.Add<int>(-1);
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x00022D80 File Offset: 0x00020F80
		[NotBurstCompatible]
		public unsafe static byte[] ToBytesNBC(this UnsafeAppendBuffer buffer)
		{
			byte[] array2;
			byte[] array = array2 = new byte[buffer.Length];
			byte* destination;
			if (array == null || array2.Length == 0)
			{
				destination = null;
			}
			else
			{
				destination = &array2[0];
			}
			UnsafeUtility.MemCpy((void*)destination, (void*)buffer.Ptr, (long)buffer.Length);
			array2 = null;
			return array;
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x00022DC8 File Offset: 0x00020FC8
		[NotBurstCompatible]
		public unsafe static void ReadNextNBC(this UnsafeAppendBuffer.Reader reader, out string value)
		{
			int num;
			reader.ReadNext<int>(out num);
			if (num != -1)
			{
				value = new string('0', num);
				fixed (string text = value)
				{
					char* ptr = text;
					if (ptr != null)
					{
						ptr += RuntimeHelpers.OffsetToStringData / 2;
					}
					int num2 = num * 2;
					UnsafeUtility.MemCpy((void*)ptr, reader.ReadNext(num2), (long)num2);
				}
				return;
			}
			value = null;
		}
	}
}
