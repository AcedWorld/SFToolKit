using System;
using System.Runtime.InteropServices;

namespace UnityEngine
{
	// Token: 0x02000009 RID: 9
	internal class AndroidReflection
	{
		// Token: 0x0600005D RID: 93 RVA: 0x00004B74 File Offset: 0x00002D74
		public static bool IsPrimitive(Type t)
		{
			return t.IsPrimitive;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00004B8C File Offset: 0x00002D8C
		public static bool IsAssignableFrom(Type t, Type from)
		{
			return t.IsAssignableFrom(from);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00004BA8 File Offset: 0x00002DA8
		private static IntPtr GetStaticMethodID(string clazz, string methodName, string signature)
		{
			IntPtr intPtr = AndroidJNISafe.FindClass(clazz);
			IntPtr staticMethodID;
			try
			{
				staticMethodID = AndroidJNISafe.GetStaticMethodID(intPtr, methodName, signature);
			}
			finally
			{
				AndroidJNISafe.DeleteLocalRef(intPtr);
			}
			return staticMethodID;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00004BE4 File Offset: 0x00002DE4
		private static IntPtr GetMethodID(string clazz, string methodName, string signature)
		{
			IntPtr intPtr = AndroidJNISafe.FindClass(clazz);
			IntPtr methodID;
			try
			{
				methodID = AndroidJNISafe.GetMethodID(intPtr, methodName, signature);
			}
			finally
			{
				AndroidJNISafe.DeleteLocalRef(intPtr);
			}
			return methodID;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00004C20 File Offset: 0x00002E20
		public static IntPtr GetConstructorMember(IntPtr jclass, string signature)
		{
			jvalue[] array = new jvalue[2];
			IntPtr result;
			try
			{
				array[0].l = jclass;
				array[1].l = AndroidJNISafe.NewString(signature);
				result = AndroidJNISafe.CallStaticObjectMethod(AndroidReflection.s_ReflectionHelperClass, AndroidReflection.s_ReflectionHelperGetConstructorID, array);
			}
			finally
			{
				AndroidJNISafe.DeleteLocalRef(array[1].l);
			}
			return result;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00004C94 File Offset: 0x00002E94
		public static IntPtr GetMethodMember(IntPtr jclass, string methodName, string signature, bool isStatic)
		{
			jvalue[] array = new jvalue[4];
			IntPtr result;
			try
			{
				array[0].l = jclass;
				array[1].l = AndroidJNISafe.NewString(methodName);
				array[2].l = AndroidJNISafe.NewString(signature);
				array[3].z = isStatic;
				result = AndroidJNISafe.CallStaticObjectMethod(AndroidReflection.s_ReflectionHelperClass, AndroidReflection.s_ReflectionHelperGetMethodID, array);
			}
			finally
			{
				AndroidJNISafe.DeleteLocalRef(array[1].l);
				AndroidJNISafe.DeleteLocalRef(array[2].l);
			}
			return result;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00004D38 File Offset: 0x00002F38
		public static IntPtr GetFieldMember(IntPtr jclass, string fieldName, string signature, bool isStatic)
		{
			jvalue[] array = new jvalue[4];
			IntPtr result;
			try
			{
				array[0].l = jclass;
				array[1].l = AndroidJNISafe.NewString(fieldName);
				array[2].l = AndroidJNISafe.NewString(signature);
				array[3].z = isStatic;
				result = AndroidJNISafe.CallStaticObjectMethod(AndroidReflection.s_ReflectionHelperClass, AndroidReflection.s_ReflectionHelperGetFieldID, array);
			}
			finally
			{
				AndroidJNISafe.DeleteLocalRef(array[1].l);
				AndroidJNISafe.DeleteLocalRef(array[2].l);
			}
			return result;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00004DDC File Offset: 0x00002FDC
		public static IntPtr GetFieldClass(IntPtr field)
		{
			return AndroidJNISafe.CallObjectMethod(field, AndroidReflection.s_FieldGetDeclaringClass, null);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00004DFC File Offset: 0x00002FFC
		public static string GetFieldSignature(IntPtr field)
		{
			jvalue[] array = new jvalue[1];
			array[0].l = field;
			return AndroidJNISafe.CallStaticStringMethod(AndroidReflection.s_ReflectionHelperClass, AndroidReflection.s_ReflectionHelperGetFieldSignature, array);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00004E38 File Offset: 0x00003038
		public static IntPtr NewProxyInstance(IntPtr player, IntPtr delegateHandle, IntPtr interfaze)
		{
			jvalue[] array = new jvalue[3];
			array[0].l = player;
			array[1].j = delegateHandle.ToInt64();
			array[2].l = interfaze;
			return AndroidJNISafe.CallStaticObjectMethod(AndroidReflection.s_ReflectionHelperClass, AndroidReflection.s_ReflectionHelperNewProxyInstance, array);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00004E94 File Offset: 0x00003094
		internal static IntPtr CreateInvocationError(Exception ex, bool methodNotFound)
		{
			jvalue[] array = new jvalue[2];
			array[0].j = GCHandle.ToIntPtr(GCHandle.Alloc(ex)).ToInt64();
			array[1].z = methodNotFound;
			return AndroidJNISafe.CallStaticObjectMethod(AndroidReflection.s_ReflectionHelperClass, AndroidReflection.s_ReflectionHelperCeateInvocationError, array);
		}

		// Token: 0x0400000C RID: 12
		private const string RELECTION_HELPER_CLASS_NAME = "com/unity3d/player/ReflectionHelper";

		// Token: 0x0400000D RID: 13
		private static readonly GlobalJavaObjectRef s_ReflectionHelperClass = new GlobalJavaObjectRef(AndroidJNISafe.FindClass("com/unity3d/player/ReflectionHelper"));

		// Token: 0x0400000E RID: 14
		private static readonly IntPtr s_ReflectionHelperGetConstructorID = AndroidReflection.GetStaticMethodID("com/unity3d/player/ReflectionHelper", "getConstructorID", "(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/reflect/Constructor;");

		// Token: 0x0400000F RID: 15
		private static readonly IntPtr s_ReflectionHelperGetMethodID = AndroidReflection.GetStaticMethodID("com/unity3d/player/ReflectionHelper", "getMethodID", "(Ljava/lang/Class;Ljava/lang/String;Ljava/lang/String;Z)Ljava/lang/reflect/Method;");

		// Token: 0x04000010 RID: 16
		private static readonly IntPtr s_ReflectionHelperGetFieldID = AndroidReflection.GetStaticMethodID("com/unity3d/player/ReflectionHelper", "getFieldID", "(Ljava/lang/Class;Ljava/lang/String;Ljava/lang/String;Z)Ljava/lang/reflect/Field;");

		// Token: 0x04000011 RID: 17
		private static readonly IntPtr s_ReflectionHelperGetFieldSignature = AndroidReflection.GetStaticMethodID("com/unity3d/player/ReflectionHelper", "getFieldSignature", "(Ljava/lang/reflect/Field;)Ljava/lang/String;");

		// Token: 0x04000012 RID: 18
		private static readonly IntPtr s_ReflectionHelperNewProxyInstance = AndroidReflection.GetStaticMethodID("com/unity3d/player/ReflectionHelper", "newProxyInstance", "(Lcom/unity3d/player/UnityPlayer;JLjava/lang/Class;)Ljava/lang/Object;");

		// Token: 0x04000013 RID: 19
		private static readonly IntPtr s_ReflectionHelperCeateInvocationError = AndroidReflection.GetStaticMethodID("com/unity3d/player/ReflectionHelper", "createInvocationError", "(JZ)Ljava/lang/Object;");

		// Token: 0x04000014 RID: 20
		private static readonly IntPtr s_FieldGetDeclaringClass = AndroidReflection.GetMethodID("java/lang/reflect/Field", "getDeclaringClass", "()Ljava/lang/Class;");
	}
}
