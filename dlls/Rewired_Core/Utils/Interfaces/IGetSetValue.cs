using System;

namespace Rewired.Utils.Interfaces
{
	// Token: 0x02000535 RID: 1333
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IGetSetValue<T> : IGetValue<!0>, ISetValue<!0>
	{
	}
}
