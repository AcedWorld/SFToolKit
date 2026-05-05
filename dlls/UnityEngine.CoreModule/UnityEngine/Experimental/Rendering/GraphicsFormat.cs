using System;
using System.ComponentModel;

namespace UnityEngine.Experimental.Rendering
{
	// Token: 0x020004DD RID: 1245
	public enum GraphicsFormat
	{
		// Token: 0x04001049 RID: 4169
		None,
		// Token: 0x0400104A RID: 4170
		R8_SRGB,
		// Token: 0x0400104B RID: 4171
		R8G8_SRGB,
		// Token: 0x0400104C RID: 4172
		R8G8B8_SRGB,
		// Token: 0x0400104D RID: 4173
		R8G8B8A8_SRGB,
		// Token: 0x0400104E RID: 4174
		R8_UNorm,
		// Token: 0x0400104F RID: 4175
		R8G8_UNorm,
		// Token: 0x04001050 RID: 4176
		R8G8B8_UNorm,
		// Token: 0x04001051 RID: 4177
		R8G8B8A8_UNorm,
		// Token: 0x04001052 RID: 4178
		R8_SNorm,
		// Token: 0x04001053 RID: 4179
		R8G8_SNorm,
		// Token: 0x04001054 RID: 4180
		R8G8B8_SNorm,
		// Token: 0x04001055 RID: 4181
		R8G8B8A8_SNorm,
		// Token: 0x04001056 RID: 4182
		R8_UInt,
		// Token: 0x04001057 RID: 4183
		R8G8_UInt,
		// Token: 0x04001058 RID: 4184
		R8G8B8_UInt,
		// Token: 0x04001059 RID: 4185
		R8G8B8A8_UInt,
		// Token: 0x0400105A RID: 4186
		R8_SInt,
		// Token: 0x0400105B RID: 4187
		R8G8_SInt,
		// Token: 0x0400105C RID: 4188
		R8G8B8_SInt,
		// Token: 0x0400105D RID: 4189
		R8G8B8A8_SInt,
		// Token: 0x0400105E RID: 4190
		R16_UNorm,
		// Token: 0x0400105F RID: 4191
		R16G16_UNorm,
		// Token: 0x04001060 RID: 4192
		R16G16B16_UNorm,
		// Token: 0x04001061 RID: 4193
		R16G16B16A16_UNorm,
		// Token: 0x04001062 RID: 4194
		R16_SNorm,
		// Token: 0x04001063 RID: 4195
		R16G16_SNorm,
		// Token: 0x04001064 RID: 4196
		R16G16B16_SNorm,
		// Token: 0x04001065 RID: 4197
		R16G16B16A16_SNorm,
		// Token: 0x04001066 RID: 4198
		R16_UInt,
		// Token: 0x04001067 RID: 4199
		R16G16_UInt,
		// Token: 0x04001068 RID: 4200
		R16G16B16_UInt,
		// Token: 0x04001069 RID: 4201
		R16G16B16A16_UInt,
		// Token: 0x0400106A RID: 4202
		R16_SInt,
		// Token: 0x0400106B RID: 4203
		R16G16_SInt,
		// Token: 0x0400106C RID: 4204
		R16G16B16_SInt,
		// Token: 0x0400106D RID: 4205
		R16G16B16A16_SInt,
		// Token: 0x0400106E RID: 4206
		R32_UInt,
		// Token: 0x0400106F RID: 4207
		R32G32_UInt,
		// Token: 0x04001070 RID: 4208
		R32G32B32_UInt,
		// Token: 0x04001071 RID: 4209
		R32G32B32A32_UInt,
		// Token: 0x04001072 RID: 4210
		R32_SInt,
		// Token: 0x04001073 RID: 4211
		R32G32_SInt,
		// Token: 0x04001074 RID: 4212
		R32G32B32_SInt,
		// Token: 0x04001075 RID: 4213
		R32G32B32A32_SInt,
		// Token: 0x04001076 RID: 4214
		R16_SFloat,
		// Token: 0x04001077 RID: 4215
		R16G16_SFloat,
		// Token: 0x04001078 RID: 4216
		R16G16B16_SFloat,
		// Token: 0x04001079 RID: 4217
		R16G16B16A16_SFloat,
		// Token: 0x0400107A RID: 4218
		R32_SFloat,
		// Token: 0x0400107B RID: 4219
		R32G32_SFloat,
		// Token: 0x0400107C RID: 4220
		R32G32B32_SFloat,
		// Token: 0x0400107D RID: 4221
		R32G32B32A32_SFloat,
		// Token: 0x0400107E RID: 4222
		B8G8R8_SRGB = 56,
		// Token: 0x0400107F RID: 4223
		B8G8R8A8_SRGB,
		// Token: 0x04001080 RID: 4224
		B8G8R8_UNorm,
		// Token: 0x04001081 RID: 4225
		B8G8R8A8_UNorm,
		// Token: 0x04001082 RID: 4226
		B8G8R8_SNorm,
		// Token: 0x04001083 RID: 4227
		B8G8R8A8_SNorm,
		// Token: 0x04001084 RID: 4228
		B8G8R8_UInt,
		// Token: 0x04001085 RID: 4229
		B8G8R8A8_UInt,
		// Token: 0x04001086 RID: 4230
		B8G8R8_SInt,
		// Token: 0x04001087 RID: 4231
		B8G8R8A8_SInt,
		// Token: 0x04001088 RID: 4232
		R4G4B4A4_UNormPack16,
		// Token: 0x04001089 RID: 4233
		B4G4R4A4_UNormPack16,
		// Token: 0x0400108A RID: 4234
		R5G6B5_UNormPack16,
		// Token: 0x0400108B RID: 4235
		B5G6R5_UNormPack16,
		// Token: 0x0400108C RID: 4236
		R5G5B5A1_UNormPack16,
		// Token: 0x0400108D RID: 4237
		B5G5R5A1_UNormPack16,
		// Token: 0x0400108E RID: 4238
		A1R5G5B5_UNormPack16,
		// Token: 0x0400108F RID: 4239
		E5B9G9R9_UFloatPack32,
		// Token: 0x04001090 RID: 4240
		B10G11R11_UFloatPack32,
		// Token: 0x04001091 RID: 4241
		A2B10G10R10_UNormPack32,
		// Token: 0x04001092 RID: 4242
		A2B10G10R10_UIntPack32,
		// Token: 0x04001093 RID: 4243
		A2B10G10R10_SIntPack32,
		// Token: 0x04001094 RID: 4244
		A2R10G10B10_UNormPack32,
		// Token: 0x04001095 RID: 4245
		A2R10G10B10_UIntPack32,
		// Token: 0x04001096 RID: 4246
		A2R10G10B10_SIntPack32,
		// Token: 0x04001097 RID: 4247
		A2R10G10B10_XRSRGBPack32,
		// Token: 0x04001098 RID: 4248
		A2R10G10B10_XRUNormPack32,
		// Token: 0x04001099 RID: 4249
		R10G10B10_XRSRGBPack32,
		// Token: 0x0400109A RID: 4250
		R10G10B10_XRUNormPack32,
		// Token: 0x0400109B RID: 4251
		A10R10G10B10_XRSRGBPack32,
		// Token: 0x0400109C RID: 4252
		A10R10G10B10_XRUNormPack32,
		// Token: 0x0400109D RID: 4253
		D16_UNorm = 90,
		// Token: 0x0400109E RID: 4254
		D24_UNorm,
		// Token: 0x0400109F RID: 4255
		D24_UNorm_S8_UInt,
		// Token: 0x040010A0 RID: 4256
		D32_SFloat,
		// Token: 0x040010A1 RID: 4257
		D32_SFloat_S8_UInt,
		// Token: 0x040010A2 RID: 4258
		S8_UInt,
		// Token: 0x040010A3 RID: 4259
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Enum member GraphicsFormat.RGB_DXT1_SRGB has been deprecated. Use GraphicsFormat.RGBA_DXT1_SRGB instead (UnityUpgradable) -> RGBA_DXT1_SRGB", true)]
		RGB_DXT1_SRGB,
		// Token: 0x040010A4 RID: 4260
		RGBA_DXT1_SRGB = 96,
		// Token: 0x040010A5 RID: 4261
		[Obsolete("Enum member GraphicsFormat.RGB_DXT1_UNorm has been deprecated. Use GraphicsFormat.RGBA_DXT1_UNorm instead (UnityUpgradable) -> RGBA_DXT1_UNorm", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		RGB_DXT1_UNorm,
		// Token: 0x040010A6 RID: 4262
		RGBA_DXT1_UNorm = 97,
		// Token: 0x040010A7 RID: 4263
		RGBA_DXT3_SRGB,
		// Token: 0x040010A8 RID: 4264
		RGBA_DXT3_UNorm,
		// Token: 0x040010A9 RID: 4265
		RGBA_DXT5_SRGB,
		// Token: 0x040010AA RID: 4266
		RGBA_DXT5_UNorm,
		// Token: 0x040010AB RID: 4267
		R_BC4_UNorm,
		// Token: 0x040010AC RID: 4268
		R_BC4_SNorm,
		// Token: 0x040010AD RID: 4269
		RG_BC5_UNorm,
		// Token: 0x040010AE RID: 4270
		RG_BC5_SNorm,
		// Token: 0x040010AF RID: 4271
		RGB_BC6H_UFloat,
		// Token: 0x040010B0 RID: 4272
		RGB_BC6H_SFloat,
		// Token: 0x040010B1 RID: 4273
		RGBA_BC7_SRGB,
		// Token: 0x040010B2 RID: 4274
		RGBA_BC7_UNorm,
		// Token: 0x040010B3 RID: 4275
		RGB_PVRTC_2Bpp_SRGB,
		// Token: 0x040010B4 RID: 4276
		RGB_PVRTC_2Bpp_UNorm,
		// Token: 0x040010B5 RID: 4277
		RGB_PVRTC_4Bpp_SRGB,
		// Token: 0x040010B6 RID: 4278
		RGB_PVRTC_4Bpp_UNorm,
		// Token: 0x040010B7 RID: 4279
		RGBA_PVRTC_2Bpp_SRGB,
		// Token: 0x040010B8 RID: 4280
		RGBA_PVRTC_2Bpp_UNorm,
		// Token: 0x040010B9 RID: 4281
		RGBA_PVRTC_4Bpp_SRGB,
		// Token: 0x040010BA RID: 4282
		RGBA_PVRTC_4Bpp_UNorm,
		// Token: 0x040010BB RID: 4283
		RGB_ETC_UNorm,
		// Token: 0x040010BC RID: 4284
		RGB_ETC2_SRGB,
		// Token: 0x040010BD RID: 4285
		RGB_ETC2_UNorm,
		// Token: 0x040010BE RID: 4286
		RGB_A1_ETC2_SRGB,
		// Token: 0x040010BF RID: 4287
		RGB_A1_ETC2_UNorm,
		// Token: 0x040010C0 RID: 4288
		RGBA_ETC2_SRGB,
		// Token: 0x040010C1 RID: 4289
		RGBA_ETC2_UNorm,
		// Token: 0x040010C2 RID: 4290
		R_EAC_UNorm,
		// Token: 0x040010C3 RID: 4291
		R_EAC_SNorm,
		// Token: 0x040010C4 RID: 4292
		RG_EAC_UNorm,
		// Token: 0x040010C5 RID: 4293
		RG_EAC_SNorm,
		// Token: 0x040010C6 RID: 4294
		RGBA_ASTC4X4_SRGB,
		// Token: 0x040010C7 RID: 4295
		RGBA_ASTC4X4_UNorm,
		// Token: 0x040010C8 RID: 4296
		RGBA_ASTC5X5_SRGB,
		// Token: 0x040010C9 RID: 4297
		RGBA_ASTC5X5_UNorm,
		// Token: 0x040010CA RID: 4298
		RGBA_ASTC6X6_SRGB,
		// Token: 0x040010CB RID: 4299
		RGBA_ASTC6X6_UNorm,
		// Token: 0x040010CC RID: 4300
		RGBA_ASTC8X8_SRGB,
		// Token: 0x040010CD RID: 4301
		RGBA_ASTC8X8_UNorm,
		// Token: 0x040010CE RID: 4302
		RGBA_ASTC10X10_SRGB,
		// Token: 0x040010CF RID: 4303
		RGBA_ASTC10X10_UNorm,
		// Token: 0x040010D0 RID: 4304
		RGBA_ASTC12X12_SRGB,
		// Token: 0x040010D1 RID: 4305
		RGBA_ASTC12X12_UNorm,
		// Token: 0x040010D2 RID: 4306
		YUV2,
		// Token: 0x040010D3 RID: 4307
		[Obsolete("Enum member GraphicsFormat.DepthAuto has been deprecated. Use GraphicsFormat.None as a color format to indicate depth only rendering and DefaultFormat to get the default depth buffer format.", false)]
		DepthAuto,
		// Token: 0x040010D4 RID: 4308
		[Obsolete("Enum member GraphicsFormat.ShadowAuto has been deprecated. Use GraphicsFormat.None as a color format to indicate depth only rendering and DefaultFormat to get the default shadow buffer format.", false)]
		ShadowAuto,
		// Token: 0x040010D5 RID: 4309
		[Obsolete("Enum member GraphicsFormat.VideoAuto has been deprecated. Use DefaultFormat instead.", false)]
		VideoAuto,
		// Token: 0x040010D6 RID: 4310
		RGBA_ASTC4X4_UFloat,
		// Token: 0x040010D7 RID: 4311
		RGBA_ASTC5X5_UFloat,
		// Token: 0x040010D8 RID: 4312
		RGBA_ASTC6X6_UFloat,
		// Token: 0x040010D9 RID: 4313
		RGBA_ASTC8X8_UFloat,
		// Token: 0x040010DA RID: 4314
		RGBA_ASTC10X10_UFloat,
		// Token: 0x040010DB RID: 4315
		RGBA_ASTC12X12_UFloat,
		// Token: 0x040010DC RID: 4316
		D16_UNorm_S8_UInt
	}
}
