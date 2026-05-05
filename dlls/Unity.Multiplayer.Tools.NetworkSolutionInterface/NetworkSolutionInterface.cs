using System;

namespace Unity.Multiplayer.Tools
{
	// Token: 0x02000005 RID: 5
	internal static class NetworkSolutionInterface
	{
		// Token: 0x06000004 RID: 4 RVA: 0x000020C0 File Offset: 0x000002C0
		public static void SetInterface(NetworkSolutionInterfaceParameters parameters)
		{
			ref INetworkObjectProvider ptr = ref parameters.NetworkObjectProvider;
			if (ptr == null)
			{
				ptr = new NullNetworkObjectProvider();
			}
			NetworkSolutionInterface.s_Parameters = parameters;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020E6 File Offset: 0x000002E6
		internal static INetworkObjectProvider NetworkObjectProvider
		{
			get
			{
				return NetworkSolutionInterface.s_Parameters.NetworkObjectProvider;
			}
		}

		// Token: 0x04000002 RID: 2
		private static NetworkSolutionInterfaceParameters s_Parameters;
	}
}
