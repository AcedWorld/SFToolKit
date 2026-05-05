using System;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x0200003B RID: 59
	[AddComponentMenu("VFX/Property Binders/UI Toggle Binder")]
	[VFXBinder("UI/Toggle")]
	internal class VFXUIToggleBinder : VFXBinderBase
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600017C RID: 380 RVA: 0x00008D3B File Offset: 0x00006F3B
		// (set) Token: 0x0600017D RID: 381 RVA: 0x00008D48 File Offset: 0x00006F48
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

		// Token: 0x0600017E RID: 382 RVA: 0x00008D56 File Offset: 0x00006F56
		public override bool IsValid(VisualEffect component)
		{
			return this.Target != null && component.HasBool(this.m_Property);
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00008D79 File Offset: 0x00006F79
		public override void UpdateBinding(VisualEffect component)
		{
			component.SetBool(this.m_Property, this.Target.isOn);
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00008D97 File Offset: 0x00006F97
		public override string ToString()
		{
			return string.Format("UI Toggle : '{0}' -> {1}", this.m_Property, (this.Target == null) ? "(null)" : this.Target.name);
		}

		// Token: 0x04000108 RID: 264
		[VFXPropertyBinding(new string[]
		{
			"System.Boolean"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_Parameter")]
		protected ExposedProperty m_Property = "BoolParameter";

		// Token: 0x04000109 RID: 265
		public Toggle Target;
	}
}
