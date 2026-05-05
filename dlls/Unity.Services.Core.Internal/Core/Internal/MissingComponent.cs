using System;

namespace Unity.Services.Core.Internal
{
	// Token: 0x02000049 RID: 73
	internal class MissingComponent : IServiceComponent
	{
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000139 RID: 313 RVA: 0x000037F1 File Offset: 0x000019F1
		public Type IntendedType { get; }

		// Token: 0x0600013A RID: 314 RVA: 0x000037F9 File Offset: 0x000019F9
		internal MissingComponent(Type intendedType)
		{
			this.IntendedType = intendedType;
		}
	}
}
