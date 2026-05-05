using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityEngine.UIElements
{
	// Token: 0x020003DA RID: 986
	public class UxmlEnumeration : UxmlTypeRestriction
	{
		// Token: 0x17000781 RID: 1921
		// (get) Token: 0x06002043 RID: 8259 RVA: 0x00079B38 File Offset: 0x00077D38
		// (set) Token: 0x06002044 RID: 8260 RVA: 0x00079B50 File Offset: 0x00077D50
		public IEnumerable<string> values
		{
			get
			{
				return this.m_Values;
			}
			set
			{
				this.m_Values = value.ToList<string>();
			}
		}

		// Token: 0x06002045 RID: 8261 RVA: 0x00079B60 File Offset: 0x00077D60
		public override bool Equals(UxmlTypeRestriction other)
		{
			UxmlEnumeration uxmlEnumeration = other as UxmlEnumeration;
			bool flag = uxmlEnumeration == null;
			return !flag && this.values.All(new Func<string, bool>(uxmlEnumeration.values.Contains<string>)) && this.values.Count<string>() == uxmlEnumeration.values.Count<string>();
		}

		// Token: 0x04000D48 RID: 3400
		private List<string> m_Values = new List<string>();
	}
}
