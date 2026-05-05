using System;

namespace UnityEngine
{
	// Token: 0x0200000F RID: 15
	internal class AndroidJNISafe
	{
		// Token: 0x06000195 RID: 405 RVA: 0x00007C00 File Offset: 0x00005E00
		public static void CheckException()
		{
			IntPtr intPtr = AndroidJNI.ExceptionOccurred();
			bool flag = intPtr != IntPtr.Zero;
			if (flag)
			{
				AndroidJNI.ExceptionClear();
				IntPtr intPtr2 = AndroidJNI.FindClass("java/lang/Throwable");
				IntPtr intPtr3 = AndroidJNI.FindClass("android/util/Log");
				try
				{
					IntPtr methodID = AndroidJNI.GetMethodID(intPtr2, "toString", "()Ljava/lang/String;");
					IntPtr staticMethodID = AndroidJNI.GetStaticMethodID(intPtr3, "getStackTraceString", "(Ljava/lang/Throwable;)Ljava/lang/String;");
					string message = AndroidJNI.CallStringMethod(intPtr, methodID, new jvalue[0]);
					jvalue[] array = new jvalue[1];
					array[0].l = intPtr;
					string javaStackTrace = AndroidJNI.CallStaticStringMethod(intPtr3, staticMethodID, array);
					throw new AndroidJavaException(message, javaStackTrace);
				}
				finally
				{
					AndroidJNISafe.DeleteLocalRef(intPtr);
					AndroidJNISafe.DeleteLocalRef(intPtr2);
					AndroidJNISafe.DeleteLocalRef(intPtr3);
				}
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00007CCC File Offset: 0x00005ECC
		public static void DeleteGlobalRef(IntPtr globalref)
		{
			bool flag = globalref != IntPtr.Zero;
			if (flag)
			{
				AndroidJNI.DeleteGlobalRef(globalref);
			}
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00007CF0 File Offset: 0x00005EF0
		public static void QueueDeleteGlobalRef(IntPtr globalref)
		{
			bool flag = globalref != IntPtr.Zero;
			if (flag)
			{
				AndroidJNI.QueueDeleteGlobalRef(globalref);
			}
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00007D14 File Offset: 0x00005F14
		public static void DeleteWeakGlobalRef(IntPtr globalref)
		{
			bool flag = globalref != IntPtr.Zero;
			if (flag)
			{
				AndroidJNI.DeleteWeakGlobalRef(globalref);
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00007D38 File Offset: 0x00005F38
		public static void DeleteLocalRef(IntPtr localref)
		{
			bool flag = localref != IntPtr.Zero;
			if (flag)
			{
				AndroidJNI.DeleteLocalRef(localref);
			}
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00007D5C File Offset: 0x00005F5C
		public static IntPtr NewString(string chars)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.NewString(chars);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00007D90 File Offset: 0x00005F90
		public static IntPtr NewStringUTF(string bytes)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.NewStringUTF(bytes);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00007DC4 File Offset: 0x00005FC4
		public static string GetStringChars(IntPtr str)
		{
			string stringChars;
			try
			{
				stringChars = AndroidJNI.GetStringChars(str);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return stringChars;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00007DF8 File Offset: 0x00005FF8
		public static string GetStringUTFChars(IntPtr str)
		{
			string stringUTFChars;
			try
			{
				stringUTFChars = AndroidJNI.GetStringUTFChars(str);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return stringUTFChars;
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00007E2C File Offset: 0x0000602C
		public static IntPtr GetObjectClass(IntPtr ptr)
		{
			IntPtr objectClass;
			try
			{
				objectClass = AndroidJNI.GetObjectClass(ptr);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return objectClass;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00007E60 File Offset: 0x00006060
		public static IntPtr GetStaticMethodID(IntPtr clazz, string name, string sig)
		{
			IntPtr staticMethodID;
			try
			{
				staticMethodID = AndroidJNI.GetStaticMethodID(clazz, name, sig);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return staticMethodID;
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00007E94 File Offset: 0x00006094
		public static IntPtr GetMethodID(IntPtr obj, string name, string sig)
		{
			IntPtr methodID;
			try
			{
				methodID = AndroidJNI.GetMethodID(obj, name, sig);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return methodID;
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00007EC8 File Offset: 0x000060C8
		public static IntPtr GetFieldID(IntPtr clazz, string name, string sig)
		{
			IntPtr fieldID;
			try
			{
				fieldID = AndroidJNI.GetFieldID(clazz, name, sig);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return fieldID;
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00007EFC File Offset: 0x000060FC
		public static IntPtr GetStaticFieldID(IntPtr clazz, string name, string sig)
		{
			IntPtr staticFieldID;
			try
			{
				staticFieldID = AndroidJNI.GetStaticFieldID(clazz, name, sig);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return staticFieldID;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00007F30 File Offset: 0x00006130
		public static IntPtr FromReflectedMethod(IntPtr refMethod)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.FromReflectedMethod(refMethod);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00007F64 File Offset: 0x00006164
		public static IntPtr FromReflectedField(IntPtr refField)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.FromReflectedField(refField);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00007F98 File Offset: 0x00006198
		public static IntPtr FindClass(string name)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.FindClass(name);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00007FCC File Offset: 0x000061CC
		public static IntPtr NewObject(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.NewObject(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00007FEC File Offset: 0x000061EC
		public static IntPtr NewObject(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.NewObject(clazz, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00008020 File Offset: 0x00006220
		public static void SetStaticObjectField(IntPtr clazz, IntPtr fieldID, IntPtr val)
		{
			try
			{
				AndroidJNI.SetStaticObjectField(clazz, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00008054 File Offset: 0x00006254
		public static void SetStaticStringField(IntPtr clazz, IntPtr fieldID, string val)
		{
			try
			{
				AndroidJNI.SetStaticStringField(clazz, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00008088 File Offset: 0x00006288
		public static void SetStaticCharField(IntPtr clazz, IntPtr fieldID, char val)
		{
			try
			{
				AndroidJNI.SetStaticCharField(clazz, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001AB RID: 427 RVA: 0x000080BC File Offset: 0x000062BC
		public static void SetStaticDoubleField(IntPtr clazz, IntPtr fieldID, double val)
		{
			try
			{
				AndroidJNI.SetStaticDoubleField(clazz, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x000080F0 File Offset: 0x000062F0
		public static void SetStaticFloatField(IntPtr clazz, IntPtr fieldID, float val)
		{
			try
			{
				AndroidJNI.SetStaticFloatField(clazz, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00008124 File Offset: 0x00006324
		public static void SetStaticLongField(IntPtr clazz, IntPtr fieldID, long val)
		{
			try
			{
				AndroidJNI.SetStaticLongField(clazz, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00008158 File Offset: 0x00006358
		public static void SetStaticShortField(IntPtr clazz, IntPtr fieldID, short val)
		{
			try
			{
				AndroidJNI.SetStaticShortField(clazz, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0000818C File Offset: 0x0000638C
		public static void SetStaticSByteField(IntPtr clazz, IntPtr fieldID, sbyte val)
		{
			try
			{
				AndroidJNI.SetStaticSByteField(clazz, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x000081C0 File Offset: 0x000063C0
		public static void SetStaticBooleanField(IntPtr clazz, IntPtr fieldID, bool val)
		{
			try
			{
				AndroidJNI.SetStaticBooleanField(clazz, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x000081F4 File Offset: 0x000063F4
		public static void SetStaticIntField(IntPtr clazz, IntPtr fieldID, int val)
		{
			try
			{
				AndroidJNI.SetStaticIntField(clazz, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00008228 File Offset: 0x00006428
		public static IntPtr GetStaticObjectField(IntPtr clazz, IntPtr fieldID)
		{
			IntPtr staticObjectField;
			try
			{
				staticObjectField = AndroidJNI.GetStaticObjectField(clazz, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return staticObjectField;
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000825C File Offset: 0x0000645C
		public static string GetStaticStringField(IntPtr clazz, IntPtr fieldID)
		{
			string staticStringField;
			try
			{
				staticStringField = AndroidJNI.GetStaticStringField(clazz, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return staticStringField;
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00008290 File Offset: 0x00006490
		public static char GetStaticCharField(IntPtr clazz, IntPtr fieldID)
		{
			char staticCharField;
			try
			{
				staticCharField = AndroidJNI.GetStaticCharField(clazz, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return staticCharField;
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x000082C4 File Offset: 0x000064C4
		public static double GetStaticDoubleField(IntPtr clazz, IntPtr fieldID)
		{
			double staticDoubleField;
			try
			{
				staticDoubleField = AndroidJNI.GetStaticDoubleField(clazz, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return staticDoubleField;
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x000082F8 File Offset: 0x000064F8
		public static float GetStaticFloatField(IntPtr clazz, IntPtr fieldID)
		{
			float staticFloatField;
			try
			{
				staticFloatField = AndroidJNI.GetStaticFloatField(clazz, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return staticFloatField;
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0000832C File Offset: 0x0000652C
		public static long GetStaticLongField(IntPtr clazz, IntPtr fieldID)
		{
			long staticLongField;
			try
			{
				staticLongField = AndroidJNI.GetStaticLongField(clazz, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return staticLongField;
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x00008360 File Offset: 0x00006560
		public static short GetStaticShortField(IntPtr clazz, IntPtr fieldID)
		{
			short staticShortField;
			try
			{
				staticShortField = AndroidJNI.GetStaticShortField(clazz, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return staticShortField;
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00008394 File Offset: 0x00006594
		public static sbyte GetStaticSByteField(IntPtr clazz, IntPtr fieldID)
		{
			sbyte staticSByteField;
			try
			{
				staticSByteField = AndroidJNI.GetStaticSByteField(clazz, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return staticSByteField;
		}

		// Token: 0x060001BA RID: 442 RVA: 0x000083C8 File Offset: 0x000065C8
		public static bool GetStaticBooleanField(IntPtr clazz, IntPtr fieldID)
		{
			bool staticBooleanField;
			try
			{
				staticBooleanField = AndroidJNI.GetStaticBooleanField(clazz, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return staticBooleanField;
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000083FC File Offset: 0x000065FC
		public static int GetStaticIntField(IntPtr clazz, IntPtr fieldID)
		{
			int staticIntField;
			try
			{
				staticIntField = AndroidJNI.GetStaticIntField(clazz, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return staticIntField;
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00008430 File Offset: 0x00006630
		public static void CallStaticVoidMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			AndroidJNISafe.CallStaticVoidMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00008444 File Offset: 0x00006644
		public static void CallStaticVoidMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			try
			{
				AndroidJNI.CallStaticVoidMethod(clazz, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00008478 File Offset: 0x00006678
		public static IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallStaticObjectMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00008498 File Offset: 0x00006698
		public static IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.CallStaticObjectMethod(clazz, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x000084CC File Offset: 0x000066CC
		public static string CallStaticStringMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallStaticStringMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x000084EC File Offset: 0x000066EC
		public static string CallStaticStringMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			string result;
			try
			{
				result = AndroidJNI.CallStaticStringMethod(clazz, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00008520 File Offset: 0x00006720
		public static char CallStaticCharMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallStaticCharMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00008540 File Offset: 0x00006740
		public static char CallStaticCharMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			char result;
			try
			{
				result = AndroidJNI.CallStaticCharMethod(clazz, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00008574 File Offset: 0x00006774
		public static double CallStaticDoubleMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallStaticDoubleMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00008594 File Offset: 0x00006794
		public static double CallStaticDoubleMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			double result;
			try
			{
				result = AndroidJNI.CallStaticDoubleMethod(clazz, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x000085C8 File Offset: 0x000067C8
		public static float CallStaticFloatMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallStaticFloatMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x000085E8 File Offset: 0x000067E8
		public static float CallStaticFloatMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			float result;
			try
			{
				result = AndroidJNI.CallStaticFloatMethod(clazz, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0000861C File Offset: 0x0000681C
		public static long CallStaticLongMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallStaticLongMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0000863C File Offset: 0x0000683C
		public static long CallStaticLongMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			long result;
			try
			{
				result = AndroidJNI.CallStaticLongMethod(clazz, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00008670 File Offset: 0x00006870
		public static short CallStaticShortMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallStaticShortMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00008690 File Offset: 0x00006890
		public static short CallStaticShortMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			short result;
			try
			{
				result = AndroidJNI.CallStaticShortMethod(clazz, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001CC RID: 460 RVA: 0x000086C4 File Offset: 0x000068C4
		public static sbyte CallStaticSByteMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallStaticSByteMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001CD RID: 461 RVA: 0x000086E4 File Offset: 0x000068E4
		public static sbyte CallStaticSByteMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			sbyte result;
			try
			{
				result = AndroidJNI.CallStaticSByteMethod(clazz, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00008718 File Offset: 0x00006918
		public static bool CallStaticBooleanMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallStaticBooleanMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00008738 File Offset: 0x00006938
		public static bool CallStaticBooleanMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			bool result;
			try
			{
				result = AndroidJNI.CallStaticBooleanMethod(clazz, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0000876C File Offset: 0x0000696C
		public static int CallStaticIntMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallStaticIntMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000878C File Offset: 0x0000698C
		public static int CallStaticIntMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			int result;
			try
			{
				result = AndroidJNI.CallStaticIntMethod(clazz, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x000087C0 File Offset: 0x000069C0
		public static void SetObjectField(IntPtr obj, IntPtr fieldID, IntPtr val)
		{
			try
			{
				AndroidJNI.SetObjectField(obj, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x000087F4 File Offset: 0x000069F4
		public static void SetStringField(IntPtr obj, IntPtr fieldID, string val)
		{
			try
			{
				AndroidJNI.SetStringField(obj, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00008828 File Offset: 0x00006A28
		public static void SetCharField(IntPtr obj, IntPtr fieldID, char val)
		{
			try
			{
				AndroidJNI.SetCharField(obj, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0000885C File Offset: 0x00006A5C
		public static void SetDoubleField(IntPtr obj, IntPtr fieldID, double val)
		{
			try
			{
				AndroidJNI.SetDoubleField(obj, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00008890 File Offset: 0x00006A90
		public static void SetFloatField(IntPtr obj, IntPtr fieldID, float val)
		{
			try
			{
				AndroidJNI.SetFloatField(obj, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x000088C4 File Offset: 0x00006AC4
		public static void SetLongField(IntPtr obj, IntPtr fieldID, long val)
		{
			try
			{
				AndroidJNI.SetLongField(obj, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x000088F8 File Offset: 0x00006AF8
		public static void SetShortField(IntPtr obj, IntPtr fieldID, short val)
		{
			try
			{
				AndroidJNI.SetShortField(obj, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x0000892C File Offset: 0x00006B2C
		public static void SetSByteField(IntPtr obj, IntPtr fieldID, sbyte val)
		{
			try
			{
				AndroidJNI.SetSByteField(obj, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00008960 File Offset: 0x00006B60
		public static void SetBooleanField(IntPtr obj, IntPtr fieldID, bool val)
		{
			try
			{
				AndroidJNI.SetBooleanField(obj, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00008994 File Offset: 0x00006B94
		public static void SetIntField(IntPtr obj, IntPtr fieldID, int val)
		{
			try
			{
				AndroidJNI.SetIntField(obj, fieldID, val);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001DC RID: 476 RVA: 0x000089C8 File Offset: 0x00006BC8
		public static IntPtr GetObjectField(IntPtr obj, IntPtr fieldID)
		{
			IntPtr objectField;
			try
			{
				objectField = AndroidJNI.GetObjectField(obj, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return objectField;
		}

		// Token: 0x060001DD RID: 477 RVA: 0x000089FC File Offset: 0x00006BFC
		public static string GetStringField(IntPtr obj, IntPtr fieldID)
		{
			string stringField;
			try
			{
				stringField = AndroidJNI.GetStringField(obj, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return stringField;
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00008A30 File Offset: 0x00006C30
		public static char GetCharField(IntPtr obj, IntPtr fieldID)
		{
			char charField;
			try
			{
				charField = AndroidJNI.GetCharField(obj, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return charField;
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00008A64 File Offset: 0x00006C64
		public static double GetDoubleField(IntPtr obj, IntPtr fieldID)
		{
			double doubleField;
			try
			{
				doubleField = AndroidJNI.GetDoubleField(obj, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return doubleField;
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00008A98 File Offset: 0x00006C98
		public static float GetFloatField(IntPtr obj, IntPtr fieldID)
		{
			float floatField;
			try
			{
				floatField = AndroidJNI.GetFloatField(obj, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return floatField;
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00008ACC File Offset: 0x00006CCC
		public static long GetLongField(IntPtr obj, IntPtr fieldID)
		{
			long longField;
			try
			{
				longField = AndroidJNI.GetLongField(obj, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return longField;
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00008B00 File Offset: 0x00006D00
		public static short GetShortField(IntPtr obj, IntPtr fieldID)
		{
			short shortField;
			try
			{
				shortField = AndroidJNI.GetShortField(obj, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return shortField;
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00008B34 File Offset: 0x00006D34
		public static sbyte GetSByteField(IntPtr obj, IntPtr fieldID)
		{
			sbyte sbyteField;
			try
			{
				sbyteField = AndroidJNI.GetSByteField(obj, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return sbyteField;
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00008B68 File Offset: 0x00006D68
		public static bool GetBooleanField(IntPtr obj, IntPtr fieldID)
		{
			bool booleanField;
			try
			{
				booleanField = AndroidJNI.GetBooleanField(obj, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return booleanField;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00008B9C File Offset: 0x00006D9C
		public static int GetIntField(IntPtr obj, IntPtr fieldID)
		{
			int intField;
			try
			{
				intField = AndroidJNI.GetIntField(obj, fieldID);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return intField;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00008BD0 File Offset: 0x00006DD0
		public static void CallVoidMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			AndroidJNISafe.CallVoidMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00008BE4 File Offset: 0x00006DE4
		public static void CallVoidMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			try
			{
				AndroidJNI.CallVoidMethod(obj, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00008C18 File Offset: 0x00006E18
		public static IntPtr CallObjectMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallObjectMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00008C38 File Offset: 0x00006E38
		public static IntPtr CallObjectMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.CallObjectMethod(obj, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00008C6C File Offset: 0x00006E6C
		public static string CallStringMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallStringMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00008C8C File Offset: 0x00006E8C
		public static string CallStringMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			string result;
			try
			{
				result = AndroidJNI.CallStringMethod(obj, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00008CC0 File Offset: 0x00006EC0
		public static char CallCharMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallCharMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00008CE0 File Offset: 0x00006EE0
		public static char CallCharMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			char result;
			try
			{
				result = AndroidJNI.CallCharMethod(obj, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00008D14 File Offset: 0x00006F14
		public static double CallDoubleMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallDoubleMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00008D34 File Offset: 0x00006F34
		public static double CallDoubleMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			double result;
			try
			{
				result = AndroidJNI.CallDoubleMethod(obj, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00008D68 File Offset: 0x00006F68
		public static float CallFloatMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallFloatMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00008D88 File Offset: 0x00006F88
		public static float CallFloatMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			float result;
			try
			{
				result = AndroidJNI.CallFloatMethod(obj, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00008DBC File Offset: 0x00006FBC
		public static long CallLongMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallLongMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00008DDC File Offset: 0x00006FDC
		public static long CallLongMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			long result;
			try
			{
				result = AndroidJNI.CallLongMethod(obj, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00008E10 File Offset: 0x00007010
		public static short CallShortMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallShortMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00008E30 File Offset: 0x00007030
		public static short CallShortMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			short result;
			try
			{
				result = AndroidJNI.CallShortMethod(obj, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00008E64 File Offset: 0x00007064
		public static sbyte CallSByteMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallSByteMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00008E84 File Offset: 0x00007084
		public static sbyte CallSByteMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			sbyte result;
			try
			{
				result = AndroidJNI.CallSByteMethod(obj, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00008EB8 File Offset: 0x000070B8
		public static bool CallBooleanMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallBooleanMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00008ED8 File Offset: 0x000070D8
		public static bool CallBooleanMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			bool result;
			try
			{
				result = AndroidJNI.CallBooleanMethod(obj, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00008F0C File Offset: 0x0000710C
		public static int CallIntMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNISafe.CallIntMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00008F2C File Offset: 0x0000712C
		public static int CallIntMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			int result;
			try
			{
				result = AndroidJNI.CallIntMethod(obj, methodID, args);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00008F60 File Offset: 0x00007160
		public static IntPtr[] FromObjectArray(IntPtr array)
		{
			IntPtr[] result;
			try
			{
				result = AndroidJNI.FromObjectArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00008F94 File Offset: 0x00007194
		public static char[] FromCharArray(IntPtr array)
		{
			char[] result;
			try
			{
				result = AndroidJNI.FromCharArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00008FC8 File Offset: 0x000071C8
		public static double[] FromDoubleArray(IntPtr array)
		{
			double[] result;
			try
			{
				result = AndroidJNI.FromDoubleArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00008FFC File Offset: 0x000071FC
		public static float[] FromFloatArray(IntPtr array)
		{
			float[] result;
			try
			{
				result = AndroidJNI.FromFloatArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00009030 File Offset: 0x00007230
		public static long[] FromLongArray(IntPtr array)
		{
			long[] result;
			try
			{
				result = AndroidJNI.FromLongArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00009064 File Offset: 0x00007264
		public static short[] FromShortArray(IntPtr array)
		{
			short[] result;
			try
			{
				result = AndroidJNI.FromShortArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00009098 File Offset: 0x00007298
		public static byte[] FromByteArray(IntPtr array)
		{
			byte[] result;
			try
			{
				result = AndroidJNI.FromByteArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x06000203 RID: 515 RVA: 0x000090CC File Offset: 0x000072CC
		public static sbyte[] FromSByteArray(IntPtr array)
		{
			sbyte[] result;
			try
			{
				result = AndroidJNI.FromSByteArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00009100 File Offset: 0x00007300
		public static bool[] FromBooleanArray(IntPtr array)
		{
			bool[] result;
			try
			{
				result = AndroidJNI.FromBooleanArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00009134 File Offset: 0x00007334
		public static int[] FromIntArray(IntPtr array)
		{
			int[] result;
			try
			{
				result = AndroidJNI.FromIntArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00009168 File Offset: 0x00007368
		public static IntPtr ToObjectArray(IntPtr[] array)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.ToObjectArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0000919C File Offset: 0x0000739C
		public static IntPtr ToObjectArray(IntPtr[] array, IntPtr type)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.ToObjectArray(array, type);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x06000208 RID: 520 RVA: 0x000091D0 File Offset: 0x000073D0
		public static IntPtr ToCharArray(char[] array)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.ToCharArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00009204 File Offset: 0x00007404
		public static IntPtr ToDoubleArray(double[] array)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.ToDoubleArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00009238 File Offset: 0x00007438
		public static IntPtr ToFloatArray(float[] array)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.ToFloatArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0000926C File Offset: 0x0000746C
		public static IntPtr ToLongArray(long[] array)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.ToLongArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x0600020C RID: 524 RVA: 0x000092A0 File Offset: 0x000074A0
		public static IntPtr ToShortArray(short[] array)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.ToShortArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x000092D4 File Offset: 0x000074D4
		public static IntPtr ToByteArray(byte[] array)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.ToByteArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00009308 File Offset: 0x00007508
		public static IntPtr ToSByteArray(sbyte[] array)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.ToSByteArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000933C File Offset: 0x0000753C
		public static IntPtr ToBooleanArray(bool[] array)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.ToBooleanArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00009370 File Offset: 0x00007570
		public static IntPtr ToIntArray(int[] array)
		{
			IntPtr result;
			try
			{
				result = AndroidJNI.ToIntArray(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return result;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x000093A4 File Offset: 0x000075A4
		public static IntPtr GetObjectArrayElement(IntPtr array, int index)
		{
			IntPtr objectArrayElement;
			try
			{
				objectArrayElement = AndroidJNI.GetObjectArrayElement(array, index);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return objectArrayElement;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x000093D8 File Offset: 0x000075D8
		public static int GetArrayLength(IntPtr array)
		{
			int arrayLength;
			try
			{
				arrayLength = AndroidJNI.GetArrayLength(array);
			}
			finally
			{
				AndroidJNISafe.CheckException();
			}
			return arrayLength;
		}
	}
}
