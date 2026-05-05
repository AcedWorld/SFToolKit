using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000169 RID: 361
	public static class ApplicationVariables
	{
		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x060009A0 RID: 2464 RVA: 0x0002917E File Offset: 0x0002737E
		public static VariablesAsset asset
		{
			get
			{
				if (ApplicationVariables._asset == null)
				{
					ApplicationVariables.Load();
				}
				return ApplicationVariables._asset;
			}
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x00029197 File Offset: 0x00027397
		public static void Load()
		{
			ApplicationVariables._asset = (Resources.Load<VariablesAsset>("ApplicationVariables") ?? ScriptableObject.CreateInstance<VariablesAsset>());
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x060009A2 RID: 2466 RVA: 0x000291B1 File Offset: 0x000273B1
		// (set) Token: 0x060009A3 RID: 2467 RVA: 0x000291B8 File Offset: 0x000273B8
		public static VariableDeclarations runtime { get; private set; }

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x060009A4 RID: 2468 RVA: 0x000291C0 File Offset: 0x000273C0
		public static VariableDeclarations initial
		{
			get
			{
				return ApplicationVariables.asset.declarations;
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x060009A5 RID: 2469 RVA: 0x000291CC File Offset: 0x000273CC
		public static VariableDeclarations current
		{
			get
			{
				if (!Application.isPlaying)
				{
					return ApplicationVariables.initial;
				}
				return ApplicationVariables.runtime;
			}
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x000291E0 File Offset: 0x000273E0
		public static void OnEnterEditMode()
		{
			ApplicationVariables.DestroyRuntimeDeclarations();
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x000291E7 File Offset: 0x000273E7
		public static void OnExitEditMode()
		{
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x000291E9 File Offset: 0x000273E9
		internal static void OnEnterPlayMode()
		{
			ApplicationVariables.CreateRuntimeDeclarations();
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x000291F0 File Offset: 0x000273F0
		internal static void OnExitPlayMode()
		{
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x000291F2 File Offset: 0x000273F2
		private static void CreateRuntimeDeclarations()
		{
			ApplicationVariables.runtime = ApplicationVariables.asset.declarations.CloneViaFakeSerialization<VariableDeclarations>();
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x00029208 File Offset: 0x00027408
		private static void DestroyRuntimeDeclarations()
		{
			ApplicationVariables.runtime = null;
		}

		// Token: 0x04000241 RID: 577
		public const string assetPath = "ApplicationVariables";

		// Token: 0x04000242 RID: 578
		private static VariablesAsset _asset;
	}
}
