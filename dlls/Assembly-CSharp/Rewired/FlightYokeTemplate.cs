using System;

namespace Rewired
{
	// Token: 0x0200026F RID: 623
	public sealed class FlightYokeTemplate : ControllerTemplate, IFlightYokeTemplate, IControllerTemplate
	{
		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000B80 RID: 2944 RVA: 0x00043B6D File Offset: 0x00041D6D
		IControllerTemplateButton IFlightYokeTemplate.leftPaddle
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(59);
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06000B81 RID: 2945 RVA: 0x00043B77 File Offset: 0x00041D77
		IControllerTemplateButton IFlightYokeTemplate.rightPaddle
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(60);
			}
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000B82 RID: 2946 RVA: 0x000438F2 File Offset: 0x00041AF2
		IControllerTemplateButton IFlightYokeTemplate.leftGripButton1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(7);
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06000B83 RID: 2947 RVA: 0x000438FB File Offset: 0x00041AFB
		IControllerTemplateButton IFlightYokeTemplate.leftGripButton2
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(8);
			}
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06000B84 RID: 2948 RVA: 0x00043904 File Offset: 0x00041B04
		IControllerTemplateButton IFlightYokeTemplate.leftGripButton3
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(9);
			}
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06000B85 RID: 2949 RVA: 0x0004390E File Offset: 0x00041B0E
		IControllerTemplateButton IFlightYokeTemplate.leftGripButton4
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(10);
			}
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000B86 RID: 2950 RVA: 0x000439B0 File Offset: 0x00041BB0
		IControllerTemplateButton IFlightYokeTemplate.leftGripButton5
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(11);
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000B87 RID: 2951 RVA: 0x00043922 File Offset: 0x00041B22
		IControllerTemplateButton IFlightYokeTemplate.leftGripButton6
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(12);
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000B88 RID: 2952 RVA: 0x000439BA File Offset: 0x00041BBA
		IControllerTemplateButton IFlightYokeTemplate.rightGripButton1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(13);
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000B89 RID: 2953 RVA: 0x00043936 File Offset: 0x00041B36
		IControllerTemplateButton IFlightYokeTemplate.rightGripButton2
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(14);
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000B8A RID: 2954 RVA: 0x00043940 File Offset: 0x00041B40
		IControllerTemplateButton IFlightYokeTemplate.rightGripButton3
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(15);
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000B8B RID: 2955 RVA: 0x0004394A File Offset: 0x00041B4A
		IControllerTemplateButton IFlightYokeTemplate.rightGripButton4
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(16);
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000B8C RID: 2956 RVA: 0x000439C4 File Offset: 0x00041BC4
		IControllerTemplateButton IFlightYokeTemplate.rightGripButton5
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(17);
			}
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000B8D RID: 2957 RVA: 0x000439CE File Offset: 0x00041BCE
		IControllerTemplateButton IFlightYokeTemplate.rightGripButton6
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(18);
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000B8E RID: 2958 RVA: 0x000439D8 File Offset: 0x00041BD8
		IControllerTemplateButton IFlightYokeTemplate.centerButton1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(19);
			}
		}

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000B8F RID: 2959 RVA: 0x000439E2 File Offset: 0x00041BE2
		IControllerTemplateButton IFlightYokeTemplate.centerButton2
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(20);
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000B90 RID: 2960 RVA: 0x000439EC File Offset: 0x00041BEC
		IControllerTemplateButton IFlightYokeTemplate.centerButton3
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(21);
			}
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000B91 RID: 2961 RVA: 0x000439F6 File Offset: 0x00041BF6
		IControllerTemplateButton IFlightYokeTemplate.centerButton4
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(22);
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000B92 RID: 2962 RVA: 0x00043A00 File Offset: 0x00041C00
		IControllerTemplateButton IFlightYokeTemplate.centerButton5
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(23);
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000B93 RID: 2963 RVA: 0x00043A0A File Offset: 0x00041C0A
		IControllerTemplateButton IFlightYokeTemplate.centerButton6
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(24);
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000B94 RID: 2964 RVA: 0x00043A14 File Offset: 0x00041C14
		IControllerTemplateButton IFlightYokeTemplate.centerButton7
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(25);
			}
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000B95 RID: 2965 RVA: 0x00043A1E File Offset: 0x00041C1E
		IControllerTemplateButton IFlightYokeTemplate.centerButton8
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(26);
			}
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000B96 RID: 2966 RVA: 0x00043B31 File Offset: 0x00041D31
		IControllerTemplateButton IFlightYokeTemplate.wheel1Up
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(53);
			}
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000B97 RID: 2967 RVA: 0x00043B3B File Offset: 0x00041D3B
		IControllerTemplateButton IFlightYokeTemplate.wheel1Down
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(54);
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000B98 RID: 2968 RVA: 0x00043B45 File Offset: 0x00041D45
		IControllerTemplateButton IFlightYokeTemplate.wheel1Press
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(55);
			}
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000B99 RID: 2969 RVA: 0x00043B4F File Offset: 0x00041D4F
		IControllerTemplateButton IFlightYokeTemplate.wheel2Up
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(56);
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000B9A RID: 2970 RVA: 0x00043B59 File Offset: 0x00041D59
		IControllerTemplateButton IFlightYokeTemplate.wheel2Down
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(57);
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000B9B RID: 2971 RVA: 0x00043B63 File Offset: 0x00041D63
		IControllerTemplateButton IFlightYokeTemplate.wheel2Press
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(58);
			}
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000B9C RID: 2972 RVA: 0x00043AAA File Offset: 0x00041CAA
		IControllerTemplateButton IFlightYokeTemplate.consoleButton1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(43);
			}
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000B9D RID: 2973 RVA: 0x00043A82 File Offset: 0x00041C82
		IControllerTemplateButton IFlightYokeTemplate.consoleButton2
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(44);
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000B9E RID: 2974 RVA: 0x00043AFF File Offset: 0x00041CFF
		IControllerTemplateButton IFlightYokeTemplate.consoleButton3
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(45);
			}
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000B9F RID: 2975 RVA: 0x00043B09 File Offset: 0x00041D09
		IControllerTemplateButton IFlightYokeTemplate.consoleButton4
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(46);
			}
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000BA0 RID: 2976 RVA: 0x00043DD8 File Offset: 0x00041FD8
		IControllerTemplateButton IFlightYokeTemplate.consoleButton5
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(47);
			}
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000BA1 RID: 2977 RVA: 0x00043DE2 File Offset: 0x00041FE2
		IControllerTemplateButton IFlightYokeTemplate.consoleButton6
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(48);
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000BA2 RID: 2978 RVA: 0x00043DEC File Offset: 0x00041FEC
		IControllerTemplateButton IFlightYokeTemplate.consoleButton7
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(49);
			}
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000BA3 RID: 2979 RVA: 0x00043B13 File Offset: 0x00041D13
		IControllerTemplateButton IFlightYokeTemplate.consoleButton8
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(50);
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000BA4 RID: 2980 RVA: 0x00043B1D File Offset: 0x00041D1D
		IControllerTemplateButton IFlightYokeTemplate.consoleButton9
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(51);
			}
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000BA5 RID: 2981 RVA: 0x00043B27 File Offset: 0x00041D27
		IControllerTemplateButton IFlightYokeTemplate.consoleButton10
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(52);
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000BA6 RID: 2982 RVA: 0x00043B81 File Offset: 0x00041D81
		IControllerTemplateButton IFlightYokeTemplate.mode1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(61);
			}
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000BA7 RID: 2983 RVA: 0x00043B8B File Offset: 0x00041D8B
		IControllerTemplateButton IFlightYokeTemplate.mode2
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(62);
			}
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000BA8 RID: 2984 RVA: 0x00043B95 File Offset: 0x00041D95
		IControllerTemplateButton IFlightYokeTemplate.mode3
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(63);
			}
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000BA9 RID: 2985 RVA: 0x00043DF6 File Offset: 0x00041FF6
		IControllerTemplateYoke IFlightYokeTemplate.yoke
		{
			get
			{
				return base.GetElement<IControllerTemplateYoke>(69);
			}
		}

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000BAA RID: 2986 RVA: 0x00043E00 File Offset: 0x00042000
		IControllerTemplateThrottle IFlightYokeTemplate.lever1
		{
			get
			{
				return base.GetElement<IControllerTemplateThrottle>(70);
			}
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000BAB RID: 2987 RVA: 0x00043E0A File Offset: 0x0004200A
		IControllerTemplateThrottle IFlightYokeTemplate.lever2
		{
			get
			{
				return base.GetElement<IControllerTemplateThrottle>(71);
			}
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000BAC RID: 2988 RVA: 0x00043E14 File Offset: 0x00042014
		IControllerTemplateThrottle IFlightYokeTemplate.lever3
		{
			get
			{
				return base.GetElement<IControllerTemplateThrottle>(72);
			}
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000BAD RID: 2989 RVA: 0x00043E1E File Offset: 0x0004201E
		IControllerTemplateThrottle IFlightYokeTemplate.lever4
		{
			get
			{
				return base.GetElement<IControllerTemplateThrottle>(73);
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000BAE RID: 2990 RVA: 0x00043E28 File Offset: 0x00042028
		IControllerTemplateThrottle IFlightYokeTemplate.lever5
		{
			get
			{
				return base.GetElement<IControllerTemplateThrottle>(74);
			}
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000BAF RID: 2991 RVA: 0x00043E32 File Offset: 0x00042032
		IControllerTemplateHat IFlightYokeTemplate.leftGripHat
		{
			get
			{
				return base.GetElement<IControllerTemplateHat>(75);
			}
		}

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000BB0 RID: 2992 RVA: 0x00043E3C File Offset: 0x0004203C
		IControllerTemplateHat IFlightYokeTemplate.rightGripHat
		{
			get
			{
				return base.GetElement<IControllerTemplateHat>(76);
			}
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x00043972 File Offset: 0x00041B72
		public FlightYokeTemplate(object payload) : base(payload)
		{
		}

		// Token: 0x04001174 RID: 4468
		public static readonly Guid typeGuid = new Guid("f311fa16-0ccc-41c0-ac4b-50f7100bb8ff");

		// Token: 0x04001175 RID: 4469
		public const int elementId_rotateYoke = 0;

		// Token: 0x04001176 RID: 4470
		public const int elementId_yokeZ = 1;

		// Token: 0x04001177 RID: 4471
		public const int elementId_leftPaddle = 59;

		// Token: 0x04001178 RID: 4472
		public const int elementId_rightPaddle = 60;

		// Token: 0x04001179 RID: 4473
		public const int elementId_lever1Axis = 2;

		// Token: 0x0400117A RID: 4474
		public const int elementId_lever1MinDetent = 64;

		// Token: 0x0400117B RID: 4475
		public const int elementId_lever2Axis = 3;

		// Token: 0x0400117C RID: 4476
		public const int elementId_lever2MinDetent = 65;

		// Token: 0x0400117D RID: 4477
		public const int elementId_lever3Axis = 4;

		// Token: 0x0400117E RID: 4478
		public const int elementId_lever3MinDetent = 66;

		// Token: 0x0400117F RID: 4479
		public const int elementId_lever4Axis = 5;

		// Token: 0x04001180 RID: 4480
		public const int elementId_lever4MinDetent = 67;

		// Token: 0x04001181 RID: 4481
		public const int elementId_lever5Axis = 6;

		// Token: 0x04001182 RID: 4482
		public const int elementId_lever5MinDetent = 68;

		// Token: 0x04001183 RID: 4483
		public const int elementId_leftGripButton1 = 7;

		// Token: 0x04001184 RID: 4484
		public const int elementId_leftGripButton2 = 8;

		// Token: 0x04001185 RID: 4485
		public const int elementId_leftGripButton3 = 9;

		// Token: 0x04001186 RID: 4486
		public const int elementId_leftGripButton4 = 10;

		// Token: 0x04001187 RID: 4487
		public const int elementId_leftGripButton5 = 11;

		// Token: 0x04001188 RID: 4488
		public const int elementId_leftGripButton6 = 12;

		// Token: 0x04001189 RID: 4489
		public const int elementId_rightGripButton1 = 13;

		// Token: 0x0400118A RID: 4490
		public const int elementId_rightGripButton2 = 14;

		// Token: 0x0400118B RID: 4491
		public const int elementId_rightGripButton3 = 15;

		// Token: 0x0400118C RID: 4492
		public const int elementId_rightGripButton4 = 16;

		// Token: 0x0400118D RID: 4493
		public const int elementId_rightGripButton5 = 17;

		// Token: 0x0400118E RID: 4494
		public const int elementId_rightGripButton6 = 18;

		// Token: 0x0400118F RID: 4495
		public const int elementId_centerButton1 = 19;

		// Token: 0x04001190 RID: 4496
		public const int elementId_centerButton2 = 20;

		// Token: 0x04001191 RID: 4497
		public const int elementId_centerButton3 = 21;

		// Token: 0x04001192 RID: 4498
		public const int elementId_centerButton4 = 22;

		// Token: 0x04001193 RID: 4499
		public const int elementId_centerButton5 = 23;

		// Token: 0x04001194 RID: 4500
		public const int elementId_centerButton6 = 24;

		// Token: 0x04001195 RID: 4501
		public const int elementId_centerButton7 = 25;

		// Token: 0x04001196 RID: 4502
		public const int elementId_centerButton8 = 26;

		// Token: 0x04001197 RID: 4503
		public const int elementId_wheel1Up = 53;

		// Token: 0x04001198 RID: 4504
		public const int elementId_wheel1Down = 54;

		// Token: 0x04001199 RID: 4505
		public const int elementId_wheel1Press = 55;

		// Token: 0x0400119A RID: 4506
		public const int elementId_wheel2Up = 56;

		// Token: 0x0400119B RID: 4507
		public const int elementId_wheel2Down = 57;

		// Token: 0x0400119C RID: 4508
		public const int elementId_wheel2Press = 58;

		// Token: 0x0400119D RID: 4509
		public const int elementId_leftGripHatUp = 27;

		// Token: 0x0400119E RID: 4510
		public const int elementId_leftGripHatUpRight = 28;

		// Token: 0x0400119F RID: 4511
		public const int elementId_leftGripHatRight = 29;

		// Token: 0x040011A0 RID: 4512
		public const int elementId_leftGripHatDownRight = 30;

		// Token: 0x040011A1 RID: 4513
		public const int elementId_leftGripHatDown = 31;

		// Token: 0x040011A2 RID: 4514
		public const int elementId_leftGripHatDownLeft = 32;

		// Token: 0x040011A3 RID: 4515
		public const int elementId_leftGripHatLeft = 33;

		// Token: 0x040011A4 RID: 4516
		public const int elementId_leftGripHatUpLeft = 34;

		// Token: 0x040011A5 RID: 4517
		public const int elementId_rightGripHatUp = 35;

		// Token: 0x040011A6 RID: 4518
		public const int elementId_rightGripHatUpRight = 36;

		// Token: 0x040011A7 RID: 4519
		public const int elementId_rightGripHatRight = 37;

		// Token: 0x040011A8 RID: 4520
		public const int elementId_rightGripHatDownRight = 38;

		// Token: 0x040011A9 RID: 4521
		public const int elementId_rightGripHatDown = 39;

		// Token: 0x040011AA RID: 4522
		public const int elementId_rightGripHatDownLeft = 40;

		// Token: 0x040011AB RID: 4523
		public const int elementId_rightGripHatLeft = 41;

		// Token: 0x040011AC RID: 4524
		public const int elementId_rightGripHatUpLeft = 42;

		// Token: 0x040011AD RID: 4525
		public const int elementId_consoleButton1 = 43;

		// Token: 0x040011AE RID: 4526
		public const int elementId_consoleButton2 = 44;

		// Token: 0x040011AF RID: 4527
		public const int elementId_consoleButton3 = 45;

		// Token: 0x040011B0 RID: 4528
		public const int elementId_consoleButton4 = 46;

		// Token: 0x040011B1 RID: 4529
		public const int elementId_consoleButton5 = 47;

		// Token: 0x040011B2 RID: 4530
		public const int elementId_consoleButton6 = 48;

		// Token: 0x040011B3 RID: 4531
		public const int elementId_consoleButton7 = 49;

		// Token: 0x040011B4 RID: 4532
		public const int elementId_consoleButton8 = 50;

		// Token: 0x040011B5 RID: 4533
		public const int elementId_consoleButton9 = 51;

		// Token: 0x040011B6 RID: 4534
		public const int elementId_consoleButton10 = 52;

		// Token: 0x040011B7 RID: 4535
		public const int elementId_mode1 = 61;

		// Token: 0x040011B8 RID: 4536
		public const int elementId_mode2 = 62;

		// Token: 0x040011B9 RID: 4537
		public const int elementId_mode3 = 63;

		// Token: 0x040011BA RID: 4538
		public const int elementId_yoke = 69;

		// Token: 0x040011BB RID: 4539
		public const int elementId_lever1 = 70;

		// Token: 0x040011BC RID: 4540
		public const int elementId_lever2 = 71;

		// Token: 0x040011BD RID: 4541
		public const int elementId_lever3 = 72;

		// Token: 0x040011BE RID: 4542
		public const int elementId_lever4 = 73;

		// Token: 0x040011BF RID: 4543
		public const int elementId_lever5 = 74;

		// Token: 0x040011C0 RID: 4544
		public const int elementId_leftGripHat = 75;

		// Token: 0x040011C1 RID: 4545
		public const int elementId_rightGripHat = 76;
	}
}
