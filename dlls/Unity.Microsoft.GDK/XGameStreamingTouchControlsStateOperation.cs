using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000137 RID: 311
	public class XGameStreamingTouchControlsStateOperation
	{
		// Token: 0x060007A8 RID: 1960 RVA: 0x0000D279 File Offset: 0x0000B479
		internal XGameStreamingTouchControlsStateOperation(XGameStreamingTouchControlsStateOperation interop)
		{
			this._interop = interop;
			this._value = new XGameStreamingTouchControlsStateValue(interop.value);
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x0000D299 File Offset: 0x0000B499
		public XGameStreamingTouchControlsStateOperation()
		{
			this._interop = default(XGameStreamingTouchControlsStateOperation);
			this._value = new XGameStreamingTouchControlsStateValue();
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x060007AA RID: 1962 RVA: 0x0000D2B8 File Offset: 0x0000B4B8
		internal XGameStreamingTouchControlsStateOperation interop
		{
			get
			{
				this._interop.value = this._value.interop;
				return this._interop;
			}
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x060007AB RID: 1963 RVA: 0x0000D2D6 File Offset: 0x0000B4D6
		// (set) Token: 0x060007AC RID: 1964 RVA: 0x0000D2E3 File Offset: 0x0000B4E3
		public XGameStreamingTouchControlsStateOperationKind OperationKind
		{
			get
			{
				return this._interop.operationKind;
			}
			set
			{
				this._interop.operationKind = value;
			}
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x060007AD RID: 1965 RVA: 0x0000D2F1 File Offset: 0x0000B4F1
		// (set) Token: 0x060007AE RID: 1966 RVA: 0x0000D2FE File Offset: 0x0000B4FE
		public string Path
		{
			get
			{
				return this._interop.path;
			}
			set
			{
				this._interop.path = value;
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x060007AF RID: 1967 RVA: 0x0000D30C File Offset: 0x0000B50C
		// (set) Token: 0x060007B0 RID: 1968 RVA: 0x0000D314 File Offset: 0x0000B514
		public XGameStreamingTouchControlsStateValue Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
			}
		}

		// Token: 0x040004AA RID: 1194
		internal XGameStreamingTouchControlsStateOperation _interop;

		// Token: 0x040004AB RID: 1195
		internal XGameStreamingTouchControlsStateValue _value;
	}
}
