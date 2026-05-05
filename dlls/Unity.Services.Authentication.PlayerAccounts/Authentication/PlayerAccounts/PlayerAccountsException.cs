using System;
using Unity.Services.Core;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000005 RID: 5
	public sealed class PlayerAccountsException : RequestFailedException
	{
		// Token: 0x06000004 RID: 4 RVA: 0x000020C8 File Offset: 0x000002C8
		private PlayerAccountsException(int errorCode, string message, Exception innerException = null) : base(errorCode, message, innerException)
		{
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020D3 File Offset: 0x000002D3
		internal static PlayerAccountsException Create(int errorCode, string message, Exception innerException = null)
		{
			return new PlayerAccountsException(errorCode, message, innerException);
		}
	}
}
