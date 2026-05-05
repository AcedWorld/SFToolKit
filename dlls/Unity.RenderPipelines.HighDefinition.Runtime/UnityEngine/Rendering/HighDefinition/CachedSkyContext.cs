using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001EB RID: 491
	internal struct CachedSkyContext
	{
		// Token: 0x06000EBC RID: 3772 RVA: 0x00074C6D File Offset: 0x00072E6D
		public void Reset()
		{
			this.hash = 0;
			this.refCount = 0;
			if (this.renderingContext != null)
			{
				this.renderingContext.Reset();
			}
		}

		// Token: 0x06000EBD RID: 3773 RVA: 0x00074C90 File Offset: 0x00072E90
		public void Cleanup()
		{
			this.Reset();
			if (this.renderingContext != null)
			{
				this.renderingContext.Cleanup();
				this.renderingContext = null;
			}
		}

		// Token: 0x04001769 RID: 5993
		public Type type;

		// Token: 0x0400176A RID: 5994
		public SkyRenderingContext renderingContext;

		// Token: 0x0400176B RID: 5995
		public int hash;

		// Token: 0x0400176C RID: 5996
		public int refCount;
	}
}
