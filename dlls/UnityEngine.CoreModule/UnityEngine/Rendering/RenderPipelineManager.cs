using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.Scripting;

namespace UnityEngine.Rendering
{
	// Token: 0x02000468 RID: 1128
	public static class RenderPipelineManager
	{
		// Token: 0x170006F8 RID: 1784
		// (get) Token: 0x060025E3 RID: 9699 RVA: 0x00040BCA File Offset: 0x0003EDCA
		// (set) Token: 0x060025E4 RID: 9700 RVA: 0x00040BD1 File Offset: 0x0003EDD1
		public static RenderPipeline currentPipeline
		{
			get
			{
				return RenderPipelineManager.s_CurrentPipeline;
			}
			private set
			{
				RenderPipelineManager.s_CurrentPipelineType = ((value != null) ? value.GetType().ToString() : "Built-in Pipeline");
				RenderPipelineManager.s_CurrentPipeline = value;
			}
		}

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x060025E5 RID: 9701 RVA: 0x00040BF4 File Offset: 0x0003EDF4
		// (remove) Token: 0x060025E6 RID: 9702 RVA: 0x00040C28 File Offset: 0x0003EE28
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<ScriptableRenderContext, Camera[]> beginFrameRendering;

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x060025E7 RID: 9703 RVA: 0x00040C5C File Offset: 0x0003EE5C
		// (remove) Token: 0x060025E8 RID: 9704 RVA: 0x00040C90 File Offset: 0x0003EE90
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<ScriptableRenderContext, Camera[]> endFrameRendering;

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x060025E9 RID: 9705 RVA: 0x00040CC4 File Offset: 0x0003EEC4
		// (remove) Token: 0x060025EA RID: 9706 RVA: 0x00040CF8 File Offset: 0x0003EEF8
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<ScriptableRenderContext, List<Camera>> beginContextRendering;

		// Token: 0x14000032 RID: 50
		// (add) Token: 0x060025EB RID: 9707 RVA: 0x00040D2C File Offset: 0x0003EF2C
		// (remove) Token: 0x060025EC RID: 9708 RVA: 0x00040D60 File Offset: 0x0003EF60
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<ScriptableRenderContext, List<Camera>> endContextRendering;

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x060025ED RID: 9709 RVA: 0x00040D94 File Offset: 0x0003EF94
		// (remove) Token: 0x060025EE RID: 9710 RVA: 0x00040DC8 File Offset: 0x0003EFC8
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<ScriptableRenderContext, Camera> beginCameraRendering;

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x060025EF RID: 9711 RVA: 0x00040DFC File Offset: 0x0003EFFC
		// (remove) Token: 0x060025F0 RID: 9712 RVA: 0x00040E30 File Offset: 0x0003F030
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<ScriptableRenderContext, Camera> endCameraRendering;

		// Token: 0x14000035 RID: 53
		// (add) Token: 0x060025F1 RID: 9713 RVA: 0x00040E64 File Offset: 0x0003F064
		// (remove) Token: 0x060025F2 RID: 9714 RVA: 0x00040E98 File Offset: 0x0003F098
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action activeRenderPipelineTypeChanged;

		// Token: 0x14000036 RID: 54
		// (add) Token: 0x060025F3 RID: 9715 RVA: 0x00040ECC File Offset: 0x0003F0CC
		// (remove) Token: 0x060025F4 RID: 9716 RVA: 0x00040F00 File Offset: 0x0003F100
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<RenderPipelineAsset, RenderPipelineAsset> activeRenderPipelineAssetChanged;

		// Token: 0x14000037 RID: 55
		// (add) Token: 0x060025F5 RID: 9717 RVA: 0x00040F34 File Offset: 0x0003F134
		// (remove) Token: 0x060025F6 RID: 9718 RVA: 0x00040F68 File Offset: 0x0003F168
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action activeRenderPipelineCreated;

		// Token: 0x14000038 RID: 56
		// (add) Token: 0x060025F7 RID: 9719 RVA: 0x00040F9C File Offset: 0x0003F19C
		// (remove) Token: 0x060025F8 RID: 9720 RVA: 0x00040FD0 File Offset: 0x0003F1D0
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action activeRenderPipelineDisposed;

		// Token: 0x170006F9 RID: 1785
		// (get) Token: 0x060025F9 RID: 9721 RVA: 0x00041003 File Offset: 0x0003F203
		public static bool pipelineSwitchCompleted
		{
			get
			{
				return RenderPipelineManager.s_CurrentPipelineAsset == GraphicsSettings.currentRenderPipeline && !RenderPipelineManager.IsPipelineRequireCreation();
			}
		}

		// Token: 0x060025FA RID: 9722 RVA: 0x0004101C File Offset: 0x0003F21C
		internal static void BeginContextRendering(ScriptableRenderContext context, List<Camera> cameras)
		{
			Action<ScriptableRenderContext, List<Camera>> action = RenderPipelineManager.beginContextRendering;
			if (action != null)
			{
				action(context, cameras);
			}
			Action<ScriptableRenderContext, Camera[]> action2 = RenderPipelineManager.beginFrameRendering;
			if (action2 != null)
			{
				action2(context, cameras.ToArray());
			}
		}

		// Token: 0x060025FB RID: 9723 RVA: 0x0004104A File Offset: 0x0003F24A
		internal static void BeginCameraRendering(ScriptableRenderContext context, Camera camera)
		{
			Action<ScriptableRenderContext, Camera> action = RenderPipelineManager.beginCameraRendering;
			if (action != null)
			{
				action(context, camera);
			}
		}

		// Token: 0x060025FC RID: 9724 RVA: 0x00041060 File Offset: 0x0003F260
		internal static void EndContextRendering(ScriptableRenderContext context, List<Camera> cameras)
		{
			Action<ScriptableRenderContext, Camera[]> action = RenderPipelineManager.endFrameRendering;
			if (action != null)
			{
				action(context, cameras.ToArray());
			}
			Action<ScriptableRenderContext, List<Camera>> action2 = RenderPipelineManager.endContextRendering;
			if (action2 != null)
			{
				action2(context, cameras);
			}
		}

		// Token: 0x060025FD RID: 9725 RVA: 0x0004108E File Offset: 0x0003F28E
		internal static void EndCameraRendering(ScriptableRenderContext context, Camera camera)
		{
			Action<ScriptableRenderContext, Camera> action = RenderPipelineManager.endCameraRendering;
			if (action != null)
			{
				action(context, camera);
			}
		}

		// Token: 0x060025FE RID: 9726 RVA: 0x000410A4 File Offset: 0x0003F2A4
		[RequiredByNativeCode]
		internal static void OnActiveRenderPipelineTypeChanged()
		{
			Action action = RenderPipelineManager.activeRenderPipelineTypeChanged;
			if (action != null)
			{
				action();
			}
		}

		// Token: 0x060025FF RID: 9727 RVA: 0x000410B8 File Offset: 0x0003F2B8
		[RequiredByNativeCode]
		internal static void OnActiveRenderPipelineAssetChanged(ScriptableObject from, ScriptableObject to)
		{
			Action<RenderPipelineAsset, RenderPipelineAsset> action = RenderPipelineManager.activeRenderPipelineAssetChanged;
			if (action != null)
			{
				action(from as RenderPipelineAsset, to as RenderPipelineAsset);
			}
		}

		// Token: 0x06002600 RID: 9728 RVA: 0x000410D8 File Offset: 0x0003F2D8
		[RequiredByNativeCode]
		internal static void HandleRenderPipelineChange(RenderPipelineAsset pipelineAsset)
		{
			bool flag = RenderPipelineManager.s_CurrentPipelineAsset != pipelineAsset;
			bool flag2 = flag;
			if (flag2)
			{
				RenderPipelineManager.CleanupRenderPipeline();
				RenderPipelineManager.s_CurrentPipelineAsset = pipelineAsset;
			}
		}

		// Token: 0x06002601 RID: 9729 RVA: 0x00041108 File Offset: 0x0003F308
		[RequiredByNativeCode]
		internal static void CleanupRenderPipeline()
		{
			bool flag = RenderPipelineManager.currentPipeline != null && !RenderPipelineManager.currentPipeline.disposed;
			if (flag)
			{
				Action action = RenderPipelineManager.activeRenderPipelineDisposed;
				if (action != null)
				{
					action();
				}
				RenderPipelineManager.currentPipeline.Dispose();
				RenderPipelineManager.s_CurrentPipelineAsset = null;
				RenderPipelineManager.currentPipeline = null;
				SupportedRenderingFeatures.active = new SupportedRenderingFeatures();
			}
		}

		// Token: 0x06002602 RID: 9730 RVA: 0x00041168 File Offset: 0x0003F368
		[RequiredByNativeCode]
		private static string GetCurrentPipelineAssetType()
		{
			return RenderPipelineManager.s_CurrentPipelineType;
		}

		// Token: 0x06002603 RID: 9731 RVA: 0x00041180 File Offset: 0x0003F380
		[RequiredByNativeCode]
		private static void DoRenderLoop_Internal(RenderPipelineAsset pipe, IntPtr loopPtr, Object renderRequest)
		{
			RenderPipelineManager.PrepareRenderPipeline(pipe);
			bool flag = RenderPipelineManager.currentPipeline == null;
			if (!flag)
			{
				ScriptableRenderContext context = new ScriptableRenderContext(loopPtr);
				RenderPipelineManager.s_Cameras.Clear();
				context.GetCameras(RenderPipelineManager.s_Cameras);
				bool flag2 = renderRequest == null;
				if (flag2)
				{
					RenderPipelineManager.currentPipeline.InternalRender(context, RenderPipelineManager.s_Cameras);
				}
				else
				{
					RenderPipelineManager.currentPipeline.InternalProcessRenderRequests<Object>(context, RenderPipelineManager.s_Cameras[0], renderRequest);
				}
				RenderPipelineManager.s_Cameras.Clear();
			}
		}

		// Token: 0x06002604 RID: 9732 RVA: 0x00041204 File Offset: 0x0003F404
		internal static void PrepareRenderPipeline(RenderPipelineAsset pipelineAsset)
		{
			RenderPipelineManager.HandleRenderPipelineChange(pipelineAsset);
			bool flag = RenderPipelineManager.IsPipelineRequireCreation();
			if (flag)
			{
				RenderPipelineManager.currentPipeline = RenderPipelineManager.s_CurrentPipelineAsset.InternalCreatePipeline();
				Action action = RenderPipelineManager.activeRenderPipelineCreated;
				if (action != null)
				{
					action();
				}
			}
		}

		// Token: 0x06002605 RID: 9733 RVA: 0x00041245 File Offset: 0x0003F445
		private static bool IsPipelineRequireCreation()
		{
			return RenderPipelineManager.s_CurrentPipelineAsset != null && (RenderPipelineManager.currentPipeline == null || RenderPipelineManager.currentPipeline.disposed);
		}

		// Token: 0x04000E5F RID: 3679
		internal static RenderPipelineAsset s_CurrentPipelineAsset;

		// Token: 0x04000E60 RID: 3680
		private static List<Camera> s_Cameras = new List<Camera>();

		// Token: 0x04000E61 RID: 3681
		private static string s_CurrentPipelineType = "Built-in Pipeline";

		// Token: 0x04000E62 RID: 3682
		private const string k_BuiltinPipelineName = "Built-in Pipeline";

		// Token: 0x04000E63 RID: 3683
		private static RenderPipeline s_CurrentPipeline = null;
	}
}
