using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace WebSocketSharp.Net
{
	// Token: 0x02000022 RID: 34
	[Serializable]
	public class HttpListenerException : Win32Exception
	{
		// Token: 0x06000276 RID: 630 RVA: 0x0001066A File Offset: 0x0000E86A
		protected HttpListenerException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
		{
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00010676 File Offset: 0x0000E876
		public HttpListenerException()
		{
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00010680 File Offset: 0x0000E880
		public HttpListenerException(int errorCode) : base(errorCode)
		{
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0001068B File Offset: 0x0000E88B
		public HttpListenerException(int errorCode, string message) : base(errorCode, message)
		{
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600027A RID: 634 RVA: 0x00010698 File Offset: 0x0000E898
		public override int ErrorCode
		{
			get
			{
				return base.NativeErrorCode;
			}
		}
	}
}
