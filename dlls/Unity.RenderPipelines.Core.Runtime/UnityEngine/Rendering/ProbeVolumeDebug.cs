using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200008D RID: 141
	internal class ProbeVolumeDebug : IDebugData
	{
		// Token: 0x060004BC RID: 1212 RVA: 0x000171F8 File Offset: 0x000153F8
		public ProbeVolumeDebug()
		{
			this.Init();
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x00017258 File Offset: 0x00015458
		private void Init()
		{
			this.drawProbes = false;
			this.drawBricks = false;
			this.drawCells = false;
			this.realtimeSubdivision = false;
			this.subdivisionCellUpdatePerFrame = 4;
			this.subdivisionDelayInSeconds = 1f;
			this.probeShading = DebugProbeShadingMode.SH;
			this.probeSize = 0.3f;
			this.subdivisionViewCullingDistance = 500f;
			this.probeCullingDistance = 200f;
			this.maxSubdivToVisualize = 7;
			this.minSubdivToVisualize = 0;
			this.exposureCompensation = 0f;
			this.drawVirtualOffsetPush = false;
			this.offsetSize = 0.025f;
			this.freezeStreaming = false;
			this.otherStateIndex = 0;
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x000172F4 File Offset: 0x000154F4
		public Action GetReset()
		{
			return delegate()
			{
				this.Init();
			};
		}

		// Token: 0x040002F8 RID: 760
		public bool drawProbes;

		// Token: 0x040002F9 RID: 761
		public bool drawBricks;

		// Token: 0x040002FA RID: 762
		public bool drawCells;

		// Token: 0x040002FB RID: 763
		public bool realtimeSubdivision;

		// Token: 0x040002FC RID: 764
		public int subdivisionCellUpdatePerFrame = 4;

		// Token: 0x040002FD RID: 765
		public float subdivisionDelayInSeconds = 1f;

		// Token: 0x040002FE RID: 766
		public DebugProbeShadingMode probeShading;

		// Token: 0x040002FF RID: 767
		public float probeSize = 0.3f;

		// Token: 0x04000300 RID: 768
		public float subdivisionViewCullingDistance = 500f;

		// Token: 0x04000301 RID: 769
		public float probeCullingDistance = 200f;

		// Token: 0x04000302 RID: 770
		public int maxSubdivToVisualize = 7;

		// Token: 0x04000303 RID: 771
		public int minSubdivToVisualize;

		// Token: 0x04000304 RID: 772
		public float exposureCompensation;

		// Token: 0x04000305 RID: 773
		public bool drawVirtualOffsetPush;

		// Token: 0x04000306 RID: 774
		public float offsetSize = 0.025f;

		// Token: 0x04000307 RID: 775
		public bool freezeStreaming;

		// Token: 0x04000308 RID: 776
		public int otherStateIndex;
	}
}
