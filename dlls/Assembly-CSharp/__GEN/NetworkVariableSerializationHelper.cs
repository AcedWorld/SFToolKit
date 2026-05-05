using System;
using Unity.Netcode;
using UnityEngine;

namespace __GEN
{
	// Token: 0x0200042E RID: 1070
	internal class NetworkVariableSerializationHelper
	{
		// Token: 0x06001624 RID: 5668 RVA: 0x00075793 File Offset: 0x00073993
		[RuntimeInitializeOnLoadMethod]
		internal static void InitializeSerialization()
		{
			NetworkVariableSerializationTypes.InitializeSerializer_UnmanagedINetworkSerializable<NetworkOutfitSyncAll.OutfitConfig>();
			NetworkVariableSerializationTypes.InitializeEqualityChecker_UnmanagedIEquatable<NetworkOutfitSyncAll.OutfitConfig>();
			NetworkVariableSerializationTypes.InitializeSerializer_UnmanagedINetworkSerializable<NetworkScooterSyncAll.ScooterConfig>();
			NetworkVariableSerializationTypes.InitializeEqualityChecker_UnmanagedIEquatable<NetworkScooterSyncAll.ScooterConfig>();
			NetworkVariableSerializationTypes.InitializeSerializer_UnmanagedINetworkSerializable<NetworkClothingSync.ClothingConfig>();
			NetworkVariableSerializationTypes.InitializeEqualityChecker_UnmanagedIEquatable<NetworkClothingSync.ClothingConfig>();
		}
	}
}
