using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x02000010 RID: 16
	[ExecuteInEditMode]
	public class BlurredBackgroundPassHDRPVolume : MonoBehaviour
	{
		// Token: 0x0600008C RID: 140 RVA: 0x00004000 File Offset: 0x00002200
		public static BlurredBackgroundPassHDRPVolume FindOrCreate(CustomPassInjectionPoint injectionPoint, Camera camera = null)
		{
			foreach (BlurredBackgroundPassHDRPVolume blurredBackgroundPassHDRPVolume in Utils.FindRootObjectsByType<BlurredBackgroundPassHDRPVolume>(false))
			{
				if (blurredBackgroundPassHDRPVolume.InjectionPoint == injectionPoint)
				{
					return blurredBackgroundPassHDRPVolume;
				}
			}
			GameObject gameObject = new GameObject("UGUI BlurredBackground Custom Pass Volume (" + injectionPoint.ToString() + ")");
			gameObject.hideFlags = (HideFlags.DontSaveInEditor | HideFlags.NotEditable | HideFlags.DontSaveInBuild | HideFlags.DontUnloadUnusedAsset);
			Utils.SmartDontDestroyOnLoad(gameObject);
			CustomPassVolume customPassVolume = gameObject.AddComponent<CustomPassVolume>();
			customPassVolume.hideFlags = (HideFlags.DontSaveInEditor | HideFlags.NotEditable | HideFlags.DontSaveInBuild | HideFlags.DontUnloadUnusedAsset);
			customPassVolume.injectionPoint = injectionPoint;
			customPassVolume.priority = 0f;
			if (camera != null)
			{
				customPassVolume.isGlobal = false;
				customPassVolume.targetCamera = camera;
			}
			else
			{
				customPassVolume.isGlobal = true;
			}
			BlurredBackgroundPassHDRPVolume blurredBackgroundPassHDRPVolume2 = gameObject.AddComponent<BlurredBackgroundPassHDRPVolume>();
			blurredBackgroundPassHDRPVolume2.hideFlags = (HideFlags.DontSaveInEditor | HideFlags.NotEditable | HideFlags.DontSaveInBuild | HideFlags.DontUnloadUnusedAsset);
			blurredBackgroundPassHDRPVolume2.InjectionPoint = injectionPoint;
			blurredBackgroundPassHDRPVolume2.Volume = customPassVolume;
			return blurredBackgroundPassHDRPVolume2;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000040EC File Offset: 0x000022EC
		public BlurredBackgroundPassHDRP GetPass()
		{
			return this._pass;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000040F4 File Offset: 0x000022F4
		public BlurredBackgroundPassHDRP GetOrCreatePass(ShaderQuality quality, Vector2Int resolution, float offset, int iterations, Color additiveColor)
		{
			if (this._pass == null && this.Volume != null)
			{
				CustomPass customPass = this.Volume.AddPassOfType<BlurredBackgroundPassHDRP>();
				customPass.enabled = true;
				customPass.targetColorBuffer = CustomPass.TargetBuffer.Camera;
				customPass.targetDepthBuffer = CustomPass.TargetBuffer.Camera;
				customPass.clearFlags = ClearFlag.None;
				this._pass = (customPass as BlurredBackgroundPassHDRP);
				this._pass.Quality = quality;
				this._pass.Resolution = resolution;
				this._pass.Offset = offset;
				this._pass.Iterations = iterations;
				this._pass.AdditiveColor = additiveColor;
			}
			return this._pass;
		}

		// Token: 0x04000050 RID: 80
		public CustomPassVolume Volume;

		// Token: 0x04000051 RID: 81
		public CustomPassInjectionPoint InjectionPoint;

		// Token: 0x04000052 RID: 82
		protected BlurredBackgroundPassHDRP _pass;

		// Token: 0x04000053 RID: 83
		protected const HideFlags _hideFlags = HideFlags.DontSaveInEditor | HideFlags.NotEditable | HideFlags.DontSaveInBuild | HideFlags.DontUnloadUnusedAsset;
	}
}
