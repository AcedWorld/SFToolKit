using System;
using System.Collections.Generic;
using UnityEngine.TextCore.Text;

namespace UnityEngine.UIElements
{
	// Token: 0x020002CF RID: 719
	public struct FontDefinition : IEquatable<FontDefinition>
	{
		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x06001569 RID: 5481 RVA: 0x00054DC0 File Offset: 0x00052FC0
		// (set) Token: 0x0600156A RID: 5482 RVA: 0x00054DD8 File Offset: 0x00052FD8
		public Font font
		{
			get
			{
				return this.m_Font;
			}
			set
			{
				bool flag = value != null && this.fontAsset != null;
				if (flag)
				{
					throw new InvalidOperationException("Cannot set both Font and FontAsset on FontDefinition");
				}
				this.m_Font = value;
			}
		}

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x0600156B RID: 5483 RVA: 0x00054E14 File Offset: 0x00053014
		// (set) Token: 0x0600156C RID: 5484 RVA: 0x00054E2C File Offset: 0x0005302C
		public FontAsset fontAsset
		{
			get
			{
				return this.m_FontAsset;
			}
			set
			{
				bool flag = value != null && this.font != null;
				if (flag)
				{
					throw new InvalidOperationException("Cannot set both Font and FontAsset on FontDefinition");
				}
				this.m_FontAsset = value;
			}
		}

		// Token: 0x0600156D RID: 5485 RVA: 0x00054E68 File Offset: 0x00053068
		public static FontDefinition FromFont(Font f)
		{
			return new FontDefinition
			{
				m_Font = f
			};
		}

		// Token: 0x0600156E RID: 5486 RVA: 0x00054E8C File Offset: 0x0005308C
		public static FontDefinition FromSDFFont(FontAsset f)
		{
			return new FontDefinition
			{
				m_FontAsset = f
			};
		}

		// Token: 0x0600156F RID: 5487 RVA: 0x00054EB0 File Offset: 0x000530B0
		internal static FontDefinition FromObject(object obj)
		{
			Font font = obj as Font;
			bool flag = font != null;
			FontDefinition result;
			if (flag)
			{
				result = FontDefinition.FromFont(font);
			}
			else
			{
				FontAsset fontAsset = obj as FontAsset;
				bool flag2 = fontAsset != null;
				if (flag2)
				{
					result = FontDefinition.FromSDFFont(fontAsset);
				}
				else
				{
					result = default(FontDefinition);
				}
			}
			return result;
		}

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x06001570 RID: 5488 RVA: 0x00054F04 File Offset: 0x00053104
		internal static IEnumerable<Type> allowedAssetTypes
		{
			get
			{
				yield return typeof(Font);
				yield return typeof(FontAsset);
				yield break;
			}
		}

		// Token: 0x06001571 RID: 5489 RVA: 0x00054F1C File Offset: 0x0005311C
		internal bool IsEmpty()
		{
			return this.m_Font == null && this.m_FontAsset == null;
		}

		// Token: 0x06001572 RID: 5490 RVA: 0x00054F4C File Offset: 0x0005314C
		public override string ToString()
		{
			bool flag = this.font != null;
			string result;
			if (flag)
			{
				result = string.Format("{0}", this.font);
			}
			else
			{
				result = string.Format("{0}", this.fontAsset);
			}
			return result;
		}

		// Token: 0x06001573 RID: 5491 RVA: 0x00054F94 File Offset: 0x00053194
		public bool Equals(FontDefinition other)
		{
			return object.Equals(this.m_Font, other.m_Font) && object.Equals(this.m_FontAsset, other.m_FontAsset);
		}

		// Token: 0x06001574 RID: 5492 RVA: 0x00054FD0 File Offset: 0x000531D0
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is FontDefinition)
			{
				FontDefinition other = (FontDefinition)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001575 RID: 5493 RVA: 0x00054FFC File Offset: 0x000531FC
		public override int GetHashCode()
		{
			return ((this.m_Font != null) ? this.m_Font.GetHashCode() : 0) * 397 ^ ((this.m_FontAsset != null) ? this.m_FontAsset.GetHashCode() : 0);
		}

		// Token: 0x06001576 RID: 5494 RVA: 0x00055050 File Offset: 0x00053250
		public static bool operator ==(FontDefinition left, FontDefinition right)
		{
			return left.Equals(right);
		}

		// Token: 0x06001577 RID: 5495 RVA: 0x0005506C File Offset: 0x0005326C
		public static bool operator !=(FontDefinition left, FontDefinition right)
		{
			return !left.Equals(right);
		}

		// Token: 0x040009D2 RID: 2514
		private Font m_Font;

		// Token: 0x040009D3 RID: 2515
		private FontAsset m_FontAsset;
	}
}
