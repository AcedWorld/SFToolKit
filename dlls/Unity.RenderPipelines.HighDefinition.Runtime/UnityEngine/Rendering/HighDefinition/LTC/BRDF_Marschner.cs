using System;

namespace UnityEngine.Rendering.HighDefinition.LTC
{
	// Token: 0x02000233 RID: 563
	internal struct BRDF_Marschner : IBRDF
	{
		// Token: 0x0600100E RID: 4110 RVA: 0x0007C602 File Offset: 0x0007A802
		public double Eval(ref Vector3 _tsView, ref Vector3 _tsLight, float _alpha, out double _pdf)
		{
			_pdf = 0.07957747154594767;
			return 0.0;
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x0007C619 File Offset: 0x0007A819
		public void GetSamplingDirection(ref Vector3 _tsView, float _alpha, float _U1, float _U2, ref Vector3 _direction)
		{
			_direction = Vector3.up;
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x0007C627 File Offset: 0x0007A827
		public LTCLightingModel GetLightingModel()
		{
			return LTCLightingModel.Marschner;
		}
	}
}
