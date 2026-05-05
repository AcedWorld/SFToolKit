using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils
{
	// Token: 0x020004A1 RID: 1185
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EqualityComparerNoAlloc<T>
	{
		// Token: 0x17000B13 RID: 2835
		// (get) Token: 0x06003067 RID: 12391 RVA: 0x000A90E4 File Offset: 0x000A72E4
		public static IEqualityComparer<T> Default
		{
			get
			{
				Type typeFromHandle = typeof(T);
				if (typeFromHandle == typeof(int))
				{
					return (IEqualityComparer<T>)EqualityComparerNoAlloc<T>.EgvytknuzkqgAJaizkRZEYVTKeXL.wfalHBICkDfkyZdHmQkCunLCWaOX;
				}
				if (typeFromHandle == typeof(long))
				{
					return (IEqualityComparer<T>)EqualityComparerNoAlloc<T>.plHnBkOdRcDdLbxqDiiFvDmtELpnA.DhPirKMtyBhyGIdfzkHBmPbYigyh;
				}
				if (typeFromHandle == typeof(uint))
				{
					return (IEqualityComparer<T>)EqualityComparerNoAlloc<T>.vFJCgKEiZJAApeHVOqGvtezLNPcfA.xspWkNKdPIgVQtocGYjtZAaabbKU;
				}
				if (typeFromHandle == typeof(ulong))
				{
					return (IEqualityComparer<T>)EqualityComparerNoAlloc<T>.GaVWingDIIxojZNWLarfgOeHroFhb.UhhhanOvVsLjHckhFGhpaBGLuSQCA;
				}
				if (typeFromHandle == typeof(float))
				{
					return (IEqualityComparer<T>)EqualityComparerNoAlloc<T>.TOlODVGOFOQxMIDOJYsceltZtwBH.rkghzwqVmPrRuZRkuqqvpEvvLBcB;
				}
				if (typeFromHandle == typeof(double))
				{
					return (IEqualityComparer<T>)EqualityComparerNoAlloc<T>.SWCDEXeGEOHGLXRigkkpXIzkFSPG.UsgaakHmZluCatyWfwQwDvjuSWuV;
				}
				if (typeFromHandle == typeof(byte))
				{
					return (IEqualityComparer<T>)EqualityComparerNoAlloc<T>.SrhdromfNacHPeVuUKEtnfARmpCN.UhEqoGgQWPJJxCYzMppMqWNniqhv;
				}
				if (typeFromHandle == typeof(sbyte))
				{
					return (IEqualityComparer<T>)EqualityComparerNoAlloc<T>.JqBWotaEMiEyTTWJPeWtxWOrnTEk.hYCVGffsPplInWOEtHpokLkkvRdN;
				}
				if (typeFromHandle == typeof(bool))
				{
					return (IEqualityComparer<T>)EqualityComparerNoAlloc<T>.yPWZeQBoCxbsVBLCBaihlsayCklq.WiMeoydTdIcnKaKMQFOTcjAuJQZtA;
				}
				if (typeFromHandle == typeof(IntPtr))
				{
					return (IEqualityComparer<T>)EqualityComparerNoAlloc<T>.kxVEwhpiPhFsPrxaFZOhBXlHXIWF.UeenCWTtmiNwExNGQNcYZiejhJTp;
				}
				if (typeFromHandle == typeof(Guid))
				{
					return (IEqualityComparer<T>)EqualityComparerNoAlloc<T>.qRUrRpIkUYxDbfShnCEZqNBLZqhb.EUeSEbMPGKshdcazIObBSevluMzF;
				}
				if (typeFromHandle == typeof(Bytes20))
				{
					return (IEqualityComparer<T>)EqualityComparerNoAlloc<T>.FKmtrIBmDDTMsAfkZmPjAqLzYTSU.WlMmXIgIZuQAORQiPDomaERDkObm;
				}
				return EqualityComparer<T>.Default;
			}
		}

		// Token: 0x020004A2 RID: 1186
		private class EgvytknuzkqgAJaizkRZEYVTKeXL : IEqualityComparer, IEqualityComparer<int>
		{
			// Token: 0x17000B14 RID: 2836
			// (get) Token: 0x06003068 RID: 12392 RVA: 0x00024EEE File Offset: 0x000230EE
			public static EqualityComparerNoAlloc<\u0001>.EgvytknuzkqgAJaizkRZEYVTKeXL wfalHBICkDfkyZdHmQkCunLCWaOX
			{
				get
				{
					EqualityComparerNoAlloc<\u0001>.EgvytknuzkqgAJaizkRZEYVTKeXL result;
					if ((result = EqualityComparerNoAlloc<\u0001>.EgvytknuzkqgAJaizkRZEYVTKeXL.PPqTxfKHynCeegPNNXxSCZdyCMZO) == null)
					{
						result = (EqualityComparerNoAlloc<\u0001>.EgvytknuzkqgAJaizkRZEYVTKeXL.PPqTxfKHynCeegPNNXxSCZdyCMZO = new EqualityComparerNoAlloc<\u0001>.EgvytknuzkqgAJaizkRZEYVTKeXL());
					}
					return result;
				}
			}

			// Token: 0x06003069 RID: 12393 RVA: 0x00024F04 File Offset: 0x00023104
			public bool Equals(int x, int y)
			{
				return x == y;
			}

			// Token: 0x0600306A RID: 12394 RVA: 0x00024F0A File Offset: 0x0002310A
			public int GetHashCode(int obj)
			{
				return obj.GetHashCode();
			}

			// Token: 0x0600306B RID: 12395 RVA: 0x00024F13 File Offset: 0x00023113
			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					return y == null;
				}
				return x is int && y is int && this.Equals((int)x, (int)y);
			}

			// Token: 0x0600306C RID: 12396 RVA: 0x00024F43 File Offset: 0x00023143
			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is int))
				{
					return 0;
				}
				return this.GetHashCode((int)obj);
			}

			// Token: 0x04001A98 RID: 6808
			private static EqualityComparerNoAlloc<\u0001>.EgvytknuzkqgAJaizkRZEYVTKeXL PPqTxfKHynCeegPNNXxSCZdyCMZO;
		}

		// Token: 0x020004A3 RID: 1187
		private class plHnBkOdRcDdLbxqDiiFvDmtELpnA : IEqualityComparer, IEqualityComparer<ulong>
		{
			// Token: 0x17000B15 RID: 2837
			// (get) Token: 0x0600306E RID: 12398 RVA: 0x00024F5E File Offset: 0x0002315E
			public static EqualityComparerNoAlloc<\u0001>.plHnBkOdRcDdLbxqDiiFvDmtELpnA DhPirKMtyBhyGIdfzkHBmPbYigyh
			{
				get
				{
					EqualityComparerNoAlloc<\u0001>.plHnBkOdRcDdLbxqDiiFvDmtELpnA result;
					if ((result = EqualityComparerNoAlloc<\u0001>.plHnBkOdRcDdLbxqDiiFvDmtELpnA.lArtntkKTlvgSgWoMDIAZMpVuqhX) == null)
					{
						result = (EqualityComparerNoAlloc<\u0001>.plHnBkOdRcDdLbxqDiiFvDmtELpnA.lArtntkKTlvgSgWoMDIAZMpVuqhX = new EqualityComparerNoAlloc<\u0001>.plHnBkOdRcDdLbxqDiiFvDmtELpnA());
					}
					return result;
				}
			}

			// Token: 0x0600306F RID: 12399 RVA: 0x00024F04 File Offset: 0x00023104
			public bool Equals(ulong x, ulong y)
			{
				return x == y;
			}

			// Token: 0x06003070 RID: 12400 RVA: 0x00024F74 File Offset: 0x00023174
			public int GetHashCode(ulong obj)
			{
				return obj.GetHashCode();
			}

			// Token: 0x06003071 RID: 12401 RVA: 0x00024F7D File Offset: 0x0002317D
			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					return y == null;
				}
				return x is ulong && y is ulong && this.Equals((ulong)x, (ulong)y);
			}

			// Token: 0x06003072 RID: 12402 RVA: 0x00024FAD File Offset: 0x000231AD
			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is ulong))
				{
					return 0;
				}
				return this.GetHashCode((ulong)obj);
			}

			// Token: 0x04001A99 RID: 6809
			private static EqualityComparerNoAlloc<\u0001>.plHnBkOdRcDdLbxqDiiFvDmtELpnA lArtntkKTlvgSgWoMDIAZMpVuqhX;
		}

		// Token: 0x020004A4 RID: 1188
		private class vFJCgKEiZJAApeHVOqGvtezLNPcfA : IEqualityComparer, IEqualityComparer<uint>
		{
			// Token: 0x17000B16 RID: 2838
			// (get) Token: 0x06003074 RID: 12404 RVA: 0x00024FC8 File Offset: 0x000231C8
			public static EqualityComparerNoAlloc<\u0001>.vFJCgKEiZJAApeHVOqGvtezLNPcfA xspWkNKdPIgVQtocGYjtZAaabbKU
			{
				get
				{
					EqualityComparerNoAlloc<\u0001>.vFJCgKEiZJAApeHVOqGvtezLNPcfA result;
					if ((result = EqualityComparerNoAlloc<\u0001>.vFJCgKEiZJAApeHVOqGvtezLNPcfA.bvTsXnzBKcbQlkJnSbjZsqTxwQqH) == null)
					{
						result = (EqualityComparerNoAlloc<\u0001>.vFJCgKEiZJAApeHVOqGvtezLNPcfA.bvTsXnzBKcbQlkJnSbjZsqTxwQqH = new EqualityComparerNoAlloc<\u0001>.vFJCgKEiZJAApeHVOqGvtezLNPcfA());
					}
					return result;
				}
			}

			// Token: 0x06003075 RID: 12405 RVA: 0x00024F04 File Offset: 0x00023104
			public bool Equals(uint x, uint y)
			{
				return x == y;
			}

			// Token: 0x06003076 RID: 12406 RVA: 0x00024FDE File Offset: 0x000231DE
			public int GetHashCode(uint obj)
			{
				return obj.GetHashCode();
			}

			// Token: 0x06003077 RID: 12407 RVA: 0x00024FE7 File Offset: 0x000231E7
			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					return y == null;
				}
				return x is uint && y is uint && this.Equals((uint)x, (uint)y);
			}

			// Token: 0x06003078 RID: 12408 RVA: 0x00025017 File Offset: 0x00023217
			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is uint))
				{
					return 0;
				}
				return this.GetHashCode((uint)obj);
			}

			// Token: 0x04001A9A RID: 6810
			private static EqualityComparerNoAlloc<\u0001>.vFJCgKEiZJAApeHVOqGvtezLNPcfA bvTsXnzBKcbQlkJnSbjZsqTxwQqH;
		}

		// Token: 0x020004A5 RID: 1189
		private class GaVWingDIIxojZNWLarfgOeHroFhb : IEqualityComparer, IEqualityComparer<ulong>
		{
			// Token: 0x17000B17 RID: 2839
			// (get) Token: 0x0600307A RID: 12410 RVA: 0x00025032 File Offset: 0x00023232
			public static EqualityComparerNoAlloc<\u0001>.GaVWingDIIxojZNWLarfgOeHroFhb UhhhanOvVsLjHckhFGhpaBGLuSQCA
			{
				get
				{
					EqualityComparerNoAlloc<\u0001>.GaVWingDIIxojZNWLarfgOeHroFhb result;
					if ((result = EqualityComparerNoAlloc<\u0001>.GaVWingDIIxojZNWLarfgOeHroFhb.eLuriAIOFPEyDcGKiyUKVvCYIZsL) == null)
					{
						result = (EqualityComparerNoAlloc<\u0001>.GaVWingDIIxojZNWLarfgOeHroFhb.eLuriAIOFPEyDcGKiyUKVvCYIZsL = new EqualityComparerNoAlloc<\u0001>.GaVWingDIIxojZNWLarfgOeHroFhb());
					}
					return result;
				}
			}

			// Token: 0x0600307B RID: 12411 RVA: 0x00024F04 File Offset: 0x00023104
			public bool Equals(ulong x, ulong y)
			{
				return x == y;
			}

			// Token: 0x0600307C RID: 12412 RVA: 0x00024F74 File Offset: 0x00023174
			public int GetHashCode(ulong obj)
			{
				return obj.GetHashCode();
			}

			// Token: 0x0600307D RID: 12413 RVA: 0x00025048 File Offset: 0x00023248
			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					return y == null;
				}
				return x is ulong && y is ulong && this.Equals((ulong)x, (ulong)y);
			}

			// Token: 0x0600307E RID: 12414 RVA: 0x00025078 File Offset: 0x00023278
			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is ulong))
				{
					return 0;
				}
				return this.GetHashCode((ulong)obj);
			}

			// Token: 0x04001A9B RID: 6811
			private static EqualityComparerNoAlloc<\u0001>.GaVWingDIIxojZNWLarfgOeHroFhb eLuriAIOFPEyDcGKiyUKVvCYIZsL;
		}

		// Token: 0x020004A6 RID: 1190
		private class TOlODVGOFOQxMIDOJYsceltZtwBH : IEqualityComparer, IEqualityComparer<float>
		{
			// Token: 0x17000B18 RID: 2840
			// (get) Token: 0x06003080 RID: 12416 RVA: 0x00025093 File Offset: 0x00023293
			public static EqualityComparerNoAlloc<\u0001>.TOlODVGOFOQxMIDOJYsceltZtwBH rkghzwqVmPrRuZRkuqqvpEvvLBcB
			{
				get
				{
					EqualityComparerNoAlloc<\u0001>.TOlODVGOFOQxMIDOJYsceltZtwBH result;
					if ((result = EqualityComparerNoAlloc<\u0001>.TOlODVGOFOQxMIDOJYsceltZtwBH.toZnlvdJFADyoNGpillggeFWaqPb) == null)
					{
						result = (EqualityComparerNoAlloc<\u0001>.TOlODVGOFOQxMIDOJYsceltZtwBH.toZnlvdJFADyoNGpillggeFWaqPb = new EqualityComparerNoAlloc<\u0001>.TOlODVGOFOQxMIDOJYsceltZtwBH());
					}
					return result;
				}
			}

			// Token: 0x06003081 RID: 12417 RVA: 0x00024F04 File Offset: 0x00023104
			public bool Equals(float x, float y)
			{
				return x == y;
			}

			// Token: 0x06003082 RID: 12418 RVA: 0x000250A9 File Offset: 0x000232A9
			public int GetHashCode(float obj)
			{
				return obj.GetHashCode();
			}

			// Token: 0x06003083 RID: 12419 RVA: 0x000250B2 File Offset: 0x000232B2
			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					return y == null;
				}
				return x is float && y is float && this.Equals((float)x, (float)y);
			}

			// Token: 0x06003084 RID: 12420 RVA: 0x000250E2 File Offset: 0x000232E2
			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is float))
				{
					return 0;
				}
				return this.GetHashCode((float)obj);
			}

			// Token: 0x04001A9C RID: 6812
			private static EqualityComparerNoAlloc<\u0001>.TOlODVGOFOQxMIDOJYsceltZtwBH toZnlvdJFADyoNGpillggeFWaqPb;
		}

		// Token: 0x020004A7 RID: 1191
		private class SWCDEXeGEOHGLXRigkkpXIzkFSPG : IEqualityComparer, IEqualityComparer<double>
		{
			// Token: 0x17000B19 RID: 2841
			// (get) Token: 0x06003086 RID: 12422 RVA: 0x000250FD File Offset: 0x000232FD
			public static EqualityComparerNoAlloc<\u0001>.SWCDEXeGEOHGLXRigkkpXIzkFSPG UsgaakHmZluCatyWfwQwDvjuSWuV
			{
				get
				{
					EqualityComparerNoAlloc<\u0001>.SWCDEXeGEOHGLXRigkkpXIzkFSPG result;
					if ((result = EqualityComparerNoAlloc<\u0001>.SWCDEXeGEOHGLXRigkkpXIzkFSPG.RoqCXMfNGNKVpxgfAuYEIGOuMKfw) == null)
					{
						result = (EqualityComparerNoAlloc<\u0001>.SWCDEXeGEOHGLXRigkkpXIzkFSPG.RoqCXMfNGNKVpxgfAuYEIGOuMKfw = new EqualityComparerNoAlloc<\u0001>.SWCDEXeGEOHGLXRigkkpXIzkFSPG());
					}
					return result;
				}
			}

			// Token: 0x06003087 RID: 12423 RVA: 0x00024F04 File Offset: 0x00023104
			public bool Equals(double x, double y)
			{
				return x == y;
			}

			// Token: 0x06003088 RID: 12424 RVA: 0x00025113 File Offset: 0x00023313
			public int GetHashCode(double obj)
			{
				return obj.GetHashCode();
			}

			// Token: 0x06003089 RID: 12425 RVA: 0x0002511C File Offset: 0x0002331C
			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					return y == null;
				}
				return x is double && y is double && this.Equals((double)x, (double)y);
			}

			// Token: 0x0600308A RID: 12426 RVA: 0x0002514C File Offset: 0x0002334C
			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is double))
				{
					return 0;
				}
				return this.GetHashCode((double)obj);
			}

			// Token: 0x04001A9D RID: 6813
			private static EqualityComparerNoAlloc<\u0001>.SWCDEXeGEOHGLXRigkkpXIzkFSPG RoqCXMfNGNKVpxgfAuYEIGOuMKfw;
		}

		// Token: 0x020004A8 RID: 1192
		private class SrhdromfNacHPeVuUKEtnfARmpCN : IEqualityComparer, IEqualityComparer<byte>
		{
			// Token: 0x17000B1A RID: 2842
			// (get) Token: 0x0600308C RID: 12428 RVA: 0x00025167 File Offset: 0x00023367
			public static EqualityComparerNoAlloc<\u0001>.SrhdromfNacHPeVuUKEtnfARmpCN UhEqoGgQWPJJxCYzMppMqWNniqhv
			{
				get
				{
					EqualityComparerNoAlloc<\u0001>.SrhdromfNacHPeVuUKEtnfARmpCN result;
					if ((result = EqualityComparerNoAlloc<\u0001>.SrhdromfNacHPeVuUKEtnfARmpCN.nvIAJwGvjHGPCiqAkKHGWdJQzYLRb) == null)
					{
						result = (EqualityComparerNoAlloc<\u0001>.SrhdromfNacHPeVuUKEtnfARmpCN.nvIAJwGvjHGPCiqAkKHGWdJQzYLRb = new EqualityComparerNoAlloc<\u0001>.SrhdromfNacHPeVuUKEtnfARmpCN());
					}
					return result;
				}
			}

			// Token: 0x0600308D RID: 12429 RVA: 0x00024F04 File Offset: 0x00023104
			public bool Equals(byte x, byte y)
			{
				return x == y;
			}

			// Token: 0x0600308E RID: 12430 RVA: 0x0002517D File Offset: 0x0002337D
			public int GetHashCode(byte obj)
			{
				return obj.GetHashCode();
			}

			// Token: 0x0600308F RID: 12431 RVA: 0x00025186 File Offset: 0x00023386
			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					return y == null;
				}
				return x is byte && y is byte && this.Equals((byte)x, (byte)y);
			}

			// Token: 0x06003090 RID: 12432 RVA: 0x000251B6 File Offset: 0x000233B6
			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is byte))
				{
					return 0;
				}
				return this.GetHashCode((byte)obj);
			}

			// Token: 0x04001A9E RID: 6814
			private static EqualityComparerNoAlloc<\u0001>.SrhdromfNacHPeVuUKEtnfARmpCN nvIAJwGvjHGPCiqAkKHGWdJQzYLRb;
		}

		// Token: 0x020004A9 RID: 1193
		private class JqBWotaEMiEyTTWJPeWtxWOrnTEk : IEqualityComparer, IEqualityComparer<sbyte>
		{
			// Token: 0x17000B1B RID: 2843
			// (get) Token: 0x06003092 RID: 12434 RVA: 0x000251D1 File Offset: 0x000233D1
			public static EqualityComparerNoAlloc<\u0001>.JqBWotaEMiEyTTWJPeWtxWOrnTEk hYCVGffsPplInWOEtHpokLkkvRdN
			{
				get
				{
					EqualityComparerNoAlloc<\u0001>.JqBWotaEMiEyTTWJPeWtxWOrnTEk result;
					if ((result = EqualityComparerNoAlloc<\u0001>.JqBWotaEMiEyTTWJPeWtxWOrnTEk.lnlSWvDCFMqJmmRnkJWVnUqnpHRS) == null)
					{
						result = (EqualityComparerNoAlloc<\u0001>.JqBWotaEMiEyTTWJPeWtxWOrnTEk.lnlSWvDCFMqJmmRnkJWVnUqnpHRS = new EqualityComparerNoAlloc<\u0001>.JqBWotaEMiEyTTWJPeWtxWOrnTEk());
					}
					return result;
				}
			}

			// Token: 0x06003093 RID: 12435 RVA: 0x00024F04 File Offset: 0x00023104
			public bool Equals(sbyte x, sbyte y)
			{
				return x == y;
			}

			// Token: 0x06003094 RID: 12436 RVA: 0x000251E7 File Offset: 0x000233E7
			public int GetHashCode(sbyte obj)
			{
				return obj.GetHashCode();
			}

			// Token: 0x06003095 RID: 12437 RVA: 0x000251F0 File Offset: 0x000233F0
			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					return y == null;
				}
				return x is sbyte && y is sbyte && this.Equals((sbyte)x, (sbyte)y);
			}

			// Token: 0x06003096 RID: 12438 RVA: 0x00025220 File Offset: 0x00023420
			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is sbyte))
				{
					return 0;
				}
				return this.GetHashCode((sbyte)obj);
			}

			// Token: 0x04001A9F RID: 6815
			private static EqualityComparerNoAlloc<\u0001>.JqBWotaEMiEyTTWJPeWtxWOrnTEk lnlSWvDCFMqJmmRnkJWVnUqnpHRS;
		}

		// Token: 0x020004AA RID: 1194
		private class yPWZeQBoCxbsVBLCBaihlsayCklq : IEqualityComparer, IEqualityComparer<bool>
		{
			// Token: 0x17000B1C RID: 2844
			// (get) Token: 0x06003098 RID: 12440 RVA: 0x0002523B File Offset: 0x0002343B
			public static EqualityComparerNoAlloc<\u0001>.yPWZeQBoCxbsVBLCBaihlsayCklq WiMeoydTdIcnKaKMQFOTcjAuJQZtA
			{
				get
				{
					EqualityComparerNoAlloc<\u0001>.yPWZeQBoCxbsVBLCBaihlsayCklq result;
					if ((result = EqualityComparerNoAlloc<\u0001>.yPWZeQBoCxbsVBLCBaihlsayCklq.tjiZHaCRyGCUrcKNSyZlmjuoUscfA) == null)
					{
						result = (EqualityComparerNoAlloc<\u0001>.yPWZeQBoCxbsVBLCBaihlsayCklq.tjiZHaCRyGCUrcKNSyZlmjuoUscfA = new EqualityComparerNoAlloc<\u0001>.yPWZeQBoCxbsVBLCBaihlsayCklq());
					}
					return result;
				}
			}

			// Token: 0x06003099 RID: 12441 RVA: 0x00024F04 File Offset: 0x00023104
			public bool Equals(bool x, bool y)
			{
				return x == y;
			}

			// Token: 0x0600309A RID: 12442 RVA: 0x00025251 File Offset: 0x00023451
			public int GetHashCode(bool obj)
			{
				return obj.GetHashCode();
			}

			// Token: 0x0600309B RID: 12443 RVA: 0x0002525A File Offset: 0x0002345A
			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					return y == null;
				}
				return x is bool && y is bool && this.Equals((bool)x, (bool)y);
			}

			// Token: 0x0600309C RID: 12444 RVA: 0x0002528A File Offset: 0x0002348A
			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is bool))
				{
					return 0;
				}
				return this.GetHashCode((bool)obj);
			}

			// Token: 0x04001AA0 RID: 6816
			private static EqualityComparerNoAlloc<\u0001>.yPWZeQBoCxbsVBLCBaihlsayCklq tjiZHaCRyGCUrcKNSyZlmjuoUscfA;
		}

		// Token: 0x020004AB RID: 1195
		private class kxVEwhpiPhFsPrxaFZOhBXlHXIWF : IEqualityComparer, IEqualityComparer<IntPtr>
		{
			// Token: 0x17000B1D RID: 2845
			// (get) Token: 0x0600309E RID: 12446 RVA: 0x000252A5 File Offset: 0x000234A5
			public static EqualityComparerNoAlloc<\u0001>.kxVEwhpiPhFsPrxaFZOhBXlHXIWF UeenCWTtmiNwExNGQNcYZiejhJTp
			{
				get
				{
					EqualityComparerNoAlloc<\u0001>.kxVEwhpiPhFsPrxaFZOhBXlHXIWF result;
					if ((result = EqualityComparerNoAlloc<\u0001>.kxVEwhpiPhFsPrxaFZOhBXlHXIWF.mZiNDVqLIlrgqJpUPvAKKKoQcWYK) == null)
					{
						result = (EqualityComparerNoAlloc<\u0001>.kxVEwhpiPhFsPrxaFZOhBXlHXIWF.mZiNDVqLIlrgqJpUPvAKKKoQcWYK = new EqualityComparerNoAlloc<\u0001>.kxVEwhpiPhFsPrxaFZOhBXlHXIWF());
					}
					return result;
				}
			}

			// Token: 0x0600309F RID: 12447 RVA: 0x000252BB File Offset: 0x000234BB
			public bool Equals(IntPtr x, IntPtr y)
			{
				return x == y;
			}

			// Token: 0x060030A0 RID: 12448 RVA: 0x000252C4 File Offset: 0x000234C4
			public int GetHashCode(IntPtr obj)
			{
				return obj.GetHashCode();
			}

			// Token: 0x060030A1 RID: 12449 RVA: 0x000252CD File Offset: 0x000234CD
			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					return y == null;
				}
				return x is IntPtr && y is IntPtr && this.Equals((IntPtr)x, (IntPtr)y);
			}

			// Token: 0x060030A2 RID: 12450 RVA: 0x000252FD File Offset: 0x000234FD
			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is IntPtr))
				{
					return 0;
				}
				return this.GetHashCode((IntPtr)obj);
			}

			// Token: 0x04001AA1 RID: 6817
			private static EqualityComparerNoAlloc<\u0001>.kxVEwhpiPhFsPrxaFZOhBXlHXIWF mZiNDVqLIlrgqJpUPvAKKKoQcWYK;
		}

		// Token: 0x020004AC RID: 1196
		private class qRUrRpIkUYxDbfShnCEZqNBLZqhb : IEqualityComparer, IEqualityComparer<Guid>
		{
			// Token: 0x17000B1E RID: 2846
			// (get) Token: 0x060030A4 RID: 12452 RVA: 0x00025318 File Offset: 0x00023518
			public static EqualityComparerNoAlloc<\u0001>.qRUrRpIkUYxDbfShnCEZqNBLZqhb EUeSEbMPGKshdcazIObBSevluMzF
			{
				get
				{
					EqualityComparerNoAlloc<\u0001>.qRUrRpIkUYxDbfShnCEZqNBLZqhb result;
					if ((result = EqualityComparerNoAlloc<\u0001>.qRUrRpIkUYxDbfShnCEZqNBLZqhb.DOtDEgJqFMswmafAKAhfCgeZkgru) == null)
					{
						result = (EqualityComparerNoAlloc<\u0001>.qRUrRpIkUYxDbfShnCEZqNBLZqhb.DOtDEgJqFMswmafAKAhfCgeZkgru = new EqualityComparerNoAlloc<\u0001>.qRUrRpIkUYxDbfShnCEZqNBLZqhb());
					}
					return result;
				}
			}

			// Token: 0x060030A5 RID: 12453 RVA: 0x0002532E File Offset: 0x0002352E
			public bool Equals(Guid x, Guid y)
			{
				return x == y;
			}

			// Token: 0x060030A6 RID: 12454 RVA: 0x00025337 File Offset: 0x00023537
			public int GetHashCode(Guid obj)
			{
				return obj.GetHashCode();
			}

			// Token: 0x060030A7 RID: 12455 RVA: 0x00025346 File Offset: 0x00023546
			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					return y == null;
				}
				return x is Guid && y is Guid && this.Equals((Guid)x, (Guid)y);
			}

			// Token: 0x060030A8 RID: 12456 RVA: 0x00025376 File Offset: 0x00023576
			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is Guid))
				{
					return 0;
				}
				return this.GetHashCode((Guid)obj);
			}

			// Token: 0x04001AA2 RID: 6818
			private static EqualityComparerNoAlloc<\u0001>.qRUrRpIkUYxDbfShnCEZqNBLZqhb DOtDEgJqFMswmafAKAhfCgeZkgru;
		}

		// Token: 0x020004AD RID: 1197
		private class FKmtrIBmDDTMsAfkZmPjAqLzYTSU : IEqualityComparer, IEqualityComparer<Bytes20>
		{
			// Token: 0x17000B1F RID: 2847
			// (get) Token: 0x060030AA RID: 12458 RVA: 0x00025391 File Offset: 0x00023591
			public static EqualityComparerNoAlloc<\u0001>.FKmtrIBmDDTMsAfkZmPjAqLzYTSU WlMmXIgIZuQAORQiPDomaERDkObm
			{
				get
				{
					EqualityComparerNoAlloc<\u0001>.FKmtrIBmDDTMsAfkZmPjAqLzYTSU result;
					if ((result = EqualityComparerNoAlloc<\u0001>.FKmtrIBmDDTMsAfkZmPjAqLzYTSU.blVNXgcopqQcGIaomzuIMaXaDSMe) == null)
					{
						result = (EqualityComparerNoAlloc<\u0001>.FKmtrIBmDDTMsAfkZmPjAqLzYTSU.blVNXgcopqQcGIaomzuIMaXaDSMe = new EqualityComparerNoAlloc<\u0001>.FKmtrIBmDDTMsAfkZmPjAqLzYTSU());
					}
					return result;
				}
			}

			// Token: 0x060030AB RID: 12459 RVA: 0x000253A7 File Offset: 0x000235A7
			public bool Equals(Bytes20 x, Bytes20 y)
			{
				return x == y;
			}

			// Token: 0x060030AC RID: 12460 RVA: 0x000253B0 File Offset: 0x000235B0
			public int GetHashCode(Bytes20 obj)
			{
				return obj.GetHashCode();
			}

			// Token: 0x060030AD RID: 12461 RVA: 0x000253BF File Offset: 0x000235BF
			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					return y == null;
				}
				return x is Bytes20 && y is Bytes20 && this.Equals((Bytes20)x, (Bytes20)y);
			}

			// Token: 0x060030AE RID: 12462 RVA: 0x000253EF File Offset: 0x000235EF
			int IEqualityComparer.GetHashCode(object obj)
			{
				if (obj == null || !(obj is Bytes20))
				{
					return 0;
				}
				return this.GetHashCode((Bytes20)obj);
			}

			// Token: 0x04001AA3 RID: 6819
			private static EqualityComparerNoAlloc<\u0001>.FKmtrIBmDDTMsAfkZmPjAqLzYTSU blVNXgcopqQcGIaomzuIMaXaDSMe;
		}
	}
}
