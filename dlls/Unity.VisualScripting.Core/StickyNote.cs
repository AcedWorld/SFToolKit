using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000143 RID: 323
	public class StickyNote : GraphElement<IGraph>
	{
		// Token: 0x1700019D RID: 413
		// (get) Token: 0x060008B1 RID: 2225 RVA: 0x0002646B File Offset: 0x0002466B
		// (set) Token: 0x060008B2 RID: 2226 RVA: 0x00026473 File Offset: 0x00024673
		[Serialize]
		public Rect position { get; set; }

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x060008B3 RID: 2227 RVA: 0x0002647C File Offset: 0x0002467C
		// (set) Token: 0x060008B4 RID: 2228 RVA: 0x00026484 File Offset: 0x00024684
		[Serialize]
		public string title { get; set; } = "Sticky Note";

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x060008B5 RID: 2229 RVA: 0x0002648D File Offset: 0x0002468D
		// (set) Token: 0x060008B6 RID: 2230 RVA: 0x00026495 File Offset: 0x00024695
		[Serialize]
		[InspectorTextArea(minLines = 1f)]
		public string body { get; set; }

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x060008B7 RID: 2231 RVA: 0x0002649E File Offset: 0x0002469E
		// (set) Token: 0x060008B8 RID: 2232 RVA: 0x000264A6 File Offset: 0x000246A6
		[Serialize]
		[Inspectable]
		public StickyNote.ColorEnum colorTheme { get; set; }

		// Token: 0x060008B9 RID: 2233 RVA: 0x000264B0 File Offset: 0x000246B0
		public static Color GetStickyColor(StickyNote.ColorEnum enumValue)
		{
			switch (enumValue)
			{
			case StickyNote.ColorEnum.Black:
				return new Color(0.122f, 0.114f, 0.09f);
			case StickyNote.ColorEnum.Dark:
				return new Color(0.184f, 0.145f, 0.024f);
			case StickyNote.ColorEnum.Orange:
				return new Color(0.988f, 0.663f, 0.275f);
			case StickyNote.ColorEnum.Green:
				return new Color(0.376f, 0.886f, 0.655f);
			case StickyNote.ColorEnum.Blue:
				return new Color(0.518f, 0.725f, 0.855f);
			case StickyNote.ColorEnum.Red:
				return new Color(1f, 0.502f, 0.502f);
			case StickyNote.ColorEnum.Purple:
				return new Color(0.98f, 0.769f, 0.949f);
			case StickyNote.ColorEnum.Teal:
				return new Color(0.475f, 0.878f, 0.89f);
			default:
				return new Color(0.969f, 0.91f, 0.624f);
			}
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x000265A6 File Offset: 0x000247A6
		public static Color GetFontColor(StickyNote.ColorEnum enumValue)
		{
			if (enumValue - StickyNote.ColorEnum.Black <= 1)
			{
				return Color.white;
			}
			return Color.black;
		}

		// Token: 0x04000213 RID: 531
		[DoNotSerialize]
		public static readonly Color defaultColor = new Color(0.969f, 0.91f, 0.624f);

		// Token: 0x02000205 RID: 517
		public enum ColorEnum
		{
			// Token: 0x04000982 RID: 2434
			Classic,
			// Token: 0x04000983 RID: 2435
			Black,
			// Token: 0x04000984 RID: 2436
			Dark,
			// Token: 0x04000985 RID: 2437
			Orange,
			// Token: 0x04000986 RID: 2438
			Green,
			// Token: 0x04000987 RID: 2439
			Blue,
			// Token: 0x04000988 RID: 2440
			Red,
			// Token: 0x04000989 RID: 2441
			Purple,
			// Token: 0x0400098A RID: 2442
			Teal
		}
	}
}
