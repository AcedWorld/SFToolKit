using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.LowLevel
{
	// Token: 0x0200032D RID: 813
	[MovedFrom("UnityEngine.Experimental.LowLevel")]
	public class PlayerLoop
	{
		// Token: 0x060020D1 RID: 8401 RVA: 0x00036604 File Offset: 0x00034804
		public static PlayerLoopSystem GetDefaultPlayerLoop()
		{
			PlayerLoopSystemInternal[] defaultPlayerLoopInternal = PlayerLoop.GetDefaultPlayerLoopInternal();
			int num = 0;
			return PlayerLoop.InternalToPlayerLoopSystem(defaultPlayerLoopInternal, ref num);
		}

		// Token: 0x060020D2 RID: 8402 RVA: 0x00036628 File Offset: 0x00034828
		public static PlayerLoopSystem GetCurrentPlayerLoop()
		{
			PlayerLoopSystemInternal[] currentPlayerLoopInternal = PlayerLoop.GetCurrentPlayerLoopInternal();
			int num = 0;
			return PlayerLoop.InternalToPlayerLoopSystem(currentPlayerLoopInternal, ref num);
		}

		// Token: 0x060020D3 RID: 8403 RVA: 0x0003664C File Offset: 0x0003484C
		public static void SetPlayerLoop(PlayerLoopSystem loop)
		{
			List<PlayerLoopSystemInternal> list = new List<PlayerLoopSystemInternal>();
			PlayerLoop.PlayerLoopSystemToInternal(loop, ref list);
			PlayerLoop.SetPlayerLoopInternal(list.ToArray());
		}

		// Token: 0x060020D4 RID: 8404 RVA: 0x00036678 File Offset: 0x00034878
		private static int PlayerLoopSystemToInternal(PlayerLoopSystem sys, ref List<PlayerLoopSystemInternal> internalSys)
		{
			int count = internalSys.Count;
			PlayerLoopSystemInternal playerLoopSystemInternal = new PlayerLoopSystemInternal
			{
				type = sys.type,
				updateDelegate = sys.updateDelegate,
				updateFunction = sys.updateFunction,
				loopConditionFunction = sys.loopConditionFunction,
				numSubSystems = 0
			};
			internalSys.Add(playerLoopSystemInternal);
			bool flag = sys.subSystemList != null;
			if (flag)
			{
				for (int i = 0; i < sys.subSystemList.Length; i++)
				{
					playerLoopSystemInternal.numSubSystems += PlayerLoop.PlayerLoopSystemToInternal(sys.subSystemList[i], ref internalSys);
				}
			}
			internalSys[count] = playerLoopSystemInternal;
			return playerLoopSystemInternal.numSubSystems + 1;
		}

		// Token: 0x060020D5 RID: 8405 RVA: 0x00036744 File Offset: 0x00034944
		private static PlayerLoopSystem InternalToPlayerLoopSystem(PlayerLoopSystemInternal[] internalSys, ref int offset)
		{
			PlayerLoopSystem result = new PlayerLoopSystem
			{
				type = internalSys[offset].type,
				updateDelegate = internalSys[offset].updateDelegate,
				updateFunction = internalSys[offset].updateFunction,
				loopConditionFunction = internalSys[offset].loopConditionFunction,
				subSystemList = null
			};
			int num = offset;
			offset = num + 1;
			int num2 = num;
			bool flag = internalSys[num2].numSubSystems > 0;
			if (flag)
			{
				List<PlayerLoopSystem> list = new List<PlayerLoopSystem>();
				while (offset <= num2 + internalSys[num2].numSubSystems)
				{
					list.Add(PlayerLoop.InternalToPlayerLoopSystem(internalSys, ref offset));
				}
				result.subSystemList = list.ToArray();
			}
			return result;
		}

		// Token: 0x060020D6 RID: 8406
		[NativeMethod(IsFreeFunction = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern PlayerLoopSystemInternal[] GetDefaultPlayerLoopInternal();

		// Token: 0x060020D7 RID: 8407
		[NativeMethod(IsFreeFunction = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern PlayerLoopSystemInternal[] GetCurrentPlayerLoopInternal();

		// Token: 0x060020D8 RID: 8408
		[NativeMethod(IsFreeFunction = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetPlayerLoopInternal(PlayerLoopSystemInternal[] loop);
	}
}
