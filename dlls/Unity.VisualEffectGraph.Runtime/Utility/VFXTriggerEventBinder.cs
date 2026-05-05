using System;
using System.Collections.Generic;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000023 RID: 35
	[RequireComponent(typeof(Collider))]
	internal class VFXTriggerEventBinder : VFXEventBinderBase
	{
		// Token: 0x060000BA RID: 186 RVA: 0x00006AB8 File Offset: 0x00004CB8
		protected override void SetEventAttribute(object[] parameters)
		{
			Collider collider = (Collider)parameters[0];
			this.eventAttribute.SetVector3(this.positionParameter, collider.transform.position);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00006AEF File Offset: 0x00004CEF
		private void OnTriggerEnter(Collider other)
		{
			if (this.activation != VFXTriggerEventBinder.Activation.OnEnter)
			{
				return;
			}
			if (!this.colliders.Contains(other))
			{
				return;
			}
			base.SendEventToVisualEffect(new object[]
			{
				other
			});
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00006B19 File Offset: 0x00004D19
		private void OnTriggerExit(Collider other)
		{
			if (this.activation != VFXTriggerEventBinder.Activation.OnExit)
			{
				return;
			}
			if (!this.colliders.Contains(other))
			{
				return;
			}
			base.SendEventToVisualEffect(new object[]
			{
				other
			});
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00006B44 File Offset: 0x00004D44
		private void OnTriggerStay(Collider other)
		{
			if (this.activation != VFXTriggerEventBinder.Activation.OnStay)
			{
				return;
			}
			if (!this.colliders.Contains(other))
			{
				return;
			}
			base.SendEventToVisualEffect(new object[]
			{
				other
			});
		}

		// Token: 0x0400008C RID: 140
		public List<Collider> colliders = new List<Collider>();

		// Token: 0x0400008D RID: 141
		public VFXTriggerEventBinder.Activation activation;

		// Token: 0x0400008E RID: 142
		private ExposedProperty positionParameter = "position";

		// Token: 0x02000061 RID: 97
		public enum Activation
		{
			// Token: 0x040001DC RID: 476
			OnEnter,
			// Token: 0x040001DD RID: 477
			OnExit,
			// Token: 0x040001DE RID: 478
			OnStay
		}
	}
}
