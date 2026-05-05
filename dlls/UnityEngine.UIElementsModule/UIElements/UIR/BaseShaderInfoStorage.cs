using System;
using Unity.Profiling;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x0200045F RID: 1119
	internal abstract class BaseShaderInfoStorage : IDisposable
	{
		// Token: 0x170007F0 RID: 2032
		// (get) Token: 0x060022F1 RID: 8945
		public abstract Texture2D texture { get; }

		// Token: 0x060022F2 RID: 8946
		public abstract bool AllocateRect(int width, int height, out RectInt uvs);

		// Token: 0x060022F3 RID: 8947
		public abstract void SetTexel(int x, int y, Color color);

		// Token: 0x060022F4 RID: 8948
		public abstract void UpdateTexture();

		// Token: 0x170007F1 RID: 2033
		// (get) Token: 0x060022F5 RID: 8949 RVA: 0x0008782D File Offset: 0x00085A2D
		// (set) Token: 0x060022F6 RID: 8950 RVA: 0x00087835 File Offset: 0x00085A35
		private protected bool disposed { protected get; private set; }

		// Token: 0x060022F7 RID: 8951 RVA: 0x0008783E File Offset: 0x00085A3E
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060022F8 RID: 8952 RVA: 0x00087850 File Offset: 0x00085A50
		protected virtual void Dispose(bool disposing)
		{
			bool disposed = this.disposed;
			if (!disposed)
			{
				bool flag = !disposing;
				if (flag)
				{
				}
				this.disposed = true;
			}
		}

		// Token: 0x04001018 RID: 4120
		protected static int s_TextureCounter;

		// Token: 0x04001019 RID: 4121
		internal static ProfilerMarker s_MarkerCopyTexture = new ProfilerMarker("UIR.ShaderInfoStorage.CopyTexture");

		// Token: 0x0400101A RID: 4122
		internal static ProfilerMarker s_MarkerGetTextureData = new ProfilerMarker("UIR.ShaderInfoStorage.GetTextureData");

		// Token: 0x0400101B RID: 4123
		internal static ProfilerMarker s_MarkerUpdateTexture = new ProfilerMarker("UIR.ShaderInfoStorage.UpdateTexture");
	}
}
