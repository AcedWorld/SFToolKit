using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000135 RID: 309
	public class D3D12XBOX_FRAME_PIPELINE_TOKEN
	{
		// Token: 0x06000798 RID: 1944 RVA: 0x0000D18F File Offset: 0x0000B38F
		public D3D12XBOX_FRAME_PIPELINE_TOKEN(ulong value)
		{
			this.data = default(D3D12XBOX_FRAME_PIPELINE_TOKEN);
			this.data.value = value;
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x0000D1AF File Offset: 0x0000B3AF
		internal D3D12XBOX_FRAME_PIPELINE_TOKEN(D3D12XBOX_FRAME_PIPELINE_TOKEN interop)
		{
			this.data = interop;
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x0600079A RID: 1946 RVA: 0x0000D1BE File Offset: 0x0000B3BE
		// (set) Token: 0x0600079B RID: 1947 RVA: 0x0000D1CB File Offset: 0x0000B3CB
		public ulong Value
		{
			get
			{
				return this.data.value;
			}
			set
			{
				this.data.value = value;
			}
		}

		// Token: 0x040004A7 RID: 1191
		internal D3D12XBOX_FRAME_PIPELINE_TOKEN data;
	}
}
