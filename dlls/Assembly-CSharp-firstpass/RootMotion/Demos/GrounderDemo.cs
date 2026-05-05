using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200017F RID: 383
	public class GrounderDemo : MonoBehaviour
	{
		// Token: 0x06000B03 RID: 2819 RVA: 0x0004618C File Offset: 0x0004438C
		private void OnGUI()
		{
			if (GUILayout.Button("Biped", Array.Empty<GUILayoutOption>()))
			{
				this.Activate(0);
			}
			if (GUILayout.Button("Quadruped", Array.Empty<GUILayoutOption>()))
			{
				this.Activate(1);
			}
			if (GUILayout.Button("Mech", Array.Empty<GUILayoutOption>()))
			{
				this.Activate(2);
			}
			if (GUILayout.Button("Bot", Array.Empty<GUILayoutOption>()))
			{
				this.Activate(3);
			}
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x000461FC File Offset: 0x000443FC
		public void Activate(int index)
		{
			for (int i = 0; i < this.characters.Length; i++)
			{
				this.characters[i].SetActive(i == index);
			}
		}

		// Token: 0x04000AE6 RID: 2790
		public GameObject[] characters;
	}
}
