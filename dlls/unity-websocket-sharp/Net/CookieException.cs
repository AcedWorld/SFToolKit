using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x0200002C RID: 44
	[Serializable]
	internal class CookieException : FormatException, ISerializable
	{
		// Token: 0x06000338 RID: 824 RVA: 0x0000F27B File Offset: 0x0000D47B
		internal CookieException(string message) : base(message)
		{
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0000F284 File Offset: 0x0000D484
		internal CookieException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000F28E File Offset: 0x0000D48E
		protected CookieException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
		{
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0000F298 File Offset: 0x0000D498
		public CookieException()
		{
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0000F2A0 File Offset: 0x0000D4A0
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			base.GetObjectData(serializationInfo, streamingContext);
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0000F2AA File Offset: 0x0000D4AA
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter, SerializationFormatter = true)]
		void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			base.GetObjectData(serializationInfo, streamingContext);
		}
	}
}
