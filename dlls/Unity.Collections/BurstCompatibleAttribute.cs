using System;

namespace Unity.Collections
{
	// Token: 0x02000023 RID: 35
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
	public class BurstCompatibleAttribute : Attribute
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00003A46 File Offset: 0x00001C46
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x00003A4E File Offset: 0x00001C4E
		public Type[] GenericTypeArguments { get; set; }

		// Token: 0x0400006E RID: 110
		public string RequiredUnityDefine;

		// Token: 0x0400006F RID: 111
		public BurstCompatibleAttribute.BurstCompatibleCompileTarget CompileTarget;

		// Token: 0x02000024 RID: 36
		public enum BurstCompatibleCompileTarget
		{
			// Token: 0x04000071 RID: 113
			Player,
			// Token: 0x04000072 RID: 114
			Editor,
			// Token: 0x04000073 RID: 115
			PlayerAndEditor
		}
	}
}
