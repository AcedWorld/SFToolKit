using System;

namespace Rewired
{
	// Token: 0x02000267 RID: 615
	public interface IRacingWheelTemplate : IControllerTemplate
	{
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060009FC RID: 2556
		IControllerTemplateAxis wheel { get; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060009FD RID: 2557
		IControllerTemplateAxis accelerator { get; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060009FE RID: 2558
		IControllerTemplateAxis brake { get; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060009FF RID: 2559
		IControllerTemplateAxis clutch { get; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000A00 RID: 2560
		IControllerTemplateButton shiftDown { get; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000A01 RID: 2561
		IControllerTemplateButton shiftUp { get; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000A02 RID: 2562
		IControllerTemplateButton wheelButton1 { get; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000A03 RID: 2563
		IControllerTemplateButton wheelButton2 { get; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000A04 RID: 2564
		IControllerTemplateButton wheelButton3 { get; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000A05 RID: 2565
		IControllerTemplateButton wheelButton4 { get; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000A06 RID: 2566
		IControllerTemplateButton wheelButton5 { get; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000A07 RID: 2567
		IControllerTemplateButton wheelButton6 { get; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000A08 RID: 2568
		IControllerTemplateButton wheelButton7 { get; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000A09 RID: 2569
		IControllerTemplateButton wheelButton8 { get; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000A0A RID: 2570
		IControllerTemplateButton wheelButton9 { get; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000A0B RID: 2571
		IControllerTemplateButton wheelButton10 { get; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000A0C RID: 2572
		IControllerTemplateButton consoleButton1 { get; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000A0D RID: 2573
		IControllerTemplateButton consoleButton2 { get; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000A0E RID: 2574
		IControllerTemplateButton consoleButton3 { get; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000A0F RID: 2575
		IControllerTemplateButton consoleButton4 { get; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000A10 RID: 2576
		IControllerTemplateButton consoleButton5 { get; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000A11 RID: 2577
		IControllerTemplateButton consoleButton6 { get; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000A12 RID: 2578
		IControllerTemplateButton consoleButton7 { get; }

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000A13 RID: 2579
		IControllerTemplateButton consoleButton8 { get; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000A14 RID: 2580
		IControllerTemplateButton consoleButton9 { get; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000A15 RID: 2581
		IControllerTemplateButton consoleButton10 { get; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000A16 RID: 2582
		IControllerTemplateButton shifter1 { get; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000A17 RID: 2583
		IControllerTemplateButton shifter2 { get; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000A18 RID: 2584
		IControllerTemplateButton shifter3 { get; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000A19 RID: 2585
		IControllerTemplateButton shifter4 { get; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000A1A RID: 2586
		IControllerTemplateButton shifter5 { get; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000A1B RID: 2587
		IControllerTemplateButton shifter6 { get; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000A1C RID: 2588
		IControllerTemplateButton shifter7 { get; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000A1D RID: 2589
		IControllerTemplateButton shifter8 { get; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000A1E RID: 2590
		IControllerTemplateButton shifter9 { get; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000A1F RID: 2591
		IControllerTemplateButton shifter10 { get; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000A20 RID: 2592
		IControllerTemplateButton reverseGear { get; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000A21 RID: 2593
		IControllerTemplateButton select { get; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000A22 RID: 2594
		IControllerTemplateButton start { get; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000A23 RID: 2595
		IControllerTemplateButton systemButton { get; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000A24 RID: 2596
		IControllerTemplateButton horn { get; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000A25 RID: 2597
		IControllerTemplateDPad dPad { get; }
	}
}
