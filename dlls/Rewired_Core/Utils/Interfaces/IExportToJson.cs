using System;
using System.Text;

namespace Rewired.Utils.Interfaces
{
	// Token: 0x02000530 RID: 1328
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IExportToJson
	{
		// Token: 0x0600365F RID: 13919
		void WriteJson(StringBuilder stringBuilder, Action<StringBuilder, object> appendValueDelegate);
	}
}
