using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200016B RID: 363
	public static class HDShaderPassNames
	{
		// Token: 0x04000EAC RID: 3756
		public static readonly string s_EmptyStr = "";

		// Token: 0x04000EAD RID: 3757
		public static readonly string s_ForwardStr = "Forward";

		// Token: 0x04000EAE RID: 3758
		public static readonly string s_DepthOnlyStr = "DepthOnly";

		// Token: 0x04000EAF RID: 3759
		public static readonly string s_DepthForwardOnlyStr = "DepthForwardOnly";

		// Token: 0x04000EB0 RID: 3760
		public static readonly string s_ForwardOnlyStr = "ForwardOnly";

		// Token: 0x04000EB1 RID: 3761
		public static readonly string s_GBufferStr = "GBuffer";

		// Token: 0x04000EB2 RID: 3762
		public static readonly string s_GBufferWithPrepassStr = "GBufferWithPrepass";

		// Token: 0x04000EB3 RID: 3763
		public static readonly string s_SRPDefaultUnlitStr = "SRPDefaultUnlit";

		// Token: 0x04000EB4 RID: 3764
		public static readonly string s_MotionVectorsStr = "MotionVectors";

		// Token: 0x04000EB5 RID: 3765
		public static readonly string s_DistortionVectorsStr = "DistortionVectors";

		// Token: 0x04000EB6 RID: 3766
		public static readonly string s_TransparentDepthPrepassStr = "TransparentDepthPrepass";

		// Token: 0x04000EB7 RID: 3767
		public static readonly string s_TransparentBackfaceStr = "TransparentBackface";

		// Token: 0x04000EB8 RID: 3768
		public static readonly string s_TransparentDepthPostpassStr = "TransparentDepthPostpass";

		// Token: 0x04000EB9 RID: 3769
		public static readonly string s_RayTracingPrepassStr = "RayTracingPrepass";

		// Token: 0x04000EBA RID: 3770
		public static readonly string s_RayTracingGBufferStr = "GBufferDXR";

		// Token: 0x04000EBB RID: 3771
		public static readonly string s_RayTracingForwardStr = "ForwardDXR";

		// Token: 0x04000EBC RID: 3772
		public static readonly string s_RayTracingIndirectStr = "IndirectDXR";

		// Token: 0x04000EBD RID: 3773
		public static readonly string s_RayTracingVisibilityStr = "VisibilityDXR";

		// Token: 0x04000EBE RID: 3774
		public static readonly string s_PathTracingDXRStr = "PathTracingDXR";

		// Token: 0x04000EBF RID: 3775
		public static readonly string s_MetaStr = "META";

		// Token: 0x04000EC0 RID: 3776
		public static readonly string s_ShadowCasterStr = "ShadowCaster";

		// Token: 0x04000EC1 RID: 3777
		public static readonly string s_FullScreenDebugStr = "FullScreenDebug";

		// Token: 0x04000EC2 RID: 3778
		public static readonly string s_DBufferProjectorStr = DecalSystem.s_MaterialDecalPassNames[0];

		// Token: 0x04000EC3 RID: 3779
		public static readonly string s_DecalProjectorForwardEmissiveStr = DecalSystem.s_MaterialDecalPassNames[1];

		// Token: 0x04000EC4 RID: 3780
		public static readonly string s_DBufferMeshStr = DecalSystem.s_MaterialDecalPassNames[2];

		// Token: 0x04000EC5 RID: 3781
		public static readonly string s_DecalMeshForwardEmissiveStr = DecalSystem.s_MaterialDecalPassNames[3];

		// Token: 0x04000EC6 RID: 3782
		public static readonly string s_DBufferVFXDecalStr = "DBufferVFX";

		// Token: 0x04000EC7 RID: 3783
		public static readonly string s_FogVolumeVoxelizeStr = "FogVolumeVoxelize";

		// Token: 0x04000EC8 RID: 3784
		public static readonly ShaderTagId s_EmptyName = new ShaderTagId(HDShaderPassNames.s_EmptyStr);

		// Token: 0x04000EC9 RID: 3785
		public static readonly ShaderTagId s_ForwardName = new ShaderTagId(HDShaderPassNames.s_ForwardStr);

		// Token: 0x04000ECA RID: 3786
		public static readonly ShaderTagId s_DepthOnlyName = new ShaderTagId(HDShaderPassNames.s_DepthOnlyStr);

		// Token: 0x04000ECB RID: 3787
		public static readonly ShaderTagId s_DepthForwardOnlyName = new ShaderTagId(HDShaderPassNames.s_DepthForwardOnlyStr);

		// Token: 0x04000ECC RID: 3788
		public static readonly ShaderTagId s_ForwardOnlyName = new ShaderTagId(HDShaderPassNames.s_ForwardOnlyStr);

		// Token: 0x04000ECD RID: 3789
		public static readonly ShaderTagId s_GBufferName = new ShaderTagId(HDShaderPassNames.s_GBufferStr);

		// Token: 0x04000ECE RID: 3790
		public static readonly ShaderTagId s_GBufferWithPrepassName = new ShaderTagId(HDShaderPassNames.s_GBufferWithPrepassStr);

		// Token: 0x04000ECF RID: 3791
		public static readonly ShaderTagId s_SRPDefaultUnlitName = new ShaderTagId(HDShaderPassNames.s_SRPDefaultUnlitStr);

		// Token: 0x04000ED0 RID: 3792
		public static readonly ShaderTagId s_MotionVectorsName = new ShaderTagId(HDShaderPassNames.s_MotionVectorsStr);

		// Token: 0x04000ED1 RID: 3793
		public static readonly ShaderTagId s_DistortionVectorsName = new ShaderTagId(HDShaderPassNames.s_DistortionVectorsStr);

		// Token: 0x04000ED2 RID: 3794
		public static readonly ShaderTagId s_TransparentDepthPrepassName = new ShaderTagId(HDShaderPassNames.s_TransparentDepthPrepassStr);

		// Token: 0x04000ED3 RID: 3795
		public static readonly ShaderTagId s_TransparentBackfaceName = new ShaderTagId(HDShaderPassNames.s_TransparentBackfaceStr);

		// Token: 0x04000ED4 RID: 3796
		public static readonly ShaderTagId s_TransparentDepthPostpassName = new ShaderTagId(HDShaderPassNames.s_TransparentDepthPostpassStr);

		// Token: 0x04000ED5 RID: 3797
		public static readonly ShaderTagId s_RayTracingPrepassName = new ShaderTagId(HDShaderPassNames.s_RayTracingPrepassStr);

		// Token: 0x04000ED6 RID: 3798
		public static readonly ShaderTagId s_FullScreenDebugName = new ShaderTagId(HDShaderPassNames.s_FullScreenDebugStr);

		// Token: 0x04000ED7 RID: 3799
		public static readonly ShaderTagId s_DBufferMeshName = new ShaderTagId(HDShaderPassNames.s_DBufferMeshStr);

		// Token: 0x04000ED8 RID: 3800
		public static readonly ShaderTagId s_DecalMeshForwardEmissiveName = new ShaderTagId(HDShaderPassNames.s_DecalMeshForwardEmissiveStr);

		// Token: 0x04000ED9 RID: 3801
		public static readonly ShaderTagId s_DBufferVFXDecalName = new ShaderTagId(HDShaderPassNames.s_DBufferVFXDecalStr);

		// Token: 0x04000EDA RID: 3802
		public static readonly ShaderTagId s_FogVolumeVoxelizeName = new ShaderTagId(HDShaderPassNames.s_FogVolumeVoxelizeStr);

		// Token: 0x04000EDB RID: 3803
		internal static readonly ShaderTagId s_AlwaysName = new ShaderTagId("Always");

		// Token: 0x04000EDC RID: 3804
		internal static readonly ShaderTagId s_ForwardBaseName = new ShaderTagId("ForwardBase");

		// Token: 0x04000EDD RID: 3805
		internal static readonly ShaderTagId s_DeferredName = new ShaderTagId("Deferred");

		// Token: 0x04000EDE RID: 3806
		internal static readonly ShaderTagId s_PrepassBaseName = new ShaderTagId("PrepassBase");

		// Token: 0x04000EDF RID: 3807
		internal static readonly ShaderTagId s_VertexName = new ShaderTagId("Vertex");

		// Token: 0x04000EE0 RID: 3808
		internal static readonly ShaderTagId s_VertexLMRGBMName = new ShaderTagId("VertexLMRGBM");

		// Token: 0x04000EE1 RID: 3809
		internal static readonly ShaderTagId s_VertexLMName = new ShaderTagId("VertexLM");
	}
}
