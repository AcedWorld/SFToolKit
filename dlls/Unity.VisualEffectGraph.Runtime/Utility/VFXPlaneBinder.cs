using System;
using UnityEngine.Serialization;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000032 RID: 50
	[AddComponentMenu("VFX/Property Binders/Plane Binder")]
	[VFXBinder("Utility/Plane")]
	internal class VFXPlaneBinder : VFXBinderBase
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000133 RID: 307 RVA: 0x00008157 File Offset: 0x00006357
		// (set) Token: 0x06000134 RID: 308 RVA: 0x00008164 File Offset: 0x00006364
		public string Property
		{
			get
			{
				return (string)this.m_Property;
			}
			set
			{
				this.m_Property = value;
				this.UpdateSubProperties();
			}
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00008178 File Offset: 0x00006378
		protected override void OnEnable()
		{
			base.OnEnable();
			this.UpdateSubProperties();
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00008186 File Offset: 0x00006386
		private void OnValidate()
		{
			this.UpdateSubProperties();
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000818E File Offset: 0x0000638E
		private void UpdateSubProperties()
		{
			this.Position = this.m_Property + "_position";
			this.Normal = this.m_Property + "_normal";
		}

		// Token: 0x06000138 RID: 312 RVA: 0x000081C6 File Offset: 0x000063C6
		public override bool IsValid(VisualEffect component)
		{
			return this.Target != null && component.HasVector3(this.Position) && component.HasVector3(this.Normal);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x000081FC File Offset: 0x000063FC
		public override void UpdateBinding(VisualEffect component)
		{
			component.SetVector3(this.Position, this.Target.transform.position);
			component.SetVector3(this.Normal, this.Target.transform.up);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000824B File Offset: 0x0000644B
		public override string ToString()
		{
			return string.Format("Plane : '{0}' -> {1}", this.m_Property, (this.Target == null) ? "(null)" : this.Target.name);
		}

		// Token: 0x040000E0 RID: 224
		[VFXPropertyBinding(new string[]
		{
			"UnityEditor.VFX.Plane"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_Parameter")]
		protected ExposedProperty m_Property = "Plane";

		// Token: 0x040000E1 RID: 225
		public Transform Target;

		// Token: 0x040000E2 RID: 226
		private ExposedProperty Position;

		// Token: 0x040000E3 RID: 227
		private ExposedProperty Normal;
	}
}
