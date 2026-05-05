using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000190 RID: 400
	public abstract class MouseCaptureEventBase<T> : PointerCaptureEventBase<T>, IMouseCaptureEvent where T : MouseCaptureEventBase<T>, new()
	{
		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06000C6F RID: 3183 RVA: 0x00031AA3 File Offset: 0x0002FCA3
		public new IEventHandler relatedTarget
		{
			get
			{
				return base.relatedTarget;
			}
		}

		// Token: 0x06000C70 RID: 3184 RVA: 0x00031AAC File Offset: 0x0002FCAC
		public static T GetPooled(IEventHandler target, IEventHandler relatedTarget)
		{
			return PointerCaptureEventBase<T>.GetPooled(target, relatedTarget, 0);
		}

		// Token: 0x06000C71 RID: 3185 RVA: 0x00031AC8 File Offset: 0x0002FCC8
		protected override void Init()
		{
			base.Init();
		}
	}
}
