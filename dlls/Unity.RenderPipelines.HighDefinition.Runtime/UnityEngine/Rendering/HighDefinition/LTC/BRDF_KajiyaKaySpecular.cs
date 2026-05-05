using System;

namespace UnityEngine.Rendering.HighDefinition.LTC
{
	// Token: 0x02000232 RID: 562
	internal struct BRDF_KajiyaKaySpecular : IBRDF
	{
		// Token: 0x06001006 RID: 4102 RVA: 0x0007C338 File Offset: 0x0007A538
		public double Eval(ref Vector3 _tsView, ref Vector3 _tsLight, float _alpha, out double _pdf)
		{
			if (_tsView.z <= 0f)
			{
				_pdf = 0.0;
				return 0.0;
			}
			_alpha = Mathf.Max(0.002f, _alpha);
			double num = Math.Sqrt((double)_alpha);
			Vector3 right = Vector3.right;
			Vector3 forward = Vector3.forward;
			double num2 = (double)Math.Max(0f, _tsView.z);
			double num3 = (double)Math.Max(0f, _tsLight.z);
			double num4 = (double)Math.Max(0f, Vector3.Dot(_tsLight, _tsView));
			Vector3 vector = Vector3.Normalize(_tsLight + _tsView);
			double cosTheta = (double)Math.Max(0f, Vector3.Dot(_tsLight, vector));
			Vector3 t = this.ShiftTangent(right, forward, 0f);
			Vector3 t2 = this.ShiftTangent(right, forward, 0f);
			double specularExponent = this.RoughnessToBlinnPhongSpecularExponent((double)_alpha);
			double num5 = this.D_KajiyaKay(t, vector, specularExponent);
			double num6 = this.D_KajiyaKay(t2, vector, specularExponent);
			double f = 0.5 + (num + num * num4);
			double num7 = this.F_Schlick(1.0, f, cosTheta);
			double result = 0.25 * num7 * (num5 + num6) * num3 * Math.Min(Math.Max(num2 * double.MaxValue, 0.0), 1.0);
			_pdf = 0.15915494309189535;
			return result;
		}

		// Token: 0x06001007 RID: 4103 RVA: 0x0007C4B4 File Offset: 0x0007A6B4
		public void GetSamplingDirection(ref Vector3 _tsView, float _alpha, float _U1, float _U2, ref Vector3 _direction)
		{
			float f = 6.2831855f * _U1;
			float num = 1f - _U2;
			float num2 = Mathf.Sqrt(1f - num * num);
			_direction = new Vector3(num2 * Mathf.Cos(f), num2 * Mathf.Sin(f), num);
		}

		// Token: 0x06001008 RID: 4104 RVA: 0x0007C4FE File Offset: 0x0007A6FE
		private double RoughnessToBlinnPhongSpecularExponent(double roughness)
		{
			return Math.Min(Math.Max(2.0 / (roughness * roughness) - 2.0, 0.0001), 3000.0);
		}

		// Token: 0x06001009 RID: 4105 RVA: 0x0007C534 File Offset: 0x0007A734
		private double F_Schlick(double _F0, double _F90, double _cosTheta)
		{
			double num = 1.0 - _cosTheta;
			double num2 = num * num;
			double num3 = num * num2 * num2;
			return (_F90 - _F0) * num3 + _F0;
		}

		// Token: 0x0600100A RID: 4106 RVA: 0x0007C55C File Offset: 0x0007A75C
		private Vector3 ShiftTangent(Vector3 T, Vector3 N, float shift)
		{
			return Vector3.Normalize(T + N * shift);
		}

		// Token: 0x0600100B RID: 4107 RVA: 0x0007C570 File Offset: 0x0007A770
		private double PositivePow(double value, double power)
		{
			return Math.Pow(Math.Max(Math.Abs(value), 1.192092896E-07), power);
		}

		// Token: 0x0600100C RID: 4108 RVA: 0x0007C58C File Offset: 0x0007A78C
		private double D_KajiyaKay(Vector3 T, Vector3 H, double specularExponent)
		{
			float num = Vector3.Dot(T, H);
			float num2 = Mathf.Clamp(1f - num * num, 0f, 1f);
			double num3 = (double)Mathf.Clamp(num + 1f, 0f, 1f);
			double num4 = (specularExponent + 2.0) / 6.283185307179586;
			return num3 * num4 * this.PositivePow((double)num2, 0.5 * specularExponent);
		}

		// Token: 0x0600100D RID: 4109 RVA: 0x0007C5FF File Offset: 0x0007A7FF
		public LTCLightingModel GetLightingModel()
		{
			return LTCLightingModel.KajiyaKaySpecular;
		}
	}
}
