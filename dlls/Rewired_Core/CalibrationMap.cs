using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	// Token: 0x02000113 RID: 275
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public sealed class CalibrationMap
	{
		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06000A05 RID: 2565 RVA: 0x0000A267 File Offset: 0x00008467
		public IList<AxisCalibration> Axes
		{
			get
			{
				return this.xvWUubGXsyPUBHdDMkfyiKlDehBBA;
			}
		}

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06000A06 RID: 2566 RVA: 0x0000A26F File Offset: 0x0000846F
		public int axisCount
		{
			get
			{
				if (this.LfuAZydhDmkIuASLBBmzNswBKRqN == null)
				{
					return 0;
				}
				return this.LfuAZydhDmkIuASLBBmzNswBKRqN.Length;
			}
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x0000A283 File Offset: 0x00008483
		private CalibrationMap()
		{
			this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA = ReInput.id;
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x00046BD4 File Offset: 0x00044DD4
		internal CalibrationMap(AxisCalibrationData[] A_1, Func<int, int> A_2) : this()
		{
			int num = (A_1 != null) ? A_1.Length : 0;
			this.LfuAZydhDmkIuASLBBmzNswBKRqN = new AxisCalibration[num];
			this.popHnPdiOdnewOUkEExmdAKGVTXi = new MappedArray<AxisCalibration>(this.LfuAZydhDmkIuASLBBmzNswBKRqN, A_2);
			for (int i = 0; i < num; i++)
			{
				this.LfuAZydhDmkIuASLBBmzNswBKRqN[i] = new AxisCalibration(A_1[i]);
			}
			this.xvWUubGXsyPUBHdDMkfyiKlDehBBA = new ReadOnlyCollection<AxisCalibration>(this.popHnPdiOdnewOUkEExmdAKGVTXi);
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x0000A296 File Offset: 0x00008496
		public CalibrationMap(AxisCalibration[] A_1) : this()
		{
			this.LfuAZydhDmkIuASLBBmzNswBKRqN = A_1;
			this.popHnPdiOdnewOUkEExmdAKGVTXi = new MappedArray<AxisCalibration>(this.LfuAZydhDmkIuASLBBmzNswBKRqN, null);
			this.xvWUubGXsyPUBHdDMkfyiKlDehBBA = new ReadOnlyCollection<AxisCalibration>(this.popHnPdiOdnewOUkEExmdAKGVTXi);
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x00046C40 File Offset: 0x00044E40
		public void Reset()
		{
			if (ReInput._id != this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA)
			{
				ReInput.CheckInitialized(this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA);
				return;
			}
			for (int i = 0; i < this.LfuAZydhDmkIuASLBBmzNswBKRqN.Length; i++)
			{
				this.LfuAZydhDmkIuASLBBmzNswBKRqN[i].Reset();
			}
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x0000A2C8 File Offset: 0x000084C8
		public AxisCalibration GetAxis(int index)
		{
			if (ReInput._id != this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA)
			{
				ReInput.CheckInitialized(this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA);
				return null;
			}
			if (index < 0 || index >= this.LfuAZydhDmkIuASLBBmzNswBKRqN.Length)
			{
				return null;
			}
			return this.popHnPdiOdnewOUkEExmdAKGVTXi[index];
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x00046C88 File Offset: 0x00044E88
		public float GetCalibratedValue(int axisIndex, float value)
		{
			if (ReInput._id != this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA)
			{
				ReInput.CheckInitialized(this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA);
				return 0f;
			}
			if (axisIndex < 0 || axisIndex >= this.LfuAZydhDmkIuASLBBmzNswBKRqN.Length)
			{
				return value;
			}
			return this.popHnPdiOdnewOUkEExmdAKGVTXi[axisIndex].GetCalibratedValue(value);
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x00046CD8 File Offset: 0x00044ED8
		public bool SetAxisData(int index, AxisCalibrationData data)
		{
			if (ReInput._id != this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA)
			{
				ReInput.CheckInitialized(this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA);
				return false;
			}
			if (index < 0 || index >= this.LfuAZydhDmkIuASLBBmzNswBKRqN.Length)
			{
				return false;
			}
			this.popHnPdiOdnewOUkEExmdAKGVTXi[index].SetData(data);
			return true;
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x00046D24 File Offset: 0x00044F24
		public AxisCalibrationData GetAxisData(int index)
		{
			if (ReInput._id != this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA)
			{
				ReInput.CheckInitialized(this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA);
				return default(AxisCalibrationData);
			}
			if (index < 0 || index >= this.LfuAZydhDmkIuASLBBmzNswBKRqN.Length)
			{
				return default(AxisCalibrationData);
			}
			return this.popHnPdiOdnewOUkEExmdAKGVTXi[index].GetData();
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x00046D80 File Offset: 0x00044F80
		internal void CopyFrom(CalibrationMap map, bool copyHardwareDeadzone)
		{
			if (map == null)
			{
				return;
			}
			if (map.LfuAZydhDmkIuASLBBmzNswBKRqN.Length != this.LfuAZydhDmkIuASLBBmzNswBKRqN.Length)
			{
				Logger.LogError("Calibration map data does not match the number of elements in the hardware!");
				return;
			}
			for (int i = 0; i < this.LfuAZydhDmkIuASLBBmzNswBKRqN.Length; i++)
			{
				this.LfuAZydhDmkIuASLBBmzNswBKRqN[i].CopyFrom(map.LfuAZydhDmkIuASLBBmzNswBKRqN[i], copyHardwareDeadzone);
			}
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x00046DD8 File Offset: 0x00044FD8
		public string ToXmlString()
		{
			if (ReInput._id != this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA)
			{
				ReInput.CheckInitialized(this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA);
				return string.Empty;
			}
			string empty = string.Empty;
			try
			{
				return this.IXmcFjsPSFZDgvADedhYFhBzNZIi().ToXmlString(true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to XML! " + ex.Message);
			}
			return empty;
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x00046E44 File Offset: 0x00045044
		public string ToJsonString()
		{
			if (ReInput._id != this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA)
			{
				ReInput.CheckInitialized(this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA);
				return string.Empty;
			}
			try
			{
				return this.IXmcFjsPSFZDgvADedhYFhBzNZIi().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing CalibrationMap to JSON! " + ex.Message);
			}
			return string.Empty;
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x00046EB0 File Offset: 0x000450B0
		public bool ImportXmlString(string xmlString)
		{
			if (ReInput._id != this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA)
			{
				ReInput.CheckInitialized(this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA);
				return false;
			}
			if (string.IsNullOrEmpty(xmlString))
			{
				return false;
			}
			try
			{
				this.OusEHZAhvqgwRQXzGrLvmtvpassbA(SerializedObject.FromXml(base.GetType(), xmlString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from XML! " + ex.Message);
			}
			return false;
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x00046F24 File Offset: 0x00045124
		public bool ImportJsonString(string jsonString)
		{
			if (ReInput._id != this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA)
			{
				ReInput.CheckInitialized(this.SdFkBgfkHlVCSQdBtqZbmiwvlLtA);
				return false;
			}
			if (string.IsNullOrEmpty(jsonString))
			{
				return false;
			}
			try
			{
				this.OusEHZAhvqgwRQXzGrLvmtvpassbA(SerializedObject.FromJson(base.GetType(), jsonString));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error creating CalibrationMap from JSON! " + ex.Message);
			}
			return false;
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x00046F98 File Offset: 0x00045198
		private SerializedObject IXmcFjsPSFZDgvADedhYFhBzNZIi()
		{
			SerializedObject serializedObject = new SerializedObject(base.GetType(), SerializedObject.ObjectType.Object);
			serializedObject.Add<int>("dataVersion", 4, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo = new SerializedObject.XmlInfo();
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.LNgACPpwshkKROSusbBaVylbemLP
			{
				icHQGefQbedChDWtubHCUkbucRzbb = "dataVersion",
				hQsdIPBPqieQLwIOlxlBAUDVYhDFA = 4.ToString()
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.LNgACPpwshkKROSusbBaVylbemLP
			{
				RYjXkEgviKdbPKjefiQAbwFNRXTlA = "xmlns",
				icHQGefQbedChDWtubHCUkbucRzbb = "xsi",
				YulEumEWpPNPEIqyPwfvMWtcRrsFA = null,
				hQsdIPBPqieQLwIOlxlBAUDVYhDFA = "http://www.w3.org/2001/XMLSchema-instance"
			});
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.LNgACPpwshkKROSusbBaVylbemLP
			{
				RYjXkEgviKdbPKjefiQAbwFNRXTlA = "xsi",
				icHQGefQbedChDWtubHCUkbucRzbb = "schemaLocation",
				YulEumEWpPNPEIqyPwfvMWtcRrsFA = null,
				hQsdIPBPqieQLwIOlxlBAUDVYhDFA = string.Format("{0} {1}{2}{3}{4}{5}", new object[]
				{
					"http://guavaman.com/rewired",
					"http://guavaman.com/schemas/rewired/",
					"1.3",
					"/",
					base.GetType().Name,
					".xsd"
				})
			});
			List<object> list = new List<object>();
			serializedObject.Add<List<object>>("axes", list, SerializedObject.FieldOptions.None);
			int num = (this.LfuAZydhDmkIuASLBBmzNswBKRqN != null) ? this.LfuAZydhDmkIuASLBBmzNswBKRqN.Length : 0;
			for (int i = 0; i < num; i++)
			{
				if (this.LfuAZydhDmkIuASLBBmzNswBKRqN[i] != null)
				{
					list.Add(this.LfuAZydhDmkIuASLBBmzNswBKRqN[i].ExportData());
				}
			}
			return serializedObject;
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x00047114 File Offset: 0x00045314
		private void OusEHZAhvqgwRQXzGrLvmtvpassbA(SerializedObject A_1)
		{
			SerializedObject serializedObject = null;
			if (A_1.TryGetDeserializedValueByRef<SerializedObject>("axes", ref serializedObject))
			{
				int num = MathTools.Min(serializedObject.count, this.LfuAZydhDmkIuASLBBmzNswBKRqN.Length);
				for (int i = 0; i < num; i++)
				{
					if (serializedObject[i].value is SerializedObject && this.LfuAZydhDmkIuASLBBmzNswBKRqN[i] != null)
					{
						this.LfuAZydhDmkIuASLBBmzNswBKRqN[i].Import((SerializedObject)serializedObject[i].value);
					}
				}
			}
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x0000A302 File Offset: 0x00008502
		internal Vector2 GetCalibrated2DValue(int xAxisIndex, int yAxisIndex, float valueRawX, float valueRawY, DeadZone2DType deadZoneType, AxisSensitivity2DType sensitivityType)
		{
			return Axis2DCalibration.GetCalibrated2DValue(valueRawX, valueRawY, this.GetAxis(xAxisIndex), this.GetAxis(yAxisIndex), deadZoneType, sensitivityType);
		}

		// Token: 0x04000752 RID: 1874
		private AxisCalibration[] LfuAZydhDmkIuASLBBmzNswBKRqN;

		// Token: 0x04000753 RID: 1875
		private MappedArray<AxisCalibration> popHnPdiOdnewOUkEExmdAKGVTXi;

		// Token: 0x04000754 RID: 1876
		private IList<AxisCalibration> xvWUubGXsyPUBHdDMkfyiKlDehBBA;

		// Token: 0x04000755 RID: 1877
		private readonly int SdFkBgfkHlVCSQdBtqZbmiwvlLtA;
	}
}
