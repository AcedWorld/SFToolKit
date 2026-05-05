using System;

namespace Rewired.Utils.Attributes
{
	// Token: 0x0200053B RID: 1339
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class SerializationTypeAttribute : Attribute
	{
		// Token: 0x17000C27 RID: 3111
		// (get) Token: 0x0600366E RID: 13934 RVA: 0x0002A7AB File Offset: 0x000289AB
		public SerializationTypeAttribute.SerializationType serializationType
		{
			get
			{
				return this._serializationType;
			}
		}

		// Token: 0x0600366F RID: 13935 RVA: 0x0002A7B3 File Offset: 0x000289B3
		public SerializationTypeAttribute(SerializationTypeAttribute.SerializationType A_1)
		{
			this._serializationType = A_1;
		}

		// Token: 0x04001C95 RID: 7317
		private SerializationTypeAttribute.SerializationType _serializationType;

		// Token: 0x0200053C RID: 1340
		public enum SerializationType
		{
			// Token: 0x04001C97 RID: 7319
			Default,
			// Token: 0x04001C98 RID: 7320
			Object
		}
	}
}
