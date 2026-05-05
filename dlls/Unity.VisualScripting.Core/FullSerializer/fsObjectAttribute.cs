using System;

namespace Unity.VisualScripting.FullSerializer
{
	// Token: 0x020001A4 RID: 420
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class fsObjectAttribute : Attribute
	{
		// Token: 0x06000B09 RID: 2825 RVA: 0x0002E88B File Offset: 0x0002CA8B
		public fsObjectAttribute()
		{
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x0002E89A File Offset: 0x0002CA9A
		public fsObjectAttribute(string versionString, params Type[] previousModels)
		{
			this.VersionString = versionString;
			this.PreviousModels = previousModels;
		}

		// Token: 0x0400028E RID: 654
		public Type[] PreviousModels;

		// Token: 0x0400028F RID: 655
		public string VersionString;

		// Token: 0x04000290 RID: 656
		public fsMemberSerialization MemberSerialization = fsMemberSerialization.Default;

		// Token: 0x04000291 RID: 657
		public Type Converter;

		// Token: 0x04000292 RID: 658
		public Type Processor;
	}
}
