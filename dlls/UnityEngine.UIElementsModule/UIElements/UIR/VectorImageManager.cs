using System;
using System.Collections.Generic;
using Unity.Profiling;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000474 RID: 1140
	internal class VectorImageManager : IDisposable
	{
		// Token: 0x170007F7 RID: 2039
		// (get) Token: 0x06002341 RID: 9025 RVA: 0x00088DD0 File Offset: 0x00086FD0
		public Texture2D atlas
		{
			get
			{
				GradientSettingsAtlas gradientSettingsAtlas = this.m_GradientSettingsAtlas;
				return (gradientSettingsAtlas != null) ? gradientSettingsAtlas.atlas : null;
			}
		}

		// Token: 0x06002342 RID: 9026 RVA: 0x00088DF4 File Offset: 0x00086FF4
		public VectorImageManager(AtlasBase atlas)
		{
			VectorImageManager.instances.Add(this);
			this.m_Atlas = atlas;
			this.m_Registered = new Dictionary<VectorImage, VectorImageRenderInfo>(32);
			this.m_RenderInfoPool = new VectorImageRenderInfoPool();
			this.m_GradientRemapPool = new GradientRemapPool();
			this.m_GradientSettingsAtlas = new GradientSettingsAtlas(4096);
		}

		// Token: 0x170007F8 RID: 2040
		// (get) Token: 0x06002343 RID: 9027 RVA: 0x00088E4F File Offset: 0x0008704F
		// (set) Token: 0x06002344 RID: 9028 RVA: 0x00088E57 File Offset: 0x00087057
		private protected bool disposed { protected get; private set; }

		// Token: 0x06002345 RID: 9029 RVA: 0x00088E60 File Offset: 0x00087060
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06002346 RID: 9030 RVA: 0x00088E74 File Offset: 0x00087074
		protected virtual void Dispose(bool disposing)
		{
			bool disposed = this.disposed;
			if (!disposed)
			{
				if (disposing)
				{
					this.m_Registered.Clear();
					this.m_RenderInfoPool.Clear();
					this.m_GradientRemapPool.Clear();
					this.m_GradientSettingsAtlas.Dispose();
					VectorImageManager.instances.Remove(this);
				}
				this.disposed = true;
			}
		}

		// Token: 0x06002347 RID: 9031 RVA: 0x00088EDC File Offset: 0x000870DC
		public void Reset()
		{
			bool disposed = this.disposed;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
			}
			else
			{
				this.m_Registered.Clear();
				this.m_RenderInfoPool.Clear();
				this.m_GradientRemapPool.Clear();
				this.m_GradientSettingsAtlas.Reset();
			}
		}

		// Token: 0x06002348 RID: 9032 RVA: 0x00088F30 File Offset: 0x00087130
		public void Commit()
		{
			bool disposed = this.disposed;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
			}
			else
			{
				this.m_GradientSettingsAtlas.Commit();
			}
		}

		// Token: 0x06002349 RID: 9033 RVA: 0x00088F60 File Offset: 0x00087160
		public GradientRemap AddUser(VectorImage vi, VisualElement context)
		{
			bool disposed = this.disposed;
			GradientRemap result;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
				result = null;
			}
			else
			{
				bool flag = vi == null;
				if (flag)
				{
					result = null;
				}
				else
				{
					VectorImageRenderInfo vectorImageRenderInfo;
					bool flag2 = this.m_Registered.TryGetValue(vi, out vectorImageRenderInfo);
					if (flag2)
					{
						vectorImageRenderInfo.useCount++;
					}
					else
					{
						vectorImageRenderInfo = this.Register(vi, context);
					}
					result = vectorImageRenderInfo.firstGradientRemap;
				}
			}
			return result;
		}

		// Token: 0x0600234A RID: 9034 RVA: 0x00088FCC File Offset: 0x000871CC
		public void RemoveUser(VectorImage vi)
		{
			bool disposed = this.disposed;
			if (disposed)
			{
				DisposeHelper.NotifyDisposedUsed(this);
			}
			else
			{
				bool flag = vi == null;
				if (!flag)
				{
					VectorImageRenderInfo vectorImageRenderInfo;
					bool flag2 = this.m_Registered.TryGetValue(vi, out vectorImageRenderInfo);
					if (flag2)
					{
						vectorImageRenderInfo.useCount--;
						bool flag3 = vectorImageRenderInfo.useCount == 0;
						if (flag3)
						{
							this.Unregister(vi, vectorImageRenderInfo);
						}
					}
				}
			}
		}

		// Token: 0x0600234B RID: 9035 RVA: 0x00089038 File Offset: 0x00087238
		private VectorImageRenderInfo Register(VectorImage vi, VisualElement context)
		{
			VectorImageRenderInfo vectorImageRenderInfo = this.m_RenderInfoPool.Get();
			vectorImageRenderInfo.useCount = 1;
			this.m_Registered[vi] = vectorImageRenderInfo;
			GradientSettings[] settings = vi.settings;
			bool flag = settings != null && settings.Length != 0;
			if (flag)
			{
				int num = vi.settings.Length;
				Alloc alloc = this.m_GradientSettingsAtlas.Add(num);
				bool flag2 = alloc.size > 0U;
				if (flag2)
				{
					TextureId atlas;
					RectInt rectInt;
					bool flag3 = this.m_Atlas.TryGetAtlas(context, vi.atlas, out atlas, out rectInt);
					if (flag3)
					{
						GradientRemap gradientRemap = null;
						for (int i = 0; i < num; i++)
						{
							GradientRemap gradientRemap2 = this.m_GradientRemapPool.Get();
							bool flag4 = i > 0;
							if (flag4)
							{
								gradientRemap.next = gradientRemap2;
							}
							else
							{
								vectorImageRenderInfo.firstGradientRemap = gradientRemap2;
							}
							gradientRemap = gradientRemap2;
							gradientRemap2.origIndex = i;
							gradientRemap2.destIndex = (int)(alloc.start + (uint)i);
							GradientSettings gradientSettings = vi.settings[i];
							RectInt location = gradientSettings.location;
							location.x += rectInt.x;
							location.y += rectInt.y;
							gradientRemap2.location = location;
							gradientRemap2.atlas = atlas;
						}
						this.m_GradientSettingsAtlas.Write(alloc, vi.settings, vectorImageRenderInfo.firstGradientRemap);
					}
					else
					{
						GradientRemap gradientRemap3 = null;
						for (int j = 0; j < num; j++)
						{
							GradientRemap gradientRemap4 = this.m_GradientRemapPool.Get();
							bool flag5 = j > 0;
							if (flag5)
							{
								gradientRemap3.next = gradientRemap4;
							}
							else
							{
								vectorImageRenderInfo.firstGradientRemap = gradientRemap4;
							}
							gradientRemap3 = gradientRemap4;
							gradientRemap4.origIndex = j;
							gradientRemap4.destIndex = (int)(alloc.start + (uint)j);
							gradientRemap4.atlas = TextureId.invalid;
						}
						this.m_GradientSettingsAtlas.Write(alloc, vi.settings, null);
					}
				}
				else
				{
					bool flag6 = !this.m_LoggedExhaustedSettingsAtlas;
					if (flag6)
					{
						string str = "Exhausted max gradient settings (";
						string str2 = this.m_GradientSettingsAtlas.length.ToString();
						string str3 = ") for atlas: ";
						Texture2D atlas2 = this.m_GradientSettingsAtlas.atlas;
						Debug.LogError(str + str2 + str3 + ((atlas2 != null) ? atlas2.name : null));
						this.m_LoggedExhaustedSettingsAtlas = true;
					}
				}
			}
			return vectorImageRenderInfo;
		}

		// Token: 0x0600234C RID: 9036 RVA: 0x00089294 File Offset: 0x00087494
		private void Unregister(VectorImage vi, VectorImageRenderInfo renderInfo)
		{
			bool flag = renderInfo.gradientSettingsAlloc.size > 0U;
			if (flag)
			{
				this.m_GradientSettingsAtlas.Remove(renderInfo.gradientSettingsAlloc);
			}
			GradientRemap next;
			for (GradientRemap gradientRemap = renderInfo.firstGradientRemap; gradientRemap != null; gradientRemap = next)
			{
				next = gradientRemap.next;
				this.m_GradientRemapPool.Return(gradientRemap);
			}
			this.m_Registered.Remove(vi);
			this.m_RenderInfoPool.Return(renderInfo);
		}

		// Token: 0x04001068 RID: 4200
		public static List<VectorImageManager> instances = new List<VectorImageManager>(16);

		// Token: 0x04001069 RID: 4201
		private static ProfilerMarker s_MarkerRegister = new ProfilerMarker("UIR.VectorImageManager.Register");

		// Token: 0x0400106A RID: 4202
		private static ProfilerMarker s_MarkerUnregister = new ProfilerMarker("UIR.VectorImageManager.Unregister");

		// Token: 0x0400106B RID: 4203
		private readonly AtlasBase m_Atlas;

		// Token: 0x0400106C RID: 4204
		private Dictionary<VectorImage, VectorImageRenderInfo> m_Registered;

		// Token: 0x0400106D RID: 4205
		private VectorImageRenderInfoPool m_RenderInfoPool;

		// Token: 0x0400106E RID: 4206
		private GradientRemapPool m_GradientRemapPool;

		// Token: 0x0400106F RID: 4207
		private GradientSettingsAtlas m_GradientSettingsAtlas;

		// Token: 0x04001070 RID: 4208
		private bool m_LoggedExhaustedSettingsAtlas;
	}
}
