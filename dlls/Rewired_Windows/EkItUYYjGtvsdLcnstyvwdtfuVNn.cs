using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

// Token: 0x02000023 RID: 35
internal class EkItUYYjGtvsdLcnstyvwdtfuVNn : PlatformInputManager, INativePlatformHelper
{
	// Token: 0x0600017B RID: 379 RVA: 0x00026360 File Offset: 0x00024560
	public EkItUYYjGtvsdLcnstyvwdtfuVNn(ConfigVars A_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> A_2, Func<int> A_3)
	{
		try
		{
			this.WTzxbIauNqZUzkugEVaiQQGtBdlH = A_1.windowsStandalonePrimaryInputSource;
			this.VLqXQjIHavtSKIiRbEemiHmmytVS = new Func<PidVid, bool>(EkItUYYjGtvsdLcnstyvwdtfuVNn.hTPosfeoQbeheJFVaOsLjgVCrasoA.<>9.LWuRGlaBpEjWVYDLkhHeHoiHgohI);
			bool flag = UnityTools.platform == Platform.WindowsAppStore || UnityTools.platform == Platform.Windows81Store || UnityTools.platform == Platform.WindowsPhone8;
			bool flag2 = UnityTools.platform == Platform.Windows && (this.WTzxbIauNqZUzkugEVaiQQGtBdlH == WindowsStandalonePrimaryInputSource.DirectInput || this.WTzxbIauNqZUzkugEVaiQQGtBdlH == WindowsStandalonePrimaryInputSource.RawInput);
			BEzoLQEyeVcMuWZsryGeXRQqhkdd bezoLQEyeVcMuWZsryGeXRQqhkdd = BEzoLQEyeVcMuWZsryGeXRQqhkdd.None;
			if (flag2)
			{
				bezoLQEyeVcMuWZsryGeXRQqhkdd = (A_1.GetPlatformVar_useWindowsGamingInput() ? BEzoLQEyeVcMuWZsryGeXRQqhkdd.WindowsGamingInput : (A_1.useXInput ? BEzoLQEyeVcMuWZsryGeXRQqhkdd.XInput : BEzoLQEyeVcMuWZsryGeXRQqhkdd.None));
			}
			bool flag3 = bezoLQEyeVcMuWZsryGeXRQqhkdd == BEzoLQEyeVcMuWZsryGeXRQqhkdd.WindowsGamingInput || bezoLQEyeVcMuWZsryGeXRQqhkdd == BEzoLQEyeVcMuWZsryGeXRQqhkdd.XInput || this.WTzxbIauNqZUzkugEVaiQQGtBdlH == WindowsStandalonePrimaryInputSource.XInput || this.WTzxbIauNqZUzkugEVaiQQGtBdlH == WindowsStandalonePrimaryInputSource.WindowsGamingInput;
			this.wQXmDWBuLSnnZAHtheZynIUDxAgU = A_2;
			this.NgSaZpQXdmmmXMlKYyBPnsPUHKHh = A_3;
			bool flag4 = false;
			this.BcBPhCroxhJqmzAeEcFhpoLmeTAB = new IndexedDictionary<int, PlatformInputManager>();
			PlatformInputManager platformInputManager = null;
			if (UnityTools.platform != Platform.WindowsAppStore)
			{
				try
				{
					jbcfMDoFeBFAQElVePZhKkwUdctNA.mEaapnChteVJwORTrycWUfioKHRfA(flag3);
				}
				catch (Exception ex)
				{
					this.OnDestroy();
					Logger.LogWarning("Unable to initialize input source!\n" + ex.Message);
					throw;
				}
			}
			if (flag2)
			{
				if (bezoLQEyeVcMuWZsryGeXRQqhkdd == BEzoLQEyeVcMuWZsryGeXRQqhkdd.XInput)
				{
					if (this.ALfAqWipiQlYuifUtIatRYbXMiQt(A_1, false, out platformInputManager))
					{
						flag4 = true;
					}
					else
					{
						A_1.useXInput = false;
					}
				}
				else if (bezoLQEyeVcMuWZsryGeXRQqhkdd == BEzoLQEyeVcMuWZsryGeXRQqhkdd.WindowsGamingInput && !this.FUlutyhatrTpuLHKwIAdyFjBHpiC(A_1, false, out platformInputManager))
				{
					A_1.SetPlatformVar_useWindowsGamingInput(false);
					if (A_1.useXInput && !flag4)
					{
						Logger.Log("Attempting to fallback to XInput...");
						if (this.ALfAqWipiQlYuifUtIatRYbXMiQt(A_1, false, out platformInputManager))
						{
							flag4 = true;
							Logger.Log("XInput initialized.");
						}
						else
						{
							A_1.useXInput = false;
						}
					}
				}
			}
			if (flag)
			{
				if (!flag4 && !this.ALfAqWipiQlYuifUtIatRYbXMiQt(A_1, true, out this.vvHsANFGBkCiJNASeMyFcxlfjgGM))
				{
					throw new Exception();
				}
			}
			else if (UnityTools.platform != Platform.WindowsAppStore)
			{
				this.galSFIvAZjRVAIaLMGXnbDOTLokVA = new GiLZwgRrTknVsoaJvlUtgGkudXpu();
				bool flag5 = false;
				if (this.WTzxbIauNqZUzkugEVaiQQGtBdlH == WindowsStandalonePrimaryInputSource.DirectInput)
				{
					flag5 = this.LxwgvvgatpdUuudDwoawskZAkkmLA(A_1, this.galSFIvAZjRVAIaLMGXnbDOTLokVA, platformInputManager as xKKbjmIOHiqxZGRJDfbeyLuvTjMwB);
					if (!flag5)
					{
						Logger.Log("Attempting to fallback to Raw Input...");
						flag5 = this.oonsquLiTFfExASWvROKlaZODckbb(A_1, this.galSFIvAZjRVAIaLMGXnbDOTLokVA, platformInputManager as xKKbjmIOHiqxZGRJDfbeyLuvTjMwB);
						if (flag5)
						{
							A_1.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							this.WTzxbIauNqZUzkugEVaiQQGtBdlH = A_1.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized.");
						}
					}
				}
				else if (this.WTzxbIauNqZUzkugEVaiQQGtBdlH == WindowsStandalonePrimaryInputSource.RawInput)
				{
					flag5 = this.oonsquLiTFfExASWvROKlaZODckbb(A_1, this.galSFIvAZjRVAIaLMGXnbDOTLokVA, platformInputManager as xKKbjmIOHiqxZGRJDfbeyLuvTjMwB);
					if (!flag5)
					{
						Logger.Log("Attempting to fallback to Direct Input...");
						flag5 = this.LxwgvvgatpdUuudDwoawskZAkkmLA(A_1, this.galSFIvAZjRVAIaLMGXnbDOTLokVA, platformInputManager as xKKbjmIOHiqxZGRJDfbeyLuvTjMwB);
						if (flag5)
						{
							A_1.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.DirectInput;
							this.WTzxbIauNqZUzkugEVaiQQGtBdlH = A_1.windowsStandalonePrimaryInputSource;
							Logger.Log("Direct Input initialized.");
						}
					}
				}
				else if (this.WTzxbIauNqZUzkugEVaiQQGtBdlH == WindowsStandalonePrimaryInputSource.XInput)
				{
					A_1.SetPlatformVar_useWindowsGamingInput(false);
					flag5 = this.ALfAqWipiQlYuifUtIatRYbXMiQt(A_1, true, out this.vvHsANFGBkCiJNASeMyFcxlfjgGM);
					flag4 = flag5;
					if (flag5)
					{
						this.PIuSptZKEjDcobxqCrxZJtqArLBq(A_1, this.galSFIvAZjRVAIaLMGXnbDOTLokVA);
					}
					else
					{
						A_1.useXInput = false;
						Logger.Log("Attempting to fallback to Raw Input...");
						flag5 = this.oonsquLiTFfExASWvROKlaZODckbb(A_1, this.galSFIvAZjRVAIaLMGXnbDOTLokVA, null);
						if (flag5)
						{
							A_1.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							this.WTzxbIauNqZUzkugEVaiQQGtBdlH = A_1.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized.");
						}
					}
				}
				else if (this.WTzxbIauNqZUzkugEVaiQQGtBdlH == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
				{
					bool flag6 = true;
					flag5 = this.FUlutyhatrTpuLHKwIAdyFjBHpiC(A_1, true, out this.vvHsANFGBkCiJNASeMyFcxlfjgGM);
					if (!flag5)
					{
						A_1.SetPlatformVar_useWindowsGamingInput(false);
						if (A_1.useXInput && !flag4)
						{
							Logger.Log("Attempting to fallback to XInput...");
							flag5 = this.ALfAqWipiQlYuifUtIatRYbXMiQt(A_1, true, out this.vvHsANFGBkCiJNASeMyFcxlfjgGM);
							flag4 = flag5;
							if (flag5)
							{
								A_1.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.XInput;
								Logger.Log("XInput initialized.");
							}
							else
							{
								A_1.useXInput = false;
							}
						}
						if (!flag5)
						{
							Logger.Log("Attempting to fallback to Raw Input...");
							flag5 = this.oonsquLiTFfExASWvROKlaZODckbb(A_1, this.galSFIvAZjRVAIaLMGXnbDOTLokVA, null);
							if (flag5)
							{
								flag6 = false;
								A_1.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
								this.WTzxbIauNqZUzkugEVaiQQGtBdlH = A_1.windowsStandalonePrimaryInputSource;
								Logger.Log("Raw Input initialized.");
							}
						}
					}
					if (flag5 && flag6)
					{
						this.PIuSptZKEjDcobxqCrxZJtqArLBq(A_1, this.galSFIvAZjRVAIaLMGXnbDOTLokVA);
					}
				}
				if (!flag5)
				{
					throw new Exception();
				}
				this.galSFIvAZjRVAIaLMGXnbDOTLokVA.DtHIAjuXGgkGakbMyrPHWyvYZAUA += this.oklGgiOlEnPowdYpWWHUmjKGsaDY;
				this.galSFIvAZjRVAIaLMGXnbDOTLokVA.LasSBxxLihTfsfmJCksdrCivVJmT += this.UbPwXwDJxNsDYIvWcmWWHpKypZjb;
			}
			if (this.vvHsANFGBkCiJNASeMyFcxlfjgGM == null)
			{
				throw new Exception("No primary input manager could be initialized.");
			}
			this.KrFnzeQYJJDXoBeiCvCBpKUWjkkX = new Action<int, ControllerDataUpdater>(this.UpdateControllerData);
		}
		catch (Exception ex2)
		{
			this.OnDestroy();
			Logger.LogWarning("Unable to initialize input source!\n" + ex2.Message);
			throw;
		}
	}

	// Token: 0x17000035 RID: 53
	// (get) Token: 0x0600017C RID: 380 RVA: 0x00026800 File Offset: 0x00024A00
	bool INativePlatformHelper.isApplicationFocused
	{
		get
		{
			IntPtr value = wLURyKQfpGlmweDJGGSrwwzrDUJFA.kHdMXluFWqNCISYjLawcyAFHcKzW();
			IntPtr intPtr = wLURyKQfpGlmweDJGGSrwwzrDUJFA.NcNUORJAUceCejbICLHRcPTLEkhIb();
			return intPtr != IntPtr.Zero && value == intPtr;
		}
	}

	// Token: 0x0600017D RID: 381 RVA: 0x00026830 File Offset: 0x00024A30
	private bool LxwgvvgatpdUuudDwoawskZAkkmLA(ConfigVars A_1, GiLZwgRrTknVsoaJvlUtgGkudXpu A_2, xKKbjmIOHiqxZGRJDfbeyLuvTjMwB A_3)
	{
		CNVeZFjzzLebAIeziISIZlyPJSYp cnveZFjzzLebAIeziISIZlyPJSYp = null;
		EegVRmhDzKlDwgeYQLLOXmqEZyWQ eegVRmhDzKlDwgeYQLLOXmqEZyWQ = null;
		try
		{
			cnveZFjzzLebAIeziISIZlyPJSYp = new CNVeZFjzzLebAIeziISIZlyPJSYp(A_1, null, null, null, false, A_1.GetPlatformVar_useNativeMouse(), A_1.GetPlatformVar_useNativeKeyboard(), A_1.GetPlatformVar_useEnhancedDeviceSupport());
			eegVRmhDzKlDwgeYQLLOXmqEZyWQ = new EegVRmhDzKlDwgeYQLLOXmqEZyWQ(A_1.updateLoop, A_3, A_2.RxOGhMtPqMvvnWwYxEtfzXikpHlE, this.wQXmDWBuLSnnZAHtheZynIUDxAgU, this.NgSaZpQXdmmmXMlKYyBPnsPUHKHh);
			this.vvHsANFGBkCiJNASeMyFcxlfjgGM = eegVRmhDzKlDwgeYQLLOXmqEZyWQ;
			this.BcBPhCroxhJqmzAeEcFhpoLmeTAB.Add(5, cnveZFjzzLebAIeziISIZlyPJSYp);
			this.BcBPhCroxhJqmzAeEcFhpoLmeTAB.Add(1, this.vvHsANFGBkCiJNASeMyFcxlfjgGM);
			A_2.sOtwcmLmTANWXZwVuhFVxhlbFJikA += cnveZFjzzLebAIeziISIZlyPJSYp.rkMJMQFJvlHAtoNgYhrnfzzhDyOi;
			cnveZFjzzLebAIeziISIZlyPJSYp.DeviceConnectedEvent += this.zuzyFCtcWOILxlhEFMhfBLnCShkm;
			cnveZFjzzLebAIeziISIZlyPJSYp.DeviceDisconnectedEvent += this.vFrYqCFyRGCTQnRaEjZmXJYZLjVj;
			cnveZFjzzLebAIeziISIZlyPJSYp.UpdateControllerInfoEvent += this.IBdCjeBjgTfPglIrLohZiPEGhlwpc;
			eegVRmhDzKlDwgeYQLLOXmqEZyWQ.DeviceConnectedEvent += this.zuzyFCtcWOILxlhEFMhfBLnCShkm;
			eegVRmhDzKlDwgeYQLLOXmqEZyWQ.DeviceDisconnectedEvent += this.vFrYqCFyRGCTQnRaEjZmXJYZLjVj;
			eegVRmhDzKlDwgeYQLLOXmqEZyWQ.UpdateControllerInfoEvent += this.IBdCjeBjgTfPglIrLohZiPEGhlwpc;
			return true;
		}
		catch (Exception)
		{
			if (eegVRmhDzKlDwgeYQLLOXmqEZyWQ != null)
			{
				eegVRmhDzKlDwgeYQLLOXmqEZyWQ.OnDestroy();
			}
			if (cnveZFjzzLebAIeziISIZlyPJSYp != null)
			{
				cnveZFjzzLebAIeziISIZlyPJSYp.OnDestroy();
			}
			Logger.LogWarning("Unable to initialize Direct Input! ");
		}
		return false;
	}

	// Token: 0x0600017E RID: 382 RVA: 0x00026958 File Offset: 0x00024B58
	private bool oonsquLiTFfExASWvROKlaZODckbb(ConfigVars A_1, GiLZwgRrTknVsoaJvlUtgGkudXpu A_2, xKKbjmIOHiqxZGRJDfbeyLuvTjMwB A_3)
	{
		CNVeZFjzzLebAIeziISIZlyPJSYp cnveZFjzzLebAIeziISIZlyPJSYp = null;
		try
		{
			cnveZFjzzLebAIeziISIZlyPJSYp = new CNVeZFjzzLebAIeziISIZlyPJSYp(A_1, A_3, this.wQXmDWBuLSnnZAHtheZynIUDxAgU, this.NgSaZpQXdmmmXMlKYyBPnsPUHKHh, true, A_1.GetPlatformVar_useNativeMouse(), A_1.GetPlatformVar_useNativeKeyboard(), A_1.GetPlatformVar_useEnhancedDeviceSupport());
			this.BcBPhCroxhJqmzAeEcFhpoLmeTAB.Add(5, cnveZFjzzLebAIeziISIZlyPJSYp);
			A_2.sOtwcmLmTANWXZwVuhFVxhlbFJikA += cnveZFjzzLebAIeziISIZlyPJSYp.rkMJMQFJvlHAtoNgYhrnfzzhDyOi;
			this.vvHsANFGBkCiJNASeMyFcxlfjgGM = cnveZFjzzLebAIeziISIZlyPJSYp;
			cnveZFjzzLebAIeziISIZlyPJSYp.DeviceConnectedEvent += this.zuzyFCtcWOILxlhEFMhfBLnCShkm;
			cnveZFjzzLebAIeziISIZlyPJSYp.DeviceDisconnectedEvent += this.vFrYqCFyRGCTQnRaEjZmXJYZLjVj;
			cnveZFjzzLebAIeziISIZlyPJSYp.UpdateControllerInfoEvent += this.IBdCjeBjgTfPglIrLohZiPEGhlwpc;
			return true;
		}
		catch (Exception)
		{
			Logger.LogWarning("Unable to initialize Raw Input! This error can be caused by running Unity sandboxed.");
			if (cnveZFjzzLebAIeziISIZlyPJSYp != null)
			{
				cnveZFjzzLebAIeziISIZlyPJSYp.OnDestroy();
			}
		}
		return false;
	}

	// Token: 0x0600017F RID: 383 RVA: 0x00026A18 File Offset: 0x00024C18
	private bool PIuSptZKEjDcobxqCrxZJtqArLBq(ConfigVars A_1, GiLZwgRrTknVsoaJvlUtgGkudXpu A_2)
	{
		bool platformVar_useNativeMouse = A_1.GetPlatformVar_useNativeMouse();
		bool platformVar_useNativeKeyboard = A_1.GetPlatformVar_useNativeKeyboard();
		if (!platformVar_useNativeMouse && !platformVar_useNativeKeyboard)
		{
			return false;
		}
		CNVeZFjzzLebAIeziISIZlyPJSYp cnveZFjzzLebAIeziISIZlyPJSYp = null;
		bool result;
		try
		{
			cnveZFjzzLebAIeziISIZlyPJSYp = new CNVeZFjzzLebAIeziISIZlyPJSYp(A_1, null, null, null, false, platformVar_useNativeMouse, platformVar_useNativeKeyboard, A_1.GetPlatformVar_useEnhancedDeviceSupport());
			A_2.sOtwcmLmTANWXZwVuhFVxhlbFJikA += cnveZFjzzLebAIeziISIZlyPJSYp.rkMJMQFJvlHAtoNgYhrnfzzhDyOi;
			this.BcBPhCroxhJqmzAeEcFhpoLmeTAB.Add(5, cnveZFjzzLebAIeziISIZlyPJSYp);
			cnveZFjzzLebAIeziISIZlyPJSYp.DeviceConnectedEvent += this.zuzyFCtcWOILxlhEFMhfBLnCShkm;
			cnveZFjzzLebAIeziISIZlyPJSYp.DeviceDisconnectedEvent += this.vFrYqCFyRGCTQnRaEjZmXJYZLjVj;
			cnveZFjzzLebAIeziISIZlyPJSYp.UpdateControllerInfoEvent += this.IBdCjeBjgTfPglIrLohZiPEGhlwpc;
			result = true;
		}
		catch
		{
			Logger.LogWarning("Unable to initialize Raw Input for native mouse handling! Unity mouse input will be used instead.");
			if (cnveZFjzzLebAIeziISIZlyPJSYp != null)
			{
				cnveZFjzzLebAIeziISIZlyPJSYp.OnDestroy();
			}
			cnveZFjzzLebAIeziISIZlyPJSYp = null;
			result = false;
		}
		return result;
	}

	// Token: 0x06000180 RID: 384 RVA: 0x00026AD4 File Offset: 0x00024CD4
	private bool ALfAqWipiQlYuifUtIatRYbXMiQt(ConfigVars A_1, bool A_2, out PlatformInputManager A_3)
	{
		UpdateLoopSetting updateLoop = A_1.updateLoop;
		bool flag = false;
		bool result;
		try
		{
			if (flag)
			{
				EkItUYYjGtvsdLcnstyvwdtfuVNn.YcZzHBDseeYUWyQWHsLYqWcOOTxd ycZzHBDseeYUWyQWHsLYqWcOOTxd = new EkItUYYjGtvsdLcnstyvwdtfuVNn.YcZzHBDseeYUWyQWHsLYqWcOOTxd();
				ycZzHBDseeYUWyQWHsLYqWcOOTxd.lrMXfoFkKpMPWHgSgEVWrlCqbkBeA = 0;
				A_3 = new hSuFwhjVGbqfsiEcUujmPPhLicCV(flag, updateLoop, this.wQXmDWBuLSnnZAHtheZynIUDxAgU, new Func<int>(ycZzHBDseeYUWyQWHsLYqWcOOTxd.GoxlSNGgbwAdQAGJKsHRFNTEsTRh), this.VLqXQjIHavtSKIiRbEemiHmmytVS);
				this.BcBPhCroxhJqmzAeEcFhpoLmeTAB.Add(2, A_3);
			}
			else
			{
				A_3 = new hSuFwhjVGbqfsiEcUujmPPhLicCV(flag, updateLoop, this.wQXmDWBuLSnnZAHtheZynIUDxAgU, this.NgSaZpQXdmmmXMlKYyBPnsPUHKHh, this.VLqXQjIHavtSKIiRbEemiHmmytVS);
				this.BcBPhCroxhJqmzAeEcFhpoLmeTAB.Add(2, A_3);
				A_3.DeviceConnectedEvent += this.zuzyFCtcWOILxlhEFMhfBLnCShkm;
				A_3.DeviceDisconnectedEvent += this.vFrYqCFyRGCTQnRaEjZmXJYZLjVj;
				A_3.UpdateControllerInfoEvent += this.IBdCjeBjgTfPglIrLohZiPEGhlwpc;
			}
			result = true;
		}
		catch
		{
			A_3 = null;
			if (A_2)
			{
				Logger.LogWarning("Unable to initialize XInput!");
			}
			else if (!flag)
			{
				A_1.useXInput = false;
				for (int i = 0; i < this.BcBPhCroxhJqmzAeEcFhpoLmeTAB.Count; i++)
				{
					if (this.BcBPhCroxhJqmzAeEcFhpoLmeTAB[i] != null)
					{
						tzycxhCaFmhznyezTOQRNaGkykDIA tzycxhCaFmhznyezTOQRNaGkykDIA = this.BcBPhCroxhJqmzAeEcFhpoLmeTAB[i] as tzycxhCaFmhznyezTOQRNaGkykDIA;
						if (tzycxhCaFmhznyezTOQRNaGkykDIA != null && tzycxhCaFmhznyezTOQRNaGkykDIA.qbaspVnkVEWcLMRiajjuCAMzxLHi != null && tzycxhCaFmhznyezTOQRNaGkykDIA.qbaspVnkVEWcLMRiajjuCAMzxLHi.FPcmcApMcgfMMcFhtgEUQlTEawosA == BEzoLQEyeVcMuWZsryGeXRQqhkdd.XInput)
						{
							tzycxhCaFmhznyezTOQRNaGkykDIA.qbaspVnkVEWcLMRiajjuCAMzxLHi = null;
						}
					}
				}
				Logger.LogWarning("Unable to initialize XInput! XInput controllers will be handled by " + this.WTzxbIauNqZUzkugEVaiQQGtBdlH.ToString() + " instead. Vibration is not supported and the L/R triggers are treated as a single axis and input cannot be detected when both are pressed simultaneously. ");
			}
			result = false;
		}
		return result;
	}

	// Token: 0x06000181 RID: 385 RVA: 0x00026C54 File Offset: 0x00024E54
	private bool FUlutyhatrTpuLHKwIAdyFjBHpiC(ConfigVars A_1, bool A_2, out PlatformInputManager A_3)
	{
		UpdateLoopSetting updateLoop = A_1.updateLoop;
		if (!A_1.GetPlatformVar_useWindowsGamingInput() && !A_2)
		{
			A_3 = null;
			return false;
		}
		bool result;
		try
		{
			A_3 = new rwgKjrJfRPKcAmogdtLedpDnUifY(A_1, this.wQXmDWBuLSnnZAHtheZynIUDxAgU, this.NgSaZpQXdmmmXMlKYyBPnsPUHKHh, this.VLqXQjIHavtSKIiRbEemiHmmytVS);
			if (A_2)
			{
				this.vvHsANFGBkCiJNASeMyFcxlfjgGM = A_3;
			}
			this.BcBPhCroxhJqmzAeEcFhpoLmeTAB.Add(30, A_3);
			A_3.DeviceConnectedEvent += this.zuzyFCtcWOILxlhEFMhfBLnCShkm;
			A_3.DeviceDisconnectedEvent += this.vFrYqCFyRGCTQnRaEjZmXJYZLjVj;
			A_3.UpdateControllerInfoEvent += this.IBdCjeBjgTfPglIrLohZiPEGhlwpc;
			result = true;
		}
		catch (Exception)
		{
			A_3 = null;
			if (!A_2)
			{
				A_1.SetPlatformVar_useWindowsGamingInput(false);
				for (int i = 0; i < this.BcBPhCroxhJqmzAeEcFhpoLmeTAB.Count; i++)
				{
					if (this.BcBPhCroxhJqmzAeEcFhpoLmeTAB[i] != null)
					{
						tzycxhCaFmhznyezTOQRNaGkykDIA tzycxhCaFmhznyezTOQRNaGkykDIA = this.BcBPhCroxhJqmzAeEcFhpoLmeTAB[i] as tzycxhCaFmhznyezTOQRNaGkykDIA;
						if (tzycxhCaFmhznyezTOQRNaGkykDIA != null && tzycxhCaFmhznyezTOQRNaGkykDIA.qbaspVnkVEWcLMRiajjuCAMzxLHi != null && tzycxhCaFmhznyezTOQRNaGkykDIA.qbaspVnkVEWcLMRiajjuCAMzxLHi.FPcmcApMcgfMMcFhtgEUQlTEawosA == BEzoLQEyeVcMuWZsryGeXRQqhkdd.WindowsGamingInput)
						{
							tzycxhCaFmhznyezTOQRNaGkykDIA.qbaspVnkVEWcLMRiajjuCAMzxLHi = null;
						}
					}
				}
			}
			Logger.LogWarning("Unable to initialize Windows Gaming Input! ");
			result = false;
		}
		return result;
	}

	// Token: 0x17000036 RID: 54
	// (get) Token: 0x06000182 RID: 386 RVA: 0x00011FFB File Offset: 0x000101FB
	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			return this.GDlpYDyTrhovMqiyMFNlEFouQDYz.wVOhCQvSfFGuAgaiyzxbBgUNGpJAA;
		}
	}

	// Token: 0x17000037 RID: 55
	// (get) Token: 0x06000183 RID: 387 RVA: 0x00012008 File Offset: 0x00010208
	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager
	{
		get
		{
			return this.vvHsANFGBkCiJNASeMyFcxlfjgGM;
		}
	}

	// Token: 0x17000038 RID: 56
	// (get) Token: 0x06000184 RID: 388 RVA: 0x00012010 File Offset: 0x00010210
	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource
	{
		get
		{
			return this.vvHsANFGBkCiJNASeMyFcxlfjgGM.inputSource;
		}
	}

	// Token: 0x17000039 RID: 57
	// (get) Token: 0x06000185 RID: 389 RVA: 0x0001201D File Offset: 0x0001021D
	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			if (this.vvHsANFGBkCiJNASeMyFcxlfjgGM == null)
			{
				return InputSource.None;
			}
			return this.vvHsANFGBkCiJNASeMyFcxlfjgGM.inputSourceType;
		}
	}

	// Token: 0x06000186 RID: 390 RVA: 0x00026D70 File Offset: 0x00024F70
	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		this.SIodJkcvPkxFlNSleLdcNRwPwDFxA = true;
		this.GDlpYDyTrhovMqiyMFNlEFouQDYz = new EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF();
		for (int i = 0; i < this.BcBPhCroxhJqmzAeEcFhpoLmeTAB.Count; i++)
		{
			this.BcBPhCroxhJqmzAeEcFhpoLmeTAB[i].Initialize();
		}
	}

	// Token: 0x06000187 RID: 391 RVA: 0x00026DB8 File Offset: 0x00024FB8
	public virtual void htieFxcTWRdSPDfnJpyUNPbSUocub(UpdateLoopType A_1)
	{
		for (int i = 0; i < this.BcBPhCroxhJqmzAeEcFhpoLmeTAB.Count; i++)
		{
			this.BcBPhCroxhJqmzAeEcFhpoLmeTAB[i].Update(A_1);
		}
	}

	// Token: 0x06000188 RID: 392 RVA: 0x00026DF0 File Offset: 0x00024FF0
	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		for (int i = this.BcBPhCroxhJqmzAeEcFhpoLmeTAB.Count - 1; i >= 0; i--)
		{
			this.BcBPhCroxhJqmzAeEcFhpoLmeTAB[i].OnDestroy();
		}
		this.BcBPhCroxhJqmzAeEcFhpoLmeTAB.Clear();
		if (this.galSFIvAZjRVAIaLMGXnbDOTLokVA != null)
		{
			this.galSFIvAZjRVAIaLMGXnbDOTLokVA.VybIdGBKoMVTytiarhJtgXcousySA();
			this.galSFIvAZjRVAIaLMGXnbDOTLokVA = null;
		}
		jbcfMDoFeBFAQElVePZhKkwUdctNA.EivjXMyDJrcuzHrbmimqGXwBZEXgA();
	}

	// Token: 0x06000189 RID: 393 RVA: 0x00012034 File Offset: 0x00010234
	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return this.KrFnzeQYJJDXoBeiCvCBpKUWjkkX;
	}

	// Token: 0x0600018A RID: 394 RVA: 0x0001203C File Offset: 0x0001023C
	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int controllerId, ControllerDataUpdater data)
	{
		this.BcBPhCroxhJqmzAeEcFhpoLmeTAB.GetValue((int)data.source).UpdateControllerData(this.GDlpYDyTrhovMqiyMFNlEFouQDYz.cSbjdivSrFPoAyubPKPzKrznmXDQ(controllerId, data.source, EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi.Connected), data);
	}

	// Token: 0x0600018B RID: 395 RVA: 0x000116E9 File Offset: 0x0000F8E9
	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
	}

	// Token: 0x0600018C RID: 396 RVA: 0x000116E9 File Offset: 0x0000F8E9
	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
	}

	// Token: 0x0600018D RID: 397 RVA: 0x000116E9 File Offset: 0x0000F8E9
	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	// Token: 0x0600018E RID: 398 RVA: 0x00026E50 File Offset: 0x00025050
	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		for (int i = 0; i < this.BcBPhCroxhJqmzAeEcFhpoLmeTAB.Count; i++)
		{
			IUnifiedMouseSource unifiedMouseSource = this.BcBPhCroxhJqmzAeEcFhpoLmeTAB[i].GetUnifiedMouseSource();
			if (unifiedMouseSource != null)
			{
				return unifiedMouseSource;
			}
		}
		return null;
	}

	// Token: 0x0600018F RID: 399 RVA: 0x00026E8C File Offset: 0x0002508C
	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		for (int i = 0; i < this.BcBPhCroxhJqmzAeEcFhpoLmeTAB.Count; i++)
		{
			IUnifiedKeyboardSource unifiedKeyboardSource = this.BcBPhCroxhJqmzAeEcFhpoLmeTAB[i].GetUnifiedKeyboardSource();
			if (unifiedKeyboardSource != null)
			{
				return unifiedKeyboardSource;
			}
		}
		return null;
	}

	// Token: 0x06000190 RID: 400 RVA: 0x00012068 File Offset: 0x00010268
	private void zuzyFCtcWOILxlhEFMhfBLnCShkm(BridgedController A_1)
	{
		if (A_1 == null)
		{
			return;
		}
		this.GDlpYDyTrhovMqiyMFNlEFouQDYz.UdtSrWwBItBhsHcgFkyfaRXhdxNfA(A_1);
		if (this._DeviceConnectedEvent != null)
		{
			this._DeviceConnectedEvent(A_1);
		}
	}

	// Token: 0x06000191 RID: 401 RVA: 0x0001208E File Offset: 0x0001028E
	private void vFrYqCFyRGCTQnRaEjZmXJYZLjVj(ControllerDisconnectedEventArgs A_1)
	{
		if (A_1 == null)
		{
			return;
		}
		this.GDlpYDyTrhovMqiyMFNlEFouQDYz.lXbpHEjERulVNDBIpslQgtWILeSB(A_1);
		if (this._DeviceDisconnectedEvent != null)
		{
			this._DeviceDisconnectedEvent(A_1);
		}
	}

	// Token: 0x06000192 RID: 402 RVA: 0x00026EC8 File Offset: 0x000250C8
	private void oklGgiOlEnPowdYpWWHUmjKGsaDY(EventArgs A_1)
	{
		if (!this.SIodJkcvPkxFlNSleLdcNRwPwDFxA)
		{
			return;
		}
		for (int i = 0; i < this.BcBPhCroxhJqmzAeEcFhpoLmeTAB.Count; i++)
		{
			this.BcBPhCroxhJqmzAeEcFhpoLmeTAB[i].SystemDeviceConnected();
		}
	}

	// Token: 0x06000193 RID: 403 RVA: 0x00026F08 File Offset: 0x00025108
	private void UbPwXwDJxNsDYIvWcmWWHpKypZjb(EventArgs A_1)
	{
		if (!this.SIodJkcvPkxFlNSleLdcNRwPwDFxA)
		{
			return;
		}
		for (int i = 0; i < this.BcBPhCroxhJqmzAeEcFhpoLmeTAB.Count; i++)
		{
			this.BcBPhCroxhJqmzAeEcFhpoLmeTAB[i].SystemDeviceDisconnected();
		}
	}

	// Token: 0x06000194 RID: 404 RVA: 0x00026F48 File Offset: 0x00025148
	private void IBdCjeBjgTfPglIrLohZiPEGhlwpc(UpdateControllerInfoEventArgs A_1)
	{
		if (A_1 == null || A_1.sourceJoystick == null)
		{
			return;
		}
		this.GDlpYDyTrhovMqiyMFNlEFouQDYz.ZzpVmNqIbQSWiMtpseUTJIAOdJMHA(A_1.sourceJoystick.rewiredId, A_1.sourceJoystick.inputManagerId);
		EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi kymBOckckimPenhizuULasQdVDJi = EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi.Connected;
		int num = this.GDlpYDyTrhovMqiyMFNlEFouQDYz.gvrVvmAbVbdDfVdDUZwhJVQhMxav(A_1.sourceJoystick.rewiredId, kymBOckckimPenhizuULasQdVDJi);
		if (num < 0)
		{
			kymBOckckimPenhizuULasQdVDJi = EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi.Disconnected;
			num = this.GDlpYDyTrhovMqiyMFNlEFouQDYz.gvrVvmAbVbdDfVdDUZwhJVQhMxav(A_1.sourceJoystick.rewiredId, kymBOckckimPenhizuULasQdVDJi);
		}
		if (num < 0)
		{
			return;
		}
		EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.XkteADnJnFMqiGgyOEZwyjcOAiGN xkteADnJnFMqiGgyOEZwyjcOAiGN = this.GDlpYDyTrhovMqiyMFNlEFouQDYz.tpoYmbMQZHbLDEoDTPLruuwkdGBz(num, kymBOckckimPenhizuULasQdVDJi);
		if (this._UpdateControllerInfoEvent != null)
		{
			this._UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(new EkItUYYjGtvsdLcnstyvwdtfuVNn.SLbumLisFittmoshBtexcXbXknMu(A_1.sourceJoystick, xkteADnJnFMqiGgyOEZwyjcOAiGN.kaNjpbMOjdMiJZDFMbWpPgyUQWCO)));
		}
	}

	// Token: 0x04000139 RID: 313
	private const bool FRDTmauhuoPFUcsiKcnchJhmFncg = false;

	// Token: 0x0400013A RID: 314
	private const bool XNZMBhBkrmkHIGoPlIRnDYOEzMTt = false;

	// Token: 0x0400013B RID: 315
	private const bool mmIIymVKqomnTpUTWZvEHKpbYtE = false;

	// Token: 0x0400013C RID: 316
	private const bool cvLabWVqehCDPbBbxSlcJHEzpIdcb = false;

	// Token: 0x0400013D RID: 317
	private const bool CfGbONQqOgpcHMbarHWNiIJkobuDA = false;

	// Token: 0x0400013E RID: 318
	private const bool CawVqOboQNMkiQmFybLcVvmKxBfF = false;

	// Token: 0x0400013F RID: 319
	private bool SIodJkcvPkxFlNSleLdcNRwPwDFxA;

	// Token: 0x04000140 RID: 320
	private GiLZwgRrTknVsoaJvlUtgGkudXpu galSFIvAZjRVAIaLMGXnbDOTLokVA;

	// Token: 0x04000141 RID: 321
	private IndexedDictionary<int, PlatformInputManager> BcBPhCroxhJqmzAeEcFhpoLmeTAB;

	// Token: 0x04000142 RID: 322
	private EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF GDlpYDyTrhovMqiyMFNlEFouQDYz;

	// Token: 0x04000143 RID: 323
	private Action<int, ControllerDataUpdater> KrFnzeQYJJDXoBeiCvCBpKUWjkkX;

	// Token: 0x04000144 RID: 324
	private WindowsStandalonePrimaryInputSource WTzxbIauNqZUzkugEVaiQQGtBdlH;

	// Token: 0x04000145 RID: 325
	private PlatformInputManager vvHsANFGBkCiJNASeMyFcxlfjgGM;

	// Token: 0x04000146 RID: 326
	private bool CyZgCAqAIDdhnBgGODZeMGzUtudJA;

	// Token: 0x04000147 RID: 327
	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> wQXmDWBuLSnnZAHtheZynIUDxAgU;

	// Token: 0x04000148 RID: 328
	private Func<int> NgSaZpQXdmmmXMlKYyBPnsPUHKHh;

	// Token: 0x04000149 RID: 329
	private Func<PidVid, bool> VLqXQjIHavtSKIiRbEemiHmmytVS;

	// Token: 0x0400014A RID: 330
	[CustomObfuscation(rename = false)]
	private int counter;

	// Token: 0x02000024 RID: 36
	private class XgKTyFXlusJcoiByyTAPWpBLQQUF
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000195 RID: 405 RVA: 0x000120B4 File Offset: 0x000102B4
		public int wVOhCQvSfFGuAgaiyzxbBgUNGpJAA
		{
			get
			{
				return this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb.Count;
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x000120C1 File Offset: 0x000102C1
		public XgKTyFXlusJcoiByyTAPWpBLQQUF()
		{
			this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb = new List<EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.shsuBCmPilRNZtwjcPwYaaDZgItX>();
			this.UmCYpbqoKTVdAVxOIGyDcbHbbyCF = new List<EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.shsuBCmPilRNZtwjcPwYaaDZgItX>();
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00026FF8 File Offset: 0x000251F8
		public void UdtSrWwBItBhsHcgFkyfaRXhdxNfA(BridgedController A_1)
		{
			if (A_1 == null || A_1.sourceJoystick == null)
			{
				return;
			}
			IInputManagerJoystickPublic sourceJoystick = A_1.sourceJoystick;
			int num = this.gvrVvmAbVbdDfVdDUZwhJVQhMxav(sourceJoystick.rewiredId, EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi.Connected);
			EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.shsuBCmPilRNZtwjcPwYaaDZgItX shsuBCmPilRNZtwjcPwYaaDZgItX;
			if (num >= 0)
			{
				shsuBCmPilRNZtwjcPwYaaDZgItX = this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb[num];
				shsuBCmPilRNZtwjcPwYaaDZgItX.kwlmzQaVGWuSZKmTqRAfQhgpReRU(sourceJoystick.inputManagerId);
				A_1.sourceJoystick = new EkItUYYjGtvsdLcnstyvwdtfuVNn.SLbumLisFittmoshBtexcXbXknMu(sourceJoystick, shsuBCmPilRNZtwjcPwYaaDZgItX.hKYlRdFcLWgawryzMlXgyxeyTEhV);
				return;
			}
			num = this.gvrVvmAbVbdDfVdDUZwhJVQhMxav(sourceJoystick.rewiredId, EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi.Disconnected);
			if (num >= 0)
			{
				shsuBCmPilRNZtwjcPwYaaDZgItX = this.UmCYpbqoKTVdAVxOIGyDcbHbbyCF[num];
				this.UmCYpbqoKTVdAVxOIGyDcbHbbyCF.RemoveAt(num);
				int hKYlRdFcLWgawryzMlXgyxeyTEhV = this.guKDLyaNFMJvhpENvRJEsAnWGywyA(shsuBCmPilRNZtwjcPwYaaDZgItX.hKYlRdFcLWgawryzMlXgyxeyTEhV);
				shsuBCmPilRNZtwjcPwYaaDZgItX.hKYlRdFcLWgawryzMlXgyxeyTEhV = hKYlRdFcLWgawryzMlXgyxeyTEhV;
			}
			else
			{
				shsuBCmPilRNZtwjcPwYaaDZgItX = new EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.shsuBCmPilRNZtwjcPwYaaDZgItX(this.YyQOmiWSPqvWNUMOpeXcLAneqLdK(), sourceJoystick.inputManagerId, sourceJoystick.rewiredId, A_1.inputManagerSource);
			}
			A_1.sourceJoystick = new EkItUYYjGtvsdLcnstyvwdtfuVNn.SLbumLisFittmoshBtexcXbXknMu(sourceJoystick, shsuBCmPilRNZtwjcPwYaaDZgItX.hKYlRdFcLWgawryzMlXgyxeyTEhV);
			this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb.Add(shsuBCmPilRNZtwjcPwYaaDZgItX);
			this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb.Sort(new Comparison<EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.shsuBCmPilRNZtwjcPwYaaDZgItX>(EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.shsuBCmPilRNZtwjcPwYaaDZgItX.OubahxkUKpcHBiRXCpUefBUAaQOtA));
		}

		// Token: 0x06000198 RID: 408 RVA: 0x000270EC File Offset: 0x000252EC
		public void lXbpHEjERulVNDBIpslQgtWILeSB(ControllerDisconnectedEventArgs A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			int num = this.gvrVvmAbVbdDfVdDUZwhJVQhMxav(A_1.rewiredId, EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi.Connected);
			if (num < 0)
			{
				Logger.LogError("Device was not in connected list! Cannot remove!");
				return;
			}
			EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.shsuBCmPilRNZtwjcPwYaaDZgItX item = this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb[num];
			this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb.RemoveAt(num);
			this.UmCYpbqoKTVdAVxOIGyDcbHbbyCF.Add(item);
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00027140 File Offset: 0x00025340
		public void ZzpVmNqIbQSWiMtpseUTJIAOdJMHA(int A_1, int A_2)
		{
			int num = this.gvrVvmAbVbdDfVdDUZwhJVQhMxav(A_1, EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi.Connected);
			if (num >= 0)
			{
				this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb[num].kwlmzQaVGWuSZKmTqRAfQhgpReRU(A_2);
				return;
			}
			num = this.gvrVvmAbVbdDfVdDUZwhJVQhMxav(A_1, EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi.Disconnected);
			if (num >= 0)
			{
				this.UmCYpbqoKTVdAVxOIGyDcbHbbyCF[num].kwlmzQaVGWuSZKmTqRAfQhgpReRU(A_2);
				return;
			}
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000120DF File Offset: 0x000102DF
		public bool rOCpMlnUdDtxppJcuHuxCPWeyPHL(int A_1, EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi A_2)
		{
			return this.gvrVvmAbVbdDfVdDUZwhJVQhMxav(A_1, A_2) >= 0;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00027190 File Offset: 0x00025390
		public int gvrVvmAbVbdDfVdDUZwhJVQhMxav(int A_1, EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi A_2)
		{
			if (A_2 == EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi.Connected)
			{
				int count = this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb.Count;
				for (int i = 0; i < count; i++)
				{
					if (this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb[i].cFSlZnQOKubyWVVofBAjJdfgmjLy == A_1)
					{
						return i;
					}
				}
			}
			else if (A_2 == EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi.Disconnected)
			{
				int count2 = this.UmCYpbqoKTVdAVxOIGyDcbHbbyCF.Count;
				for (int j = 0; j < count2; j++)
				{
					if (this.UmCYpbqoKTVdAVxOIGyDcbHbbyCF[j].cFSlZnQOKubyWVVofBAjJdfgmjLy == A_1)
					{
						return j;
					}
				}
			}
			return -1;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00027204 File Offset: 0x00025404
		public int ClHBIIJyIXsMmppcDurXnjLGmecvA(int A_1, InputSource A_2, EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi A_3)
		{
			if (A_3 == EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi.Connected)
			{
				int count = this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb.Count;
				for (int i = 0; i < count; i++)
				{
					if (this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb[i].hKYlRdFcLWgawryzMlXgyxeyTEhV == A_1 && this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb[i].ZlcwOHBiWCRQyGOwhSMCcOWJaDod == A_2)
					{
						return i;
					}
				}
			}
			else if (A_3 == EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi.Disconnected)
			{
				int count2 = this.UmCYpbqoKTVdAVxOIGyDcbHbbyCF.Count;
				for (int j = 0; j < count2; j++)
				{
					if (this.UmCYpbqoKTVdAVxOIGyDcbHbbyCF[j].hKYlRdFcLWgawryzMlXgyxeyTEhV == A_1 && this.UmCYpbqoKTVdAVxOIGyDcbHbbyCF[j].ZlcwOHBiWCRQyGOwhSMCcOWJaDod == A_2)
					{
						return j;
					}
				}
			}
			return -1;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x000272A0 File Offset: 0x000254A0
		public EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.XkteADnJnFMqiGgyOEZwyjcOAiGN tpoYmbMQZHbLDEoDTPLruuwkdGBz(int A_1, EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi A_2)
		{
			if (A_2 == EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi.Connected)
			{
				if (A_1 < 0 || A_1 >= this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				return this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb[A_1].lVBdhoGzAfqheaJbcMeUMwBTgvHDA();
			}
			else
			{
				if (A_1 < 0 || A_1 >= this.UmCYpbqoKTVdAVxOIGyDcbHbbyCF.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				return this.UmCYpbqoKTVdAVxOIGyDcbHbbyCF[A_1].lVBdhoGzAfqheaJbcMeUMwBTgvHDA();
			}
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00027304 File Offset: 0x00025504
		public int cSbjdivSrFPoAyubPKPzKrznmXDQ(int A_1, InputSource A_2, EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi A_3)
		{
			int num = this.ClHBIIJyIXsMmppcDurXnjLGmecvA(A_1, A_2, A_3);
			if (num < 0)
			{
				return -1;
			}
			if (A_3 == EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi.Connected)
			{
				return this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb[num].XExWQLgsVYORDiUbmrDFtWrTBqdw;
			}
			if (A_3 == EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.KymBOckckimPenhizuULasQdVDJi.Disconnected)
			{
				return this.UmCYpbqoKTVdAVxOIGyDcbHbbyCF[num].XExWQLgsVYORDiUbmrDFtWrTBqdw;
			}
			return -1;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00027350 File Offset: 0x00025550
		private int guKDLyaNFMJvhpENvRJEsAnWGywyA(int A_1)
		{
			int count = this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb[i].hKYlRdFcLWgawryzMlXgyxeyTEhV == A_1)
				{
					return this.YyQOmiWSPqvWNUMOpeXcLAneqLdK();
				}
			}
			return A_1;
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00027394 File Offset: 0x00025594
		private int YyQOmiWSPqvWNUMOpeXcLAneqLdK()
		{
			int count = this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb.Count;
			int num = 0;
			for (;;)
			{
				bool flag = false;
				for (int i = 0; i < count; i++)
				{
					if (this.eRoabxAkOsKCmEOyQEXNUTCPRcOcb[i].hKYlRdFcLWgawryzMlXgyxeyTEhV == num)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
				num++;
			}
			return num;
		}

		// Token: 0x0400014B RID: 331
		private List<EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.shsuBCmPilRNZtwjcPwYaaDZgItX> UmCYpbqoKTVdAVxOIGyDcbHbbyCF;

		// Token: 0x0400014C RID: 332
		private List<EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.shsuBCmPilRNZtwjcPwYaaDZgItX> eRoabxAkOsKCmEOyQEXNUTCPRcOcb;

		// Token: 0x02000025 RID: 37
		private class shsuBCmPilRNZtwjcPwYaaDZgItX
		{
			// Token: 0x060001A1 RID: 417 RVA: 0x000120EF File Offset: 0x000102EF
			public shsuBCmPilRNZtwjcPwYaaDZgItX(int A_1, int A_2, int A_3, InputSource A_4)
			{
				this.hKYlRdFcLWgawryzMlXgyxeyTEhV = A_1;
				this.XExWQLgsVYORDiUbmrDFtWrTBqdw = A_2;
				this.cFSlZnQOKubyWVVofBAjJdfgmjLy = A_3;
				this.ZlcwOHBiWCRQyGOwhSMCcOWJaDod = A_4;
			}

			// Token: 0x060001A2 RID: 418 RVA: 0x00012114 File Offset: 0x00010314
			public void kwlmzQaVGWuSZKmTqRAfQhgpReRU(int A_1)
			{
				this.XExWQLgsVYORDiUbmrDFtWrTBqdw = A_1;
			}

			// Token: 0x060001A3 RID: 419 RVA: 0x0001211D File Offset: 0x0001031D
			public EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.XkteADnJnFMqiGgyOEZwyjcOAiGN lVBdhoGzAfqheaJbcMeUMwBTgvHDA()
			{
				return new EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.XkteADnJnFMqiGgyOEZwyjcOAiGN(this.hKYlRdFcLWgawryzMlXgyxeyTEhV, this.XExWQLgsVYORDiUbmrDFtWrTBqdw, this.ZlcwOHBiWCRQyGOwhSMCcOWJaDod);
			}

			// Token: 0x060001A4 RID: 420 RVA: 0x00012136 File Offset: 0x00010336
			public static int OubahxkUKpcHBiRXCpUefBUAaQOtA(EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.shsuBCmPilRNZtwjcPwYaaDZgItX A_0, EkItUYYjGtvsdLcnstyvwdtfuVNn.XgKTyFXlusJcoiByyTAPWpBLQQUF.shsuBCmPilRNZtwjcPwYaaDZgItX A_1)
			{
				if (A_0.hKYlRdFcLWgawryzMlXgyxeyTEhV < A_1.hKYlRdFcLWgawryzMlXgyxeyTEhV)
				{
					return -1;
				}
				if (A_0.hKYlRdFcLWgawryzMlXgyxeyTEhV > A_1.hKYlRdFcLWgawryzMlXgyxeyTEhV)
				{
					return 1;
				}
				return 0;
			}

			// Token: 0x0400014D RID: 333
			public int hKYlRdFcLWgawryzMlXgyxeyTEhV;

			// Token: 0x0400014E RID: 334
			public int XExWQLgsVYORDiUbmrDFtWrTBqdw;

			// Token: 0x0400014F RID: 335
			public int cFSlZnQOKubyWVVofBAjJdfgmjLy;

			// Token: 0x04000150 RID: 336
			public InputSource ZlcwOHBiWCRQyGOwhSMCcOWJaDod;
		}

		// Token: 0x02000026 RID: 38
		public struct XkteADnJnFMqiGgyOEZwyjcOAiGN
		{
			// Token: 0x060001A5 RID: 421 RVA: 0x00012159 File Offset: 0x00010359
			public XkteADnJnFMqiGgyOEZwyjcOAiGN(int A_1, int A_2, InputSource A_3)
			{
				this.kaNjpbMOjdMiJZDFMbWpPgyUQWCO = A_1;
				this.uTeqJCLYjiaEdXTwShHpRTNhlbpI = A_2;
				this.xoTubdAgDKcoFPmbwIQopFENcVRAA = A_3;
			}

			// Token: 0x04000151 RID: 337
			public int kaNjpbMOjdMiJZDFMbWpPgyUQWCO;

			// Token: 0x04000152 RID: 338
			public int uTeqJCLYjiaEdXTwShHpRTNhlbpI;

			// Token: 0x04000153 RID: 339
			public InputSource xoTubdAgDKcoFPmbwIQopFENcVRAA;
		}

		// Token: 0x02000027 RID: 39
		public enum KymBOckckimPenhizuULasQdVDJi
		{
			// Token: 0x04000155 RID: 341
			Connected,
			// Token: 0x04000156 RID: 342
			Disconnected
		}
	}

	// Token: 0x02000028 RID: 40
	private class SLbumLisFittmoshBtexcXbXknMu : IInputManagerJoystickPublic, ITryGetLocalizedName
	{
		// Token: 0x060001A6 RID: 422 RVA: 0x00012170 File Offset: 0x00010370
		public SLbumLisFittmoshBtexcXbXknMu(IInputManagerJoystickPublic A_1, int A_2)
		{
			this.HBVxuDaCxrtnBsJtnKcZTpyNfFzw = A_1;
			this.VlZTGAAWaxnkpCdEnhfVXoFVQZPl = A_2;
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x00012186 File Offset: 0x00010386
		public int rewiredId
		{
			get
			{
				return this.HBVxuDaCxrtnBsJtnKcZTpyNfFzw.rewiredId;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x00012193 File Offset: 0x00010393
		public int inputManagerId
		{
			get
			{
				return this.VlZTGAAWaxnkpCdEnhfVXoFVQZPl;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x0001219B File Offset: 0x0001039B
		public string name
		{
			get
			{
				return this.HBVxuDaCxrtnBsJtnKcZTpyNfFzw.name;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060001AA RID: 426 RVA: 0x000121A8 File Offset: 0x000103A8
		public long? systemId
		{
			get
			{
				return this.HBVxuDaCxrtnBsJtnKcZTpyNfFzw.systemId;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060001AB RID: 427 RVA: 0x000121B5 File Offset: 0x000103B5
		public int unityId
		{
			get
			{
				return this.HBVxuDaCxrtnBsJtnKcZTpyNfFzw.unityId;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060001AC RID: 428 RVA: 0x000121C2 File Offset: 0x000103C2
		public Guid instanceGuid
		{
			get
			{
				return this.HBVxuDaCxrtnBsJtnKcZTpyNfFzw.instanceGuid;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060001AD RID: 429 RVA: 0x000121CF File Offset: 0x000103CF
		public Guid persistentGuid
		{
			get
			{
				return this.instanceGuid;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060001AE RID: 430 RVA: 0x000121D7 File Offset: 0x000103D7
		public Controller.Extension extension
		{
			get
			{
				return this.HBVxuDaCxrtnBsJtnKcZTpyNfFzw.extension;
			}
		}

		// Token: 0x060001AF RID: 431 RVA: 0x000121E4 File Offset: 0x000103E4
		public void SetVibration(float amount, int motorIndex)
		{
			this.HBVxuDaCxrtnBsJtnKcZTpyNfFzw.SetVibration(amount, motorIndex);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x000121F3 File Offset: 0x000103F3
		public void StopVibration()
		{
			this.HBVxuDaCxrtnBsJtnKcZTpyNfFzw.StopVibration();
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x000273E0 File Offset: 0x000255E0
		bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
		{
			ITryGetLocalizedName tryGetLocalizedName = this.HBVxuDaCxrtnBsJtnKcZTpyNfFzw as ITryGetLocalizedName;
			if (tryGetLocalizedName != null)
			{
				return tryGetLocalizedName.TryGetLocalizedName(out value);
			}
			value = null;
			return false;
		}

		// Token: 0x04000157 RID: 343
		private IInputManagerJoystickPublic HBVxuDaCxrtnBsJtnKcZTpyNfFzw;

		// Token: 0x04000158 RID: 344
		private int VlZTGAAWaxnkpCdEnhfVXoFVQZPl;
	}

	// Token: 0x02000029 RID: 41
	[CompilerGenerated]
	[Serializable]
	private sealed class hTPosfeoQbeheJFVaOsLjgVCrasoA
	{
		// Token: 0x060001B4 RID: 436 RVA: 0x00011826 File Offset: 0x0000FA26
		internal bool LWuRGlaBpEjWVYDLkhHeHoiHgohI(PidVid A_1)
		{
			return false;
		}

		// Token: 0x04000159 RID: 345
		public static readonly EkItUYYjGtvsdLcnstyvwdtfuVNn.hTPosfeoQbeheJFVaOsLjgVCrasoA <>9 = new EkItUYYjGtvsdLcnstyvwdtfuVNn.hTPosfeoQbeheJFVaOsLjgVCrasoA();

		// Token: 0x0400015A RID: 346
		public static Func<PidVid, bool> <>9__17_0;
	}

	// Token: 0x0200002A RID: 42
	[CompilerGenerated]
	private sealed class YcZzHBDseeYUWyQWHsLYqWcOOTxd
	{
		// Token: 0x060001B6 RID: 438 RVA: 0x00027408 File Offset: 0x00025608
		internal int GoxlSNGgbwAdQAGJKsHRFNTEsTRh()
		{
			int num = this.lrMXfoFkKpMPWHgSgEVWrlCqbkBeA;
			this.lrMXfoFkKpMPWHgSgEVWrlCqbkBeA = num + 1;
			return num;
		}

		// Token: 0x0400015B RID: 347
		public int lrMXfoFkKpMPWHgSgEVWrlCqbkBeA;
	}
}
