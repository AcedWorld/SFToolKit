using System;
using System.Runtime.CompilerServices;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000031 RID: 49
	internal interface IReaderWriter
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000133 RID: 307
		bool IsReader { get; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000134 RID: 308
		bool IsWriter { get; }

		// Token: 0x06000135 RID: 309
		FastBufferReader GetFastBufferReader();

		// Token: 0x06000136 RID: 310
		FastBufferWriter GetFastBufferWriter();

		// Token: 0x06000137 RID: 311
		void SerializeValue(ref string s, bool oneByteChars = false);

		// Token: 0x06000138 RID: 312
		void SerializeValue<[IsUnmanaged] T>(ref T[] array) where T : struct, ValueType;

		// Token: 0x06000139 RID: 313
		void SerializeValue(ref byte value);

		// Token: 0x0600013A RID: 314
		void SerializeValue<[IsUnmanaged] T>(ref T value) where T : struct, ValueType;

		// Token: 0x0600013B RID: 315
		void SerializeNetworkSerializable<T>(ref T value) where T : INetworkSerializable, new();

		// Token: 0x0600013C RID: 316
		bool PreCheck(int amount);

		// Token: 0x0600013D RID: 317
		void SerializeValuePreChecked(ref string s, bool oneByteChars = false);

		// Token: 0x0600013E RID: 318
		void SerializeValuePreChecked<[IsUnmanaged] T>(ref T[] array) where T : struct, ValueType;

		// Token: 0x0600013F RID: 319
		void SerializeValuePreChecked(ref byte value);

		// Token: 0x06000140 RID: 320
		void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value) where T : struct, ValueType;
	}
}
