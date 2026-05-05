using System;

namespace Unity.VisualScripting.Dependencies.NCalc
{
	// Token: 0x0200018B RID: 395
	public class FunctionArgs : EventArgs
	{
		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06000A9F RID: 2719 RVA: 0x00014514 File Offset: 0x00012714
		// (set) Token: 0x06000AA0 RID: 2720 RVA: 0x0001451C File Offset: 0x0001271C
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

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06000AA1 RID: 2721 RVA: 0x0001452C File Offset: 0x0001272C
		// (set) Token: 0x06000AA2 RID: 2722 RVA: 0x00014534 File Offset: 0x00012734
		public bool HasResult { get; set; }

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06000AA3 RID: 2723 RVA: 0x0001453D File Offset: 0x0001273D
		// (set) Token: 0x06000AA4 RID: 2724 RVA: 0x00014545 File Offset: 0x00012745
		public Expression[] Parameters
		{
			get
			{
				return this._parameters;
			}
			set
			{
				this._parameters = value;
			}
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x00014550 File Offset: 0x00012750
		public object[] EvaluateParameters(Flow flow)
		{
			object[] array = new object[this._parameters.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = this._parameters[i].Evaluate(flow);
			}
			return array;
		}

		// Token: 0x04000256 RID: 598
		private object _result;

		// Token: 0x04000257 RID: 599
		private Expression[] _parameters = new Expression[0];
	}
}
