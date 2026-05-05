using System;

namespace Unity.Netcode
{
	// Token: 0x020000CE RID: 206
	public class UserNetworkVariableSerialization<T>
	{
		// Token: 0x04000265 RID: 613
		public static UserNetworkVariableSerialization<T>.WriteValueDelegate WriteValue;

		// Token: 0x04000266 RID: 614
		public static UserNetworkVariableSerialization<T>.ReadValueDelegate ReadValue;

		// Token: 0x04000267 RID: 615
		public static UserNetworkVariableSerialization<T>.WriteDeltaDelegate WriteDelta;

		// Token: 0x04000268 RID: 616
		public static UserNetworkVariableSerialization<T>.ReadDeltaDelegate ReadDelta;

		// Token: 0x04000269 RID: 617
		public static UserNetworkVariableSerialization<T>.DuplicateValueDelegate DuplicateValue;

		// Token: 0x020000CF RID: 207
		// (Invoke) Token: 0x060004E1 RID: 1249
		public delegate void WriteValueDelegate(FastBufferWriter writer, in T value);

		// Token: 0x020000D0 RID: 208
		// (Invoke) Token: 0x060004E5 RID: 1253
		public delegate void WriteDeltaDelegate(FastBufferWriter writer, in T value, in T previousValue);

		// Token: 0x020000D1 RID: 209
		// (Invoke) Token: 0x060004E9 RID: 1257
		public delegate void ReadValueDelegate(FastBufferReader reader, out T value);

		// Token: 0x020000D2 RID: 210
		// (Invoke) Token: 0x060004ED RID: 1261
		public delegate void ReadDeltaDelegate(FastBufferReader reader, ref T value);

		// Token: 0x020000D3 RID: 211
		// (Invoke) Token: 0x060004F1 RID: 1265
		public delegate void DuplicateValueDelegate(in T value, ref T duplicatedValue);
	}
}
