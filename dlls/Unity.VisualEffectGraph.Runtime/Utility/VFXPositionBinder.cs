using System;
using UnityEngine.Serialization;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000033 RID: 51
	[AddComponentMenu("VFX/Property Binders/Position Binder")]
	[VFXBinder("Transform/Position")]
	internal class VFXPositionBinder : VFXBinderBase
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00008295 File Offset: 0x00006495
		// (set) Token: 0x0600013D RID: 317 RVA: 0x000082A2 File Offset: 0x000064A2
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

		// Token: 0x0600013E RID: 318 RVA: 0x000082B0 File Offset: 0x000064B0
		public override bool IsValid(VisualEffect component)
		{
			return this.Target != null && component.HasVector3(this.m_Property);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x000082D3 File Offset: 0x000064D3
		public override void UpdateBinding(VisualEffect component)
		{
			component.SetVector3(this.m_Property, this.Target.transform.position);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x000082F6 File Offset: 0x000064F6
		public override string ToString()
		{
			return string.Format("Position : '{0}' -> {1}", this.m_Property, (this.Target == null) ? "(null)" : this.Target.name);
		}

		// Token: 0x040000E4 RID: 228
		[VFXPropertyBinding(new string[]
		{
			"UnityEditor.VFX.Position",
			"UnityEngine.Vector3"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_Parameter")]
		protected ExposedProperty m_Property = "Position";

		// Token: 0x040000E5 RID: 229
		public Transform Target;
	}
}
