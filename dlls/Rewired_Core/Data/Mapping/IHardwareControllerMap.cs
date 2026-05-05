using System;

namespace Rewired.Data.Mapping
{
	// Token: 0x02000397 RID: 919
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	public interface IHardwareControllerMap
	{
		// Token: 0x06002555 RID: 9557
		string[] GetElementIdentifierNames();

		// Token: 0x06002556 RID: 9558
		int[] GetElementIdentifierIds();

		// Token: 0x06002557 RID: 9559
		bool ContainsElementIdentifier(int id);

		// Token: 0x06002558 RID: 9560
		int GetMappableElementIdentifierInfo(out string[] names, out int[] ids);
	}
}
