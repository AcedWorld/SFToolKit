using System;

namespace UnityEngine.Rendering.HighDefinition.LTC
{
	// Token: 0x0200022C RID: 556
	internal struct BRDF_CookTorrance : IBRDF
	{
		// Token: 0x06000FF1 RID: 4081 RVA: 0x0007BC0C File Offset: 0x00079E0C
		public double Eval(ref Vector3 _tsView, ref Vector3 _tsLight, float _alpha, out double _pdf)
		{
			if (_tsView.z <= 0f)
			{
				_pdf = 0.0;
				return 0.0;
			}
			_alpha = Mathf.Max(0.002f, _alpha);
			Vector3 normalized = (_tsView + _tsLight).normalized;
			double val = Math.Max(1E-08, (double)_tsLight.z);
			double num = Math.Max(1E-08, (double)_tsView.z);
			double num2 = (double)normalized.z;
			double num3 = Math.Max(1E-08, (double)Vector3.Dot(_tsLight, normalized));
			double num4 = num2 * num2;
			double num5 = (double)(_alpha * _alpha);
			double num6 = Math.Exp((num4 - 1.0) / (num4 * num5)) / Math.Max(1E-12, 3.141592653589793 * num5 * num4 * num4);
			double num7 = Math.Min(1.0, 2.0 * num2 * Math.Min(num, val) / num3);
			double result = num6 * num7 / (4.0 * num);
			_pdf = Math.Abs(num6 * num2 / (4.0 * num3));
			return result;
		}

		// Token: 0x06000FF2 RID: 4082 RVA: 0x0007BD4C File Offset: 0x00079F4C
		public void GetSamplingDirection(ref Vector3 _tsView, float _alpha, float _U1, float _U2, ref Vector3 _direction)
		{
			float f = 6.2831855f * _U1;
			float num = 1f / Mathf.Sqrt(1f - _alpha * _alpha * Mathf.Log(Mathf.Max(1E-06f, _U2)));
			float num2 = Mathf.Sqrt(1f - num * num);
			Vector3 vector = new Vector3(num2 * Mathf.Cos(f), num2 * Mathf.Sin(f), num);
			_direction = 2f * Vector3.Dot(vector, _tsView) * vector - _tsView;
		}

		// Token: 0x06000FF3 RID: 4083 RVA: 0x0007BDD9 File Offset: 0x00079FD9
		public LTCLightingModel GetLightingModel()
		{
			return LTCLightingModel.CookTorrance;
		}
	}
}
