using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System.Xml
{
	// Token: 0x0200001B RID: 27
	internal static class BinHexEncoder
	{
		// Token: 0x06000057 RID: 87 RVA: 0x000037F4 File Offset: 0x000019F4
		internal static void Encode(byte[] buffer, int index, int count, XmlWriter writer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (count > buffer.Length - index)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			char[] array = new char[(count * 2 < 128) ? (count * 2) : 128];
			int num = index + count;
			while (index < num)
			{
				int num2 = (count < 64) ? count : 64;
				int count2 = BinHexEncoder.Encode(buffer, index, num2, array);
				writer.WriteRaw(array, 0, count2);
				index += num2;
				count -= num2;
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000388C File Offset: 0x00001A8C
		internal static string Encode(byte[] inArray, int offsetIn, int count)
		{
			if (inArray == null)
			{
				throw new ArgumentNullException("inArray");
			}
			if (0 > offsetIn)
			{
				throw new ArgumentOutOfRangeException("offsetIn");
			}
			if (0 > count)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (count > inArray.Length - offsetIn)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			char[] array = new char[2 * count];
			int length = BinHexEncoder.Encode(inArray, offsetIn, count, array);
			return new string(array, 0, length);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000038F4 File Offset: 0x00001AF4
		private static int Encode(byte[] inArray, int offsetIn, int count, char[] outArray)
		{
			int num = 0;
			int num2 = 0;
			int num3 = outArray.Length;
			for (int i = 0; i < count; i++)
			{
				byte b = inArray[offsetIn++];
				outArray[num++] = "0123456789ABCDEF"[b >> 4];
				if (num == num3)
				{
					break;
				}
				outArray[num++] = "0123456789ABCDEF"[(int)(b & 15)];
				if (num == num3)
				{
					break;
				}
			}
			return num - num2;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003958 File Offset: 0x00001B58
		internal static Task EncodeAsync(byte[] buffer, int index, int count, XmlWriter writer)
		{
			BinHexEncoder.<EncodeAsync>d__5 <EncodeAsync>d__;
			<EncodeAsync>d__.buffer = buffer;
			<EncodeAsync>d__.index = index;
			<EncodeAsync>d__.count = count;
			<EncodeAsync>d__.writer = writer;
			<EncodeAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<EncodeAsync>d__.<>1__state = -1;
			<EncodeAsync>d__.<>t__builder.Start<BinHexEncoder.<EncodeAsync>d__5>(ref <EncodeAsync>d__);
			return <EncodeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04000505 RID: 1285
		private const string s_hexDigits = "0123456789ABCDEF";

		// Token: 0x04000506 RID: 1286
		private const int CharsChunkSize = 128;
	}
}
