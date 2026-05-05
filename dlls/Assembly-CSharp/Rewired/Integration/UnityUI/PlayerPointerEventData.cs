using System;
using System.Text;
using Rewired.UI;
using UnityEngine.EventSystems;

namespace Rewired.Integration.UnityUI
{
	// Token: 0x02000290 RID: 656
	public class PlayerPointerEventData : PointerEventData
	{
		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x06000D12 RID: 3346 RVA: 0x00047D27 File Offset: 0x00045F27
		// (set) Token: 0x06000D13 RID: 3347 RVA: 0x00047D2F File Offset: 0x00045F2F
		public int playerId { get; set; }

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x06000D14 RID: 3348 RVA: 0x00047D38 File Offset: 0x00045F38
		// (set) Token: 0x06000D15 RID: 3349 RVA: 0x00047D40 File Offset: 0x00045F40
		public int inputSourceIndex { get; set; }

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x06000D16 RID: 3350 RVA: 0x00047D49 File Offset: 0x00045F49
		// (set) Token: 0x06000D17 RID: 3351 RVA: 0x00047D51 File Offset: 0x00045F51
		public IMouseInputSource mouseSource { get; set; }

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x06000D18 RID: 3352 RVA: 0x00047D5A File Offset: 0x00045F5A
		// (set) Token: 0x06000D19 RID: 3353 RVA: 0x00047D62 File Offset: 0x00045F62
		public ITouchInputSource touchSource { get; set; }

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x06000D1A RID: 3354 RVA: 0x00047D6B File Offset: 0x00045F6B
		// (set) Token: 0x06000D1B RID: 3355 RVA: 0x00047D73 File Offset: 0x00045F73
		public PointerEventType sourceType { get; set; }

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x06000D1C RID: 3356 RVA: 0x00047D7C File Offset: 0x00045F7C
		// (set) Token: 0x06000D1D RID: 3357 RVA: 0x00047D84 File Offset: 0x00045F84
		public int buttonIndex { get; set; }

		// Token: 0x06000D1E RID: 3358 RVA: 0x00047D8D File Offset: 0x00045F8D
		public PlayerPointerEventData(EventSystem eventSystem) : base(eventSystem)
		{
			this.playerId = -1;
			this.inputSourceIndex = -1;
			this.buttonIndex = -1;
		}

		// Token: 0x06000D1F RID: 3359 RVA: 0x00047DAC File Offset: 0x00045FAC
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("<b>Player Id</b>: " + this.playerId.ToString());
			string str = "<b>Mouse Source</b>: ";
			IMouseInputSource mouseSource = this.mouseSource;
			stringBuilder.AppendLine(str + ((mouseSource != null) ? mouseSource.ToString() : null));
			stringBuilder.AppendLine("<b>Input Source Index</b>: " + this.inputSourceIndex.ToString());
			string str2 = "<b>Touch Source/b>: ";
			ITouchInputSource touchSource = this.touchSource;
			stringBuilder.AppendLine(str2 + ((touchSource != null) ? touchSource.ToString() : null));
			stringBuilder.AppendLine("<b>Source Type</b>: " + this.sourceType.ToString());
			stringBuilder.AppendLine("<b>Button Index</b>: " + this.buttonIndex.ToString());
			stringBuilder.Append(base.ToString());
			return stringBuilder.ToString();
		}
	}
}
