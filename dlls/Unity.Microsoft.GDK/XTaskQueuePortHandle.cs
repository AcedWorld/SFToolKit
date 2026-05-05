using System;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200019C RID: 412
	public class XTaskQueuePortHandle : EquatableHandle
	{
		// Token: 0x060009EB RID: 2539 RVA: 0x0000F22A File Offset: 0x0000D42A
		public XTaskQueuePortHandle(IntPtr handle) : base(IntPtr.Zero, true, handle)
		{
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x0000F239 File Offset: 0x0000D439
		protected override bool ReleaseHandle()
		{
			base.SetHandle(IntPtr.Zero);
			return true;
		}

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x060009ED RID: 2541 RVA: 0x0000F247 File Offset: 0x0000D447
		public override bool IsInvalid
		{
			get
			{
				return base.Handle == IntPtr.Zero;
			}
		}
	}
}
