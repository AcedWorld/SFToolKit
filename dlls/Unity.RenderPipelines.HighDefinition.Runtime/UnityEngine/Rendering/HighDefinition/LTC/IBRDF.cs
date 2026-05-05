using System;

namespace UnityEngine.Rendering.HighDefinition.LTC
{
	// Token: 0x02000230 RID: 560
	internal interface IBRDF
	{
		// Token: 0x06001000 RID: 4096
		double Eval(ref Vector3 _tsView, ref Vector3 _tsLight, float _alpha, out double _pdf);

		// Token: 0x06001001 RID: 4097
		void GetSamplingDirection(ref Vector3 _tsView, float _alpha, float _U1, float _U2, ref Vector3 _direction);

		// Token: 0x06001002 RID: 4098
		LTCLightingModel GetLightingModel();
	}
}
