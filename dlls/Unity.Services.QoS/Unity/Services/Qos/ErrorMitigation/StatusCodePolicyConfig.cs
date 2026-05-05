using System;
using System.Collections.Generic;

namespace Unity.Services.Qos.ErrorMitigation
{
	// Token: 0x02000074 RID: 116
	internal class StatusCodePolicyConfig
	{
		// Token: 0x06000238 RID: 568 RVA: 0x00007FC3 File Offset: 0x000061C3
		public void HandleStatusCode(long code)
		{
			if (this._statusCodesToHandleDict.ContainsKey(code))
			{
				this._statusCodesToHandleDict[code] = true;
				return;
			}
			this._statusCodesToHandleDict.Add(new KeyValuePair<long, bool>(code, true));
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00007FF3 File Offset: 0x000061F3
		public void DontHandleStatusCode(long code)
		{
			if (this._statusCodesToHandleDict.ContainsKey(code))
			{
				this._statusCodesToHandleDict[code] = false;
				return;
			}
			this._statusCodesToHandleDict.Add(new KeyValuePair<long, bool>(code, false));
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00008023 File Offset: 0x00006223
		public void Clear()
		{
			this._statusCodesToHandleDict.Clear();
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00008030 File Offset: 0x00006230
		public bool IsHandledStatusCode(long code)
		{
			return this._statusCodesToHandleDict.Contains(new KeyValuePair<long, bool>(code, true));
		}

		// Token: 0x040000E7 RID: 231
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
