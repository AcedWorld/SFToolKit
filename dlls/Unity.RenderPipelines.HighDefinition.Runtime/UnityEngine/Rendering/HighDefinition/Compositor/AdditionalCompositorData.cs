using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition.Compositor
{
	// Token: 0x0200023C RID: 572
	[AddComponentMenu("")]
	internal class AdditionalCompositorData : MonoBehaviour
	{
		// Token: 0x06001018 RID: 4120 RVA: 0x0007C9A3 File Offset: 0x0007ABA3
		public void Init(List<CompositionFilter> layerFilters, bool clearAlpha)
		{
			this.layerFilters = new List<CompositionFilter>(layerFilters);
			this.clearAlpha = clearAlpha;
		}

		// Token: 0x06001019 RID: 4121 RVA: 0x0007C9B8 File Offset: 0x0007ABB8
		public void ResetData()
		{
			this.clearColorTexture = null;
			this.clearDepthTexture = null;
			this.clearAlpha = true;
			this.imageFitMode = BackgroundFitMode.Stretch;
			if (this.layerFilters != null)
			{
				this.layerFilters.Clear();
				this.layerFilters = null;
			}
			this.alphaMax = 1f;
			this.alphaMin = 0f;
		}

		// Token: 0x04001974 RID: 6516
		public Texture clearColorTexture;

		// Token: 0x04001975 RID: 6517
		public RenderTexture clearDepthTexture;

		// Token: 0x04001976 RID: 6518
		public bool clearAlpha = true;

		// Token: 0x04001977 RID: 6519
		public BackgroundFitMode imageFitMode;

		// Token: 0x04001978 RID: 6520
		public List<CompositionFilter> layerFilters;

		// Token: 0x04001979 RID: 6521
		public float alphaMax = 1f;

		// Token: 0x0400197A RID: 6522
		public float alphaMin;
	}
}
