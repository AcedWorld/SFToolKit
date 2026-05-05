using System;

namespace Unity.Netcode
{
	// Token: 0x02000042 RID: 66
	public class NetworkConfigurationException : Exception
	{
		// Token: 0x060001F9 RID: 505 RVA: 0x0000ABFD File Offset: 0x00008DFD
		public NetworkConfigurationException()
		{
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000519D File Offset: 0x0000339D
		public NetworkConfigurationException(string message) : base(message)
		{
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000AC05 File Offset: 0x00008E05
		public NetworkConfigurationException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
