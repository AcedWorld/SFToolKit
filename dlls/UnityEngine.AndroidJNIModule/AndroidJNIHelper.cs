using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Android;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x0200000D RID: 13
	[UsedByNativeCode]
	[NativeHeader("Modules/AndroidJNI/Public/AndroidJNIBindingsHelpers.h")]
	[StaticAccessor("AndroidJNIBindingsHelpers", StaticAccessorType.DoubleColon)]
	[NativeConditional("PLATFORM_ANDROID")]
	public static class AndroidJNIHelper
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000080 RID: 128
		// (set) Token: 0x06000081 RID: 129
		public static extern bool debug { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06000082 RID: 130 RVA: 0x00006998 File Offset: 0x00004B98
		public static IntPtr GetConstructorID(IntPtr javaClass)
		{
			return AndroidJNIHelper.GetConstructorID(javaClass, "");
		}

		// Token: 0x06000083 RID: 131 RVA: 0x000069B8 File Offset: 0x00004BB8
		public static IntPtr GetConstructorID(IntPtr javaClass, [DefaultValue("")] string signature)
		{
			return _AndroidJNIHelper.GetConstructorID(javaClass, signature);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000069D4 File Offset: 0x00004BD4
		public static IntPtr GetMethodID(IntPtr javaClass, string methodName)
		{
			return AndroidJNIHelper.GetMethodID(javaClass, methodName, "", false);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000069F4 File Offset: 0x00004BF4
		public static IntPtr GetMethodID(IntPtr javaClass, string methodName, [DefaultValue("")] string signature)
		{
			return AndroidJNIHelper.GetMethodID(javaClass, methodName, signature, false);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00006A10 File Offset: 0x00004C10
		public static IntPtr GetMethodID(IntPtr javaClass, string methodName, [DefaultValue("")] string signature, [DefaultValue("false")] bool isStatic)
		{
			return _AndroidJNIHelper.GetMethodID(javaClass, methodName, signature, isStatic);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00006A2C File Offset: 0x00004C2C
		public static IntPtr GetFieldID(IntPtr javaClass, string fieldName)
		{
			return AndroidJNIHelper.GetFieldID(javaClass, fieldName, "", false);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00006A4C File Offset: 0x00004C4C
		public static IntPtr GetFieldID(IntPtr javaClass, string fieldName, [DefaultValue("")] string signature)
		{
			return AndroidJNIHelper.GetFieldID(javaClass, fieldName, signature, false);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00006A68 File Offset: 0x00004C68
		public static IntPtr GetFieldID(IntPtr javaClass, string fieldName, [DefaultValue("")] string signature, [DefaultValue("false")] bool isStatic)
		{
			return _AndroidJNIHelper.GetFieldID(javaClass, fieldName, signature, isStatic);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00006A84 File Offset: 0x00004C84
		public static IntPtr CreateJavaRunnable(AndroidJavaRunnable jrunnable)
		{
			return _AndroidJNIHelper.CreateJavaRunnable(jrunnable);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00006A9C File Offset: 0x00004C9C
		public static IntPtr CreateJavaProxy(AndroidJavaProxy proxy)
		{
			GCHandle value = GCHandle.Alloc(proxy);
			IntPtr result;
			try
			{
				result = _AndroidJNIHelper.CreateJavaProxy(AndroidApp.UnityPlayerRaw, GCHandle.ToIntPtr(value), proxy);
			}
			catch
			{
				value.Free();
				throw;
			}
			return result;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00006AE4 File Offset: 0x00004CE4
		public static IntPtr ConvertToJNIArray(Array array)
		{
			return _AndroidJNIHelper.ConvertToJNIArray(array);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00006AFC File Offset: 0x00004CFC
		public static jvalue[] CreateJNIArgArray(object[] args)
		{
			jvalue[] array = new jvalue[args.Length];
			_AndroidJNIHelper.CreateJNIArgArray(args, array);
			return array;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00006B28 File Offset: 0x00004D28
		public static void CreateJNIArgArray(object[] args, Span<jvalue> jniArgs)
		{
			bool flag = args.Length != jniArgs.Length;
			if (flag)
			{
				throw new ArgumentException(string.Format("Both arrays must be of the same length, but are {0} and {1}", args.Length, jniArgs.Length));
			}
			_AndroidJNIHelper.CreateJNIArgArray(args, jniArgs);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00006B75 File Offset: 0x00004D75
		public static void DeleteJNIArgArray(object[] args, jvalue[] jniArgs)
		{
			_AndroidJNIHelper.DeleteJNIArgArray(args, jniArgs);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00006B85 File Offset: 0x00004D85
		public static void DeleteJNIArgArray(object[] args, Span<jvalue> jniArgs)
		{
			_AndroidJNIHelper.DeleteJNIArgArray(args, jniArgs);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00006B90 File Offset: 0x00004D90
		public static IntPtr GetConstructorID(IntPtr jclass, object[] args)
		{
			return _AndroidJNIHelper.GetConstructorID(jclass, args);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00006BAC File Offset: 0x00004DAC
		public static IntPtr GetMethodID(IntPtr jclass, string methodName, object[] args, bool isStatic)
		{
			return _AndroidJNIHelper.GetMethodID(jclass, methodName, args, isStatic);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00006BC8 File Offset: 0x00004DC8
		public static string GetSignature(object obj)
		{
			return _AndroidJNIHelper.GetSignature(obj);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00006BE0 File Offset: 0x00004DE0
		public static string GetSignature(object[] args)
		{
			return _AndroidJNIHelper.GetSignature(args);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00006BF8 File Offset: 0x00004DF8
		public static ArrayType ConvertFromJNIArray<ArrayType>(IntPtr array)
		{
			return _AndroidJNIHelper.ConvertFromJNIArray<ArrayType>(array);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00006C10 File Offset: 0x00004E10
		public static IntPtr GetMethodID<ReturnType>(IntPtr jclass, string methodName, object[] args, bool isStatic)
		{
			return _AndroidJNIHelper.GetMethodID<ReturnType>(jclass, methodName, args, isStatic);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00006C2C File Offset: 0x00004E2C
		public static IntPtr GetFieldID<FieldType>(IntPtr jclass, string fieldName, bool isStatic)
		{
			return _AndroidJNIHelper.GetFieldID<FieldType>(jclass, fieldName, isStatic);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00006C48 File Offset: 0x00004E48
		public static string GetSignature<ReturnType>(object[] args)
		{
			return _AndroidJNIHelper.GetSignature<ReturnType>(args);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00006C60 File Offset: 0x00004E60
		private unsafe static IntPtr Box(jvalue val, string boxedClass, string signature)
		{
			IntPtr intPtr = AndroidJNISafe.FindClass(boxedClass);
			IntPtr result;
			try
			{
				IntPtr staticMethodID = AndroidJNISafe.GetStaticMethodID(intPtr, "valueOf", signature);
				Span<jvalue> args = new Span<jvalue>((void*)(&val), 1);
				result = AndroidJNISafe.CallStaticObjectMethod(intPtr, staticMethodID, args);
			}
			finally
			{
				AndroidJNISafe.DeleteLocalRef(intPtr);
			}
			return result;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00006CB8 File Offset: 0x00004EB8
		public static IntPtr Box(sbyte value)
		{
			return AndroidJNIHelper.Box(new jvalue
			{
				b = value
			}, "java/lang/Byte", "(B)Ljava/lang/Byte;");
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00006CEC File Offset: 0x00004EEC
		public static IntPtr Box(short value)
		{
			return AndroidJNIHelper.Box(new jvalue
			{
				s = value
			}, "java/lang/Short", "(S)Ljava/lang/Short;");
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00006D20 File Offset: 0x00004F20
		public static IntPtr Box(int value)
		{
			return AndroidJNIHelper.Box(new jvalue
			{
				i = value
			}, "java/lang/Integer", "(I)Ljava/lang/Integer;");
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00006D54 File Offset: 0x00004F54
		public static IntPtr Box(long value)
		{
			return AndroidJNIHelper.Box(new jvalue
			{
				j = value
			}, "java/lang/Long", "(J)Ljava/lang/Long;");
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00006D88 File Offset: 0x00004F88
		public static IntPtr Box(float value)
		{
			return AndroidJNIHelper.Box(new jvalue
			{
				f = value
			}, "java/lang/Float", "(F)Ljava/lang/Float;");
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00006DBC File Offset: 0x00004FBC
		public static IntPtr Box(double value)
		{
			return AndroidJNIHelper.Box(new jvalue
			{
				d = value
			}, "java/lang/Double", "(D)Ljava/lang/Double;");
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00006DF0 File Offset: 0x00004FF0
		public static IntPtr Box(char value)
		{
			return AndroidJNIHelper.Box(new jvalue
			{
				c = value
			}, "java/lang/Character", "(C)Ljava/lang/Character;");
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00006E24 File Offset: 0x00005024
		public static IntPtr Box(bool value)
		{
			return AndroidJNIHelper.Box(new jvalue
			{
				z = value
			}, "java/lang/Boolean", "(Z)Ljava/lang/Boolean;");
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00006E58 File Offset: 0x00005058
		private static IntPtr GetUnboxMethod(IntPtr obj, string methodName, string signature)
		{
			IntPtr objectClass = AndroidJNISafe.GetObjectClass(obj);
			IntPtr methodID;
			try
			{
				methodID = AndroidJNISafe.GetMethodID(objectClass, methodName, signature);
			}
			finally
			{
				AndroidJNISafe.DeleteLocalRef(objectClass);
			}
			return methodID;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00006E94 File Offset: 0x00005094
		public static void Unbox(IntPtr obj, out sbyte value)
		{
			IntPtr unboxMethod = AndroidJNIHelper.GetUnboxMethod(obj, "byteValue", "()B");
			value = AndroidJNISafe.CallSByteMethod(obj, unboxMethod, default(Span<jvalue>));
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00006EC8 File Offset: 0x000050C8
		public static void Unbox(IntPtr obj, out short value)
		{
			IntPtr unboxMethod = AndroidJNIHelper.GetUnboxMethod(obj, "shortValue", "()S");
			value = AndroidJNISafe.CallShortMethod(obj, unboxMethod, default(Span<jvalue>));
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00006EFC File Offset: 0x000050FC
		public static void Unbox(IntPtr obj, out int value)
		{
			IntPtr unboxMethod = AndroidJNIHelper.GetUnboxMethod(obj, "intValue", "()I");
			value = AndroidJNISafe.CallIntMethod(obj, unboxMethod, default(Span<jvalue>));
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00006F30 File Offset: 0x00005130
		public static void Unbox(IntPtr obj, out long value)
		{
			IntPtr unboxMethod = AndroidJNIHelper.GetUnboxMethod(obj, "longValue", "()J");
			value = AndroidJNISafe.CallLongMethod(obj, unboxMethod, default(Span<jvalue>));
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00006F64 File Offset: 0x00005164
		public static void Unbox(IntPtr obj, out float value)
		{
			IntPtr unboxMethod = AndroidJNIHelper.GetUnboxMethod(obj, "floatValue", "()F");
			value = AndroidJNISafe.CallFloatMethod(obj, unboxMethod, default(Span<jvalue>));
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00006F98 File Offset: 0x00005198
		public static void Unbox(IntPtr obj, out double value)
		{
			IntPtr unboxMethod = AndroidJNIHelper.GetUnboxMethod(obj, "doubleValue", "()D");
			value = AndroidJNISafe.CallDoubleMethod(obj, unboxMethod, default(Span<jvalue>));
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00006FCC File Offset: 0x000051CC
		public static void Unbox(IntPtr obj, out char value)
		{
			IntPtr unboxMethod = AndroidJNIHelper.GetUnboxMethod(obj, "charValue", "()C");
			value = AndroidJNISafe.CallCharMethod(obj, unboxMethod, default(Span<jvalue>));
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00007000 File Offset: 0x00005200
		public static void Unbox(IntPtr obj, out bool value)
		{
			IntPtr unboxMethod = AndroidJNIHelper.GetUnboxMethod(obj, "booleanValue", "()Z");
			value = AndroidJNISafe.CallBooleanMethod(obj, unboxMethod, default(Span<jvalue>));
		}
	}
}
