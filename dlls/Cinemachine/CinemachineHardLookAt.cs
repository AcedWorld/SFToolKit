using System;
using UnityEngine;

namespace Cinemachine
{
	// Token: 0x02000026 RID: 38
	[DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
	[AddComponentMenu("")]
	[SaveDuringPlay]
	public class CinemachineHardLookAt : CinemachineComponentBase
	{
		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001CB RID: 459 RVA: 0x0000E4E9 File Offset: 0x0000C6E9
		public override bool IsValid
		{
			get
			{
				return base.enabled && base.LookAtTarget != null;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001CC RID: 460 RVA: 0x0000E501 File Offset: 0x0000C701
		public override CinemachineCore.Stage Stage
		{
			get
			{
				return CinemachineCore.Stage.Aim;
			}
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000E504 File Offset: 0x0000C704
		public override void MutateCameraState(ref CameraState curState, float deltaTime)
		{
			if (this.IsValid && curState.HasLookAt)
			{
				Vector3 vector = curState.ReferenceLookAt - curState.CorrectedPosition;
				if (vector.magnitude > 0.0001f)
				{
					if (Vector3.Cross(vector.normalized, curState.ReferenceUp).magnitude < 0.0001f)
					{
						curState.RawOrientation = Quaternion.FromToRotation(Vector3.forward, vector);
						return;
					}
					curState.RawOrientation = Quaternion.LookRotation(vector, curState.ReferenceUp);
				}
			}
		}
	}
}
