using System;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000242 RID: 578
	public class TMP_ExampleScript_01 : MonoBehaviour
	{
		// Token: 0x0600090F RID: 2319 RVA: 0x0003F068 File Offset: 0x0003D268
		private void Awake()
		{
			if (this.ObjectType == TMP_ExampleScript_01.objectType.TextMeshPro)
			{
				this.m_text = (base.GetComponent<TextMeshPro>() ?? base.gameObject.AddComponent<TextMeshPro>());
			}
			else
			{
				this.m_text = (base.GetComponent<TextMeshProUGUI>() ?? base.gameObject.AddComponent<TextMeshProUGUI>());
			}
			this.m_text.font = Resources.Load<TMP_FontAsset>("Fonts & Materials/Anton SDF");
			this.m_text.fontSharedMaterial = Resources.Load<Material>("Fonts & Materials/Anton SDF - Drop Shadow");
			this.m_text.fontSize = 120f;
			this.m_text.text = "A <#0080ff>simple</color> line of text.";
			Vector2 preferredValues = this.m_text.GetPreferredValues(float.PositiveInfinity, float.PositiveInfinity);
			this.m_text.rectTransform.sizeDelta = new Vector2(preferredValues.x, preferredValues.y);
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x0003F136 File Offset: 0x0003D336
		private void Update()
		{
			if (!this.isStatic)
			{
				this.m_text.SetText("The count is <#0080ff>{0}</color>", (float)(this.count % 1000));
				this.count++;
			}
		}

		// Token: 0x04000F7D RID: 3965
		public TMP_ExampleScript_01.objectType ObjectType;

		// Token: 0x04000F7E RID: 3966
		public bool isStatic;

		// Token: 0x04000F7F RID: 3967
		private TMP_Text m_text;

		// Token: 0x04000F80 RID: 3968
		private const string k_label = "The count is <#0080ff>{0}</color>";

		// Token: 0x04000F81 RID: 3969
		private int count;

		// Token: 0x02000243 RID: 579
		public enum objectType
		{
			// Token: 0x04000F83 RID: 3971
			TextMeshPro,
			// Token: 0x04000F84 RID: 3972
			TextMeshProUGUI
		}
	}
}
