using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngineInternal;

namespace UnityEngine
{
	// Token: 0x0200024A RID: 586
	[UsedByNativeCode]
	[ExcludeFromPreset]
	[NativeHeader("Runtime/Export/Scripting/GameObject.bindings.h")]
	public sealed class GameObject : Object
	{
		// Token: 0x060018C6 RID: 6342
		[FreeFunction("GameObjectBindings::CreatePrimitive")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern GameObject CreatePrimitive(PrimitiveType type);

		// Token: 0x060018C7 RID: 6343 RVA: 0x0002993C File Offset: 0x00027B3C
		[SecuritySafeCritical]
		public unsafe T GetComponent<T>()
		{
			CastHelper<T> castHelper = default(CastHelper<T>);
			this.GetComponentFastPath(typeof(T), new IntPtr((void*)(&castHelper.onePointerFurtherThanT)));
			return castHelper.t;
		}

		// Token: 0x060018C8 RID: 6344
		[FreeFunction(Name = "GameObjectBindings::GetComponentFromType", HasExplicitThis = true, ThrowsException = true)]
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern Component GetComponent(Type type);

		// Token: 0x060018C9 RID: 6345
		[FreeFunction(Name = "GameObjectBindings::GetComponentFastPath", HasExplicitThis = true, ThrowsException = true)]
		[NativeWritableSelf]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void GetComponentFastPath(Type type, IntPtr oneFurtherThanResultValue);

		// Token: 0x060018CA RID: 6346
		[FreeFunction(Name = "Scripting::GetScriptingWrapperOfComponentOfGameObject", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern Component GetComponentByName(string type);

		// Token: 0x060018CB RID: 6347
		[FreeFunction(Name = "Scripting::GetScriptingWrapperOfComponentOfGameObjectWithCase", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern Component GetComponentByNameWithCase(string type, bool caseSensitive);

		// Token: 0x060018CC RID: 6348 RVA: 0x0002997C File Offset: 0x00027B7C
		public Component GetComponent(string type)
		{
			return this.GetComponentByName(type);
		}

		// Token: 0x060018CD RID: 6349
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		[FreeFunction(Name = "GameObjectBindings::GetComponentInChildren", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern Component GetComponentInChildren(Type type, bool includeInactive);

		// Token: 0x060018CE RID: 6350 RVA: 0x00029998 File Offset: 0x00027B98
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public Component GetComponentInChildren(Type type)
		{
			return this.GetComponentInChildren(type, false);
		}

		// Token: 0x060018CF RID: 6351 RVA: 0x000299B4 File Offset: 0x00027BB4
		[ExcludeFromDocs]
		public T GetComponentInChildren<T>()
		{
			bool includeInactive = false;
			return this.GetComponentInChildren<T>(includeInactive);
		}

		// Token: 0x060018D0 RID: 6352 RVA: 0x000299D0 File Offset: 0x00027BD0
		public T GetComponentInChildren<T>([DefaultValue("false")] bool includeInactive)
		{
			return (T)((object)this.GetComponentInChildren(typeof(T), includeInactive));
		}

		// Token: 0x060018D1 RID: 6353
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		[FreeFunction(Name = "GameObjectBindings::GetComponentInParent", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern Component GetComponentInParent(Type type, bool includeInactive);

		// Token: 0x060018D2 RID: 6354 RVA: 0x000299F8 File Offset: 0x00027BF8
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public Component GetComponentInParent(Type type)
		{
			return this.GetComponentInParent(type, false);
		}

		// Token: 0x060018D3 RID: 6355 RVA: 0x00029A14 File Offset: 0x00027C14
		[ExcludeFromDocs]
		public T GetComponentInParent<T>()
		{
			bool includeInactive = false;
			return this.GetComponentInParent<T>(includeInactive);
		}

		// Token: 0x060018D4 RID: 6356 RVA: 0x00029A30 File Offset: 0x00027C30
		public T GetComponentInParent<T>([DefaultValue("false")] bool includeInactive)
		{
			return (T)((object)this.GetComponentInParent(typeof(T), includeInactive));
		}

		// Token: 0x060018D5 RID: 6357
		[FreeFunction(Name = "GameObjectBindings::GetComponentsInternal", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern Array GetComponentsInternal(Type type, bool useSearchTypeAsArrayReturnType, bool recursive, bool includeInactive, bool reverse, object resultList);

		// Token: 0x060018D6 RID: 6358 RVA: 0x00029A58 File Offset: 0x00027C58
		public Component[] GetComponents(Type type)
		{
			return (Component[])this.GetComponentsInternal(type, false, false, true, false, null);
		}

		// Token: 0x060018D7 RID: 6359 RVA: 0x00029A7C File Offset: 0x00027C7C
		public T[] GetComponents<T>()
		{
			return (T[])this.GetComponentsInternal(typeof(T), true, false, true, false, null);
		}

		// Token: 0x060018D8 RID: 6360 RVA: 0x00029AA8 File Offset: 0x00027CA8
		public void GetComponents(Type type, List<Component> results)
		{
			this.GetComponentsInternal(type, false, false, true, false, results);
		}

		// Token: 0x060018D9 RID: 6361 RVA: 0x00029AB8 File Offset: 0x00027CB8
		public void GetComponents<T>(List<T> results)
		{
			this.GetComponentsInternal(typeof(T), true, false, true, false, results);
		}

		// Token: 0x060018DA RID: 6362 RVA: 0x00029AD4 File Offset: 0x00027CD4
		[ExcludeFromDocs]
		public Component[] GetComponentsInChildren(Type type)
		{
			bool includeInactive = false;
			return this.GetComponentsInChildren(type, includeInactive);
		}

		// Token: 0x060018DB RID: 6363 RVA: 0x00029AF0 File Offset: 0x00027CF0
		public Component[] GetComponentsInChildren(Type type, [DefaultValue("false")] bool includeInactive)
		{
			return (Component[])this.GetComponentsInternal(type, false, true, includeInactive, false, null);
		}

		// Token: 0x060018DC RID: 6364 RVA: 0x00029B14 File Offset: 0x00027D14
		public T[] GetComponentsInChildren<T>(bool includeInactive)
		{
			return (T[])this.GetComponentsInternal(typeof(T), true, true, includeInactive, false, null);
		}

		// Token: 0x060018DD RID: 6365 RVA: 0x00029B40 File Offset: 0x00027D40
		public void GetComponentsInChildren<T>(bool includeInactive, List<T> results)
		{
			this.GetComponentsInternal(typeof(T), true, true, includeInactive, false, results);
		}

		// Token: 0x060018DE RID: 6366 RVA: 0x00029B5C File Offset: 0x00027D5C
		public T[] GetComponentsInChildren<T>()
		{
			return this.GetComponentsInChildren<T>(false);
		}

		// Token: 0x060018DF RID: 6367 RVA: 0x00029B75 File Offset: 0x00027D75
		public void GetComponentsInChildren<T>(List<T> results)
		{
			this.GetComponentsInChildren<T>(false, results);
		}

		// Token: 0x060018E0 RID: 6368 RVA: 0x00029B84 File Offset: 0x00027D84
		[ExcludeFromDocs]
		public Component[] GetComponentsInParent(Type type)
		{
			bool includeInactive = false;
			return this.GetComponentsInParent(type, includeInactive);
		}

		// Token: 0x060018E1 RID: 6369 RVA: 0x00029BA0 File Offset: 0x00027DA0
		public Component[] GetComponentsInParent(Type type, [DefaultValue("false")] bool includeInactive)
		{
			return (Component[])this.GetComponentsInternal(type, false, true, includeInactive, true, null);
		}

		// Token: 0x060018E2 RID: 6370 RVA: 0x00029BC3 File Offset: 0x00027DC3
		public void GetComponentsInParent<T>(bool includeInactive, List<T> results)
		{
			this.GetComponentsInternal(typeof(T), true, true, includeInactive, true, results);
		}

		// Token: 0x060018E3 RID: 6371 RVA: 0x00029BDC File Offset: 0x00027DDC
		public T[] GetComponentsInParent<T>(bool includeInactive)
		{
			return (T[])this.GetComponentsInternal(typeof(T), true, true, includeInactive, true, null);
		}

		// Token: 0x060018E4 RID: 6372 RVA: 0x00029C08 File Offset: 0x00027E08
		public T[] GetComponentsInParent<T>()
		{
			return this.GetComponentsInParent<T>(false);
		}

		// Token: 0x060018E5 RID: 6373 RVA: 0x00029C24 File Offset: 0x00027E24
		[SecuritySafeCritical]
		public unsafe bool TryGetComponent<T>(out T component)
		{
			CastHelper<T> castHelper = default(CastHelper<T>);
			this.TryGetComponentFastPath(typeof(T), new IntPtr((void*)(&castHelper.onePointerFurtherThanT)));
			component = castHelper.t;
			return castHelper.t != null;
		}

		// Token: 0x060018E6 RID: 6374 RVA: 0x00029C78 File Offset: 0x00027E78
		public bool TryGetComponent(Type type, out Component component)
		{
			component = this.TryGetComponentInternal(type);
			return component != null;
		}

		// Token: 0x060018E7 RID: 6375
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		[FreeFunction(Name = "GameObjectBindings::TryGetComponentFromType", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern Component TryGetComponentInternal(Type type);

		// Token: 0x060018E8 RID: 6376
		[NativeWritableSelf]
		[FreeFunction(Name = "GameObjectBindings::TryGetComponentFastPath", HasExplicitThis = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void TryGetComponentFastPath(Type type, IntPtr oneFurtherThanResultValue);

		// Token: 0x060018E9 RID: 6377 RVA: 0x00029C9C File Offset: 0x00027E9C
		public static GameObject FindWithTag(string tag)
		{
			return GameObject.FindGameObjectWithTag(tag);
		}

		// Token: 0x060018EA RID: 6378 RVA: 0x00029CB4 File Offset: 0x00027EB4
		public void SendMessageUpwards(string methodName, SendMessageOptions options)
		{
			this.SendMessageUpwards(methodName, null, options);
		}

		// Token: 0x060018EB RID: 6379 RVA: 0x00029CC1 File Offset: 0x00027EC1
		public void SendMessage(string methodName, SendMessageOptions options)
		{
			this.SendMessage(methodName, null, options);
		}

		// Token: 0x060018EC RID: 6380 RVA: 0x00029CCE File Offset: 0x00027ECE
		public void BroadcastMessage(string methodName, SendMessageOptions options)
		{
			this.BroadcastMessage(methodName, null, options);
		}

		// Token: 0x060018ED RID: 6381
		[FreeFunction(Name = "MonoAddComponent", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern Component AddComponentInternal(string className);

		// Token: 0x060018EE RID: 6382
		[FreeFunction(Name = "MonoAddComponentWithType", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern Component Internal_AddComponentWithType(Type componentType);

		// Token: 0x060018EF RID: 6383 RVA: 0x00029CDC File Offset: 0x00027EDC
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public Component AddComponent(Type componentType)
		{
			return this.Internal_AddComponentWithType(componentType);
		}

		// Token: 0x060018F0 RID: 6384 RVA: 0x00029CF8 File Offset: 0x00027EF8
		public T AddComponent<T>() where T : Component
		{
			return this.AddComponent(typeof(T)) as T;
		}

		// Token: 0x060018F1 RID: 6385
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int GetComponentCount();

		// Token: 0x060018F2 RID: 6386
		[NativeName("QueryComponentAtIndex<Unity::Component>")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern Component QueryComponentAtIndex(int index);

		// Token: 0x060018F3 RID: 6387 RVA: 0x00029D24 File Offset: 0x00027F24
		public Component GetComponentAtIndex(int index)
		{
			bool flag = index < 0 || index >= this.GetComponentCount();
			if (flag)
			{
				throw new ArgumentOutOfRangeException("index", "Valid range is 0 to GetComponentCount() - 1.");
			}
			return this.QueryComponentAtIndex(index);
		}

		// Token: 0x060018F4 RID: 6388 RVA: 0x00029D64 File Offset: 0x00027F64
		public T GetComponentAtIndex<T>(int index) where T : Component
		{
			T t = (T)((object)this.GetComponentAtIndex(index));
			bool flag = t == null;
			if (flag)
			{
				throw new InvalidCastException();
			}
			return t;
		}

		// Token: 0x060018F5 RID: 6389
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int GetComponentIndex(Component component);

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x060018F6 RID: 6390
		public extern Transform transform { [FreeFunction("GameObjectBindings::GetTransform", HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x060018F7 RID: 6391
		// (set) Token: 0x060018F8 RID: 6392
		public extern int layer { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x060018F9 RID: 6393
		// (set) Token: 0x060018FA RID: 6394
		[Obsolete("GameObject.active is obsolete. Use GameObject.SetActive(), GameObject.activeSelf or GameObject.activeInHierarchy.")]
		public extern bool active { [NativeMethod(Name = "IsActive")] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeMethod(Name = "SetSelfActive")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x060018FB RID: 6395
		[NativeMethod(Name = "SetSelfActive")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetActive(bool value);

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x060018FC RID: 6396
		public extern bool activeSelf { [NativeMethod(Name = "IsSelfActive")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x060018FD RID: 6397
		public extern bool activeInHierarchy { [NativeMethod(Name = "IsActive")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x060018FE RID: 6398
		[Obsolete("gameObject.SetActiveRecursively() is obsolete. Use GameObject.SetActive(), which is now inherited by children.")]
		[NativeMethod(Name = "SetActiveRecursivelyDeprecated")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SetActiveRecursively(bool state);

		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x060018FF RID: 6399
		// (set) Token: 0x06001900 RID: 6400
		public extern bool isStatic { [NativeMethod(Name = "GetIsStaticDeprecated")] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeMethod(Name = "SetIsStaticDeprecated")] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x06001901 RID: 6401
		internal extern bool isStaticBatchable { [NativeMethod(Name = "IsStaticBatchable")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x06001902 RID: 6402
		// (set) Token: 0x06001903 RID: 6403
		public extern string tag { [FreeFunction("GameObjectBindings::GetTag", HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; [FreeFunction("GameObjectBindings::SetTag", HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x06001904 RID: 6404
		[FreeFunction(Name = "GameObjectBindings::CompareTag", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool CompareTag(string tag);

		// Token: 0x06001905 RID: 6405
		[FreeFunction(Name = "GameObjectBindings::FindGameObjectWithTag", ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern GameObject FindGameObjectWithTag(string tag);

		// Token: 0x06001906 RID: 6406
		[FreeFunction(Name = "GameObjectBindings::FindGameObjectsWithTag", ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern GameObject[] FindGameObjectsWithTag(string tag);

		// Token: 0x06001907 RID: 6407
		[FreeFunction(Name = "Scripting::SendScriptingMessageUpwards", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SendMessageUpwards(string methodName, [DefaultValue("null")] object value, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

		// Token: 0x06001908 RID: 6408 RVA: 0x00029D9C File Offset: 0x00027F9C
		[ExcludeFromDocs]
		public void SendMessageUpwards(string methodName, object value)
		{
			SendMessageOptions options = SendMessageOptions.RequireReceiver;
			this.SendMessageUpwards(methodName, value, options);
		}

		// Token: 0x06001909 RID: 6409 RVA: 0x00029DB8 File Offset: 0x00027FB8
		[ExcludeFromDocs]
		public void SendMessageUpwards(string methodName)
		{
			SendMessageOptions options = SendMessageOptions.RequireReceiver;
			object value = null;
			this.SendMessageUpwards(methodName, value, options);
		}

		// Token: 0x0600190A RID: 6410
		[FreeFunction(Name = "Scripting::SendScriptingMessage", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SendMessage(string methodName, [DefaultValue("null")] object value, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

		// Token: 0x0600190B RID: 6411 RVA: 0x00029DD4 File Offset: 0x00027FD4
		[ExcludeFromDocs]
		public void SendMessage(string methodName, object value)
		{
			SendMessageOptions options = SendMessageOptions.RequireReceiver;
			this.SendMessage(methodName, value, options);
		}

		// Token: 0x0600190C RID: 6412 RVA: 0x00029DF0 File Offset: 0x00027FF0
		[ExcludeFromDocs]
		public void SendMessage(string methodName)
		{
			SendMessageOptions options = SendMessageOptions.RequireReceiver;
			object value = null;
			this.SendMessage(methodName, value, options);
		}

		// Token: 0x0600190D RID: 6413
		[FreeFunction(Name = "Scripting::BroadcastScriptingMessage", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void BroadcastMessage(string methodName, [DefaultValue("null")] object parameter, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

		// Token: 0x0600190E RID: 6414 RVA: 0x00029E0C File Offset: 0x0002800C
		[ExcludeFromDocs]
		public void BroadcastMessage(string methodName, object parameter)
		{
			SendMessageOptions options = SendMessageOptions.RequireReceiver;
			this.BroadcastMessage(methodName, parameter, options);
		}

		// Token: 0x0600190F RID: 6415 RVA: 0x00029E28 File Offset: 0x00028028
		[ExcludeFromDocs]
		public void BroadcastMessage(string methodName)
		{
			SendMessageOptions options = SendMessageOptions.RequireReceiver;
			object parameter = null;
			this.BroadcastMessage(methodName, parameter, options);
		}

		// Token: 0x06001910 RID: 6416 RVA: 0x00029E44 File Offset: 0x00028044
		public GameObject(string name)
		{
			GameObject.Internal_CreateGameObject(this, name);
		}

		// Token: 0x06001911 RID: 6417 RVA: 0x00029E56 File Offset: 0x00028056
		public GameObject()
		{
			GameObject.Internal_CreateGameObject(this, null);
		}

		// Token: 0x06001912 RID: 6418 RVA: 0x00029E68 File Offset: 0x00028068
		public GameObject(string name, params Type[] components)
		{
			GameObject.Internal_CreateGameObject(this, name);
			foreach (Type componentType in components)
			{
				this.AddComponent(componentType);
			}
		}

		// Token: 0x06001913 RID: 6419
		[FreeFunction(Name = "GameObjectBindings::Internal_CreateGameObject")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_CreateGameObject([Writable] GameObject self, string name);

		// Token: 0x06001914 RID: 6420
		[FreeFunction(Name = "GameObjectBindings::Find")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern GameObject Find(string name);

		// Token: 0x06001915 RID: 6421
		[FreeFunction(Name = "GameObjectBindings::SetGameObjectsActiveByInstanceID")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetGameObjectsActive(IntPtr instanceIds, int instanceCount, bool active);

		// Token: 0x06001916 RID: 6422 RVA: 0x00029EA4 File Offset: 0x000280A4
		public static void SetGameObjectsActive(NativeArray<int> instanceIDs, bool active)
		{
			bool flag = !instanceIDs.IsCreated;
			if (flag)
			{
				throw new ArgumentException("NativeArray is uninitialized", "instanceIDs");
			}
			bool flag2 = instanceIDs.Length == 0;
			if (!flag2)
			{
				GameObject.SetGameObjectsActive((IntPtr)instanceIDs.GetUnsafeReadOnlyPtr<int>(), instanceIDs.Length, active);
			}
		}

		// Token: 0x06001917 RID: 6423 RVA: 0x00029EFC File Offset: 0x000280FC
		public unsafe static void SetGameObjectsActive(ReadOnlySpan<int> instanceIDs, bool active)
		{
			bool flag = instanceIDs.Length == 0;
			if (!flag)
			{
				fixed (int* pinnableReference = instanceIDs.GetPinnableReference())
				{
					int* value = pinnableReference;
					GameObject.SetGameObjectsActive((IntPtr)((void*)value), instanceIDs.Length, active);
				}
			}
		}

		// Token: 0x06001918 RID: 6424 RVA: 0x00029F3E File Offset: 0x0002813E
		[FreeFunction("GameObjectBindings::InstantiateGameObjectsByInstanceID")]
		private static void InstantiateGameObjects(int sourceInstanceID, IntPtr newInstanceIDs, IntPtr newTransformInstanceIDs, int count, Scene destinationScene)
		{
			GameObject.InstantiateGameObjects_Injected(sourceInstanceID, newInstanceIDs, newTransformInstanceIDs, count, ref destinationScene);
		}

		// Token: 0x06001919 RID: 6425 RVA: 0x00029F4C File Offset: 0x0002814C
		public static void InstantiateGameObjects(int sourceInstanceID, int count, NativeArray<int> newInstanceIDs, NativeArray<int> newTransformInstanceIDs, Scene destinationScene = default(Scene))
		{
			bool flag = !newInstanceIDs.IsCreated;
			if (flag)
			{
				throw new ArgumentException("NativeArray is uninitialized", "newInstanceIDs");
			}
			bool flag2 = !newTransformInstanceIDs.IsCreated;
			if (flag2)
			{
				throw new ArgumentException("NativeArray is uninitialized", "newTransformInstanceIDs");
			}
			bool flag3 = count == 0;
			if (!flag3)
			{
				bool flag4 = count != newInstanceIDs.Length || count != newTransformInstanceIDs.Length;
				if (flag4)
				{
					throw new ArgumentException("Size mismatch! Both arrays must already be the size of count.");
				}
				GameObject.InstantiateGameObjects(sourceInstanceID, (IntPtr)newInstanceIDs.GetUnsafeReadOnlyPtr<int>(), (IntPtr)newTransformInstanceIDs.GetUnsafeReadOnlyPtr<int>(), newInstanceIDs.Length, destinationScene);
			}
		}

		// Token: 0x0600191A RID: 6426 RVA: 0x00029FF0 File Offset: 0x000281F0
		[FreeFunction(Name = "GameObjectBindings::GetSceneByInstanceID")]
		public static Scene GetScene(int instanceID)
		{
			Scene result;
			GameObject.GetScene_Injected(instanceID, out result);
			return result;
		}

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x0600191B RID: 6427 RVA: 0x0002A008 File Offset: 0x00028208
		public Scene scene
		{
			[FreeFunction("GameObjectBindings::GetScene", HasExplicitThis = true)]
			get
			{
				Scene result;
				this.get_scene_Injected(out result);
				return result;
			}
		}

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x0600191C RID: 6428
		public extern ulong sceneCullingMask { [FreeFunction(Name = "GameObjectBindings::GetSceneCullingMask", HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x0600191D RID: 6429 RVA: 0x0002A020 File Offset: 0x00028220
		public GameObject gameObject
		{
			get
			{
				return this;
			}
		}

		// Token: 0x0600191E RID: 6430
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InstantiateGameObjects_Injected(int sourceInstanceID, IntPtr newInstanceIDs, IntPtr newTransformInstanceIDs, int count, ref Scene destinationScene);

		// Token: 0x0600191F RID: 6431
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetScene_Injected(int instanceID, out Scene ret);

		// Token: 0x06001920 RID: 6432
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void get_scene_Injected(out Scene ret);
	}
}
