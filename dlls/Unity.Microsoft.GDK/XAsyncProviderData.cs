using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200005F RID: 95
	public class XAsyncProviderData
	{
		// Token: 0x060003E5 RID: 997 RVA: 0x0000948E File Offset: 0x0000768E
		internal XAsyncProviderData(XAsyncProviderData interop, XAsyncBlock block)
		{
			this._async = block;
			this.interop = interop;
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x000094A4 File Offset: 0x000076A4
		// (set) Token: 0x060003E7 RID: 999 RVA: 0x000094AC File Offset: 0x000076AC
		public XAsyncBlock Async
		{
			get
			{
				return this._async;
			}
			set
			{
				this._async = value;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060003E8 RID: 1000 RVA: 0x000094B5 File Offset: 0x000076B5
		// (set) Token: 0x060003E9 RID: 1001 RVA: 0x000094C2 File Offset: 0x000076C2
		public ulong BufferSize
		{
			get
			{
				return this.interop.bufferSize;
			}
			set
			{
				this.interop.bufferSize = value;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x000094D0 File Offset: 0x000076D0
		// (set) Token: 0x060003EB RID: 1003 RVA: 0x000094DD File Offset: 0x000076DD
		public IntPtr Buffer
		{
			get
			{
				return this.interop.buffer;
			}
			set
			{
				this.interop.buffer = value;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x000094EB File Offset: 0x000076EB
		// (set) Token: 0x060003ED RID: 1005 RVA: 0x000094F8 File Offset: 0x000076F8
		public IntPtr Context
		{
			get
			{
				return this.interop.context;
			}
			set
			{
				this.interop.context = value;
			}
		}

		// Token: 0x040000CE RID: 206
		internal XAsyncProviderData interop;

		// Token: 0x040000CF RID: 207
		internal XAsyncBlock _async;
	}
}
