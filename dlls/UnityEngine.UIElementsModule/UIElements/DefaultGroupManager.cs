using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000264 RID: 612
	internal class DefaultGroupManager : IGroupManager
	{
		// Token: 0x06001160 RID: 4448 RVA: 0x0003EDB0 File Offset: 0x0003CFB0
		public void Init(IGroupBox groupBox)
		{
			this.m_GroupBox = groupBox;
		}

		// Token: 0x06001161 RID: 4449 RVA: 0x0003EDBC File Offset: 0x0003CFBC
		public IGroupBoxOption GetSelectedOption()
		{
			return this.m_SelectedOption;
		}

		// Token: 0x06001162 RID: 4450 RVA: 0x0003EDD4 File Offset: 0x0003CFD4
		public void OnOptionSelectionChanged(IGroupBoxOption selectedOption)
		{
			bool flag = this.m_SelectedOption == selectedOption;
			if (!flag)
			{
				this.m_SelectedOption = selectedOption;
				foreach (IGroupBoxOption groupBoxOption in this.m_GroupOptions)
				{
					groupBoxOption.SetSelected(groupBoxOption == this.m_SelectedOption);
				}
			}
		}

		// Token: 0x06001163 RID: 4451 RVA: 0x0003EE4C File Offset: 0x0003D04C
		public void RegisterOption(IGroupBoxOption option)
		{
			bool flag = !this.m_GroupOptions.Contains(option);
			if (flag)
			{
				this.m_GroupOptions.Add(option);
				this.m_GroupBox.OnOptionAdded(option);
			}
		}

		// Token: 0x06001164 RID: 4452 RVA: 0x0003EE89 File Offset: 0x0003D089
		public void UnregisterOption(IGroupBoxOption option)
		{
			this.m_GroupOptions.Remove(option);
			this.m_GroupBox.OnOptionRemoved(option);
		}

		// Token: 0x040007A3 RID: 1955
		private List<IGroupBoxOption> m_GroupOptions = new List<IGroupBoxOption>();

		// Token: 0x040007A4 RID: 1956
		private IGroupBoxOption m_SelectedOption;

		// Token: 0x040007A5 RID: 1957
		private IGroupBox m_GroupBox;
	}
}
