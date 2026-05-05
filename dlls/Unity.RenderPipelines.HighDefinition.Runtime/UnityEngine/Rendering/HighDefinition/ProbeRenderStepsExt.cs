using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000A5 RID: 165
	public static class ProbeRenderStepsExt
	{
		// Token: 0x0600075E RID: 1886 RVA: 0x00048764 File Offset: 0x00046964
		public static bool IsNone(this ProbeRenderSteps steps)
		{
			return steps == ProbeRenderSteps.None;
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0004876C File Offset: 0x0004696C
		public static bool HasCubeFace(this ProbeRenderSteps steps, CubemapFace face)
		{
			ProbeRenderSteps probeRenderSteps = ProbeRenderStepsExt.FromCubeFace(face);
			return probeRenderSteps == ProbeRenderSteps.None || (steps & probeRenderSteps) == probeRenderSteps;
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x0004878B File Offset: 0x0004698B
		public static ProbeRenderSteps FromCubeFace(CubemapFace face)
		{
			switch (face)
			{
			case CubemapFace.PositiveX:
				return ProbeRenderSteps.CubeFace0;
			case CubemapFace.NegativeX:
				return ProbeRenderSteps.CubeFace1;
			case CubemapFace.PositiveY:
				return ProbeRenderSteps.CubeFace2;
			case CubemapFace.NegativeY:
				return ProbeRenderSteps.CubeFace3;
			case CubemapFace.PositiveZ:
				return ProbeRenderSteps.CubeFace4;
			case CubemapFace.NegativeZ:
				return ProbeRenderSteps.CubeFace5;
			default:
				return ProbeRenderSteps.Planar;
			}
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x000487BD File Offset: 0x000469BD
		public static ProbeRenderSteps FromProbeType(ProbeSettings.ProbeType probeType)
		{
			if (probeType == ProbeSettings.ProbeType.ReflectionProbe)
			{
				return ProbeRenderSteps.ReflectionProbeMask;
			}
			if (probeType != ProbeSettings.ProbeType.PlanarProbe)
			{
				return ProbeRenderSteps.None;
			}
			return ProbeRenderSteps.PlanarProbeMask;
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x000487D5 File Offset: 0x000469D5
		public static ProbeRenderSteps LowestSetBit(this ProbeRenderSteps steps)
		{
			return steps & -steps;
		}
	}
}
