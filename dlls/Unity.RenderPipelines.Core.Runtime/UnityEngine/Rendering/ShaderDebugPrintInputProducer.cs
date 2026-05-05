using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200007D RID: 125
	public static class ShaderDebugPrintInputProducer
	{
		// Token: 0x060003E5 RID: 997 RVA: 0x00010B8C File Offset: 0x0000ED8C
		public static ShaderDebugPrintInput Get()
		{
			return new ShaderDebugPrintInput
			{
				pos = Input.mousePosition,
				leftDown = Input.GetMouseButton(0),
				rightDown = Input.GetMouseButton(1),
				middleDown = Input.GetMouseButton(2)
			};
		}
	}
}
