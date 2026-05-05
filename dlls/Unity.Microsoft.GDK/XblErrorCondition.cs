using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000075 RID: 117
	[MovedFrom("Unity.GameCore")]
	public enum XblErrorCondition : uint
	{
		// Token: 0x04000121 RID: 289
		NoError,
		// Token: 0x04000122 RID: 290
		GenericError,
		// Token: 0x04000123 RID: 291
		GenericOutOfRange,
		// Token: 0x04000124 RID: 292
		Auth,
		// Token: 0x04000125 RID: 293
		Network,
		// Token: 0x04000126 RID: 294
		HttpGeneric,
		// Token: 0x04000127 RID: 295
		Http304NotModified,
		// Token: 0x04000128 RID: 296
		Http404NotFound,
		// Token: 0x04000129 RID: 297
		Http412PreconditionFailed,
		// Token: 0x0400012A RID: 298
		Http429TooManyRequests,
		// Token: 0x0400012B RID: 299
		HttpServiceTimeout,
		// Token: 0x0400012C RID: 300
		Rta
	}
}
