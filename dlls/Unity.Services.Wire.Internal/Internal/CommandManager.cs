using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.Services.Core;
using Unity.Services.Core.Scheduler.Internal;
using Unity.Services.Wire.Protocol.Internal;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000017 RID: 23
	internal class CommandManager
	{
		// Token: 0x06000050 RID: 80 RVA: 0x00002E27 File Offset: 0x00001027
		public CommandManager(Configuration configuration, IActionScheduler actionScheduler)
		{
			this.m_Commands = new ConcurrentDictionary<uint, TaskCompletionSource<Reply>>();
			this.m_ActionScheduler = actionScheduler;
			this.Config = configuration;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002E48 File Offset: 0x00001048
		public void Clear()
		{
			this.m_Commands.Clear();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002E58 File Offset: 0x00001058
		public void RegisterCommand(uint id)
		{
			TaskCompletionSource<Reply> commandTCS = new TaskCompletionSource<Reply>();
			this.m_ActionScheduler.ScheduleAction(delegate
			{
				TaskCompletionSource<Reply> commandTCS = commandTCS;
				if (commandTCS == null)
				{
					return;
				}
				commandTCS.TrySetCanceled();
			}, this.Config.CommandTimeoutInSeconds);
			if (!this.m_Commands.TryAdd(id, commandTCS))
			{
				throw new CommandAlreadyExists(id);
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002EB4 File Offset: 0x000010B4
		public Task<Reply> WaitForCommandAsync(uint id)
		{
			CommandManager.<WaitForCommandAsync>d__6 <WaitForCommandAsync>d__;
			<WaitForCommandAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Reply>.Create();
			<WaitForCommandAsync>d__.<>4__this = this;
			<WaitForCommandAsync>d__.id = id;
			<WaitForCommandAsync>d__.<>1__state = -1;
			<WaitForCommandAsync>d__.<>t__builder.Start<CommandManager.<WaitForCommandAsync>d__6>(ref <WaitForCommandAsync>d__);
			return <WaitForCommandAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002F00 File Offset: 0x00001100
		public void OnDisconnect(Exception exceptionToThrow)
		{
			foreach (KeyValuePair<uint, TaskCompletionSource<Reply>> keyValuePair in this.m_Commands)
			{
				keyValuePair.Value.TrySetException(exceptionToThrow);
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002F54 File Offset: 0x00001154
		public void OnCommandReplyReceived(Reply reply)
		{
			TaskCompletionSource<Reply> taskCompletionSource;
			if (!this.m_Commands.TryGetValue(reply.id, out taskCompletionSource))
			{
				throw new UnknownCommandReplyException(reply.id);
			}
			if (reply.HasError())
			{
				taskCompletionSource.TrySetException(this.CentrifugeErrorToException(reply.error));
				return;
			}
			taskCompletionSource.TrySetResult(reply);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002FA6 File Offset: 0x000011A6
		private Exception CentrifugeErrorToException(Error error)
		{
			if (error.code == CentrifugeErrorCode.ErrorUnauthorized)
			{
				return new RequestFailedException(23007, error.message);
			}
			return new RequestFailedException(23000, error.message);
		}

		// Token: 0x04000076 RID: 118
		private readonly ConcurrentDictionary<uint, TaskCompletionSource<Reply>> m_Commands;

		// Token: 0x04000077 RID: 119
		public Configuration Config;

		// Token: 0x04000078 RID: 120
		private readonly IActionScheduler m_ActionScheduler;
	}
}
