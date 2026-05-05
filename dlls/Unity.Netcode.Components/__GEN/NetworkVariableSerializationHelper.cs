using System;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;

namespace __GEN
{
	// Token: 0x02000029 RID: 41
	internal class NetworkVariableSerializationHelper
	{
		// Token: 0x06000147 RID: 327 RVA: 0x00009F46 File Offset: 0x00008146
		[RuntimeInitializeOnLoadMethod]
		internal static void InitializeSerialization()
		{
			NetworkVariableSerializationTypes.InitializeSerializer_UnmanagedINetworkSerializable<NetworkTransform.NetworkTransformState>();
			NetworkVariableSerializationTypes.InitializeEqualityChecker_UnmanagedValueEquals<NetworkTransform.NetworkTransformState>();
		}
	}
}
