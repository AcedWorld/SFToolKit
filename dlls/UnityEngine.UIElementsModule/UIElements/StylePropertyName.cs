using System;
using UnityEngine.UIElements.StyleSheets;

namespace UnityEngine.UIElements
{
	// Token: 0x02000348 RID: 840
	public struct StylePropertyName : IEquatable<StylePropertyName>
	{
		// Token: 0x1700069B RID: 1691
		// (get) Token: 0x06001C4D RID: 7245 RVA: 0x0006E207 File Offset: 0x0006C407
		internal readonly StylePropertyId id { get; }

		// Token: 0x1700069C RID: 1692
		// (get) Token: 0x06001C4E RID: 7246 RVA: 0x0006E20F File Offset: 0x0006C40F
		private readonly string name { get; }

		// Token: 0x06001C4F RID: 7247 RVA: 0x0006E218 File Offset: 0x0006C418
		internal static StylePropertyId StylePropertyIdFromString(string name)
		{
			StylePropertyId stylePropertyId;
			bool flag = StylePropertyUtil.s_NameToId.TryGetValue(name, out stylePropertyId);
			StylePropertyId result;
			if (flag)
			{
				result = stylePropertyId;
			}
			else
			{
				result = StylePropertyId.Unknown;
			}
			return result;
		}

		// Token: 0x06001C50 RID: 7248 RVA: 0x0006E244 File Offset: 0x0006C444
		internal StylePropertyName(StylePropertyId stylePropertyId)
		{
			this.id = stylePropertyId;
			this.name = null;
			string text;
			bool flag = StylePropertyUtil.s_IdToName.TryGetValue(stylePropertyId, out text);
			if (flag)
			{
				this.name = text;
			}
		}

		// Token: 0x06001C51 RID: 7249 RVA: 0x0006E27C File Offset: 0x0006C47C
		public StylePropertyName(string name)
		{
			this.id = StylePropertyName.StylePropertyIdFromString(name);
			this.name = null;
			bool flag = this.id > StylePropertyId.Unknown;
			if (flag)
			{
				this.name = name;
			}
		}

		// Token: 0x06001C52 RID: 7250 RVA: 0x0006E2B4 File Offset: 0x0006C4B4
		public static bool IsNullOrEmpty(StylePropertyName propertyName)
		{
			return propertyName.id == StylePropertyId.Unknown;
		}

		// Token: 0x06001C53 RID: 7251 RVA: 0x0006E2D0 File Offset: 0x0006C4D0
		public static bool operator ==(StylePropertyName lhs, StylePropertyName rhs)
		{
			return lhs.id == rhs.id;
		}

		// Token: 0x06001C54 RID: 7252 RVA: 0x0006E2F4 File Offset: 0x0006C4F4
		public static bool operator !=(StylePropertyName lhs, StylePropertyName rhs)
		{
			return lhs.id != rhs.id;
		}

		// Token: 0x06001C55 RID: 7253 RVA: 0x0006E31C File Offset: 0x0006C51C
		public static implicit operator StylePropertyName(string name)
		{
			return new StylePropertyName(name);
		}

		// Token: 0x06001C56 RID: 7254 RVA: 0x0006E334 File Offset: 0x0006C534
		public override int GetHashCode()
		{
			return (int)this.id;
		}

		// Token: 0x06001C57 RID: 7255 RVA: 0x0006E34C File Offset: 0x0006C54C
		public override bool Equals(object other)
		{
			return other is StylePropertyName && this.Equals((StylePropertyName)other);
		}

		// Token: 0x06001C58 RID: 7256 RVA: 0x0006E378 File Offset: 0x0006C578
		public bool Equals(StylePropertyName other)
		{
			return this == other;
		}

		// Token: 0x06001C59 RID: 7257 RVA: 0x0006E398 File Offset: 0x0006C598
		public override string ToString()
		{
			return this.name;
		}
	}
}
