using System;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x0200048C RID: 1164
	[Serializable]
	internal struct ScalableImage
	{
		// Token: 0x06002462 RID: 9314 RVA: 0x000972C4 File Offset: 0x000954C4
		public override string ToString()
		{
			return string.Format("{0}: {1}, {2}: {3}", new object[]
			{
				"normalImage",
				this.normalImage,
				"highResolutionImage",
				this.highResolutionImage
			});
		}

		// Token: 0x04001179 RID: 4473
		public Texture2D normalImage;

		// Token: 0x0400117A RID: 4474
		public Texture2D highResolutionImage;
	}
}
