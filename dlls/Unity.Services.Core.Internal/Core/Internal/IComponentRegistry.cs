using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Unity.Services.Core.Internal
{
	// Token: 0x02000039 RID: 57
	internal interface IComponentRegistry
	{
		// Token: 0x060000E8 RID: 232
		void RegisterServiceComponent<TComponent>([NotNull] TComponent component) where TComponent : IServiceComponent;

		// Token: 0x060000E9 RID: 233
		TComponent GetServiceComponent<TComponent>() where TComponent : IServiceComponent;

		// Token: 0x060000EA RID: 234
		bool TryGetServiceComponent<TComponent>(out TComponent component) where TComponent : IServiceComponent;

		// Token: 0x060000EB RID: 235
		void ResetProvidedComponents(IDictionary<int, IServiceComponent> componentTypeHashToInstance);
	}
}
