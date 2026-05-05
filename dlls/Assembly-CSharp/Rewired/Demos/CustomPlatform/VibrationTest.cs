using System;
using UnityEngine;

namespace Rewired.Demos.CustomPlatform
{
	// Token: 0x020002E1 RID: 737
	public class VibrationTest : MonoBehaviour
	{
		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06000F84 RID: 3972 RVA: 0x0005284A File Offset: 0x00050A4A
		private Player player
		{
			get
			{
				return ReInput.players.GetPlayer(this.playerId);
			}
		}

		// Token: 0x06000F85 RID: 3973 RVA: 0x0005285C File Offset: 0x00050A5C
		private void Update()
		{
			for (int i = 0; i < VibrationTest.action_motors.Length; i++)
			{
				if (this.player.GetButtonDown(VibrationTest.action_motors[i]))
				{
					this.SetVibration(i, Mathf.Clamp01(this.motors[i] + this.vibrationIncrement));
				}
				if (this.player.GetNegativeButtonDown(VibrationTest.action_motors[i]))
				{
					this.SetVibration(i, Mathf.Clamp01(this.motors[i] - this.vibrationIncrement));
				}
			}
			if (this.player.GetButtonDown(VibrationTest.action_stop))
			{
				this.StopVibration();
			}
		}

		// Token: 0x06000F86 RID: 3974 RVA: 0x000528F1 File Offset: 0x00050AF1
		private void StopVibration()
		{
			this.player.StopVibration();
			Array.Clear(this.motors, 0, this.motors.Length);
		}

		// Token: 0x06000F87 RID: 3975 RVA: 0x00052912 File Offset: 0x00050B12
		private void SetVibration(int motorIndex, float value)
		{
			this.motors[motorIndex] = value;
			this.player.SetVibration(motorIndex, this.motors[motorIndex]);
		}

		// Token: 0x04001414 RID: 5140
		public int playerId;

		// Token: 0x04001415 RID: 5141
		public float vibrationIncrement = 0.1f;

		// Token: 0x04001416 RID: 5142
		private float[] motors = new float[2];

		// Token: 0x04001417 RID: 5143
		private static readonly string[] action_motors = new string[]
		{
			"VibrationMotor0",
			"VibrationMotor1"
		};

		// Token: 0x04001418 RID: 5144
		private static readonly string action_stop = "StopVibration";
	}
}
