using System;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x0200019C RID: 412
	public sealed class fsDuplicateVersionNameException : Exception
	{
		// Token: 0x06000AD8 RID: 2776 RVA: 0x0002D4E4 File Offset: 0x0002B6E4
		public fsDuplicateVersionNameException(Type typeA, Type typeB, string version) : base(string.Concat(new string[]
		{
			(typeA != null) ? typeA.ToString() : null,
			" and ",
			(typeB != null) ? typeB.ToString() : null,
			" have the same version string (",
			version,
			"); please change one of them."
		}))
		{
		}
	}
}
