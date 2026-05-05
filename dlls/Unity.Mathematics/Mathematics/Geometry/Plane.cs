using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics.Geometry
{
	// Token: 0x0200004D RID: 77
	[DebuggerDisplay("{Normal}, {Distance}")]
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	internal struct Plane
	{
		// Token: 0x06002458 RID: 9304 RVA: 0x00067320 File Offset: 0x00065520
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Plane(float coefficientA, float coefficientB, float coefficientC, float coefficientD)
		{
			this.NormalAndDistance = Plane.Normalize(new float4(coefficientA, coefficientB, coefficientC, coefficientD));
		}

		// Token: 0x06002459 RID: 9305 RVA: 0x00067337 File Offset: 0x00065537
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Plane(float3 normal, float distance)
		{
			this.NormalAndDistance = Plane.Normalize(new float4(normal, distance));
		}

		// Token: 0x0600245A RID: 9306 RVA: 0x0006734B File Offset: 0x0006554B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Plane(float3 normal, float3 pointInPlane)
		{
			this = new Plane(normal, -math.dot(normal, pointInPlane));
		}

		// Token: 0x0600245B RID: 9307 RVA: 0x0006735C File Offset: 0x0006555C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Plane(float3 vector1InPlane, float3 vector2InPlane, float3 pointInPlane)
		{
			this = new Plane(math.cross(vector1InPlane, vector2InPlane), pointInPlane);
		}

		// Token: 0x0600245C RID: 9308 RVA: 0x0006736C File Offset: 0x0006556C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Plane CreateFromUnitNormalAndDistance(float3 unitNormal, float distance)
		{
			return new Plane
			{
				NormalAndDistance = new float4(unitNormal, distance)
			};
		}

		// Token: 0x0600245D RID: 9309 RVA: 0x00067390 File Offset: 0x00065590
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Plane CreateFromUnitNormalAndPointInPlane(float3 unitNormal, float3 pointInPlane)
		{
			return new Plane
			{
				NormalAndDistance = new float4(unitNormal, -math.dot(unitNormal, pointInPlane))
			};
		}

		// Token: 0x17000B8F RID: 2959
		// (get) Token: 0x0600245E RID: 9310 RVA: 0x000673BB File Offset: 0x000655BB
		// (set) Token: 0x0600245F RID: 9311 RVA: 0x000673C8 File Offset: 0x000655C8
		public float3 Normal
		{
			get
			{
				return this.NormalAndDistance.xyz;
			}
			set
			{
				this.NormalAndDistance.xyz = value;
			}
		}

		// Token: 0x17000B90 RID: 2960
		// (get) Token: 0x06002460 RID: 9312 RVA: 0x000673D6 File Offset: 0x000655D6
		// (set) Token: 0x06002461 RID: 9313 RVA: 0x000673E3 File Offset: 0x000655E3
		public float Distance
		{
			get
			{
				return this.NormalAndDistance.w;
			}
			set
			{
				this.NormalAndDistance.w = value;
			}
		}

		// Token: 0x06002462 RID: 9314 RVA: 0x000673F4 File Offset: 0x000655F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Plane Normalize(Plane plane)
		{
			return new Plane
			{
				NormalAndDistance = Plane.Normalize(plane.NormalAndDistance)
			};
		}

		// Token: 0x06002463 RID: 9315 RVA: 0x0006741C File Offset: 0x0006561C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 Normalize(float4 planeCoefficients)
		{
			float rhs = math.rsqrt(math.lengthsq(planeCoefficients.xyz));
			return new Plane
			{
				NormalAndDistance = planeCoefficients * rhs
			};
		}

		// Token: 0x06002464 RID: 9316 RVA: 0x00067457 File Offset: 0x00065657
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float SignedDistanceToPoint(float3 point)
		{
			return math.dot(this.NormalAndDistance, new float4(point, 1f));
		}

		// Token: 0x06002465 RID: 9317 RVA: 0x0006746F File Offset: 0x0006566F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3 Projection(float3 point)
		{
			return point - this.Normal * this.SignedDistanceToPoint(point);
		}

		// Token: 0x17000B91 RID: 2961
		// (get) Token: 0x06002466 RID: 9318 RVA: 0x0006748C File Offset: 0x0006568C
		public Plane Flipped
		{
			get
			{
				return new Plane
				{
					NormalAndDistance = -this.NormalAndDistance
				};
			}
		}

		// Token: 0x06002467 RID: 9319 RVA: 0x000674B4 File Offset: 0x000656B4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4(Plane plane)
		{
			return plane.NormalAndDistance;
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x000674BC File Offset: 0x000656BC
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckPlaneIsNormalized()
		{
			float num = math.lengthsq(this.Normal.xyz);
			if (num < 0.99800104f || num > 1.002001f)
			{
				throw new ArgumentException("Plane must be normalized. Call Plane.Normalize() to normalize plane.");
			}
		}

		// Token: 0x0400011D RID: 285
		public float4 NormalAndDistance;
	}
}
