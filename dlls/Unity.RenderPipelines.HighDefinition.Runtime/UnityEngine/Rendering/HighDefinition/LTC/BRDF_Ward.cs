using System;

namespace UnityEngine.Rendering.HighDefinition.LTC
{
	// Token: 0x02000235 RID: 565
	internal struct BRDF_Ward : IBRDF
	{
		// Token: 0x06001014 RID: 4116 RVA: 0x0007C7F8 File Offset: 0x0007A9F8
		public double Eval(ref Vector3 _tsView, ref Vector3 _tsLight, float _alpha, out double _pdf)
		{
			if (_tsView.z <= 0f)
			{
				_pdf = 0.0;
				return 0.0;
			}
			_alpha = Mathf.Max(0.002f, _alpha);
			Vector3 normalized = (_tsView + _tsLight).normalized;
			double num = Math.Max(1E-08, (double)_tsLight.z);
			double num2 = Math.Max(1E-08, (double)normalized.z);
			double num3 = Math.Max(1E-08, (double)Vector3.Dot(_tsLight, normalized));
			double num4 = (double)(_alpha * _alpha);
			double num5 = num2 * num2;
			double num6 = Math.Exp(-(1.0 - num5) / (num4 * num5)) / (3.141592653589793 * num4 * num5 * num5);
			num6 /= 4.0 * num3 * num3;
			double result = num6 * num;
			_pdf = Math.Abs(num6 * num2);
			return result;
		}

		// Token: 0x06001015 RID: 4117 RVA: 0x0007C8F4 File Offset: 0x0007AAF4
		public void GetSamplingDirection(ref Vector3 _tsView, float _alpha, float _U1, float _U2, ref Vector3 _direction)
		{
			float num = _alpha * Mathf.Sqrt(-Mathf.Log(Mathf.Max(1E-06f, _U1)));
			float f = _U2 * 2f * 3.1415927f;
			float num2 = 1f / Mathf.Sqrt(1f + num * num);
			float num3 = Mathf.Sqrt(1f - num2 * num2);
			Vector3 vector = new Vector3(num3 * Mathf.Cos(f), num3 * Mathf.Sin(f), num2);
			_direction = 2f * Vector3.Dot(vector, _tsView) * vector - _tsView;
		}

		// Token: 0x06001016 RID: 4118 RVA: 0x0007C991 File Offset: 0x0007AB91
		public LTCLightingModel GetLightingModel()
		{
			return LTCLightingModel.Ward;
		}
	}
}
