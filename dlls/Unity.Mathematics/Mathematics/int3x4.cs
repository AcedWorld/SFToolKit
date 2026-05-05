using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000034 RID: 52
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct int3x4 : IEquatable<int3x4>, IFormattable
	{
		// Token: 0x06001AD4 RID: 6868 RVA: 0x000494EC File Offset: 0x000476EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x4(int3 c0, int3 c1, int3 c2, int3 c3)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
			this.c3 = c3;
		}

		// Token: 0x06001AD5 RID: 6869 RVA: 0x0004950C File Offset: 0x0004770C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x4(int m00, int m01, int m02, int m03, int m10, int m11, int m12, int m13, int m20, int m21, int m22, int m23)
		{
			this.c0 = new int3(m00, m10, m20);
			this.c1 = new int3(m01, m11, m21);
			this.c2 = new int3(m02, m12, m22);
			this.c3 = new int3(m03, m13, m23);
		}

		// Token: 0x06001AD6 RID: 6870 RVA: 0x0004955A File Offset: 0x0004775A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x4(int v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x06001AD7 RID: 6871 RVA: 0x0004958C File Offset: 0x0004778C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x4(bool v)
		{
			this.c0 = math.select(new int3(0), new int3(1), v);
			this.c1 = math.select(new int3(0), new int3(1), v);
			this.c2 = math.select(new int3(0), new int3(1), v);
			this.c3 = math.select(new int3(0), new int3(1), v);
		}

		// Token: 0x06001AD8 RID: 6872 RVA: 0x000495FC File Offset: 0x000477FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x4(bool3x4 v)
		{
			this.c0 = math.select(new int3(0), new int3(1), v.c0);
			this.c1 = math.select(new int3(0), new int3(1), v.c1);
			this.c2 = math.select(new int3(0), new int3(1), v.c2);
			this.c3 = math.select(new int3(0), new int3(1), v.c3);
		}

		// Token: 0x06001AD9 RID: 6873 RVA: 0x0004967D File Offset: 0x0004787D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x4(uint v)
		{
			this.c0 = (int3)v;
			this.c1 = (int3)v;
			this.c2 = (int3)v;
			this.c3 = (int3)v;
		}

		// Token: 0x06001ADA RID: 6874 RVA: 0x000496B0 File Offset: 0x000478B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x4(uint3x4 v)
		{
			this.c0 = (int3)v.c0;
			this.c1 = (int3)v.c1;
			this.c2 = (int3)v.c2;
			this.c3 = (int3)v.c3;
		}

		// Token: 0x06001ADB RID: 6875 RVA: 0x00049701 File Offset: 0x00047901
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x4(float v)
		{
			this.c0 = (int3)v;
			this.c1 = (int3)v;
			this.c2 = (int3)v;
			this.c3 = (int3)v;
		}

		// Token: 0x06001ADC RID: 6876 RVA: 0x00049734 File Offset: 0x00047934
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x4(float3x4 v)
		{
			this.c0 = (int3)v.c0;
			this.c1 = (int3)v.c1;
			this.c2 = (int3)v.c2;
			this.c3 = (int3)v.c3;
		}

		// Token: 0x06001ADD RID: 6877 RVA: 0x00049785 File Offset: 0x00047985
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x4(double v)
		{
			this.c0 = (int3)v;
			this.c1 = (int3)v;
			this.c2 = (int3)v;
			this.c3 = (int3)v;
		}

		// Token: 0x06001ADE RID: 6878 RVA: 0x000497B8 File Offset: 0x000479B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x4(double3x4 v)
		{
			this.c0 = (int3)v.c0;
			this.c1 = (int3)v.c1;
			this.c2 = (int3)v.c2;
			this.c3 = (int3)v.c3;
		}

		// Token: 0x06001ADF RID: 6879 RVA: 0x00049809 File Offset: 0x00047A09
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator int3x4(int v)
		{
			return new int3x4(v);
		}

		// Token: 0x06001AE0 RID: 6880 RVA: 0x00049811 File Offset: 0x00047A11
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x4(bool v)
		{
			return new int3x4(v);
		}

		// Token: 0x06001AE1 RID: 6881 RVA: 0x00049819 File Offset: 0x00047A19
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x4(bool3x4 v)
		{
			return new int3x4(v);
		}

		// Token: 0x06001AE2 RID: 6882 RVA: 0x00049821 File Offset: 0x00047A21
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x4(uint v)
		{
			return new int3x4(v);
		}

		// Token: 0x06001AE3 RID: 6883 RVA: 0x00049829 File Offset: 0x00047A29
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x4(uint3x4 v)
		{
			return new int3x4(v);
		}

		// Token: 0x06001AE4 RID: 6884 RVA: 0x00049831 File Offset: 0x00047A31
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x4(float v)
		{
			return new int3x4(v);
		}

		// Token: 0x06001AE5 RID: 6885 RVA: 0x00049839 File Offset: 0x00047A39
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x4(float3x4 v)
		{
			return new int3x4(v);
		}

		// Token: 0x06001AE6 RID: 6886 RVA: 0x00049841 File Offset: 0x00047A41
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x4(double v)
		{
			return new int3x4(v);
		}

		// Token: 0x06001AE7 RID: 6887 RVA: 0x00049849 File Offset: 0x00047A49
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x4(double3x4 v)
		{
			return new int3x4(v);
		}

		// Token: 0x06001AE8 RID: 6888 RVA: 0x00049854 File Offset: 0x00047A54
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator *(int3x4 lhs, int3x4 rhs)
		{
			return new int3x4(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2, lhs.c3 * rhs.c3);
		}

		// Token: 0x06001AE9 RID: 6889 RVA: 0x000498AA File Offset: 0x00047AAA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator *(int3x4 lhs, int rhs)
		{
			return new int3x4(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs, lhs.c3 * rhs);
		}

		// Token: 0x06001AEA RID: 6890 RVA: 0x000498E1 File Offset: 0x00047AE1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator *(int lhs, int3x4 rhs)
		{
			return new int3x4(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2, lhs * rhs.c3);
		}

		// Token: 0x06001AEB RID: 6891 RVA: 0x00049918 File Offset: 0x00047B18
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator +(int3x4 lhs, int3x4 rhs)
		{
			return new int3x4(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2, lhs.c3 + rhs.c3);
		}

		// Token: 0x06001AEC RID: 6892 RVA: 0x0004996E File Offset: 0x00047B6E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator +(int3x4 lhs, int rhs)
		{
			return new int3x4(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs, lhs.c3 + rhs);
		}

		// Token: 0x06001AED RID: 6893 RVA: 0x000499A5 File Offset: 0x00047BA5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator +(int lhs, int3x4 rhs)
		{
			return new int3x4(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2, lhs + rhs.c3);
		}

		// Token: 0x06001AEE RID: 6894 RVA: 0x000499DC File Offset: 0x00047BDC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator -(int3x4 lhs, int3x4 rhs)
		{
			return new int3x4(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2, lhs.c3 - rhs.c3);
		}

		// Token: 0x06001AEF RID: 6895 RVA: 0x00049A32 File Offset: 0x00047C32
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator -(int3x4 lhs, int rhs)
		{
			return new int3x4(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs, lhs.c3 - rhs);
		}

		// Token: 0x06001AF0 RID: 6896 RVA: 0x00049A69 File Offset: 0x00047C69
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator -(int lhs, int3x4 rhs)
		{
			return new int3x4(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2, lhs - rhs.c3);
		}

		// Token: 0x06001AF1 RID: 6897 RVA: 0x00049AA0 File Offset: 0x00047CA0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator /(int3x4 lhs, int3x4 rhs)
		{
			return new int3x4(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2, lhs.c3 / rhs.c3);
		}

		// Token: 0x06001AF2 RID: 6898 RVA: 0x00049AF6 File Offset: 0x00047CF6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator /(int3x4 lhs, int rhs)
		{
			return new int3x4(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs, lhs.c3 / rhs);
		}

		// Token: 0x06001AF3 RID: 6899 RVA: 0x00049B2D File Offset: 0x00047D2D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator /(int lhs, int3x4 rhs)
		{
			return new int3x4(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2, lhs / rhs.c3);
		}

		// Token: 0x06001AF4 RID: 6900 RVA: 0x00049B64 File Offset: 0x00047D64
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator %(int3x4 lhs, int3x4 rhs)
		{
			return new int3x4(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2, lhs.c3 % rhs.c3);
		}

		// Token: 0x06001AF5 RID: 6901 RVA: 0x00049BBA File Offset: 0x00047DBA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator %(int3x4 lhs, int rhs)
		{
			return new int3x4(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs, lhs.c3 % rhs);
		}

		// Token: 0x06001AF6 RID: 6902 RVA: 0x00049BF1 File Offset: 0x00047DF1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator %(int lhs, int3x4 rhs)
		{
			return new int3x4(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2, lhs % rhs.c3);
		}

		// Token: 0x06001AF7 RID: 6903 RVA: 0x00049C28 File Offset: 0x00047E28
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator ++(int3x4 val)
		{
			int3 @int = ++val.c0;
			val.c0 = @int;
			int3 int2 = @int;
			@int = ++val.c1;
			val.c1 = @int;
			int3 int3 = @int;
			@int = ++val.c2;
			val.c2 = @int;
			int3 int4 = @int;
			@int = ++val.c3;
			val.c3 = @int;
			return new int3x4(int2, int3, int4, @int);
		}

		// Token: 0x06001AF8 RID: 6904 RVA: 0x00049CA4 File Offset: 0x00047EA4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator --(int3x4 val)
		{
			int3 @int = --val.c0;
			val.c0 = @int;
			int3 int2 = @int;
			@int = --val.c1;
			val.c1 = @int;
			int3 int3 = @int;
			@int = --val.c2;
			val.c2 = @int;
			int3 int4 = @int;
			@int = --val.c3;
			val.c3 = @int;
			return new int3x4(int2, int3, int4, @int);
		}

		// Token: 0x06001AF9 RID: 6905 RVA: 0x00049D20 File Offset: 0x00047F20
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator <(int3x4 lhs, int3x4 rhs)
		{
			return new bool3x4(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2, lhs.c3 < rhs.c3);
		}

		// Token: 0x06001AFA RID: 6906 RVA: 0x00049D76 File Offset: 0x00047F76
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator <(int3x4 lhs, int rhs)
		{
			return new bool3x4(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs, lhs.c3 < rhs);
		}

		// Token: 0x06001AFB RID: 6907 RVA: 0x00049DAD File Offset: 0x00047FAD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator <(int lhs, int3x4 rhs)
		{
			return new bool3x4(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2, lhs < rhs.c3);
		}

		// Token: 0x06001AFC RID: 6908 RVA: 0x00049DE4 File Offset: 0x00047FE4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator <=(int3x4 lhs, int3x4 rhs)
		{
			return new bool3x4(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2, lhs.c3 <= rhs.c3);
		}

		// Token: 0x06001AFD RID: 6909 RVA: 0x00049E3A File Offset: 0x0004803A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator <=(int3x4 lhs, int rhs)
		{
			return new bool3x4(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs, lhs.c3 <= rhs);
		}

		// Token: 0x06001AFE RID: 6910 RVA: 0x00049E71 File Offset: 0x00048071
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator <=(int lhs, int3x4 rhs)
		{
			return new bool3x4(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2, lhs <= rhs.c3);
		}

		// Token: 0x06001AFF RID: 6911 RVA: 0x00049EA8 File Offset: 0x000480A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator >(int3x4 lhs, int3x4 rhs)
		{
			return new bool3x4(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2, lhs.c3 > rhs.c3);
		}

		// Token: 0x06001B00 RID: 6912 RVA: 0x00049EFE File Offset: 0x000480FE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator >(int3x4 lhs, int rhs)
		{
			return new bool3x4(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs, lhs.c3 > rhs);
		}

		// Token: 0x06001B01 RID: 6913 RVA: 0x00049F35 File Offset: 0x00048135
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator >(int lhs, int3x4 rhs)
		{
			return new bool3x4(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2, lhs > rhs.c3);
		}

		// Token: 0x06001B02 RID: 6914 RVA: 0x00049F6C File Offset: 0x0004816C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator >=(int3x4 lhs, int3x4 rhs)
		{
			return new bool3x4(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2, lhs.c3 >= rhs.c3);
		}

		// Token: 0x06001B03 RID: 6915 RVA: 0x00049FC2 File Offset: 0x000481C2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator >=(int3x4 lhs, int rhs)
		{
			return new bool3x4(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs, lhs.c3 >= rhs);
		}

		// Token: 0x06001B04 RID: 6916 RVA: 0x00049FF9 File Offset: 0x000481F9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator >=(int lhs, int3x4 rhs)
		{
			return new bool3x4(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2, lhs >= rhs.c3);
		}

		// Token: 0x06001B05 RID: 6917 RVA: 0x0004A030 File Offset: 0x00048230
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator -(int3x4 val)
		{
			return new int3x4(-val.c0, -val.c1, -val.c2, -val.c3);
		}

		// Token: 0x06001B06 RID: 6918 RVA: 0x0004A063 File Offset: 0x00048263
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator +(int3x4 val)
		{
			return new int3x4(+val.c0, +val.c1, +val.c2, +val.c3);
		}

		// Token: 0x06001B07 RID: 6919 RVA: 0x0004A096 File Offset: 0x00048296
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator <<(int3x4 x, int n)
		{
			return new int3x4(x.c0 << n, x.c1 << n, x.c2 << n, x.c3 << n);
		}

		// Token: 0x06001B08 RID: 6920 RVA: 0x0004A0CD File Offset: 0x000482CD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator >>(int3x4 x, int n)
		{
			return new int3x4(x.c0 >> n, x.c1 >> n, x.c2 >> n, x.c3 >> n);
		}

		// Token: 0x06001B09 RID: 6921 RVA: 0x0004A104 File Offset: 0x00048304
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator ==(int3x4 lhs, int3x4 rhs)
		{
			return new bool3x4(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2, lhs.c3 == rhs.c3);
		}

		// Token: 0x06001B0A RID: 6922 RVA: 0x0004A15A File Offset: 0x0004835A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator ==(int3x4 lhs, int rhs)
		{
			return new bool3x4(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs, lhs.c3 == rhs);
		}

		// Token: 0x06001B0B RID: 6923 RVA: 0x0004A191 File Offset: 0x00048391
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator ==(int lhs, int3x4 rhs)
		{
			return new bool3x4(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2, lhs == rhs.c3);
		}

		// Token: 0x06001B0C RID: 6924 RVA: 0x0004A1C8 File Offset: 0x000483C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator !=(int3x4 lhs, int3x4 rhs)
		{
			return new bool3x4(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2, lhs.c3 != rhs.c3);
		}

		// Token: 0x06001B0D RID: 6925 RVA: 0x0004A21E File Offset: 0x0004841E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator !=(int3x4 lhs, int rhs)
		{
			return new bool3x4(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs, lhs.c3 != rhs);
		}

		// Token: 0x06001B0E RID: 6926 RVA: 0x0004A255 File Offset: 0x00048455
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator !=(int lhs, int3x4 rhs)
		{
			return new bool3x4(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2, lhs != rhs.c3);
		}

		// Token: 0x06001B0F RID: 6927 RVA: 0x0004A28C File Offset: 0x0004848C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator ~(int3x4 val)
		{
			return new int3x4(~val.c0, ~val.c1, ~val.c2, ~val.c3);
		}

		// Token: 0x06001B10 RID: 6928 RVA: 0x0004A2C0 File Offset: 0x000484C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator &(int3x4 lhs, int3x4 rhs)
		{
			return new int3x4(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2, lhs.c3 & rhs.c3);
		}

		// Token: 0x06001B11 RID: 6929 RVA: 0x0004A316 File Offset: 0x00048516
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator &(int3x4 lhs, int rhs)
		{
			return new int3x4(lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs, lhs.c3 & rhs);
		}

		// Token: 0x06001B12 RID: 6930 RVA: 0x0004A34D File Offset: 0x0004854D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator &(int lhs, int3x4 rhs)
		{
			return new int3x4(lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2, lhs & rhs.c3);
		}

		// Token: 0x06001B13 RID: 6931 RVA: 0x0004A384 File Offset: 0x00048584
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator |(int3x4 lhs, int3x4 rhs)
		{
			return new int3x4(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2, lhs.c3 | rhs.c3);
		}

		// Token: 0x06001B14 RID: 6932 RVA: 0x0004A3DA File Offset: 0x000485DA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator |(int3x4 lhs, int rhs)
		{
			return new int3x4(lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs, lhs.c3 | rhs);
		}

		// Token: 0x06001B15 RID: 6933 RVA: 0x0004A411 File Offset: 0x00048611
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator |(int lhs, int3x4 rhs)
		{
			return new int3x4(lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2, lhs | rhs.c3);
		}

		// Token: 0x06001B16 RID: 6934 RVA: 0x0004A448 File Offset: 0x00048648
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator ^(int3x4 lhs, int3x4 rhs)
		{
			return new int3x4(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2, lhs.c3 ^ rhs.c3);
		}

		// Token: 0x06001B17 RID: 6935 RVA: 0x0004A49E File Offset: 0x0004869E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator ^(int3x4 lhs, int rhs)
		{
			return new int3x4(lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs, lhs.c3 ^ rhs);
		}

		// Token: 0x06001B18 RID: 6936 RVA: 0x0004A4D5 File Offset: 0x000486D5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 operator ^(int lhs, int3x4 rhs)
		{
			return new int3x4(lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2, lhs ^ rhs.c3);
		}

		// Token: 0x17000848 RID: 2120
		public unsafe int3 this[int index]
		{
			get
			{
				fixed (int3x4* ptr = &this)
				{
					return ref *(int3*)(ptr + (IntPtr)index * (IntPtr)sizeof(int3) / (IntPtr)sizeof(int3x4));
				}
			}
		}

		// Token: 0x06001B1A RID: 6938 RVA: 0x0004A528 File Offset: 0x00048728
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(int3x4 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2) && this.c3.Equals(rhs.c3);
		}

		// Token: 0x06001B1B RID: 6939 RVA: 0x0004A584 File Offset: 0x00048784
		public override bool Equals(object o)
		{
			if (o is int3x4)
			{
				int3x4 rhs = (int3x4)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06001B1C RID: 6940 RVA: 0x0004A5A9 File Offset: 0x000487A9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06001B1D RID: 6941 RVA: 0x0004A5B8 File Offset: 0x000487B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("int3x4({0}, {1}, {2}, {3},  {4}, {5}, {6}, {7},  {8}, {9}, {10}, {11})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c2.x,
				this.c3.x,
				this.c0.y,
				this.c1.y,
				this.c2.y,
				this.c3.y,
				this.c0.z,
				this.c1.z,
				this.c2.z,
				this.c3.z
			});
		}

		// Token: 0x06001B1E RID: 6942 RVA: 0x0004A6C0 File Offset: 0x000488C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("int3x4({0}, {1}, {2}, {3},  {4}, {5}, {6}, {7},  {8}, {9}, {10}, {11})", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c2.x.ToString(format, formatProvider),
				this.c3.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c2.y.ToString(format, formatProvider),
				this.c3.y.ToString(format, formatProvider),
				this.c0.z.ToString(format, formatProvider),
				this.c1.z.ToString(format, formatProvider),
				this.c2.z.ToString(format, formatProvider),
				this.c3.z.ToString(format, formatProvider)
			});
		}

		// Token: 0x040000CB RID: 203
		public int3 c0;

		// Token: 0x040000CC RID: 204
		public int3 c1;

		// Token: 0x040000CD RID: 205
		public int3 c2;

		// Token: 0x040000CE RID: 206
		public int3 c3;

		// Token: 0x040000CF RID: 207
		public static readonly int3x4 zero;
	}
}
