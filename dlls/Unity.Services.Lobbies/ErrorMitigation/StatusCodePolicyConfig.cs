using System;
using System.Collections.Generic;

namespace Unity.Services.Lobbies.ErrorMitigation
{
	// Token: 0x02000064 RID: 100
	internal class StatusCodePolicyConfig
	{
		// Token: 0x060002A5 RID: 677 RVA: 0x000096FF File Offset: 0x000078FF
		public void HandleStatusCode(long code)
		{
			if (this._statusCodesToHandleDict.ContainsKey(code))
			{
				this._statusCodesToHandleDict[code] = true;
				return;
			}
			this._statusCodesToHandleDict.Add(new KeyValuePair<long, bool>(code, true));
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000972F File Offset: 0x0000792F
		public void DontHandleStatusCode(long code)
		{
			if (this._statusCodesToHandleDict.ContainsKey(code))
			{
				this._statusCodesToHandleDict[code] = false;
				return;
			}
			this._statusCodesToHandleDict.Add(new KeyValuePair<long, bool>(code, false));
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000975F File Offset: 0x0000795F
		public void Clear()
		{
			this._statusCodesToHandleDict.Clear();
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000976C File Offset: 0x0000796C
		public bool IsHandledStatusCode(long code)
		{
			return this._statusCodesToHandleDict.Contains(new KeyValuePair<long, bool>(code, true));
		}

		// Token: 0x04000132 RID: 306
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
