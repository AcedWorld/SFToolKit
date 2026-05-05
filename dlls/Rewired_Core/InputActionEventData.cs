using System;
using System.Collections.Generic;

namespace Rewired
{
	// Token: 0x02000006 RID: 6
	public struct InputActionEventData
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600000E RID: 14 RVA: 0x0000246D File Offset: 0x0000066D
		// (set) Token: 0x0600000F RID: 15 RVA: 0x00002475 File Offset: 0x00000675
		public InputActionEventType eventType
		{
			get
			{
				return this.dpIfSAxnUyJOGfjPxXVpGCUMTOuA;
			}
			internal set
			{
				this.dpIfSAxnUyJOGfjPxXVpGCUMTOuA = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000010 RID: 16 RVA: 0x0000247E File Offset: 0x0000067E
		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.players.GetPlayer(this.playerId);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002499 File Offset: 0x00000699
		public string actionName
		{
			get
			{
				if (!ReInput.isReady)
				{
					return string.Empty;
				}
				return ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.zBXmrejZuuEPoeoiDDZIaQYCoFmv(this.actionId).name;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000012 RID: 18 RVA: 0x000024BD File Offset: 0x000006BD
		public string actionDescriptiveName
		{
			get
			{
				if (!ReInput.isReady)
				{
					return string.Empty;
				}
				return ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.zBXmrejZuuEPoeoiDDZIaQYCoFmv(this.actionId).descriptiveName;
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000024E1 File Offset: 0x000006E1
		public float GetAxis()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.ZPnnWnuioRHnHyXZXKWHKDyfDapAA();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000024EE File Offset: 0x000006EE
		public float GetAxisPrev()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.zeIvxBEyQDnSJZoRCukhvNlOQqPk();
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000024FB File Offset: 0x000006FB
		public float GetAxisDelta()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.JcoMCwHbLcQrTzrfjEczXQEWhkKH();
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002508 File Offset: 0x00000708
		public double GetAxisTimeActive()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.MmHkSwRdUQtZMocqRgPXgzuSUrfe();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002515 File Offset: 0x00000715
		public double GetAxisTimeInactive()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.MyHSUivBytCndhknlCiBpZMblHfp();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002522 File Offset: 0x00000722
		public float GetAxisRaw()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.KBRilOANCOjinFxICUYpQZAcnxarB();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000252F File Offset: 0x0000072F
		public float GetAxisRawDelta()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.UGtpNRqVtWAMlxZxOBPFuiVrahSbA();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000253C File Offset: 0x0000073C
		public float GetAxisRawPrev()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.HkvMKqVfYwmAfauEGBultMpQzGWC();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002549 File Offset: 0x00000749
		public double GetAxisRawTimeActive()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.XcsRNAtPMzwEhwLaMacWaPEAmzFAA();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002556 File Offset: 0x00000756
		public double GetAxisRawTimeInactive()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.yQYyLKQKnMfHmzMHuKICdnFYcLsf();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002563 File Offset: 0x00000763
		public AxisCoordinateMode GetAxisCoordinateMode()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.WojBcNFKvgOvFnKvrgACEMevkdrI();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002570 File Offset: 0x00000770
		public AxisCoordinateMode GetAxisCoordinateModePrev()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.YXXRsKQIANjvEVswVdHbSLmqlDgX();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000257D File Offset: 0x0000077D
		public AxisCoordinateMode GetAxisRawCoordinateMode()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.igzeVXulKZrqUXFKfZkQvwwFHLSX();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000258A File Offset: 0x0000078A
		public AxisCoordinateMode GetAxisRawCoordinateModePrev()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.gJqeezRfNRnzoFsyAoiEtwoAjOmu();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002597 File Offset: 0x00000797
		public bool GetButton()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.PLEzowLfRVYnmqUhFdELfVgtLRUU();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000025A4 File Offset: 0x000007A4
		public bool GetButtonPrev()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.oFwEbOzifvsGVUHSHODNgMNlGvzcA();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000025B1 File Offset: 0x000007B1
		public bool GetButtonDown()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.cgnNvIBXdjcArepYxqVhcluOaiAF();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000025BE File Offset: 0x000007BE
		public bool GetButtonUp()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.iqpRhWPPruMPiSurJSIiJhNgoOiO();
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000025CB File Offset: 0x000007CB
		public bool GetButtonSinglePressHold()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.TtiHmMweSqotoAUWwlbDjsYVgpkcA();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000025D8 File Offset: 0x000007D8
		public bool GetButtonSinglePressDown()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.LWbCfZDYbtngeYfwehddWnTHkZmL();
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000025E5 File Offset: 0x000007E5
		public bool GetButtonSinglePressUp()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.HfbBeghVKYofUBdMipStTLDWnePt();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000025F2 File Offset: 0x000007F2
		public bool GetButtonDoublePressDown()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.RSbWzxTjULHvXrpzIasjWHbRcldG();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000025FF File Offset: 0x000007FF
		public bool GetButtonDoublePressDown(float speed)
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.tVtvoroswQXEnbdAENmIGAElmIBc(speed);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000260D File Offset: 0x0000080D
		public bool GetButtonDoublePressHold()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.sEBvXkfbZucozKekmkmIhQQkTXwV();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000261A File Offset: 0x0000081A
		public bool GetButtonDoublePressHold(float speed)
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.oZfcBbUtGNPizYqlKFKnHBYvkUFRA(speed);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002628 File Offset: 0x00000828
		public bool GetButtonDoublePressUp()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.DfGBNrdfRKIGfnSMAUHPHhmyNkaRA();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002635 File Offset: 0x00000835
		public bool GetButtonDoublePressUp(float speed)
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.JZbmLwFjMyOqchpEzbxnChuSPPgo(speed);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002643 File Offset: 0x00000843
		public bool GetButtonTimedPress(float time)
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.zpvDECrzpTCpSrBbeXUUgieFKOlg(time, 0f);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002656 File Offset: 0x00000856
		public bool GetButtonTimedPress(float time, float expireIn)
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.zpvDECrzpTCpSrBbeXUUgieFKOlg(time, expireIn);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002665 File Offset: 0x00000865
		public bool GetButtonTimedPressDown(float time)
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.aGvkASuRZjHXWXpVpTxDBOXESHpc(time);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002673 File Offset: 0x00000873
		public bool GetButtonTimedPressUp(float time)
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.DHssSjYakDuhVUAVpnowwTPiMpSE(time, 0f);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002686 File Offset: 0x00000886
		public bool GetButtonTimedPressUp(float time, float expireIn)
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.DHssSjYakDuhVUAVpnowwTPiMpSE(time, expireIn);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002695 File Offset: 0x00000895
		public bool GetButtonShortPress()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.DCYPHQBUQWTQyFmGGGYmeiAycAZR();
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000026A2 File Offset: 0x000008A2
		public bool GetButtonShortPressDown()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.HPuKJdCWHuCwPrBFJVtqnvtpQLnn();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000026AF File Offset: 0x000008AF
		public bool GetButtonShortPressUp()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.zyIWmXRVRLmtfjUGqPWKrVhOpplL();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000026BC File Offset: 0x000008BC
		public bool GetButtonLongPress()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.QXrrgbvJsTRiAGESJowgdvzQClRh();
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000026C9 File Offset: 0x000008C9
		public bool GetButtonLongPressDown()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.qTObevNNKnAiasvGCHaKAchXpabA();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000026D6 File Offset: 0x000008D6
		public bool GetButtonLongPressUp()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.byeGARHXOEmjPxcQoTOUGzYnfkKu();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000026E3 File Offset: 0x000008E3
		public bool GetButtonRepeating()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.bydTKFtJThpJiBleSRZzwDlRDOBL();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000026F0 File Offset: 0x000008F0
		public double GetButtonTimePressed()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.gNempBrAyTbRDWwSleIwOdtmpVtw();
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000026FD File Offset: 0x000008FD
		public double GetButtonTimeUnpressed()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.VYQDnrrCLsVEwPSOvFIDtcDnhPkB();
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000270A File Offset: 0x0000090A
		public bool GetNegativeButton()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.HWGpqzxmCQzoZIFrUhOuHScOhfbr();
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002717 File Offset: 0x00000917
		public bool GetNegativeButtonPrev()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.pJdNBJgzCniVonEUxixmJoDFVzqI();
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002724 File Offset: 0x00000924
		public bool GetNegativeButtonDown()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.DEqKIDythebfGxHycCDdFiTYHWfF();
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002731 File Offset: 0x00000931
		public bool GetNegativeButtonUp()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.YJetLbybKqkFHlIxOBMORKTNchaY();
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000273E File Offset: 0x0000093E
		public bool GetNegativeButtonSinglePressHold()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.gKhqNfBJWPQCWmZgQkjzVxTeghGO();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000274B File Offset: 0x0000094B
		public bool GetNegativeButtonSinglePressDown()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.UobencRdPOsVfpqTAcwrMWBOlucv();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002758 File Offset: 0x00000958
		public bool GetNegativeButtonSinglePressUp()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.AaTsVPLVcybQrrgogrjJLSkxuclV();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002765 File Offset: 0x00000965
		public bool GetNegativeButtonDoublePressDown()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.FPynyxlFTtjzbxhWpOkKlLwWLmVg();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002772 File Offset: 0x00000972
		public bool GetNegativeButtonDoublePressDown(float speed)
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.HiYmLLYxrhaYHiqeBOjtIGIuNpEQ(speed);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002780 File Offset: 0x00000980
		public bool GetNegativeButtonDoublePressHold()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.ctPerYDLPkNtZNcEkHTGPyuPQoPVA();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000278D File Offset: 0x0000098D
		public bool GetNegativeButtonDoublePressHold(float speed)
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.RTWkHLUpAmesTmkgELyVDjMemKUn(speed);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x0000279B File Offset: 0x0000099B
		public bool GetNegativeButtonDoublePressUp()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.wKndARlDimVggsXZnFfctkMgSEIA();
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000027A8 File Offset: 0x000009A8
		public bool GetNegativeButtonDoublePressUp(float speed)
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.hZDmLiEfhVfHuJFrpmbvWeZDliNEb(speed);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000027B6 File Offset: 0x000009B6
		public bool GetNegativeButtonTimedPress(float time)
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.HJcCPAAxaZKAkATvymNFuNUGeixn(time, 0f);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000027C9 File Offset: 0x000009C9
		public bool GetNegativeButtonTimedPress(float time, float expireIn)
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.HJcCPAAxaZKAkATvymNFuNUGeixn(time, expireIn);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000027D8 File Offset: 0x000009D8
		public bool GetNegativeButtonTimedPressDown(float time)
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.kxPJKadwjgTEVvjOoxRmKCjcGMshA(time);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000027E6 File Offset: 0x000009E6
		public bool GetNegativeButtonTimedPressUp(float time)
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.VNMQdEPgUWpZCUdysrrlMBNQfMpq(time, 0f);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000027F9 File Offset: 0x000009F9
		public bool GetNegativeButtonTimedPressUp(float time, float expireIn)
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.VNMQdEPgUWpZCUdysrrlMBNQfMpq(time, expireIn);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002808 File Offset: 0x00000A08
		public bool GetNegativeButtonShortPress()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.yekfXbpfvbVIhCPSOETpyFIXXvZI();
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002815 File Offset: 0x00000A15
		public bool GetNegativeButtonShortPressDown()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.mlPISDGCNvaJJTDdHhtCJbYKKcQL();
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002822 File Offset: 0x00000A22
		public bool GetNegativeButtonShortPressUp()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.JGiKRKJdtaebnxDHKwGTQnLkWoQE();
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000282F File Offset: 0x00000A2F
		public bool GetNegativeButtonLongPress()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.MOMLKtzwDEKbkXbSyroGZcZPmBrg();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000283C File Offset: 0x00000A3C
		public bool GetNegativeButtonLongPressDown()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.gNKMpTVSjVbOBkSwBfMifjCrZDNH();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002849 File Offset: 0x00000A49
		public bool GetNegativeButtonLongPressUp()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.VhxSlbANjTXbiijCgfOaJwIAMgygA();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002856 File Offset: 0x00000A56
		public bool GetNegativeButtonRepeating()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.aXIfnVraJSaGrMGfbgfHhEprqwOnA();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002863 File Offset: 0x00000A63
		public double GetNegativeButtonTimePressed()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.mqvWHEuwnomGVOyodRZPEbJsWeit();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002870 File Offset: 0x00000A70
		public double GetNegativeButtonTimeUnpressed()
		{
			return this.HkPrlzCUGVNhCdVQTePfVPYqWvVp.IgyWDwXEKwkniYMdFqRmkbavJkPO();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0002AC24 File Offset: 0x00028E24
		public IList<InputActionSourceData> GetCurrentInputSources()
		{
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.playerId, this.actionId, true);
			if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs == null)
			{
				return null;
			}
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.hZiPskALAXsUtBLlSarWzvOmmtg();
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0002AC54 File Offset: 0x00028E54
		public bool IsCurrentInputSource(ControllerType controllerType)
		{
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.playerId, this.actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.adFzUOgTCBtNzHOwtlssTlcJhXZw(controllerType);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0002AC88 File Offset: 0x00028E88
		public bool IsCurrentInputSource(ControllerType controllerType, int controllerId)
		{
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.playerId, this.actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.onRntVgtimRSBUIRmCSKFoWcDZalA(controllerType, controllerId);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0002ACBC File Offset: 0x00028EBC
		public bool IsCurrentInputSource(Controller controller)
		{
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = ReInput.JVYgltGRcvVxyHxDFcTYdYskrSmBb.LkKjRklxnAokVkoNYSqTVxjiDyEd(this.playerId, this.actionId, true);
			return iWmRLdlDqgwSNYjkwtUZeqvQOyqs != null && iWmRLdlDqgwSNYjkwtUZeqvQOyqs.fGcZYgmiFVldvaTpBCLSjlgpYnWm(controller);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000287D File Offset: 0x00000A7D
		internal InputActionEventData(iWmRLdlDqgwSNYjkwtUZeqvQOyqs A_1, int A_2, int A_3, UpdateLoopType A_4)
		{
			this.dpIfSAxnUyJOGfjPxXVpGCUMTOuA = InputActionEventType.Update;
			this.HkPrlzCUGVNhCdVQTePfVPYqWvVp = A_1;
			this.playerId = A_2;
			this.actionId = A_3;
			this.updateLoop = A_4;
		}

		// Token: 0x0400000A RID: 10
		private iWmRLdlDqgwSNYjkwtUZeqvQOyqs HkPrlzCUGVNhCdVQTePfVPYqWvVp;

		// Token: 0x0400000B RID: 11
		private InputActionEventType dpIfSAxnUyJOGfjPxXVpGCUMTOuA;

		// Token: 0x0400000C RID: 12
		public readonly int playerId;

		// Token: 0x0400000D RID: 13
		public readonly int actionId;

		// Token: 0x0400000E RID: 14
		public readonly UpdateLoopType updateLoop;
	}
}
