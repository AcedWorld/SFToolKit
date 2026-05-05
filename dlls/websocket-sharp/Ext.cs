using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Text;
using WebSocketSharp.Net;

namespace WebSocketSharp
{
	// Token: 0x02000002 RID: 2
	public static class Ext
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private static byte[] compress(this byte[] data)
		{
			bool flag = (long)data.Length == 0L;
			byte[] result;
			if (flag)
			{
				result = data;
			}
			else
			{
				using (MemoryStream memoryStream = new MemoryStream(data))
				{
					result = memoryStream.compressToArray();
				}
			}
			return result;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000209C File Offset: 0x0000029C
		private static MemoryStream compress(this Stream stream)
		{
			MemoryStream memoryStream = new MemoryStream();
			bool flag = stream.Length == 0L;
			MemoryStream result;
			if (flag)
			{
				result = memoryStream;
			}
			else
			{
				stream.Position = 0L;
				using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress, true))
				{
					stream.CopyTo(deflateStream, 1024);
					deflateStream.Close();
					memoryStream.Write(Ext._last, 0, 1);
					memoryStream.Position = 0L;
					result = memoryStream;
				}
			}
			return result;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002120 File Offset: 0x00000320
		private static byte[] compressToArray(this Stream stream)
		{
			byte[] result;
			using (MemoryStream memoryStream = stream.compress())
			{
				memoryStream.Close();
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002164 File Offset: 0x00000364
		private static byte[] decompress(this byte[] data)
		{
			bool flag = (long)data.Length == 0L;
			byte[] result;
			if (flag)
			{
				result = data;
			}
			else
			{
				using (MemoryStream memoryStream = new MemoryStream(data))
				{
					result = memoryStream.decompressToArray();
				}
			}
			return result;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000021B0 File Offset: 0x000003B0
		private static MemoryStream decompress(this Stream stream)
		{
			MemoryStream memoryStream = new MemoryStream();
			bool flag = stream.Length == 0L;
			MemoryStream result;
			if (flag)
			{
				result = memoryStream;
			}
			else
			{
				stream.Position = 0L;
				using (DeflateStream deflateStream = new DeflateStream(stream, CompressionMode.Decompress, true))
				{
					deflateStream.CopyTo(memoryStream, 1024);
					memoryStream.Position = 0L;
					result = memoryStream;
				}
			}
			return result;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002220 File Offset: 0x00000420
		private static byte[] decompressToArray(this Stream stream)
		{
			byte[] result;
			using (MemoryStream memoryStream = stream.decompress())
			{
				memoryStream.Close();
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002264 File Offset: 0x00000464
		private static bool isHttpMethod(this string value)
		{
			return value == "GET" || value == "HEAD" || value == "POST" || value == "PUT" || value == "DELETE" || value == "CONNECT" || value == "OPTIONS" || value == "TRACE";
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000022E0 File Offset: 0x000004E0
		private static bool isHttpMethod10(this string value)
		{
			return value == "GET" || value == "HEAD" || value == "POST";
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000231C File Offset: 0x0000051C
		internal static byte[] Append(this ushort code, string reason)
		{
			byte[] array = code.InternalToByteArray(ByteOrder.Big);
			bool flag = reason == null || reason.Length == 0;
			byte[] result;
			if (flag)
			{
				result = array;
			}
			else
			{
				List<byte> list = new List<byte>(array);
				list.AddRange(Encoding.UTF8.GetBytes(reason));
				result = list.ToArray();
			}
			return result;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000236C File Offset: 0x0000056C
		internal static byte[] Compress(this byte[] data, CompressionMethod method)
		{
			return (method == CompressionMethod.Deflate) ? data.compress() : data;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000238C File Offset: 0x0000058C
		internal static Stream Compress(this Stream stream, CompressionMethod method)
		{
			return (method == CompressionMethod.Deflate) ? stream.compress() : stream;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000023AC File Offset: 0x000005AC
		internal static byte[] CompressToArray(this Stream stream, CompressionMethod method)
		{
			return (method == CompressionMethod.Deflate) ? stream.compressToArray() : stream.ToByteArray();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000023D0 File Offset: 0x000005D0
		internal static bool Contains(this string value, params char[] anyOf)
		{
			return anyOf != null && anyOf.Length != 0 && value.IndexOfAny(anyOf) > -1;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000023F8 File Offset: 0x000005F8
		internal static bool Contains(this NameValueCollection collection, string name)
		{
			return collection[name] != null;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002414 File Offset: 0x00000614
		internal static bool Contains(this NameValueCollection collection, string name, string value, StringComparison comparisonTypeForValue)
		{
			string text = collection[name];
			bool flag = text == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				foreach (string text2 in text.Split(new char[]
				{
					','
				}))
				{
					bool flag2 = text2.Trim().Equals(value, comparisonTypeForValue);
					if (flag2)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002480 File Offset: 0x00000680
		internal static bool Contains<T>(this IEnumerable<T> source, Func<T, bool> condition)
		{
			foreach (T arg in source)
			{
				bool flag = condition(arg);
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000024DC File Offset: 0x000006DC
		internal static bool ContainsTwice(this string[] values)
		{
			int len = values.Length;
			int end = len - 1;
			Func<int, bool> seek = null;
			seek = delegate(int idx)
			{
				bool flag = idx == end;
				bool result;
				if (flag)
				{
					result = false;
				}
				else
				{
					string b = values[idx];
					for (int i = idx + 1; i < len; i++)
					{
						bool flag2 = values[i] == b;
						if (flag2)
						{
							return true;
						}
					}
					result = seek(++idx);
				}
				return result;
			};
			return seek(0);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000253C File Offset: 0x0000073C
		internal static T[] Copy<T>(this T[] source, int length)
		{
			T[] array = new T[length];
			Array.Copy(source, 0, array, 0, length);
			return array;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002564 File Offset: 0x00000764
		internal static T[] Copy<T>(this T[] source, long length)
		{
			T[] array = new T[length];
			Array.Copy(source, 0L, array, 0L, length);
			return array;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000258C File Offset: 0x0000078C
		internal static void CopyTo(this Stream source, Stream destination, int bufferLength)
		{
			byte[] buffer = new byte[bufferLength];
			for (;;)
			{
				int num = source.Read(buffer, 0, bufferLength);
				bool flag = num <= 0;
				if (flag)
				{
					break;
				}
				destination.Write(buffer, 0, num);
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000025CC File Offset: 0x000007CC
		internal static void CopyToAsync(this Stream source, Stream destination, int bufferLength, Action completed, Action<Exception> error)
		{
			byte[] buff = new byte[bufferLength];
			AsyncCallback callback = null;
			callback = delegate(IAsyncResult ar)
			{
				try
				{
					int num = source.EndRead(ar);
					bool flag2 = num <= 0;
					if (flag2)
					{
						bool flag3 = completed != null;
						if (flag3)
						{
							completed();
						}
					}
					else
					{
						destination.Write(buff, 0, num);
						source.BeginRead(buff, 0, bufferLength, callback, null);
					}
				}
				catch (Exception obj2)
				{
					bool flag4 = error != null;
					if (flag4)
					{
						error(obj2);
					}
				}
			};
			try
			{
				source.BeginRead(buff, 0, bufferLength, callback, null);
			}
			catch (Exception obj)
			{
				bool flag = error != null;
				if (flag)
				{
					error(obj);
				}
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002684 File Offset: 0x00000884
		internal static byte[] Decompress(this byte[] data, CompressionMethod method)
		{
			return (method == CompressionMethod.Deflate) ? data.decompress() : data;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000026A4 File Offset: 0x000008A4
		internal static Stream Decompress(this Stream stream, CompressionMethod method)
		{
			return (method == CompressionMethod.Deflate) ? stream.decompress() : stream;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000026C4 File Offset: 0x000008C4
		internal static byte[] DecompressToArray(this Stream stream, CompressionMethod method)
		{
			return (method == CompressionMethod.Deflate) ? stream.decompressToArray() : stream.ToByteArray();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000026E8 File Offset: 0x000008E8
		internal static void Emit(this EventHandler eventHandler, object sender, EventArgs e)
		{
			bool flag = eventHandler == null;
			if (!flag)
			{
				eventHandler(sender, e);
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000270C File Offset: 0x0000090C
		internal static void Emit<TEventArgs>(this EventHandler<TEventArgs> eventHandler, object sender, TEventArgs e) where TEventArgs : EventArgs
		{
			bool flag = eventHandler == null;
			if (!flag)
			{
				eventHandler(sender, e);
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002730 File Offset: 0x00000930
		internal static bool EqualsWith(this int value, char c, Action<int> action)
		{
			action(value);
			return value == (int)c;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002750 File Offset: 0x00000950
		internal static string GetAbsolutePath(this Uri uri)
		{
			bool isAbsoluteUri = uri.IsAbsoluteUri;
			string result;
			if (isAbsoluteUri)
			{
				result = uri.AbsolutePath;
			}
			else
			{
				string originalString = uri.OriginalString;
				bool flag = originalString[0] != '/';
				if (flag)
				{
					result = null;
				}
				else
				{
					int num = originalString.IndexOfAny(new char[]
					{
						'?',
						'#'
					});
					result = ((num > 0) ? originalString.Substring(0, num) : originalString);
				}
			}
			return result;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000027BC File Offset: 0x000009BC
		internal static WebSocketSharp.Net.CookieCollection GetCookies(this NameValueCollection headers, bool response)
		{
			string text = headers[response ? "Set-Cookie" : "Cookie"];
			return (text != null) ? WebSocketSharp.Net.CookieCollection.Parse(text, response) : new WebSocketSharp.Net.CookieCollection();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000027F8 File Offset: 0x000009F8
		internal static string GetDnsSafeHost(this Uri uri, bool bracketIPv6)
		{
			return (bracketIPv6 && uri.HostNameType == UriHostNameType.IPv6) ? uri.Host : uri.DnsSafeHost;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002824 File Offset: 0x00000A24
		internal static string GetMessage(this CloseStatusCode code)
		{
			return (code == CloseStatusCode.ProtocolError) ? "A WebSocket protocol error has occurred." : ((code == CloseStatusCode.UnsupportedData) ? "Unsupported data has been received." : ((code == CloseStatusCode.Abnormal) ? "An exception has occurred." : ((code == CloseStatusCode.InvalidData) ? "Invalid data has been received." : ((code == CloseStatusCode.PolicyViolation) ? "A policy violation has occurred." : ((code == CloseStatusCode.TooBig) ? "A too big message has been received." : ((code == CloseStatusCode.MandatoryExtension) ? "WebSocket client didn't receive expected extension(s)." : ((code == CloseStatusCode.ServerError) ? "WebSocket server got an internal error." : ((code == CloseStatusCode.TlsHandshakeFailure) ? "An error has occurred during a TLS handshake." : string.Empty))))))));
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000028C4 File Offset: 0x00000AC4
		internal static string GetName(this string nameAndValue, char separator)
		{
			int num = nameAndValue.IndexOf(separator);
			return (num > 0) ? nameAndValue.Substring(0, num).Trim() : null;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000028F4 File Offset: 0x00000AF4
		internal static string GetUTF8DecodedString(this byte[] bytes)
		{
			return Encoding.UTF8.GetString(bytes);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002914 File Offset: 0x00000B14
		internal static byte[] GetUTF8EncodedBytes(this string s)
		{
			return Encoding.UTF8.GetBytes(s);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002934 File Offset: 0x00000B34
		internal static string GetValue(this string nameAndValue, char separator)
		{
			return nameAndValue.GetValue(separator, false);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002950 File Offset: 0x00000B50
		internal static string GetValue(this string nameAndValue, char separator, bool unquote)
		{
			int num = nameAndValue.IndexOf(separator);
			bool flag = num < 0 || num == nameAndValue.Length - 1;
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				string text = nameAndValue.Substring(num + 1).Trim();
				result = (unquote ? text.Unquote() : text);
			}
			return result;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000029A0 File Offset: 0x00000BA0
		internal static byte[] InternalToByteArray(this ushort value, ByteOrder order)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			bool flag = !order.IsHostOrder();
			if (flag)
			{
				Array.Reverse(bytes);
			}
			return bytes;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000029D0 File Offset: 0x00000BD0
		internal static byte[] InternalToByteArray(this ulong value, ByteOrder order)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			bool flag = !order.IsHostOrder();
			if (flag)
			{
				Array.Reverse(bytes);
			}
			return bytes;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002A00 File Offset: 0x00000C00
		internal static bool IsCompressionExtension(this string value, CompressionMethod method)
		{
			return value.StartsWith(method.ToExtensionString(Array.Empty<string>()));
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002A24 File Offset: 0x00000C24
		internal static bool IsControl(this byte opcode)
		{
			return opcode > 7 && opcode < 16;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002A44 File Offset: 0x00000C44
		internal static bool IsControl(this Opcode opcode)
		{
			return opcode >= Opcode.Close;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002A60 File Offset: 0x00000C60
		internal static bool IsData(this byte opcode)
		{
			return opcode == 1 || opcode == 2;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002A80 File Offset: 0x00000C80
		internal static bool IsData(this Opcode opcode)
		{
			return opcode == Opcode.Text || opcode == Opcode.Binary;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002AA0 File Offset: 0x00000CA0
		internal static bool IsHttpMethod(this string value, Version version)
		{
			return (version == WebSocketSharp.Net.HttpVersion.Version10) ? value.isHttpMethod10() : value.isHttpMethod();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002AD0 File Offset: 0x00000CD0
		internal static bool IsPortNumber(this int value)
		{
			return value > 0 && value < 65536;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002AF4 File Offset: 0x00000CF4
		internal static bool IsReserved(this ushort code)
		{
			return code == 1004 || code == 1005 || code == 1006 || code == 1015;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002B2C File Offset: 0x00000D2C
		internal static bool IsReserved(this CloseStatusCode code)
		{
			return code == CloseStatusCode.Undefined || code == CloseStatusCode.NoStatus || code == CloseStatusCode.Abnormal || code == CloseStatusCode.TlsHandshakeFailure;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002B64 File Offset: 0x00000D64
		internal static bool IsSupported(this byte opcode)
		{
			return Enum.IsDefined(typeof(Opcode), opcode);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002B8C File Offset: 0x00000D8C
		internal static bool IsText(this string value)
		{
			int length = value.Length;
			for (int i = 0; i < length; i++)
			{
				char c = value[i];
				bool flag = c < ' ';
				if (flag)
				{
					bool flag2 = "\r\n\t".IndexOf(c) == -1;
					if (flag2)
					{
						return false;
					}
					bool flag3 = c == '\n';
					if (flag3)
					{
						i++;
						bool flag4 = i == length;
						if (flag4)
						{
							break;
						}
						c = value[i];
						bool flag5 = " \t".IndexOf(c) == -1;
						if (flag5)
						{
							return false;
						}
					}
				}
				else
				{
					bool flag6 = c == '\u007f';
					if (flag6)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002C40 File Offset: 0x00000E40
		internal static bool IsToken(this string value)
		{
			int i = 0;
			while (i < value.Length)
			{
				char c = value[i];
				bool flag = c < ' ';
				bool result;
				if (flag)
				{
					result = false;
				}
				else
				{
					bool flag2 = c > '~';
					if (flag2)
					{
						result = false;
					}
					else
					{
						bool flag3 = "()<>@,;:\\\"/[]?={} \t".IndexOf(c) > -1;
						if (!flag3)
						{
							i++;
							continue;
						}
						result = false;
					}
				}
				return result;
			}
			return true;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002CAC File Offset: 0x00000EAC
		internal static bool KeepsAlive(this NameValueCollection headers, Version version)
		{
			StringComparison comparisonTypeForValue = StringComparison.OrdinalIgnoreCase;
			return (version < WebSocketSharp.Net.HttpVersion.Version11) ? headers.Contains("Connection", "keep-alive", comparisonTypeForValue) : (!headers.Contains("Connection", "close", comparisonTypeForValue));
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002CF4 File Offset: 0x00000EF4
		internal static string Quote(this string value)
		{
			return string.Format("\"{0}\"", value.Replace("\"", "\\\""));
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002D20 File Offset: 0x00000F20
		internal static byte[] ReadBytes(this Stream stream, int length)
		{
			byte[] array = new byte[length];
			int num = 0;
			int num2 = 0;
			while (length > 0)
			{
				int num3 = stream.Read(array, num, length);
				bool flag = num3 <= 0;
				if (flag)
				{
					bool flag2 = num2 < Ext._retry;
					if (!flag2)
					{
						return array.SubArray(0, num);
					}
					num2++;
				}
				else
				{
					num2 = 0;
					num += num3;
					length -= num3;
				}
			}
			return array;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002D94 File Offset: 0x00000F94
		internal static byte[] ReadBytes(this Stream stream, long length, int bufferLength)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				byte[] buffer = new byte[bufferLength];
				int num = 0;
				while (length > 0L)
				{
					bool flag = length < (long)bufferLength;
					if (flag)
					{
						bufferLength = (int)length;
					}
					int num2 = stream.Read(buffer, 0, bufferLength);
					bool flag2 = num2 <= 0;
					if (flag2)
					{
						bool flag3 = num < Ext._retry;
						if (!flag3)
						{
							break;
						}
						num++;
					}
					else
					{
						num = 0;
						memoryStream.Write(buffer, 0, num2);
						length -= (long)num2;
					}
				}
				memoryStream.Close();
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002E44 File Offset: 0x00001044
		internal static void ReadBytesAsync(this Stream stream, int length, Action<byte[]> completed, Action<Exception> error)
		{
			byte[] buff = new byte[length];
			int offset = 0;
			int retry = 0;
			AsyncCallback callback = null;
			callback = delegate(IAsyncResult ar)
			{
				try
				{
					int num = stream.EndRead(ar);
					bool flag2 = num <= 0;
					if (flag2)
					{
						int retry;
						bool flag3 = retry < Ext._retry;
						if (flag3)
						{
							retry = retry;
							retry++;
							stream.BeginRead(buff, offset, length, callback, null);
						}
						else
						{
							bool flag4 = completed != null;
							if (flag4)
							{
								completed(buff.SubArray(0, offset));
							}
						}
					}
					else
					{
						bool flag5 = num == length;
						if (flag5)
						{
							bool flag6 = completed != null;
							if (flag6)
							{
								completed(buff);
							}
						}
						else
						{
							int retry = 0;
							offset += num;
							length -= num;
							stream.BeginRead(buff, offset, length, callback, null);
						}
					}
				}
				catch (Exception obj2)
				{
					bool flag7 = error != null;
					if (flag7)
					{
						error(obj2);
					}
				}
			};
			try
			{
				stream.BeginRead(buff, offset, length, callback, null);
			}
			catch (Exception obj)
			{
				bool flag = error != null;
				if (flag)
				{
					error(obj);
				}
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002F04 File Offset: 0x00001104
		internal static void ReadBytesAsync(this Stream stream, long length, int bufferLength, Action<byte[]> completed, Action<Exception> error)
		{
			MemoryStream dest = new MemoryStream();
			byte[] buff = new byte[bufferLength];
			int retry = 0;
			Action<long> read = null;
			read = delegate(long len)
			{
				bool flag2 = len < (long)bufferLength;
				if (flag2)
				{
					bufferLength = (int)len;
				}
				stream.BeginRead(buff, 0, bufferLength, delegate(IAsyncResult ar)
				{
					try
					{
						int num = stream.EndRead(ar);
						bool flag3 = num <= 0;
						if (flag3)
						{
							int retry;
							bool flag4 = retry < Ext._retry;
							if (flag4)
							{
								retry = retry;
								retry++;
								read(len);
							}
							else
							{
								bool flag5 = completed != null;
								if (flag5)
								{
									dest.Close();
									completed(dest.ToArray());
								}
								dest.Dispose();
							}
						}
						else
						{
							dest.Write(buff, 0, num);
							bool flag6 = (long)num == len;
							if (flag6)
							{
								bool flag7 = completed != null;
								if (flag7)
								{
									dest.Close();
									completed(dest.ToArray());
								}
								dest.Dispose();
							}
							else
							{
								int retry = 0;
								read(len - (long)num);
							}
						}
					}
					catch (Exception obj2)
					{
						dest.Dispose();
						bool flag8 = error != null;
						if (flag8)
						{
							error(obj2);
						}
					}
				}, null);
			};
			try
			{
				read(length);
			}
			catch (Exception obj)
			{
				dest.Dispose();
				bool flag = error != null;
				if (flag)
				{
					error(obj);
				}
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002FC0 File Offset: 0x000011C0
		internal static T[] Reverse<T>(this T[] array)
		{
			int num = array.Length;
			T[] array2 = new T[num];
			int num2 = num - 1;
			for (int i = 0; i <= num2; i++)
			{
				array2[i] = array[num2 - i];
			}
			return array2;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003009 File Offset: 0x00001209
		internal static IEnumerable<string> SplitHeaderValue(this string value, params char[] separators)
		{
			int len = value.Length;
			int end = len - 1;
			StringBuilder buff = new StringBuilder(32);
			bool escaped = false;
			bool quoted = false;
			int num;
			for (int i = 0; i <= end; i = num + 1)
			{
				char c = value[i];
				buff.Append(c);
				bool flag = c == '"';
				if (flag)
				{
					bool flag2 = escaped;
					if (flag2)
					{
						escaped = false;
					}
					else
					{
						quoted = !quoted;
					}
				}
				else
				{
					bool flag3 = c == '\\';
					if (flag3)
					{
						bool flag4 = i == end;
						if (flag4)
						{
							break;
						}
						bool flag5 = value[i + 1] == '"';
						if (flag5)
						{
							escaped = true;
						}
					}
					else
					{
						bool flag6 = Array.IndexOf<char>(separators, c) > -1;
						if (flag6)
						{
							bool flag7 = quoted;
							if (!flag7)
							{
								buff.Length--;
								yield return buff.ToString();
								buff.Length = 0;
							}
						}
					}
				}
				num = i;
			}
			yield return buff.ToString();
			yield break;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003020 File Offset: 0x00001220
		internal static byte[] ToByteArray(this Stream stream)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				stream.Position = 0L;
				stream.CopyTo(memoryStream, 1024);
				memoryStream.Close();
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003078 File Offset: 0x00001278
		internal static CompressionMethod ToCompressionMethod(this string value)
		{
			Array values = Enum.GetValues(typeof(CompressionMethod));
			foreach (object obj in values)
			{
				CompressionMethod compressionMethod = (CompressionMethod)obj;
				bool flag = compressionMethod.ToExtensionString(Array.Empty<string>()) == value;
				if (flag)
				{
					return compressionMethod;
				}
			}
			return CompressionMethod.None;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003100 File Offset: 0x00001300
		internal static string ToExtensionString(this CompressionMethod method, params string[] parameters)
		{
			bool flag = method == CompressionMethod.None;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				string text = string.Format("permessage-{0}", method.ToString().ToLower());
				result = ((parameters != null && parameters.Length != 0) ? string.Format("{0}; {1}", text, parameters.ToString("; ")) : text);
			}
			return result;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003160 File Offset: 0x00001360
		internal static IPAddress ToIPAddress(this string value)
		{
			bool flag = value == null || value.Length == 0;
			IPAddress result;
			if (flag)
			{
				result = null;
			}
			else
			{
				IPAddress ipaddress;
				bool flag2 = IPAddress.TryParse(value, out ipaddress);
				if (flag2)
				{
					result = ipaddress;
				}
				else
				{
					try
					{
						IPAddress[] hostAddresses = Dns.GetHostAddresses(value);
						result = hostAddresses[0];
					}
					catch
					{
						result = null;
					}
				}
			}
			return result;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000031C0 File Offset: 0x000013C0
		internal static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
		{
			return new List<TSource>(source);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000031D8 File Offset: 0x000013D8
		internal static string ToString(this IPAddress address, bool bracketIPv6)
		{
			return (bracketIPv6 && address.AddressFamily == AddressFamily.InterNetworkV6) ? string.Format("[{0}]", address.ToString()) : address.ToString();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003210 File Offset: 0x00001410
		internal static ushort ToUInt16(this byte[] source, ByteOrder sourceOrder)
		{
			return BitConverter.ToUInt16(source.ToHostOrder(sourceOrder), 0);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003230 File Offset: 0x00001430
		internal static ulong ToUInt64(this byte[] source, ByteOrder sourceOrder)
		{
			return BitConverter.ToUInt64(source.ToHostOrder(sourceOrder), 0);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000324F File Offset: 0x0000144F
		internal static IEnumerable<string> TrimEach(this IEnumerable<string> source)
		{
			foreach (string elm in source)
			{
				yield return elm.Trim();
				elm = null;
			}
			IEnumerator<string> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003260 File Offset: 0x00001460
		internal static string TrimSlashFromEnd(this string value)
		{
			string text = value.TrimEnd(new char[]
			{
				'/'
			});
			return (text.Length > 0) ? text : "/";
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003298 File Offset: 0x00001498
		internal static string TrimSlashOrBackslashFromEnd(this string value)
		{
			string text = value.TrimEnd(new char[]
			{
				'/',
				'\\'
			});
			return (text.Length > 0) ? text : value[0].ToString();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000032DC File Offset: 0x000014DC
		internal static bool TryCreateVersion(this string versionString, out Version result)
		{
			result = null;
			try
			{
				result = new Version(versionString);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003314 File Offset: 0x00001514
		internal static bool TryCreateWebSocketUri(this string uriString, out Uri result, out string message)
		{
			result = null;
			message = null;
			Uri uri = uriString.ToUri();
			bool flag = uri == null;
			bool result2;
			if (flag)
			{
				message = "An invalid URI string.";
				result2 = false;
			}
			else
			{
				bool flag2 = !uri.IsAbsoluteUri;
				if (flag2)
				{
					message = "A relative URI.";
					result2 = false;
				}
				else
				{
					string scheme = uri.Scheme;
					bool flag3 = !(scheme == "ws") && !(scheme == "wss");
					if (flag3)
					{
						message = "The scheme part is not 'ws' or 'wss'.";
						result2 = false;
					}
					else
					{
						int port = uri.Port;
						bool flag4 = port == 0;
						if (flag4)
						{
							message = "The port part is zero.";
							result2 = false;
						}
						else
						{
							bool flag5 = uri.Fragment.Length > 0;
							if (flag5)
							{
								message = "It includes the fragment component.";
								result2 = false;
							}
							else
							{
								result = ((port != -1) ? uri : new Uri(string.Format("{0}://{1}:{2}{3}", new object[]
								{
									scheme,
									uri.Host,
									(scheme == "ws") ? 80 : 443,
									uri.PathAndQuery
								})));
								result2 = true;
							}
						}
					}
				}
			}
			return result2;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000343C File Offset: 0x0000163C
		internal static bool TryGetUTF8DecodedString(this byte[] bytes, out string s)
		{
			s = null;
			try
			{
				s = Encoding.UTF8.GetString(bytes);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000347C File Offset: 0x0000167C
		internal static bool TryGetUTF8EncodedBytes(this string s, out byte[] bytes)
		{
			bytes = null;
			try
			{
				bytes = Encoding.UTF8.GetBytes(s);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000034BC File Offset: 0x000016BC
		internal static bool TryOpenRead(this FileInfo fileInfo, out FileStream fileStream)
		{
			fileStream = null;
			try
			{
				fileStream = fileInfo.OpenRead();
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000034F4 File Offset: 0x000016F4
		internal static string Unquote(this string value)
		{
			int num = value.IndexOf('"');
			bool flag = num == -1;
			string result;
			if (flag)
			{
				result = value;
			}
			else
			{
				int num2 = value.LastIndexOf('"');
				bool flag2 = num2 == num;
				if (flag2)
				{
					result = value;
				}
				else
				{
					int num3 = num2 - num - 1;
					result = ((num3 > 0) ? value.Substring(num + 1, num3).Replace("\\\"", "\"") : string.Empty);
				}
			}
			return result;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003560 File Offset: 0x00001760
		internal static bool Upgrades(this NameValueCollection headers, string protocol)
		{
			StringComparison comparisonTypeForValue = StringComparison.OrdinalIgnoreCase;
			return headers.Contains("Upgrade", protocol, comparisonTypeForValue) && headers.Contains("Connection", "Upgrade", comparisonTypeForValue);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003598 File Offset: 0x00001798
		internal static string UrlDecode(this string value, Encoding encoding)
		{
			return HttpUtility.UrlDecode(value, encoding);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000035B4 File Offset: 0x000017B4
		internal static string UrlEncode(this string value, Encoding encoding)
		{
			return HttpUtility.UrlEncode(value, encoding);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000035D0 File Offset: 0x000017D0
		internal static void WriteBytes(this Stream stream, byte[] bytes, int bufferLength)
		{
			using (MemoryStream memoryStream = new MemoryStream(bytes))
			{
				memoryStream.CopyTo(stream, bufferLength);
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000360C File Offset: 0x0000180C
		internal static void WriteBytesAsync(this Stream stream, byte[] bytes, int bufferLength, Action completed, Action<Exception> error)
		{
			MemoryStream src = new MemoryStream(bytes);
			src.CopyToAsync(stream, bufferLength, delegate
			{
				bool flag = completed != null;
				if (flag)
				{
					completed();
				}
				src.Dispose();
			}, delegate(Exception ex)
			{
				src.Dispose();
				bool flag = error != null;
				if (flag)
				{
					error(ex);
				}
			});
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003664 File Offset: 0x00001864
		public static string GetDescription(this WebSocketSharp.Net.HttpStatusCode code)
		{
			return ((int)code).GetStatusDescription();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000367C File Offset: 0x0000187C
		public static string GetStatusDescription(this int code)
		{
			if (code <= 207)
			{
				switch (code)
				{
				case 100:
					return "Continue";
				case 101:
					return "Switching Protocols";
				case 102:
					return "Processing";
				default:
					switch (code)
					{
					case 200:
						return "OK";
					case 201:
						return "Created";
					case 202:
						return "Accepted";
					case 203:
						return "Non-Authoritative Information";
					case 204:
						return "No Content";
					case 205:
						return "Reset Content";
					case 206:
						return "Partial Content";
					case 207:
						return "Multi-Status";
					}
					break;
				}
			}
			else
			{
				switch (code)
				{
				case 300:
					return "Multiple Choices";
				case 301:
					return "Moved Permanently";
				case 302:
					return "Found";
				case 303:
					return "See Other";
				case 304:
					return "Not Modified";
				case 305:
					return "Use Proxy";
				case 306:
					break;
				case 307:
					return "Temporary Redirect";
				default:
					switch (code)
					{
					case 400:
						return "Bad Request";
					case 401:
						return "Unauthorized";
					case 402:
						return "Payment Required";
					case 403:
						return "Forbidden";
					case 404:
						return "Not Found";
					case 405:
						return "Method Not Allowed";
					case 406:
						return "Not Acceptable";
					case 407:
						return "Proxy Authentication Required";
					case 408:
						return "Request Timeout";
					case 409:
						return "Conflict";
					case 410:
						return "Gone";
					case 411:
						return "Length Required";
					case 412:
						return "Precondition Failed";
					case 413:
						return "Request Entity Too Large";
					case 414:
						return "Request-Uri Too Long";
					case 415:
						return "Unsupported Media Type";
					case 416:
						return "Requested Range Not Satisfiable";
					case 417:
						return "Expectation Failed";
					case 418:
					case 419:
					case 420:
					case 421:
						break;
					case 422:
						return "Unprocessable Entity";
					case 423:
						return "Locked";
					case 424:
						return "Failed Dependency";
					default:
						switch (code)
						{
						case 500:
							return "Internal Server Error";
						case 501:
							return "Not Implemented";
						case 502:
							return "Bad Gateway";
						case 503:
							return "Service Unavailable";
						case 504:
							return "Gateway Timeout";
						case 505:
							return "Http Version Not Supported";
						case 507:
							return "Insufficient Storage";
						}
						break;
					}
					break;
				}
			}
			return string.Empty;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003988 File Offset: 0x00001B88
		public static bool IsCloseStatusCode(this ushort value)
		{
			return value > 999 && value < 5000;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000039B0 File Offset: 0x00001BB0
		public static bool IsEnclosedIn(this string value, char c)
		{
			bool flag = value == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int length = value.Length;
				bool flag2 = length < 2;
				result = (!flag2 && value[0] == c && value[length - 1] == c);
			}
			return result;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000039FC File Offset: 0x00001BFC
		public static bool IsHostOrder(this ByteOrder order)
		{
			return BitConverter.IsLittleEndian == (order == ByteOrder.Little);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00003A1C File Offset: 0x00001C1C
		public static bool IsLocal(this IPAddress address)
		{
			bool flag = address == null;
			if (flag)
			{
				throw new ArgumentNullException("address");
			}
			bool flag2 = address.Equals(IPAddress.Any);
			bool result;
			if (flag2)
			{
				result = true;
			}
			else
			{
				bool flag3 = address.Equals(IPAddress.Loopback);
				if (flag3)
				{
					result = true;
				}
				else
				{
					bool ossupportsIPv = Socket.OSSupportsIPv6;
					if (ossupportsIPv)
					{
						bool flag4 = address.Equals(IPAddress.IPv6Any);
						if (flag4)
						{
							return true;
						}
						bool flag5 = address.Equals(IPAddress.IPv6Loopback);
						if (flag5)
						{
							return true;
						}
					}
					string hostName = Dns.GetHostName();
					IPAddress[] hostAddresses = Dns.GetHostAddresses(hostName);
					foreach (IPAddress obj in hostAddresses)
					{
						bool flag6 = address.Equals(obj);
						if (flag6)
						{
							return true;
						}
					}
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003AEC File Offset: 0x00001CEC
		public static bool IsNullOrEmpty(this string value)
		{
			return value == null || value.Length == 0;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003B10 File Offset: 0x00001D10
		public static bool IsPredefinedScheme(this string value)
		{
			bool flag = value == null || value.Length < 2;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				char c = value[0];
				bool flag2 = c == 'h';
				if (flag2)
				{
					result = (value == "http" || value == "https");
				}
				else
				{
					bool flag3 = c == 'w';
					if (flag3)
					{
						result = (value == "ws" || value == "wss");
					}
					else
					{
						bool flag4 = c == 'f';
						if (flag4)
						{
							result = (value == "file" || value == "ftp");
						}
						else
						{
							bool flag5 = c == 'g';
							if (flag5)
							{
								result = (value == "gopher");
							}
							else
							{
								bool flag6 = c == 'm';
								if (flag6)
								{
									result = (value == "mailto");
								}
								else
								{
									bool flag7 = c == 'n';
									if (flag7)
									{
										c = value[1];
										result = ((c == 'e') ? (value == "news" || value == "net.pipe" || value == "net.tcp") : (value == "nntp"));
									}
									else
									{
										result = false;
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003C4C File Offset: 0x00001E4C
		public static bool MaybeUri(this string value)
		{
			bool flag = value == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = value.Length == 0;
				if (flag2)
				{
					result = false;
				}
				else
				{
					int num = value.IndexOf(':');
					bool flag3 = num == -1;
					if (flag3)
					{
						result = false;
					}
					else
					{
						bool flag4 = num >= 10;
						if (flag4)
						{
							result = false;
						}
						else
						{
							string value2 = value.Substring(0, num);
							result = value2.IsPredefinedScheme();
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003CB8 File Offset: 0x00001EB8
		public static T[] SubArray<T>(this T[] array, int startIndex, int length)
		{
			bool flag = array == null;
			if (flag)
			{
				throw new ArgumentNullException("array");
			}
			int num = array.Length;
			bool flag2 = num == 0;
			T[] result;
			if (flag2)
			{
				bool flag3 = startIndex != 0;
				if (flag3)
				{
					throw new ArgumentOutOfRangeException("startIndex");
				}
				bool flag4 = length != 0;
				if (flag4)
				{
					throw new ArgumentOutOfRangeException("length");
				}
				result = array;
			}
			else
			{
				bool flag5 = startIndex < 0 || startIndex >= num;
				if (flag5)
				{
					throw new ArgumentOutOfRangeException("startIndex");
				}
				bool flag6 = length < 0 || length > num - startIndex;
				if (flag6)
				{
					throw new ArgumentOutOfRangeException("length");
				}
				bool flag7 = length == 0;
				if (flag7)
				{
					result = new T[0];
				}
				else
				{
					bool flag8 = length == num;
					if (flag8)
					{
						result = array;
					}
					else
					{
						T[] array2 = new T[length];
						Array.Copy(array, startIndex, array2, 0, length);
						result = array2;
					}
				}
			}
			return result;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003D90 File Offset: 0x00001F90
		public static T[] SubArray<T>(this T[] array, long startIndex, long length)
		{
			bool flag = array == null;
			if (flag)
			{
				throw new ArgumentNullException("array");
			}
			long num = (long)array.Length;
			bool flag2 = num == 0L;
			T[] result;
			if (flag2)
			{
				bool flag3 = startIndex != 0L;
				if (flag3)
				{
					throw new ArgumentOutOfRangeException("startIndex");
				}
				bool flag4 = length != 0L;
				if (flag4)
				{
					throw new ArgumentOutOfRangeException("length");
				}
				result = array;
			}
			else
			{
				bool flag5 = startIndex < 0L || startIndex >= num;
				if (flag5)
				{
					throw new ArgumentOutOfRangeException("startIndex");
				}
				bool flag6 = length < 0L || length > num - startIndex;
				if (flag6)
				{
					throw new ArgumentOutOfRangeException("length");
				}
				bool flag7 = length == 0L;
				if (flag7)
				{
					result = new T[0];
				}
				else
				{
					bool flag8 = length == num;
					if (flag8)
					{
						result = array;
					}
					else
					{
						T[] array2 = new T[length];
						Array.Copy(array, startIndex, array2, 0L, length);
						result = array2;
					}
				}
			}
			return result;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003E70 File Offset: 0x00002070
		public static void Times(this int n, Action action)
		{
			bool flag = n <= 0;
			if (!flag)
			{
				bool flag2 = action == null;
				if (!flag2)
				{
					for (int i = 0; i < n; i++)
					{
						action();
					}
				}
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003EAC File Offset: 0x000020AC
		public static void Times(this long n, Action action)
		{
			bool flag = n <= 0L;
			if (!flag)
			{
				bool flag2 = action == null;
				if (!flag2)
				{
					for (long num = 0L; num < n; num += 1L)
					{
						action();
					}
				}
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003EEC File Offset: 0x000020EC
		public static void Times(this uint n, Action action)
		{
			bool flag = n == 0U;
			if (!flag)
			{
				bool flag2 = action == null;
				if (!flag2)
				{
					for (uint num = 0U; num < n; num += 1U)
					{
						action();
					}
				}
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003F28 File Offset: 0x00002128
		public static void Times(this ulong n, Action action)
		{
			bool flag = n == 0UL;
			if (!flag)
			{
				bool flag2 = action == null;
				if (!flag2)
				{
					for (ulong num = 0UL; num < n; num += 1UL)
					{
						action();
					}
				}
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003F64 File Offset: 0x00002164
		public static void Times(this int n, Action<int> action)
		{
			bool flag = n <= 0;
			if (!flag)
			{
				bool flag2 = action == null;
				if (!flag2)
				{
					for (int i = 0; i < n; i++)
					{
						action(i);
					}
				}
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003FA4 File Offset: 0x000021A4
		public static void Times(this long n, Action<long> action)
		{
			bool flag = n <= 0L;
			if (!flag)
			{
				bool flag2 = action == null;
				if (!flag2)
				{
					for (long num = 0L; num < n; num += 1L)
					{
						action(num);
					}
				}
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00003FE4 File Offset: 0x000021E4
		public static void Times(this uint n, Action<uint> action)
		{
			bool flag = n == 0U;
			if (!flag)
			{
				bool flag2 = action == null;
				if (!flag2)
				{
					for (uint num = 0U; num < n; num += 1U)
					{
						action(num);
					}
				}
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00004020 File Offset: 0x00002220
		public static void Times(this ulong n, Action<ulong> action)
		{
			bool flag = n == 0UL;
			if (!flag)
			{
				bool flag2 = action == null;
				if (!flag2)
				{
					for (ulong num = 0UL; num < n; num += 1UL)
					{
						action(num);
					}
				}
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00004060 File Offset: 0x00002260
		[Obsolete("This method will be removed.")]
		public static T To<T>(this byte[] source, ByteOrder sourceOrder) where T : struct
		{
			bool flag = source == null;
			if (flag)
			{
				throw new ArgumentNullException("source");
			}
			bool flag2 = source.Length == 0;
			T result;
			if (flag2)
			{
				result = default(T);
			}
			else
			{
				Type typeFromHandle = typeof(T);
				byte[] value = source.ToHostOrder(sourceOrder);
				result = ((typeFromHandle == typeof(bool)) ? ((T)((object)BitConverter.ToBoolean(value, 0))) : ((typeFromHandle == typeof(char)) ? ((T)((object)BitConverter.ToChar(value, 0))) : ((typeFromHandle == typeof(double)) ? ((T)((object)BitConverter.ToDouble(value, 0))) : ((typeFromHandle == typeof(short)) ? ((T)((object)BitConverter.ToInt16(value, 0))) : ((typeFromHandle == typeof(int)) ? ((T)((object)BitConverter.ToInt32(value, 0))) : ((typeFromHandle == typeof(long)) ? ((T)((object)BitConverter.ToInt64(value, 0))) : ((typeFromHandle == typeof(float)) ? ((T)((object)BitConverter.ToSingle(value, 0))) : ((typeFromHandle == typeof(ushort)) ? ((T)((object)BitConverter.ToUInt16(value, 0))) : ((typeFromHandle == typeof(uint)) ? ((T)((object)BitConverter.ToUInt32(value, 0))) : ((typeFromHandle == typeof(ulong)) ? ((T)((object)BitConverter.ToUInt64(value, 0))) : default(T)))))))))));
			}
			return result;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00004244 File Offset: 0x00002444
		[Obsolete("This method will be removed.")]
		public static byte[] ToByteArray<T>(this T value, ByteOrder order) where T : struct
		{
			Type typeFromHandle = typeof(T);
			byte[] array;
			if (!(typeFromHandle == typeof(bool)))
			{
				if (!(typeFromHandle == typeof(byte)))
				{
					array = ((typeFromHandle == typeof(char)) ? BitConverter.GetBytes((char)((object)value)) : ((typeFromHandle == typeof(double)) ? BitConverter.GetBytes((double)((object)value)) : ((typeFromHandle == typeof(short)) ? BitConverter.GetBytes((short)((object)value)) : ((typeFromHandle == typeof(int)) ? BitConverter.GetBytes((int)((object)value)) : ((typeFromHandle == typeof(long)) ? BitConverter.GetBytes((long)((object)value)) : ((typeFromHandle == typeof(float)) ? BitConverter.GetBytes((float)((object)value)) : ((typeFromHandle == typeof(ushort)) ? BitConverter.GetBytes((ushort)((object)value)) : ((typeFromHandle == typeof(uint)) ? BitConverter.GetBytes((uint)((object)value)) : ((typeFromHandle == typeof(ulong)) ? BitConverter.GetBytes((ulong)((object)value)) : WebSocket.EmptyBytes)))))))));
				}
				else
				{
					(array = new byte[1])[0] = (byte)((object)value);
				}
			}
			else
			{
				array = BitConverter.GetBytes((bool)((object)value));
			}
			byte[] array2 = array;
			bool flag = array2.Length > 1;
			if (flag)
			{
				bool flag2 = !order.IsHostOrder();
				if (flag2)
				{
					Array.Reverse(array2);
				}
			}
			return array2;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00004430 File Offset: 0x00002630
		public static byte[] ToHostOrder(this byte[] source, ByteOrder sourceOrder)
		{
			bool flag = source == null;
			if (flag)
			{
				throw new ArgumentNullException("source");
			}
			bool flag2 = source.Length < 2;
			byte[] result;
			if (flag2)
			{
				result = source;
			}
			else
			{
				bool flag3 = sourceOrder.IsHostOrder();
				if (flag3)
				{
					result = source;
				}
				else
				{
					result = source.Reverse<byte>();
				}
			}
			return result;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00004478 File Offset: 0x00002678
		public static string ToString<T>(this T[] array, string separator)
		{
			bool flag = array == null;
			if (flag)
			{
				throw new ArgumentNullException("array");
			}
			int num = array.Length;
			bool flag2 = num == 0;
			string result;
			if (flag2)
			{
				result = string.Empty;
			}
			else
			{
				bool flag3 = separator == null;
				if (flag3)
				{
					separator = string.Empty;
				}
				StringBuilder stringBuilder = new StringBuilder(64);
				int num2 = num - 1;
				for (int i = 0; i < num2; i++)
				{
					stringBuilder.AppendFormat("{0}{1}", array[i], separator);
				}
				stringBuilder.Append(array[num2].ToString());
				result = stringBuilder.ToString();
			}
			return result;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00004524 File Offset: 0x00002724
		public static Uri ToUri(this string value)
		{
			Uri result;
			Uri.TryCreate(value, value.MaybeUri() ? UriKind.Absolute : UriKind.Relative, out result);
			return result;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000454C File Offset: 0x0000274C
		[Obsolete("This method will be removed.")]
		public static void WriteContent(this WebSocketSharp.Net.HttpListenerResponse response, byte[] content)
		{
			bool flag = response == null;
			if (flag)
			{
				throw new ArgumentNullException("response");
			}
			bool flag2 = content == null;
			if (flag2)
			{
				throw new ArgumentNullException("content");
			}
			long num = (long)content.Length;
			bool flag3 = num == 0L;
			if (flag3)
			{
				response.Close();
			}
			else
			{
				response.ContentLength64 = num;
				Stream outputStream = response.OutputStream;
				bool flag4 = num <= 2147483647L;
				if (flag4)
				{
					outputStream.Write(content, 0, (int)num);
				}
				else
				{
					outputStream.WriteBytes(content, 1024);
				}
				outputStream.Close();
			}
		}

		// Token: 0x04000001 RID: 1
		private static readonly byte[] _last = new byte[1];

		// Token: 0x04000002 RID: 2
		private static readonly int _retry = 5;

		// Token: 0x04000003 RID: 3
		private const string _tspecials = "()<>@,;:\\\"/[]?={} \t";
	}
}
