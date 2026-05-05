using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x0200040C RID: 1036
	public struct VisualElementStyleSheetSet : IEquatable<VisualElementStyleSheetSet>
	{
		// Token: 0x06002115 RID: 8469 RVA: 0x0007D124 File Offset: 0x0007B324
		internal VisualElementStyleSheetSet(VisualElement element)
		{
			this.m_Element = element;
		}

		// Token: 0x06002116 RID: 8470 RVA: 0x0007D130 File Offset: 0x0007B330
		public void Add(StyleSheet styleSheet)
		{
			bool flag = styleSheet == null;
			if (flag)
			{
				throw new ArgumentNullException("styleSheet");
			}
			bool flag2 = this.m_Element.styleSheetList == null;
			if (flag2)
			{
				this.m_Element.styleSheetList = new List<StyleSheet>();
			}
			else
			{
				bool flag3 = this.m_Element.styleSheetList.Contains(styleSheet);
				if (flag3)
				{
					return;
				}
			}
			this.m_Element.styleSheetList.Add(styleSheet);
			this.m_Element.IncrementVersion(VersionChangeType.StyleSheet);
		}

		// Token: 0x06002117 RID: 8471 RVA: 0x0007D1B4 File Offset: 0x0007B3B4
		public void Clear()
		{
			bool flag = this.m_Element.styleSheetList == null;
			if (!flag)
			{
				this.m_Element.styleSheetList = null;
				this.m_Element.IncrementVersion(VersionChangeType.StyleSheet);
			}
		}

		// Token: 0x06002118 RID: 8472 RVA: 0x0007D1F0 File Offset: 0x0007B3F0
		public bool Remove(StyleSheet styleSheet)
		{
			bool flag = styleSheet == null;
			if (flag)
			{
				throw new ArgumentNullException("styleSheet");
			}
			bool flag2 = this.m_Element.styleSheetList != null && this.m_Element.styleSheetList.Remove(styleSheet);
			bool result;
			if (flag2)
			{
				bool flag3 = this.m_Element.styleSheetList.Count == 0;
				if (flag3)
				{
					this.m_Element.styleSheetList = null;
				}
				this.m_Element.IncrementVersion(VersionChangeType.StyleSheet);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06002119 RID: 8473 RVA: 0x0007D278 File Offset: 0x0007B478
		internal void Swap(StyleSheet old, StyleSheet @new)
		{
			bool flag = old == null;
			if (flag)
			{
				throw new ArgumentNullException("old");
			}
			bool flag2 = @new == null;
			if (flag2)
			{
				throw new ArgumentNullException("new");
			}
			bool flag3 = this.m_Element.styleSheetList == null;
			if (!flag3)
			{
				int num = this.m_Element.styleSheetList.IndexOf(old);
				bool flag4 = num >= 0;
				if (flag4)
				{
					this.m_Element.IncrementVersion(VersionChangeType.StyleSheet);
					this.m_Element.styleSheetList[num] = @new;
				}
			}
		}

		// Token: 0x0600211A RID: 8474 RVA: 0x0007D30C File Offset: 0x0007B50C
		public bool Contains(StyleSheet styleSheet)
		{
			bool flag = styleSheet == null;
			if (flag)
			{
				throw new ArgumentNullException("styleSheet");
			}
			bool flag2 = this.m_Element.styleSheetList != null;
			return flag2 && this.m_Element.styleSheetList.Contains(styleSheet);
		}

		// Token: 0x170007AC RID: 1964
		// (get) Token: 0x0600211B RID: 8475 RVA: 0x0007D35C File Offset: 0x0007B55C
		public int count
		{
			get
			{
				bool flag = this.m_Element.styleSheetList == null;
				int result;
				if (flag)
				{
					result = 0;
				}
				else
				{
					result = this.m_Element.styleSheetList.Count;
				}
				return result;
			}
		}

		// Token: 0x170007AD RID: 1965
		public StyleSheet this[int index]
		{
			get
			{
				bool flag = this.m_Element.styleSheetList == null;
				if (flag)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return this.m_Element.styleSheetList[index];
			}
		}

		// Token: 0x0600211D RID: 8477 RVA: 0x0007D3D4 File Offset: 0x0007B5D4
		public bool Equals(VisualElementStyleSheetSet other)
		{
			return object.Equals(this.m_Element, other.m_Element);
		}

		// Token: 0x0600211E RID: 8478 RVA: 0x0007D3F8 File Offset: 0x0007B5F8
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is VisualElementStyleSheetSet && this.Equals((VisualElementStyleSheetSet)obj);
		}

		// Token: 0x0600211F RID: 8479 RVA: 0x0007D430 File Offset: 0x0007B630
		public override int GetHashCode()
		{
			return (this.m_Element != null) ? this.m_Element.GetHashCode() : 0;
		}

		// Token: 0x06002120 RID: 8480 RVA: 0x0007D458 File Offset: 0x0007B658
		public static bool operator ==(VisualElementStyleSheetSet left, VisualElementStyleSheetSet right)
		{
			return left.Equals(right);
		}

		// Token: 0x06002121 RID: 8481 RVA: 0x0007D474 File Offset: 0x0007B674
		public static bool operator !=(VisualElementStyleSheetSet left, VisualElementStyleSheetSet right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000DFC RID: 3580
		private readonly VisualElement m_Element;
	}
}
