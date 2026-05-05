using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Unity.Mathematics
{
	// Token: 0x02000025 RID: 37
	[DebuggerTypeProxy(typeof(float4.DebuggerProxy))]
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct float4 : IEquatable<float4>, IFormattable
	{
		// Token: 0x060012DA RID: 4826 RVA: 0x00036BDD File Offset: 0x00034DDD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(float x, float y, float z, float w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		// Token: 0x060012DB RID: 4827 RVA: 0x00036BFC File Offset: 0x00034DFC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(float x, float y, float2 zw)
		{
			this.x = x;
			this.y = y;
			this.z = zw.x;
			this.w = zw.y;
		}

		// Token: 0x060012DC RID: 4828 RVA: 0x00036C24 File Offset: 0x00034E24
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(float x, float2 yz, float w)
		{
			this.x = x;
			this.y = yz.x;
			this.z = yz.y;
			this.w = w;
		}

		// Token: 0x060012DD RID: 4829 RVA: 0x00036C4C File Offset: 0x00034E4C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(float x, float3 yzw)
		{
			this.x = x;
			this.y = yzw.x;
			this.z = yzw.y;
			this.w = yzw.z;
		}

		// Token: 0x060012DE RID: 4830 RVA: 0x00036C79 File Offset: 0x00034E79
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(float2 xy, float z, float w)
		{
			this.x = xy.x;
			this.y = xy.y;
			this.z = z;
			this.w = w;
		}

		// Token: 0x060012DF RID: 4831 RVA: 0x00036CA1 File Offset: 0x00034EA1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(float2 xy, float2 zw)
		{
			this.x = xy.x;
			this.y = xy.y;
			this.z = zw.x;
			this.w = zw.y;
		}

		// Token: 0x060012E0 RID: 4832 RVA: 0x00036CD3 File Offset: 0x00034ED3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(float3 xyz, float w)
		{
			this.x = xyz.x;
			this.y = xyz.y;
			this.z = xyz.z;
			this.w = w;
		}

		// Token: 0x060012E1 RID: 4833 RVA: 0x00036D00 File Offset: 0x00034F00
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(float4 xyzw)
		{
			this.x = xyzw.x;
			this.y = xyzw.y;
			this.z = xyzw.z;
			this.w = xyzw.w;
		}

		// Token: 0x060012E2 RID: 4834 RVA: 0x00036D32 File Offset: 0x00034F32
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(float v)
		{
			this.x = v;
			this.y = v;
			this.z = v;
			this.w = v;
		}

		// Token: 0x060012E3 RID: 4835 RVA: 0x00036D50 File Offset: 0x00034F50
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(bool v)
		{
			this.x = (v ? 1f : 0f);
			this.y = (v ? 1f : 0f);
			this.z = (v ? 1f : 0f);
			this.w = (v ? 1f : 0f);
		}

		// Token: 0x060012E4 RID: 4836 RVA: 0x00036DB4 File Offset: 0x00034FB4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(bool4 v)
		{
			this.x = (v.x ? 1f : 0f);
			this.y = (v.y ? 1f : 0f);
			this.z = (v.z ? 1f : 0f);
			this.w = (v.w ? 1f : 0f);
		}

		// Token: 0x060012E5 RID: 4837 RVA: 0x00036E29 File Offset: 0x00035029
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(int v)
		{
			this.x = (float)v;
			this.y = (float)v;
			this.z = (float)v;
			this.w = (float)v;
		}

		// Token: 0x060012E6 RID: 4838 RVA: 0x00036E4B File Offset: 0x0003504B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(int4 v)
		{
			this.x = (float)v.x;
			this.y = (float)v.y;
			this.z = (float)v.z;
			this.w = (float)v.w;
		}

		// Token: 0x060012E7 RID: 4839 RVA: 0x00036E81 File Offset: 0x00035081
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(uint v)
		{
			this.x = v;
			this.y = v;
			this.z = v;
			this.w = v;
		}

		// Token: 0x060012E8 RID: 4840 RVA: 0x00036EA7 File Offset: 0x000350A7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(uint4 v)
		{
			this.x = v.x;
			this.y = v.y;
			this.z = v.z;
			this.w = v.w;
		}

		// Token: 0x060012E9 RID: 4841 RVA: 0x00036EE1 File Offset: 0x000350E1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(half v)
		{
			this.x = v;
			this.y = v;
			this.z = v;
			this.w = v;
		}

		// Token: 0x060012EA RID: 4842 RVA: 0x00036F14 File Offset: 0x00035114
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(half4 v)
		{
			this.x = v.x;
			this.y = v.y;
			this.z = v.z;
			this.w = v.w;
		}

		// Token: 0x060012EB RID: 4843 RVA: 0x00036F65 File Offset: 0x00035165
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(double v)
		{
			this.x = (float)v;
			this.y = (float)v;
			this.z = (float)v;
			this.w = (float)v;
		}

		// Token: 0x060012EC RID: 4844 RVA: 0x00036F87 File Offset: 0x00035187
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4(double4 v)
		{
			this.x = (float)v.x;
			this.y = (float)v.y;
			this.z = (float)v.z;
			this.w = (float)v.w;
		}

		// Token: 0x060012ED RID: 4845 RVA: 0x00036FBD File Offset: 0x000351BD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4(float v)
		{
			return new float4(v);
		}

		// Token: 0x060012EE RID: 4846 RVA: 0x00036FC5 File Offset: 0x000351C5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float4(bool v)
		{
			return new float4(v);
		}

		// Token: 0x060012EF RID: 4847 RVA: 0x00036FCD File Offset: 0x000351CD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float4(bool4 v)
		{
			return new float4(v);
		}

		// Token: 0x060012F0 RID: 4848 RVA: 0x00036FD5 File Offset: 0x000351D5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4(int v)
		{
			return new float4(v);
		}

		// Token: 0x060012F1 RID: 4849 RVA: 0x00036FDD File Offset: 0x000351DD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4(int4 v)
		{
			return new float4(v);
		}

		// Token: 0x060012F2 RID: 4850 RVA: 0x00036FE5 File Offset: 0x000351E5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4(uint v)
		{
			return new float4(v);
		}

		// Token: 0x060012F3 RID: 4851 RVA: 0x00036FED File Offset: 0x000351ED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4(uint4 v)
		{
			return new float4(v);
		}

		// Token: 0x060012F4 RID: 4852 RVA: 0x00036FF5 File Offset: 0x000351F5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4(half v)
		{
			return new float4(v);
		}

		// Token: 0x060012F5 RID: 4853 RVA: 0x00036FFD File Offset: 0x000351FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4(half4 v)
		{
			return new float4(v);
		}

		// Token: 0x060012F6 RID: 4854 RVA: 0x00037005 File Offset: 0x00035205
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float4(double v)
		{
			return new float4(v);
		}

		// Token: 0x060012F7 RID: 4855 RVA: 0x0003700D File Offset: 0x0003520D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float4(double4 v)
		{
			return new float4(v);
		}

		// Token: 0x060012F8 RID: 4856 RVA: 0x00037015 File Offset: 0x00035215
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator *(float4 lhs, float4 rhs)
		{
			return new float4(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w);
		}

		// Token: 0x060012F9 RID: 4857 RVA: 0x00037050 File Offset: 0x00035250
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator *(float4 lhs, float rhs)
		{
			return new float4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
		}

		// Token: 0x060012FA RID: 4858 RVA: 0x00037077 File Offset: 0x00035277
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator *(float lhs, float4 rhs)
		{
			return new float4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w);
		}

		// Token: 0x060012FB RID: 4859 RVA: 0x0003709E File Offset: 0x0003529E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator +(float4 lhs, float4 rhs)
		{
			return new float4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
		}

		// Token: 0x060012FC RID: 4860 RVA: 0x000370D9 File Offset: 0x000352D9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator +(float4 lhs, float rhs)
		{
			return new float4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);
		}

		// Token: 0x060012FD RID: 4861 RVA: 0x00037100 File Offset: 0x00035300
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator +(float lhs, float4 rhs)
		{
			return new float4(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z, lhs + rhs.w);
		}

		// Token: 0x060012FE RID: 4862 RVA: 0x00037127 File Offset: 0x00035327
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator -(float4 lhs, float4 rhs)
		{
			return new float4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
		}

		// Token: 0x060012FF RID: 4863 RVA: 0x00037162 File Offset: 0x00035362
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator -(float4 lhs, float rhs)
		{
			return new float4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);
		}

		// Token: 0x06001300 RID: 4864 RVA: 0x00037189 File Offset: 0x00035389
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator -(float lhs, float4 rhs)
		{
			return new float4(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z, lhs - rhs.w);
		}

		// Token: 0x06001301 RID: 4865 RVA: 0x000371B0 File Offset: 0x000353B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator /(float4 lhs, float4 rhs)
		{
			return new float4(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z, lhs.w / rhs.w);
		}

		// Token: 0x06001302 RID: 4866 RVA: 0x000371EB File Offset: 0x000353EB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator /(float4 lhs, float rhs)
		{
			return new float4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
		}

		// Token: 0x06001303 RID: 4867 RVA: 0x00037212 File Offset: 0x00035412
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator /(float lhs, float4 rhs)
		{
			return new float4(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z, lhs / rhs.w);
		}

		// Token: 0x06001304 RID: 4868 RVA: 0x00037239 File Offset: 0x00035439
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator %(float4 lhs, float4 rhs)
		{
			return new float4(lhs.x % rhs.x, lhs.y % rhs.y, lhs.z % rhs.z, lhs.w % rhs.w);
		}

		// Token: 0x06001305 RID: 4869 RVA: 0x00037274 File Offset: 0x00035474
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator %(float4 lhs, float rhs)
		{
			return new float4(lhs.x % rhs, lhs.y % rhs, lhs.z % rhs, lhs.w % rhs);
		}

		// Token: 0x06001306 RID: 4870 RVA: 0x0003729B File Offset: 0x0003549B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator %(float lhs, float4 rhs)
		{
			return new float4(lhs % rhs.x, lhs % rhs.y, lhs % rhs.z, lhs % rhs.w);
		}

		// Token: 0x06001307 RID: 4871 RVA: 0x000372C4 File Offset: 0x000354C4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator ++(float4 val)
		{
			float num = val.x + 1f;
			val.x = num;
			float num2 = num;
			num = val.y + 1f;
			val.y = num;
			float num3 = num;
			num = val.z + 1f;
			val.z = num;
			float num4 = num;
			num = val.w + 1f;
			val.w = num;
			return new float4(num2, num3, num4, num);
		}

		// Token: 0x06001308 RID: 4872 RVA: 0x00037324 File Offset: 0x00035524
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator --(float4 val)
		{
			float num = val.x - 1f;
			val.x = num;
			float num2 = num;
			num = val.y - 1f;
			val.y = num;
			float num3 = num;
			num = val.z - 1f;
			val.z = num;
			float num4 = num;
			num = val.w - 1f;
			val.w = num;
			return new float4(num2, num3, num4, num);
		}

		// Token: 0x06001309 RID: 4873 RVA: 0x00037382 File Offset: 0x00035582
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator <(float4 lhs, float4 rhs)
		{
			return new bool4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w);
		}

		// Token: 0x0600130A RID: 4874 RVA: 0x000373C1 File Offset: 0x000355C1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator <(float4 lhs, float rhs)
		{
			return new bool4(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs, lhs.w < rhs);
		}

		// Token: 0x0600130B RID: 4875 RVA: 0x000373EC File Offset: 0x000355EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator <(float lhs, float4 rhs)
		{
			return new bool4(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z, lhs < rhs.w);
		}

		// Token: 0x0600130C RID: 4876 RVA: 0x00037418 File Offset: 0x00035618
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator <=(float4 lhs, float4 rhs)
		{
			return new bool4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w);
		}

		// Token: 0x0600130D RID: 4877 RVA: 0x0003746E File Offset: 0x0003566E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator <=(float4 lhs, float rhs)
		{
			return new bool4(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs, lhs.w <= rhs);
		}

		// Token: 0x0600130E RID: 4878 RVA: 0x000374A5 File Offset: 0x000356A5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator <=(float lhs, float4 rhs)
		{
			return new bool4(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z, lhs <= rhs.w);
		}

		// Token: 0x0600130F RID: 4879 RVA: 0x000374DC File Offset: 0x000356DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator >(float4 lhs, float4 rhs)
		{
			return new bool4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w);
		}

		// Token: 0x06001310 RID: 4880 RVA: 0x0003751B File Offset: 0x0003571B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator >(float4 lhs, float rhs)
		{
			return new bool4(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs, lhs.w > rhs);
		}

		// Token: 0x06001311 RID: 4881 RVA: 0x00037546 File Offset: 0x00035746
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator >(float lhs, float4 rhs)
		{
			return new bool4(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z, lhs > rhs.w);
		}

		// Token: 0x06001312 RID: 4882 RVA: 0x00037574 File Offset: 0x00035774
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator >=(float4 lhs, float4 rhs)
		{
			return new bool4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w);
		}

		// Token: 0x06001313 RID: 4883 RVA: 0x000375CA File Offset: 0x000357CA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator >=(float4 lhs, float rhs)
		{
			return new bool4(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs, lhs.w >= rhs);
		}

		// Token: 0x06001314 RID: 4884 RVA: 0x00037601 File Offset: 0x00035801
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator >=(float lhs, float4 rhs)
		{
			return new bool4(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z, lhs >= rhs.w);
		}

		// Token: 0x06001315 RID: 4885 RVA: 0x00037638 File Offset: 0x00035838
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator -(float4 val)
		{
			return new float4(-val.x, -val.y, -val.z, -val.w);
		}

		// Token: 0x06001316 RID: 4886 RVA: 0x0003765B File Offset: 0x0003585B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 operator +(float4 val)
		{
			return new float4(val.x, val.y, val.z, val.w);
		}

		// Token: 0x06001317 RID: 4887 RVA: 0x0003767A File Offset: 0x0003587A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator ==(float4 lhs, float4 rhs)
		{
			return new bool4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);
		}

		// Token: 0x06001318 RID: 4888 RVA: 0x000376B9 File Offset: 0x000358B9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator ==(float4 lhs, float rhs)
		{
			return new bool4(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs, lhs.w == rhs);
		}

		// Token: 0x06001319 RID: 4889 RVA: 0x000376E4 File Offset: 0x000358E4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator ==(float lhs, float4 rhs)
		{
			return new bool4(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z, lhs == rhs.w);
		}

		// Token: 0x0600131A RID: 4890 RVA: 0x00037710 File Offset: 0x00035910
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator !=(float4 lhs, float4 rhs)
		{
			return new bool4(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w);
		}

		// Token: 0x0600131B RID: 4891 RVA: 0x00037766 File Offset: 0x00035966
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator !=(float4 lhs, float rhs)
		{
			return new bool4(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs, lhs.w != rhs);
		}

		// Token: 0x0600131C RID: 4892 RVA: 0x0003779D File Offset: 0x0003599D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator !=(float lhs, float4 rhs)
		{
			return new bool4(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z, lhs != rhs.w);
		}

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x0600131D RID: 4893 RVA: 0x000377D4 File Offset: 0x000359D4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.x, this.x);
			}
		}

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x0600131E RID: 4894 RVA: 0x000377F3 File Offset: 0x000359F3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.x, this.y);
			}
		}

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x0600131F RID: 4895 RVA: 0x00037812 File Offset: 0x00035A12
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.x, this.z);
			}
		}

		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x06001320 RID: 4896 RVA: 0x00037831 File Offset: 0x00035A31
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.x, this.w);
			}
		}

		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x06001321 RID: 4897 RVA: 0x00037850 File Offset: 0x00035A50
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.y, this.x);
			}
		}

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x06001322 RID: 4898 RVA: 0x0003786F File Offset: 0x00035A6F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.y, this.y);
			}
		}

		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x06001323 RID: 4899 RVA: 0x0003788E File Offset: 0x00035A8E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.y, this.z);
			}
		}

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x06001324 RID: 4900 RVA: 0x000378AD File Offset: 0x00035AAD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.y, this.w);
			}
		}

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x06001325 RID: 4901 RVA: 0x000378CC File Offset: 0x00035ACC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.z, this.x);
			}
		}

		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x06001326 RID: 4902 RVA: 0x000378EB File Offset: 0x00035AEB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.z, this.y);
			}
		}

		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x06001327 RID: 4903 RVA: 0x0003790A File Offset: 0x00035B0A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.z, this.z);
			}
		}

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x06001328 RID: 4904 RVA: 0x00037929 File Offset: 0x00035B29
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.z, this.w);
			}
		}

		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x06001329 RID: 4905 RVA: 0x00037948 File Offset: 0x00035B48
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.w, this.x);
			}
		}

		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x0600132A RID: 4906 RVA: 0x00037967 File Offset: 0x00035B67
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.w, this.y);
			}
		}

		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x0600132B RID: 4907 RVA: 0x00037986 File Offset: 0x00035B86
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.w, this.z);
			}
		}

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x0600132C RID: 4908 RVA: 0x000379A5 File Offset: 0x00035BA5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.w, this.w);
			}
		}

		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x0600132D RID: 4909 RVA: 0x000379C4 File Offset: 0x00035BC4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.x, this.x);
			}
		}

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x0600132E RID: 4910 RVA: 0x000379E3 File Offset: 0x00035BE3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.x, this.y);
			}
		}

		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x0600132F RID: 4911 RVA: 0x00037A02 File Offset: 0x00035C02
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.x, this.z);
			}
		}

		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x06001330 RID: 4912 RVA: 0x00037A21 File Offset: 0x00035C21
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.x, this.w);
			}
		}

		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x06001331 RID: 4913 RVA: 0x00037A40 File Offset: 0x00035C40
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.y, this.x);
			}
		}

		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x06001332 RID: 4914 RVA: 0x00037A5F File Offset: 0x00035C5F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.y, this.y);
			}
		}

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x06001333 RID: 4915 RVA: 0x00037A7E File Offset: 0x00035C7E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.y, this.z);
			}
		}

		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x06001334 RID: 4916 RVA: 0x00037A9D File Offset: 0x00035C9D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.y, this.w);
			}
		}

		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x06001335 RID: 4917 RVA: 0x00037ABC File Offset: 0x00035CBC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.z, this.x);
			}
		}

		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x06001336 RID: 4918 RVA: 0x00037ADB File Offset: 0x00035CDB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.z, this.y);
			}
		}

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x06001337 RID: 4919 RVA: 0x00037AFA File Offset: 0x00035CFA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.z, this.z);
			}
		}

		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x06001338 RID: 4920 RVA: 0x00037B19 File Offset: 0x00035D19
		// (set) Token: 0x06001339 RID: 4921 RVA: 0x00037B38 File Offset: 0x00035D38
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.z, this.w);
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

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x0600133A RID: 4922 RVA: 0x00037B6A File Offset: 0x00035D6A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.w, this.x);
			}
		}

		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x0600133B RID: 4923 RVA: 0x00037B89 File Offset: 0x00035D89
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.w, this.y);
			}
		}

		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x0600133C RID: 4924 RVA: 0x00037BA8 File Offset: 0x00035DA8
		// (set) Token: 0x0600133D RID: 4925 RVA: 0x00037BC7 File Offset: 0x00035DC7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.w, this.z);
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

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x0600133E RID: 4926 RVA: 0x00037BF9 File Offset: 0x00035DF9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.w, this.w);
			}
		}

		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x0600133F RID: 4927 RVA: 0x00037C18 File Offset: 0x00035E18
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.x, this.x);
			}
		}

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x06001340 RID: 4928 RVA: 0x00037C37 File Offset: 0x00035E37
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.x, this.y);
			}
		}

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x06001341 RID: 4929 RVA: 0x00037C56 File Offset: 0x00035E56
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.x, this.z);
			}
		}

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x06001342 RID: 4930 RVA: 0x00037C75 File Offset: 0x00035E75
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.x, this.w);
			}
		}

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x06001343 RID: 4931 RVA: 0x00037C94 File Offset: 0x00035E94
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.y, this.x);
			}
		}

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x06001344 RID: 4932 RVA: 0x00037CB3 File Offset: 0x00035EB3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.y, this.y);
			}
		}

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x06001345 RID: 4933 RVA: 0x00037CD2 File Offset: 0x00035ED2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.y, this.z);
			}
		}

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x06001346 RID: 4934 RVA: 0x00037CF1 File Offset: 0x00035EF1
		// (set) Token: 0x06001347 RID: 4935 RVA: 0x00037D10 File Offset: 0x00035F10
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.y, this.w);
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

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x06001348 RID: 4936 RVA: 0x00037D42 File Offset: 0x00035F42
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.z, this.x);
			}
		}

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x06001349 RID: 4937 RVA: 0x00037D61 File Offset: 0x00035F61
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.z, this.y);
			}
		}

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x0600134A RID: 4938 RVA: 0x00037D80 File Offset: 0x00035F80
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.z, this.z);
			}
		}

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x0600134B RID: 4939 RVA: 0x00037D9F File Offset: 0x00035F9F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.z, this.w);
			}
		}

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x0600134C RID: 4940 RVA: 0x00037DBE File Offset: 0x00035FBE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.w, this.x);
			}
		}

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x0600134D RID: 4941 RVA: 0x00037DDD File Offset: 0x00035FDD
		// (set) Token: 0x0600134E RID: 4942 RVA: 0x00037DFC File Offset: 0x00035FFC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.w, this.y);
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

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x0600134F RID: 4943 RVA: 0x00037E2E File Offset: 0x0003602E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.w, this.z);
			}
		}

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x06001350 RID: 4944 RVA: 0x00037E4D File Offset: 0x0003604D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.w, this.w);
			}
		}

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x06001351 RID: 4945 RVA: 0x00037E6C File Offset: 0x0003606C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.w, this.x, this.x);
			}
		}

		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x06001352 RID: 4946 RVA: 0x00037E8B File Offset: 0x0003608B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.w, this.x, this.y);
			}
		}

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x06001353 RID: 4947 RVA: 0x00037EAA File Offset: 0x000360AA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.w, this.x, this.z);
			}
		}

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x06001354 RID: 4948 RVA: 0x00037EC9 File Offset: 0x000360C9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.w, this.x, this.w);
			}
		}

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06001355 RID: 4949 RVA: 0x00037EE8 File Offset: 0x000360E8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.w, this.y, this.x);
			}
		}

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x06001356 RID: 4950 RVA: 0x00037F07 File Offset: 0x00036107
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.w, this.y, this.y);
			}
		}

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x06001357 RID: 4951 RVA: 0x00037F26 File Offset: 0x00036126
		// (set) Token: 0x06001358 RID: 4952 RVA: 0x00037F45 File Offset: 0x00036145
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.w, this.y, this.z);
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

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x06001359 RID: 4953 RVA: 0x00037F77 File Offset: 0x00036177
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.w, this.y, this.w);
			}
		}

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x0600135A RID: 4954 RVA: 0x00037F96 File Offset: 0x00036196
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.w, this.z, this.x);
			}
		}

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x0600135B RID: 4955 RVA: 0x00037FB5 File Offset: 0x000361B5
		// (set) Token: 0x0600135C RID: 4956 RVA: 0x00037FD4 File Offset: 0x000361D4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.w, this.z, this.y);
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

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x0600135D RID: 4957 RVA: 0x00038006 File Offset: 0x00036206
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.w, this.z, this.z);
			}
		}

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x0600135E RID: 4958 RVA: 0x00038025 File Offset: 0x00036225
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.w, this.z, this.w);
			}
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x0600135F RID: 4959 RVA: 0x00038044 File Offset: 0x00036244
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.w, this.w, this.x);
			}
		}

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06001360 RID: 4960 RVA: 0x00038063 File Offset: 0x00036263
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.w, this.w, this.y);
			}
		}

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x06001361 RID: 4961 RVA: 0x00038082 File Offset: 0x00036282
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.w, this.w, this.z);
			}
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x06001362 RID: 4962 RVA: 0x000380A1 File Offset: 0x000362A1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.w, this.w, this.w);
			}
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x06001363 RID: 4963 RVA: 0x000380C0 File Offset: 0x000362C0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.x, this.x);
			}
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x06001364 RID: 4964 RVA: 0x000380DF File Offset: 0x000362DF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.x, this.y);
			}
		}

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x06001365 RID: 4965 RVA: 0x000380FE File Offset: 0x000362FE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.x, this.z);
			}
		}

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x06001366 RID: 4966 RVA: 0x0003811D File Offset: 0x0003631D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.x, this.w);
			}
		}

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x06001367 RID: 4967 RVA: 0x0003813C File Offset: 0x0003633C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.y, this.x);
			}
		}

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x06001368 RID: 4968 RVA: 0x0003815B File Offset: 0x0003635B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.y, this.y);
			}
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x06001369 RID: 4969 RVA: 0x0003817A File Offset: 0x0003637A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.y, this.z);
			}
		}

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x0600136A RID: 4970 RVA: 0x00038199 File Offset: 0x00036399
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.y, this.w);
			}
		}

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x0600136B RID: 4971 RVA: 0x000381B8 File Offset: 0x000363B8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.z, this.x);
			}
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x0600136C RID: 4972 RVA: 0x000381D7 File Offset: 0x000363D7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.z, this.y);
			}
		}

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x0600136D RID: 4973 RVA: 0x000381F6 File Offset: 0x000363F6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.z, this.z);
			}
		}

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x0600136E RID: 4974 RVA: 0x00038215 File Offset: 0x00036415
		// (set) Token: 0x0600136F RID: 4975 RVA: 0x00038234 File Offset: 0x00036434
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.z, this.w);
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

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x06001370 RID: 4976 RVA: 0x00038266 File Offset: 0x00036466
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.w, this.x);
			}
		}

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x06001371 RID: 4977 RVA: 0x00038285 File Offset: 0x00036485
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.w, this.y);
			}
		}

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x06001372 RID: 4978 RVA: 0x000382A4 File Offset: 0x000364A4
		// (set) Token: 0x06001373 RID: 4979 RVA: 0x000382C3 File Offset: 0x000364C3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.w, this.z);
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

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x06001374 RID: 4980 RVA: 0x000382F5 File Offset: 0x000364F5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.w, this.w);
			}
		}

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x06001375 RID: 4981 RVA: 0x00038314 File Offset: 0x00036514
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.x, this.x);
			}
		}

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x06001376 RID: 4982 RVA: 0x00038333 File Offset: 0x00036533
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.x, this.y);
			}
		}

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x06001377 RID: 4983 RVA: 0x00038352 File Offset: 0x00036552
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.x, this.z);
			}
		}

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x06001378 RID: 4984 RVA: 0x00038371 File Offset: 0x00036571
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.x, this.w);
			}
		}

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x06001379 RID: 4985 RVA: 0x00038390 File Offset: 0x00036590
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.y, this.x);
			}
		}

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x0600137A RID: 4986 RVA: 0x000383AF File Offset: 0x000365AF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.y, this.y);
			}
		}

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x0600137B RID: 4987 RVA: 0x000383CE File Offset: 0x000365CE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.y, this.z);
			}
		}

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x0600137C RID: 4988 RVA: 0x000383ED File Offset: 0x000365ED
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.y, this.w);
			}
		}

		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x0600137D RID: 4989 RVA: 0x0003840C File Offset: 0x0003660C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.z, this.x);
			}
		}

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x0600137E RID: 4990 RVA: 0x0003842B File Offset: 0x0003662B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.z, this.y);
			}
		}

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x0600137F RID: 4991 RVA: 0x0003844A File Offset: 0x0003664A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.z, this.z);
			}
		}

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x06001380 RID: 4992 RVA: 0x00038469 File Offset: 0x00036669
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.z, this.w);
			}
		}

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06001381 RID: 4993 RVA: 0x00038488 File Offset: 0x00036688
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.w, this.x);
			}
		}

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06001382 RID: 4994 RVA: 0x000384A7 File Offset: 0x000366A7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.w, this.y);
			}
		}

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06001383 RID: 4995 RVA: 0x000384C6 File Offset: 0x000366C6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.w, this.z);
			}
		}

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06001384 RID: 4996 RVA: 0x000384E5 File Offset: 0x000366E5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.w, this.w);
			}
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06001385 RID: 4997 RVA: 0x00038504 File Offset: 0x00036704
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.x, this.x);
			}
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x06001386 RID: 4998 RVA: 0x00038523 File Offset: 0x00036723
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.x, this.y);
			}
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x06001387 RID: 4999 RVA: 0x00038542 File Offset: 0x00036742
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.x, this.z);
			}
		}

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x06001388 RID: 5000 RVA: 0x00038561 File Offset: 0x00036761
		// (set) Token: 0x06001389 RID: 5001 RVA: 0x00038580 File Offset: 0x00036780
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.x, this.w);
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

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x0600138A RID: 5002 RVA: 0x000385B2 File Offset: 0x000367B2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.y, this.x);
			}
		}

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x0600138B RID: 5003 RVA: 0x000385D1 File Offset: 0x000367D1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.y, this.y);
			}
		}

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x0600138C RID: 5004 RVA: 0x000385F0 File Offset: 0x000367F0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.y, this.z);
			}
		}

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x0600138D RID: 5005 RVA: 0x0003860F File Offset: 0x0003680F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.y, this.w);
			}
		}

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x0600138E RID: 5006 RVA: 0x0003862E File Offset: 0x0003682E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.z, this.x);
			}
		}

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x0600138F RID: 5007 RVA: 0x0003864D File Offset: 0x0003684D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.z, this.y);
			}
		}

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x06001390 RID: 5008 RVA: 0x0003866C File Offset: 0x0003686C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.z, this.z);
			}
		}

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x06001391 RID: 5009 RVA: 0x0003868B File Offset: 0x0003688B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.z, this.w);
			}
		}

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x06001392 RID: 5010 RVA: 0x000386AA File Offset: 0x000368AA
		// (set) Token: 0x06001393 RID: 5011 RVA: 0x000386C9 File Offset: 0x000368C9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.w, this.x);
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

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06001394 RID: 5012 RVA: 0x000386FB File Offset: 0x000368FB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.w, this.y);
			}
		}

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x06001395 RID: 5013 RVA: 0x0003871A File Offset: 0x0003691A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.w, this.z);
			}
		}

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x06001396 RID: 5014 RVA: 0x00038739 File Offset: 0x00036939
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.w, this.w);
			}
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06001397 RID: 5015 RVA: 0x00038758 File Offset: 0x00036958
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 ywxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.w, this.x, this.x);
			}
		}

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06001398 RID: 5016 RVA: 0x00038777 File Offset: 0x00036977
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 ywxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.w, this.x, this.y);
			}
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06001399 RID: 5017 RVA: 0x00038796 File Offset: 0x00036996
		// (set) Token: 0x0600139A RID: 5018 RVA: 0x000387B5 File Offset: 0x000369B5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 ywxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.w, this.x, this.z);
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

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x0600139B RID: 5019 RVA: 0x000387E7 File Offset: 0x000369E7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 ywxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.w, this.x, this.w);
			}
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x0600139C RID: 5020 RVA: 0x00038806 File Offset: 0x00036A06
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 ywyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.w, this.y, this.x);
			}
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x0600139D RID: 5021 RVA: 0x00038825 File Offset: 0x00036A25
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 ywyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.w, this.y, this.y);
			}
		}

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x0600139E RID: 5022 RVA: 0x00038844 File Offset: 0x00036A44
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 ywyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.w, this.y, this.z);
			}
		}

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x0600139F RID: 5023 RVA: 0x00038863 File Offset: 0x00036A63
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 ywyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.w, this.y, this.w);
			}
		}

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x060013A0 RID: 5024 RVA: 0x00038882 File Offset: 0x00036A82
		// (set) Token: 0x060013A1 RID: 5025 RVA: 0x000388A1 File Offset: 0x00036AA1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 ywzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.w, this.z, this.x);
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

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x060013A2 RID: 5026 RVA: 0x000388D3 File Offset: 0x00036AD3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 ywzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.w, this.z, this.y);
			}
		}

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x060013A3 RID: 5027 RVA: 0x000388F2 File Offset: 0x00036AF2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 ywzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.w, this.z, this.z);
			}
		}

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x060013A4 RID: 5028 RVA: 0x00038911 File Offset: 0x00036B11
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 ywzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.w, this.z, this.w);
			}
		}

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x060013A5 RID: 5029 RVA: 0x00038930 File Offset: 0x00036B30
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 ywwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.w, this.w, this.x);
			}
		}

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x060013A6 RID: 5030 RVA: 0x0003894F File Offset: 0x00036B4F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 ywwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.w, this.w, this.y);
			}
		}

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x060013A7 RID: 5031 RVA: 0x0003896E File Offset: 0x00036B6E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 ywwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.w, this.w, this.z);
			}
		}

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x060013A8 RID: 5032 RVA: 0x0003898D File Offset: 0x00036B8D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 ywww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.w, this.w, this.w);
			}
		}

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x060013A9 RID: 5033 RVA: 0x000389AC File Offset: 0x00036BAC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.x, this.x);
			}
		}

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x060013AA RID: 5034 RVA: 0x000389CB File Offset: 0x00036BCB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.x, this.y);
			}
		}

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x060013AB RID: 5035 RVA: 0x000389EA File Offset: 0x00036BEA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.x, this.z);
			}
		}

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x060013AC RID: 5036 RVA: 0x00038A09 File Offset: 0x00036C09
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.x, this.w);
			}
		}

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x060013AD RID: 5037 RVA: 0x00038A28 File Offset: 0x00036C28
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.y, this.x);
			}
		}

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x060013AE RID: 5038 RVA: 0x00038A47 File Offset: 0x00036C47
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.y, this.y);
			}
		}

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x060013AF RID: 5039 RVA: 0x00038A66 File Offset: 0x00036C66
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.y, this.z);
			}
		}

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x060013B0 RID: 5040 RVA: 0x00038A85 File Offset: 0x00036C85
		// (set) Token: 0x060013B1 RID: 5041 RVA: 0x00038AA4 File Offset: 0x00036CA4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.y, this.w);
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

		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x060013B2 RID: 5042 RVA: 0x00038AD6 File Offset: 0x00036CD6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.z, this.x);
			}
		}

		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x060013B3 RID: 5043 RVA: 0x00038AF5 File Offset: 0x00036CF5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.z, this.y);
			}
		}

		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x060013B4 RID: 5044 RVA: 0x00038B14 File Offset: 0x00036D14
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.z, this.z);
			}
		}

		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x060013B5 RID: 5045 RVA: 0x00038B33 File Offset: 0x00036D33
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.z, this.w);
			}
		}

		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x060013B6 RID: 5046 RVA: 0x00038B52 File Offset: 0x00036D52
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.w, this.x);
			}
		}

		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x060013B7 RID: 5047 RVA: 0x00038B71 File Offset: 0x00036D71
		// (set) Token: 0x060013B8 RID: 5048 RVA: 0x00038B90 File Offset: 0x00036D90
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.w, this.y);
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

		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x060013B9 RID: 5049 RVA: 0x00038BC2 File Offset: 0x00036DC2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.w, this.z);
			}
		}

		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x060013BA RID: 5050 RVA: 0x00038BE1 File Offset: 0x00036DE1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.w, this.w);
			}
		}

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x060013BB RID: 5051 RVA: 0x00038C00 File Offset: 0x00036E00
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.x, this.x);
			}
		}

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x060013BC RID: 5052 RVA: 0x00038C1F File Offset: 0x00036E1F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.x, this.y);
			}
		}

		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x060013BD RID: 5053 RVA: 0x00038C3E File Offset: 0x00036E3E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.x, this.z);
			}
		}

		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x060013BE RID: 5054 RVA: 0x00038C5D File Offset: 0x00036E5D
		// (set) Token: 0x060013BF RID: 5055 RVA: 0x00038C7C File Offset: 0x00036E7C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.x, this.w);
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

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x060013C0 RID: 5056 RVA: 0x00038CAE File Offset: 0x00036EAE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.y, this.x);
			}
		}

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x060013C1 RID: 5057 RVA: 0x00038CCD File Offset: 0x00036ECD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.y, this.y);
			}
		}

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x060013C2 RID: 5058 RVA: 0x00038CEC File Offset: 0x00036EEC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.y, this.z);
			}
		}

		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x060013C3 RID: 5059 RVA: 0x00038D0B File Offset: 0x00036F0B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.y, this.w);
			}
		}

		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x060013C4 RID: 5060 RVA: 0x00038D2A File Offset: 0x00036F2A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.z, this.x);
			}
		}

		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x060013C5 RID: 5061 RVA: 0x00038D49 File Offset: 0x00036F49
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.z, this.y);
			}
		}

		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x060013C6 RID: 5062 RVA: 0x00038D68 File Offset: 0x00036F68
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.z, this.z);
			}
		}

		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x060013C7 RID: 5063 RVA: 0x00038D87 File Offset: 0x00036F87
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.z, this.w);
			}
		}

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x060013C8 RID: 5064 RVA: 0x00038DA6 File Offset: 0x00036FA6
		// (set) Token: 0x060013C9 RID: 5065 RVA: 0x00038DC5 File Offset: 0x00036FC5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.w, this.x);
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

		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x060013CA RID: 5066 RVA: 0x00038DF7 File Offset: 0x00036FF7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.w, this.y);
			}
		}

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x060013CB RID: 5067 RVA: 0x00038E16 File Offset: 0x00037016
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.w, this.z);
			}
		}

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x060013CC RID: 5068 RVA: 0x00038E35 File Offset: 0x00037035
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.w, this.w);
			}
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x060013CD RID: 5069 RVA: 0x00038E54 File Offset: 0x00037054
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.x, this.x);
			}
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x060013CE RID: 5070 RVA: 0x00038E73 File Offset: 0x00037073
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.x, this.y);
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x060013CF RID: 5071 RVA: 0x00038E92 File Offset: 0x00037092
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.x, this.z);
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x060013D0 RID: 5072 RVA: 0x00038EB1 File Offset: 0x000370B1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.x, this.w);
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x060013D1 RID: 5073 RVA: 0x00038ED0 File Offset: 0x000370D0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.y, this.x);
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x060013D2 RID: 5074 RVA: 0x00038EEF File Offset: 0x000370EF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.y, this.y);
			}
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x060013D3 RID: 5075 RVA: 0x00038F0E File Offset: 0x0003710E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.y, this.z);
			}
		}

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x060013D4 RID: 5076 RVA: 0x00038F2D File Offset: 0x0003712D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.y, this.w);
			}
		}

		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x060013D5 RID: 5077 RVA: 0x00038F4C File Offset: 0x0003714C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.z, this.x);
			}
		}

		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x060013D6 RID: 5078 RVA: 0x00038F6B File Offset: 0x0003716B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.z, this.y);
			}
		}

		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x060013D7 RID: 5079 RVA: 0x00038F8A File Offset: 0x0003718A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.z, this.z);
			}
		}

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x060013D8 RID: 5080 RVA: 0x00038FA9 File Offset: 0x000371A9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.z, this.w);
			}
		}

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x060013D9 RID: 5081 RVA: 0x00038FC8 File Offset: 0x000371C8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.w, this.x);
			}
		}

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x060013DA RID: 5082 RVA: 0x00038FE7 File Offset: 0x000371E7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.w, this.y);
			}
		}

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x060013DB RID: 5083 RVA: 0x00039006 File Offset: 0x00037206
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.w, this.z);
			}
		}

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x060013DC RID: 5084 RVA: 0x00039025 File Offset: 0x00037225
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.w, this.w);
			}
		}

		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x060013DD RID: 5085 RVA: 0x00039044 File Offset: 0x00037244
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.w, this.x, this.x);
			}
		}

		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x060013DE RID: 5086 RVA: 0x00039063 File Offset: 0x00037263
		// (set) Token: 0x060013DF RID: 5087 RVA: 0x00039082 File Offset: 0x00037282
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.w, this.x, this.y);
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

		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x060013E0 RID: 5088 RVA: 0x000390B4 File Offset: 0x000372B4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.w, this.x, this.z);
			}
		}

		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x060013E1 RID: 5089 RVA: 0x000390D3 File Offset: 0x000372D3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.w, this.x, this.w);
			}
		}

		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x060013E2 RID: 5090 RVA: 0x000390F2 File Offset: 0x000372F2
		// (set) Token: 0x060013E3 RID: 5091 RVA: 0x00039111 File Offset: 0x00037311
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.w, this.y, this.x);
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

		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x060013E4 RID: 5092 RVA: 0x00039143 File Offset: 0x00037343
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.w, this.y, this.y);
			}
		}

		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x060013E5 RID: 5093 RVA: 0x00039162 File Offset: 0x00037362
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.w, this.y, this.z);
			}
		}

		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x060013E6 RID: 5094 RVA: 0x00039181 File Offset: 0x00037381
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.w, this.y, this.w);
			}
		}

		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x060013E7 RID: 5095 RVA: 0x000391A0 File Offset: 0x000373A0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.w, this.z, this.x);
			}
		}

		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x060013E8 RID: 5096 RVA: 0x000391BF File Offset: 0x000373BF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.w, this.z, this.y);
			}
		}

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x060013E9 RID: 5097 RVA: 0x000391DE File Offset: 0x000373DE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.w, this.z, this.z);
			}
		}

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x060013EA RID: 5098 RVA: 0x000391FD File Offset: 0x000373FD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.w, this.z, this.w);
			}
		}

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x060013EB RID: 5099 RVA: 0x0003921C File Offset: 0x0003741C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.w, this.w, this.x);
			}
		}

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x060013EC RID: 5100 RVA: 0x0003923B File Offset: 0x0003743B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.w, this.w, this.y);
			}
		}

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x060013ED RID: 5101 RVA: 0x0003925A File Offset: 0x0003745A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.w, this.w, this.z);
			}
		}

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x060013EE RID: 5102 RVA: 0x00039279 File Offset: 0x00037479
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.w, this.w, this.w);
			}
		}

		// Token: 0x17000534 RID: 1332
		// (get) Token: 0x060013EF RID: 5103 RVA: 0x00039298 File Offset: 0x00037498
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.x, this.x, this.x);
			}
		}

		// Token: 0x17000535 RID: 1333
		// (get) Token: 0x060013F0 RID: 5104 RVA: 0x000392B7 File Offset: 0x000374B7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.x, this.x, this.y);
			}
		}

		// Token: 0x17000536 RID: 1334
		// (get) Token: 0x060013F1 RID: 5105 RVA: 0x000392D6 File Offset: 0x000374D6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.x, this.x, this.z);
			}
		}

		// Token: 0x17000537 RID: 1335
		// (get) Token: 0x060013F2 RID: 5106 RVA: 0x000392F5 File Offset: 0x000374F5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.x, this.x, this.w);
			}
		}

		// Token: 0x17000538 RID: 1336
		// (get) Token: 0x060013F3 RID: 5107 RVA: 0x00039314 File Offset: 0x00037514
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.x, this.y, this.x);
			}
		}

		// Token: 0x17000539 RID: 1337
		// (get) Token: 0x060013F4 RID: 5108 RVA: 0x00039333 File Offset: 0x00037533
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.x, this.y, this.y);
			}
		}

		// Token: 0x1700053A RID: 1338
		// (get) Token: 0x060013F5 RID: 5109 RVA: 0x00039352 File Offset: 0x00037552
		// (set) Token: 0x060013F6 RID: 5110 RVA: 0x00039371 File Offset: 0x00037571
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.x, this.y, this.z);
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

		// Token: 0x1700053B RID: 1339
		// (get) Token: 0x060013F7 RID: 5111 RVA: 0x000393A3 File Offset: 0x000375A3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.x, this.y, this.w);
			}
		}

		// Token: 0x1700053C RID: 1340
		// (get) Token: 0x060013F8 RID: 5112 RVA: 0x000393C2 File Offset: 0x000375C2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.x, this.z, this.x);
			}
		}

		// Token: 0x1700053D RID: 1341
		// (get) Token: 0x060013F9 RID: 5113 RVA: 0x000393E1 File Offset: 0x000375E1
		// (set) Token: 0x060013FA RID: 5114 RVA: 0x00039400 File Offset: 0x00037600
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.x, this.z, this.y);
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

		// Token: 0x1700053E RID: 1342
		// (get) Token: 0x060013FB RID: 5115 RVA: 0x00039432 File Offset: 0x00037632
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.x, this.z, this.z);
			}
		}

		// Token: 0x1700053F RID: 1343
		// (get) Token: 0x060013FC RID: 5116 RVA: 0x00039451 File Offset: 0x00037651
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.x, this.z, this.w);
			}
		}

		// Token: 0x17000540 RID: 1344
		// (get) Token: 0x060013FD RID: 5117 RVA: 0x00039470 File Offset: 0x00037670
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.x, this.w, this.x);
			}
		}

		// Token: 0x17000541 RID: 1345
		// (get) Token: 0x060013FE RID: 5118 RVA: 0x0003948F File Offset: 0x0003768F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.x, this.w, this.y);
			}
		}

		// Token: 0x17000542 RID: 1346
		// (get) Token: 0x060013FF RID: 5119 RVA: 0x000394AE File Offset: 0x000376AE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.x, this.w, this.z);
			}
		}

		// Token: 0x17000543 RID: 1347
		// (get) Token: 0x06001400 RID: 5120 RVA: 0x000394CD File Offset: 0x000376CD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.x, this.w, this.w);
			}
		}

		// Token: 0x17000544 RID: 1348
		// (get) Token: 0x06001401 RID: 5121 RVA: 0x000394EC File Offset: 0x000376EC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.y, this.x, this.x);
			}
		}

		// Token: 0x17000545 RID: 1349
		// (get) Token: 0x06001402 RID: 5122 RVA: 0x0003950B File Offset: 0x0003770B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.y, this.x, this.y);
			}
		}

		// Token: 0x17000546 RID: 1350
		// (get) Token: 0x06001403 RID: 5123 RVA: 0x0003952A File Offset: 0x0003772A
		// (set) Token: 0x06001404 RID: 5124 RVA: 0x00039549 File Offset: 0x00037749
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.y, this.x, this.z);
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

		// Token: 0x17000547 RID: 1351
		// (get) Token: 0x06001405 RID: 5125 RVA: 0x0003957B File Offset: 0x0003777B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.y, this.x, this.w);
			}
		}

		// Token: 0x17000548 RID: 1352
		// (get) Token: 0x06001406 RID: 5126 RVA: 0x0003959A File Offset: 0x0003779A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.y, this.y, this.x);
			}
		}

		// Token: 0x17000549 RID: 1353
		// (get) Token: 0x06001407 RID: 5127 RVA: 0x000395B9 File Offset: 0x000377B9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.y, this.y, this.y);
			}
		}

		// Token: 0x1700054A RID: 1354
		// (get) Token: 0x06001408 RID: 5128 RVA: 0x000395D8 File Offset: 0x000377D8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.y, this.y, this.z);
			}
		}

		// Token: 0x1700054B RID: 1355
		// (get) Token: 0x06001409 RID: 5129 RVA: 0x000395F7 File Offset: 0x000377F7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.y, this.y, this.w);
			}
		}

		// Token: 0x1700054C RID: 1356
		// (get) Token: 0x0600140A RID: 5130 RVA: 0x00039616 File Offset: 0x00037816
		// (set) Token: 0x0600140B RID: 5131 RVA: 0x00039635 File Offset: 0x00037835
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.y, this.z, this.x);
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

		// Token: 0x1700054D RID: 1357
		// (get) Token: 0x0600140C RID: 5132 RVA: 0x00039667 File Offset: 0x00037867
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.y, this.z, this.y);
			}
		}

		// Token: 0x1700054E RID: 1358
		// (get) Token: 0x0600140D RID: 5133 RVA: 0x00039686 File Offset: 0x00037886
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.y, this.z, this.z);
			}
		}

		// Token: 0x1700054F RID: 1359
		// (get) Token: 0x0600140E RID: 5134 RVA: 0x000396A5 File Offset: 0x000378A5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.y, this.z, this.w);
			}
		}

		// Token: 0x17000550 RID: 1360
		// (get) Token: 0x0600140F RID: 5135 RVA: 0x000396C4 File Offset: 0x000378C4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.y, this.w, this.x);
			}
		}

		// Token: 0x17000551 RID: 1361
		// (get) Token: 0x06001410 RID: 5136 RVA: 0x000396E3 File Offset: 0x000378E3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.y, this.w, this.y);
			}
		}

		// Token: 0x17000552 RID: 1362
		// (get) Token: 0x06001411 RID: 5137 RVA: 0x00039702 File Offset: 0x00037902
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.y, this.w, this.z);
			}
		}

		// Token: 0x17000553 RID: 1363
		// (get) Token: 0x06001412 RID: 5138 RVA: 0x00039721 File Offset: 0x00037921
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.y, this.w, this.w);
			}
		}

		// Token: 0x17000554 RID: 1364
		// (get) Token: 0x06001413 RID: 5139 RVA: 0x00039740 File Offset: 0x00037940
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.z, this.x, this.x);
			}
		}

		// Token: 0x17000555 RID: 1365
		// (get) Token: 0x06001414 RID: 5140 RVA: 0x0003975F File Offset: 0x0003795F
		// (set) Token: 0x06001415 RID: 5141 RVA: 0x0003977E File Offset: 0x0003797E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.z, this.x, this.y);
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

		// Token: 0x17000556 RID: 1366
		// (get) Token: 0x06001416 RID: 5142 RVA: 0x000397B0 File Offset: 0x000379B0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.z, this.x, this.z);
			}
		}

		// Token: 0x17000557 RID: 1367
		// (get) Token: 0x06001417 RID: 5143 RVA: 0x000397CF File Offset: 0x000379CF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.z, this.x, this.w);
			}
		}

		// Token: 0x17000558 RID: 1368
		// (get) Token: 0x06001418 RID: 5144 RVA: 0x000397EE File Offset: 0x000379EE
		// (set) Token: 0x06001419 RID: 5145 RVA: 0x0003980D File Offset: 0x00037A0D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.z, this.y, this.x);
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

		// Token: 0x17000559 RID: 1369
		// (get) Token: 0x0600141A RID: 5146 RVA: 0x0003983F File Offset: 0x00037A3F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.z, this.y, this.y);
			}
		}

		// Token: 0x1700055A RID: 1370
		// (get) Token: 0x0600141B RID: 5147 RVA: 0x0003985E File Offset: 0x00037A5E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.z, this.y, this.z);
			}
		}

		// Token: 0x1700055B RID: 1371
		// (get) Token: 0x0600141C RID: 5148 RVA: 0x0003987D File Offset: 0x00037A7D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.z, this.y, this.w);
			}
		}

		// Token: 0x1700055C RID: 1372
		// (get) Token: 0x0600141D RID: 5149 RVA: 0x0003989C File Offset: 0x00037A9C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.z, this.z, this.x);
			}
		}

		// Token: 0x1700055D RID: 1373
		// (get) Token: 0x0600141E RID: 5150 RVA: 0x000398BB File Offset: 0x00037ABB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.z, this.z, this.y);
			}
		}

		// Token: 0x1700055E RID: 1374
		// (get) Token: 0x0600141F RID: 5151 RVA: 0x000398DA File Offset: 0x00037ADA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.z, this.z, this.z);
			}
		}

		// Token: 0x1700055F RID: 1375
		// (get) Token: 0x06001420 RID: 5152 RVA: 0x000398F9 File Offset: 0x00037AF9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.z, this.z, this.w);
			}
		}

		// Token: 0x17000560 RID: 1376
		// (get) Token: 0x06001421 RID: 5153 RVA: 0x00039918 File Offset: 0x00037B18
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.z, this.w, this.x);
			}
		}

		// Token: 0x17000561 RID: 1377
		// (get) Token: 0x06001422 RID: 5154 RVA: 0x00039937 File Offset: 0x00037B37
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.z, this.w, this.y);
			}
		}

		// Token: 0x17000562 RID: 1378
		// (get) Token: 0x06001423 RID: 5155 RVA: 0x00039956 File Offset: 0x00037B56
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.z, this.w, this.z);
			}
		}

		// Token: 0x17000563 RID: 1379
		// (get) Token: 0x06001424 RID: 5156 RVA: 0x00039975 File Offset: 0x00037B75
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.z, this.w, this.w);
			}
		}

		// Token: 0x17000564 RID: 1380
		// (get) Token: 0x06001425 RID: 5157 RVA: 0x00039994 File Offset: 0x00037B94
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.w, this.x, this.x);
			}
		}

		// Token: 0x17000565 RID: 1381
		// (get) Token: 0x06001426 RID: 5158 RVA: 0x000399B3 File Offset: 0x00037BB3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.w, this.x, this.y);
			}
		}

		// Token: 0x17000566 RID: 1382
		// (get) Token: 0x06001427 RID: 5159 RVA: 0x000399D2 File Offset: 0x00037BD2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.w, this.x, this.z);
			}
		}

		// Token: 0x17000567 RID: 1383
		// (get) Token: 0x06001428 RID: 5160 RVA: 0x000399F1 File Offset: 0x00037BF1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.w, this.x, this.w);
			}
		}

		// Token: 0x17000568 RID: 1384
		// (get) Token: 0x06001429 RID: 5161 RVA: 0x00039A10 File Offset: 0x00037C10
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.w, this.y, this.x);
			}
		}

		// Token: 0x17000569 RID: 1385
		// (get) Token: 0x0600142A RID: 5162 RVA: 0x00039A2F File Offset: 0x00037C2F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.w, this.y, this.y);
			}
		}

		// Token: 0x1700056A RID: 1386
		// (get) Token: 0x0600142B RID: 5163 RVA: 0x00039A4E File Offset: 0x00037C4E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.w, this.y, this.z);
			}
		}

		// Token: 0x1700056B RID: 1387
		// (get) Token: 0x0600142C RID: 5164 RVA: 0x00039A6D File Offset: 0x00037C6D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.w, this.y, this.w);
			}
		}

		// Token: 0x1700056C RID: 1388
		// (get) Token: 0x0600142D RID: 5165 RVA: 0x00039A8C File Offset: 0x00037C8C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.w, this.z, this.x);
			}
		}

		// Token: 0x1700056D RID: 1389
		// (get) Token: 0x0600142E RID: 5166 RVA: 0x00039AAB File Offset: 0x00037CAB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.w, this.z, this.y);
			}
		}

		// Token: 0x1700056E RID: 1390
		// (get) Token: 0x0600142F RID: 5167 RVA: 0x00039ACA File Offset: 0x00037CCA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.w, this.z, this.z);
			}
		}

		// Token: 0x1700056F RID: 1391
		// (get) Token: 0x06001430 RID: 5168 RVA: 0x00039AE9 File Offset: 0x00037CE9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.w, this.z, this.w);
			}
		}

		// Token: 0x17000570 RID: 1392
		// (get) Token: 0x06001431 RID: 5169 RVA: 0x00039B08 File Offset: 0x00037D08
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.w, this.w, this.x);
			}
		}

		// Token: 0x17000571 RID: 1393
		// (get) Token: 0x06001432 RID: 5170 RVA: 0x00039B27 File Offset: 0x00037D27
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.w, this.w, this.y);
			}
		}

		// Token: 0x17000572 RID: 1394
		// (get) Token: 0x06001433 RID: 5171 RVA: 0x00039B46 File Offset: 0x00037D46
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.w, this.w, this.z);
			}
		}

		// Token: 0x17000573 RID: 1395
		// (get) Token: 0x06001434 RID: 5172 RVA: 0x00039B65 File Offset: 0x00037D65
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 wwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.w, this.w, this.w, this.w);
			}
		}

		// Token: 0x17000574 RID: 1396
		// (get) Token: 0x06001435 RID: 5173 RVA: 0x00039B84 File Offset: 0x00037D84
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.x, this.x);
			}
		}

		// Token: 0x17000575 RID: 1397
		// (get) Token: 0x06001436 RID: 5174 RVA: 0x00039B9D File Offset: 0x00037D9D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.x, this.y);
			}
		}

		// Token: 0x17000576 RID: 1398
		// (get) Token: 0x06001437 RID: 5175 RVA: 0x00039BB6 File Offset: 0x00037DB6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.x, this.z);
			}
		}

		// Token: 0x17000577 RID: 1399
		// (get) Token: 0x06001438 RID: 5176 RVA: 0x00039BCF File Offset: 0x00037DCF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.x, this.w);
			}
		}

		// Token: 0x17000578 RID: 1400
		// (get) Token: 0x06001439 RID: 5177 RVA: 0x00039BE8 File Offset: 0x00037DE8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.y, this.x);
			}
		}

		// Token: 0x17000579 RID: 1401
		// (get) Token: 0x0600143A RID: 5178 RVA: 0x00039C01 File Offset: 0x00037E01
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.y, this.y);
			}
		}

		// Token: 0x1700057A RID: 1402
		// (get) Token: 0x0600143B RID: 5179 RVA: 0x00039C1A File Offset: 0x00037E1A
		// (set) Token: 0x0600143C RID: 5180 RVA: 0x00039C33 File Offset: 0x00037E33
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x1700057B RID: 1403
		// (get) Token: 0x0600143D RID: 5181 RVA: 0x00039C59 File Offset: 0x00037E59
		// (set) Token: 0x0600143E RID: 5182 RVA: 0x00039C72 File Offset: 0x00037E72
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.y, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x1700057C RID: 1404
		// (get) Token: 0x0600143F RID: 5183 RVA: 0x00039C98 File Offset: 0x00037E98
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.z, this.x);
			}
		}

		// Token: 0x1700057D RID: 1405
		// (get) Token: 0x06001440 RID: 5184 RVA: 0x00039CB1 File Offset: 0x00037EB1
		// (set) Token: 0x06001441 RID: 5185 RVA: 0x00039CCA File Offset: 0x00037ECA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x1700057E RID: 1406
		// (get) Token: 0x06001442 RID: 5186 RVA: 0x00039CF0 File Offset: 0x00037EF0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.z, this.z);
			}
		}

		// Token: 0x1700057F RID: 1407
		// (get) Token: 0x06001443 RID: 5187 RVA: 0x00039D09 File Offset: 0x00037F09
		// (set) Token: 0x06001444 RID: 5188 RVA: 0x00039D22 File Offset: 0x00037F22
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.z, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x17000580 RID: 1408
		// (get) Token: 0x06001445 RID: 5189 RVA: 0x00039D48 File Offset: 0x00037F48
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.w, this.x);
			}
		}

		// Token: 0x17000581 RID: 1409
		// (get) Token: 0x06001446 RID: 5190 RVA: 0x00039D61 File Offset: 0x00037F61
		// (set) Token: 0x06001447 RID: 5191 RVA: 0x00039D7A File Offset: 0x00037F7A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.w, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.w = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x17000582 RID: 1410
		// (get) Token: 0x06001448 RID: 5192 RVA: 0x00039DA0 File Offset: 0x00037FA0
		// (set) Token: 0x06001449 RID: 5193 RVA: 0x00039DB9 File Offset: 0x00037FB9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.w, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.w = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x17000583 RID: 1411
		// (get) Token: 0x0600144A RID: 5194 RVA: 0x00039DDF File Offset: 0x00037FDF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.w, this.w);
			}
		}

		// Token: 0x17000584 RID: 1412
		// (get) Token: 0x0600144B RID: 5195 RVA: 0x00039DF8 File Offset: 0x00037FF8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.x, this.x);
			}
		}

		// Token: 0x17000585 RID: 1413
		// (get) Token: 0x0600144C RID: 5196 RVA: 0x00039E11 File Offset: 0x00038011
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.x, this.y);
			}
		}

		// Token: 0x17000586 RID: 1414
		// (get) Token: 0x0600144D RID: 5197 RVA: 0x00039E2A File Offset: 0x0003802A
		// (set) Token: 0x0600144E RID: 5198 RVA: 0x00039E43 File Offset: 0x00038043
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x17000587 RID: 1415
		// (get) Token: 0x0600144F RID: 5199 RVA: 0x00039E69 File Offset: 0x00038069
		// (set) Token: 0x06001450 RID: 5200 RVA: 0x00039E82 File Offset: 0x00038082
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.x, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x17000588 RID: 1416
		// (get) Token: 0x06001451 RID: 5201 RVA: 0x00039EA8 File Offset: 0x000380A8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.y, this.x);
			}
		}

		// Token: 0x17000589 RID: 1417
		// (get) Token: 0x06001452 RID: 5202 RVA: 0x00039EC1 File Offset: 0x000380C1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.y, this.y);
			}
		}

		// Token: 0x1700058A RID: 1418
		// (get) Token: 0x06001453 RID: 5203 RVA: 0x00039EDA File Offset: 0x000380DA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.y, this.z);
			}
		}

		// Token: 0x1700058B RID: 1419
		// (get) Token: 0x06001454 RID: 5204 RVA: 0x00039EF3 File Offset: 0x000380F3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.y, this.w);
			}
		}

		// Token: 0x1700058C RID: 1420
		// (get) Token: 0x06001455 RID: 5205 RVA: 0x00039F0C File Offset: 0x0003810C
		// (set) Token: 0x06001456 RID: 5206 RVA: 0x00039F25 File Offset: 0x00038125
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x1700058D RID: 1421
		// (get) Token: 0x06001457 RID: 5207 RVA: 0x00039F4B File Offset: 0x0003814B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.z, this.y);
			}
		}

		// Token: 0x1700058E RID: 1422
		// (get) Token: 0x06001458 RID: 5208 RVA: 0x00039F64 File Offset: 0x00038164
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.z, this.z);
			}
		}

		// Token: 0x1700058F RID: 1423
		// (get) Token: 0x06001459 RID: 5209 RVA: 0x00039F7D File Offset: 0x0003817D
		// (set) Token: 0x0600145A RID: 5210 RVA: 0x00039F96 File Offset: 0x00038196
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.z, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x17000590 RID: 1424
		// (get) Token: 0x0600145B RID: 5211 RVA: 0x00039FBC File Offset: 0x000381BC
		// (set) Token: 0x0600145C RID: 5212 RVA: 0x00039FD5 File Offset: 0x000381D5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 ywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.w, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.w = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x17000591 RID: 1425
		// (get) Token: 0x0600145D RID: 5213 RVA: 0x00039FFB File Offset: 0x000381FB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 ywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.w, this.y);
			}
		}

		// Token: 0x17000592 RID: 1426
		// (get) Token: 0x0600145E RID: 5214 RVA: 0x0003A014 File Offset: 0x00038214
		// (set) Token: 0x0600145F RID: 5215 RVA: 0x0003A02D File Offset: 0x0003822D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 ywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.w, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.w = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x17000593 RID: 1427
		// (get) Token: 0x06001460 RID: 5216 RVA: 0x0003A053 File Offset: 0x00038253
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.w, this.w);
			}
		}

		// Token: 0x17000594 RID: 1428
		// (get) Token: 0x06001461 RID: 5217 RVA: 0x0003A06C File Offset: 0x0003826C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.x, this.x);
			}
		}

		// Token: 0x17000595 RID: 1429
		// (get) Token: 0x06001462 RID: 5218 RVA: 0x0003A085 File Offset: 0x00038285
		// (set) Token: 0x06001463 RID: 5219 RVA: 0x0003A09E File Offset: 0x0003829E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x17000596 RID: 1430
		// (get) Token: 0x06001464 RID: 5220 RVA: 0x0003A0C4 File Offset: 0x000382C4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.x, this.z);
			}
		}

		// Token: 0x17000597 RID: 1431
		// (get) Token: 0x06001465 RID: 5221 RVA: 0x0003A0DD File Offset: 0x000382DD
		// (set) Token: 0x06001466 RID: 5222 RVA: 0x0003A0F6 File Offset: 0x000382F6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.x, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x17000598 RID: 1432
		// (get) Token: 0x06001467 RID: 5223 RVA: 0x0003A11C File Offset: 0x0003831C
		// (set) Token: 0x06001468 RID: 5224 RVA: 0x0003A135 File Offset: 0x00038335
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x17000599 RID: 1433
		// (get) Token: 0x06001469 RID: 5225 RVA: 0x0003A15B File Offset: 0x0003835B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.y, this.y);
			}
		}

		// Token: 0x1700059A RID: 1434
		// (get) Token: 0x0600146A RID: 5226 RVA: 0x0003A174 File Offset: 0x00038374
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.y, this.z);
			}
		}

		// Token: 0x1700059B RID: 1435
		// (get) Token: 0x0600146B RID: 5227 RVA: 0x0003A18D File Offset: 0x0003838D
		// (set) Token: 0x0600146C RID: 5228 RVA: 0x0003A1A6 File Offset: 0x000383A6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.y, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x1700059C RID: 1436
		// (get) Token: 0x0600146D RID: 5229 RVA: 0x0003A1CC File Offset: 0x000383CC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.z, this.x);
			}
		}

		// Token: 0x1700059D RID: 1437
		// (get) Token: 0x0600146E RID: 5230 RVA: 0x0003A1E5 File Offset: 0x000383E5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.z, this.y);
			}
		}

		// Token: 0x1700059E RID: 1438
		// (get) Token: 0x0600146F RID: 5231 RVA: 0x0003A1FE File Offset: 0x000383FE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.z, this.z);
			}
		}

		// Token: 0x1700059F RID: 1439
		// (get) Token: 0x06001470 RID: 5232 RVA: 0x0003A217 File Offset: 0x00038417
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.z, this.w);
			}
		}

		// Token: 0x170005A0 RID: 1440
		// (get) Token: 0x06001471 RID: 5233 RVA: 0x0003A230 File Offset: 0x00038430
		// (set) Token: 0x06001472 RID: 5234 RVA: 0x0003A249 File Offset: 0x00038449
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.w, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.w = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x170005A1 RID: 1441
		// (get) Token: 0x06001473 RID: 5235 RVA: 0x0003A26F File Offset: 0x0003846F
		// (set) Token: 0x06001474 RID: 5236 RVA: 0x0003A288 File Offset: 0x00038488
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.w, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.w = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x170005A2 RID: 1442
		// (get) Token: 0x06001475 RID: 5237 RVA: 0x0003A2AE File Offset: 0x000384AE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.w, this.z);
			}
		}

		// Token: 0x170005A3 RID: 1443
		// (get) Token: 0x06001476 RID: 5238 RVA: 0x0003A2C7 File Offset: 0x000384C7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.w, this.w);
			}
		}

		// Token: 0x170005A4 RID: 1444
		// (get) Token: 0x06001477 RID: 5239 RVA: 0x0003A2E0 File Offset: 0x000384E0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 wxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.w, this.x, this.x);
			}
		}

		// Token: 0x170005A5 RID: 1445
		// (get) Token: 0x06001478 RID: 5240 RVA: 0x0003A2F9 File Offset: 0x000384F9
		// (set) Token: 0x06001479 RID: 5241 RVA: 0x0003A312 File Offset: 0x00038512
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 wxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.w, this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.x = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x170005A6 RID: 1446
		// (get) Token: 0x0600147A RID: 5242 RVA: 0x0003A338 File Offset: 0x00038538
		// (set) Token: 0x0600147B RID: 5243 RVA: 0x0003A351 File Offset: 0x00038551
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 wxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.w, this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.x = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x170005A7 RID: 1447
		// (get) Token: 0x0600147C RID: 5244 RVA: 0x0003A377 File Offset: 0x00038577
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 wxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.w, this.x, this.w);
			}
		}

		// Token: 0x170005A8 RID: 1448
		// (get) Token: 0x0600147D RID: 5245 RVA: 0x0003A390 File Offset: 0x00038590
		// (set) Token: 0x0600147E RID: 5246 RVA: 0x0003A3A9 File Offset: 0x000385A9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 wyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.w, this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.y = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x170005A9 RID: 1449
		// (get) Token: 0x0600147F RID: 5247 RVA: 0x0003A3CF File Offset: 0x000385CF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 wyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.w, this.y, this.y);
			}
		}

		// Token: 0x170005AA RID: 1450
		// (get) Token: 0x06001480 RID: 5248 RVA: 0x0003A3E8 File Offset: 0x000385E8
		// (set) Token: 0x06001481 RID: 5249 RVA: 0x0003A401 File Offset: 0x00038601
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 wyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.w, this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.y = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x170005AB RID: 1451
		// (get) Token: 0x06001482 RID: 5250 RVA: 0x0003A427 File Offset: 0x00038627
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 wyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.w, this.y, this.w);
			}
		}

		// Token: 0x170005AC RID: 1452
		// (get) Token: 0x06001483 RID: 5251 RVA: 0x0003A440 File Offset: 0x00038640
		// (set) Token: 0x06001484 RID: 5252 RVA: 0x0003A459 File Offset: 0x00038659
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 wzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.w, this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.z = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x170005AD RID: 1453
		// (get) Token: 0x06001485 RID: 5253 RVA: 0x0003A47F File Offset: 0x0003867F
		// (set) Token: 0x06001486 RID: 5254 RVA: 0x0003A498 File Offset: 0x00038698
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 wzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.w, this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.z = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x170005AE RID: 1454
		// (get) Token: 0x06001487 RID: 5255 RVA: 0x0003A4BE File Offset: 0x000386BE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 wzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.w, this.z, this.z);
			}
		}

		// Token: 0x170005AF RID: 1455
		// (get) Token: 0x06001488 RID: 5256 RVA: 0x0003A4D7 File Offset: 0x000386D7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 wzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.w, this.z, this.w);
			}
		}

		// Token: 0x170005B0 RID: 1456
		// (get) Token: 0x06001489 RID: 5257 RVA: 0x0003A4F0 File Offset: 0x000386F0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 wwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.w, this.w, this.x);
			}
		}

		// Token: 0x170005B1 RID: 1457
		// (get) Token: 0x0600148A RID: 5258 RVA: 0x0003A509 File Offset: 0x00038709
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 wwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.w, this.w, this.y);
			}
		}

		// Token: 0x170005B2 RID: 1458
		// (get) Token: 0x0600148B RID: 5259 RVA: 0x0003A522 File Offset: 0x00038722
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 wwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.w, this.w, this.z);
			}
		}

		// Token: 0x170005B3 RID: 1459
		// (get) Token: 0x0600148C RID: 5260 RVA: 0x0003A53B File Offset: 0x0003873B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 www
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.w, this.w, this.w);
			}
		}

		// Token: 0x170005B4 RID: 1460
		// (get) Token: 0x0600148D RID: 5261 RVA: 0x0003A554 File Offset: 0x00038754
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.x, this.x);
			}
		}

		// Token: 0x170005B5 RID: 1461
		// (get) Token: 0x0600148E RID: 5262 RVA: 0x0003A567 File Offset: 0x00038767
		// (set) Token: 0x0600148F RID: 5263 RVA: 0x0003A57A File Offset: 0x0003877A
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

		// Token: 0x170005B6 RID: 1462
		// (get) Token: 0x06001490 RID: 5264 RVA: 0x0003A594 File Offset: 0x00038794
		// (set) Token: 0x06001491 RID: 5265 RVA: 0x0003A5A7 File Offset: 0x000387A7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 xz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
			}
		}

		// Token: 0x170005B7 RID: 1463
		// (get) Token: 0x06001492 RID: 5266 RVA: 0x0003A5C1 File Offset: 0x000387C1
		// (set) Token: 0x06001493 RID: 5267 RVA: 0x0003A5D4 File Offset: 0x000387D4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 xw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.x, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.w = value.y;
			}
		}

		// Token: 0x170005B8 RID: 1464
		// (get) Token: 0x06001494 RID: 5268 RVA: 0x0003A5EE File Offset: 0x000387EE
		// (set) Token: 0x06001495 RID: 5269 RVA: 0x0003A601 File Offset: 0x00038801
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

		// Token: 0x170005B9 RID: 1465
		// (get) Token: 0x06001496 RID: 5270 RVA: 0x0003A61B File Offset: 0x0003881B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 yy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.y, this.y);
			}
		}

		// Token: 0x170005BA RID: 1466
		// (get) Token: 0x06001497 RID: 5271 RVA: 0x0003A62E File Offset: 0x0003882E
		// (set) Token: 0x06001498 RID: 5272 RVA: 0x0003A641 File Offset: 0x00038841
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 yz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
			}
		}

		// Token: 0x170005BB RID: 1467
		// (get) Token: 0x06001499 RID: 5273 RVA: 0x0003A65B File Offset: 0x0003885B
		// (set) Token: 0x0600149A RID: 5274 RVA: 0x0003A66E File Offset: 0x0003886E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 yw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.y, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.w = value.y;
			}
		}

		// Token: 0x170005BC RID: 1468
		// (get) Token: 0x0600149B RID: 5275 RVA: 0x0003A688 File Offset: 0x00038888
		// (set) Token: 0x0600149C RID: 5276 RVA: 0x0003A69B File Offset: 0x0003889B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 zx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x170005BD RID: 1469
		// (get) Token: 0x0600149D RID: 5277 RVA: 0x0003A6B5 File Offset: 0x000388B5
		// (set) Token: 0x0600149E RID: 5278 RVA: 0x0003A6C8 File Offset: 0x000388C8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 zy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x170005BE RID: 1470
		// (get) Token: 0x0600149F RID: 5279 RVA: 0x0003A6E2 File Offset: 0x000388E2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 zz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.z, this.z);
			}
		}

		// Token: 0x170005BF RID: 1471
		// (get) Token: 0x060014A0 RID: 5280 RVA: 0x0003A6F5 File Offset: 0x000388F5
		// (set) Token: 0x060014A1 RID: 5281 RVA: 0x0003A708 File Offset: 0x00038908
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 zw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.z, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.w = value.y;
			}
		}

		// Token: 0x170005C0 RID: 1472
		// (get) Token: 0x060014A2 RID: 5282 RVA: 0x0003A722 File Offset: 0x00038922
		// (set) Token: 0x060014A3 RID: 5283 RVA: 0x0003A735 File Offset: 0x00038935
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 wx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.w, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x170005C1 RID: 1473
		// (get) Token: 0x060014A4 RID: 5284 RVA: 0x0003A74F File Offset: 0x0003894F
		// (set) Token: 0x060014A5 RID: 5285 RVA: 0x0003A762 File Offset: 0x00038962
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 wy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.w, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x170005C2 RID: 1474
		// (get) Token: 0x060014A6 RID: 5286 RVA: 0x0003A77C File Offset: 0x0003897C
		// (set) Token: 0x060014A7 RID: 5287 RVA: 0x0003A78F File Offset: 0x0003898F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 wz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.w, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.z = value.y;
			}
		}

		// Token: 0x170005C3 RID: 1475
		// (get) Token: 0x060014A8 RID: 5288 RVA: 0x0003A7A9 File Offset: 0x000389A9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 ww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.w, this.w);
			}
		}

		// Token: 0x170005C4 RID: 1476
		public unsafe float this[int index]
		{
			get
			{
				fixed (float4* ptr = &this)
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

		// Token: 0x060014AB RID: 5291 RVA: 0x0003A7F4 File Offset: 0x000389F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(float4 rhs)
		{
			return this.x == rhs.x && this.y == rhs.y && this.z == rhs.z && this.w == rhs.w;
		}

		// Token: 0x060014AC RID: 5292 RVA: 0x0003A830 File Offset: 0x00038A30
		public override bool Equals(object o)
		{
			if (o is float4)
			{
				float4 rhs = (float4)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x060014AD RID: 5293 RVA: 0x0003A855 File Offset: 0x00038A55
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x060014AE RID: 5294 RVA: 0x0003A864 File Offset: 0x00038A64
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("float4({0}f, {1}f, {2}f, {3}f)", new object[]
			{
				this.x,
				this.y,
				this.z,
				this.w
			});
		}

		// Token: 0x060014AF RID: 5295 RVA: 0x0003A8BC File Offset: 0x00038ABC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("float4({0}f, {1}f, {2}f, {3}f)", new object[]
			{
				this.x.ToString(format, formatProvider),
				this.y.ToString(format, formatProvider),
				this.z.ToString(format, formatProvider),
				this.w.ToString(format, formatProvider)
			});
		}

		// Token: 0x060014B0 RID: 5296 RVA: 0x0003A919 File Offset: 0x00038B19
		public static implicit operator float4(Vector4 v)
		{
			return new float4(v.x, v.y, v.z, v.w);
		}

		// Token: 0x060014B1 RID: 5297 RVA: 0x0003A938 File Offset: 0x00038B38
		public static implicit operator Vector4(float4 v)
		{
			return new Vector4(v.x, v.y, v.z, v.w);
		}

		// Token: 0x0400008F RID: 143
		public float x;

		// Token: 0x04000090 RID: 144
		public float y;

		// Token: 0x04000091 RID: 145
		public float z;

		// Token: 0x04000092 RID: 146
		public float w;

		// Token: 0x04000093 RID: 147
		public static readonly float4 zero;

		// Token: 0x0200005C RID: 92
		internal sealed class DebuggerProxy
		{
			// Token: 0x06002471 RID: 9329 RVA: 0x0006764C File Offset: 0x0006584C
			public DebuggerProxy(float4 v)
			{
				this.x = v.x;
				this.y = v.y;
				this.z = v.z;
				this.w = v.w;
			}

			// Token: 0x04000151 RID: 337
			public float x;

			// Token: 0x04000152 RID: 338
			public float y;

			// Token: 0x04000153 RID: 339
			public float z;

			// Token: 0x04000154 RID: 340
			public float w;
		}
	}
}
