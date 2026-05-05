using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000189 RID: 393
	public class VRIKCalibrationBasic : MonoBehaviour
	{
		// Token: 0x06000B24 RID: 2852 RVA: 0x000469E4 File Offset: 0x00044BE4
		private void LateUpdate()
		{
			if (Input.GetKeyDown(KeyCode.C))
			{
				this.data = VRIKCalibrator.Calibrate(this.ik, this.centerEyeAnchor, this.leftHandAnchor, this.rightHandAnchor, this.headAnchorPositionOffset, this.headAnchorRotationOffset, this.handAnchorPositionOffset, this.handAnchorRotationOffset, this.scaleMlp);
			}
			if (Input.GetKeyDown(KeyCode.D))
			{
				if (this.data.scale == 0f)
				{
					Debug.LogError("No Calibration Data to calibrate to, please calibrate with 'C' first.");
				}
				else
				{
					VRIKCalibrator.Calibrate(this.ik, this.data, this.centerEyeAnchor, null, this.leftHandAnchor, this.rightHandAnchor, null, null);
				}
			}
			if (Input.GetKeyDown(KeyCode.S))
			{
				if (this.data.scale == 0f)
				{
					Debug.LogError("Avatar needs to be calibrated before RecalibrateScale is called.");
				}
				VRIKCalibrator.RecalibrateScale(this.ik, this.data, this.scaleMlp);
			}
		}

		// Token: 0x04000B0E RID: 2830
		[Tooltip("The VRIK component.")]
		public VRIK ik;

		// Token: 0x04000B0F RID: 2831
		[Header("Head")]
		[Tooltip("HMD.")]
		public Transform centerEyeAnchor;

		// Token: 0x04000B10 RID: 2832
		[Tooltip("Position offset of the camera from the head bone (root space).")]
		public Vector3 headAnchorPositionOffset;

		// Token: 0x04000B11 RID: 2833
		[Tooltip("Rotation offset of the camera from the head bone (root space).")]
		public Vector3 headAnchorRotationOffset;

		// Token: 0x04000B12 RID: 2834
		[Header("Hands")]
		[Tooltip("Left Hand Controller")]
		public Transform leftHandAnchor;

		// Token: 0x04000B13 RID: 2835
		[Tooltip("Right Hand Controller")]
		public Transform rightHandAnchor;

		// Token: 0x04000B14 RID: 2836
		[Tooltip("Position offset of the hand controller from the hand bone (controller space).")]
		public Vector3 handAnchorPositionOffset;

		// Token: 0x04000B15 RID: 2837
		[Tooltip("Rotation offset of the hand controller from the hand bone (controller space).")]
		public Vector3 handAnchorRotationOffset;

		// Token: 0x04000B16 RID: 2838
		[Header("Scale")]
		[Tooltip("Multiplies the scale of the root.")]
		public float scaleMlp = 1f;

		// Token: 0x04000B17 RID: 2839
		[Header("Data stored by Calibration")]
		public VRIKCalibrator.CalibrationData data = new VRIKCalibrator.CalibrationData();
	}
}
