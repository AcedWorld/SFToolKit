using System;
using System.Collections;
using UnityEngine;

namespace TMPro.Examples
{
	// Token: 0x02000239 RID: 569
	public class TextConsoleSimulator : MonoBehaviour
	{
		// Token: 0x060008E3 RID: 2275 RVA: 0x0003E0AA File Offset: 0x0003C2AA
		private void Awake()
		{
			this.m_TextComponent = base.gameObject.GetComponent<TMP_Text>();
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x0003E0BD File Offset: 0x0003C2BD
		private void Start()
		{
			base.StartCoroutine(this.RevealCharacters(this.m_TextComponent));
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x0003E0D2 File Offset: 0x0003C2D2
		private void OnEnable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Add(new Action<Object>(this.ON_TEXT_CHANGED));
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x0003E0EA File Offset: 0x0003C2EA
		private void OnDisable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(new Action<Object>(this.ON_TEXT_CHANGED));
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x0003E102 File Offset: 0x0003C302
		private void ON_TEXT_CHANGED(Object obj)
		{
			this.hasTextChanged = true;
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x0003E10B File Offset: 0x0003C30B
		private IEnumerator RevealCharacters(TMP_Text textComponent)
		{
			textComponent.ForceMeshUpdate(false, false);
			TMP_TextInfo textInfo = textComponent.textInfo;
			int totalVisibleCharacters = textInfo.characterCount;
			int visibleCount = 0;
			for (;;)
			{
				if (this.hasTextChanged)
				{
					totalVisibleCharacters = textInfo.characterCount;
					this.hasTextChanged = false;
				}
				if (visibleCount > totalVisibleCharacters)
				{
					yield return new WaitForSeconds(1f);
					visibleCount = 0;
				}
				textComponent.maxVisibleCharacters = visibleCount;
				visibleCount++;
				yield return null;
			}
			yield break;
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0003E121 File Offset: 0x0003C321
		private IEnumerator RevealWords(TMP_Text textComponent)
		{
			textComponent.ForceMeshUpdate(false, false);
			int totalWordCount = textComponent.textInfo.wordCount;
			int totalVisibleCharacters = textComponent.textInfo.characterCount;
			int counter = 0;
			int visibleCount = 0;
			for (;;)
			{
				int num = counter % (totalWordCount + 1);
				if (num == 0)
				{
					visibleCount = 0;
				}
				else if (num < totalWordCount)
				{
					visibleCount = textComponent.textInfo.wordInfo[num - 1].lastCharacterIndex + 1;
				}
				else if (num == totalWordCount)
				{
					visibleCount = totalVisibleCharacters;
				}
				textComponent.maxVisibleCharacters = visibleCount;
				if (visibleCount >= totalVisibleCharacters)
				{
					yield return new WaitForSeconds(1f);
				}
				counter++;
				yield return new WaitForSeconds(0.1f);
			}
			yield break;
		}

		// Token: 0x04000F3D RID: 3901
		private TMP_Text m_TextComponent;

		// Token: 0x04000F3E RID: 3902
		private bool hasTextChanged;
	}
}
