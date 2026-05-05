using System;
using UnityEngine.Serialization;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x0200002C RID: 44
	[AddComponentMenu("VFX/Property Binders/Input Button Binder")]
	[VFXBinder("Input/Button")]
	internal class VFXInputButtonBinder : VFXBinderBase
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x000075B9 File Offset: 0x000057B9
		// (set) Token: 0x060000F7 RID: 247 RVA: 0x000075C6 File Offset: 0x000057C6
		public string ButtonProperty
		{
			get
			{
				return (string)this.m_ButtonProperty;
			}
			set
			{
				this.m_ButtonProperty = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x000075D4 File Offset: 0x000057D4
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x000075E1 File Offset: 0x000057E1
		public string ButtonSmoothProperty
		{
			get
			{
				return (string)this.m_ButtonSmoothProperty;
			}
			set
			{
				this.m_ButtonSmoothProperty = value;
			}
		}

		// Token: 0x060000FA RID: 250 RVA: 0x000075EF File Offset: 0x000057EF
		public override bool IsValid(VisualEffect component)
		{
			return component.HasBool(this.m_ButtonProperty) && (!this.UseButtonSmooth || component.HasFloat(this.m_ButtonSmoothProperty));
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00007621 File Offset: 0x00005821
		private void Start()
		{
			if (this.UseButtonSmooth)
			{
				this.m_CachedSmoothValue = (Input.GetButton(this.ButtonName) ? 1f : 0f);
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000764C File Offset: 0x0000584C
		public override void UpdateBinding(VisualEffect component)
		{
			bool button = Input.GetButton(this.ButtonName);
			component.SetBool(this.m_ButtonProperty, button);
			if (this.UseButtonSmooth)
			{
				this.m_CachedSmoothValue += this.SmoothSpeed * Time.deltaTime * (button ? 1f : -1f);
				this.m_CachedSmoothValue = Mathf.Clamp01(this.m_CachedSmoothValue);
				component.SetFloat(this.m_ButtonSmoothProperty, this.m_CachedSmoothValue);
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000076D0 File Offset: 0x000058D0
		public override string ToString()
		{
			return string.Format("Input Button: '{0}' -> {1}", this.m_ButtonSmoothProperty, this.ButtonName.ToString());
		}

		// Token: 0x040000B4 RID: 180
		[VFXPropertyBinding(new string[]
		{
			"System.Boolean"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_ButtonParameter")]
		protected ExposedProperty m_ButtonProperty = "ButtonDown";

		// Token: 0x040000B5 RID: 181
		[VFXPropertyBinding(new string[]
		{
			"System.Single"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_ButtonSmoothParameter")]
		protected ExposedProperty m_ButtonSmoothProperty = "KeySmooth";

		// Token: 0x040000B6 RID: 182
		public string ButtonName = "Action";

		// Token: 0x040000B7 RID: 183
		public float SmoothSpeed = 2f;

		// Token: 0x040000B8 RID: 184
		public bool UseButtonSmooth = true;

		// Token: 0x040000B9 RID: 185
		private float m_CachedSmoothValue;
	}
}
