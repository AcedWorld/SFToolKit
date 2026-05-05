using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000B1 RID: 177
	[AttributeUsage(AttributeTargets.Field)]
	public class HLSLArray : Attribute
	{
		// Token: 0x06000559 RID: 1369 RVA: 0x0001B8E7 File Offset: 0x00019AE7
		public HLSLArray(int arraySize, Type elementType)
		{
			this.arraySize = arraySize;
			this.elementType = elementType;
		}

		// Token: 0x040003E8 RID: 1000
		public int arraySize;

		// Token: 0x040003E9 RID: 1001
		public Type elementType;
	}
}
