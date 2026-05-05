using System;
using UnityEngine.Scripting;

namespace Unity.Services.Authentication.Internal
{
	// Token: 0x02000059 RID: 89
	[RequireImplementors]
	internal interface IPlayerName
	{
		// Token: 0x17000064 RID: 100
		// (get) Token: 0x0600024B RID: 587
		string PlayerName { get; }

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x0600024C RID: 588
		// (remove) Token: 0x0600024D RID: 589
		event Action<string> PlayerNameChanged;
	}
}
