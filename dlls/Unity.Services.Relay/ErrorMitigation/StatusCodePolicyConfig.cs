using System;
using System.Collections.Generic;

namespace Unity.Services.Relay.ErrorMitigation
{
	// Token: 0x0200004A RID: 74
	internal class StatusCodePolicyConfig
	{
		// Token: 0x0600015A RID: 346 RVA: 0x00005063 File Offset: 0x00003263
		public void HandleStatusCode(long code)
		{
			if (this._statusCodesToHandleDict.ContainsKey(code))
			{
				this._statusCodesToHandleDict[code] = true;
				return;
			}
			this._statusCodesToHandleDict.Add(new KeyValuePair<long, bool>(code, true));
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00005093 File Offset: 0x00003293
		public void DontHandleStatusCode(long code)
		{
			if (this._statusCodesToHandleDict.ContainsKey(code))
			{
				this._statusCodesToHandleDict[code] = false;
				return;
			}
			this._statusCodesToHandleDict.Add(new KeyValuePair<long, bool>(code, false));
		}

		// Token: 0x0600015C RID: 348 RVA: 0x000050C3 File Offset: 0x000032C3
		public void Clear()
		{
			this._statusCodesToHandleDict.Clear();
		}

		// Token: 0x0600015D RID: 349 RVA: 0x000050D0 File Offset: 0x000032D0
		public bool IsHandledStatusCode(long code)
		{
			return this._statusCodesToHandleDict.Contains(new KeyValuePair<long, bool>(code, true));
		}

		// Token: 0x040000A7 RID: 167
		private IDictionary<long, bool> _statusCodesToHandleDict = new Dictionary<long, bool>
		{
			{
				408L,
				true
			},
			{
				429L,
				true
			},
			{
				502L,
				true
			},
			{
				503L,
				true
			},
			{
				504L,
				true
			}
		};
	}
}
