using System;

namespace UnityEngine.Rendering.HighDefinition.LTC
{
	// Token: 0x02000234 RID: 564
	internal struct BRDF_OrenNayar : IBRDF
	{
		// Token: 0x06001011 RID: 4113 RVA: 0x0007C62C File Offset: 0x0007A82C
		public double Eval(ref Vector3 _tsView, ref Vector3 _tsLight, float _alpha, out double _pdf)
		{
			if (_tsView.z <= 0f)
			{
				_pdf = 0.0;
				return 0.0;
			}
			float num = Mathf.Max(0.002f, 1.5707964f * _alpha);
			double num2 = (double)Math.Max(0f, _tsLight.z);
			double num3 = (double)Math.Max(0f, _tsView.z);
			double val = (double)(_tsView.x * _tsLight.x + _tsView.y * _tsLight.y) / Math.Max(1E-20, Math.Sqrt(1.0 - num3 * num3) * Math.Sqrt(1.0 - num2 * num2));
			double num4 = (double)(num * num);
			double num5 = 1.0 - 0.5 * (num4 / (num4 + 0.57));
			double num6 = 0.45 * (num4 / (num4 + 0.09));
			double num7 = (num3 < num2) ? num3 : num2;
			double num8 = (num3 < num2) ? num2 : num3;
			double num9 = Math.Sqrt(1.0 - num7 * num7);
			double num10 = Math.Sqrt(1.0 - num8 * num8);
			double num11 = num9 * num10 / Math.Max(1E-20, num8);
			double result = (num5 + num6 * Math.Max(0.0, val) * num11) / 3.141592653589793 * num2;
			_pdf = num2 / 3.141592653589793;
			return result;
		}

		// Token: 0x06001012 RID: 4114 RVA: 0x0007C7A4 File Offset: 0x0007A9A4
		public void GetSamplingDirection(ref Vector3 _tsView, float _alpha, float _U1, float _U2, ref Vector3 _direction)
		{
			float num = Mathf.Sqrt(_U1);
			float f = 6.2831855f * _U2;
			_direction.x = num * Mathf.Cos(f);
			_direction.y = num * Mathf.Sin(f);
			_direction.z = Mathf.Sqrt(1f - _U1);
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x0007C7F2 File Offset: 0x0007A9F2
		public LTCLightingModel GetLightingModel()
		{
			return LTCLightingModel.OrenNayar;
		}
	}
}
