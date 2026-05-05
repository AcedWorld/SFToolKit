using System;
using System.Collections.Generic;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x0200003F RID: 63
	public class TextEditor
	{
		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000465 RID: 1125 RVA: 0x000111AC File Offset: 0x0000F3AC
		// (set) Token: 0x06000466 RID: 1126 RVA: 0x000111C4 File Offset: 0x0000F3C4
		[Obsolete("Please use 'text' instead of 'content'", false)]
		public GUIContent content
		{
			get
			{
				return this.m_Content;
			}
			set
			{
				this.m_Content = value;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000467 RID: 1127 RVA: 0x000111D0 File Offset: 0x0000F3D0
		// (set) Token: 0x06000468 RID: 1128 RVA: 0x000111ED File Offset: 0x0000F3ED
		public string text
		{
			get
			{
				return this.m_Content.text;
			}
			set
			{
				this.m_Content.text = (value ?? string.Empty);
				this.EnsureValidCodePointIndex(ref this.m_CursorIndex);
				this.EnsureValidCodePointIndex(ref this.m_SelectIndex);
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x00011220 File Offset: 0x0000F420
		// (set) Token: 0x0600046A RID: 1130 RVA: 0x00011238 File Offset: 0x0000F438
		public Rect position
		{
			get
			{
				return this.m_Position;
			}
			set
			{
				bool flag = this.m_Position == value;
				if (!flag)
				{
					this.scrollOffset = Vector2.zero;
					this.m_Position = value;
					this.UpdateScrollOffset();
				}
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x0600046B RID: 1131 RVA: 0x00011274 File Offset: 0x0000F474
		internal virtual Rect localPosition
		{
			get
			{
				return this.position;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x0001128C File Offset: 0x0000F48C
		// (set) Token: 0x0600046D RID: 1133 RVA: 0x000112A4 File Offset: 0x0000F4A4
		public int cursorIndex
		{
			get
			{
				return this.m_CursorIndex;
			}
			set
			{
				int cursorIndex = this.m_CursorIndex;
				this.m_CursorIndex = value;
				this.EnsureValidCodePointIndex(ref this.m_CursorIndex);
				bool flag = this.m_CursorIndex != cursorIndex;
				if (flag)
				{
					this.m_RevealCursor = true;
					this.OnCursorIndexChange();
				}
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x0600046E RID: 1134 RVA: 0x000112F0 File Offset: 0x0000F4F0
		// (set) Token: 0x0600046F RID: 1135 RVA: 0x00011308 File Offset: 0x0000F508
		public int selectIndex
		{
			get
			{
				return this.m_SelectIndex;
			}
			set
			{
				int selectIndex = this.m_SelectIndex;
				this.m_SelectIndex = value;
				this.EnsureValidCodePointIndex(ref this.m_SelectIndex);
				bool flag = this.m_SelectIndex != selectIndex;
				if (flag)
				{
					this.OnSelectIndexChange();
				}
			}
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00011348 File Offset: 0x0000F548
		private void ClearCursorPos()
		{
			this.hasHorizontalCursorPos = false;
			this.m_iAltCursorPos = -1;
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000471 RID: 1137 RVA: 0x0001135C File Offset: 0x0000F55C
		// (set) Token: 0x06000472 RID: 1138 RVA: 0x00011374 File Offset: 0x0000F574
		public TextEditor.DblClickSnapping doubleClickSnapping
		{
			get
			{
				return this.m_DblClickSnap;
			}
			set
			{
				this.m_DblClickSnap = value;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000473 RID: 1139 RVA: 0x00011380 File Offset: 0x0000F580
		// (set) Token: 0x06000474 RID: 1140 RVA: 0x00011398 File Offset: 0x0000F598
		public int altCursorPosition
		{
			get
			{
				return this.m_iAltCursorPos;
			}
			set
			{
				this.m_iAltCursorPos = value;
			}
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x000113A4 File Offset: 0x0000F5A4
		[RequiredByNativeCode]
		public TextEditor()
		{
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00011438 File Offset: 0x0000F638
		public void OnFocus()
		{
			bool flag = this.multiline;
			if (flag)
			{
				this.cursorIndex = (this.selectIndex = 0);
			}
			else
			{
				this.SelectAll();
			}
			this.m_HasFocus = true;
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00011472 File Offset: 0x0000F672
		public void OnLostFocus()
		{
			this.m_HasFocus = false;
			this.scrollOffset = Vector2.zero;
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00011488 File Offset: 0x0000F688
		private void GrabGraphicalCursorPos()
		{
			bool flag = !this.hasHorizontalCursorPos;
			if (flag)
			{
				this.graphicalCursorPos = this.style.GetCursorPixelPosition(this.localPosition, this.m_Content, this.cursorIndex);
				this.graphicalSelectCursorPos = this.style.GetCursorPixelPosition(this.localPosition, this.m_Content, this.selectIndex);
				this.hasHorizontalCursorPos = false;
			}
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x000114F4 File Offset: 0x0000F6F4
		public bool HandleKeyEvent(Event e)
		{
			return this.HandleKeyEvent(e, false);
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00011510 File Offset: 0x0000F710
		[VisibleToOtherModules]
		internal bool HandleKeyEvent(Event e, bool textIsReadOnly)
		{
			this.InitKeyActions();
			EventModifiers modifiers = e.modifiers;
			e.modifiers &= ~EventModifiers.CapsLock;
			bool flag = TextEditor.s_Keyactions.ContainsKey(e);
			bool result;
			if (flag)
			{
				TextEditor.TextEditOp operation = TextEditor.s_Keyactions[e];
				this.PerformOperation(operation, textIsReadOnly);
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

		// Token: 0x0600047B RID: 1147 RVA: 0x0001157C File Offset: 0x0000F77C
		public bool DeleteLineBack()
		{
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
					this.m_Content.text = this.text.Remove(num, this.cursorIndex - num);
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

		// Token: 0x0600047C RID: 1148 RVA: 0x00011638 File Offset: 0x0000F838
		public bool DeleteWordBack()
		{
			bool hasSelection = this.hasSelection;
			bool result;
			if (hasSelection)
			{
				this.DeleteSelection();
				result = true;
			}
			else
			{
				int num = this.FindEndOfPreviousWord(this.cursorIndex);
				bool flag = this.cursorIndex != num;
				if (flag)
				{
					this.m_Content.text = this.text.Remove(num, this.cursorIndex - num);
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

		// Token: 0x0600047D RID: 1149 RVA: 0x000116B8 File Offset: 0x0000F8B8
		public bool DeleteWordForward()
		{
			bool hasSelection = this.hasSelection;
			bool result;
			if (hasSelection)
			{
				this.DeleteSelection();
				result = true;
			}
			else
			{
				int num = this.FindStartOfNextWord(this.cursorIndex);
				bool flag = this.cursorIndex < this.text.Length;
				if (flag)
				{
					this.m_Content.text = this.text.Remove(this.cursorIndex, num - this.cursorIndex);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x00011730 File Offset: 0x0000F930
		public bool Delete()
		{
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
					this.m_Content.text = this.text.Remove(this.cursorIndex, this.NextCodePointIndex(this.cursorIndex) - this.cursorIndex);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x000117A8 File Offset: 0x0000F9A8
		public bool CanPaste()
		{
			return GUIUtility.systemCopyBuffer.Length != 0;
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x000117C8 File Offset: 0x0000F9C8
		public bool Backspace()
		{
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
					int num = this.PreviousCodePointIndex(this.cursorIndex);
					this.m_Content.text = this.text.Remove(num, this.cursorIndex - num);
					this.selectIndex = (this.cursorIndex = num);
					this.ClearCursorPos();
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x0001184B File Offset: 0x0000FA4B
		public void SelectAll()
		{
			this.cursorIndex = 0;
			this.selectIndex = this.text.Length;
			this.ClearCursorPos();
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x0001186F File Offset: 0x0000FA6F
		public void SelectNone()
		{
			this.selectIndex = this.cursorIndex;
			this.ClearCursorPos();
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x00011888 File Offset: 0x0000FA88
		public bool hasSelection
		{
			get
			{
				return this.cursorIndex != this.selectIndex;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x000118AC File Offset: 0x0000FAAC
		public string SelectedText
		{
			get
			{
				bool flag = this.cursorIndex == this.selectIndex;
				string result;
				if (flag)
				{
					result = "";
				}
				else
				{
					bool flag2 = this.cursorIndex < this.selectIndex;
					if (flag2)
					{
						result = this.text.Substring(this.cursorIndex, this.selectIndex - this.cursorIndex);
					}
					else
					{
						result = this.text.Substring(this.selectIndex, this.cursorIndex - this.selectIndex);
					}
				}
				return result;
			}
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x0001192C File Offset: 0x0000FB2C
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
					this.m_Content.text = this.text.Substring(0, this.cursorIndex) + this.text.Substring(this.selectIndex, this.text.Length - this.selectIndex);
					this.selectIndex = this.cursorIndex;
				}
				else
				{
					this.m_Content.text = this.text.Substring(0, this.selectIndex) + this.text.Substring(this.cursorIndex, this.text.Length - this.cursorIndex);
					this.cursorIndex = this.selectIndex;
				}
				this.ClearCursorPos();
				result = true;
			}
			return result;
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x00011A20 File Offset: 0x0000FC20
		public void ReplaceSelection(string replace)
		{
			this.DeleteSelection();
			this.m_Content.text = this.text.Insert(this.cursorIndex, replace);
			this.selectIndex = (this.cursorIndex += replace.Length);
			this.ClearCursorPos();
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00011A78 File Offset: 0x0000FC78
		public void Insert(char c)
		{
			this.ReplaceSelection(c.ToString());
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00011A8C File Offset: 0x0000FC8C
		public void MoveSelectionToAltCursor()
		{
			bool flag = this.m_iAltCursorPos == -1;
			if (!flag)
			{
				int iAltCursorPos = this.m_iAltCursorPos;
				string selectedText = this.SelectedText;
				this.m_Content.text = this.text.Insert(iAltCursorPos, selectedText);
				bool flag2 = iAltCursorPos < this.cursorIndex;
				if (flag2)
				{
					this.cursorIndex += selectedText.Length;
					this.selectIndex += selectedText.Length;
				}
				this.DeleteSelection();
				this.selectIndex = (this.cursorIndex = iAltCursorPos);
				this.ClearCursorPos();
			}
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x00011B2C File Offset: 0x0000FD2C
		public void MoveRight()
		{
			this.ClearCursorPos();
			bool flag = this.selectIndex == this.cursorIndex;
			if (flag)
			{
				this.cursorIndex = this.NextCodePointIndex(this.cursorIndex);
				this.DetectFocusChange();
				this.selectIndex = this.cursorIndex;
			}
			else
			{
				bool flag2 = this.selectIndex > this.cursorIndex;
				if (flag2)
				{
					this.cursorIndex = this.selectIndex;
				}
				else
				{
					this.selectIndex = this.cursorIndex;
				}
			}
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x00011BB0 File Offset: 0x0000FDB0
		public void MoveLeft()
		{
			bool flag = this.selectIndex == this.cursorIndex;
			if (flag)
			{
				this.cursorIndex = this.PreviousCodePointIndex(this.cursorIndex);
				this.selectIndex = this.cursorIndex;
			}
			else
			{
				bool flag2 = this.selectIndex > this.cursorIndex;
				if (flag2)
				{
					this.selectIndex = this.cursorIndex;
				}
				else
				{
					this.cursorIndex = this.selectIndex;
				}
			}
			this.ClearCursorPos();
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x00011C2C File Offset: 0x0000FE2C
		public void MoveUp()
		{
			bool flag = this.selectIndex < this.cursorIndex;
			if (flag)
			{
				this.selectIndex = this.cursorIndex;
			}
			else
			{
				this.cursorIndex = this.selectIndex;
			}
			this.GrabGraphicalCursorPos();
			this.graphicalCursorPos.y = this.graphicalCursorPos.y - 1f;
			this.cursorIndex = (this.selectIndex = this.style.GetCursorStringIndex(this.localPosition, this.m_Content, this.graphicalCursorPos));
			bool flag2 = this.cursorIndex <= 0;
			if (flag2)
			{
				this.ClearCursorPos();
			}
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x00011CC8 File Offset: 0x0000FEC8
		public void MoveDown()
		{
			bool flag = this.selectIndex > this.cursorIndex;
			if (flag)
			{
				this.selectIndex = this.cursorIndex;
			}
			else
			{
				this.cursorIndex = this.selectIndex;
			}
			this.GrabGraphicalCursorPos();
			this.graphicalCursorPos.y = this.graphicalCursorPos.y + (this.style.lineHeight + 5f);
			this.cursorIndex = (this.selectIndex = this.style.GetCursorStringIndex(this.localPosition, this.m_Content, this.graphicalCursorPos));
			bool flag2 = this.cursorIndex == this.text.Length;
			if (flag2)
			{
				this.ClearCursorPos();
			}
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00011D78 File Offset: 0x0000FF78
		public void MoveLineStart()
		{
			int num = (this.selectIndex < this.cursorIndex) ? this.selectIndex : this.cursorIndex;
			int num2 = num;
			while (num2-- != 0)
			{
				bool flag = this.text[num2] == '\n';
				if (flag)
				{
					this.selectIndex = (this.cursorIndex = num2 + 1);
					return;
				}
			}
			this.selectIndex = (this.cursorIndex = 0);
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x00011DF4 File Offset: 0x0000FFF4
		public void MoveLineEnd()
		{
			int num = (this.selectIndex > this.cursorIndex) ? this.selectIndex : this.cursorIndex;
			int i = num;
			int length = this.text.Length;
			while (i < length)
			{
				bool flag = this.text[i] == '\n';
				if (flag)
				{
					this.selectIndex = (this.cursorIndex = i);
					return;
				}
				i++;
			}
			this.selectIndex = (this.cursorIndex = length);
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x00011E80 File Offset: 0x00010080
		public void MoveGraphicalLineStart()
		{
			this.cursorIndex = (this.selectIndex = this.GetGraphicalLineStart((this.cursorIndex < this.selectIndex) ? this.cursorIndex : this.selectIndex));
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x00011EC4 File Offset: 0x000100C4
		public void MoveGraphicalLineEnd()
		{
			this.cursorIndex = (this.selectIndex = this.GetGraphicalLineEnd((this.cursorIndex > this.selectIndex) ? this.cursorIndex : this.selectIndex));
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x00011F08 File Offset: 0x00010108
		public void MoveTextStart()
		{
			this.selectIndex = (this.cursorIndex = 0);
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x00011F28 File Offset: 0x00010128
		public void MoveTextEnd()
		{
			this.selectIndex = (this.cursorIndex = this.text.Length);
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x00011F54 File Offset: 0x00010154
		private int IndexOfEndOfLine(int startIndex)
		{
			int num = this.text.IndexOf('\n', startIndex);
			return (num != -1) ? num : this.text.Length;
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x00011F88 File Offset: 0x00010188
		public void MoveParagraphForward()
		{
			this.cursorIndex = ((this.cursorIndex > this.selectIndex) ? this.cursorIndex : this.selectIndex);
			bool flag = this.cursorIndex < this.text.Length;
			if (flag)
			{
				this.selectIndex = (this.cursorIndex = this.IndexOfEndOfLine(this.cursorIndex + 1));
			}
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x00011FF4 File Offset: 0x000101F4
		public void MoveParagraphBackward()
		{
			this.cursorIndex = ((this.cursorIndex < this.selectIndex) ? this.cursorIndex : this.selectIndex);
			bool flag = this.cursorIndex > 1;
			if (flag)
			{
				this.selectIndex = (this.cursorIndex = this.text.LastIndexOf('\n', this.cursorIndex - 2) + 1);
			}
			else
			{
				this.selectIndex = (this.cursorIndex = 0);
			}
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x00012070 File Offset: 0x00010270
		public void MoveCursorToPosition(Vector2 cursorPosition)
		{
			this.MoveCursorToPosition_Internal(cursorPosition, Event.current.shift);
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x00012088 File Offset: 0x00010288
		protected internal void MoveCursorToPosition_Internal(Vector2 cursorPosition, bool shift)
		{
			this.selectIndex = this.style.GetCursorStringIndex(this.localPosition, this.m_Content, cursorPosition + this.scrollOffset);
			bool flag = !shift;
			if (flag)
			{
				this.cursorIndex = this.selectIndex;
			}
			this.DetectFocusChange();
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x000120E0 File Offset: 0x000102E0
		public void MoveAltCursorToPosition(Vector2 cursorPosition)
		{
			int cursorStringIndex = this.style.GetCursorStringIndex(this.localPosition, this.m_Content, cursorPosition + this.scrollOffset);
			this.m_iAltCursorPos = Mathf.Min(this.text.Length, cursorStringIndex);
			this.DetectFocusChange();
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x00012130 File Offset: 0x00010330
		public bool IsOverSelection(Vector2 cursorPosition)
		{
			int cursorStringIndex = this.style.GetCursorStringIndex(this.localPosition, this.m_Content, cursorPosition + this.scrollOffset);
			return cursorStringIndex < Mathf.Max(this.cursorIndex, this.selectIndex) && cursorStringIndex > Mathf.Min(this.cursorIndex, this.selectIndex);
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x00012194 File Offset: 0x00010394
		public void SelectToPosition(Vector2 cursorPosition)
		{
			bool flag = !this.m_MouseDragSelectsWholeWords;
			if (flag)
			{
				this.cursorIndex = this.style.GetCursorStringIndex(this.localPosition, this.m_Content, cursorPosition + this.scrollOffset);
			}
			else
			{
				int cursorStringIndex = this.style.GetCursorStringIndex(this.localPosition, this.m_Content, cursorPosition + this.scrollOffset);
				this.EnsureValidCodePointIndex(ref cursorStringIndex);
				this.EnsureValidCodePointIndex(ref this.m_DblClickInitPos);
				bool flag2 = this.m_DblClickSnap == TextEditor.DblClickSnapping.WORDS;
				if (flag2)
				{
					bool flag3 = cursorStringIndex < this.m_DblClickInitPos;
					if (flag3)
					{
						this.cursorIndex = this.FindEndOfClassification(cursorStringIndex, TextEditor.Direction.Backward);
						this.selectIndex = this.FindEndOfClassification(this.m_DblClickInitPos, TextEditor.Direction.Forward);
					}
					else
					{
						this.cursorIndex = this.FindEndOfClassification(cursorStringIndex, TextEditor.Direction.Forward);
						this.selectIndex = this.FindEndOfClassification(this.m_DblClickInitPos, TextEditor.Direction.Backward);
					}
				}
				else
				{
					bool flag4 = cursorStringIndex < this.m_DblClickInitPos;
					if (flag4)
					{
						bool flag5 = cursorStringIndex > 0;
						if (flag5)
						{
							this.cursorIndex = this.text.LastIndexOf('\n', Mathf.Max(0, cursorStringIndex - 2)) + 1;
						}
						else
						{
							this.cursorIndex = 0;
						}
						this.selectIndex = this.text.LastIndexOf('\n', Mathf.Min(this.text.Length - 1, this.m_DblClickInitPos));
					}
					else
					{
						bool flag6 = cursorStringIndex < this.text.Length;
						if (flag6)
						{
							this.cursorIndex = this.IndexOfEndOfLine(cursorStringIndex);
						}
						else
						{
							this.cursorIndex = this.text.Length;
						}
						this.selectIndex = this.text.LastIndexOf('\n', Mathf.Max(0, this.m_DblClickInitPos - 2)) + 1;
					}
				}
			}
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x0001235C File Offset: 0x0001055C
		public void SelectLeft()
		{
			bool bJustSelected = this.m_bJustSelected;
			if (bJustSelected)
			{
				bool flag = this.cursorIndex > this.selectIndex;
				if (flag)
				{
					int cursorIndex = this.cursorIndex;
					this.cursorIndex = this.selectIndex;
					this.selectIndex = cursorIndex;
				}
			}
			this.m_bJustSelected = false;
			this.cursorIndex = this.PreviousCodePointIndex(this.cursorIndex);
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x000123C0 File Offset: 0x000105C0
		public void SelectRight()
		{
			bool bJustSelected = this.m_bJustSelected;
			if (bJustSelected)
			{
				bool flag = this.cursorIndex < this.selectIndex;
				if (flag)
				{
					int cursorIndex = this.cursorIndex;
					this.cursorIndex = this.selectIndex;
					this.selectIndex = cursorIndex;
				}
			}
			this.m_bJustSelected = false;
			this.cursorIndex = this.NextCodePointIndex(this.cursorIndex);
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x00012424 File Offset: 0x00010624
		public void SelectUp()
		{
			this.GrabGraphicalCursorPos();
			this.graphicalCursorPos.y = this.graphicalCursorPos.y - 1f;
			this.cursorIndex = this.style.GetCursorStringIndex(this.localPosition, this.m_Content, this.graphicalCursorPos);
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00012474 File Offset: 0x00010674
		public void SelectDown()
		{
			this.GrabGraphicalCursorPos();
			this.graphicalCursorPos.y = this.graphicalCursorPos.y + (this.style.lineHeight + 5f);
			this.cursorIndex = this.style.GetCursorStringIndex(this.localPosition, this.m_Content, this.graphicalCursorPos);
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x000124CD File Offset: 0x000106CD
		public void SelectTextEnd()
		{
			this.cursorIndex = this.text.Length;
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x000124E2 File Offset: 0x000106E2
		public void SelectTextStart()
		{
			this.cursorIndex = 0;
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x000124ED File Offset: 0x000106ED
		public void MouseDragSelectsWholeWords(bool on)
		{
			this.m_MouseDragSelectsWholeWords = on;
			this.m_DblClickInitPos = this.cursorIndex;
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x00011374 File Offset: 0x0000F574
		public void DblClickSnap(TextEditor.DblClickSnapping snapping)
		{
			this.m_DblClickSnap = snapping;
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x00012504 File Offset: 0x00010704
		private int GetGraphicalLineStart(int p)
		{
			Vector2 cursorPixelPosition = this.style.GetCursorPixelPosition(this.localPosition, this.m_Content, p);
			cursorPixelPosition.y += 1f / GUIUtility.pixelsPerPoint;
			cursorPixelPosition.x = 0f;
			return this.style.GetCursorStringIndex(this.localPosition, this.m_Content, cursorPixelPosition);
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x0001256C File Offset: 0x0001076C
		private int GetGraphicalLineEnd(int p)
		{
			Vector2 cursorPixelPosition = this.style.GetCursorPixelPosition(this.localPosition, this.m_Content, p);
			cursorPixelPosition.y += 1f / GUIUtility.pixelsPerPoint;
			cursorPixelPosition.x += 5000f;
			return this.style.GetCursorStringIndex(this.localPosition, this.m_Content, cursorPixelPosition);
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x000125D8 File Offset: 0x000107D8
		private int FindNextSeperator(int startPos)
		{
			int length = this.text.Length;
			while (startPos < length && this.ClassifyChar(startPos) > TextEditor.CharacterType.LetterLike)
			{
				startPos = this.NextCodePointIndex(startPos);
			}
			while (startPos < length && this.ClassifyChar(startPos) == TextEditor.CharacterType.LetterLike)
			{
				startPos = this.NextCodePointIndex(startPos);
			}
			return startPos;
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x00012638 File Offset: 0x00010838
		private int FindPrevSeperator(int startPos)
		{
			startPos = this.PreviousCodePointIndex(startPos);
			while (startPos > 0 && this.ClassifyChar(startPos) > TextEditor.CharacterType.LetterLike)
			{
				startPos = this.PreviousCodePointIndex(startPos);
			}
			bool flag = startPos == 0;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				while (startPos > 0 && this.ClassifyChar(startPos) == TextEditor.CharacterType.LetterLike)
				{
					startPos = this.PreviousCodePointIndex(startPos);
				}
				bool flag2 = this.ClassifyChar(startPos) == TextEditor.CharacterType.LetterLike;
				if (flag2)
				{
					result = startPos;
				}
				else
				{
					result = this.NextCodePointIndex(startPos);
				}
			}
			return result;
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x000126BC File Offset: 0x000108BC
		public void MoveWordRight()
		{
			this.cursorIndex = ((this.cursorIndex > this.selectIndex) ? this.cursorIndex : this.selectIndex);
			this.cursorIndex = (this.selectIndex = this.FindNextSeperator(this.cursorIndex));
			this.ClearCursorPos();
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00012714 File Offset: 0x00010914
		public void MoveToStartOfNextWord()
		{
			this.ClearCursorPos();
			bool flag = this.cursorIndex != this.selectIndex;
			if (flag)
			{
				this.MoveRight();
			}
			else
			{
				this.cursorIndex = (this.selectIndex = this.FindStartOfNextWord(this.cursorIndex));
			}
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x00012768 File Offset: 0x00010968
		public void MoveToEndOfPreviousWord()
		{
			this.ClearCursorPos();
			bool flag = this.cursorIndex != this.selectIndex;
			if (flag)
			{
				this.MoveLeft();
			}
			else
			{
				this.cursorIndex = (this.selectIndex = this.FindEndOfPreviousWord(this.cursorIndex));
			}
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x000127B9 File Offset: 0x000109B9
		public void SelectToStartOfNextWord()
		{
			this.ClearCursorPos();
			this.cursorIndex = this.FindStartOfNextWord(this.cursorIndex);
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x000127D6 File Offset: 0x000109D6
		public void SelectToEndOfPreviousWord()
		{
			this.ClearCursorPos();
			this.cursorIndex = this.FindEndOfPreviousWord(this.cursorIndex);
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x000127F4 File Offset: 0x000109F4
		private TextEditor.CharacterType ClassifyChar(int index)
		{
			bool flag = char.IsWhiteSpace(this.text, index);
			TextEditor.CharacterType result;
			if (flag)
			{
				result = TextEditor.CharacterType.WhiteSpace;
			}
			else
			{
				bool flag2 = char.IsLetterOrDigit(this.text, index) || this.text[index] == '\'';
				if (flag2)
				{
					result = TextEditor.CharacterType.LetterLike;
				}
				else
				{
					result = TextEditor.CharacterType.Symbol;
				}
			}
			return result;
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x00012844 File Offset: 0x00010A44
		public int FindStartOfNextWord(int p)
		{
			int length = this.text.Length;
			bool flag = p == length;
			int result;
			if (flag)
			{
				result = p;
			}
			else
			{
				TextEditor.CharacterType characterType = this.ClassifyChar(p);
				bool flag2 = characterType != TextEditor.CharacterType.WhiteSpace;
				if (flag2)
				{
					p = this.NextCodePointIndex(p);
					while (p < length && this.ClassifyChar(p) == characterType)
					{
						p = this.NextCodePointIndex(p);
					}
				}
				else
				{
					bool flag3 = this.text[p] == '\t' || this.text[p] == '\n';
					if (flag3)
					{
						return this.NextCodePointIndex(p);
					}
				}
				bool flag4 = p == length;
				if (flag4)
				{
					result = p;
				}
				else
				{
					bool flag5 = this.text[p] == ' ';
					if (flag5)
					{
						while (p < length && this.ClassifyChar(p) == TextEditor.CharacterType.WhiteSpace)
						{
							p = this.NextCodePointIndex(p);
						}
					}
					else
					{
						bool flag6 = this.text[p] == '\t' || this.text[p] == '\n';
						if (flag6)
						{
							return p;
						}
					}
					result = p;
				}
			}
			return result;
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00012964 File Offset: 0x00010B64
		private int FindEndOfPreviousWord(int p)
		{
			bool flag = p == 0;
			int result;
			if (flag)
			{
				result = p;
			}
			else
			{
				p = this.PreviousCodePointIndex(p);
				while (p > 0 && this.text[p] == ' ')
				{
					p = this.PreviousCodePointIndex(p);
				}
				TextEditor.CharacterType characterType = this.ClassifyChar(p);
				bool flag2 = characterType != TextEditor.CharacterType.WhiteSpace;
				if (flag2)
				{
					while (p > 0 && this.ClassifyChar(this.PreviousCodePointIndex(p)) == characterType)
					{
						p = this.PreviousCodePointIndex(p);
					}
				}
				result = p;
			}
			return result;
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x000129F4 File Offset: 0x00010BF4
		public void MoveWordLeft()
		{
			this.cursorIndex = ((this.cursorIndex < this.selectIndex) ? this.cursorIndex : this.selectIndex);
			this.cursorIndex = this.FindPrevSeperator(this.cursorIndex);
			this.selectIndex = this.cursorIndex;
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00012A48 File Offset: 0x00010C48
		public void SelectWordRight()
		{
			this.ClearCursorPos();
			int selectIndex = this.selectIndex;
			bool flag = this.cursorIndex < this.selectIndex;
			if (flag)
			{
				this.selectIndex = this.cursorIndex;
				this.MoveWordRight();
				this.selectIndex = selectIndex;
				this.cursorIndex = ((this.cursorIndex < this.selectIndex) ? this.cursorIndex : this.selectIndex);
			}
			else
			{
				this.selectIndex = this.cursorIndex;
				this.MoveWordRight();
				this.selectIndex = selectIndex;
			}
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00012AD4 File Offset: 0x00010CD4
		public void SelectWordLeft()
		{
			this.ClearCursorPos();
			int selectIndex = this.selectIndex;
			bool flag = this.cursorIndex > this.selectIndex;
			if (flag)
			{
				this.selectIndex = this.cursorIndex;
				this.MoveWordLeft();
				this.selectIndex = selectIndex;
				this.cursorIndex = ((this.cursorIndex > this.selectIndex) ? this.cursorIndex : this.selectIndex);
			}
			else
			{
				this.selectIndex = this.cursorIndex;
				this.MoveWordLeft();
				this.selectIndex = selectIndex;
			}
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00012B60 File Offset: 0x00010D60
		public void ExpandSelectGraphicalLineStart()
		{
			this.ClearCursorPos();
			bool flag = this.cursorIndex < this.selectIndex;
			if (flag)
			{
				this.cursorIndex = this.GetGraphicalLineStart(this.cursorIndex);
			}
			else
			{
				int cursorIndex = this.cursorIndex;
				this.cursorIndex = this.GetGraphicalLineStart(this.selectIndex);
				this.selectIndex = cursorIndex;
			}
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00012BC0 File Offset: 0x00010DC0
		public void ExpandSelectGraphicalLineEnd()
		{
			this.ClearCursorPos();
			bool flag = this.cursorIndex > this.selectIndex;
			if (flag)
			{
				this.cursorIndex = this.GetGraphicalLineEnd(this.cursorIndex);
			}
			else
			{
				int cursorIndex = this.cursorIndex;
				this.cursorIndex = this.GetGraphicalLineEnd(this.selectIndex);
				this.selectIndex = cursorIndex;
			}
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00012C20 File Offset: 0x00010E20
		public void SelectGraphicalLineStart()
		{
			this.ClearCursorPos();
			this.cursorIndex = this.GetGraphicalLineStart(this.cursorIndex);
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x00012C3D File Offset: 0x00010E3D
		public void SelectGraphicalLineEnd()
		{
			this.ClearCursorPos();
			this.cursorIndex = this.GetGraphicalLineEnd(this.cursorIndex);
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00012C5C File Offset: 0x00010E5C
		public void SelectParagraphForward()
		{
			this.ClearCursorPos();
			bool flag = this.cursorIndex < this.selectIndex;
			bool flag2 = this.cursorIndex < this.text.Length;
			if (flag2)
			{
				this.cursorIndex = this.IndexOfEndOfLine(this.cursorIndex + 1);
				bool flag3 = flag && this.cursorIndex > this.selectIndex;
				if (flag3)
				{
					this.cursorIndex = this.selectIndex;
				}
			}
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00012CD4 File Offset: 0x00010ED4
		public void SelectParagraphBackward()
		{
			this.ClearCursorPos();
			bool flag = this.cursorIndex > this.selectIndex;
			bool flag2 = this.cursorIndex > 1;
			if (flag2)
			{
				this.cursorIndex = this.text.LastIndexOf('\n', this.cursorIndex - 2) + 1;
				bool flag3 = flag && this.cursorIndex < this.selectIndex;
				if (flag3)
				{
					this.cursorIndex = this.selectIndex;
				}
			}
			else
			{
				this.selectIndex = (this.cursorIndex = 0);
			}
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x00012D60 File Offset: 0x00010F60
		public void SelectCurrentWord()
		{
			int cursorIndex = this.cursorIndex;
			bool flag = this.cursorIndex < this.selectIndex;
			if (flag)
			{
				this.cursorIndex = this.FindEndOfClassification(cursorIndex, TextEditor.Direction.Backward);
				this.selectIndex = this.FindEndOfClassification(cursorIndex, TextEditor.Direction.Forward);
			}
			else
			{
				this.cursorIndex = this.FindEndOfClassification(cursorIndex, TextEditor.Direction.Forward);
				this.selectIndex = this.FindEndOfClassification(cursorIndex, TextEditor.Direction.Backward);
			}
			this.ClearCursorPos();
			this.m_bJustSelected = true;
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00012DD8 File Offset: 0x00010FD8
		private int FindEndOfClassification(int p, TextEditor.Direction dir)
		{
			bool flag = this.text.Length == 0;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				bool flag2 = p == this.text.Length;
				if (flag2)
				{
					p = this.PreviousCodePointIndex(p);
				}
				TextEditor.CharacterType characterType = this.ClassifyChar(p);
				for (;;)
				{
					if (dir != TextEditor.Direction.Forward)
					{
						if (dir == TextEditor.Direction.Backward)
						{
							p = this.PreviousCodePointIndex(p);
							bool flag3 = p == 0;
							if (flag3)
							{
								break;
							}
						}
					}
					else
					{
						p = this.NextCodePointIndex(p);
						bool flag4 = p == this.text.Length;
						if (flag4)
						{
							goto Block_7;
						}
					}
					if (this.ClassifyChar(p) != characterType)
					{
						goto Block_8;
					}
				}
				return (this.ClassifyChar(0) == characterType) ? 0 : this.NextCodePointIndex(0);
				Block_7:
				return this.text.Length;
				Block_8:
				bool flag5 = dir == TextEditor.Direction.Forward;
				if (flag5)
				{
					result = p;
				}
				else
				{
					result = this.NextCodePointIndex(p);
				}
			}
			return result;
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x00012EBC File Offset: 0x000110BC
		public void SelectCurrentParagraph()
		{
			this.ClearCursorPos();
			int length = this.text.Length;
			bool flag = this.cursorIndex < length;
			if (flag)
			{
				this.cursorIndex = this.IndexOfEndOfLine(this.cursorIndex) + 1;
			}
			bool flag2 = this.selectIndex != 0;
			if (flag2)
			{
				this.selectIndex = this.text.LastIndexOf('\n', this.selectIndex - 1) + 1;
			}
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x00012F2C File Offset: 0x0001112C
		public void UpdateScrollOffsetIfNeeded(Event evt)
		{
			bool flag = evt.type != EventType.Repaint && evt.type != EventType.Layout;
			if (flag)
			{
				this.UpdateScrollOffset();
			}
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x00012F60 File Offset: 0x00011160
		[VisibleToOtherModules]
		internal void UpdateScrollOffset()
		{
			int cursorIndex = this.cursorIndex;
			this.graphicalCursorPos = this.style.GetCursorPixelPosition(new Rect(0f, 0f, this.position.width, this.position.height), this.m_Content, cursorIndex);
			Rect rect = this.style.padding.Remove(this.position);
			Vector2 vector = this.graphicalCursorPos;
			vector.x -= (float)this.style.padding.left;
			vector.y -= (float)this.style.padding.top;
			Vector2 vector2 = new Vector2(this.style.CalcSize(this.m_Content).x, this.style.CalcHeight(this.m_Content, this.position.width));
			vector2.x -= (float)(this.style.padding.left + this.style.padding.right);
			vector2.y -= (float)(this.style.padding.top + this.style.padding.bottom);
			bool flag = vector2.x < rect.width;
			if (flag)
			{
				this.scrollOffset.x = 0f;
			}
			else
			{
				bool revealCursor = this.m_RevealCursor;
				if (revealCursor)
				{
					bool flag2 = vector.x + 1f > this.scrollOffset.x + rect.width;
					if (flag2)
					{
						this.scrollOffset.x = vector.x - rect.width + 1f;
					}
					bool flag3 = vector.x < this.scrollOffset.x;
					if (flag3)
					{
						this.scrollOffset.x = vector.x;
					}
				}
			}
			bool flag4 = vector2.y < rect.height;
			if (flag4)
			{
				this.scrollOffset.y = 0f;
			}
			else
			{
				bool revealCursor2 = this.m_RevealCursor;
				if (revealCursor2)
				{
					bool flag5 = vector.y + this.style.lineHeight > this.scrollOffset.y + rect.height;
					if (flag5)
					{
						this.scrollOffset.y = vector.y - rect.height + this.style.lineHeight;
					}
					bool flag6 = vector.y < this.scrollOffset.y;
					if (flag6)
					{
						this.scrollOffset.y = vector.y;
					}
				}
			}
			bool flag7 = this.scrollOffset.y > 0f && vector2.y - this.scrollOffset.y < rect.height;
			if (flag7)
			{
				this.scrollOffset.y = vector2.y - rect.height;
			}
			this.scrollOffset.y = ((this.scrollOffset.y < 0f) ? 0f : this.scrollOffset.y);
			this.m_RevealCursor = false;
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0001328C File Offset: 0x0001148C
		public void DrawCursor(string newText)
		{
			string text = this.text;
			int num = this.cursorIndex;
			bool flag = GUIUtility.compositionString.Length > 0;
			if (flag)
			{
				this.m_Content.text = newText.Substring(0, this.cursorIndex) + GUIUtility.compositionString + newText.Substring(this.selectIndex);
				num += GUIUtility.compositionString.Length;
			}
			else
			{
				this.m_Content.text = newText;
			}
			this.graphicalCursorPos = this.style.GetCursorPixelPosition(new Rect(0f, 0f, this.position.width, this.position.height), this.m_Content, num);
			Vector2 contentOffset = this.style.contentOffset;
			this.style.contentOffset -= this.scrollOffset;
			this.style.Internal_clipOffset = this.scrollOffset;
			GUIUtility.compositionCursorPos = GUIClip.UnclipToWindow(this.graphicalCursorPos + new Vector2(this.position.x, this.position.y + this.style.lineHeight) - this.scrollOffset);
			bool flag2 = GUIUtility.compositionString.Length > 0;
			if (flag2)
			{
				this.style.DrawWithTextSelection(this.position, this.m_Content, this.controlID, this.cursorIndex, this.cursorIndex + GUIUtility.compositionString.Length, true);
			}
			else
			{
				this.style.DrawWithTextSelection(this.position, this.m_Content, this.controlID, this.cursorIndex, this.selectIndex);
			}
			bool flag3 = this.m_iAltCursorPos != -1;
			if (flag3)
			{
				this.style.DrawCursor(this.position, this.m_Content, this.controlID, this.m_iAltCursorPos);
			}
			this.style.contentOffset = contentOffset;
			this.style.Internal_clipOffset = Vector2.zero;
			this.m_Content.text = text;
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x000134AC File Offset: 0x000116AC
		private bool PerformOperation(TextEditor.TextEditOp operation, bool textIsReadOnly)
		{
			this.m_RevealCursor = true;
			switch (operation)
			{
			case TextEditor.TextEditOp.MoveLeft:
				this.MoveLeft();
				goto IL_328;
			case TextEditor.TextEditOp.MoveRight:
				this.MoveRight();
				goto IL_328;
			case TextEditor.TextEditOp.MoveUp:
				this.MoveUp();
				goto IL_328;
			case TextEditor.TextEditOp.MoveDown:
				this.MoveDown();
				goto IL_328;
			case TextEditor.TextEditOp.MoveLineStart:
				this.MoveLineStart();
				goto IL_328;
			case TextEditor.TextEditOp.MoveLineEnd:
				this.MoveLineEnd();
				goto IL_328;
			case TextEditor.TextEditOp.MoveTextStart:
				this.MoveTextStart();
				goto IL_328;
			case TextEditor.TextEditOp.MoveTextEnd:
				this.MoveTextEnd();
				goto IL_328;
			case TextEditor.TextEditOp.MoveGraphicalLineStart:
				this.MoveGraphicalLineStart();
				goto IL_328;
			case TextEditor.TextEditOp.MoveGraphicalLineEnd:
				this.MoveGraphicalLineEnd();
				goto IL_328;
			case TextEditor.TextEditOp.MoveWordLeft:
				this.MoveWordLeft();
				goto IL_328;
			case TextEditor.TextEditOp.MoveWordRight:
				this.MoveWordRight();
				goto IL_328;
			case TextEditor.TextEditOp.MoveParagraphForward:
				this.MoveParagraphForward();
				goto IL_328;
			case TextEditor.TextEditOp.MoveParagraphBackward:
				this.MoveParagraphBackward();
				goto IL_328;
			case TextEditor.TextEditOp.MoveToStartOfNextWord:
				this.MoveToStartOfNextWord();
				goto IL_328;
			case TextEditor.TextEditOp.MoveToEndOfPreviousWord:
				this.MoveToEndOfPreviousWord();
				goto IL_328;
			case TextEditor.TextEditOp.SelectLeft:
				this.SelectLeft();
				goto IL_328;
			case TextEditor.TextEditOp.SelectRight:
				this.SelectRight();
				goto IL_328;
			case TextEditor.TextEditOp.SelectUp:
				this.SelectUp();
				goto IL_328;
			case TextEditor.TextEditOp.SelectDown:
				this.SelectDown();
				goto IL_328;
			case TextEditor.TextEditOp.SelectTextStart:
				this.SelectTextStart();
				goto IL_328;
			case TextEditor.TextEditOp.SelectTextEnd:
				this.SelectTextEnd();
				goto IL_328;
			case TextEditor.TextEditOp.ExpandSelectGraphicalLineStart:
				this.ExpandSelectGraphicalLineStart();
				goto IL_328;
			case TextEditor.TextEditOp.ExpandSelectGraphicalLineEnd:
				this.ExpandSelectGraphicalLineEnd();
				goto IL_328;
			case TextEditor.TextEditOp.SelectGraphicalLineStart:
				this.SelectGraphicalLineStart();
				goto IL_328;
			case TextEditor.TextEditOp.SelectGraphicalLineEnd:
				this.SelectGraphicalLineEnd();
				goto IL_328;
			case TextEditor.TextEditOp.SelectWordLeft:
				this.SelectWordLeft();
				goto IL_328;
			case TextEditor.TextEditOp.SelectWordRight:
				this.SelectWordRight();
				goto IL_328;
			case TextEditor.TextEditOp.SelectToEndOfPreviousWord:
				this.SelectToEndOfPreviousWord();
				goto IL_328;
			case TextEditor.TextEditOp.SelectToStartOfNextWord:
				this.SelectToStartOfNextWord();
				goto IL_328;
			case TextEditor.TextEditOp.SelectParagraphBackward:
				this.SelectParagraphBackward();
				goto IL_328;
			case TextEditor.TextEditOp.SelectParagraphForward:
				this.SelectParagraphForward();
				goto IL_328;
			case TextEditor.TextEditOp.Delete:
				return !textIsReadOnly && this.Delete();
			case TextEditor.TextEditOp.Backspace:
				return !textIsReadOnly && this.Backspace();
			case TextEditor.TextEditOp.DeleteWordBack:
				return !textIsReadOnly && this.DeleteWordBack();
			case TextEditor.TextEditOp.DeleteWordForward:
				return !textIsReadOnly && this.DeleteWordForward();
			case TextEditor.TextEditOp.DeleteLineBack:
				return !textIsReadOnly && this.DeleteLineBack();
			case TextEditor.TextEditOp.Cut:
				return !textIsReadOnly && this.Cut();
			case TextEditor.TextEditOp.Copy:
				this.Copy();
				goto IL_328;
			case TextEditor.TextEditOp.Paste:
				return !textIsReadOnly && this.Paste();
			case TextEditor.TextEditOp.SelectAll:
				this.SelectAll();
				goto IL_328;
			case TextEditor.TextEditOp.SelectNone:
				this.SelectNone();
				goto IL_328;
			}
			Debug.Log("Unimplemented: " + operation.ToString());
			IL_328:
			return false;
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x000137E6 File Offset: 0x000119E6
		public void SaveBackup()
		{
			this.oldText = this.text;
			this.oldPos = this.cursorIndex;
			this.oldSelectPos = this.selectIndex;
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0001380D File Offset: 0x00011A0D
		public void Undo()
		{
			this.m_Content.text = this.oldText;
			this.cursorIndex = this.oldPos;
			this.selectIndex = this.oldSelectPos;
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x0001383C File Offset: 0x00011A3C
		public bool Cut()
		{
			bool flag = this.isPasswordField;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.Copy();
				result = this.DeleteSelection();
			}
			return result;
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x0001386C File Offset: 0x00011A6C
		public void Copy()
		{
			bool flag = this.selectIndex == this.cursorIndex;
			if (!flag)
			{
				bool flag2 = this.isPasswordField;
				if (!flag2)
				{
					string systemCopyBuffer = this.style.Internal_GetSelectedRenderedText(this.localPosition, this.m_Content, this.selectIndex, this.cursorIndex);
					GUIUtility.systemCopyBuffer = systemCopyBuffer;
				}
			}
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x000138C8 File Offset: 0x00011AC8
		internal Rect[] GetHyperlinksRect()
		{
			return this.style.Internal_GetHyperlinksRect(this.localPosition, this.m_Content);
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x000138F4 File Offset: 0x00011AF4
		private static string ReplaceNewlinesWithSpaces(string value)
		{
			value = value.Replace("\r\n", " ");
			value = value.Replace('\n', ' ');
			value = value.Replace('\r', ' ');
			return value;
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00013934 File Offset: 0x00011B34
		public bool Paste()
		{
			string text = GUIUtility.systemCopyBuffer;
			bool flag = text != "";
			bool result;
			if (flag)
			{
				bool flag2 = !this.multiline;
				if (flag2)
				{
					text = TextEditor.ReplaceNewlinesWithSpaces(text);
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

		// Token: 0x060004C6 RID: 1222 RVA: 0x0001397D File Offset: 0x00011B7D
		private static void MapKey(string key, TextEditor.TextEditOp action)
		{
			TextEditor.s_Keyactions[Event.KeyboardEvent(key)] = action;
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x00013994 File Offset: 0x00011B94
		private void InitKeyActions()
		{
			bool flag = TextEditor.s_Keyactions != null;
			if (!flag)
			{
				TextEditor.s_Keyactions = new Dictionary<Event, TextEditor.TextEditOp>();
				TextEditor.MapKey("left", TextEditor.TextEditOp.MoveLeft);
				TextEditor.MapKey("right", TextEditor.TextEditOp.MoveRight);
				TextEditor.MapKey("up", TextEditor.TextEditOp.MoveUp);
				TextEditor.MapKey("down", TextEditor.TextEditOp.MoveDown);
				TextEditor.MapKey("#left", TextEditor.TextEditOp.SelectLeft);
				TextEditor.MapKey("#right", TextEditor.TextEditOp.SelectRight);
				TextEditor.MapKey("#up", TextEditor.TextEditOp.SelectUp);
				TextEditor.MapKey("#down", TextEditor.TextEditOp.SelectDown);
				TextEditor.MapKey("delete", TextEditor.TextEditOp.Delete);
				TextEditor.MapKey("backspace", TextEditor.TextEditOp.Backspace);
				TextEditor.MapKey("#backspace", TextEditor.TextEditOp.Backspace);
				bool flag2 = SystemInfo.operatingSystemFamily == OperatingSystemFamily.MacOSX;
				if (flag2)
				{
					TextEditor.MapKey("^left", TextEditor.TextEditOp.MoveGraphicalLineStart);
					TextEditor.MapKey("^right", TextEditor.TextEditOp.MoveGraphicalLineEnd);
					TextEditor.MapKey("&left", TextEditor.TextEditOp.MoveWordLeft);
					TextEditor.MapKey("&right", TextEditor.TextEditOp.MoveWordRight);
					TextEditor.MapKey("&up", TextEditor.TextEditOp.MoveParagraphBackward);
					TextEditor.MapKey("&down", TextEditor.TextEditOp.MoveParagraphForward);
					TextEditor.MapKey("%left", TextEditor.TextEditOp.MoveGraphicalLineStart);
					TextEditor.MapKey("%right", TextEditor.TextEditOp.MoveGraphicalLineEnd);
					TextEditor.MapKey("%up", TextEditor.TextEditOp.MoveTextStart);
					TextEditor.MapKey("%down", TextEditor.TextEditOp.MoveTextEnd);
					TextEditor.MapKey("#home", TextEditor.TextEditOp.SelectTextStart);
					TextEditor.MapKey("#end", TextEditor.TextEditOp.SelectTextEnd);
					TextEditor.MapKey("#^left", TextEditor.TextEditOp.ExpandSelectGraphicalLineStart);
					TextEditor.MapKey("#^right", TextEditor.TextEditOp.ExpandSelectGraphicalLineEnd);
					TextEditor.MapKey("#^up", TextEditor.TextEditOp.SelectParagraphBackward);
					TextEditor.MapKey("#^down", TextEditor.TextEditOp.SelectParagraphForward);
					TextEditor.MapKey("#&left", TextEditor.TextEditOp.SelectWordLeft);
					TextEditor.MapKey("#&right", TextEditor.TextEditOp.SelectWordRight);
					TextEditor.MapKey("#&up", TextEditor.TextEditOp.SelectParagraphBackward);
					TextEditor.MapKey("#&down", TextEditor.TextEditOp.SelectParagraphForward);
					TextEditor.MapKey("#%left", TextEditor.TextEditOp.ExpandSelectGraphicalLineStart);
					TextEditor.MapKey("#%right", TextEditor.TextEditOp.ExpandSelectGraphicalLineEnd);
					TextEditor.MapKey("#%up", TextEditor.TextEditOp.SelectTextStart);
					TextEditor.MapKey("#%down", TextEditor.TextEditOp.SelectTextEnd);
					TextEditor.MapKey("%a", TextEditor.TextEditOp.SelectAll);
					TextEditor.MapKey("%x", TextEditor.TextEditOp.Cut);
					TextEditor.MapKey("%c", TextEditor.TextEditOp.Copy);
					TextEditor.MapKey("%v", TextEditor.TextEditOp.Paste);
					TextEditor.MapKey("^d", TextEditor.TextEditOp.Delete);
					TextEditor.MapKey("^h", TextEditor.TextEditOp.Backspace);
					TextEditor.MapKey("^b", TextEditor.TextEditOp.MoveLeft);
					TextEditor.MapKey("^f", TextEditor.TextEditOp.MoveRight);
					TextEditor.MapKey("^a", TextEditor.TextEditOp.MoveLineStart);
					TextEditor.MapKey("^e", TextEditor.TextEditOp.MoveLineEnd);
					TextEditor.MapKey("&delete", TextEditor.TextEditOp.DeleteWordForward);
					TextEditor.MapKey("&backspace", TextEditor.TextEditOp.DeleteWordBack);
					TextEditor.MapKey("%backspace", TextEditor.TextEditOp.DeleteLineBack);
				}
				else
				{
					TextEditor.MapKey("home", TextEditor.TextEditOp.MoveGraphicalLineStart);
					TextEditor.MapKey("end", TextEditor.TextEditOp.MoveGraphicalLineEnd);
					TextEditor.MapKey("%left", TextEditor.TextEditOp.MoveWordLeft);
					TextEditor.MapKey("%right", TextEditor.TextEditOp.MoveWordRight);
					TextEditor.MapKey("%up", TextEditor.TextEditOp.MoveParagraphBackward);
					TextEditor.MapKey("%down", TextEditor.TextEditOp.MoveParagraphForward);
					TextEditor.MapKey("^left", TextEditor.TextEditOp.MoveToEndOfPreviousWord);
					TextEditor.MapKey("^right", TextEditor.TextEditOp.MoveToStartOfNextWord);
					TextEditor.MapKey("^up", TextEditor.TextEditOp.MoveParagraphBackward);
					TextEditor.MapKey("^down", TextEditor.TextEditOp.MoveParagraphForward);
					TextEditor.MapKey("#^left", TextEditor.TextEditOp.SelectToEndOfPreviousWord);
					TextEditor.MapKey("#^right", TextEditor.TextEditOp.SelectToStartOfNextWord);
					TextEditor.MapKey("#^up", TextEditor.TextEditOp.SelectParagraphBackward);
					TextEditor.MapKey("#^down", TextEditor.TextEditOp.SelectParagraphForward);
					TextEditor.MapKey("#home", TextEditor.TextEditOp.SelectGraphicalLineStart);
					TextEditor.MapKey("#end", TextEditor.TextEditOp.SelectGraphicalLineEnd);
					TextEditor.MapKey("^delete", TextEditor.TextEditOp.DeleteWordForward);
					TextEditor.MapKey("^backspace", TextEditor.TextEditOp.DeleteWordBack);
					TextEditor.MapKey("%backspace", TextEditor.TextEditOp.DeleteLineBack);
					TextEditor.MapKey("^a", TextEditor.TextEditOp.SelectAll);
					TextEditor.MapKey("^x", TextEditor.TextEditOp.Cut);
					TextEditor.MapKey("^c", TextEditor.TextEditOp.Copy);
					TextEditor.MapKey("^v", TextEditor.TextEditOp.Paste);
					TextEditor.MapKey("#delete", TextEditor.TextEditOp.Cut);
					TextEditor.MapKey("^insert", TextEditor.TextEditOp.Copy);
					TextEditor.MapKey("#insert", TextEditor.TextEditOp.Paste);
				}
			}
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x00013D8D File Offset: 0x00011F8D
		public void DetectFocusChange()
		{
			this.OnDetectFocusChange();
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00013D98 File Offset: 0x00011F98
		internal virtual void OnDetectFocusChange()
		{
			bool flag = this.m_HasFocus && this.controlID != GUIUtility.keyboardControl;
			if (flag)
			{
				this.OnLostFocus();
			}
			bool flag2 = !this.m_HasFocus && this.controlID == GUIUtility.keyboardControl;
			if (flag2)
			{
				this.OnFocus();
			}
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x00002221 File Offset: 0x00000421
		internal virtual void OnCursorIndexChange()
		{
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x00002221 File Offset: 0x00000421
		internal virtual void OnSelectIndexChange()
		{
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x00013DEF File Offset: 0x00011FEF
		private void ClampTextIndex(ref int index)
		{
			index = Mathf.Clamp(index, 0, this.text.Length);
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x00013E08 File Offset: 0x00012008
		private void EnsureValidCodePointIndex(ref int index)
		{
			this.ClampTextIndex(ref index);
			bool flag = !this.IsValidCodePointIndex(index);
			if (flag)
			{
				index = this.NextCodePointIndex(index);
			}
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x00013E38 File Offset: 0x00012038
		private bool IsValidCodePointIndex(int index)
		{
			bool flag = index < 0 || index > this.text.Length;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = index == 0 || index == this.text.Length;
				result = (flag2 || !char.IsLowSurrogate(this.text[index]));
			}
			return result;
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x00013E98 File Offset: 0x00012098
		private int PreviousCodePointIndex(int index)
		{
			bool flag = index > 0;
			if (flag)
			{
				index--;
			}
			while (index > 0 && char.IsLowSurrogate(this.text[index]))
			{
				index--;
			}
			return index;
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00013EDC File Offset: 0x000120DC
		private int NextCodePointIndex(int index)
		{
			bool flag = index < this.text.Length;
			if (flag)
			{
				index++;
			}
			while (index < this.text.Length && char.IsLowSurrogate(this.text[index]))
			{
				index++;
			}
			return index;
		}

		// Token: 0x0400017C RID: 380
		public TouchScreenKeyboard keyboardOnScreen = null;

		// Token: 0x0400017D RID: 381
		public int controlID = 0;

		// Token: 0x0400017E RID: 382
		public GUIStyle style = GUIStyle.none;

		// Token: 0x0400017F RID: 383
		public bool multiline = false;

		// Token: 0x04000180 RID: 384
		public bool hasHorizontalCursorPos = false;

		// Token: 0x04000181 RID: 385
		public bool isPasswordField = false;

		// Token: 0x04000182 RID: 386
		internal bool m_HasFocus;

		// Token: 0x04000183 RID: 387
		public Vector2 scrollOffset = Vector2.zero;

		// Token: 0x04000184 RID: 388
		private GUIContent m_Content = new GUIContent();

		// Token: 0x04000185 RID: 389
		private Rect m_Position;

		// Token: 0x04000186 RID: 390
		private int m_CursorIndex = 0;

		// Token: 0x04000187 RID: 391
		private int m_SelectIndex = 0;

		// Token: 0x04000188 RID: 392
		private bool m_RevealCursor = false;

		// Token: 0x04000189 RID: 393
		public Vector2 graphicalCursorPos;

		// Token: 0x0400018A RID: 394
		public Vector2 graphicalSelectCursorPos;

		// Token: 0x0400018B RID: 395
		private bool m_MouseDragSelectsWholeWords = false;

		// Token: 0x0400018C RID: 396
		private int m_DblClickInitPos = 0;

		// Token: 0x0400018D RID: 397
		private TextEditor.DblClickSnapping m_DblClickSnap = TextEditor.DblClickSnapping.WORDS;

		// Token: 0x0400018E RID: 398
		private bool m_bJustSelected = false;

		// Token: 0x0400018F RID: 399
		private int m_iAltCursorPos = -1;

		// Token: 0x04000190 RID: 400
		private string oldText;

		// Token: 0x04000191 RID: 401
		private int oldPos;

		// Token: 0x04000192 RID: 402
		private int oldSelectPos;

		// Token: 0x04000193 RID: 403
		private static Dictionary<Event, TextEditor.TextEditOp> s_Keyactions;

		// Token: 0x02000040 RID: 64
		public enum DblClickSnapping : byte
		{
			// Token: 0x04000195 RID: 405
			WORDS,
			// Token: 0x04000196 RID: 406
			PARAGRAPHS
		}

		// Token: 0x02000041 RID: 65
		private enum CharacterType
		{
			// Token: 0x04000198 RID: 408
			LetterLike,
			// Token: 0x04000199 RID: 409
			Symbol,
			// Token: 0x0400019A RID: 410
			Symbol2,
			// Token: 0x0400019B RID: 411
			WhiteSpace
		}

		// Token: 0x02000042 RID: 66
		private enum Direction
		{
			// Token: 0x0400019D RID: 413
			Forward,
			// Token: 0x0400019E RID: 414
			Backward
		}

		// Token: 0x02000043 RID: 67
		private enum TextEditOp
		{
			// Token: 0x040001A0 RID: 416
			MoveLeft,
			// Token: 0x040001A1 RID: 417
			MoveRight,
			// Token: 0x040001A2 RID: 418
			MoveUp,
			// Token: 0x040001A3 RID: 419
			MoveDown,
			// Token: 0x040001A4 RID: 420
			MoveLineStart,
			// Token: 0x040001A5 RID: 421
			MoveLineEnd,
			// Token: 0x040001A6 RID: 422
			MoveTextStart,
			// Token: 0x040001A7 RID: 423
			MoveTextEnd,
			// Token: 0x040001A8 RID: 424
			MovePageUp,
			// Token: 0x040001A9 RID: 425
			MovePageDown,
			// Token: 0x040001AA RID: 426
			MoveGraphicalLineStart,
			// Token: 0x040001AB RID: 427
			MoveGraphicalLineEnd,
			// Token: 0x040001AC RID: 428
			MoveWordLeft,
			// Token: 0x040001AD RID: 429
			MoveWordRight,
			// Token: 0x040001AE RID: 430
			MoveParagraphForward,
			// Token: 0x040001AF RID: 431
			MoveParagraphBackward,
			// Token: 0x040001B0 RID: 432
			MoveToStartOfNextWord,
			// Token: 0x040001B1 RID: 433
			MoveToEndOfPreviousWord,
			// Token: 0x040001B2 RID: 434
			SelectLeft,
			// Token: 0x040001B3 RID: 435
			SelectRight,
			// Token: 0x040001B4 RID: 436
			SelectUp,
			// Token: 0x040001B5 RID: 437
			SelectDown,
			// Token: 0x040001B6 RID: 438
			SelectTextStart,
			// Token: 0x040001B7 RID: 439
			SelectTextEnd,
			// Token: 0x040001B8 RID: 440
			SelectPageUp,
			// Token: 0x040001B9 RID: 441
			SelectPageDown,
			// Token: 0x040001BA RID: 442
			ExpandSelectGraphicalLineStart,
			// Token: 0x040001BB RID: 443
			ExpandSelectGraphicalLineEnd,
			// Token: 0x040001BC RID: 444
			SelectGraphicalLineStart,
			// Token: 0x040001BD RID: 445
			SelectGraphicalLineEnd,
			// Token: 0x040001BE RID: 446
			SelectWordLeft,
			// Token: 0x040001BF RID: 447
			SelectWordRight,
			// Token: 0x040001C0 RID: 448
			SelectToEndOfPreviousWord,
			// Token: 0x040001C1 RID: 449
			SelectToStartOfNextWord,
			// Token: 0x040001C2 RID: 450
			SelectParagraphBackward,
			// Token: 0x040001C3 RID: 451
			SelectParagraphForward,
			// Token: 0x040001C4 RID: 452
			Delete,
			// Token: 0x040001C5 RID: 453
			Backspace,
			// Token: 0x040001C6 RID: 454
			DeleteWordBack,
			// Token: 0x040001C7 RID: 455
			DeleteWordForward,
			// Token: 0x040001C8 RID: 456
			DeleteLineBack,
			// Token: 0x040001C9 RID: 457
			Cut,
			// Token: 0x040001CA RID: 458
			Copy,
			// Token: 0x040001CB RID: 459
			Paste,
			// Token: 0x040001CC RID: 460
			SelectAll,
			// Token: 0x040001CD RID: 461
			SelectNone,
			// Token: 0x040001CE RID: 462
			ScrollStart,
			// Token: 0x040001CF RID: 463
			ScrollEnd,
			// Token: 0x040001D0 RID: 464
			ScrollPageUp,
			// Token: 0x040001D1 RID: 465
			ScrollPageDown
		}
	}
}
