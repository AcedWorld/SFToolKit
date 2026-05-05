using System;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace Unity.Networking.Transport.Utilities
{
	// Token: 0x020000C7 RID: 199
	public static class FixedStringHexExt
	{
		// Token: 0x060002FB RID: 763 RVA: 0x0001103C File Offset: 0x0000F23C
		public static FormatError AppendHex<[IsUnmanaged] T>(this T str, ushort val) where T : struct, ValueType, INativeList<byte>, IUTF8Bytes
		{
			int i = 12;
			while (i > 0 && (val >> i & 15) == 0)
			{
				i -= 4;
			}
			FormatError formatError = FormatError.None;
			while (i >= 0)
			{
				int num = val >> i & 15;
				if (num >= 10)
				{
					formatError |= ref str.AppendRawByte((byte)(97 + num - 10));
				}
				else
				{
					formatError |= ref str.AppendRawByte((byte)(48 + num));
				}
				i -= 4;
			}
			if (formatError == FormatError.None)
			{
				return FormatError.None;
			}
			return FormatError.Overflow;
		}
	}
}
