using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003D2 RID: 978
	internal class UxmlObjectFactory<TCreatedType, TTraits> : BaseUxmlFactory<TCreatedType, TTraits>, IUxmlObjectFactory<TCreatedType>, IBaseUxmlObjectFactory, IBaseUxmlFactory where TCreatedType : new() where TTraits : UxmlObjectTraits<TCreatedType>, new()
	{
		// Token: 0x06002018 RID: 8216 RVA: 0x000794E0 File Offset: 0x000776E0
		public virtual TCreatedType CreateObject(IUxmlAttributes bag, CreationContext cc)
		{
			TCreatedType result = Activator.CreateInstance<TCreatedType>();
			this.m_Traits.Init(ref result, bag, cc);
			return result;
		}
	}
}
