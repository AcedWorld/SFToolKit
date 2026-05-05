using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200018A RID: 394
	public class VRIKCalibrationController : MonoBehaviour
	{
		// Token: 0x06000B26 RID: 2854 RVA: 0x00046AE4 File Offset: 0x00044CE4
		private void LateUpdate()
		{
			if (Input.GetKeyDown(KeyCode.C))
			{
				this.data = VRIKCalibrator.Calibrate(this.ik, this.settings, this.headTracker, this.bodyTracker, this.leftHandTracker, this.rightHandTracker, this.leftFootTracker, this.rightFootTracker);
			}
			if (Input.GetKeyDown(KeyCode.D))
			{
				if (this.data.scale == 0f)
				{
					Debug.LogError("No Calibration Data to calibrate to, please calibrate with settings first.");
				}
				else
				{
					VRIKCalibrator.Calibrate(this.ik, this.data, this.headTracker, this.bodyTracker, this.leftHandTracker, this.rightHandTracker, this.leftFootTracker, this.rightFootTracker);
				}
			}
			if (Input.GetKeyDown(KeyCode.S))
			{
				if (this.data.scale == 0f)
				{
					Debug.LogError("Avatar needs to be calibrated before RecalibrateScale is called.");
				}
				VRIKCalibrator.RecalibrateScale(this.ik, this.data, this.settings);
			}
		}

		// Token: 0x04000B18 RID: 2840
		[Tooltip("Reference to the VRIK component on the avatar.")]
		public VRIK ik;

		// Token: 0x04000B19 RID: 2841
		[Tooltip("The settings for VRIK calibration.")]
		public VRIKCalibrator.Settings settings;

		// Token: 0x04000B1A RID: 2842
		[Tooltip("The HMD.")]
		public Transform headTracker;

		// Token: 0x04000B1B RID: 2843
		[Tooltip("(Optional) A tracker placed anywhere on the body of the player, preferrably close to the pelvis, on the belt area.")]
		public Transform bodyTracker;

		// Token: 0x04000B1C RID: 2844
		[Tooltip("(Optional) A tracker or hand controller device placed anywhere on or in the player's left hand.")]
		public Transform leftHandTracker;

		// Token: 0x04000B1D RID: 2845
		[Tooltip("(Optional) A tracker or hand controller device placed anywhere on or in the player's right hand.")]
		public Transform rightHandTracker;

		// Token: 0x04000B1E RID: 2846
		[Tooltip("(Optional) A tracker placed anywhere on the ankle or toes of the player's left leg.")]
		public Transform leftFootTracker;

		// Token: 0x04000B1F RID: 2847
		[Tooltip("(Optional) A tracker placed anywhere on the ankle or toes of the player's right leg.")]
		public Transform rightFootTracker;

		// Token: 0x04000B20 RID: 2848
		[Header("Data stored by Calibration")]
		public VRIKCalibrator.CalibrationData data = new VRIKCalibrator.CalibrationData();
	}
}
