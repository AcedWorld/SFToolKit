using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x0200002C RID: 44
	[DebuggerTypeProxy(typeof(half4.DebuggerProxy))]
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct half4 : IEquatable<half4>, IFormattable
	{
		// Token: 0x06001677 RID: 5751 RVA: 0x0003F90E File Offset: 0x0003DB0E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half4(half x, half y, half z, half w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		// Token: 0x06001678 RID: 5752 RVA: 0x0003F92D File Offset: 0x0003DB2D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half4(half x, half y, half2 zw)
		{
			this.x = x;
			this.y = y;
			this.z = zw.x;
			this.w = zw.y;
		}

		// Token: 0x06001679 RID: 5753 RVA: 0x0003F955 File Offset: 0x0003DB55
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half4(half x, half2 yz, half w)
		{
			this.x = x;
			this.y = yz.x;
			this.z = yz.y;
			this.w = w;
		}

		// Token: 0x0600167A RID: 5754 RVA: 0x0003F97D File Offset: 0x0003DB7D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half4(half x, half3 yzw)
		{
			this.x = x;
			this.y = yzw.x;
			this.z = yzw.y;
			this.w = yzw.z;
		}

		// Token: 0x0600167B RID: 5755 RVA: 0x0003F9AA File Offset: 0x0003DBAA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half4(half2 xy, half z, half w)
		{
			this.x = xy.x;
			this.y = xy.y;
			this.z = z;
			this.w = w;
		}

		// Token: 0x0600167C RID: 5756 RVA: 0x0003F9D2 File Offset: 0x0003DBD2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half4(half2 xy, half2 zw)
		{
			this.x = xy.x;
			this.y = xy.y;
			this.z = zw.x;
			this.w = zw.y;
		}

		// Token: 0x0600167D RID: 5757 RVA: 0x0003FA04 File Offset: 0x0003DC04
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half4(half3 xyz, half w)
		{
			this.x = xyz.x;
			this.y = xyz.y;
			this.z = xyz.z;
			this.w = w;
		}

		// Token: 0x0600167E RID: 5758 RVA: 0x0003FA31 File Offset: 0x0003DC31
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half4(half4 xyzw)
		{
			this.x = xyzw.x;
			this.y = xyzw.y;
			this.z = xyzw.z;
			this.w = xyzw.w;
		}

		// Token: 0x0600167F RID: 5759 RVA: 0x0003FA63 File Offset: 0x0003DC63
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half4(half v)
		{
			this.x = v;
			this.y = v;
			this.z = v;
			this.w = v;
		}

		// Token: 0x06001680 RID: 5760 RVA: 0x0003FA81 File Offset: 0x0003DC81
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half4(float v)
		{
			this.x = (half)v;
			this.y = (half)v;
			this.z = (half)v;
			this.w = (half)v;
		}

		// Token: 0x06001681 RID: 5761 RVA: 0x0003FAB4 File Offset: 0x0003DCB4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half4(float4 v)
		{
			this.x = (half)v.x;
			this.y = (half)v.y;
			this.z = (half)v.z;
			this.w = (half)v.w;
		}

		// Token: 0x06001682 RID: 5762 RVA: 0x0003FB05 File Offset: 0x0003DD05
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half4(double v)
		{
			this.x = (half)v;
			this.y = (half)v;
			this.z = (half)v;
			this.w = (half)v;
		}

		// Token: 0x06001683 RID: 5763 RVA: 0x0003FB38 File Offset: 0x0003DD38
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half4(double4 v)
		{
			this.x = (half)v.x;
			this.y = (half)v.y;
			this.z = (half)v.z;
			this.w = (half)v.w;
		}

		// Token: 0x06001684 RID: 5764 RVA: 0x0003FB89 File Offset: 0x0003DD89
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator half4(half v)
		{
			return new half4(v);
		}

		// Token: 0x06001685 RID: 5765 RVA: 0x0003FB91 File Offset: 0x0003DD91
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator half4(float v)
		{
			return new half4(v);
		}

		// Token: 0x06001686 RID: 5766 RVA: 0x0003FB99 File Offset: 0x0003DD99
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator half4(float4 v)
		{
			return new half4(v);
		}

		// Token: 0x06001687 RID: 5767 RVA: 0x0003FBA1 File Offset: 0x0003DDA1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator half4(double v)
		{
			return new half4(v);
		}

		// Token: 0x06001688 RID: 5768 RVA: 0x0003FBA9 File Offset: 0x0003DDA9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator half4(double4 v)
		{
			return new half4(v);
		}

		// Token: 0x06001689 RID: 5769 RVA: 0x0003FBB4 File Offset: 0x0003DDB4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator ==(half4 lhs, half4 rhs)
		{
			return new bool4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);
		}

		// Token: 0x0600168A RID: 5770 RVA: 0x0003FC0A File Offset: 0x0003DE0A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator ==(half4 lhs, half rhs)
		{
			return new bool4(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs, lhs.w == rhs);
		}

		// Token: 0x0600168B RID: 5771 RVA: 0x0003FC41 File Offset: 0x0003DE41
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator ==(half lhs, half4 rhs)
		{
			return new bool4(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z, lhs == rhs.w);
		}

		// Token: 0x0600168C RID: 5772 RVA: 0x0003FC78 File Offset: 0x0003DE78
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator !=(half4 lhs, half4 rhs)
		{
			return new bool4(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w);
		}

		// Token: 0x0600168D RID: 5773 RVA: 0x0003FCCE File Offset: 0x0003DECE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator !=(half4 lhs, half rhs)
		{
			return new bool4(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs, lhs.w != rhs);
		}

		// Token: 0x0600168E RID: 5774 RVA: 0x0003FD05 File Offset: 0x0003DF05
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator !=(half lhs, half4 rhs)
		{
			return new bool4(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z, lhs != rhs.w);
		}

		// Token: 0x1700065F RID: 1631
		// (get) Token: 0x0600168F RID: 5775 RVA: 0x0003FD3C File Offset: 0x0003DF3C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.x, this.x);
			}
		}

		// Token: 0x17000660 RID: 1632
		// (get) Token: 0x06001690 RID: 5776 RVA: 0x0003FD5B File Offset: 0x0003DF5B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.x, this.y);
			}
		}

		// Token: 0x17000661 RID: 1633
		// (get) Token: 0x06001691 RID: 5777 RVA: 0x0003FD7A File Offset: 0x0003DF7A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.x, this.z);
			}
		}

		// Token: 0x17000662 RID: 1634
		// (get) Token: 0x06001692 RID: 5778 RVA: 0x0003FD99 File Offset: 0x0003DF99
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.x, this.w);
			}
		}

		// Token: 0x17000663 RID: 1635
		// (get) Token: 0x06001693 RID: 5779 RVA: 0x0003FDB8 File Offset: 0x0003DFB8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.y, this.x);
			}
		}

		// Token: 0x17000664 RID: 1636
		// (get) Token: 0x06001694 RID: 5780 RVA: 0x0003FDD7 File Offset: 0x0003DFD7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.y, this.y);
			}
		}

		// Token: 0x17000665 RID: 1637
		// (get) Token: 0x06001695 RID: 5781 RVA: 0x0003FDF6 File Offset: 0x0003DFF6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.y, this.z);
			}
		}

		// Token: 0x17000666 RID: 1638
		// (get) Token: 0x06001696 RID: 5782 RVA: 0x0003FE15 File Offset: 0x0003E015
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.y, this.w);
			}
		}

		// Token: 0x17000667 RID: 1639
		// (get) Token: 0x06001697 RID: 5783 RVA: 0x0003FE34 File Offset: 0x0003E034
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.z, this.x);
			}
		}

		// Token: 0x17000668 RID: 1640
		// (get) Token: 0x06001698 RID: 5784 RVA: 0x0003FE53 File Offset: 0x0003E053
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.z, this.y);
			}
		}

		// Token: 0x17000669 RID: 1641
		// (get) Token: 0x06001699 RID: 5785 RVA: 0x0003FE72 File Offset: 0x0003E072
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.z, this.z);
			}
		}

		// Token: 0x1700066A RID: 1642
		// (get) Token: 0x0600169A RID: 5786 RVA: 0x0003FE91 File Offset: 0x0003E091
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.z, this.w);
			}
		}

		// Token: 0x1700066B RID: 1643
		// (get) Token: 0x0600169B RID: 5787 RVA: 0x0003FEB0 File Offset: 0x0003E0B0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.w, this.x);
			}
		}

		// Token: 0x1700066C RID: 1644
		// (get) Token: 0x0600169C RID: 5788 RVA: 0x0003FECF File Offset: 0x0003E0CF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.w, this.y);
			}
		}

		// Token: 0x1700066D RID: 1645
		// (get) Token: 0x0600169D RID: 5789 RVA: 0x0003FEEE File Offset: 0x0003E0EE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.w, this.z);
			}
		}

		// Token: 0x1700066E RID: 1646
		// (get) Token: 0x0600169E RID: 5790 RVA: 0x0003FF0D File Offset: 0x0003E10D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.w, this.w);
			}
		}

		// Token: 0x1700066F RID: 1647
		// (get) Token: 0x0600169F RID: 5791 RVA: 0x0003FF2C File Offset: 0x0003E12C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.x, this.x);
			}
		}

		// Token: 0x17000670 RID: 1648
		// (get) Token: 0x060016A0 RID: 5792 RVA: 0x0003FF4B File Offset: 0x0003E14B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.x, this.y);
			}
		}

		// Token: 0x17000671 RID: 1649
		// (get) Token: 0x060016A1 RID: 5793 RVA: 0x0003FF6A File Offset: 0x0003E16A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.x, this.z);
			}
		}

		// Token: 0x17000672 RID: 1650
		// (get) Token: 0x060016A2 RID: 5794 RVA: 0x0003FF89 File Offset: 0x0003E189
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.x, this.w);
			}
		}

		// Token: 0x17000673 RID: 1651
		// (get) Token: 0x060016A3 RID: 5795 RVA: 0x0003FFA8 File Offset: 0x0003E1A8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.y, this.x);
			}
		}

		// Token: 0x17000674 RID: 1652
		// (get) Token: 0x060016A4 RID: 5796 RVA: 0x0003FFC7 File Offset: 0x0003E1C7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.y, this.y);
			}
		}

		// Token: 0x17000675 RID: 1653
		// (get) Token: 0x060016A5 RID: 5797 RVA: 0x0003FFE6 File Offset: 0x0003E1E6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.y, this.z);
			}
		}

		// Token: 0x17000676 RID: 1654
		// (get) Token: 0x060016A6 RID: 5798 RVA: 0x00040005 File Offset: 0x0003E205
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.y, this.w);
			}
		}

		// Token: 0x17000677 RID: 1655
		// (get) Token: 0x060016A7 RID: 5799 RVA: 0x00040024 File Offset: 0x0003E224
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.z, this.x);
			}
		}

		// Token: 0x17000678 RID: 1656
		// (get) Token: 0x060016A8 RID: 5800 RVA: 0x00040043 File Offset: 0x0003E243
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.z, this.y);
			}
		}

		// Token: 0x17000679 RID: 1657
		// (get) Token: 0x060016A9 RID: 5801 RVA: 0x00040062 File Offset: 0x0003E262
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.z, this.z);
			}
		}

		// Token: 0x1700067A RID: 1658
		// (get) Token: 0x060016AA RID: 5802 RVA: 0x00040081 File Offset: 0x0003E281
		// (set) Token: 0x060016AB RID: 5803 RVA: 0x000400A0 File Offset: 0x0003E2A0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.z, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
				this.z = value.z;
				this.w = value.w;
			}
		}

		// Token: 0x1700067B RID: 1659
		// (get) Token: 0x060016AC RID: 5804 RVA: 0x000400D2 File Offset: 0x0003E2D2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.w, this.x);
			}
		}

		// Token: 0x1700067C RID: 1660
		// (get) Token: 0x060016AD RID: 5805 RVA: 0x000400F1 File Offset: 0x0003E2F1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.w, this.y);
			}
		}

		// Token: 0x1700067D RID: 1661
		// (get) Token: 0x060016AE RID: 5806 RVA: 0x00040110 File Offset: 0x0003E310
		// (set) Token: 0x060016AF RID: 5807 RVA: 0x0004012F File Offset: 0x0003E32F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.w, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
				this.w = value.z;
				this.z = value.w;
			}
		}

		// Token: 0x1700067E RID: 1662
		// (get) Token: 0x060016B0 RID: 5808 RVA: 0x00040161 File Offset: 0x0003E361
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.w, this.w);
			}
		}

		// Token: 0x1700067F RID: 1663
		// (get) Token: 0x060016B1 RID: 5809 RVA: 0x00040180 File Offset: 0x0003E380
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.x, this.x);
			}
		}

		// Token: 0x17000680 RID: 1664
		// (get) Token: 0x060016B2 RID: 5810 RVA: 0x0004019F File Offset: 0x0003E39F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.x, this.y);
			}
		}

		// Token: 0x17000681 RID: 1665
		// (get) Token: 0x060016B3 RID: 5811 RVA: 0x000401BE File Offset: 0x0003E3BE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.x, this.z);
			}
		}

		// Token: 0x17000682 RID: 1666
		// (get) Token: 0x060016B4 RID: 5812 RVA: 0x000401DD File Offset: 0x0003E3DD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.x, this.w);
			}
		}

		// Token: 0x17000683 RID: 1667
		// (get) Token: 0x060016B5 RID: 5813 RVA: 0x000401FC File Offset: 0x0003E3FC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.y, this.x);
			}
		}

		// Token: 0x17000684 RID: 1668
		// (get) Token: 0x060016B6 RID: 5814 RVA: 0x0004021B File Offset: 0x0003E41B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.y, this.y);
			}
		}

		// Token: 0x17000685 RID: 1669
		// (get) Token: 0x060016B7 RID: 5815 RVA: 0x0004023A File Offset: 0x0003E43A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.y, this.z);
			}
		}

		// Token: 0x17000686 RID: 1670
		// (get) Token: 0x060016B8 RID: 5816 RVA: 0x00040259 File Offset: 0x0003E459
		// (set) Token: 0x060016B9 RID: 5817 RVA: 0x00040278 File Offset: 0x0003E478
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.y, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
				this.y = value.z;
				this.w = value.w;
			}
		}

		// Token: 0x17000687 RID: 1671
		// (get) Token: 0x060016BA RID: 5818 RVA: 0x000402AA File Offset: 0x0003E4AA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.z, this.x);
			}
		}

		// Token: 0x17000688 RID: 1672
		// (get) Token: 0x060016BB RID: 5819 RVA: 0x000402C9 File Offset: 0x0003E4C9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.z, this.y);
			}
		}

		// Token: 0x17000689 RID: 1673
		// (get) Token: 0x060016BC RID: 5820 RVA: 0x000402E8 File Offset: 0x0003E4E8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.z, this.z);
			}
		}

		// Token: 0x1700068A RID: 1674
		// (get) Token: 0x060016BD RID: 5821 RVA: 0x00040307 File Offset: 0x0003E507
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.z, this.w);
			}
		}

		// Token: 0x1700068B RID: 1675
		// (get) Token: 0x060016BE RID: 5822 RVA: 0x00040326 File Offset: 0x0003E526
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.w, this.x);
			}
		}

		// Token: 0x1700068C RID: 1676
		// (get) Token: 0x060016BF RID: 5823 RVA: 0x00040345 File Offset: 0x0003E545
		// (set) Token: 0x060016C0 RID: 5824 RVA: 0x00040364 File Offset: 0x0003E564
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.w, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
				this.w = value.z;
				this.y = value.w;
			}
		}

		// Token: 0x1700068D RID: 1677
		// (get) Token: 0x060016C1 RID: 5825 RVA: 0x00040396 File Offset: 0x0003E596
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.w, this.z);
			}
		}

		// Token: 0x1700068E RID: 1678
		// (get) Token: 0x060016C2 RID: 5826 RVA: 0x000403B5 File Offset: 0x0003E5B5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.z, this.w, this.w);
			}
		}

		// Token: 0x1700068F RID: 1679
		// (get) Token: 0x060016C3 RID: 5827 RVA: 0x000403D4 File Offset: 0x0003E5D4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.w, this.x, this.x);
			}
		}

		// Token: 0x17000690 RID: 1680
		// (get) Token: 0x060016C4 RID: 5828 RVA: 0x000403F3 File Offset: 0x0003E5F3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.w, this.x, this.y);
			}
		}

		// Token: 0x17000691 RID: 1681
		// (get) Token: 0x060016C5 RID: 5829 RVA: 0x00040412 File Offset: 0x0003E612
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.w, this.x, this.z);
			}
		}

		// Token: 0x17000692 RID: 1682
		// (get) Token: 0x060016C6 RID: 5830 RVA: 0x00040431 File Offset: 0x0003E631
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.w, this.x, this.w);
			}
		}

		// Token: 0x17000693 RID: 1683
		// (get) Token: 0x060016C7 RID: 5831 RVA: 0x00040450 File Offset: 0x0003E650
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.w, this.y, this.x);
			}
		}

		// Token: 0x17000694 RID: 1684
		// (get) Token: 0x060016C8 RID: 5832 RVA: 0x0004046F File Offset: 0x0003E66F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.w, this.y, this.y);
			}
		}

		// Token: 0x17000695 RID: 1685
		// (get) Token: 0x060016C9 RID: 5833 RVA: 0x0004048E File Offset: 0x0003E68E
		// (set) Token: 0x060016CA RID: 5834 RVA: 0x000404AD File Offset: 0x0003E6AD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.w, this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.w = value.y;
				this.y = value.z;
				this.z = value.w;
			}
		}

		// Token: 0x17000696 RID: 1686
		// (get) Token: 0x060016CB RID: 5835 RVA: 0x000404DF File Offset: 0x0003E6DF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.w, this.y, this.w);
			}
		}

		// Token: 0x17000697 RID: 1687
		// (get) Token: 0x060016CC RID: 5836 RVA: 0x000404FE File Offset: 0x0003E6FE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.w, this.z, this.x);
			}
		}

		// Token: 0x17000698 RID: 1688
		// (get) Token: 0x060016CD RID: 5837 RVA: 0x0004051D File Offset: 0x0003E71D
		// (set) Token: 0x060016CE RID: 5838 RVA: 0x0004053C File Offset: 0x0003E73C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.w, this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.w = value.y;
				this.z = value.z;
				this.y = value.w;
			}
		}

		// Token: 0x17000699 RID: 1689
		// (get) Token: 0x060016CF RID: 5839 RVA: 0x0004056E File Offset: 0x0003E76E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.w, this.z, this.z);
			}
		}

		// Token: 0x1700069A RID: 1690
		// (get) Token: 0x060016D0 RID: 5840 RVA: 0x0004058D File Offset: 0x0003E78D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.w, this.z, this.w);
			}
		}

		// Token: 0x1700069B RID: 1691
		// (get) Token: 0x060016D1 RID: 5841 RVA: 0x000405AC File Offset: 0x0003E7AC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.w, this.w, this.x);
			}
		}

		// Token: 0x1700069C RID: 1692
		// (get) Token: 0x060016D2 RID: 5842 RVA: 0x000405CB File Offset: 0x0003E7CB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.w, this.w, this.y);
			}
		}

		// Token: 0x1700069D RID: 1693
		// (get) Token: 0x060016D3 RID: 5843 RVA: 0x000405EA File Offset: 0x0003E7EA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.w, this.w, this.z);
			}
		}

		// Token: 0x1700069E RID: 1694
		// (get) Token: 0x060016D4 RID: 5844 RVA: 0x00040609 File Offset: 0x0003E809
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.w, this.w, this.w);
			}
		}

		// Token: 0x1700069F RID: 1695
		// (get) Token: 0x060016D5 RID: 5845 RVA: 0x00040628 File Offset: 0x0003E828
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.x, this.x);
			}
		}

		// Token: 0x170006A0 RID: 1696
		// (get) Token: 0x060016D6 RID: 5846 RVA: 0x00040647 File Offset: 0x0003E847
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.x, this.y);
			}
		}

		// Token: 0x170006A1 RID: 1697
		// (get) Token: 0x060016D7 RID: 5847 RVA: 0x00040666 File Offset: 0x0003E866
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.x, this.z);
			}
		}

		// Token: 0x170006A2 RID: 1698
		// (get) Token: 0x060016D8 RID: 5848 RVA: 0x00040685 File Offset: 0x0003E885
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.x, this.w);
			}
		}

		// Token: 0x170006A3 RID: 1699
		// (get) Token: 0x060016D9 RID: 5849 RVA: 0x000406A4 File Offset: 0x0003E8A4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.y, this.x);
			}
		}

		// Token: 0x170006A4 RID: 1700
		// (get) Token: 0x060016DA RID: 5850 RVA: 0x000406C3 File Offset: 0x0003E8C3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.y, this.y);
			}
		}

		// Token: 0x170006A5 RID: 1701
		// (get) Token: 0x060016DB RID: 5851 RVA: 0x000406E2 File Offset: 0x0003E8E2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.y, this.z);
			}
		}

		// Token: 0x170006A6 RID: 1702
		// (get) Token: 0x060016DC RID: 5852 RVA: 0x00040701 File Offset: 0x0003E901
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.y, this.w);
			}
		}

		// Token: 0x170006A7 RID: 1703
		// (get) Token: 0x060016DD RID: 5853 RVA: 0x00040720 File Offset: 0x0003E920
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.z, this.x);
			}
		}

		// Token: 0x170006A8 RID: 1704
		// (get) Token: 0x060016DE RID: 5854 RVA: 0x0004073F File Offset: 0x0003E93F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.z, this.y);
			}
		}

		// Token: 0x170006A9 RID: 1705
		// (get) Token: 0x060016DF RID: 5855 RVA: 0x0004075E File Offset: 0x0003E95E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.z, this.z);
			}
		}

		// Token: 0x170006AA RID: 1706
		// (get) Token: 0x060016E0 RID: 5856 RVA: 0x0004077D File Offset: 0x0003E97D
		// (set) Token: 0x060016E1 RID: 5857 RVA: 0x0004079C File Offset: 0x0003E99C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.z, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
				this.z = value.z;
				this.w = value.w;
			}
		}

		// Token: 0x170006AB RID: 1707
		// (get) Token: 0x060016E2 RID: 5858 RVA: 0x000407CE File Offset: 0x0003E9CE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.w, this.x);
			}
		}

		// Token: 0x170006AC RID: 1708
		// (get) Token: 0x060016E3 RID: 5859 RVA: 0x000407ED File Offset: 0x0003E9ED
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.w, this.y);
			}
		}

		// Token: 0x170006AD RID: 1709
		// (get) Token: 0x060016E4 RID: 5860 RVA: 0x0004080C File Offset: 0x0003EA0C
		// (set) Token: 0x060016E5 RID: 5861 RVA: 0x0004082B File Offset: 0x0003EA2B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.w, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
				this.w = value.z;
				this.z = value.w;
			}
		}

		// Token: 0x170006AE RID: 1710
		// (get) Token: 0x060016E6 RID: 5862 RVA: 0x0004085D File Offset: 0x0003EA5D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.w, this.w);
			}
		}

		// Token: 0x170006AF RID: 1711
		// (get) Token: 0x060016E7 RID: 5863 RVA: 0x0004087C File Offset: 0x0003EA7C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.x, this.x);
			}
		}

		// Token: 0x170006B0 RID: 1712
		// (get) Token: 0x060016E8 RID: 5864 RVA: 0x0004089B File Offset: 0x0003EA9B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.x, this.y);
			}
		}

		// Token: 0x170006B1 RID: 1713
		// (get) Token: 0x060016E9 RID: 5865 RVA: 0x000408BA File Offset: 0x0003EABA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.x, this.z);
			}
		}

		// Token: 0x170006B2 RID: 1714
		// (get) Token: 0x060016EA RID: 5866 RVA: 0x000408D9 File Offset: 0x0003EAD9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.x, this.w);
			}
		}

		// Token: 0x170006B3 RID: 1715
		// (get) Token: 0x060016EB RID: 5867 RVA: 0x000408F8 File Offset: 0x0003EAF8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.y, this.x);
			}
		}

		// Token: 0x170006B4 RID: 1716
		// (get) Token: 0x060016EC RID: 5868 RVA: 0x00040917 File Offset: 0x0003EB17
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.y, this.y);
			}
		}

		// Token: 0x170006B5 RID: 1717
		// (get) Token: 0x060016ED RID: 5869 RVA: 0x00040936 File Offset: 0x0003EB36
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.y, this.z);
			}
		}

		// Token: 0x170006B6 RID: 1718
		// (get) Token: 0x060016EE RID: 5870 RVA: 0x00040955 File Offset: 0x0003EB55
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.y, this.w);
			}
		}

		// Token: 0x170006B7 RID: 1719
		// (get) Token: 0x060016EF RID: 5871 RVA: 0x00040974 File Offset: 0x0003EB74
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.z, this.x);
			}
		}

		// Token: 0x170006B8 RID: 1720
		// (get) Token: 0x060016F0 RID: 5872 RVA: 0x00040993 File Offset: 0x0003EB93
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.z, this.y);
			}
		}

		// Token: 0x170006B9 RID: 1721
		// (get) Token: 0x060016F1 RID: 5873 RVA: 0x000409B2 File Offset: 0x0003EBB2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.z, this.z);
			}
		}

		// Token: 0x170006BA RID: 1722
		// (get) Token: 0x060016F2 RID: 5874 RVA: 0x000409D1 File Offset: 0x0003EBD1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.z, this.w);
			}
		}

		// Token: 0x170006BB RID: 1723
		// (get) Token: 0x060016F3 RID: 5875 RVA: 0x000409F0 File Offset: 0x0003EBF0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.w, this.x);
			}
		}

		// Token: 0x170006BC RID: 1724
		// (get) Token: 0x060016F4 RID: 5876 RVA: 0x00040A0F File Offset: 0x0003EC0F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.w, this.y);
			}
		}

		// Token: 0x170006BD RID: 1725
		// (get) Token: 0x060016F5 RID: 5877 RVA: 0x00040A2E File Offset: 0x0003EC2E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.w, this.z);
			}
		}

		// Token: 0x170006BE RID: 1726
		// (get) Token: 0x060016F6 RID: 5878 RVA: 0x00040A4D File Offset: 0x0003EC4D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.w, this.w);
			}
		}

		// Token: 0x170006BF RID: 1727
		// (get) Token: 0x060016F7 RID: 5879 RVA: 0x00040A6C File Offset: 0x0003EC6C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.x, this.x);
			}
		}

		// Token: 0x170006C0 RID: 1728
		// (get) Token: 0x060016F8 RID: 5880 RVA: 0x00040A8B File Offset: 0x0003EC8B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.x, this.y);
			}
		}

		// Token: 0x170006C1 RID: 1729
		// (get) Token: 0x060016F9 RID: 5881 RVA: 0x00040AAA File Offset: 0x0003ECAA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.x, this.z);
			}
		}

		// Token: 0x170006C2 RID: 1730
		// (get) Token: 0x060016FA RID: 5882 RVA: 0x00040AC9 File Offset: 0x0003ECC9
		// (set) Token: 0x060016FB RID: 5883 RVA: 0x00040AE8 File Offset: 0x0003ECE8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.x, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
				this.x = value.z;
				this.w = value.w;
			}
		}

		// Token: 0x170006C3 RID: 1731
		// (get) Token: 0x060016FC RID: 5884 RVA: 0x00040B1A File Offset: 0x0003ED1A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.y, this.x);
			}
		}

		// Token: 0x170006C4 RID: 1732
		// (get) Token: 0x060016FD RID: 5885 RVA: 0x00040B39 File Offset: 0x0003ED39
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.y, this.y);
			}
		}

		// Token: 0x170006C5 RID: 1733
		// (get) Token: 0x060016FE RID: 5886 RVA: 0x00040B58 File Offset: 0x0003ED58
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.y, this.z);
			}
		}

		// Token: 0x170006C6 RID: 1734
		// (get) Token: 0x060016FF RID: 5887 RVA: 0x00040B77 File Offset: 0x0003ED77
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.y, this.w);
			}
		}

		// Token: 0x170006C7 RID: 1735
		// (get) Token: 0x06001700 RID: 5888 RVA: 0x00040B96 File Offset: 0x0003ED96
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.z, this.x);
			}
		}

		// Token: 0x170006C8 RID: 1736
		// (get) Token: 0x06001701 RID: 5889 RVA: 0x00040BB5 File Offset: 0x0003EDB5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.z, this.y);
			}
		}

		// Token: 0x170006C9 RID: 1737
		// (get) Token: 0x06001702 RID: 5890 RVA: 0x00040BD4 File Offset: 0x0003EDD4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.z, this.z);
			}
		}

		// Token: 0x170006CA RID: 1738
		// (get) Token: 0x06001703 RID: 5891 RVA: 0x00040BF3 File Offset: 0x0003EDF3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.z, this.w);
			}
		}

		// Token: 0x170006CB RID: 1739
		// (get) Token: 0x06001704 RID: 5892 RVA: 0x00040C12 File Offset: 0x0003EE12
		// (set) Token: 0x06001705 RID: 5893 RVA: 0x00040C31 File Offset: 0x0003EE31
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.w, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
				this.w = value.z;
				this.x = value.w;
			}
		}

		// Token: 0x170006CC RID: 1740
		// (get) Token: 0x06001706 RID: 5894 RVA: 0x00040C63 File Offset: 0x0003EE63
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.w, this.y);
			}
		}

		// Token: 0x170006CD RID: 1741
		// (get) Token: 0x06001707 RID: 5895 RVA: 0x00040C82 File Offset: 0x0003EE82
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.w, this.z);
			}
		}

		// Token: 0x170006CE RID: 1742
		// (get) Token: 0x06001708 RID: 5896 RVA: 0x00040CA1 File Offset: 0x0003EEA1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.z, this.w, this.w);
			}
		}

		// Token: 0x170006CF RID: 1743
		// (get) Token: 0x06001709 RID: 5897 RVA: 0x00040CC0 File Offset: 0x0003EEC0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 ywxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.w, this.x, this.x);
			}
		}

		// Token: 0x170006D0 RID: 1744
		// (get) Token: 0x0600170A RID: 5898 RVA: 0x00040CDF File Offset: 0x0003EEDF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 ywxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.w, this.x, this.y);
			}
		}

		// Token: 0x170006D1 RID: 1745
		// (get) Token: 0x0600170B RID: 5899 RVA: 0x00040CFE File Offset: 0x0003EEFE
		// (set) Token: 0x0600170C RID: 5900 RVA: 0x00040D1D File Offset: 0x0003EF1D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 ywxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.w, this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.w = value.y;
				this.x = value.z;
				this.z = value.w;
			}
		}

		// Token: 0x170006D2 RID: 1746
		// (get) Token: 0x0600170D RID: 5901 RVA: 0x00040D4F File Offset: 0x0003EF4F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 ywxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.w, this.x, this.w);
			}
		}

		// Token: 0x170006D3 RID: 1747
		// (get) Token: 0x0600170E RID: 5902 RVA: 0x00040D6E File Offset: 0x0003EF6E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 ywyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.w, this.y, this.x);
			}
		}

		// Token: 0x170006D4 RID: 1748
		// (get) Token: 0x0600170F RID: 5903 RVA: 0x00040D8D File Offset: 0x0003EF8D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 ywyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.w, this.y, this.y);
			}
		}

		// Token: 0x170006D5 RID: 1749
		// (get) Token: 0x06001710 RID: 5904 RVA: 0x00040DAC File Offset: 0x0003EFAC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 ywyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.w, this.y, this.z);
			}
		}

		// Token: 0x170006D6 RID: 1750
		// (get) Token: 0x06001711 RID: 5905 RVA: 0x00040DCB File Offset: 0x0003EFCB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 ywyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.w, this.y, this.w);
			}
		}

		// Token: 0x170006D7 RID: 1751
		// (get) Token: 0x06001712 RID: 5906 RVA: 0x00040DEA File Offset: 0x0003EFEA
		// (set) Token: 0x06001713 RID: 5907 RVA: 0x00040E09 File Offset: 0x0003F009
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 ywzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.w, this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.w = value.y;
				this.z = value.z;
				this.x = value.w;
			}
		}

		// Token: 0x170006D8 RID: 1752
		// (get) Token: 0x06001714 RID: 5908 RVA: 0x00040E3B File Offset: 0x0003F03B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 ywzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.w, this.z, this.y);
			}
		}

		// Token: 0x170006D9 RID: 1753
		// (get) Token: 0x06001715 RID: 5909 RVA: 0x00040E5A File Offset: 0x0003F05A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 ywzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.w, this.z, this.z);
			}
		}

		// Token: 0x170006DA RID: 1754
		// (get) Token: 0x06001716 RID: 5910 RVA: 0x00040E79 File Offset: 0x0003F079
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 ywzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.w, this.z, this.w);
			}
		}

		// Token: 0x170006DB RID: 1755
		// (get) Token: 0x06001717 RID: 5911 RVA: 0x00040E98 File Offset: 0x0003F098
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 ywwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.w, this.w, this.x);
			}
		}

		// Token: 0x170006DC RID: 1756
		// (get) Token: 0x06001718 RID: 5912 RVA: 0x00040EB7 File Offset: 0x0003F0B7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 ywwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.w, this.w, this.y);
			}
		}

		// Token: 0x170006DD RID: 1757
		// (get) Token: 0x06001719 RID: 5913 RVA: 0x00040ED6 File Offset: 0x0003F0D6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 ywwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.w, this.w, this.z);
			}
		}

		// Token: 0x170006DE RID: 1758
		// (get) Token: 0x0600171A RID: 5914 RVA: 0x00040EF5 File Offset: 0x0003F0F5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 ywww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.w, this.w, this.w);
			}
		}

		// Token: 0x170006DF RID: 1759
		// (get) Token: 0x0600171B RID: 5915 RVA: 0x00040F14 File Offset: 0x0003F114
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.x, this.x);
			}
		}

		// Token: 0x170006E0 RID: 1760
		// (get) Token: 0x0600171C RID: 5916 RVA: 0x00040F33 File Offset: 0x0003F133
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.x, this.y);
			}
		}

		// Token: 0x170006E1 RID: 1761
		// (get) Token: 0x0600171D RID: 5917 RVA: 0x00040F52 File Offset: 0x0003F152
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.x, this.z);
			}
		}

		// Token: 0x170006E2 RID: 1762
		// (get) Token: 0x0600171E RID: 5918 RVA: 0x00040F71 File Offset: 0x0003F171
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.x, this.w);
			}
		}

		// Token: 0x170006E3 RID: 1763
		// (get) Token: 0x0600171F RID: 5919 RVA: 0x00040F90 File Offset: 0x0003F190
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.y, this.x);
			}
		}

		// Token: 0x170006E4 RID: 1764
		// (get) Token: 0x06001720 RID: 5920 RVA: 0x00040FAF File Offset: 0x0003F1AF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.y, this.y);
			}
		}

		// Token: 0x170006E5 RID: 1765
		// (get) Token: 0x06001721 RID: 5921 RVA: 0x00040FCE File Offset: 0x0003F1CE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.y, this.z);
			}
		}

		// Token: 0x170006E6 RID: 1766
		// (get) Token: 0x06001722 RID: 5922 RVA: 0x00040FED File Offset: 0x0003F1ED
		// (set) Token: 0x06001723 RID: 5923 RVA: 0x0004100C File Offset: 0x0003F20C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.y, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
				this.y = value.z;
				this.w = value.w;
			}
		}

		// Token: 0x170006E7 RID: 1767
		// (get) Token: 0x06001724 RID: 5924 RVA: 0x0004103E File Offset: 0x0003F23E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.z, this.x);
			}
		}

		// Token: 0x170006E8 RID: 1768
		// (get) Token: 0x06001725 RID: 5925 RVA: 0x0004105D File Offset: 0x0003F25D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.z, this.y);
			}
		}

		// Token: 0x170006E9 RID: 1769
		// (get) Token: 0x06001726 RID: 5926 RVA: 0x0004107C File Offset: 0x0003F27C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.z, this.z);
			}
		}

		// Token: 0x170006EA RID: 1770
		// (get) Token: 0x06001727 RID: 5927 RVA: 0x0004109B File Offset: 0x0003F29B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.z, this.w);
			}
		}

		// Token: 0x170006EB RID: 1771
		// (get) Token: 0x06001728 RID: 5928 RVA: 0x000410BA File Offset: 0x0003F2BA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.w, this.x);
			}
		}

		// Token: 0x170006EC RID: 1772
		// (get) Token: 0x06001729 RID: 5929 RVA: 0x000410D9 File Offset: 0x0003F2D9
		// (set) Token: 0x0600172A RID: 5930 RVA: 0x000410F8 File Offset: 0x0003F2F8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.w, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
				this.w = value.z;
				this.y = value.w;
			}
		}

		// Token: 0x170006ED RID: 1773
		// (get) Token: 0x0600172B RID: 5931 RVA: 0x0004112A File Offset: 0x0003F32A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.w, this.z);
			}
		}

		// Token: 0x170006EE RID: 1774
		// (get) Token: 0x0600172C RID: 5932 RVA: 0x00041149 File Offset: 0x0003F349
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.x, this.w, this.w);
			}
		}

		// Token: 0x170006EF RID: 1775
		// (get) Token: 0x0600172D RID: 5933 RVA: 0x00041168 File Offset: 0x0003F368
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.x, this.x);
			}
		}

		// Token: 0x170006F0 RID: 1776
		// (get) Token: 0x0600172E RID: 5934 RVA: 0x00041187 File Offset: 0x0003F387
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.x, this.y);
			}
		}

		// Token: 0x170006F1 RID: 1777
		// (get) Token: 0x0600172F RID: 5935 RVA: 0x000411A6 File Offset: 0x0003F3A6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.x, this.z);
			}
		}

		// Token: 0x170006F2 RID: 1778
		// (get) Token: 0x06001730 RID: 5936 RVA: 0x000411C5 File Offset: 0x0003F3C5
		// (set) Token: 0x06001731 RID: 5937 RVA: 0x000411E4 File Offset: 0x0003F3E4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.x, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
				this.x = value.z;
				this.w = value.w;
			}
		}

		// Token: 0x170006F3 RID: 1779
		// (get) Token: 0x06001732 RID: 5938 RVA: 0x00041216 File Offset: 0x0003F416
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.y, this.x);
			}
		}

		// Token: 0x170006F4 RID: 1780
		// (get) Token: 0x06001733 RID: 5939 RVA: 0x00041235 File Offset: 0x0003F435
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.y, this.y);
			}
		}

		// Token: 0x170006F5 RID: 1781
		// (get) Token: 0x06001734 RID: 5940 RVA: 0x00041254 File Offset: 0x0003F454
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.y, this.z);
			}
		}

		// Token: 0x170006F6 RID: 1782
		// (get) Token: 0x06001735 RID: 5941 RVA: 0x00041273 File Offset: 0x0003F473
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.y, this.w);
			}
		}

		// Token: 0x170006F7 RID: 1783
		// (get) Token: 0x06001736 RID: 5942 RVA: 0x00041292 File Offset: 0x0003F492
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.z, this.x);
			}
		}

		// Token: 0x170006F8 RID: 1784
		// (get) Token: 0x06001737 RID: 5943 RVA: 0x000412B1 File Offset: 0x0003F4B1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.z, this.y);
			}
		}

		// Token: 0x170006F9 RID: 1785
		// (get) Token: 0x06001738 RID: 5944 RVA: 0x000412D0 File Offset: 0x0003F4D0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.z, this.z);
			}
		}

		// Token: 0x170006FA RID: 1786
		// (get) Token: 0x06001739 RID: 5945 RVA: 0x000412EF File Offset: 0x0003F4EF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.z, this.w);
			}
		}

		// Token: 0x170006FB RID: 1787
		// (get) Token: 0x0600173A RID: 5946 RVA: 0x0004130E File Offset: 0x0003F50E
		// (set) Token: 0x0600173B RID: 5947 RVA: 0x0004132D File Offset: 0x0003F52D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.w, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
				this.w = value.z;
				this.x = value.w;
			}
		}

		// Token: 0x170006FC RID: 1788
		// (get) Token: 0x0600173C RID: 5948 RVA: 0x0004135F File Offset: 0x0003F55F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.w, this.y);
			}
		}

		// Token: 0x170006FD RID: 1789
		// (get) Token: 0x0600173D RID: 5949 RVA: 0x0004137E File Offset: 0x0003F57E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.w, this.z);
			}
		}

		// Token: 0x170006FE RID: 1790
		// (get) Token: 0x0600173E RID: 5950 RVA: 0x0004139D File Offset: 0x0003F59D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.y, this.w, this.w);
			}
		}

		// Token: 0x170006FF RID: 1791
		// (get) Token: 0x0600173F RID: 5951 RVA: 0x000413BC File Offset: 0x0003F5BC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.x, this.x);
			}
		}

		// Token: 0x17000700 RID: 1792
		// (get) Token: 0x06001740 RID: 5952 RVA: 0x000413DB File Offset: 0x0003F5DB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.x, this.y);
			}
		}

		// Token: 0x17000701 RID: 1793
		// (get) Token: 0x06001741 RID: 5953 RVA: 0x000413FA File Offset: 0x0003F5FA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.x, this.z);
			}
		}

		// Token: 0x17000702 RID: 1794
		// (get) Token: 0x06001742 RID: 5954 RVA: 0x00041419 File Offset: 0x0003F619
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.x, this.w);
			}
		}

		// Token: 0x17000703 RID: 1795
		// (get) Token: 0x06001743 RID: 5955 RVA: 0x00041438 File Offset: 0x0003F638
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.y, this.x);
			}
		}

		// Token: 0x17000704 RID: 1796
		// (get) Token: 0x06001744 RID: 5956 RVA: 0x00041457 File Offset: 0x0003F657
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.y, this.y);
			}
		}

		// Token: 0x17000705 RID: 1797
		// (get) Token: 0x06001745 RID: 5957 RVA: 0x00041476 File Offset: 0x0003F676
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.y, this.z);
			}
		}

		// Token: 0x17000706 RID: 1798
		// (get) Token: 0x06001746 RID: 5958 RVA: 0x00041495 File Offset: 0x0003F695
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.y, this.w);
			}
		}

		// Token: 0x17000707 RID: 1799
		// (get) Token: 0x06001747 RID: 5959 RVA: 0x000414B4 File Offset: 0x0003F6B4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.z, this.x);
			}
		}

		// Token: 0x17000708 RID: 1800
		// (get) Token: 0x06001748 RID: 5960 RVA: 0x000414D3 File Offset: 0x0003F6D3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.z, this.y);
			}
		}

		// Token: 0x17000709 RID: 1801
		// (get) Token: 0x06001749 RID: 5961 RVA: 0x000414F2 File Offset: 0x0003F6F2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.z, this.z);
			}
		}

		// Token: 0x1700070A RID: 1802
		// (get) Token: 0x0600174A RID: 5962 RVA: 0x00041511 File Offset: 0x0003F711
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.z, this.w);
			}
		}

		// Token: 0x1700070B RID: 1803
		// (get) Token: 0x0600174B RID: 5963 RVA: 0x00041530 File Offset: 0x0003F730
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.w, this.x);
			}
		}

		// Token: 0x1700070C RID: 1804
		// (get) Token: 0x0600174C RID: 5964 RVA: 0x0004154F File Offset: 0x0003F74F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.w, this.y);
			}
		}

		// Token: 0x1700070D RID: 1805
		// (get) Token: 0x0600174D RID: 5965 RVA: 0x0004156E File Offset: 0x0003F76E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.w, this.z);
			}
		}

		// Token: 0x1700070E RID: 1806
		// (get) Token: 0x0600174E RID: 5966 RVA: 0x0004158D File Offset: 0x0003F78D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.z, this.w, this.w);
			}
		}

		// Token: 0x1700070F RID: 1807
		// (get) Token: 0x0600174F RID: 5967 RVA: 0x000415AC File Offset: 0x0003F7AC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.w, this.x, this.x);
			}
		}

		// Token: 0x17000710 RID: 1808
		// (get) Token: 0x06001750 RID: 5968 RVA: 0x000415CB File Offset: 0x0003F7CB
		// (set) Token: 0x06001751 RID: 5969 RVA: 0x000415EA File Offset: 0x0003F7EA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.w, this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.w = value.y;
				this.x = value.z;
				this.y = value.w;
			}
		}

		// Token: 0x17000711 RID: 1809
		// (get) Token: 0x06001752 RID: 5970 RVA: 0x0004161C File Offset: 0x0003F81C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.w, this.x, this.z);
			}
		}

		// Token: 0x17000712 RID: 1810
		// (get) Token: 0x06001753 RID: 5971 RVA: 0x0004163B File Offset: 0x0003F83B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.w, this.x, this.w);
			}
		}

		// Token: 0x17000713 RID: 1811
		// (get) Token: 0x06001754 RID: 5972 RVA: 0x0004165A File Offset: 0x0003F85A
		// (set) Token: 0x06001755 RID: 5973 RVA: 0x00041679 File Offset: 0x0003F879
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.w, this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.w = value.y;
				this.y = value.z;
				this.x = value.w;
			}
		}

		// Token: 0x17000714 RID: 1812
		// (get) Token: 0x06001756 RID: 5974 RVA: 0x000416AB File Offset: 0x0003F8AB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.w, this.y, this.y);
			}
		}

		// Token: 0x17000715 RID: 1813
		// (get) Token: 0x06001757 RID: 5975 RVA: 0x000416CA File Offset: 0x0003F8CA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.w, this.y, this.z);
			}
		}

		// Token: 0x17000716 RID: 1814
		// (get) Token: 0x06001758 RID: 5976 RVA: 0x000416E9 File Offset: 0x0003F8E9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.w, this.y, this.w);
			}
		}

		// Token: 0x17000717 RID: 1815
		// (get) Token: 0x06001759 RID: 5977 RVA: 0x00041708 File Offset: 0x0003F908
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.w, this.z, this.x);
			}
		}

		// Token: 0x17000718 RID: 1816
		// (get) Token: 0x0600175A RID: 5978 RVA: 0x00041727 File Offset: 0x0003F927
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.w, this.z, this.y);
			}
		}

		// Token: 0x17000719 RID: 1817
		// (get) Token: 0x0600175B RID: 5979 RVA: 0x00041746 File Offset: 0x0003F946
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.w, this.z, this.z);
			}
		}

		// Token: 0x1700071A RID: 1818
		// (get) Token: 0x0600175C RID: 5980 RVA: 0x00041765 File Offset: 0x0003F965
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.w, this.z, this.w);
			}
		}

		// Token: 0x1700071B RID: 1819
		// (get) Token: 0x0600175D RID: 5981 RVA: 0x00041784 File Offset: 0x0003F984
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.w, this.w, this.x);
			}
		}

		// Token: 0x1700071C RID: 1820
		// (get) Token: 0x0600175E RID: 5982 RVA: 0x000417A3 File Offset: 0x0003F9A3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.w, this.w, this.y);
			}
		}

		// Token: 0x1700071D RID: 1821
		// (get) Token: 0x0600175F RID: 5983 RVA: 0x000417C2 File Offset: 0x0003F9C2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.w, this.w, this.z);
			}
		}

		// Token: 0x1700071E RID: 1822
		// (get) Token: 0x06001760 RID: 5984 RVA: 0x000417E1 File Offset: 0x0003F9E1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 zwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.z, this.w, this.w, this.w);
			}
		}

		// Token: 0x1700071F RID: 1823
		// (get) Token: 0x06001761 RID: 5985 RVA: 0x00041800 File Offset: 0x0003FA00
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.x, this.x, this.x);
			}
		}

		// Token: 0x17000720 RID: 1824
		// (get) Token: 0x06001762 RID: 5986 RVA: 0x0004181F File Offset: 0x0003FA1F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.x, this.x, this.y);
			}
		}

		// Token: 0x17000721 RID: 1825
		// (get) Token: 0x06001763 RID: 5987 RVA: 0x0004183E File Offset: 0x0003FA3E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.x, this.x, this.z);
			}
		}

		// Token: 0x17000722 RID: 1826
		// (get) Token: 0x06001764 RID: 5988 RVA: 0x0004185D File Offset: 0x0003FA5D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.x, this.x, this.w);
			}
		}

		// Token: 0x17000723 RID: 1827
		// (get) Token: 0x06001765 RID: 5989 RVA: 0x0004187C File Offset: 0x0003FA7C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.x, this.y, this.x);
			}
		}

		// Token: 0x17000724 RID: 1828
		// (get) Token: 0x06001766 RID: 5990 RVA: 0x0004189B File Offset: 0x0003FA9B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.x, this.y, this.y);
			}
		}

		// Token: 0x17000725 RID: 1829
		// (get) Token: 0x06001767 RID: 5991 RVA: 0x000418BA File Offset: 0x0003FABA
		// (set) Token: 0x06001768 RID: 5992 RVA: 0x000418D9 File Offset: 0x0003FAD9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.x, this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.x = value.y;
				this.y = value.z;
				this.z = value.w;
			}
		}

		// Token: 0x17000726 RID: 1830
		// (get) Token: 0x06001769 RID: 5993 RVA: 0x0004190B File Offset: 0x0003FB0B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.x, this.y, this.w);
			}
		}

		// Token: 0x17000727 RID: 1831
		// (get) Token: 0x0600176A RID: 5994 RVA: 0x0004192A File Offset: 0x0003FB2A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.x, this.z, this.x);
			}
		}

		// Token: 0x17000728 RID: 1832
		// (get) Token: 0x0600176B RID: 5995 RVA: 0x00041949 File Offset: 0x0003FB49
		// (set) Token: 0x0600176C RID: 5996 RVA: 0x00041968 File Offset: 0x0003FB68
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.x, this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.x = value.y;
				this.z = value.z;
				this.y = value.w;
			}
		}

		// Token: 0x17000729 RID: 1833
		// (get) Token: 0x0600176D RID: 5997 RVA: 0x0004199A File Offset: 0x0003FB9A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.x, this.z, this.z);
			}
		}

		// Token: 0x1700072A RID: 1834
		// (get) Token: 0x0600176E RID: 5998 RVA: 0x000419B9 File Offset: 0x0003FBB9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.x, this.z, this.w);
			}
		}

		// Token: 0x1700072B RID: 1835
		// (get) Token: 0x0600176F RID: 5999 RVA: 0x000419D8 File Offset: 0x0003FBD8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.x, this.w, this.x);
			}
		}

		// Token: 0x1700072C RID: 1836
		// (get) Token: 0x06001770 RID: 6000 RVA: 0x000419F7 File Offset: 0x0003FBF7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.x, this.w, this.y);
			}
		}

		// Token: 0x1700072D RID: 1837
		// (get) Token: 0x06001771 RID: 6001 RVA: 0x00041A16 File Offset: 0x0003FC16
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.x, this.w, this.z);
			}
		}

		// Token: 0x1700072E RID: 1838
		// (get) Token: 0x06001772 RID: 6002 RVA: 0x00041A35 File Offset: 0x0003FC35
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.x, this.w, this.w);
			}
		}

		// Token: 0x1700072F RID: 1839
		// (get) Token: 0x06001773 RID: 6003 RVA: 0x00041A54 File Offset: 0x0003FC54
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.y, this.x, this.x);
			}
		}

		// Token: 0x17000730 RID: 1840
		// (get) Token: 0x06001774 RID: 6004 RVA: 0x00041A73 File Offset: 0x0003FC73
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.y, this.x, this.y);
			}
		}

		// Token: 0x17000731 RID: 1841
		// (get) Token: 0x06001775 RID: 6005 RVA: 0x00041A92 File Offset: 0x0003FC92
		// (set) Token: 0x06001776 RID: 6006 RVA: 0x00041AB1 File Offset: 0x0003FCB1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.y, this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.y = value.y;
				this.x = value.z;
				this.z = value.w;
			}
		}

		// Token: 0x17000732 RID: 1842
		// (get) Token: 0x06001777 RID: 6007 RVA: 0x00041AE3 File Offset: 0x0003FCE3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.y, this.x, this.w);
			}
		}

		// Token: 0x17000733 RID: 1843
		// (get) Token: 0x06001778 RID: 6008 RVA: 0x00041B02 File Offset: 0x0003FD02
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.y, this.y, this.x);
			}
		}

		// Token: 0x17000734 RID: 1844
		// (get) Token: 0x06001779 RID: 6009 RVA: 0x00041B21 File Offset: 0x0003FD21
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.y, this.y, this.y);
			}
		}

		// Token: 0x17000735 RID: 1845
		// (get) Token: 0x0600177A RID: 6010 RVA: 0x00041B40 File Offset: 0x0003FD40
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.y, this.y, this.z);
			}
		}

		// Token: 0x17000736 RID: 1846
		// (get) Token: 0x0600177B RID: 6011 RVA: 0x00041B5F File Offset: 0x0003FD5F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.y, this.y, this.w);
			}
		}

		// Token: 0x17000737 RID: 1847
		// (get) Token: 0x0600177C RID: 6012 RVA: 0x00041B7E File Offset: 0x0003FD7E
		// (set) Token: 0x0600177D RID: 6013 RVA: 0x00041B9D File Offset: 0x0003FD9D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.y, this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.y = value.y;
				this.z = value.z;
				this.x = value.w;
			}
		}

		// Token: 0x17000738 RID: 1848
		// (get) Token: 0x0600177E RID: 6014 RVA: 0x00041BCF File Offset: 0x0003FDCF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.y, this.z, this.y);
			}
		}

		// Token: 0x17000739 RID: 1849
		// (get) Token: 0x0600177F RID: 6015 RVA: 0x00041BEE File Offset: 0x0003FDEE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.y, this.z, this.z);
			}
		}

		// Token: 0x1700073A RID: 1850
		// (get) Token: 0x06001780 RID: 6016 RVA: 0x00041C0D File Offset: 0x0003FE0D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.y, this.z, this.w);
			}
		}

		// Token: 0x1700073B RID: 1851
		// (get) Token: 0x06001781 RID: 6017 RVA: 0x00041C2C File Offset: 0x0003FE2C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.y, this.w, this.x);
			}
		}

		// Token: 0x1700073C RID: 1852
		// (get) Token: 0x06001782 RID: 6018 RVA: 0x00041C4B File Offset: 0x0003FE4B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.y, this.w, this.y);
			}
		}

		// Token: 0x1700073D RID: 1853
		// (get) Token: 0x06001783 RID: 6019 RVA: 0x00041C6A File Offset: 0x0003FE6A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.y, this.w, this.z);
			}
		}

		// Token: 0x1700073E RID: 1854
		// (get) Token: 0x06001784 RID: 6020 RVA: 0x00041C89 File Offset: 0x0003FE89
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.y, this.w, this.w);
			}
		}

		// Token: 0x1700073F RID: 1855
		// (get) Token: 0x06001785 RID: 6021 RVA: 0x00041CA8 File Offset: 0x0003FEA8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.z, this.x, this.x);
			}
		}

		// Token: 0x17000740 RID: 1856
		// (get) Token: 0x06001786 RID: 6022 RVA: 0x00041CC7 File Offset: 0x0003FEC7
		// (set) Token: 0x06001787 RID: 6023 RVA: 0x00041CE6 File Offset: 0x0003FEE6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.z, this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.z = value.y;
				this.x = value.z;
				this.y = value.w;
			}
		}

		// Token: 0x17000741 RID: 1857
		// (get) Token: 0x06001788 RID: 6024 RVA: 0x00041D18 File Offset: 0x0003FF18
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.z, this.x, this.z);
			}
		}

		// Token: 0x17000742 RID: 1858
		// (get) Token: 0x06001789 RID: 6025 RVA: 0x00041D37 File Offset: 0x0003FF37
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.z, this.x, this.w);
			}
		}

		// Token: 0x17000743 RID: 1859
		// (get) Token: 0x0600178A RID: 6026 RVA: 0x00041D56 File Offset: 0x0003FF56
		// (set) Token: 0x0600178B RID: 6027 RVA: 0x00041D75 File Offset: 0x0003FF75
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.z, this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.z = value.y;
				this.y = value.z;
				this.x = value.w;
			}
		}

		// Token: 0x17000744 RID: 1860
		// (get) Token: 0x0600178C RID: 6028 RVA: 0x00041DA7 File Offset: 0x0003FFA7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.z, this.y, this.y);
			}
		}

		// Token: 0x17000745 RID: 1861
		// (get) Token: 0x0600178D RID: 6029 RVA: 0x00041DC6 File Offset: 0x0003FFC6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.z, this.y, this.z);
			}
		}

		// Token: 0x17000746 RID: 1862
		// (get) Token: 0x0600178E RID: 6030 RVA: 0x00041DE5 File Offset: 0x0003FFE5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.z, this.y, this.w);
			}
		}

		// Token: 0x17000747 RID: 1863
		// (get) Token: 0x0600178F RID: 6031 RVA: 0x00041E04 File Offset: 0x00040004
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.z, this.z, this.x);
			}
		}

		// Token: 0x17000748 RID: 1864
		// (get) Token: 0x06001790 RID: 6032 RVA: 0x00041E23 File Offset: 0x00040023
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.z, this.z, this.y);
			}
		}

		// Token: 0x17000749 RID: 1865
		// (get) Token: 0x06001791 RID: 6033 RVA: 0x00041E42 File Offset: 0x00040042
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.z, this.z, this.z);
			}
		}

		// Token: 0x1700074A RID: 1866
		// (get) Token: 0x06001792 RID: 6034 RVA: 0x00041E61 File Offset: 0x00040061
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.z, this.z, this.w);
			}
		}

		// Token: 0x1700074B RID: 1867
		// (get) Token: 0x06001793 RID: 6035 RVA: 0x00041E80 File Offset: 0x00040080
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.z, this.w, this.x);
			}
		}

		// Token: 0x1700074C RID: 1868
		// (get) Token: 0x06001794 RID: 6036 RVA: 0x00041E9F File Offset: 0x0004009F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.z, this.w, this.y);
			}
		}

		// Token: 0x1700074D RID: 1869
		// (get) Token: 0x06001795 RID: 6037 RVA: 0x00041EBE File Offset: 0x000400BE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.z, this.w, this.z);
			}
		}

		// Token: 0x1700074E RID: 1870
		// (get) Token: 0x06001796 RID: 6038 RVA: 0x00041EDD File Offset: 0x000400DD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.z, this.w, this.w);
			}
		}

		// Token: 0x1700074F RID: 1871
		// (get) Token: 0x06001797 RID: 6039 RVA: 0x00041EFC File Offset: 0x000400FC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.w, this.x, this.x);
			}
		}

		// Token: 0x17000750 RID: 1872
		// (get) Token: 0x06001798 RID: 6040 RVA: 0x00041F1B File Offset: 0x0004011B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.w, this.x, this.y);
			}
		}

		// Token: 0x17000751 RID: 1873
		// (get) Token: 0x06001799 RID: 6041 RVA: 0x00041F3A File Offset: 0x0004013A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.w, this.x, this.z);
			}
		}

		// Token: 0x17000752 RID: 1874
		// (get) Token: 0x0600179A RID: 6042 RVA: 0x00041F59 File Offset: 0x00040159
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.w, this.x, this.w);
			}
		}

		// Token: 0x17000753 RID: 1875
		// (get) Token: 0x0600179B RID: 6043 RVA: 0x00041F78 File Offset: 0x00040178
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.w, this.y, this.x);
			}
		}

		// Token: 0x17000754 RID: 1876
		// (get) Token: 0x0600179C RID: 6044 RVA: 0x00041F97 File Offset: 0x00040197
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.w, this.y, this.y);
			}
		}

		// Token: 0x17000755 RID: 1877
		// (get) Token: 0x0600179D RID: 6045 RVA: 0x00041FB6 File Offset: 0x000401B6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.w, this.y, this.z);
			}
		}

		// Token: 0x17000756 RID: 1878
		// (get) Token: 0x0600179E RID: 6046 RVA: 0x00041FD5 File Offset: 0x000401D5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.w, this.y, this.w);
			}
		}

		// Token: 0x17000757 RID: 1879
		// (get) Token: 0x0600179F RID: 6047 RVA: 0x00041FF4 File Offset: 0x000401F4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.w, this.z, this.x);
			}
		}

		// Token: 0x17000758 RID: 1880
		// (get) Token: 0x060017A0 RID: 6048 RVA: 0x00042013 File Offset: 0x00040213
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.w, this.z, this.y);
			}
		}

		// Token: 0x17000759 RID: 1881
		// (get) Token: 0x060017A1 RID: 6049 RVA: 0x00042032 File Offset: 0x00040232
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.w, this.z, this.z);
			}
		}

		// Token: 0x1700075A RID: 1882
		// (get) Token: 0x060017A2 RID: 6050 RVA: 0x00042051 File Offset: 0x00040251
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.w, this.z, this.w);
			}
		}

		// Token: 0x1700075B RID: 1883
		// (get) Token: 0x060017A3 RID: 6051 RVA: 0x00042070 File Offset: 0x00040270
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.w, this.w, this.x);
			}
		}

		// Token: 0x1700075C RID: 1884
		// (get) Token: 0x060017A4 RID: 6052 RVA: 0x0004208F File Offset: 0x0004028F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.w, this.w, this.y);
			}
		}

		// Token: 0x1700075D RID: 1885
		// (get) Token: 0x060017A5 RID: 6053 RVA: 0x000420AE File Offset: 0x000402AE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.w, this.w, this.z);
			}
		}

		// Token: 0x1700075E RID: 1886
		// (get) Token: 0x060017A6 RID: 6054 RVA: 0x000420CD File Offset: 0x000402CD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 wwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.w, this.w, this.w, this.w);
			}
		}

		// Token: 0x1700075F RID: 1887
		// (get) Token: 0x060017A7 RID: 6055 RVA: 0x000420EC File Offset: 0x000402EC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.x, this.x);
			}
		}

		// Token: 0x17000760 RID: 1888
		// (get) Token: 0x060017A8 RID: 6056 RVA: 0x00042105 File Offset: 0x00040305
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.x, this.y);
			}
		}

		// Token: 0x17000761 RID: 1889
		// (get) Token: 0x060017A9 RID: 6057 RVA: 0x0004211E File Offset: 0x0004031E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.x, this.z);
			}
		}

		// Token: 0x17000762 RID: 1890
		// (get) Token: 0x060017AA RID: 6058 RVA: 0x00042137 File Offset: 0x00040337
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.x, this.w);
			}
		}

		// Token: 0x17000763 RID: 1891
		// (get) Token: 0x060017AB RID: 6059 RVA: 0x00042150 File Offset: 0x00040350
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.y, this.x);
			}
		}

		// Token: 0x17000764 RID: 1892
		// (get) Token: 0x060017AC RID: 6060 RVA: 0x00042169 File Offset: 0x00040369
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.y, this.y);
			}
		}

		// Token: 0x17000765 RID: 1893
		// (get) Token: 0x060017AD RID: 6061 RVA: 0x00042182 File Offset: 0x00040382
		// (set) Token: 0x060017AE RID: 6062 RVA: 0x0004219B File Offset: 0x0004039B
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

		// Token: 0x17000766 RID: 1894
		// (get) Token: 0x060017AF RID: 6063 RVA: 0x000421C1 File Offset: 0x000403C1
		// (set) Token: 0x060017B0 RID: 6064 RVA: 0x000421DA File Offset: 0x000403DA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.y, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x17000767 RID: 1895
		// (get) Token: 0x060017B1 RID: 6065 RVA: 0x00042200 File Offset: 0x00040400
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.z, this.x);
			}
		}

		// Token: 0x17000768 RID: 1896
		// (get) Token: 0x060017B2 RID: 6066 RVA: 0x00042219 File Offset: 0x00040419
		// (set) Token: 0x060017B3 RID: 6067 RVA: 0x00042232 File Offset: 0x00040432
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

		// Token: 0x17000769 RID: 1897
		// (get) Token: 0x060017B4 RID: 6068 RVA: 0x00042258 File Offset: 0x00040458
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.z, this.z);
			}
		}

		// Token: 0x1700076A RID: 1898
		// (get) Token: 0x060017B5 RID: 6069 RVA: 0x00042271 File Offset: 0x00040471
		// (set) Token: 0x060017B6 RID: 6070 RVA: 0x0004228A File Offset: 0x0004048A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.z, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x1700076B RID: 1899
		// (get) Token: 0x060017B7 RID: 6071 RVA: 0x000422B0 File Offset: 0x000404B0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.w, this.x);
			}
		}

		// Token: 0x1700076C RID: 1900
		// (get) Token: 0x060017B8 RID: 6072 RVA: 0x000422C9 File Offset: 0x000404C9
		// (set) Token: 0x060017B9 RID: 6073 RVA: 0x000422E2 File Offset: 0x000404E2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.w, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.w = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x1700076D RID: 1901
		// (get) Token: 0x060017BA RID: 6074 RVA: 0x00042308 File Offset: 0x00040508
		// (set) Token: 0x060017BB RID: 6075 RVA: 0x00042321 File Offset: 0x00040521
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.w, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.w = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x1700076E RID: 1902
		// (get) Token: 0x060017BC RID: 6076 RVA: 0x00042347 File Offset: 0x00040547
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.w, this.w);
			}
		}

		// Token: 0x1700076F RID: 1903
		// (get) Token: 0x060017BD RID: 6077 RVA: 0x00042360 File Offset: 0x00040560
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.x, this.x);
			}
		}

		// Token: 0x17000770 RID: 1904
		// (get) Token: 0x060017BE RID: 6078 RVA: 0x00042379 File Offset: 0x00040579
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.x, this.y);
			}
		}

		// Token: 0x17000771 RID: 1905
		// (get) Token: 0x060017BF RID: 6079 RVA: 0x00042392 File Offset: 0x00040592
		// (set) Token: 0x060017C0 RID: 6080 RVA: 0x000423AB File Offset: 0x000405AB
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

		// Token: 0x17000772 RID: 1906
		// (get) Token: 0x060017C1 RID: 6081 RVA: 0x000423D1 File Offset: 0x000405D1
		// (set) Token: 0x060017C2 RID: 6082 RVA: 0x000423EA File Offset: 0x000405EA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.x, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x17000773 RID: 1907
		// (get) Token: 0x060017C3 RID: 6083 RVA: 0x00042410 File Offset: 0x00040610
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.y, this.x);
			}
		}

		// Token: 0x17000774 RID: 1908
		// (get) Token: 0x060017C4 RID: 6084 RVA: 0x00042429 File Offset: 0x00040629
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.y, this.y);
			}
		}

		// Token: 0x17000775 RID: 1909
		// (get) Token: 0x060017C5 RID: 6085 RVA: 0x00042442 File Offset: 0x00040642
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.y, this.z);
			}
		}

		// Token: 0x17000776 RID: 1910
		// (get) Token: 0x060017C6 RID: 6086 RVA: 0x0004245B File Offset: 0x0004065B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.y, this.w);
			}
		}

		// Token: 0x17000777 RID: 1911
		// (get) Token: 0x060017C7 RID: 6087 RVA: 0x00042474 File Offset: 0x00040674
		// (set) Token: 0x060017C8 RID: 6088 RVA: 0x0004248D File Offset: 0x0004068D
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

		// Token: 0x17000778 RID: 1912
		// (get) Token: 0x060017C9 RID: 6089 RVA: 0x000424B3 File Offset: 0x000406B3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.z, this.y);
			}
		}

		// Token: 0x17000779 RID: 1913
		// (get) Token: 0x060017CA RID: 6090 RVA: 0x000424CC File Offset: 0x000406CC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.z, this.z);
			}
		}

		// Token: 0x1700077A RID: 1914
		// (get) Token: 0x060017CB RID: 6091 RVA: 0x000424E5 File Offset: 0x000406E5
		// (set) Token: 0x060017CC RID: 6092 RVA: 0x000424FE File Offset: 0x000406FE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.z, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x1700077B RID: 1915
		// (get) Token: 0x060017CD RID: 6093 RVA: 0x00042524 File Offset: 0x00040724
		// (set) Token: 0x060017CE RID: 6094 RVA: 0x0004253D File Offset: 0x0004073D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 ywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.w, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.w = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x1700077C RID: 1916
		// (get) Token: 0x060017CF RID: 6095 RVA: 0x00042563 File Offset: 0x00040763
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 ywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.w, this.y);
			}
		}

		// Token: 0x1700077D RID: 1917
		// (get) Token: 0x060017D0 RID: 6096 RVA: 0x0004257C File Offset: 0x0004077C
		// (set) Token: 0x060017D1 RID: 6097 RVA: 0x00042595 File Offset: 0x00040795
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 ywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.w, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.w = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x1700077E RID: 1918
		// (get) Token: 0x060017D2 RID: 6098 RVA: 0x000425BB File Offset: 0x000407BB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.w, this.w);
			}
		}

		// Token: 0x1700077F RID: 1919
		// (get) Token: 0x060017D3 RID: 6099 RVA: 0x000425D4 File Offset: 0x000407D4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.x, this.x);
			}
		}

		// Token: 0x17000780 RID: 1920
		// (get) Token: 0x060017D4 RID: 6100 RVA: 0x000425ED File Offset: 0x000407ED
		// (set) Token: 0x060017D5 RID: 6101 RVA: 0x00042606 File Offset: 0x00040806
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

		// Token: 0x17000781 RID: 1921
		// (get) Token: 0x060017D6 RID: 6102 RVA: 0x0004262C File Offset: 0x0004082C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.x, this.z);
			}
		}

		// Token: 0x17000782 RID: 1922
		// (get) Token: 0x060017D7 RID: 6103 RVA: 0x00042645 File Offset: 0x00040845
		// (set) Token: 0x060017D8 RID: 6104 RVA: 0x0004265E File Offset: 0x0004085E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.x, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x17000783 RID: 1923
		// (get) Token: 0x060017D9 RID: 6105 RVA: 0x00042684 File Offset: 0x00040884
		// (set) Token: 0x060017DA RID: 6106 RVA: 0x0004269D File Offset: 0x0004089D
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

		// Token: 0x17000784 RID: 1924
		// (get) Token: 0x060017DB RID: 6107 RVA: 0x000426C3 File Offset: 0x000408C3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.y, this.y);
			}
		}

		// Token: 0x17000785 RID: 1925
		// (get) Token: 0x060017DC RID: 6108 RVA: 0x000426DC File Offset: 0x000408DC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.y, this.z);
			}
		}

		// Token: 0x17000786 RID: 1926
		// (get) Token: 0x060017DD RID: 6109 RVA: 0x000426F5 File Offset: 0x000408F5
		// (set) Token: 0x060017DE RID: 6110 RVA: 0x0004270E File Offset: 0x0004090E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.y, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x17000787 RID: 1927
		// (get) Token: 0x060017DF RID: 6111 RVA: 0x00042734 File Offset: 0x00040934
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.z, this.x);
			}
		}

		// Token: 0x17000788 RID: 1928
		// (get) Token: 0x060017E0 RID: 6112 RVA: 0x0004274D File Offset: 0x0004094D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.z, this.y);
			}
		}

		// Token: 0x17000789 RID: 1929
		// (get) Token: 0x060017E1 RID: 6113 RVA: 0x00042766 File Offset: 0x00040966
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.z, this.z);
			}
		}

		// Token: 0x1700078A RID: 1930
		// (get) Token: 0x060017E2 RID: 6114 RVA: 0x0004277F File Offset: 0x0004097F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.z, this.w);
			}
		}

		// Token: 0x1700078B RID: 1931
		// (get) Token: 0x060017E3 RID: 6115 RVA: 0x00042798 File Offset: 0x00040998
		// (set) Token: 0x060017E4 RID: 6116 RVA: 0x000427B1 File Offset: 0x000409B1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.w, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.w = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x1700078C RID: 1932
		// (get) Token: 0x060017E5 RID: 6117 RVA: 0x000427D7 File Offset: 0x000409D7
		// (set) Token: 0x060017E6 RID: 6118 RVA: 0x000427F0 File Offset: 0x000409F0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.w, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.w = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x1700078D RID: 1933
		// (get) Token: 0x060017E7 RID: 6119 RVA: 0x00042816 File Offset: 0x00040A16
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.w, this.z);
			}
		}

		// Token: 0x1700078E RID: 1934
		// (get) Token: 0x060017E8 RID: 6120 RVA: 0x0004282F File Offset: 0x00040A2F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 zww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.z, this.w, this.w);
			}
		}

		// Token: 0x1700078F RID: 1935
		// (get) Token: 0x060017E9 RID: 6121 RVA: 0x00042848 File Offset: 0x00040A48
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 wxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.w, this.x, this.x);
			}
		}

		// Token: 0x17000790 RID: 1936
		// (get) Token: 0x060017EA RID: 6122 RVA: 0x00042861 File Offset: 0x00040A61
		// (set) Token: 0x060017EB RID: 6123 RVA: 0x0004287A File Offset: 0x00040A7A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 wxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.w, this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.x = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x17000791 RID: 1937
		// (get) Token: 0x060017EC RID: 6124 RVA: 0x000428A0 File Offset: 0x00040AA0
		// (set) Token: 0x060017ED RID: 6125 RVA: 0x000428B9 File Offset: 0x00040AB9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 wxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.w, this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.x = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x17000792 RID: 1938
		// (get) Token: 0x060017EE RID: 6126 RVA: 0x000428DF File Offset: 0x00040ADF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 wxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.w, this.x, this.w);
			}
		}

		// Token: 0x17000793 RID: 1939
		// (get) Token: 0x060017EF RID: 6127 RVA: 0x000428F8 File Offset: 0x00040AF8
		// (set) Token: 0x060017F0 RID: 6128 RVA: 0x00042911 File Offset: 0x00040B11
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 wyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.w, this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.y = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x17000794 RID: 1940
		// (get) Token: 0x060017F1 RID: 6129 RVA: 0x00042937 File Offset: 0x00040B37
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 wyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.w, this.y, this.y);
			}
		}

		// Token: 0x17000795 RID: 1941
		// (get) Token: 0x060017F2 RID: 6130 RVA: 0x00042950 File Offset: 0x00040B50
		// (set) Token: 0x060017F3 RID: 6131 RVA: 0x00042969 File Offset: 0x00040B69
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 wyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.w, this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.y = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x17000796 RID: 1942
		// (get) Token: 0x060017F4 RID: 6132 RVA: 0x0004298F File Offset: 0x00040B8F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 wyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.w, this.y, this.w);
			}
		}

		// Token: 0x17000797 RID: 1943
		// (get) Token: 0x060017F5 RID: 6133 RVA: 0x000429A8 File Offset: 0x00040BA8
		// (set) Token: 0x060017F6 RID: 6134 RVA: 0x000429C1 File Offset: 0x00040BC1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 wzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.w, this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.z = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x17000798 RID: 1944
		// (get) Token: 0x060017F7 RID: 6135 RVA: 0x000429E7 File Offset: 0x00040BE7
		// (set) Token: 0x060017F8 RID: 6136 RVA: 0x00042A00 File Offset: 0x00040C00
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 wzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.w, this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.z = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x17000799 RID: 1945
		// (get) Token: 0x060017F9 RID: 6137 RVA: 0x00042A26 File Offset: 0x00040C26
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 wzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.w, this.z, this.z);
			}
		}

		// Token: 0x1700079A RID: 1946
		// (get) Token: 0x060017FA RID: 6138 RVA: 0x00042A3F File Offset: 0x00040C3F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 wzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.w, this.z, this.w);
			}
		}

		// Token: 0x1700079B RID: 1947
		// (get) Token: 0x060017FB RID: 6139 RVA: 0x00042A58 File Offset: 0x00040C58
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 wwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.w, this.w, this.x);
			}
		}

		// Token: 0x1700079C RID: 1948
		// (get) Token: 0x060017FC RID: 6140 RVA: 0x00042A71 File Offset: 0x00040C71
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 wwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.w, this.w, this.y);
			}
		}

		// Token: 0x1700079D RID: 1949
		// (get) Token: 0x060017FD RID: 6141 RVA: 0x00042A8A File Offset: 0x00040C8A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 wwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.w, this.w, this.z);
			}
		}

		// Token: 0x1700079E RID: 1950
		// (get) Token: 0x060017FE RID: 6142 RVA: 0x00042AA3 File Offset: 0x00040CA3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 www
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.w, this.w, this.w);
			}
		}

		// Token: 0x1700079F RID: 1951
		// (get) Token: 0x060017FF RID: 6143 RVA: 0x00042ABC File Offset: 0x00040CBC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.x, this.x);
			}
		}

		// Token: 0x170007A0 RID: 1952
		// (get) Token: 0x06001800 RID: 6144 RVA: 0x00042ACF File Offset: 0x00040CCF
		// (set) Token: 0x06001801 RID: 6145 RVA: 0x00042AE2 File Offset: 0x00040CE2
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

		// Token: 0x170007A1 RID: 1953
		// (get) Token: 0x06001802 RID: 6146 RVA: 0x00042AFC File Offset: 0x00040CFC
		// (set) Token: 0x06001803 RID: 6147 RVA: 0x00042B0F File Offset: 0x00040D0F
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

		// Token: 0x170007A2 RID: 1954
		// (get) Token: 0x06001804 RID: 6148 RVA: 0x00042B29 File Offset: 0x00040D29
		// (set) Token: 0x06001805 RID: 6149 RVA: 0x00042B3C File Offset: 0x00040D3C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 xw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.x, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.w = value.y;
			}
		}

		// Token: 0x170007A3 RID: 1955
		// (get) Token: 0x06001806 RID: 6150 RVA: 0x00042B56 File Offset: 0x00040D56
		// (set) Token: 0x06001807 RID: 6151 RVA: 0x00042B69 File Offset: 0x00040D69
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

		// Token: 0x170007A4 RID: 1956
		// (get) Token: 0x06001808 RID: 6152 RVA: 0x00042B83 File Offset: 0x00040D83
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 yy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.y, this.y);
			}
		}

		// Token: 0x170007A5 RID: 1957
		// (get) Token: 0x06001809 RID: 6153 RVA: 0x00042B96 File Offset: 0x00040D96
		// (set) Token: 0x0600180A RID: 6154 RVA: 0x00042BA9 File Offset: 0x00040DA9
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

		// Token: 0x170007A6 RID: 1958
		// (get) Token: 0x0600180B RID: 6155 RVA: 0x00042BC3 File Offset: 0x00040DC3
		// (set) Token: 0x0600180C RID: 6156 RVA: 0x00042BD6 File Offset: 0x00040DD6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 yw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.y, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.w = value.y;
			}
		}

		// Token: 0x170007A7 RID: 1959
		// (get) Token: 0x0600180D RID: 6157 RVA: 0x00042BF0 File Offset: 0x00040DF0
		// (set) Token: 0x0600180E RID: 6158 RVA: 0x00042C03 File Offset: 0x00040E03
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

		// Token: 0x170007A8 RID: 1960
		// (get) Token: 0x0600180F RID: 6159 RVA: 0x00042C1D File Offset: 0x00040E1D
		// (set) Token: 0x06001810 RID: 6160 RVA: 0x00042C30 File Offset: 0x00040E30
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

		// Token: 0x170007A9 RID: 1961
		// (get) Token: 0x06001811 RID: 6161 RVA: 0x00042C4A File Offset: 0x00040E4A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 zz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.z, this.z);
			}
		}

		// Token: 0x170007AA RID: 1962
		// (get) Token: 0x06001812 RID: 6162 RVA: 0x00042C5D File Offset: 0x00040E5D
		// (set) Token: 0x06001813 RID: 6163 RVA: 0x00042C70 File Offset: 0x00040E70
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 zw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.z, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.w = value.y;
			}
		}

		// Token: 0x170007AB RID: 1963
		// (get) Token: 0x06001814 RID: 6164 RVA: 0x00042C8A File Offset: 0x00040E8A
		// (set) Token: 0x06001815 RID: 6165 RVA: 0x00042C9D File Offset: 0x00040E9D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 wx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.w, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x170007AC RID: 1964
		// (get) Token: 0x06001816 RID: 6166 RVA: 0x00042CB7 File Offset: 0x00040EB7
		// (set) Token: 0x06001817 RID: 6167 RVA: 0x00042CCA File Offset: 0x00040ECA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 wy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.w, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x170007AD RID: 1965
		// (get) Token: 0x06001818 RID: 6168 RVA: 0x00042CE4 File Offset: 0x00040EE4
		// (set) Token: 0x06001819 RID: 6169 RVA: 0x00042CF7 File Offset: 0x00040EF7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 wz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.w, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.z = value.y;
			}
		}

		// Token: 0x170007AE RID: 1966
		// (get) Token: 0x0600181A RID: 6170 RVA: 0x00042D11 File Offset: 0x00040F11
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 ww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.w, this.w);
			}
		}

		// Token: 0x170007AF RID: 1967
		public unsafe half this[int index]
		{
			get
			{
				fixed (half4* ptr = &this)
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

		// Token: 0x0600181D RID: 6173 RVA: 0x00042D70 File Offset: 0x00040F70
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(half4 rhs)
		{
			return this.x == rhs.x && this.y == rhs.y && this.z == rhs.z && this.w == rhs.w;
		}

		// Token: 0x0600181E RID: 6174 RVA: 0x00042DCC File Offset: 0x00040FCC
		public override bool Equals(object o)
		{
			if (o is half4)
			{
				half4 rhs = (half4)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x0600181F RID: 6175 RVA: 0x00042DF1 File Offset: 0x00040FF1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06001820 RID: 6176 RVA: 0x00042E00 File Offset: 0x00041000
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("half4({0}, {1}, {2}, {3})", new object[]
			{
				this.x,
				this.y,
				this.z,
				this.w
			});
		}

		// Token: 0x06001821 RID: 6177 RVA: 0x00042E58 File Offset: 0x00041058
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("half4({0}, {1}, {2}, {3})", new object[]
			{
				this.x.ToString(format, formatProvider),
				this.y.ToString(format, formatProvider),
				this.z.ToString(format, formatProvider),
				this.w.ToString(format, formatProvider)
			});
		}

		// Token: 0x040000AA RID: 170
		public half x;

		// Token: 0x040000AB RID: 171
		public half y;

		// Token: 0x040000AC RID: 172
		public half z;

		// Token: 0x040000AD RID: 173
		public half w;

		// Token: 0x040000AE RID: 174
		public static readonly half4 zero;

		// Token: 0x0200005F RID: 95
		internal sealed class DebuggerProxy
		{
			// Token: 0x06002474 RID: 9332 RVA: 0x000676D0 File Offset: 0x000658D0
			public DebuggerProxy(half4 v)
			{
				this.x = v.x;
				this.y = v.y;
				this.z = v.z;
				this.w = v.w;
			}

			// Token: 0x0400015A RID: 346
			public half x;

			// Token: 0x0400015B RID: 347
			public half y;

			// Token: 0x0400015C RID: 348
			public half z;

			// Token: 0x0400015D RID: 349
			public half w;
		}
	}
}
