using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200014B RID: 331
	public abstract class CustomPostProcessVolumeComponent : VolumeComponent
	{
		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000AD3 RID: 2771 RVA: 0x0005AD68 File Offset: 0x00058F68
		public virtual CustomPostProcessInjectionPoint injectionPoint
		{
			get
			{
				return CustomPostProcessInjectionPoint.AfterPostProcess;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000AD4 RID: 2772 RVA: 0x0005AD6B File Offset: 0x00058F6B
		public virtual bool visibleInSceneView
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x0005AD6E File Offset: 0x00058F6E
		public virtual void Setup()
		{
		}

		// Token: 0x06000AD6 RID: 2774
		public abstract void Render(CommandBuffer cmd, HDCamera camera, RTHandle source, RTHandle destination);

		// Token: 0x06000AD7 RID: 2775 RVA: 0x0005AD70 File Offset: 0x00058F70
		public virtual void Cleanup()
		{
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x0005AD72 File Offset: 0x00058F72
		protected override void OnDisable()
		{
			base.OnDisable();
			this.CleanupInternal();
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x0005AD80 File Offset: 0x00058F80
		internal void CleanupInternal()
		{
			if (this.m_IsInitialized)
			{
				this.Cleanup();
			}
			this.m_IsInitialized = false;
			CustomPostProcessVolumeComponent.instances.Remove(this);
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x0005ADA3 File Offset: 0x00058FA3
		internal void SetupIfNeeded()
		{
			if (!this.m_IsInitialized)
			{
				this.Setup();
				this.m_IsInitialized = true;
				this.typeName = base.GetType().Name;
				CustomPostProcessVolumeComponent.instances.Add(this);
			}
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x0005ADD8 File Offset: 0x00058FD8
		internal static void CleanupAllCustomPostProcesses()
		{
			foreach (CustomPostProcessVolumeComponent customPostProcessVolumeComponent in CustomPostProcessVolumeComponent.instances.ToList<CustomPostProcessVolumeComponent>())
			{
				customPostProcessVolumeComponent.CleanupInternal();
			}
		}

		// Token: 0x04000C05 RID: 3077
		private bool m_IsInitialized;

		// Token: 0x04000C06 RID: 3078
		internal string typeName;

		// Token: 0x04000C07 RID: 3079
		internal static HashSet<CustomPostProcessVolumeComponent> instances = new HashSet<CustomPostProcessVolumeComponent>();
	}
}
