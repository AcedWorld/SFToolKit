using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x020002C5 RID: 709
	public struct Background : IEquatable<Background>
	{
		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x06001481 RID: 5249 RVA: 0x00049030 File Offset: 0x00047230
		// (set) Token: 0x06001482 RID: 5250 RVA: 0x00049048 File Offset: 0x00047248
		public Texture2D texture
		{
			get
			{
				return this.m_Texture;
			}
			set
			{
				bool flag = this.m_Texture == value;
				if (!flag)
				{
					this.m_Texture = value;
					this.m_Sprite = null;
					this.m_RenderTexture = null;
					this.m_VectorImage = null;
				}
			}
		}

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x06001483 RID: 5251 RVA: 0x00049084 File Offset: 0x00047284
		// (set) Token: 0x06001484 RID: 5252 RVA: 0x0004909C File Offset: 0x0004729C
		public Sprite sprite
		{
			get
			{
				return this.m_Sprite;
			}
			set
			{
				bool flag = this.m_Sprite == value;
				if (!flag)
				{
					this.m_Texture = null;
					this.m_Sprite = value;
					this.m_RenderTexture = null;
					this.m_VectorImage = null;
				}
			}
		}

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x06001485 RID: 5253 RVA: 0x000490D8 File Offset: 0x000472D8
		// (set) Token: 0x06001486 RID: 5254 RVA: 0x000490F0 File Offset: 0x000472F0
		public RenderTexture renderTexture
		{
			get
			{
				return this.m_RenderTexture;
			}
			set
			{
				bool flag = this.m_RenderTexture == value;
				if (!flag)
				{
					this.m_Texture = null;
					this.m_Sprite = null;
					this.m_RenderTexture = value;
					this.m_VectorImage = null;
				}
			}
		}

		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x06001487 RID: 5255 RVA: 0x0004912C File Offset: 0x0004732C
		// (set) Token: 0x06001488 RID: 5256 RVA: 0x00049144 File Offset: 0x00047344
		public VectorImage vectorImage
		{
			get
			{
				return this.m_VectorImage;
			}
			set
			{
				bool flag = this.vectorImage == value;
				if (!flag)
				{
					this.m_Texture = null;
					this.m_Sprite = null;
					this.m_RenderTexture = null;
					this.m_VectorImage = value;
				}
			}
		}

		// Token: 0x06001489 RID: 5257 RVA: 0x00049180 File Offset: 0x00047380
		[Obsolete("Use Background.FromTexture2D instead")]
		public Background(Texture2D t)
		{
			this.m_Texture = t;
			this.m_Sprite = null;
			this.m_RenderTexture = null;
			this.m_VectorImage = null;
		}

		// Token: 0x0600148A RID: 5258 RVA: 0x000491A0 File Offset: 0x000473A0
		public static Background FromTexture2D(Texture2D t)
		{
			return new Background
			{
				texture = t
			};
		}

		// Token: 0x0600148B RID: 5259 RVA: 0x000491C4 File Offset: 0x000473C4
		public static Background FromRenderTexture(RenderTexture rt)
		{
			return new Background
			{
				renderTexture = rt
			};
		}

		// Token: 0x0600148C RID: 5260 RVA: 0x000491E8 File Offset: 0x000473E8
		public static Background FromSprite(Sprite s)
		{
			return new Background
			{
				sprite = s
			};
		}

		// Token: 0x0600148D RID: 5261 RVA: 0x0004920C File Offset: 0x0004740C
		public static Background FromVectorImage(VectorImage vi)
		{
			return new Background
			{
				vectorImage = vi
			};
		}

		// Token: 0x0600148E RID: 5262 RVA: 0x00049230 File Offset: 0x00047430
		internal static Background FromObject(object obj)
		{
			Texture2D texture2D = obj as Texture2D;
			bool flag = texture2D != null;
			Background result;
			if (flag)
			{
				result = Background.FromTexture2D(texture2D);
			}
			else
			{
				RenderTexture renderTexture = obj as RenderTexture;
				bool flag2 = renderTexture != null;
				if (flag2)
				{
					result = Background.FromRenderTexture(renderTexture);
				}
				else
				{
					Sprite sprite = obj as Sprite;
					bool flag3 = sprite != null;
					if (flag3)
					{
						result = Background.FromSprite(sprite);
					}
					else
					{
						VectorImage vectorImage = obj as VectorImage;
						bool flag4 = vectorImage != null;
						if (flag4)
						{
							result = Background.FromVectorImage(vectorImage);
						}
						else
						{
							result = default(Background);
						}
					}
				}
			}
			return result;
		}

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x0600148F RID: 5263 RVA: 0x000492C8 File Offset: 0x000474C8
		internal static IEnumerable<Type> allowedAssetTypes
		{
			get
			{
				yield return typeof(Texture2D);
				yield return typeof(RenderTexture);
				yield return typeof(Sprite);
				yield return typeof(VectorImage);
				yield break;
			}
		}

		// Token: 0x06001490 RID: 5264 RVA: 0x000492E0 File Offset: 0x000474E0
		public static bool operator ==(Background lhs, Background rhs)
		{
			return lhs.texture == rhs.texture && lhs.sprite == rhs.sprite && lhs.renderTexture == rhs.renderTexture && lhs.vectorImage == rhs.vectorImage;
		}

		// Token: 0x06001491 RID: 5265 RVA: 0x00049348 File Offset: 0x00047548
		public static bool operator !=(Background lhs, Background rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001492 RID: 5266 RVA: 0x00049364 File Offset: 0x00047564
		public static implicit operator Background(Texture2D v)
		{
			return Background.FromTexture2D(v);
		}

		// Token: 0x06001493 RID: 5267 RVA: 0x0004937C File Offset: 0x0004757C
		public bool Equals(Background other)
		{
			return other == this;
		}

		// Token: 0x06001494 RID: 5268 RVA: 0x0004939C File Offset: 0x0004759C
		public override bool Equals(object obj)
		{
			bool flag = !(obj is Background);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				Background lhs = (Background)obj;
				result = (lhs == this);
			}
			return result;
		}

		// Token: 0x06001495 RID: 5269 RVA: 0x000493D8 File Offset: 0x000475D8
		public override int GetHashCode()
		{
			int num = 851985039;
			bool flag = this.texture != null;
			if (flag)
			{
				num = num * -1521134295 + this.texture.GetHashCode();
			}
			bool flag2 = this.sprite != null;
			if (flag2)
			{
				num = num * -1521134295 + this.sprite.GetHashCode();
			}
			bool flag3 = this.renderTexture != null;
			if (flag3)
			{
				num = num * -1521134295 + this.renderTexture.GetHashCode();
			}
			bool flag4 = this.vectorImage != null;
			if (flag4)
			{
				num = num * -1521134295 + this.vectorImage.GetHashCode();
			}
			return num;
		}

		// Token: 0x06001496 RID: 5270 RVA: 0x0004947C File Offset: 0x0004767C
		public override string ToString()
		{
			bool flag = this.texture != null;
			string result;
			if (flag)
			{
				result = this.texture.ToString();
			}
			else
			{
				bool flag2 = this.sprite != null;
				if (flag2)
				{
					result = this.sprite.ToString();
				}
				else
				{
					bool flag3 = this.renderTexture != null;
					if (flag3)
					{
						result = this.renderTexture.ToString();
					}
					else
					{
						bool flag4 = this.vectorImage != null;
						if (flag4)
						{
							result = this.vectorImage.ToString();
						}
						else
						{
							result = "";
						}
					}
				}
			}
			return result;
		}

		// Token: 0x04000989 RID: 2441
		private Texture2D m_Texture;

		// Token: 0x0400098A RID: 2442
		private Sprite m_Sprite;

		// Token: 0x0400098B RID: 2443
		private RenderTexture m_RenderTexture;

		// Token: 0x0400098C RID: 2444
		private VectorImage m_VectorImage;
	}
}
