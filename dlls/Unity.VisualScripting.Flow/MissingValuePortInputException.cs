using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000172 RID: 370
	public sealed class MissingValuePortInputException : Exception
	{
		// Token: 0x0600097A RID: 2426 RVA: 0x00010F18 File Offset: 0x0000F118
		public MissingValuePortInputException(string key) : base("Missing input value for '" + key + "'.")
		{
		}
	}
}
