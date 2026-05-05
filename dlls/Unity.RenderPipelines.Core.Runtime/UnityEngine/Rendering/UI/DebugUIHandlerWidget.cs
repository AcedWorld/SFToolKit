using System;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x0200013E RID: 318
	public class DebugUIHandlerWidget : MonoBehaviour
	{
		// Token: 0x17000146 RID: 326
		// (get) Token: 0x0600098F RID: 2447 RVA: 0x0002B69C File Offset: 0x0002989C
		// (set) Token: 0x06000990 RID: 2448 RVA: 0x0002B6A4 File Offset: 0x000298A4
		public DebugUIHandlerWidget parentUIHandler { get; set; }

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000991 RID: 2449 RVA: 0x0002B6AD File Offset: 0x000298AD
		// (set) Token: 0x06000992 RID: 2450 RVA: 0x0002B6B5 File Offset: 0x000298B5
		public DebugUIHandlerWidget previousUIHandler { get; set; }

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000993 RID: 2451 RVA: 0x0002B6BE File Offset: 0x000298BE
		// (set) Token: 0x06000994 RID: 2452 RVA: 0x0002B6C6 File Offset: 0x000298C6
		public DebugUIHandlerWidget nextUIHandler { get; set; }

		// Token: 0x06000995 RID: 2453 RVA: 0x0002B6CF File Offset: 0x000298CF
		protected virtual void OnEnable()
		{
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x0002B6D1 File Offset: 0x000298D1
		internal virtual void SetWidget(DebugUI.Widget widget)
		{
			this.m_Widget = widget;
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0002B6DA File Offset: 0x000298DA
		internal DebugUI.Widget GetWidget()
		{
			return this.m_Widget;
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x0002B6E4 File Offset: 0x000298E4
		protected T CastWidget<T>() where T : DebugUI.Widget
		{
			T t = this.m_Widget as T;
			string text = (this.m_Widget == null) ? "null" : this.m_Widget.GetType().ToString();
			if (t == null)
			{
				string str = "Can't cast ";
				string str2 = text;
				string str3 = " to ";
				Type typeFromHandle = typeof(T);
				throw new InvalidOperationException(str + str2 + str3 + ((typeFromHandle != null) ? typeFromHandle.ToString() : null));
			}
			return t;
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x0002B755 File Offset: 0x00029955
		public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous)
		{
			return true;
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0002B758 File Offset: 0x00029958
		public virtual void OnDeselection()
		{
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0002B75A File Offset: 0x0002995A
		public virtual void OnAction()
		{
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x0002B75C File Offset: 0x0002995C
		public virtual void OnIncrement(bool fast)
		{
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x0002B75E File Offset: 0x0002995E
		public virtual void OnDecrement(bool fast)
		{
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x0002B760 File Offset: 0x00029960
		public virtual DebugUIHandlerWidget Previous()
		{
			if (this.previousUIHandler != null)
			{
				return this.previousUIHandler;
			}
			if (this.parentUIHandler != null)
			{
				return this.parentUIHandler;
			}
			return null;
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x0002B790 File Offset: 0x00029990
		public virtual DebugUIHandlerWidget Next()
		{
			if (this.nextUIHandler != null)
			{
				return this.nextUIHandler;
			}
			if (this.parentUIHandler != null)
			{
				DebugUIHandlerWidget parentUIHandler = this.parentUIHandler;
				while (parentUIHandler != null)
				{
					DebugUIHandlerWidget nextUIHandler = parentUIHandler.nextUIHandler;
					if (nextUIHandler != null)
					{
						return nextUIHandler;
					}
					parentUIHandler = parentUIHandler.parentUIHandler;
				}
			}
			return null;
		}

		// Token: 0x0400058F RID: 1423
		[HideInInspector]
		public Color colorDefault = new Color(0.8f, 0.8f, 0.8f, 1f);

		// Token: 0x04000590 RID: 1424
		[HideInInspector]
		public Color colorSelected = new Color(0.25f, 0.65f, 0.8f, 1f);

		// Token: 0x04000594 RID: 1428
		protected DebugUI.Widget m_Widget;
	}
}
