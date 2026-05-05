using System;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004D9 RID: 1241
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class StopwatchBase
	{
		// Token: 0x17000B3F RID: 2879
		// (get) Token: 0x060031C1 RID: 12737
		// (set) Token: 0x060031C2 RID: 12738
		public abstract double offsetSeconds { get; set; }

		// Token: 0x17000B40 RID: 2880
		// (get) Token: 0x060031C3 RID: 12739
		// (set) Token: 0x060031C4 RID: 12740
		public abstract long offsetTicks { get; set; }

		// Token: 0x17000B41 RID: 2881
		// (get) Token: 0x060031C5 RID: 12741
		public abstract double elapsedSeconds { get; }

		// Token: 0x17000B42 RID: 2882
		// (get) Token: 0x060031C6 RID: 12742
		public abstract double elapsedSecondsRaw { get; }

		// Token: 0x17000B43 RID: 2883
		// (get) Token: 0x060031C7 RID: 12743
		public abstract long elapsedMilliseconds { get; }

		// Token: 0x17000B44 RID: 2884
		// (get) Token: 0x060031C8 RID: 12744
		public abstract long elapsedMillisecondsRaw { get; }

		// Token: 0x17000B45 RID: 2885
		// (get) Token: 0x060031C9 RID: 12745
		public abstract long elapsedTicks { get; }

		// Token: 0x17000B46 RID: 2886
		// (get) Token: 0x060031CA RID: 12746
		public abstract long elapsedTicksRaw { get; }

		// Token: 0x17000B47 RID: 2887
		// (get) Token: 0x060031CB RID: 12747
		public abstract bool isRunning { get; }

		// Token: 0x060031CC RID: 12748
		public abstract void Stop();

		// Token: 0x060031CD RID: 12749
		public abstract void Start();

		// Token: 0x060031CE RID: 12750
		public abstract void Reset();
	}
}
