using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Mathematics;

namespace Unity.Networking.Transport
{
	// Token: 0x02000026 RID: 38
	public struct NetworkCompressionModel : IDisposable
	{
		// Token: 0x060000D7 RID: 215 RVA: 0x00003CAF File Offset: 0x00001EAF
		public void Dispose()
		{
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00004DAC File Offset: 0x00002FAC
		public unsafe NetworkCompressionModel(Allocator allocator)
		{
			for (int i = 0; i < 16; i++)
			{
				*(ref this.bucketSizes.FixedElementField + i) = NetworkCompressionModel.k_BucketSizes[i];
				*(ref this.bucketOffsets.FixedElementField + (IntPtr)i * 4) = NetworkCompressionModel.k_BucketOffsets[i];
			}
			byte[] array = NetworkCompressionModel.k_DefaultModelData;
			int num = 1;
			byte[,] array2 = new byte[num, 16];
			int num2 = 0;
			byte b = array[num2++];
			for (int j = 0; j < 16; j++)
			{
				byte b2 = array[num2++];
				for (int k = 0; k < num; k++)
				{
					array2[k, j] = b2;
				}
			}
			int num3 = (int)array[num2] | (int)array[num2 + 1] << 8;
			num2 += 2;
			for (int l = 0; l < num3; l++)
			{
				int num4 = (int)array[num2] | (int)array[num2 + 1] << 8;
				num2 += 2;
				byte b3 = array[num2++];
				for (int m = 0; m < 16; m++)
				{
					byte b4 = array[num2++];
					array2[num4, m] = b4;
				}
			}
			byte[] array3 = new byte[16];
			ushort[] array4 = new ushort[64];
			byte[] array5 = new byte[16];
			for (int n = 0; n < num; n++)
			{
				for (int num5 = 0; num5 < 16; num5++)
				{
					array3[num5] = array2[n, num5];
				}
				NetworkCompressionModel.GenerateHuffmanCodes(array5, 0, array3, 0, 16, 6);
				NetworkCompressionModel.GenerateHuffmanDecodeTable(array4, 0, array3, array5, 16, 6);
				for (int num6 = 0; num6 < 16; num6++)
				{
					*(ref this.encodeTable.FixedElementField + (IntPtr)(n * 16 + num6) * 2) = (ushort)((int)array5[num6] << 8 | (int)array2[n, num6]);
				}
				for (int num7 = 0; num7 < 64; num7++)
				{
					*(ref this.decodeTable.FixedElementField + (IntPtr)(n * 64 + num7) * 2) = array4[num7];
				}
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00004F88 File Offset: 0x00003188
		private static void GenerateHuffmanCodes(byte[] symboLCodes, int symbolCodesOffset, byte[] symbolLengths, int symbolLengthsOffset, int alphabetSize, int maxCodeLength)
		{
			byte[] array = new byte[maxCodeLength + 1];
			byte[,] array2 = new byte[maxCodeLength + 1, alphabetSize];
			for (int i = 0; i < alphabetSize; i++)
			{
				int num = (int)symbolLengths[i + symbolLengthsOffset];
				byte[,] array3 = array2;
				int num2 = num;
				byte[] array4 = array;
				int num3 = num;
				byte b = array4[num3];
				array4[num3] = b + 1;
				array3[num2, (int)b] = (byte)i;
			}
			uint num4 = 0U;
			for (int j = 1; j <= maxCodeLength; j++)
			{
				int num5 = (int)array[j];
				for (int k = 0; k < num5; k++)
				{
					int num6 = (int)array2[j, k];
					symboLCodes[num6 + symbolCodesOffset] = (byte)NetworkCompressionModel.ReverseBits(num4++, j);
				}
				num4 <<= 1;
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000502C File Offset: 0x0000322C
		private static uint ReverseBits(uint value, int num_bits)
		{
			value = ((value & 1431655765U) << 1 | (value & 2863311530U) >> 1);
			value = ((value & 858993459U) << 2 | (value & 3435973836U) >> 2);
			value = ((value & 252645135U) << 4 | (value & 4042322160U) >> 4);
			value = ((value & 16711935U) << 8 | (value & 4278255360U) >> 8);
			value = (value << 16 | value >> 16);
			return value >> 32 - num_bits;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000050A4 File Offset: 0x000032A4
		private static void GenerateHuffmanDecodeTable(ushort[] decodeTable, int decodeTableOffset, byte[] symbolLengths, byte[] symbolCodes, int alphabetSize, int maxCodeLength)
		{
			uint num = 1U << maxCodeLength;
			for (int i = 0; i < alphabetSize; i++)
			{
				int num2 = (int)symbolLengths[i];
				if (num2 > 0)
				{
					uint num3 = (uint)symbolCodes[i];
					uint num4 = 1U << num2;
					do
					{
						decodeTable[(int)(checked((IntPtr)(unchecked((long)decodeTableOffset + (long)((ulong)num3)))))] = (ushort)(i << 8 | num2);
						num3 += num4;
					}
					while (num3 < num);
				}
			}
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000050F4 File Offset: 0x000032F4
		public unsafe int CalculateBucket(uint value)
		{
			int num = NetworkCompressionModel.k_FirstBucketCandidate[math.lzcnt(value)];
			if (num + 1 < 16 && value >= *(ref this.bucketOffsets.FixedElementField + (IntPtr)(num + 1) * 4))
			{
				num++;
			}
			return num;
		}

		// Token: 0x04000065 RID: 101
		internal static readonly byte[] k_BucketSizes = new byte[]
		{
			0,
			0,
			1,
			2,
			3,
			4,
			6,
			8,
			10,
			12,
			15,
			18,
			21,
			24,
			27,
			32
		};

		// Token: 0x04000066 RID: 102
		internal static readonly uint[] k_BucketOffsets = new uint[]
		{
			0U,
			1U,
			2U,
			4U,
			8U,
			16U,
			32U,
			96U,
			352U,
			1376U,
			5472U,
			38240U,
			300384U,
			2397536U,
			19174752U,
			153392480U
		};

		// Token: 0x04000067 RID: 103
		internal static readonly int[] k_FirstBucketCandidate = new int[]
		{
			15,
			15,
			15,
			15,
			14,
			14,
			14,
			13,
			13,
			13,
			12,
			12,
			12,
			11,
			11,
			11,
			10,
			10,
			10,
			9,
			9,
			8,
			8,
			7,
			7,
			6,
			5,
			4,
			3,
			2,
			1,
			1,
			0
		};

		// Token: 0x04000068 RID: 104
		internal static readonly byte[] k_DefaultModelData = new byte[]
		{
			16,
			2,
			3,
			3,
			3,
			4,
			4,
			4,
			5,
			5,
			5,
			6,
			6,
			6,
			6,
			6,
			6,
			0,
			0
		};

		// Token: 0x04000069 RID: 105
		internal const int k_AlphabetSize = 16;

		// Token: 0x0400006A RID: 106
		internal const int k_MaxHuffmanSymbolLength = 6;

		// Token: 0x0400006B RID: 107
		internal const int k_MaxContexts = 1;

		// Token: 0x0400006C RID: 108
		[FixedBuffer(typeof(ushort), 16)]
		internal NetworkCompressionModel.<encodeTable>e__FixedBuffer encodeTable;

		// Token: 0x0400006D RID: 109
		[FixedBuffer(typeof(ushort), 64)]
		internal NetworkCompressionModel.<decodeTable>e__FixedBuffer decodeTable;

		// Token: 0x0400006E RID: 110
		[FixedBuffer(typeof(byte), 16)]
		internal NetworkCompressionModel.<bucketSizes>e__FixedBuffer bucketSizes;

		// Token: 0x0400006F RID: 111
		[FixedBuffer(typeof(uint), 16)]
		internal NetworkCompressionModel.<bucketOffsets>e__FixedBuffer bucketOffsets;

		// Token: 0x02000027 RID: 39
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 64)]
		public struct <bucketOffsets>e__FixedBuffer
		{
			// Token: 0x04000070 RID: 112
			public uint FixedElementField;
		}

		// Token: 0x02000028 RID: 40
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 16)]
		public struct <bucketSizes>e__FixedBuffer
		{
			// Token: 0x04000071 RID: 113
			public byte FixedElementField;
		}

		// Token: 0x02000029 RID: 41
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <decodeTable>e__FixedBuffer
		{
			// Token: 0x04000072 RID: 114
			public ushort FixedElementField;
		}

		// Token: 0x0200002A RID: 42
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 32)]
		public struct <encodeTable>e__FixedBuffer
		{
			// Token: 0x04000073 RID: 115
			public ushort FixedElementField;
		}
	}
}
