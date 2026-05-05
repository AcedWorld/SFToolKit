using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200003E RID: 62
	public class HDVolumeDebugSettings : VolumeDebugSettings<HDAdditionalCameraData>
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600021B RID: 539 RVA: 0x0000C340 File Offset: 0x0000A540
		public override Type targetRenderPipeline
		{
			get
			{
				return typeof(HDRenderPipeline);
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600021C RID: 540 RVA: 0x0000C34C File Offset: 0x0000A54C
		public override VolumeStack selectedCameraVolumeStack
		{
			get
			{
				Camera selectedCamera = base.selectedCamera;
				if (selectedCamera == null)
				{
					return null;
				}
				VolumeStack volumeStack = HDCamera.GetOrCreate(selectedCamera, 0).volumeStack;
				if (volumeStack != null)
				{
					return volumeStack;
				}
				return VolumeManager.instance.stack;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600021D RID: 541 RVA: 0x0000C387 File Offset: 0x0000A587
		public override LayerMask selectedCameraLayerMask
		{
			get
			{
				if (base.selectedCamera == null)
				{
					return 0;
				}
				return base.selectedCamera.GetComponent<HDAdditionalCameraData>().volumeLayerMask;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600021E RID: 542 RVA: 0x0000C3B0 File Offset: 0x0000A5B0
		public override Vector3 selectedCameraPosition
		{
			get
			{
				Camera selectedCamera = base.selectedCamera;
				if (selectedCamera == null)
				{
					return Vector3.zero;
				}
				Transform transform = HDCamera.GetOrCreate(selectedCamera, 0).volumeAnchor;
				if (transform == null)
				{
					HDAdditionalCameraData hdadditionalCameraData;
					if (selectedCamera.TryGetComponent<HDAdditionalCameraData>(out hdadditionalCameraData))
					{
						transform = hdadditionalCameraData.volumeAnchorOverride;
					}
					if (transform == null)
					{
						transform = selectedCamera.transform;
					}
					VolumeStack selectedCameraVolumeStack = this.selectedCameraVolumeStack;
					if (selectedCameraVolumeStack != null)
					{
						VolumeManager.instance.Update(selectedCameraVolumeStack, transform, this.selectedCameraLayerMask);
					}
				}
				return transform.position;
			}
		}
	}
}
