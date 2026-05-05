using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Unity.Networking.Transport
{
	// Token: 0x02000079 RID: 121
	internal static class SHA256
	{
		// Token: 0x0200007A RID: 122
		internal struct SHA256State
		{
			// Token: 0x06000219 RID: 537 RVA: 0x0000B788 File Offset: 0x00009988
			public unsafe static SHA256.SHA256State Create()
			{
				SHA256.SHA256State result = default(SHA256.SHA256State);
				result.state.FixedElementField = 1779033703U;
				*(ref result.state.FixedElementField + 4) = 3144134277U;
				*(ref result.state.FixedElementField + (IntPtr)2 * 4) = 1013904242U;
				*(ref result.state.FixedElementField + (IntPtr)3 * 4) = 2773480762U;
				*(ref result.state.FixedElementField + (IntPtr)4 * 4) = 1359893119U;
				*(ref result.state.FixedElementField + (IntPtr)5 * 4) = 2600822924U;
				*(ref result.state.FixedElementField + (IntPtr)6 * 4) = 528734635U;
				*(ref result.state.FixedElementField + (IntPtr)7 * 4) = 1541459225U;
				return result;
			}

			// Token: 0x0600021A RID: 538 RVA: 0x0000B850 File Offset: 0x00009A50
			public unsafe void Update(byte* data, int length)
			{
				ulong num = this.count & 63UL;
				while (length > 0)
				{
					ulong num2 = num;
					num = num2 + 1UL;
					*(ref this.buffer.FixedElementField + (UIntPtr)num2) = *(data++);
					this.count += 1UL;
					length--;
					if (num == 64UL)
					{
						num = 0UL;
						this.WriteByteBlock();
					}
				}
			}

			// Token: 0x0600021B RID: 539 RVA: 0x0000B8AC File Offset: 0x00009AAC
			public unsafe void Final(byte* dest)
			{
				ulong num = this.count << 3;
				uint num2 = (uint)(this.count & 63UL);
				*(ref this.buffer.FixedElementField + (UIntPtr)(num2++)) = 128;
				while (num2 != 56U)
				{
					num2 &= 63U;
					if (num2 == 0U)
					{
						this.WriteByteBlock();
					}
					*(ref this.buffer.FixedElementField + (UIntPtr)(num2++)) = 0;
				}
				for (int i = 0; i < 8; i++)
				{
					*(ref this.buffer.FixedElementField + (UIntPtr)(num2++)) = (byte)(num >> 56);
					num <<= 8;
				}
				this.WriteByteBlock();
				for (int j = 0; j < 8; j++)
				{
					*(dest++) = (byte)(*(ref this.state.FixedElementField + (IntPtr)j * 4) >> 24);
					*(dest++) = (byte)(*(ref this.state.FixedElementField + (IntPtr)j * 4) >> 16);
					*(dest++) = (byte)(*(ref this.state.FixedElementField + (IntPtr)j * 4) >> 8);
					*(dest++) = (byte)(*(ref this.state.FixedElementField + (IntPtr)j * 4));
				}
			}

			// Token: 0x0600021C RID: 540 RVA: 0x0000B9B8 File Offset: 0x00009BB8
			private unsafe void WriteByteBlock()
			{
				uint* ptr = stackalloc uint[(UIntPtr)64];
				for (int i = 0; i < 16; i++)
				{
					ptr[i] = (uint)(((int)(*(ref this.buffer.FixedElementField + i * 4)) << 24) + ((int)(*(ref this.buffer.FixedElementField + (i * 4 + 1))) << 16) + ((int)(*(ref this.buffer.FixedElementField + (i * 4 + 2))) << 8) + (int)(*(ref this.buffer.FixedElementField + (i * 4 + 3))));
				}
				this.Transform(ptr);
			}

			// Token: 0x0600021D RID: 541 RVA: 0x0000BA38 File Offset: 0x00009C38
			private unsafe void Transform(uint* data)
			{
				uint* ptr = stackalloc uint[(UIntPtr)64];
				uint* ptr2 = stackalloc uint[(UIntPtr)32];
				for (int i = 0; i < 8; i++)
				{
					ptr2[i] = *(ref this.state.FixedElementField + (IntPtr)i * 4);
				}
				for (int j = 0; j < 64; j += 16)
				{
					for (int k = 0; k < 16; k++)
					{
						ptr2[7 - k & 7] += SHA256.SHA256State.<Transform>g__S1|8_2(ptr2[4 - k & 7]) + SHA256.SHA256State.<Transform>g__Ch|8_5(ptr2[4 - k & 7], ptr2[5 - k & 7], ptr2[6 - k & 7]) + SHA256.SHA256State.K[k + j] + ((j != 0) ? (ptr[k & 15] += SHA256.SHA256State.<Transform>g__s1|8_4(ptr[k - 2 & 15]) + ptr[k - 7 & 15] + SHA256.SHA256State.<Transform>g__s0|8_3(ptr[k - 15 & 15])) : (ptr[k] = data[k]));
						ptr2[3 - k & 7] += ptr2[7 - k & 7];
						ptr2[7 - k & 7] += SHA256.SHA256State.<Transform>g__S0|8_1(ptr2[0 - k & 7]) + SHA256.SHA256State.<Transform>g__Maj|8_6(ptr2[0 - k & 7], ptr2[1 - k & 7], ptr2[2 - k & 7]);
					}
				}
				for (int l = 0; l < 8; l++)
				{
					*(ref this.state.FixedElementField + (IntPtr)l * 4) += ptr2[l];
				}
			}

			// Token: 0x0600021F RID: 543 RVA: 0x0000BC02 File Offset: 0x00009E02
			[CompilerGenerated]
			internal static uint <Transform>g__ROTR32|8_0(uint x, byte n)
			{
				return x << (int)(32 - n) | x >> (int)n;
			}

			// Token: 0x06000220 RID: 544 RVA: 0x0000BC14 File Offset: 0x00009E14
			[CompilerGenerated]
			internal static uint <Transform>g__S0|8_1(uint x)
			{
				return SHA256.SHA256State.<Transform>g__ROTR32|8_0(x, 2) ^ SHA256.SHA256State.<Transform>g__ROTR32|8_0(x, 13) ^ SHA256.SHA256State.<Transform>g__ROTR32|8_0(x, 22);
			}

			// Token: 0x06000221 RID: 545 RVA: 0x0000BC2F File Offset: 0x00009E2F
			[CompilerGenerated]
			internal static uint <Transform>g__S1|8_2(uint x)
			{
				return SHA256.SHA256State.<Transform>g__ROTR32|8_0(x, 6) ^ SHA256.SHA256State.<Transform>g__ROTR32|8_0(x, 11) ^ SHA256.SHA256State.<Transform>g__ROTR32|8_0(x, 25);
			}

			// Token: 0x06000222 RID: 546 RVA: 0x0000BC4A File Offset: 0x00009E4A
			[CompilerGenerated]
			internal static uint <Transform>g__s0|8_3(uint x)
			{
				return SHA256.SHA256State.<Transform>g__ROTR32|8_0(x, 7) ^ SHA256.SHA256State.<Transform>g__ROTR32|8_0(x, 18) ^ x >> 3;
			}

			// Token: 0x06000223 RID: 547 RVA: 0x0000BC60 File Offset: 0x00009E60
			[CompilerGenerated]
			internal static uint <Transform>g__s1|8_4(uint x)
			{
				return SHA256.SHA256State.<Transform>g__ROTR32|8_0(x, 17) ^ SHA256.SHA256State.<Transform>g__ROTR32|8_0(x, 19) ^ x >> 10;
			}

			// Token: 0x06000224 RID: 548 RVA: 0x0000BC78 File Offset: 0x00009E78
			[CompilerGenerated]
			internal static uint <Transform>g__Ch|8_5(uint x, uint y, uint z)
			{
				return z ^ (x & (y ^ z));
			}

			// Token: 0x06000225 RID: 549 RVA: 0x0000BC81 File Offset: 0x00009E81
			[CompilerGenerated]
			internal static uint <Transform>g__Maj|8_6(uint x, uint y, uint z)
			{
				return (x & y) | (z & (x | y));
			}

			// Token: 0x04000190 RID: 400
			[FixedBuffer(typeof(uint), 8)]
			public SHA256.SHA256State.<state>e__FixedBuffer state;

			// Token: 0x04000191 RID: 401
			[FixedBuffer(typeof(byte), 64)]
			public SHA256.SHA256State.<buffer>e__FixedBuffer buffer;

			// Token: 0x04000192 RID: 402
			private ulong count;

			// Token: 0x04000193 RID: 403
			private static readonly uint[] K = new uint[]
			{
				1116352408U,
				1899447441U,
				3049323471U,
				3921009573U,
				961987163U,
				1508970993U,
				2453635748U,
				2870763221U,
				3624381080U,
				310598401U,
				607225278U,
				1426881987U,
				1925078388U,
				2162078206U,
				2614888103U,
				3248222580U,
				3835390401U,
				4022224774U,
				264347078U,
				604807628U,
				770255983U,
				1249150122U,
				1555081692U,
				1996064986U,
				2554220882U,
				2821834349U,
				2952996808U,
				3210313671U,
				3336571891U,
				3584528711U,
				113926993U,
				338241895U,
				666307205U,
				773529912U,
				1294757372U,
				1396182291U,
				1695183700U,
				1986661051U,
				2177026350U,
				2456956037U,
				2730485921U,
				2820302411U,
				3259730800U,
				3345764771U,
				3516065817U,
				3600352804U,
				4094571909U,
				275423344U,
				430227734U,
				506948616U,
				659060556U,
				883997877U,
				958139571U,
				1322822218U,
				1537002063U,
				1747873779U,
				1955562222U,
				2024104815U,
				2227730452U,
				2361852424U,
				2428436474U,
				2756734187U,
				3204031479U,
				3329325298U
			};

			// Token: 0x0200007B RID: 123
			[CompilerGenerated]
			[UnsafeValueType]
			[StructLayout(LayoutKind.Sequential, Size = 64)]
			public struct <buffer>e__FixedBuffer
			{
				// Token: 0x04000194 RID: 404
				public byte FixedElementField;
			}

			// Token: 0x0200007C RID: 124
			[CompilerGenerated]
			[UnsafeValueType]
			[StructLayout(LayoutKind.Sequential, Size = 32)]
			public struct <state>e__FixedBuffer
			{
				// Token: 0x04000195 RID: 405
				public uint FixedElementField;
			}
		}
	}
}
