using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace Unity.Netcode
{
	// Token: 0x0200002F RID: 47
	public static class NetworkUpdateLoop
	{
		// Token: 0x060001CB RID: 459 RVA: 0x0000A1F8 File Offset: 0x000083F8
		static NetworkUpdateLoop()
		{
			foreach (object obj in Enum.GetValues(typeof(NetworkUpdateStage)))
			{
				NetworkUpdateStage key = (NetworkUpdateStage)obj;
				NetworkUpdateLoop.s_UpdateSystem_Sets.Add(key, new HashSet<INetworkUpdateSystem>());
				NetworkUpdateLoop.s_UpdateSystem_Arrays.Add(key, new INetworkUpdateSystem[1024]);
			}
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000A28C File Offset: 0x0000848C
		public static void RegisterAllNetworkUpdates(this INetworkUpdateSystem updateSystem)
		{
			foreach (object obj in Enum.GetValues(typeof(NetworkUpdateStage)))
			{
				NetworkUpdateStage updateStage = (NetworkUpdateStage)obj;
				updateSystem.RegisterNetworkUpdate(updateStage);
			}
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000A2F0 File Offset: 0x000084F0
		public static void RegisterNetworkUpdate(this INetworkUpdateSystem updateSystem, NetworkUpdateStage updateStage = NetworkUpdateStage.Update)
		{
			HashSet<INetworkUpdateSystem> hashSet = NetworkUpdateLoop.s_UpdateSystem_Sets[updateStage];
			if (!hashSet.Contains(updateSystem))
			{
				hashSet.Add(updateSystem);
				int count = hashSet.Count;
				INetworkUpdateSystem[] array = NetworkUpdateLoop.s_UpdateSystem_Arrays[updateStage];
				int num = array.Length;
				if (count > num)
				{
					array = (NetworkUpdateLoop.s_UpdateSystem_Arrays[updateStage] = new INetworkUpdateSystem[num *= 2]);
				}
				hashSet.CopyTo(array);
				if (count < num)
				{
					array[count] = null;
				}
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000A360 File Offset: 0x00008560
		public static void UnregisterAllNetworkUpdates(this INetworkUpdateSystem updateSystem)
		{
			foreach (object obj in Enum.GetValues(typeof(NetworkUpdateStage)))
			{
				NetworkUpdateStage updateStage = (NetworkUpdateStage)obj;
				updateSystem.UnregisterNetworkUpdate(updateStage);
			}
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0000A3C4 File Offset: 0x000085C4
		public static void UnregisterNetworkUpdate(this INetworkUpdateSystem updateSystem, NetworkUpdateStage updateStage = NetworkUpdateStage.Update)
		{
			HashSet<INetworkUpdateSystem> hashSet = NetworkUpdateLoop.s_UpdateSystem_Sets[updateStage];
			if (hashSet.Contains(updateSystem))
			{
				hashSet.Remove(updateSystem);
				int count = hashSet.Count;
				INetworkUpdateSystem[] array = NetworkUpdateLoop.s_UpdateSystem_Arrays[updateStage];
				int num = array.Length;
				hashSet.CopyTo(array);
				if (count < num)
				{
					array[count] = null;
				}
			}
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0000A414 File Offset: 0x00008614
		internal static void RunNetworkUpdateStage(NetworkUpdateStage updateStage)
		{
			NetworkUpdateLoop.UpdateStage = updateStage;
			INetworkUpdateSystem[] array = NetworkUpdateLoop.s_UpdateSystem_Arrays[updateStage];
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				INetworkUpdateSystem networkUpdateSystem = array[i];
				if (networkUpdateSystem == null)
				{
					break;
				}
				networkUpdateSystem.NetworkUpdate(updateStage);
			}
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000A451 File Offset: 0x00008651
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Initialize()
		{
			NetworkUpdateLoop.UnregisterLoopSystems();
			NetworkUpdateLoop.RegisterLoopSystems();
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000A460 File Offset: 0x00008660
		private static bool TryAddLoopSystem(ref PlayerLoopSystem parentLoopSystem, PlayerLoopSystem childLoopSystem, Type anchorSystemType, NetworkUpdateLoop.LoopSystemPosition loopSystemPosition)
		{
			int num = -1;
			if (anchorSystemType != null)
			{
				for (int i = 0; i < parentLoopSystem.subSystemList.Length; i++)
				{
					if (parentLoopSystem.subSystemList[i].type == anchorSystemType)
					{
						num = ((loopSystemPosition == NetworkUpdateLoop.LoopSystemPosition.After) ? (i + 1) : i);
						break;
					}
				}
			}
			else
			{
				num = ((loopSystemPosition == NetworkUpdateLoop.LoopSystemPosition.After) ? parentLoopSystem.subSystemList.Length : 0);
			}
			if (num == -1)
			{
				return false;
			}
			PlayerLoopSystem[] array = new PlayerLoopSystem[parentLoopSystem.subSystemList.Length + 1];
			if (num > 0)
			{
				Array.Copy(parentLoopSystem.subSystemList, array, num);
			}
			array[num] = childLoopSystem;
			if (num < parentLoopSystem.subSystemList.Length)
			{
				Array.Copy(parentLoopSystem.subSystemList, num, array, num + 1, parentLoopSystem.subSystemList.Length - num);
			}
			parentLoopSystem.subSystemList = array;
			return true;
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0000A520 File Offset: 0x00008720
		private static bool TryRemoveLoopSystem(ref PlayerLoopSystem parentLoopSystem, Type childSystemType)
		{
			int num = -1;
			for (int i = 0; i < parentLoopSystem.subSystemList.Length; i++)
			{
				if (parentLoopSystem.subSystemList[i].type == childSystemType)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return false;
			}
			PlayerLoopSystem[] array = new PlayerLoopSystem[parentLoopSystem.subSystemList.Length - 1];
			if (num > 0)
			{
				Array.Copy(parentLoopSystem.subSystemList, array, num);
			}
			if (num < parentLoopSystem.subSystemList.Length - 1)
			{
				Array.Copy(parentLoopSystem.subSystemList, num + 1, array, num, parentLoopSystem.subSystemList.Length - num - 1);
			}
			parentLoopSystem.subSystemList = array;
			return true;
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000A5B8 File Offset: 0x000087B8
		internal static void RegisterLoopSystems()
		{
			PlayerLoopSystem currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
			for (int i = 0; i < currentPlayerLoop.subSystemList.Length; i++)
			{
				ref PlayerLoopSystem ptr = ref currentPlayerLoop.subSystemList[i];
				if (ptr.type == typeof(Initialization))
				{
					NetworkUpdateLoop.TryAddLoopSystem(ref ptr, NetworkUpdateLoop.NetworkInitialization.CreateLoopSystem(), null, NetworkUpdateLoop.LoopSystemPosition.After);
				}
				else if (ptr.type == typeof(EarlyUpdate))
				{
					NetworkUpdateLoop.TryAddLoopSystem(ref ptr, NetworkUpdateLoop.NetworkEarlyUpdate.CreateLoopSystem(), typeof(EarlyUpdate.ScriptRunDelayedStartupFrame), NetworkUpdateLoop.LoopSystemPosition.Before);
				}
				else if (ptr.type == typeof(FixedUpdate))
				{
					NetworkUpdateLoop.TryAddLoopSystem(ref ptr, NetworkUpdateLoop.NetworkFixedUpdate.CreateLoopSystem(), typeof(FixedUpdate.ScriptRunBehaviourFixedUpdate), NetworkUpdateLoop.LoopSystemPosition.Before);
				}
				else if (ptr.type == typeof(PreUpdate))
				{
					NetworkUpdateLoop.TryAddLoopSystem(ref ptr, NetworkUpdateLoop.NetworkPreUpdate.CreateLoopSystem(), typeof(PreUpdate.PhysicsUpdate), NetworkUpdateLoop.LoopSystemPosition.Before);
				}
				else if (ptr.type == typeof(Update))
				{
					NetworkUpdateLoop.TryAddLoopSystem(ref ptr, NetworkUpdateLoop.NetworkUpdate.CreateLoopSystem(), typeof(Update.ScriptRunBehaviourUpdate), NetworkUpdateLoop.LoopSystemPosition.Before);
				}
				else if (ptr.type == typeof(PreLateUpdate))
				{
					NetworkUpdateLoop.TryAddLoopSystem(ref ptr, NetworkUpdateLoop.NetworkPreLateUpdate.CreateLoopSystem(), typeof(PreLateUpdate.ScriptRunBehaviourLateUpdate), NetworkUpdateLoop.LoopSystemPosition.Before);
					NetworkUpdateLoop.TryAddLoopSystem(ref ptr, NetworkUpdateLoop.NetworkPostScriptLateUpdate.CreateLoopSystem(), typeof(PreLateUpdate.ScriptRunBehaviourLateUpdate), NetworkUpdateLoop.LoopSystemPosition.After);
				}
				else if (ptr.type == typeof(PostLateUpdate))
				{
					NetworkUpdateLoop.TryAddLoopSystem(ref ptr, NetworkUpdateLoop.NetworkPostLateUpdate.CreateLoopSystem(), typeof(PostLateUpdate.PlayerSendFrameComplete), NetworkUpdateLoop.LoopSystemPosition.After);
				}
			}
			PlayerLoop.SetPlayerLoop(currentPlayerLoop);
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0000A760 File Offset: 0x00008960
		internal static void UnregisterLoopSystems()
		{
			PlayerLoopSystem currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
			for (int i = 0; i < currentPlayerLoop.subSystemList.Length; i++)
			{
				ref PlayerLoopSystem ptr = ref currentPlayerLoop.subSystemList[i];
				if (ptr.type == typeof(Initialization))
				{
					NetworkUpdateLoop.TryRemoveLoopSystem(ref ptr, typeof(NetworkUpdateLoop.NetworkInitialization));
				}
				else if (ptr.type == typeof(EarlyUpdate))
				{
					NetworkUpdateLoop.TryRemoveLoopSystem(ref ptr, typeof(NetworkUpdateLoop.NetworkEarlyUpdate));
				}
				else if (ptr.type == typeof(FixedUpdate))
				{
					NetworkUpdateLoop.TryRemoveLoopSystem(ref ptr, typeof(NetworkUpdateLoop.NetworkFixedUpdate));
				}
				else if (ptr.type == typeof(PreUpdate))
				{
					NetworkUpdateLoop.TryRemoveLoopSystem(ref ptr, typeof(NetworkUpdateLoop.NetworkPreUpdate));
				}
				else if (ptr.type == typeof(Update))
				{
					NetworkUpdateLoop.TryRemoveLoopSystem(ref ptr, typeof(NetworkUpdateLoop.NetworkUpdate));
				}
				else if (ptr.type == typeof(PreLateUpdate))
				{
					NetworkUpdateLoop.TryRemoveLoopSystem(ref ptr, typeof(NetworkUpdateLoop.NetworkPreLateUpdate));
					NetworkUpdateLoop.TryRemoveLoopSystem(ref ptr, typeof(NetworkUpdateLoop.NetworkPostScriptLateUpdate));
				}
				else if (ptr.type == typeof(PostLateUpdate))
				{
					NetworkUpdateLoop.TryRemoveLoopSystem(ref ptr, typeof(NetworkUpdateLoop.NetworkPostLateUpdate));
				}
			}
			PlayerLoop.SetPlayerLoop(currentPlayerLoop);
		}

		// Token: 0x040000F8 RID: 248
		private static Dictionary<NetworkUpdateStage, HashSet<INetworkUpdateSystem>> s_UpdateSystem_Sets = new Dictionary<NetworkUpdateStage, HashSet<INetworkUpdateSystem>>();

		// Token: 0x040000F9 RID: 249
		private static Dictionary<NetworkUpdateStage, INetworkUpdateSystem[]> s_UpdateSystem_Arrays = new Dictionary<NetworkUpdateStage, INetworkUpdateSystem[]>();

		// Token: 0x040000FA RID: 250
		private const int k_UpdateSystem_InitialArrayCapacity = 1024;

		// Token: 0x040000FB RID: 251
		public static NetworkUpdateStage UpdateStage;

		// Token: 0x02000030 RID: 48
		internal struct NetworkInitialization
		{
			// Token: 0x060001D6 RID: 470 RVA: 0x0000A8E0 File Offset: 0x00008AE0
			public static PlayerLoopSystem CreateLoopSystem()
			{
				PlayerLoopSystem result = default(PlayerLoopSystem);
				result.type = typeof(NetworkUpdateLoop.NetworkInitialization);
				result.updateDelegate = delegate()
				{
					NetworkUpdateLoop.RunNetworkUpdateStage(NetworkUpdateStage.Initialization);
				};
				return result;
			}
		}

		// Token: 0x02000032 RID: 50
		internal struct NetworkEarlyUpdate
		{
			// Token: 0x060001DA RID: 474 RVA: 0x0000A944 File Offset: 0x00008B44
			public static PlayerLoopSystem CreateLoopSystem()
			{
				PlayerLoopSystem result = default(PlayerLoopSystem);
				result.type = typeof(NetworkUpdateLoop.NetworkEarlyUpdate);
				result.updateDelegate = delegate()
				{
					NetworkUpdateLoop.RunNetworkUpdateStage(NetworkUpdateStage.EarlyUpdate);
				};
				return result;
			}
		}

		// Token: 0x02000034 RID: 52
		internal struct NetworkFixedUpdate
		{
			// Token: 0x060001DE RID: 478 RVA: 0x0000A9A8 File Offset: 0x00008BA8
			public static PlayerLoopSystem CreateLoopSystem()
			{
				PlayerLoopSystem result = default(PlayerLoopSystem);
				result.type = typeof(NetworkUpdateLoop.NetworkFixedUpdate);
				result.updateDelegate = delegate()
				{
					NetworkUpdateLoop.RunNetworkUpdateStage(NetworkUpdateStage.FixedUpdate);
				};
				return result;
			}
		}

		// Token: 0x02000036 RID: 54
		internal struct NetworkPreUpdate
		{
			// Token: 0x060001E2 RID: 482 RVA: 0x0000AA0C File Offset: 0x00008C0C
			public static PlayerLoopSystem CreateLoopSystem()
			{
				PlayerLoopSystem result = default(PlayerLoopSystem);
				result.type = typeof(NetworkUpdateLoop.NetworkPreUpdate);
				result.updateDelegate = delegate()
				{
					NetworkUpdateLoop.RunNetworkUpdateStage(NetworkUpdateStage.PreUpdate);
				};
				return result;
			}
		}

		// Token: 0x02000038 RID: 56
		internal struct NetworkUpdate
		{
			// Token: 0x060001E6 RID: 486 RVA: 0x0000AA70 File Offset: 0x00008C70
			public static PlayerLoopSystem CreateLoopSystem()
			{
				PlayerLoopSystem result = default(PlayerLoopSystem);
				result.type = typeof(NetworkUpdateLoop.NetworkUpdate);
				result.updateDelegate = delegate()
				{
					NetworkUpdateLoop.RunNetworkUpdateStage(NetworkUpdateStage.Update);
				};
				return result;
			}
		}

		// Token: 0x0200003A RID: 58
		internal struct NetworkPreLateUpdate
		{
			// Token: 0x060001EA RID: 490 RVA: 0x0000AAD4 File Offset: 0x00008CD4
			public static PlayerLoopSystem CreateLoopSystem()
			{
				PlayerLoopSystem result = default(PlayerLoopSystem);
				result.type = typeof(NetworkUpdateLoop.NetworkPreLateUpdate);
				result.updateDelegate = delegate()
				{
					NetworkUpdateLoop.RunNetworkUpdateStage(NetworkUpdateStage.PreLateUpdate);
				};
				return result;
			}
		}

		// Token: 0x0200003C RID: 60
		internal struct NetworkPostScriptLateUpdate
		{
			// Token: 0x060001EE RID: 494 RVA: 0x0000AB38 File Offset: 0x00008D38
			public static PlayerLoopSystem CreateLoopSystem()
			{
				PlayerLoopSystem result = default(PlayerLoopSystem);
				result.type = typeof(NetworkUpdateLoop.NetworkPostScriptLateUpdate);
				result.updateDelegate = delegate()
				{
					NetworkUpdateLoop.RunNetworkUpdateStage(NetworkUpdateStage.PostScriptLateUpdate);
				};
				return result;
			}
		}

		// Token: 0x0200003E RID: 62
		internal struct NetworkPostLateUpdate
		{
			// Token: 0x060001F2 RID: 498 RVA: 0x0000AB9C File Offset: 0x00008D9C
			public static PlayerLoopSystem CreateLoopSystem()
			{
				PlayerLoopSystem result = default(PlayerLoopSystem);
				result.type = typeof(NetworkUpdateLoop.NetworkPostLateUpdate);
				result.updateDelegate = delegate()
				{
					NetworkUpdateLoop.RunNetworkUpdateStage(NetworkUpdateStage.PostLateUpdate);
				};
				return result;
			}
		}

		// Token: 0x02000040 RID: 64
		private enum LoopSystemPosition
		{
			// Token: 0x0400010D RID: 269
			After,
			// Token: 0x0400010E RID: 270
			Before
		}
	}
}
