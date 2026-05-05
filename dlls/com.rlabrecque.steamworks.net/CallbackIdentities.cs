using System;

namespace Steamworks
{
	// Token: 0x0200017C RID: 380
	internal class CallbackIdentities
	{
		// Token: 0x060008AE RID: 2222 RVA: 0x0000CC88 File Offset: 0x0000AE88
		public static int GetCallbackIdentity(Type callbackStruct)
		{
			object[] customAttributes = callbackStruct.GetCustomAttributes(typeof(CallbackIdentityAttribute), false);
			int num = 0;
			if (num >= customAttributes.Length)
			{
				throw new Exception("Callback number not found for struct " + ((callbackStruct != null) ? callbackStruct.ToString() : null));
			}
			return ((CallbackIdentityAttribute)customAttributes[num]).Identity;
		}
	}
}
