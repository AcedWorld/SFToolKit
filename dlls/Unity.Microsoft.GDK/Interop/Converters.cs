using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001B8 RID: 440
	public static class Converters
	{
		// Token: 0x06000A49 RID: 2633 RVA: 0x0000F725 File Offset: 0x0000D925
		public static IntPtr Offset(this IntPtr ptr, long that)
		{
			return new IntPtr(ptr.ToInt64() + that);
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x0000F735 File Offset: 0x0000D935
		public static int GetSizeRequiredToEncodeStringToUTF8(string str)
		{
			return Encoding.UTF8.GetByteCount(str) + Encoding.UTF8.GetPreamble().Length;
		}

		// Token: 0x06000A4B RID: 2635 RVA: 0x0000F750 File Offset: 0x0000D950
		public static DisposableBuffer StringArrayToUTF8StringArray(string[] strings)
		{
			if (strings == null)
			{
				return new DisposableBuffer();
			}
			List<byte[]> list = new List<byte[]>(strings.Length);
			int num = 0;
			for (int i = 0; i < strings.Length; i++)
			{
				byte[] array = Converters.StringToNullTerminatedUTF8ByteArray(strings[i]);
				list.Add(array);
				checked
				{
					if (array != null)
					{
						num += array.Length;
					}
				}
			}
			int num2 = Marshal.SizeOf(typeof(IntPtr));
			int num3;
			DisposableBuffer disposableBuffer;
			IntPtr ptr;
			checked
			{
				num3 = num2 * strings.Length;
				num += num3;
				disposableBuffer = new DisposableBuffer(num);
				ptr = disposableBuffer.IntPtr;
			}
			IntPtr intPtr = ptr.Offset((long)num3);
			foreach (byte[] array2 in list)
			{
				if (array2 != null)
				{
					Marshal.WriteIntPtr(ptr, intPtr);
					Marshal.Copy(array2, 0, intPtr, array2.Length);
					intPtr = intPtr.Offset((long)array2.Length);
				}
				else
				{
					Marshal.WriteIntPtr(ptr, IntPtr.Zero);
				}
				ptr = ptr.Offset((long)num2);
			}
			return disposableBuffer;
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x0000F85C File Offset: 0x0000DA5C
		public static IntPtr StringArrayToUTF8StringArray(string[] strings, DisposableCollection disposableCollection, out SizeT count)
		{
			if (strings == null)
			{
				count = new SizeT(0);
				return IntPtr.Zero;
			}
			count = new SizeT(strings.Length);
			return disposableCollection.Add<DisposableBuffer>(Converters.StringArrayToUTF8StringArray(strings)).IntPtr;
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x0000F892 File Offset: 0x0000DA92
		public static byte[] StringToNullTerminatedUTF8ByteArray(string str)
		{
			return Converters.StringToNullTerminatedUTF8ByteArrayInternal(str, -1);
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x0000F89B File Offset: 0x0000DA9B
		public static byte[] StringToNullTerminatedUTF8ByteArray(string str, int requiredByteArrayLength)
		{
			return Converters.StringToNullTerminatedUTF8ByteArrayInternal(str, requiredByteArrayLength);
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x0000F8A4 File Offset: 0x0000DAA4
		private static byte[] StringToNullTerminatedUTF8ByteArrayInternal(string str, int requiredByteArrayLength)
		{
			if (str == null)
			{
				return null;
			}
			if (requiredByteArrayLength == -1)
			{
				return Encoding.UTF8.GetBytes(str + "\0");
			}
			byte[] array = new byte[requiredByteArrayLength];
			Encoding.UTF8.GetBytes(str + "\0", 0, str.Length + 1, array, 0);
			return array;
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x0000F8F9 File Offset: 0x0000DAF9
		public unsafe static void StringToNullTerminatedUTF8FixedPointer(string str, byte* bytePointer, int length)
		{
			Marshal.Copy(Converters.StringToNullTerminatedUTF8ByteArray(str, length), 0, (IntPtr)((void*)bytePointer), length);
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x0000F910 File Offset: 0x0000DB10
		public unsafe static string BytePointerToString(byte* bytePointer, int length)
		{
			byte[] array = new byte[length];
			Marshal.Copy((IntPtr)((void*)bytePointer), array, 0, length);
			return Converters.ByteArrayToString(array);
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x0000F938 File Offset: 0x0000DB38
		public unsafe static string NullTerminatedBytePointerToString(byte* bytePointer)
		{
			int num = 0;
			byte* ptr = bytePointer;
			while (*ptr != 0)
			{
				ptr++;
				num++;
			}
			return Converters.BytePointerToString(bytePointer, num);
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x0000F960 File Offset: 0x0000DB60
		public static string ByteArrayToString(byte[] arr)
		{
			string @string = Encoding.UTF8.GetString(arr);
			int num = @string.IndexOf('\0');
			if (num < 0)
			{
				return @string;
			}
			return @string.Substring(0, num);
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x0000F98F File Offset: 0x0000DB8F
		public static string ByteArrayToString(byte[] arr, int index, int count)
		{
			return Encoding.UTF8.GetString(arr, index, count).TrimEnd(new char[1]);
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x0000F9AC File Offset: 0x0000DBAC
		public static string PtrToStringUTF8(IntPtr rawPtr)
		{
			if (rawPtr == IntPtr.Zero)
			{
				return null;
			}
			List<byte> list = new List<byte>();
			for (;;)
			{
				byte b = Marshal.ReadByte(rawPtr);
				if (b == 0)
				{
					break;
				}
				list.Add(b);
				rawPtr = rawPtr.Offset(1L);
			}
			return Encoding.UTF8.GetString(list.ToArray());
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x0000F9FC File Offset: 0x0000DBFC
		public static ClassType PtrToClass<ClassType, InteropStructType>(IntPtr rawPtr, Func<InteropStructType, ClassType> ctor) where ClassType : class where InteropStructType : struct
		{
			if (rawPtr == IntPtr.Zero)
			{
				return default(ClassType);
			}
			return ctor((InteropStructType)((object)Marshal.PtrToStructure(rawPtr, typeof(InteropStructType))));
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x0000FA3B File Offset: 0x0000DC3B
		public static ClassType[] PtrToClassArray<ClassType, InteropStructType>(IntPtr rawPtr, SizeT count, Func<InteropStructType, ClassType> ctor)
		{
			return Converters.PtrToClassArray<ClassType, InteropStructType>(rawPtr, count.ToUInt32(), ctor);
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x0000FA4C File Offset: 0x0000DC4C
		public static ClassType[] PtrToClassArray<ClassType, InteropStructType>(IntPtr rawPtr, uint count, Func<InteropStructType, ClassType> ctor)
		{
			ClassType[] array = new ClassType[count];
			if (IntPtr.Zero != rawPtr)
			{
				int num = Marshal.SizeOf(typeof(InteropStructType));
				int num2 = 0;
				while ((long)num2 < (long)((ulong)count))
				{
					InteropStructType arg = (InteropStructType)((object)Marshal.PtrToStructure(rawPtr.Offset((long)(num2 * num)), typeof(InteropStructType)));
					array[num2] = ctor(arg);
					num2++;
				}
			}
			return array;
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x0000FAC0 File Offset: 0x0000DCC0
		public static IntPtr ClassArrayToPtr<ClassType, InteropStructType>(ClassType[] inputTypes, Func<ClassType, DisposableCollection, InteropStructType> converter, DisposableCollection disposableCollection, out SizeT arrayCount)
		{
			if (inputTypes == null)
			{
				arrayCount = new SizeT(0);
				return IntPtr.Zero;
			}
			bool isEnum = typeof(InteropStructType).IsEnum;
			int num = Marshal.SizeOf(isEnum ? Enum.GetUnderlyingType(typeof(InteropStructType)) : typeof(InteropStructType));
			DisposableBuffer disposableBuffer = disposableCollection.Add<DisposableBuffer>(new DisposableBuffer(checked(num * inputTypes.Length)));
			IntPtr ptr = disposableBuffer.IntPtr;
			foreach (ClassType arg in inputTypes)
			{
				Marshal.StructureToPtr(isEnum ? Convert.ChangeType(converter(arg, disposableCollection), Enum.GetUnderlyingType(typeof(InteropStructType))) : converter(arg, disposableCollection), ptr, false);
				ptr = ptr.Offset((long)num);
			}
			arrayCount = new SizeT(inputTypes.Length);
			return disposableBuffer.IntPtr;
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x0000FBA8 File Offset: 0x0000DDA8
		public static InteropStructType[] ConvertArrayToFixedLength<ClassType, InteropStructType>(ClassType[] classes, int length, Func<ClassType, InteropStructType> ctor)
		{
			InteropStructType[] array = new InteropStructType[length];
			int num = Math.Min(length, classes.Length);
			for (int i = 0; i < num; i++)
			{
				array[i] = ctor(classes[i]);
			}
			return array;
		}
	}
}
