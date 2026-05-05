using System;
using UnityEngine;

// Token: 0x0200002A RID: 42
[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class vSeparator : PropertyAttribute
{
	// Token: 0x06000099 RID: 153 RVA: 0x00007D39 File Offset: 0x00005F39
	public vSeparator()
	{
		this.fontSize = 15;
	}

	// Token: 0x0600009A RID: 154 RVA: 0x00007D51 File Offset: 0x00005F51
	public vSeparator(string label, string tooltip = "")
	{
		this.label = label;
		this.tooltip = tooltip;
		this.fontSize = 15;
	}

	// Token: 0x0600009B RID: 155 RVA: 0x00007D77 File Offset: 0x00005F77
	public vSeparator(string label, int fontSize, string tooltip = "")
	{
		this.label = label;
		this.tooltip = tooltip;
		this.fontSize = fontSize;
	}

	// Token: 0x040000E3 RID: 227
	public string label;

	// Token: 0x040000E4 RID: 228
	public string tooltip;

	// Token: 0x040000E5 RID: 229
	public string style;

	// Token: 0x040000E6 RID: 230
	public int fontSize = 10;
}
