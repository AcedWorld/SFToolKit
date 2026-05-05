using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements.StyleSheets;
using UnityEngine.Yoga;

namespace UnityEngine.UIElements
{
	// Token: 0x020002D1 RID: 721
	internal class InlineStyleAccess : StyleValueCollection, IStyle
	{
		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x06001580 RID: 5504 RVA: 0x00055168 File Offset: 0x00053368
		// (set) Token: 0x06001581 RID: 5505 RVA: 0x0005519C File Offset: 0x0005339C
		StyleEnum<Align> IStyle.alignContent
		{
			get
			{
				StyleInt styleInt = base.GetStyleInt(StylePropertyId.AlignContent);
				return new StyleEnum<Align>((Align)styleInt.value, styleInt.keyword);
			}
			set
			{
				bool flag = this.SetStyleValue<Align>(StylePropertyId.AlignContent, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.AlignContent = (YogaAlign)this.ve.computedStyle.alignContent;
				}
			}
		}

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x06001582 RID: 5506 RVA: 0x000551EC File Offset: 0x000533EC
		// (set) Token: 0x06001583 RID: 5507 RVA: 0x00055220 File Offset: 0x00053420
		StyleEnum<Align> IStyle.alignItems
		{
			get
			{
				StyleInt styleInt = base.GetStyleInt(StylePropertyId.AlignItems);
				return new StyleEnum<Align>((Align)styleInt.value, styleInt.keyword);
			}
			set
			{
				bool flag = this.SetStyleValue<Align>(StylePropertyId.AlignItems, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.AlignItems = (YogaAlign)this.ve.computedStyle.alignItems;
				}
			}
		}

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06001584 RID: 5508 RVA: 0x00055270 File Offset: 0x00053470
		// (set) Token: 0x06001585 RID: 5509 RVA: 0x000552A4 File Offset: 0x000534A4
		StyleEnum<Align> IStyle.alignSelf
		{
			get
			{
				StyleInt styleInt = base.GetStyleInt(StylePropertyId.AlignSelf);
				return new StyleEnum<Align>((Align)styleInt.value, styleInt.keyword);
			}
			set
			{
				bool flag = this.SetStyleValue<Align>(StylePropertyId.AlignSelf, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.AlignSelf = (YogaAlign)this.ve.computedStyle.alignSelf;
				}
			}
		}

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x06001586 RID: 5510 RVA: 0x000552F4 File Offset: 0x000534F4
		// (set) Token: 0x06001587 RID: 5511 RVA: 0x00055314 File Offset: 0x00053514
		StyleColor IStyle.backgroundColor
		{
			get
			{
				return base.GetStyleColor(StylePropertyId.BackgroundColor);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.BackgroundColor, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Color);
				}
			}
		}

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x06001588 RID: 5512 RVA: 0x00055348 File Offset: 0x00053548
		// (set) Token: 0x06001589 RID: 5513 RVA: 0x00055368 File Offset: 0x00053568
		StyleBackground IStyle.backgroundImage
		{
			get
			{
				return base.GetStyleBackground(StylePropertyId.BackgroundImage);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.BackgroundImage, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x0600158A RID: 5514 RVA: 0x0005539C File Offset: 0x0005359C
		// (set) Token: 0x0600158B RID: 5515 RVA: 0x000553BC File Offset: 0x000535BC
		StyleBackgroundPosition IStyle.backgroundPositionX
		{
			get
			{
				return base.GetStyleBackgroundPosition(StylePropertyId.BackgroundPositionX);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.BackgroundPositionX, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x0600158C RID: 5516 RVA: 0x000553F0 File Offset: 0x000535F0
		// (set) Token: 0x0600158D RID: 5517 RVA: 0x00055410 File Offset: 0x00053610
		StyleBackgroundPosition IStyle.backgroundPositionY
		{
			get
			{
				return base.GetStyleBackgroundPosition(StylePropertyId.BackgroundPositionY);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.BackgroundPositionY, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x0600158E RID: 5518 RVA: 0x00055444 File Offset: 0x00053644
		// (set) Token: 0x0600158F RID: 5519 RVA: 0x00055464 File Offset: 0x00053664
		StyleBackgroundRepeat IStyle.backgroundRepeat
		{
			get
			{
				return base.GetStyleBackgroundRepeat(StylePropertyId.BackgroundRepeat);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.BackgroundRepeat, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x06001590 RID: 5520 RVA: 0x00055498 File Offset: 0x00053698
		// (set) Token: 0x06001591 RID: 5521 RVA: 0x000554B8 File Offset: 0x000536B8
		StyleColor IStyle.borderBottomColor
		{
			get
			{
				return base.GetStyleColor(StylePropertyId.BorderBottomColor);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.BorderBottomColor, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Color);
				}
			}
		}

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x06001592 RID: 5522 RVA: 0x000554EC File Offset: 0x000536EC
		// (set) Token: 0x06001593 RID: 5523 RVA: 0x0005550C File Offset: 0x0005370C
		StyleLength IStyle.borderBottomLeftRadius
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.BorderBottomLeftRadius);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.BorderBottomLeftRadius, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.BorderRadius | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x06001594 RID: 5524 RVA: 0x00055540 File Offset: 0x00053740
		// (set) Token: 0x06001595 RID: 5525 RVA: 0x00055560 File Offset: 0x00053760
		StyleLength IStyle.borderBottomRightRadius
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.BorderBottomRightRadius);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.BorderBottomRightRadius, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.BorderRadius | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06001596 RID: 5526 RVA: 0x00055594 File Offset: 0x00053794
		// (set) Token: 0x06001597 RID: 5527 RVA: 0x000555B4 File Offset: 0x000537B4
		StyleFloat IStyle.borderBottomWidth
		{
			get
			{
				return base.GetStyleFloat(StylePropertyId.BorderBottomWidth);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.BorderBottomWidth, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles | VersionChangeType.BorderWidth | VersionChangeType.Repaint);
					this.ve.yogaNode.BorderBottomWidth = this.ve.computedStyle.borderBottomWidth;
				}
			}
		}

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x06001598 RID: 5528 RVA: 0x00055608 File Offset: 0x00053808
		// (set) Token: 0x06001599 RID: 5529 RVA: 0x00055628 File Offset: 0x00053828
		StyleColor IStyle.borderLeftColor
		{
			get
			{
				return base.GetStyleColor(StylePropertyId.BorderLeftColor);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.BorderLeftColor, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Color);
				}
			}
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x0600159A RID: 5530 RVA: 0x0005565C File Offset: 0x0005385C
		// (set) Token: 0x0600159B RID: 5531 RVA: 0x0005567C File Offset: 0x0005387C
		StyleFloat IStyle.borderLeftWidth
		{
			get
			{
				return base.GetStyleFloat(StylePropertyId.BorderLeftWidth);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.BorderLeftWidth, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles | VersionChangeType.BorderWidth | VersionChangeType.Repaint);
					this.ve.yogaNode.BorderLeftWidth = this.ve.computedStyle.borderLeftWidth;
				}
			}
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x0600159C RID: 5532 RVA: 0x000556D0 File Offset: 0x000538D0
		// (set) Token: 0x0600159D RID: 5533 RVA: 0x000556F0 File Offset: 0x000538F0
		StyleColor IStyle.borderRightColor
		{
			get
			{
				return base.GetStyleColor(StylePropertyId.BorderRightColor);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.BorderRightColor, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Color);
				}
			}
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x0600159E RID: 5534 RVA: 0x00055724 File Offset: 0x00053924
		// (set) Token: 0x0600159F RID: 5535 RVA: 0x00055744 File Offset: 0x00053944
		StyleFloat IStyle.borderRightWidth
		{
			get
			{
				return base.GetStyleFloat(StylePropertyId.BorderRightWidth);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.BorderRightWidth, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles | VersionChangeType.BorderWidth | VersionChangeType.Repaint);
					this.ve.yogaNode.BorderRightWidth = this.ve.computedStyle.borderRightWidth;
				}
			}
		}

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x060015A0 RID: 5536 RVA: 0x00055798 File Offset: 0x00053998
		// (set) Token: 0x060015A1 RID: 5537 RVA: 0x000557B8 File Offset: 0x000539B8
		StyleColor IStyle.borderTopColor
		{
			get
			{
				return base.GetStyleColor(StylePropertyId.BorderTopColor);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.BorderTopColor, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Color);
				}
			}
		}

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x060015A2 RID: 5538 RVA: 0x000557EC File Offset: 0x000539EC
		// (set) Token: 0x060015A3 RID: 5539 RVA: 0x0005580C File Offset: 0x00053A0C
		StyleLength IStyle.borderTopLeftRadius
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.BorderTopLeftRadius);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.BorderTopLeftRadius, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.BorderRadius | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x060015A4 RID: 5540 RVA: 0x00055840 File Offset: 0x00053A40
		// (set) Token: 0x060015A5 RID: 5541 RVA: 0x00055860 File Offset: 0x00053A60
		StyleLength IStyle.borderTopRightRadius
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.BorderTopRightRadius);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.BorderTopRightRadius, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.BorderRadius | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x060015A6 RID: 5542 RVA: 0x00055894 File Offset: 0x00053A94
		// (set) Token: 0x060015A7 RID: 5543 RVA: 0x000558B4 File Offset: 0x00053AB4
		StyleFloat IStyle.borderTopWidth
		{
			get
			{
				return base.GetStyleFloat(StylePropertyId.BorderTopWidth);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.BorderTopWidth, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles | VersionChangeType.BorderWidth | VersionChangeType.Repaint);
					this.ve.yogaNode.BorderTopWidth = this.ve.computedStyle.borderTopWidth;
				}
			}
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x060015A8 RID: 5544 RVA: 0x00055908 File Offset: 0x00053B08
		// (set) Token: 0x060015A9 RID: 5545 RVA: 0x00055928 File Offset: 0x00053B28
		StyleLength IStyle.bottom
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.Bottom);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.Bottom, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.Bottom = this.ve.computedStyle.bottom.ToYogaValue();
				}
			}
		}

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x060015AA RID: 5546 RVA: 0x0005597C File Offset: 0x00053B7C
		// (set) Token: 0x060015AB RID: 5547 RVA: 0x0005599C File Offset: 0x00053B9C
		StyleColor IStyle.color
		{
			get
			{
				return base.GetStyleColor(StylePropertyId.Color);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.Color, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.StyleSheet | VersionChangeType.Styles | VersionChangeType.Color);
				}
			}
		}

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x060015AC RID: 5548 RVA: 0x000559D0 File Offset: 0x00053BD0
		// (set) Token: 0x060015AD RID: 5549 RVA: 0x00055A04 File Offset: 0x00053C04
		StyleEnum<DisplayStyle> IStyle.display
		{
			get
			{
				StyleInt styleInt = base.GetStyleInt(StylePropertyId.Display);
				return new StyleEnum<DisplayStyle>((DisplayStyle)styleInt.value, styleInt.keyword);
			}
			set
			{
				bool flag = this.SetStyleValue<DisplayStyle>(StylePropertyId.Display, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles | VersionChangeType.Repaint);
					this.ve.yogaNode.Display = (YogaDisplay)this.ve.computedStyle.display;
				}
			}
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x060015AE RID: 5550 RVA: 0x00055A58 File Offset: 0x00053C58
		// (set) Token: 0x060015AF RID: 5551 RVA: 0x00055A78 File Offset: 0x00053C78
		StyleLength IStyle.flexBasis
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.FlexBasis);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.FlexBasis, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.FlexBasis = this.ve.computedStyle.flexBasis.ToYogaValue();
				}
			}
		}

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x060015B0 RID: 5552 RVA: 0x00055ACC File Offset: 0x00053CCC
		// (set) Token: 0x060015B1 RID: 5553 RVA: 0x00055B00 File Offset: 0x00053D00
		StyleEnum<FlexDirection> IStyle.flexDirection
		{
			get
			{
				StyleInt styleInt = base.GetStyleInt(StylePropertyId.FlexDirection);
				return new StyleEnum<FlexDirection>((FlexDirection)styleInt.value, styleInt.keyword);
			}
			set
			{
				bool flag = this.SetStyleValue<FlexDirection>(StylePropertyId.FlexDirection, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.FlexDirection = (YogaFlexDirection)this.ve.computedStyle.flexDirection;
				}
			}
		}

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x060015B2 RID: 5554 RVA: 0x00055B50 File Offset: 0x00053D50
		// (set) Token: 0x060015B3 RID: 5555 RVA: 0x00055B70 File Offset: 0x00053D70
		StyleFloat IStyle.flexGrow
		{
			get
			{
				return base.GetStyleFloat(StylePropertyId.FlexGrow);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.FlexGrow, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.FlexGrow = this.ve.computedStyle.flexGrow;
				}
			}
		}

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x060015B4 RID: 5556 RVA: 0x00055BC0 File Offset: 0x00053DC0
		// (set) Token: 0x060015B5 RID: 5557 RVA: 0x00055BE0 File Offset: 0x00053DE0
		StyleFloat IStyle.flexShrink
		{
			get
			{
				return base.GetStyleFloat(StylePropertyId.FlexShrink);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.FlexShrink, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.FlexShrink = this.ve.computedStyle.flexShrink;
				}
			}
		}

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x060015B6 RID: 5558 RVA: 0x00055C30 File Offset: 0x00053E30
		// (set) Token: 0x060015B7 RID: 5559 RVA: 0x00055C64 File Offset: 0x00053E64
		StyleEnum<Wrap> IStyle.flexWrap
		{
			get
			{
				StyleInt styleInt = base.GetStyleInt(StylePropertyId.FlexWrap);
				return new StyleEnum<Wrap>((Wrap)styleInt.value, styleInt.keyword);
			}
			set
			{
				bool flag = this.SetStyleValue<Wrap>(StylePropertyId.FlexWrap, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.Wrap = (YogaWrap)this.ve.computedStyle.flexWrap;
				}
			}
		}

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x060015B8 RID: 5560 RVA: 0x00055CB4 File Offset: 0x00053EB4
		// (set) Token: 0x060015B9 RID: 5561 RVA: 0x00055CD4 File Offset: 0x00053ED4
		StyleLength IStyle.fontSize
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.FontSize);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.FontSize, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.StyleSheet | VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x060015BA RID: 5562 RVA: 0x00055D08 File Offset: 0x00053F08
		// (set) Token: 0x060015BB RID: 5563 RVA: 0x00055D28 File Offset: 0x00053F28
		StyleLength IStyle.height
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.Height);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.Height, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.Height = this.ve.computedStyle.height.ToYogaValue();
				}
			}
		}

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x060015BC RID: 5564 RVA: 0x00055D7C File Offset: 0x00053F7C
		// (set) Token: 0x060015BD RID: 5565 RVA: 0x00055DB0 File Offset: 0x00053FB0
		StyleEnum<Justify> IStyle.justifyContent
		{
			get
			{
				StyleInt styleInt = base.GetStyleInt(StylePropertyId.JustifyContent);
				return new StyleEnum<Justify>((Justify)styleInt.value, styleInt.keyword);
			}
			set
			{
				bool flag = this.SetStyleValue<Justify>(StylePropertyId.JustifyContent, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.JustifyContent = (YogaJustify)this.ve.computedStyle.justifyContent;
				}
			}
		}

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x060015BE RID: 5566 RVA: 0x00055E00 File Offset: 0x00054000
		// (set) Token: 0x060015BF RID: 5567 RVA: 0x00055E20 File Offset: 0x00054020
		StyleLength IStyle.left
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.Left);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.Left, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.Left = this.ve.computedStyle.left.ToYogaValue();
				}
			}
		}

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x060015C0 RID: 5568 RVA: 0x00055E74 File Offset: 0x00054074
		// (set) Token: 0x060015C1 RID: 5569 RVA: 0x00055E94 File Offset: 0x00054094
		StyleLength IStyle.letterSpacing
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.LetterSpacing);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.LetterSpacing, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.StyleSheet | VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x060015C2 RID: 5570 RVA: 0x00055EC8 File Offset: 0x000540C8
		// (set) Token: 0x060015C3 RID: 5571 RVA: 0x00055EE8 File Offset: 0x000540E8
		StyleLength IStyle.marginBottom
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.MarginBottom);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.MarginBottom, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.MarginBottom = this.ve.computedStyle.marginBottom.ToYogaValue();
				}
			}
		}

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x060015C4 RID: 5572 RVA: 0x00055F3C File Offset: 0x0005413C
		// (set) Token: 0x060015C5 RID: 5573 RVA: 0x00055F5C File Offset: 0x0005415C
		StyleLength IStyle.marginLeft
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.MarginLeft);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.MarginLeft, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.MarginLeft = this.ve.computedStyle.marginLeft.ToYogaValue();
				}
			}
		}

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x060015C6 RID: 5574 RVA: 0x00055FB0 File Offset: 0x000541B0
		// (set) Token: 0x060015C7 RID: 5575 RVA: 0x00055FD0 File Offset: 0x000541D0
		StyleLength IStyle.marginRight
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.MarginRight);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.MarginRight, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.MarginRight = this.ve.computedStyle.marginRight.ToYogaValue();
				}
			}
		}

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x060015C8 RID: 5576 RVA: 0x00056024 File Offset: 0x00054224
		// (set) Token: 0x060015C9 RID: 5577 RVA: 0x00056044 File Offset: 0x00054244
		StyleLength IStyle.marginTop
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.MarginTop);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.MarginTop, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.MarginTop = this.ve.computedStyle.marginTop.ToYogaValue();
				}
			}
		}

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x060015CA RID: 5578 RVA: 0x00056098 File Offset: 0x00054298
		// (set) Token: 0x060015CB RID: 5579 RVA: 0x000560B8 File Offset: 0x000542B8
		StyleLength IStyle.maxHeight
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.MaxHeight);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.MaxHeight, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.MaxHeight = this.ve.computedStyle.maxHeight.ToYogaValue();
				}
			}
		}

		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x060015CC RID: 5580 RVA: 0x0005610C File Offset: 0x0005430C
		// (set) Token: 0x060015CD RID: 5581 RVA: 0x0005612C File Offset: 0x0005432C
		StyleLength IStyle.maxWidth
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.MaxWidth);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.MaxWidth, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.MaxWidth = this.ve.computedStyle.maxWidth.ToYogaValue();
				}
			}
		}

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x060015CE RID: 5582 RVA: 0x00056180 File Offset: 0x00054380
		// (set) Token: 0x060015CF RID: 5583 RVA: 0x000561A0 File Offset: 0x000543A0
		StyleLength IStyle.minHeight
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.MinHeight);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.MinHeight, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.MinHeight = this.ve.computedStyle.minHeight.ToYogaValue();
				}
			}
		}

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x060015D0 RID: 5584 RVA: 0x000561F4 File Offset: 0x000543F4
		// (set) Token: 0x060015D1 RID: 5585 RVA: 0x00056214 File Offset: 0x00054414
		StyleLength IStyle.minWidth
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.MinWidth);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.MinWidth, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.MinWidth = this.ve.computedStyle.minWidth.ToYogaValue();
				}
			}
		}

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x060015D2 RID: 5586 RVA: 0x00056268 File Offset: 0x00054468
		// (set) Token: 0x060015D3 RID: 5587 RVA: 0x00056288 File Offset: 0x00054488
		StyleFloat IStyle.opacity
		{
			get
			{
				return base.GetStyleFloat(StylePropertyId.Opacity);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.Opacity, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Opacity);
				}
			}
		}

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x060015D4 RID: 5588 RVA: 0x000562BC File Offset: 0x000544BC
		// (set) Token: 0x060015D5 RID: 5589 RVA: 0x000562F0 File Offset: 0x000544F0
		StyleEnum<Overflow> IStyle.overflow
		{
			get
			{
				StyleInt styleInt = base.GetStyleInt(StylePropertyId.Overflow);
				return new StyleEnum<Overflow>((Overflow)styleInt.value, styleInt.keyword);
			}
			set
			{
				StyleEnum<OverflowInternal> inlineValue = new StyleEnum<OverflowInternal>((OverflowInternal)value.value, value.keyword);
				bool flag = this.SetStyleValue<OverflowInternal>(StylePropertyId.Overflow, inlineValue);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles | VersionChangeType.Overflow);
					this.ve.yogaNode.Overflow = (YogaOverflow)this.ve.computedStyle.overflow;
				}
			}
		}

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x060015D6 RID: 5590 RVA: 0x00056354 File Offset: 0x00054554
		// (set) Token: 0x060015D7 RID: 5591 RVA: 0x00056374 File Offset: 0x00054574
		StyleLength IStyle.paddingBottom
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.PaddingBottom);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.PaddingBottom, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.PaddingBottom = this.ve.computedStyle.paddingBottom.ToYogaValue();
				}
			}
		}

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x060015D8 RID: 5592 RVA: 0x000563C8 File Offset: 0x000545C8
		// (set) Token: 0x060015D9 RID: 5593 RVA: 0x000563E8 File Offset: 0x000545E8
		StyleLength IStyle.paddingLeft
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.PaddingLeft);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.PaddingLeft, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.PaddingLeft = this.ve.computedStyle.paddingLeft.ToYogaValue();
				}
			}
		}

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x060015DA RID: 5594 RVA: 0x0005643C File Offset: 0x0005463C
		// (set) Token: 0x060015DB RID: 5595 RVA: 0x0005645C File Offset: 0x0005465C
		StyleLength IStyle.paddingRight
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.PaddingRight);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.PaddingRight, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.PaddingRight = this.ve.computedStyle.paddingRight.ToYogaValue();
				}
			}
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x060015DC RID: 5596 RVA: 0x000564B0 File Offset: 0x000546B0
		// (set) Token: 0x060015DD RID: 5597 RVA: 0x000564D0 File Offset: 0x000546D0
		StyleLength IStyle.paddingTop
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.PaddingTop);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.PaddingTop, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.PaddingTop = this.ve.computedStyle.paddingTop.ToYogaValue();
				}
			}
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x060015DE RID: 5598 RVA: 0x00056524 File Offset: 0x00054724
		// (set) Token: 0x060015DF RID: 5599 RVA: 0x00056558 File Offset: 0x00054758
		StyleEnum<Position> IStyle.position
		{
			get
			{
				StyleInt styleInt = base.GetStyleInt(StylePropertyId.Position);
				return new StyleEnum<Position>((Position)styleInt.value, styleInt.keyword);
			}
			set
			{
				bool flag = this.SetStyleValue<Position>(StylePropertyId.Position, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.PositionType = (YogaPositionType)this.ve.computedStyle.position;
				}
			}
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x060015E0 RID: 5600 RVA: 0x000565A8 File Offset: 0x000547A8
		// (set) Token: 0x060015E1 RID: 5601 RVA: 0x000565C8 File Offset: 0x000547C8
		StyleLength IStyle.right
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.Right);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.Right, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.Right = this.ve.computedStyle.right.ToYogaValue();
				}
			}
		}

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x060015E2 RID: 5602 RVA: 0x0005661C File Offset: 0x0005481C
		// (set) Token: 0x060015E3 RID: 5603 RVA: 0x00056650 File Offset: 0x00054850
		StyleEnum<TextOverflow> IStyle.textOverflow
		{
			get
			{
				StyleInt styleInt = base.GetStyleInt(StylePropertyId.TextOverflow);
				return new StyleEnum<TextOverflow>((TextOverflow)styleInt.value, styleInt.keyword);
			}
			set
			{
				bool flag = this.SetStyleValue<TextOverflow>(StylePropertyId.TextOverflow, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x060015E4 RID: 5604 RVA: 0x00056684 File Offset: 0x00054884
		// (set) Token: 0x060015E5 RID: 5605 RVA: 0x000566A4 File Offset: 0x000548A4
		StyleLength IStyle.top
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.Top);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.Top, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.Top = this.ve.computedStyle.top.ToYogaValue();
				}
			}
		}

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x060015E6 RID: 5606 RVA: 0x000566F8 File Offset: 0x000548F8
		// (set) Token: 0x060015E7 RID: 5607 RVA: 0x00056718 File Offset: 0x00054918
		StyleList<TimeValue> IStyle.transitionDelay
		{
			get
			{
				return this.GetStyleList<TimeValue>(StylePropertyId.TransitionDelay);
			}
			set
			{
				bool flag = this.SetStyleValue<TimeValue>(StylePropertyId.TransitionDelay, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.TransitionProperty);
				}
			}
		}

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x060015E8 RID: 5608 RVA: 0x0005674C File Offset: 0x0005494C
		// (set) Token: 0x060015E9 RID: 5609 RVA: 0x0005676C File Offset: 0x0005496C
		StyleList<TimeValue> IStyle.transitionDuration
		{
			get
			{
				return this.GetStyleList<TimeValue>(StylePropertyId.TransitionDuration);
			}
			set
			{
				bool flag = this.SetStyleValue<TimeValue>(StylePropertyId.TransitionDuration, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.TransitionProperty);
				}
			}
		}

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x060015EA RID: 5610 RVA: 0x000567A0 File Offset: 0x000549A0
		// (set) Token: 0x060015EB RID: 5611 RVA: 0x000567C0 File Offset: 0x000549C0
		StyleList<StylePropertyName> IStyle.transitionProperty
		{
			get
			{
				return this.GetStyleList<StylePropertyName>(StylePropertyId.TransitionProperty);
			}
			set
			{
				bool flag = this.SetStyleValue<StylePropertyName>(StylePropertyId.TransitionProperty, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.TransitionProperty);
				}
			}
		}

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x060015EC RID: 5612 RVA: 0x000567F4 File Offset: 0x000549F4
		// (set) Token: 0x060015ED RID: 5613 RVA: 0x00056814 File Offset: 0x00054A14
		StyleList<EasingFunction> IStyle.transitionTimingFunction
		{
			get
			{
				return this.GetStyleList<EasingFunction>(StylePropertyId.TransitionTimingFunction);
			}
			set
			{
				bool flag = this.SetStyleValue<EasingFunction>(StylePropertyId.TransitionTimingFunction, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles);
				}
			}
		}

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x060015EE RID: 5614 RVA: 0x00056844 File Offset: 0x00054A44
		// (set) Token: 0x060015EF RID: 5615 RVA: 0x00056864 File Offset: 0x00054A64
		StyleColor IStyle.unityBackgroundImageTintColor
		{
			get
			{
				return base.GetStyleColor(StylePropertyId.UnityBackgroundImageTintColor);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.UnityBackgroundImageTintColor, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Color);
				}
			}
		}

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x060015F0 RID: 5616 RVA: 0x00056898 File Offset: 0x00054A98
		// (set) Token: 0x060015F1 RID: 5617 RVA: 0x000568B8 File Offset: 0x00054AB8
		StyleFont IStyle.unityFont
		{
			get
			{
				return base.GetStyleFont(StylePropertyId.UnityFont);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.UnityFont, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.StyleSheet | VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x060015F2 RID: 5618 RVA: 0x000568EC File Offset: 0x00054AEC
		// (set) Token: 0x060015F3 RID: 5619 RVA: 0x0005690C File Offset: 0x00054B0C
		StyleFontDefinition IStyle.unityFontDefinition
		{
			get
			{
				return base.GetStyleFontDefinition(StylePropertyId.UnityFontDefinition);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.UnityFontDefinition, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.StyleSheet | VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x060015F4 RID: 5620 RVA: 0x00056940 File Offset: 0x00054B40
		// (set) Token: 0x060015F5 RID: 5621 RVA: 0x00056974 File Offset: 0x00054B74
		StyleEnum<FontStyle> IStyle.unityFontStyleAndWeight
		{
			get
			{
				StyleInt styleInt = base.GetStyleInt(StylePropertyId.UnityFontStyleAndWeight);
				return new StyleEnum<FontStyle>((FontStyle)styleInt.value, styleInt.keyword);
			}
			set
			{
				bool flag = this.SetStyleValue<FontStyle>(StylePropertyId.UnityFontStyleAndWeight, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.StyleSheet | VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x060015F6 RID: 5622 RVA: 0x000569A8 File Offset: 0x00054BA8
		// (set) Token: 0x060015F7 RID: 5623 RVA: 0x000569DC File Offset: 0x00054BDC
		StyleEnum<OverflowClipBox> IStyle.unityOverflowClipBox
		{
			get
			{
				StyleInt styleInt = base.GetStyleInt(StylePropertyId.UnityOverflowClipBox);
				return new StyleEnum<OverflowClipBox>((OverflowClipBox)styleInt.value, styleInt.keyword);
			}
			set
			{
				bool flag = this.SetStyleValue<OverflowClipBox>(StylePropertyId.UnityOverflowClipBox, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x060015F8 RID: 5624 RVA: 0x00056A10 File Offset: 0x00054C10
		// (set) Token: 0x060015F9 RID: 5625 RVA: 0x00056A30 File Offset: 0x00054C30
		StyleLength IStyle.unityParagraphSpacing
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.UnityParagraphSpacing);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.UnityParagraphSpacing, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.StyleSheet | VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x060015FA RID: 5626 RVA: 0x00056A64 File Offset: 0x00054C64
		// (set) Token: 0x060015FB RID: 5627 RVA: 0x00056A84 File Offset: 0x00054C84
		StyleInt IStyle.unitySliceBottom
		{
			get
			{
				return base.GetStyleInt(StylePropertyId.UnitySliceBottom);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.UnitySliceBottom, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x060015FC RID: 5628 RVA: 0x00056AB8 File Offset: 0x00054CB8
		// (set) Token: 0x060015FD RID: 5629 RVA: 0x00056AD8 File Offset: 0x00054CD8
		StyleInt IStyle.unitySliceLeft
		{
			get
			{
				return base.GetStyleInt(StylePropertyId.UnitySliceLeft);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.UnitySliceLeft, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x060015FE RID: 5630 RVA: 0x00056B0C File Offset: 0x00054D0C
		// (set) Token: 0x060015FF RID: 5631 RVA: 0x00056B2C File Offset: 0x00054D2C
		StyleInt IStyle.unitySliceRight
		{
			get
			{
				return base.GetStyleInt(StylePropertyId.UnitySliceRight);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.UnitySliceRight, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06001600 RID: 5632 RVA: 0x00056B60 File Offset: 0x00054D60
		// (set) Token: 0x06001601 RID: 5633 RVA: 0x00056B80 File Offset: 0x00054D80
		StyleFloat IStyle.unitySliceScale
		{
			get
			{
				return base.GetStyleFloat(StylePropertyId.UnitySliceScale);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.UnitySliceScale, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06001602 RID: 5634 RVA: 0x00056BB4 File Offset: 0x00054DB4
		// (set) Token: 0x06001603 RID: 5635 RVA: 0x00056BD4 File Offset: 0x00054DD4
		StyleInt IStyle.unitySliceTop
		{
			get
			{
				return base.GetStyleInt(StylePropertyId.UnitySliceTop);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.UnitySliceTop, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06001604 RID: 5636 RVA: 0x00056C08 File Offset: 0x00054E08
		// (set) Token: 0x06001605 RID: 5637 RVA: 0x00056C3C File Offset: 0x00054E3C
		StyleEnum<TextAnchor> IStyle.unityTextAlign
		{
			get
			{
				StyleInt styleInt = base.GetStyleInt(StylePropertyId.UnityTextAlign);
				return new StyleEnum<TextAnchor>((TextAnchor)styleInt.value, styleInt.keyword);
			}
			set
			{
				bool flag = this.SetStyleValue<TextAnchor>(StylePropertyId.UnityTextAlign, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.StyleSheet | VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06001606 RID: 5638 RVA: 0x00056C70 File Offset: 0x00054E70
		// (set) Token: 0x06001607 RID: 5639 RVA: 0x00056C90 File Offset: 0x00054E90
		StyleColor IStyle.unityTextOutlineColor
		{
			get
			{
				return base.GetStyleColor(StylePropertyId.UnityTextOutlineColor);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.UnityTextOutlineColor, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.StyleSheet | VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x06001608 RID: 5640 RVA: 0x00056CC4 File Offset: 0x00054EC4
		// (set) Token: 0x06001609 RID: 5641 RVA: 0x00056CE4 File Offset: 0x00054EE4
		StyleFloat IStyle.unityTextOutlineWidth
		{
			get
			{
				return base.GetStyleFloat(StylePropertyId.UnityTextOutlineWidth);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.UnityTextOutlineWidth, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.StyleSheet | VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x0600160A RID: 5642 RVA: 0x00056D18 File Offset: 0x00054F18
		// (set) Token: 0x0600160B RID: 5643 RVA: 0x00056D4C File Offset: 0x00054F4C
		StyleEnum<TextOverflowPosition> IStyle.unityTextOverflowPosition
		{
			get
			{
				StyleInt styleInt = base.GetStyleInt(StylePropertyId.UnityTextOverflowPosition);
				return new StyleEnum<TextOverflowPosition>((TextOverflowPosition)styleInt.value, styleInt.keyword);
			}
			set
			{
				bool flag = this.SetStyleValue<TextOverflowPosition>(StylePropertyId.UnityTextOverflowPosition, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x0600160C RID: 5644 RVA: 0x00056D80 File Offset: 0x00054F80
		// (set) Token: 0x0600160D RID: 5645 RVA: 0x00056DB4 File Offset: 0x00054FB4
		StyleEnum<Visibility> IStyle.visibility
		{
			get
			{
				StyleInt styleInt = base.GetStyleInt(StylePropertyId.Visibility);
				return new StyleEnum<Visibility>((Visibility)styleInt.value, styleInt.keyword);
			}
			set
			{
				bool flag = this.SetStyleValue<Visibility>(StylePropertyId.Visibility, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.StyleSheet | VersionChangeType.Styles | VersionChangeType.Repaint | VersionChangeType.Picking);
				}
			}
		}

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x0600160E RID: 5646 RVA: 0x00056DE8 File Offset: 0x00054FE8
		// (set) Token: 0x0600160F RID: 5647 RVA: 0x00056E1C File Offset: 0x0005501C
		StyleEnum<WhiteSpace> IStyle.whiteSpace
		{
			get
			{
				StyleInt styleInt = base.GetStyleInt(StylePropertyId.WhiteSpace);
				return new StyleEnum<WhiteSpace>((WhiteSpace)styleInt.value, styleInt.keyword);
			}
			set
			{
				bool flag = this.SetStyleValue<WhiteSpace>(StylePropertyId.WhiteSpace, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.StyleSheet | VersionChangeType.Styles);
				}
			}
		}

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06001610 RID: 5648 RVA: 0x00056E4C File Offset: 0x0005504C
		// (set) Token: 0x06001611 RID: 5649 RVA: 0x00056E6C File Offset: 0x0005506C
		StyleLength IStyle.width
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.Width);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.Width, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles);
					this.ve.yogaNode.Width = this.ve.computedStyle.width.ToYogaValue();
				}
			}
		}

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x06001612 RID: 5650 RVA: 0x00056EC0 File Offset: 0x000550C0
		// (set) Token: 0x06001613 RID: 5651 RVA: 0x00056EE0 File Offset: 0x000550E0
		StyleLength IStyle.wordSpacing
		{
			get
			{
				return base.GetStyleLength(StylePropertyId.WordSpacing);
			}
			set
			{
				bool flag = this.SetStyleValue(StylePropertyId.WordSpacing, value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.StyleSheet | VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x06001614 RID: 5652 RVA: 0x00056F11 File Offset: 0x00055111
		// (set) Token: 0x06001615 RID: 5653 RVA: 0x00056F19 File Offset: 0x00055119
		private VisualElement ve { get; set; }

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x06001616 RID: 5654 RVA: 0x00056F22 File Offset: 0x00055122
		public InlineStyleAccess.InlineRule inlineRule
		{
			get
			{
				return this.m_InlineRule;
			}
		}

		// Token: 0x06001617 RID: 5655 RVA: 0x00056F2A File Offset: 0x0005512A
		public InlineStyleAccess(VisualElement ve)
		{
			this.ve = ve;
		}

		// Token: 0x06001618 RID: 5656 RVA: 0x00056F3C File Offset: 0x0005513C
		protected override void Finalize()
		{
			try
			{
				StyleValue styleValue = default(StyleValue);
				bool flag = base.TryGetStyleValue(StylePropertyId.BackgroundImage, ref styleValue);
				if (flag)
				{
					bool isAllocated = styleValue.resource.IsAllocated;
					if (isAllocated)
					{
						styleValue.resource.Free();
					}
				}
				bool flag2 = base.TryGetStyleValue(StylePropertyId.UnityFont, ref styleValue);
				if (flag2)
				{
					bool isAllocated2 = styleValue.resource.IsAllocated;
					if (isAllocated2)
					{
						styleValue.resource.Free();
					}
				}
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x06001619 RID: 5657 RVA: 0x00056FD0 File Offset: 0x000551D0
		public void SetInlineRule(StyleSheet sheet, StyleRule rule)
		{
			this.m_InlineRule.sheet = sheet;
			this.m_InlineRule.rule = rule;
			this.m_InlineRule.propertyIds = StyleSheetCache.GetPropertyIds(rule);
			this.ApplyInlineStyles(this.ve.computedStyle);
		}

		// Token: 0x0600161A RID: 5658 RVA: 0x00057010 File Offset: 0x00055210
		public bool IsValueSet(StylePropertyId id)
		{
			foreach (StyleValue styleValue in this.m_Values)
			{
				bool flag = styleValue.id == id;
				if (flag)
				{
					return true;
				}
			}
			bool flag2 = this.m_ValuesManaged != null;
			if (flag2)
			{
				foreach (StyleValueManaged styleValueManaged in this.m_ValuesManaged)
				{
					bool flag3 = styleValueManaged.id == id;
					if (flag3)
					{
						return true;
					}
				}
			}
			if (id <= StylePropertyId.Cursor)
			{
				if (id == StylePropertyId.TextShadow)
				{
					return this.m_HasInlineTextShadow;
				}
				if (id == StylePropertyId.Cursor)
				{
					return this.m_HasInlineCursor;
				}
			}
			else
			{
				switch (id)
				{
				case StylePropertyId.Rotate:
					return this.m_HasInlineRotate;
				case StylePropertyId.Scale:
					return this.m_HasInlineScale;
				case StylePropertyId.TransformOrigin:
					return this.m_HasInlineTransformOrigin;
				case StylePropertyId.Translate:
					return this.m_HasInlineTranslate;
				default:
					if (id == StylePropertyId.BackgroundSize)
					{
						return this.m_HasInlineBackgroundSize;
					}
					break;
				}
			}
			return false;
		}

		// Token: 0x0600161B RID: 5659 RVA: 0x00057174 File Offset: 0x00055374
		public void ApplyInlineStyles(ref ComputedStyle computedStyle)
		{
			VisualElement parent = this.ve.hierarchy.parent;
			ComputedStyle ptr;
			if (parent != null)
			{
				ref ComputedStyle computedStyle2 = ref parent.computedStyle;
				ptr = parent.computedStyle;
			}
			else
			{
				ptr = InitialStyle.Get();
			}
			ref ComputedStyle parentStyle = ref ptr;
			bool flag = this.m_InlineRule.sheet != null;
			if (flag)
			{
				InlineStyleAccess.s_StylePropertyReader.SetInlineContext(this.m_InlineRule.sheet, this.m_InlineRule.rule.properties, this.m_InlineRule.propertyIds, 1f);
				computedStyle.ApplyProperties(InlineStyleAccess.s_StylePropertyReader, ref parentStyle);
			}
			foreach (StyleValue sv in this.m_Values)
			{
				computedStyle.ApplyStyleValue(sv, ref parentStyle);
			}
			bool flag2 = this.m_ValuesManaged != null;
			if (flag2)
			{
				foreach (StyleValueManaged sv2 in this.m_ValuesManaged)
				{
					computedStyle.ApplyStyleValueManaged(sv2, ref parentStyle);
				}
			}
			bool flag3 = this.ve.style.cursor.keyword != StyleKeyword.Null;
			if (flag3)
			{
				computedStyle.ApplyStyleCursor(this.ve.style.cursor.value);
			}
			bool flag4 = this.ve.style.textShadow.keyword != StyleKeyword.Null;
			if (flag4)
			{
				computedStyle.ApplyStyleTextShadow(this.ve.style.textShadow.value);
			}
			bool hasInlineTransformOrigin = this.m_HasInlineTransformOrigin;
			if (hasInlineTransformOrigin)
			{
				computedStyle.ApplyStyleTransformOrigin(this.ve.style.transformOrigin.value);
			}
			bool hasInlineTranslate = this.m_HasInlineTranslate;
			if (hasInlineTranslate)
			{
				computedStyle.ApplyStyleTranslate(this.ve.style.translate.value);
			}
			bool hasInlineScale = this.m_HasInlineScale;
			if (hasInlineScale)
			{
				computedStyle.ApplyStyleScale(this.ve.style.scale.value);
			}
			bool hasInlineRotate = this.m_HasInlineRotate;
			if (hasInlineRotate)
			{
				computedStyle.ApplyStyleRotate(this.ve.style.rotate.value);
			}
			bool hasInlineBackgroundSize = this.m_HasInlineBackgroundSize;
			if (hasInlineBackgroundSize)
			{
				computedStyle.ApplyStyleBackgroundSize(this.ve.style.backgroundSize.value);
			}
		}

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x0600161C RID: 5660 RVA: 0x0005742C File Offset: 0x0005562C
		// (set) Token: 0x0600161D RID: 5661 RVA: 0x0005745C File Offset: 0x0005565C
		StyleCursor IStyle.cursor
		{
			get
			{
				StyleCursor styleCursor = default(StyleCursor);
				bool flag = this.TryGetInlineCursor(ref styleCursor);
				StyleCursor result;
				if (flag)
				{
					result = styleCursor;
				}
				else
				{
					result = StyleKeyword.Null;
				}
				return result;
			}
			set
			{
				bool flag = this.SetInlineCursor(value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles);
				}
			}
		}

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x0600161E RID: 5662 RVA: 0x00057488 File Offset: 0x00055688
		// (set) Token: 0x0600161F RID: 5663 RVA: 0x000574B8 File Offset: 0x000556B8
		StyleTextShadow IStyle.textShadow
		{
			get
			{
				StyleTextShadow styleTextShadow = default(StyleTextShadow);
				bool flag = this.TryGetInlineTextShadow(ref styleTextShadow);
				StyleTextShadow result;
				if (flag)
				{
					result = styleTextShadow;
				}
				else
				{
					result = StyleKeyword.Null;
				}
				return result;
			}
			set
			{
				bool flag = this.SetInlineTextShadow(value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06001620 RID: 5664 RVA: 0x000574E4 File Offset: 0x000556E4
		// (set) Token: 0x06001621 RID: 5665 RVA: 0x00057514 File Offset: 0x00055714
		StyleBackgroundSize IStyle.backgroundSize
		{
			get
			{
				StyleBackgroundSize styleBackgroundSize = default(StyleBackgroundSize);
				bool flag = this.TryGetInlineBackgroundSize(ref styleBackgroundSize);
				StyleBackgroundSize result;
				if (flag)
				{
					result = styleBackgroundSize;
				}
				else
				{
					result = StyleKeyword.Null;
				}
				return result;
			}
			set
			{
				bool flag = this.SetInlineBackgroundSize(value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x06001622 RID: 5666 RVA: 0x00057540 File Offset: 0x00055740
		private StyleList<T> GetStyleList<T>(StylePropertyId id)
		{
			StyleValueManaged styleValueManaged = default(StyleValueManaged);
			bool flag = this.TryGetStyleValueManaged(id, ref styleValueManaged);
			StyleList<T> result;
			if (flag)
			{
				result = new StyleList<T>(styleValueManaged.value as List<T>, styleValueManaged.keyword);
			}
			else
			{
				result = StyleKeyword.Null;
			}
			return result;
		}

		// Token: 0x06001623 RID: 5667 RVA: 0x00057588 File Offset: 0x00055788
		private void SetStyleValueManaged(StyleValueManaged value)
		{
			bool flag = this.m_ValuesManaged == null;
			if (flag)
			{
				this.m_ValuesManaged = new List<StyleValueManaged>();
			}
			for (int i = 0; i < this.m_ValuesManaged.Count; i++)
			{
				bool flag2 = this.m_ValuesManaged[i].id == value.id;
				if (flag2)
				{
					bool flag3 = value.keyword == StyleKeyword.Null;
					if (flag3)
					{
						this.m_ValuesManaged.RemoveAt(i);
					}
					else
					{
						this.m_ValuesManaged[i] = value;
					}
					return;
				}
			}
			this.m_ValuesManaged.Add(value);
		}

		// Token: 0x06001624 RID: 5668 RVA: 0x00057628 File Offset: 0x00055828
		private bool TryGetStyleValueManaged(StylePropertyId id, ref StyleValueManaged value)
		{
			value.id = StylePropertyId.Unknown;
			bool flag = this.m_ValuesManaged == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				foreach (StyleValueManaged styleValueManaged in this.m_ValuesManaged)
				{
					bool flag2 = styleValueManaged.id == id;
					if (flag2)
					{
						value = styleValueManaged;
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06001625 RID: 5669 RVA: 0x000576B4 File Offset: 0x000558B4
		// (set) Token: 0x06001626 RID: 5670 RVA: 0x000576E4 File Offset: 0x000558E4
		StyleTransformOrigin IStyle.transformOrigin
		{
			get
			{
				StyleTransformOrigin styleTransformOrigin = default(StyleTransformOrigin);
				bool flag = this.TryGetInlineTransformOrigin(ref styleTransformOrigin);
				StyleTransformOrigin result;
				if (flag)
				{
					result = styleTransformOrigin;
				}
				else
				{
					result = StyleKeyword.Null;
				}
				return result;
			}
			set
			{
				bool flag = this.SetInlineTransformOrigin(value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Transform);
				}
			}
		}

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06001627 RID: 5671 RVA: 0x00057710 File Offset: 0x00055910
		// (set) Token: 0x06001628 RID: 5672 RVA: 0x00057740 File Offset: 0x00055940
		StyleTranslate IStyle.translate
		{
			get
			{
				StyleTranslate styleTranslate = default(StyleTranslate);
				bool flag = this.TryGetInlineTranslate(ref styleTranslate);
				StyleTranslate result;
				if (flag)
				{
					result = styleTranslate;
				}
				else
				{
					result = StyleKeyword.Null;
				}
				return result;
			}
			set
			{
				bool flag = this.SetInlineTranslate(value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Transform);
				}
			}
		}

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x06001629 RID: 5673 RVA: 0x0005776C File Offset: 0x0005596C
		// (set) Token: 0x0600162A RID: 5674 RVA: 0x0005779C File Offset: 0x0005599C
		StyleRotate IStyle.rotate
		{
			get
			{
				StyleRotate styleRotate = default(StyleRotate);
				bool flag = this.TryGetInlineRotate(ref styleRotate);
				StyleRotate result;
				if (flag)
				{
					result = styleRotate;
				}
				else
				{
					result = StyleKeyword.Null;
				}
				return result;
			}
			set
			{
				bool flag = this.SetInlineRotate(value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Transform);
				}
			}
		}

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x0600162B RID: 5675 RVA: 0x000577C8 File Offset: 0x000559C8
		// (set) Token: 0x0600162C RID: 5676 RVA: 0x000577F8 File Offset: 0x000559F8
		StyleScale IStyle.scale
		{
			get
			{
				StyleScale styleScale = default(StyleScale);
				bool flag = this.TryGetInlineScale(ref styleScale);
				StyleScale result;
				if (flag)
				{
					result = styleScale;
				}
				else
				{
					result = StyleKeyword.Null;
				}
				return result;
			}
			set
			{
				bool flag = this.SetInlineScale(value);
				if (flag)
				{
					this.ve.IncrementVersion(VersionChangeType.Styles | VersionChangeType.Transform);
				}
			}
		}

		// Token: 0x0600162D RID: 5677 RVA: 0x00057824 File Offset: 0x00055A24
		private bool SetStyleValue(StylePropertyId id, StyleBackgroundPosition inlineValue)
		{
			StyleValue styleValue = default(StyleValue);
			bool flag = base.TryGetStyleValue(id, ref styleValue);
			if (flag)
			{
				bool flag2 = styleValue.position == inlineValue.value && styleValue.keyword == inlineValue.keyword;
				if (flag2)
				{
					return false;
				}
			}
			else
			{
				bool flag3 = inlineValue.keyword == StyleKeyword.Null;
				if (flag3)
				{
					return false;
				}
			}
			styleValue.id = id;
			styleValue.keyword = inlineValue.keyword;
			styleValue.position = inlineValue.value;
			base.SetStyleValue(styleValue);
			bool flag4 = inlineValue.keyword == StyleKeyword.Null;
			bool result;
			if (flag4)
			{
				result = this.RemoveInlineStyle(id);
			}
			else
			{
				this.ApplyStyleValue(styleValue);
				result = true;
			}
			return result;
		}

		// Token: 0x0600162E RID: 5678 RVA: 0x000578E4 File Offset: 0x00055AE4
		private bool SetStyleValue(StylePropertyId id, StyleBackgroundRepeat inlineValue)
		{
			StyleValue styleValue = default(StyleValue);
			bool flag = base.TryGetStyleValue(id, ref styleValue);
			if (flag)
			{
				bool flag2 = styleValue.repeat == inlineValue.value && styleValue.keyword == inlineValue.keyword;
				if (flag2)
				{
					return false;
				}
			}
			else
			{
				bool flag3 = inlineValue.keyword == StyleKeyword.Null;
				if (flag3)
				{
					return false;
				}
			}
			styleValue.id = id;
			styleValue.keyword = inlineValue.keyword;
			styleValue.repeat = inlineValue.value;
			base.SetStyleValue(styleValue);
			bool flag4 = inlineValue.keyword == StyleKeyword.Null;
			bool result;
			if (flag4)
			{
				result = this.RemoveInlineStyle(id);
			}
			else
			{
				this.ApplyStyleValue(styleValue);
				result = true;
			}
			return result;
		}

		// Token: 0x0600162F RID: 5679 RVA: 0x000579A4 File Offset: 0x00055BA4
		private bool SetStyleValue(StylePropertyId id, StyleLength inlineValue)
		{
			StyleValue styleValue = default(StyleValue);
			bool flag = base.TryGetStyleValue(id, ref styleValue);
			if (flag)
			{
				bool flag2 = styleValue.length == inlineValue.ToLength() && styleValue.keyword == inlineValue.keyword;
				if (flag2)
				{
					return false;
				}
			}
			else
			{
				bool flag3 = inlineValue.keyword == StyleKeyword.Null;
				if (flag3)
				{
					return false;
				}
			}
			styleValue.id = id;
			styleValue.keyword = inlineValue.keyword;
			styleValue.length = inlineValue.ToLength();
			base.SetStyleValue(styleValue);
			bool flag4 = inlineValue.keyword == StyleKeyword.Null;
			bool result;
			if (flag4)
			{
				result = this.RemoveInlineStyle(id);
			}
			else
			{
				this.ApplyStyleValue(styleValue);
				result = true;
			}
			return result;
		}

		// Token: 0x06001630 RID: 5680 RVA: 0x00057A60 File Offset: 0x00055C60
		private bool SetStyleValue(StylePropertyId id, StyleFloat inlineValue)
		{
			StyleValue styleValue = default(StyleValue);
			bool flag = base.TryGetStyleValue(id, ref styleValue);
			if (flag)
			{
				bool flag2 = styleValue.number == inlineValue.value && styleValue.keyword == inlineValue.keyword;
				if (flag2)
				{
					return false;
				}
			}
			else
			{
				bool flag3 = inlineValue.keyword == StyleKeyword.Null;
				if (flag3)
				{
					return false;
				}
			}
			styleValue.id = id;
			styleValue.keyword = inlineValue.keyword;
			styleValue.number = inlineValue.value;
			base.SetStyleValue(styleValue);
			bool flag4 = inlineValue.keyword == StyleKeyword.Null;
			bool result;
			if (flag4)
			{
				result = this.RemoveInlineStyle(id);
			}
			else
			{
				this.ApplyStyleValue(styleValue);
				result = true;
			}
			return result;
		}

		// Token: 0x06001631 RID: 5681 RVA: 0x00057B18 File Offset: 0x00055D18
		private bool SetStyleValue(StylePropertyId id, StyleInt inlineValue)
		{
			StyleValue styleValue = default(StyleValue);
			bool flag = base.TryGetStyleValue(id, ref styleValue);
			if (flag)
			{
				bool flag2 = styleValue.number == (float)inlineValue.value && styleValue.keyword == inlineValue.keyword;
				if (flag2)
				{
					return false;
				}
			}
			else
			{
				bool flag3 = inlineValue.keyword == StyleKeyword.Null;
				if (flag3)
				{
					return false;
				}
			}
			styleValue.id = id;
			styleValue.keyword = inlineValue.keyword;
			styleValue.number = (float)inlineValue.value;
			base.SetStyleValue(styleValue);
			bool flag4 = inlineValue.keyword == StyleKeyword.Null;
			bool result;
			if (flag4)
			{
				result = this.RemoveInlineStyle(id);
			}
			else
			{
				this.ApplyStyleValue(styleValue);
				result = true;
			}
			return result;
		}

		// Token: 0x06001632 RID: 5682 RVA: 0x00057BD4 File Offset: 0x00055DD4
		private bool SetStyleValue(StylePropertyId id, StyleColor inlineValue)
		{
			StyleValue styleValue = default(StyleValue);
			bool flag = base.TryGetStyleValue(id, ref styleValue);
			if (flag)
			{
				bool flag2 = styleValue.color == inlineValue.value && styleValue.keyword == inlineValue.keyword;
				if (flag2)
				{
					return false;
				}
			}
			else
			{
				bool flag3 = inlineValue.keyword == StyleKeyword.Null;
				if (flag3)
				{
					return false;
				}
			}
			styleValue.id = id;
			styleValue.keyword = inlineValue.keyword;
			styleValue.color = inlineValue.value;
			base.SetStyleValue(styleValue);
			bool flag4 = inlineValue.keyword == StyleKeyword.Null;
			bool result;
			if (flag4)
			{
				result = this.RemoveInlineStyle(id);
			}
			else
			{
				this.ApplyStyleValue(styleValue);
				result = true;
			}
			return result;
		}

		// Token: 0x06001633 RID: 5683 RVA: 0x00057C94 File Offset: 0x00055E94
		private bool SetStyleValue<T>(StylePropertyId id, StyleEnum<T> inlineValue) where T : struct, IConvertible
		{
			StyleValue styleValue = default(StyleValue);
			int num = UnsafeUtility.EnumToInt<T>(inlineValue.value);
			bool flag = base.TryGetStyleValue(id, ref styleValue);
			if (flag)
			{
				bool flag2 = styleValue.number == (float)num && styleValue.keyword == inlineValue.keyword;
				if (flag2)
				{
					return false;
				}
			}
			else
			{
				bool flag3 = inlineValue.keyword == StyleKeyword.Null;
				if (flag3)
				{
					return false;
				}
			}
			styleValue.id = id;
			styleValue.keyword = inlineValue.keyword;
			styleValue.number = (float)num;
			base.SetStyleValue(styleValue);
			bool flag4 = inlineValue.keyword == StyleKeyword.Null;
			bool result;
			if (flag4)
			{
				result = this.RemoveInlineStyle(id);
			}
			else
			{
				this.ApplyStyleValue(styleValue);
				result = true;
			}
			return result;
		}

		// Token: 0x06001634 RID: 5684 RVA: 0x00057D54 File Offset: 0x00055F54
		private bool SetStyleValue(StylePropertyId id, StyleBackground inlineValue)
		{
			StyleValue styleValue = default(StyleValue);
			bool flag = base.TryGetStyleValue(id, ref styleValue);
			if (flag)
			{
				VectorImage x = styleValue.resource.IsAllocated ? (styleValue.resource.Target as VectorImage) : null;
				Sprite x2 = styleValue.resource.IsAllocated ? (styleValue.resource.Target as Sprite) : null;
				Texture2D x3 = styleValue.resource.IsAllocated ? (styleValue.resource.Target as Texture2D) : null;
				RenderTexture x4 = styleValue.resource.IsAllocated ? (styleValue.resource.Target as RenderTexture) : null;
				bool flag2 = x == inlineValue.value.vectorImage && x3 == inlineValue.value.texture && x2 == inlineValue.value.sprite && x4 == inlineValue.value.renderTexture && styleValue.keyword == inlineValue.keyword;
				if (flag2)
				{
					return false;
				}
				bool isAllocated = styleValue.resource.IsAllocated;
				if (isAllocated)
				{
					styleValue.resource.Free();
				}
			}
			else
			{
				bool flag3 = inlineValue.keyword == StyleKeyword.Null;
				if (flag3)
				{
					return false;
				}
			}
			styleValue.id = id;
			styleValue.keyword = inlineValue.keyword;
			bool flag4 = inlineValue.value.vectorImage != null;
			if (flag4)
			{
				styleValue.resource = GCHandle.Alloc(inlineValue.value.vectorImage);
			}
			else
			{
				bool flag5 = inlineValue.value.sprite != null;
				if (flag5)
				{
					styleValue.resource = GCHandle.Alloc(inlineValue.value.sprite);
				}
				else
				{
					bool flag6 = inlineValue.value.texture != null;
					if (flag6)
					{
						styleValue.resource = GCHandle.Alloc(inlineValue.value.texture);
					}
					else
					{
						bool flag7 = inlineValue.value.renderTexture != null;
						if (flag7)
						{
							styleValue.resource = GCHandle.Alloc(inlineValue.value.renderTexture);
						}
						else
						{
							styleValue.resource = default(GCHandle);
						}
					}
				}
			}
			base.SetStyleValue(styleValue);
			bool flag8 = inlineValue.keyword == StyleKeyword.Null;
			bool result;
			if (flag8)
			{
				result = this.RemoveInlineStyle(id);
			}
			else
			{
				this.ApplyStyleValue(styleValue);
				result = true;
			}
			return result;
		}

		// Token: 0x06001635 RID: 5685 RVA: 0x0005800C File Offset: 0x0005620C
		private bool SetStyleValue(StylePropertyId id, StyleFontDefinition inlineValue)
		{
			StyleValue styleValue = default(StyleValue);
			bool flag = base.TryGetStyleValue(id, ref styleValue);
			if (flag)
			{
				Font x = styleValue.resource.IsAllocated ? (styleValue.resource.Target as Font) : null;
				FontAsset x2 = styleValue.resource.IsAllocated ? (styleValue.resource.Target as FontAsset) : null;
				bool flag2 = x == inlineValue.value.font && x2 == inlineValue.value.fontAsset && styleValue.keyword == inlineValue.keyword;
				if (flag2)
				{
					return false;
				}
				bool isAllocated = styleValue.resource.IsAllocated;
				if (isAllocated)
				{
					styleValue.resource.Free();
				}
			}
			else
			{
				bool flag3 = inlineValue.keyword == StyleKeyword.Null;
				if (flag3)
				{
					return false;
				}
			}
			styleValue.id = id;
			styleValue.keyword = inlineValue.keyword;
			bool flag4 = inlineValue.value.font != null;
			if (flag4)
			{
				styleValue.resource = GCHandle.Alloc(inlineValue.value.font);
			}
			else
			{
				bool flag5 = inlineValue.value.fontAsset != null;
				if (flag5)
				{
					styleValue.resource = GCHandle.Alloc(inlineValue.value.fontAsset);
				}
				else
				{
					styleValue.resource = default(GCHandle);
				}
			}
			base.SetStyleValue(styleValue);
			bool flag6 = inlineValue.keyword == StyleKeyword.Null;
			bool result;
			if (flag6)
			{
				result = this.RemoveInlineStyle(id);
			}
			else
			{
				this.ApplyStyleValue(styleValue);
				result = true;
			}
			return result;
		}

		// Token: 0x06001636 RID: 5686 RVA: 0x000581D0 File Offset: 0x000563D0
		private bool SetStyleValue(StylePropertyId id, StyleFont inlineValue)
		{
			StyleValue styleValue = default(StyleValue);
			bool flag = base.TryGetStyleValue(id, ref styleValue);
			if (flag)
			{
				Font x = styleValue.resource.IsAllocated ? (styleValue.resource.Target as Font) : null;
				bool flag2 = x == inlineValue.value && styleValue.keyword == inlineValue.keyword;
				if (flag2)
				{
					return false;
				}
				bool isAllocated = styleValue.resource.IsAllocated;
				if (isAllocated)
				{
					styleValue.resource.Free();
				}
			}
			else
			{
				bool flag3 = inlineValue.keyword == StyleKeyword.Null;
				if (flag3)
				{
					return false;
				}
			}
			styleValue.id = id;
			styleValue.keyword = inlineValue.keyword;
			styleValue.resource = ((inlineValue.value != null) ? GCHandle.Alloc(inlineValue.value) : default(GCHandle));
			base.SetStyleValue(styleValue);
			bool flag4 = inlineValue.keyword == StyleKeyword.Null;
			bool result;
			if (flag4)
			{
				result = this.RemoveInlineStyle(id);
			}
			else
			{
				this.ApplyStyleValue(styleValue);
				result = true;
			}
			return result;
		}

		// Token: 0x06001637 RID: 5687 RVA: 0x000582F4 File Offset: 0x000564F4
		private bool SetStyleValue<T>(StylePropertyId id, StyleList<T> inlineValue)
		{
			StyleValueManaged styleValueManaged = default(StyleValueManaged);
			bool flag = this.TryGetStyleValueManaged(id, ref styleValueManaged);
			if (flag)
			{
				bool flag2 = styleValueManaged.keyword == inlineValue.keyword;
				if (flag2)
				{
					bool flag3 = styleValueManaged.value == null && inlineValue.value == null;
					if (flag3)
					{
						return false;
					}
					List<T> list = styleValueManaged.value as List<T>;
					bool flag4 = list != null && inlineValue.value != null && list.SequenceEqual(inlineValue.value);
					if (flag4)
					{
						return false;
					}
				}
			}
			else
			{
				bool flag5 = inlineValue.keyword == StyleKeyword.Null;
				if (flag5)
				{
					return false;
				}
			}
			styleValueManaged.id = id;
			styleValueManaged.keyword = inlineValue.keyword;
			bool flag6 = inlineValue.value != null;
			if (flag6)
			{
				bool flag7 = styleValueManaged.value == null;
				if (flag7)
				{
					styleValueManaged.value = new List<T>(inlineValue.value);
				}
				else
				{
					List<T> list2 = (List<T>)styleValueManaged.value;
					list2.Clear();
					list2.AddRange(inlineValue.value);
				}
			}
			else
			{
				styleValueManaged.value = null;
			}
			this.SetStyleValueManaged(styleValueManaged);
			bool flag8 = inlineValue.keyword == StyleKeyword.Null;
			bool result;
			if (flag8)
			{
				result = this.RemoveInlineStyle(id);
			}
			else
			{
				this.ApplyStyleValue(styleValueManaged);
				result = true;
			}
			return result;
		}

		// Token: 0x06001638 RID: 5688 RVA: 0x00058454 File Offset: 0x00056654
		private bool SetInlineCursor(StyleCursor inlineValue)
		{
			StyleCursor styleCursor = default(StyleCursor);
			bool flag = this.TryGetInlineCursor(ref styleCursor);
			if (flag)
			{
				bool flag2 = styleCursor.value == inlineValue.value && styleCursor.keyword == inlineValue.keyword;
				if (flag2)
				{
					return false;
				}
			}
			else
			{
				bool flag3 = inlineValue.keyword == StyleKeyword.Null;
				if (flag3)
				{
					return false;
				}
			}
			styleCursor.value = inlineValue.value;
			styleCursor.keyword = inlineValue.keyword;
			bool flag4 = inlineValue.keyword == StyleKeyword.Null;
			bool result;
			if (flag4)
			{
				this.m_HasInlineCursor = false;
				result = this.RemoveInlineStyle(StylePropertyId.Cursor);
			}
			else
			{
				this.m_InlineCursor = styleCursor;
				this.m_HasInlineCursor = true;
				this.ApplyStyleCursor(styleCursor);
				result = true;
			}
			return result;
		}

		// Token: 0x06001639 RID: 5689 RVA: 0x00058520 File Offset: 0x00056720
		private void ApplyStyleCursor(StyleCursor cursor)
		{
			this.ve.computedStyle.ApplyStyleCursor(cursor.value);
			BaseVisualElementPanel elementPanel = this.ve.elementPanel;
			bool flag = ((elementPanel != null) ? elementPanel.GetTopElementUnderPointer(PointerId.mousePointerId) : null) == this.ve;
			if (flag)
			{
				this.ve.elementPanel.cursorManager.SetCursor(cursor.value);
			}
		}

		// Token: 0x0600163A RID: 5690 RVA: 0x0005858C File Offset: 0x0005678C
		private bool SetInlineTextShadow(StyleTextShadow inlineValue)
		{
			StyleTextShadow styleTextShadow = default(StyleTextShadow);
			bool flag = this.TryGetInlineTextShadow(ref styleTextShadow);
			if (flag)
			{
				bool flag2 = styleTextShadow.value == inlineValue.value && styleTextShadow.keyword == inlineValue.keyword;
				if (flag2)
				{
					return false;
				}
			}
			else
			{
				bool flag3 = inlineValue.keyword == StyleKeyword.Null;
				if (flag3)
				{
					return false;
				}
			}
			styleTextShadow.value = inlineValue.value;
			styleTextShadow.keyword = inlineValue.keyword;
			bool flag4 = inlineValue.keyword == StyleKeyword.Null;
			bool result;
			if (flag4)
			{
				this.m_HasInlineTextShadow = false;
				result = this.RemoveInlineStyle(StylePropertyId.TextShadow);
			}
			else
			{
				this.m_InlineTextShadow = styleTextShadow;
				this.m_HasInlineTextShadow = true;
				this.ApplyStyleTextShadow(styleTextShadow);
				result = true;
			}
			return result;
		}

		// Token: 0x0600163B RID: 5691 RVA: 0x00058658 File Offset: 0x00056858
		private void ApplyStyleTextShadow(StyleTextShadow textShadow)
		{
			ComputedTransitionUtils.UpdateComputedTransitions(this.ve.computedStyle);
			bool flag = false;
			ComputedTransitionProperty computedTransitionProperty;
			bool flag2 = this.ve.computedStyle.hasTransition && this.ve.styleInitialized && this.ve.computedStyle.GetTransitionProperty(StylePropertyId.TextShadow, out computedTransitionProperty);
			if (flag2)
			{
				flag = ComputedStyle.StartAnimationInlineTextShadow(this.ve, this.ve.computedStyle, textShadow, computedTransitionProperty.durationMs, computedTransitionProperty.delayMs, computedTransitionProperty.easingCurve);
			}
			else
			{
				this.ve.styleAnimation.CancelAnimation(StylePropertyId.TextShadow);
			}
			bool flag3 = !flag;
			if (flag3)
			{
				this.ve.computedStyle.ApplyStyleTextShadow(textShadow.value);
			}
		}

		// Token: 0x0600163C RID: 5692 RVA: 0x00058720 File Offset: 0x00056920
		private bool SetInlineTransformOrigin(StyleTransformOrigin inlineValue)
		{
			StyleTransformOrigin styleTransformOrigin = default(StyleTransformOrigin);
			bool flag = this.TryGetInlineTransformOrigin(ref styleTransformOrigin);
			if (flag)
			{
				bool flag2 = styleTransformOrigin.value == inlineValue.value && styleTransformOrigin.keyword == inlineValue.keyword;
				if (flag2)
				{
					return false;
				}
			}
			else
			{
				bool flag3 = inlineValue.keyword == StyleKeyword.Null;
				if (flag3)
				{
					return false;
				}
			}
			bool flag4 = inlineValue.keyword == StyleKeyword.Null;
			bool result;
			if (flag4)
			{
				this.m_HasInlineTransformOrigin = false;
				result = this.RemoveInlineStyle(StylePropertyId.TransformOrigin);
			}
			else
			{
				this.m_InlineTransformOrigin = inlineValue;
				this.m_HasInlineTransformOrigin = true;
				this.ApplyStyleTransformOrigin(inlineValue);
				result = true;
			}
			return result;
		}

		// Token: 0x0600163D RID: 5693 RVA: 0x000587CC File Offset: 0x000569CC
		private void ApplyStyleTransformOrigin(StyleTransformOrigin transformOrigin)
		{
			ComputedTransitionUtils.UpdateComputedTransitions(this.ve.computedStyle);
			bool flag = false;
			ComputedTransitionProperty computedTransitionProperty;
			bool flag2 = this.ve.computedStyle.hasTransition && this.ve.styleInitialized && this.ve.computedStyle.GetTransitionProperty(StylePropertyId.TransformOrigin, out computedTransitionProperty);
			if (flag2)
			{
				flag = ComputedStyle.StartAnimationInlineTransformOrigin(this.ve, this.ve.computedStyle, transformOrigin, computedTransitionProperty.durationMs, computedTransitionProperty.delayMs, computedTransitionProperty.easingCurve);
			}
			else
			{
				this.ve.styleAnimation.CancelAnimation(StylePropertyId.TransformOrigin);
			}
			bool flag3 = !flag;
			if (flag3)
			{
				this.ve.computedStyle.ApplyStyleTransformOrigin(transformOrigin.value);
			}
		}

		// Token: 0x0600163E RID: 5694 RVA: 0x00058894 File Offset: 0x00056A94
		private bool SetInlineTranslate(StyleTranslate inlineValue)
		{
			StyleTranslate styleTranslate = default(StyleTranslate);
			bool flag = this.TryGetInlineTranslate(ref styleTranslate);
			if (flag)
			{
				bool flag2 = styleTranslate.value == inlineValue.value && styleTranslate.keyword == inlineValue.keyword;
				if (flag2)
				{
					return false;
				}
			}
			else
			{
				bool flag3 = inlineValue.keyword == StyleKeyword.Null;
				if (flag3)
				{
					return false;
				}
			}
			bool flag4 = inlineValue.keyword == StyleKeyword.Null;
			bool result;
			if (flag4)
			{
				this.m_HasInlineTranslate = false;
				result = this.RemoveInlineStyle(StylePropertyId.Translate);
			}
			else
			{
				this.m_InlineTranslateOperation = inlineValue;
				this.m_HasInlineTranslate = true;
				this.ApplyStyleTranslate(inlineValue);
				result = true;
			}
			return result;
		}

		// Token: 0x0600163F RID: 5695 RVA: 0x00058940 File Offset: 0x00056B40
		private void ApplyStyleTranslate(StyleTranslate translate)
		{
			ComputedTransitionUtils.UpdateComputedTransitions(this.ve.computedStyle);
			bool flag = false;
			ComputedTransitionProperty computedTransitionProperty;
			bool flag2 = this.ve.computedStyle.hasTransition && this.ve.styleInitialized && this.ve.computedStyle.GetTransitionProperty(StylePropertyId.Translate, out computedTransitionProperty);
			if (flag2)
			{
				flag = ComputedStyle.StartAnimationInlineTranslate(this.ve, this.ve.computedStyle, translate, computedTransitionProperty.durationMs, computedTransitionProperty.delayMs, computedTransitionProperty.easingCurve);
			}
			else
			{
				this.ve.styleAnimation.CancelAnimation(StylePropertyId.Translate);
			}
			bool flag3 = !flag;
			if (flag3)
			{
				this.ve.computedStyle.ApplyStyleTranslate(translate.value);
			}
		}

		// Token: 0x06001640 RID: 5696 RVA: 0x00058A08 File Offset: 0x00056C08
		private bool SetInlineScale(StyleScale inlineValue)
		{
			StyleScale styleScale = default(StyleScale);
			bool flag = this.TryGetInlineScale(ref styleScale);
			if (flag)
			{
				bool flag2 = styleScale.value == inlineValue.value && styleScale.keyword == inlineValue.keyword;
				if (flag2)
				{
					return false;
				}
			}
			else
			{
				bool flag3 = inlineValue.keyword == StyleKeyword.Null;
				if (flag3)
				{
					return false;
				}
			}
			bool flag4 = inlineValue.keyword == StyleKeyword.Null;
			bool result;
			if (flag4)
			{
				this.m_HasInlineScale = false;
				result = this.RemoveInlineStyle(StylePropertyId.Scale);
			}
			else
			{
				this.m_InlineScale = inlineValue;
				this.m_HasInlineScale = true;
				this.ApplyStyleScale(inlineValue);
				result = true;
			}
			return result;
		}

		// Token: 0x06001641 RID: 5697 RVA: 0x00058AB4 File Offset: 0x00056CB4
		private void ApplyStyleScale(StyleScale scale)
		{
			ComputedTransitionUtils.UpdateComputedTransitions(this.ve.computedStyle);
			bool flag = false;
			ComputedTransitionProperty computedTransitionProperty;
			bool flag2 = this.ve.computedStyle.hasTransition && this.ve.styleInitialized && this.ve.computedStyle.GetTransitionProperty(StylePropertyId.Scale, out computedTransitionProperty);
			if (flag2)
			{
				flag = ComputedStyle.StartAnimationInlineScale(this.ve, this.ve.computedStyle, scale, computedTransitionProperty.durationMs, computedTransitionProperty.delayMs, computedTransitionProperty.easingCurve);
			}
			else
			{
				this.ve.styleAnimation.CancelAnimation(StylePropertyId.Scale);
			}
			bool flag3 = !flag;
			if (flag3)
			{
				this.ve.computedStyle.ApplyStyleScale(scale.value);
			}
		}

		// Token: 0x06001642 RID: 5698 RVA: 0x00058B7C File Offset: 0x00056D7C
		private bool SetInlineRotate(StyleRotate inlineValue)
		{
			StyleRotate styleRotate = default(StyleRotate);
			bool flag = this.TryGetInlineRotate(ref styleRotate);
			if (flag)
			{
				bool flag2 = styleRotate.value == inlineValue.value && styleRotate.keyword == inlineValue.keyword;
				if (flag2)
				{
					return false;
				}
			}
			else
			{
				bool flag3 = inlineValue.keyword == StyleKeyword.Null;
				if (flag3)
				{
					return false;
				}
			}
			bool flag4 = inlineValue.keyword == StyleKeyword.Null;
			bool result;
			if (flag4)
			{
				this.m_HasInlineRotate = false;
				result = this.RemoveInlineStyle(StylePropertyId.Rotate);
			}
			else
			{
				this.m_InlineRotateOperation = inlineValue;
				this.m_HasInlineRotate = true;
				this.ApplyStyleRotate(inlineValue);
				result = true;
			}
			return result;
		}

		// Token: 0x06001643 RID: 5699 RVA: 0x00058C28 File Offset: 0x00056E28
		private void ApplyStyleRotate(StyleRotate rotate)
		{
			VisualElement parent = this.ve.hierarchy.parent;
			if (parent != null)
			{
				ref ComputedStyle computedStyle = ref parent.computedStyle;
				ref ComputedStyle computedStyle2 = ref parent.computedStyle;
			}
			else
			{
				InitialStyle.Get();
			}
			ComputedTransitionUtils.UpdateComputedTransitions(this.ve.computedStyle);
			bool flag = false;
			ComputedTransitionProperty computedTransitionProperty;
			bool flag2 = this.ve.computedStyle.hasTransition && this.ve.styleInitialized && this.ve.computedStyle.GetTransitionProperty(StylePropertyId.Rotate, out computedTransitionProperty);
			if (flag2)
			{
				flag = ComputedStyle.StartAnimationInlineRotate(this.ve, this.ve.computedStyle, rotate, computedTransitionProperty.durationMs, computedTransitionProperty.delayMs, computedTransitionProperty.easingCurve);
			}
			else
			{
				this.ve.styleAnimation.CancelAnimation(StylePropertyId.Rotate);
			}
			bool flag3 = !flag;
			if (flag3)
			{
				this.ve.computedStyle.ApplyStyleRotate(rotate.value);
			}
		}

		// Token: 0x06001644 RID: 5700 RVA: 0x00058D24 File Offset: 0x00056F24
		private bool SetInlineBackgroundSize(StyleBackgroundSize inlineValue)
		{
			StyleBackgroundSize styleBackgroundSize = default(StyleBackgroundSize);
			bool flag = this.TryGetInlineBackgroundSize(ref styleBackgroundSize);
			if (flag)
			{
				bool flag2 = styleBackgroundSize.value == inlineValue.value && styleBackgroundSize.keyword == inlineValue.keyword;
				if (flag2)
				{
					return false;
				}
			}
			else
			{
				bool flag3 = inlineValue.keyword == StyleKeyword.Null;
				if (flag3)
				{
					return false;
				}
			}
			bool flag4 = inlineValue.keyword == StyleKeyword.Null;
			bool result;
			if (flag4)
			{
				this.m_HasInlineBackgroundSize = false;
				result = this.RemoveInlineStyle(StylePropertyId.BackgroundSize);
			}
			else
			{
				this.m_InlineBackgroundSize = inlineValue;
				this.m_HasInlineBackgroundSize = true;
				this.ApplyStyleBackgroundSize(inlineValue);
				result = true;
			}
			return result;
		}

		// Token: 0x06001645 RID: 5701 RVA: 0x00058DD0 File Offset: 0x00056FD0
		private void ApplyStyleBackgroundSize(StyleBackgroundSize backgroundSize)
		{
			ComputedTransitionUtils.UpdateComputedTransitions(this.ve.computedStyle);
			bool flag = false;
			ComputedTransitionProperty computedTransitionProperty;
			bool flag2 = this.ve.computedStyle.hasTransition && this.ve.styleInitialized && this.ve.computedStyle.GetTransitionProperty(StylePropertyId.BackgroundSize, out computedTransitionProperty);
			if (flag2)
			{
				flag = ComputedStyle.StartAnimationInlineBackgroundSize(this.ve, this.ve.computedStyle, backgroundSize, computedTransitionProperty.durationMs, computedTransitionProperty.delayMs, computedTransitionProperty.easingCurve);
			}
			else
			{
				this.ve.styleAnimation.CancelAnimation(StylePropertyId.TransformOrigin);
			}
			bool flag3 = !flag;
			if (flag3)
			{
				this.ve.computedStyle.ApplyStyleBackgroundSize(backgroundSize.value);
			}
		}

		// Token: 0x06001646 RID: 5702 RVA: 0x00058E98 File Offset: 0x00057098
		private void ApplyStyleValue(StyleValue value)
		{
			VisualElement parent = this.ve.hierarchy.parent;
			ComputedStyle ptr;
			if (parent != null)
			{
				ref ComputedStyle computedStyle = ref parent.computedStyle;
				ptr = parent.computedStyle;
			}
			else
			{
				ptr = InitialStyle.Get();
			}
			ref ComputedStyle parentStyle = ref ptr;
			bool flag = false;
			bool flag2 = StylePropertyUtil.IsAnimatable(value.id);
			if (flag2)
			{
				ComputedTransitionUtils.UpdateComputedTransitions(this.ve.computedStyle);
				ComputedTransitionProperty computedTransitionProperty;
				bool flag3 = this.ve.computedStyle.hasTransition && this.ve.styleInitialized && this.ve.computedStyle.GetTransitionProperty(value.id, out computedTransitionProperty);
				if (flag3)
				{
					flag = ComputedStyle.StartAnimationInline(this.ve, value.id, this.ve.computedStyle, value, computedTransitionProperty.durationMs, computedTransitionProperty.delayMs, computedTransitionProperty.easingCurve);
				}
				else
				{
					this.ve.styleAnimation.CancelAnimation(value.id);
				}
			}
			bool flag4 = !flag;
			if (flag4)
			{
				this.ve.computedStyle.ApplyStyleValue(value, ref parentStyle);
			}
		}

		// Token: 0x06001647 RID: 5703 RVA: 0x00058FAC File Offset: 0x000571AC
		private void ApplyStyleValue(StyleValueManaged value)
		{
			VisualElement parent = this.ve.hierarchy.parent;
			ComputedStyle ptr;
			if (parent != null)
			{
				ref ComputedStyle computedStyle = ref parent.computedStyle;
				ptr = parent.computedStyle;
			}
			else
			{
				ptr = InitialStyle.Get();
			}
			ref ComputedStyle parentStyle = ref ptr;
			this.ve.computedStyle.ApplyStyleValueManaged(value, ref parentStyle);
		}

		// Token: 0x06001648 RID: 5704 RVA: 0x00058FFC File Offset: 0x000571FC
		private bool RemoveInlineStyle(StylePropertyId id)
		{
			long matchingRulesHash = this.ve.computedStyle.matchingRulesHash;
			bool flag = matchingRulesHash == 0L;
			bool result;
			if (flag)
			{
				this.ApplyFromComputedStyle(id, InitialStyle.Get());
				result = true;
			}
			else
			{
				ComputedStyle computedStyle;
				bool flag2 = StyleCache.TryGetValue(matchingRulesHash, out computedStyle);
				if (flag2)
				{
					this.ApplyFromComputedStyle(id, ref computedStyle);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06001649 RID: 5705 RVA: 0x00059058 File Offset: 0x00057258
		private void ApplyFromComputedStyle(StylePropertyId id, ref ComputedStyle newStyle)
		{
			bool flag = false;
			bool flag2 = StylePropertyUtil.IsAnimatable(id);
			if (flag2)
			{
				ComputedTransitionUtils.UpdateComputedTransitions(this.ve.computedStyle);
				ComputedTransitionProperty computedTransitionProperty;
				bool flag3 = this.ve.computedStyle.hasTransition && this.ve.styleInitialized && this.ve.computedStyle.GetTransitionProperty(id, out computedTransitionProperty);
				if (flag3)
				{
					flag = ComputedStyle.StartAnimation(this.ve, id, this.ve.computedStyle, ref newStyle, computedTransitionProperty.durationMs, computedTransitionProperty.delayMs, computedTransitionProperty.easingCurve);
				}
				else
				{
					this.ve.styleAnimation.CancelAnimation(id);
				}
			}
			bool flag4 = !flag;
			if (flag4)
			{
				this.ve.computedStyle.ApplyFromComputedStyle(id, ref newStyle);
			}
		}

		// Token: 0x0600164A RID: 5706 RVA: 0x00059124 File Offset: 0x00057324
		public bool TryGetInlineCursor(ref StyleCursor value)
		{
			bool hasInlineCursor = this.m_HasInlineCursor;
			bool result;
			if (hasInlineCursor)
			{
				value = this.m_InlineCursor;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600164B RID: 5707 RVA: 0x00059154 File Offset: 0x00057354
		public bool TryGetInlineTextShadow(ref StyleTextShadow value)
		{
			bool hasInlineTextShadow = this.m_HasInlineTextShadow;
			bool result;
			if (hasInlineTextShadow)
			{
				value = this.m_InlineTextShadow;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600164C RID: 5708 RVA: 0x00059184 File Offset: 0x00057384
		public bool TryGetInlineTransformOrigin(ref StyleTransformOrigin value)
		{
			bool hasInlineTransformOrigin = this.m_HasInlineTransformOrigin;
			bool result;
			if (hasInlineTransformOrigin)
			{
				value = this.m_InlineTransformOrigin;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600164D RID: 5709 RVA: 0x000591B4 File Offset: 0x000573B4
		public bool TryGetInlineTranslate(ref StyleTranslate value)
		{
			bool hasInlineTranslate = this.m_HasInlineTranslate;
			bool result;
			if (hasInlineTranslate)
			{
				value = this.m_InlineTranslateOperation;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600164E RID: 5710 RVA: 0x000591E4 File Offset: 0x000573E4
		public bool TryGetInlineRotate(ref StyleRotate value)
		{
			bool hasInlineRotate = this.m_HasInlineRotate;
			bool result;
			if (hasInlineRotate)
			{
				value = this.m_InlineRotateOperation;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600164F RID: 5711 RVA: 0x00059214 File Offset: 0x00057414
		public bool TryGetInlineScale(ref StyleScale value)
		{
			bool hasInlineScale = this.m_HasInlineScale;
			bool result;
			if (hasInlineScale)
			{
				value = this.m_InlineScale;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001650 RID: 5712 RVA: 0x00059244 File Offset: 0x00057444
		public bool TryGetInlineBackgroundSize(ref StyleBackgroundSize value)
		{
			bool hasInlineBackgroundSize = this.m_HasInlineBackgroundSize;
			bool result;
			if (hasInlineBackgroundSize)
			{
				value = this.m_InlineBackgroundSize;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x06001651 RID: 5713 RVA: 0x00059274 File Offset: 0x00057474
		// (set) Token: 0x06001652 RID: 5714 RVA: 0x000592F4 File Offset: 0x000574F4
		StyleEnum<ScaleMode> IStyle.unityBackgroundScaleMode
		{
			get
			{
				bool flag;
				return new StyleEnum<ScaleMode>(BackgroundPropertyHelper.ResolveUnityBackgroundScaleMode(this.ve.style.backgroundPositionX.value, this.ve.style.backgroundPositionY.value, this.ve.style.backgroundRepeat.value, this.ve.style.backgroundSize.value, out flag));
			}
			set
			{
				this.ve.style.backgroundPositionX = BackgroundPropertyHelper.ConvertScaleModeToBackgroundPosition(value.value);
				this.ve.style.backgroundPositionY = BackgroundPropertyHelper.ConvertScaleModeToBackgroundPosition(value.value);
				this.ve.style.backgroundRepeat = BackgroundPropertyHelper.ConvertScaleModeToBackgroundRepeat(value.value);
				this.ve.style.backgroundSize = BackgroundPropertyHelper.ConvertScaleModeToBackgroundSize(value.value);
			}
		}

		// Token: 0x040009D7 RID: 2519
		private static StylePropertyReader s_StylePropertyReader = new StylePropertyReader();

		// Token: 0x040009D8 RID: 2520
		private List<StyleValueManaged> m_ValuesManaged;

		// Token: 0x040009DA RID: 2522
		private bool m_HasInlineCursor;

		// Token: 0x040009DB RID: 2523
		private StyleCursor m_InlineCursor;

		// Token: 0x040009DC RID: 2524
		private bool m_HasInlineTextShadow;

		// Token: 0x040009DD RID: 2525
		private StyleTextShadow m_InlineTextShadow;

		// Token: 0x040009DE RID: 2526
		private bool m_HasInlineTransformOrigin;

		// Token: 0x040009DF RID: 2527
		private StyleTransformOrigin m_InlineTransformOrigin;

		// Token: 0x040009E0 RID: 2528
		private bool m_HasInlineTranslate;

		// Token: 0x040009E1 RID: 2529
		private StyleTranslate m_InlineTranslateOperation;

		// Token: 0x040009E2 RID: 2530
		private bool m_HasInlineRotate;

		// Token: 0x040009E3 RID: 2531
		private StyleRotate m_InlineRotateOperation;

		// Token: 0x040009E4 RID: 2532
		private bool m_HasInlineScale;

		// Token: 0x040009E5 RID: 2533
		private StyleScale m_InlineScale;

		// Token: 0x040009E6 RID: 2534
		private bool m_HasInlineBackgroundSize;

		// Token: 0x040009E7 RID: 2535
		public StyleBackgroundSize m_InlineBackgroundSize;

		// Token: 0x040009E8 RID: 2536
		private InlineStyleAccess.InlineRule m_InlineRule;

		// Token: 0x020002D2 RID: 722
		internal struct InlineRule
		{
			// Token: 0x170004FA RID: 1274
			// (get) Token: 0x06001654 RID: 5716 RVA: 0x00059396 File Offset: 0x00057596
			public StyleProperty[] properties
			{
				get
				{
					return this.rule.properties;
				}
			}

			// Token: 0x040009E9 RID: 2537
			public StyleSheet sheet;

			// Token: 0x040009EA RID: 2538
			public StyleRule rule;

			// Token: 0x040009EB RID: 2539
			public StylePropertyId[] propertyIds;
		}
	}
}
