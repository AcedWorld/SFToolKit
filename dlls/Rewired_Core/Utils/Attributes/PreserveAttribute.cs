using System;

namespace Rewired.Utils.Attributes
{
	// Token: 0x02000539 RID: 1337
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public class PreserveAttribute : Attribute
	{
	}
}
