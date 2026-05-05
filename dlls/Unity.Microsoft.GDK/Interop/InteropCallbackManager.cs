using System;
using System.Collections.Generic;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001C3 RID: 451
	public class InteropCallbackManager<TDelegate> where TDelegate : class
	{
		// Token: 0x06000A8B RID: 2699 RVA: 0x0000FD84 File Offset: 0x0000DF84
		internal IntPtr GetUniqueContext()
		{
			int availableContextId = this._availableContextId;
			this._availableContextId = availableContextId + 1;
			return new IntPtr(availableContextId);
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x0000FDA8 File Offset: 0x0000DFA8
		internal void AddCallbackForId(int functionId, IntPtr context, TDelegate callback)
		{
			this._contextToFunctionId[context] = functionId;
			this._functionIdToHandler[functionId] = new InteropCallbackManager<TDelegate>.HandlerContext
			{
				Context = context,
				Callback = callback
			};
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x0000FDE8 File Offset: 0x0000DFE8
		internal void RemoveCallbackForId(int functionId)
		{
			if (!this._functionIdToHandler.ContainsKey(functionId))
			{
				return;
			}
			InteropCallbackManager<TDelegate>.HandlerContext handlerContext = this._functionIdToHandler[functionId];
			this._contextToFunctionId.Remove(handlerContext.Context);
			this._functionIdToHandler.Remove(functionId);
		}

		// Token: 0x040005E9 RID: 1513
		protected readonly Dictionary<IntPtr, int> _contextToFunctionId = new Dictionary<IntPtr, int>();

		// Token: 0x040005EA RID: 1514
		protected readonly Dictionary<int, InteropCallbackManager<TDelegate>.HandlerContext> _functionIdToHandler = new Dictionary<int, InteropCallbackManager<TDelegate>.HandlerContext>();

		// Token: 0x040005EB RID: 1515
		private int _availableContextId = 1000;

		// Token: 0x02000326 RID: 806
		protected struct HandlerContext
		{
			// Token: 0x0400099B RID: 2459
			public IntPtr Context;

			// Token: 0x0400099C RID: 2460
			public TDelegate Callback;
		}
	}
}
