using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UnityWebSocketSharp
{
	// Token: 0x02000017 RID: 23
	internal class WebSocketFrame : IEnumerable<byte>, IEnumerable
	{
		// Token: 0x0600015E RID: 350 RVA: 0x00008137 File Offset: 0x00006337
		private WebSocketFrame()
		{
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0000813F File Offset: 0x0000633F
		internal WebSocketFrame(Fin fin, Opcode opcode, byte[] data, bool compressed, bool mask) : this(fin, opcode, new PayloadData(data), compressed, mask)
		{
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00008154 File Offset: 0x00006354
		internal WebSocketFrame(Fin fin, Opcode opcode, PayloadData payloadData, bool compressed, bool mask)
		{
			this._fin = fin;
			this._opcode = opcode;
			this._rsv1 = (compressed ? Rsv.On : Rsv.Off);
			this._rsv2 = Rsv.Off;
			this._rsv3 = Rsv.Off;
			ulong length = payloadData.Length;
			if (length < 126UL)
			{
				this._payloadLength = (byte)length;
				this._extPayloadLength = WebSocket.EmptyBytes;
			}
			else if (length < 65536UL)
			{
				this._payloadLength = 126;
				this._extPayloadLength = ((ushort)length).ToByteArray(ByteOrder.Big);
			}
			else
			{
				this._payloadLength = 127;
				this._extPayloadLength = length.ToByteArray(ByteOrder.Big);
			}
			if (mask)
			{
				this._mask = Mask.On;
				this._maskingKey = WebSocketFrame.createMaskingKey();
				payloadData.Mask(this._maskingKey);
			}
			else
			{
				this._mask = Mask.Off;
				this._maskingKey = WebSocket.EmptyBytes;
			}
			this._payloadData = payloadData;
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000161 RID: 353 RVA: 0x00008226 File Offset: 0x00006426
		internal ulong ExactPayloadLength
		{
			get
			{
				if (this._payloadLength < 126)
				{
					return (ulong)this._payloadLength;
				}
				if (this._payloadLength != 126)
				{
					return this._extPayloadLength.ToUInt64(ByteOrder.Big);
				}
				return (ulong)this._extPayloadLength.ToUInt16(ByteOrder.Big);
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000162 RID: 354 RVA: 0x0000825E File Offset: 0x0000645E
		internal int ExtendedPayloadLengthWidth
		{
			get
			{
				if (this._payloadLength < 126)
				{
					return 0;
				}
				if (this._payloadLength != 126)
				{
					return 8;
				}
				return 2;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000163 RID: 355 RVA: 0x00008279 File Offset: 0x00006479
		public byte[] ExtendedPayloadLength
		{
			get
			{
				return this._extPayloadLength;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000164 RID: 356 RVA: 0x00008281 File Offset: 0x00006481
		public Fin Fin
		{
			get
			{
				return this._fin;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00008289 File Offset: 0x00006489
		public bool IsBinary
		{
			get
			{
				return this._opcode == Opcode.Binary;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000166 RID: 358 RVA: 0x00008294 File Offset: 0x00006494
		public bool IsClose
		{
			get
			{
				return this._opcode == Opcode.Close;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000167 RID: 359 RVA: 0x0000829F File Offset: 0x0000649F
		public bool IsCompressed
		{
			get
			{
				return this._rsv1 == Rsv.On;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000168 RID: 360 RVA: 0x000082AA File Offset: 0x000064AA
		public bool IsContinuation
		{
			get
			{
				return this._opcode == Opcode.Cont;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000169 RID: 361 RVA: 0x000082B5 File Offset: 0x000064B5
		public bool IsControl
		{
			get
			{
				return this._opcode >= Opcode.Close;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600016A RID: 362 RVA: 0x000082C3 File Offset: 0x000064C3
		public bool IsData
		{
			get
			{
				return this._opcode == Opcode.Text || this._opcode == Opcode.Binary;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600016B RID: 363 RVA: 0x000082D9 File Offset: 0x000064D9
		public bool IsFinal
		{
			get
			{
				return this._fin == Fin.Final;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600016C RID: 364 RVA: 0x000082E4 File Offset: 0x000064E4
		public bool IsFragment
		{
			get
			{
				return this._fin == Fin.More || this._opcode == Opcode.Cont;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600016D RID: 365 RVA: 0x000082F9 File Offset: 0x000064F9
		public bool IsMasked
		{
			get
			{
				return this._mask == Mask.On;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600016E RID: 366 RVA: 0x00008304 File Offset: 0x00006504
		public bool IsPing
		{
			get
			{
				return this._opcode == Opcode.Ping;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600016F RID: 367 RVA: 0x00008310 File Offset: 0x00006510
		public bool IsPong
		{
			get
			{
				return this._opcode == Opcode.Pong;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000170 RID: 368 RVA: 0x0000831C File Offset: 0x0000651C
		public bool IsText
		{
			get
			{
				return this._opcode == Opcode.Text;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000171 RID: 369 RVA: 0x00008327 File Offset: 0x00006527
		public ulong Length
		{
			get
			{
				return (ulong)((long)(WebSocketFrame._defaultHeaderLength + this._extPayloadLength.Length + this._maskingKey.Length) + (long)this._payloadData.Length);
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000172 RID: 370 RVA: 0x0000834D File Offset: 0x0000654D
		public Mask Mask
		{
			get
			{
				return this._mask;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000173 RID: 371 RVA: 0x00008355 File Offset: 0x00006555
		public byte[] MaskingKey
		{
			get
			{
				return this._maskingKey;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000174 RID: 372 RVA: 0x0000835D File Offset: 0x0000655D
		public Opcode Opcode
		{
			get
			{
				return this._opcode;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000175 RID: 373 RVA: 0x00008365 File Offset: 0x00006565
		public PayloadData PayloadData
		{
			get
			{
				return this._payloadData;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000176 RID: 374 RVA: 0x0000836D File Offset: 0x0000656D
		public byte PayloadLength
		{
			get
			{
				return this._payloadLength;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000177 RID: 375 RVA: 0x00008375 File Offset: 0x00006575
		public Rsv Rsv1
		{
			get
			{
				return this._rsv1;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000178 RID: 376 RVA: 0x0000837D File Offset: 0x0000657D
		public Rsv Rsv2
		{
			get
			{
				return this._rsv2;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000179 RID: 377 RVA: 0x00008385 File Offset: 0x00006585
		public Rsv Rsv3
		{
			get
			{
				return this._rsv3;
			}
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00008390 File Offset: 0x00006590
		private static byte[] createMaskingKey()
		{
			byte[] array = new byte[WebSocketFrame._defaultMaskingKeyLength];
			WebSocket.RandomNumber.GetBytes(array);
			return array;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x000083B4 File Offset: 0x000065B4
		private static WebSocketFrame processHeader(byte[] header)
		{
			if (header.Length != WebSocketFrame._defaultHeaderLength)
			{
				throw new WebSocketException("The header part of a frame could not be read.");
			}
			Fin fin = ((header[0] & 128) == 128) ? Fin.Final : Fin.More;
			Rsv rsv = ((header[0] & 64) == 64) ? Rsv.On : Rsv.Off;
			Rsv rsv2 = ((header[0] & 32) == 32) ? Rsv.On : Rsv.Off;
			Rsv rsv3 = ((header[0] & 16) == 16) ? Rsv.On : Rsv.Off;
			byte opcode = header[0] & 15;
			Mask mask = ((header[1] & 128) == 128) ? Mask.On : Mask.Off;
			byte payloadLength = header[1] & 127;
			if (!opcode.IsSupportedOpcode())
			{
				string message = "The opcode of a frame is not supported.";
				throw new WebSocketException(CloseStatusCode.UnsupportedData, message);
			}
			return new WebSocketFrame
			{
				_fin = fin,
				_rsv1 = rsv,
				_rsv2 = rsv2,
				_rsv3 = rsv3,
				_opcode = (Opcode)opcode,
				_mask = mask,
				_payloadLength = payloadLength
			};
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00008498 File Offset: 0x00006698
		private static WebSocketFrame readExtendedPayloadLength(Stream stream, WebSocketFrame frame)
		{
			int extendedPayloadLengthWidth = frame.ExtendedPayloadLengthWidth;
			if (extendedPayloadLengthWidth == 0)
			{
				frame._extPayloadLength = WebSocket.EmptyBytes;
				return frame;
			}
			byte[] array = stream.ReadBytes(extendedPayloadLengthWidth);
			if (array.Length != extendedPayloadLengthWidth)
			{
				throw new WebSocketException("The extended payload length of a frame could not be read.");
			}
			frame._extPayloadLength = array;
			return frame;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x000084E0 File Offset: 0x000066E0
		private static void readExtendedPayloadLengthAsync(Stream stream, WebSocketFrame frame, Action<WebSocketFrame> completed, Action<Exception> error)
		{
			int len = frame.ExtendedPayloadLengthWidth;
			if (len == 0)
			{
				frame._extPayloadLength = WebSocket.EmptyBytes;
				completed(frame);
				return;
			}
			stream.ReadBytesAsync(len, delegate(byte[] bytes)
			{
				if (bytes.Length != len)
				{
					throw new WebSocketException("The extended payload length of a frame could not be read.");
				}
				frame._extPayloadLength = bytes;
				completed(frame);
			}, error);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00008555 File Offset: 0x00006755
		private static WebSocketFrame readHeader(Stream stream)
		{
			return WebSocketFrame.processHeader(stream.ReadBytes(WebSocketFrame._defaultHeaderLength));
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00008568 File Offset: 0x00006768
		private static void readHeaderAsync(Stream stream, Action<WebSocketFrame> completed, Action<Exception> error)
		{
			stream.ReadBytesAsync(WebSocketFrame._defaultHeaderLength, delegate(byte[] bytes)
			{
				WebSocketFrame obj = WebSocketFrame.processHeader(bytes);
				completed(obj);
			}, error);
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000859C File Offset: 0x0000679C
		private static WebSocketFrame readMaskingKey(Stream stream, WebSocketFrame frame)
		{
			if (!frame.IsMasked)
			{
				frame._maskingKey = WebSocket.EmptyBytes;
				return frame;
			}
			byte[] array = stream.ReadBytes(WebSocketFrame._defaultMaskingKeyLength);
			if (array.Length != WebSocketFrame._defaultMaskingKeyLength)
			{
				throw new WebSocketException("The masking key of a frame could not be read.");
			}
			frame._maskingKey = array;
			return frame;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x000085E8 File Offset: 0x000067E8
		private static void readMaskingKeyAsync(Stream stream, WebSocketFrame frame, Action<WebSocketFrame> completed, Action<Exception> error)
		{
			if (!frame.IsMasked)
			{
				frame._maskingKey = WebSocket.EmptyBytes;
				completed(frame);
				return;
			}
			stream.ReadBytesAsync(WebSocketFrame._defaultMaskingKeyLength, delegate(byte[] bytes)
			{
				if (bytes.Length != WebSocketFrame._defaultMaskingKeyLength)
				{
					throw new WebSocketException("The masking key of a frame could not be read.");
				}
				frame._maskingKey = bytes;
				completed(frame);
			}, error);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00008650 File Offset: 0x00006850
		private static WebSocketFrame readPayloadData(Stream stream, WebSocketFrame frame)
		{
			ulong exactPayloadLength = frame.ExactPayloadLength;
			if (exactPayloadLength > PayloadData.MaxLength)
			{
				string message = "The payload data of a frame is too big.";
				throw new WebSocketException(CloseStatusCode.TooBig, message);
			}
			if (exactPayloadLength == 0UL)
			{
				frame._payloadData = PayloadData.Empty;
				return frame;
			}
			long num = (long)exactPayloadLength;
			byte[] array = (frame._payloadLength > 126) ? stream.ReadBytes(num, 1024) : stream.ReadBytes((int)num);
			if ((long)array.Length != num)
			{
				throw new WebSocketException("The payload data of a frame could not be read.");
			}
			frame._payloadData = new PayloadData(array, num);
			return frame;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x000086D0 File Offset: 0x000068D0
		private static void readPayloadDataAsync(Stream stream, WebSocketFrame frame, Action<WebSocketFrame> completed, Action<Exception> error)
		{
			ulong exactPayloadLength = frame.ExactPayloadLength;
			if (exactPayloadLength > PayloadData.MaxLength)
			{
				string message = "The payload data of a frame is too big.";
				throw new WebSocketException(CloseStatusCode.TooBig, message);
			}
			if (exactPayloadLength == 0UL)
			{
				frame._payloadData = PayloadData.Empty;
				completed(frame);
				return;
			}
			long len = (long)exactPayloadLength;
			Action<byte[]> completed2 = delegate(byte[] bytes)
			{
				if ((long)bytes.Length != len)
				{
					throw new WebSocketException("The payload data of a frame could not be read.");
				}
				frame._payloadData = new PayloadData(bytes, len);
				completed(frame);
			};
			if (frame._payloadLength > 126)
			{
				stream.ReadBytesAsync(len, 1024, completed2, error);
				return;
			}
			stream.ReadBytesAsync((int)len, completed2, error);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00008784 File Offset: 0x00006984
		private string toDumpString()
		{
			ulong length = this.Length;
			long num = (long)(length / 4UL);
			int num2 = (int)(length % 4UL);
			string arg;
			string arg2;
			if (num < 10000L)
			{
				arg = "{0,4}";
				arg2 = "{0,4}";
			}
			else if (num < 65536L)
			{
				arg = "{0,4}";
				arg2 = "{0,4:X}";
			}
			else if (num < 4294967296L)
			{
				arg = "{0,8}";
				arg2 = "{0,8:X}";
			}
			else
			{
				arg = "{0,16}";
				arg2 = "{0,16:X}";
			}
			string format = "{0} 01234567 89ABCDEF 01234567 89ABCDEF\n{0}+--------+--------+--------+--------+\n";
			string format2 = string.Format(format, arg);
			format = "{0}|{{1,8}} {{2,8}} {{3,8}} {{4,8}}|\n";
			string lineFmt = string.Format(format, arg2);
			format = "{0}+--------+--------+--------+--------+";
			string format3 = string.Format(format, arg);
			StringBuilder buff = new StringBuilder(64);
			string arg3;
			string arg4;
			Action<string, string, string, string> action = delegate
			{
				long lineCnt = 0L;
				return delegate(string arg1, string arg2, string arg3, string arg4)
				{
					StringBuilder buff = buff;
					string lineFmt = lineFmt;
					object[] array2 = new object[5];
					int num5 = 0;
					long num6 = lineCnt + 1L;
					lineCnt = num6;
					array2[num5] = num6;
					array2[1] = arg1;
					array2[2] = arg2;
					array2[3] = arg3;
					array2[4] = arg4;
					buff.AppendFormat(lineFmt, array2);
				};
			}();
			byte[] array = this.ToArray();
			buff.AppendFormat(format2, string.Empty);
			for (long num3 = 0L; num3 <= num; num3 += 1L)
			{
				long num4 = num3 * 4L;
				checked
				{
					if (num3 < num)
					{
						arg3 = Convert.ToString(array[(int)((IntPtr)num4)], 2).PadLeft(8, '0');
						arg4 = Convert.ToString(array[(int)((IntPtr)(unchecked(num4 + 1L)))], 2).PadLeft(8, '0');
						string arg5 = Convert.ToString(array[(int)((IntPtr)(unchecked(num4 + 2L)))], 2).PadLeft(8, '0');
						string arg6 = Convert.ToString(array[(int)((IntPtr)(unchecked(num4 + 3L)))], 2).PadLeft(8, '0');
						action(arg3, arg4, arg5, arg6);
					}
					else if (num2 > 0)
					{
						string arg7 = Convert.ToString(array[(int)((IntPtr)num4)], 2).PadLeft(8, '0');
						string arg8 = (num2 >= 2) ? Convert.ToString(array[(int)((IntPtr)(unchecked(num4 + 1L)))], 2).PadLeft(8, '0') : string.Empty;
						string arg9 = (num2 == 3) ? Convert.ToString(array[(int)((IntPtr)(unchecked(num4 + 2L)))], 2).PadLeft(8, '0') : string.Empty;
						action(arg7, arg8, arg9, string.Empty);
					}
				}
			}
			buff.AppendFormat(format3, string.Empty);
			return buff.ToString();
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000899C File Offset: 0x00006B9C
		private string toString()
		{
			string text = (this._payloadLength >= 126) ? this.ExactPayloadLength.ToString() : string.Empty;
			string text2 = (this._mask == Mask.On) ? BitConverter.ToString(this._maskingKey) : string.Empty;
			string text3 = (this._payloadLength >= 126) ? "***" : ((this._payloadLength > 0) ? this._payloadData.ToString() : string.Empty);
			return string.Format("                    FIN: {0}\n                   RSV1: {1}\n                   RSV2: {2}\n                   RSV3: {3}\n                 Opcode: {4}\n                   MASK: {5}\n         Payload Length: {6}\nExtended Payload Length: {7}\n            Masking Key: {8}\n           Payload Data: {9}", new object[]
			{
				this._fin,
				this._rsv1,
				this._rsv2,
				this._rsv3,
				this._opcode,
				this._mask,
				this._payloadLength,
				text,
				text2,
				text3
			});
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00008A92 File Offset: 0x00006C92
		internal static WebSocketFrame CreateCloseFrame(PayloadData payloadData, bool mask)
		{
			return new WebSocketFrame(Fin.Final, Opcode.Close, payloadData, false, mask);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00008A9E File Offset: 0x00006C9E
		internal static WebSocketFrame CreatePingFrame(bool mask)
		{
			return new WebSocketFrame(Fin.Final, Opcode.Ping, PayloadData.Empty, false, mask);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00008AAF File Offset: 0x00006CAF
		internal static WebSocketFrame CreatePingFrame(byte[] data, bool mask)
		{
			return new WebSocketFrame(Fin.Final, Opcode.Ping, new PayloadData(data), false, mask);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00008AC1 File Offset: 0x00006CC1
		internal static WebSocketFrame CreatePongFrame(PayloadData payloadData, bool mask)
		{
			return new WebSocketFrame(Fin.Final, Opcode.Pong, payloadData, false, mask);
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00008AD0 File Offset: 0x00006CD0
		internal static WebSocketFrame ReadFrame(Stream stream, bool unmask)
		{
			WebSocketFrame webSocketFrame = WebSocketFrame.readHeader(stream);
			WebSocketFrame.readExtendedPayloadLength(stream, webSocketFrame);
			WebSocketFrame.readMaskingKey(stream, webSocketFrame);
			WebSocketFrame.readPayloadData(stream, webSocketFrame);
			if (unmask)
			{
				webSocketFrame.Unmask();
			}
			return webSocketFrame;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00008B08 File Offset: 0x00006D08
		internal static void ReadFrameAsync(Stream stream, bool unmask, Action<WebSocketFrame> completed, Action<Exception> error)
		{
			Action<WebSocketFrame> <>9__3;
			Action<WebSocketFrame> <>9__2;
			Action<WebSocketFrame> <>9__1;
			WebSocketFrame.readHeaderAsync(stream, delegate(WebSocketFrame frame)
			{
				Stream stream2 = stream;
				Action<WebSocketFrame> completed2;
				if ((completed2 = <>9__1) == null)
				{
					completed2 = (<>9__1 = delegate(WebSocketFrame frame1)
					{
						Stream stream3 = stream;
						Action<WebSocketFrame> completed3;
						if ((completed3 = <>9__2) == null)
						{
							completed3 = (<>9__2 = delegate(WebSocketFrame frame2)
							{
								Stream stream4 = stream;
								Action<WebSocketFrame> completed4;
								if ((completed4 = <>9__3) == null)
								{
									completed4 = (<>9__3 = delegate(WebSocketFrame frame3)
									{
										if (unmask)
										{
											frame3.Unmask();
										}
										completed(frame3);
									});
								}
								WebSocketFrame.readPayloadDataAsync(stream4, frame2, completed4, error);
							});
						}
						WebSocketFrame.readMaskingKeyAsync(stream3, frame1, completed3, error);
					});
				}
				WebSocketFrame.readExtendedPayloadLengthAsync(stream2, frame, completed2, error);
			}, error);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00008B54 File Offset: 0x00006D54
		internal string ToString(bool dump)
		{
			if (!dump)
			{
				return this.toString();
			}
			return this.toDumpString();
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00008B66 File Offset: 0x00006D66
		internal void Unmask()
		{
			if (this._mask == Mask.Off)
			{
				return;
			}
			this._payloadData.Mask(this._maskingKey);
			this._maskingKey = WebSocket.EmptyBytes;
			this._mask = Mask.Off;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00008B94 File Offset: 0x00006D94
		public IEnumerator<byte> GetEnumerator()
		{
			foreach (byte b in this.ToArray())
			{
				yield return b;
			}
			byte[] array = null;
			yield break;
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00008BA4 File Offset: 0x00006DA4
		public byte[] ToArray()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				byte[] buffer = ((ushort)(((((((this._fin << 1) + (byte)this._rsv1 << 1) + (byte)this._rsv2 << 1) + (byte)this._rsv3 << 4) + (byte)this._opcode << 1) + (byte)this._mask << 7) + this._payloadLength)).ToByteArray(ByteOrder.Big);
				memoryStream.Write(buffer, 0, WebSocketFrame._defaultHeaderLength);
				if (this._payloadLength >= 126)
				{
					memoryStream.Write(this._extPayloadLength, 0, this._extPayloadLength.Length);
				}
				if (this._mask == Mask.On)
				{
					memoryStream.Write(this._maskingKey, 0, WebSocketFrame._defaultMaskingKeyLength);
				}
				if (this._payloadLength > 0)
				{
					byte[] array = this._payloadData.ToArray();
					if (this._payloadLength > 126)
					{
						memoryStream.WriteBytes(array, 1024);
					}
					else
					{
						memoryStream.Write(array, 0, array.Length);
					}
				}
				memoryStream.Close();
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00008CA4 File Offset: 0x00006EA4
		public override string ToString()
		{
			return BitConverter.ToString(this.ToArray());
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00008CB1 File Offset: 0x00006EB1
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x04000089 RID: 137
		private static readonly int _defaultHeaderLength = 2;

		// Token: 0x0400008A RID: 138
		private static readonly int _defaultMaskingKeyLength = 4;

		// Token: 0x0400008B RID: 139
		private byte[] _extPayloadLength;

		// Token: 0x0400008C RID: 140
		private Fin _fin;

		// Token: 0x0400008D RID: 141
		private Mask _mask;

		// Token: 0x0400008E RID: 142
		private byte[] _maskingKey;

		// Token: 0x0400008F RID: 143
		private Opcode _opcode;

		// Token: 0x04000090 RID: 144
		private PayloadData _payloadData;

		// Token: 0x04000091 RID: 145
		private byte _payloadLength;

		// Token: 0x04000092 RID: 146
		private Rsv _rsv1;

		// Token: 0x04000093 RID: 147
		private Rsv _rsv2;

		// Token: 0x04000094 RID: 148
		private Rsv _rsv3;
	}
}
