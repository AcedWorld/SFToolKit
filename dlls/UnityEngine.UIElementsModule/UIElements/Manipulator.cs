using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000275 RID: 629
	public abstract class Manipulator : IManipulator
	{
		// Token: 0x060011D5 RID: 4565
		protected abstract void RegisterCallbacksOnTarget();

		// Token: 0x060011D6 RID: 4566
		protected abstract void UnregisterCallbacksFromTarget();

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x060011D7 RID: 4567 RVA: 0x00040B38 File Offset: 0x0003ED38
		// (set) Token: 0x060011D8 RID: 4568 RVA: 0x00040B50 File Offset: 0x0003ED50
		public VisualElement target
		{
			get
			{
				return this.m_Target;
			}
			set
			{
				bool flag = this.target != null;
				if (flag)
				{
					this.UnregisterCallbacksFromTarget();
				}
				this.m_Target = value;
				bool flag2 = this.target != null;
				if (flag2)
				{
					this.RegisterCallbacksOnTarget();
				}
			}
		}

		// Token: 0x040007E4 RID: 2020
		private VisualElement m_Target;
	}
}
