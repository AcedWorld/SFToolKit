using System;

namespace UnityEngine.Rendering.HighDefinition.LTC
{
	// Token: 0x0200022B RID: 555
	internal struct BRDF_Charlie : IBRDF
	{
		// Token: 0x06000FEA RID: 4074 RVA: 0x0007B948 File Offset: 0x00079B48
		public double Eval(ref Vector3 _tsView, ref Vector3 _tsLight, float _alpha, out double _pdf)
		{
			if (_tsView.z <= 0f)
			{
				_pdf = 0.0;
				return 0.0;
			}
			_alpha = Mathf.Max(0.002f, _alpha);
			ref Vector3 ptr = Vector3.Normalize(_tsView + _tsLight);
			double num = (double)_tsLight.z;
			double ndotV = (double)_tsView.z;
			double ndotH = (double)ptr.z;
			double num2 = this.CharlieD(_alpha, ndotH);
			double num3 = this.V_Charlie(ndotV, num, (double)_alpha);
			double result = num2 * num3 * num;
			_pdf = 0.15915494309189535;
			return result;
		}

		// Token: 0x06000FEB RID: 4075 RVA: 0x0007B9D8 File Offset: 0x00079BD8
		public void GetSamplingDirection(ref Vector3 _tsView, float _alpha, float _U1, float _U2, ref Vector3 _direction)
		{
			float f = 6.2831855f * _U1;
			float num = 1f - _U2;
			float num2 = Mathf.Sqrt(1f - num * num);
			_direction = new Vector3(num2 * Mathf.Cos(f), num2 * Mathf.Sin(f), num);
		}

		// Token: 0x06000FEC RID: 4076 RVA: 0x0007BA24 File Offset: 0x00079C24
		private double CharlieD(float _roughness, double _NdotH)
		{
			double num = 1.0 / (double)_roughness;
			double num2 = _NdotH * _NdotH;
			double x = 1.0 - num2;
			return (2.0 + num) * Math.Pow(x, num * 0.5) / 6.283185307179586;
		}

		// Token: 0x06000FED RID: 4077 RVA: 0x0007BA75 File Offset: 0x00079C75
		private double V_Ashikhmin(double _NdotV, double _NdotL)
		{
			return 1.0 / (4.0 * (_NdotL + _NdotV - _NdotL * _NdotV));
		}

		// Token: 0x06000FEE RID: 4078 RVA: 0x0007BA94 File Offset: 0x00079C94
		private double V_Charlie(double _NdotV, double _NdotL, double _roughness)
		{
			double num = (_NdotV < 0.5) ? Math.Exp(this.CharlieL(_NdotV, _roughness)) : Math.Exp(2.0 * this.CharlieL(0.5, _roughness) - this.CharlieL(1.0 - _NdotV, _roughness));
			double num2 = (_NdotL < 0.5) ? Math.Exp(this.CharlieL(_NdotL, _roughness)) : Math.Exp(2.0 * this.CharlieL(0.5, _roughness) - this.CharlieL(1.0 - _NdotL, _roughness));
			return 1.0 / ((1.0 + num + num2) * (4.0 * _NdotV * _NdotL));
		}

		// Token: 0x06000FEF RID: 4079 RVA: 0x0007BB64 File Offset: 0x00079D64
		private double CharlieL(double x, double _roughness)
		{
			float num = Mathf.Clamp01((float)_roughness);
			num = 1f - num * num;
			double num2 = (double)Mathf.Lerp(25.3245f, 21.5473f, num);
			float num3 = Mathf.Lerp(3.32435f, 3.82987f, num);
			float num4 = Mathf.Lerp(0.16801f, 0.19823f, num);
			float num5 = Mathf.Lerp(-1.27393f, -1.9776f, num);
			float num6 = Mathf.Lerp(-4.85967f, -4.32054f, num);
			return num2 / (1.0 + (double)num3 * Math.Pow(Math.Max(0.0, x), (double)num4)) + (double)num5 * x + (double)num6;
		}

		// Token: 0x06000FF0 RID: 4080 RVA: 0x0007BC06 File Offset: 0x00079E06
		public LTCLightingModel GetLightingModel()
		{
			return LTCLightingModel.Charlie;
		}
	}
}
