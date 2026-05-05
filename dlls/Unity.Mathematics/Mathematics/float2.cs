using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Unity.Mathematics
{
	// Token: 0x0200001D RID: 29
	[DebuggerTypeProxy(typeof(float2.DebuggerProxy))]
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct float2 : IEquatable<float2>, IFormattable
	{
		// Token: 0x06001013 RID: 4115 RVA: 0x0002F443 File Offset: 0x0002D643
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		// Token: 0x06001014 RID: 4116 RVA: 0x0002F453 File Offset: 0x0002D653
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2(float2 xy)
		{
			this.x = xy.x;
			this.y = xy.y;
		}

		// Token: 0x06001015 RID: 4117 RVA: 0x0002F46D File Offset: 0x0002D66D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2(float v)
		{
			this.x = v;
			this.y = v;
		}

		// Token: 0x06001016 RID: 4118 RVA: 0x0002F47D File Offset: 0x0002D67D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2(bool v)
		{
			this.x = (v ? 1f : 0f);
			this.y = (v ? 1f : 0f);
		}

		// Token: 0x06001017 RID: 4119 RVA: 0x0002F4A9 File Offset: 0x0002D6A9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2(bool2 v)
		{
			this.x = (v.x ? 1f : 0f);
			this.y = (v.y ? 1f : 0f);
		}

		// Token: 0x06001018 RID: 4120 RVA: 0x0002F4DF File Offset: 0x0002D6DF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2(int v)
		{
			this.x = (float)v;
			this.y = (float)v;
		}

		// Token: 0x06001019 RID: 4121 RVA: 0x0002F4F1 File Offset: 0x0002D6F1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2(int2 v)
		{
			this.x = (float)v.x;
			this.y = (float)v.y;
		}

		// Token: 0x0600101A RID: 4122 RVA: 0x0002F50D File Offset: 0x0002D70D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2(uint v)
		{
			this.x = v;
			this.y = v;
		}

		// Token: 0x0600101B RID: 4123 RVA: 0x0002F521 File Offset: 0x0002D721
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2(uint2 v)
		{
			this.x = v.x;
			this.y = v.y;
		}

		// Token: 0x0600101C RID: 4124 RVA: 0x0002F53F File Offset: 0x0002D73F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2(half v)
		{
			this.x = v;
			this.y = v;
		}

		// Token: 0x0600101D RID: 4125 RVA: 0x0002F559 File Offset: 0x0002D759
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2(half2 v)
		{
			this.x = v.x;
			this.y = v.y;
		}

		// Token: 0x0600101E RID: 4126 RVA: 0x0002F57D File Offset: 0x0002D77D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2(double v)
		{
			this.x = (float)v;
			this.y = (float)v;
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x0002F58F File Offset: 0x0002D78F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2(double2 v)
		{
			this.x = (float)v.x;
			this.y = (float)v.y;
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x0002F5AB File Offset: 0x0002D7AB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float2(float v)
		{
			return new float2(v);
		}

		// Token: 0x06001021 RID: 4129 RVA: 0x0002F5B3 File Offset: 0x0002D7B3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float2(bool v)
		{
			return new float2(v);
		}

		// Token: 0x06001022 RID: 4130 RVA: 0x0002F5BB File Offset: 0x0002D7BB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float2(bool2 v)
		{
			return new float2(v);
		}

		// Token: 0x06001023 RID: 4131 RVA: 0x0002F5C3 File Offset: 0x0002D7C3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float2(int v)
		{
			return new float2(v);
		}

		// Token: 0x06001024 RID: 4132 RVA: 0x0002F5CB File Offset: 0x0002D7CB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float2(int2 v)
		{
			return new float2(v);
		}

		// Token: 0x06001025 RID: 4133 RVA: 0x0002F5D3 File Offset: 0x0002D7D3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float2(uint v)
		{
			return new float2(v);
		}

		// Token: 0x06001026 RID: 4134 RVA: 0x0002F5DB File Offset: 0x0002D7DB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float2(uint2 v)
		{
			return new float2(v);
		}

		// Token: 0x06001027 RID: 4135 RVA: 0x0002F5E3 File Offset: 0x0002D7E3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float2(half v)
		{
			return new float2(v);
		}

		// Token: 0x06001028 RID: 4136 RVA: 0x0002F5EB File Offset: 0x0002D7EB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float2(half2 v)
		{
			return new float2(v);
		}

		// Token: 0x06001029 RID: 4137 RVA: 0x0002F5F3 File Offset: 0x0002D7F3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float2(double v)
		{
			return new float2(v);
		}

		// Token: 0x0600102A RID: 4138 RVA: 0x0002F5FB File Offset: 0x0002D7FB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float2(double2 v)
		{
			return new float2(v);
		}

		// Token: 0x0600102B RID: 4139 RVA: 0x0002F603 File Offset: 0x0002D803
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator *(float2 lhs, float2 rhs)
		{
			return new float2(lhs.x * rhs.x, lhs.y * rhs.y);
		}

		// Token: 0x0600102C RID: 4140 RVA: 0x0002F624 File Offset: 0x0002D824
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator *(float2 lhs, float rhs)
		{
			return new float2(lhs.x * rhs, lhs.y * rhs);
		}

		// Token: 0x0600102D RID: 4141 RVA: 0x0002F63B File Offset: 0x0002D83B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator *(float lhs, float2 rhs)
		{
			return new float2(lhs * rhs.x, lhs * rhs.y);
		}

		// Token: 0x0600102E RID: 4142 RVA: 0x0002F652 File Offset: 0x0002D852
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator +(float2 lhs, float2 rhs)
		{
			return new float2(lhs.x + rhs.x, lhs.y + rhs.y);
		}

		// Token: 0x0600102F RID: 4143 RVA: 0x0002F673 File Offset: 0x0002D873
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator +(float2 lhs, float rhs)
		{
			return new float2(lhs.x + rhs, lhs.y + rhs);
		}

		// Token: 0x06001030 RID: 4144 RVA: 0x0002F68A File Offset: 0x0002D88A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator +(float lhs, float2 rhs)
		{
			return new float2(lhs + rhs.x, lhs + rhs.y);
		}

		// Token: 0x06001031 RID: 4145 RVA: 0x0002F6A1 File Offset: 0x0002D8A1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator -(float2 lhs, float2 rhs)
		{
			return new float2(lhs.x - rhs.x, lhs.y - rhs.y);
		}

		// Token: 0x06001032 RID: 4146 RVA: 0x0002F6C2 File Offset: 0x0002D8C2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator -(float2 lhs, float rhs)
		{
			return new float2(lhs.x - rhs, lhs.y - rhs);
		}

		// Token: 0x06001033 RID: 4147 RVA: 0x0002F6D9 File Offset: 0x0002D8D9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator -(float lhs, float2 rhs)
		{
			return new float2(lhs - rhs.x, lhs - rhs.y);
		}

		// Token: 0x06001034 RID: 4148 RVA: 0x0002F6F0 File Offset: 0x0002D8F0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator /(float2 lhs, float2 rhs)
		{
			return new float2(lhs.x / rhs.x, lhs.y / rhs.y);
		}

		// Token: 0x06001035 RID: 4149 RVA: 0x0002F711 File Offset: 0x0002D911
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator /(float2 lhs, float rhs)
		{
			return new float2(lhs.x / rhs, lhs.y / rhs);
		}

		// Token: 0x06001036 RID: 4150 RVA: 0x0002F728 File Offset: 0x0002D928
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator /(float lhs, float2 rhs)
		{
			return new float2(lhs / rhs.x, lhs / rhs.y);
		}

		// Token: 0x06001037 RID: 4151 RVA: 0x0002F73F File Offset: 0x0002D93F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator %(float2 lhs, float2 rhs)
		{
			return new float2(lhs.x % rhs.x, lhs.y % rhs.y);
		}

		// Token: 0x06001038 RID: 4152 RVA: 0x0002F760 File Offset: 0x0002D960
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator %(float2 lhs, float rhs)
		{
			return new float2(lhs.x % rhs, lhs.y % rhs);
		}

		// Token: 0x06001039 RID: 4153 RVA: 0x0002F777 File Offset: 0x0002D977
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator %(float lhs, float2 rhs)
		{
			return new float2(lhs % rhs.x, lhs % rhs.y);
		}

		// Token: 0x0600103A RID: 4154 RVA: 0x0002F790 File Offset: 0x0002D990
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator ++(float2 val)
		{
			float num = val.x + 1f;
			val.x = num;
			float num2 = num;
			num = val.y + 1f;
			val.y = num;
			return new float2(num2, num);
		}

		// Token: 0x0600103B RID: 4155 RVA: 0x0002F7C8 File Offset: 0x0002D9C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator --(float2 val)
		{
			float num = val.x - 1f;
			val.x = num;
			float num2 = num;
			num = val.y - 1f;
			val.y = num;
			return new float2(num2, num);
		}

		// Token: 0x0600103C RID: 4156 RVA: 0x0002F800 File Offset: 0x0002DA00
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <(float2 lhs, float2 rhs)
		{
			return new bool2(lhs.x < rhs.x, lhs.y < rhs.y);
		}

		// Token: 0x0600103D RID: 4157 RVA: 0x0002F823 File Offset: 0x0002DA23
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <(float2 lhs, float rhs)
		{
			return new bool2(lhs.x < rhs, lhs.y < rhs);
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x0002F83C File Offset: 0x0002DA3C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <(float lhs, float2 rhs)
		{
			return new bool2(lhs < rhs.x, lhs < rhs.y);
		}

		// Token: 0x0600103F RID: 4159 RVA: 0x0002F855 File Offset: 0x0002DA55
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <=(float2 lhs, float2 rhs)
		{
			return new bool2(lhs.x <= rhs.x, lhs.y <= rhs.y);
		}

		// Token: 0x06001040 RID: 4160 RVA: 0x0002F87E File Offset: 0x0002DA7E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <=(float2 lhs, float rhs)
		{
			return new bool2(lhs.x <= rhs, lhs.y <= rhs);
		}

		// Token: 0x06001041 RID: 4161 RVA: 0x0002F89D File Offset: 0x0002DA9D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <=(float lhs, float2 rhs)
		{
			return new bool2(lhs <= rhs.x, lhs <= rhs.y);
		}

		// Token: 0x06001042 RID: 4162 RVA: 0x0002F8BC File Offset: 0x0002DABC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >(float2 lhs, float2 rhs)
		{
			return new bool2(lhs.x > rhs.x, lhs.y > rhs.y);
		}

		// Token: 0x06001043 RID: 4163 RVA: 0x0002F8DF File Offset: 0x0002DADF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >(float2 lhs, float rhs)
		{
			return new bool2(lhs.x > rhs, lhs.y > rhs);
		}

		// Token: 0x06001044 RID: 4164 RVA: 0x0002F8F8 File Offset: 0x0002DAF8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >(float lhs, float2 rhs)
		{
			return new bool2(lhs > rhs.x, lhs > rhs.y);
		}

		// Token: 0x06001045 RID: 4165 RVA: 0x0002F911 File Offset: 0x0002DB11
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >=(float2 lhs, float2 rhs)
		{
			return new bool2(lhs.x >= rhs.x, lhs.y >= rhs.y);
		}

		// Token: 0x06001046 RID: 4166 RVA: 0x0002F93A File Offset: 0x0002DB3A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >=(float2 lhs, float rhs)
		{
			return new bool2(lhs.x >= rhs, lhs.y >= rhs);
		}

		// Token: 0x06001047 RID: 4167 RVA: 0x0002F959 File Offset: 0x0002DB59
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >=(float lhs, float2 rhs)
		{
			return new bool2(lhs >= rhs.x, lhs >= rhs.y);
		}

		// Token: 0x06001048 RID: 4168 RVA: 0x0002F978 File Offset: 0x0002DB78
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator -(float2 val)
		{
			return new float2(-val.x, -val.y);
		}

		// Token: 0x06001049 RID: 4169 RVA: 0x0002F98D File Offset: 0x0002DB8D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 operator +(float2 val)
		{
			return new float2(val.x, val.y);
		}

		// Token: 0x0600104A RID: 4170 RVA: 0x0002F9A0 File Offset: 0x0002DBA0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(float2 lhs, float2 rhs)
		{
			return new bool2(lhs.x == rhs.x, lhs.y == rhs.y);
		}

		// Token: 0x0600104B RID: 4171 RVA: 0x0002F9C3 File Offset: 0x0002DBC3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(float2 lhs, float rhs)
		{
			return new bool2(lhs.x == rhs, lhs.y == rhs);
		}

		// Token: 0x0600104C RID: 4172 RVA: 0x0002F9DC File Offset: 0x0002DBDC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(float lhs, float2 rhs)
		{
			return new bool2(lhs == rhs.x, lhs == rhs.y);
		}

		// Token: 0x0600104D RID: 4173 RVA: 0x0002F9F5 File Offset: 0x0002DBF5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(float2 lhs, float2 rhs)
		{
			return new bool2(lhs.x != rhs.x, lhs.y != rhs.y);
		}

		// Token: 0x0600104E RID: 4174 RVA: 0x0002FA1E File Offset: 0x0002DC1E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(float2 lhs, float rhs)
		{
			return new bool2(lhs.x != rhs, lhs.y != rhs);
		}

		// Token: 0x0600104F RID: 4175 RVA: 0x0002FA3D File Offset: 0x0002DC3D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(float lhs, float2 rhs)
		{
			return new bool2(lhs != rhs.x, lhs != rhs.y);
		}

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x06001050 RID: 4176 RVA: 0x0002FA5C File Offset: 0x0002DC5C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.x, this.x);
			}
		}

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x06001051 RID: 4177 RVA: 0x0002FA7B File Offset: 0x0002DC7B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.x, this.y);
			}
		}

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x06001052 RID: 4178 RVA: 0x0002FA9A File Offset: 0x0002DC9A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.y, this.x);
			}
		}

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x06001053 RID: 4179 RVA: 0x0002FAB9 File Offset: 0x0002DCB9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.y, this.y);
			}
		}

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x06001054 RID: 4180 RVA: 0x0002FAD8 File Offset: 0x0002DCD8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.x, this.x);
			}
		}

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x06001055 RID: 4181 RVA: 0x0002FAF7 File Offset: 0x0002DCF7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.x, this.y);
			}
		}

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x06001056 RID: 4182 RVA: 0x0002FB16 File Offset: 0x0002DD16
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.y, this.x);
			}
		}

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x06001057 RID: 4183 RVA: 0x0002FB35 File Offset: 0x0002DD35
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.y, this.y);
			}
		}

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x06001058 RID: 4184 RVA: 0x0002FB54 File Offset: 0x0002DD54
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.x, this.x);
			}
		}

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x06001059 RID: 4185 RVA: 0x0002FB73 File Offset: 0x0002DD73
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.x, this.y);
			}
		}

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x0600105A RID: 4186 RVA: 0x0002FB92 File Offset: 0x0002DD92
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.y, this.x);
			}
		}

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x0600105B RID: 4187 RVA: 0x0002FBB1 File Offset: 0x0002DDB1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.y, this.y);
			}
		}

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x0600105C RID: 4188 RVA: 0x0002FBD0 File Offset: 0x0002DDD0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.x, this.x);
			}
		}

		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x0600105D RID: 4189 RVA: 0x0002FBEF File Offset: 0x0002DDEF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.x, this.y);
			}
		}

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x0600105E RID: 4190 RVA: 0x0002FC0E File Offset: 0x0002DE0E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.y, this.x);
			}
		}

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x0600105F RID: 4191 RVA: 0x0002FC2D File Offset: 0x0002DE2D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.y, this.y);
			}
		}

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x06001060 RID: 4192 RVA: 0x0002FC4C File Offset: 0x0002DE4C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.x, this.x);
			}
		}

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x06001061 RID: 4193 RVA: 0x0002FC65 File Offset: 0x0002DE65
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.x, this.y);
			}
		}

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x06001062 RID: 4194 RVA: 0x0002FC7E File Offset: 0x0002DE7E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.y, this.x);
			}
		}

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x06001063 RID: 4195 RVA: 0x0002FC97 File Offset: 0x0002DE97
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.y, this.y);
			}
		}

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x06001064 RID: 4196 RVA: 0x0002FCB0 File Offset: 0x0002DEB0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.x, this.x);
			}
		}

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x06001065 RID: 4197 RVA: 0x0002FCC9 File Offset: 0x0002DEC9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.x, this.y);
			}
		}

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x06001066 RID: 4198 RVA: 0x0002FCE2 File Offset: 0x0002DEE2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.y, this.x);
			}
		}

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x06001067 RID: 4199 RVA: 0x0002FCFB File Offset: 0x0002DEFB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.y, this.y);
			}
		}

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x06001068 RID: 4200 RVA: 0x0002FD14 File Offset: 0x0002DF14
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.x, this.x);
			}
		}

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06001069 RID: 4201 RVA: 0x0002FD27 File Offset: 0x0002DF27
		// (set) Token: 0x0600106A RID: 4202 RVA: 0x0002FD3A File Offset: 0x0002DF3A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 xy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x0600106B RID: 4203 RVA: 0x0002FD54 File Offset: 0x0002DF54
		// (set) Token: 0x0600106C RID: 4204 RVA: 0x0002FD67 File Offset: 0x0002DF67
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 yx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x0600106D RID: 4205 RVA: 0x0002FD81 File Offset: 0x0002DF81
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 yy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.y, this.y);
			}
		}

		// Token: 0x170003F7 RID: 1015
		public unsafe float this[int index]
		{
			get
			{
				fixed (float2* ptr = &this)
				{
					return ((float*)ptr)[index];
				}
			}
			set
			{
				fixed (float* ptr = &this.x)
				{
					ptr[index] = value;
				}
			}
		}

		// Token: 0x06001070 RID: 4208 RVA: 0x0002FDCC File Offset: 0x0002DFCC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(float2 rhs)
		{
			return this.x == rhs.x && this.y == rhs.y;
		}

		// Token: 0x06001071 RID: 4209 RVA: 0x0002FDEC File Offset: 0x0002DFEC
		public override bool Equals(object o)
		{
			if (o is float2)
			{
				float2 rhs = (float2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06001072 RID: 4210 RVA: 0x0002FE11 File Offset: 0x0002E011
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06001073 RID: 4211 RVA: 0x0002FE1E File Offset: 0x0002E01E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("float2({0}f, {1}f)", this.x, this.y);
		}

		// Token: 0x06001074 RID: 4212 RVA: 0x0002FE40 File Offset: 0x0002E040
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("float2({0}f, {1}f)", this.x.ToString(format, formatProvider), this.y.ToString(format, formatProvider));
		}

		// Token: 0x06001075 RID: 4213 RVA: 0x0002FE66 File Offset: 0x0002E066
		public static implicit operator Vector2(float2 v)
		{
			return new Vector2(v.x, v.y);
		}

		// Token: 0x06001076 RID: 4214 RVA: 0x0002FE79 File Offset: 0x0002E079
		public static implicit operator float2(Vector2 v)
		{
			return new float2(v.x, v.y);
		}

		// Token: 0x0400006E RID: 110
		public float x;

		// Token: 0x0400006F RID: 111
		public float y;

		// Token: 0x04000070 RID: 112
		public static readonly float2 zero;

		// Token: 0x0200005A RID: 90
		internal sealed class DebuggerProxy
		{
			// Token: 0x0600246F RID: 9327 RVA: 0x00067600 File Offset: 0x00065800
			public DebuggerProxy(float2 v)
			{
				this.x = v.x;
				this.y = v.y;
			}

			// Token: 0x0400014C RID: 332
			public float x;

			// Token: 0x0400014D RID: 333
			public float y;
		}
	}
}
