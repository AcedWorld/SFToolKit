using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

// Token: 0x02000006 RID: 6
internal sealed class JqUKKiwhYOELBracduSEHlaDBJSA : IElementIdentifierTool
{
	// Token: 0x06000041 RID: 65 RVA: 0x000114B0 File Offset: 0x0000F6B0
	public void Initialize(GUIText text)
	{
		this.FRtECKcKLCPlONQgyxuwtVuLIlOb = text;
		this.suguEZWxsRspbewZqkPlGhjBBFTdA = Enum.GetNames(typeof(RawInputAxis));
		this.TAXCOIBDOfCUZCSuEPAALMrIfHuQc = (int[])Enum.GetValues(typeof(RawInputAxis));
	}

	// Token: 0x06000042 RID: 66 RVA: 0x0001E6C0 File Offset: 0x0001C8C0
	public void Start()
	{
		if (ReInput.isEditor && ReInput.editorPlatform != EditorPlatform.Windows)
		{
			Logger.LogError("Raw Input cannot be run on this platform. You must be running the editor in Windows.");
			return;
		}
		if (ReInput.currentPlatform != Platform.Windows)
		{
			Logger.LogError("Raw Input cannot be run on this build target. Be sure Unity's build target is set to Windows Standalone.");
			return;
		}
		this.zSxVAGnnJtHSiLVQeWKqdqXRIXdL = (ReInput.primaryInputManager.inputSource as wOInxLKDewlatLvQaXlNWuUFKXeD);
		if (this.zSxVAGnnJtHSiLVQeWKqdqXRIXdL == null)
		{
			Logger.LogError("Unable to initialize Raw Input! You must add a Rewired Input Manager to the scene and set the input mode to Raw Input.");
			return;
		}
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += this.sHtSYmZcBIiqdFylVvmNMnEdzjlM;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += this.jqvFYQcdrchCKkSFDeTQmtGzxwIHA;
		this.HikYkHwLJkXhTykIvNkZNyZOktEW();
		this.iUtZkQLmCcdFxFScARDvDKxCkSOmb = true;
	}

	// Token: 0x06000043 RID: 67 RVA: 0x0001E75C File Offset: 0x0001C95C
	public void Update()
	{
		if (!this.iUtZkQLmCcdFxFScARDvDKxCkSOmb)
		{
			return;
		}
		this.EeSXhyUhZytkqevEStUMjtaEflle = "Raw Input Joystick Element Identifier\n\n";
		this.FRtECKcKLCPlONQgyxuwtVuLIlOb.text = this.EeSXhyUhZytkqevEStUMjtaEflle;
		int viVgtGKBdONoUWgWSUOQtPlsbtIy = this.ViVgtGKBdONoUWgWSUOQtPlsbtIy;
		Guid a = this.vJmxLyxAUwdpongHUdWFSZMFKvAv;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			this.ViVgtGKBdONoUWgWSUOQtPlsbtIy++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			this.ViVgtGKBdONoUWgWSUOQtPlsbtIy--;
		}
		if (this.eGkTqCJuINOdHlnxrkeXloejgmSX)
		{
			this.HikYkHwLJkXhTykIvNkZNyZOktEW();
			this.eGkTqCJuINOdHlnxrkeXloejgmSX = false;
		}
		int num = (this.wzUpbiVFvcDkOqntKorVyRKzITWw != null) ? this.wzUpbiVFvcDkOqntKorVyRKzITWw.Count : 0;
		if (num == 0)
		{
			return;
		}
		if (this.ViVgtGKBdONoUWgWSUOQtPlsbtIy < 0)
		{
			this.ViVgtGKBdONoUWgWSUOQtPlsbtIy = num - 1;
		}
		else if (this.ViVgtGKBdONoUWgWSUOQtPlsbtIy >= num)
		{
			this.ViVgtGKBdONoUWgWSUOQtPlsbtIy = 0;
		}
		this.vJmxLyxAUwdpongHUdWFSZMFKvAv = this.wzUpbiVFvcDkOqntKorVyRKzITWw[this.ViVgtGKBdONoUWgWSUOQtPlsbtIy].GNTLZGZMYteNfQShJMHVqmWwrOKR;
		bool flag = false;
		if (viVgtGKBdONoUWgWSUOQtPlsbtIy != this.ViVgtGKBdONoUWgWSUOQtPlsbtIy || a != this.vJmxLyxAUwdpongHUdWFSZMFKvAv)
		{
			flag = true;
		}
		if (this.xdoNsbhahrKuObEzxadYARKJWRxy == null || flag)
		{
			if (this.xdoNsbhahrKuObEzxadYARKJWRxy != null)
			{
				this.xdoNsbhahrKuObEzxadYARKJWRxy.aLGLCNQlAGFbzfFShLCURNjpXQRLA();
			}
			this.xdoNsbhahrKuObEzxadYARKJWRxy = this.wzUpbiVFvcDkOqntKorVyRKzITWw[this.ViVgtGKBdONoUWgWSUOQtPlsbtIy];
			if (this.xdoNsbhahrKuObEzxadYARKJWRxy == null)
			{
				return;
			}
			this.xdoNsbhahrKuObEzxadYARKJWRxy.KdgtFiNynTGrzMSLaREzsijtfvXB();
		}
		bool flag2 = false;
		if (this.xdoNsbhahrKuObEzxadYARKJWRxy.CjqyIMsBbXiZyfJCwEMIozoxkqNo is HcYEnccIjPAYPjznhnzOXfyNmtcA)
		{
			flag2 = true;
		}
		else if (!(this.xdoNsbhahrKuObEzxadYARKJWRxy.CjqyIMsBbXiZyfJCwEMIozoxkqNo is IPSdCZFUYRXiSCWqVVaWtTkwblCIA))
		{
			return;
		}
		if (num > 0)
		{
			this.EeSXhyUhZytkqevEStUMjtaEflle = this.EeSXhyUhZytkqevEStUMjtaEflle + num.ToString() + " connected devices:\n";
		}
		for (int i = 0; i < num; i++)
		{
			this.EeSXhyUhZytkqevEStUMjtaEflle = this.EeSXhyUhZytkqevEStUMjtaEflle + this.wzUpbiVFvcDkOqntKorVyRKzITWw[i].aNWLXhLWGmlNwNjarBtbGFEZsCcjb + "\n";
		}
		this.EeSXhyUhZytkqevEStUMjtaEflle += "\n";
		this.EeSXhyUhZytkqevEStUMjtaEflle = string.Concat(new string[]
		{
			this.EeSXhyUhZytkqevEStUMjtaEflle,
			"Current RI device ",
			this.ViVgtGKBdONoUWgWSUOQtPlsbtIy.ToString(),
			": \"",
			this.xdoNsbhahrKuObEzxadYARKJWRxy.aNWLXhLWGmlNwNjarBtbGFEZsCcjb,
			"\"\n"
		});
		this.EeSXhyUhZytkqevEStUMjtaEflle += "(Press + or - to change monitored device id.)\n\n";
		this.wYWykGJOzUxdwlaTfXOGVQhMpTxd("Product Name", "\"" + this.xdoNsbhahrKuObEzxadYARKJWRxy.aNWLXhLWGmlNwNjarBtbGFEZsCcjb + "\"");
		this.wYWykGJOzUxdwlaTfXOGVQhMpTxd("Is Bluetooth Device", this.xdoNsbhahrKuObEzxadYARKJWRxy.sSEwpwqkxLufRnCodfVriXMzECJm);
		if (this.xdoNsbhahrKuObEzxadYARKJWRxy.sSEwpwqkxLufRnCodfVriXMzECJm)
		{
			this.wYWykGJOzUxdwlaTfXOGVQhMpTxd("Bluetooth Device Name", "\"" + this.xdoNsbhahrKuObEzxadYARKJWRxy.xgLtCGMbIZFiPgINPDaFQATjyGnb + "\"");
		}
		if (flag2)
		{
			this.wYWykGJOzUxdwlaTfXOGVQhMpTxd("Using Custom Driver", "TRUE");
		}
		this.wYWykGJOzUxdwlaTfXOGVQhMpTxd("Device Type", this.xdoNsbhahrKuObEzxadYARKJWRxy.BlgUDNeotKGCVXkuubuQsIWeKoTq.ToString());
		this.wYWykGJOzUxdwlaTfXOGVQhMpTxd("Identifier", new PidVid(this.xdoNsbhahrKuObEzxadYARKJWRxy.GWbIxeTfbRipYnHifgKzkkVPynigA));
		this.wYWykGJOzUxdwlaTfXOGVQhMpTxd("Product Id", this.xdoNsbhahrKuObEzxadYARKJWRxy.gQKqCyxHcQWSYcLHtQkBxKYVGOOeA);
		this.wYWykGJOzUxdwlaTfXOGVQhMpTxd("Vendor Id", this.xdoNsbhahrKuObEzxadYARKJWRxy.iYEmfoJliEcUkzCqcvRxHanukpuq);
		this.EeSXhyUhZytkqevEStUMjtaEflle += "\n";
		this.wYWykGJOzUxdwlaTfXOGVQhMpTxd("Axis Count", this.xdoNsbhahrKuObEzxadYARKJWRxy.NzkgnaOHNqJCxeRsdSSRrdNSukjE);
		this.wYWykGJOzUxdwlaTfXOGVQhMpTxd("Button Count", this.xdoNsbhahrKuObEzxadYARKJWRxy.lbnsFjoMSpFiAcHWbdCvUiitnKIcA);
		this.wYWykGJOzUxdwlaTfXOGVQhMpTxd("Hat Count", this.xdoNsbhahrKuObEzxadYARKJWRxy.LbGTYYxaCCdgIaBoxCQhECxBrFji);
		this.EeSXhyUhZytkqevEStUMjtaEflle += "\n";
		if (flag)
		{
			string text = "";
			text = text + "Device Name: \"" + this.wzUpbiVFvcDkOqntKorVyRKzITWw[this.ViVgtGKBdONoUWgWSUOQtPlsbtIy].aNWLXhLWGmlNwNjarBtbGFEZsCcjb + "\"\n";
			if (this.xdoNsbhahrKuObEzxadYARKJWRxy.sSEwpwqkxLufRnCodfVriXMzECJm)
			{
				text = text + "Bluetooth Device Name: \"" + this.xdoNsbhahrKuObEzxadYARKJWRxy.xgLtCGMbIZFiPgINPDaFQATjyGnb + "\"\n";
			}
			text = text + "Identifier: " + new PidVid(this.xdoNsbhahrKuObEzxadYARKJWRxy.GWbIxeTfbRipYnHifgKzkkVPynigA).ToString() + "\n";
			Logger.Log(text);
		}
		if (!flag2)
		{
			IPSdCZFUYRXiSCWqVVaWtTkwblCIA ipsdCZFUYRXiSCWqVVaWtTkwblCIA = this.xdoNsbhahrKuObEzxadYARKJWRxy.CjqyIMsBbXiZyfJCwEMIozoxkqNo as IPSdCZFUYRXiSCWqVVaWtTkwblCIA;
			for (int j = 1; j < this.suguEZWxsRspbewZqkPlGhjBBFTdA.Length - 1; j++)
			{
				int num2 = this.cIFUbBUjEwMKbNUtnKzEKsHEjxDS((RawInputAxis)this.TAXCOIBDOfCUZCSuEPAALMrIfHuQc[j], 0, ipsdCZFUYRXiSCWqVVaWtTkwblCIA);
				string text2 = this.suguEZWxsRspbewZqkPlGhjBBFTdA[j];
				try
				{
					this.wYWykGJOzUxdwlaTfXOGVQhMpTxd(text2, num2.ToString() + " (" + this.YMqcmoEXfiwnJhfXSJpZCDacLqkMb(num2).ToString() + ")");
				}
				catch
				{
					this.wYWykGJOzUxdwlaTfXOGVQhMpTxd(text2, "FAILED! Axis value = " + num2.ToString());
				}
			}
			if (ipsdCZFUYRXiSCWqVVaWtTkwblCIA.ckasgUWpUvksiaotXnIqfdFJNdoX > 0)
			{
				for (int k = 0; k < ipsdCZFUYRXiSCWqVVaWtTkwblCIA.ckasgUWpUvksiaotXnIqfdFJNdoX; k++)
				{
					int num3 = this.cIFUbBUjEwMKbNUtnKzEKsHEjxDS(RawInputAxis.Other, k, ipsdCZFUYRXiSCWqVVaWtTkwblCIA);
					string text3 = "Other Axis " + k.ToString();
					try
					{
						this.wYWykGJOzUxdwlaTfXOGVQhMpTxd(text3, num3.ToString() + " (" + this.YMqcmoEXfiwnJhfXSJpZCDacLqkMb(num3).ToString() + ")");
					}
					catch
					{
						this.wYWykGJOzUxdwlaTfXOGVQhMpTxd(text3, "FAILED! Axis value = " + num3.ToString());
					}
				}
			}
			int[] array = this.xdoNsbhahrKuObEzxadYARKJWRxy.ZezovXXwJbxiiihgGbekVKdzZEpH;
			for (int l = 0; l < array.Length; l++)
			{
				int num4 = array[l];
				string text4 = "Hat " + l.ToString();
				this.wYWykGJOzUxdwlaTfXOGVQhMpTxd(text4, num4);
			}
			bool[] array2 = this.xdoNsbhahrKuObEzxadYARKJWRxy.SBIpSMfhMbXHumLUWAoDaLzlfPgb;
			string text5 = "";
			for (int m = 0; m < array2.Length; m++)
			{
				if (array2[m])
				{
					if (text5 != "")
					{
						text5 += ", ";
					}
					text5 += m.ToString();
				}
			}
			this.wYWykGJOzUxdwlaTfXOGVQhMpTxd("Buttons ", text5);
		}
		else
		{
			HcYEnccIjPAYPjznhnzOXfyNmtcA hcYEnccIjPAYPjznhnzOXfyNmtcA = this.xdoNsbhahrKuObEzxadYARKJWRxy.CjqyIMsBbXiZyfJCwEMIozoxkqNo as HcYEnccIjPAYPjznhnzOXfyNmtcA;
			for (int n = 0; n < this.xdoNsbhahrKuObEzxadYARKJWRxy.NzkgnaOHNqJCxeRsdSSRrdNSukjE; n++)
			{
				float num5 = hcYEnccIjPAYPjznhnzOXfyNmtcA.wYoiXYUrBndvPuoILfVoGOgkslQ(n);
				string text6 = n.ToString();
				try
				{
					this.wYWykGJOzUxdwlaTfXOGVQhMpTxd(text6, num5.ToString() + " (" + hcYEnccIjPAYPjznhnzOXfyNmtcA.TLcASOBMpHSiwGDNDoRvfAoduWTgc(n).ToString() + ")");
				}
				catch
				{
					this.wYWykGJOzUxdwlaTfXOGVQhMpTxd(text6, "FAILED! Axis value = " + num5.ToString());
				}
			}
			int[] array3 = this.xdoNsbhahrKuObEzxadYARKJWRxy.ZezovXXwJbxiiihgGbekVKdzZEpH;
			for (int num6 = 0; num6 < this.xdoNsbhahrKuObEzxadYARKJWRxy.LbGTYYxaCCdgIaBoxCQhECxBrFji; num6++)
			{
				int num7 = array3[num6];
				string text7 = "Hat " + num6.ToString();
				this.wYWykGJOzUxdwlaTfXOGVQhMpTxd(text7, num7);
			}
			for (int num8 = 0; num8 < this.xdoNsbhahrKuObEzxadYARKJWRxy.tyAiqnJTfiEhtdOAyaqGhYQnJKbU.GyroscopeCount; num8++)
			{
				int cvrbxMijQOqoNixNBrBUtnnxddHhb = this.xdoNsbhahrKuObEzxadYARKJWRxy.tyAiqnJTfiEhtdOAyaqGhYQnJKbU.gyroscopes[num8].CvrbxMijQOqoNixNBrBUtnnxddHhb;
				string text8 = "";
				for (int num9 = 0; num9 < cvrbxMijQOqoNixNBrBUtnnxddHhb; num9++)
				{
					float num10 = this.xdoNsbhahrKuObEzxadYARKJWRxy.tyAiqnJTfiEhtdOAyaqGhYQnJKbU.gyroscopes[num8].oxrAVCGYVAsFpNwvvghIcKXCXRPLA[num9];
					text8 = string.Concat(new string[]
					{
						text8,
						"[",
						num9.ToString(),
						"]: ",
						num10.ToString("f3")
					});
					if (num9 < cvrbxMijQOqoNixNBrBUtnnxddHhb - 1)
					{
						text8 += " ";
					}
				}
				this.wYWykGJOzUxdwlaTfXOGVQhMpTxd("Gyro " + num8.ToString(), text8);
			}
			for (int num11 = 0; num11 < this.xdoNsbhahrKuObEzxadYARKJWRxy.tyAiqnJTfiEhtdOAyaqGhYQnJKbU.AccelerometerCount; num11++)
			{
				int bmIgCitWoujyBdynciLMEvcTpTQEb = this.xdoNsbhahrKuObEzxadYARKJWRxy.tyAiqnJTfiEhtdOAyaqGhYQnJKbU.accelerometers[num11].bmIgCitWoujyBdynciLMEvcTpTQEb;
				string text9 = "";
				for (int num12 = 0; num12 < bmIgCitWoujyBdynciLMEvcTpTQEb; num12++)
				{
					float num13 = this.xdoNsbhahrKuObEzxadYARKJWRxy.tyAiqnJTfiEhtdOAyaqGhYQnJKbU.accelerometers[num11].wxlPSRPpXOGcnsgwYrXChZnlGJzD[num12];
					text9 = string.Concat(new string[]
					{
						text9,
						"[",
						num12.ToString(),
						"]: ",
						num13.ToString("f3")
					});
					if (num12 < bmIgCitWoujyBdynciLMEvcTpTQEb - 1)
					{
						text9 += " ";
					}
				}
				this.wYWykGJOzUxdwlaTfXOGVQhMpTxd("Accelerometer " + num11.ToString(), text9);
			}
			for (int num14 = 0; num14 < this.xdoNsbhahrKuObEzxadYARKJWRxy.tyAiqnJTfiEhtdOAyaqGhYQnJKbU.TouchpadCount; num14++)
			{
				zwWEPIBfQQjvcFGMdkkFNKDGwfdgA zwWEPIBfQQjvcFGMdkkFNKDGwfdgA = this.xdoNsbhahrKuObEzxadYARKJWRxy.tyAiqnJTfiEhtdOAyaqGhYQnJKbU.touchpads[num14];
				int num15 = zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.mbGotkNspciCdWUfwbxMijjJnXsL.Length;
				string text10 = "";
				for (int num16 = 0; num16 < num15; num16++)
				{
					zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.TouchData touchData = zwWEPIBfQQjvcFGMdkkFNKDGwfdgA.mbGotkNspciCdWUfwbxMijjJnXsL[num16];
					text10 = string.Concat(new string[]
					{
						text10,
						"Touch ",
						num16.ToString(),
						": Is Touching = ",
						touchData.isTouching.ToString(),
						"\n"
					});
					text10 = string.Concat(new string[]
					{
						text10,
						"Touch ",
						num16.ToString(),
						": Touch Id = ",
						touchData.touchId.ToString(),
						"\n"
					});
					text10 = string.Concat(new string[]
					{
						text10,
						"Touch ",
						num16.ToString(),
						": Position = ",
						touchData.positionX.ToString(),
						", ",
						touchData.positionY.ToString(),
						"\n"
					});
					text10 = string.Concat(new string[]
					{
						text10,
						"Touch ",
						num16.ToString(),
						": Abs Position = ",
						touchData.positionAbsX.ToString(),
						", ",
						touchData.positionAbsY.ToString(),
						" (",
						touchData.positionRawX.ToString(),
						", ",
						touchData.positionRawY.ToString(),
						")\n"
					});
				}
				this.SyPgaCBrFBdDOeHwQMMCiAAWxdIB("Touchpad " + num14.ToString(), text10);
			}
			bool[] array4 = this.xdoNsbhahrKuObEzxadYARKJWRxy.SBIpSMfhMbXHumLUWAoDaLzlfPgb;
			string text11 = "";
			for (int num17 = 0; num17 < array4.Length; num17++)
			{
				if (array4[num17])
				{
					if (text11 != "")
					{
						text11 += ", ";
					}
					text11 += num17.ToString();
				}
			}
			this.wYWykGJOzUxdwlaTfXOGVQhMpTxd("Buttons ", text11);
		}
		this.FRtECKcKLCPlONQgyxuwtVuLIlOb.text = this.EeSXhyUhZytkqevEStUMjtaEflle;
	}

	// Token: 0x06000044 RID: 68 RVA: 0x000114E8 File Offset: 0x0000F6E8
	public void OnDestroy()
	{
		if (this.xdoNsbhahrKuObEzxadYARKJWRxy != null)
		{
			this.xdoNsbhahrKuObEzxadYARKJWRxy.aLGLCNQlAGFbzfFShLCURNjpXQRLA();
		}
	}

	// Token: 0x06000045 RID: 69 RVA: 0x000114FD File Offset: 0x0000F6FD
	private void HikYkHwLJkXhTykIvNkZNyZOktEW()
	{
		this.wzUpbiVFvcDkOqntKorVyRKzITWw = this.zSxVAGnnJtHSiLVQeWKqdqXRIXdL.GetJoysticks<zOVftvsFbTAvLzuhvSRGfBOXFlHHA>();
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00011510 File Offset: 0x0000F710
	private void sHtSYmZcBIiqdFylVvmNMnEdzjlM()
	{
		this.EoGyMVhhTkaBvAzaykNEhFJObMIuA();
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00011510 File Offset: 0x0000F710
	private void jqvFYQcdrchCKkSFDeTQmtGzxwIHA()
	{
		this.EoGyMVhhTkaBvAzaykNEhFJObMIuA();
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00011518 File Offset: 0x0000F718
	private void EoGyMVhhTkaBvAzaykNEhFJObMIuA()
	{
		this.AYjkloKDRurbMGDLQQNkExtPHNdg();
		this.eGkTqCJuINOdHlnxrkeXloejgmSX = true;
	}

	// Token: 0x06000049 RID: 73 RVA: 0x00011527 File Offset: 0x0000F727
	private void AYjkloKDRurbMGDLQQNkExtPHNdg()
	{
		this.ViVgtGKBdONoUWgWSUOQtPlsbtIy = 0;
		this.xdoNsbhahrKuObEzxadYARKJWRxy = null;
		this.vJmxLyxAUwdpongHUdWFSZMFKvAv = Guid.Empty;
		this.wzUpbiVFvcDkOqntKorVyRKzITWw = null;
		this.qBoyIJqeNRWDHjkGspzHASNxPoah = false;
		this.eGkTqCJuINOdHlnxrkeXloejgmSX = false;
	}

	// Token: 0x0600004A RID: 74 RVA: 0x00011557 File Offset: 0x0000F757
	private void wYWykGJOzUxdwlaTfXOGVQhMpTxd(string A_1, object A_2)
	{
		this.EeSXhyUhZytkqevEStUMjtaEflle = string.Concat(new string[]
		{
			this.EeSXhyUhZytkqevEStUMjtaEflle,
			A_1,
			" = ",
			A_2.ToString(),
			"\n"
		});
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00011590 File Offset: 0x0000F790
	private void SyPgaCBrFBdDOeHwQMMCiAAWxdIB(string A_1, object A_2)
	{
		this.EeSXhyUhZytkqevEStUMjtaEflle = string.Concat(new string[]
		{
			this.EeSXhyUhZytkqevEStUMjtaEflle,
			A_1,
			":\n",
			A_2.ToString(),
			"\n"
		});
	}

	// Token: 0x0600004C RID: 76 RVA: 0x000115C9 File Offset: 0x0000F7C9
	private int cIFUbBUjEwMKbNUtnKzEKsHEjxDS(RawInputAxis A_1, int A_2, IPSdCZFUYRXiSCWqVVaWtTkwblCIA A_3)
	{
		return A_3.QjITHNilndtaIBZTPJBvqPhisJty(A_1, A_2);
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00011464 File Offset: 0x0000F664
	private float YMqcmoEXfiwnJhfXSJpZCDacLqkMb(int A_1)
	{
		if (A_1 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(A_1) / 65535f * (float)MathTools.Sign(A_1), -1f, 1f);
	}

	// Token: 0x0400001C RID: 28
	private GUIText FRtECKcKLCPlONQgyxuwtVuLIlOb;

	// Token: 0x0400001D RID: 29
	private string EeSXhyUhZytkqevEStUMjtaEflle;

	// Token: 0x0400001E RID: 30
	private int ViVgtGKBdONoUWgWSUOQtPlsbtIy;

	// Token: 0x0400001F RID: 31
	private wOInxLKDewlatLvQaXlNWuUFKXeD zSxVAGnnJtHSiLVQeWKqdqXRIXdL;

	// Token: 0x04000020 RID: 32
	private zOVftvsFbTAvLzuhvSRGfBOXFlHHA xdoNsbhahrKuObEzxadYARKJWRxy;

	// Token: 0x04000021 RID: 33
	private Guid vJmxLyxAUwdpongHUdWFSZMFKvAv;

	// Token: 0x04000022 RID: 34
	private IList<zOVftvsFbTAvLzuhvSRGfBOXFlHHA> wzUpbiVFvcDkOqntKorVyRKzITWw;

	// Token: 0x04000023 RID: 35
	private bool qBoyIJqeNRWDHjkGspzHASNxPoah;

	// Token: 0x04000024 RID: 36
	private bool eGkTqCJuINOdHlnxrkeXloejgmSX;

	// Token: 0x04000025 RID: 37
	private bool iUtZkQLmCcdFxFScARDvDKxCkSOmb;

	// Token: 0x04000026 RID: 38
	private string[] suguEZWxsRspbewZqkPlGhjBBFTdA;

	// Token: 0x04000027 RID: 39
	private int[] TAXCOIBDOfCUZCSuEPAALMrIfHuQc;
}
