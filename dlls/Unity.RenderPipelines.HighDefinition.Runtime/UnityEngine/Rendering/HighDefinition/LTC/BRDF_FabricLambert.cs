using System;

namespace UnityEngine.Rendering.HighDefinition.LTC
{
	// Token: 0x0200022E RID: 558
	internal struct BRDF_FabricLambert : IBRDF
	{
		// Token: 0x06000FF8 RID: 4088 RVA: 0x0007BF3C File Offset: 0x0007A13C
		public double Eval(ref Vector3 _tsView, ref Vector3 _tsLight, float _alpha, out double _pdf)
		{
			if (_tsView.z <= 0f)
			{
				_pdf = 0.0;
				return 0.0;
			}
			double num = (double)Math.Max(0f, _tsLight.z);
			_pdf = num / 3.141592653589793;
			return (double)Mathf.Lerp(1f, 0.5f, Mathf.Max(0.002f, _alpha)) * _pdf;
		}

		// Token: 0x06000FF9 RID: 4089 RVA: 0x0007BFAC File Offset: 0x0007A1AC
		public void GetSamplingDirection(ref Vector3 _tsView, float _alpha, float _U1, float _U2, ref Vector3 _direction)
		{
			float num = Mathf.Sqrt(_U1);
			float f = 6.2831855f * _U2;
			_direction.x = num * Mathf.Cos(f);
			_direction.y = num * Mathf.Sin(f);
			_direction.z = Mathf.Sqrt(1f - _U1);
		}

		// Token: 0x06000FFA RID: 4090 RVA: 0x0007BFFA File Offset: 0x0007A1FA
		public LTCLightingModel GetLightingModel()
		{
			return LTCLightingModel.FabricLambert;
		}
	}
}
