using System;
using Unity.Collections.LowLevel.Unsafe;

namespace UnityEngine
{
	// Token: 0x020001DB RID: 475
	public static class HashUtilities
	{
		// Token: 0x06001498 RID: 5272 RVA: 0x0001D628 File Offset: 0x0001B828
		public unsafe static void AppendHash(ref Hash128 inHash, ref Hash128 outHash)
		{
			fixed (Hash128* ptr = &outHash)
			{
				Hash128* hash = ptr;
				fixed (Hash128* ptr2 = &inHash)
				{
					Hash128* data = ptr2;
					HashUnsafeUtilities.ComputeHash128((void*)data, (ulong)((long)sizeof(Hash128)), hash);
				}
			}
		}

		// Token: 0x06001499 RID: 5273 RVA: 0x0001D65C File Offset: 0x0001B85C
		public unsafe static void QuantisedMatrixHash(ref Matrix4x4 value, ref Hash128 hash)
		{
			fixed (Hash128* ptr = &hash)
			{
				Hash128* hash2 = ptr;
				int* ptr2 = stackalloc int[(UIntPtr)64];
				for (int i = 0; i < 16; i++)
				{
					ptr2[i] = (int)(value[i] * 1000f + 0.5f);
				}
				HashUnsafeUtilities.ComputeHash128((void*)ptr2, 64UL, hash2);
			}
		}

		// Token: 0x0600149A RID: 5274 RVA: 0x0001D6B8 File Offset: 0x0001B8B8
		public unsafe static void QuantisedVectorHash(ref Vector3 value, ref Hash128 hash)
		{
			fixed (Hash128* ptr = &hash)
			{
				Hash128* hash2 = ptr;
				int* ptr2 = stackalloc int[(UIntPtr)12];
				for (int i = 0; i < 3; i++)
				{
					ptr2[i] = (int)(value[i] * 1000f + 0.5f);
				}
				HashUnsafeUtilities.ComputeHash128((void*)ptr2, 12UL, hash2);
			}
		}

		// Token: 0x0600149B RID: 5275 RVA: 0x0001D710 File Offset: 0x0001B910
		public unsafe static void ComputeHash128<T>(ref T value, ref Hash128 hash) where T : struct
		{
			void* data = UnsafeUtility.AddressOf<T>(ref value);
			ulong dataSize = (ulong)((long)UnsafeUtility.SizeOf<T>());
			Hash128* hash2 = (Hash128*)UnsafeUtility.AddressOf<Hash128>(ref hash);
			HashUnsafeUtilities.ComputeHash128(data, dataSize, hash2);
		}

		// Token: 0x0600149C RID: 5276 RVA: 0x0001D73C File Offset: 0x0001B93C
		public unsafe static void ComputeHash128(byte[] value, ref Hash128 hash)
		{
			fixed (byte* ptr = &value[0])
			{
				byte* data = ptr;
				ulong dataSize = (ulong)((long)value.Length);
				Hash128* hash2 = (Hash128*)UnsafeUtility.AddressOf<Hash128>(ref hash);
				HashUnsafeUtilities.ComputeHash128((void*)data, dataSize, hash2);
			}
		}
	}
}
