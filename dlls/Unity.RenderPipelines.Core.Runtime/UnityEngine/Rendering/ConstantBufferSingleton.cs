using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200003A RID: 58
	internal class ConstantBufferSingleton<CBType> : ConstantBuffer<CBType> where CBType : struct
	{
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600021F RID: 543 RVA: 0x0000A6B8 File Offset: 0x000088B8
		// (set) Token: 0x06000220 RID: 544 RVA: 0x0000A6DA File Offset: 0x000088DA
		internal static ConstantBufferSingleton<CBType> instance
		{
			get
			{
				if (ConstantBufferSingleton<CBType>.s_Instance == null)
				{
					ConstantBufferSingleton<CBType>.s_Instance = new ConstantBufferSingleton<CBType>();
					ConstantBuffer.Register(ConstantBufferSingleton<CBType>.s_Instance);
				}
				return ConstantBufferSingleton<CBType>.s_Instance;
			}
			set
			{
				ConstantBufferSingleton<CBType>.s_Instance = value;
			}
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000A6E2 File Offset: 0x000088E2
		public override void Release()
		{
			base.Release();
			ConstantBufferSingleton<CBType>.s_Instance = null;
		}

		// Token: 0x04000145 RID: 325
		private static ConstantBufferSingleton<CBType> s_Instance;
	}
}
