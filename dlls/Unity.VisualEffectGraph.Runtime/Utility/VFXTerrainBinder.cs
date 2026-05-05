using System;
using UnityEngine.Serialization;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000037 RID: 55
	[AddComponentMenu("VFX/Property Binders/Terrain Binder")]
	[VFXBinder("Utility/Terrain")]
	internal class VFXTerrainBinder : VFXBinderBase
	{
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600015E RID: 350 RVA: 0x0000885A File Offset: 0x00006A5A
		// (set) Token: 0x0600015F RID: 351 RVA: 0x00008867 File Offset: 0x00006A67
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

		// Token: 0x06000160 RID: 352 RVA: 0x0000887B File Offset: 0x00006A7B
		protected override void OnEnable()
		{
			base.OnEnable();
			this.UpdateSubProperties();
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00008889 File Offset: 0x00006A89
		private void OnValidate()
		{
			this.UpdateSubProperties();
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00008894 File Offset: 0x00006A94
		private void UpdateSubProperties()
		{
			this.Terrain_Bounds_center = this.m_Property + "_Bounds_center";
			this.Terrain_Bounds_size = this.m_Property + "_Bounds_size";
			this.Terrain_HeightMap = this.m_Property + "_HeightMap";
			this.Terrain_Height = this.m_Property + "_Height";
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00008910 File Offset: 0x00006B10
		public override bool IsValid(VisualEffect component)
		{
			return this.Terrain != null && component.HasVector3(this.Terrain_Bounds_center) && component.HasVector3(this.Terrain_Bounds_size) && component.HasTexture(this.Terrain_HeightMap) && component.HasFloat(this.Terrain_Height);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00008978 File Offset: 0x00006B78
		public override void UpdateBinding(VisualEffect component)
		{
			Bounds bounds = this.Terrain.terrainData.bounds;
			component.SetVector3(this.Terrain_Bounds_center, bounds.center);
			component.SetVector3(this.Terrain_Bounds_size, bounds.size);
			component.SetTexture(this.Terrain_HeightMap, this.Terrain.terrainData.heightmapTexture);
			component.SetFloat(this.Terrain_Height, this.Terrain.terrainData.heightmapScale.y);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00008A0D File Offset: 0x00006C0D
		public override string ToString()
		{
			return string.Format("Terrain : '{0}' -> {1}", this.m_Property, (this.Terrain == null) ? "(null)" : this.Terrain.name);
		}

		// Token: 0x040000F9 RID: 249
		[VFXPropertyBinding(new string[]
		{
			"UnityEditor.VFX.TerrainType"
		})]
		[FormerlySerializedAs("TerrainParameter")]
		public ExposedProperty m_Property = "Terrain";

		// Token: 0x040000FA RID: 250
		public Terrain Terrain;

		// Token: 0x040000FB RID: 251
		private ExposedProperty Terrain_Bounds_center;

		// Token: 0x040000FC RID: 252
		private ExposedProperty Terrain_Bounds_size;

		// Token: 0x040000FD RID: 253
		private ExposedProperty Terrain_HeightMap;

		// Token: 0x040000FE RID: 254
		private ExposedProperty Terrain_Height;
	}
}
