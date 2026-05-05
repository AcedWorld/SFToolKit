using System;
using UnityEngine.Scripting;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x0200001B RID: 27
	internal class WireMessage
	{
		// Token: 0x06000095 RID: 149 RVA: 0x000039C9 File Offset: 0x00001BC9
		[Preserve]
		public WireMessage()
		{
		}

		// Token: 0x04000089 RID: 137
		public string payload;

		// Token: 0x0400008A RID: 138
		public string version;
	}
}
