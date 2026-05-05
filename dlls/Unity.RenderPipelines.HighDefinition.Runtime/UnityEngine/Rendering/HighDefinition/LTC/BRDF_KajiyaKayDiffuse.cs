using System;

namespace UnityEngine.Rendering.HighDefinition.LTC
{
	// Token: 0x02000231 RID: 561
	internal struct BRDF_KajiyaKayDiffuse : IBRDF
	{
		// Token: 0x06001003 RID: 4099 RVA: 0x0007C27C File Offset: 0x0007A47C
		public double Eval(ref Vector3 _tsView, ref Vector3 _tsLight, float _alpha, out double _pdf)
		{
			if (_tsView.z <= 0f)
			{
				_pdf = 0.0;
				return 0.0;
			}
			_alpha = Mathf.Max(0.002f, _alpha);
			double num = (double)Math.Max(0f, _tsLight.z);
			_pdf = num / 3.141592653589793;
			return num / 9.869604401089358;
		}

		// Token: 0x06001004 RID: 4100 RVA: 0x0007C2E4 File Offset: 0x0007A4E4
		public void GetSamplingDirection(ref Vector3 _tsView, float _alpha, float _U1, float _U2, ref Vector3 _direction)
		{
			float num = Mathf.Sqrt(_U1);
			float f = 6.2831855f * _U2;
			_direction.x = num * Mathf.Cos(f);
			_direction.y = num * Mathf.Sin(f);
			_direction.z = Mathf.Sqrt(1f - _U1);
		}

		// Token: 0x06001005 RID: 4101 RVA: 0x0007C332 File Offset: 0x0007A532
		public LTCLightingModel GetLightingModel()
		{
			return LTCLightingModel.KajiyaKayDiffuse;
		}
	}
}
