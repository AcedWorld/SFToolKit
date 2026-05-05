using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x0200002B RID: 43
	[DebuggerTypeProxy(typeof(half3.DebuggerProxy))]
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct half3 : IEquatable<half3>, IFormattable
	{
		// Token: 0x060015DB RID: 5595 RVA: 0x0003E6C6 File Offset: 0x0003C8C6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half3(half x, half y, half z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		// Token: 0x060015DC RID: 5596 RVA: 0x0003E6DD File Offset: 0x0003C8DD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half3(half x, half2 yz)
		{
			this.x = x;
			this.y = yz.x;
			this.z = yz.y;
		}

		// Token: 0x060015DD RID: 5597 RVA: 0x0003E6FE File Offset: 0x0003C8FE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half3(half2 xy, half z)
		{
			this.x = xy.x;
			this.y = xy.y;
			this.z = z;
		}

		// Token: 0x060015DE RID: 5598 RVA: 0x0003E71F File Offset: 0x0003C91F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half3(half3 xyz)
		{
			this.x = xyz.x;
			this.y = xyz.y;
			this.z = xyz.z;
		}

		// Token: 0x060015DF RID: 5599 RVA: 0x0003E745 File Offset: 0x0003C945
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half3(half v)
		{
			this.x = v;
			this.y = v;
			this.z = v;
		}

		// Token: 0x060015E0 RID: 5600 RVA: 0x0003E75C File Offset: 0x0003C95C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half3(float v)
		{
			this.x = (half)v;
			this.y = (half)v;
			this.z = (half)v;
		}

		// Token: 0x060015E1 RID: 5601 RVA: 0x0003E782 File Offset: 0x0003C982
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half3(float3 v)
		{
			this.x = (half)v.x;
			this.y = (half)v.y;
			this.z = (half)v.z;
		}

		// Token: 0x060015E2 RID: 5602 RVA: 0x0003E7B7 File Offset: 0x0003C9B7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half3(double v)
		{
			this.x = (half)v;
			this.y = (half)v;
			this.z = (half)v;
		}

		// Token: 0x060015E3 RID: 5603 RVA: 0x0003E7DD File Offset: 0x0003C9DD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half3(double3 v)
		{
			this.x = (half)v.x;
			this.y = (half)v.y;
			this.z = (half)v.z;
		}

		// Token: 0x060015E4 RID: 5604 RVA: 0x0003E812 File Offset: 0x0003CA12
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator half3(half v)
		{
			return new half3(v);
		}

		// Token: 0x060015E5 RID: 5605 RVA: 0x0003E81A File Offset: 0x0003CA1A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator half3(float v)
		{
			return new half3(v);
		}

		// Token: 0x060015E6 RID: 5606 RVA: 0x0003E822 File Offset: 0x0003CA22
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator half3(float3 v)
		{
			return new half3(v);
		}

		// Token: 0x060015E7 RID: 5607 RVA: 0x0003E82A File Offset: 0x0003CA2A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator half3(double v)
		{
			return new half3(v);
		}

		// Token: 0x060015E8 RID: 5608 RVA: 0x0003E832 File Offset: 0x0003CA32
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator half3(double3 v)
		{
			return new half3(v);
		}

		// Token: 0x060015E9 RID: 5609 RVA: 0x0003E83A File Offset: 0x0003CA3A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator ==(half3 lhs, half3 rhs)
		{
			return new bool3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);
		}

		// Token: 0x060015EA RID: 5610 RVA: 0x0003E874 File Offset: 0x0003CA74
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator ==(half3 lhs, half rhs)
		{
			return new bool3(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs);
		}

		// Token: 0x060015EB RID: 5611 RVA: 0x0003E89F File Offset: 0x0003CA9F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator ==(half lhs, half3 rhs)
		{
			return new bool3(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z);
		}

		// Token: 0x060015EC RID: 5612 RVA: 0x0003E8CA File Offset: 0x0003CACA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator !=(half3 lhs, half3 rhs)
		{
			return new bool3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z);
		}

		// Token: 0x060015ED RID: 5613 RVA: 0x0003E904 File Offset: 0x0003CB04
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator !=(half3 lhs, half rhs)
		{
			return new bool3(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs);
		}

		// Token: 0x060015EE RID: 5614 RVA: 0x0003E92F File Offset: 0x0003CB2F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator !=(half lhs, half3 rhs)
		{
			return new bool3(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z);
		}

		// Token: 0x170005E9 RID: 1513
		// (get) Token: 0x060015EF RID: 5615 RVA: 0x0003E95A File Offset: 0x0003CB5A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.x, this.x);
			}
		}

		// Token: 0x170005EA RID: 1514
		// (get) Token: 0x060015F0 RID: 5616 RVA: 0x0003E979 File Offset: 0x0003CB79
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.x, this.y);
			}
		}

		// Token: 0x170005EB RID: 1515
		// (get) Token: 0x060015F1 RID: 5617 RVA: 0x0003E998 File Offset: 0x0003CB98
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.x, this.z);
			}
		}

		// Token: 0x170005EC RID: 1516
		// (get) Token: 0x060015F2 RID: 5618 RVA: 0x0003E9B7 File Offset: 0x0003CBB7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.y, this.x);
			}
		}

		// Token: 0x170005ED RID: 1517
		// (get) Token: 0x060015F3 RID: 5619 RVA: 0x0003E9D6 File Offset: 0x0003CBD6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.y, this.y);
			}
		}

		// Token: 0x170005EE RID: 1518
		// (get) Token: 0x060015F4 RID: 5620 RVA: 0x0003E9F5 File Offset: 0x0003CBF5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.y, this.z);
			}
		}

		// Token: 0x170005EF RID: 1519
		// (get) Token: 0x060015F5 RID: 5621 RVA: 0x0003EA14 File Offset: 0x0003CC14
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.z, this.x);
			}
		}

		// Token: 0x170005F0 RID: 1520
		// (get) Token: 0x060015F6 RID: 5622 RVA: 0x0003EA33 File Offset: 0x0003CC33
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.z, this.y);
			}
		}

		// Token: 0x170005F1 RID: 1521
		// (get) Token: 0x060015F7 RID: 5623 RVA: 0x0003EA52 File Offset: 0x0003CC52
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.z, this.z);
			}
		}

		// Token: 0x170005F2 RID: 1522
		// (get) Token: 0x060015F8 RID: 5624 RVA: 0x0003EA71 File Offset: 0x0003CC71
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.x, this.x);
			}
		}

		// Token: 0x170005F3 RID: 1523
		// (get) Token: 0x060015F9 RID: 5625 RVA: 0x0003EA90 File Offset: 0x0003CC90
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.x, this.y);
			}
		}

		// Token: 0x170005F4 RID: 1524
		// (get) Token: 0x060015FA RID: 5626 RVA: 0x0003EAAF File Offset: 0x0003CCAF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.x, this.z);
			}
		}

		// Token: 0x170005F5 RID: 1525
		// (get) Token: 0x060015FB RID: 5627 RVA: 0x0003EACE File Offset: 0x0003CCCE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.y, this.x);
			}
		}

		// Token: 0x170005F6 RID: 1526
		// (get) Token: 0x060015FC RID: 5628 RVA: 0x0003EAED File Offset: 0x0003CCED
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.y, this.y);
			}
		}

		// Token: 0x170005F7 RID: 1527
		// (get) Token: 0x060015FD RID: 5629 RVA: 0x0003EB0C File Offset: 0x0003CD0C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.y, this.z);
			}
		}

		// Token: 0x170005F8 RID: 1528
		// (get) Token: 0x060015FE RID: 5630 RVA: 0x0003EB2B File Offset: 0x0003CD2B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.z, this.x);
			}
		}

		// Token: 0x170005F9 RID: 1529
		// (get) Token: 0x060015FF RID: 5631 RVA: 0x0003EB4A File Offset: 0x0003CD4A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.z, this.y);
			}
		}

		// Token: 0x170005FA RID: 1530
		// (get) Token: 0x06001600 RID: 5632 RVA: 0x0003EB69 File Offset: 0x0003CD69
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.z, this.z);
			}
		}

		// Token: 0x170005FB RID: 1531
		// (get) Token: 0x06001601 RID: 5633 RVA: 0x0003EB88 File Offset: 0x0003CD88
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.x, this.x);
			}
		}

		// Token: 0x170005FC RID: 1532
		// (get) Token: 0x06001602 RID: 5634 RVA: 0x0003EBA7 File Offset: 0x0003CDA7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.x, this.y);
			}
		}

		// Token: 0x170005FD RID: 1533
		// (get) Token: 0x06001603 RID: 5635 RVA: 0x0003EBC6 File Offset: 0x0003CDC6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.x, this.z);
			}
		}

		// Token: 0x170005FE RID: 1534
		// (get) Token: 0x06001604 RID: 5636 RVA: 0x0003EBE5 File Offset: 0x0003CDE5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.y, this.x);
			}
		}

		// Token: 0x170005FF RID: 1535
		// (get) Token: 0x06001605 RID: 5637 RVA: 0x0003EC04 File Offset: 0x0003CE04
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.y, this.y);
			}
		}

		// Token: 0x17000600 RID: 1536
		// (get) Token: 0x06001606 RID: 5638 RVA: 0x0003EC23 File Offset: 0x0003CE23
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.y, this.z);
			}
		}

		// Token: 0x17000601 RID: 1537
		// (get) Token: 0x06001607 RID: 5639 RVA: 0x0003EC42 File Offset: 0x0003CE42
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.z, this.x);
			}
		}

		// Token: 0x17000602 RID: 1538
		// (get) Token: 0x06001608 RID: 5640 RVA: 0x0003EC61 File Offset: 0x0003CE61
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.z, this.y);
			}
		}

		// Token: 0x17000603 RID: 1539
		// (get) Token: 0x06001609 RID: 5641 RVA: 0x0003EC80 File Offset: 0x0003CE80
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.z, this.z);
			}
		}

		// Token: 0x17000604 RID: 1540
		// (get) Token: 0x0600160A RID: 5642 RVA: 0x0003EC9F File Offset: 0x0003CE9F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.x, this.x);
			}
		}

		// Token: 0x17000605 RID: 1541
		// (get) Token: 0x0600160B RID: 5643 RVA: 0x0003ECBE File Offset: 0x0003CEBE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.x, this.y);
			}
		}

		// Token: 0x17000606 RID: 1542
		// (get) Token: 0x0600160C RID: 5644 RVA: 0x0003ECDD File Offset: 0x0003CEDD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.x, this.z);
			}
		}

		// Token: 0x17000607 RID: 1543
		// (get) Token: 0x0600160D RID: 5645 RVA: 0x0003ECFC File Offset: 0x0003CEFC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.y, this.x);
			}
		}

		// Token: 0x17000608 RID: 1544
		// (get) Token: 0x0600160E RID: 5646 RVA: 0x0003ED1B File Offset: 0x0003CF1B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.y, this.y);
			}
		}

		// Token: 0x17000609 RID: 1545
		// (get) Token: 0x0600160F RID: 5647 RVA: 0x0003ED3A File Offset: 0x0003CF3A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.y, this.z);
			}
		}

		// Token: 0x1700060A RID: 1546
		// (get) Token: 0x06001610 RID: 5648 RVA: 0x0003ED59 File Offset: 0x0003CF59
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.z, this.x);
			}
		}

		// Token: 0x1700060B RID: 1547
		// (get) Token: 0x06001611 RID: 5649 RVA: 0x0003ED78 File Offset: 0x0003CF78
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.z, this.y);
			}
		}

		// Token: 0x1700060C RID: 1548
		// (get) Token: 0x06001612 RID: 5650 RVA: 0x0003ED97 File Offset: 0x0003CF97
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.z, this.z);
			}
		}

		// Token: 0x1700060D RID: 1549
		// (get) Token: 0x06001613 RID: 5651 RVA: 0x0003EDB6 File Offset: 0x0003CFB6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.x, this.x);
			}
		}

		// Token: 0x1700060E RID: 1550
		// (get) Token: 0x06001614 RID: 5652 RVA: 0x0003EDD5 File Offset: 0x0003CFD5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.x, this.y);
			}
		}

		// Token: 0x1700060F RID: 1551
		// (get) Token: 0x06001615 RID: 5653 RVA: 0x0003EDF4 File Offset: 0x0003CFF4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.x, this.z);
			}
		}

		// Token: 0x17000610 RID: 1552
		// (get) Token: 0x06001616 RID: 5654 RVA: 0x0003EE13 File Offset: 0x0003D013
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.y, this.x);
			}
		}

		// Token: 0x17000611 RID: 1553
		// (get) Token: 0x06001617 RID: 5655 RVA: 0x0003EE32 File Offset: 0x0003D032
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.y, this.y);
			}
		}

		// Token: 0x17000612 RID: 1554
		// (get) Token: 0x06001618 RID: 5656 RVA: 0x0003EE51 File Offset: 0x0003D051
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.y, this.z);
			}
		}

		// Token: 0x17000613 RID: 1555
		// (get) Token: 0x06001619 RID: 5657 RVA: 0x0003EE70 File Offset: 0x0003D070
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.z, this.x);
			}
		}

		// Token: 0x17000614 RID: 1556
		// (get) Token: 0x0600161A RID: 5658 RVA: 0x0003EE8F File Offset: 0x0003D08F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.z, this.y);
			}
		}

		// Token: 0x17000615 RID: 1557
		// (get) Token: 0x0600161B RID: 5659 RVA: 0x0003EEAE File Offset: 0x0003D0AE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.z, this.z);
			}
		}

		// Token: 0x17000616 RID: 1558
		// (get) Token: 0x0600161C RID: 5660 RVA: 0x0003EECD File Offset: 0x0003D0CD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.x, this.x);
			}
		}

		// Token: 0x17000617 RID: 1559
		// (get) Token: 0x0600161D RID: 5661 RVA: 0x0003EEEC File Offset: 0x0003D0EC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.x, this.y);
			}
		}

		// Token: 0x17000618 RID: 1560
		// (get) Token: 0x0600161E RID: 5662 RVA: 0x0003EF0B File Offset: 0x0003D10B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.x, this.z);
			}
		}

		// Token: 0x17000619 RID: 1561
		// (get) Token: 0x0600161F RID: 5663 RVA: 0x0003EF2A File Offset: 0x0003D12A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.y, this.x);
			}
		}

		// Token: 0x1700061A RID: 1562
		// (get) Token: 0x06001620 RID: 5664 RVA: 0x0003EF49 File Offset: 0x0003D149
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.y, this.y);
			}
		}

		// Token: 0x1700061B RID: 1563
		// (get) Token: 0x06001621 RID: 5665 RVA: 0x0003EF68 File Offset: 0x0003D168
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.y, this.z);
			}
		}

		// Token: 0x1700061C RID: 1564
		// (get) Token: 0x06001622 RID: 5666 RVA: 0x0003EF87 File Offset: 0x0003D187
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.z, this.x);
			}
		}

		// Token: 0x1700061D RID: 1565
		// (get) Token: 0x06001623 RID: 5667 RVA: 0x0003EFA6 File Offset: 0x0003D1A6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.z, this.y);
			}
		}

		// Token: 0x1700061E RID: 1566
		// (get) Token: 0x06001624 RID: 5668 RVA: 0x0003EFC5 File Offset: 0x0003D1C5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.z, this.z);
			}
		}

		// Token: 0x1700061F RID: 1567
		// (get) Token: 0x06001625 RID: 5669 RVA: 0x0003EFE4 File Offset: 0x0003D1E4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.x, this.x);
			}
		}

		// Token: 0x17000620 RID: 1568
		// (get) Token: 0x06001626 RID: 5670 RVA: 0x0003F003 File Offset: 0x0003D203
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.x, this.y);
			}
		}

		// Token: 0x17000621 RID: 1569
		// (get) Token: 0x06001627 RID: 5671 RVA: 0x0003F022 File Offset: 0x0003D222
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.x, this.z);
			}
		}

		// Token: 0x17000622 RID: 1570
		// (get) Token: 0x06001628 RID: 5672 RVA: 0x0003F041 File Offset: 0x0003D241
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.y, this.x);
			}
		}

		// Token: 0x17000623 RID: 1571
		// (get) Token: 0x06001629 RID: 5673 RVA: 0x0003F060 File Offset: 0x0003D260
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.y, this.y);
			}
		}

		// Token: 0x17000624 RID: 1572
		// (get) Token: 0x0600162A RID: 5674 RVA: 0x0003F07F File Offset: 0x0003D27F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.y, this.z);
			}
		}

		// Token: 0x17000625 RID: 1573
		// (get) Token: 0x0600162B RID: 5675 RVA: 0x0003F09E File Offset: 0x0003D29E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.z, this.x);
			}
		}

		// Token: 0x17000626 RID: 1574
		// (get) Token: 0x0600162C RID: 5676 RVA: 0x0003F0BD File Offset: 0x0003D2BD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.z, this.y);
			}
		}

		// Token: 0x17000627 RID: 1575
		// (get) Token: 0x0600162D RID: 5677 RVA: 0x0003F0DC File Offset: 0x0003D2DC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.z, this.z);
			}
		}

		// Token: 0x17000628 RID: 1576
		// (get) Token: 0x0600162E RID: 5678 RVA: 0x0003F0FB File Offset: 0x0003D2FB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.x, this.x);
			}
		}

		// Token: 0x17000629 RID: 1577
		// (get) Token: 0x0600162F RID: 5679 RVA: 0x0003F11A File Offset: 0x0003D31A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.x, this.y);
			}
		}

		// Token: 0x1700062A RID: 1578
		// (get) Token: 0x06001630 RID: 5680 RVA: 0x0003F139 File Offset: 0x0003D339
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.x, this.z);
			}
		}

		// Token: 0x1700062B RID: 1579
		// (get) Token: 0x06001631 RID: 5681 RVA: 0x0003F158 File Offset: 0x0003D358
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.y, this.x);
			}
		}

		// Token: 0x1700062C RID: 1580
		// (get) Token: 0x06001632 RID: 5682 RVA: 0x0003F177 File Offset: 0x0003D377
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.y, this.y);
			}
		}

		// Token: 0x1700062D RID: 1581
		// (get) Token: 0x06001633 RID: 5683 RVA: 0x0003F196 File Offset: 0x0003D396
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.y, this.z);
			}
		}

		// Token: 0x1700062E RID: 1582
		// (get) Token: 0x06001634 RID: 5684 RVA: 0x0003F1B5 File Offset: 0x0003D3B5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.z, this.x);
			}
		}

		// Token: 0x1700062F RID: 1583
		// (get) Token: 0x06001635 RID: 5685 RVA: 0x0003F1D4 File Offset: 0x0003D3D4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.z, this.y);
			}
		}

		// Token: 0x17000630 RID: 1584
		// (get) Token: 0x06001636 RID: 5686 RVA: 0x0003F1F3 File Offset: 0x0003D3F3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.z, this.z);
			}
		}

		// Token: 0x17000631 RID: 1585
		// (get) Token: 0x06001637 RID: 5687 RVA: 0x0003F212 File Offset: 0x0003D412
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.x, this.x);
			}
		}

		// Token: 0x17000632 RID: 1586
		// (get) Token: 0x06001638 RID: 5688 RVA: 0x0003F231 File Offset: 0x0003D431
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.x, this.y);
			}
		}

		// Token: 0x17000633 RID: 1587
		// (get) Token: 0x06001639 RID: 5689 RVA: 0x0003F250 File Offset: 0x0003D450
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.x, this.z);
			}
		}

		// Token: 0x17000634 RID: 1588
		// (get) Token: 0x0600163A RID: 5690 RVA: 0x0003F26F File Offset: 0x0003D46F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.y, this.x);
			}
		}

		// Token: 0x17000635 RID: 1589
		// (get) Token: 0x0600163B RID: 5691 RVA: 0x0003F28E File Offset: 0x0003D48E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.y, this.y);
			}
		}

		// Token: 0x17000636 RID: 1590
		// (get) Token: 0x0600163C RID: 5692 RVA: 0x0003F2AD File Offset: 0x0003D4AD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.y, this.z);
			}
		}

		// Token: 0x17000637 RID: 1591
		// (get) Token: 0x0600163D RID: 5693 RVA: 0x0003F2CC File Offset: 0x0003D4CC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.z, this.x);
			}
		}

		// Token: 0x17000638 RID: 1592
		// (get) Token: 0x0600163E RID: 5694 RVA: 0x0003F2EB File Offset: 0x0003D4EB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.z, this.y);
			}
		}

		// Token: 0x17000639 RID: 1593
		// (get) Token: 0x0600163F RID: 5695 RVA: 0x0003F30A File Offset: 0x0003D50A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.z, this.z);
			}
		}

		// Token: 0x1700063A RID: 1594
		// (get) Token: 0x06001640 RID: 5696 RVA: 0x0003F329 File Offset: 0x0003D529
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.x, this.x);
			}
		}

		// Token: 0x1700063B RID: 1595
		// (get) Token: 0x06001641 RID: 5697 RVA: 0x0003F342 File Offset: 0x0003D542
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.x, this.y);
			}
		}

		// Token: 0x1700063C RID: 1596
		// (get) Token: 0x06001642 RID: 5698 RVA: 0x0003F35B File Offset: 0x0003D55B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.x, this.z);
			}
		}

		// Token: 0x1700063D RID: 1597
		// (get) Token: 0x06001643 RID: 5699 RVA: 0x0003F374 File Offset: 0x0003D574
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.y, this.x);
			}
		}

		// Token: 0x1700063E RID: 1598
		// (get) Token: 0x06001644 RID: 5700 RVA: 0x0003F38D File Offset: 0x0003D58D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.y, this.y);
			}
		}

		// Token: 0x1700063F RID: 1599
		// (get) Token: 0x06001645 RID: 5701 RVA: 0x0003F3A6 File Offset: 0x0003D5A6
		// (set) Token: 0x06001646 RID: 5702 RVA: 0x0003F3BF File Offset: 0x0003D5BF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x17000640 RID: 1600
		// (get) Token: 0x06001647 RID: 5703 RVA: 0x0003F3E5 File Offset: 0x0003D5E5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.z, this.x);
			}
		}

		// Token: 0x17000641 RID: 1601
		// (get) Token: 0x06001648 RID: 5704 RVA: 0x0003F3FE File Offset: 0x0003D5FE
		// (set) Token: 0x06001649 RID: 5705 RVA: 0x0003F417 File Offset: 0x0003D617
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x17000642 RID: 1602
		// (get) Token: 0x0600164A RID: 5706 RVA: 0x0003F43D File Offset: 0x0003D63D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.z, this.z);
			}
		}

		// Token: 0x17000643 RID: 1603
		// (get) Token: 0x0600164B RID: 5707 RVA: 0x0003F456 File Offset: 0x0003D656
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.x, this.x);
			}
		}

		// Token: 0x17000644 RID: 1604
		// (get) Token: 0x0600164C RID: 5708 RVA: 0x0003F46F File Offset: 0x0003D66F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.x, this.y);
			}
		}

		// Token: 0x17000645 RID: 1605
		// (get) Token: 0x0600164D RID: 5709 RVA: 0x0003F488 File Offset: 0x0003D688
		// (set) Token: 0x0600164E RID: 5710 RVA: 0x0003F4A1 File Offset: 0x0003D6A1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x17000646 RID: 1606
		// (get) Token: 0x0600164F RID: 5711 RVA: 0x0003F4C7 File Offset: 0x0003D6C7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.y, this.x);
			}
		}

		// Token: 0x17000647 RID: 1607
		// (get) Token: 0x06001650 RID: 5712 RVA: 0x0003F4E0 File Offset: 0x0003D6E0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.y, this.y);
			}
		}

		// Token: 0x17000648 RID: 1608
		// (get) Token: 0x06001651 RID: 5713 RVA: 0x0003F4F9 File Offset: 0x0003D6F9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.y, this.z);
			}
		}

		// Token: 0x17000649 RID: 1609
		// (get) Token: 0x06001652 RID: 5714 RVA: 0x0003F512 File Offset: 0x0003D712
		// (set) Token: 0x06001653 RID: 5715 RVA: 0x0003F52B File Offset: 0x0003D72B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x1700064A RID: 1610
		// (get) Token: 0x06001654 RID: 5716 RVA: 0x0003F551 File Offset: 0x0003D751
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.z, this.y);
			}
		}

		// Token: 0x1700064B RID: 1611
		// (get) Token: 0x06001655 RID: 5717 RVA: 0x0003F56A File Offset: 0x0003D76A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.z, this.z);
			}
		}

		// Token: 0x1700064C RID: 1612
		// (get) Token: 0x06001656 RID: 5718 RVA: 0x0003F583 File Offset: 0x0003D783
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.x, this.x);
			}
		}

		// Token: 0x1700064D RID: 1613
		// (get) Token: 0x06001657 RID: 5719 RVA: 0x0003F59C File Offset: 0x0003D79C
		// (set) Token: 0x06001658 RID: 5720 RVA: 0x0003F5B5 File Offset: 0x0003D7B5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x1700064E RID: 1614
		// (get) Token: 0x06001659 RID: 5721 RVA: 0x0003F5DB File Offset: 0x0003D7DB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.x, this.z);
			}
		}

		// Token: 0x1700064F RID: 1615
		// (get) Token: 0x0600165A RID: 5722 RVA: 0x0003F5F4 File Offset: 0x0003D7F4
		// (set) Token: 0x0600165B RID: 5723 RVA: 0x0003F60D File Offset: 0x0003D80D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x17000650 RID: 1616
		// (get) Token: 0x0600165C RID: 5724 RVA: 0x0003F633 File Offset: 0x0003D833
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.y, this.y);
			}
		}

		// Token: 0x17000651 RID: 1617
		// (get) Token: 0x0600165D RID: 5725 RVA: 0x0003F64C File Offset: 0x0003D84C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.y, this.z);
			}
		}

		// Token: 0x17000652 RID: 1618
		// (get) Token: 0x0600165E RID: 5726 RVA: 0x0003F665 File Offset: 0x0003D865
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.z, this.x);
			}
		}

		// Token: 0x17000653 RID: 1619
		// (get) Token: 0x0600165F RID: 5727 RVA: 0x0003F67E File Offset: 0x0003D87E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.z, this.y);
			}
		}

		// Token: 0x17000654 RID: 1620
		// (get) Token: 0x06001660 RID: 5728 RVA: 0x0003F697 File Offset: 0x0003D897
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.z, this.z);
			}
		}

		// Token: 0x17000655 RID: 1621
		// (get) Token: 0x06001661 RID: 5729 RVA: 0x0003F6B0 File Offset: 0x0003D8B0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.x, this.x);
			}
		}

		// Token: 0x17000656 RID: 1622
		// (get) Token: 0x06001662 RID: 5730 RVA: 0x0003F6C3 File Offset: 0x0003D8C3
		// (set) Token: 0x06001663 RID: 5731 RVA: 0x0003F6D6 File Offset: 0x0003D8D6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 xy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x17000657 RID: 1623
		// (get) Token: 0x06001664 RID: 5732 RVA: 0x0003F6F0 File Offset: 0x0003D8F0
		// (set) Token: 0x06001665 RID: 5733 RVA: 0x0003F703 File Offset: 0x0003D903
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 xz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
			}
		}

		// Token: 0x17000658 RID: 1624
		// (get) Token: 0x06001666 RID: 5734 RVA: 0x0003F71D File Offset: 0x0003D91D
		// (set) Token: 0x06001667 RID: 5735 RVA: 0x0003F730 File Offset: 0x0003D930
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 yx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x17000659 RID: 1625
		// (get) Token: 0x06001668 RID: 5736 RVA: 0x0003F74A File Offset: 0x0003D94A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 yy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.y, this.y);
			}
		}

		// Token: 0x1700065A RID: 1626
		// (get) Token: 0x06001669 RID: 5737 RVA: 0x0003F75D File Offset: 0x0003D95D
		// (set) Token: 0x0600166A RID: 5738 RVA: 0x0003F770 File Offset: 0x0003D970
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 yz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
			}
		}

		// Token: 0x1700065B RID: 1627
		// (get) Token: 0x0600166B RID: 5739 RVA: 0x0003F78A File Offset: 0x0003D98A
		// (set) Token: 0x0600166C RID: 5740 RVA: 0x0003F79D File Offset: 0x0003D99D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 zx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x1700065C RID: 1628
		// (get) Token: 0x0600166D RID: 5741 RVA: 0x0003F7B7 File Offset: 0x0003D9B7
		// (set) Token: 0x0600166E RID: 5742 RVA: 0x0003F7CA File Offset: 0x0003D9CA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 zy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x1700065D RID: 1629
		// (get) Token: 0x0600166F RID: 5743 RVA: 0x0003F7E4 File Offset: 0x0003D9E4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 zz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.z, this.z);
			}
		}

		// Token: 0x1700065E RID: 1630
		public unsafe half this[int index]
		{
			get
			{
				fixed (half3* ptr = &this)
				{
					return ((half*)ptr)[index];
				}
			}
			set
			{
				fixed (half* ptr = &this.x)
				{
					ptr[index] = value;
				}
			}
		}

		// Token: 0x06001672 RID: 5746 RVA: 0x0003F841 File Offset: 0x0003DA41
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(half3 rhs)
		{
			return this.x == rhs.x && this.y == rhs.y && this.z == rhs.z;
		}

		// Token: 0x06001673 RID: 5747 RVA: 0x0003F87C File Offset: 0x0003DA7C
		public override bool Equals(object o)
		{
			if (o is half3)
			{
				half3 rhs = (half3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06001674 RID: 5748 RVA: 0x0003F8A1 File Offset: 0x0003DAA1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06001675 RID: 5749 RVA: 0x0003F8AE File Offset: 0x0003DAAE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("half3({0}, {1}, {2})", this.x, this.y, this.z);
		}

		// Token: 0x06001676 RID: 5750 RVA: 0x0003F8DB File Offset: 0x0003DADB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("half3({0}, {1}, {2})", this.x.ToString(format, formatProvider), this.y.ToString(format, formatProvider), this.z.ToString(format, formatProvider));
		}

		// Token: 0x040000A6 RID: 166
		public half x;

		// Token: 0x040000A7 RID: 167
		public half y;

		// Token: 0x040000A8 RID: 168
		public half z;

		// Token: 0x040000A9 RID: 169
		public static readonly half3 zero;

		// Token: 0x0200005E RID: 94
		internal sealed class DebuggerProxy
		{
			// Token: 0x06002473 RID: 9331 RVA: 0x000676A4 File Offset: 0x000658A4
			public DebuggerProxy(half3 v)
			{
				this.x = v.x;
				this.y = v.y;
				this.z = v.z;
			}

			// Token: 0x04000157 RID: 343
			public half x;

			// Token: 0x04000158 RID: 344
			public half y;

			// Token: 0x04000159 RID: 345
			public half z;
		}
	}
}
