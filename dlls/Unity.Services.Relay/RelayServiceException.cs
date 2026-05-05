using System;
using Unity.Services.Core;
using Unity.Services.Relay.Http;
using Unity.Services.Relay.Models;

namespace Unity.Services.Relay
{
	// Token: 0x0200000E RID: 14
	public class RelayServiceException : RequestFailedException
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002570 File Offset: 0x00000770
		// (set) Token: 0x06000029 RID: 41 RVA: 0x00002578 File Offset: 0x00000778
		public RelayExceptionReason Reason { get; private set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002581 File Offset: 0x00000781
		public ErrorResponseBody ApiError
		{
			get
			{
				HttpException<ErrorResponseBody> httpException = base.InnerException as HttpException<ErrorResponseBody>;
				if (httpException == null)
				{
					return null;
				}
				return httpException.ActualError;
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002599 File Offset: 0x00000799
		public RelayServiceException(RelayExceptionReason reason, string message, Exception innerException) : base((int)reason, message, innerException)
		{
			this.Reason = reason;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000025AB File Offset: 0x000007AB
		public RelayServiceException(RelayExceptionReason reason, string message) : base((int)reason, message)
		{
			this.Reason = reason;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000025BC File Offset: 0x000007BC
		public RelayServiceException(long errorCode, string message) : base((int)errorCode, message)
		{
			if (Enum.IsDefined(typeof(RelayExceptionReason), errorCode))
			{
				this.Reason = (RelayExceptionReason)errorCode;
				return;
			}
			this.Reason = RelayExceptionReason.Unknown;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000025F2 File Offset: 0x000007F2
		public RelayServiceException(Exception innerException) : base(15999, "Unknown Relay Service Exception", innerException)
		{
		}
	}
}
