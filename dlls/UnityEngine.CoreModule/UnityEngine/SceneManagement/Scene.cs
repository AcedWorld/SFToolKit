using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.SceneManagement
{
	// Token: 0x0200031F RID: 799
	[NativeHeader("Runtime/Export/SceneManager/Scene.bindings.h")]
	[Serializable]
	public struct Scene
	{
		// Token: 0x0600204A RID: 8266
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsValidInternal(int sceneHandle);

		// Token: 0x0600204B RID: 8267
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string GetPathInternal(int sceneHandle);

		// Token: 0x0600204C RID: 8268
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetPathAndGUIDInternal(int sceneHandle, string path, string guid);

		// Token: 0x0600204D RID: 8269
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string GetNameInternal(int sceneHandle);

		// Token: 0x0600204E RID: 8270
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetNameInternal(int sceneHandle, string name);

		// Token: 0x0600204F RID: 8271
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string GetGUIDInternal(int sceneHandle);

		// Token: 0x06002050 RID: 8272
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsSubScene(int sceneHandle);

		// Token: 0x06002051 RID: 8273
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetIsSubScene(int sceneHandle, bool value);

		// Token: 0x06002052 RID: 8274
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetIsLoadedInternal(int sceneHandle);

		// Token: 0x06002053 RID: 8275
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Scene.LoadingState GetLoadingStateInternal(int sceneHandle);

		// Token: 0x06002054 RID: 8276
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetIsDirtyInternal(int sceneHandle);

		// Token: 0x06002055 RID: 8277
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetDirtyID(int sceneHandle);

		// Token: 0x06002056 RID: 8278
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetBuildIndexInternal(int sceneHandle);

		// Token: 0x06002057 RID: 8279
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetRootCountInternal(int sceneHandle);

		// Token: 0x06002058 RID: 8280
		[StaticAccessor("SceneBindings", StaticAccessorType.DoubleColon)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetRootGameObjectsInternal(int sceneHandle, object resultRootList);

		// Token: 0x06002059 RID: 8281 RVA: 0x00035B25 File Offset: 0x00033D25
		internal Scene(int handle)
		{
			this.m_Handle = handle;
		}

		// Token: 0x1700062E RID: 1582
		// (get) Token: 0x0600205A RID: 8282 RVA: 0x00035B30 File Offset: 0x00033D30
		public int handle
		{
			get
			{
				return this.m_Handle;
			}
		}

		// Token: 0x1700062F RID: 1583
		// (get) Token: 0x0600205B RID: 8283 RVA: 0x00035B48 File Offset: 0x00033D48
		internal Scene.LoadingState loadingState
		{
			get
			{
				return Scene.GetLoadingStateInternal(this.handle);
			}
		}

		// Token: 0x17000630 RID: 1584
		// (get) Token: 0x0600205C RID: 8284 RVA: 0x00035B68 File Offset: 0x00033D68
		internal string guid
		{
			get
			{
				return Scene.GetGUIDInternal(this.handle);
			}
		}

		// Token: 0x0600205D RID: 8285 RVA: 0x00035B88 File Offset: 0x00033D88
		public bool IsValid()
		{
			return Scene.IsValidInternal(this.handle);
		}

		// Token: 0x17000631 RID: 1585
		// (get) Token: 0x0600205E RID: 8286 RVA: 0x00035BA8 File Offset: 0x00033DA8
		public string path
		{
			get
			{
				return Scene.GetPathInternal(this.handle);
			}
		}

		// Token: 0x17000632 RID: 1586
		// (get) Token: 0x0600205F RID: 8287 RVA: 0x00035BC8 File Offset: 0x00033DC8
		// (set) Token: 0x06002060 RID: 8288 RVA: 0x00035BE5 File Offset: 0x00033DE5
		public string name
		{
			get
			{
				return Scene.GetNameInternal(this.handle);
			}
			set
			{
				Scene.SetNameInternal(this.handle, value);
			}
		}

		// Token: 0x17000633 RID: 1587
		// (get) Token: 0x06002061 RID: 8289 RVA: 0x00035BF8 File Offset: 0x00033DF8
		public bool isLoaded
		{
			get
			{
				return Scene.GetIsLoadedInternal(this.handle);
			}
		}

		// Token: 0x17000634 RID: 1588
		// (get) Token: 0x06002062 RID: 8290 RVA: 0x00035C18 File Offset: 0x00033E18
		public int buildIndex
		{
			get
			{
				return Scene.GetBuildIndexInternal(this.handle);
			}
		}

		// Token: 0x17000635 RID: 1589
		// (get) Token: 0x06002063 RID: 8291 RVA: 0x00035C38 File Offset: 0x00033E38
		public bool isDirty
		{
			get
			{
				return Scene.GetIsDirtyInternal(this.handle);
			}
		}

		// Token: 0x17000636 RID: 1590
		// (get) Token: 0x06002064 RID: 8292 RVA: 0x00035C58 File Offset: 0x00033E58
		internal int dirtyID
		{
			get
			{
				return Scene.GetDirtyID(this.handle);
			}
		}

		// Token: 0x17000637 RID: 1591
		// (get) Token: 0x06002065 RID: 8293 RVA: 0x00035C78 File Offset: 0x00033E78
		public int rootCount
		{
			get
			{
				return Scene.GetRootCountInternal(this.handle);
			}
		}

		// Token: 0x17000638 RID: 1592
		// (get) Token: 0x06002066 RID: 8294 RVA: 0x00035C98 File Offset: 0x00033E98
		// (set) Token: 0x06002067 RID: 8295 RVA: 0x00035CB5 File Offset: 0x00033EB5
		public bool isSubScene
		{
			get
			{
				return Scene.IsSubScene(this.handle);
			}
			set
			{
				Scene.SetIsSubScene(this.handle, value);
			}
		}

		// Token: 0x06002068 RID: 8296 RVA: 0x00035CC8 File Offset: 0x00033EC8
		public GameObject[] GetRootGameObjects()
		{
			List<GameObject> list = new List<GameObject>(this.rootCount);
			this.GetRootGameObjects(list);
			return list.ToArray();
		}

		// Token: 0x06002069 RID: 8297 RVA: 0x00035CF4 File Offset: 0x00033EF4
		public void GetRootGameObjects(List<GameObject> rootGameObjects)
		{
			bool flag = rootGameObjects.Capacity < this.rootCount;
			if (flag)
			{
				rootGameObjects.Capacity = this.rootCount;
			}
			rootGameObjects.Clear();
			bool flag2 = !this.IsValid();
			if (flag2)
			{
				throw new ArgumentException("The scene is invalid.");
			}
			bool flag3 = !Application.isPlaying && !this.isLoaded;
			if (flag3)
			{
				throw new ArgumentException("The scene is not loaded.");
			}
			bool flag4 = this.rootCount == 0;
			if (!flag4)
			{
				Scene.GetRootGameObjectsInternal(this.handle, rootGameObjects);
			}
		}

		// Token: 0x0600206A RID: 8298 RVA: 0x00035D80 File Offset: 0x00033F80
		public static bool operator ==(Scene lhs, Scene rhs)
		{
			return lhs.handle == rhs.handle;
		}

		// Token: 0x0600206B RID: 8299 RVA: 0x00035DA4 File Offset: 0x00033FA4
		public static bool operator !=(Scene lhs, Scene rhs)
		{
			return lhs.handle != rhs.handle;
		}

		// Token: 0x0600206C RID: 8300 RVA: 0x00035DCC File Offset: 0x00033FCC
		public override int GetHashCode()
		{
			return this.m_Handle;
		}

		// Token: 0x0600206D RID: 8301 RVA: 0x00035DE4 File Offset: 0x00033FE4
		public override bool Equals(object other)
		{
			bool flag = !(other is Scene);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				Scene scene = (Scene)other;
				result = (this.handle == scene.handle);
			}
			return result;
		}

		// Token: 0x0600206E RID: 8302 RVA: 0x00035E20 File Offset: 0x00034020
		internal void SetPathAndGuid(string path, string guid)
		{
			Scene.SetPathAndGUIDInternal(this.m_Handle, path, guid);
		}

		// Token: 0x04000AB1 RID: 2737
		[HideInInspector]
		[SerializeField]
		private int m_Handle;

		// Token: 0x02000320 RID: 800
		internal enum LoadingState
		{
			// Token: 0x04000AB3 RID: 2739
			NotLoaded,
			// Token: 0x04000AB4 RID: 2740
			Loading,
			// Token: 0x04000AB5 RID: 2741
			Loaded,
			// Token: 0x04000AB6 RID: 2742
			Unloading
		}
	}
}
