using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System.Xml
{
	// Token: 0x02000049 RID: 73
	internal class ReadContentAsBinaryHelper
	{
		// Token: 0x06000261 RID: 609 RVA: 0x0000DCBA File Offset: 0x0000BEBA
		internal ReadContentAsBinaryHelper(XmlReader reader)
		{
			this.reader = reader;
			this.canReadValueChunk = reader.CanReadValueChunk;
			if (this.canReadValueChunk)
			{
				this.valueChunk = new char[256];
			}
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000DCED File Offset: 0x0000BEED
		internal static ReadContentAsBinaryHelper CreateOrReset(ReadContentAsBinaryHelper helper, XmlReader reader)
		{
			if (helper == null)
			{
				return new ReadContentAsBinaryHelper(reader);
			}
			helper.Reset();
			return helper;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000DD00 File Offset: 0x0000BF00
		internal int ReadContentAsBase64(byte[] buffer, int index, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (buffer.Length - index < count)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			switch (this.state)
			{
			case ReadContentAsBinaryHelper.State.None:
				if (!this.reader.CanReadContentAs())
				{
					throw this.reader.CreateReadContentAsException("ReadContentAsBase64");
				}
				if (!this.Init())
				{
					return 0;
				}
				break;
			case ReadContentAsBinaryHelper.State.InReadContent:
				if (this.decoder == this.base64Decoder)
				{
					return this.ReadContentAsBinary(buffer, index, count);
				}
				break;
			case ReadContentAsBinaryHelper.State.InReadElementContent:
				throw new InvalidOperationException(Res.GetString("ReadContentAsBase64 and ReadContentAsBinHex method calls cannot be mixed with calls to ReadElementContentAsBase64 and ReadElementContentAsBinHex."));
			default:
				return 0;
			}
			this.InitBase64Decoder();
			return this.ReadContentAsBinary(buffer, index, count);
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000DDC8 File Offset: 0x0000BFC8
		internal int ReadContentAsBinHex(byte[] buffer, int index, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (buffer.Length - index < count)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			switch (this.state)
			{
			case ReadContentAsBinaryHelper.State.None:
				if (!this.reader.CanReadContentAs())
				{
					throw this.reader.CreateReadContentAsException("ReadContentAsBinHex");
				}
				if (!this.Init())
				{
					return 0;
				}
				break;
			case ReadContentAsBinaryHelper.State.InReadContent:
				if (this.decoder == this.binHexDecoder)
				{
					return this.ReadContentAsBinary(buffer, index, count);
				}
				break;
			case ReadContentAsBinaryHelper.State.InReadElementContent:
				throw new InvalidOperationException(Res.GetString("ReadContentAsBase64 and ReadContentAsBinHex method calls cannot be mixed with calls to ReadElementContentAsBase64 and ReadElementContentAsBinHex."));
			default:
				return 0;
			}
			this.InitBinHexDecoder();
			return this.ReadContentAsBinary(buffer, index, count);
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000DE90 File Offset: 0x0000C090
		internal int ReadElementContentAsBase64(byte[] buffer, int index, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (buffer.Length - index < count)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			switch (this.state)
			{
			case ReadContentAsBinaryHelper.State.None:
				if (this.reader.NodeType != XmlNodeType.Element)
				{
					throw this.reader.CreateReadElementContentAsException("ReadElementContentAsBase64");
				}
				if (!this.InitOnElement())
				{
					return 0;
				}
				break;
			case ReadContentAsBinaryHelper.State.InReadContent:
				throw new InvalidOperationException(Res.GetString("ReadContentAsBase64 and ReadContentAsBinHex method calls cannot be mixed with calls to ReadElementContentAsBase64 and ReadElementContentAsBinHex."));
			case ReadContentAsBinaryHelper.State.InReadElementContent:
				if (this.decoder == this.base64Decoder)
				{
					return this.ReadElementContentAsBinary(buffer, index, count);
				}
				break;
			default:
				return 0;
			}
			this.InitBase64Decoder();
			return this.ReadElementContentAsBinary(buffer, index, count);
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000DF5C File Offset: 0x0000C15C
		internal int ReadElementContentAsBinHex(byte[] buffer, int index, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (buffer.Length - index < count)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			switch (this.state)
			{
			case ReadContentAsBinaryHelper.State.None:
				if (this.reader.NodeType != XmlNodeType.Element)
				{
					throw this.reader.CreateReadElementContentAsException("ReadElementContentAsBinHex");
				}
				if (!this.InitOnElement())
				{
					return 0;
				}
				break;
			case ReadContentAsBinaryHelper.State.InReadContent:
				throw new InvalidOperationException(Res.GetString("ReadContentAsBase64 and ReadContentAsBinHex method calls cannot be mixed with calls to ReadElementContentAsBase64 and ReadElementContentAsBinHex."));
			case ReadContentAsBinaryHelper.State.InReadElementContent:
				if (this.decoder == this.binHexDecoder)
				{
					return this.ReadElementContentAsBinary(buffer, index, count);
				}
				break;
			default:
				return 0;
			}
			this.InitBinHexDecoder();
			return this.ReadElementContentAsBinary(buffer, index, count);
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000E028 File Offset: 0x0000C228
		internal void Finish()
		{
			if (this.state != ReadContentAsBinaryHelper.State.None)
			{
				while (this.MoveToNextContentNode(true))
				{
				}
				if (this.state == ReadContentAsBinaryHelper.State.InReadElementContent)
				{
					if (this.reader.NodeType != XmlNodeType.EndElement)
					{
						throw new XmlException("'{0}' is an invalid XmlNodeType.", this.reader.NodeType.ToString(), this.reader as IXmlLineInfo);
					}
					this.reader.Read();
				}
			}
			this.Reset();
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000E09F File Offset: 0x0000C29F
		internal void Reset()
		{
			this.state = ReadContentAsBinaryHelper.State.None;
			this.isEnd = false;
			this.valueOffset = 0;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000E0B6 File Offset: 0x0000C2B6
		private bool Init()
		{
			if (!this.MoveToNextContentNode(false))
			{
				return false;
			}
			this.state = ReadContentAsBinaryHelper.State.InReadContent;
			this.isEnd = false;
			return true;
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0000E0D4 File Offset: 0x0000C2D4
		private bool InitOnElement()
		{
			bool isEmptyElement = this.reader.IsEmptyElement;
			this.reader.Read();
			if (isEmptyElement)
			{
				return false;
			}
			if (this.MoveToNextContentNode(false))
			{
				this.state = ReadContentAsBinaryHelper.State.InReadElementContent;
				this.isEnd = false;
				return true;
			}
			if (this.reader.NodeType != XmlNodeType.EndElement)
			{
				throw new XmlException("'{0}' is an invalid XmlNodeType.", this.reader.NodeType.ToString(), this.reader as IXmlLineInfo);
			}
			this.reader.Read();
			return false;
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000E160 File Offset: 0x0000C360
		private void InitBase64Decoder()
		{
			if (this.base64Decoder == null)
			{
				this.base64Decoder = new Base64Decoder();
			}
			else
			{
				this.base64Decoder.Reset();
			}
			this.decoder = this.base64Decoder;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000E18E File Offset: 0x0000C38E
		private void InitBinHexDecoder()
		{
			if (this.binHexDecoder == null)
			{
				this.binHexDecoder = new BinHexDecoder();
			}
			else
			{
				this.binHexDecoder.Reset();
			}
			this.decoder = this.binHexDecoder;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000E1BC File Offset: 0x0000C3BC
		private int ReadContentAsBinary(byte[] buffer, int index, int count)
		{
			if (this.isEnd)
			{
				this.Reset();
				return 0;
			}
			this.decoder.SetNextOutputBuffer(buffer, index, count);
			for (;;)
			{
				if (this.canReadValueChunk)
				{
					for (;;)
					{
						if (this.valueOffset < this.valueChunkLength)
						{
							int num = this.decoder.Decode(this.valueChunk, this.valueOffset, this.valueChunkLength - this.valueOffset);
							this.valueOffset += num;
						}
						if (this.decoder.IsFull)
						{
							goto Block_3;
						}
						if ((this.valueChunkLength = this.reader.ReadValueChunk(this.valueChunk, 0, 256)) == 0)
						{
							break;
						}
						this.valueOffset = 0;
					}
				}
				else
				{
					string value = this.reader.Value;
					int num2 = this.decoder.Decode(value, this.valueOffset, value.Length - this.valueOffset);
					this.valueOffset += num2;
					if (this.decoder.IsFull)
					{
						goto Block_5;
					}
				}
				this.valueOffset = 0;
				if (!this.MoveToNextContentNode(true))
				{
					goto Block_6;
				}
			}
			Block_3:
			return this.decoder.DecodedCount;
			Block_5:
			return this.decoder.DecodedCount;
			Block_6:
			this.isEnd = true;
			return this.decoder.DecodedCount;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000E2F4 File Offset: 0x0000C4F4
		private int ReadElementContentAsBinary(byte[] buffer, int index, int count)
		{
			if (count == 0)
			{
				return 0;
			}
			int num = this.ReadContentAsBinary(buffer, index, count);
			if (num > 0)
			{
				return num;
			}
			if (this.reader.NodeType != XmlNodeType.EndElement)
			{
				throw new XmlException("'{0}' is an invalid XmlNodeType.", this.reader.NodeType.ToString(), this.reader as IXmlLineInfo);
			}
			this.reader.Read();
			this.state = ReadContentAsBinaryHelper.State.None;
			return 0;
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000E368 File Offset: 0x0000C568
		private bool MoveToNextContentNode(bool moveIfOnContentNode)
		{
			for (;;)
			{
				switch (this.reader.NodeType)
				{
				case XmlNodeType.Attribute:
					goto IL_52;
				case XmlNodeType.Text:
				case XmlNodeType.CDATA:
				case XmlNodeType.Whitespace:
				case XmlNodeType.SignificantWhitespace:
					if (!moveIfOnContentNode)
					{
						return true;
					}
					goto IL_78;
				case XmlNodeType.EntityReference:
					if (this.reader.CanResolveEntity)
					{
						this.reader.ResolveEntity();
						goto IL_78;
					}
					break;
				case XmlNodeType.ProcessingInstruction:
				case XmlNodeType.Comment:
				case XmlNodeType.EndEntity:
					goto IL_78;
				}
				break;
				IL_78:
				moveIfOnContentNode = false;
				if (!this.reader.Read())
				{
					return false;
				}
			}
			return false;
			IL_52:
			return !moveIfOnContentNode;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000E404 File Offset: 0x0000C604
		internal Task<int> ReadContentAsBase64Async(byte[] buffer, int index, int count)
		{
			ReadContentAsBinaryHelper.<ReadContentAsBase64Async>d__27 <ReadContentAsBase64Async>d__;
			<ReadContentAsBase64Async>d__.<>4__this = this;
			<ReadContentAsBase64Async>d__.buffer = buffer;
			<ReadContentAsBase64Async>d__.index = index;
			<ReadContentAsBase64Async>d__.count = count;
			<ReadContentAsBase64Async>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<ReadContentAsBase64Async>d__.<>1__state = -1;
			<ReadContentAsBase64Async>d__.<>t__builder.Start<ReadContentAsBinaryHelper.<ReadContentAsBase64Async>d__27>(ref <ReadContentAsBase64Async>d__);
			return <ReadContentAsBase64Async>d__.<>t__builder.Task;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000E460 File Offset: 0x0000C660
		internal Task<int> ReadContentAsBinHexAsync(byte[] buffer, int index, int count)
		{
			ReadContentAsBinaryHelper.<ReadContentAsBinHexAsync>d__28 <ReadContentAsBinHexAsync>d__;
			<ReadContentAsBinHexAsync>d__.<>4__this = this;
			<ReadContentAsBinHexAsync>d__.buffer = buffer;
			<ReadContentAsBinHexAsync>d__.index = index;
			<ReadContentAsBinHexAsync>d__.count = count;
			<ReadContentAsBinHexAsync>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<ReadContentAsBinHexAsync>d__.<>1__state = -1;
			<ReadContentAsBinHexAsync>d__.<>t__builder.Start<ReadContentAsBinaryHelper.<ReadContentAsBinHexAsync>d__28>(ref <ReadContentAsBinHexAsync>d__);
			return <ReadContentAsBinHexAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000E4BC File Offset: 0x0000C6BC
		internal Task<int> ReadElementContentAsBase64Async(byte[] buffer, int index, int count)
		{
			ReadContentAsBinaryHelper.<ReadElementContentAsBase64Async>d__29 <ReadElementContentAsBase64Async>d__;
			<ReadElementContentAsBase64Async>d__.<>4__this = this;
			<ReadElementContentAsBase64Async>d__.buffer = buffer;
			<ReadElementContentAsBase64Async>d__.index = index;
			<ReadElementContentAsBase64Async>d__.count = count;
			<ReadElementContentAsBase64Async>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<ReadElementContentAsBase64Async>d__.<>1__state = -1;
			<ReadElementContentAsBase64Async>d__.<>t__builder.Start<ReadContentAsBinaryHelper.<ReadElementContentAsBase64Async>d__29>(ref <ReadElementContentAsBase64Async>d__);
			return <ReadElementContentAsBase64Async>d__.<>t__builder.Task;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000E518 File Offset: 0x0000C718
		internal Task<int> ReadElementContentAsBinHexAsync(byte[] buffer, int index, int count)
		{
			ReadContentAsBinaryHelper.<ReadElementContentAsBinHexAsync>d__30 <ReadElementContentAsBinHexAsync>d__;
			<ReadElementContentAsBinHexAsync>d__.<>4__this = this;
			<ReadElementContentAsBinHexAsync>d__.buffer = buffer;
			<ReadElementContentAsBinHexAsync>d__.index = index;
			<ReadElementContentAsBinHexAsync>d__.count = count;
			<ReadElementContentAsBinHexAsync>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<ReadElementContentAsBinHexAsync>d__.<>1__state = -1;
			<ReadElementContentAsBinHexAsync>d__.<>t__builder.Start<ReadContentAsBinaryHelper.<ReadElementContentAsBinHexAsync>d__30>(ref <ReadElementContentAsBinHexAsync>d__);
			return <ReadElementContentAsBinHexAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000E574 File Offset: 0x0000C774
		internal Task FinishAsync()
		{
			ReadContentAsBinaryHelper.<FinishAsync>d__31 <FinishAsync>d__;
			<FinishAsync>d__.<>4__this = this;
			<FinishAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<FinishAsync>d__.<>1__state = -1;
			<FinishAsync>d__.<>t__builder.Start<ReadContentAsBinaryHelper.<FinishAsync>d__31>(ref <FinishAsync>d__);
			return <FinishAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000E5B8 File Offset: 0x0000C7B8
		private Task<bool> InitAsync()
		{
			ReadContentAsBinaryHelper.<InitAsync>d__32 <InitAsync>d__;
			<InitAsync>d__.<>4__this = this;
			<InitAsync>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<InitAsync>d__.<>1__state = -1;
			<InitAsync>d__.<>t__builder.Start<ReadContentAsBinaryHelper.<InitAsync>d__32>(ref <InitAsync>d__);
			return <InitAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000E5FC File Offset: 0x0000C7FC
		private Task<bool> InitOnElementAsync()
		{
			ReadContentAsBinaryHelper.<InitOnElementAsync>d__33 <InitOnElementAsync>d__;
			<InitOnElementAsync>d__.<>4__this = this;
			<InitOnElementAsync>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<InitOnElementAsync>d__.<>1__state = -1;
			<InitOnElementAsync>d__.<>t__builder.Start<ReadContentAsBinaryHelper.<InitOnElementAsync>d__33>(ref <InitOnElementAsync>d__);
			return <InitOnElementAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000E640 File Offset: 0x0000C840
		private Task<int> ReadContentAsBinaryAsync(byte[] buffer, int index, int count)
		{
			ReadContentAsBinaryHelper.<ReadContentAsBinaryAsync>d__34 <ReadContentAsBinaryAsync>d__;
			<ReadContentAsBinaryAsync>d__.<>4__this = this;
			<ReadContentAsBinaryAsync>d__.buffer = buffer;
			<ReadContentAsBinaryAsync>d__.index = index;
			<ReadContentAsBinaryAsync>d__.count = count;
			<ReadContentAsBinaryAsync>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<ReadContentAsBinaryAsync>d__.<>1__state = -1;
			<ReadContentAsBinaryAsync>d__.<>t__builder.Start<ReadContentAsBinaryHelper.<ReadContentAsBinaryAsync>d__34>(ref <ReadContentAsBinaryAsync>d__);
			return <ReadContentAsBinaryAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000E69C File Offset: 0x0000C89C
		private Task<int> ReadElementContentAsBinaryAsync(byte[] buffer, int index, int count)
		{
			ReadContentAsBinaryHelper.<ReadElementContentAsBinaryAsync>d__35 <ReadElementContentAsBinaryAsync>d__;
			<ReadElementContentAsBinaryAsync>d__.<>4__this = this;
			<ReadElementContentAsBinaryAsync>d__.buffer = buffer;
			<ReadElementContentAsBinaryAsync>d__.index = index;
			<ReadElementContentAsBinaryAsync>d__.count = count;
			<ReadElementContentAsBinaryAsync>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<ReadElementContentAsBinaryAsync>d__.<>1__state = -1;
			<ReadElementContentAsBinaryAsync>d__.<>t__builder.Start<ReadContentAsBinaryHelper.<ReadElementContentAsBinaryAsync>d__35>(ref <ReadElementContentAsBinaryAsync>d__);
			return <ReadElementContentAsBinaryAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000E6F8 File Offset: 0x0000C8F8
		private Task<bool> MoveToNextContentNodeAsync(bool moveIfOnContentNode)
		{
			ReadContentAsBinaryHelper.<MoveToNextContentNodeAsync>d__36 <MoveToNextContentNodeAsync>d__;
			<MoveToNextContentNodeAsync>d__.<>4__this = this;
			<MoveToNextContentNodeAsync>d__.moveIfOnContentNode = moveIfOnContentNode;
			<MoveToNextContentNodeAsync>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<MoveToNextContentNodeAsync>d__.<>1__state = -1;
			<MoveToNextContentNodeAsync>d__.<>t__builder.Start<ReadContentAsBinaryHelper.<MoveToNextContentNodeAsync>d__36>(ref <MoveToNextContentNodeAsync>d__);
			return <MoveToNextContentNodeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04000629 RID: 1577
		private XmlReader reader;

		// Token: 0x0400062A RID: 1578
		private ReadContentAsBinaryHelper.State state;

		// Token: 0x0400062B RID: 1579
		private int valueOffset;

		// Token: 0x0400062C RID: 1580
		private bool isEnd;

		// Token: 0x0400062D RID: 1581
		private bool canReadValueChunk;

		// Token: 0x0400062E RID: 1582
		private char[] valueChunk;

		// Token: 0x0400062F RID: 1583
		private int valueChunkLength;

		// Token: 0x04000630 RID: 1584
		private IncrementalReadDecoder decoder;

		// Token: 0x04000631 RID: 1585
		private Base64Decoder base64Decoder;

		// Token: 0x04000632 RID: 1586
		private BinHexDecoder binHexDecoder;

		// Token: 0x04000633 RID: 1587
		private const int ChunkSize = 256;

		// Token: 0x0200004A RID: 74
		private enum State
		{
			// Token: 0x04000635 RID: 1589
			None,
			// Token: 0x04000636 RID: 1590
			InReadContent,
			// Token: 0x04000637 RID: 1591
			InReadElementContent
		}
	}
}
