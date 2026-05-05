using System;
using Unity.Services.Core.Internal;
using UnityEngine.Scripting;

namespace Unity.Services.Core.Configuration.Internal
{
	// Token: 0x02000023 RID: 35
	[RequireImplementors]
	public interface IExternalUserId : IServiceComponent
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000061 RID: 97
		string UserId { get; }

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000062 RID: 98
		// (remove) Token: 0x06000063 RID: 99
		event Action<string> UserIdChanged;
	}
}
