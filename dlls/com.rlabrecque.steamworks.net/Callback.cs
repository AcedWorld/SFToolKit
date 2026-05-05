using System;

namespace Steamworks
{
	// Token: 0x02000178 RID: 376
	public abstract class Callback
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600088B RID: 2187
		public abstract bool IsGameServer { get; }

		// Token: 0x0600088C RID: 2188
		internal abstract Type GetCallbackType();

		// Token: 0x0600088D RID: 2189
		internal abstract void OnRunCallback(IntPtr pvParam);

		// Token: 0x0600088E RID: 2190
		internal abstract void SetUnregistered();
	}
}
