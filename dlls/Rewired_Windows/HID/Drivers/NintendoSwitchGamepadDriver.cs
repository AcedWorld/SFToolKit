using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Rewired.ControllerExtensions;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	// Token: 0x02000316 RID: 790
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class NintendoSwitchGamepadDriver : HIDDeviceDriver, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		// Token: 0x170003BA RID: 954
		// (get) Token: 0x0600170F RID: 5903 RVA: 0x0001D0E9 File Offset: 0x0001B2E9
		public int vibrationMotorCount
		{
			get
			{
				return this._vibrationMotorCount;
			}
		}

		// Token: 0x06001710 RID: 5904 RVA: 0x00051554 File Offset: 0x0004F754
		public void GetVibration(int motorIndex, out float amplitudeLow, out float frequencyLow, out float amplitudeHigh, out float frequencyHigh)
		{
			if (motorIndex < 0 || motorIndex >= this._vibrationMotorCount)
			{
				amplitudeLow = 0f;
				frequencyLow = 0f;
				amplitudeHigh = 0f;
				frequencyHigh = 0f;
				return;
			}
			NintendoSwitchGamepadDriver.WiZKgdEAWCpRvMpxYSZXyaGcPOtU wiZKgdEAWCpRvMpxYSZXyaGcPOtU = this.jKeHBRxAQhNLMxfYBgnDRipQrVkk[motorIndex].nizCEkBOSbZkiCdYfosixZeltoyd;
			amplitudeLow = wiZKgdEAWCpRvMpxYSZXyaGcPOtU.oCCDxSlVTiwlUoQfaaGRkgvEiKwH;
			frequencyLow = wiZKgdEAWCpRvMpxYSZXyaGcPOtU.NGjeSPCzHqgRhcCMvrtzJrIXgojgb;
			amplitudeHigh = wiZKgdEAWCpRvMpxYSZXyaGcPOtU.TxDMmEQFfnAHsxMorWSySEpaOcSB;
			frequencyHigh = wiZKgdEAWCpRvMpxYSZXyaGcPOtU.yRpCvViNEAuOzpmyKKxuRVhmkyOM;
		}

		// Token: 0x06001711 RID: 5905 RVA: 0x0001D0F1 File Offset: 0x0001B2F1
		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh)
		{
			this.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, 0f, false);
		}

		// Token: 0x06001712 RID: 5906 RVA: 0x0001D106 File Offset: 0x0001B306
		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, bool stopOtherMotors)
		{
			this.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, 0f, stopOtherMotors);
		}

		// Token: 0x06001713 RID: 5907 RVA: 0x0001D11C File Offset: 0x0001B31C
		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration)
		{
			this.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration, false);
		}

		// Token: 0x06001714 RID: 5908 RVA: 0x0001D12E File Offset: 0x0001B32E
		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration, bool stopOtherMotors)
		{
			if (motorIndex < 0 || motorIndex >= this._vibrationMotorCount)
			{
				return;
			}
			if (stopOtherMotors)
			{
				this.mcijfeXHTvlRsUGXBAFEFgIQEHAFb(motorIndex);
			}
			this.jKeHBRxAQhNLMxfYBgnDRipQrVkk[motorIndex].NluaVtIjcIChcKRKGaQYzNEghhed(amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration);
		}

		// Token: 0x06001715 RID: 5909 RVA: 0x0001D15E File Offset: 0x0001B35E
		public void StopVibration(int motorIndex)
		{
			if (motorIndex < 0 || motorIndex >= this._vibrationMotorCount)
			{
				return;
			}
			this.jKeHBRxAQhNLMxfYBgnDRipQrVkk[motorIndex].YZqmLihxHysgnNOjPwTSWiasbBeL();
		}

		// Token: 0x06001716 RID: 5910 RVA: 0x000515C0 File Offset: 0x0004F7C0
		public void StopVibration()
		{
			for (int i = 0; i < this._vibrationMotorCount; i++)
			{
				this.jKeHBRxAQhNLMxfYBgnDRipQrVkk[i].YZqmLihxHysgnNOjPwTSWiasbBeL();
			}
		}

		// Token: 0x06001717 RID: 5911 RVA: 0x000515EC File Offset: 0x0004F7EC
		private void mcijfeXHTvlRsUGXBAFEFgIQEHAFb(int A_1)
		{
			for (int i = 0; i < this.jKeHBRxAQhNLMxfYBgnDRipQrVkk.Length; i++)
			{
				if (i != A_1)
				{
					this.jKeHBRxAQhNLMxfYBgnDRipQrVkk[i].YZqmLihxHysgnNOjPwTSWiasbBeL();
				}
			}
		}

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06001718 RID: 5912 RVA: 0x0001D17B File Offset: 0x0001B37B
		ushort IHIDControllerExtension.vendorId
		{
			get
			{
				return this.VVcWKkPdBdFEanbNFwoYoAPpMUPt.vendorId;
			}
		}

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06001719 RID: 5913 RVA: 0x0001D188 File Offset: 0x0001B388
		ushort IHIDControllerExtension.productId
		{
			get
			{
				return this.VVcWKkPdBdFEanbNFwoYoAPpMUPt.productId;
			}
		}

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x0600171A RID: 5914 RVA: 0x0001D195 File Offset: 0x0001B395
		string IHIDControllerExtension.productName
		{
			get
			{
				return this.VVcWKkPdBdFEanbNFwoYoAPpMUPt.productName;
			}
		}

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x0600171B RID: 5915 RVA: 0x0001D1A2 File Offset: 0x0001B3A2
		string IHIDControllerExtension.manufacturer
		{
			get
			{
				return this.VVcWKkPdBdFEanbNFwoYoAPpMUPt.manufacturer;
			}
		}

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x0600171C RID: 5916 RVA: 0x0001D1AF File Offset: 0x0001B3AF
		ushort IHIDControllerExtension.usagePage
		{
			get
			{
				return this.VVcWKkPdBdFEanbNFwoYoAPpMUPt.usagePage;
			}
		}

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x0600171D RID: 5917 RVA: 0x0001D1BC File Offset: 0x0001B3BC
		ushort IHIDControllerExtension.usage
		{
			get
			{
				return this.VVcWKkPdBdFEanbNFwoYoAPpMUPt.usage;
			}
		}

		// Token: 0x0600171E RID: 5918 RVA: 0x00051620 File Offset: 0x0004F820
		protected NintendoSwitchGamepadDriver(HIDDeviceDriver.InitArgs A_1, NintendoSwitchGamepadDriver.cLmDiWGVqVGnsnEnIZtSOAxhDrwpA A_2, int A_3, int A_4, int A_5)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			this._controllerType = A_2;
			this._buttonCount = A_3;
			this._axisCount = A_4;
			this._vibrationMotorCount = A_5;
			this.XpjQfqALnnpFFHmDtAGLBtlKinCaA = A_1.hidDevice;
			this.VVcWKkPdBdFEanbNFwoYoAPpMUPt = A_1.hidDevice.properties;
			this.UlNMtcKzXZHsCFUWZDbPcFmHeIYg = (A_1.connectionType == srhddSmbipxLrwlIqjetZPjyhATp.Bluetooth);
			this.JUCqtSpmJvvlpDeCppeqdwlNQpJr = new NativeBuffer(this.VVcWKkPdBdFEanbNFwoYoAPpMUPt.maxInputReportLength);
			this.HmpyquXoDaDhZOTwbAzUALAnVizw = new NativeBuffer(this.VVcWKkPdBdFEanbNFwoYoAPpMUPt.maxOutputReportLength);
			this.RpsFLqADjCTYelLwBOftZXcXTnevA = new NativeBuffer(32);
			this.yODTXFsKhrbGiWPMhRBakTIQDQVv = new byte[this.VVcWKkPdBdFEanbNFwoYoAPpMUPt.maxInputReportLength];
			this.eqHkcGtDjlCJcCmKoOUDXmXWcWlo = new NativeBuffer(this.VVcWKkPdBdFEanbNFwoYoAPpMUPt.maxOutputReportLength);
			this.voVZpdPpQMOXQXWPTupyTecVZvMe = new NativeBuffer(49);
			if (this.VVcWKkPdBdFEanbNFwoYoAPpMUPt.maxOutputReportLength < 2)
			{
				throw new ArgumentException("Output report buffer is too small.");
			}
			this.pkddbNUhTMBuEwrmGvTpLIFGeFlW = new AWHWYMjOaGiEqJCCtAEpfhRJAtYq(this.HmpyquXoDaDhZOTwbAzUALAnVizw.Pointer, this.HmpyquXoDaDhZOTwbAzUALAnVizw.Length, this.HmpyquXoDaDhZOTwbAzUALAnVizw.Length);
			this.wpzSLxsnINnAfPSbpdhioRPWdWXB = (!this.UlNMtcKzXZHsCFUWZDbPcFmHeIYg && UnityTools.effectivePlatform == Platform.Windows);
			ReInput.ApplicationPauseChangedEvent += this.qNUHRJiYOBGPsfSlCWvPMlPaSWNr;
			this.buttons = new bsHiSnxdPKGTmlVVXzABmREfuPAX[A_3];
			for (int i = 0; i < A_3; i++)
			{
				this.buttons[i] = new bsHiSnxdPKGTmlVVXzABmREfuPAX(33, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			this.mRYOXYPIUNhmzoPpnMMcLcQmbSfP = new NintendoSwitchGamepadDriver.jDXrftiygZEnrPnsgnWXphhhEXw[this._axisCount];
			this.vibrationMotors = new UnptiYUxBEDyXRujUEnkdeIKIoPk[A_5];
			for (int j = 0; j < this.vibrationMotors.Length; j++)
			{
				this.vibrationMotors[j] = new UnptiYUxBEDyXRujUEnkdeIKIoPk(0, 255);
			}
			this.jKeHBRxAQhNLMxfYBgnDRipQrVkk = new NintendoSwitchGamepadDriver.WexUQLBRjQmNWIwwWyDqJKNQTONG[A_5];
			for (int k = 0; k < this.jKeHBRxAQhNLMxfYBgnDRipQrVkk.Length; k++)
			{
				this.jKeHBRxAQhNLMxfYBgnDRipQrVkk[k] = new NintendoSwitchGamepadDriver.WexUQLBRjQmNWIwwWyDqJKNQTONG(this.vibrationMotors[k]);
			}
		}

		// Token: 0x0600171F RID: 5919 RVA: 0x00051824 File Offset: 0x0004FA24
		protected void Initialize()
		{
			this.hALRzvKVkGvxjTSLZfFBXTvARgPN = false;
			this.HmpyquXoDaDhZOTwbAzUALAnVizw.Clear();
			if (!this.UlNMtcKzXZHsCFUWZDbPcFmHeIYg)
			{
				NativeBuffer hmpyquXoDaDhZOTwbAzUALAnVizw = this.HmpyquXoDaDhZOTwbAzUALAnVizw;
				hmpyquXoDaDhZOTwbAzUALAnVizw[0] = 128;
				hmpyquXoDaDhZOTwbAzUALAnVizw[1] = 1;
				if (!this.wuVCMSEeppbKRFiTjurGyeuVCRtPc(xvcebytMmHXPBmUQiJYMACsdJpLo.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB connection status.", true);
					throw new Exception();
				}
				hmpyquXoDaDhZOTwbAzUALAnVizw[0] = 128;
				hmpyquXoDaDhZOTwbAzUALAnVizw[1] = 2;
				if (!this.wuVCMSEeppbKRFiTjurGyeuVCRtPc(xvcebytMmHXPBmUQiJYMACsdJpLo.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB handshake 1.", true);
					throw new Exception();
				}
				hmpyquXoDaDhZOTwbAzUALAnVizw[0] = 128;
				hmpyquXoDaDhZOTwbAzUALAnVizw[1] = 3;
				if (!this.wuVCMSEeppbKRFiTjurGyeuVCRtPc(xvcebytMmHXPBmUQiJYMACsdJpLo.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB set baudrate.", true);
					throw new Exception();
				}
				hmpyquXoDaDhZOTwbAzUALAnVizw[0] = 128;
				hmpyquXoDaDhZOTwbAzUALAnVizw[1] = 2;
				if (!this.wuVCMSEeppbKRFiTjurGyeuVCRtPc(xvcebytMmHXPBmUQiJYMACsdJpLo.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB handshake 2.", true);
					throw new Exception();
				}
				hmpyquXoDaDhZOTwbAzUALAnVizw[0] = 128;
				hmpyquXoDaDhZOTwbAzUALAnVizw[1] = 4;
				if (!this.wuVCMSEeppbKRFiTjurGyeuVCRtPc(xvcebytMmHXPBmUQiJYMACsdJpLo.Synchronous))
				{
					Logger.LogError("Failed to write output report to device: USB prevent hid timeout.", true);
					throw new Exception();
				}
			}
			if (!this.ZtXgZRgonqXuImdfFoXIDrCMDxKCb(new NintendoSwitchGamepadDriver.bdSyBruVRCMMzbzrsDudoFjvFwEi(72, new byte[]
			{
				1
			}, 1), this.yODTXFsKhrbGiWPMhRBakTIQDQVv))
			{
				throw new Exception();
			}
			if (!this.ZtXgZRgonqXuImdfFoXIDrCMDxKCb(new NintendoSwitchGamepadDriver.bdSyBruVRCMMzbzrsDudoFjvFwEi(3, new byte[]
			{
				48
			}, 1), this.yODTXFsKhrbGiWPMhRBakTIQDQVv))
			{
				throw new Exception();
			}
			this.ATRScfkdYJBVoFLFDTWqEsQQoWvE();
			if (!this.ZGoMXyqtSLPZlOHQgWdQLqcXdGsjA())
			{
				throw new Exception();
			}
			if (this.wpzSLxsnINnAfPSbpdhioRPWdWXB)
			{
				this.ZnylSgxRuczDgCatRZaPArBOMQjH = ReInput.realTime;
			}
			this.hALRzvKVkGvxjTSLZfFBXTvARgPN = true;
		}

		// Token: 0x06001720 RID: 5920 RVA: 0x000519B4 File Offset: 0x0004FBB4
		public override void Update(UpdateLoopType updateLoop)
		{
			double realTime = ReInput.realTime;
			if (this.wpzSLxsnINnAfPSbpdhioRPWdWXB && realTime >= this.ZnylSgxRuczDgCatRZaPArBOMQjH + 1.0)
			{
				try
				{
					this.Initialize();
				}
				catch
				{
					Logger.LogWarning("Error re-initializing Nintendo Switch Pro Controller. Will retry.");
					this.ZnylSgxRuczDgCatRZaPArBOMQjH = realTime;
				}
			}
			for (int i = 0; i < this.jKeHBRxAQhNLMxfYBgnDRipQrVkk.Length; i++)
			{
				this.jKeHBRxAQhNLMxfYBgnDRipQrVkk[i].ZuynJFEevXABDJRCUnzxEKrcrgdFc(realTime);
			}
			if (realTime >= this.QyZRsehfmlGGYRRumJkjBbhIDJWs + 0.01515151560306549)
			{
				this.QyZRsehfmlGGYRRumJkjBbhIDJWs = realTime;
				this.LHvTUHYkdWbDedRZiWeZbsiZPeNoA(this.HmpyquXoDaDhZOTwbAzUALAnVizw);
				this.wuVCMSEeppbKRFiTjurGyeuVCRtPc(xvcebytMmHXPBmUQiJYMACsdJpLo.Asynchronous);
			}
		}

		// Token: 0x06001721 RID: 5921 RVA: 0x00051A60 File Offset: 0x0004FC60
		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (!this.hALRzvKVkGvxjTSLZfFBXTvARgPN)
			{
				return false;
			}
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (this.JUCqtSpmJvvlpDeCppeqdwlNQpJr.Length < 49)
			{
				return false;
			}
			if (Marshal.ReadByte(inputReportPtr, 0) != 33)
			{
				return false;
			}
			if (this.wpzSLxsnINnAfPSbpdhioRPWdWXB)
			{
				this.ZnylSgxRuczDgCatRZaPArBOMQjH = ReInput.realTime;
			}
			int numBytesToWrite = Math.Min(inputReportLength, this.JUCqtSpmJvvlpDeCppeqdwlNQpJr.Length);
			this.JUCqtSpmJvvlpDeCppeqdwlNQpJr.Write(inputReportPtr, inputReportLength, numBytesToWrite, 0, 0);
			this.UpdateButtons(this.JUCqtSpmJvvlpDeCppeqdwlNQpJr, timestamp);
			zHTBvVyhFGDLpEJMFINchPNfqnfnb[] axes = this.axes;
			this.UpdateElements(axes, this.JUCqtSpmJvvlpDeCppeqdwlNQpJr, timestamp);
			return true;
		}

		// Token: 0x06001722 RID: 5922
		protected abstract void UpdateButtons(NativeBuffer inputReport, double timestamp);

		// Token: 0x06001723 RID: 5923
		protected abstract void UpdateElements(zHTBvVyhFGDLpEJMFINchPNfqnfnb[] elements, NativeBuffer inputReport, double timestamp);

		// Token: 0x06001724 RID: 5924 RVA: 0x00051AFC File Offset: 0x0004FCFC
		private bool ZtXgZRgonqXuImdfFoXIDrCMDxKCb(NintendoSwitchGamepadDriver.bdSyBruVRCMMzbzrsDudoFjvFwEi A_1, byte[] A_2)
		{
			bool result;
			try
			{
				if (A_1.tWaztNluTzhpNubedmPqNsCootzX.Length + 11 > this.eqHkcGtDjlCJcCmKoOUDXmXWcWlo.Length)
				{
					result = false;
				}
				else
				{
					this.LHvTUHYkdWbDedRZiWeZbsiZPeNoA(this.eqHkcGtDjlCJcCmKoOUDXmXWcWlo);
					this.eqHkcGtDjlCJcCmKoOUDXmXWcWlo[10] = A_1.gqjnGxAbQtpchPsnYSdxgPzlLerO;
					this.eqHkcGtDjlCJcCmKoOUDXmXWcWlo.TryWriteBytes(A_1.tWaztNluTzhpNubedmPqNsCootzX, A_1.jERICbcAhyjmYAvxXauNAgRHtbXbB, 11, 0);
					int num = 2;
					bool flag = false;
					int num2 = 0;
					while (this.XpjQfqALnnpFFHmDtAGLBtlKinCaA.ReadSync(this.voVZpdPpQMOXQXWPTupyTecVZvMe, this.voVZpdPpQMOXQXWPTupyTecVZvMe.Length, 1))
					{
					}
					for (int i = 0; i < num; i++)
					{
						Array.Clear(A_2, 0, A_2.Length);
						this.voVZpdPpQMOXQXWPTupyTecVZvMe.Clear();
						this.zhocApZgUTVBJxrFukcSDLScfuBT(this.eqHkcGtDjlCJcCmKoOUDXmXWcWlo, A_1.gqjnGxAbQtpchPsnYSdxgPzlLerO);
						double realTime = ReInput.realTime;
						if (i == 0)
						{
							double realTime2 = ReInput.realTime;
						}
						int num3 = 0;
						while (ReInput.realTime < realTime + 0.5)
						{
							if (this.XpjQfqALnnpFFHmDtAGLBtlKinCaA.ReadSync(this.voVZpdPpQMOXQXWPTupyTecVZvMe, this.voVZpdPpQMOXQXWPTupyTecVZvMe.Length, 200) && this.voVZpdPpQMOXQXWPTupyTecVZvMe[0] == 33)
							{
								if (this.voVZpdPpQMOXQXWPTupyTecVZvMe[14] == A_1.gqjnGxAbQtpchPsnYSdxgPzlLerO)
								{
									flag = true;
									double realTime3 = ReInput.realTime;
									break;
								}
								num3++;
								num2++;
							}
						}
						if (flag)
						{
							break;
						}
					}
					if (flag)
					{
						this.voVZpdPpQMOXQXWPTupyTecVZvMe.Read(A_2, this.voVZpdPpQMOXQXWPTupyTecVZvMe.Length, 0, 0);
					}
					result = flag;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001725 RID: 5925 RVA: 0x0001D1C9 File Offset: 0x0001B3C9
		private bool zhocApZgUTVBJxrFukcSDLScfuBT(NativeBuffer A_1, byte A_2)
		{
			return this.XpjQfqALnnpFFHmDtAGLBtlKinCaA.WriteSync(new AWHWYMjOaGiEqJCCtAEpfhRJAtYq(A_1, A_1.Length, A_1.Length), 1000);
		}

		// Token: 0x06001726 RID: 5926 RVA: 0x00051CA8 File Offset: 0x0004FEA8
		private void VgxEhPBlSVsGEjOZGFUpdDuKddZwb(byte A_1)
		{
			this.HmpyquXoDaDhZOTwbAzUALAnVizw.Clear();
			this.HmpyquXoDaDhZOTwbAzUALAnVizw[0] = 128;
			this.HmpyquXoDaDhZOTwbAzUALAnVizw[1] = 146;
			this.HmpyquXoDaDhZOTwbAzUALAnVizw[2] = 0;
			this.HmpyquXoDaDhZOTwbAzUALAnVizw[3] = 49;
			this.HmpyquXoDaDhZOTwbAzUALAnVizw[8] = A_1;
		}

		// Token: 0x06001727 RID: 5927 RVA: 0x0001D1F7 File Offset: 0x0001B3F7
		private void vulVgBDNEKnUFgDTAkvYWcfUjSUf(byte A_1, NativeBuffer A_2, int A_3, xvcebytMmHXPBmUQiJYMACsdJpLo A_4)
		{
			this.VgxEhPBlSVsGEjOZGFUpdDuKddZwb(A_1);
			if (A_3 > 0)
			{
				this.HmpyquXoDaDhZOTwbAzUALAnVizw.Write(A_2, A_3, 9, 0, 0);
			}
		}

		// Token: 0x06001728 RID: 5928 RVA: 0x0001D21A File Offset: 0x0001B41A
		private void LHvTUHYkdWbDedRZiWeZbsiZPeNoA(NativeBuffer A_1)
		{
			A_1.Clear();
			A_1[0] = 1;
			A_1[1] = this.udZeEubaVDjORdRhhRuYFyEVsRkJB();
			this.MhHVxLALIGOoKYAwPgTipADxwtSV(A_1, 2);
		}

		// Token: 0x06001729 RID: 5929 RVA: 0x00051D0C File Offset: 0x0004FF0C
		private void MhHVxLALIGOoKYAwPgTipADxwtSV(NativeBuffer A_1, int A_2)
		{
			if (this._controllerType == NintendoSwitchGamepadDriver.cLmDiWGVqVGnsnEnIZtSOAxhDrwpA.JoyConRight)
			{
				A_2 += 4;
			}
			for (int i = 0; i < this.jKeHBRxAQhNLMxfYBgnDRipQrVkk.Length; i++)
			{
				NintendoSwitchGamepadDriver.wwccnsvlhGruGddhvPrPaDHEcjCR(A_1, A_2, this.jKeHBRxAQhNLMxfYBgnDRipQrVkk[i].nizCEkBOSbZkiCdYfosixZeltoyd);
				A_2 += 4;
			}
		}

		// Token: 0x0600172A RID: 5930 RVA: 0x00051D54 File Offset: 0x0004FF54
		private static void wwccnsvlhGruGddhvPrPaDHEcjCR(NativeBuffer A_0, int A_1, NintendoSwitchGamepadDriver.WiZKgdEAWCpRvMpxYSZXyaGcPOtU A_2)
		{
			if (A_2.oCCDxSlVTiwlUoQfaaGRkgvEiKwH == 0f && A_2.TxDMmEQFfnAHsxMorWSySEpaOcSB == 0f)
			{
				A_0[A_1] = 0;
				A_0[1 + A_1] = 1;
				A_0[2 + A_1] = 64;
				A_0[3 + A_1] = 64;
				return;
			}
			ushort num = (ushort)((Math.Round(32.0 * Math.Log((double)(A_2.yRpCvViNEAuOzpmyKKxuRVhmkyOM * 0.1f), 2.0)) - 96.0) * 4.0);
			byte b = (byte)(Math.Round(32.0 * Math.Log((double)(A_2.NGjeSPCzHqgRhcCMvrtzJrIXgojgb * 0.1f), 2.0)) - 64.0);
			byte b2 = NintendoSwitchGamepadDriver.iCJgfVHJmqgooWJKugqBeVmbOjPq(A_2.TxDMmEQFfnAHsxMorWSySEpaOcSB);
			ushort num2 = (ushort)(Math.Round((double)NintendoSwitchGamepadDriver.iCJgfVHJmqgooWJKugqBeVmbOjPq(A_2.oCCDxSlVTiwlUoQfaaGRkgvEiKwH)) * 0.5);
			byte b3 = (byte)(num2 % 2);
			if (b3 > 0)
			{
				num2 -= 1;
			}
			num2 = (ushort)(num2 >> 1);
			num2 += 64;
			if (b3 > 0)
			{
				num2 |= 32768;
			}
			b2 -= b2 % 2;
			A_0[A_1] = (byte)(num & 255);
			A_0[1 + A_1] = (byte)((num >> 8 & 255) + (int)b2);
			A_0[2 + A_1] = (byte)((num2 >> 8 & 255) + (int)b);
			A_0[3 + A_1] = (byte)(num2 & 255);
		}

		// Token: 0x0600172B RID: 5931 RVA: 0x00051EB8 File Offset: 0x000500B8
		private static byte iCJgfVHJmqgooWJKugqBeVmbOjPq(float A_0)
		{
			byte result;
			if (A_0 < 0.01f)
			{
				result = 0;
			}
			else if ((double)A_0 < 0.117)
			{
				result = (byte)((Math.Log((double)(A_0 * 1000f), 2.0) * 32.0 - 96.0) / (5.0 - Math.Pow((double)A_0, 2.0)) - 1.0);
			}
			else if ((double)A_0 < 0.23)
			{
				result = (byte)(Math.Log((double)(A_0 * 1000f), 2.0) * 32.0 - 96.0 - 92.0);
			}
			else
			{
				result = (byte)((Math.Log((double)(A_0 * 1000f), 2.0) * 32.0 - 96.0) * 2.0 - 246.0);
			}
			return result;
		}

		// Token: 0x0600172C RID: 5932 RVA: 0x00051FC0 File Offset: 0x000501C0
		private void BbnGrtPqdGxaDxPmEmVojQzPlSJp(xvcebytMmHXPBmUQiJYMACsdJpLo A_1)
		{
			NativeBuffer rpsFLqADjCTYelLwBOftZXcXTnevA = this.RpsFLqADjCTYelLwBOftZXcXTnevA;
			rpsFLqADjCTYelLwBOftZXcXTnevA[0] = this.udZeEubaVDjORdRhhRuYFyEVsRkJB();
			this.MhHVxLALIGOoKYAwPgTipADxwtSV(rpsFLqADjCTYelLwBOftZXcXTnevA, 1);
			this.vulVgBDNEKnUFgDTAkvYWcfUjSUf(16, rpsFLqADjCTYelLwBOftZXcXTnevA, 9, A_1);
			this.wuVCMSEeppbKRFiTjurGyeuVCRtPc(A_1);
		}

		// Token: 0x0600172D RID: 5933 RVA: 0x00052000 File Offset: 0x00050200
		private bool ATRScfkdYJBVoFLFDTWqEsQQoWvE()
		{
			byte[] array = new byte[25];
			ArrayTools.Fill<byte>(array, byte.MaxValue);
			array[0] = 24;
			array[1] = 1;
			return this.ZtXgZRgonqXuImdfFoXIDrCMDxKCb(new NintendoSwitchGamepadDriver.bdSyBruVRCMMzbzrsDudoFjvFwEi(56, array, 25), this.yODTXFsKhrbGiWPMhRBakTIQDQVv);
		}

		// Token: 0x0600172E RID: 5934 RVA: 0x00052040 File Offset: 0x00050240
		private bool UtykWxlMjqdfbXAxTvBNCviPhJFG(bool A_1)
		{
			byte[] array = new byte[25];
			ArrayTools.Fill<byte>(array, byte.MaxValue);
			if (A_1)
			{
				array[0] = 31;
				array[1] = 240;
			}
			else
			{
				array[0] = 16;
				array[1] = 1;
			}
			return this.ZtXgZRgonqXuImdfFoXIDrCMDxKCb(new NintendoSwitchGamepadDriver.bdSyBruVRCMMzbzrsDudoFjvFwEi(56, array, 25), this.yODTXFsKhrbGiWPMhRBakTIQDQVv);
		}

		// Token: 0x0600172F RID: 5935 RVA: 0x00052094 File Offset: 0x00050294
		private bool yrNJOFSiXzoqQeEabdIaVYfuSyIc(byte A_1, byte A_2, byte A_3, byte[] A_4)
		{
			byte[] array = new byte[]
			{
				A_2,
				A_1,
				0,
				0,
				A_3
			};
			bool flag = false;
			for (int i = 0; i < 10; i++)
			{
				if (this.ZtXgZRgonqXuImdfFoXIDrCMDxKCb(new NintendoSwitchGamepadDriver.bdSyBruVRCMMzbzrsDudoFjvFwEi(16, array, array.Length), A_4) && A_4[15] == A_2 && A_4[16] == A_1)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
			Array.Copy(A_4, 20, A_4, 0, (int)A_3);
			ArrayTools.Fill<byte>(A_4, 0, (int)A_3, A_4.Length - (int)A_3);
			return true;
		}

		// Token: 0x06001730 RID: 5936 RVA: 0x0001D23F File Offset: 0x0001B43F
		private bool wuVCMSEeppbKRFiTjurGyeuVCRtPc(xvcebytMmHXPBmUQiJYMACsdJpLo A_1)
		{
			if (A_1 == xvcebytMmHXPBmUQiJYMACsdJpLo.Synchronous)
			{
				return this.XpjQfqALnnpFFHmDtAGLBtlKinCaA.WriteSync(this.pkddbNUhTMBuEwrmGvTpLIFGeFlW, 0);
			}
			if (A_1 == xvcebytMmHXPBmUQiJYMACsdJpLo.Asynchronous)
			{
				this.XpjQfqALnnpFFHmDtAGLBtlKinCaA.WriteAsync(this.pkddbNUhTMBuEwrmGvTpLIFGeFlW, 1000);
				return true;
			}
			throw new NotImplementedException();
		}

		// Token: 0x06001731 RID: 5937 RVA: 0x0001D278 File Offset: 0x0001B478
		private byte udZeEubaVDjORdRhhRuYFyEVsRkJB()
		{
			if (this.YZwGFFNIQAWFljJnsCbCaMRFEBJi == 15)
			{
				this.YZwGFFNIQAWFljJnsCbCaMRFEBJi = 0;
			}
			else
			{
				this.YZwGFFNIQAWFljJnsCbCaMRFEBJi += 1;
			}
			return this.YZwGFFNIQAWFljJnsCbCaMRFEBJi;
		}

		// Token: 0x06001732 RID: 5938 RVA: 0x00052110 File Offset: 0x00050310
		private bool ZGoMXyqtSLPZlOHQgWdQLqcXdGsjA()
		{
			bool flag = this._controllerType == NintendoSwitchGamepadDriver.cLmDiWGVqVGnsnEnIZtSOAxhDrwpA.JoyConLeft || this._controllerType == NintendoSwitchGamepadDriver.cLmDiWGVqVGnsnEnIZtSOAxhDrwpA.ProController;
			Array.Clear(this.mRYOXYPIUNhmzoPpnMMcLcQmbSfP, 0, this.mRYOXYPIUNhmzoPpnMMcLcQmbSfP.Length);
			bool flag2 = false;
			if (this.yrNJOFSiXzoqQeEabdIaVYfuSyIc(128, flag ? 18 : 29, 9, this.yODTXFsKhrbGiWPMhRBakTIQDQVv))
			{
				for (int i = 0; i < 9; i++)
				{
					if (this.yODTXFsKhrbGiWPMhRBakTIQDQVv[i] != 255)
					{
						flag2 = true;
					}
				}
			}
			if (!flag2 && this.yrNJOFSiXzoqQeEabdIaVYfuSyIc(96, flag ? 61 : 70, 9, this.yODTXFsKhrbGiWPMhRBakTIQDQVv))
			{
				flag2 = true;
			}
			bool result;
			if (flag2)
			{
				NintendoSwitchGamepadDriver.jDXrftiygZEnrPnsgnWXphhhEXw jDXrftiygZEnrPnsgnWXphhhEXw = new NintendoSwitchGamepadDriver.jDXrftiygZEnrPnsgnWXphhhEXw();
				NintendoSwitchGamepadDriver.jDXrftiygZEnrPnsgnWXphhhEXw jDXrftiygZEnrPnsgnWXphhhEXw2 = new NintendoSwitchGamepadDriver.jDXrftiygZEnrPnsgnWXphhhEXw();
				NintendoSwitchGamepadDriver.QNcGiaJaaTQaufjAhsyDgVzmzcTub(this.yODTXFsKhrbGiWPMhRBakTIQDQVv, jDXrftiygZEnrPnsgnWXphhhEXw, jDXrftiygZEnrPnsgnWXphhhEXw2, flag);
				this.mRYOXYPIUNhmzoPpnMMcLcQmbSfP[0] = jDXrftiygZEnrPnsgnWXphhhEXw;
				this.mRYOXYPIUNhmzoPpnMMcLcQmbSfP[1] = jDXrftiygZEnrPnsgnWXphhhEXw2;
				result = true;
				if (this.yrNJOFSiXzoqQeEabdIaVYfuSyIc(96, flag ? 134 : 152, 16, this.yODTXFsKhrbGiWPMhRBakTIQDQVv))
				{
					NintendoSwitchGamepadDriver.wynRGlvtdAVKyMYezBnkAwatVZWo(this.yODTXFsKhrbGiWPMhRBakTIQDQVv, jDXrftiygZEnrPnsgnWXphhhEXw, jDXrftiygZEnrPnsgnWXphhhEXw2);
				}
			}
			else
			{
				result = false;
			}
			if (this._controllerType == NintendoSwitchGamepadDriver.cLmDiWGVqVGnsnEnIZtSOAxhDrwpA.ProController)
			{
				bool flag3 = false;
				if (this.yrNJOFSiXzoqQeEabdIaVYfuSyIc(128, (!flag) ? 18 : 29, 9, this.yODTXFsKhrbGiWPMhRBakTIQDQVv))
				{
					for (int j = 0; j < 9; j++)
					{
						if (this.yODTXFsKhrbGiWPMhRBakTIQDQVv[j] != 255)
						{
							flag3 = true;
						}
					}
				}
				if (!flag3 && this.yrNJOFSiXzoqQeEabdIaVYfuSyIc(96, (!flag) ? 61 : 70, 9, this.yODTXFsKhrbGiWPMhRBakTIQDQVv))
				{
					flag3 = true;
				}
				if (flag3)
				{
					NintendoSwitchGamepadDriver.jDXrftiygZEnrPnsgnWXphhhEXw jDXrftiygZEnrPnsgnWXphhhEXw3 = new NintendoSwitchGamepadDriver.jDXrftiygZEnrPnsgnWXphhhEXw();
					NintendoSwitchGamepadDriver.jDXrftiygZEnrPnsgnWXphhhEXw jDXrftiygZEnrPnsgnWXphhhEXw4 = new NintendoSwitchGamepadDriver.jDXrftiygZEnrPnsgnWXphhhEXw();
					NintendoSwitchGamepadDriver.QNcGiaJaaTQaufjAhsyDgVzmzcTub(this.yODTXFsKhrbGiWPMhRBakTIQDQVv, jDXrftiygZEnrPnsgnWXphhhEXw3, jDXrftiygZEnrPnsgnWXphhhEXw4, !flag);
					this.mRYOXYPIUNhmzoPpnMMcLcQmbSfP[2] = jDXrftiygZEnrPnsgnWXphhhEXw3;
					this.mRYOXYPIUNhmzoPpnMMcLcQmbSfP[3] = jDXrftiygZEnrPnsgnWXphhhEXw4;
					result = true;
					if (this.yrNJOFSiXzoqQeEabdIaVYfuSyIc(96, (!flag) ? 134 : 152, 16, this.yODTXFsKhrbGiWPMhRBakTIQDQVv))
					{
						NintendoSwitchGamepadDriver.wynRGlvtdAVKyMYezBnkAwatVZWo(this.yODTXFsKhrbGiWPMhRBakTIQDQVv, jDXrftiygZEnrPnsgnWXphhhEXw3, jDXrftiygZEnrPnsgnWXphhhEXw4);
					}
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06001733 RID: 5939 RVA: 0x000522FC File Offset: 0x000504FC
		private static void QNcGiaJaaTQaufjAhsyDgVzmzcTub(byte[] A_0, NintendoSwitchGamepadDriver.jDXrftiygZEnrPnsgnWXphhhEXw A_1, NintendoSwitchGamepadDriver.jDXrftiygZEnrPnsgnWXphhhEXw A_2, bool A_3)
		{
			ushort num = (ushort)(((int)A_0[1] << 8 & 3840) | (int)A_0[0]);
			ushort num2 = (ushort)((int)A_0[2] << 4 | A_0[1] >> 4);
			ushort num3 = (ushort)(((int)A_0[4] << 8 & 3840) | (int)A_0[3]);
			ushort num4 = (ushort)((int)A_0[5] << 4 | A_0[4] >> 4);
			ushort num5 = (ushort)(((int)A_0[7] << 8 & 3840) | (int)A_0[6]);
			ushort num6 = (ushort)((int)A_0[8] << 4 | A_0[7] >> 4);
			if (A_3)
			{
				A_1.UnFwOBaCwwWMPdCwKuBhrVLZPPWj = num;
				A_2.UnFwOBaCwwWMPdCwKuBhrVLZPPWj = num2;
				A_1.pVHgpRbrIzXNejuiSZVOhtZsMUChb = num3;
				A_2.pVHgpRbrIzXNejuiSZVOhtZsMUChb = num4;
				A_1.QmCDtpYOjqTfSeugVEYmEqIyKltj = num5;
				A_2.QmCDtpYOjqTfSeugVEYmEqIyKltj = num6;
				return;
			}
			A_1.pVHgpRbrIzXNejuiSZVOhtZsMUChb = num;
			A_2.pVHgpRbrIzXNejuiSZVOhtZsMUChb = num2;
			A_1.QmCDtpYOjqTfSeugVEYmEqIyKltj = num3;
			A_2.QmCDtpYOjqTfSeugVEYmEqIyKltj = num4;
			A_1.UnFwOBaCwwWMPdCwKuBhrVLZPPWj = num5;
			A_2.UnFwOBaCwwWMPdCwKuBhrVLZPPWj = num6;
		}

		// Token: 0x06001734 RID: 5940 RVA: 0x0001D2A2 File Offset: 0x0001B4A2
		private static void wynRGlvtdAVKyMYezBnkAwatVZWo(byte[] A_0, NintendoSwitchGamepadDriver.jDXrftiygZEnrPnsgnWXphhhEXw A_1, NintendoSwitchGamepadDriver.jDXrftiygZEnrPnsgnWXphhhEXw A_2)
		{
			A_1.IRPZiEeGuvrNRyGfNkZSvLUAUKmH = (ushort)(((int)A_0[4] << 8 & 3840) | (int)A_0[3]);
			A_2.IRPZiEeGuvrNRyGfNkZSvLUAUKmH = A_1.IRPZiEeGuvrNRyGfNkZSvLUAUKmH;
		}

		// Token: 0x06001735 RID: 5941 RVA: 0x000523C4 File Offset: 0x000505C4
		protected bool GetCalibratedStickValue(ushort valueX, ushort valueY, NintendoSwitchGamepadDriver.jDXrftiygZEnrPnsgnWXphhhEXw calX, NintendoSwitchGamepadDriver.jDXrftiygZEnrPnsgnWXphhhEXw calY, out ushort calibratedX, out ushort calibratedY)
		{
			calibratedX = 32767;
			calibratedY = 32767;
			if (calX == null || calY == null)
			{
				return false;
			}
			ushort irpziEeGuvrNRyGfNkZSvLUAUKmH = calX.IRPZiEeGuvrNRyGfNkZSvLUAUKmH;
			float num = (float)(valueX - calX.pVHgpRbrIzXNejuiSZVOhtZsMUChb);
			float num2 = (float)(valueY - calY.pVHgpRbrIzXNejuiSZVOhtZsMUChb);
			if (Math.Abs(num * num + num2 * num2) < (float)(irpziEeGuvrNRyGfNkZSvLUAUKmH * irpziEeGuvrNRyGfNkZSvLUAUKmH))
			{
				return false;
			}
			calibratedX = (ushort)MathTools.ValueInNewRange(MathTools.Clamp(num / (float)((num > 0f) ? calX.UnFwOBaCwwWMPdCwKuBhrVLZPPWj : calX.QmCDtpYOjqTfSeugVEYmEqIyKltj), -0.95f, 0.95f), -0.95f, 0.95f, 0f, 65535f);
			calibratedY = (ushort)MathTools.ValueInNewRange(MathTools.Clamp(num2 / (float)((num2 > 0f) ? calY.UnFwOBaCwwWMPdCwKuBhrVLZPPWj : calY.QmCDtpYOjqTfSeugVEYmEqIyKltj), -0.95f, 0.95f), -0.95f, 0.95f, 0f, 65535f);
			return true;
		}

		// Token: 0x06001736 RID: 5942 RVA: 0x0001D2C6 File Offset: 0x0001B4C6
		protected NintendoSwitchGamepadDriver.jDXrftiygZEnrPnsgnWXphhhEXw GetAxisCalibration(int index)
		{
			return this.mRYOXYPIUNhmzoPpnMMcLcQmbSfP[index];
		}

		// Token: 0x06001737 RID: 5943 RVA: 0x0001D2D0 File Offset: 0x0001B4D0
		private void qNUHRJiYOBGPsfSlCWvPMlPaSWNr(bool A_1)
		{
			if (this.wpzSLxsnINnAfPSbpdhioRPWdWXB && !A_1)
			{
				this.ZnylSgxRuczDgCatRZaPArBOMQjH = ReInput.realTime;
			}
		}

		// Token: 0x06001738 RID: 5944 RVA: 0x0004F27C File Offset: 0x0004D47C
		~NintendoSwitchGamepadDriver()
		{
			this.Dispose(false);
		}

		// Token: 0x06001739 RID: 5945 RVA: 0x000524A8 File Offset: 0x000506A8
		protected override void Dispose(bool disposing)
		{
			if (base.disposed)
			{
				return;
			}
			if (disposing)
			{
				ReInput.ApplicationPauseChangedEvent -= this.qNUHRJiYOBGPsfSlCWvPMlPaSWNr;
				if (!this.UlNMtcKzXZHsCFUWZDbPcFmHeIYg && this.HmpyquXoDaDhZOTwbAzUALAnVizw != null)
				{
					this.HmpyquXoDaDhZOTwbAzUALAnVizw.Clear();
					this.HmpyquXoDaDhZOTwbAzUALAnVizw[0] = 128;
					this.HmpyquXoDaDhZOTwbAzUALAnVizw[1] = 5;
					try
					{
						this.XpjQfqALnnpFFHmDtAGLBtlKinCaA.WriteSync(this.pkddbNUhTMBuEwrmGvTpLIFGeFlW, 0);
					}
					catch
					{
					}
					this.HmpyquXoDaDhZOTwbAzUALAnVizw.Clear();
					this.HmpyquXoDaDhZOTwbAzUALAnVizw[0] = 128;
					this.HmpyquXoDaDhZOTwbAzUALAnVizw[1] = 6;
					try
					{
						this.XpjQfqALnnpFFHmDtAGLBtlKinCaA.WriteSync(this.pkddbNUhTMBuEwrmGvTpLIFGeFlW, 0);
					}
					catch
					{
					}
				}
				if (this.JUCqtSpmJvvlpDeCppeqdwlNQpJr != null)
				{
					this.JUCqtSpmJvvlpDeCppeqdwlNQpJr.Dispose();
				}
				if (this.HmpyquXoDaDhZOTwbAzUALAnVizw != null)
				{
					this.HmpyquXoDaDhZOTwbAzUALAnVizw.Dispose();
				}
				if (this.eqHkcGtDjlCJcCmKoOUDXmXWcWlo != null)
				{
					this.eqHkcGtDjlCJcCmKoOUDXmXWcWlo.Dispose();
				}
				if (this.voVZpdPpQMOXQXWPTupyTecVZvMe != null)
				{
					this.voVZpdPpQMOXQXWPTupyTecVZvMe.Dispose();
				}
				if (this.RpsFLqADjCTYelLwBOftZXcXTnevA == null)
				{
					this.RpsFLqADjCTYelLwBOftZXcXTnevA.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600173A RID: 5946 RVA: 0x0001D2E8 File Offset: 0x0001B4E8
		private static void rpnuiDauybVGRpxkEyxnRujrHdUD(NativeBuffer A_0, int A_1)
		{
			A_0.TryWriteBytes(NintendoSwitchGamepadDriver.izSlfftFsrnZcvXtnXQIGuFIQwHe, NintendoSwitchGamepadDriver.izSlfftFsrnZcvXtnXQIGuFIQwHe.Length, A_1, 0);
		}

		// Token: 0x0600173B RID: 5947 RVA: 0x0001D2FF File Offset: 0x0001B4FF
		private static void MTORcOhWlbRBSHpvDyrZMHYeeLWd(byte[] A_0, int A_1)
		{
			Array.Copy(NintendoSwitchGamepadDriver.izSlfftFsrnZcvXtnXQIGuFIQwHe, 0, A_0, A_1, NintendoSwitchGamepadDriver.izSlfftFsrnZcvXtnXQIGuFIQwHe.Length);
		}

		// Token: 0x0600173C RID: 5948 RVA: 0x0001D315 File Offset: 0x0001B515
		[Conditional("DEBUG_THIS")]
		protected static void DLog(object msg)
		{
			if (msg == null)
			{
				return;
			}
			Logger.Log("SwitchGamepadDriverBase: " + ((msg != null) ? msg.ToString() : null));
		}

		// Token: 0x04003279 RID: 12921
		protected const byte INPUT_REPORT_ID = 33;

		// Token: 0x0400327A RID: 12922
		protected const byte OUTPUT_REPORT_COMMAND_GET_INPUT = 31;

		// Token: 0x0400327B RID: 12923
		protected const byte OUTPUT_RUMBLE_AND_SUBCMD = 1;

		// Token: 0x0400327C RID: 12924
		protected const byte OUTPUT_FW_UPDATE_PKT = 3;

		// Token: 0x0400327D RID: 12925
		protected const byte OUTPUT_RUMBLE_ONLY = 16;

		// Token: 0x0400327E RID: 12926
		protected const byte OUTPUT_MCU_DATA = 17;

		// Token: 0x0400327F RID: 12927
		protected const byte OUTPUT_USB_CMD = 128;

		// Token: 0x04003280 RID: 12928
		protected const byte SUBCMD_STATE = 0;

		// Token: 0x04003281 RID: 12929
		protected const byte SUBCMD_MANUAL_BT_PAIRING = 1;

		// Token: 0x04003282 RID: 12930
		protected const byte SUBCMD_REQ_DEV_INFO = 2;

		// Token: 0x04003283 RID: 12931
		protected const byte SUBCMD_SET_REPORT_MODE = 3;

		// Token: 0x04003284 RID: 12932
		protected const byte SUBCMD_TRIGGERS_ELAPSED = 4;

		// Token: 0x04003285 RID: 12933
		protected const byte SUBCMD_GET_PAGE_LIST_STATE = 5;

		// Token: 0x04003286 RID: 12934
		protected const byte SUBCMD_SET_HCI_STATE = 6;

		// Token: 0x04003287 RID: 12935
		protected const byte SUBCMD_RESET_PAIRING_INFO = 7;

		// Token: 0x04003288 RID: 12936
		protected const byte SUBCMD_LOW_POWER_MODE = 8;

		// Token: 0x04003289 RID: 12937
		protected const byte SUBCMD_SPI_FLASH_READ = 16;

		// Token: 0x0400328A RID: 12938
		protected const byte SUBCMD_SPI_FLASH_WRITE = 17;

		// Token: 0x0400328B RID: 12939
		protected const byte SUBCMD_RESET_MCU = 32;

		// Token: 0x0400328C RID: 12940
		protected const byte SUBCMD_SET_MCU_CONFIG = 33;

		// Token: 0x0400328D RID: 12941
		protected const byte SUBCMD_SET_MCU_STATE = 34;

		// Token: 0x0400328E RID: 12942
		protected const byte SUBCMD_SET_PLAYER_LIGHTS = 48;

		// Token: 0x0400328F RID: 12943
		protected const byte SUBCMD_GET_PLAYER_LIGHTS = 49;

		// Token: 0x04003290 RID: 12944
		protected const byte SUBCMD_SET_HOME_LIGHT = 56;

		// Token: 0x04003291 RID: 12945
		protected const byte SUBCMD_ENABLE_IMU = 64;

		// Token: 0x04003292 RID: 12946
		protected const byte SUBCMD_SET_IMU_SENSITIVITY = 65;

		// Token: 0x04003293 RID: 12947
		protected const byte SUBCMD_WRITE_IMU_REG = 66;

		// Token: 0x04003294 RID: 12948
		protected const byte SUBCMD_READ_IMU_REG = 67;

		// Token: 0x04003295 RID: 12949
		protected const byte SUBCMD_ENABLE_VIBRATION = 72;

		// Token: 0x04003296 RID: 12950
		protected const byte SUBCMD_GET_REGULATED_VOLTAGE = 80;

		// Token: 0x04003297 RID: 12951
		protected const byte INPUT_BUTTON_EVENT = 63;

		// Token: 0x04003298 RID: 12952
		protected const byte INPUT_SUBCMD_REPLY = 33;

		// Token: 0x04003299 RID: 12953
		protected const byte INPUT_IMU_DATA = 48;

		// Token: 0x0400329A RID: 12954
		protected const byte INPUT_MCU_DATA = 49;

		// Token: 0x0400329B RID: 12955
		protected const byte INPUT_USB_RESPONSE = 129;

		// Token: 0x0400329C RID: 12956
		protected const byte FEATURE_LAST_SUBCMD = 2;

		// Token: 0x0400329D RID: 12957
		protected const byte FEATURE_OTA_FW_UPGRADE = 112;

		// Token: 0x0400329E RID: 12958
		protected const byte FEATURE_SETUP_MEM_READ = 113;

		// Token: 0x0400329F RID: 12959
		protected const byte FEATURE_MEM_READ = 114;

		// Token: 0x040032A0 RID: 12960
		protected const byte FEATURE_ERASE_MEM_SECTOR = 115;

		// Token: 0x040032A1 RID: 12961
		protected const byte FEATURE_MEM_WRITE = 116;

		// Token: 0x040032A2 RID: 12962
		protected const byte FEATURE_LAUNCH = 117;

		// Token: 0x040032A3 RID: 12963
		protected const byte USB_CMD_CONN_STATUS = 1;

		// Token: 0x040032A4 RID: 12964
		protected const byte USB_CMD_HANDSHAKE = 2;

		// Token: 0x040032A5 RID: 12965
		protected const byte USB_CMD_BAUDRATE_3M = 3;

		// Token: 0x040032A6 RID: 12966
		protected const byte USB_CMD_NO_TIMEOUT = 4;

		// Token: 0x040032A7 RID: 12967
		protected const byte USB_CMD_EN_TIMEOUT = 5;

		// Token: 0x040032A8 RID: 12968
		protected const byte USB_RESET = 6;

		// Token: 0x040032A9 RID: 12969
		protected const byte USB_PRE_HANDSHAKE = 145;

		// Token: 0x040032AA RID: 12970
		protected const byte USB_SEND_UART = 146;

		// Token: 0x040032AB RID: 12971
		protected const ushort CAL_DATA_START = 24637;

		// Token: 0x040032AC RID: 12972
		protected const ushort CAL_DATA_END = 24654;

		// Token: 0x040032AD RID: 12973
		protected const ushort CAL_DATA_SIZE = 18;

		// Token: 0x040032AE RID: 12974
		protected const int MIN_INPUT_REPORT_SIZE = 49;

		// Token: 0x040032AF RID: 12975
		protected const int SUBCOMMAND_INPUT_REPORT_SIZE = 49;

		// Token: 0x040032B0 RID: 12976
		protected const float VIBRATION_FREQUENCY_LOW_MIN = 40.875885f;

		// Token: 0x040032B1 RID: 12977
		protected const float VIBRATION_FREQUENCY_LOW_MAX = 626.28613f;

		// Token: 0x040032B2 RID: 12978
		protected const float VIBRATION_FREQUENCY_HIGH_MIN = 81.75177f;

		// Token: 0x040032B3 RID: 12979
		protected const float VIBRATION_FREQUENCY_HIGH_MAX = 1252.5723f;

		// Token: 0x040032B4 RID: 12980
		protected const float NOINPUTREPORT_REINIT_HACK_TIMEOUT_SEC = 1f;

		// Token: 0x040032B5 RID: 12981
		protected const int DEVICE_POLL_RATE_HZ = 66;

		// Token: 0x040032B6 RID: 12982
		protected const int HID_AXIS_MIN_VALUE = 0;

		// Token: 0x040032B7 RID: 12983
		protected const int HID_AXIS_MAX_VALUE = 65535;

		// Token: 0x040032B8 RID: 12984
		protected const int HID_AXIS_ZERO_VALUE = 32767;

		// Token: 0x040032B9 RID: 12985
		protected const int HID_AXIS_BITS = 16;

		// Token: 0x040032BA RID: 12986
		protected const int HID_AXIS_BYTES = 2;

		// Token: 0x040032BB RID: 12987
		protected readonly NintendoSwitchGamepadDriver.cLmDiWGVqVGnsnEnIZtSOAxhDrwpA _controllerType;

		// Token: 0x040032BC RID: 12988
		protected readonly int _buttonCount;

		// Token: 0x040032BD RID: 12989
		protected readonly int _axisCount;

		// Token: 0x040032BE RID: 12990
		protected readonly int _vibrationMotorCount;

		// Token: 0x040032BF RID: 12991
		private readonly HIDDeviceDriver.IHIDDevice XpjQfqALnnpFFHmDtAGLBtlKinCaA;

		// Token: 0x040032C0 RID: 12992
		private readonly HIDDeviceDriver.HIDProperties VVcWKkPdBdFEanbNFwoYoAPpMUPt;

		// Token: 0x040032C1 RID: 12993
		private readonly bool UlNMtcKzXZHsCFUWZDbPcFmHeIYg;

		// Token: 0x040032C2 RID: 12994
		private readonly NativeBuffer JUCqtSpmJvvlpDeCppeqdwlNQpJr;

		// Token: 0x040032C3 RID: 12995
		private readonly NativeBuffer HmpyquXoDaDhZOTwbAzUALAnVizw;

		// Token: 0x040032C4 RID: 12996
		private readonly NativeBuffer RpsFLqADjCTYelLwBOftZXcXTnevA;

		// Token: 0x040032C5 RID: 12997
		private readonly byte[] yODTXFsKhrbGiWPMhRBakTIQDQVv;

		// Token: 0x040032C6 RID: 12998
		private readonly NativeBuffer eqHkcGtDjlCJcCmKoOUDXmXWcWlo;

		// Token: 0x040032C7 RID: 12999
		private readonly NativeBuffer voVZpdPpQMOXQXWPTupyTecVZvMe;

		// Token: 0x040032C8 RID: 13000
		private AWHWYMjOaGiEqJCCtAEpfhRJAtYq pkddbNUhTMBuEwrmGvTpLIFGeFlW;

		// Token: 0x040032C9 RID: 13001
		private double QyZRsehfmlGGYRRumJkjBbhIDJWs;

		// Token: 0x040032CA RID: 13002
		private byte YZwGFFNIQAWFljJnsCbCaMRFEBJi;

		// Token: 0x040032CB RID: 13003
		private double ZnylSgxRuczDgCatRZaPArBOMQjH;

		// Token: 0x040032CC RID: 13004
		private bool wpzSLxsnINnAfPSbpdhioRPWdWXB;

		// Token: 0x040032CD RID: 13005
		private bool hALRzvKVkGvxjTSLZfFBXTvARgPN;

		// Token: 0x040032CE RID: 13006
		private NintendoSwitchGamepadDriver.WexUQLBRjQmNWIwwWyDqJKNQTONG[] jKeHBRxAQhNLMxfYBgnDRipQrVkk;

		// Token: 0x040032CF RID: 13007
		private NintendoSwitchGamepadDriver.jDXrftiygZEnrPnsgnWXphhhEXw[] mRYOXYPIUNhmzoPpnMMcLcQmbSfP;

		// Token: 0x040032D0 RID: 13008
		private static readonly byte[] izSlfftFsrnZcvXtnXQIGuFIQwHe = new byte[]
		{
			0,
			1,
			64,
			64,
			0,
			1,
			64,
			64
		};

		// Token: 0x02000317 RID: 791
		protected enum cLmDiWGVqVGnsnEnIZtSOAxhDrwpA
		{
			// Token: 0x040032D2 RID: 13010
			ProController,
			// Token: 0x040032D3 RID: 13011
			JoyConLeft,
			// Token: 0x040032D4 RID: 13012
			JoyConRight
		}

		// Token: 0x02000318 RID: 792
		protected class WexUQLBRjQmNWIwwWyDqJKNQTONG
		{
			// Token: 0x170003C1 RID: 961
			// (get) Token: 0x0600173E RID: 5950 RVA: 0x0001D34E File Offset: 0x0001B54E
			public NintendoSwitchGamepadDriver.WiZKgdEAWCpRvMpxYSZXyaGcPOtU nizCEkBOSbZkiCdYfosixZeltoyd
			{
				get
				{
					return this.YGceTyZogDoJZoNOXJGkGCaknCqg;
				}
			}

			// Token: 0x0600173F RID: 5951 RVA: 0x0001D356 File Offset: 0x0001B556
			public WexUQLBRjQmNWIwwWyDqJKNQTONG(UnptiYUxBEDyXRujUEnkdeIKIoPk A_1)
			{
				this.duXKFyibXwbIjQQBvunySMaSaIee = A_1;
				this.EhqbDPPruzigSjEkOUaZRBLeyLRN();
			}

			// Token: 0x06001740 RID: 5952 RVA: 0x000525F0 File Offset: 0x000507F0
			public void NluaVtIjcIChcKRKGaQYzNEghhed(float A_1, float A_2, float A_3, float A_4, float A_5)
			{
				if (A_5 < 0f)
				{
					A_5 = 0f;
				}
				this.SiFJFQRgktdgzxkhknKZFoqDhETJA = A_5;
				this.YGceTyZogDoJZoNOXJGkGCaknCqg.oCCDxSlVTiwlUoQfaaGRkgvEiKwH = MathTools.Clamp01(A_1);
				this.YGceTyZogDoJZoNOXJGkGCaknCqg.NGjeSPCzHqgRhcCMvrtzJrIXgojgb = MathTools.Clamp(A_2, 40.875885f, 626.28613f);
				this.YGceTyZogDoJZoNOXJGkGCaknCqg.TxDMmEQFfnAHsxMorWSySEpaOcSB = MathTools.Clamp01(A_3);
				this.YGceTyZogDoJZoNOXJGkGCaknCqg.yRpCvViNEAuOzpmyKKxuRVhmkyOM = MathTools.Clamp(A_4, 81.75177f, 1252.5723f);
				this.duXKFyibXwbIjQQBvunySMaSaIee.kEsBudgJSBjLmBXIUoFwHyyKoNffb = Math.Max(this.YGceTyZogDoJZoNOXJGkGCaknCqg.oCCDxSlVTiwlUoQfaaGRkgvEiKwH, this.YGceTyZogDoJZoNOXJGkGCaknCqg.TxDMmEQFfnAHsxMorWSySEpaOcSB);
				this.OxKbFAhNSfwCdDQjcHRcWYHxPuNU = ReInput.realTime;
			}

			// Token: 0x06001741 RID: 5953 RVA: 0x000526A0 File Offset: 0x000508A0
			public void ZuynJFEevXABDJRCUnzxEKrcrgdFc(double A_1)
			{
				if ((this.YGceTyZogDoJZoNOXJGkGCaknCqg.oCCDxSlVTiwlUoQfaaGRkgvEiKwH > 0f || this.YGceTyZogDoJZoNOXJGkGCaknCqg.TxDMmEQFfnAHsxMorWSySEpaOcSB > 0f) && this.SiFJFQRgktdgzxkhknKZFoqDhETJA > 0f && A_1 >= this.OxKbFAhNSfwCdDQjcHRcWYHxPuNU + (double)this.SiFJFQRgktdgzxkhknKZFoqDhETJA)
				{
					this.YZqmLihxHysgnNOjPwTSWiasbBeL();
				}
			}

			// Token: 0x06001742 RID: 5954 RVA: 0x000526FC File Offset: 0x000508FC
			public void YZqmLihxHysgnNOjPwTSWiasbBeL()
			{
				this.YGceTyZogDoJZoNOXJGkGCaknCqg.TxDMmEQFfnAHsxMorWSySEpaOcSB = 0f;
				this.YGceTyZogDoJZoNOXJGkGCaknCqg.oCCDxSlVTiwlUoQfaaGRkgvEiKwH = 0f;
				this.duXKFyibXwbIjQQBvunySMaSaIee.jytYrChQDenkTUaEnqBMeGDoorVS = 0;
				this.SiFJFQRgktdgzxkhknKZFoqDhETJA = 0f;
				this.OxKbFAhNSfwCdDQjcHRcWYHxPuNU = ReInput.realTime;
			}

			// Token: 0x06001743 RID: 5955 RVA: 0x0001D36B File Offset: 0x0001B56B
			public void EhqbDPPruzigSjEkOUaZRBLeyLRN()
			{
				this.YGceTyZogDoJZoNOXJGkGCaknCqg = NintendoSwitchGamepadDriver.WiZKgdEAWCpRvMpxYSZXyaGcPOtU.QRpInRiOHaCIoPQcxfJqdrOOsTwJ();
				this.duXKFyibXwbIjQQBvunySMaSaIee.jytYrChQDenkTUaEnqBMeGDoorVS = 0;
				this.SiFJFQRgktdgzxkhknKZFoqDhETJA = 0f;
				this.OxKbFAhNSfwCdDQjcHRcWYHxPuNU = 0.0;
			}

			// Token: 0x040032D5 RID: 13013
			private UnptiYUxBEDyXRujUEnkdeIKIoPk duXKFyibXwbIjQQBvunySMaSaIee;

			// Token: 0x040032D6 RID: 13014
			private NintendoSwitchGamepadDriver.WiZKgdEAWCpRvMpxYSZXyaGcPOtU YGceTyZogDoJZoNOXJGkGCaknCqg;

			// Token: 0x040032D7 RID: 13015
			private float SiFJFQRgktdgzxkhknKZFoqDhETJA;

			// Token: 0x040032D8 RID: 13016
			private double OxKbFAhNSfwCdDQjcHRcWYHxPuNU;
		}

		// Token: 0x02000319 RID: 793
		protected struct WiZKgdEAWCpRvMpxYSZXyaGcPOtU
		{
			// Token: 0x06001744 RID: 5956 RVA: 0x0005274C File Offset: 0x0005094C
			internal WiZKgdEAWCpRvMpxYSZXyaGcPOtU(float A_1, float A_2, float A_3, float A_4)
			{
				if (A_1 < 0f)
				{
					A_1 = 0f;
				}
				if (A_1 > 1f)
				{
					A_1 = 1f;
				}
				if (A_2 < 0f)
				{
					A_2 = 0f;
				}
				if (A_3 < 0f)
				{
					A_3 = 0f;
				}
				if (A_3 > 1f)
				{
					A_3 = 1f;
				}
				if (A_4 < 0f)
				{
					A_4 = 0f;
				}
				this.oCCDxSlVTiwlUoQfaaGRkgvEiKwH = A_1;
				this.NGjeSPCzHqgRhcCMvrtzJrIXgojgb = A_2;
				this.TxDMmEQFfnAHsxMorWSySEpaOcSB = A_3;
				this.yRpCvViNEAuOzpmyKKxuRVhmkyOM = A_4;
			}

			// Token: 0x06001745 RID: 5957 RVA: 0x0001D39E File Offset: 0x0001B59E
			public static NintendoSwitchGamepadDriver.WiZKgdEAWCpRvMpxYSZXyaGcPOtU QRpInRiOHaCIoPQcxfJqdrOOsTwJ()
			{
				return new NintendoSwitchGamepadDriver.WiZKgdEAWCpRvMpxYSZXyaGcPOtU(0f, 160f, 0f, 320f);
			}

			// Token: 0x06001746 RID: 5958 RVA: 0x000527D4 File Offset: 0x000509D4
			public string RghTNdjbrRDVsMxCswIRAiWXTDPN()
			{
				return string.Concat(new string[]
				{
					"amplitudeLow: ",
					this.oCCDxSlVTiwlUoQfaaGRkgvEiKwH.ToString(),
					", frequencyLow: ",
					this.NGjeSPCzHqgRhcCMvrtzJrIXgojgb.ToString(),
					", amplitudeHigh: ",
					this.TxDMmEQFfnAHsxMorWSySEpaOcSB.ToString(),
					", frequencyHigh: ",
					this.yRpCvViNEAuOzpmyKKxuRVhmkyOM.ToString()
				});
			}

			// Token: 0x040032D9 RID: 13017
			public const int qQeopypCIsITSJENdrwXRsQdicltA = 160;

			// Token: 0x040032DA RID: 13018
			public const int VudWldvwKNKlXhNpQzGImeSHSAmi = 320;

			// Token: 0x040032DB RID: 13019
			public float oCCDxSlVTiwlUoQfaaGRkgvEiKwH;

			// Token: 0x040032DC RID: 13020
			public float NGjeSPCzHqgRhcCMvrtzJrIXgojgb;

			// Token: 0x040032DD RID: 13021
			public float TxDMmEQFfnAHsxMorWSySEpaOcSB;

			// Token: 0x040032DE RID: 13022
			public float yRpCvViNEAuOzpmyKKxuRVhmkyOM;
		}

		// Token: 0x0200031A RID: 794
		private struct bdSyBruVRCMMzbzrsDudoFjvFwEi
		{
			// Token: 0x06001747 RID: 5959 RVA: 0x0001D3B9 File Offset: 0x0001B5B9
			public bdSyBruVRCMMzbzrsDudoFjvFwEi(byte A_1, byte[] A_2, int A_3)
			{
				this.gqjnGxAbQtpchPsnYSdxgPzlLerO = A_1;
				this.tWaztNluTzhpNubedmPqNsCootzX = A_2;
				this.jERICbcAhyjmYAvxXauNAgRHtbXbB = A_3;
			}

			// Token: 0x040032DF RID: 13023
			public byte gqjnGxAbQtpchPsnYSdxgPzlLerO;

			// Token: 0x040032E0 RID: 13024
			public byte[] tWaztNluTzhpNubedmPqNsCootzX;

			// Token: 0x040032E1 RID: 13025
			public int jERICbcAhyjmYAvxXauNAgRHtbXbB;
		}

		// Token: 0x0200031B RID: 795
		protected class jDXrftiygZEnrPnsgnWXphhhEXw
		{
			// Token: 0x06001748 RID: 5960 RVA: 0x00052844 File Offset: 0x00050A44
			public virtual string FlHuAyeyBABRVSdLOfOzJMOrXSqlA()
			{
				return string.Concat(new string[]
				{
					"min: ",
					this.QmCDtpYOjqTfSeugVEYmEqIyKltj.ToString(),
					", max: ",
					this.UnFwOBaCwwWMPdCwKuBhrVLZPPWj.ToString(),
					", zero: ",
					this.pVHgpRbrIzXNejuiSZVOhtZsMUChb.ToString(),
					", deadzone: ",
					this.IRPZiEeGuvrNRyGfNkZSvLUAUKmH.ToString()
				});
			}

			// Token: 0x040032E2 RID: 13026
			public ushort QmCDtpYOjqTfSeugVEYmEqIyKltj;

			// Token: 0x040032E3 RID: 13027
			public ushort UnFwOBaCwwWMPdCwKuBhrVLZPPWj;

			// Token: 0x040032E4 RID: 13028
			public ushort pVHgpRbrIzXNejuiSZVOhtZsMUChb;

			// Token: 0x040032E5 RID: 13029
			public ushort IRPZiEeGuvrNRyGfNkZSvLUAUKmH;
		}
	}
}
