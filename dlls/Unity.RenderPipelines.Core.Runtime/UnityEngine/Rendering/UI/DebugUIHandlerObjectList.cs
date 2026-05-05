using System;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x0200012F RID: 303
	public class DebugUIHandlerObjectList : DebugUIHandlerField<DebugUI.ObjectListField>
	{
		// Token: 0x06000907 RID: 2311 RVA: 0x00029AA7 File Offset: 0x00027CA7
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			this.m_Index = 0;
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x00029AB7 File Offset: 0x00027CB7
		public override void OnIncrement(bool fast)
		{
			this.m_Index++;
			this.UpdateValueLabel();
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x00029ACD File Offset: 0x00027CCD
		public override void OnDecrement(bool fast)
		{
			this.m_Index--;
			this.UpdateValueLabel();
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x00029AE4 File Offset: 0x00027CE4
		public override void UpdateValueLabel()
		{
			string labelText = "Empty";
			Object[] value = this.m_Field.GetValue();
			if (value != null)
			{
				this.m_Index = Math.Clamp(this.m_Index, 0, value.Length - 1);
				labelText = value[this.m_Index].name;
			}
			base.SetLabelText(labelText);
		}

		// Token: 0x0400054F RID: 1359
		private int m_Index;
	}
}
