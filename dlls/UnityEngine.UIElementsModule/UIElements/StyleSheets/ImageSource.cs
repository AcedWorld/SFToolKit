using System;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x0200048E RID: 1166
	internal struct ImageSource
	{
		// Token: 0x06002463 RID: 9315 RVA: 0x00097308 File Offset: 0x00095508
		public bool IsNull()
		{
			return this.texture == null && this.sprite == null && this.vectorImage == null && this.renderTexture == null;
		}

		// Token: 0x0400117D RID: 4477
		public Texture2D texture;

		// Token: 0x0400117E RID: 4478
		public Sprite sprite;

		// Token: 0x0400117F RID: 4479
		public VectorImage vectorImage;

		// Token: 0x04001180 RID: 4480
		public RenderTexture renderTexture;
	}
}
