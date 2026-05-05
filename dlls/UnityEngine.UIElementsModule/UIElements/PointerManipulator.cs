using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200029F RID: 671
	public abstract class PointerManipulator : MouseManipulator
	{
		// Token: 0x0600133E RID: 4926 RVA: 0x00043218 File Offset: 0x00041418
		protected bool CanStartManipulation(IPointerEvent e)
		{
			foreach (ManipulatorActivationFilter manipulatorActivationFilter in base.activators)
			{
				bool flag = manipulatorActivationFilter.Matches(e);
				if (flag)
				{
					this.m_CurrentPointerId = e.pointerId;
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600133F RID: 4927 RVA: 0x0004328C File Offset: 0x0004148C
		protected bool CanStopManipulation(IPointerEvent e)
		{
			bool flag = e == null;
			return !flag && e.pointerId == this.m_CurrentPointerId;
		}

		// Token: 0x040008B8 RID: 2232
		private int m_CurrentPointerId;
	}
}
