using System;
using UnityEngine.Serialization;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x0200002B RID: 43
	[AddComponentMenu("VFX/Property Binders/Input Axis Binder")]
	[VFXBinder("Input/Axis")]
	internal class VFXInputAxisBinder : VFXBinderBase
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x000074D1 File Offset: 0x000056D1
		// (set) Token: 0x060000F1 RID: 241 RVA: 0x000074DE File Offset: 0x000056DE
		public string AxisProperty
		{
			get
			{
				return (string)this.m_AxisProperty;
			}
			set
			{
				this.m_AxisProperty = value;
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000074EC File Offset: 0x000056EC
		public override bool IsValid(VisualEffect component)
		{
			return component.HasFloat(this.m_AxisProperty);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00007500 File Offset: 0x00005700
		public override void UpdateBinding(VisualEffect component)
		{
			float axisRaw = Input.GetAxisRaw(this.AxisName);
			if (this.Accumulate)
			{
				float @float = component.GetFloat(this.m_AxisProperty);
				component.SetFloat(this.m_AxisProperty, @float + this.AccumulateSpeed * axisRaw * Time.deltaTime);
				return;
			}
			component.SetFloat(this.m_AxisProperty, axisRaw);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00007567 File Offset: 0x00005767
		public override string ToString()
		{
			return string.Format("Input Axis: '{0}' -> {1}", this.m_AxisProperty, this.AxisName.ToString());
		}

		// Token: 0x040000B0 RID: 176
		[VFXPropertyBinding(new string[]
		{
			"System.Single"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_AxisParameter")]
		protected ExposedProperty m_AxisProperty = "Axis";

		// Token: 0x040000B1 RID: 177
		public string AxisName = "Horizontal";

		// Token: 0x040000B2 RID: 178
		public float AccumulateSpeed = 1f;

		// Token: 0x040000B3 RID: 179
		public bool Accumulate = true;
	}
}
