using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003D1 RID: 977
	public class UxmlFactory<TCreatedType, TTraits> : BaseUxmlFactory<TCreatedType, TTraits>, IUxmlFactory, IBaseUxmlFactory where TCreatedType : VisualElement, new() where TTraits : UxmlTraits, new()
	{
		// Token: 0x06002016 RID: 8214 RVA: 0x000794A0 File Offset: 0x000776A0
		public virtual VisualElement Create(IUxmlAttributes bag, CreationContext cc)
		{
			TCreatedType tcreatedType = Activator.CreateInstance<TCreatedType>();
			this.m_Traits.Init(tcreatedType, bag, cc);
			return tcreatedType;
		}
	}
}
