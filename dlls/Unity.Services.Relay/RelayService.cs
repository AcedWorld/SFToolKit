using System;

namespace Unity.Services.Relay
{
	// Token: 0x02000012 RID: 18
	public static class RelayService
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002605 File Offset: 0x00000805
		public static IRelayService Instance
		{
			get
			{
				if (RelayService.service != null)
				{
					return RelayService.service;
				}
				IRelayServiceSdk instance = RelayServiceSdk.Instance;
				if (instance == null)
				{
					throw new InvalidOperationException("Attempting to call Relay Services requires initializing Core Registry. Call 'UnityServices.InitializeAsync' first!");
				}
				RelayService.service = new WrappedRelayService(instance);
				return RelayService.service;
			}
		}

		// Token: 0x04000045 RID: 69
		private static IRelayService service;
	}
}
