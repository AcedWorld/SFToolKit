using System;
using UnityEngine;

// Token: 0x02000027 RID: 39
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class vHelpBoxAttribute : PropertyAttribute
{
	// Token: 0x06000096 RID: 150 RVA: 0x00007CEF File Offset: 0x00005EEF
	public vHelpBoxAttribute(string text, vHelpBoxAttribute.MessageType messageType = vHelpBoxAttribute.MessageType.None)
	{
		this.text = text;
		this.messageType = messageType;
	}

	// Token: 0x040000DA RID: 218
	public string text;

	// Token: 0x040000DB RID: 219
	public int lineSpace;

	// Token: 0x040000DC RID: 220
	public vHelpBoxAttribute.MessageType messageType;

	// Token: 0x02000028 RID: 40
	public enum MessageType
	{
		// Token: 0x040000DE RID: 222
		None,
		// Token: 0x040000DF RID: 223
		Info,
		// Token: 0x040000E0 RID: 224
		Warning
	}
}
