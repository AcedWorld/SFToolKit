using System;
using UnityEngine.Serialization;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x0200003C RID: 60
	[AddComponentMenu("VFX/Property Binders/Velocity Binder")]
	[VFXBinder("Transform/Velocity")]
	internal class VFXVelocityBinder : VFXBinderBase
	{
		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000182 RID: 386 RVA: 0x00008DE1 File Offset: 0x00006FE1
		// (set) Token: 0x06000183 RID: 387 RVA: 0x00008DEE File Offset: 0x00006FEE
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

		// Token: 0x06000184 RID: 388 RVA: 0x00008DFC File Offset: 0x00006FFC
		public override bool IsValid(VisualEffect component)
		{
			return this.Target != null && component.HasVector3(this.m_Property);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00008E1F File Offset: 0x0000701F
		public override void Reset()
		{
			this.m_PreviousTime = VFXVelocityBinder.invalidPreviousTime;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00008E2C File Offset: 0x0000702C
		public override void UpdateBinding(VisualEffect component)
		{
			Vector3 v = Vector3.zero;
			float time = Time.time;
			if (this.m_PreviousTime != VFXVelocityBinder.invalidPreviousTime)
			{
				Vector3 vector = this.Target.transform.position - this.m_PreviousPosition;
				float num = time - this.m_PreviousTime;
				if (Vector3.SqrMagnitude(vector) > Mathf.Epsilon && num > Mathf.Epsilon)
				{
					v = vector / num;
				}
			}
			component.SetVector3(this.m_Property, v);
			this.m_PreviousPosition = this.Target.transform.position;
			this.m_PreviousTime = time;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00008EC3 File Offset: 0x000070C3
		public override string ToString()
		{
			return string.Format("Velocity : '{0}' -> {1}", this.m_Property, (this.Target == null) ? "(null)" : this.Target.name);
		}

		// Token: 0x0400010A RID: 266
		[VFXPropertyBinding(new string[]
		{
			"UnityEngine.Vector3"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_Parameter")]
		public ExposedProperty m_Property = "Velocity";

		// Token: 0x0400010B RID: 267
		public Transform Target;

		// Token: 0x0400010C RID: 268
		private static readonly float invalidPreviousTime = -1f;

		// Token: 0x0400010D RID: 269
		private float m_PreviousTime = VFXVelocityBinder.invalidPreviousTime;

		// Token: 0x0400010E RID: 270
		private Vector3 m_PreviousPosition = Vector3.zero;
	}
}
