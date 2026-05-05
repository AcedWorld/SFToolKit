using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200007C RID: 124
	public struct ShaderDebugPrintInput
	{
		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060003DC RID: 988 RVA: 0x00010AD5 File Offset: 0x0000ECD5
		// (set) Token: 0x060003DD RID: 989 RVA: 0x00010ADD File Offset: 0x0000ECDD
		public Vector2 pos { readonly get; set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060003DE RID: 990 RVA: 0x00010AE6 File Offset: 0x0000ECE6
		// (set) Token: 0x060003DF RID: 991 RVA: 0x00010AEE File Offset: 0x0000ECEE
		public bool leftDown { readonly get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060003E0 RID: 992 RVA: 0x00010AF7 File Offset: 0x0000ECF7
		// (set) Token: 0x060003E1 RID: 993 RVA: 0x00010AFF File Offset: 0x0000ECFF
		public bool rightDown { readonly get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x00010B08 File Offset: 0x0000ED08
		// (set) Token: 0x060003E3 RID: 995 RVA: 0x00010B10 File Offset: 0x0000ED10
		public bool middleDown { readonly get; set; }

		// Token: 0x060003E4 RID: 996 RVA: 0x00010B1C File Offset: 0x0000ED1C
		public string String()
		{
			return string.Format("Mouse: {0}x{1}  Btns: Left:{2} Right:{3} Middle:{4} ", new object[]
			{
				this.pos.x,
				this.pos.y,
				this.leftDown,
				this.rightDown,
				this.middleDown
			});
		}
	}
}
