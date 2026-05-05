using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000023 RID: 35
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct float3x3 : IEquatable<float3x3>, IFormattable
	{
		// Token: 0x06001241 RID: 4673 RVA: 0x0003440B File Offset: 0x0003260B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x3(float3 c0, float3 c1, float3 c2)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
		}

		// Token: 0x06001242 RID: 4674 RVA: 0x00034422 File Offset: 0x00032622
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x3(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22)
		{
			this.c0 = new float3(m00, m10, m20);
			this.c1 = new float3(m01, m11, m21);
			this.c2 = new float3(m02, m12, m22);
		}

		// Token: 0x06001243 RID: 4675 RVA: 0x00034454 File Offset: 0x00032654
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x3(float v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x06001244 RID: 4676 RVA: 0x0003447C File Offset: 0x0003267C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x3(bool v)
		{
			this.c0 = math.select(new float3(0f), new float3(1f), v);
			this.c1 = math.select(new float3(0f), new float3(1f), v);
			this.c2 = math.select(new float3(0f), new float3(1f), v);
		}

		// Token: 0x06001245 RID: 4677 RVA: 0x000344EC File Offset: 0x000326EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x3(bool3x3 v)
		{
			this.c0 = math.select(new float3(0f), new float3(1f), v.c0);
			this.c1 = math.select(new float3(0f), new float3(1f), v.c1);
			this.c2 = math.select(new float3(0f), new float3(1f), v.c2);
		}

		// Token: 0x06001246 RID: 4678 RVA: 0x00034568 File Offset: 0x00032768
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x3(int v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x06001247 RID: 4679 RVA: 0x0003458E File Offset: 0x0003278E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x3(int3x3 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
		}

		// Token: 0x06001248 RID: 4680 RVA: 0x000345C3 File Offset: 0x000327C3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x3(uint v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x06001249 RID: 4681 RVA: 0x000345E9 File Offset: 0x000327E9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x3(uint3x3 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
		}

		// Token: 0x0600124A RID: 4682 RVA: 0x0003461E File Offset: 0x0003281E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x3(double v)
		{
			this.c0 = (float3)v;
			this.c1 = (float3)v;
			this.c2 = (float3)v;
		}

		// Token: 0x0600124B RID: 4683 RVA: 0x00034644 File Offset: 0x00032844
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3x3(double3x3 v)
		{
			this.c0 = (float3)v.c0;
			this.c1 = (float3)v.c1;
			this.c2 = (float3)v.c2;
		}

		// Token: 0x0600124C RID: 4684 RVA: 0x00034679 File Offset: 0x00032879
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3x3(float v)
		{
			return new float3x3(v);
		}

		// Token: 0x0600124D RID: 4685 RVA: 0x00034681 File Offset: 0x00032881
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float3x3(bool v)
		{
			return new float3x3(v);
		}

		// Token: 0x0600124E RID: 4686 RVA: 0x00034689 File Offset: 0x00032889
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float3x3(bool3x3 v)
		{
			return new float3x3(v);
		}

		// Token: 0x0600124F RID: 4687 RVA: 0x00034691 File Offset: 0x00032891
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3x3(int v)
		{
			return new float3x3(v);
		}

		// Token: 0x06001250 RID: 4688 RVA: 0x00034699 File Offset: 0x00032899
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3x3(int3x3 v)
		{
			return new float3x3(v);
		}

		// Token: 0x06001251 RID: 4689 RVA: 0x000346A1 File Offset: 0x000328A1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3x3(uint v)
		{
			return new float3x3(v);
		}

		// Token: 0x06001252 RID: 4690 RVA: 0x000346A9 File Offset: 0x000328A9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3x3(uint3x3 v)
		{
			return new float3x3(v);
		}

		// Token: 0x06001253 RID: 4691 RVA: 0x000346B1 File Offset: 0x000328B1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float3x3(double v)
		{
			return new float3x3(v);
		}

		// Token: 0x06001254 RID: 4692 RVA: 0x000346B9 File Offset: 0x000328B9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float3x3(double3x3 v)
		{
			return new float3x3(v);
		}

		// Token: 0x06001255 RID: 4693 RVA: 0x000346C1 File Offset: 0x000328C1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator *(float3x3 lhs, float3x3 rhs)
		{
			return new float3x3(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2);
		}

		// Token: 0x06001256 RID: 4694 RVA: 0x000346FB File Offset: 0x000328FB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator *(float3x3 lhs, float rhs)
		{
			return new float3x3(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs);
		}

		// Token: 0x06001257 RID: 4695 RVA: 0x00034726 File Offset: 0x00032926
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator *(float lhs, float3x3 rhs)
		{
			return new float3x3(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2);
		}

		// Token: 0x06001258 RID: 4696 RVA: 0x00034751 File Offset: 0x00032951
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator +(float3x3 lhs, float3x3 rhs)
		{
			return new float3x3(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2);
		}

		// Token: 0x06001259 RID: 4697 RVA: 0x0003478B File Offset: 0x0003298B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator +(float3x3 lhs, float rhs)
		{
			return new float3x3(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs);
		}

		// Token: 0x0600125A RID: 4698 RVA: 0x000347B6 File Offset: 0x000329B6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator +(float lhs, float3x3 rhs)
		{
			return new float3x3(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2);
		}

		// Token: 0x0600125B RID: 4699 RVA: 0x000347E1 File Offset: 0x000329E1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator -(float3x3 lhs, float3x3 rhs)
		{
			return new float3x3(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2);
		}

		// Token: 0x0600125C RID: 4700 RVA: 0x0003481B File Offset: 0x00032A1B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator -(float3x3 lhs, float rhs)
		{
			return new float3x3(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs);
		}

		// Token: 0x0600125D RID: 4701 RVA: 0x00034846 File Offset: 0x00032A46
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator -(float lhs, float3x3 rhs)
		{
			return new float3x3(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2);
		}

		// Token: 0x0600125E RID: 4702 RVA: 0x00034871 File Offset: 0x00032A71
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator /(float3x3 lhs, float3x3 rhs)
		{
			return new float3x3(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2);
		}

		// Token: 0x0600125F RID: 4703 RVA: 0x000348AB File Offset: 0x00032AAB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator /(float3x3 lhs, float rhs)
		{
			return new float3x3(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs);
		}

		// Token: 0x06001260 RID: 4704 RVA: 0x000348D6 File Offset: 0x00032AD6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator /(float lhs, float3x3 rhs)
		{
			return new float3x3(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2);
		}

		// Token: 0x06001261 RID: 4705 RVA: 0x00034901 File Offset: 0x00032B01
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator %(float3x3 lhs, float3x3 rhs)
		{
			return new float3x3(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2);
		}

		// Token: 0x06001262 RID: 4706 RVA: 0x0003493B File Offset: 0x00032B3B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator %(float3x3 lhs, float rhs)
		{
			return new float3x3(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs);
		}

		// Token: 0x06001263 RID: 4707 RVA: 0x00034966 File Offset: 0x00032B66
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator %(float lhs, float3x3 rhs)
		{
			return new float3x3(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2);
		}

		// Token: 0x06001264 RID: 4708 RVA: 0x00034994 File Offset: 0x00032B94
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator ++(float3x3 val)
		{
			float3 @float = ++val.c0;
			val.c0 = @float;
			float3 float2 = @float;
			@float = ++val.c1;
			val.c1 = @float;
			float3 float3 = @float;
			@float = ++val.c2;
			val.c2 = @float;
			return new float3x3(float2, float3, @float);
		}

		// Token: 0x06001265 RID: 4709 RVA: 0x000349F4 File Offset: 0x00032BF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator --(float3x3 val)
		{
			float3 @float = --val.c0;
			val.c0 = @float;
			float3 float2 = @float;
			@float = --val.c1;
			val.c1 = @float;
			float3 float3 = @float;
			@float = --val.c2;
			val.c2 = @float;
			return new float3x3(float2, float3, @float);
		}

		// Token: 0x06001266 RID: 4710 RVA: 0x00034A54 File Offset: 0x00032C54
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <(float3x3 lhs, float3x3 rhs)
		{
			return new bool3x3(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2);
		}

		// Token: 0x06001267 RID: 4711 RVA: 0x00034A8E File Offset: 0x00032C8E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <(float3x3 lhs, float rhs)
		{
			return new bool3x3(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs);
		}

		// Token: 0x06001268 RID: 4712 RVA: 0x00034AB9 File Offset: 0x00032CB9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <(float lhs, float3x3 rhs)
		{
			return new bool3x3(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2);
		}

		// Token: 0x06001269 RID: 4713 RVA: 0x00034AE4 File Offset: 0x00032CE4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <=(float3x3 lhs, float3x3 rhs)
		{
			return new bool3x3(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2);
		}

		// Token: 0x0600126A RID: 4714 RVA: 0x00034B1E File Offset: 0x00032D1E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <=(float3x3 lhs, float rhs)
		{
			return new bool3x3(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs);
		}

		// Token: 0x0600126B RID: 4715 RVA: 0x00034B49 File Offset: 0x00032D49
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <=(float lhs, float3x3 rhs)
		{
			return new bool3x3(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2);
		}

		// Token: 0x0600126C RID: 4716 RVA: 0x00034B74 File Offset: 0x00032D74
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >(float3x3 lhs, float3x3 rhs)
		{
			return new bool3x3(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2);
		}

		// Token: 0x0600126D RID: 4717 RVA: 0x00034BAE File Offset: 0x00032DAE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >(float3x3 lhs, float rhs)
		{
			return new bool3x3(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs);
		}

		// Token: 0x0600126E RID: 4718 RVA: 0x00034BD9 File Offset: 0x00032DD9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >(float lhs, float3x3 rhs)
		{
			return new bool3x3(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2);
		}

		// Token: 0x0600126F RID: 4719 RVA: 0x00034C04 File Offset: 0x00032E04
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >=(float3x3 lhs, float3x3 rhs)
		{
			return new bool3x3(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2);
		}

		// Token: 0x06001270 RID: 4720 RVA: 0x00034C3E File Offset: 0x00032E3E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >=(float3x3 lhs, float rhs)
		{
			return new bool3x3(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs);
		}

		// Token: 0x06001271 RID: 4721 RVA: 0x00034C69 File Offset: 0x00032E69
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >=(float lhs, float3x3 rhs)
		{
			return new bool3x3(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2);
		}

		// Token: 0x06001272 RID: 4722 RVA: 0x00034C94 File Offset: 0x00032E94
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator -(float3x3 val)
		{
			return new float3x3(-val.c0, -val.c1, -val.c2);
		}

		// Token: 0x06001273 RID: 4723 RVA: 0x00034CBC File Offset: 0x00032EBC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 operator +(float3x3 val)
		{
			return new float3x3(+val.c0, +val.c1, +val.c2);
		}

		// Token: 0x06001274 RID: 4724 RVA: 0x00034CE4 File Offset: 0x00032EE4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator ==(float3x3 lhs, float3x3 rhs)
		{
			return new bool3x3(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2);
		}

		// Token: 0x06001275 RID: 4725 RVA: 0x00034D1E File Offset: 0x00032F1E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator ==(float3x3 lhs, float rhs)
		{
			return new bool3x3(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs);
		}

		// Token: 0x06001276 RID: 4726 RVA: 0x00034D49 File Offset: 0x00032F49
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator ==(float lhs, float3x3 rhs)
		{
			return new bool3x3(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2);
		}

		// Token: 0x06001277 RID: 4727 RVA: 0x00034D74 File Offset: 0x00032F74
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator !=(float3x3 lhs, float3x3 rhs)
		{
			return new bool3x3(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2);
		}

		// Token: 0x06001278 RID: 4728 RVA: 0x00034DAE File Offset: 0x00032FAE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator !=(float3x3 lhs, float rhs)
		{
			return new bool3x3(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs);
		}

		// Token: 0x06001279 RID: 4729 RVA: 0x00034DD9 File Offset: 0x00032FD9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator !=(float lhs, float3x3 rhs)
		{
			return new bool3x3(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2);
		}

		// Token: 0x17000472 RID: 1138
		public unsafe float3 this[int index]
		{
			get
			{
				fixed (float3x3* ptr = &this)
				{
					return ref *(float3*)(ptr + (IntPtr)index * (IntPtr)sizeof(float3) / (IntPtr)sizeof(float3x3));
				}
			}
		}

		// Token: 0x0600127B RID: 4731 RVA: 0x00034E1F File Offset: 0x0003301F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(float3x3 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2);
		}

		// Token: 0x0600127C RID: 4732 RVA: 0x00034E5C File Offset: 0x0003305C
		public override bool Equals(object o)
		{
			if (o is float3x3)
			{
				float3x3 rhs = (float3x3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x0600127D RID: 4733 RVA: 0x00034E81 File Offset: 0x00033081
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x0600127E RID: 4734 RVA: 0x00034E90 File Offset: 0x00033090
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("float3x3({0}f, {1}f, {2}f,  {3}f, {4}f, {5}f,  {6}f, {7}f, {8}f)", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c2.x,
				this.c0.y,
				this.c1.y,
				this.c2.y,
				this.c0.z,
				this.c1.z,
				this.c2.z
			});
		}

		// Token: 0x0600127F RID: 4735 RVA: 0x00034F5C File Offset: 0x0003315C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("float3x3({0}f, {1}f, {2}f,  {3}f, {4}f, {5}f,  {6}f, {7}f, {8}f)", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c2.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c2.y.ToString(format, formatProvider),
				this.c0.z.ToString(format, formatProvider),
				this.c1.z.ToString(format, formatProvider),
				this.c2.z.ToString(format, formatProvider)
			});
		}

		// Token: 0x06001280 RID: 4736 RVA: 0x00035037 File Offset: 0x00033237
		public float3x3(float4x4 f4x4)
		{
			this.c0 = f4x4.c0.xyz;
			this.c1 = f4x4.c1.xyz;
			this.c2 = f4x4.c2.xyz;
		}

		// Token: 0x06001281 RID: 4737 RVA: 0x00035070 File Offset: 0x00033270
		public float3x3(quaternion q)
		{
			float4 value = q.value;
			float4 @float = value + value;
			uint3 rhs = math.uint3(2147483648U, 0U, 2147483648U);
			uint3 rhs2 = math.uint3(2147483648U, 2147483648U, 0U);
			uint3 rhs3 = math.uint3(0U, 2147483648U, 2147483648U);
			this.c0 = @float.y * math.asfloat(math.asuint(value.yxw) ^ rhs) - @float.z * math.asfloat(math.asuint(value.zwx) ^ rhs3) + math.float3(1f, 0f, 0f);
			this.c1 = @float.z * math.asfloat(math.asuint(value.wzy) ^ rhs2) - @float.x * math.asfloat(math.asuint(value.yxw) ^ rhs) + math.float3(0f, 1f, 0f);
			this.c2 = @float.x * math.asfloat(math.asuint(value.zwx) ^ rhs3) - @float.y * math.asfloat(math.asuint(value.wzy) ^ rhs2) + math.float3(0f, 0f, 1f);
		}

		// Token: 0x06001282 RID: 4738 RVA: 0x000351FC File Offset: 0x000333FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 AxisAngle(float3 axis, float angle)
		{
			float rhs;
			float num;
			math.sincos(angle, out rhs, out num);
			float3 @float = axis;
			float3 yzx = @float.yzx;
			float3 zxy = @float.zxy;
			float3 rhs2 = @float - @float * num;
			float4 float2 = math.float4(@float * rhs, num);
			uint3 rhs3 = math.uint3(0U, 0U, 2147483648U);
			uint3 rhs4 = math.uint3(2147483648U, 0U, 0U);
			uint3 rhs5 = math.uint3(0U, 2147483648U, 0U);
			return math.float3x3(@float.x * rhs2 + math.asfloat(math.asuint(float2.wzy) ^ rhs3), @float.y * rhs2 + math.asfloat(math.asuint(float2.zwx) ^ rhs4), @float.z * rhs2 + math.asfloat(math.asuint(float2.yxw) ^ rhs5));
		}

		// Token: 0x06001283 RID: 4739 RVA: 0x000352EC File Offset: 0x000334EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 EulerXYZ(float3 xyz)
		{
			float3 @float;
			float3 float2;
			math.sincos(xyz, out @float, out float2);
			return math.float3x3(float2.y * float2.z, float2.z * @float.x * @float.y - float2.x * @float.z, float2.x * float2.z * @float.y + @float.x * @float.z, float2.y * @float.z, float2.x * float2.z + @float.x * @float.y * @float.z, float2.x * @float.y * @float.z - float2.z * @float.x, -@float.y, float2.y * @float.x, float2.x * float2.y);
		}

		// Token: 0x06001284 RID: 4740 RVA: 0x000353CC File Offset: 0x000335CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 EulerXZY(float3 xyz)
		{
			float3 @float;
			float3 float2;
			math.sincos(xyz, out @float, out float2);
			return math.float3x3(float2.y * float2.z, @float.x * @float.y - float2.x * float2.y * @float.z, float2.x * @float.y + float2.y * @float.x * @float.z, @float.z, float2.x * float2.z, -float2.z * @float.x, -float2.z * @float.y, float2.y * @float.x + float2.x * @float.y * @float.z, float2.x * float2.y - @float.x * @float.y * @float.z);
		}

		// Token: 0x06001285 RID: 4741 RVA: 0x000354AC File Offset: 0x000336AC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 EulerYXZ(float3 xyz)
		{
			float3 @float;
			float3 float2;
			math.sincos(xyz, out @float, out float2);
			return math.float3x3(float2.y * float2.z - @float.x * @float.y * @float.z, -float2.x * @float.z, float2.z * @float.y + float2.y * @float.x * @float.z, float2.z * @float.x * @float.y + float2.y * @float.z, float2.x * float2.z, @float.y * @float.z - float2.y * float2.z * @float.x, -float2.x * @float.y, @float.x, float2.x * float2.y);
		}

		// Token: 0x06001286 RID: 4742 RVA: 0x0003558C File Offset: 0x0003378C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 EulerYZX(float3 xyz)
		{
			float3 @float;
			float3 float2;
			math.sincos(xyz, out @float, out float2);
			return math.float3x3(float2.y * float2.z, -@float.z, float2.z * @float.y, @float.x * @float.y + float2.x * float2.y * @float.z, float2.x * float2.z, float2.x * @float.y * @float.z - float2.y * @float.x, float2.y * @float.x * @float.z - float2.x * @float.y, float2.z * @float.x, float2.x * float2.y + @float.x * @float.y * @float.z);
		}

		// Token: 0x06001287 RID: 4743 RVA: 0x0003566C File Offset: 0x0003386C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 EulerZXY(float3 xyz)
		{
			float3 @float;
			float3 float2;
			math.sincos(xyz, out @float, out float2);
			return math.float3x3(float2.y * float2.z + @float.x * @float.y * @float.z, float2.z * @float.x * @float.y - float2.y * @float.z, float2.x * @float.y, float2.x * @float.z, float2.x * float2.z, -@float.x, float2.y * @float.x * @float.z - float2.z * @float.y, float2.y * float2.z * @float.x + @float.y * @float.z, float2.x * float2.y);
		}

		// Token: 0x06001288 RID: 4744 RVA: 0x0003574C File Offset: 0x0003394C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 EulerZYX(float3 xyz)
		{
			float3 @float;
			float3 float2;
			math.sincos(xyz, out @float, out float2);
			return math.float3x3(float2.y * float2.z, -float2.y * @float.z, @float.y, float2.z * @float.x * @float.y + float2.x * @float.z, float2.x * float2.z - @float.x * @float.y * @float.z, -float2.y * @float.x, @float.x * @float.z - float2.x * float2.z * @float.y, float2.z * @float.x + float2.x * @float.y * @float.z, float2.x * float2.y);
		}

		// Token: 0x06001289 RID: 4745 RVA: 0x0003582C File Offset: 0x00033A2C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 EulerXYZ(float x, float y, float z)
		{
			return float3x3.EulerXYZ(math.float3(x, y, z));
		}

		// Token: 0x0600128A RID: 4746 RVA: 0x0003583B File Offset: 0x00033A3B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 EulerXZY(float x, float y, float z)
		{
			return float3x3.EulerXZY(math.float3(x, y, z));
		}

		// Token: 0x0600128B RID: 4747 RVA: 0x0003584A File Offset: 0x00033A4A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 EulerYXZ(float x, float y, float z)
		{
			return float3x3.EulerYXZ(math.float3(x, y, z));
		}

		// Token: 0x0600128C RID: 4748 RVA: 0x00035859 File Offset: 0x00033A59
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 EulerYZX(float x, float y, float z)
		{
			return float3x3.EulerYZX(math.float3(x, y, z));
		}

		// Token: 0x0600128D RID: 4749 RVA: 0x00035868 File Offset: 0x00033A68
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 EulerZXY(float x, float y, float z)
		{
			return float3x3.EulerZXY(math.float3(x, y, z));
		}

		// Token: 0x0600128E RID: 4750 RVA: 0x00035877 File Offset: 0x00033A77
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 EulerZYX(float x, float y, float z)
		{
			return float3x3.EulerZYX(math.float3(x, y, z));
		}

		// Token: 0x0600128F RID: 4751 RVA: 0x00035888 File Offset: 0x00033A88
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 Euler(float3 xyz, math.RotationOrder order = math.RotationOrder.ZXY)
		{
			switch (order)
			{
			case math.RotationOrder.XYZ:
				return float3x3.EulerXYZ(xyz);
			case math.RotationOrder.XZY:
				return float3x3.EulerXZY(xyz);
			case math.RotationOrder.YXZ:
				return float3x3.EulerYXZ(xyz);
			case math.RotationOrder.YZX:
				return float3x3.EulerYZX(xyz);
			case math.RotationOrder.ZXY:
				return float3x3.EulerZXY(xyz);
			case math.RotationOrder.ZYX:
				return float3x3.EulerZYX(xyz);
			default:
				return float3x3.identity;
			}
		}

		// Token: 0x06001290 RID: 4752 RVA: 0x000358E4 File Offset: 0x00033AE4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 Euler(float x, float y, float z, math.RotationOrder order = math.RotationOrder.ZXY)
		{
			return float3x3.Euler(math.float3(x, y, z), order);
		}

		// Token: 0x06001291 RID: 4753 RVA: 0x000358F4 File Offset: 0x00033AF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 RotateX(float angle)
		{
			float num;
			float num2;
			math.sincos(angle, out num, out num2);
			return math.float3x3(1f, 0f, 0f, 0f, num2, -num, 0f, num, num2);
		}

		// Token: 0x06001292 RID: 4754 RVA: 0x00035930 File Offset: 0x00033B30
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 RotateY(float angle)
		{
			float num;
			float num2;
			math.sincos(angle, out num, out num2);
			return math.float3x3(num2, 0f, num, 0f, 1f, 0f, -num, 0f, num2);
		}

		// Token: 0x06001293 RID: 4755 RVA: 0x0003596C File Offset: 0x00033B6C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 RotateZ(float angle)
		{
			float num;
			float num2;
			math.sincos(angle, out num, out num2);
			return math.float3x3(num2, -num, 0f, num, num2, 0f, 0f, 0f, 1f);
		}

		// Token: 0x06001294 RID: 4756 RVA: 0x000359A8 File Offset: 0x00033BA8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 Scale(float s)
		{
			return math.float3x3(s, 0f, 0f, 0f, s, 0f, 0f, 0f, s);
		}

		// Token: 0x06001295 RID: 4757 RVA: 0x000359DC File Offset: 0x00033BDC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 Scale(float x, float y, float z)
		{
			return math.float3x3(x, 0f, 0f, 0f, y, 0f, 0f, 0f, z);
		}

		// Token: 0x06001296 RID: 4758 RVA: 0x00035A0F File Offset: 0x00033C0F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 Scale(float3 v)
		{
			return float3x3.Scale(v.x, v.y, v.z);
		}

		// Token: 0x06001297 RID: 4759 RVA: 0x00035A28 File Offset: 0x00033C28
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 LookRotation(float3 forward, float3 up)
		{
			float3 y = math.normalize(math.cross(up, forward));
			return math.float3x3(y, math.cross(forward, y), forward);
		}

		// Token: 0x06001298 RID: 4760 RVA: 0x00035A50 File Offset: 0x00033C50
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 LookRotationSafe(float3 forward, float3 up)
		{
			float x = math.dot(forward, forward);
			float num = math.dot(up, up);
			forward *= math.rsqrt(x);
			up *= math.rsqrt(num);
			float3 @float = math.cross(up, forward);
			float num2 = math.dot(@float, @float);
			@float *= math.rsqrt(num2);
			float num3 = math.min(math.min(x, num), num2);
			float num4 = math.max(math.max(x, num), num2);
			bool c = num3 > 1E-35f && num4 < 1E+35f && math.isfinite(x) && math.isfinite(num) && math.isfinite(num2);
			return math.float3x3(math.select(math.float3(1f, 0f, 0f), @float, c), math.select(math.float3(0f, 1f, 0f), math.cross(forward, @float), c), math.select(math.float3(0f, 0f, 1f), forward, c));
		}

		// Token: 0x06001299 RID: 4761 RVA: 0x00035B4C File Offset: 0x00033D4C
		public static explicit operator float3x3(float4x4 f4x4)
		{
			return new float3x3(f4x4);
		}

		// Token: 0x04000085 RID: 133
		public float3 c0;

		// Token: 0x04000086 RID: 134
		public float3 c1;

		// Token: 0x04000087 RID: 135
		public float3 c2;

		// Token: 0x04000088 RID: 136
		public static readonly float3x3 identity = new float3x3(1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 1f);

		// Token: 0x04000089 RID: 137
		public static readonly float3x3 zero;
	}
}
