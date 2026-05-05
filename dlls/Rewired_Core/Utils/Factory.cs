using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils
{
	// Token: 0x020004B0 RID: 1200
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class Factory
	{
		// Token: 0x060030B6 RID: 12470 RVA: 0x0002542C File Offset: 0x0002362C
		public static object CreateInstance(Type type, object[] args = null)
		{
			if (type == null)
			{
				return null;
			}
			if (type == typeof(SerializedObject))
			{
				return new SerializedObject(null, SerializedObject.ObjectType.List, (args != null && args.Length != 0) ? ((int)args[0]) : 0);
			}
			return Activator.CreateInstance(type);
		}
	}
}
