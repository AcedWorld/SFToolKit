using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000375 RID: 885
	public interface ITextSelection
	{
		// Token: 0x17000703 RID: 1795
		// (get) Token: 0x06001DD3 RID: 7635
		// (set) Token: 0x06001DD4 RID: 7636
		bool isSelectable { get; set; }

		// Token: 0x17000704 RID: 1796
		// (get) Token: 0x06001DD5 RID: 7637
		// (set) Token: 0x06001DD6 RID: 7638
		Color cursorColor { get; set; }

		// Token: 0x17000705 RID: 1797
		// (get) Token: 0x06001DD7 RID: 7639
		// (set) Token: 0x06001DD8 RID: 7640
		int cursorIndex { get; set; }

		// Token: 0x17000706 RID: 1798
		// (get) Token: 0x06001DD9 RID: 7641
		// (set) Token: 0x06001DDA RID: 7642
		bool doubleClickSelectsWord { get; set; }

		// Token: 0x17000707 RID: 1799
		// (get) Token: 0x06001DDB RID: 7643
		// (set) Token: 0x06001DDC RID: 7644
		int selectIndex { get; set; }

		// Token: 0x17000708 RID: 1800
		// (get) Token: 0x06001DDD RID: 7645
		// (set) Token: 0x06001DDE RID: 7646
		Color selectionColor { get; set; }

		// Token: 0x17000709 RID: 1801
		// (get) Token: 0x06001DDF RID: 7647
		// (set) Token: 0x06001DE0 RID: 7648
		bool tripleClickSelectsLine { get; set; }

		// Token: 0x06001DE1 RID: 7649
		bool HasSelection();

		// Token: 0x06001DE2 RID: 7650
		void SelectAll();

		// Token: 0x06001DE3 RID: 7651
		void SelectNone();

		// Token: 0x06001DE4 RID: 7652
		void SelectRange(int cursorIndex, int selectionIndex);

		// Token: 0x1700070A RID: 1802
		// (get) Token: 0x06001DE5 RID: 7653
		// (set) Token: 0x06001DE6 RID: 7654
		bool selectAllOnFocus { get; set; }

		// Token: 0x1700070B RID: 1803
		// (get) Token: 0x06001DE7 RID: 7655
		// (set) Token: 0x06001DE8 RID: 7656
		bool selectAllOnMouseUp { get; set; }

		// Token: 0x1700070C RID: 1804
		// (get) Token: 0x06001DE9 RID: 7657
		Vector2 cursorPosition { get; }

		// Token: 0x1700070D RID: 1805
		// (get) Token: 0x06001DEA RID: 7658
		float lineHeightAtCursorPosition { get; }

		// Token: 0x1700070E RID: 1806
		// (get) Token: 0x06001DEB RID: 7659
		// (set) Token: 0x06001DEC RID: 7660
		float cursorWidth { get; set; }

		// Token: 0x06001DED RID: 7661
		void MoveTextEnd();
	}
}
