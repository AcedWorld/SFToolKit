using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Rewired.Utils
{
	// Token: 0x02000496 RID: 1174
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class NativeTools
	{
		// Token: 0x06002F29 RID: 12073 RVA: 0x0002410F File Offset: 0x0002230F
		public static IntPtr OffsetIntPtr(IntPtr intPtr, int offset)
		{
			if (offset == 0)
			{
				return intPtr;
			}
			if (SystemInfo.is64Bit)
			{
				return new IntPtr(intPtr.ToInt64() + (long)offset);
			}
			return new IntPtr(intPtr.ToInt32() + offset);
		}

		// Token: 0x06002F2A RID: 12074 RVA: 0x000A4040 File Offset: 0x000A2240
		public static bool CopyMemory(IntPtr source, IntPtr destination, int sourceStartIndex, int destinationStartIndex, int bytesToCopy, bool throwOnError = true)
		{
			if (throwOnError)
			{
				if (source == IntPtr.Zero)
				{
					throw new ArgumentNullException("source");
				}
				if (destination == IntPtr.Zero)
				{
					throw new ArgumentNullException("destination");
				}
				if (sourceStartIndex < 0)
				{
					throw new ArgumentOutOfRangeException("sourceStartIndex");
				}
				if (destinationStartIndex < 0)
				{
					throw new ArgumentOutOfRangeException("destinationStartIndex");
				}
				if (bytesToCopy <= 0)
				{
					throw new ArgumentOutOfRangeException("length");
				}
			}
			else
			{
				if (source == IntPtr.Zero || destination == IntPtr.Zero)
				{
					return false;
				}
				if (sourceStartIndex < 0)
				{
					sourceStartIndex = 0;
				}
				if (destinationStartIndex < 0)
				{
					destinationStartIndex = 0;
				}
				if (bytesToCopy <= 0)
				{
					return false;
				}
			}
			bool result;
			try
			{
				int num = bytesToCopy;
				if (num >= 8)
				{
					int num2 = bytesToCopy / 8 * 8;
					for (int i = 0; i < num2; i += 8)
					{
						Marshal.WriteInt64(destination, i + destinationStartIndex, Marshal.ReadInt64(source, i + sourceStartIndex));
					}
					num %= 8;
				}
				if (num >= 4)
				{
					int num3 = bytesToCopy / 4 * 4;
					for (int j = bytesToCopy - num; j < num3; j += 4)
					{
						Marshal.WriteInt32(destination, j + destinationStartIndex, Marshal.ReadInt32(source, j + sourceStartIndex));
					}
					num %= 4;
				}
				if (num >= 2)
				{
					int num4 = bytesToCopy / 2 * 2;
					for (int k = bytesToCopy - num; k < num4; k += 2)
					{
						Marshal.WriteInt16(destination, k + destinationStartIndex, Marshal.ReadInt16(source, k + sourceStartIndex));
					}
					num %= 2;
				}
				for (int l = bytesToCopy - num; l < bytesToCopy; l++)
				{
					Marshal.WriteByte(destination, l + destinationStartIndex, Marshal.ReadByte(source, l + sourceStartIndex));
				}
				result = true;
			}
			catch
			{
				if (throwOnError)
				{
					throw;
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06002F2B RID: 12075 RVA: 0x000A41CC File Offset: 0x000A23CC
		public static bool CopyMemory(byte[] source, IntPtr destination, int sourceStartIndex, int destinationStartIndex, int bytesToCopy, bool throwOnError = true)
		{
			if (throwOnError)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				if (sourceStartIndex < 0 || sourceStartIndex >= source.Length)
				{
					throw new ArgumentOutOfRangeException("sourceStartIndex");
				}
				if (destinationStartIndex < 0)
				{
					throw new ArgumentOutOfRangeException("destinationStartIndex");
				}
				if (bytesToCopy > source.Length - sourceStartIndex)
				{
					throw new Exception("source.Length + souceStartIndex must be >= bytesToCopy");
				}
			}
			else
			{
				if (source == null)
				{
					return false;
				}
				if (sourceStartIndex < 0 || sourceStartIndex >= source.Length)
				{
					return false;
				}
				if (destinationStartIndex < 0)
				{
					return false;
				}
				if (bytesToCopy > source.Length - sourceStartIndex)
				{
					return false;
				}
			}
			bool result;
			try
			{
				if (destinationStartIndex == 0)
				{
					Marshal.Copy(source, sourceStartIndex, destination, bytesToCopy);
				}
				else
				{
					Marshal.Copy(source, sourceStartIndex, NativeTools.OffsetIntPtr(destination, destinationStartIndex), bytesToCopy);
				}
				result = true;
			}
			catch
			{
				if (throwOnError)
				{
					throw;
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06002F2C RID: 12076 RVA: 0x000A4288 File Offset: 0x000A2488
		public static bool CopyMemory(IntPtr source, byte[] destination, int sourceStartIndex, int destinationStartIndex, int bytesToCopy, bool throwOnError = true)
		{
			if (throwOnError)
			{
				if (destination == null)
				{
					throw new ArgumentNullException("destination");
				}
				if (sourceStartIndex < 0)
				{
					throw new ArgumentOutOfRangeException("sourceStartIndex");
				}
				if (destinationStartIndex < 0 || destinationStartIndex >= destination.Length)
				{
					throw new ArgumentOutOfRangeException("destinationStartIndex");
				}
				if (bytesToCopy > destination.Length - destinationStartIndex)
				{
					throw new Exception("destination.Length + destinationStartIndex must be >= bytesToCopy");
				}
			}
			else
			{
				if (destination == null)
				{
					return false;
				}
				if (sourceStartIndex < 0)
				{
					return false;
				}
				if (destinationStartIndex < 0 || destinationStartIndex >= destination.Length)
				{
					return false;
				}
				if (bytesToCopy > destination.Length - destinationStartIndex)
				{
					return false;
				}
			}
			bool result;
			try
			{
				if (sourceStartIndex == 0)
				{
					Marshal.Copy(source, destination, destinationStartIndex, bytesToCopy);
				}
				else
				{
					Marshal.Copy(NativeTools.OffsetIntPtr(source, sourceStartIndex), destination, destinationStartIndex, bytesToCopy);
				}
				result = true;
			}
			catch
			{
				if (throwOnError)
				{
					throw;
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06002F2D RID: 12077 RVA: 0x0002413B File Offset: 0x0002233B
		public static bool FillMemory(IntPtr buffer, int length, byte value, bool throwOnError = true)
		{
			return NativeTools.FillMemory(buffer, 0, length, value, throwOnError);
		}

		// Token: 0x06002F2E RID: 12078 RVA: 0x000A4344 File Offset: 0x000A2544
		public static bool FillMemory(IntPtr buffer, int startIndex, int length, byte value, bool throwOnError = true)
		{
			if (throwOnError)
			{
				if (buffer == IntPtr.Zero)
				{
					throw new ArgumentNullException("buffer");
				}
				if (startIndex < 0)
				{
					throw new ArgumentOutOfRangeException("sourceStartIndex");
				}
				if (length <= 0)
				{
					throw new ArgumentOutOfRangeException("length");
				}
			}
			else
			{
				if (buffer == IntPtr.Zero)
				{
					return false;
				}
				if (startIndex < 0)
				{
					startIndex = 0;
				}
				if (length <= 0)
				{
					return false;
				}
			}
			int num = length;
			if (value != 0)
			{
				if (NativeTools.OrJEdwYnpAGXITGVdQbexcPqiKJi == null)
				{
					NativeTools.OrJEdwYnpAGXITGVdQbexcPqiKJi = new byte[8];
				}
				bool flag = false;
				if (num >= 8)
				{
					byte[] orJEdwYnpAGXITGVdQbexcPqiKJi = NativeTools.OrJEdwYnpAGXITGVdQbexcPqiKJi;
					long val;
					lock (orJEdwYnpAGXITGVdQbexcPqiKJi)
					{
						for (int i = 0; i < 8; i++)
						{
							NativeTools.OrJEdwYnpAGXITGVdQbexcPqiKJi[i] = value;
						}
						flag = true;
						val = BitConverter.ToInt64(NativeTools.OrJEdwYnpAGXITGVdQbexcPqiKJi, 0);
					}
					int num2 = length / 8 * 8;
					for (int j = 0; j < num2; j += 8)
					{
						Marshal.WriteInt64(buffer, j + startIndex, val);
					}
					num %= 8;
				}
				if (num >= 4)
				{
					byte[] orJEdwYnpAGXITGVdQbexcPqiKJi = NativeTools.OrJEdwYnpAGXITGVdQbexcPqiKJi;
					int val2;
					lock (orJEdwYnpAGXITGVdQbexcPqiKJi)
					{
						if (!flag)
						{
							for (int k = 0; k < 4; k++)
							{
								NativeTools.OrJEdwYnpAGXITGVdQbexcPqiKJi[k] = value;
							}
							flag = true;
						}
						val2 = BitConverter.ToInt32(NativeTools.OrJEdwYnpAGXITGVdQbexcPqiKJi, 0);
					}
					int num3 = length / 4 * 4;
					for (int l = length - num; l < num3; l += 4)
					{
						Marshal.WriteInt32(buffer, l + startIndex, val2);
					}
					num %= 4;
				}
				if (num >= 2)
				{
					byte[] orJEdwYnpAGXITGVdQbexcPqiKJi = NativeTools.OrJEdwYnpAGXITGVdQbexcPqiKJi;
					short val3;
					lock (orJEdwYnpAGXITGVdQbexcPqiKJi)
					{
						if (!flag)
						{
							for (int m = 0; m < 2; m++)
							{
								NativeTools.OrJEdwYnpAGXITGVdQbexcPqiKJi[m] = value;
							}
							flag = true;
						}
						val3 = BitConverter.ToInt16(NativeTools.OrJEdwYnpAGXITGVdQbexcPqiKJi, 0);
					}
					int num4 = length / 2 * 2;
					for (int n = length - num; n < num4; n += 2)
					{
						Marshal.WriteInt16(buffer, n + startIndex, val3);
					}
					num %= 2;
				}
			}
			else
			{
				if (num >= 8)
				{
					int num5 = length / 8 * 8;
					for (int num6 = 0; num6 < num5; num6 += 8)
					{
						Marshal.WriteInt64(buffer, num6 + startIndex, 0L);
					}
					num %= 8;
				}
				if (num >= 4)
				{
					int num7 = length / 4 * 4;
					for (int num8 = length - num; num8 < num7; num8 += 4)
					{
						Marshal.WriteInt32(buffer, num8 + startIndex, 0);
					}
					num %= 4;
				}
				if (num >= 2)
				{
					int num9 = length / 2 * 2;
					for (int num10 = length - num; num10 < num9; num10 += 2)
					{
						Marshal.WriteInt16(buffer, num10 + startIndex, 0);
					}
					num %= 2;
				}
			}
			for (int num11 = length - num; num11 < length; num11++)
			{
				Marshal.WriteByte(buffer, num11 + startIndex, value);
			}
			return true;
		}

		// Token: 0x06002F2F RID: 12079 RVA: 0x00024147 File Offset: 0x00022347
		public static bool FillMemory(byte[] buffer, int length, byte value, bool throwOnError = true)
		{
			return NativeTools.FillMemory(buffer, 0, length, value, throwOnError);
		}

		// Token: 0x06002F30 RID: 12080 RVA: 0x000A45FC File Offset: 0x000A27FC
		public static bool FillMemory(byte[] buffer, int startIndex, int length, byte value, bool throwOnError = true)
		{
			if (throwOnError)
			{
				if (buffer == null)
				{
					throw new ArgumentNullException("buffer");
				}
				if (startIndex < 0 || startIndex >= buffer.Length)
				{
					throw new ArgumentOutOfRangeException("startIndex");
				}
				if (length < 0 || length + startIndex > buffer.Length)
				{
					throw new ArgumentOutOfRangeException("length");
				}
			}
			else
			{
				if (buffer == null)
				{
					return false;
				}
				if (startIndex < 0 || startIndex >= buffer.Length)
				{
					return false;
				}
				if (length < 0 || length + startIndex > buffer.Length)
				{
					return false;
				}
			}
			bool flag;
			try
			{
				bool flag2;
				lock (buffer)
				{
					GCHandle gchandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
					flag2 = NativeTools.FillMemory(gchandle.AddrOfPinnedObject(), startIndex, length, value, throwOnError);
					gchandle.Free();
				}
				flag = flag2;
			}
			catch
			{
				if (throwOnError)
				{
					throw;
				}
				flag = false;
			}
			return flag;
		}

		// Token: 0x06002F31 RID: 12081 RVA: 0x000A46CC File Offset: 0x000A28CC
		public static void ZeroFillMemory(IntPtr buffer, int length)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("buffer");
			}
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			int num = length;
			if (num >= 8)
			{
				int num2 = length / 8 * 8;
				for (int i = 0; i < num2; i += 8)
				{
					Marshal.WriteInt64(buffer, i, 0L);
				}
				num %= 8;
			}
			if (num >= 4)
			{
				int num3 = length / 4 * 4;
				for (int j = length - num; j < num3; j += 4)
				{
					Marshal.WriteInt32(buffer, j, 0);
				}
				num %= 4;
			}
			if (num >= 2)
			{
				int num4 = length / 2 * 2;
				for (int k = length - num; k < num4; k += 2)
				{
					Marshal.WriteInt16(buffer, k, 0);
				}
				num %= 2;
			}
			for (int l = length - num; l < length; l++)
			{
				Marshal.WriteByte(buffer, l, 0);
			}
		}

		// Token: 0x06002F32 RID: 12082 RVA: 0x000A4794 File Offset: 0x000A2994
		public static string DumpToString(IntPtr buffer, int length, string stringFormat = "x2")
		{
			if (buffer == IntPtr.Zero)
			{
				return "Invalid buffer!";
			}
			string result;
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < length; i++)
				{
					stringBuilder.Append(Marshal.ReadByte(buffer, i).ToString(stringFormat));
					if (i < length - 1)
					{
						stringBuilder.Append(", ");
					}
				}
				result = stringBuilder.ToString();
			}
			catch
			{
				result = "Exception!";
			}
			return result;
		}

		// Token: 0x06002F33 RID: 12083 RVA: 0x000A4814 File Offset: 0x000A2A14
		public static void FreeHGlobalSafe(ref IntPtr pointer)
		{
			if (pointer == IntPtr.Zero)
			{
				return;
			}
			try
			{
				Marshal.FreeHGlobal(pointer);
			}
			catch
			{
			}
			pointer = IntPtr.Zero;
		}

		// Token: 0x040019BE RID: 6590
		private static byte[] OrJEdwYnpAGXITGVdQbexcPqiKJi;
	}
}
