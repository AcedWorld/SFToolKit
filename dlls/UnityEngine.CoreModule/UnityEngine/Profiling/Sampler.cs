using System;
using System.Collections.Generic;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Profiling
{
	// Token: 0x020002BC RID: 700
	[UsedByNativeCode]
	[NativeHeader("Runtime/Profiler/ScriptBindings/Sampler.bindings.h")]
	public class Sampler
	{
		// Token: 0x06001DFF RID: 7679 RVA: 0x00009E2F File Offset: 0x0000802F
		internal Sampler()
		{
		}

		// Token: 0x06001E00 RID: 7680 RVA: 0x00031783 File Offset: 0x0002F983
		internal Sampler(IntPtr ptr)
		{
			this.m_Ptr = ptr;
		}

		// Token: 0x170005EE RID: 1518
		// (get) Token: 0x06001E01 RID: 7681 RVA: 0x00031794 File Offset: 0x0002F994
		public bool isValid
		{
			get
			{
				return this.m_Ptr != IntPtr.Zero;
			}
		}

		// Token: 0x06001E02 RID: 7682 RVA: 0x000317B8 File Offset: 0x0002F9B8
		public Recorder GetRecorder()
		{
			ProfilerRecorderHandle handle = new ProfilerRecorderHandle((ulong)this.m_Ptr.ToInt64());
			return new Recorder(handle);
		}

		// Token: 0x06001E03 RID: 7683 RVA: 0x000317E4 File Offset: 0x0002F9E4
		public static Sampler Get(string name)
		{
			IntPtr marker = ProfilerUnsafeUtility.GetMarker(name);
			bool flag = marker == IntPtr.Zero;
			Sampler result;
			if (flag)
			{
				result = Sampler.s_InvalidSampler;
			}
			else
			{
				result = new Sampler(marker);
			}
			return result;
		}

		// Token: 0x06001E04 RID: 7684 RVA: 0x0003181C File Offset: 0x0002FA1C
		public static int GetNames(List<string> names)
		{
			List<ProfilerRecorderHandle> list = new List<ProfilerRecorderHandle>();
			ProfilerRecorderHandle.GetAvailable(list);
			bool flag = names != null;
			if (flag)
			{
				bool flag2 = names.Count < list.Count;
				if (flag2)
				{
					names.Capacity = list.Count;
					for (int i = names.Count; i < list.Count; i++)
					{
						names.Add(null);
					}
				}
				int num = 0;
				foreach (ProfilerRecorderHandle handle in list)
				{
					names[num] = ProfilerRecorderHandle.GetDescription(handle).Name;
					num++;
				}
			}
			return list.Count;
		}

		// Token: 0x170005EF RID: 1519
		// (get) Token: 0x06001E05 RID: 7685 RVA: 0x000318F8 File Offset: 0x0002FAF8
		public string name
		{
			get
			{
				return ProfilerUnsafeUtility.Internal_GetName(this.m_Ptr);
			}
		}

		// Token: 0x040009EA RID: 2538
		internal IntPtr m_Ptr;

		// Token: 0x040009EB RID: 2539
		internal static Sampler s_InvalidSampler = new Sampler();
	}
}
