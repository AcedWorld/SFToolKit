using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Unity.Services.Core.Internal
{
	// Token: 0x0200003A RID: 58
	internal class LockedComponentRegistry : IComponentRegistry
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00002D10 File Offset: 0x00000F10
		[NotNull]
		internal IComponentRegistry Registry { get; }

		// Token: 0x060000ED RID: 237 RVA: 0x00002D18 File Offset: 0x00000F18
		public LockedComponentRegistry([NotNull] IComponentRegistry registryToLock)
		{
			this.Registry = registryToLock;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00002D27 File Offset: 0x00000F27
		public void RegisterServiceComponent<TComponent>(TComponent component) where TComponent : IServiceComponent
		{
			throw new InvalidOperationException("Component registration has been locked. Make sure to register service components before all packages have finished initializing.");
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00002D33 File Offset: 0x00000F33
		public TComponent GetServiceComponent<TComponent>() where TComponent : IServiceComponent
		{
			return this.Registry.GetServiceComponent<TComponent>();
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00002D40 File Offset: 0x00000F40
		public bool TryGetServiceComponent<TComponent>(out TComponent component) where TComponent : IServiceComponent
		{
			return this.Registry.TryGetServiceComponent<TComponent>(out component);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00002D4E File Offset: 0x00000F4E
		public void ResetProvidedComponents(IDictionary<int, IServiceComponent> componentTypeHashToInstance)
		{
			throw new InvalidOperationException("Component registration has been locked. Make sure to register service components before all packages have finished initializing.");
		}

		// Token: 0x04000038 RID: 56
		private const string k_ErrorMessage = "Component registration has been locked. Make sure to register service components before all packages have finished initializing.";
	}
}
