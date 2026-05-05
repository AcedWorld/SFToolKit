using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x0200003D RID: 61
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct Random
	{
		// Token: 0x06001E28 RID: 7720 RVA: 0x000579FD File Offset: 0x00055BFD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Random(uint seed)
		{
			this.state = seed;
			this.NextState();
		}

		// Token: 0x06001E29 RID: 7721 RVA: 0x00057A0D File Offset: 0x00055C0D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Random CreateFromIndex(uint index)
		{
			return new Random(Random.WangHash(index + 62U));
		}

		// Token: 0x06001E2A RID: 7722 RVA: 0x00057A1D File Offset: 0x00055C1D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static uint WangHash(uint n)
		{
			n = (n ^ 61U ^ n >> 16);
			n *= 9U;
			n ^= n >> 4;
			n *= 668265261U;
			n ^= n >> 15;
			return n;
		}

		// Token: 0x06001E2B RID: 7723 RVA: 0x00057A49 File Offset: 0x00055C49
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void InitState(uint seed = 1851936439U)
		{
			this.state = seed;
			this.NextState();
		}

		// Token: 0x06001E2C RID: 7724 RVA: 0x00057A59 File Offset: 0x00055C59
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool NextBool()
		{
			return (this.NextState() & 1U) == 1U;
		}

		// Token: 0x06001E2D RID: 7725 RVA: 0x00057A66 File Offset: 0x00055C66
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool2 NextBool2()
		{
			return (math.uint2(this.NextState()) & math.uint2(1U, 2U)) == 0U;
		}

		// Token: 0x06001E2E RID: 7726 RVA: 0x00057A85 File Offset: 0x00055C85
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool3 NextBool3()
		{
			return (math.uint3(this.NextState()) & math.uint3(1U, 2U, 4U)) == 0U;
		}

		// Token: 0x06001E2F RID: 7727 RVA: 0x00057AA5 File Offset: 0x00055CA5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool4 NextBool4()
		{
			return (math.uint4(this.NextState()) & math.uint4(1U, 2U, 4U, 8U)) == 0U;
		}

		// Token: 0x06001E30 RID: 7728 RVA: 0x00057AC6 File Offset: 0x00055CC6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int NextInt()
		{
			return (int)(this.NextState() ^ 2147483648U);
		}

		// Token: 0x06001E31 RID: 7729 RVA: 0x00057AD4 File Offset: 0x00055CD4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2 NextInt2()
		{
			return math.int2((int)this.NextState(), (int)this.NextState()) ^ int.MinValue;
		}

		// Token: 0x06001E32 RID: 7730 RVA: 0x00057AF1 File Offset: 0x00055CF1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3 NextInt3()
		{
			return math.int3((int)this.NextState(), (int)this.NextState(), (int)this.NextState()) ^ int.MinValue;
		}

		// Token: 0x06001E33 RID: 7731 RVA: 0x00057B14 File Offset: 0x00055D14
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4 NextInt4()
		{
			return math.int4((int)this.NextState(), (int)this.NextState(), (int)this.NextState(), (int)this.NextState()) ^ int.MinValue;
		}

		// Token: 0x06001E34 RID: 7732 RVA: 0x00057B3D File Offset: 0x00055D3D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int NextInt(int max)
		{
			return (int)((ulong)this.NextState() * (ulong)((long)max) >> 32);
		}

		// Token: 0x06001E35 RID: 7733 RVA: 0x00057B4D File Offset: 0x00055D4D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2 NextInt2(int2 max)
		{
			return math.int2((int)((ulong)this.NextState() * (ulong)((long)max.x) >> 32), (int)((ulong)this.NextState() * (ulong)((long)max.y) >> 32));
		}

		// Token: 0x06001E36 RID: 7734 RVA: 0x00057B7A File Offset: 0x00055D7A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3 NextInt3(int3 max)
		{
			return math.int3((int)((ulong)this.NextState() * (ulong)((long)max.x) >> 32), (int)((ulong)this.NextState() * (ulong)((long)max.y) >> 32), (int)((ulong)this.NextState() * (ulong)((long)max.z) >> 32));
		}

		// Token: 0x06001E37 RID: 7735 RVA: 0x00057BBC File Offset: 0x00055DBC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4 NextInt4(int4 max)
		{
			return math.int4((int)((ulong)this.NextState() * (ulong)((long)max.x) >> 32), (int)((ulong)this.NextState() * (ulong)((long)max.y) >> 32), (int)((ulong)this.NextState() * (ulong)((long)max.z) >> 32), (int)((ulong)this.NextState() * (ulong)((long)max.w) >> 32));
		}

		// Token: 0x06001E38 RID: 7736 RVA: 0x00057C1C File Offset: 0x00055E1C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int NextInt(int min, int max)
		{
			uint num = (uint)(max - min);
			return (int)((ulong)this.NextState() * (ulong)num >> 32) + min;
		}

		// Token: 0x06001E39 RID: 7737 RVA: 0x00057C40 File Offset: 0x00055E40
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2 NextInt2(int2 min, int2 max)
		{
			uint2 @uint = (uint2)(max - min);
			return math.int2((int)((ulong)this.NextState() * (ulong)@uint.x >> 32), (int)((ulong)this.NextState() * (ulong)@uint.y >> 32)) + min;
		}

		// Token: 0x06001E3A RID: 7738 RVA: 0x00057C8C File Offset: 0x00055E8C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3 NextInt3(int3 min, int3 max)
		{
			uint3 @uint = (uint3)(max - min);
			return math.int3((int)((ulong)this.NextState() * (ulong)@uint.x >> 32), (int)((ulong)this.NextState() * (ulong)@uint.y >> 32), (int)((ulong)this.NextState() * (ulong)@uint.z >> 32)) + min;
		}

		// Token: 0x06001E3B RID: 7739 RVA: 0x00057CEC File Offset: 0x00055EEC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4 NextInt4(int4 min, int4 max)
		{
			uint4 @uint = (uint4)(max - min);
			return math.int4((int)((ulong)this.NextState() * (ulong)@uint.x >> 32), (int)((ulong)this.NextState() * (ulong)@uint.y >> 32), (int)((ulong)this.NextState() * (ulong)@uint.z >> 32), (int)((ulong)this.NextState() * (ulong)@uint.w >> 32)) + min;
		}

		// Token: 0x06001E3C RID: 7740 RVA: 0x00057D5D File Offset: 0x00055F5D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint NextUInt()
		{
			return this.NextState() - 1U;
		}

		// Token: 0x06001E3D RID: 7741 RVA: 0x00057D67 File Offset: 0x00055F67
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2 NextUInt2()
		{
			return math.uint2(this.NextState(), this.NextState()) - 1U;
		}

		// Token: 0x06001E3E RID: 7742 RVA: 0x00057D80 File Offset: 0x00055F80
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3 NextUInt3()
		{
			return math.uint3(this.NextState(), this.NextState(), this.NextState()) - 1U;
		}

		// Token: 0x06001E3F RID: 7743 RVA: 0x00057D9F File Offset: 0x00055F9F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4 NextUInt4()
		{
			return math.uint4(this.NextState(), this.NextState(), this.NextState(), this.NextState()) - 1U;
		}

		// Token: 0x06001E40 RID: 7744 RVA: 0x00057DC4 File Offset: 0x00055FC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint NextUInt(uint max)
		{
			return (uint)((ulong)this.NextState() * (ulong)max >> 32);
		}

		// Token: 0x06001E41 RID: 7745 RVA: 0x00057DD4 File Offset: 0x00055FD4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2 NextUInt2(uint2 max)
		{
			return math.uint2((uint)((ulong)this.NextState() * (ulong)max.x >> 32), (uint)((ulong)this.NextState() * (ulong)max.y >> 32));
		}

		// Token: 0x06001E42 RID: 7746 RVA: 0x00057E01 File Offset: 0x00056001
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3 NextUInt3(uint3 max)
		{
			return math.uint3((uint)((ulong)this.NextState() * (ulong)max.x >> 32), (uint)((ulong)this.NextState() * (ulong)max.y >> 32), (uint)((ulong)this.NextState() * (ulong)max.z >> 32));
		}

		// Token: 0x06001E43 RID: 7747 RVA: 0x00057E44 File Offset: 0x00056044
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4 NextUInt4(uint4 max)
		{
			return math.uint4((uint)((ulong)this.NextState() * (ulong)max.x >> 32), (uint)((ulong)this.NextState() * (ulong)max.y >> 32), (uint)((ulong)this.NextState() * (ulong)max.z >> 32), (uint)((ulong)this.NextState() * (ulong)max.w >> 32));
		}

		// Token: 0x06001E44 RID: 7748 RVA: 0x00057EA4 File Offset: 0x000560A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint NextUInt(uint min, uint max)
		{
			uint num = max - min;
			return (uint)((ulong)this.NextState() * (ulong)num >> 32) + min;
		}

		// Token: 0x06001E45 RID: 7749 RVA: 0x00057EC8 File Offset: 0x000560C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2 NextUInt2(uint2 min, uint2 max)
		{
			uint2 @uint = max - min;
			return math.uint2((uint)((ulong)this.NextState() * (ulong)@uint.x >> 32), (uint)((ulong)this.NextState() * (ulong)@uint.y >> 32)) + min;
		}

		// Token: 0x06001E46 RID: 7750 RVA: 0x00057F10 File Offset: 0x00056110
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3 NextUInt3(uint3 min, uint3 max)
		{
			uint3 @uint = max - min;
			return math.uint3((uint)((ulong)this.NextState() * (ulong)@uint.x >> 32), (uint)((ulong)this.NextState() * (ulong)@uint.y >> 32), (uint)((ulong)this.NextState() * (ulong)@uint.z >> 32)) + min;
		}

		// Token: 0x06001E47 RID: 7751 RVA: 0x00057F6C File Offset: 0x0005616C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4 NextUInt4(uint4 min, uint4 max)
		{
			uint4 @uint = max - min;
			return math.uint4((uint)((ulong)this.NextState() * (ulong)@uint.x >> 32), (uint)((ulong)this.NextState() * (ulong)@uint.y >> 32), (uint)((ulong)this.NextState() * (ulong)@uint.z >> 32), (uint)((ulong)this.NextState() * (ulong)@uint.w >> 32)) + min;
		}

		// Token: 0x06001E48 RID: 7752 RVA: 0x00057FD8 File Offset: 0x000561D8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float NextFloat()
		{
			return math.asfloat(1065353216U | this.NextState() >> 9) - 1f;
		}

		// Token: 0x06001E49 RID: 7753 RVA: 0x00057FF4 File Offset: 0x000561F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2 NextFloat2()
		{
			return math.asfloat(1065353216U | math.uint2(this.NextState(), this.NextState()) >> 9) - 1f;
		}

		// Token: 0x06001E4A RID: 7754 RVA: 0x00058027 File Offset: 0x00056227
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3 NextFloat3()
		{
			return math.asfloat(1065353216U | math.uint3(this.NextState(), this.NextState(), this.NextState()) >> 9) - 1f;
		}

		// Token: 0x06001E4B RID: 7755 RVA: 0x00058060 File Offset: 0x00056260
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4 NextFloat4()
		{
			return math.asfloat(1065353216U | math.uint4(this.NextState(), this.NextState(), this.NextState(), this.NextState()) >> 9) - 1f;
		}

		// Token: 0x06001E4C RID: 7756 RVA: 0x0005809F File Offset: 0x0005629F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float NextFloat(float max)
		{
			return this.NextFloat() * max;
		}

		// Token: 0x06001E4D RID: 7757 RVA: 0x000580A9 File Offset: 0x000562A9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2 NextFloat2(float2 max)
		{
			return this.NextFloat2() * max;
		}

		// Token: 0x06001E4E RID: 7758 RVA: 0x000580B7 File Offset: 0x000562B7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3 NextFloat3(float3 max)
		{
			return this.NextFloat3() * max;
		}

		// Token: 0x06001E4F RID: 7759 RVA: 0x000580C5 File Offset: 0x000562C5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4 NextFloat4(float4 max)
		{
			return this.NextFloat4() * max;
		}

		// Token: 0x06001E50 RID: 7760 RVA: 0x000580D3 File Offset: 0x000562D3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float NextFloat(float min, float max)
		{
			return this.NextFloat() * (max - min) + min;
		}

		// Token: 0x06001E51 RID: 7761 RVA: 0x000580E1 File Offset: 0x000562E1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2 NextFloat2(float2 min, float2 max)
		{
			return this.NextFloat2() * (max - min) + min;
		}

		// Token: 0x06001E52 RID: 7762 RVA: 0x000580FB File Offset: 0x000562FB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3 NextFloat3(float3 min, float3 max)
		{
			return this.NextFloat3() * (max - min) + min;
		}

		// Token: 0x06001E53 RID: 7763 RVA: 0x00058115 File Offset: 0x00056315
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4 NextFloat4(float4 min, float4 max)
		{
			return this.NextFloat4() * (max - min) + min;
		}

		// Token: 0x06001E54 RID: 7764 RVA: 0x00058130 File Offset: 0x00056330
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double NextDouble()
		{
			ulong num = (ulong)this.NextState() << 20 ^ (ulong)this.NextState();
			return math.asdouble(4607182418800017408UL | num) - 1.0;
		}

		// Token: 0x06001E55 RID: 7765 RVA: 0x0005816C File Offset: 0x0005636C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2 NextDouble2()
		{
			ulong num = (ulong)this.NextState() << 20 ^ (ulong)this.NextState();
			ulong num2 = (ulong)this.NextState() << 20 ^ (ulong)this.NextState();
			return math.double2(math.asdouble(4607182418800017408UL | num), math.asdouble(4607182418800017408UL | num2)) - 1.0;
		}

		// Token: 0x06001E56 RID: 7766 RVA: 0x000581D4 File Offset: 0x000563D4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3 NextDouble3()
		{
			ulong num = (ulong)this.NextState() << 20 ^ (ulong)this.NextState();
			ulong num2 = (ulong)this.NextState() << 20 ^ (ulong)this.NextState();
			ulong num3 = (ulong)this.NextState() << 20 ^ (ulong)this.NextState();
			return math.double3(math.asdouble(4607182418800017408UL | num), math.asdouble(4607182418800017408UL | num2), math.asdouble(4607182418800017408UL | num3)) - 1.0;
		}

		// Token: 0x06001E57 RID: 7767 RVA: 0x00058260 File Offset: 0x00056460
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4 NextDouble4()
		{
			ulong num = (ulong)this.NextState() << 20 ^ (ulong)this.NextState();
			ulong num2 = (ulong)this.NextState() << 20 ^ (ulong)this.NextState();
			ulong num3 = (ulong)this.NextState() << 20 ^ (ulong)this.NextState();
			ulong num4 = (ulong)this.NextState() << 20 ^ (ulong)this.NextState();
			return math.double4(math.asdouble(4607182418800017408UL | num), math.asdouble(4607182418800017408UL | num2), math.asdouble(4607182418800017408UL | num3), math.asdouble(4607182418800017408UL | num4)) - 1.0;
		}

		// Token: 0x06001E58 RID: 7768 RVA: 0x0005830C File Offset: 0x0005650C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double NextDouble(double max)
		{
			return this.NextDouble() * max;
		}

		// Token: 0x06001E59 RID: 7769 RVA: 0x00058316 File Offset: 0x00056516
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2 NextDouble2(double2 max)
		{
			return this.NextDouble2() * max;
		}

		// Token: 0x06001E5A RID: 7770 RVA: 0x00058324 File Offset: 0x00056524
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3 NextDouble3(double3 max)
		{
			return this.NextDouble3() * max;
		}

		// Token: 0x06001E5B RID: 7771 RVA: 0x00058332 File Offset: 0x00056532
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4 NextDouble4(double4 max)
		{
			return this.NextDouble4() * max;
		}

		// Token: 0x06001E5C RID: 7772 RVA: 0x00058340 File Offset: 0x00056540
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double NextDouble(double min, double max)
		{
			return this.NextDouble() * (max - min) + min;
		}

		// Token: 0x06001E5D RID: 7773 RVA: 0x0005834E File Offset: 0x0005654E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2 NextDouble2(double2 min, double2 max)
		{
			return this.NextDouble2() * (max - min) + min;
		}

		// Token: 0x06001E5E RID: 7774 RVA: 0x00058368 File Offset: 0x00056568
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3 NextDouble3(double3 min, double3 max)
		{
			return this.NextDouble3() * (max - min) + min;
		}

		// Token: 0x06001E5F RID: 7775 RVA: 0x00058382 File Offset: 0x00056582
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4 NextDouble4(double4 min, double4 max)
		{
			return this.NextDouble4() * (max - min) + min;
		}

		// Token: 0x06001E60 RID: 7776 RVA: 0x0005839C File Offset: 0x0005659C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2 NextFloat2Direction()
		{
			float y;
			float x;
			math.sincos(this.NextFloat() * 3.1415927f * 2f, out y, out x);
			return math.float2(x, y);
		}

		// Token: 0x06001E61 RID: 7777 RVA: 0x000583CC File Offset: 0x000565CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2 NextDouble2Direction()
		{
			double y;
			double x;
			math.sincos(this.NextDouble() * 3.141592653589793 * 2.0, out y, out x);
			return math.double2(x, y);
		}

		// Token: 0x06001E62 RID: 7778 RVA: 0x00058404 File Offset: 0x00056604
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3 NextFloat3Direction()
		{
			float2 @float = this.NextFloat2();
			float num = @float.x * 2f - 1f;
			float num2 = math.sqrt(math.max(1f - num * num, 0f));
			float num3;
			float num4;
			math.sincos(@float.y * 3.1415927f * 2f, out num3, out num4);
			return math.float3(num4 * num2, num3 * num2, num);
		}

		// Token: 0x06001E63 RID: 7779 RVA: 0x0005846C File Offset: 0x0005666C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3 NextDouble3Direction()
		{
			double2 @double = this.NextDouble2();
			double num = @double.x * 2.0 - 1.0;
			double num2 = math.sqrt(math.max(1.0 - num * num, 0.0));
			double num3;
			double num4;
			math.sincos(@double.y * 3.141592653589793 * 2.0, out num3, out num4);
			return math.double3(num4 * num2, num3 * num2, num);
		}

		// Token: 0x06001E64 RID: 7780 RVA: 0x000584EC File Offset: 0x000566EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public quaternion NextQuaternionRotation()
		{
			float3 @float = this.NextFloat3(math.float3(6.2831855f, 6.2831855f, 1f));
			float z = @float.z;
			float2 xy = @float.xy;
			float num = math.sqrt(1f - z);
			float num2 = math.sqrt(z);
			float2 float2;
			float2 float3;
			math.sincos(xy, out float2, out float3);
			quaternion quaternion = math.quaternion(num * float2.x, num * float3.x, num2 * float2.y, num2 * float3.y);
			return math.quaternion(math.select(quaternion.value, -quaternion.value, quaternion.value.w < 0f));
		}

		// Token: 0x06001E65 RID: 7781 RVA: 0x0005859C File Offset: 0x0005679C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private uint NextState()
		{
			uint result = this.state;
			this.state ^= this.state << 13;
			this.state ^= this.state >> 17;
			this.state ^= this.state << 5;
			return result;
		}

		// Token: 0x06001E66 RID: 7782 RVA: 0x000585F0 File Offset: 0x000567F0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckInitState()
		{
		}

		// Token: 0x06001E67 RID: 7783 RVA: 0x000585F2 File Offset: 0x000567F2
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckIndexForHash(uint index)
		{
			if (index == 4294967295U)
			{
				throw new ArgumentException("Index must not be uint.MaxValue");
			}
		}

		// Token: 0x06001E68 RID: 7784 RVA: 0x00058603 File Offset: 0x00056803
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckState()
		{
		}

		// Token: 0x06001E69 RID: 7785 RVA: 0x00058605 File Offset: 0x00056805
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckNextIntMax(int max)
		{
		}

		// Token: 0x06001E6A RID: 7786 RVA: 0x00058607 File Offset: 0x00056807
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckNextIntMinMax(int min, int max)
		{
		}

		// Token: 0x06001E6B RID: 7787 RVA: 0x00058609 File Offset: 0x00056809
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckNextUIntMinMax(uint min, uint max)
		{
		}

		// Token: 0x040000E4 RID: 228
		public uint state;
	}
}
