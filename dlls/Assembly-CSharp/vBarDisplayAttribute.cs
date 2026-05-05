using System;
using UnityEngine;

// Token: 0x02000024 RID: 36
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
public class vBarDisplayAttribute : PropertyAttribute
{
	// Token: 0x06000092 RID: 146 RVA: 0x00007C4E File Offset: 0x00005E4E
	public vBarDisplayAttribute(string maxValueProperty, bool showJuntInPlayMode = false)
	{
		this.maxValueProperty = maxValueProperty;
		this.showJuntInPlayMode = showJuntInPlayMode;
	}

	// Token: 0x040000D3 RID: 211
	public readonly string maxValueProperty;

	// Token: 0x040000D4 RID: 212
	public readonly bool showJuntInPlayMode;
}
