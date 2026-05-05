using System;
using UnityEngine;
using UnityEngine.Events;

namespace Unity.Services.Authentication.Components
{
	// Token: 0x02000070 RID: 112
	[Serializable]
	public class PlayerAuthenticationEvents
	{
		// Token: 0x04000164 RID: 356
		[SerializeField]
		public UnityEvent SignedIn = new UnityEvent();

		// Token: 0x04000165 RID: 357
		[SerializeField]
		public UnityEvent<Exception> SignInFailed = new UnityEvent<Exception>();

		// Token: 0x04000166 RID: 358
		[SerializeField]
		public UnityEvent SignedOut = new UnityEvent();

		// Token: 0x04000167 RID: 359
		[SerializeField]
		public UnityEvent Expired = new UnityEvent();

		// Token: 0x04000168 RID: 360
		[SerializeField]
		public UnityEvent<SignInCodeInfo> SignInCodeReceived = new UnityEvent<SignInCodeInfo>();

		// Token: 0x04000169 RID: 361
		[SerializeField]
		public UnityEvent SignInCodeExpired = new UnityEvent();
	}
}
