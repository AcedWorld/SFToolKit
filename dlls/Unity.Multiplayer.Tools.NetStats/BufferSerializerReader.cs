using System;
using System.Runtime.CompilerServices;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x0200002B RID: 43
	internal struct BufferSerializerReader : IReaderWriter
	{
		// Token: 0x060000C9 RID: 201 RVA: 0x00003A42 File Offset: 0x00001C42
		public BufferSerializerReader(FastBufferReader reader)
		{
			this.m_Reader = reader;
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000CA RID: 202 RVA: 0x00003A4B File Offset: 0x00001C4B
		public bool IsReader
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00003A4E File Offset: 0x00001C4E
		public bool IsWriter
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00003A51 File Offset: 0x00001C51
		public FastBufferReader GetFastBufferReader()
		{
			return this.m_Reader;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00003A59 File Offset: 0x00001C59
		public FastBufferWriter GetFastBufferWriter()
		{
			throw new InvalidOperationException("Cannot retrieve a FastBufferWriter from a serializer where IsWriter = false");
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00003A65 File Offset: 0x00001C65
		public void SerializeValue(ref string s, bool oneByteChars = false)
		{
			this.m_Reader.ReadValueSafe(out s, oneByteChars);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00003A74 File Offset: 0x00001C74
		public void SerializeValue<[IsUnmanaged] T>(ref T[] array) where T : struct, ValueType
		{
			this.m_Reader.ReadValueSafe<T>(out array);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00003A82 File Offset: 0x00001C82
		public void SerializeValue(ref byte value)
		{
			this.m_Reader.ReadByteSafe(out value);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00003A90 File Offset: 0x00001C90
		public void SerializeValue<[IsUnmanaged] T>(ref T value) where T : struct, ValueType
		{
			this.m_Reader.ReadValueSafe<T>(out value);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00003A9E File Offset: 0x00001C9E
		public void SerializeNetworkSerializable<T>(ref T value) where T : INetworkSerializable, new()
		{
			this.m_Reader.ReadNetworkSerializable<T>(out value);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00003AAC File Offset: 0x00001CAC
		public bool PreCheck(int amount)
		{
			return this.m_Reader.TryBeginRead(amount);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00003ABA File Offset: 0x00001CBA
		public void SerializeValuePreChecked(ref string s, bool oneByteChars = false)
		{
			this.m_Reader.ReadValue(out s, oneByteChars);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00003AC9 File Offset: 0x00001CC9
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T[] array) where T : struct, ValueType
		{
			this.m_Reader.ReadValue<T>(out array);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00003AD7 File Offset: 0x00001CD7
		public void SerializeValuePreChecked(ref byte value)
		{
			this.m_Reader.ReadValue<byte>(out value);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00003AE5 File Offset: 0x00001CE5
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value) where T : struct, ValueType
		{
			this.m_Reader.ReadValue<T>(out value);
		}

		// Token: 0x04000050 RID: 80
		private FastBufferReader m_Reader;
	}
}
