using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x0200000E RID: 14
	[NativeConditional("PLATFORM_ANDROID")]
	[NativeHeader("Modules/AndroidJNI/Public/AndroidJNIBindingsHelpers.h")]
	[StaticAccessor("AndroidJNIBindingsHelpers", StaticAccessorType.DoubleColon)]
	public static class AndroidJNI
	{
		// Token: 0x060000AB RID: 171
		[StaticAccessor("jni", StaticAccessorType.DoubleColon)]
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetJavaVM();

		// Token: 0x060000AC RID: 172
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int AttachCurrentThread();

		// Token: 0x060000AD RID: 173
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int DetachCurrentThread();

		// Token: 0x060000AE RID: 174
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetVersion();

		// Token: 0x060000AF RID: 175
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr FindClass(string name);

		// Token: 0x060000B0 RID: 176
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr FromReflectedMethod(IntPtr refMethod);

		// Token: 0x060000B1 RID: 177
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr FromReflectedField(IntPtr refField);

		// Token: 0x060000B2 RID: 178
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr ToReflectedMethod(IntPtr clazz, IntPtr methodID, bool isStatic);

		// Token: 0x060000B3 RID: 179
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr ToReflectedField(IntPtr clazz, IntPtr fieldID, bool isStatic);

		// Token: 0x060000B4 RID: 180
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetSuperclass(IntPtr clazz);

		// Token: 0x060000B5 RID: 181
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsAssignableFrom(IntPtr clazz1, IntPtr clazz2);

		// Token: 0x060000B6 RID: 182
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int Throw(IntPtr obj);

		// Token: 0x060000B7 RID: 183
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int ThrowNew(IntPtr clazz, string message);

		// Token: 0x060000B8 RID: 184
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr ExceptionOccurred();

		// Token: 0x060000B9 RID: 185
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void ExceptionDescribe();

		// Token: 0x060000BA RID: 186
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void ExceptionClear();

		// Token: 0x060000BB RID: 187
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void FatalError(string message);

		// Token: 0x060000BC RID: 188
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int PushLocalFrame(int capacity);

		// Token: 0x060000BD RID: 189
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr PopLocalFrame(IntPtr ptr);

		// Token: 0x060000BE RID: 190
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr NewGlobalRef(IntPtr obj);

		// Token: 0x060000BF RID: 191
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void DeleteGlobalRef(IntPtr obj);

		// Token: 0x060000C0 RID: 192
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void QueueDeleteGlobalRef(IntPtr obj);

		// Token: 0x060000C1 RID: 193
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern uint GetQueueGlobalRefsCount();

		// Token: 0x060000C2 RID: 194
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr NewWeakGlobalRef(IntPtr obj);

		// Token: 0x060000C3 RID: 195
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void DeleteWeakGlobalRef(IntPtr obj);

		// Token: 0x060000C4 RID: 196
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr NewLocalRef(IntPtr obj);

		// Token: 0x060000C5 RID: 197
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void DeleteLocalRef(IntPtr obj);

		// Token: 0x060000C6 RID: 198
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsSameObject(IntPtr obj1, IntPtr obj2);

		// Token: 0x060000C7 RID: 199
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int EnsureLocalCapacity(int capacity);

		// Token: 0x060000C8 RID: 200
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr AllocObject(IntPtr clazz);

		// Token: 0x060000C9 RID: 201 RVA: 0x00007034 File Offset: 0x00005234
		public static IntPtr NewObject(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.NewObject(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00007054 File Offset: 0x00005254
		public unsafe static IntPtr NewObject(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.NewObjectA(clazz, methodID, args2);
			}
		}

		// Token: 0x060000CB RID: 203
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern IntPtr NewObjectA(IntPtr clazz, IntPtr methodID, jvalue* args);

		// Token: 0x060000CC RID: 204
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetObjectClass(IntPtr obj);

		// Token: 0x060000CD RID: 205
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsInstanceOf(IntPtr obj, IntPtr clazz);

		// Token: 0x060000CE RID: 206
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetMethodID(IntPtr clazz, string name, string sig);

		// Token: 0x060000CF RID: 207
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetFieldID(IntPtr clazz, string name, string sig);

		// Token: 0x060000D0 RID: 208
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetStaticMethodID(IntPtr clazz, string name, string sig);

		// Token: 0x060000D1 RID: 209
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetStaticFieldID(IntPtr clazz, string name, string sig);

		// Token: 0x060000D2 RID: 210 RVA: 0x0000707C File Offset: 0x0000527C
		public static IntPtr NewString(string chars)
		{
			return AndroidJNI.NewStringFromStr(chars);
		}

		// Token: 0x060000D3 RID: 211
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr NewStringFromStr(string chars);

		// Token: 0x060000D4 RID: 212
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr NewString(char[] chars);

		// Token: 0x060000D5 RID: 213
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr NewStringUTF(string bytes);

		// Token: 0x060000D6 RID: 214
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string GetStringChars(IntPtr str);

		// Token: 0x060000D7 RID: 215
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetStringLength(IntPtr str);

		// Token: 0x060000D8 RID: 216
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetStringUTFLength(IntPtr str);

		// Token: 0x060000D9 RID: 217
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string GetStringUTFChars(IntPtr str);

		// Token: 0x060000DA RID: 218 RVA: 0x00007094 File Offset: 0x00005294
		public static string CallStringMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallStringMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000070B4 File Offset: 0x000052B4
		public unsafe static string CallStringMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallStringMethodUnsafe(obj, methodID, args2);
			}
		}

		// Token: 0x060000DC RID: 220
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern string CallStringMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args);

		// Token: 0x060000DD RID: 221 RVA: 0x000070DC File Offset: 0x000052DC
		public static IntPtr CallObjectMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallObjectMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000070FC File Offset: 0x000052FC
		public unsafe static IntPtr CallObjectMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallObjectMethodUnsafe(obj, methodID, args2);
			}
		}

		// Token: 0x060000DF RID: 223
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern IntPtr CallObjectMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args);

		// Token: 0x060000E0 RID: 224 RVA: 0x00007124 File Offset: 0x00005324
		public static int CallIntMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallIntMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00007144 File Offset: 0x00005344
		public unsafe static int CallIntMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallIntMethodUnsafe(obj, methodID, args2);
			}
		}

		// Token: 0x060000E2 RID: 226
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern int CallIntMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args);

		// Token: 0x060000E3 RID: 227 RVA: 0x0000716C File Offset: 0x0000536C
		public static bool CallBooleanMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallBooleanMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000718C File Offset: 0x0000538C
		public unsafe static bool CallBooleanMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallBooleanMethodUnsafe(obj, methodID, args2);
			}
		}

		// Token: 0x060000E5 RID: 229
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern bool CallBooleanMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args);

		// Token: 0x060000E6 RID: 230 RVA: 0x000071B4 File Offset: 0x000053B4
		public static short CallShortMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallShortMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000071D4 File Offset: 0x000053D4
		public unsafe static short CallShortMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallShortMethodUnsafe(obj, methodID, args2);
			}
		}

		// Token: 0x060000E8 RID: 232
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern short CallShortMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args);

		// Token: 0x060000E9 RID: 233 RVA: 0x000071FC File Offset: 0x000053FC
		[Obsolete("AndroidJNI.CallByteMethod is obsolete. Use AndroidJNI.CallSByteMethod method instead")]
		public static byte CallByteMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return (byte)AndroidJNI.CallSByteMethod(obj, methodID, args);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00007218 File Offset: 0x00005418
		public static sbyte CallSByteMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallSByteMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00007238 File Offset: 0x00005438
		public unsafe static sbyte CallSByteMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallSByteMethodUnsafe(obj, methodID, args2);
			}
		}

		// Token: 0x060000EC RID: 236
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern sbyte CallSByteMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args);

		// Token: 0x060000ED RID: 237 RVA: 0x00007260 File Offset: 0x00005460
		public static char CallCharMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallCharMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00007280 File Offset: 0x00005480
		public unsafe static char CallCharMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallCharMethodUnsafe(obj, methodID, args2);
			}
		}

		// Token: 0x060000EF RID: 239
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern char CallCharMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args);

		// Token: 0x060000F0 RID: 240 RVA: 0x000072A8 File Offset: 0x000054A8
		public static float CallFloatMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallFloatMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x000072C8 File Offset: 0x000054C8
		public unsafe static float CallFloatMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallFloatMethodUnsafe(obj, methodID, args2);
			}
		}

		// Token: 0x060000F2 RID: 242
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern float CallFloatMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args);

		// Token: 0x060000F3 RID: 243 RVA: 0x000072F0 File Offset: 0x000054F0
		public static double CallDoubleMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallDoubleMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00007310 File Offset: 0x00005510
		public unsafe static double CallDoubleMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallDoubleMethodUnsafe(obj, methodID, args2);
			}
		}

		// Token: 0x060000F5 RID: 245
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern double CallDoubleMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args);

		// Token: 0x060000F6 RID: 246 RVA: 0x00007338 File Offset: 0x00005538
		public static long CallLongMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallLongMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00007358 File Offset: 0x00005558
		public unsafe static long CallLongMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallLongMethodUnsafe(obj, methodID, args2);
			}
		}

		// Token: 0x060000F8 RID: 248
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern long CallLongMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args);

		// Token: 0x060000F9 RID: 249 RVA: 0x0000737F File Offset: 0x0000557F
		public static void CallVoidMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
		{
			AndroidJNI.CallVoidMethod(obj, methodID, new Span<jvalue>(args));
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00007390 File Offset: 0x00005590
		public unsafe static void CallVoidMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				AndroidJNI.CallVoidMethodUnsafe(obj, methodID, args2);
			}
		}

		// Token: 0x060000FB RID: 251
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern void CallVoidMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args);

		// Token: 0x060000FC RID: 252
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string GetStringField(IntPtr obj, IntPtr fieldID);

		// Token: 0x060000FD RID: 253
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetObjectField(IntPtr obj, IntPtr fieldID);

		// Token: 0x060000FE RID: 254
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool GetBooleanField(IntPtr obj, IntPtr fieldID);

		// Token: 0x060000FF RID: 255 RVA: 0x000073BC File Offset: 0x000055BC
		[Obsolete("AndroidJNI.GetByteField is obsolete. Use AndroidJNI.GetSByteField method instead")]
		public static byte GetByteField(IntPtr obj, IntPtr fieldID)
		{
			return (byte)AndroidJNI.GetSByteField(obj, fieldID);
		}

		// Token: 0x06000100 RID: 256
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern sbyte GetSByteField(IntPtr obj, IntPtr fieldID);

		// Token: 0x06000101 RID: 257
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern char GetCharField(IntPtr obj, IntPtr fieldID);

		// Token: 0x06000102 RID: 258
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern short GetShortField(IntPtr obj, IntPtr fieldID);

		// Token: 0x06000103 RID: 259
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetIntField(IntPtr obj, IntPtr fieldID);

		// Token: 0x06000104 RID: 260
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern long GetLongField(IntPtr obj, IntPtr fieldID);

		// Token: 0x06000105 RID: 261
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern float GetFloatField(IntPtr obj, IntPtr fieldID);

		// Token: 0x06000106 RID: 262
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double GetDoubleField(IntPtr obj, IntPtr fieldID);

		// Token: 0x06000107 RID: 263
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetStringField(IntPtr obj, IntPtr fieldID, string val);

		// Token: 0x06000108 RID: 264
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetObjectField(IntPtr obj, IntPtr fieldID, IntPtr val);

		// Token: 0x06000109 RID: 265
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetBooleanField(IntPtr obj, IntPtr fieldID, bool val);

		// Token: 0x0600010A RID: 266 RVA: 0x000073D6 File Offset: 0x000055D6
		[Obsolete("AndroidJNI.SetByteField is obsolete. Use AndroidJNI.SetSByteField method instead")]
		public static void SetByteField(IntPtr obj, IntPtr fieldID, byte val)
		{
			AndroidJNI.SetSByteField(obj, fieldID, (sbyte)val);
		}

		// Token: 0x0600010B RID: 267
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetSByteField(IntPtr obj, IntPtr fieldID, sbyte val);

		// Token: 0x0600010C RID: 268
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetCharField(IntPtr obj, IntPtr fieldID, char val);

		// Token: 0x0600010D RID: 269
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetShortField(IntPtr obj, IntPtr fieldID, short val);

		// Token: 0x0600010E RID: 270
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetIntField(IntPtr obj, IntPtr fieldID, int val);

		// Token: 0x0600010F RID: 271
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetLongField(IntPtr obj, IntPtr fieldID, long val);

		// Token: 0x06000110 RID: 272
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetFloatField(IntPtr obj, IntPtr fieldID, float val);

		// Token: 0x06000111 RID: 273
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetDoubleField(IntPtr obj, IntPtr fieldID, double val);

		// Token: 0x06000112 RID: 274 RVA: 0x000073E4 File Offset: 0x000055E4
		public static string CallStaticStringMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallStaticStringMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00007404 File Offset: 0x00005604
		public unsafe static string CallStaticStringMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallStaticStringMethodUnsafe(clazz, methodID, args2);
			}
		}

		// Token: 0x06000114 RID: 276
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern string CallStaticStringMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args);

		// Token: 0x06000115 RID: 277 RVA: 0x0000742C File Offset: 0x0000562C
		public static IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallStaticObjectMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000744C File Offset: 0x0000564C
		public unsafe static IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallStaticObjectMethodUnsafe(clazz, methodID, args2);
			}
		}

		// Token: 0x06000117 RID: 279
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern IntPtr CallStaticObjectMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args);

		// Token: 0x06000118 RID: 280 RVA: 0x00007474 File Offset: 0x00005674
		public static int CallStaticIntMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallStaticIntMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00007494 File Offset: 0x00005694
		public unsafe static int CallStaticIntMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallStaticIntMethodUnsafe(clazz, methodID, args2);
			}
		}

		// Token: 0x0600011A RID: 282
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern int CallStaticIntMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args);

		// Token: 0x0600011B RID: 283 RVA: 0x000074BC File Offset: 0x000056BC
		public static bool CallStaticBooleanMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallStaticBooleanMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000074DC File Offset: 0x000056DC
		public unsafe static bool CallStaticBooleanMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallStaticBooleanMethodUnsafe(clazz, methodID, args2);
			}
		}

		// Token: 0x0600011D RID: 285
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern bool CallStaticBooleanMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args);

		// Token: 0x0600011E RID: 286 RVA: 0x00007504 File Offset: 0x00005704
		public static short CallStaticShortMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallStaticShortMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00007524 File Offset: 0x00005724
		public unsafe static short CallStaticShortMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallStaticShortMethodUnsafe(clazz, methodID, args2);
			}
		}

		// Token: 0x06000120 RID: 288
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern short CallStaticShortMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args);

		// Token: 0x06000121 RID: 289 RVA: 0x0000754C File Offset: 0x0000574C
		[Obsolete("AndroidJNI.CallStaticByteMethod is obsolete. Use AndroidJNI.CallStaticSByteMethod method instead")]
		public static byte CallStaticByteMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return (byte)AndroidJNI.CallStaticSByteMethod(clazz, methodID, args);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00007568 File Offset: 0x00005768
		public static sbyte CallStaticSByteMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallStaticSByteMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00007588 File Offset: 0x00005788
		public unsafe static sbyte CallStaticSByteMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallStaticSByteMethodUnsafe(clazz, methodID, args2);
			}
		}

		// Token: 0x06000124 RID: 292
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern sbyte CallStaticSByteMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args);

		// Token: 0x06000125 RID: 293 RVA: 0x000075B0 File Offset: 0x000057B0
		public static char CallStaticCharMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallStaticCharMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x06000126 RID: 294 RVA: 0x000075D0 File Offset: 0x000057D0
		public unsafe static char CallStaticCharMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallStaticCharMethodUnsafe(clazz, methodID, args2);
			}
		}

		// Token: 0x06000127 RID: 295
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern char CallStaticCharMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args);

		// Token: 0x06000128 RID: 296 RVA: 0x000075F8 File Offset: 0x000057F8
		public static float CallStaticFloatMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallStaticFloatMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00007618 File Offset: 0x00005818
		public unsafe static float CallStaticFloatMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallStaticFloatMethodUnsafe(clazz, methodID, args2);
			}
		}

		// Token: 0x0600012A RID: 298
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern float CallStaticFloatMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args);

		// Token: 0x0600012B RID: 299 RVA: 0x00007640 File Offset: 0x00005840
		public static double CallStaticDoubleMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallStaticDoubleMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00007660 File Offset: 0x00005860
		public unsafe static double CallStaticDoubleMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallStaticDoubleMethodUnsafe(clazz, methodID, args2);
			}
		}

		// Token: 0x0600012D RID: 301
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern double CallStaticDoubleMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args);

		// Token: 0x0600012E RID: 302 RVA: 0x00007688 File Offset: 0x00005888
		public static long CallStaticLongMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			return AndroidJNI.CallStaticLongMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000076A8 File Offset: 0x000058A8
		public unsafe static long CallStaticLongMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				return AndroidJNI.CallStaticLongMethodUnsafe(clazz, methodID, args2);
			}
		}

		// Token: 0x06000130 RID: 304
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern long CallStaticLongMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args);

		// Token: 0x06000131 RID: 305 RVA: 0x000076CF File Offset: 0x000058CF
		public static void CallStaticVoidMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
		{
			AndroidJNI.CallStaticVoidMethod(clazz, methodID, new Span<jvalue>(args));
		}

		// Token: 0x06000132 RID: 306 RVA: 0x000076E0 File Offset: 0x000058E0
		public unsafe static void CallStaticVoidMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args)
		{
			fixed (jvalue* pinnableReference = args.GetPinnableReference())
			{
				jvalue* args2 = pinnableReference;
				AndroidJNI.CallStaticVoidMethodUnsafe(clazz, methodID, args2);
			}
		}

		// Token: 0x06000133 RID: 307
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern void CallStaticVoidMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args);

		// Token: 0x06000134 RID: 308
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern string GetStaticStringField(IntPtr clazz, IntPtr fieldID);

		// Token: 0x06000135 RID: 309
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetStaticObjectField(IntPtr clazz, IntPtr fieldID);

		// Token: 0x06000136 RID: 310
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool GetStaticBooleanField(IntPtr clazz, IntPtr fieldID);

		// Token: 0x06000137 RID: 311 RVA: 0x0000770C File Offset: 0x0000590C
		[Obsolete("AndroidJNI.GetStaticByteField is obsolete. Use AndroidJNI.GetStaticSByteField method instead")]
		public static byte GetStaticByteField(IntPtr clazz, IntPtr fieldID)
		{
			return (byte)AndroidJNI.GetStaticSByteField(clazz, fieldID);
		}

		// Token: 0x06000138 RID: 312
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern sbyte GetStaticSByteField(IntPtr clazz, IntPtr fieldID);

		// Token: 0x06000139 RID: 313
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern char GetStaticCharField(IntPtr clazz, IntPtr fieldID);

		// Token: 0x0600013A RID: 314
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern short GetStaticShortField(IntPtr clazz, IntPtr fieldID);

		// Token: 0x0600013B RID: 315
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetStaticIntField(IntPtr clazz, IntPtr fieldID);

		// Token: 0x0600013C RID: 316
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern long GetStaticLongField(IntPtr clazz, IntPtr fieldID);

		// Token: 0x0600013D RID: 317
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern float GetStaticFloatField(IntPtr clazz, IntPtr fieldID);

		// Token: 0x0600013E RID: 318
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double GetStaticDoubleField(IntPtr clazz, IntPtr fieldID);

		// Token: 0x0600013F RID: 319
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetStaticStringField(IntPtr clazz, IntPtr fieldID, string val);

		// Token: 0x06000140 RID: 320
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetStaticObjectField(IntPtr clazz, IntPtr fieldID, IntPtr val);

		// Token: 0x06000141 RID: 321
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetStaticBooleanField(IntPtr clazz, IntPtr fieldID, bool val);

		// Token: 0x06000142 RID: 322 RVA: 0x00007726 File Offset: 0x00005926
		[Obsolete("AndroidJNI.SetStaticByteField is obsolete. Use AndroidJNI.SetStaticSByteField method instead")]
		public static void SetStaticByteField(IntPtr clazz, IntPtr fieldID, byte val)
		{
			AndroidJNI.SetStaticSByteField(clazz, fieldID, (sbyte)val);
		}

		// Token: 0x06000143 RID: 323
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetStaticSByteField(IntPtr clazz, IntPtr fieldID, sbyte val);

		// Token: 0x06000144 RID: 324
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetStaticCharField(IntPtr clazz, IntPtr fieldID, char val);

		// Token: 0x06000145 RID: 325
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetStaticShortField(IntPtr clazz, IntPtr fieldID, short val);

		// Token: 0x06000146 RID: 326
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetStaticIntField(IntPtr clazz, IntPtr fieldID, int val);

		// Token: 0x06000147 RID: 327
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetStaticLongField(IntPtr clazz, IntPtr fieldID, long val);

		// Token: 0x06000148 RID: 328
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetStaticFloatField(IntPtr clazz, IntPtr fieldID, float val);

		// Token: 0x06000149 RID: 329
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetStaticDoubleField(IntPtr clazz, IntPtr fieldID, double val);

		// Token: 0x0600014A RID: 330
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr ToBooleanArray(bool[] array);

		// Token: 0x0600014B RID: 331
		[Obsolete("AndroidJNI.ToByteArray is obsolete. Use AndroidJNI.ToSByteArray method instead")]
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr ToByteArray(byte[] array);

		// Token: 0x0600014C RID: 332 RVA: 0x00007734 File Offset: 0x00005934
		public unsafe static IntPtr ToSByteArray(sbyte[] array)
		{
			bool flag = array == null;
			IntPtr result;
			if (flag)
			{
				result = IntPtr.Zero;
			}
			else
			{
				sbyte* array2;
				if (array == null || array.Length == 0)
				{
					array2 = null;
				}
				else
				{
					array2 = &array[0];
				}
				result = AndroidJNI.ToSByteArray(array2, array.Length);
			}
			return result;
		}

		// Token: 0x0600014D RID: 333
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern IntPtr ToSByteArray(sbyte* array, int length);

		// Token: 0x0600014E RID: 334 RVA: 0x0000777C File Offset: 0x0000597C
		public unsafe static IntPtr ToCharArray(char[] array)
		{
			bool flag = array == null;
			IntPtr result;
			if (flag)
			{
				result = IntPtr.Zero;
			}
			else
			{
				char* array2;
				if (array == null || array.Length == 0)
				{
					array2 = null;
				}
				else
				{
					array2 = &array[0];
				}
				result = AndroidJNI.ToCharArray(array2, array.Length);
			}
			return result;
		}

		// Token: 0x0600014F RID: 335
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern IntPtr ToCharArray(char* array, int length);

		// Token: 0x06000150 RID: 336 RVA: 0x000077C4 File Offset: 0x000059C4
		public unsafe static IntPtr ToShortArray(short[] array)
		{
			bool flag = array == null;
			IntPtr result;
			if (flag)
			{
				result = IntPtr.Zero;
			}
			else
			{
				short* array2;
				if (array == null || array.Length == 0)
				{
					array2 = null;
				}
				else
				{
					array2 = &array[0];
				}
				result = AndroidJNI.ToShortArray(array2, array.Length);
			}
			return result;
		}

		// Token: 0x06000151 RID: 337
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern IntPtr ToShortArray(short* array, int length);

		// Token: 0x06000152 RID: 338 RVA: 0x0000780C File Offset: 0x00005A0C
		public unsafe static IntPtr ToIntArray(int[] array)
		{
			bool flag = array == null;
			IntPtr result;
			if (flag)
			{
				result = IntPtr.Zero;
			}
			else
			{
				int* array2;
				if (array == null || array.Length == 0)
				{
					array2 = null;
				}
				else
				{
					array2 = &array[0];
				}
				result = AndroidJNI.ToIntArray(array2, array.Length);
			}
			return result;
		}

		// Token: 0x06000153 RID: 339
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern IntPtr ToIntArray(int* array, int length);

		// Token: 0x06000154 RID: 340 RVA: 0x00007854 File Offset: 0x00005A54
		public unsafe static IntPtr ToLongArray(long[] array)
		{
			bool flag = array == null;
			IntPtr result;
			if (flag)
			{
				result = IntPtr.Zero;
			}
			else
			{
				long* array2;
				if (array == null || array.Length == 0)
				{
					array2 = null;
				}
				else
				{
					array2 = &array[0];
				}
				result = AndroidJNI.ToLongArray(array2, array.Length);
			}
			return result;
		}

		// Token: 0x06000155 RID: 341
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern IntPtr ToLongArray(long* array, int length);

		// Token: 0x06000156 RID: 342 RVA: 0x0000789C File Offset: 0x00005A9C
		public unsafe static IntPtr ToFloatArray(float[] array)
		{
			bool flag = array == null;
			IntPtr result;
			if (flag)
			{
				result = IntPtr.Zero;
			}
			else
			{
				float* array2;
				if (array == null || array.Length == 0)
				{
					array2 = null;
				}
				else
				{
					array2 = &array[0];
				}
				result = AndroidJNI.ToFloatArray(array2, array.Length);
			}
			return result;
		}

		// Token: 0x06000157 RID: 343
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern IntPtr ToFloatArray(float* array, int length);

		// Token: 0x06000158 RID: 344 RVA: 0x000078E4 File Offset: 0x00005AE4
		public unsafe static IntPtr ToDoubleArray(double[] array)
		{
			bool flag = array == null;
			IntPtr result;
			if (flag)
			{
				result = IntPtr.Zero;
			}
			else
			{
				double* array2;
				if (array == null || array.Length == 0)
				{
					array2 = null;
				}
				else
				{
					array2 = &array[0];
				}
				result = AndroidJNI.ToDoubleArray(array2, array.Length);
			}
			return result;
		}

		// Token: 0x06000159 RID: 345
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern IntPtr ToDoubleArray(double* array, int length);

		// Token: 0x0600015A RID: 346
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern IntPtr ToObjectArray(IntPtr* array, int length, IntPtr arrayClass);

		// Token: 0x0600015B RID: 347 RVA: 0x0000792C File Offset: 0x00005B2C
		public unsafe static IntPtr ToObjectArray(IntPtr[] array, IntPtr arrayClass)
		{
			bool flag = array == null;
			IntPtr result;
			if (flag)
			{
				result = IntPtr.Zero;
			}
			else
			{
				IntPtr* array2;
				if (array == null || array.Length == 0)
				{
					array2 = null;
				}
				else
				{
					array2 = &array[0];
				}
				result = AndroidJNI.ToObjectArray(array2, array.Length, arrayClass);
			}
			return result;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00007974 File Offset: 0x00005B74
		public static IntPtr ToObjectArray(IntPtr[] array)
		{
			return AndroidJNI.ToObjectArray(array, IntPtr.Zero);
		}

		// Token: 0x0600015D RID: 349
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool[] FromBooleanArray(IntPtr array);

		// Token: 0x0600015E RID: 350
		[ThreadSafe]
		[Obsolete("AndroidJNI.FromByteArray is obsolete. Use AndroidJNI.FromSByteArray method instead")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern byte[] FromByteArray(IntPtr array);

		// Token: 0x0600015F RID: 351
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern sbyte[] FromSByteArray(IntPtr array);

		// Token: 0x06000160 RID: 352
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern char[] FromCharArray(IntPtr array);

		// Token: 0x06000161 RID: 353
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern short[] FromShortArray(IntPtr array);

		// Token: 0x06000162 RID: 354
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int[] FromIntArray(IntPtr array);

		// Token: 0x06000163 RID: 355
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern long[] FromLongArray(IntPtr array);

		// Token: 0x06000164 RID: 356
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern float[] FromFloatArray(IntPtr array);

		// Token: 0x06000165 RID: 357
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double[] FromDoubleArray(IntPtr array);

		// Token: 0x06000166 RID: 358
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr[] FromObjectArray(IntPtr array);

		// Token: 0x06000167 RID: 359
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetArrayLength(IntPtr array);

		// Token: 0x06000168 RID: 360
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr NewBooleanArray(int size);

		// Token: 0x06000169 RID: 361 RVA: 0x00007994 File Offset: 0x00005B94
		[Obsolete("AndroidJNI.NewByteArray is obsolete. Use AndroidJNI.NewSByteArray method instead")]
		public static IntPtr NewByteArray(int size)
		{
			return AndroidJNI.NewSByteArray(size);
		}

		// Token: 0x0600016A RID: 362
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr NewSByteArray(int size);

		// Token: 0x0600016B RID: 363
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr NewCharArray(int size);

		// Token: 0x0600016C RID: 364
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr NewShortArray(int size);

		// Token: 0x0600016D RID: 365
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr NewIntArray(int size);

		// Token: 0x0600016E RID: 366
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr NewLongArray(int size);

		// Token: 0x0600016F RID: 367
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr NewFloatArray(int size);

		// Token: 0x06000170 RID: 368
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr NewDoubleArray(int size);

		// Token: 0x06000171 RID: 369
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr NewObjectArray(int size, IntPtr clazz, IntPtr obj);

		// Token: 0x06000172 RID: 370
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool GetBooleanArrayElement(IntPtr array, int index);

		// Token: 0x06000173 RID: 371 RVA: 0x000079AC File Offset: 0x00005BAC
		[Obsolete("AndroidJNI.GetByteArrayElement is obsolete. Use AndroidJNI.GetSByteArrayElement method instead")]
		public static byte GetByteArrayElement(IntPtr array, int index)
		{
			return (byte)AndroidJNI.GetSByteArrayElement(array, index);
		}

		// Token: 0x06000174 RID: 372
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern sbyte GetSByteArrayElement(IntPtr array, int index);

		// Token: 0x06000175 RID: 373
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern char GetCharArrayElement(IntPtr array, int index);

		// Token: 0x06000176 RID: 374
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern short GetShortArrayElement(IntPtr array, int index);

		// Token: 0x06000177 RID: 375
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int GetIntArrayElement(IntPtr array, int index);

		// Token: 0x06000178 RID: 376
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern long GetLongArrayElement(IntPtr array, int index);

		// Token: 0x06000179 RID: 377
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern float GetFloatArrayElement(IntPtr array, int index);

		// Token: 0x0600017A RID: 378
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double GetDoubleArrayElement(IntPtr array, int index);

		// Token: 0x0600017B RID: 379
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetObjectArrayElement(IntPtr array, int index);

		// Token: 0x0600017C RID: 380 RVA: 0x000079C6 File Offset: 0x00005BC6
		[Obsolete("AndroidJNI.SetBooleanArrayElement(IntPtr, int, byte) is obsolete. Use AndroidJNI.SetBooleanArrayElement(IntPtr, int, bool) method instead")]
		public static void SetBooleanArrayElement(IntPtr array, int index, byte val)
		{
			AndroidJNI.SetBooleanArrayElement(array, index, val > 0);
		}

		// Token: 0x0600017D RID: 381
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetBooleanArrayElement(IntPtr array, int index, bool val);

		// Token: 0x0600017E RID: 382 RVA: 0x000079D5 File Offset: 0x00005BD5
		[Obsolete("AndroidJNI.SetByteArrayElement is obsolete. Use AndroidJNI.SetSByteArrayElement method instead")]
		public static void SetByteArrayElement(IntPtr array, int index, sbyte val)
		{
			AndroidJNI.SetSByteArrayElement(array, index, val);
		}

		// Token: 0x0600017F RID: 383
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetSByteArrayElement(IntPtr array, int index, sbyte val);

		// Token: 0x06000180 RID: 384
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetCharArrayElement(IntPtr array, int index, char val);

		// Token: 0x06000181 RID: 385
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetShortArrayElement(IntPtr array, int index, short val);

		// Token: 0x06000182 RID: 386
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetIntArrayElement(IntPtr array, int index, int val);

		// Token: 0x06000183 RID: 387
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetLongArrayElement(IntPtr array, int index, long val);

		// Token: 0x06000184 RID: 388
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetFloatArrayElement(IntPtr array, int index, float val);

		// Token: 0x06000185 RID: 389
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetDoubleArrayElement(IntPtr array, int index, double val);

		// Token: 0x06000186 RID: 390
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetObjectArrayElement(IntPtr array, int index, IntPtr obj);

		// Token: 0x06000187 RID: 391
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern IntPtr NewDirectByteBuffer(byte* buffer, long capacity);

		// Token: 0x06000188 RID: 392 RVA: 0x000079E4 File Offset: 0x00005BE4
		public static IntPtr NewDirectByteBuffer(NativeArray<byte> buffer)
		{
			return AndroidJNI.NewDirectByteBufferFromNativeArray<byte>(buffer);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000079FC File Offset: 0x00005BFC
		public static IntPtr NewDirectByteBuffer(NativeArray<sbyte> buffer)
		{
			return AndroidJNI.NewDirectByteBufferFromNativeArray<sbyte>(buffer);
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00007A14 File Offset: 0x00005C14
		private unsafe static IntPtr NewDirectByteBufferFromNativeArray<T>(NativeArray<T> buffer) where T : struct
		{
			bool flag = !buffer.IsCreated || buffer.Length <= 0;
			IntPtr result;
			if (flag)
			{
				result = IntPtr.Zero;
			}
			else
			{
				result = AndroidJNI.NewDirectByteBuffer((byte*)buffer.GetUnsafePtr<T>(), (long)buffer.Length);
			}
			return result;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00007A60 File Offset: 0x00005C60
		public unsafe static sbyte* GetDirectBufferAddress(IntPtr buffer)
		{
			return null;
		}

		// Token: 0x0600018C RID: 396
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern long GetDirectBufferCapacity(IntPtr buffer);

		// Token: 0x0600018D RID: 397 RVA: 0x00007A74 File Offset: 0x00005C74
		private unsafe static NativeArray<T> GetDirectBuffer<T>(IntPtr buffer) where T : struct
		{
			bool flag = buffer == IntPtr.Zero;
			NativeArray<T> result;
			if (flag)
			{
				result = default(NativeArray<T>);
			}
			else
			{
				sbyte* directBufferAddress = AndroidJNI.GetDirectBufferAddress(buffer);
				bool flag2 = directBufferAddress == null;
				if (flag2)
				{
					result = default(NativeArray<T>);
				}
				else
				{
					long directBufferCapacity = AndroidJNI.GetDirectBufferCapacity(buffer);
					bool flag3 = directBufferCapacity > 2147483647L;
					if (flag3)
					{
						throw new Exception(string.Format("Direct buffer is too large ({0}) for NativeArray (max {1})", directBufferCapacity, int.MaxValue));
					}
					result = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>((void*)directBufferAddress, (int)directBufferCapacity, Allocator.None);
				}
			}
			return result;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00007B04 File Offset: 0x00005D04
		public static NativeArray<byte> GetDirectByteBuffer(IntPtr buffer)
		{
			return AndroidJNI.GetDirectBuffer<byte>(buffer);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00007B1C File Offset: 0x00005D1C
		public static NativeArray<sbyte> GetDirectSByteBuffer(IntPtr buffer)
		{
			return AndroidJNI.GetDirectBuffer<sbyte>(buffer);
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00007B34 File Offset: 0x00005D34
		public static int RegisterNatives(IntPtr clazz, JNINativeMethod[] methods)
		{
			bool flag = methods == null || methods.Length == 0;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				foreach (JNINativeMethod jninativeMethod in methods)
				{
					bool flag2 = string.IsNullOrEmpty(jninativeMethod.name) || string.IsNullOrEmpty(jninativeMethod.signature);
					if (flag2)
					{
						return -1;
					}
				}
				IntPtr natives = AndroidJNI.RegisterNativesAllocate(methods.Length);
				for (int j = 0; j < methods.Length; j++)
				{
					AndroidJNI.RegisterNativesSet(natives, j, methods[j].name, methods[j].signature, methods[j].fnPtr);
				}
				result = AndroidJNI.RegisterNativesAndFree(clazz, natives, methods.Length);
			}
			return result;
		}

		// Token: 0x06000191 RID: 401
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr RegisterNativesAllocate(int length);

		// Token: 0x06000192 RID: 402
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RegisterNativesSet(IntPtr natives, int idx, string name, string signature, IntPtr fnPtr);

		// Token: 0x06000193 RID: 403
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int RegisterNativesAndFree(IntPtr clazz, IntPtr natives, int n);

		// Token: 0x06000194 RID: 404
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int UnregisterNatives(IntPtr clazz);
	}
}
