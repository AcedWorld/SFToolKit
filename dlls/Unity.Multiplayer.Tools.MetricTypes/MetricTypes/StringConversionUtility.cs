using System;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace Unity.Multiplayer.Tools.MetricTypes
{
	// Token: 0x0200001B RID: 27
	internal static class StringConversionUtility
	{
		// Token: 0x06000052 RID: 82 RVA: 0x000026BC File Offset: 0x000008BC
		public unsafe static FixedString64Bytes ConvertToFixedString(string value)
		{
			if (value == null)
			{
				return string.Empty;
			}
			if (FixedString64Bytes.UTF8MaxLengthInBytes < value.Length)
			{
				FixedString64Bytes result = default(FixedString64Bytes);
				fixed (string text = value)
				{
					char* ptr = text;
					if (ptr != null)
					{
						ptr += RuntimeHelpers.OffsetToStringData / 2;
					}
					int length;
					UTF8ArrayUnsafeUtility.Copy(result.GetUnsafePtr(), out length, FixedString64Bytes.UTF8MaxLengthInBytes, ptr, value.Length);
					result.Length = length;
				}
				return result;
			}
			return value;
		}
	}
}
