using System;
using Unity.Burst.CompilerServices;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000042 RID: 66
	internal static class DebugLightHierarchyExtensions
	{
		// Token: 0x06000220 RID: 544 RVA: 0x0000C434 File Offset: 0x0000A634
		[IgnoreWarning(1370)]
		public static bool IsEnabledFor(this DebugLightFilterMode mode, GPULightType gpuLightType, SpotLightShape spotLightShape)
		{
			switch (gpuLightType)
			{
			case GPULightType.Directional:
				return (mode & DebugLightFilterMode.DirectDirectional) > DebugLightFilterMode.None;
			case GPULightType.Point:
				return (mode & DebugLightFilterMode.DirectPunctual) > DebugLightFilterMode.None;
			case GPULightType.Spot:
			case GPULightType.ProjectorPyramid:
			case GPULightType.ProjectorBox:
				switch (spotLightShape)
				{
				case SpotLightShape.Cone:
					return (mode & DebugLightFilterMode.DirectSpotCone) > DebugLightFilterMode.None;
				case SpotLightShape.Pyramid:
					return (mode & DebugLightFilterMode.DirectSpotPyramid) > DebugLightFilterMode.None;
				case SpotLightShape.Box:
					return (mode & DebugLightFilterMode.DirectSpotBox) > DebugLightFilterMode.None;
				default:
					throw new ArgumentOutOfRangeException("spotLightShape");
				}
				break;
			case GPULightType.Tube:
				return (mode & DebugLightFilterMode.DirectTube) > DebugLightFilterMode.None;
			case GPULightType.Rectangle:
				return (mode & DebugLightFilterMode.DirectRectangle) > DebugLightFilterMode.None;
			default:
				throw new ArgumentOutOfRangeException("gpuLightType");
			}
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000C4C2 File Offset: 0x0000A6C2
		public static bool IsEnabledFor(this DebugLightFilterMode mode, ProbeSettings.ProbeType probeType)
		{
			if (probeType == ProbeSettings.ProbeType.ReflectionProbe)
			{
				return (mode & DebugLightFilterMode.IndirectReflectionProbe) > DebugLightFilterMode.None;
			}
			if (probeType == ProbeSettings.ProbeType.PlanarProbe)
			{
				return (mode & DebugLightFilterMode.IndirectPlanarProbe) > DebugLightFilterMode.None;
			}
			throw new ArgumentOutOfRangeException("probeType");
		}
	}
}
