using System;
using UnityEngine.Serialization;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000034 RID: 52
	[AddComponentMenu("VFX/Property Binders/Previous Position Binder")]
	[VFXBinder("Transform/Position (Previous)")]
	internal class VFXPreviousPositionBinder : VFXBinderBase
	{
		// Token: 0x06000142 RID: 322 RVA: 0x00008340 File Offset: 0x00006540
		protected override void OnEnable()
		{
			base.OnEnable();
			this.oldPosition = ((this.Target != null) ? this.Target.position : Vector3.zero);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000836E File Offset: 0x0000656E
		public override bool IsValid(VisualEffect component)
		{
			return this.Target != null && component.HasVector3(this.m_Property);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00008391 File Offset: 0x00006591
		public override void UpdateBinding(VisualEffect component)
		{
			component.SetVector3(this.m_Property, this.oldPosition);
			this.oldPosition = this.Target.position;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x000083BB File Offset: 0x000065BB
		public override string ToString()
		{
			return string.Format("Previous Position : '{0}' -> {1}", this.m_Property, (this.Target == null) ? "(null)" : this.Target.name);
		}

		// Token: 0x040000E6 RID: 230
		[VFXPropertyBinding(new string[]
		{
			"UnityEngine.Vector3"
		})]
		[FormerlySerializedAs("m_Parameter")]
		public ExposedProperty m_Property = "PreviousPosition";

		// Token: 0x040000E7 RID: 231
		public Transform Target;

		// Token: 0x040000E8 RID: 232
		private Vector3 oldPosition;
	}
}
