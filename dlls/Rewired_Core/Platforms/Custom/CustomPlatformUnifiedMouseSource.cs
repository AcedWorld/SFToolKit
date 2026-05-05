using System;
using UnityEngine;

namespace Rewired.Platforms.Custom
{
	// Token: 0x0200022A RID: 554
	public abstract class CustomPlatformUnifiedMouseSource : CustomPlatformUnifiedControllerSource
	{
		// Token: 0x060019C9 RID: 6601 RVA: 0x00015202 File Offset: 0x00013402
		public CustomPlatformUnifiedMouseSource() : base(4, 7)
		{
		}

		// Token: 0x17000639 RID: 1593
		// (get) Token: 0x060019CA RID: 6602
		public abstract Vector2 mousePosition { get; }
	}
}
