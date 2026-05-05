using System;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine.Scripting;

namespace UnityEngine.Profiling
{
	// Token: 0x020002BB RID: 699
	[UsedByNativeCode]
	public sealed class Recorder
	{
		// Token: 0x06001DF0 RID: 7664 RVA: 0x00009E2F File Offset: 0x0000802F
		internal Recorder()
		{
		}

		// Token: 0x06001DF1 RID: 7665 RVA: 0x00031468 File Offset: 0x0002F668
		internal Recorder(ProfilerRecorderHandle handle)
		{
			bool flag = !handle.Valid;
			if (!flag)
			{
				this.m_RecorderCPU = new ProfilerRecorder(handle, 1, (ProfilerRecorderOptions)153);
				bool flag2 = (ProfilerRecorderHandle.GetDescription(handle).Flags & MarkerFlags.SampleGPU) > MarkerFlags.Default;
				if (flag2)
				{
					this.m_RecorderGPU = new ProfilerRecorder(handle, 1, (ProfilerRecorderOptions)217);
				}
			}
		}

		// Token: 0x06001DF2 RID: 7666 RVA: 0x000314CC File Offset: 0x0002F6CC
		~Recorder()
		{
			this.m_RecorderCPU.Dispose();
			this.m_RecorderGPU.Dispose();
		}

		// Token: 0x06001DF3 RID: 7667 RVA: 0x00031510 File Offset: 0x0002F710
		public static Recorder Get(string samplerName)
		{
			ProfilerRecorderHandle handle = ProfilerRecorderHandle.Get(ProfilerCategory.Any, samplerName);
			bool flag = !handle.Valid;
			Recorder result;
			if (flag)
			{
				result = Recorder.s_InvalidRecorder;
			}
			else
			{
				result = new Recorder(handle);
			}
			return result;
		}

		// Token: 0x170005E8 RID: 1512
		// (get) Token: 0x06001DF4 RID: 7668 RVA: 0x0003154C File Offset: 0x0002F74C
		public bool isValid
		{
			get
			{
				return this.m_RecorderCPU.handle > 0UL;
			}
		}

		// Token: 0x170005E9 RID: 1513
		// (get) Token: 0x06001DF5 RID: 7669 RVA: 0x00031570 File Offset: 0x0002F770
		// (set) Token: 0x06001DF6 RID: 7670 RVA: 0x0003158D File Offset: 0x0002F78D
		public bool enabled
		{
			get
			{
				return this.m_RecorderCPU.IsRunning;
			}
			set
			{
				this.SetEnabled(value);
			}
		}

		// Token: 0x170005EA RID: 1514
		// (get) Token: 0x06001DF7 RID: 7671 RVA: 0x00031598 File Offset: 0x0002F798
		public long elapsedNanoseconds
		{
			get
			{
				bool flag = !this.m_RecorderCPU.Valid;
				long result;
				if (flag)
				{
					result = 0L;
				}
				else
				{
					result = this.m_RecorderCPU.LastValue;
				}
				return result;
			}
		}

		// Token: 0x170005EB RID: 1515
		// (get) Token: 0x06001DF8 RID: 7672 RVA: 0x000315CC File Offset: 0x0002F7CC
		public long gpuElapsedNanoseconds
		{
			get
			{
				bool flag = !this.m_RecorderGPU.Valid;
				long result;
				if (flag)
				{
					result = 0L;
				}
				else
				{
					result = this.m_RecorderGPU.LastValue;
				}
				return result;
			}
		}

		// Token: 0x170005EC RID: 1516
		// (get) Token: 0x06001DF9 RID: 7673 RVA: 0x00031600 File Offset: 0x0002F800
		public int sampleBlockCount
		{
			get
			{
				bool flag = !this.m_RecorderCPU.Valid;
				int result;
				if (flag)
				{
					result = 0;
				}
				else
				{
					bool flag2 = this.m_RecorderCPU.Count != 1;
					if (flag2)
					{
						result = 0;
					}
					else
					{
						result = (int)this.m_RecorderCPU.GetSample(0).Count;
					}
				}
				return result;
			}
		}

		// Token: 0x170005ED RID: 1517
		// (get) Token: 0x06001DFA RID: 7674 RVA: 0x00031658 File Offset: 0x0002F858
		public int gpuSampleBlockCount
		{
			get
			{
				bool flag = !this.m_RecorderGPU.Valid;
				int result;
				if (flag)
				{
					result = 0;
				}
				else
				{
					bool flag2 = this.m_RecorderGPU.Count != 1;
					if (flag2)
					{
						result = 0;
					}
					else
					{
						result = (int)this.m_RecorderGPU.GetSample(0).Count;
					}
				}
				return result;
			}
		}

		// Token: 0x06001DFB RID: 7675 RVA: 0x000316B0 File Offset: 0x0002F8B0
		public void FilterToCurrentThread()
		{
			bool flag = !this.m_RecorderCPU.Valid;
			if (!flag)
			{
				this.m_RecorderCPU.FilterToCurrentThread();
			}
		}

		// Token: 0x06001DFC RID: 7676 RVA: 0x000316E0 File Offset: 0x0002F8E0
		public void CollectFromAllThreads()
		{
			bool flag = !this.m_RecorderCPU.Valid;
			if (!flag)
			{
				this.m_RecorderCPU.CollectFromAllThreads();
			}
		}

		// Token: 0x06001DFD RID: 7677 RVA: 0x00031710 File Offset: 0x0002F910
		private void SetEnabled(bool state)
		{
			if (state)
			{
				this.m_RecorderCPU.Start();
				bool valid = this.m_RecorderGPU.Valid;
				if (valid)
				{
					this.m_RecorderGPU.Start();
				}
			}
			else
			{
				this.m_RecorderCPU.Stop();
				bool valid2 = this.m_RecorderGPU.Valid;
				if (valid2)
				{
					this.m_RecorderGPU.Stop();
				}
			}
		}

		// Token: 0x040009E6 RID: 2534
		private const ProfilerRecorderOptions s_RecorderDefaultOptions = (ProfilerRecorderOptions)153;

		// Token: 0x040009E7 RID: 2535
		internal static Recorder s_InvalidRecorder = new Recorder();

		// Token: 0x040009E8 RID: 2536
		private ProfilerRecorder m_RecorderCPU;

		// Token: 0x040009E9 RID: 2537
		private ProfilerRecorder m_RecorderGPU;
	}
}
