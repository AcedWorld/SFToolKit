using System;
using UnityEngine.Serialization;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000036 RID: 54
	[AddComponentMenu("VFX/Property Binders/Sphere Collider Binder")]
	[VFXBinder("Collider/Sphere")]
	internal class VFXSphereBinder : VFXBinderBase
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000154 RID: 340 RVA: 0x0000866D File Offset: 0x0000686D
		// (set) Token: 0x06000155 RID: 341 RVA: 0x0000867A File Offset: 0x0000687A
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

		// Token: 0x06000156 RID: 342 RVA: 0x0000868E File Offset: 0x0000688E
		protected override void OnEnable()
		{
			base.OnEnable();
			this.UpdateSubProperties();
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0000869C File Offset: 0x0000689C
		private void OnValidate()
		{
			this.UpdateSubProperties();
		}

		// Token: 0x06000158 RID: 344 RVA: 0x000086A4 File Offset: 0x000068A4
		private void UpdateSubProperties()
		{
			this.m_Old_Center = this.m_Property + "_center";
			this.m_New_Center = this.m_Property + "_transform_position";
			this.m_Radius = this.m_Property + "_radius";
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00008704 File Offset: 0x00006904
		public override bool IsValid(VisualEffect component)
		{
			return this.Target != null && (component.HasVector3(this.m_New_Center) || component.HasVector3(this.m_Old_Center)) && component.HasFloat(this.m_Radius);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00008758 File Offset: 0x00006958
		public override void UpdateBinding(VisualEffect component)
		{
			Vector3 v = this.Target.transform.position + this.Target.center;
			if (component.HasVector3(this.m_New_Center))
			{
				component.SetVector3(this.m_New_Center, v);
			}
			else
			{
				component.SetVector3(this.m_Old_Center, v);
			}
			component.SetFloat(this.m_Radius, this.Target.radius * this.GetSphereColliderScale(this.Target.transform.localScale));
		}

		// Token: 0x0600015B RID: 347 RVA: 0x000087F2 File Offset: 0x000069F2
		public float GetSphereColliderScale(Vector3 scale)
		{
			return Mathf.Max(scale.x, Mathf.Max(scale.y, scale.z));
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00008810 File Offset: 0x00006A10
		public override string ToString()
		{
			return string.Format("Sphere : '{0}' -> {1}", this.m_Property, (this.Target == null) ? "(null)" : this.Target.name);
		}

		// Token: 0x040000F4 RID: 244
		[VFXPropertyBinding(new string[]
		{
			"UnityEditor.VFX.Sphere",
			"UnityEditor.VFX.TSphere"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_Parameter")]
		protected ExposedProperty m_Property = "Sphere";

		// Token: 0x040000F5 RID: 245
		public SphereCollider Target;

		// Token: 0x040000F6 RID: 246
		private ExposedProperty m_Old_Center;

		// Token: 0x040000F7 RID: 247
		private ExposedProperty m_New_Center;

		// Token: 0x040000F8 RID: 248
		private ExposedProperty m_Radius;
	}
}
