using System;
using System.Collections.Generic;

namespace Unity.Services.Qos.V2.ErrorMitigation
{
	// Token: 0x02000044 RID: 68
	internal class StatusCodePolicyConfig
	{
		// Token: 0x06000140 RID: 320 RVA: 0x000059F7 File Offset: 0x00003BF7
		public void HandleStatusCode(long code)
		{
			if (this._statusCodesToHandleDict.ContainsKey(code))
			{
				this._statusCodesToHandleDict[code] = true;
				return;
			}
			this._statusCodesToHandleDict.Add(new KeyValuePair<long, bool>(code, true));
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00005A27 File Offset: 0x00003C27
		public void DontHandleStatusCode(long code)
		{
			if (this._statusCodesToHandleDict.ContainsKey(code))
			{
				this._statusCodesToHandleDict[code] = false;
				return;
			}
			this._statusCodesToHandleDict.Add(new KeyValuePair<long, bool>(code, false));
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00005A57 File Offset: 0x00003C57
		public void Clear()
		{
			this._statusCodesToHandleDict.Clear();
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00005A64 File Offset: 0x00003C64
		public bool IsHandledStatusCode(long code)
		{
			return this._statusCodesToHandleDict.Contains(new KeyValuePair<long, bool>(code, true));
		}

		// Token: 0x040000A3 RID: 163
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
