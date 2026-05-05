using System;
using System.Runtime.InteropServices;
using UnityEngine.TextCore.Text;

namespace UnityEngine.UIElements
{
	// Token: 0x02000304 RID: 772
	public struct StyleFontDefinition : IStyleValue<FontDefinition>, IEquatable<StyleFontDefinition>
	{
		// Token: 0x1700066E RID: 1646
		// (get) Token: 0x06001A73 RID: 6771 RVA: 0x000691C4 File Offset: 0x000673C4
		// (set) Token: 0x06001A74 RID: 6772 RVA: 0x000691EF File Offset: 0x000673EF
		public FontDefinition value
		{
			get
			{
				return (this.m_Keyword == StyleKeyword.Undefined) ? this.m_Value : default(FontDefinition);
			}
			set
			{
				this.m_Value = value;
				this.m_Keyword = StyleKeyword.Undefined;
			}
		}

		// Token: 0x1700066F RID: 1647
		// (get) Token: 0x06001A75 RID: 6773 RVA: 0x00069200 File Offset: 0x00067400
		// (set) Token: 0x06001A76 RID: 6774 RVA: 0x00069218 File Offset: 0x00067418
		public StyleKeyword keyword
		{
			get
			{
				return this.m_Keyword;
			}
			set
			{
				this.m_Keyword = value;
			}
		}

		// Token: 0x06001A77 RID: 6775 RVA: 0x00069222 File Offset: 0x00067422
		public StyleFontDefinition(FontDefinition f)
		{
			this = new StyleFontDefinition(f, StyleKeyword.Undefined);
		}

		// Token: 0x06001A78 RID: 6776 RVA: 0x0006922E File Offset: 0x0006742E
		public StyleFontDefinition(FontAsset f)
		{
			this = new StyleFontDefinition(f, StyleKeyword.Undefined);
		}

		// Token: 0x06001A79 RID: 6777 RVA: 0x0006923A File Offset: 0x0006743A
		public StyleFontDefinition(Font f)
		{
			this = new StyleFontDefinition(f, StyleKeyword.Undefined);
		}

		// Token: 0x06001A7A RID: 6778 RVA: 0x00069248 File Offset: 0x00067448
		public StyleFontDefinition(StyleKeyword keyword)
		{
			this = new StyleFontDefinition(default(FontDefinition), keyword);
		}

		// Token: 0x06001A7B RID: 6779 RVA: 0x00069267 File Offset: 0x00067467
		internal StyleFontDefinition(object obj, StyleKeyword keyword)
		{
			this = new StyleFontDefinition(FontDefinition.FromObject(obj), keyword);
		}

		// Token: 0x06001A7C RID: 6780 RVA: 0x00069278 File Offset: 0x00067478
		internal StyleFontDefinition(object obj)
		{
			this = new StyleFontDefinition(FontDefinition.FromObject(obj), StyleKeyword.Undefined);
		}

		// Token: 0x06001A7D RID: 6781 RVA: 0x00069289 File Offset: 0x00067489
		internal StyleFontDefinition(FontAsset f, StyleKeyword keyword)
		{
			this = new StyleFontDefinition(FontDefinition.FromSDFFont(f), keyword);
		}

		// Token: 0x06001A7E RID: 6782 RVA: 0x0006929A File Offset: 0x0006749A
		internal StyleFontDefinition(Font f, StyleKeyword keyword)
		{
			this = new StyleFontDefinition(FontDefinition.FromFont(f), keyword);
		}

		// Token: 0x06001A7F RID: 6783 RVA: 0x000692AC File Offset: 0x000674AC
		internal StyleFontDefinition(GCHandle gcHandle, StyleKeyword keyword)
		{
			this = new StyleFontDefinition(gcHandle.IsAllocated ? FontDefinition.FromObject(gcHandle.Target) : default(FontDefinition), keyword);
		}

		// Token: 0x06001A80 RID: 6784 RVA: 0x000692E2 File Offset: 0x000674E2
		internal StyleFontDefinition(FontDefinition f, StyleKeyword keyword)
		{
			this.m_Keyword = keyword;
			this.m_Value = f;
		}

		// Token: 0x06001A81 RID: 6785 RVA: 0x000692F3 File Offset: 0x000674F3
		internal StyleFontDefinition(StyleFontDefinition sfd)
		{
			this.m_Keyword = sfd.keyword;
			this.m_Value = sfd.value;
		}

		// Token: 0x06001A82 RID: 6786 RVA: 0x00069310 File Offset: 0x00067510
		public static implicit operator StyleFontDefinition(StyleKeyword keyword)
		{
			return new StyleFontDefinition(keyword);
		}

		// Token: 0x06001A83 RID: 6787 RVA: 0x00069328 File Offset: 0x00067528
		public static implicit operator StyleFontDefinition(FontDefinition f)
		{
			return new StyleFontDefinition(f);
		}

		// Token: 0x06001A84 RID: 6788 RVA: 0x00069340 File Offset: 0x00067540
		public bool Equals(StyleFontDefinition other)
		{
			return this.m_Keyword == other.m_Keyword && this.m_Value.Equals(other.m_Value);
		}

		// Token: 0x06001A85 RID: 6789 RVA: 0x00069374 File Offset: 0x00067574
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is StyleFontDefinition)
			{
				StyleFontDefinition other = (StyleFontDefinition)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001A86 RID: 6790 RVA: 0x000693A0 File Offset: 0x000675A0
		public override int GetHashCode()
		{
			return (int)(this.m_Keyword * (StyleKeyword)397 ^ (StyleKeyword)this.m_Value.GetHashCode());
		}

		// Token: 0x06001A87 RID: 6791 RVA: 0x000693D4 File Offset: 0x000675D4
		public static bool operator ==(StyleFontDefinition left, StyleFontDefinition right)
		{
			return left.Equals(right);
		}

		// Token: 0x06001A88 RID: 6792 RVA: 0x000693F0 File Offset: 0x000675F0
		public static bool operator !=(StyleFontDefinition left, StyleFontDefinition right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000AEA RID: 2794
		private StyleKeyword m_Keyword;

		// Token: 0x04000AEB RID: 2795
		private FontDefinition m_Value;
	}
}
