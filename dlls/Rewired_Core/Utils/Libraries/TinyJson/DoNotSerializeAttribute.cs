using System;

namespace Rewired.Utils.Libraries.TinyJson
{
	// Token: 0x020004B8 RID: 1208
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	public class DoNotSerializeAttribute : Attribute
	{
	}
}
