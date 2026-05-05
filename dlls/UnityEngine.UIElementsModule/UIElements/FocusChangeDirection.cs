using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000246 RID: 582
	public class FocusChangeDirection : IDisposable
	{
		// Token: 0x17000379 RID: 889
		// (get) Token: 0x0600108D RID: 4237 RVA: 0x0003BDE3 File Offset: 0x00039FE3
		public static FocusChangeDirection unspecified { get; } = new FocusChangeDirection(-1);

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x0600108E RID: 4238 RVA: 0x0003BDEA File Offset: 0x00039FEA
		public static FocusChangeDirection none { get; } = new FocusChangeDirection(0);

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x0600108F RID: 4239 RVA: 0x0003BDF1 File Offset: 0x00039FF1
		protected static FocusChangeDirection lastValue { get; } = FocusChangeDirection.none;

		// Token: 0x06001090 RID: 4240 RVA: 0x0003BDF8 File Offset: 0x00039FF8
		protected FocusChangeDirection(int value)
		{
			this.m_Value = value;
		}

		// Token: 0x06001091 RID: 4241 RVA: 0x0003BE0C File Offset: 0x0003A00C
		public static implicit operator int(FocusChangeDirection fcd)
		{
			return (fcd != null) ? fcd.m_Value : 0;
		}

		// Token: 0x06001092 RID: 4242 RVA: 0x0003BE2A File Offset: 0x0003A02A
		void IDisposable.Dispose()
		{
			this.Dispose();
		}

		// Token: 0x06001093 RID: 4243 RVA: 0x00003CD2 File Offset: 0x00001ED2
		protected virtual void Dispose()
		{
		}

		// Token: 0x06001094 RID: 4244 RVA: 0x0003BE33 File Offset: 0x0003A033
		internal virtual void ApplyTo(FocusController focusController, Focusable f)
		{
			focusController.SwitchFocus(f, this, false, DispatchMode.Default);
		}

		// Token: 0x04000747 RID: 1863
		private readonly int m_Value;
	}
}
