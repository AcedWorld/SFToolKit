using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000278 RID: 632
	public abstract class MouseManipulator : Manipulator
	{
		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x060011DF RID: 4575 RVA: 0x00040C91 File Offset: 0x0003EE91
		// (set) Token: 0x060011E0 RID: 4576 RVA: 0x00040C99 File Offset: 0x0003EE99
		public List<ManipulatorActivationFilter> activators { get; private set; }

		// Token: 0x060011E1 RID: 4577 RVA: 0x00040CA2 File Offset: 0x0003EEA2
		protected MouseManipulator()
		{
			this.activators = new List<ManipulatorActivationFilter>();
		}

		// Token: 0x060011E2 RID: 4578 RVA: 0x00040CB8 File Offset: 0x0003EEB8
		protected bool CanStartManipulation(IMouseEvent e)
		{
			foreach (ManipulatorActivationFilter currentActivator in this.activators)
			{
				bool flag = currentActivator.Matches(e);
				if (flag)
				{
					this.m_currentActivator = currentActivator;
					return true;
				}
			}
			return false;
		}

		// Token: 0x060011E3 RID: 4579 RVA: 0x00040D28 File Offset: 0x0003EF28
		protected bool CanStopManipulation(IMouseEvent e)
		{
			bool flag = e == null;
			return !flag && e.button == (int)this.m_currentActivator.button;
		}

		// Token: 0x040007EC RID: 2028
		private ManipulatorActivationFilter m_currentActivator;
	}
}
