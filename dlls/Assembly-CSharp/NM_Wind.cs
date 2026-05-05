using System;
using UnityEngine;

// Token: 0x0200008F RID: 143
[ExecuteInEditMode]
public class NM_Wind : MonoBehaviour
{
	// Token: 0x0600025E RID: 606 RVA: 0x00013C98 File Offset: 0x00011E98
	private void Start()
	{
		this.ApplySettings();
	}

	// Token: 0x0600025F RID: 607 RVA: 0x00013C98 File Offset: 0x00011E98
	private void Update()
	{
		this.ApplySettings();
	}

	// Token: 0x06000260 RID: 608 RVA: 0x00013C98 File Offset: 0x00011E98
	private void OnValidate()
	{
		this.ApplySettings();
	}

	// Token: 0x06000261 RID: 609 RVA: 0x00013CA0 File Offset: 0x00011EA0
	private void ApplySettings()
	{
		Shader.SetGlobalTexture("WIND_SETTINGS_TexNoise", this.NoiseTexture);
		Shader.SetGlobalTexture("WIND_SETTINGS_TexGust", this.GustMaskTexture);
		Shader.SetGlobalVector("WIND_SETTINGS_WorldDirectionAndSpeed", this.GetDirectionAndSpeed());
		Shader.SetGlobalFloat("WIND_SETTINGS_FlexNoiseScale", 1f / Mathf.Max(0.01f, this.FlexNoiseWorldSize));
		Shader.SetGlobalFloat("WIND_SETTINGS_ShiverNoiseScale", 1f / Mathf.Max(0.01f, this.ShiverNoiseWorldSize));
		Shader.SetGlobalFloat("WIND_SETTINGS_Turbulence", this.WindSpeed * this.Turbulence);
		Shader.SetGlobalFloat("WIND_SETTINGS_GustSpeed", this.GustSpeed);
		Shader.SetGlobalFloat("WIND_SETTINGS_GustScale", this.GustScale);
		Shader.SetGlobalFloat("WIND_SETTINGS_GustWorldScale", 1f / Mathf.Max(0.01f, this.GustWorldSize));
		if (this.point1 != null)
		{
			this.pos1 = new Vector4(this.point1.transform.position.x, this.point1.transform.position.y, this.point1.transform.position.z, this.point1.windMain * 0.2777f);
			this.radius[0] = this.point1.radius;
		}
		else
		{
			this.pos1 = new Vector4(0f, 0f, 0f, 0f);
			this.radius[0] = 0.1f;
		}
		if (this.point2 != null)
		{
			this.pos2 = new Vector4(this.point2.transform.position.x, this.point2.transform.position.y, this.point2.transform.position.z, this.point2.windMain * 0.2777f);
			this.radius[1] = this.point2.radius;
		}
		else
		{
			this.pos2 = new Vector4(0f, 0f, 0f, 0f);
			this.radius[1] = 0.1f;
		}
		if (this.point3 != null)
		{
			this.pos3 = new Vector4(this.point3.transform.position.x, this.point3.transform.position.y, this.point3.transform.position.z, this.point3.windMain * 0.2777f);
			this.radius[2] = this.point3.radius;
		}
		else
		{
			this.pos3 = new Vector4(0f, 0f, 0f, 0f);
			this.radius[2] = 0.1f;
		}
		if (this.point4 != null)
		{
			this.pos4 = new Vector4(this.point4.transform.position.x, this.point4.transform.position.y, this.point4.transform.position.z, this.point4.windMain * 0.2777f);
			this.radius[3] = this.point4.radius;
		}
		else
		{
			this.pos4 = new Vector4(0f, 0f, 0f, 0f);
			this.radius[3] = 0.1f;
		}
		Shader.SetGlobalMatrix("WIND_SETTINGS_Points", new Matrix4x4(this.pos1, this.pos2, this.pos3, this.pos4));
		Shader.SetGlobalVector("WIND_SETTINGS_Points_Radius", this.radius);
	}

	// Token: 0x06000262 RID: 610 RVA: 0x00014074 File Offset: 0x00012274
	private Vector4 GetDirectionAndSpeed()
	{
		Vector3 normalized = base.transform.forward.normalized;
		return new Vector4(normalized.x, normalized.y, normalized.z, this.WindSpeed * 0.2777f);
	}

	// Token: 0x040002F8 RID: 760
	[Header("General Parameters")]
	[Tooltip("Wind Speed in Kilometers per hour")]
	public float WindSpeed = 30f;

	// Token: 0x040002F9 RID: 761
	[Range(0f, 2f)]
	[Tooltip("Wind Turbulence in percentage of wind Speed")]
	public float Turbulence = 0.25f;

	// Token: 0x040002FA RID: 762
	[Header("Noise Parameters")]
	[Tooltip("Texture used for wind turbulence")]
	public Texture2D NoiseTexture;

	// Token: 0x040002FB RID: 763
	[Tooltip("Size of one world tiling patch of the Noise Texture, for bending trees")]
	public float FlexNoiseWorldSize = 175f;

	// Token: 0x040002FC RID: 764
	[Tooltip("Size of one world tiling patch of the Noise Texture, for leaf shivering")]
	public float ShiverNoiseWorldSize = 10f;

	// Token: 0x040002FD RID: 765
	[Header("Gust Parameters")]
	[Tooltip("Texture used for wind gusts")]
	public Texture2D GustMaskTexture;

	// Token: 0x040002FE RID: 766
	[Tooltip("Size of one world tiling patch of the Gust Texture, for leaf shivering")]
	public float GustWorldSize = 600f;

	// Token: 0x040002FF RID: 767
	[Tooltip("Wind Gust Speed in Kilometers per hour")]
	public float GustSpeed = 50f;

	// Token: 0x04000300 RID: 768
	[Tooltip("Wind Gust Influence on trees")]
	public float GustScale = 1f;

	// Token: 0x04000301 RID: 769
	[Header("Wind Sherical")]
	[Tooltip("Wind Gust Influence on trees")]
	public WindZone point1;

	// Token: 0x04000302 RID: 770
	public WindZone point2;

	// Token: 0x04000303 RID: 771
	public WindZone point3;

	// Token: 0x04000304 RID: 772
	public WindZone point4;

	// Token: 0x04000305 RID: 773
	private Vector4 pos1;

	// Token: 0x04000306 RID: 774
	private Vector4 pos2;

	// Token: 0x04000307 RID: 775
	private Vector4 pos3;

	// Token: 0x04000308 RID: 776
	private Vector4 pos4;

	// Token: 0x04000309 RID: 777
	private Vector4 radius;
}
