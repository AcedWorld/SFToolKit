using System;
using System.Linq;

namespace UnityEngine.UIElements
{
	// Token: 0x02000351 RID: 849
	[Serializable]
	internal class StyleSelector
	{
		// Token: 0x170006A5 RID: 1701
		// (get) Token: 0x06001C78 RID: 7288 RVA: 0x0006E9A8 File Offset: 0x0006CBA8
		// (set) Token: 0x06001C79 RID: 7289 RVA: 0x0006E9C0 File Offset: 0x0006CBC0
		public StyleSelectorPart[] parts
		{
			get
			{
				return this.m_Parts;
			}
			internal set
			{
				this.m_Parts = value;
			}
		}

		// Token: 0x170006A6 RID: 1702
		// (get) Token: 0x06001C7A RID: 7290 RVA: 0x0006E9CC File Offset: 0x0006CBCC
		// (set) Token: 0x06001C7B RID: 7291 RVA: 0x0006E9E4 File Offset: 0x0006CBE4
		public StyleSelectorRelationship previousRelationship
		{
			get
			{
				return this.m_PreviousRelationship;
			}
			internal set
			{
				this.m_PreviousRelationship = value;
			}
		}

		// Token: 0x06001C7C RID: 7292 RVA: 0x0006E9F0 File Offset: 0x0006CBF0
		public override string ToString()
		{
			return string.Join(", ", (from p in this.parts
			select p.ToString()).ToArray<string>());
		}

		// Token: 0x04000BC6 RID: 3014
		[SerializeField]
		private StyleSelectorPart[] m_Parts;

		// Token: 0x04000BC7 RID: 3015
		[SerializeField]
		private StyleSelectorRelationship m_PreviousRelationship;

		// Token: 0x04000BC8 RID: 3016
		internal int pseudoStateMask = -1;

		// Token: 0x04000BC9 RID: 3017
		internal int negatedPseudoStateMask = -1;
	}
}
