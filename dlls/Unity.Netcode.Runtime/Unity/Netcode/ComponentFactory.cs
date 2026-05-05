using System;
using System.Collections.Generic;

namespace Unity.Netcode
{
	// Token: 0x02000017 RID: 23
	internal static class ComponentFactory
	{
		// Token: 0x0600007E RID: 126 RVA: 0x0000509F File Offset: 0x0000329F
		public static T Create<T>(NetworkManager networkManager)
		{
			return (T)((object)ComponentFactory.s_Delegates[typeof(T)](networkManager));
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000050C0 File Offset: 0x000032C0
		public static void Register<T>(ComponentFactory.CreateObjectDelegate creator)
		{
			ComponentFactory.s_Delegates[typeof(T)] = creator;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000050D7 File Offset: 0x000032D7
		public static void Deregister<T>()
		{
			ComponentFactory.s_Delegates.Remove(typeof(T));
			ComponentFactory.SetDefaults();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000050F4 File Offset: 0x000032F4
		public static void SetDefaults()
		{
			ComponentFactory.SetDefault<IDeferredNetworkMessageManager>((NetworkManager networkManager) => new DeferredMessageManager(networkManager));
			ComponentFactory.SetDefault<IRealTimeProvider>((NetworkManager networkManager) => new RealTimeProvider());
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00005149 File Offset: 0x00003349
		private static void SetDefault<T>(ComponentFactory.CreateObjectDelegate creator)
		{
			if (!ComponentFactory.s_Delegates.ContainsKey(typeof(T)))
			{
				ComponentFactory.s_Delegates[typeof(T)] = creator;
			}
		}

		// Token: 0x04000064 RID: 100
		private static Dictionary<Type, ComponentFactory.CreateObjectDelegate> s_Delegates = new Dictionary<Type, ComponentFactory.CreateObjectDelegate>();

		// Token: 0x02000018 RID: 24
		// (Invoke) Token: 0x06000085 RID: 133
		internal delegate object CreateObjectDelegate(NetworkManager networkManager);
	}
}
