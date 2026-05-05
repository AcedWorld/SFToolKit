using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x0200002A RID: 42
	[DebuggerTypeProxy(typeof(half2.DebuggerProxy))]
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct half2 : IEquatable<half2>, IFormattable
	{
		// Token: 0x060015A4 RID: 5540 RVA: 0x0003E0F4 File Offset: 0x0003C2F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half2(half x, half y)
		{
			this.x = x;
			this.y = y;
		}

		// Token: 0x060015A5 RID: 5541 RVA: 0x0003E104 File Offset: 0x0003C304
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half2(half2 xy)
		{
			this.x = xy.x;
			this.y = xy.y;
		}

		// Token: 0x060015A6 RID: 5542 RVA: 0x0003E11E File Offset: 0x0003C31E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half2(half v)
		{
			this.x = v;
			this.y = v;
		}

		// Token: 0x060015A7 RID: 5543 RVA: 0x0003E12E File Offset: 0x0003C32E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half2(float v)
		{
			this.x = (half)v;
			this.y = (half)v;
		}

		// Token: 0x060015A8 RID: 5544 RVA: 0x0003E148 File Offset: 0x0003C348
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half2(float2 v)
		{
			this.x = (half)v.x;
			this.y = (half)v.y;
		}

		// Token: 0x060015A9 RID: 5545 RVA: 0x0003E16C File Offset: 0x0003C36C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half2(double v)
		{
			this.x = (half)v;
			this.y = (half)v;
		}

		// Token: 0x060015AA RID: 5546 RVA: 0x0003E186 File Offset: 0x0003C386
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half2(double2 v)
		{
			this.x = (half)v.x;
			this.y = (half)v.y;
		}

		// Token: 0x060015AB RID: 5547 RVA: 0x0003E1AA File Offset: 0x0003C3AA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator half2(half v)
		{
			return new half2(v);
		}

		// Token: 0x060015AC RID: 5548 RVA: 0x0003E1B2 File Offset: 0x0003C3B2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator half2(float v)
		{
			return new half2(v);
		}

		// Token: 0x060015AD RID: 5549 RVA: 0x0003E1BA File Offset: 0x0003C3BA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator half2(float2 v)
		{
			return new half2(v);
		}

		// Token: 0x060015AE RID: 5550 RVA: 0x0003E1C2 File Offset: 0x0003C3C2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator half2(double v)
		{
			return new half2(v);
		}

		// Token: 0x060015AF RID: 5551 RVA: 0x0003E1CA File Offset: 0x0003C3CA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator half2(double2 v)
		{
			return new half2(v);
		}

		// Token: 0x060015B0 RID: 5552 RVA: 0x0003E1D2 File Offset: 0x0003C3D2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(half2 lhs, half2 rhs)
		{
			return new bool2(lhs.x == rhs.x, lhs.y == rhs.y);
		}

		// Token: 0x060015B1 RID: 5553 RVA: 0x0003E1FB File Offset: 0x0003C3FB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(half2 lhs, half rhs)
		{
			return new bool2(lhs.x == rhs, lhs.y == rhs);
		}

		// Token: 0x060015B2 RID: 5554 RVA: 0x0003E21A File Offset: 0x0003C41A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(half lhs, half2 rhs)
		{
			return new bool2(lhs == rhs.x, lhs == rhs.y);
		}

		// Token: 0x060015B3 RID: 5555 RVA: 0x0003E239 File Offset: 0x0003C439
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(half2 lhs, half2 rhs)
		{
			return new bool2(lhs.x != rhs.x, lhs.y != rhs.y);
		}

		// Token: 0x060015B4 RID: 5556 RVA: 0x0003E262 File Offset: 0x0003C462
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(half2 lhs, half rhs)
		{
			return new bool2(lhs.x != rhs, lhs.y != rhs);
		}

		// Token: 0x060015B5 RID: 5557 RVA: 0x0003E281 File Offset: 0x0003C481
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(half lhs, half2 rhs)
		{
			return new bool2(lhs != rhs.x, lhs != rhs.y);
		}

		// Token: 0x170005CC RID: 1484
		// (get) Token: 0x060015B6 RID: 5558 RVA: 0x0003E2A0 File Offset: 0x0003C4A0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.x, this.x);
			}
		}

		// Token: 0x170005CD RID: 1485
		// (get) Token: 0x060015B7 RID: 5559 RVA: 0x0003E2BF File Offset: 0x0003C4BF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.x, this.y);
			}
		}

		// Token: 0x170005CE RID: 1486
		// (get) Token: 0x060015B8 RID: 5560 RVA: 0x0003E2DE File Offset: 0x0003C4DE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.y, this.x);
			}
		}

		// Token: 0x170005CF RID: 1487
		// (get) Token: 0x060015B9 RID: 5561 RVA: 0x0003E2FD File Offset: 0x0003C4FD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.x, this.y, this.y);
			}
		}

		// Token: 0x170005D0 RID: 1488
		// (get) Token: 0x060015BA RID: 5562 RVA: 0x0003E31C File Offset: 0x0003C51C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.x, this.x);
			}
		}

		// Token: 0x170005D1 RID: 1489
		// (get) Token: 0x060015BB RID: 5563 RVA: 0x0003E33B File Offset: 0x0003C53B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.x, this.y);
			}
		}

		// Token: 0x170005D2 RID: 1490
		// (get) Token: 0x060015BC RID: 5564 RVA: 0x0003E35A File Offset: 0x0003C55A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.y, this.x);
			}
		}

		// Token: 0x170005D3 RID: 1491
		// (get) Token: 0x060015BD RID: 5565 RVA: 0x0003E379 File Offset: 0x0003C579
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.x, this.y, this.y, this.y);
			}
		}

		// Token: 0x170005D4 RID: 1492
		// (get) Token: 0x060015BE RID: 5566 RVA: 0x0003E398 File Offset: 0x0003C598
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.x, this.x);
			}
		}

		// Token: 0x170005D5 RID: 1493
		// (get) Token: 0x060015BF RID: 5567 RVA: 0x0003E3B7 File Offset: 0x0003C5B7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.x, this.y);
			}
		}

		// Token: 0x170005D6 RID: 1494
		// (get) Token: 0x060015C0 RID: 5568 RVA: 0x0003E3D6 File Offset: 0x0003C5D6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.y, this.x);
			}
		}

		// Token: 0x170005D7 RID: 1495
		// (get) Token: 0x060015C1 RID: 5569 RVA: 0x0003E3F5 File Offset: 0x0003C5F5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.x, this.y, this.y);
			}
		}

		// Token: 0x170005D8 RID: 1496
		// (get) Token: 0x060015C2 RID: 5570 RVA: 0x0003E414 File Offset: 0x0003C614
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.x, this.x);
			}
		}

		// Token: 0x170005D9 RID: 1497
		// (get) Token: 0x060015C3 RID: 5571 RVA: 0x0003E433 File Offset: 0x0003C633
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.x, this.y);
			}
		}

		// Token: 0x170005DA RID: 1498
		// (get) Token: 0x060015C4 RID: 5572 RVA: 0x0003E452 File Offset: 0x0003C652
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.y, this.x);
			}
		}

		// Token: 0x170005DB RID: 1499
		// (get) Token: 0x060015C5 RID: 5573 RVA: 0x0003E471 File Offset: 0x0003C671
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half4 yyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half4(this.y, this.y, this.y, this.y);
			}
		}

		// Token: 0x170005DC RID: 1500
		// (get) Token: 0x060015C6 RID: 5574 RVA: 0x0003E490 File Offset: 0x0003C690
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.x, this.x);
			}
		}

		// Token: 0x170005DD RID: 1501
		// (get) Token: 0x060015C7 RID: 5575 RVA: 0x0003E4A9 File Offset: 0x0003C6A9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.x, this.y);
			}
		}

		// Token: 0x170005DE RID: 1502
		// (get) Token: 0x060015C8 RID: 5576 RVA: 0x0003E4C2 File Offset: 0x0003C6C2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.y, this.x);
			}
		}

		// Token: 0x170005DF RID: 1503
		// (get) Token: 0x060015C9 RID: 5577 RVA: 0x0003E4DB File Offset: 0x0003C6DB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 xyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.x, this.y, this.y);
			}
		}

		// Token: 0x170005E0 RID: 1504
		// (get) Token: 0x060015CA RID: 5578 RVA: 0x0003E4F4 File Offset: 0x0003C6F4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.x, this.x);
			}
		}

		// Token: 0x170005E1 RID: 1505
		// (get) Token: 0x060015CB RID: 5579 RVA: 0x0003E50D File Offset: 0x0003C70D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.x, this.y);
			}
		}

		// Token: 0x170005E2 RID: 1506
		// (get) Token: 0x060015CC RID: 5580 RVA: 0x0003E526 File Offset: 0x0003C726
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.y, this.x);
			}
		}

		// Token: 0x170005E3 RID: 1507
		// (get) Token: 0x060015CD RID: 5581 RVA: 0x0003E53F File Offset: 0x0003C73F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half3 yyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half3(this.y, this.y, this.y);
			}
		}

		// Token: 0x170005E4 RID: 1508
		// (get) Token: 0x060015CE RID: 5582 RVA: 0x0003E558 File Offset: 0x0003C758
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.x, this.x);
			}
		}

		// Token: 0x170005E5 RID: 1509
		// (get) Token: 0x060015CF RID: 5583 RVA: 0x0003E56B File Offset: 0x0003C76B
		// (set) Token: 0x060015D0 RID: 5584 RVA: 0x0003E57E File Offset: 0x0003C77E
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

		// Token: 0x170005E6 RID: 1510
		// (get) Token: 0x060015D1 RID: 5585 RVA: 0x0003E598 File Offset: 0x0003C798
		// (set) Token: 0x060015D2 RID: 5586 RVA: 0x0003E5AB File Offset: 0x0003C7AB
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

		// Token: 0x170005E7 RID: 1511
		// (get) Token: 0x060015D3 RID: 5587 RVA: 0x0003E5C5 File Offset: 0x0003C7C5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public half2 yy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new half2(this.y, this.y);
			}
		}

		// Token: 0x170005E8 RID: 1512
		public unsafe half this[int index]
		{
			get
			{
				fixed (half2* ptr = &this)
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

		// Token: 0x060015D6 RID: 5590 RVA: 0x0003E621 File Offset: 0x0003C821
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(half2 rhs)
		{
			return this.x == rhs.x && this.y == rhs.y;
		}

		// Token: 0x060015D7 RID: 5591 RVA: 0x0003E64C File Offset: 0x0003C84C
		public override bool Equals(object o)
		{
			if (o is half2)
			{
				half2 rhs = (half2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x060015D8 RID: 5592 RVA: 0x0003E671 File Offset: 0x0003C871
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x060015D9 RID: 5593 RVA: 0x0003E67E File Offset: 0x0003C87E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("half2({0}, {1})", this.x, this.y);
		}

		// Token: 0x060015DA RID: 5594 RVA: 0x0003E6A0 File Offset: 0x0003C8A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("half2({0}, {1})", this.x.ToString(format, formatProvider), this.y.ToString(format, formatProvider));
		}

		// Token: 0x040000A3 RID: 163
		public half x;

		// Token: 0x040000A4 RID: 164
		public half y;

		// Token: 0x040000A5 RID: 165
		public static readonly half2 zero;

		// Token: 0x0200005D RID: 93
		internal sealed class DebuggerProxy
		{
			// Token: 0x06002472 RID: 9330 RVA: 0x00067684 File Offset: 0x00065884
			public DebuggerProxy(half2 v)
			{
				this.x = v.x;
				this.y = v.y;
			}

			// Token: 0x04000155 RID: 341
			public half x;

			// Token: 0x04000156 RID: 342
			public half y;
		}
	}
}
