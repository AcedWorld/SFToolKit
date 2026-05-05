using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003D7 RID: 983
	public abstract class UxmlTypeRestriction : IEquatable<UxmlTypeRestriction>
	{
		// Token: 0x06002033 RID: 8243 RVA: 0x00079A20 File Offset: 0x00077C20
		public virtual bool Equals(UxmlTypeRestriction other)
		{
			return this == other;
		}
	}
}
