using System;

namespace Unity.Netcode
{
	// Token: 0x020000D9 RID: 217
	public class RpcFallbackSerialization
	{
		// Token: 0x06000527 RID: 1319 RVA: 0x00015AA8 File Offset: 0x00013CA8
		public static void Write<T>(FastBufferWriter writer, ref T value)
		{
			NetworkVariableSerialization<T>.Write(writer, ref value);
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x00015AB1 File Offset: 0x00013CB1
		public static void Read<T>(FastBufferReader reader, ref T value)
		{
			NetworkVariableSerialization<T>.Read(reader, ref value);
		}
	}
}
