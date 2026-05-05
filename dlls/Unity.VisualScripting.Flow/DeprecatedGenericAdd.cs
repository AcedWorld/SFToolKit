using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000CD RID: 205
	[UnitCategory("Math/Generic")]
	[UnitTitle("Add")]
	[RenamedFrom("Bolt.GenericAdd")]
	[RenamedFrom("Unity.VisualScripting.GenericAdd")]
	[Obsolete("Use the new \"Add (Math/Generic)\" node instead.")]
	public sealed class DeprecatedGenericAdd : Add<object>
	{
		// Token: 0x06000639 RID: 1593 RVA: 0x0000C825 File Offset: 0x0000AA25
		public override object Operation(object a, object b)
		{
			return OperatorUtility.Add(a, b);
		}
	}
}
