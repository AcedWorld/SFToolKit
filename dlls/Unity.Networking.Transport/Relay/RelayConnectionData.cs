using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Unity.Networking.Transport.Relay
{
	// Token: 0x02000095 RID: 149
	public struct RelayConnectionData
	{
		// Token: 0x06000282 RID: 642 RVA: 0x0000DD24 File Offset: 0x0000BF24
		public unsafe static RelayConnectionData FromBytePointer(byte* dataPtr, int length)
		{
			if (length > 255)
			{
				Debug.LogError(string.Format("Provided byte array length is invalid, must be less or equal to {0} but got {1}.", 255, length));
				return default(RelayConnectionData);
			}
			RelayConnectionData result = default(RelayConnectionData);
			UnsafeUtility.MemCpy((void*)(&result.Value.FixedElementField), (void*)dataPtr, (long)length);
			return result;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000DD80 File Offset: 0x0000BF80
		public unsafe static RelayConnectionData FromByteArray(byte[] data)
		{
			byte* dataPtr;
			if (data == null || data.Length == 0)
			{
				dataPtr = null;
			}
			else
			{
				dataPtr = &data[0];
			}
			return RelayConnectionData.FromBytePointer(dataPtr, data.Length);
		}

		// Token: 0x040001F3 RID: 499
		public const int k_Length = 255;

		// Token: 0x040001F4 RID: 500
		[FixedBuffer(typeof(byte), 255)]
		public RelayConnectionData.<Value>e__FixedBuffer Value;

		// Token: 0x02000096 RID: 150
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 255)]
		public struct <Value>e__FixedBuffer
		{
			// Token: 0x040001F5 RID: 501
			public byte FixedElementField;
		}
	}
}
