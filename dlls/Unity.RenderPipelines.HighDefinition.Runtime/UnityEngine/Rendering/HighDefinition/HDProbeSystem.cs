using System;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000A9 RID: 169
	internal static class HDProbeSystem
	{
		// Token: 0x060007C6 RID: 1990 RVA: 0x000495B8 File Offset: 0x000477B8
		static HDProbeSystem()
		{
			Application.quitting += HDProbeSystem.DisposeStaticInstance;
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x000495D5 File Offset: 0x000477D5
		private static void DisposeStaticInstance()
		{
			HDProbeSystem.s_Instance.Dispose();
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060007C8 RID: 1992 RVA: 0x000495E1 File Offset: 0x000477E1
		// (set) Token: 0x060007C9 RID: 1993 RVA: 0x000495ED File Offset: 0x000477ED
		public static ReflectionSystemParameters Parameters
		{
			get
			{
				return HDProbeSystem.s_Instance.Parameters;
			}
			set
			{
				HDProbeSystem.s_Instance.Parameters = value;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060007CA RID: 1994 RVA: 0x000495FA File Offset: 0x000477FA
		public static IEnumerable<HDProbe> realtimeViewDependentProbes
		{
			get
			{
				return HDProbeSystem.s_Instance.realtimeViewDependentProbes;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060007CB RID: 1995 RVA: 0x00049606 File Offset: 0x00047806
		public static IEnumerable<HDProbe> realtimeViewIndependentProbes
		{
			get
			{
				return HDProbeSystem.s_Instance.realtimeViewIndependentProbes;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060007CC RID: 1996 RVA: 0x00049612 File Offset: 0x00047812
		public static IEnumerable<HDProbe> bakedProbes
		{
			get
			{
				return HDProbeSystem.s_Instance.bakedProbes;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060007CD RID: 1997 RVA: 0x0004961E File Offset: 0x0004781E
		public static int bakedProbeCount
		{
			get
			{
				return HDProbeSystem.s_Instance.bakedProbeCount;
			}
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x0004962A File Offset: 0x0004782A
		public static void RegisterProbe(HDProbe probe)
		{
			HDProbeSystem.s_Instance.RegisterProbe(probe);
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x00049637 File Offset: 0x00047837
		public static void UnregisterProbe(HDProbe probe)
		{
			HDProbeSystem.s_Instance.UnregisterProbe(probe);
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x00049644 File Offset: 0x00047844
		public static void Render(HDProbe probe, Transform viewerTransform, Texture outTarget, out HDProbe.RenderData outRenderData, bool forceFlipY = false, float referenceFieldOfView = 90f, float referenceAspect = 1f)
		{
			ProbeCapturePositionSettings position = ProbeCapturePositionSettings.ComputeFrom(probe, viewerTransform);
			CameraSettings camera;
			CameraPositionSettings position2;
			HDRenderUtilities.Render(probe.settings, position, outTarget, out camera, out position2, forceFlipY, false, 0U, referenceFieldOfView, referenceAspect);
			outRenderData = new HDProbe.RenderData(camera, position2);
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x0004967F File Offset: 0x0004787F
		public static void AssignRenderData(HDProbe probe, HDProbe.RenderData renderData, ProbeSettings.Mode targetMode)
		{
			switch (targetMode)
			{
			case ProbeSettings.Mode.Baked:
				probe.bakedRenderData = renderData;
				return;
			case ProbeSettings.Mode.Realtime:
				probe.realtimeRenderData = renderData;
				return;
			case ProbeSettings.Mode.Custom:
				probe.customRenderData = renderData;
				return;
			default:
				return;
			}
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x000496AB File Offset: 0x000478AB
		public static HDProbeCullState PrepareCull(Camera camera)
		{
			return HDProbeSystem.s_Instance.PrepareCull(camera);
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x000496B8 File Offset: 0x000478B8
		public static void QueryCullResults(HDProbeCullState state, ref HDProbeCullingResults results)
		{
			HDProbeSystem.s_Instance.QueryCullResults(state, ref results);
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x000496C8 File Offset: 0x000478C8
		public static Texture CreateRenderTargetForMode(HDProbe probe, ProbeSettings.Mode targetMode)
		{
			Texture result = null;
			HDRenderPipeline hdrenderPipeline = (HDRenderPipeline)RenderPipelineManager.currentPipeline;
			ProbeSettings settings = probe.settings;
			switch (targetMode)
			{
			case ProbeSettings.Mode.Baked:
			case ProbeSettings.Mode.Custom:
			{
				GraphicsFormat format = GraphicsFormat.R16G16B16A16_SFloat;
				ProbeSettings.ProbeType type = settings.type;
				if (type != ProbeSettings.ProbeType.ReflectionProbe)
				{
					if (type == ProbeSettings.ProbeType.PlanarProbe)
					{
						result = HDRenderUtilities.CreatePlanarProbeRenderTarget((int)probe.resolution, format);
					}
				}
				else
				{
					result = HDRenderUtilities.CreateReflectionProbeRenderTarget((int)probe.cubeResolution, format);
				}
				break;
			}
			case ProbeSettings.Mode.Realtime:
			{
				GraphicsFormat reflectionProbeFormat = (GraphicsFormat)hdrenderPipeline.currentPlatformRenderPipelineSettings.lightLoopSettings.reflectionProbeFormat;
				ProbeSettings.ProbeType type = settings.type;
				if (type != ProbeSettings.ProbeType.ReflectionProbe)
				{
					if (type == ProbeSettings.ProbeType.PlanarProbe)
					{
						result = HDRenderUtilities.CreatePlanarProbeRenderTarget((int)probe.resolution, reflectionProbeFormat);
					}
				}
				else
				{
					result = HDRenderUtilities.CreateReflectionProbeRenderTarget((int)probe.cubeResolution, reflectionProbeFormat);
				}
				break;
			}
			}
			return result;
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x00049774 File Offset: 0x00047974
		private static Texture CreateAndSetRenderTargetIfRequired(HDProbe probe, ProbeSettings.Mode targetMode)
		{
			ProbeSettings settings = probe.settings;
			Texture texture = probe.GetTexture(targetMode);
			if (texture != null)
			{
				return texture;
			}
			texture = HDProbeSystem.CreateRenderTargetForMode(probe, targetMode);
			probe.SetTexture(targetMode, texture);
			return texture;
		}

		// Token: 0x0400078F RID: 1935
		private static HDProbeSystemInternal s_Instance = new HDProbeSystemInternal();
	}
}
