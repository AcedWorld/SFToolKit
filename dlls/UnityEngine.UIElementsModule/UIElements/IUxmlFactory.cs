using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003CD RID: 973
	public interface IUxmlFactory : IBaseUxmlFactory
	{
		// Token: 0x06002008 RID: 8200
		VisualElement Create(IUxmlAttributes bag, CreationContext cc);
	}
}
