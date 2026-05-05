using System;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	// Token: 0x0200039F RID: 927
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public abstract class CustomControllerExtension : Controller.Extension
	{
		// Token: 0x06002586 RID: 9606 RVA: 0x0001B762 File Offset: 0x00019962
		public CustomControllerExtension(IControllerExtensionSource A_1) : base(A_1)
		{
		}

		// Token: 0x06002587 RID: 9607 RVA: 0x0001B76B File Offset: 0x0001996B
		protected CustomControllerExtension(CustomControllerExtension A_1) : base(A_1)
		{
		}

		// Token: 0x06002588 RID: 9608 RVA: 0x00002FF9 File Offset: 0x000011F9
		protected virtual void OnUpdateData(UpdateLoopType updateLoop)
		{
		}

		// Token: 0x06002589 RID: 9609 RVA: 0x00002FF9 File Offset: 0x000011F9
		protected virtual void OnSourceUpdated(IControllerExtensionSource source)
		{
		}

		// Token: 0x0600258A RID: 9610 RVA: 0x0001B774 File Offset: 0x00019974
		protected new IControllerExtensionSource GetSource()
		{
			return base.GetSource();
		}

		// Token: 0x0600258B RID: 9611
		public abstract Controller.Extension ShallowCopy();

		// Token: 0x0600258C RID: 9612 RVA: 0x0001B77C File Offset: 0x0001997C
		internal override Controller.Extension Clone()
		{
			return this.ShallowCopy();
		}

		// Token: 0x0600258D RID: 9613 RVA: 0x0001B784 File Offset: 0x00019984
		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (!this.RsLKUAvfmMyCvpogPdqbifzqwZVb || !base.enabled)
			{
				return;
			}
			this.OnUpdateData(updateLoop);
		}

		// Token: 0x0600258E RID: 9614 RVA: 0x0001B79E File Offset: 0x0001999E
		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			this.RsLKUAvfmMyCvpogPdqbifzqwZVb = (source != null);
			this.OnSourceUpdated(source);
		}

		// Token: 0x0400157C RID: 5500
		private bool RsLKUAvfmMyCvpogPdqbifzqwZVb;
	}
}
