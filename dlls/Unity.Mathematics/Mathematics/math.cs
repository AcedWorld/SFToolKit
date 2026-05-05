using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000005 RID: 5
	[Il2CppEagerStaticClassConstruction]
	public static class math
	{
		// Token: 0x0600003C RID: 60 RVA: 0x000026B0 File Offset: 0x000008B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 bool2(bool x, bool y)
		{
			return new bool2(x, y);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000026B9 File Offset: 0x000008B9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 bool2(bool2 xy)
		{
			return new bool2(xy);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000026C1 File Offset: 0x000008C1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 bool2(bool v)
		{
			return new bool2(v);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000026C9 File Offset: 0x000008C9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(bool2 v)
		{
			return math.csum(math.select(math.uint2(2426570171U, 1561977301U), math.uint2(4205774813U, 1650214333U), v));
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000026F4 File Offset: 0x000008F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(bool2 v)
		{
			return math.select(math.uint2(3388112843U, 1831150513U), math.uint2(1848374953U, 3430200247U), v);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000271A File Offset: 0x0000091A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool shuffle(bool2 left, bool2 right, math.ShuffleComponent x)
		{
			return math.select_shuffle_component(left, right, x);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002724 File Offset: 0x00000924
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 shuffle(bool2 left, bool2 right, math.ShuffleComponent x, math.ShuffleComponent y)
		{
			return math.bool2(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y));
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000273B File Offset: 0x0000093B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 shuffle(bool2 left, bool2 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
		{
			return math.bool3(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z));
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000275B File Offset: 0x0000095B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 shuffle(bool2 left, bool2 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
		{
			return math.bool4(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z), math.select_shuffle_component(left, right, w));
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002784 File Offset: 0x00000984
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool select_shuffle_component(bool2 a, bool2 b, math.ShuffleComponent component)
		{
			switch (component)
			{
			case math.ShuffleComponent.LeftX:
				return a.x;
			case math.ShuffleComponent.LeftY:
				return a.y;
			case math.ShuffleComponent.RightX:
				return b.x;
			case math.ShuffleComponent.RightY:
				return b.y;
			}
			throw new ArgumentException("Invalid shuffle component: " + component.ToString());
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000027E9 File Offset: 0x000009E9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 bool2x2(bool2 c0, bool2 c1)
		{
			return new bool2x2(c0, c1);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000027F2 File Offset: 0x000009F2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 bool2x2(bool m00, bool m01, bool m10, bool m11)
		{
			return new bool2x2(m00, m01, m10, m11);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000027FD File Offset: 0x000009FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 bool2x2(bool v)
		{
			return new bool2x2(v);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002805 File Offset: 0x00000A05
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 transpose(bool2x2 v)
		{
			return math.bool2x2(v.c0.x, v.c0.y, v.c1.x, v.c1.y);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002838 File Offset: 0x00000A38
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(bool2x2 v)
		{
			return math.csum(math.select(math.uint2(2062756937U, 2920485769U), math.uint2(1562056283U, 2265541847U), v.c0) + math.select(math.uint2(1283419601U, 1210229737U), math.uint2(2864955997U, 3525118277U), v.c1));
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000028A4 File Offset: 0x00000AA4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(bool2x2 v)
		{
			return math.select(math.uint2(2298260269U, 1632478733U), math.uint2(1537393931U, 2353355467U), v.c0) + math.select(math.uint2(3441847433U, 4052036147U), math.uint2(2011389559U, 2252224297U), v.c1);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002908 File Offset: 0x00000B08
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 bool2x3(bool2 c0, bool2 c1, bool2 c2)
		{
			return new bool2x3(c0, c1, c2);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002912 File Offset: 0x00000B12
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 bool2x3(bool m00, bool m01, bool m02, bool m10, bool m11, bool m12)
		{
			return new bool2x3(m00, m01, m02, m10, m11, m12);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002921 File Offset: 0x00000B21
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 bool2x3(bool v)
		{
			return new bool2x3(v);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000292C File Offset: 0x00000B2C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 transpose(bool2x3 v)
		{
			return math.bool3x2(v.c0.x, v.c0.y, v.c1.x, v.c1.y, v.c2.x, v.c2.y);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002980 File Offset: 0x00000B80
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(bool2x3 v)
		{
			return math.csum(math.select(math.uint2(2078515003U, 4206465343U), math.uint2(3025146473U, 3763046909U), v.c0) + math.select(math.uint2(3678265601U, 2070747979U), math.uint2(1480171127U, 1588341193U), v.c1) + math.select(math.uint2(4234155257U, 1811310911U), math.uint2(2635799963U, 4165137857U), v.c2));
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002A18 File Offset: 0x00000C18
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(bool2x3 v)
		{
			return math.select(math.uint2(2759770933U, 2759319383U), math.uint2(3299952959U, 3121178323U), v.c0) + math.select(math.uint2(2948522579U, 1531026433U), math.uint2(1365086453U, 3969870067U), v.c1) + math.select(math.uint2(4192899797U, 3271228601U), math.uint2(1634639009U, 3318036811U), v.c2);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002AAA File Offset: 0x00000CAA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 bool2x4(bool2 c0, bool2 c1, bool2 c2, bool2 c3)
		{
			return new bool2x4(c0, c1, c2, c3);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002AB5 File Offset: 0x00000CB5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 bool2x4(bool m00, bool m01, bool m02, bool m03, bool m10, bool m11, bool m12, bool m13)
		{
			return new bool2x4(m00, m01, m02, m03, m10, m11, m12, m13);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002AC8 File Offset: 0x00000CC8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 bool2x4(bool v)
		{
			return new bool2x4(v);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002AD0 File Offset: 0x00000CD0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 transpose(bool2x4 v)
		{
			return math.bool4x2(v.c0.x, v.c0.y, v.c1.x, v.c1.y, v.c2.x, v.c2.y, v.c3.x, v.c3.y);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002B3C File Offset: 0x00000D3C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(bool2x4 v)
		{
			return math.csum(math.select(math.uint2(1168253063U, 4228926523U), math.uint2(1610574617U, 1584185147U), v.c0) + math.select(math.uint2(3041325733U, 3150930919U), math.uint2(3309258581U, 1770373673U), v.c1) + math.select(math.uint2(3778261171U, 3286279097U), math.uint2(4264629071U, 1898591447U), v.c2) + math.select(math.uint2(2641864091U, 1229113913U), math.uint2(3020867117U, 1449055807U), v.c3));
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002C04 File Offset: 0x00000E04
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(bool2x4 v)
		{
			return math.select(math.uint2(2479033387U, 3702457169U), math.uint2(1845824257U, 1963973621U), v.c0) + math.select(math.uint2(2134758553U, 1391111867U), math.uint2(1167706003U, 2209736489U), v.c1) + math.select(math.uint2(3261535807U, 1740411209U), math.uint2(2910609089U, 2183822701U), v.c2) + math.select(math.uint2(3029516053U, 3547472099U), math.uint2(2057487037U, 3781937309U), v.c3);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002CC4 File Offset: 0x00000EC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 bool3(bool x, bool y, bool z)
		{
			return new bool3(x, y, z);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002CCE File Offset: 0x00000ECE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 bool3(bool x, bool2 yz)
		{
			return new bool3(x, yz);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002CD7 File Offset: 0x00000ED7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 bool3(bool2 xy, bool z)
		{
			return new bool3(xy, z);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00002CE0 File Offset: 0x00000EE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 bool3(bool3 xyz)
		{
			return new bool3(xyz);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002CE8 File Offset: 0x00000EE8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 bool3(bool v)
		{
			return new bool3(v);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00002CF0 File Offset: 0x00000EF0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(bool3 v)
		{
			return math.csum(math.select(math.uint3(2716413241U, 1166264321U, 2503385333U), math.uint3(2944493077U, 2599999021U, 3814721321U), v));
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002D25 File Offset: 0x00000F25
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(bool3 v)
		{
			return math.select(math.uint3(1595355149U, 1728931849U, 2062756937U), math.uint3(2920485769U, 1562056283U, 2265541847U), v);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002D55 File Offset: 0x00000F55
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool shuffle(bool3 left, bool3 right, math.ShuffleComponent x)
		{
			return math.select_shuffle_component(left, right, x);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00002D5F File Offset: 0x00000F5F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 shuffle(bool3 left, bool3 right, math.ShuffleComponent x, math.ShuffleComponent y)
		{
			return math.bool2(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y));
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00002D76 File Offset: 0x00000F76
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 shuffle(bool3 left, bool3 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
		{
			return math.bool3(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z));
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00002D96 File Offset: 0x00000F96
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 shuffle(bool3 left, bool3 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
		{
			return math.bool4(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z), math.select_shuffle_component(left, right, w));
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002DC0 File Offset: 0x00000FC0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool select_shuffle_component(bool3 a, bool3 b, math.ShuffleComponent component)
		{
			switch (component)
			{
			case math.ShuffleComponent.LeftX:
				return a.x;
			case math.ShuffleComponent.LeftY:
				return a.y;
			case math.ShuffleComponent.LeftZ:
				return a.z;
			case math.ShuffleComponent.RightX:
				return b.x;
			case math.ShuffleComponent.RightY:
				return b.y;
			case math.ShuffleComponent.RightZ:
				return b.z;
			}
			throw new ArgumentException("Invalid shuffle component: " + component.ToString());
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002E37 File Offset: 0x00001037
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 bool3x2(bool3 c0, bool3 c1)
		{
			return new bool3x2(c0, c1);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00002E40 File Offset: 0x00001040
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 bool3x2(bool m00, bool m01, bool m10, bool m11, bool m20, bool m21)
		{
			return new bool3x2(m00, m01, m10, m11, m20, m21);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00002E4F File Offset: 0x0000104F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 bool3x2(bool v)
		{
			return new bool3x2(v);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00002E58 File Offset: 0x00001058
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 transpose(bool3x2 v)
		{
			return math.bool2x3(v.c0.x, v.c0.y, v.c0.z, v.c1.x, v.c1.y, v.c1.z);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002EAC File Offset: 0x000010AC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(bool3x2 v)
		{
			return math.csum(math.select(math.uint3(2627668003U, 1520214331U, 2949502447U), math.uint3(2827819133U, 3480140317U, 2642994593U), v.c0) + math.select(math.uint3(3940484981U, 1954192763U, 1091696537U), math.uint3(3052428017U, 4253034763U, 2338696631U), v.c1));
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002F2C File Offset: 0x0000112C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(bool3x2 v)
		{
			return math.select(math.uint3(3757372771U, 1885959949U, 3508684087U), math.uint3(3919501043U, 1209161033U, 4007793211U), v.c0) + math.select(math.uint3(3819806693U, 3458005183U, 2078515003U), math.uint3(4206465343U, 3025146473U, 3763046909U), v.c1);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002FA4 File Offset: 0x000011A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 bool3x3(bool3 c0, bool3 c1, bool3 c2)
		{
			return new bool3x3(c0, c1, c2);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002FB0 File Offset: 0x000011B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 bool3x3(bool m00, bool m01, bool m02, bool m10, bool m11, bool m12, bool m20, bool m21, bool m22)
		{
			return new bool3x3(m00, m01, m02, m10, m11, m12, m20, m21, m22);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00002FD0 File Offset: 0x000011D0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 bool3x3(bool v)
		{
			return new bool3x3(v);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002FD8 File Offset: 0x000011D8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 transpose(bool3x3 v)
		{
			return math.bool3x3(v.c0.x, v.c0.y, v.c0.z, v.c1.x, v.c1.y, v.c1.z, v.c2.x, v.c2.y, v.c2.z);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003050 File Offset: 0x00001250
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(bool3x3 v)
		{
			return math.csum(math.select(math.uint3(3881277847U, 4017968839U, 1727237899U), math.uint3(1648514723U, 1385344481U, 3538260197U), v.c0) + math.select(math.uint3(4066109527U, 2613148903U, 3367528529U), math.uint3(1678332449U, 2918459647U, 2744611081U), v.c1) + math.select(math.uint3(1952372791U, 2631698677U, 4200781601U), math.uint3(2119021007U, 1760485621U, 3157985881U), v.c2));
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003108 File Offset: 0x00001308
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(bool3x3 v)
		{
			return math.select(math.uint3(2171534173U, 2723054263U, 1168253063U), math.uint3(4228926523U, 1610574617U, 1584185147U), v.c0) + math.select(math.uint3(3041325733U, 3150930919U, 3309258581U), math.uint3(1770373673U, 3778261171U, 3286279097U), v.c1) + math.select(math.uint3(4264629071U, 1898591447U, 2641864091U), math.uint3(1229113913U, 3020867117U, 1449055807U), v.c2);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000031B8 File Offset: 0x000013B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 bool3x4(bool3 c0, bool3 c1, bool3 c2, bool3 c3)
		{
			return new bool3x4(c0, c1, c2, c3);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000031C4 File Offset: 0x000013C4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 bool3x4(bool m00, bool m01, bool m02, bool m03, bool m10, bool m11, bool m12, bool m13, bool m20, bool m21, bool m22, bool m23)
		{
			return new bool3x4(m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000031EA File Offset: 0x000013EA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 bool3x4(bool v)
		{
			return new bool3x4(v);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000031F4 File Offset: 0x000013F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 transpose(bool3x4 v)
		{
			return math.bool4x3(v.c0.x, v.c0.y, v.c0.z, v.c1.x, v.c1.y, v.c1.z, v.c2.x, v.c2.y, v.c2.z, v.c3.x, v.c3.y, v.c3.z);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000328C File Offset: 0x0000148C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(bool3x4 v)
		{
			return math.csum(math.select(math.uint3(2209710647U, 2201894441U, 2849577407U), math.uint3(3287031191U, 3098675399U, 1564399943U), v.c0) + math.select(math.uint3(1148435377U, 3416333663U, 1750611407U), math.uint3(3285396193U, 3110507567U, 4271396531U), v.c1) + math.select(math.uint3(4198118021U, 2908068253U, 3705492289U), math.uint3(2497566569U, 2716413241U, 1166264321U), v.c2) + math.select(math.uint3(2503385333U, 2944493077U, 2599999021U), math.uint3(3814721321U, 1595355149U, 1728931849U), v.c3));
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000337C File Offset: 0x0000157C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(bool3x4 v)
		{
			return math.select(math.uint3(2062756937U, 2920485769U, 1562056283U), math.uint3(2265541847U, 1283419601U, 1210229737U), v.c0) + math.select(math.uint3(2864955997U, 3525118277U, 2298260269U), math.uint3(1632478733U, 1537393931U, 2353355467U), v.c1) + math.select(math.uint3(3441847433U, 4052036147U, 2011389559U), math.uint3(2252224297U, 3784421429U, 1750626223U), v.c2) + math.select(math.uint3(3571447507U, 3412283213U, 2601761069U), math.uint3(1254033427U, 2248573027U, 3612677113U), v.c3);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003464 File Offset: 0x00001664
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 bool4(bool x, bool y, bool z, bool w)
		{
			return new bool4(x, y, z, w);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000346F File Offset: 0x0000166F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 bool4(bool x, bool y, bool2 zw)
		{
			return new bool4(x, y, zw);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003479 File Offset: 0x00001679
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 bool4(bool x, bool2 yz, bool w)
		{
			return new bool4(x, yz, w);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003483 File Offset: 0x00001683
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 bool4(bool x, bool3 yzw)
		{
			return new bool4(x, yzw);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000348C File Offset: 0x0000168C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 bool4(bool2 xy, bool z, bool w)
		{
			return new bool4(xy, z, w);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003496 File Offset: 0x00001696
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 bool4(bool2 xy, bool2 zw)
		{
			return new bool4(xy, zw);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x0000349F File Offset: 0x0000169F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 bool4(bool3 xyz, bool w)
		{
			return new bool4(xyz, w);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000034A8 File Offset: 0x000016A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 bool4(bool4 xyzw)
		{
			return new bool4(xyzw);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000034B0 File Offset: 0x000016B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 bool4(bool v)
		{
			return new bool4(v);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000034B8 File Offset: 0x000016B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(bool4 v)
		{
			return math.csum(math.select(math.uint4(1610574617U, 1584185147U, 3041325733U, 3150930919U), math.uint4(3309258581U, 1770373673U, 3778261171U, 3286279097U), v));
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000034F7 File Offset: 0x000016F7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(bool4 v)
		{
			return math.select(math.uint4(4264629071U, 1898591447U, 2641864091U, 1229113913U), math.uint4(3020867117U, 1449055807U, 2479033387U, 3702457169U), v);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00003531 File Offset: 0x00001731
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool shuffle(bool4 left, bool4 right, math.ShuffleComponent x)
		{
			return math.select_shuffle_component(left, right, x);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000353B File Offset: 0x0000173B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 shuffle(bool4 left, bool4 right, math.ShuffleComponent x, math.ShuffleComponent y)
		{
			return math.bool2(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y));
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003552 File Offset: 0x00001752
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 shuffle(bool4 left, bool4 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
		{
			return math.bool3(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z));
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003572 File Offset: 0x00001772
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 shuffle(bool4 left, bool4 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
		{
			return math.bool4(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z), math.select_shuffle_component(left, right, w));
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000359C File Offset: 0x0000179C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool select_shuffle_component(bool4 a, bool4 b, math.ShuffleComponent component)
		{
			switch (component)
			{
			case math.ShuffleComponent.LeftX:
				return a.x;
			case math.ShuffleComponent.LeftY:
				return a.y;
			case math.ShuffleComponent.LeftZ:
				return a.z;
			case math.ShuffleComponent.LeftW:
				return a.w;
			case math.ShuffleComponent.RightX:
				return b.x;
			case math.ShuffleComponent.RightY:
				return b.y;
			case math.ShuffleComponent.RightZ:
				return b.z;
			case math.ShuffleComponent.RightW:
				return b.w;
			default:
				throw new ArgumentException("Invalid shuffle component: " + component.ToString());
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003625 File Offset: 0x00001825
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 bool4x2(bool4 c0, bool4 c1)
		{
			return new bool4x2(c0, c1);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000362E File Offset: 0x0000182E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 bool4x2(bool m00, bool m01, bool m10, bool m11, bool m20, bool m21, bool m30, bool m31)
		{
			return new bool4x2(m00, m01, m10, m11, m20, m21, m30, m31);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00003641 File Offset: 0x00001841
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 bool4x2(bool v)
		{
			return new bool4x2(v);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000364C File Offset: 0x0000184C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 transpose(bool4x2 v)
		{
			return math.bool2x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w, v.c1.x, v.c1.y, v.c1.z, v.c1.w);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000036B8 File Offset: 0x000018B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(bool4x2 v)
		{
			return math.csum(math.select(math.uint4(3516359879U, 3050356579U, 4178586719U, 2558655391U), math.uint4(1453413133U, 2152428077U, 1938706661U, 1338588197U), v.c0) + math.select(math.uint4(3439609253U, 3535343003U, 3546061613U, 2702024231U), math.uint4(1452124841U, 1966089551U, 2668168249U, 1587512777U), v.c1));
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000374C File Offset: 0x0000194C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(bool4x2 v)
		{
			return math.select(math.uint4(2353831999U, 3101256173U, 2891822459U, 2837054189U), math.uint4(3016004371U, 4097481403U, 2229788699U, 2382715877U), v.c0) + math.select(math.uint4(1851936439U, 1938025801U, 3712598587U, 3956330501U), math.uint4(2437373431U, 1441286183U, 2426570171U, 1561977301U), v.c1);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000037D8 File Offset: 0x000019D8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 bool4x3(bool4 c0, bool4 c1, bool4 c2)
		{
			return new bool4x3(c0, c1, c2);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000037E4 File Offset: 0x000019E4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 bool4x3(bool m00, bool m01, bool m02, bool m10, bool m11, bool m12, bool m20, bool m21, bool m22, bool m30, bool m31, bool m32)
		{
			return new bool4x3(m00, m01, m02, m10, m11, m12, m20, m21, m22, m30, m31, m32);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000380A File Offset: 0x00001A0A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 bool4x3(bool v)
		{
			return new bool4x3(v);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003814 File Offset: 0x00001A14
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 transpose(bool4x3 v)
		{
			return math.bool3x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w, v.c1.x, v.c1.y, v.c1.z, v.c1.w, v.c2.x, v.c2.y, v.c2.z, v.c2.w);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000038AC File Offset: 0x00001AAC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(bool4x3 v)
		{
			return math.csum(math.select(math.uint4(3940484981U, 1954192763U, 1091696537U, 3052428017U), math.uint4(4253034763U, 2338696631U, 3757372771U, 1885959949U), v.c0) + math.select(math.uint4(3508684087U, 3919501043U, 1209161033U, 4007793211U), math.uint4(3819806693U, 3458005183U, 2078515003U, 4206465343U), v.c1) + math.select(math.uint4(3025146473U, 3763046909U, 3678265601U, 2070747979U), math.uint4(1480171127U, 1588341193U, 4234155257U, 1811310911U), v.c2));
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00003980 File Offset: 0x00001B80
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(bool4x3 v)
		{
			return math.select(math.uint4(2635799963U, 4165137857U, 2759770933U, 2759319383U), math.uint4(3299952959U, 3121178323U, 2948522579U, 1531026433U), v.c0) + math.select(math.uint4(1365086453U, 3969870067U, 4192899797U, 3271228601U), math.uint4(1634639009U, 3318036811U, 3404170631U, 2048213449U), v.c1) + math.select(math.uint4(4164671783U, 1780759499U, 1352369353U, 2446407751U), math.uint4(1391928079U, 3475533443U, 3777095341U, 3385463369U), v.c2);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003A4E File Offset: 0x00001C4E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 bool4x4(bool4 c0, bool4 c1, bool4 c2, bool4 c3)
		{
			return new bool4x4(c0, c1, c2, c3);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003A5C File Offset: 0x00001C5C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 bool4x4(bool m00, bool m01, bool m02, bool m03, bool m10, bool m11, bool m12, bool m13, bool m20, bool m21, bool m22, bool m23, bool m30, bool m31, bool m32, bool m33)
		{
			return new bool4x4(m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00003A8A File Offset: 0x00001C8A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 bool4x4(bool v)
		{
			return new bool4x4(v);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00003A94 File Offset: 0x00001C94
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 transpose(bool4x4 v)
		{
			return math.bool4x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w, v.c1.x, v.c1.y, v.c1.z, v.c1.w, v.c2.x, v.c2.y, v.c2.z, v.c2.w, v.c3.x, v.c3.y, v.c3.z, v.c3.w);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003B58 File Offset: 0x00001D58
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(bool4x4 v)
		{
			return math.csum(math.select(math.uint4(3516359879U, 3050356579U, 4178586719U, 2558655391U), math.uint4(1453413133U, 2152428077U, 1938706661U, 1338588197U), v.c0) + math.select(math.uint4(3439609253U, 3535343003U, 3546061613U, 2702024231U), math.uint4(1452124841U, 1966089551U, 2668168249U, 1587512777U), v.c1) + math.select(math.uint4(2353831999U, 3101256173U, 2891822459U, 2837054189U), math.uint4(3016004371U, 4097481403U, 2229788699U, 2382715877U), v.c2) + math.select(math.uint4(1851936439U, 1938025801U, 3712598587U, 3956330501U), math.uint4(2437373431U, 1441286183U, 2426570171U, 1561977301U), v.c3));
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003C70 File Offset: 0x00001E70
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(bool4x4 v)
		{
			return math.select(math.uint4(4205774813U, 1650214333U, 3388112843U, 1831150513U), math.uint4(1848374953U, 3430200247U, 2209710647U, 2201894441U), v.c0) + math.select(math.uint4(2849577407U, 3287031191U, 3098675399U, 1564399943U), math.uint4(1148435377U, 3416333663U, 1750611407U, 3285396193U), v.c1) + math.select(math.uint4(3110507567U, 4271396531U, 4198118021U, 2908068253U), math.uint4(3705492289U, 2497566569U, 2716413241U, 1166264321U), v.c2) + math.select(math.uint4(2503385333U, 2944493077U, 2599999021U, 3814721321U), math.uint4(1595355149U, 1728931849U, 2062756937U, 2920485769U), v.c3);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00003D80 File Offset: 0x00001F80
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 double2(double x, double y)
		{
			return new double2(x, y);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003D89 File Offset: 0x00001F89
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 double2(double2 xy)
		{
			return new double2(xy);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00003D91 File Offset: 0x00001F91
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 double2(double v)
		{
			return new double2(v);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00003D99 File Offset: 0x00001F99
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 double2(bool v)
		{
			return new double2(v);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00003DA1 File Offset: 0x00001FA1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 double2(bool2 v)
		{
			return new double2(v);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00003DA9 File Offset: 0x00001FA9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 double2(int v)
		{
			return new double2(v);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003DB1 File Offset: 0x00001FB1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 double2(int2 v)
		{
			return new double2(v);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00003DB9 File Offset: 0x00001FB9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 double2(uint v)
		{
			return new double2(v);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003DC1 File Offset: 0x00001FC1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 double2(uint2 v)
		{
			return new double2(v);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00003DC9 File Offset: 0x00001FC9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 double2(half v)
		{
			return new double2(v);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00003DD1 File Offset: 0x00001FD1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 double2(half2 v)
		{
			return new double2(v);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00003DD9 File Offset: 0x00001FD9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 double2(float v)
		{
			return new double2(v);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00003DE1 File Offset: 0x00001FE1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 double2(float2 v)
		{
			return new double2(v);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003DE9 File Offset: 0x00001FE9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(double2 v)
		{
			return math.csum(math.fold_to_uint(v) * math.uint2(2503385333U, 2944493077U)) + 2599999021U;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00003E10 File Offset: 0x00002010
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(double2 v)
		{
			return math.fold_to_uint(v) * math.uint2(3814721321U, 1595355149U) + 1728931849U;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003E36 File Offset: 0x00002036
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double shuffle(double2 left, double2 right, math.ShuffleComponent x)
		{
			return math.select_shuffle_component(left, right, x);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003E40 File Offset: 0x00002040
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 shuffle(double2 left, double2 right, math.ShuffleComponent x, math.ShuffleComponent y)
		{
			return math.double2(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y));
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003E57 File Offset: 0x00002057
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 shuffle(double2 left, double2 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
		{
			return math.double3(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z));
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00003E77 File Offset: 0x00002077
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 shuffle(double2 left, double2 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
		{
			return math.double4(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z), math.select_shuffle_component(left, right, w));
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00003EA0 File Offset: 0x000020A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static double select_shuffle_component(double2 a, double2 b, math.ShuffleComponent component)
		{
			switch (component)
			{
			case math.ShuffleComponent.LeftX:
				return a.x;
			case math.ShuffleComponent.LeftY:
				return a.y;
			case math.ShuffleComponent.RightX:
				return b.x;
			case math.ShuffleComponent.RightY:
				return b.y;
			}
			throw new ArgumentException("Invalid shuffle component: " + component.ToString());
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00003F05 File Offset: 0x00002105
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x2 double2x2(double2 c0, double2 c1)
		{
			return new double2x2(c0, c1);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00003F0E File Offset: 0x0000210E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x2 double2x2(double m00, double m01, double m10, double m11)
		{
			return new double2x2(m00, m01, m10, m11);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00003F19 File Offset: 0x00002119
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x2 double2x2(double v)
		{
			return new double2x2(v);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00003F21 File Offset: 0x00002121
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x2 double2x2(bool v)
		{
			return new double2x2(v);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00003F29 File Offset: 0x00002129
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x2 double2x2(bool2x2 v)
		{
			return new double2x2(v);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00003F31 File Offset: 0x00002131
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x2 double2x2(int v)
		{
			return new double2x2(v);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00003F39 File Offset: 0x00002139
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x2 double2x2(int2x2 v)
		{
			return new double2x2(v);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00003F41 File Offset: 0x00002141
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x2 double2x2(uint v)
		{
			return new double2x2(v);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00003F49 File Offset: 0x00002149
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x2 double2x2(uint2x2 v)
		{
			return new double2x2(v);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00003F51 File Offset: 0x00002151
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x2 double2x2(float v)
		{
			return new double2x2(v);
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00003F59 File Offset: 0x00002159
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x2 double2x2(float2x2 v)
		{
			return new double2x2(v);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00003F61 File Offset: 0x00002161
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x2 transpose(double2x2 v)
		{
			return math.double2x2(v.c0.x, v.c0.y, v.c1.x, v.c1.y);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00003F94 File Offset: 0x00002194
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x2 inverse(double2x2 m)
		{
			double x = m.c0.x;
			double x2 = m.c1.x;
			double y = m.c0.y;
			double y2 = m.c1.y;
			double num = x * y2 - x2 * y;
			return math.double2x2(y2, -x2, -y, x) * (1.0 / num);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00003FF8 File Offset: 0x000021F8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double determinant(double2x2 m)
		{
			double x = m.c0.x;
			double x2 = m.c1.x;
			double y = m.c0.y;
			double y2 = m.c1.y;
			return x * y2 - x2 * y;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000403C File Offset: 0x0000223C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(double2x2 v)
		{
			return math.csum(math.fold_to_uint(v.c0) * math.uint2(4253034763U, 2338696631U) + math.fold_to_uint(v.c1) * math.uint2(3757372771U, 1885959949U)) + 3508684087U;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00004098 File Offset: 0x00002298
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(double2x2 v)
		{
			return math.fold_to_uint(v.c0) * math.uint2(3919501043U, 1209161033U) + math.fold_to_uint(v.c1) * math.uint2(4007793211U, 3819806693U) + 3458005183U;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x000040F2 File Offset: 0x000022F2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 double2x3(double2 c0, double2 c1, double2 c2)
		{
			return new double2x3(c0, c1, c2);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000040FC File Offset: 0x000022FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 double2x3(double m00, double m01, double m02, double m10, double m11, double m12)
		{
			return new double2x3(m00, m01, m02, m10, m11, m12);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000410B File Offset: 0x0000230B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 double2x3(double v)
		{
			return new double2x3(v);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00004113 File Offset: 0x00002313
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 double2x3(bool v)
		{
			return new double2x3(v);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000411B File Offset: 0x0000231B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 double2x3(bool2x3 v)
		{
			return new double2x3(v);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00004123 File Offset: 0x00002323
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 double2x3(int v)
		{
			return new double2x3(v);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000412B File Offset: 0x0000232B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 double2x3(int2x3 v)
		{
			return new double2x3(v);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00004133 File Offset: 0x00002333
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 double2x3(uint v)
		{
			return new double2x3(v);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000413B File Offset: 0x0000233B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 double2x3(uint2x3 v)
		{
			return new double2x3(v);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00004143 File Offset: 0x00002343
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 double2x3(float v)
		{
			return new double2x3(v);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000414B File Offset: 0x0000234B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 double2x3(float2x3 v)
		{
			return new double2x3(v);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00004154 File Offset: 0x00002354
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 transpose(double2x3 v)
		{
			return math.double3x2(v.c0.x, v.c0.y, v.c1.x, v.c1.y, v.c2.x, v.c2.y);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000041A8 File Offset: 0x000023A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(double2x3 v)
		{
			return math.csum(math.fold_to_uint(v.c0) * math.uint2(4066109527U, 2613148903U) + math.fold_to_uint(v.c1) * math.uint2(3367528529U, 1678332449U) + math.fold_to_uint(v.c2) * math.uint2(2918459647U, 2744611081U)) + 1952372791U;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00004228 File Offset: 0x00002428
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(double2x3 v)
		{
			return math.fold_to_uint(v.c0) * math.uint2(2631698677U, 4200781601U) + math.fold_to_uint(v.c1) * math.uint2(2119021007U, 1760485621U) + math.fold_to_uint(v.c2) * math.uint2(3157985881U, 2171534173U) + 2723054263U;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000042A6 File Offset: 0x000024A6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 double2x4(double2 c0, double2 c1, double2 c2, double2 c3)
		{
			return new double2x4(c0, c1, c2, c3);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000042B1 File Offset: 0x000024B1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 double2x4(double m00, double m01, double m02, double m03, double m10, double m11, double m12, double m13)
		{
			return new double2x4(m00, m01, m02, m03, m10, m11, m12, m13);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000042C4 File Offset: 0x000024C4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 double2x4(double v)
		{
			return new double2x4(v);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000042CC File Offset: 0x000024CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 double2x4(bool v)
		{
			return new double2x4(v);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x000042D4 File Offset: 0x000024D4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 double2x4(bool2x4 v)
		{
			return new double2x4(v);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x000042DC File Offset: 0x000024DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 double2x4(int v)
		{
			return new double2x4(v);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000042E4 File Offset: 0x000024E4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 double2x4(int2x4 v)
		{
			return new double2x4(v);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000042EC File Offset: 0x000024EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 double2x4(uint v)
		{
			return new double2x4(v);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000042F4 File Offset: 0x000024F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 double2x4(uint2x4 v)
		{
			return new double2x4(v);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000042FC File Offset: 0x000024FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 double2x4(float v)
		{
			return new double2x4(v);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00004304 File Offset: 0x00002504
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 double2x4(float2x4 v)
		{
			return new double2x4(v);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000430C File Offset: 0x0000250C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 transpose(double2x4 v)
		{
			return math.double4x2(v.c0.x, v.c0.y, v.c1.x, v.c1.y, v.c2.x, v.c2.y, v.c3.x, v.c3.y);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00004378 File Offset: 0x00002578
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(double2x4 v)
		{
			return math.csum(math.fold_to_uint(v.c0) * math.uint2(2437373431U, 1441286183U) + math.fold_to_uint(v.c1) * math.uint2(2426570171U, 1561977301U) + math.fold_to_uint(v.c2) * math.uint2(4205774813U, 1650214333U) + math.fold_to_uint(v.c3) * math.uint2(3388112843U, 1831150513U)) + 1848374953U;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000441C File Offset: 0x0000261C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(double2x4 v)
		{
			return math.fold_to_uint(v.c0) * math.uint2(3430200247U, 2209710647U) + math.fold_to_uint(v.c1) * math.uint2(2201894441U, 2849577407U) + math.fold_to_uint(v.c2) * math.uint2(3287031191U, 3098675399U) + math.fold_to_uint(v.c3) * math.uint2(1564399943U, 1148435377U) + 3416333663U;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000044BE File Offset: 0x000026BE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 double3(double x, double y, double z)
		{
			return new double3(x, y, z);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000044C8 File Offset: 0x000026C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 double3(double x, double2 yz)
		{
			return new double3(x, yz);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000044D1 File Offset: 0x000026D1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 double3(double2 xy, double z)
		{
			return new double3(xy, z);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000044DA File Offset: 0x000026DA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 double3(double3 xyz)
		{
			return new double3(xyz);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000044E2 File Offset: 0x000026E2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 double3(double v)
		{
			return new double3(v);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000044EA File Offset: 0x000026EA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 double3(bool v)
		{
			return new double3(v);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000044F2 File Offset: 0x000026F2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 double3(bool3 v)
		{
			return new double3(v);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000044FA File Offset: 0x000026FA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 double3(int v)
		{
			return new double3(v);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00004502 File Offset: 0x00002702
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 double3(int3 v)
		{
			return new double3(v);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000450A File Offset: 0x0000270A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 double3(uint v)
		{
			return new double3(v);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00004512 File Offset: 0x00002712
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 double3(uint3 v)
		{
			return new double3(v);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000451A File Offset: 0x0000271A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 double3(half v)
		{
			return new double3(v);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00004522 File Offset: 0x00002722
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 double3(half3 v)
		{
			return new double3(v);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000452A File Offset: 0x0000272A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 double3(float v)
		{
			return new double3(v);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00004532 File Offset: 0x00002732
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 double3(float3 v)
		{
			return new double3(v);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000453A File Offset: 0x0000273A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(double3 v)
		{
			return math.csum(math.fold_to_uint(v) * math.uint3(2937008387U, 3835713223U, 2216526373U)) + 3375971453U;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00004566 File Offset: 0x00002766
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(double3 v)
		{
			return math.fold_to_uint(v) * math.uint3(3559829411U, 3652178029U, 2544260129U) + 2013864031U;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00004591 File Offset: 0x00002791
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double shuffle(double3 left, double3 right, math.ShuffleComponent x)
		{
			return math.select_shuffle_component(left, right, x);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000459B File Offset: 0x0000279B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 shuffle(double3 left, double3 right, math.ShuffleComponent x, math.ShuffleComponent y)
		{
			return math.double2(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y));
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000045B2 File Offset: 0x000027B2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 shuffle(double3 left, double3 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
		{
			return math.double3(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z));
		}

		// Token: 0x060000EC RID: 236 RVA: 0x000045D2 File Offset: 0x000027D2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 shuffle(double3 left, double3 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
		{
			return math.double4(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z), math.select_shuffle_component(left, right, w));
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000045FC File Offset: 0x000027FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static double select_shuffle_component(double3 a, double3 b, math.ShuffleComponent component)
		{
			switch (component)
			{
			case math.ShuffleComponent.LeftX:
				return a.x;
			case math.ShuffleComponent.LeftY:
				return a.y;
			case math.ShuffleComponent.LeftZ:
				return a.z;
			case math.ShuffleComponent.RightX:
				return b.x;
			case math.ShuffleComponent.RightY:
				return b.y;
			case math.ShuffleComponent.RightZ:
				return b.z;
			}
			throw new ArgumentException("Invalid shuffle component: " + component.ToString());
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00004673 File Offset: 0x00002873
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 double3x2(double3 c0, double3 c1)
		{
			return new double3x2(c0, c1);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000467C File Offset: 0x0000287C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 double3x2(double m00, double m01, double m10, double m11, double m20, double m21)
		{
			return new double3x2(m00, m01, m10, m11, m20, m21);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000468B File Offset: 0x0000288B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 double3x2(double v)
		{
			return new double3x2(v);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00004693 File Offset: 0x00002893
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 double3x2(bool v)
		{
			return new double3x2(v);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000469B File Offset: 0x0000289B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 double3x2(bool3x2 v)
		{
			return new double3x2(v);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x000046A3 File Offset: 0x000028A3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 double3x2(int v)
		{
			return new double3x2(v);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x000046AB File Offset: 0x000028AB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 double3x2(int3x2 v)
		{
			return new double3x2(v);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x000046B3 File Offset: 0x000028B3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 double3x2(uint v)
		{
			return new double3x2(v);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x000046BB File Offset: 0x000028BB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 double3x2(uint3x2 v)
		{
			return new double3x2(v);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x000046C3 File Offset: 0x000028C3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 double3x2(float v)
		{
			return new double3x2(v);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000046CB File Offset: 0x000028CB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 double3x2(float3x2 v)
		{
			return new double3x2(v);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x000046D4 File Offset: 0x000028D4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 transpose(double3x2 v)
		{
			return math.double2x3(v.c0.x, v.c0.y, v.c0.z, v.c1.x, v.c1.y, v.c1.z);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00004728 File Offset: 0x00002928
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(double3x2 v)
		{
			return math.csum(math.fold_to_uint(v.c0) * math.uint3(3996716183U, 2626301701U, 1306289417U) + math.fold_to_uint(v.c1) * math.uint3(2096137163U, 1548578029U, 4178800919U)) + 3898072289U;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00004790 File Offset: 0x00002990
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(double3x2 v)
		{
			return math.fold_to_uint(v.c0) * math.uint3(4129428421U, 2631575897U, 2854656703U) + math.fold_to_uint(v.c1) * math.uint3(3578504047U, 4245178297U, 2173281923U) + 2973357649U;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000047F4 File Offset: 0x000029F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 double3x3(double3 c0, double3 c1, double3 c2)
		{
			return new double3x3(c0, c1, c2);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00004800 File Offset: 0x00002A00
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 double3x3(double m00, double m01, double m02, double m10, double m11, double m12, double m20, double m21, double m22)
		{
			return new double3x3(m00, m01, m02, m10, m11, m12, m20, m21, m22);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00004820 File Offset: 0x00002A20
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 double3x3(double v)
		{
			return new double3x3(v);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00004828 File Offset: 0x00002A28
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 double3x3(bool v)
		{
			return new double3x3(v);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00004830 File Offset: 0x00002A30
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 double3x3(bool3x3 v)
		{
			return new double3x3(v);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00004838 File Offset: 0x00002A38
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 double3x3(int v)
		{
			return new double3x3(v);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00004840 File Offset: 0x00002A40
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 double3x3(int3x3 v)
		{
			return new double3x3(v);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00004848 File Offset: 0x00002A48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 double3x3(uint v)
		{
			return new double3x3(v);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00004850 File Offset: 0x00002A50
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 double3x3(uint3x3 v)
		{
			return new double3x3(v);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00004858 File Offset: 0x00002A58
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 double3x3(float v)
		{
			return new double3x3(v);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00004860 File Offset: 0x00002A60
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 double3x3(float3x3 v)
		{
			return new double3x3(v);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00004868 File Offset: 0x00002A68
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 transpose(double3x3 v)
		{
			return math.double3x3(v.c0.x, v.c0.y, v.c0.z, v.c1.x, v.c1.y, v.c1.z, v.c2.x, v.c2.y, v.c2.z);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000048E0 File Offset: 0x00002AE0
		public static double3x3 inverse(double3x3 m)
		{
			double3 c = m.c0;
			double3 c2 = m.c1;
			double3 c3 = m.c2;
			double3 lhs = math.double3(c2.x, c3.x, c.x);
			double3 @double = math.double3(c2.y, c3.y, c.y);
			double3 rhs = math.double3(c2.z, c3.z, c.z);
			double3 double2 = @double * rhs.yzx - @double.yzx * rhs;
			double3 c4 = lhs.yzx * rhs - lhs * rhs.yzx;
			double3 c5 = lhs * @double.yzx - lhs.yzx * @double;
			double rhs2 = 1.0 / math.csum(lhs.zxy * double2);
			return math.double3x3(double2, c4, c5) * rhs2;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x000049E0 File Offset: 0x00002BE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double determinant(double3x3 m)
		{
			double3 c = m.c0;
			double3 c2 = m.c1;
			double3 c3 = m.c2;
			double num = c2.y * c3.z - c2.z * c3.y;
			double num2 = c.y * c3.z - c.z * c3.y;
			double num3 = c.y * c2.z - c.z * c2.y;
			return c.x * num - c2.x * num2 + c3.x * num3;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00004A74 File Offset: 0x00002C74
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(double3x3 v)
		{
			return math.csum(math.fold_to_uint(v.c0) * math.uint3(2891822459U, 2837054189U, 3016004371U) + math.fold_to_uint(v.c1) * math.uint3(4097481403U, 2229788699U, 2382715877U) + math.fold_to_uint(v.c2) * math.uint3(1851936439U, 1938025801U, 3712598587U)) + 3956330501U;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00004B04 File Offset: 0x00002D04
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(double3x3 v)
		{
			return math.fold_to_uint(v.c0) * math.uint3(2437373431U, 1441286183U, 2426570171U) + math.fold_to_uint(v.c1) * math.uint3(1561977301U, 4205774813U, 1650214333U) + math.fold_to_uint(v.c2) * math.uint3(3388112843U, 1831150513U, 1848374953U) + 3430200247U;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00004B91 File Offset: 0x00002D91
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x4 double3x4(double3 c0, double3 c1, double3 c2, double3 c3)
		{
			return new double3x4(c0, c1, c2, c3);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00004B9C File Offset: 0x00002D9C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x4 double3x4(double m00, double m01, double m02, double m03, double m10, double m11, double m12, double m13, double m20, double m21, double m22, double m23)
		{
			return new double3x4(m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00004BC2 File Offset: 0x00002DC2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x4 double3x4(double v)
		{
			return new double3x4(v);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00004BCA File Offset: 0x00002DCA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x4 double3x4(bool v)
		{
			return new double3x4(v);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00004BD2 File Offset: 0x00002DD2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x4 double3x4(bool3x4 v)
		{
			return new double3x4(v);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00004BDA File Offset: 0x00002DDA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x4 double3x4(int v)
		{
			return new double3x4(v);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00004BE2 File Offset: 0x00002DE2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x4 double3x4(int3x4 v)
		{
			return new double3x4(v);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00004BEA File Offset: 0x00002DEA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x4 double3x4(uint v)
		{
			return new double3x4(v);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00004BF2 File Offset: 0x00002DF2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x4 double3x4(uint3x4 v)
		{
			return new double3x4(v);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00004BFA File Offset: 0x00002DFA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x4 double3x4(float v)
		{
			return new double3x4(v);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00004C02 File Offset: 0x00002E02
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x4 double3x4(float3x4 v)
		{
			return new double3x4(v);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00004C0C File Offset: 0x00002E0C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 transpose(double3x4 v)
		{
			return math.double4x3(v.c0.x, v.c0.y, v.c0.z, v.c1.x, v.c1.y, v.c1.z, v.c2.x, v.c2.y, v.c2.z, v.c3.x, v.c3.y, v.c3.z);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00004CA4 File Offset: 0x00002EA4
		public static double3x4 fastinverse(double3x4 m)
		{
			double3 c = m.c0;
			double3 c2 = m.c1;
			double3 c3 = m.c2;
			double3 @double = m.c3;
			double3 double2 = math.double3(c.x, c2.x, c3.x);
			double3 double3 = math.double3(c.y, c2.y, c3.y);
			double3 double4 = math.double3(c.z, c2.z, c3.z);
			@double = -(double2 * @double.x + double3 * @double.y + double4 * @double.z);
			return math.double3x4(double2, double3, double4, @double);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00004D58 File Offset: 0x00002F58
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(double3x4 v)
		{
			return math.csum(math.fold_to_uint(v.c0) * math.uint3(3996716183U, 2626301701U, 1306289417U) + math.fold_to_uint(v.c1) * math.uint3(2096137163U, 1548578029U, 4178800919U) + math.fold_to_uint(v.c2) * math.uint3(3898072289U, 4129428421U, 2631575897U) + math.fold_to_uint(v.c3) * math.uint3(2854656703U, 3578504047U, 4245178297U)) + 2173281923U;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00004E10 File Offset: 0x00003010
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(double3x4 v)
		{
			return math.fold_to_uint(v.c0) * math.uint3(2973357649U, 3881277847U, 4017968839U) + math.fold_to_uint(v.c1) * math.uint3(1727237899U, 1648514723U, 1385344481U) + math.fold_to_uint(v.c2) * math.uint3(3538260197U, 4066109527U, 2613148903U) + math.fold_to_uint(v.c3) * math.uint3(3367528529U, 1678332449U, 2918459647U) + 2744611081U;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00004EC6 File Offset: 0x000030C6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(double x, double y, double z, double w)
		{
			return new double4(x, y, z, w);
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00004ED1 File Offset: 0x000030D1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(double x, double y, double2 zw)
		{
			return new double4(x, y, zw);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00004EDB File Offset: 0x000030DB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(double x, double2 yz, double w)
		{
			return new double4(x, yz, w);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00004EE5 File Offset: 0x000030E5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(double x, double3 yzw)
		{
			return new double4(x, yzw);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00004EEE File Offset: 0x000030EE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(double2 xy, double z, double w)
		{
			return new double4(xy, z, w);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00004EF8 File Offset: 0x000030F8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(double2 xy, double2 zw)
		{
			return new double4(xy, zw);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00004F01 File Offset: 0x00003101
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(double3 xyz, double w)
		{
			return new double4(xyz, w);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00004F0A File Offset: 0x0000310A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(double4 xyzw)
		{
			return new double4(xyzw);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00004F12 File Offset: 0x00003112
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(double v)
		{
			return new double4(v);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00004F1A File Offset: 0x0000311A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(bool v)
		{
			return new double4(v);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00004F22 File Offset: 0x00003122
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(bool4 v)
		{
			return new double4(v);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00004F2A File Offset: 0x0000312A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(int v)
		{
			return new double4(v);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00004F32 File Offset: 0x00003132
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(int4 v)
		{
			return new double4(v);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00004F3A File Offset: 0x0000313A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(uint v)
		{
			return new double4(v);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00004F42 File Offset: 0x00003142
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(uint4 v)
		{
			return new double4(v);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00004F4A File Offset: 0x0000314A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(half v)
		{
			return new double4(v);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00004F52 File Offset: 0x00003152
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(half4 v)
		{
			return new double4(v);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00004F5A File Offset: 0x0000315A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(float v)
		{
			return new double4(v);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00004F62 File Offset: 0x00003162
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 double4(float4 v)
		{
			return new double4(v);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00004F6A File Offset: 0x0000316A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(double4 v)
		{
			return math.csum(math.fold_to_uint(v) * math.uint4(2669441947U, 1260114311U, 2650080659U, 4052675461U)) + 2652487619U;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00004F9B File Offset: 0x0000319B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(double4 v)
		{
			return math.fold_to_uint(v) * math.uint4(2174136431U, 3528391193U, 2105559227U, 1899745391U) + 1966790317U;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00004FCB File Offset: 0x000031CB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double shuffle(double4 left, double4 right, math.ShuffleComponent x)
		{
			return math.select_shuffle_component(left, right, x);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00004FD5 File Offset: 0x000031D5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 shuffle(double4 left, double4 right, math.ShuffleComponent x, math.ShuffleComponent y)
		{
			return math.double2(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y));
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00004FEC File Offset: 0x000031EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 shuffle(double4 left, double4 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
		{
			return math.double3(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z));
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000500C File Offset: 0x0000320C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 shuffle(double4 left, double4 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
		{
			return math.double4(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z), math.select_shuffle_component(left, right, w));
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00005038 File Offset: 0x00003238
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static double select_shuffle_component(double4 a, double4 b, math.ShuffleComponent component)
		{
			switch (component)
			{
			case math.ShuffleComponent.LeftX:
				return a.x;
			case math.ShuffleComponent.LeftY:
				return a.y;
			case math.ShuffleComponent.LeftZ:
				return a.z;
			case math.ShuffleComponent.LeftW:
				return a.w;
			case math.ShuffleComponent.RightX:
				return b.x;
			case math.ShuffleComponent.RightY:
				return b.y;
			case math.ShuffleComponent.RightZ:
				return b.z;
			case math.ShuffleComponent.RightW:
				return b.w;
			default:
				throw new ArgumentException("Invalid shuffle component: " + component.ToString());
			}
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000050C1 File Offset: 0x000032C1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 double4x2(double4 c0, double4 c1)
		{
			return new double4x2(c0, c1);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x000050CA File Offset: 0x000032CA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 double4x2(double m00, double m01, double m10, double m11, double m20, double m21, double m30, double m31)
		{
			return new double4x2(m00, m01, m10, m11, m20, m21, m30, m31);
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000050DD File Offset: 0x000032DD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 double4x2(double v)
		{
			return new double4x2(v);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x000050E5 File Offset: 0x000032E5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 double4x2(bool v)
		{
			return new double4x2(v);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x000050ED File Offset: 0x000032ED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 double4x2(bool4x2 v)
		{
			return new double4x2(v);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x000050F5 File Offset: 0x000032F5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 double4x2(int v)
		{
			return new double4x2(v);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x000050FD File Offset: 0x000032FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 double4x2(int4x2 v)
		{
			return new double4x2(v);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00005105 File Offset: 0x00003305
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 double4x2(uint v)
		{
			return new double4x2(v);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000510D File Offset: 0x0000330D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 double4x2(uint4x2 v)
		{
			return new double4x2(v);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00005115 File Offset: 0x00003315
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 double4x2(float v)
		{
			return new double4x2(v);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000511D File Offset: 0x0000331D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 double4x2(float4x2 v)
		{
			return new double4x2(v);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00005128 File Offset: 0x00003328
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 transpose(double4x2 v)
		{
			return math.double2x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w, v.c1.x, v.c1.y, v.c1.z, v.c1.w);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00005194 File Offset: 0x00003394
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(double4x2 v)
		{
			return math.csum(math.fold_to_uint(v.c0) * math.uint4(1521739981U, 1735296007U, 3010324327U, 1875523709U) + math.fold_to_uint(v.c1) * math.uint4(2937008387U, 3835713223U, 2216526373U, 3375971453U)) + 3559829411U;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00005204 File Offset: 0x00003404
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(double4x2 v)
		{
			return math.fold_to_uint(v.c0) * math.uint4(3652178029U, 2544260129U, 2013864031U, 2627668003U) + math.fold_to_uint(v.c1) * math.uint4(1520214331U, 2949502447U, 2827819133U, 3480140317U) + 2642994593U;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00005272 File Offset: 0x00003472
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 double4x3(double4 c0, double4 c1, double4 c2)
		{
			return new double4x3(c0, c1, c2);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000527C File Offset: 0x0000347C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 double4x3(double m00, double m01, double m02, double m10, double m11, double m12, double m20, double m21, double m22, double m30, double m31, double m32)
		{
			return new double4x3(m00, m01, m02, m10, m11, m12, m20, m21, m22, m30, m31, m32);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x000052A2 File Offset: 0x000034A2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 double4x3(double v)
		{
			return new double4x3(v);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x000052AA File Offset: 0x000034AA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 double4x3(bool v)
		{
			return new double4x3(v);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x000052B2 File Offset: 0x000034B2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 double4x3(bool4x3 v)
		{
			return new double4x3(v);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x000052BA File Offset: 0x000034BA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 double4x3(int v)
		{
			return new double4x3(v);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x000052C2 File Offset: 0x000034C2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 double4x3(int4x3 v)
		{
			return new double4x3(v);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x000052CA File Offset: 0x000034CA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 double4x3(uint v)
		{
			return new double4x3(v);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x000052D2 File Offset: 0x000034D2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 double4x3(uint4x3 v)
		{
			return new double4x3(v);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x000052DA File Offset: 0x000034DA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 double4x3(float v)
		{
			return new double4x3(v);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x000052E2 File Offset: 0x000034E2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 double4x3(float4x3 v)
		{
			return new double4x3(v);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x000052EC File Offset: 0x000034EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x4 transpose(double4x3 v)
		{
			return math.double3x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w, v.c1.x, v.c1.y, v.c1.z, v.c1.w, v.c2.x, v.c2.y, v.c2.z, v.c2.w);
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00005384 File Offset: 0x00003584
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(double4x3 v)
		{
			return math.csum(math.fold_to_uint(v.c0) * math.uint4(2057338067U, 2942577577U, 2834440507U, 2671762487U) + math.fold_to_uint(v.c1) * math.uint4(2892026051U, 2455987759U, 3868600063U, 3170963179U) + math.fold_to_uint(v.c2) * math.uint4(2632835537U, 1136528209U, 2944626401U, 2972762423U)) + 1417889653U;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00005424 File Offset: 0x00003624
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(double4x3 v)
		{
			return math.fold_to_uint(v.c0) * math.uint4(2080514593U, 2731544287U, 2828498809U, 2669441947U) + math.fold_to_uint(v.c1) * math.uint4(1260114311U, 2650080659U, 4052675461U, 2652487619U) + math.fold_to_uint(v.c2) * math.uint4(2174136431U, 3528391193U, 2105559227U, 1899745391U) + 1966790317U;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x000054C0 File Offset: 0x000036C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x4 double4x4(double4 c0, double4 c1, double4 c2, double4 c3)
		{
			return new double4x4(c0, c1, c2, c3);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x000054CC File Offset: 0x000036CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x4 double4x4(double m00, double m01, double m02, double m03, double m10, double m11, double m12, double m13, double m20, double m21, double m22, double m23, double m30, double m31, double m32, double m33)
		{
			return new double4x4(m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x000054FA File Offset: 0x000036FA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x4 double4x4(double v)
		{
			return new double4x4(v);
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00005502 File Offset: 0x00003702
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x4 double4x4(bool v)
		{
			return new double4x4(v);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000550A File Offset: 0x0000370A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x4 double4x4(bool4x4 v)
		{
			return new double4x4(v);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00005512 File Offset: 0x00003712
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x4 double4x4(int v)
		{
			return new double4x4(v);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0000551A File Offset: 0x0000371A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x4 double4x4(int4x4 v)
		{
			return new double4x4(v);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00005522 File Offset: 0x00003722
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x4 double4x4(uint v)
		{
			return new double4x4(v);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0000552A File Offset: 0x0000372A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x4 double4x4(uint4x4 v)
		{
			return new double4x4(v);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00005532 File Offset: 0x00003732
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x4 double4x4(float v)
		{
			return new double4x4(v);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0000553A File Offset: 0x0000373A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x4 double4x4(float4x4 v)
		{
			return new double4x4(v);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00005544 File Offset: 0x00003744
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 rotate(double4x4 a, double3 b)
		{
			return (a.c0 * b.x + a.c1 * b.y + a.c2 * b.z).xyz;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00005598 File Offset: 0x00003798
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 transform(double4x4 a, double3 b)
		{
			return (a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3).xyz;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x000055F8 File Offset: 0x000037F8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x4 transpose(double4x4 v)
		{
			return math.double4x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w, v.c1.x, v.c1.y, v.c1.z, v.c1.w, v.c2.x, v.c2.y, v.c2.z, v.c2.w, v.c3.x, v.c3.y, v.c3.z, v.c3.w);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x000056BC File Offset: 0x000038BC
		public static double4x4 inverse(double4x4 m)
		{
			double4 c = m.c0;
			double4 c2 = m.c1;
			double4 c3 = m.c2;
			double4 c4 = m.c3;
			double4 @double = math.movelh(c2, c);
			double4 double2 = math.movelh(c3, c4);
			double4 double3 = math.movehl(c, c2);
			double4 double4 = math.movehl(c4, c3);
			double4 lhs = math.shuffle(c2, c, math.ShuffleComponent.LeftY, math.ShuffleComponent.LeftZ, math.ShuffleComponent.RightY, math.ShuffleComponent.RightZ);
			double4 lhs2 = math.shuffle(c3, c4, math.ShuffleComponent.LeftY, math.ShuffleComponent.LeftZ, math.ShuffleComponent.RightY, math.ShuffleComponent.RightZ);
			double4 lhs3 = math.shuffle(c2, c, math.ShuffleComponent.LeftW, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightW, math.ShuffleComponent.RightX);
			double4 lhs4 = math.shuffle(c3, c4, math.ShuffleComponent.LeftW, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightW, math.ShuffleComponent.RightX);
			double4 lhs5 = math.shuffle(double2, @double, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX, math.ShuffleComponent.RightZ);
			double4 lhs6 = math.shuffle(double2, @double, math.ShuffleComponent.LeftW, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightY, math.ShuffleComponent.RightW);
			double4 lhs7 = math.shuffle(double4, double3, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX, math.ShuffleComponent.RightZ);
			double4 lhs8 = math.shuffle(double4, double3, math.ShuffleComponent.LeftW, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightY, math.ShuffleComponent.RightW);
			double4 lhs9 = math.shuffle(@double, double2, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX, math.ShuffleComponent.RightZ);
			double4 double5 = lhs * double4 - lhs2 * double3;
			double4 double6 = @double * double4 - double2 * double3;
			double4 double7 = lhs4 * @double - lhs3 * double2;
			double4 rhs = math.shuffle(double5, double5, math.ShuffleComponent.LeftX, math.ShuffleComponent.LeftZ, math.ShuffleComponent.RightZ, math.ShuffleComponent.RightX);
			double4 rhs2 = math.shuffle(double5, double5, math.ShuffleComponent.LeftY, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightW, math.ShuffleComponent.RightY);
			double4 rhs3 = math.shuffle(double6, double6, math.ShuffleComponent.LeftX, math.ShuffleComponent.LeftZ, math.ShuffleComponent.RightZ, math.ShuffleComponent.RightX);
			double4 rhs4 = math.shuffle(double6, double6, math.ShuffleComponent.LeftY, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightW, math.ShuffleComponent.RightY);
			double4 double8 = lhs8 * rhs - lhs7 * rhs4 + lhs6 * rhs2;
			double4 double9 = lhs9 * double8;
			double9 += math.shuffle(double9, double9, math.ShuffleComponent.LeftY, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightW, math.ShuffleComponent.RightZ);
			double9 -= math.shuffle(double9, double9, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftZ, math.ShuffleComponent.RightX, math.ShuffleComponent.RightX);
			double4 rhs5 = math.double4(1.0) / double9;
			double4x4 result;
			result.c0 = double8 * rhs5;
			double4 rhs6 = math.shuffle(double7, double7, math.ShuffleComponent.LeftX, math.ShuffleComponent.LeftZ, math.ShuffleComponent.RightZ, math.ShuffleComponent.RightX);
			double4 rhs7 = math.shuffle(double7, double7, math.ShuffleComponent.LeftY, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightW, math.ShuffleComponent.RightY);
			double4 lhs10 = lhs7 * rhs6 - lhs5 * rhs2 - lhs8 * rhs3;
			result.c1 = lhs10 * rhs5;
			double4 lhs11 = lhs5 * rhs4 - lhs6 * rhs6 - lhs8 * rhs7;
			result.c2 = lhs11 * rhs5;
			double4 lhs12 = lhs6 * rhs3 - lhs5 * rhs + lhs7 * rhs7;
			result.c3 = lhs12 * rhs5;
			return result;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00005950 File Offset: 0x00003B50
		public static double4x4 fastinverse(double4x4 m)
		{
			double4 c = m.c0;
			double4 c2 = m.c1;
			double4 c3 = m.c2;
			double4 @double = m.c3;
			double4 b = math.double4(0);
			double4 a = math.unpacklo(c, c3);
			double4 b2 = math.unpacklo(c2, b);
			double4 a2 = math.unpackhi(c, c3);
			double4 b3 = math.unpackhi(c2, b);
			double4 double2 = math.unpacklo(a, b2);
			double4 double3 = math.unpackhi(a, b2);
			double4 double4 = math.unpacklo(a2, b3);
			@double = -(double2 * @double.x + double3 * @double.y + double4 * @double.z);
			@double.w = 1.0;
			return math.double4x4(double2, double3, double4, @double);
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00005A14 File Offset: 0x00003C14
		public static double determinant(double4x4 m)
		{
			double4 c = m.c0;
			double4 c2 = m.c1;
			double4 c3 = m.c2;
			double4 c4 = m.c3;
			double num = c2.y * (c3.z * c4.w - c3.w * c4.z) - c3.y * (c2.z * c4.w - c2.w * c4.z) + c4.y * (c2.z * c3.w - c2.w * c3.z);
			double num2 = c.y * (c3.z * c4.w - c3.w * c4.z) - c3.y * (c.z * c4.w - c.w * c4.z) + c4.y * (c.z * c3.w - c.w * c3.z);
			double num3 = c.y * (c2.z * c4.w - c2.w * c4.z) - c2.y * (c.z * c4.w - c.w * c4.z) + c4.y * (c.z * c2.w - c.w * c2.z);
			double num4 = c.y * (c2.z * c3.w - c2.w * c3.z) - c2.y * (c.z * c3.w - c.w * c3.z) + c3.y * (c.z * c2.w - c.w * c2.z);
			return c.x * num - c2.x * num2 + c3.x * num3 - c4.x * num4;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00005C0C File Offset: 0x00003E0C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(double4x4 v)
		{
			return math.csum(math.fold_to_uint(v.c0) * math.uint4(1306289417U, 2096137163U, 1548578029U, 4178800919U) + math.fold_to_uint(v.c1) * math.uint4(3898072289U, 4129428421U, 2631575897U, 2854656703U) + math.fold_to_uint(v.c2) * math.uint4(3578504047U, 4245178297U, 2173281923U, 2973357649U) + math.fold_to_uint(v.c3) * math.uint4(3881277847U, 4017968839U, 1727237899U, 1648514723U)) + 1385344481U;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00005CD8 File Offset: 0x00003ED8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(double4x4 v)
		{
			return math.fold_to_uint(v.c0) * math.uint4(3538260197U, 4066109527U, 2613148903U, 3367528529U) + math.fold_to_uint(v.c1) * math.uint4(1678332449U, 2918459647U, 2744611081U, 1952372791U) + math.fold_to_uint(v.c2) * math.uint4(2631698677U, 4200781601U, 2119021007U, 1760485621U) + math.fold_to_uint(v.c3) * math.uint4(3157985881U, 2171534173U, 2723054263U, 1168253063U) + 4228926523U;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00005DA2 File Offset: 0x00003FA2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 float2(float x, float y)
		{
			return new float2(x, y);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00005DAB File Offset: 0x00003FAB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 float2(float2 xy)
		{
			return new float2(xy);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00005DB3 File Offset: 0x00003FB3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 float2(float v)
		{
			return new float2(v);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00005DBB File Offset: 0x00003FBB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 float2(bool v)
		{
			return new float2(v);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00005DC3 File Offset: 0x00003FC3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 float2(bool2 v)
		{
			return new float2(v);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00005DCB File Offset: 0x00003FCB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 float2(int v)
		{
			return new float2(v);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00005DD3 File Offset: 0x00003FD3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 float2(int2 v)
		{
			return new float2(v);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00005DDB File Offset: 0x00003FDB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 float2(uint v)
		{
			return new float2(v);
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00005DE3 File Offset: 0x00003FE3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 float2(uint2 v)
		{
			return new float2(v);
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00005DEB File Offset: 0x00003FEB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 float2(half v)
		{
			return new float2(v);
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00005DF3 File Offset: 0x00003FF3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 float2(half2 v)
		{
			return new float2(v);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00005DFB File Offset: 0x00003FFB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 float2(double v)
		{
			return new float2(v);
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00005E03 File Offset: 0x00004003
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 float2(double2 v)
		{
			return new float2(v);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00005E0B File Offset: 0x0000400B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(float2 v)
		{
			return math.csum(math.asuint(v) * math.uint2(4198118021U, 2908068253U)) + 3705492289U;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00005E32 File Offset: 0x00004032
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(float2 v)
		{
			return math.asuint(v) * math.uint2(2497566569U, 2716413241U) + 1166264321U;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00005E58 File Offset: 0x00004058
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float shuffle(float2 left, float2 right, math.ShuffleComponent x)
		{
			return math.select_shuffle_component(left, right, x);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00005E62 File Offset: 0x00004062
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 shuffle(float2 left, float2 right, math.ShuffleComponent x, math.ShuffleComponent y)
		{
			return math.float2(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y));
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00005E79 File Offset: 0x00004079
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 shuffle(float2 left, float2 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
		{
			return math.float3(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z));
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00005E99 File Offset: 0x00004099
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 shuffle(float2 left, float2 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
		{
			return math.float4(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z), math.select_shuffle_component(left, right, w));
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00005EC4 File Offset: 0x000040C4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static float select_shuffle_component(float2 a, float2 b, math.ShuffleComponent component)
		{
			switch (component)
			{
			case math.ShuffleComponent.LeftX:
				return a.x;
			case math.ShuffleComponent.LeftY:
				return a.y;
			case math.ShuffleComponent.RightX:
				return b.x;
			case math.ShuffleComponent.RightY:
				return b.y;
			}
			throw new ArgumentException("Invalid shuffle component: " + component.ToString());
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00005F29 File Offset: 0x00004129
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x2 float2x2(float2 c0, float2 c1)
		{
			return new float2x2(c0, c1);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00005F32 File Offset: 0x00004132
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x2 float2x2(float m00, float m01, float m10, float m11)
		{
			return new float2x2(m00, m01, m10, m11);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00005F3D File Offset: 0x0000413D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x2 float2x2(float v)
		{
			return new float2x2(v);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00005F45 File Offset: 0x00004145
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x2 float2x2(bool v)
		{
			return new float2x2(v);
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00005F4D File Offset: 0x0000414D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x2 float2x2(bool2x2 v)
		{
			return new float2x2(v);
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00005F55 File Offset: 0x00004155
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x2 float2x2(int v)
		{
			return new float2x2(v);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00005F5D File Offset: 0x0000415D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x2 float2x2(int2x2 v)
		{
			return new float2x2(v);
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00005F65 File Offset: 0x00004165
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x2 float2x2(uint v)
		{
			return new float2x2(v);
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00005F6D File Offset: 0x0000416D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x2 float2x2(uint2x2 v)
		{
			return new float2x2(v);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00005F75 File Offset: 0x00004175
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x2 float2x2(double v)
		{
			return new float2x2(v);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00005F7D File Offset: 0x0000417D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x2 float2x2(double2x2 v)
		{
			return new float2x2(v);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00005F85 File Offset: 0x00004185
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x2 transpose(float2x2 v)
		{
			return math.float2x2(v.c0.x, v.c0.y, v.c1.x, v.c1.y);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00005FB8 File Offset: 0x000041B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x2 inverse(float2x2 m)
		{
			float x = m.c0.x;
			float x2 = m.c1.x;
			float y = m.c0.y;
			float y2 = m.c1.y;
			float num = x * y2 - x2 * y;
			return math.float2x2(y2, -x2, -y, x) * (1f / num);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00006018 File Offset: 0x00004218
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float determinant(float2x2 m)
		{
			float x = m.c0.x;
			float x2 = m.c1.x;
			float y = m.c0.y;
			float y2 = m.c1.y;
			return x * y2 - x2 * y;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000605C File Offset: 0x0000425C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(float2x2 v)
		{
			return math.csum(math.asuint(v.c0) * math.uint2(2627668003U, 1520214331U) + math.asuint(v.c1) * math.uint2(2949502447U, 2827819133U)) + 3480140317U;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x000060B8 File Offset: 0x000042B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(float2x2 v)
		{
			return math.asuint(v.c0) * math.uint2(2642994593U, 3940484981U) + math.asuint(v.c1) * math.uint2(1954192763U, 1091696537U) + 3052428017U;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00006112 File Offset: 0x00004312
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 float2x3(float2 c0, float2 c1, float2 c2)
		{
			return new float2x3(c0, c1, c2);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000611C File Offset: 0x0000431C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 float2x3(float m00, float m01, float m02, float m10, float m11, float m12)
		{
			return new float2x3(m00, m01, m02, m10, m11, m12);
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000612B File Offset: 0x0000432B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 float2x3(float v)
		{
			return new float2x3(v);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00006133 File Offset: 0x00004333
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 float2x3(bool v)
		{
			return new float2x3(v);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000613B File Offset: 0x0000433B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 float2x3(bool2x3 v)
		{
			return new float2x3(v);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00006143 File Offset: 0x00004343
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 float2x3(int v)
		{
			return new float2x3(v);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000614B File Offset: 0x0000434B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 float2x3(int2x3 v)
		{
			return new float2x3(v);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00006153 File Offset: 0x00004353
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 float2x3(uint v)
		{
			return new float2x3(v);
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000615B File Offset: 0x0000435B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 float2x3(uint2x3 v)
		{
			return new float2x3(v);
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00006163 File Offset: 0x00004363
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 float2x3(double v)
		{
			return new float2x3(v);
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000616B File Offset: 0x0000436B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 float2x3(double2x3 v)
		{
			return new float2x3(v);
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00006174 File Offset: 0x00004374
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 transpose(float2x3 v)
		{
			return math.float3x2(v.c0.x, v.c0.y, v.c1.x, v.c1.y, v.c2.x, v.c2.y);
		}

		// Token: 0x06000194 RID: 404 RVA: 0x000061C8 File Offset: 0x000043C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(float2x3 v)
		{
			return math.csum(math.asuint(v.c0) * math.uint2(3898072289U, 4129428421U) + math.asuint(v.c1) * math.uint2(2631575897U, 2854656703U) + math.asuint(v.c2) * math.uint2(3578504047U, 4245178297U)) + 2173281923U;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00006248 File Offset: 0x00004448
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(float2x3 v)
		{
			return math.asuint(v.c0) * math.uint2(2973357649U, 3881277847U) + math.asuint(v.c1) * math.uint2(4017968839U, 1727237899U) + math.asuint(v.c2) * math.uint2(1648514723U, 1385344481U) + 3538260197U;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x000062C6 File Offset: 0x000044C6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 float2x4(float2 c0, float2 c1, float2 c2, float2 c3)
		{
			return new float2x4(c0, c1, c2, c3);
		}

		// Token: 0x06000197 RID: 407 RVA: 0x000062D1 File Offset: 0x000044D1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 float2x4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13)
		{
			return new float2x4(m00, m01, m02, m03, m10, m11, m12, m13);
		}

		// Token: 0x06000198 RID: 408 RVA: 0x000062E4 File Offset: 0x000044E4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 float2x4(float v)
		{
			return new float2x4(v);
		}

		// Token: 0x06000199 RID: 409 RVA: 0x000062EC File Offset: 0x000044EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 float2x4(bool v)
		{
			return new float2x4(v);
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000062F4 File Offset: 0x000044F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 float2x4(bool2x4 v)
		{
			return new float2x4(v);
		}

		// Token: 0x0600019B RID: 411 RVA: 0x000062FC File Offset: 0x000044FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 float2x4(int v)
		{
			return new float2x4(v);
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00006304 File Offset: 0x00004504
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 float2x4(int2x4 v)
		{
			return new float2x4(v);
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0000630C File Offset: 0x0000450C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 float2x4(uint v)
		{
			return new float2x4(v);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00006314 File Offset: 0x00004514
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 float2x4(uint2x4 v)
		{
			return new float2x4(v);
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0000631C File Offset: 0x0000451C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 float2x4(double v)
		{
			return new float2x4(v);
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00006324 File Offset: 0x00004524
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 float2x4(double2x4 v)
		{
			return new float2x4(v);
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x0000632C File Offset: 0x0000452C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 transpose(float2x4 v)
		{
			return math.float4x2(v.c0.x, v.c0.y, v.c1.x, v.c1.y, v.c2.x, v.c2.y, v.c3.x, v.c3.y);
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00006398 File Offset: 0x00004598
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(float2x4 v)
		{
			return math.csum(math.asuint(v.c0) * math.uint2(3546061613U, 2702024231U) + math.asuint(v.c1) * math.uint2(1452124841U, 1966089551U) + math.asuint(v.c2) * math.uint2(2668168249U, 1587512777U) + math.asuint(v.c3) * math.uint2(2353831999U, 3101256173U)) + 2891822459U;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0000643C File Offset: 0x0000463C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(float2x4 v)
		{
			return math.asuint(v.c0) * math.uint2(2837054189U, 3016004371U) + math.asuint(v.c1) * math.uint2(4097481403U, 2229788699U) + math.asuint(v.c2) * math.uint2(2382715877U, 1851936439U) + math.asuint(v.c3) * math.uint2(1938025801U, 3712598587U) + 3956330501U;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x000064DE File Offset: 0x000046DE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 float3(float x, float y, float z)
		{
			return new float3(x, y, z);
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x000064E8 File Offset: 0x000046E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 float3(float x, float2 yz)
		{
			return new float3(x, yz);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x000064F1 File Offset: 0x000046F1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 float3(float2 xy, float z)
		{
			return new float3(xy, z);
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x000064FA File Offset: 0x000046FA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 float3(float3 xyz)
		{
			return new float3(xyz);
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00006502 File Offset: 0x00004702
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 float3(float v)
		{
			return new float3(v);
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0000650A File Offset: 0x0000470A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 float3(bool v)
		{
			return new float3(v);
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00006512 File Offset: 0x00004712
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 float3(bool3 v)
		{
			return new float3(v);
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000651A File Offset: 0x0000471A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 float3(int v)
		{
			return new float3(v);
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00006522 File Offset: 0x00004722
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 float3(int3 v)
		{
			return new float3(v);
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0000652A File Offset: 0x0000472A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 float3(uint v)
		{
			return new float3(v);
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00006532 File Offset: 0x00004732
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 float3(uint3 v)
		{
			return new float3(v);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0000653A File Offset: 0x0000473A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 float3(half v)
		{
			return new float3(v);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00006542 File Offset: 0x00004742
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 float3(half3 v)
		{
			return new float3(v);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0000654A File Offset: 0x0000474A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 float3(double v)
		{
			return new float3(v);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00006552 File Offset: 0x00004752
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 float3(double3 v)
		{
			return new float3(v);
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000655A File Offset: 0x0000475A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(float3 v)
		{
			return math.csum(math.asuint(v) * math.uint3(2601761069U, 1254033427U, 2248573027U)) + 3612677113U;
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00006586 File Offset: 0x00004786
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(float3 v)
		{
			return math.asuint(v) * math.uint3(1521739981U, 1735296007U, 3010324327U) + 1875523709U;
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x000065B1 File Offset: 0x000047B1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float shuffle(float3 left, float3 right, math.ShuffleComponent x)
		{
			return math.select_shuffle_component(left, right, x);
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x000065BB File Offset: 0x000047BB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 shuffle(float3 left, float3 right, math.ShuffleComponent x, math.ShuffleComponent y)
		{
			return math.float2(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y));
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x000065D2 File Offset: 0x000047D2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 shuffle(float3 left, float3 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
		{
			return math.float3(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z));
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000065F2 File Offset: 0x000047F2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 shuffle(float3 left, float3 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
		{
			return math.float4(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z), math.select_shuffle_component(left, right, w));
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0000661C File Offset: 0x0000481C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static float select_shuffle_component(float3 a, float3 b, math.ShuffleComponent component)
		{
			switch (component)
			{
			case math.ShuffleComponent.LeftX:
				return a.x;
			case math.ShuffleComponent.LeftY:
				return a.y;
			case math.ShuffleComponent.LeftZ:
				return a.z;
			case math.ShuffleComponent.RightX:
				return b.x;
			case math.ShuffleComponent.RightY:
				return b.y;
			case math.ShuffleComponent.RightZ:
				return b.z;
			}
			throw new ArgumentException("Invalid shuffle component: " + component.ToString());
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00006693 File Offset: 0x00004893
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 float3x2(float3 c0, float3 c1)
		{
			return new float3x2(c0, c1);
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0000669C File Offset: 0x0000489C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 float3x2(float m00, float m01, float m10, float m11, float m20, float m21)
		{
			return new float3x2(m00, m01, m10, m11, m20, m21);
		}

		// Token: 0x060001BC RID: 444 RVA: 0x000066AB File Offset: 0x000048AB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 float3x2(float v)
		{
			return new float3x2(v);
		}

		// Token: 0x060001BD RID: 445 RVA: 0x000066B3 File Offset: 0x000048B3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 float3x2(bool v)
		{
			return new float3x2(v);
		}

		// Token: 0x060001BE RID: 446 RVA: 0x000066BB File Offset: 0x000048BB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 float3x2(bool3x2 v)
		{
			return new float3x2(v);
		}

		// Token: 0x060001BF RID: 447 RVA: 0x000066C3 File Offset: 0x000048C3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 float3x2(int v)
		{
			return new float3x2(v);
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x000066CB File Offset: 0x000048CB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 float3x2(int3x2 v)
		{
			return new float3x2(v);
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x000066D3 File Offset: 0x000048D3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 float3x2(uint v)
		{
			return new float3x2(v);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x000066DB File Offset: 0x000048DB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 float3x2(uint3x2 v)
		{
			return new float3x2(v);
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x000066E3 File Offset: 0x000048E3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 float3x2(double v)
		{
			return new float3x2(v);
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x000066EB File Offset: 0x000048EB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 float3x2(double3x2 v)
		{
			return new float3x2(v);
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x000066F4 File Offset: 0x000048F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 transpose(float3x2 v)
		{
			return math.float2x3(v.c0.x, v.c0.y, v.c0.z, v.c1.x, v.c1.y, v.c1.z);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00006748 File Offset: 0x00004948
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(float3x2 v)
		{
			return math.csum(math.asuint(v.c0) * math.uint3(3777095341U, 3385463369U, 1773538433U) + math.asuint(v.c1) * math.uint3(3773525029U, 4131962539U, 1809525511U)) + 4016293529U;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x000067B0 File Offset: 0x000049B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(float3x2 v)
		{
			return math.asuint(v.c0) * math.uint3(2416021567U, 2828384717U, 2636362241U) + math.asuint(v.c1) * math.uint3(1258410977U, 1952565773U, 2037535609U) + 3592785499U;
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00006814 File Offset: 0x00004A14
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 float3x3(float3 c0, float3 c1, float3 c2)
		{
			return new float3x3(c0, c1, c2);
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00006820 File Offset: 0x00004A20
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 float3x3(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22)
		{
			return new float3x3(m00, m01, m02, m10, m11, m12, m20, m21, m22);
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00006840 File Offset: 0x00004A40
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 float3x3(float v)
		{
			return new float3x3(v);
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00006848 File Offset: 0x00004A48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 float3x3(bool v)
		{
			return new float3x3(v);
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00006850 File Offset: 0x00004A50
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 float3x3(bool3x3 v)
		{
			return new float3x3(v);
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00006858 File Offset: 0x00004A58
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 float3x3(int v)
		{
			return new float3x3(v);
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00006860 File Offset: 0x00004A60
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 float3x3(int3x3 v)
		{
			return new float3x3(v);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00006868 File Offset: 0x00004A68
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 float3x3(uint v)
		{
			return new float3x3(v);
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00006870 File Offset: 0x00004A70
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 float3x3(uint3x3 v)
		{
			return new float3x3(v);
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00006878 File Offset: 0x00004A78
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 float3x3(double v)
		{
			return new float3x3(v);
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00006880 File Offset: 0x00004A80
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 float3x3(double3x3 v)
		{
			return new float3x3(v);
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00006888 File Offset: 0x00004A88
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 transpose(float3x3 v)
		{
			return math.float3x3(v.c0.x, v.c0.y, v.c0.z, v.c1.x, v.c1.y, v.c1.z, v.c2.x, v.c2.y, v.c2.z);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00006900 File Offset: 0x00004B00
		public static float3x3 inverse(float3x3 m)
		{
			float3 c = m.c0;
			float3 c2 = m.c1;
			float3 c3 = m.c2;
			float3 lhs = math.float3(c2.x, c3.x, c.x);
			float3 @float = math.float3(c2.y, c3.y, c.y);
			float3 rhs = math.float3(c2.z, c3.z, c.z);
			float3 float2 = @float * rhs.yzx - @float.yzx * rhs;
			float3 c4 = lhs.yzx * rhs - lhs * rhs.yzx;
			float3 c5 = lhs * @float.yzx - lhs.yzx * @float;
			float rhs2 = 1f / math.csum(lhs.zxy * float2);
			return math.float3x3(float2, c4, c5) * rhs2;
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x000069FC File Offset: 0x00004BFC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float determinant(float3x3 m)
		{
			float3 c = m.c0;
			float3 c2 = m.c1;
			float3 c3 = m.c2;
			float num = c2.y * c3.z - c2.z * c3.y;
			float num2 = c.y * c3.z - c.z * c3.y;
			float num3 = c.y * c2.z - c.z * c2.y;
			return c.x * num - c2.x * num2 + c3.x * num3;
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00006A90 File Offset: 0x00004C90
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(float3x3 v)
		{
			return math.csum(math.asuint(v.c0) * math.uint3(1899745391U, 1966790317U, 3516359879U) + math.asuint(v.c1) * math.uint3(3050356579U, 4178586719U, 2558655391U) + math.asuint(v.c2) * math.uint3(1453413133U, 2152428077U, 1938706661U)) + 1338588197U;
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00006B20 File Offset: 0x00004D20
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(float3x3 v)
		{
			return math.asuint(v.c0) * math.uint3(3439609253U, 3535343003U, 3546061613U) + math.asuint(v.c1) * math.uint3(2702024231U, 1452124841U, 1966089551U) + math.asuint(v.c2) * math.uint3(2668168249U, 1587512777U, 2353831999U) + 3101256173U;
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00006BAD File Offset: 0x00004DAD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 float3x4(float3 c0, float3 c1, float3 c2, float3 c3)
		{
			return new float3x4(c0, c1, c2, c3);
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00006BB8 File Offset: 0x00004DB8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 float3x4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23)
		{
			return new float3x4(m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23);
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00006BDE File Offset: 0x00004DDE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 float3x4(float v)
		{
			return new float3x4(v);
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00006BE6 File Offset: 0x00004DE6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 float3x4(bool v)
		{
			return new float3x4(v);
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00006BEE File Offset: 0x00004DEE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 float3x4(bool3x4 v)
		{
			return new float3x4(v);
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00006BF6 File Offset: 0x00004DF6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 float3x4(int v)
		{
			return new float3x4(v);
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00006BFE File Offset: 0x00004DFE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 float3x4(int3x4 v)
		{
			return new float3x4(v);
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00006C06 File Offset: 0x00004E06
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 float3x4(uint v)
		{
			return new float3x4(v);
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00006C0E File Offset: 0x00004E0E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 float3x4(uint3x4 v)
		{
			return new float3x4(v);
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00006C16 File Offset: 0x00004E16
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 float3x4(double v)
		{
			return new float3x4(v);
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00006C1E File Offset: 0x00004E1E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 float3x4(double3x4 v)
		{
			return new float3x4(v);
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00006C28 File Offset: 0x00004E28
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 transpose(float3x4 v)
		{
			return math.float4x3(v.c0.x, v.c0.y, v.c0.z, v.c1.x, v.c1.y, v.c1.z, v.c2.x, v.c2.y, v.c2.z, v.c3.x, v.c3.y, v.c3.z);
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00006CC0 File Offset: 0x00004EC0
		public static float3x4 fastinverse(float3x4 m)
		{
			float3 c = m.c0;
			float3 c2 = m.c1;
			float3 c3 = m.c2;
			float3 @float = m.c3;
			float3 float2 = math.float3(c.x, c2.x, c3.x);
			float3 float3 = math.float3(c.y, c2.y, c3.y);
			float3 float4 = math.float3(c.z, c2.z, c3.z);
			@float = -(float2 * @float.x + float3 * @float.y + float4 * @float.z);
			return math.float3x4(float2, float3, float4, @float);
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00006D74 File Offset: 0x00004F74
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(float3x4 v)
		{
			return math.csum(math.asuint(v.c0) * math.uint3(4192899797U, 3271228601U, 1634639009U) + math.asuint(v.c1) * math.uint3(3318036811U, 3404170631U, 2048213449U) + math.asuint(v.c2) * math.uint3(4164671783U, 1780759499U, 1352369353U) + math.asuint(v.c3) * math.uint3(2446407751U, 1391928079U, 3475533443U)) + 3777095341U;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00006E2C File Offset: 0x0000502C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(float3x4 v)
		{
			return math.asuint(v.c0) * math.uint3(3385463369U, 1773538433U, 3773525029U) + math.asuint(v.c1) * math.uint3(4131962539U, 1809525511U, 4016293529U) + math.asuint(v.c2) * math.uint3(2416021567U, 2828384717U, 2636362241U) + math.asuint(v.c3) * math.uint3(1258410977U, 1952565773U, 2037535609U) + 3592785499U;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00006EE2 File Offset: 0x000050E2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(float x, float y, float z, float w)
		{
			return new float4(x, y, z, w);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00006EED File Offset: 0x000050ED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(float x, float y, float2 zw)
		{
			return new float4(x, y, zw);
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00006EF7 File Offset: 0x000050F7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(float x, float2 yz, float w)
		{
			return new float4(x, yz, w);
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00006F01 File Offset: 0x00005101
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(float x, float3 yzw)
		{
			return new float4(x, yzw);
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00006F0A File Offset: 0x0000510A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(float2 xy, float z, float w)
		{
			return new float4(xy, z, w);
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00006F14 File Offset: 0x00005114
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(float2 xy, float2 zw)
		{
			return new float4(xy, zw);
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00006F1D File Offset: 0x0000511D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(float3 xyz, float w)
		{
			return new float4(xyz, w);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00006F26 File Offset: 0x00005126
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(float4 xyzw)
		{
			return new float4(xyzw);
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00006F2E File Offset: 0x0000512E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(float v)
		{
			return new float4(v);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00006F36 File Offset: 0x00005136
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(bool v)
		{
			return new float4(v);
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00006F3E File Offset: 0x0000513E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(bool4 v)
		{
			return new float4(v);
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00006F46 File Offset: 0x00005146
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(int v)
		{
			return new float4(v);
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00006F4E File Offset: 0x0000514E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(int4 v)
		{
			return new float4(v);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00006F56 File Offset: 0x00005156
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(uint v)
		{
			return new float4(v);
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00006F5E File Offset: 0x0000515E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(uint4 v)
		{
			return new float4(v);
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00006F66 File Offset: 0x00005166
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(half v)
		{
			return new float4(v);
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00006F6E File Offset: 0x0000516E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(half4 v)
		{
			return new float4(v);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00006F76 File Offset: 0x00005176
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(double v)
		{
			return new float4(v);
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00006F7E File Offset: 0x0000517E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 float4(double4 v)
		{
			return new float4(v);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00006F86 File Offset: 0x00005186
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(float4 v)
		{
			return math.csum(math.asuint(v) * math.uint4(3868600063U, 3170963179U, 2632835537U, 1136528209U)) + 2944626401U;
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00006FB7 File Offset: 0x000051B7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(float4 v)
		{
			return math.asuint(v) * math.uint4(2972762423U, 1417889653U, 2080514593U, 2731544287U) + 2828498809U;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00006FE7 File Offset: 0x000051E7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float shuffle(float4 left, float4 right, math.ShuffleComponent x)
		{
			return math.select_shuffle_component(left, right, x);
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00006FF1 File Offset: 0x000051F1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 shuffle(float4 left, float4 right, math.ShuffleComponent x, math.ShuffleComponent y)
		{
			return math.float2(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y));
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00007008 File Offset: 0x00005208
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 shuffle(float4 left, float4 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
		{
			return math.float3(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z));
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00007028 File Offset: 0x00005228
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 shuffle(float4 left, float4 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
		{
			return math.float4(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z), math.select_shuffle_component(left, right, w));
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00007054 File Offset: 0x00005254
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static float select_shuffle_component(float4 a, float4 b, math.ShuffleComponent component)
		{
			switch (component)
			{
			case math.ShuffleComponent.LeftX:
				return a.x;
			case math.ShuffleComponent.LeftY:
				return a.y;
			case math.ShuffleComponent.LeftZ:
				return a.z;
			case math.ShuffleComponent.LeftW:
				return a.w;
			case math.ShuffleComponent.RightX:
				return b.x;
			case math.ShuffleComponent.RightY:
				return b.y;
			case math.ShuffleComponent.RightZ:
				return b.z;
			case math.ShuffleComponent.RightW:
				return b.w;
			default:
				throw new ArgumentException("Invalid shuffle component: " + component.ToString());
			}
		}

		// Token: 0x06000201 RID: 513 RVA: 0x000070DD File Offset: 0x000052DD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 float4x2(float4 c0, float4 c1)
		{
			return new float4x2(c0, c1);
		}

		// Token: 0x06000202 RID: 514 RVA: 0x000070E6 File Offset: 0x000052E6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 float4x2(float m00, float m01, float m10, float m11, float m20, float m21, float m30, float m31)
		{
			return new float4x2(m00, m01, m10, m11, m20, m21, m30, m31);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x000070F9 File Offset: 0x000052F9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 float4x2(float v)
		{
			return new float4x2(v);
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00007101 File Offset: 0x00005301
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 float4x2(bool v)
		{
			return new float4x2(v);
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00007109 File Offset: 0x00005309
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 float4x2(bool4x2 v)
		{
			return new float4x2(v);
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00007111 File Offset: 0x00005311
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 float4x2(int v)
		{
			return new float4x2(v);
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00007119 File Offset: 0x00005319
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 float4x2(int4x2 v)
		{
			return new float4x2(v);
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00007121 File Offset: 0x00005321
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 float4x2(uint v)
		{
			return new float4x2(v);
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00007129 File Offset: 0x00005329
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 float4x2(uint4x2 v)
		{
			return new float4x2(v);
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00007131 File Offset: 0x00005331
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 float4x2(double v)
		{
			return new float4x2(v);
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00007139 File Offset: 0x00005339
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 float4x2(double4x2 v)
		{
			return new float4x2(v);
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00007144 File Offset: 0x00005344
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 transpose(float4x2 v)
		{
			return math.float2x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w, v.c1.x, v.c1.y, v.c1.z, v.c1.w);
		}

		// Token: 0x0600020D RID: 525 RVA: 0x000071B0 File Offset: 0x000053B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(float4x2 v)
		{
			return math.csum(math.asuint(v.c0) * math.uint4(2864955997U, 3525118277U, 2298260269U, 1632478733U) + math.asuint(v.c1) * math.uint4(1537393931U, 2353355467U, 3441847433U, 4052036147U)) + 2011389559U;
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00007220 File Offset: 0x00005420
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(float4x2 v)
		{
			return math.asuint(v.c0) * math.uint4(2252224297U, 3784421429U, 1750626223U, 3571447507U) + math.asuint(v.c1) * math.uint4(3412283213U, 2601761069U, 1254033427U, 2248573027U) + 3612677113U;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000728E File Offset: 0x0000548E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 float4x3(float4 c0, float4 c1, float4 c2)
		{
			return new float4x3(c0, c1, c2);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00007298 File Offset: 0x00005498
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 float4x3(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22, float m30, float m31, float m32)
		{
			return new float4x3(m00, m01, m02, m10, m11, m12, m20, m21, m22, m30, m31, m32);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x000072BE File Offset: 0x000054BE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 float4x3(float v)
		{
			return new float4x3(v);
		}

		// Token: 0x06000212 RID: 530 RVA: 0x000072C6 File Offset: 0x000054C6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 float4x3(bool v)
		{
			return new float4x3(v);
		}

		// Token: 0x06000213 RID: 531 RVA: 0x000072CE File Offset: 0x000054CE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 float4x3(bool4x3 v)
		{
			return new float4x3(v);
		}

		// Token: 0x06000214 RID: 532 RVA: 0x000072D6 File Offset: 0x000054D6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 float4x3(int v)
		{
			return new float4x3(v);
		}

		// Token: 0x06000215 RID: 533 RVA: 0x000072DE File Offset: 0x000054DE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 float4x3(int4x3 v)
		{
			return new float4x3(v);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x000072E6 File Offset: 0x000054E6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 float4x3(uint v)
		{
			return new float4x3(v);
		}

		// Token: 0x06000217 RID: 535 RVA: 0x000072EE File Offset: 0x000054EE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 float4x3(uint4x3 v)
		{
			return new float4x3(v);
		}

		// Token: 0x06000218 RID: 536 RVA: 0x000072F6 File Offset: 0x000054F6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 float4x3(double v)
		{
			return new float4x3(v);
		}

		// Token: 0x06000219 RID: 537 RVA: 0x000072FE File Offset: 0x000054FE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 float4x3(double4x3 v)
		{
			return new float4x3(v);
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00007308 File Offset: 0x00005508
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 transpose(float4x3 v)
		{
			return math.float3x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w, v.c1.x, v.c1.y, v.c1.z, v.c1.w, v.c2.x, v.c2.y, v.c2.z, v.c2.w);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x000073A0 File Offset: 0x000055A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(float4x3 v)
		{
			return math.csum(math.asuint(v.c0) * math.uint4(3309258581U, 1770373673U, 3778261171U, 3286279097U) + math.asuint(v.c1) * math.uint4(4264629071U, 1898591447U, 2641864091U, 1229113913U) + math.asuint(v.c2) * math.uint4(3020867117U, 1449055807U, 2479033387U, 3702457169U)) + 1845824257U;
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00007440 File Offset: 0x00005640
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(float4x3 v)
		{
			return math.asuint(v.c0) * math.uint4(1963973621U, 2134758553U, 1391111867U, 1167706003U) + math.asuint(v.c1) * math.uint4(2209736489U, 3261535807U, 1740411209U, 2910609089U) + math.asuint(v.c2) * math.uint4(2183822701U, 3029516053U, 3547472099U, 2057487037U) + 3781937309U;
		}

		// Token: 0x0600021D RID: 541 RVA: 0x000074DC File Offset: 0x000056DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 float4x4(float4 c0, float4 c1, float4 c2, float4 c3)
		{
			return new float4x4(c0, c1, c2, c3);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x000074E8 File Offset: 0x000056E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 float4x4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33)
		{
			return new float4x4(m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33);
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00007516 File Offset: 0x00005716
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 float4x4(float v)
		{
			return new float4x4(v);
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0000751E File Offset: 0x0000571E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 float4x4(bool v)
		{
			return new float4x4(v);
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00007526 File Offset: 0x00005726
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 float4x4(bool4x4 v)
		{
			return new float4x4(v);
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000752E File Offset: 0x0000572E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 float4x4(int v)
		{
			return new float4x4(v);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00007536 File Offset: 0x00005736
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 float4x4(int4x4 v)
		{
			return new float4x4(v);
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000753E File Offset: 0x0000573E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 float4x4(uint v)
		{
			return new float4x4(v);
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00007546 File Offset: 0x00005746
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 float4x4(uint4x4 v)
		{
			return new float4x4(v);
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000754E File Offset: 0x0000574E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 float4x4(double v)
		{
			return new float4x4(v);
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00007556 File Offset: 0x00005756
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 float4x4(double4x4 v)
		{
			return new float4x4(v);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00007560 File Offset: 0x00005760
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 rotate(float4x4 a, float3 b)
		{
			return (a.c0 * b.x + a.c1 * b.y + a.c2 * b.z).xyz;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x000075B4 File Offset: 0x000057B4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 transform(float4x4 a, float3 b)
		{
			return (a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3).xyz;
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00007614 File Offset: 0x00005814
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 transpose(float4x4 v)
		{
			return math.float4x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w, v.c1.x, v.c1.y, v.c1.z, v.c1.w, v.c2.x, v.c2.y, v.c2.z, v.c2.w, v.c3.x, v.c3.y, v.c3.z, v.c3.w);
		}

		// Token: 0x0600022B RID: 555 RVA: 0x000076D8 File Offset: 0x000058D8
		public static float4x4 inverse(float4x4 m)
		{
			float4 c = m.c0;
			float4 c2 = m.c1;
			float4 c3 = m.c2;
			float4 c4 = m.c3;
			float4 @float = math.movelh(c2, c);
			float4 float2 = math.movelh(c3, c4);
			float4 float3 = math.movehl(c, c2);
			float4 float4 = math.movehl(c4, c3);
			float4 lhs = math.shuffle(c2, c, math.ShuffleComponent.LeftY, math.ShuffleComponent.LeftZ, math.ShuffleComponent.RightY, math.ShuffleComponent.RightZ);
			float4 lhs2 = math.shuffle(c3, c4, math.ShuffleComponent.LeftY, math.ShuffleComponent.LeftZ, math.ShuffleComponent.RightY, math.ShuffleComponent.RightZ);
			float4 lhs3 = math.shuffle(c2, c, math.ShuffleComponent.LeftW, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightW, math.ShuffleComponent.RightX);
			float4 lhs4 = math.shuffle(c3, c4, math.ShuffleComponent.LeftW, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightW, math.ShuffleComponent.RightX);
			float4 lhs5 = math.shuffle(float2, @float, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX, math.ShuffleComponent.RightZ);
			float4 lhs6 = math.shuffle(float2, @float, math.ShuffleComponent.LeftW, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightY, math.ShuffleComponent.RightW);
			float4 lhs7 = math.shuffle(float4, float3, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX, math.ShuffleComponent.RightZ);
			float4 lhs8 = math.shuffle(float4, float3, math.ShuffleComponent.LeftW, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightY, math.ShuffleComponent.RightW);
			float4 lhs9 = math.shuffle(@float, float2, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX, math.ShuffleComponent.RightZ);
			float4 float5 = lhs * float4 - lhs2 * float3;
			float4 float6 = @float * float4 - float2 * float3;
			float4 float7 = lhs4 * @float - lhs3 * float2;
			float4 rhs = math.shuffle(float5, float5, math.ShuffleComponent.LeftX, math.ShuffleComponent.LeftZ, math.ShuffleComponent.RightZ, math.ShuffleComponent.RightX);
			float4 rhs2 = math.shuffle(float5, float5, math.ShuffleComponent.LeftY, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightW, math.ShuffleComponent.RightY);
			float4 rhs3 = math.shuffle(float6, float6, math.ShuffleComponent.LeftX, math.ShuffleComponent.LeftZ, math.ShuffleComponent.RightZ, math.ShuffleComponent.RightX);
			float4 rhs4 = math.shuffle(float6, float6, math.ShuffleComponent.LeftY, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightW, math.ShuffleComponent.RightY);
			float4 float8 = lhs8 * rhs - lhs7 * rhs4 + lhs6 * rhs2;
			float4 float9 = lhs9 * float8;
			float9 += math.shuffle(float9, float9, math.ShuffleComponent.LeftY, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightW, math.ShuffleComponent.RightZ);
			float9 -= math.shuffle(float9, float9, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftZ, math.ShuffleComponent.RightX, math.ShuffleComponent.RightX);
			float4 rhs5 = math.float4(1f) / float9;
			float4x4 result;
			result.c0 = float8 * rhs5;
			float4 rhs6 = math.shuffle(float7, float7, math.ShuffleComponent.LeftX, math.ShuffleComponent.LeftZ, math.ShuffleComponent.RightZ, math.ShuffleComponent.RightX);
			float4 rhs7 = math.shuffle(float7, float7, math.ShuffleComponent.LeftY, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightW, math.ShuffleComponent.RightY);
			float4 lhs10 = lhs7 * rhs6 - lhs5 * rhs2 - lhs8 * rhs3;
			result.c1 = lhs10 * rhs5;
			float4 lhs11 = lhs5 * rhs4 - lhs6 * rhs6 - lhs8 * rhs7;
			result.c2 = lhs11 * rhs5;
			float4 lhs12 = lhs6 * rhs3 - lhs5 * rhs + lhs7 * rhs7;
			result.c3 = lhs12 * rhs5;
			return result;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00007968 File Offset: 0x00005B68
		public static float4x4 fastinverse(float4x4 m)
		{
			float4 c = m.c0;
			float4 c2 = m.c1;
			float4 c3 = m.c2;
			float4 @float = m.c3;
			float4 b = math.float4(0);
			float4 a = math.unpacklo(c, c3);
			float4 b2 = math.unpacklo(c2, b);
			float4 a2 = math.unpackhi(c, c3);
			float4 b3 = math.unpackhi(c2, b);
			float4 float2 = math.unpacklo(a, b2);
			float4 float3 = math.unpackhi(a, b2);
			float4 float4 = math.unpacklo(a2, b3);
			@float = -(float2 * @float.x + float3 * @float.y + float4 * @float.z);
			@float.w = 1f;
			return math.float4x4(float2, float3, float4, @float);
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00007A28 File Offset: 0x00005C28
		public static float determinant(float4x4 m)
		{
			float4 c = m.c0;
			float4 c2 = m.c1;
			float4 c3 = m.c2;
			float4 c4 = m.c3;
			float num = c2.y * (c3.z * c4.w - c3.w * c4.z) - c3.y * (c2.z * c4.w - c2.w * c4.z) + c4.y * (c2.z * c3.w - c2.w * c3.z);
			float num2 = c.y * (c3.z * c4.w - c3.w * c4.z) - c3.y * (c.z * c4.w - c.w * c4.z) + c4.y * (c.z * c3.w - c.w * c3.z);
			float num3 = c.y * (c2.z * c4.w - c2.w * c4.z) - c2.y * (c.z * c4.w - c.w * c4.z) + c4.y * (c.z * c2.w - c.w * c2.z);
			float num4 = c.y * (c2.z * c3.w - c2.w * c3.z) - c2.y * (c.z * c3.w - c.w * c3.z) + c3.y * (c.z * c2.w - c.w * c2.z);
			return c.x * num - c2.x * num2 + c3.x * num3 - c4.x * num4;
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00007C20 File Offset: 0x00005E20
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(float4x4 v)
		{
			return math.csum(math.asuint(v.c0) * math.uint4(3299952959U, 3121178323U, 2948522579U, 1531026433U) + math.asuint(v.c1) * math.uint4(1365086453U, 3969870067U, 4192899797U, 3271228601U) + math.asuint(v.c2) * math.uint4(1634639009U, 3318036811U, 3404170631U, 2048213449U) + math.asuint(v.c3) * math.uint4(4164671783U, 1780759499U, 1352369353U, 2446407751U)) + 1391928079U;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00007CEC File Offset: 0x00005EEC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(float4x4 v)
		{
			return math.asuint(v.c0) * math.uint4(3475533443U, 3777095341U, 3385463369U, 1773538433U) + math.asuint(v.c1) * math.uint4(3773525029U, 4131962539U, 1809525511U, 4016293529U) + math.asuint(v.c2) * math.uint4(2416021567U, 2828384717U, 2636362241U, 1258410977U) + math.asuint(v.c3) * math.uint4(1952565773U, 2037535609U, 3592785499U, 3996716183U) + 2626301701U;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00007DB6 File Offset: 0x00005FB6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half half(half x)
		{
			return new half(x);
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00007DBE File Offset: 0x00005FBE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half half(float v)
		{
			return new half(v);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00007DC6 File Offset: 0x00005FC6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half half(double v)
		{
			return new half(v);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00007DCE File Offset: 0x00005FCE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(half v)
		{
			return (uint)v.value * 1952372791U + 2171534173U;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00007DE2 File Offset: 0x00005FE2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half2 half2(half x, half y)
		{
			return new half2(x, y);
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00007DEB File Offset: 0x00005FEB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half2 half2(half2 xy)
		{
			return new half2(xy);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00007DF3 File Offset: 0x00005FF3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half2 half2(half v)
		{
			return new half2(v);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00007DFB File Offset: 0x00005FFB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half2 half2(float v)
		{
			return new half2(v);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00007E03 File Offset: 0x00006003
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half2 half2(float2 v)
		{
			return new half2(v);
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00007E0B File Offset: 0x0000600B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half2 half2(double v)
		{
			return new half2(v);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00007E13 File Offset: 0x00006013
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half2 half2(double2 v)
		{
			return new half2(v);
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00007E1B File Offset: 0x0000601B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(half2 v)
		{
			return math.csum(math.uint2((uint)v.x.value, (uint)v.y.value) * math.uint2(1851936439U, 1938025801U)) + 3712598587U;
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00007E57 File Offset: 0x00006057
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(half2 v)
		{
			return math.uint2((uint)v.x.value, (uint)v.y.value) * math.uint2(3956330501U, 2437373431U) + 1441286183U;
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00007E92 File Offset: 0x00006092
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half3 half3(half x, half y, half z)
		{
			return new half3(x, y, z);
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00007E9C File Offset: 0x0000609C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half3 half3(half x, half2 yz)
		{
			return new half3(x, yz);
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00007EA5 File Offset: 0x000060A5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half3 half3(half2 xy, half z)
		{
			return new half3(xy, z);
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00007EAE File Offset: 0x000060AE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half3 half3(half3 xyz)
		{
			return new half3(xyz);
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00007EB6 File Offset: 0x000060B6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half3 half3(half v)
		{
			return new half3(v);
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00007EBE File Offset: 0x000060BE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half3 half3(float v)
		{
			return new half3(v);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00007EC6 File Offset: 0x000060C6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half3 half3(float3 v)
		{
			return new half3(v);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00007ECE File Offset: 0x000060CE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half3 half3(double v)
		{
			return new half3(v);
		}

		// Token: 0x06000245 RID: 581 RVA: 0x00007ED6 File Offset: 0x000060D6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half3 half3(double3 v)
		{
			return new half3(v);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00007EE0 File Offset: 0x000060E0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(half3 v)
		{
			return math.csum(math.uint3((uint)v.x.value, (uint)v.y.value, (uint)v.z.value) * math.uint3(1750611407U, 3285396193U, 3110507567U)) + 4271396531U;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00007F38 File Offset: 0x00006138
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(half3 v)
		{
			return math.uint3((uint)v.x.value, (uint)v.y.value, (uint)v.z.value) * math.uint3(4198118021U, 2908068253U, 3705492289U) + 2497566569U;
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00007F8E File Offset: 0x0000618E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 half4(half x, half y, half z, half w)
		{
			return new half4(x, y, z, w);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00007F99 File Offset: 0x00006199
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 half4(half x, half y, half2 zw)
		{
			return new half4(x, y, zw);
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00007FA3 File Offset: 0x000061A3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 half4(half x, half2 yz, half w)
		{
			return new half4(x, yz, w);
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00007FAD File Offset: 0x000061AD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 half4(half x, half3 yzw)
		{
			return new half4(x, yzw);
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00007FB6 File Offset: 0x000061B6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 half4(half2 xy, half z, half w)
		{
			return new half4(xy, z, w);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00007FC0 File Offset: 0x000061C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 half4(half2 xy, half2 zw)
		{
			return new half4(xy, zw);
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00007FC9 File Offset: 0x000061C9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 half4(half3 xyz, half w)
		{
			return new half4(xyz, w);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00007FD2 File Offset: 0x000061D2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 half4(half4 xyzw)
		{
			return new half4(xyzw);
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00007FDA File Offset: 0x000061DA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 half4(half v)
		{
			return new half4(v);
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00007FE2 File Offset: 0x000061E2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 half4(float v)
		{
			return new half4(v);
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00007FEA File Offset: 0x000061EA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 half4(float4 v)
		{
			return new half4(v);
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00007FF2 File Offset: 0x000061F2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 half4(double v)
		{
			return new half4(v);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00007FFA File Offset: 0x000061FA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static half4 half4(double4 v)
		{
			return new half4(v);
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00008004 File Offset: 0x00006204
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(half4 v)
		{
			return math.csum(math.uint4((uint)v.x.value, (uint)v.y.value, (uint)v.z.value, (uint)v.w.value) * math.uint4(1952372791U, 2631698677U, 4200781601U, 2119021007U)) + 1760485621U;
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000806C File Offset: 0x0000626C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(half4 v)
		{
			return math.uint4((uint)v.x.value, (uint)v.y.value, (uint)v.z.value, (uint)v.w.value) * math.uint4(3157985881U, 2171534173U, 2723054263U, 1168253063U) + 4228926523U;
		}

		// Token: 0x06000257 RID: 599 RVA: 0x000080D2 File Offset: 0x000062D2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 int2(int x, int y)
		{
			return new int2(x, y);
		}

		// Token: 0x06000258 RID: 600 RVA: 0x000080DB File Offset: 0x000062DB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 int2(int2 xy)
		{
			return new int2(xy);
		}

		// Token: 0x06000259 RID: 601 RVA: 0x000080E3 File Offset: 0x000062E3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 int2(int v)
		{
			return new int2(v);
		}

		// Token: 0x0600025A RID: 602 RVA: 0x000080EB File Offset: 0x000062EB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 int2(bool v)
		{
			return new int2(v);
		}

		// Token: 0x0600025B RID: 603 RVA: 0x000080F3 File Offset: 0x000062F3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 int2(bool2 v)
		{
			return new int2(v);
		}

		// Token: 0x0600025C RID: 604 RVA: 0x000080FB File Offset: 0x000062FB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 int2(uint v)
		{
			return new int2(v);
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00008103 File Offset: 0x00006303
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 int2(uint2 v)
		{
			return new int2(v);
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000810B File Offset: 0x0000630B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 int2(float v)
		{
			return new int2(v);
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00008113 File Offset: 0x00006313
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 int2(float2 v)
		{
			return new int2(v);
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000811B File Offset: 0x0000631B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 int2(double v)
		{
			return new int2(v);
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00008123 File Offset: 0x00006323
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 int2(double2 v)
		{
			return new int2(v);
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000812B File Offset: 0x0000632B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(int2 v)
		{
			return math.csum(math.asuint(v) * math.uint2(2209710647U, 2201894441U)) + 2849577407U;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00008152 File Offset: 0x00006352
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(int2 v)
		{
			return math.asuint(v) * math.uint2(3287031191U, 3098675399U) + 1564399943U;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00008178 File Offset: 0x00006378
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int shuffle(int2 left, int2 right, math.ShuffleComponent x)
		{
			return math.select_shuffle_component(left, right, x);
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00008182 File Offset: 0x00006382
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 shuffle(int2 left, int2 right, math.ShuffleComponent x, math.ShuffleComponent y)
		{
			return math.int2(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y));
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00008199 File Offset: 0x00006399
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 shuffle(int2 left, int2 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
		{
			return math.int3(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z));
		}

		// Token: 0x06000267 RID: 615 RVA: 0x000081B9 File Offset: 0x000063B9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 shuffle(int2 left, int2 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
		{
			return math.int4(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z), math.select_shuffle_component(left, right, w));
		}

		// Token: 0x06000268 RID: 616 RVA: 0x000081E4 File Offset: 0x000063E4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int select_shuffle_component(int2 a, int2 b, math.ShuffleComponent component)
		{
			switch (component)
			{
			case math.ShuffleComponent.LeftX:
				return a.x;
			case math.ShuffleComponent.LeftY:
				return a.y;
			case math.ShuffleComponent.RightX:
				return b.x;
			case math.ShuffleComponent.RightY:
				return b.y;
			}
			throw new ArgumentException("Invalid shuffle component: " + component.ToString());
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00008249 File Offset: 0x00006449
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 int2x2(int2 c0, int2 c1)
		{
			return new int2x2(c0, c1);
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00008252 File Offset: 0x00006452
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 int2x2(int m00, int m01, int m10, int m11)
		{
			return new int2x2(m00, m01, m10, m11);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000825D File Offset: 0x0000645D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 int2x2(int v)
		{
			return new int2x2(v);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00008265 File Offset: 0x00006465
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 int2x2(bool v)
		{
			return new int2x2(v);
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000826D File Offset: 0x0000646D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 int2x2(bool2x2 v)
		{
			return new int2x2(v);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00008275 File Offset: 0x00006475
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 int2x2(uint v)
		{
			return new int2x2(v);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000827D File Offset: 0x0000647D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 int2x2(uint2x2 v)
		{
			return new int2x2(v);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00008285 File Offset: 0x00006485
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 int2x2(float v)
		{
			return new int2x2(v);
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000828D File Offset: 0x0000648D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 int2x2(float2x2 v)
		{
			return new int2x2(v);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00008295 File Offset: 0x00006495
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 int2x2(double v)
		{
			return new int2x2(v);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000829D File Offset: 0x0000649D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 int2x2(double2x2 v)
		{
			return new int2x2(v);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x000082A5 File Offset: 0x000064A5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 transpose(int2x2 v)
		{
			return math.int2x2(v.c0.x, v.c0.y, v.c1.x, v.c1.y);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x000082D8 File Offset: 0x000064D8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int determinant(int2x2 m)
		{
			int x = m.c0.x;
			int x2 = m.c1.x;
			int y = m.c0.y;
			int y2 = m.c1.y;
			return x * y2 - x2 * y;
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000831C File Offset: 0x0000651C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(int2x2 v)
		{
			return math.csum(math.asuint(v.c0) * math.uint2(3784421429U, 1750626223U) + math.asuint(v.c1) * math.uint2(3571447507U, 3412283213U)) + 2601761069U;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00008378 File Offset: 0x00006578
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(int2x2 v)
		{
			return math.asuint(v.c0) * math.uint2(1254033427U, 2248573027U) + math.asuint(v.c1) * math.uint2(3612677113U, 1521739981U) + 1735296007U;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x000083D2 File Offset: 0x000065D2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 int2x3(int2 c0, int2 c1, int2 c2)
		{
			return new int2x3(c0, c1, c2);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x000083DC File Offset: 0x000065DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 int2x3(int m00, int m01, int m02, int m10, int m11, int m12)
		{
			return new int2x3(m00, m01, m02, m10, m11, m12);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x000083EB File Offset: 0x000065EB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 int2x3(int v)
		{
			return new int2x3(v);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x000083F3 File Offset: 0x000065F3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 int2x3(bool v)
		{
			return new int2x3(v);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x000083FB File Offset: 0x000065FB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 int2x3(bool2x3 v)
		{
			return new int2x3(v);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00008403 File Offset: 0x00006603
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 int2x3(uint v)
		{
			return new int2x3(v);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000840B File Offset: 0x0000660B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 int2x3(uint2x3 v)
		{
			return new int2x3(v);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00008413 File Offset: 0x00006613
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 int2x3(float v)
		{
			return new int2x3(v);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000841B File Offset: 0x0000661B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 int2x3(float2x3 v)
		{
			return new int2x3(v);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00008423 File Offset: 0x00006623
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 int2x3(double v)
		{
			return new int2x3(v);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000842B File Offset: 0x0000662B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 int2x3(double2x3 v)
		{
			return new int2x3(v);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00008434 File Offset: 0x00006634
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 transpose(int2x3 v)
		{
			return math.int3x2(v.c0.x, v.c0.y, v.c1.x, v.c1.y, v.c2.x, v.c2.y);
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00008488 File Offset: 0x00006688
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(int2x3 v)
		{
			return math.csum(math.asuint(v.c0) * math.uint2(3404170631U, 2048213449U) + math.asuint(v.c1) * math.uint2(4164671783U, 1780759499U) + math.asuint(v.c2) * math.uint2(1352369353U, 2446407751U)) + 1391928079U;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00008508 File Offset: 0x00006708
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(int2x3 v)
		{
			return math.asuint(v.c0) * math.uint2(3475533443U, 3777095341U) + math.asuint(v.c1) * math.uint2(3385463369U, 1773538433U) + math.asuint(v.c2) * math.uint2(3773525029U, 4131962539U) + 1809525511U;
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00008586 File Offset: 0x00006786
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 int2x4(int2 c0, int2 c1, int2 c2, int2 c3)
		{
			return new int2x4(c0, c1, c2, c3);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00008591 File Offset: 0x00006791
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 int2x4(int m00, int m01, int m02, int m03, int m10, int m11, int m12, int m13)
		{
			return new int2x4(m00, m01, m02, m03, m10, m11, m12, m13);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x000085A4 File Offset: 0x000067A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 int2x4(int v)
		{
			return new int2x4(v);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x000085AC File Offset: 0x000067AC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 int2x4(bool v)
		{
			return new int2x4(v);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x000085B4 File Offset: 0x000067B4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 int2x4(bool2x4 v)
		{
			return new int2x4(v);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x000085BC File Offset: 0x000067BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 int2x4(uint v)
		{
			return new int2x4(v);
		}

		// Token: 0x0600028C RID: 652 RVA: 0x000085C4 File Offset: 0x000067C4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 int2x4(uint2x4 v)
		{
			return new int2x4(v);
		}

		// Token: 0x0600028D RID: 653 RVA: 0x000085CC File Offset: 0x000067CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 int2x4(float v)
		{
			return new int2x4(v);
		}

		// Token: 0x0600028E RID: 654 RVA: 0x000085D4 File Offset: 0x000067D4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 int2x4(float2x4 v)
		{
			return new int2x4(v);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x000085DC File Offset: 0x000067DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 int2x4(double v)
		{
			return new int2x4(v);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x000085E4 File Offset: 0x000067E4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 int2x4(double2x4 v)
		{
			return new int2x4(v);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x000085EC File Offset: 0x000067EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 transpose(int2x4 v)
		{
			return math.int4x2(v.c0.x, v.c0.y, v.c1.x, v.c1.y, v.c2.x, v.c2.y, v.c3.x, v.c3.y);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00008658 File Offset: 0x00006858
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(int2x4 v)
		{
			return math.csum(math.asuint(v.c0) * math.uint2(2057338067U, 2942577577U) + math.asuint(v.c1) * math.uint2(2834440507U, 2671762487U) + math.asuint(v.c2) * math.uint2(2892026051U, 2455987759U) + math.asuint(v.c3) * math.uint2(3868600063U, 3170963179U)) + 2632835537U;
		}

		// Token: 0x06000293 RID: 659 RVA: 0x000086FC File Offset: 0x000068FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(int2x4 v)
		{
			return math.asuint(v.c0) * math.uint2(1136528209U, 2944626401U) + math.asuint(v.c1) * math.uint2(2972762423U, 1417889653U) + math.asuint(v.c2) * math.uint2(2080514593U, 2731544287U) + math.asuint(v.c3) * math.uint2(2828498809U, 2669441947U) + 1260114311U;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000879E File Offset: 0x0000699E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 int3(int x, int y, int z)
		{
			return new int3(x, y, z);
		}

		// Token: 0x06000295 RID: 661 RVA: 0x000087A8 File Offset: 0x000069A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 int3(int x, int2 yz)
		{
			return new int3(x, yz);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x000087B1 File Offset: 0x000069B1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 int3(int2 xy, int z)
		{
			return new int3(xy, z);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x000087BA File Offset: 0x000069BA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 int3(int3 xyz)
		{
			return new int3(xyz);
		}

		// Token: 0x06000298 RID: 664 RVA: 0x000087C2 File Offset: 0x000069C2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 int3(int v)
		{
			return new int3(v);
		}

		// Token: 0x06000299 RID: 665 RVA: 0x000087CA File Offset: 0x000069CA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 int3(bool v)
		{
			return new int3(v);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x000087D2 File Offset: 0x000069D2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 int3(bool3 v)
		{
			return new int3(v);
		}

		// Token: 0x0600029B RID: 667 RVA: 0x000087DA File Offset: 0x000069DA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 int3(uint v)
		{
			return new int3(v);
		}

		// Token: 0x0600029C RID: 668 RVA: 0x000087E2 File Offset: 0x000069E2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 int3(uint3 v)
		{
			return new int3(v);
		}

		// Token: 0x0600029D RID: 669 RVA: 0x000087EA File Offset: 0x000069EA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 int3(float v)
		{
			return new int3(v);
		}

		// Token: 0x0600029E RID: 670 RVA: 0x000087F2 File Offset: 0x000069F2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 int3(float3 v)
		{
			return new int3(v);
		}

		// Token: 0x0600029F RID: 671 RVA: 0x000087FA File Offset: 0x000069FA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 int3(double v)
		{
			return new int3(v);
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00008802 File Offset: 0x00006A02
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 int3(double3 v)
		{
			return new int3(v);
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000880A File Offset: 0x00006A0A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(int3 v)
		{
			return math.csum(math.asuint(v) * math.uint3(1283419601U, 1210229737U, 2864955997U)) + 3525118277U;
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00008836 File Offset: 0x00006A36
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(int3 v)
		{
			return math.asuint(v) * math.uint3(2298260269U, 1632478733U, 1537393931U) + 2353355467U;
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00008861 File Offset: 0x00006A61
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int shuffle(int3 left, int3 right, math.ShuffleComponent x)
		{
			return math.select_shuffle_component(left, right, x);
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000886B File Offset: 0x00006A6B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 shuffle(int3 left, int3 right, math.ShuffleComponent x, math.ShuffleComponent y)
		{
			return math.int2(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y));
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00008882 File Offset: 0x00006A82
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 shuffle(int3 left, int3 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
		{
			return math.int3(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z));
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x000088A2 File Offset: 0x00006AA2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 shuffle(int3 left, int3 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
		{
			return math.int4(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z), math.select_shuffle_component(left, right, w));
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x000088CC File Offset: 0x00006ACC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int select_shuffle_component(int3 a, int3 b, math.ShuffleComponent component)
		{
			switch (component)
			{
			case math.ShuffleComponent.LeftX:
				return a.x;
			case math.ShuffleComponent.LeftY:
				return a.y;
			case math.ShuffleComponent.LeftZ:
				return a.z;
			case math.ShuffleComponent.RightX:
				return b.x;
			case math.ShuffleComponent.RightY:
				return b.y;
			case math.ShuffleComponent.RightZ:
				return b.z;
			}
			throw new ArgumentException("Invalid shuffle component: " + component.ToString());
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00008943 File Offset: 0x00006B43
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 int3x2(int3 c0, int3 c1)
		{
			return new int3x2(c0, c1);
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000894C File Offset: 0x00006B4C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 int3x2(int m00, int m01, int m10, int m11, int m20, int m21)
		{
			return new int3x2(m00, m01, m10, m11, m20, m21);
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000895B File Offset: 0x00006B5B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 int3x2(int v)
		{
			return new int3x2(v);
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00008963 File Offset: 0x00006B63
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 int3x2(bool v)
		{
			return new int3x2(v);
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000896B File Offset: 0x00006B6B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 int3x2(bool3x2 v)
		{
			return new int3x2(v);
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00008973 File Offset: 0x00006B73
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 int3x2(uint v)
		{
			return new int3x2(v);
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000897B File Offset: 0x00006B7B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 int3x2(uint3x2 v)
		{
			return new int3x2(v);
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00008983 File Offset: 0x00006B83
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 int3x2(float v)
		{
			return new int3x2(v);
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000898B File Offset: 0x00006B8B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 int3x2(float3x2 v)
		{
			return new int3x2(v);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00008993 File Offset: 0x00006B93
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 int3x2(double v)
		{
			return new int3x2(v);
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000899B File Offset: 0x00006B9B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 int3x2(double3x2 v)
		{
			return new int3x2(v);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x000089A4 File Offset: 0x00006BA4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 transpose(int3x2 v)
		{
			return math.int2x3(v.c0.x, v.c0.y, v.c0.z, v.c1.x, v.c1.y, v.c1.z);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x000089F8 File Offset: 0x00006BF8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(int3x2 v)
		{
			return math.csum(math.asuint(v.c0) * math.uint3(3678265601U, 2070747979U, 1480171127U) + math.asuint(v.c1) * math.uint3(1588341193U, 4234155257U, 1811310911U)) + 2635799963U;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00008A60 File Offset: 0x00006C60
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(int3x2 v)
		{
			return math.asuint(v.c0) * math.uint3(4165137857U, 2759770933U, 2759319383U) + math.asuint(v.c1) * math.uint3(3299952959U, 3121178323U, 2948522579U) + 1531026433U;
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00008AC4 File Offset: 0x00006CC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 int3x3(int3 c0, int3 c1, int3 c2)
		{
			return new int3x3(c0, c1, c2);
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00008AD0 File Offset: 0x00006CD0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 int3x3(int m00, int m01, int m02, int m10, int m11, int m12, int m20, int m21, int m22)
		{
			return new int3x3(m00, m01, m02, m10, m11, m12, m20, m21, m22);
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00008AF0 File Offset: 0x00006CF0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 int3x3(int v)
		{
			return new int3x3(v);
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00008AF8 File Offset: 0x00006CF8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 int3x3(bool v)
		{
			return new int3x3(v);
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00008B00 File Offset: 0x00006D00
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 int3x3(bool3x3 v)
		{
			return new int3x3(v);
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00008B08 File Offset: 0x00006D08
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 int3x3(uint v)
		{
			return new int3x3(v);
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00008B10 File Offset: 0x00006D10
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 int3x3(uint3x3 v)
		{
			return new int3x3(v);
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00008B18 File Offset: 0x00006D18
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 int3x3(float v)
		{
			return new int3x3(v);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00008B20 File Offset: 0x00006D20
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 int3x3(float3x3 v)
		{
			return new int3x3(v);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x00008B28 File Offset: 0x00006D28
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 int3x3(double v)
		{
			return new int3x3(v);
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00008B30 File Offset: 0x00006D30
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 int3x3(double3x3 v)
		{
			return new int3x3(v);
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00008B38 File Offset: 0x00006D38
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 transpose(int3x3 v)
		{
			return math.int3x3(v.c0.x, v.c0.y, v.c0.z, v.c1.x, v.c1.y, v.c1.z, v.c2.x, v.c2.y, v.c2.z);
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00008BB0 File Offset: 0x00006DB0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int determinant(int3x3 m)
		{
			int3 c = m.c0;
			int3 c2 = m.c1;
			int3 c3 = m.c2;
			int num = c2.y * c3.z - c2.z * c3.y;
			int num2 = c.y * c3.z - c.z * c3.y;
			int num3 = c.y * c2.z - c.z * c2.y;
			return c.x * num - c2.x * num2 + c3.x * num3;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x00008C44 File Offset: 0x00006E44
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(int3x3 v)
		{
			return math.csum(math.asuint(v.c0) * math.uint3(2479033387U, 3702457169U, 1845824257U) + math.asuint(v.c1) * math.uint3(1963973621U, 2134758553U, 1391111867U) + math.asuint(v.c2) * math.uint3(1167706003U, 2209736489U, 3261535807U)) + 1740411209U;
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00008CD4 File Offset: 0x00006ED4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(int3x3 v)
		{
			return math.asuint(v.c0) * math.uint3(2910609089U, 2183822701U, 3029516053U) + math.asuint(v.c1) * math.uint3(3547472099U, 2057487037U, 3781937309U) + math.asuint(v.c2) * math.uint3(2057338067U, 2942577577U, 2834440507U) + 2671762487U;
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00008D61 File Offset: 0x00006F61
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 int3x4(int3 c0, int3 c1, int3 c2, int3 c3)
		{
			return new int3x4(c0, c1, c2, c3);
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x00008D6C File Offset: 0x00006F6C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 int3x4(int m00, int m01, int m02, int m03, int m10, int m11, int m12, int m13, int m20, int m21, int m22, int m23)
		{
			return new int3x4(m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23);
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00008D92 File Offset: 0x00006F92
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 int3x4(int v)
		{
			return new int3x4(v);
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x00008D9A File Offset: 0x00006F9A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 int3x4(bool v)
		{
			return new int3x4(v);
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00008DA2 File Offset: 0x00006FA2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 int3x4(bool3x4 v)
		{
			return new int3x4(v);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00008DAA File Offset: 0x00006FAA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 int3x4(uint v)
		{
			return new int3x4(v);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x00008DB2 File Offset: 0x00006FB2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 int3x4(uint3x4 v)
		{
			return new int3x4(v);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00008DBA File Offset: 0x00006FBA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 int3x4(float v)
		{
			return new int3x4(v);
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00008DC2 File Offset: 0x00006FC2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 int3x4(float3x4 v)
		{
			return new int3x4(v);
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00008DCA File Offset: 0x00006FCA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 int3x4(double v)
		{
			return new int3x4(v);
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00008DD2 File Offset: 0x00006FD2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 int3x4(double3x4 v)
		{
			return new int3x4(v);
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00008DDC File Offset: 0x00006FDC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 transpose(int3x4 v)
		{
			return math.int4x3(v.c0.x, v.c0.y, v.c0.z, v.c1.x, v.c1.y, v.c1.z, v.c2.x, v.c2.y, v.c2.z, v.c3.x, v.c3.y, v.c3.z);
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00008E74 File Offset: 0x00007074
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(int3x4 v)
		{
			return math.csum(math.asuint(v.c0) * math.uint3(1521739981U, 1735296007U, 3010324327U) + math.asuint(v.c1) * math.uint3(1875523709U, 2937008387U, 3835713223U) + math.asuint(v.c2) * math.uint3(2216526373U, 3375971453U, 3559829411U) + math.asuint(v.c3) * math.uint3(3652178029U, 2544260129U, 2013864031U)) + 2627668003U;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00008F2C File Offset: 0x0000712C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(int3x4 v)
		{
			return math.asuint(v.c0) * math.uint3(1520214331U, 2949502447U, 2827819133U) + math.asuint(v.c1) * math.uint3(3480140317U, 2642994593U, 3940484981U) + math.asuint(v.c2) * math.uint3(1954192763U, 1091696537U, 3052428017U) + math.asuint(v.c3) * math.uint3(4253034763U, 2338696631U, 3757372771U) + 1885959949U;
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00008FE2 File Offset: 0x000071E2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 int4(int x, int y, int z, int w)
		{
			return new int4(x, y, z, w);
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00008FED File Offset: 0x000071ED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 int4(int x, int y, int2 zw)
		{
			return new int4(x, y, zw);
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x00008FF7 File Offset: 0x000071F7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 int4(int x, int2 yz, int w)
		{
			return new int4(x, yz, w);
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00009001 File Offset: 0x00007201
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 int4(int x, int3 yzw)
		{
			return new int4(x, yzw);
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000900A File Offset: 0x0000720A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 int4(int2 xy, int z, int w)
		{
			return new int4(xy, z, w);
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00009014 File Offset: 0x00007214
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 int4(int2 xy, int2 zw)
		{
			return new int4(xy, zw);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000901D File Offset: 0x0000721D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 int4(int3 xyz, int w)
		{
			return new int4(xyz, w);
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00009026 File Offset: 0x00007226
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 int4(int4 xyzw)
		{
			return new int4(xyzw);
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000902E File Offset: 0x0000722E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 int4(int v)
		{
			return new int4(v);
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00009036 File Offset: 0x00007236
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 int4(bool v)
		{
			return new int4(v);
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0000903E File Offset: 0x0000723E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 int4(bool4 v)
		{
			return new int4(v);
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00009046 File Offset: 0x00007246
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 int4(uint v)
		{
			return new int4(v);
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000904E File Offset: 0x0000724E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 int4(uint4 v)
		{
			return new int4(v);
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00009056 File Offset: 0x00007256
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 int4(float v)
		{
			return new int4(v);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000905E File Offset: 0x0000725E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 int4(float4 v)
		{
			return new int4(v);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00009066 File Offset: 0x00007266
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 int4(double v)
		{
			return new int4(v);
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000906E File Offset: 0x0000726E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 int4(double4 v)
		{
			return new int4(v);
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00009076 File Offset: 0x00007276
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(int4 v)
		{
			return math.csum(math.asuint(v) * math.uint4(1845824257U, 1963973621U, 2134758553U, 1391111867U)) + 1167706003U;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x000090A7 File Offset: 0x000072A7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(int4 v)
		{
			return math.asuint(v) * math.uint4(2209736489U, 3261535807U, 1740411209U, 2910609089U) + 2183822701U;
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x000090D7 File Offset: 0x000072D7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int shuffle(int4 left, int4 right, math.ShuffleComponent x)
		{
			return math.select_shuffle_component(left, right, x);
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x000090E1 File Offset: 0x000072E1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 shuffle(int4 left, int4 right, math.ShuffleComponent x, math.ShuffleComponent y)
		{
			return math.int2(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y));
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x000090F8 File Offset: 0x000072F8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 shuffle(int4 left, int4 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
		{
			return math.int3(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z));
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00009118 File Offset: 0x00007318
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 shuffle(int4 left, int4 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
		{
			return math.int4(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z), math.select_shuffle_component(left, right, w));
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00009144 File Offset: 0x00007344
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int select_shuffle_component(int4 a, int4 b, math.ShuffleComponent component)
		{
			switch (component)
			{
			case math.ShuffleComponent.LeftX:
				return a.x;
			case math.ShuffleComponent.LeftY:
				return a.y;
			case math.ShuffleComponent.LeftZ:
				return a.z;
			case math.ShuffleComponent.LeftW:
				return a.w;
			case math.ShuffleComponent.RightX:
				return b.x;
			case math.ShuffleComponent.RightY:
				return b.y;
			case math.ShuffleComponent.RightZ:
				return b.z;
			case math.ShuffleComponent.RightW:
				return b.w;
			default:
				throw new ArgumentException("Invalid shuffle component: " + component.ToString());
			}
		}

		// Token: 0x060002EB RID: 747 RVA: 0x000091CD File Offset: 0x000073CD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 int4x2(int4 c0, int4 c1)
		{
			return new int4x2(c0, c1);
		}

		// Token: 0x060002EC RID: 748 RVA: 0x000091D6 File Offset: 0x000073D6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 int4x2(int m00, int m01, int m10, int m11, int m20, int m21, int m30, int m31)
		{
			return new int4x2(m00, m01, m10, m11, m20, m21, m30, m31);
		}

		// Token: 0x060002ED RID: 749 RVA: 0x000091E9 File Offset: 0x000073E9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 int4x2(int v)
		{
			return new int4x2(v);
		}

		// Token: 0x060002EE RID: 750 RVA: 0x000091F1 File Offset: 0x000073F1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 int4x2(bool v)
		{
			return new int4x2(v);
		}

		// Token: 0x060002EF RID: 751 RVA: 0x000091F9 File Offset: 0x000073F9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 int4x2(bool4x2 v)
		{
			return new int4x2(v);
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00009201 File Offset: 0x00007401
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 int4x2(uint v)
		{
			return new int4x2(v);
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00009209 File Offset: 0x00007409
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 int4x2(uint4x2 v)
		{
			return new int4x2(v);
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00009211 File Offset: 0x00007411
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 int4x2(float v)
		{
			return new int4x2(v);
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00009219 File Offset: 0x00007419
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 int4x2(float4x2 v)
		{
			return new int4x2(v);
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x00009221 File Offset: 0x00007421
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 int4x2(double v)
		{
			return new int4x2(v);
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00009229 File Offset: 0x00007429
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 int4x2(double4x2 v)
		{
			return new int4x2(v);
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00009234 File Offset: 0x00007434
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 transpose(int4x2 v)
		{
			return math.int2x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w, v.c1.x, v.c1.y, v.c1.z, v.c1.w);
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x000092A0 File Offset: 0x000074A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(int4x2 v)
		{
			return math.csum(math.asuint(v.c0) * math.uint4(4205774813U, 1650214333U, 3388112843U, 1831150513U) + math.asuint(v.c1) * math.uint4(1848374953U, 3430200247U, 2209710647U, 2201894441U)) + 2849577407U;
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00009310 File Offset: 0x00007510
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(int4x2 v)
		{
			return math.asuint(v.c0) * math.uint4(3287031191U, 3098675399U, 1564399943U, 1148435377U) + math.asuint(v.c1) * math.uint4(3416333663U, 1750611407U, 3285396193U, 3110507567U) + 4271396531U;
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0000937E File Offset: 0x0000757E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 int4x3(int4 c0, int4 c1, int4 c2)
		{
			return new int4x3(c0, c1, c2);
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00009388 File Offset: 0x00007588
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 int4x3(int m00, int m01, int m02, int m10, int m11, int m12, int m20, int m21, int m22, int m30, int m31, int m32)
		{
			return new int4x3(m00, m01, m02, m10, m11, m12, m20, m21, m22, m30, m31, m32);
		}

		// Token: 0x060002FB RID: 763 RVA: 0x000093AE File Offset: 0x000075AE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 int4x3(int v)
		{
			return new int4x3(v);
		}

		// Token: 0x060002FC RID: 764 RVA: 0x000093B6 File Offset: 0x000075B6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 int4x3(bool v)
		{
			return new int4x3(v);
		}

		// Token: 0x060002FD RID: 765 RVA: 0x000093BE File Offset: 0x000075BE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 int4x3(bool4x3 v)
		{
			return new int4x3(v);
		}

		// Token: 0x060002FE RID: 766 RVA: 0x000093C6 File Offset: 0x000075C6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 int4x3(uint v)
		{
			return new int4x3(v);
		}

		// Token: 0x060002FF RID: 767 RVA: 0x000093CE File Offset: 0x000075CE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 int4x3(uint4x3 v)
		{
			return new int4x3(v);
		}

		// Token: 0x06000300 RID: 768 RVA: 0x000093D6 File Offset: 0x000075D6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 int4x3(float v)
		{
			return new int4x3(v);
		}

		// Token: 0x06000301 RID: 769 RVA: 0x000093DE File Offset: 0x000075DE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 int4x3(float4x3 v)
		{
			return new int4x3(v);
		}

		// Token: 0x06000302 RID: 770 RVA: 0x000093E6 File Offset: 0x000075E6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 int4x3(double v)
		{
			return new int4x3(v);
		}

		// Token: 0x06000303 RID: 771 RVA: 0x000093EE File Offset: 0x000075EE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 int4x3(double4x3 v)
		{
			return new int4x3(v);
		}

		// Token: 0x06000304 RID: 772 RVA: 0x000093F8 File Offset: 0x000075F8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 transpose(int4x3 v)
		{
			return math.int3x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w, v.c1.x, v.c1.y, v.c1.z, v.c1.w, v.c2.x, v.c2.y, v.c2.z, v.c2.w);
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00009490 File Offset: 0x00007690
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(int4x3 v)
		{
			return math.csum(math.asuint(v.c0) * math.uint4(1773538433U, 3773525029U, 4131962539U, 1809525511U) + math.asuint(v.c1) * math.uint4(4016293529U, 2416021567U, 2828384717U, 2636362241U) + math.asuint(v.c2) * math.uint4(1258410977U, 1952565773U, 2037535609U, 3592785499U)) + 3996716183U;
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00009530 File Offset: 0x00007730
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(int4x3 v)
		{
			return math.asuint(v.c0) * math.uint4(2626301701U, 1306289417U, 2096137163U, 1548578029U) + math.asuint(v.c1) * math.uint4(4178800919U, 3898072289U, 4129428421U, 2631575897U) + math.asuint(v.c2) * math.uint4(2854656703U, 3578504047U, 4245178297U, 2173281923U) + 2973357649U;
		}

		// Token: 0x06000307 RID: 775 RVA: 0x000095CC File Offset: 0x000077CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 int4x4(int4 c0, int4 c1, int4 c2, int4 c3)
		{
			return new int4x4(c0, c1, c2, c3);
		}

		// Token: 0x06000308 RID: 776 RVA: 0x000095D8 File Offset: 0x000077D8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 int4x4(int m00, int m01, int m02, int m03, int m10, int m11, int m12, int m13, int m20, int m21, int m22, int m23, int m30, int m31, int m32, int m33)
		{
			return new int4x4(m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33);
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00009606 File Offset: 0x00007806
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 int4x4(int v)
		{
			return new int4x4(v);
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000960E File Offset: 0x0000780E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 int4x4(bool v)
		{
			return new int4x4(v);
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00009616 File Offset: 0x00007816
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 int4x4(bool4x4 v)
		{
			return new int4x4(v);
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0000961E File Offset: 0x0000781E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 int4x4(uint v)
		{
			return new int4x4(v);
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00009626 File Offset: 0x00007826
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 int4x4(uint4x4 v)
		{
			return new int4x4(v);
		}

		// Token: 0x0600030E RID: 782 RVA: 0x0000962E File Offset: 0x0000782E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 int4x4(float v)
		{
			return new int4x4(v);
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00009636 File Offset: 0x00007836
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 int4x4(float4x4 v)
		{
			return new int4x4(v);
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0000963E File Offset: 0x0000783E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 int4x4(double v)
		{
			return new int4x4(v);
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00009646 File Offset: 0x00007846
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 int4x4(double4x4 v)
		{
			return new int4x4(v);
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00009650 File Offset: 0x00007850
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 transpose(int4x4 v)
		{
			return math.int4x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w, v.c1.x, v.c1.y, v.c1.z, v.c1.w, v.c2.x, v.c2.y, v.c2.z, v.c2.w, v.c3.x, v.c3.y, v.c3.z, v.c3.w);
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00009714 File Offset: 0x00007914
		public static int determinant(int4x4 m)
		{
			int4 c = m.c0;
			int4 c2 = m.c1;
			int4 c3 = m.c2;
			int4 c4 = m.c3;
			int num = c2.y * (c3.z * c4.w - c3.w * c4.z) - c3.y * (c2.z * c4.w - c2.w * c4.z) + c4.y * (c2.z * c3.w - c2.w * c3.z);
			int num2 = c.y * (c3.z * c4.w - c3.w * c4.z) - c3.y * (c.z * c4.w - c.w * c4.z) + c4.y * (c.z * c3.w - c.w * c3.z);
			int num3 = c.y * (c2.z * c4.w - c2.w * c4.z) - c2.y * (c.z * c4.w - c.w * c4.z) + c4.y * (c.z * c2.w - c.w * c2.z);
			int num4 = c.y * (c2.z * c3.w - c2.w * c3.z) - c2.y * (c.z * c3.w - c.w * c3.z) + c3.y * (c.z * c2.w - c.w * c2.z);
			return c.x * num - c2.x * num2 + c3.x * num3 - c4.x * num4;
		}

		// Token: 0x06000314 RID: 788 RVA: 0x0000990C File Offset: 0x00007B0C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(int4x4 v)
		{
			return math.csum(math.asuint(v.c0) * math.uint4(1562056283U, 2265541847U, 1283419601U, 1210229737U) + math.asuint(v.c1) * math.uint4(2864955997U, 3525118277U, 2298260269U, 1632478733U) + math.asuint(v.c2) * math.uint4(1537393931U, 2353355467U, 3441847433U, 4052036147U) + math.asuint(v.c3) * math.uint4(2011389559U, 2252224297U, 3784421429U, 1750626223U)) + 3571447507U;
		}

		// Token: 0x06000315 RID: 789 RVA: 0x000099D8 File Offset: 0x00007BD8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(int4x4 v)
		{
			return math.asuint(v.c0) * math.uint4(3412283213U, 2601761069U, 1254033427U, 2248573027U) + math.asuint(v.c1) * math.uint4(3612677113U, 1521739981U, 1735296007U, 3010324327U) + math.asuint(v.c2) * math.uint4(1875523709U, 2937008387U, 3835713223U, 2216526373U) + math.asuint(v.c3) * math.uint4(3375971453U, 3559829411U, 3652178029U, 2544260129U) + 2013864031U;
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00009AA2 File Offset: 0x00007CA2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int asint(uint x)
		{
			return (int)x;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00009AA5 File Offset: 0x00007CA5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 asint(uint2 x)
		{
			return math.int2((int)x.x, (int)x.y);
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00009AB8 File Offset: 0x00007CB8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 asint(uint3 x)
		{
			return math.int3((int)x.x, (int)x.y, (int)x.z);
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00009AD1 File Offset: 0x00007CD1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 asint(uint4 x)
		{
			return math.int4((int)x.x, (int)x.y, (int)x.z, (int)x.w);
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00009AF0 File Offset: 0x00007CF0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int asint(float x)
		{
			math.IntFloatUnion intFloatUnion;
			intFloatUnion.intValue = 0;
			intFloatUnion.floatValue = x;
			return intFloatUnion.intValue;
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00009B13 File Offset: 0x00007D13
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 asint(float2 x)
		{
			return math.int2(math.asint(x.x), math.asint(x.y));
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00009B30 File Offset: 0x00007D30
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 asint(float3 x)
		{
			return math.int3(math.asint(x.x), math.asint(x.y), math.asint(x.z));
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00009B58 File Offset: 0x00007D58
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 asint(float4 x)
		{
			return math.int4(math.asint(x.x), math.asint(x.y), math.asint(x.z), math.asint(x.w));
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00009B8B File Offset: 0x00007D8B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint asuint(int x)
		{
			return (uint)x;
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00009B8E File Offset: 0x00007D8E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 asuint(int2 x)
		{
			return math.uint2((uint)x.x, (uint)x.y);
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00009BA1 File Offset: 0x00007DA1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 asuint(int3 x)
		{
			return math.uint3((uint)x.x, (uint)x.y, (uint)x.z);
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00009BBA File Offset: 0x00007DBA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 asuint(int4 x)
		{
			return math.uint4((uint)x.x, (uint)x.y, (uint)x.z, (uint)x.w);
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00009BD9 File Offset: 0x00007DD9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint asuint(float x)
		{
			return (uint)math.asint(x);
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00009BE1 File Offset: 0x00007DE1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 asuint(float2 x)
		{
			return math.uint2(math.asuint(x.x), math.asuint(x.y));
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00009BFE File Offset: 0x00007DFE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 asuint(float3 x)
		{
			return math.uint3(math.asuint(x.x), math.asuint(x.y), math.asuint(x.z));
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00009C26 File Offset: 0x00007E26
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 asuint(float4 x)
		{
			return math.uint4(math.asuint(x.x), math.asuint(x.y), math.asuint(x.z), math.asuint(x.w));
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00009C59 File Offset: 0x00007E59
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long aslong(ulong x)
		{
			return (long)x;
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00009C5C File Offset: 0x00007E5C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long aslong(double x)
		{
			math.LongDoubleUnion longDoubleUnion;
			longDoubleUnion.longValue = 0L;
			longDoubleUnion.doubleValue = x;
			return longDoubleUnion.longValue;
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00009C80 File Offset: 0x00007E80
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong asulong(long x)
		{
			return (ulong)x;
		}

		// Token: 0x06000329 RID: 809 RVA: 0x00009C83 File Offset: 0x00007E83
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong asulong(double x)
		{
			return (ulong)math.aslong(x);
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00009C8C File Offset: 0x00007E8C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float asfloat(int x)
		{
			math.IntFloatUnion intFloatUnion;
			intFloatUnion.floatValue = 0f;
			intFloatUnion.intValue = x;
			return intFloatUnion.floatValue;
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00009CB3 File Offset: 0x00007EB3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 asfloat(int2 x)
		{
			return math.float2(math.asfloat(x.x), math.asfloat(x.y));
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00009CD0 File Offset: 0x00007ED0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 asfloat(int3 x)
		{
			return math.float3(math.asfloat(x.x), math.asfloat(x.y), math.asfloat(x.z));
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00009CF8 File Offset: 0x00007EF8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 asfloat(int4 x)
		{
			return math.float4(math.asfloat(x.x), math.asfloat(x.y), math.asfloat(x.z), math.asfloat(x.w));
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00009D2B File Offset: 0x00007F2B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float asfloat(uint x)
		{
			return math.asfloat((int)x);
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00009D33 File Offset: 0x00007F33
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 asfloat(uint2 x)
		{
			return math.float2(math.asfloat(x.x), math.asfloat(x.y));
		}

		// Token: 0x06000330 RID: 816 RVA: 0x00009D50 File Offset: 0x00007F50
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 asfloat(uint3 x)
		{
			return math.float3(math.asfloat(x.x), math.asfloat(x.y), math.asfloat(x.z));
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00009D78 File Offset: 0x00007F78
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 asfloat(uint4 x)
		{
			return math.float4(math.asfloat(x.x), math.asfloat(x.y), math.asfloat(x.z), math.asfloat(x.w));
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00009DAC File Offset: 0x00007FAC
		public static int bitmask(bool4 value)
		{
			int num = 0;
			if (value.x)
			{
				num |= 1;
			}
			if (value.y)
			{
				num |= 2;
			}
			if (value.z)
			{
				num |= 4;
			}
			if (value.w)
			{
				num |= 8;
			}
			return num;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00009DEC File Offset: 0x00007FEC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double asdouble(long x)
		{
			math.LongDoubleUnion longDoubleUnion;
			longDoubleUnion.doubleValue = 0.0;
			longDoubleUnion.longValue = x;
			return longDoubleUnion.doubleValue;
		}

		// Token: 0x06000334 RID: 820 RVA: 0x00009E17 File Offset: 0x00008017
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double asdouble(ulong x)
		{
			return math.asdouble((long)x);
		}

		// Token: 0x06000335 RID: 821 RVA: 0x00009E1F File Offset: 0x0000801F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool isfinite(float x)
		{
			return math.abs(x) < float.PositiveInfinity;
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00009E2E File Offset: 0x0000802E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 isfinite(float2 x)
		{
			return math.abs(x) < float.PositiveInfinity;
		}

		// Token: 0x06000337 RID: 823 RVA: 0x00009E40 File Offset: 0x00008040
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 isfinite(float3 x)
		{
			return math.abs(x) < float.PositiveInfinity;
		}

		// Token: 0x06000338 RID: 824 RVA: 0x00009E52 File Offset: 0x00008052
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 isfinite(float4 x)
		{
			return math.abs(x) < float.PositiveInfinity;
		}

		// Token: 0x06000339 RID: 825 RVA: 0x00009E64 File Offset: 0x00008064
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool isfinite(double x)
		{
			return math.abs(x) < double.PositiveInfinity;
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00009E77 File Offset: 0x00008077
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 isfinite(double2 x)
		{
			return math.abs(x) < double.PositiveInfinity;
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00009E8D File Offset: 0x0000808D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 isfinite(double3 x)
		{
			return math.abs(x) < double.PositiveInfinity;
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00009EA3 File Offset: 0x000080A3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 isfinite(double4 x)
		{
			return math.abs(x) < double.PositiveInfinity;
		}

		// Token: 0x0600033D RID: 829 RVA: 0x00009EB9 File Offset: 0x000080B9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool isinf(float x)
		{
			return math.abs(x) == float.PositiveInfinity;
		}

		// Token: 0x0600033E RID: 830 RVA: 0x00009EC8 File Offset: 0x000080C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 isinf(float2 x)
		{
			return math.abs(x) == float.PositiveInfinity;
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00009EDA File Offset: 0x000080DA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 isinf(float3 x)
		{
			return math.abs(x) == float.PositiveInfinity;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00009EEC File Offset: 0x000080EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 isinf(float4 x)
		{
			return math.abs(x) == float.PositiveInfinity;
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00009EFE File Offset: 0x000080FE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool isinf(double x)
		{
			return math.abs(x) == double.PositiveInfinity;
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00009F11 File Offset: 0x00008111
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 isinf(double2 x)
		{
			return math.abs(x) == double.PositiveInfinity;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00009F27 File Offset: 0x00008127
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 isinf(double3 x)
		{
			return math.abs(x) == double.PositiveInfinity;
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00009F3D File Offset: 0x0000813D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 isinf(double4 x)
		{
			return math.abs(x) == double.PositiveInfinity;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00009F53 File Offset: 0x00008153
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool isnan(float x)
		{
			return (math.asuint(x) & 2147483647U) > 2139095040U;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00009F68 File Offset: 0x00008168
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 isnan(float2 x)
		{
			return (math.asuint(x) & 2147483647U) > 2139095040U;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00009F84 File Offset: 0x00008184
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 isnan(float3 x)
		{
			return (math.asuint(x) & 2147483647U) > 2139095040U;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00009FA0 File Offset: 0x000081A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 isnan(float4 x)
		{
			return (math.asuint(x) & 2147483647U) > 2139095040U;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00009FBC File Offset: 0x000081BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool isnan(double x)
		{
			return (math.asulong(x) & 9223372036854775807UL) > 9218868437227405312UL;
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00009FDC File Offset: 0x000081DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 isnan(double2 x)
		{
			return math.bool2((math.asulong(x.x) & 9223372036854775807UL) > 9218868437227405312UL, (math.asulong(x.y) & 9223372036854775807UL) > 9218868437227405312UL);
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0000A030 File Offset: 0x00008230
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 isnan(double3 x)
		{
			return math.bool3((math.asulong(x.x) & 9223372036854775807UL) > 9218868437227405312UL, (math.asulong(x.y) & 9223372036854775807UL) > 9218868437227405312UL, (math.asulong(x.z) & 9223372036854775807UL) > 9218868437227405312UL);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0000A0A4 File Offset: 0x000082A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 isnan(double4 x)
		{
			return math.bool4((math.asulong(x.x) & 9223372036854775807UL) > 9218868437227405312UL, (math.asulong(x.y) & 9223372036854775807UL) > 9218868437227405312UL, (math.asulong(x.z) & 9223372036854775807UL) > 9218868437227405312UL, (math.asulong(x.w) & 9223372036854775807UL) > 9218868437227405312UL);
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0000A136 File Offset: 0x00008336
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ispow2(int x)
		{
			return x > 0 && (x & x - 1) == 0;
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0000A146 File Offset: 0x00008346
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 ispow2(int2 x)
		{
			return new bool2(math.ispow2(x.x), math.ispow2(x.y));
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000A163 File Offset: 0x00008363
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 ispow2(int3 x)
		{
			return new bool3(math.ispow2(x.x), math.ispow2(x.y), math.ispow2(x.z));
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0000A18B File Offset: 0x0000838B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 ispow2(int4 x)
		{
			return new bool4(math.ispow2(x.x), math.ispow2(x.y), math.ispow2(x.z), math.ispow2(x.w));
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0000A1BE File Offset: 0x000083BE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ispow2(uint x)
		{
			return x > 0U && (x & x - 1U) == 0U;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0000A1CE File Offset: 0x000083CE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 ispow2(uint2 x)
		{
			return new bool2(math.ispow2(x.x), math.ispow2(x.y));
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0000A1EB File Offset: 0x000083EB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 ispow2(uint3 x)
		{
			return new bool3(math.ispow2(x.x), math.ispow2(x.y), math.ispow2(x.z));
		}

		// Token: 0x06000354 RID: 852 RVA: 0x0000A213 File Offset: 0x00008413
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 ispow2(uint4 x)
		{
			return new bool4(math.ispow2(x.x), math.ispow2(x.y), math.ispow2(x.z), math.ispow2(x.w));
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0000A246 File Offset: 0x00008446
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int min(int x, int y)
		{
			if (x >= y)
			{
				return y;
			}
			return x;
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0000A24F File Offset: 0x0000844F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 min(int2 x, int2 y)
		{
			return new int2(math.min(x.x, y.x), math.min(x.y, y.y));
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0000A278 File Offset: 0x00008478
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 min(int3 x, int3 y)
		{
			return new int3(math.min(x.x, y.x), math.min(x.y, y.y), math.min(x.z, y.z));
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0000A2B4 File Offset: 0x000084B4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 min(int4 x, int4 y)
		{
			return new int4(math.min(x.x, y.x), math.min(x.y, y.y), math.min(x.z, y.z), math.min(x.w, y.w));
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0000A30A File Offset: 0x0000850A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint min(uint x, uint y)
		{
			if (x >= y)
			{
				return y;
			}
			return x;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0000A313 File Offset: 0x00008513
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 min(uint2 x, uint2 y)
		{
			return new uint2(math.min(x.x, y.x), math.min(x.y, y.y));
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0000A33C File Offset: 0x0000853C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 min(uint3 x, uint3 y)
		{
			return new uint3(math.min(x.x, y.x), math.min(x.y, y.y), math.min(x.z, y.z));
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0000A378 File Offset: 0x00008578
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 min(uint4 x, uint4 y)
		{
			return new uint4(math.min(x.x, y.x), math.min(x.y, y.y), math.min(x.z, y.z), math.min(x.w, y.w));
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0000A3CE File Offset: 0x000085CE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long min(long x, long y)
		{
			if (x >= y)
			{
				return y;
			}
			return x;
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0000A3D7 File Offset: 0x000085D7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong min(ulong x, ulong y)
		{
			if (x >= y)
			{
				return y;
			}
			return x;
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0000A3E0 File Offset: 0x000085E0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float min(float x, float y)
		{
			if (!float.IsNaN(y) && x >= y)
			{
				return y;
			}
			return x;
		}

		// Token: 0x06000360 RID: 864 RVA: 0x0000A3F1 File Offset: 0x000085F1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 min(float2 x, float2 y)
		{
			return new float2(math.min(x.x, y.x), math.min(x.y, y.y));
		}

		// Token: 0x06000361 RID: 865 RVA: 0x0000A41A File Offset: 0x0000861A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 min(float3 x, float3 y)
		{
			return new float3(math.min(x.x, y.x), math.min(x.y, y.y), math.min(x.z, y.z));
		}

		// Token: 0x06000362 RID: 866 RVA: 0x0000A454 File Offset: 0x00008654
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 min(float4 x, float4 y)
		{
			return new float4(math.min(x.x, y.x), math.min(x.y, y.y), math.min(x.z, y.z), math.min(x.w, y.w));
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0000A4AA File Offset: 0x000086AA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double min(double x, double y)
		{
			if (!double.IsNaN(y) && x >= y)
			{
				return y;
			}
			return x;
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0000A4BB File Offset: 0x000086BB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 min(double2 x, double2 y)
		{
			return new double2(math.min(x.x, y.x), math.min(x.y, y.y));
		}

		// Token: 0x06000365 RID: 869 RVA: 0x0000A4E4 File Offset: 0x000086E4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 min(double3 x, double3 y)
		{
			return new double3(math.min(x.x, y.x), math.min(x.y, y.y), math.min(x.z, y.z));
		}

		// Token: 0x06000366 RID: 870 RVA: 0x0000A520 File Offset: 0x00008720
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 min(double4 x, double4 y)
		{
			return new double4(math.min(x.x, y.x), math.min(x.y, y.y), math.min(x.z, y.z), math.min(x.w, y.w));
		}

		// Token: 0x06000367 RID: 871 RVA: 0x0000A576 File Offset: 0x00008776
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int max(int x, int y)
		{
			if (x <= y)
			{
				return y;
			}
			return x;
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0000A57F File Offset: 0x0000877F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 max(int2 x, int2 y)
		{
			return new int2(math.max(x.x, y.x), math.max(x.y, y.y));
		}

		// Token: 0x06000369 RID: 873 RVA: 0x0000A5A8 File Offset: 0x000087A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 max(int3 x, int3 y)
		{
			return new int3(math.max(x.x, y.x), math.max(x.y, y.y), math.max(x.z, y.z));
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0000A5E4 File Offset: 0x000087E4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 max(int4 x, int4 y)
		{
			return new int4(math.max(x.x, y.x), math.max(x.y, y.y), math.max(x.z, y.z), math.max(x.w, y.w));
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0000A63A File Offset: 0x0000883A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint max(uint x, uint y)
		{
			if (x <= y)
			{
				return y;
			}
			return x;
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0000A643 File Offset: 0x00008843
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 max(uint2 x, uint2 y)
		{
			return new uint2(math.max(x.x, y.x), math.max(x.y, y.y));
		}

		// Token: 0x0600036D RID: 877 RVA: 0x0000A66C File Offset: 0x0000886C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 max(uint3 x, uint3 y)
		{
			return new uint3(math.max(x.x, y.x), math.max(x.y, y.y), math.max(x.z, y.z));
		}

		// Token: 0x0600036E RID: 878 RVA: 0x0000A6A8 File Offset: 0x000088A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 max(uint4 x, uint4 y)
		{
			return new uint4(math.max(x.x, y.x), math.max(x.y, y.y), math.max(x.z, y.z), math.max(x.w, y.w));
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0000A6FE File Offset: 0x000088FE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long max(long x, long y)
		{
			if (x <= y)
			{
				return y;
			}
			return x;
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0000A707 File Offset: 0x00008907
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong max(ulong x, ulong y)
		{
			if (x <= y)
			{
				return y;
			}
			return x;
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0000A710 File Offset: 0x00008910
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float max(float x, float y)
		{
			if (!float.IsNaN(y) && x <= y)
			{
				return y;
			}
			return x;
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0000A721 File Offset: 0x00008921
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 max(float2 x, float2 y)
		{
			return new float2(math.max(x.x, y.x), math.max(x.y, y.y));
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0000A74A File Offset: 0x0000894A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 max(float3 x, float3 y)
		{
			return new float3(math.max(x.x, y.x), math.max(x.y, y.y), math.max(x.z, y.z));
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0000A784 File Offset: 0x00008984
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 max(float4 x, float4 y)
		{
			return new float4(math.max(x.x, y.x), math.max(x.y, y.y), math.max(x.z, y.z), math.max(x.w, y.w));
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0000A7DA File Offset: 0x000089DA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double max(double x, double y)
		{
			if (!double.IsNaN(y) && x <= y)
			{
				return y;
			}
			return x;
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0000A7EB File Offset: 0x000089EB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 max(double2 x, double2 y)
		{
			return new double2(math.max(x.x, y.x), math.max(x.y, y.y));
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0000A814 File Offset: 0x00008A14
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 max(double3 x, double3 y)
		{
			return new double3(math.max(x.x, y.x), math.max(x.y, y.y), math.max(x.z, y.z));
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0000A850 File Offset: 0x00008A50
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 max(double4 x, double4 y)
		{
			return new double4(math.max(x.x, y.x), math.max(x.y, y.y), math.max(x.z, y.z), math.max(x.w, y.w));
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0000A8A6 File Offset: 0x00008AA6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float lerp(float x, float y, float s)
		{
			return x + s * (y - x);
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0000A8AF File Offset: 0x00008AAF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 lerp(float2 x, float2 y, float s)
		{
			return x + s * (y - x);
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0000A8C4 File Offset: 0x00008AC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 lerp(float3 x, float3 y, float s)
		{
			return x + s * (y - x);
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0000A8D9 File Offset: 0x00008AD9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 lerp(float4 x, float4 y, float s)
		{
			return x + s * (y - x);
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0000A8EE File Offset: 0x00008AEE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 lerp(float2 x, float2 y, float2 s)
		{
			return x + s * (y - x);
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0000A903 File Offset: 0x00008B03
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 lerp(float3 x, float3 y, float3 s)
		{
			return x + s * (y - x);
		}

		// Token: 0x0600037F RID: 895 RVA: 0x0000A918 File Offset: 0x00008B18
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 lerp(float4 x, float4 y, float4 s)
		{
			return x + s * (y - x);
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0000A92D File Offset: 0x00008B2D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double lerp(double x, double y, double s)
		{
			return x + s * (y - x);
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0000A936 File Offset: 0x00008B36
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 lerp(double2 x, double2 y, double s)
		{
			return x + s * (y - x);
		}

		// Token: 0x06000382 RID: 898 RVA: 0x0000A94B File Offset: 0x00008B4B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 lerp(double3 x, double3 y, double s)
		{
			return x + s * (y - x);
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0000A960 File Offset: 0x00008B60
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 lerp(double4 x, double4 y, double s)
		{
			return x + s * (y - x);
		}

		// Token: 0x06000384 RID: 900 RVA: 0x0000A975 File Offset: 0x00008B75
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 lerp(double2 x, double2 y, double2 s)
		{
			return x + s * (y - x);
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0000A98A File Offset: 0x00008B8A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 lerp(double3 x, double3 y, double3 s)
		{
			return x + s * (y - x);
		}

		// Token: 0x06000386 RID: 902 RVA: 0x0000A99F File Offset: 0x00008B9F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 lerp(double4 x, double4 y, double4 s)
		{
			return x + s * (y - x);
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0000A9B4 File Offset: 0x00008BB4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float unlerp(float a, float b, float x)
		{
			return (x - a) / (b - a);
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0000A9BD File Offset: 0x00008BBD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 unlerp(float2 a, float2 b, float2 x)
		{
			return (x - a) / (b - a);
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0000A9D2 File Offset: 0x00008BD2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 unlerp(float3 a, float3 b, float3 x)
		{
			return (x - a) / (b - a);
		}

		// Token: 0x0600038A RID: 906 RVA: 0x0000A9E7 File Offset: 0x00008BE7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 unlerp(float4 a, float4 b, float4 x)
		{
			return (x - a) / (b - a);
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0000A9FC File Offset: 0x00008BFC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double unlerp(double a, double b, double x)
		{
			return (x - a) / (b - a);
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0000AA05 File Offset: 0x00008C05
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 unlerp(double2 a, double2 b, double2 x)
		{
			return (x - a) / (b - a);
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0000AA1A File Offset: 0x00008C1A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 unlerp(double3 a, double3 b, double3 x)
		{
			return (x - a) / (b - a);
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0000AA2F File Offset: 0x00008C2F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 unlerp(double4 a, double4 b, double4 x)
		{
			return (x - a) / (b - a);
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0000AA44 File Offset: 0x00008C44
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float remap(float a, float b, float c, float d, float x)
		{
			return math.lerp(c, d, math.unlerp(a, b, x));
		}

		// Token: 0x06000390 RID: 912 RVA: 0x0000AA56 File Offset: 0x00008C56
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 remap(float2 a, float2 b, float2 c, float2 d, float2 x)
		{
			return math.lerp(c, d, math.unlerp(a, b, x));
		}

		// Token: 0x06000391 RID: 913 RVA: 0x0000AA68 File Offset: 0x00008C68
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 remap(float3 a, float3 b, float3 c, float3 d, float3 x)
		{
			return math.lerp(c, d, math.unlerp(a, b, x));
		}

		// Token: 0x06000392 RID: 914 RVA: 0x0000AA7A File Offset: 0x00008C7A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 remap(float4 a, float4 b, float4 c, float4 d, float4 x)
		{
			return math.lerp(c, d, math.unlerp(a, b, x));
		}

		// Token: 0x06000393 RID: 915 RVA: 0x0000AA8C File Offset: 0x00008C8C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double remap(double a, double b, double c, double d, double x)
		{
			return math.lerp(c, d, math.unlerp(a, b, x));
		}

		// Token: 0x06000394 RID: 916 RVA: 0x0000AA9E File Offset: 0x00008C9E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 remap(double2 a, double2 b, double2 c, double2 d, double2 x)
		{
			return math.lerp(c, d, math.unlerp(a, b, x));
		}

		// Token: 0x06000395 RID: 917 RVA: 0x0000AAB0 File Offset: 0x00008CB0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 remap(double3 a, double3 b, double3 c, double3 d, double3 x)
		{
			return math.lerp(c, d, math.unlerp(a, b, x));
		}

		// Token: 0x06000396 RID: 918 RVA: 0x0000AAC2 File Offset: 0x00008CC2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 remap(double4 a, double4 b, double4 c, double4 d, double4 x)
		{
			return math.lerp(c, d, math.unlerp(a, b, x));
		}

		// Token: 0x06000397 RID: 919 RVA: 0x0000AAD4 File Offset: 0x00008CD4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int mad(int a, int b, int c)
		{
			return a * b + c;
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0000AADB File Offset: 0x00008CDB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 mad(int2 a, int2 b, int2 c)
		{
			return a * b + c;
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0000AAEA File Offset: 0x00008CEA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 mad(int3 a, int3 b, int3 c)
		{
			return a * b + c;
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0000AAF9 File Offset: 0x00008CF9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 mad(int4 a, int4 b, int4 c)
		{
			return a * b + c;
		}

		// Token: 0x0600039B RID: 923 RVA: 0x0000AB08 File Offset: 0x00008D08
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint mad(uint a, uint b, uint c)
		{
			return a * b + c;
		}

		// Token: 0x0600039C RID: 924 RVA: 0x0000AB0F File Offset: 0x00008D0F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 mad(uint2 a, uint2 b, uint2 c)
		{
			return a * b + c;
		}

		// Token: 0x0600039D RID: 925 RVA: 0x0000AB1E File Offset: 0x00008D1E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 mad(uint3 a, uint3 b, uint3 c)
		{
			return a * b + c;
		}

		// Token: 0x0600039E RID: 926 RVA: 0x0000AB2D File Offset: 0x00008D2D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 mad(uint4 a, uint4 b, uint4 c)
		{
			return a * b + c;
		}

		// Token: 0x0600039F RID: 927 RVA: 0x0000AB3C File Offset: 0x00008D3C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long mad(long a, long b, long c)
		{
			return a * b + c;
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x0000AB43 File Offset: 0x00008D43
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong mad(ulong a, ulong b, ulong c)
		{
			return a * b + c;
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x0000AB4A File Offset: 0x00008D4A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float mad(float a, float b, float c)
		{
			return a * b + c;
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x0000AB51 File Offset: 0x00008D51
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 mad(float2 a, float2 b, float2 c)
		{
			return a * b + c;
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x0000AB60 File Offset: 0x00008D60
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 mad(float3 a, float3 b, float3 c)
		{
			return a * b + c;
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x0000AB6F File Offset: 0x00008D6F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 mad(float4 a, float4 b, float4 c)
		{
			return a * b + c;
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x0000AB7E File Offset: 0x00008D7E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double mad(double a, double b, double c)
		{
			return a * b + c;
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x0000AB85 File Offset: 0x00008D85
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 mad(double2 a, double2 b, double2 c)
		{
			return a * b + c;
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x0000AB94 File Offset: 0x00008D94
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 mad(double3 a, double3 b, double3 c)
		{
			return a * b + c;
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0000ABA3 File Offset: 0x00008DA3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 mad(double4 a, double4 b, double4 c)
		{
			return a * b + c;
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x0000ABB2 File Offset: 0x00008DB2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int clamp(int x, int a, int b)
		{
			return math.max(a, math.min(b, x));
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0000ABC1 File Offset: 0x00008DC1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 clamp(int2 x, int2 a, int2 b)
		{
			return math.max(a, math.min(b, x));
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0000ABD0 File Offset: 0x00008DD0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 clamp(int3 x, int3 a, int3 b)
		{
			return math.max(a, math.min(b, x));
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0000ABDF File Offset: 0x00008DDF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 clamp(int4 x, int4 a, int4 b)
		{
			return math.max(a, math.min(b, x));
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0000ABEE File Offset: 0x00008DEE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint clamp(uint x, uint a, uint b)
		{
			return math.max(a, math.min(b, x));
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0000ABFD File Offset: 0x00008DFD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 clamp(uint2 x, uint2 a, uint2 b)
		{
			return math.max(a, math.min(b, x));
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0000AC0C File Offset: 0x00008E0C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 clamp(uint3 x, uint3 a, uint3 b)
		{
			return math.max(a, math.min(b, x));
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0000AC1B File Offset: 0x00008E1B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 clamp(uint4 x, uint4 a, uint4 b)
		{
			return math.max(a, math.min(b, x));
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0000AC2A File Offset: 0x00008E2A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long clamp(long x, long a, long b)
		{
			return math.max(a, math.min(b, x));
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0000AC39 File Offset: 0x00008E39
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong clamp(ulong x, ulong a, ulong b)
		{
			return math.max(a, math.min(b, x));
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0000AC48 File Offset: 0x00008E48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float clamp(float x, float a, float b)
		{
			return math.max(a, math.min(b, x));
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0000AC57 File Offset: 0x00008E57
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 clamp(float2 x, float2 a, float2 b)
		{
			return math.max(a, math.min(b, x));
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0000AC66 File Offset: 0x00008E66
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 clamp(float3 x, float3 a, float3 b)
		{
			return math.max(a, math.min(b, x));
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0000AC75 File Offset: 0x00008E75
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 clamp(float4 x, float4 a, float4 b)
		{
			return math.max(a, math.min(b, x));
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0000AC84 File Offset: 0x00008E84
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double clamp(double x, double a, double b)
		{
			return math.max(a, math.min(b, x));
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0000AC93 File Offset: 0x00008E93
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 clamp(double2 x, double2 a, double2 b)
		{
			return math.max(a, math.min(b, x));
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0000ACA2 File Offset: 0x00008EA2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 clamp(double3 x, double3 a, double3 b)
		{
			return math.max(a, math.min(b, x));
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0000ACB1 File Offset: 0x00008EB1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 clamp(double4 x, double4 a, double4 b)
		{
			return math.max(a, math.min(b, x));
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0000ACC0 File Offset: 0x00008EC0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float saturate(float x)
		{
			return math.clamp(x, 0f, 1f);
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0000ACD2 File Offset: 0x00008ED2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 saturate(float2 x)
		{
			return math.clamp(x, new float2(0f), new float2(1f));
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0000ACEE File Offset: 0x00008EEE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 saturate(float3 x)
		{
			return math.clamp(x, new float3(0f), new float3(1f));
		}

		// Token: 0x060003BE RID: 958 RVA: 0x0000AD0A File Offset: 0x00008F0A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 saturate(float4 x)
		{
			return math.clamp(x, new float4(0f), new float4(1f));
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0000AD26 File Offset: 0x00008F26
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double saturate(double x)
		{
			return math.clamp(x, 0.0, 1.0);
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x0000AD40 File Offset: 0x00008F40
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 saturate(double2 x)
		{
			return math.clamp(x, new double2(0.0), new double2(1.0));
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x0000AD64 File Offset: 0x00008F64
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 saturate(double3 x)
		{
			return math.clamp(x, new double3(0.0), new double3(1.0));
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0000AD88 File Offset: 0x00008F88
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 saturate(double4 x)
		{
			return math.clamp(x, new double4(0.0), new double4(1.0));
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x0000ADAC File Offset: 0x00008FAC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int abs(int x)
		{
			return math.max(-x, x);
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0000ADB6 File Offset: 0x00008FB6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 abs(int2 x)
		{
			return math.max(-x, x);
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x0000ADC4 File Offset: 0x00008FC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 abs(int3 x)
		{
			return math.max(-x, x);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0000ADD2 File Offset: 0x00008FD2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 abs(int4 x)
		{
			return math.max(-x, x);
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0000ADE0 File Offset: 0x00008FE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long abs(long x)
		{
			return math.max(-x, x);
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x0000ADEA File Offset: 0x00008FEA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float abs(float x)
		{
			return math.asfloat(math.asuint(x) & 2147483647U);
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0000ADFD File Offset: 0x00008FFD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 abs(float2 x)
		{
			return math.asfloat(math.asuint(x) & 2147483647U);
		}

		// Token: 0x060003CA RID: 970 RVA: 0x0000AE14 File Offset: 0x00009014
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 abs(float3 x)
		{
			return math.asfloat(math.asuint(x) & 2147483647U);
		}

		// Token: 0x060003CB RID: 971 RVA: 0x0000AE2B File Offset: 0x0000902B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 abs(float4 x)
		{
			return math.asfloat(math.asuint(x) & 2147483647U);
		}

		// Token: 0x060003CC RID: 972 RVA: 0x0000AE42 File Offset: 0x00009042
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double abs(double x)
		{
			return math.asdouble(math.asulong(x) & 9223372036854775807UL);
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0000AE59 File Offset: 0x00009059
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 abs(double2 x)
		{
			return math.double2(math.asdouble(math.asulong(x.x) & 9223372036854775807UL), math.asdouble(math.asulong(x.y) & 9223372036854775807UL));
		}

		// Token: 0x060003CE RID: 974 RVA: 0x0000AE94 File Offset: 0x00009094
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 abs(double3 x)
		{
			return math.double3(math.asdouble(math.asulong(x.x) & 9223372036854775807UL), math.asdouble(math.asulong(x.y) & 9223372036854775807UL), math.asdouble(math.asulong(x.z) & 9223372036854775807UL));
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0000AEF4 File Offset: 0x000090F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 abs(double4 x)
		{
			return math.double4(math.asdouble(math.asulong(x.x) & 9223372036854775807UL), math.asdouble(math.asulong(x.y) & 9223372036854775807UL), math.asdouble(math.asulong(x.z) & 9223372036854775807UL), math.asdouble(math.asulong(x.w) & 9223372036854775807UL));
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0000AF6E File Offset: 0x0000916E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int dot(int x, int y)
		{
			return x * y;
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0000AF73 File Offset: 0x00009173
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int dot(int2 x, int2 y)
		{
			return x.x * y.x + x.y * y.y;
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x0000AF90 File Offset: 0x00009190
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int dot(int3 x, int3 y)
		{
			return x.x * y.x + x.y * y.y + x.z * y.z;
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0000AFBB File Offset: 0x000091BB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int dot(int4 x, int4 y)
		{
			return x.x * y.x + x.y * y.y + x.z * y.z + x.w * y.w;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0000AFF4 File Offset: 0x000091F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint dot(uint x, uint y)
		{
			return x * y;
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0000AFF9 File Offset: 0x000091F9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint dot(uint2 x, uint2 y)
		{
			return x.x * y.x + x.y * y.y;
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x0000B016 File Offset: 0x00009216
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint dot(uint3 x, uint3 y)
		{
			return x.x * y.x + x.y * y.y + x.z * y.z;
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0000B041 File Offset: 0x00009241
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint dot(uint4 x, uint4 y)
		{
			return x.x * y.x + x.y * y.y + x.z * y.z + x.w * y.w;
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0000B07A File Offset: 0x0000927A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float dot(float x, float y)
		{
			return x * y;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0000B07F File Offset: 0x0000927F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float dot(float2 x, float2 y)
		{
			return x.x * y.x + x.y * y.y;
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0000B09C File Offset: 0x0000929C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float dot(float3 x, float3 y)
		{
			return x.x * y.x + x.y * y.y + x.z * y.z;
		}

		// Token: 0x060003DB RID: 987 RVA: 0x0000B0C7 File Offset: 0x000092C7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float dot(float4 x, float4 y)
		{
			return x.x * y.x + x.y * y.y + x.z * y.z + x.w * y.w;
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0000B100 File Offset: 0x00009300
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double dot(double x, double y)
		{
			return x * y;
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0000B105 File Offset: 0x00009305
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double dot(double2 x, double2 y)
		{
			return x.x * y.x + x.y * y.y;
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0000B122 File Offset: 0x00009322
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double dot(double3 x, double3 y)
		{
			return x.x * y.x + x.y * y.y + x.z * y.z;
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0000B14D File Offset: 0x0000934D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double dot(double4 x, double4 y)
		{
			return x.x * y.x + x.y * y.y + x.z * y.z + x.w * y.w;
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x0000B186 File Offset: 0x00009386
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float tan(float x)
		{
			return (float)Math.Tan((double)x);
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0000B190 File Offset: 0x00009390
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 tan(float2 x)
		{
			return new float2(math.tan(x.x), math.tan(x.y));
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0000B1AD File Offset: 0x000093AD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 tan(float3 x)
		{
			return new float3(math.tan(x.x), math.tan(x.y), math.tan(x.z));
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0000B1D5 File Offset: 0x000093D5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 tan(float4 x)
		{
			return new float4(math.tan(x.x), math.tan(x.y), math.tan(x.z), math.tan(x.w));
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x0000B208 File Offset: 0x00009408
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double tan(double x)
		{
			return Math.Tan(x);
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x0000B210 File Offset: 0x00009410
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 tan(double2 x)
		{
			return new double2(math.tan(x.x), math.tan(x.y));
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x0000B22D File Offset: 0x0000942D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 tan(double3 x)
		{
			return new double3(math.tan(x.x), math.tan(x.y), math.tan(x.z));
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x0000B255 File Offset: 0x00009455
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 tan(double4 x)
		{
			return new double4(math.tan(x.x), math.tan(x.y), math.tan(x.z), math.tan(x.w));
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0000B288 File Offset: 0x00009488
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float tanh(float x)
		{
			return (float)Math.Tanh((double)x);
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0000B292 File Offset: 0x00009492
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 tanh(float2 x)
		{
			return new float2(math.tanh(x.x), math.tanh(x.y));
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x0000B2AF File Offset: 0x000094AF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 tanh(float3 x)
		{
			return new float3(math.tanh(x.x), math.tanh(x.y), math.tanh(x.z));
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0000B2D7 File Offset: 0x000094D7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 tanh(float4 x)
		{
			return new float4(math.tanh(x.x), math.tanh(x.y), math.tanh(x.z), math.tanh(x.w));
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x0000B30A File Offset: 0x0000950A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double tanh(double x)
		{
			return Math.Tanh(x);
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x0000B312 File Offset: 0x00009512
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 tanh(double2 x)
		{
			return new double2(math.tanh(x.x), math.tanh(x.y));
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0000B32F File Offset: 0x0000952F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 tanh(double3 x)
		{
			return new double3(math.tanh(x.x), math.tanh(x.y), math.tanh(x.z));
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x0000B357 File Offset: 0x00009557
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 tanh(double4 x)
		{
			return new double4(math.tanh(x.x), math.tanh(x.y), math.tanh(x.z), math.tanh(x.w));
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0000B38A File Offset: 0x0000958A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float atan(float x)
		{
			return (float)Math.Atan((double)x);
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x0000B394 File Offset: 0x00009594
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 atan(float2 x)
		{
			return new float2(math.atan(x.x), math.atan(x.y));
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x0000B3B1 File Offset: 0x000095B1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 atan(float3 x)
		{
			return new float3(math.atan(x.x), math.atan(x.y), math.atan(x.z));
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0000B3D9 File Offset: 0x000095D9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 atan(float4 x)
		{
			return new float4(math.atan(x.x), math.atan(x.y), math.atan(x.z), math.atan(x.w));
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0000B40C File Offset: 0x0000960C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double atan(double x)
		{
			return Math.Atan(x);
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0000B414 File Offset: 0x00009614
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 atan(double2 x)
		{
			return new double2(math.atan(x.x), math.atan(x.y));
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0000B431 File Offset: 0x00009631
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 atan(double3 x)
		{
			return new double3(math.atan(x.x), math.atan(x.y), math.atan(x.z));
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0000B459 File Offset: 0x00009659
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 atan(double4 x)
		{
			return new double4(math.atan(x.x), math.atan(x.y), math.atan(x.z), math.atan(x.w));
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0000B48C File Offset: 0x0000968C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float atan2(float y, float x)
		{
			return (float)Math.Atan2((double)y, (double)x);
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0000B498 File Offset: 0x00009698
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 atan2(float2 y, float2 x)
		{
			return new float2(math.atan2(y.x, x.x), math.atan2(y.y, x.y));
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0000B4C1 File Offset: 0x000096C1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 atan2(float3 y, float3 x)
		{
			return new float3(math.atan2(y.x, x.x), math.atan2(y.y, x.y), math.atan2(y.z, x.z));
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0000B4FC File Offset: 0x000096FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 atan2(float4 y, float4 x)
		{
			return new float4(math.atan2(y.x, x.x), math.atan2(y.y, x.y), math.atan2(y.z, x.z), math.atan2(y.w, x.w));
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0000B552 File Offset: 0x00009752
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double atan2(double y, double x)
		{
			return Math.Atan2(y, x);
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x0000B55B File Offset: 0x0000975B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 atan2(double2 y, double2 x)
		{
			return new double2(math.atan2(y.x, x.x), math.atan2(y.y, x.y));
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0000B584 File Offset: 0x00009784
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 atan2(double3 y, double3 x)
		{
			return new double3(math.atan2(y.x, x.x), math.atan2(y.y, x.y), math.atan2(y.z, x.z));
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x0000B5C0 File Offset: 0x000097C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 atan2(double4 y, double4 x)
		{
			return new double4(math.atan2(y.x, x.x), math.atan2(y.y, x.y), math.atan2(y.z, x.z), math.atan2(y.w, x.w));
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x0000B616 File Offset: 0x00009816
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float cos(float x)
		{
			return (float)Math.Cos((double)x);
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0000B620 File Offset: 0x00009820
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 cos(float2 x)
		{
			return new float2(math.cos(x.x), math.cos(x.y));
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x0000B63D File Offset: 0x0000983D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 cos(float3 x)
		{
			return new float3(math.cos(x.x), math.cos(x.y), math.cos(x.z));
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x0000B665 File Offset: 0x00009865
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 cos(float4 x)
		{
			return new float4(math.cos(x.x), math.cos(x.y), math.cos(x.z), math.cos(x.w));
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x0000B698 File Offset: 0x00009898
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double cos(double x)
		{
			return Math.Cos(x);
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x0000B6A0 File Offset: 0x000098A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 cos(double2 x)
		{
			return new double2(math.cos(x.x), math.cos(x.y));
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0000B6BD File Offset: 0x000098BD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 cos(double3 x)
		{
			return new double3(math.cos(x.x), math.cos(x.y), math.cos(x.z));
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0000B6E5 File Offset: 0x000098E5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 cos(double4 x)
		{
			return new double4(math.cos(x.x), math.cos(x.y), math.cos(x.z), math.cos(x.w));
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0000B718 File Offset: 0x00009918
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float cosh(float x)
		{
			return (float)Math.Cosh((double)x);
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0000B722 File Offset: 0x00009922
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 cosh(float2 x)
		{
			return new float2(math.cosh(x.x), math.cosh(x.y));
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0000B73F File Offset: 0x0000993F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 cosh(float3 x)
		{
			return new float3(math.cosh(x.x), math.cosh(x.y), math.cosh(x.z));
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0000B767 File Offset: 0x00009967
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 cosh(float4 x)
		{
			return new float4(math.cosh(x.x), math.cosh(x.y), math.cosh(x.z), math.cosh(x.w));
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0000B79A File Offset: 0x0000999A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double cosh(double x)
		{
			return Math.Cosh(x);
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x0000B7A2 File Offset: 0x000099A2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 cosh(double2 x)
		{
			return new double2(math.cosh(x.x), math.cosh(x.y));
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x0000B7BF File Offset: 0x000099BF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 cosh(double3 x)
		{
			return new double3(math.cosh(x.x), math.cosh(x.y), math.cosh(x.z));
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0000B7E7 File Offset: 0x000099E7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 cosh(double4 x)
		{
			return new double4(math.cosh(x.x), math.cosh(x.y), math.cosh(x.z), math.cosh(x.w));
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0000B81A File Offset: 0x00009A1A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float acos(float x)
		{
			return (float)Math.Acos((double)x);
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x0000B825 File Offset: 0x00009A25
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 acos(float2 x)
		{
			return new float2(math.acos(x.x), math.acos(x.y));
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0000B842 File Offset: 0x00009A42
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 acos(float3 x)
		{
			return new float3(math.acos(x.x), math.acos(x.y), math.acos(x.z));
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x0000B86A File Offset: 0x00009A6A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 acos(float4 x)
		{
			return new float4(math.acos(x.x), math.acos(x.y), math.acos(x.z), math.acos(x.w));
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x0000B89D File Offset: 0x00009A9D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double acos(double x)
		{
			return Math.Acos(x);
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x0000B8A5 File Offset: 0x00009AA5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 acos(double2 x)
		{
			return new double2(math.acos(x.x), math.acos(x.y));
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x0000B8C2 File Offset: 0x00009AC2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 acos(double3 x)
		{
			return new double3(math.acos(x.x), math.acos(x.y), math.acos(x.z));
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x0000B8EA File Offset: 0x00009AEA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 acos(double4 x)
		{
			return new double4(math.acos(x.x), math.acos(x.y), math.acos(x.z), math.acos(x.w));
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x0000B91D File Offset: 0x00009B1D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float sin(float x)
		{
			return (float)Math.Sin((double)x);
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x0000B928 File Offset: 0x00009B28
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 sin(float2 x)
		{
			return new float2(math.sin(x.x), math.sin(x.y));
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x0000B945 File Offset: 0x00009B45
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 sin(float3 x)
		{
			return new float3(math.sin(x.x), math.sin(x.y), math.sin(x.z));
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x0000B96D File Offset: 0x00009B6D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 sin(float4 x)
		{
			return new float4(math.sin(x.x), math.sin(x.y), math.sin(x.z), math.sin(x.w));
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x0000B9A0 File Offset: 0x00009BA0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double sin(double x)
		{
			return Math.Sin(x);
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x0000B9A8 File Offset: 0x00009BA8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 sin(double2 x)
		{
			return new double2(math.sin(x.x), math.sin(x.y));
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x0000B9C5 File Offset: 0x00009BC5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 sin(double3 x)
		{
			return new double3(math.sin(x.x), math.sin(x.y), math.sin(x.z));
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0000B9ED File Offset: 0x00009BED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 sin(double4 x)
		{
			return new double4(math.sin(x.x), math.sin(x.y), math.sin(x.z), math.sin(x.w));
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0000BA20 File Offset: 0x00009C20
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float sinh(float x)
		{
			return (float)Math.Sinh((double)x);
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0000BA2B File Offset: 0x00009C2B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 sinh(float2 x)
		{
			return new float2(math.sinh(x.x), math.sinh(x.y));
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x0000BA48 File Offset: 0x00009C48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 sinh(float3 x)
		{
			return new float3(math.sinh(x.x), math.sinh(x.y), math.sinh(x.z));
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x0000BA70 File Offset: 0x00009C70
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 sinh(float4 x)
		{
			return new float4(math.sinh(x.x), math.sinh(x.y), math.sinh(x.z), math.sinh(x.w));
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x0000BAA3 File Offset: 0x00009CA3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double sinh(double x)
		{
			return Math.Sinh(x);
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0000BAAB File Offset: 0x00009CAB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 sinh(double2 x)
		{
			return new double2(math.sinh(x.x), math.sinh(x.y));
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0000BAC8 File Offset: 0x00009CC8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 sinh(double3 x)
		{
			return new double3(math.sinh(x.x), math.sinh(x.y), math.sinh(x.z));
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x0000BAF0 File Offset: 0x00009CF0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 sinh(double4 x)
		{
			return new double4(math.sinh(x.x), math.sinh(x.y), math.sinh(x.z), math.sinh(x.w));
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0000BB23 File Offset: 0x00009D23
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float asin(float x)
		{
			return (float)Math.Asin((double)x);
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0000BB2E File Offset: 0x00009D2E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 asin(float2 x)
		{
			return new float2(math.asin(x.x), math.asin(x.y));
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0000BB4B File Offset: 0x00009D4B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 asin(float3 x)
		{
			return new float3(math.asin(x.x), math.asin(x.y), math.asin(x.z));
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x0000BB73 File Offset: 0x00009D73
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 asin(float4 x)
		{
			return new float4(math.asin(x.x), math.asin(x.y), math.asin(x.z), math.asin(x.w));
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0000BBA6 File Offset: 0x00009DA6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double asin(double x)
		{
			return Math.Asin(x);
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0000BBAE File Offset: 0x00009DAE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 asin(double2 x)
		{
			return new double2(math.asin(x.x), math.asin(x.y));
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0000BBCB File Offset: 0x00009DCB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 asin(double3 x)
		{
			return new double3(math.asin(x.x), math.asin(x.y), math.asin(x.z));
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0000BBF3 File Offset: 0x00009DF3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 asin(double4 x)
		{
			return new double4(math.asin(x.x), math.asin(x.y), math.asin(x.z), math.asin(x.w));
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x0000BC26 File Offset: 0x00009E26
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float floor(float x)
		{
			return (float)Math.Floor((double)x);
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x0000BC31 File Offset: 0x00009E31
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 floor(float2 x)
		{
			return new float2(math.floor(x.x), math.floor(x.y));
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x0000BC4E File Offset: 0x00009E4E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 floor(float3 x)
		{
			return new float3(math.floor(x.x), math.floor(x.y), math.floor(x.z));
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x0000BC76 File Offset: 0x00009E76
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 floor(float4 x)
		{
			return new float4(math.floor(x.x), math.floor(x.y), math.floor(x.z), math.floor(x.w));
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x0000BCA9 File Offset: 0x00009EA9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double floor(double x)
		{
			return Math.Floor(x);
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0000BCB1 File Offset: 0x00009EB1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 floor(double2 x)
		{
			return new double2(math.floor(x.x), math.floor(x.y));
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x0000BCCE File Offset: 0x00009ECE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 floor(double3 x)
		{
			return new double3(math.floor(x.x), math.floor(x.y), math.floor(x.z));
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x0000BCF6 File Offset: 0x00009EF6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 floor(double4 x)
		{
			return new double4(math.floor(x.x), math.floor(x.y), math.floor(x.z), math.floor(x.w));
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x0000BD29 File Offset: 0x00009F29
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float ceil(float x)
		{
			return (float)Math.Ceiling((double)x);
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x0000BD34 File Offset: 0x00009F34
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 ceil(float2 x)
		{
			return new float2(math.ceil(x.x), math.ceil(x.y));
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x0000BD51 File Offset: 0x00009F51
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 ceil(float3 x)
		{
			return new float3(math.ceil(x.x), math.ceil(x.y), math.ceil(x.z));
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x0000BD79 File Offset: 0x00009F79
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 ceil(float4 x)
		{
			return new float4(math.ceil(x.x), math.ceil(x.y), math.ceil(x.z), math.ceil(x.w));
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x0000BDAC File Offset: 0x00009FAC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double ceil(double x)
		{
			return Math.Ceiling(x);
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x0000BDB4 File Offset: 0x00009FB4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 ceil(double2 x)
		{
			return new double2(math.ceil(x.x), math.ceil(x.y));
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x0000BDD1 File Offset: 0x00009FD1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 ceil(double3 x)
		{
			return new double3(math.ceil(x.x), math.ceil(x.y), math.ceil(x.z));
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x0000BDF9 File Offset: 0x00009FF9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 ceil(double4 x)
		{
			return new double4(math.ceil(x.x), math.ceil(x.y), math.ceil(x.z), math.ceil(x.w));
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x0000BE2C File Offset: 0x0000A02C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float round(float x)
		{
			return (float)Math.Round((double)x);
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x0000BE37 File Offset: 0x0000A037
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 round(float2 x)
		{
			return new float2(math.round(x.x), math.round(x.y));
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x0000BE54 File Offset: 0x0000A054
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 round(float3 x)
		{
			return new float3(math.round(x.x), math.round(x.y), math.round(x.z));
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x0000BE7C File Offset: 0x0000A07C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 round(float4 x)
		{
			return new float4(math.round(x.x), math.round(x.y), math.round(x.z), math.round(x.w));
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x0000BEAF File Offset: 0x0000A0AF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double round(double x)
		{
			return Math.Round(x);
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x0000BEB7 File Offset: 0x0000A0B7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 round(double2 x)
		{
			return new double2(math.round(x.x), math.round(x.y));
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x0000BED4 File Offset: 0x0000A0D4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 round(double3 x)
		{
			return new double3(math.round(x.x), math.round(x.y), math.round(x.z));
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0000BEFC File Offset: 0x0000A0FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 round(double4 x)
		{
			return new double4(math.round(x.x), math.round(x.y), math.round(x.z), math.round(x.w));
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0000BF2F File Offset: 0x0000A12F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float trunc(float x)
		{
			return (float)Math.Truncate((double)x);
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x0000BF3A File Offset: 0x0000A13A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 trunc(float2 x)
		{
			return new float2(math.trunc(x.x), math.trunc(x.y));
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x0000BF57 File Offset: 0x0000A157
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 trunc(float3 x)
		{
			return new float3(math.trunc(x.x), math.trunc(x.y), math.trunc(x.z));
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x0000BF7F File Offset: 0x0000A17F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 trunc(float4 x)
		{
			return new float4(math.trunc(x.x), math.trunc(x.y), math.trunc(x.z), math.trunc(x.w));
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x0000BFB2 File Offset: 0x0000A1B2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double trunc(double x)
		{
			return Math.Truncate(x);
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x0000BFBA File Offset: 0x0000A1BA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 trunc(double2 x)
		{
			return new double2(math.trunc(x.x), math.trunc(x.y));
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x0000BFD7 File Offset: 0x0000A1D7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 trunc(double3 x)
		{
			return new double3(math.trunc(x.x), math.trunc(x.y), math.trunc(x.z));
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0000BFFF File Offset: 0x0000A1FF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 trunc(double4 x)
		{
			return new double4(math.trunc(x.x), math.trunc(x.y), math.trunc(x.z), math.trunc(x.w));
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x0000C032 File Offset: 0x0000A232
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float frac(float x)
		{
			return x - math.floor(x);
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0000C03C File Offset: 0x0000A23C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 frac(float2 x)
		{
			return x - math.floor(x);
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x0000C04A File Offset: 0x0000A24A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 frac(float3 x)
		{
			return x - math.floor(x);
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x0000C058 File Offset: 0x0000A258
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 frac(float4 x)
		{
			return x - math.floor(x);
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x0000C066 File Offset: 0x0000A266
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double frac(double x)
		{
			return x - math.floor(x);
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x0000C070 File Offset: 0x0000A270
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 frac(double2 x)
		{
			return x - math.floor(x);
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x0000C07E File Offset: 0x0000A27E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 frac(double3 x)
		{
			return x - math.floor(x);
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x0000C08C File Offset: 0x0000A28C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 frac(double4 x)
		{
			return x - math.floor(x);
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x0000C09A File Offset: 0x0000A29A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float rcp(float x)
		{
			return 1f / x;
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x0000C0A3 File Offset: 0x0000A2A3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 rcp(float2 x)
		{
			return 1f / x;
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x0000C0B0 File Offset: 0x0000A2B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 rcp(float3 x)
		{
			return 1f / x;
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x0000C0BD File Offset: 0x0000A2BD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 rcp(float4 x)
		{
			return 1f / x;
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x0000C0CA File Offset: 0x0000A2CA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double rcp(double x)
		{
			return 1.0 / x;
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x0000C0D7 File Offset: 0x0000A2D7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 rcp(double2 x)
		{
			return 1.0 / x;
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x0000C0E8 File Offset: 0x0000A2E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 rcp(double3 x)
		{
			return 1.0 / x;
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x0000C0F9 File Offset: 0x0000A2F9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 rcp(double4 x)
		{
			return 1.0 / x;
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x0000C10A File Offset: 0x0000A30A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float sign(float x)
		{
			return ((x > 0f) ? 1f : 0f) - ((x < 0f) ? 1f : 0f);
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x0000C135 File Offset: 0x0000A335
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 sign(float2 x)
		{
			return new float2(math.sign(x.x), math.sign(x.y));
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x0000C152 File Offset: 0x0000A352
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 sign(float3 x)
		{
			return new float3(math.sign(x.x), math.sign(x.y), math.sign(x.z));
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0000C17A File Offset: 0x0000A37A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 sign(float4 x)
		{
			return new float4(math.sign(x.x), math.sign(x.y), math.sign(x.z), math.sign(x.w));
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x0000C1B0 File Offset: 0x0000A3B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double sign(double x)
		{
			if (x != 0.0)
			{
				return ((x > 0.0) ? 1.0 : 0.0) - ((x < 0.0) ? 1.0 : 0.0);
			}
			return 0.0;
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x0000C214 File Offset: 0x0000A414
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 sign(double2 x)
		{
			return new double2(math.sign(x.x), math.sign(x.y));
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0000C231 File Offset: 0x0000A431
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 sign(double3 x)
		{
			return new double3(math.sign(x.x), math.sign(x.y), math.sign(x.z));
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x0000C259 File Offset: 0x0000A459
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 sign(double4 x)
		{
			return new double4(math.sign(x.x), math.sign(x.y), math.sign(x.z), math.sign(x.w));
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x0000C28C File Offset: 0x0000A48C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float pow(float x, float y)
		{
			return (float)Math.Pow((double)x, (double)y);
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x0000C29A File Offset: 0x0000A49A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 pow(float2 x, float2 y)
		{
			return new float2(math.pow(x.x, y.x), math.pow(x.y, y.y));
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x0000C2C3 File Offset: 0x0000A4C3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 pow(float3 x, float3 y)
		{
			return new float3(math.pow(x.x, y.x), math.pow(x.y, y.y), math.pow(x.z, y.z));
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x0000C300 File Offset: 0x0000A500
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 pow(float4 x, float4 y)
		{
			return new float4(math.pow(x.x, y.x), math.pow(x.y, y.y), math.pow(x.z, y.z), math.pow(x.w, y.w));
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x0000C356 File Offset: 0x0000A556
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double pow(double x, double y)
		{
			return Math.Pow(x, y);
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0000C35F File Offset: 0x0000A55F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 pow(double2 x, double2 y)
		{
			return new double2(math.pow(x.x, y.x), math.pow(x.y, y.y));
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x0000C388 File Offset: 0x0000A588
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 pow(double3 x, double3 y)
		{
			return new double3(math.pow(x.x, y.x), math.pow(x.y, y.y), math.pow(x.z, y.z));
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x0000C3C4 File Offset: 0x0000A5C4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 pow(double4 x, double4 y)
		{
			return new double4(math.pow(x.x, y.x), math.pow(x.y, y.y), math.pow(x.z, y.z), math.pow(x.w, y.w));
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x0000C41A File Offset: 0x0000A61A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float exp(float x)
		{
			return (float)Math.Exp((double)x);
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x0000C425 File Offset: 0x0000A625
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 exp(float2 x)
		{
			return new float2(math.exp(x.x), math.exp(x.y));
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x0000C442 File Offset: 0x0000A642
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 exp(float3 x)
		{
			return new float3(math.exp(x.x), math.exp(x.y), math.exp(x.z));
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x0000C46A File Offset: 0x0000A66A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 exp(float4 x)
		{
			return new float4(math.exp(x.x), math.exp(x.y), math.exp(x.z), math.exp(x.w));
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0000C49D File Offset: 0x0000A69D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double exp(double x)
		{
			return Math.Exp(x);
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x0000C4A5 File Offset: 0x0000A6A5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 exp(double2 x)
		{
			return new double2(math.exp(x.x), math.exp(x.y));
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0000C4C2 File Offset: 0x0000A6C2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 exp(double3 x)
		{
			return new double3(math.exp(x.x), math.exp(x.y), math.exp(x.z));
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0000C4EA File Offset: 0x0000A6EA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 exp(double4 x)
		{
			return new double4(math.exp(x.x), math.exp(x.y), math.exp(x.z), math.exp(x.w));
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0000C51D File Offset: 0x0000A71D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float exp2(float x)
		{
			return (float)Math.Exp((double)(x * 0.6931472f));
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0000C52E File Offset: 0x0000A72E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 exp2(float2 x)
		{
			return new float2(math.exp2(x.x), math.exp2(x.y));
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0000C54B File Offset: 0x0000A74B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 exp2(float3 x)
		{
			return new float3(math.exp2(x.x), math.exp2(x.y), math.exp2(x.z));
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0000C573 File Offset: 0x0000A773
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 exp2(float4 x)
		{
			return new float4(math.exp2(x.x), math.exp2(x.y), math.exp2(x.z), math.exp2(x.w));
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0000C5A6 File Offset: 0x0000A7A6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double exp2(double x)
		{
			return Math.Exp(x * 0.6931471805599453);
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x0000C5B8 File Offset: 0x0000A7B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 exp2(double2 x)
		{
			return new double2(math.exp2(x.x), math.exp2(x.y));
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0000C5D5 File Offset: 0x0000A7D5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 exp2(double3 x)
		{
			return new double3(math.exp2(x.x), math.exp2(x.y), math.exp2(x.z));
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x0000C5FD File Offset: 0x0000A7FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 exp2(double4 x)
		{
			return new double4(math.exp2(x.x), math.exp2(x.y), math.exp2(x.z), math.exp2(x.w));
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x0000C630 File Offset: 0x0000A830
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float exp10(float x)
		{
			return (float)Math.Exp((double)(x * 2.3025851f));
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x0000C641 File Offset: 0x0000A841
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 exp10(float2 x)
		{
			return new float2(math.exp10(x.x), math.exp10(x.y));
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x0000C65E File Offset: 0x0000A85E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 exp10(float3 x)
		{
			return new float3(math.exp10(x.x), math.exp10(x.y), math.exp10(x.z));
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x0000C686 File Offset: 0x0000A886
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 exp10(float4 x)
		{
			return new float4(math.exp10(x.x), math.exp10(x.y), math.exp10(x.z), math.exp10(x.w));
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x0000C6B9 File Offset: 0x0000A8B9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double exp10(double x)
		{
			return Math.Exp(x * 2.302585092994046);
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x0000C6CB File Offset: 0x0000A8CB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 exp10(double2 x)
		{
			return new double2(math.exp10(x.x), math.exp10(x.y));
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x0000C6E8 File Offset: 0x0000A8E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 exp10(double3 x)
		{
			return new double3(math.exp10(x.x), math.exp10(x.y), math.exp10(x.z));
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x0000C710 File Offset: 0x0000A910
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 exp10(double4 x)
		{
			return new double4(math.exp10(x.x), math.exp10(x.y), math.exp10(x.z), math.exp10(x.w));
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x0000C743 File Offset: 0x0000A943
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float log(float x)
		{
			return (float)Math.Log((double)x);
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x0000C74E File Offset: 0x0000A94E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 log(float2 x)
		{
			return new float2(math.log(x.x), math.log(x.y));
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x0000C76B File Offset: 0x0000A96B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 log(float3 x)
		{
			return new float3(math.log(x.x), math.log(x.y), math.log(x.z));
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x0000C793 File Offset: 0x0000A993
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 log(float4 x)
		{
			return new float4(math.log(x.x), math.log(x.y), math.log(x.z), math.log(x.w));
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0000C7C6 File Offset: 0x0000A9C6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double log(double x)
		{
			return Math.Log(x);
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x0000C7CE File Offset: 0x0000A9CE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 log(double2 x)
		{
			return new double2(math.log(x.x), math.log(x.y));
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x0000C7EB File Offset: 0x0000A9EB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 log(double3 x)
		{
			return new double3(math.log(x.x), math.log(x.y), math.log(x.z));
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x0000C813 File Offset: 0x0000AA13
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 log(double4 x)
		{
			return new double4(math.log(x.x), math.log(x.y), math.log(x.z), math.log(x.w));
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0000C846 File Offset: 0x0000AA46
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float log2(float x)
		{
			return (float)Math.Log((double)x, 2.0);
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x0000C85A File Offset: 0x0000AA5A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 log2(float2 x)
		{
			return new float2(math.log2(x.x), math.log2(x.y));
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0000C877 File Offset: 0x0000AA77
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 log2(float3 x)
		{
			return new float3(math.log2(x.x), math.log2(x.y), math.log2(x.z));
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0000C89F File Offset: 0x0000AA9F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 log2(float4 x)
		{
			return new float4(math.log2(x.x), math.log2(x.y), math.log2(x.z), math.log2(x.w));
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0000C8D2 File Offset: 0x0000AAD2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double log2(double x)
		{
			return Math.Log(x, 2.0);
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0000C8E3 File Offset: 0x0000AAE3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 log2(double2 x)
		{
			return new double2(math.log2(x.x), math.log2(x.y));
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x0000C900 File Offset: 0x0000AB00
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 log2(double3 x)
		{
			return new double3(math.log2(x.x), math.log2(x.y), math.log2(x.z));
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x0000C928 File Offset: 0x0000AB28
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 log2(double4 x)
		{
			return new double4(math.log2(x.x), math.log2(x.y), math.log2(x.z), math.log2(x.w));
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x0000C95B File Offset: 0x0000AB5B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float log10(float x)
		{
			return (float)Math.Log10((double)x);
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x0000C966 File Offset: 0x0000AB66
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 log10(float2 x)
		{
			return new float2(math.log10(x.x), math.log10(x.y));
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0000C983 File Offset: 0x0000AB83
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 log10(float3 x)
		{
			return new float3(math.log10(x.x), math.log10(x.y), math.log10(x.z));
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x0000C9AB File Offset: 0x0000ABAB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 log10(float4 x)
		{
			return new float4(math.log10(x.x), math.log10(x.y), math.log10(x.z), math.log10(x.w));
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x0000C9DE File Offset: 0x0000ABDE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double log10(double x)
		{
			return Math.Log10(x);
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x0000C9E6 File Offset: 0x0000ABE6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 log10(double2 x)
		{
			return new double2(math.log10(x.x), math.log10(x.y));
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x0000CA03 File Offset: 0x0000AC03
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 log10(double3 x)
		{
			return new double3(math.log10(x.x), math.log10(x.y), math.log10(x.z));
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0000CA2B File Offset: 0x0000AC2B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 log10(double4 x)
		{
			return new double4(math.log10(x.x), math.log10(x.y), math.log10(x.z), math.log10(x.w));
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x0000CA5E File Offset: 0x0000AC5E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float fmod(float x, float y)
		{
			return x % y;
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x0000CA63 File Offset: 0x0000AC63
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 fmod(float2 x, float2 y)
		{
			return new float2(x.x % y.x, x.y % y.y);
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x0000CA84 File Offset: 0x0000AC84
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 fmod(float3 x, float3 y)
		{
			return new float3(x.x % y.x, x.y % y.y, x.z % y.z);
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x0000CAB2 File Offset: 0x0000ACB2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 fmod(float4 x, float4 y)
		{
			return new float4(x.x % y.x, x.y % y.y, x.z % y.z, x.w % y.w);
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x0000CAED File Offset: 0x0000ACED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double fmod(double x, double y)
		{
			return x % y;
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x0000CAF2 File Offset: 0x0000ACF2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 fmod(double2 x, double2 y)
		{
			return new double2(x.x % y.x, x.y % y.y);
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x0000CB13 File Offset: 0x0000AD13
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 fmod(double3 x, double3 y)
		{
			return new double3(x.x % y.x, x.y % y.y, x.z % y.z);
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x0000CB41 File Offset: 0x0000AD41
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 fmod(double4 x, double4 y)
		{
			return new double4(x.x % y.x, x.y % y.y, x.z % y.z, x.w % y.w);
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x0000CB7C File Offset: 0x0000AD7C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float modf(float x, out float i)
		{
			i = math.trunc(x);
			return x - i;
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x0000CB8A File Offset: 0x0000AD8A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 modf(float2 x, out float2 i)
		{
			i = math.trunc(x);
			return x - i;
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x0000CBA4 File Offset: 0x0000ADA4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 modf(float3 x, out float3 i)
		{
			i = math.trunc(x);
			return x - i;
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x0000CBBE File Offset: 0x0000ADBE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 modf(float4 x, out float4 i)
		{
			i = math.trunc(x);
			return x - i;
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x0000CBD8 File Offset: 0x0000ADD8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double modf(double x, out double i)
		{
			i = math.trunc(x);
			return x - i;
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x0000CBE6 File Offset: 0x0000ADE6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 modf(double2 x, out double2 i)
		{
			i = math.trunc(x);
			return x - i;
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x0000CC00 File Offset: 0x0000AE00
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 modf(double3 x, out double3 i)
		{
			i = math.trunc(x);
			return x - i;
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x0000CC1A File Offset: 0x0000AE1A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 modf(double4 x, out double4 i)
		{
			i = math.trunc(x);
			return x - i;
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x0000CC34 File Offset: 0x0000AE34
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float sqrt(float x)
		{
			return (float)Math.Sqrt((double)x);
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x0000CC3F File Offset: 0x0000AE3F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 sqrt(float2 x)
		{
			return new float2(math.sqrt(x.x), math.sqrt(x.y));
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0000CC5C File Offset: 0x0000AE5C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 sqrt(float3 x)
		{
			return new float3(math.sqrt(x.x), math.sqrt(x.y), math.sqrt(x.z));
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0000CC84 File Offset: 0x0000AE84
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 sqrt(float4 x)
		{
			return new float4(math.sqrt(x.x), math.sqrt(x.y), math.sqrt(x.z), math.sqrt(x.w));
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x0000CCB7 File Offset: 0x0000AEB7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double sqrt(double x)
		{
			return Math.Sqrt(x);
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x0000CCBF File Offset: 0x0000AEBF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 sqrt(double2 x)
		{
			return new double2(math.sqrt(x.x), math.sqrt(x.y));
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x0000CCDC File Offset: 0x0000AEDC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 sqrt(double3 x)
		{
			return new double3(math.sqrt(x.x), math.sqrt(x.y), math.sqrt(x.z));
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x0000CD04 File Offset: 0x0000AF04
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 sqrt(double4 x)
		{
			return new double4(math.sqrt(x.x), math.sqrt(x.y), math.sqrt(x.z), math.sqrt(x.w));
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x0000CD37 File Offset: 0x0000AF37
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float rsqrt(float x)
		{
			return 1f / math.sqrt(x);
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0000CD45 File Offset: 0x0000AF45
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 rsqrt(float2 x)
		{
			return 1f / math.sqrt(x);
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x0000CD57 File Offset: 0x0000AF57
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 rsqrt(float3 x)
		{
			return 1f / math.sqrt(x);
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x0000CD69 File Offset: 0x0000AF69
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 rsqrt(float4 x)
		{
			return 1f / math.sqrt(x);
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0000CD7B File Offset: 0x0000AF7B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double rsqrt(double x)
		{
			return 1.0 / math.sqrt(x);
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0000CD8D File Offset: 0x0000AF8D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 rsqrt(double2 x)
		{
			return 1.0 / math.sqrt(x);
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0000CDA3 File Offset: 0x0000AFA3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 rsqrt(double3 x)
		{
			return 1.0 / math.sqrt(x);
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0000CDB9 File Offset: 0x0000AFB9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 rsqrt(double4 x)
		{
			return 1.0 / math.sqrt(x);
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0000CDCF File Offset: 0x0000AFCF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 normalize(float2 x)
		{
			return math.rsqrt(math.dot(x, x)) * x;
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x0000CDE3 File Offset: 0x0000AFE3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 normalize(float3 x)
		{
			return math.rsqrt(math.dot(x, x)) * x;
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x0000CDF7 File Offset: 0x0000AFF7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 normalize(float4 x)
		{
			return math.rsqrt(math.dot(x, x)) * x;
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x0000CE0B File Offset: 0x0000B00B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 normalize(double2 x)
		{
			return math.rsqrt(math.dot(x, x)) * x;
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x0000CE1F File Offset: 0x0000B01F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 normalize(double3 x)
		{
			return math.rsqrt(math.dot(x, x)) * x;
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x0000CE33 File Offset: 0x0000B033
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 normalize(double4 x)
		{
			return math.rsqrt(math.dot(x, x)) * x;
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x0000CE48 File Offset: 0x0000B048
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 normalizesafe(float2 x, float2 defaultvalue = default(float2))
		{
			float num = math.dot(x, x);
			return math.select(defaultvalue, x * math.rsqrt(num), num > 1.1754944E-38f);
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0000CE78 File Offset: 0x0000B078
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 normalizesafe(float3 x, float3 defaultvalue = default(float3))
		{
			float num = math.dot(x, x);
			return math.select(defaultvalue, x * math.rsqrt(num), num > 1.1754944E-38f);
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x0000CEA8 File Offset: 0x0000B0A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 normalizesafe(float4 x, float4 defaultvalue = default(float4))
		{
			float num = math.dot(x, x);
			return math.select(defaultvalue, x * math.rsqrt(num), num > 1.1754944E-38f);
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x0000CED8 File Offset: 0x0000B0D8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 normalizesafe(double2 x, double2 defaultvalue = default(double2))
		{
			double num = math.dot(x, x);
			return math.select(defaultvalue, x * math.rsqrt(num), num > 1.1754943508222875E-38);
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0000CF0C File Offset: 0x0000B10C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 normalizesafe(double3 x, double3 defaultvalue = default(double3))
		{
			double num = math.dot(x, x);
			return math.select(defaultvalue, x * math.rsqrt(num), num > 1.1754943508222875E-38);
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x0000CF40 File Offset: 0x0000B140
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 normalizesafe(double4 x, double4 defaultvalue = default(double4))
		{
			double num = math.dot(x, x);
			return math.select(defaultvalue, x * math.rsqrt(num), num > 1.1754943508222875E-38);
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x0000CF73 File Offset: 0x0000B173
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float length(float x)
		{
			return math.abs(x);
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x0000CF7B File Offset: 0x0000B17B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float length(float2 x)
		{
			return math.sqrt(math.dot(x, x));
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x0000CF89 File Offset: 0x0000B189
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float length(float3 x)
		{
			return math.sqrt(math.dot(x, x));
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x0000CF97 File Offset: 0x0000B197
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float length(float4 x)
		{
			return math.sqrt(math.dot(x, x));
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x0000CFA5 File Offset: 0x0000B1A5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double length(double x)
		{
			return math.abs(x);
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x0000CFAD File Offset: 0x0000B1AD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double length(double2 x)
		{
			return math.sqrt(math.dot(x, x));
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x0000CFBB File Offset: 0x0000B1BB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double length(double3 x)
		{
			return math.sqrt(math.dot(x, x));
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x0000CFC9 File Offset: 0x0000B1C9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double length(double4 x)
		{
			return math.sqrt(math.dot(x, x));
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x0000CFD7 File Offset: 0x0000B1D7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float lengthsq(float x)
		{
			return x * x;
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x0000CFDC File Offset: 0x0000B1DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float lengthsq(float2 x)
		{
			return math.dot(x, x);
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x0000CFE5 File Offset: 0x0000B1E5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float lengthsq(float3 x)
		{
			return math.dot(x, x);
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x0000CFEE File Offset: 0x0000B1EE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float lengthsq(float4 x)
		{
			return math.dot(x, x);
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x0000CFF7 File Offset: 0x0000B1F7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double lengthsq(double x)
		{
			return x * x;
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x0000CFFC File Offset: 0x0000B1FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double lengthsq(double2 x)
		{
			return math.dot(x, x);
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x0000D005 File Offset: 0x0000B205
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double lengthsq(double3 x)
		{
			return math.dot(x, x);
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x0000D00E File Offset: 0x0000B20E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double lengthsq(double4 x)
		{
			return math.dot(x, x);
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0000D017 File Offset: 0x0000B217
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float distance(float x, float y)
		{
			return math.abs(y - x);
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x0000D021 File Offset: 0x0000B221
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float distance(float2 x, float2 y)
		{
			return math.length(y - x);
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x0000D02F File Offset: 0x0000B22F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float distance(float3 x, float3 y)
		{
			return math.length(y - x);
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x0000D03D File Offset: 0x0000B23D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float distance(float4 x, float4 y)
		{
			return math.length(y - x);
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x0000D04B File Offset: 0x0000B24B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double distance(double x, double y)
		{
			return math.abs(y - x);
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x0000D055 File Offset: 0x0000B255
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double distance(double2 x, double2 y)
		{
			return math.length(y - x);
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x0000D063 File Offset: 0x0000B263
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double distance(double3 x, double3 y)
		{
			return math.length(y - x);
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x0000D071 File Offset: 0x0000B271
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double distance(double4 x, double4 y)
		{
			return math.length(y - x);
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x0000D07F File Offset: 0x0000B27F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float distancesq(float x, float y)
		{
			return (y - x) * (y - x);
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x0000D088 File Offset: 0x0000B288
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float distancesq(float2 x, float2 y)
		{
			return math.lengthsq(y - x);
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x0000D096 File Offset: 0x0000B296
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float distancesq(float3 x, float3 y)
		{
			return math.lengthsq(y - x);
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x0000D0A4 File Offset: 0x0000B2A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float distancesq(float4 x, float4 y)
		{
			return math.lengthsq(y - x);
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x0000D0B2 File Offset: 0x0000B2B2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double distancesq(double x, double y)
		{
			return (y - x) * (y - x);
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0000D0BB File Offset: 0x0000B2BB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double distancesq(double2 x, double2 y)
		{
			return math.lengthsq(y - x);
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x0000D0C9 File Offset: 0x0000B2C9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double distancesq(double3 x, double3 y)
		{
			return math.lengthsq(y - x);
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x0000D0D7 File Offset: 0x0000B2D7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double distancesq(double4 x, double4 y)
		{
			return math.lengthsq(y - x);
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x0000D0E8 File Offset: 0x0000B2E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 cross(float3 x, float3 y)
		{
			return (x * y.yzx - x.yzx * y).yzx;
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x0000D11C File Offset: 0x0000B31C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 cross(double3 x, double3 y)
		{
			return (x * y.yzx - x.yzx * y).yzx;
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x0000D150 File Offset: 0x0000B350
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float smoothstep(float a, float b, float x)
		{
			float num = math.saturate((x - a) / (b - a));
			return num * num * (3f - 2f * num);
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x0000D17C File Offset: 0x0000B37C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 smoothstep(float2 a, float2 b, float2 x)
		{
			float2 @float = math.saturate((x - a) / (b - a));
			return @float * @float * (3f - 2f * @float);
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x0000D1C4 File Offset: 0x0000B3C4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 smoothstep(float3 a, float3 b, float3 x)
		{
			float3 @float = math.saturate((x - a) / (b - a));
			return @float * @float * (3f - 2f * @float);
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x0000D20C File Offset: 0x0000B40C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 smoothstep(float4 a, float4 b, float4 x)
		{
			float4 @float = math.saturate((x - a) / (b - a));
			return @float * @float * (3f - 2f * @float);
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x0000D254 File Offset: 0x0000B454
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double smoothstep(double a, double b, double x)
		{
			double num = math.saturate((x - a) / (b - a));
			return num * num * (3.0 - 2.0 * num);
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x0000D288 File Offset: 0x0000B488
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 smoothstep(double2 a, double2 b, double2 x)
		{
			double2 @double = math.saturate((x - a) / (b - a));
			return @double * @double * (3.0 - 2.0 * @double);
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x0000D2D8 File Offset: 0x0000B4D8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 smoothstep(double3 a, double3 b, double3 x)
		{
			double3 @double = math.saturate((x - a) / (b - a));
			return @double * @double * (3.0 - 2.0 * @double);
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x0000D328 File Offset: 0x0000B528
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 smoothstep(double4 a, double4 b, double4 x)
		{
			double4 @double = math.saturate((x - a) / (b - a));
			return @double * @double * (3.0 - 2.0 * @double);
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x0000D377 File Offset: 0x0000B577
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool any(bool2 x)
		{
			return x.x || x.y;
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0000D389 File Offset: 0x0000B589
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool any(bool3 x)
		{
			return x.x || x.y || x.z;
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x0000D3A3 File Offset: 0x0000B5A3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool any(bool4 x)
		{
			return x.x || x.y || x.z || x.w;
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x0000D3C5 File Offset: 0x0000B5C5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool any(int2 x)
		{
			return x.x != 0 || x.y != 0;
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x0000D3DA File Offset: 0x0000B5DA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool any(int3 x)
		{
			return x.x != 0 || x.y != 0 || x.z != 0;
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x0000D3F7 File Offset: 0x0000B5F7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool any(int4 x)
		{
			return x.x != 0 || x.y != 0 || x.z != 0 || x.w != 0;
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x0000D41C File Offset: 0x0000B61C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool any(uint2 x)
		{
			return x.x != 0U || x.y > 0U;
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x0000D431 File Offset: 0x0000B631
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool any(uint3 x)
		{
			return x.x != 0U || x.y != 0U || x.z > 0U;
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x0000D44E File Offset: 0x0000B64E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool any(uint4 x)
		{
			return x.x != 0U || x.y != 0U || x.z != 0U || x.w > 0U;
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x0000D473 File Offset: 0x0000B673
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool any(float2 x)
		{
			return x.x != 0f || x.y != 0f;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0000D494 File Offset: 0x0000B694
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool any(float3 x)
		{
			return x.x != 0f || x.y != 0f || x.z != 0f;
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x0000D4C2 File Offset: 0x0000B6C2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool any(float4 x)
		{
			return x.x != 0f || x.y != 0f || x.z != 0f || x.w != 0f;
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x0000D4FD File Offset: 0x0000B6FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool any(double2 x)
		{
			return x.x != 0.0 || x.y != 0.0;
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x0000D526 File Offset: 0x0000B726
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool any(double3 x)
		{
			return x.x != 0.0 || x.y != 0.0 || x.z != 0.0;
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x0000D560 File Offset: 0x0000B760
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool any(double4 x)
		{
			return x.x != 0.0 || x.y != 0.0 || x.z != 0.0 || x.w != 0.0;
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x0000D5B6 File Offset: 0x0000B7B6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool all(bool2 x)
		{
			return x.x && x.y;
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x0000D5C8 File Offset: 0x0000B7C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool all(bool3 x)
		{
			return x.x && x.y && x.z;
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x0000D5E2 File Offset: 0x0000B7E2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool all(bool4 x)
		{
			return x.x && x.y && x.z && x.w;
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x0000D604 File Offset: 0x0000B804
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool all(int2 x)
		{
			return x.x != 0 && x.y != 0;
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x0000D619 File Offset: 0x0000B819
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool all(int3 x)
		{
			return x.x != 0 && x.y != 0 && x.z != 0;
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x0000D636 File Offset: 0x0000B836
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool all(int4 x)
		{
			return x.x != 0 && x.y != 0 && x.z != 0 && x.w != 0;
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x0000D65B File Offset: 0x0000B85B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool all(uint2 x)
		{
			return x.x != 0U && x.y > 0U;
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x0000D670 File Offset: 0x0000B870
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool all(uint3 x)
		{
			return x.x != 0U && x.y != 0U && x.z > 0U;
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x0000D68D File Offset: 0x0000B88D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool all(uint4 x)
		{
			return x.x != 0U && x.y != 0U && x.z != 0U && x.w > 0U;
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x0000D6B2 File Offset: 0x0000B8B2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool all(float2 x)
		{
			return x.x != 0f && x.y != 0f;
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x0000D6D3 File Offset: 0x0000B8D3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool all(float3 x)
		{
			return x.x != 0f && x.y != 0f && x.z != 0f;
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x0000D701 File Offset: 0x0000B901
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool all(float4 x)
		{
			return x.x != 0f && x.y != 0f && x.z != 0f && x.w != 0f;
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x0000D73C File Offset: 0x0000B93C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool all(double2 x)
		{
			return x.x != 0.0 && x.y != 0.0;
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0000D765 File Offset: 0x0000B965
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool all(double3 x)
		{
			return x.x != 0.0 && x.y != 0.0 && x.z != 0.0;
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0000D7A0 File Offset: 0x0000B9A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool all(double4 x)
		{
			return x.x != 0.0 && x.y != 0.0 && x.z != 0.0 && x.w != 0.0;
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x0000D7F6 File Offset: 0x0000B9F6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int select(int a, int b, bool c)
		{
			if (!c)
			{
				return a;
			}
			return b;
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x0000D7FE File Offset: 0x0000B9FE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 select(int2 a, int2 b, bool c)
		{
			if (!c)
			{
				return a;
			}
			return b;
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0000D806 File Offset: 0x0000BA06
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 select(int3 a, int3 b, bool c)
		{
			if (!c)
			{
				return a;
			}
			return b;
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x0000D80E File Offset: 0x0000BA0E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 select(int4 a, int4 b, bool c)
		{
			if (!c)
			{
				return a;
			}
			return b;
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x0000D816 File Offset: 0x0000BA16
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 select(int2 a, int2 b, bool2 c)
		{
			return new int2(c.x ? b.x : a.x, c.y ? b.y : a.y);
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x0000D84C File Offset: 0x0000BA4C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 select(int3 a, int3 b, bool3 c)
		{
			return new int3(c.x ? b.x : a.x, c.y ? b.y : a.y, c.z ? b.z : a.z);
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x0000D8A0 File Offset: 0x0000BAA0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 select(int4 a, int4 b, bool4 c)
		{
			return new int4(c.x ? b.x : a.x, c.y ? b.y : a.y, c.z ? b.z : a.z, c.w ? b.w : a.w);
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x0000D90A File Offset: 0x0000BB0A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint select(uint a, uint b, bool c)
		{
			if (!c)
			{
				return a;
			}
			return b;
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x0000D912 File Offset: 0x0000BB12
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 select(uint2 a, uint2 b, bool c)
		{
			if (!c)
			{
				return a;
			}
			return b;
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x0000D91A File Offset: 0x0000BB1A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 select(uint3 a, uint3 b, bool c)
		{
			if (!c)
			{
				return a;
			}
			return b;
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x0000D922 File Offset: 0x0000BB22
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 select(uint4 a, uint4 b, bool c)
		{
			if (!c)
			{
				return a;
			}
			return b;
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x0000D92A File Offset: 0x0000BB2A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 select(uint2 a, uint2 b, bool2 c)
		{
			return new uint2(c.x ? b.x : a.x, c.y ? b.y : a.y);
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x0000D960 File Offset: 0x0000BB60
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 select(uint3 a, uint3 b, bool3 c)
		{
			return new uint3(c.x ? b.x : a.x, c.y ? b.y : a.y, c.z ? b.z : a.z);
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x0000D9B4 File Offset: 0x0000BBB4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 select(uint4 a, uint4 b, bool4 c)
		{
			return new uint4(c.x ? b.x : a.x, c.y ? b.y : a.y, c.z ? b.z : a.z, c.w ? b.w : a.w);
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0000DA1E File Offset: 0x0000BC1E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long select(long a, long b, bool c)
		{
			if (!c)
			{
				return a;
			}
			return b;
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0000DA26 File Offset: 0x0000BC26
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong select(ulong a, ulong b, bool c)
		{
			if (!c)
			{
				return a;
			}
			return b;
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0000DA2E File Offset: 0x0000BC2E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float select(float a, float b, bool c)
		{
			if (!c)
			{
				return a;
			}
			return b;
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x0000DA36 File Offset: 0x0000BC36
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 select(float2 a, float2 b, bool c)
		{
			if (!c)
			{
				return a;
			}
			return b;
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0000DA3E File Offset: 0x0000BC3E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 select(float3 a, float3 b, bool c)
		{
			if (!c)
			{
				return a;
			}
			return b;
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x0000DA46 File Offset: 0x0000BC46
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 select(float4 a, float4 b, bool c)
		{
			if (!c)
			{
				return a;
			}
			return b;
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x0000DA4E File Offset: 0x0000BC4E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 select(float2 a, float2 b, bool2 c)
		{
			return new float2(c.x ? b.x : a.x, c.y ? b.y : a.y);
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x0000DA84 File Offset: 0x0000BC84
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 select(float3 a, float3 b, bool3 c)
		{
			return new float3(c.x ? b.x : a.x, c.y ? b.y : a.y, c.z ? b.z : a.z);
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x0000DAD8 File Offset: 0x0000BCD8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 select(float4 a, float4 b, bool4 c)
		{
			return new float4(c.x ? b.x : a.x, c.y ? b.y : a.y, c.z ? b.z : a.z, c.w ? b.w : a.w);
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0000DB42 File Offset: 0x0000BD42
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double select(double a, double b, bool c)
		{
			if (!c)
			{
				return a;
			}
			return b;
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x0000DB4A File Offset: 0x0000BD4A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 select(double2 a, double2 b, bool c)
		{
			if (!c)
			{
				return a;
			}
			return b;
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x0000DB52 File Offset: 0x0000BD52
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 select(double3 a, double3 b, bool c)
		{
			if (!c)
			{
				return a;
			}
			return b;
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x0000DB5A File Offset: 0x0000BD5A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 select(double4 a, double4 b, bool c)
		{
			if (!c)
			{
				return a;
			}
			return b;
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x0000DB62 File Offset: 0x0000BD62
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 select(double2 a, double2 b, bool2 c)
		{
			return new double2(c.x ? b.x : a.x, c.y ? b.y : a.y);
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x0000DB98 File Offset: 0x0000BD98
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 select(double3 a, double3 b, bool3 c)
		{
			return new double3(c.x ? b.x : a.x, c.y ? b.y : a.y, c.z ? b.z : a.z);
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x0000DBEC File Offset: 0x0000BDEC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 select(double4 a, double4 b, bool4 c)
		{
			return new double4(c.x ? b.x : a.x, c.y ? b.y : a.y, c.z ? b.z : a.z, c.w ? b.w : a.w);
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x0000DC56 File Offset: 0x0000BE56
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float step(float y, float x)
		{
			return math.select(0f, 1f, x >= y);
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x0000DC6E File Offset: 0x0000BE6E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 step(float2 y, float2 x)
		{
			return math.select(math.float2(0f), math.float2(1f), x >= y);
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x0000DC90 File Offset: 0x0000BE90
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 step(float3 y, float3 x)
		{
			return math.select(math.float3(0f), math.float3(1f), x >= y);
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x0000DCB2 File Offset: 0x0000BEB2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 step(float4 y, float4 x)
		{
			return math.select(math.float4(0f), math.float4(1f), x >= y);
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x0000DCD4 File Offset: 0x0000BED4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double step(double y, double x)
		{
			return math.select(0.0, 1.0, x >= y);
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x0000DCF4 File Offset: 0x0000BEF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 step(double2 y, double2 x)
		{
			return math.select(math.double2(0.0), math.double2(1.0), x >= y);
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x0000DD1E File Offset: 0x0000BF1E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 step(double3 y, double3 x)
		{
			return math.select(math.double3(0.0), math.double3(1.0), x >= y);
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0000DD48 File Offset: 0x0000BF48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 step(double4 y, double4 x)
		{
			return math.select(math.double4(0.0), math.double4(1.0), x >= y);
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x0000DD72 File Offset: 0x0000BF72
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 reflect(float2 i, float2 n)
		{
			return i - 2f * n * math.dot(i, n);
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x0000DD91 File Offset: 0x0000BF91
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 reflect(float3 i, float3 n)
		{
			return i - 2f * n * math.dot(i, n);
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x0000DDB0 File Offset: 0x0000BFB0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 reflect(float4 i, float4 n)
		{
			return i - 2f * n * math.dot(i, n);
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x0000DDCF File Offset: 0x0000BFCF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 reflect(double2 i, double2 n)
		{
			return i - 2.0 * n * math.dot(i, n);
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x0000DDF2 File Offset: 0x0000BFF2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 reflect(double3 i, double3 n)
		{
			return i - 2.0 * n * math.dot(i, n);
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0000DE15 File Offset: 0x0000C015
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 reflect(double4 i, double4 n)
		{
			return i - 2.0 * n * math.dot(i, n);
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x0000DE38 File Offset: 0x0000C038
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 refract(float2 i, float2 n, float eta)
		{
			float num = math.dot(n, i);
			float num2 = 1f - eta * eta * (1f - num * num);
			return math.select(0f, eta * i - (eta * num + math.sqrt(num2)) * n, num2 >= 0f);
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x0000DE98 File Offset: 0x0000C098
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 refract(float3 i, float3 n, float eta)
		{
			float num = math.dot(n, i);
			float num2 = 1f - eta * eta * (1f - num * num);
			return math.select(0f, eta * i - (eta * num + math.sqrt(num2)) * n, num2 >= 0f);
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x0000DEF8 File Offset: 0x0000C0F8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 refract(float4 i, float4 n, float eta)
		{
			float num = math.dot(n, i);
			float num2 = 1f - eta * eta * (1f - num * num);
			return math.select(0f, eta * i - (eta * num + math.sqrt(num2)) * n, num2 >= 0f);
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x0000DF58 File Offset: 0x0000C158
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 refract(double2 i, double2 n, double eta)
		{
			double num = math.dot(n, i);
			double num2 = 1.0 - eta * eta * (1.0 - num * num);
			return math.select(0f, eta * i - (eta * num + math.sqrt(num2)) * n, num2 >= 0.0);
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x0000DFC4 File Offset: 0x0000C1C4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 refract(double3 i, double3 n, double eta)
		{
			double num = math.dot(n, i);
			double num2 = 1.0 - eta * eta * (1.0 - num * num);
			return math.select(0f, eta * i - (eta * num + math.sqrt(num2)) * n, num2 >= 0.0);
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x0000E030 File Offset: 0x0000C230
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 refract(double4 i, double4 n, double eta)
		{
			double num = math.dot(n, i);
			double num2 = 1.0 - eta * eta * (1.0 - num * num);
			return math.select(0f, eta * i - (eta * num + math.sqrt(num2)) * n, num2 >= 0.0);
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0000E09B File Offset: 0x0000C29B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 project(float2 a, float2 b)
		{
			return math.dot(a, b) / math.dot(b, b) * b;
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x0000E0B2 File Offset: 0x0000C2B2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 project(float3 a, float3 b)
		{
			return math.dot(a, b) / math.dot(b, b) * b;
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x0000E0C9 File Offset: 0x0000C2C9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 project(float4 a, float4 b)
		{
			return math.dot(a, b) / math.dot(b, b) * b;
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x0000E0E0 File Offset: 0x0000C2E0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 projectsafe(float2 a, float2 b, float2 defaultValue = default(float2))
		{
			float2 @float = math.project(a, b);
			return math.select(defaultValue, @float, math.all(math.isfinite(@float)));
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x0000E108 File Offset: 0x0000C308
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 projectsafe(float3 a, float3 b, float3 defaultValue = default(float3))
		{
			float3 @float = math.project(a, b);
			return math.select(defaultValue, @float, math.all(math.isfinite(@float)));
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x0000E130 File Offset: 0x0000C330
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 projectsafe(float4 a, float4 b, float4 defaultValue = default(float4))
		{
			float4 @float = math.project(a, b);
			return math.select(defaultValue, @float, math.all(math.isfinite(@float)));
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x0000E157 File Offset: 0x0000C357
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 project(double2 a, double2 b)
		{
			return math.dot(a, b) / math.dot(b, b) * b;
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x0000E16E File Offset: 0x0000C36E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 project(double3 a, double3 b)
		{
			return math.dot(a, b) / math.dot(b, b) * b;
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x0000E185 File Offset: 0x0000C385
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 project(double4 a, double4 b)
		{
			return math.dot(a, b) / math.dot(b, b) * b;
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x0000E19C File Offset: 0x0000C39C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 projectsafe(double2 a, double2 b, double2 defaultValue = default(double2))
		{
			double2 @double = math.project(a, b);
			return math.select(defaultValue, @double, math.all(math.isfinite(@double)));
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0000E1C4 File Offset: 0x0000C3C4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 projectsafe(double3 a, double3 b, double3 defaultValue = default(double3))
		{
			double3 @double = math.project(a, b);
			return math.select(defaultValue, @double, math.all(math.isfinite(@double)));
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0000E1EC File Offset: 0x0000C3EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 projectsafe(double4 a, double4 b, double4 defaultValue = default(double4))
		{
			double4 @double = math.project(a, b);
			return math.select(defaultValue, @double, math.all(math.isfinite(@double)));
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0000E213 File Offset: 0x0000C413
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 faceforward(float2 n, float2 i, float2 ng)
		{
			return math.select(n, -n, math.dot(ng, i) >= 0f);
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0000E232 File Offset: 0x0000C432
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 faceforward(float3 n, float3 i, float3 ng)
		{
			return math.select(n, -n, math.dot(ng, i) >= 0f);
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0000E251 File Offset: 0x0000C451
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 faceforward(float4 n, float4 i, float4 ng)
		{
			return math.select(n, -n, math.dot(ng, i) >= 0f);
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x0000E270 File Offset: 0x0000C470
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 faceforward(double2 n, double2 i, double2 ng)
		{
			return math.select(n, -n, math.dot(ng, i) >= 0.0);
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x0000E293 File Offset: 0x0000C493
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 faceforward(double3 n, double3 i, double3 ng)
		{
			return math.select(n, -n, math.dot(ng, i) >= 0.0);
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x0000E2B6 File Offset: 0x0000C4B6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 faceforward(double4 n, double4 i, double4 ng)
		{
			return math.select(n, -n, math.dot(ng, i) >= 0.0);
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x0000E2D9 File Offset: 0x0000C4D9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void sincos(float x, out float s, out float c)
		{
			s = math.sin(x);
			c = math.cos(x);
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x0000E2EB File Offset: 0x0000C4EB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void sincos(float2 x, out float2 s, out float2 c)
		{
			s = math.sin(x);
			c = math.cos(x);
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x0000E305 File Offset: 0x0000C505
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void sincos(float3 x, out float3 s, out float3 c)
		{
			s = math.sin(x);
			c = math.cos(x);
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x0000E31F File Offset: 0x0000C51F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void sincos(float4 x, out float4 s, out float4 c)
		{
			s = math.sin(x);
			c = math.cos(x);
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x0000E339 File Offset: 0x0000C539
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void sincos(double x, out double s, out double c)
		{
			s = math.sin(x);
			c = math.cos(x);
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x0000E34B File Offset: 0x0000C54B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void sincos(double2 x, out double2 s, out double2 c)
		{
			s = math.sin(x);
			c = math.cos(x);
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x0000E365 File Offset: 0x0000C565
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void sincos(double3 x, out double3 s, out double3 c)
		{
			s = math.sin(x);
			c = math.cos(x);
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x0000E37F File Offset: 0x0000C57F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void sincos(double4 x, out double4 s, out double4 c)
		{
			s = math.sin(x);
			c = math.cos(x);
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x0000E399 File Offset: 0x0000C599
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int countbits(int x)
		{
			return math.countbits((uint)x);
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x0000E3A1 File Offset: 0x0000C5A1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 countbits(int2 x)
		{
			return math.countbits((uint2)x);
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x0000E3AE File Offset: 0x0000C5AE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 countbits(int3 x)
		{
			return math.countbits((uint3)x);
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0000E3BB File Offset: 0x0000C5BB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 countbits(int4 x)
		{
			return math.countbits((uint4)x);
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x0000E3C8 File Offset: 0x0000C5C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int countbits(uint x)
		{
			x -= (x >> 1 & 1431655765U);
			x = (x & 858993459U) + (x >> 2 & 858993459U);
			return (int)((x + (x >> 4) & 252645135U) * 16843009U >> 24);
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x0000E400 File Offset: 0x0000C600
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 countbits(uint2 x)
		{
			x -= (x >> 1 & 1431655765U);
			x = (x & 858993459U) + (x >> 2 & 858993459U);
			return math.int2((x + (x >> 4) & 252645135U) * 16843009U >> 24);
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x0000E478 File Offset: 0x0000C678
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 countbits(uint3 x)
		{
			x -= (x >> 1 & 1431655765U);
			x = (x & 858993459U) + (x >> 2 & 858993459U);
			return math.int3((x + (x >> 4) & 252645135U) * 16843009U >> 24);
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x0000E4F0 File Offset: 0x0000C6F0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 countbits(uint4 x)
		{
			x -= (x >> 1 & 1431655765U);
			x = (x & 858993459U) + (x >> 2 & 858993459U);
			return math.int4((x + (x >> 4) & 252645135U) * 16843009U >> 24);
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x0000E568 File Offset: 0x0000C768
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int countbits(ulong x)
		{
			x -= (x >> 1 & 6148914691236517205UL);
			x = (x & 3689348814741910323UL) + (x >> 2 & 3689348814741910323UL);
			return (int)((x + (x >> 4) & 1085102592571150095UL) * 72340172838076673UL >> 56);
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x0000E5BE File Offset: 0x0000C7BE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int countbits(long x)
		{
			return math.countbits((ulong)x);
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0000E5C6 File Offset: 0x0000C7C6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int lzcnt(int x)
		{
			return math.lzcnt((uint)x);
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0000E5CE File Offset: 0x0000C7CE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 lzcnt(int2 x)
		{
			return math.int2(math.lzcnt(x.x), math.lzcnt(x.y));
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0000E5EB File Offset: 0x0000C7EB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 lzcnt(int3 x)
		{
			return math.int3(math.lzcnt(x.x), math.lzcnt(x.y), math.lzcnt(x.z));
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0000E613 File Offset: 0x0000C813
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 lzcnt(int4 x)
		{
			return math.int4(math.lzcnt(x.x), math.lzcnt(x.y), math.lzcnt(x.z), math.lzcnt(x.w));
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x0000E648 File Offset: 0x0000C848
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int lzcnt(uint x)
		{
			if (x == 0U)
			{
				return 32;
			}
			math.LongDoubleUnion longDoubleUnion;
			longDoubleUnion.doubleValue = 0.0;
			longDoubleUnion.longValue = (long)(4841369599423283200UL + (ulong)x);
			longDoubleUnion.doubleValue -= 4503599627370496.0;
			return 1054 - (int)(longDoubleUnion.longValue >> 52);
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x0000E6A2 File Offset: 0x0000C8A2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 lzcnt(uint2 x)
		{
			return math.int2(math.lzcnt(x.x), math.lzcnt(x.y));
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x0000E6BF File Offset: 0x0000C8BF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 lzcnt(uint3 x)
		{
			return math.int3(math.lzcnt(x.x), math.lzcnt(x.y), math.lzcnt(x.z));
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x0000E6E7 File Offset: 0x0000C8E7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 lzcnt(uint4 x)
		{
			return math.int4(math.lzcnt(x.x), math.lzcnt(x.y), math.lzcnt(x.z), math.lzcnt(x.w));
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x0000E71A File Offset: 0x0000C91A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int lzcnt(long x)
		{
			return math.lzcnt((ulong)x);
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x0000E724 File Offset: 0x0000C924
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int lzcnt(ulong x)
		{
			if (x == 0UL)
			{
				return 64;
			}
			uint num = (uint)(x >> 32);
			uint num2 = (num != 0U) ? num : ((uint)x);
			int num3 = (num != 0U) ? 1054 : 1086;
			math.LongDoubleUnion longDoubleUnion;
			longDoubleUnion.doubleValue = 0.0;
			longDoubleUnion.longValue = (long)(4841369599423283200UL + (ulong)num2);
			longDoubleUnion.doubleValue -= 4503599627370496.0;
			return num3 - (int)(longDoubleUnion.longValue >> 52);
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x0000E797 File Offset: 0x0000C997
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int tzcnt(int x)
		{
			return math.tzcnt((uint)x);
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x0000E79F File Offset: 0x0000C99F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 tzcnt(int2 x)
		{
			return math.int2(math.tzcnt(x.x), math.tzcnt(x.y));
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x0000E7BC File Offset: 0x0000C9BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 tzcnt(int3 x)
		{
			return math.int3(math.tzcnt(x.x), math.tzcnt(x.y), math.tzcnt(x.z));
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0000E7E4 File Offset: 0x0000C9E4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 tzcnt(int4 x)
		{
			return math.int4(math.tzcnt(x.x), math.tzcnt(x.y), math.tzcnt(x.z), math.tzcnt(x.w));
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x0000E818 File Offset: 0x0000CA18
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int tzcnt(uint x)
		{
			if (x == 0U)
			{
				return 32;
			}
			x &= (uint)(-(uint)((ulong)x));
			math.LongDoubleUnion longDoubleUnion;
			longDoubleUnion.doubleValue = 0.0;
			longDoubleUnion.longValue = (long)(4841369599423283200UL + (ulong)x);
			longDoubleUnion.doubleValue -= 4503599627370496.0;
			return (int)(longDoubleUnion.longValue >> 52) - 1023;
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0000E87A File Offset: 0x0000CA7A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 tzcnt(uint2 x)
		{
			return math.int2(math.tzcnt(x.x), math.tzcnt(x.y));
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x0000E897 File Offset: 0x0000CA97
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 tzcnt(uint3 x)
		{
			return math.int3(math.tzcnt(x.x), math.tzcnt(x.y), math.tzcnt(x.z));
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x0000E8BF File Offset: 0x0000CABF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 tzcnt(uint4 x)
		{
			return math.int4(math.tzcnt(x.x), math.tzcnt(x.y), math.tzcnt(x.z), math.tzcnt(x.w));
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x0000E8F2 File Offset: 0x0000CAF2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int tzcnt(long x)
		{
			return math.tzcnt((ulong)x);
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x0000E8FC File Offset: 0x0000CAFC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int tzcnt(ulong x)
		{
			if (x == 0UL)
			{
				return 64;
			}
			x &= -x;
			uint num = (uint)x;
			uint num2 = (num != 0U) ? num : ((uint)(x >> 32));
			int num3 = (num != 0U) ? 1023 : 991;
			math.LongDoubleUnion longDoubleUnion;
			longDoubleUnion.doubleValue = 0.0;
			longDoubleUnion.longValue = (long)(4841369599423283200UL + (ulong)num2);
			longDoubleUnion.doubleValue -= 4503599627370496.0;
			return (int)(longDoubleUnion.longValue >> 52) - num3;
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x0000E977 File Offset: 0x0000CB77
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int reversebits(int x)
		{
			return (int)math.reversebits((uint)x);
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x0000E97F File Offset: 0x0000CB7F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 reversebits(int2 x)
		{
			return (int2)math.reversebits((uint2)x);
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x0000E991 File Offset: 0x0000CB91
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 reversebits(int3 x)
		{
			return (int3)math.reversebits((uint3)x);
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x0000E9A3 File Offset: 0x0000CBA3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 reversebits(int4 x)
		{
			return (int4)math.reversebits((uint4)x);
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x0000E9B8 File Offset: 0x0000CBB8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint reversebits(uint x)
		{
			x = ((x >> 1 & 1431655765U) | (x & 1431655765U) << 1);
			x = ((x >> 2 & 858993459U) | (x & 858993459U) << 2);
			x = ((x >> 4 & 252645135U) | (x & 252645135U) << 4);
			x = ((x >> 8 & 16711935U) | (x & 16711935U) << 8);
			return x >> 16 | x << 16;
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x0000EA24 File Offset: 0x0000CC24
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 reversebits(uint2 x)
		{
			x = ((x >> 1 & 1431655765U) | (x & 1431655765U) << 1);
			x = ((x >> 2 & 858993459U) | (x & 858993459U) << 2);
			x = ((x >> 4 & 252645135U) | (x & 252645135U) << 4);
			x = ((x >> 8 & 16711935U) | (x & 16711935U) << 8);
			return x >> 16 | x << 16;
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x0000EAEC File Offset: 0x0000CCEC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 reversebits(uint3 x)
		{
			x = ((x >> 1 & 1431655765U) | (x & 1431655765U) << 1);
			x = ((x >> 2 & 858993459U) | (x & 858993459U) << 2);
			x = ((x >> 4 & 252645135U) | (x & 252645135U) << 4);
			x = ((x >> 8 & 16711935U) | (x & 16711935U) << 8);
			return x >> 16 | x << 16;
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x0000EBB4 File Offset: 0x0000CDB4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 reversebits(uint4 x)
		{
			x = ((x >> 1 & 1431655765U) | (x & 1431655765U) << 1);
			x = ((x >> 2 & 858993459U) | (x & 858993459U) << 2);
			x = ((x >> 4 & 252645135U) | (x & 252645135U) << 4);
			x = ((x >> 8 & 16711935U) | (x & 16711935U) << 8);
			return x >> 16 | x << 16;
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x0000EC7A File Offset: 0x0000CE7A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long reversebits(long x)
		{
			return (long)math.reversebits((ulong)x);
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x0000EC84 File Offset: 0x0000CE84
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong reversebits(ulong x)
		{
			x = ((x >> 1 & 6148914691236517205UL) | (x & 6148914691236517205UL) << 1);
			x = ((x >> 2 & 3689348814741910323UL) | (x & 3689348814741910323UL) << 2);
			x = ((x >> 4 & 1085102592571150095UL) | (x & 1085102592571150095UL) << 4);
			x = ((x >> 8 & 71777214294589695UL) | (x & 71777214294589695UL) << 8);
			x = ((x >> 16 & 281470681808895UL) | (x & 281470681808895UL) << 16);
			return x >> 32 | x << 32;
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x0000ED2D File Offset: 0x0000CF2D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int rol(int x, int n)
		{
			return (int)math.rol((uint)x, n);
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x0000ED36 File Offset: 0x0000CF36
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 rol(int2 x, int n)
		{
			return (int2)math.rol((uint2)x, n);
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x0000ED49 File Offset: 0x0000CF49
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 rol(int3 x, int n)
		{
			return (int3)math.rol((uint3)x, n);
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x0000ED5C File Offset: 0x0000CF5C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 rol(int4 x, int n)
		{
			return (int4)math.rol((uint4)x, n);
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x0000ED6F File Offset: 0x0000CF6F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint rol(uint x, int n)
		{
			return x << n | x >> 32 - n;
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x0000ED81 File Offset: 0x0000CF81
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 rol(uint2 x, int n)
		{
			return x << n | x >> 32 - n;
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x0000ED99 File Offset: 0x0000CF99
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 rol(uint3 x, int n)
		{
			return x << n | x >> 32 - n;
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x0000EDB1 File Offset: 0x0000CFB1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 rol(uint4 x, int n)
		{
			return x << n | x >> 32 - n;
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x0000EDC9 File Offset: 0x0000CFC9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long rol(long x, int n)
		{
			return (long)math.rol((ulong)x, n);
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x0000EDD2 File Offset: 0x0000CFD2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong rol(ulong x, int n)
		{
			return x << n | x >> 64 - n;
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0000EDE4 File Offset: 0x0000CFE4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int ror(int x, int n)
		{
			return (int)math.ror((uint)x, n);
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x0000EDED File Offset: 0x0000CFED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 ror(int2 x, int n)
		{
			return (int2)math.ror((uint2)x, n);
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x0000EE00 File Offset: 0x0000D000
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 ror(int3 x, int n)
		{
			return (int3)math.ror((uint3)x, n);
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x0000EE13 File Offset: 0x0000D013
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 ror(int4 x, int n)
		{
			return (int4)math.ror((uint4)x, n);
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x0000EE26 File Offset: 0x0000D026
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint ror(uint x, int n)
		{
			return x >> n | x << 32 - n;
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x0000EE38 File Offset: 0x0000D038
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 ror(uint2 x, int n)
		{
			return x >> n | x << 32 - n;
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x0000EE50 File Offset: 0x0000D050
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 ror(uint3 x, int n)
		{
			return x >> n | x << 32 - n;
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x0000EE68 File Offset: 0x0000D068
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 ror(uint4 x, int n)
		{
			return x >> n | x << 32 - n;
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x0000EE80 File Offset: 0x0000D080
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long ror(long x, int n)
		{
			return (long)math.ror((ulong)x, n);
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x0000EE89 File Offset: 0x0000D089
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong ror(ulong x, int n)
		{
			return x >> n | x << 64 - n;
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x0000EE9B File Offset: 0x0000D09B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int ceilpow2(int x)
		{
			x--;
			x |= x >> 1;
			x |= x >> 2;
			x |= x >> 4;
			x |= x >> 8;
			x |= x >> 16;
			return x + 1;
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x0000EECC File Offset: 0x0000D0CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 ceilpow2(int2 x)
		{
			x -= 1;
			x |= x >> 1;
			x |= x >> 2;
			x |= x >> 4;
			x |= x >> 8;
			x |= x >> 16;
			return x + 1;
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x0000EF38 File Offset: 0x0000D138
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 ceilpow2(int3 x)
		{
			x -= 1;
			x |= x >> 1;
			x |= x >> 2;
			x |= x >> 4;
			x |= x >> 8;
			x |= x >> 16;
			return x + 1;
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x0000EFA4 File Offset: 0x0000D1A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 ceilpow2(int4 x)
		{
			x -= 1;
			x |= x >> 1;
			x |= x >> 2;
			x |= x >> 4;
			x |= x >> 8;
			x |= x >> 16;
			return x + 1;
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x0000F00D File Offset: 0x0000D20D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint ceilpow2(uint x)
		{
			x -= 1U;
			x |= x >> 1;
			x |= x >> 2;
			x |= x >> 4;
			x |= x >> 8;
			x |= x >> 16;
			return x + 1U;
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x0000F03C File Offset: 0x0000D23C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 ceilpow2(uint2 x)
		{
			x -= 1U;
			x |= x >> 1;
			x |= x >> 2;
			x |= x >> 4;
			x |= x >> 8;
			x |= x >> 16;
			return x + 1U;
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x0000F0A8 File Offset: 0x0000D2A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 ceilpow2(uint3 x)
		{
			x -= 1U;
			x |= x >> 1;
			x |= x >> 2;
			x |= x >> 4;
			x |= x >> 8;
			x |= x >> 16;
			return x + 1U;
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x0000F114 File Offset: 0x0000D314
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 ceilpow2(uint4 x)
		{
			x -= 1U;
			x |= x >> 1;
			x |= x >> 2;
			x |= x >> 4;
			x |= x >> 8;
			x |= x >> 16;
			return x + 1U;
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x0000F17D File Offset: 0x0000D37D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long ceilpow2(long x)
		{
			x -= 1L;
			x |= x >> 1;
			x |= x >> 2;
			x |= x >> 4;
			x |= x >> 8;
			x |= x >> 16;
			x |= x >> 32;
			return x + 1L;
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x0000F1B5 File Offset: 0x0000D3B5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong ceilpow2(ulong x)
		{
			x -= 1UL;
			x |= x >> 1;
			x |= x >> 2;
			x |= x >> 4;
			x |= x >> 8;
			x |= x >> 16;
			x |= x >> 32;
			return x + 1UL;
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x0000F1ED File Offset: 0x0000D3ED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int ceillog2(int x)
		{
			return 32 - math.lzcnt((uint)(x - 1));
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x0000F1FA File Offset: 0x0000D3FA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 ceillog2(int2 x)
		{
			return new int2(math.ceillog2(x.x), math.ceillog2(x.y));
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x0000F217 File Offset: 0x0000D417
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 ceillog2(int3 x)
		{
			return new int3(math.ceillog2(x.x), math.ceillog2(x.y), math.ceillog2(x.z));
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x0000F23F File Offset: 0x0000D43F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 ceillog2(int4 x)
		{
			return new int4(math.ceillog2(x.x), math.ceillog2(x.y), math.ceillog2(x.z), math.ceillog2(x.w));
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x0000F272 File Offset: 0x0000D472
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int ceillog2(uint x)
		{
			return 32 - math.lzcnt(x - 1U);
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x0000F27F File Offset: 0x0000D47F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 ceillog2(uint2 x)
		{
			return new int2(math.ceillog2(x.x), math.ceillog2(x.y));
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x0000F29C File Offset: 0x0000D49C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 ceillog2(uint3 x)
		{
			return new int3(math.ceillog2(x.x), math.ceillog2(x.y), math.ceillog2(x.z));
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x0000F2C4 File Offset: 0x0000D4C4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 ceillog2(uint4 x)
		{
			return new int4(math.ceillog2(x.x), math.ceillog2(x.y), math.ceillog2(x.z), math.ceillog2(x.w));
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x0000F2F7 File Offset: 0x0000D4F7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int floorlog2(int x)
		{
			return 31 - math.lzcnt((uint)x);
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x0000F302 File Offset: 0x0000D502
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 floorlog2(int2 x)
		{
			return new int2(math.floorlog2(x.x), math.floorlog2(x.y));
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x0000F31F File Offset: 0x0000D51F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 floorlog2(int3 x)
		{
			return new int3(math.floorlog2(x.x), math.floorlog2(x.y), math.floorlog2(x.z));
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x0000F347 File Offset: 0x0000D547
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 floorlog2(int4 x)
		{
			return new int4(math.floorlog2(x.x), math.floorlog2(x.y), math.floorlog2(x.z), math.floorlog2(x.w));
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x0000F37A File Offset: 0x0000D57A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int floorlog2(uint x)
		{
			return 31 - math.lzcnt(x);
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x0000F385 File Offset: 0x0000D585
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 floorlog2(uint2 x)
		{
			return new int2(math.floorlog2(x.x), math.floorlog2(x.y));
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x0000F3A2 File Offset: 0x0000D5A2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 floorlog2(uint3 x)
		{
			return new int3(math.floorlog2(x.x), math.floorlog2(x.y), math.floorlog2(x.z));
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x0000F3CA File Offset: 0x0000D5CA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 floorlog2(uint4 x)
		{
			return new int4(math.floorlog2(x.x), math.floorlog2(x.y), math.floorlog2(x.z), math.floorlog2(x.w));
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x0000F3FD File Offset: 0x0000D5FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float radians(float x)
		{
			return x * 0.017453292f;
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x0000F406 File Offset: 0x0000D606
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 radians(float2 x)
		{
			return x * 0.017453292f;
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x0000F413 File Offset: 0x0000D613
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 radians(float3 x)
		{
			return x * 0.017453292f;
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x0000F420 File Offset: 0x0000D620
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 radians(float4 x)
		{
			return x * 0.017453292f;
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x0000F42D File Offset: 0x0000D62D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double radians(double x)
		{
			return x * 0.017453292519943295;
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x0000F43A File Offset: 0x0000D63A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 radians(double2 x)
		{
			return x * 0.017453292519943295;
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x0000F44B File Offset: 0x0000D64B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 radians(double3 x)
		{
			return x * 0.017453292519943295;
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x0000F45C File Offset: 0x0000D65C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 radians(double4 x)
		{
			return x * 0.017453292519943295;
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0000F46D File Offset: 0x0000D66D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float degrees(float x)
		{
			return x * 57.29578f;
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0000F476 File Offset: 0x0000D676
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 degrees(float2 x)
		{
			return x * 57.29578f;
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0000F483 File Offset: 0x0000D683
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 degrees(float3 x)
		{
			return x * 57.29578f;
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0000F490 File Offset: 0x0000D690
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 degrees(float4 x)
		{
			return x * 57.29578f;
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x0000F49D File Offset: 0x0000D69D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double degrees(double x)
		{
			return x * 57.29577951308232;
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x0000F4AA File Offset: 0x0000D6AA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 degrees(double2 x)
		{
			return x * 57.29577951308232;
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0000F4BB File Offset: 0x0000D6BB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 degrees(double3 x)
		{
			return x * 57.29577951308232;
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x0000F4CC File Offset: 0x0000D6CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 degrees(double4 x)
		{
			return x * 57.29577951308232;
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x0000F4DD File Offset: 0x0000D6DD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int cmin(int2 x)
		{
			return math.min(x.x, x.y);
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x0000F4F0 File Offset: 0x0000D6F0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int cmin(int3 x)
		{
			return math.min(math.min(x.x, x.y), x.z);
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x0000F50E File Offset: 0x0000D70E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int cmin(int4 x)
		{
			return math.min(math.min(x.x, x.y), math.min(x.z, x.w));
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x0000F537 File Offset: 0x0000D737
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint cmin(uint2 x)
		{
			return math.min(x.x, x.y);
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0000F54A File Offset: 0x0000D74A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint cmin(uint3 x)
		{
			return math.min(math.min(x.x, x.y), x.z);
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0000F568 File Offset: 0x0000D768
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint cmin(uint4 x)
		{
			return math.min(math.min(x.x, x.y), math.min(x.z, x.w));
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x0000F591 File Offset: 0x0000D791
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float cmin(float2 x)
		{
			return math.min(x.x, x.y);
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x0000F5A4 File Offset: 0x0000D7A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float cmin(float3 x)
		{
			return math.min(math.min(x.x, x.y), x.z);
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x0000F5C2 File Offset: 0x0000D7C2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float cmin(float4 x)
		{
			return math.min(math.min(x.x, x.y), math.min(x.z, x.w));
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x0000F5EB File Offset: 0x0000D7EB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double cmin(double2 x)
		{
			return math.min(x.x, x.y);
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x0000F5FE File Offset: 0x0000D7FE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double cmin(double3 x)
		{
			return math.min(math.min(x.x, x.y), x.z);
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x0000F61C File Offset: 0x0000D81C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double cmin(double4 x)
		{
			return math.min(math.min(x.x, x.y), math.min(x.z, x.w));
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x0000F645 File Offset: 0x0000D845
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int cmax(int2 x)
		{
			return math.max(x.x, x.y);
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x0000F658 File Offset: 0x0000D858
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int cmax(int3 x)
		{
			return math.max(math.max(x.x, x.y), x.z);
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x0000F676 File Offset: 0x0000D876
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int cmax(int4 x)
		{
			return math.max(math.max(x.x, x.y), math.max(x.z, x.w));
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x0000F69F File Offset: 0x0000D89F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint cmax(uint2 x)
		{
			return math.max(x.x, x.y);
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x0000F6B2 File Offset: 0x0000D8B2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint cmax(uint3 x)
		{
			return math.max(math.max(x.x, x.y), x.z);
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x0000F6D0 File Offset: 0x0000D8D0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint cmax(uint4 x)
		{
			return math.max(math.max(x.x, x.y), math.max(x.z, x.w));
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x0000F6F9 File Offset: 0x0000D8F9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float cmax(float2 x)
		{
			return math.max(x.x, x.y);
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x0000F70C File Offset: 0x0000D90C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float cmax(float3 x)
		{
			return math.max(math.max(x.x, x.y), x.z);
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x0000F72A File Offset: 0x0000D92A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float cmax(float4 x)
		{
			return math.max(math.max(x.x, x.y), math.max(x.z, x.w));
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x0000F753 File Offset: 0x0000D953
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double cmax(double2 x)
		{
			return math.max(x.x, x.y);
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x0000F766 File Offset: 0x0000D966
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double cmax(double3 x)
		{
			return math.max(math.max(x.x, x.y), x.z);
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x0000F784 File Offset: 0x0000D984
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double cmax(double4 x)
		{
			return math.max(math.max(x.x, x.y), math.max(x.z, x.w));
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x0000F7AD File Offset: 0x0000D9AD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int csum(int2 x)
		{
			return x.x + x.y;
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x0000F7BC File Offset: 0x0000D9BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int csum(int3 x)
		{
			return x.x + x.y + x.z;
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x0000F7D2 File Offset: 0x0000D9D2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int csum(int4 x)
		{
			return x.x + x.y + x.z + x.w;
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0000F7EF File Offset: 0x0000D9EF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint csum(uint2 x)
		{
			return x.x + x.y;
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x0000F7FE File Offset: 0x0000D9FE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint csum(uint3 x)
		{
			return x.x + x.y + x.z;
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x0000F814 File Offset: 0x0000DA14
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint csum(uint4 x)
		{
			return x.x + x.y + x.z + x.w;
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x0000F831 File Offset: 0x0000DA31
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float csum(float2 x)
		{
			return x.x + x.y;
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x0000F840 File Offset: 0x0000DA40
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float csum(float3 x)
		{
			return x.x + x.y + x.z;
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x0000F856 File Offset: 0x0000DA56
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float csum(float4 x)
		{
			return x.x + x.y + (x.z + x.w);
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x0000F873 File Offset: 0x0000DA73
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double csum(double2 x)
		{
			return x.x + x.y;
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x0000F882 File Offset: 0x0000DA82
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double csum(double3 x)
		{
			return x.x + x.y + x.z;
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0000F898 File Offset: 0x0000DA98
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double csum(double4 x)
		{
			return x.x + x.y + (x.z + x.w);
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0000F8B8 File Offset: 0x0000DAB8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int compress(int* output, int index, int4 val, bool4 mask)
		{
			if (mask.x)
			{
				output[index++] = val.x;
			}
			if (mask.y)
			{
				output[index++] = val.y;
			}
			if (mask.z)
			{
				output[index++] = val.z;
			}
			if (mask.w)
			{
				output[index++] = val.w;
			}
			return index;
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x0000F92E File Offset: 0x0000DB2E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int compress(uint* output, int index, uint4 val, bool4 mask)
		{
			return math.compress((int*)output, index, *(int4*)(&val), mask);
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x0000F940 File Offset: 0x0000DB40
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static int compress(float* output, int index, float4 val, bool4 mask)
		{
			return math.compress((int*)output, index, *(int4*)(&val), mask);
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x0000F954 File Offset: 0x0000DB54
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float f16tof32(uint x)
		{
			uint num = (x & 32767U) << 13;
			uint num2 = num & 260046848U;
			uint num3 = num + 939524096U + math.select(0U, 939524096U, num2 == 260046848U);
			return math.asfloat(math.select(num3, math.asuint(math.asfloat(num3 + 8388608U) - 6.1035156E-05f), num2 == 0U) | (x & 32768U) << 16);
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x0000F9C0 File Offset: 0x0000DBC0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 f16tof32(uint2 x)
		{
			uint2 lhs = (x & 32767U) << 13;
			uint2 lhs2 = lhs & 260046848U;
			uint2 @uint = lhs + 939524096U + math.select(0U, 939524096U, lhs2 == 260046848U);
			return math.asfloat(math.select(@uint, math.asuint(math.asfloat(@uint + 8388608U) - 6.1035156E-05f), lhs2 == 0U) | (x & 32768U) << 16);
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x0000FA64 File Offset: 0x0000DC64
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 f16tof32(uint3 x)
		{
			uint3 lhs = (x & 32767U) << 13;
			uint3 lhs2 = lhs & 260046848U;
			uint3 @uint = lhs + 939524096U + math.select(0U, 939524096U, lhs2 == 260046848U);
			return math.asfloat(math.select(@uint, math.asuint(math.asfloat(@uint + 8388608U) - 6.1035156E-05f), lhs2 == 0U) | (x & 32768U) << 16);
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x0000FB08 File Offset: 0x0000DD08
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 f16tof32(uint4 x)
		{
			uint4 lhs = (x & 32767U) << 13;
			uint4 lhs2 = lhs & 260046848U;
			uint4 @uint = lhs + 939524096U + math.select(0U, 939524096U, lhs2 == 260046848U);
			return math.asfloat(math.select(@uint, math.asuint(math.asfloat(@uint + 8388608U) - 6.1035156E-05f), lhs2 == 0U) | (x & 32768U) << 16);
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x0000FBAC File Offset: 0x0000DDAC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint f32tof16(float x)
		{
			uint num = math.asuint(x);
			uint num2 = num & 2147479552U;
			return math.select(math.asuint(math.min(math.asfloat(num2) * 1.92593E-34f, 260042750f)) + 4096U >> 13, math.select(31744U, 32256U, num2 > 2139095040U), num2 >= 2139095040U) | (num & 2147487743U) >> 16;
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x0000FC20 File Offset: 0x0000DE20
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 f32tof16(float2 x)
		{
			uint2 lhs = math.asuint(x);
			uint2 @uint = lhs & 2147479552U;
			return math.select((uint2)(math.asint(math.min(math.asfloat(@uint) * 1.92593E-34f, 260042750f)) + 4096) >> 13, math.select(31744U, 32256U, (int2)@uint > 2139095040), (int2)@uint >= 2139095040) | (lhs & 2147487743U) >> 16;
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x0000FCD0 File Offset: 0x0000DED0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 f32tof16(float3 x)
		{
			uint3 lhs = math.asuint(x);
			uint3 @uint = lhs & 2147479552U;
			return math.select((uint3)(math.asint(math.min(math.asfloat(@uint) * 1.92593E-34f, 260042750f)) + 4096) >> 13, math.select(31744U, 32256U, (int3)@uint > 2139095040), (int3)@uint >= 2139095040) | (lhs & 2147487743U) >> 16;
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x0000FD80 File Offset: 0x0000DF80
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 f32tof16(float4 x)
		{
			uint4 lhs = math.asuint(x);
			uint4 @uint = lhs & 2147479552U;
			return math.select((uint4)(math.asint(math.min(math.asfloat(@uint) * 1.92593E-34f, 260042750f)) + 4096) >> 13, math.select(31744U, 32256U, (int4)@uint > 2139095040), (int4)@uint >= 2139095040) | (lhs & 2147487743U) >> 16;
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x0000FE30 File Offset: 0x0000E030
		public unsafe static uint hash(void* pBuffer, int numBytes, uint seed = 0U)
		{
			uint4* ptr = (uint4*)pBuffer;
			uint num = seed + 374761393U;
			if (numBytes >= 16)
			{
				uint4 @uint = new uint4(606290984U, 2246822519U, 0U, 1640531535U) + seed;
				int num2 = numBytes >> 4;
				for (int i = 0; i < num2; i++)
				{
					@uint += *(ptr++) * 2246822519U;
					@uint = (@uint << 13 | @uint >> 19);
					@uint *= 2654435761U;
				}
				num = math.rol(@uint.x, 1) + math.rol(@uint.y, 7) + math.rol(@uint.z, 12) + math.rol(@uint.w, 18);
			}
			num += (uint)numBytes;
			uint* ptr2 = (uint*)ptr;
			for (int j = 0; j < (numBytes >> 2 & 3); j++)
			{
				num += *(ptr2++) * 3266489917U;
				num = math.rol(num, 17) * 668265263U;
			}
			byte* ptr3 = (byte*)ptr2;
			for (int k = 0; k < (numBytes & 3); k++)
			{
				num += (uint)(*(ptr3++)) * 374761393U;
				num = math.rol(num, 11) * 2654435761U;
			}
			num ^= num >> 15;
			num *= 2246822519U;
			num ^= num >> 13;
			num *= 3266489917U;
			return num ^ num >> 16;
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x0000FF95 File Offset: 0x0000E195
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 up()
		{
			return new float3(0f, 1f, 0f);
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x0000FFAB File Offset: 0x0000E1AB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 down()
		{
			return new float3(0f, -1f, 0f);
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x0000FFC1 File Offset: 0x0000E1C1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 forward()
		{
			return new float3(0f, 0f, 1f);
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x0000FFD7 File Offset: 0x0000E1D7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 back()
		{
			return new float3(0f, 0f, -1f);
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x0000FFED File Offset: 0x0000E1ED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 left()
		{
			return new float3(-1f, 0f, 0f);
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x00010003 File Offset: 0x0000E203
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 right()
		{
			return new float3(1f, 0f, 0f);
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x00010019 File Offset: 0x0000E219
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static float4 unpacklo(float4 a, float4 b)
		{
			return math.shuffle(a, b, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightY);
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x00010026 File Offset: 0x0000E226
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static double4 unpacklo(double4 a, double4 b)
		{
			return math.shuffle(a, b, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightY);
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x00010033 File Offset: 0x0000E233
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static float4 unpackhi(float4 a, float4 b)
		{
			return math.shuffle(a, b, math.ShuffleComponent.LeftZ, math.ShuffleComponent.RightZ, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightW);
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x00010040 File Offset: 0x0000E240
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static double4 unpackhi(double4 a, double4 b)
		{
			return math.shuffle(a, b, math.ShuffleComponent.LeftZ, math.ShuffleComponent.RightZ, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightW);
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x0001004D File Offset: 0x0000E24D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static float4 movelh(float4 a, float4 b)
		{
			return math.shuffle(a, b, math.ShuffleComponent.LeftX, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightX, math.ShuffleComponent.RightY);
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0001005A File Offset: 0x0000E25A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static double4 movelh(double4 a, double4 b)
		{
			return math.shuffle(a, b, math.ShuffleComponent.LeftX, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightX, math.ShuffleComponent.RightY);
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x00010067 File Offset: 0x0000E267
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static float4 movehl(float4 a, float4 b)
		{
			return math.shuffle(b, a, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightZ, math.ShuffleComponent.RightW);
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x00010074 File Offset: 0x0000E274
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static double4 movehl(double4 a, double4 b)
		{
			return math.shuffle(b, a, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightZ, math.ShuffleComponent.RightW);
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x00010084 File Offset: 0x0000E284
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static uint fold_to_uint(double x)
		{
			math.LongDoubleUnion longDoubleUnion;
			longDoubleUnion.longValue = 0L;
			longDoubleUnion.doubleValue = x;
			return (uint)(longDoubleUnion.longValue >> 32) ^ (uint)longDoubleUnion.longValue;
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x000100B4 File Offset: 0x0000E2B4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static uint2 fold_to_uint(double2 x)
		{
			return math.uint2(math.fold_to_uint(x.x), math.fold_to_uint(x.y));
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x000100D1 File Offset: 0x0000E2D1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static uint3 fold_to_uint(double3 x)
		{
			return math.uint3(math.fold_to_uint(x.x), math.fold_to_uint(x.y), math.fold_to_uint(x.z));
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x000100F9 File Offset: 0x0000E2F9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static uint4 fold_to_uint(double4 x)
		{
			return math.uint4(math.fold_to_uint(x.x), math.fold_to_uint(x.y), math.fold_to_uint(x.z), math.fold_to_uint(x.w));
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x0001012C File Offset: 0x0000E32C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 float3x3(float4x4 f4x4)
		{
			return new float3x3(f4x4);
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x00010134 File Offset: 0x0000E334
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 float3x3(quaternion rotation)
		{
			return new float3x3(rotation);
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x0001013C File Offset: 0x0000E33C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 float4x4(float3x3 rotation, float3 translation)
		{
			return new float4x4(rotation, translation);
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x00010145 File Offset: 0x0000E345
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 float4x4(quaternion rotation, float3 translation)
		{
			return new float4x4(rotation, translation);
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x0001014E File Offset: 0x0000E34E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 float4x4(RigidTransform transform)
		{
			return new float4x4(transform);
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x00010158 File Offset: 0x0000E358
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 orthonormalize(float3x3 i)
		{
			float3 c = i.c0;
			float3 @float = i.c1 - i.c0 * math.dot(i.c1, i.c0);
			float num = math.length(c);
			float num2 = math.length(@float);
			bool c2 = num > 1E-30f && num2 > 1E-30f;
			float3x3 float3x;
			float3x.c0 = math.select(math.float3(1f, 0f, 0f), c / num, c2);
			float3x.c1 = math.select(math.float3(0f, 1f, 0f), @float / num2, c2);
			float3x.c2 = math.cross(float3x.c0, float3x.c1);
			return float3x;
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x00010225 File Offset: 0x0000E425
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float mul(float a, float b)
		{
			return a * b;
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x0001022A File Offset: 0x0000E42A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float mul(float2 a, float2 b)
		{
			return a.x * b.x + a.y * b.y;
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x00010248 File Offset: 0x0000E448
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 mul(float2 a, float2x2 b)
		{
			return math.float2(a.x * b.c0.x + a.y * b.c0.y, a.x * b.c1.x + a.y * b.c1.y);
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x000102A4 File Offset: 0x0000E4A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 mul(float2 a, float2x3 b)
		{
			return math.float3(a.x * b.c0.x + a.y * b.c0.y, a.x * b.c1.x + a.y * b.c1.y, a.x * b.c2.x + a.y * b.c2.y);
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x00010328 File Offset: 0x0000E528
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 mul(float2 a, float2x4 b)
		{
			return math.float4(a.x * b.c0.x + a.y * b.c0.y, a.x * b.c1.x + a.y * b.c1.y, a.x * b.c2.x + a.y * b.c2.y, a.x * b.c3.x + a.y * b.c3.y);
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x000103CE File Offset: 0x0000E5CE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float mul(float3 a, float3 b)
		{
			return a.x * b.x + a.y * b.y + a.z * b.z;
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x000103FC File Offset: 0x0000E5FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 mul(float3 a, float3x2 b)
		{
			return math.float2(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z);
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x00010480 File Offset: 0x0000E680
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 mul(float3 a, float3x3 b)
		{
			return math.float3(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z, a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z);
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x0001053C File Offset: 0x0000E73C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 mul(float3 a, float3x4 b)
		{
			return math.float4(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z, a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z, a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z);
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x0001062E File Offset: 0x0000E82E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float mul(float4 a, float4 b)
		{
			return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x00010668 File Offset: 0x0000E868
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 mul(float4 a, float4x2 b)
		{
			return math.float2(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w);
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x00010710 File Offset: 0x0000E910
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 mul(float4 a, float4x3 b)
		{
			return math.float3(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w, a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w);
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x00010804 File Offset: 0x0000EA04
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 mul(float4 a, float4x4 b)
		{
			return math.float4(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w, a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w, a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z + a.w * b.c3.w);
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x00010942 File Offset: 0x0000EB42
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 mul(float2x2 a, float2 b)
		{
			return a.c0 * b.x + a.c1 * b.y;
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x0001096C File Offset: 0x0000EB6C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x2 mul(float2x2 a, float2x2 b)
		{
			return math.float2x2(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y);
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x000109E0 File Offset: 0x0000EBE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 mul(float2x2 a, float2x3 b)
		{
			return math.float2x3(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y);
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x00010A88 File Offset: 0x0000EC88
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 mul(float2x2 a, float2x4 b)
		{
			return math.float2x4(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y, a.c0 * b.c3.x + a.c1 * b.c3.y);
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x00010B5E File Offset: 0x0000ED5E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 mul(float2x3 a, float3 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x00010BA0 File Offset: 0x0000EDA0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x2 mul(float2x3 a, float3x2 b)
		{
			return math.float2x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x00010C4C File Offset: 0x0000EE4C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 mul(float2x3 a, float3x3 b)
		{
			return math.float2x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x00010D44 File Offset: 0x0000EF44
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 mul(float2x3 a, float3x4 b)
		{
			return math.float2x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x00010E88 File Offset: 0x0000F088
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 mul(float2x4 a, float4 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x00010EE8 File Offset: 0x0000F0E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x2 mul(float2x4 a, float4x2 b)
		{
			return math.float2x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x00010FC8 File Offset: 0x0000F1C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x3 mul(float2x4 a, float4x3 b)
		{
			return math.float2x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x00011110 File Offset: 0x0000F310
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 mul(float2x4 a, float4x4 b)
		{
			return math.float2x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x000112BE File Offset: 0x0000F4BE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 mul(float3x2 a, float2 b)
		{
			return a.c0 * b.x + a.c1 * b.y;
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x000112E8 File Offset: 0x0000F4E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 mul(float3x2 a, float2x2 b)
		{
			return math.float3x2(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y);
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0001135C File Offset: 0x0000F55C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 mul(float3x2 a, float2x3 b)
		{
			return math.float3x3(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y);
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x00011404 File Offset: 0x0000F604
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 mul(float3x2 a, float2x4 b)
		{
			return math.float3x4(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y, a.c0 * b.c3.x + a.c1 * b.c3.y);
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x000114DA File Offset: 0x0000F6DA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 mul(float3x3 a, float3 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x0001151C File Offset: 0x0000F71C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 mul(float3x3 a, float3x2 b)
		{
			return math.float3x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x000115C8 File Offset: 0x0000F7C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 mul(float3x3 a, float3x3 b)
		{
			return math.float3x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x000116C0 File Offset: 0x0000F8C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 mul(float3x3 a, float3x4 b)
		{
			return math.float3x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x00011804 File Offset: 0x0000FA04
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 mul(float3x4 a, float4 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x00011864 File Offset: 0x0000FA64
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x2 mul(float3x4 a, float4x2 b)
		{
			return math.float3x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x00011944 File Offset: 0x0000FB44
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x3 mul(float3x4 a, float4x3 b)
		{
			return math.float3x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x00011A8C File Offset: 0x0000FC8C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3x4 mul(float3x4 a, float4x4 b)
		{
			return math.float3x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x00011C3A File Offset: 0x0000FE3A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 mul(float4x2 a, float2 b)
		{
			return a.c0 * b.x + a.c1 * b.y;
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x00011C64 File Offset: 0x0000FE64
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 mul(float4x2 a, float2x2 b)
		{
			return math.float4x2(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y);
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x00011CD8 File Offset: 0x0000FED8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 mul(float4x2 a, float2x3 b)
		{
			return math.float4x3(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y);
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x00011D80 File Offset: 0x0000FF80
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 mul(float4x2 a, float2x4 b)
		{
			return math.float4x4(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y, a.c0 * b.c3.x + a.c1 * b.c3.y);
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x00011E56 File Offset: 0x00010056
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 mul(float4x3 a, float3 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x00011E98 File Offset: 0x00010098
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 mul(float4x3 a, float3x2 b)
		{
			return math.float4x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x00011F44 File Offset: 0x00010144
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 mul(float4x3 a, float3x3 b)
		{
			return math.float4x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x0001203C File Offset: 0x0001023C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 mul(float4x3 a, float3x4 b)
		{
			return math.float4x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x00012180 File Offset: 0x00010380
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 mul(float4x4 a, float4 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x000121E0 File Offset: 0x000103E0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 mul(float4x4 a, float4x2 b)
		{
			return math.float4x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x000122C0 File Offset: 0x000104C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 mul(float4x4 a, float4x3 b)
		{
			return math.float4x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x00012408 File Offset: 0x00010608
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 mul(float4x4 a, float4x4 b)
		{
			return math.float4x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x000125B6 File Offset: 0x000107B6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double mul(double a, double b)
		{
			return a * b;
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x000125BB File Offset: 0x000107BB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double mul(double2 a, double2 b)
		{
			return a.x * b.x + a.y * b.y;
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x000125D8 File Offset: 0x000107D8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 mul(double2 a, double2x2 b)
		{
			return math.double2(a.x * b.c0.x + a.y * b.c0.y, a.x * b.c1.x + a.y * b.c1.y);
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x00012634 File Offset: 0x00010834
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 mul(double2 a, double2x3 b)
		{
			return math.double3(a.x * b.c0.x + a.y * b.c0.y, a.x * b.c1.x + a.y * b.c1.y, a.x * b.c2.x + a.y * b.c2.y);
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x000126B8 File Offset: 0x000108B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 mul(double2 a, double2x4 b)
		{
			return math.double4(a.x * b.c0.x + a.y * b.c0.y, a.x * b.c1.x + a.y * b.c1.y, a.x * b.c2.x + a.y * b.c2.y, a.x * b.c3.x + a.y * b.c3.y);
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x0001275E File Offset: 0x0001095E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double mul(double3 a, double3 b)
		{
			return a.x * b.x + a.y * b.y + a.z * b.z;
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x0001278C File Offset: 0x0001098C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 mul(double3 a, double3x2 b)
		{
			return math.double2(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z);
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x00012810 File Offset: 0x00010A10
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 mul(double3 a, double3x3 b)
		{
			return math.double3(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z, a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z);
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x000128CC File Offset: 0x00010ACC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 mul(double3 a, double3x4 b)
		{
			return math.double4(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z, a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z, a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z);
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x000129BE File Offset: 0x00010BBE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double mul(double4 a, double4 b)
		{
			return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x000129F8 File Offset: 0x00010BF8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 mul(double4 a, double4x2 b)
		{
			return math.double2(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w);
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x00012AA0 File Offset: 0x00010CA0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 mul(double4 a, double4x3 b)
		{
			return math.double3(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w, a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w);
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x00012B94 File Offset: 0x00010D94
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 mul(double4 a, double4x4 b)
		{
			return math.double4(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w, a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w, a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z + a.w * b.c3.w);
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x00012CD2 File Offset: 0x00010ED2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 mul(double2x2 a, double2 b)
		{
			return a.c0 * b.x + a.c1 * b.y;
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x00012CFC File Offset: 0x00010EFC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x2 mul(double2x2 a, double2x2 b)
		{
			return math.double2x2(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y);
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x00012D70 File Offset: 0x00010F70
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 mul(double2x2 a, double2x3 b)
		{
			return math.double2x3(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y);
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x00012E18 File Offset: 0x00011018
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 mul(double2x2 a, double2x4 b)
		{
			return math.double2x4(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y, a.c0 * b.c3.x + a.c1 * b.c3.y);
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x00012EEE File Offset: 0x000110EE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 mul(double2x3 a, double3 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x00012F30 File Offset: 0x00011130
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x2 mul(double2x3 a, double3x2 b)
		{
			return math.double2x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x00012FDC File Offset: 0x000111DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 mul(double2x3 a, double3x3 b)
		{
			return math.double2x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x000130D4 File Offset: 0x000112D4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 mul(double2x3 a, double3x4 b)
		{
			return math.double2x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x00013218 File Offset: 0x00011418
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 mul(double2x4 a, double4 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x00013278 File Offset: 0x00011478
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x2 mul(double2x4 a, double4x2 b)
		{
			return math.double2x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x00013358 File Offset: 0x00011558
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 mul(double2x4 a, double4x3 b)
		{
			return math.double2x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x000134A0 File Offset: 0x000116A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 mul(double2x4 a, double4x4 b)
		{
			return math.double2x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x0001364E File Offset: 0x0001184E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 mul(double3x2 a, double2 b)
		{
			return a.c0 * b.x + a.c1 * b.y;
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x00013678 File Offset: 0x00011878
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 mul(double3x2 a, double2x2 b)
		{
			return math.double3x2(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y);
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x000136EC File Offset: 0x000118EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 mul(double3x2 a, double2x3 b)
		{
			return math.double3x3(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y);
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x00013794 File Offset: 0x00011994
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x4 mul(double3x2 a, double2x4 b)
		{
			return math.double3x4(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y, a.c0 * b.c3.x + a.c1 * b.c3.y);
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0001386A File Offset: 0x00011A6A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 mul(double3x3 a, double3 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x000138AC File Offset: 0x00011AAC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 mul(double3x3 a, double3x2 b)
		{
			return math.double3x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x00013958 File Offset: 0x00011B58
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 mul(double3x3 a, double3x3 b)
		{
			return math.double3x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x00013A50 File Offset: 0x00011C50
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x4 mul(double3x3 a, double3x4 b)
		{
			return math.double3x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x00013B94 File Offset: 0x00011D94
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 mul(double3x4 a, double4 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x00013BF4 File Offset: 0x00011DF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 mul(double3x4 a, double4x2 b)
		{
			return math.double3x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x00013CD4 File Offset: 0x00011ED4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 mul(double3x4 a, double4x3 b)
		{
			return math.double3x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x00013E1C File Offset: 0x0001201C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x4 mul(double3x4 a, double4x4 b)
		{
			return math.double3x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x00013FCA File Offset: 0x000121CA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 mul(double4x2 a, double2 b)
		{
			return a.c0 * b.x + a.c1 * b.y;
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x00013FF4 File Offset: 0x000121F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 mul(double4x2 a, double2x2 b)
		{
			return math.double4x2(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y);
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x00014068 File Offset: 0x00012268
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 mul(double4x2 a, double2x3 b)
		{
			return math.double4x3(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y);
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x00014110 File Offset: 0x00012310
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x4 mul(double4x2 a, double2x4 b)
		{
			return math.double4x4(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y, a.c0 * b.c3.x + a.c1 * b.c3.y);
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x000141E6 File Offset: 0x000123E6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 mul(double4x3 a, double3 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x00014228 File Offset: 0x00012428
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 mul(double4x3 a, double3x2 b)
		{
			return math.double4x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x000142D4 File Offset: 0x000124D4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 mul(double4x3 a, double3x3 b)
		{
			return math.double4x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x000143CC File Offset: 0x000125CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x4 mul(double4x3 a, double3x4 b)
		{
			return math.double4x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x00014510 File Offset: 0x00012710
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 mul(double4x4 a, double4 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x00014570 File Offset: 0x00012770
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 mul(double4x4 a, double4x2 b)
		{
			return math.double4x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x00014650 File Offset: 0x00012850
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 mul(double4x4 a, double4x3 b)
		{
			return math.double4x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x00014798 File Offset: 0x00012998
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x4 mul(double4x4 a, double4x4 b)
		{
			return math.double4x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x00014946 File Offset: 0x00012B46
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int mul(int a, int b)
		{
			return a * b;
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x0001494B File Offset: 0x00012B4B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int mul(int2 a, int2 b)
		{
			return a.x * b.x + a.y * b.y;
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x00014968 File Offset: 0x00012B68
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 mul(int2 a, int2x2 b)
		{
			return math.int2(a.x * b.c0.x + a.y * b.c0.y, a.x * b.c1.x + a.y * b.c1.y);
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x000149C4 File Offset: 0x00012BC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 mul(int2 a, int2x3 b)
		{
			return math.int3(a.x * b.c0.x + a.y * b.c0.y, a.x * b.c1.x + a.y * b.c1.y, a.x * b.c2.x + a.y * b.c2.y);
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x00014A48 File Offset: 0x00012C48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 mul(int2 a, int2x4 b)
		{
			return math.int4(a.x * b.c0.x + a.y * b.c0.y, a.x * b.c1.x + a.y * b.c1.y, a.x * b.c2.x + a.y * b.c2.y, a.x * b.c3.x + a.y * b.c3.y);
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x00014AEE File Offset: 0x00012CEE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int mul(int3 a, int3 b)
		{
			return a.x * b.x + a.y * b.y + a.z * b.z;
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x00014B1C File Offset: 0x00012D1C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 mul(int3 a, int3x2 b)
		{
			return math.int2(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z);
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x00014BA0 File Offset: 0x00012DA0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 mul(int3 a, int3x3 b)
		{
			return math.int3(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z, a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z);
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x00014C5C File Offset: 0x00012E5C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 mul(int3 a, int3x4 b)
		{
			return math.int4(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z, a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z, a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z);
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x00014D4E File Offset: 0x00012F4E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int mul(int4 a, int4 b)
		{
			return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x00014D88 File Offset: 0x00012F88
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 mul(int4 a, int4x2 b)
		{
			return math.int2(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w);
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x00014E30 File Offset: 0x00013030
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 mul(int4 a, int4x3 b)
		{
			return math.int3(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w, a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w);
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x00014F24 File Offset: 0x00013124
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 mul(int4 a, int4x4 b)
		{
			return math.int4(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w, a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w, a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z + a.w * b.c3.w);
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x00015062 File Offset: 0x00013262
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 mul(int2x2 a, int2 b)
		{
			return a.c0 * b.x + a.c1 * b.y;
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x0001508C File Offset: 0x0001328C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 mul(int2x2 a, int2x2 b)
		{
			return math.int2x2(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y);
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x00015100 File Offset: 0x00013300
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 mul(int2x2 a, int2x3 b)
		{
			return math.int2x3(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y);
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x000151A8 File Offset: 0x000133A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 mul(int2x2 a, int2x4 b)
		{
			return math.int2x4(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y, a.c0 * b.c3.x + a.c1 * b.c3.y);
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x0001527E File Offset: 0x0001347E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 mul(int2x3 a, int3 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x000152C0 File Offset: 0x000134C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 mul(int2x3 a, int3x2 b)
		{
			return math.int2x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x0001536C File Offset: 0x0001356C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 mul(int2x3 a, int3x3 b)
		{
			return math.int2x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x00015464 File Offset: 0x00013664
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 mul(int2x3 a, int3x4 b)
		{
			return math.int2x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x000155A8 File Offset: 0x000137A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 mul(int2x4 a, int4 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x00015608 File Offset: 0x00013808
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 mul(int2x4 a, int4x2 b)
		{
			return math.int2x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x000156E8 File Offset: 0x000138E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 mul(int2x4 a, int4x3 b)
		{
			return math.int2x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x00015830 File Offset: 0x00013A30
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 mul(int2x4 a, int4x4 b)
		{
			return math.int2x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x000159DE File Offset: 0x00013BDE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 mul(int3x2 a, int2 b)
		{
			return a.c0 * b.x + a.c1 * b.y;
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x00015A08 File Offset: 0x00013C08
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 mul(int3x2 a, int2x2 b)
		{
			return math.int3x2(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y);
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x00015A7C File Offset: 0x00013C7C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 mul(int3x2 a, int2x3 b)
		{
			return math.int3x3(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y);
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x00015B24 File Offset: 0x00013D24
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 mul(int3x2 a, int2x4 b)
		{
			return math.int3x4(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y, a.c0 * b.c3.x + a.c1 * b.c3.y);
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x00015BFA File Offset: 0x00013DFA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 mul(int3x3 a, int3 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x00015C3C File Offset: 0x00013E3C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 mul(int3x3 a, int3x2 b)
		{
			return math.int3x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x00015CE8 File Offset: 0x00013EE8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 mul(int3x3 a, int3x3 b)
		{
			return math.int3x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x00015DE0 File Offset: 0x00013FE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 mul(int3x3 a, int3x4 b)
		{
			return math.int3x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x00015F24 File Offset: 0x00014124
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 mul(int3x4 a, int4 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x00015F84 File Offset: 0x00014184
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 mul(int3x4 a, int4x2 b)
		{
			return math.int3x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x00016064 File Offset: 0x00014264
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 mul(int3x4 a, int4x3 b)
		{
			return math.int3x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x000161AC File Offset: 0x000143AC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x4 mul(int3x4 a, int4x4 b)
		{
			return math.int3x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x0001635A File Offset: 0x0001455A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 mul(int4x2 a, int2 b)
		{
			return a.c0 * b.x + a.c1 * b.y;
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x00016384 File Offset: 0x00014584
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 mul(int4x2 a, int2x2 b)
		{
			return math.int4x2(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y);
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x000163F8 File Offset: 0x000145F8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 mul(int4x2 a, int2x3 b)
		{
			return math.int4x3(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y);
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x000164A0 File Offset: 0x000146A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 mul(int4x2 a, int2x4 b)
		{
			return math.int4x4(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y, a.c0 * b.c3.x + a.c1 * b.c3.y);
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x00016576 File Offset: 0x00014776
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 mul(int4x3 a, int3 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x000165B8 File Offset: 0x000147B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 mul(int4x3 a, int3x2 b)
		{
			return math.int4x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x00016664 File Offset: 0x00014864
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 mul(int4x3 a, int3x3 b)
		{
			return math.int4x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x0001675C File Offset: 0x0001495C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 mul(int4x3 a, int3x4 b)
		{
			return math.int4x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x000168A0 File Offset: 0x00014AA0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 mul(int4x4 a, int4 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x00016900 File Offset: 0x00014B00
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 mul(int4x4 a, int4x2 b)
		{
			return math.int4x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x000169E0 File Offset: 0x00014BE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 mul(int4x4 a, int4x3 b)
		{
			return math.int4x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x00016B28 File Offset: 0x00014D28
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 mul(int4x4 a, int4x4 b)
		{
			return math.int4x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x00016CD6 File Offset: 0x00014ED6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint mul(uint a, uint b)
		{
			return a * b;
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x00016CDB File Offset: 0x00014EDB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint mul(uint2 a, uint2 b)
		{
			return a.x * b.x + a.y * b.y;
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x00016CF8 File Offset: 0x00014EF8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 mul(uint2 a, uint2x2 b)
		{
			return math.uint2(a.x * b.c0.x + a.y * b.c0.y, a.x * b.c1.x + a.y * b.c1.y);
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x00016D54 File Offset: 0x00014F54
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 mul(uint2 a, uint2x3 b)
		{
			return math.uint3(a.x * b.c0.x + a.y * b.c0.y, a.x * b.c1.x + a.y * b.c1.y, a.x * b.c2.x + a.y * b.c2.y);
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x00016DD8 File Offset: 0x00014FD8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 mul(uint2 a, uint2x4 b)
		{
			return math.uint4(a.x * b.c0.x + a.y * b.c0.y, a.x * b.c1.x + a.y * b.c1.y, a.x * b.c2.x + a.y * b.c2.y, a.x * b.c3.x + a.y * b.c3.y);
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00016E7E File Offset: 0x0001507E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint mul(uint3 a, uint3 b)
		{
			return a.x * b.x + a.y * b.y + a.z * b.z;
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x00016EAC File Offset: 0x000150AC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 mul(uint3 a, uint3x2 b)
		{
			return math.uint2(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z);
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x00016F30 File Offset: 0x00015130
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 mul(uint3 a, uint3x3 b)
		{
			return math.uint3(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z, a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z);
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x00016FEC File Offset: 0x000151EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 mul(uint3 a, uint3x4 b)
		{
			return math.uint4(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z, a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z, a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z);
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x000170DE File Offset: 0x000152DE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint mul(uint4 a, uint4 b)
		{
			return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x00017118 File Offset: 0x00015318
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 mul(uint4 a, uint4x2 b)
		{
			return math.uint2(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w);
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x000171C0 File Offset: 0x000153C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 mul(uint4 a, uint4x3 b)
		{
			return math.uint3(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w, a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w);
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x000172B4 File Offset: 0x000154B4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 mul(uint4 a, uint4x4 b)
		{
			return math.uint4(a.x * b.c0.x + a.y * b.c0.y + a.z * b.c0.z + a.w * b.c0.w, a.x * b.c1.x + a.y * b.c1.y + a.z * b.c1.z + a.w * b.c1.w, a.x * b.c2.x + a.y * b.c2.y + a.z * b.c2.z + a.w * b.c2.w, a.x * b.c3.x + a.y * b.c3.y + a.z * b.c3.z + a.w * b.c3.w);
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x000173F2 File Offset: 0x000155F2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 mul(uint2x2 a, uint2 b)
		{
			return a.c0 * b.x + a.c1 * b.y;
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x0001741C File Offset: 0x0001561C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 mul(uint2x2 a, uint2x2 b)
		{
			return math.uint2x2(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y);
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x00017490 File Offset: 0x00015690
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 mul(uint2x2 a, uint2x3 b)
		{
			return math.uint2x3(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y);
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x00017538 File Offset: 0x00015738
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x4 mul(uint2x2 a, uint2x4 b)
		{
			return math.uint2x4(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y, a.c0 * b.c3.x + a.c1 * b.c3.y);
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x0001760E File Offset: 0x0001580E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 mul(uint2x3 a, uint3 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x00017650 File Offset: 0x00015850
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 mul(uint2x3 a, uint3x2 b)
		{
			return math.uint2x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x000176FC File Offset: 0x000158FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 mul(uint2x3 a, uint3x3 b)
		{
			return math.uint2x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x000177F4 File Offset: 0x000159F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x4 mul(uint2x3 a, uint3x4 b)
		{
			return math.uint2x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x00017938 File Offset: 0x00015B38
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 mul(uint2x4 a, uint4 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x00017998 File Offset: 0x00015B98
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 mul(uint2x4 a, uint4x2 b)
		{
			return math.uint2x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x00017A78 File Offset: 0x00015C78
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 mul(uint2x4 a, uint4x3 b)
		{
			return math.uint2x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00017BC0 File Offset: 0x00015DC0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x4 mul(uint2x4 a, uint4x4 b)
		{
			return math.uint2x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x00017D6E File Offset: 0x00015F6E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 mul(uint3x2 a, uint2 b)
		{
			return a.c0 * b.x + a.c1 * b.y;
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x00017D98 File Offset: 0x00015F98
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 mul(uint3x2 a, uint2x2 b)
		{
			return math.uint3x2(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y);
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x00017E0C File Offset: 0x0001600C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 mul(uint3x2 a, uint2x3 b)
		{
			return math.uint3x3(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y);
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x00017EB4 File Offset: 0x000160B4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x4 mul(uint3x2 a, uint2x4 b)
		{
			return math.uint3x4(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y, a.c0 * b.c3.x + a.c1 * b.c3.y);
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x00017F8A File Offset: 0x0001618A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 mul(uint3x3 a, uint3 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x00017FCC File Offset: 0x000161CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 mul(uint3x3 a, uint3x2 b)
		{
			return math.uint3x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x00018078 File Offset: 0x00016278
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 mul(uint3x3 a, uint3x3 b)
		{
			return math.uint3x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x00018170 File Offset: 0x00016370
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x4 mul(uint3x3 a, uint3x4 b)
		{
			return math.uint3x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x000182B4 File Offset: 0x000164B4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 mul(uint3x4 a, uint4 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x00018314 File Offset: 0x00016514
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 mul(uint3x4 a, uint4x2 b)
		{
			return math.uint3x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x000183F4 File Offset: 0x000165F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 mul(uint3x4 a, uint4x3 b)
		{
			return math.uint3x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x0001853C File Offset: 0x0001673C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x4 mul(uint3x4 a, uint4x4 b)
		{
			return math.uint3x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x000186EA File Offset: 0x000168EA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 mul(uint4x2 a, uint2 b)
		{
			return a.c0 * b.x + a.c1 * b.y;
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x00018714 File Offset: 0x00016914
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 mul(uint4x2 a, uint2x2 b)
		{
			return math.uint4x2(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y);
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x00018788 File Offset: 0x00016988
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 mul(uint4x2 a, uint2x3 b)
		{
			return math.uint4x3(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y);
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x00018830 File Offset: 0x00016A30
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 mul(uint4x2 a, uint2x4 b)
		{
			return math.uint4x4(a.c0 * b.c0.x + a.c1 * b.c0.y, a.c0 * b.c1.x + a.c1 * b.c1.y, a.c0 * b.c2.x + a.c1 * b.c2.y, a.c0 * b.c3.x + a.c1 * b.c3.y);
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x00018906 File Offset: 0x00016B06
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 mul(uint4x3 a, uint3 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z;
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x00018948 File Offset: 0x00016B48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 mul(uint4x3 a, uint3x2 b)
		{
			return math.uint4x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z);
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x000189F4 File Offset: 0x00016BF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 mul(uint4x3 a, uint3x3 b)
		{
			return math.uint4x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z);
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x00018AEC File Offset: 0x00016CEC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 mul(uint4x3 a, uint3x4 b)
		{
			return math.uint4x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z);
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x00018C30 File Offset: 0x00016E30
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 mul(uint4x4 a, uint4 b)
		{
			return a.c0 * b.x + a.c1 * b.y + a.c2 * b.z + a.c3 * b.w;
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x00018C90 File Offset: 0x00016E90
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 mul(uint4x4 a, uint4x2 b)
		{
			return math.uint4x2(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w);
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x00018D70 File Offset: 0x00016F70
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 mul(uint4x4 a, uint4x3 b)
		{
			return math.uint4x3(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w);
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x00018EB8 File Offset: 0x000170B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 mul(uint4x4 a, uint4x4 b)
		{
			return math.uint4x4(a.c0 * b.c0.x + a.c1 * b.c0.y + a.c2 * b.c0.z + a.c3 * b.c0.w, a.c0 * b.c1.x + a.c1 * b.c1.y + a.c2 * b.c1.z + a.c3 * b.c1.w, a.c0 * b.c2.x + a.c1 * b.c2.y + a.c2 * b.c2.z + a.c3 * b.c2.w, a.c0 * b.c3.x + a.c1 * b.c3.y + a.c2 * b.c3.z + a.c3 * b.c3.w);
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x00019066 File Offset: 0x00017266
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion quaternion(float x, float y, float z, float w)
		{
			return new quaternion(x, y, z, w);
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x00019071 File Offset: 0x00017271
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion quaternion(float4 value)
		{
			return new quaternion(value);
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x00019079 File Offset: 0x00017279
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion quaternion(float3x3 m)
		{
			return new quaternion(m);
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x00019081 File Offset: 0x00017281
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion quaternion(float4x4 m)
		{
			return new quaternion(m);
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x00019089 File Offset: 0x00017289
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion conjugate(quaternion q)
		{
			return math.quaternion(q.value * math.float4(-1f, -1f, -1f, 1f));
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x000190B4 File Offset: 0x000172B4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion inverse(quaternion q)
		{
			float4 value = q.value;
			return math.quaternion(math.rcp(math.dot(value, value)) * value * math.float4(-1f, -1f, -1f, 1f));
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x000190FD File Offset: 0x000172FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float dot(quaternion a, quaternion b)
		{
			return math.dot(a.value, b.value);
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x00019110 File Offset: 0x00017310
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float length(quaternion q)
		{
			return math.sqrt(math.dot(q.value, q.value));
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x00019128 File Offset: 0x00017328
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float lengthsq(quaternion q)
		{
			return math.dot(q.value, q.value);
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x0001913C File Offset: 0x0001733C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion normalize(quaternion q)
		{
			float4 value = q.value;
			return math.quaternion(math.rsqrt(math.dot(value, value)) * value);
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x00019168 File Offset: 0x00017368
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion normalizesafe(quaternion q)
		{
			float4 value = q.value;
			float num = math.dot(value, value);
			return math.quaternion(math.select(Unity.Mathematics.quaternion.identity.value, value * math.rsqrt(num), num > 1.1754944E-38f));
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x000191AC File Offset: 0x000173AC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion normalizesafe(quaternion q, quaternion defaultvalue)
		{
			float4 value = q.value;
			float num = math.dot(value, value);
			return math.quaternion(math.select(defaultvalue.value, value * math.rsqrt(num), num > 1.1754944E-38f));
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x000191EC File Offset: 0x000173EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion unitexp(quaternion q)
		{
			float num = math.rsqrt(math.dot(q.value.xyz, q.value.xyz));
			float rhs;
			float w;
			math.sincos(math.rcp(num), out rhs, out w);
			return math.quaternion(math.float4(q.value.xyz * num * rhs, w));
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x00019250 File Offset: 0x00017450
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion exp(quaternion q)
		{
			float num = math.rsqrt(math.dot(q.value.xyz, q.value.xyz));
			float rhs;
			float w;
			math.sincos(math.rcp(num), out rhs, out w);
			return math.quaternion(math.float4(q.value.xyz * num * rhs, w) * math.exp(q.value.w));
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x000192C8 File Offset: 0x000174C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion unitlog(quaternion q)
		{
			float num = math.clamp(q.value.w, -1f, 1f);
			float rhs = math.acos(num) * math.rsqrt(1f - num * num);
			return math.quaternion(math.float4(q.value.xyz * rhs, 0f));
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x00019328 File Offset: 0x00017528
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion log(quaternion q)
		{
			float num = math.dot(q.value.xyz, q.value.xyz);
			float x = num + q.value.w * q.value.w;
			float rhs = math.acos(math.clamp(q.value.w * math.rsqrt(x), -1f, 1f)) * math.rsqrt(num);
			return math.quaternion(math.float4(q.value.xyz * rhs, 0.5f * math.log(x)));
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x000193C4 File Offset: 0x000175C4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion mul(quaternion a, quaternion b)
		{
			return math.quaternion(a.value.wwww * b.value + (a.value.xyzx * b.value.wwwx + a.value.yzxy * b.value.zxyy) * math.float4(1f, 1f, 1f, -1f) - a.value.zxyz * b.value.yzxz);
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00019474 File Offset: 0x00017674
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 mul(quaternion q, float3 v)
		{
			float3 @float = 2f * math.cross(q.value.xyz, v);
			return v + q.value.w * @float + math.cross(q.value.xyz, @float);
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x000194CC File Offset: 0x000176CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 rotate(quaternion q, float3 v)
		{
			float3 @float = 2f * math.cross(q.value.xyz, v);
			return v + q.value.w * @float + math.cross(q.value.xyz, @float);
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x00019524 File Offset: 0x00017724
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion nlerp(quaternion q1, quaternion q2, float t)
		{
			if (math.dot(q1, q2) < 0f)
			{
				q2.value = -q2.value;
			}
			return math.normalize(math.quaternion(math.lerp(q1.value, q2.value, t)));
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x00019564 File Offset: 0x00017764
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion slerp(quaternion q1, quaternion q2, float t)
		{
			float num = math.dot(q1, q2);
			if (num < 0f)
			{
				num = -num;
				q2.value = -q2.value;
			}
			if (num < 0.9995f)
			{
				float num2 = math.acos(num);
				float num3 = math.rsqrt(1f - num * num);
				float rhs = math.sin(num2 * (1f - t)) * num3;
				float rhs2 = math.sin(num2 * t) * num3;
				return math.quaternion(q1.value * rhs + q2.value * rhs2);
			}
			return math.nlerp(q1, q2, t);
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x000195F9 File Offset: 0x000177F9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(quaternion q)
		{
			return math.hash(q.value);
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00019606 File Offset: 0x00017806
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(quaternion q)
		{
			return math.hashwide(q.value);
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x00019613 File Offset: 0x00017813
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 forward(quaternion q)
		{
			return math.mul(q, math.float3(0f, 0f, 1f));
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0001962F File Offset: 0x0001782F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform RigidTransform(quaternion rot, float3 pos)
		{
			return new RigidTransform(rot, pos);
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x00019638 File Offset: 0x00017838
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform RigidTransform(float3x3 rotation, float3 translation)
		{
			return new RigidTransform(rotation, translation);
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x00019641 File Offset: 0x00017841
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform RigidTransform(float4x4 transform)
		{
			return new RigidTransform(transform);
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0001964C File Offset: 0x0001784C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform inverse(RigidTransform t)
		{
			quaternion quaternion = math.inverse(t.rot);
			float3 translation = math.mul(quaternion, -t.pos);
			return new RigidTransform(quaternion, translation);
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x0001967C File Offset: 0x0001787C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform mul(RigidTransform a, RigidTransform b)
		{
			return new RigidTransform(math.mul(a.rot, b.rot), math.mul(a.rot, b.pos) + a.pos);
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x000196B0 File Offset: 0x000178B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 mul(RigidTransform a, float4 pos)
		{
			return math.float4(math.mul(a.rot, pos.xyz) + a.pos * pos.w, pos.w);
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x000196E5 File Offset: 0x000178E5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 rotate(RigidTransform a, float3 dir)
		{
			return math.mul(a.rot, dir);
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x000196F3 File Offset: 0x000178F3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 transform(RigidTransform a, float3 pos)
		{
			return math.mul(a.rot, pos) + a.pos;
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x0001970C File Offset: 0x0001790C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(RigidTransform t)
		{
			return math.hash(t.rot) + 3318036811U * math.hash(t.pos);
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x0001972C File Offset: 0x0001792C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(RigidTransform t)
		{
			return math.hashwide(t.rot) + 3318036811U * math.hashwide(t.pos).xyzz;
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00019766 File Offset: 0x00017966
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 uint2(uint x, uint y)
		{
			return new uint2(x, y);
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x0001976F File Offset: 0x0001796F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 uint2(uint2 xy)
		{
			return new uint2(xy);
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00019777 File Offset: 0x00017977
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 uint2(uint v)
		{
			return new uint2(v);
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x0001977F File Offset: 0x0001797F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 uint2(bool v)
		{
			return new uint2(v);
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00019787 File Offset: 0x00017987
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 uint2(bool2 v)
		{
			return new uint2(v);
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x0001978F File Offset: 0x0001798F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 uint2(int v)
		{
			return new uint2(v);
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00019797 File Offset: 0x00017997
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 uint2(int2 v)
		{
			return new uint2(v);
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x0001979F File Offset: 0x0001799F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 uint2(float v)
		{
			return new uint2(v);
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x000197A7 File Offset: 0x000179A7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 uint2(float2 v)
		{
			return new uint2(v);
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x000197AF File Offset: 0x000179AF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 uint2(double v)
		{
			return new uint2(v);
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x000197B7 File Offset: 0x000179B7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 uint2(double2 v)
		{
			return new uint2(v);
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x000197BF File Offset: 0x000179BF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(uint2 v)
		{
			return math.csum(v * math.uint2(1148435377U, 3416333663U)) + 1750611407U;
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x000197E1 File Offset: 0x000179E1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(uint2 v)
		{
			return v * math.uint2(3285396193U, 3110507567U) + 4271396531U;
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x00019802 File Offset: 0x00017A02
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint shuffle(uint2 left, uint2 right, math.ShuffleComponent x)
		{
			return math.select_shuffle_component(left, right, x);
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x0001980C File Offset: 0x00017A0C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 shuffle(uint2 left, uint2 right, math.ShuffleComponent x, math.ShuffleComponent y)
		{
			return math.uint2(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y));
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x00019823 File Offset: 0x00017A23
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 shuffle(uint2 left, uint2 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
		{
			return math.uint3(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z));
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x00019843 File Offset: 0x00017A43
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 shuffle(uint2 left, uint2 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
		{
			return math.uint4(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z), math.select_shuffle_component(left, right, w));
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x0001986C File Offset: 0x00017A6C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static uint select_shuffle_component(uint2 a, uint2 b, math.ShuffleComponent component)
		{
			switch (component)
			{
			case math.ShuffleComponent.LeftX:
				return a.x;
			case math.ShuffleComponent.LeftY:
				return a.y;
			case math.ShuffleComponent.RightX:
				return b.x;
			case math.ShuffleComponent.RightY:
				return b.y;
			}
			throw new ArgumentException("Invalid shuffle component: " + component.ToString());
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x000198D1 File Offset: 0x00017AD1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 uint2x2(uint2 c0, uint2 c1)
		{
			return new uint2x2(c0, c1);
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x000198DA File Offset: 0x00017ADA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 uint2x2(uint m00, uint m01, uint m10, uint m11)
		{
			return new uint2x2(m00, m01, m10, m11);
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x000198E5 File Offset: 0x00017AE5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 uint2x2(uint v)
		{
			return new uint2x2(v);
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x000198ED File Offset: 0x00017AED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 uint2x2(bool v)
		{
			return new uint2x2(v);
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x000198F5 File Offset: 0x00017AF5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 uint2x2(bool2x2 v)
		{
			return new uint2x2(v);
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x000198FD File Offset: 0x00017AFD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 uint2x2(int v)
		{
			return new uint2x2(v);
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x00019905 File Offset: 0x00017B05
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 uint2x2(int2x2 v)
		{
			return new uint2x2(v);
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x0001990D File Offset: 0x00017B0D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 uint2x2(float v)
		{
			return new uint2x2(v);
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x00019915 File Offset: 0x00017B15
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 uint2x2(float2x2 v)
		{
			return new uint2x2(v);
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x0001991D File Offset: 0x00017B1D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 uint2x2(double v)
		{
			return new uint2x2(v);
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x00019925 File Offset: 0x00017B25
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 uint2x2(double2x2 v)
		{
			return new uint2x2(v);
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x0001992D File Offset: 0x00017B2D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 transpose(uint2x2 v)
		{
			return math.uint2x2(v.c0.x, v.c0.y, v.c1.x, v.c1.y);
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x00019960 File Offset: 0x00017B60
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(uint2x2 v)
		{
			return math.csum(v.c0 * math.uint2(3010324327U, 1875523709U) + v.c1 * math.uint2(2937008387U, 3835713223U)) + 2216526373U;
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x000199B4 File Offset: 0x00017BB4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(uint2x2 v)
		{
			return v.c0 * math.uint2(3375971453U, 3559829411U) + v.c1 * math.uint2(3652178029U, 2544260129U) + 2013864031U;
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x00019A04 File Offset: 0x00017C04
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 uint2x3(uint2 c0, uint2 c1, uint2 c2)
		{
			return new uint2x3(c0, c1, c2);
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00019A0E File Offset: 0x00017C0E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 uint2x3(uint m00, uint m01, uint m02, uint m10, uint m11, uint m12)
		{
			return new uint2x3(m00, m01, m02, m10, m11, m12);
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x00019A1D File Offset: 0x00017C1D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 uint2x3(uint v)
		{
			return new uint2x3(v);
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x00019A25 File Offset: 0x00017C25
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 uint2x3(bool v)
		{
			return new uint2x3(v);
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x00019A2D File Offset: 0x00017C2D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 uint2x3(bool2x3 v)
		{
			return new uint2x3(v);
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x00019A35 File Offset: 0x00017C35
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 uint2x3(int v)
		{
			return new uint2x3(v);
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x00019A3D File Offset: 0x00017C3D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 uint2x3(int2x3 v)
		{
			return new uint2x3(v);
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x00019A45 File Offset: 0x00017C45
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 uint2x3(float v)
		{
			return new uint2x3(v);
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x00019A4D File Offset: 0x00017C4D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 uint2x3(float2x3 v)
		{
			return new uint2x3(v);
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x00019A55 File Offset: 0x00017C55
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 uint2x3(double v)
		{
			return new uint2x3(v);
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x00019A5D File Offset: 0x00017C5D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 uint2x3(double2x3 v)
		{
			return new uint2x3(v);
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x00019A68 File Offset: 0x00017C68
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 transpose(uint2x3 v)
		{
			return math.uint3x2(v.c0.x, v.c0.y, v.c1.x, v.c1.y, v.c2.x, v.c2.y);
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x00019ABC File Offset: 0x00017CBC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(uint2x3 v)
		{
			return math.csum(v.c0 * math.uint2(4016293529U, 2416021567U) + v.c1 * math.uint2(2828384717U, 2636362241U) + v.c2 * math.uint2(1258410977U, 1952565773U)) + 2037535609U;
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x00019B2C File Offset: 0x00017D2C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(uint2x3 v)
		{
			return v.c0 * math.uint2(3592785499U, 3996716183U) + v.c1 * math.uint2(2626301701U, 1306289417U) + v.c2 * math.uint2(2096137163U, 1548578029U) + 4178800919U;
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x00019B9B File Offset: 0x00017D9B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x4 uint2x4(uint2 c0, uint2 c1, uint2 c2, uint2 c3)
		{
			return new uint2x4(c0, c1, c2, c3);
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x00019BA6 File Offset: 0x00017DA6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x4 uint2x4(uint m00, uint m01, uint m02, uint m03, uint m10, uint m11, uint m12, uint m13)
		{
			return new uint2x4(m00, m01, m02, m03, m10, m11, m12, m13);
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x00019BB9 File Offset: 0x00017DB9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x4 uint2x4(uint v)
		{
			return new uint2x4(v);
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x00019BC1 File Offset: 0x00017DC1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x4 uint2x4(bool v)
		{
			return new uint2x4(v);
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x00019BC9 File Offset: 0x00017DC9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x4 uint2x4(bool2x4 v)
		{
			return new uint2x4(v);
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x00019BD1 File Offset: 0x00017DD1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x4 uint2x4(int v)
		{
			return new uint2x4(v);
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x00019BD9 File Offset: 0x00017DD9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x4 uint2x4(int2x4 v)
		{
			return new uint2x4(v);
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x00019BE1 File Offset: 0x00017DE1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x4 uint2x4(float v)
		{
			return new uint2x4(v);
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x00019BE9 File Offset: 0x00017DE9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x4 uint2x4(float2x4 v)
		{
			return new uint2x4(v);
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x00019BF1 File Offset: 0x00017DF1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x4 uint2x4(double v)
		{
			return new uint2x4(v);
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x00019BF9 File Offset: 0x00017DF9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x4 uint2x4(double2x4 v)
		{
			return new uint2x4(v);
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x00019C04 File Offset: 0x00017E04
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 transpose(uint2x4 v)
		{
			return math.uint4x2(v.c0.x, v.c0.y, v.c1.x, v.c1.y, v.c2.x, v.c2.y, v.c3.x, v.c3.y);
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x00019C70 File Offset: 0x00017E70
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(uint2x4 v)
		{
			return math.csum(v.c0 * math.uint2(2650080659U, 4052675461U) + v.c1 * math.uint2(2652487619U, 2174136431U) + v.c2 * math.uint2(3528391193U, 2105559227U) + v.c3 * math.uint2(1899745391U, 1966790317U)) + 3516359879U;
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x00019D00 File Offset: 0x00017F00
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 hashwide(uint2x4 v)
		{
			return v.c0 * math.uint2(3050356579U, 4178586719U) + v.c1 * math.uint2(2558655391U, 1453413133U) + v.c2 * math.uint2(2152428077U, 1938706661U) + v.c3 * math.uint2(1338588197U, 3439609253U) + 3535343003U;
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x00019D8E File Offset: 0x00017F8E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 uint3(uint x, uint y, uint z)
		{
			return new uint3(x, y, z);
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x00019D98 File Offset: 0x00017F98
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 uint3(uint x, uint2 yz)
		{
			return new uint3(x, yz);
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x00019DA1 File Offset: 0x00017FA1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 uint3(uint2 xy, uint z)
		{
			return new uint3(xy, z);
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x00019DAA File Offset: 0x00017FAA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 uint3(uint3 xyz)
		{
			return new uint3(xyz);
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x00019DB2 File Offset: 0x00017FB2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 uint3(uint v)
		{
			return new uint3(v);
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x00019DBA File Offset: 0x00017FBA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 uint3(bool v)
		{
			return new uint3(v);
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x00019DC2 File Offset: 0x00017FC2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 uint3(bool3 v)
		{
			return new uint3(v);
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x00019DCA File Offset: 0x00017FCA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 uint3(int v)
		{
			return new uint3(v);
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x00019DD2 File Offset: 0x00017FD2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 uint3(int3 v)
		{
			return new uint3(v);
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x00019DDA File Offset: 0x00017FDA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 uint3(float v)
		{
			return new uint3(v);
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x00019DE2 File Offset: 0x00017FE2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 uint3(float3 v)
		{
			return new uint3(v);
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x00019DEA File Offset: 0x00017FEA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 uint3(double v)
		{
			return new uint3(v);
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x00019DF2 File Offset: 0x00017FF2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 uint3(double3 v)
		{
			return new uint3(v);
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x00019DFA File Offset: 0x00017FFA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(uint3 v)
		{
			return math.csum(v * math.uint3(3441847433U, 4052036147U, 2011389559U)) + 2252224297U;
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x00019E21 File Offset: 0x00018021
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(uint3 v)
		{
			return v * math.uint3(3784421429U, 1750626223U, 3571447507U) + 3412283213U;
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x00019E47 File Offset: 0x00018047
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint shuffle(uint3 left, uint3 right, math.ShuffleComponent x)
		{
			return math.select_shuffle_component(left, right, x);
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00019E51 File Offset: 0x00018051
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 shuffle(uint3 left, uint3 right, math.ShuffleComponent x, math.ShuffleComponent y)
		{
			return math.uint2(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y));
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00019E68 File Offset: 0x00018068
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 shuffle(uint3 left, uint3 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
		{
			return math.uint3(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z));
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x00019E88 File Offset: 0x00018088
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 shuffle(uint3 left, uint3 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
		{
			return math.uint4(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z), math.select_shuffle_component(left, right, w));
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x00019EB4 File Offset: 0x000180B4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static uint select_shuffle_component(uint3 a, uint3 b, math.ShuffleComponent component)
		{
			switch (component)
			{
			case math.ShuffleComponent.LeftX:
				return a.x;
			case math.ShuffleComponent.LeftY:
				return a.y;
			case math.ShuffleComponent.LeftZ:
				return a.z;
			case math.ShuffleComponent.RightX:
				return b.x;
			case math.ShuffleComponent.RightY:
				return b.y;
			case math.ShuffleComponent.RightZ:
				return b.z;
			}
			throw new ArgumentException("Invalid shuffle component: " + component.ToString());
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x00019F2B File Offset: 0x0001812B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 uint3x2(uint3 c0, uint3 c1)
		{
			return new uint3x2(c0, c1);
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x00019F34 File Offset: 0x00018134
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 uint3x2(uint m00, uint m01, uint m10, uint m11, uint m20, uint m21)
		{
			return new uint3x2(m00, m01, m10, m11, m20, m21);
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x00019F43 File Offset: 0x00018143
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 uint3x2(uint v)
		{
			return new uint3x2(v);
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x00019F4B File Offset: 0x0001814B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 uint3x2(bool v)
		{
			return new uint3x2(v);
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x00019F53 File Offset: 0x00018153
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 uint3x2(bool3x2 v)
		{
			return new uint3x2(v);
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x00019F5B File Offset: 0x0001815B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 uint3x2(int v)
		{
			return new uint3x2(v);
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x00019F63 File Offset: 0x00018163
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 uint3x2(int3x2 v)
		{
			return new uint3x2(v);
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x00019F6B File Offset: 0x0001816B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 uint3x2(float v)
		{
			return new uint3x2(v);
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x00019F73 File Offset: 0x00018173
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 uint3x2(float3x2 v)
		{
			return new uint3x2(v);
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x00019F7B File Offset: 0x0001817B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 uint3x2(double v)
		{
			return new uint3x2(v);
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x00019F83 File Offset: 0x00018183
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 uint3x2(double3x2 v)
		{
			return new uint3x2(v);
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x00019F8C File Offset: 0x0001818C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 transpose(uint3x2 v)
		{
			return math.uint2x3(v.c0.x, v.c0.y, v.c0.z, v.c1.x, v.c1.y, v.c1.z);
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x00019FE0 File Offset: 0x000181E0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(uint3x2 v)
		{
			return math.csum(v.c0 * math.uint3(1365086453U, 3969870067U, 4192899797U) + v.c1 * math.uint3(3271228601U, 1634639009U, 3318036811U)) + 3404170631U;
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x0001A03C File Offset: 0x0001823C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(uint3x2 v)
		{
			return v.c0 * math.uint3(2048213449U, 4164671783U, 1780759499U) + v.c1 * math.uint3(1352369353U, 2446407751U, 1391928079U) + 3475533443U;
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x0001A096 File Offset: 0x00018296
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 uint3x3(uint3 c0, uint3 c1, uint3 c2)
		{
			return new uint3x3(c0, c1, c2);
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x0001A0A0 File Offset: 0x000182A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 uint3x3(uint m00, uint m01, uint m02, uint m10, uint m11, uint m12, uint m20, uint m21, uint m22)
		{
			return new uint3x3(m00, m01, m02, m10, m11, m12, m20, m21, m22);
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x0001A0C0 File Offset: 0x000182C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 uint3x3(uint v)
		{
			return new uint3x3(v);
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x0001A0C8 File Offset: 0x000182C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 uint3x3(bool v)
		{
			return new uint3x3(v);
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x0001A0D0 File Offset: 0x000182D0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 uint3x3(bool3x3 v)
		{
			return new uint3x3(v);
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x0001A0D8 File Offset: 0x000182D8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 uint3x3(int v)
		{
			return new uint3x3(v);
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x0001A0E0 File Offset: 0x000182E0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 uint3x3(int3x3 v)
		{
			return new uint3x3(v);
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x0001A0E8 File Offset: 0x000182E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 uint3x3(float v)
		{
			return new uint3x3(v);
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x0001A0F0 File Offset: 0x000182F0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 uint3x3(float3x3 v)
		{
			return new uint3x3(v);
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x0001A0F8 File Offset: 0x000182F8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 uint3x3(double v)
		{
			return new uint3x3(v);
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x0001A100 File Offset: 0x00018300
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 uint3x3(double3x3 v)
		{
			return new uint3x3(v);
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x0001A108 File Offset: 0x00018308
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 transpose(uint3x3 v)
		{
			return math.uint3x3(v.c0.x, v.c0.y, v.c0.z, v.c1.x, v.c1.y, v.c1.z, v.c2.x, v.c2.y, v.c2.z);
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x0001A180 File Offset: 0x00018380
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(uint3x3 v)
		{
			return math.csum(v.c0 * math.uint3(2892026051U, 2455987759U, 3868600063U) + v.c1 * math.uint3(3170963179U, 2632835537U, 1136528209U) + v.c2 * math.uint3(2944626401U, 2972762423U, 1417889653U)) + 2080514593U;
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0001A200 File Offset: 0x00018400
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(uint3x3 v)
		{
			return v.c0 * math.uint3(2731544287U, 2828498809U, 2669441947U) + v.c1 * math.uint3(1260114311U, 2650080659U, 4052675461U) + v.c2 * math.uint3(2652487619U, 2174136431U, 3528391193U) + 2105559227U;
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x0001A27E File Offset: 0x0001847E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x4 uint3x4(uint3 c0, uint3 c1, uint3 c2, uint3 c3)
		{
			return new uint3x4(c0, c1, c2, c3);
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x0001A28C File Offset: 0x0001848C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x4 uint3x4(uint m00, uint m01, uint m02, uint m03, uint m10, uint m11, uint m12, uint m13, uint m20, uint m21, uint m22, uint m23)
		{
			return new uint3x4(m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23);
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x0001A2B2 File Offset: 0x000184B2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x4 uint3x4(uint v)
		{
			return new uint3x4(v);
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x0001A2BA File Offset: 0x000184BA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x4 uint3x4(bool v)
		{
			return new uint3x4(v);
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x0001A2C2 File Offset: 0x000184C2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x4 uint3x4(bool3x4 v)
		{
			return new uint3x4(v);
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x0001A2CA File Offset: 0x000184CA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x4 uint3x4(int v)
		{
			return new uint3x4(v);
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x0001A2D2 File Offset: 0x000184D2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x4 uint3x4(int3x4 v)
		{
			return new uint3x4(v);
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x0001A2DA File Offset: 0x000184DA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x4 uint3x4(float v)
		{
			return new uint3x4(v);
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x0001A2E2 File Offset: 0x000184E2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x4 uint3x4(float3x4 v)
		{
			return new uint3x4(v);
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x0001A2EA File Offset: 0x000184EA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x4 uint3x4(double v)
		{
			return new uint3x4(v);
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x0001A2F2 File Offset: 0x000184F2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x4 uint3x4(double3x4 v)
		{
			return new uint3x4(v);
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x0001A2FC File Offset: 0x000184FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 transpose(uint3x4 v)
		{
			return math.uint4x3(v.c0.x, v.c0.y, v.c0.z, v.c1.x, v.c1.y, v.c1.z, v.c2.x, v.c2.y, v.c2.z, v.c3.x, v.c3.y, v.c3.z);
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x0001A394 File Offset: 0x00018594
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(uint3x4 v)
		{
			return math.csum(v.c0 * math.uint3(3508684087U, 3919501043U, 1209161033U) + v.c1 * math.uint3(4007793211U, 3819806693U, 3458005183U) + v.c2 * math.uint3(2078515003U, 4206465343U, 3025146473U) + v.c3 * math.uint3(3763046909U, 3678265601U, 2070747979U)) + 1480171127U;
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x0001A438 File Offset: 0x00018638
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 hashwide(uint3x4 v)
		{
			return v.c0 * math.uint3(1588341193U, 4234155257U, 1811310911U) + v.c1 * math.uint3(2635799963U, 4165137857U, 2759770933U) + v.c2 * math.uint3(2759319383U, 3299952959U, 3121178323U) + v.c3 * math.uint3(2948522579U, 1531026433U, 1365086453U) + 3969870067U;
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x0001A4DA File Offset: 0x000186DA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 uint4(uint x, uint y, uint z, uint w)
		{
			return new uint4(x, y, z, w);
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x0001A4E5 File Offset: 0x000186E5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 uint4(uint x, uint y, uint2 zw)
		{
			return new uint4(x, y, zw);
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x0001A4EF File Offset: 0x000186EF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 uint4(uint x, uint2 yz, uint w)
		{
			return new uint4(x, yz, w);
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x0001A4F9 File Offset: 0x000186F9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 uint4(uint x, uint3 yzw)
		{
			return new uint4(x, yzw);
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x0001A502 File Offset: 0x00018702
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 uint4(uint2 xy, uint z, uint w)
		{
			return new uint4(xy, z, w);
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x0001A50C File Offset: 0x0001870C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 uint4(uint2 xy, uint2 zw)
		{
			return new uint4(xy, zw);
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x0001A515 File Offset: 0x00018715
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 uint4(uint3 xyz, uint w)
		{
			return new uint4(xyz, w);
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x0001A51E File Offset: 0x0001871E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 uint4(uint4 xyzw)
		{
			return new uint4(xyzw);
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x0001A526 File Offset: 0x00018726
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 uint4(uint v)
		{
			return new uint4(v);
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x0001A52E File Offset: 0x0001872E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 uint4(bool v)
		{
			return new uint4(v);
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x0001A536 File Offset: 0x00018736
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 uint4(bool4 v)
		{
			return new uint4(v);
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x0001A53E File Offset: 0x0001873E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 uint4(int v)
		{
			return new uint4(v);
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x0001A546 File Offset: 0x00018746
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 uint4(int4 v)
		{
			return new uint4(v);
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x0001A54E File Offset: 0x0001874E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 uint4(float v)
		{
			return new uint4(v);
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x0001A556 File Offset: 0x00018756
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 uint4(float4 v)
		{
			return new uint4(v);
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x0001A55E File Offset: 0x0001875E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 uint4(double v)
		{
			return new uint4(v);
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x0001A566 File Offset: 0x00018766
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 uint4(double4 v)
		{
			return new uint4(v);
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x0001A56E File Offset: 0x0001876E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(uint4 v)
		{
			return math.csum(v * math.uint4(3029516053U, 3547472099U, 2057487037U, 3781937309U)) + 2057338067U;
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x0001A59A File Offset: 0x0001879A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(uint4 v)
		{
			return v * math.uint4(2942577577U, 2834440507U, 2671762487U, 2892026051U) + 2455987759U;
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x0001A5C5 File Offset: 0x000187C5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint shuffle(uint4 left, uint4 right, math.ShuffleComponent x)
		{
			return math.select_shuffle_component(left, right, x);
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x0001A5CF File Offset: 0x000187CF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 shuffle(uint4 left, uint4 right, math.ShuffleComponent x, math.ShuffleComponent y)
		{
			return math.uint2(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y));
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x0001A5E6 File Offset: 0x000187E6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 shuffle(uint4 left, uint4 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
		{
			return math.uint3(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z));
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x0001A606 File Offset: 0x00018806
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 shuffle(uint4 left, uint4 right, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
		{
			return math.uint4(math.select_shuffle_component(left, right, x), math.select_shuffle_component(left, right, y), math.select_shuffle_component(left, right, z), math.select_shuffle_component(left, right, w));
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x0001A630 File Offset: 0x00018830
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static uint select_shuffle_component(uint4 a, uint4 b, math.ShuffleComponent component)
		{
			switch (component)
			{
			case math.ShuffleComponent.LeftX:
				return a.x;
			case math.ShuffleComponent.LeftY:
				return a.y;
			case math.ShuffleComponent.LeftZ:
				return a.z;
			case math.ShuffleComponent.LeftW:
				return a.w;
			case math.ShuffleComponent.RightX:
				return b.x;
			case math.ShuffleComponent.RightY:
				return b.y;
			case math.ShuffleComponent.RightZ:
				return b.z;
			case math.ShuffleComponent.RightW:
				return b.w;
			default:
				throw new ArgumentException("Invalid shuffle component: " + component.ToString());
			}
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x0001A6B9 File Offset: 0x000188B9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 uint4x2(uint4 c0, uint4 c1)
		{
			return new uint4x2(c0, c1);
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x0001A6C2 File Offset: 0x000188C2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 uint4x2(uint m00, uint m01, uint m10, uint m11, uint m20, uint m21, uint m30, uint m31)
		{
			return new uint4x2(m00, m01, m10, m11, m20, m21, m30, m31);
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x0001A6D5 File Offset: 0x000188D5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 uint4x2(uint v)
		{
			return new uint4x2(v);
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x0001A6DD File Offset: 0x000188DD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 uint4x2(bool v)
		{
			return new uint4x2(v);
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x0001A6E5 File Offset: 0x000188E5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 uint4x2(bool4x2 v)
		{
			return new uint4x2(v);
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x0001A6ED File Offset: 0x000188ED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 uint4x2(int v)
		{
			return new uint4x2(v);
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x0001A6F5 File Offset: 0x000188F5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 uint4x2(int4x2 v)
		{
			return new uint4x2(v);
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x0001A6FD File Offset: 0x000188FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 uint4x2(float v)
		{
			return new uint4x2(v);
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x0001A705 File Offset: 0x00018905
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 uint4x2(float4x2 v)
		{
			return new uint4x2(v);
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x0001A70D File Offset: 0x0001890D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 uint4x2(double v)
		{
			return new uint4x2(v);
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x0001A715 File Offset: 0x00018915
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 uint4x2(double4x2 v)
		{
			return new uint4x2(v);
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x0001A720 File Offset: 0x00018920
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x4 transpose(uint4x2 v)
		{
			return math.uint2x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w, v.c1.x, v.c1.y, v.c1.z, v.c1.w);
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x0001A78C File Offset: 0x0001898C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(uint4x2 v)
		{
			return math.csum(v.c0 * math.uint4(4198118021U, 2908068253U, 3705492289U, 2497566569U) + v.c1 * math.uint4(2716413241U, 1166264321U, 2503385333U, 2944493077U)) + 2599999021U;
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x0001A7F4 File Offset: 0x000189F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(uint4x2 v)
		{
			return v.c0 * math.uint4(3814721321U, 1595355149U, 1728931849U, 2062756937U) + v.c1 * math.uint4(2920485769U, 1562056283U, 2265541847U, 1283419601U) + 1210229737U;
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x0001A858 File Offset: 0x00018A58
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 uint4x3(uint4 c0, uint4 c1, uint4 c2)
		{
			return new uint4x3(c0, c1, c2);
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x0001A864 File Offset: 0x00018A64
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 uint4x3(uint m00, uint m01, uint m02, uint m10, uint m11, uint m12, uint m20, uint m21, uint m22, uint m30, uint m31, uint m32)
		{
			return new uint4x3(m00, m01, m02, m10, m11, m12, m20, m21, m22, m30, m31, m32);
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x0001A88A File Offset: 0x00018A8A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 uint4x3(uint v)
		{
			return new uint4x3(v);
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x0001A892 File Offset: 0x00018A92
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 uint4x3(bool v)
		{
			return new uint4x3(v);
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x0001A89A File Offset: 0x00018A9A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 uint4x3(bool4x3 v)
		{
			return new uint4x3(v);
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x0001A8A2 File Offset: 0x00018AA2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 uint4x3(int v)
		{
			return new uint4x3(v);
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0001A8AA File Offset: 0x00018AAA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 uint4x3(int4x3 v)
		{
			return new uint4x3(v);
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x0001A8B2 File Offset: 0x00018AB2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 uint4x3(float v)
		{
			return new uint4x3(v);
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x0001A8BA File Offset: 0x00018ABA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 uint4x3(float4x3 v)
		{
			return new uint4x3(v);
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x0001A8C2 File Offset: 0x00018AC2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 uint4x3(double v)
		{
			return new uint4x3(v);
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x0001A8CA File Offset: 0x00018ACA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x3 uint4x3(double4x3 v)
		{
			return new uint4x3(v);
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x0001A8D4 File Offset: 0x00018AD4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x4 transpose(uint4x3 v)
		{
			return math.uint3x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w, v.c1.x, v.c1.y, v.c1.z, v.c1.w, v.c2.x, v.c2.y, v.c2.z, v.c2.w);
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x0001A96C File Offset: 0x00018B6C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(uint4x3 v)
		{
			return math.csum(v.c0 * math.uint4(3881277847U, 4017968839U, 1727237899U, 1648514723U) + v.c1 * math.uint4(1385344481U, 3538260197U, 4066109527U, 2613148903U) + v.c2 * math.uint4(3367528529U, 1678332449U, 2918459647U, 2744611081U)) + 1952372791U;
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x0001A9FC File Offset: 0x00018BFC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(uint4x3 v)
		{
			return v.c0 * math.uint4(2631698677U, 4200781601U, 2119021007U, 1760485621U) + v.c1 * math.uint4(3157985881U, 2171534173U, 2723054263U, 1168253063U) + v.c2 * math.uint4(4228926523U, 1610574617U, 1584185147U, 3041325733U) + 3150930919U;
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x0001AA89 File Offset: 0x00018C89
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 uint4x4(uint4 c0, uint4 c1, uint4 c2, uint4 c3)
		{
			return new uint4x4(c0, c1, c2, c3);
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x0001AA94 File Offset: 0x00018C94
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 uint4x4(uint m00, uint m01, uint m02, uint m03, uint m10, uint m11, uint m12, uint m13, uint m20, uint m21, uint m22, uint m23, uint m30, uint m31, uint m32, uint m33)
		{
			return new uint4x4(m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33);
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x0001AAC2 File Offset: 0x00018CC2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 uint4x4(uint v)
		{
			return new uint4x4(v);
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x0001AACA File Offset: 0x00018CCA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 uint4x4(bool v)
		{
			return new uint4x4(v);
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0001AAD2 File Offset: 0x00018CD2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 uint4x4(bool4x4 v)
		{
			return new uint4x4(v);
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x0001AADA File Offset: 0x00018CDA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 uint4x4(int v)
		{
			return new uint4x4(v);
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0001AAE2 File Offset: 0x00018CE2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 uint4x4(int4x4 v)
		{
			return new uint4x4(v);
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x0001AAEA File Offset: 0x00018CEA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 uint4x4(float v)
		{
			return new uint4x4(v);
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x0001AAF2 File Offset: 0x00018CF2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 uint4x4(float4x4 v)
		{
			return new uint4x4(v);
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x0001AAFA File Offset: 0x00018CFA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 uint4x4(double v)
		{
			return new uint4x4(v);
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x0001AB02 File Offset: 0x00018D02
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 uint4x4(double4x4 v)
		{
			return new uint4x4(v);
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x0001AB0C File Offset: 0x00018D0C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 transpose(uint4x4 v)
		{
			return math.uint4x4(v.c0.x, v.c0.y, v.c0.z, v.c0.w, v.c1.x, v.c1.y, v.c1.z, v.c1.w, v.c2.x, v.c2.y, v.c2.z, v.c2.w, v.c3.x, v.c3.y, v.c3.z, v.c3.w);
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x0001ABD0 File Offset: 0x00018DD0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint hash(uint4x4 v)
		{
			return math.csum(v.c0 * math.uint4(2627668003U, 1520214331U, 2949502447U, 2827819133U) + v.c1 * math.uint4(3480140317U, 2642994593U, 3940484981U, 1954192763U) + v.c2 * math.uint4(1091696537U, 3052428017U, 4253034763U, 2338696631U) + v.c3 * math.uint4(3757372771U, 1885959949U, 3508684087U, 3919501043U)) + 1209161033U;
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x0001AC88 File Offset: 0x00018E88
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 hashwide(uint4x4 v)
		{
			return v.c0 * math.uint4(4007793211U, 3819806693U, 3458005183U, 2078515003U) + v.c1 * math.uint4(4206465343U, 3025146473U, 3763046909U, 3678265601U) + v.c2 * math.uint4(2070747979U, 1480171127U, 1588341193U, 4234155257U) + v.c3 * math.uint4(1811310911U, 2635799963U, 4165137857U, 2759770933U) + 2759319383U;
		}

		// Token: 0x04000003 RID: 3
		public const double E_DBL = 2.718281828459045;

		// Token: 0x04000004 RID: 4
		public const double LOG2E_DBL = 1.4426950408889634;

		// Token: 0x04000005 RID: 5
		public const double LOG10E_DBL = 0.4342944819032518;

		// Token: 0x04000006 RID: 6
		public const double LN2_DBL = 0.6931471805599453;

		// Token: 0x04000007 RID: 7
		public const double LN10_DBL = 2.302585092994046;

		// Token: 0x04000008 RID: 8
		public const double PI_DBL = 3.141592653589793;

		// Token: 0x04000009 RID: 9
		public const double SQRT2_DBL = 1.4142135623730951;

		// Token: 0x0400000A RID: 10
		public const double EPSILON_DBL = 2.220446049250313E-16;

		// Token: 0x0400000B RID: 11
		public const double INFINITY_DBL = double.PositiveInfinity;

		// Token: 0x0400000C RID: 12
		public const double NAN_DBL = double.NaN;

		// Token: 0x0400000D RID: 13
		public const float FLT_MIN_NORMAL = 1.1754944E-38f;

		// Token: 0x0400000E RID: 14
		public const double DBL_MIN_NORMAL = 2.2250738585072014E-308;

		// Token: 0x0400000F RID: 15
		public const float E = 2.7182817f;

		// Token: 0x04000010 RID: 16
		public const float LOG2E = 1.442695f;

		// Token: 0x04000011 RID: 17
		public const float LOG10E = 0.4342945f;

		// Token: 0x04000012 RID: 18
		public const float LN2 = 0.6931472f;

		// Token: 0x04000013 RID: 19
		public const float LN10 = 2.3025851f;

		// Token: 0x04000014 RID: 20
		public const float PI = 3.1415927f;

		// Token: 0x04000015 RID: 21
		public const float SQRT2 = 1.4142135f;

		// Token: 0x04000016 RID: 22
		public const float EPSILON = 1.1920929E-07f;

		// Token: 0x04000017 RID: 23
		public const float INFINITY = float.PositiveInfinity;

		// Token: 0x04000018 RID: 24
		public const float NAN = float.NaN;

		// Token: 0x02000051 RID: 81
		public enum RotationOrder : byte
		{
			// Token: 0x04000128 RID: 296
			XYZ,
			// Token: 0x04000129 RID: 297
			XZY,
			// Token: 0x0400012A RID: 298
			YXZ,
			// Token: 0x0400012B RID: 299
			YZX,
			// Token: 0x0400012C RID: 300
			ZXY,
			// Token: 0x0400012D RID: 301
			ZYX,
			// Token: 0x0400012E RID: 302
			Default = 4
		}

		// Token: 0x02000052 RID: 82
		public enum ShuffleComponent : byte
		{
			// Token: 0x04000130 RID: 304
			LeftX,
			// Token: 0x04000131 RID: 305
			LeftY,
			// Token: 0x04000132 RID: 306
			LeftZ,
			// Token: 0x04000133 RID: 307
			LeftW,
			// Token: 0x04000134 RID: 308
			RightX,
			// Token: 0x04000135 RID: 309
			RightY,
			// Token: 0x04000136 RID: 310
			RightZ,
			// Token: 0x04000137 RID: 311
			RightW
		}

		// Token: 0x02000053 RID: 83
		[StructLayout(LayoutKind.Explicit)]
		internal struct IntFloatUnion
		{
			// Token: 0x04000138 RID: 312
			[FieldOffset(0)]
			public int intValue;

			// Token: 0x04000139 RID: 313
			[FieldOffset(0)]
			public float floatValue;
		}

		// Token: 0x02000054 RID: 84
		[StructLayout(LayoutKind.Explicit)]
		internal struct LongDoubleUnion
		{
			// Token: 0x0400013A RID: 314
			[FieldOffset(0)]
			public long longValue;

			// Token: 0x0400013B RID: 315
			[FieldOffset(0)]
			public double doubleValue;
		}
	}
}
