using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000403 RID: 1027
	internal class VisualElementFocusChangeTarget : FocusChangeDirection
	{
		// Token: 0x060020E3 RID: 8419 RVA: 0x0007C4DC File Offset: 0x0007A6DC
		public static VisualElementFocusChangeTarget GetPooled(Focusable target)
		{
			VisualElementFocusChangeTarget visualElementFocusChangeTarget = VisualElementFocusChangeTarget.Pool.Get();
			visualElementFocusChangeTarget.target = target;
			return visualElementFocusChangeTarget;
		}

		// Token: 0x060020E4 RID: 8420 RVA: 0x0007C502 File Offset: 0x0007A702
		protected override void Dispose()
		{
			this.target = null;
			VisualElementFocusChangeTarget.Pool.Release(this);
		}

		// Token: 0x060020E5 RID: 8421 RVA: 0x0007C519 File Offset: 0x0007A719
		internal override void ApplyTo(FocusController focusController, Focusable f)
		{
			focusController.selectedTextElement = null;
			f.Focus();
		}

		// Token: 0x060020E6 RID: 8422 RVA: 0x0007C52B File Offset: 0x0007A72B
		public VisualElementFocusChangeTarget() : base(FocusChangeDirection.unspecified)
		{
		}

		// Token: 0x170007A4 RID: 1956
		// (get) Token: 0x060020E7 RID: 8423 RVA: 0x0007C53F File Offset: 0x0007A73F
		// (set) Token: 0x060020E8 RID: 8424 RVA: 0x0007C547 File Offset: 0x0007A747
		public Focusable target { get; private set; }

		// Token: 0x04000DE9 RID: 3561
		private static readonly ObjectPool<VisualElementFocusChangeTarget> Pool = new ObjectPool<VisualElementFocusChangeTarget>(() => new VisualElementFocusChangeTarget(), 100);
	}
}
