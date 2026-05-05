using System;
using UnityEngine.Serialization;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000030 RID: 48
	[AddComponentMenu("VFX/Property Binders/Light Binder")]
	[VFXBinder("Utility/Light")]
	internal class VFXLightBinder : VFXBinderBase
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000123 RID: 291 RVA: 0x00007DA2 File Offset: 0x00005FA2
		// (set) Token: 0x06000124 RID: 292 RVA: 0x00007DAF File Offset: 0x00005FAF
		public string ColorProperty
		{
			get
			{
				return (string)this.m_ColorProperty;
			}
			set
			{
				this.m_ColorProperty = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00007DBD File Offset: 0x00005FBD
		// (set) Token: 0x06000126 RID: 294 RVA: 0x00007DCA File Offset: 0x00005FCA
		public string BrightnessProperty
		{
			get
			{
				return (string)this.m_BrightnessProperty;
			}
			set
			{
				this.m_ColorProperty = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00007DD8 File Offset: 0x00005FD8
		// (set) Token: 0x06000128 RID: 296 RVA: 0x00007DE5 File Offset: 0x00005FE5
		public string RadiusProperty
		{
			get
			{
				return (string)this.m_RadiusProperty;
			}
			set
			{
				this.m_RadiusProperty = value;
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00007DF4 File Offset: 0x00005FF4
		public override bool IsValid(VisualEffect component)
		{
			return this.Target != null && (!this.BindColor || component.HasVector4(this.ColorProperty)) && (!this.BindBrightness || component.HasFloat(this.BrightnessProperty)) && (!this.BindRadius || component.HasFloat(this.RadiusProperty));
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00007E54 File Offset: 0x00006054
		public override void UpdateBinding(VisualEffect component)
		{
			if (this.BindColor)
			{
				component.SetVector4(this.ColorProperty, this.Target.color);
			}
			if (this.BindBrightness)
			{
				component.SetFloat(this.BrightnessProperty, this.Target.intensity);
			}
			if (this.BindRadius)
			{
				component.SetFloat(this.RadiusProperty, this.Target.range);
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00007EC3 File Offset: 0x000060C3
		public override string ToString()
		{
			return string.Format("Light : '{0}' -> {1}", this.m_ColorProperty, (this.Target == null) ? "(null)" : this.Target.name);
		}

		// Token: 0x040000D3 RID: 211
		[VFXPropertyBinding(new string[]
		{
			"UnityEngine.Color"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_ColorParameter")]
		protected ExposedProperty m_ColorProperty = "Color";

		// Token: 0x040000D4 RID: 212
		[VFXPropertyBinding(new string[]
		{
			"System.Single"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_BrightnessParameter")]
		protected ExposedProperty m_BrightnessProperty = "Brightness";

		// Token: 0x040000D5 RID: 213
		[VFXPropertyBinding(new string[]
		{
			"System.Single"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_RadiusParameter")]
		protected ExposedProperty m_RadiusProperty = "Radius";

		// Token: 0x040000D6 RID: 214
		public Light Target;

		// Token: 0x040000D7 RID: 215
		public bool BindColor = true;

		// Token: 0x040000D8 RID: 216
		public bool BindBrightness;

		// Token: 0x040000D9 RID: 217
		public bool BindRadius;
	}
}
