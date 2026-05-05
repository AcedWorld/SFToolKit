using System;

namespace Unity.VisualScripting.Dependencies.NCalc
{
	// Token: 0x02000192 RID: 402
	public class ParameterArgs : EventArgs
	{
		// Token: 0x170003AA RID: 938
		// (get) Token: 0x06000B32 RID: 2866 RVA: 0x000199E3 File Offset: 0x00017BE3
		// (set) Token: 0x06000B33 RID: 2867 RVA: 0x000199EB File Offset: 0x00017BEB
		public object Result
		{
			get
			{
				return this._result;
			}
			set
			{
				this._result = value;
				this.HasResult = true;
			}
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x06000B34 RID: 2868 RVA: 0x000199FB File Offset: 0x00017BFB
		// (set) Token: 0x06000B35 RID: 2869 RVA: 0x00019A03 File Offset: 0x00017C03
		public bool HasResult { get; set; }

		// Token: 0x04000324 RID: 804
		private object _result;
	}
}
