using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001C4 RID: 452
	public static class InteropHelpers
	{
		// Token: 0x06000A8F RID: 2703 RVA: 0x0000FE5C File Offset: 0x0000E05C
		public static IntPtr MarshalStringUtf8(string str)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(str);
			IntPtr intPtr = Marshal.AllocCoTaskMem(bytes.Length + 1);
			Marshal.Copy(bytes, 0, intPtr, bytes.Length);
			Marshal.WriteByte(intPtr, bytes.Length, 0);
			return intPtr;
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x0000FE98 File Offset: 0x0000E098
		public static U[] MarshalArray<T, U>(IntPtr ptr, uint count, Func<T, U> converter) where T : struct
		{
			IntPtr intPtr = ptr;
			U[] array = new U[count];
			for (uint num = 0U; num < count; num += 1U)
			{
				T arg = (T)((object)Marshal.PtrToStructure(intPtr, typeof(T)));
				array[(int)num] = converter(arg);
				intPtr += Marshal.SizeOf(typeof(T));
			}
			return array;
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x0000FEF8 File Offset: 0x0000E0F8
		public static T[] MarshalArray<T>(IntPtr ptr, uint count) where T : struct
		{
			IntPtr intPtr = ptr;
			T[] array = new T[count];
			for (uint num = 0U; num < count; num += 1U)
			{
				array[(int)num] = (T)((object)Marshal.PtrToStructure(intPtr, typeof(T)));
				intPtr += Marshal.SizeOf(typeof(T));
			}
			return array;
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x0000FF50 File Offset: 0x0000E150
		public static string[] MarshalStringArrayAnsi(IntPtr ptr, uint count)
		{
			IntPtr intPtr = ptr;
			string[] array = new string[count];
			for (uint num = 0U; num < count; num += 1U)
			{
				IntPtr ptr2 = (IntPtr)Marshal.PtrToStructure(intPtr, typeof(IntPtr));
				array[(int)num] = Marshal.PtrToStringAnsi(ptr2);
				intPtr += Marshal.SizeOf(typeof(IntPtr));
			}
			return array;
		}
	}
}
