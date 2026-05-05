using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils
{
	// Token: 0x0200048E RID: 1166
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class BitTools
	{
		// Token: 0x06002E39 RID: 11833 RVA: 0x00023728 File Offset: 0x00021928
		public static void GetBytes(short value, byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("bytes");
			}
			if (buffer.Length < 2)
			{
				throw new Exception("bytes.Length must be >= 2.");
			}
			buffer[0] = (byte)value;
			buffer[1] = (byte)(value >> 8);
		}

		// Token: 0x06002E3A RID: 11834 RVA: 0x00023755 File Offset: 0x00021955
		public static void GetBytes(int value, byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("bytes");
			}
			if (buffer.Length < 4)
			{
				throw new Exception("bytes.Length must be >= 4.");
			}
			buffer[0] = (byte)value;
			buffer[1] = (byte)(value >> 8);
			buffer[2] = (byte)(value >> 16);
			buffer[3] = (byte)(value >> 24);
		}

		// Token: 0x06002E3B RID: 11835 RVA: 0x000A1ED0 File Offset: 0x000A00D0
		public static void GetBytes(long value, byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("bytes");
			}
			if (buffer.Length < 8)
			{
				throw new Exception("bytes.Length must be >= 8.");
			}
			buffer[0] = (byte)value;
			buffer[1] = (byte)(value >> 8);
			buffer[2] = (byte)(value >> 16);
			buffer[3] = (byte)(value >> 24);
			buffer[4] = (byte)(value >> 32);
			buffer[5] = (byte)(value >> 40);
			buffer[6] = (byte)(value >> 48);
			buffer[7] = (byte)(value >> 56);
		}

		// Token: 0x17000AEE RID: 2798
		// (get) Token: 0x06002E3C RID: 11836 RVA: 0x00023792 File Offset: 0x00021992
		private static byte[] intToFloatBuffer
		{
			get
			{
				byte[] result;
				if ((result = BitTools.XiNGxmiDMPBJWUlGBYUbVpOrrPtm) == null)
				{
					result = (BitTools.XiNGxmiDMPBJWUlGBYUbVpOrrPtm = new byte[4]);
				}
				return result;
			}
		}

		// Token: 0x06002E3D RID: 11837 RVA: 0x000A1F38 File Offset: 0x000A0138
		public static float IntToFloat(IntPtr pointer, int offset = 0)
		{
			if (pointer == IntPtr.Zero)
			{
				throw new Exception("pointer is null");
			}
			byte[] array = BitTools.intToFloatBuffer;
			byte[] obj = array;
			float result;
			lock (obj)
			{
				Marshal.Copy(pointer, array, offset, 4);
				result = BitConverter.ToSingle(array, 0);
			}
			return result;
		}

		// Token: 0x040019AE RID: 6574
		private static byte[] XiNGxmiDMPBJWUlGBYUbVpOrrPtm;
	}
}
