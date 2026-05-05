using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200016D RID: 365
	public static class HDMaterialProperties
	{
		// Token: 0x0400122F RID: 4655
		public const string kZWrite = "_ZWrite";

		// Token: 0x04001230 RID: 4656
		public const string kTransparentZWrite = "_TransparentZWrite";

		// Token: 0x04001231 RID: 4657
		public const string kTransparentCullMode = "_TransparentCullMode";

		// Token: 0x04001232 RID: 4658
		public const string kOpaqueCullMode = "_OpaqueCullMode";

		// Token: 0x04001233 RID: 4659
		public const string kZTestTransparent = "_ZTestTransparent";

		// Token: 0x04001234 RID: 4660
		public const string kRayTracing = "_RayTracing";

		// Token: 0x04001235 RID: 4661
		public const string kSurfaceType = "_SurfaceType";

		// Token: 0x04001236 RID: 4662
		public const string kSupportDecals = "_SupportDecals";

		// Token: 0x04001237 RID: 4663
		public const string kAlphaCutoffEnabled = "_AlphaCutoffEnable";

		// Token: 0x04001238 RID: 4664
		public const string kBlendMode = "_BlendMode";

		// Token: 0x04001239 RID: 4665
		public const string kAlphaToMask = "_AlphaToMask";

		// Token: 0x0400123A RID: 4666
		public const string kEnableFogOnTransparent = "_EnableFogOnTransparent";

		// Token: 0x0400123B RID: 4667
		internal const string kDistortionDepthTest = "_DistortionDepthTest";

		// Token: 0x0400123C RID: 4668
		public const string kDistortionEnable = "_DistortionEnable";

		// Token: 0x0400123D RID: 4669
		public const string kZTestModeDistortion = "_ZTestModeDistortion";

		// Token: 0x0400123E RID: 4670
		public const string kDistortionBlendMode = "_DistortionBlendMode";

		// Token: 0x0400123F RID: 4671
		public const string kTransparentWritingMotionVec = "_TransparentWritingMotionVec";

		// Token: 0x04001240 RID: 4672
		public const string kEnableBlendModePreserveSpecularLighting = "_EnableBlendModePreserveSpecularLighting";

		// Token: 0x04001241 RID: 4673
		public const string kTransparentBackfaceEnable = "_TransparentBackfaceEnable";

		// Token: 0x04001242 RID: 4674
		public const string kDoubleSidedEnable = "_DoubleSidedEnable";

		// Token: 0x04001243 RID: 4675
		public const string kDoubleSidedNormalMode = "_DoubleSidedNormalMode";

		// Token: 0x04001244 RID: 4676
		public const string kDoubleSidedGIMode = "_DoubleSidedGIMode";

		// Token: 0x04001245 RID: 4677
		public const string kDistortionOnly = "_DistortionOnly";

		// Token: 0x04001246 RID: 4678
		public const string kTransparentDepthPrepassEnable = "_TransparentDepthPrepassEnable";

		// Token: 0x04001247 RID: 4679
		public const string kTransparentDepthPostpassEnable = "_TransparentDepthPostpassEnable";

		// Token: 0x04001248 RID: 4680
		public const string kTransparentSortPriority = "_TransparentSortPriority";

		// Token: 0x04001249 RID: 4681
		public const string kReceivesSSR = "_ReceivesSSR";

		// Token: 0x0400124A RID: 4682
		public const string kReceivesSSRTransparent = "_ReceivesSSRTransparent";

		// Token: 0x0400124B RID: 4683
		public const string kDepthOffsetEnable = "_DepthOffsetEnable";

		// Token: 0x0400124C RID: 4684
		public const string kConservativeDepthOffsetEnable = "_ConservativeDepthOffsetEnable";

		// Token: 0x0400124D RID: 4685
		public const string kAffectAlbedo = "_AffectAlbedo";

		// Token: 0x0400124E RID: 4686
		public const string kAffectNormal = "_AffectNormal";

		// Token: 0x0400124F RID: 4687
		public const string kAffectAO = "_AffectAO";

		// Token: 0x04001250 RID: 4688
		public const string kAffectMetal = "_AffectMetal";

		// Token: 0x04001251 RID: 4689
		public const string kAffectSmoothness = "_AffectSmoothness";

		// Token: 0x04001252 RID: 4690
		public const string kAffectEmission = "_AffectEmission";

		// Token: 0x04001253 RID: 4691
		public const string kExcludeFromTUAndAA = "_ExcludeFromTUAndAA";

		// Token: 0x04001254 RID: 4692
		internal const string kStencilRef = "_StencilRef";

		// Token: 0x04001255 RID: 4693
		internal const string kStencilWriteMask = "_StencilWriteMask";

		// Token: 0x04001256 RID: 4694
		internal const string kStencilRefDepth = "_StencilRefDepth";

		// Token: 0x04001257 RID: 4695
		internal const string kStencilWriteMaskDepth = "_StencilWriteMaskDepth";

		// Token: 0x04001258 RID: 4696
		internal const string kStencilRefGBuffer = "_StencilRefGBuffer";

		// Token: 0x04001259 RID: 4697
		internal const string kStencilWriteMaskGBuffer = "_StencilWriteMaskGBuffer";

		// Token: 0x0400125A RID: 4698
		internal const string kStencilRefMV = "_StencilRefMV";

		// Token: 0x0400125B RID: 4699
		internal const string kStencilWriteMaskMV = "_StencilWriteMaskMV";

		// Token: 0x0400125C RID: 4700
		internal const string kStencilRefDistortionVec = "_StencilRefDistortionVec";

		// Token: 0x0400125D RID: 4701
		internal const string kStencilWriteMaskDistortionVec = "_StencilWriteMaskDistortionVec";

		// Token: 0x0400125E RID: 4702
		internal const string kDecalStencilWriteMask = "_DecalStencilWriteMask";

		// Token: 0x0400125F RID: 4703
		internal const string kDecalStencilRef = "_DecalStencilRef";

		// Token: 0x04001260 RID: 4704
		internal const string kEnableGeometricSpecularAA = "_EnableGeometricSpecularAA";

		// Token: 0x04001261 RID: 4705
		internal const string kRenderQueueTypeShaderGraph = "_RenderQueueType";

		// Token: 0x04001262 RID: 4706
		internal const string kUseSplitLighting = "_RequireSplitLighting";

		// Token: 0x04001263 RID: 4707
		internal const string kDecalColorMask0 = "_DecalColorMask0";

		// Token: 0x04001264 RID: 4708
		internal const string kDecalColorMask1 = "_DecalColorMask1";

		// Token: 0x04001265 RID: 4709
		internal const string kDecalColorMask2 = "_DecalColorMask2";

		// Token: 0x04001266 RID: 4710
		internal const string kDecalColorMask3 = "_DecalColorMask3";

		// Token: 0x04001267 RID: 4711
		internal const string kEnableDecals = "_SupportDecals";

		// Token: 0x04001268 RID: 4712
		internal const int kMaxLayerCount = 4;

		// Token: 0x04001269 RID: 4713
		internal const string kLayerCount = "_LayerCount";

		// Token: 0x0400126A RID: 4714
		internal const string kUVBase = "_UVBase";

		// Token: 0x0400126B RID: 4715
		internal const string kTexWorldScale = "_TexWorldScale";

		// Token: 0x0400126C RID: 4716
		internal const string kInvTilingScale = "_InvTilingScale";

		// Token: 0x0400126D RID: 4717
		internal const string kUVMappingMask = "_UVMappingMask";

		// Token: 0x0400126E RID: 4718
		internal const string kUVDetail = "_UVDetail";

		// Token: 0x0400126F RID: 4719
		internal const string kUVDetailsMappingMask = "_UVDetailsMappingMask";

		// Token: 0x04001270 RID: 4720
		internal const string kDecalLayerMaskFromDecal = "_DecalLayerMaskFromDecal";

		// Token: 0x04001271 RID: 4721
		internal const string kObjectSpaceUVMapping = "_ObjectSpaceUVMapping";

		// Token: 0x04001272 RID: 4722
		internal const string kDisplacementMode = "_DisplacementMode";

		// Token: 0x04001273 RID: 4723
		internal const string kMaterialID = "_MaterialID";

		// Token: 0x04001274 RID: 4724
		internal const string kTransmissionEnable = "_TransmissionEnable";

		// Token: 0x04001275 RID: 4725
		internal const string kZTestGBuffer = "_ZTestGBuffer";

		// Token: 0x04001276 RID: 4726
		internal const string kZTestDepthEqualForOpaque = "_ZTestDepthEqualForOpaque";

		// Token: 0x04001277 RID: 4727
		internal const string kEmissionColor = "_EmissionColor";

		// Token: 0x04001278 RID: 4728
		internal const string kEnableSSR = "_ReceivesSSR";

		// Token: 0x04001279 RID: 4729
		internal const string kAddPrecomputedVelocity = "_AddPrecomputedVelocity";

		// Token: 0x0400127A RID: 4730
		internal const string kShadowMatteFilter = "_ShadowMatteFilter";

		// Token: 0x0400127B RID: 4731
		internal const string kTransmittanceColorMap = "_TransmittanceColorMap";

		// Token: 0x0400127C RID: 4732
		internal const string kRefractionModel = "_RefractionModel";

		// Token: 0x0400127D RID: 4733
		internal const string kSpecularOcclusionMode = "_SpecularOcclusionMode";

		// Token: 0x0400127E RID: 4734
		internal const string kCutoff = "_Cutoff";

		// Token: 0x0400127F RID: 4735
		internal const string kAlphaCutoff = "_AlphaCutoff";

		// Token: 0x04001280 RID: 4736
		internal const string kUseShadowThreshold = "_UseShadowThreshold";

		// Token: 0x04001281 RID: 4737
		internal const string kAlphaCutoffShadow = "_AlphaCutoffShadow";

		// Token: 0x04001282 RID: 4738
		internal const string kAlphaCutoffPrepass = "_AlphaCutoffPrepass";

		// Token: 0x04001283 RID: 4739
		internal const string kAlphaCutoffPostpass = "_AlphaCutoffPostpass";

		// Token: 0x04001284 RID: 4740
		internal const string kBaseColor = "_BaseColor";

		// Token: 0x04001285 RID: 4741
		internal const string kBaseColorMap = "_BaseColorMap";

		// Token: 0x04001286 RID: 4742
		internal const string kMetallic = "_Metallic";

		// Token: 0x04001287 RID: 4743
		internal const string kSmoothness = "_Smoothness";

		// Token: 0x04001288 RID: 4744
		internal const string kUseEmissiveIntensity = "_UseEmissiveIntensity";

		// Token: 0x04001289 RID: 4745
		internal const string kEmissiveExposureWeight = "_EmissiveExposureWeight";

		// Token: 0x0400128A RID: 4746
		internal const string kEmissiveIntensity = "_EmissiveIntensity";

		// Token: 0x0400128B RID: 4747
		internal const string kEmissiveIntensityUnit = "_EmissiveIntensityUnit";

		// Token: 0x0400128C RID: 4748
		internal const string kForceForwardEmissive = "_ForceForwardEmissive";

		// Token: 0x0400128D RID: 4749
		internal const string kEmissiveColor = "_EmissiveColor";

		// Token: 0x0400128E RID: 4750
		internal const string kEmissiveColorLDR = "_EmissiveColorLDR";

		// Token: 0x0400128F RID: 4751
		internal const string kEmissiveColorHDR = "_EmissiveColorHDR";

		// Token: 0x04001290 RID: 4752
		internal const string kEmissiveColorMap = "_EmissiveColorMap";

		// Token: 0x04001291 RID: 4753
		internal const string kUVEmissive = "_UVEmissive";

		// Token: 0x04001292 RID: 4754
		internal const string kTessellationMode = "_TessellationMode";

		// Token: 0x04001293 RID: 4755
		internal const string kTessellationFactor = "_TessellationFactor";

		// Token: 0x04001294 RID: 4756
		internal const string kTessellationFactorMinDistance = "_TessellationFactorMinDistance";

		// Token: 0x04001295 RID: 4757
		internal const string kTessellationFactorMaxDistance = "_TessellationFactorMaxDistance";

		// Token: 0x04001296 RID: 4758
		internal const string kTessellationFactorTriangleSize = "_TessellationFactorTriangleSize";

		// Token: 0x04001297 RID: 4759
		internal const string kTessellationShapeFactor = "_TessellationShapeFactor";

		// Token: 0x04001298 RID: 4760
		internal const string kTessellationBackFaceCullEpsilon = "_TessellationBackFaceCullEpsilon";

		// Token: 0x04001299 RID: 4761
		internal const string kTessellationMaxDisplacement = "_TessellationMaxDisplacement";

		// Token: 0x0400129A RID: 4762
		internal const string kHeightMap = "_HeightMap";

		// Token: 0x0400129B RID: 4763
		internal const string kHeightAmplitude = "_HeightAmplitude";

		// Token: 0x0400129C RID: 4764
		internal const string kHeightCenter = "_HeightCenter";

		// Token: 0x0400129D RID: 4765
		internal const string kHeightPoMAmplitude = "_HeightPoMAmplitude";

		// Token: 0x0400129E RID: 4766
		internal const string kHeightTessCenter = "_HeightTessCenter";

		// Token: 0x0400129F RID: 4767
		internal const string kHeightTessAmplitude = "_HeightTessAmplitude";

		// Token: 0x040012A0 RID: 4768
		internal const string kHeightMin = "_HeightMin";

		// Token: 0x040012A1 RID: 4769
		internal const string kHeightMax = "_HeightMax";

		// Token: 0x040012A2 RID: 4770
		internal const string kHeightOffset = "_HeightOffset";

		// Token: 0x040012A3 RID: 4771
		internal const string kHeightParametrization = "_HeightMapParametrization";

		// Token: 0x040012A4 RID: 4772
		internal const string kDisplacementLockObjectScale = "_DisplacementLockObjectScale";

		// Token: 0x040012A5 RID: 4773
		internal const string kDisplacementLockTilingScale = "_DisplacementLockTilingScale";

		// Token: 0x040012A6 RID: 4774
		internal const string kEnableHeightBlend = "_EnableHeightBlend";

		// Token: 0x040012A7 RID: 4775
		internal const string kHeightTransition = "_HeightTransition";

		// Token: 0x040012A8 RID: 4776
		internal const string kEnableInstancedPerPixelNormal = "_EnableInstancedPerPixelNormal";

		// Token: 0x040012A9 RID: 4777
		internal const string kMaskMap = "_MaskMap";

		// Token: 0x040012AA RID: 4778
		internal const string kDetailMap = "_DetailMap";

		// Token: 0x040012AB RID: 4779
		internal const string kNormalMap = "_NormalMap";

		// Token: 0x040012AC RID: 4780
		internal const string kNormalMapOS = "_NormalMapOS";

		// Token: 0x040012AD RID: 4781
		internal const string kNormalMapSpace = "_NormalMapSpace";

		// Token: 0x040012AE RID: 4782
		internal const string kBentNormalMap = "_BentNormalMap";

		// Token: 0x040012AF RID: 4783
		internal const string kBentNormalMapOS = "_BentNormalMapOS";

		// Token: 0x040012B0 RID: 4784
		internal const string kTangentMap = "_TangentMap";

		// Token: 0x040012B1 RID: 4785
		internal const string kTangentMapOS = "_TangentMapOS";

		// Token: 0x040012B2 RID: 4786
		internal const string kSubsurfaceMaskMap = "_SubsurfaceMaskMap";

		// Token: 0x040012B3 RID: 4787
		internal const string kTransmissionMaskMap = "_TransmissionMaskMap";

		// Token: 0x040012B4 RID: 4788
		internal const string kThicknessMap = "_ThicknessMap";

		// Token: 0x040012B5 RID: 4789
		internal const string kSpecularColorMap = "_SpecularColorMap";

		// Token: 0x040012B6 RID: 4790
		internal const string kAnisotropyMap = "_AnisotropyMap";

		// Token: 0x040012B7 RID: 4791
		internal const string kIridescenceThicknessMap = "_IridescenceThicknessMap";

		// Token: 0x040012B8 RID: 4792
		internal const string kCoatMask = "_CoatMask";

		// Token: 0x040012B9 RID: 4793
		internal const string kCoatMaskMap = "_CoatMaskMap";
	}
}
