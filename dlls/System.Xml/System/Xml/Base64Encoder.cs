using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System.Xml
{
	// Token: 0x02000015 RID: 21
	internal abstract class Base64Encoder
	{
		// Token: 0x0600003D RID: 61 RVA: 0x00002DC7 File Offset: 0x00000FC7
		internal Base64Encoder()
		{
			this.charsLine = new char[76];
		}

		// Token: 0x0600003E RID: 62
		internal abstract void WriteChars(char[] chars, int index, int count);

		// Token: 0x0600003F RID: 63 RVA: 0x00002DDC File Offset: 0x00000FDC
		internal void Encode(byte[] buffer, int index, int count)
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
			if (this.leftOverBytesCount > 0)
			{
				int num = this.leftOverBytesCount;
				while (num < 3 && count > 0)
				{
					this.leftOverBytes[num++] = buffer[index++];
					count--;
				}
				if (count == 0 && num < 3)
				{
					this.leftOverBytesCount = num;
					return;
				}
				int count2 = Convert.ToBase64CharArray(this.leftOverBytes, 0, 3, this.charsLine, 0);
				this.WriteChars(this.charsLine, 0, count2);
			}
			this.leftOverBytesCount = count % 3;
			if (this.leftOverBytesCount > 0)
			{
				count -= this.leftOverBytesCount;
				if (this.leftOverBytes == null)
				{
					this.leftOverBytes = new byte[3];
				}
				for (int i = 0; i < this.leftOverBytesCount; i++)
				{
					this.leftOverBytes[i] = buffer[index + count + i];
				}
			}
			int num2 = index + count;
			int num3 = 57;
			while (index < num2)
			{
				if (index + num3 > num2)
				{
					num3 = num2 - index;
				}
				int count3 = Convert.ToBase64CharArray(buffer, index, num3, this.charsLine, 0);
				this.WriteChars(this.charsLine, 0, count3);
				index += num3;
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002F20 File Offset: 0x00001120
		internal void Flush()
		{
			if (this.leftOverBytesCount > 0)
			{
				int count = Convert.ToBase64CharArray(this.leftOverBytes, 0, this.leftOverBytesCount, this.charsLine, 0);
				this.WriteChars(this.charsLine, 0, count);
				this.leftOverBytesCount = 0;
			}
		}

		// Token: 0x06000041 RID: 65
		internal abstract Task WriteCharsAsync(char[] chars, int index, int count);

		// Token: 0x06000042 RID: 66 RVA: 0x00002F68 File Offset: 0x00001168
		internal Task EncodeAsync(byte[] buffer, int index, int count)
		{
			Base64Encoder.<EncodeAsync>d__10 <EncodeAsync>d__;
			<EncodeAsync>d__.<>4__this = this;
			<EncodeAsync>d__.buffer = buffer;
			<EncodeAsync>d__.index = index;
			<EncodeAsync>d__.count = count;
			<EncodeAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<EncodeAsync>d__.<>1__state = -1;
			<EncodeAsync>d__.<>t__builder.Start<Base64Encoder.<EncodeAsync>d__10>(ref <EncodeAsync>d__);
			return <EncodeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002FC4 File Offset: 0x000011C4
		internal Task FlushAsync()
		{
			Base64Encoder.<FlushAsync>d__11 <FlushAsync>d__;
			<FlushAsync>d__.<>4__this = this;
			<FlushAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<FlushAsync>d__.<>1__state = -1;
			<FlushAsync>d__.<>t__builder.Start<Base64Encoder.<FlushAsync>d__11>(ref <FlushAsync>d__);
			return <FlushAsync>d__.<>t__builder.Task;
		}

		// Token: 0x040004EB RID: 1259
		private byte[] leftOverBytes;

		// Token: 0x040004EC RID: 1260
		private int leftOverBytesCount;

		// Token: 0x040004ED RID: 1261
		private char[] charsLine;

		// Token: 0x040004EE RID: 1262
		internal const int Base64LineSize = 76;

		// Token: 0x040004EF RID: 1263
		internal const int LineSizeInBytes = 57;
	}
}
