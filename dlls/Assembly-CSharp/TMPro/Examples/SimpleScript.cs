using System;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000234 RID: 564
	public class SimpleScript : MonoBehaviour
	{
		// Token: 0x060008CC RID: 2252 RVA: 0x0003D7A4 File Offset: 0x0003B9A4
		private void Start()
		{
			this.m_textMeshPro = base.gameObject.AddComponent<TextMeshPro>();
			this.m_textMeshPro.autoSizeTextContainer = true;
			this.m_textMeshPro.fontSize = 48f;
			this.m_textMeshPro.alignment = TextAlignmentOptions.Center;
			this.m_textMeshPro.enableWordWrapping = false;
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x0003D7FA File Offset: 0x0003B9FA
		private void Update()
		{
			this.m_textMeshPro.SetText("The <#0050FF>count is: </color>{0:2}", this.m_frame % 1000f);
			this.m_frame += 1f * Time.deltaTime;
		}

		// Token: 0x04000F28 RID: 3880
		private TextMeshPro m_textMeshPro;

		// Token: 0x04000F29 RID: 3881
		private const string label = "The <#0050FF>count is: </color>{0:2}";

		// Token: 0x04000F2A RID: 3882
		private float m_frame;
	}
}
