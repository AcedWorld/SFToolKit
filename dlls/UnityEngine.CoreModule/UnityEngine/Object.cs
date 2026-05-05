using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngineInternal;

namespace UnityEngine
{
	// Token: 0x0200026B RID: 619
	[RequiredByNativeCode(GenerateProxy = true)]
	[NativeHeader("Runtime/Export/Scripting/UnityEngineObject.bindings.h")]
	[NativeHeader("Runtime/GameCode/CloneObject.h")]
	[NativeHeader("Runtime/SceneManager/SceneManager.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class Object
	{
		// Token: 0x060019AD RID: 6573 RVA: 0x0002B2B4 File Offset: 0x000294B4
		[SecuritySafeCritical]
		public unsafe int GetInstanceID()
		{
			bool flag = this.m_CachedPtr == IntPtr.Zero;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				bool flag2 = Object.OffsetOfInstanceIDInCPlusPlusObject == -1;
				if (flag2)
				{
					Object.OffsetOfInstanceIDInCPlusPlusObject = Object.GetOffsetOfInstanceIDInCPlusPlusObject();
				}
				result = *(int*)((void*)new IntPtr(this.m_CachedPtr.ToInt64() + (long)Object.OffsetOfInstanceIDInCPlusPlusObject));
			}
			return result;
		}

		// Token: 0x060019AE RID: 6574 RVA: 0x0002B314 File Offset: 0x00029514
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x060019AF RID: 6575 RVA: 0x0002B32C File Offset: 0x0002952C
		public override bool Equals(object other)
		{
			Object @object = other as Object;
			bool flag = @object == null && other != null && !(other is Object);
			return !flag && Object.CompareBaseObjects(this, @object);
		}

		// Token: 0x060019B0 RID: 6576 RVA: 0x0002B370 File Offset: 0x00029570
		public static implicit operator bool(Object exists)
		{
			return !Object.CompareBaseObjects(exists, null);
		}

		// Token: 0x060019B1 RID: 6577 RVA: 0x0002B38C File Offset: 0x0002958C
		private static bool CompareBaseObjects(Object lhs, Object rhs)
		{
			bool flag = lhs == null;
			bool flag2 = rhs == null;
			bool flag3 = flag2 && flag;
			bool result;
			if (flag3)
			{
				result = true;
			}
			else
			{
				bool flag4 = flag2;
				if (flag4)
				{
					result = !Object.IsNativeObjectAlive(lhs);
				}
				else
				{
					bool flag5 = flag;
					if (flag5)
					{
						result = !Object.IsNativeObjectAlive(rhs);
					}
					else
					{
						result = (lhs == rhs);
					}
				}
			}
			return result;
		}

		// Token: 0x060019B2 RID: 6578 RVA: 0x0002B3E0 File Offset: 0x000295E0
		private void EnsureRunningOnMainThread()
		{
			bool flag = !Object.CurrentThreadIsMainThread();
			if (flag)
			{
				throw new InvalidOperationException("EnsureRunningOnMainThread can only be called from the main thread");
			}
		}

		// Token: 0x060019B3 RID: 6579 RVA: 0x0002B408 File Offset: 0x00029608
		private static bool IsNativeObjectAlive(Object o)
		{
			return o.GetCachedPtr() != IntPtr.Zero;
		}

		// Token: 0x060019B4 RID: 6580 RVA: 0x0002B42C File Offset: 0x0002962C
		private IntPtr GetCachedPtr()
		{
			return this.m_CachedPtr;
		}

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x060019B5 RID: 6581 RVA: 0x0002B444 File Offset: 0x00029644
		// (set) Token: 0x060019B6 RID: 6582 RVA: 0x0002B45C File Offset: 0x0002965C
		public string name
		{
			get
			{
				return Object.GetName(this);
			}
			set
			{
				Object.SetName(this, value);
			}
		}

		// Token: 0x060019B7 RID: 6583 RVA: 0x0002B468 File Offset: 0x00029668
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original) where T : Object
		{
			return Object.InstantiateAsync<T>(original, new InstantiateParameters
			{
				worldSpace = true
			});
		}

		// Token: 0x060019B8 RID: 6584 RVA: 0x0002B494 File Offset: 0x00029694
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, Transform parent) where T : Object
		{
			return Object.InstantiateAsync<T>(original, new InstantiateParameters
			{
				worldSpace = true,
				parent = parent
			});
		}

		// Token: 0x060019B9 RID: 6585 RVA: 0x0002B4C8 File Offset: 0x000296C8
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, Vector3 position, Quaternion rotation) where T : Object
		{
			return Object.InstantiateAsync<T>(original, position, rotation, new InstantiateParameters
			{
				worldSpace = true
			});
		}

		// Token: 0x060019BA RID: 6586 RVA: 0x0002B4F4 File Offset: 0x000296F4
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, Transform parent, Vector3 position, Quaternion rotation) where T : Object
		{
			return Object.InstantiateAsync<T>(original, position, rotation, new InstantiateParameters
			{
				worldSpace = true,
				parent = parent
			});
		}

		// Token: 0x060019BB RID: 6587 RVA: 0x0002B528 File Offset: 0x00029728
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count) where T : Object
		{
			return Object.InstantiateAsync<T>(original, count, new InstantiateParameters
			{
				worldSpace = true
			});
		}

		// Token: 0x060019BC RID: 6588 RVA: 0x0002B554 File Offset: 0x00029754
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, Transform parent) where T : Object
		{
			return Object.InstantiateAsync<T>(original, count, new InstantiateParameters
			{
				worldSpace = true,
				parent = parent
			});
		}

		// Token: 0x060019BD RID: 6589 RVA: 0x0002B588 File Offset: 0x00029788
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, Vector3 position, Quaternion rotation) where T : Object
		{
			return Object.InstantiateAsync<T>(original, count, position, rotation, new InstantiateParameters
			{
				worldSpace = true
			});
		}

		// Token: 0x060019BE RID: 6590 RVA: 0x0002B5B4 File Offset: 0x000297B4
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, ReadOnlySpan<Vector3> positions, ReadOnlySpan<Quaternion> rotations) where T : Object
		{
			return Object.InstantiateAsync<T>(original, count, positions, rotations, new InstantiateParameters
			{
				worldSpace = true
			});
		}

		// Token: 0x060019BF RID: 6591 RVA: 0x0002B5E0 File Offset: 0x000297E0
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, Transform parent, Vector3 position, Quaternion rotation) where T : Object
		{
			return Object.InstantiateAsync<T>(original, count, position, rotation, new InstantiateParameters
			{
				worldSpace = true,
				parent = parent
			});
		}

		// Token: 0x060019C0 RID: 6592 RVA: 0x0002B618 File Offset: 0x00029818
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, Transform parent, ReadOnlySpan<Vector3> positions, ReadOnlySpan<Quaternion> rotations) where T : Object
		{
			return Object.InstantiateAsync<T>(original, count, positions, rotations, new InstantiateParameters
			{
				worldSpace = true,
				parent = parent
			});
		}

		// Token: 0x060019C1 RID: 6593 RVA: 0x0002B650 File Offset: 0x00029850
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, InstantiateParameters parameters) where T : Object
		{
			return Object.InstantiateAsync<T>(original, 1, parameters);
		}

		// Token: 0x060019C2 RID: 6594 RVA: 0x0002B66C File Offset: 0x0002986C
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, InstantiateParameters parameters) where T : Object
		{
			return Object.InstantiateAsync<T>(original, count, ReadOnlySpan<Vector3>.Empty, ReadOnlySpan<Quaternion>.Empty, parameters);
		}

		// Token: 0x060019C3 RID: 6595 RVA: 0x0002B690 File Offset: 0x00029890
		public static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, Vector3 position, Quaternion rotation, InstantiateParameters parameters) where T : Object
		{
			return Object.InstantiateAsync<T>(original, 1, position, rotation, parameters);
		}

		// Token: 0x060019C4 RID: 6596 RVA: 0x0002B6AC File Offset: 0x000298AC
		public unsafe static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, Vector3 position, Quaternion rotation, InstantiateParameters parameters) where T : Object
		{
			return Object.InstantiateAsync<T>(original, count, new ReadOnlySpan<Vector3>((void*)(&position), 1), new ReadOnlySpan<Quaternion>((void*)(&rotation), 1), parameters);
		}

		// Token: 0x060019C5 RID: 6597 RVA: 0x0002B6DC File Offset: 0x000298DC
		[MethodImpl((MethodImplOptions)768)]
		public unsafe static AsyncInstantiateOperation<T> InstantiateAsync<T>(T original, int count, ReadOnlySpan<Vector3> positions, ReadOnlySpan<Quaternion> rotations, InstantiateParameters parameters) where T : Object
		{
			Object.CheckNullArgument(original, "The Object you want to instantiate is null.");
			bool flag = count <= 0;
			if (flag)
			{
				throw new ArgumentException("Cannot call instantiate multiple with count less or equal to zero");
			}
			fixed (Vector3* pinnableReference = positions.GetPinnableReference())
			{
				Vector3* value = pinnableReference;
				fixed (Quaternion* pinnableReference2 = rotations.GetPinnableReference())
				{
					Quaternion* value2 = pinnableReference2;
					AsyncInstantiateOperation op = Object.Internal_InstantiateAsyncWithParams(original, count, parameters, (IntPtr)((void*)value), positions.Length, (IntPtr)((void*)value2), rotations.Length);
					return new AsyncInstantiateOperation<T>(op);
				}
			}
		}

		// Token: 0x060019C6 RID: 6598 RVA: 0x0002B764 File Offset: 0x00029964
		[TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
		public static Object Instantiate(Object original, Vector3 position, Quaternion rotation)
		{
			Object.CheckNullArgument(original, "The Object you want to instantiate is null.");
			bool flag = original is ScriptableObject;
			if (flag)
			{
				throw new ArgumentException("Cannot instantiate a ScriptableObject with a position and rotation");
			}
			Object @object = Object.Internal_InstantiateSingle(original, position, rotation);
			bool flag2 = @object == null;
			if (flag2)
			{
				throw new UnityException("Instantiate failed because the clone was destroyed during creation. This can happen if DestroyImmediate is called in MonoBehaviour.Awake.");
			}
			return @object;
		}

		// Token: 0x060019C7 RID: 6599 RVA: 0x0002B7BC File Offset: 0x000299BC
		[TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
		public static Object Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent)
		{
			bool flag = parent == null;
			Object result;
			if (flag)
			{
				result = Object.Instantiate(original, position, rotation);
			}
			else
			{
				Object.CheckNullArgument(original, "The Object you want to instantiate is null.");
				Object @object = Object.Internal_InstantiateSingleWithParent(original, parent, position, rotation);
				bool flag2 = @object == null;
				if (flag2)
				{
					throw new UnityException("Instantiate failed because the clone was destroyed during creation. This can happen if DestroyImmediate is called in MonoBehaviour.Awake.");
				}
				result = @object;
			}
			return result;
		}

		// Token: 0x060019C8 RID: 6600 RVA: 0x0002B814 File Offset: 0x00029A14
		[TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
		public static Object Instantiate(Object original)
		{
			Object.CheckNullArgument(original, "The Object you want to instantiate is null.");
			Object @object = Object.Internal_CloneSingle(original);
			bool flag = @object == null;
			if (flag)
			{
				throw new UnityException("Instantiate failed because the clone was destroyed during creation. This can happen if DestroyImmediate is called in MonoBehaviour.Awake.");
			}
			return @object;
		}

		// Token: 0x060019C9 RID: 6601 RVA: 0x0002B850 File Offset: 0x00029A50
		[TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
		public static Object Instantiate(Object original, Scene scene)
		{
			Object.CheckNullArgument(original, "The Object you want to instantiate is null.");
			Object @object = Object.Internal_CloneSingleWithScene(original, scene);
			bool flag = @object == null;
			if (flag)
			{
				throw new UnityException("Instantiate failed because the clone was destroyed during creation. This can happen if DestroyImmediate is called in MonoBehaviour.Awake.");
			}
			return @object;
		}

		// Token: 0x060019CA RID: 6602 RVA: 0x0002B890 File Offset: 0x00029A90
		public static T Instantiate<T>(T original, InstantiateParameters parameters) where T : Object
		{
			Object.CheckNullArgument(original, "The Object you want to instantiate is null.");
			T t = (T)((object)Object.Internal_CloneSingleWithParams(original, parameters));
			bool flag = t == null;
			if (flag)
			{
				throw new UnityException("Instantiate failed because the clone was destroyed during creation. This can happen if DestroyImmediate is called in MonoBehaviour.Awake.");
			}
			return t;
		}

		// Token: 0x060019CB RID: 6603 RVA: 0x0002B8E4 File Offset: 0x00029AE4
		public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation, InstantiateParameters parameters) where T : Object
		{
			Object.CheckNullArgument(original, "The Object you want to instantiate is null.");
			T t = (T)((object)Object.Internal_InstantiateSingleWithParams(original, position, rotation, parameters));
			bool flag = t == null;
			if (flag)
			{
				throw new UnityException("Instantiate failed because the clone was destroyed during creation. This can happen if DestroyImmediate is called in MonoBehaviour.Awake.");
			}
			return t;
		}

		// Token: 0x060019CC RID: 6604 RVA: 0x0002B938 File Offset: 0x00029B38
		[TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
		public static Object Instantiate(Object original, Transform parent)
		{
			return Object.Instantiate(original, parent, false);
		}

		// Token: 0x060019CD RID: 6605 RVA: 0x0002B954 File Offset: 0x00029B54
		[TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
		public static Object Instantiate(Object original, Transform parent, bool instantiateInWorldSpace)
		{
			bool flag = parent == null;
			Object result;
			if (flag)
			{
				result = Object.Instantiate(original);
			}
			else
			{
				Object.CheckNullArgument(original, "The Object you want to instantiate is null.");
				Object @object = Object.Internal_CloneSingleWithParent(original, parent, instantiateInWorldSpace);
				bool flag2 = @object == null;
				if (flag2)
				{
					throw new UnityException("Instantiate failed because the clone was destroyed during creation. This can happen if DestroyImmediate is called in MonoBehaviour.Awake.");
				}
				result = @object;
			}
			return result;
		}

		// Token: 0x060019CE RID: 6606 RVA: 0x0002B9A8 File Offset: 0x00029BA8
		public static T Instantiate<T>(T original) where T : Object
		{
			Object.CheckNullArgument(original, "The Object you want to instantiate is null.");
			T t = (T)((object)Object.Internal_CloneSingle(original));
			bool flag = t == null;
			if (flag)
			{
				throw new UnityException("Instantiate failed because the clone was destroyed during creation. This can happen if DestroyImmediate is called in MonoBehaviour.Awake.");
			}
			return t;
		}

		// Token: 0x060019CF RID: 6607 RVA: 0x0002B9F8 File Offset: 0x00029BF8
		public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation) where T : Object
		{
			return (T)((object)Object.Instantiate(original, position, rotation));
		}

		// Token: 0x060019D0 RID: 6608 RVA: 0x0002BA1C File Offset: 0x00029C1C
		public static T Instantiate<T>(T original, Vector3 position, Quaternion rotation, Transform parent) where T : Object
		{
			return (T)((object)Object.Instantiate(original, position, rotation, parent));
		}

		// Token: 0x060019D1 RID: 6609 RVA: 0x0002BA44 File Offset: 0x00029C44
		public static T Instantiate<T>(T original, Transform parent) where T : Object
		{
			return Object.Instantiate<T>(original, parent, false);
		}

		// Token: 0x060019D2 RID: 6610 RVA: 0x0002BA60 File Offset: 0x00029C60
		public static T Instantiate<T>(T original, Transform parent, bool worldPositionStays) where T : Object
		{
			return (T)((object)Object.Instantiate(original, parent, worldPositionStays));
		}

		// Token: 0x060019D3 RID: 6611
		[NativeMethod(Name = "Scripting::DestroyObjectFromScripting", IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Destroy(Object obj, [DefaultValue("0.0F")] float t);

		// Token: 0x060019D4 RID: 6612 RVA: 0x0002BA84 File Offset: 0x00029C84
		[ExcludeFromDocs]
		public static void Destroy(Object obj)
		{
			float t = 0f;
			Object.Destroy(obj, t);
		}

		// Token: 0x060019D5 RID: 6613
		[NativeMethod(Name = "Scripting::DestroyObjectFromScriptingImmediate", IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void DestroyImmediate(Object obj, [DefaultValue("false")] bool allowDestroyingAssets);

		// Token: 0x060019D6 RID: 6614 RVA: 0x0002BAA0 File Offset: 0x00029CA0
		[ExcludeFromDocs]
		public static void DestroyImmediate(Object obj)
		{
			bool allowDestroyingAssets = false;
			Object.DestroyImmediate(obj, allowDestroyingAssets);
		}

		// Token: 0x060019D7 RID: 6615 RVA: 0x0002BAB8 File Offset: 0x00029CB8
		public static Object[] FindObjectsOfType(Type type)
		{
			return Object.FindObjectsOfType(type, false);
		}

		// Token: 0x060019D8 RID: 6616
		[FreeFunction("UnityEngineObjectBindings::FindObjectsOfType")]
		[TypeInferenceRule(TypeInferenceRules.ArrayOfTypeReferencedByFirstArgument)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern Object[] FindObjectsOfType(Type type, bool includeInactive);

		// Token: 0x060019D9 RID: 6617 RVA: 0x0002BAD4 File Offset: 0x00029CD4
		public static Object[] FindObjectsByType(Type type, FindObjectsSortMode sortMode)
		{
			return Object.FindObjectsByType(type, FindObjectsInactive.Exclude, sortMode);
		}

		// Token: 0x060019DA RID: 6618
		[TypeInferenceRule(TypeInferenceRules.ArrayOfTypeReferencedByFirstArgument)]
		[FreeFunction("UnityEngineObjectBindings::FindObjectsByType")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern Object[] FindObjectsByType(Type type, FindObjectsInactive findObjectsInactive, FindObjectsSortMode sortMode);

		// Token: 0x060019DB RID: 6619
		[FreeFunction("GetSceneManager().DontDestroyOnLoad", ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void DontDestroyOnLoad([NotNull("NullExceptionObject")] Object target);

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x060019DC RID: 6620
		// (set) Token: 0x060019DD RID: 6621
		public extern HideFlags hideFlags { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x060019DE RID: 6622 RVA: 0x0002BAEE File Offset: 0x00029CEE
		[Obsolete("use Object.Destroy instead.")]
		public static void DestroyObject(Object obj, [DefaultValue("0.0F")] float t)
		{
			Object.Destroy(obj, t);
		}

		// Token: 0x060019DF RID: 6623 RVA: 0x0002BAFC File Offset: 0x00029CFC
		[Obsolete("use Object.Destroy instead.")]
		[ExcludeFromDocs]
		public static void DestroyObject(Object obj)
		{
			float t = 0f;
			Object.Destroy(obj, t);
		}

		// Token: 0x060019E0 RID: 6624 RVA: 0x0002BB18 File Offset: 0x00029D18
		[Obsolete("warning use Object.FindObjectsByType instead.")]
		public static Object[] FindSceneObjectsOfType(Type type)
		{
			return Object.FindObjectsOfType(type);
		}

		// Token: 0x060019E1 RID: 6625
		[Obsolete("use Resources.FindObjectsOfTypeAll instead.")]
		[FreeFunction("UnityEngineObjectBindings::FindObjectsOfTypeIncludingAssets")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern Object[] FindObjectsOfTypeIncludingAssets(Type type);

		// Token: 0x060019E2 RID: 6626 RVA: 0x0002BB30 File Offset: 0x00029D30
		public static T[] FindObjectsOfType<T>() where T : Object
		{
			return Resources.ConvertObjects<T>(Object.FindObjectsOfType(typeof(T), false));
		}

		// Token: 0x060019E3 RID: 6627 RVA: 0x0002BB58 File Offset: 0x00029D58
		public static T[] FindObjectsByType<T>(FindObjectsSortMode sortMode) where T : Object
		{
			return Resources.ConvertObjects<T>(Object.FindObjectsByType(typeof(T), FindObjectsInactive.Exclude, sortMode));
		}

		// Token: 0x060019E4 RID: 6628 RVA: 0x0002BB80 File Offset: 0x00029D80
		public static T[] FindObjectsOfType<T>(bool includeInactive) where T : Object
		{
			return Resources.ConvertObjects<T>(Object.FindObjectsOfType(typeof(T), includeInactive));
		}

		// Token: 0x060019E5 RID: 6629 RVA: 0x0002BBA8 File Offset: 0x00029DA8
		public static T[] FindObjectsByType<T>(FindObjectsInactive findObjectsInactive, FindObjectsSortMode sortMode) where T : Object
		{
			return Resources.ConvertObjects<T>(Object.FindObjectsByType(typeof(T), findObjectsInactive, sortMode));
		}

		// Token: 0x060019E6 RID: 6630 RVA: 0x0002BBD0 File Offset: 0x00029DD0
		public static T FindObjectOfType<T>() where T : Object
		{
			return (T)((object)Object.FindObjectOfType(typeof(T), false));
		}

		// Token: 0x060019E7 RID: 6631 RVA: 0x0002BBF8 File Offset: 0x00029DF8
		public static T FindObjectOfType<T>(bool includeInactive) where T : Object
		{
			return (T)((object)Object.FindObjectOfType(typeof(T), includeInactive));
		}

		// Token: 0x060019E8 RID: 6632 RVA: 0x0002BC20 File Offset: 0x00029E20
		public static T FindFirstObjectByType<T>() where T : Object
		{
			return (T)((object)Object.FindFirstObjectByType(typeof(T), FindObjectsInactive.Exclude));
		}

		// Token: 0x060019E9 RID: 6633 RVA: 0x0002BC48 File Offset: 0x00029E48
		public static T FindAnyObjectByType<T>() where T : Object
		{
			return (T)((object)Object.FindAnyObjectByType(typeof(T), FindObjectsInactive.Exclude));
		}

		// Token: 0x060019EA RID: 6634 RVA: 0x0002BC70 File Offset: 0x00029E70
		public static T FindFirstObjectByType<T>(FindObjectsInactive findObjectsInactive) where T : Object
		{
			return (T)((object)Object.FindFirstObjectByType(typeof(T), findObjectsInactive));
		}

		// Token: 0x060019EB RID: 6635 RVA: 0x0002BC98 File Offset: 0x00029E98
		public static T FindAnyObjectByType<T>(FindObjectsInactive findObjectsInactive) where T : Object
		{
			return (T)((object)Object.FindAnyObjectByType(typeof(T), findObjectsInactive));
		}

		// Token: 0x060019EC RID: 6636 RVA: 0x0002BCC0 File Offset: 0x00029EC0
		[Obsolete("Please use Resources.FindObjectsOfTypeAll instead")]
		public static Object[] FindObjectsOfTypeAll(Type type)
		{
			return Resources.FindObjectsOfTypeAll(type);
		}

		// Token: 0x060019ED RID: 6637 RVA: 0x0002BCD8 File Offset: 0x00029ED8
		private static void CheckNullArgument(object arg, string message)
		{
			bool flag = arg == null;
			if (flag)
			{
				throw new ArgumentException(message);
			}
		}

		// Token: 0x060019EE RID: 6638 RVA: 0x0002BCF8 File Offset: 0x00029EF8
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public static Object FindObjectOfType(Type type)
		{
			Object[] array = Object.FindObjectsOfType(type, false);
			bool flag = array.Length != 0;
			Object result;
			if (flag)
			{
				result = array[0];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060019EF RID: 6639 RVA: 0x0002BD24 File Offset: 0x00029F24
		public static Object FindFirstObjectByType(Type type)
		{
			Object[] array = Object.FindObjectsByType(type, FindObjectsInactive.Exclude, FindObjectsSortMode.InstanceID);
			return (array.Length != 0) ? array[0] : null;
		}

		// Token: 0x060019F0 RID: 6640 RVA: 0x0002BD4C File Offset: 0x00029F4C
		public static Object FindAnyObjectByType(Type type)
		{
			Object[] array = Object.FindObjectsByType(type, FindObjectsInactive.Exclude, FindObjectsSortMode.None);
			return (array.Length != 0) ? array[0] : null;
		}

		// Token: 0x060019F1 RID: 6641 RVA: 0x0002BD74 File Offset: 0x00029F74
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public static Object FindObjectOfType(Type type, bool includeInactive)
		{
			Object[] array = Object.FindObjectsOfType(type, includeInactive);
			bool flag = array.Length != 0;
			Object result;
			if (flag)
			{
				result = array[0];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060019F2 RID: 6642 RVA: 0x0002BDA0 File Offset: 0x00029FA0
		public static Object FindFirstObjectByType(Type type, FindObjectsInactive findObjectsInactive)
		{
			Object[] array = Object.FindObjectsByType(type, findObjectsInactive, FindObjectsSortMode.InstanceID);
			return (array.Length != 0) ? array[0] : null;
		}

		// Token: 0x060019F3 RID: 6643 RVA: 0x0002BDC8 File Offset: 0x00029FC8
		public static Object FindAnyObjectByType(Type type, FindObjectsInactive findObjectsInactive)
		{
			Object[] array = Object.FindObjectsByType(type, findObjectsInactive, FindObjectsSortMode.None);
			return (array.Length != 0) ? array[0] : null;
		}

		// Token: 0x060019F4 RID: 6644 RVA: 0x0002BDF0 File Offset: 0x00029FF0
		public override string ToString()
		{
			return Object.ToString(this);
		}

		// Token: 0x060019F5 RID: 6645 RVA: 0x0002BE08 File Offset: 0x0002A008
		public static bool operator ==(Object x, Object y)
		{
			return Object.CompareBaseObjects(x, y);
		}

		// Token: 0x060019F6 RID: 6646 RVA: 0x0002BE24 File Offset: 0x0002A024
		public static bool operator !=(Object x, Object y)
		{
			return !Object.CompareBaseObjects(x, y);
		}

		// Token: 0x060019F7 RID: 6647
		[NativeMethod(Name = "Object::GetOffsetOfInstanceIdMember", IsFreeFunction = true, IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetOffsetOfInstanceIDInCPlusPlusObject();

		// Token: 0x060019F8 RID: 6648
		[NativeMethod(Name = "CurrentThreadIsMainThread", IsFreeFunction = true, IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CurrentThreadIsMainThread();

		// Token: 0x060019F9 RID: 6649
		[NativeMethod(Name = "CloneObject", IsFreeFunction = true, ThrowsException = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Object Internal_CloneSingle([NotNull("NullExceptionObject")] Object data);

		// Token: 0x060019FA RID: 6650 RVA: 0x0002BE40 File Offset: 0x0002A040
		[FreeFunction("CloneObjectToScene")]
		private static Object Internal_CloneSingleWithScene([NotNull("ArgumentNullException")] Object data, Scene scene)
		{
			return Object.Internal_CloneSingleWithScene_Injected(data, ref scene);
		}

		// Token: 0x060019FB RID: 6651 RVA: 0x0002BE4A File Offset: 0x0002A04A
		[FreeFunction("CloneObjectWithParams")]
		private static Object Internal_CloneSingleWithParams([NotNull("ArgumentNullException")] Object data, InstantiateParameters parameters)
		{
			return Object.Internal_CloneSingleWithParams_Injected(data, ref parameters);
		}

		// Token: 0x060019FC RID: 6652 RVA: 0x0002BE54 File Offset: 0x0002A054
		[FreeFunction("InstantiateObjectWithParams")]
		private static Object Internal_InstantiateSingleWithParams([NotNull("ArgumentNullException")] Object data, Vector3 position, Quaternion rotation, InstantiateParameters parameters)
		{
			return Object.Internal_InstantiateSingleWithParams_Injected(data, ref position, ref rotation, ref parameters);
		}

		// Token: 0x060019FD RID: 6653
		[FreeFunction("CloneObject")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Object Internal_CloneSingleWithParent([NotNull("NullExceptionObject")] Object data, [NotNull("NullExceptionObject")] Transform parent, bool worldPositionStays);

		// Token: 0x060019FE RID: 6654 RVA: 0x0002BE62 File Offset: 0x0002A062
		[FreeFunction("InstantiateAsyncObjects")]
		private static AsyncInstantiateOperation Internal_InstantiateAsyncWithParams([NotNull("NullExceptionObject")] Object original, int count, InstantiateParameters parameters, IntPtr positions, int positionsCount, IntPtr rotations, int rotationsCount)
		{
			return Object.Internal_InstantiateAsyncWithParams_Injected(original, count, ref parameters, positions, positionsCount, rotations, rotationsCount);
		}

		// Token: 0x060019FF RID: 6655 RVA: 0x0002BE74 File Offset: 0x0002A074
		[FreeFunction("InstantiateObject")]
		private static Object Internal_InstantiateSingle([NotNull("NullExceptionObject")] Object data, Vector3 pos, Quaternion rot)
		{
			return Object.Internal_InstantiateSingle_Injected(data, ref pos, ref rot);
		}

		// Token: 0x06001A00 RID: 6656 RVA: 0x0002BE80 File Offset: 0x0002A080
		[FreeFunction("InstantiateObject")]
		private static Object Internal_InstantiateSingleWithParent([NotNull("NullExceptionObject")] Object data, [NotNull("NullExceptionObject")] Transform parent, Vector3 pos, Quaternion rot)
		{
			return Object.Internal_InstantiateSingleWithParent_Injected(data, parent, ref pos, ref rot);
		}

		// Token: 0x06001A01 RID: 6657
		[FreeFunction("UnityEngineObjectBindings::ToString")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string ToString(Object obj);

		// Token: 0x06001A02 RID: 6658
		[FreeFunction("UnityEngineObjectBindings::GetName")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string GetName([NotNull("NullExceptionObject")] Object obj);

		// Token: 0x06001A03 RID: 6659
		[FreeFunction("UnityEngineObjectBindings::IsPersistent")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool IsPersistent([NotNull("NullExceptionObject")] Object obj);

		// Token: 0x06001A04 RID: 6660
		[FreeFunction("UnityEngineObjectBindings::SetName")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetName([NotNull("NullExceptionObject")] Object obj, string name);

		// Token: 0x06001A05 RID: 6661
		[NativeMethod(Name = "UnityEngineObjectBindings::DoesObjectWithInstanceIDExist", IsFreeFunction = true, IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool DoesObjectWithInstanceIDExist(int instanceID);

		// Token: 0x06001A06 RID: 6662
		[VisibleToOtherModules]
		[FreeFunction("UnityEngineObjectBindings::FindObjectFromInstanceID")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Object FindObjectFromInstanceID(int instanceID);

		// Token: 0x06001A07 RID: 6663
		[FreeFunction("UnityEngineObjectBindings::ForceLoadFromInstanceID")]
		[VisibleToOtherModules]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Object ForceLoadFromInstanceID(int instanceID);

		// Token: 0x06001A08 RID: 6664
		[FreeFunction("UnityEngineObjectBindings::MarkObjectDirty", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void MarkDirty();

		// Token: 0x06001A0B RID: 6667
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Object Internal_CloneSingleWithScene_Injected(Object data, ref Scene scene);

		// Token: 0x06001A0C RID: 6668
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Object Internal_CloneSingleWithParams_Injected(Object data, ref InstantiateParameters parameters);

		// Token: 0x06001A0D RID: 6669
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Object Internal_InstantiateSingleWithParams_Injected(Object data, ref Vector3 position, ref Quaternion rotation, ref InstantiateParameters parameters);

		// Token: 0x06001A0E RID: 6670
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AsyncInstantiateOperation Internal_InstantiateAsyncWithParams_Injected(Object original, int count, ref InstantiateParameters parameters, IntPtr positions, int positionsCount, IntPtr rotations, int rotationsCount);

		// Token: 0x06001A0F RID: 6671
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Object Internal_InstantiateSingle_Injected(Object data, ref Vector3 pos, ref Quaternion rot);

		// Token: 0x06001A10 RID: 6672
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Object Internal_InstantiateSingleWithParent_Injected(Object data, Transform parent, ref Vector3 pos, ref Quaternion rot);

		// Token: 0x040008FE RID: 2302
		private IntPtr m_CachedPtr;

		// Token: 0x040008FF RID: 2303
		internal static int OffsetOfInstanceIDInCPlusPlusObject = -1;

		// Token: 0x04000900 RID: 2304
		private const string objectIsNullMessage = "The Object you want to instantiate is null.";

		// Token: 0x04000901 RID: 2305
		private const string cloneDestroyedMessage = "Instantiate failed because the clone was destroyed during creation. This can happen if DestroyImmediate is called in MonoBehaviour.Awake.";
	}
}
