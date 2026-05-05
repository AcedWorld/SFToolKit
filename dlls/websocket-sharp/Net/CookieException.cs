using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace WebSocketSharp.Net
{
	// Token: 0x0200001C RID: 28
	[Serializable]
	public class CookieException : FormatException, ISerializable
	{
		// Token: 0x060001FC RID: 508 RVA: 0x0000DA86 File Offset: 0x0000BC86
		internal CookieException(string message) : base(message)
		{
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000DA91 File Offset: 0x0000BC91
		internal CookieException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000DA9D File Offset: 0x0000BC9D
		protected CookieException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
		{
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0000DAA9 File Offset: 0x0000BCA9
		public CookieException()
		{
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000DAB3 File Offset: 0x0000BCB3
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			base.GetObjectData(serializationInfo, streamingContext);
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0000DAB3 File Offset: 0x0000BCB3
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter, SerializationFormatter = true)]
		void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			base.GetObjectData(serializationInfo, streamingContext);
		}
	}
}
