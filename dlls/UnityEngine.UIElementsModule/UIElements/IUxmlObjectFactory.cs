using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003CF RID: 975
	internal interface IUxmlObjectFactory<out T> : IBaseUxmlObjectFactory, IBaseUxmlFactory where T : new()
	{
		// Token: 0x06002009 RID: 8201
		T CreateObject(IUxmlAttributes bag, CreationContext cc);
	}
}
