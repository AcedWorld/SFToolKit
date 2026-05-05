using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityWebSocketSharp.Net;

namespace UnityWebSocketSharp
{
	// Token: 0x02000008 RID: 8
	internal static class Ext
	{
		// Token: 0x0600000B RID: 11 RVA: 0x00002128 File Offset: 0x00000328
		private static byte[] compress(this byte[] data)
		{
			if ((long)data.Length == 0L)
			{
				return data;
			}
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				result = memoryStream.compressToArray();
			}
			return result;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002168 File Offset: 0x00000368
		private static MemoryStream compress(this Stream stream)
		{
			MemoryStream memoryStream = new MemoryStream();
			if (stream.Length == 0L)
			{
				return memoryStream;
			}
			stream.Position = 0L;
			CompressionMode mode = CompressionMode.Compress;
			MemoryStream result;
			using (DeflateStream deflateStream = new DeflateStream(memoryStream, mode, true))
			{
				stream.CopyTo(deflateStream, 1024);
				deflateStream.Close();
				memoryStream.Write(Ext._last, 0, 1);
				memoryStream.Position = 0L;
				result = memoryStream;
			}
			return result;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000021E0 File Offset: 0x000003E0
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

		// Token: 0x0600000E RID: 14 RVA: 0x00002220 File Offset: 0x00000420
		private static byte[] decompress(this byte[] data)
		{
			if ((long)data.Length == 0L)
			{
				return data;
			}
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				result = memoryStream.decompressToArray();
			}
			return result;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002260 File Offset: 0x00000460
		private static MemoryStream decompress(this Stream stream)
		{
			MemoryStream memoryStream = new MemoryStream();
			if (stream.Length == 0L)
			{
				return memoryStream;
			}
			stream.Position = 0L;
			CompressionMode mode = CompressionMode.Decompress;
			MemoryStream result;
			using (DeflateStream deflateStream = new DeflateStream(stream, mode, true))
			{
				deflateStream.CopyTo(memoryStream, 1024);
				memoryStream.Position = 0L;
				result = memoryStream;
			}
			return result;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000022C4 File Offset: 0x000004C4
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

		// Token: 0x06000011 RID: 17 RVA: 0x00002304 File Offset: 0x00000504
		private static bool isPredefinedScheme(this string value)
		{
			char c = value[0];
			if (c == 'h')
			{
				return value == "http" || value == "https";
			}
			if (c == 'w')
			{
				return value == "ws" || value == "wss";
			}
			if (c == 'f')
			{
				return value == "file" || value == "ftp";
			}
			if (c == 'g')
			{
				return value == "gopher";
			}
			if (c == 'm')
			{
				return value == "mailto";
			}
			if (c != 'n')
			{
				return false;
			}
			c = value[1];
			if (c != 'e')
			{
				return value == "nntp";
			}
			return value == "news" || value == "net.pipe" || value == "net.tcp";
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000023E4 File Offset: 0x000005E4
		internal static byte[] Append(this ushort code, string reason)
		{
			byte[] array = code.ToByteArray(ByteOrder.Big);
			if (reason == null || reason.Length == 0)
			{
				return array;
			}
			List<byte> list = new List<byte>(array);
			byte[] bytes = Encoding.UTF8.GetBytes(reason);
			list.AddRange(bytes);
			return list.ToArray();
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002424 File Offset: 0x00000624
		internal static byte[] Compress(this byte[] data, CompressionMethod method)
		{
			if (method != CompressionMethod.Deflate)
			{
				return data;
			}
			return data.compress();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002432 File Offset: 0x00000632
		internal static Stream Compress(this Stream stream, CompressionMethod method)
		{
			if (method != CompressionMethod.Deflate)
			{
				return stream;
			}
			return stream.compress();
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002440 File Offset: 0x00000640
		internal static bool Contains(this string value, params char[] anyOf)
		{
			return anyOf != null && anyOf.Length != 0 && value.IndexOfAny(anyOf) > -1;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002455 File Offset: 0x00000655
		internal static bool Contains(this NameValueCollection collection, string name)
		{
			return collection[name] != null;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002464 File Offset: 0x00000664
		internal static bool Contains(this NameValueCollection collection, string name, string value, StringComparison comparisonTypeForValue)
		{
			string text = collection[name];
			if (text == null)
			{
				return false;
			}
			string[] array = text.Split(',', StringSplitOptions.None);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Trim().Equals(value, comparisonTypeForValue))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000024AC File Offset: 0x000006AC
		internal static bool Contains<T>(this IEnumerable<T> source, Func<T, bool> condition)
		{
			foreach (T arg in source)
			{
				if (condition(arg))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002500 File Offset: 0x00000700
		internal static bool ContainsTwice(this string[] values)
		{
			int len = values.Length;
			len--;
			Func<int, bool> seek = null;
			int end;
			seek = delegate(int idx)
			{
				if (idx == end)
				{
					return false;
				}
				string b = values[idx];
				for (int i = idx + 1; i < len; i++)
				{
					if (values[i] == b)
					{
						return true;
					}
				}
				return seek(++idx);
			};
			return seek(0);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000255C File Offset: 0x0000075C
		internal static T[] Copy<T>(this T[] sourceArray, int length)
		{
			T[] array = new T[length];
			Array.Copy(sourceArray, 0, array, 0, length);
			return array;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000257C File Offset: 0x0000077C
		internal static T[] Copy<T>(this T[] sourceArray, long length)
		{
			T[] array = new T[length];
			Array.Copy(sourceArray, 0L, array, 0L, length);
			return array;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000025A0 File Offset: 0x000007A0
		internal static void CopyTo(this Stream sourceStream, Stream destinationStream, int bufferLength)
		{
			byte[] buffer = new byte[bufferLength];
			for (;;)
			{
				int num = sourceStream.Read(buffer, 0, bufferLength);
				if (num <= 0)
				{
					break;
				}
				destinationStream.Write(buffer, 0, num);
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000025D0 File Offset: 0x000007D0
		internal static void CopyToAsync(this Stream sourceStream, Stream destinationStream, int bufferLength, Action completed, Action<Exception> error)
		{
			byte[] buff = new byte[bufferLength];
			AsyncCallback callback = null;
			callback = delegate(IAsyncResult ar)
			{
				try
				{
					int num = sourceStream.EndRead(ar);
					if (num <= 0)
					{
						if (completed != null)
						{
							completed();
						}
					}
					else
					{
						destinationStream.Write(buff, 0, num);
						sourceStream.BeginRead(buff, 0, bufferLength, callback, null);
					}
				}
				catch (Exception obj2)
				{
					if (error != null)
					{
						error(obj2);
					}
				}
			};
			try
			{
				sourceStream.BeginRead(buff, 0, bufferLength, callback, null);
			}
			catch (Exception obj)
			{
				if (error != null)
				{
					error(obj);
				}
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000267C File Offset: 0x0000087C
		internal static byte[] Decompress(this byte[] data, CompressionMethod method)
		{
			if (method != CompressionMethod.Deflate)
			{
				return data;
			}
			return data.decompress();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000268A File Offset: 0x0000088A
		internal static Stream Decompress(this Stream stream, CompressionMethod method)
		{
			if (method != CompressionMethod.Deflate)
			{
				return stream;
			}
			return stream.decompress();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002698 File Offset: 0x00000898
		internal static byte[] DecompressToArray(this Stream stream, CompressionMethod method)
		{
			if (method != CompressionMethod.Deflate)
			{
				return stream.ToByteArray();
			}
			return stream.decompressToArray();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000026AB File Offset: 0x000008AB
		internal static void Emit(this EventHandler eventHandler, object sender, EventArgs e)
		{
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(sender, e);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000026B9 File Offset: 0x000008B9
		internal static void Emit<TEventArgs>(this EventHandler<TEventArgs> eventHandler, object sender, TEventArgs e) where TEventArgs : EventArgs
		{
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(sender, e);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000026C8 File Offset: 0x000008C8
		internal static string GetAbsolutePath(this Uri uri)
		{
			if (uri.IsAbsoluteUri)
			{
				return uri.AbsolutePath;
			}
			string originalString = uri.OriginalString;
			if (originalString[0] != '/')
			{
				return null;
			}
			int num = originalString.IndexOfAny(new char[]
			{
				'?',
				'#'
			});
			if (num <= 0)
			{
				return originalString;
			}
			return originalString.Substring(0, num);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002720 File Offset: 0x00000920
		internal static CookieCollection GetCookies(this NameValueCollection headers, bool response)
		{
			string text = headers[response ? "Set-Cookie" : "Cookie"];
			if (text == null)
			{
				return new CookieCollection();
			}
			return CookieCollection.Parse(text, response);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002753 File Offset: 0x00000953
		internal static string GetDnsSafeHost(this Uri uri, bool bracketIPv6)
		{
			if (!bracketIPv6 || uri.HostNameType != UriHostNameType.IPv6)
			{
				return uri.DnsSafeHost;
			}
			return uri.Host;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002770 File Offset: 0x00000970
		internal static string GetErrorMessage(this ushort code)
		{
			switch (code)
			{
			case 1002:
				return "A protocol error has occurred.";
			case 1003:
				return "Unsupported data has been received.";
			case 1006:
				return "An abnormal error has occurred.";
			case 1007:
				return "Invalid data has been received.";
			case 1008:
				return "A policy violation has occurred.";
			case 1009:
				return "A too big message has been received.";
			case 1010:
				return "The client did not receive expected extension(s).";
			case 1011:
				return "The server got an internal error.";
			case 1015:
				return "An error has occurred during a TLS handshake.";
			}
			return string.Empty;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000027FE File Offset: 0x000009FE
		internal static string GetErrorMessage(this CloseStatusCode code)
		{
			return ((ushort)code).GetErrorMessage();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002808 File Offset: 0x00000A08
		internal static string GetName(this string nameAndValue, char separator)
		{
			int num = nameAndValue.IndexOf(separator);
			if (num <= 0)
			{
				return null;
			}
			return nameAndValue.Substring(0, num).Trim();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002830 File Offset: 0x00000A30
		internal static string GetUTF8DecodedString(this byte[] bytes)
		{
			string result;
			try
			{
				result = Encoding.UTF8.GetString(bytes);
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002864 File Offset: 0x00000A64
		internal static byte[] GetUTF8EncodedBytes(this string s)
		{
			byte[] result;
			try
			{
				result = Encoding.UTF8.GetBytes(s);
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002898 File Offset: 0x00000A98
		internal static string GetValue(this string nameAndValue, char separator)
		{
			return nameAndValue.GetValue(separator, false);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000028A4 File Offset: 0x00000AA4
		internal static string GetValue(this string nameAndValue, char separator, bool unquote)
		{
			int num = nameAndValue.IndexOf(separator);
			if (num < 0 || num == nameAndValue.Length - 1)
			{
				return null;
			}
			string text = nameAndValue.Substring(num + 1).Trim();
			if (!unquote)
			{
				return text;
			}
			return text.Unquote();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000028E4 File Offset: 0x00000AE4
		internal static bool IsCompressionExtension(this string value, CompressionMethod method)
		{
			string value2 = method.ToExtensionString(Array.Empty<string>());
			StringComparison comparisonType = StringComparison.Ordinal;
			return value.StartsWith(value2, comparisonType);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002907 File Offset: 0x00000B07
		internal static bool IsEqualTo(this int value, char c, Action<int> beforeComparing)
		{
			beforeComparing(value);
			return value == (int)c;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002914 File Offset: 0x00000B14
		internal static bool IsHttpMethod(this string value)
		{
			return value == "GET" || value == "HEAD" || value == "POST" || value == "PUT" || value == "DELETE" || value == "CONNECT" || value == "OPTIONS" || value == "TRACE";
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002989 File Offset: 0x00000B89
		internal static bool IsPortNumber(this int value)
		{
			return value > 0 && value < 65536;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002999 File Offset: 0x00000B99
		internal static bool IsReserved(this CloseStatusCode code)
		{
			return ((ushort)code).IsReservedStatusCode();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000029A1 File Offset: 0x00000BA1
		internal static bool IsReservedStatusCode(this ushort code)
		{
			return code == 1004 || code == 1005 || code == 1006 || code == 1015;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000029C5 File Offset: 0x00000BC5
		internal static bool IsSupportedOpcode(this byte opcode)
		{
			return Enum.IsDefined(typeof(Opcode), opcode);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000029DC File Offset: 0x00000BDC
		internal static bool IsText(this string value)
		{
			int length = value.Length;
			for (int i = 0; i < length; i++)
			{
				char c = value[i];
				if (c < ' ')
				{
					if ("\r\n\t".IndexOf(c) == -1)
					{
						return false;
					}
					if (c == '\n')
					{
						i++;
						if (i == length)
						{
							break;
						}
						c = value[i];
						if (" \t".IndexOf(c) == -1)
						{
							return false;
						}
					}
				}
				else if (c == '\u007f')
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002A48 File Offset: 0x00000C48
		internal static bool IsToken(this string value)
		{
			foreach (char c in value)
			{
				if (c < ' ')
				{
					return false;
				}
				if (c > '~')
				{
					return false;
				}
				if ("()<>@,;:\\\"/[]?={} \t".IndexOf(c) > -1)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002A90 File Offset: 0x00000C90
		internal static bool KeepsAlive(this NameValueCollection headers, Version version)
		{
			StringComparison comparisonTypeForValue = StringComparison.OrdinalIgnoreCase;
			if (!(version < HttpVersion.Version11))
			{
				return !headers.Contains("Connection", "close", comparisonTypeForValue);
			}
			return headers.Contains("Connection", "keep-alive", comparisonTypeForValue);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002AD4 File Offset: 0x00000CD4
		internal static bool MaybeUri(this string value)
		{
			int num = value.IndexOf(':');
			return num >= 2 && num <= 9 && value.Substring(0, num).isPredefinedScheme();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002B04 File Offset: 0x00000D04
		internal static string Quote(this string value)
		{
			string format = "\"{0}\"";
			string arg = value.Replace("\"", "\\\"");
			return string.Format(format, arg);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002B30 File Offset: 0x00000D30
		internal static byte[] ReadBytes(this Stream stream, int length)
		{
			byte[] array = new byte[length];
			int num = 0;
			int num2 = 0;
			while (length > 0)
			{
				int num3 = stream.Read(array, num, length);
				if (num3 <= 0)
				{
					if (num2 >= Ext._maxRetry)
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

		// Token: 0x0600003A RID: 58 RVA: 0x00002B80 File Offset: 0x00000D80
		internal static byte[] ReadBytes(this Stream stream, long length, int bufferLength)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				byte[] buffer = new byte[bufferLength];
				int num = 0;
				while (length > 0L)
				{
					if (length < (long)bufferLength)
					{
						bufferLength = (int)length;
					}
					int num2 = stream.Read(buffer, 0, bufferLength);
					if (num2 <= 0)
					{
						if (num >= Ext._maxRetry)
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

		// Token: 0x0600003B RID: 59 RVA: 0x00002C08 File Offset: 0x00000E08
		internal static void ReadBytesAsync(this Stream stream, int length, Action<byte[]> completed, Action<Exception> error)
		{
			byte[] ret = new byte[length];
			int offset = 0;
			int retry = 0;
			AsyncCallback callback = null;
			callback = delegate(IAsyncResult ar)
			{
				try
				{
					int num = stream.EndRead(ar);
					if (num <= 0)
					{
						int retry;
						if (retry < Ext._maxRetry)
						{
							retry = retry;
							retry++;
							stream.BeginRead(ret, offset, length, callback, null);
						}
						else if (completed != null)
						{
							completed(ret.SubArray(0, offset));
						}
					}
					else if (num == length)
					{
						if (completed != null)
						{
							completed(ret);
						}
					}
					else
					{
						int retry = 0;
						offset += num;
						length -= num;
						stream.BeginRead(ret, offset, length, callback, null);
					}
				}
				catch (Exception obj2)
				{
					if (error != null)
					{
						error(obj2);
					}
				}
			};
			try
			{
				stream.BeginRead(ret, offset, length, callback, null);
			}
			catch (Exception obj)
			{
				if (error != null)
				{
					error(obj);
				}
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002CC0 File Offset: 0x00000EC0
		internal static void ReadBytesAsync(this Stream stream, long length, int bufferLength, Action<byte[]> completed, Action<Exception> error)
		{
			MemoryStream dest = new MemoryStream();
			byte[] buff = new byte[bufferLength];
			int retry = 0;
			Action<long> read = null;
			read = delegate(long len)
			{
				if (len < (long)bufferLength)
				{
					bufferLength = (int)len;
				}
				stream.BeginRead(buff, 0, bufferLength, delegate(IAsyncResult ar)
				{
					try
					{
						int num = stream.EndRead(ar);
						if (num <= 0)
						{
							int retry;
							if (retry < Ext._maxRetry)
							{
								retry = retry;
								retry++;
								read(len);
							}
							else
							{
								if (completed != null)
								{
									dest.Close();
									byte[] obj2 = dest.ToArray();
									completed(obj2);
								}
								dest.Dispose();
							}
						}
						else
						{
							dest.Write(buff, 0, num);
							if ((long)num == len)
							{
								if (completed != null)
								{
									dest.Close();
									byte[] obj3 = dest.ToArray();
									completed(obj3);
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
					catch (Exception obj4)
					{
						dest.Dispose();
						if (error != null)
						{
							error(obj4);
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
				if (error != null)
				{
					error(obj);
				}
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002D6C File Offset: 0x00000F6C
		internal static T[] Reverse<T>(this T[] array)
		{
			long num = (long)array.Length;
			T[] array2 = new T[num];
			long num2 = num - 1L;
			for (long num3 = 0L; num3 <= num2; num3 += 1L)
			{
				checked
				{
					array2[(int)((IntPtr)num3)] = array[(int)((IntPtr)(unchecked(num2 - num3)))];
				}
			}
			return array2;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002DA9 File Offset: 0x00000FA9
		internal static IEnumerable<string> SplitHeaderValue(this string value, params char[] separators)
		{
			int length = value.Length;
			int end = length - 1;
			StringBuilder buff = new StringBuilder(32);
			bool escaped = false;
			bool quoted = false;
			int num;
			for (int i = 0; i <= end; i = num + 1)
			{
				char c = value[i];
				buff.Append(c);
				if (c == '"')
				{
					if (escaped)
					{
						escaped = false;
					}
					else
					{
						quoted = !quoted;
					}
				}
				else if (c == '\\')
				{
					if (i == end)
					{
						break;
					}
					if (value[i + 1] == '"')
					{
						escaped = true;
					}
				}
				else if (Array.IndexOf<char>(separators, c) > -1 && !quoted)
				{
					buff.Length--;
					yield return buff.ToString();
					buff.Length = 0;
				}
				num = i;
			}
			yield return buff.ToString();
			yield break;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002DC0 File Offset: 0x00000FC0
		internal static byte[] ToByteArray(this Stream stream)
		{
			stream.Position = 0L;
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				stream.CopyTo(memoryStream, 1024);
				memoryStream.Close();
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002E14 File Offset: 0x00001014
		internal static byte[] ToByteArray(this ushort value, ByteOrder order)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			if (!order.IsHostOrder())
			{
				Array.Reverse<byte>(bytes);
			}
			return bytes;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002E38 File Offset: 0x00001038
		internal static byte[] ToByteArray(this ulong value, ByteOrder order)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			if (!order.IsHostOrder())
			{
				Array.Reverse<byte>(bytes);
			}
			return bytes;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002E5C File Offset: 0x0000105C
		internal static CompressionMethod ToCompressionMethod(this string value)
		{
			foreach (object obj in Enum.GetValues(typeof(CompressionMethod)))
			{
				CompressionMethod compressionMethod = (CompressionMethod)obj;
				if (compressionMethod.ToExtensionString(Array.Empty<string>()) == value)
				{
					return compressionMethod;
				}
			}
			return CompressionMethod.None;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002ED4 File Offset: 0x000010D4
		internal static string ToExtensionString(this CompressionMethod method, params string[] parameters)
		{
			if (method == CompressionMethod.None)
			{
				return string.Empty;
			}
			string arg = method.ToString().ToLower();
			string text = string.Format("permessage-{0}", arg);
			if (parameters == null || parameters.Length == 0)
			{
				return text;
			}
			string arg2 = parameters.ToString("; ");
			return string.Format("{0}; {1}", text, arg2);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002F2A File Offset: 0x0000112A
		internal static int ToInt32(this string numericString)
		{
			return int.Parse(numericString);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002F34 File Offset: 0x00001134
		internal static IPAddress ToIPAddress(this string value)
		{
			if (value == null || value.Length == 0)
			{
				return null;
			}
			IPAddress result;
			if (IPAddress.TryParse(value, out result))
			{
				return result;
			}
			IPAddress result2;
			try
			{
				result2 = Dns.GetHostAddresses(value)[0];
			}
			catch
			{
				result2 = null;
			}
			return result2;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002F7C File Offset: 0x0000117C
		internal static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
		{
			return new List<TSource>(source);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002F84 File Offset: 0x00001184
		internal static string ToString(this IPAddress address, bool bracketIPv6)
		{
			if (!bracketIPv6 || address.AddressFamily != AddressFamily.InterNetworkV6)
			{
				return address.ToString();
			}
			return string.Format("[{0}]", address);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002FA5 File Offset: 0x000011A5
		internal static ushort ToUInt16(this byte[] source, ByteOrder sourceOrder)
		{
			return BitConverter.ToUInt16(source.ToHostOrder(sourceOrder), 0);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002FB4 File Offset: 0x000011B4
		internal static ulong ToUInt64(this byte[] source, ByteOrder sourceOrder)
		{
			return BitConverter.ToUInt64(source.ToHostOrder(sourceOrder), 0);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002FC3 File Offset: 0x000011C3
		internal static Version ToVersion(this string versionString)
		{
			return new Version(versionString);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002FCB File Offset: 0x000011CB
		internal static IEnumerable<string> TrimEach(this IEnumerable<string> source)
		{
			foreach (string text in source)
			{
				yield return text.Trim();
			}
			IEnumerator<string> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002FDC File Offset: 0x000011DC
		internal static string TrimSlashFromEnd(this string value)
		{
			string text = value.TrimEnd('/');
			if (text.Length <= 0)
			{
				return "/";
			}
			return text;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003004 File Offset: 0x00001204
		internal static string TrimSlashOrBackslashFromEnd(this string value)
		{
			string text = value.TrimEnd(new char[]
			{
				'/',
				'\\'
			});
			if (text.Length <= 0)
			{
				return value[0].ToString();
			}
			return text;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003044 File Offset: 0x00001244
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

		// Token: 0x0600004F RID: 79 RVA: 0x00003078 File Offset: 0x00001278
		internal static bool TryCreateWebSocketUri(this string uriString, out Uri result, out string message)
		{
			result = null;
			message = null;
			Uri uri = uriString.ToUri();
			if (uri == null)
			{
				message = "An invalid URI string.";
				return false;
			}
			if (!uri.IsAbsoluteUri)
			{
				message = "A relative URI.";
				return false;
			}
			string scheme = uri.Scheme;
			if (!(scheme == "ws") && !(scheme == "wss"))
			{
				message = "The scheme part is not 'ws' or 'wss'.";
				return false;
			}
			int num = uri.Port;
			if (num == 0)
			{
				message = "The port part is zero.";
				return false;
			}
			if (uri.Fragment.Length > 0)
			{
				message = "It includes the fragment component.";
				return false;
			}
			if (num == -1)
			{
				num = ((scheme == "ws") ? 80 : 443);
				uriString = string.Format("{0}://{1}:{2}{3}", new object[]
				{
					scheme,
					uri.Host,
					num,
					uri.PathAndQuery
				});
				result = new Uri(uriString);
			}
			else
			{
				result = uri;
			}
			return true;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003168 File Offset: 0x00001368
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

		// Token: 0x06000051 RID: 81 RVA: 0x000031A0 File Offset: 0x000013A0
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

		// Token: 0x06000052 RID: 82 RVA: 0x000031D8 File Offset: 0x000013D8
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

		// Token: 0x06000053 RID: 83 RVA: 0x0000320C File Offset: 0x0000140C
		internal static string Unquote(this string value)
		{
			int num = value.IndexOf('"');
			if (num == -1)
			{
				return value;
			}
			int num2 = value.LastIndexOf('"');
			if (num2 == num)
			{
				return value;
			}
			int num3 = num2 - num - 1;
			if (num3 <= 0)
			{
				return string.Empty;
			}
			return value.Substring(num + 1, num3).Replace("\\\"", "\"");
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003260 File Offset: 0x00001460
		internal static bool Upgrades(this NameValueCollection headers, string protocol)
		{
			StringComparison comparisonTypeForValue = StringComparison.OrdinalIgnoreCase;
			return headers.Contains("Upgrade", protocol, comparisonTypeForValue) && headers.Contains("Connection", "Upgrade", comparisonTypeForValue);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003291 File Offset: 0x00001491
		internal static string UrlDecode(this string value, Encoding encoding)
		{
			if (value.IndexOfAny(new char[]
			{
				'%',
				'+'
			}) <= -1)
			{
				return value;
			}
			return HttpUtility.UrlDecode(value, encoding);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000032B5 File Offset: 0x000014B5
		internal static string UrlEncode(this string value, Encoding encoding)
		{
			return HttpUtility.UrlEncode(value, encoding);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000032C0 File Offset: 0x000014C0
		internal static void WriteBytes(this Stream stream, byte[] bytes, int bufferLength)
		{
			using (MemoryStream memoryStream = new MemoryStream(bytes))
			{
				memoryStream.CopyTo(stream, bufferLength);
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000032F8 File Offset: 0x000014F8
		internal static void WriteBytesAsync(this Stream stream, byte[] bytes, int bufferLength, Action completed, Action<Exception> error)
		{
			MemoryStream src = new MemoryStream(bytes);
			src.CopyToAsync(stream, bufferLength, delegate
			{
				if (completed != null)
				{
					completed();
				}
				src.Dispose();
			}, delegate(Exception ex)
			{
				src.Dispose();
				if (error != null)
				{
					error(ex);
				}
			});
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000334B File Offset: 0x0000154B
		public static string GetDescription(this HttpStatusCode code)
		{
			return ((int)code).GetStatusDescription();
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003354 File Offset: 0x00001554
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

		// Token: 0x0600005B RID: 91 RVA: 0x00003595 File Offset: 0x00001795
		public static bool IsCloseStatusCode(this ushort value)
		{
			return value > 999 && value < 5000;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000035AC File Offset: 0x000017AC
		public static bool IsEnclosedIn(this string value, char c)
		{
			if (value == null)
			{
				return false;
			}
			int length = value.Length;
			return length > 1 && value[0] == c && value[length - 1] == c;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000035E3 File Offset: 0x000017E3
		public static bool IsHostOrder(this ByteOrder order)
		{
			return BitConverter.IsLittleEndian == (order == ByteOrder.Little);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000035F0 File Offset: 0x000017F0
		public static bool IsLocal(this IPAddress address)
		{
			if (address == null)
			{
				throw new ArgumentNullException("address");
			}
			if (address.Equals(IPAddress.Any))
			{
				return true;
			}
			if (address.Equals(IPAddress.Loopback))
			{
				return true;
			}
			if (Socket.OSSupportsIPv6)
			{
				if (address.Equals(IPAddress.IPv6Any))
				{
					return true;
				}
				if (address.Equals(IPAddress.IPv6Loopback))
				{
					return true;
				}
			}
			foreach (IPAddress obj in Dns.GetHostAddresses(Dns.GetHostName()))
			{
				if (address.Equals(obj))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003677 File Offset: 0x00001877
		public static bool IsNullOrEmpty(this string value)
		{
			return value == null || value.Length == 0;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003688 File Offset: 0x00001888
		public static T[] SubArray<T>(this T[] array, int startIndex, int length)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			int num = array.Length;
			if (num == 0)
			{
				if (startIndex != 0)
				{
					throw new ArgumentOutOfRangeException("startIndex");
				}
				if (length != 0)
				{
					throw new ArgumentOutOfRangeException("length");
				}
				return array;
			}
			else
			{
				if (startIndex < 0 || startIndex >= num)
				{
					throw new ArgumentOutOfRangeException("startIndex");
				}
				if (length < 0 || length > num - startIndex)
				{
					throw new ArgumentOutOfRangeException("length");
				}
				if (length == 0)
				{
					return new T[0];
				}
				if (length == num)
				{
					return array;
				}
				T[] array2 = new T[length];
				Array.Copy(array, startIndex, array2, 0, length);
				return array2;
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003714 File Offset: 0x00001914
		public static T[] SubArray<T>(this T[] array, long startIndex, long length)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			long num = (long)array.Length;
			if (num == 0L)
			{
				if (startIndex != 0L)
				{
					throw new ArgumentOutOfRangeException("startIndex");
				}
				if (length != 0L)
				{
					throw new ArgumentOutOfRangeException("length");
				}
				return array;
			}
			else
			{
				if (startIndex < 0L || startIndex >= num)
				{
					throw new ArgumentOutOfRangeException("startIndex");
				}
				if (length < 0L || length > num - startIndex)
				{
					throw new ArgumentOutOfRangeException("length");
				}
				if (length == 0L)
				{
					return new T[0];
				}
				if (length == num)
				{
					return array;
				}
				T[] array2 = new T[length];
				Array.Copy(array, startIndex, array2, 0L, length);
				return array2;
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000037A4 File Offset: 0x000019A4
		public static void Times(this int n, Action<int> action)
		{
			if (n <= 0)
			{
				return;
			}
			if (action == null)
			{
				return;
			}
			for (int i = 0; i < n; i++)
			{
				action(i);
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000037D0 File Offset: 0x000019D0
		public static void Times(this long n, Action<long> action)
		{
			if (n <= 0L)
			{
				return;
			}
			if (action == null)
			{
				return;
			}
			for (long num = 0L; num < n; num += 1L)
			{
				action(num);
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000037FC File Offset: 0x000019FC
		public static byte[] ToHostOrder(this byte[] source, ByteOrder sourceOrder)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (source.Length < 2)
			{
				return source;
			}
			if (sourceOrder.IsHostOrder())
			{
				return source;
			}
			return source.Reverse<byte>();
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003824 File Offset: 0x00001A24
		public static string ToString<T>(this T[] array, string separator)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			int num = array.Length;
			if (num == 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder(64);
			int num2 = num - 1;
			for (int i = 0; i < num2; i++)
			{
				stringBuilder.AppendFormat("{0}{1}", array[i], separator);
			}
			stringBuilder.AppendFormat("{0}", array[num2]);
			return stringBuilder.ToString();
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000389C File Offset: 0x00001A9C
		public static Uri ToUri(this string value)
		{
			if (value == null || value.Length == 0)
			{
				return null;
			}
			UriKind uriKind = value.MaybeUri() ? UriKind.Absolute : UriKind.Relative;
			Uri result;
			Uri.TryCreate(value, uriKind, out result);
			return result;
		}

		// Token: 0x04000019 RID: 25
		private static readonly byte[] _last = new byte[1];

		// Token: 0x0400001A RID: 26
		private static readonly int _maxRetry = 5;

		// Token: 0x0400001B RID: 27
		private const string _tspecials = "()<>@,;:\\\"/[]?={} \t";
	}
}
