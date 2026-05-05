using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x020001FB RID: 507
	[StaticAccessor("GetObjectDispatcher()", StaticAccessorType.Dot)]
	[RequiredByNativeCode]
	[NativeHeader("Runtime/Misc/ObjectDispatcher.h")]
	internal sealed class ObjectDispatcher : IDisposable
	{
		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x0600171A RID: 5914 RVA: 0x000266E8 File Offset: 0x000248E8
		public bool valid
		{
			get
			{
				return this.m_Ptr != IntPtr.Zero;
			}
		}

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x0600171B RID: 5915 RVA: 0x0002670C File Offset: 0x0002490C
		// (set) Token: 0x0600171C RID: 5916 RVA: 0x00026730 File Offset: 0x00024930
		public int maxDispatchHistoryFramesCount
		{
			get
			{
				this.ValidateSystemHandleAndThrow();
				return ObjectDispatcher.GetMaxDispatchHistoryFramesCount(this.m_Ptr);
			}
			set
			{
				this.ValidateSystemHandleAndThrow();
				ObjectDispatcher.SetMaxDispatchHistoryFramesCount(this.m_Ptr, value);
			}
		}

		// Token: 0x0600171D RID: 5917 RVA: 0x00026747 File Offset: 0x00024947
		public ObjectDispatcher()
		{
			this.m_Ptr = ObjectDispatcher.CreateDispatchSystemHandle();
		}

		// Token: 0x0600171E RID: 5918 RVA: 0x00026768 File Offset: 0x00024968
		~ObjectDispatcher()
		{
			this.Dispose(false);
		}

		// Token: 0x0600171F RID: 5919 RVA: 0x0002679C File Offset: 0x0002499C
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06001720 RID: 5920 RVA: 0x000267B0 File Offset: 0x000249B0
		private void Dispose(bool disposing)
		{
			bool flag = this.m_Ptr != IntPtr.Zero;
			if (flag)
			{
				ObjectDispatcher.DestroyDispatchSystemHandle(this.m_Ptr);
				this.m_Ptr = IntPtr.Zero;
			}
		}

		// Token: 0x06001721 RID: 5921 RVA: 0x000267EC File Offset: 0x000249EC
		private void ValidateSystemHandleAndThrow()
		{
			bool flag = !this.valid;
			if (flag)
			{
				throw new Exception("The ObjectDispatcher is invalid or has been disposed.");
			}
		}

		// Token: 0x06001722 RID: 5922 RVA: 0x00026814 File Offset: 0x00024A14
		private void ValidateTypeAndThrow(Type type)
		{
			bool flag = !type.IsSubclassOf(typeof(Object));
			if (flag)
			{
				throw new Exception("Only types inherited from UnityEngine.Object are supported.");
			}
		}

		// Token: 0x06001723 RID: 5923 RVA: 0x00026844 File Offset: 0x00024A44
		private void ValidateComponentTypeAndThrow(Type type)
		{
			bool flag = !type.IsSubclassOf(typeof(Component));
			if (flag)
			{
				throw new Exception("Only types inherited from UnityEngine.Component are supported.");
			}
		}

		// Token: 0x06001724 RID: 5924 RVA: 0x00026874 File Offset: 0x00024A74
		public void DispatchTypeChangesAndClear(Type type, Action<TypeDispatchData> callback, bool sortByInstanceID = false, bool noScriptingArray = false)
		{
			this.ValidateSystemHandleAndThrow();
			this.ValidateTypeAndThrow(type);
			ObjectDispatcher.DispatchTypeChangesAndClear(this.m_Ptr, type, ObjectDispatcher.s_TypeDispatch, sortByInstanceID, noScriptingArray, callback);
		}

		// Token: 0x06001725 RID: 5925 RVA: 0x0002689C File Offset: 0x00024A9C
		public void DispatchTransformChangesAndClear(Type type, ObjectDispatcher.TransformTrackingType trackingType, Action<Component[]> callback, bool sortByInstanceID = false)
		{
			this.ValidateSystemHandleAndThrow();
			this.ValidateComponentTypeAndThrow(type);
			ObjectDispatcher.DispatchTransformChangesAndClear(this.m_Ptr, type, trackingType, callback, sortByInstanceID);
		}

		// Token: 0x06001726 RID: 5926 RVA: 0x000268BF File Offset: 0x00024ABF
		public void DispatchTransformChangesAndClear(Type type, ObjectDispatcher.TransformTrackingType trackingType, Action<TransformDispatchData> callback)
		{
			this.ValidateSystemHandleAndThrow();
			this.ValidateComponentTypeAndThrow(type);
			ObjectDispatcher.DispatchTransformDataChangesAndClear(this.m_Ptr, type, trackingType, ObjectDispatcher.s_TransformDispatch, callback);
		}

		// Token: 0x06001727 RID: 5927 RVA: 0x000268E5 File Offset: 0x00024AE5
		public void ClearTypeChanges(Type type)
		{
			this.ValidateSystemHandleAndThrow();
			this.ValidateTypeAndThrow(type);
			ObjectDispatcher.DispatchTypeChangesAndClear(this.m_Ptr, type, null, false, false, null);
		}

		// Token: 0x06001728 RID: 5928 RVA: 0x00026908 File Offset: 0x00024B08
		public TypeDispatchData GetTypeChangesAndClear(Type type, Allocator allocator, bool sortByInstanceID = false, bool noScriptingArray = false)
		{
			TypeDispatchData dispatchData = default(TypeDispatchData);
			this.DispatchTypeChangesAndClear(type, delegate(TypeDispatchData data)
			{
				dispatchData.changed = data.changed;
				dispatchData.changedID = new NativeArray<int>(data.changedID, allocator);
				dispatchData.destroyedID = new NativeArray<int>(data.destroyedID, allocator);
			}, sortByInstanceID, noScriptingArray);
			return dispatchData;
		}

		// Token: 0x06001729 RID: 5929 RVA: 0x00026950 File Offset: 0x00024B50
		public void GetTypeChangesAndClear(Type type, List<Object> changed, out NativeArray<int> changedID, out NativeArray<int> destroyedID, Allocator allocator, bool sortByInstanceID = false)
		{
			TypeDispatchData dispatchData = default(TypeDispatchData);
			this.DispatchTypeChangesAndClear(type, delegate(TypeDispatchData data)
			{
				dispatchData.changedID = new NativeArray<int>(data.changedID, allocator);
				dispatchData.destroyedID = new NativeArray<int>(data.destroyedID, allocator);
			}, sortByInstanceID, true);
			changedID = dispatchData.changedID;
			destroyedID = dispatchData.destroyedID;
			Resources.InstanceIDToObjectList(dispatchData.changedID, changed);
		}

		// Token: 0x0600172A RID: 5930 RVA: 0x000269C4 File Offset: 0x00024BC4
		public Component[] GetTransformChangesAndClear(Type type, ObjectDispatcher.TransformTrackingType trackingType, bool sortByInstanceID = false)
		{
			Component[] dispatchData = null;
			this.DispatchTransformChangesAndClear(type, trackingType, delegate(Component[] instances)
			{
				dispatchData = instances;
			}, sortByInstanceID);
			return dispatchData;
		}

		// Token: 0x0600172B RID: 5931 RVA: 0x00026A00 File Offset: 0x00024C00
		public TransformDispatchData GetTransformChangesAndClear(Type type, ObjectDispatcher.TransformTrackingType trackingType, Allocator allocator)
		{
			TransformDispatchData dispatchData = default(TransformDispatchData);
			this.DispatchTransformChangesAndClear(type, trackingType, delegate(TransformDispatchData data)
			{
				dispatchData.transformedID = new NativeArray<int>(data.transformedID, allocator);
				dispatchData.parentID = new NativeArray<int>(data.parentID, allocator);
				dispatchData.localToWorldMatrices = new NativeArray<Matrix4x4>(data.localToWorldMatrices, allocator);
				dispatchData.positions = new NativeArray<Vector3>(data.positions, allocator);
				dispatchData.rotations = new NativeArray<Quaternion>(data.rotations, allocator);
				dispatchData.scales = new NativeArray<Vector3>(data.scales, allocator);
			});
			return dispatchData;
		}

		// Token: 0x0600172C RID: 5932 RVA: 0x00026A48 File Offset: 0x00024C48
		public void EnableTypeTracking(ObjectDispatcher.TypeTrackingFlags typeTrackingMask, params Type[] types)
		{
			this.ValidateSystemHandleAndThrow();
			foreach (Type type in types)
			{
				this.ValidateTypeAndThrow(type);
				ObjectDispatcher.EnableTypeTracking(this.m_Ptr, type, typeTrackingMask);
			}
		}

		// Token: 0x0600172D RID: 5933 RVA: 0x00026A8A File Offset: 0x00024C8A
		public void EnableTypeTracking(params Type[] types)
		{
			this.EnableTypeTracking(ObjectDispatcher.TypeTrackingFlags.Default, types);
		}

		// Token: 0x0600172E RID: 5934 RVA: 0x00026A8A File Offset: 0x00024C8A
		[Obsolete("EnableTypeTrackingIncludingAssets is deprecated, please use EnableTypeTracking and provide the flag that specifies whether you need assets or not.", false)]
		public void EnableTypeTrackingIncludingAssets(params Type[] types)
		{
			this.EnableTypeTracking(ObjectDispatcher.TypeTrackingFlags.Default, types);
		}

		// Token: 0x0600172F RID: 5935 RVA: 0x00026A98 File Offset: 0x00024C98
		public void DisableTypeTracking(params Type[] types)
		{
			this.ValidateSystemHandleAndThrow();
			foreach (Type type in types)
			{
				this.ValidateTypeAndThrow(type);
				ObjectDispatcher.DisableTypeTracking(this.m_Ptr, type);
			}
		}

		// Token: 0x06001730 RID: 5936 RVA: 0x00026ADC File Offset: 0x00024CDC
		public void EnableTransformTracking(ObjectDispatcher.TransformTrackingType trackingType, params Type[] types)
		{
			this.ValidateSystemHandleAndThrow();
			foreach (Type type in types)
			{
				this.ValidateComponentTypeAndThrow(type);
				ObjectDispatcher.EnableTransformTracking(this.m_Ptr, type, trackingType);
			}
		}

		// Token: 0x06001731 RID: 5937 RVA: 0x00026B20 File Offset: 0x00024D20
		public void DisableTransformTracking(ObjectDispatcher.TransformTrackingType trackingType, params Type[] types)
		{
			this.ValidateSystemHandleAndThrow();
			foreach (Type type in types)
			{
				this.ValidateComponentTypeAndThrow(type);
				ObjectDispatcher.DisableTransformTracking(this.m_Ptr, type, trackingType);
			}
		}

		// Token: 0x06001732 RID: 5938 RVA: 0x00026B62 File Offset: 0x00024D62
		public void DispatchTypeChangesAndClear<T>(Action<TypeDispatchData> callback, bool sortByInstanceID = false, bool noScriptingArray = false) where T : Object
		{
			this.DispatchTypeChangesAndClear(typeof(T), callback, sortByInstanceID, noScriptingArray);
		}

		// Token: 0x06001733 RID: 5939 RVA: 0x00026B79 File Offset: 0x00024D79
		public void DispatchTransformChangesAndClear<T>(ObjectDispatcher.TransformTrackingType trackingType, Action<Component[]> callback, bool sortByInstanceID = false) where T : Object
		{
			this.DispatchTransformChangesAndClear(typeof(T), trackingType, callback, sortByInstanceID);
		}

		// Token: 0x06001734 RID: 5940 RVA: 0x00026B90 File Offset: 0x00024D90
		public void DispatchTransformChangesAndClear<T>(ObjectDispatcher.TransformTrackingType trackingType, Action<TransformDispatchData> callback) where T : Object
		{
			this.DispatchTransformChangesAndClear(typeof(T), trackingType, callback);
		}

		// Token: 0x06001735 RID: 5941 RVA: 0x00026BA6 File Offset: 0x00024DA6
		public void ClearTypeChanges<T>() where T : Object
		{
			this.ClearTypeChanges(typeof(T));
		}

		// Token: 0x06001736 RID: 5942 RVA: 0x00026BBC File Offset: 0x00024DBC
		public TypeDispatchData GetTypeChangesAndClear<T>(Allocator allocator, bool sortByInstanceID = false, bool noScriptingArray = false) where T : Object
		{
			return this.GetTypeChangesAndClear(typeof(T), allocator, sortByInstanceID, noScriptingArray);
		}

		// Token: 0x06001737 RID: 5943 RVA: 0x00026BE1 File Offset: 0x00024DE1
		public void GetTypeChangesAndClear<T>(List<Object> changed, out NativeArray<int> changedID, out NativeArray<int> destroyedID, Allocator allocator, bool sortByInstanceID = false) where T : Object
		{
			this.GetTypeChangesAndClear(typeof(T), changed, out changedID, out destroyedID, allocator, sortByInstanceID);
		}

		// Token: 0x06001738 RID: 5944 RVA: 0x00026BFC File Offset: 0x00024DFC
		public Component[] GetTransformChangesAndClear<T>(ObjectDispatcher.TransformTrackingType trackingType, bool sortByInstanceID = false) where T : Object
		{
			return this.GetTransformChangesAndClear(typeof(T), trackingType, sortByInstanceID);
		}

		// Token: 0x06001739 RID: 5945 RVA: 0x00026C20 File Offset: 0x00024E20
		public TransformDispatchData GetTransformChangesAndClear<T>(ObjectDispatcher.TransformTrackingType trackingType, Allocator allocator) where T : Object
		{
			return this.GetTransformChangesAndClear(typeof(T), trackingType, allocator);
		}

		// Token: 0x0600173A RID: 5946 RVA: 0x00026C44 File Offset: 0x00024E44
		public void EnableTypeTracking<T>(ObjectDispatcher.TypeTrackingFlags typeTrackingMask = ObjectDispatcher.TypeTrackingFlags.Default) where T : Object
		{
			this.EnableTypeTracking(typeTrackingMask, new Type[]
			{
				typeof(T)
			});
		}

		// Token: 0x0600173B RID: 5947 RVA: 0x00026C62 File Offset: 0x00024E62
		public void DisableTypeTracking<T>() where T : Object
		{
			this.DisableTypeTracking(new Type[]
			{
				typeof(T)
			});
		}

		// Token: 0x0600173C RID: 5948 RVA: 0x00026C7F File Offset: 0x00024E7F
		public void EnableTransformTracking<T>(ObjectDispatcher.TransformTrackingType trackingType) where T : Object
		{
			this.EnableTransformTracking(trackingType, new Type[]
			{
				typeof(T)
			});
		}

		// Token: 0x0600173D RID: 5949 RVA: 0x00026C9D File Offset: 0x00024E9D
		public void DisableTransformTracking<T>(ObjectDispatcher.TransformTrackingType trackingType) where T : Object
		{
			this.DisableTransformTracking(trackingType, new Type[]
			{
				typeof(T)
			});
		}

		// Token: 0x0600173E RID: 5950
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr CreateDispatchSystemHandle();

		// Token: 0x0600173F RID: 5951
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DestroyDispatchSystemHandle(IntPtr ptr);

		// Token: 0x06001740 RID: 5952
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetMaxDispatchHistoryFramesCount(IntPtr ptr);

		// Token: 0x06001741 RID: 5953
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetMaxDispatchHistoryFramesCount(IntPtr ptr, int count);

		// Token: 0x06001742 RID: 5954
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void EnableTypeTracking(IntPtr ptr, Type type, ObjectDispatcher.TypeTrackingFlags typeTrackingMask);

		// Token: 0x06001743 RID: 5955
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DisableTypeTracking(IntPtr ptr, Type type);

		// Token: 0x06001744 RID: 5956
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void EnableTransformTracking(IntPtr ptr, Type type, ObjectDispatcher.TransformTrackingType trackingType);

		// Token: 0x06001745 RID: 5957
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DisableTransformTracking(IntPtr ptr, Type type, ObjectDispatcher.TransformTrackingType trackingType);

		// Token: 0x06001746 RID: 5958
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DispatchTypeChangesAndClear(IntPtr ptr, Type type, Action<Object[], IntPtr, IntPtr, int, int, Action<TypeDispatchData>> callback, bool sortByInstanceID, bool noScriptingArray, Action<TypeDispatchData> param);

		// Token: 0x06001747 RID: 5959
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DispatchTransformDataChangesAndClear(IntPtr ptr, Type type, ObjectDispatcher.TransformTrackingType trackingType, Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, int, Action<TransformDispatchData>> callback, Action<TransformDispatchData> param);

		// Token: 0x06001748 RID: 5960
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DispatchTransformChangesAndClear(IntPtr ptr, Type type, ObjectDispatcher.TransformTrackingType trackingType, Action<Component[]> callback, bool sortByInstanceID);

		// Token: 0x0400084A RID: 2122
		private IntPtr m_Ptr = IntPtr.Zero;

		// Token: 0x0400084B RID: 2123
		private static Action<Object[], IntPtr, IntPtr, int, int, Action<TypeDispatchData>> s_TypeDispatch = delegate(Object[] changed, IntPtr changedID, IntPtr destroyedID, int changedCount, int destroyedCount, Action<TypeDispatchData> callback)
		{
			NativeArray<int> changedID2 = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<int>(changedID.ToPointer(), changedCount, Allocator.Invalid);
			NativeArray<int> destroyedID2 = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<int>(destroyedID.ToPointer(), destroyedCount, Allocator.Invalid);
			TypeDispatchData obj = new TypeDispatchData
			{
				changed = changed,
				changedID = changedID2,
				destroyedID = destroyedID2
			};
			callback(obj);
		};

		// Token: 0x0400084C RID: 2124
		private static Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, int, Action<TransformDispatchData>> s_TransformDispatch = delegate(IntPtr transformed, IntPtr parents, IntPtr localToWorldMatrices, IntPtr positions, IntPtr rotations, IntPtr scales, int count, Action<TransformDispatchData> callback)
		{
			NativeArray<int> transformedID = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<int>(transformed.ToPointer(), count, Allocator.Invalid);
			NativeArray<int> parentID = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<int>(parents.ToPointer(), (parents != IntPtr.Zero) ? count : 0, Allocator.Invalid);
			NativeArray<Matrix4x4> localToWorldMatrices2 = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<Matrix4x4>(localToWorldMatrices.ToPointer(), (localToWorldMatrices != IntPtr.Zero) ? count : 0, Allocator.Invalid);
			NativeArray<Vector3> positions2 = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<Vector3>(positions.ToPointer(), (positions != IntPtr.Zero) ? count : 0, Allocator.Invalid);
			NativeArray<Quaternion> rotations2 = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<Quaternion>(rotations.ToPointer(), (rotations != IntPtr.Zero) ? count : 0, Allocator.Invalid);
			NativeArray<Vector3> scales2 = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<Vector3>(scales.ToPointer(), (scales != IntPtr.Zero) ? count : 0, Allocator.Invalid);
			TransformDispatchData obj = new TransformDispatchData
			{
				transformedID = transformedID,
				parentID = parentID,
				localToWorldMatrices = localToWorldMatrices2,
				positions = positions2,
				rotations = rotations2,
				scales = scales2
			};
			callback(obj);
		};

		// Token: 0x020001FC RID: 508
		public enum TransformTrackingType
		{
			// Token: 0x0400084E RID: 2126
			GlobalTRS,
			// Token: 0x0400084F RID: 2127
			LocalTRS,
			// Token: 0x04000850 RID: 2128
			Hierarchy
		}

		// Token: 0x020001FD RID: 509
		[Flags]
		public enum TypeTrackingFlags
		{
			// Token: 0x04000852 RID: 2130
			SceneObjects = 1,
			// Token: 0x04000853 RID: 2131
			Assets = 2,
			// Token: 0x04000854 RID: 2132
			EditorOnlyObjects = 4,
			// Token: 0x04000855 RID: 2133
			Default = 3,
			// Token: 0x04000856 RID: 2134
			All = 7
		}
	}
}
