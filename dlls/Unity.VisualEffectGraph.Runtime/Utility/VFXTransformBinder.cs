using System;
using UnityEngine.Serialization;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000038 RID: 56
	[AddComponentMenu("VFX/Property Binders/Transform Binder")]
	[VFXBinder("Transform/Transform")]
	internal class VFXTransformBinder : VFXBinderBase
	{
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000167 RID: 359 RVA: 0x00008A57 File Offset: 0x00006C57
		// (set) Token: 0x06000168 RID: 360 RVA: 0x00008A64 File Offset: 0x00006C64
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

		// Token: 0x06000169 RID: 361 RVA: 0x00008A78 File Offset: 0x00006C78
		protected override void OnEnable()
		{
			base.OnEnable();
			this.UpdateSubProperties();
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00008A86 File Offset: 0x00006C86
		private void OnValidate()
		{
			this.UpdateSubProperties();
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00008A90 File Offset: 0x00006C90
		private void UpdateSubProperties()
		{
			this.Position = this.m_Property + "_position";
			this.Angles = this.m_Property + "_angles";
			this.Scale = this.m_Property + "_scale";
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00008AF0 File Offset: 0x00006CF0
		public override bool IsValid(VisualEffect component)
		{
			return this.Target != null && component.HasVector3(this.Position) && component.HasVector3(this.Angles) && component.HasVector3(this.Scale);
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00008B44 File Offset: 0x00006D44
		public override void UpdateBinding(VisualEffect component)
		{
			component.SetVector3(this.Position, this.Target.position);
			component.SetVector3(this.Angles, this.Target.eulerAngles);
			component.SetVector3(this.Scale, this.Target.localScale);
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00008BA5 File Offset: 0x00006DA5
		public override string ToString()
		{
			return string.Format("Transform : '{0}' -> {1}", this.m_Property, (this.Target == null) ? "(null)" : this.Target.name);
		}

		// Token: 0x040000FF RID: 255
		[VFXPropertyBinding(new string[]
		{
			"UnityEditor.VFX.Transform"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_Parameter")]
		protected ExposedProperty m_Property = "Transform";

		// Token: 0x04000100 RID: 256
		public Transform Target;

		// Token: 0x04000101 RID: 257
		private ExposedProperty Position;

		// Token: 0x04000102 RID: 258
		private ExposedProperty Angles;

		// Token: 0x04000103 RID: 259
		private ExposedProperty Scale;
	}
}
