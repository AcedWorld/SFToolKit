using System;

namespace Steamworks
{
	// Token: 0x0200017A RID: 378
	public abstract class CallResult
	{
		// Token: 0x0600089D RID: 2205
		internal abstract Type GetCallbackType();

		// Token: 0x0600089E RID: 2206
		internal abstract void OnRunCallResult(IntPtr pvParam, bool bFailed, ulong hSteamAPICall);

		// Token: 0x0600089F RID: 2207
		internal abstract void SetUnregistered();
	}
}
