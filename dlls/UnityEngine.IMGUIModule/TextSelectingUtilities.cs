using System;
using System.Collections.Generic;
using UnityEngine.TextCore.Text;

namespace UnityEngine
{
	// Token: 0x02000044 RID: 68
	internal class TextSelectingUtilities
	{
		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x00013F33 File Offset: 0x00012133
		public bool hasSelection
		{
			get
			{
				return this.cursorIndex != this.selectIndex;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060004D2 RID: 1234 RVA: 0x00013F46 File Offset: 0x00012146
		// (set) Token: 0x060004D3 RID: 1235 RVA: 0x00013F50 File Offset: 0x00012150
		public bool revealCursor
		{
			get
			{
				return this.m_RevealCursor;
			}
			set
			{
				bool flag = this.m_RevealCursor != value;
				if (flag)
				{
					this.m_RevealCursor = value;
					Action onRevealCursorChange = this.OnRevealCursorChange;
					if (onRevealCursorChange != null)
					{
						onRevealCursorChange();
					}
				}
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060004D4 RID: 1236 RVA: 0x00013F89 File Offset: 0x00012189
		private int m_CharacterCount
		{
			get
			{
				return this.m_TextHandle.textInfo.characterCount;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x00013F9C File Offset: 0x0001219C
		private int characterCount
		{
			get
			{
				return (this.m_CharacterCount > 0 && this.m_TextHandle.textInfo.textElementInfo[this.m_CharacterCount - 1].character == '​') ? (this.m_CharacterCount - 1) : this.m_CharacterCount;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x00013FEB File Offset: 0x000121EB
		private TextElementInfo[] m_TextElementInfos
		{
			get
			{
				return this.m_TextHandle.textInfo.textElementInfo;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x00013FFD File Offset: 0x000121FD
		// (set) Token: 0x060004D8 RID: 1240 RVA: 0x0001400C File Offset: 0x0001220C
		public int cursorIndex
		{
			get
			{
				return this.EnsureValidCodePointIndex(this.m_CursorIndex);
			}
			set
			{
				bool flag = this.m_CursorIndex != value;
				if (flag)
				{
					this.SetCursorIndexWithoutNotify(value);
					Action onCursorIndexChange = this.OnCursorIndexChange;
					if (onCursorIndexChange != null)
					{
						onCursorIndexChange();
					}
				}
			}
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00014046 File Offset: 0x00012246
		internal void SetCursorIndexWithoutNotify(int index)
		{
			this.m_CursorIndex = index;
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060004DA RID: 1242 RVA: 0x00014050 File Offset: 0x00012250
		// (set) Token: 0x060004DB RID: 1243 RVA: 0x00014060 File Offset: 0x00012260
		public int selectIndex
		{
			get
			{
				return this.EnsureValidCodePointIndex(this.m_SelectIndex);
			}
			set
			{
				bool flag = this.m_SelectIndex != value;
				if (flag)
				{
					this.SetSelectIndexWithoutNotify(value);
					Action onSelectIndexChange = this.OnSelectIndexChange;
					if (onSelectIndexChange != null)
					{
						onSelectIndexChange();
					}
				}
			}
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0001409A File Offset: 0x0001229A
		internal void SetSelectIndexWithoutNotify(int index)
		{
			this.m_SelectIndex = index;
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060004DD RID: 1245 RVA: 0x000140A4 File Offset: 0x000122A4
		public string selectedText
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
						result = this.m_TextHandle.Substring(this.cursorIndex, this.selectIndex - this.cursorIndex);
					}
					else
					{
						result = this.m_TextHandle.Substring(this.selectIndex, this.cursorIndex - this.selectIndex);
					}
				}
				return result;
			}
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00014124 File Offset: 0x00012324
		public TextSelectingUtilities(TextHandle textHandle)
		{
			this.m_TextHandle = textHandle;
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00014180 File Offset: 0x00012380
		internal bool HandleKeyEvent(Event e)
		{
			this.InitKeyActions();
			EventModifiers modifiers = e.modifiers;
			e.modifiers &= ~EventModifiers.CapsLock;
			bool flag = TextSelectingUtilities.s_KeySelectOps.ContainsKey(e);
			bool result;
			if (flag)
			{
				TextSelectOp operation = TextSelectingUtilities.s_KeySelectOps[e];
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

		// Token: 0x060004E0 RID: 1248 RVA: 0x000141EC File Offset: 0x000123EC
		private bool PerformOperation(TextSelectOp operation)
		{
			switch (operation)
			{
			case TextSelectOp.SelectLeft:
				this.SelectLeft();
				return false;
			case TextSelectOp.SelectRight:
				this.SelectRight();
				return false;
			case TextSelectOp.SelectUp:
				this.SelectUp();
				return false;
			case TextSelectOp.SelectDown:
				this.SelectDown();
				return false;
			case TextSelectOp.SelectTextStart:
				this.SelectTextStart();
				return false;
			case TextSelectOp.SelectTextEnd:
				this.SelectTextEnd();
				return false;
			case TextSelectOp.ExpandSelectGraphicalLineStart:
				this.ExpandSelectGraphicalLineStart();
				return false;
			case TextSelectOp.ExpandSelectGraphicalLineEnd:
				this.ExpandSelectGraphicalLineEnd();
				return false;
			case TextSelectOp.SelectGraphicalLineStart:
				this.SelectGraphicalLineStart();
				return false;
			case TextSelectOp.SelectGraphicalLineEnd:
				this.SelectGraphicalLineEnd();
				return false;
			case TextSelectOp.SelectWordLeft:
				this.SelectWordLeft();
				return false;
			case TextSelectOp.SelectWordRight:
				this.SelectWordRight();
				return false;
			case TextSelectOp.SelectToEndOfPreviousWord:
				this.SelectToEndOfPreviousWord();
				return false;
			case TextSelectOp.SelectToStartOfNextWord:
				this.SelectToStartOfNextWord();
				return false;
			case TextSelectOp.SelectParagraphBackward:
				this.SelectParagraphBackward();
				return false;
			case TextSelectOp.SelectParagraphForward:
				this.SelectParagraphForward();
				return false;
			case TextSelectOp.Copy:
				this.Copy();
				return false;
			case TextSelectOp.SelectAll:
				this.SelectAll();
				return false;
			case TextSelectOp.SelectNone:
				this.SelectNone();
				return false;
			}
			Debug.Log("Unimplemented: " + operation.ToString());
			return false;
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00014344 File Offset: 0x00012544
		private static void MapKey(string key, TextSelectOp action)
		{
			TextSelectingUtilities.s_KeySelectOps[Event.KeyboardEvent(key)] = action;
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x0001435C File Offset: 0x0001255C
		private void InitKeyActions()
		{
			bool flag = TextSelectingUtilities.s_KeySelectOps != null;
			if (!flag)
			{
				TextSelectingUtilities.s_KeySelectOps = new Dictionary<Event, TextSelectOp>();
				TextSelectingUtilities.MapKey("#left", TextSelectOp.SelectLeft);
				TextSelectingUtilities.MapKey("#right", TextSelectOp.SelectRight);
				TextSelectingUtilities.MapKey("#up", TextSelectOp.SelectUp);
				TextSelectingUtilities.MapKey("#down", TextSelectOp.SelectDown);
				bool flag2 = SystemInfo.operatingSystemFamily == OperatingSystemFamily.MacOSX;
				if (flag2)
				{
					TextSelectingUtilities.MapKey("#home", TextSelectOp.SelectTextStart);
					TextSelectingUtilities.MapKey("#end", TextSelectOp.SelectTextEnd);
					TextSelectingUtilities.MapKey("#^left", TextSelectOp.ExpandSelectGraphicalLineStart);
					TextSelectingUtilities.MapKey("#^right", TextSelectOp.ExpandSelectGraphicalLineEnd);
					TextSelectingUtilities.MapKey("#^up", TextSelectOp.SelectParagraphBackward);
					TextSelectingUtilities.MapKey("#^down", TextSelectOp.SelectParagraphForward);
					TextSelectingUtilities.MapKey("#&left", TextSelectOp.SelectWordLeft);
					TextSelectingUtilities.MapKey("#&right", TextSelectOp.SelectWordRight);
					TextSelectingUtilities.MapKey("#&up", TextSelectOp.SelectParagraphBackward);
					TextSelectingUtilities.MapKey("#&down", TextSelectOp.SelectParagraphForward);
					TextSelectingUtilities.MapKey("#%left", TextSelectOp.ExpandSelectGraphicalLineStart);
					TextSelectingUtilities.MapKey("#%right", TextSelectOp.ExpandSelectGraphicalLineEnd);
					TextSelectingUtilities.MapKey("#%up", TextSelectOp.SelectTextStart);
					TextSelectingUtilities.MapKey("#%down", TextSelectOp.SelectTextEnd);
					TextSelectingUtilities.MapKey("%a", TextSelectOp.SelectAll);
					TextSelectingUtilities.MapKey("%c", TextSelectOp.Copy);
				}
				else
				{
					TextSelectingUtilities.MapKey("#^left", TextSelectOp.SelectToEndOfPreviousWord);
					TextSelectingUtilities.MapKey("#^right", TextSelectOp.SelectToStartOfNextWord);
					TextSelectingUtilities.MapKey("#^up", TextSelectOp.SelectParagraphBackward);
					TextSelectingUtilities.MapKey("#^down", TextSelectOp.SelectParagraphForward);
					TextSelectingUtilities.MapKey("#home", TextSelectOp.SelectGraphicalLineStart);
					TextSelectingUtilities.MapKey("#end", TextSelectOp.SelectGraphicalLineEnd);
					TextSelectingUtilities.MapKey("^a", TextSelectOp.SelectAll);
					TextSelectingUtilities.MapKey("^c", TextSelectOp.Copy);
					TextSelectingUtilities.MapKey("^insert", TextSelectOp.Copy);
				}
			}
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00014509 File Offset: 0x00012709
		public void ClearCursorPos()
		{
			this.hasHorizontalCursorPos = false;
			this.iAltCursorPos = -1;
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x0001451C File Offset: 0x0001271C
		public void OnFocus(bool selectAll = true)
		{
			if (selectAll)
			{
				this.SelectAll();
			}
			this.revealCursor = true;
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x0001453E File Offset: 0x0001273E
		public void SelectAll()
		{
			this.cursorIndex = 0;
			this.selectIndex = int.MaxValue;
			this.ClearCursorPos();
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x0001455C File Offset: 0x0001275C
		public void SelectNone()
		{
			this.selectIndex = this.cursorIndex;
			this.ClearCursorPos();
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x00014574 File Offset: 0x00012774
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

		// Token: 0x060004E8 RID: 1256 RVA: 0x000145D8 File Offset: 0x000127D8
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

		// Token: 0x060004E9 RID: 1257 RVA: 0x0001463A File Offset: 0x0001283A
		public void SelectUp()
		{
			this.cursorIndex = this.m_TextHandle.LineUpCharacterPosition(this.cursorIndex);
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x00014655 File Offset: 0x00012855
		public void SelectDown()
		{
			this.cursorIndex = this.m_TextHandle.LineDownCharacterPosition(this.cursorIndex);
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x00014670 File Offset: 0x00012870
		public void SelectTextEnd()
		{
			this.cursorIndex = this.characterCount;
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x00014680 File Offset: 0x00012880
		public void SelectTextStart()
		{
			this.cursorIndex = 0;
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x0001468B File Offset: 0x0001288B
		public void SelectToStartOfNextWord()
		{
			this.ClearCursorPos();
			this.cursorIndex = this.FindStartOfNextWord(this.cursorIndex);
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x000146A8 File Offset: 0x000128A8
		public void SelectToEndOfPreviousWord()
		{
			this.ClearCursorPos();
			this.cursorIndex = this.FindEndOfPreviousWord(this.cursorIndex);
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x000146C8 File Offset: 0x000128C8
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

		// Token: 0x060004F0 RID: 1264 RVA: 0x00014754 File Offset: 0x00012954
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

		// Token: 0x060004F1 RID: 1265 RVA: 0x000147E0 File Offset: 0x000129E0
		public void SelectGraphicalLineStart()
		{
			this.ClearCursorPos();
			this.cursorIndex = this.GetGraphicalLineStart(this.cursorIndex);
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x000147FD File Offset: 0x000129FD
		public void SelectGraphicalLineEnd()
		{
			this.ClearCursorPos();
			this.cursorIndex = this.GetGraphicalLineEnd(this.cursorIndex);
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x0001481C File Offset: 0x00012A1C
		public void SelectParagraphForward()
		{
			this.ClearCursorPos();
			bool flag = this.cursorIndex < this.selectIndex;
			bool flag2 = this.cursorIndex < this.characterCount;
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

		// Token: 0x060004F4 RID: 1268 RVA: 0x00014890 File Offset: 0x00012A90
		public void SelectParagraphBackward()
		{
			this.ClearCursorPos();
			bool flag = this.cursorIndex > this.selectIndex;
			bool flag2 = this.cursorIndex > 1;
			if (flag2)
			{
				this.cursorIndex = this.m_TextHandle.LastIndexOf('\n', this.cursorIndex - 2) + 1;
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

		// Token: 0x060004F5 RID: 1269 RVA: 0x0001491C File Offset: 0x00012B1C
		public void SelectCurrentWord()
		{
			int cursorIndex = this.cursorIndex;
			bool flag = this.cursorIndex < this.selectIndex;
			if (flag)
			{
				this.cursorIndex = this.FindEndOfClassification(cursorIndex, TextSelectingUtilities.Direction.Backward);
				this.selectIndex = this.FindEndOfClassification(cursorIndex, TextSelectingUtilities.Direction.Forward);
			}
			else
			{
				this.cursorIndex = this.FindEndOfClassification(cursorIndex, TextSelectingUtilities.Direction.Forward);
				this.selectIndex = this.FindEndOfClassification(cursorIndex, TextSelectingUtilities.Direction.Backward);
			}
			this.ClearCursorPos();
			this.m_bJustSelected = true;
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00014994 File Offset: 0x00012B94
		public void SelectCurrentParagraph()
		{
			this.ClearCursorPos();
			int characterCount = this.characterCount;
			bool flag = this.cursorIndex < characterCount;
			if (flag)
			{
				this.cursorIndex = this.IndexOfEndOfLine(this.cursorIndex);
			}
			bool flag2 = this.selectIndex != 0;
			if (flag2)
			{
				this.selectIndex = this.m_TextHandle.LastIndexOf('\n', this.selectIndex - 1) + 1;
			}
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x000149FC File Offset: 0x00012BFC
		public void MoveRight()
		{
			this.ClearCursorPos();
			bool flag = this.selectIndex == this.cursorIndex;
			if (flag)
			{
				this.cursorIndex = this.NextCodePointIndex(this.cursorIndex);
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

		// Token: 0x060004F8 RID: 1272 RVA: 0x00014A78 File Offset: 0x00012C78
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

		// Token: 0x060004F9 RID: 1273 RVA: 0x00014AF4 File Offset: 0x00012CF4
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
			this.cursorIndex = (this.selectIndex = this.m_TextHandle.LineUpCharacterPosition(this.cursorIndex));
			bool flag2 = this.cursorIndex <= 0;
			if (flag2)
			{
				this.ClearCursorPos();
			}
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x00014B6C File Offset: 0x00012D6C
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
			this.cursorIndex = (this.selectIndex = this.m_TextHandle.LineDownCharacterPosition(this.cursorIndex));
			bool flag2 = this.cursorIndex == this.characterCount;
			if (flag2)
			{
				this.ClearCursorPos();
			}
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x00014BE4 File Offset: 0x00012DE4
		public void MoveLineStart()
		{
			int num = (this.selectIndex < this.cursorIndex) ? this.selectIndex : this.cursorIndex;
			int num2 = num;
			while (num2-- != 0)
			{
				bool flag = this.m_TextElementInfos[num2].character == '\n';
				if (flag)
				{
					this.selectIndex = (this.cursorIndex = num2 + 1);
					return;
				}
			}
			this.selectIndex = (this.cursorIndex = 0);
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00014C64 File Offset: 0x00012E64
		public void MoveLineEnd()
		{
			int num = (this.selectIndex > this.cursorIndex) ? this.selectIndex : this.cursorIndex;
			int i = num;
			int characterCount = this.characterCount;
			while (i < characterCount)
			{
				bool flag = this.m_TextElementInfos[i].character == '\n';
				if (flag)
				{
					this.selectIndex = (this.cursorIndex = i);
					return;
				}
				i++;
			}
			this.selectIndex = (this.cursorIndex = characterCount);
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00014CF0 File Offset: 0x00012EF0
		public void MoveGraphicalLineStart()
		{
			this.cursorIndex = (this.selectIndex = this.GetGraphicalLineStart((this.cursorIndex < this.selectIndex) ? this.cursorIndex : this.selectIndex));
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00014D34 File Offset: 0x00012F34
		public void MoveGraphicalLineEnd()
		{
			this.cursorIndex = (this.selectIndex = this.GetGraphicalLineEnd((this.cursorIndex > this.selectIndex) ? this.cursorIndex : this.selectIndex));
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00014D78 File Offset: 0x00012F78
		public void MoveTextStart()
		{
			this.selectIndex = (this.cursorIndex = 0);
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00014D98 File Offset: 0x00012F98
		public void MoveTextEnd()
		{
			this.selectIndex = (this.cursorIndex = this.characterCount);
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x00014DC0 File Offset: 0x00012FC0
		public void MoveParagraphForward()
		{
			this.cursorIndex = ((this.cursorIndex > this.selectIndex) ? this.cursorIndex : this.selectIndex);
			bool flag = this.cursorIndex < this.characterCount;
			if (flag)
			{
				this.selectIndex = (this.cursorIndex = this.IndexOfEndOfLine(this.cursorIndex + 1));
			}
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x00014E24 File Offset: 0x00013024
		public void MoveParagraphBackward()
		{
			this.cursorIndex = ((this.cursorIndex < this.selectIndex) ? this.cursorIndex : this.selectIndex);
			bool flag = this.cursorIndex > 1;
			if (flag)
			{
				this.selectIndex = (this.cursorIndex = this.m_TextHandle.LastIndexOf('\n', this.cursorIndex - 2) + 1);
			}
			else
			{
				this.selectIndex = (this.cursorIndex = 0);
			}
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x00014EA0 File Offset: 0x000130A0
		public void MoveWordRight()
		{
			this.cursorIndex = ((this.cursorIndex > this.selectIndex) ? this.cursorIndex : this.selectIndex);
			this.cursorIndex = (this.selectIndex = this.FindNextSeperator(this.cursorIndex));
			this.ClearCursorPos();
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x00014EF8 File Offset: 0x000130F8
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

		// Token: 0x06000505 RID: 1285 RVA: 0x00014F4C File Offset: 0x0001314C
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

		// Token: 0x06000506 RID: 1286 RVA: 0x00014FA0 File Offset: 0x000131A0
		public void MoveWordLeft()
		{
			this.cursorIndex = ((this.cursorIndex < this.selectIndex) ? this.cursorIndex : this.selectIndex);
			this.cursorIndex = this.FindPrevSeperator(this.cursorIndex);
			this.selectIndex = this.cursorIndex;
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x00014FF4 File Offset: 0x000131F4
		public void MouseDragSelectsWholeWords(bool on)
		{
			this.m_MouseDragSelectsWholeWords = on;
			this.m_DblClickInitPosStart = ((this.cursorIndex < this.selectIndex) ? this.cursorIndex : this.selectIndex);
			this.m_DblClickInitPosEnd = ((this.cursorIndex < this.selectIndex) ? this.selectIndex : this.cursorIndex);
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x00015050 File Offset: 0x00013250
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

		// Token: 0x06000509 RID: 1289 RVA: 0x000150B0 File Offset: 0x000132B0
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

		// Token: 0x0600050A RID: 1290 RVA: 0x00015110 File Offset: 0x00013310
		public void DblClickSnap(TextEditor.DblClickSnapping snapping)
		{
			this.dblClickSnap = snapping;
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x0001511C File Offset: 0x0001331C
		protected internal void MoveCursorToPosition_Internal(Vector2 cursorPosition, bool shift)
		{
			this.selectIndex = this.m_TextHandle.GetCursorIndexFromPosition(cursorPosition, true);
			bool flag = !shift;
			if (flag)
			{
				this.cursorIndex = this.selectIndex;
			}
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x00015158 File Offset: 0x00013358
		public void SelectToPosition(Vector2 cursorPosition)
		{
			bool flag = this.characterCount == 0;
			if (!flag)
			{
				bool flag2 = !this.m_MouseDragSelectsWholeWords;
				if (flag2)
				{
					this.cursorIndex = this.m_TextHandle.GetCursorIndexFromPosition(cursorPosition, true);
				}
				else
				{
					int num = this.m_TextHandle.GetCursorIndexFromPosition(cursorPosition, true);
					num = this.EnsureValidCodePointIndex(num);
					bool flag3 = this.dblClickSnap == TextEditor.DblClickSnapping.WORDS;
					if (flag3)
					{
						bool flag4 = num <= this.m_DblClickInitPosStart;
						if (flag4)
						{
							this.cursorIndex = this.FindEndOfClassification(num, TextSelectingUtilities.Direction.Backward);
							this.selectIndex = this.FindEndOfClassification(this.m_DblClickInitPosEnd - 1, TextSelectingUtilities.Direction.Forward);
						}
						else
						{
							bool flag5 = num >= this.m_DblClickInitPosEnd;
							if (flag5)
							{
								this.cursorIndex = this.FindEndOfClassification(num - 1, TextSelectingUtilities.Direction.Forward);
								this.selectIndex = this.FindEndOfClassification(this.m_DblClickInitPosStart + 1, TextSelectingUtilities.Direction.Backward);
							}
							else
							{
								this.cursorIndex = this.m_DblClickInitPosStart;
								this.selectIndex = this.m_DblClickInitPosEnd;
							}
						}
					}
					else
					{
						bool flag6 = num <= this.m_DblClickInitPosStart;
						if (flag6)
						{
							bool flag7 = num > 0;
							if (flag7)
							{
								this.cursorIndex = this.m_TextHandle.LastIndexOf('\n', Mathf.Max(0, num - 1)) + 1;
							}
							else
							{
								this.cursorIndex = 0;
							}
							this.selectIndex = this.m_TextHandle.LastIndexOf('\n', Mathf.Min(this.characterCount - 1, this.m_DblClickInitPosEnd + 1));
						}
						else
						{
							bool flag8 = num >= this.m_DblClickInitPosEnd;
							if (flag8)
							{
								bool flag9 = num < this.characterCount;
								if (flag9)
								{
									this.cursorIndex = this.IndexOfEndOfLine(num);
								}
								else
								{
									this.cursorIndex = this.characterCount;
								}
								this.selectIndex = this.m_TextHandle.LastIndexOf('\n', Mathf.Max(0, this.m_DblClickInitPosEnd - 2)) + 1;
							}
							else
							{
								this.cursorIndex = this.m_DblClickInitPosStart;
								this.selectIndex = this.m_DblClickInitPosEnd;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x0001535C File Offset: 0x0001355C
		private int FindNextSeperator(int startPos)
		{
			int characterCount = this.characterCount;
			while (startPos < characterCount && this.ClassifyChar(startPos) > TextSelectingUtilities.CharacterType.LetterLike)
			{
				startPos = this.NextCodePointIndex(startPos);
			}
			while (startPos < characterCount && this.ClassifyChar(startPos) == TextSelectingUtilities.CharacterType.LetterLike)
			{
				startPos = this.NextCodePointIndex(startPos);
			}
			return startPos;
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x000153B8 File Offset: 0x000135B8
		private int FindPrevSeperator(int startPos)
		{
			startPos = this.PreviousCodePointIndex(startPos);
			while (startPos > 0 && this.ClassifyChar(startPos) > TextSelectingUtilities.CharacterType.LetterLike)
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
				while (startPos > 0 && this.ClassifyChar(startPos) == TextSelectingUtilities.CharacterType.LetterLike)
				{
					startPos = this.PreviousCodePointIndex(startPos);
				}
				bool flag2 = this.ClassifyChar(startPos) == TextSelectingUtilities.CharacterType.LetterLike;
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

		// Token: 0x0600050F RID: 1295 RVA: 0x0001543C File Offset: 0x0001363C
		public int FindStartOfNextWord(int p)
		{
			int characterCount = this.characterCount;
			bool flag = p == characterCount;
			int result;
			if (flag)
			{
				result = p;
			}
			else
			{
				TextSelectingUtilities.CharacterType characterType = this.ClassifyChar(p);
				bool flag2 = characterType != TextSelectingUtilities.CharacterType.WhiteSpace;
				if (flag2)
				{
					p = this.NextCodePointIndex(p);
					while (p < characterCount && this.ClassifyChar(p) == characterType)
					{
						p = this.NextCodePointIndex(p);
					}
				}
				else
				{
					bool flag3 = this.m_TextElementInfos[p].character == '\t' || this.m_TextElementInfos[p].character == '\n';
					if (flag3)
					{
						return this.NextCodePointIndex(p);
					}
				}
				bool flag4 = p == characterCount;
				if (flag4)
				{
					result = p;
				}
				else
				{
					bool flag5 = this.m_TextElementInfos[p].character == ' ';
					if (flag5)
					{
						while (p < characterCount && this.ClassifyChar(p) == TextSelectingUtilities.CharacterType.WhiteSpace)
						{
							p = this.NextCodePointIndex(p);
						}
					}
					else
					{
						bool flag6 = this.m_TextElementInfos[p].character == '\t' || this.m_TextElementInfos[p].character == '\n';
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

		// Token: 0x06000510 RID: 1296 RVA: 0x00015574 File Offset: 0x00013774
		public int FindEndOfPreviousWord(int p)
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
				while (p > 0 && this.m_TextElementInfos[p].character == ' ')
				{
					p = this.PreviousCodePointIndex(p);
				}
				TextSelectingUtilities.CharacterType characterType = this.ClassifyChar(p);
				bool flag2 = characterType != TextSelectingUtilities.CharacterType.WhiteSpace;
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

		// Token: 0x06000511 RID: 1297 RVA: 0x00015608 File Offset: 0x00013808
		private int FindEndOfClassification(int p, TextSelectingUtilities.Direction dir)
		{
			bool flag = this.characterCount == 0;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				bool flag2 = p == this.characterCount;
				if (flag2)
				{
					p = this.PreviousCodePointIndex(p);
				}
				TextSelectingUtilities.CharacterType characterType = this.ClassifyChar(p);
				bool flag3 = characterType == TextSelectingUtilities.CharacterType.NewLine;
				if (flag3)
				{
					result = p;
				}
				else
				{
					for (;;)
					{
						if (dir != TextSelectingUtilities.Direction.Forward)
						{
							if (dir == TextSelectingUtilities.Direction.Backward)
							{
								p = this.PreviousCodePointIndex(p);
								bool flag4 = p == 0;
								if (flag4)
								{
									break;
								}
							}
						}
						else
						{
							p = this.NextCodePointIndex(p);
							bool flag5 = p == this.characterCount;
							if (flag5)
							{
								goto Block_8;
							}
						}
						if (this.ClassifyChar(p) != characterType)
						{
							goto Block_9;
						}
					}
					return (this.ClassifyChar(0) == characterType) ? 0 : this.NextCodePointIndex(0);
					Block_8:
					return this.characterCount;
					Block_9:
					bool flag6 = dir == TextSelectingUtilities.Direction.Forward;
					if (flag6)
					{
						result = p;
					}
					else
					{
						result = this.NextCodePointIndex(p);
					}
				}
			}
			return result;
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x000156E8 File Offset: 0x000138E8
		private int ClampTextIndex(int index)
		{
			return Mathf.Clamp(index, 0, this.characterCount);
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x00015708 File Offset: 0x00013908
		internal int EnsureValidCodePointIndex(int index)
		{
			index = this.ClampTextIndex(index);
			bool flag = !this.IsValidCodePointIndex(index);
			if (flag)
			{
				index = this.NextCodePointIndex(index);
			}
			return index;
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x0001573C File Offset: 0x0001393C
		private bool IsValidCodePointIndex(int index)
		{
			bool flag = index < 0 || index > this.characterCount;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = index == 0 || index == this.characterCount;
				result = (flag2 || !char.IsLowSurrogate(this.m_TextElementInfos[index].character));
			}
			return result;
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x00015798 File Offset: 0x00013998
		private int IndexOfEndOfLine(int startIndex)
		{
			int num = this.m_TextHandle.IndexOf('\n', startIndex);
			return (num != -1) ? num : this.characterCount;
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x000157C8 File Offset: 0x000139C8
		public int PreviousCodePointIndex(int index)
		{
			bool flag = index > 0;
			if (flag)
			{
				index--;
			}
			while (index > 0 && char.IsLowSurrogate(this.m_TextElementInfos[index].character))
			{
				index--;
			}
			return index;
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x00015810 File Offset: 0x00013A10
		public int NextCodePointIndex(int index)
		{
			bool flag = index < this.characterCount;
			if (flag)
			{
				index++;
			}
			while (index < this.characterCount && char.IsLowSurrogate(this.m_TextElementInfos[index].character))
			{
				index++;
			}
			return index;
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x00015864 File Offset: 0x00013A64
		private int GetGraphicalLineStart(int p)
		{
			Vector2 cursorPositionFromStringIndexUsingLineHeight = this.m_TextHandle.GetCursorPositionFromStringIndexUsingLineHeight(p, false, true);
			cursorPositionFromStringIndexUsingLineHeight.y -= 1f / GUIUtility.pixelsPerPoint;
			cursorPositionFromStringIndexUsingLineHeight.x = 0f;
			return this.m_TextHandle.GetCursorIndexFromPosition(cursorPositionFromStringIndexUsingLineHeight, true);
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x000158B4 File Offset: 0x00013AB4
		private int GetGraphicalLineEnd(int p)
		{
			Vector2 cursorPositionFromStringIndexUsingLineHeight = this.m_TextHandle.GetCursorPositionFromStringIndexUsingLineHeight(p, false, true);
			cursorPositionFromStringIndexUsingLineHeight.y -= 1f / GUIUtility.pixelsPerPoint;
			cursorPositionFromStringIndexUsingLineHeight.x += 5000f;
			return this.m_TextHandle.GetCursorIndexFromPosition(cursorPositionFromStringIndexUsingLineHeight, true);
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x00015908 File Offset: 0x00013B08
		public void Copy()
		{
			bool flag = this.selectIndex == this.cursorIndex;
			if (!flag)
			{
				GUIUtility.systemCopyBuffer = this.selectedText;
			}
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x00015938 File Offset: 0x00013B38
		private TextSelectingUtilities.CharacterType ClassifyChar(int index)
		{
			char character = this.m_TextElementInfos[index].character;
			bool flag = character == '\n';
			TextSelectingUtilities.CharacterType result;
			if (flag)
			{
				result = TextSelectingUtilities.CharacterType.NewLine;
			}
			else
			{
				bool flag2 = char.IsWhiteSpace(character);
				if (flag2)
				{
					result = TextSelectingUtilities.CharacterType.WhiteSpace;
				}
				else
				{
					bool flag3 = char.IsLetterOrDigit(character) || this.m_TextElementInfos[index].character == '\'';
					if (flag3)
					{
						result = TextSelectingUtilities.CharacterType.LetterLike;
					}
					else
					{
						result = TextSelectingUtilities.CharacterType.Symbol;
					}
				}
			}
			return result;
		}

		// Token: 0x040001D2 RID: 466
		public TextEditor.DblClickSnapping dblClickSnap = TextEditor.DblClickSnapping.WORDS;

		// Token: 0x040001D3 RID: 467
		public int iAltCursorPos = -1;

		// Token: 0x040001D4 RID: 468
		public bool hasHorizontalCursorPos = false;

		// Token: 0x040001D5 RID: 469
		private bool m_bJustSelected = false;

		// Token: 0x040001D6 RID: 470
		private bool m_MouseDragSelectsWholeWords = false;

		// Token: 0x040001D7 RID: 471
		private int m_DblClickInitPosStart = 0;

		// Token: 0x040001D8 RID: 472
		private int m_DblClickInitPosEnd = 0;

		// Token: 0x040001D9 RID: 473
		private TextHandle m_TextHandle;

		// Token: 0x040001DA RID: 474
		private const int kMoveDownHeight = 5;

		// Token: 0x040001DB RID: 475
		private const char kNewLineChar = '\n';

		// Token: 0x040001DC RID: 476
		private bool m_RevealCursor;

		// Token: 0x040001DD RID: 477
		private int m_CursorIndex = 0;

		// Token: 0x040001DE RID: 478
		internal int m_SelectIndex = 0;

		// Token: 0x040001DF RID: 479
		private static Dictionary<Event, TextSelectOp> s_KeySelectOps;

		// Token: 0x040001E0 RID: 480
		internal Action OnCursorIndexChange;

		// Token: 0x040001E1 RID: 481
		internal Action OnSelectIndexChange;

		// Token: 0x040001E2 RID: 482
		internal Action OnRevealCursorChange;

		// Token: 0x02000045 RID: 69
		private enum CharacterType
		{
			// Token: 0x040001E4 RID: 484
			LetterLike,
			// Token: 0x040001E5 RID: 485
			Symbol,
			// Token: 0x040001E6 RID: 486
			Symbol2,
			// Token: 0x040001E7 RID: 487
			WhiteSpace,
			// Token: 0x040001E8 RID: 488
			NewLine
		}

		// Token: 0x02000046 RID: 70
		private enum Direction
		{
			// Token: 0x040001EA RID: 490
			Forward,
			// Token: 0x040001EB RID: 491
			Backward
		}
	}
}
