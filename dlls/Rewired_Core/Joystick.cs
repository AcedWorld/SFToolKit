using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired
{
	// Token: 0x0200005E RID: 94
	public class Joystick : ControllerWithAxes
	{
		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600041F RID: 1055 RVA: 0x00005CE1 File Offset: 0x00003EE1
		internal IList<JoystickType> OmVgUGpTfLdgkFOZUarGBHJSgyEf
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return EmptyObjects<JoystickType>.EmptyReadOnlyIListT;
				}
				return this.vIKzDtmFnQdBAmCwgyJdQJNGBlQR;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000420 RID: 1056 RVA: 0x00005D08 File Offset: 0x00003F08
		public long? systemId
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return new long?(-1L);
				}
				return this.JKgCTciPqALSEPcfLesMCqAgTcxRb.systemId;
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x00005D36 File Offset: 0x00003F36
		public int unityId
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return -1;
				}
				return this.JKgCTciPqALSEPcfLesMCqAgTcxRb.unityId;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000422 RID: 1058 RVA: 0x00005D5E File Offset: 0x00003F5E
		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return Guid.Empty;
				}
				return this.JKgCTciPqALSEPcfLesMCqAgTcxRb.persistentGuid;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x00005D8A File Offset: 0x00003F8A
		public bool supportsVibration
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return false;
				}
				return this.QlIPfHMQXlaCorOnEgPVHORspwKR;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x00034FA4 File Offset: 0x000331A4
		// (set) Token: 0x06000425 RID: 1061 RVA: 0x00035024 File Offset: 0x00033224
		public float vibrationLeftMotor
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return 0f;
				}
				if (!this.QlIPfHMQXlaCorOnEgPVHORspwKR)
				{
					return 0f;
				}
				IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
				if (controllerVibrator != null && controllerVibrator.vibrationMotorCount > 0)
				{
					return controllerVibrator.GetVibration(0);
				}
				if (!this.TLxofEKLiMGGleBluNfrnzoSEpSV)
				{
					return 0f;
				}
				if (this.LiHZkLgShCrvWqkxfeDabhOgNjCxA > 0)
				{
					return this.gvGixrEbmdxnUyidPtAkfihlUtRu[0];
				}
				return 0f;
			}
			set
			{
				if (!this.QlIPfHMQXlaCorOnEgPVHORspwKR)
				{
					return;
				}
				value = MathTools.Clamp(value, 0f, 1f);
				IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
				if (controllerVibrator != null && controllerVibrator.vibrationMotorCount > 0)
				{
					controllerVibrator.SetVibration(0, value);
					return;
				}
				if (!this.TLxofEKLiMGGleBluNfrnzoSEpSV)
				{
					return;
				}
				if (0 >= this.LiHZkLgShCrvWqkxfeDabhOgNjCxA)
				{
					return;
				}
				this.EySSLtEIdwZfZUEbmKuGNMCEwOSl(0, value, 0f, false, true);
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x00035090 File Offset: 0x00033290
		// (set) Token: 0x06000427 RID: 1063 RVA: 0x00035110 File Offset: 0x00033310
		public float vibrationRightMotor
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return 0f;
				}
				if (!this.QlIPfHMQXlaCorOnEgPVHORspwKR)
				{
					return 0f;
				}
				IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
				if (controllerVibrator != null && controllerVibrator.vibrationMotorCount > 1)
				{
					return controllerVibrator.GetVibration(1);
				}
				if (!this.TLxofEKLiMGGleBluNfrnzoSEpSV)
				{
					return 0f;
				}
				if (this.LiHZkLgShCrvWqkxfeDabhOgNjCxA > 1)
				{
					return this.gvGixrEbmdxnUyidPtAkfihlUtRu[1];
				}
				return 0f;
			}
			set
			{
				if (!this.QlIPfHMQXlaCorOnEgPVHORspwKR)
				{
					return;
				}
				value = MathTools.Clamp(value, 0f, 1f);
				IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
				if (controllerVibrator != null && controllerVibrator.vibrationMotorCount > 1)
				{
					controllerVibrator.SetVibration(1, value);
					return;
				}
				if (!this.TLxofEKLiMGGleBluNfrnzoSEpSV)
				{
					return;
				}
				if (1 >= this.LiHZkLgShCrvWqkxfeDabhOgNjCxA)
				{
					return;
				}
				this.EySSLtEIdwZfZUEbmKuGNMCEwOSl(1, value, 0f, false, true);
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000428 RID: 1064 RVA: 0x0003517C File Offset: 0x0003337C
		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return 0;
				}
				if (base.extension is IControllerVibrator)
				{
					return (base.extension as IControllerVibrator).vibrationMotorCount;
				}
				return this.LiHZkLgShCrvWqkxfeDabhOgNjCxA;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x00005DAD File Offset: 0x00003FAD
		public int hatCount
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return 0;
				}
				return this.DDknPmuhGJAvpDfQeDRYsDqokiQHA;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x00005DD0 File Offset: 0x00003FD0
		public IList<Controller.Hat> Hats
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return EmptyObjects<Controller.Hat>.EmptyReadOnlyIListT;
				}
				return this.AvleqKjTFAUZrkhVPgttBsilueCG;
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x00005DF7 File Offset: 0x00003FF7
		public int directionalPadCount
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return 0;
				}
				return this.XTSKUISoQufbdhNaYBXcdJecbGjGB;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x00005E1A File Offset: 0x0000401A
		public IList<Controller.DirectionalPad> DirectionalPads
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return EmptyObjects<Controller.DirectionalPad>.EmptyReadOnlyIListT;
				}
				return this.ioJeaRCFPexcXRjEIpWHwkfEbuUy;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x00005E41 File Offset: 0x00004041
		internal int BjZIwCQrVZKIGHzYAESmJWHyVhwq
		{
			get
			{
				return this.JKgCTciPqALSEPcfLesMCqAgTcxRb.inputManagerId;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x0600042E RID: 1070 RVA: 0x000351C8 File Offset: 0x000333C8
		internal HardwareControllerMapIdentifier ThGbXXlsifIbguAVciLTnfCzoQwS
		{
			get
			{
				if (this.WGnseNgKihPuTwMSEeDkNInQXGEb == null)
				{
					return default(HardwareControllerMapIdentifier);
				}
				return this.WGnseNgKihPuTwMSEeDkNInQXGEb.hardwareMapIdentifier;
			}
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x000351F4 File Offset: 0x000333F4
		internal Joystick(BridgedController A_1) : this(A_1.sourceJoystick.rewiredId, A_1.inputSource, A_1.sourceJoystick.name, (A_1.hw_isBluetoothDevice && !string.IsNullOrEmpty(A_1.hw_bluetoothDeviceName)) ? A_1.hw_bluetoothDeviceName : A_1.productName, A_1.hardwareIdentifier, A_1.controllerTypeGuid, A_1.axisCount, A_1.buttonCount, A_1.isButtonPressureSensitive, A_1.gameHardwareMap, A_1.controllerExtension, new ControllerDataUpdater(A_1.inputManagerSource, A_1.axisCount, A_1.buttonCount, A_1.unknownControllerHats))
		{
			this.JKgCTciPqALSEPcfLesMCqAgTcxRb = A_1.sourceJoystick;
			base.GLHbZelwhOdwlaXxSwsaxsMXqpGj = (this.JKgCTciPqALSEPcfLesMCqAgTcxRb as ITryGetLocalizedName);
			this.QlIPfHMQXlaCorOnEgPVHORspwKR = A_1.hw_supportsVibration;
			this.eRFaWwCGnlFOcOTwfVodoxvATrQSA = A_1.hw_supportsVoice;
			this.LiHZkLgShCrvWqkxfeDabhOgNjCxA = ((A_1.controllerExtension is IControllerVibrator) ? 0 : A_1.hw_localVibrationMotorCount);
			if (this.QlIPfHMQXlaCorOnEgPVHORspwKR && this.LiHZkLgShCrvWqkxfeDabhOgNjCxA > 0)
			{
				this.gvGixrEbmdxnUyidPtAkfihlUtRu = new float[this.LiHZkLgShCrvWqkxfeDabhOgNjCxA];
				this.FVXpMHNYMnaLWbdLjRhcLphpHihM = new TimerAbs[this.LiHZkLgShCrvWqkxfeDabhOgNjCxA];
				ArrayTools.Populate<TimerAbs>(this.FVXpMHNYMnaLWbdLjRhcLphpHihM, 0, this.LiHZkLgShCrvWqkxfeDabhOgNjCxA);
				this.TLxofEKLiMGGleBluNfrnzoSEpSV = true;
			}
			if (this.legQjhUclFMVpVFTfXDlmJRWuUQj != Guid.Empty)
			{
				IList<COootOIiwXGzUSdmLyqHaOKMeIvB> list = ReInput.FnIiSrUmuVbWfEIDNpGFxuuzlUPdA(this.legQjhUclFMVpVFTfXDlmJRWuUQj);
				if (list != null)
				{
					List<IControllerTemplate> list2 = null;
					for (int i = 0; i < list.Count; i++)
					{
						COootOIiwXGzUSdmLyqHaOKMeIvB coootOIiwXGzUSdmLyqHaOKMeIvB = list[i];
						if (coootOIiwXGzUSdmLyqHaOKMeIvB != null)
						{
							IControllerTemplate controllerTemplate;
							try
							{
								controllerTemplate = UnityTools.externalTools.CreateControllerTemplate(coootOIiwXGzUSdmLyqHaOKMeIvB.QrQhTWxkdKIjWKrNNOMwChQrVSON, new ControllerTemplate.EloyBJjsFoEzqixOtJlabyvUdtWp(this, coootOIiwXGzUSdmLyqHaOKMeIvB));
								if (controllerTemplate == null)
								{
									throw new Exception("Controller Template for guid " + coootOIiwXGzUSdmLyqHaOKMeIvB.QrQhTWxkdKIjWKrNNOMwChQrVSON.ToString() + " was not found. If you are using custom Controller Templates, did you export the Controller Templates from the Controller Data Files inspector?");
								}
							}
							catch (Exception ex)
							{
								Logger.LogErrorEditor(ex.Message);
								goto IL_1C8;
							}
							if (list2 == null)
							{
								list2 = new List<IControllerTemplate>();
							}
							list2.Add(controllerTemplate);
						}
						IL_1C8:;
					}
					if (list2 != null)
					{
						base.MgYwapbZCQwLiKLveprNZCrDUWPN(list2.ToArray());
					}
				}
			}
			this.qEnvtUAzINATYqQGwxMxBBiSsAkj();
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x000353FC File Offset: 0x000335FC
		private Joystick(int A_1, InputSource A_2, string A_3, string A_4, string A_5, Guid A_6, int A_7, int A_8, bool[] A_9, HardwareControllerMap_Game A_10, Controller.Extension A_11, ControllerDataUpdater A_12) : base(A_1, A_2, A_3, A_4, A_5, ControllerType.Joystick, A_6, A_7, A_8, A_9, A_10, A_11, A_12)
		{
			if (A_10 == null || A_10.joystickTypes == null || A_10.joystickTypes.Length == 0)
			{
				this.PQqqgTjUsgvxaKFWzVyvDxRRTSye = new JoystickType[1];
			}
			else
			{
				this.PQqqgTjUsgvxaKFWzVyvDxRRTSye = A_10.joystickTypes;
			}
			this.vIKzDtmFnQdBAmCwgyJdQJNGBlQR = new ReadOnlyCollection<JoystickType>(this.PQqqgTjUsgvxaKFWzVyvDxRRTSye);
			this.DDknPmuhGJAvpDfQeDRYsDqokiQHA = A_10.hatCount;
			this.FoGrsPHGKbFoITGKhtvLNrXUHnUS = new Controller.Hat[this.DDknPmuhGJAvpDfQeDRYsDqokiQHA];
			for (int i = 0; i < this.DDknPmuhGJAvpDfQeDRYsDqokiQHA; i++)
			{
				HardwareJoystickMap.CompoundElement hatData = A_10.GetHatData(i);
				try
				{
					if (hatData == null)
					{
						Logger.LogError("Error creating Hat from hardware map! CompoundElement is null!");
						this.FoGrsPHGKbFoITGKhtvLNrXUHnUS[i] = new Controller.Hat(this, hatData.elementIdentifier, "Hat " + i.ToString(), new Controller.Button[0], new int[0]);
					}
					else
					{
						List<Controller.Button> list = new List<Controller.Button>();
						List<int> list2 = new List<int>();
						for (int j = 0; j < hatData.elementCount; j++)
						{
							int componentElementIdentifierId = hatData.GetComponentElementIdentifierId(j);
							if (!ArrayTools.Contains<int>(A_10.buttonElementIdentifierIds, componentElementIdentifierId))
							{
								list.Add(null);
								list2.Add(-1);
							}
							else
							{
								int buttonIndex = A_10.GetButtonIndex(componentElementIdentifierId);
								if (buttonIndex < 0)
								{
									list.Add(null);
									list2.Add(-1);
								}
								else
								{
									list.Add(this.buttons[buttonIndex]);
									list2.Add(buttonIndex);
								}
							}
						}
						try
						{
							this.FoGrsPHGKbFoITGKhtvLNrXUHnUS[i] = new Controller.Hat(this, hatData.elementIdentifier, "Hat " + i.ToString(), list.ToArray(), list2.ToArray());
						}
						catch
						{
							Logger.LogError("Error creating Hat from hardware map! Exception thrown when creating Hat.");
							this.FoGrsPHGKbFoITGKhtvLNrXUHnUS[i] = new Controller.Hat(this, hatData.elementIdentifier, "Hat " + i.ToString(), new Controller.Button[0], new int[0]);
						}
					}
				}
				finally
				{
					base.cVOLZuDPMltkbpMYWExnExBwVvDnA(this.FoGrsPHGKbFoITGKhtvLNrXUHnUS[i]);
				}
			}
			this.AvleqKjTFAUZrkhVPgttBsilueCG = new ReadOnlyCollection<Controller.Hat>(this.FoGrsPHGKbFoITGKhtvLNrXUHnUS);
			this.XTSKUISoQufbdhNaYBXcdJecbGjGB = A_10.dpadCount;
			this.pyLosGRODeBpvpgYdCqCapRhGeMOA = new Controller.DirectionalPad[this.XTSKUISoQufbdhNaYBXcdJecbGjGB];
			for (int k = 0; k < this.XTSKUISoQufbdhNaYBXcdJecbGjGB; k++)
			{
				HardwareJoystickMap.CompoundElement dpadData = A_10.GetDPadData(k);
				try
				{
					if (dpadData == null)
					{
						Logger.LogError("Error creating D-Pad from hardware map! CompoundElement is null!");
						this.pyLosGRODeBpvpgYdCqCapRhGeMOA[k] = new Controller.DirectionalPad(this, dpadData.elementIdentifier, "D-Pad " + k.ToString(), new Controller.Button[0], new int[0]);
					}
					else
					{
						List<Controller.Button> list3 = new List<Controller.Button>();
						List<int> list4 = new List<int>();
						for (int l = 0; l < dpadData.elementCount; l++)
						{
							int componentElementIdentifierId2 = dpadData.GetComponentElementIdentifierId(l);
							if (!ArrayTools.Contains<int>(A_10.buttonElementIdentifierIds, componentElementIdentifierId2))
							{
								list3.Add(null);
								list4.Add(-1);
							}
							else
							{
								int buttonIndex2 = A_10.GetButtonIndex(componentElementIdentifierId2);
								if (buttonIndex2 < 0)
								{
									list3.Add(null);
									list4.Add(-1);
								}
								else
								{
									list3.Add(this.buttons[buttonIndex2]);
									list4.Add(buttonIndex2);
								}
							}
						}
						try
						{
							this.pyLosGRODeBpvpgYdCqCapRhGeMOA[k] = new Controller.DirectionalPad(this, dpadData.elementIdentifier, "D-Pad " + k.ToString(), list3.ToArray(), list4.ToArray());
						}
						catch
						{
							Logger.LogError("Error creating D-Pad from hardware map! Exception thrown when creating D-Pad.");
							this.pyLosGRODeBpvpgYdCqCapRhGeMOA[k] = new Controller.DirectionalPad(this, dpadData.elementIdentifier, "D-Pad " + k.ToString(), new Controller.Button[0], new int[0]);
						}
					}
				}
				finally
				{
					base.cVOLZuDPMltkbpMYWExnExBwVvDnA(this.pyLosGRODeBpvpgYdCqCapRhGeMOA[k]);
				}
			}
			this.ioJeaRCFPexcXRjEIpWHwkfEbuUy = new ReadOnlyCollection<Controller.DirectionalPad>(this.pyLosGRODeBpvpgYdCqCapRhGeMOA);
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00035810 File Offset: 0x00033A10
		internal bool NmHvCAMMCPRAbzsXTESnTGnxCBZz(JoystickType A_1)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			int num = this.PQqqgTjUsgvxaKFWzVyvDxRRTSye.Length;
			for (int i = 0; i < num; i++)
			{
				if (this.PQqqgTjUsgvxaKFWzVyvDxRRTSye[i] == A_1)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00005E4E File Offset: 0x0000404E
		public JoystickCalibrationMapSaveData GetCalibrationMapSaveData()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return null;
			}
			return new JoystickCalibrationMapSaveData(base.calibrationMap, this._type, this._hardwareIdentifier, base.hardwareTypeGuid);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00005E88 File Offset: 0x00004088
		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return;
			}
			this.SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x0003585C File Offset: 0x00033A5C
		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return;
			}
			if (!this.QlIPfHMQXlaCorOnEgPVHORspwKR)
			{
				return;
			}
			IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
			if (controllerVibrator != null)
			{
				int vibrationMotorCount = controllerVibrator.vibrationMotorCount;
				if (vibrationMotorCount > 0)
				{
					controllerVibrator.SetVibration(0, leftMotorLevel, leftMotorDuration);
				}
				if (vibrationMotorCount > 1)
				{
					controllerVibrator.SetVibration(1, rightMotorLevel, rightMotorDuration);
				}
			}
			if (!this.TLxofEKLiMGGleBluNfrnzoSEpSV)
			{
				return;
			}
			if (this.LiHZkLgShCrvWqkxfeDabhOgNjCxA > 0)
			{
				this.EySSLtEIdwZfZUEbmKuGNMCEwOSl(0, leftMotorLevel, leftMotorDuration, false, false);
			}
			if (this.LiHZkLgShCrvWqkxfeDabhOgNjCxA > 1)
			{
				this.EySSLtEIdwZfZUEbmKuGNMCEwOSl(1, rightMotorLevel, rightMotorDuration, false, false);
			}
			this.uQrpdZeyPVZhiuMDKememFAqEILU();
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00005EB6 File Offset: 0x000040B6
		public void SetVibration(int motorIndex, float motorLevel)
		{
			this.SetVibration(motorIndex, motorLevel, 0f, false);
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00005EC6 File Offset: 0x000040C6
		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
			this.SetVibration(motorIndex, motorLevel, duration, false);
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00005ED2 File Offset: 0x000040D2
		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			this.SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x000358F4 File Offset: 0x00033AF4
		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return;
			}
			if (!this.QlIPfHMQXlaCorOnEgPVHORspwKR || motorIndex < 0)
			{
				return;
			}
			IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
			if (controllerVibrator != null)
			{
				controllerVibrator.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
			}
			if (!this.TLxofEKLiMGGleBluNfrnzoSEpSV)
			{
				return;
			}
			if (motorIndex >= this.LiHZkLgShCrvWqkxfeDabhOgNjCxA)
			{
				return;
			}
			this.EySSLtEIdwZfZUEbmKuGNMCEwOSl(motorIndex, motorLevel, duration, stopOtherMotors, true);
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00035964 File Offset: 0x00033B64
		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0f;
			}
			if (!this.QlIPfHMQXlaCorOnEgPVHORspwKR || motorIndex < 0)
			{
				return 0f;
			}
			IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
			if (controllerVibrator != null && motorIndex < controllerVibrator.vibrationMotorCount)
			{
				return controllerVibrator.GetVibration(motorIndex);
			}
			if (!this.TLxofEKLiMGGleBluNfrnzoSEpSV)
			{
				return 0f;
			}
			if (motorIndex >= this.LiHZkLgShCrvWqkxfeDabhOgNjCxA)
			{
				return 0f;
			}
			return this.gvGixrEbmdxnUyidPtAkfihlUtRu[motorIndex];
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x000359E8 File Offset: 0x00033BE8
		public void StopVibration()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return;
			}
			if (!this.QlIPfHMQXlaCorOnEgPVHORspwKR)
			{
				return;
			}
			IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
			if (controllerVibrator != null)
			{
				controllerVibrator.StopVibration();
			}
			if (this.TLxofEKLiMGGleBluNfrnzoSEpSV)
			{
				Array.Clear(this.gvGixrEbmdxnUyidPtAkfihlUtRu, 0, this.gvGixrEbmdxnUyidPtAkfihlUtRu.Length);
				for (int i = 0; i < this.LiHZkLgShCrvWqkxfeDabhOgNjCxA; i++)
				{
					this.FVXpMHNYMnaLWbdLjRhcLphpHihM[i].Clear();
				}
			}
			if (this.JKgCTciPqALSEPcfLesMCqAgTcxRb != null)
			{
				this.JKgCTciPqALSEPcfLesMCqAgTcxRb.StopVibration();
			}
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00035A7C File Offset: 0x00033C7C
		internal virtual void CdGxIEUmaqXQvuzCHkpHkjPbdtqH(UpdateLoopType A_1)
		{
			base.HNyKctIlBYbvsLaQmuRrJcfvYARm(A_1);
			for (int i = 0; i < this.DDknPmuhGJAvpDfQeDRYsDqokiQHA; i++)
			{
				if (this.FoGrsPHGKbFoITGKhtvLNrXUHnUS[i] != null)
				{
					this.FoGrsPHGKbFoITGKhtvLNrXUHnUS[i].VemTStXfXrIsdaQWUBvMMdXulhEY(A_1, this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb);
				}
			}
			for (int j = 0; j < this.XTSKUISoQufbdhNaYBXcdJecbGjGB; j++)
			{
				if (this.pyLosGRODeBpvpgYdCqCapRhGeMOA[j] != null)
				{
					this.pyLosGRODeBpvpgYdCqCapRhGeMOA[j].pYOiYUPFcFDuKUemhmfGuZJmGmkO(A_1, this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb);
				}
			}
			this.loeVhkmfvVVEWqQDKDNVoNmMrIeo();
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00005EE2 File Offset: 0x000040E2
		internal void IJOhYxqRBOGjaKvVYvqaHjEEAbAx(UpdateControllerInfoEventArgs A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			this.qripnrnCNpSEUkIGZnfLvcxOlAOQ(A_1.sourceJoystick);
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00005EF4 File Offset: 0x000040F4
		internal void RapssdIPKSTuZrgyibatSKSDlRgh(BridgedController A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			this.qripnrnCNpSEUkIGZnfLvcxOlAOQ(A_1.sourceJoystick);
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00035AF4 File Offset: 0x00033CF4
		private void qripnrnCNpSEUkIGZnfLvcxOlAOQ(IInputManagerJoystickPublic A_1)
		{
			this.JKgCTciPqALSEPcfLesMCqAgTcxRb = A_1;
			base.GLHbZelwhOdwlaXxSwsaxsMXqpGj = (A_1 as ITryGetLocalizedName);
			if (A_1 == null)
			{
				return;
			}
			if (base.extension != null)
			{
				base.CrnanVLriShQUIjluGsNhACGtayK(A_1.extension);
			}
			else
			{
				base.IyhljjWhnREpPEFrzYjBCBrPWmrY(A_1.extension);
			}
			if (A_1.name != string.Empty)
			{
				this._name = A_1.name;
			}
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00005F06 File Offset: 0x00004106
		internal virtual void MXDBygccqUxeUQRUWasAudTaXXPLA()
		{
			base.xSsMiNKHGFcrTjlxQnjHqjKlHSWZ();
			this.StopVibration();
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00005F14 File Offset: 0x00004114
		internal virtual void WdMVpCvehbhruztUlyLyVXqNUOSq(bool A_1)
		{
			base.traDKlHspaXCdfNvtkwAFzPfEhYY(A_1);
			if (!A_1 && !ReInput.applicationRunInBackground)
			{
				this.StopVibration();
			}
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x00035B58 File Offset: 0x00033D58
		protected override void Disconnected()
		{
			base.Disconnected();
			if (this.TLxofEKLiMGGleBluNfrnzoSEpSV)
			{
				Array.Clear(this.gvGixrEbmdxnUyidPtAkfihlUtRu, 0, this.gvGixrEbmdxnUyidPtAkfihlUtRu.Length);
				for (int i = 0; i < this.LiHZkLgShCrvWqkxfeDabhOgNjCxA; i++)
				{
					this.FVXpMHNYMnaLWbdLjRhcLphpHihM[i].Clear();
				}
			}
			IControllerVibrator controllerVibrator = base.extension as IControllerVibrator;
			if (controllerVibrator != null)
			{
				controllerVibrator.StopVibration();
			}
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x00035BBC File Offset: 0x00033DBC
		private void loeVhkmfvVVEWqQDKDNVoNmMrIeo()
		{
			if (!this.QlIPfHMQXlaCorOnEgPVHORspwKR)
			{
				return;
			}
			if (!this.TLxofEKLiMGGleBluNfrnzoSEpSV)
			{
				return;
			}
			for (int i = 0; i < this.LiHZkLgShCrvWqkxfeDabhOgNjCxA; i++)
			{
				if (this.FVXpMHNYMnaLWbdLjRhcLphpHihM[i].Update())
				{
					this.SetVibration(i, 0f, false);
				}
			}
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00035C08 File Offset: 0x00033E08
		private void EySSLtEIdwZfZUEbmKuGNMCEwOSl(int A_1, float A_2, float A_3, bool A_4, bool A_5)
		{
			if (!this.TLxofEKLiMGGleBluNfrnzoSEpSV)
			{
				return;
			}
			if (A_1 < 0 || A_1 >= this.LiHZkLgShCrvWqkxfeDabhOgNjCxA)
			{
				return;
			}
			if (A_4)
			{
				Array.Clear(this.gvGixrEbmdxnUyidPtAkfihlUtRu, 0, this.gvGixrEbmdxnUyidPtAkfihlUtRu.Length);
				for (int i = 0; i < this.LiHZkLgShCrvWqkxfeDabhOgNjCxA; i++)
				{
					this.FVXpMHNYMnaLWbdLjRhcLphpHihM[i].Clear();
				}
			}
			this.gvGixrEbmdxnUyidPtAkfihlUtRu[A_1] = MathTools.Clamp01(A_2);
			if (A_2 <= 0f || A_3 <= 0f)
			{
				this.FVXpMHNYMnaLWbdLjRhcLphpHihM[A_1].Clear();
			}
			else
			{
				this.FVXpMHNYMnaLWbdLjRhcLphpHihM[A_1].Start((double)A_3);
			}
			if (A_5)
			{
				this.uQrpdZeyPVZhiuMDKememFAqEILU();
			}
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00035CA8 File Offset: 0x00033EA8
		private void uQrpdZeyPVZhiuMDKememFAqEILU()
		{
			if (!this.QlIPfHMQXlaCorOnEgPVHORspwKR || !this.TLxofEKLiMGGleBluNfrnzoSEpSV)
			{
				return;
			}
			if (this.JKgCTciPqALSEPcfLesMCqAgTcxRb == null)
			{
				return;
			}
			for (int i = 0; i < this.gvGixrEbmdxnUyidPtAkfihlUtRu.Length; i++)
			{
				this.JKgCTciPqALSEPcfLesMCqAgTcxRb.SetVibration(this.gvGixrEbmdxnUyidPtAkfihlUtRu[i], i);
			}
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00002FF9 File Offset: 0x000011F9
		private void EWBDojVyiQkvhRwJhmTINmfMapZw()
		{
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00005F2D File Offset: 0x0000412D
		internal static int gJHZVvczEoCkCxKFlcmJagyCMvjZ(Joystick A_0, Joystick A_1)
		{
			if (A_0.BjZIwCQrVZKIGHzYAESmJWHyVhwq < A_1.BjZIwCQrVZKIGHzYAESmJWHyVhwq)
			{
				return -1;
			}
			if (A_0.BjZIwCQrVZKIGHzYAESmJWHyVhwq > A_1.BjZIwCQrVZKIGHzYAESmJWHyVhwq)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x04000316 RID: 790
		private const int cVqewnOiCfsDLrDAKvXrdfuJHDIJ = 0;

		// Token: 0x04000317 RID: 791
		private const int BCRyxEJfvXLNsLDfaqwXsbTyphRB = 1;

		// Token: 0x04000318 RID: 792
		private IInputManagerJoystickPublic JKgCTciPqALSEPcfLesMCqAgTcxRb;

		// Token: 0x04000319 RID: 793
		private readonly JoystickType[] PQqqgTjUsgvxaKFWzVyvDxRRTSye;

		// Token: 0x0400031A RID: 794
		private readonly ReadOnlyCollection<JoystickType> vIKzDtmFnQdBAmCwgyJdQJNGBlQR;

		// Token: 0x0400031B RID: 795
		private readonly bool QlIPfHMQXlaCorOnEgPVHORspwKR;

		// Token: 0x0400031C RID: 796
		private readonly bool TLxofEKLiMGGleBluNfrnzoSEpSV;

		// Token: 0x0400031D RID: 797
		private readonly bool eRFaWwCGnlFOcOTwfVodoxvATrQSA;

		// Token: 0x0400031E RID: 798
		private readonly int LiHZkLgShCrvWqkxfeDabhOgNjCxA;

		// Token: 0x0400031F RID: 799
		private readonly float[] gvGixrEbmdxnUyidPtAkfihlUtRu;

		// Token: 0x04000320 RID: 800
		private readonly TimerAbs[] FVXpMHNYMnaLWbdLjRhcLphpHihM;

		// Token: 0x04000321 RID: 801
		private readonly int DDknPmuhGJAvpDfQeDRYsDqokiQHA;

		// Token: 0x04000322 RID: 802
		private readonly Controller.Hat[] FoGrsPHGKbFoITGKhtvLNrXUHnUS;

		// Token: 0x04000323 RID: 803
		private readonly ReadOnlyCollection<Controller.Hat> AvleqKjTFAUZrkhVPgttBsilueCG;

		// Token: 0x04000324 RID: 804
		private readonly int XTSKUISoQufbdhNaYBXcdJecbGjGB;

		// Token: 0x04000325 RID: 805
		private readonly Controller.DirectionalPad[] pyLosGRODeBpvpgYdCqCapRhGeMOA;

		// Token: 0x04000326 RID: 806
		private readonly ReadOnlyCollection<Controller.DirectionalPad> ioJeaRCFPexcXRjEIpWHwkfEbuUy;
	}
}
