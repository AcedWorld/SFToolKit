using System;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x0200000A RID: 10
	public sealed class FieldsCloner : ReflectedCloner
	{
		// Token: 0x06000023 RID: 35 RVA: 0x0000244C File Offset: 0x0000064C
		protected override bool IncludeField(FieldInfo field)
		{
			return true;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000244F File Offset: 0x0000064F
		protected override bool IncludeProperty(PropertyInfo property)
		{
			return false;
		}
	}
}
