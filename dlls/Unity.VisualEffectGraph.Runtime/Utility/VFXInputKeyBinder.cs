using System;
using UnityEngine.Serialization;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x0200002D RID: 45
	[AddComponentMenu("VFX/Property Binders/Input Key Press Binder")]
	[VFXBinder("Input/Key")]
	internal class VFXInputKeyBinder : VFXBinderBase
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00007740 File Offset: 0x00005940
		// (set) Token: 0x06000100 RID: 256 RVA: 0x0000774D File Offset: 0x0000594D
		public string KeyProperty
		{
			get
			{
				return (string)this.m_KeyProperty;
			}
			set
			{
				this.m_KeyProperty = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000101 RID: 257 RVA: 0x0000775B File Offset: 0x0000595B
		// (set) Token: 0x06000102 RID: 258 RVA: 0x00007768 File Offset: 0x00005968
		public string KeySmoothProperty
		{
			get
			{
				return (string)this.m_KeySmoothProperty;
			}
			set
			{
				this.m_KeySmoothProperty = value;
			}
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00007776 File Offset: 0x00005976
		public override bool IsValid(VisualEffect component)
		{
			return component.HasBool(this.m_KeyProperty) && (!this.UseKeySmooth || component.HasFloat(this.m_KeySmoothProperty));
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000077A8 File Offset: 0x000059A8
		private void Start()
		{
			if (this.UseKeySmooth)
			{
				this.m_CachedSmoothValue = (Input.GetKeyDown(this.Key) ? 1f : 0f);
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000077D4 File Offset: 0x000059D4
		public override void UpdateBinding(VisualEffect component)
		{
			bool key = Input.GetKey(this.Key);
			component.SetBool(this.m_KeyProperty, key);
			if (this.UseKeySmooth)
			{
				this.m_CachedSmoothValue += this.SmoothSpeed * Time.deltaTime * (key ? 1f : -1f);
				this.m_CachedSmoothValue = Mathf.Clamp01(this.m_CachedSmoothValue);
				component.SetFloat(this.m_KeySmoothProperty, this.m_CachedSmoothValue);
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00007858 File Offset: 0x00005A58
		public override string ToString()
		{
			return string.Format("Key: '{0}' -> {1}", this.m_KeySmoothProperty, this.Key.ToString());
		}

		// Token: 0x040000BA RID: 186
		[VFXPropertyBinding(new string[]
		{
			"System.Boolean"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_KeyParameter")]
		protected ExposedProperty m_KeyProperty = "KeyDown";

		// Token: 0x040000BB RID: 187
		[VFXPropertyBinding(new string[]
		{
			"System.Single"
		})]
		[SerializeField]
		[FormerlySerializedAs("m_KeySmoothParameter")]
		protected ExposedProperty m_KeySmoothProperty = "KeySmooth";

		// Token: 0x040000BC RID: 188
		public KeyCode Key = KeyCode.Space;

		// Token: 0x040000BD RID: 189
		public float SmoothSpeed = 2f;

		// Token: 0x040000BE RID: 190
		public bool UseKeySmooth = true;

		// Token: 0x040000BF RID: 191
		private float m_CachedSmoothValue;
	}
}
