using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000075 RID: 117
	public interface IGraphNest : IAotStubbable
	{
		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x0600039C RID: 924
		// (set) Token: 0x0600039D RID: 925
		IGraphNester nester { get; set; }

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x0600039E RID: 926
		// (set) Token: 0x0600039F RID: 927
		GraphSource source { get; set; }

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060003A0 RID: 928
		// (set) Token: 0x060003A1 RID: 929
		IGraph embed { get; set; }

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060003A2 RID: 930
		// (set) Token: 0x060003A3 RID: 931
		IMacro macro { get; set; }

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060003A4 RID: 932
		IGraph graph { get; }

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060003A5 RID: 933
		Type graphType { get; }

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060003A6 RID: 934
		Type macroType { get; }

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060003A7 RID: 935
		bool hasBackgroundEmbed { get; }
	}
}
