using System;
using Unity.VisualScripting.FullSerializer;

namespace Unity.VisualScripting
{
	// Token: 0x0200013D RID: 317
	public class SerializationVersionAttribute : fsObjectAttribute
	{
		// Token: 0x060008A5 RID: 2213 RVA: 0x000263FA File Offset: 0x000245FA
		public SerializationVersionAttribute(string versionString, params Type[] previousModels) : base(versionString, previousModels)
		{
		}
	}
}
