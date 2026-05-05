using System;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000035 RID: 53
	[AddComponentMenu("VFX/Property Binders/Raycast Binder")]
	[VFXBinder("Physics/Raycast")]
	internal class VFXRaycastBinder : VFXBinderBase
	{
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000147 RID: 327 RVA: 0x00008405 File Offset: 0x00006605
		// (set) Token: 0x06000148 RID: 328 RVA: 0x00008412 File Offset: 0x00006612
		public string TargetPosition
		{
			get
			{
				return (string)this.m_TargetPosition;
			}
			set
			{
				this.m_TargetPosition = value;
				this.UpdateSubProperties();
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000149 RID: 329 RVA: 0x00008426 File Offset: 0x00006626
		// (set) Token: 0x0600014A RID: 330 RVA: 0x00008433 File Offset: 0x00006633
		public string TargetNormal
		{
			get
			{
				return (string)this.m_TargetNormal;
			}
			set
			{
				this.m_TargetNormal = value;
				this.UpdateSubProperties();
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600014B RID: 331 RVA: 0x00008447 File Offset: 0x00006647
		// (set) Token: 0x0600014C RID: 332 RVA: 0x00008454 File Offset: 0x00006654
		public string TargetHit
		{
			get
			{
				return (string)this.m_TargetHit;
			}
			set
			{
				this.m_TargetHit = value;
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00008462 File Offset: 0x00006662
		protected override void OnEnable()
		{
			base.OnEnable();
			this.UpdateSubProperties();
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00008470 File Offset: 0x00006670
		private void OnValidate()
		{
			this.UpdateSubProperties();
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00008478 File Offset: 0x00006678
		private void UpdateSubProperties()
		{
			this.m_TargetPosition_position = this.m_TargetPosition + "_position";
			this.m_TargetNormal_direction = this.m_TargetNormal + "_direction";
		}

		// Token: 0x06000150 RID: 336 RVA: 0x000084B0 File Offset: 0x000066B0
		public override bool IsValid(VisualEffect component)
		{
			return component.HasVector3(this.m_TargetPosition_position) && component.HasVector3(this.m_TargetNormal_direction) && component.HasBool(this.m_TargetHit) && this.RaycastSource != null;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00008504 File Offset: 0x00006704
		public override void UpdateBinding(VisualEffect component)
		{
			Vector3 direction = (this.RaycastDirectionSpace == VFXRaycastBinder.Space.Local) ? this.RaycastSource.transform.TransformDirection(this.RaycastDirection) : this.RaycastDirection;
			bool b = Physics.Raycast(new Ray(this.RaycastSource.transform.position, direction), out this.m_HitInfo, this.MaxDistance, this.Layers);
			component.SetVector3(this.m_TargetPosition_position, this.m_HitInfo.point);
			component.SetVector3(this.m_TargetNormal_direction, this.m_HitInfo.normal);
			component.SetBool(this.TargetHit, b);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x000085B0 File Offset: 0x000067B0
		public override string ToString()
		{
			return string.Format(string.Format("Raycast : {0} -> {1} ({2})", (this.RaycastSource == null) ? "null" : this.RaycastSource.name, this.RaycastDirection, this.RaycastDirectionSpace), Array.Empty<object>());
		}

		// Token: 0x040000E9 RID: 233
		[VFXPropertyBinding(new string[]
		{
			"UnityEditor.VFX.Position"
		})]
		[SerializeField]
		protected ExposedProperty m_TargetPosition = "TargetPosition";

		// Token: 0x040000EA RID: 234
		[VFXPropertyBinding(new string[]
		{
			"UnityEditor.VFX.DirectionType"
		})]
		[SerializeField]
		protected ExposedProperty m_TargetNormal = "TargetNormal";

		// Token: 0x040000EB RID: 235
		[VFXPropertyBinding(new string[]
		{
			"System.Boolean"
		})]
		[SerializeField]
		protected ExposedProperty m_TargetHit = "TargetHit";

		// Token: 0x040000EC RID: 236
		protected ExposedProperty m_TargetPosition_position;

		// Token: 0x040000ED RID: 237
		protected ExposedProperty m_TargetNormal_direction;

		// Token: 0x040000EE RID: 238
		public GameObject RaycastSource;

		// Token: 0x040000EF RID: 239
		public Vector3 RaycastDirection = Vector3.forward;

		// Token: 0x040000F0 RID: 240
		public VFXRaycastBinder.Space RaycastDirectionSpace;

		// Token: 0x040000F1 RID: 241
		public LayerMask Layers = -1;

		// Token: 0x040000F2 RID: 242
		public float MaxDistance = 100f;

		// Token: 0x040000F3 RID: 243
		private RaycastHit m_HitInfo;

		// Token: 0x02000067 RID: 103
		public enum Space
		{
			// Token: 0x040001F0 RID: 496
			Local,
			// Token: 0x040001F1 RID: 497
			World
		}
	}
}
