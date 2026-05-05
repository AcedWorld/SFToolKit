using System;
using System.Runtime.Serialization;

namespace UnityEngine
{
	// Token: 0x0200025D RID: 605
	[Serializable]
	public class MissingComponentException : SystemException
	{
		// Token: 0x06001982 RID: 6530 RVA: 0x0002ADD7 File Offset: 0x00028FD7
		public MissingComponentException() : base("A Unity Runtime error occurred!")
		{
			base.HResult = -2147467261;
		}

		// Token: 0x06001983 RID: 6531 RVA: 0x0002ADF2 File Offset: 0x00028FF2
		public MissingComponentException(string message) : base(message)
		{
			base.HResult = -2147467261;
		}

		// Token: 0x06001984 RID: 6532 RVA: 0x0002AE09 File Offset: 0x00029009
		public MissingComponentException(string message, Exception innerException) : base(message, innerException)
		{
			base.HResult = -2147467261;
		}

		// Token: 0x06001985 RID: 6533 RVA: 0x0002AE21 File Offset: 0x00029021
		protected MissingComponentException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x040008DB RID: 2267
		private const int Result = -2147467261;

		// Token: 0x040008DC RID: 2268
		private string unityStackTrace;
	}
}
