using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Rendering;

namespace UnityEngine
{
	// Token: 0x02000167 RID: 359
	[StaticAccessor("GetRenderSettings()", StaticAccessorType.Dot)]
	[NativeHeader("Runtime/Graphics/QualitySettingsTypes.h")]
	[NativeHeader("Runtime/Camera/RenderSettings.h")]
	public sealed class RenderSettings : Object
	{
		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000D2D RID: 3373 RVA: 0x00013338 File Offset: 0x00011538
		// (set) Token: 0x06000D2E RID: 3374 RVA: 0x0001334F File Offset: 0x0001154F
		[Obsolete("Use RenderSettings.ambientIntensity instead (UnityUpgradable) -> ambientIntensity", false)]
		public static float ambientSkyboxAmount
		{
			get
			{
				return RenderSettings.ambientIntensity;
			}
			set
			{
				RenderSettings.ambientIntensity = value;
			}
		}

		// Token: 0x06000D2F RID: 3375 RVA: 0x0001117A File Offset: 0x0000F37A
		private RenderSettings()
		{
		}

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000D30 RID: 3376
		// (set) Token: 0x06000D31 RID: 3377
		[NativeProperty("UseFog")]
		public static extern bool fog { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06000D32 RID: 3378
		// (set) Token: 0x06000D33 RID: 3379
		[NativeProperty("LinearFogStart")]
		public static extern float fogStartDistance { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06000D34 RID: 3380
		// (set) Token: 0x06000D35 RID: 3381
		[NativeProperty("LinearFogEnd")]
		public static extern float fogEndDistance { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06000D36 RID: 3382
		// (set) Token: 0x06000D37 RID: 3383
		public static extern FogMode fogMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06000D38 RID: 3384 RVA: 0x0001335C File Offset: 0x0001155C
		// (set) Token: 0x06000D39 RID: 3385 RVA: 0x00013371 File Offset: 0x00011571
		public static Color fogColor
		{
			get
			{
				Color result;
				RenderSettings.get_fogColor_Injected(out result);
				return result;
			}
			set
			{
				RenderSettings.set_fogColor_Injected(ref value);
			}
		}

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06000D3A RID: 3386
		// (set) Token: 0x06000D3B RID: 3387
		public static extern float fogDensity { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x06000D3C RID: 3388
		// (set) Token: 0x06000D3D RID: 3389
		public static extern AmbientMode ambientMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x06000D3E RID: 3390 RVA: 0x0001337C File Offset: 0x0001157C
		// (set) Token: 0x06000D3F RID: 3391 RVA: 0x00013391 File Offset: 0x00011591
		public static Color ambientSkyColor
		{
			get
			{
				Color result;
				RenderSettings.get_ambientSkyColor_Injected(out result);
				return result;
			}
			set
			{
				RenderSettings.set_ambientSkyColor_Injected(ref value);
			}
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x06000D40 RID: 3392 RVA: 0x0001339C File Offset: 0x0001159C
		// (set) Token: 0x06000D41 RID: 3393 RVA: 0x000133B1 File Offset: 0x000115B1
		public static Color ambientEquatorColor
		{
			get
			{
				Color result;
				RenderSettings.get_ambientEquatorColor_Injected(out result);
				return result;
			}
			set
			{
				RenderSettings.set_ambientEquatorColor_Injected(ref value);
			}
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06000D42 RID: 3394 RVA: 0x000133BC File Offset: 0x000115BC
		// (set) Token: 0x06000D43 RID: 3395 RVA: 0x000133D1 File Offset: 0x000115D1
		public static Color ambientGroundColor
		{
			get
			{
				Color result;
				RenderSettings.get_ambientGroundColor_Injected(out result);
				return result;
			}
			set
			{
				RenderSettings.set_ambientGroundColor_Injected(ref value);
			}
		}

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x06000D44 RID: 3396
		// (set) Token: 0x06000D45 RID: 3397
		public static extern float ambientIntensity { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x06000D46 RID: 3398 RVA: 0x000133DC File Offset: 0x000115DC
		// (set) Token: 0x06000D47 RID: 3399 RVA: 0x000133F1 File Offset: 0x000115F1
		[NativeProperty("AmbientSkyColor")]
		public static Color ambientLight
		{
			get
			{
				Color result;
				RenderSettings.get_ambientLight_Injected(out result);
				return result;
			}
			set
			{
				RenderSettings.set_ambientLight_Injected(ref value);
			}
		}

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x06000D48 RID: 3400 RVA: 0x000133FC File Offset: 0x000115FC
		// (set) Token: 0x06000D49 RID: 3401 RVA: 0x00013411 File Offset: 0x00011611
		public static Color subtractiveShadowColor
		{
			get
			{
				Color result;
				RenderSettings.get_subtractiveShadowColor_Injected(out result);
				return result;
			}
			set
			{
				RenderSettings.set_subtractiveShadowColor_Injected(ref value);
			}
		}

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000D4A RID: 3402
		// (set) Token: 0x06000D4B RID: 3403
		[NativeProperty("SkyboxMaterial")]
		public static extern Material skybox { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06000D4C RID: 3404
		// (set) Token: 0x06000D4D RID: 3405
		public static extern Light sun { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x06000D4E RID: 3406 RVA: 0x0001341C File Offset: 0x0001161C
		// (set) Token: 0x06000D4F RID: 3407 RVA: 0x00013431 File Offset: 0x00011631
		public static SphericalHarmonicsL2 ambientProbe
		{
			[NativeMethod("GetFinalAmbientProbe")]
			get
			{
				SphericalHarmonicsL2 result;
				RenderSettings.get_ambientProbe_Injected(out result);
				return result;
			}
			set
			{
				RenderSettings.set_ambientProbe_Injected(ref value);
			}
		}

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x06000D50 RID: 3408 RVA: 0x0001343C File Offset: 0x0001163C
		// (set) Token: 0x06000D51 RID: 3409 RVA: 0x00013471 File Offset: 0x00011671
		[Obsolete("RenderSettings.customReflection has been deprecated in favor of RenderSettings.customReflectionTexture.", false)]
		public static Cubemap customReflection
		{
			get
			{
				Cubemap cubemap = RenderSettings.customReflectionTexture as Cubemap;
				bool flag = cubemap == null;
				if (flag)
				{
					throw new ArgumentException("RenderSettings.customReflection is currently not referencing a cubemap.");
				}
				return cubemap;
			}
			[NativeThrows]
			set
			{
				RenderSettings.customReflectionTexture = value;
			}
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x06000D52 RID: 3410
		// (set) Token: 0x06000D53 RID: 3411
		[NativeProperty("CustomReflection")]
		public static extern Texture customReflectionTexture { [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeThrows] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x06000D54 RID: 3412
		// (set) Token: 0x06000D55 RID: 3413
		public static extern float reflectionIntensity { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x06000D56 RID: 3414
		// (set) Token: 0x06000D57 RID: 3415
		public static extern int reflectionBounces { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x06000D58 RID: 3416
		[NativeProperty("GeneratedSkyboxReflection")]
		internal static extern Cubemap defaultReflection { [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x06000D59 RID: 3417
		// (set) Token: 0x06000D5A RID: 3418
		public static extern DefaultReflectionMode defaultReflectionMode { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x06000D5B RID: 3419
		// (set) Token: 0x06000D5C RID: 3420
		public static extern int defaultReflectionResolution { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x06000D5D RID: 3421
		// (set) Token: 0x06000D5E RID: 3422
		public static extern float haloStrength { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x06000D5F RID: 3423
		// (set) Token: 0x06000D60 RID: 3424
		public static extern float flareStrength { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x06000D61 RID: 3425
		// (set) Token: 0x06000D62 RID: 3426
		public static extern float flareFadeSpeed { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06000D63 RID: 3427
		[FreeFunction("GetRenderSettings")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Object GetRenderSettings();

		// Token: 0x06000D64 RID: 3428
		[StaticAccessor("RenderSettingsScripting", StaticAccessorType.DoubleColon)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Reset();

		// Token: 0x06000D65 RID: 3429
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_fogColor_Injected(out Color ret);

		// Token: 0x06000D66 RID: 3430
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_fogColor_Injected(ref Color value);

		// Token: 0x06000D67 RID: 3431
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_ambientSkyColor_Injected(out Color ret);

		// Token: 0x06000D68 RID: 3432
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_ambientSkyColor_Injected(ref Color value);

		// Token: 0x06000D69 RID: 3433
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_ambientEquatorColor_Injected(out Color ret);

		// Token: 0x06000D6A RID: 3434
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_ambientEquatorColor_Injected(ref Color value);

		// Token: 0x06000D6B RID: 3435
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_ambientGroundColor_Injected(out Color ret);

		// Token: 0x06000D6C RID: 3436
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_ambientGroundColor_Injected(ref Color value);

		// Token: 0x06000D6D RID: 3437
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_ambientLight_Injected(out Color ret);

		// Token: 0x06000D6E RID: 3438
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_ambientLight_Injected(ref Color value);

		// Token: 0x06000D6F RID: 3439
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_subtractiveShadowColor_Injected(out Color ret);

		// Token: 0x06000D70 RID: 3440
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_subtractiveShadowColor_Injected(ref Color value);

		// Token: 0x06000D71 RID: 3441
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_ambientProbe_Injected(out SphericalHarmonicsL2 ret);

		// Token: 0x06000D72 RID: 3442
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_ambientProbe_Injected(ref SphericalHarmonicsL2 value);
	}
}
