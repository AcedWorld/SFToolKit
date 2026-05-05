using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering
{
	// Token: 0x020000E7 RID: 231
	[ExecuteAlways]
	[AddComponentMenu("Miscellaneous/Volume")]
	public class Volume : MonoBehaviour, IVolume
	{
		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600079E RID: 1950 RVA: 0x00025402 File Offset: 0x00023602
		// (set) Token: 0x0600079F RID: 1951 RVA: 0x0002540A File Offset: 0x0002360A
		[Tooltip("When enabled, the Volume is applied to the entire Scene.")]
		public bool isGlobal
		{
			get
			{
				return this.m_IsGlobal;
			}
			set
			{
				this.m_IsGlobal = value;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x060007A0 RID: 1952 RVA: 0x00025414 File Offset: 0x00023614
		// (set) Token: 0x060007A1 RID: 1953 RVA: 0x000254C0 File Offset: 0x000236C0
		public VolumeProfile profile
		{
			get
			{
				if (this.m_InternalProfile == null)
				{
					this.m_InternalProfile = ScriptableObject.CreateInstance<VolumeProfile>();
					if (this.sharedProfile != null)
					{
						this.m_InternalProfile.name = this.sharedProfile.name;
						foreach (VolumeComponent original in this.sharedProfile.components)
						{
							VolumeComponent item = Object.Instantiate<VolumeComponent>(original);
							this.m_InternalProfile.components.Add(item);
						}
					}
				}
				return this.m_InternalProfile;
			}
			set
			{
				this.m_InternalProfile = value;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060007A2 RID: 1954 RVA: 0x000254C9 File Offset: 0x000236C9
		public List<Collider> colliders
		{
			get
			{
				return this.m_Colliders;
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060007A3 RID: 1955 RVA: 0x000254D1 File Offset: 0x000236D1
		internal VolumeProfile profileRef
		{
			get
			{
				if (!(this.m_InternalProfile == null))
				{
					return this.m_InternalProfile;
				}
				return this.sharedProfile;
			}
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x000254EE File Offset: 0x000236EE
		public bool HasInstantiatedProfile()
		{
			return this.m_InternalProfile != null;
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x000254FC File Offset: 0x000236FC
		private void OnEnable()
		{
			this.m_PreviousLayer = base.gameObject.layer;
			VolumeManager.instance.Register(this, this.m_PreviousLayer);
			base.GetComponents<Collider>(this.m_Colliders);
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0002552C File Offset: 0x0002372C
		private void OnDisable()
		{
			VolumeManager.instance.Unregister(this, base.gameObject.layer);
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x00025544 File Offset: 0x00023744
		private void Update()
		{
			this.UpdateLayer();
			if (this.priority != this.m_PreviousPriority)
			{
				VolumeManager.instance.SetLayerDirty(base.gameObject.layer);
				this.m_PreviousPriority = this.priority;
			}
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0002557C File Offset: 0x0002377C
		internal void UpdateLayer()
		{
			int layer = base.gameObject.layer;
			if (layer != this.m_PreviousLayer)
			{
				VolumeManager.instance.UpdateVolumeLayer(this, this.m_PreviousLayer, layer);
				this.m_PreviousLayer = layer;
			}
		}

		// Token: 0x040004BF RID: 1215
		[SerializeField]
		[FormerlySerializedAs("isGlobal")]
		private bool m_IsGlobal = true;

		// Token: 0x040004C0 RID: 1216
		[Tooltip("A value which determines which Volume is being used when Volumes have an equal amount of influence on the Scene. Volumes with a higher priority will override lower ones.")]
		[Delayed]
		public float priority;

		// Token: 0x040004C1 RID: 1217
		[Tooltip("Sets the outer distance to start blending from. A value of 0 means no blending and Unity applies the Volume overrides immediately upon entry.")]
		public float blendDistance;

		// Token: 0x040004C2 RID: 1218
		[Range(0f, 1f)]
		[Tooltip("Sets the total weight of this Volume in the Scene. 0 means no effect and 1 means full effect.")]
		public float weight = 1f;

		// Token: 0x040004C3 RID: 1219
		public VolumeProfile sharedProfile;

		// Token: 0x040004C4 RID: 1220
		internal List<Collider> m_Colliders = new List<Collider>();

		// Token: 0x040004C5 RID: 1221
		private int m_PreviousLayer;

		// Token: 0x040004C6 RID: 1222
		private float m_PreviousPriority;

		// Token: 0x040004C7 RID: 1223
		private VolumeProfile m_InternalProfile;
	}
}
