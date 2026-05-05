using System;
using Unity.Services.Core;
using Unity.Services.Lobbies.Http;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies
{
	// Token: 0x02000010 RID: 16
	public class LobbyServiceException : RequestFailedException
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600005B RID: 91 RVA: 0x000047E1 File Offset: 0x000029E1
		// (set) Token: 0x0600005C RID: 92 RVA: 0x000047E9 File Offset: 0x000029E9
		public LobbyExceptionReason Reason { get; private set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600005D RID: 93 RVA: 0x000047F2 File Offset: 0x000029F2
		public ErrorStatus ApiError
		{
			get
			{
				HttpException<ErrorStatus> httpException = base.InnerException as HttpException<ErrorStatus>;
				if (httpException == null)
				{
					return null;
				}
				return httpException.ActualError;
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000480A File Offset: 0x00002A0A
		public LobbyServiceException(LobbyExceptionReason reason, string message, Exception innerException) : base((int)reason, message, innerException)
		{
			this.Reason = reason;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000481C File Offset: 0x00002A1C
		public LobbyServiceException(LobbyExceptionReason reason, string message) : base((int)reason, message)
		{
			this.Reason = reason;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000482D File Offset: 0x00002A2D
		public LobbyServiceException(long errorCode, string message) : base((int)errorCode, message)
		{
			if (Enum.IsDefined(typeof(LobbyExceptionReason), errorCode))
			{
				this.Reason = (LobbyExceptionReason)errorCode;
				return;
			}
			this.Reason = LobbyExceptionReason.Unknown;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00004863 File Offset: 0x00002A63
		public LobbyServiceException(Exception innerException) : base(16999, "Unknown Lobby Service Exception", innerException)
		{
		}
	}
}
