using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements.StyleSheets;

namespace UnityEngine.UIElements
{
	// Token: 0x020000C4 RID: 196
	public class Image : VisualElement
	{
		// Token: 0x17000117 RID: 279
		// (get) Token: 0x0600069A RID: 1690 RVA: 0x0001913E File Offset: 0x0001733E
		// (set) Token: 0x0600069B RID: 1691 RVA: 0x00019148 File Offset: 0x00017348
		public Texture image
		{
			get
			{
				return this.m_Image;
			}
			set
			{
				bool flag = this.m_Image == value && this.m_ImageIsInline;
				if (!flag)
				{
					this.m_ImageIsInline = (value != null);
					this.SetProperty<Texture, Sprite, VectorImage>(value, ref this.m_Image, ref this.m_Sprite, ref this.m_VectorImage);
				}
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x0600069C RID: 1692 RVA: 0x0001919A File Offset: 0x0001739A
		// (set) Token: 0x0600069D RID: 1693 RVA: 0x000191A4 File Offset: 0x000173A4
		public Sprite sprite
		{
			get
			{
				return this.m_Sprite;
			}
			set
			{
				bool flag = this.m_Sprite == value && this.m_ImageIsInline;
				if (!flag)
				{
					this.m_ImageIsInline = (value != null);
					this.SetProperty<Sprite, Texture, VectorImage>(value, ref this.m_Sprite, ref this.m_Image, ref this.m_VectorImage);
				}
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x0600069E RID: 1694 RVA: 0x000191F6 File Offset: 0x000173F6
		// (set) Token: 0x0600069F RID: 1695 RVA: 0x00019200 File Offset: 0x00017400
		public VectorImage vectorImage
		{
			get
			{
				return this.m_VectorImage;
			}
			set
			{
				bool flag = this.m_VectorImage == value && this.m_ImageIsInline;
				if (!flag)
				{
					this.m_ImageIsInline = (value != null);
					this.SetProperty<VectorImage, Texture, Sprite>(value, ref this.m_VectorImage, ref this.m_Image, ref this.m_Sprite);
				}
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060006A0 RID: 1696 RVA: 0x00019252 File Offset: 0x00017452
		// (set) Token: 0x060006A1 RID: 1697 RVA: 0x0001925C File Offset: 0x0001745C
		public Rect sourceRect
		{
			get
			{
				return this.GetSourceRect();
			}
			set
			{
				bool flag = this.GetSourceRect() == value;
				if (!flag)
				{
					bool flag2 = this.sprite != null;
					if (flag2)
					{
						Debug.LogError("Cannot set sourceRect on a sprite image");
					}
					else
					{
						this.CalculateUV(value);
					}
				}
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060006A2 RID: 1698 RVA: 0x000192A2 File Offset: 0x000174A2
		// (set) Token: 0x060006A3 RID: 1699 RVA: 0x000192AC File Offset: 0x000174AC
		public Rect uv
		{
			get
			{
				return this.m_UV;
			}
			set
			{
				bool flag = this.m_UV == value;
				if (!flag)
				{
					this.m_UV = value;
				}
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060006A4 RID: 1700 RVA: 0x000192D3 File Offset: 0x000174D3
		// (set) Token: 0x060006A5 RID: 1701 RVA: 0x000192DC File Offset: 0x000174DC
		public ScaleMode scaleMode
		{
			get
			{
				return this.m_ScaleMode;
			}
			set
			{
				bool flag = this.m_ScaleMode == value && this.m_ScaleModeIsInline;
				if (!flag)
				{
					this.m_ScaleModeIsInline = true;
					this.SetScaleMode(value);
				}
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060006A6 RID: 1702 RVA: 0x00019311 File Offset: 0x00017511
		// (set) Token: 0x060006A7 RID: 1703 RVA: 0x0001931C File Offset: 0x0001751C
		public Color tintColor
		{
			get
			{
				return this.m_TintColor;
			}
			set
			{
				bool flag = this.m_TintColor == value && this.m_TintColorIsInline;
				if (!flag)
				{
					this.m_TintColorIsInline = true;
					this.SetTintColor(value);
				}
			}
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x00019358 File Offset: 0x00017558
		public Image()
		{
			base.AddToClassList(Image.ussClassName);
			this.m_ScaleMode = ScaleMode.ScaleToFit;
			this.m_TintColor = Color.white;
			this.m_UV = new Rect(0f, 0f, 1f, 1f);
			base.requireMeasureFunction = true;
			base.RegisterCallback<CustomStyleResolvedEvent>(new EventCallback<CustomStyleResolvedEvent>(this.OnCustomStyleResolved), TrickleDown.NoTrickleDown);
			base.generateVisualContent = (Action<MeshGenerationContext>)Delegate.Combine(base.generateVisualContent, new Action<MeshGenerationContext>(this.OnGenerateVisualContent));
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x000193EC File Offset: 0x000175EC
		private Vector2 GetTextureDisplaySize(Texture texture)
		{
			Vector2 zero = Vector2.zero;
			bool flag = texture != null;
			if (flag)
			{
				zero = new Vector2((float)texture.width, (float)texture.height);
			}
			return zero;
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x00019428 File Offset: 0x00017628
		private Vector2 GetTextureDisplaySize(Sprite sprite)
		{
			Vector2 result = Vector2.zero;
			bool flag = sprite != null;
			if (flag)
			{
				float d = UIElementsUtility.PixelsPerUnitScaleForElement(this, sprite);
				result = sprite.bounds.size * sprite.pixelsPerUnit * d;
			}
			return result;
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x00019480 File Offset: 0x00017680
		protected internal override Vector2 DoMeasure(float desiredWidth, VisualElement.MeasureMode widthMode, float desiredHeight, VisualElement.MeasureMode heightMode)
		{
			float num = float.NaN;
			float num2 = float.NaN;
			bool flag = this.image == null && this.sprite == null && this.vectorImage == null;
			Vector2 result;
			if (flag)
			{
				result = new Vector2(num, num2);
			}
			else
			{
				Vector2 vector = Vector2.zero;
				bool flag2 = this.image != null;
				if (flag2)
				{
					vector = this.GetTextureDisplaySize(this.image);
				}
				else
				{
					bool flag3 = this.sprite != null;
					if (flag3)
					{
						vector = this.GetTextureDisplaySize(this.sprite);
					}
					else
					{
						vector = this.vectorImage.size;
					}
				}
				Rect sourceRect = this.sourceRect;
				bool flag4 = sourceRect != Rect.zero;
				num = (flag4 ? Mathf.Abs(sourceRect.width) : vector.x);
				num2 = (flag4 ? Mathf.Abs(sourceRect.height) : vector.y);
				bool flag5 = widthMode == VisualElement.MeasureMode.AtMost;
				if (flag5)
				{
					num = Mathf.Min(num, desiredWidth);
				}
				bool flag6 = heightMode == VisualElement.MeasureMode.AtMost;
				if (flag6)
				{
					num2 = Mathf.Min(num2, desiredHeight);
				}
				result = new Vector2(num, num2);
			}
			return result;
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x000195AC File Offset: 0x000177AC
		private void OnGenerateVisualContent(MeshGenerationContext mgc)
		{
			bool flag = this.image == null && this.sprite == null && this.vectorImage == null;
			if (!flag)
			{
				Rect rect = GUIUtility.AlignRectToDevice(base.contentRect);
				MeshGenerationContextUtils.RectangleParams rectParams = default(MeshGenerationContextUtils.RectangleParams);
				bool flag2 = this.image != null;
				if (flag2)
				{
					rectParams = MeshGenerationContextUtils.RectangleParams.MakeTextured(rect, this.uv, this.image, this.scaleMode, base.panel.contextType);
				}
				else
				{
					bool flag3 = this.sprite != null;
					if (flag3)
					{
						Vector4 zero = Vector4.zero;
						rectParams = MeshGenerationContextUtils.RectangleParams.MakeSprite(rect, this.uv, this.sprite, this.scaleMode, base.panel.contextType, false, ref zero, false);
					}
					else
					{
						bool flag4 = this.vectorImage != null;
						if (flag4)
						{
							rectParams = MeshGenerationContextUtils.RectangleParams.MakeVectorTextured(rect, this.uv, this.vectorImage, this.scaleMode, base.panel.contextType);
						}
					}
				}
				rectParams.color = this.tintColor;
				mgc.Rectangle(rectParams);
			}
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x000196C8 File Offset: 0x000178C8
		private void OnCustomStyleResolved(CustomStyleResolvedEvent e)
		{
			this.ReadCustomProperties(e.customStyle);
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x000196D8 File Offset: 0x000178D8
		private void ReadCustomProperties(ICustomStyle customStyleProvider)
		{
			bool flag = !this.m_ImageIsInline;
			if (flag)
			{
				Texture2D src;
				bool flag2 = customStyleProvider.TryGetValue(Image.s_ImageProperty, out src);
				if (flag2)
				{
					this.SetProperty<Texture, Sprite, VectorImage>(src, ref this.m_Image, ref this.m_Sprite, ref this.m_VectorImage);
				}
				else
				{
					Sprite src2;
					bool flag3 = customStyleProvider.TryGetValue(Image.s_SpriteProperty, out src2);
					if (flag3)
					{
						this.SetProperty<Sprite, Texture, VectorImage>(src2, ref this.m_Sprite, ref this.m_Image, ref this.m_VectorImage);
					}
					else
					{
						VectorImage src3;
						bool flag4 = customStyleProvider.TryGetValue(Image.s_VectorImageProperty, out src3);
						if (flag4)
						{
							this.SetProperty<VectorImage, Texture, Sprite>(src3, ref this.m_VectorImage, ref this.m_Image, ref this.m_Sprite);
						}
						else
						{
							this.ClearProperty();
						}
					}
				}
			}
			string value;
			bool flag5 = !this.m_ScaleModeIsInline && customStyleProvider.TryGetValue(Image.s_ScaleModeProperty, out value);
			if (flag5)
			{
				int scaleMode;
				StylePropertyUtil.TryGetEnumIntValue(StyleEnumType.ScaleMode, value, out scaleMode);
				this.SetScaleMode((ScaleMode)scaleMode);
			}
			Color tintColor;
			bool flag6 = !this.m_TintColorIsInline && customStyleProvider.TryGetValue(Image.s_TintColorProperty, out tintColor);
			if (flag6)
			{
				this.SetTintColor(tintColor);
			}
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x000197F4 File Offset: 0x000179F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetProperty<T0, T1, T2>(T0 src, ref T0 dst, ref T1 alt0, ref T2 alt1) where T0 : Object where T1 : Object where T2 : Object
		{
			bool flag = src == dst;
			if (!flag)
			{
				dst = src;
				bool flag2 = dst != null;
				if (flag2)
				{
					alt0 = default(T1);
					alt1 = default(T2);
				}
				bool flag3 = dst == null;
				if (flag3)
				{
					this.uv = new Rect(0f, 0f, 1f, 1f);
					this.ReadCustomProperties(base.customStyle);
				}
				base.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Repaint);
			}
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x0001989C File Offset: 0x00017A9C
		private void ClearProperty()
		{
			bool imageIsInline = this.m_ImageIsInline;
			if (!imageIsInline)
			{
				this.image = null;
				this.sprite = null;
				this.vectorImage = null;
			}
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x000198D0 File Offset: 0x00017AD0
		private void SetScaleMode(ScaleMode mode)
		{
			bool flag = this.m_ScaleMode != mode;
			if (flag)
			{
				this.m_ScaleMode = mode;
				base.IncrementVersion(VersionChangeType.Repaint);
			}
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x00019904 File Offset: 0x00017B04
		private void SetTintColor(Color color)
		{
			bool flag = this.m_TintColor != color;
			if (flag)
			{
				this.m_TintColor = color;
				base.IncrementVersion(VersionChangeType.Repaint);
			}
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x00019938 File Offset: 0x00017B38
		private void CalculateUV(Rect srcRect)
		{
			this.m_UV = new Rect(0f, 0f, 1f, 1f);
			Vector2 vector = Vector2.zero;
			Texture image = this.image;
			bool flag = image != null;
			if (flag)
			{
				vector = this.GetTextureDisplaySize(image);
			}
			VectorImage vectorImage = this.vectorImage;
			bool flag2 = vectorImage != null;
			if (flag2)
			{
				vector = vectorImage.size;
			}
			bool flag3 = vector != Vector2.zero;
			if (flag3)
			{
				this.m_UV.x = srcRect.x / vector.x;
				this.m_UV.width = srcRect.width / vector.x;
				this.m_UV.height = srcRect.height / vector.y;
				this.m_UV.y = 1f - this.m_UV.height - srcRect.y / vector.y;
			}
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x00019A30 File Offset: 0x00017C30
		private Rect GetSourceRect()
		{
			Rect zero = Rect.zero;
			Vector2 vector = Vector2.zero;
			Texture image = this.image;
			bool flag = image != null;
			if (flag)
			{
				vector = this.GetTextureDisplaySize(image);
			}
			VectorImage vectorImage = this.vectorImage;
			bool flag2 = vectorImage != null;
			if (flag2)
			{
				vector = vectorImage.size;
			}
			bool flag3 = vector != Vector2.zero;
			if (flag3)
			{
				zero.x = this.uv.x * vector.x;
				zero.width = this.uv.width * vector.x;
				zero.y = (1f - this.uv.y - this.uv.height) * vector.y;
				zero.height = this.uv.height * vector.y;
			}
			return zero;
		}

		// Token: 0x040002E3 RID: 739
		private ScaleMode m_ScaleMode;

		// Token: 0x040002E4 RID: 740
		private Texture m_Image;

		// Token: 0x040002E5 RID: 741
		private Sprite m_Sprite;

		// Token: 0x040002E6 RID: 742
		private VectorImage m_VectorImage;

		// Token: 0x040002E7 RID: 743
		private Rect m_UV;

		// Token: 0x040002E8 RID: 744
		private Color m_TintColor;

		// Token: 0x040002E9 RID: 745
		internal bool m_ImageIsInline;

		// Token: 0x040002EA RID: 746
		private bool m_ScaleModeIsInline;

		// Token: 0x040002EB RID: 747
		private bool m_TintColorIsInline;

		// Token: 0x040002EC RID: 748
		public static readonly string ussClassName = "unity-image";

		// Token: 0x040002ED RID: 749
		private static CustomStyleProperty<Texture2D> s_ImageProperty = new CustomStyleProperty<Texture2D>("--unity-image");

		// Token: 0x040002EE RID: 750
		private static CustomStyleProperty<Sprite> s_SpriteProperty = new CustomStyleProperty<Sprite>("--unity-image");

		// Token: 0x040002EF RID: 751
		private static CustomStyleProperty<VectorImage> s_VectorImageProperty = new CustomStyleProperty<VectorImage>("--unity-image");

		// Token: 0x040002F0 RID: 752
		private static CustomStyleProperty<string> s_ScaleModeProperty = new CustomStyleProperty<string>("--unity-image-size");

		// Token: 0x040002F1 RID: 753
		private static CustomStyleProperty<Color> s_TintColorProperty = new CustomStyleProperty<Color>("--unity-image-tint-color");

		// Token: 0x020000C5 RID: 197
		public new class UxmlFactory : UxmlFactory<Image, Image.UxmlTraits>
		{
		}

		// Token: 0x020000C6 RID: 198
		public new class UxmlTraits : VisualElement.UxmlTraits
		{
			// Token: 0x1700011E RID: 286
			// (get) Token: 0x060006B7 RID: 1719 RVA: 0x00019B98 File Offset: 0x00017D98
			public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
			{
				get
				{
					yield break;
				}
			}
		}
	}
}
