using System;

namespace Rewired
{
	// Token: 0x0200026D RID: 621
	public sealed class RacingWheelTemplate : ControllerTemplate, IRacingWheelTemplate, IControllerTemplate
	{
		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000AFA RID: 2810 RVA: 0x0004398C File Offset: 0x00041B8C
		IControllerTemplateAxis IRacingWheelTemplate.wheel
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(0);
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000AFB RID: 2811 RVA: 0x00043995 File Offset: 0x00041B95
		IControllerTemplateAxis IRacingWheelTemplate.accelerator
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(1);
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000AFC RID: 2812 RVA: 0x0004399E File Offset: 0x00041B9E
		IControllerTemplateAxis IRacingWheelTemplate.brake
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(2);
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000AFD RID: 2813 RVA: 0x000439A7 File Offset: 0x00041BA7
		IControllerTemplateAxis IRacingWheelTemplate.clutch
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(3);
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000AFE RID: 2814 RVA: 0x000438D7 File Offset: 0x00041AD7
		IControllerTemplateButton IRacingWheelTemplate.shiftDown
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(4);
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000AFF RID: 2815 RVA: 0x000438E0 File Offset: 0x00041AE0
		IControllerTemplateButton IRacingWheelTemplate.shiftUp
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(5);
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000B00 RID: 2816 RVA: 0x000438E9 File Offset: 0x00041AE9
		IControllerTemplateButton IRacingWheelTemplate.wheelButton1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(6);
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000B01 RID: 2817 RVA: 0x000438F2 File Offset: 0x00041AF2
		IControllerTemplateButton IRacingWheelTemplate.wheelButton2
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(7);
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000B02 RID: 2818 RVA: 0x000438FB File Offset: 0x00041AFB
		IControllerTemplateButton IRacingWheelTemplate.wheelButton3
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(8);
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000B03 RID: 2819 RVA: 0x00043904 File Offset: 0x00041B04
		IControllerTemplateButton IRacingWheelTemplate.wheelButton4
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(9);
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000B04 RID: 2820 RVA: 0x0004390E File Offset: 0x00041B0E
		IControllerTemplateButton IRacingWheelTemplate.wheelButton5
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(10);
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000B05 RID: 2821 RVA: 0x000439B0 File Offset: 0x00041BB0
		IControllerTemplateButton IRacingWheelTemplate.wheelButton6
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(11);
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000B06 RID: 2822 RVA: 0x00043922 File Offset: 0x00041B22
		IControllerTemplateButton IRacingWheelTemplate.wheelButton7
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(12);
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000B07 RID: 2823 RVA: 0x000439BA File Offset: 0x00041BBA
		IControllerTemplateButton IRacingWheelTemplate.wheelButton8
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(13);
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000B08 RID: 2824 RVA: 0x00043936 File Offset: 0x00041B36
		IControllerTemplateButton IRacingWheelTemplate.wheelButton9
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(14);
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000B09 RID: 2825 RVA: 0x00043940 File Offset: 0x00041B40
		IControllerTemplateButton IRacingWheelTemplate.wheelButton10
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(15);
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000B0A RID: 2826 RVA: 0x0004394A File Offset: 0x00041B4A
		IControllerTemplateButton IRacingWheelTemplate.consoleButton1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(16);
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000B0B RID: 2827 RVA: 0x000439C4 File Offset: 0x00041BC4
		IControllerTemplateButton IRacingWheelTemplate.consoleButton2
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(17);
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000B0C RID: 2828 RVA: 0x000439CE File Offset: 0x00041BCE
		IControllerTemplateButton IRacingWheelTemplate.consoleButton3
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(18);
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06000B0D RID: 2829 RVA: 0x000439D8 File Offset: 0x00041BD8
		IControllerTemplateButton IRacingWheelTemplate.consoleButton4
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(19);
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000B0E RID: 2830 RVA: 0x000439E2 File Offset: 0x00041BE2
		IControllerTemplateButton IRacingWheelTemplate.consoleButton5
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(20);
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000B0F RID: 2831 RVA: 0x000439EC File Offset: 0x00041BEC
		IControllerTemplateButton IRacingWheelTemplate.consoleButton6
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(21);
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000B10 RID: 2832 RVA: 0x000439F6 File Offset: 0x00041BF6
		IControllerTemplateButton IRacingWheelTemplate.consoleButton7
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(22);
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000B11 RID: 2833 RVA: 0x00043A00 File Offset: 0x00041C00
		IControllerTemplateButton IRacingWheelTemplate.consoleButton8
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(23);
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000B12 RID: 2834 RVA: 0x00043A0A File Offset: 0x00041C0A
		IControllerTemplateButton IRacingWheelTemplate.consoleButton9
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(24);
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000B13 RID: 2835 RVA: 0x00043A14 File Offset: 0x00041C14
		IControllerTemplateButton IRacingWheelTemplate.consoleButton10
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(25);
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000B14 RID: 2836 RVA: 0x00043A1E File Offset: 0x00041C1E
		IControllerTemplateButton IRacingWheelTemplate.shifter1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(26);
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000B15 RID: 2837 RVA: 0x00043A28 File Offset: 0x00041C28
		IControllerTemplateButton IRacingWheelTemplate.shifter2
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(27);
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000B16 RID: 2838 RVA: 0x00043A32 File Offset: 0x00041C32
		IControllerTemplateButton IRacingWheelTemplate.shifter3
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(28);
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000B17 RID: 2839 RVA: 0x00043A3C File Offset: 0x00041C3C
		IControllerTemplateButton IRacingWheelTemplate.shifter4
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(29);
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000B18 RID: 2840 RVA: 0x00043A46 File Offset: 0x00041C46
		IControllerTemplateButton IRacingWheelTemplate.shifter5
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(30);
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000B19 RID: 2841 RVA: 0x00043A50 File Offset: 0x00041C50
		IControllerTemplateButton IRacingWheelTemplate.shifter6
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(31);
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000B1A RID: 2842 RVA: 0x00043A5A File Offset: 0x00041C5A
		IControllerTemplateButton IRacingWheelTemplate.shifter7
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(32);
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000B1B RID: 2843 RVA: 0x00043A64 File Offset: 0x00041C64
		IControllerTemplateButton IRacingWheelTemplate.shifter8
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(33);
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000B1C RID: 2844 RVA: 0x00043A6E File Offset: 0x00041C6E
		IControllerTemplateButton IRacingWheelTemplate.shifter9
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(34);
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000B1D RID: 2845 RVA: 0x00043A78 File Offset: 0x00041C78
		IControllerTemplateButton IRacingWheelTemplate.shifter10
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(35);
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000B1E RID: 2846 RVA: 0x00043A82 File Offset: 0x00041C82
		IControllerTemplateButton IRacingWheelTemplate.reverseGear
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(44);
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000B1F RID: 2847 RVA: 0x00043A8C File Offset: 0x00041C8C
		IControllerTemplateButton IRacingWheelTemplate.select
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(36);
			}
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000B20 RID: 2848 RVA: 0x00043A96 File Offset: 0x00041C96
		IControllerTemplateButton IRacingWheelTemplate.start
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(37);
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000B21 RID: 2849 RVA: 0x00043AA0 File Offset: 0x00041CA0
		IControllerTemplateButton IRacingWheelTemplate.systemButton
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(38);
			}
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000B22 RID: 2850 RVA: 0x00043AAA File Offset: 0x00041CAA
		IControllerTemplateButton IRacingWheelTemplate.horn
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(43);
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000B23 RID: 2851 RVA: 0x00043AB4 File Offset: 0x00041CB4
		IControllerTemplateDPad IRacingWheelTemplate.dPad
		{
			get
			{
				return base.GetElement<IControllerTemplateDPad>(45);
			}
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x00043972 File Offset: 0x00041B72
		public RacingWheelTemplate(object payload) : base(payload)
		{
		}

		// Token: 0x0400109C RID: 4252
		public static readonly Guid typeGuid = new Guid("104e31d8-9115-4dd5-a398-2e54d35e6c83");

		// Token: 0x0400109D RID: 4253
		public const int elementId_wheel = 0;

		// Token: 0x0400109E RID: 4254
		public const int elementId_accelerator = 1;

		// Token: 0x0400109F RID: 4255
		public const int elementId_brake = 2;

		// Token: 0x040010A0 RID: 4256
		public const int elementId_clutch = 3;

		// Token: 0x040010A1 RID: 4257
		public const int elementId_shiftDown = 4;

		// Token: 0x040010A2 RID: 4258
		public const int elementId_shiftUp = 5;

		// Token: 0x040010A3 RID: 4259
		public const int elementId_wheelButton1 = 6;

		// Token: 0x040010A4 RID: 4260
		public const int elementId_wheelButton2 = 7;

		// Token: 0x040010A5 RID: 4261
		public const int elementId_wheelButton3 = 8;

		// Token: 0x040010A6 RID: 4262
		public const int elementId_wheelButton4 = 9;

		// Token: 0x040010A7 RID: 4263
		public const int elementId_wheelButton5 = 10;

		// Token: 0x040010A8 RID: 4264
		public const int elementId_wheelButton6 = 11;

		// Token: 0x040010A9 RID: 4265
		public const int elementId_wheelButton7 = 12;

		// Token: 0x040010AA RID: 4266
		public const int elementId_wheelButton8 = 13;

		// Token: 0x040010AB RID: 4267
		public const int elementId_wheelButton9 = 14;

		// Token: 0x040010AC RID: 4268
		public const int elementId_wheelButton10 = 15;

		// Token: 0x040010AD RID: 4269
		public const int elementId_consoleButton1 = 16;

		// Token: 0x040010AE RID: 4270
		public const int elementId_consoleButton2 = 17;

		// Token: 0x040010AF RID: 4271
		public const int elementId_consoleButton3 = 18;

		// Token: 0x040010B0 RID: 4272
		public const int elementId_consoleButton4 = 19;

		// Token: 0x040010B1 RID: 4273
		public const int elementId_consoleButton5 = 20;

		// Token: 0x040010B2 RID: 4274
		public const int elementId_consoleButton6 = 21;

		// Token: 0x040010B3 RID: 4275
		public const int elementId_consoleButton7 = 22;

		// Token: 0x040010B4 RID: 4276
		public const int elementId_consoleButton8 = 23;

		// Token: 0x040010B5 RID: 4277
		public const int elementId_consoleButton9 = 24;

		// Token: 0x040010B6 RID: 4278
		public const int elementId_consoleButton10 = 25;

		// Token: 0x040010B7 RID: 4279
		public const int elementId_shifter1 = 26;

		// Token: 0x040010B8 RID: 4280
		public const int elementId_shifter2 = 27;

		// Token: 0x040010B9 RID: 4281
		public const int elementId_shifter3 = 28;

		// Token: 0x040010BA RID: 4282
		public const int elementId_shifter4 = 29;

		// Token: 0x040010BB RID: 4283
		public const int elementId_shifter5 = 30;

		// Token: 0x040010BC RID: 4284
		public const int elementId_shifter6 = 31;

		// Token: 0x040010BD RID: 4285
		public const int elementId_shifter7 = 32;

		// Token: 0x040010BE RID: 4286
		public const int elementId_shifter8 = 33;

		// Token: 0x040010BF RID: 4287
		public const int elementId_shifter9 = 34;

		// Token: 0x040010C0 RID: 4288
		public const int elementId_shifter10 = 35;

		// Token: 0x040010C1 RID: 4289
		public const int elementId_reverseGear = 44;

		// Token: 0x040010C2 RID: 4290
		public const int elementId_select = 36;

		// Token: 0x040010C3 RID: 4291
		public const int elementId_start = 37;

		// Token: 0x040010C4 RID: 4292
		public const int elementId_systemButton = 38;

		// Token: 0x040010C5 RID: 4293
		public const int elementId_horn = 43;

		// Token: 0x040010C6 RID: 4294
		public const int elementId_dPadUp = 39;

		// Token: 0x040010C7 RID: 4295
		public const int elementId_dPadRight = 40;

		// Token: 0x040010C8 RID: 4296
		public const int elementId_dPadDown = 41;

		// Token: 0x040010C9 RID: 4297
		public const int elementId_dPadLeft = 42;

		// Token: 0x040010CA RID: 4298
		public const int elementId_dPad = 45;
	}
}
