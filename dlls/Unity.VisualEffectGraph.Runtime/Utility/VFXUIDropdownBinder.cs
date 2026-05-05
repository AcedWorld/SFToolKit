using System;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000039 RID: 57
	[AddComponentMenu("VFX/Property Binders/UI Dropdown Binder")]
	[VFXBinder("UI/Dropdown")]
	internal class VFXUIDropdownBinder : VFXBinderBase
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000170 RID: 368 RVA: 0x00008BEF File Offset: 0x00006DEF
		// (set) Token: 0x06000171 RID: 369 RVA: 0x00008BFC File Offset: 0x00006DFC
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

		// Token: 0x06000172 RID: 370 RVA: 0x00008C0A File Offset: 0x00006E0A
		public override bool IsValid(VisualEffect component)
		{
			return this.Target != null && component.HasInt(this.m_Property);
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00008C2D File Offset: 0x00006E2D
		public override void UpdateBinding(VisualEffect component)
		{
			component.SetInt(this.m_Property, this.Target.value);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00008C4B File Offset: 0x00006E4B
		public override string ToString()
		{
			return string.Format("UI Dropdown : '{0}' -> {1}", this.m_Property, (this.Target == null) ? "(null)" : this.Target.name);
		}

		// Token: 0x04000104 RID: 260
		[VFXPropertyBinding(new string[]
		{
			"System.Int32"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_Parameter")]
		protected ExposedProperty m_Property = "IntParameter";

		// Token: 0x04000105 RID: 261
		public Dropdown Target;
	}
}
