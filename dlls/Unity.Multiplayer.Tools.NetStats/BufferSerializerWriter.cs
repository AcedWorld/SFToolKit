using System;
using System.Runtime.CompilerServices;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x0200002C RID: 44
	internal struct BufferSerializerWriter : IReaderWriter
	{
		// Token: 0x060000D8 RID: 216 RVA: 0x00003AF3 File Offset: 0x00001CF3
		public BufferSerializerWriter(FastBufferWriter writer)
		{
			this.m_Writer = writer;
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00003AFC File Offset: 0x00001CFC
		public bool IsReader
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00003AFF File Offset: 0x00001CFF
		public bool IsWriter
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00003B02 File Offset: 0x00001D02
		public FastBufferReader GetFastBufferReader()
		{
			throw new InvalidOperationException("Cannot retrieve a FastBufferReader from a serializer where IsReader = false");
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00003B0E File Offset: 0x00001D0E
		public FastBufferWriter GetFastBufferWriter()
		{
			return this.m_Writer;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00003B16 File Offset: 0x00001D16
		public void SerializeValue(ref string s, bool oneByteChars = false)
		{
			this.m_Writer.WriteValueSafe(s, oneByteChars);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00003B26 File Offset: 0x00001D26
		public void SerializeValue<[IsUnmanaged] T>(ref T[] array) where T : struct, ValueType
		{
			this.m_Writer.WriteValueSafe<T>(array, -1, 0);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00003B37 File Offset: 0x00001D37
		public void SerializeValue(ref byte value)
		{
			this.m_Writer.WriteByteSafe(value);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00003B46 File Offset: 0x00001D46
		public void SerializeValue<[IsUnmanaged] T>(ref T value) where T : struct, ValueType
		{
			this.m_Writer.WriteValueSafe<T>(value);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00003B54 File Offset: 0x00001D54
		public void SerializeNetworkSerializable<T>(ref T value) where T : INetworkSerializable, new()
		{
			this.m_Writer.WriteNetworkSerializable<T>(value);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00003B62 File Offset: 0x00001D62
		public bool PreCheck(int amount)
		{
			return this.m_Writer.TryBeginWrite(amount);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00003B70 File Offset: 0x00001D70
		public void SerializeValuePreChecked(ref string s, bool oneByteChars = false)
		{
			this.m_Writer.WriteValue(s, oneByteChars);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00003B80 File Offset: 0x00001D80
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T[] array) where T : struct, ValueType
		{
			this.m_Writer.WriteValue<T>(array, -1, 0);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00003B91 File Offset: 0x00001D91
		public void SerializeValuePreChecked(ref byte value)
		{
			this.m_Writer.WriteByte(value);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00003BA0 File Offset: 0x00001DA0
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value) where T : struct, ValueType
		{
			this.m_Writer.WriteValue<T>(value);
		}

		// Token: 0x04000051 RID: 81
		private FastBufferWriter m_Writer;
	}
}
