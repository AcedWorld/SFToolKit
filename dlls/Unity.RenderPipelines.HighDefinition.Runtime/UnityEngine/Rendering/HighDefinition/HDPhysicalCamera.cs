using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000154 RID: 340
	[Obsolete("Properties have been migrated to Camera class", false)]
	[Serializable]
	public struct HDPhysicalCamera
	{
		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000AFA RID: 2810 RVA: 0x0005B3F5 File Offset: 0x000595F5
		// (set) Token: 0x06000AFB RID: 2811 RVA: 0x0005B3FD File Offset: 0x000595FD
		public float focusDistance
		{
			get
			{
				return this.m_FocusDistance;
			}
			set
			{
				this.m_FocusDistance = Mathf.Max(value, 0.1f);
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000AFC RID: 2812 RVA: 0x0005B410 File Offset: 0x00059610
		// (set) Token: 0x06000AFD RID: 2813 RVA: 0x0005B418 File Offset: 0x00059618
		public int iso
		{
			get
			{
				return this.m_Iso;
			}
			set
			{
				this.m_Iso = Mathf.Max(value, 1);
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000AFE RID: 2814 RVA: 0x0005B427 File Offset: 0x00059627
		// (set) Token: 0x06000AFF RID: 2815 RVA: 0x0005B42F File Offset: 0x0005962F
		public float shutterSpeed
		{
			get
			{
				return this.m_ShutterSpeed;
			}
			set
			{
				this.m_ShutterSpeed = Mathf.Max(value, 0f);
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000B00 RID: 2816 RVA: 0x0005B442 File Offset: 0x00059642
		// (set) Token: 0x06000B01 RID: 2817 RVA: 0x0005B44A File Offset: 0x0005964A
		public float aperture
		{
			get
			{
				return this.m_Aperture;
			}
			set
			{
				this.m_Aperture = Mathf.Clamp(value, 0.7f, 32f);
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000B02 RID: 2818 RVA: 0x0005B462 File Offset: 0x00059662
		// (set) Token: 0x06000B03 RID: 2819 RVA: 0x0005B46A File Offset: 0x0005966A
		public int bladeCount
		{
			get
			{
				return this.m_BladeCount;
			}
			set
			{
				this.m_BladeCount = Mathf.Clamp(value, 3, 11);
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000B04 RID: 2820 RVA: 0x0005B47B File Offset: 0x0005967B
		// (set) Token: 0x06000B05 RID: 2821 RVA: 0x0005B483 File Offset: 0x00059683
		public Vector2 curvature
		{
			get
			{
				return this.m_Curvature;
			}
			set
			{
				this.m_Curvature.x = Mathf.Max(value.x, 0.7f);
				this.m_Curvature.y = Mathf.Min(value.y, 32f);
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000B06 RID: 2822 RVA: 0x0005B4BB File Offset: 0x000596BB
		// (set) Token: 0x06000B07 RID: 2823 RVA: 0x0005B4C3 File Offset: 0x000596C3
		public float barrelClipping
		{
			get
			{
				return this.m_BarrelClipping;
			}
			set
			{
				this.m_BarrelClipping = Mathf.Clamp01(value);
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000B08 RID: 2824 RVA: 0x0005B4D1 File Offset: 0x000596D1
		// (set) Token: 0x06000B09 RID: 2825 RVA: 0x0005B4D9 File Offset: 0x000596D9
		public float anamorphism
		{
			get
			{
				return this.m_Anamorphism;
			}
			set
			{
				this.m_Anamorphism = Mathf.Clamp(value, -1f, 1f);
			}
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x0005B4F1 File Offset: 0x000596F1
		[Obsolete("The CopyTo method is obsolete and does not work anymore. Use the assignement operator instead to get a copy of the HDPhysicalCamera parameters.", true)]
		public void CopyTo(HDPhysicalCamera c)
		{
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x0005B4F4 File Offset: 0x000596F4
		public static HDPhysicalCamera GetDefaults()
		{
			return new HDPhysicalCamera
			{
				iso = 200,
				shutterSpeed = 0.005f,
				aperture = 16f,
				focusDistance = 10f,
				bladeCount = 5,
				curvature = new Vector2(2f, 11f),
				barrelClipping = 0.25f,
				anamorphism = 0f
			};
		}

		// Token: 0x04000C2E RID: 3118
		public const float kMinAperture = 0.7f;

		// Token: 0x04000C2F RID: 3119
		public const float kMaxAperture = 32f;

		// Token: 0x04000C30 RID: 3120
		public const int kMinBladeCount = 3;

		// Token: 0x04000C31 RID: 3121
		public const int kMaxBladeCount = 11;

		// Token: 0x04000C32 RID: 3122
		[SerializeField]
		[Min(1f)]
		private int m_Iso;

		// Token: 0x04000C33 RID: 3123
		[SerializeField]
		[Min(0f)]
		private float m_ShutterSpeed;

		// Token: 0x04000C34 RID: 3124
		[SerializeField]
		[Range(0.7f, 32f)]
		private float m_Aperture;

		// Token: 0x04000C35 RID: 3125
		[SerializeField]
		[Min(0.1f)]
		private float m_FocusDistance;

		// Token: 0x04000C36 RID: 3126
		[SerializeField]
		[Range(3f, 11f)]
		private int m_BladeCount;

		// Token: 0x04000C37 RID: 3127
		[SerializeField]
		private Vector2 m_Curvature;

		// Token: 0x04000C38 RID: 3128
		[SerializeField]
		[Range(0f, 1f)]
		private float m_BarrelClipping;

		// Token: 0x04000C39 RID: 3129
		[SerializeField]
		[Range(-1f, 1f)]
		private float m_Anamorphism;
	}
}
