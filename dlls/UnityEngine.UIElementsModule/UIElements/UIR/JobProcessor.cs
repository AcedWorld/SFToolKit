using System;
using System.Runtime.CompilerServices;
using Unity.Jobs;
using UnityEngine.Bindings;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000425 RID: 1061
	[NativeHeader("ModuleOverrides/com.unity.ui/Core/Native/Renderer/UIRendererJobProcessor.h")]
	internal static class JobProcessor
	{
		// Token: 0x060021D0 RID: 8656 RVA: 0x0007F58C File Offset: 0x0007D78C
		internal static JobHandle ScheduleNudgeJobs(IntPtr buffer, int jobCount)
		{
			JobHandle result;
			JobProcessor.ScheduleNudgeJobs_Injected(buffer, jobCount, out result);
			return result;
		}

		// Token: 0x060021D1 RID: 8657 RVA: 0x0007F5A4 File Offset: 0x0007D7A4
		internal static JobHandle ScheduleConvertMeshJobs(IntPtr buffer, int jobCount)
		{
			JobHandle result;
			JobProcessor.ScheduleConvertMeshJobs_Injected(buffer, jobCount, out result);
			return result;
		}

		// Token: 0x060021D2 RID: 8658 RVA: 0x0007F5BC File Offset: 0x0007D7BC
		internal static JobHandle ScheduleCopyClosingMeshJobs(IntPtr buffer, int jobCount)
		{
			JobHandle result;
			JobProcessor.ScheduleCopyClosingMeshJobs_Injected(buffer, jobCount, out result);
			return result;
		}

		// Token: 0x060021D3 RID: 8659
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ScheduleNudgeJobs_Injected(IntPtr buffer, int jobCount, out JobHandle ret);

		// Token: 0x060021D4 RID: 8660
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ScheduleConvertMeshJobs_Injected(IntPtr buffer, int jobCount, out JobHandle ret);

		// Token: 0x060021D5 RID: 8661
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ScheduleCopyClosingMeshJobs_Injected(IntPtr buffer, int jobCount, out JobHandle ret);
	}
}
