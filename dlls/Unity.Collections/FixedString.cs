using System;

namespace Unity.Collections
{
	// Token: 0x02000080 RID: 128
	[BurstCompatible]
	public static class FixedString
	{
		// Token: 0x0600043D RID: 1085 RVA: 0x0000C520 File Offset: 0x0000A720
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, int arg1, int arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x0000C58C File Offset: 0x0000A78C
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, int arg1, int arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x0000C5FC File Offset: 0x0000A7FC
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, int arg1, int arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x0000C668 File Offset: 0x0000A868
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, int arg1, int arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x0000C6C4 File Offset: 0x0000A8C4
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, float arg1, int arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x0000C734 File Offset: 0x0000A934
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, float arg1, int arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x0000C7A4 File Offset: 0x0000A9A4
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, float arg1, int arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x0000C814 File Offset: 0x0000AA14
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, float arg1, int arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x0000C874 File Offset: 0x0000AA74
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, string arg1, int arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x0000C8E0 File Offset: 0x0000AAE0
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, string arg1, int arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0000C950 File Offset: 0x0000AB50
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, string arg1, int arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0000C9BC File Offset: 0x0000ABBC
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, string arg1, int arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x0000CA18 File Offset: 0x0000AC18
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, T1 arg1, int arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x0000CA74 File Offset: 0x0000AC74
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, T1 arg1, int arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x0000CAD4 File Offset: 0x0000ACD4
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, T1 arg1, int arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x0000CB30 File Offset: 0x0000AD30
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, T2 arg1, int arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg2);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3);
			ref result.AppendFormat(formatString, arg0, arg1, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x0000CB7C File Offset: 0x0000AD7C
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, int arg1, float arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x0000CBEC File Offset: 0x0000ADEC
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, int arg1, float arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0000CC5C File Offset: 0x0000AE5C
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, int arg1, float arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x0000CCCC File Offset: 0x0000AECC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, int arg1, float arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0000CD2C File Offset: 0x0000AF2C
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, float arg1, float arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x0000CD9C File Offset: 0x0000AF9C
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, float arg1, float arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x0000CE10 File Offset: 0x0000B010
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, float arg1, float arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x0000CE80 File Offset: 0x0000B080
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, float arg1, float arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x0000CEE0 File Offset: 0x0000B0E0
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, string arg1, float arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x0000CF50 File Offset: 0x0000B150
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, string arg1, float arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x0000CFC0 File Offset: 0x0000B1C0
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, string arg1, float arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x0000D030 File Offset: 0x0000B230
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, string arg1, float arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x0000D090 File Offset: 0x0000B290
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, T1 arg1, float arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x0000D0F0 File Offset: 0x0000B2F0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, T1 arg1, float arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x0000D150 File Offset: 0x0000B350
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, T1 arg1, float arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x0000D1B0 File Offset: 0x0000B3B0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, T2 arg1, float arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3);
			ref result.AppendFormat(formatString, arg0, arg1, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x0000D1FC File Offset: 0x0000B3FC
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, int arg1, string arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x0000D268 File Offset: 0x0000B468
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, int arg1, string arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x0000D2D8 File Offset: 0x0000B4D8
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, int arg1, string arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x0000D344 File Offset: 0x0000B544
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, int arg1, string arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x0000D3A0 File Offset: 0x0000B5A0
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, float arg1, string arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x0000D410 File Offset: 0x0000B610
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, float arg1, string arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0000D480 File Offset: 0x0000B680
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, float arg1, string arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x0000D4F0 File Offset: 0x0000B6F0
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, float arg1, string arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x0000D550 File Offset: 0x0000B750
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, string arg1, string arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0000D5BC File Offset: 0x0000B7BC
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, string arg1, string arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x0000D62C File Offset: 0x0000B82C
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, string arg1, string arg2, int arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x0000D698 File Offset: 0x0000B898
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, string arg1, string arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x0000D6F4 File Offset: 0x0000B8F4
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, T1 arg1, string arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x0000D750 File Offset: 0x0000B950
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, T1 arg1, string arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x0000D7B0 File Offset: 0x0000B9B0
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, T1 arg1, string arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x0000D80C File Offset: 0x0000BA0C
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, T2 arg1, string arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg2);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3);
			ref result.AppendFormat(formatString, arg0, arg1, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0000D858 File Offset: 0x0000BA58
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, int arg1, T1 arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x0000D8B4 File Offset: 0x0000BAB4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, int arg1, T1 arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x0000D914 File Offset: 0x0000BB14
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, int arg1, T1 arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x0000D970 File Offset: 0x0000BB70
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, int arg1, T2 arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, arg2, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x0000D9BC File Offset: 0x0000BBBC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, float arg1, T1 arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x0000DA1C File Offset: 0x0000BC1C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, float arg1, T1 arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x0000DA7C File Offset: 0x0000BC7C
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, float arg1, T1 arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0000DADC File Offset: 0x0000BCDC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, float arg1, T2 arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, arg2, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x0000DB28 File Offset: 0x0000BD28
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, string arg1, T1 arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0000DB84 File Offset: 0x0000BD84
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, string arg1, T1 arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0000DBE4 File Offset: 0x0000BDE4
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, string arg1, T1 arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0000DC40 File Offset: 0x0000BE40
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, string arg1, T2 arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, arg2, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0000DC8C File Offset: 0x0000BE8C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, int arg0, T1 arg1, T2 arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, arg2, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0000DCD8 File Offset: 0x0000BED8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, float arg0, T1 arg1, T2 arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, arg2, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0000DD24 File Offset: 0x0000BF24
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, string arg0, T1 arg1, T2 arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, arg2, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0000DD70 File Offset: 0x0000BF70
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2, T3>(FixedString512Bytes formatString, T1 arg0, T2 arg1, T3 arg2, int arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg3);
			ref result.AppendFormat(formatString, arg0, arg1, arg2, fixedString32Bytes);
			return result;
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x0000DDAC File Offset: 0x0000BFAC
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, int arg1, int arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0000DE1C File Offset: 0x0000C01C
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, int arg1, int arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x0000DE8C File Offset: 0x0000C08C
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, int arg1, int arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x0000DEFC File Offset: 0x0000C0FC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, int arg1, int arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x0000DF5C File Offset: 0x0000C15C
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, float arg1, int arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x0000DFCC File Offset: 0x0000C1CC
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, float arg1, int arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x0000E040 File Offset: 0x0000C240
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, float arg1, int arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x0000E0B0 File Offset: 0x0000C2B0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, float arg1, int arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x0000E110 File Offset: 0x0000C310
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, string arg1, int arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x0000E180 File Offset: 0x0000C380
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, string arg1, int arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x0000E1F0 File Offset: 0x0000C3F0
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, string arg1, int arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x0000E260 File Offset: 0x0000C460
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, string arg1, int arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x0000E2C0 File Offset: 0x0000C4C0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, T1 arg1, int arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x0000E320 File Offset: 0x0000C520
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, T1 arg1, int arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x0000E380 File Offset: 0x0000C580
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, T1 arg1, int arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0000E3E0 File Offset: 0x0000C5E0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, T2 arg1, int arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg2);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3, '.');
			ref result.AppendFormat(formatString, arg0, arg1, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x0000E42C File Offset: 0x0000C62C
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, int arg1, float arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x0000E49C File Offset: 0x0000C69C
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, int arg1, float arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x0000E510 File Offset: 0x0000C710
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, int arg1, float arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0000E580 File Offset: 0x0000C780
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, int arg1, float arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x0000E5E0 File Offset: 0x0000C7E0
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, float arg1, float arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0000E654 File Offset: 0x0000C854
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, float arg1, float arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0000E6C8 File Offset: 0x0000C8C8
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, float arg1, float arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0000E73C File Offset: 0x0000C93C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, float arg1, float arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0000E7A0 File Offset: 0x0000C9A0
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, string arg1, float arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x0000E810 File Offset: 0x0000CA10
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, string arg1, float arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x0000E884 File Offset: 0x0000CA84
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, string arg1, float arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x0000E8F4 File Offset: 0x0000CAF4
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, string arg1, float arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x0000E954 File Offset: 0x0000CB54
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, T1 arg1, float arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0000E9B4 File Offset: 0x0000CBB4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, T1 arg1, float arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x0000EA18 File Offset: 0x0000CC18
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, T1 arg1, float arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x0000EA78 File Offset: 0x0000CC78
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, T2 arg1, float arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3, '.');
			ref result.AppendFormat(formatString, arg0, arg1, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x0000EAC8 File Offset: 0x0000CCC8
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, int arg1, string arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x0000EB38 File Offset: 0x0000CD38
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, int arg1, string arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0000EBA8 File Offset: 0x0000CDA8
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, int arg1, string arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x0000EC18 File Offset: 0x0000CE18
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, int arg1, string arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x0000EC78 File Offset: 0x0000CE78
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, float arg1, string arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x0000ECE8 File Offset: 0x0000CEE8
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, float arg1, string arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x0000ED5C File Offset: 0x0000CF5C
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, float arg1, string arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x0000EDCC File Offset: 0x0000CFCC
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, float arg1, string arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x0000EE2C File Offset: 0x0000D02C
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, string arg1, string arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x0000EE9C File Offset: 0x0000D09C
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, string arg1, string arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x0000EF0C File Offset: 0x0000D10C
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, string arg1, string arg2, float arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x0000EF7C File Offset: 0x0000D17C
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, string arg1, string arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x0000EFDC File Offset: 0x0000D1DC
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, T1 arg1, string arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x0000F03C File Offset: 0x0000D23C
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, T1 arg1, string arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x0000F09C File Offset: 0x0000D29C
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, T1 arg1, string arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x0000F0FC File Offset: 0x0000D2FC
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, T2 arg1, string arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg2);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3, '.');
			ref result.AppendFormat(formatString, arg0, arg1, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x0000F148 File Offset: 0x0000D348
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, int arg1, T1 arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x0000F1A8 File Offset: 0x0000D3A8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, int arg1, T1 arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x0000F208 File Offset: 0x0000D408
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, int arg1, T1 arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x0000F268 File Offset: 0x0000D468
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, int arg1, T2 arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, arg2, fixedString32Bytes2);
			return result;
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x0000F2B4 File Offset: 0x0000D4B4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, float arg1, T1 arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0000F314 File Offset: 0x0000D514
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, float arg1, T1 arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0000F378 File Offset: 0x0000D578
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, float arg1, T1 arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x0000F3D8 File Offset: 0x0000D5D8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, float arg1, T2 arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, arg2, fixedString32Bytes2);
			return result;
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x0000F428 File Offset: 0x0000D628
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, string arg1, T1 arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x0000F488 File Offset: 0x0000D688
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, string arg1, T1 arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x0000F4E8 File Offset: 0x0000D6E8
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, string arg1, T1 arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x0000F548 File Offset: 0x0000D748
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, string arg1, T2 arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, arg2, fixedString32Bytes2);
			return result;
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0000F594 File Offset: 0x0000D794
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, int arg0, T1 arg1, T2 arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, arg2, fixedString32Bytes2);
			return result;
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x0000F5E0 File Offset: 0x0000D7E0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, float arg0, T1 arg1, T2 arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, arg2, fixedString32Bytes2);
			return result;
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x0000F630 File Offset: 0x0000D830
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, string arg0, T1 arg1, T2 arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, arg2, fixedString32Bytes2);
			return result;
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0000F67C File Offset: 0x0000D87C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2, T3>(FixedString512Bytes formatString, T1 arg0, T2 arg1, T3 arg2, float arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg3, '.');
			ref result.AppendFormat(formatString, arg0, arg1, arg2, fixedString32Bytes);
			return result;
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0000F6B8 File Offset: 0x0000D8B8
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, int arg1, int arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0000F724 File Offset: 0x0000D924
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, int arg1, int arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0000F794 File Offset: 0x0000D994
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, int arg1, int arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0000F800 File Offset: 0x0000DA00
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, int arg1, int arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x0000F85C File Offset: 0x0000DA5C
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, float arg1, int arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x0000F8CC File Offset: 0x0000DACC
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, float arg1, int arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x0000F93C File Offset: 0x0000DB3C
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, float arg1, int arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x0000F9AC File Offset: 0x0000DBAC
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, float arg1, int arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x0000FA0C File Offset: 0x0000DC0C
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, string arg1, int arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x0000FA78 File Offset: 0x0000DC78
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, string arg1, int arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0000FAE8 File Offset: 0x0000DCE8
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, string arg1, int arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x0000FB54 File Offset: 0x0000DD54
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, string arg1, int arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x0000FBB0 File Offset: 0x0000DDB0
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, T1 arg1, int arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0000FC0C File Offset: 0x0000DE0C
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, T1 arg1, int arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x0000FC6C File Offset: 0x0000DE6C
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, T1 arg1, int arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x0000FCC8 File Offset: 0x0000DEC8
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, T2 arg1, int arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg2);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3);
			ref result.AppendFormat(formatString, arg0, arg1, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x0000FD14 File Offset: 0x0000DF14
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, int arg1, float arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x0000FD84 File Offset: 0x0000DF84
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, int arg1, float arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x0000FDF4 File Offset: 0x0000DFF4
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, int arg1, float arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x0000FE64 File Offset: 0x0000E064
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, int arg1, float arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x0000FEC4 File Offset: 0x0000E0C4
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, float arg1, float arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x0000FF34 File Offset: 0x0000E134
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, float arg1, float arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x0000FFA8 File Offset: 0x0000E1A8
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, float arg1, float arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00010018 File Offset: 0x0000E218
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, float arg1, float arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x00010078 File Offset: 0x0000E278
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, string arg1, float arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x000100E8 File Offset: 0x0000E2E8
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, string arg1, float arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00010158 File Offset: 0x0000E358
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, string arg1, float arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x000101C8 File Offset: 0x0000E3C8
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, string arg1, float arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00010228 File Offset: 0x0000E428
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, T1 arg1, float arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x00010288 File Offset: 0x0000E488
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, T1 arg1, float arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x000102E8 File Offset: 0x0000E4E8
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, T1 arg1, float arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00010348 File Offset: 0x0000E548
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, T2 arg1, float arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg2, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3);
			ref result.AppendFormat(formatString, arg0, arg1, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00010394 File Offset: 0x0000E594
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, int arg1, string arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00010400 File Offset: 0x0000E600
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, int arg1, string arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00010470 File Offset: 0x0000E670
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, int arg1, string arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x000104DC File Offset: 0x0000E6DC
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, int arg1, string arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00010538 File Offset: 0x0000E738
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, float arg1, string arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x000105A8 File Offset: 0x0000E7A8
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, float arg1, string arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00010618 File Offset: 0x0000E818
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, float arg1, string arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00010688 File Offset: 0x0000E888
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, float arg1, string arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x000106E8 File Offset: 0x0000E8E8
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, int arg0, string arg1, string arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x00010754 File Offset: 0x0000E954
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, float arg0, string arg1, string arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x000107C4 File Offset: 0x0000E9C4
		[NotBurstCompatible]
		public static FixedString512Bytes Format(FixedString512Bytes formatString, string arg0, string arg1, string arg2, string arg3)
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			FixedString32Bytes fixedString32Bytes4 = default(FixedString32Bytes);
			ref fixedString32Bytes4.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, fixedString32Bytes4);
			return result;
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x00010830 File Offset: 0x0000EA30
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, T1 arg0, string arg1, string arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0001088C File Offset: 0x0000EA8C
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, T1 arg1, string arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x000108E8 File Offset: 0x0000EAE8
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, T1 arg1, string arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x00010948 File Offset: 0x0000EB48
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, T1 arg1, string arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x000109A4 File Offset: 0x0000EBA4
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, T2 arg1, string arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg2);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3);
			ref result.AppendFormat(formatString, arg0, arg1, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x000109F0 File Offset: 0x0000EBF0
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, int arg1, T1 arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00010A4C File Offset: 0x0000EC4C
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, int arg1, T1 arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x00010AAC File Offset: 0x0000ECAC
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, int arg1, T1 arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x00010B08 File Offset: 0x0000ED08
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, int arg1, T2 arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, arg2, fixedString32Bytes2);
			return result;
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x00010B54 File Offset: 0x0000ED54
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, float arg1, T1 arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x00010BB4 File Offset: 0x0000EDB4
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, float arg1, T1 arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x00010C14 File Offset: 0x0000EE14
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, float arg1, T1 arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00010C74 File Offset: 0x0000EE74
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, float arg1, T2 arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, arg2, fixedString32Bytes2);
			return result;
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x00010CC0 File Offset: 0x0000EEC0
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, string arg1, T1 arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00010D1C File Offset: 0x0000EF1C
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, string arg1, T1 arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x00010D7C File Offset: 0x0000EF7C
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, string arg1, T1 arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00010DD8 File Offset: 0x0000EFD8
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, string arg1, T2 arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, arg2, fixedString32Bytes2);
			return result;
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00010E24 File Offset: 0x0000F024
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, int arg0, T1 arg1, T2 arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, arg2, fixedString32Bytes2);
			return result;
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x00010E70 File Offset: 0x0000F070
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, float arg0, T1 arg1, T2 arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, arg2, fixedString32Bytes2);
			return result;
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x00010EBC File Offset: 0x0000F0BC
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, string arg0, T1 arg1, T2 arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg3);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, arg2, fixedString32Bytes2);
			return result;
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00010F08 File Offset: 0x0000F108
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2, T3>(FixedString512Bytes formatString, T1 arg0, T2 arg1, T3 arg2, string arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg3);
			ref result.AppendFormat(formatString, arg0, arg1, arg2, fixedString32Bytes);
			return result;
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00010F44 File Offset: 0x0000F144
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, int arg1, int arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00010FA0 File Offset: 0x0000F1A0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, int arg1, int arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00010FFC File Offset: 0x0000F1FC
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, int arg1, int arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00011058 File Offset: 0x0000F258
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, int arg1, int arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, arg3);
			return result;
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x000110A4 File Offset: 0x0000F2A4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, float arg1, int arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x00011100 File Offset: 0x0000F300
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, float arg1, int arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x00011160 File Offset: 0x0000F360
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, float arg1, int arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x000111BC File Offset: 0x0000F3BC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, float arg1, int arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, arg3);
			return result;
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x00011208 File Offset: 0x0000F408
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, string arg1, int arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x00011264 File Offset: 0x0000F464
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, string arg1, int arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x000112C0 File Offset: 0x0000F4C0
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, string arg1, int arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x0001131C File Offset: 0x0000F51C
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, string arg1, int arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, arg3);
			return result;
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x00011368 File Offset: 0x0000F568
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, int arg0, T1 arg1, int arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, arg3);
			return result;
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x000113B4 File Offset: 0x0000F5B4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, float arg0, T1 arg1, int arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, arg3);
			return result;
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x00011400 File Offset: 0x0000F600
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, string arg0, T1 arg1, int arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, arg3);
			return result;
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x0001144C File Offset: 0x0000F64C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2, T3>(FixedString512Bytes formatString, T1 arg0, T2 arg1, int arg2, T3 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg2);
			ref result.AppendFormat(formatString, arg0, arg1, fixedString32Bytes, arg3);
			return result;
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x00011484 File Offset: 0x0000F684
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, int arg1, float arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x000114E0 File Offset: 0x0000F6E0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, int arg1, float arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x00011540 File Offset: 0x0000F740
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, int arg1, float arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x0001159C File Offset: 0x0000F79C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, int arg1, float arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, arg3);
			return result;
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x000115E8 File Offset: 0x0000F7E8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, float arg1, float arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x00011648 File Offset: 0x0000F848
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, float arg1, float arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x000116A8 File Offset: 0x0000F8A8
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, float arg1, float arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x00011708 File Offset: 0x0000F908
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, float arg1, float arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, arg3);
			return result;
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x00011758 File Offset: 0x0000F958
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, string arg1, float arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x000117B4 File Offset: 0x0000F9B4
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, string arg1, float arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x00011814 File Offset: 0x0000FA14
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, string arg1, float arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x00011870 File Offset: 0x0000FA70
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, string arg1, float arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, arg3);
			return result;
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x000118BC File Offset: 0x0000FABC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, int arg0, T1 arg1, float arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, arg3);
			return result;
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x00011908 File Offset: 0x0000FB08
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, float arg0, T1 arg1, float arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, arg3);
			return result;
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x00011958 File Offset: 0x0000FB58
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, string arg0, T1 arg1, float arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, arg3);
			return result;
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x000119A4 File Offset: 0x0000FBA4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2, T3>(FixedString512Bytes formatString, T1 arg0, T2 arg1, float arg2, T3 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg2, '.');
			ref result.AppendFormat(formatString, arg0, arg1, fixedString32Bytes, arg3);
			return result;
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x000119E0 File Offset: 0x0000FBE0
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, int arg1, string arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x00011A3C File Offset: 0x0000FC3C
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, int arg1, string arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x00011A98 File Offset: 0x0000FC98
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, int arg1, string arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x00011AF4 File Offset: 0x0000FCF4
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, int arg1, string arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, arg3);
			return result;
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x00011B40 File Offset: 0x0000FD40
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, float arg1, string arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x00011B9C File Offset: 0x0000FD9C
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, float arg1, string arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x00011BFC File Offset: 0x0000FDFC
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, float arg1, string arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x00011C58 File Offset: 0x0000FE58
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, float arg1, string arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, arg3);
			return result;
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x00011CA4 File Offset: 0x0000FEA4
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, int arg0, string arg1, string arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x00011D00 File Offset: 0x0000FF00
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, float arg0, string arg1, string arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x00011D5C File Offset: 0x0000FF5C
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1>(FixedString512Bytes formatString, string arg0, string arg1, string arg2, T1 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3, arg3);
			return result;
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x00011DB8 File Offset: 0x0000FFB8
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, T1 arg0, string arg1, string arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2, arg3);
			return result;
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x00011E04 File Offset: 0x00010004
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, int arg0, T1 arg1, string arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, arg3);
			return result;
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x00011E50 File Offset: 0x00010050
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, float arg0, T1 arg1, string arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, arg3);
			return result;
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x00011E9C File Offset: 0x0001009C
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, string arg0, T1 arg1, string arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2, arg3);
			return result;
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x00011EE8 File Offset: 0x000100E8
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2, T3>(FixedString512Bytes formatString, T1 arg0, T2 arg1, string arg2, T3 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg2);
			ref result.AppendFormat(formatString, arg0, arg1, fixedString32Bytes, arg3);
			return result;
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x00011F20 File Offset: 0x00010120
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, int arg0, int arg1, T1 arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, arg3);
			return result;
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x00011F6C File Offset: 0x0001016C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, float arg0, int arg1, T1 arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, arg3);
			return result;
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x00011FB8 File Offset: 0x000101B8
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, string arg0, int arg1, T1 arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, arg3);
			return result;
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x00012004 File Offset: 0x00010204
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2, T3>(FixedString512Bytes formatString, T1 arg0, int arg1, T2 arg2, T3 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, arg2, arg3);
			return result;
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x0001203C File Offset: 0x0001023C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, int arg0, float arg1, T1 arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, arg3);
			return result;
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x00012088 File Offset: 0x00010288
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, float arg0, float arg1, T1 arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, arg3);
			return result;
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x000120D8 File Offset: 0x000102D8
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, string arg0, float arg1, T1 arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, arg3);
			return result;
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x00012124 File Offset: 0x00010324
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2, T3>(FixedString512Bytes formatString, T1 arg0, float arg1, T2 arg2, T3 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, arg2, arg3);
			return result;
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x00012160 File Offset: 0x00010360
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, int arg0, string arg1, T1 arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, arg3);
			return result;
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x000121AC File Offset: 0x000103AC
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, float arg0, string arg1, T1 arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, arg3);
			return result;
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x000121F8 File Offset: 0x000103F8
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2>(FixedString512Bytes formatString, string arg0, string arg1, T1 arg2, T2 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2, arg3);
			return result;
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x00012244 File Offset: 0x00010444
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2, T3>(FixedString512Bytes formatString, T1 arg0, string arg1, T2 arg2, T3 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, arg2, arg3);
			return result;
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0001227C File Offset: 0x0001047C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2, T3>(FixedString512Bytes formatString, int arg0, T1 arg1, T2 arg2, T3 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, arg2, arg3);
			return result;
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x000122B4 File Offset: 0x000104B4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2, T3>(FixedString512Bytes formatString, float arg0, T1 arg1, T2 arg2, T3 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, arg2, arg3);
			return result;
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x000122F0 File Offset: 0x000104F0
		[NotBurstCompatible]
		public static FixedString512Bytes Format<T1, T2, T3>(FixedString512Bytes formatString, string arg0, T1 arg1, T2 arg2, T3 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, arg2, arg3);
			return result;
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x00012328 File Offset: 0x00010528
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString512Bytes Format<T1, T2, T3, T4>(FixedString512Bytes formatString, T1 arg0, T2 arg1, T3 arg2, T4 arg3) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes where T4 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString512Bytes result = default(FixedString512Bytes);
			ref result.AppendFormat(formatString, arg0, arg1, arg2, arg3);
			return result;
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x00012350 File Offset: 0x00010550
		public static FixedString128Bytes Format(FixedString128Bytes formatString, int arg0, int arg1, int arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x000123A8 File Offset: 0x000105A8
		public static FixedString128Bytes Format(FixedString128Bytes formatString, float arg0, int arg1, int arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x00012404 File Offset: 0x00010604
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, string arg0, int arg1, int arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x0001245C File Offset: 0x0001065C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, T1 arg0, int arg1, int arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x000124A4 File Offset: 0x000106A4
		public static FixedString128Bytes Format(FixedString128Bytes formatString, int arg0, float arg1, int arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x00012500 File Offset: 0x00010700
		public static FixedString128Bytes Format(FixedString128Bytes formatString, float arg0, float arg1, int arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x0001255C File Offset: 0x0001075C
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, string arg0, float arg1, int arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x000125B8 File Offset: 0x000107B8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, T1 arg0, float arg1, int arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x00012604 File Offset: 0x00010804
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, int arg0, string arg1, int arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0001265C File Offset: 0x0001085C
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, float arg0, string arg1, int arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x000126B8 File Offset: 0x000108B8
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, string arg0, string arg1, int arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x00012710 File Offset: 0x00010910
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, T1 arg0, string arg1, int arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x00012758 File Offset: 0x00010958
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, int arg0, T1 arg1, int arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x000127A0 File Offset: 0x000109A0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, float arg0, T1 arg1, int arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x000127EC File Offset: 0x000109EC
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, string arg0, T1 arg1, int arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x00012834 File Offset: 0x00010A34
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1, T2>(FixedString128Bytes formatString, T1 arg0, T2 arg1, int arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg2);
			ref result.AppendFormat(formatString, arg0, arg1, fixedString32Bytes);
			return result;
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x0001286C File Offset: 0x00010A6C
		public static FixedString128Bytes Format(FixedString128Bytes formatString, int arg0, int arg1, float arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x000128C8 File Offset: 0x00010AC8
		public static FixedString128Bytes Format(FixedString128Bytes formatString, float arg0, int arg1, float arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x00012924 File Offset: 0x00010B24
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, string arg0, int arg1, float arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x00012980 File Offset: 0x00010B80
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, T1 arg0, int arg1, float arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x000129CC File Offset: 0x00010BCC
		public static FixedString128Bytes Format(FixedString128Bytes formatString, int arg0, float arg1, float arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x00012A28 File Offset: 0x00010C28
		public static FixedString128Bytes Format(FixedString128Bytes formatString, float arg0, float arg1, float arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x00012A88 File Offset: 0x00010C88
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, string arg0, float arg1, float arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x00012AE4 File Offset: 0x00010CE4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, T1 arg0, float arg1, float arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x00012B30 File Offset: 0x00010D30
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, int arg0, string arg1, float arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x00012B8C File Offset: 0x00010D8C
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, float arg0, string arg1, float arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x00012BE8 File Offset: 0x00010DE8
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, string arg0, string arg1, float arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x00012C44 File Offset: 0x00010E44
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, T1 arg0, string arg1, float arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x00012C90 File Offset: 0x00010E90
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, int arg0, T1 arg1, float arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x00012CDC File Offset: 0x00010EDC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, float arg0, T1 arg1, float arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x00012D28 File Offset: 0x00010F28
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, string arg0, T1 arg1, float arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x00012D74 File Offset: 0x00010F74
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1, T2>(FixedString128Bytes formatString, T1 arg0, T2 arg1, float arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg2, '.');
			ref result.AppendFormat(formatString, arg0, arg1, fixedString32Bytes);
			return result;
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x00012DAC File Offset: 0x00010FAC
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, int arg0, int arg1, string arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x00012E04 File Offset: 0x00011004
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, float arg0, int arg1, string arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x00012E60 File Offset: 0x00011060
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, string arg0, int arg1, string arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x00012EB8 File Offset: 0x000110B8
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, T1 arg0, int arg1, string arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x00012F00 File Offset: 0x00011100
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, int arg0, float arg1, string arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x00012F5C File Offset: 0x0001115C
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, float arg0, float arg1, string arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x00012FB8 File Offset: 0x000111B8
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, string arg0, float arg1, string arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x00013014 File Offset: 0x00011214
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, T1 arg0, float arg1, string arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x00013060 File Offset: 0x00011260
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, int arg0, string arg1, string arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x000130B8 File Offset: 0x000112B8
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, float arg0, string arg1, string arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x00013114 File Offset: 0x00011314
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, string arg0, string arg1, string arg2)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			FixedString32Bytes fixedString32Bytes3 = default(FixedString32Bytes);
			ref fixedString32Bytes3.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, fixedString32Bytes3);
			return result;
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x0001316C File Offset: 0x0001136C
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, T1 arg0, string arg1, string arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x000131B4 File Offset: 0x000113B4
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, int arg0, T1 arg1, string arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x000131FC File Offset: 0x000113FC
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, float arg0, T1 arg1, string arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x00013248 File Offset: 0x00011448
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, string arg0, T1 arg1, string arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg2);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x00013290 File Offset: 0x00011490
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1, T2>(FixedString128Bytes formatString, T1 arg0, T2 arg1, string arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg2);
			ref result.AppendFormat(formatString, arg0, arg1, fixedString32Bytes);
			return result;
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x000132C8 File Offset: 0x000114C8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, int arg0, int arg1, T1 arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2);
			return result;
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x00013310 File Offset: 0x00011510
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, float arg0, int arg1, T1 arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2);
			return result;
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x0001335C File Offset: 0x0001155C
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, string arg0, int arg1, T1 arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2);
			return result;
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x000133A4 File Offset: 0x000115A4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1, T2>(FixedString128Bytes formatString, T1 arg0, int arg1, T2 arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, arg2);
			return result;
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x000133DC File Offset: 0x000115DC
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, int arg0, float arg1, T1 arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2);
			return result;
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x00013428 File Offset: 0x00011628
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, float arg0, float arg1, T1 arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2);
			return result;
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x00013474 File Offset: 0x00011674
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, string arg0, float arg1, T1 arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2);
			return result;
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x000134C0 File Offset: 0x000116C0
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1, T2>(FixedString128Bytes formatString, T1 arg0, float arg1, T2 arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, arg2);
			return result;
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x000134F8 File Offset: 0x000116F8
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, int arg0, string arg1, T1 arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2);
			return result;
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x00013540 File Offset: 0x00011740
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, float arg0, string arg1, T1 arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2);
			return result;
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0001358C File Offset: 0x0001178C
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, string arg0, string arg1, T1 arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2, arg2);
			return result;
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x000135D4 File Offset: 0x000117D4
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1, T2>(FixedString128Bytes formatString, T1 arg0, string arg1, T2 arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes, arg2);
			return result;
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0001360C File Offset: 0x0001180C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1, T2>(FixedString128Bytes formatString, int arg0, T1 arg1, T2 arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, arg2);
			return result;
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x00013644 File Offset: 0x00011844
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1, T2>(FixedString128Bytes formatString, float arg0, T1 arg1, T2 arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, arg2);
			return result;
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x0001367C File Offset: 0x0001187C
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1, T2>(FixedString128Bytes formatString, string arg0, T1 arg1, T2 arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1, arg2);
			return result;
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x000136B4 File Offset: 0x000118B4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1, T2, T3>(FixedString128Bytes formatString, T1 arg0, T2 arg1, T3 arg2) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes where T3 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			ref result.AppendFormat(formatString, arg0, arg1, arg2);
			return result;
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x000136DC File Offset: 0x000118DC
		public static FixedString128Bytes Format(FixedString128Bytes formatString, int arg0, int arg1)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x00013724 File Offset: 0x00011924
		public static FixedString128Bytes Format(FixedString128Bytes formatString, float arg0, int arg1)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x0001376C File Offset: 0x0001196C
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, string arg0, int arg1)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x000137B4 File Offset: 0x000119B4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, T1 arg0, int arg1) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes);
			return result;
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x000137E8 File Offset: 0x000119E8
		public static FixedString128Bytes Format(FixedString128Bytes formatString, int arg0, float arg1)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x00013830 File Offset: 0x00011A30
		public static FixedString128Bytes Format(FixedString128Bytes formatString, float arg0, float arg1)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x0001387C File Offset: 0x00011A7C
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, string arg0, float arg1)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x000138C4 File Offset: 0x00011AC4
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, T1 arg0, float arg1) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1, '.');
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes);
			return result;
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x000138FC File Offset: 0x00011AFC
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, int arg0, string arg1)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x00013944 File Offset: 0x00011B44
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, float arg0, string arg1)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x0001398C File Offset: 0x00011B8C
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, string arg0, string arg1)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
			ref fixedString32Bytes2.Append(arg1);
			ref result.AppendFormat(formatString, fixedString32Bytes, fixedString32Bytes2);
			return result;
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x000139D4 File Offset: 0x00011BD4
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, T1 arg0, string arg1) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg1);
			ref result.AppendFormat(formatString, arg0, fixedString32Bytes);
			return result;
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x00013A08 File Offset: 0x00011C08
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, int arg0, T1 arg1) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1);
			return result;
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x00013A3C File Offset: 0x00011C3C
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, float arg0, T1 arg1) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1);
			return result;
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x00013A74 File Offset: 0x00011C74
		[NotBurstCompatible]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, string arg0, T1 arg1) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			ref result.AppendFormat(formatString, fixedString32Bytes, arg1);
			return result;
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x00013AA8 File Offset: 0x00011CA8
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes),
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1, T2>(FixedString128Bytes formatString, T1 arg0, T2 arg1) where T1 : struct, INativeList<byte>, IUTF8Bytes where T2 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			ref result.AppendFormat(formatString, arg0, arg1);
			return result;
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x00013ACC File Offset: 0x00011CCC
		public static FixedString128Bytes Format(FixedString128Bytes formatString, int arg0)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			ref result.AppendFormat(formatString, fixedString32Bytes);
			return result;
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x00013B00 File Offset: 0x00011D00
		public static FixedString128Bytes Format(FixedString128Bytes formatString, float arg0)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0, '.');
			ref result.AppendFormat(formatString, fixedString32Bytes);
			return result;
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x00013B34 File Offset: 0x00011D34
		[NotBurstCompatible]
		public static FixedString128Bytes Format(FixedString128Bytes formatString, string arg0)
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
			ref fixedString32Bytes.Append(arg0);
			ref result.AppendFormat(formatString, fixedString32Bytes);
			return result;
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x00013B68 File Offset: 0x00011D68
		[BurstCompatible(GenericTypeArguments = new Type[]
		{
			typeof(FixedString32Bytes)
		})]
		public static FixedString128Bytes Format<T1>(FixedString128Bytes formatString, T1 arg0) where T1 : struct, INativeList<byte>, IUTF8Bytes
		{
			FixedString128Bytes result = default(FixedString128Bytes);
			ref result.AppendFormat(formatString, arg0);
			return result;
		}
	}
}
