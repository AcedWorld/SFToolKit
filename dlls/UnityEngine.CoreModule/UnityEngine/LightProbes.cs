using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x02000152 RID: 338
	[NativeHeader("Runtime/Export/Graphics/Graphics.bindings.h")]
	[StructLayout(LayoutKind.Sequential)]
	public sealed class LightProbes : Object
	{
		// Token: 0x06000A91 RID: 2705 RVA: 0x0001117A File Offset: 0x0000F37A
		private LightProbes()
		{
		}

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000A92 RID: 2706 RVA: 0x000111B0 File Offset: 0x0000F3B0
		// (remove) Token: 0x06000A93 RID: 2707 RVA: 0x000111E4 File Offset: 0x0000F3E4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action lightProbesUpdated;

		// Token: 0x06000A94 RID: 2708 RVA: 0x00011218 File Offset: 0x0000F418
		[RequiredByNativeCode]
		private static void Internal_CallLightProbesUpdatedFunction()
		{
			bool flag = LightProbes.lightProbesUpdated != null;
			if (flag)
			{
				LightProbes.lightProbesUpdated();
			}
		}

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x06000A95 RID: 2709 RVA: 0x00011240 File Offset: 0x0000F440
		// (remove) Token: 0x06000A96 RID: 2710 RVA: 0x00011274 File Offset: 0x0000F474
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action tetrahedralizationCompleted;

		// Token: 0x06000A97 RID: 2711 RVA: 0x000112A8 File Offset: 0x0000F4A8
		[RequiredByNativeCode]
		private static void Internal_CallTetrahedralizationCompletedFunction()
		{
			bool flag = LightProbes.tetrahedralizationCompleted != null;
			if (flag)
			{
				LightProbes.tetrahedralizationCompleted();
			}
		}

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x06000A98 RID: 2712 RVA: 0x000112D0 File Offset: 0x0000F4D0
		// (remove) Token: 0x06000A99 RID: 2713 RVA: 0x00011304 File Offset: 0x0000F504
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action needsRetetrahedralization;

		// Token: 0x06000A9A RID: 2714 RVA: 0x00011338 File Offset: 0x0000F538
		[RequiredByNativeCode]
		private static void Internal_CallNeedsRetetrahedralizationFunction()
		{
			bool flag = LightProbes.needsRetetrahedralization != null;
			if (flag)
			{
				LightProbes.needsRetetrahedralization();
			}
		}

		// Token: 0x06000A9B RID: 2715
		[FreeFunction]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Tetrahedralize();

		// Token: 0x06000A9C RID: 2716
		[FreeFunction]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void TetrahedralizeAsync();

		// Token: 0x06000A9D RID: 2717 RVA: 0x0001135D File Offset: 0x0000F55D
		[FreeFunction]
		public static void GetInterpolatedProbe(Vector3 position, Renderer renderer, out SphericalHarmonicsL2 probe)
		{
			LightProbes.GetInterpolatedProbe_Injected(ref position, renderer, out probe);
		}

		// Token: 0x06000A9E RID: 2718
		[FreeFunction]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool AreLightProbesAllowed(Renderer renderer);

		// Token: 0x06000A9F RID: 2719 RVA: 0x00011368 File Offset: 0x0000F568
		public static void CalculateInterpolatedLightAndOcclusionProbes(Vector3[] positions, SphericalHarmonicsL2[] lightProbes, Vector4[] occlusionProbes)
		{
			bool flag = positions == null;
			if (flag)
			{
				throw new ArgumentNullException("positions");
			}
			bool flag2 = lightProbes == null && occlusionProbes == null;
			if (flag2)
			{
				throw new ArgumentException("Argument lightProbes and occlusionProbes cannot both be null.");
			}
			bool flag3 = lightProbes != null && lightProbes.Length < positions.Length;
			if (flag3)
			{
				throw new ArgumentException("lightProbes", "Argument lightProbes has less elements than positions");
			}
			bool flag4 = occlusionProbes != null && occlusionProbes.Length < positions.Length;
			if (flag4)
			{
				throw new ArgumentException("occlusionProbes", "Argument occlusionProbes has less elements than positions");
			}
			LightProbes.CalculateInterpolatedLightAndOcclusionProbes_Internal(positions, positions.Length, lightProbes, occlusionProbes);
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x000113F4 File Offset: 0x0000F5F4
		public static void CalculateInterpolatedLightAndOcclusionProbes(List<Vector3> positions, List<SphericalHarmonicsL2> lightProbes, List<Vector4> occlusionProbes)
		{
			bool flag = positions == null;
			if (flag)
			{
				throw new ArgumentNullException("positions");
			}
			bool flag2 = lightProbes == null && occlusionProbes == null;
			if (flag2)
			{
				throw new ArgumentException("Argument lightProbes and occlusionProbes cannot both be null.");
			}
			bool flag3 = lightProbes != null;
			if (flag3)
			{
				bool flag4 = lightProbes.Capacity < positions.Count;
				if (flag4)
				{
					lightProbes.Capacity = positions.Count;
				}
				bool flag5 = lightProbes.Count < positions.Count;
				if (flag5)
				{
					NoAllocHelpers.ResizeList<SphericalHarmonicsL2>(lightProbes, positions.Count);
				}
			}
			bool flag6 = occlusionProbes != null;
			if (flag6)
			{
				bool flag7 = occlusionProbes.Capacity < positions.Count;
				if (flag7)
				{
					occlusionProbes.Capacity = positions.Count;
				}
				bool flag8 = occlusionProbes.Count < positions.Count;
				if (flag8)
				{
					NoAllocHelpers.ResizeList<Vector4>(occlusionProbes, positions.Count);
				}
			}
			LightProbes.CalculateInterpolatedLightAndOcclusionProbes_Internal(NoAllocHelpers.ExtractArrayFromListT<Vector3>(positions), positions.Count, NoAllocHelpers.ExtractArrayFromListT<SphericalHarmonicsL2>(lightProbes), NoAllocHelpers.ExtractArrayFromListT<Vector4>(occlusionProbes));
		}

		// Token: 0x06000AA1 RID: 2721
		[NativeName("CalculateInterpolatedLightAndOcclusionProbes")]
		[FreeFunction]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void CalculateInterpolatedLightAndOcclusionProbes_Internal([Unmarshalled] Vector3[] positions, int positionsCount, [Unmarshalled] SphericalHarmonicsL2[] lightProbes, [Unmarshalled] Vector4[] occlusionProbes);

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000AA2 RID: 2722
		public extern Vector3[] positions { [FreeFunction(HasExplicitThis = true)] [NativeName("GetLightProbePositions")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000AA3 RID: 2723
		// (set) Token: 0x06000AA4 RID: 2724
		public extern SphericalHarmonicsL2[] bakedProbes { [NativeName("GetBakedCoefficients")] [FreeFunction(HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; [FreeFunction(HasExplicitThis = true)] [NativeName("SetBakedCoefficients")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000AA5 RID: 2725
		public extern int count { [NativeName("GetLightProbeCount")] [FreeFunction(HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000AA6 RID: 2726
		public extern int cellCount { [FreeFunction(HasExplicitThis = true)] [NativeName("GetTetrahedraSize")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000AA7 RID: 2727
		[FreeFunction]
		[NativeName("GetLightProbeCount")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int GetCount();

		// Token: 0x06000AA8 RID: 2728 RVA: 0x00002669 File Offset: 0x00000869
		[Obsolete("Use GetInterpolatedProbe instead.", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetInterpolatedLightProbe(Vector3 position, Renderer renderer, float[] coefficients)
		{
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000AA9 RID: 2729 RVA: 0x000114E4 File Offset: 0x0000F6E4
		// (set) Token: 0x06000AAA RID: 2730 RVA: 0x00002669 File Offset: 0x00000869
		[Obsolete("Use bakedProbes instead.", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float[] coefficients
		{
			get
			{
				return new float[0];
			}
			set
			{
			}
		}

		// Token: 0x06000AAB RID: 2731
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetInterpolatedProbe_Injected(ref Vector3 position, Renderer renderer, out SphericalHarmonicsL2 probe);
	}
}
