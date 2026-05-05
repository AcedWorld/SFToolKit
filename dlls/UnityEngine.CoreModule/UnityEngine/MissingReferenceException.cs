using System;
using System.Runtime.Serialization;

namespace UnityEngine
{
	// Token: 0x0200025F RID: 607
	[Serializable]
	public class MissingReferenceException : SystemException
	{
		// Token: 0x0600198A RID: 6538 RVA: 0x0002ADD7 File Offset: 0x00028FD7
		public MissingReferenceException() : base("A Unity Runtime error occurred!")
		{
			base.HResult = -2147467261;
		}

		// Token: 0x0600198B RID: 6539 RVA: 0x0002ADF2 File Offset: 0x00028FF2
		public MissingReferenceException(string message) : base(message)
		{
			base.HResult = -2147467261;
		}

		// Token: 0x0600198C RID: 6540 RVA: 0x0002AE09 File Offset: 0x00029009
		public MissingReferenceException(string message, Exception innerException) : base(message, innerException)
		{
			base.HResult = -2147467261;
		}

		// Token: 0x0600198D RID: 6541 RVA: 0x0002AE21 File Offset: 0x00029021
		protected MissingReferenceException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x040008DF RID: 2271
		private const int Result = -2147467261;

		// Token: 0x040008E0 RID: 2272
		private string unityStackTrace;
	}
}
