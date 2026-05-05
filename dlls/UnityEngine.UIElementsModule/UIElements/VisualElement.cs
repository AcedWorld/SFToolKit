using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Unity.Profiling;
using UnityEngine.Assertions;
using UnityEngine.UIElements.Experimental;
using UnityEngine.UIElements.StyleSheets;
using UnityEngine.UIElements.UIR;
using UnityEngine.Yoga;

namespace UnityEngine.UIElements
{
	// Token: 0x020002D5 RID: 725
	public class VisualElement : Focusable, IResolvedStyle, IStylePropertyAnimations, ITransform, ITransitionAnimations, IExperimentalFeatures, IVisualElementScheduler
	{
		// Token: 0x1700059B RID: 1435
		// (get) Token: 0x06001747 RID: 5959 RVA: 0x0002DD41 File Offset: 0x0002BF41
		public IResolvedStyle resolvedStyle
		{
			get
			{
				return this;
			}
		}

		// Token: 0x1700059C RID: 1436
		// (get) Token: 0x06001748 RID: 5960 RVA: 0x000593A3 File Offset: 0x000575A3
		Align IResolvedStyle.alignContent
		{
			get
			{
				return this.computedStyle.alignContent;
			}
		}

		// Token: 0x1700059D RID: 1437
		// (get) Token: 0x06001749 RID: 5961 RVA: 0x000593B0 File Offset: 0x000575B0
		Align IResolvedStyle.alignItems
		{
			get
			{
				return this.computedStyle.alignItems;
			}
		}

		// Token: 0x1700059E RID: 1438
		// (get) Token: 0x0600174A RID: 5962 RVA: 0x000593BD File Offset: 0x000575BD
		Align IResolvedStyle.alignSelf
		{
			get
			{
				return this.computedStyle.alignSelf;
			}
		}

		// Token: 0x1700059F RID: 1439
		// (get) Token: 0x0600174B RID: 5963 RVA: 0x000593CA File Offset: 0x000575CA
		Color IResolvedStyle.backgroundColor
		{
			get
			{
				return this.computedStyle.backgroundColor;
			}
		}

		// Token: 0x170005A0 RID: 1440
		// (get) Token: 0x0600174C RID: 5964 RVA: 0x000593D7 File Offset: 0x000575D7
		Background IResolvedStyle.backgroundImage
		{
			get
			{
				return this.computedStyle.backgroundImage;
			}
		}

		// Token: 0x170005A1 RID: 1441
		// (get) Token: 0x0600174D RID: 5965 RVA: 0x000593E4 File Offset: 0x000575E4
		BackgroundPosition IResolvedStyle.backgroundPositionX
		{
			get
			{
				return this.computedStyle.backgroundPositionX;
			}
		}

		// Token: 0x170005A2 RID: 1442
		// (get) Token: 0x0600174E RID: 5966 RVA: 0x000593F1 File Offset: 0x000575F1
		BackgroundPosition IResolvedStyle.backgroundPositionY
		{
			get
			{
				return this.computedStyle.backgroundPositionY;
			}
		}

		// Token: 0x170005A3 RID: 1443
		// (get) Token: 0x0600174F RID: 5967 RVA: 0x000593FE File Offset: 0x000575FE
		BackgroundRepeat IResolvedStyle.backgroundRepeat
		{
			get
			{
				return this.computedStyle.backgroundRepeat;
			}
		}

		// Token: 0x170005A4 RID: 1444
		// (get) Token: 0x06001750 RID: 5968 RVA: 0x0005940B File Offset: 0x0005760B
		BackgroundSize IResolvedStyle.backgroundSize
		{
			get
			{
				return this.computedStyle.backgroundSize;
			}
		}

		// Token: 0x170005A5 RID: 1445
		// (get) Token: 0x06001751 RID: 5969 RVA: 0x00059418 File Offset: 0x00057618
		Color IResolvedStyle.borderBottomColor
		{
			get
			{
				return this.computedStyle.borderBottomColor;
			}
		}

		// Token: 0x170005A6 RID: 1446
		// (get) Token: 0x06001752 RID: 5970 RVA: 0x00059428 File Offset: 0x00057628
		float IResolvedStyle.borderBottomLeftRadius
		{
			get
			{
				return this.computedStyle.borderBottomLeftRadius.value;
			}
		}

		// Token: 0x170005A7 RID: 1447
		// (get) Token: 0x06001753 RID: 5971 RVA: 0x00059448 File Offset: 0x00057648
		float IResolvedStyle.borderBottomRightRadius
		{
			get
			{
				return this.computedStyle.borderBottomRightRadius.value;
			}
		}

		// Token: 0x170005A8 RID: 1448
		// (get) Token: 0x06001754 RID: 5972 RVA: 0x00059468 File Offset: 0x00057668
		float IResolvedStyle.borderBottomWidth
		{
			get
			{
				return this.yogaNode.LayoutBorderBottom;
			}
		}

		// Token: 0x170005A9 RID: 1449
		// (get) Token: 0x06001755 RID: 5973 RVA: 0x00059475 File Offset: 0x00057675
		Color IResolvedStyle.borderLeftColor
		{
			get
			{
				return this.computedStyle.borderLeftColor;
			}
		}

		// Token: 0x170005AA RID: 1450
		// (get) Token: 0x06001756 RID: 5974 RVA: 0x00059482 File Offset: 0x00057682
		float IResolvedStyle.borderLeftWidth
		{
			get
			{
				return this.yogaNode.LayoutBorderLeft;
			}
		}

		// Token: 0x170005AB RID: 1451
		// (get) Token: 0x06001757 RID: 5975 RVA: 0x0005948F File Offset: 0x0005768F
		Color IResolvedStyle.borderRightColor
		{
			get
			{
				return this.computedStyle.borderRightColor;
			}
		}

		// Token: 0x170005AC RID: 1452
		// (get) Token: 0x06001758 RID: 5976 RVA: 0x0005949C File Offset: 0x0005769C
		float IResolvedStyle.borderRightWidth
		{
			get
			{
				return this.yogaNode.LayoutBorderRight;
			}
		}

		// Token: 0x170005AD RID: 1453
		// (get) Token: 0x06001759 RID: 5977 RVA: 0x000594A9 File Offset: 0x000576A9
		Color IResolvedStyle.borderTopColor
		{
			get
			{
				return this.computedStyle.borderTopColor;
			}
		}

		// Token: 0x170005AE RID: 1454
		// (get) Token: 0x0600175A RID: 5978 RVA: 0x000594B8 File Offset: 0x000576B8
		float IResolvedStyle.borderTopLeftRadius
		{
			get
			{
				return this.computedStyle.borderTopLeftRadius.value;
			}
		}

		// Token: 0x170005AF RID: 1455
		// (get) Token: 0x0600175B RID: 5979 RVA: 0x000594D8 File Offset: 0x000576D8
		float IResolvedStyle.borderTopRightRadius
		{
			get
			{
				return this.computedStyle.borderTopRightRadius.value;
			}
		}

		// Token: 0x170005B0 RID: 1456
		// (get) Token: 0x0600175C RID: 5980 RVA: 0x000594F8 File Offset: 0x000576F8
		float IResolvedStyle.borderTopWidth
		{
			get
			{
				return this.yogaNode.LayoutBorderTop;
			}
		}

		// Token: 0x170005B1 RID: 1457
		// (get) Token: 0x0600175D RID: 5981 RVA: 0x00059505 File Offset: 0x00057705
		float IResolvedStyle.bottom
		{
			get
			{
				return this.yogaNode.LayoutBottom;
			}
		}

		// Token: 0x170005B2 RID: 1458
		// (get) Token: 0x0600175E RID: 5982 RVA: 0x00059512 File Offset: 0x00057712
		Color IResolvedStyle.color
		{
			get
			{
				return this.computedStyle.color;
			}
		}

		// Token: 0x170005B3 RID: 1459
		// (get) Token: 0x0600175F RID: 5983 RVA: 0x0005951F File Offset: 0x0005771F
		DisplayStyle IResolvedStyle.display
		{
			get
			{
				return this.computedStyle.display;
			}
		}

		// Token: 0x170005B4 RID: 1460
		// (get) Token: 0x06001760 RID: 5984 RVA: 0x0005952C File Offset: 0x0005772C
		StyleFloat IResolvedStyle.flexBasis
		{
			get
			{
				return new StyleFloat(this.yogaNode.ComputedFlexBasis);
			}
		}

		// Token: 0x170005B5 RID: 1461
		// (get) Token: 0x06001761 RID: 5985 RVA: 0x0005953E File Offset: 0x0005773E
		FlexDirection IResolvedStyle.flexDirection
		{
			get
			{
				return this.computedStyle.flexDirection;
			}
		}

		// Token: 0x170005B6 RID: 1462
		// (get) Token: 0x06001762 RID: 5986 RVA: 0x0005954B File Offset: 0x0005774B
		float IResolvedStyle.flexGrow
		{
			get
			{
				return this.computedStyle.flexGrow;
			}
		}

		// Token: 0x170005B7 RID: 1463
		// (get) Token: 0x06001763 RID: 5987 RVA: 0x00059558 File Offset: 0x00057758
		float IResolvedStyle.flexShrink
		{
			get
			{
				return this.computedStyle.flexShrink;
			}
		}

		// Token: 0x170005B8 RID: 1464
		// (get) Token: 0x06001764 RID: 5988 RVA: 0x00059565 File Offset: 0x00057765
		Wrap IResolvedStyle.flexWrap
		{
			get
			{
				return this.computedStyle.flexWrap;
			}
		}

		// Token: 0x170005B9 RID: 1465
		// (get) Token: 0x06001765 RID: 5989 RVA: 0x00059574 File Offset: 0x00057774
		float IResolvedStyle.fontSize
		{
			get
			{
				return this.computedStyle.fontSize.value;
			}
		}

		// Token: 0x170005BA RID: 1466
		// (get) Token: 0x06001766 RID: 5990 RVA: 0x00059594 File Offset: 0x00057794
		float IResolvedStyle.height
		{
			get
			{
				return this.yogaNode.LayoutHeight;
			}
		}

		// Token: 0x170005BB RID: 1467
		// (get) Token: 0x06001767 RID: 5991 RVA: 0x000595A1 File Offset: 0x000577A1
		Justify IResolvedStyle.justifyContent
		{
			get
			{
				return this.computedStyle.justifyContent;
			}
		}

		// Token: 0x170005BC RID: 1468
		// (get) Token: 0x06001768 RID: 5992 RVA: 0x000595AE File Offset: 0x000577AE
		float IResolvedStyle.left
		{
			get
			{
				return this.yogaNode.LayoutX;
			}
		}

		// Token: 0x170005BD RID: 1469
		// (get) Token: 0x06001769 RID: 5993 RVA: 0x000595BC File Offset: 0x000577BC
		float IResolvedStyle.letterSpacing
		{
			get
			{
				return this.computedStyle.letterSpacing.value;
			}
		}

		// Token: 0x170005BE RID: 1470
		// (get) Token: 0x0600176A RID: 5994 RVA: 0x000595DC File Offset: 0x000577DC
		float IResolvedStyle.marginBottom
		{
			get
			{
				return this.yogaNode.LayoutMarginBottom;
			}
		}

		// Token: 0x170005BF RID: 1471
		// (get) Token: 0x0600176B RID: 5995 RVA: 0x000595E9 File Offset: 0x000577E9
		float IResolvedStyle.marginLeft
		{
			get
			{
				return this.yogaNode.LayoutMarginLeft;
			}
		}

		// Token: 0x170005C0 RID: 1472
		// (get) Token: 0x0600176C RID: 5996 RVA: 0x000595F6 File Offset: 0x000577F6
		float IResolvedStyle.marginRight
		{
			get
			{
				return this.yogaNode.LayoutMarginRight;
			}
		}

		// Token: 0x170005C1 RID: 1473
		// (get) Token: 0x0600176D RID: 5997 RVA: 0x00059603 File Offset: 0x00057803
		float IResolvedStyle.marginTop
		{
			get
			{
				return this.yogaNode.LayoutMarginTop;
			}
		}

		// Token: 0x170005C2 RID: 1474
		// (get) Token: 0x0600176E RID: 5998 RVA: 0x00059610 File Offset: 0x00057810
		StyleFloat IResolvedStyle.maxHeight
		{
			get
			{
				return this.ResolveLengthValue(this.computedStyle.maxHeight, false);
			}
		}

		// Token: 0x170005C3 RID: 1475
		// (get) Token: 0x0600176F RID: 5999 RVA: 0x00059624 File Offset: 0x00057824
		StyleFloat IResolvedStyle.maxWidth
		{
			get
			{
				return this.ResolveLengthValue(this.computedStyle.maxWidth, true);
			}
		}

		// Token: 0x170005C4 RID: 1476
		// (get) Token: 0x06001770 RID: 6000 RVA: 0x00059638 File Offset: 0x00057838
		StyleFloat IResolvedStyle.minHeight
		{
			get
			{
				return this.ResolveLengthValue(this.computedStyle.minHeight, false);
			}
		}

		// Token: 0x170005C5 RID: 1477
		// (get) Token: 0x06001771 RID: 6001 RVA: 0x0005964C File Offset: 0x0005784C
		StyleFloat IResolvedStyle.minWidth
		{
			get
			{
				return this.ResolveLengthValue(this.computedStyle.minWidth, true);
			}
		}

		// Token: 0x170005C6 RID: 1478
		// (get) Token: 0x06001772 RID: 6002 RVA: 0x00059660 File Offset: 0x00057860
		float IResolvedStyle.opacity
		{
			get
			{
				return this.computedStyle.opacity;
			}
		}

		// Token: 0x170005C7 RID: 1479
		// (get) Token: 0x06001773 RID: 6003 RVA: 0x0005966D File Offset: 0x0005786D
		float IResolvedStyle.paddingBottom
		{
			get
			{
				return this.yogaNode.LayoutPaddingBottom;
			}
		}

		// Token: 0x170005C8 RID: 1480
		// (get) Token: 0x06001774 RID: 6004 RVA: 0x0005967A File Offset: 0x0005787A
		float IResolvedStyle.paddingLeft
		{
			get
			{
				return this.yogaNode.LayoutPaddingLeft;
			}
		}

		// Token: 0x170005C9 RID: 1481
		// (get) Token: 0x06001775 RID: 6005 RVA: 0x00059687 File Offset: 0x00057887
		float IResolvedStyle.paddingRight
		{
			get
			{
				return this.yogaNode.LayoutPaddingRight;
			}
		}

		// Token: 0x170005CA RID: 1482
		// (get) Token: 0x06001776 RID: 6006 RVA: 0x00059694 File Offset: 0x00057894
		float IResolvedStyle.paddingTop
		{
			get
			{
				return this.yogaNode.LayoutPaddingTop;
			}
		}

		// Token: 0x170005CB RID: 1483
		// (get) Token: 0x06001777 RID: 6007 RVA: 0x000596A1 File Offset: 0x000578A1
		Position IResolvedStyle.position
		{
			get
			{
				return this.computedStyle.position;
			}
		}

		// Token: 0x170005CC RID: 1484
		// (get) Token: 0x06001778 RID: 6008 RVA: 0x000596AE File Offset: 0x000578AE
		float IResolvedStyle.right
		{
			get
			{
				return this.yogaNode.LayoutRight;
			}
		}

		// Token: 0x170005CD RID: 1485
		// (get) Token: 0x06001779 RID: 6009 RVA: 0x000596BB File Offset: 0x000578BB
		Rotate IResolvedStyle.rotate
		{
			get
			{
				return this.computedStyle.rotate;
			}
		}

		// Token: 0x170005CE RID: 1486
		// (get) Token: 0x0600177A RID: 6010 RVA: 0x000596C8 File Offset: 0x000578C8
		Scale IResolvedStyle.scale
		{
			get
			{
				return this.computedStyle.scale;
			}
		}

		// Token: 0x170005CF RID: 1487
		// (get) Token: 0x0600177B RID: 6011 RVA: 0x000596D5 File Offset: 0x000578D5
		TextOverflow IResolvedStyle.textOverflow
		{
			get
			{
				return this.computedStyle.textOverflow;
			}
		}

		// Token: 0x170005D0 RID: 1488
		// (get) Token: 0x0600177C RID: 6012 RVA: 0x000596E2 File Offset: 0x000578E2
		float IResolvedStyle.top
		{
			get
			{
				return this.yogaNode.LayoutY;
			}
		}

		// Token: 0x170005D1 RID: 1489
		// (get) Token: 0x0600177D RID: 6013 RVA: 0x000596EF File Offset: 0x000578EF
		Vector3 IResolvedStyle.transformOrigin
		{
			get
			{
				return this.ResolveTransformOrigin();
			}
		}

		// Token: 0x170005D2 RID: 1490
		// (get) Token: 0x0600177E RID: 6014 RVA: 0x000596F7 File Offset: 0x000578F7
		IEnumerable<TimeValue> IResolvedStyle.transitionDelay
		{
			get
			{
				return this.computedStyle.transitionDelay;
			}
		}

		// Token: 0x170005D3 RID: 1491
		// (get) Token: 0x0600177F RID: 6015 RVA: 0x00059704 File Offset: 0x00057904
		IEnumerable<TimeValue> IResolvedStyle.transitionDuration
		{
			get
			{
				return this.computedStyle.transitionDuration;
			}
		}

		// Token: 0x170005D4 RID: 1492
		// (get) Token: 0x06001780 RID: 6016 RVA: 0x00059711 File Offset: 0x00057911
		IEnumerable<StylePropertyName> IResolvedStyle.transitionProperty
		{
			get
			{
				return this.computedStyle.transitionProperty;
			}
		}

		// Token: 0x170005D5 RID: 1493
		// (get) Token: 0x06001781 RID: 6017 RVA: 0x0005971E File Offset: 0x0005791E
		IEnumerable<EasingFunction> IResolvedStyle.transitionTimingFunction
		{
			get
			{
				return this.computedStyle.transitionTimingFunction;
			}
		}

		// Token: 0x170005D6 RID: 1494
		// (get) Token: 0x06001782 RID: 6018 RVA: 0x0005972B File Offset: 0x0005792B
		Vector3 IResolvedStyle.translate
		{
			get
			{
				return this.ResolveTranslate();
			}
		}

		// Token: 0x170005D7 RID: 1495
		// (get) Token: 0x06001783 RID: 6019 RVA: 0x00059733 File Offset: 0x00057933
		Color IResolvedStyle.unityBackgroundImageTintColor
		{
			get
			{
				return this.computedStyle.unityBackgroundImageTintColor;
			}
		}

		// Token: 0x170005D8 RID: 1496
		// (get) Token: 0x06001784 RID: 6020 RVA: 0x00059740 File Offset: 0x00057940
		Font IResolvedStyle.unityFont
		{
			get
			{
				return this.computedStyle.unityFont;
			}
		}

		// Token: 0x170005D9 RID: 1497
		// (get) Token: 0x06001785 RID: 6021 RVA: 0x0005974D File Offset: 0x0005794D
		FontDefinition IResolvedStyle.unityFontDefinition
		{
			get
			{
				return this.computedStyle.unityFontDefinition;
			}
		}

		// Token: 0x170005DA RID: 1498
		// (get) Token: 0x06001786 RID: 6022 RVA: 0x0005975A File Offset: 0x0005795A
		FontStyle IResolvedStyle.unityFontStyleAndWeight
		{
			get
			{
				return this.computedStyle.unityFontStyleAndWeight;
			}
		}

		// Token: 0x170005DB RID: 1499
		// (get) Token: 0x06001787 RID: 6023 RVA: 0x00059768 File Offset: 0x00057968
		float IResolvedStyle.unityParagraphSpacing
		{
			get
			{
				return this.computedStyle.unityParagraphSpacing.value;
			}
		}

		// Token: 0x170005DC RID: 1500
		// (get) Token: 0x06001788 RID: 6024 RVA: 0x00059788 File Offset: 0x00057988
		int IResolvedStyle.unitySliceBottom
		{
			get
			{
				return this.computedStyle.unitySliceBottom;
			}
		}

		// Token: 0x170005DD RID: 1501
		// (get) Token: 0x06001789 RID: 6025 RVA: 0x00059795 File Offset: 0x00057995
		int IResolvedStyle.unitySliceLeft
		{
			get
			{
				return this.computedStyle.unitySliceLeft;
			}
		}

		// Token: 0x170005DE RID: 1502
		// (get) Token: 0x0600178A RID: 6026 RVA: 0x000597A2 File Offset: 0x000579A2
		int IResolvedStyle.unitySliceRight
		{
			get
			{
				return this.computedStyle.unitySliceRight;
			}
		}

		// Token: 0x170005DF RID: 1503
		// (get) Token: 0x0600178B RID: 6027 RVA: 0x000597AF File Offset: 0x000579AF
		float IResolvedStyle.unitySliceScale
		{
			get
			{
				return this.computedStyle.unitySliceScale;
			}
		}

		// Token: 0x170005E0 RID: 1504
		// (get) Token: 0x0600178C RID: 6028 RVA: 0x000597BC File Offset: 0x000579BC
		int IResolvedStyle.unitySliceTop
		{
			get
			{
				return this.computedStyle.unitySliceTop;
			}
		}

		// Token: 0x170005E1 RID: 1505
		// (get) Token: 0x0600178D RID: 6029 RVA: 0x000597C9 File Offset: 0x000579C9
		TextAnchor IResolvedStyle.unityTextAlign
		{
			get
			{
				return this.computedStyle.unityTextAlign;
			}
		}

		// Token: 0x170005E2 RID: 1506
		// (get) Token: 0x0600178E RID: 6030 RVA: 0x000597D6 File Offset: 0x000579D6
		Color IResolvedStyle.unityTextOutlineColor
		{
			get
			{
				return this.computedStyle.unityTextOutlineColor;
			}
		}

		// Token: 0x170005E3 RID: 1507
		// (get) Token: 0x0600178F RID: 6031 RVA: 0x000597E3 File Offset: 0x000579E3
		float IResolvedStyle.unityTextOutlineWidth
		{
			get
			{
				return this.computedStyle.unityTextOutlineWidth;
			}
		}

		// Token: 0x170005E4 RID: 1508
		// (get) Token: 0x06001790 RID: 6032 RVA: 0x000597F0 File Offset: 0x000579F0
		TextOverflowPosition IResolvedStyle.unityTextOverflowPosition
		{
			get
			{
				return this.computedStyle.unityTextOverflowPosition;
			}
		}

		// Token: 0x170005E5 RID: 1509
		// (get) Token: 0x06001791 RID: 6033 RVA: 0x000597FD File Offset: 0x000579FD
		Visibility IResolvedStyle.visibility
		{
			get
			{
				return this.computedStyle.visibility;
			}
		}

		// Token: 0x170005E6 RID: 1510
		// (get) Token: 0x06001792 RID: 6034 RVA: 0x0005980A File Offset: 0x00057A0A
		WhiteSpace IResolvedStyle.whiteSpace
		{
			get
			{
				return this.computedStyle.whiteSpace;
			}
		}

		// Token: 0x170005E7 RID: 1511
		// (get) Token: 0x06001793 RID: 6035 RVA: 0x00059817 File Offset: 0x00057A17
		float IResolvedStyle.width
		{
			get
			{
				return this.yogaNode.LayoutWidth;
			}
		}

		// Token: 0x170005E8 RID: 1512
		// (get) Token: 0x06001794 RID: 6036 RVA: 0x00059824 File Offset: 0x00057A24
		float IResolvedStyle.wordSpacing
		{
			get
			{
				return this.computedStyle.wordSpacing.value;
			}
		}

		// Token: 0x170005E9 RID: 1513
		// (get) Token: 0x06001795 RID: 6037 RVA: 0x00059844 File Offset: 0x00057A44
		internal bool hasRunningAnimations
		{
			get
			{
				return this.styleAnimation.runningAnimationCount > 0;
			}
		}

		// Token: 0x170005EA RID: 1514
		// (get) Token: 0x06001796 RID: 6038 RVA: 0x00059854 File Offset: 0x00057A54
		internal bool hasCompletedAnimations
		{
			get
			{
				return this.styleAnimation.completedAnimationCount > 0;
			}
		}

		// Token: 0x170005EB RID: 1515
		// (get) Token: 0x06001797 RID: 6039 RVA: 0x00059864 File Offset: 0x00057A64
		// (set) Token: 0x06001798 RID: 6040 RVA: 0x0005986C File Offset: 0x00057A6C
		int IStylePropertyAnimations.runningAnimationCount { get; set; }

		// Token: 0x170005EC RID: 1516
		// (get) Token: 0x06001799 RID: 6041 RVA: 0x00059875 File Offset: 0x00057A75
		// (set) Token: 0x0600179A RID: 6042 RVA: 0x0005987D File Offset: 0x00057A7D
		int IStylePropertyAnimations.completedAnimationCount { get; set; }

		// Token: 0x0600179B RID: 6043 RVA: 0x00059888 File Offset: 0x00057A88
		private IStylePropertyAnimationSystem GetStylePropertyAnimationSystem()
		{
			BaseVisualElementPanel elementPanel = this.elementPanel;
			return (elementPanel != null) ? elementPanel.styleAnimationSystem : null;
		}

		// Token: 0x170005ED RID: 1517
		// (get) Token: 0x0600179C RID: 6044 RVA: 0x0002DD41 File Offset: 0x0002BF41
		internal IStylePropertyAnimations styleAnimation
		{
			get
			{
				return this;
			}
		}

		// Token: 0x0600179D RID: 6045 RVA: 0x000598AC File Offset: 0x00057AAC
		bool IStylePropertyAnimations.Start(StylePropertyId id, float from, float to, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return this.GetStylePropertyAnimationSystem().StartTransition(this, id, from, to, durationMs, delayMs, easingCurve);
		}

		// Token: 0x0600179E RID: 6046 RVA: 0x000598D4 File Offset: 0x00057AD4
		bool IStylePropertyAnimations.Start(StylePropertyId id, int from, int to, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return this.GetStylePropertyAnimationSystem().StartTransition(this, id, from, to, durationMs, delayMs, easingCurve);
		}

		// Token: 0x0600179F RID: 6047 RVA: 0x000598FC File Offset: 0x00057AFC
		bool IStylePropertyAnimations.Start(StylePropertyId id, Length from, Length to, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return this.GetStylePropertyAnimationSystem().StartTransition(this, id, from, to, durationMs, delayMs, easingCurve);
		}

		// Token: 0x060017A0 RID: 6048 RVA: 0x00059924 File Offset: 0x00057B24
		bool IStylePropertyAnimations.Start(StylePropertyId id, Color from, Color to, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return this.GetStylePropertyAnimationSystem().StartTransition(this, id, from, to, durationMs, delayMs, easingCurve);
		}

		// Token: 0x060017A1 RID: 6049 RVA: 0x0005994C File Offset: 0x00057B4C
		bool IStylePropertyAnimations.StartEnum(StylePropertyId id, int from, int to, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return this.GetStylePropertyAnimationSystem().StartTransition(this, id, from, to, durationMs, delayMs, easingCurve);
		}

		// Token: 0x060017A2 RID: 6050 RVA: 0x00059974 File Offset: 0x00057B74
		bool IStylePropertyAnimations.Start(StylePropertyId id, Background from, Background to, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return this.GetStylePropertyAnimationSystem().StartTransition(this, id, from, to, durationMs, delayMs, easingCurve);
		}

		// Token: 0x060017A3 RID: 6051 RVA: 0x0005999C File Offset: 0x00057B9C
		bool IStylePropertyAnimations.Start(StylePropertyId id, FontDefinition from, FontDefinition to, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return this.GetStylePropertyAnimationSystem().StartTransition(this, id, from, to, durationMs, delayMs, easingCurve);
		}

		// Token: 0x060017A4 RID: 6052 RVA: 0x000599C4 File Offset: 0x00057BC4
		bool IStylePropertyAnimations.Start(StylePropertyId id, Font from, Font to, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return this.GetStylePropertyAnimationSystem().StartTransition(this, id, from, to, durationMs, delayMs, easingCurve);
		}

		// Token: 0x060017A5 RID: 6053 RVA: 0x000599EC File Offset: 0x00057BEC
		bool IStylePropertyAnimations.Start(StylePropertyId id, TextShadow from, TextShadow to, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return this.GetStylePropertyAnimationSystem().StartTransition(this, id, from, to, durationMs, delayMs, easingCurve);
		}

		// Token: 0x060017A6 RID: 6054 RVA: 0x00059A14 File Offset: 0x00057C14
		bool IStylePropertyAnimations.Start(StylePropertyId id, Scale from, Scale to, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return this.GetStylePropertyAnimationSystem().StartTransition(this, id, from, to, durationMs, delayMs, easingCurve);
		}

		// Token: 0x060017A7 RID: 6055 RVA: 0x00059A3C File Offset: 0x00057C3C
		bool IStylePropertyAnimations.Start(StylePropertyId id, Translate from, Translate to, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return this.GetStylePropertyAnimationSystem().StartTransition(this, id, from, to, durationMs, delayMs, easingCurve);
		}

		// Token: 0x060017A8 RID: 6056 RVA: 0x00059A64 File Offset: 0x00057C64
		bool IStylePropertyAnimations.Start(StylePropertyId id, Rotate from, Rotate to, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return this.GetStylePropertyAnimationSystem().StartTransition(this, id, from, to, durationMs, delayMs, easingCurve);
		}

		// Token: 0x060017A9 RID: 6057 RVA: 0x00059A8C File Offset: 0x00057C8C
		bool IStylePropertyAnimations.Start(StylePropertyId id, TransformOrigin from, TransformOrigin to, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return this.GetStylePropertyAnimationSystem().StartTransition(this, id, from, to, durationMs, delayMs, easingCurve);
		}

		// Token: 0x060017AA RID: 6058 RVA: 0x00059AB4 File Offset: 0x00057CB4
		bool IStylePropertyAnimations.Start(StylePropertyId id, BackgroundPosition from, BackgroundPosition to, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return this.GetStylePropertyAnimationSystem().StartTransition(this, id, from, to, durationMs, delayMs, easingCurve);
		}

		// Token: 0x060017AB RID: 6059 RVA: 0x00059ADC File Offset: 0x00057CDC
		bool IStylePropertyAnimations.Start(StylePropertyId id, BackgroundRepeat from, BackgroundRepeat to, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return this.GetStylePropertyAnimationSystem().StartTransition(this, id, from, to, durationMs, delayMs, easingCurve);
		}

		// Token: 0x060017AC RID: 6060 RVA: 0x00059B04 File Offset: 0x00057D04
		bool IStylePropertyAnimations.Start(StylePropertyId id, BackgroundSize from, BackgroundSize to, int durationMs, int delayMs, Func<float, float> easingCurve)
		{
			return this.GetStylePropertyAnimationSystem().StartTransition(this, id, from, to, durationMs, delayMs, easingCurve);
		}

		// Token: 0x060017AD RID: 6061 RVA: 0x00059B2B File Offset: 0x00057D2B
		void IStylePropertyAnimations.CancelAnimation(StylePropertyId id)
		{
			IStylePropertyAnimationSystem stylePropertyAnimationSystem = this.GetStylePropertyAnimationSystem();
			if (stylePropertyAnimationSystem != null)
			{
				stylePropertyAnimationSystem.CancelAnimation(this, id);
			}
		}

		// Token: 0x060017AE RID: 6062 RVA: 0x00059B44 File Offset: 0x00057D44
		void IStylePropertyAnimations.CancelAllAnimations()
		{
			bool flag = this.hasRunningAnimations || this.hasCompletedAnimations;
			if (flag)
			{
				IStylePropertyAnimationSystem stylePropertyAnimationSystem = this.GetStylePropertyAnimationSystem();
				if (stylePropertyAnimationSystem != null)
				{
					stylePropertyAnimationSystem.CancelAllAnimations(this);
				}
			}
		}

		// Token: 0x060017AF RID: 6063 RVA: 0x00059B7C File Offset: 0x00057D7C
		bool IStylePropertyAnimations.HasRunningAnimation(StylePropertyId id)
		{
			return this.hasRunningAnimations && this.GetStylePropertyAnimationSystem().HasRunningAnimation(this, id);
		}

		// Token: 0x060017B0 RID: 6064 RVA: 0x00059BA6 File Offset: 0x00057DA6
		void IStylePropertyAnimations.UpdateAnimation(StylePropertyId id)
		{
			this.GetStylePropertyAnimationSystem().UpdateAnimation(this, id);
		}

		// Token: 0x060017B1 RID: 6065 RVA: 0x00059BB8 File Offset: 0x00057DB8
		void IStylePropertyAnimations.GetAllAnimations(List<StylePropertyId> outPropertyIds)
		{
			bool flag = this.hasRunningAnimations || this.hasCompletedAnimations;
			if (flag)
			{
				this.GetStylePropertyAnimationSystem().GetAllAnimations(this, outPropertyIds);
			}
		}

		// Token: 0x060017B2 RID: 6066 RVA: 0x00059BEC File Offset: 0x00057DEC
		internal bool TryConvertLengthUnits(StylePropertyId id, ref Length from, ref Length to, int subPropertyIndex = 0)
		{
			bool flag = from.IsAuto() || from.IsNone() || to.IsAuto() || to.IsNone();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = float.IsNaN(from.value) || float.IsNaN(to.value);
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = from.unit == to.unit;
					if (flag3)
					{
						result = true;
					}
					else
					{
						bool flag4 = to.unit == LengthUnit.Pixel;
						if (flag4)
						{
							bool flag5 = Mathf.Approximately(from.value, 0f);
							if (flag5)
							{
								from = new Length(0f, LengthUnit.Pixel);
								return true;
							}
							float? parentSizeForLengthConversion = this.GetParentSizeForLengthConversion(id, subPropertyIndex);
							bool flag6 = parentSizeForLengthConversion == null || parentSizeForLengthConversion.Value < 0f;
							if (flag6)
							{
								return false;
							}
							from = new Length(from.value * parentSizeForLengthConversion.Value / 100f, LengthUnit.Pixel);
						}
						else
						{
							Assert.AreEqual<LengthUnit>(LengthUnit.Percent, to.unit);
							float? parentSizeForLengthConversion2 = this.GetParentSizeForLengthConversion(id, subPropertyIndex);
							bool flag7 = parentSizeForLengthConversion2 == null || parentSizeForLengthConversion2.Value <= 0f;
							if (flag7)
							{
								return false;
							}
							from = new Length(from.value * 100f / parentSizeForLengthConversion2.Value, LengthUnit.Percent);
						}
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x060017B3 RID: 6067 RVA: 0x00059D64 File Offset: 0x00057F64
		internal bool TryConvertTransformOriginUnits(ref TransformOrigin from, ref TransformOrigin to)
		{
			Length x = from.x;
			Length y = from.y;
			Length x2 = to.x;
			Length y2 = to.y;
			bool flag = !this.TryConvertLengthUnits(StylePropertyId.TransformOrigin, ref x, ref x2, 0);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = !this.TryConvertLengthUnits(StylePropertyId.TransformOrigin, ref y, ref y2, 1);
				if (flag2)
				{
					result = false;
				}
				else
				{
					from.x = x;
					from.y = y;
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060017B4 RID: 6068 RVA: 0x00059DE4 File Offset: 0x00057FE4
		internal bool TryConvertTranslateUnits(ref Translate from, ref Translate to)
		{
			Length x = from.x;
			Length y = from.y;
			Length x2 = to.x;
			Length y2 = to.y;
			bool flag = !this.TryConvertLengthUnits(StylePropertyId.Translate, ref x, ref x2, 0);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = !this.TryConvertLengthUnits(StylePropertyId.Translate, ref y, ref y2, 1);
				if (flag2)
				{
					result = false;
				}
				else
				{
					from.x = x;
					from.y = y;
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060017B5 RID: 6069 RVA: 0x00059E64 File Offset: 0x00058064
		internal bool TryConvertBackgroundPositionUnits(ref BackgroundPosition from, ref BackgroundPosition to)
		{
			Length offset = from.offset;
			Length offset2 = to.offset;
			bool flag = !this.TryConvertLengthUnits(StylePropertyId.BackgroundPosition, ref offset, ref offset2, 0);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				from.offset = offset;
				result = true;
			}
			return result;
		}

		// Token: 0x060017B6 RID: 6070 RVA: 0x00059EA8 File Offset: 0x000580A8
		internal bool TryConvertBackgroundSizeUnits(ref BackgroundSize from, ref BackgroundSize to)
		{
			Length x = from.x;
			Length y = from.y;
			Length x2 = to.x;
			Length y2 = to.y;
			bool flag = !this.TryConvertLengthUnits(StylePropertyId.BackgroundSize, ref x, ref x2, 0);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = !this.TryConvertLengthUnits(StylePropertyId.BackgroundSize, ref y, ref y2, 1);
				if (flag2)
				{
					result = false;
				}
				else
				{
					from.x = x;
					from.y = y;
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060017B7 RID: 6071 RVA: 0x00059F28 File Offset: 0x00058128
		private float? GetParentSizeForLengthConversion(StylePropertyId id, int subPropertyIndex = 0)
		{
			if (id <= StylePropertyId.WordSpacing)
			{
				if (id - StylePropertyId.FontSize <= 1 || id == StylePropertyId.UnityParagraphSpacing || id == StylePropertyId.WordSpacing)
				{
					return null;
				}
			}
			else if (id <= StylePropertyId.Translate)
			{
				switch (id)
				{
				case StylePropertyId.Bottom:
				case StylePropertyId.Height:
				case StylePropertyId.MaxHeight:
				case StylePropertyId.MinHeight:
				case StylePropertyId.Top:
				{
					VisualElement parent = this.hierarchy.parent;
					return (parent != null) ? new float?(parent.resolvedStyle.height) : null;
				}
				case StylePropertyId.Display:
				case StylePropertyId.FlexDirection:
				case StylePropertyId.FlexGrow:
				case StylePropertyId.FlexShrink:
				case StylePropertyId.FlexWrap:
				case StylePropertyId.JustifyContent:
				case StylePropertyId.Position:
					break;
				case StylePropertyId.FlexBasis:
				{
					bool flag = this.hierarchy.parent == null;
					if (flag)
					{
						return null;
					}
					FlexDirection flexDirection = this.hierarchy.parent.resolvedStyle.flexDirection;
					FlexDirection flexDirection2 = flexDirection;
					if (flexDirection2 > FlexDirection.ColumnReverse)
					{
						return new float?(this.hierarchy.parent.resolvedStyle.width);
					}
					return new float?(this.hierarchy.parent.resolvedStyle.height);
				}
				case StylePropertyId.Left:
				case StylePropertyId.MarginBottom:
				case StylePropertyId.MarginLeft:
				case StylePropertyId.MarginRight:
				case StylePropertyId.MarginTop:
				case StylePropertyId.MaxWidth:
				case StylePropertyId.MinWidth:
				case StylePropertyId.PaddingBottom:
				case StylePropertyId.PaddingLeft:
				case StylePropertyId.PaddingRight:
				case StylePropertyId.PaddingTop:
				case StylePropertyId.Right:
				case StylePropertyId.Width:
				{
					VisualElement parent2 = this.hierarchy.parent;
					return (parent2 != null) ? new float?(parent2.resolvedStyle.width) : null;
				}
				default:
					if (id - StylePropertyId.TransformOrigin <= 1)
					{
						return new float?((subPropertyIndex == 0) ? this.resolvedStyle.width : this.resolvedStyle.height);
					}
					break;
				}
			}
			else if (id - StylePropertyId.BorderBottomLeftRadius <= 1 || id - StylePropertyId.BorderTopLeftRadius <= 1)
			{
				return new float?(this.resolvedStyle.width);
			}
			return null;
		}

		// Token: 0x170005EE RID: 1518
		// (get) Token: 0x060017B8 RID: 6072 RVA: 0x0005A16A File Offset: 0x0005836A
		// (set) Token: 0x060017B9 RID: 6073 RVA: 0x0005A180 File Offset: 0x00058380
		internal bool isCompositeRoot
		{
			get
			{
				return (this.m_Flags & VisualElementFlags.CompositeRoot) == VisualElementFlags.CompositeRoot;
			}
			set
			{
				this.m_Flags = (value ? (this.m_Flags | VisualElementFlags.CompositeRoot) : (this.m_Flags & ~VisualElementFlags.CompositeRoot));
				if (value)
				{
					this.SetAsNextParentWithEventCallback();
				}
			}
		}

		// Token: 0x170005EF RID: 1519
		// (get) Token: 0x060017BA RID: 6074 RVA: 0x0005A1BD File Offset: 0x000583BD
		// (set) Token: 0x060017BB RID: 6075 RVA: 0x0005A1D2 File Offset: 0x000583D2
		internal bool isHierarchyDisplayed
		{
			get
			{
				return (this.m_Flags & VisualElementFlags.HierarchyDisplayed) == VisualElementFlags.HierarchyDisplayed;
			}
			set
			{
				this.m_Flags = (value ? (this.m_Flags | VisualElementFlags.HierarchyDisplayed) : (this.m_Flags & ~VisualElementFlags.HierarchyDisplayed));
			}
		}

		// Token: 0x170005F0 RID: 1520
		// (get) Token: 0x060017BC RID: 6076 RVA: 0x0005A1F7 File Offset: 0x000583F7
		// (set) Token: 0x060017BD RID: 6077 RVA: 0x0005A200 File Offset: 0x00058400
		public string viewDataKey
		{
			get
			{
				return this.m_ViewDataKey;
			}
			set
			{
				bool flag = this.m_ViewDataKey != value;
				if (flag)
				{
					this.m_ViewDataKey = value;
					bool flag2 = !string.IsNullOrEmpty(value);
					if (flag2)
					{
						this.IncrementVersion(VersionChangeType.ViewData);
					}
				}
			}
		}

		// Token: 0x170005F1 RID: 1521
		// (get) Token: 0x060017BE RID: 6078 RVA: 0x0005A23C File Offset: 0x0005843C
		// (set) Token: 0x060017BF RID: 6079 RVA: 0x0005A251 File Offset: 0x00058451
		internal bool enableViewDataPersistence
		{
			get
			{
				return (this.m_Flags & VisualElementFlags.EnableViewDataPersistence) == VisualElementFlags.EnableViewDataPersistence;
			}
			private set
			{
				this.m_Flags = (value ? (this.m_Flags | VisualElementFlags.EnableViewDataPersistence) : (this.m_Flags & ~VisualElementFlags.EnableViewDataPersistence));
			}
		}

		// Token: 0x170005F2 RID: 1522
		// (get) Token: 0x060017C0 RID: 6080 RVA: 0x0005A278 File Offset: 0x00058478
		// (set) Token: 0x060017C1 RID: 6081 RVA: 0x0005A299 File Offset: 0x00058499
		public object userData
		{
			get
			{
				object result;
				this.TryGetPropertyInternal(VisualElement.userDataPropertyKey, out result);
				return result;
			}
			set
			{
				this.SetPropertyInternal(VisualElement.userDataPropertyKey, value);
			}
		}

		// Token: 0x170005F3 RID: 1523
		// (get) Token: 0x060017C2 RID: 6082 RVA: 0x0005A2AC File Offset: 0x000584AC
		public override bool canGrabFocus
		{
			get
			{
				bool flag = false;
				for (VisualElement parent = this.hierarchy.parent; parent != null; parent = parent.parent)
				{
					bool isCompositeRoot = parent.isCompositeRoot;
					if (isCompositeRoot)
					{
						flag |= !parent.canGrabFocus;
						break;
					}
				}
				return !flag && this.visible && this.resolvedStyle.display != DisplayStyle.None && this.enabledInHierarchy && base.canGrabFocus;
			}
		}

		// Token: 0x170005F4 RID: 1524
		// (get) Token: 0x060017C3 RID: 6083 RVA: 0x0005A32C File Offset: 0x0005852C
		public override FocusController focusController
		{
			get
			{
				IPanel panel = this.panel;
				return (panel != null) ? panel.focusController : null;
			}
		}

		// Token: 0x170005F5 RID: 1525
		// (get) Token: 0x060017C4 RID: 6084 RVA: 0x0005A350 File Offset: 0x00058550
		// (set) Token: 0x060017C5 RID: 6085 RVA: 0x0005A3A0 File Offset: 0x000585A0
		public UsageHints usageHints
		{
			get
			{
				return (((this.renderHints & RenderHints.GroupTransform) != RenderHints.None) ? UsageHints.GroupTransform : UsageHints.None) | (((this.renderHints & RenderHints.BoneTransform) != RenderHints.None) ? UsageHints.DynamicTransform : UsageHints.None) | (((this.renderHints & RenderHints.MaskContainer) != RenderHints.None) ? UsageHints.MaskContainer : UsageHints.None) | (((this.renderHints & RenderHints.DynamicColor) != RenderHints.None) ? UsageHints.DynamicColor : UsageHints.None);
			}
			set
			{
				bool flag = (value & UsageHints.GroupTransform) > UsageHints.None;
				if (flag)
				{
					this.renderHints |= RenderHints.GroupTransform;
				}
				else
				{
					this.renderHints &= ~RenderHints.GroupTransform;
				}
				bool flag2 = (value & UsageHints.DynamicTransform) > UsageHints.None;
				if (flag2)
				{
					this.renderHints |= RenderHints.BoneTransform;
				}
				else
				{
					this.renderHints &= ~RenderHints.BoneTransform;
				}
				bool flag3 = (value & UsageHints.MaskContainer) > UsageHints.None;
				if (flag3)
				{
					this.renderHints |= RenderHints.MaskContainer;
				}
				else
				{
					this.renderHints &= ~RenderHints.MaskContainer;
				}
				bool flag4 = (value & UsageHints.DynamicColor) > UsageHints.None;
				if (flag4)
				{
					this.renderHints |= RenderHints.DynamicColor;
				}
				else
				{
					this.renderHints &= ~RenderHints.DynamicColor;
				}
			}
		}

		// Token: 0x170005F6 RID: 1526
		// (get) Token: 0x060017C6 RID: 6086 RVA: 0x0005A45C File Offset: 0x0005865C
		// (set) Token: 0x060017C7 RID: 6087 RVA: 0x0005A474 File Offset: 0x00058674
		internal RenderHints renderHints
		{
			get
			{
				return this.m_RenderHints;
			}
			set
			{
				RenderHints renderHints = this.m_RenderHints & ~(RenderHints.DirtyGroupTransform | RenderHints.DirtyBoneTransform | RenderHints.DirtyClipWithScissors | RenderHints.DirtyMaskContainer | RenderHints.DirtyDynamicColor);
				RenderHints renderHints2 = value & ~(RenderHints.DirtyGroupTransform | RenderHints.DirtyBoneTransform | RenderHints.DirtyClipWithScissors | RenderHints.DirtyMaskContainer | RenderHints.DirtyDynamicColor);
				RenderHints renderHints3 = renderHints ^ renderHints2;
				bool flag = renderHints3 > RenderHints.None;
				if (flag)
				{
					RenderHints renderHints4 = this.m_RenderHints & RenderHints.DirtyAll;
					RenderHints renderHints5 = renderHints3 << 5;
					this.m_RenderHints = (renderHints2 | renderHints4 | renderHints5);
					this.IncrementVersion(VersionChangeType.RenderHints);
				}
			}
		}

		// Token: 0x060017C8 RID: 6088 RVA: 0x0005A4D1 File Offset: 0x000586D1
		internal void MarkRenderHintsClean()
		{
			this.m_RenderHints &= ~(RenderHints.DirtyGroupTransform | RenderHints.DirtyBoneTransform | RenderHints.DirtyClipWithScissors | RenderHints.DirtyMaskContainer | RenderHints.DirtyDynamicColor);
		}

		// Token: 0x170005F7 RID: 1527
		// (get) Token: 0x060017C9 RID: 6089 RVA: 0x0005A4E8 File Offset: 0x000586E8
		public ITransform transform
		{
			get
			{
				return this;
			}
		}

		// Token: 0x170005F8 RID: 1528
		// (get) Token: 0x060017CA RID: 6090 RVA: 0x0005A4FC File Offset: 0x000586FC
		// (set) Token: 0x060017CB RID: 6091 RVA: 0x0005A519 File Offset: 0x00058719
		Vector3 ITransform.position
		{
			get
			{
				return this.resolvedStyle.translate;
			}
			set
			{
				this.style.translate = new Translate(value.x, value.y, value.z);
			}
		}

		// Token: 0x170005F9 RID: 1529
		// (get) Token: 0x060017CC RID: 6092 RVA: 0x0005A550 File Offset: 0x00058750
		// (set) Token: 0x060017CD RID: 6093 RVA: 0x0005A578 File Offset: 0x00058778
		Quaternion ITransform.rotation
		{
			get
			{
				return this.resolvedStyle.rotate.ToQuaternion();
			}
			set
			{
				float value2;
				Vector3 axis;
				value.ToAngleAxis(out value2, out axis);
				this.style.rotate = new Rotate(value2, axis);
			}
		}

		// Token: 0x170005FA RID: 1530
		// (get) Token: 0x060017CE RID: 6094 RVA: 0x0005A5B0 File Offset: 0x000587B0
		// (set) Token: 0x060017CF RID: 6095 RVA: 0x0005A5D5 File Offset: 0x000587D5
		Vector3 ITransform.scale
		{
			get
			{
				return this.resolvedStyle.scale.value;
			}
			set
			{
				this.style.scale = new Scale(value);
			}
		}

		// Token: 0x170005FB RID: 1531
		// (get) Token: 0x060017D0 RID: 6096 RVA: 0x0005A5F4 File Offset: 0x000587F4
		Matrix4x4 ITransform.matrix
		{
			get
			{
				return Matrix4x4.TRS(this.resolvedStyle.translate, this.resolvedStyle.rotate.ToQuaternion(), this.resolvedStyle.scale.value);
			}
		}

		// Token: 0x170005FC RID: 1532
		// (get) Token: 0x060017D1 RID: 6097 RVA: 0x0005A63C File Offset: 0x0005883C
		// (set) Token: 0x060017D2 RID: 6098 RVA: 0x0005A64B File Offset: 0x0005884B
		internal bool isLayoutManual
		{
			get
			{
				return (this.m_Flags & VisualElementFlags.LayoutManual) == VisualElementFlags.LayoutManual;
			}
			private set
			{
				this.m_Flags = (value ? (this.m_Flags | VisualElementFlags.LayoutManual) : (this.m_Flags & ~VisualElementFlags.LayoutManual));
			}
		}

		// Token: 0x170005FD RID: 1533
		// (get) Token: 0x060017D3 RID: 6099 RVA: 0x0005A66A File Offset: 0x0005886A
		internal float scaledPixelsPerPoint
		{
			get
			{
				BaseVisualElementPanel elementPanel = this.elementPanel;
				return (elementPanel != null) ? elementPanel.scaledPixelsPerPoint : GUIUtility.pixelsPerPoint;
			}
		}

		// Token: 0x170005FE RID: 1534
		// (get) Token: 0x060017D4 RID: 6100 RVA: 0x0005A684 File Offset: 0x00058884
		StyleEnum<ScaleMode> IResolvedStyle.unityBackgroundScaleMode
		{
			get
			{
				bool flag;
				return BackgroundPropertyHelper.ResolveUnityBackgroundScaleMode(this.computedStyle.backgroundPositionX, this.computedStyle.backgroundPositionY, this.computedStyle.backgroundRepeat, this.computedStyle.backgroundSize, out flag);
			}
		}

		// Token: 0x170005FF RID: 1535
		// (get) Token: 0x060017D5 RID: 6101 RVA: 0x0005A6CC File Offset: 0x000588CC
		// (set) Token: 0x060017D6 RID: 6102 RVA: 0x0005A74C File Offset: 0x0005894C
		public Rect layout
		{
			get
			{
				Rect layout = this.m_Layout;
				bool flag = this.yogaNode != null && !this.isLayoutManual;
				if (flag)
				{
					layout.x = this.yogaNode.LayoutX;
					layout.y = this.yogaNode.LayoutY;
					layout.width = this.yogaNode.LayoutWidth;
					layout.height = this.yogaNode.LayoutHeight;
				}
				return layout;
			}
			internal set
			{
				bool flag = this.yogaNode == null;
				if (flag)
				{
					this.yogaNode = new YogaNode(null);
				}
				bool flag2 = this.isLayoutManual && this.m_Layout == value;
				if (!flag2)
				{
					Rect layout = this.layout;
					VersionChangeType versionChangeType = (VersionChangeType)0;
					bool flag3 = !Mathf.Approximately(layout.x, value.x) || !Mathf.Approximately(layout.y, value.y);
					if (flag3)
					{
						versionChangeType |= VersionChangeType.Transform;
					}
					bool flag4 = !Mathf.Approximately(layout.width, value.width) || !Mathf.Approximately(layout.height, value.height);
					if (flag4)
					{
						versionChangeType |= VersionChangeType.Size;
					}
					this.m_Layout = value;
					this.isLayoutManual = true;
					IStyle style = this.style;
					style.position = Position.Absolute;
					style.marginLeft = 0f;
					style.marginRight = 0f;
					style.marginBottom = 0f;
					style.marginTop = 0f;
					style.left = value.x;
					style.top = value.y;
					style.right = float.NaN;
					style.bottom = float.NaN;
					style.width = value.width;
					style.height = value.height;
					bool flag5 = versionChangeType > (VersionChangeType)0;
					if (flag5)
					{
						this.IncrementVersion(versionChangeType);
					}
				}
			}
		}

		// Token: 0x060017D7 RID: 6103 RVA: 0x0005A900 File Offset: 0x00058B00
		internal void ClearManualLayout()
		{
			this.isLayoutManual = false;
			IStyle style = this.style;
			style.position = StyleKeyword.Null;
			style.marginLeft = StyleKeyword.Null;
			style.marginRight = StyleKeyword.Null;
			style.marginBottom = StyleKeyword.Null;
			style.marginTop = StyleKeyword.Null;
			style.left = StyleKeyword.Null;
			style.top = StyleKeyword.Null;
			style.right = StyleKeyword.Null;
			style.bottom = StyleKeyword.Null;
			style.width = StyleKeyword.Null;
			style.height = StyleKeyword.Null;
		}

		// Token: 0x17000600 RID: 1536
		// (get) Token: 0x060017D8 RID: 6104 RVA: 0x0005A9AC File Offset: 0x00058BAC
		public Rect contentRect
		{
			get
			{
				Spacing a = new Spacing(this.resolvedStyle.paddingLeft, this.resolvedStyle.paddingTop, this.resolvedStyle.paddingRight, this.resolvedStyle.paddingBottom);
				return this.paddingRect - a;
			}
		}

		// Token: 0x17000601 RID: 1537
		// (get) Token: 0x060017D9 RID: 6105 RVA: 0x0005AA00 File Offset: 0x00058C00
		protected Rect paddingRect
		{
			get
			{
				Spacing a = new Spacing(this.resolvedStyle.borderLeftWidth, this.resolvedStyle.borderTopWidth, this.resolvedStyle.borderRightWidth, this.resolvedStyle.borderBottomWidth);
				return this.rect - a;
			}
		}

		// Token: 0x17000602 RID: 1538
		// (get) Token: 0x060017DA RID: 6106 RVA: 0x0005AA51 File Offset: 0x00058C51
		// (set) Token: 0x060017DB RID: 6107 RVA: 0x0005AA5E File Offset: 0x00058C5E
		internal bool isBoundingBoxDirty
		{
			get
			{
				return (this.m_Flags & VisualElementFlags.BoundingBoxDirty) == VisualElementFlags.BoundingBoxDirty;
			}
			set
			{
				this.m_Flags = (value ? (this.m_Flags | VisualElementFlags.BoundingBoxDirty) : (this.m_Flags & ~VisualElementFlags.BoundingBoxDirty));
			}
		}

		// Token: 0x17000603 RID: 1539
		// (get) Token: 0x060017DC RID: 6108 RVA: 0x0005AA7C File Offset: 0x00058C7C
		// (set) Token: 0x060017DD RID: 6109 RVA: 0x0005AA8B File Offset: 0x00058C8B
		internal bool isWorldBoundingBoxDirty
		{
			get
			{
				return (this.m_Flags & VisualElementFlags.WorldBoundingBoxDirty) == VisualElementFlags.WorldBoundingBoxDirty;
			}
			set
			{
				this.m_Flags = (value ? (this.m_Flags | VisualElementFlags.WorldBoundingBoxDirty) : (this.m_Flags & ~VisualElementFlags.WorldBoundingBoxDirty));
			}
		}

		// Token: 0x17000604 RID: 1540
		// (get) Token: 0x060017DE RID: 6110 RVA: 0x0005AAAA File Offset: 0x00058CAA
		internal bool isWorldBoundingBoxOrDependenciesDirty
		{
			get
			{
				return (this.m_Flags & (VisualElementFlags.WorldTransformDirty | VisualElementFlags.BoundingBoxDirty | VisualElementFlags.WorldBoundingBoxDirty)) > (VisualElementFlags)0;
			}
		}

		// Token: 0x17000605 RID: 1541
		// (get) Token: 0x060017DF RID: 6111 RVA: 0x0005AAB8 File Offset: 0x00058CB8
		internal Rect boundingBox
		{
			get
			{
				bool isBoundingBoxDirty = this.isBoundingBoxDirty;
				if (isBoundingBoxDirty)
				{
					this.UpdateBoundingBox();
					this.isBoundingBoxDirty = false;
				}
				return this.m_BoundingBox;
			}
		}

		// Token: 0x17000606 RID: 1542
		// (get) Token: 0x060017E0 RID: 6112 RVA: 0x0005AAEC File Offset: 0x00058CEC
		internal Rect worldBoundingBox
		{
			get
			{
				bool isWorldBoundingBoxOrDependenciesDirty = this.isWorldBoundingBoxOrDependenciesDirty;
				if (isWorldBoundingBoxOrDependenciesDirty)
				{
					this.UpdateWorldBoundingBox();
					this.isWorldBoundingBoxDirty = false;
				}
				return this.m_WorldBoundingBox;
			}
		}

		// Token: 0x17000607 RID: 1543
		// (get) Token: 0x060017E1 RID: 6113 RVA: 0x0005AB20 File Offset: 0x00058D20
		private Rect boundingBoxInParentSpace
		{
			get
			{
				Rect boundingBox = this.boundingBox;
				this.TransformAlignedRectToParentSpace(ref boundingBox);
				return boundingBox;
			}
		}

		// Token: 0x060017E2 RID: 6114 RVA: 0x0005AB44 File Offset: 0x00058D44
		internal void UpdateBoundingBox()
		{
			bool flag = float.IsNaN(this.rect.x) || float.IsNaN(this.rect.y) || float.IsNaN(this.rect.width) || float.IsNaN(this.rect.height);
			if (flag)
			{
				this.m_BoundingBox = Rect.zero;
			}
			else
			{
				this.m_BoundingBox = this.rect;
				bool flag2 = !this.ShouldClip();
				if (flag2)
				{
					int count = this.m_Children.Count;
					for (int i = 0; i < count; i++)
					{
						Rect boundingBoxInParentSpace = this.m_Children[i].boundingBoxInParentSpace;
						this.m_BoundingBox.xMin = Math.Min(this.m_BoundingBox.xMin, boundingBoxInParentSpace.xMin);
						this.m_BoundingBox.xMax = Math.Max(this.m_BoundingBox.xMax, boundingBoxInParentSpace.xMax);
						this.m_BoundingBox.yMin = Math.Min(this.m_BoundingBox.yMin, boundingBoxInParentSpace.yMin);
						this.m_BoundingBox.yMax = Math.Max(this.m_BoundingBox.yMax, boundingBoxInParentSpace.yMax);
					}
				}
			}
			this.isWorldBoundingBoxDirty = true;
		}

		// Token: 0x060017E3 RID: 6115 RVA: 0x0005ACAF File Offset: 0x00058EAF
		internal void UpdateWorldBoundingBox()
		{
			this.m_WorldBoundingBox = this.boundingBox;
			VisualElement.TransformAlignedRect(this.worldTransformRef, ref this.m_WorldBoundingBox);
		}

		// Token: 0x17000608 RID: 1544
		// (get) Token: 0x060017E4 RID: 6116 RVA: 0x0005ACD0 File Offset: 0x00058ED0
		public Rect worldBound
		{
			get
			{
				Rect rect = this.rect;
				VisualElement.TransformAlignedRect(this.worldTransformRef, ref rect);
				return rect;
			}
		}

		// Token: 0x17000609 RID: 1545
		// (get) Token: 0x060017E5 RID: 6117 RVA: 0x0005ACF8 File Offset: 0x00058EF8
		public Rect localBound
		{
			get
			{
				Rect rect = this.rect;
				this.TransformAlignedRectToParentSpace(ref rect);
				return rect;
			}
		}

		// Token: 0x1700060A RID: 1546
		// (get) Token: 0x060017E6 RID: 6118 RVA: 0x0005AD1C File Offset: 0x00058F1C
		internal Rect rect
		{
			get
			{
				Rect layout = this.layout;
				return new Rect(0f, 0f, layout.width, layout.height);
			}
		}

		// Token: 0x1700060B RID: 1547
		// (get) Token: 0x060017E7 RID: 6119 RVA: 0x0005AD52 File Offset: 0x00058F52
		// (set) Token: 0x060017E8 RID: 6120 RVA: 0x0005AD5F File Offset: 0x00058F5F
		internal bool isWorldTransformDirty
		{
			get
			{
				return (this.m_Flags & VisualElementFlags.WorldTransformDirty) == VisualElementFlags.WorldTransformDirty;
			}
			set
			{
				this.m_Flags = (value ? (this.m_Flags | VisualElementFlags.WorldTransformDirty) : (this.m_Flags & ~VisualElementFlags.WorldTransformDirty));
			}
		}

		// Token: 0x1700060C RID: 1548
		// (get) Token: 0x060017E9 RID: 6121 RVA: 0x0005AD7D File Offset: 0x00058F7D
		// (set) Token: 0x060017EA RID: 6122 RVA: 0x0005AD8A File Offset: 0x00058F8A
		internal bool isWorldTransformInverseDirty
		{
			get
			{
				return (this.m_Flags & VisualElementFlags.WorldTransformInverseDirty) == VisualElementFlags.WorldTransformInverseDirty;
			}
			set
			{
				this.m_Flags = (value ? (this.m_Flags | VisualElementFlags.WorldTransformInverseDirty) : (this.m_Flags & ~VisualElementFlags.WorldTransformInverseDirty));
			}
		}

		// Token: 0x1700060D RID: 1549
		// (get) Token: 0x060017EB RID: 6123 RVA: 0x0005ADA8 File Offset: 0x00058FA8
		internal bool isWorldTransformInverseOrDependenciesDirty
		{
			get
			{
				return (this.m_Flags & (VisualElementFlags.WorldTransformDirty | VisualElementFlags.WorldTransformInverseDirty)) > (VisualElementFlags)0;
			}
		}

		// Token: 0x1700060E RID: 1550
		// (get) Token: 0x060017EC RID: 6124 RVA: 0x0005ADB8 File Offset: 0x00058FB8
		public Matrix4x4 worldTransform
		{
			get
			{
				bool isWorldTransformDirty = this.isWorldTransformDirty;
				if (isWorldTransformDirty)
				{
					this.UpdateWorldTransform();
				}
				return this.m_WorldTransformCache;
			}
		}

		// Token: 0x1700060F RID: 1551
		// (get) Token: 0x060017ED RID: 6125 RVA: 0x0005ADE4 File Offset: 0x00058FE4
		internal ref Matrix4x4 worldTransformRef
		{
			get
			{
				bool isWorldTransformDirty = this.isWorldTransformDirty;
				if (isWorldTransformDirty)
				{
					this.UpdateWorldTransform();
				}
				return ref this.m_WorldTransformCache;
			}
		}

		// Token: 0x17000610 RID: 1552
		// (get) Token: 0x060017EE RID: 6126 RVA: 0x0005AE10 File Offset: 0x00059010
		internal ref Matrix4x4 worldTransformInverse
		{
			get
			{
				bool isWorldTransformInverseOrDependenciesDirty = this.isWorldTransformInverseOrDependenciesDirty;
				if (isWorldTransformInverseOrDependenciesDirty)
				{
					this.UpdateWorldTransformInverse();
				}
				return ref this.m_WorldTransformInverseCache;
			}
		}

		// Token: 0x060017EF RID: 6127 RVA: 0x0005AE3C File Offset: 0x0005903C
		internal void UpdateWorldTransform()
		{
			bool flag = this.elementPanel != null && !this.elementPanel.duringLayoutPhase;
			if (flag)
			{
				this.isWorldTransformDirty = false;
			}
			bool flag2 = this.hierarchy.parent != null;
			if (flag2)
			{
				bool hasDefaultRotationAndScale = this.hasDefaultRotationAndScale;
				if (hasDefaultRotationAndScale)
				{
					VisualElement.TranslateMatrix34(this.hierarchy.parent.worldTransformRef, this.positionWithLayout, out this.m_WorldTransformCache);
				}
				else
				{
					Matrix4x4 matrix4x;
					this.GetPivotedMatrixWithLayout(out matrix4x);
					VisualElement.MultiplyMatrix34(this.hierarchy.parent.worldTransformRef, ref matrix4x, out this.m_WorldTransformCache);
				}
			}
			else
			{
				this.GetPivotedMatrixWithLayout(out this.m_WorldTransformCache);
			}
			this.isWorldTransformInverseDirty = true;
			this.isWorldBoundingBoxDirty = true;
		}

		// Token: 0x060017F0 RID: 6128 RVA: 0x0005AF08 File Offset: 0x00059108
		internal void UpdateWorldTransformInverse()
		{
			Matrix4x4.Inverse3DAffine(this.worldTransform, ref this.m_WorldTransformInverseCache);
			this.isWorldTransformInverseDirty = false;
		}

		// Token: 0x17000611 RID: 1553
		// (get) Token: 0x060017F1 RID: 6129 RVA: 0x0005AF25 File Offset: 0x00059125
		// (set) Token: 0x060017F2 RID: 6130 RVA: 0x0005AF32 File Offset: 0x00059132
		internal bool isWorldClipDirty
		{
			get
			{
				return (this.m_Flags & VisualElementFlags.WorldClipDirty) == VisualElementFlags.WorldClipDirty;
			}
			set
			{
				this.m_Flags = (value ? (this.m_Flags | VisualElementFlags.WorldClipDirty) : (this.m_Flags & ~VisualElementFlags.WorldClipDirty));
			}
		}

		// Token: 0x17000612 RID: 1554
		// (get) Token: 0x060017F3 RID: 6131 RVA: 0x0005AF50 File Offset: 0x00059150
		internal Rect worldClip
		{
			get
			{
				bool isWorldClipDirty = this.isWorldClipDirty;
				if (isWorldClipDirty)
				{
					this.UpdateWorldClip();
					this.isWorldClipDirty = false;
				}
				return this.m_WorldClip;
			}
		}

		// Token: 0x17000613 RID: 1555
		// (get) Token: 0x060017F4 RID: 6132 RVA: 0x0005AF84 File Offset: 0x00059184
		internal Rect worldClipMinusGroup
		{
			get
			{
				bool isWorldClipDirty = this.isWorldClipDirty;
				if (isWorldClipDirty)
				{
					this.UpdateWorldClip();
					this.isWorldClipDirty = false;
				}
				return this.m_WorldClipMinusGroup;
			}
		}

		// Token: 0x17000614 RID: 1556
		// (get) Token: 0x060017F5 RID: 6133 RVA: 0x0005AFB8 File Offset: 0x000591B8
		internal bool worldClipIsInfinite
		{
			get
			{
				bool isWorldClipDirty = this.isWorldClipDirty;
				if (isWorldClipDirty)
				{
					this.UpdateWorldClip();
					this.isWorldClipDirty = false;
				}
				return this.m_WorldClipIsInfinite;
			}
		}

		// Token: 0x060017F6 RID: 6134 RVA: 0x0005AFEC File Offset: 0x000591EC
		internal void EnsureWorldTransformAndClipUpToDate()
		{
			bool isWorldTransformDirty = this.isWorldTransformDirty;
			if (isWorldTransformDirty)
			{
				this.UpdateWorldTransform();
			}
			bool isWorldClipDirty = this.isWorldClipDirty;
			if (isWorldClipDirty)
			{
				this.UpdateWorldClip();
				this.isWorldClipDirty = false;
			}
		}

		// Token: 0x060017F7 RID: 6135 RVA: 0x0005B028 File Offset: 0x00059228
		private void UpdateWorldClip()
		{
			bool flag = this.hierarchy.parent != null;
			if (flag)
			{
				this.m_WorldClip = this.hierarchy.parent.worldClip;
				bool flag2 = this.hierarchy.parent.worldClipIsInfinite;
				bool flag3 = this.hierarchy.parent != this.renderChainData.groupTransformAncestor;
				if (flag3)
				{
					this.m_WorldClipMinusGroup = this.hierarchy.parent.worldClipMinusGroup;
				}
				else
				{
					flag2 = true;
					this.m_WorldClipMinusGroup = VisualElement.s_InfiniteRect;
				}
				bool flag4 = this.ShouldClip();
				if (flag4)
				{
					Rect rect = this.SubstractBorderPadding(this.worldBound);
					this.m_WorldClip = this.CombineClipRects(rect, this.m_WorldClip);
					this.m_WorldClipMinusGroup = (flag2 ? rect : this.CombineClipRects(rect, this.m_WorldClipMinusGroup));
					this.m_WorldClipIsInfinite = false;
				}
				else
				{
					this.m_WorldClipIsInfinite = flag2;
				}
			}
			else
			{
				this.m_WorldClipMinusGroup = (this.m_WorldClip = ((this.panel != null) ? this.panel.visualTree.rect : VisualElement.s_InfiniteRect));
				this.m_WorldClipIsInfinite = true;
			}
		}

		// Token: 0x060017F8 RID: 6136 RVA: 0x0005B164 File Offset: 0x00059364
		private Rect CombineClipRects(Rect rect, Rect parentRect)
		{
			float num = Mathf.Max(rect.xMin, parentRect.xMin);
			float num2 = Mathf.Min(rect.xMax, parentRect.xMax);
			float num3 = Mathf.Max(rect.yMin, parentRect.yMin);
			float num4 = Mathf.Min(rect.yMax, parentRect.yMax);
			float width = Mathf.Max(num2 - num, 0f);
			float height = Mathf.Max(num4 - num3, 0f);
			return new Rect(num, num3, width, height);
		}

		// Token: 0x060017F9 RID: 6137 RVA: 0x0005B1F4 File Offset: 0x000593F4
		private Rect SubstractBorderPadding(Rect worldRect)
		{
			float m = this.worldTransform.m00;
			float m2 = this.worldTransform.m11;
			worldRect.x += this.resolvedStyle.borderLeftWidth * m;
			worldRect.y += this.resolvedStyle.borderTopWidth * m2;
			worldRect.width -= (this.resolvedStyle.borderLeftWidth + this.resolvedStyle.borderRightWidth) * m;
			worldRect.height -= (this.resolvedStyle.borderTopWidth + this.resolvedStyle.borderBottomWidth) * m2;
			bool flag = this.computedStyle.unityOverflowClipBox == OverflowClipBox.ContentBox;
			if (flag)
			{
				worldRect.x += this.resolvedStyle.paddingLeft * m;
				worldRect.y += this.resolvedStyle.paddingTop * m2;
				worldRect.width -= (this.resolvedStyle.paddingLeft + this.resolvedStyle.paddingRight) * m;
				worldRect.height -= (this.resolvedStyle.paddingTop + this.resolvedStyle.paddingBottom) * m2;
			}
			return worldRect;
		}

		// Token: 0x060017FA RID: 6138 RVA: 0x0005B348 File Offset: 0x00059548
		internal static Rect ComputeAAAlignedBound(Rect position, Matrix4x4 mat)
		{
			Rect rect = position;
			Vector3 vector = mat.MultiplyPoint3x4(new Vector3(rect.x, rect.y, 0f));
			Vector3 vector2 = mat.MultiplyPoint3x4(new Vector3(rect.x + rect.width, rect.y, 0f));
			Vector3 vector3 = mat.MultiplyPoint3x4(new Vector3(rect.x, rect.y + rect.height, 0f));
			Vector3 vector4 = mat.MultiplyPoint3x4(new Vector3(rect.x + rect.width, rect.y + rect.height, 0f));
			return Rect.MinMaxRect(Mathf.Min(vector.x, Mathf.Min(vector2.x, Mathf.Min(vector3.x, vector4.x))), Mathf.Min(vector.y, Mathf.Min(vector2.y, Mathf.Min(vector3.y, vector4.y))), Mathf.Max(vector.x, Mathf.Max(vector2.x, Mathf.Max(vector3.x, vector4.x))), Mathf.Max(vector.y, Mathf.Max(vector2.y, Mathf.Max(vector3.y, vector4.y))));
		}

		// Token: 0x17000615 RID: 1557
		// (get) Token: 0x060017FB RID: 6139 RVA: 0x0005B4A4 File Offset: 0x000596A4
		// (set) Token: 0x060017FC RID: 6140 RVA: 0x0005B4BC File Offset: 0x000596BC
		internal PseudoStates pseudoStates
		{
			get
			{
				return this.m_PseudoStates;
			}
			set
			{
				PseudoStates pseudoStates = this.m_PseudoStates ^ value;
				bool flag = pseudoStates > (PseudoStates)0;
				if (flag)
				{
					bool flag2 = (value & PseudoStates.Root) == PseudoStates.Root;
					if (flag2)
					{
						this.isRootVisualContainer = true;
					}
					bool flag3 = pseudoStates != PseudoStates.Root;
					if (flag3)
					{
						PseudoStates pseudoStates2 = pseudoStates & value;
						PseudoStates pseudoStates3 = pseudoStates & this.m_PseudoStates;
						bool flag4 = (this.triggerPseudoMask & pseudoStates2) != (PseudoStates)0 || (this.dependencyPseudoMask & pseudoStates3) > (PseudoStates)0;
						if (flag4)
						{
							this.IncrementVersion(VersionChangeType.StyleSheet);
						}
					}
					this.m_PseudoStates = value;
				}
			}
		}

		// Token: 0x17000616 RID: 1558
		// (get) Token: 0x060017FD RID: 6141 RVA: 0x0005B549 File Offset: 0x00059749
		// (set) Token: 0x060017FE RID: 6142 RVA: 0x0005B551 File Offset: 0x00059751
		internal int containedPointerIds { get; private set; }

		// Token: 0x060017FF RID: 6143 RVA: 0x0005B55C File Offset: 0x0005975C
		private void UpdateHoverPseudoState()
		{
			bool flag = this.containedPointerIds == 0 || this.panel == null;
			if (flag)
			{
				this.pseudoStates &= ~PseudoStates.Hover;
			}
			else
			{
				bool flag2 = false;
				for (int i = 0; i < PointerId.maxPointers; i++)
				{
					bool flag3 = (this.containedPointerIds & 1 << i) != 0;
					if (flag3)
					{
						IEventHandler capturingElement = this.panel.GetCapturingElement(i);
						bool flag4 = VisualElement.IsPartOfCapturedChain(this, capturingElement);
						if (flag4)
						{
							flag2 = true;
							break;
						}
					}
				}
				bool flag5 = flag2;
				if (flag5)
				{
					this.pseudoStates |= PseudoStates.Hover;
				}
				else
				{
					this.pseudoStates &= ~PseudoStates.Hover;
				}
			}
		}

		// Token: 0x06001800 RID: 6144 RVA: 0x0005B610 File Offset: 0x00059810
		private static bool IsPartOfCapturedChain(VisualElement self, in IEventHandler capturingElement)
		{
			bool flag = self == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = capturingElement == null;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = capturingElement == self;
					result = (flag3 || self.Contains(capturingElement as VisualElement));
				}
			}
			return result;
		}

		// Token: 0x17000617 RID: 1559
		// (get) Token: 0x06001801 RID: 6145 RVA: 0x0005B655 File Offset: 0x00059855
		// (set) Token: 0x06001802 RID: 6146 RVA: 0x0005B660 File Offset: 0x00059860
		public PickingMode pickingMode
		{
			get
			{
				return this.m_PickingMode;
			}
			set
			{
				bool flag = this.m_PickingMode == value;
				if (!flag)
				{
					this.m_PickingMode = value;
					this.IncrementVersion(VersionChangeType.Picking);
				}
			}
		}

		// Token: 0x17000618 RID: 1560
		// (get) Token: 0x06001803 RID: 6147 RVA: 0x0005B690 File Offset: 0x00059890
		// (set) Token: 0x06001804 RID: 6148 RVA: 0x0005B6A8 File Offset: 0x000598A8
		public string name
		{
			get
			{
				return this.m_Name;
			}
			set
			{
				bool flag = this.m_Name == value;
				if (!flag)
				{
					this.m_Name = value;
					this.IncrementVersion(VersionChangeType.StyleSheet);
				}
			}
		}

		// Token: 0x17000619 RID: 1561
		// (get) Token: 0x06001805 RID: 6149 RVA: 0x0005B6D8 File Offset: 0x000598D8
		internal List<string> classList
		{
			get
			{
				bool flag = this.m_ClassList == VisualElement.s_EmptyClassList;
				if (flag)
				{
					this.m_ClassList = ObjectListPool<string>.Get();
				}
				return this.m_ClassList;
			}
		}

		// Token: 0x1700061A RID: 1562
		// (get) Token: 0x06001806 RID: 6150 RVA: 0x0005B70E File Offset: 0x0005990E
		internal string fullTypeName
		{
			get
			{
				return this.typeData.fullTypeName;
			}
		}

		// Token: 0x1700061B RID: 1563
		// (get) Token: 0x06001807 RID: 6151 RVA: 0x0005B71B File Offset: 0x0005991B
		internal string typeName
		{
			get
			{
				return this.typeData.typeName;
			}
		}

		// Token: 0x1700061C RID: 1564
		// (get) Token: 0x06001808 RID: 6152 RVA: 0x0005B728 File Offset: 0x00059928
		// (set) Token: 0x06001809 RID: 6153 RVA: 0x0005B730 File Offset: 0x00059930
		internal YogaNode yogaNode { get; private set; }

		// Token: 0x1700061D RID: 1565
		// (get) Token: 0x0600180A RID: 6154 RVA: 0x0005B739 File Offset: 0x00059939
		internal ref ComputedStyle computedStyle
		{
			get
			{
				return ref this.m_Style;
			}
		}

		// Token: 0x1700061E RID: 1566
		// (get) Token: 0x0600180B RID: 6155 RVA: 0x0005B741 File Offset: 0x00059941
		internal bool hasInlineStyle
		{
			get
			{
				return this.inlineStyleAccess != null;
			}
		}

		// Token: 0x1700061F RID: 1567
		// (get) Token: 0x0600180C RID: 6156 RVA: 0x0005B74C File Offset: 0x0005994C
		// (set) Token: 0x0600180D RID: 6157 RVA: 0x0005B761 File Offset: 0x00059961
		internal bool styleInitialized
		{
			get
			{
				return (this.m_Flags & VisualElementFlags.StyleInitialized) == VisualElementFlags.StyleInitialized;
			}
			set
			{
				this.m_Flags = (value ? (this.m_Flags | VisualElementFlags.StyleInitialized) : (this.m_Flags & ~VisualElementFlags.StyleInitialized));
			}
		}

		// Token: 0x17000620 RID: 1568
		// (get) Token: 0x0600180E RID: 6158 RVA: 0x0005B788 File Offset: 0x00059988
		// (set) Token: 0x0600180F RID: 6159 RVA: 0x0005B7A5 File Offset: 0x000599A5
		internal float opacity
		{
			get
			{
				return this.resolvedStyle.opacity;
			}
			set
			{
				this.style.opacity = value;
			}
		}

		// Token: 0x06001810 RID: 6160 RVA: 0x0005B7BC File Offset: 0x000599BC
		private void ChangeIMGUIContainerCount(int delta)
		{
			for (VisualElement visualElement = this; visualElement != null; visualElement = visualElement.hierarchy.parent)
			{
				visualElement.imguiContainerDescendantCount += delta;
			}
		}

		// Token: 0x06001811 RID: 6161 RVA: 0x0005B7F8 File Offset: 0x000599F8
		public VisualElement()
		{
			UIElementsRuntimeUtilityNative.VisualElementCreation();
			this.m_Children = VisualElement.s_EmptyList;
			this.controlid = (VisualElement.s_NextId += 1U);
			this.hierarchy = new VisualElement.Hierarchy(this);
			this.m_ClassList = VisualElement.s_EmptyClassList;
			this.m_Flags = VisualElementFlags.Init;
			this.SetEnabled(true);
			base.focusable = false;
			this.name = string.Empty;
			this.yogaNode = new YogaNode(null);
			this.renderHints = RenderHints.None;
			EventInterestReflectionUtils.GetDefaultEventInterests(base.GetType(), out this.m_DefaultActionEventCategories, out this.m_DefaultActionAtTargetEventCategories);
		}

		// Token: 0x06001812 RID: 6162 RVA: 0x0005B910 File Offset: 0x00059B10
		[EventInterest(new Type[]
		{
			typeof(MouseOverEvent),
			typeof(MouseOutEvent),
			typeof(MouseCaptureOutEvent),
			typeof(PointerEnterEvent),
			typeof(PointerLeaveEvent),
			typeof(PointerCaptureEvent),
			typeof(PointerCaptureOutEvent),
			typeof(BlurEvent),
			typeof(FocusEvent),
			typeof(TooltipEvent)
		})]
		protected override void ExecuteDefaultAction(EventBase evt)
		{
			base.ExecuteDefaultAction(evt);
			bool flag = evt == null;
			if (!flag)
			{
				bool flag2 = evt.eventTypeId == EventBase<MouseOverEvent>.TypeId() || evt.eventTypeId == EventBase<MouseOutEvent>.TypeId() || evt.eventTypeId == EventBase<MouseCaptureOutEvent>.TypeId();
				if (flag2)
				{
					this.UpdateCursorStyle(evt.eventTypeId);
				}
				else
				{
					bool flag3 = evt.eventTypeId == EventBase<PointerEnterEvent>.TypeId();
					if (flag3)
					{
						this.containedPointerIds |= 1 << ((IPointerEvent)evt).pointerId;
						this.UpdateHoverPseudoState();
					}
					else
					{
						bool flag4 = evt.eventTypeId == EventBase<PointerLeaveEvent>.TypeId();
						if (flag4)
						{
							this.containedPointerIds &= ~(1 << ((IPointerEvent)evt).pointerId);
							this.UpdateHoverPseudoState();
						}
						else
						{
							bool flag5 = evt.eventTypeId == EventBase<PointerCaptureEvent>.TypeId() || evt.eventTypeId == EventBase<PointerCaptureOutEvent>.TypeId();
							if (flag5)
							{
								for (VisualElement visualElement = this; visualElement != null; visualElement = visualElement.parent)
								{
									visualElement.UpdateHoverPseudoState();
								}
								BaseVisualElementPanel elementPanel = this.elementPanel;
								VisualElement visualElement2 = (elementPanel != null) ? elementPanel.GetTopElementUnderPointer(((IPointerCaptureEventInternal)evt).pointerId) : null;
								VisualElement visualElement3 = visualElement2;
								while (visualElement3 != null && visualElement3 != this)
								{
									visualElement3.UpdateHoverPseudoState();
									visualElement3 = visualElement3.parent;
								}
							}
							else
							{
								bool flag6 = evt.eventTypeId == EventBase<BlurEvent>.TypeId();
								if (flag6)
								{
									this.pseudoStates &= ~PseudoStates.Focus;
								}
								else
								{
									bool flag7 = evt.eventTypeId == EventBase<FocusEvent>.TypeId();
									if (flag7)
									{
										this.pseudoStates |= PseudoStates.Focus;
									}
									else
									{
										bool flag8 = evt.eventTypeId == EventBase<TooltipEvent>.TypeId();
										if (flag8)
										{
											this.SetTooltip((TooltipEvent)evt);
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06001813 RID: 6163 RVA: 0x0005BAF8 File Offset: 0x00059CF8
		internal virtual Rect GetTooltipRect()
		{
			return this.worldBound;
		}

		// Token: 0x06001814 RID: 6164 RVA: 0x0005BB10 File Offset: 0x00059D10
		private void SetTooltip(TooltipEvent e)
		{
			VisualElement visualElement = e.currentTarget as VisualElement;
			bool flag = visualElement != null && !string.IsNullOrEmpty(visualElement.tooltip);
			if (flag)
			{
				e.rect = visualElement.GetTooltipRect();
				e.tooltip = visualElement.tooltip;
				e.StopImmediatePropagation();
			}
		}

		// Token: 0x06001815 RID: 6165 RVA: 0x0005BB68 File Offset: 0x00059D68
		public sealed override void Focus()
		{
			bool flag = !this.canGrabFocus && this.hierarchy.parent != null;
			if (flag)
			{
				this.hierarchy.parent.Focus();
			}
			else
			{
				base.Focus();
			}
		}

		// Token: 0x06001816 RID: 6166 RVA: 0x0005BBB8 File Offset: 0x00059DB8
		internal void SetPanel(BaseVisualElementPanel p)
		{
			bool flag = this.panel == p;
			if (!flag)
			{
				List<VisualElement> list = VisualElementListPool.Get(0);
				try
				{
					list.Add(this);
					this.GatherAllChildren(list);
					EventDispatcherGate? eventDispatcherGate = null;
					bool flag2 = ((p != null) ? p.dispatcher : null) != null;
					if (flag2)
					{
						eventDispatcherGate = new EventDispatcherGate?(new EventDispatcherGate(p.dispatcher));
					}
					EventDispatcherGate? eventDispatcherGate2 = null;
					IPanel panel = this.panel;
					bool flag3 = ((panel != null) ? panel.dispatcher : null) != null && this.panel.dispatcher != ((p != null) ? p.dispatcher : null);
					if (flag3)
					{
						eventDispatcherGate2 = new EventDispatcherGate?(new EventDispatcherGate(this.panel.dispatcher));
					}
					BaseVisualElementPanel elementPanel = this.elementPanel;
					uint num = (elementPanel != null) ? elementPanel.hierarchyVersion : 0U;
					EventDispatcherGate? eventDispatcherGate3 = eventDispatcherGate;
					try
					{
						EventDispatcherGate? eventDispatcherGate4 = eventDispatcherGate2;
						try
						{
							IPanel panel2 = this.panel;
							if (panel2 != null)
							{
								EventDispatcher dispatcher = panel2.dispatcher;
								if (dispatcher != null)
								{
									dispatcher.m_ClickDetector.Cleanup(list);
								}
							}
							foreach (VisualElement visualElement in list)
							{
								visualElement.WillChangePanel(p);
							}
							uint num2 = (elementPanel != null) ? elementPanel.hierarchyVersion : 0U;
							bool flag4 = num != num2;
							if (flag4)
							{
								list.Clear();
								list.Add(this);
								this.GatherAllChildren(list);
							}
							VisualElementFlags visualElementFlags = (p != null) ? VisualElementFlags.NeedsAttachToPanelEvent : ((VisualElementFlags)0);
							foreach (VisualElement visualElement2 in list)
							{
								visualElement2.elementPanel = p;
								visualElement2.m_Flags |= visualElementFlags;
								visualElement2.m_CachedNextParentWithEventCallback = null;
							}
							foreach (VisualElement visualElement3 in list)
							{
								visualElement3.HasChangedPanel(elementPanel);
							}
						}
						finally
						{
							if (eventDispatcherGate4 != null)
							{
								((IDisposable)eventDispatcherGate4.GetValueOrDefault()).Dispose();
							}
						}
					}
					finally
					{
						if (eventDispatcherGate3 != null)
						{
							((IDisposable)eventDispatcherGate3.GetValueOrDefault()).Dispose();
						}
					}
				}
				finally
				{
					VisualElementListPool.Release(list);
				}
			}
		}

		// Token: 0x06001817 RID: 6167 RVA: 0x0005BEB0 File Offset: 0x0005A0B0
		private void WillChangePanel(BaseVisualElementPanel destinationPanel)
		{
			bool flag = this.panel != null;
			if (flag)
			{
				this.UnregisterRunningAnimations();
				bool flag2 = (this.m_Flags & VisualElementFlags.NeedsAttachToPanelEvent) == (VisualElementFlags)0;
				if (flag2)
				{
					bool flag3 = this.HasEventCallbacksOrDefaultActions(EventBase<DetachFromPanelEvent>.EventCategory);
					if (flag3)
					{
						using (DetachFromPanelEvent pooled = PanelChangedEventBase<DetachFromPanelEvent>.GetPooled(this.panel, destinationPanel))
						{
							pooled.target = this;
							base.HandleEventAtTargetAndDefaultPhase(pooled);
						}
					}
				}
				this.UnregisterRunningAnimations();
			}
		}

		// Token: 0x06001818 RID: 6168 RVA: 0x0005BF40 File Offset: 0x0005A140
		private void HasChangedPanel(BaseVisualElementPanel prevPanel)
		{
			bool flag = this.panel != null;
			if (flag)
			{
				this.yogaNode.Config = this.elementPanel.yogaConfig;
				this.RegisterRunningAnimations();
				this.pseudoStates &= ~(PseudoStates.Active | PseudoStates.Hover | PseudoStates.Focus);
				bool flag2 = (this.m_Flags & VisualElementFlags.NeedsAttachToPanelEvent) == VisualElementFlags.NeedsAttachToPanelEvent;
				if (flag2)
				{
					bool flag3 = this.HasEventCallbacksOrDefaultActions(EventBase<AttachToPanelEvent>.EventCategory);
					if (flag3)
					{
						using (AttachToPanelEvent pooled = PanelChangedEventBase<AttachToPanelEvent>.GetPooled(prevPanel, this.panel))
						{
							pooled.target = this;
							base.HandleEventAtTargetAndDefaultPhase(pooled);
						}
					}
					this.m_Flags &= ~VisualElementFlags.NeedsAttachToPanelEvent;
				}
			}
			else
			{
				this.yogaNode.Config = YogaConfig.Default;
			}
			this.styleInitialized = false;
			this.IncrementVersion(VersionChangeType.Layout | VersionChangeType.StyleSheet | VersionChangeType.Transform);
			bool flag4 = !string.IsNullOrEmpty(this.viewDataKey);
			if (flag4)
			{
				this.IncrementVersion(VersionChangeType.ViewData);
			}
		}

		// Token: 0x06001819 RID: 6169 RVA: 0x0005C04C File Offset: 0x0005A24C
		public sealed override void SendEvent(EventBase e)
		{
			BaseVisualElementPanel elementPanel = this.elementPanel;
			if (elementPanel != null)
			{
				elementPanel.SendEvent(e, DispatchMode.Default);
			}
		}

		// Token: 0x0600181A RID: 6170 RVA: 0x0005C063 File Offset: 0x0005A263
		internal sealed override void SendEvent(EventBase e, DispatchMode dispatchMode)
		{
			BaseVisualElementPanel elementPanel = this.elementPanel;
			if (elementPanel != null)
			{
				elementPanel.SendEvent(e, dispatchMode);
			}
		}

		// Token: 0x0600181B RID: 6171 RVA: 0x0005C07A File Offset: 0x0005A27A
		internal void IncrementVersion(VersionChangeType changeType)
		{
			BaseVisualElementPanel elementPanel = this.elementPanel;
			if (elementPanel != null)
			{
				elementPanel.OnVersionChanged(this, changeType);
			}
		}

		// Token: 0x0600181C RID: 6172 RVA: 0x0005C091 File Offset: 0x0005A291
		internal void InvokeHierarchyChanged(HierarchyChangeType changeType)
		{
			BaseVisualElementPanel elementPanel = this.elementPanel;
			if (elementPanel != null)
			{
				elementPanel.InvokeHierarchyChanged(this, changeType);
			}
		}

		// Token: 0x0600181D RID: 6173 RVA: 0x0005C0A8 File Offset: 0x0005A2A8
		[Obsolete("SetEnabledFromHierarchy is deprecated and will be removed in a future release. Please use SetEnabled instead.")]
		protected internal bool SetEnabledFromHierarchy(bool state)
		{
			return this.SetEnabledFromHierarchyPrivate(state);
		}

		// Token: 0x0600181E RID: 6174 RVA: 0x0005C0C4 File Offset: 0x0005A2C4
		private bool SetEnabledFromHierarchyPrivate(bool state)
		{
			bool enabledInHierarchy = this.enabledInHierarchy;
			bool flag = false;
			if (state)
			{
				bool isParentEnabledInHierarchy = this.isParentEnabledInHierarchy;
				if (isParentEnabledInHierarchy)
				{
					bool enabledSelf = this.enabledSelf;
					if (enabledSelf)
					{
						this.RemoveFromClassList(VisualElement.disabledUssClassName);
					}
					else
					{
						flag = true;
						this.AddToClassList(VisualElement.disabledUssClassName);
					}
				}
				else
				{
					flag = true;
					this.RemoveFromClassList(VisualElement.disabledUssClassName);
				}
			}
			else
			{
				flag = true;
				this.EnableInClassList(VisualElement.disabledUssClassName, this.isParentEnabledInHierarchy);
			}
			bool flag2 = flag;
			if (flag2)
			{
				bool flag3 = this.focusController != null && this.focusController.IsFocused(this);
				if (flag3)
				{
					EventDispatcherGate? eventDispatcherGate = null;
					IPanel panel = this.panel;
					bool flag4 = ((panel != null) ? panel.dispatcher : null) != null;
					if (flag4)
					{
						eventDispatcherGate = new EventDispatcherGate?(new EventDispatcherGate(this.panel.dispatcher));
					}
					EventDispatcherGate? eventDispatcherGate2 = eventDispatcherGate;
					try
					{
						base.BlurImmediately();
					}
					finally
					{
						if (eventDispatcherGate2 != null)
						{
							((IDisposable)eventDispatcherGate2.GetValueOrDefault()).Dispose();
						}
					}
				}
				this.pseudoStates |= PseudoStates.Disabled;
			}
			else
			{
				this.pseudoStates &= ~PseudoStates.Disabled;
			}
			return enabledInHierarchy != this.enabledInHierarchy;
		}

		// Token: 0x17000621 RID: 1569
		// (get) Token: 0x0600181F RID: 6175 RVA: 0x0005C224 File Offset: 0x0005A424
		private bool isParentEnabledInHierarchy
		{
			get
			{
				return this.hierarchy.parent == null || this.hierarchy.parent.enabledInHierarchy;
			}
		}

		// Token: 0x17000622 RID: 1570
		// (get) Token: 0x06001820 RID: 6176 RVA: 0x0005C25C File Offset: 0x0005A45C
		public bool enabledInHierarchy
		{
			get
			{
				return (this.pseudoStates & PseudoStates.Disabled) != PseudoStates.Disabled;
			}
		}

		// Token: 0x17000623 RID: 1571
		// (get) Token: 0x06001821 RID: 6177 RVA: 0x0005C27E File Offset: 0x0005A47E
		// (set) Token: 0x06001822 RID: 6178 RVA: 0x0005C286 File Offset: 0x0005A486
		public bool enabledSelf { get; private set; }

		// Token: 0x06001823 RID: 6179 RVA: 0x0005C290 File Offset: 0x0005A490
		public void SetEnabled(bool value)
		{
			bool flag = this.enabledSelf == value;
			if (!flag)
			{
				this.enabledSelf = value;
				this.PropagateEnabledToChildren(value);
			}
		}

		// Token: 0x06001824 RID: 6180 RVA: 0x0005C2C0 File Offset: 0x0005A4C0
		private void PropagateEnabledToChildren(bool value)
		{
			bool flag = this.SetEnabledFromHierarchyPrivate(value);
			if (flag)
			{
				int count = this.m_Children.Count;
				for (int i = 0; i < count; i++)
				{
					this.m_Children[i].PropagateEnabledToChildren(value);
				}
			}
		}

		// Token: 0x17000624 RID: 1572
		// (get) Token: 0x06001825 RID: 6181 RVA: 0x0005C30C File Offset: 0x0005A50C
		// (set) Token: 0x06001826 RID: 6182 RVA: 0x0005C314 File Offset: 0x0005A514
		public LanguageDirection languageDirection
		{
			get
			{
				return this.m_LanguageDirection;
			}
			set
			{
				bool flag = this.m_LanguageDirection == value;
				if (!flag)
				{
					this.m_LanguageDirection = value;
					this.localLanguageDirection = this.m_LanguageDirection;
				}
			}
		}

		// Token: 0x17000625 RID: 1573
		// (get) Token: 0x06001827 RID: 6183 RVA: 0x0005C345 File Offset: 0x0005A545
		// (set) Token: 0x06001828 RID: 6184 RVA: 0x0005C350 File Offset: 0x0005A550
		internal LanguageDirection localLanguageDirection
		{
			get
			{
				return this.m_LocalLanguageDirection;
			}
			set
			{
				bool flag = this.m_LocalLanguageDirection == value;
				if (!flag)
				{
					this.m_LocalLanguageDirection = value;
					this.IncrementVersion(VersionChangeType.Layout);
					int count = this.m_Children.Count;
					for (int i = 0; i < count; i++)
					{
						bool flag2 = this.m_Children[i].languageDirection == LanguageDirection.Inherit;
						if (flag2)
						{
							this.m_Children[i].localLanguageDirection = this.m_LocalLanguageDirection;
						}
					}
				}
			}
		}

		// Token: 0x17000626 RID: 1574
		// (get) Token: 0x06001829 RID: 6185 RVA: 0x0005C3CC File Offset: 0x0005A5CC
		// (set) Token: 0x0600182A RID: 6186 RVA: 0x0005C3EC File Offset: 0x0005A5EC
		public bool visible
		{
			get
			{
				return this.resolvedStyle.visibility == Visibility.Visible;
			}
			set
			{
				this.style.visibility = (value ? Visibility.Visible : Visibility.Hidden);
			}
		}

		// Token: 0x0600182B RID: 6187 RVA: 0x0005C407 File Offset: 0x0005A607
		public void MarkDirtyRepaint()
		{
			this.IncrementVersion(VersionChangeType.Repaint);
		}

		// Token: 0x17000627 RID: 1575
		// (get) Token: 0x0600182C RID: 6188 RVA: 0x0005C416 File Offset: 0x0005A616
		// (set) Token: 0x0600182D RID: 6189 RVA: 0x0005C41E File Offset: 0x0005A61E
		public Action<MeshGenerationContext> generateVisualContent { get; set; }

		// Token: 0x0600182E RID: 6190 RVA: 0x0005C428 File Offset: 0x0005A628
		internal void InvokeGenerateVisualContent(MeshGenerationContext mgc)
		{
			bool flag = this.generateVisualContent != null;
			if (flag)
			{
				try
				{
					using (VisualElement.k_GenerateVisualContentMarker.Auto())
					{
						this.generateVisualContent(mgc);
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		// Token: 0x0600182F RID: 6191 RVA: 0x0005C4A0 File Offset: 0x0005A6A0
		internal void GetFullHierarchicalViewDataKey(StringBuilder key)
		{
			bool flag = this.parent != null;
			if (flag)
			{
				this.parent.GetFullHierarchicalViewDataKey(key);
			}
			bool flag2 = !string.IsNullOrEmpty(this.viewDataKey);
			if (flag2)
			{
				key.Append("__");
				key.Append(this.viewDataKey);
			}
		}

		// Token: 0x06001830 RID: 6192 RVA: 0x0005C4F8 File Offset: 0x0005A6F8
		internal string GetFullHierarchicalViewDataKey()
		{
			StringBuilder stringBuilder = new StringBuilder();
			this.GetFullHierarchicalViewDataKey(stringBuilder);
			return stringBuilder.ToString();
		}

		// Token: 0x06001831 RID: 6193 RVA: 0x0005C520 File Offset: 0x0005A720
		internal T GetOrCreateViewData<T>(object existing, string key) where T : class, new()
		{
			Debug.Assert(this.elementPanel != null, "VisualElement.elementPanel is null! Cannot load persistent data.");
			ISerializableJsonDictionary serializableJsonDictionary = (this.elementPanel == null || this.elementPanel.getViewDataDictionary == null) ? null : this.elementPanel.getViewDataDictionary();
			bool flag = serializableJsonDictionary == null || string.IsNullOrEmpty(this.viewDataKey) || !this.enableViewDataPersistence;
			T result;
			if (flag)
			{
				bool flag2 = existing != null;
				if (flag2)
				{
					result = (existing as T);
				}
				else
				{
					result = Activator.CreateInstance<T>();
				}
			}
			else
			{
				string str = "__";
				Type typeFromHandle = typeof(T);
				string key2 = key + str + ((typeFromHandle != null) ? typeFromHandle.ToString() : null);
				bool flag3 = !serializableJsonDictionary.ContainsKey(key2);
				if (flag3)
				{
					serializableJsonDictionary.Set<T>(key2, Activator.CreateInstance<T>());
				}
				result = serializableJsonDictionary.Get<T>(key2);
			}
			return result;
		}

		// Token: 0x06001832 RID: 6194 RVA: 0x0005C5F8 File Offset: 0x0005A7F8
		internal T GetOrCreateViewData<T>(ScriptableObject existing, string key) where T : ScriptableObject
		{
			Debug.Assert(this.elementPanel != null, "VisualElement.elementPanel is null! Cannot load view data.");
			ISerializableJsonDictionary serializableJsonDictionary = (this.elementPanel == null || this.elementPanel.getViewDataDictionary == null) ? null : this.elementPanel.getViewDataDictionary();
			bool flag = serializableJsonDictionary == null || string.IsNullOrEmpty(this.viewDataKey) || !this.enableViewDataPersistence;
			T result;
			if (flag)
			{
				bool flag2 = existing != null;
				if (flag2)
				{
					result = (existing as T);
				}
				else
				{
					result = ScriptableObject.CreateInstance<T>();
				}
			}
			else
			{
				string str = "__";
				Type typeFromHandle = typeof(T);
				string key2 = key + str + ((typeFromHandle != null) ? typeFromHandle.ToString() : null);
				bool flag3 = !serializableJsonDictionary.ContainsKey(key2);
				if (flag3)
				{
					serializableJsonDictionary.Set<T>(key2, ScriptableObject.CreateInstance<T>());
				}
				result = serializableJsonDictionary.GetScriptable<T>(key2);
			}
			return result;
		}

		// Token: 0x06001833 RID: 6195 RVA: 0x0005C6D4 File Offset: 0x0005A8D4
		internal void OverwriteFromViewData(object obj, string key)
		{
			bool flag = obj == null;
			if (flag)
			{
				throw new ArgumentNullException("obj");
			}
			Debug.Assert(this.elementPanel != null, "VisualElement.elementPanel is null! Cannot load view data.");
			ISerializableJsonDictionary serializableJsonDictionary = (this.elementPanel == null || this.elementPanel.getViewDataDictionary == null) ? null : this.elementPanel.getViewDataDictionary();
			bool flag2 = serializableJsonDictionary == null || string.IsNullOrEmpty(this.viewDataKey) || !this.enableViewDataPersistence;
			if (!flag2)
			{
				string str = "__";
				Type type = obj.GetType();
				string key2 = key + str + ((type != null) ? type.ToString() : null);
				bool flag3 = !serializableJsonDictionary.ContainsKey(key2);
				if (flag3)
				{
					serializableJsonDictionary.Set<object>(key2, obj);
				}
				else
				{
					serializableJsonDictionary.Overwrite(obj, key2);
				}
			}
		}

		// Token: 0x06001834 RID: 6196 RVA: 0x0005C79C File Offset: 0x0005A99C
		internal void SaveViewData()
		{
			bool flag = this.elementPanel != null && this.elementPanel.saveViewData != null && !string.IsNullOrEmpty(this.viewDataKey) && this.enableViewDataPersistence;
			if (flag)
			{
				this.elementPanel.saveViewData();
			}
		}

		// Token: 0x06001835 RID: 6197 RVA: 0x0005C7EC File Offset: 0x0005A9EC
		internal bool IsViewDataPersitenceSupportedOnChildren(bool existingState)
		{
			bool result = existingState;
			bool flag = string.IsNullOrEmpty(this.viewDataKey) && this != this.contentContainer;
			if (flag)
			{
				result = false;
			}
			bool flag2 = this.parent != null && this == this.parent.contentContainer;
			if (flag2)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06001836 RID: 6198 RVA: 0x0005C842 File Offset: 0x0005AA42
		internal void OnViewDataReady(bool enablePersistence)
		{
			this.enableViewDataPersistence = enablePersistence;
			this.OnViewDataReady();
		}

		// Token: 0x06001837 RID: 6199 RVA: 0x00003CD2 File Offset: 0x00001ED2
		internal virtual void OnViewDataReady()
		{
		}

		// Token: 0x06001838 RID: 6200 RVA: 0x0005C854 File Offset: 0x0005AA54
		public virtual bool ContainsPoint(Vector2 localPoint)
		{
			return this.rect.Contains(localPoint);
		}

		// Token: 0x06001839 RID: 6201 RVA: 0x0005C878 File Offset: 0x0005AA78
		public virtual bool Overlaps(Rect rectangle)
		{
			return this.rect.Overlaps(rectangle, true);
		}

		// Token: 0x17000628 RID: 1576
		// (get) Token: 0x0600183A RID: 6202 RVA: 0x0005C89A File Offset: 0x0005AA9A
		// (set) Token: 0x0600183B RID: 6203 RVA: 0x0005C8B0 File Offset: 0x0005AAB0
		internal bool requireMeasureFunction
		{
			get
			{
				return (this.m_Flags & VisualElementFlags.RequireMeasureFunction) == VisualElementFlags.RequireMeasureFunction;
			}
			set
			{
				this.m_Flags = (value ? (this.m_Flags | VisualElementFlags.RequireMeasureFunction) : (this.m_Flags & ~VisualElementFlags.RequireMeasureFunction));
				bool flag = value && !this.yogaNode.IsMeasureDefined;
				if (flag)
				{
					this.AssignMeasureFunction();
				}
				else
				{
					bool flag2 = !value && this.yogaNode.IsMeasureDefined;
					if (flag2)
					{
						this.RemoveMeasureFunction();
					}
				}
			}
		}

		// Token: 0x0600183C RID: 6204 RVA: 0x0005C922 File Offset: 0x0005AB22
		private void AssignMeasureFunction()
		{
			this.yogaNode.SetMeasureFunction((YogaNode node, float f, YogaMeasureMode mode, float f1, YogaMeasureMode heightMode) => this.Measure(node, f, mode, f1, heightMode));
		}

		// Token: 0x0600183D RID: 6205 RVA: 0x0005C93D File Offset: 0x0005AB3D
		private void RemoveMeasureFunction()
		{
			this.yogaNode.SetMeasureFunction(null);
		}

		// Token: 0x0600183E RID: 6206 RVA: 0x0005C950 File Offset: 0x0005AB50
		protected internal virtual Vector2 DoMeasure(float desiredWidth, VisualElement.MeasureMode widthMode, float desiredHeight, VisualElement.MeasureMode heightMode)
		{
			return new Vector2(float.NaN, float.NaN);
		}

		// Token: 0x0600183F RID: 6207 RVA: 0x0005C974 File Offset: 0x0005AB74
		internal YogaSize Measure(YogaNode node, float width, YogaMeasureMode widthMode, float height, YogaMeasureMode heightMode)
		{
			Debug.Assert(node == this.yogaNode, "YogaNode instance mismatch");
			Vector2 vector = this.DoMeasure(width, (VisualElement.MeasureMode)widthMode, height, (VisualElement.MeasureMode)heightMode);
			float scaledPixelsPerPoint = this.scaledPixelsPerPoint;
			return MeasureOutput.Make(AlignmentUtils.RoundToPixelGrid(vector.x, scaledPixelsPerPoint, 0.02f), AlignmentUtils.RoundToPixelGrid(vector.y, scaledPixelsPerPoint, 0.02f));
		}

		// Token: 0x06001840 RID: 6208 RVA: 0x0005C9D8 File Offset: 0x0005ABD8
		internal void SetSize(Vector2 size)
		{
			Rect layout = this.layout;
			layout.width = size.x;
			layout.height = size.y;
			this.layout = layout;
		}

		// Token: 0x06001841 RID: 6209 RVA: 0x0005CA14 File Offset: 0x0005AC14
		private void FinalizeLayout()
		{
			bool flag = this.hasInlineStyle || this.hasRunningAnimations;
			if (flag)
			{
				this.computedStyle.SyncWithLayout(this.yogaNode);
			}
			else
			{
				this.yogaNode.CopyStyle(this.computedStyle.yogaNode);
			}
		}

		// Token: 0x06001842 RID: 6210 RVA: 0x0005CA68 File Offset: 0x0005AC68
		internal void SetInlineRule(StyleSheet sheet, StyleRule rule)
		{
			bool flag = this.inlineStyleAccess == null;
			if (flag)
			{
				this.inlineStyleAccess = new InlineStyleAccess(this);
			}
			this.inlineStyleAccess.SetInlineRule(sheet, rule);
		}

		// Token: 0x06001843 RID: 6211 RVA: 0x0005CAA0 File Offset: 0x0005ACA0
		internal unsafe void UpdateInlineRule(StyleSheet sheet, StyleRule rule)
		{
			ComputedStyle computedStyle = this.computedStyle.Acquire();
			long matchingRulesHash = this.computedStyle.matchingRulesHash;
			ComputedStyle computedStyle2;
			bool flag = !StyleCache.TryGetValue(matchingRulesHash, out computedStyle2);
			if (flag)
			{
				computedStyle2 = *InitialStyle.Get();
			}
			this.m_Style.CopyFrom(ref computedStyle2);
			this.SetInlineRule(sheet, rule);
			this.FinalizeLayout();
			VersionChangeType changeType = ComputedStyle.CompareChanges(ref computedStyle, this.computedStyle);
			computedStyle.Release();
			this.IncrementVersion(changeType);
		}

		// Token: 0x06001844 RID: 6212 RVA: 0x0005CB20 File Offset: 0x0005AD20
		internal void SetComputedStyle(ref ComputedStyle newStyle)
		{
			bool flag = this.m_Style.matchingRulesHash == newStyle.matchingRulesHash;
			if (!flag)
			{
				VersionChangeType changeType = ComputedStyle.CompareChanges(ref this.m_Style, ref newStyle);
				this.m_Style.CopyFrom(ref newStyle);
				this.FinalizeLayout();
				BaseVisualElementPanel elementPanel = this.elementPanel;
				bool flag2 = ((elementPanel != null) ? elementPanel.GetTopElementUnderPointer(PointerId.mousePointerId) : null) == this;
				if (flag2)
				{
					this.elementPanel.cursorManager.SetCursor(this.m_Style.cursor);
				}
				this.IncrementVersion(changeType);
			}
		}

		// Token: 0x06001845 RID: 6213 RVA: 0x0005CBAC File Offset: 0x0005ADAC
		internal void ResetPositionProperties()
		{
			bool flag = !this.hasInlineStyle;
			if (!flag)
			{
				this.style.position = StyleKeyword.Null;
				this.style.marginLeft = StyleKeyword.Null;
				this.style.marginRight = StyleKeyword.Null;
				this.style.marginBottom = StyleKeyword.Null;
				this.style.marginTop = StyleKeyword.Null;
				this.style.left = StyleKeyword.Null;
				this.style.top = StyleKeyword.Null;
				this.style.right = StyleKeyword.Null;
				this.style.bottom = StyleKeyword.Null;
				this.style.width = StyleKeyword.Null;
				this.style.height = StyleKeyword.Null;
			}
		}

		// Token: 0x06001846 RID: 6214 RVA: 0x0005CC94 File Offset: 0x0005AE94
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				base.GetType().Name,
				" ",
				this.name,
				" ",
				this.layout.ToString(),
				" world rect: ",
				this.worldBound.ToString()
			});
		}

		// Token: 0x06001847 RID: 6215 RVA: 0x0005CD10 File Offset: 0x0005AF10
		public IEnumerable<string> GetClasses()
		{
			return this.m_ClassList;
		}

		// Token: 0x06001848 RID: 6216 RVA: 0x0005CD28 File Offset: 0x0005AF28
		internal List<string> GetClassesForIteration()
		{
			return this.m_ClassList;
		}

		// Token: 0x06001849 RID: 6217 RVA: 0x0005CD40 File Offset: 0x0005AF40
		public void ClearClassList()
		{
			bool flag = this.m_ClassList.Count > 0;
			if (flag)
			{
				ObjectListPool<string>.Release(this.m_ClassList);
				this.m_ClassList = VisualElement.s_EmptyClassList;
				this.IncrementVersion(VersionChangeType.StyleSheet);
			}
		}

		// Token: 0x0600184A RID: 6218 RVA: 0x0005CD84 File Offset: 0x0005AF84
		public void AddToClassList(string className)
		{
			bool flag = string.IsNullOrEmpty(className);
			if (!flag)
			{
				bool flag2 = this.m_ClassList == VisualElement.s_EmptyClassList;
				if (flag2)
				{
					this.m_ClassList = ObjectListPool<string>.Get();
				}
				else
				{
					bool flag3 = this.m_ClassList.Contains(className);
					if (flag3)
					{
						return;
					}
					bool flag4 = this.m_ClassList.Capacity == this.m_ClassList.Count;
					if (flag4)
					{
						this.m_ClassList.Capacity++;
					}
				}
				this.m_ClassList.Add(className);
				this.IncrementVersion(VersionChangeType.StyleSheet);
			}
		}

		// Token: 0x0600184B RID: 6219 RVA: 0x0005CE1C File Offset: 0x0005B01C
		public void RemoveFromClassList(string className)
		{
			bool flag = this.m_ClassList.Remove(className);
			if (flag)
			{
				bool flag2 = this.m_ClassList.Count == 0;
				if (flag2)
				{
					ObjectListPool<string>.Release(this.m_ClassList);
					this.m_ClassList = VisualElement.s_EmptyClassList;
				}
				this.IncrementVersion(VersionChangeType.StyleSheet);
			}
		}

		// Token: 0x0600184C RID: 6220 RVA: 0x0005CE70 File Offset: 0x0005B070
		public void ToggleInClassList(string className)
		{
			bool flag = this.ClassListContains(className);
			if (flag)
			{
				this.RemoveFromClassList(className);
			}
			else
			{
				this.AddToClassList(className);
			}
		}

		// Token: 0x0600184D RID: 6221 RVA: 0x0005CE9C File Offset: 0x0005B09C
		public void EnableInClassList(string className, bool enable)
		{
			if (enable)
			{
				this.AddToClassList(className);
			}
			else
			{
				this.RemoveFromClassList(className);
			}
		}

		// Token: 0x0600184E RID: 6222 RVA: 0x0005CEC4 File Offset: 0x0005B0C4
		public bool ClassListContains(string cls)
		{
			for (int i = 0; i < this.m_ClassList.Count; i++)
			{
				bool flag = this.m_ClassList[i].Equals(cls, StringComparison.Ordinal);
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600184F RID: 6223 RVA: 0x0005CF10 File Offset: 0x0005B110
		public object FindAncestorUserData()
		{
			for (VisualElement parent = this.parent; parent != null; parent = parent.parent)
			{
				bool flag = parent.userData != null;
				if (flag)
				{
					return parent.userData;
				}
			}
			return null;
		}

		// Token: 0x06001850 RID: 6224 RVA: 0x0005CF54 File Offset: 0x0005B154
		internal object GetProperty(PropertyName key)
		{
			VisualElement.CheckUserKeyArgument(key);
			object result;
			this.TryGetPropertyInternal(key, out result);
			return result;
		}

		// Token: 0x06001851 RID: 6225 RVA: 0x0005CF78 File Offset: 0x0005B178
		internal void SetProperty(PropertyName key, object value)
		{
			VisualElement.CheckUserKeyArgument(key);
			this.SetPropertyInternal(key, value);
		}

		// Token: 0x06001852 RID: 6226 RVA: 0x0005CF8C File Offset: 0x0005B18C
		internal bool HasProperty(PropertyName key)
		{
			VisualElement.CheckUserKeyArgument(key);
			object obj;
			return this.TryGetPropertyInternal(key, out obj);
		}

		// Token: 0x06001853 RID: 6227 RVA: 0x0005CFB0 File Offset: 0x0005B1B0
		private bool TryGetPropertyInternal(PropertyName key, out object value)
		{
			value = null;
			bool flag = this.m_PropertyBag != null;
			if (flag)
			{
				for (int i = 0; i < this.m_PropertyBag.Count; i++)
				{
					bool flag2 = this.m_PropertyBag[i].Key == key;
					if (flag2)
					{
						value = this.m_PropertyBag[i].Value;
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06001854 RID: 6228 RVA: 0x0005D030 File Offset: 0x0005B230
		private static void CheckUserKeyArgument(PropertyName key)
		{
			bool flag = PropertyName.IsNullOrEmpty(key);
			if (flag)
			{
				throw new ArgumentNullException("key");
			}
			bool flag2 = key == VisualElement.userDataPropertyKey;
			if (flag2)
			{
				throw new InvalidOperationException(string.Format("The {0} key is reserved by the system", VisualElement.userDataPropertyKey));
			}
		}

		// Token: 0x06001855 RID: 6229 RVA: 0x0005D07C File Offset: 0x0005B27C
		private void SetPropertyInternal(PropertyName key, object value)
		{
			KeyValuePair<PropertyName, object> keyValuePair = new KeyValuePair<PropertyName, object>(key, value);
			bool flag = this.m_PropertyBag == null;
			if (flag)
			{
				this.m_PropertyBag = new List<KeyValuePair<PropertyName, object>>(1);
				this.m_PropertyBag.Add(keyValuePair);
			}
			else
			{
				for (int i = 0; i < this.m_PropertyBag.Count; i++)
				{
					bool flag2 = this.m_PropertyBag[i].Key == key;
					if (flag2)
					{
						this.m_PropertyBag[i] = keyValuePair;
						return;
					}
				}
				bool flag3 = this.m_PropertyBag.Capacity == this.m_PropertyBag.Count;
				if (flag3)
				{
					this.m_PropertyBag.Capacity++;
				}
				this.m_PropertyBag.Add(keyValuePair);
			}
		}

		// Token: 0x06001856 RID: 6230 RVA: 0x0005D154 File Offset: 0x0005B354
		private void UpdateCursorStyle(long eventType)
		{
			bool flag = this.elementPanel == null;
			if (!flag)
			{
				bool flag2 = eventType == EventBase<MouseCaptureOutEvent>.TypeId();
				if (flag2)
				{
					VisualElement topElementUnderPointer = this.elementPanel.GetTopElementUnderPointer(PointerId.mousePointerId);
					bool flag3 = topElementUnderPointer != null;
					if (flag3)
					{
						this.elementPanel.cursorManager.SetCursor(topElementUnderPointer.computedStyle.cursor);
					}
					else
					{
						this.elementPanel.cursorManager.ResetCursor();
					}
				}
				else
				{
					IEventHandler capturingElement = this.elementPanel.GetCapturingElement(PointerId.mousePointerId);
					bool flag4 = capturingElement != null && capturingElement != this;
					if (!flag4)
					{
						bool flag5 = eventType == EventBase<MouseOverEvent>.TypeId() && this.elementPanel.GetTopElementUnderPointer(PointerId.mousePointerId) == this;
						if (flag5)
						{
							this.elementPanel.cursorManager.SetCursor(this.computedStyle.cursor);
						}
						else
						{
							bool flag6 = eventType == EventBase<MouseOutEvent>.TypeId() && capturingElement == null;
							if (flag6)
							{
								this.elementPanel.cursorManager.ResetCursor();
							}
						}
					}
				}
			}
		}

		// Token: 0x17000629 RID: 1577
		// (get) Token: 0x06001857 RID: 6231 RVA: 0x0005D268 File Offset: 0x0005B468
		// (set) Token: 0x06001858 RID: 6232 RVA: 0x0005D280 File Offset: 0x0005B480
		internal VisualElement.RenderTargetMode subRenderTargetMode
		{
			get
			{
				return this.m_SubRenderTargetMode;
			}
			set
			{
				bool flag = this.m_SubRenderTargetMode == value;
				if (!flag)
				{
					Debug.Assert(Application.isEditor, "subRenderTargetMode is not supported on runtime yet");
					this.m_SubRenderTargetMode = value;
					this.IncrementVersion(VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x06001859 RID: 6233 RVA: 0x0005D2C0 File Offset: 0x0005B4C0
		private Material getRuntimeMaterial()
		{
			bool flag = VisualElement.s_runtimeMaterial != null;
			Material result;
			if (flag)
			{
				result = VisualElement.s_runtimeMaterial;
			}
			else
			{
				Shader shader = Shader.Find(UIRUtility.k_DefaultShaderName);
				Debug.Assert(shader != null, "Failed to load UIElements default shader");
				bool flag2 = shader != null;
				if (flag2)
				{
					shader.hideFlags |= HideFlags.DontSaveInEditor;
					Material material = new Material(shader);
					material.hideFlags |= HideFlags.DontSaveInEditor;
					result = (VisualElement.s_runtimeMaterial = material);
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x1700062A RID: 1578
		// (get) Token: 0x0600185A RID: 6234 RVA: 0x0005D348 File Offset: 0x0005B548
		// (set) Token: 0x0600185B RID: 6235 RVA: 0x0005D360 File Offset: 0x0005B560
		internal Material defaultMaterial
		{
			get
			{
				return this.m_defaultMaterial;
			}
			private set
			{
				bool flag = this.m_defaultMaterial == value;
				if (!flag)
				{
					this.m_defaultMaterial = value;
					this.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x0600185C RID: 6236 RVA: 0x0005D394 File Offset: 0x0005B594
		private VisualElementAnimationSystem GetAnimationSystem()
		{
			bool flag = this.elementPanel != null;
			VisualElementAnimationSystem result;
			if (flag)
			{
				result = (this.elementPanel.GetUpdater(VisualTreeUpdatePhase.Animation) as VisualElementAnimationSystem);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600185D RID: 6237 RVA: 0x0005D3CC File Offset: 0x0005B5CC
		internal void RegisterAnimation(IValueAnimationUpdate anim)
		{
			bool flag = this.m_RunningAnimations == null;
			if (flag)
			{
				this.m_RunningAnimations = new List<IValueAnimationUpdate>();
			}
			this.m_RunningAnimations.Add(anim);
			VisualElementAnimationSystem animationSystem = this.GetAnimationSystem();
			bool flag2 = animationSystem != null;
			if (flag2)
			{
				animationSystem.RegisterAnimation(anim);
			}
		}

		// Token: 0x0600185E RID: 6238 RVA: 0x0005D41C File Offset: 0x0005B61C
		internal void UnregisterAnimation(IValueAnimationUpdate anim)
		{
			bool flag = this.m_RunningAnimations != null;
			if (flag)
			{
				this.m_RunningAnimations.Remove(anim);
			}
			VisualElementAnimationSystem animationSystem = this.GetAnimationSystem();
			bool flag2 = animationSystem != null;
			if (flag2)
			{
				animationSystem.UnregisterAnimation(anim);
			}
		}

		// Token: 0x0600185F RID: 6239 RVA: 0x0005D460 File Offset: 0x0005B660
		private void UnregisterRunningAnimations()
		{
			bool flag = this.m_RunningAnimations != null && this.m_RunningAnimations.Count > 0;
			if (flag)
			{
				VisualElementAnimationSystem animationSystem = this.GetAnimationSystem();
				bool flag2 = animationSystem != null;
				if (flag2)
				{
					animationSystem.UnregisterAnimations(this.m_RunningAnimations);
				}
			}
			this.styleAnimation.CancelAllAnimations();
		}

		// Token: 0x06001860 RID: 6240 RVA: 0x0005D4B8 File Offset: 0x0005B6B8
		private void RegisterRunningAnimations()
		{
			bool flag = this.m_RunningAnimations != null && this.m_RunningAnimations.Count > 0;
			if (flag)
			{
				VisualElementAnimationSystem animationSystem = this.GetAnimationSystem();
				bool flag2 = animationSystem != null;
				if (flag2)
				{
					animationSystem.RegisterAnimations(this.m_RunningAnimations);
				}
			}
		}

		// Token: 0x06001861 RID: 6241 RVA: 0x0005D504 File Offset: 0x0005B704
		ValueAnimation<float> ITransitionAnimations.Start(float from, float to, int durationMs, Action<VisualElement, float> onValueChanged)
		{
			return this.experimental.animation.Start((VisualElement e) => from, to, durationMs, onValueChanged);
		}

		// Token: 0x06001862 RID: 6242 RVA: 0x0005D544 File Offset: 0x0005B744
		ValueAnimation<Rect> ITransitionAnimations.Start(Rect from, Rect to, int durationMs, Action<VisualElement, Rect> onValueChanged)
		{
			return this.experimental.animation.Start((VisualElement e) => from, to, durationMs, onValueChanged);
		}

		// Token: 0x06001863 RID: 6243 RVA: 0x0005D584 File Offset: 0x0005B784
		ValueAnimation<Color> ITransitionAnimations.Start(Color from, Color to, int durationMs, Action<VisualElement, Color> onValueChanged)
		{
			return this.experimental.animation.Start((VisualElement e) => from, to, durationMs, onValueChanged);
		}

		// Token: 0x06001864 RID: 6244 RVA: 0x0005D5C4 File Offset: 0x0005B7C4
		ValueAnimation<Vector3> ITransitionAnimations.Start(Vector3 from, Vector3 to, int durationMs, Action<VisualElement, Vector3> onValueChanged)
		{
			return this.experimental.animation.Start((VisualElement e) => from, to, durationMs, onValueChanged);
		}

		// Token: 0x06001865 RID: 6245 RVA: 0x0005D604 File Offset: 0x0005B804
		ValueAnimation<Vector2> ITransitionAnimations.Start(Vector2 from, Vector2 to, int durationMs, Action<VisualElement, Vector2> onValueChanged)
		{
			return this.experimental.animation.Start((VisualElement e) => from, to, durationMs, onValueChanged);
		}

		// Token: 0x06001866 RID: 6246 RVA: 0x0005D644 File Offset: 0x0005B844
		ValueAnimation<Quaternion> ITransitionAnimations.Start(Quaternion from, Quaternion to, int durationMs, Action<VisualElement, Quaternion> onValueChanged)
		{
			return this.experimental.animation.Start((VisualElement e) => from, to, durationMs, onValueChanged);
		}

		// Token: 0x06001867 RID: 6247 RVA: 0x0005D684 File Offset: 0x0005B884
		ValueAnimation<StyleValues> ITransitionAnimations.Start(StyleValues from, StyleValues to, int durationMs)
		{
			bool flag = from.m_StyleValues == null;
			if (flag)
			{
				from.Values();
			}
			bool flag2 = to.m_StyleValues == null;
			if (flag2)
			{
				to.Values();
			}
			return this.Start((VisualElement e) => from, to, durationMs);
		}

		// Token: 0x06001868 RID: 6248 RVA: 0x0005D6EC File Offset: 0x0005B8EC
		ValueAnimation<float> ITransitionAnimations.Start(Func<VisualElement, float> fromValueGetter, float to, int durationMs, Action<VisualElement, float> onValueChanged)
		{
			return VisualElement.StartAnimation<float>(ValueAnimation<float>.Create(this, new Func<float, float, float, float>(Lerp.Interpolate)), fromValueGetter, to, durationMs, onValueChanged);
		}

		// Token: 0x06001869 RID: 6249 RVA: 0x0005D71C File Offset: 0x0005B91C
		ValueAnimation<Rect> ITransitionAnimations.Start(Func<VisualElement, Rect> fromValueGetter, Rect to, int durationMs, Action<VisualElement, Rect> onValueChanged)
		{
			return VisualElement.StartAnimation<Rect>(ValueAnimation<Rect>.Create(this, new Func<Rect, Rect, float, Rect>(Lerp.Interpolate)), fromValueGetter, to, durationMs, onValueChanged);
		}

		// Token: 0x0600186A RID: 6250 RVA: 0x0005D74C File Offset: 0x0005B94C
		ValueAnimation<Color> ITransitionAnimations.Start(Func<VisualElement, Color> fromValueGetter, Color to, int durationMs, Action<VisualElement, Color> onValueChanged)
		{
			return VisualElement.StartAnimation<Color>(ValueAnimation<Color>.Create(this, new Func<Color, Color, float, Color>(Lerp.Interpolate)), fromValueGetter, to, durationMs, onValueChanged);
		}

		// Token: 0x0600186B RID: 6251 RVA: 0x0005D77C File Offset: 0x0005B97C
		ValueAnimation<Vector3> ITransitionAnimations.Start(Func<VisualElement, Vector3> fromValueGetter, Vector3 to, int durationMs, Action<VisualElement, Vector3> onValueChanged)
		{
			return VisualElement.StartAnimation<Vector3>(ValueAnimation<Vector3>.Create(this, new Func<Vector3, Vector3, float, Vector3>(Lerp.Interpolate)), fromValueGetter, to, durationMs, onValueChanged);
		}

		// Token: 0x0600186C RID: 6252 RVA: 0x0005D7AC File Offset: 0x0005B9AC
		ValueAnimation<Vector2> ITransitionAnimations.Start(Func<VisualElement, Vector2> fromValueGetter, Vector2 to, int durationMs, Action<VisualElement, Vector2> onValueChanged)
		{
			return VisualElement.StartAnimation<Vector2>(ValueAnimation<Vector2>.Create(this, new Func<Vector2, Vector2, float, Vector2>(Lerp.Interpolate)), fromValueGetter, to, durationMs, onValueChanged);
		}

		// Token: 0x0600186D RID: 6253 RVA: 0x0005D7DC File Offset: 0x0005B9DC
		ValueAnimation<Quaternion> ITransitionAnimations.Start(Func<VisualElement, Quaternion> fromValueGetter, Quaternion to, int durationMs, Action<VisualElement, Quaternion> onValueChanged)
		{
			return VisualElement.StartAnimation<Quaternion>(ValueAnimation<Quaternion>.Create(this, new Func<Quaternion, Quaternion, float, Quaternion>(Lerp.Interpolate)), fromValueGetter, to, durationMs, onValueChanged);
		}

		// Token: 0x0600186E RID: 6254 RVA: 0x0005D80C File Offset: 0x0005BA0C
		private static ValueAnimation<T> StartAnimation<T>(ValueAnimation<T> anim, Func<VisualElement, T> fromValueGetter, T to, int durationMs, Action<VisualElement, T> onValueChanged)
		{
			anim.initialValue = fromValueGetter;
			anim.to = to;
			anim.durationMs = durationMs;
			anim.valueUpdated = onValueChanged;
			anim.Start();
			return anim;
		}

		// Token: 0x0600186F RID: 6255 RVA: 0x0005D848 File Offset: 0x0005BA48
		private static void AssignStyleValues(VisualElement ve, StyleValues src)
		{
			IStyle style = ve.style;
			bool flag = src.m_StyleValues != null;
			if (flag)
			{
				foreach (StyleValue styleValue in src.m_StyleValues.m_Values)
				{
					StylePropertyId id = styleValue.id;
					StylePropertyId stylePropertyId = id;
					if (stylePropertyId <= StylePropertyId.Width)
					{
						if (stylePropertyId <= StylePropertyId.Color)
						{
							if (stylePropertyId != StylePropertyId.Unknown)
							{
								if (stylePropertyId == StylePropertyId.Color)
								{
									style.color = styleValue.color;
								}
							}
						}
						else if (stylePropertyId != StylePropertyId.FontSize)
						{
							switch (stylePropertyId)
							{
							case StylePropertyId.BorderBottomWidth:
								style.borderBottomWidth = styleValue.number;
								break;
							case StylePropertyId.BorderLeftWidth:
								style.borderLeftWidth = styleValue.number;
								break;
							case StylePropertyId.BorderRightWidth:
								style.borderRightWidth = styleValue.number;
								break;
							case StylePropertyId.BorderTopWidth:
								style.borderTopWidth = styleValue.number;
								break;
							case StylePropertyId.Bottom:
								style.bottom = styleValue.number;
								break;
							case StylePropertyId.FlexGrow:
								style.flexGrow = styleValue.number;
								break;
							case StylePropertyId.FlexShrink:
								style.flexShrink = styleValue.number;
								break;
							case StylePropertyId.Height:
								style.height = styleValue.number;
								break;
							case StylePropertyId.Left:
								style.left = styleValue.number;
								break;
							case StylePropertyId.MarginBottom:
								style.marginBottom = styleValue.number;
								break;
							case StylePropertyId.MarginLeft:
								style.marginLeft = styleValue.number;
								break;
							case StylePropertyId.MarginRight:
								style.marginRight = styleValue.number;
								break;
							case StylePropertyId.MarginTop:
								style.marginTop = styleValue.number;
								break;
							case StylePropertyId.PaddingBottom:
								style.paddingBottom = styleValue.number;
								break;
							case StylePropertyId.PaddingLeft:
								style.paddingLeft = styleValue.number;
								break;
							case StylePropertyId.PaddingRight:
								style.paddingRight = styleValue.number;
								break;
							case StylePropertyId.PaddingTop:
								style.paddingTop = styleValue.number;
								break;
							case StylePropertyId.Right:
								style.right = styleValue.number;
								break;
							case StylePropertyId.Top:
								style.top = styleValue.number;
								break;
							case StylePropertyId.Width:
								style.width = styleValue.number;
								break;
							}
						}
						else
						{
							style.fontSize = styleValue.number;
						}
					}
					else if (stylePropertyId <= StylePropertyId.BorderColor)
					{
						if (stylePropertyId != StylePropertyId.UnityBackgroundImageTintColor)
						{
							if (stylePropertyId == StylePropertyId.BorderColor)
							{
								style.borderLeftColor = styleValue.color;
								style.borderTopColor = styleValue.color;
								style.borderRightColor = styleValue.color;
								style.borderBottomColor = styleValue.color;
							}
						}
						else
						{
							style.unityBackgroundImageTintColor = styleValue.color;
						}
					}
					else if (stylePropertyId != StylePropertyId.BackgroundColor)
					{
						switch (stylePropertyId)
						{
						case StylePropertyId.BorderBottomLeftRadius:
							style.borderBottomLeftRadius = styleValue.number;
							break;
						case StylePropertyId.BorderBottomRightRadius:
							style.borderBottomRightRadius = styleValue.number;
							break;
						case StylePropertyId.BorderTopLeftRadius:
							style.borderTopLeftRadius = styleValue.number;
							break;
						case StylePropertyId.BorderTopRightRadius:
							style.borderTopRightRadius = styleValue.number;
							break;
						case StylePropertyId.Opacity:
							style.opacity = styleValue.number;
							break;
						}
					}
					else
					{
						style.backgroundColor = styleValue.color;
					}
				}
			}
		}

		// Token: 0x06001870 RID: 6256 RVA: 0x0005DCE8 File Offset: 0x0005BEE8
		private StyleValues ReadCurrentValues(VisualElement ve, StyleValues targetValuesToRead)
		{
			StyleValues result = default(StyleValues);
			IResolvedStyle resolvedStyle = ve.resolvedStyle;
			bool flag = targetValuesToRead.m_StyleValues != null;
			if (flag)
			{
				foreach (StyleValue styleValue in targetValuesToRead.m_StyleValues.m_Values)
				{
					StylePropertyId id = styleValue.id;
					StylePropertyId stylePropertyId = id;
					if (stylePropertyId <= StylePropertyId.Width)
					{
						if (stylePropertyId != StylePropertyId.Unknown)
						{
							if (stylePropertyId != StylePropertyId.Color)
							{
								switch (stylePropertyId)
								{
								case StylePropertyId.BorderBottomWidth:
									result.borderBottomWidth = resolvedStyle.borderBottomWidth;
									break;
								case StylePropertyId.BorderLeftWidth:
									result.borderLeftWidth = resolvedStyle.borderLeftWidth;
									break;
								case StylePropertyId.BorderRightWidth:
									result.borderRightWidth = resolvedStyle.borderRightWidth;
									break;
								case StylePropertyId.BorderTopWidth:
									result.borderTopWidth = resolvedStyle.borderTopWidth;
									break;
								case StylePropertyId.Bottom:
									result.bottom = resolvedStyle.bottom;
									break;
								case StylePropertyId.FlexGrow:
									result.flexGrow = resolvedStyle.flexGrow;
									break;
								case StylePropertyId.FlexShrink:
									result.flexShrink = resolvedStyle.flexShrink;
									break;
								case StylePropertyId.Height:
									result.height = resolvedStyle.height;
									break;
								case StylePropertyId.Left:
									result.left = resolvedStyle.left;
									break;
								case StylePropertyId.MarginBottom:
									result.marginBottom = resolvedStyle.marginBottom;
									break;
								case StylePropertyId.MarginLeft:
									result.marginLeft = resolvedStyle.marginLeft;
									break;
								case StylePropertyId.MarginRight:
									result.marginRight = resolvedStyle.marginRight;
									break;
								case StylePropertyId.MarginTop:
									result.marginTop = resolvedStyle.marginTop;
									break;
								case StylePropertyId.PaddingBottom:
									result.paddingBottom = resolvedStyle.paddingBottom;
									break;
								case StylePropertyId.PaddingLeft:
									result.paddingLeft = resolvedStyle.paddingLeft;
									break;
								case StylePropertyId.PaddingRight:
									result.paddingRight = resolvedStyle.paddingRight;
									break;
								case StylePropertyId.PaddingTop:
									result.paddingTop = resolvedStyle.paddingTop;
									break;
								case StylePropertyId.Right:
									result.right = resolvedStyle.right;
									break;
								case StylePropertyId.Top:
									result.top = resolvedStyle.top;
									break;
								case StylePropertyId.Width:
									result.width = resolvedStyle.width;
									break;
								}
							}
							else
							{
								result.color = resolvedStyle.color;
							}
						}
					}
					else if (stylePropertyId <= StylePropertyId.BorderColor)
					{
						if (stylePropertyId != StylePropertyId.UnityBackgroundImageTintColor)
						{
							if (stylePropertyId == StylePropertyId.BorderColor)
							{
								result.borderColor = resolvedStyle.borderLeftColor;
							}
						}
						else
						{
							result.unityBackgroundImageTintColor = resolvedStyle.unityBackgroundImageTintColor;
						}
					}
					else if (stylePropertyId != StylePropertyId.BackgroundColor)
					{
						switch (stylePropertyId)
						{
						case StylePropertyId.BorderBottomLeftRadius:
							result.borderBottomLeftRadius = resolvedStyle.borderBottomLeftRadius;
							break;
						case StylePropertyId.BorderBottomRightRadius:
							result.borderBottomRightRadius = resolvedStyle.borderBottomRightRadius;
							break;
						case StylePropertyId.BorderTopLeftRadius:
							result.borderTopLeftRadius = resolvedStyle.borderTopLeftRadius;
							break;
						case StylePropertyId.BorderTopRightRadius:
							result.borderTopRightRadius = resolvedStyle.borderTopRightRadius;
							break;
						case StylePropertyId.Opacity:
							result.opacity = resolvedStyle.opacity;
							break;
						}
					}
					else
					{
						result.backgroundColor = resolvedStyle.backgroundColor;
					}
				}
			}
			return result;
		}

		// Token: 0x06001871 RID: 6257 RVA: 0x0005E0B4 File Offset: 0x0005C2B4
		ValueAnimation<StyleValues> ITransitionAnimations.Start(StyleValues to, int durationMs)
		{
			bool flag = to.m_StyleValues == null;
			if (flag)
			{
				to.Values();
			}
			return this.Start((VisualElement e) => this.ReadCurrentValues(e, to), to, durationMs);
		}

		// Token: 0x06001872 RID: 6258 RVA: 0x0005E114 File Offset: 0x0005C314
		private ValueAnimation<StyleValues> Start(Func<VisualElement, StyleValues> fromValueGetter, StyleValues to, int durationMs)
		{
			return VisualElement.StartAnimation<StyleValues>(ValueAnimation<StyleValues>.Create(this, new Func<StyleValues, StyleValues, float, StyleValues>(Lerp.Interpolate)), fromValueGetter, to, durationMs, new Action<VisualElement, StyleValues>(VisualElement.AssignStyleValues));
		}

		// Token: 0x06001873 RID: 6259 RVA: 0x0005E14C File Offset: 0x0005C34C
		ValueAnimation<Rect> ITransitionAnimations.Layout(Rect to, int durationMs)
		{
			return this.experimental.animation.Start((VisualElement e) => new Rect(e.resolvedStyle.left, e.resolvedStyle.top, e.resolvedStyle.width, e.resolvedStyle.height), to, durationMs, delegate(VisualElement e, Rect c)
			{
				e.style.left = c.x;
				e.style.top = c.y;
				e.style.width = c.width;
				e.style.height = c.height;
			});
		}

		// Token: 0x06001874 RID: 6260 RVA: 0x0005E1B0 File Offset: 0x0005C3B0
		ValueAnimation<Vector2> ITransitionAnimations.TopLeft(Vector2 to, int durationMs)
		{
			return this.experimental.animation.Start((VisualElement e) => new Vector2(e.resolvedStyle.left, e.resolvedStyle.top), to, durationMs, delegate(VisualElement e, Vector2 c)
			{
				e.style.left = c.x;
				e.style.top = c.y;
			});
		}

		// Token: 0x06001875 RID: 6261 RVA: 0x0005E214 File Offset: 0x0005C414
		ValueAnimation<Vector2> ITransitionAnimations.Size(Vector2 to, int durationMs)
		{
			return this.experimental.animation.Start((VisualElement e) => e.layout.size, to, durationMs, delegate(VisualElement e, Vector2 c)
			{
				e.style.width = c.x;
				e.style.height = c.y;
			});
		}

		// Token: 0x06001876 RID: 6262 RVA: 0x0005E278 File Offset: 0x0005C478
		ValueAnimation<float> ITransitionAnimations.Scale(float to, int durationMs)
		{
			return this.experimental.animation.Start((VisualElement e) => e.transform.scale.x, to, durationMs, delegate(VisualElement e, float c)
			{
				e.transform.scale = new Vector3(c, c, c);
			});
		}

		// Token: 0x06001877 RID: 6263 RVA: 0x0005E2DC File Offset: 0x0005C4DC
		ValueAnimation<Vector3> ITransitionAnimations.Position(Vector3 to, int durationMs)
		{
			return this.experimental.animation.Start((VisualElement e) => e.transform.position, to, durationMs, delegate(VisualElement e, Vector3 c)
			{
				e.transform.position = c;
			});
		}

		// Token: 0x06001878 RID: 6264 RVA: 0x0005E340 File Offset: 0x0005C540
		ValueAnimation<Quaternion> ITransitionAnimations.Rotation(Quaternion to, int durationMs)
		{
			return this.experimental.animation.Start((VisualElement e) => e.transform.rotation, to, durationMs, delegate(VisualElement e, Quaternion c)
			{
				e.transform.rotation = c;
			});
		}

		// Token: 0x06001879 RID: 6265 RVA: 0x0005E3A4 File Offset: 0x0005C5A4
		private void DirtyNextParentWithEventCallback()
		{
			bool flag = this.m_CachedNextParentWithEventCallback != null && this.m_NextParentCachedVersion == this.m_CachedNextParentWithEventCallback.m_NextParentRequiredVersion;
			if (flag)
			{
				this.m_CachedNextParentWithEventCallback.m_NextParentRequiredVersion = (VisualElement.s_NextParentVersion += 1U);
			}
		}

		// Token: 0x0600187A RID: 6266 RVA: 0x0005E3F0 File Offset: 0x0005C5F0
		private void SetAsNextParentWithEventCallback()
		{
			bool flag = this.m_NextParentRequiredVersion > 0U;
			if (!flag)
			{
				this.m_NextParentRequiredVersion = (VisualElement.s_NextParentVersion += 1U);
				bool flag2 = this.m_CachedNextParentWithEventCallback != null && this.m_NextParentCachedVersion == this.m_CachedNextParentWithEventCallback.m_NextParentRequiredVersion;
				if (flag2)
				{
					this.m_CachedNextParentWithEventCallback.m_NextParentRequiredVersion = (VisualElement.s_NextParentVersion += 1U);
				}
			}
		}

		// Token: 0x0600187B RID: 6267 RVA: 0x0005E45C File Offset: 0x0005C65C
		internal bool GetCachedNextParentWithEventCallback(out VisualElement nextParent)
		{
			nextParent = this.m_CachedNextParentWithEventCallback;
			return nextParent != null && nextParent.m_NextParentRequiredVersion == this.m_NextParentCachedVersion;
		}

		// Token: 0x1700062B RID: 1579
		// (get) Token: 0x0600187C RID: 6268 RVA: 0x0005E48C File Offset: 0x0005C68C
		internal VisualElement nextParentWithEventCallback
		{
			get
			{
				VisualElement visualElement;
				bool cachedNextParentWithEventCallback = this.GetCachedNextParentWithEventCallback(out visualElement);
				VisualElement result;
				if (cachedNextParentWithEventCallback)
				{
					result = visualElement;
				}
				else
				{
					for (VisualElement parent = this.hierarchy.parent; parent != null; parent = parent.hierarchy.parent)
					{
						bool flag = parent.m_NextParentRequiredVersion > 0U;
						if (flag)
						{
							this.PropagateCachedNextParentWithEventCallback(parent, parent);
							return parent;
						}
						VisualElement visualElement2;
						bool cachedNextParentWithEventCallback2 = parent.GetCachedNextParentWithEventCallback(out visualElement2);
						if (cachedNextParentWithEventCallback2)
						{
							this.PropagateCachedNextParentWithEventCallback(visualElement2, parent);
							return visualElement2;
						}
					}
					this.m_CachedNextParentWithEventCallback = null;
					result = null;
				}
				return result;
			}
		}

		// Token: 0x0600187D RID: 6269 RVA: 0x0005E520 File Offset: 0x0005C720
		private void PropagateCachedNextParentWithEventCallback(VisualElement nextParent, VisualElement stopParent)
		{
			for (VisualElement visualElement = this; visualElement != stopParent; visualElement = visualElement.hierarchy.parent)
			{
				visualElement.m_CachedNextParentWithEventCallback = nextParent;
				visualElement.m_NextParentCachedVersion = nextParent.m_NextParentRequiredVersion;
			}
		}

		// Token: 0x1700062C RID: 1580
		// (get) Token: 0x0600187E RID: 6270 RVA: 0x0005E561 File Offset: 0x0005C761
		// (set) Token: 0x0600187F RID: 6271 RVA: 0x0005E56C File Offset: 0x0005C76C
		internal int eventCallbackCategories
		{
			get
			{
				return this.m_EventCallbackCategories;
			}
			set
			{
				bool flag = this.m_EventCallbackCategories != value;
				if (flag)
				{
					int num = this.m_EventCallbackCategories ^ value;
					bool flag2 = (num & -2769) != 0;
					if (flag2)
					{
						this.SetAsNextParentWithEventCallback();
						this.IncrementVersion(VersionChangeType.EventCallbackCategories);
					}
					else
					{
						this.m_CachedEventCallbackParentCategories |= value;
					}
					this.m_EventCallbackCategories = value;
				}
			}
		}

		// Token: 0x1700062D RID: 1581
		// (get) Token: 0x06001880 RID: 6272 RVA: 0x0005E5D4 File Offset: 0x0005C7D4
		internal int eventCallbackParentCategories
		{
			get
			{
				bool flag = this.elementPanel == null;
				int result;
				if (flag)
				{
					result = -1;
				}
				else
				{
					bool isEventCallbackParentCategoriesDirty = this.isEventCallbackParentCategoriesDirty;
					if (isEventCallbackParentCategoriesDirty)
					{
						this.UpdateCallbackParentCategories();
						this.isEventCallbackParentCategoriesDirty = false;
					}
					result = this.m_CachedEventCallbackParentCategories;
				}
				return result;
			}
		}

		// Token: 0x1700062E RID: 1582
		// (get) Token: 0x06001881 RID: 6273 RVA: 0x0005E618 File Offset: 0x0005C818
		// (set) Token: 0x06001882 RID: 6274 RVA: 0x0005E627 File Offset: 0x0005C827
		internal bool isEventCallbackParentCategoriesDirty
		{
			get
			{
				return (this.m_Flags & VisualElementFlags.EventCallbackParentCategoriesDirty) == VisualElementFlags.EventCallbackParentCategoriesDirty;
			}
			set
			{
				this.m_Flags = (value ? (this.m_Flags | VisualElementFlags.EventCallbackParentCategoriesDirty) : (this.m_Flags & ~VisualElementFlags.EventCallbackParentCategoriesDirty));
			}
		}

		// Token: 0x06001883 RID: 6275 RVA: 0x0005E648 File Offset: 0x0005C848
		private void UpdateCallbackParentCategories()
		{
			this.m_CachedEventCallbackParentCategories = this.m_EventCallbackCategories;
			bool isCompositeRoot = this.isCompositeRoot;
			if (isCompositeRoot)
			{
				this.m_CachedEventCallbackParentCategories |= this.m_DefaultActionEventCategories;
			}
			VisualElement nextParentWithEventCallback = this.nextParentWithEventCallback;
			bool flag = nextParentWithEventCallback == null;
			if (!flag)
			{
				this.m_CachedEventCallbackParentCategories |= nextParentWithEventCallback.eventCallbackParentCategories;
				bool flag2 = this.hierarchy.parent != null;
				if (flag2)
				{
					for (VisualElement parent = this.hierarchy.parent; parent != nextParentWithEventCallback; parent = parent.hierarchy.parent)
					{
						parent.m_CachedEventCallbackParentCategories = this.m_CachedEventCallbackParentCategories;
						parent.isEventCallbackParentCategoriesDirty = false;
					}
				}
			}
		}

		// Token: 0x06001884 RID: 6276 RVA: 0x0005E706 File Offset: 0x0005C906
		internal bool HasEventCallbacks(EventCategory eventCategory)
		{
			return (this.eventCallbackCategories & 1 << (int)eventCategory) != 0;
		}

		// Token: 0x06001885 RID: 6277 RVA: 0x0005E718 File Offset: 0x0005C918
		internal bool HasParentEventCallbacks(EventCategory eventCategory)
		{
			return (this.eventCallbackParentCategories & 1 << (int)eventCategory) != 0;
		}

		// Token: 0x06001886 RID: 6278 RVA: 0x0005E72A File Offset: 0x0005C92A
		internal bool HasParentEventCallbacksOrDefaultActions(EventCategory eventCategory)
		{
			return ((this.m_DefaultActionEventCategories | this.m_DefaultActionAtTargetEventCategories | this.eventCallbackParentCategories) & 1 << (int)eventCategory) != 0;
		}

		// Token: 0x06001887 RID: 6279 RVA: 0x0005E74A File Offset: 0x0005C94A
		internal bool HasEventCallbacksOrDefaultActions(EventCategory eventCategory)
		{
			return ((this.m_DefaultActionEventCategories | this.m_DefaultActionAtTargetEventCategories | this.eventCallbackCategories) & 1 << (int)eventCategory) != 0;
		}

		// Token: 0x06001888 RID: 6280 RVA: 0x0005E76A File Offset: 0x0005C96A
		internal bool HasParentEventCallbacksOrDefaultActionAtTarget(EventCategory eventCategory)
		{
			return ((this.m_DefaultActionAtTargetEventCategories | this.eventCallbackParentCategories) & 1 << (int)eventCategory) != 0;
		}

		// Token: 0x06001889 RID: 6281 RVA: 0x0005E783 File Offset: 0x0005C983
		internal bool HasEventCallbacksOrDefaultActionAtTarget(EventCategory eventCategory)
		{
			return ((this.m_DefaultActionAtTargetEventCategories | this.eventCallbackCategories) & 1 << (int)eventCategory) != 0;
		}

		// Token: 0x0600188A RID: 6282 RVA: 0x0005E79C File Offset: 0x0005C99C
		internal bool HasDefaultAction(EventCategory eventCategory)
		{
			return (this.m_DefaultActionEventCategories & 1 << (int)eventCategory) != 0;
		}

		// Token: 0x1700062F RID: 1583
		// (get) Token: 0x0600188B RID: 6283 RVA: 0x0005E7B0 File Offset: 0x0005C9B0
		public IExperimentalFeatures experimental
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000630 RID: 1584
		// (get) Token: 0x0600188C RID: 6284 RVA: 0x0005E7C4 File Offset: 0x0005C9C4
		ITransitionAnimations IExperimentalFeatures.animation
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000631 RID: 1585
		// (get) Token: 0x0600188D RID: 6285 RVA: 0x0005E7D7 File Offset: 0x0005C9D7
		// (set) Token: 0x0600188E RID: 6286 RVA: 0x0005E7DF File Offset: 0x0005C9DF
		public VisualElement.Hierarchy hierarchy { get; private set; }

		// Token: 0x17000632 RID: 1586
		// (get) Token: 0x0600188F RID: 6287 RVA: 0x0005E7E8 File Offset: 0x0005C9E8
		// (set) Token: 0x06001890 RID: 6288 RVA: 0x0005E7F0 File Offset: 0x0005C9F0
		internal bool isRootVisualContainer { get; set; }

		// Token: 0x17000633 RID: 1587
		// (get) Token: 0x06001891 RID: 6289 RVA: 0x0005E7F9 File Offset: 0x0005C9F9
		// (set) Token: 0x06001892 RID: 6290 RVA: 0x0005E801 File Offset: 0x0005CA01
		[Obsolete("VisualElement.cacheAsBitmap is deprecated and has no effect")]
		public bool cacheAsBitmap { get; set; }

		// Token: 0x17000634 RID: 1588
		// (get) Token: 0x06001893 RID: 6291 RVA: 0x0005E80A File Offset: 0x0005CA0A
		// (set) Token: 0x06001894 RID: 6292 RVA: 0x0005E81F File Offset: 0x0005CA1F
		internal bool disableClipping
		{
			get
			{
				return (this.m_Flags & VisualElementFlags.DisableClipping) == VisualElementFlags.DisableClipping;
			}
			set
			{
				this.m_Flags = (value ? (this.m_Flags | VisualElementFlags.DisableClipping) : (this.m_Flags & ~VisualElementFlags.DisableClipping));
			}
		}

		// Token: 0x06001895 RID: 6293 RVA: 0x0005E844 File Offset: 0x0005CA44
		internal bool ShouldClip()
		{
			return this.computedStyle.overflow != OverflowInternal.Visible && !this.disableClipping;
		}

		// Token: 0x17000635 RID: 1589
		// (get) Token: 0x06001896 RID: 6294 RVA: 0x0005E870 File Offset: 0x0005CA70
		public VisualElement parent
		{
			get
			{
				return this.m_LogicalParent;
			}
		}

		// Token: 0x17000636 RID: 1590
		// (get) Token: 0x06001897 RID: 6295 RVA: 0x0005E888 File Offset: 0x0005CA88
		// (set) Token: 0x06001898 RID: 6296 RVA: 0x0005E890 File Offset: 0x0005CA90
		internal BaseVisualElementPanel elementPanel { get; private set; }

		// Token: 0x17000637 RID: 1591
		// (get) Token: 0x06001899 RID: 6297 RVA: 0x0005E89C File Offset: 0x0005CA9C
		public IPanel panel
		{
			get
			{
				return this.elementPanel;
			}
		}

		// Token: 0x17000638 RID: 1592
		// (get) Token: 0x0600189A RID: 6298 RVA: 0x0005E8B4 File Offset: 0x0005CAB4
		public virtual VisualElement contentContainer
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000639 RID: 1593
		// (get) Token: 0x0600189B RID: 6299 RVA: 0x0005E8C7 File Offset: 0x0005CAC7
		// (set) Token: 0x0600189C RID: 6300 RVA: 0x0005E8CF File Offset: 0x0005CACF
		public VisualTreeAsset visualTreeAssetSource
		{
			get
			{
				return this.m_VisualTreeAssetSource;
			}
			internal set
			{
				this.m_VisualTreeAssetSource = value;
			}
		}

		// Token: 0x0600189D RID: 6301 RVA: 0x0005E8D8 File Offset: 0x0005CAD8
		public void Add(VisualElement child)
		{
			bool flag = child == null;
			if (!flag)
			{
				VisualElement contentContainer = this.contentContainer;
				bool flag2 = contentContainer == null;
				if (flag2)
				{
					throw new InvalidOperationException("You can't add directly to this VisualElement. Use hierarchy.Add() if you know what you're doing.");
				}
				bool flag3 = contentContainer == this;
				if (flag3)
				{
					this.hierarchy.Add(child);
				}
				else if (contentContainer != null)
				{
					contentContainer.Add(child);
				}
				child.m_LogicalParent = this;
			}
		}

		// Token: 0x0600189E RID: 6302 RVA: 0x0005E940 File Offset: 0x0005CB40
		public void Insert(int index, VisualElement element)
		{
			bool flag = element == null;
			if (!flag)
			{
				bool flag2 = this.contentContainer == this;
				if (flag2)
				{
					this.hierarchy.Insert(index, element);
				}
				else
				{
					VisualElement contentContainer = this.contentContainer;
					if (contentContainer != null)
					{
						contentContainer.Insert(index, element);
					}
				}
				element.m_LogicalParent = this;
			}
		}

		// Token: 0x0600189F RID: 6303 RVA: 0x0005E998 File Offset: 0x0005CB98
		public void Remove(VisualElement element)
		{
			bool flag = this.contentContainer == this;
			if (flag)
			{
				this.hierarchy.Remove(element);
			}
			else
			{
				VisualElement contentContainer = this.contentContainer;
				if (contentContainer != null)
				{
					contentContainer.Remove(element);
				}
			}
		}

		// Token: 0x060018A0 RID: 6304 RVA: 0x0005E9DC File Offset: 0x0005CBDC
		public void RemoveAt(int index)
		{
			bool flag = this.contentContainer == this;
			if (flag)
			{
				this.hierarchy.RemoveAt(index);
			}
			else
			{
				VisualElement contentContainer = this.contentContainer;
				if (contentContainer != null)
				{
					contentContainer.RemoveAt(index);
				}
			}
		}

		// Token: 0x060018A1 RID: 6305 RVA: 0x0005EA20 File Offset: 0x0005CC20
		public void Clear()
		{
			bool flag = this.contentContainer == this;
			if (flag)
			{
				this.hierarchy.Clear();
			}
			else
			{
				VisualElement contentContainer = this.contentContainer;
				if (contentContainer != null)
				{
					contentContainer.Clear();
				}
			}
		}

		// Token: 0x060018A2 RID: 6306 RVA: 0x0005EA64 File Offset: 0x0005CC64
		public VisualElement ElementAt(int index)
		{
			return this[index];
		}

		// Token: 0x1700063A RID: 1594
		public VisualElement this[int key]
		{
			get
			{
				bool flag = this.contentContainer == this;
				VisualElement result;
				if (flag)
				{
					result = this.hierarchy[key];
				}
				else
				{
					VisualElement contentContainer = this.contentContainer;
					result = ((contentContainer != null) ? contentContainer[key] : null);
				}
				return result;
			}
		}

		// Token: 0x1700063B RID: 1595
		// (get) Token: 0x060018A4 RID: 6308 RVA: 0x0005EAC8 File Offset: 0x0005CCC8
		public int childCount
		{
			get
			{
				bool flag = this.contentContainer == this;
				int result;
				if (flag)
				{
					result = this.hierarchy.childCount;
				}
				else
				{
					VisualElement contentContainer = this.contentContainer;
					result = ((contentContainer != null) ? contentContainer.childCount : 0);
				}
				return result;
			}
		}

		// Token: 0x060018A5 RID: 6309 RVA: 0x0005EB0C File Offset: 0x0005CD0C
		public int IndexOf(VisualElement element)
		{
			bool flag = this.contentContainer == this;
			int result;
			if (flag)
			{
				result = this.hierarchy.IndexOf(element);
			}
			else
			{
				VisualElement contentContainer = this.contentContainer;
				result = ((contentContainer != null) ? contentContainer.IndexOf(element) : -1);
			}
			return result;
		}

		// Token: 0x060018A6 RID: 6310 RVA: 0x0005EB54 File Offset: 0x0005CD54
		internal VisualElement ElementAtTreePath(List<int> childIndexes)
		{
			VisualElement visualElement = this;
			foreach (int num in childIndexes)
			{
				bool flag = num >= 0 && num < visualElement.hierarchy.childCount;
				if (!flag)
				{
					return null;
				}
				visualElement = visualElement.hierarchy[num];
			}
			return visualElement;
		}

		// Token: 0x060018A7 RID: 6311 RVA: 0x0005EBE4 File Offset: 0x0005CDE4
		internal bool FindElementInTree(VisualElement element, List<int> outChildIndexes)
		{
			VisualElement visualElement = element;
			for (VisualElement parent = visualElement.hierarchy.parent; parent != null; parent = parent.hierarchy.parent)
			{
				outChildIndexes.Insert(0, parent.hierarchy.IndexOf(visualElement));
				bool flag = parent == this;
				if (flag)
				{
					return true;
				}
				visualElement = parent;
			}
			outChildIndexes.Clear();
			return false;
		}

		// Token: 0x060018A8 RID: 6312 RVA: 0x0005EC58 File Offset: 0x0005CE58
		public IEnumerable<VisualElement> Children()
		{
			bool flag = this.contentContainer == this;
			IEnumerable<VisualElement> result;
			if (flag)
			{
				result = this.hierarchy.Children();
			}
			else
			{
				VisualElement contentContainer = this.contentContainer;
				result = (((contentContainer != null) ? contentContainer.Children() : null) ?? VisualElement.s_EmptyList);
			}
			return result;
		}

		// Token: 0x060018A9 RID: 6313 RVA: 0x0005ECA4 File Offset: 0x0005CEA4
		public void Sort(Comparison<VisualElement> comp)
		{
			bool flag = this.contentContainer == this;
			if (flag)
			{
				this.hierarchy.Sort(comp);
			}
			else
			{
				VisualElement contentContainer = this.contentContainer;
				if (contentContainer != null)
				{
					contentContainer.Sort(comp);
				}
			}
		}

		// Token: 0x060018AA RID: 6314 RVA: 0x0005ECE8 File Offset: 0x0005CEE8
		public void BringToFront()
		{
			bool flag = this.hierarchy.parent == null;
			if (!flag)
			{
				this.hierarchy.parent.hierarchy.BringToFront(this);
			}
		}

		// Token: 0x060018AB RID: 6315 RVA: 0x0005ED2C File Offset: 0x0005CF2C
		public void SendToBack()
		{
			bool flag = this.hierarchy.parent == null;
			if (!flag)
			{
				this.hierarchy.parent.hierarchy.SendToBack(this);
			}
		}

		// Token: 0x060018AC RID: 6316 RVA: 0x0005ED70 File Offset: 0x0005CF70
		public void PlaceBehind(VisualElement sibling)
		{
			bool flag = sibling == null;
			if (flag)
			{
				throw new ArgumentNullException("sibling");
			}
			bool flag2 = this.hierarchy.parent == null || sibling.hierarchy.parent != this.hierarchy.parent;
			if (flag2)
			{
				throw new ArgumentException("VisualElements are not siblings");
			}
			this.hierarchy.parent.hierarchy.PlaceBehind(this, sibling);
		}

		// Token: 0x060018AD RID: 6317 RVA: 0x0005EDF4 File Offset: 0x0005CFF4
		public void PlaceInFront(VisualElement sibling)
		{
			bool flag = sibling == null;
			if (flag)
			{
				throw new ArgumentNullException("sibling");
			}
			bool flag2 = this.hierarchy.parent == null || sibling.hierarchy.parent != this.hierarchy.parent;
			if (flag2)
			{
				throw new ArgumentException("VisualElements are not siblings");
			}
			this.hierarchy.parent.hierarchy.PlaceInFront(this, sibling);
		}

		// Token: 0x060018AE RID: 6318 RVA: 0x0005EE78 File Offset: 0x0005D078
		public void RemoveFromHierarchy()
		{
			bool flag = this.hierarchy.parent != null;
			if (flag)
			{
				this.hierarchy.parent.hierarchy.Remove(this);
			}
		}

		// Token: 0x060018AF RID: 6319 RVA: 0x0005EEBC File Offset: 0x0005D0BC
		public T GetFirstOfType<T>() where T : class
		{
			T t = this as T;
			bool flag = t != null;
			T result;
			if (flag)
			{
				result = t;
			}
			else
			{
				result = this.GetFirstAncestorOfType<T>();
			}
			return result;
		}

		// Token: 0x060018B0 RID: 6320 RVA: 0x0005EEF4 File Offset: 0x0005D0F4
		public T GetFirstAncestorOfType<T>() where T : class
		{
			for (VisualElement parent = this.hierarchy.parent; parent != null; parent = parent.hierarchy.parent)
			{
				T t = parent as T;
				bool flag = t != null;
				if (flag)
				{
					return t;
				}
			}
			return default(T);
		}

		// Token: 0x060018B1 RID: 6321 RVA: 0x0005EF60 File Offset: 0x0005D160
		internal VisualElement GetFirstAncestorWhere(Predicate<VisualElement> predicate)
		{
			for (VisualElement parent = this.hierarchy.parent; parent != null; parent = parent.hierarchy.parent)
			{
				bool flag = predicate(parent);
				if (flag)
				{
					return parent;
				}
			}
			return null;
		}

		// Token: 0x060018B2 RID: 6322 RVA: 0x0005EFB0 File Offset: 0x0005D1B0
		public bool Contains(VisualElement child)
		{
			while (child != null)
			{
				bool flag = child.hierarchy.parent == this;
				if (flag)
				{
					return true;
				}
				child = child.hierarchy.parent;
			}
			return false;
		}

		// Token: 0x060018B3 RID: 6323 RVA: 0x0005EFFC File Offset: 0x0005D1FC
		private void GatherAllChildren(List<VisualElement> elements)
		{
			bool flag = this.m_Children.Count > 0;
			if (flag)
			{
				int i = elements.Count;
				elements.AddRange(this.m_Children);
				while (i < elements.Count)
				{
					VisualElement visualElement = elements[i];
					elements.AddRange(visualElement.m_Children);
					i++;
				}
			}
		}

		// Token: 0x060018B4 RID: 6324 RVA: 0x0005F05C File Offset: 0x0005D25C
		public VisualElement FindCommonAncestor(VisualElement other)
		{
			bool flag = other == null;
			if (flag)
			{
				throw new ArgumentNullException("other");
			}
			bool flag2 = this.panel != other.panel;
			VisualElement result;
			if (flag2)
			{
				result = null;
			}
			else
			{
				VisualElement visualElement = this;
				int i = 0;
				while (visualElement != null)
				{
					i++;
					visualElement = visualElement.hierarchy.parent;
				}
				VisualElement visualElement2 = other;
				int j = 0;
				while (visualElement2 != null)
				{
					j++;
					visualElement2 = visualElement2.hierarchy.parent;
				}
				visualElement = this;
				visualElement2 = other;
				while (i > j)
				{
					i--;
					visualElement = visualElement.hierarchy.parent;
				}
				while (j > i)
				{
					j--;
					visualElement2 = visualElement2.hierarchy.parent;
				}
				while (visualElement != visualElement2)
				{
					visualElement = visualElement.hierarchy.parent;
					visualElement2 = visualElement2.hierarchy.parent;
				}
				result = visualElement;
			}
			return result;
		}

		// Token: 0x060018B5 RID: 6325 RVA: 0x0005F16C File Offset: 0x0005D36C
		internal VisualElement GetRoot()
		{
			bool flag = this.panel != null;
			VisualElement result;
			if (flag)
			{
				result = this.panel.visualTree;
			}
			else
			{
				VisualElement visualElement = this;
				while (visualElement.m_PhysicalParent != null)
				{
					visualElement = visualElement.m_PhysicalParent;
				}
				result = visualElement;
			}
			return result;
		}

		// Token: 0x060018B6 RID: 6326 RVA: 0x0005F1B8 File Offset: 0x0005D3B8
		internal VisualElement GetRootVisualContainer()
		{
			VisualElement result = null;
			for (VisualElement visualElement = this; visualElement != null; visualElement = visualElement.hierarchy.parent)
			{
				bool isRootVisualContainer = visualElement.isRootVisualContainer;
				if (isRootVisualContainer)
				{
					result = visualElement;
				}
			}
			return result;
		}

		// Token: 0x060018B7 RID: 6327 RVA: 0x0005F1FC File Offset: 0x0005D3FC
		internal VisualElement GetNextElementDepthFirst()
		{
			bool flag = this.m_Children.Count > 0;
			VisualElement result;
			if (flag)
			{
				result = this.m_Children[0];
			}
			else
			{
				VisualElement physicalParent = this.m_PhysicalParent;
				VisualElement visualElement = this;
				while (physicalParent != null)
				{
					int i;
					for (i = 0; i < physicalParent.m_Children.Count; i++)
					{
						bool flag2 = physicalParent.m_Children[i] == visualElement;
						if (flag2)
						{
							break;
						}
					}
					bool flag3 = i < physicalParent.m_Children.Count - 1;
					if (flag3)
					{
						return physicalParent.m_Children[i + 1];
					}
					visualElement = physicalParent;
					physicalParent = physicalParent.m_PhysicalParent;
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060018B8 RID: 6328 RVA: 0x0005F2BC File Offset: 0x0005D4BC
		internal VisualElement GetPreviousElementDepthFirst()
		{
			bool flag = this.m_PhysicalParent != null;
			VisualElement result;
			if (flag)
			{
				int i;
				for (i = 0; i < this.m_PhysicalParent.m_Children.Count; i++)
				{
					bool flag2 = this.m_PhysicalParent.m_Children[i] == this;
					if (flag2)
					{
						break;
					}
				}
				bool flag3 = i > 0;
				if (flag3)
				{
					VisualElement visualElement = this.m_PhysicalParent.m_Children[i - 1];
					while (visualElement.m_Children.Count > 0)
					{
						visualElement = visualElement.m_Children[visualElement.m_Children.Count - 1];
					}
					result = visualElement;
				}
				else
				{
					result = this.m_PhysicalParent;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060018B9 RID: 6329 RVA: 0x0005F384 File Offset: 0x0005D584
		internal VisualElement RetargetElement(VisualElement retargetAgainst)
		{
			bool flag = retargetAgainst == null;
			VisualElement result;
			if (flag)
			{
				result = this;
			}
			else
			{
				VisualElement visualElement = retargetAgainst.m_PhysicalParent ?? retargetAgainst;
				while (visualElement.m_PhysicalParent != null && !visualElement.isCompositeRoot)
				{
					visualElement = visualElement.m_PhysicalParent;
				}
				VisualElement result2 = this;
				VisualElement physicalParent = this.m_PhysicalParent;
				while (physicalParent != null)
				{
					physicalParent = physicalParent.m_PhysicalParent;
					bool flag2 = physicalParent == visualElement;
					if (flag2)
					{
						return result2;
					}
					bool flag3 = physicalParent != null && physicalParent.isCompositeRoot;
					if (flag3)
					{
						result2 = physicalParent;
					}
				}
				result = this;
			}
			return result;
		}

		// Token: 0x1700063C RID: 1596
		// (get) Token: 0x060018BA RID: 6330 RVA: 0x0005F41C File Offset: 0x0005D61C
		private Vector3 positionWithLayout
		{
			get
			{
				return this.ResolveTranslate() + this.layout.min;
			}
		}

		// Token: 0x060018BB RID: 6331 RVA: 0x0005F44C File Offset: 0x0005D64C
		internal void GetPivotedMatrixWithLayout(out Matrix4x4 result)
		{
			Vector3 vector = this.ResolveTransformOrigin();
			result = Matrix4x4.TRS(this.positionWithLayout + vector, this.ResolveRotation(), this.ResolveScale());
			VisualElement.TranslateMatrix34InPlace(ref result, -vector);
		}

		// Token: 0x1700063D RID: 1597
		// (get) Token: 0x060018BC RID: 6332 RVA: 0x0005F494 File Offset: 0x0005D694
		internal bool hasDefaultRotationAndScale
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.computedStyle.rotate.angle.value == 0f && this.computedStyle.scale.value == Vector3.one;
			}
		}

		// Token: 0x060018BD RID: 6333 RVA: 0x0005F4E8 File Offset: 0x0005D6E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static float Min(float a, float b, float c, float d)
		{
			return Mathf.Min(Mathf.Min(a, b), Mathf.Min(c, d));
		}

		// Token: 0x060018BE RID: 6334 RVA: 0x0005F510 File Offset: 0x0005D710
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static float Max(float a, float b, float c, float d)
		{
			return Mathf.Max(Mathf.Max(a, b), Mathf.Max(c, d));
		}

		// Token: 0x060018BF RID: 6335 RVA: 0x0005F538 File Offset: 0x0005D738
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void TransformAlignedRectToParentSpace(ref Rect rect)
		{
			bool hasDefaultRotationAndScale = this.hasDefaultRotationAndScale;
			if (hasDefaultRotationAndScale)
			{
				rect.position += this.positionWithLayout;
			}
			else
			{
				Matrix4x4 matrix4x;
				this.GetPivotedMatrixWithLayout(out matrix4x);
				rect = VisualElement.CalculateConservativeRect(ref matrix4x, rect);
			}
		}

		// Token: 0x060018C0 RID: 6336 RVA: 0x0005F590 File Offset: 0x0005D790
		internal static Rect CalculateConservativeRect(ref Matrix4x4 matrix, Rect rect)
		{
			bool flag = float.IsNaN(rect.height) | float.IsNaN(rect.width) | float.IsNaN(rect.x) | float.IsNaN(rect.y);
			Rect result;
			if (flag)
			{
				rect = new Rect(VisualElement.MultiplyMatrix44Point2(ref matrix, rect.position), VisualElement.MultiplyVector2(ref matrix, rect.size));
				VisualElement.OrderMinMaxRect(ref rect);
				result = rect;
			}
			else
			{
				Vector2 v = new Vector2(rect.xMin, rect.yMin);
				Vector2 v2 = new Vector2(rect.xMax, rect.yMax);
				Vector2 v3 = new Vector2(rect.xMax, rect.yMin);
				Vector2 v4 = new Vector2(rect.xMin, rect.yMax);
				Vector3 vector = matrix.MultiplyPoint3x4(v);
				Vector3 vector2 = matrix.MultiplyPoint3x4(v2);
				Vector3 vector3 = matrix.MultiplyPoint3x4(v3);
				Vector3 vector4 = matrix.MultiplyPoint3x4(v4);
				Vector2 vector5 = new Vector2(VisualElement.Min(vector.x, vector2.x, vector3.x, vector4.x), VisualElement.Min(vector.y, vector2.y, vector3.y, vector4.y));
				Vector2 vector6 = new Vector2(VisualElement.Max(vector.x, vector2.x, vector3.x, vector4.x), VisualElement.Max(vector.y, vector2.y, vector3.y, vector4.y));
				result = new Rect(vector5.x, vector5.y, vector6.x - vector5.x, vector6.y - vector5.y);
			}
			return result;
		}

		// Token: 0x060018C1 RID: 6337 RVA: 0x0005F75E File Offset: 0x0005D95E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void TransformAlignedRect(ref Matrix4x4 matrix, ref Rect rect)
		{
			rect = VisualElement.CalculateConservativeRect(ref matrix, rect);
		}

		// Token: 0x060018C2 RID: 6338 RVA: 0x0005F774 File Offset: 0x0005D974
		internal static void OrderMinMaxRect(ref Rect rect)
		{
			bool flag = rect.width < 0f;
			if (flag)
			{
				rect.x += rect.width;
				rect.width = -rect.width;
			}
			bool flag2 = rect.height < 0f;
			if (flag2)
			{
				rect.y += rect.height;
				rect.height = -rect.height;
			}
		}

		// Token: 0x060018C3 RID: 6339 RVA: 0x0005F7EC File Offset: 0x0005D9EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Vector2 MultiplyMatrix44Point2(ref Matrix4x4 lhs, Vector2 point)
		{
			Vector2 result;
			result.x = lhs.m00 * point.x + lhs.m01 * point.y + lhs.m03;
			result.y = lhs.m10 * point.x + lhs.m11 * point.y + lhs.m13;
			return result;
		}

		// Token: 0x060018C4 RID: 6340 RVA: 0x0005F854 File Offset: 0x0005DA54
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Vector2 MultiplyVector2(ref Matrix4x4 lhs, Vector2 vector)
		{
			Vector2 result;
			result.x = lhs.m00 * vector.x + lhs.m01 * vector.y;
			result.y = lhs.m10 * vector.x + lhs.m11 * vector.y;
			return result;
		}

		// Token: 0x060018C5 RID: 6341 RVA: 0x0005F8AC File Offset: 0x0005DAAC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Rect MultiplyMatrix44Rect2(ref Matrix4x4 lhs, Rect r)
		{
			r.position = VisualElement.MultiplyMatrix44Point2(ref lhs, r.position);
			r.size = VisualElement.MultiplyVector2(ref lhs, r.size);
			return r;
		}

		// Token: 0x060018C6 RID: 6342 RVA: 0x0005F8EC File Offset: 0x0005DAEC
		internal static void MultiplyMatrix34(ref Matrix4x4 lhs, ref Matrix4x4 rhs, out Matrix4x4 res)
		{
			res.m00 = lhs.m00 * rhs.m00 + lhs.m01 * rhs.m10 + lhs.m02 * rhs.m20;
			res.m01 = lhs.m00 * rhs.m01 + lhs.m01 * rhs.m11 + lhs.m02 * rhs.m21;
			res.m02 = lhs.m00 * rhs.m02 + lhs.m01 * rhs.m12 + lhs.m02 * rhs.m22;
			res.m03 = lhs.m00 * rhs.m03 + lhs.m01 * rhs.m13 + lhs.m02 * rhs.m23 + lhs.m03;
			res.m10 = lhs.m10 * rhs.m00 + lhs.m11 * rhs.m10 + lhs.m12 * rhs.m20;
			res.m11 = lhs.m10 * rhs.m01 + lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21;
			res.m12 = lhs.m10 * rhs.m02 + lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22;
			res.m13 = lhs.m10 * rhs.m03 + lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13;
			res.m20 = lhs.m20 * rhs.m00 + lhs.m21 * rhs.m10 + lhs.m22 * rhs.m20;
			res.m21 = lhs.m20 * rhs.m01 + lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21;
			res.m22 = lhs.m20 * rhs.m02 + lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22;
			res.m23 = lhs.m20 * rhs.m03 + lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23;
			res.m30 = 0f;
			res.m31 = 0f;
			res.m32 = 0f;
			res.m33 = 1f;
		}

		// Token: 0x060018C7 RID: 6343 RVA: 0x0005FB6F File Offset: 0x0005DD6F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void TranslateMatrix34(ref Matrix4x4 lhs, Vector3 rhs, out Matrix4x4 res)
		{
			res = lhs;
			VisualElement.TranslateMatrix34InPlace(ref res, rhs);
		}

		// Token: 0x060018C8 RID: 6344 RVA: 0x0005FB88 File Offset: 0x0005DD88
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void TranslateMatrix34InPlace(ref Matrix4x4 lhs, Vector3 rhs)
		{
			lhs.m03 += lhs.m00 * rhs.x + lhs.m01 * rhs.y + lhs.m02 * rhs.z;
			lhs.m13 += lhs.m10 * rhs.x + lhs.m11 * rhs.y + lhs.m12 * rhs.z;
			lhs.m23 += lhs.m20 * rhs.x + lhs.m21 * rhs.y + lhs.m22 * rhs.z;
		}

		// Token: 0x1700063E RID: 1598
		// (get) Token: 0x060018C9 RID: 6345 RVA: 0x0005FC30 File Offset: 0x0005DE30
		public IVisualElementScheduler schedule
		{
			get
			{
				return this;
			}
		}

		// Token: 0x060018CA RID: 6346 RVA: 0x0005FC44 File Offset: 0x0005DE44
		IVisualElementScheduledItem IVisualElementScheduler.Execute(Action<TimerState> timerUpdateEvent)
		{
			VisualElement.TimerStateScheduledItem timerStateScheduledItem = new VisualElement.TimerStateScheduledItem(this, timerUpdateEvent)
			{
				timerUpdateStopCondition = ScheduledItem.OnceCondition
			};
			timerStateScheduledItem.Resume();
			return timerStateScheduledItem;
		}

		// Token: 0x060018CB RID: 6347 RVA: 0x0005FC74 File Offset: 0x0005DE74
		IVisualElementScheduledItem IVisualElementScheduler.Execute(Action updateEvent)
		{
			VisualElement.SimpleScheduledItem simpleScheduledItem = new VisualElement.SimpleScheduledItem(this, updateEvent)
			{
				timerUpdateStopCondition = ScheduledItem.OnceCondition
			};
			simpleScheduledItem.Resume();
			return simpleScheduledItem;
		}

		// Token: 0x1700063F RID: 1599
		// (get) Token: 0x060018CC RID: 6348 RVA: 0x0005FCA4 File Offset: 0x0005DEA4
		public IStyle style
		{
			get
			{
				bool flag = this.inlineStyleAccess == null;
				if (flag)
				{
					this.inlineStyleAccess = new InlineStyleAccess(this);
				}
				return this.inlineStyleAccess;
			}
		}

		// Token: 0x17000640 RID: 1600
		// (get) Token: 0x060018CD RID: 6349 RVA: 0x0005FCD8 File Offset: 0x0005DED8
		public ICustomStyle customStyle
		{
			get
			{
				VisualElement.s_CustomStyleAccess.SetContext(this.computedStyle.customProperties, this.computedStyle.dpiScaling);
				return VisualElement.s_CustomStyleAccess;
			}
		}

		// Token: 0x17000641 RID: 1601
		// (get) Token: 0x060018CE RID: 6350 RVA: 0x0005FD10 File Offset: 0x0005DF10
		public VisualElementStyleSheetSet styleSheets
		{
			get
			{
				return new VisualElementStyleSheetSet(this);
			}
		}

		// Token: 0x060018CF RID: 6351 RVA: 0x0005FD18 File Offset: 0x0005DF18
		internal void AddStyleSheetPath(string sheetPath)
		{
			StyleSheet styleSheet = Panel.LoadResource(sheetPath, typeof(StyleSheet), this.scaledPixelsPerPoint) as StyleSheet;
			bool flag = styleSheet == null;
			if (flag)
			{
				bool flag2 = !VisualElement.s_InternalStyleSheetPath.IsMatch(sheetPath);
				if (flag2)
				{
					Debug.LogWarning(string.Format("Style sheet not found for path \"{0}\"", sheetPath));
				}
			}
			else
			{
				this.styleSheets.Add(styleSheet);
			}
		}

		// Token: 0x060018D0 RID: 6352 RVA: 0x0005FD88 File Offset: 0x0005DF88
		internal bool HasStyleSheetPath(string sheetPath)
		{
			StyleSheet styleSheet = Panel.LoadResource(sheetPath, typeof(StyleSheet), this.scaledPixelsPerPoint) as StyleSheet;
			bool flag = styleSheet == null;
			bool result;
			if (flag)
			{
				Debug.LogWarning(string.Format("Style sheet not found for path \"{0}\"", sheetPath));
				result = false;
			}
			else
			{
				result = this.styleSheets.Contains(styleSheet);
			}
			return result;
		}

		// Token: 0x060018D1 RID: 6353 RVA: 0x0005FDE8 File Offset: 0x0005DFE8
		internal void RemoveStyleSheetPath(string sheetPath)
		{
			StyleSheet styleSheet = Panel.LoadResource(sheetPath, typeof(StyleSheet), this.scaledPixelsPerPoint) as StyleSheet;
			bool flag = styleSheet == null;
			if (flag)
			{
				Debug.LogWarning(string.Format("Style sheet not found for path \"{0}\"", sheetPath));
			}
			else
			{
				this.styleSheets.Remove(styleSheet);
			}
		}

		// Token: 0x060018D2 RID: 6354 RVA: 0x0005FE44 File Offset: 0x0005E044
		private StyleFloat ResolveLengthValue(Length length, bool isRow)
		{
			bool flag = length.IsAuto();
			StyleFloat result;
			if (flag)
			{
				result = new StyleFloat(StyleKeyword.Auto);
			}
			else
			{
				bool flag2 = length.IsNone();
				if (flag2)
				{
					result = new StyleFloat(StyleKeyword.None);
				}
				else
				{
					bool flag3 = length.unit != LengthUnit.Percent;
					if (flag3)
					{
						result = new StyleFloat(length.value);
					}
					else
					{
						VisualElement parent = this.hierarchy.parent;
						bool flag4 = parent == null;
						if (flag4)
						{
							result = 0f;
						}
						else
						{
							float num = isRow ? parent.resolvedStyle.width : parent.resolvedStyle.height;
							result = length.value * num / 100f;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060018D3 RID: 6355 RVA: 0x0005FEFC File Offset: 0x0005E0FC
		private Vector3 ResolveTranslate()
		{
			Translate translate = this.computedStyle.translate;
			Length x = translate.x;
			bool flag = x.unit == LengthUnit.Percent;
			float num;
			if (flag)
			{
				float width = this.resolvedStyle.width;
				num = (float.IsNaN(width) ? 0f : (width * x.value / 100f));
			}
			else
			{
				num = x.value;
				num = (float.IsNaN(num) ? 0f : num);
			}
			Length y = translate.y;
			bool flag2 = y.unit == LengthUnit.Percent;
			float num2;
			if (flag2)
			{
				float height = this.resolvedStyle.height;
				num2 = (float.IsNaN(height) ? 0f : (height * y.value / 100f));
			}
			else
			{
				num2 = y.value;
				num2 = (float.IsNaN(num2) ? 0f : num2);
			}
			float num3 = translate.z;
			num3 = (float.IsNaN(num3) ? 0f : num3);
			return new Vector3(num, num2, num3);
		}

		// Token: 0x060018D4 RID: 6356 RVA: 0x00060010 File Offset: 0x0005E210
		private Vector3 ResolveTransformOrigin()
		{
			TransformOrigin transformOrigin = this.computedStyle.transformOrigin;
			Length x = transformOrigin.x;
			bool flag = x.IsNone();
			float x2;
			if (flag)
			{
				float width = this.resolvedStyle.width;
				x2 = (float.IsNaN(width) ? 0f : (width / 2f));
			}
			else
			{
				bool flag2 = x.unit == LengthUnit.Percent;
				if (flag2)
				{
					float width2 = this.resolvedStyle.width;
					x2 = (float.IsNaN(width2) ? 0f : (width2 * x.value / 100f));
				}
				else
				{
					x2 = x.value;
				}
			}
			Length y = transformOrigin.y;
			bool flag3 = y.IsNone();
			float y2;
			if (flag3)
			{
				float height = this.resolvedStyle.height;
				y2 = (float.IsNaN(height) ? 0f : (height / 2f));
			}
			else
			{
				bool flag4 = y.unit == LengthUnit.Percent;
				if (flag4)
				{
					float height2 = this.resolvedStyle.height;
					y2 = (float.IsNaN(height2) ? 0f : (height2 * y.value / 100f));
				}
				else
				{
					y2 = y.value;
				}
			}
			float z = transformOrigin.z;
			return new Vector3(x2, y2, z);
		}

		// Token: 0x060018D5 RID: 6357 RVA: 0x00060168 File Offset: 0x0005E368
		private Quaternion ResolveRotation()
		{
			Rotate rotate = this.computedStyle.rotate;
			Vector3 axis = rotate.axis;
			bool flag = float.IsNaN(rotate.angle.value) || float.IsNaN(axis.x) || float.IsNaN(axis.y) || float.IsNaN(axis.z);
			if (flag)
			{
				rotate = Rotate.Initial();
			}
			return rotate.ToQuaternion();
		}

		// Token: 0x060018D6 RID: 6358 RVA: 0x000601E0 File Offset: 0x0005E3E0
		private Vector3 ResolveScale()
		{
			Vector3 value = this.computedStyle.scale.value;
			return (float.IsNaN(value.x) || float.IsNaN(value.y) || float.IsNaN(value.z)) ? Vector3.one : value;
		}

		// Token: 0x17000642 RID: 1602
		// (get) Token: 0x060018D7 RID: 6359 RVA: 0x00060238 File Offset: 0x0005E438
		// (set) Token: 0x060018D8 RID: 6360 RVA: 0x00060268 File Offset: 0x0005E468
		public string tooltip
		{
			get
			{
				string text = this.GetProperty(VisualElement.tooltipPropertyKey) as string;
				return text ?? string.Empty;
			}
			set
			{
				bool flag = !this.HasProperty(VisualElement.tooltipPropertyKey);
				if (flag)
				{
					bool flag2 = string.IsNullOrEmpty(value);
					if (flag2)
					{
						return;
					}
					base.RegisterCallback<TooltipEvent>(new EventCallback<TooltipEvent>(this.SetTooltip), TrickleDown.NoTrickleDown);
				}
				this.SetProperty(VisualElement.tooltipPropertyKey, value);
			}
		}

		// Token: 0x060018D9 RID: 6361 RVA: 0x000602B8 File Offset: 0x0005E4B8
		internal static VisualElement.TypeData GetOrCreateTypeData(Type t)
		{
			VisualElement.TypeData typeData;
			bool flag = !VisualElement.s_TypeData.TryGetValue(t, out typeData);
			if (flag)
			{
				typeData = new VisualElement.TypeData(t);
				VisualElement.s_TypeData.Add(t, typeData);
			}
			return typeData;
		}

		// Token: 0x17000643 RID: 1603
		// (get) Token: 0x060018DA RID: 6362 RVA: 0x000602F8 File Offset: 0x0005E4F8
		private VisualElement.TypeData typeData
		{
			get
			{
				bool flag = this.m_TypeData == null;
				if (flag)
				{
					Type type = base.GetType();
					bool flag2 = !VisualElement.s_TypeData.TryGetValue(type, out this.m_TypeData);
					if (flag2)
					{
						this.m_TypeData = new VisualElement.TypeData(type);
						VisualElement.s_TypeData.Add(type, this.m_TypeData);
					}
				}
				return this.m_TypeData;
			}
		}

		// Token: 0x040009EE RID: 2542
		private static uint s_NextId;

		// Token: 0x040009EF RID: 2543
		private static List<string> s_EmptyClassList = new List<string>(0);

		// Token: 0x040009F0 RID: 2544
		internal static readonly PropertyName userDataPropertyKey = new PropertyName("--unity-user-data");

		// Token: 0x040009F1 RID: 2545
		public static readonly string disabledUssClassName = "unity-disabled";

		// Token: 0x040009F2 RID: 2546
		private string m_Name;

		// Token: 0x040009F3 RID: 2547
		private List<string> m_ClassList;

		// Token: 0x040009F4 RID: 2548
		private List<KeyValuePair<PropertyName, object>> m_PropertyBag;

		// Token: 0x040009F5 RID: 2549
		internal VisualElementFlags m_Flags;

		// Token: 0x040009F6 RID: 2550
		private string m_ViewDataKey;

		// Token: 0x040009F7 RID: 2551
		private RenderHints m_RenderHints;

		// Token: 0x040009F8 RID: 2552
		internal Rect lastLayout;

		// Token: 0x040009F9 RID: 2553
		internal Rect lastPseudoPadding;

		// Token: 0x040009FA RID: 2554
		internal RenderChainVEData renderChainData;

		// Token: 0x040009FB RID: 2555
		private Rect m_Layout;

		// Token: 0x040009FC RID: 2556
		private Rect m_BoundingBox;

		// Token: 0x040009FD RID: 2557
		private const VisualElementFlags worldBoundingBoxDirtyDependencies = VisualElementFlags.WorldTransformDirty | VisualElementFlags.BoundingBoxDirty | VisualElementFlags.WorldBoundingBoxDirty;

		// Token: 0x040009FE RID: 2558
		private Rect m_WorldBoundingBox;

		// Token: 0x040009FF RID: 2559
		private const VisualElementFlags worldTransformInverseDirtyDependencies = VisualElementFlags.WorldTransformDirty | VisualElementFlags.WorldTransformInverseDirty;

		// Token: 0x04000A00 RID: 2560
		private Matrix4x4 m_WorldTransformCache = Matrix4x4.identity;

		// Token: 0x04000A01 RID: 2561
		private Matrix4x4 m_WorldTransformInverseCache = Matrix4x4.identity;

		// Token: 0x04000A02 RID: 2562
		private Rect m_WorldClip = Rect.zero;

		// Token: 0x04000A03 RID: 2563
		private Rect m_WorldClipMinusGroup = Rect.zero;

		// Token: 0x04000A04 RID: 2564
		private bool m_WorldClipIsInfinite = false;

		// Token: 0x04000A05 RID: 2565
		internal static readonly Rect s_InfiniteRect = new Rect(-10000f, -10000f, 40000f, 40000f);

		// Token: 0x04000A06 RID: 2566
		internal PseudoStates triggerPseudoMask;

		// Token: 0x04000A07 RID: 2567
		internal PseudoStates dependencyPseudoMask;

		// Token: 0x04000A08 RID: 2568
		private PseudoStates m_PseudoStates;

		// Token: 0x04000A0A RID: 2570
		private PickingMode m_PickingMode;

		// Token: 0x04000A0C RID: 2572
		internal ComputedStyle m_Style = InitialStyle.Acquire();

		// Token: 0x04000A0D RID: 2573
		internal StyleVariableContext variableContext = StyleVariableContext.none;

		// Token: 0x04000A0E RID: 2574
		internal int inheritedStylesHash = 0;

		// Token: 0x04000A0F RID: 2575
		internal readonly uint controlid;

		// Token: 0x04000A10 RID: 2576
		internal int imguiContainerDescendantCount = 0;

		// Token: 0x04000A12 RID: 2578
		private LanguageDirection m_LanguageDirection;

		// Token: 0x04000A13 RID: 2579
		private LanguageDirection m_LocalLanguageDirection;

		// Token: 0x04000A15 RID: 2581
		private static readonly ProfilerMarker k_GenerateVisualContentMarker = new ProfilerMarker("GenerateVisualContent");

		// Token: 0x04000A16 RID: 2582
		private VisualElement.RenderTargetMode m_SubRenderTargetMode = VisualElement.RenderTargetMode.None;

		// Token: 0x04000A17 RID: 2583
		private static Material s_runtimeMaterial;

		// Token: 0x04000A18 RID: 2584
		private Material m_defaultMaterial;

		// Token: 0x04000A19 RID: 2585
		private List<IValueAnimationUpdate> m_RunningAnimations;

		// Token: 0x04000A1A RID: 2586
		private static uint s_NextParentVersion;

		// Token: 0x04000A1B RID: 2587
		private uint m_NextParentCachedVersion;

		// Token: 0x04000A1C RID: 2588
		private uint m_NextParentRequiredVersion;

		// Token: 0x04000A1D RID: 2589
		private VisualElement m_CachedNextParentWithEventCallback;

		// Token: 0x04000A1E RID: 2590
		private int m_EventCallbackCategories = 0;

		// Token: 0x04000A1F RID: 2591
		private int m_CachedEventCallbackParentCategories = 0;

		// Token: 0x04000A20 RID: 2592
		private readonly int m_DefaultActionEventCategories;

		// Token: 0x04000A21 RID: 2593
		private readonly int m_DefaultActionAtTargetEventCategories;

		// Token: 0x04000A22 RID: 2594
		internal const string k_RootVisualContainerName = "rootVisualContainer";

		// Token: 0x04000A26 RID: 2598
		private VisualElement m_PhysicalParent;

		// Token: 0x04000A27 RID: 2599
		private VisualElement m_LogicalParent;

		// Token: 0x04000A28 RID: 2600
		private static readonly List<VisualElement> s_EmptyList = new List<VisualElement>();

		// Token: 0x04000A29 RID: 2601
		private List<VisualElement> m_Children;

		// Token: 0x04000A2B RID: 2603
		private VisualTreeAsset m_VisualTreeAssetSource = null;

		// Token: 0x04000A2C RID: 2604
		internal static VisualElement.CustomStyleAccess s_CustomStyleAccess = new VisualElement.CustomStyleAccess();

		// Token: 0x04000A2D RID: 2605
		internal InlineStyleAccess inlineStyleAccess;

		// Token: 0x04000A2E RID: 2606
		internal List<StyleSheet> styleSheetList;

		// Token: 0x04000A2F RID: 2607
		private static readonly Regex s_InternalStyleSheetPath = new Regex("^instanceId:[-0-9]+$", RegexOptions.Compiled);

		// Token: 0x04000A30 RID: 2608
		internal static readonly PropertyName tooltipPropertyKey = new PropertyName("--unity-tooltip");

		// Token: 0x04000A31 RID: 2609
		private static readonly Dictionary<Type, VisualElement.TypeData> s_TypeData = new Dictionary<Type, VisualElement.TypeData>();

		// Token: 0x04000A32 RID: 2610
		private VisualElement.TypeData m_TypeData;

		// Token: 0x020002D6 RID: 726
		public class UxmlFactory : UxmlFactory<VisualElement, VisualElement.UxmlTraits>
		{
		}

		// Token: 0x020002D7 RID: 727
		public class UxmlTraits : UnityEngine.UIElements.UxmlTraits
		{
			// Token: 0x17000644 RID: 1604
			// (get) Token: 0x060018DE RID: 6366 RVA: 0x00060413 File Offset: 0x0005E613
			// (set) Token: 0x060018DF RID: 6367 RVA: 0x0006041B File Offset: 0x0005E61B
			protected UxmlIntAttributeDescription focusIndex { get; set; } = new UxmlIntAttributeDescription
			{
				name = null,
				obsoleteNames = new string[]
				{
					"focus-index",
					"focusIndex"
				},
				defaultValue = -1
			};

			// Token: 0x17000645 RID: 1605
			// (get) Token: 0x060018E0 RID: 6368 RVA: 0x00060424 File Offset: 0x0005E624
			// (set) Token: 0x060018E1 RID: 6369 RVA: 0x0006042C File Offset: 0x0005E62C
			protected UxmlBoolAttributeDescription focusable { get; set; } = new UxmlBoolAttributeDescription
			{
				name = "focusable",
				defaultValue = false
			};

			// Token: 0x17000646 RID: 1606
			// (get) Token: 0x060018E2 RID: 6370 RVA: 0x00060438 File Offset: 0x0005E638
			public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
			{
				get
				{
					yield return new UxmlChildElementDescription(typeof(VisualElement));
					yield break;
				}
			}

			// Token: 0x060018E3 RID: 6371 RVA: 0x00060458 File Offset: 0x0005E658
			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				base.Init(ve, bag, cc);
				bool flag = ve == null;
				if (flag)
				{
					throw new ArgumentNullException("ve");
				}
				ve.name = this.m_Name.GetValueFromBag(bag, cc);
				ve.viewDataKey = this.m_ViewDataKey.GetValueFromBag(bag, cc);
				ve.pickingMode = this.m_PickingMode.GetValueFromBag(bag, cc);
				ve.usageHints = this.m_UsageHints.GetValueFromBag(bag, cc);
				ve.tooltip = this.m_Tooltip.GetValueFromBag(bag, cc);
				int num = 0;
				bool flag2 = this.focusIndex.TryGetValueFromBag(bag, cc, ref num);
				if (flag2)
				{
					ve.tabIndex = ((num >= 0) ? num : 0);
					ve.focusable = (num >= 0);
				}
				ve.tabIndex = this.m_TabIndex.GetValueFromBag(bag, cc);
				ve.focusable = this.focusable.GetValueFromBag(bag, cc);
			}

			// Token: 0x04000A33 RID: 2611
			protected UxmlStringAttributeDescription m_Name = new UxmlStringAttributeDescription
			{
				name = "name"
			};

			// Token: 0x04000A34 RID: 2612
			private UxmlStringAttributeDescription m_ViewDataKey = new UxmlStringAttributeDescription
			{
				name = "view-data-key"
			};

			// Token: 0x04000A35 RID: 2613
			protected UxmlEnumAttributeDescription<PickingMode> m_PickingMode = new UxmlEnumAttributeDescription<PickingMode>
			{
				name = "picking-mode",
				obsoleteNames = new string[]
				{
					"pickingMode"
				}
			};

			// Token: 0x04000A36 RID: 2614
			private UxmlStringAttributeDescription m_Tooltip = new UxmlStringAttributeDescription
			{
				name = "tooltip"
			};

			// Token: 0x04000A37 RID: 2615
			private UxmlEnumAttributeDescription<UsageHints> m_UsageHints = new UxmlEnumAttributeDescription<UsageHints>
			{
				name = "usage-hints"
			};

			// Token: 0x04000A39 RID: 2617
			private UxmlIntAttributeDescription m_TabIndex = new UxmlIntAttributeDescription
			{
				name = "tabindex",
				defaultValue = 0
			};

			// Token: 0x04000A3B RID: 2619
			private UxmlStringAttributeDescription m_Class = new UxmlStringAttributeDescription
			{
				name = "class"
			};

			// Token: 0x04000A3C RID: 2620
			private UxmlStringAttributeDescription m_ContentContainer = new UxmlStringAttributeDescription
			{
				name = "content-container",
				obsoleteNames = new string[]
				{
					"contentContainer"
				}
			};

			// Token: 0x04000A3D RID: 2621
			private UxmlStringAttributeDescription m_Style = new UxmlStringAttributeDescription
			{
				name = "style"
			};
		}

		// Token: 0x020002D9 RID: 729
		public enum MeasureMode
		{
			// Token: 0x04000A43 RID: 2627
			Undefined,
			// Token: 0x04000A44 RID: 2628
			Exactly,
			// Token: 0x04000A45 RID: 2629
			AtMost
		}

		// Token: 0x020002DA RID: 730
		internal enum RenderTargetMode
		{
			// Token: 0x04000A47 RID: 2631
			None,
			// Token: 0x04000A48 RID: 2632
			NoColorConversion,
			// Token: 0x04000A49 RID: 2633
			LinearToGamma,
			// Token: 0x04000A4A RID: 2634
			GammaToLinear
		}

		// Token: 0x020002DB RID: 731
		public struct Hierarchy
		{
			// Token: 0x17000649 RID: 1609
			// (get) Token: 0x060018ED RID: 6381 RVA: 0x0006077C File Offset: 0x0005E97C
			public VisualElement parent
			{
				get
				{
					return this.m_Owner.m_PhysicalParent;
				}
			}

			// Token: 0x1700064A RID: 1610
			// (get) Token: 0x060018EE RID: 6382 RVA: 0x00060799 File Offset: 0x0005E999
			internal List<VisualElement> children
			{
				get
				{
					return this.m_Owner.m_Children;
				}
			}

			// Token: 0x060018EF RID: 6383 RVA: 0x000607A6 File Offset: 0x0005E9A6
			internal Hierarchy(VisualElement element)
			{
				this.m_Owner = element;
			}

			// Token: 0x060018F0 RID: 6384 RVA: 0x000607B0 File Offset: 0x0005E9B0
			public void Add(VisualElement child)
			{
				bool flag = child == null;
				if (flag)
				{
					throw new ArgumentException("Cannot add null child");
				}
				this.Insert(this.childCount, child);
			}

			// Token: 0x060018F1 RID: 6385 RVA: 0x000607E0 File Offset: 0x0005E9E0
			public void Insert(int index, VisualElement child)
			{
				bool flag = child == null;
				if (flag)
				{
					throw new ArgumentException("Cannot insert null child");
				}
				bool flag2 = index > this.childCount;
				if (flag2)
				{
					throw new ArgumentOutOfRangeException("Index out of range: " + index.ToString());
				}
				bool flag3 = child == this.m_Owner;
				if (flag3)
				{
					throw new ArgumentException("Cannot insert element as its own child");
				}
				bool flag4 = this.m_Owner.elementPanel != null && this.m_Owner.elementPanel.duringLayoutPhase;
				if (flag4)
				{
					throw new InvalidOperationException("Cannot modify VisualElement hierarchy during layout calculation");
				}
				child.RemoveFromHierarchy();
				bool flag5 = this.m_Owner.m_Children == VisualElement.s_EmptyList;
				if (flag5)
				{
					this.m_Owner.m_Children = VisualElementListPool.Get(0);
				}
				bool isMeasureDefined = this.m_Owner.yogaNode.IsMeasureDefined;
				if (isMeasureDefined)
				{
					this.m_Owner.RemoveMeasureFunction();
				}
				this.PutChildAtIndex(child, index);
				int num = child.imguiContainerDescendantCount + (child.isIMGUIContainer ? 1 : 0);
				bool flag6 = num > 0;
				if (flag6)
				{
					this.m_Owner.ChangeIMGUIContainerCount(num);
				}
				child.hierarchy.SetParent(this.m_Owner);
				child.PropagateEnabledToChildren(this.m_Owner.enabledInHierarchy);
				bool flag7 = child.languageDirection == LanguageDirection.Inherit;
				if (flag7)
				{
					child.localLanguageDirection = this.m_Owner.localLanguageDirection;
				}
				child.InvokeHierarchyChanged(HierarchyChangeType.Add);
				child.IncrementVersion(VersionChangeType.Hierarchy);
				this.m_Owner.IncrementVersion(VersionChangeType.Hierarchy);
			}

			// Token: 0x060018F2 RID: 6386 RVA: 0x00060960 File Offset: 0x0005EB60
			public void Remove(VisualElement child)
			{
				bool flag = child == null;
				if (flag)
				{
					throw new ArgumentException("Cannot remove null child");
				}
				bool flag2 = child.hierarchy.parent != this.m_Owner;
				if (flag2)
				{
					throw new ArgumentException("This VisualElement is not my child");
				}
				int index = this.m_Owner.m_Children.IndexOf(child);
				this.RemoveAt(index);
			}

			// Token: 0x060018F3 RID: 6387 RVA: 0x000609C4 File Offset: 0x0005EBC4
			public void RemoveAt(int index)
			{
				bool flag = this.m_Owner.elementPanel != null && this.m_Owner.elementPanel.duringLayoutPhase;
				if (flag)
				{
					throw new InvalidOperationException("Cannot modify VisualElement hierarchy during layout calculation");
				}
				bool flag2 = index < 0 || index >= this.childCount;
				if (flag2)
				{
					throw new ArgumentOutOfRangeException("Index out of range: " + index.ToString());
				}
				VisualElement visualElement = this.m_Owner.m_Children[index];
				visualElement.InvokeHierarchyChanged(HierarchyChangeType.Remove);
				this.RemoveChildAtIndex(index);
				int num = visualElement.imguiContainerDescendantCount + (visualElement.isIMGUIContainer ? 1 : 0);
				bool flag3 = num > 0;
				if (flag3)
				{
					this.m_Owner.ChangeIMGUIContainerCount(-num);
				}
				visualElement.hierarchy.SetParent(null);
				bool flag4 = this.childCount == 0;
				if (flag4)
				{
					this.ReleaseChildList();
					bool requireMeasureFunction = this.m_Owner.requireMeasureFunction;
					if (requireMeasureFunction)
					{
						this.m_Owner.AssignMeasureFunction();
					}
				}
				BaseVisualElementPanel elementPanel = this.m_Owner.elementPanel;
				if (elementPanel != null)
				{
					elementPanel.OnVersionChanged(visualElement, VersionChangeType.Hierarchy);
				}
				this.m_Owner.IncrementVersion(VersionChangeType.Hierarchy);
			}

			// Token: 0x060018F4 RID: 6388 RVA: 0x00060AEC File Offset: 0x0005ECEC
			public void Clear()
			{
				bool flag = this.m_Owner.elementPanel != null && this.m_Owner.elementPanel.duringLayoutPhase;
				if (flag)
				{
					throw new InvalidOperationException("Cannot modify VisualElement hierarchy during layout calculation");
				}
				bool flag2 = this.childCount > 0;
				if (flag2)
				{
					List<VisualElement> list = VisualElementListPool.Copy(this.m_Owner.m_Children);
					this.ReleaseChildList();
					this.m_Owner.yogaNode.Clear();
					bool requireMeasureFunction = this.m_Owner.requireMeasureFunction;
					if (requireMeasureFunction)
					{
						this.m_Owner.AssignMeasureFunction();
					}
					foreach (VisualElement visualElement in list)
					{
						visualElement.InvokeHierarchyChanged(HierarchyChangeType.Remove);
						visualElement.hierarchy.SetParent(null);
						visualElement.m_LogicalParent = null;
						BaseVisualElementPanel elementPanel = this.m_Owner.elementPanel;
						if (elementPanel != null)
						{
							elementPanel.OnVersionChanged(visualElement, VersionChangeType.Hierarchy);
						}
					}
					bool flag3 = this.m_Owner.imguiContainerDescendantCount > 0;
					if (flag3)
					{
						int num = this.m_Owner.imguiContainerDescendantCount;
						bool isIMGUIContainer = this.m_Owner.isIMGUIContainer;
						if (isIMGUIContainer)
						{
							num--;
						}
						this.m_Owner.ChangeIMGUIContainerCount(-num);
					}
					VisualElementListPool.Release(list);
					this.m_Owner.IncrementVersion(VersionChangeType.Hierarchy);
				}
			}

			// Token: 0x060018F5 RID: 6389 RVA: 0x00060C5C File Offset: 0x0005EE5C
			internal void BringToFront(VisualElement child)
			{
				bool flag = this.childCount > 1;
				if (flag)
				{
					int num = this.m_Owner.m_Children.IndexOf(child);
					bool flag2 = num >= 0 && num < this.childCount - 1;
					if (flag2)
					{
						this.MoveChildElement(child, num, this.childCount);
					}
				}
			}

			// Token: 0x060018F6 RID: 6390 RVA: 0x00060CB4 File Offset: 0x0005EEB4
			internal void SendToBack(VisualElement child)
			{
				bool flag = this.childCount > 1;
				if (flag)
				{
					int num = this.m_Owner.m_Children.IndexOf(child);
					bool flag2 = num > 0;
					if (flag2)
					{
						this.MoveChildElement(child, num, 0);
					}
				}
			}

			// Token: 0x060018F7 RID: 6391 RVA: 0x00060CF8 File Offset: 0x0005EEF8
			internal void PlaceBehind(VisualElement child, VisualElement over)
			{
				bool flag = this.childCount > 0;
				if (flag)
				{
					int num = this.m_Owner.m_Children.IndexOf(child);
					bool flag2 = num < 0;
					if (!flag2)
					{
						int num2 = this.m_Owner.m_Children.IndexOf(over);
						bool flag3 = num2 > 0 && num < num2;
						if (flag3)
						{
							num2--;
						}
						this.MoveChildElement(child, num, num2);
					}
				}
			}

			// Token: 0x060018F8 RID: 6392 RVA: 0x00060D64 File Offset: 0x0005EF64
			internal void PlaceInFront(VisualElement child, VisualElement under)
			{
				bool flag = this.childCount > 0;
				if (flag)
				{
					int num = this.m_Owner.m_Children.IndexOf(child);
					bool flag2 = num < 0;
					if (!flag2)
					{
						int num2 = this.m_Owner.m_Children.IndexOf(under);
						bool flag3 = num > num2;
						if (flag3)
						{
							num2++;
						}
						this.MoveChildElement(child, num, num2);
					}
				}
			}

			// Token: 0x060018F9 RID: 6393 RVA: 0x00060DCC File Offset: 0x0005EFCC
			private void MoveChildElement(VisualElement child, int currentIndex, int nextIndex)
			{
				bool flag = this.m_Owner.elementPanel != null && this.m_Owner.elementPanel.duringLayoutPhase;
				if (flag)
				{
					throw new InvalidOperationException("Cannot modify VisualElement hierarchy during layout calculation");
				}
				child.InvokeHierarchyChanged(HierarchyChangeType.Remove);
				this.RemoveChildAtIndex(currentIndex);
				this.PutChildAtIndex(child, nextIndex);
				child.InvokeHierarchyChanged(HierarchyChangeType.Add);
				this.m_Owner.IncrementVersion(VersionChangeType.Hierarchy);
			}

			// Token: 0x1700064B RID: 1611
			// (get) Token: 0x060018FA RID: 6394 RVA: 0x00060E38 File Offset: 0x0005F038
			public int childCount
			{
				get
				{
					return this.m_Owner.m_Children.Count;
				}
			}

			// Token: 0x1700064C RID: 1612
			public VisualElement this[int key]
			{
				get
				{
					return this.m_Owner.m_Children[key];
				}
			}

			// Token: 0x060018FC RID: 6396 RVA: 0x00060E80 File Offset: 0x0005F080
			public int IndexOf(VisualElement element)
			{
				return this.m_Owner.m_Children.IndexOf(element);
			}

			// Token: 0x060018FD RID: 6397 RVA: 0x00060EA4 File Offset: 0x0005F0A4
			public VisualElement ElementAt(int index)
			{
				return this[index];
			}

			// Token: 0x060018FE RID: 6398 RVA: 0x00060EC0 File Offset: 0x0005F0C0
			public IEnumerable<VisualElement> Children()
			{
				return this.m_Owner.m_Children;
			}

			// Token: 0x060018FF RID: 6399 RVA: 0x00060EDD File Offset: 0x0005F0DD
			private void SetParent(VisualElement value)
			{
				this.m_Owner.m_PhysicalParent = value;
				this.m_Owner.m_LogicalParent = value;
				this.m_Owner.DirtyNextParentWithEventCallback();
				this.m_Owner.SetPanel((value != null) ? value.elementPanel : null);
			}

			// Token: 0x06001900 RID: 6400 RVA: 0x00060F1C File Offset: 0x0005F11C
			public void Sort(Comparison<VisualElement> comp)
			{
				bool flag = this.m_Owner.elementPanel != null && this.m_Owner.elementPanel.duringLayoutPhase;
				if (flag)
				{
					throw new InvalidOperationException("Cannot modify VisualElement hierarchy during layout calculation");
				}
				bool flag2 = this.childCount > 1;
				if (flag2)
				{
					this.m_Owner.m_Children.Sort(comp);
					this.m_Owner.yogaNode.Clear();
					for (int i = 0; i < this.m_Owner.m_Children.Count; i++)
					{
						this.m_Owner.yogaNode.Insert(i, this.m_Owner.m_Children[i].yogaNode);
					}
					this.m_Owner.InvokeHierarchyChanged(HierarchyChangeType.Move);
					this.m_Owner.IncrementVersion(VersionChangeType.Hierarchy);
				}
			}

			// Token: 0x06001901 RID: 6401 RVA: 0x00060FF4 File Offset: 0x0005F1F4
			private void PutChildAtIndex(VisualElement child, int index)
			{
				bool flag = index >= this.childCount;
				if (flag)
				{
					this.m_Owner.m_Children.Add(child);
					this.m_Owner.yogaNode.Insert(this.m_Owner.yogaNode.Count, child.yogaNode);
				}
				else
				{
					this.m_Owner.m_Children.Insert(index, child);
					this.m_Owner.yogaNode.Insert(index, child.yogaNode);
				}
			}

			// Token: 0x06001902 RID: 6402 RVA: 0x0006107C File Offset: 0x0005F27C
			private void RemoveChildAtIndex(int index)
			{
				this.m_Owner.m_Children.RemoveAt(index);
				this.m_Owner.yogaNode.RemoveAt(index);
			}

			// Token: 0x06001903 RID: 6403 RVA: 0x000610A4 File Offset: 0x0005F2A4
			private void ReleaseChildList()
			{
				bool flag = this.m_Owner.m_Children != VisualElement.s_EmptyList;
				if (flag)
				{
					List<VisualElement> children = this.m_Owner.m_Children;
					this.m_Owner.m_Children = VisualElement.s_EmptyList;
					VisualElementListPool.Release(children);
				}
			}

			// Token: 0x06001904 RID: 6404 RVA: 0x000610F0 File Offset: 0x0005F2F0
			public bool Equals(VisualElement.Hierarchy other)
			{
				return other == this;
			}

			// Token: 0x06001905 RID: 6405 RVA: 0x00061110 File Offset: 0x0005F310
			public override bool Equals(object obj)
			{
				bool flag = obj == null;
				return !flag && obj is VisualElement.Hierarchy && this.Equals((VisualElement.Hierarchy)obj);
			}

			// Token: 0x06001906 RID: 6406 RVA: 0x00061148 File Offset: 0x0005F348
			public override int GetHashCode()
			{
				return (this.m_Owner != null) ? this.m_Owner.GetHashCode() : 0;
			}

			// Token: 0x06001907 RID: 6407 RVA: 0x00061170 File Offset: 0x0005F370
			public static bool operator ==(VisualElement.Hierarchy x, VisualElement.Hierarchy y)
			{
				return x.m_Owner == y.m_Owner;
			}

			// Token: 0x06001908 RID: 6408 RVA: 0x00061190 File Offset: 0x0005F390
			public static bool operator !=(VisualElement.Hierarchy x, VisualElement.Hierarchy y)
			{
				return !(x == y);
			}

			// Token: 0x04000A4B RID: 2635
			private const string k_InvalidHierarchyChangeMsg = "Cannot modify VisualElement hierarchy during layout calculation";

			// Token: 0x04000A4C RID: 2636
			private readonly VisualElement m_Owner;
		}

		// Token: 0x020002DC RID: 732
		private abstract class BaseVisualElementScheduledItem : ScheduledItem, IVisualElementScheduledItem, IVisualElementPanelActivatable
		{
			// Token: 0x1700064D RID: 1613
			// (get) Token: 0x06001909 RID: 6409 RVA: 0x000611AC File Offset: 0x0005F3AC
			// (set) Token: 0x0600190A RID: 6410 RVA: 0x000611B4 File Offset: 0x0005F3B4
			public VisualElement element { get; private set; }

			// Token: 0x1700064E RID: 1614
			// (get) Token: 0x0600190B RID: 6411 RVA: 0x000611C0 File Offset: 0x0005F3C0
			public bool isActive
			{
				get
				{
					return this.m_Activator.isActive;
				}
			}

			// Token: 0x0600190C RID: 6412 RVA: 0x000611DD File Offset: 0x0005F3DD
			protected BaseVisualElementScheduledItem(VisualElement handler)
			{
				this.element = handler;
				this.m_Activator = new VisualElementPanelActivator(this);
			}

			// Token: 0x0600190D RID: 6413 RVA: 0x00061204 File Offset: 0x0005F404
			public IVisualElementScheduledItem StartingIn(long delayMs)
			{
				base.delayMs = delayMs;
				return this;
			}

			// Token: 0x0600190E RID: 6414 RVA: 0x00061220 File Offset: 0x0005F420
			public IVisualElementScheduledItem Until(Func<bool> stopCondition)
			{
				bool flag = stopCondition == null;
				if (flag)
				{
					stopCondition = ScheduledItem.ForeverCondition;
				}
				this.timerUpdateStopCondition = stopCondition;
				return this;
			}

			// Token: 0x0600190F RID: 6415 RVA: 0x0006124C File Offset: 0x0005F44C
			public IVisualElementScheduledItem ForDuration(long durationMs)
			{
				base.SetDuration(durationMs);
				return this;
			}

			// Token: 0x06001910 RID: 6416 RVA: 0x00061268 File Offset: 0x0005F468
			public IVisualElementScheduledItem Every(long intervalMs)
			{
				base.intervalMs = intervalMs;
				bool flag = this.timerUpdateStopCondition == ScheduledItem.OnceCondition;
				if (flag)
				{
					this.timerUpdateStopCondition = ScheduledItem.ForeverCondition;
				}
				return this;
			}

			// Token: 0x06001911 RID: 6417 RVA: 0x000612A4 File Offset: 0x0005F4A4
			internal override void OnItemUnscheduled()
			{
				base.OnItemUnscheduled();
				this.isScheduled = false;
				bool flag = !this.m_Activator.isDetaching;
				if (flag)
				{
					this.m_Activator.SetActive(false);
				}
			}

			// Token: 0x06001912 RID: 6418 RVA: 0x000612E1 File Offset: 0x0005F4E1
			public void Resume()
			{
				this.m_Activator.SetActive(true);
			}

			// Token: 0x06001913 RID: 6419 RVA: 0x000612F1 File Offset: 0x0005F4F1
			public void Pause()
			{
				this.m_Activator.SetActive(false);
			}

			// Token: 0x06001914 RID: 6420 RVA: 0x00061304 File Offset: 0x0005F504
			public void ExecuteLater(long delayMs)
			{
				bool flag = !this.isScheduled;
				if (flag)
				{
					this.Resume();
				}
				base.ResetStartTime();
				this.StartingIn(delayMs);
			}

			// Token: 0x06001915 RID: 6421 RVA: 0x00061338 File Offset: 0x0005F538
			public void OnPanelActivate()
			{
				bool flag = !this.isScheduled;
				if (flag)
				{
					this.isScheduled = true;
					base.ResetStartTime();
					this.element.elementPanel.scheduler.Schedule(this);
				}
			}

			// Token: 0x06001916 RID: 6422 RVA: 0x0006137C File Offset: 0x0005F57C
			public void OnPanelDeactivate()
			{
				bool flag = this.isScheduled;
				if (flag)
				{
					this.isScheduled = false;
					this.element.elementPanel.scheduler.Unschedule(this);
				}
			}

			// Token: 0x06001917 RID: 6423 RVA: 0x000613B4 File Offset: 0x0005F5B4
			public bool CanBeActivated()
			{
				return this.element != null && this.element.elementPanel != null && this.element.elementPanel.scheduler != null;
			}

			// Token: 0x04000A4E RID: 2638
			public bool isScheduled = false;

			// Token: 0x04000A4F RID: 2639
			private VisualElementPanelActivator m_Activator;
		}

		// Token: 0x020002DD RID: 733
		private abstract class VisualElementScheduledItem<ActionType> : VisualElement.BaseVisualElementScheduledItem
		{
			// Token: 0x06001918 RID: 6424 RVA: 0x000613F1 File Offset: 0x0005F5F1
			public VisualElementScheduledItem(VisualElement handler, ActionType upEvent) : base(handler)
			{
				this.updateEvent = upEvent;
			}

			// Token: 0x06001919 RID: 6425 RVA: 0x00061404 File Offset: 0x0005F604
			public static bool Matches(ScheduledItem item, ActionType updateEvent)
			{
				VisualElement.VisualElementScheduledItem<ActionType> visualElementScheduledItem = item as VisualElement.VisualElementScheduledItem<ActionType>;
				bool flag = visualElementScheduledItem != null;
				return flag && EqualityComparer<ActionType>.Default.Equals(visualElementScheduledItem.updateEvent, updateEvent);
			}

			// Token: 0x04000A50 RID: 2640
			public ActionType updateEvent;
		}

		// Token: 0x020002DE RID: 734
		private class TimerStateScheduledItem : VisualElement.VisualElementScheduledItem<Action<TimerState>>
		{
			// Token: 0x0600191A RID: 6426 RVA: 0x0006143B File Offset: 0x0005F63B
			public TimerStateScheduledItem(VisualElement handler, Action<TimerState> updateEvent) : base(handler, updateEvent)
			{
			}

			// Token: 0x0600191B RID: 6427 RVA: 0x00061448 File Offset: 0x0005F648
			public override void PerformTimerUpdate(TimerState state)
			{
				bool isScheduled = this.isScheduled;
				if (isScheduled)
				{
					this.updateEvent(state);
				}
			}
		}

		// Token: 0x020002DF RID: 735
		private class SimpleScheduledItem : VisualElement.VisualElementScheduledItem<Action>
		{
			// Token: 0x0600191C RID: 6428 RVA: 0x0006146F File Offset: 0x0005F66F
			public SimpleScheduledItem(VisualElement handler, Action updateEvent) : base(handler, updateEvent)
			{
			}

			// Token: 0x0600191D RID: 6429 RVA: 0x0006147C File Offset: 0x0005F67C
			public override void PerformTimerUpdate(TimerState state)
			{
				bool isScheduled = this.isScheduled;
				if (isScheduled)
				{
					this.updateEvent();
				}
			}
		}

		// Token: 0x020002E0 RID: 736
		internal class CustomStyleAccess : ICustomStyle
		{
			// Token: 0x0600191E RID: 6430 RVA: 0x000614A2 File Offset: 0x0005F6A2
			public void SetContext(Dictionary<string, StylePropertyValue> customProperties, float dpiScaling)
			{
				this.m_CustomProperties = customProperties;
				this.m_DpiScaling = dpiScaling;
			}

			// Token: 0x0600191F RID: 6431 RVA: 0x000614B4 File Offset: 0x0005F6B4
			public bool TryGetValue(CustomStyleProperty<float> property, out float value)
			{
				StylePropertyValue stylePropertyValue;
				bool flag = this.TryGetValue(property.name, StyleValueType.Float, out stylePropertyValue);
				if (flag)
				{
					bool flag2 = stylePropertyValue.sheet.TryReadFloat(stylePropertyValue.handle, out value);
					if (flag2)
					{
						return true;
					}
				}
				value = 0f;
				return false;
			}

			// Token: 0x06001920 RID: 6432 RVA: 0x00061500 File Offset: 0x0005F700
			public bool TryGetValue(CustomStyleProperty<int> property, out int value)
			{
				StylePropertyValue stylePropertyValue;
				bool flag = this.TryGetValue(property.name, StyleValueType.Float, out stylePropertyValue);
				if (flag)
				{
					float num;
					bool flag2 = stylePropertyValue.sheet.TryReadFloat(stylePropertyValue.handle, out num);
					if (flag2)
					{
						value = (int)num;
						return true;
					}
				}
				value = 0;
				return false;
			}

			// Token: 0x06001921 RID: 6433 RVA: 0x00061550 File Offset: 0x0005F750
			public bool TryGetValue(CustomStyleProperty<bool> property, out bool value)
			{
				StylePropertyValue stylePropertyValue;
				bool flag = this.m_CustomProperties != null && this.m_CustomProperties.TryGetValue(property.name, out stylePropertyValue);
				bool result;
				if (flag)
				{
					value = (stylePropertyValue.sheet.ReadKeyword(stylePropertyValue.handle) == StyleValueKeyword.True);
					result = true;
				}
				else
				{
					value = false;
					result = false;
				}
				return result;
			}

			// Token: 0x06001922 RID: 6434 RVA: 0x000615A4 File Offset: 0x0005F7A4
			public bool TryGetValue(CustomStyleProperty<Color> property, out Color value)
			{
				StylePropertyValue stylePropertyValue;
				bool flag = this.m_CustomProperties != null && this.m_CustomProperties.TryGetValue(property.name, out stylePropertyValue);
				if (flag)
				{
					StyleValueHandle handle = stylePropertyValue.handle;
					StyleValueType valueType = handle.valueType;
					StyleValueType styleValueType = valueType;
					if (styleValueType != StyleValueType.Color)
					{
						if (styleValueType == StyleValueType.Enum)
						{
							string text = stylePropertyValue.sheet.ReadAsString(handle);
							return StyleSheetColor.TryGetColor(text.ToLowerInvariant(), out value);
						}
						VisualElement.CustomStyleAccess.LogCustomPropertyWarning(property.name, StyleValueType.Color, stylePropertyValue);
					}
					else
					{
						bool flag2 = stylePropertyValue.sheet.TryReadColor(stylePropertyValue.handle, out value);
						if (flag2)
						{
							return true;
						}
					}
				}
				value = Color.clear;
				return false;
			}

			// Token: 0x06001923 RID: 6435 RVA: 0x0006165C File Offset: 0x0005F85C
			public bool TryGetValue(CustomStyleProperty<Texture2D> property, out Texture2D value)
			{
				StylePropertyValue propertyValue;
				bool flag = this.m_CustomProperties != null && this.m_CustomProperties.TryGetValue(property.name, out propertyValue);
				if (flag)
				{
					ImageSource imageSource = default(ImageSource);
					bool flag2 = StylePropertyReader.TryGetImageSourceFromValue(propertyValue, this.m_DpiScaling, out imageSource) && imageSource.texture != null;
					if (flag2)
					{
						value = imageSource.texture;
						return true;
					}
				}
				value = null;
				return false;
			}

			// Token: 0x06001924 RID: 6436 RVA: 0x000616D4 File Offset: 0x0005F8D4
			public bool TryGetValue(CustomStyleProperty<Sprite> property, out Sprite value)
			{
				StylePropertyValue propertyValue;
				bool flag = this.m_CustomProperties != null && this.m_CustomProperties.TryGetValue(property.name, out propertyValue);
				if (flag)
				{
					ImageSource imageSource = default(ImageSource);
					bool flag2 = StylePropertyReader.TryGetImageSourceFromValue(propertyValue, this.m_DpiScaling, out imageSource) && imageSource.sprite != null;
					if (flag2)
					{
						value = imageSource.sprite;
						return true;
					}
				}
				value = null;
				return false;
			}

			// Token: 0x06001925 RID: 6437 RVA: 0x0006174C File Offset: 0x0005F94C
			public bool TryGetValue(CustomStyleProperty<VectorImage> property, out VectorImage value)
			{
				StylePropertyValue propertyValue;
				bool flag = this.m_CustomProperties != null && this.m_CustomProperties.TryGetValue(property.name, out propertyValue);
				if (flag)
				{
					ImageSource imageSource = default(ImageSource);
					bool flag2 = StylePropertyReader.TryGetImageSourceFromValue(propertyValue, this.m_DpiScaling, out imageSource) && imageSource.vectorImage != null;
					if (flag2)
					{
						value = imageSource.vectorImage;
						return true;
					}
				}
				value = null;
				return false;
			}

			// Token: 0x06001926 RID: 6438 RVA: 0x000617C4 File Offset: 0x0005F9C4
			public bool TryGetValue<T>(CustomStyleProperty<T> property, out T value) where T : Object
			{
				StylePropertyValue stylePropertyValue;
				bool flag = this.m_CustomProperties != null && this.m_CustomProperties.TryGetValue(property.name, out stylePropertyValue);
				if (flag)
				{
					Object @object;
					bool flag2 = stylePropertyValue.sheet.TryReadAssetReference(stylePropertyValue.handle, out @object);
					if (flag2)
					{
						value = (@object as T);
						return value != null;
					}
				}
				value = default(T);
				return false;
			}

			// Token: 0x06001927 RID: 6439 RVA: 0x00061844 File Offset: 0x0005FA44
			public bool TryGetValue(CustomStyleProperty<string> property, out string value)
			{
				StylePropertyValue stylePropertyValue;
				bool flag = this.m_CustomProperties != null && this.m_CustomProperties.TryGetValue(property.name, out stylePropertyValue);
				bool result;
				if (flag)
				{
					value = stylePropertyValue.sheet.ReadAsString(stylePropertyValue.handle);
					result = true;
				}
				else
				{
					value = string.Empty;
					result = false;
				}
				return result;
			}

			// Token: 0x06001928 RID: 6440 RVA: 0x0006189C File Offset: 0x0005FA9C
			private bool TryGetValue(string propertyName, StyleValueType valueType, out StylePropertyValue customProp)
			{
				customProp = default(StylePropertyValue);
				bool flag = this.m_CustomProperties != null && this.m_CustomProperties.TryGetValue(propertyName, out customProp);
				bool result;
				if (flag)
				{
					StyleValueHandle handle = customProp.handle;
					bool flag2 = handle.valueType != valueType;
					if (flag2)
					{
						VisualElement.CustomStyleAccess.LogCustomPropertyWarning(propertyName, valueType, customProp);
						result = false;
					}
					else
					{
						result = true;
					}
				}
				else
				{
					result = false;
				}
				return result;
			}

			// Token: 0x06001929 RID: 6441 RVA: 0x00061902 File Offset: 0x0005FB02
			private static void LogCustomPropertyWarning(string propertyName, StyleValueType valueType, StylePropertyValue customProp)
			{
				Debug.LogWarning(string.Format("Trying to read custom property {0} value as {1} while parsed type is {2}", propertyName, valueType, customProp.handle.valueType));
			}

			// Token: 0x04000A51 RID: 2641
			private Dictionary<string, StylePropertyValue> m_CustomProperties;

			// Token: 0x04000A52 RID: 2642
			private float m_DpiScaling;
		}

		// Token: 0x020002E1 RID: 737
		internal class TypeData
		{
			// Token: 0x1700064F RID: 1615
			// (get) Token: 0x0600192B RID: 6443 RVA: 0x0006192D File Offset: 0x0005FB2D
			public Type type { get; }

			// Token: 0x0600192C RID: 6444 RVA: 0x00061935 File Offset: 0x0005FB35
			public TypeData(Type type)
			{
				this.type = type;
			}

			// Token: 0x17000650 RID: 1616
			// (get) Token: 0x0600192D RID: 6445 RVA: 0x00061968 File Offset: 0x0005FB68
			public string fullTypeName
			{
				get
				{
					bool flag = string.IsNullOrEmpty(this.m_FullTypeName);
					if (flag)
					{
						this.m_FullTypeName = this.type.FullName;
					}
					return this.m_FullTypeName;
				}
			}

			// Token: 0x17000651 RID: 1617
			// (get) Token: 0x0600192E RID: 6446 RVA: 0x000619A0 File Offset: 0x0005FBA0
			public string typeName
			{
				get
				{
					bool flag = string.IsNullOrEmpty(this.m_TypeName);
					if (flag)
					{
						bool isGenericType = this.type.IsGenericType;
						this.m_TypeName = this.type.Name;
						bool flag2 = isGenericType;
						if (flag2)
						{
							int num = this.m_TypeName.IndexOf('`');
							bool flag3 = num >= 0;
							if (flag3)
							{
								this.m_TypeName = this.m_TypeName.Remove(num);
							}
						}
					}
					return this.m_TypeName;
				}
			}

			// Token: 0x17000652 RID: 1618
			// (get) Token: 0x0600192F RID: 6447 RVA: 0x00061A20 File Offset: 0x0005FC20
			public string typeNamespace
			{
				get
				{
					bool flag = string.IsNullOrEmpty(this.m_TypeNamespace);
					if (flag)
					{
						this.m_TypeNamespace = this.type.Namespace;
					}
					return this.m_TypeNamespace;
				}
			}

			// Token: 0x04000A54 RID: 2644
			private string m_FullTypeName = string.Empty;

			// Token: 0x04000A55 RID: 2645
			private string m_TypeName = string.Empty;

			// Token: 0x04000A56 RID: 2646
			private string m_TypeNamespace = string.Empty;
		}
	}
}
