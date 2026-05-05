using System;
using System.Runtime.CompilerServices;

namespace Unity.Mathematics.Geometry
{
	// Token: 0x0200004C RID: 76
	internal static class Math
	{
		// Token: 0x06002455 RID: 9301 RVA: 0x00067088 File Offset: 0x00065288
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MinMaxAABB Transform(RigidTransform transform, MinMaxAABB aabb)
		{
			float3 halfExtents = aabb.HalfExtents;
			float3 x = math.rotate(transform.rot, new float3(halfExtents.x, 0f, 0f));
			float3 x2 = math.rotate(transform.rot, new float3(0f, halfExtents.y, 0f));
			float3 x3 = math.rotate(transform.rot, new float3(0f, 0f, halfExtents.z));
			float3 rhs = math.abs(x) + math.abs(x2) + math.abs(x3);
			float3 lhs = math.transform(transform, aabb.Center);
			return new MinMaxAABB(lhs - rhs, lhs + rhs);
		}

		// Token: 0x06002456 RID: 9302 RVA: 0x00067140 File Offset: 0x00065340
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MinMaxAABB Transform(float4x4 transform, MinMaxAABB aabb)
		{
			MinMaxAABB result = Math.Transform(new float3x3(transform), aabb);
			result.Min += transform.c3.xyz;
			result.Max += transform.c3.xyz;
			return result;
		}

		// Token: 0x06002457 RID: 9303 RVA: 0x000671A4 File Offset: 0x000653A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MinMaxAABB Transform(float3x3 transform, MinMaxAABB aabb)
		{
			float3 @float = transform.c0.xyz * aabb.Min.xxx;
			float3 float2 = transform.c0.xyz * aabb.Max.xxx;
			bool3 @bool = @float < float2;
			MinMaxAABB result = new MinMaxAABB(math.select(float2, @float, @bool), math.select(float2, @float, !@bool));
			@float = transform.c1.xyz * aabb.Min.yyy;
			float2 = transform.c1.xyz * aabb.Max.yyy;
			@bool = (@float < float2);
			result.Min += math.select(float2, @float, @bool);
			result.Max += math.select(float2, @float, !@bool);
			@float = transform.c2.xyz * aabb.Min.zzz;
			float2 = transform.c2.xyz * aabb.Max.zzz;
			@bool = (@float < float2);
			result.Min += math.select(float2, @float, @bool);
			result.Max += math.select(float2, @float, !@bool);
			return result;
		}
	}
}
