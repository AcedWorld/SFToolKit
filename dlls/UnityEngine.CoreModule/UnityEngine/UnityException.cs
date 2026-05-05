using System;
using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x0200025C RID: 604
	[RequiredByNativeCode]
	[Serializable]
	public class UnityException : SystemException
	{
		// Token: 0x0600197E RID: 6526 RVA: 0x0002ADD7 File Offset: 0x00028FD7
		public UnityException() : base("A Unity Runtime error occurred!")
		{
			base.HResult = -2147467261;
		}

		// Token: 0x0600197F RID: 6527 RVA: 0x0002ADF2 File Offset: 0x00028FF2
		public UnityException(string message) : base(message)
		{
			base.HResult = -2147467261;
		}

		// Token: 0x06001980 RID: 6528 RVA: 0x0002AE09 File Offset: 0x00029009
		public UnityException(string message, Exception innerException) : base(message, innerException)
		{
			base.HResult = -2147467261;
		}

		// Token: 0x06001981 RID: 6529 RVA: 0x0002AE21 File Offset: 0x00029021
		protected UnityException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x040008D9 RID: 2265
		private const int Result = -2147467261;

		// Token: 0x040008DA RID: 2266
		private string unityStackTrace;
	}
}
