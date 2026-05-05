using System;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000024 RID: 36
	[RequireComponent(typeof(Renderer))]
	internal class VFXVisibilityEventBinder : VFXEventBinderBase
	{
		// Token: 0x060000BF RID: 191 RVA: 0x00006B92 File Offset: 0x00004D92
		protected override void SetEventAttribute(object[] parameters)
		{
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00006B94 File Offset: 0x00004D94
		private void OnBecameVisible()
		{
			if (this.activation != VFXVisibilityEventBinder.Activation.OnBecameVisible)
			{
				return;
			}
			base.SendEventToVisualEffect(Array.Empty<object>());
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00006BAA File Offset: 0x00004DAA
		private void OnBecameInvisible()
		{
			if (this.activation != VFXVisibilityEventBinder.Activation.OnBecameInvisible)
			{
				return;
			}
			base.SendEventToVisualEffect(Array.Empty<object>());
		}

		// Token: 0x0400008F RID: 143
		public VFXVisibilityEventBinder.Activation activation;

		// Token: 0x02000062 RID: 98
		public enum Activation
		{
			// Token: 0x040001E0 RID: 480
			OnBecameVisible,
			// Token: 0x040001E1 RID: 481
			OnBecameInvisible
		}
	}
}
