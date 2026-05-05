using System;

namespace Rewired
{
	// Token: 0x02000271 RID: 625
	public sealed class SixDofControllerTemplate : ControllerTemplate, ISixDofControllerTemplate, IControllerTemplate
	{
		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000BB8 RID: 3000 RVA: 0x00043E68 File Offset: 0x00042068
		IControllerTemplateAxis ISixDofControllerTemplate.extraAxis1
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(8);
			}
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000BB9 RID: 3001 RVA: 0x00043E71 File Offset: 0x00042071
		IControllerTemplateAxis ISixDofControllerTemplate.extraAxis2
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(9);
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000BBA RID: 3002 RVA: 0x00043E7B File Offset: 0x0004207B
		IControllerTemplateAxis ISixDofControllerTemplate.extraAxis3
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(10);
			}
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000BBB RID: 3003 RVA: 0x00043918 File Offset: 0x00041B18
		IControllerTemplateAxis ISixDofControllerTemplate.extraAxis4
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(11);
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000BBC RID: 3004 RVA: 0x00043922 File Offset: 0x00041B22
		IControllerTemplateButton ISixDofControllerTemplate.button1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(12);
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000BBD RID: 3005 RVA: 0x000439BA File Offset: 0x00041BBA
		IControllerTemplateButton ISixDofControllerTemplate.button2
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(13);
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000BBE RID: 3006 RVA: 0x00043936 File Offset: 0x00041B36
		IControllerTemplateButton ISixDofControllerTemplate.button3
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(14);
			}
		}

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000BBF RID: 3007 RVA: 0x00043940 File Offset: 0x00041B40
		IControllerTemplateButton ISixDofControllerTemplate.button4
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(15);
			}
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000BC0 RID: 3008 RVA: 0x0004394A File Offset: 0x00041B4A
		IControllerTemplateButton ISixDofControllerTemplate.button5
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(16);
			}
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06000BC1 RID: 3009 RVA: 0x000439C4 File Offset: 0x00041BC4
		IControllerTemplateButton ISixDofControllerTemplate.button6
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(17);
			}
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000BC2 RID: 3010 RVA: 0x000439CE File Offset: 0x00041BCE
		IControllerTemplateButton ISixDofControllerTemplate.button7
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(18);
			}
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000BC3 RID: 3011 RVA: 0x000439D8 File Offset: 0x00041BD8
		IControllerTemplateButton ISixDofControllerTemplate.button8
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(19);
			}
		}

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000BC4 RID: 3012 RVA: 0x000439E2 File Offset: 0x00041BE2
		IControllerTemplateButton ISixDofControllerTemplate.button9
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(20);
			}
		}

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000BC5 RID: 3013 RVA: 0x000439EC File Offset: 0x00041BEC
		IControllerTemplateButton ISixDofControllerTemplate.button10
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(21);
			}
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000BC6 RID: 3014 RVA: 0x000439F6 File Offset: 0x00041BF6
		IControllerTemplateButton ISixDofControllerTemplate.button11
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(22);
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06000BC7 RID: 3015 RVA: 0x00043A00 File Offset: 0x00041C00
		IControllerTemplateButton ISixDofControllerTemplate.button12
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(23);
			}
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06000BC8 RID: 3016 RVA: 0x00043A0A File Offset: 0x00041C0A
		IControllerTemplateButton ISixDofControllerTemplate.button13
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(24);
			}
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000BC9 RID: 3017 RVA: 0x00043A14 File Offset: 0x00041C14
		IControllerTemplateButton ISixDofControllerTemplate.button14
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(25);
			}
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000BCA RID: 3018 RVA: 0x00043A1E File Offset: 0x00041C1E
		IControllerTemplateButton ISixDofControllerTemplate.button15
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(26);
			}
		}

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000BCB RID: 3019 RVA: 0x00043A28 File Offset: 0x00041C28
		IControllerTemplateButton ISixDofControllerTemplate.button16
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(27);
			}
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06000BCC RID: 3020 RVA: 0x00043A32 File Offset: 0x00041C32
		IControllerTemplateButton ISixDofControllerTemplate.button17
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(28);
			}
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06000BCD RID: 3021 RVA: 0x00043A3C File Offset: 0x00041C3C
		IControllerTemplateButton ISixDofControllerTemplate.button18
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(29);
			}
		}

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06000BCE RID: 3022 RVA: 0x00043A46 File Offset: 0x00041C46
		IControllerTemplateButton ISixDofControllerTemplate.button19
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(30);
			}
		}

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x06000BCF RID: 3023 RVA: 0x00043A50 File Offset: 0x00041C50
		IControllerTemplateButton ISixDofControllerTemplate.button20
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(31);
			}
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x00043B45 File Offset: 0x00041D45
		IControllerTemplateButton ISixDofControllerTemplate.button21
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(55);
			}
		}

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06000BD1 RID: 3025 RVA: 0x00043B4F File Offset: 0x00041D4F
		IControllerTemplateButton ISixDofControllerTemplate.button22
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(56);
			}
		}

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06000BD2 RID: 3026 RVA: 0x00043B59 File Offset: 0x00041D59
		IControllerTemplateButton ISixDofControllerTemplate.button23
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(57);
			}
		}

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000BD3 RID: 3027 RVA: 0x00043B63 File Offset: 0x00041D63
		IControllerTemplateButton ISixDofControllerTemplate.button24
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(58);
			}
		}

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000BD4 RID: 3028 RVA: 0x00043B6D File Offset: 0x00041D6D
		IControllerTemplateButton ISixDofControllerTemplate.button25
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(59);
			}
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000BD5 RID: 3029 RVA: 0x00043B77 File Offset: 0x00041D77
		IControllerTemplateButton ISixDofControllerTemplate.button26
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(60);
			}
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000BD6 RID: 3030 RVA: 0x00043B81 File Offset: 0x00041D81
		IControllerTemplateButton ISixDofControllerTemplate.button27
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(61);
			}
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000BD7 RID: 3031 RVA: 0x00043B8B File Offset: 0x00041D8B
		IControllerTemplateButton ISixDofControllerTemplate.button28
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(62);
			}
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000BD8 RID: 3032 RVA: 0x00043B95 File Offset: 0x00041D95
		IControllerTemplateButton ISixDofControllerTemplate.button29
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(63);
			}
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000BD9 RID: 3033 RVA: 0x00043B9F File Offset: 0x00041D9F
		IControllerTemplateButton ISixDofControllerTemplate.button30
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(64);
			}
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000BDA RID: 3034 RVA: 0x00043BA9 File Offset: 0x00041DA9
		IControllerTemplateButton ISixDofControllerTemplate.button31
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(65);
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06000BDB RID: 3035 RVA: 0x00043BB3 File Offset: 0x00041DB3
		IControllerTemplateButton ISixDofControllerTemplate.button32
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(66);
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06000BDC RID: 3036 RVA: 0x00043E85 File Offset: 0x00042085
		IControllerTemplateHat ISixDofControllerTemplate.hat1
		{
			get
			{
				return base.GetElement<IControllerTemplateHat>(48);
			}
		}

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000BDD RID: 3037 RVA: 0x00043E8F File Offset: 0x0004208F
		IControllerTemplateHat ISixDofControllerTemplate.hat2
		{
			get
			{
				return base.GetElement<IControllerTemplateHat>(49);
			}
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06000BDE RID: 3038 RVA: 0x00043E99 File Offset: 0x00042099
		IControllerTemplateThrottle ISixDofControllerTemplate.throttle1
		{
			get
			{
				return base.GetElement<IControllerTemplateThrottle>(52);
			}
		}

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06000BDF RID: 3039 RVA: 0x00043EA3 File Offset: 0x000420A3
		IControllerTemplateThrottle ISixDofControllerTemplate.throttle2
		{
			get
			{
				return base.GetElement<IControllerTemplateThrottle>(53);
			}
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06000BE0 RID: 3040 RVA: 0x00043EAD File Offset: 0x000420AD
		IControllerTemplateStick6D ISixDofControllerTemplate.stick
		{
			get
			{
				return base.GetElement<IControllerTemplateStick6D>(54);
			}
		}

		// Token: 0x06000BE1 RID: 3041 RVA: 0x00043972 File Offset: 0x00041B72
		public SixDofControllerTemplate(object payload) : base(payload)
		{
		}

		// Token: 0x040011C6 RID: 4550
		public static readonly Guid typeGuid = new Guid("2599beb3-522b-43dd-a4ef-93fd60e5eafa");

		// Token: 0x040011C7 RID: 4551
		public const int elementId_positionX = 1;

		// Token: 0x040011C8 RID: 4552
		public const int elementId_positionY = 2;

		// Token: 0x040011C9 RID: 4553
		public const int elementId_positionZ = 0;

		// Token: 0x040011CA RID: 4554
		public const int elementId_rotationX = 3;

		// Token: 0x040011CB RID: 4555
		public const int elementId_rotationY = 5;

		// Token: 0x040011CC RID: 4556
		public const int elementId_rotationZ = 4;

		// Token: 0x040011CD RID: 4557
		public const int elementId_throttle1Axis = 6;

		// Token: 0x040011CE RID: 4558
		public const int elementId_throttle1MinDetent = 50;

		// Token: 0x040011CF RID: 4559
		public const int elementId_throttle2Axis = 7;

		// Token: 0x040011D0 RID: 4560
		public const int elementId_throttle2MinDetent = 51;

		// Token: 0x040011D1 RID: 4561
		public const int elementId_extraAxis1 = 8;

		// Token: 0x040011D2 RID: 4562
		public const int elementId_extraAxis2 = 9;

		// Token: 0x040011D3 RID: 4563
		public const int elementId_extraAxis3 = 10;

		// Token: 0x040011D4 RID: 4564
		public const int elementId_extraAxis4 = 11;

		// Token: 0x040011D5 RID: 4565
		public const int elementId_button1 = 12;

		// Token: 0x040011D6 RID: 4566
		public const int elementId_button2 = 13;

		// Token: 0x040011D7 RID: 4567
		public const int elementId_button3 = 14;

		// Token: 0x040011D8 RID: 4568
		public const int elementId_button4 = 15;

		// Token: 0x040011D9 RID: 4569
		public const int elementId_button5 = 16;

		// Token: 0x040011DA RID: 4570
		public const int elementId_button6 = 17;

		// Token: 0x040011DB RID: 4571
		public const int elementId_button7 = 18;

		// Token: 0x040011DC RID: 4572
		public const int elementId_button8 = 19;

		// Token: 0x040011DD RID: 4573
		public const int elementId_button9 = 20;

		// Token: 0x040011DE RID: 4574
		public const int elementId_button10 = 21;

		// Token: 0x040011DF RID: 4575
		public const int elementId_button11 = 22;

		// Token: 0x040011E0 RID: 4576
		public const int elementId_button12 = 23;

		// Token: 0x040011E1 RID: 4577
		public const int elementId_button13 = 24;

		// Token: 0x040011E2 RID: 4578
		public const int elementId_button14 = 25;

		// Token: 0x040011E3 RID: 4579
		public const int elementId_button15 = 26;

		// Token: 0x040011E4 RID: 4580
		public const int elementId_button16 = 27;

		// Token: 0x040011E5 RID: 4581
		public const int elementId_button17 = 28;

		// Token: 0x040011E6 RID: 4582
		public const int elementId_button18 = 29;

		// Token: 0x040011E7 RID: 4583
		public const int elementId_button19 = 30;

		// Token: 0x040011E8 RID: 4584
		public const int elementId_button20 = 31;

		// Token: 0x040011E9 RID: 4585
		public const int elementId_button21 = 55;

		// Token: 0x040011EA RID: 4586
		public const int elementId_button22 = 56;

		// Token: 0x040011EB RID: 4587
		public const int elementId_button23 = 57;

		// Token: 0x040011EC RID: 4588
		public const int elementId_button24 = 58;

		// Token: 0x040011ED RID: 4589
		public const int elementId_button25 = 59;

		// Token: 0x040011EE RID: 4590
		public const int elementId_button26 = 60;

		// Token: 0x040011EF RID: 4591
		public const int elementId_button27 = 61;

		// Token: 0x040011F0 RID: 4592
		public const int elementId_button28 = 62;

		// Token: 0x040011F1 RID: 4593
		public const int elementId_button29 = 63;

		// Token: 0x040011F2 RID: 4594
		public const int elementId_button30 = 64;

		// Token: 0x040011F3 RID: 4595
		public const int elementId_button31 = 65;

		// Token: 0x040011F4 RID: 4596
		public const int elementId_button32 = 66;

		// Token: 0x040011F5 RID: 4597
		public const int elementId_hat1Up = 32;

		// Token: 0x040011F6 RID: 4598
		public const int elementId_hat1UpRight = 33;

		// Token: 0x040011F7 RID: 4599
		public const int elementId_hat1Right = 34;

		// Token: 0x040011F8 RID: 4600
		public const int elementId_hat1DownRight = 35;

		// Token: 0x040011F9 RID: 4601
		public const int elementId_hat1Down = 36;

		// Token: 0x040011FA RID: 4602
		public const int elementId_hat1DownLeft = 37;

		// Token: 0x040011FB RID: 4603
		public const int elementId_hat1Left = 38;

		// Token: 0x040011FC RID: 4604
		public const int elementId_hat1UpLeft = 39;

		// Token: 0x040011FD RID: 4605
		public const int elementId_hat2Up = 40;

		// Token: 0x040011FE RID: 4606
		public const int elementId_hat2UpRight = 41;

		// Token: 0x040011FF RID: 4607
		public const int elementId_hat2Right = 42;

		// Token: 0x04001200 RID: 4608
		public const int elementId_hat2DownRight = 43;

		// Token: 0x04001201 RID: 4609
		public const int elementId_hat2Down = 44;

		// Token: 0x04001202 RID: 4610
		public const int elementId_hat2DownLeft = 45;

		// Token: 0x04001203 RID: 4611
		public const int elementId_hat2Left = 46;

		// Token: 0x04001204 RID: 4612
		public const int elementId_hat2UpLeft = 47;

		// Token: 0x04001205 RID: 4613
		public const int elementId_hat1 = 48;

		// Token: 0x04001206 RID: 4614
		public const int elementId_hat2 = 49;

		// Token: 0x04001207 RID: 4615
		public const int elementId_throttle1 = 52;

		// Token: 0x04001208 RID: 4616
		public const int elementId_throttle2 = 53;

		// Token: 0x04001209 RID: 4617
		public const int elementId_stick = 54;
	}
}
