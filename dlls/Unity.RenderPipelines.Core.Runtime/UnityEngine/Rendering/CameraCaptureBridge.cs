using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
	// Token: 0x020000D0 RID: 208
	public static class CameraCaptureBridge
	{
		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060006D2 RID: 1746 RVA: 0x000211B0 File Offset: 0x0001F3B0
		// (set) Token: 0x060006D3 RID: 1747 RVA: 0x000211B7 File Offset: 0x0001F3B7
		public static bool enabled
		{
			get
			{
				return CameraCaptureBridge._enabled;
			}
			set
			{
				CameraCaptureBridge._enabled = value;
			}
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x000211C0 File Offset: 0x0001F3C0
		public static IEnumerator<Action<RenderTargetIdentifier, CommandBuffer>> GetCaptureActions(Camera camera)
		{
			HashSet<Action<RenderTargetIdentifier, CommandBuffer>> hashSet;
			if (!CameraCaptureBridge.actionDict.TryGetValue(camera, out hashSet) || hashSet.Count == 0)
			{
				return null;
			}
			return hashSet.GetEnumerator();
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x000211F4 File Offset: 0x0001F3F4
		public static void AddCaptureAction(Camera camera, Action<RenderTargetIdentifier, CommandBuffer> action)
		{
			HashSet<Action<RenderTargetIdentifier, CommandBuffer>> hashSet;
			CameraCaptureBridge.actionDict.TryGetValue(camera, out hashSet);
			if (hashSet == null)
			{
				hashSet = new HashSet<Action<RenderTargetIdentifier, CommandBuffer>>();
				CameraCaptureBridge.actionDict.Add(camera, hashSet);
			}
			hashSet.Add(action);
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x0002122C File Offset: 0x0001F42C
		public static void RemoveCaptureAction(Camera camera, Action<RenderTargetIdentifier, CommandBuffer> action)
		{
			if (camera == null)
			{
				return;
			}
			HashSet<Action<RenderTargetIdentifier, CommandBuffer>> hashSet;
			if (CameraCaptureBridge.actionDict.TryGetValue(camera, out hashSet))
			{
				hashSet.Remove(action);
			}
		}

		// Token: 0x0400047E RID: 1150
		private static Dictionary<Camera, HashSet<Action<RenderTargetIdentifier, CommandBuffer>>> actionDict = new Dictionary<Camera, HashSet<Action<RenderTargetIdentifier, CommandBuffer>>>();

		// Token: 0x0400047F RID: 1151
		private static bool _enabled;
	}
}
