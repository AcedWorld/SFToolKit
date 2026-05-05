using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000AA RID: 170
	internal class HDProbeSystemInternal : IDisposable
	{
		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060007D6 RID: 2006 RVA: 0x000497AD File Offset: 0x000479AD
		public IEnumerable<HDProbe> bakedProbes
		{
			get
			{
				HDProbeSystemInternal.RemoveDestroyedProbes(this.m_BakedProbes);
				return this.m_BakedProbes;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060007D7 RID: 2007 RVA: 0x000497C0 File Offset: 0x000479C0
		public IEnumerable<HDProbe> realtimeViewDependentProbes
		{
			get
			{
				HDProbeSystemInternal.RemoveDestroyedProbes(this.m_RealtimeViewDependentProbes);
				return this.m_RealtimeViewDependentProbes;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060007D8 RID: 2008 RVA: 0x000497D3 File Offset: 0x000479D3
		public IEnumerable<HDProbe> realtimeViewIndependentProbes
		{
			get
			{
				HDProbeSystemInternal.RemoveDestroyedProbes(this.m_RealtimeViewIndependentProbes);
				return this.m_RealtimeViewIndependentProbes;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060007D9 RID: 2009 RVA: 0x000497E6 File Offset: 0x000479E6
		public int bakedProbeCount
		{
			get
			{
				return this.m_BakedProbes.Count;
			}
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x000497F3 File Offset: 0x000479F3
		public void Dispose()
		{
			this.m_PlanarProbeCullingGroup.Dispose();
			this.m_PlanarProbeCullingGroup = null;
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x00049808 File Offset: 0x00047A08
		internal void RegisterProbe(HDProbe probe)
		{
			ProbeSettings settings = probe.settings;
			ProbeSettings.Mode mode = settings.mode;
			if (mode != ProbeSettings.Mode.Baked)
			{
				if (mode == ProbeSettings.Mode.Realtime)
				{
					ProbeSettings.ProbeType type = settings.type;
					if (type != ProbeSettings.ProbeType.ReflectionProbe)
					{
						if (type == ProbeSettings.ProbeType.PlanarProbe && !this.m_RealtimeViewDependentProbes.Contains(probe))
						{
							this.m_RealtimeViewDependentProbes.Add(probe);
						}
					}
					else if (!this.m_RealtimeViewIndependentProbes.Contains(probe))
					{
						this.m_RealtimeViewIndependentProbes.Add(probe);
					}
				}
			}
			else
			{
				this.m_BakedProbes.Add(probe);
			}
			if (settings.type == ProbeSettings.ProbeType.PlanarProbe && this.m_PlanarProbes.Add((PlanarReflectionProbe)probe))
			{
				if (this.m_PlanarProbeCount >= this.m_PlanarProbesArray.Length)
				{
					Array.Resize<PlanarReflectionProbe>(ref this.m_PlanarProbesArray, this.m_PlanarProbeCount * 2);
					Array.Resize<BoundingSphere>(ref this.m_PlanarProbeBounds, this.m_PlanarProbeCount * 2);
				}
				this.m_PlanarProbesArray[this.m_PlanarProbeCount] = (PlanarReflectionProbe)probe;
				this.m_PlanarProbeBounds[this.m_PlanarProbeCount] = ((PlanarReflectionProbe)probe).boundingSphere;
				this.m_PlanarProbeCount++;
			}
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x00049913 File Offset: 0x00047B13
		internal void UnregisterProbe(HDProbe probe)
		{
			this.m_BakedProbes.Remove(probe);
			this.m_RealtimeViewDependentProbes.Remove(probe);
			this.m_RealtimeViewIndependentProbes.Remove(probe);
			if (this.m_PlanarProbes.Remove(probe))
			{
				this.m_RebuildPlanarProbeArray = true;
			}
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x00049954 File Offset: 0x00047B54
		internal HDProbeCullState PrepareCull(Camera camera)
		{
			if (this.m_PlanarProbeCullingGroup == null)
			{
				return default(HDProbeCullState);
			}
			this.RebuildPlanarProbeArrayIfRequired();
			HDProbeSystemInternal.UpdateBoundsAndRemoveDestroyedProbes(this.m_PlanarProbesArray, this.m_PlanarProbeBounds, ref this.m_PlanarProbeCount);
			this.m_PlanarProbeCullingGroup.targetCamera = camera;
			this.m_PlanarProbeCullingGroup.SetBoundingSpheres(this.m_PlanarProbeBounds);
			this.m_PlanarProbeCullingGroup.SetBoundingSphereCount(this.m_PlanarProbeCount);
			BoundingSphere[] planarProbeBounds = this.m_PlanarProbeBounds;
			HDProbe[] planarProbesArray = this.m_PlanarProbesArray;
			Hash128 stateHash = HDProbeSystemInternal.ComputeStateHashDebug(planarProbeBounds, planarProbesArray, this.m_PlanarProbeCount);
			CullingGroup planarProbeCullingGroup = this.m_PlanarProbeCullingGroup;
			planarProbesArray = this.m_PlanarProbesArray;
			return new HDProbeCullState(planarProbeCullingGroup, planarProbesArray, stateHash);
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x000499EC File Offset: 0x00047BEC
		private void RebuildPlanarProbeArrayIfRequired()
		{
			if (this.m_RebuildPlanarProbeArray)
			{
				HDProbeSystemInternal.RemoveDestroyedProbes(this.m_PlanarProbes);
				this.m_RebuildPlanarProbeArray = false;
				int num = 0;
				foreach (HDProbe hdprobe in this.m_PlanarProbes)
				{
					this.m_PlanarProbesArray[num] = (PlanarReflectionProbe)hdprobe;
					num++;
				}
				this.m_PlanarProbeCount = this.m_PlanarProbes.Count;
			}
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x00049A78 File Offset: 0x00047C78
		internal void QueryCullResults(HDProbeCullState state, ref HDProbeCullingResults results)
		{
			BoundingSphere[] planarProbeBounds = this.m_PlanarProbeBounds;
			HDProbe[] planarProbesArray = this.m_PlanarProbesArray;
			HDProbeSystemInternal.ComputeStateHashDebug(planarProbeBounds, planarProbesArray, this.m_PlanarProbeCount);
			results.Reset();
			Array.Resize<int>(ref this.m_QueryCullResults_Indices, this.Parameters.maxActivePlanarReflectionProbe + this.Parameters.maxActiveEnvReflectionProbe);
			int num = state.cullingGroup.QueryIndices(true, this.m_QueryCullResults_Indices, 0);
			for (int i = 0; i < num; i++)
			{
				results.AddProbe(state.hdProbes[this.m_QueryCullResults_Indices[i]]);
			}
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x00049B00 File Offset: 0x00047D00
		private static void RemoveDestroyedProbes(HashSet<HDProbe> probes)
		{
			probes.RemoveWhere((HDProbe p) => p == null || p.Equals(null));
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x00049B28 File Offset: 0x00047D28
		private static void UpdateBoundsAndRemoveDestroyedProbes(PlanarReflectionProbe[] probes, BoundingSphere[] bounds, ref int count)
		{
			for (int i = 0; i < count; i++)
			{
				if (probes[i] == null || probes[i].Equals(null))
				{
					probes[i] = probes[count - 1];
					bounds[i] = bounds[count - 1];
					probes[count - 1] = null;
					count--;
				}
				if (probes[i])
				{
					bounds[i] = probes[i].boundingSphere;
				}
			}
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x00049B98 File Offset: 0x00047D98
		private static Hash128 ComputeStateHashDebug(BoundingSphere[] probeBounds, HDProbe[] probes, int probeCount)
		{
			return default(Hash128);
		}

		// Token: 0x04000790 RID: 1936
		private HashSet<HDProbe> m_BakedProbes = new HashSet<HDProbe>();

		// Token: 0x04000791 RID: 1937
		private HashSet<HDProbe> m_RealtimeViewDependentProbes = new HashSet<HDProbe>();

		// Token: 0x04000792 RID: 1938
		private HashSet<HDProbe> m_RealtimeViewIndependentProbes = new HashSet<HDProbe>();

		// Token: 0x04000793 RID: 1939
		private int m_PlanarProbeCount;

		// Token: 0x04000794 RID: 1940
		private bool m_RebuildPlanarProbeArray;

		// Token: 0x04000795 RID: 1941
		private HashSet<HDProbe> m_PlanarProbes = new HashSet<HDProbe>();

		// Token: 0x04000796 RID: 1942
		private PlanarReflectionProbe[] m_PlanarProbesArray = new PlanarReflectionProbe[32];

		// Token: 0x04000797 RID: 1943
		private BoundingSphere[] m_PlanarProbeBounds = new BoundingSphere[32];

		// Token: 0x04000798 RID: 1944
		private CullingGroup m_PlanarProbeCullingGroup = new CullingGroup();

		// Token: 0x04000799 RID: 1945
		public ReflectionSystemParameters Parameters;

		// Token: 0x0400079A RID: 1946
		private int[] m_QueryCullResults_Indices;
	}
}
