using System;
using Unity.Profiling;
using UnityEngine.Profiling;

namespace UnityEngine.Rendering
{
	// Token: 0x02000078 RID: 120
	[IgnoredByDeepProfiler]
	public class ProfilingSampler
	{
		// Token: 0x060003B6 RID: 950 RVA: 0x0001008C File Offset: 0x0000E28C
		public static ProfilingSampler Get<TEnum>(TEnum marker) where TEnum : Enum
		{
			TProfilingSampler<TEnum> result;
			TProfilingSampler<TEnum>.samples.TryGetValue(marker, out result);
			return result;
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x000100A8 File Offset: 0x0000E2A8
		public ProfilingSampler(string name)
		{
			this.sampler = CustomSampler.Create(name, true);
			this.inlineSampler = CustomSampler.Create("Inl_" + name, false);
			this.name = name;
			this.m_Recorder = this.sampler.GetRecorder();
			this.m_Recorder.enabled = false;
			this.m_InlineRecorder = this.inlineSampler.GetRecorder();
			this.m_InlineRecorder.enabled = false;
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00010120 File Offset: 0x0000E320
		public void Begin(CommandBuffer cmd)
		{
			if (cmd != null)
			{
				if (this.sampler != null && this.sampler.isValid)
				{
					cmd.BeginSample(this.sampler);
					return;
				}
				cmd.BeginSample(this.name);
			}
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00010153 File Offset: 0x0000E353
		public void End(CommandBuffer cmd)
		{
			if (cmd != null)
			{
				if (this.sampler != null && this.sampler.isValid)
				{
					cmd.EndSample(this.sampler);
					return;
				}
				cmd.EndSample(this.name);
			}
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00010186 File Offset: 0x0000E386
		internal bool IsValid()
		{
			return this.sampler != null && this.inlineSampler != null;
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060003BB RID: 955 RVA: 0x0001019B File Offset: 0x0000E39B
		// (set) Token: 0x060003BC RID: 956 RVA: 0x000101A3 File Offset: 0x0000E3A3
		internal CustomSampler sampler { get; private set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060003BD RID: 957 RVA: 0x000101AC File Offset: 0x0000E3AC
		// (set) Token: 0x060003BE RID: 958 RVA: 0x000101B4 File Offset: 0x0000E3B4
		internal CustomSampler inlineSampler { get; private set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060003BF RID: 959 RVA: 0x000101BD File Offset: 0x0000E3BD
		// (set) Token: 0x060003C0 RID: 960 RVA: 0x000101C5 File Offset: 0x0000E3C5
		public string name { get; private set; }

		// Token: 0x1700008B RID: 139
		// (set) Token: 0x060003C1 RID: 961 RVA: 0x000101CE File Offset: 0x0000E3CE
		public bool enableRecording
		{
			set
			{
				this.m_Recorder.enabled = value;
				this.m_InlineRecorder.enabled = value;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x000101E8 File Offset: 0x0000E3E8
		public float gpuElapsedTime
		{
			get
			{
				if (!this.m_Recorder.enabled)
				{
					return 0f;
				}
				return (float)this.m_Recorder.gpuElapsedNanoseconds / 1000000f;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x0001020F File Offset: 0x0000E40F
		public int gpuSampleCount
		{
			get
			{
				if (!this.m_Recorder.enabled)
				{
					return 0;
				}
				return this.m_Recorder.gpuSampleBlockCount;
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x0001022B File Offset: 0x0000E42B
		public float cpuElapsedTime
		{
			get
			{
				if (!this.m_Recorder.enabled)
				{
					return 0f;
				}
				return (float)this.m_Recorder.elapsedNanoseconds / 1000000f;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x00010252 File Offset: 0x0000E452
		public int cpuSampleCount
		{
			get
			{
				if (!this.m_Recorder.enabled)
				{
					return 0;
				}
				return this.m_Recorder.sampleBlockCount;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060003C6 RID: 966 RVA: 0x0001026E File Offset: 0x0000E46E
		public float inlineCpuElapsedTime
		{
			get
			{
				if (!this.m_InlineRecorder.enabled)
				{
					return 0f;
				}
				return (float)this.m_InlineRecorder.elapsedNanoseconds / 1000000f;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060003C7 RID: 967 RVA: 0x00010295 File Offset: 0x0000E495
		public int inlineCpuSampleCount
		{
			get
			{
				if (!this.m_InlineRecorder.enabled)
				{
					return 0;
				}
				return this.m_InlineRecorder.sampleBlockCount;
			}
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x000102B1 File Offset: 0x0000E4B1
		private ProfilingSampler()
		{
		}

		// Token: 0x0400021A RID: 538
		private Recorder m_Recorder;

		// Token: 0x0400021B RID: 539
		private Recorder m_InlineRecorder;
	}
}
