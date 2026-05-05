using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngineInternal;

namespace UnityEngine
{
	// Token: 0x02000223 RID: 547
	[NativeHeader("Runtime/Misc/ResourceManagerUtility.h")]
	[NativeHeader("Runtime/Export/Resources/Resources.bindings.h")]
	public sealed class Resources
	{
		// Token: 0x060017FB RID: 6139 RVA: 0x00027BE0 File Offset: 0x00025DE0
		internal static T[] ConvertObjects<T>(Object[] rawObjects) where T : Object
		{
			bool flag = rawObjects == null;
			T[] result;
			if (flag)
			{
				result = null;
			}
			else
			{
				T[] array = new T[rawObjects.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = (T)((object)rawObjects[i]);
				}
				result = array;
			}
			return result;
		}

		// Token: 0x060017FC RID: 6140 RVA: 0x00027C2C File Offset: 0x00025E2C
		public static Object[] FindObjectsOfTypeAll(Type type)
		{
			return ResourcesAPI.ActiveAPI.FindObjectsOfTypeAll(type);
		}

		// Token: 0x060017FD RID: 6141 RVA: 0x00027C4C File Offset: 0x00025E4C
		public static T[] FindObjectsOfTypeAll<T>() where T : Object
		{
			return Resources.ConvertObjects<T>(Resources.FindObjectsOfTypeAll(typeof(T)));
		}

		// Token: 0x060017FE RID: 6142 RVA: 0x00027C74 File Offset: 0x00025E74
		public static Object Load(string path)
		{
			return Resources.Load(path, typeof(Object));
		}

		// Token: 0x060017FF RID: 6143 RVA: 0x00027C98 File Offset: 0x00025E98
		public static T Load<T>(string path) where T : Object
		{
			return (T)((object)Resources.Load(path, typeof(T)));
		}

		// Token: 0x06001800 RID: 6144 RVA: 0x00027CC0 File Offset: 0x00025EC0
		public static Object Load(string path, Type systemTypeInstance)
		{
			return ResourcesAPI.ActiveAPI.Load(path, systemTypeInstance);
		}

		// Token: 0x06001801 RID: 6145 RVA: 0x00027CE0 File Offset: 0x00025EE0
		public static ResourceRequest LoadAsync(string path)
		{
			return Resources.LoadAsync(path, typeof(Object));
		}

		// Token: 0x06001802 RID: 6146 RVA: 0x00027D04 File Offset: 0x00025F04
		public static ResourceRequest LoadAsync<T>(string path) where T : Object
		{
			return Resources.LoadAsync(path, typeof(T));
		}

		// Token: 0x06001803 RID: 6147 RVA: 0x00027D28 File Offset: 0x00025F28
		public static ResourceRequest LoadAsync(string path, Type type)
		{
			return ResourcesAPI.ActiveAPI.LoadAsync(path, type);
		}

		// Token: 0x06001804 RID: 6148 RVA: 0x00027D48 File Offset: 0x00025F48
		public static Object[] LoadAll(string path, Type systemTypeInstance)
		{
			return ResourcesAPI.ActiveAPI.LoadAll(path, systemTypeInstance);
		}

		// Token: 0x06001805 RID: 6149 RVA: 0x00027D68 File Offset: 0x00025F68
		public static Object[] LoadAll(string path)
		{
			return Resources.LoadAll(path, typeof(Object));
		}

		// Token: 0x06001806 RID: 6150 RVA: 0x00027D8C File Offset: 0x00025F8C
		public static T[] LoadAll<T>(string path) where T : Object
		{
			return Resources.ConvertObjects<T>(Resources.LoadAll(path, typeof(T)));
		}

		// Token: 0x06001807 RID: 6151
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		[FreeFunction("GetScriptingBuiltinResource", ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern Object GetBuiltinResource([NotNull("ArgumentNullException")] Type type, string path);

		// Token: 0x06001808 RID: 6152 RVA: 0x00027DB4 File Offset: 0x00025FB4
		public static T GetBuiltinResource<T>(string path) where T : Object
		{
			return (T)((object)Resources.GetBuiltinResource(typeof(T), path));
		}

		// Token: 0x06001809 RID: 6153 RVA: 0x00027DDB File Offset: 0x00025FDB
		public static void UnloadAsset(Object assetToUnload)
		{
			ResourcesAPI.ActiveAPI.UnloadAsset(assetToUnload);
		}

		// Token: 0x0600180A RID: 6154
		[FreeFunction("Scripting::UnloadAssetFromScripting")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void UnloadAssetImplResourceManager(Object assetToUnload);

		// Token: 0x0600180B RID: 6155
		[FreeFunction("Resources_Bindings::UnloadUnusedAssets")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern AsyncOperation UnloadUnusedAssets();

		// Token: 0x0600180C RID: 6156
		[FreeFunction("Resources_Bindings::InstanceIDToObject")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern Object InstanceIDToObject(int instanceID);

		// Token: 0x0600180D RID: 6157
		[FreeFunction("Resources_Bindings::InstanceIDToObjectList", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InstanceIDToObjectList(IntPtr instanceIDs, int instanceCount, List<Object> objects);

		// Token: 0x0600180E RID: 6158 RVA: 0x00027DEC File Offset: 0x00025FEC
		public static void InstanceIDToObjectList(NativeArray<int> instanceIDs, List<Object> objects)
		{
			bool flag = !instanceIDs.IsCreated;
			if (flag)
			{
				throw new ArgumentException("NativeArray is uninitialized", "instanceIDs");
			}
			bool flag2 = objects == null;
			if (flag2)
			{
				throw new ArgumentNullException("objects");
			}
			bool flag3 = instanceIDs.Length == 0;
			if (flag3)
			{
				objects.Clear();
			}
			else
			{
				Resources.InstanceIDToObjectList((IntPtr)instanceIDs.GetUnsafeReadOnlyPtr<int>(), instanceIDs.Length, objects);
			}
		}

		// Token: 0x0600180F RID: 6159
		[FreeFunction("Resources_Bindings::InstanceIDsToValidArray", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InstanceIDsToValidArray_Internal(IntPtr instanceIDs, int instanceCount, IntPtr validArray, int validArrayCount);

		// Token: 0x06001810 RID: 6160
		[FreeFunction("Resources_Bindings::DoesObjectWithInstanceIDExist", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool InstanceIDIsValid(int instanceId);

		// Token: 0x06001811 RID: 6161 RVA: 0x00027E5C File Offset: 0x0002605C
		public static void InstanceIDsToValidArray(NativeArray<int> instanceIDs, NativeArray<bool> validArray)
		{
			bool flag = !instanceIDs.IsCreated;
			if (flag)
			{
				throw new ArgumentException("NativeArray is uninitialized", "instanceIDs");
			}
			bool flag2 = !validArray.IsCreated;
			if (flag2)
			{
				throw new ArgumentException("NativeArray is uninitialized", "validArray");
			}
			bool flag3 = instanceIDs.Length != validArray.Length;
			if (flag3)
			{
				throw new ArgumentException("Size mismatch! Both arrays must be the same length.");
			}
			bool flag4 = instanceIDs.Length == 0;
			if (!flag4)
			{
				Resources.InstanceIDsToValidArray_Internal((IntPtr)instanceIDs.GetUnsafeReadOnlyPtr<int>(), instanceIDs.Length, (IntPtr)validArray.GetUnsafePtr<bool>(), validArray.Length);
			}
		}

		// Token: 0x06001812 RID: 6162 RVA: 0x00027F04 File Offset: 0x00026104
		public unsafe static void InstanceIDsToValidArray(ReadOnlySpan<int> instanceIDs, Span<bool> validArray)
		{
			bool flag = instanceIDs.Length != validArray.Length;
			if (flag)
			{
				throw new ArgumentException("Size mismatch! Both arrays must be the same length.");
			}
			bool flag2 = instanceIDs.Length == 0;
			if (!flag2)
			{
				fixed (int* pinnableReference = instanceIDs.GetPinnableReference())
				{
					int* value = pinnableReference;
					fixed (bool* pinnableReference2 = validArray.GetPinnableReference())
					{
						bool* value2 = pinnableReference2;
						Resources.InstanceIDsToValidArray_Internal((IntPtr)((void*)value), instanceIDs.Length, (IntPtr)((void*)value2), validArray.Length);
					}
				}
			}
		}
	}
}
