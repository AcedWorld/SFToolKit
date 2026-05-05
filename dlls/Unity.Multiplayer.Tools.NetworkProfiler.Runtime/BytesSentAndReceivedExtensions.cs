using System;
using System.Collections.Generic;

namespace Unity.Multiplayer.Tools.NetworkProfiler.Runtime
{
	// Token: 0x0200000E RID: 14
	internal static class BytesSentAndReceivedExtensions
	{
		// Token: 0x06000027 RID: 39 RVA: 0x00002760 File Offset: 0x00000960
		public static BytesSentAndReceived Sum<T>(this IEnumerable<T> ts, Func<T, BytesSentAndReceived> f)
		{
			BytesSentAndReceived bytesSentAndReceived = default(BytesSentAndReceived);
			foreach (T arg in ts)
			{
				bytesSentAndReceived += f(arg);
			}
			return bytesSentAndReceived;
		}
	}
}
