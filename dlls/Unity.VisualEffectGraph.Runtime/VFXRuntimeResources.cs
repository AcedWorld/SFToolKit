using System;

namespace UnityEngine.VFX
{
	// Token: 0x0200001F RID: 31
	internal class VFXRuntimeResources : ScriptableObject
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00003CAF File Offset: 0x00001EAF
		// (set) Token: 0x06000073 RID: 115 RVA: 0x00003CB7 File Offset: 0x00001EB7
		internal ComputeShader sdfRayMapCS
		{
			get
			{
				return this.m_SDFRayMapCS;
			}
			set
			{
				this.m_SDFRayMapCS = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00003CC0 File Offset: 0x00001EC0
		// (set) Token: 0x06000075 RID: 117 RVA: 0x00003CC8 File Offset: 0x00001EC8
		internal ComputeShader sdfNormalsCS
		{
			get
			{
				return this.m_SDFNormalsCS;
			}
			set
			{
				this.m_SDFNormalsCS = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00003CD1 File Offset: 0x00001ED1
		// (set) Token: 0x06000077 RID: 119 RVA: 0x00003CD9 File Offset: 0x00001ED9
		internal Shader sdfRayMapShader
		{
			get
			{
				return this.m_SDFRayMapShader;
			}
			set
			{
				this.m_SDFRayMapShader = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00003CE2 File Offset: 0x00001EE2
		public static VFXRuntimeResources runtimeResources
		{
			get
			{
				return VFXManager.runtimeResources as VFXRuntimeResources;
			}
		}

		// Token: 0x04000051 RID: 81
		[SerializeField]
		private ComputeShader m_SDFRayMapCS;

		// Token: 0x04000052 RID: 82
		[SerializeField]
		private ComputeShader m_SDFNormalsCS;

		// Token: 0x04000053 RID: 83
		[SerializeField]
		private Shader m_SDFRayMapShader;
	}
}
