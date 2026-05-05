using System;

namespace Rewired
{
	// Token: 0x02000266 RID: 614
	public interface IGamepadTemplate : IControllerTemplate
	{
		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060009DF RID: 2527
		IControllerTemplateButton actionBottomRow1 { get; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060009E0 RID: 2528
		IControllerTemplateButton a { get; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060009E1 RID: 2529
		IControllerTemplateButton actionBottomRow2 { get; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060009E2 RID: 2530
		IControllerTemplateButton b { get; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060009E3 RID: 2531
		IControllerTemplateButton actionBottomRow3 { get; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060009E4 RID: 2532
		IControllerTemplateButton c { get; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060009E5 RID: 2533
		IControllerTemplateButton actionTopRow1 { get; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060009E6 RID: 2534
		IControllerTemplateButton x { get; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060009E7 RID: 2535
		IControllerTemplateButton actionTopRow2 { get; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060009E8 RID: 2536
		IControllerTemplateButton y { get; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060009E9 RID: 2537
		IControllerTemplateButton actionTopRow3 { get; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060009EA RID: 2538
		IControllerTemplateButton z { get; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060009EB RID: 2539
		IControllerTemplateButton leftShoulder1 { get; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060009EC RID: 2540
		IControllerTemplateButton leftBumper { get; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060009ED RID: 2541
		IControllerTemplateAxis leftShoulder2 { get; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060009EE RID: 2542
		IControllerTemplateAxis leftTrigger { get; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060009EF RID: 2543
		IControllerTemplateButton rightShoulder1 { get; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060009F0 RID: 2544
		IControllerTemplateButton rightBumper { get; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060009F1 RID: 2545
		IControllerTemplateAxis rightShoulder2 { get; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060009F2 RID: 2546
		IControllerTemplateAxis rightTrigger { get; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060009F3 RID: 2547
		IControllerTemplateButton center1 { get; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060009F4 RID: 2548
		IControllerTemplateButton back { get; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060009F5 RID: 2549
		IControllerTemplateButton center2 { get; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060009F6 RID: 2550
		IControllerTemplateButton start { get; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060009F7 RID: 2551
		IControllerTemplateButton center3 { get; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060009F8 RID: 2552
		IControllerTemplateButton guide { get; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060009F9 RID: 2553
		IControllerTemplateThumbStick leftStick { get; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060009FA RID: 2554
		IControllerTemplateThumbStick rightStick { get; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060009FB RID: 2555
		IControllerTemplateDPad dPad { get; }
	}
}
