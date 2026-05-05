using System;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x02000487 RID: 1159
	internal enum StylePropertyId
	{
		// Token: 0x04001106 RID: 4358
		Unknown,
		// Token: 0x04001107 RID: 4359
		Custom = -1,
		// Token: 0x04001108 RID: 4360
		AlignContent = 131072,
		// Token: 0x04001109 RID: 4361
		AlignItems,
		// Token: 0x0400110A RID: 4362
		AlignSelf,
		// Token: 0x0400110B RID: 4363
		All = 262144,
		// Token: 0x0400110C RID: 4364
		BackgroundColor = 458752,
		// Token: 0x0400110D RID: 4365
		BackgroundImage,
		// Token: 0x0400110E RID: 4366
		BackgroundPosition = 262145,
		// Token: 0x0400110F RID: 4367
		BackgroundPositionX = 458754,
		// Token: 0x04001110 RID: 4368
		BackgroundPositionY,
		// Token: 0x04001111 RID: 4369
		BackgroundRepeat,
		// Token: 0x04001112 RID: 4370
		BackgroundSize,
		// Token: 0x04001113 RID: 4371
		BorderBottomColor,
		// Token: 0x04001114 RID: 4372
		BorderBottomLeftRadius,
		// Token: 0x04001115 RID: 4373
		BorderBottomRightRadius,
		// Token: 0x04001116 RID: 4374
		BorderBottomWidth = 131075,
		// Token: 0x04001117 RID: 4375
		BorderColor = 262146,
		// Token: 0x04001118 RID: 4376
		BorderLeftColor = 458761,
		// Token: 0x04001119 RID: 4377
		BorderLeftWidth = 131076,
		// Token: 0x0400111A RID: 4378
		BorderRadius = 262147,
		// Token: 0x0400111B RID: 4379
		BorderRightColor = 458762,
		// Token: 0x0400111C RID: 4380
		BorderRightWidth = 131077,
		// Token: 0x0400111D RID: 4381
		BorderTopColor = 458763,
		// Token: 0x0400111E RID: 4382
		BorderTopLeftRadius,
		// Token: 0x0400111F RID: 4383
		BorderTopRightRadius,
		// Token: 0x04001120 RID: 4384
		BorderTopWidth = 131078,
		// Token: 0x04001121 RID: 4385
		BorderWidth = 262148,
		// Token: 0x04001122 RID: 4386
		Bottom = 131079,
		// Token: 0x04001123 RID: 4387
		Color = 65536,
		// Token: 0x04001124 RID: 4388
		Cursor = 196608,
		// Token: 0x04001125 RID: 4389
		Display = 131080,
		// Token: 0x04001126 RID: 4390
		Flex = 262149,
		// Token: 0x04001127 RID: 4391
		FlexBasis = 131081,
		// Token: 0x04001128 RID: 4392
		FlexDirection,
		// Token: 0x04001129 RID: 4393
		FlexGrow,
		// Token: 0x0400112A RID: 4394
		FlexShrink,
		// Token: 0x0400112B RID: 4395
		FlexWrap,
		// Token: 0x0400112C RID: 4396
		FontSize = 65537,
		// Token: 0x0400112D RID: 4397
		Height = 131086,
		// Token: 0x0400112E RID: 4398
		JustifyContent,
		// Token: 0x0400112F RID: 4399
		Left,
		// Token: 0x04001130 RID: 4400
		LetterSpacing = 65538,
		// Token: 0x04001131 RID: 4401
		Margin = 262150,
		// Token: 0x04001132 RID: 4402
		MarginBottom = 131089,
		// Token: 0x04001133 RID: 4403
		MarginLeft,
		// Token: 0x04001134 RID: 4404
		MarginRight,
		// Token: 0x04001135 RID: 4405
		MarginTop,
		// Token: 0x04001136 RID: 4406
		MaxHeight,
		// Token: 0x04001137 RID: 4407
		MaxWidth,
		// Token: 0x04001138 RID: 4408
		MinHeight,
		// Token: 0x04001139 RID: 4409
		MinWidth,
		// Token: 0x0400113A RID: 4410
		Opacity = 458766,
		// Token: 0x0400113B RID: 4411
		Overflow,
		// Token: 0x0400113C RID: 4412
		Padding = 262151,
		// Token: 0x0400113D RID: 4413
		PaddingBottom = 131097,
		// Token: 0x0400113E RID: 4414
		PaddingLeft,
		// Token: 0x0400113F RID: 4415
		PaddingRight,
		// Token: 0x04001140 RID: 4416
		PaddingTop,
		// Token: 0x04001141 RID: 4417
		Position,
		// Token: 0x04001142 RID: 4418
		Right,
		// Token: 0x04001143 RID: 4419
		Rotate = 327680,
		// Token: 0x04001144 RID: 4420
		Scale,
		// Token: 0x04001145 RID: 4421
		TextOverflow = 196609,
		// Token: 0x04001146 RID: 4422
		TextShadow = 65539,
		// Token: 0x04001147 RID: 4423
		Top = 131103,
		// Token: 0x04001148 RID: 4424
		TransformOrigin = 327682,
		// Token: 0x04001149 RID: 4425
		Transition = 262152,
		// Token: 0x0400114A RID: 4426
		TransitionDelay = 393216,
		// Token: 0x0400114B RID: 4427
		TransitionDuration,
		// Token: 0x0400114C RID: 4428
		TransitionProperty,
		// Token: 0x0400114D RID: 4429
		TransitionTimingFunction,
		// Token: 0x0400114E RID: 4430
		Translate = 327683,
		// Token: 0x0400114F RID: 4431
		UnityBackgroundImageTintColor = 196610,
		// Token: 0x04001150 RID: 4432
		UnityBackgroundScaleMode = 262153,
		// Token: 0x04001151 RID: 4433
		UnityFont = 65540,
		// Token: 0x04001152 RID: 4434
		UnityFontDefinition,
		// Token: 0x04001153 RID: 4435
		UnityFontStyleAndWeight,
		// Token: 0x04001154 RID: 4436
		UnityOverflowClipBox = 196611,
		// Token: 0x04001155 RID: 4437
		UnityParagraphSpacing = 65543,
		// Token: 0x04001156 RID: 4438
		UnitySliceBottom = 196612,
		// Token: 0x04001157 RID: 4439
		UnitySliceLeft,
		// Token: 0x04001158 RID: 4440
		UnitySliceRight,
		// Token: 0x04001159 RID: 4441
		UnitySliceScale,
		// Token: 0x0400115A RID: 4442
		UnitySliceTop,
		// Token: 0x0400115B RID: 4443
		UnityTextAlign = 65544,
		// Token: 0x0400115C RID: 4444
		UnityTextOutline = 262154,
		// Token: 0x0400115D RID: 4445
		UnityTextOutlineColor = 65545,
		// Token: 0x0400115E RID: 4446
		UnityTextOutlineWidth,
		// Token: 0x0400115F RID: 4447
		UnityTextOverflowPosition = 196617,
		// Token: 0x04001160 RID: 4448
		Visibility = 65547,
		// Token: 0x04001161 RID: 4449
		WhiteSpace,
		// Token: 0x04001162 RID: 4450
		Width = 131104,
		// Token: 0x04001163 RID: 4451
		WordSpacing = 65549
	}
}
