using System;
using UnityEngine.Serialization;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000029 RID: 41
	[AddComponentMenu("VFX/Property Binders/Enabled Binder")]
	[VFXBinder("GameObject/Enabled")]
	internal class VFXEnabledBinder : VFXBinderBase
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00006FFC File Offset: 0x000051FC
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x00007009 File Offset: 0x00005209
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

		// Token: 0x060000E3 RID: 227 RVA: 0x00007017 File Offset: 0x00005217
		public override bool IsValid(VisualEffect component)
		{
			return this.Target != null && component.HasBool(this.m_Property);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000703A File Offset: 0x0000523A
		public override void UpdateBinding(VisualEffect component)
		{
			component.SetBool(this.m_Property, (this.check == VFXEnabledBinder.Check.ActiveInHierarchy) ? this.Target.activeInHierarchy : this.Target.activeSelf);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000706D File Offset: 0x0000526D
		public override string ToString()
		{
			return string.Format("{2} : '{0}' -> {1}", this.m_Property, (this.Target == null) ? "(null)" : this.Target.name, this.check);
		}

		// Token: 0x040000A1 RID: 161
		public VFXEnabledBinder.Check check;

		// Token: 0x040000A2 RID: 162
		[VFXPropertyBinding(new string[]
		{
			"System.Boolean"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_Parameter")]
		protected ExposedProperty m_Property = "Enabled";

		// Token: 0x040000A3 RID: 163
		public GameObject Target;

		// Token: 0x02000064 RID: 100
		public enum Check
		{
			// Token: 0x040001E6 RID: 486
			ActiveInHierarchy,
			// Token: 0x040001E7 RID: 487
			ActiveSelf
		}
	}
}
