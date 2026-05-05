using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000B0 RID: 176
	[Serializable]
	public class ProxyVolume : IVersionable<ProxyVolume.Version>, ISerializationCallbackReceiver
	{
		// Token: 0x17000130 RID: 304
		// (get) Token: 0x0600083F RID: 2111 RVA: 0x0004B7AC File Offset: 0x000499AC
		// (set) Token: 0x06000840 RID: 2112 RVA: 0x0004B7B4 File Offset: 0x000499B4
		public ProxyShape shape
		{
			get
			{
				return this.m_Shape;
			}
			private set
			{
				this.m_Shape = value;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000841 RID: 2113 RVA: 0x0004B7BD File Offset: 0x000499BD
		// (set) Token: 0x06000842 RID: 2114 RVA: 0x0004B7C5 File Offset: 0x000499C5
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

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000843 RID: 2115 RVA: 0x0004B7CE File Offset: 0x000499CE
		// (set) Token: 0x06000844 RID: 2116 RVA: 0x0004B7D6 File Offset: 0x000499D6
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

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000845 RID: 2117 RVA: 0x0004B7DF File Offset: 0x000499DF
		internal Vector3 extents
		{
			get
			{
				return this.GetExtents(this.shape);
			}
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x0004B7F0 File Offset: 0x000499F0
		internal Hash128 ComputeHash()
		{
			Hash128 result = default(Hash128);
			Hash128 hash = default(Hash128);
			HashUtilities.ComputeHash128<ProxyShape>(ref this.m_Shape, ref result);
			HashUtilities.ComputeHash128<Vector3>(ref this.m_BoxSize, ref hash);
			HashUtilities.AppendHash(ref hash, ref result);
			HashUtilities.ComputeHash128<float>(ref this.m_SphereRadius, ref hash);
			return result;
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x0004B83E File Offset: 0x00049A3E
		private Vector3 GetExtents(ProxyShape shape)
		{
			if (shape == ProxyShape.Box)
			{
				return this.m_BoxSize * 0.5f;
			}
			if (shape != ProxyShape.Sphere)
			{
				return Vector3.one;
			}
			return Vector3.one * this.m_SphereRadius;
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000848 RID: 2120 RVA: 0x0004B870 File Offset: 0x00049A70
		// (set) Token: 0x06000849 RID: 2121 RVA: 0x0004B878 File Offset: 0x00049A78
		ProxyVolume.Version IVersionable<ProxyVolume.Version>.version
		{
			get
			{
				return this.m_CSVersion;
			}
			set
			{
				this.m_CSVersion = value;
			}
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x0004B881 File Offset: 0x00049A81
		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x0004B884 File Offset: 0x00049A84
		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			ProxyVolume.k_Migration.Migrate(this);
		}

		// Token: 0x040007E2 RID: 2018
		[SerializeField]
		[FormerlySerializedAs("m_ShapeType")]
		private ProxyShape m_Shape;

		// Token: 0x040007E3 RID: 2019
		[SerializeField]
		[Min(0f)]
		private Vector3 m_BoxSize = Vector3.one;

		// Token: 0x040007E4 RID: 2020
		[SerializeField]
		[Min(0f)]
		private float m_SphereRadius = 1f;

		// Token: 0x040007E5 RID: 2021
		private static readonly MigrationDescription<ProxyVolume.Version, ProxyVolume> k_Migration = MigrationDescription.New<ProxyVolume.Version, ProxyVolume>(new MigrationStep<ProxyVolume.Version, ProxyVolume>[]
		{
			MigrationStep.New<ProxyVolume.Version, ProxyVolume>(ProxyVolume.Version.InfiniteProjectionInShape, delegate(ProxyVolume p)
			{
				if ((p.shape == ProxyShape.Sphere && p.m_ObsoleteSphereInfiniteProjection) || (p.shape == ProxyShape.Box && p.m_ObsoleteBoxInfiniteProjection))
				{
					p.shape = ProxyShape.Infinite;
				}
			}),
			MigrationStep.New<ProxyVolume.Version, ProxyVolume>(ProxyVolume.Version.ForcePositiveSize, delegate(ProxyVolume p)
			{
				p.sphereRadius = Mathf.Abs(p.sphereRadius);
				p.boxSize = new Vector3(Mathf.Abs(p.boxSize.x), Mathf.Abs(p.boxSize.y), Mathf.Abs(p.boxSize.z));
			})
		});

		// Token: 0x040007E6 RID: 2022
		[SerializeField]
		private ProxyVolume.Version m_CSVersion = MigrationDescription.LastVersion<ProxyVolume.Version>();

		// Token: 0x040007E7 RID: 2023
		[SerializeField]
		[FormerlySerializedAs("m_SphereInfiniteProjection")]
		[Obsolete("For data migration")]
		private bool m_ObsoleteSphereInfiniteProjection;

		// Token: 0x040007E8 RID: 2024
		[SerializeField]
		[FormerlySerializedAs("m_BoxInfiniteProjection")]
		[Obsolete("Kept only for compatibility. Use m_Shape instead")]
		private bool m_ObsoleteBoxInfiniteProjection;

		// Token: 0x02000347 RID: 839
		private enum Version
		{
			// Token: 0x04002342 RID: 9026
			Initial,
			// Token: 0x04002343 RID: 9027
			InfiniteProjectionInShape,
			// Token: 0x04002344 RID: 9028
			ForcePositiveSize
		}
	}
}
