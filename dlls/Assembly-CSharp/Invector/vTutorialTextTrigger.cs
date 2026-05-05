using System;
using UnityEngine;
using UnityEngine.UI;

namespace Invector
{
	// Token: 0x0200037A RID: 890
	public class vTutorialTextTrigger : MonoBehaviour
	{
		// Token: 0x0600120A RID: 4618 RVA: 0x0006009F File Offset: 0x0005E29F
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				this.EnableTutorialPanel();
			}
		}

		// Token: 0x0600120B RID: 4619 RVA: 0x000600B9 File Offset: 0x0005E2B9
		public void EnableTutorialPanel()
		{
			this.painel.SetActive(true);
			this._textUI.gameObject.SetActive(true);
			this._textUI.text = this.text;
		}

		// Token: 0x0600120C RID: 4620 RVA: 0x000600E9 File Offset: 0x0005E2E9
		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				this.DisableTutorialPanel();
			}
		}

		// Token: 0x0600120D RID: 4621 RVA: 0x00060103 File Offset: 0x0005E303
		public void DisableTutorialPanel()
		{
			this.painel.SetActive(false);
			this._textUI.gameObject.SetActive(false);
			this._textUI.text = " ";
		}

		// Token: 0x040017FA RID: 6138
		[TextArea(5, 3000)]
		[Multiline]
		public string text;

		// Token: 0x040017FB RID: 6139
		public Text _textUI;

		// Token: 0x040017FC RID: 6140
		public GameObject painel;
	}
}
