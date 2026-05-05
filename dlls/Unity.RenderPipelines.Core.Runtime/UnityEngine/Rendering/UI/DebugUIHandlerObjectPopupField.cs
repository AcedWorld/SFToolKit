using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x02000130 RID: 304
	public class DebugUIHandlerObjectPopupField : DebugUIHandlerField<DebugUI.ObjectPopupField>
	{
		// Token: 0x0600090C RID: 2316 RVA: 0x00029B3A File Offset: 0x00027D3A
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			this.m_Index = 0;
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x00029B4C File Offset: 0x00027D4C
		private void ChangeSelectedObject()
		{
			if (this.m_Field == null)
			{
				return;
			}
			IEnumerable<Object> enumerable = this.m_Field.getObjects();
			if (enumerable == null)
			{
				return;
			}
			Object[] array = enumerable.ToArray<Object>();
			int num = array.Count<Object>();
			if (this.m_Index >= num)
			{
				this.m_Index = 0;
			}
			else if (this.m_Index < 0)
			{
				this.m_Index = num - 1;
			}
			Object value = array[this.m_Index];
			this.m_Field.SetValue(value);
			this.UpdateValueLabel();
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x00029BC2 File Offset: 0x00027DC2
		public override void OnIncrement(bool fast)
		{
			this.m_Index++;
			this.ChangeSelectedObject();
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x00029BD8 File Offset: 0x00027DD8
		public override void OnDecrement(bool fast)
		{
			this.m_Index--;
			this.ChangeSelectedObject();
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x00029BF0 File Offset: 0x00027DF0
		public override void UpdateValueLabel()
		{
			Object value = this.m_Field.GetValue();
			string labelText = (value != null) ? value.name : "Empty";
			base.SetLabelText(labelText);
		}

		// Token: 0x04000550 RID: 1360
		private int m_Index;
	}
}
