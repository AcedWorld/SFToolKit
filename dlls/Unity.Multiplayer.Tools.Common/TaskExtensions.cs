using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x0200001E RID: 30
	internal static class TaskExtensions
	{
		// Token: 0x06000089 RID: 137 RVA: 0x00002EE9 File Offset: 0x000010E9
		public static void Forget(this Task task)
		{
			if (!task.IsCompleted || task.IsFaulted)
			{
				TaskExtensions.<Forget>g__ForgetAwaited|0_0(task, false);
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00002F04 File Offset: 0x00001104
		[CompilerGenerated]
		internal static Task <Forget>g__ForgetAwaited|0_0(Task task, bool logCanceledTask = false)
		{
			TaskExtensions.<<Forget>g__ForgetAwaited|0_0>d <<Forget>g__ForgetAwaited|0_0>d;
			<<Forget>g__ForgetAwaited|0_0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
			<<Forget>g__ForgetAwaited|0_0>d.task = task;
			<<Forget>g__ForgetAwaited|0_0>d.logCanceledTask = logCanceledTask;
			<<Forget>g__ForgetAwaited|0_0>d.<>1__state = -1;
			<<Forget>g__ForgetAwaited|0_0>d.<>t__builder.Start<TaskExtensions.<<Forget>g__ForgetAwaited|0_0>d>(ref <<Forget>g__ForgetAwaited|0_0>d);
			return <<Forget>g__ForgetAwaited|0_0>d.<>t__builder.Task;
		}
	}
}
