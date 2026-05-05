using System;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x0200022A RID: 554
	[RequiredByNativeCode]
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public sealed class RequireComponent : Attribute
	{
		// Token: 0x06001841 RID: 6209 RVA: 0x00028476 File Offset: 0x00026676
		public RequireComponent(Type requiredComponent)
		{
			this.m_Type0 = requiredComponent;
		}

		// Token: 0x06001842 RID: 6210 RVA: 0x00028487 File Offset: 0x00026687
		public RequireComponent(Type requiredComponent, Type requiredComponent2)
		{
			this.m_Type0 = requiredComponent;
			this.m_Type1 = requiredComponent2;
		}

		// Token: 0x06001843 RID: 6211 RVA: 0x0002849F File Offset: 0x0002669F
		public RequireComponent(Type requiredComponent, Type requiredComponent2, Type requiredComponent3)
		{
			this.m_Type0 = requiredComponent;
			this.m_Type1 = requiredComponent2;
			this.m_Type2 = requiredComponent3;
		}

		// Token: 0x0400088B RID: 2187
		public Type m_Type0;

		// Token: 0x0400088C RID: 2188
		public Type m_Type1;

		// Token: 0x0400088D RID: 2189
		public Type m_Type2;
	}
}
