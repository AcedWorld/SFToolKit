using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000019 RID: 25
	[DebuggerTypeProxy(typeof(double4.DebuggerProxy))]
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct double4 : IEquatable<double4>, IFormattable
	{
		// Token: 0x06000D7F RID: 3455 RVA: 0x00028EA5 File Offset: 0x000270A5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(double x, double y, double z, double w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		// Token: 0x06000D80 RID: 3456 RVA: 0x00028EC4 File Offset: 0x000270C4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(double x, double y, double2 zw)
		{
			this.x = x;
			this.y = y;
			this.z = zw.x;
			this.w = zw.y;
		}

		// Token: 0x06000D81 RID: 3457 RVA: 0x00028EEC File Offset: 0x000270EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(double x, double2 yz, double w)
		{
			this.x = x;
			this.y = yz.x;
			this.z = yz.y;
			this.w = w;
		}

		// Token: 0x06000D82 RID: 3458 RVA: 0x00028F14 File Offset: 0x00027114
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(double x, double3 yzw)
		{
			this.x = x;
			this.y = yzw.x;
			this.z = yzw.y;
			this.w = yzw.z;
		}

		// Token: 0x06000D83 RID: 3459 RVA: 0x00028F41 File Offset: 0x00027141
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(double2 xy, double z, double w)
		{
			this.x = xy.x;
			this.y = xy.y;
			this.z = z;
			this.w = w;
		}

		// Token: 0x06000D84 RID: 3460 RVA: 0x00028F69 File Offset: 0x00027169
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(double2 xy, double2 zw)
		{
			this.x = xy.x;
			this.y = xy.y;
			this.z = zw.x;
			this.w = zw.y;
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x00028F9B File Offset: 0x0002719B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(double3 xyz, double w)
		{
			this.x = xyz.x;
			this.y = xyz.y;
			this.z = xyz.z;
			this.w = w;
		}

		// Token: 0x06000D86 RID: 3462 RVA: 0x00028FC8 File Offset: 0x000271C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(double4 xyzw)
		{
			this.x = xyzw.x;
			this.y = xyzw.y;
			this.z = xyzw.z;
			this.w = xyzw.w;
		}

		// Token: 0x06000D87 RID: 3463 RVA: 0x00028FFA File Offset: 0x000271FA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(double v)
		{
			this.x = v;
			this.y = v;
			this.z = v;
			this.w = v;
		}

		// Token: 0x06000D88 RID: 3464 RVA: 0x00029018 File Offset: 0x00027218
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(bool v)
		{
			this.x = (v ? 1.0 : 0.0);
			this.y = (v ? 1.0 : 0.0);
			this.z = (v ? 1.0 : 0.0);
			this.w = (v ? 1.0 : 0.0);
		}

		// Token: 0x06000D89 RID: 3465 RVA: 0x0002909C File Offset: 0x0002729C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(bool4 v)
		{
			this.x = (v.x ? 1.0 : 0.0);
			this.y = (v.y ? 1.0 : 0.0);
			this.z = (v.z ? 1.0 : 0.0);
			this.w = (v.w ? 1.0 : 0.0);
		}

		// Token: 0x06000D8A RID: 3466 RVA: 0x00029131 File Offset: 0x00027331
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(int v)
		{
			this.x = (double)v;
			this.y = (double)v;
			this.z = (double)v;
			this.w = (double)v;
		}

		// Token: 0x06000D8B RID: 3467 RVA: 0x00029153 File Offset: 0x00027353
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(int4 v)
		{
			this.x = (double)v.x;
			this.y = (double)v.y;
			this.z = (double)v.z;
			this.w = (double)v.w;
		}

		// Token: 0x06000D8C RID: 3468 RVA: 0x00029189 File Offset: 0x00027389
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(uint v)
		{
			this.x = v;
			this.y = v;
			this.z = v;
			this.w = v;
		}

		// Token: 0x06000D8D RID: 3469 RVA: 0x000291AF File Offset: 0x000273AF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(uint4 v)
		{
			this.x = v.x;
			this.y = v.y;
			this.z = v.z;
			this.w = v.w;
		}

		// Token: 0x06000D8E RID: 3470 RVA: 0x000291E9 File Offset: 0x000273E9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(half v)
		{
			this.x = v;
			this.y = v;
			this.z = v;
			this.w = v;
		}

		// Token: 0x06000D8F RID: 3471 RVA: 0x0002921C File Offset: 0x0002741C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(half4 v)
		{
			this.x = v.x;
			this.y = v.y;
			this.z = v.z;
			this.w = v.w;
		}

		// Token: 0x06000D90 RID: 3472 RVA: 0x0002926D File Offset: 0x0002746D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(float v)
		{
			this.x = (double)v;
			this.y = (double)v;
			this.z = (double)v;
			this.w = (double)v;
		}

		// Token: 0x06000D91 RID: 3473 RVA: 0x0002928F File Offset: 0x0002748F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4(float4 v)
		{
			this.x = (double)v.x;
			this.y = (double)v.y;
			this.z = (double)v.z;
			this.w = (double)v.w;
		}

		// Token: 0x06000D92 RID: 3474 RVA: 0x000292C5 File Offset: 0x000274C5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4(double v)
		{
			return new double4(v);
		}

		// Token: 0x06000D93 RID: 3475 RVA: 0x000292CD File Offset: 0x000274CD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator double4(bool v)
		{
			return new double4(v);
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x000292D5 File Offset: 0x000274D5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator double4(bool4 v)
		{
			return new double4(v);
		}

		// Token: 0x06000D95 RID: 3477 RVA: 0x000292DD File Offset: 0x000274DD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4(int v)
		{
			return new double4(v);
		}

		// Token: 0x06000D96 RID: 3478 RVA: 0x000292E5 File Offset: 0x000274E5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4(int4 v)
		{
			return new double4(v);
		}

		// Token: 0x06000D97 RID: 3479 RVA: 0x000292ED File Offset: 0x000274ED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4(uint v)
		{
			return new double4(v);
		}

		// Token: 0x06000D98 RID: 3480 RVA: 0x000292F5 File Offset: 0x000274F5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4(uint4 v)
		{
			return new double4(v);
		}

		// Token: 0x06000D99 RID: 3481 RVA: 0x000292FD File Offset: 0x000274FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4(half v)
		{
			return new double4(v);
		}

		// Token: 0x06000D9A RID: 3482 RVA: 0x00029305 File Offset: 0x00027505
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4(half4 v)
		{
			return new double4(v);
		}

		// Token: 0x06000D9B RID: 3483 RVA: 0x0002930D File Offset: 0x0002750D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4(float v)
		{
			return new double4(v);
		}

		// Token: 0x06000D9C RID: 3484 RVA: 0x00029315 File Offset: 0x00027515
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4(float4 v)
		{
			return new double4(v);
		}

		// Token: 0x06000D9D RID: 3485 RVA: 0x0002931D File Offset: 0x0002751D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator *(double4 lhs, double4 rhs)
		{
			return new double4(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w);
		}

		// Token: 0x06000D9E RID: 3486 RVA: 0x00029358 File Offset: 0x00027558
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator *(double4 lhs, double rhs)
		{
			return new double4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
		}

		// Token: 0x06000D9F RID: 3487 RVA: 0x0002937F File Offset: 0x0002757F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator *(double lhs, double4 rhs)
		{
			return new double4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w);
		}

		// Token: 0x06000DA0 RID: 3488 RVA: 0x000293A6 File Offset: 0x000275A6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator +(double4 lhs, double4 rhs)
		{
			return new double4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
		}

		// Token: 0x06000DA1 RID: 3489 RVA: 0x000293E1 File Offset: 0x000275E1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator +(double4 lhs, double rhs)
		{
			return new double4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);
		}

		// Token: 0x06000DA2 RID: 3490 RVA: 0x00029408 File Offset: 0x00027608
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator +(double lhs, double4 rhs)
		{
			return new double4(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z, lhs + rhs.w);
		}

		// Token: 0x06000DA3 RID: 3491 RVA: 0x0002942F File Offset: 0x0002762F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator -(double4 lhs, double4 rhs)
		{
			return new double4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
		}

		// Token: 0x06000DA4 RID: 3492 RVA: 0x0002946A File Offset: 0x0002766A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator -(double4 lhs, double rhs)
		{
			return new double4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);
		}

		// Token: 0x06000DA5 RID: 3493 RVA: 0x00029491 File Offset: 0x00027691
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator -(double lhs, double4 rhs)
		{
			return new double4(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z, lhs - rhs.w);
		}

		// Token: 0x06000DA6 RID: 3494 RVA: 0x000294B8 File Offset: 0x000276B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator /(double4 lhs, double4 rhs)
		{
			return new double4(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z, lhs.w / rhs.w);
		}

		// Token: 0x06000DA7 RID: 3495 RVA: 0x000294F3 File Offset: 0x000276F3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator /(double4 lhs, double rhs)
		{
			return new double4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
		}

		// Token: 0x06000DA8 RID: 3496 RVA: 0x0002951A File Offset: 0x0002771A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator /(double lhs, double4 rhs)
		{
			return new double4(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z, lhs / rhs.w);
		}

		// Token: 0x06000DA9 RID: 3497 RVA: 0x00029541 File Offset: 0x00027741
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator %(double4 lhs, double4 rhs)
		{
			return new double4(lhs.x % rhs.x, lhs.y % rhs.y, lhs.z % rhs.z, lhs.w % rhs.w);
		}

		// Token: 0x06000DAA RID: 3498 RVA: 0x0002957C File Offset: 0x0002777C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator %(double4 lhs, double rhs)
		{
			return new double4(lhs.x % rhs, lhs.y % rhs, lhs.z % rhs, lhs.w % rhs);
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x000295A3 File Offset: 0x000277A3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator %(double lhs, double4 rhs)
		{
			return new double4(lhs % rhs.x, lhs % rhs.y, lhs % rhs.z, lhs % rhs.w);
		}

		// Token: 0x06000DAC RID: 3500 RVA: 0x000295CC File Offset: 0x000277CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator ++(double4 val)
		{
			double num = val.x + 1.0;
			val.x = num;
			double num2 = num;
			num = val.y + 1.0;
			val.y = num;
			double num3 = num;
			num = val.z + 1.0;
			val.z = num;
			double num4 = num;
			num = val.w + 1.0;
			val.w = num;
			return new double4(num2, num3, num4, num);
		}

		// Token: 0x06000DAD RID: 3501 RVA: 0x0002963C File Offset: 0x0002783C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator --(double4 val)
		{
			double num = val.x - 1.0;
			val.x = num;
			double num2 = num;
			num = val.y - 1.0;
			val.y = num;
			double num3 = num;
			num = val.z - 1.0;
			val.z = num;
			double num4 = num;
			num = val.w - 1.0;
			val.w = num;
			return new double4(num2, num3, num4, num);
		}

		// Token: 0x06000DAE RID: 3502 RVA: 0x000296AA File Offset: 0x000278AA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator <(double4 lhs, double4 rhs)
		{
			return new bool4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w);
		}

		// Token: 0x06000DAF RID: 3503 RVA: 0x000296E9 File Offset: 0x000278E9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator <(double4 lhs, double rhs)
		{
			return new bool4(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs, lhs.w < rhs);
		}

		// Token: 0x06000DB0 RID: 3504 RVA: 0x00029714 File Offset: 0x00027914
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator <(double lhs, double4 rhs)
		{
			return new bool4(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z, lhs < rhs.w);
		}

		// Token: 0x06000DB1 RID: 3505 RVA: 0x00029740 File Offset: 0x00027940
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator <=(double4 lhs, double4 rhs)
		{
			return new bool4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w);
		}

		// Token: 0x06000DB2 RID: 3506 RVA: 0x00029796 File Offset: 0x00027996
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator <=(double4 lhs, double rhs)
		{
			return new bool4(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs, lhs.w <= rhs);
		}

		// Token: 0x06000DB3 RID: 3507 RVA: 0x000297CD File Offset: 0x000279CD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator <=(double lhs, double4 rhs)
		{
			return new bool4(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z, lhs <= rhs.w);
		}

		// Token: 0x06000DB4 RID: 3508 RVA: 0x00029804 File Offset: 0x00027A04
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator >(double4 lhs, double4 rhs)
		{
			return new bool4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w);
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x00029843 File Offset: 0x00027A43
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator >(double4 lhs, double rhs)
		{
			return new bool4(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs, lhs.w > rhs);
		}

		// Token: 0x06000DB6 RID: 3510 RVA: 0x0002986E File Offset: 0x00027A6E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator >(double lhs, double4 rhs)
		{
			return new bool4(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z, lhs > rhs.w);
		}

		// Token: 0x06000DB7 RID: 3511 RVA: 0x0002989C File Offset: 0x00027A9C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator >=(double4 lhs, double4 rhs)
		{
			return new bool4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w);
		}

		// Token: 0x06000DB8 RID: 3512 RVA: 0x000298F2 File Offset: 0x00027AF2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator >=(double4 lhs, double rhs)
		{
			return new bool4(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs, lhs.w >= rhs);
		}

		// Token: 0x06000DB9 RID: 3513 RVA: 0x00029929 File Offset: 0x00027B29
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator >=(double lhs, double4 rhs)
		{
			return new bool4(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z, lhs >= rhs.w);
		}

		// Token: 0x06000DBA RID: 3514 RVA: 0x00029960 File Offset: 0x00027B60
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator -(double4 val)
		{
			return new double4(-val.x, -val.y, -val.z, -val.w);
		}

		// Token: 0x06000DBB RID: 3515 RVA: 0x00029983 File Offset: 0x00027B83
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 operator +(double4 val)
		{
			return new double4(val.x, val.y, val.z, val.w);
		}

		// Token: 0x06000DBC RID: 3516 RVA: 0x000299A2 File Offset: 0x00027BA2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator ==(double4 lhs, double4 rhs)
		{
			return new bool4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);
		}

		// Token: 0x06000DBD RID: 3517 RVA: 0x000299E1 File Offset: 0x00027BE1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator ==(double4 lhs, double rhs)
		{
			return new bool4(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs, lhs.w == rhs);
		}

		// Token: 0x06000DBE RID: 3518 RVA: 0x00029A0C File Offset: 0x00027C0C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator ==(double lhs, double4 rhs)
		{
			return new bool4(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z, lhs == rhs.w);
		}

		// Token: 0x06000DBF RID: 3519 RVA: 0x00029A38 File Offset: 0x00027C38
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator !=(double4 lhs, double4 rhs)
		{
			return new bool4(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w);
		}

		// Token: 0x06000DC0 RID: 3520 RVA: 0x00029A8E File Offset: 0x00027C8E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator !=(double4 lhs, double rhs)
		{
			return new bool4(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs, lhs.w != rhs);
		}

		// Token: 0x06000DC1 RID: 3521 RVA: 0x00029AC5 File Offset: 0x00027CC5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator !=(double lhs, double4 rhs)
		{
			return new bool4(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z, lhs != rhs.w);
		}

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x06000DC2 RID: 3522 RVA: 0x00029AFC File Offset: 0x00027CFC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.x, this.x);
			}
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x06000DC3 RID: 3523 RVA: 0x00029B1B File Offset: 0x00027D1B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.x, this.y);
			}
		}

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000DC4 RID: 3524 RVA: 0x00029B3A File Offset: 0x00027D3A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.x, this.z);
			}
		}

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000DC5 RID: 3525 RVA: 0x00029B59 File Offset: 0x00027D59
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.x, this.w);
			}
		}

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06000DC6 RID: 3526 RVA: 0x00029B78 File Offset: 0x00027D78
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.y, this.x);
			}
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000DC7 RID: 3527 RVA: 0x00029B97 File Offset: 0x00027D97
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.y, this.y);
			}
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x06000DC8 RID: 3528 RVA: 0x00029BB6 File Offset: 0x00027DB6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.y, this.z);
			}
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x06000DC9 RID: 3529 RVA: 0x00029BD5 File Offset: 0x00027DD5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.y, this.w);
			}
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x06000DCA RID: 3530 RVA: 0x00029BF4 File Offset: 0x00027DF4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.z, this.x);
			}
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x06000DCB RID: 3531 RVA: 0x00029C13 File Offset: 0x00027E13
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.z, this.y);
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x06000DCC RID: 3532 RVA: 0x00029C32 File Offset: 0x00027E32
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.z, this.z);
			}
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x06000DCD RID: 3533 RVA: 0x00029C51 File Offset: 0x00027E51
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.z, this.w);
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06000DCE RID: 3534 RVA: 0x00029C70 File Offset: 0x00027E70
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.w, this.x);
			}
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06000DCF RID: 3535 RVA: 0x00029C8F File Offset: 0x00027E8F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.w, this.y);
			}
		}

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06000DD0 RID: 3536 RVA: 0x00029CAE File Offset: 0x00027EAE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.w, this.z);
			}
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x06000DD1 RID: 3537 RVA: 0x00029CCD File Offset: 0x00027ECD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.w, this.w);
			}
		}

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x06000DD2 RID: 3538 RVA: 0x00029CEC File Offset: 0x00027EEC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.x, this.x);
			}
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x06000DD3 RID: 3539 RVA: 0x00029D0B File Offset: 0x00027F0B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.x, this.y);
			}
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x06000DD4 RID: 3540 RVA: 0x00029D2A File Offset: 0x00027F2A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.x, this.z);
			}
		}

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x06000DD5 RID: 3541 RVA: 0x00029D49 File Offset: 0x00027F49
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.x, this.w);
			}
		}

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x06000DD6 RID: 3542 RVA: 0x00029D68 File Offset: 0x00027F68
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.y, this.x);
			}
		}

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x06000DD7 RID: 3543 RVA: 0x00029D87 File Offset: 0x00027F87
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.y, this.y);
			}
		}

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x06000DD8 RID: 3544 RVA: 0x00029DA6 File Offset: 0x00027FA6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.y, this.z);
			}
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x06000DD9 RID: 3545 RVA: 0x00029DC5 File Offset: 0x00027FC5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.y, this.w);
			}
		}

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x06000DDA RID: 3546 RVA: 0x00029DE4 File Offset: 0x00027FE4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.z, this.x);
			}
		}

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x06000DDB RID: 3547 RVA: 0x00029E03 File Offset: 0x00028003
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.z, this.y);
			}
		}

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x06000DDC RID: 3548 RVA: 0x00029E22 File Offset: 0x00028022
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.z, this.z);
			}
		}

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x06000DDD RID: 3549 RVA: 0x00029E41 File Offset: 0x00028041
		// (set) Token: 0x06000DDE RID: 3550 RVA: 0x00029E60 File Offset: 0x00028060
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.z, this.w);
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

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x06000DDF RID: 3551 RVA: 0x00029E92 File Offset: 0x00028092
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.w, this.x);
			}
		}

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x06000DE0 RID: 3552 RVA: 0x00029EB1 File Offset: 0x000280B1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.w, this.y);
			}
		}

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x06000DE1 RID: 3553 RVA: 0x00029ED0 File Offset: 0x000280D0
		// (set) Token: 0x06000DE2 RID: 3554 RVA: 0x00029EEF File Offset: 0x000280EF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.w, this.z);
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

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x06000DE3 RID: 3555 RVA: 0x00029F21 File Offset: 0x00028121
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.w, this.w);
			}
		}

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x06000DE4 RID: 3556 RVA: 0x00029F40 File Offset: 0x00028140
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.x, this.x);
			}
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x06000DE5 RID: 3557 RVA: 0x00029F5F File Offset: 0x0002815F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.x, this.y);
			}
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x06000DE6 RID: 3558 RVA: 0x00029F7E File Offset: 0x0002817E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.x, this.z);
			}
		}

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x06000DE7 RID: 3559 RVA: 0x00029F9D File Offset: 0x0002819D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.x, this.w);
			}
		}

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x06000DE8 RID: 3560 RVA: 0x00029FBC File Offset: 0x000281BC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.y, this.x);
			}
		}

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x06000DE9 RID: 3561 RVA: 0x00029FDB File Offset: 0x000281DB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.y, this.y);
			}
		}

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x06000DEA RID: 3562 RVA: 0x00029FFA File Offset: 0x000281FA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.y, this.z);
			}
		}

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x06000DEB RID: 3563 RVA: 0x0002A019 File Offset: 0x00028219
		// (set) Token: 0x06000DEC RID: 3564 RVA: 0x0002A038 File Offset: 0x00028238
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.y, this.w);
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

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x06000DED RID: 3565 RVA: 0x0002A06A File Offset: 0x0002826A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.z, this.x);
			}
		}

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x06000DEE RID: 3566 RVA: 0x0002A089 File Offset: 0x00028289
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.z, this.y);
			}
		}

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x06000DEF RID: 3567 RVA: 0x0002A0A8 File Offset: 0x000282A8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.z, this.z);
			}
		}

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x06000DF0 RID: 3568 RVA: 0x0002A0C7 File Offset: 0x000282C7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.z, this.w);
			}
		}

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x06000DF1 RID: 3569 RVA: 0x0002A0E6 File Offset: 0x000282E6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.w, this.x);
			}
		}

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x06000DF2 RID: 3570 RVA: 0x0002A105 File Offset: 0x00028305
		// (set) Token: 0x06000DF3 RID: 3571 RVA: 0x0002A124 File Offset: 0x00028324
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.w, this.y);
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

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x06000DF4 RID: 3572 RVA: 0x0002A156 File Offset: 0x00028356
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.w, this.z);
			}
		}

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x06000DF5 RID: 3573 RVA: 0x0002A175 File Offset: 0x00028375
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.w, this.w);
			}
		}

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06000DF6 RID: 3574 RVA: 0x0002A194 File Offset: 0x00028394
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.w, this.x, this.x);
			}
		}

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06000DF7 RID: 3575 RVA: 0x0002A1B3 File Offset: 0x000283B3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.w, this.x, this.y);
			}
		}

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x06000DF8 RID: 3576 RVA: 0x0002A1D2 File Offset: 0x000283D2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.w, this.x, this.z);
			}
		}

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x06000DF9 RID: 3577 RVA: 0x0002A1F1 File Offset: 0x000283F1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.w, this.x, this.w);
			}
		}

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x06000DFA RID: 3578 RVA: 0x0002A210 File Offset: 0x00028410
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.w, this.y, this.x);
			}
		}

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x06000DFB RID: 3579 RVA: 0x0002A22F File Offset: 0x0002842F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.w, this.y, this.y);
			}
		}

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x06000DFC RID: 3580 RVA: 0x0002A24E File Offset: 0x0002844E
		// (set) Token: 0x06000DFD RID: 3581 RVA: 0x0002A26D File Offset: 0x0002846D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.w, this.y, this.z);
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

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x06000DFE RID: 3582 RVA: 0x0002A29F File Offset: 0x0002849F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.w, this.y, this.w);
			}
		}

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x06000DFF RID: 3583 RVA: 0x0002A2BE File Offset: 0x000284BE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.w, this.z, this.x);
			}
		}

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x06000E00 RID: 3584 RVA: 0x0002A2DD File Offset: 0x000284DD
		// (set) Token: 0x06000E01 RID: 3585 RVA: 0x0002A2FC File Offset: 0x000284FC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.w, this.z, this.y);
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

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06000E02 RID: 3586 RVA: 0x0002A32E File Offset: 0x0002852E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.w, this.z, this.z);
			}
		}

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06000E03 RID: 3587 RVA: 0x0002A34D File Offset: 0x0002854D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.w, this.z, this.w);
			}
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x06000E04 RID: 3588 RVA: 0x0002A36C File Offset: 0x0002856C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.w, this.w, this.x);
			}
		}

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x06000E05 RID: 3589 RVA: 0x0002A38B File Offset: 0x0002858B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.w, this.w, this.y);
			}
		}

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x06000E06 RID: 3590 RVA: 0x0002A3AA File Offset: 0x000285AA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.w, this.w, this.z);
			}
		}

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x06000E07 RID: 3591 RVA: 0x0002A3C9 File Offset: 0x000285C9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.w, this.w, this.w);
			}
		}

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x06000E08 RID: 3592 RVA: 0x0002A3E8 File Offset: 0x000285E8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.x, this.x);
			}
		}

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x06000E09 RID: 3593 RVA: 0x0002A407 File Offset: 0x00028607
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.x, this.y);
			}
		}

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x06000E0A RID: 3594 RVA: 0x0002A426 File Offset: 0x00028626
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.x, this.z);
			}
		}

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06000E0B RID: 3595 RVA: 0x0002A445 File Offset: 0x00028645
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.x, this.w);
			}
		}

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000E0C RID: 3596 RVA: 0x0002A464 File Offset: 0x00028664
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.y, this.x);
			}
		}

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000E0D RID: 3597 RVA: 0x0002A483 File Offset: 0x00028683
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.y, this.y);
			}
		}

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06000E0E RID: 3598 RVA: 0x0002A4A2 File Offset: 0x000286A2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.y, this.z);
			}
		}

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06000E0F RID: 3599 RVA: 0x0002A4C1 File Offset: 0x000286C1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.y, this.w);
			}
		}

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06000E10 RID: 3600 RVA: 0x0002A4E0 File Offset: 0x000286E0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.z, this.x);
			}
		}

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06000E11 RID: 3601 RVA: 0x0002A4FF File Offset: 0x000286FF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.z, this.y);
			}
		}

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06000E12 RID: 3602 RVA: 0x0002A51E File Offset: 0x0002871E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.z, this.z);
			}
		}

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x06000E13 RID: 3603 RVA: 0x0002A53D File Offset: 0x0002873D
		// (set) Token: 0x06000E14 RID: 3604 RVA: 0x0002A55C File Offset: 0x0002875C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.z, this.w);
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

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x06000E15 RID: 3605 RVA: 0x0002A58E File Offset: 0x0002878E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.w, this.x);
			}
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x06000E16 RID: 3606 RVA: 0x0002A5AD File Offset: 0x000287AD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.w, this.y);
			}
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06000E17 RID: 3607 RVA: 0x0002A5CC File Offset: 0x000287CC
		// (set) Token: 0x06000E18 RID: 3608 RVA: 0x0002A5EB File Offset: 0x000287EB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.w, this.z);
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

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x06000E19 RID: 3609 RVA: 0x0002A61D File Offset: 0x0002881D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.w, this.w);
			}
		}

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x06000E1A RID: 3610 RVA: 0x0002A63C File Offset: 0x0002883C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.x, this.x);
			}
		}

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x06000E1B RID: 3611 RVA: 0x0002A65B File Offset: 0x0002885B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.x, this.y);
			}
		}

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000E1C RID: 3612 RVA: 0x0002A67A File Offset: 0x0002887A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.x, this.z);
			}
		}

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06000E1D RID: 3613 RVA: 0x0002A699 File Offset: 0x00028899
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.x, this.w);
			}
		}

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x06000E1E RID: 3614 RVA: 0x0002A6B8 File Offset: 0x000288B8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.y, this.x);
			}
		}

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x06000E1F RID: 3615 RVA: 0x0002A6D7 File Offset: 0x000288D7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.y, this.y);
			}
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x06000E20 RID: 3616 RVA: 0x0002A6F6 File Offset: 0x000288F6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.y, this.z);
			}
		}

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x06000E21 RID: 3617 RVA: 0x0002A715 File Offset: 0x00028915
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.y, this.w);
			}
		}

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x06000E22 RID: 3618 RVA: 0x0002A734 File Offset: 0x00028934
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.z, this.x);
			}
		}

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x06000E23 RID: 3619 RVA: 0x0002A753 File Offset: 0x00028953
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.z, this.y);
			}
		}

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x06000E24 RID: 3620 RVA: 0x0002A772 File Offset: 0x00028972
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.z, this.z);
			}
		}

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x06000E25 RID: 3621 RVA: 0x0002A791 File Offset: 0x00028991
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.z, this.w);
			}
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x06000E26 RID: 3622 RVA: 0x0002A7B0 File Offset: 0x000289B0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.w, this.x);
			}
		}

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x06000E27 RID: 3623 RVA: 0x0002A7CF File Offset: 0x000289CF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.w, this.y);
			}
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x06000E28 RID: 3624 RVA: 0x0002A7EE File Offset: 0x000289EE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.w, this.z);
			}
		}

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x06000E29 RID: 3625 RVA: 0x0002A80D File Offset: 0x00028A0D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.w, this.w);
			}
		}

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x06000E2A RID: 3626 RVA: 0x0002A82C File Offset: 0x00028A2C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.x, this.x);
			}
		}

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x06000E2B RID: 3627 RVA: 0x0002A84B File Offset: 0x00028A4B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.x, this.y);
			}
		}

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x06000E2C RID: 3628 RVA: 0x0002A86A File Offset: 0x00028A6A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.x, this.z);
			}
		}

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x06000E2D RID: 3629 RVA: 0x0002A889 File Offset: 0x00028A89
		// (set) Token: 0x06000E2E RID: 3630 RVA: 0x0002A8A8 File Offset: 0x00028AA8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.x, this.w);
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

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x06000E2F RID: 3631 RVA: 0x0002A8DA File Offset: 0x00028ADA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.y, this.x);
			}
		}

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06000E30 RID: 3632 RVA: 0x0002A8F9 File Offset: 0x00028AF9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.y, this.y);
			}
		}

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06000E31 RID: 3633 RVA: 0x0002A918 File Offset: 0x00028B18
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.y, this.z);
			}
		}

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06000E32 RID: 3634 RVA: 0x0002A937 File Offset: 0x00028B37
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.y, this.w);
			}
		}

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06000E33 RID: 3635 RVA: 0x0002A956 File Offset: 0x00028B56
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.z, this.x);
			}
		}

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06000E34 RID: 3636 RVA: 0x0002A975 File Offset: 0x00028B75
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.z, this.y);
			}
		}

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x06000E35 RID: 3637 RVA: 0x0002A994 File Offset: 0x00028B94
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.z, this.z);
			}
		}

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x06000E36 RID: 3638 RVA: 0x0002A9B3 File Offset: 0x00028BB3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.z, this.w);
			}
		}

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x06000E37 RID: 3639 RVA: 0x0002A9D2 File Offset: 0x00028BD2
		// (set) Token: 0x06000E38 RID: 3640 RVA: 0x0002A9F1 File Offset: 0x00028BF1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.w, this.x);
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

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x06000E39 RID: 3641 RVA: 0x0002AA23 File Offset: 0x00028C23
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.w, this.y);
			}
		}

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x06000E3A RID: 3642 RVA: 0x0002AA42 File Offset: 0x00028C42
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.w, this.z);
			}
		}

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x06000E3B RID: 3643 RVA: 0x0002AA61 File Offset: 0x00028C61
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.w, this.w);
			}
		}

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06000E3C RID: 3644 RVA: 0x0002AA80 File Offset: 0x00028C80
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 ywxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.w, this.x, this.x);
			}
		}

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x06000E3D RID: 3645 RVA: 0x0002AA9F File Offset: 0x00028C9F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 ywxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.w, this.x, this.y);
			}
		}

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06000E3E RID: 3646 RVA: 0x0002AABE File Offset: 0x00028CBE
		// (set) Token: 0x06000E3F RID: 3647 RVA: 0x0002AADD File Offset: 0x00028CDD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 ywxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.w, this.x, this.z);
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

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06000E40 RID: 3648 RVA: 0x0002AB0F File Offset: 0x00028D0F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 ywxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.w, this.x, this.w);
			}
		}

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06000E41 RID: 3649 RVA: 0x0002AB2E File Offset: 0x00028D2E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 ywyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.w, this.y, this.x);
			}
		}

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06000E42 RID: 3650 RVA: 0x0002AB4D File Offset: 0x00028D4D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 ywyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.w, this.y, this.y);
			}
		}

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06000E43 RID: 3651 RVA: 0x0002AB6C File Offset: 0x00028D6C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 ywyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.w, this.y, this.z);
			}
		}

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06000E44 RID: 3652 RVA: 0x0002AB8B File Offset: 0x00028D8B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 ywyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.w, this.y, this.w);
			}
		}

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06000E45 RID: 3653 RVA: 0x0002ABAA File Offset: 0x00028DAA
		// (set) Token: 0x06000E46 RID: 3654 RVA: 0x0002ABC9 File Offset: 0x00028DC9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 ywzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.w, this.z, this.x);
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

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06000E47 RID: 3655 RVA: 0x0002ABFB File Offset: 0x00028DFB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 ywzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.w, this.z, this.y);
			}
		}

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x06000E48 RID: 3656 RVA: 0x0002AC1A File Offset: 0x00028E1A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 ywzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.w, this.z, this.z);
			}
		}

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06000E49 RID: 3657 RVA: 0x0002AC39 File Offset: 0x00028E39
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 ywzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.w, this.z, this.w);
			}
		}

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06000E4A RID: 3658 RVA: 0x0002AC58 File Offset: 0x00028E58
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 ywwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.w, this.w, this.x);
			}
		}

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06000E4B RID: 3659 RVA: 0x0002AC77 File Offset: 0x00028E77
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 ywwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.w, this.w, this.y);
			}
		}

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x06000E4C RID: 3660 RVA: 0x0002AC96 File Offset: 0x00028E96
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 ywwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.w, this.w, this.z);
			}
		}

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x06000E4D RID: 3661 RVA: 0x0002ACB5 File Offset: 0x00028EB5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 ywww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.w, this.w, this.w);
			}
		}

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x06000E4E RID: 3662 RVA: 0x0002ACD4 File Offset: 0x00028ED4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.x, this.x);
			}
		}

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x06000E4F RID: 3663 RVA: 0x0002ACF3 File Offset: 0x00028EF3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.x, this.y);
			}
		}

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06000E50 RID: 3664 RVA: 0x0002AD12 File Offset: 0x00028F12
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.x, this.z);
			}
		}

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06000E51 RID: 3665 RVA: 0x0002AD31 File Offset: 0x00028F31
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.x, this.w);
			}
		}

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x06000E52 RID: 3666 RVA: 0x0002AD50 File Offset: 0x00028F50
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.y, this.x);
			}
		}

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x06000E53 RID: 3667 RVA: 0x0002AD6F File Offset: 0x00028F6F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.y, this.y);
			}
		}

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x06000E54 RID: 3668 RVA: 0x0002AD8E File Offset: 0x00028F8E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.y, this.z);
			}
		}

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06000E55 RID: 3669 RVA: 0x0002ADAD File Offset: 0x00028FAD
		// (set) Token: 0x06000E56 RID: 3670 RVA: 0x0002ADCC File Offset: 0x00028FCC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.y, this.w);
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

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x06000E57 RID: 3671 RVA: 0x0002ADFE File Offset: 0x00028FFE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.z, this.x);
			}
		}

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x06000E58 RID: 3672 RVA: 0x0002AE1D File Offset: 0x0002901D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.z, this.y);
			}
		}

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x06000E59 RID: 3673 RVA: 0x0002AE3C File Offset: 0x0002903C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.z, this.z);
			}
		}

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06000E5A RID: 3674 RVA: 0x0002AE5B File Offset: 0x0002905B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.z, this.w);
			}
		}

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06000E5B RID: 3675 RVA: 0x0002AE7A File Offset: 0x0002907A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.w, this.x);
			}
		}

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000E5C RID: 3676 RVA: 0x0002AE99 File Offset: 0x00029099
		// (set) Token: 0x06000E5D RID: 3677 RVA: 0x0002AEB8 File Offset: 0x000290B8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.w, this.y);
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

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000E5E RID: 3678 RVA: 0x0002AEEA File Offset: 0x000290EA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.w, this.z);
			}
		}

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06000E5F RID: 3679 RVA: 0x0002AF09 File Offset: 0x00029109
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.w, this.w);
			}
		}

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x06000E60 RID: 3680 RVA: 0x0002AF28 File Offset: 0x00029128
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.x, this.x);
			}
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06000E61 RID: 3681 RVA: 0x0002AF47 File Offset: 0x00029147
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.x, this.y);
			}
		}

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x06000E62 RID: 3682 RVA: 0x0002AF66 File Offset: 0x00029166
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.x, this.z);
			}
		}

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x06000E63 RID: 3683 RVA: 0x0002AF85 File Offset: 0x00029185
		// (set) Token: 0x06000E64 RID: 3684 RVA: 0x0002AFA4 File Offset: 0x000291A4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.x, this.w);
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

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x06000E65 RID: 3685 RVA: 0x0002AFD6 File Offset: 0x000291D6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.y, this.x);
			}
		}

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x06000E66 RID: 3686 RVA: 0x0002AFF5 File Offset: 0x000291F5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.y, this.y);
			}
		}

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x06000E67 RID: 3687 RVA: 0x0002B014 File Offset: 0x00029214
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.y, this.z);
			}
		}

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06000E68 RID: 3688 RVA: 0x0002B033 File Offset: 0x00029233
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.y, this.w);
			}
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06000E69 RID: 3689 RVA: 0x0002B052 File Offset: 0x00029252
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.z, this.x);
			}
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06000E6A RID: 3690 RVA: 0x0002B071 File Offset: 0x00029271
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.z, this.y);
			}
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06000E6B RID: 3691 RVA: 0x0002B090 File Offset: 0x00029290
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.z, this.z);
			}
		}

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06000E6C RID: 3692 RVA: 0x0002B0AF File Offset: 0x000292AF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.z, this.w);
			}
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06000E6D RID: 3693 RVA: 0x0002B0CE File Offset: 0x000292CE
		// (set) Token: 0x06000E6E RID: 3694 RVA: 0x0002B0ED File Offset: 0x000292ED
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.w, this.x);
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

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06000E6F RID: 3695 RVA: 0x0002B11F File Offset: 0x0002931F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.w, this.y);
			}
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000E70 RID: 3696 RVA: 0x0002B13E File Offset: 0x0002933E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.w, this.z);
			}
		}

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06000E71 RID: 3697 RVA: 0x0002B15D File Offset: 0x0002935D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.w, this.w);
			}
		}

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06000E72 RID: 3698 RVA: 0x0002B17C File Offset: 0x0002937C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.x, this.x);
			}
		}

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06000E73 RID: 3699 RVA: 0x0002B19B File Offset: 0x0002939B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.x, this.y);
			}
		}

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x06000E74 RID: 3700 RVA: 0x0002B1BA File Offset: 0x000293BA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.x, this.z);
			}
		}

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06000E75 RID: 3701 RVA: 0x0002B1D9 File Offset: 0x000293D9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.x, this.w);
			}
		}

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x06000E76 RID: 3702 RVA: 0x0002B1F8 File Offset: 0x000293F8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.y, this.x);
			}
		}

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06000E77 RID: 3703 RVA: 0x0002B217 File Offset: 0x00029417
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.y, this.y);
			}
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06000E78 RID: 3704 RVA: 0x0002B236 File Offset: 0x00029436
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.y, this.z);
			}
		}

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x06000E79 RID: 3705 RVA: 0x0002B255 File Offset: 0x00029455
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.y, this.w);
			}
		}

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06000E7A RID: 3706 RVA: 0x0002B274 File Offset: 0x00029474
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.z, this.x);
			}
		}

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x06000E7B RID: 3707 RVA: 0x0002B293 File Offset: 0x00029493
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.z, this.y);
			}
		}

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x06000E7C RID: 3708 RVA: 0x0002B2B2 File Offset: 0x000294B2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.z, this.z);
			}
		}

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x06000E7D RID: 3709 RVA: 0x0002B2D1 File Offset: 0x000294D1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.z, this.w);
			}
		}

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x06000E7E RID: 3710 RVA: 0x0002B2F0 File Offset: 0x000294F0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.w, this.x);
			}
		}

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x06000E7F RID: 3711 RVA: 0x0002B30F File Offset: 0x0002950F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.w, this.y);
			}
		}

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x06000E80 RID: 3712 RVA: 0x0002B32E File Offset: 0x0002952E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.w, this.z);
			}
		}

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x06000E81 RID: 3713 RVA: 0x0002B34D File Offset: 0x0002954D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.w, this.w);
			}
		}

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06000E82 RID: 3714 RVA: 0x0002B36C File Offset: 0x0002956C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.w, this.x, this.x);
			}
		}

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x06000E83 RID: 3715 RVA: 0x0002B38B File Offset: 0x0002958B
		// (set) Token: 0x06000E84 RID: 3716 RVA: 0x0002B3AA File Offset: 0x000295AA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.w, this.x, this.y);
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

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06000E85 RID: 3717 RVA: 0x0002B3DC File Offset: 0x000295DC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.w, this.x, this.z);
			}
		}

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06000E86 RID: 3718 RVA: 0x0002B3FB File Offset: 0x000295FB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.w, this.x, this.w);
			}
		}

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06000E87 RID: 3719 RVA: 0x0002B41A File Offset: 0x0002961A
		// (set) Token: 0x06000E88 RID: 3720 RVA: 0x0002B439 File Offset: 0x00029639
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.w, this.y, this.x);
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

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x06000E89 RID: 3721 RVA: 0x0002B46B File Offset: 0x0002966B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.w, this.y, this.y);
			}
		}

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x06000E8A RID: 3722 RVA: 0x0002B48A File Offset: 0x0002968A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.w, this.y, this.z);
			}
		}

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x06000E8B RID: 3723 RVA: 0x0002B4A9 File Offset: 0x000296A9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.w, this.y, this.w);
			}
		}

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06000E8C RID: 3724 RVA: 0x0002B4C8 File Offset: 0x000296C8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.w, this.z, this.x);
			}
		}

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06000E8D RID: 3725 RVA: 0x0002B4E7 File Offset: 0x000296E7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.w, this.z, this.y);
			}
		}

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x06000E8E RID: 3726 RVA: 0x0002B506 File Offset: 0x00029706
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.w, this.z, this.z);
			}
		}

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x06000E8F RID: 3727 RVA: 0x0002B525 File Offset: 0x00029725
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.w, this.z, this.w);
			}
		}

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x06000E90 RID: 3728 RVA: 0x0002B544 File Offset: 0x00029744
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.w, this.w, this.x);
			}
		}

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x06000E91 RID: 3729 RVA: 0x0002B563 File Offset: 0x00029763
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.w, this.w, this.y);
			}
		}

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x06000E92 RID: 3730 RVA: 0x0002B582 File Offset: 0x00029782
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.w, this.w, this.z);
			}
		}

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x06000E93 RID: 3731 RVA: 0x0002B5A1 File Offset: 0x000297A1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.w, this.w, this.w);
			}
		}

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x06000E94 RID: 3732 RVA: 0x0002B5C0 File Offset: 0x000297C0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.x, this.x, this.x);
			}
		}

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06000E95 RID: 3733 RVA: 0x0002B5DF File Offset: 0x000297DF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.x, this.x, this.y);
			}
		}

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06000E96 RID: 3734 RVA: 0x0002B5FE File Offset: 0x000297FE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.x, this.x, this.z);
			}
		}

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06000E97 RID: 3735 RVA: 0x0002B61D File Offset: 0x0002981D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.x, this.x, this.w);
			}
		}

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x06000E98 RID: 3736 RVA: 0x0002B63C File Offset: 0x0002983C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.x, this.y, this.x);
			}
		}

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x06000E99 RID: 3737 RVA: 0x0002B65B File Offset: 0x0002985B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.x, this.y, this.y);
			}
		}

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x06000E9A RID: 3738 RVA: 0x0002B67A File Offset: 0x0002987A
		// (set) Token: 0x06000E9B RID: 3739 RVA: 0x0002B699 File Offset: 0x00029899
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.x, this.y, this.z);
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

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x06000E9C RID: 3740 RVA: 0x0002B6CB File Offset: 0x000298CB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.x, this.y, this.w);
			}
		}

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x06000E9D RID: 3741 RVA: 0x0002B6EA File Offset: 0x000298EA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.x, this.z, this.x);
			}
		}

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x06000E9E RID: 3742 RVA: 0x0002B709 File Offset: 0x00029909
		// (set) Token: 0x06000E9F RID: 3743 RVA: 0x0002B728 File Offset: 0x00029928
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.x, this.z, this.y);
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

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x06000EA0 RID: 3744 RVA: 0x0002B75A File Offset: 0x0002995A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.x, this.z, this.z);
			}
		}

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x06000EA1 RID: 3745 RVA: 0x0002B779 File Offset: 0x00029979
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.x, this.z, this.w);
			}
		}

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06000EA2 RID: 3746 RVA: 0x0002B798 File Offset: 0x00029998
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.x, this.w, this.x);
			}
		}

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x06000EA3 RID: 3747 RVA: 0x0002B7B7 File Offset: 0x000299B7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.x, this.w, this.y);
			}
		}

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x06000EA4 RID: 3748 RVA: 0x0002B7D6 File Offset: 0x000299D6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.x, this.w, this.z);
			}
		}

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x06000EA5 RID: 3749 RVA: 0x0002B7F5 File Offset: 0x000299F5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.x, this.w, this.w);
			}
		}

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x06000EA6 RID: 3750 RVA: 0x0002B814 File Offset: 0x00029A14
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.y, this.x, this.x);
			}
		}

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x06000EA7 RID: 3751 RVA: 0x0002B833 File Offset: 0x00029A33
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.y, this.x, this.y);
			}
		}

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x06000EA8 RID: 3752 RVA: 0x0002B852 File Offset: 0x00029A52
		// (set) Token: 0x06000EA9 RID: 3753 RVA: 0x0002B871 File Offset: 0x00029A71
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.y, this.x, this.z);
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

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x06000EAA RID: 3754 RVA: 0x0002B8A3 File Offset: 0x00029AA3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.y, this.x, this.w);
			}
		}

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x06000EAB RID: 3755 RVA: 0x0002B8C2 File Offset: 0x00029AC2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.y, this.y, this.x);
			}
		}

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x06000EAC RID: 3756 RVA: 0x0002B8E1 File Offset: 0x00029AE1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.y, this.y, this.y);
			}
		}

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x06000EAD RID: 3757 RVA: 0x0002B900 File Offset: 0x00029B00
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.y, this.y, this.z);
			}
		}

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x06000EAE RID: 3758 RVA: 0x0002B91F File Offset: 0x00029B1F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.y, this.y, this.w);
			}
		}

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x06000EAF RID: 3759 RVA: 0x0002B93E File Offset: 0x00029B3E
		// (set) Token: 0x06000EB0 RID: 3760 RVA: 0x0002B95D File Offset: 0x00029B5D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.y, this.z, this.x);
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

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x06000EB1 RID: 3761 RVA: 0x0002B98F File Offset: 0x00029B8F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.y, this.z, this.y);
			}
		}

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06000EB2 RID: 3762 RVA: 0x0002B9AE File Offset: 0x00029BAE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.y, this.z, this.z);
			}
		}

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06000EB3 RID: 3763 RVA: 0x0002B9CD File Offset: 0x00029BCD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.y, this.z, this.w);
			}
		}

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x06000EB4 RID: 3764 RVA: 0x0002B9EC File Offset: 0x00029BEC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.y, this.w, this.x);
			}
		}

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x06000EB5 RID: 3765 RVA: 0x0002BA0B File Offset: 0x00029C0B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.y, this.w, this.y);
			}
		}

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x06000EB6 RID: 3766 RVA: 0x0002BA2A File Offset: 0x00029C2A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.y, this.w, this.z);
			}
		}

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06000EB7 RID: 3767 RVA: 0x0002BA49 File Offset: 0x00029C49
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.y, this.w, this.w);
			}
		}

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06000EB8 RID: 3768 RVA: 0x0002BA68 File Offset: 0x00029C68
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.z, this.x, this.x);
			}
		}

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06000EB9 RID: 3769 RVA: 0x0002BA87 File Offset: 0x00029C87
		// (set) Token: 0x06000EBA RID: 3770 RVA: 0x0002BAA6 File Offset: 0x00029CA6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.z, this.x, this.y);
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

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x06000EBB RID: 3771 RVA: 0x0002BAD8 File Offset: 0x00029CD8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.z, this.x, this.z);
			}
		}

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x06000EBC RID: 3772 RVA: 0x0002BAF7 File Offset: 0x00029CF7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.z, this.x, this.w);
			}
		}

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06000EBD RID: 3773 RVA: 0x0002BB16 File Offset: 0x00029D16
		// (set) Token: 0x06000EBE RID: 3774 RVA: 0x0002BB35 File Offset: 0x00029D35
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.z, this.y, this.x);
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

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x06000EBF RID: 3775 RVA: 0x0002BB67 File Offset: 0x00029D67
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.z, this.y, this.y);
			}
		}

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x06000EC0 RID: 3776 RVA: 0x0002BB86 File Offset: 0x00029D86
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.z, this.y, this.z);
			}
		}

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x06000EC1 RID: 3777 RVA: 0x0002BBA5 File Offset: 0x00029DA5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.z, this.y, this.w);
			}
		}

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x06000EC2 RID: 3778 RVA: 0x0002BBC4 File Offset: 0x00029DC4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.z, this.z, this.x);
			}
		}

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06000EC3 RID: 3779 RVA: 0x0002BBE3 File Offset: 0x00029DE3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.z, this.z, this.y);
			}
		}

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x06000EC4 RID: 3780 RVA: 0x0002BC02 File Offset: 0x00029E02
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.z, this.z, this.z);
			}
		}

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x06000EC5 RID: 3781 RVA: 0x0002BC21 File Offset: 0x00029E21
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.z, this.z, this.w);
			}
		}

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x06000EC6 RID: 3782 RVA: 0x0002BC40 File Offset: 0x00029E40
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.z, this.w, this.x);
			}
		}

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x06000EC7 RID: 3783 RVA: 0x0002BC5F File Offset: 0x00029E5F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.z, this.w, this.y);
			}
		}

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x06000EC8 RID: 3784 RVA: 0x0002BC7E File Offset: 0x00029E7E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.z, this.w, this.z);
			}
		}

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06000EC9 RID: 3785 RVA: 0x0002BC9D File Offset: 0x00029E9D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.z, this.w, this.w);
			}
		}

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06000ECA RID: 3786 RVA: 0x0002BCBC File Offset: 0x00029EBC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.w, this.x, this.x);
			}
		}

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000ECB RID: 3787 RVA: 0x0002BCDB File Offset: 0x00029EDB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.w, this.x, this.y);
			}
		}

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06000ECC RID: 3788 RVA: 0x0002BCFA File Offset: 0x00029EFA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.w, this.x, this.z);
			}
		}

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x06000ECD RID: 3789 RVA: 0x0002BD19 File Offset: 0x00029F19
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.w, this.x, this.w);
			}
		}

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x06000ECE RID: 3790 RVA: 0x0002BD38 File Offset: 0x00029F38
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.w, this.y, this.x);
			}
		}

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x06000ECF RID: 3791 RVA: 0x0002BD57 File Offset: 0x00029F57
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.w, this.y, this.y);
			}
		}

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x06000ED0 RID: 3792 RVA: 0x0002BD76 File Offset: 0x00029F76
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.w, this.y, this.z);
			}
		}

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06000ED1 RID: 3793 RVA: 0x0002BD95 File Offset: 0x00029F95
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.w, this.y, this.w);
			}
		}

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06000ED2 RID: 3794 RVA: 0x0002BDB4 File Offset: 0x00029FB4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.w, this.z, this.x);
			}
		}

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000ED3 RID: 3795 RVA: 0x0002BDD3 File Offset: 0x00029FD3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.w, this.z, this.y);
			}
		}

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000ED4 RID: 3796 RVA: 0x0002BDF2 File Offset: 0x00029FF2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.w, this.z, this.z);
			}
		}

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06000ED5 RID: 3797 RVA: 0x0002BE11 File Offset: 0x0002A011
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.w, this.z, this.w);
			}
		}

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x06000ED6 RID: 3798 RVA: 0x0002BE30 File Offset: 0x0002A030
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.w, this.w, this.x);
			}
		}

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06000ED7 RID: 3799 RVA: 0x0002BE4F File Offset: 0x0002A04F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.w, this.w, this.y);
			}
		}

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x06000ED8 RID: 3800 RVA: 0x0002BE6E File Offset: 0x0002A06E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.w, this.w, this.z);
			}
		}

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06000ED9 RID: 3801 RVA: 0x0002BE8D File Offset: 0x0002A08D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 wwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.w, this.w, this.w, this.w);
			}
		}

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x06000EDA RID: 3802 RVA: 0x0002BEAC File Offset: 0x0002A0AC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.x, this.x);
			}
		}

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x06000EDB RID: 3803 RVA: 0x0002BEC5 File Offset: 0x0002A0C5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.x, this.y);
			}
		}

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x06000EDC RID: 3804 RVA: 0x0002BEDE File Offset: 0x0002A0DE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.x, this.z);
			}
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x06000EDD RID: 3805 RVA: 0x0002BEF7 File Offset: 0x0002A0F7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.x, this.w);
			}
		}

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x06000EDE RID: 3806 RVA: 0x0002BF10 File Offset: 0x0002A110
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.y, this.x);
			}
		}

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x06000EDF RID: 3807 RVA: 0x0002BF29 File Offset: 0x0002A129
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.y, this.y);
			}
		}

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x06000EE0 RID: 3808 RVA: 0x0002BF42 File Offset: 0x0002A142
		// (set) Token: 0x06000EE1 RID: 3809 RVA: 0x0002BF5B File Offset: 0x0002A15B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06000EE2 RID: 3810 RVA: 0x0002BF81 File Offset: 0x0002A181
		// (set) Token: 0x06000EE3 RID: 3811 RVA: 0x0002BF9A File Offset: 0x0002A19A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.y, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06000EE4 RID: 3812 RVA: 0x0002BFC0 File Offset: 0x0002A1C0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.z, this.x);
			}
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06000EE5 RID: 3813 RVA: 0x0002BFD9 File Offset: 0x0002A1D9
		// (set) Token: 0x06000EE6 RID: 3814 RVA: 0x0002BFF2 File Offset: 0x0002A1F2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06000EE7 RID: 3815 RVA: 0x0002C018 File Offset: 0x0002A218
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.z, this.z);
			}
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06000EE8 RID: 3816 RVA: 0x0002C031 File Offset: 0x0002A231
		// (set) Token: 0x06000EE9 RID: 3817 RVA: 0x0002C04A File Offset: 0x0002A24A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.z, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06000EEA RID: 3818 RVA: 0x0002C070 File Offset: 0x0002A270
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.w, this.x);
			}
		}

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06000EEB RID: 3819 RVA: 0x0002C089 File Offset: 0x0002A289
		// (set) Token: 0x06000EEC RID: 3820 RVA: 0x0002C0A2 File Offset: 0x0002A2A2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.w, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.w = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06000EED RID: 3821 RVA: 0x0002C0C8 File Offset: 0x0002A2C8
		// (set) Token: 0x06000EEE RID: 3822 RVA: 0x0002C0E1 File Offset: 0x0002A2E1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.w, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.w = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06000EEF RID: 3823 RVA: 0x0002C107 File Offset: 0x0002A307
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.w, this.w);
			}
		}

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x06000EF0 RID: 3824 RVA: 0x0002C120 File Offset: 0x0002A320
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.x, this.x);
			}
		}

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06000EF1 RID: 3825 RVA: 0x0002C139 File Offset: 0x0002A339
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.x, this.y);
			}
		}

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x06000EF2 RID: 3826 RVA: 0x0002C152 File Offset: 0x0002A352
		// (set) Token: 0x06000EF3 RID: 3827 RVA: 0x0002C16B File Offset: 0x0002A36B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06000EF4 RID: 3828 RVA: 0x0002C191 File Offset: 0x0002A391
		// (set) Token: 0x06000EF5 RID: 3829 RVA: 0x0002C1AA File Offset: 0x0002A3AA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.x, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06000EF6 RID: 3830 RVA: 0x0002C1D0 File Offset: 0x0002A3D0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.y, this.x);
			}
		}

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06000EF7 RID: 3831 RVA: 0x0002C1E9 File Offset: 0x0002A3E9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.y, this.y);
			}
		}

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06000EF8 RID: 3832 RVA: 0x0002C202 File Offset: 0x0002A402
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.y, this.z);
			}
		}

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06000EF9 RID: 3833 RVA: 0x0002C21B File Offset: 0x0002A41B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.y, this.w);
			}
		}

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06000EFA RID: 3834 RVA: 0x0002C234 File Offset: 0x0002A434
		// (set) Token: 0x06000EFB RID: 3835 RVA: 0x0002C24D File Offset: 0x0002A44D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06000EFC RID: 3836 RVA: 0x0002C273 File Offset: 0x0002A473
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.z, this.y);
			}
		}

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06000EFD RID: 3837 RVA: 0x0002C28C File Offset: 0x0002A48C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.z, this.z);
			}
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06000EFE RID: 3838 RVA: 0x0002C2A5 File Offset: 0x0002A4A5
		// (set) Token: 0x06000EFF RID: 3839 RVA: 0x0002C2BE File Offset: 0x0002A4BE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.z, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06000F00 RID: 3840 RVA: 0x0002C2E4 File Offset: 0x0002A4E4
		// (set) Token: 0x06000F01 RID: 3841 RVA: 0x0002C2FD File Offset: 0x0002A4FD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 ywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.w, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.w = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06000F02 RID: 3842 RVA: 0x0002C323 File Offset: 0x0002A523
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 ywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.w, this.y);
			}
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06000F03 RID: 3843 RVA: 0x0002C33C File Offset: 0x0002A53C
		// (set) Token: 0x06000F04 RID: 3844 RVA: 0x0002C355 File Offset: 0x0002A555
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 ywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.w, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.w = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06000F05 RID: 3845 RVA: 0x0002C37B File Offset: 0x0002A57B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.w, this.w);
			}
		}

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x06000F06 RID: 3846 RVA: 0x0002C394 File Offset: 0x0002A594
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.x, this.x);
			}
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06000F07 RID: 3847 RVA: 0x0002C3AD File Offset: 0x0002A5AD
		// (set) Token: 0x06000F08 RID: 3848 RVA: 0x0002C3C6 File Offset: 0x0002A5C6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06000F09 RID: 3849 RVA: 0x0002C3EC File Offset: 0x0002A5EC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.x, this.z);
			}
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x06000F0A RID: 3850 RVA: 0x0002C405 File Offset: 0x0002A605
		// (set) Token: 0x06000F0B RID: 3851 RVA: 0x0002C41E File Offset: 0x0002A61E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.x, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x06000F0C RID: 3852 RVA: 0x0002C444 File Offset: 0x0002A644
		// (set) Token: 0x06000F0D RID: 3853 RVA: 0x0002C45D File Offset: 0x0002A65D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x06000F0E RID: 3854 RVA: 0x0002C483 File Offset: 0x0002A683
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.y, this.y);
			}
		}

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x06000F0F RID: 3855 RVA: 0x0002C49C File Offset: 0x0002A69C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.y, this.z);
			}
		}

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x06000F10 RID: 3856 RVA: 0x0002C4B5 File Offset: 0x0002A6B5
		// (set) Token: 0x06000F11 RID: 3857 RVA: 0x0002C4CE File Offset: 0x0002A6CE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.y, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x06000F12 RID: 3858 RVA: 0x0002C4F4 File Offset: 0x0002A6F4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.z, this.x);
			}
		}

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x06000F13 RID: 3859 RVA: 0x0002C50D File Offset: 0x0002A70D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.z, this.y);
			}
		}

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x06000F14 RID: 3860 RVA: 0x0002C526 File Offset: 0x0002A726
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.z, this.z);
			}
		}

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06000F15 RID: 3861 RVA: 0x0002C53F File Offset: 0x0002A73F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.z, this.w);
			}
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06000F16 RID: 3862 RVA: 0x0002C558 File Offset: 0x0002A758
		// (set) Token: 0x06000F17 RID: 3863 RVA: 0x0002C571 File Offset: 0x0002A771
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.w, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.w = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06000F18 RID: 3864 RVA: 0x0002C597 File Offset: 0x0002A797
		// (set) Token: 0x06000F19 RID: 3865 RVA: 0x0002C5B0 File Offset: 0x0002A7B0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.w, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.w = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x06000F1A RID: 3866 RVA: 0x0002C5D6 File Offset: 0x0002A7D6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.w, this.z);
			}
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x06000F1B RID: 3867 RVA: 0x0002C5EF File Offset: 0x0002A7EF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.w, this.w);
			}
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x06000F1C RID: 3868 RVA: 0x0002C608 File Offset: 0x0002A808
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 wxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.w, this.x, this.x);
			}
		}

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x06000F1D RID: 3869 RVA: 0x0002C621 File Offset: 0x0002A821
		// (set) Token: 0x06000F1E RID: 3870 RVA: 0x0002C63A File Offset: 0x0002A83A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 wxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.w, this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.x = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x06000F1F RID: 3871 RVA: 0x0002C660 File Offset: 0x0002A860
		// (set) Token: 0x06000F20 RID: 3872 RVA: 0x0002C679 File Offset: 0x0002A879
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 wxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.w, this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.x = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06000F21 RID: 3873 RVA: 0x0002C69F File Offset: 0x0002A89F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 wxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.w, this.x, this.w);
			}
		}

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06000F22 RID: 3874 RVA: 0x0002C6B8 File Offset: 0x0002A8B8
		// (set) Token: 0x06000F23 RID: 3875 RVA: 0x0002C6D1 File Offset: 0x0002A8D1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 wyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.w, this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.y = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06000F24 RID: 3876 RVA: 0x0002C6F7 File Offset: 0x0002A8F7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 wyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.w, this.y, this.y);
			}
		}

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x06000F25 RID: 3877 RVA: 0x0002C710 File Offset: 0x0002A910
		// (set) Token: 0x06000F26 RID: 3878 RVA: 0x0002C729 File Offset: 0x0002A929
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 wyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.w, this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.y = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x06000F27 RID: 3879 RVA: 0x0002C74F File Offset: 0x0002A94F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 wyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.w, this.y, this.w);
			}
		}

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x06000F28 RID: 3880 RVA: 0x0002C768 File Offset: 0x0002A968
		// (set) Token: 0x06000F29 RID: 3881 RVA: 0x0002C781 File Offset: 0x0002A981
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 wzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.w, this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.z = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x06000F2A RID: 3882 RVA: 0x0002C7A7 File Offset: 0x0002A9A7
		// (set) Token: 0x06000F2B RID: 3883 RVA: 0x0002C7C0 File Offset: 0x0002A9C0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 wzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.w, this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.z = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x06000F2C RID: 3884 RVA: 0x0002C7E6 File Offset: 0x0002A9E6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 wzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.w, this.z, this.z);
			}
		}

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x06000F2D RID: 3885 RVA: 0x0002C7FF File Offset: 0x0002A9FF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 wzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.w, this.z, this.w);
			}
		}

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x06000F2E RID: 3886 RVA: 0x0002C818 File Offset: 0x0002AA18
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 wwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.w, this.w, this.x);
			}
		}

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x06000F2F RID: 3887 RVA: 0x0002C831 File Offset: 0x0002AA31
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 wwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.w, this.w, this.y);
			}
		}

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x06000F30 RID: 3888 RVA: 0x0002C84A File Offset: 0x0002AA4A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 wwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.w, this.w, this.z);
			}
		}

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x06000F31 RID: 3889 RVA: 0x0002C863 File Offset: 0x0002AA63
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 www
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.w, this.w, this.w);
			}
		}

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06000F32 RID: 3890 RVA: 0x0002C87C File Offset: 0x0002AA7C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.x, this.x);
			}
		}

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x06000F33 RID: 3891 RVA: 0x0002C88F File Offset: 0x0002AA8F
		// (set) Token: 0x06000F34 RID: 3892 RVA: 0x0002C8A2 File Offset: 0x0002AAA2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 xy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x06000F35 RID: 3893 RVA: 0x0002C8BC File Offset: 0x0002AABC
		// (set) Token: 0x06000F36 RID: 3894 RVA: 0x0002C8CF File Offset: 0x0002AACF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 xz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
			}
		}

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x06000F37 RID: 3895 RVA: 0x0002C8E9 File Offset: 0x0002AAE9
		// (set) Token: 0x06000F38 RID: 3896 RVA: 0x0002C8FC File Offset: 0x0002AAFC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 xw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.x, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.w = value.y;
			}
		}

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x06000F39 RID: 3897 RVA: 0x0002C916 File Offset: 0x0002AB16
		// (set) Token: 0x06000F3A RID: 3898 RVA: 0x0002C929 File Offset: 0x0002AB29
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 yx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x06000F3B RID: 3899 RVA: 0x0002C943 File Offset: 0x0002AB43
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 yy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.y, this.y);
			}
		}

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06000F3C RID: 3900 RVA: 0x0002C956 File Offset: 0x0002AB56
		// (set) Token: 0x06000F3D RID: 3901 RVA: 0x0002C969 File Offset: 0x0002AB69
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 yz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
			}
		}

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06000F3E RID: 3902 RVA: 0x0002C983 File Offset: 0x0002AB83
		// (set) Token: 0x06000F3F RID: 3903 RVA: 0x0002C996 File Offset: 0x0002AB96
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 yw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.y, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.w = value.y;
			}
		}

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x06000F40 RID: 3904 RVA: 0x0002C9B0 File Offset: 0x0002ABB0
		// (set) Token: 0x06000F41 RID: 3905 RVA: 0x0002C9C3 File Offset: 0x0002ABC3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 zx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x06000F42 RID: 3906 RVA: 0x0002C9DD File Offset: 0x0002ABDD
		// (set) Token: 0x06000F43 RID: 3907 RVA: 0x0002C9F0 File Offset: 0x0002ABF0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 zy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x06000F44 RID: 3908 RVA: 0x0002CA0A File Offset: 0x0002AC0A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 zz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.z, this.z);
			}
		}

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x06000F45 RID: 3909 RVA: 0x0002CA1D File Offset: 0x0002AC1D
		// (set) Token: 0x06000F46 RID: 3910 RVA: 0x0002CA30 File Offset: 0x0002AC30
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 zw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.z, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.w = value.y;
			}
		}

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x06000F47 RID: 3911 RVA: 0x0002CA4A File Offset: 0x0002AC4A
		// (set) Token: 0x06000F48 RID: 3912 RVA: 0x0002CA5D File Offset: 0x0002AC5D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 wx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.w, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x06000F49 RID: 3913 RVA: 0x0002CA77 File Offset: 0x0002AC77
		// (set) Token: 0x06000F4A RID: 3914 RVA: 0x0002CA8A File Offset: 0x0002AC8A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 wy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.w, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x06000F4B RID: 3915 RVA: 0x0002CAA4 File Offset: 0x0002ACA4
		// (set) Token: 0x06000F4C RID: 3916 RVA: 0x0002CAB7 File Offset: 0x0002ACB7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 wz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.w, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.z = value.y;
			}
		}

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x06000F4D RID: 3917 RVA: 0x0002CAD1 File Offset: 0x0002ACD1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 ww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.w, this.w);
			}
		}

		// Token: 0x170003D7 RID: 983
		public unsafe double this[int index]
		{
			get
			{
				fixed (double4* ptr = &this)
				{
					return ((double*)ptr)[index];
				}
			}
			set
			{
				fixed (double* ptr = &this.x)
				{
					ptr[index] = value;
				}
			}
		}

		// Token: 0x06000F50 RID: 3920 RVA: 0x0002CB1C File Offset: 0x0002AD1C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(double4 rhs)
		{
			return this.x == rhs.x && this.y == rhs.y && this.z == rhs.z && this.w == rhs.w;
		}

		// Token: 0x06000F51 RID: 3921 RVA: 0x0002CB58 File Offset: 0x0002AD58
		public override bool Equals(object o)
		{
			if (o is double4)
			{
				double4 rhs = (double4)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06000F52 RID: 3922 RVA: 0x0002CB7D File Offset: 0x0002AD7D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06000F53 RID: 3923 RVA: 0x0002CB8C File Offset: 0x0002AD8C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("double4({0}, {1}, {2}, {3})", new object[]
			{
				this.x,
				this.y,
				this.z,
				this.w
			});
		}

		// Token: 0x06000F54 RID: 3924 RVA: 0x0002CBE4 File Offset: 0x0002ADE4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("double4({0}, {1}, {2}, {3})", new object[]
			{
				this.x.ToString(format, formatProvider),
				this.y.ToString(format, formatProvider),
				this.z.ToString(format, formatProvider),
				this.w.ToString(format, formatProvider)
			});
		}

		// Token: 0x0400005C RID: 92
		public double x;

		// Token: 0x0400005D RID: 93
		public double y;

		// Token: 0x0400005E RID: 94
		public double z;

		// Token: 0x0400005F RID: 95
		public double w;

		// Token: 0x04000060 RID: 96
		public static readonly double4 zero;

		// Token: 0x02000059 RID: 89
		internal sealed class DebuggerProxy
		{
			// Token: 0x0600246E RID: 9326 RVA: 0x000675C8 File Offset: 0x000657C8
			public DebuggerProxy(double4 v)
			{
				this.x = v.x;
				this.y = v.y;
				this.z = v.z;
				this.w = v.w;
			}

			// Token: 0x04000148 RID: 328
			public double x;

			// Token: 0x04000149 RID: 329
			public double y;

			// Token: 0x0400014A RID: 330
			public double z;

			// Token: 0x0400014B RID: 331
			public double w;
		}
	}
}
