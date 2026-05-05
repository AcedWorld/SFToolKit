using System;

namespace Unity.Services.Authentication
{
	// Token: 0x02000016 RID: 22
	internal class ProfileEventArgs : EventArgs
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00004C14 File Offset: 0x00002E14
		public string Profile { get; }

		// Token: 0x06000136 RID: 310 RVA: 0x00004C1C File Offset: 0x00002E1C
		public ProfileEventArgs(string profile)
		{
			this.Profile = profile;
		}
	}
}
