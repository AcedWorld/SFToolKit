using System;
using System.Runtime.CompilerServices;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x0200002A RID: 42
	internal ref struct BufferSerializer<TReaderWriter> where TReaderWriter : IReaderWriter
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00003923 File Offset: 0x00001B23
		public bool IsReader
		{
			get
			{
				return this.m_Implementation.IsReader;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00003936 File Offset: 0x00001B36
		public bool IsWriter
		{
			get
			{
				return this.m_Implementation.IsWriter;
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00003949 File Offset: 0x00001B49
		internal BufferSerializer(TReaderWriter implementation)
		{
			this.m_Implementation = implementation;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00003952 File Offset: 0x00001B52
		public FastBufferReader GetFastBufferReader()
		{
			return this.m_Implementation.GetFastBufferReader();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00003965 File Offset: 0x00001B65
		public FastBufferWriter GetFastBufferWriter()
		{
			return this.m_Implementation.GetFastBufferWriter();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00003978 File Offset: 0x00001B78
		public void SerializeNetworkSerializable<T>(ref T value) where T : INetworkSerializable, new()
		{
			this.m_Implementation.SerializeNetworkSerializable<T>(ref value);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000398C File Offset: 0x00001B8C
		public void SerializeValue(ref string s, bool oneByteChars = false)
		{
			this.m_Implementation.SerializeValue(ref s, oneByteChars);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000039A1 File Offset: 0x00001BA1
		public void SerializeValue<[IsUnmanaged] T>(ref T[] array) where T : struct, ValueType
		{
			this.m_Implementation.SerializeValue<T>(ref array);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x000039B5 File Offset: 0x00001BB5
		public void SerializeValue(ref byte value)
		{
			this.m_Implementation.SerializeValue(ref value);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x000039C9 File Offset: 0x00001BC9
		public void SerializeValue<[IsUnmanaged] T>(ref T value) where T : struct, ValueType
		{
			this.m_Implementation.SerializeValue<T>(ref value);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000039DD File Offset: 0x00001BDD
		public bool PreCheck(int amount)
		{
			return this.m_Implementation.PreCheck(amount);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000039F1 File Offset: 0x00001BF1
		public void SerializeValuePreChecked(ref string s, bool oneByteChars = false)
		{
			this.m_Implementation.SerializeValuePreChecked(ref s, oneByteChars);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00003A06 File Offset: 0x00001C06
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T[] array) where T : struct, ValueType
		{
			this.m_Implementation.SerializeValuePreChecked<T>(ref array);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00003A1A File Offset: 0x00001C1A
		public void SerializeValuePreChecked(ref byte value)
		{
			this.m_Implementation.SerializeValuePreChecked(ref value);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00003A2E File Offset: 0x00001C2E
		public void SerializeValuePreChecked<[IsUnmanaged] T>(ref T value) where T : struct, ValueType
		{
			this.m_Implementation.SerializeValuePreChecked<T>(ref value);
		}

		// Token: 0x0400004F RID: 79
		private TReaderWriter m_Implementation;
	}
}
