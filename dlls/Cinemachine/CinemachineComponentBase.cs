using System;
using UnityEngine;

namespace Cinemachine
{
	// Token: 0x02000033 RID: 51
	[DocumentationSorting(DocumentationSortingAttribute.Level.API)]
	public abstract class CinemachineComponentBase : MonoBehaviour
	{
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000260 RID: 608 RVA: 0x0001192C File Offset: 0x0000FB2C
		public CinemachineVirtualCameraBase VirtualCamera
		{
			get
			{
				if (this.m_vcamOwner == null)
				{
					this.m_vcamOwner = base.GetComponent<CinemachineVirtualCameraBase>();
				}
				if (this.m_vcamOwner == null && base.transform.parent != null)
				{
					this.m_vcamOwner = base.transform.parent.GetComponent<CinemachineVirtualCameraBase>();
				}
				return this.m_vcamOwner;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000261 RID: 609 RVA: 0x00011990 File Offset: 0x0000FB90
		public Transform FollowTarget
		{
			get
			{
				CinemachineVirtualCameraBase virtualCamera = this.VirtualCamera;
				if (!(virtualCamera == null))
				{
					return virtualCamera.ResolveFollow(virtualCamera.Follow);
				}
				return null;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000262 RID: 610 RVA: 0x000119BC File Offset: 0x0000FBBC
		public Transform LookAtTarget
		{
			get
			{
				CinemachineVirtualCameraBase virtualCamera = this.VirtualCamera;
				if (!(virtualCamera == null))
				{
					return virtualCamera.ResolveLookAt(virtualCamera.LookAt);
				}
				return null;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000263 RID: 611 RVA: 0x000119E8 File Offset: 0x0000FBE8
		public ICinemachineTargetGroup AbstractFollowTargetGroup
		{
			get
			{
				CinemachineVirtualCameraBase virtualCamera = this.VirtualCamera;
				if (!(virtualCamera == null))
				{
					return virtualCamera.AbstractFollowTargetGroup;
				}
				return null;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000264 RID: 612 RVA: 0x00011A0D File Offset: 0x0000FC0D
		public CinemachineTargetGroup FollowTargetGroup
		{
			get
			{
				return this.AbstractFollowTargetGroup as CinemachineTargetGroup;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00011A1C File Offset: 0x0000FC1C
		public Vector3 FollowTargetPosition
		{
			get
			{
				CinemachineVirtualCameraBase followTargetAsVcam = this.VirtualCamera.FollowTargetAsVcam;
				if (followTargetAsVcam != null)
				{
					return followTargetAsVcam.State.FinalPosition;
				}
				Transform followTarget = this.FollowTarget;
				if (followTarget != null)
				{
					return TargetPositionCache.GetTargetPosition(followTarget);
				}
				return Vector3.zero;
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000266 RID: 614 RVA: 0x00011A6C File Offset: 0x0000FC6C
		public Quaternion FollowTargetRotation
		{
			get
			{
				CinemachineVirtualCameraBase followTargetAsVcam = this.VirtualCamera.FollowTargetAsVcam;
				if (followTargetAsVcam != null)
				{
					return followTargetAsVcam.State.FinalOrientation;
				}
				Transform followTarget = this.FollowTarget;
				if (followTarget != null)
				{
					return TargetPositionCache.GetTargetRotation(followTarget);
				}
				return Quaternion.identity;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000267 RID: 615 RVA: 0x00011AB9 File Offset: 0x0000FCB9
		public ICinemachineTargetGroup AbstractLookAtTargetGroup
		{
			get
			{
				return this.VirtualCamera.AbstractLookAtTargetGroup;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000268 RID: 616 RVA: 0x00011AC6 File Offset: 0x0000FCC6
		public CinemachineTargetGroup LookAtTargetGroup
		{
			get
			{
				return this.AbstractLookAtTargetGroup as CinemachineTargetGroup;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000269 RID: 617 RVA: 0x00011AD4 File Offset: 0x0000FCD4
		public Vector3 LookAtTargetPosition
		{
			get
			{
				CinemachineVirtualCameraBase lookAtTargetAsVcam = this.VirtualCamera.LookAtTargetAsVcam;
				if (lookAtTargetAsVcam != null)
				{
					return lookAtTargetAsVcam.State.FinalPosition;
				}
				Transform lookAtTarget = this.LookAtTarget;
				if (lookAtTarget != null)
				{
					return TargetPositionCache.GetTargetPosition(lookAtTarget);
				}
				return Vector3.zero;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x0600026A RID: 618 RVA: 0x00011B24 File Offset: 0x0000FD24
		public Quaternion LookAtTargetRotation
		{
			get
			{
				CinemachineVirtualCameraBase lookAtTargetAsVcam = this.VirtualCamera.LookAtTargetAsVcam;
				if (lookAtTargetAsVcam != null)
				{
					return lookAtTargetAsVcam.State.FinalOrientation;
				}
				Transform lookAtTarget = this.LookAtTarget;
				if (lookAtTarget != null)
				{
					return TargetPositionCache.GetTargetRotation(lookAtTarget);
				}
				return Quaternion.identity;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600026B RID: 619 RVA: 0x00011B74 File Offset: 0x0000FD74
		public CameraState VcamState
		{
			get
			{
				CinemachineVirtualCameraBase virtualCamera = this.VirtualCamera;
				if (!(virtualCamera == null))
				{
					return virtualCamera.State;
				}
				return CameraState.Default;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600026C RID: 620
		public abstract bool IsValid { get; }

		// Token: 0x0600026D RID: 621 RVA: 0x00011B9D File Offset: 0x0000FD9D
		public virtual void PrePipelineMutateCameraState(ref CameraState curState, float deltaTime)
		{
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600026E RID: 622
		public abstract CinemachineCore.Stage Stage { get; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600026F RID: 623 RVA: 0x00011B9F File Offset: 0x0000FD9F
		public virtual bool BodyAppliesAfterAim
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000270 RID: 624
		public abstract void MutateCameraState(ref CameraState curState, float deltaTime);

		// Token: 0x06000271 RID: 625 RVA: 0x00011BA2 File Offset: 0x0000FDA2
		public virtual bool OnTransitionFromCamera(ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime, ref CinemachineVirtualCameraBase.TransitionParams transitionParams)
		{
			return false;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00011BA5 File Offset: 0x0000FDA5
		public virtual void OnTargetObjectWarped(Transform target, Vector3 positionDelta)
		{
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00011BA7 File Offset: 0x0000FDA7
		public virtual void ForceCameraPosition(Vector3 pos, Quaternion rot)
		{
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00011BA9 File Offset: 0x0000FDA9
		public virtual float GetMaxDampTime()
		{
			return 0f;
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000275 RID: 629 RVA: 0x00011BB0 File Offset: 0x0000FDB0
		public virtual bool RequiresUserInput
		{
			get
			{
				return false;
			}
		}

		// Token: 0x040001C7 RID: 455
		protected const float Epsilon = 0.0001f;

		// Token: 0x040001C8 RID: 456
		private CinemachineVirtualCameraBase m_vcamOwner;
	}
}
