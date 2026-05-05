using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000029 RID: 41
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct half : IEquatable<half>, IFormattable
	{
		// Token: 0x170005C8 RID: 1480
		// (get) Token: 0x06001591 RID: 5521 RVA: 0x0003DFCF File Offset: 0x0003C1CF
		public static float MaxValue
		{
			get
			{
				return 65504f;
			}
		}

		// Token: 0x170005C9 RID: 1481
		// (get) Token: 0x06001592 RID: 5522 RVA: 0x0003DFD6 File Offset: 0x0003C1D6
		public static float MinValue
		{
			get
			{
				return -65504f;
			}
		}

		// Token: 0x170005CA RID: 1482
		// (get) Token: 0x06001593 RID: 5523 RVA: 0x0003DFDD File Offset: 0x0003C1DD
		public static half MaxValueAsHalf
		{
			get
			{
				return new half(half.MaxValue);
			}
		}

		// Token: 0x170005CB RID: 1483
		// (get) Token: 0x06001594 RID: 5524 RVA: 0x0003DFE9 File Offset: 0x0003C1E9
		public static half MinValueAsHalf
		{
			get
			{
				return new half(half.MinValue);
			}
		}

		// Token: 0x06001595 RID: 5525 RVA: 0x0003DFF5 File Offset: 0x0003C1F5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half(half x)
		{
			this.value = x.value;
		}

		// Token: 0x06001596 RID: 5526 RVA: 0x0003E003 File Offset: 0x0003C203
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half(float v)
		{
			this.value = (ushort)math.f32tof16(v);
		}

		// Token: 0x06001597 RID: 5527 RVA: 0x0003E012 File Offset: 0x0003C212
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public half(double v)
		{
			this.value = (ushort)math.f32tof16((float)v);
		}

		// Token: 0x06001598 RID: 5528 RVA: 0x0003E022 File Offset: 0x0003C222
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator half(float v)
		{
			return new half(v);
		}

		// Token: 0x06001599 RID: 5529 RVA: 0x0003E02A File Offset: 0x0003C22A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator half(double v)
		{
			return new half(v);
		}

		// Token: 0x0600159A RID: 5530 RVA: 0x0003E032 File Offset: 0x0003C232
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float(half d)
		{
			return math.f16tof32((uint)d.value);
		}

		// Token: 0x0600159B RID: 5531 RVA: 0x0003E03F File Offset: 0x0003C23F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double(half d)
		{
			return (double)math.f16tof32((uint)d.value);
		}

		// Token: 0x0600159C RID: 5532 RVA: 0x0003E04D File Offset: 0x0003C24D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(half lhs, half rhs)
		{
			return lhs.value == rhs.value;
		}

		// Token: 0x0600159D RID: 5533 RVA: 0x0003E05D File Offset: 0x0003C25D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(half lhs, half rhs)
		{
			return lhs.value != rhs.value;
		}

		// Token: 0x0600159E RID: 5534 RVA: 0x0003E070 File Offset: 0x0003C270
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(half rhs)
		{
			return this.value == rhs.value;
		}

		// Token: 0x0600159F RID: 5535 RVA: 0x0003E080 File Offset: 0x0003C280
		public override bool Equals(object o)
		{
			if (o is half)
			{
				half rhs = (half)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x060015A0 RID: 5536 RVA: 0x0003E0A5 File Offset: 0x0003C2A5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)this.value;
		}

		// Token: 0x060015A1 RID: 5537 RVA: 0x0003E0B0 File Offset: 0x0003C2B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return math.f16tof32((uint)this.value).ToString();
		}

		// Token: 0x060015A2 RID: 5538 RVA: 0x0003E0D0 File Offset: 0x0003C2D0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return math.f16tof32((uint)this.value).ToString(format, formatProvider);
		}

		// Token: 0x040000A1 RID: 161
		public ushort value;

		// Token: 0x040000A2 RID: 162
		public static readonly half zero;
	}
}
