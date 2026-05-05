using System;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	// Token: 0x02000320 RID: 800
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class RailDriverDriver : HIDDeviceDriver, IDisposable, IDriver_RailDriver, IControllerDriver, IHIDControllerExtension
	{
		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x0600176C RID: 5996 RVA: 0x0001D4E1 File Offset: 0x0001B6E1
		// (set) Token: 0x0600176D RID: 5997 RVA: 0x0001D4E9 File Offset: 0x0001B6E9
		public bool SpeakerEnabled
		{
			get
			{
				return this.CtdglJkxudgHUVcdmCKfHutNmjqA;
			}
			set
			{
				this.CtdglJkxudgHUVcdmCKfHutNmjqA = value;
				this.OFbqwCYhPnVaQaSdPnnsoYKShMbM(RailDriverDriver.DGtGKHWtHgbXViTKfNqHAckdZReQ.Speaker, xvcebytMmHXPBmUQiJYMACsdJpLo.Synchronous);
			}
		}

		// Token: 0x0600176E RID: 5998 RVA: 0x0001D4FB File Offset: 0x0001B6FB
		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (digitIndex < 0 || digitIndex >= 3)
			{
				return;
			}
			this.WjjrmhvHqLGStAtOssiwtbvdIWaI[digitIndex] = digitBitValues;
			this.OFbqwCYhPnVaQaSdPnnsoYKShMbM(RailDriverDriver.DGtGKHWtHgbXViTKfNqHAckdZReQ.LED, xvcebytMmHXPBmUQiJYMACsdJpLo.Synchronous);
		}

		// Token: 0x0600176F RID: 5999 RVA: 0x0001D518 File Offset: 0x0001B718
		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			this.WjjrmhvHqLGStAtOssiwtbvdIWaI[0] = digit1BitValues;
			this.WjjrmhvHqLGStAtOssiwtbvdIWaI[1] = digit2BitValues;
			this.WjjrmhvHqLGStAtOssiwtbvdIWaI[2] = digit3BitValues;
			this.OFbqwCYhPnVaQaSdPnnsoYKShMbM(RailDriverDriver.DGtGKHWtHgbXViTKfNqHAckdZReQ.LED, xvcebytMmHXPBmUQiJYMACsdJpLo.Synchronous);
		}

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x06001770 RID: 6000 RVA: 0x0001D53E File Offset: 0x0001B73E
		ushort IHIDControllerExtension.vendorId
		{
			get
			{
				return this.vFmTkApcRiDctyfUETrGTVgvdxxi.vendorId;
			}
		}

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x06001771 RID: 6001 RVA: 0x0001D54B File Offset: 0x0001B74B
		ushort IHIDControllerExtension.productId
		{
			get
			{
				return this.vFmTkApcRiDctyfUETrGTVgvdxxi.productId;
			}
		}

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x06001772 RID: 6002 RVA: 0x0001D558 File Offset: 0x0001B758
		string IHIDControllerExtension.productName
		{
			get
			{
				return this.vFmTkApcRiDctyfUETrGTVgvdxxi.productName;
			}
		}

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x06001773 RID: 6003 RVA: 0x0001D565 File Offset: 0x0001B765
		string IHIDControllerExtension.manufacturer
		{
			get
			{
				return this.vFmTkApcRiDctyfUETrGTVgvdxxi.manufacturer;
			}
		}

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06001774 RID: 6004 RVA: 0x0001D572 File Offset: 0x0001B772
		ushort IHIDControllerExtension.usagePage
		{
			get
			{
				return this.vFmTkApcRiDctyfUETrGTVgvdxxi.usagePage;
			}
		}

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06001775 RID: 6005 RVA: 0x0001D57F File Offset: 0x0001B77F
		ushort IHIDControllerExtension.usage
		{
			get
			{
				return this.vFmTkApcRiDctyfUETrGTVgvdxxi.usage;
			}
		}

		// Token: 0x06001776 RID: 6006 RVA: 0x000532A4 File Offset: 0x000514A4
		public RailDriverDriver(HIDDeviceDriver.InitArgs A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			this.BzgOMTOzedJhGZAXDTxEBCjiRczC = A_1.hidDevice;
			this.vFmTkApcRiDctyfUETrGTVgvdxxi = this.BzgOMTOzedJhGZAXDTxEBCjiRczC.properties;
			this.OGKCeaaOgGRqZePEeEmLGKjomzTH = new NativeBuffer(15);
			this.ofNcgDUXdeLGDrKlICZrWEQUxdUi = new NativeBuffer(9);
			this.kIpBzVqNVTYTYtHXZRGezzSOlpGi = new AWHWYMjOaGiEqJCCtAEpfhRJAtYq(this.ofNcgDUXdeLGDrKlICZrWEQUxdUi.Pointer, this.ofNcgDUXdeLGDrKlICZrWEQUxdUi.Length, 9);
			this.buttons = new bsHiSnxdPKGTmlVVXzABmREfuPAX[50];
			for (int i = 0; i < 50; i++)
			{
				this.buttons[i] = new bsHiSnxdPKGTmlVVXzABmREfuPAX(0, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			this.axes = new WlBhllbxXziYUoZmsblPearfaCpbA[]
			{
				new WlBhllbxXziYUoZmsblPearfaCpbA(0, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0U,
					unitsExp = 0U
				}, false, 127),
				new WlBhllbxXziYUoZmsblPearfaCpbA(0, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0U,
					unitsExp = 0U
				}, false, 127),
				new WlBhllbxXziYUoZmsblPearfaCpbA(0, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 3,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0U,
					unitsExp = 0U
				}, false, 127),
				new WlBhllbxXziYUoZmsblPearfaCpbA(0, new zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 4,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0U,
					unitsExp = 0U
				}, false, 127)
			};
		}

		// Token: 0x06001777 RID: 6007 RVA: 0x000116E9 File Offset: 0x0000F8E9
		public override void Update(UpdateLoopType updateLoop)
		{
		}

		// Token: 0x06001778 RID: 6008 RVA: 0x000534E4 File Offset: 0x000516E4
		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < this.OGKCeaaOgGRqZePEeEmLGKjomzTH.Length)
			{
				return false;
			}
			this.OGKCeaaOgGRqZePEeEmLGKjomzTH.Write(inputReportPtr, inputReportLength, this.OGKCeaaOgGRqZePEeEmLGKjomzTH.Length, 0, 0);
			this.HRHZbGqflduCabMlUwVXfGUkPHkG(this.OGKCeaaOgGRqZePEeEmLGKjomzTH, timestamp);
			zHTBvVyhFGDLpEJMFINchPNfqnfnb[] axes = this.axes;
			this.KaTvVOChFVyNXAFCUpIXoQrYDkPX(axes, this.OGKCeaaOgGRqZePEeEmLGKjomzTH, timestamp);
			return true;
		}

		// Token: 0x06001779 RID: 6009 RVA: 0x0001D58C File Offset: 0x0001B78C
		public override Controller.Extension CreateControllerExtension()
		{
			return new RailDriverExtension(this);
		}

		// Token: 0x0600177A RID: 6010 RVA: 0x0001D594 File Offset: 0x0001B794
		private bool OFbqwCYhPnVaQaSdPnnsoYKShMbM(RailDriverDriver.DGtGKHWtHgbXViTKfNqHAckdZReQ A_1, xvcebytMmHXPBmUQiJYMACsdJpLo A_2)
		{
			this.uRoEuhAqsxAJfCZYAPeHIYiTkozzA(A_1);
			return this.blaBqOzsRdkpnxOJwoXgDSxWnYSt(A_2);
		}

		// Token: 0x0600177B RID: 6011 RVA: 0x00053550 File Offset: 0x00051750
		private void uRoEuhAqsxAJfCZYAPeHIYiTkozzA(RailDriverDriver.DGtGKHWtHgbXViTKfNqHAckdZReQ A_1)
		{
			if (A_1 == RailDriverDriver.DGtGKHWtHgbXViTKfNqHAckdZReQ.Speaker)
			{
				this.ofNcgDUXdeLGDrKlICZrWEQUxdUi.Clear();
				this.ofNcgDUXdeLGDrKlICZrWEQUxdUi[1] = 133;
				this.ofNcgDUXdeLGDrKlICZrWEQUxdUi[7] = (this.CtdglJkxudgHUVcdmCKfHutNmjqA ? 1 : 0);
				return;
			}
			if (A_1 != RailDriverDriver.DGtGKHWtHgbXViTKfNqHAckdZReQ.LED)
			{
				throw new NotImplementedException();
			}
			this.ofNcgDUXdeLGDrKlICZrWEQUxdUi.Clear();
			this.ofNcgDUXdeLGDrKlICZrWEQUxdUi[1] = 134;
			this.ofNcgDUXdeLGDrKlICZrWEQUxdUi[2] = this.WjjrmhvHqLGStAtOssiwtbvdIWaI[0];
			this.ofNcgDUXdeLGDrKlICZrWEQUxdUi[3] = this.WjjrmhvHqLGStAtOssiwtbvdIWaI[1];
			this.ofNcgDUXdeLGDrKlICZrWEQUxdUi[4] = this.WjjrmhvHqLGStAtOssiwtbvdIWaI[2];
		}

		// Token: 0x0600177C RID: 6012 RVA: 0x0001D5A4 File Offset: 0x0001B7A4
		private bool blaBqOzsRdkpnxOJwoXgDSxWnYSt(xvcebytMmHXPBmUQiJYMACsdJpLo A_1)
		{
			if (A_1 == xvcebytMmHXPBmUQiJYMACsdJpLo.Synchronous)
			{
				return this.BzgOMTOzedJhGZAXDTxEBCjiRczC.WriteSync(this.kIpBzVqNVTYTYtHXZRGezzSOlpGi, 0);
			}
			if (A_1 == xvcebytMmHXPBmUQiJYMACsdJpLo.Asynchronous)
			{
				this.BzgOMTOzedJhGZAXDTxEBCjiRczC.WriteAsync(this.kIpBzVqNVTYTYtHXZRGezzSOlpGi, 1000);
				return true;
			}
			throw new NotImplementedException();
		}

		// Token: 0x0600177D RID: 6013 RVA: 0x000535FC File Offset: 0x000517FC
		private void HRHZbGqflduCabMlUwVXfGUkPHkG(NativeBuffer A_1, double A_2)
		{
			for (int i = 0; i < 6; i++)
			{
				byte b = A_1[8 + i];
				int num = i * 8;
				for (int j = 0; j < 8; j++)
				{
					int num2 = num + j;
					if (num2 >= 44)
					{
						break;
					}
					this.buttons[num2].dcmdjPVjtigsiROYEiHxGPMPgEOn(((int)b & 1 << j) != 0, A_2);
				}
			}
			byte b2 = A_1[6];
			this.buttons[44].dcmdjPVjtigsiROYEiHxGPMPgEOn(b2 < 95, A_2);
			this.buttons[45].dcmdjPVjtigsiROYEiHxGPMPgEOn(b2 >= 95 && b2 < 161, A_2);
			this.buttons[46].dcmdjPVjtigsiROYEiHxGPMPgEOn(b2 >= 161, A_2);
			b2 = A_1[7];
			this.buttons[47].dcmdjPVjtigsiROYEiHxGPMPgEOn(b2 < 95, A_2);
			this.buttons[48].dcmdjPVjtigsiROYEiHxGPMPgEOn(b2 >= 95 && b2 < 161, A_2);
			this.buttons[49].dcmdjPVjtigsiROYEiHxGPMPgEOn(b2 >= 161, A_2);
		}

		// Token: 0x0600177E RID: 6014 RVA: 0x0004E9C4 File Offset: 0x0004CBC4
		private void KaTvVOChFVyNXAFCUpIXoQrYDkPX(zHTBvVyhFGDLpEJMFINchPNfqnfnb[] A_1, NativeBuffer A_2, double A_3)
		{
			for (int i = 0; i < A_1.Length; i++)
			{
				A_1[i].WMAwtKiWRygWRqyRkTqlMnhmDEdgA(A_2, A_3);
			}
		}

		// Token: 0x0600177F RID: 6015 RVA: 0x0004F27C File Offset: 0x0004D47C
		~RailDriverDriver()
		{
			this.Dispose(false);
		}

		// Token: 0x06001780 RID: 6016 RVA: 0x0001D5DD File Offset: 0x0001B7DD
		protected override void Dispose(bool disposing)
		{
			if (base.disposed)
			{
				return;
			}
			base.Dispose(disposing);
			if (disposing)
			{
				if (this.OGKCeaaOgGRqZePEeEmLGKjomzTH != null)
				{
					this.OGKCeaaOgGRqZePEeEmLGKjomzTH.Dispose();
				}
				if (this.ofNcgDUXdeLGDrKlICZrWEQUxdUi != null)
				{
					this.ofNcgDUXdeLGDrKlICZrWEQUxdUi.Dispose();
				}
			}
		}

		// Token: 0x06001781 RID: 6017 RVA: 0x0001D618 File Offset: 0x0001B818
		public static bool Matches(int vid, int pid)
		{
			return 1523 == vid && 210 == pid;
		}

		// Token: 0x040032FE RID: 13054
		private const int qgmOtSsNXKdayLNHjiAFbgcLYgGu = 1523;

		// Token: 0x040032FF RID: 13055
		private const int IUeuGWKiqWGjExMuWsDweXNGiJJV = 210;

		// Token: 0x04003300 RID: 13056
		private const int OmJJCCHBhVjPZuzrSNywDZMATSBO = 50;

		// Token: 0x04003301 RID: 13057
		private const int cMXuPQoikmukHAqghsuxKpzYkdRP = 44;

		// Token: 0x04003302 RID: 13058
		private const int foZVvDpusJLmauzFaNSksRXyhWE = 6;

		// Token: 0x04003303 RID: 13059
		private const int MutzBRuTuiSfGdPkSdIuKGlXbwnCb = 44;

		// Token: 0x04003304 RID: 13060
		private const int wAIiSGFvmmgDtaFnfHMQgxkcmPiRc = 45;

		// Token: 0x04003305 RID: 13061
		private const int DPqRwSDFcPQfbRRBpXRcVaxbSZwb = 46;

		// Token: 0x04003306 RID: 13062
		private const int BqNaafmCiBBlIqEzsSdLjHjqwrCC = 47;

		// Token: 0x04003307 RID: 13063
		private const int JYPXgHCdGDKfyigOvwPlEyrfNYgF = 48;

		// Token: 0x04003308 RID: 13064
		private const int ZTiAeFeuzmmQyNLdaZiroamqIUiKA = 49;

		// Token: 0x04003309 RID: 13065
		private const int QEqCAkKMzajcvzdvReocQxsqBEJW = 0;

		// Token: 0x0400330A RID: 13066
		private const int RsCRVOVmNFcTlavOOixtUBukKcMy = 15;

		// Token: 0x0400330B RID: 13067
		private const int wNHokWeWszRaqypbeIJYvPJomteA = 9;

		// Token: 0x0400330C RID: 13068
		private const int MrInZfFNFqTrsqknKxvLAubMFNTO = 1;

		// Token: 0x0400330D RID: 13069
		private const int upbyauzukDSQzqlTHEaaxEwKTUTS = 2;

		// Token: 0x0400330E RID: 13070
		private const int WDuABVvGzpHBAOldxDaUTcJHibrBA = 3;

		// Token: 0x0400330F RID: 13071
		private const int uqxRTKuOTEGaYXLGvjOWdiHhYphdA = 4;

		// Token: 0x04003310 RID: 13072
		private const int UOezvTCiudObaQSopbZfhcwRoVKN = 5;

		// Token: 0x04003311 RID: 13073
		private const int lNNChDHImtKlSvErfNgOcdLCXlWN = 6;

		// Token: 0x04003312 RID: 13074
		private const int udKJiWZcwTDLpkGTkXHHFAFGRVgO = 7;

		// Token: 0x04003313 RID: 13075
		private const int yFyBNZFHmTEIsXvQZYVrqmAwEqSAb = 8;

		// Token: 0x04003314 RID: 13076
		private const int mKwQRyTvFhwffXHKCrXuMGregYAs = 14;

		// Token: 0x04003315 RID: 13077
		private const int qltULpSBejCVylYjTjjMoxWZhKyt = 3;

		// Token: 0x04003316 RID: 13078
		private const int onAnsPTriEJTjoZewcLNcIgXIFPjA = 7;

		// Token: 0x04003317 RID: 13079
		private readonly NativeBuffer OGKCeaaOgGRqZePEeEmLGKjomzTH;

		// Token: 0x04003318 RID: 13080
		private readonly NativeBuffer ofNcgDUXdeLGDrKlICZrWEQUxdUi;

		// Token: 0x04003319 RID: 13081
		private bool CtdglJkxudgHUVcdmCKfHutNmjqA;

		// Token: 0x0400331A RID: 13082
		private byte[] WjjrmhvHqLGStAtOssiwtbvdIWaI = new byte[3];

		// Token: 0x0400331B RID: 13083
		private readonly HIDDeviceDriver.IHIDDevice BzgOMTOzedJhGZAXDTxEBCjiRczC;

		// Token: 0x0400331C RID: 13084
		private readonly HIDDeviceDriver.HIDProperties vFmTkApcRiDctyfUETrGTVgvdxxi;

		// Token: 0x0400331D RID: 13085
		private readonly AWHWYMjOaGiEqJCCtAEpfhRJAtYq kIpBzVqNVTYTYtHXZRGezzSOlpGi;

		// Token: 0x02000321 RID: 801
		private enum DGtGKHWtHgbXViTKfNqHAckdZReQ
		{
			// Token: 0x0400331F RID: 13087
			Speaker,
			// Token: 0x04003320 RID: 13088
			LED
		}
	}
}
