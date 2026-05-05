using System;
using System.Xml;

namespace Rewired.Utils.Interfaces
{
	// Token: 0x0200052F RID: 1327
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IExportToXml
	{
		// Token: 0x17000C22 RID: 3106
		// (get) Token: 0x0600365D RID: 13917
		bool writesOwnElementTag { get; }

		// Token: 0x0600365E RID: 13918
		void WriteXml(XmlWriter writer);
	}
}
