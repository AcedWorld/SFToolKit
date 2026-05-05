using System;
using System.Collections.Generic;
using Rewired.Internal;
using Rewired.Internal.Localization;
using Rewired.Platforms.Custom;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Platforms.XboxOne
{
	// Token: 0x02000219 RID: 537
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class XboxOneInputSource : CustomInputSource, IXboxOneInputSource
	{
		// Token: 0x17000621 RID: 1569
		// (get) Token: 0x06001948 RID: 6472 RVA: 0x00014C71 File Offset: 0x00012E71
		public override bool isReady
		{
			get
			{
				return this.OUrrAqSjdCeUKWxTzOsMTzTPJfME;
			}
		}

		// Token: 0x06001949 RID: 6473 RVA: 0x00070E2C File Offset: 0x0006F02C
		public XboxOneInputSource() : base(21)
		{
			try
			{
				this.cXydTQgYTyfWOzELNDpXISTGhvjL = new Queue<XboxOneInputSource.qpCemzGckJglNABvOiokpZHCnFKi>();
				base.useApproximateMatching = false;
				for (int i = 0; i < 8; i++)
				{
					int num = i + 1;
					XboxOneInputSource.BadConnectionReason badConnectionReason;
					bool flag = this.yyThBcTdCkuxzgSRLDvzhFsiFuFeA((uint)num, true, out badConnectionReason);
					ulong num2 = flag ? UnityTools.externalTools.XboxOneInput_GetControllerId((uint)num) : 0UL;
					base.AddJoystick(new XboxOneInputSource.MTTxmNkKOKFxWgvJqgzaGjDTRMSmA(this, num2, num, flag)
					{
						supportsVibration = true
					});
				}
				UnityTools.externalTools.XboxOneInput_OnGamepadStateChange += this.ydlcTTcVaxbOVOLaqaUIvOhXgtOL;
				this.OUrrAqSjdCeUKWxTzOsMTzTPJfME = true;
			}
			catch
			{
			}
		}

		// Token: 0x0600194A RID: 6474 RVA: 0x00070ED4 File Offset: 0x0006F0D4
		public override void Update()
		{
			if (!this.OUrrAqSjdCeUKWxTzOsMTzTPJfME)
			{
				return;
			}
			this.zuxHJtKvbUOmiqdELfXafoBAfhZH();
			UnityTools.externalTools.XboxOne_Gamepad_UpdatePlugin();
			IList<CustomInputSource.Joystick> joysticks = base.GetJoysticks();
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				joysticks[i].Update();
			}
		}

		// Token: 0x0600194B RID: 6475 RVA: 0x00070F20 File Offset: 0x0006F120
		private void ydlcTTcVaxbOVOLaqaUIvOhXgtOL(uint A_1, bool A_2)
		{
			if (!this.OUrrAqSjdCeUKWxTzOsMTzTPJfME)
			{
				return;
			}
			if (A_1 <= 0U)
			{
				Logger.LogError("Invalid unity joystick id");
				return;
			}
			if (A_2)
			{
				XboxOneInputSource.BadConnectionReason badConnectionReason;
				if (this.yyThBcTdCkuxzgSRLDvzhFsiFuFeA(A_1, true, out badConnectionReason))
				{
					this.qmTDxzghkaPeKyfgJzEjrsuwOsKs(A_1, true);
					return;
				}
			}
			else
			{
				int index = (int)(A_1 - 1U);
				(base.GetJoysticks()[index] as XboxOneInputSource.MTTxmNkKOKFxWgvJqgzaGjDTRMSmA).Disconnect();
				this.OnJoystickDisconnected();
			}
		}

		// Token: 0x0600194C RID: 6476 RVA: 0x00070F80 File Offset: 0x0006F180
		private void qmTDxzghkaPeKyfgJzEjrsuwOsKs(uint A_1, bool A_2)
		{
			int index = (int)(A_1 - 1U);
			XboxOneInputSource.MTTxmNkKOKFxWgvJqgzaGjDTRMSmA mttxmNkKOKFxWgvJqgzaGjDTRMSmA = base.GetJoysticks()[index] as XboxOneInputSource.MTTxmNkKOKFxWgvJqgzaGjDTRMSmA;
			ulong num = UnityTools.externalTools.XboxOneInput_GetControllerId(A_1);
			mttxmNkKOKFxWgvJqgzaGjDTRMSmA.twQlmSRAwgtmqWSlwxxtYEVJmSCI(num);
			if (A_2)
			{
				this.OnJoystickConnected();
			}
		}

		// Token: 0x0600194D RID: 6477 RVA: 0x00070FC0 File Offset: 0x0006F1C0
		private void zuxHJtKvbUOmiqdELfXafoBAfhZH()
		{
			int i = this.cXydTQgYTyfWOzELNDpXISTGhvjL.Count;
			if (i == 0)
			{
				return;
			}
			bool flag = false;
			uint currentFrame = ReInput.time.currentFrame;
			while (i > 0)
			{
				XboxOneInputSource.qpCemzGckJglNABvOiokpZHCnFKi qpCemzGckJglNABvOiokpZHCnFKi = this.cXydTQgYTyfWOzELNDpXISTGhvjL.Dequeue();
				if (currentFrame >= qpCemzGckJglNABvOiokpZHCnFKi.CpApSDXDnkdkYIMJRmRFULhtmHPQA + 1U)
				{
					XboxOneInputSource.BadConnectionReason badConnectionReason;
					if (this.yyThBcTdCkuxzgSRLDvzhFsiFuFeA(qpCemzGckJglNABvOiokpZHCnFKi.YJgQDawZCMSPSYMWVbtIqfzCKEri, true, out badConnectionReason))
					{
						this.qmTDxzghkaPeKyfgJzEjrsuwOsKs(qpCemzGckJglNABvOiokpZHCnFKi.YJgQDawZCMSPSYMWVbtIqfzCKEri, false);
						flag = true;
					}
				}
				else
				{
					this.cXydTQgYTyfWOzELNDpXISTGhvjL.Enqueue(qpCemzGckJglNABvOiokpZHCnFKi);
				}
				i--;
			}
			if (flag)
			{
				this.OnJoystickConnected();
			}
		}

		// Token: 0x0600194E RID: 6478 RVA: 0x00071044 File Offset: 0x0006F244
		private bool yyThBcTdCkuxzgSRLDvzhFsiFuFeA(uint A_1, bool A_2, out XboxOneInputSource.BadConnectionReason A_3)
		{
			if (!UnityTools.externalTools.XboxOneInput_IsGamepadActive(A_1))
			{
				A_3 = XboxOneInputSource.BadConnectionReason.GamepadNotActive;
				return false;
			}
			string text = UnityTools.externalTools.XboxOneInput_GetControllerType(UnityTools.externalTools.XboxOneInput_GetControllerId(A_1));
			if (string.IsNullOrEmpty(text) || text == " ")
			{
				if (A_2)
				{
					this.cXydTQgYTyfWOzELNDpXISTGhvjL.Enqueue(new XboxOneInputSource.qpCemzGckJglNABvOiokpZHCnFKi(A_1, ReInput.time.currentFrame));
				}
				A_3 = XboxOneInputSource.BadConnectionReason.InvalidName;
				return false;
			}
			A_3 = XboxOneInputSource.BadConnectionReason.None;
			return true;
		}

		// Token: 0x0600194F RID: 6479 RVA: 0x00014C79 File Offset: 0x00012E79
		private void RWRmBjTTJiWNIqygAPHmveRMFTTd()
		{
			if (this.dTDPcbHYTTMyRdfJWcEdmKyUuWih)
			{
				return;
			}
			this.dTDPcbHYTTMyRdfJWcEdmKyUuWih = true;
			Logger.LogError("A required native library is missing! See documentation for Xbox One installation instructions.");
		}

		// Token: 0x06001950 RID: 6480 RVA: 0x00014C95 File Offset: 0x00012E95
		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			if (!this.OUrrAqSjdCeUKWxTzOsMTzTPJfME)
			{
				return -1;
			}
			return UnityTools.externalTools.XboxOneInput_GetUserIdForGamepad((uint)unityJoystickId);
		}

		// Token: 0x06001951 RID: 6481 RVA: 0x000710B8 File Offset: 0x0006F2B8
		public void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (!this.OUrrAqSjdCeUKWxTzOsMTzTPJfME)
			{
				return;
			}
			ulong durationMS = (ulong)(duration * 1000f);
			UnityTools.externalTools.XboxOne_Gamepad_PulseVibrateMotor(xboxOneJoystickId, (int)motor, startLevel, endLevel, durationMS);
		}

		// Token: 0x06001952 RID: 6482 RVA: 0x00014CAC File Offset: 0x00012EAC
		public bool SetXboxOneVibration(ulong xboxOneJoystickId, eSdkeiNbMcydmNPVeUBLWdxGyQBY vibration)
		{
			return this.OUrrAqSjdCeUKWxTzOsMTzTPJfME && UnityTools.externalTools.XboxOne_Gamepad_SetGamepadVibration(xboxOneJoystickId, vibration.gdBPKlEdhBDpGEcYiIRVAgICEphbB, vibration.rsRYIFctnTdEVaccRwfIxKCqKsnaA, vibration.hRlKGOKRGYLWBqITgkPCbICHbOgkA, vibration.VTcIEopRaueHhlLCffWgHzzBscenA);
		}

		// Token: 0x06001953 RID: 6483 RVA: 0x00014CDB File Offset: 0x00012EDB
		public override void Dispose()
		{
			base.Dispose();
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06001954 RID: 6484 RVA: 0x000710E8 File Offset: 0x0006F2E8
		~XboxOneInputSource()
		{
			this.Dispose(false);
		}

		// Token: 0x06001955 RID: 6485 RVA: 0x00014CF0 File Offset: 0x00012EF0
		protected override void Dispose(bool disposing)
		{
			if (this.ahLkbWmbGQDdUSpymVojREZOJKsy)
			{
				return;
			}
			if (disposing)
			{
				UnityTools.externalTools.XboxOneInput_OnGamepadStateChange -= this.ydlcTTcVaxbOVOLaqaUIvOhXgtOL;
			}
			this.ahLkbWmbGQDdUSpymVojREZOJKsy = true;
		}

		// Token: 0x04000E62 RID: 3682
		private const int vrMgDfCppsmvIdIdtJlGAsbIXUoZA = 8;

		// Token: 0x04000E63 RID: 3683
		private readonly bool OUrrAqSjdCeUKWxTzOsMTzTPJfME;

		// Token: 0x04000E64 RID: 3684
		private bool dTDPcbHYTTMyRdfJWcEdmKyUuWih;

		// Token: 0x04000E65 RID: 3685
		private Queue<XboxOneInputSource.qpCemzGckJglNABvOiokpZHCnFKi> cXydTQgYTyfWOzELNDpXISTGhvjL;

		// Token: 0x04000E66 RID: 3686
		private bool ahLkbWmbGQDdUSpymVojREZOJKsy;

		// Token: 0x0200021A RID: 538
		[CustomObfuscation(rename = false)]
		private enum BadConnectionReason
		{
			// Token: 0x04000E68 RID: 3688
			[CustomObfuscation(rename = false)]
			None,
			// Token: 0x04000E69 RID: 3689
			[CustomObfuscation(rename = false)]
			GamepadNotActive,
			// Token: 0x04000E6A RID: 3690
			[CustomObfuscation(rename = false)]
			InvalidName
		}

		// Token: 0x0200021B RID: 539
		private struct qpCemzGckJglNABvOiokpZHCnFKi
		{
			// Token: 0x06001956 RID: 6486 RVA: 0x00014D1B File Offset: 0x00012F1B
			public qpCemzGckJglNABvOiokpZHCnFKi(uint A_1, uint A_2)
			{
				this.YJgQDawZCMSPSYMWVbtIqfzCKEri = A_1;
				this.CpApSDXDnkdkYIMJRmRFULhtmHPQA = A_2;
			}

			// Token: 0x04000E6B RID: 3691
			public uint YJgQDawZCMSPSYMWVbtIqfzCKEri;

			// Token: 0x04000E6C RID: 3692
			public uint CpApSDXDnkdkYIMJRmRFULhtmHPQA;
		}

		// Token: 0x0200021C RID: 540
		private class MTTxmNkKOKFxWgvJqgzaGjDTRMSmA : CustomInputSource.Joystick, ITryGetLocalizedName, IInputManagerHardwareJoystickMapHandler
		{
			// Token: 0x17000622 RID: 1570
			// (get) Token: 0x06001957 RID: 6487 RVA: 0x00014D2B File Offset: 0x00012F2B
			public ulong JkRSglDNmZwgHsWsyoMBLyqWUuOh
			{
				get
				{
					return this.LylaZXyAgKPJVHfYVSXRbpMCxoxX;
				}
			}

			// Token: 0x06001958 RID: 6488 RVA: 0x00071118 File Offset: 0x0006F318
			public MTTxmNkKOKFxWgvJqgzaGjDTRMSmA(IXboxOneInputSource A_1, ulong A_2, int A_3, bool A_4) : base(A_4 ? UnityTools.externalTools.XboxOneInput_GetControllerType(A_2) : "Xbox One Controller", new long?((long)A_2), A_3, 6, 14)
			{
				this.LYDPbTrKYWebjjAWZnEGJmZtEayJA = A_1;
				this.aSemVeeMQaYOuRMJKWwVmtgbhexT = A_3 - 1;
				this.uFHOAkYRyjTTNJdCArYoxaPFewOCA = new string[6];
				this.qvXyEeazNFJyvpNArUeNEaRKKBBs();
				this.CUFOAIgaqUwirkaIuADdaZMwIYiB = new LocalizedString();
				base.extension = new XboxOneGamepadExtension(true, A_1);
				this._isConnected = A_4;
				if (this._isConnected)
				{
					this.twQlmSRAwgtmqWSlwxxtYEVJmSCI(A_2);
					return;
				}
				this.LylaZXyAgKPJVHfYVSXRbpMCxoxX = A_2;
			}

			// Token: 0x06001959 RID: 6489 RVA: 0x000711A4 File Offset: 0x0006F3A4
			public virtual void FRLNBvouGioBklgKVpArNkBjvLRK()
			{
				if (!this._isConnected)
				{
					return;
				}
				IList<CustomInputSource.Button> buttons = base.Buttons;
				buttons[0].boolValue = this.jIsboujnYnsaTxYdqIShQvdUdEJH(0);
				buttons[1].boolValue = this.jIsboujnYnsaTxYdqIShQvdUdEJH(1);
				buttons[2].boolValue = this.jIsboujnYnsaTxYdqIShQvdUdEJH(2);
				buttons[3].boolValue = this.jIsboujnYnsaTxYdqIShQvdUdEJH(3);
				buttons[4].boolValue = this.jIsboujnYnsaTxYdqIShQvdUdEJH(4);
				buttons[5].boolValue = this.jIsboujnYnsaTxYdqIShQvdUdEJH(5);
				buttons[6].boolValue = this.jIsboujnYnsaTxYdqIShQvdUdEJH(6);
				buttons[7].boolValue = this.jIsboujnYnsaTxYdqIShQvdUdEJH(7);
				buttons[8].boolValue = this.jIsboujnYnsaTxYdqIShQvdUdEJH(8);
				buttons[9].boolValue = this.jIsboujnYnsaTxYdqIShQvdUdEJH(9);
				buttons[10].boolValue = this.jIsboujnYnsaTxYdqIShQvdUdEJH(12);
				buttons[11].boolValue = this.jIsboujnYnsaTxYdqIShQvdUdEJH(15);
				buttons[12].boolValue = this.jIsboujnYnsaTxYdqIShQvdUdEJH(13);
				buttons[13].boolValue = this.jIsboujnYnsaTxYdqIShQvdUdEJH(14);
				IList<CustomInputSource.Axis> axes = base.Axes;
				axes[0].value = Input.GetAxisRaw(this.uFHOAkYRyjTTNJdCArYoxaPFewOCA[0]);
				axes[1].value = Input.GetAxisRaw(this.uFHOAkYRyjTTNJdCArYoxaPFewOCA[1]);
				axes[2].value = Input.GetAxisRaw(this.uFHOAkYRyjTTNJdCArYoxaPFewOCA[2]);
				axes[3].value = Input.GetAxisRaw(this.uFHOAkYRyjTTNJdCArYoxaPFewOCA[3]);
				axes[4].value = Input.GetAxisRaw(this.uFHOAkYRyjTTNJdCArYoxaPFewOCA[4]);
				axes[5].value = Input.GetAxisRaw(this.uFHOAkYRyjTTNJdCArYoxaPFewOCA[5]);
			}

			// Token: 0x0600195A RID: 6490 RVA: 0x00071370 File Offset: 0x0006F570
			public void twQlmSRAwgtmqWSlwxxtYEVJmSCI(ulong A_1)
			{
				if (this._isConnected)
				{
					return;
				}
				this._isConnected = true;
				this.LylaZXyAgKPJVHfYVSXRbpMCxoxX = A_1;
				base.systemId = new long?((long)A_1);
				if (UnityTools.externalTools.XboxOneInput_GetJoystickId(A_1) != (uint)base.unityId)
				{
					Logger.LogError("Unity joystick id does not match expected id!");
					this._isConnected = false;
					return;
				}
				this.ohlPZYRhiRQIxbkNJwFsrxKepaHh();
			}

			// Token: 0x0600195B RID: 6491 RVA: 0x000713CC File Offset: 0x0006F5CC
			private void ohlPZYRhiRQIxbkNJwFsrxKepaHh()
			{
				if (this._isConnected)
				{
					this._deviceName = UnityTools.externalTools.XboxOneInput_GetControllerType(this.LylaZXyAgKPJVHfYVSXRbpMCxoxX);
				}
				this._customName = string.Format("{0} {1}", "Controller", base.unityId);
				this.CUFOAIgaqUwirkaIuADdaZMwIYiB.Clear();
			}

			// Token: 0x0600195C RID: 6492 RVA: 0x00014D33 File Offset: 0x00012F33
			private bool jIsboujnYnsaTxYdqIShQvdUdEJH(int A_1)
			{
				return Input.GetKey(KeyCode.Joystick1Button0 + A_1 + this.aSemVeeMQaYOuRMJKWwVmtgbhexT * 20);
			}

			// Token: 0x0600195D RID: 6493 RVA: 0x00071424 File Offset: 0x0006F624
			private void qvXyEeazNFJyvpNArUeNEaRKKBBs()
			{
				this.uFHOAkYRyjTTNJdCArYoxaPFewOCA[0] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 0);
				this.uFHOAkYRyjTTNJdCArYoxaPFewOCA[1] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 1);
				this.uFHOAkYRyjTTNJdCArYoxaPFewOCA[2] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 3);
				this.uFHOAkYRyjTTNJdCArYoxaPFewOCA[3] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 4);
				this.uFHOAkYRyjTTNJdCArYoxaPFewOCA[4] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 8);
				this.uFHOAkYRyjTTNJdCArYoxaPFewOCA[5] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 9);
			}

			// Token: 0x0600195E RID: 6494 RVA: 0x00014D4B File Offset: 0x00012F4B
			void IInputManagerHardwareJoystickMapHandler.InitializeHardwareJoystickMap(HardwareJoystickMap_InputManager hardwareMap)
			{
				this.rFsPrlheOAfZSfmGhdpzaPjaphgf = hardwareMap;
			}

			// Token: 0x0600195F RID: 6495 RVA: 0x000714AC File Offset: 0x0006F6AC
			bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
			{
				if (this.rFsPrlheOAfZSfmGhdpzaPjaphgf == null)
				{
					value = null;
					return false;
				}
				if ((LocalizationManager.GetAndUpdateLocalizedString(this.CUFOAIgaqUwirkaIuADdaZMwIYiB, this.rFsPrlheOAfZSfmGhdpzaPjaphgf.deviceLocalizationInfo.parentKeys, "controller", "Controller", out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
				{
					value = string.Format("{0} {1}", value, base.unityId);
					this.CUFOAIgaqUwirkaIuADdaZMwIYiB.cachedValue = value;
				}
				return true;
			}

			// Token: 0x04000E6D RID: 3693
			private const int pPmnutrzoXLeplBtQGxVVWyULZgj = 6;

			// Token: 0x04000E6E RID: 3694
			private const int dlNlbCUbCogaeMLGeifVFnqMFqLX = 14;

			// Token: 0x04000E6F RID: 3695
			private const string XgqtPerdwYNhvZjTQsrbyJUJZEWH = "Xbox One Controller";

			// Token: 0x04000E70 RID: 3696
			private const string gZBvOdhRiauAcrIYyjKyFjrEMYiQ = "Controller";

			// Token: 0x04000E71 RID: 3697
			private const int lDNqoBsRfvYHzUigAjaCguuPwAtQ = 0;

			// Token: 0x04000E72 RID: 3698
			private const int QuTqTnNYfCQOCpiTUbGlKDCIPZXz = 1;

			// Token: 0x04000E73 RID: 3699
			private const int hfeFqvLqsDKyKPjIojYmgUsiNZbc = 2;

			// Token: 0x04000E74 RID: 3700
			private const int jQPMuNgINWLuTBkheCrVZVpyeRPgA = 3;

			// Token: 0x04000E75 RID: 3701
			private const int tpKEDddNXpSURGglRgYNlTXQUvdl = 4;

			// Token: 0x04000E76 RID: 3702
			private const int zrIOkXWgOaBKKSdemgPyslPVvpUs = 5;

			// Token: 0x04000E77 RID: 3703
			private const int ccfBmudvbXNodUYgkMlNlDHeAmTM = 6;

			// Token: 0x04000E78 RID: 3704
			private const int sOlrWoyatEvsPlIvoCdDmHEqZHAD = 7;

			// Token: 0x04000E79 RID: 3705
			private const int osNZtasEQVExpomXuhLiVJdZWuIj = 8;

			// Token: 0x04000E7A RID: 3706
			private const int QIxIEwHaPVKFbtBBsLHAEesniAcH = 9;

			// Token: 0x04000E7B RID: 3707
			private const int RYcvUrOEKLReSrbdSjLopJTCLQzH = 12;

			// Token: 0x04000E7C RID: 3708
			private const int sFzKvmRfSmiKDusEocYyPyMbtbdW = 13;

			// Token: 0x04000E7D RID: 3709
			private const int BViukJlymKwnXKZpYtbaMDvylIXm = 14;

			// Token: 0x04000E7E RID: 3710
			private const int AnRetxYLQaGjUNjPpzkFzwiLUljm = 15;

			// Token: 0x04000E7F RID: 3711
			private const int QHiEUopacuvfCyFNtHPDjmFNAHATA = 0;

			// Token: 0x04000E80 RID: 3712
			private const int BaLgtPosefecMrkGfeDCovyLwcQl = 1;

			// Token: 0x04000E81 RID: 3713
			private const int RzVugsLJmniWmvltROsQtJDepZlV = 3;

			// Token: 0x04000E82 RID: 3714
			private const int nJZTgjANLkUBIVwYsBLGaOfQtFsy = 4;

			// Token: 0x04000E83 RID: 3715
			private const int jCkgIPmxYPAAYpApvYceCvyjlrDh = 8;

			// Token: 0x04000E84 RID: 3716
			private const int hfIBTHiAnJugxlqZCcODCGaIMjxCA = 9;

			// Token: 0x04000E85 RID: 3717
			private readonly IXboxOneInputSource LYDPbTrKYWebjjAWZnEGJmZtEayJA;

			// Token: 0x04000E86 RID: 3718
			private int aSemVeeMQaYOuRMJKWwVmtgbhexT;

			// Token: 0x04000E87 RID: 3719
			private ulong LylaZXyAgKPJVHfYVSXRbpMCxoxX;

			// Token: 0x04000E88 RID: 3720
			private string[] uFHOAkYRyjTTNJdCArYoxaPFewOCA;

			// Token: 0x04000E89 RID: 3721
			private HardwareJoystickMap_InputManager rFsPrlheOAfZSfmGhdpzaPjaphgf;

			// Token: 0x04000E8A RID: 3722
			private readonly LocalizedString CUFOAIgaqUwirkaIuADdaZMwIYiB;
		}
	}
}
