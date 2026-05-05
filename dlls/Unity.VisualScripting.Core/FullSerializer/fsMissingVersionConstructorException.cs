using System;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x0200019B RID: 411
	public sealed class fsMissingVersionConstructorException : Exception
	{
		// Token: 0x06000AD7 RID: 2775 RVA: 0x0002D4B5 File Offset: 0x0002B6B5
		public fsMissingVersionConstructorException(Type versionedType, Type constructorType) : base(((versionedType != null) ? versionedType.ToString() : null) + " is missing a constructor for previous model type " + ((constructorType != null) ? constructorType.ToString() : null))
		{
		}
	}
}
