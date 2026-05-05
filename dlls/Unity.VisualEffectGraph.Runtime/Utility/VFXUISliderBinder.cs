using System;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x0200003A RID: 58
	[AddComponentMenu("VFX/Property Binders/UI Slider Binder")]
	[VFXBinder("UI/Slider")]
	internal class VFXUISliderBinder : VFXBinderBase
	{
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000176 RID: 374 RVA: 0x00008C95 File Offset: 0x00006E95
		// (set) Token: 0x06000177 RID: 375 RVA: 0x00008CA2 File Offset: 0x00006EA2
		public string Property
		{
			get
			{
				return (string)this.m_Property;
			}
			set
			{
				this.m_Property = value;
			}
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00008CB0 File Offset: 0x00006EB0
		public override bool IsValid(VisualEffect component)
		{
			return this.Target != null && component.HasFloat(this.m_Property);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00008CD3 File Offset: 0x00006ED3
		public override void UpdateBinding(VisualEffect component)
		{
			component.SetFloat(this.m_Property, this.Target.value);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00008CF1 File Offset: 0x00006EF1
		public override string ToString()
		{
			return string.Format("UI Slider : '{0}' -> {1}", this.m_Property, (this.Target == null) ? "(null)" : this.Target.name);
		}

		// Token: 0x04000106 RID: 262
		[VFXPropertyBinding(new string[]
		{
			"System.Single"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_Parameter")]
		protected ExposedProperty m_Property = "FloatParameter";

		// Token: 0x04000107 RID: 263
		public Slider Target;
	}
}
