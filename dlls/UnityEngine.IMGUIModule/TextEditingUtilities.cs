using System;
using System.Collections.Generic;
using UnityEngine.Bindings;
using UnityEngine.TextCore.Text;

namespace UnityEngine
{
	// Token: 0x0200003E RID: 62
	internal class TextEditingUtilities
	{
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000440 RID: 1088 RVA: 0x000103C7 File Offset: 0x0000E5C7
		private bool hasSelection
		{
			get
			{
				return this.m_TextSelectingUtility.hasSelection;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x000103D4 File Offset: 0x0000E5D4
		private string SelectedText
		{
			get
			{
				return this.m_TextSelectingUtility.selectedText;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000442 RID: 1090 RVA: 0x000103E1 File Offset: 0x0000E5E1
		private int m_iAltCursorPos
		{
			get
			{
				return this.m_TextSelectingUtility.iAltCursorPos;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x000103F0 File Offset: 0x0000E5F0
		// (set) Token: 0x06000444 RID: 1092 RVA: 0x0001040D File Offset: 0x0000E60D
		internal bool revealCursor
		{
			get
			{
				return this.m_TextSelectingUtility.revealCursor;
			}
			set
			{
				this.m_TextSelectingUtility.revealCursor = value;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x00010420 File Offset: 0x0000E620
		// (set) Token: 0x06000446 RID: 1094 RVA: 0x0001043D File Offset: 0x0000E63D
		private int cursorIndex
		{
			get
			{
				return this.m_TextSelectingUtility.cursorIndex;
			}
			set
			{
				this.m_TextSelectingUtility.cursorIndex = value;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x00010450 File Offset: 0x0000E650
		// (set) Token: 0x06000448 RID: 1096 RVA: 0x0001046D File Offset: 0x0000E66D
		private int selectIndex
		{
			get
			{
				return this.m_TextSelectingUtility.selectIndex;
			}
			set
			{
				this.m_TextSelectingUtility.selectIndex = value;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x00010480 File Offset: 0x0000E680
		// (set) Token: 0x0600044A RID: 1098 RVA: 0x00010498 File Offset: 0x0000E698
		public string text
		{
			get
			{
				return this.m_Text;
			}
			set
			{
				bool flag = value == this.m_Text;
				if (!flag)
				{
					this.m_Text = (value ?? string.Empty);
				}
			}
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x000104C8 File Offset: 0x0000E6C8
		public TextEditingUtilities(TextSelectingUtilities selectingUtilities, TextHandle textHandle, string text)
		{
			this.m_TextSelectingUtility = selectingUtilities;
			this.m_TextHandle = textHandle;
			this.m_Text = text;
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x000104F8 File Offset: 0x0000E6F8
		public bool UpdateImeState()
		{
			bool flag = GUIUtility.compositionString.Length > 0;
			if (flag)
			{
				bool flag2 = !this.isCompositionActive;
				if (flag2)
				{
					this.m_UpdateImeWindowPosition = true;
					this.ReplaceSelection(string.Empty);
				}
				this.isCompositionActive = true;
			}
			else
			{
				this.isCompositionActive = false;
			}
			return this.isCompositionActive;
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00010558 File Offset: 0x0000E758
		public bool ShouldUpdateImeWindowPosition()
		{
			return this.m_UpdateImeWindowPosition;
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00010570 File Offset: 0x0000E770
		public void SetImeWindowPosition(Vector2 worldPosition)
		{
			Vector2 cursorPositionFromStringIndexUsingCharacterHeight = this.m_TextHandle.GetCursorPositionFromStringIndexUsingCharacterHeight(this.cursorIndex, true);
			GUIUtility.compositionCursorPos = worldPosition + cursorPositionFromStringIndexUsingCharacterHeight;
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x000105A0 File Offset: 0x0000E7A0
		public string GeneratePreviewString(bool richText)
		{
			this.RestoreCursorState();
			string compositionString = GUIUtility.compositionString;
			bool flag = this.isCompositionActive;
			string result;
			if (flag)
			{
				result = (richText ? this.text.Insert(this.cursorIndex, "<u>" + compositionString + "</u>") : this.text.Insert(this.cursorIndex, compositionString));
			}
			else
			{
				result = this.text;
			}
			return result;
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x0001060C File Offset: 0x0000E80C
		public void EnableCursorPreviewState()
		{
			bool flag = this.m_CursorIndexSavedState != -1;
			if (!flag)
			{
				this.m_CursorIndexSavedState = this.m_TextSelectingUtility.cursorIndex;
				this.cursorIndex = (this.selectIndex = this.m_CursorIndexSavedState + GUIUtility.compositionString.Length);
			}
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00010660 File Offset: 0x0000E860
		public void RestoreCursorState()
		{
			bool flag = this.m_CursorIndexSavedState == -1;
			if (!flag)
			{
				this.cursorIndex = (this.selectIndex = this.m_CursorIndexSavedState);
				this.m_CursorIndexSavedState = -1;
			}
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x0001069C File Offset: 0x0000E89C
		[VisibleToOtherModules]
		internal bool HandleKeyEvent(Event e)
		{
			this.RestoreCursorState();
			this.InitKeyActions();
			EventModifiers modifiers = e.modifiers;
			e.modifiers &= ~EventModifiers.CapsLock;
			bool flag = TextEditingUtilities.s_KeyEditOps.ContainsKey(e);
			bool result;
			if (flag)
			{
				TextEditOp operation = TextEditingUtilities.s_KeyEditOps[e];
				this.PerformOperation(operation);
				e.modifiers = modifiers;
				result = true;
			}
			else
			{
				e.modifiers = modifiers;
				result = false;
			}
			return result;
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x0001070C File Offset: 0x0000E90C
		private void PerformOperation(TextEditOp operation)
		{
			this.revealCursor = true;
			switch (operation)
			{
			case TextEditOp.MoveLeft:
				this.m_TextSelectingUtility.MoveLeft();
				return;
			case TextEditOp.MoveRight:
				this.m_TextSelectingUtility.MoveRight();
				return;
			case TextEditOp.MoveUp:
				this.m_TextSelectingUtility.MoveUp();
				return;
			case TextEditOp.MoveDown:
				this.m_TextSelectingUtility.MoveDown();
				return;
			case TextEditOp.MoveLineStart:
				this.m_TextSelectingUtility.MoveLineStart();
				return;
			case TextEditOp.MoveLineEnd:
				this.m_TextSelectingUtility.MoveLineEnd();
				return;
			case TextEditOp.MoveTextStart:
				this.m_TextSelectingUtility.MoveTextStart();
				return;
			case TextEditOp.MoveTextEnd:
				this.m_TextSelectingUtility.MoveTextEnd();
				return;
			case TextEditOp.MoveGraphicalLineStart:
				this.m_TextSelectingUtility.MoveGraphicalLineStart();
				return;
			case TextEditOp.MoveGraphicalLineEnd:
				this.m_TextSelectingUtility.MoveGraphicalLineEnd();
				return;
			case TextEditOp.MoveWordLeft:
				this.m_TextSelectingUtility.MoveWordLeft();
				return;
			case TextEditOp.MoveWordRight:
				this.m_TextSelectingUtility.MoveWordRight();
				return;
			case TextEditOp.MoveParagraphForward:
				this.m_TextSelectingUtility.MoveParagraphForward();
				return;
			case TextEditOp.MoveParagraphBackward:
				this.m_TextSelectingUtility.MoveParagraphBackward();
				return;
			case TextEditOp.MoveToStartOfNextWord:
				this.m_TextSelectingUtility.MoveToStartOfNextWord();
				return;
			case TextEditOp.MoveToEndOfPreviousWord:
				this.m_TextSelectingUtility.MoveToEndOfPreviousWord();
				return;
			case TextEditOp.Delete:
				this.Delete();
				return;
			case TextEditOp.Backspace:
				this.Backspace();
				return;
			case TextEditOp.DeleteWordBack:
				this.DeleteWordBack();
				return;
			case TextEditOp.DeleteWordForward:
				this.DeleteWordForward();
				return;
			case TextEditOp.DeleteLineBack:
				this.DeleteLineBack();
				return;
			case TextEditOp.Cut:
				this.Cut();
				return;
			case TextEditOp.Paste:
				this.Paste();
				return;
			}
			Debug.Log("Unimplemented: " + operation.ToString());
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x000108FA File Offset: 0x0000EAFA
		private static void MapKey(string key, TextEditOp action)
		{
			TextEditingUtilities.s_KeyEditOps[Event.KeyboardEvent(key)] = action;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00010910 File Offset: 0x0000EB10
		private void InitKeyActions()
		{
			bool flag = TextEditingUtilities.s_KeyEditOps != null;
			if (!flag)
			{
				TextEditingUtilities.s_KeyEditOps = new Dictionary<Event, TextEditOp>();
				TextEditingUtilities.MapKey("left", TextEditOp.MoveLeft);
				TextEditingUtilities.MapKey("right", TextEditOp.MoveRight);
				TextEditingUtilities.MapKey("up", TextEditOp.MoveUp);
				TextEditingUtilities.MapKey("down", TextEditOp.MoveDown);
				TextEditingUtilities.MapKey("delete", TextEditOp.Delete);
				TextEditingUtilities.MapKey("backspace", TextEditOp.Backspace);
				TextEditingUtilities.MapKey("#backspace", TextEditOp.Backspace);
				bool flag2 = SystemInfo.operatingSystemFamily == OperatingSystemFamily.MacOSX;
				if (flag2)
				{
					TextEditingUtilities.MapKey("^left", TextEditOp.MoveGraphicalLineStart);
					TextEditingUtilities.MapKey("^right", TextEditOp.MoveGraphicalLineEnd);
					TextEditingUtilities.MapKey("&left", TextEditOp.MoveWordLeft);
					TextEditingUtilities.MapKey("&right", TextEditOp.MoveWordRight);
					TextEditingUtilities.MapKey("&up", TextEditOp.MoveParagraphBackward);
					TextEditingUtilities.MapKey("&down", TextEditOp.MoveParagraphForward);
					TextEditingUtilities.MapKey("%left", TextEditOp.MoveGraphicalLineStart);
					TextEditingUtilities.MapKey("%right", TextEditOp.MoveGraphicalLineEnd);
					TextEditingUtilities.MapKey("%up", TextEditOp.MoveTextStart);
					TextEditingUtilities.MapKey("%down", TextEditOp.MoveTextEnd);
					TextEditingUtilities.MapKey("%x", TextEditOp.Cut);
					TextEditingUtilities.MapKey("%v", TextEditOp.Paste);
					TextEditingUtilities.MapKey("^d", TextEditOp.Delete);
					TextEditingUtilities.MapKey("^h", TextEditOp.Backspace);
					TextEditingUtilities.MapKey("^b", TextEditOp.MoveLeft);
					TextEditingUtilities.MapKey("^f", TextEditOp.MoveRight);
					TextEditingUtilities.MapKey("^a", TextEditOp.MoveLineStart);
					TextEditingUtilities.MapKey("^e", TextEditOp.MoveLineEnd);
					TextEditingUtilities.MapKey("&delete", TextEditOp.DeleteWordForward);
					TextEditingUtilities.MapKey("&backspace", TextEditOp.DeleteWordBack);
					TextEditingUtilities.MapKey("%backspace", TextEditOp.DeleteLineBack);
				}
				else
				{
					TextEditingUtilities.MapKey("home", TextEditOp.MoveGraphicalLineStart);
					TextEditingUtilities.MapKey("end", TextEditOp.MoveGraphicalLineEnd);
					TextEditingUtilities.MapKey("%left", TextEditOp.MoveWordLeft);
					TextEditingUtilities.MapKey("%right", TextEditOp.MoveWordRight);
					TextEditingUtilities.MapKey("%up", TextEditOp.MoveParagraphBackward);
					TextEditingUtilities.MapKey("%down", TextEditOp.MoveParagraphForward);
					TextEditingUtilities.MapKey("^left", TextEditOp.MoveToEndOfPreviousWord);
					TextEditingUtilities.MapKey("^right", TextEditOp.MoveToStartOfNextWord);
					TextEditingUtilities.MapKey("^up", TextEditOp.MoveParagraphBackward);
					TextEditingUtilities.MapKey("^down", TextEditOp.MoveParagraphForward);
					TextEditingUtilities.MapKey("^delete", TextEditOp.DeleteWordForward);
					TextEditingUtilities.MapKey("^backspace", TextEditOp.DeleteWordBack);
					TextEditingUtilities.MapKey("%backspace", TextEditOp.DeleteLineBack);
					TextEditingUtilities.MapKey("^x", TextEditOp.Cut);
					TextEditingUtilities.MapKey("^v", TextEditOp.Paste);
					TextEditingUtilities.MapKey("#delete", TextEditOp.Cut);
					TextEditingUtilities.MapKey("#insert", TextEditOp.Paste);
				}
			}
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00010B90 File Offset: 0x0000ED90
		public bool DeleteLineBack()
		{
			this.RestoreCursorState();
			bool hasSelection = this.hasSelection;
			bool result;
			if (hasSelection)
			{
				this.DeleteSelection();
				result = true;
			}
			else
			{
				int num = this.cursorIndex;
				int num2 = num;
				while (num2-- != 0)
				{
					bool flag = this.text[num2] == '\n';
					if (flag)
					{
						num = num2 + 1;
						break;
					}
				}
				bool flag2 = num2 == -1;
				if (flag2)
				{
					num = 0;
				}
				bool flag3 = this.cursorIndex != num;
				if (flag3)
				{
					this.text = this.text.Remove(num, this.cursorIndex - num);
					this.m_TextSelectingUtility.selectIndex = (this.cursorIndex = num);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x00010C50 File Offset: 0x0000EE50
		public bool DeleteWordBack()
		{
			this.RestoreCursorState();
			bool hasSelection = this.hasSelection;
			bool result;
			if (hasSelection)
			{
				this.DeleteSelection();
				result = true;
			}
			else
			{
				int num = this.m_TextSelectingUtility.FindEndOfPreviousWord(this.cursorIndex);
				bool flag = this.cursorIndex != num;
				if (flag)
				{
					this.text = this.text.Remove(num, this.cursorIndex - num);
					this.selectIndex = (this.cursorIndex = num);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00010CD8 File Offset: 0x0000EED8
		public bool DeleteWordForward()
		{
			this.RestoreCursorState();
			bool hasSelection = this.hasSelection;
			bool result;
			if (hasSelection)
			{
				this.DeleteSelection();
				result = true;
			}
			else
			{
				int num = this.m_TextSelectingUtility.FindStartOfNextWord(this.cursorIndex);
				bool flag = this.cursorIndex < this.text.Length;
				if (flag)
				{
					this.text = this.text.Remove(this.cursorIndex, num - this.cursorIndex);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00010D58 File Offset: 0x0000EF58
		public bool Delete()
		{
			this.RestoreCursorState();
			bool hasSelection = this.hasSelection;
			bool result;
			if (hasSelection)
			{
				this.DeleteSelection();
				result = true;
			}
			else
			{
				bool flag = this.cursorIndex < this.text.Length;
				if (flag)
				{
					this.text = this.text.Remove(this.cursorIndex, this.m_TextSelectingUtility.NextCodePointIndex(this.cursorIndex) - this.cursorIndex);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00010DD4 File Offset: 0x0000EFD4
		public bool Backspace()
		{
			this.RestoreCursorState();
			bool hasSelection = this.hasSelection;
			bool result;
			if (hasSelection)
			{
				this.DeleteSelection();
				result = true;
			}
			else
			{
				bool flag = this.cursorIndex > 0;
				if (flag)
				{
					int num = this.m_TextSelectingUtility.PreviousCodePointIndex(this.cursorIndex);
					this.text = this.text.Remove(num, this.cursorIndex - num);
					this.m_TextSelectingUtility.SetCursorIndexWithoutNotify(num);
					this.m_TextSelectingUtility.SetSelectIndexWithoutNotify(num);
					this.m_TextSelectingUtility.ClearCursorPos();
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00010E6C File Offset: 0x0000F06C
		public bool DeleteSelection()
		{
			bool flag = this.cursorIndex == this.selectIndex;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.cursorIndex < this.selectIndex;
				if (flag2)
				{
					this.text = this.text.Substring(0, this.cursorIndex) + this.text.Substring(this.selectIndex, this.text.Length - this.selectIndex);
					this.m_TextSelectingUtility.SetSelectIndexWithoutNotify(this.cursorIndex);
				}
				else
				{
					this.text = this.text.Substring(0, this.selectIndex) + this.text.Substring(this.cursorIndex, this.text.Length - this.cursorIndex);
					this.m_TextSelectingUtility.SetCursorIndexWithoutNotify(this.selectIndex);
				}
				this.m_TextSelectingUtility.ClearCursorPos();
				result = true;
			}
			return result;
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00010F64 File Offset: 0x0000F164
		public void ReplaceSelection(string replace)
		{
			this.RestoreCursorState();
			this.DeleteSelection();
			this.text = this.text.Insert(this.cursorIndex, replace);
			int num = this.cursorIndex + replace.Length;
			this.m_TextSelectingUtility.SetCursorIndexWithoutNotify(num);
			this.m_TextSelectingUtility.SetSelectIndexWithoutNotify(num);
			this.m_TextSelectingUtility.ClearCursorPos();
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00010FCD File Offset: 0x0000F1CD
		public void Insert(char c)
		{
			this.ReplaceSelection(c.ToString());
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00010FE0 File Offset: 0x0000F1E0
		public void MoveSelectionToAltCursor()
		{
			this.RestoreCursorState();
			bool flag = this.m_iAltCursorPos == -1;
			if (!flag)
			{
				int iAltCursorPos = this.m_iAltCursorPos;
				string selectedText = this.SelectedText;
				this.text = this.text.Insert(iAltCursorPos, selectedText);
				bool flag2 = iAltCursorPos < this.cursorIndex;
				if (flag2)
				{
					this.cursorIndex += selectedText.Length;
					this.selectIndex += selectedText.Length;
				}
				this.DeleteSelection();
				this.selectIndex = (this.cursorIndex = iAltCursorPos);
				this.m_TextSelectingUtility.ClearCursorPos();
			}
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00011088 File Offset: 0x0000F288
		public bool CanPaste()
		{
			return GUIUtility.systemCopyBuffer.Length != 0;
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x000110A8 File Offset: 0x0000F2A8
		public bool Cut()
		{
			this.m_TextSelectingUtility.Copy();
			return this.DeleteSelection();
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x000110CC File Offset: 0x0000F2CC
		public bool Paste()
		{
			this.RestoreCursorState();
			string text = GUIUtility.systemCopyBuffer;
			bool flag = text != "";
			bool result;
			if (flag)
			{
				bool flag2 = !this.multiline;
				if (flag2)
				{
					text = TextEditingUtilities.ReplaceNewlinesWithSpaces(text);
				}
				this.ReplaceSelection(text);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x0001111C File Offset: 0x0000F31C
		private static string ReplaceNewlinesWithSpaces(string value)
		{
			value = value.Replace("\r\n", " ");
			value = value.Replace('\n', ' ');
			value = value.Replace('\r', ' ');
			return value;
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x00011159 File Offset: 0x0000F359
		internal void OnBlur()
		{
			this.revealCursor = false;
			this.m_TextSelectingUtility.SelectNone();
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00011170 File Offset: 0x0000F370
		internal bool TouchScreenKeyboardShouldBeUsed()
		{
			RuntimePlatform platform = Application.platform;
			RuntimePlatform runtimePlatform = platform;
			RuntimePlatform runtimePlatform2 = runtimePlatform;
			bool result;
			if (runtimePlatform2 != RuntimePlatform.Android && runtimePlatform2 != RuntimePlatform.WebGLPlayer)
			{
				result = TouchScreenKeyboard.isSupported;
			}
			else
			{
				result = !TouchScreenKeyboard.isInPlaceEditingAllowed;
			}
			return result;
		}

		// Token: 0x04000174 RID: 372
		private TextSelectingUtilities m_TextSelectingUtility;

		// Token: 0x04000175 RID: 373
		private TextHandle m_TextHandle;

		// Token: 0x04000176 RID: 374
		private int m_CursorIndexSavedState = -1;

		// Token: 0x04000177 RID: 375
		internal bool isCompositionActive;

		// Token: 0x04000178 RID: 376
		private bool m_UpdateImeWindowPosition;

		// Token: 0x04000179 RID: 377
		public bool multiline = false;

		// Token: 0x0400017A RID: 378
		private string m_Text;

		// Token: 0x0400017B RID: 379
		private static Dictionary<Event, TextEditOp> s_KeyEditOps;
	}
}
