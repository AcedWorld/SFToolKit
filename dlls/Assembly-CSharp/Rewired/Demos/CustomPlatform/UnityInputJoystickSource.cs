using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.Demos.CustomPlatform
{
	// Token: 0x020002DF RID: 735
	public class UnityInputJoystickSource
	{
		// Token: 0x06000F73 RID: 3955 RVA: 0x000522D3 File Offset: 0x000504D3
		public UnityInputJoystickSource()
		{
			this._joysticks = new List<UnityInputJoystickSource.Joystick>();
			this._joysticks_readOnly = new ReadOnlyCollection<UnityInputJoystickSource.Joystick>(this._joysticks);
			this.RefreshJoysticks();
		}

		// Token: 0x06000F74 RID: 3956 RVA: 0x00052309 File Offset: 0x00050509
		public void Update()
		{
			this.CheckForJoystickChanges();
		}

		// Token: 0x06000F75 RID: 3957 RVA: 0x00052311 File Offset: 0x00050511
		public IList<UnityInputJoystickSource.Joystick> GetJoysticks()
		{
			return this._joysticks_readOnly;
		}

		// Token: 0x06000F76 RID: 3958 RVA: 0x0005231C File Offset: 0x0005051C
		private void CheckForJoystickChanges()
		{
			double unscaledTime = ReInput.time.unscaledTime;
			if (unscaledTime >= this._nextJoystickCheckTime)
			{
				this._nextJoystickCheckTime = unscaledTime + 1.0;
				if (this.DidJoysticksChange())
				{
					this.RefreshJoysticks();
				}
			}
		}

		// Token: 0x06000F77 RID: 3959 RVA: 0x0005235C File Offset: 0x0005055C
		private bool DidJoysticksChange()
		{
			string[] joystickNames = Input.GetJoystickNames();
			string[] unityJoysticks = this._unityJoysticks;
			this._unityJoysticks = joystickNames;
			if (unityJoysticks.Length != joystickNames.Length)
			{
				return true;
			}
			for (int i = 0; i < joystickNames.Length; i++)
			{
				if (!string.Equals(unityJoysticks[i], joystickNames[i], StringComparison.Ordinal))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000F78 RID: 3960 RVA: 0x000523A8 File Offset: 0x000505A8
		private void RefreshJoysticks()
		{
			bool[] array = new bool[this._unityJoysticks.Length];
			for (int i = this._joysticks.Count - 1; i >= 0; i--)
			{
				int unityIndex = this._joysticks[i].unityIndex;
				if (unityIndex >= this._unityJoysticks.Length || !string.Equals(this._joysticks[i].deviceName, this._unityJoysticks[unityIndex]))
				{
					bool flag = false;
					for (int j = this._unityJoysticks.Length - 1; j >= 0; j--)
					{
						if (!array[j] && string.Equals(this._unityJoysticks[j], this._joysticks[i].deviceName))
						{
							this._joysticks[i].unityIndex = j;
							array[j] = true;
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						Debug.Log(this._joysticks[i].deviceName + " was disconnected.");
						this._joysticks.RemoveAt(i);
					}
				}
				else
				{
					array[unityIndex] = true;
				}
			}
			for (int k = 0; k < this._unityJoysticks.Length; k++)
			{
				if (!array[k] && !string.IsNullOrEmpty(this._unityJoysticks[k]))
				{
					UnityInputJoystickSource.Joystick joystick;
					if (this._unityJoysticks[k].ToLower().Contains("xbox one") || this._unityJoysticks[k].ToLower().Contains("xbox bluetooth"))
					{
						joystick = new UnityInputJoystickSource.Joystick((long)UnityInputJoystickSource.systemIdCounter++, this._unityJoysticks[k], 7, 16);
						joystick.identifier = new MyPlatformControllerIdentifier
						{
							vendorId = 1118,
							productId = 721
						};
						joystick.vibrationMotorCount = 2;
					}
					else
					{
						joystick = new UnityInputJoystickSource.Joystick((long)UnityInputJoystickSource.systemIdCounter++, this._unityJoysticks[k], 10, 20);
					}
					joystick.unityIndex = k;
					Debug.Log(this._unityJoysticks[k] + " was connected.");
					this._joysticks.Add(joystick);
				}
			}
		}

		// Token: 0x04001401 RID: 5121
		private const float joystickCheckInterval = 1f;

		// Token: 0x04001402 RID: 5122
		private static int systemIdCounter;

		// Token: 0x04001403 RID: 5123
		private string[] _unityJoysticks = new string[0];

		// Token: 0x04001404 RID: 5124
		private double _nextJoystickCheckTime;

		// Token: 0x04001405 RID: 5125
		private List<UnityInputJoystickSource.Joystick> _joysticks;

		// Token: 0x04001406 RID: 5126
		private ReadOnlyCollection<UnityInputJoystickSource.Joystick> _joysticks_readOnly;

		// Token: 0x020002E0 RID: 736
		public class Joystick : IControllerVibrator
		{
			// Token: 0x06000F79 RID: 3961 RVA: 0x000525C5 File Offset: 0x000507C5
			public Joystick(long systemId, string deviceName, int axisCount, int buttonCount)
			{
				this.systemId = systemId;
				this.deviceName = deviceName;
				this.axisCount = axisCount;
				this.buttonCount = buttonCount;
				this.axisValues = new float[axisCount];
				this.buttonValues = new bool[buttonCount];
			}

			// Token: 0x06000F7A RID: 3962 RVA: 0x00052603 File Offset: 0x00050803
			public bool GetButtonValue(int index)
			{
				return index < 20 && this.systemId < 8L && Input.GetKey(KeyCode.Joystick1Button0 + this.unityIndex * 20 + index);
			}

			// Token: 0x06000F7B RID: 3963 RVA: 0x00052630 File Offset: 0x00050830
			public float GetAxisValue(int index)
			{
				if (index >= 10)
				{
					return 0f;
				}
				if (this.systemId >= 8L)
				{
					return 0f;
				}
				return Input.GetAxis("Joy" + (this.unityIndex + 1).ToString() + "Axis" + (index + 1).ToString());
			}

			// Token: 0x17000311 RID: 785
			// (get) Token: 0x06000F7C RID: 3964 RVA: 0x00052687 File Offset: 0x00050887
			// (set) Token: 0x06000F7D RID: 3965 RVA: 0x0005268F File Offset: 0x0005088F
			public int vibrationMotorCount { get; set; }

			// Token: 0x06000F7E RID: 3966 RVA: 0x00052698 File Offset: 0x00050898
			public void SetVibration(int motorIndex, float motorLevel)
			{
				Debug.Log(string.Concat(new string[]
				{
					"Vibrate ",
					this.deviceName,
					": motorIndex: ",
					motorIndex.ToString(),
					", motorLevel: ",
					motorLevel.ToString()
				}));
			}

			// Token: 0x06000F7F RID: 3967 RVA: 0x000526EC File Offset: 0x000508EC
			public void SetVibration(int motorIndex, float motorLevel, float duration)
			{
				Debug.Log(string.Concat(new string[]
				{
					"Vibrate ",
					this.deviceName,
					": motorIndex: ",
					motorIndex.ToString(),
					", motorLevel: ",
					motorLevel.ToString(),
					", duration: ",
					duration.ToString()
				}));
			}

			// Token: 0x06000F80 RID: 3968 RVA: 0x00052750 File Offset: 0x00050950
			public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
			{
				Debug.Log(string.Concat(new string[]
				{
					"Vibrate ",
					this.deviceName,
					": motorIndex: ",
					motorIndex.ToString(),
					", motorLevel: ",
					motorLevel.ToString(),
					", stopOtherMotors: ",
					stopOtherMotors.ToString()
				}));
			}

			// Token: 0x06000F81 RID: 3969 RVA: 0x000527B4 File Offset: 0x000509B4
			public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
			{
				Debug.Log(string.Concat(new string[]
				{
					"Vibrate ",
					this.deviceName,
					": motorIndex: ",
					motorIndex.ToString(),
					", motorLevel: ",
					motorLevel.ToString(),
					", duration: ",
					duration.ToString(),
					", stopOtherMotors: ",
					stopOtherMotors.ToString()
				}));
			}

			// Token: 0x06000F82 RID: 3970 RVA: 0x0005282C File Offset: 0x00050A2C
			public float GetVibration(int motorIndex)
			{
				return 0f;
			}

			// Token: 0x06000F83 RID: 3971 RVA: 0x00052833 File Offset: 0x00050A33
			public void StopVibration()
			{
				Debug.Log("Stop vibration " + this.deviceName);
			}

			// Token: 0x04001407 RID: 5127
			private const int maxJoysticks = 8;

			// Token: 0x04001408 RID: 5128
			private const int maxAxes = 10;

			// Token: 0x04001409 RID: 5129
			private const int maxButtons = 20;

			// Token: 0x0400140A RID: 5130
			public readonly long systemId;

			// Token: 0x0400140B RID: 5131
			public readonly string deviceName;

			// Token: 0x0400140C RID: 5132
			public Guid deviceInstanceGuid;

			// Token: 0x0400140D RID: 5133
			public readonly int axisCount;

			// Token: 0x0400140E RID: 5134
			public readonly int buttonCount;

			// Token: 0x0400140F RID: 5135
			public MyPlatformControllerIdentifier identifier;

			// Token: 0x04001410 RID: 5136
			public readonly bool[] buttonValues;

			// Token: 0x04001411 RID: 5137
			public readonly float[] axisValues;

			// Token: 0x04001412 RID: 5138
			public int unityIndex;
		}
	}
}
