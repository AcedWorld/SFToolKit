using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200024A RID: 586
	[Serializable]
	public class DynamicAtlasSettings
	{
		// Token: 0x17000380 RID: 896
		// (get) Token: 0x060010B5 RID: 4277 RVA: 0x0003C701 File Offset: 0x0003A901
		// (set) Token: 0x060010B6 RID: 4278 RVA: 0x0003C709 File Offset: 0x0003A909
		public int minAtlasSize
		{
			get
			{
				return this.m_MinAtlasSize;
			}
			set
			{
				this.m_MinAtlasSize = value;
			}
		}

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x060010B7 RID: 4279 RVA: 0x0003C712 File Offset: 0x0003A912
		// (set) Token: 0x060010B8 RID: 4280 RVA: 0x0003C71A File Offset: 0x0003A91A
		public int maxAtlasSize
		{
			get
			{
				return this.m_MaxAtlasSize;
			}
			set
			{
				this.m_MaxAtlasSize = value;
			}
		}

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x060010B9 RID: 4281 RVA: 0x0003C723 File Offset: 0x0003A923
		// (set) Token: 0x060010BA RID: 4282 RVA: 0x0003C72B File Offset: 0x0003A92B
		public int maxSubTextureSize
		{
			get
			{
				return this.m_MaxSubTextureSize;
			}
			set
			{
				this.m_MaxSubTextureSize = value;
			}
		}

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x060010BB RID: 4283 RVA: 0x0003C734 File Offset: 0x0003A934
		// (set) Token: 0x060010BC RID: 4284 RVA: 0x0003C73C File Offset: 0x0003A93C
		public DynamicAtlasFilters activeFilters
		{
			get
			{
				return this.m_ActiveFilters;
			}
			set
			{
				this.m_ActiveFilters = value;
			}
		}

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x060010BD RID: 4285 RVA: 0x0003C745 File Offset: 0x0003A945
		public static DynamicAtlasFilters defaultFilters
		{
			get
			{
				return DynamicAtlas.defaultFilters;
			}
		}

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x060010BE RID: 4286 RVA: 0x0003C74C File Offset: 0x0003A94C
		// (set) Token: 0x060010BF RID: 4287 RVA: 0x0003C754 File Offset: 0x0003A954
		public DynamicAtlasCustomFilter customFilter
		{
			get
			{
				return this.m_CustomFilter;
			}
			set
			{
				this.m_CustomFilter = value;
			}
		}

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x060010C0 RID: 4288 RVA: 0x0003C75D File Offset: 0x0003A95D
		public static DynamicAtlasSettings defaults
		{
			get
			{
				return new DynamicAtlasSettings
				{
					minAtlasSize = 64,
					maxAtlasSize = 4096,
					maxSubTextureSize = 64,
					activeFilters = DynamicAtlasSettings.defaultFilters,
					customFilter = null
				};
			}
		}

		// Token: 0x04000751 RID: 1873
		[HideInInspector]
		[SerializeField]
		private int m_MinAtlasSize;

		// Token: 0x04000752 RID: 1874
		[HideInInspector]
		[SerializeField]
		private int m_MaxAtlasSize;

		// Token: 0x04000753 RID: 1875
		[HideInInspector]
		[SerializeField]
		private int m_MaxSubTextureSize;

		// Token: 0x04000754 RID: 1876
		[HideInInspector]
		[SerializeField]
		private DynamicAtlasFilters m_ActiveFilters;

		// Token: 0x04000755 RID: 1877
		private DynamicAtlasCustomFilter m_CustomFilter;
	}
}
