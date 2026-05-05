using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000022 RID: 34
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct float3x2 : IEquatable<float3x2>, IFormattable
	{
		// Token: 0x06001202 RID: 4610 RVA: 0x00033B3C File Offset: 0x00031D3C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x2(float3 c0, float3 c1)
		{
			this.c0 = c0;
			this.c1 = c1;
		}

		// Token: 0x06001203 RID: 4611 RVA: 0x00033B4C File Offset: 0x00031D4C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x2(float m00, float m01, float m10, float m11, float m20, float m21)
		{
			this.c0 = new float3(m00, m10, m20);
			this.c1 = new float3(m01, m11, m21);
		}

		// Token: 0x06001204 RID: 4612 RVA: 0x00033B6D File Offset: 0x00031D6D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x2(float v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x06001205 RID: 4613 RVA: 0x00033B88 File Offset: 0x00031D88
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x2(bool v)
		{
			this.c0 = math.select(new float3(0f), new float3(1f), v);
			this.c1 = math.select(new float3(0f), new float3(1f), v);
		}

		// Token: 0x06001206 RID: 4614 RVA: 0x00033BD8 File Offset: 0x00031DD8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x2(bool3x2 v)
		{
			this.c0 = math.select(new float3(0f), new float3(1f), v.c0);
			this.c1 = math.select(new float3(0f), new float3(1f), v.c1);
		}

		// Token: 0x06001207 RID: 4615 RVA: 0x00033C2F File Offset: 0x00031E2F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x2(int v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x06001208 RID: 4616 RVA: 0x00033C49 File Offset: 0x00031E49
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x2(int3x2 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
		}

		// Token: 0x06001209 RID: 4617 RVA: 0x00033C6D File Offset: 0x00031E6D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x2(uint v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x0600120A RID: 4618 RVA: 0x00033C87 File Offset: 0x00031E87
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x2(uint3x2 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
		}

		// Token: 0x0600120B RID: 4619 RVA: 0x00033CAB File Offset: 0x00031EAB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x2(double v)
		{
			this.c0 = (float3)v;
			this.c1 = (float3)v;
		}

		// Token: 0x0600120C RID: 4620 RVA: 0x00033CC5 File Offset: 0x00031EC5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x2(double3x2 v)
		{
			this.c0 = (float3)v.c0;
			this.c1 = (float3)v.c1;
		}

		// Token: 0x0600120D RID: 4621 RVA: 0x00033CE9 File Offset: 0x00031EE9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3x2(float v)
		{
			return new float3x2(v);
		}

		// Token: 0x0600120E RID: 4622 RVA: 0x00033CF1 File Offset: 0x00031EF1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float3x2(bool v)
		{
			return new float3x2(v);
		}

		// Token: 0x0600120F RID: 4623 RVA: 0x00033CF9 File Offset: 0x00031EF9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float3x2(bool3x2 v)
		{
			return new float3x2(v);
		}

		// Token: 0x06001210 RID: 4624 RVA: 0x00033D01 File Offset: 0x00031F01
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3x2(int v)
		{
			return new float3x2(v);
		}

		// Token: 0x06001211 RID: 4625 RVA: 0x00033D09 File Offset: 0x00031F09
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3x2(int3x2 v)
		{
			return new float3x2(v);
		}

		// Token: 0x06001212 RID: 4626 RVA: 0x00033D11 File Offset: 0x00031F11
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3x2(uint v)
		{
			return new float3x2(v);
		}

		// Token: 0x06001213 RID: 4627 RVA: 0x00033D19 File Offset: 0x00031F19
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3x2(uint3x2 v)
		{
			return new float3x2(v);
		}

		// Token: 0x06001214 RID: 4628 RVA: 0x00033D21 File Offset: 0x00031F21
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float3x2(double v)
		{
			return new float3x2(v);
		}

		// Token: 0x06001215 RID: 4629 RVA: 0x00033D29 File Offset: 0x00031F29
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float3x2(double3x2 v)
		{
			return new float3x2(v);
		}

		// Token: 0x06001216 RID: 4630 RVA: 0x00033D31 File Offset: 0x00031F31
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator *(float3x2 lhs, float3x2 rhs)
		{
			return new float3x2(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1);
		}

		// Token: 0x06001217 RID: 4631 RVA: 0x00033D5A File Offset: 0x00031F5A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator *(float3x2 lhs, float rhs)
		{
			return new float3x2(lhs.c0 * rhs, lhs.c1 * rhs);
		}

		// Token: 0x06001218 RID: 4632 RVA: 0x00033D79 File Offset: 0x00031F79
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator *(float lhs, float3x2 rhs)
		{
			return new float3x2(lhs * rhs.c0, lhs * rhs.c1);
		}

		// Token: 0x06001219 RID: 4633 RVA: 0x00033D98 File Offset: 0x00031F98
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator +(float3x2 lhs, float3x2 rhs)
		{
			return new float3x2(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1);
		}

		// Token: 0x0600121A RID: 4634 RVA: 0x00033DC1 File Offset: 0x00031FC1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator +(float3x2 lhs, float rhs)
		{
			return new float3x2(lhs.c0 + rhs, lhs.c1 + rhs);
		}

		// Token: 0x0600121B RID: 4635 RVA: 0x00033DE0 File Offset: 0x00031FE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator +(float lhs, float3x2 rhs)
		{
			return new float3x2(lhs + rhs.c0, lhs + rhs.c1);
		}

		// Token: 0x0600121C RID: 4636 RVA: 0x00033DFF File Offset: 0x00031FFF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator -(float3x2 lhs, float3x2 rhs)
		{
			return new float3x2(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1);
		}

		// Token: 0x0600121D RID: 4637 RVA: 0x00033E28 File Offset: 0x00032028
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator -(float3x2 lhs, float rhs)
		{
			return new float3x2(lhs.c0 - rhs, lhs.c1 - rhs);
		}

		// Token: 0x0600121E RID: 4638 RVA: 0x00033E47 File Offset: 0x00032047
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator -(float lhs, float3x2 rhs)
		{
			return new float3x2(lhs - rhs.c0, lhs - rhs.c1);
		}

		// Token: 0x0600121F RID: 4639 RVA: 0x00033E66 File Offset: 0x00032066
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator /(float3x2 lhs, float3x2 rhs)
		{
			return new float3x2(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1);
		}

		// Token: 0x06001220 RID: 4640 RVA: 0x00033E8F File Offset: 0x0003208F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator /(float3x2 lhs, float rhs)
		{
			return new float3x2(lhs.c0 / rhs, lhs.c1 / rhs);
		}

		// Token: 0x06001221 RID: 4641 RVA: 0x00033EAE File Offset: 0x000320AE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator /(float lhs, float3x2 rhs)
		{
			return new float3x2(lhs / rhs.c0, lhs / rhs.c1);
		}

		// Token: 0x06001222 RID: 4642 RVA: 0x00033ECD File Offset: 0x000320CD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator %(float3x2 lhs, float3x2 rhs)
		{
			return new float3x2(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1);
		}

		// Token: 0x06001223 RID: 4643 RVA: 0x00033EF6 File Offset: 0x000320F6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator %(float3x2 lhs, float rhs)
		{
			return new float3x2(lhs.c0 % rhs, lhs.c1 % rhs);
		}

		// Token: 0x06001224 RID: 4644 RVA: 0x00033F15 File Offset: 0x00032115
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator %(float lhs, float3x2 rhs)
		{
			return new float3x2(lhs % rhs.c0, lhs % rhs.c1);
		}

		// Token: 0x06001225 RID: 4645 RVA: 0x00033F34 File Offset: 0x00032134
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator ++(float3x2 val)
		{
			float3 @float = ++val.c0;
			val.c0 = @float;
			float3 float2 = @float;
			@float = ++val.c1;
			val.c1 = @float;
			return new float3x2(float2, @float);
		}

		// Token: 0x06001226 RID: 4646 RVA: 0x00033F7C File Offset: 0x0003217C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator --(float3x2 val)
		{
			float3 @float = --val.c0;
			val.c0 = @float;
			float3 float2 = @float;
			@float = --val.c1;
			val.c1 = @float;
			return new float3x2(float2, @float);
		}

		// Token: 0x06001227 RID: 4647 RVA: 0x00033FC2 File Offset: 0x000321C2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <(float3x2 lhs, float3x2 rhs)
		{
			return new bool3x2(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1);
		}

		// Token: 0x06001228 RID: 4648 RVA: 0x00033FEB File Offset: 0x000321EB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <(float3x2 lhs, float rhs)
		{
			return new bool3x2(lhs.c0 < rhs, lhs.c1 < rhs);
		}

		// Token: 0x06001229 RID: 4649 RVA: 0x0003400A File Offset: 0x0003220A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <(float lhs, float3x2 rhs)
		{
			return new bool3x2(lhs < rhs.c0, lhs < rhs.c1);
		}

		// Token: 0x0600122A RID: 4650 RVA: 0x00034029 File Offset: 0x00032229
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <=(float3x2 lhs, float3x2 rhs)
		{
			return new bool3x2(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1);
		}

		// Token: 0x0600122B RID: 4651 RVA: 0x00034052 File Offset: 0x00032252
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <=(float3x2 lhs, float rhs)
		{
			return new bool3x2(lhs.c0 <= rhs, lhs.c1 <= rhs);
		}

		// Token: 0x0600122C RID: 4652 RVA: 0x00034071 File Offset: 0x00032271
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <=(float lhs, float3x2 rhs)
		{
			return new bool3x2(lhs <= rhs.c0, lhs <= rhs.c1);
		}

		// Token: 0x0600122D RID: 4653 RVA: 0x00034090 File Offset: 0x00032290
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >(float3x2 lhs, float3x2 rhs)
		{
			return new bool3x2(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1);
		}

		// Token: 0x0600122E RID: 4654 RVA: 0x000340B9 File Offset: 0x000322B9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >(float3x2 lhs, float rhs)
		{
			return new bool3x2(lhs.c0 > rhs, lhs.c1 > rhs);
		}

		// Token: 0x0600122F RID: 4655 RVA: 0x000340D8 File Offset: 0x000322D8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >(float lhs, float3x2 rhs)
		{
			return new bool3x2(lhs > rhs.c0, lhs > rhs.c1);
		}

		// Token: 0x06001230 RID: 4656 RVA: 0x000340F7 File Offset: 0x000322F7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >=(float3x2 lhs, float3x2 rhs)
		{
			return new bool3x2(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1);
		}

		// Token: 0x06001231 RID: 4657 RVA: 0x00034120 File Offset: 0x00032320
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >=(float3x2 lhs, float rhs)
		{
			return new bool3x2(lhs.c0 >= rhs, lhs.c1 >= rhs);
		}

		// Token: 0x06001232 RID: 4658 RVA: 0x0003413F File Offset: 0x0003233F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >=(float lhs, float3x2 rhs)
		{
			return new bool3x2(lhs >= rhs.c0, lhs >= rhs.c1);
		}

		// Token: 0x06001233 RID: 4659 RVA: 0x0003415E File Offset: 0x0003235E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator -(float3x2 val)
		{
			return new float3x2(-val.c0, -val.c1);
		}

		// Token: 0x06001234 RID: 4660 RVA: 0x0003417B File Offset: 0x0003237B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 operator +(float3x2 val)
		{
			return new float3x2(+val.c0, +val.c1);
		}

		// Token: 0x06001235 RID: 4661 RVA: 0x00034198 File Offset: 0x00032398
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator ==(float3x2 lhs, float3x2 rhs)
		{
			return new bool3x2(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1);
		}

		// Token: 0x06001236 RID: 4662 RVA: 0x000341C1 File Offset: 0x000323C1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator ==(float3x2 lhs, float rhs)
		{
			return new bool3x2(lhs.c0 == rhs, lhs.c1 == rhs);
		}

		// Token: 0x06001237 RID: 4663 RVA: 0x000341E0 File Offset: 0x000323E0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator ==(float lhs, float3x2 rhs)
		{
			return new bool3x2(lhs == rhs.c0, lhs == rhs.c1);
		}

		// Token: 0x06001238 RID: 4664 RVA: 0x000341FF File Offset: 0x000323FF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator !=(float3x2 lhs, float3x2 rhs)
		{
			return new bool3x2(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1);
		}

		// Token: 0x06001239 RID: 4665 RVA: 0x00034228 File Offset: 0x00032428
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator !=(float3x2 lhs, float rhs)
		{
			return new bool3x2(lhs.c0 != rhs, lhs.c1 != rhs);
		}

		// Token: 0x0600123A RID: 4666 RVA: 0x00034247 File Offset: 0x00032447
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator !=(float lhs, float3x2 rhs)
		{
			return new bool3x2(lhs != rhs.c0, lhs != rhs.c1);
		}

		// Token: 0x17000471 RID: 1137
		public unsafe float3 this[int index]
		{
			get
			{
				fixed (float3x2* ptr = &this)
				{
					return ref *(float3*)(ptr + (IntPtr)index * (IntPtr)sizeof(float3) / (IntPtr)sizeof(float3x2));
				}
			}
		}

		// Token: 0x0600123C RID: 4668 RVA: 0x00034283 File Offset: 0x00032483
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(float3x2 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1);
		}

		// Token: 0x0600123D RID: 4669 RVA: 0x000342AC File Offset: 0x000324AC
		public override bool Equals(object o)
		{
			if (o is float3x2)
			{
				float3x2 rhs = (float3x2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x0600123E RID: 4670 RVA: 0x000342D1 File Offset: 0x000324D1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x0600123F RID: 4671 RVA: 0x000342E0 File Offset: 0x000324E0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("float3x2({0}f, {1}f,  {2}f, {3}f,  {4}f, {5}f)", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c0.y,
				this.c1.y,
				this.c0.z,
				this.c1.z
			});
		}

		// Token: 0x06001240 RID: 4672 RVA: 0x00034370 File Offset: 0x00032570
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("float3x2({0}f, {1}f,  {2}f, {3}f,  {4}f, {5}f)", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c0.z.ToString(format, formatProvider),
				this.c1.z.ToString(format, formatProvider)
			});
		}

		// Token: 0x04000082 RID: 130
		public float3 c0;

		// Token: 0x04000083 RID: 131
		public float3 c1;

		// Token: 0x04000084 RID: 132
		public static readonly float3x2 zero;
	}
}
