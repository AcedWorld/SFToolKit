using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000EF RID: 239
	public abstract class OperatorException : InvalidCastException
	{
		// Token: 0x06000644 RID: 1604 RVA: 0x0001C2F9 File Offset: 0x0001A4F9
		protected OperatorException()
		{
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x0001C301 File Offset: 0x0001A501
		protected OperatorException(string message) : base(message)
		{
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x0001C30A File Offset: 0x0001A50A
		protected OperatorException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
