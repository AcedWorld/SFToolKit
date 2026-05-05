using System;
using System.Runtime.Serialization;

namespace UnityEngine
{
	// Token: 0x0200025E RID: 606
	[Serializable]
	public class UnassignedReferenceException : SystemException
	{
		// Token: 0x06001986 RID: 6534 RVA: 0x0002ADD7 File Offset: 0x00028FD7
		public UnassignedReferenceException() : base("A Unity Runtime error occurred!")
		{
			base.HResult = -2147467261;
		}

		// Token: 0x06001987 RID: 6535 RVA: 0x0002ADF2 File Offset: 0x00028FF2
		public UnassignedReferenceException(string message) : base(message)
		{
			base.HResult = -2147467261;
		}

		// Token: 0x06001988 RID: 6536 RVA: 0x0002AE09 File Offset: 0x00029009
		public UnassignedReferenceException(string message, Exception innerException) : base(message, innerException)
		{
			base.HResult = -2147467261;
		}

		// Token: 0x06001989 RID: 6537 RVA: 0x0002AE21 File Offset: 0x00029021
		protected UnassignedReferenceException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x040008DD RID: 2269
		private const int Result = -2147467261;

		// Token: 0x040008DE RID: 2270
		private string unityStackTrace;
	}
}
