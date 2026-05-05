using System;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace System.Xml
{
	// Token: 0x0200011E RID: 286
	internal class XmlUtf8RawTextWriter : XmlRawWriter
	{
		// Token: 0x06000A74 RID: 2676 RVA: 0x00044EFC File Offset: 0x000430FC
		protected XmlUtf8RawTextWriter(XmlWriterSettings settings)
		{
			this.useAsync = settings.Async;
			this.newLineHandling = settings.NewLineHandling;
			this.omitXmlDeclaration = settings.OmitXmlDeclaration;
			this.newLineChars = settings.NewLineChars;
			this.checkCharacters = settings.CheckCharacters;
			this.closeOutput = settings.CloseOutput;
			this.standalone = settings.Standalone;
			this.outputMethod = settings.OutputMethod;
			this.mergeCDataSections = settings.MergeCDataSections;
			if (this.checkCharacters && this.newLineHandling == NewLineHandling.Replace)
			{
				this.ValidateContentChars(this.newLineChars, "NewLineChars", false);
			}
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x00044FC4 File Offset: 0x000431C4
		public XmlUtf8RawTextWriter(Stream stream, XmlWriterSettings settings) : this(settings)
		{
			this.stream = stream;
			this.encoding = settings.Encoding;
			if (settings.Async)
			{
				this.bufLen = 65536;
			}
			this.bufBytes = new byte[this.bufLen + 32];
			if (!stream.CanSeek || stream.Position == 0L)
			{
				byte[] preamble = this.encoding.GetPreamble();
				if (preamble.Length != 0)
				{
					Buffer.BlockCopy(preamble, 0, this.bufBytes, 1, preamble.Length);
					this.bufPos += preamble.Length;
					this.textPos += preamble.Length;
				}
			}
			if (settings.AutoXmlDeclaration)
			{
				this.WriteXmlDeclaration(this.standalone);
				this.autoXmlDeclaration = true;
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000A76 RID: 2678 RVA: 0x00045080 File Offset: 0x00043280
		public override XmlWriterSettings Settings
		{
			get
			{
				return new XmlWriterSettings
				{
					Encoding = this.encoding,
					OmitXmlDeclaration = this.omitXmlDeclaration,
					NewLineHandling = this.newLineHandling,
					NewLineChars = this.newLineChars,
					CloseOutput = this.closeOutput,
					ConformanceLevel = ConformanceLevel.Auto,
					CheckCharacters = this.checkCharacters,
					AutoXmlDeclaration = this.autoXmlDeclaration,
					Standalone = this.standalone,
					OutputMethod = this.outputMethod,
					ReadOnly = true
				};
			}
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x0004510C File Offset: 0x0004330C
		internal override void WriteXmlDeclaration(XmlStandalone standalone)
		{
			if (!this.omitXmlDeclaration && !this.autoXmlDeclaration)
			{
				this.RawText("<?xml version=\"");
				this.RawText("1.0");
				if (this.encoding != null)
				{
					this.RawText("\" encoding=\"");
					this.RawText(this.encoding.WebName);
				}
				if (standalone != XmlStandalone.Omit)
				{
					this.RawText("\" standalone=\"");
					this.RawText((standalone == XmlStandalone.Yes) ? "yes" : "no");
				}
				this.RawText("\"?>");
			}
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x00045192 File Offset: 0x00043392
		internal override void WriteXmlDeclaration(string xmldecl)
		{
			if (!this.omitXmlDeclaration && !this.autoXmlDeclaration)
			{
				this.WriteProcessingInstruction("xml", xmldecl);
			}
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x000451B0 File Offset: 0x000433B0
		public override void WriteDocType(string name, string pubid, string sysid, string subset)
		{
			this.RawText("<!DOCTYPE ");
			this.RawText(name);
			int num;
			if (pubid != null)
			{
				this.RawText(" PUBLIC \"");
				this.RawText(pubid);
				this.RawText("\" \"");
				if (sysid != null)
				{
					this.RawText(sysid);
				}
				byte[] array = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array[num] = 34;
			}
			else if (sysid != null)
			{
				this.RawText(" SYSTEM \"");
				this.RawText(sysid);
				byte[] array2 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array2[num] = 34;
			}
			else
			{
				byte[] array3 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array3[num] = 32;
			}
			if (subset != null)
			{
				byte[] array4 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array4[num] = 91;
				this.RawText(subset);
				byte[] array5 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array5[num] = 93;
			}
			byte[] array6 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array6[num] = 62;
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x000452BC File Offset: 0x000434BC
		public override void WriteStartElement(string prefix, string localName, string ns)
		{
			byte[] array = this.bufBytes;
			int num = this.bufPos;
			this.bufPos = num + 1;
			array[num] = 60;
			if (prefix != null && prefix.Length != 0)
			{
				this.RawText(prefix);
				byte[] array2 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array2[num] = 58;
			}
			this.RawText(localName);
			this.attrEndPos = this.bufPos;
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x00045324 File Offset: 0x00043524
		internal override void StartElementContent()
		{
			byte[] array = this.bufBytes;
			int num = this.bufPos;
			this.bufPos = num + 1;
			array[num] = 62;
			this.contentPos = this.bufPos;
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x00045358 File Offset: 0x00043558
		internal override void WriteEndElement(string prefix, string localName, string ns)
		{
			int num;
			if (this.contentPos != this.bufPos)
			{
				byte[] array = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array[num] = 60;
				byte[] array2 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array2[num] = 47;
				if (prefix != null && prefix.Length != 0)
				{
					this.RawText(prefix);
					byte[] array3 = this.bufBytes;
					num = this.bufPos;
					this.bufPos = num + 1;
					array3[num] = 58;
				}
				this.RawText(localName);
				byte[] array4 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array4[num] = 62;
				return;
			}
			this.bufPos--;
			byte[] array5 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array5[num] = 32;
			byte[] array6 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array6[num] = 47;
			byte[] array7 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array7[num] = 62;
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x00045454 File Offset: 0x00043654
		internal override void WriteFullEndElement(string prefix, string localName, string ns)
		{
			byte[] array = this.bufBytes;
			int num = this.bufPos;
			this.bufPos = num + 1;
			array[num] = 60;
			byte[] array2 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array2[num] = 47;
			if (prefix != null && prefix.Length != 0)
			{
				this.RawText(prefix);
				byte[] array3 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array3[num] = 58;
			}
			this.RawText(localName);
			byte[] array4 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array4[num] = 62;
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x000454E4 File Offset: 0x000436E4
		public override void WriteStartAttribute(string prefix, string localName, string ns)
		{
			int num;
			if (this.attrEndPos == this.bufPos)
			{
				byte[] array = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array[num] = 32;
			}
			if (prefix != null && prefix.Length > 0)
			{
				this.RawText(prefix);
				byte[] array2 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array2[num] = 58;
			}
			this.RawText(localName);
			byte[] array3 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array3[num] = 61;
			byte[] array4 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array4[num] = 34;
			this.inAttributeValue = true;
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x00045588 File Offset: 0x00043788
		public override void WriteEndAttribute()
		{
			byte[] array = this.bufBytes;
			int num = this.bufPos;
			this.bufPos = num + 1;
			array[num] = 34;
			this.inAttributeValue = false;
			this.attrEndPos = this.bufPos;
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x000153D1 File Offset: 0x000135D1
		internal override void WriteNamespaceDeclaration(string prefix, string namespaceName)
		{
			this.WriteStartNamespaceDeclaration(prefix);
			this.WriteString(namespaceName);
			this.WriteEndNamespaceDeclaration();
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000A81 RID: 2689 RVA: 0x0001222F File Offset: 0x0001042F
		internal override bool SupportsNamespaceDeclarationInChunks
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x000455C4 File Offset: 0x000437C4
		internal override void WriteStartNamespaceDeclaration(string prefix)
		{
			if (prefix.Length == 0)
			{
				this.RawText(" xmlns=\"");
			}
			else
			{
				this.RawText(" xmlns:");
				this.RawText(prefix);
				byte[] array = this.bufBytes;
				int num = this.bufPos;
				this.bufPos = num + 1;
				array[num] = 61;
				byte[] array2 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array2[num] = 34;
			}
			this.inAttributeValue = true;
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x00045634 File Offset: 0x00043834
		internal override void WriteEndNamespaceDeclaration()
		{
			this.inAttributeValue = false;
			byte[] array = this.bufBytes;
			int num = this.bufPos;
			this.bufPos = num + 1;
			array[num] = 34;
			this.attrEndPos = this.bufPos;
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x00045670 File Offset: 0x00043870
		public override void WriteCData(string text)
		{
			int num;
			if (this.mergeCDataSections && this.bufPos == this.cdataPos)
			{
				this.bufPos -= 3;
			}
			else
			{
				byte[] array = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array[num] = 60;
				byte[] array2 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array2[num] = 33;
				byte[] array3 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array3[num] = 91;
				byte[] array4 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array4[num] = 67;
				byte[] array5 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array5[num] = 68;
				byte[] array6 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array6[num] = 65;
				byte[] array7 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array7[num] = 84;
				byte[] array8 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array8[num] = 65;
				byte[] array9 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array9[num] = 91;
			}
			this.WriteCDataSection(text);
			byte[] array10 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array10[num] = 93;
			byte[] array11 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array11[num] = 93;
			byte[] array12 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array12[num] = 62;
			this.textPos = this.bufPos;
			this.cdataPos = this.bufPos;
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x00045800 File Offset: 0x00043A00
		public override void WriteComment(string text)
		{
			byte[] array = this.bufBytes;
			int num = this.bufPos;
			this.bufPos = num + 1;
			array[num] = 60;
			byte[] array2 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array2[num] = 33;
			byte[] array3 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array3[num] = 45;
			byte[] array4 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array4[num] = 45;
			this.WriteCommentOrPi(text, 45);
			byte[] array5 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array5[num] = 45;
			byte[] array6 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array6[num] = 45;
			byte[] array7 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array7[num] = 62;
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x000458CC File Offset: 0x00043ACC
		public override void WriteProcessingInstruction(string name, string text)
		{
			byte[] array = this.bufBytes;
			int num = this.bufPos;
			this.bufPos = num + 1;
			array[num] = 60;
			byte[] array2 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array2[num] = 63;
			this.RawText(name);
			if (text.Length > 0)
			{
				byte[] array3 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array3[num] = 32;
				this.WriteCommentOrPi(text, 63);
			}
			byte[] array4 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array4[num] = 63;
			byte[] array5 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array5[num] = 62;
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x00045974 File Offset: 0x00043B74
		public override void WriteEntityRef(string name)
		{
			byte[] array = this.bufBytes;
			int num = this.bufPos;
			this.bufPos = num + 1;
			array[num] = 38;
			this.RawText(name);
			byte[] array2 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array2[num] = 59;
			if (this.bufPos > this.bufLen)
			{
				this.FlushBuffer();
			}
			this.textPos = this.bufPos;
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x000459DC File Offset: 0x00043BDC
		public override void WriteCharEntity(char ch)
		{
			int num = (int)ch;
			string s = num.ToString("X", NumberFormatInfo.InvariantInfo);
			if (this.checkCharacters && !this.xmlCharType.IsCharData(ch))
			{
				throw XmlConvert.CreateInvalidCharException(ch, '\0');
			}
			byte[] array = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array[num] = 38;
			byte[] array2 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array2[num] = 35;
			byte[] array3 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array3[num] = 120;
			this.RawText(s);
			byte[] array4 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array4[num] = 59;
			if (this.bufPos > this.bufLen)
			{
				this.FlushBuffer();
			}
			this.textPos = this.bufPos;
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x00045AAC File Offset: 0x00043CAC
		public unsafe override void WriteWhitespace(string ws)
		{
			fixed (string text = ws)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				char* pSrcEnd = ptr + ws.Length;
				if (this.inAttributeValue)
				{
					this.WriteAttributeTextBlock(ptr, pSrcEnd);
				}
				else
				{
					this.WriteElementTextBlock(ptr, pSrcEnd);
				}
			}
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x00045AF4 File Offset: 0x00043CF4
		public unsafe override void WriteString(string text)
		{
			fixed (string text2 = text)
			{
				char* ptr = text2;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				char* pSrcEnd = ptr + text.Length;
				if (this.inAttributeValue)
				{
					this.WriteAttributeTextBlock(ptr, pSrcEnd);
				}
				else
				{
					this.WriteElementTextBlock(ptr, pSrcEnd);
				}
			}
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x00045B3C File Offset: 0x00043D3C
		public override void WriteSurrogateCharEntity(char lowChar, char highChar)
		{
			int num = XmlCharType.CombineSurrogateChar((int)lowChar, (int)highChar);
			byte[] array = this.bufBytes;
			int num2 = this.bufPos;
			this.bufPos = num2 + 1;
			array[num2] = 38;
			byte[] array2 = this.bufBytes;
			num2 = this.bufPos;
			this.bufPos = num2 + 1;
			array2[num2] = 35;
			byte[] array3 = this.bufBytes;
			num2 = this.bufPos;
			this.bufPos = num2 + 1;
			array3[num2] = 120;
			this.RawText(num.ToString("X", NumberFormatInfo.InvariantInfo));
			byte[] array4 = this.bufBytes;
			num2 = this.bufPos;
			this.bufPos = num2 + 1;
			array4[num2] = 59;
			this.textPos = this.bufPos;
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x00045BDC File Offset: 0x00043DDC
		public unsafe override void WriteChars(char[] buffer, int index, int count)
		{
			fixed (char* ptr = &buffer[index])
			{
				char* ptr2 = ptr;
				if (this.inAttributeValue)
				{
					this.WriteAttributeTextBlock(ptr2, ptr2 + count);
				}
				else
				{
					this.WriteElementTextBlock(ptr2, ptr2 + count);
				}
			}
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x00045C1C File Offset: 0x00043E1C
		public unsafe override void WriteRaw(char[] buffer, int index, int count)
		{
			fixed (char* ptr = &buffer[index])
			{
				char* ptr2 = ptr;
				this.WriteRawWithCharChecking(ptr2, ptr2 + count);
			}
			this.textPos = this.bufPos;
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x00045C50 File Offset: 0x00043E50
		public unsafe override void WriteRaw(string data)
		{
			fixed (string text = data)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				this.WriteRawWithCharChecking(ptr, ptr + data.Length);
			}
			this.textPos = this.bufPos;
		}

		// Token: 0x06000A8F RID: 2703 RVA: 0x00045C90 File Offset: 0x00043E90
		public override void Close()
		{
			try
			{
				this.FlushBuffer();
				this.FlushEncoder();
			}
			finally
			{
				this.writeToNull = true;
				if (this.stream != null)
				{
					try
					{
						this.stream.Flush();
					}
					finally
					{
						try
						{
							if (this.closeOutput)
							{
								this.stream.Close();
							}
						}
						finally
						{
							this.stream = null;
						}
					}
				}
			}
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x00045D10 File Offset: 0x00043F10
		public override void Flush()
		{
			this.FlushBuffer();
			this.FlushEncoder();
			if (this.stream != null)
			{
				this.stream.Flush();
			}
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x00045D34 File Offset: 0x00043F34
		protected virtual void FlushBuffer()
		{
			try
			{
				if (!this.writeToNull)
				{
					this.stream.Write(this.bufBytes, 1, this.bufPos - 1);
				}
			}
			catch
			{
				this.writeToNull = true;
				throw;
			}
			finally
			{
				this.bufBytes[0] = this.bufBytes[this.bufPos - 1];
				if (XmlUtf8RawTextWriter.IsSurrogateByte(this.bufBytes[0]))
				{
					this.bufBytes[1] = this.bufBytes[this.bufPos];
					this.bufBytes[2] = this.bufBytes[this.bufPos + 1];
					this.bufBytes[3] = this.bufBytes[this.bufPos + 2];
				}
				this.textPos = ((this.textPos == this.bufPos) ? 1 : 0);
				this.attrEndPos = ((this.attrEndPos == this.bufPos) ? 1 : 0);
				this.contentPos = 0;
				this.cdataPos = 0;
				this.bufPos = 1;
			}
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x0000B528 File Offset: 0x00009728
		private void FlushEncoder()
		{
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x00045E40 File Offset: 0x00044040
		protected unsafe void WriteAttributeTextBlock(char* pSrc, char* pSrcEnd)
		{
			byte[] array;
			byte* ptr;
			if ((array = this.bufBytes) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			byte* ptr2 = ptr + this.bufPos;
			int num = 0;
			for (;;)
			{
				byte* ptr3 = ptr2 + (long)(pSrcEnd - pSrc);
				if (ptr3 != ptr + this.bufLen)
				{
					ptr3 = ptr + this.bufLen;
				}
				while (ptr2 < ptr3 && (this.xmlCharType.charProperties[num = (int)(*pSrc)] & 128) != 0 && num <= 127)
				{
					*ptr2 = (byte)num;
					ptr2++;
					pSrc++;
				}
				if (pSrc >= pSrcEnd)
				{
					break;
				}
				if (ptr2 >= ptr3)
				{
					this.bufPos = (int)((long)(ptr2 - ptr));
					this.FlushBuffer();
					ptr2 = ptr + 1;
				}
				else
				{
					if (num <= 38)
					{
						switch (num)
						{
						case 9:
							if (this.newLineHandling == NewLineHandling.None)
							{
								*ptr2 = (byte)num;
								ptr2++;
								goto IL_1CC;
							}
							ptr2 = XmlUtf8RawTextWriter.TabEntity(ptr2);
							goto IL_1CC;
						case 10:
							if (this.newLineHandling == NewLineHandling.None)
							{
								*ptr2 = (byte)num;
								ptr2++;
								goto IL_1CC;
							}
							ptr2 = XmlUtf8RawTextWriter.LineFeedEntity(ptr2);
							goto IL_1CC;
						case 11:
						case 12:
							break;
						case 13:
							if (this.newLineHandling == NewLineHandling.None)
							{
								*ptr2 = (byte)num;
								ptr2++;
								goto IL_1CC;
							}
							ptr2 = XmlUtf8RawTextWriter.CarriageReturnEntity(ptr2);
							goto IL_1CC;
						default:
							if (num == 34)
							{
								ptr2 = XmlUtf8RawTextWriter.QuoteEntity(ptr2);
								goto IL_1CC;
							}
							if (num == 38)
							{
								ptr2 = XmlUtf8RawTextWriter.AmpEntity(ptr2);
								goto IL_1CC;
							}
							break;
						}
					}
					else
					{
						if (num == 39)
						{
							*ptr2 = (byte)num;
							ptr2++;
							goto IL_1CC;
						}
						if (num == 60)
						{
							ptr2 = XmlUtf8RawTextWriter.LtEntity(ptr2);
							goto IL_1CC;
						}
						if (num == 62)
						{
							ptr2 = XmlUtf8RawTextWriter.GtEntity(ptr2);
							goto IL_1CC;
						}
					}
					if (XmlCharType.IsSurrogate(num))
					{
						ptr2 = XmlUtf8RawTextWriter.EncodeSurrogate(pSrc, pSrcEnd, ptr2);
						pSrc += 2;
						continue;
					}
					if (num <= 127 || num >= 65534)
					{
						ptr2 = this.InvalidXmlChar(num, ptr2, true);
						pSrc++;
						continue;
					}
					ptr2 = XmlUtf8RawTextWriter.EncodeMultibyteUTF8(num, ptr2);
					pSrc++;
					continue;
					IL_1CC:
					pSrc++;
				}
			}
			this.bufPos = (int)((long)(ptr2 - ptr));
			array = null;
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x00046034 File Offset: 0x00044234
		protected unsafe void WriteElementTextBlock(char* pSrc, char* pSrcEnd)
		{
			byte[] array;
			byte* ptr;
			if ((array = this.bufBytes) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			byte* ptr2 = ptr + this.bufPos;
			int num = 0;
			for (;;)
			{
				byte* ptr3 = ptr2 + (long)(pSrcEnd - pSrc);
				if (ptr3 != ptr + this.bufLen)
				{
					ptr3 = ptr + this.bufLen;
				}
				while (ptr2 < ptr3 && (this.xmlCharType.charProperties[num = (int)(*pSrc)] & 128) != 0 && num <= 127)
				{
					*ptr2 = (byte)num;
					ptr2++;
					pSrc++;
				}
				if (pSrc >= pSrcEnd)
				{
					break;
				}
				if (ptr2 < ptr3)
				{
					if (num <= 38)
					{
						switch (num)
						{
						case 9:
							goto IL_108;
						case 10:
							if (this.newLineHandling == NewLineHandling.Replace)
							{
								ptr2 = this.WriteNewLine(ptr2);
								goto IL_1CF;
							}
							*ptr2 = (byte)num;
							ptr2++;
							goto IL_1CF;
						case 11:
						case 12:
							break;
						case 13:
							switch (this.newLineHandling)
							{
							case NewLineHandling.Replace:
								if (pSrc[1] == '\n')
								{
									pSrc++;
								}
								ptr2 = this.WriteNewLine(ptr2);
								goto IL_1CF;
							case NewLineHandling.Entitize:
								ptr2 = XmlUtf8RawTextWriter.CarriageReturnEntity(ptr2);
								goto IL_1CF;
							case NewLineHandling.None:
								*ptr2 = (byte)num;
								ptr2++;
								goto IL_1CF;
							default:
								goto IL_1CF;
							}
							break;
						default:
							if (num == 34)
							{
								goto IL_108;
							}
							if (num == 38)
							{
								ptr2 = XmlUtf8RawTextWriter.AmpEntity(ptr2);
								goto IL_1CF;
							}
							break;
						}
					}
					else
					{
						if (num == 39)
						{
							goto IL_108;
						}
						if (num == 60)
						{
							ptr2 = XmlUtf8RawTextWriter.LtEntity(ptr2);
							goto IL_1CF;
						}
						if (num == 62)
						{
							ptr2 = XmlUtf8RawTextWriter.GtEntity(ptr2);
							goto IL_1CF;
						}
					}
					if (XmlCharType.IsSurrogate(num))
					{
						ptr2 = XmlUtf8RawTextWriter.EncodeSurrogate(pSrc, pSrcEnd, ptr2);
						pSrc += 2;
						continue;
					}
					if (num <= 127 || num >= 65534)
					{
						ptr2 = this.InvalidXmlChar(num, ptr2, true);
						pSrc++;
						continue;
					}
					ptr2 = XmlUtf8RawTextWriter.EncodeMultibyteUTF8(num, ptr2);
					pSrc++;
					continue;
					IL_1CF:
					pSrc++;
					continue;
					IL_108:
					*ptr2 = (byte)num;
					ptr2++;
					goto IL_1CF;
				}
				this.bufPos = (int)((long)(ptr2 - ptr));
				this.FlushBuffer();
				ptr2 = ptr + 1;
			}
			this.bufPos = (int)((long)(ptr2 - ptr));
			this.textPos = this.bufPos;
			this.contentPos = 0;
			array = null;
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x0004623C File Offset: 0x0004443C
		protected unsafe void RawText(string s)
		{
			fixed (string text = s)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				this.RawText(ptr, ptr + s.Length);
			}
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x00046270 File Offset: 0x00044470
		protected unsafe void RawText(char* pSrcBegin, char* pSrcEnd)
		{
			byte[] array;
			byte* ptr;
			if ((array = this.bufBytes) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			byte* ptr2 = ptr + this.bufPos;
			char* ptr3 = pSrcBegin;
			int num = 0;
			for (;;)
			{
				byte* ptr4 = ptr2 + (long)(pSrcEnd - ptr3);
				if (ptr4 != ptr + this.bufLen)
				{
					ptr4 = ptr + this.bufLen;
				}
				while (ptr2 < ptr4 && (num = (int)(*ptr3)) <= 127)
				{
					ptr3++;
					*ptr2 = (byte)num;
					ptr2++;
				}
				if (ptr3 >= pSrcEnd)
				{
					break;
				}
				if (ptr2 >= ptr4)
				{
					this.bufPos = (int)((long)(ptr2 - ptr));
					this.FlushBuffer();
					ptr2 = ptr + 1;
				}
				else if (XmlCharType.IsSurrogate(num))
				{
					ptr2 = XmlUtf8RawTextWriter.EncodeSurrogate(ptr3, pSrcEnd, ptr2);
					ptr3 += 2;
				}
				else if (num <= 127 || num >= 65534)
				{
					ptr2 = this.InvalidXmlChar(num, ptr2, false);
					ptr3++;
				}
				else
				{
					ptr2 = XmlUtf8RawTextWriter.EncodeMultibyteUTF8(num, ptr2);
					ptr3++;
				}
			}
			this.bufPos = (int)((long)(ptr2 - ptr));
			array = null;
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x00046368 File Offset: 0x00044568
		protected unsafe void WriteRawWithCharChecking(char* pSrcBegin, char* pSrcEnd)
		{
			byte[] array;
			byte* ptr;
			if ((array = this.bufBytes) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			char* ptr2 = pSrcBegin;
			byte* ptr3 = ptr + this.bufPos;
			int num = 0;
			for (;;)
			{
				byte* ptr4 = ptr3 + (long)(pSrcEnd - ptr2);
				if (ptr4 != ptr + this.bufLen)
				{
					ptr4 = ptr + this.bufLen;
				}
				while (ptr3 < ptr4 && (this.xmlCharType.charProperties[num = (int)(*ptr2)] & 64) != 0 && num <= 127)
				{
					*ptr3 = (byte)num;
					ptr3++;
					ptr2++;
				}
				if (ptr2 >= pSrcEnd)
				{
					break;
				}
				if (ptr3 < ptr4)
				{
					if (num <= 38)
					{
						switch (num)
						{
						case 9:
							goto IL_D9;
						case 10:
							if (this.newLineHandling == NewLineHandling.Replace)
							{
								ptr3 = this.WriteNewLine(ptr3);
								goto IL_180;
							}
							*ptr3 = (byte)num;
							ptr3++;
							goto IL_180;
						case 11:
						case 12:
							break;
						case 13:
							if (this.newLineHandling == NewLineHandling.Replace)
							{
								if (ptr2[1] == '\n')
								{
									ptr2++;
								}
								ptr3 = this.WriteNewLine(ptr3);
								goto IL_180;
							}
							*ptr3 = (byte)num;
							ptr3++;
							goto IL_180;
						default:
							if (num == 38)
							{
								goto IL_D9;
							}
							break;
						}
					}
					else if (num == 60 || num == 93)
					{
						goto IL_D9;
					}
					if (XmlCharType.IsSurrogate(num))
					{
						ptr3 = XmlUtf8RawTextWriter.EncodeSurrogate(ptr2, pSrcEnd, ptr3);
						ptr2 += 2;
						continue;
					}
					if (num <= 127 || num >= 65534)
					{
						ptr3 = this.InvalidXmlChar(num, ptr3, false);
						ptr2++;
						continue;
					}
					ptr3 = XmlUtf8RawTextWriter.EncodeMultibyteUTF8(num, ptr3);
					ptr2++;
					continue;
					IL_180:
					ptr2++;
					continue;
					IL_D9:
					*ptr3 = (byte)num;
					ptr3++;
					goto IL_180;
				}
				this.bufPos = (int)((long)(ptr3 - ptr));
				this.FlushBuffer();
				ptr3 = ptr + 1;
			}
			this.bufPos = (int)((long)(ptr3 - ptr));
			array = null;
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x00046510 File Offset: 0x00044710
		protected unsafe void WriteCommentOrPi(string text, int stopChar)
		{
			if (text.Length == 0)
			{
				if (this.bufPos >= this.bufLen)
				{
					this.FlushBuffer();
				}
				return;
			}
			fixed (string text2 = text)
			{
				char* ptr = text2;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				byte[] array;
				byte* ptr2;
				if ((array = this.bufBytes) == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = &array[0];
				}
				char* ptr3 = ptr;
				char* ptr4 = ptr + text.Length;
				byte* ptr5 = ptr2 + this.bufPos;
				int num = 0;
				for (;;)
				{
					byte* ptr6 = ptr5 + (long)(ptr4 - ptr3);
					if (ptr6 != ptr2 + this.bufLen)
					{
						ptr6 = ptr2 + this.bufLen;
					}
					while (ptr5 < ptr6 && (this.xmlCharType.charProperties[num = (int)(*ptr3)] & 64) != 0 && num != stopChar && num <= 127)
					{
						*ptr5 = (byte)num;
						ptr5++;
						ptr3++;
					}
					if (ptr3 >= ptr4)
					{
						break;
					}
					if (ptr5 < ptr6)
					{
						if (num <= 45)
						{
							switch (num)
							{
							case 9:
								goto IL_220;
							case 10:
								if (this.newLineHandling == NewLineHandling.Replace)
								{
									ptr5 = this.WriteNewLine(ptr5);
									goto IL_28F;
								}
								*ptr5 = (byte)num;
								ptr5++;
								goto IL_28F;
							case 11:
							case 12:
								break;
							case 13:
								if (this.newLineHandling == NewLineHandling.Replace)
								{
									if (ptr3[1] == '\n')
									{
										ptr3++;
									}
									ptr5 = this.WriteNewLine(ptr5);
									goto IL_28F;
								}
								*ptr5 = (byte)num;
								ptr5++;
								goto IL_28F;
							default:
								if (num == 38)
								{
									goto IL_220;
								}
								if (num == 45)
								{
									*ptr5 = 45;
									ptr5++;
									if (num == stopChar && (ptr3 + 1 == ptr4 || ptr3[1] == '-'))
									{
										*ptr5 = 32;
										ptr5++;
										goto IL_28F;
									}
									goto IL_28F;
								}
								break;
							}
						}
						else
						{
							if (num == 60)
							{
								goto IL_220;
							}
							if (num != 63)
							{
								if (num == 93)
								{
									*ptr5 = 93;
									ptr5++;
									goto IL_28F;
								}
							}
							else
							{
								*ptr5 = 63;
								ptr5++;
								if (num == stopChar && ptr3 + 1 < ptr4 && ptr3[1] == '>')
								{
									*ptr5 = 32;
									ptr5++;
									goto IL_28F;
								}
								goto IL_28F;
							}
						}
						if (XmlCharType.IsSurrogate(num))
						{
							ptr5 = XmlUtf8RawTextWriter.EncodeSurrogate(ptr3, ptr4, ptr5);
							ptr3 += 2;
							continue;
						}
						if (num <= 127 || num >= 65534)
						{
							ptr5 = this.InvalidXmlChar(num, ptr5, false);
							ptr3++;
							continue;
						}
						ptr5 = XmlUtf8RawTextWriter.EncodeMultibyteUTF8(num, ptr5);
						ptr3++;
						continue;
						IL_28F:
						ptr3++;
						continue;
						IL_220:
						*ptr5 = (byte)num;
						ptr5++;
						goto IL_28F;
					}
					this.bufPos = (int)((long)(ptr5 - ptr2));
					this.FlushBuffer();
					ptr5 = ptr2 + 1;
				}
				this.bufPos = (int)((long)(ptr5 - ptr2));
				array = null;
			}
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x000467CC File Offset: 0x000449CC
		protected unsafe void WriteCDataSection(string text)
		{
			if (text.Length == 0)
			{
				if (this.bufPos >= this.bufLen)
				{
					this.FlushBuffer();
				}
				return;
			}
			fixed (string text2 = text)
			{
				char* ptr = text2;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				byte[] array;
				byte* ptr2;
				if ((array = this.bufBytes) == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = &array[0];
				}
				char* ptr3 = ptr;
				char* ptr4 = ptr + text.Length;
				byte* ptr5 = ptr2 + this.bufPos;
				int num = 0;
				for (;;)
				{
					byte* ptr6 = ptr5 + (long)(ptr4 - ptr3);
					if (ptr6 != ptr2 + this.bufLen)
					{
						ptr6 = ptr2 + this.bufLen;
					}
					while (ptr5 < ptr6 && (this.xmlCharType.charProperties[num = (int)(*ptr3)] & 128) != 0 && num != 93 && num <= 127)
					{
						*ptr5 = (byte)num;
						ptr5++;
						ptr3++;
					}
					if (ptr3 >= ptr4)
					{
						break;
					}
					if (ptr5 < ptr6)
					{
						if (num <= 39)
						{
							switch (num)
							{
							case 9:
								goto IL_204;
							case 10:
								if (this.newLineHandling == NewLineHandling.Replace)
								{
									ptr5 = this.WriteNewLine(ptr5);
									goto IL_273;
								}
								*ptr5 = (byte)num;
								ptr5++;
								goto IL_273;
							case 11:
							case 12:
								break;
							case 13:
								if (this.newLineHandling == NewLineHandling.Replace)
								{
									if (ptr3[1] == '\n')
									{
										ptr3++;
									}
									ptr5 = this.WriteNewLine(ptr5);
									goto IL_273;
								}
								*ptr5 = (byte)num;
								ptr5++;
								goto IL_273;
							default:
								if (num == 34 || num - 38 <= 1)
								{
									goto IL_204;
								}
								break;
							}
						}
						else
						{
							if (num == 60)
							{
								goto IL_204;
							}
							if (num == 62)
							{
								if (this.hadDoubleBracket && ptr5[-1] == 93)
								{
									ptr5 = XmlUtf8RawTextWriter.RawEndCData(ptr5);
									ptr5 = XmlUtf8RawTextWriter.RawStartCData(ptr5);
								}
								*ptr5 = 62;
								ptr5++;
								goto IL_273;
							}
							if (num == 93)
							{
								if (ptr5[-1] == 93)
								{
									this.hadDoubleBracket = true;
								}
								else
								{
									this.hadDoubleBracket = false;
								}
								*ptr5 = 93;
								ptr5++;
								goto IL_273;
							}
						}
						if (XmlCharType.IsSurrogate(num))
						{
							ptr5 = XmlUtf8RawTextWriter.EncodeSurrogate(ptr3, ptr4, ptr5);
							ptr3 += 2;
							continue;
						}
						if (num <= 127 || num >= 65534)
						{
							ptr5 = this.InvalidXmlChar(num, ptr5, false);
							ptr3++;
							continue;
						}
						ptr5 = XmlUtf8RawTextWriter.EncodeMultibyteUTF8(num, ptr5);
						ptr3++;
						continue;
						IL_273:
						ptr3++;
						continue;
						IL_204:
						*ptr5 = (byte)num;
						ptr5++;
						goto IL_273;
					}
					this.bufPos = (int)((long)(ptr5 - ptr2));
					this.FlushBuffer();
					ptr5 = ptr2 + 1;
				}
				this.bufPos = (int)((long)(ptr5 - ptr2));
				array = null;
			}
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x00046A69 File Offset: 0x00044C69
		private static bool IsSurrogateByte(byte b)
		{
			return (b & 248) == 240;
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x00046A7C File Offset: 0x00044C7C
		private unsafe static byte* EncodeSurrogate(char* pSrc, char* pSrcEnd, byte* pDst)
		{
			int num = (int)(*pSrc);
			if (num > 56319)
			{
				throw XmlConvert.CreateInvalidHighSurrogateCharException((char)num);
			}
			if (pSrc + 1 >= pSrcEnd)
			{
				throw new ArgumentException(Res.GetString("The surrogate pair is invalid. Missing a low surrogate character."));
			}
			int num2 = (int)pSrc[1];
			if (num2 >= 56320 && (LocalAppContextSwitches.DontThrowOnInvalidSurrogatePairs || num2 <= 57343))
			{
				num = XmlCharType.CombineSurrogateChar(num2, num);
				*pDst = (byte)(240 | num >> 18);
				pDst[1] = (byte)(128 | (num >> 12 & 63));
				pDst[2] = (byte)(128 | (num >> 6 & 63));
				pDst[3] = (byte)(128 | (num & 63));
				pDst += 4;
				return pDst;
			}
			throw XmlConvert.CreateInvalidSurrogatePairException((char)num2, (char)num);
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x00046B28 File Offset: 0x00044D28
		private unsafe byte* InvalidXmlChar(int ch, byte* pDst, bool entitize)
		{
			if (this.checkCharacters)
			{
				throw XmlConvert.CreateInvalidCharException((char)ch, '\0');
			}
			if (entitize)
			{
				return XmlUtf8RawTextWriter.CharEntity(pDst, (char)ch);
			}
			if (ch < 128)
			{
				*pDst = (byte)ch;
				pDst++;
			}
			else
			{
				pDst = XmlUtf8RawTextWriter.EncodeMultibyteUTF8(ch, pDst);
			}
			return pDst;
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x00046B64 File Offset: 0x00044D64
		internal unsafe void EncodeChar(ref char* pSrc, char* pSrcEnd, ref byte* pDst)
		{
			int num = (int)(*pSrc);
			if (XmlCharType.IsSurrogate(num))
			{
				pDst = XmlUtf8RawTextWriter.EncodeSurrogate(pSrc, pSrcEnd, pDst);
				pSrc += (IntPtr)2 * 2;
				return;
			}
			if (num <= 127 || num >= 65534)
			{
				pDst = this.InvalidXmlChar(num, pDst, false);
				pSrc += 2;
				return;
			}
			pDst = XmlUtf8RawTextWriter.EncodeMultibyteUTF8(num, pDst);
			pSrc += 2;
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x00046BC4 File Offset: 0x00044DC4
		internal unsafe static byte* EncodeMultibyteUTF8(int ch, byte* pDst)
		{
			if (ch < 2048)
			{
				*pDst = (byte)(-64 | ch >> 6);
			}
			else
			{
				*pDst = (byte)(-32 | ch >> 12);
				pDst++;
				*pDst = (byte)(-128 | (ch >> 6 & 63));
			}
			pDst++;
			*pDst = (byte)(128 | (ch & 63));
			return pDst + 1;
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x00046C14 File Offset: 0x00044E14
		internal unsafe static void CharToUTF8(ref char* pSrc, char* pSrcEnd, ref byte* pDst)
		{
			int num = (int)(*pSrc);
			if (num <= 127)
			{
				*pDst = (byte)num;
				pDst++;
				pSrc += 2;
				return;
			}
			if (XmlCharType.IsSurrogate(num))
			{
				pDst = XmlUtf8RawTextWriter.EncodeSurrogate(pSrc, pSrcEnd, pDst);
				pSrc += (IntPtr)2 * 2;
				return;
			}
			pDst = XmlUtf8RawTextWriter.EncodeMultibyteUTF8(num, pDst);
			pSrc += 2;
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x00046C6C File Offset: 0x00044E6C
		protected unsafe byte* WriteNewLine(byte* pDst)
		{
			byte[] array;
			byte* ptr;
			if ((array = this.bufBytes) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			this.bufPos = (int)((long)(pDst - ptr));
			this.RawText(this.newLineChars);
			return ptr + this.bufPos;
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x00046CB7 File Offset: 0x00044EB7
		protected unsafe static byte* LtEntity(byte* pDst)
		{
			*pDst = 38;
			pDst[1] = 108;
			pDst[2] = 116;
			pDst[3] = 59;
			return pDst + 4;
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x00046CD2 File Offset: 0x00044ED2
		protected unsafe static byte* GtEntity(byte* pDst)
		{
			*pDst = 38;
			pDst[1] = 103;
			pDst[2] = 116;
			pDst[3] = 59;
			return pDst + 4;
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x00046CED File Offset: 0x00044EED
		protected unsafe static byte* AmpEntity(byte* pDst)
		{
			*pDst = 38;
			pDst[1] = 97;
			pDst[2] = 109;
			pDst[3] = 112;
			pDst[4] = 59;
			return pDst + 5;
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x00046D0E File Offset: 0x00044F0E
		protected unsafe static byte* QuoteEntity(byte* pDst)
		{
			*pDst = 38;
			pDst[1] = 113;
			pDst[2] = 117;
			pDst[3] = 111;
			pDst[4] = 116;
			pDst[5] = 59;
			return pDst + 6;
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x00046D35 File Offset: 0x00044F35
		protected unsafe static byte* TabEntity(byte* pDst)
		{
			*pDst = 38;
			pDst[1] = 35;
			pDst[2] = 120;
			pDst[3] = 57;
			pDst[4] = 59;
			return pDst + 5;
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x00046D56 File Offset: 0x00044F56
		protected unsafe static byte* LineFeedEntity(byte* pDst)
		{
			*pDst = 38;
			pDst[1] = 35;
			pDst[2] = 120;
			pDst[3] = 65;
			pDst[4] = 59;
			return pDst + 5;
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x00046D77 File Offset: 0x00044F77
		protected unsafe static byte* CarriageReturnEntity(byte* pDst)
		{
			*pDst = 38;
			pDst[1] = 35;
			pDst[2] = 120;
			pDst[3] = 68;
			pDst[4] = 59;
			return pDst + 5;
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x00046D98 File Offset: 0x00044F98
		private unsafe static byte* CharEntity(byte* pDst, char ch)
		{
			int num = (int)ch;
			string text = num.ToString("X", NumberFormatInfo.InvariantInfo);
			*pDst = 38;
			pDst[1] = 35;
			pDst[2] = 120;
			pDst += 3;
			fixed (string text2 = text)
			{
				char* ptr = text2;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				char* ptr2 = ptr;
				while ((*(pDst++) = (byte)(*(ptr2++))) != 0)
				{
				}
			}
			pDst[-1] = 59;
			return pDst;
		}

		// Token: 0x06000AA9 RID: 2729 RVA: 0x00046DFC File Offset: 0x00044FFC
		protected unsafe static byte* RawStartCData(byte* pDst)
		{
			*pDst = 60;
			pDst[1] = 33;
			pDst[2] = 91;
			pDst[3] = 67;
			pDst[4] = 68;
			pDst[5] = 65;
			pDst[6] = 84;
			pDst[7] = 65;
			pDst[8] = 91;
			return pDst + 9;
		}

		// Token: 0x06000AAA RID: 2730 RVA: 0x00046E36 File Offset: 0x00045036
		protected unsafe static byte* RawEndCData(byte* pDst)
		{
			*pDst = 93;
			pDst[1] = 93;
			pDst[2] = 62;
			return pDst + 3;
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x00046E4C File Offset: 0x0004504C
		protected void ValidateContentChars(string chars, string propertyName, bool allowOnlyWhitespace)
		{
			if (!allowOnlyWhitespace)
			{
				for (int i = 0; i < chars.Length; i++)
				{
					if (!this.xmlCharType.IsTextChar(chars[i]))
					{
						char c = chars[i];
						if (c <= '&')
						{
							switch (c)
							{
							case '\t':
							case '\n':
							case '\r':
								goto IL_11C;
							case '\v':
							case '\f':
								goto IL_A2;
							default:
								if (c != '&')
								{
									goto IL_A2;
								}
								break;
							}
						}
						else if (c != '<' && c != ']')
						{
							goto IL_A2;
						}
						string name = "'{0}', hexadecimal value {1}, is an invalid character.";
						object[] args = XmlException.BuildCharExceptionArgs(chars, i);
						string @string = Res.GetString(name, args);
						goto IL_12D;
						IL_A2:
						if (XmlCharType.IsHighSurrogate((int)chars[i]))
						{
							if (i + 1 < chars.Length && XmlCharType.IsLowSurrogate((int)chars[i + 1]))
							{
								i++;
								goto IL_11C;
							}
							@string = Res.GetString("The surrogate pair is invalid. Missing a low surrogate character.");
						}
						else
						{
							if (!XmlCharType.IsLowSurrogate((int)chars[i]))
							{
								goto IL_11C;
							}
							@string = Res.GetString("Invalid high surrogate character (0x{0}). A high surrogate character must have a value from range (0xD800 - 0xDBFF).", new object[]
							{
								((uint)chars[i]).ToString("X", CultureInfo.InvariantCulture)
							});
						}
						IL_12D:
						string name2 = "XmlWriterSettings.{0} can contain only valid XML text content characters when XmlWriterSettings.CheckCharacters is true. {1}";
						args = new string[]
						{
							propertyName,
							@string
						};
						throw new ArgumentException(Res.GetString(name2, args));
					}
					IL_11C:;
				}
				return;
			}
			if (!this.xmlCharType.IsOnlyWhitespace(chars))
			{
				throw new ArgumentException(Res.GetString("XmlWriterSettings.{0} can contain only valid XML white space characters when XmlWriterSettings.CheckCharacters and XmlWriterSettings.NewLineOnAttributes are true.", new object[]
				{
					propertyName
				}));
			}
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x00046FA6 File Offset: 0x000451A6
		protected void CheckAsyncCall()
		{
			if (!this.useAsync)
			{
				throw new InvalidOperationException(Res.GetString("Set XmlWriterSettings.Async to true if you want to use Async Methods."));
			}
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x00046FC0 File Offset: 0x000451C0
		internal override Task WriteXmlDeclarationAsync(XmlStandalone standalone)
		{
			XmlUtf8RawTextWriter.<WriteXmlDeclarationAsync>d__86 <WriteXmlDeclarationAsync>d__;
			<WriteXmlDeclarationAsync>d__.<>4__this = this;
			<WriteXmlDeclarationAsync>d__.standalone = standalone;
			<WriteXmlDeclarationAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteXmlDeclarationAsync>d__.<>1__state = -1;
			<WriteXmlDeclarationAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<WriteXmlDeclarationAsync>d__86>(ref <WriteXmlDeclarationAsync>d__);
			return <WriteXmlDeclarationAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x0004700B File Offset: 0x0004520B
		internal override Task WriteXmlDeclarationAsync(string xmldecl)
		{
			this.CheckAsyncCall();
			if (!this.omitXmlDeclaration && !this.autoXmlDeclaration)
			{
				return this.WriteProcessingInstructionAsync("xml", xmldecl);
			}
			return AsyncHelper.DoneTask;
		}

		// Token: 0x06000AAF RID: 2735 RVA: 0x00047038 File Offset: 0x00045238
		public override Task WriteDocTypeAsync(string name, string pubid, string sysid, string subset)
		{
			XmlUtf8RawTextWriter.<WriteDocTypeAsync>d__88 <WriteDocTypeAsync>d__;
			<WriteDocTypeAsync>d__.<>4__this = this;
			<WriteDocTypeAsync>d__.name = name;
			<WriteDocTypeAsync>d__.pubid = pubid;
			<WriteDocTypeAsync>d__.sysid = sysid;
			<WriteDocTypeAsync>d__.subset = subset;
			<WriteDocTypeAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteDocTypeAsync>d__.<>1__state = -1;
			<WriteDocTypeAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<WriteDocTypeAsync>d__88>(ref <WriteDocTypeAsync>d__);
			return <WriteDocTypeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000AB0 RID: 2736 RVA: 0x0004709C File Offset: 0x0004529C
		public override Task WriteStartElementAsync(string prefix, string localName, string ns)
		{
			this.CheckAsyncCall();
			byte[] array = this.bufBytes;
			int num = this.bufPos;
			this.bufPos = num + 1;
			array[num] = 60;
			Task task;
			if (prefix != null && prefix.Length != 0)
			{
				task = this.RawTextAsync(prefix + ":" + localName);
			}
			else
			{
				task = this.RawTextAsync(localName);
			}
			return task.CallVoidFuncWhenFinish(new Action(this.WriteStartElementAsync_SetAttEndPos));
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x00047103 File Offset: 0x00045303
		private void WriteStartElementAsync_SetAttEndPos()
		{
			this.attrEndPos = this.bufPos;
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x00047114 File Offset: 0x00045314
		internal override Task WriteEndElementAsync(string prefix, string localName, string ns)
		{
			this.CheckAsyncCall();
			int num;
			if (this.contentPos == this.bufPos)
			{
				this.bufPos--;
				byte[] array = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array[num] = 32;
				byte[] array2 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array2[num] = 47;
				byte[] array3 = this.bufBytes;
				num = this.bufPos;
				this.bufPos = num + 1;
				array3[num] = 62;
				return AsyncHelper.DoneTask;
			}
			byte[] array4 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array4[num] = 60;
			byte[] array5 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array5[num] = 47;
			if (prefix != null && prefix.Length != 0)
			{
				return this.RawTextAsync(prefix + ":" + localName + ">");
			}
			return this.RawTextAsync(localName + ">");
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x00047200 File Offset: 0x00045400
		internal override Task WriteFullEndElementAsync(string prefix, string localName, string ns)
		{
			this.CheckAsyncCall();
			byte[] array = this.bufBytes;
			int num = this.bufPos;
			this.bufPos = num + 1;
			array[num] = 60;
			byte[] array2 = this.bufBytes;
			num = this.bufPos;
			this.bufPos = num + 1;
			array2[num] = 47;
			if (prefix != null && prefix.Length != 0)
			{
				return this.RawTextAsync(prefix + ":" + localName + ">");
			}
			return this.RawTextAsync(localName + ">");
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x0004727C File Offset: 0x0004547C
		protected internal override Task WriteStartAttributeAsync(string prefix, string localName, string ns)
		{
			this.CheckAsyncCall();
			if (this.attrEndPos == this.bufPos)
			{
				byte[] array = this.bufBytes;
				int num = this.bufPos;
				this.bufPos = num + 1;
				array[num] = 32;
			}
			Task task;
			if (prefix != null && prefix.Length > 0)
			{
				task = this.RawTextAsync(prefix + ":" + localName + "=\"");
			}
			else
			{
				task = this.RawTextAsync(localName + "=\"");
			}
			return task.CallVoidFuncWhenFinish(new Action(this.WriteStartAttribute_SetInAttribute));
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x0000FF4C File Offset: 0x0000E14C
		private void WriteStartAttribute_SetInAttribute()
		{
			this.inAttributeValue = true;
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x00047304 File Offset: 0x00045504
		protected internal override Task WriteEndAttributeAsync()
		{
			this.CheckAsyncCall();
			byte[] array = this.bufBytes;
			int num = this.bufPos;
			this.bufPos = num + 1;
			array[num] = 34;
			this.inAttributeValue = false;
			this.attrEndPos = this.bufPos;
			return AsyncHelper.DoneTask;
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x0004734C File Offset: 0x0004554C
		internal override Task WriteNamespaceDeclarationAsync(string prefix, string namespaceName)
		{
			XmlUtf8RawTextWriter.<WriteNamespaceDeclarationAsync>d__96 <WriteNamespaceDeclarationAsync>d__;
			<WriteNamespaceDeclarationAsync>d__.<>4__this = this;
			<WriteNamespaceDeclarationAsync>d__.prefix = prefix;
			<WriteNamespaceDeclarationAsync>d__.namespaceName = namespaceName;
			<WriteNamespaceDeclarationAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteNamespaceDeclarationAsync>d__.<>1__state = -1;
			<WriteNamespaceDeclarationAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<WriteNamespaceDeclarationAsync>d__96>(ref <WriteNamespaceDeclarationAsync>d__);
			return <WriteNamespaceDeclarationAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x000473A0 File Offset: 0x000455A0
		internal override Task WriteStartNamespaceDeclarationAsync(string prefix)
		{
			XmlUtf8RawTextWriter.<WriteStartNamespaceDeclarationAsync>d__97 <WriteStartNamespaceDeclarationAsync>d__;
			<WriteStartNamespaceDeclarationAsync>d__.<>4__this = this;
			<WriteStartNamespaceDeclarationAsync>d__.prefix = prefix;
			<WriteStartNamespaceDeclarationAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteStartNamespaceDeclarationAsync>d__.<>1__state = -1;
			<WriteStartNamespaceDeclarationAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<WriteStartNamespaceDeclarationAsync>d__97>(ref <WriteStartNamespaceDeclarationAsync>d__);
			return <WriteStartNamespaceDeclarationAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x000473EC File Offset: 0x000455EC
		internal override Task WriteEndNamespaceDeclarationAsync()
		{
			this.CheckAsyncCall();
			this.inAttributeValue = false;
			byte[] array = this.bufBytes;
			int num = this.bufPos;
			this.bufPos = num + 1;
			array[num] = 34;
			this.attrEndPos = this.bufPos;
			return AsyncHelper.DoneTask;
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x00047434 File Offset: 0x00045634
		public override Task WriteCDataAsync(string text)
		{
			XmlUtf8RawTextWriter.<WriteCDataAsync>d__99 <WriteCDataAsync>d__;
			<WriteCDataAsync>d__.<>4__this = this;
			<WriteCDataAsync>d__.text = text;
			<WriteCDataAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteCDataAsync>d__.<>1__state = -1;
			<WriteCDataAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<WriteCDataAsync>d__99>(ref <WriteCDataAsync>d__);
			return <WriteCDataAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x00047480 File Offset: 0x00045680
		public override Task WriteCommentAsync(string text)
		{
			XmlUtf8RawTextWriter.<WriteCommentAsync>d__100 <WriteCommentAsync>d__;
			<WriteCommentAsync>d__.<>4__this = this;
			<WriteCommentAsync>d__.text = text;
			<WriteCommentAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteCommentAsync>d__.<>1__state = -1;
			<WriteCommentAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<WriteCommentAsync>d__100>(ref <WriteCommentAsync>d__);
			return <WriteCommentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x000474CC File Offset: 0x000456CC
		public override Task WriteProcessingInstructionAsync(string name, string text)
		{
			XmlUtf8RawTextWriter.<WriteProcessingInstructionAsync>d__101 <WriteProcessingInstructionAsync>d__;
			<WriteProcessingInstructionAsync>d__.<>4__this = this;
			<WriteProcessingInstructionAsync>d__.name = name;
			<WriteProcessingInstructionAsync>d__.text = text;
			<WriteProcessingInstructionAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteProcessingInstructionAsync>d__.<>1__state = -1;
			<WriteProcessingInstructionAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<WriteProcessingInstructionAsync>d__101>(ref <WriteProcessingInstructionAsync>d__);
			return <WriteProcessingInstructionAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x00047520 File Offset: 0x00045720
		public override Task WriteEntityRefAsync(string name)
		{
			XmlUtf8RawTextWriter.<WriteEntityRefAsync>d__102 <WriteEntityRefAsync>d__;
			<WriteEntityRefAsync>d__.<>4__this = this;
			<WriteEntityRefAsync>d__.name = name;
			<WriteEntityRefAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteEntityRefAsync>d__.<>1__state = -1;
			<WriteEntityRefAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<WriteEntityRefAsync>d__102>(ref <WriteEntityRefAsync>d__);
			return <WriteEntityRefAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x0004756C File Offset: 0x0004576C
		public override Task WriteCharEntityAsync(char ch)
		{
			XmlUtf8RawTextWriter.<WriteCharEntityAsync>d__103 <WriteCharEntityAsync>d__;
			<WriteCharEntityAsync>d__.<>4__this = this;
			<WriteCharEntityAsync>d__.ch = ch;
			<WriteCharEntityAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteCharEntityAsync>d__.<>1__state = -1;
			<WriteCharEntityAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<WriteCharEntityAsync>d__103>(ref <WriteCharEntityAsync>d__);
			return <WriteCharEntityAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x000475B7 File Offset: 0x000457B7
		public override Task WriteWhitespaceAsync(string ws)
		{
			this.CheckAsyncCall();
			if (this.inAttributeValue)
			{
				return this.WriteAttributeTextBlockAsync(ws);
			}
			return this.WriteElementTextBlockAsync(ws);
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x000475B7 File Offset: 0x000457B7
		public override Task WriteStringAsync(string text)
		{
			this.CheckAsyncCall();
			if (this.inAttributeValue)
			{
				return this.WriteAttributeTextBlockAsync(text);
			}
			return this.WriteElementTextBlockAsync(text);
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x000475D8 File Offset: 0x000457D8
		public override Task WriteSurrogateCharEntityAsync(char lowChar, char highChar)
		{
			XmlUtf8RawTextWriter.<WriteSurrogateCharEntityAsync>d__106 <WriteSurrogateCharEntityAsync>d__;
			<WriteSurrogateCharEntityAsync>d__.<>4__this = this;
			<WriteSurrogateCharEntityAsync>d__.lowChar = lowChar;
			<WriteSurrogateCharEntityAsync>d__.highChar = highChar;
			<WriteSurrogateCharEntityAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteSurrogateCharEntityAsync>d__.<>1__state = -1;
			<WriteSurrogateCharEntityAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<WriteSurrogateCharEntityAsync>d__106>(ref <WriteSurrogateCharEntityAsync>d__);
			return <WriteSurrogateCharEntityAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x0004762B File Offset: 0x0004582B
		public override Task WriteCharsAsync(char[] buffer, int index, int count)
		{
			this.CheckAsyncCall();
			if (this.inAttributeValue)
			{
				return this.WriteAttributeTextBlockAsync(buffer, index, count);
			}
			return this.WriteElementTextBlockAsync(buffer, index, count);
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x00047650 File Offset: 0x00045850
		public override Task WriteRawAsync(char[] buffer, int index, int count)
		{
			XmlUtf8RawTextWriter.<WriteRawAsync>d__108 <WriteRawAsync>d__;
			<WriteRawAsync>d__.<>4__this = this;
			<WriteRawAsync>d__.buffer = buffer;
			<WriteRawAsync>d__.index = index;
			<WriteRawAsync>d__.count = count;
			<WriteRawAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteRawAsync>d__.<>1__state = -1;
			<WriteRawAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<WriteRawAsync>d__108>(ref <WriteRawAsync>d__);
			return <WriteRawAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x000476AC File Offset: 0x000458AC
		public override Task WriteRawAsync(string data)
		{
			XmlUtf8RawTextWriter.<WriteRawAsync>d__109 <WriteRawAsync>d__;
			<WriteRawAsync>d__.<>4__this = this;
			<WriteRawAsync>d__.data = data;
			<WriteRawAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteRawAsync>d__.<>1__state = -1;
			<WriteRawAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<WriteRawAsync>d__109>(ref <WriteRawAsync>d__);
			return <WriteRawAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x000476F8 File Offset: 0x000458F8
		public override Task FlushAsync()
		{
			XmlUtf8RawTextWriter.<FlushAsync>d__110 <FlushAsync>d__;
			<FlushAsync>d__.<>4__this = this;
			<FlushAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<FlushAsync>d__.<>1__state = -1;
			<FlushAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<FlushAsync>d__110>(ref <FlushAsync>d__);
			return <FlushAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x0004773C File Offset: 0x0004593C
		protected virtual Task FlushBufferAsync()
		{
			XmlUtf8RawTextWriter.<FlushBufferAsync>d__111 <FlushBufferAsync>d__;
			<FlushBufferAsync>d__.<>4__this = this;
			<FlushBufferAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<FlushBufferAsync>d__.<>1__state = -1;
			<FlushBufferAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<FlushBufferAsync>d__111>(ref <FlushBufferAsync>d__);
			return <FlushBufferAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x0001E21A File Offset: 0x0001C41A
		private Task FlushEncoderAsync()
		{
			return AsyncHelper.DoneTask;
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x00047780 File Offset: 0x00045980
		[SecuritySafeCritical]
		protected unsafe int WriteAttributeTextBlockNoFlush(char* pSrc, char* pSrcEnd)
		{
			char* ptr = pSrc;
			byte[] array;
			byte* ptr2;
			if ((array = this.bufBytes) == null || array.Length == 0)
			{
				ptr2 = null;
			}
			else
			{
				ptr2 = &array[0];
			}
			byte* ptr3 = ptr2 + this.bufPos;
			int num = 0;
			for (;;)
			{
				byte* ptr4 = ptr3 + (long)(pSrcEnd - pSrc);
				if (ptr4 != ptr2 + this.bufLen)
				{
					ptr4 = ptr2 + this.bufLen;
				}
				while (ptr3 < ptr4 && (this.xmlCharType.charProperties[num = (int)(*pSrc)] & 128) != 0 && num <= 127)
				{
					*ptr3 = (byte)num;
					ptr3++;
					pSrc++;
				}
				if (pSrc >= pSrcEnd)
				{
					goto IL_1E8;
				}
				if (ptr3 >= ptr4)
				{
					break;
				}
				if (num <= 38)
				{
					switch (num)
					{
					case 9:
						if (this.newLineHandling == NewLineHandling.None)
						{
							*ptr3 = (byte)num;
							ptr3++;
							goto IL_1DE;
						}
						ptr3 = XmlUtf8RawTextWriter.TabEntity(ptr3);
						goto IL_1DE;
					case 10:
						if (this.newLineHandling == NewLineHandling.None)
						{
							*ptr3 = (byte)num;
							ptr3++;
							goto IL_1DE;
						}
						ptr3 = XmlUtf8RawTextWriter.LineFeedEntity(ptr3);
						goto IL_1DE;
					case 11:
					case 12:
						break;
					case 13:
						if (this.newLineHandling == NewLineHandling.None)
						{
							*ptr3 = (byte)num;
							ptr3++;
							goto IL_1DE;
						}
						ptr3 = XmlUtf8RawTextWriter.CarriageReturnEntity(ptr3);
						goto IL_1DE;
					default:
						if (num == 34)
						{
							ptr3 = XmlUtf8RawTextWriter.QuoteEntity(ptr3);
							goto IL_1DE;
						}
						if (num == 38)
						{
							ptr3 = XmlUtf8RawTextWriter.AmpEntity(ptr3);
							goto IL_1DE;
						}
						break;
					}
				}
				else
				{
					if (num == 39)
					{
						*ptr3 = (byte)num;
						ptr3++;
						goto IL_1DE;
					}
					if (num == 60)
					{
						ptr3 = XmlUtf8RawTextWriter.LtEntity(ptr3);
						goto IL_1DE;
					}
					if (num == 62)
					{
						ptr3 = XmlUtf8RawTextWriter.GtEntity(ptr3);
						goto IL_1DE;
					}
				}
				if (XmlCharType.IsSurrogate(num))
				{
					ptr3 = XmlUtf8RawTextWriter.EncodeSurrogate(pSrc, pSrcEnd, ptr3);
					pSrc += 2;
					continue;
				}
				if (num <= 127 || num >= 65534)
				{
					ptr3 = this.InvalidXmlChar(num, ptr3, true);
					pSrc++;
					continue;
				}
				ptr3 = XmlUtf8RawTextWriter.EncodeMultibyteUTF8(num, ptr3);
				pSrc++;
				continue;
				IL_1DE:
				pSrc++;
			}
			this.bufPos = (int)((long)(ptr3 - ptr2));
			return (int)((long)(pSrc - ptr));
			IL_1E8:
			this.bufPos = (int)((long)(ptr3 - ptr2));
			array = null;
			return -1;
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x00047988 File Offset: 0x00045B88
		[SecuritySafeCritical]
		protected unsafe int WriteAttributeTextBlockNoFlush(char[] chars, int index, int count)
		{
			if (count == 0)
			{
				return -1;
			}
			fixed (char* ptr = &chars[index])
			{
				char* ptr2 = ptr;
				char* pSrcEnd = ptr2 + count;
				return this.WriteAttributeTextBlockNoFlush(ptr2, pSrcEnd);
			}
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x000479B4 File Offset: 0x00045BB4
		[SecuritySafeCritical]
		protected unsafe int WriteAttributeTextBlockNoFlush(string text, int index, int count)
		{
			if (count == 0)
			{
				return -1;
			}
			char* ptr = text;
			if (ptr != null)
			{
				ptr += RuntimeHelpers.OffsetToStringData / 2;
			}
			char* ptr2 = ptr + index;
			char* pSrcEnd = ptr2 + count;
			return this.WriteAttributeTextBlockNoFlush(ptr2, pSrcEnd);
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x000479EC File Offset: 0x00045BEC
		protected Task WriteAttributeTextBlockAsync(char[] chars, int index, int count)
		{
			XmlUtf8RawTextWriter.<WriteAttributeTextBlockAsync>d__116 <WriteAttributeTextBlockAsync>d__;
			<WriteAttributeTextBlockAsync>d__.<>4__this = this;
			<WriteAttributeTextBlockAsync>d__.chars = chars;
			<WriteAttributeTextBlockAsync>d__.index = index;
			<WriteAttributeTextBlockAsync>d__.count = count;
			<WriteAttributeTextBlockAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteAttributeTextBlockAsync>d__.<>1__state = -1;
			<WriteAttributeTextBlockAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<WriteAttributeTextBlockAsync>d__116>(ref <WriteAttributeTextBlockAsync>d__);
			return <WriteAttributeTextBlockAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x00047A48 File Offset: 0x00045C48
		protected Task WriteAttributeTextBlockAsync(string text)
		{
			int num = 0;
			int num2 = text.Length;
			int num3 = this.WriteAttributeTextBlockNoFlush(text, num, num2);
			num += num3;
			num2 -= num3;
			if (num3 >= 0)
			{
				return this._WriteAttributeTextBlockAsync(text, num, num2);
			}
			return AsyncHelper.DoneTask;
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x00047A88 File Offset: 0x00045C88
		private Task _WriteAttributeTextBlockAsync(string text, int curIndex, int leftCount)
		{
			XmlUtf8RawTextWriter.<_WriteAttributeTextBlockAsync>d__118 <_WriteAttributeTextBlockAsync>d__;
			<_WriteAttributeTextBlockAsync>d__.<>4__this = this;
			<_WriteAttributeTextBlockAsync>d__.text = text;
			<_WriteAttributeTextBlockAsync>d__.curIndex = curIndex;
			<_WriteAttributeTextBlockAsync>d__.leftCount = leftCount;
			<_WriteAttributeTextBlockAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<_WriteAttributeTextBlockAsync>d__.<>1__state = -1;
			<_WriteAttributeTextBlockAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<_WriteAttributeTextBlockAsync>d__118>(ref <_WriteAttributeTextBlockAsync>d__);
			return <_WriteAttributeTextBlockAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x00047AE4 File Offset: 0x00045CE4
		[SecuritySafeCritical]
		protected unsafe int WriteElementTextBlockNoFlush(char* pSrc, char* pSrcEnd, out bool needWriteNewLine)
		{
			needWriteNewLine = false;
			char* ptr = pSrc;
			byte[] array;
			byte* ptr2;
			if ((array = this.bufBytes) == null || array.Length == 0)
			{
				ptr2 = null;
			}
			else
			{
				ptr2 = &array[0];
			}
			byte* ptr3 = ptr2 + this.bufPos;
			int num = 0;
			for (;;)
			{
				byte* ptr4 = ptr3 + (long)(pSrcEnd - pSrc);
				if (ptr4 != ptr2 + this.bufLen)
				{
					ptr4 = ptr2 + this.bufLen;
				}
				while (ptr3 < ptr4 && (this.xmlCharType.charProperties[num = (int)(*pSrc)] & 128) != 0 && num <= 127)
				{
					*ptr3 = (byte)num;
					ptr3++;
					pSrc++;
				}
				if (pSrc >= pSrcEnd)
				{
					goto IL_209;
				}
				if (ptr3 >= ptr4)
				{
					break;
				}
				if (num <= 38)
				{
					switch (num)
					{
					case 9:
						goto IL_114;
					case 10:
						if (this.newLineHandling == NewLineHandling.Replace)
						{
							goto Block_14;
						}
						*ptr3 = (byte)num;
						ptr3++;
						goto IL_1FF;
					case 11:
					case 12:
						break;
					case 13:
						switch (this.newLineHandling)
						{
						case NewLineHandling.Replace:
							goto IL_170;
						case NewLineHandling.Entitize:
							ptr3 = XmlUtf8RawTextWriter.CarriageReturnEntity(ptr3);
							goto IL_1FF;
						case NewLineHandling.None:
							*ptr3 = (byte)num;
							ptr3++;
							goto IL_1FF;
						default:
							goto IL_1FF;
						}
						break;
					default:
						if (num == 34)
						{
							goto IL_114;
						}
						if (num == 38)
						{
							ptr3 = XmlUtf8RawTextWriter.AmpEntity(ptr3);
							goto IL_1FF;
						}
						break;
					}
				}
				else
				{
					if (num == 39)
					{
						goto IL_114;
					}
					if (num == 60)
					{
						ptr3 = XmlUtf8RawTextWriter.LtEntity(ptr3);
						goto IL_1FF;
					}
					if (num == 62)
					{
						ptr3 = XmlUtf8RawTextWriter.GtEntity(ptr3);
						goto IL_1FF;
					}
				}
				if (XmlCharType.IsSurrogate(num))
				{
					ptr3 = XmlUtf8RawTextWriter.EncodeSurrogate(pSrc, pSrcEnd, ptr3);
					pSrc += 2;
					continue;
				}
				if (num <= 127 || num >= 65534)
				{
					ptr3 = this.InvalidXmlChar(num, ptr3, true);
					pSrc++;
					continue;
				}
				ptr3 = XmlUtf8RawTextWriter.EncodeMultibyteUTF8(num, ptr3);
				pSrc++;
				continue;
				IL_1FF:
				pSrc++;
				continue;
				IL_114:
				*ptr3 = (byte)num;
				ptr3++;
				goto IL_1FF;
			}
			this.bufPos = (int)((long)(ptr3 - ptr2));
			return (int)((long)(pSrc - ptr));
			Block_14:
			this.bufPos = (int)((long)(ptr3 - ptr2));
			needWriteNewLine = true;
			return (int)((long)(pSrc - ptr));
			IL_170:
			if (pSrc[1] == '\n')
			{
				pSrc++;
			}
			this.bufPos = (int)((long)(ptr3 - ptr2));
			needWriteNewLine = true;
			return (int)((long)(pSrc - ptr));
			IL_209:
			this.bufPos = (int)((long)(ptr3 - ptr2));
			this.textPos = this.bufPos;
			this.contentPos = 0;
			array = null;
			return -1;
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x00047D20 File Offset: 0x00045F20
		[SecuritySafeCritical]
		protected unsafe int WriteElementTextBlockNoFlush(char[] chars, int index, int count, out bool needWriteNewLine)
		{
			needWriteNewLine = false;
			if (count == 0)
			{
				this.contentPos = 0;
				return -1;
			}
			fixed (char* ptr = &chars[index])
			{
				char* ptr2 = ptr;
				char* pSrcEnd = ptr2 + count;
				return this.WriteElementTextBlockNoFlush(ptr2, pSrcEnd, out needWriteNewLine);
			}
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x00047D5C File Offset: 0x00045F5C
		[SecuritySafeCritical]
		protected unsafe int WriteElementTextBlockNoFlush(string text, int index, int count, out bool needWriteNewLine)
		{
			needWriteNewLine = false;
			if (count == 0)
			{
				this.contentPos = 0;
				return -1;
			}
			char* ptr = text;
			if (ptr != null)
			{
				ptr += RuntimeHelpers.OffsetToStringData / 2;
			}
			char* ptr2 = ptr + index;
			char* pSrcEnd = ptr2 + count;
			return this.WriteElementTextBlockNoFlush(ptr2, pSrcEnd, out needWriteNewLine);
		}

		// Token: 0x06000AD1 RID: 2769 RVA: 0x00047DA4 File Offset: 0x00045FA4
		protected Task WriteElementTextBlockAsync(char[] chars, int index, int count)
		{
			XmlUtf8RawTextWriter.<WriteElementTextBlockAsync>d__122 <WriteElementTextBlockAsync>d__;
			<WriteElementTextBlockAsync>d__.<>4__this = this;
			<WriteElementTextBlockAsync>d__.chars = chars;
			<WriteElementTextBlockAsync>d__.index = index;
			<WriteElementTextBlockAsync>d__.count = count;
			<WriteElementTextBlockAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteElementTextBlockAsync>d__.<>1__state = -1;
			<WriteElementTextBlockAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<WriteElementTextBlockAsync>d__122>(ref <WriteElementTextBlockAsync>d__);
			return <WriteElementTextBlockAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x00047E00 File Offset: 0x00046000
		protected Task WriteElementTextBlockAsync(string text)
		{
			int num = 0;
			int num2 = text.Length;
			bool flag = false;
			int num3 = this.WriteElementTextBlockNoFlush(text, num, num2, out flag);
			num += num3;
			num2 -= num3;
			if (flag)
			{
				return this._WriteElementTextBlockAsync(true, text, num, num2);
			}
			if (num3 >= 0)
			{
				return this._WriteElementTextBlockAsync(false, text, num, num2);
			}
			return AsyncHelper.DoneTask;
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x00047E50 File Offset: 0x00046050
		private Task _WriteElementTextBlockAsync(bool newLine, string text, int curIndex, int leftCount)
		{
			XmlUtf8RawTextWriter.<_WriteElementTextBlockAsync>d__124 <_WriteElementTextBlockAsync>d__;
			<_WriteElementTextBlockAsync>d__.<>4__this = this;
			<_WriteElementTextBlockAsync>d__.newLine = newLine;
			<_WriteElementTextBlockAsync>d__.text = text;
			<_WriteElementTextBlockAsync>d__.curIndex = curIndex;
			<_WriteElementTextBlockAsync>d__.leftCount = leftCount;
			<_WriteElementTextBlockAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<_WriteElementTextBlockAsync>d__.<>1__state = -1;
			<_WriteElementTextBlockAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<_WriteElementTextBlockAsync>d__124>(ref <_WriteElementTextBlockAsync>d__);
			return <_WriteElementTextBlockAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x00047EB4 File Offset: 0x000460B4
		[SecuritySafeCritical]
		protected unsafe int RawTextNoFlush(char* pSrcBegin, char* pSrcEnd)
		{
			byte[] array;
			byte* ptr;
			if ((array = this.bufBytes) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			byte* ptr2 = ptr + this.bufPos;
			char* ptr3 = pSrcBegin;
			int num = 0;
			for (;;)
			{
				byte* ptr4 = ptr2 + (long)(pSrcEnd - ptr3);
				if (ptr4 != ptr + this.bufLen)
				{
					ptr4 = ptr + this.bufLen;
				}
				while (ptr2 < ptr4 && (num = (int)(*ptr3)) <= 127)
				{
					ptr3++;
					*ptr2 = (byte)num;
					ptr2++;
				}
				if (ptr3 >= pSrcEnd)
				{
					goto IL_E7;
				}
				if (ptr2 >= ptr4)
				{
					break;
				}
				if (XmlCharType.IsSurrogate(num))
				{
					ptr2 = XmlUtf8RawTextWriter.EncodeSurrogate(ptr3, pSrcEnd, ptr2);
					ptr3 += 2;
				}
				else if (num <= 127 || num >= 65534)
				{
					ptr2 = this.InvalidXmlChar(num, ptr2, false);
					ptr3++;
				}
				else
				{
					ptr2 = XmlUtf8RawTextWriter.EncodeMultibyteUTF8(num, ptr2);
					ptr3++;
				}
			}
			this.bufPos = (int)((long)(ptr2 - ptr));
			return (int)((long)(ptr3 - pSrcBegin));
			IL_E7:
			this.bufPos = (int)((long)(ptr2 - ptr));
			array = null;
			return -1;
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x00047FB8 File Offset: 0x000461B8
		[SecuritySafeCritical]
		protected unsafe int RawTextNoFlush(string text, int index, int count)
		{
			if (count == 0)
			{
				return -1;
			}
			char* ptr = text;
			if (ptr != null)
			{
				ptr += RuntimeHelpers.OffsetToStringData / 2;
			}
			char* ptr2 = ptr + index;
			char* pSrcEnd = ptr2 + count;
			return this.RawTextNoFlush(ptr2, pSrcEnd);
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x00047FF0 File Offset: 0x000461F0
		protected Task RawTextAsync(string text)
		{
			int num = 0;
			int num2 = text.Length;
			int num3 = this.RawTextNoFlush(text, num, num2);
			num += num3;
			num2 -= num3;
			if (num3 >= 0)
			{
				return this._RawTextAsync(text, num, num2);
			}
			return AsyncHelper.DoneTask;
		}

		// Token: 0x06000AD7 RID: 2775 RVA: 0x00048030 File Offset: 0x00046230
		private Task _RawTextAsync(string text, int curIndex, int leftCount)
		{
			XmlUtf8RawTextWriter.<_RawTextAsync>d__128 <_RawTextAsync>d__;
			<_RawTextAsync>d__.<>4__this = this;
			<_RawTextAsync>d__.text = text;
			<_RawTextAsync>d__.curIndex = curIndex;
			<_RawTextAsync>d__.leftCount = leftCount;
			<_RawTextAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<_RawTextAsync>d__.<>1__state = -1;
			<_RawTextAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<_RawTextAsync>d__128>(ref <_RawTextAsync>d__);
			return <_RawTextAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x0004808C File Offset: 0x0004628C
		[SecuritySafeCritical]
		protected unsafe int WriteRawWithCharCheckingNoFlush(char* pSrcBegin, char* pSrcEnd, out bool needWriteNewLine)
		{
			needWriteNewLine = false;
			byte[] array;
			byte* ptr;
			if ((array = this.bufBytes) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			char* ptr2 = pSrcBegin;
			byte* ptr3 = ptr + this.bufPos;
			int num = 0;
			for (;;)
			{
				byte* ptr4 = ptr3 + (long)(pSrcEnd - ptr2);
				if (ptr4 != ptr + this.bufLen)
				{
					ptr4 = ptr + this.bufLen;
				}
				while (ptr3 < ptr4 && (this.xmlCharType.charProperties[num = (int)(*ptr2)] & 64) != 0 && num <= 127)
				{
					*ptr3 = (byte)num;
					ptr3++;
					ptr2++;
				}
				if (ptr2 >= pSrcEnd)
				{
					goto IL_1C5;
				}
				if (ptr3 >= ptr4)
				{
					break;
				}
				if (num <= 38)
				{
					switch (num)
					{
					case 9:
						goto IL_E5;
					case 10:
						if (this.newLineHandling == NewLineHandling.Replace)
						{
							goto Block_13;
						}
						*ptr3 = (byte)num;
						ptr3++;
						goto IL_1BC;
					case 11:
					case 12:
						break;
					case 13:
						if (this.newLineHandling == NewLineHandling.Replace)
						{
							goto Block_11;
						}
						*ptr3 = (byte)num;
						ptr3++;
						goto IL_1BC;
					default:
						if (num == 38)
						{
							goto IL_E5;
						}
						break;
					}
				}
				else if (num == 60 || num == 93)
				{
					goto IL_E5;
				}
				if (XmlCharType.IsSurrogate(num))
				{
					ptr3 = XmlUtf8RawTextWriter.EncodeSurrogate(ptr2, pSrcEnd, ptr3);
					ptr2 += 2;
					continue;
				}
				if (num <= 127 || num >= 65534)
				{
					ptr3 = this.InvalidXmlChar(num, ptr3, false);
					ptr2++;
					continue;
				}
				ptr3 = XmlUtf8RawTextWriter.EncodeMultibyteUTF8(num, ptr3);
				ptr2++;
				continue;
				IL_1BC:
				ptr2++;
				continue;
				IL_E5:
				*ptr3 = (byte)num;
				ptr3++;
				goto IL_1BC;
			}
			this.bufPos = (int)((long)(ptr3 - ptr));
			return (int)((long)(ptr2 - pSrcBegin));
			Block_11:
			if (ptr2[1] == '\n')
			{
				ptr2++;
			}
			this.bufPos = (int)((long)(ptr3 - ptr));
			needWriteNewLine = true;
			return (int)((long)(ptr2 - pSrcBegin));
			Block_13:
			this.bufPos = (int)((long)(ptr3 - ptr));
			needWriteNewLine = true;
			return (int)((long)(ptr2 - pSrcBegin));
			IL_1C5:
			this.bufPos = (int)((long)(ptr3 - ptr));
			array = null;
			return -1;
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x00048270 File Offset: 0x00046470
		[SecuritySafeCritical]
		protected unsafe int WriteRawWithCharCheckingNoFlush(char[] chars, int index, int count, out bool needWriteNewLine)
		{
			needWriteNewLine = false;
			if (count == 0)
			{
				return -1;
			}
			fixed (char* ptr = &chars[index])
			{
				char* ptr2 = ptr;
				char* pSrcEnd = ptr2 + count;
				return this.WriteRawWithCharCheckingNoFlush(ptr2, pSrcEnd, out needWriteNewLine);
			}
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x000482A4 File Offset: 0x000464A4
		[SecuritySafeCritical]
		protected unsafe int WriteRawWithCharCheckingNoFlush(string text, int index, int count, out bool needWriteNewLine)
		{
			needWriteNewLine = false;
			if (count == 0)
			{
				return -1;
			}
			char* ptr = text;
			if (ptr != null)
			{
				ptr += RuntimeHelpers.OffsetToStringData / 2;
			}
			char* ptr2 = ptr + index;
			char* pSrcEnd = ptr2 + count;
			return this.WriteRawWithCharCheckingNoFlush(ptr2, pSrcEnd, out needWriteNewLine);
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x000482E4 File Offset: 0x000464E4
		protected Task WriteRawWithCharCheckingAsync(char[] chars, int index, int count)
		{
			XmlUtf8RawTextWriter.<WriteRawWithCharCheckingAsync>d__132 <WriteRawWithCharCheckingAsync>d__;
			<WriteRawWithCharCheckingAsync>d__.<>4__this = this;
			<WriteRawWithCharCheckingAsync>d__.chars = chars;
			<WriteRawWithCharCheckingAsync>d__.index = index;
			<WriteRawWithCharCheckingAsync>d__.count = count;
			<WriteRawWithCharCheckingAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteRawWithCharCheckingAsync>d__.<>1__state = -1;
			<WriteRawWithCharCheckingAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<WriteRawWithCharCheckingAsync>d__132>(ref <WriteRawWithCharCheckingAsync>d__);
			return <WriteRawWithCharCheckingAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000ADC RID: 2780 RVA: 0x00048340 File Offset: 0x00046540
		protected Task WriteRawWithCharCheckingAsync(string text)
		{
			XmlUtf8RawTextWriter.<WriteRawWithCharCheckingAsync>d__133 <WriteRawWithCharCheckingAsync>d__;
			<WriteRawWithCharCheckingAsync>d__.<>4__this = this;
			<WriteRawWithCharCheckingAsync>d__.text = text;
			<WriteRawWithCharCheckingAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteRawWithCharCheckingAsync>d__.<>1__state = -1;
			<WriteRawWithCharCheckingAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<WriteRawWithCharCheckingAsync>d__133>(ref <WriteRawWithCharCheckingAsync>d__);
			return <WriteRawWithCharCheckingAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x0004838C File Offset: 0x0004658C
		[SecuritySafeCritical]
		protected unsafe int WriteCommentOrPiNoFlush(string text, int index, int count, int stopChar, out bool needWriteNewLine)
		{
			needWriteNewLine = false;
			if (count == 0)
			{
				return -1;
			}
			char* ptr = text;
			if (ptr != null)
			{
				ptr += RuntimeHelpers.OffsetToStringData / 2;
			}
			char* ptr2 = ptr + index;
			byte[] array;
			byte* ptr3;
			if ((array = this.bufBytes) == null || array.Length == 0)
			{
				ptr3 = null;
			}
			else
			{
				ptr3 = &array[0];
			}
			char* ptr4 = ptr2;
			char* ptr5 = ptr4;
			char* ptr6 = ptr2 + count;
			byte* ptr7 = ptr3 + this.bufPos;
			int num = 0;
			for (;;)
			{
				byte* ptr8 = ptr7 + (long)(ptr6 - ptr4);
				if (ptr8 != ptr3 + this.bufLen)
				{
					ptr8 = ptr3 + this.bufLen;
				}
				while (ptr7 < ptr8 && (this.xmlCharType.charProperties[num = (int)(*ptr4)] & 64) != 0 && num != stopChar && num <= 127)
				{
					*ptr7 = (byte)num;
					ptr7++;
					ptr4++;
				}
				if (ptr4 >= ptr6)
				{
					goto IL_2A4;
				}
				if (ptr7 >= ptr8)
				{
					break;
				}
				if (num <= 45)
				{
					switch (num)
					{
					case 9:
						goto IL_22A;
					case 10:
						if (this.newLineHandling == NewLineHandling.Replace)
						{
							goto Block_24;
						}
						*ptr7 = (byte)num;
						ptr7++;
						goto IL_299;
					case 11:
					case 12:
						break;
					case 13:
						if (this.newLineHandling == NewLineHandling.Replace)
						{
							goto Block_22;
						}
						*ptr7 = (byte)num;
						ptr7++;
						goto IL_299;
					default:
						if (num == 38)
						{
							goto IL_22A;
						}
						if (num == 45)
						{
							*ptr7 = 45;
							ptr7++;
							if (num == stopChar && (ptr4 + 1 == ptr6 || ptr4[1] == '-'))
							{
								*ptr7 = 32;
								ptr7++;
								goto IL_299;
							}
							goto IL_299;
						}
						break;
					}
				}
				else
				{
					if (num == 60)
					{
						goto IL_22A;
					}
					if (num != 63)
					{
						if (num == 93)
						{
							*ptr7 = 93;
							ptr7++;
							goto IL_299;
						}
					}
					else
					{
						*ptr7 = 63;
						ptr7++;
						if (num == stopChar && ptr4 + 1 < ptr6 && ptr4[1] == '>')
						{
							*ptr7 = 32;
							ptr7++;
							goto IL_299;
						}
						goto IL_299;
					}
				}
				if (XmlCharType.IsSurrogate(num))
				{
					ptr7 = XmlUtf8RawTextWriter.EncodeSurrogate(ptr4, ptr6, ptr7);
					ptr4 += 2;
					continue;
				}
				if (num <= 127 || num >= 65534)
				{
					ptr7 = this.InvalidXmlChar(num, ptr7, false);
					ptr4++;
					continue;
				}
				ptr7 = XmlUtf8RawTextWriter.EncodeMultibyteUTF8(num, ptr7);
				ptr4++;
				continue;
				IL_299:
				ptr4++;
				continue;
				IL_22A:
				*ptr7 = (byte)num;
				ptr7++;
				goto IL_299;
			}
			this.bufPos = (int)((long)(ptr7 - ptr3));
			return (int)((long)(ptr4 - ptr5));
			Block_22:
			if (ptr4[1] == '\n')
			{
				ptr4++;
			}
			this.bufPos = (int)((long)(ptr7 - ptr3));
			needWriteNewLine = true;
			return (int)((long)(ptr4 - ptr5));
			Block_24:
			this.bufPos = (int)((long)(ptr7 - ptr3));
			needWriteNewLine = true;
			return (int)((long)(ptr4 - ptr5));
			IL_2A4:
			this.bufPos = (int)((long)(ptr7 - ptr3));
			array = null;
			return -1;
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x00048650 File Offset: 0x00046850
		protected Task WriteCommentOrPiAsync(string text, int stopChar)
		{
			XmlUtf8RawTextWriter.<WriteCommentOrPiAsync>d__135 <WriteCommentOrPiAsync>d__;
			<WriteCommentOrPiAsync>d__.<>4__this = this;
			<WriteCommentOrPiAsync>d__.text = text;
			<WriteCommentOrPiAsync>d__.stopChar = stopChar;
			<WriteCommentOrPiAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteCommentOrPiAsync>d__.<>1__state = -1;
			<WriteCommentOrPiAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<WriteCommentOrPiAsync>d__135>(ref <WriteCommentOrPiAsync>d__);
			return <WriteCommentOrPiAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x000486A4 File Offset: 0x000468A4
		[SecuritySafeCritical]
		protected unsafe int WriteCDataSectionNoFlush(string text, int index, int count, out bool needWriteNewLine)
		{
			needWriteNewLine = false;
			if (count == 0)
			{
				return -1;
			}
			char* ptr = text;
			if (ptr != null)
			{
				ptr += RuntimeHelpers.OffsetToStringData / 2;
			}
			char* ptr2 = ptr + index;
			byte[] array;
			byte* ptr3;
			if ((array = this.bufBytes) == null || array.Length == 0)
			{
				ptr3 = null;
			}
			else
			{
				ptr3 = &array[0];
			}
			char* ptr4 = ptr2;
			char* ptr5 = ptr2 + count;
			char* ptr6 = ptr4;
			byte* ptr7 = ptr3 + this.bufPos;
			int num = 0;
			for (;;)
			{
				byte* ptr8 = ptr7 + (long)(ptr5 - ptr4);
				if (ptr8 != ptr3 + this.bufLen)
				{
					ptr8 = ptr3 + this.bufLen;
				}
				while (ptr7 < ptr8 && (this.xmlCharType.charProperties[num = (int)(*ptr4)] & 128) != 0 && num != 93 && num <= 127)
				{
					*ptr7 = (byte)num;
					ptr7++;
					ptr4++;
				}
				if (ptr4 >= ptr5)
				{
					goto IL_285;
				}
				if (ptr7 >= ptr8)
				{
					break;
				}
				if (num <= 39)
				{
					switch (num)
					{
					case 9:
						goto IL_20B;
					case 10:
						if (this.newLineHandling == NewLineHandling.Replace)
						{
							goto Block_22;
						}
						*ptr7 = (byte)num;
						ptr7++;
						goto IL_27A;
					case 11:
					case 12:
						break;
					case 13:
						if (this.newLineHandling == NewLineHandling.Replace)
						{
							goto Block_20;
						}
						*ptr7 = (byte)num;
						ptr7++;
						goto IL_27A;
					default:
						if (num == 34 || num - 38 <= 1)
						{
							goto IL_20B;
						}
						break;
					}
				}
				else
				{
					if (num == 60)
					{
						goto IL_20B;
					}
					if (num == 62)
					{
						if (this.hadDoubleBracket && ptr7[-1] == 93)
						{
							ptr7 = XmlUtf8RawTextWriter.RawEndCData(ptr7);
							ptr7 = XmlUtf8RawTextWriter.RawStartCData(ptr7);
						}
						*ptr7 = 62;
						ptr7++;
						goto IL_27A;
					}
					if (num == 93)
					{
						if (ptr7[-1] == 93)
						{
							this.hadDoubleBracket = true;
						}
						else
						{
							this.hadDoubleBracket = false;
						}
						*ptr7 = 93;
						ptr7++;
						goto IL_27A;
					}
				}
				if (XmlCharType.IsSurrogate(num))
				{
					ptr7 = XmlUtf8RawTextWriter.EncodeSurrogate(ptr4, ptr5, ptr7);
					ptr4 += 2;
					continue;
				}
				if (num <= 127 || num >= 65534)
				{
					ptr7 = this.InvalidXmlChar(num, ptr7, false);
					ptr4++;
					continue;
				}
				ptr7 = XmlUtf8RawTextWriter.EncodeMultibyteUTF8(num, ptr7);
				ptr4++;
				continue;
				IL_27A:
				ptr4++;
				continue;
				IL_20B:
				*ptr7 = (byte)num;
				ptr7++;
				goto IL_27A;
			}
			this.bufPos = (int)((long)(ptr7 - ptr3));
			return (int)((long)(ptr4 - ptr6));
			Block_20:
			if (ptr4[1] == '\n')
			{
				ptr4++;
			}
			this.bufPos = (int)((long)(ptr7 - ptr3));
			needWriteNewLine = true;
			return (int)((long)(ptr4 - ptr6));
			Block_22:
			this.bufPos = (int)((long)(ptr7 - ptr3));
			needWriteNewLine = true;
			return (int)((long)(ptr4 - ptr6));
			IL_285:
			this.bufPos = (int)((long)(ptr7 - ptr3));
			array = null;
			return -1;
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x00048948 File Offset: 0x00046B48
		protected Task WriteCDataSectionAsync(string text)
		{
			XmlUtf8RawTextWriter.<WriteCDataSectionAsync>d__137 <WriteCDataSectionAsync>d__;
			<WriteCDataSectionAsync>d__.<>4__this = this;
			<WriteCDataSectionAsync>d__.text = text;
			<WriteCDataSectionAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<WriteCDataSectionAsync>d__.<>1__state = -1;
			<WriteCDataSectionAsync>d__.<>t__builder.Start<XmlUtf8RawTextWriter.<WriteCDataSectionAsync>d__137>(ref <WriteCDataSectionAsync>d__);
			return <WriteCDataSectionAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04000C2C RID: 3116
		private readonly bool useAsync;

		// Token: 0x04000C2D RID: 3117
		protected byte[] bufBytes;

		// Token: 0x04000C2E RID: 3118
		protected Stream stream;

		// Token: 0x04000C2F RID: 3119
		protected Encoding encoding;

		// Token: 0x04000C30 RID: 3120
		protected XmlCharType xmlCharType = XmlCharType.Instance;

		// Token: 0x04000C31 RID: 3121
		protected int bufPos = 1;

		// Token: 0x04000C32 RID: 3122
		protected int textPos = 1;

		// Token: 0x04000C33 RID: 3123
		protected int contentPos;

		// Token: 0x04000C34 RID: 3124
		protected int cdataPos;

		// Token: 0x04000C35 RID: 3125
		protected int attrEndPos;

		// Token: 0x04000C36 RID: 3126
		protected int bufLen = 6144;

		// Token: 0x04000C37 RID: 3127
		protected bool writeToNull;

		// Token: 0x04000C38 RID: 3128
		protected bool hadDoubleBracket;

		// Token: 0x04000C39 RID: 3129
		protected bool inAttributeValue;

		// Token: 0x04000C3A RID: 3130
		protected NewLineHandling newLineHandling;

		// Token: 0x04000C3B RID: 3131
		protected bool closeOutput;

		// Token: 0x04000C3C RID: 3132
		protected bool omitXmlDeclaration;

		// Token: 0x04000C3D RID: 3133
		protected string newLineChars;

		// Token: 0x04000C3E RID: 3134
		protected bool checkCharacters;

		// Token: 0x04000C3F RID: 3135
		protected XmlStandalone standalone;

		// Token: 0x04000C40 RID: 3136
		protected XmlOutputMethod outputMethod;

		// Token: 0x04000C41 RID: 3137
		protected bool autoXmlDeclaration;

		// Token: 0x04000C42 RID: 3138
		protected bool mergeCDataSections;

		// Token: 0x04000C43 RID: 3139
		private const int BUFSIZE = 6144;

		// Token: 0x04000C44 RID: 3140
		private const int ASYNCBUFSIZE = 65536;

		// Token: 0x04000C45 RID: 3141
		private const int OVERFLOW = 32;

		// Token: 0x04000C46 RID: 3142
		private const int INIT_MARKS_COUNT = 64;
	}
}
