using System;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000025 RID: 37
	internal abstract class VFXEventBinderBase : MonoBehaviour
	{
		// Token: 0x060000C3 RID: 195 RVA: 0x00006BC9 File Offset: 0x00004DC9
		protected virtual void OnEnable()
		{
			this.UpdateCacheEventAttribute();
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00006BD1 File Offset: 0x00004DD1
		private void OnValidate()
		{
			this.UpdateCacheEventAttribute();
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00006BD9 File Offset: 0x00004DD9
		private void UpdateCacheEventAttribute()
		{
			if (this.target != null)
			{
				this.eventAttribute = this.target.CreateVFXEventAttribute();
				return;
			}
			this.eventAttribute = null;
		}

		// Token: 0x060000C6 RID: 198
		protected abstract void SetEventAttribute(object[] parameters = null);

		// Token: 0x060000C7 RID: 199 RVA: 0x00006C02 File Offset: 0x00004E02
		protected void SendEventToVisualEffect(params object[] parameters)
		{
			if (this.target != null)
			{
				this.SetEventAttribute(parameters);
				this.target.SendEvent(this.EventName, this.eventAttribute);
			}
		}

		// Token: 0x04000090 RID: 144
		[SerializeField]
		protected VisualEffect target;

		// Token: 0x04000091 RID: 145
		public string EventName = "Event";

		// Token: 0x04000092 RID: 146
		[SerializeField]
		[HideInInspector]
		protected VFXEventAttribute eventAttribute;
	}
}
