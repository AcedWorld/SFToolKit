using System;

namespace UnityEngine
{
	// Token: 0x020001CD RID: 461
	public struct CombineInstance
	{
		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x0600120E RID: 4622 RVA: 0x00019314 File Offset: 0x00017514
		// (set) Token: 0x0600120F RID: 4623 RVA: 0x00019331 File Offset: 0x00017531
		public Mesh mesh
		{
			get
			{
				return Mesh.FromInstanceID(this.m_MeshInstanceID);
			}
			set
			{
				this.m_MeshInstanceID = ((value != null) ? value.GetInstanceID() : 0);
			}
		}

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06001210 RID: 4624 RVA: 0x0001934C File Offset: 0x0001754C
		// (set) Token: 0x06001211 RID: 4625 RVA: 0x00019364 File Offset: 0x00017564
		public int subMeshIndex
		{
			get
			{
				return this.m_SubMeshIndex;
			}
			set
			{
				this.m_SubMeshIndex = value;
			}
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06001212 RID: 4626 RVA: 0x00019370 File Offset: 0x00017570
		// (set) Token: 0x06001213 RID: 4627 RVA: 0x00019388 File Offset: 0x00017588
		public Matrix4x4 transform
		{
			get
			{
				return this.m_Transform;
			}
			set
			{
				this.m_Transform = value;
			}
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06001214 RID: 4628 RVA: 0x00019394 File Offset: 0x00017594
		// (set) Token: 0x06001215 RID: 4629 RVA: 0x000193AC File Offset: 0x000175AC
		public Vector4 lightmapScaleOffset
		{
			get
			{
				return this.m_LightmapScaleOffset;
			}
			set
			{
				this.m_LightmapScaleOffset = value;
			}
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06001216 RID: 4630 RVA: 0x000193B8 File Offset: 0x000175B8
		// (set) Token: 0x06001217 RID: 4631 RVA: 0x000193D0 File Offset: 0x000175D0
		public Vector4 realtimeLightmapScaleOffset
		{
			get
			{
				return this.m_RealtimeLightmapScaleOffset;
			}
			set
			{
				this.m_RealtimeLightmapScaleOffset = value;
			}
		}

		// Token: 0x0400064F RID: 1615
		private int m_MeshInstanceID;

		// Token: 0x04000650 RID: 1616
		private int m_SubMeshIndex;

		// Token: 0x04000651 RID: 1617
		private Matrix4x4 m_Transform;

		// Token: 0x04000652 RID: 1618
		private Vector4 m_LightmapScaleOffset;

		// Token: 0x04000653 RID: 1619
		private Vector4 m_RealtimeLightmapScaleOffset;
	}
}
