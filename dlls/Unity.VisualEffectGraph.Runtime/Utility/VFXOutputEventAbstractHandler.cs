using System;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000026 RID: 38
	[ExecuteAlways]
	[RequireComponent(typeof(VisualEffect))]
	public abstract class VFXOutputEventAbstractHandler : MonoBehaviour
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000C9 RID: 201
		public abstract bool canExecuteInEditor { get; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00006C4C File Offset: 0x00004E4C
		// (set) Token: 0x060000CA RID: 202 RVA: 0x00006C43 File Offset: 0x00004E43
		private protected VisualEffect m_VisualEffect { protected get; private set; }

		// Token: 0x060000CC RID: 204 RVA: 0x00006C54 File Offset: 0x00004E54
		protected virtual void OnEnable()
		{
			this.m_VisualEffect = base.GetComponent<VisualEffect>();
			if (this.m_VisualEffect != null)
			{
				VisualEffect visualEffect = this.m_VisualEffect;
				visualEffect.outputEventReceived = (Action<VFXOutputEventArgs>)Delegate.Combine(visualEffect.outputEventReceived, new Action<VFXOutputEventArgs>(this.OnOutputEventRecieved));
			}
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00006CA2 File Offset: 0x00004EA2
		protected virtual void OnDisable()
		{
			if (this.m_VisualEffect != null)
			{
				VisualEffect visualEffect = this.m_VisualEffect;
				visualEffect.outputEventReceived = (Action<VFXOutputEventArgs>)Delegate.Remove(visualEffect.outputEventReceived, new Action<VFXOutputEventArgs>(this.OnOutputEventRecieved));
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00006CD9 File Offset: 0x00004ED9
		private void OnOutputEventRecieved(VFXOutputEventArgs args)
		{
			if ((Application.isPlaying || (this.executeInEditor && this.canExecuteInEditor)) && args.nameId == this.outputEvent)
			{
				this.OnVFXOutputEvent(args.eventAttribute);
			}
		}

		// Token: 0x060000CF RID: 207
		public abstract void OnVFXOutputEvent(VFXEventAttribute eventAttribute);

		// Token: 0x04000093 RID: 147
		public bool executeInEditor = true;

		// Token: 0x04000094 RID: 148
		public ExposedProperty outputEvent = "On Received Event";
	}
}
