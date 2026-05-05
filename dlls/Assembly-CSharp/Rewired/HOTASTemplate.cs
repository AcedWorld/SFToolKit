using System;

namespace Rewired
{
	// Token: 0x0200026E RID: 622
	public sealed class HOTASTemplate : ControllerTemplate, IHOTASTemplate, IControllerTemplate
	{
		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06000B26 RID: 2854 RVA: 0x00043ACF File Offset: 0x00041CCF
		IControllerTemplateButton IHOTASTemplate.stickTrigger
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(3);
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x06000B27 RID: 2855 RVA: 0x000438D7 File Offset: 0x00041AD7
		IControllerTemplateButton IHOTASTemplate.stickTriggerStage2
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(4);
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06000B28 RID: 2856 RVA: 0x000438E0 File Offset: 0x00041AE0
		IControllerTemplateButton IHOTASTemplate.stickPinkyButton
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(5);
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000B29 RID: 2857 RVA: 0x00043AD8 File Offset: 0x00041CD8
		IControllerTemplateButton IHOTASTemplate.stickPinkyTrigger
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(154);
			}
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000B2A RID: 2858 RVA: 0x000438E9 File Offset: 0x00041AE9
		IControllerTemplateButton IHOTASTemplate.stickButton1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(6);
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000B2B RID: 2859 RVA: 0x000438F2 File Offset: 0x00041AF2
		IControllerTemplateButton IHOTASTemplate.stickButton2
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(7);
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06000B2C RID: 2860 RVA: 0x000438FB File Offset: 0x00041AFB
		IControllerTemplateButton IHOTASTemplate.stickButton3
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(8);
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000B2D RID: 2861 RVA: 0x00043904 File Offset: 0x00041B04
		IControllerTemplateButton IHOTASTemplate.stickButton4
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(9);
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000B2E RID: 2862 RVA: 0x0004390E File Offset: 0x00041B0E
		IControllerTemplateButton IHOTASTemplate.stickButton5
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(10);
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000B2F RID: 2863 RVA: 0x000439B0 File Offset: 0x00041BB0
		IControllerTemplateButton IHOTASTemplate.stickButton6
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(11);
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06000B30 RID: 2864 RVA: 0x00043922 File Offset: 0x00041B22
		IControllerTemplateButton IHOTASTemplate.stickButton7
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(12);
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000B31 RID: 2865 RVA: 0x000439BA File Offset: 0x00041BBA
		IControllerTemplateButton IHOTASTemplate.stickButton8
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(13);
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000B32 RID: 2866 RVA: 0x00043936 File Offset: 0x00041B36
		IControllerTemplateButton IHOTASTemplate.stickButton9
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(14);
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000B33 RID: 2867 RVA: 0x00043940 File Offset: 0x00041B40
		IControllerTemplateButton IHOTASTemplate.stickButton10
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(15);
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000B34 RID: 2868 RVA: 0x000439CE File Offset: 0x00041BCE
		IControllerTemplateButton IHOTASTemplate.stickBaseButton1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(18);
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000B35 RID: 2869 RVA: 0x000439D8 File Offset: 0x00041BD8
		IControllerTemplateButton IHOTASTemplate.stickBaseButton2
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(19);
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000B36 RID: 2870 RVA: 0x000439E2 File Offset: 0x00041BE2
		IControllerTemplateButton IHOTASTemplate.stickBaseButton3
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(20);
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000B37 RID: 2871 RVA: 0x000439EC File Offset: 0x00041BEC
		IControllerTemplateButton IHOTASTemplate.stickBaseButton4
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(21);
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000B38 RID: 2872 RVA: 0x000439F6 File Offset: 0x00041BF6
		IControllerTemplateButton IHOTASTemplate.stickBaseButton5
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(22);
			}
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000B39 RID: 2873 RVA: 0x00043A00 File Offset: 0x00041C00
		IControllerTemplateButton IHOTASTemplate.stickBaseButton6
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(23);
			}
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000B3A RID: 2874 RVA: 0x00043A0A File Offset: 0x00041C0A
		IControllerTemplateButton IHOTASTemplate.stickBaseButton7
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(24);
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06000B3B RID: 2875 RVA: 0x00043A14 File Offset: 0x00041C14
		IControllerTemplateButton IHOTASTemplate.stickBaseButton8
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(25);
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000B3C RID: 2876 RVA: 0x00043A1E File Offset: 0x00041C1E
		IControllerTemplateButton IHOTASTemplate.stickBaseButton9
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(26);
			}
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000B3D RID: 2877 RVA: 0x00043A28 File Offset: 0x00041C28
		IControllerTemplateButton IHOTASTemplate.stickBaseButton10
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(27);
			}
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000B3E RID: 2878 RVA: 0x00043AE5 File Offset: 0x00041CE5
		IControllerTemplateButton IHOTASTemplate.stickBaseButton11
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(161);
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000B3F RID: 2879 RVA: 0x00043AF2 File Offset: 0x00041CF2
		IControllerTemplateButton IHOTASTemplate.stickBaseButton12
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(162);
			}
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000B40 RID: 2880 RVA: 0x00043A82 File Offset: 0x00041C82
		IControllerTemplateButton IHOTASTemplate.mode1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(44);
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000B41 RID: 2881 RVA: 0x00043AFF File Offset: 0x00041CFF
		IControllerTemplateButton IHOTASTemplate.mode2
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(45);
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000B42 RID: 2882 RVA: 0x00043B09 File Offset: 0x00041D09
		IControllerTemplateButton IHOTASTemplate.mode3
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(46);
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06000B43 RID: 2883 RVA: 0x00043B13 File Offset: 0x00041D13
		IControllerTemplateButton IHOTASTemplate.throttleButton1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(50);
			}
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000B44 RID: 2884 RVA: 0x00043B1D File Offset: 0x00041D1D
		IControllerTemplateButton IHOTASTemplate.throttleButton2
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(51);
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000B45 RID: 2885 RVA: 0x00043B27 File Offset: 0x00041D27
		IControllerTemplateButton IHOTASTemplate.throttleButton3
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(52);
			}
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000B46 RID: 2886 RVA: 0x00043B31 File Offset: 0x00041D31
		IControllerTemplateButton IHOTASTemplate.throttleButton4
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(53);
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000B47 RID: 2887 RVA: 0x00043B3B File Offset: 0x00041D3B
		IControllerTemplateButton IHOTASTemplate.throttleButton5
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(54);
			}
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000B48 RID: 2888 RVA: 0x00043B45 File Offset: 0x00041D45
		IControllerTemplateButton IHOTASTemplate.throttleButton6
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(55);
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000B49 RID: 2889 RVA: 0x00043B4F File Offset: 0x00041D4F
		IControllerTemplateButton IHOTASTemplate.throttleButton7
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(56);
			}
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000B4A RID: 2890 RVA: 0x00043B59 File Offset: 0x00041D59
		IControllerTemplateButton IHOTASTemplate.throttleButton8
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(57);
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000B4B RID: 2891 RVA: 0x00043B63 File Offset: 0x00041D63
		IControllerTemplateButton IHOTASTemplate.throttleButton9
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(58);
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000B4C RID: 2892 RVA: 0x00043B6D File Offset: 0x00041D6D
		IControllerTemplateButton IHOTASTemplate.throttleButton10
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(59);
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000B4D RID: 2893 RVA: 0x00043B77 File Offset: 0x00041D77
		IControllerTemplateButton IHOTASTemplate.throttleBaseButton1
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(60);
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000B4E RID: 2894 RVA: 0x00043B81 File Offset: 0x00041D81
		IControllerTemplateButton IHOTASTemplate.throttleBaseButton2
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(61);
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000B4F RID: 2895 RVA: 0x00043B8B File Offset: 0x00041D8B
		IControllerTemplateButton IHOTASTemplate.throttleBaseButton3
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(62);
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000B50 RID: 2896 RVA: 0x00043B95 File Offset: 0x00041D95
		IControllerTemplateButton IHOTASTemplate.throttleBaseButton4
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(63);
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000B51 RID: 2897 RVA: 0x00043B9F File Offset: 0x00041D9F
		IControllerTemplateButton IHOTASTemplate.throttleBaseButton5
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(64);
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000B52 RID: 2898 RVA: 0x00043BA9 File Offset: 0x00041DA9
		IControllerTemplateButton IHOTASTemplate.throttleBaseButton6
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(65);
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000B53 RID: 2899 RVA: 0x00043BB3 File Offset: 0x00041DB3
		IControllerTemplateButton IHOTASTemplate.throttleBaseButton7
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(66);
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000B54 RID: 2900 RVA: 0x00043BBD File Offset: 0x00041DBD
		IControllerTemplateButton IHOTASTemplate.throttleBaseButton8
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(67);
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000B55 RID: 2901 RVA: 0x00043BC7 File Offset: 0x00041DC7
		IControllerTemplateButton IHOTASTemplate.throttleBaseButton9
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(68);
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000B56 RID: 2902 RVA: 0x00043BD1 File Offset: 0x00041DD1
		IControllerTemplateButton IHOTASTemplate.throttleBaseButton10
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(69);
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000B57 RID: 2903 RVA: 0x00043BDB File Offset: 0x00041DDB
		IControllerTemplateButton IHOTASTemplate.throttleBaseButton11
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(132);
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000B58 RID: 2904 RVA: 0x00043BE8 File Offset: 0x00041DE8
		IControllerTemplateButton IHOTASTemplate.throttleBaseButton12
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(133);
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000B59 RID: 2905 RVA: 0x00043BF5 File Offset: 0x00041DF5
		IControllerTemplateButton IHOTASTemplate.throttleBaseButton13
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(134);
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000B5A RID: 2906 RVA: 0x00043C02 File Offset: 0x00041E02
		IControllerTemplateButton IHOTASTemplate.throttleBaseButton14
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(135);
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000B5B RID: 2907 RVA: 0x00043C0F File Offset: 0x00041E0F
		IControllerTemplateButton IHOTASTemplate.throttleBaseButton15
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(136);
			}
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000B5C RID: 2908 RVA: 0x00043C1C File Offset: 0x00041E1C
		IControllerTemplateAxis IHOTASTemplate.throttleSlider1
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(70);
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000B5D RID: 2909 RVA: 0x00043C26 File Offset: 0x00041E26
		IControllerTemplateAxis IHOTASTemplate.throttleSlider2
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(71);
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000B5E RID: 2910 RVA: 0x00043C30 File Offset: 0x00041E30
		IControllerTemplateAxis IHOTASTemplate.throttleSlider3
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(72);
			}
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000B5F RID: 2911 RVA: 0x00043C3A File Offset: 0x00041E3A
		IControllerTemplateAxis IHOTASTemplate.throttleSlider4
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(73);
			}
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000B60 RID: 2912 RVA: 0x00043C44 File Offset: 0x00041E44
		IControllerTemplateAxis IHOTASTemplate.throttleDial1
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(74);
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000B61 RID: 2913 RVA: 0x00043C4E File Offset: 0x00041E4E
		IControllerTemplateAxis IHOTASTemplate.throttleDial2
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(142);
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000B62 RID: 2914 RVA: 0x00043C5B File Offset: 0x00041E5B
		IControllerTemplateAxis IHOTASTemplate.throttleDial3
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(143);
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000B63 RID: 2915 RVA: 0x00043C68 File Offset: 0x00041E68
		IControllerTemplateAxis IHOTASTemplate.throttleDial4
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(144);
			}
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06000B64 RID: 2916 RVA: 0x00043C75 File Offset: 0x00041E75
		IControllerTemplateButton IHOTASTemplate.throttleWheel1Forward
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(145);
			}
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000B65 RID: 2917 RVA: 0x00043C82 File Offset: 0x00041E82
		IControllerTemplateButton IHOTASTemplate.throttleWheel1Back
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(146);
			}
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000B66 RID: 2918 RVA: 0x00043C8F File Offset: 0x00041E8F
		IControllerTemplateButton IHOTASTemplate.throttleWheel1Press
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(147);
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000B67 RID: 2919 RVA: 0x00043C9C File Offset: 0x00041E9C
		IControllerTemplateButton IHOTASTemplate.throttleWheel2Forward
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(148);
			}
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000B68 RID: 2920 RVA: 0x00043CA9 File Offset: 0x00041EA9
		IControllerTemplateButton IHOTASTemplate.throttleWheel2Back
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(149);
			}
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000B69 RID: 2921 RVA: 0x00043CB6 File Offset: 0x00041EB6
		IControllerTemplateButton IHOTASTemplate.throttleWheel2Press
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(150);
			}
		}

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000B6A RID: 2922 RVA: 0x00043CC3 File Offset: 0x00041EC3
		IControllerTemplateButton IHOTASTemplate.throttleWheel3Forward
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(151);
			}
		}

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000B6B RID: 2923 RVA: 0x00043CD0 File Offset: 0x00041ED0
		IControllerTemplateButton IHOTASTemplate.throttleWheel3Back
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(152);
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000B6C RID: 2924 RVA: 0x00043CDD File Offset: 0x00041EDD
		IControllerTemplateButton IHOTASTemplate.throttleWheel3Press
		{
			get
			{
				return base.GetElement<IControllerTemplateButton>(153);
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000B6D RID: 2925 RVA: 0x00043CEA File Offset: 0x00041EEA
		IControllerTemplateAxis IHOTASTemplate.leftPedal
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(168);
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000B6E RID: 2926 RVA: 0x00043CF7 File Offset: 0x00041EF7
		IControllerTemplateAxis IHOTASTemplate.rightPedal
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(169);
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000B6F RID: 2927 RVA: 0x00043D04 File Offset: 0x00041F04
		IControllerTemplateAxis IHOTASTemplate.slidePedals
		{
			get
			{
				return base.GetElement<IControllerTemplateAxis>(170);
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06000B70 RID: 2928 RVA: 0x00043D11 File Offset: 0x00041F11
		IControllerTemplateStick IHOTASTemplate.stick
		{
			get
			{
				return base.GetElement<IControllerTemplateStick>(171);
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000B71 RID: 2929 RVA: 0x00043D1E File Offset: 0x00041F1E
		IControllerTemplateThumbStick IHOTASTemplate.stickMiniStick1
		{
			get
			{
				return base.GetElement<IControllerTemplateThumbStick>(172);
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000B72 RID: 2930 RVA: 0x00043D2B File Offset: 0x00041F2B
		IControllerTemplateThumbStick IHOTASTemplate.stickMiniStick2
		{
			get
			{
				return base.GetElement<IControllerTemplateThumbStick>(173);
			}
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000B73 RID: 2931 RVA: 0x00043D38 File Offset: 0x00041F38
		IControllerTemplateHat IHOTASTemplate.stickHat1
		{
			get
			{
				return base.GetElement<IControllerTemplateHat>(174);
			}
		}

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000B74 RID: 2932 RVA: 0x00043D45 File Offset: 0x00041F45
		IControllerTemplateHat IHOTASTemplate.stickHat2
		{
			get
			{
				return base.GetElement<IControllerTemplateHat>(175);
			}
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000B75 RID: 2933 RVA: 0x00043D52 File Offset: 0x00041F52
		IControllerTemplateHat IHOTASTemplate.stickHat3
		{
			get
			{
				return base.GetElement<IControllerTemplateHat>(176);
			}
		}

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06000B76 RID: 2934 RVA: 0x00043D5F File Offset: 0x00041F5F
		IControllerTemplateHat IHOTASTemplate.stickHat4
		{
			get
			{
				return base.GetElement<IControllerTemplateHat>(177);
			}
		}

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000B77 RID: 2935 RVA: 0x00043D6C File Offset: 0x00041F6C
		IControllerTemplateThrottle IHOTASTemplate.throttle1
		{
			get
			{
				return base.GetElement<IControllerTemplateThrottle>(178);
			}
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000B78 RID: 2936 RVA: 0x00043D79 File Offset: 0x00041F79
		IControllerTemplateThrottle IHOTASTemplate.throttle2
		{
			get
			{
				return base.GetElement<IControllerTemplateThrottle>(179);
			}
		}

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000B79 RID: 2937 RVA: 0x00043D86 File Offset: 0x00041F86
		IControllerTemplateThumbStick IHOTASTemplate.throttleMiniStick
		{
			get
			{
				return base.GetElement<IControllerTemplateThumbStick>(180);
			}
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000B7A RID: 2938 RVA: 0x00043D93 File Offset: 0x00041F93
		IControllerTemplateHat IHOTASTemplate.throttleHat1
		{
			get
			{
				return base.GetElement<IControllerTemplateHat>(181);
			}
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000B7B RID: 2939 RVA: 0x00043DA0 File Offset: 0x00041FA0
		IControllerTemplateHat IHOTASTemplate.throttleHat2
		{
			get
			{
				return base.GetElement<IControllerTemplateHat>(182);
			}
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000B7C RID: 2940 RVA: 0x00043DAD File Offset: 0x00041FAD
		IControllerTemplateHat IHOTASTemplate.throttleHat3
		{
			get
			{
				return base.GetElement<IControllerTemplateHat>(183);
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06000B7D RID: 2941 RVA: 0x00043DBA File Offset: 0x00041FBA
		IControllerTemplateHat IHOTASTemplate.throttleHat4
		{
			get
			{
				return base.GetElement<IControllerTemplateHat>(184);
			}
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x00043972 File Offset: 0x00041B72
		public HOTASTemplate(object payload) : base(payload)
		{
		}

		// Token: 0x040010CB RID: 4299
		public static readonly Guid typeGuid = new Guid("061a00cf-d8c2-4f8d-8cb5-a15a010bc53e");

		// Token: 0x040010CC RID: 4300
		public const int elementId_stickX = 0;

		// Token: 0x040010CD RID: 4301
		public const int elementId_stickY = 1;

		// Token: 0x040010CE RID: 4302
		public const int elementId_stickRotate = 2;

		// Token: 0x040010CF RID: 4303
		public const int elementId_stickMiniStick1X = 78;

		// Token: 0x040010D0 RID: 4304
		public const int elementId_stickMiniStick1Y = 79;

		// Token: 0x040010D1 RID: 4305
		public const int elementId_stickMiniStick1Press = 80;

		// Token: 0x040010D2 RID: 4306
		public const int elementId_stickMiniStick2X = 81;

		// Token: 0x040010D3 RID: 4307
		public const int elementId_stickMiniStick2Y = 82;

		// Token: 0x040010D4 RID: 4308
		public const int elementId_stickMiniStick2Press = 83;

		// Token: 0x040010D5 RID: 4309
		public const int elementId_stickTrigger = 3;

		// Token: 0x040010D6 RID: 4310
		public const int elementId_stickTriggerStage2 = 4;

		// Token: 0x040010D7 RID: 4311
		public const int elementId_stickPinkyButton = 5;

		// Token: 0x040010D8 RID: 4312
		public const int elementId_stickPinkyTrigger = 154;

		// Token: 0x040010D9 RID: 4313
		public const int elementId_stickButton1 = 6;

		// Token: 0x040010DA RID: 4314
		public const int elementId_stickButton2 = 7;

		// Token: 0x040010DB RID: 4315
		public const int elementId_stickButton3 = 8;

		// Token: 0x040010DC RID: 4316
		public const int elementId_stickButton4 = 9;

		// Token: 0x040010DD RID: 4317
		public const int elementId_stickButton5 = 10;

		// Token: 0x040010DE RID: 4318
		public const int elementId_stickButton6 = 11;

		// Token: 0x040010DF RID: 4319
		public const int elementId_stickButton7 = 12;

		// Token: 0x040010E0 RID: 4320
		public const int elementId_stickButton8 = 13;

		// Token: 0x040010E1 RID: 4321
		public const int elementId_stickButton9 = 14;

		// Token: 0x040010E2 RID: 4322
		public const int elementId_stickButton10 = 15;

		// Token: 0x040010E3 RID: 4323
		public const int elementId_stickBaseButton1 = 18;

		// Token: 0x040010E4 RID: 4324
		public const int elementId_stickBaseButton2 = 19;

		// Token: 0x040010E5 RID: 4325
		public const int elementId_stickBaseButton3 = 20;

		// Token: 0x040010E6 RID: 4326
		public const int elementId_stickBaseButton4 = 21;

		// Token: 0x040010E7 RID: 4327
		public const int elementId_stickBaseButton5 = 22;

		// Token: 0x040010E8 RID: 4328
		public const int elementId_stickBaseButton6 = 23;

		// Token: 0x040010E9 RID: 4329
		public const int elementId_stickBaseButton7 = 24;

		// Token: 0x040010EA RID: 4330
		public const int elementId_stickBaseButton8 = 25;

		// Token: 0x040010EB RID: 4331
		public const int elementId_stickBaseButton9 = 26;

		// Token: 0x040010EC RID: 4332
		public const int elementId_stickBaseButton10 = 27;

		// Token: 0x040010ED RID: 4333
		public const int elementId_stickBaseButton11 = 161;

		// Token: 0x040010EE RID: 4334
		public const int elementId_stickBaseButton12 = 162;

		// Token: 0x040010EF RID: 4335
		public const int elementId_stickHat1Up = 28;

		// Token: 0x040010F0 RID: 4336
		public const int elementId_stickHat1UpRight = 29;

		// Token: 0x040010F1 RID: 4337
		public const int elementId_stickHat1Right = 30;

		// Token: 0x040010F2 RID: 4338
		public const int elementId_stickHat1DownRight = 31;

		// Token: 0x040010F3 RID: 4339
		public const int elementId_stickHat1Down = 32;

		// Token: 0x040010F4 RID: 4340
		public const int elementId_stickHat1DownLeft = 33;

		// Token: 0x040010F5 RID: 4341
		public const int elementId_stickHat1Left = 34;

		// Token: 0x040010F6 RID: 4342
		public const int elementId_stickHat1Up_Left = 35;

		// Token: 0x040010F7 RID: 4343
		public const int elementId_stickHat2Up = 36;

		// Token: 0x040010F8 RID: 4344
		public const int elementId_stickHat2Up_right = 37;

		// Token: 0x040010F9 RID: 4345
		public const int elementId_stickHat2Right = 38;

		// Token: 0x040010FA RID: 4346
		public const int elementId_stickHat2Down_Right = 39;

		// Token: 0x040010FB RID: 4347
		public const int elementId_stickHat2Down = 40;

		// Token: 0x040010FC RID: 4348
		public const int elementId_stickHat2Down_Left = 41;

		// Token: 0x040010FD RID: 4349
		public const int elementId_stickHat2Left = 42;

		// Token: 0x040010FE RID: 4350
		public const int elementId_stickHat2Up_Left = 43;

		// Token: 0x040010FF RID: 4351
		public const int elementId_stickHat3Up = 84;

		// Token: 0x04001100 RID: 4352
		public const int elementId_stickHat3Up_Right = 85;

		// Token: 0x04001101 RID: 4353
		public const int elementId_stickHat3Right = 86;

		// Token: 0x04001102 RID: 4354
		public const int elementId_stickHat3Down_Right = 87;

		// Token: 0x04001103 RID: 4355
		public const int elementId_stickHat3Down = 88;

		// Token: 0x04001104 RID: 4356
		public const int elementId_stickHat3Down_Left = 89;

		// Token: 0x04001105 RID: 4357
		public const int elementId_stickHat3Left = 90;

		// Token: 0x04001106 RID: 4358
		public const int elementId_stickHat3Up_Left = 91;

		// Token: 0x04001107 RID: 4359
		public const int elementId_stickHat4Up = 92;

		// Token: 0x04001108 RID: 4360
		public const int elementId_stickHat4Up_Right = 93;

		// Token: 0x04001109 RID: 4361
		public const int elementId_stickHat4Right = 94;

		// Token: 0x0400110A RID: 4362
		public const int elementId_stickHat4Down_Right = 95;

		// Token: 0x0400110B RID: 4363
		public const int elementId_stickHat4Down = 96;

		// Token: 0x0400110C RID: 4364
		public const int elementId_stickHat4Down_Left = 97;

		// Token: 0x0400110D RID: 4365
		public const int elementId_stickHat4Left = 98;

		// Token: 0x0400110E RID: 4366
		public const int elementId_stickHat4Up_Left = 99;

		// Token: 0x0400110F RID: 4367
		public const int elementId_mode1 = 44;

		// Token: 0x04001110 RID: 4368
		public const int elementId_mode2 = 45;

		// Token: 0x04001111 RID: 4369
		public const int elementId_mode3 = 46;

		// Token: 0x04001112 RID: 4370
		public const int elementId_throttle1Axis = 49;

		// Token: 0x04001113 RID: 4371
		public const int elementId_throttle2Axis = 155;

		// Token: 0x04001114 RID: 4372
		public const int elementId_throttle1MinDetent = 166;

		// Token: 0x04001115 RID: 4373
		public const int elementId_throttle2MinDetent = 167;

		// Token: 0x04001116 RID: 4374
		public const int elementId_throttleButton1 = 50;

		// Token: 0x04001117 RID: 4375
		public const int elementId_throttleButton2 = 51;

		// Token: 0x04001118 RID: 4376
		public const int elementId_throttleButton3 = 52;

		// Token: 0x04001119 RID: 4377
		public const int elementId_throttleButton4 = 53;

		// Token: 0x0400111A RID: 4378
		public const int elementId_throttleButton5 = 54;

		// Token: 0x0400111B RID: 4379
		public const int elementId_throttleButton6 = 55;

		// Token: 0x0400111C RID: 4380
		public const int elementId_throttleButton7 = 56;

		// Token: 0x0400111D RID: 4381
		public const int elementId_throttleButton8 = 57;

		// Token: 0x0400111E RID: 4382
		public const int elementId_throttleButton9 = 58;

		// Token: 0x0400111F RID: 4383
		public const int elementId_throttleButton10 = 59;

		// Token: 0x04001120 RID: 4384
		public const int elementId_throttleBaseButton1 = 60;

		// Token: 0x04001121 RID: 4385
		public const int elementId_throttleBaseButton2 = 61;

		// Token: 0x04001122 RID: 4386
		public const int elementId_throttleBaseButton3 = 62;

		// Token: 0x04001123 RID: 4387
		public const int elementId_throttleBaseButton4 = 63;

		// Token: 0x04001124 RID: 4388
		public const int elementId_throttleBaseButton5 = 64;

		// Token: 0x04001125 RID: 4389
		public const int elementId_throttleBaseButton6 = 65;

		// Token: 0x04001126 RID: 4390
		public const int elementId_throttleBaseButton7 = 66;

		// Token: 0x04001127 RID: 4391
		public const int elementId_throttleBaseButton8 = 67;

		// Token: 0x04001128 RID: 4392
		public const int elementId_throttleBaseButton9 = 68;

		// Token: 0x04001129 RID: 4393
		public const int elementId_throttleBaseButton10 = 69;

		// Token: 0x0400112A RID: 4394
		public const int elementId_throttleBaseButton11 = 132;

		// Token: 0x0400112B RID: 4395
		public const int elementId_throttleBaseButton12 = 133;

		// Token: 0x0400112C RID: 4396
		public const int elementId_throttleBaseButton13 = 134;

		// Token: 0x0400112D RID: 4397
		public const int elementId_throttleBaseButton14 = 135;

		// Token: 0x0400112E RID: 4398
		public const int elementId_throttleBaseButton15 = 136;

		// Token: 0x0400112F RID: 4399
		public const int elementId_throttleSlider1 = 70;

		// Token: 0x04001130 RID: 4400
		public const int elementId_throttleSlider2 = 71;

		// Token: 0x04001131 RID: 4401
		public const int elementId_throttleSlider3 = 72;

		// Token: 0x04001132 RID: 4402
		public const int elementId_throttleSlider4 = 73;

		// Token: 0x04001133 RID: 4403
		public const int elementId_throttleDial1 = 74;

		// Token: 0x04001134 RID: 4404
		public const int elementId_throttleDial2 = 142;

		// Token: 0x04001135 RID: 4405
		public const int elementId_throttleDial3 = 143;

		// Token: 0x04001136 RID: 4406
		public const int elementId_throttleDial4 = 144;

		// Token: 0x04001137 RID: 4407
		public const int elementId_throttleMiniStickX = 75;

		// Token: 0x04001138 RID: 4408
		public const int elementId_throttleMiniStickY = 76;

		// Token: 0x04001139 RID: 4409
		public const int elementId_throttleMiniStickPress = 77;

		// Token: 0x0400113A RID: 4410
		public const int elementId_throttleWheel1Forward = 145;

		// Token: 0x0400113B RID: 4411
		public const int elementId_throttleWheel1Back = 146;

		// Token: 0x0400113C RID: 4412
		public const int elementId_throttleWheel1Press = 147;

		// Token: 0x0400113D RID: 4413
		public const int elementId_throttleWheel2Forward = 148;

		// Token: 0x0400113E RID: 4414
		public const int elementId_throttleWheel2Back = 149;

		// Token: 0x0400113F RID: 4415
		public const int elementId_throttleWheel2Press = 150;

		// Token: 0x04001140 RID: 4416
		public const int elementId_throttleWheel3Forward = 151;

		// Token: 0x04001141 RID: 4417
		public const int elementId_throttleWheel3Back = 152;

		// Token: 0x04001142 RID: 4418
		public const int elementId_throttleWheel3Press = 153;

		// Token: 0x04001143 RID: 4419
		public const int elementId_throttleHat1Up = 100;

		// Token: 0x04001144 RID: 4420
		public const int elementId_throttleHat1Up_Right = 101;

		// Token: 0x04001145 RID: 4421
		public const int elementId_throttleHat1Right = 102;

		// Token: 0x04001146 RID: 4422
		public const int elementId_throttleHat1Down_Right = 103;

		// Token: 0x04001147 RID: 4423
		public const int elementId_throttleHat1Down = 104;

		// Token: 0x04001148 RID: 4424
		public const int elementId_throttleHat1Down_Left = 105;

		// Token: 0x04001149 RID: 4425
		public const int elementId_throttleHat1Left = 106;

		// Token: 0x0400114A RID: 4426
		public const int elementId_throttleHat1Up_Left = 107;

		// Token: 0x0400114B RID: 4427
		public const int elementId_throttleHat2Up = 108;

		// Token: 0x0400114C RID: 4428
		public const int elementId_throttleHat2Up_Right = 109;

		// Token: 0x0400114D RID: 4429
		public const int elementId_throttleHat2Right = 110;

		// Token: 0x0400114E RID: 4430
		public const int elementId_throttleHat2Down_Right = 111;

		// Token: 0x0400114F RID: 4431
		public const int elementId_throttleHat2Down = 112;

		// Token: 0x04001150 RID: 4432
		public const int elementId_throttleHat2Down_Left = 113;

		// Token: 0x04001151 RID: 4433
		public const int elementId_throttleHat2Left = 114;

		// Token: 0x04001152 RID: 4434
		public const int elementId_throttleHat2Up_Left = 115;

		// Token: 0x04001153 RID: 4435
		public const int elementId_throttleHat3Up = 116;

		// Token: 0x04001154 RID: 4436
		public const int elementId_throttleHat3Up_Right = 117;

		// Token: 0x04001155 RID: 4437
		public const int elementId_throttleHat3Right = 118;

		// Token: 0x04001156 RID: 4438
		public const int elementId_throttleHat3Down_Right = 119;

		// Token: 0x04001157 RID: 4439
		public const int elementId_throttleHat3Down = 120;

		// Token: 0x04001158 RID: 4440
		public const int elementId_throttleHat3Down_Left = 121;

		// Token: 0x04001159 RID: 4441
		public const int elementId_throttleHat3Left = 122;

		// Token: 0x0400115A RID: 4442
		public const int elementId_throttleHat3Up_Left = 123;

		// Token: 0x0400115B RID: 4443
		public const int elementId_throttleHat4Up = 124;

		// Token: 0x0400115C RID: 4444
		public const int elementId_throttleHat4Up_Right = 125;

		// Token: 0x0400115D RID: 4445
		public const int elementId_throttleHat4Right = 126;

		// Token: 0x0400115E RID: 4446
		public const int elementId_throttleHat4Down_Right = 127;

		// Token: 0x0400115F RID: 4447
		public const int elementId_throttleHat4Down = 128;

		// Token: 0x04001160 RID: 4448
		public const int elementId_throttleHat4Down_Left = 129;

		// Token: 0x04001161 RID: 4449
		public const int elementId_throttleHat4Left = 130;

		// Token: 0x04001162 RID: 4450
		public const int elementId_throttleHat4Up_Left = 131;

		// Token: 0x04001163 RID: 4451
		public const int elementId_leftPedal = 168;

		// Token: 0x04001164 RID: 4452
		public const int elementId_rightPedal = 169;

		// Token: 0x04001165 RID: 4453
		public const int elementId_slidePedals = 170;

		// Token: 0x04001166 RID: 4454
		public const int elementId_stick = 171;

		// Token: 0x04001167 RID: 4455
		public const int elementId_stickMiniStick1 = 172;

		// Token: 0x04001168 RID: 4456
		public const int elementId_stickMiniStick2 = 173;

		// Token: 0x04001169 RID: 4457
		public const int elementId_stickHat1 = 174;

		// Token: 0x0400116A RID: 4458
		public const int elementId_stickHat2 = 175;

		// Token: 0x0400116B RID: 4459
		public const int elementId_stickHat3 = 176;

		// Token: 0x0400116C RID: 4460
		public const int elementId_stickHat4 = 177;

		// Token: 0x0400116D RID: 4461
		public const int elementId_throttle1 = 178;

		// Token: 0x0400116E RID: 4462
		public const int elementId_throttle2 = 179;

		// Token: 0x0400116F RID: 4463
		public const int elementId_throttleMiniStick = 180;

		// Token: 0x04001170 RID: 4464
		public const int elementId_throttleHat1 = 181;

		// Token: 0x04001171 RID: 4465
		public const int elementId_throttleHat2 = 182;

		// Token: 0x04001172 RID: 4466
		public const int elementId_throttleHat3 = 183;

		// Token: 0x04001173 RID: 4467
		public const int elementId_throttleHat4 = 184;
	}
}
