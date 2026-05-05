using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000364 RID: 868
	[HelpURL("UIE-tss")]
	[Serializable]
	public class ThemeStyleSheet : StyleSheet
	{
		// Token: 0x06001CDB RID: 7387 RVA: 0x00070083 File Offset: 0x0006E283
		internal override void OnEnable()
		{
			base.isDefaultStyleSheet = true;
			base.OnEnable();
		}
	}
}
