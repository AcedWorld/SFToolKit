using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000034 RID: 52
	public static class CommandBufferPool
	{
		// Token: 0x060001FB RID: 507 RVA: 0x0000A2B9 File Offset: 0x000084B9
		public static CommandBuffer Get()
		{
			CommandBuffer commandBuffer = CommandBufferPool.s_BufferPool.Get();
			commandBuffer.name = "";
			return commandBuffer;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000A2D0 File Offset: 0x000084D0
		public static CommandBuffer Get(string name)
		{
			CommandBuffer commandBuffer = CommandBufferPool.s_BufferPool.Get();
			commandBuffer.name = name;
			return commandBuffer;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000A2E3 File Offset: 0x000084E3
		public static void Release(CommandBuffer buffer)
		{
			CommandBufferPool.s_BufferPool.Release(buffer);
		}

		// Token: 0x04000137 RID: 311
		private static ObjectPool<CommandBuffer> s_BufferPool = new ObjectPool<CommandBuffer>(null, delegate(CommandBuffer x)
		{
			x.Clear();
		}, true);
	}
}
