using System;

namespace Unity.Services.Authentication
{
	// Token: 0x02000018 RID: 24
	public sealed class Identity
	{
		// Token: 0x0600013F RID: 319 RVA: 0x00004CBC File Offset: 0x00002EBC
		internal Identity(ExternalIdentity externalIdentity)
		{
			if (externalIdentity != null)
			{
				this.TypeId = externalIdentity.ProviderId;
				this.UserId = externalIdentity.ExternalId;
			}
		}

		// Token: 0x04000059 RID: 89
		public string TypeId;

		// Token: 0x0400005A RID: 90
		public string UserId;
	}
}
