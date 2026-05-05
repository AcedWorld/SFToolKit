using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x0200001F RID: 31
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct float2x3 : IEquatable<float2x3>, IFormattable
	{
		// Token: 0x060010BB RID: 4283 RVA: 0x00030786 File Offset: 0x0002E986
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x3(float2 c0, float2 c1, float2 c2)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
		}

		// Token: 0x060010BC RID: 4284 RVA: 0x0003079D File Offset: 0x0002E99D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x3(float m00, float m01, float m02, float m10, float m11, float m12)
		{
			this.c0 = new float2(m00, m10);
			this.c1 = new float2(m01, m11);
			this.c2 = new float2(m02, m12);
		}

		// Token: 0x060010BD RID: 4285 RVA: 0x000307C9 File Offset: 0x0002E9C9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x3(float v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x060010BE RID: 4286 RVA: 0x000307F0 File Offset: 0x0002E9F0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x3(bool v)
		{
			this.c0 = math.select(new float2(0f), new float2(1f), v);
			this.c1 = math.select(new float2(0f), new float2(1f), v);
			this.c2 = math.select(new float2(0f), new float2(1f), v);
		}

		// Token: 0x060010BF RID: 4287 RVA: 0x00030860 File Offset: 0x0002EA60
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x3(bool2x3 v)
		{
			this.c0 = math.select(new float2(0f), new float2(1f), v.c0);
			this.c1 = math.select(new float2(0f), new float2(1f), v.c1);
			this.c2 = math.select(new float2(0f), new float2(1f), v.c2);
		}

		// Token: 0x060010C0 RID: 4288 RVA: 0x000308DC File Offset: 0x0002EADC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x3(int v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x060010C1 RID: 4289 RVA: 0x00030902 File Offset: 0x0002EB02
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x3(int2x3 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
		}

		// Token: 0x060010C2 RID: 4290 RVA: 0x00030937 File Offset: 0x0002EB37
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x3(uint v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x060010C3 RID: 4291 RVA: 0x0003095D File Offset: 0x0002EB5D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x3(uint2x3 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
		}

		// Token: 0x060010C4 RID: 4292 RVA: 0x00030992 File Offset: 0x0002EB92
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x3(double v)
		{
			this.c0 = (float2)v;
			this.c1 = (float2)v;
			this.c2 = (float2)v;
		}

		// Token: 0x060010C5 RID: 4293 RVA: 0x000309B8 File Offset: 0x0002EBB8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x3(double2x3 v)
		{
			this.c0 = (float2)v.c0;
			this.c1 = (float2)v.c1;
			this.c2 = (float2)v.c2;
		}

		// Token: 0x060010C6 RID: 4294 RVA: 0x000309ED File Offset: 0x0002EBED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float2x3(float v)
		{
			return new float2x3(v);
		}

		// Token: 0x060010C7 RID: 4295 RVA: 0x000309F5 File Offset: 0x0002EBF5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float2x3(bool v)
		{
			return new float2x3(v);
		}

		// Token: 0x060010C8 RID: 4296 RVA: 0x000309FD File Offset: 0x0002EBFD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float2x3(bool2x3 v)
		{
			return new float2x3(v);
		}

		// Token: 0x060010C9 RID: 4297 RVA: 0x00030A05 File Offset: 0x0002EC05
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float2x3(int v)
		{
			return new float2x3(v);
		}

		// Token: 0x060010CA RID: 4298 RVA: 0x00030A0D File Offset: 0x0002EC0D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float2x3(int2x3 v)
		{
			return new float2x3(v);
		}

		// Token: 0x060010CB RID: 4299 RVA: 0x00030A15 File Offset: 0x0002EC15
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float2x3(uint v)
		{
			return new float2x3(v);
		}

		// Token: 0x060010CC RID: 4300 RVA: 0x00030A1D File Offset: 0x0002EC1D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float2x3(uint2x3 v)
		{
			return new float2x3(v);
		}

		// Token: 0x060010CD RID: 4301 RVA: 0x00030A25 File Offset: 0x0002EC25
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float2x3(double v)
		{
			return new float2x3(v);
		}

		// Token: 0x060010CE RID: 4302 RVA: 0x00030A2D File Offset: 0x0002EC2D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float2x3(double2x3 v)
		{
			return new float2x3(v);
		}

		// Token: 0x060010CF RID: 4303 RVA: 0x00030A35 File Offset: 0x0002EC35
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator *(float2x3 lhs, float2x3 rhs)
		{
			return new float2x3(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2);
		}

		// Token: 0x060010D0 RID: 4304 RVA: 0x00030A6F File Offset: 0x0002EC6F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator *(float2x3 lhs, float rhs)
		{
			return new float2x3(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs);
		}

		// Token: 0x060010D1 RID: 4305 RVA: 0x00030A9A File Offset: 0x0002EC9A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator *(float lhs, float2x3 rhs)
		{
			return new float2x3(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2);
		}

		// Token: 0x060010D2 RID: 4306 RVA: 0x00030AC5 File Offset: 0x0002ECC5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator +(float2x3 lhs, float2x3 rhs)
		{
			return new float2x3(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2);
		}

		// Token: 0x060010D3 RID: 4307 RVA: 0x00030AFF File Offset: 0x0002ECFF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator +(float2x3 lhs, float rhs)
		{
			return new float2x3(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs);
		}

		// Token: 0x060010D4 RID: 4308 RVA: 0x00030B2A File Offset: 0x0002ED2A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator +(float lhs, float2x3 rhs)
		{
			return new float2x3(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2);
		}

		// Token: 0x060010D5 RID: 4309 RVA: 0x00030B55 File Offset: 0x0002ED55
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator -(float2x3 lhs, float2x3 rhs)
		{
			return new float2x3(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2);
		}

		// Token: 0x060010D6 RID: 4310 RVA: 0x00030B8F File Offset: 0x0002ED8F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator -(float2x3 lhs, float rhs)
		{
			return new float2x3(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs);
		}

		// Token: 0x060010D7 RID: 4311 RVA: 0x00030BBA File Offset: 0x0002EDBA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator -(float lhs, float2x3 rhs)
		{
			return new float2x3(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2);
		}

		// Token: 0x060010D8 RID: 4312 RVA: 0x00030BE5 File Offset: 0x0002EDE5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator /(float2x3 lhs, float2x3 rhs)
		{
			return new float2x3(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2);
		}

		// Token: 0x060010D9 RID: 4313 RVA: 0x00030C1F File Offset: 0x0002EE1F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator /(float2x3 lhs, float rhs)
		{
			return new float2x3(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs);
		}

		// Token: 0x060010DA RID: 4314 RVA: 0x00030C4A File Offset: 0x0002EE4A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator /(float lhs, float2x3 rhs)
		{
			return new float2x3(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2);
		}

		// Token: 0x060010DB RID: 4315 RVA: 0x00030C75 File Offset: 0x0002EE75
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator %(float2x3 lhs, float2x3 rhs)
		{
			return new float2x3(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2);
		}

		// Token: 0x060010DC RID: 4316 RVA: 0x00030CAF File Offset: 0x0002EEAF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator %(float2x3 lhs, float rhs)
		{
			return new float2x3(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs);
		}

		// Token: 0x060010DD RID: 4317 RVA: 0x00030CDA File Offset: 0x0002EEDA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator %(float lhs, float2x3 rhs)
		{
			return new float2x3(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2);
		}

		// Token: 0x060010DE RID: 4318 RVA: 0x00030D08 File Offset: 0x0002EF08
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator ++(float2x3 val)
		{
			float2 @float = ++val.c0;
			val.c0 = @float;
			float2 float2 = @float;
			@float = ++val.c1;
			val.c1 = @float;
			float2 float3 = @float;
			@float = ++val.c2;
			val.c2 = @float;
			return new float2x3(float2, float3, @float);
		}

		// Token: 0x060010DF RID: 4319 RVA: 0x00030D68 File Offset: 0x0002EF68
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator --(float2x3 val)
		{
			float2 @float = --val.c0;
			val.c0 = @float;
			float2 float2 = @float;
			@float = --val.c1;
			val.c1 = @float;
			float2 float3 = @float;
			@float = --val.c2;
			val.c2 = @float;
			return new float2x3(float2, float3, @float);
		}

		// Token: 0x060010E0 RID: 4320 RVA: 0x00030DC8 File Offset: 0x0002EFC8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <(float2x3 lhs, float2x3 rhs)
		{
			return new bool2x3(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2);
		}

		// Token: 0x060010E1 RID: 4321 RVA: 0x00030E02 File Offset: 0x0002F002
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <(float2x3 lhs, float rhs)
		{
			return new bool2x3(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs);
		}

		// Token: 0x060010E2 RID: 4322 RVA: 0x00030E2D File Offset: 0x0002F02D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <(float lhs, float2x3 rhs)
		{
			return new bool2x3(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2);
		}

		// Token: 0x060010E3 RID: 4323 RVA: 0x00030E58 File Offset: 0x0002F058
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <=(float2x3 lhs, float2x3 rhs)
		{
			return new bool2x3(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2);
		}

		// Token: 0x060010E4 RID: 4324 RVA: 0x00030E92 File Offset: 0x0002F092
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <=(float2x3 lhs, float rhs)
		{
			return new bool2x3(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs);
		}

		// Token: 0x060010E5 RID: 4325 RVA: 0x00030EBD File Offset: 0x0002F0BD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <=(float lhs, float2x3 rhs)
		{
			return new bool2x3(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2);
		}

		// Token: 0x060010E6 RID: 4326 RVA: 0x00030EE8 File Offset: 0x0002F0E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >(float2x3 lhs, float2x3 rhs)
		{
			return new bool2x3(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2);
		}

		// Token: 0x060010E7 RID: 4327 RVA: 0x00030F22 File Offset: 0x0002F122
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >(float2x3 lhs, float rhs)
		{
			return new bool2x3(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs);
		}

		// Token: 0x060010E8 RID: 4328 RVA: 0x00030F4D File Offset: 0x0002F14D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >(float lhs, float2x3 rhs)
		{
			return new bool2x3(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2);
		}

		// Token: 0x060010E9 RID: 4329 RVA: 0x00030F78 File Offset: 0x0002F178
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >=(float2x3 lhs, float2x3 rhs)
		{
			return new bool2x3(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2);
		}

		// Token: 0x060010EA RID: 4330 RVA: 0x00030FB2 File Offset: 0x0002F1B2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >=(float2x3 lhs, float rhs)
		{
			return new bool2x3(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs);
		}

		// Token: 0x060010EB RID: 4331 RVA: 0x00030FDD File Offset: 0x0002F1DD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >=(float lhs, float2x3 rhs)
		{
			return new bool2x3(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2);
		}

		// Token: 0x060010EC RID: 4332 RVA: 0x00031008 File Offset: 0x0002F208
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator -(float2x3 val)
		{
			return new float2x3(-val.c0, -val.c1, -val.c2);
		}

		// Token: 0x060010ED RID: 4333 RVA: 0x00031030 File Offset: 0x0002F230
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 operator +(float2x3 val)
		{
			return new float2x3(+val.c0, +val.c1, +val.c2);
		}

		// Token: 0x060010EE RID: 4334 RVA: 0x00031058 File Offset: 0x0002F258
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator ==(float2x3 lhs, float2x3 rhs)
		{
			return new bool2x3(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2);
		}

		// Token: 0x060010EF RID: 4335 RVA: 0x00031092 File Offset: 0x0002F292
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator ==(float2x3 lhs, float rhs)
		{
			return new bool2x3(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs);
		}

		// Token: 0x060010F0 RID: 4336 RVA: 0x000310BD File Offset: 0x0002F2BD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator ==(float lhs, float2x3 rhs)
		{
			return new bool2x3(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2);
		}

		// Token: 0x060010F1 RID: 4337 RVA: 0x000310E8 File Offset: 0x0002F2E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator !=(float2x3 lhs, float2x3 rhs)
		{
			return new bool2x3(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2);
		}

		// Token: 0x060010F2 RID: 4338 RVA: 0x00031122 File Offset: 0x0002F322
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator !=(float2x3 lhs, float rhs)
		{
			return new bool2x3(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs);
		}

		// Token: 0x060010F3 RID: 4339 RVA: 0x0003114D File Offset: 0x0002F34D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator !=(float lhs, float2x3 rhs)
		{
			return new bool2x3(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2);
		}

		// Token: 0x170003F9 RID: 1017
		public unsafe float2 this[int index]
		{
			get
			{
				fixed (float2x3* ptr = &this)
				{
					return ref *(float2*)(ptr + (IntPtr)index * (IntPtr)sizeof(float2) / (IntPtr)sizeof(float2x3));
				}
			}
		}

		// Token: 0x060010F5 RID: 4341 RVA: 0x00031193 File Offset: 0x0002F393
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(float2x3 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2);
		}

		// Token: 0x060010F6 RID: 4342 RVA: 0x000311D0 File Offset: 0x0002F3D0
		public override bool Equals(object o)
		{
			if (o is float2x3)
			{
				float2x3 rhs = (float2x3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x060010F7 RID: 4343 RVA: 0x000311F5 File Offset: 0x0002F3F5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x060010F8 RID: 4344 RVA: 0x00031204 File Offset: 0x0002F404
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("float2x3({0}f, {1}f, {2}f,  {3}f, {4}f, {5}f)", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c2.x,
				this.c0.y,
				this.c1.y,
				this.c2.y
			});
		}

		// Token: 0x060010F9 RID: 4345 RVA: 0x00031294 File Offset: 0x0002F494
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("float2x3({0}f, {1}f, {2}f,  {3}f, {4}f, {5}f)", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c2.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c2.y.ToString(format, formatProvider)
			});
		}

		// Token: 0x04000075 RID: 117
		public float2 c0;

		// Token: 0x04000076 RID: 118
		public float2 c1;

		// Token: 0x04000077 RID: 119
		public float2 c2;

		// Token: 0x04000078 RID: 120
		public static readonly float2x3 zero;
	}
}
