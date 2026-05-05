using System;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace Unity.Networking.Transport.Utilities
{
	// Token: 0x020000C8 RID: 200
	public static class NativeListExt
	{
		// Token: 0x060002FC RID: 764 RVA: 0x000110A4 File Offset: 0x0000F2A4
		public static void ResizeUninitializedTillPowerOf2<[IsUnmanaged] T>(this NativeList<T> list, int sizeToFit) where T : struct, ValueType
		{
			int length = list.Length;
			if (sizeToFit >= length)
			{
				sizeToFit |= sizeToFit >> 1;
				sizeToFit |= sizeToFit >> 2;
				sizeToFit |= sizeToFit >> 4;
				sizeToFit |= sizeToFit >> 8;
				sizeToFit |= sizeToFit >> 16;
				sizeToFit++;
				list.ResizeUninitialized(sizeToFit);
			}
		}
	}
}
