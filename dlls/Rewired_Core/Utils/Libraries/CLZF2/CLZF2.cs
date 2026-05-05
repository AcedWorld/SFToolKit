using System;

namespace Rewired.Utils.Libraries.CLZF2
{
	// Token: 0x020004B2 RID: 1202
	public sealed class CLZF2
	{
		// Token: 0x060030BB RID: 12475 RVA: 0x000A93F4 File Offset: 0x000A75F4
		public byte[] Compress(byte[] inputBytes)
		{
			int num = inputBytes.Length * 2;
			byte[] src = new byte[num];
			int num2;
			for (num2 = this.NeYgVSHSyhMQVqVbedcWwrBQpOpU(inputBytes, ref src); num2 == 0; num2 = this.NeYgVSHSyhMQVqVbedcWwrBQpOpU(inputBytes, ref src))
			{
				num *= 2;
				src = new byte[num];
			}
			byte[] array = new byte[num2];
			Buffer.BlockCopy(src, 0, array, 0, num2);
			return array;
		}

		// Token: 0x060030BC RID: 12476 RVA: 0x000A9444 File Offset: 0x000A7644
		public byte[] Decompress(byte[] inputBytes)
		{
			int num = inputBytes.Length * 2;
			byte[] array = new byte[num];
			CLZF2.XbnCohxCQFmRZmMjLieOTUhhelXkA xbnCohxCQFmRZmMjLieOTUhhelXkA;
			int num2 = this.QaCPJcQQiJhqCBppMtvudnSekVpIA(inputBytes, array, out xbnCohxCQFmRZmMjLieOTUhhelXkA);
			while (num2 == 0 && xbnCohxCQFmRZmMjLieOTUhhelXkA == CLZF2.XbnCohxCQFmRZmMjLieOTUhhelXkA.OutputBufferTooSmall)
			{
				num *= 2;
				array = new byte[num];
				num2 = this.QaCPJcQQiJhqCBppMtvudnSekVpIA(inputBytes, array, out xbnCohxCQFmRZmMjLieOTUhhelXkA);
			}
			if (xbnCohxCQFmRZmMjLieOTUhhelXkA == CLZF2.XbnCohxCQFmRZmMjLieOTUhhelXkA.Success)
			{
				byte[] array2 = new byte[num2];
				Buffer.BlockCopy(array, 0, array2, 0, num2);
				return array2;
			}
			return new byte[0];
		}

		// Token: 0x060030BD RID: 12477 RVA: 0x000A94A8 File Offset: 0x000A76A8
		private int NeYgVSHSyhMQVqVbedcWwrBQpOpU(byte[] A_1, ref byte[] A_2)
		{
			int num = A_1.Length;
			int num2 = A_2.Length;
			Array.Clear(this.BUrGlWybGOjAsofztyrbuDxJDyTW, 0, 16384);
			uint num3 = 0U;
			uint num4 = 0U;
			uint num5 = (uint)((int)A_1[(int)num3] << 8 | (int)A_1[(int)(num3 + 1U)]);
			int num6 = 0;
			for (;;)
			{
				if ((ulong)num3 < (ulong)((long)(num - 2)))
				{
					num5 = (num5 << 8 | (uint)A_1[(int)(num3 + 2U)]);
					long num7 = (long)((ulong)((num5 ^ num5 << 5) >> (int)(10U - num5 * 5U) & 16383U));
					long num8 = this.BUrGlWybGOjAsofztyrbuDxJDyTW[(int)(checked((IntPtr)num7))];
					this.BUrGlWybGOjAsofztyrbuDxJDyTW[(int)(checked((IntPtr)num7))] = (long)((ulong)num3);
					long num9;
					if ((num9 = (long)((ulong)num3 - (ulong)num8 - 1UL)) < 8192L && (ulong)(num3 + 4U) < (ulong)((long)num) && num8 > 0L && A_1[(int)(checked((IntPtr)num8))] == A_1[(int)num3] && A_1[(int)(checked((IntPtr)(unchecked(num8 + 1L))))] == A_1[(int)(num3 + 1U)] && A_1[(int)(checked((IntPtr)(unchecked(num8 + 2L))))] == A_1[(int)(num3 + 2U)])
					{
						uint num10 = 2U;
						uint num11 = (uint)(num - (int)num3 - (int)num10);
						num11 = ((num11 > 264U) ? 264U : num11);
						if ((ulong)num4 + (ulong)((long)num6) + 1UL + 3UL >= (ulong)((long)num2))
						{
							break;
						}
						do
						{
							num10 += 1U;
						}
						while (num10 < num11 && A_1[(int)(checked((IntPtr)(unchecked(num8 + (long)((ulong)num10)))))] == A_1[(int)(num3 + num10)]);
						if (num6 != 0)
						{
							A_2[(int)num4++] = (byte)(num6 - 1);
							num6 = -num6;
							do
							{
								A_2[(int)num4++] = A_1[(int)(checked((IntPtr)(unchecked((ulong)num3 + (ulong)((long)num6)))))];
							}
							while (++num6 != 0);
						}
						num10 -= 2U;
						num3 += 1U;
						if (num10 < 7U)
						{
							A_2[(int)num4++] = (byte)((num9 >> 8) + (long)((ulong)((ulong)num10 << 5)));
						}
						else
						{
							A_2[(int)num4++] = (byte)((num9 >> 8) + 224L);
							A_2[(int)num4++] = (byte)(num10 - 7U);
						}
						A_2[(int)num4++] = (byte)num9;
						num3 += num10 - 1U;
						num5 = (uint)((int)A_1[(int)num3] << 8 | (int)A_1[(int)(num3 + 1U)]);
						num5 = (num5 << 8 | (uint)A_1[(int)(num3 + 2U)]);
						this.BUrGlWybGOjAsofztyrbuDxJDyTW[(int)((num5 ^ num5 << 5) >> (int)(10U - num5 * 5U) & 16383U)] = (long)((ulong)num3);
						num3 += 1U;
						num5 = (num5 << 8 | (uint)A_1[(int)(num3 + 2U)]);
						this.BUrGlWybGOjAsofztyrbuDxJDyTW[(int)((num5 ^ num5 << 5) >> (int)(10U - num5 * 5U) & 16383U)] = (long)((ulong)num3);
						num3 += 1U;
						continue;
					}
				}
				else if ((ulong)num3 == (ulong)((long)num))
				{
					goto IL_282;
				}
				num6++;
				num3 += 1U;
				if ((long)num6 == 32L)
				{
					if ((ulong)(num4 + 1U + 32U) >= (ulong)((long)num2))
					{
						return 0;
					}
					A_2[(int)num4++] = 31;
					num6 = -num6;
					do
					{
						A_2[(int)num4++] = A_1[(int)(checked((IntPtr)(unchecked((ulong)num3 + (ulong)((long)num6)))))];
					}
					while (++num6 != 0);
				}
			}
			return 0;
			IL_282:
			if (num6 != 0)
			{
				if ((ulong)num4 + (ulong)((long)num6) + 1UL >= (ulong)((long)num2))
				{
					return 0;
				}
				A_2[(int)num4++] = (byte)(num6 - 1);
				num6 = -num6;
				do
				{
					A_2[(int)num4++] = A_1[(int)(checked((IntPtr)(unchecked((ulong)num3 + (ulong)((long)num6)))))];
				}
				while (++num6 != 0);
			}
			return (int)num4;
		}

		// Token: 0x060030BE RID: 12478 RVA: 0x000A9780 File Offset: 0x000A7980
		private int QaCPJcQQiJhqCBppMtvudnSekVpIA(byte[] A_1, byte[] A_2, out CLZF2.XbnCohxCQFmRZmMjLieOTUhhelXkA A_3)
		{
			int num = A_1.Length;
			int num2 = A_2.Length;
			uint num3 = 0U;
			uint num4 = 0U;
			for (;;)
			{
				uint num5 = (uint)A_1[(int)num3++];
				if (num5 < 32U)
				{
					num5 += 1U;
					if ((ulong)(num4 + num5) > (ulong)((long)num2))
					{
						break;
					}
					do
					{
						A_2[(int)num4++] = A_1[(int)num3++];
					}
					while ((num5 -= 1U) != 0U);
				}
				else
				{
					uint num6 = num5 >> 5;
					int num7 = (int)(num4 - ((num5 & 31U) << 8) - 1U);
					if (num6 == 7U)
					{
						num6 += (uint)A_1[(int)num3++];
					}
					num7 -= (int)A_1[(int)num3++];
					if ((ulong)(num4 + num6 + 2U) > (ulong)((long)num2))
					{
						goto Block_5;
					}
					if (num7 < 0)
					{
						goto Block_6;
					}
					A_2[(int)num4++] = A_2[num7++];
					A_2[(int)num4++] = A_2[num7++];
					do
					{
						A_2[(int)num4++] = A_2[num7++];
					}
					while ((num6 -= 1U) != 0U);
				}
				if ((ulong)num3 >= (ulong)((long)num))
				{
					goto Block_7;
				}
			}
			A_3 = CLZF2.XbnCohxCQFmRZmMjLieOTUhhelXkA.OutputBufferTooSmall;
			return 0;
			Block_5:
			A_3 = CLZF2.XbnCohxCQFmRZmMjLieOTUhhelXkA.OutputBufferTooSmall;
			return 0;
			Block_6:
			A_3 = CLZF2.XbnCohxCQFmRZmMjLieOTUhhelXkA.Einval;
			return 0;
			Block_7:
			A_3 = ((num4 > 0U) ? CLZF2.XbnCohxCQFmRZmMjLieOTUhhelXkA.Success : CLZF2.XbnCohxCQFmRZmMjLieOTUhhelXkA.ZeroSize);
			return (int)num4;
		}

		// Token: 0x04001AAC RID: 6828
		private const uint nkOsGwdgRvltFyyXzsCAfEsCYuEN = 14U;

		// Token: 0x04001AAD RID: 6829
		private const uint YqTMlfBKMQBFOdnwqNcvbgJFZrzfA = 16384U;

		// Token: 0x04001AAE RID: 6830
		private const uint QHebAGJBGeUhcDaKjjJKNbpadrLAA = 32U;

		// Token: 0x04001AAF RID: 6831
		private const uint DidUrCoNOdzPigoOHFwDBHihDawc = 8192U;

		// Token: 0x04001AB0 RID: 6832
		private const uint LGsJmtLHTNFZgDUtSCxkkvTkfgfIb = 264U;

		// Token: 0x04001AB1 RID: 6833
		private readonly long[] BUrGlWybGOjAsofztyrbuDxJDyTW = new long[16384];

		// Token: 0x020004B3 RID: 1203
		private enum XbnCohxCQFmRZmMjLieOTUhhelXkA
		{
			// Token: 0x04001AB3 RID: 6835
			Success,
			// Token: 0x04001AB4 RID: 6836
			OutputBufferTooSmall,
			// Token: 0x04001AB5 RID: 6837
			Einval,
			// Token: 0x04001AB6 RID: 6838
			ZeroSize
		}
	}
}
