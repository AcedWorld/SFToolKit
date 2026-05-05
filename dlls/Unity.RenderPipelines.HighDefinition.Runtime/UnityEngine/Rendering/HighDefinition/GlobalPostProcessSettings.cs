using System;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200014E RID: 334
	[Serializable]
	public struct GlobalPostProcessSettings
	{
		// Token: 0x06000ADE RID: 2782 RVA: 0x0005AE40 File Offset: 0x00059040
		internal static GlobalPostProcessSettings NewDefault()
		{
			return new GlobalPostProcessSettings
			{
				lutSize = 32,
				lutFormat = GradingLutFormat.R16G16B16A16,
				bufferFormat = PostProcessBufferFormat.R11G11B10
			};
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000ADF RID: 2783 RVA: 0x0005AE71 File Offset: 0x00059071
		internal bool supportsAlpha
		{
			get
			{
				return this.bufferFormat != PostProcessBufferFormat.R11G11B10;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000AE0 RID: 2784 RVA: 0x0005AE80 File Offset: 0x00059080
		// (set) Token: 0x06000AE1 RID: 2785 RVA: 0x0005AE88 File Offset: 0x00059088
		public int lutSize
		{
			get
			{
				return this.m_LutSize;
			}
			set
			{
				this.m_LutSize = Mathf.Clamp(value, 16, 65);
			}
		}

		// Token: 0x04000C10 RID: 3088
		public const int k_MinLutSize = 16;

		// Token: 0x04000C11 RID: 3089
		public const int k_MaxLutSize = 65;

		// Token: 0x04000C12 RID: 3090
		[Range(16f, 65f)]
		[SerializeField]
		private int m_LutSize;

		// Token: 0x04000C13 RID: 3091
		[FormerlySerializedAs("m_LutFormat")]
		public GradingLutFormat lutFormat;

		// Token: 0x04000C14 RID: 3092
		public PostProcessBufferFormat bufferFormat;
	}
}
