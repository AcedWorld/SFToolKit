using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200020B RID: 523
	internal class ProbeCameraCache<K> : IDisposable
	{
		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000F8A RID: 3978 RVA: 0x00078EA9 File Offset: 0x000770A9
		internal int cachedActiveCameraCount
		{
			get
			{
				return this.m_CameraPool.Count;
			}
		}

		// Token: 0x06000F8B RID: 3979 RVA: 0x00078EB8 File Offset: 0x000770B8
		public Camera GetOrCreate(K key, int frameCount)
		{
			if (this.m_Cache == null)
			{
				throw new ObjectDisposedException("ProbeCameraCache");
			}
			ValueTuple<Camera, int> valueTuple;
			if (!this.m_Cache.TryGetValue(key, out valueTuple) || valueTuple.Item1 == null || valueTuple.Item1.Equals(null))
			{
				if (this.m_CameraPool.Count == 0)
				{
					GameObject gameObject = new GameObject("Unused Probe Camera");
					gameObject.hideFlags = HideFlags.HideAndDontSave;
					Object.DontDestroyOnLoad(gameObject);
					valueTuple = new ValueTuple<Camera, int>(gameObject.AddComponent<Camera>(), frameCount);
					valueTuple.Item1.cameraType = CameraType.Reflection;
					gameObject.SetActive(false);
				}
				else
				{
					valueTuple = new ValueTuple<Camera, int>(this.m_CameraPool.Pop(), frameCount);
				}
				this.m_Cache[key] = valueTuple;
			}
			else
			{
				valueTuple.Item2 = frameCount;
				this.m_Cache[key] = valueTuple;
			}
			return valueTuple.Item1;
		}

		// Token: 0x06000F8C RID: 3980 RVA: 0x00078F88 File Offset: 0x00077188
		public void ReleaseCamerasUnusedFor(int frameWindow, int frameCount)
		{
			if (this.m_Cache == null)
			{
				throw new ObjectDisposedException("ProbeCameraCache");
			}
			if (this.m_Cache.Count == 0)
			{
				return;
			}
			if (this.m_TempCameraKeysCache.Length != this.m_Cache.Count)
			{
				this.m_TempCameraKeysCache = new K[this.m_Cache.Count];
			}
			this.m_Cache.Keys.CopyTo(this.m_TempCameraKeysCache, 0);
			foreach (K key in this.m_TempCameraKeysCache)
			{
				ValueTuple<Camera, int> valueTuple;
				if (this.m_Cache.TryGetValue(key, out valueTuple) && Math.Abs(frameCount - valueTuple.Item2) > frameWindow)
				{
					if (valueTuple.Item1 != null)
					{
						valueTuple.Item1.name = "Unused Probe Camera";
						this.m_CameraPool.Push(valueTuple.Item1);
					}
					this.m_Cache.Remove(key);
				}
			}
		}

		// Token: 0x06000F8D RID: 3981 RVA: 0x00079074 File Offset: 0x00077274
		public void Clear()
		{
			if (this.m_Cache == null)
			{
				throw new ObjectDisposedException("ProbeCameraCache");
			}
			foreach (KeyValuePair<K, ValueTuple<Camera, int>> keyValuePair in this.m_Cache)
			{
				if (keyValuePair.Value.Item1 != null)
				{
					CoreUtils.Destroy(keyValuePair.Value.Item1.gameObject);
				}
			}
			this.m_Cache.Clear();
			foreach (Camera camera in this.m_CameraPool)
			{
				if (camera != null)
				{
					CoreUtils.Destroy(camera.gameObject);
				}
			}
			this.m_CameraPool.Clear();
		}

		// Token: 0x06000F8E RID: 3982 RVA: 0x00079164 File Offset: 0x00077364
		public void Dispose()
		{
			this.Clear();
			this.m_Cache = null;
			this.m_CameraPool = null;
		}

		// Token: 0x04001809 RID: 6153
		private Stack<Camera> m_CameraPool = new Stack<Camera>();

		// Token: 0x0400180A RID: 6154
		[TupleElementNames(new string[]
		{
			"camera",
			"lastFrame"
		})]
		private Dictionary<K, ValueTuple<Camera, int>> m_Cache = new Dictionary<K, ValueTuple<Camera, int>>();

		// Token: 0x0400180B RID: 6155
		private K[] m_TempCameraKeysCache = new K[0];
	}
}
