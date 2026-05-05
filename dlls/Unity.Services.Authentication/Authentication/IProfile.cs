using System;

namespace Unity.Services.Authentication
{
	// Token: 0x02000014 RID: 20
	internal interface IProfile
	{
		// Token: 0x14000012 RID: 18
		// (add) Token: 0x0600012B RID: 299
		// (remove) Token: 0x0600012C RID: 300
		event Action<ProfileEventArgs> ProfileChange;

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600012D RID: 301
		// (set) Token: 0x0600012E RID: 302
		string Current { get; set; }
	}
}
