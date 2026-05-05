using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x02000023 RID: 35
	public class DemoGUIMessage : MonoBehaviour
	{
		// Token: 0x060000BA RID: 186 RVA: 0x00006507 File Offset: 0x00004707
		private void OnGUI()
		{
			GUI.color = this.color;
			GUILayout.Label(this.text, Array.Empty<GUILayoutOption>());
			GUI.color = Color.white;
		}

		// Token: 0x040000E7 RID: 231
		public string text;

		// Token: 0x040000E8 RID: 232
		public Color color = Color.white;
	}
}
