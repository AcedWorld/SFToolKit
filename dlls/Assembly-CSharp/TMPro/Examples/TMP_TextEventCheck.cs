using System;
using UnityEngine;
using UnityEngine.Events;

namespace TMPro.Examples
{
	// Token: 0x02000246 RID: 582
	public class TMP_TextEventCheck : MonoBehaviour
	{
		// Token: 0x06000917 RID: 2327 RVA: 0x0003F500 File Offset: 0x0003D700
		private void OnEnable()
		{
			if (this.TextEventHandler != null)
			{
				this.m_TextComponent = this.TextEventHandler.GetComponent<TMP_Text>();
				this.TextEventHandler.onCharacterSelection.AddListener(new UnityAction<char, int>(this.OnCharacterSelection));
				this.TextEventHandler.onSpriteSelection.AddListener(new UnityAction<char, int>(this.OnSpriteSelection));
				this.TextEventHandler.onWordSelection.AddListener(new UnityAction<string, int, int>(this.OnWordSelection));
				this.TextEventHandler.onLineSelection.AddListener(new UnityAction<string, int, int>(this.OnLineSelection));
				this.TextEventHandler.onLinkSelection.AddListener(new UnityAction<string, string, int>(this.OnLinkSelection));
			}
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x0003F5BC File Offset: 0x0003D7BC
		private void OnDisable()
		{
			if (this.TextEventHandler != null)
			{
				this.TextEventHandler.onCharacterSelection.RemoveListener(new UnityAction<char, int>(this.OnCharacterSelection));
				this.TextEventHandler.onSpriteSelection.RemoveListener(new UnityAction<char, int>(this.OnSpriteSelection));
				this.TextEventHandler.onWordSelection.RemoveListener(new UnityAction<string, int, int>(this.OnWordSelection));
				this.TextEventHandler.onLineSelection.RemoveListener(new UnityAction<string, int, int>(this.OnLineSelection));
				this.TextEventHandler.onLinkSelection.RemoveListener(new UnityAction<string, string, int>(this.OnLinkSelection));
			}
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x0003F666 File Offset: 0x0003D866
		private void OnCharacterSelection(char c, int index)
		{
			Debug.Log(string.Concat(new string[]
			{
				"Character [",
				c.ToString(),
				"] at Index: ",
				index.ToString(),
				" has been selected."
			}));
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x0003F6A4 File Offset: 0x0003D8A4
		private void OnSpriteSelection(char c, int index)
		{
			Debug.Log(string.Concat(new string[]
			{
				"Sprite [",
				c.ToString(),
				"] at Index: ",
				index.ToString(),
				" has been selected."
			}));
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x0003F6E4 File Offset: 0x0003D8E4
		private void OnWordSelection(string word, int firstCharacterIndex, int length)
		{
			Debug.Log(string.Concat(new string[]
			{
				"Word [",
				word,
				"] with first character index of ",
				firstCharacterIndex.ToString(),
				" and length of ",
				length.ToString(),
				" has been selected."
			}));
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x0003F73C File Offset: 0x0003D93C
		private void OnLineSelection(string lineText, int firstCharacterIndex, int length)
		{
			Debug.Log(string.Concat(new string[]
			{
				"Line [",
				lineText,
				"] with first character index of ",
				firstCharacterIndex.ToString(),
				" and length of ",
				length.ToString(),
				" has been selected."
			}));
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x0003F794 File Offset: 0x0003D994
		private void OnLinkSelection(string linkID, string linkText, int linkIndex)
		{
			if (this.m_TextComponent != null)
			{
				TMP_LinkInfo[] linkInfo = this.m_TextComponent.textInfo.linkInfo;
			}
			Debug.Log(string.Concat(new string[]
			{
				"Link Index: ",
				linkIndex.ToString(),
				" with ID [",
				linkID,
				"] and Text \"",
				linkText,
				"\" has been selected."
			}));
		}

		// Token: 0x04000F94 RID: 3988
		public TMP_TextEventHandler TextEventHandler;

		// Token: 0x04000F95 RID: 3989
		private TMP_Text m_TextComponent;
	}
}
