using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace TMPro
{
	// Token: 0x02000220 RID: 544
	public class TMP_TextEventHandler : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600088A RID: 2186 RVA: 0x0003BD5C File Offset: 0x00039F5C
		// (set) Token: 0x0600088B RID: 2187 RVA: 0x0003BD64 File Offset: 0x00039F64
		public TMP_TextEventHandler.CharacterSelectionEvent onCharacterSelection
		{
			get
			{
				return this.m_OnCharacterSelection;
			}
			set
			{
				this.m_OnCharacterSelection = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600088C RID: 2188 RVA: 0x0003BD6D File Offset: 0x00039F6D
		// (set) Token: 0x0600088D RID: 2189 RVA: 0x0003BD75 File Offset: 0x00039F75
		public TMP_TextEventHandler.SpriteSelectionEvent onSpriteSelection
		{
			get
			{
				return this.m_OnSpriteSelection;
			}
			set
			{
				this.m_OnSpriteSelection = value;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600088E RID: 2190 RVA: 0x0003BD7E File Offset: 0x00039F7E
		// (set) Token: 0x0600088F RID: 2191 RVA: 0x0003BD86 File Offset: 0x00039F86
		public TMP_TextEventHandler.WordSelectionEvent onWordSelection
		{
			get
			{
				return this.m_OnWordSelection;
			}
			set
			{
				this.m_OnWordSelection = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000890 RID: 2192 RVA: 0x0003BD8F File Offset: 0x00039F8F
		// (set) Token: 0x06000891 RID: 2193 RVA: 0x0003BD97 File Offset: 0x00039F97
		public TMP_TextEventHandler.LineSelectionEvent onLineSelection
		{
			get
			{
				return this.m_OnLineSelection;
			}
			set
			{
				this.m_OnLineSelection = value;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000892 RID: 2194 RVA: 0x0003BDA0 File Offset: 0x00039FA0
		// (set) Token: 0x06000893 RID: 2195 RVA: 0x0003BDA8 File Offset: 0x00039FA8
		public TMP_TextEventHandler.LinkSelectionEvent onLinkSelection
		{
			get
			{
				return this.m_OnLinkSelection;
			}
			set
			{
				this.m_OnLinkSelection = value;
			}
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x0003BDB4 File Offset: 0x00039FB4
		private void Awake()
		{
			this.m_TextComponent = base.gameObject.GetComponent<TMP_Text>();
			if (this.m_TextComponent.GetType() == typeof(TextMeshProUGUI))
			{
				this.m_Canvas = base.gameObject.GetComponentInParent<Canvas>();
				if (this.m_Canvas != null)
				{
					if (this.m_Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
					{
						this.m_Camera = null;
						return;
					}
					this.m_Camera = this.m_Canvas.worldCamera;
					return;
				}
			}
			else
			{
				this.m_Camera = Camera.main;
			}
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x0003BE40 File Offset: 0x0003A040
		private void LateUpdate()
		{
			if (TMP_TextUtilities.IsIntersectingRectTransform(this.m_TextComponent.rectTransform, Input.mousePosition, this.m_Camera))
			{
				int num = TMP_TextUtilities.FindIntersectingCharacter(this.m_TextComponent, Input.mousePosition, this.m_Camera, true);
				if (num != -1 && num != this.m_lastCharIndex)
				{
					this.m_lastCharIndex = num;
					TMP_TextElementType elementType = this.m_TextComponent.textInfo.characterInfo[num].elementType;
					if (elementType == TMP_TextElementType.Character)
					{
						this.SendOnCharacterSelection(this.m_TextComponent.textInfo.characterInfo[num].character, num);
					}
					else if (elementType == TMP_TextElementType.Sprite)
					{
						this.SendOnSpriteSelection(this.m_TextComponent.textInfo.characterInfo[num].character, num);
					}
				}
				int num2 = TMP_TextUtilities.FindIntersectingWord(this.m_TextComponent, Input.mousePosition, this.m_Camera);
				if (num2 != -1 && num2 != this.m_lastWordIndex)
				{
					this.m_lastWordIndex = num2;
					TMP_WordInfo tmp_WordInfo = this.m_TextComponent.textInfo.wordInfo[num2];
					this.SendOnWordSelection(tmp_WordInfo.GetWord(), tmp_WordInfo.firstCharacterIndex, tmp_WordInfo.characterCount);
				}
				int num3 = TMP_TextUtilities.FindIntersectingLine(this.m_TextComponent, Input.mousePosition, this.m_Camera);
				if (num3 != -1 && num3 != this.m_lastLineIndex)
				{
					this.m_lastLineIndex = num3;
					TMP_LineInfo tmp_LineInfo = this.m_TextComponent.textInfo.lineInfo[num3];
					char[] array = new char[tmp_LineInfo.characterCount];
					int num4 = 0;
					while (num4 < tmp_LineInfo.characterCount && num4 < this.m_TextComponent.textInfo.characterInfo.Length)
					{
						array[num4] = this.m_TextComponent.textInfo.characterInfo[num4 + tmp_LineInfo.firstCharacterIndex].character;
						num4++;
					}
					string line = new string(array);
					this.SendOnLineSelection(line, tmp_LineInfo.firstCharacterIndex, tmp_LineInfo.characterCount);
				}
				int num5 = TMP_TextUtilities.FindIntersectingLink(this.m_TextComponent, Input.mousePosition, this.m_Camera);
				if (num5 != -1 && num5 != this.m_selectedLink)
				{
					this.m_selectedLink = num5;
					TMP_LinkInfo tmp_LinkInfo = this.m_TextComponent.textInfo.linkInfo[num5];
					this.SendOnLinkSelection(tmp_LinkInfo.GetLinkID(), tmp_LinkInfo.GetLinkText(), num5);
					return;
				}
			}
			else
			{
				this.m_selectedLink = -1;
				this.m_lastCharIndex = -1;
				this.m_lastWordIndex = -1;
				this.m_lastLineIndex = -1;
			}
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x000020BE File Offset: 0x000002BE
		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x000020BE File Offset: 0x000002BE
		public void OnPointerExit(PointerEventData eventData)
		{
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x0003C0A3 File Offset: 0x0003A2A3
		private void SendOnCharacterSelection(char character, int characterIndex)
		{
			if (this.onCharacterSelection != null)
			{
				this.onCharacterSelection.Invoke(character, characterIndex);
			}
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x0003C0BA File Offset: 0x0003A2BA
		private void SendOnSpriteSelection(char character, int characterIndex)
		{
			if (this.onSpriteSelection != null)
			{
				this.onSpriteSelection.Invoke(character, characterIndex);
			}
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x0003C0D1 File Offset: 0x0003A2D1
		private void SendOnWordSelection(string word, int charIndex, int length)
		{
			if (this.onWordSelection != null)
			{
				this.onWordSelection.Invoke(word, charIndex, length);
			}
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x0003C0E9 File Offset: 0x0003A2E9
		private void SendOnLineSelection(string line, int charIndex, int length)
		{
			if (this.onLineSelection != null)
			{
				this.onLineSelection.Invoke(line, charIndex, length);
			}
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x0003C101 File Offset: 0x0003A301
		private void SendOnLinkSelection(string linkID, string linkText, int linkIndex)
		{
			if (this.onLinkSelection != null)
			{
				this.onLinkSelection.Invoke(linkID, linkText, linkIndex);
			}
		}

		// Token: 0x04000EBC RID: 3772
		[SerializeField]
		private TMP_TextEventHandler.CharacterSelectionEvent m_OnCharacterSelection = new TMP_TextEventHandler.CharacterSelectionEvent();

		// Token: 0x04000EBD RID: 3773
		[SerializeField]
		private TMP_TextEventHandler.SpriteSelectionEvent m_OnSpriteSelection = new TMP_TextEventHandler.SpriteSelectionEvent();

		// Token: 0x04000EBE RID: 3774
		[SerializeField]
		private TMP_TextEventHandler.WordSelectionEvent m_OnWordSelection = new TMP_TextEventHandler.WordSelectionEvent();

		// Token: 0x04000EBF RID: 3775
		[SerializeField]
		private TMP_TextEventHandler.LineSelectionEvent m_OnLineSelection = new TMP_TextEventHandler.LineSelectionEvent();

		// Token: 0x04000EC0 RID: 3776
		[SerializeField]
		private TMP_TextEventHandler.LinkSelectionEvent m_OnLinkSelection = new TMP_TextEventHandler.LinkSelectionEvent();

		// Token: 0x04000EC1 RID: 3777
		private TMP_Text m_TextComponent;

		// Token: 0x04000EC2 RID: 3778
		private Camera m_Camera;

		// Token: 0x04000EC3 RID: 3779
		private Canvas m_Canvas;

		// Token: 0x04000EC4 RID: 3780
		private int m_selectedLink = -1;

		// Token: 0x04000EC5 RID: 3781
		private int m_lastCharIndex = -1;

		// Token: 0x04000EC6 RID: 3782
		private int m_lastWordIndex = -1;

		// Token: 0x04000EC7 RID: 3783
		private int m_lastLineIndex = -1;

		// Token: 0x02000221 RID: 545
		[Serializable]
		public class CharacterSelectionEvent : UnityEvent<char, int>
		{
		}

		// Token: 0x02000222 RID: 546
		[Serializable]
		public class SpriteSelectionEvent : UnityEvent<char, int>
		{
		}

		// Token: 0x02000223 RID: 547
		[Serializable]
		public class WordSelectionEvent : UnityEvent<string, int, int>
		{
		}

		// Token: 0x02000224 RID: 548
		[Serializable]
		public class LineSelectionEvent : UnityEvent<string, int, int>
		{
		}

		// Token: 0x02000225 RID: 549
		[Serializable]
		public class LinkSelectionEvent : UnityEvent<string, string, int>
		{
		}
	}
}
