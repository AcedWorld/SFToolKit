using System;
using UnityEngine.Rendering;

namespace UnityEngine.Experimental.GlobalIllumination
{
	// Token: 0x020004BC RID: 1212
	public struct LinearColor
	{
		// Token: 0x17000836 RID: 2102
		// (get) Token: 0x06002AB4 RID: 10932 RVA: 0x00047A4C File Offset: 0x00045C4C
		// (set) Token: 0x06002AB5 RID: 10933 RVA: 0x00047A64 File Offset: 0x00045C64
		public float red
		{
			get
			{
				return this.m_red;
			}
			set
			{
				bool flag = value < 0f || value > 1f;
				if (flag)
				{
					throw new ArgumentOutOfRangeException("Red color (" + value.ToString() + ") must be in range [0;1].");
				}
				this.m_red = value;
			}
		}

		// Token: 0x17000837 RID: 2103
		// (get) Token: 0x06002AB6 RID: 10934 RVA: 0x00047AAC File Offset: 0x00045CAC
		// (set) Token: 0x06002AB7 RID: 10935 RVA: 0x00047AC4 File Offset: 0x00045CC4
		public float green
		{
			get
			{
				return this.m_green;
			}
			set
			{
				bool flag = value < 0f || value > 1f;
				if (flag)
				{
					throw new ArgumentOutOfRangeException("Green color (" + value.ToString() + ") must be in range [0;1].");
				}
				this.m_green = value;
			}
		}

		// Token: 0x17000838 RID: 2104
		// (get) Token: 0x06002AB8 RID: 10936 RVA: 0x00047B0C File Offset: 0x00045D0C
		// (set) Token: 0x06002AB9 RID: 10937 RVA: 0x00047B24 File Offset: 0x00045D24
		public float blue
		{
			get
			{
				return this.m_blue;
			}
			set
			{
				bool flag = value < 0f || value > 1f;
				if (flag)
				{
					throw new ArgumentOutOfRangeException("Blue color (" + value.ToString() + ") must be in range [0;1].");
				}
				this.m_blue = value;
			}
		}

		// Token: 0x17000839 RID: 2105
		// (get) Token: 0x06002ABA RID: 10938 RVA: 0x00047B6C File Offset: 0x00045D6C
		// (set) Token: 0x06002ABB RID: 10939 RVA: 0x00047B84 File Offset: 0x00045D84
		public float intensity
		{
			get
			{
				return this.m_intensity;
			}
			set
			{
				bool flag = value < 0f;
				if (flag)
				{
					throw new ArgumentOutOfRangeException("Intensity (" + value.ToString() + ") must be positive.");
				}
				this.m_intensity = value;
			}
		}

		// Token: 0x06002ABC RID: 10940 RVA: 0x00047BC4 File Offset: 0x00045DC4
		public static LinearColor Convert(Color color, float intensity)
		{
			Color color2 = GraphicsSettings.lightsUseLinearIntensity ? color.linear.RGBMultiplied(intensity) : color.RGBMultiplied(intensity).linear;
			float maxColorComponent = color2.maxColorComponent;
			bool flag = color2.r < 0f || color2.g < 0f || color2.b < 0f;
			if (flag)
			{
				throw new ArgumentOutOfRangeException(string.Concat(new string[]
				{
					"The input color to be converted must not contain negative values (red: ",
					color2.r.ToString(),
					", green: ",
					color2.g.ToString(),
					", blue: ",
					color2.b.ToString(),
					")."
				}));
			}
			bool flag2 = maxColorComponent <= 1E-20f;
			LinearColor result;
			if (flag2)
			{
				result = LinearColor.Black();
			}
			else
			{
				float num = 1f / color2.maxColorComponent;
				LinearColor linearColor;
				linearColor.m_red = color2.r * num;
				linearColor.m_green = color2.g * num;
				linearColor.m_blue = color2.b * num;
				linearColor.m_intensity = maxColorComponent;
				result = linearColor;
			}
			return result;
		}

		// Token: 0x06002ABD RID: 10941 RVA: 0x00047CF8 File Offset: 0x00045EF8
		public static LinearColor Black()
		{
			LinearColor result;
			result.m_red = (result.m_green = (result.m_blue = (result.m_intensity = 0f)));
			return result;
		}

		// Token: 0x04000FBA RID: 4026
		private float m_red;

		// Token: 0x04000FBB RID: 4027
		private float m_green;

		// Token: 0x04000FBC RID: 4028
		private float m_blue;

		// Token: 0x04000FBD RID: 4029
		private float m_intensity;
	}
}
