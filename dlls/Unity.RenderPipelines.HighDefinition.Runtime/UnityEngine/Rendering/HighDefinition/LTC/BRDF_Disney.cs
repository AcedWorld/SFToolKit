using System;

namespace UnityEngine.Rendering.HighDefinition.LTC
{
	// Token: 0x0200022D RID: 557
	internal struct BRDF_Disney : IBRDF
	{
		// Token: 0x06000FF4 RID: 4084 RVA: 0x0007BDDC File Offset: 0x00079FDC
		public double Eval(ref Vector3 _tsView, ref Vector3 _tsLight, float _alpha, out double _pdf)
		{
			if (_tsView.z <= 0f)
			{
				_pdf = 0.0;
				return 0.0;
			}
			_alpha = Mathf.Max(0.002f, _alpha);
			double num = (double)Math.Max(0f, _tsLight.z);
			double cosTheta = (double)Math.Max(0f, _tsView.z);
			double num2 = (double)Math.Max(0f, Vector3.Dot(_tsLight, _tsView));
			double num3 = Math.Sqrt((double)_alpha);
			double f = 0.5 + (num3 + num3 * num2);
			double num4 = this.F_Schlick(1.0, f, num);
			double num5 = this.F_Schlick(1.0, f, cosTheta);
			double result = num4 * num5 / 3.141592653589793 / 1.03571 * num;
			_pdf = num / 3.141592653589793;
			return result;
		}

		// Token: 0x06000FF5 RID: 4085 RVA: 0x0007BEC0 File Offset: 0x0007A0C0
		public void GetSamplingDirection(ref Vector3 _tsView, float _alpha, float _U1, float _U2, ref Vector3 _direction)
		{
			float num = Mathf.Sqrt(_U1);
			float f = 6.2831855f * _U2;
			_direction.x = num * Mathf.Cos(f);
			_direction.y = num * Mathf.Sin(f);
			_direction.z = Mathf.Sqrt(1f - _U1);
		}

		// Token: 0x06000FF6 RID: 4086 RVA: 0x0007BF10 File Offset: 0x0007A110
		private double F_Schlick(double _F0, double _F90, double _cosTheta)
		{
			double num = 1.0 - _cosTheta;
			double num2 = num * num;
			double num3 = num * num2 * num2;
			return (_F90 - _F0) * num3 + _F0;
		}

		// Token: 0x06000FF7 RID: 4087 RVA: 0x0007BF38 File Offset: 0x0007A138
		public LTCLightingModel GetLightingModel()
		{
			return LTCLightingModel.DisneyDiffuse;
		}
	}
}
