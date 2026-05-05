using System;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x0200003E RID: 62
	[ExecuteAlways]
	[RequireComponent(typeof(VFXPropertyBinder))]
	public abstract class VFXBinderBase : MonoBehaviour
	{
		// Token: 0x0600018B RID: 395
		public abstract bool IsValid(VisualEffect component);

		// Token: 0x0600018C RID: 396 RVA: 0x00008F3E File Offset: 0x0000713E
		public virtual void Reset()
		{
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00008F40 File Offset: 0x00007140
		protected virtual void Awake()
		{
			this.binder = base.GetComponent<VFXPropertyBinder>();
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00008F4E File Offset: 0x0000714E
		protected virtual void OnEnable()
		{
			if (!this.binder.m_Bindings.Contains(this))
			{
				this.binder.m_Bindings.Add(this);
			}
			base.hideFlags = HideFlags.HideInInspector;
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00008F7B File Offset: 0x0000717B
		protected virtual void OnDisable()
		{
			if (this.binder.m_Bindings.Contains(this))
			{
				this.binder.m_Bindings.Remove(this);
			}
		}

		// Token: 0x06000190 RID: 400
		public abstract void UpdateBinding(VisualEffect component);

		// Token: 0x06000191 RID: 401 RVA: 0x00008FA2 File Offset: 0x000071A2
		public override string ToString()
		{
			return base.GetType().ToString();
		}

		// Token: 0x04000110 RID: 272
		protected VFXPropertyBinder binder;
	}
}
