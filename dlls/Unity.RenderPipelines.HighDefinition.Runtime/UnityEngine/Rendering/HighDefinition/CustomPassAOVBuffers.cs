using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200018F RID: 399
	public class CustomPassAOVBuffers
	{
		// Token: 0x06000C79 RID: 3193 RVA: 0x0006857C File Offset: 0x0006677C
		public CustomPassAOVBuffers(CustomPassInjectionPoint injectionPoint, CustomPassAOVBuffers.OutputType outputType)
		{
			this.injectionPoint = injectionPoint;
			this.outputType = outputType;
		}

		// Token: 0x040013A0 RID: 5024
		public CustomPassInjectionPoint injectionPoint;

		// Token: 0x040013A1 RID: 5025
		public CustomPassAOVBuffers.OutputType outputType;

		// Token: 0x020003DB RID: 987
		public enum OutputType
		{
			// Token: 0x0400282A RID: 10282
			CustomPassBuffer,
			// Token: 0x0400282B RID: 10283
			Camera
		}
	}
}
