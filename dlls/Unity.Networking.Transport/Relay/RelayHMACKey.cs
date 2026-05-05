using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Unity.Networking.Transport.Relay
{
	// Token: 0x02000098 RID: 152
	public struct RelayHMACKey
	{
		// Token: 0x06000284 RID: 644 RVA: 0x0000DDB0 File Offset: 0x0000BFB0
		public unsafe static RelayHMACKey FromBytePointer(byte* data, int length)
		{
			if (length != 64)
			{
				Debug.LogError(string.Format("Provided byte array length is invalid, must be {0} but got {1}.", 64, length));
				return default(RelayHMACKey);
			}
			RelayHMACKey result = default(RelayHMACKey);
			UnsafeUtility.MemCpy((void*)(&result.Value.FixedElementField), (void*)data, (long)length);
			return result;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000DE08 File Offset: 0x0000C008
		public unsafe static RelayHMACKey FromByteArray(byte[] data)
		{
			byte* data2;
			if (data == null || data.Length == 0)
			{
				data2 = null;
			}
			else
			{
				data2 = &data[0];
			}
			return RelayHMACKey.FromBytePointer(data2, data.Length);
		}

		// Token: 0x040001FB RID: 507
		public const int k_Length = 64;

		// Token: 0x040001FC RID: 508
		[FixedBuffer(typeof(byte), 64)]
		public RelayHMACKey.<Value>e__FixedBuffer Value;

		// Token: 0x02000099 RID: 153
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 64)]
		public struct <Value>e__FixedBuffer
		{
			// Token: 0x040001FD RID: 509
			public byte FixedElementField;
		}
	}
}
