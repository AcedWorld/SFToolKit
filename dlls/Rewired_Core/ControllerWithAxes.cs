using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	// Token: 0x02000058 RID: 88
	public abstract class ControllerWithAxes : ControllerWithMap
	{
		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060003AF RID: 943 RVA: 0x0000592A File Offset: 0x00003B2A
		public int axisCount
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return 0;
				}
				return this._axisCount;
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060003B0 RID: 944 RVA: 0x0000594D File Offset: 0x00003B4D
		public int axis2DCount
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return 0;
				}
				return this._axis2DCount;
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060003B1 RID: 945 RVA: 0x00005970 File Offset: 0x00003B70
		public IList<Controller.Axis> Axes
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return EmptyObjects<Controller.Axis>.EmptyReadOnlyIListT;
				}
				return this.axes_readOnly;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060003B2 RID: 946 RVA: 0x00005997 File Offset: 0x00003B97
		public IList<Controller.Axis2D> Axes2D
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return EmptyObjects<Controller.Axis2D>.EmptyReadOnlyIListT;
				}
				return this.axes2D_readOnly;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060003B3 RID: 947 RVA: 0x000059BE File Offset: 0x00003BBE
		public CalibrationMap calibrationMap
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return null;
				}
				return this._calibrationMap;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x000059E1 File Offset: 0x00003BE1
		public IList<ControllerElementIdentifier> AxisElementIdentifiers
		{
			get
			{
				if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
				{
					ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return this.WGnseNgKihPuTwMSEeDkNInQXGEb.axisElementIdentifiers_readOnly;
			}
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x00032FDC File Offset: 0x000311DC
		internal ControllerWithAxes(int A_1, InputSource A_2, string A_3, string A_4, string A_5, ControllerType A_6, Guid A_7, int A_8, int A_9, bool[] A_10, HardwareControllerMap_Game A_11, Controller.Extension A_12, ControllerDataUpdater A_13) : base(A_1, A_2, A_3, A_4, A_5, A_6, A_7, A_9, A_10, A_11, A_12, A_13)
		{
			this._axisCount = A_8;
			this.axes = new Controller.Axis[A_8];
			for (int i = 0; i < A_8; i++)
			{
				this.axes[i] = new Controller.Axis(this, A_11.axisElementIdentifierIds[i], "Axis " + i.ToString(), A_11.hwAxisRanges[i], A_11.hwAxisInfo[i]);
				base.XLjRULaYMvgYNtbsPXBrIvFPOHVy(this.axes[i]);
			}
			this.axes_readOnly = new ReadOnlyCollection<Controller.Axis>(this.axes);
			Func<int, int> func = null;
			if (base.extension is IAxisCalibrationIndexMap)
			{
				func = new Func<int, int>(this.SsjVFhbeLeyxIHEIhCXeNqJhdtSm);
			}
			this._calibrationMap = new CalibrationMap(A_11.hwAxisCalibrationData, func);
			this._axis2DCount = A_11.axis2DCount;
			this.axes2D = new Controller.Axis2D[this._axis2DCount];
			for (int j = 0; j < this._axis2DCount; j++)
			{
				try
				{
					HardwareJoystickMap.CompoundElement axis2DData = A_11.GetAxis2DData(j);
					if (axis2DData == null)
					{
						Logger.LogError("Error creating Axis2D from hardware map! CompoundElement is null!");
						this.axes2D[j] = new Controller.Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + j.ToString(), null, null, 0, 0, null);
					}
					else
					{
						int axisIndex = A_11.GetAxisIndex(axis2DData.componentElementIdentifiers[0]);
						int axisIndex2 = A_11.GetAxisIndex(axis2DData.componentElementIdentifiers[1]);
						if (axisIndex < 0 || axisIndex >= this._axisCount || axisIndex2 < 0 || axisIndex2 >= this._axisCount)
						{
							this.axes2D[j] = new Controller.Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + j.ToString(), null, null, 0, 0, null);
						}
						else
						{
							this.axes2D[j] = new Controller.Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + j.ToString(), this.axes[axisIndex], this.axes[axisIndex2], axisIndex, axisIndex2, this._calibrationMap);
						}
					}
				}
				catch
				{
					Logger.LogError("Error creating Axis2D from hardware map! An exception was thrown.");
					this.axes2D[j] = new Controller.Axis2D(this, -1, "Axis 2D " + j.ToString(), null, null, 0, 0, null);
				}
				finally
				{
					base.cVOLZuDPMltkbpMYWExnExBwVvDnA(this.axes2D[j]);
				}
			}
			this.axes2D_readOnly = new ReadOnlyCollection<Controller.Axis2D>(this.axes2D);
			this.uGSPQHjHvphynelfZpJNYIuXmcT();
			this.XJnDrZlXJpiyahbEmvURnYBGJPEM = new Func<int, int>(A_11.GetAxisIndex);
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x00033284 File Offset: 0x00031484
		public override Controller.Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return null;
			}
			if (this.WGnseNgKihPuTwMSEeDkNInQXGEb == null)
			{
				return null;
			}
			Controller.Element elementById = base.GetElementById(elementIdentifierId);
			if (elementById != null)
			{
				return elementById;
			}
			int axisIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0)
			{
				return null;
			}
			return this.axes[axisIndex];
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00005A0D File Offset: 0x00003C0D
		public int GetAxisIndexById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return -1;
			}
			return this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetAxisIndex(elementIdentifierId);
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x000332E0 File Offset: 0x000314E0
		public float GetAxis(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0f;
			}
			if (index < 0 || index >= this._axisCount)
			{
				return 0f;
			}
			return this.axes[index].value;
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0003332C File Offset: 0x0003152C
		public float GetAxisPrev(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0f;
			}
			if (index < 0 || index >= this._axisCount)
			{
				return 0f;
			}
			return this.axes[index].valuePrev;
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00033378 File Offset: 0x00031578
		public float GetAxisRaw(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0f;
			}
			if (index < 0 || index >= this._axisCount)
			{
				return 0f;
			}
			return this.axes[index].valueRaw;
		}

		// Token: 0x060003BB RID: 955 RVA: 0x000333C4 File Offset: 0x000315C4
		public float GetAxisRawPrev(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0f;
			}
			if (index < 0 || index >= this._axisCount)
			{
				return 0f;
			}
			return this.axes[index].valueRawPrev;
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00033410 File Offset: 0x00031610
		public double GetAxisTimeActive(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			if (index < 0 || index >= this._axisCount)
			{
				return 0.0;
			}
			return this.axes[index].timeActive;
		}

		// Token: 0x060003BD RID: 957 RVA: 0x00033464 File Offset: 0x00031664
		public double GetAxisTimeInactive(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			if (index < 0 || index >= this._axisCount)
			{
				return 0.0;
			}
			return this.axes[index].timeInactive;
		}

		// Token: 0x060003BE RID: 958 RVA: 0x000334B8 File Offset: 0x000316B8
		public double GetAxisLastTimeActive(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			if (index < 0 || index >= this._axisCount)
			{
				return 0.0;
			}
			return this.axes[index].lastTimeActive;
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0003350C File Offset: 0x0003170C
		public double GetAxisLastTimeInactive(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			if (index < 0 || index >= this._axisCount)
			{
				return 0.0;
			}
			return this.axes[index].lastTimeInactive;
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00033560 File Offset: 0x00031760
		public double GetAxisRawTimeActive(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			if (index < 0 || index >= this._axisCount)
			{
				return 0.0;
			}
			return this.axes[index].timeActiveRaw;
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x000335B4 File Offset: 0x000317B4
		public double GetAxisRawTimeInactive(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			if (index < 0 || index >= this._axisCount)
			{
				return 0.0;
			}
			return this.axes[index].timeInactiveRaw;
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00033608 File Offset: 0x00031808
		public double GetAxisRawLastTimeActive(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			if (index < 0 || index >= this._axisCount)
			{
				return 0.0;
			}
			return this.axes[index].lastTimeActiveRaw;
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x0003365C File Offset: 0x0003185C
		public double GetAxisRawLastTimeInactive(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			if (index < 0 || index >= this._axisCount)
			{
				return 0.0;
			}
			return this.axes[index].lastTimeInactiveRaw;
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x000336B0 File Offset: 0x000318B0
		public float GetAxisById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0f;
			}
			int axisIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= this._axisCount)
			{
				return 0f;
			}
			return this.axes[axisIndex].value;
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x0003370C File Offset: 0x0003190C
		public float GetAxisPrevById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0f;
			}
			int axisIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= this._axisCount)
			{
				return 0f;
			}
			return this.axes[axisIndex].valuePrev;
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00033768 File Offset: 0x00031968
		public float GetAxisRawById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0f;
			}
			int axisIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= this._axisCount)
			{
				return 0f;
			}
			return this.axes[axisIndex].valueRaw;
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x000337C4 File Offset: 0x000319C4
		public float GetAxisRawPrevById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0f;
			}
			int axisIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= this._axisCount)
			{
				return 0f;
			}
			return this.axes[axisIndex].valueRawPrev;
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00033820 File Offset: 0x00031A20
		public double GetAxisTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			int axisIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= this._axisCount)
			{
				return 0.0;
			}
			return this.axes[axisIndex].timeActive;
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00033884 File Offset: 0x00031A84
		public double GetAxisTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			int axisIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= this._axisCount)
			{
				return 0.0;
			}
			return this.axes[axisIndex].timeInactive;
		}

		// Token: 0x060003CA RID: 970 RVA: 0x000338E8 File Offset: 0x00031AE8
		public double GetAxisLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			int axisIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= this._axisCount)
			{
				return 0.0;
			}
			return this.axes[axisIndex].lastTimeActive;
		}

		// Token: 0x060003CB RID: 971 RVA: 0x0003394C File Offset: 0x00031B4C
		public double GetAxisLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			int axisIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= this._axisCount)
			{
				return 0.0;
			}
			return this.axes[axisIndex].lastTimeInactive;
		}

		// Token: 0x060003CC RID: 972 RVA: 0x000339B0 File Offset: 0x00031BB0
		public double GetAxisRawTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			int axisIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= this._axisCount)
			{
				return 0.0;
			}
			return this.axes[axisIndex].timeActiveRaw;
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00033A14 File Offset: 0x00031C14
		public double GetAxisRawTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			int axisIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= this._axisCount)
			{
				return 0.0;
			}
			return this.axes[axisIndex].timeInactiveRaw;
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00033A78 File Offset: 0x00031C78
		public double GetAxisRawLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			int axisIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= this._axisCount)
			{
				return 0.0;
			}
			return this.axes[axisIndex].lastTimeActiveRaw;
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00033ADC File Offset: 0x00031CDC
		public double GetAxisRawLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			int axisIndex = this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= this._axisCount)
			{
				return 0.0;
			}
			return this.axes[axisIndex].lastTimeInactiveRaw;
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x00033B40 File Offset: 0x00031D40
		public Vector2 GetAxis2D(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return Vector2.zero;
			}
			if (index < 0 || index >= this._axis2DCount)
			{
				return default(Vector2);
			}
			return this.axes2D[index].value;
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x00033B90 File Offset: 0x00031D90
		public Vector2 GetAxis2DPrev(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return Vector2.zero;
			}
			if (index < 0 || index >= this._axis2DCount)
			{
				return default(Vector2);
			}
			return this.axes2D[index].valuePrev;
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00033BE0 File Offset: 0x00031DE0
		public Vector2 GetAxis2DRaw(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return Vector2.zero;
			}
			if (index < 0 || index >= this._axis2DCount)
			{
				return default(Vector2);
			}
			return this.axes2D[index].valueRaw;
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00033C30 File Offset: 0x00031E30
		public Vector2 GetAxis2DRawPrev(int index)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return Vector2.zero;
			}
			if (index < 0 || index >= this._axis2DCount)
			{
				return default(Vector2);
			}
			return this.axes2D[index].valueRawPrev;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00004849 File Offset: 0x00002A49
		public override double GetLastTimeActive()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			return this.GetLastTimeActive(false);
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x00005A36 File Offset: 0x00003C36
		public override double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			return MathTools.Max(base.GetLastTimeActive(useRawValues), this.GetLastTimeAnyAxisActive(useRawValues));
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x00005A6E File Offset: 0x00003C6E
		public override double GetLastTimeAnyElementChanged()
		{
			return this.GetLastTimeAnyElementChanged(false);
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00005A77 File Offset: 0x00003C77
		public override double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			return MathTools.Max(base.GetLastTimeAnyElementChanged(useRawValues), this.GetLastTimeAnyAxisChanged(useRawValues));
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00005AAF File Offset: 0x00003CAF
		public double GetLastTimeAnyAxisActive()
		{
			return this.GetLastTimeAnyAxisActive(false);
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x00033C80 File Offset: 0x00031E80
		public double GetLastTimeAnyAxisActive(bool useRawValues)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			if (this.axes == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < this.axes.Length; i++)
			{
				double num2 = useRawValues ? this.axes[i].lastTimeActiveRaw : this.axes[i].lastTimeActive;
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00005AB8 File Offset: 0x00003CB8
		public double GetLastTimeAnyAxisChanged()
		{
			return this.GetLastTimeAnyAxisChanged(false);
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00033D08 File Offset: 0x00031F08
		public double GetLastTimeAnyAxisChanged(bool useRawValues)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return 0.0;
			}
			if (this.axes == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < this.axes.Length; i++)
			{
				double num2 = useRawValues ? this.axes[i].lastTimeValueChangedRaw : this.axes[i].lastTimeValueChanged;
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00033D90 File Offset: 0x00031F90
		public override ControllerPollingInfo PollForFirstElement()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
			}
			ControllerPollingInfo result = base.PollForFirstElement();
			if (result.success)
			{
				return result;
			}
			return this.PollForFirstAxis();
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00033DD4 File Offset: 0x00031FD4
		public override ControllerPollingInfo PollForFirstElementDown()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
			}
			ControllerPollingInfo result = base.PollForFirstElementDown();
			if (result.success)
			{
				return result;
			}
			return this.PollForFirstAxis();
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00033E18 File Offset: 0x00032018
		public ControllerPollingInfo PollForFirstAxis()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
			}
			base.UpdatePollingFrameTracking();
			this.BZKtAeaVoigIWokiIuLuXnLkUqHy();
			for (int i = 0; i < this._axisCount; i++)
			{
				Pole pole;
				int num;
				if (this.IsPolledAxisActive(i, out pole, out num))
				{
					return new ControllerPollingInfo(true, -1, this.id, this._name, this._type, ControllerElementType.Axis, i, pole, this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.EXNSuXxOFjDfdIjdsBQXmtXlYiWn();
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00005AC1 File Offset: 0x00003CC1
		public override IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				yield break;
			}
			foreach (ControllerPollingInfo controllerPollingInfo in this.RFEThRMDkfTKMGzRSBolMzKexLOH())
			{
				yield return controllerPollingInfo;
			}
			IEnumerator<ControllerPollingInfo> enumerator = null;
			foreach (ControllerPollingInfo controllerPollingInfo2 in this.PollForAllAxes())
			{
				yield return controllerPollingInfo2;
			}
			enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00005AD1 File Offset: 0x00003CD1
		public override IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				yield break;
			}
			foreach (ControllerPollingInfo controllerPollingInfo in this.uhwcDlufOyopVuaGhcsgnRaWWZhG())
			{
				yield return controllerPollingInfo;
			}
			IEnumerator<ControllerPollingInfo> enumerator = null;
			foreach (ControllerPollingInfo controllerPollingInfo2 in this.PollForAllAxes())
			{
				yield return controllerPollingInfo2;
			}
			enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00005AE1 File Offset: 0x00003CE1
		public IEnumerable<ControllerPollingInfo> PollForAllAxes()
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				yield break;
			}
			base.UpdatePollingFrameTracking();
			this.BZKtAeaVoigIWokiIuLuXnLkUqHy();
			int num2;
			for (int i = 0; i < this._axisCount; i = num2 + 1)
			{
				Pole pole;
				int num;
				if (this.IsPolledAxisActive(i, out pole, out num))
				{
					yield return new ControllerPollingInfo(true, -1, this.id, this._name, this._type, ControllerElementType.Axis, i, pole, this.WGnseNgKihPuTwMSEeDkNInQXGEb.GetElementIdentifierName(num), num, KeyCode.None);
				}
				num2 = i;
			}
			yield break;
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00033EA0 File Offset: 0x000320A0
		private void BZKtAeaVoigIWokiIuLuXnLkUqHy()
		{
			if (this.InlcndydJcGQxLdcnyxlpvFxoAKP == null)
			{
				this.InlcndydJcGQxLdcnyxlpvFxoAKP = new float[this._axisCount];
			}
			if (this.WcWoumfMigeejCwVwqPaGscuaJaJ != this.LqJGRnNHcrANlJQeIREaUGMmeUTj)
			{
				this.LqJGRnNHcrANlJQeIREaUGMmeUTj = this.WcWoumfMigeejCwVwqPaGscuaJaJ;
				UpdateLoopType currentUpdateLoop = ReInput.currentUpdateLoop;
				for (int i = 0; i < this._axisCount; i++)
				{
					this.InlcndydJcGQxLdcnyxlpvFxoAKP[i] = this.axes[i].SowOKJRemKGQXusTBFOaIQTdxSdIA(currentUpdateLoop, this._calibrationMap.GetAxis(i));
				}
			}
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00033F1C File Offset: 0x0003211C
		protected virtual bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (this.axes[index].fzzkLLIistIuAlLCPzLMFEPVKHOk != null)
			{
				if (this.axes[index].fzzkLLIistIuAlLCPzLMFEPVKHOk._excludeFromPolling)
				{
					return false;
				}
				if (this.axes[index].fzzkLLIistIuAlLCPzLMFEPVKHOk._dataFormat == AxisCoordinateMode.Relative)
				{
					return false;
				}
			}
			float value = this.axes[index].SowOKJRemKGQXusTBFOaIQTdxSdIA(ReInput.currentUpdateLoop, this._calibrationMap.GetAxis(index)) - this.InlcndydJcGQxLdcnyxlpvFxoAKP[index];
			if (MathTools.Abs(value) <= this.axes[index].ZQoOPuaFhStRTYOlYriHWUJshfEj)
			{
				return false;
			}
			pole = ((MathTools.Sign(value) >= 0f) ? Pole.Positive : Pole.Negative);
			elementIdentifierId = this.WGnseNgKihPuTwMSEeDkNInQXGEb.axisElementIdentifierIds[index];
			return elementIdentifierId >= 0;
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00005AF1 File Offset: 0x00003CF1
		public bool ImportCalibrationMapFromXmlString(string xmlString)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			return this.calibrationMap.ImportXmlString(xmlString);
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00005B1A File Offset: 0x00003D1A
		public bool ImportCalibrationMapFromJsonString(string jsonString)
		{
			if (ReInput._id != this.SISUIQtlCHkLdwsmdeqFquyXrGcw)
			{
				ReInput.CheckInitialized(this.SISUIQtlCHkLdwsmdeqFquyXrGcw);
				return false;
			}
			return this.calibrationMap.ImportJsonString(jsonString);
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00033FD4 File Offset: 0x000321D4
		internal virtual void HNyKctIlBYbvsLaQmuRrJcfvYARm(UpdateLoopType A_1)
		{
			base.FQTBjLASwKIywYemFGwowQCkCzxHA(A_1);
			bool flag = ReInput.IsInputAllowed(this._type);
			bool flag2 = this._type == ControllerType.Joystick || this._type == ControllerType.Custom;
			bool flag3 = this._type == ControllerType.Joystick && ReInput.checkNeverPressed;
			bool flag4 = this._type == ControllerType.Joystick && !this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb.hasReceivedInput;
			for (int i = 0; i < this._axisCount; i++)
			{
				this.axes[i].znxiAoQjQzZirXYdmKafTWVfxAfK(A_1);
				if (!flag || flag4 || (flag3 && !this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb.axisHasBeenPressedOSXLinux[i]))
				{
					this.axes[i].valueRaw = this._calibrationMap.GetAxis(i).calibratedZero;
					this.axes[i].WGNjnPthNHRYKMPNuVIrALqFUfyc();
				}
				else
				{
					this.axes[i].valueRaw = this.ydAtmTGPnVEBcanqXjmfnQCYnoGgb.axisValues[i];
					if (flag2)
					{
						this.axes[i].FEvBJkPZnMrqaaBDVlPNNBufpbuo(this._calibrationMap.GetAxis(i));
					}
					else
					{
						this.axes[i].WaNlEwLGWlEHuFVBsAkSFrvJMQTaA();
					}
				}
			}
			for (int j = 0; j < this._axis2DCount; j++)
			{
				this.axes2D[j].pwFxdqtVCppluMaoszqiCANFgETr();
			}
			for (int k = 0; k < this._axisCount; k++)
			{
				this.axes[k].vvllVrmPmGSfmAiPKWpLKAaZJcve();
			}
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00034140 File Offset: 0x00032340
		internal bool tsUovSoTtpHiriVRiTsSXWemlOhi(ActionElementMap A_1, int A_2, bool A_3, bool A_4, out float A_5)
		{
			A_5 = 0f;
			ControllerElementType elementType = A_1._elementType;
			if (A_2 != A_1._actionId)
			{
				return false;
			}
			int mRCBQDgzARDPVbNsvhiBadcDxEwTB = A_1.mRCBQDgzARDPVbNsvhiBadcDxEwTB;
			if (mRCBQDgzARDPVbNsvhiBadcDxEwTB < 0 || mRCBQDgzARDPVbNsvhiBadcDxEwTB >= this._axisCount)
			{
				return false;
			}
			float num;
			if (A_4)
			{
				num = (A_3 ? this.axes[mRCBQDgzARDPVbNsvhiBadcDxEwTB].valueRawPrev : this.axes[mRCBQDgzARDPVbNsvhiBadcDxEwTB].valuePrev);
			}
			else
			{
				num = (A_3 ? this.axes[mRCBQDgzARDPVbNsvhiBadcDxEwTB].valueRaw : this.axes[mRCBQDgzARDPVbNsvhiBadcDxEwTB].value);
			}
			if (MathTools.Approximately(num, 0f))
			{
				return true;
			}
			if (elementType == ControllerElementType.Axis)
			{
				if (A_1._axisRange == AxisRange.Full)
				{
					if (A_1._invert)
					{
						num *= -1f;
					}
				}
				else
				{
					bool flag = MathTools.Sign(num) > 0f;
					if (flag && A_1._axisRange == AxisRange.Positive)
					{
						num = ((num >= 0f) ? num : 0f);
						if (A_1._axisContribution == Pole.Negative)
						{
							num *= -1f;
						}
					}
					else if (!flag && A_1._axisRange == AxisRange.Negative)
					{
						num = ((num <= 0f) ? num : 0f);
						if (A_1._axisContribution == Pole.Positive)
						{
							num *= -1f;
						}
					}
					else
					{
						num = 0f;
					}
				}
			}
			else if (elementType == ControllerElementType.Button && A_1._axisContribution == Pole.Negative)
			{
				num *= -1f;
			}
			A_5 = num;
			return true;
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0003428C File Offset: 0x0003248C
		internal virtual void aqFbtCGUJtISBcTcIjcjmmGUlozqb(ControllerMap A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			ControllerMapWithAxes controllerMapWithAxes = A_1 as ControllerMapWithAxes;
			if (controllerMapWithAxes == null)
			{
				Logger.LogWarning("Map type must inherit from ControllerMapWithAxes!");
				return;
			}
			base.VswFFcfRUHqPtFHydytpQrxVsYK(A_1);
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			for (int i = 0; i < axisMaps.Count; i++)
			{
				this.ZIaqgsDccGvTITgnjUFeFXRKbtuj(A_1, axisMaps[i]);
			}
			for (int j = axisMaps.Count - 1; j >= 0; j--)
			{
				if (axisMaps[j].elementIndex < 0)
				{
					A_1.DeleteElementMap(axisMaps[j].pGMbotKVdjNowDvSSfgThIWDmLSHB);
				}
			}
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00005B43 File Offset: 0x00003D43
		internal virtual void IRfNkxgPnVgkxqfdPtcJAkzabDLEA(ControllerMap A_1, ActionElementMap A_2)
		{
			if (A_2 == null)
			{
				return;
			}
			base.ZIaqgsDccGvTITgnjUFeFXRKbtuj(A_1, A_2);
			if (A_2._elementType != ControllerElementType.Axis)
			{
				return;
			}
			A_2.YmjBUAFlEbXvUpfGfovFCfjkhaLrc(A_1);
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00034314 File Offset: 0x00032514
		internal void uGSPQHjHvphynelfZpJNYIuXmcT()
		{
			for (int i = 0; i < this.axisCount; i++)
			{
				SpecialAxisType specialAxisType = this.axes[i].fzzkLLIistIuAlLCPzLMFEPVKHOk._specialAxisType;
				if (specialAxisType != SpecialAxisType.None)
				{
					if (specialAxisType != SpecialAxisType.Throttle)
					{
						throw new NotImplementedException();
					}
					this._calibrationMap.Axes[i].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(ReInput.configVars.throttleCalibrationMode);
				}
				else
				{
					this._calibrationMap.Axes[i].calibrationMode = AlternateAxisCalibrationType.Default;
				}
			}
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00034394 File Offset: 0x00032594
		internal virtual void xSsMiNKHGFcrTjlxQnjHqjKlHSWZ()
		{
			base.teTpHyJcIRafhlIJVTCUfrhAktlq();
			for (int i = 0; i < this._axisCount; i++)
			{
				if (this.axes[i] != null)
				{
					this.axes[i].Reset();
				}
			}
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x000343D0 File Offset: 0x000325D0
		[CompilerGenerated]
		private int SsjVFhbeLeyxIHEIhCXeNqJhdtSm(int A_1)
		{
			IAxisCalibrationIndexMap axisCalibrationIndexMap = base.extension as IAxisCalibrationIndexMap;
			if (axisCalibrationIndexMap != null)
			{
				return axisCalibrationIndexMap.GetMappedAxisIndex(A_1);
			}
			return A_1;
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00005B61 File Offset: 0x00003D61
		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ControllerPollingInfo> RFEThRMDkfTKMGzRSBolMzKexLOH()
		{
			return base.PollForAllElements();
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00005B69 File Offset: 0x00003D69
		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ControllerPollingInfo> uhwcDlufOyopVuaGhcsgnRaWWZhG()
		{
			return base.PollForAllElementsDown();
		}

		// Token: 0x040002F8 RID: 760
		protected readonly int _axisCount;

		// Token: 0x040002F9 RID: 761
		protected readonly int _axis2DCount;

		// Token: 0x040002FA RID: 762
		protected readonly Controller.Axis[] axes;

		// Token: 0x040002FB RID: 763
		protected readonly ReadOnlyCollection<Controller.Axis> axes_readOnly;

		// Token: 0x040002FC RID: 764
		protected readonly Controller.Axis2D[] axes2D;

		// Token: 0x040002FD RID: 765
		protected readonly ReadOnlyCollection<Controller.Axis2D> axes2D_readOnly;

		// Token: 0x040002FE RID: 766
		protected readonly CalibrationMap _calibrationMap;

		// Token: 0x040002FF RID: 767
		private float[] InlcndydJcGQxLdcnyxlpvFxoAKP;

		// Token: 0x04000300 RID: 768
		private uint LqJGRnNHcrANlJQeIREaUGMmeUTj = uint.MaxValue;

		// Token: 0x04000301 RID: 769
		private Func<int, int> XJnDrZlXJpiyahbEmvURnYBGJPEM;
	}
}
