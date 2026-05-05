using System;
using Unity.Services.Qos;

namespace Unity.Services.Core
{
	// Token: 0x0200000E RID: 14
	public static class UnityServicesExtensions
	{
		// Token: 0x06000040 RID: 64 RVA: 0x00003452 File Offset: 0x00001652
		public static IQosService GetQosService(this IUnityServices unityServices)
		{
			return unityServices.GetService<IQosService>();
		}
	}
}
