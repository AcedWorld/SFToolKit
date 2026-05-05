using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200005B RID: 91
	public class InvalidConversionException : InvalidCastException
	{
		// Token: 0x0600028E RID: 654 RVA: 0x00006665 File Offset: 0x00004865
		public InvalidConversionException()
		{
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0000666D File Offset: 0x0000486D
		public InvalidConversionException(string message) : base(message)
		{
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00006676 File Offset: 0x00004876
		public InvalidConversionException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
