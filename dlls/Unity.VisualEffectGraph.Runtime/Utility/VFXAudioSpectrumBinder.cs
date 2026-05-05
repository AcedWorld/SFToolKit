using System;
using UnityEngine.Serialization;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000028 RID: 40
	[AddComponentMenu("VFX/Property Binders/Audio Spectrum Binder")]
	[VFXBinder("Audio/Audio Spectrum to AttributeMap")]
	internal class VFXAudioSpectrumBinder : VFXBinderBase
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00006DD6 File Offset: 0x00004FD6
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x00006DE3 File Offset: 0x00004FE3
		public string CountProperty
		{
			get
			{
				return (string)this.m_CountProperty;
			}
			set
			{
				this.m_CountProperty = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00006DF1 File Offset: 0x00004FF1
		// (set) Token: 0x060000DB RID: 219 RVA: 0x00006DFE File Offset: 0x00004FFE
		public string TextureProperty
		{
			get
			{
				return (string)this.m_TextureProperty;
			}
			set
			{
				this.m_TextureProperty = value;
			}
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00006E0C File Offset: 0x0000500C
		public override bool IsValid(VisualEffect component)
		{
			bool flag = this.Mode != VFXAudioSpectrumBinder.AudioSourceMode.AudioSource || this.AudioSource != null;
			bool flag2 = component.HasTexture(this.TextureProperty);
			bool flag3 = component.HasUInt(this.CountProperty);
			return flag && flag2 && flag3;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00006E50 File Offset: 0x00005050
		private void UpdateTexture()
		{
			if (this.m_Texture == null || (long)this.m_Texture.width != (long)((ulong)this.Samples))
			{
				this.m_Texture = new Texture2D((int)this.Samples, 1, TextureFormat.RFloat, false);
				this.m_AudioCache = new float[this.Samples];
				this.m_ColorCache = new Color[this.Samples];
			}
			if (this.Mode == VFXAudioSpectrumBinder.AudioSourceMode.AudioListener)
			{
				AudioListener.GetSpectrumData(this.m_AudioCache, 0, this.FFTWindow);
			}
			else
			{
				if (this.Mode != VFXAudioSpectrumBinder.AudioSourceMode.AudioSource)
				{
					throw new NotImplementedException();
				}
				this.AudioSource.GetSpectrumData(this.m_AudioCache, 0, this.FFTWindow);
			}
			int num = 0;
			while ((long)num < (long)((ulong)this.Samples))
			{
				this.m_ColorCache[num] = new Color(this.m_AudioCache[num], 0f, 0f, 0f);
				num++;
			}
			this.m_Texture.SetPixels(this.m_ColorCache);
			this.m_Texture.name = "AudioSpectrum" + this.Samples.ToString();
			this.m_Texture.Apply();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00006F73 File Offset: 0x00005173
		public override void UpdateBinding(VisualEffect component)
		{
			this.UpdateTexture();
			component.SetTexture(this.TextureProperty, this.m_Texture);
			component.SetUInt(this.CountProperty, this.Samples);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00006F9F File Offset: 0x0000519F
		public override string ToString()
		{
			return string.Format("Audio Spectrum : '{0} samples' -> {1}", this.m_CountProperty, (this.Mode == VFXAudioSpectrumBinder.AudioSourceMode.AudioSource) ? "AudioSource" : "AudioListener");
		}

		// Token: 0x04000098 RID: 152
		[VFXPropertyBinding(new string[]
		{
			"System.UInt32"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_CountParameter")]
		protected ExposedProperty m_CountProperty = "Count";

		// Token: 0x04000099 RID: 153
		[VFXPropertyBinding(new string[]
		{
			"UnityEngine.Texture2D"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_TextureParameter")]
		protected ExposedProperty m_TextureProperty = "SpectrumTexture";

		// Token: 0x0400009A RID: 154
		public FFTWindow FFTWindow = FFTWindow.BlackmanHarris;

		// Token: 0x0400009B RID: 155
		public uint Samples = 64U;

		// Token: 0x0400009C RID: 156
		public VFXAudioSpectrumBinder.AudioSourceMode Mode;

		// Token: 0x0400009D RID: 157
		public AudioSource AudioSource;

		// Token: 0x0400009E RID: 158
		private Texture2D m_Texture;

		// Token: 0x0400009F RID: 159
		private float[] m_AudioCache;

		// Token: 0x040000A0 RID: 160
		private Color[] m_ColorCache;

		// Token: 0x02000063 RID: 99
		public enum AudioSourceMode
		{
			// Token: 0x040001E3 RID: 483
			AudioSource,
			// Token: 0x040001E4 RID: 484
			AudioListener
		}
	}
}
