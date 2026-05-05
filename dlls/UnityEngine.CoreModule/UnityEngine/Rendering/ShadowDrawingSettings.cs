using System;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x02000472 RID: 1138
	[UsedByNativeCode]
	public struct ShadowDrawingSettings : IEquatable<ShadowDrawingSettings>
	{
		// Token: 0x1700070F RID: 1807
		// (get) Token: 0x060026B3 RID: 9907 RVA: 0x00042590 File Offset: 0x00040790
		// (set) Token: 0x060026B4 RID: 9908 RVA: 0x000425A8 File Offset: 0x000407A8
		public CullingResults cullingResults
		{
			get
			{
				return this.m_CullingResults;
			}
			set
			{
				this.m_CullingResults = value;
			}
		}

		// Token: 0x17000710 RID: 1808
		// (get) Token: 0x060026B5 RID: 9909 RVA: 0x000425B4 File Offset: 0x000407B4
		// (set) Token: 0x060026B6 RID: 9910 RVA: 0x000425CC File Offset: 0x000407CC
		public int lightIndex
		{
			get
			{
				return this.m_LightIndex;
			}
			set
			{
				this.m_LightIndex = value;
			}
		}

		// Token: 0x17000711 RID: 1809
		// (get) Token: 0x060026B7 RID: 9911 RVA: 0x000425D8 File Offset: 0x000407D8
		// (set) Token: 0x060026B8 RID: 9912 RVA: 0x000425F3 File Offset: 0x000407F3
		public bool useRenderingLayerMaskTest
		{
			get
			{
				return this.m_UseRenderingLayerMaskTest != 0;
			}
			set
			{
				this.m_UseRenderingLayerMaskTest = (value ? 1 : 0);
			}
		}

		// Token: 0x17000712 RID: 1810
		// (get) Token: 0x060026B9 RID: 9913 RVA: 0x00042604 File Offset: 0x00040804
		// (set) Token: 0x060026BA RID: 9914 RVA: 0x0004261C File Offset: 0x0004081C
		public ShadowSplitData splitData
		{
			get
			{
				return this.m_SplitData;
			}
			set
			{
				this.m_SplitData = value;
			}
		}

		// Token: 0x17000713 RID: 1811
		// (get) Token: 0x060026BB RID: 9915 RVA: 0x00042628 File Offset: 0x00040828
		// (set) Token: 0x060026BC RID: 9916 RVA: 0x00042640 File Offset: 0x00040840
		public ShadowObjectsFilter objectsFilter
		{
			get
			{
				return this.m_ObjectsFilter;
			}
			set
			{
				this.m_ObjectsFilter = value;
			}
		}

		// Token: 0x17000714 RID: 1812
		// (get) Token: 0x060026BD RID: 9917 RVA: 0x0004264C File Offset: 0x0004084C
		// (set) Token: 0x060026BE RID: 9918 RVA: 0x00042664 File Offset: 0x00040864
		public BatchCullingProjectionType projectionType
		{
			get
			{
				return this.m_ProjectionType;
			}
			set
			{
				this.m_ProjectionType = value;
			}
		}

		// Token: 0x060026BF RID: 9919 RVA: 0x0004266E File Offset: 0x0004086E
		[Obsolete("ShadowDrawingSettings(CullingResults, int) is deprecated. Use ShadowDrawingSettings(CullingResults, int, BatchCullingProjectionType) instead.")]
		public ShadowDrawingSettings(CullingResults cullingResults, int lightIndex)
		{
			this = new ShadowDrawingSettings(cullingResults, lightIndex, BatchCullingProjectionType.Unknown);
		}

		// Token: 0x060026C0 RID: 9920 RVA: 0x0004267C File Offset: 0x0004087C
		public ShadowDrawingSettings(CullingResults cullingResults, int lightIndex, BatchCullingProjectionType projectionType)
		{
			this.m_CullingResults = cullingResults;
			this.m_LightIndex = lightIndex;
			this.m_UseRenderingLayerMaskTest = 0;
			this.m_SplitData = default(ShadowSplitData);
			this.m_SplitData.shadowCascadeBlendCullingFactor = 1f;
			this.m_ObjectsFilter = ShadowObjectsFilter.AllObjects;
			this.m_ProjectionType = projectionType;
		}

		// Token: 0x060026C1 RID: 9921 RVA: 0x000426CC File Offset: 0x000408CC
		public bool Equals(ShadowDrawingSettings other)
		{
			return this.m_CullingResults.Equals(other.m_CullingResults) && this.m_LightIndex == other.m_LightIndex && this.m_SplitData.Equals(other.m_SplitData) && this.m_UseRenderingLayerMaskTest.Equals(other.m_UseRenderingLayerMaskTest) && this.m_ObjectsFilter.Equals(other.m_ObjectsFilter);
		}

		// Token: 0x060026C2 RID: 9922 RVA: 0x00042744 File Offset: 0x00040944
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is ShadowDrawingSettings && this.Equals((ShadowDrawingSettings)obj);
		}

		// Token: 0x060026C3 RID: 9923 RVA: 0x0004277C File Offset: 0x0004097C
		public override int GetHashCode()
		{
			int num = this.m_CullingResults.GetHashCode();
			num = (num * 397 ^ this.m_LightIndex);
			num = (num * 397 ^ this.m_UseRenderingLayerMaskTest);
			num = (num * 397 ^ this.m_SplitData.GetHashCode());
			return num * 397 ^ (int)this.m_ObjectsFilter;
		}

		// Token: 0x060026C4 RID: 9924 RVA: 0x000427EC File Offset: 0x000409EC
		public static bool operator ==(ShadowDrawingSettings left, ShadowDrawingSettings right)
		{
			return left.Equals(right);
		}

		// Token: 0x060026C5 RID: 9925 RVA: 0x00042808 File Offset: 0x00040A08
		public static bool operator !=(ShadowDrawingSettings left, ShadowDrawingSettings right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000E93 RID: 3731
		private CullingResults m_CullingResults;

		// Token: 0x04000E94 RID: 3732
		private int m_LightIndex;

		// Token: 0x04000E95 RID: 3733
		private int m_UseRenderingLayerMaskTest;

		// Token: 0x04000E96 RID: 3734
		private ShadowSplitData m_SplitData;

		// Token: 0x04000E97 RID: 3735
		private ShadowObjectsFilter m_ObjectsFilter;

		// Token: 0x04000E98 RID: 3736
		private BatchCullingProjectionType m_ProjectionType;
	}
}
