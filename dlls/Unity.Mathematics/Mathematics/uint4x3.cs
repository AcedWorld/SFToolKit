using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000049 RID: 73
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct uint4x3 : IEquatable<uint4x3>, IFormattable
	{
		// Token: 0x060023AE RID: 9134 RVA: 0x00064BF9 File Offset: 0x00062DF9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x3(uint4 c0, uint4 c1, uint4 c2)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
		}

		// Token: 0x060023AF RID: 9135 RVA: 0x00064C10 File Offset: 0x00062E10
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x3(uint m00, uint m01, uint m02, uint m10, uint m11, uint m12, uint m20, uint m21, uint m22, uint m30, uint m31, uint m32)
		{
			this.c0 = new uint4(m00, m10, m20, m30);
			this.c1 = new uint4(m01, m11, m21, m31);
			this.c2 = new uint4(m02, m12, m22, m32);
		}

		// Token: 0x060023B0 RID: 9136 RVA: 0x00064C48 File Offset: 0x00062E48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x3(uint v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x060023B1 RID: 9137 RVA: 0x00064C70 File Offset: 0x00062E70
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x3(bool v)
		{
			this.c0 = math.select(new uint4(0U), new uint4(1U), v);
			this.c1 = math.select(new uint4(0U), new uint4(1U), v);
			this.c2 = math.select(new uint4(0U), new uint4(1U), v);
		}

		// Token: 0x060023B2 RID: 9138 RVA: 0x00064CC8 File Offset: 0x00062EC8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x3(bool4x3 v)
		{
			this.c0 = math.select(new uint4(0U), new uint4(1U), v.c0);
			this.c1 = math.select(new uint4(0U), new uint4(1U), v.c1);
			this.c2 = math.select(new uint4(0U), new uint4(1U), v.c2);
		}

		// Token: 0x060023B3 RID: 9139 RVA: 0x00064D2C File Offset: 0x00062F2C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x3(int v)
		{
			this.c0 = (uint4)v;
			this.c1 = (uint4)v;
			this.c2 = (uint4)v;
		}

		// Token: 0x060023B4 RID: 9140 RVA: 0x00064D52 File Offset: 0x00062F52
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x3(int4x3 v)
		{
			this.c0 = (uint4)v.c0;
			this.c1 = (uint4)v.c1;
			this.c2 = (uint4)v.c2;
		}

		// Token: 0x060023B5 RID: 9141 RVA: 0x00064D87 File Offset: 0x00062F87
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x3(float v)
		{
			this.c0 = (uint4)v;
			this.c1 = (uint4)v;
			this.c2 = (uint4)v;
		}

		// Token: 0x060023B6 RID: 9142 RVA: 0x00064DAD File Offset: 0x00062FAD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x3(float4x3 v)
		{
			this.c0 = (uint4)v.c0;
			this.c1 = (uint4)v.c1;
			this.c2 = (uint4)v.c2;
		}

		// Token: 0x060023B7 RID: 9143 RVA: 0x00064DE2 File Offset: 0x00062FE2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x3(double v)
		{
			this.c0 = (uint4)v;
			this.c1 = (uint4)v;
			this.c2 = (uint4)v;
		}

		// Token: 0x060023B8 RID: 9144 RVA: 0x00064E08 File Offset: 0x00063008
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x3(double4x3 v)
		{
			this.c0 = (uint4)v.c0;
			this.c1 = (uint4)v.c1;
			this.c2 = (uint4)v.c2;
		}

		// Token: 0x060023B9 RID: 9145 RVA: 0x00064E3D File Offset: 0x0006303D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator uint4x3(uint v)
		{
			return new uint4x3(v);
		}

		// Token: 0x060023BA RID: 9146 RVA: 0x00064E45 File Offset: 0x00063045
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x3(bool v)
		{
			return new uint4x3(v);
		}

		// Token: 0x060023BB RID: 9147 RVA: 0x00064E4D File Offset: 0x0006304D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x3(bool4x3 v)
		{
			return new uint4x3(v);
		}

		// Token: 0x060023BC RID: 9148 RVA: 0x00064E55 File Offset: 0x00063055
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x3(int v)
		{
			return new uint4x3(v);
		}

		// Token: 0x060023BD RID: 9149 RVA: 0x00064E5D File Offset: 0x0006305D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x3(int4x3 v)
		{
			return new uint4x3(v);
		}

		// Token: 0x060023BE RID: 9150 RVA: 0x00064E65 File Offset: 0x00063065
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x3(float v)
		{
			return new uint4x3(v);
		}

		// Token: 0x060023BF RID: 9151 RVA: 0x00064E6D File Offset: 0x0006306D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x3(float4x3 v)
		{
			return new uint4x3(v);
		}

		// Token: 0x060023C0 RID: 9152 RVA: 0x00064E75 File Offset: 0x00063075
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x3(double v)
		{
			return new uint4x3(v);
		}

		// Token: 0x060023C1 RID: 9153 RVA: 0x00064E7D File Offset: 0x0006307D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x3(double4x3 v)
		{
			return new uint4x3(v);
		}

		// Token: 0x060023C2 RID: 9154 RVA: 0x00064E85 File Offset: 0x00063085
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator *(uint4x3 lhs, uint4x3 rhs)
		{
			return new uint4x3(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2);
		}

		// Token: 0x060023C3 RID: 9155 RVA: 0x00064EBF File Offset: 0x000630BF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator *(uint4x3 lhs, uint rhs)
		{
			return new uint4x3(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs);
		}

		// Token: 0x060023C4 RID: 9156 RVA: 0x00064EEA File Offset: 0x000630EA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator *(uint lhs, uint4x3 rhs)
		{
			return new uint4x3(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2);
		}

		// Token: 0x060023C5 RID: 9157 RVA: 0x00064F15 File Offset: 0x00063115
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator +(uint4x3 lhs, uint4x3 rhs)
		{
			return new uint4x3(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2);
		}

		// Token: 0x060023C6 RID: 9158 RVA: 0x00064F4F File Offset: 0x0006314F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator +(uint4x3 lhs, uint rhs)
		{
			return new uint4x3(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs);
		}

		// Token: 0x060023C7 RID: 9159 RVA: 0x00064F7A File Offset: 0x0006317A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator +(uint lhs, uint4x3 rhs)
		{
			return new uint4x3(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2);
		}

		// Token: 0x060023C8 RID: 9160 RVA: 0x00064FA5 File Offset: 0x000631A5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator -(uint4x3 lhs, uint4x3 rhs)
		{
			return new uint4x3(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2);
		}

		// Token: 0x060023C9 RID: 9161 RVA: 0x00064FDF File Offset: 0x000631DF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator -(uint4x3 lhs, uint rhs)
		{
			return new uint4x3(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs);
		}

		// Token: 0x060023CA RID: 9162 RVA: 0x0006500A File Offset: 0x0006320A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator -(uint lhs, uint4x3 rhs)
		{
			return new uint4x3(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2);
		}

		// Token: 0x060023CB RID: 9163 RVA: 0x00065035 File Offset: 0x00063235
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator /(uint4x3 lhs, uint4x3 rhs)
		{
			return new uint4x3(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2);
		}

		// Token: 0x060023CC RID: 9164 RVA: 0x0006506F File Offset: 0x0006326F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator /(uint4x3 lhs, uint rhs)
		{
			return new uint4x3(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs);
		}

		// Token: 0x060023CD RID: 9165 RVA: 0x0006509A File Offset: 0x0006329A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator /(uint lhs, uint4x3 rhs)
		{
			return new uint4x3(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2);
		}

		// Token: 0x060023CE RID: 9166 RVA: 0x000650C5 File Offset: 0x000632C5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator %(uint4x3 lhs, uint4x3 rhs)
		{
			return new uint4x3(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2);
		}

		// Token: 0x060023CF RID: 9167 RVA: 0x000650FF File Offset: 0x000632FF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator %(uint4x3 lhs, uint rhs)
		{
			return new uint4x3(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs);
		}

		// Token: 0x060023D0 RID: 9168 RVA: 0x0006512A File Offset: 0x0006332A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator %(uint lhs, uint4x3 rhs)
		{
			return new uint4x3(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2);
		}

		// Token: 0x060023D1 RID: 9169 RVA: 0x00065158 File Offset: 0x00063358
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator ++(uint4x3 val)
		{
			uint4 @uint = ++val.c0;
			val.c0 = @uint;
			uint4 uint2 = @uint;
			@uint = ++val.c1;
			val.c1 = @uint;
			uint4 uint3 = @uint;
			@uint = ++val.c2;
			val.c2 = @uint;
			return new uint4x3(uint2, uint3, @uint);
		}

		// Token: 0x060023D2 RID: 9170 RVA: 0x000651B8 File Offset: 0x000633B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator --(uint4x3 val)
		{
			uint4 @uint = --val.c0;
			val.c0 = @uint;
			uint4 uint2 = @uint;
			@uint = --val.c1;
			val.c1 = @uint;
			uint4 uint3 = @uint;
			@uint = --val.c2;
			val.c2 = @uint;
			return new uint4x3(uint2, uint3, @uint);
		}

		// Token: 0x060023D3 RID: 9171 RVA: 0x00065218 File Offset: 0x00063418
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <(uint4x3 lhs, uint4x3 rhs)
		{
			return new bool4x3(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2);
		}

		// Token: 0x060023D4 RID: 9172 RVA: 0x00065252 File Offset: 0x00063452
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <(uint4x3 lhs, uint rhs)
		{
			return new bool4x3(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs);
		}

		// Token: 0x060023D5 RID: 9173 RVA: 0x0006527D File Offset: 0x0006347D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <(uint lhs, uint4x3 rhs)
		{
			return new bool4x3(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2);
		}

		// Token: 0x060023D6 RID: 9174 RVA: 0x000652A8 File Offset: 0x000634A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <=(uint4x3 lhs, uint4x3 rhs)
		{
			return new bool4x3(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2);
		}

		// Token: 0x060023D7 RID: 9175 RVA: 0x000652E2 File Offset: 0x000634E2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <=(uint4x3 lhs, uint rhs)
		{
			return new bool4x3(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs);
		}

		// Token: 0x060023D8 RID: 9176 RVA: 0x0006530D File Offset: 0x0006350D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <=(uint lhs, uint4x3 rhs)
		{
			return new bool4x3(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2);
		}

		// Token: 0x060023D9 RID: 9177 RVA: 0x00065338 File Offset: 0x00063538
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >(uint4x3 lhs, uint4x3 rhs)
		{
			return new bool4x3(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2);
		}

		// Token: 0x060023DA RID: 9178 RVA: 0x00065372 File Offset: 0x00063572
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >(uint4x3 lhs, uint rhs)
		{
			return new bool4x3(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs);
		}

		// Token: 0x060023DB RID: 9179 RVA: 0x0006539D File Offset: 0x0006359D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >(uint lhs, uint4x3 rhs)
		{
			return new bool4x3(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2);
		}

		// Token: 0x060023DC RID: 9180 RVA: 0x000653C8 File Offset: 0x000635C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >=(uint4x3 lhs, uint4x3 rhs)
		{
			return new bool4x3(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2);
		}

		// Token: 0x060023DD RID: 9181 RVA: 0x00065402 File Offset: 0x00063602
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >=(uint4x3 lhs, uint rhs)
		{
			return new bool4x3(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs);
		}

		// Token: 0x060023DE RID: 9182 RVA: 0x0006542D File Offset: 0x0006362D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >=(uint lhs, uint4x3 rhs)
		{
			return new bool4x3(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2);
		}

		// Token: 0x060023DF RID: 9183 RVA: 0x00065458 File Offset: 0x00063658
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator -(uint4x3 val)
		{
			return new uint4x3(-val.c0, -val.c1, -val.c2);
		}

		// Token: 0x060023E0 RID: 9184 RVA: 0x00065480 File Offset: 0x00063680
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator +(uint4x3 val)
		{
			return new uint4x3(+val.c0, +val.c1, +val.c2);
		}

		// Token: 0x060023E1 RID: 9185 RVA: 0x000654A8 File Offset: 0x000636A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator <<(uint4x3 x, int n)
		{
			return new uint4x3(x.c0 << n, x.c1 << n, x.c2 << n);
		}

		// Token: 0x060023E2 RID: 9186 RVA: 0x000654D3 File Offset: 0x000636D3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator >>(uint4x3 x, int n)
		{
			return new uint4x3(x.c0 >> n, x.c1 >> n, x.c2 >> n);
		}

		// Token: 0x060023E3 RID: 9187 RVA: 0x000654FE File Offset: 0x000636FE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator ==(uint4x3 lhs, uint4x3 rhs)
		{
			return new bool4x3(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2);
		}

		// Token: 0x060023E4 RID: 9188 RVA: 0x00065538 File Offset: 0x00063738
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator ==(uint4x3 lhs, uint rhs)
		{
			return new bool4x3(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs);
		}

		// Token: 0x060023E5 RID: 9189 RVA: 0x00065563 File Offset: 0x00063763
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator ==(uint lhs, uint4x3 rhs)
		{
			return new bool4x3(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2);
		}

		// Token: 0x060023E6 RID: 9190 RVA: 0x0006558E File Offset: 0x0006378E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator !=(uint4x3 lhs, uint4x3 rhs)
		{
			return new bool4x3(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2);
		}

		// Token: 0x060023E7 RID: 9191 RVA: 0x000655C8 File Offset: 0x000637C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator !=(uint4x3 lhs, uint rhs)
		{
			return new bool4x3(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs);
		}

		// Token: 0x060023E8 RID: 9192 RVA: 0x000655F3 File Offset: 0x000637F3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator !=(uint lhs, uint4x3 rhs)
		{
			return new bool4x3(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2);
		}

		// Token: 0x060023E9 RID: 9193 RVA: 0x0006561E File Offset: 0x0006381E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator ~(uint4x3 val)
		{
			return new uint4x3(~val.c0, ~val.c1, ~val.c2);
		}

		// Token: 0x060023EA RID: 9194 RVA: 0x00065646 File Offset: 0x00063846
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator &(uint4x3 lhs, uint4x3 rhs)
		{
			return new uint4x3(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2);
		}

		// Token: 0x060023EB RID: 9195 RVA: 0x00065680 File Offset: 0x00063880
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator &(uint4x3 lhs, uint rhs)
		{
			return new uint4x3(lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs);
		}

		// Token: 0x060023EC RID: 9196 RVA: 0x000656AB File Offset: 0x000638AB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator &(uint lhs, uint4x3 rhs)
		{
			return new uint4x3(lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2);
		}

		// Token: 0x060023ED RID: 9197 RVA: 0x000656D6 File Offset: 0x000638D6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator |(uint4x3 lhs, uint4x3 rhs)
		{
			return new uint4x3(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2);
		}

		// Token: 0x060023EE RID: 9198 RVA: 0x00065710 File Offset: 0x00063910
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator |(uint4x3 lhs, uint rhs)
		{
			return new uint4x3(lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs);
		}

		// Token: 0x060023EF RID: 9199 RVA: 0x0006573B File Offset: 0x0006393B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator |(uint lhs, uint4x3 rhs)
		{
			return new uint4x3(lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2);
		}

		// Token: 0x060023F0 RID: 9200 RVA: 0x00065766 File Offset: 0x00063966
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator ^(uint4x3 lhs, uint4x3 rhs)
		{
			return new uint4x3(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2);
		}

		// Token: 0x060023F1 RID: 9201 RVA: 0x000657A0 File Offset: 0x000639A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator ^(uint4x3 lhs, uint rhs)
		{
			return new uint4x3(lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs);
		}

		// Token: 0x060023F2 RID: 9202 RVA: 0x000657CB File Offset: 0x000639CB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 operator ^(uint lhs, uint4x3 rhs)
		{
			return new uint4x3(lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2);
		}

		// Token: 0x17000B88 RID: 2952
		public unsafe uint4 this[int index]
		{
			get
			{
				fixed (uint4x3* ptr = &this)
				{
					return ref *(uint4*)(ptr + (IntPtr)index * (IntPtr)sizeof(uint4) / (IntPtr)sizeof(uint4x3));
				}
			}
		}

		// Token: 0x060023F4 RID: 9204 RVA: 0x00065813 File Offset: 0x00063A13
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(uint4x3 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2);
		}

		// Token: 0x060023F5 RID: 9205 RVA: 0x00065850 File Offset: 0x00063A50
		public override bool Equals(object o)
		{
			if (o is uint4x3)
			{
				uint4x3 rhs = (uint4x3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x060023F6 RID: 9206 RVA: 0x00065875 File Offset: 0x00063A75
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x060023F7 RID: 9207 RVA: 0x00065884 File Offset: 0x00063A84
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("uint4x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8},  {9}, {10}, {11})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c2.x,
				this.c0.y,
				this.c1.y,
				this.c2.y,
				this.c0.z,
				this.c1.z,
				this.c2.z,
				this.c0.w,
				this.c1.w,
				this.c2.w
			});
		}

		// Token: 0x060023F8 RID: 9208 RVA: 0x0006598C File Offset: 0x00063B8C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("uint4x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8},  {9}, {10}, {11})", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c2.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c2.y.ToString(format, formatProvider),
				this.c0.z.ToString(format, formatProvider),
				this.c1.z.ToString(format, formatProvider),
				this.c2.z.ToString(format, formatProvider),
				this.c0.w.ToString(format, formatProvider),
				this.c1.w.ToString(format, formatProvider),
				this.c2.w.ToString(format, formatProvider)
			});
		}

		// Token: 0x04000111 RID: 273
		public uint4 c0;

		// Token: 0x04000112 RID: 274
		public uint4 c1;

		// Token: 0x04000113 RID: 275
		public uint4 c2;

		// Token: 0x04000114 RID: 276
		public static readonly uint4x3 zero;
	}
}
