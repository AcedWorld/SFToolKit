using System;

namespace Unity.Netcode
{
	// Token: 0x02000045 RID: 69
	public class SpawnStateException : Exception
	{
		// Token: 0x06000202 RID: 514 RVA: 0x0000ABFD File Offset: 0x00008DFD
		public SpawnStateException()
		{
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000519D File Offset: 0x0000339D
		public SpawnStateException(string message) : base(message)
		{
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0000AC05 File Offset: 0x00008E05
		public SpawnStateException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
