using System;

namespace UnityEngine.Rendering.HighDefinition.LTC
{
	// Token: 0x0200022F RID: 559
	internal class BRDF_GGX : IBRDF
	{
		// Token: 0x06000FFB RID: 4091 RVA: 0x0007C000 File Offset: 0x0007A200
		public double Eval(ref Vector3 _tsView, ref Vector3 _tsLight, float _alpha, out double _pdf)
		{
			if (_tsView.z <= 0f)
			{
				_pdf = 0.0;
				return 0.0;
			}
			double num = this.Lambda(_tsView.z, _alpha);
			double num2 = 0.0;
			if (_tsLight.z > 0f)
			{
				double num3 = this.Lambda(_tsLight.z, _alpha);
				num2 = 1.0 / (1.0 + num + num3);
			}
			Vector3 vector = _tsView + _tsLight;
			float magnitude = vector.magnitude;
			if (magnitude > 1E-08f)
			{
				vector /= magnitude;
			}
			else
			{
				vector = new Vector3(0f, 0f, 1f);
			}
			double num4 = (double)(vector.x / vector.z);
			double num5 = (double)(vector.y / vector.z);
			double num6 = 1.0 / (1.0 + (num4 * num4 + num5 * num5) / (double)_alpha / (double)_alpha);
			num6 *= num6;
			num6 /= 3.141592653589793 * (double)_alpha * (double)_alpha * (double)vector.z * (double)vector.z * (double)vector.z * (double)vector.z;
			double result = num6 * num2 / 4.0 / (double)_tsView.z;
			_pdf = Math.Abs(num6 * (double)vector.z / 4.0 / (double)Vector3.Dot(_tsView, vector));
			return result;
		}

		// Token: 0x06000FFC RID: 4092 RVA: 0x0007C184 File Offset: 0x0007A384
		public void GetSamplingDirection(ref Vector3 _tsView, float _alpha, float _U1, float _U2, ref Vector3 _direction)
		{
			float f = 6.2831855f * _U1;
			float num = _alpha * Mathf.Sqrt(_U2 / (1f - _U2));
			Vector3 normalized = new Vector3(num * Mathf.Cos(f), num * Mathf.Sin(f), 1f).normalized;
			_direction = -_tsView + 2f * normalized * Vector3.Dot(normalized, _tsView);
		}

		// Token: 0x06000FFD RID: 4093 RVA: 0x0007C204 File Offset: 0x0007A404
		private double Lambda(float _cosTheta, float _alpha)
		{
			double num = (double)(1f / _alpha) / Math.Tan(Math.Acos((double)_cosTheta));
			if ((double)_cosTheta >= 1.0)
			{
				return 0.0;
			}
			return 0.5 * (-1.0 + Math.Sqrt(1.0 + 1.0 / (num * num)));
		}

		// Token: 0x06000FFE RID: 4094 RVA: 0x0007C26E File Offset: 0x0007A46E
		public LTCLightingModel GetLightingModel()
		{
			return LTCLightingModel.GGX;
		}
	}
}
