using System;
using System.Collections.Generic;
using Unity.Services.Core;

namespace Unity.Services.Authentication
{
	// Token: 0x0200000A RID: 10
	public sealed class AuthenticationException : RequestFailedException
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000099 RID: 153 RVA: 0x000040AD File Offset: 0x000022AD
		public List<Notification> Notifications { get; }

		// Token: 0x0600009A RID: 154 RVA: 0x000040B5 File Offset: 0x000022B5
		private AuthenticationException(int errorCode, string message, Exception innerException = null, List<Notification> notifications = null) : base(errorCode, message, innerException)
		{
			this.Notifications = notifications;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000040C8 File Offset: 0x000022C8
		public static RequestFailedException Create(int errorCode, string message, Exception innerException = null)
		{
			return AuthenticationException.Create(errorCode, message, null, innerException);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000040D3 File Offset: 0x000022D3
		internal static RequestFailedException Create(int errorCode, string message, List<Notification> notifications, Exception innerException = null)
		{
			if (errorCode < AuthenticationErrorCodes.MinValue)
			{
				return new RequestFailedException(errorCode, message, innerException);
			}
			return new AuthenticationException(errorCode, message, innerException, notifications);
		}
	}
}
