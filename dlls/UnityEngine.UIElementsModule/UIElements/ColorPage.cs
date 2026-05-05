using System;
using UnityEngine.UIElements.UIR;

namespace UnityEngine.UIElements
{
	// Token: 0x020002AC RID: 684
	internal struct ColorPage
	{
		// Token: 0x060013AC RID: 5036 RVA: 0x00044EEC File Offset: 0x000430EC
		public static ColorPage Init(RenderChain renderChain, BMPAlloc alloc)
		{
			bool flag = alloc.IsValid();
			return new ColorPage
			{
				isValid = flag,
				pageAndID = (flag ? renderChain.shaderInfoAllocator.ColorAllocToVertexData(alloc) : default(Color32))
			};
		}

		// Token: 0x060013AD RID: 5037 RVA: 0x00044F38 File Offset: 0x00043138
		public MeshBuilderNative.NativeColorPage ToNativeColorPage()
		{
			return new MeshBuilderNative.NativeColorPage
			{
				isValid = (this.isValid ? 1 : 0),
				pageAndID = this.pageAndID
			};
		}

		// Token: 0x04000904 RID: 2308
		public bool isValid;

		// Token: 0x04000905 RID: 2309
		public Color32 pageAndID;
	}
}
