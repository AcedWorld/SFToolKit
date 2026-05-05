using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
	// Token: 0x020000B5 RID: 181
	public class BufferedRTHandleSystem : IDisposable
	{
		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600055F RID: 1375 RVA: 0x0001BBCA File Offset: 0x00019DCA
		public int maxWidth
		{
			get
			{
				return this.m_RTHandleSystem.GetMaxWidth();
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000560 RID: 1376 RVA: 0x0001BBD7 File Offset: 0x00019DD7
		public int maxHeight
		{
			get
			{
				return this.m_RTHandleSystem.GetMaxHeight();
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000561 RID: 1377 RVA: 0x0001BBE4 File Offset: 0x00019DE4
		public RTHandleProperties rtHandleProperties
		{
			get
			{
				return this.m_RTHandleSystem.rtHandleProperties;
			}
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x0001BBF1 File Offset: 0x00019DF1
		public RTHandle GetFrameRT(int bufferId, int frameIndex)
		{
			if (!this.m_RTHandles.ContainsKey(bufferId))
			{
				return null;
			}
			return this.m_RTHandles[bufferId][frameIndex];
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0001BC14 File Offset: 0x00019E14
		public void AllocBuffer(int bufferId, Func<RTHandleSystem, int, RTHandle> allocator, int bufferCount)
		{
			RTHandle[] array = new RTHandle[bufferCount];
			this.m_RTHandles.Add(bufferId, array);
			array[0] = allocator(this.m_RTHandleSystem, 0);
			int i = 1;
			int num = array.Length;
			while (i < num)
			{
				array[i] = allocator(this.m_RTHandleSystem, i);
				this.m_RTHandleSystem.SwitchResizeMode(array[i], RTHandleSystem.ResizeMode.OnDemand);
				i++;
			}
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x0001BC74 File Offset: 0x00019E74
		public void ReleaseBuffer(int bufferId)
		{
			RTHandle[] array;
			if (this.m_RTHandles.TryGetValue(bufferId, out array))
			{
				foreach (RTHandle rth in array)
				{
					this.m_RTHandleSystem.Release(rth);
				}
			}
			this.m_RTHandles.Remove(bufferId);
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x0001BCBE File Offset: 0x00019EBE
		public void SwapAndSetReferenceSize(int width, int height)
		{
			this.Swap();
			this.m_RTHandleSystem.SetReferenceSize(width, height);
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x0001BCD3 File Offset: 0x00019ED3
		public void ResetReferenceSize(int width, int height)
		{
			this.m_RTHandleSystem.ResetReferenceSize(width, height);
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x0001BCE2 File Offset: 0x00019EE2
		public int GetNumFramesAllocated(int bufferId)
		{
			if (!this.m_RTHandles.ContainsKey(bufferId))
			{
				return 0;
			}
			return this.m_RTHandles[bufferId].Length;
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x0001BD04 File Offset: 0x00019F04
		public Vector2 CalculateRatioAgainstMaxSize(int width, int height)
		{
			RTHandleSystem rthandleSystem = this.m_RTHandleSystem;
			Vector2Int vector2Int = new Vector2Int(width, height);
			return rthandleSystem.CalculateRatioAgainstMaxSize(vector2Int);
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x0001BD28 File Offset: 0x00019F28
		private void Swap()
		{
			foreach (KeyValuePair<int, RTHandle[]> keyValuePair in this.m_RTHandles)
			{
				if (keyValuePair.Value.Length > 1)
				{
					RTHandle rthandle = keyValuePair.Value[keyValuePair.Value.Length - 1];
					int i = 0;
					int num = keyValuePair.Value.Length - 1;
					while (i < num)
					{
						keyValuePair.Value[i + 1] = keyValuePair.Value[i];
						i++;
					}
					keyValuePair.Value[0] = rthandle;
					this.m_RTHandleSystem.SwitchResizeMode(keyValuePair.Value[0], RTHandleSystem.ResizeMode.Auto);
					this.m_RTHandleSystem.SwitchResizeMode(keyValuePair.Value[1], RTHandleSystem.ResizeMode.OnDemand);
				}
				else
				{
					this.m_RTHandleSystem.SwitchResizeMode(keyValuePair.Value[0], RTHandleSystem.ResizeMode.Auto);
				}
			}
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0001BE14 File Offset: 0x0001A014
		private void Dispose(bool disposing)
		{
			if (!this.m_DisposedValue)
			{
				if (disposing)
				{
					this.ReleaseAll();
					this.m_RTHandleSystem.Dispose();
					this.m_RTHandleSystem = null;
				}
				this.m_DisposedValue = true;
			}
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0001BE40 File Offset: 0x0001A040
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0001BE4C File Offset: 0x0001A04C
		public void ReleaseAll()
		{
			foreach (KeyValuePair<int, RTHandle[]> keyValuePair in this.m_RTHandles)
			{
				int i = 0;
				int num = keyValuePair.Value.Length;
				while (i < num)
				{
					this.m_RTHandleSystem.Release(keyValuePair.Value[i]);
					i++;
				}
			}
			this.m_RTHandles.Clear();
		}

		// Token: 0x040003FB RID: 1019
		private Dictionary<int, RTHandle[]> m_RTHandles = new Dictionary<int, RTHandle[]>();

		// Token: 0x040003FC RID: 1020
		private RTHandleSystem m_RTHandleSystem = new RTHandleSystem();

		// Token: 0x040003FD RID: 1021
		private bool m_DisposedValue;
	}
}
