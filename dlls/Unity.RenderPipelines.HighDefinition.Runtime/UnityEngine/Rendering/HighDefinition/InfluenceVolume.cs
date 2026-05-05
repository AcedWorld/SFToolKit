using System;
using System.Runtime.CompilerServices;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000AF RID: 175
	[Serializable]
	public class InfluenceVolume : IVersionable<InfluenceVolume.Version>, ISerializationCallbackReceiver
	{
		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000813 RID: 2067 RVA: 0x0004AF67 File Offset: 0x00049167
		// (set) Token: 0x06000814 RID: 2068 RVA: 0x0004AF6F File Offset: 0x0004916F
		public InfluenceShape shape
		{
			get
			{
				return this.m_Shape;
			}
			set
			{
				this.m_Shape = value;
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000815 RID: 2069 RVA: 0x0004AF78 File Offset: 0x00049178
		public Vector3 extents
		{
			get
			{
				return this.GetExtents(this.shape);
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000816 RID: 2070 RVA: 0x0004AF86 File Offset: 0x00049186
		// (set) Token: 0x06000817 RID: 2071 RVA: 0x0004AF8E File Offset: 0x0004918E
		public Vector3 boxSize
		{
			get
			{
				return this.m_BoxSize;
			}
			set
			{
				this.m_BoxSize = value;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000818 RID: 2072 RVA: 0x0004AF97 File Offset: 0x00049197
		public Vector3 boxBlendOffset
		{
			get
			{
				return (this.boxBlendDistanceNegative - this.boxBlendDistancePositive) * 0.5f;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000819 RID: 2073 RVA: 0x0004AFB4 File Offset: 0x000491B4
		public Vector3 boxBlendSize
		{
			get
			{
				return -(this.boxBlendDistancePositive + this.boxBlendDistanceNegative);
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x0600081A RID: 2074 RVA: 0x0004AFCC File Offset: 0x000491CC
		// (set) Token: 0x0600081B RID: 2075 RVA: 0x0004AFD4 File Offset: 0x000491D4
		public Vector3 boxBlendDistancePositive
		{
			get
			{
				return this.m_BoxBlendDistancePositive;
			}
			set
			{
				this.m_BoxBlendDistancePositive = value;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600081C RID: 2076 RVA: 0x0004AFDD File Offset: 0x000491DD
		// (set) Token: 0x0600081D RID: 2077 RVA: 0x0004AFE5 File Offset: 0x000491E5
		public Vector3 boxBlendDistanceNegative
		{
			get
			{
				return this.m_BoxBlendDistanceNegative;
			}
			set
			{
				this.m_BoxBlendDistanceNegative = value;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600081E RID: 2078 RVA: 0x0004AFEE File Offset: 0x000491EE
		public Vector3 boxBlendNormalOffset
		{
			get
			{
				return (this.boxBlendNormalDistanceNegative - this.boxBlendNormalDistancePositive) * 0.5f;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x0600081F RID: 2079 RVA: 0x0004B00B File Offset: 0x0004920B
		public Vector3 boxBlendNormalSize
		{
			get
			{
				return -(this.boxBlendNormalDistancePositive + this.boxBlendNormalDistanceNegative);
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000820 RID: 2080 RVA: 0x0004B023 File Offset: 0x00049223
		// (set) Token: 0x06000821 RID: 2081 RVA: 0x0004B02B File Offset: 0x0004922B
		public Vector3 boxBlendNormalDistancePositive
		{
			get
			{
				return this.m_BoxBlendNormalDistancePositive;
			}
			set
			{
				this.m_BoxBlendNormalDistancePositive = value;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000822 RID: 2082 RVA: 0x0004B034 File Offset: 0x00049234
		// (set) Token: 0x06000823 RID: 2083 RVA: 0x0004B03C File Offset: 0x0004923C
		public Vector3 boxBlendNormalDistanceNegative
		{
			get
			{
				return this.m_BoxBlendNormalDistanceNegative;
			}
			set
			{
				this.m_BoxBlendNormalDistanceNegative = value;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000824 RID: 2084 RVA: 0x0004B045 File Offset: 0x00049245
		// (set) Token: 0x06000825 RID: 2085 RVA: 0x0004B04D File Offset: 0x0004924D
		public Vector3 boxSideFadePositive
		{
			get
			{
				return this.m_BoxSideFadePositive;
			}
			set
			{
				this.m_BoxSideFadePositive = value;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000826 RID: 2086 RVA: 0x0004B056 File Offset: 0x00049256
		// (set) Token: 0x06000827 RID: 2087 RVA: 0x0004B05E File Offset: 0x0004925E
		public Vector3 boxSideFadeNegative
		{
			get
			{
				return this.m_BoxSideFadeNegative;
			}
			set
			{
				this.m_BoxSideFadeNegative = value;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000828 RID: 2088 RVA: 0x0004B067 File Offset: 0x00049267
		// (set) Token: 0x06000829 RID: 2089 RVA: 0x0004B06F File Offset: 0x0004926F
		public float sphereRadius
		{
			get
			{
				return this.m_SphereRadius;
			}
			set
			{
				this.m_SphereRadius = value;
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600082A RID: 2090 RVA: 0x0004B078 File Offset: 0x00049278
		// (set) Token: 0x0600082B RID: 2091 RVA: 0x0004B080 File Offset: 0x00049280
		public float sphereBlendDistance
		{
			get
			{
				return this.m_SphereBlendDistance;
			}
			set
			{
				this.m_SphereBlendDistance = value;
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600082C RID: 2092 RVA: 0x0004B089 File Offset: 0x00049289
		// (set) Token: 0x0600082D RID: 2093 RVA: 0x0004B091 File Offset: 0x00049291
		public float sphereBlendNormalDistance
		{
			get
			{
				return this.m_SphereBlendNormalDistance;
			}
			set
			{
				this.m_SphereBlendNormalDistance = value;
			}
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x0004B09C File Offset: 0x0004929C
		public Hash128 ComputeHash()
		{
			Hash128 result = default(Hash128);
			Hash128 hash = default(Hash128);
			HashUtilities.ComputeHash128<InfluenceShape>(ref this.m_Shape, ref result);
			HashUtilities.ComputeHash128<Vector3>(ref this.m_ObsoleteOffset, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<Vector3>(ref this.m_BoxBlendDistanceNegative, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<Vector3>(ref this.m_BoxBlendDistancePositive, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<Vector3>(ref this.m_BoxBlendNormalDistanceNegative, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<Vector3>(ref this.m_BoxBlendNormalDistancePositive, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<Vector3>(ref this.m_BoxSideFadeNegative, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<Vector3>(ref this.m_BoxSideFadePositive, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<Vector3>(ref this.m_BoxSize, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<float>(ref this.m_SphereBlendDistance, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<float>(ref this.m_SphereBlendNormalDistance, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<float>(ref this.m_SphereRadius, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			return result;
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x0004B1BC File Offset: 0x000493BC
		internal BoundingSphere GetBoundingSphereAt(Vector3 position)
		{
			InfluenceShape shape = this.shape;
			if (shape != InfluenceShape.Box)
			{
				return new BoundingSphere(position, this.sphereRadius);
			}
			float rad = Mathf.Max(this.boxSize.x, Mathf.Max(this.boxSize.y, this.boxSize.z));
			return new BoundingSphere(position, rad);
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x0004B218 File Offset: 0x00049418
		internal Bounds GetBoundsAt(Vector3 position)
		{
			InfluenceShape shape = this.shape;
			if (shape != InfluenceShape.Box)
			{
				return new Bounds(position, Vector3.one * this.sphereRadius);
			}
			return new Bounds(position, this.boxSize);
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x0004B256 File Offset: 0x00049456
		internal Matrix4x4 GetInfluenceToWorld(Transform transform)
		{
			return Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000832 RID: 2098 RVA: 0x0004B270 File Offset: 0x00049470
		internal EnvShapeType envShape
		{
			get
			{
				InfluenceShape shape = this.shape;
				if (shape == InfluenceShape.Box || shape != InfluenceShape.Sphere)
				{
					return EnvShapeType.Box;
				}
				return EnvShapeType.Sphere;
			}
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x0004B290 File Offset: 0x00049490
		internal void CopyTo(InfluenceVolume data)
		{
			data.m_Shape = this.m_Shape;
			data.m_ObsoleteOffset = this.m_ObsoleteOffset;
			data.m_BoxSize = this.m_BoxSize;
			data.m_BoxBlendDistancePositive = this.m_BoxBlendDistancePositive;
			data.m_BoxBlendDistanceNegative = this.m_BoxBlendDistanceNegative;
			data.m_BoxBlendNormalDistancePositive = this.m_BoxBlendNormalDistancePositive;
			data.m_BoxBlendNormalDistanceNegative = this.m_BoxBlendNormalDistanceNegative;
			data.m_BoxSideFadePositive = this.m_BoxSideFadePositive;
			data.m_BoxSideFadeNegative = this.m_BoxSideFadeNegative;
			data.m_SphereRadius = this.m_SphereRadius;
			data.m_SphereBlendDistance = this.m_SphereBlendDistance;
			data.m_SphereBlendNormalDistance = this.m_SphereBlendNormalDistance;
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x0004B330 File Offset: 0x00049530
		private Vector3 GetExtents(InfluenceShape shape)
		{
			if (shape == InfluenceShape.Box || shape != InfluenceShape.Sphere)
			{
				return Vector3.Max(Vector3.one * 0.0001f, this.boxSize * 0.5f);
			}
			return Mathf.Max(0.0001f, this.sphereRadius) * Vector3.one;
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x0004B384 File Offset: 0x00049584
		public float ComputeFOVAt(Vector3 viewerPositionWS, Vector3 lookAtPositionWS, Matrix4x4 influenceToWorld)
		{
			InfluenceVolume.<>c__DisplayClass62_0 CS$<>8__locals1;
			CS$<>8__locals1.lookAtPositionWS = lookAtPositionWS;
			CS$<>8__locals1.viewerPositionWS = viewerPositionWS;
			float result = 0f;
			EnvShapeType envShape = this.envShape;
			if (envShape != EnvShapeType.Box)
			{
				if (envShape != EnvShapeType.Sphere)
				{
					result = 90f;
				}
				else
				{
					InfluenceVolume.<ComputeFOVAt>g__GrowFOVToInclude|62_0(ref result, influenceToWorld.MultiplyPoint(new Vector3(this.sphereRadius * 2f, 0f, 0f)), ref CS$<>8__locals1);
					InfluenceVolume.<ComputeFOVAt>g__GrowFOVToInclude|62_0(ref result, influenceToWorld.MultiplyPoint(new Vector3(-this.sphereRadius * 2f, 0f, 0f)), ref CS$<>8__locals1);
					InfluenceVolume.<ComputeFOVAt>g__GrowFOVToInclude|62_0(ref result, influenceToWorld.MultiplyPoint(new Vector3(0f, this.sphereRadius * 2f, 0f)), ref CS$<>8__locals1);
					InfluenceVolume.<ComputeFOVAt>g__GrowFOVToInclude|62_0(ref result, influenceToWorld.MultiplyPoint(new Vector3(0f, -this.sphereRadius * 2f, 0f)), ref CS$<>8__locals1);
					InfluenceVolume.<ComputeFOVAt>g__GrowFOVToInclude|62_0(ref result, influenceToWorld.MultiplyPoint(new Vector3(0f, 0f, this.sphereRadius * 2f)), ref CS$<>8__locals1);
					InfluenceVolume.<ComputeFOVAt>g__GrowFOVToInclude|62_0(ref result, influenceToWorld.MultiplyPoint(new Vector3(0f, 0f, -this.sphereRadius * 2f)), ref CS$<>8__locals1);
				}
			}
			else
			{
				InfluenceVolume.<ComputeFOVAt>g__GrowFOVToInclude|62_0(ref result, influenceToWorld.MultiplyPoint(new Vector3(this.boxSize.x, -this.boxSize.y, -this.boxSize.z)), ref CS$<>8__locals1);
				InfluenceVolume.<ComputeFOVAt>g__GrowFOVToInclude|62_0(ref result, influenceToWorld.MultiplyPoint(new Vector3(this.boxSize.x, -this.boxSize.y, this.boxSize.z)), ref CS$<>8__locals1);
				InfluenceVolume.<ComputeFOVAt>g__GrowFOVToInclude|62_0(ref result, influenceToWorld.MultiplyPoint(new Vector3(this.boxSize.x, this.boxSize.y, -this.boxSize.z)), ref CS$<>8__locals1);
				InfluenceVolume.<ComputeFOVAt>g__GrowFOVToInclude|62_0(ref result, influenceToWorld.MultiplyPoint(new Vector3(this.boxSize.x, this.boxSize.y, this.boxSize.z)), ref CS$<>8__locals1);
				InfluenceVolume.<ComputeFOVAt>g__GrowFOVToInclude|62_0(ref result, influenceToWorld.MultiplyPoint(new Vector3(-this.boxSize.x, -this.boxSize.y, -this.boxSize.z)), ref CS$<>8__locals1);
				InfluenceVolume.<ComputeFOVAt>g__GrowFOVToInclude|62_0(ref result, influenceToWorld.MultiplyPoint(new Vector3(-this.boxSize.x, -this.boxSize.y, this.boxSize.z)), ref CS$<>8__locals1);
				InfluenceVolume.<ComputeFOVAt>g__GrowFOVToInclude|62_0(ref result, influenceToWorld.MultiplyPoint(new Vector3(-this.boxSize.x, this.boxSize.y, -this.boxSize.z)), ref CS$<>8__locals1);
				InfluenceVolume.<ComputeFOVAt>g__GrowFOVToInclude|62_0(ref result, influenceToWorld.MultiplyPoint(new Vector3(-this.boxSize.x, this.boxSize.y, this.boxSize.z)), ref CS$<>8__locals1);
			}
			return result;
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000836 RID: 2102 RVA: 0x0004B68D File Offset: 0x0004988D
		// (set) Token: 0x06000837 RID: 2103 RVA: 0x0004B695 File Offset: 0x00049895
		InfluenceVolume.Version IVersionable<InfluenceVolume.Version>.version
		{
			get
			{
				return this.m_Version;
			}
			set
			{
				this.m_Version = value;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000838 RID: 2104 RVA: 0x0004B69E File Offset: 0x0004989E
		// (set) Token: 0x06000839 RID: 2105 RVA: 0x0004B6A6 File Offset: 0x000498A6
		[Obsolete("Only used for data migration purpose. Don't use this field.")]
		internal Vector3 obsoleteOffset
		{
			get
			{
				return this.m_ObsoleteOffset;
			}
			set
			{
				this.m_ObsoleteOffset = value;
			}
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x0004B6AF File Offset: 0x000498AF
		public void OnBeforeSerialize()
		{
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x0004B6B4 File Offset: 0x000498B4
		public void OnAfterDeserialize()
		{
			InfluenceVolume.k_Migration.Migrate(this);
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x0004B76C File Offset: 0x0004996C
		[CompilerGenerated]
		internal static void <ComputeFOVAt>g__GrowFOVToInclude|62_0(ref float fieldOfView, Vector3 positionWS, ref InfluenceVolume.<>c__DisplayClass62_0 A_2)
		{
			float num = Vector3.Angle(A_2.lookAtPositionWS - A_2.viewerPositionWS, positionWS - A_2.viewerPositionWS);
			fieldOfView = Mathf.Max(num * 2f, fieldOfView);
		}

		// Token: 0x040007CA RID: 1994
		[SerializeField]
		[FormerlySerializedAs("m_ShapeType")]
		private InfluenceShape m_Shape;

		// Token: 0x040007CB RID: 1995
		[SerializeField]
		[FormerlySerializedAs("m_BoxBaseSize")]
		private Vector3 m_BoxSize = Vector3.one * 10f;

		// Token: 0x040007CC RID: 1996
		[SerializeField]
		[FormerlySerializedAs("m_BoxInfluencePositiveFade")]
		private Vector3 m_BoxBlendDistancePositive;

		// Token: 0x040007CD RID: 1997
		[SerializeField]
		[FormerlySerializedAs("m_BoxInfluenceNegativeFade")]
		private Vector3 m_BoxBlendDistanceNegative;

		// Token: 0x040007CE RID: 1998
		[SerializeField]
		[FormerlySerializedAs("m_BoxInfluenceNormalPositiveFade")]
		private Vector3 m_BoxBlendNormalDistancePositive;

		// Token: 0x040007CF RID: 1999
		[SerializeField]
		[FormerlySerializedAs("m_BoxInfluenceNormalNegativeFade")]
		private Vector3 m_BoxBlendNormalDistanceNegative;

		// Token: 0x040007D0 RID: 2000
		[SerializeField]
		[FormerlySerializedAs("m_BoxPositiveFaceFade")]
		private Vector3 m_BoxSideFadePositive = Vector3.one;

		// Token: 0x040007D1 RID: 2001
		[SerializeField]
		[FormerlySerializedAs("m_BoxNegativeFaceFade")]
		private Vector3 m_BoxSideFadeNegative = Vector3.one;

		// Token: 0x040007D2 RID: 2002
		[SerializeField]
		[FormerlySerializedAs("m_SphereBaseRadius")]
		[Min(0f)]
		private float m_SphereRadius = 3f;

		// Token: 0x040007D3 RID: 2003
		[SerializeField]
		[FormerlySerializedAs("m_SphereInfluenceFade")]
		private float m_SphereBlendDistance;

		// Token: 0x040007D4 RID: 2004
		[SerializeField]
		[FormerlySerializedAs("m_SphereInfluenceNormalFade")]
		private float m_SphereBlendNormalDistance;

		// Token: 0x040007D5 RID: 2005
		[SerializeField]
		[FormerlySerializedAs("editorAdvancedModeBlendDistancePositive")]
		private Vector3 m_EditorAdvancedModeBlendDistancePositive;

		// Token: 0x040007D6 RID: 2006
		[SerializeField]
		[FormerlySerializedAs("editorAdvancedModeBlendDistanceNegative")]
		private Vector3 m_EditorAdvancedModeBlendDistanceNegative;

		// Token: 0x040007D7 RID: 2007
		[SerializeField]
		[FormerlySerializedAs("editorSimplifiedModeBlendDistance")]
		private float m_EditorSimplifiedModeBlendDistance;

		// Token: 0x040007D8 RID: 2008
		[SerializeField]
		[FormerlySerializedAs("editorAdvancedModeBlendNormalDistancePositive")]
		private Vector3 m_EditorAdvancedModeBlendNormalDistancePositive;

		// Token: 0x040007D9 RID: 2009
		[SerializeField]
		[FormerlySerializedAs("editorAdvancedModeBlendNormalDistanceNegative")]
		private Vector3 m_EditorAdvancedModeBlendNormalDistanceNegative;

		// Token: 0x040007DA RID: 2010
		[SerializeField]
		[FormerlySerializedAs("editorSimplifiedModeBlendNormalDistance")]
		private float m_EditorSimplifiedModeBlendNormalDistance;

		// Token: 0x040007DB RID: 2011
		[SerializeField]
		[FormerlySerializedAs("editorAdvancedModeEnabled")]
		private bool m_EditorAdvancedModeEnabled;

		// Token: 0x040007DC RID: 2012
		[SerializeField]
		private Vector3 m_EditorAdvancedModeFaceFadePositive = Vector3.one;

		// Token: 0x040007DD RID: 2013
		[SerializeField]
		private Vector3 m_EditorAdvancedModeFaceFadeNegative = Vector3.one;

		// Token: 0x040007DE RID: 2014
		private static readonly MigrationDescription<InfluenceVolume.Version, InfluenceVolume> k_Migration = MigrationDescription.New<InfluenceVolume.Version, InfluenceVolume>(new MigrationStep<InfluenceVolume.Version, InfluenceVolume>[]
		{
			MigrationStep.New<InfluenceVolume.Version, InfluenceVolume>(InfluenceVolume.Version.SphereOffset, delegate(InfluenceVolume i)
			{
				if (i.shape == InfluenceShape.Sphere)
				{
					i.m_ObsoleteOffset = i.m_ObsoleteSphereBaseOffset;
				}
			})
		});

		// Token: 0x040007DF RID: 2015
		[SerializeField]
		[ExcludeCopy]
		private InfluenceVolume.Version m_Version = MigrationDescription.LastVersion<InfluenceVolume.Version>();

		// Token: 0x040007E0 RID: 2016
		[SerializeField]
		[FormerlySerializedAs("m_SphereBaseOffset")]
		[Obsolete("For Data Migration")]
		[ExcludeCopy]
		private Vector3 m_ObsoleteSphereBaseOffset;

		// Token: 0x040007E1 RID: 2017
		[SerializeField]
		[FormerlySerializedAs("m_BoxBaseOffset")]
		[FormerlySerializedAs("m_Offset")]
		[ExcludeCopy]
		private Vector3 m_ObsoleteOffset;

		// Token: 0x02000344 RID: 836
		private enum Version
		{
			// Token: 0x0400233C RID: 9020
			Initial,
			// Token: 0x0400233D RID: 9021
			SphereOffset
		}
	}
}
