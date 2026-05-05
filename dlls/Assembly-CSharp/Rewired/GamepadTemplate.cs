using System;

namespace Rewired
{
	// Token: 0x0200026C RID: 620
	public sealed class GamepadTemplate : ControllerTemplate, IGamepadTemplate, IControllerTemplate
	{
		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000ADB RID: 2779 RVA: 0x000438D7 File Offset: 0x00041AD7
		IControllerTemplateButton IGamepadTemplate.actionBottomRow1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(4);
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000ADC RID: 2780 RVA: 0x000438D7 File Offset: 0x00041AD7
		IControllerTemplateButton IGamepadTemplate.a
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(4);
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000ADD RID: 2781 RVA: 0x000438E0 File Offset: 0x00041AE0
		IControllerTemplateButton IGamepadTemplate.actionBottomRow2
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(5);
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000ADE RID: 2782 RVA: 0x000438E0 File Offset: 0x00041AE0
		IControllerTemplateButton IGamepadTemplate.b
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(5);
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000ADF RID: 2783 RVA: 0x000438E9 File Offset: 0x00041AE9
		IControllerTemplateButton IGamepadTemplate.actionBottomRow3
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(6);
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000AE0 RID: 2784 RVA: 0x000438E9 File Offset: 0x00041AE9
		IControllerTemplateButton IGamepadTemplate.c
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(6);
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000AE1 RID: 2785 RVA: 0x000438F2 File Offset: 0x00041AF2
		IControllerTemplateButton IGamepadTemplate.actionTopRow1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(7);
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000AE2 RID: 2786 RVA: 0x000438F2 File Offset: 0x00041AF2
		IControllerTemplateButton IGamepadTemplate.x
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(7);
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000AE3 RID: 2787 RVA: 0x000438FB File Offset: 0x00041AFB
		IControllerTemplateButton IGamepadTemplate.actionTopRow2
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(8);
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000AE4 RID: 2788 RVA: 0x000438FB File Offset: 0x00041AFB
		IControllerTemplateButton IGamepadTemplate.y
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(8);
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000AE5 RID: 2789 RVA: 0x00043904 File Offset: 0x00041B04
		IControllerTemplateButton IGamepadTemplate.actionTopRow3
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(9);
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000AE6 RID: 2790 RVA: 0x00043904 File Offset: 0x00041B04
		IControllerTemplateButton IGamepadTemplate.z
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(9);
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000AE7 RID: 2791 RVA: 0x0004390E File Offset: 0x00041B0E
		IControllerTemplateButton IGamepadTemplate.leftShoulder1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(10);
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000AE8 RID: 2792 RVA: 0x0004390E File Offset: 0x00041B0E
		IControllerTemplateButton IGamepadTemplate.leftBumper
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(10);
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000AE9 RID: 2793 RVA: 0x00043918 File Offset: 0x00041B18
		IControllerTemplateAxis IGamepadTemplate.leftShoulder2
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(11);
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000AEA RID: 2794 RVA: 0x00043918 File Offset: 0x00041B18
		IControllerTemplateAxis IGamepadTemplate.leftTrigger
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(11);
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000AEB RID: 2795 RVA: 0x00043922 File Offset: 0x00041B22
		IControllerTemplateButton IGamepadTemplate.rightShoulder1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(12);
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000AEC RID: 2796 RVA: 0x00043922 File Offset: 0x00041B22
		IControllerTemplateButton IGamepadTemplate.rightBumper
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(12);
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000AED RID: 2797 RVA: 0x0004392C File Offset: 0x00041B2C
		IControllerTemplateAxis IGamepadTemplate.rightShoulder2
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(13);
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000AEE RID: 2798 RVA: 0x0004392C File Offset: 0x00041B2C
		IControllerTemplateAxis IGamepadTemplate.rightTrigger
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(13);
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000AEF RID: 2799 RVA: 0x00043936 File Offset: 0x00041B36
		IControllerTemplateButton IGamepadTemplate.center1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(14);
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000AF0 RID: 2800 RVA: 0x00043936 File Offset: 0x00041B36
		IControllerTemplateButton IGamepadTemplate.back
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(14);
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000AF1 RID: 2801 RVA: 0x00043940 File Offset: 0x00041B40
		IControllerTemplateButton IGamepadTemplate.center2
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(15);
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000AF2 RID: 2802 RVA: 0x00043940 File Offset: 0x00041B40
		IControllerTemplateButton IGamepadTemplate.start
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(15);
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000AF3 RID: 2803 RVA: 0x0004394A File Offset: 0x00041B4A
		IControllerTemplateButton IGamepadTemplate.center3
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(16);
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000AF4 RID: 2804 RVA: 0x0004394A File Offset: 0x00041B4A
		IControllerTemplateButton IGamepadTemplate.guide
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(16);
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000AF5 RID: 2805 RVA: 0x00043954 File Offset: 0x00041B54
		IControllerTemplateThumbStick IGamepadTemplate.leftStick
		{
			get
			{
				return base.GetElement<IControllerTemplateThumbStick>(23);
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000AF6 RID: 2806 RVA: 0x0004395E File Offset: 0x00041B5E
		IControllerTemplateThumbStick IGamepadTemplate.rightStick
		{
			get
			{
				return base.GetElement<IControllerTemplateThumbStick>(24);
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000AF7 RID: 2807 RVA: 0x00043968 File Offset: 0x00041B68
		IControllerTemplateDPad IGamepadTemplate.dPad
		{
			get
			{
				return base.GetElement<IControllerTemplateDPad>(25);
			}
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x00043972 File Offset: 0x00041B72
		public GamepadTemplate(object payload) : base(payload)
		{
		}

		// Token: 0x04001074 RID: 4212
		public static readonly Guid typeGuid = new Guid("83b427e4-086f-47f3-bb06-be266abd1ca5");

		// Token: 0x04001075 RID: 4213
		public const int elementId_leftStickX = 0;

		// Token: 0x04001076 RID: 4214
		public const int elementId_leftStickY = 1;

		// Token: 0x04001077 RID: 4215
		public const int elementId_rightStickX = 2;

		// Token: 0x04001078 RID: 4216
		public const int elementId_rightStickY = 3;

		// Token: 0x04001079 RID: 4217
		public const int elementId_actionBottomRow1 = 4;

		// Token: 0x0400107A RID: 4218
		public const int elementId_a = 4;

		// Token: 0x0400107B RID: 4219
		public const int elementId_actionBottomRow2 = 5;

		// Token: 0x0400107C RID: 4220
		public const int elementId_b = 5;

		// Token: 0x0400107D RID: 4221
		public const int elementId_actionBottomRow3 = 6;

		// Token: 0x0400107E RID: 4222
		public const int elementId_c = 6;

		// Token: 0x0400107F RID: 4223
		public const int elementId_actionTopRow1 = 7;

		// Token: 0x04001080 RID: 4224
		public const int elementId_x = 7;

		// Token: 0x04001081 RID: 4225
		public const int elementId_actionTopRow2 = 8;

		// Token: 0x04001082 RID: 4226
		public const int elementId_y = 8;

		// Token: 0x04001083 RID: 4227
		public const int elementId_actionTopRow3 = 9;

		// Token: 0x04001084 RID: 4228
		public const int elementId_z = 9;

		// Token: 0x04001085 RID: 4229
		public const int elementId_leftShoulder1 = 10;

		// Token: 0x04001086 RID: 4230
		public const int elementId_leftBumper = 10;

		// Token: 0x04001087 RID: 4231
		public const int elementId_leftShoulder2 = 11;

		// Token: 0x04001088 RID: 4232
		public const int elementId_leftTrigger = 11;

		// Token: 0x04001089 RID: 4233
		public const int elementId_rightShoulder1 = 12;

		// Token: 0x0400108A RID: 4234
		public const int elementId_rightBumper = 12;

		// Token: 0x0400108B RID: 4235
		public const int elementId_rightShoulder2 = 13;

		// Token: 0x0400108C RID: 4236
		public const int elementId_rightTrigger = 13;

		// Token: 0x0400108D RID: 4237
		public const int elementId_center1 = 14;

		// Token: 0x0400108E RID: 4238
		public const int elementId_back = 14;

		// Token: 0x0400108F RID: 4239
		public const int elementId_center2 = 15;

		// Token: 0x04001090 RID: 4240
		public const int elementId_start = 15;

		// Token: 0x04001091 RID: 4241
		public const int elementId_center3 = 16;

		// Token: 0x04001092 RID: 4242
		public const int elementId_guide = 16;

		// Token: 0x04001093 RID: 4243
		public const int elementId_leftStickButton = 17;

		// Token: 0x04001094 RID: 4244
		public const int elementId_rightStickButton = 18;

		// Token: 0x04001095 RID: 4245
		public const int elementId_dPadUp = 19;

		// Token: 0x04001096 RID: 4246
		public const int elementId_dPadRight = 20;

		// Token: 0x04001097 RID: 4247
		public const int elementId_dPadDown = 21;

		// Token: 0x04001098 RID: 4248
		public const int elementId_dPadLeft = 22;

		// Token: 0x04001099 RID: 4249
		public const int elementId_leftStick = 23;

		// Token: 0x0400109A RID: 4250
		public const int elementId_rightStick = 24;

		// Token: 0x0400109B RID: 4251
		public const int elementId_dPad = 25;
	}
}
