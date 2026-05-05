using System;
using UnityEngine;

// Token: 0x0200002B RID: 43
[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
public class vToggleOptionAttribute : PropertyAttribute
{
	// Token: 0x0600009C RID: 156 RVA: 0x00007D9C File Offset: 0x00005F9C
	public vToggleOptionAttribute(string label = "", string falseValue = "No", string trueValue = "Yes")
	{
		this.label = label;
		this.falseValue = falseValue;
		this.trueValue = trueValue;
	}

	// Token: 0x040000E7 RID: 231
	public string label;

	// Token: 0x040000E8 RID: 232
	public string falseValue;

	// Token: 0x040000E9 RID: 233
	public string trueValue;
}
