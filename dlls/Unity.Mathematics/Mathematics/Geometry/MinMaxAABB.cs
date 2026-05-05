using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics.Geometry
{
	// Token: 0x0200004B RID: 75
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	internal struct MinMaxAABB : IEquatable<MinMaxAABB>
	{
		// Token: 0x06002445 RID: 9285 RVA: 0x00066E73 File Offset: 0x00065073
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public MinMaxAABB(float3 min, float3 max)
		{
			this.Min = min;
			this.Max = max;
		}

		// Token: 0x06002446 RID: 9286 RVA: 0x00066E83 File Offset: 0x00065083
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MinMaxAABB CreateFromCenterAndExtents(float3 center, float3 extents)
		{
			return MinMaxAABB.CreateFromCenterAndHalfExtents(center, extents * 0.5f);
		}

		// Token: 0x06002447 RID: 9287 RVA: 0x00066E96 File Offset: 0x00065096
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MinMaxAABB CreateFromCenterAndHalfExtents(float3 center, float3 halfExtents)
		{
			return new MinMaxAABB(center - halfExtents, center + halfExtents);
		}

		// Token: 0x17000B8A RID: 2954
		// (get) Token: 0x06002448 RID: 9288 RVA: 0x00066EAB File Offset: 0x000650AB
		public float3 Extents
		{
			get
			{
				return this.Max - this.Min;
			}
		}

		// Token: 0x17000B8B RID: 2955
		// (get) Token: 0x06002449 RID: 9289 RVA: 0x00066EBE File Offset: 0x000650BE
		public float3 HalfExtents
		{
			get
			{
				return (this.Max - this.Min) * 0.5f;
			}
		}

		// Token: 0x17000B8C RID: 2956
		// (get) Token: 0x0600244A RID: 9290 RVA: 0x00066EDB File Offset: 0x000650DB
		public float3 Center
		{
			get
			{
				return (this.Max + this.Min) * 0.5f;
			}
		}

		// Token: 0x17000B8D RID: 2957
		// (get) Token: 0x0600244B RID: 9291 RVA: 0x00066EF8 File Offset: 0x000650F8
		public bool IsValid
		{
			get
			{
				return math.all(this.Min <= this.Max);
			}
		}

		// Token: 0x17000B8E RID: 2958
		// (get) Token: 0x0600244C RID: 9292 RVA: 0x00066F10 File Offset: 0x00065110
		public float SurfaceArea
		{
			get
			{
				float3 x = this.Max - this.Min;
				return 2f * math.dot(x, x.yzx);
			}
		}

		// Token: 0x0600244D RID: 9293 RVA: 0x00066F42 File Offset: 0x00065142
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(float3 point)
		{
			return math.all(point >= this.Min & point <= this.Max);
		}

		// Token: 0x0600244E RID: 9294 RVA: 0x00066F66 File Offset: 0x00065166
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(MinMaxAABB aabb)
		{
			return math.all(this.Min <= aabb.Min & this.Max >= aabb.Max);
		}

		// Token: 0x0600244F RID: 9295 RVA: 0x00066F94 File Offset: 0x00065194
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Overlaps(MinMaxAABB aabb)
		{
			return math.all(this.Max >= aabb.Min & this.Min <= aabb.Max);
		}

		// Token: 0x06002450 RID: 9296 RVA: 0x00066FC2 File Offset: 0x000651C2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Expand(float signedDistance)
		{
			this.Min -= signedDistance;
			this.Max += signedDistance;
		}

		// Token: 0x06002451 RID: 9297 RVA: 0x00066FE8 File Offset: 0x000651E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Encapsulate(MinMaxAABB aabb)
		{
			this.Min = math.min(this.Min, aabb.Min);
			this.Max = math.max(this.Max, aabb.Max);
		}

		// Token: 0x06002452 RID: 9298 RVA: 0x00067018 File Offset: 0x00065218
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Encapsulate(float3 point)
		{
			this.Min = math.min(this.Min, point);
			this.Max = math.max(this.Max, point);
		}

		// Token: 0x06002453 RID: 9299 RVA: 0x0006703E File Offset: 0x0006523E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(MinMaxAABB other)
		{
			return this.Min.Equals(other.Min) && this.Max.Equals(other.Max);
		}

		// Token: 0x06002454 RID: 9300 RVA: 0x00067066 File Offset: 0x00065266
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("MinMaxAABB({0}, {1})", this.Min, this.Max);
		}

		// Token: 0x0400011B RID: 283
		public float3 Min;

		// Token: 0x0400011C RID: 284
		public float3 Max;
	}
}
