using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Invector
{
	// Token: 0x0200039A RID: 922
	[vClassHeader("Skybox Fade", true, "icon_v2", false, "", helpBoxText = "A Skybox with Cubemap type is Required to use this Component", useHelpBox = true)]
	public class vSkyboxFade : vMonoBehaviour
	{
		// Token: 0x06001291 RID: 4753 RVA: 0x000620D4 File Offset: 0x000602D4
		private void Start()
		{
			this.skybox = RenderSettings.skybox;
			this.lastFadeSettings = new vSkyboxFade.SkyboxFadeSettings();
			this.currentFadeSettings = this.defaultSkyboxSettings.Copy();
			this.currentFadeSettings = new vSkyboxFade.SkyboxFadeSettings(this.skybox);
			this.skybox.SetColor("_Tint", this.defaultSkyboxSettings.tint);
			this.skybox.SetFloat("_Exposure", this.defaultSkyboxSettings.exposure);
			this.skybox.SetFloat("_Rotation", this.defaultSkyboxSettings.rotation);
		}

		// Token: 0x06001292 RID: 4754 RVA: 0x0006216C File Offset: 0x0006036C
		private void OnApplicationQuit()
		{
			this.skybox.SetColor("_Tint", this.defaultSkyboxSettings.tint);
			this.skybox.SetFloat("_Exposure", this.defaultSkyboxSettings.exposure);
			this.skybox.SetFloat("_Rotation", this.defaultSkyboxSettings.rotation);
		}

		// Token: 0x06001293 RID: 4755 RVA: 0x000621CC File Offset: 0x000603CC
		public void Fade(string _fadeName)
		{
			this.targetFadeSettings = this.fadeSettings.Find((vSkyboxFade.SkyboxFadeSettings f) => f.name.Equals(_fadeName));
			if (this.targetFadeSettings != null)
			{
				this.exitRoutine = true;
				base.StartCoroutine(this.FadeRoutine());
			}
		}

		// Token: 0x06001294 RID: 4756 RVA: 0x0006221F File Offset: 0x0006041F
		public void FadeToDefault()
		{
			this.targetFadeSettings = this.defaultSkyboxSettings.Copy();
			this.exitRoutine = true;
			base.StartCoroutine(this.FadeRoutine());
		}

		// Token: 0x06001295 RID: 4757 RVA: 0x00062246 File Offset: 0x00060446
		private IEnumerator FadeRoutine()
		{
			yield return new WaitForEndOfFrame();
			this.exitRoutine = false;
			this.lastFadeSettings.tint = this.currentFadeSettings.tint;
			this.lastFadeSettings.exposure = this.currentFadeSettings.exposure;
			this.lastFadeSettings.rotation = this.currentFadeSettings.rotation;
			float timer = 0f;
			if (!(this.lastFadeSettings.tint == this.targetFadeSettings.tint) || this.lastFadeSettings.exposure != this.targetFadeSettings.exposure || this.targetFadeSettings.rotation != this.lastFadeSettings.rotation)
			{
				do
				{
					this.currentFadeSettings.tint = Color.Lerp(this.lastFadeSettings.tint, this.targetFadeSettings.tint, this.targetFadeSettings.curve.Evaluate(timer));
					this.currentFadeSettings.exposure = Mathf.Lerp(this.lastFadeSettings.exposure, this.targetFadeSettings.exposure, this.targetFadeSettings.curve.Evaluate(timer));
					this.currentFadeSettings.rotation = Mathf.Lerp(this.lastFadeSettings.rotation, this.targetFadeSettings.rotation, this.targetFadeSettings.curve.Evaluate(timer));
					this.skybox.SetColor("_Tint", this.currentFadeSettings.tint);
					this.skybox.SetFloat("_Exposure", this.currentFadeSettings.exposure);
					this.skybox.SetFloat("_Rotation", this.currentFadeSettings.rotation);
					yield return null;
					if (timer >= 1f)
					{
						break;
					}
					timer += Time.fixedDeltaTime / this.targetFadeSettings.fadeTime;
				}
				while (!this.exitRoutine);
			}
			yield break;
		}

		// Token: 0x0400184E RID: 6222
		public vSkyboxFade.SkyboxFadeSettings defaultSkyboxSettings;

		// Token: 0x0400184F RID: 6223
		public List<vSkyboxFade.SkyboxFadeSettings> fadeSettings;

		// Token: 0x04001850 RID: 6224
		private vSkyboxFade.SkyboxFadeSettings currentFadeSettings;

		// Token: 0x04001851 RID: 6225
		private vSkyboxFade.SkyboxFadeSettings lastFadeSettings;

		// Token: 0x04001852 RID: 6226
		private vSkyboxFade.SkyboxFadeSettings targetFadeSettings;

		// Token: 0x04001853 RID: 6227
		private Material skybox;

		// Token: 0x04001854 RID: 6228
		private bool exitRoutine;

		// Token: 0x0200039B RID: 923
		[Serializable]
		public class SkyboxFadeSettings
		{
			// Token: 0x06001297 RID: 4759 RVA: 0x00062258 File Offset: 0x00060458
			public SkyboxFadeSettings()
			{
			}

			// Token: 0x06001298 RID: 4760 RVA: 0x000622CC File Offset: 0x000604CC
			public SkyboxFadeSettings(Material mat)
			{
				this.tint = mat.GetColor("_Tint");
				this.exposure = mat.GetFloat("_Exposure");
				this.rotation = mat.GetFloat("_Rotation");
			}

			// Token: 0x06001299 RID: 4761 RVA: 0x00062371 File Offset: 0x00060571
			public void CopyMaterial(Material mat)
			{
				this.tint = mat.GetColor("_Tint");
				this.exposure = mat.GetFloat("_Exposure");
				this.rotation = mat.GetFloat("_Rotation");
			}

			// Token: 0x0600129A RID: 4762 RVA: 0x000623A8 File Offset: 0x000605A8
			public vSkyboxFade.SkyboxFadeSettings Copy()
			{
				return new vSkyboxFade.SkyboxFadeSettings
				{
					curve = this.curve,
					fadeTime = this.fadeTime,
					tint = this.tint,
					exposure = this.exposure,
					rotation = this.rotation
				};
			}

			// Token: 0x04001855 RID: 6229
			public string name = "My SkySettings";

			// Token: 0x04001856 RID: 6230
			public AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

			// Token: 0x04001857 RID: 6231
			public float fadeTime = 1f;

			// Token: 0x04001858 RID: 6232
			public Color tint = new Color(0.5f, 0.5f, 0.5f, 0.5f);

			// Token: 0x04001859 RID: 6233
			[Range(0f, 8f)]
			public float exposure = 1f;

			// Token: 0x0400185A RID: 6234
			[Range(0f, 360f)]
			public float rotation;
		}
	}
}
