using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	// Token: 0x0200053F RID: 1343
	public class DebugInformation : MonoBehaviour
	{
		// Token: 0x06003672 RID: 13938 RVA: 0x0002A7C2 File Offset: 0x000289C2
		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			DebugInformation.jwqxRtOeZhsVrcxAJWrRTTtJvGGj = this;
			if (this.XRuFaBZtMlFxqptKMhprjQQFlBvLA.Count == 0)
			{
				this.XRuFaBZtMlFxqptKMhprjQQFlBvLA.Add("Rewired_DebugInformation", true);
			}
		}

		// Token: 0x06003673 RID: 13939 RVA: 0x0002A7E8 File Offset: 0x000289E8
		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			if (DebugInformation.jwqxRtOeZhsVrcxAJWrRTTtJvGGj == this)
			{
				DebugInformation.jwqxRtOeZhsVrcxAJWrRTTtJvGGj = null;
			}
		}

		// Token: 0x06003674 RID: 13940 RVA: 0x000B673C File Offset: 0x000B493C
		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			DebugInformation.beAacLiBZQWtHnEMzJSQcqAdrSHZ.tkyooRNZAbDPfvYaGavZcPUOJOSX = 0;
			GUILayout.BeginArea(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height));
			DebugInformation.yRkzUKdfbWoYxYMfpsdhVtzqRyng = GUILayout.BeginScrollView(DebugInformation.yRkzUKdfbWoYxYMfpsdhVtzqRyng, new GUILayoutOption[]
			{
				GUILayout.ExpandWidth(true),
				GUILayout.ExpandHeight(true)
			});
			DebugInformation.DrawDebugInformation(true, this.XRuFaBZtMlFxqptKMhprjQQFlBvLA);
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}

		// Token: 0x06003675 RID: 13941 RVA: 0x000B67AC File Offset: 0x000B49AC
		public static void DrawDebugInformation(bool enabled, IDictionary<string, bool> foldouts)
		{
			bool enabled2 = GUI.enabled;
			if (!ReInput.isReady || !enabled)
			{
				GUI.enabled = false;
			}
			DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.iigUBaLuGrxlBDlMlNOqsPcCVZFI();
			GUILayout.FlexibleSpace();
			DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.ZytwEwGSyCWRytvAQKdEjYwkzEfC();
			Rect lastRect = GUILayoutUtility.GetLastRect();
			float num = lastRect.width / 3f;
			DebugInformation.YYuhvLpvQHhUNiZlOEzmdPAtBjkn.HcGdRfxHVBJLCrPCrjNOKdNYgByCA = lastRect.width - num;
			DebugInformation.YYuhvLpvQHhUNiZlOEzmdPAtBjkn.yRqmUDpuuWQuhNhRRRELYXCySBhD = num;
			DebugInformation.zxZdStdjQwwDTuqYnhKeZxtLcTzAb(enabled, foldouts);
			GUI.enabled = enabled2;
			DebugInformation.YYuhvLpvQHhUNiZlOEzmdPAtBjkn.HcGdRfxHVBJLCrPCrjNOKdNYgByCA = 0f;
			DebugInformation.YYuhvLpvQHhUNiZlOEzmdPAtBjkn.yRqmUDpuuWQuhNhRRRELYXCySBhD = 0f;
		}

		// Token: 0x06003676 RID: 13942 RVA: 0x000B6828 File Offset: 0x000B4A28
		private static void zxZdStdjQwwDTuqYnhKeZxtLcTzAb(bool A_0, IDictionary<string, bool> A_1)
		{
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Rewired Debug Information", "Rewired_DebugInformation", A_1))
			{
				if (!ReInput.isReady || !A_0)
				{
					GUILayout.Label("There is no active Rewired Input Manager in the scene.", Array.Empty<GUILayoutOption>());
				}
				else if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					DebugInformation.HazmzBhUNxkuKUppRipJXfQmUgmE(A_1, "Rewired_DebugInformation");
					bool flag = ReInput.configuration.disableNativeInput;
					if (!flag && (ReInput.currentPlatform == Platform.Windows || ReInput.currentPlatform == Platform.OSX) && ReInput.primaryInputManager.inputSourceType == InputSource.Fallback)
					{
						flag = true;
					}
					if (flag)
					{
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.bKWEfHfQBbutELGoEUOnItRAOLUdb("Native input is disabled. Many special features are unavailable without native input.", DebugInformation.mciVNfkSlHfQPCucefKSOzpMWJRm.Warning);
					}
					DebugInformation.qWRvqIkVZpIQJblBDHYHEiDpinRAb(A_1, "Rewired_DebugInformation");
					string text = "Rewired_DebugInformation_controllers";
					using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS2 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Controllers", text, A_1))
					{
						if (jBFOEFkAeQEazsKHaJXsORemHpTS2.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
						{
							DebugInformation.VTLgJwgxGuJgLKdFMtZnomwdIMpE(ReInput.controllers.Joysticks, A_1, text);
							DebugInformation.PWPVTJeSqMUqLqexpnAhbgPGSakD(ReInput.controllers.CustomControllers, A_1, text);
							DebugInformation.HjPXBSogdXlRpFFwbvoIgMAMFJqD(A_1, "Rewired_DebugInformation");
							DebugInformation.kavbLZOsExMiXcfoMDmWRddqXKoK(A_1, "Rewired_DebugInformation");
						}
					}
				}
			}
		}

		// Token: 0x06003677 RID: 13943 RVA: 0x000B6948 File Offset: 0x000B4B48
		private static void HazmzBhUNxkuKUppRipJXfQmUgmE(IDictionary<string, bool> A_0, string A_1)
		{
			string text = A_1 + "_info";
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Info", text, A_0))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Rewired Version", ReInput.programVersion);
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Platform", ReInput.currentPlatform.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Primary Input Source", ReInput.primaryInputManager.inputSourceType.ToString());
					if (ReInput.currentPlatform == Platform.Windows)
					{
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Use Windows Gaming Input", ReInput.configuration.useWindowsGamingInput.ToString());
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Use XInput", ReInput.configuration.useXInput.ToString());
					}
					else if (ReInput.currentPlatform == Platform.WindowsUWP)
					{
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Support HID Devices", ReInput.configuration.windowsUWPSupportHIDDevices.ToString());
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Support Gamepads", ReInput.configuration.windowsUWPSupportGamepads.ToString());
					}
					else if (ReInput.currentPlatform == Platform.OSX)
					{
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Use Game Controller Framework", ReInput.configuration.useAppleGameControllerFramework.ToString());
					}
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Enhanced Device Support", ReInput.configuration.enhancedDeviceSupport.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Native Keyboard Handling", ReInput.configuration.nativeKeyboardSupport.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Physical Key Mapping", ReInput.configVars.unityUsePhysicalKeys.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Native Mouse Handling", ReInput.configuration.nativeMouseSupport.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Ignore Input When App Not in Focus", ReInput.configuration.ignoreInputWhenAppNotInFocus.ToString());
				}
			}
		}

		// Token: 0x06003678 RID: 13944 RVA: 0x000B6B2C File Offset: 0x000B4D2C
		private static void qWRvqIkVZpIQJblBDHYHEiDpinRAb(IDictionary<string, bool> A_0, string A_1)
		{
			string text = A_1 + "_players";
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Players (" + ReInput.players.allPlayerCount.ToString() + ")", text, A_0))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					int playerCount = ReInput.players.playerCount;
					for (int i = 0; i < playerCount; i++)
					{
						DebugInformation.IopwgEYlscAclHgjxetcbGsOdkJz(ReInput.players.GetPlayer(i), i, A_0, text);
					}
					DebugInformation.IopwgEYlscAclHgjxetcbGsOdkJz(ReInput.players.SystemPlayer, -1, A_0, text);
				}
			}
		}

		// Token: 0x06003679 RID: 13945 RVA: 0x000B6BD4 File Offset: 0x000B4DD4
		private static void VTLgJwgxGuJgLKdFMtZnomwdIMpE(IList<Joystick> A_0, IDictionary<string, bool> A_1, string A_2)
		{
			int num = (A_0 != null) ? A_0.Count : 0;
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Joysticks (" + num.ToString() + ")", A_2 + "_joysticks", A_1))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					for (int i = 0; i < num; i++)
					{
						Joystick joystick = A_0[i];
						string text = A_2 + "_joystick" + joystick.id.ToString();
						using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS2 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(i.ToString() + ": " + ((joystick.name == "Unknown Controller") ? joystick.hardwareName : joystick.name), text, A_1))
						{
							if (jBFOEFkAeQEazsKHaJXsORemHpTS2.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
							{
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Id (unique id)", joystick.id.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Name", joystick.name);
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Hardware Name", joystick.hardwareName);
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Is Recognized", (joystick.hardwareTypeGuid != Guid.Empty).ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Enabled", joystick.enabled.ToString());
								string text2 = string.Empty;
								for (int j = 0; j < ReInput.players.allPlayerCount; j++)
								{
									Player player = ReInput.players.AllPlayers[j];
									if (ReInput.controllers.IsJoystickAssignedToPlayer(joystick.id, player.id))
									{
										if (text2 != string.Empty)
										{
											text2 += ", ";
										}
										text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
									}
								}
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("System Id", joystick.systemId.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Unity Id", ReInput.usingUnityInput ? joystick.unityId.ToString() : "--");
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Hardware Type Guid", joystick.hardwareTypeGuid.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Hardware Identifier", joystick.hardwareIdentifier);
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Device Instance Guid", joystick.deviceInstanceGuid.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Tag", joystick.tag);
								DebugInformation.FixGSLzFHUgxDNPLNdhZihNPSvxE(joystick.Axes, A_1, text);
								DebugInformation.EuQUhCCzNsAltmbYTWJTBqkrBPJi(joystick.Buttons, ControllerType.Joystick, A_1, text);
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Axis2D Count", joystick.axis2DCount.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Hat Count", joystick.hatCount.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("D-Pad Count", joystick.directionalPadCount.ToString());
								DebugInformation.HnkcZzBcdEDfYauMLqliDKPkawMmA(joystick, A_1, text);
								CalibrationMap calibrationMap = joystick.calibrationMap;
								using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS3 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Calibration Map", text + "_calibrationMap", A_1))
								{
									if (jBFOEFkAeQEazsKHaJXsORemHpTS3.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
									{
										int axisCount = calibrationMap.axisCount;
										for (int k = 0; k < axisCount; k++)
										{
											AxisCalibration axisCalibration = calibrationMap.Axes[k];
											using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS4 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(k.ToString() + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + k.ToString(), A_1))
											{
												if (jBFOEFkAeQEazsKHaJXsORemHpTS4.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
												{
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Enabled", axisCalibration.enabled.ToString());
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Calibrated Max", axisCalibration.calibratedMax.ToString());
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Calibrated Min", axisCalibration.calibratedMin.ToString());
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Calibrated Zero", axisCalibration.calibratedZero.ToString());
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Dead Zone", axisCalibration.deadZone.ToString());
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Invert", axisCalibration.invert.ToString());
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Sensitivity Type", axisCalibration.sensitivityType.ToString());
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Sensitivity", axisCalibration.sensitivity.ToString());
													if (axisCalibration.sensitivityCurve != null)
													{
														bool enabled = GUI.enabled;
														GUI.enabled = false;
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.bIwqYhvSmeHtsITuLfqLQxdmtaeE("Sensitivity Curve", axisCalibration.sensitivityCurve);
														GUI.enabled = enabled;
													}
													else
													{
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Sensitivity Curve", "--");
													}
												}
											}
										}
									}
								}
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Supports Vibration", joystick.supportsVibration.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Vibration Motor Count", joystick.vibrationMotorCount.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Has Extension", (joystick.extension != null).ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Extension Type", (joystick.extension != null) ? joystick.extension.GetType().Name : "--");
								DebugInformation.terQaPIlHxDfXUYyqddqEXHQrKQV(joystick, A_1, text);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600367A RID: 13946 RVA: 0x000B71D8 File Offset: 0x000B53D8
		private static void HjPXBSogdXlRpFFwbvoIgMAMFJqD(IDictionary<string, bool> A_0, string A_1)
		{
			string text = A_1 + "_mouse";
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Mouse", text, A_0))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					Mouse mouse = ReInput.controllers.Mouse;
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Enabled", mouse.enabled.ToString());
					string text2 = string.Empty;
					for (int i = 0; i < ReInput.players.allPlayerCount; i++)
					{
						Player player = ReInput.players.AllPlayers[i];
						if (player.controllers.hasMouse)
						{
							if (text2 != string.Empty)
							{
								text2 += ", ";
							}
							text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
						}
					}
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Screen Position", mouse.screenPosition.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Screen Position Prev", mouse.screenPositionPrev.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Screen Position Delta", mouse.screenPositionDelta.ToString());
					DebugInformation.FixGSLzFHUgxDNPLNdhZihNPSvxE(mouse.Axes, A_0, text);
					DebugInformation.EuQUhCCzNsAltmbYTWJTBqkrBPJi(mouse.Buttons, ControllerType.Mouse, A_0, text);
					DebugInformation.HnkcZzBcdEDfYauMLqliDKPkawMmA(mouse, A_0, text);
					DebugInformation.terQaPIlHxDfXUYyqddqEXHQrKQV(mouse, A_0, text);
				}
			}
		}

		// Token: 0x0600367B RID: 13947 RVA: 0x000B7380 File Offset: 0x000B5580
		private static void kavbLZOsExMiXcfoMDmWRddqXKoK(IDictionary<string, bool> A_0, string A_1)
		{
			string text = A_1 + "_keyboard";
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Keyboard", text, A_0))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					Keyboard keyboard = ReInput.controllers.Keyboard;
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Enabled", keyboard.enabled.ToString());
					string text2 = string.Empty;
					for (int i = 0; i < ReInput.players.allPlayerCount; i++)
					{
						Player player = ReInput.players.AllPlayers[i];
						if (player.controllers.hasKeyboard)
						{
							if (text2 != string.Empty)
							{
								text2 += ", ";
							}
							text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
						}
					}
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
					DebugInformation.EuQUhCCzNsAltmbYTWJTBqkrBPJi(keyboard.Buttons, ControllerType.Keyboard, A_0, text);
					DebugInformation.HnkcZzBcdEDfYauMLqliDKPkawMmA(keyboard, A_0, text);
					DebugInformation.terQaPIlHxDfXUYyqddqEXHQrKQV(keyboard, A_0, text);
				}
			}
		}

		// Token: 0x0600367C RID: 13948 RVA: 0x000B74B0 File Offset: 0x000B56B0
		private static void PWPVTJeSqMUqLqexpnAhbgPGSakD(IList<CustomController> A_0, IDictionary<string, bool> A_1, string A_2)
		{
			int num = (A_0 != null) ? A_0.Count : 0;
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Custom Controllers (" + num.ToString() + ")", A_2 + "_customControllers", A_1))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					for (int i = 0; i < num; i++)
					{
						CustomController customController = A_0[i];
						string text = A_2 + "_customController" + customController.id.ToString();
						using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS2 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(i.ToString() + ": " + customController.name, text, A_1))
						{
							if (jBFOEFkAeQEazsKHaJXsORemHpTS2.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
							{
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Id", customController.id.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Name", customController.name);
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Hardware Name", customController.hardwareName);
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Tag", customController.tag);
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Hardware Identifier", customController.hardwareIdentifier);
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Enabled", customController.enabled.ToString());
								string text2 = string.Empty;
								for (int j = 0; j < ReInput.players.allPlayerCount; j++)
								{
									Player player = ReInput.players.AllPlayers[j];
									if (ReInput.controllers.IsCustomControllerAssignedToPlayer(customController.id, player.id))
									{
										if (text2 != string.Empty)
										{
											text2 += ", ";
										}
										text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
									}
								}
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
								DebugInformation.FixGSLzFHUgxDNPLNdhZihNPSvxE(customController.Axes, A_1, text);
								DebugInformation.EuQUhCCzNsAltmbYTWJTBqkrBPJi(customController.Buttons, ControllerType.Custom, A_1, text);
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Axis2D Count", customController.axis2DCount.ToString());
								using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS3 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Element Identifiers", text + "_elementIdentifiers", A_1))
								{
									if (jBFOEFkAeQEazsKHaJXsORemHpTS3.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
									{
										int num2 = (customController.AxisElementIdentifiers != null) ? customController.AxisElementIdentifiers.Count : 0;
										using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS4 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Axis Element Identifiers (" + num2.ToString() + ")", text + "_axisEIs", A_1))
										{
											if (jBFOEFkAeQEazsKHaJXsORemHpTS4.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
											{
												for (int k = 0; k < num2; k++)
												{
													ControllerElementIdentifier controllerElementIdentifier = customController.AxisElementIdentifiers[k];
													using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS5 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(string.Concat(new string[]
													{
														k.ToString(),
														": ",
														controllerElementIdentifier.name,
														" (id: ",
														controllerElementIdentifier.id.ToString(),
														")"
													}), string.Concat(new string[]
													{
														text,
														"_AxisEI",
														k.ToString(),
														"_",
														controllerElementIdentifier.name
													}), A_1))
													{
														if (jBFOEFkAeQEazsKHaJXsORemHpTS5.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
														{
															DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Id", controllerElementIdentifier.id.ToString());
															DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Name", controllerElementIdentifier.name);
														}
													}
												}
											}
										}
										num2 = ((customController.ButtonElementIdentifiers != null) ? customController.ButtonElementIdentifiers.Count : 0);
										using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS6 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Button Element Identifiers (" + num2.ToString() + ")", text + "_buttonEIs", A_1))
										{
											if (jBFOEFkAeQEazsKHaJXsORemHpTS6.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
											{
												for (int l = 0; l < num2; l++)
												{
													ControllerElementIdentifier controllerElementIdentifier2 = customController.ButtonElementIdentifiers[l];
													using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS7 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(string.Concat(new string[]
													{
														l.ToString(),
														": ",
														controllerElementIdentifier2.name,
														" (id: ",
														controllerElementIdentifier2.id.ToString(),
														")"
													}), string.Concat(new string[]
													{
														text,
														"_ButtonEI",
														l.ToString(),
														"_",
														controllerElementIdentifier2.name
													}), A_1))
													{
														if (jBFOEFkAeQEazsKHaJXsORemHpTS7.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
														{
															DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Id", controllerElementIdentifier2.id.ToString());
															DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Name", controllerElementIdentifier2.name);
														}
													}
												}
											}
										}
									}
								}
								CalibrationMap calibrationMap = customController.calibrationMap;
								using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS8 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Calibration Map", text + "_calibrationMap", A_1))
								{
									if (jBFOEFkAeQEazsKHaJXsORemHpTS8.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
									{
										int num2 = calibrationMap.axisCount;
										for (int m = 0; m < num2; m++)
										{
											AxisCalibration axisCalibration = calibrationMap.Axes[m];
											using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS9 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(m.ToString() + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + m.ToString(), A_1))
											{
												if (jBFOEFkAeQEazsKHaJXsORemHpTS9.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
												{
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Enabled", axisCalibration.enabled.ToString());
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Calibrated Max", axisCalibration.calibratedMax.ToString());
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Calibrated Min", axisCalibration.calibratedMin.ToString());
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Calibrated Zero", axisCalibration.calibratedZero.ToString());
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Dead Zone", axisCalibration.deadZone.ToString());
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Invert", axisCalibration.invert.ToString());
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Sensitivity Type", axisCalibration.sensitivityType.ToString());
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Sensitivity", axisCalibration.sensitivity.ToString());
													if (axisCalibration.sensitivityCurve != null)
													{
														bool enabled = GUI.enabled;
														GUI.enabled = false;
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.bIwqYhvSmeHtsITuLfqLQxdmtaeE("Sensitivity Curve", axisCalibration.sensitivityCurve);
														GUI.enabled = enabled;
													}
													else
													{
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Sensitivity Curve", "--");
													}
												}
											}
										}
									}
								}
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Has Extension", (customController.extension != null).ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Extension Type", (customController.extension != null) ? customController.extension.GetType().Name : "--");
								DebugInformation.terQaPIlHxDfXUYyqddqEXHQrKQV(customController, A_1, text);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600367D RID: 13949 RVA: 0x000B7CCC File Offset: 0x000B5ECC
		private static void IopwgEYlscAclHgjxetcbGsOdkJz(Player A_0, int A_1, IDictionary<string, bool> A_2, string A_3)
		{
			string text = A_3 + "_player" + A_0.id.ToString();
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS((A_0.id == 9999999) ? "System Player" : (A_1.ToString() + ": " + A_0.name), text, A_2))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Player Id", A_0.id.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Name", A_0.name);
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Descriptive Name", A_0.descriptiveName);
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Is Playing", A_0.isPlaying.ToString());
					using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS2 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Controllers", text + "_controllers", A_2))
					{
						if (jBFOEFkAeQEazsKHaJXsORemHpTS2.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
						{
							Player.ControllerHelper controllers = A_0.controllers;
							DebugInformation.VTLgJwgxGuJgLKdFMtZnomwdIMpE(controllers.Joysticks, A_2, text);
							DebugInformation.PWPVTJeSqMUqLqexpnAhbgPGSakD(controllers.CustomControllers, A_2, text);
							DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Has Mouse", controllers.hasMouse.ToString());
							DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Has Keyboard", controllers.hasKeyboard.ToString());
							DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Exclude From Controller Auto Assignment", controllers.excludeFromControllerAutoAssignment.ToString());
							DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Last Active Controller", (controllers.GetLastActiveController() != null) ? controllers.GetLastActiveController().name.ToString() : "NULL");
						}
					}
					string text2 = text + "_controllerMaps";
					using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS3 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Controller Maps", text2, A_2))
					{
						if (jBFOEFkAeQEazsKHaJXsORemHpTS3.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
						{
							DebugInformation.dgRrLHLGFkZBwUFwwMJdCrqYeYnt<KeyboardMap>(ControllerType.Keyboard, A_0.controllers.maps.GetMaps<KeyboardMap>(0), "Keyboard Maps", A_2, text2 + "_keyboard");
							DebugInformation.dgRrLHLGFkZBwUFwwMJdCrqYeYnt<MouseMap>(ControllerType.Mouse, A_0.controllers.maps.GetMaps<MouseMap>(0), "Mouse Maps", A_2, text2 + "_mouse");
							string text3 = text2 + "_joystickMaps";
							using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS4 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Joystick Maps (" + A_0.controllers.joystickCount.ToString() + ")", text3, A_2))
							{
								if (jBFOEFkAeQEazsKHaJXsORemHpTS4.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
								{
									for (int i = 0; i < A_0.controllers.joystickCount; i++)
									{
										Joystick joystick = A_0.controllers.Joysticks[i];
										IList<JoystickMap> maps = A_0.controllers.maps.GetMaps<JoystickMap>(joystick.id);
										text3 = text3 + "_joystickId" + joystick.id.ToString();
										DebugInformation.dgRrLHLGFkZBwUFwwMJdCrqYeYnt<JoystickMap>(ControllerType.Joystick, maps, (joystick.name != "Unknown Controller") ? joystick.name : joystick.hardwareName, A_2, text3);
									}
								}
							}
							text3 = text2 + "_customControllerMaps";
							using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS5 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Custom Controller Maps (" + A_0.controllers.customControllerCount.ToString() + ")", text3, A_2))
							{
								if (jBFOEFkAeQEazsKHaJXsORemHpTS5.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
								{
									for (int j = 0; j < A_0.controllers.customControllerCount; j++)
									{
										CustomController customController = A_0.controllers.CustomControllers[j];
										IList<CustomControllerMap> maps2 = A_0.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
										text3 = text3 + "_customControllerId" + customController.id.ToString();
										DebugInformation.dgRrLHLGFkZBwUFwwMJdCrqYeYnt<CustomControllerMap>(ControllerType.Custom, maps2, customController.name, A_2, text3);
									}
								}
							}
						}
					}
					text2 = text + "_controllerMapLayoutManager";
					using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS6 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Layout Manager", text2, A_2))
					{
						if (jBFOEFkAeQEazsKHaJXsORemHpTS6.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
						{
							DebugInformation.LtiSFtSgBVjnJlGMxtWDSKbIBgjk(A_0.controllers.maps.layoutManager, A_2, text2);
						}
					}
					text2 = text + "_controllerMapEnabler";
					using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS7 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Map Enabler", text2, A_2))
					{
						if (jBFOEFkAeQEazsKHaJXsORemHpTS7.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
						{
							DebugInformation.elmVVHNdyunGrxzeNMaahiHeaQwcA(A_0.controllers.maps.mapEnabler, A_2, text2);
						}
					}
					text2 = text + "_inputBehaviors";
					DebugInformation.RaSLWXnEhvWfbZAoyLGnGqWZglYW(A_0.controllers.maps.InputBehaviors, A_2, text2);
					text2 = text + "_actions";
					List<InputAction> list = new List<InputAction>(ReInput.mapping.Actions);
					list.Sort(new Comparison<InputAction>(DebugInformation.qeFqmvvFOApwcVPvVMXUmiZSlpEc.<>9.wiSZreROZsyZjyhicsetNjgIxDTw));
					IList<InputCategory> actionCategories = ReInput.mapping.ActionCategories;
					using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS8 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Actions (" + list.Count.ToString() + ")", text2, A_2))
					{
						if (jBFOEFkAeQEazsKHaJXsORemHpTS8.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
						{
							for (int k = 0; k < actionCategories.Count; k++)
							{
								DebugInformation.bLwtTzlZKKVbUUkHYfqTvCOiAhWBA bLwtTzlZKKVbUUkHYfqTvCOiAhWBA = new DebugInformation.bLwtTzlZKKVbUUkHYfqTvCOiAhWBA();
								bLwtTzlZKKVbUUkHYfqTvCOiAhWBA.MmTpsCifMrfsLBwGCBlSBcxpLnSLA = actionCategories[k];
								string text4 = text2 + "_actionCat" + bLwtTzlZKKVbUUkHYfqTvCOiAhWBA.MmTpsCifMrfsLBwGCBlSBcxpLnSLA.id.ToString();
								int num = ListTools.Count<InputAction>(list, new Predicate<InputAction>(bLwtTzlZKKVbUUkHYfqTvCOiAhWBA.dNcXSRRrVJOawJyTLEyvScejXTSr));
								using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS9 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(string.Concat(new string[]
								{
									"id ",
									bLwtTzlZKKVbUUkHYfqTvCOiAhWBA.MmTpsCifMrfsLBwGCBlSBcxpLnSLA.id.ToString(),
									": ",
									bLwtTzlZKKVbUUkHYfqTvCOiAhWBA.MmTpsCifMrfsLBwGCBlSBcxpLnSLA.name,
									" (",
									num.ToString(),
									")"
								}), text4, A_2))
								{
									if (jBFOEFkAeQEazsKHaJXsORemHpTS9.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
									{
										for (int l = 0; l < list.Count; l++)
										{
											InputAction inputAction = list[l];
											if (inputAction.categoryId == bLwtTzlZKKVbUUkHYfqTvCOiAhWBA.MmTpsCifMrfsLBwGCBlSBcxpLnSLA.id)
											{
												string text5 = text4 + "_actionId" + inputAction.id.ToString();
												using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS10 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(string.Concat(new string[]
												{
													"id ",
													inputAction.id.ToString(),
													": ",
													inputAction.name,
													": ",
													A_0.GetAxis(inputAction.id).ToString("f3")
												}), text5, A_2))
												{
													if (jBFOEFkAeQEazsKHaJXsORemHpTS10.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
													{
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Axis Value", A_0.GetAxis(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Axis Raw Value", A_0.GetAxisRaw(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Button Value", A_0.GetButton(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Button Double Press Value", A_0.GetButtonDoublePressHold(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Button Short Press Value", A_0.GetButtonShortPress(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Button Long Press Value", A_0.GetButtonLongPress(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Button Repeating Value", A_0.GetButtonRepeating(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Negative Button Value", A_0.GetNegativeButton(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Negative Button Double Press Value", A_0.GetNegativeButtonDoublePressHold(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Negative Button Short Press Value", A_0.GetNegativeButtonShortPress(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Negative Button Long Press Value", A_0.GetNegativeButtonLongPress(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Negative Button Repeating Value", A_0.GetNegativeButtonRepeating(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Axis Time Active", A_0.GetAxisTimeActive(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Axis Time Inactive", A_0.GetAxisTimeInactive(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Axis Raw Time Active", A_0.GetAxisRawTimeActive(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Axis Raw Time Inactive", A_0.GetAxisRawTimeInactive(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Button Time Pressed", A_0.GetButtonTimePressed(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Button Time Unpressed", A_0.GetButtonTimeUnpressed(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Negative Button Time Pressed", A_0.GetNegativeButtonTimePressed(inputAction.id).ToString());
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Negative Button Time Unpressed", A_0.GetNegativeButtonTimeUnpressed(inputAction.id).ToString());
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600367E RID: 13950 RVA: 0x000B8710 File Offset: 0x000B6910
		private static void RaSLWXnEhvWfbZAoyLGnGqWZglYW(IList<InputBehavior> A_0, IDictionary<string, bool> A_1, string A_2)
		{
			int num = (A_0 != null) ? A_0.Count : 0;
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Input Behaviors (" + num.ToString() + ")", A_2 + "_inputBehaviors", A_1))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					for (int i = 0; i < num; i++)
					{
						DebugInformation.kmZDZfbTToPtzjhEinjjnAdGQxgSA(A_0[i], i, A_1, A_2);
					}
				}
			}
		}

		// Token: 0x0600367F RID: 13951 RVA: 0x000B8794 File Offset: 0x000B6994
		private static void kmZDZfbTToPtzjhEinjjnAdGQxgSA(InputBehavior A_0, int A_1, IDictionary<string, bool> A_2, string A_3)
		{
			string text = A_3 + "_inputBehavior" + A_0.id.ToString();
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(A_1.ToString() + ": " + A_0.name, text, A_2))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Id", A_0.id.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Name", A_0.name);
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Digital Axis Gravity", A_0.digitalAxisGravity.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Digital Axis Instant Reverse", A_0.digitalAxisInstantReverse.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Digital Axis Sensitivity", A_0.digitalAxisSensitivity.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Digital Axis Snap", A_0.digitalAxisSnap.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Joystick Axis Sensitivity", A_0.joystickAxisSensitivity.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Custom Controller Axis Sensitivity", A_0.customControllerAxisSensitivity.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Mouse XY Axis Mode", A_0.mouseXYAxisMode.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Mouse XY Axis Sensitivity", A_0.mouseXYAxisSensitivity.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Mouse XY Axis Delta Calc", A_0.mouseXYAxisDeltaCalc.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Mouse Other Axis Mode", A_0.mouseOtherAxisMode.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Mouse Other Axis Sensitivity", A_0.mouseOtherAxisSensitivity.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Button Dead Zone", A_0.buttonDeadZone.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Button Double Press Speed", A_0.buttonDoublePressSpeed.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Button Short Press Time", A_0.buttonShortPressTime.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Button Short Press Expires In", A_0.buttonShortPressExpiresIn.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Button Long Press Time", A_0.buttonLongPressTime.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Button Long Press Expires In", A_0.buttonLongPressExpiresIn.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Button Down Buffer", A_0.buttonDownBuffer.ToString());
				}
			}
		}

		// Token: 0x06003680 RID: 13952 RVA: 0x000B8A00 File Offset: 0x000B6C00
		private static void HnkcZzBcdEDfYauMLqliDKPkawMmA(Controller A_0, IDictionary<string, bool> A_1, string A_2)
		{
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Element Identifiers", A_2 + "_elementIdentifiers", A_1))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					if (A_0 is ControllerWithAxes)
					{
						ControllerWithAxes controllerWithAxes = A_0 as ControllerWithAxes;
						int num = (controllerWithAxes.AxisElementIdentifiers != null) ? controllerWithAxes.AxisElementIdentifiers.Count : 0;
						using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS2 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Axis Element Identifiers (" + num.ToString() + ")", A_2 + "_axisEIs", A_1))
						{
							if (jBFOEFkAeQEazsKHaJXsORemHpTS2.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
							{
								for (int i = 0; i < num; i++)
								{
									ControllerElementIdentifier controllerElementIdentifier = controllerWithAxes.AxisElementIdentifiers[i];
									using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS3 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(string.Concat(new string[]
									{
										i.ToString(),
										": ",
										controllerElementIdentifier.name,
										" (id: ",
										controllerElementIdentifier.id.ToString(),
										")"
									}), string.Concat(new string[]
									{
										A_2,
										"_AxisEI",
										i.ToString(),
										"_",
										controllerElementIdentifier.name
									}), A_1))
									{
										if (jBFOEFkAeQEazsKHaJXsORemHpTS3.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
										{
											DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Id", controllerElementIdentifier.id.ToString());
											DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Name", controllerElementIdentifier.name);
										}
									}
								}
							}
						}
					}
					if (A_0 != null)
					{
						int num = (A_0.ButtonElementIdentifiers != null) ? A_0.ButtonElementIdentifiers.Count : 0;
						using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS4 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Button Element Identifiers (" + num.ToString() + ")", A_2 + "_buttonEIs", A_1))
						{
							if (jBFOEFkAeQEazsKHaJXsORemHpTS4.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
							{
								for (int j = 0; j < num; j++)
								{
									ControllerElementIdentifier controllerElementIdentifier2 = A_0.ButtonElementIdentifiers[j];
									using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS5 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(string.Concat(new string[]
									{
										j.ToString(),
										": ",
										controllerElementIdentifier2.name,
										" (id: ",
										controllerElementIdentifier2.id.ToString(),
										")"
									}), string.Concat(new string[]
									{
										A_2,
										"_ButtonEI",
										j.ToString(),
										"_",
										controllerElementIdentifier2.name
									}), A_1))
									{
										if (jBFOEFkAeQEazsKHaJXsORemHpTS5.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
										{
											DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Id", controllerElementIdentifier2.id.ToString());
											DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Name", controllerElementIdentifier2.name);
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06003681 RID: 13953 RVA: 0x000B8D64 File Offset: 0x000B6F64
		private static void EuQUhCCzNsAltmbYTWJTBqkrBPJi(IList<Controller.Button> A_0, ControllerType A_1, IDictionary<string, bool> A_2, string A_3)
		{
			string str = (A_1 == ControllerType.Keyboard) ? "Key" : "Button";
			int num = (A_0 != null) ? A_0.Count : 0;
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(str + "s (" + num.ToString() + ")", A_3 + "_Buttons", A_2))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					for (int i = 0; i < num; i++)
					{
						Controller.Button button = A_0[i];
						using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS2 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(string.Concat(new string[]
						{
							i.ToString(),
							": ",
							(A_1 == ControllerType.Keyboard) ? (Keyboard.GetKeyboardKeyCodeByButtonIndex(i).ToString() + " (" + Keyboard.GetKeyName((KeyCode)Keyboard.GetKeyboardKeyCodeByButtonIndex(i)) + ")") : button.elementIdentifier.name,
							": ",
							button.value ? "Pressed" : "",
							" (",
							button.pressure.ToString("f3"),
							")"
						}), A_3 + "_" + button.name, A_2))
						{
							if (jBFOEFkAeQEazsKHaJXsORemHpTS2.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
							{
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Is Member Element", button.isMemberElement.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Is Pressure Sensitive", button.isPressureSensitive.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value", button.value.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value Prev", button.valuePrev.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Pressure", button.pressure.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Pressure Prev", button.pressurePrev.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Just Pressed", button.justPressed.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Just Released", button.justReleased.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Just Double Pressed", button.justDoublePressed.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Double Pressed And Held", button.doublePressedAndHeld.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Time Pressed", button.timePressed.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Time Unpressed", button.timeUnpressed.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Last Time Pressed", button.lastTimePressed.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Last Time Unpressed", button.lastTimeUnpressed.ToString());
							}
						}
					}
				}
			}
		}

		// Token: 0x06003682 RID: 13954 RVA: 0x000B9054 File Offset: 0x000B7254
		private static void FixGSLzFHUgxDNPLNdhZihNPSvxE(IList<Controller.Axis> A_0, IDictionary<string, bool> A_1, string A_2)
		{
			int num = (A_0 != null) ? A_0.Count : 0;
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Axes (" + num.ToString() + ")", A_2 + "_Axes", A_1))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					for (int i = 0; i < num; i++)
					{
						Controller.Axis axis = A_0[i];
						using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS2 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(string.Concat(new string[]
						{
							i.ToString(),
							": ",
							axis.elementIdentifier.name,
							": ",
							axis.value.ToString("f3"),
							" (",
							axis.valueRaw.ToString("f3"),
							")"
						}), A_2 + "_" + axis.name, A_1))
						{
							if (jBFOEFkAeQEazsKHaJXsORemHpTS2.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
							{
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Is Member Element", axis.isMemberElement.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value", axis.value.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value Raw", axis.valueRaw.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value Prev", axis.valuePrev.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value Raw Prev", axis.valueRawPrev.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value Delta", axis.valueDelta.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value Delta Raw", axis.valueDeltaRaw.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Time Active", axis.timeActive.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Time Active Raw", axis.timeActiveRaw.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Time Inactive", axis.timeInactive.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Time Inactive Raw", axis.timeInactiveRaw.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Last Time Active", axis.lastTimeActive.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Last Time Active Raw", axis.lastTimeActiveRaw.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Last Time Inactive", axis.lastTimeInactive.ToString());
								DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Last Time Inactive Raw", axis.lastTimeInactiveRaw.ToString());
							}
						}
					}
				}
			}
		}

		// Token: 0x06003683 RID: 13955 RVA: 0x000B931C File Offset: 0x000B751C
		private static void dgRrLHLGFkZBwUFwwMJdCrqYeYnt<\u0001>(ControllerType A_0, IList<\u0001> A_1, string A_2, IDictionary<string, bool> A_3, string A_4) where \u0001 : ControllerMap
		{
			string text = A_4 + "_controllerMaps";
			int num = (A_1 != null) ? A_1.Count : 0;
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(A_2 + " (" + num.ToString() + ")", text, A_3))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					for (int i = 0; i < num; i++)
					{
						string text2 = A_1[i].enabled ? "Enabled" : "Disabled";
						InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(A_1[i].categoryId);
						InputLayout layout = ReInput.mapping.GetLayout(A_0, A_1[i].layoutId);
						string text3 = (mapCategory != null) ? mapCategory.name : "n/a";
						string text4 = (layout != null) ? layout.name : "n/a";
						using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS2 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(string.Concat(new string[]
						{
							i.ToString(),
							": ",
							text3,
							", ",
							text4,
							": ",
							text2
						}), A_4 + "_index" + i.ToString(), A_3))
						{
							if (jBFOEFkAeQEazsKHaJXsORemHpTS2.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
							{
								if (A_1[i] is ControllerMapWithAxes)
								{
									DebugInformation.NmMxxbMwJvAHDKqFEiUTbMNXmMFeb(A_1[i] as ControllerMapWithAxes, A_3, text + i.ToString());
								}
								else
								{
									DebugInformation.iWMyRXPgcHaAsEHopJTYQeHinxnbb(A_1[i], A_3, text + i.ToString());
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06003684 RID: 13956 RVA: 0x000B9510 File Offset: 0x000B7710
		private static void iWMyRXPgcHaAsEHopJTYQeHinxnbb(ControllerMap A_0, IDictionary<string, bool> A_1, string A_2)
		{
			DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Id (unique id)", A_0.id.ToString());
			DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Source Map Id", A_0.sourceMapId.ToString());
			DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Enabled", A_0.enabled.ToString());
			DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Controller Type", A_0.controllerType.ToString());
			if (A_0.controllerType == ControllerType.Joystick || A_0.controllerType == ControllerType.Custom)
			{
				DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Controller Id", A_0.controllerId.ToString());
			}
			string text = A_0.categoryId.ToString();
			if (A_0.categoryId >= 0)
			{
				try
				{
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(A_0.categoryId);
					if (mapCategory != null)
					{
						text = text + " (" + mapCategory.name + ")";
					}
				}
				catch
				{
				}
			}
			DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Category Id", text);
			string text2 = A_0.layoutId.ToString();
			if (A_0.layoutId >= 0)
			{
				try
				{
					InputLayout layout = ReInput.mapping.GetLayout(A_0.controllerType, A_0.layoutId);
					if (layout != null)
					{
						text2 = text2 + " (" + layout.name + ")";
					}
				}
				catch
				{
				}
			}
			DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Layout Id", text2);
			int buttonMapCount = A_0.buttonMapCount;
			string text3 = A_2 + "_buttonMaps";
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Button Maps (" + buttonMapCount.ToString() + ")", text3, A_1))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					for (int i = 0; i < buttonMapCount; i++)
					{
						DebugInformation.QuCbcNIAgBInoQufxWBsCKPploWk(A_0.controllerType, A_0.ButtonMaps[i], i, A_1, text3 + i.ToString());
					}
				}
			}
		}

		// Token: 0x06003685 RID: 13957 RVA: 0x000B9710 File Offset: 0x000B7910
		private static void NmMxxbMwJvAHDKqFEiUTbMNXmMFeb(ControllerMapWithAxes A_0, IDictionary<string, bool> A_1, string A_2)
		{
			DebugInformation.iWMyRXPgcHaAsEHopJTYQeHinxnbb(A_0, A_1, A_2);
			string text = A_2 + "_axisMaps";
			int axisMapCount = A_0.axisMapCount;
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Axis Maps (" + axisMapCount.ToString() + ")", text, A_1))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					for (int i = 0; i < axisMapCount; i++)
					{
						DebugInformation.QuCbcNIAgBInoQufxWBsCKPploWk(A_0.controllerType, A_0.AxisMaps[i], i, A_1, text + i.ToString());
					}
				}
			}
		}

		// Token: 0x06003686 RID: 13958 RVA: 0x000B97B0 File Offset: 0x000B79B0
		private static void QuCbcNIAgBInoQufxWBsCKPploWk(ControllerType A_0, ActionElementMap A_1, int A_2, IDictionary<string, bool> A_3, string A_4)
		{
			string str = "Action Element Map";
			InputAction action = ReInput.mapping.GetAction(A_1.actionId);
			string str2 = (action != null) ? action.name : string.Empty;
			string text = DebugInformation.brqhgVNzalbGyWnROlmISnUKNYNC(A_1);
			if (!string.IsNullOrEmpty(text))
			{
				str = A_1.elementIdentifierName + " (" + text + ")";
			}
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(A_2.ToString() + ": " + str, A_4 + "_" + A_2.ToString(), A_3))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Id (unique id)", A_1.id.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Enabled", A_1.enabled.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Element Type", A_1.elementType.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Action Id", A_1.actionId.ToString() + " " + ((action != null) ? ("(" + str2 + ")") : ""));
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Element Identifier Id", A_1.elementIdentifierId.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Element Identifier Name", A_1.elementIdentifierName);
					if (A_1.elementType == ControllerElementType.Axis)
					{
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Element Index", A_1.elementIndex.ToString());
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Axis Range", A_1.axisRange.ToString());
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Axis Type", A_1.axisType.ToString());
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Invert", A_1.invert.ToString());
					}
					else if (A_1.elementType == ControllerElementType.Button)
					{
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Element Index", A_1.elementIndex.ToString());
						if (A_0 == ControllerType.Keyboard)
						{
							DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Key Code", A_1.keyCode.ToString());
							DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Keyboard Key Code", A_1.keyboardKeyCode.ToString());
							DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Has Modifiers", A_1.hasModifiers.ToString());
							DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Modifier Key 1", A_1.modifierKey1.ToString());
							DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Modifier Key 2", A_1.modifierKey2.ToString());
							DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Modifier Key 3", A_1.modifierKey3.ToString());
						}
					}
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Axis Contribution", A_1.axisContribution.ToString());
				}
			}
		}

		// Token: 0x06003687 RID: 13959 RVA: 0x000B9AA8 File Offset: 0x000B7CA8
		private static string brqhgVNzalbGyWnROlmISnUKNYNC(ActionElementMap A_0)
		{
			InputAction action = ReInput.mapping.GetAction(A_0.actionId);
			if (action == null)
			{
				return string.Empty;
			}
			string text = string.Empty;
			if (A_0.elementType == ControllerElementType.Button || (A_0.elementType == ControllerElementType.Axis && A_0.axisType == AxisType.Split))
			{
				if (A_0.axisContribution == Pole.Positive)
				{
					text = action.positiveDescriptiveName;
					if (string.IsNullOrEmpty(text))
					{
						text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? (action.descriptiveName + " +") : (action.name + " +"));
					}
				}
				else
				{
					text = action.negativeDescriptiveName;
					if (string.IsNullOrEmpty(text))
					{
						text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? (action.descriptiveName + " -") : (action.name + " -"));
					}
				}
			}
			else if (A_0.elementType == ControllerElementType.Axis && A_0.axisType == AxisType.Normal)
			{
				text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? action.descriptiveName : action.name);
			}
			return text;
		}

		// Token: 0x06003688 RID: 13960 RVA: 0x000B9BB0 File Offset: 0x000B7DB0
		private static void LtiSFtSgBVjnJlGMxtWDSKbIBgjk(ControllerMapLayoutManager A_0, IDictionary<string, bool> A_1, string A_2)
		{
			if (DebugInformation.rDeJiJemjeRUeCCBuJFHybuzyHMN("Enabled", A_0.enabled))
			{
				A_0.enabled = !A_0.enabled;
			}
			DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Load from User Data Store", A_0.loadFromUserDataStore.ToString());
			string text = A_2 + "_ruleSets";
			int count = A_0.ruleSets.Count;
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Rule Sets (" + count.ToString() + ")", text, A_1))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					for (int i = 0; i < count; i++)
					{
						DebugInformation.VdBDONyOZJLQhpyJsFKNZexYAAdjA(A_0.ruleSets[i], i, A_1, text + i.ToString());
					}
				}
			}
		}

		// Token: 0x06003689 RID: 13961 RVA: 0x000B9C84 File Offset: 0x000B7E84
		private static void VdBDONyOZJLQhpyJsFKNZexYAAdjA(ControllerMapLayoutManager.RuleSet A_0, int A_1, IDictionary<string, bool> A_2, string A_3)
		{
			int num = (A_0 != null) ? A_0.Count : 0;
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(A_1.ToString() + ": " + ((!string.IsNullOrEmpty(A_0.tag)) ? (A_0.tag + ", ") : "") + (A_0.enabled ? "Enabled" : "Disabled"), A_3, A_2))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					if (DebugInformation.rDeJiJemjeRUeCCBuJFHybuzyHMN("Enabled", A_0.enabled))
					{
						A_0.enabled = !A_0.enabled;
					}
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Tag", A_0.tag);
					string text = A_3 + "_rules";
					using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS2 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Rules (" + A_0.Count.ToString() + ")", text, A_2))
					{
						if (jBFOEFkAeQEazsKHaJXsORemHpTS2.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
						{
							for (int i = 0; i < num; i++)
							{
								ControllerMapLayoutManager.Rule rule = A_0[i];
								string text2 = text + i.ToString();
								using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS3 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(i.ToString() + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, A_2))
								{
									if (jBFOEFkAeQEazsKHaJXsORemHpTS3.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
									{
										DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Tag", rule.tag);
										DebugInformation.TpiAMbhAMIlvmxLROTqPosGEzLPcA(rule.controllerSetSelector, A_2, text2);
										int[] categoryIds = rule.categoryIds;
										int num2 = (categoryIds != null) ? categoryIds.Length : 0;
										using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS4 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Map Categories (" + num2.ToString() + ")", text2 + "_categoryIds", A_2))
										{
											if (jBFOEFkAeQEazsKHaJXsORemHpTS4.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
											{
												if (num2 == 0)
												{
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Category", "All Map Categories");
												}
												else
												{
													for (int j = 0; j < categoryIds.Length; j++)
													{
														InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
														string text3 = (mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id.ToString() + ")") : "[INVALID]";
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Category " + j.ToString(), text3);
													}
												}
											}
										}
										InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, rule.layoutId);
										DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA(rule.controllerSetSelector.controllerType.ToString() + " Layout", (layout != null) ? (layout.name + " (" + layout.id.ToString() + ")") : "[INVALID]");
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600368A RID: 13962 RVA: 0x000B9FDC File Offset: 0x000B81DC
		private static void elmVVHNdyunGrxzeNMaahiHeaQwcA(ControllerMapEnabler A_0, IDictionary<string, bool> A_1, string A_2)
		{
			if (DebugInformation.rDeJiJemjeRUeCCBuJFHybuzyHMN("Enabled", A_0.enabled))
			{
				A_0.enabled = !A_0.enabled;
			}
			string text = A_2 + "_ruleSets";
			int count = A_0.ruleSets.Count;
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Rule Sets (" + count.ToString() + ")", text, A_1))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					for (int i = 0; i < count; i++)
					{
						DebugInformation.tKEjrhqflNULZPbipquvvVWicFyq(A_0.ruleSets[i], i, A_1, text + i.ToString());
					}
				}
			}
		}

		// Token: 0x0600368B RID: 13963 RVA: 0x000BA090 File Offset: 0x000B8290
		private static void tKEjrhqflNULZPbipquvvVWicFyq(ControllerMapEnabler.RuleSet A_0, int A_1, IDictionary<string, bool> A_2, string A_3)
		{
			int num = (A_0 != null) ? A_0.Count : 0;
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(A_1.ToString() + ": " + ((!string.IsNullOrEmpty(A_0.tag)) ? (A_0.tag + ", ") : "") + (A_0.enabled ? "Enabled" : "Disabled"), A_3, A_2))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					if (DebugInformation.rDeJiJemjeRUeCCBuJFHybuzyHMN("Enabled", A_0.enabled))
					{
						A_0.enabled = !A_0.enabled;
					}
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Tag", A_0.tag);
					string text = A_3 + "_rules";
					using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS2 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Rules (" + A_0.Count.ToString() + ")", text, A_2))
					{
						if (jBFOEFkAeQEazsKHaJXsORemHpTS2.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
						{
							for (int i = 0; i < num; i++)
							{
								ControllerMapEnabler.Rule rule = A_0[i];
								string text2 = text + i.ToString();
								using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS3 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(i.ToString() + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, A_2))
								{
									if (jBFOEFkAeQEazsKHaJXsORemHpTS3.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
									{
										if (DebugInformation.rDeJiJemjeRUeCCBuJFHybuzyHMN("Enable", rule.enable))
										{
											rule.enable = !rule.enable;
										}
										DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Tag", rule.tag);
										DebugInformation.TpiAMbhAMIlvmxLROTqPosGEzLPcA(rule.controllerSetSelector, A_2, text2);
										int[] categoryIds = rule.categoryIds;
										int num2 = (categoryIds != null) ? categoryIds.Length : 0;
										using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS4 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Map Categories (" + num2.ToString() + ")", text2 + "_categoryIds", A_2))
										{
											if (jBFOEFkAeQEazsKHaJXsORemHpTS4.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
											{
												if (num2 == 0)
												{
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Category", "All Map Categories");
												}
												else
												{
													for (int j = 0; j < categoryIds.Length; j++)
													{
														InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
														string text3 = (mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id.ToString() + ")") : "[INVALID]";
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Category " + j.ToString(), text3);
													}
												}
											}
										}
										int[] layoutIds = rule.layoutIds;
										int num3 = (layoutIds != null) ? layoutIds.Length : 0;
										using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS5 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Layouts (" + num3.ToString() + ")", text2 + "_layoutIds", A_2))
										{
											if (jBFOEFkAeQEazsKHaJXsORemHpTS5.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
											{
												if (num3 == 0)
												{
													DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Layout", (rule.controllerSetSelector.type == ControllerSetSelector.Type.All) ? "All Layouts" : ("All " + rule.controllerSetSelector.controllerType.ToString() + " Layouts"));
												}
												else
												{
													for (int k = 0; k < layoutIds.Length; k++)
													{
														InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, layoutIds[k]);
														string text4 = (layout != null) ? (layout.name + " (" + layout.id.ToString() + ")") : "[INVALID]";
														DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA(rule.controllerSetSelector.controllerType.ToString() + " Layout " + k.ToString(), text4);
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600368C RID: 13964 RVA: 0x000BA4F4 File Offset: 0x000B86F4
		private static void TpiAMbhAMIlvmxLROTqPosGEzLPcA(ControllerSetSelector A_0, IDictionary<string, bool> A_1, string A_2)
		{
			string text = A_2 + "_controllerSetSelector";
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Controller Set Selector", text, A_1))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Type", StringTools.AddSpacesToSentence(A_0.type.ToString(), false));
					if (A_0.type != ControllerSetSelector.Type.All)
					{
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Controller Type", A_0.controllerType.ToString());
					}
					if (A_0.type == ControllerSetSelector.Type.HardwareType)
					{
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Hardware Type Guid", A_0.hardwareTypeGuid.ToString());
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Hardware Identifier", A_0.hardwareIdentifier);
					}
					if (A_0.type == ControllerSetSelector.Type.ControllerTemplateType)
					{
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Controller Template Type Guid", A_0.controllerTemplateTypeGuid.ToString());
					}
					if (A_0.type == ControllerSetSelector.Type.PersistentControllerInstance)
					{
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Device Instance Guid", A_0.deviceInstanceGuid.ToString());
					}
					if (A_0.type == ControllerSetSelector.Type.SessionControllerInstance)
					{
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Controller Id", A_0.controllerId.ToString());
					}
				}
			}
		}

		// Token: 0x0600368D RID: 13965 RVA: 0x000BA644 File Offset: 0x000B8844
		private static void terQaPIlHxDfXUYyqddqEXHQrKQV(Controller A_0, IDictionary<string, bool> A_1, string A_2)
		{
			A_2 += "_templates";
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Templates (" + A_0.templateCount.ToString() + ")", A_2, A_1))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					for (int i = 0; i < A_0.templateCount; i++)
					{
						DebugInformation.SVpApudPohoePAlgFqFYiOyFSchsb(A_0.Templates[i], i, A_2, A_1);
					}
				}
			}
		}

		// Token: 0x0600368E RID: 13966 RVA: 0x000BA6CC File Offset: 0x000B88CC
		private static void SVpApudPohoePAlgFqFYiOyFSchsb(IControllerTemplate A_0, int A_1, string A_2, IDictionary<string, bool> A_3)
		{
			A_2 += ((A_1 >= 0) ? ("_" + A_1.ToString()) : "");
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(((A_1 >= 0) ? (A_1.ToString() + ": ") : "") + A_0.name, A_2, A_3))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Type GUID", A_0.typeGuid.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Class Type", A_0.GetType().ToString());
					A_2 += "_elements";
					using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS2 = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Elements (" + A_0.elementCount.ToString() + ")", A_2, A_3))
					{
						if (jBFOEFkAeQEazsKHaJXsORemHpTS2.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
						{
							for (int i = 0; i < A_0.elementCount; i++)
							{
								DebugInformation.ExwpmEZWmfOVwFfefNAJMOFdzkyG(A_0.elements[i], i, A_2, A_3);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600368F RID: 13967 RVA: 0x000BA804 File Offset: 0x000B8A04
		private static void ExwpmEZWmfOVwFfefNAJMOFdzkyG(IControllerTemplateElement A_0, int A_1, string A_2, IDictionary<string, bool> A_3)
		{
			A_2 += ((A_1 >= 0) ? ("_" + A_1.ToString()) : "");
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(string.Concat(new string[]
			{
				(A_1 >= 0) ? ": " : "",
				A_0.descriptiveName,
				" (id: ",
				A_0.id.ToString(),
				")"
			}), A_2, A_3))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Id", A_0.id.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Name", A_0.descriptiveName.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Type", A_0.type.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Exists", A_0.exists.ToString());
					if (A_0.type == ControllerTemplateElementType.Button)
					{
						DebugInformation.TRxMnYiPVJvUmPBftbFYihmlFjEG(A_0 as IControllerTemplateButton, A_2, A_3);
					}
					else if (A_0.type == ControllerTemplateElementType.Axis)
					{
						DebugInformation.WmFwmKlVcQZvNfheebXGppHyjKwr(A_0 as IControllerTemplateAxis, A_2, A_3);
					}
					else if (A_0.type == ControllerTemplateElementType.DPad)
					{
						IControllerTemplateDPad controllerTemplateDPad = A_0 as IControllerTemplateDPad;
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value", controllerTemplateDPad.value.ToString());
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value Prev", controllerTemplateDPad.valuePrev.ToString());
						DebugInformation.MpvwVFKjFYMxZJydglNbodssDNSu(controllerTemplateDPad.up, "Up", A_2, A_3);
						DebugInformation.MpvwVFKjFYMxZJydglNbodssDNSu(controllerTemplateDPad.right, "Right", A_2, A_3);
						DebugInformation.MpvwVFKjFYMxZJydglNbodssDNSu(controllerTemplateDPad.down, "Down", A_2, A_3);
						DebugInformation.MpvwVFKjFYMxZJydglNbodssDNSu(controllerTemplateDPad.left, "Left", A_2, A_3);
					}
					else if (A_0.type == ControllerTemplateElementType.Hat)
					{
						IControllerTemplateHat controllerTemplateHat = A_0 as IControllerTemplateHat;
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value", controllerTemplateHat.value.ToString());
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value Prev", controllerTemplateHat.valuePrev.ToString());
						DebugInformation.MpvwVFKjFYMxZJydglNbodssDNSu(controllerTemplateHat.up, "up", A_2, A_3);
						DebugInformation.MpvwVFKjFYMxZJydglNbodssDNSu(controllerTemplateHat.upRight, "upRight", A_2, A_3);
						DebugInformation.MpvwVFKjFYMxZJydglNbodssDNSu(controllerTemplateHat.right, "right", A_2, A_3);
						DebugInformation.MpvwVFKjFYMxZJydglNbodssDNSu(controllerTemplateHat.downRight, "downRight", A_2, A_3);
						DebugInformation.MpvwVFKjFYMxZJydglNbodssDNSu(controllerTemplateHat.down, "down", A_2, A_3);
						DebugInformation.MpvwVFKjFYMxZJydglNbodssDNSu(controllerTemplateHat.downLeft, "downLeft", A_2, A_3);
						DebugInformation.MpvwVFKjFYMxZJydglNbodssDNSu(controllerTemplateHat.left, "left", A_2, A_3);
						DebugInformation.MpvwVFKjFYMxZJydglNbodssDNSu(controllerTemplateHat.upLeft, "upLeft", A_2, A_3);
					}
					else if (A_0.type == ControllerTemplateElementType.Stick)
					{
						IControllerTemplateStick controllerTemplateStick = A_0 as IControllerTemplateStick;
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value", controllerTemplateStick.value.ToString());
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value Prev", controllerTemplateStick.valuePrev.ToString());
						DebugInformation.DKaAWbmDMmtfQEXNFjUxvPWNsoEV(controllerTemplateStick.horizontal, "horizontal", A_2, A_3);
						DebugInformation.DKaAWbmDMmtfQEXNFjUxvPWNsoEV(controllerTemplateStick.vertical, "vertical", A_2, A_3);
						DebugInformation.DKaAWbmDMmtfQEXNFjUxvPWNsoEV(controllerTemplateStick.rotation, "rotation", A_2, A_3);
					}
					else if (A_0.type == ControllerTemplateElementType.Throttle)
					{
						IControllerTemplateThrottle controllerTemplateThrottle = A_0 as IControllerTemplateThrottle;
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value", controllerTemplateThrottle.value.ToString());
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value Prev", controllerTemplateThrottle.valuePrev.ToString());
						DebugInformation.DKaAWbmDMmtfQEXNFjUxvPWNsoEV(controllerTemplateThrottle.throttle, "throttle", A_2, A_3);
						DebugInformation.MpvwVFKjFYMxZJydglNbodssDNSu(controllerTemplateThrottle.minDetent, "zeroDetent", A_2, A_3);
					}
					else if (A_0.type == ControllerTemplateElementType.ThumbStick)
					{
						IControllerTemplateThumbStick controllerTemplateThumbStick = A_0 as IControllerTemplateThumbStick;
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value", controllerTemplateThumbStick.value.ToString());
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value Prev", controllerTemplateThumbStick.valuePrev.ToString());
						DebugInformation.DKaAWbmDMmtfQEXNFjUxvPWNsoEV(controllerTemplateThumbStick.horizontal, "horizontal", A_2, A_3);
						DebugInformation.DKaAWbmDMmtfQEXNFjUxvPWNsoEV(controllerTemplateThumbStick.vertical, "vertical", A_2, A_3);
						DebugInformation.MpvwVFKjFYMxZJydglNbodssDNSu(controllerTemplateThumbStick.press, "press", A_2, A_3);
					}
					else if (A_0.type == ControllerTemplateElementType.Yoke)
					{
						IControllerTemplateYoke controllerTemplateYoke = A_0 as IControllerTemplateYoke;
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value", controllerTemplateYoke.value.ToString());
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value Prev", controllerTemplateYoke.valuePrev.ToString());
						DebugInformation.DKaAWbmDMmtfQEXNFjUxvPWNsoEV(controllerTemplateYoke.rotation, "rotation", A_2, A_3);
						DebugInformation.DKaAWbmDMmtfQEXNFjUxvPWNsoEV(controllerTemplateYoke.pushPull, "pushPull", A_2, A_3);
					}
					else if (A_0.type == ControllerTemplateElementType.Stick6D)
					{
						IControllerTemplateStick6D controllerTemplateStick6D = A_0 as IControllerTemplateStick6D;
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Position", controllerTemplateStick6D.position.ToString());
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Position Prev", controllerTemplateStick6D.positionPrev.ToString());
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Rotation", controllerTemplateStick6D.rotation.ToString());
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Rotation Prev", controllerTemplateStick6D.rotationPrev.ToString());
						DebugInformation.DKaAWbmDMmtfQEXNFjUxvPWNsoEV(controllerTemplateStick6D.positionX, "PositionX", A_2, A_3);
						DebugInformation.DKaAWbmDMmtfQEXNFjUxvPWNsoEV(controllerTemplateStick6D.positionY, "PositionY", A_2, A_3);
						DebugInformation.DKaAWbmDMmtfQEXNFjUxvPWNsoEV(controllerTemplateStick6D.positionZ, "PositionZ", A_2, A_3);
						DebugInformation.DKaAWbmDMmtfQEXNFjUxvPWNsoEV(controllerTemplateStick6D.rotationX, "RotationX", A_2, A_3);
						DebugInformation.DKaAWbmDMmtfQEXNFjUxvPWNsoEV(controllerTemplateStick6D.rotationY, "RotationY", A_2, A_3);
						DebugInformation.DKaAWbmDMmtfQEXNFjUxvPWNsoEV(controllerTemplateStick6D.rotationZ, "RotationZ", A_2, A_3);
					}
					else
					{
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Unknown element type", A_0.type.ToString());
					}
				}
			}
		}

		// Token: 0x06003690 RID: 13968 RVA: 0x000BAE20 File Offset: 0x000B9020
		private static void DKaAWbmDMmtfQEXNFjUxvPWNsoEV(IControllerTemplateAxis A_0, string A_1, string A_2, IDictionary<string, bool> A_3)
		{
			A_2 = A_2 + "_" + A_1;
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(StringTools.VariableNameToDisplayName(A_1), A_2, A_3))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					DebugInformation.WmFwmKlVcQZvNfheebXGppHyjKwr(A_0, A_2, A_3);
				}
			}
		}

		// Token: 0x06003691 RID: 13969 RVA: 0x000BAE78 File Offset: 0x000B9078
		private static void MpvwVFKjFYMxZJydglNbodssDNSu(IControllerTemplateButton A_0, string A_1, string A_2, IDictionary<string, bool> A_3)
		{
			A_2 = A_2 + "_" + A_1;
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(StringTools.VariableNameToDisplayName(A_1), A_2, A_3))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					DebugInformation.TRxMnYiPVJvUmPBftbFYihmlFjEG(A_0, A_2, A_3);
				}
			}
		}

		// Token: 0x06003692 RID: 13970 RVA: 0x000BAED0 File Offset: 0x000B90D0
		private static void WmFwmKlVcQZvNfheebXGppHyjKwr(IControllerTemplateAxis A_0, string A_1, IDictionary<string, bool> A_2)
		{
			DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value", A_0.value.ToString());
			DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value Prev", A_0.valuePrev.ToString());
			DebugInformation.oYKSmzEmdUfpfhkaiNqTgtZYGDZYA(A_0.source, "target", A_1, A_2);
		}

		// Token: 0x06003693 RID: 13971 RVA: 0x000BAF20 File Offset: 0x000B9120
		private static void TRxMnYiPVJvUmPBftbFYihmlFjEG(IControllerTemplateButton A_0, string A_1, IDictionary<string, bool> A_2)
		{
			DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value", A_0.value.ToString());
			DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Value Prev", A_0.valuePrev.ToString());
			DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Pressure", A_0.pressure.ToString());
			DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Pressure Prev", A_0.pressurePrev.ToString());
			DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Just Pressed", A_0.justPressed.ToString());
			DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Just Released", A_0.justReleased.ToString());
			DebugInformation.dsuOonQsvYSTSufcEfjDDPTObAWfb(A_0.source, "target", A_1, A_2);
		}

		// Token: 0x06003694 RID: 13972 RVA: 0x000BAFD0 File Offset: 0x000B91D0
		private static void oYKSmzEmdUfpfhkaiNqTgtZYGDZYA(IControllerTemplateAxisSource A_0, string A_1, string A_2, IDictionary<string, bool> A_3)
		{
			A_2 = A_2 + "_" + A_1;
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS("Axis Target", A_2, A_3))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Split Axis", A_0.splitAxis.ToString());
					DebugInformation.FZGewhuldyaKAnGEXEIucHUHjMDnA(A_0.fullTarget, "target", A_2, A_3);
					DebugInformation.FZGewhuldyaKAnGEXEIucHUHjMDnA(A_0.positiveTarget, "positiveTarget", A_2, A_3);
					DebugInformation.FZGewhuldyaKAnGEXEIucHUHjMDnA(A_0.negativeTarget, "negativeTarget", A_2, A_3);
				}
			}
		}

		// Token: 0x06003695 RID: 13973 RVA: 0x0002A7FD File Offset: 0x000289FD
		private static void dsuOonQsvYSTSufcEfjDDPTObAWfb(IControllerTemplateButtonSource A_0, string A_1, string A_2, IDictionary<string, bool> A_3)
		{
			A_2 = A_2 + "_" + A_1;
			DebugInformation.FZGewhuldyaKAnGEXEIucHUHjMDnA(A_0.target, "target", A_2, A_3);
		}

		// Token: 0x06003696 RID: 13974 RVA: 0x000BB06C File Offset: 0x000B926C
		private static void FZGewhuldyaKAnGEXEIucHUHjMDnA(IControllerElementTarget A_0, string A_1, string A_2, IDictionary<string, bool> A_3)
		{
			A_2 = A_2 + "_" + A_1;
			using (DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS jBFOEFkAeQEazsKHaJXsORemHpTS = new DebugInformation.jBFOEFkAeQEazsKHaJXsORemHpTS(StringTools.VariableNameToDisplayName(A_1), A_2, A_3))
			{
				if (jBFOEFkAeQEazsKHaJXsORemHpTS.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA)
				{
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Element Identifier Id", A_0.elementIdentifierId.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Axis Range", A_0.axisRange.ToString());
					DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Has Target", A_0.hasTarget.ToString());
					if (A_0.hasTarget)
					{
						DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA("Target Element", A_0.descriptiveName);
					}
				}
			}
		}

		// Token: 0x06003697 RID: 13975 RVA: 0x0002A81F File Offset: 0x00028A1F
		private static bool rDeJiJemjeRUeCCBuJFHybuzyHMN(string A_0, bool A_1)
		{
			DebugInformation.erKgaQtnpokoVRpysebZeKrHoXhPA.JnDvpQVGHjxcSEVBDEbbwbkGgKTKA(A_0, A_1.ToString());
			return false;
		}

		// Token: 0x06003698 RID: 13976 RVA: 0x0002A82F File Offset: 0x00028A2F
		private static GUIStyle mCZUEJCepDCrtkyDKNEZOmGtYfsK()
		{
			return DebugInformation.rWxjeBFvXUhELSexFDSWhKeviDZw(new GUIStyle(GUI.skin.label)
			{
				margin = 
				{
					top = 1,
					bottom = 1
				},
				fontSize = DebugInformation.jwqxRtOeZhsVrcxAJWrRTTtJvGGj._fontSize
			});
		}

		// Token: 0x06003699 RID: 13977 RVA: 0x0002A86D File Offset: 0x00028A6D
		public static GUIStyle GetToggleStyle()
		{
			GUIStyle guistyle = DebugInformation.rWxjeBFvXUhELSexFDSWhKeviDZw(new GUIStyle(GUI.skin.toggle)
			{
				margin = 
				{
					top = 0,
					bottom = 0
				}
			});
			guistyle.fontSize = DebugInformation.jwqxRtOeZhsVrcxAJWrRTTtJvGGj._fontSize;
			return guistyle;
		}

		// Token: 0x0600369A RID: 13978 RVA: 0x0002A8AB File Offset: 0x00028AAB
		private static GUIStyle rWxjeBFvXUhELSexFDSWhKeviDZw(GUIStyle A_0)
		{
			A_0 = new GUIStyle(A_0);
			A_0.margin.left = DebugInformation.beAacLiBZQWtHnEMzJSQcqAdrSHZ.tkyooRNZAbDPfvYaGavZcPUOJOSX * 20;
			return A_0;
		}

		// Token: 0x04001C9C RID: 7324
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _fontSize = 13;

		// Token: 0x04001C9D RID: 7325
		private static DebugInformation jwqxRtOeZhsVrcxAJWrRTTtJvGGj;

		// Token: 0x04001C9E RID: 7326
		private IDictionary<string, bool> XRuFaBZtMlFxqptKMhprjQQFlBvLA = new Dictionary<string, bool>();

		// Token: 0x04001C9F RID: 7327
		private static Vector2 yRkzUKdfbWoYxYMfpsdhVtzqRyng;

		// Token: 0x04001CA0 RID: 7328
		private const string eWcOchNqsxyxKpdduBiqEHGBdrTeb = "Rewired_DebugInformation";

		// Token: 0x04001CA1 RID: 7329
		private const string HajhDARHfSIdVcIDLBumaeMKNfKqb = "Rewired Debug Information";

		// Token: 0x04001CA2 RID: 7330
		private const int eEUXCDVOCsjWOCuIqvGCVPLzeAUEA = 20;

		// Token: 0x02000540 RID: 1344
		private class jBFOEFkAeQEazsKHaJXsORemHpTS : IDisposable
		{
			// Token: 0x0600369C RID: 13980 RVA: 0x0002A8E4 File Offset: 0x00028AE4
			public jBFOEFkAeQEazsKHaJXsORemHpTS(string A_1, string A_2, IDictionary<string, bool> A_3)
			{
				this.oXGbjoHUKMcQnzlZWAbGqpdPKYxuA = this.boqEPLVibbZjIxJqcgLmzfluOTke(A_1, A_2, A_3);
				DebugInformation.beAacLiBZQWtHnEMzJSQcqAdrSHZ.tkyooRNZAbDPfvYaGavZcPUOJOSX++;
			}

			// Token: 0x0600369D RID: 13981 RVA: 0x0002A907 File Offset: 0x00028B07
			private bool boqEPLVibbZjIxJqcgLmzfluOTke(string A_1, string A_2, IDictionary<string, bool> A_3)
			{
				return this.MzAvsRhqcYknQNpfdOKLkpUKvosS(A_2, GUILayout.Toggle(this.VqStipdMUIXthZmweKcdkdVLSdIW(A_2, A_3), new GUIContent(A_1, A_1), DebugInformation.GetToggleStyle(), Array.Empty<GUILayoutOption>()), A_3);
			}

			// Token: 0x0600369E RID: 13982 RVA: 0x0002A92F File Offset: 0x00028B2F
			private bool VqStipdMUIXthZmweKcdkdVLSdIW(string A_1, IDictionary<string, bool> A_2)
			{
				if (!A_2.ContainsKey(A_1))
				{
					A_2.Add(A_1, false);
				}
				return A_2[A_1];
			}

			// Token: 0x0600369F RID: 13983 RVA: 0x0002A949 File Offset: 0x00028B49
			private bool MzAvsRhqcYknQNpfdOKLkpUKvosS(string A_1, bool A_2, IDictionary<string, bool> A_3)
			{
				if (!A_3.ContainsKey(A_1))
				{
					A_3.Add(A_1, A_2);
				}
				else
				{
					A_3[A_1] = A_2;
				}
				return A_2;
			}

			// Token: 0x060036A0 RID: 13984 RVA: 0x0002A967 File Offset: 0x00028B67
			public void Dispose()
			{
				DebugInformation.beAacLiBZQWtHnEMzJSQcqAdrSHZ.tkyooRNZAbDPfvYaGavZcPUOJOSX--;
			}

			// Token: 0x04001CA3 RID: 7331
			public readonly bool oXGbjoHUKMcQnzlZWAbGqpdPKYxuA;
		}

		// Token: 0x02000541 RID: 1345
		private static class beAacLiBZQWtHnEMzJSQcqAdrSHZ
		{
			// Token: 0x17000C28 RID: 3112
			// (get) Token: 0x060036A1 RID: 13985 RVA: 0x0002A975 File Offset: 0x00028B75
			// (set) Token: 0x060036A2 RID: 13986 RVA: 0x0002A97C File Offset: 0x00028B7C
			public static int tkyooRNZAbDPfvYaGavZcPUOJOSX
			{
				get
				{
					return DebugInformation.beAacLiBZQWtHnEMzJSQcqAdrSHZ.ODznCYvaCKfEJDIeKPNZsWqPRgPfA;
				}
				set
				{
					DebugInformation.beAacLiBZQWtHnEMzJSQcqAdrSHZ.ODznCYvaCKfEJDIeKPNZsWqPRgPfA = Mathf.Max(0, value);
				}
			}

			// Token: 0x04001CA4 RID: 7332
			private static int ODznCYvaCKfEJDIeKPNZsWqPRgPfA;
		}

		// Token: 0x02000542 RID: 1346
		private static class erKgaQtnpokoVRpysebZeKrHoXhPA
		{
			// Token: 0x060036A3 RID: 13987 RVA: 0x0002A98A File Offset: 0x00028B8A
			public static void iigUBaLuGrxlBDlMlNOqsPcCVZFI()
			{
				GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			}

			// Token: 0x060036A4 RID: 13988 RVA: 0x0002A996 File Offset: 0x00028B96
			public static void ZytwEwGSyCWRytvAQKdEjYwkzEfC()
			{
				GUILayout.EndHorizontal();
			}

			// Token: 0x060036A5 RID: 13989 RVA: 0x0002A99D File Offset: 0x00028B9D
			public static void ZFJZIVakssuHLuaQLjOBNbeNoUT()
			{
				GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
			}

			// Token: 0x060036A6 RID: 13990 RVA: 0x0002A9A9 File Offset: 0x00028BA9
			public static void JAKgYNjRDEzVdXkfbNvyViriEkigA()
			{
				GUILayout.EndVertical();
			}

			// Token: 0x060036A7 RID: 13991 RVA: 0x0002A9B0 File Offset: 0x00028BB0
			public static void bKWEfHfQBbutELGoEUOnItRAOLUdb(string A_0, DebugInformation.mciVNfkSlHfQPCucefKSOzpMWJRm A_1)
			{
				GUILayout.Label(A_0, DebugInformation.mCZUEJCepDCrtkyDKNEZOmGtYfsK(), Array.Empty<GUILayoutOption>());
			}

			// Token: 0x060036A8 RID: 13992 RVA: 0x0002A9C2 File Offset: 0x00028BC2
			public static void JnDvpQVGHjxcSEVBDEbbwbkGgKTKA(string A_0, string A_1)
			{
				GUILayout.Label(A_0 + ": " + A_1, DebugInformation.mCZUEJCepDCrtkyDKNEZOmGtYfsK(), Array.Empty<GUILayoutOption>());
			}

			// Token: 0x060036A9 RID: 13993 RVA: 0x0002A9DF File Offset: 0x00028BDF
			public static void bIwqYhvSmeHtsITuLfqLQxdmtaeE(string A_0, AnimationCurve A_1)
			{
				GUILayout.Label(A_0 + ": Curves are not visualized by this tool.", Array.Empty<GUILayoutOption>());
			}

			// Token: 0x060036AA RID: 13994 RVA: 0x0002A9F6 File Offset: 0x00028BF6
			public static bool hdYGnRVbRmqnkXKhxscBjXdGJCdu(string A_0, bool A_1)
			{
				return GUILayout.Toggle(A_1, A_0, DebugInformation.mCZUEJCepDCrtkyDKNEZOmGtYfsK(), Array.Empty<GUILayoutOption>());
			}
		}

		// Token: 0x02000543 RID: 1347
		private static class YYuhvLpvQHhUNiZlOEzmdPAtBjkn
		{
			// Token: 0x17000C29 RID: 3113
			// (get) Token: 0x060036AB RID: 13995 RVA: 0x0002AA09 File Offset: 0x00028C09
			// (set) Token: 0x060036AC RID: 13996 RVA: 0x0002AA10 File Offset: 0x00028C10
			public static float HcGdRfxHVBJLCrPCrjNOKdNYgByCA { get; set; }

			// Token: 0x17000C2A RID: 3114
			// (get) Token: 0x060036AD RID: 13997 RVA: 0x0002AA18 File Offset: 0x00028C18
			// (set) Token: 0x060036AE RID: 13998 RVA: 0x0002AA1F File Offset: 0x00028C1F
			public static float yRqmUDpuuWQuhNhRRRELYXCySBhD { get; set; }

			// Token: 0x04001CA5 RID: 7333
			[CompilerGenerated]
			private static float VzhSjlaJHyTPUxyXMffPFrGJVkVX;

			// Token: 0x04001CA6 RID: 7334
			[CompilerGenerated]
			private static float RnCLzmjtfRhbwHVznqqYfDHPbiJu;
		}

		// Token: 0x02000544 RID: 1348
		internal enum mciVNfkSlHfQPCucefKSOzpMWJRm
		{
			// Token: 0x04001CA8 RID: 7336
			None,
			// Token: 0x04001CA9 RID: 7337
			Info,
			// Token: 0x04001CAA RID: 7338
			Warning,
			// Token: 0x04001CAB RID: 7339
			Error
		}

		// Token: 0x02000545 RID: 1349
		[CompilerGenerated]
		[Serializable]
		private sealed class qeFqmvvFOApwcVPvVMXUmiZSlpEc
		{
			// Token: 0x060036B1 RID: 14001 RVA: 0x0002AA33 File Offset: 0x00028C33
			internal int wiSZreROZsyZjyhicsetNjgIxDTw(InputAction A_1, InputAction A_2)
			{
				return A_1.name.CompareTo(A_2.name);
			}

			// Token: 0x04001CAC RID: 7340
			public static readonly DebugInformation.qeFqmvvFOApwcVPvVMXUmiZSlpEc <>9 = new DebugInformation.qeFqmvvFOApwcVPvVMXUmiZSlpEc();

			// Token: 0x04001CAD RID: 7341
			public static Comparison<InputAction> <>9__17_0;
		}

		// Token: 0x02000546 RID: 1350
		[CompilerGenerated]
		private sealed class bLwtTzlZKKVbUUkHYfqTvCOiAhWBA
		{
			// Token: 0x060036B3 RID: 14003 RVA: 0x0002AA46 File Offset: 0x00028C46
			internal bool dNcXSRRrVJOawJyTLEyvScejXTSr(InputAction A_1)
			{
				return A_1.categoryId == this.MmTpsCifMrfsLBwGCBlSBcxpLnSLA.id;
			}

			// Token: 0x04001CAE RID: 7342
			public InputCategory MmTpsCifMrfsLBwGCBlSBcxpLnSLA;
		}
	}
}
