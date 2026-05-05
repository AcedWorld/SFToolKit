using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired
{
	// Token: 0x02000121 RID: 289
	public sealed class ControllerMapEnabler
	{
		// Token: 0x06000B19 RID: 2841 RVA: 0x0000B05F File Offset: 0x0000925F
		internal ControllerMapEnabler(Player A_1, ControllerMapEnabler.YqpaJJElEihfpIGutrHkMZgMkOuC A_2)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("player");
			}
			if (A_2 == null)
			{
				throw new ArgumentNullException("startingSettings");
			}
			this.ympmlAVJzntFrkNIsoAttzFzLxho = ReInput.id;
			this.gqGLbLOQYQLwCJdWqiKOdMEofydR = A_1;
			this.nrOrEEHWaoNOKaKqdnYSXGRBydzF = A_2;
		}

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x06000B1A RID: 2842 RVA: 0x0000B09C File Offset: 0x0000929C
		// (set) Token: 0x06000B1B RID: 2843 RVA: 0x0000B0A4 File Offset: 0x000092A4
		public bool enabled
		{
			get
			{
				return this.UapbdhDcwUEEudwhzvoFHZNddPhcA;
			}
			set
			{
				this.UapbdhDcwUEEudwhzvoFHZNddPhcA = value;
				if (value)
				{
					this.Apply();
				}
			}
		}

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x06000B1C RID: 2844 RVA: 0x0000B0B6 File Offset: 0x000092B6
		// (set) Token: 0x06000B1D RID: 2845 RVA: 0x0000B0BE File Offset: 0x000092BE
		public List<ControllerMapEnabler.RuleSet> ruleSets
		{
			get
			{
				return this.vMpZVNJQqbdprECjMjvpwSZRYQBi;
			}
			set
			{
				if (value == null)
				{
					value = new List<ControllerMapEnabler.RuleSet>();
				}
				this.vMpZVNJQqbdprECjMjvpwSZRYQBi = value;
			}
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x00048894 File Offset: 0x00046A94
		public void Apply()
		{
			if (ReInput._id != this.ympmlAVJzntFrkNIsoAttzFzLxho)
			{
				ReInput.CheckInitialized(this.ympmlAVJzntFrkNIsoAttzFzLxho);
				return;
			}
			if (!this.UapbdhDcwUEEudwhzvoFHZNddPhcA)
			{
				return;
			}
			if (this.vMpZVNJQqbdprECjMjvpwSZRYQBi == null)
			{
				return;
			}
			int count = this.vMpZVNJQqbdprECjMjvpwSZRYQBi.Count;
			if (count == 0)
			{
				return;
			}
			using (TempListPool.TList<ControllerMap> tlist = TempListPool.GetTList<ControllerMap>())
			{
				List<ControllerMap> list = tlist.list;
				this.gqGLbLOQYQLwCJdWqiKOdMEofydR.controllers.maps.GetAllMaps(list);
				int count2 = list.Count;
				for (int i = 0; i < count; i++)
				{
					ControllerMapEnabler.RuleSet ruleSet = this.vMpZVNJQqbdprECjMjvpwSZRYQBi[i];
					if (ruleSet != null && ruleSet.enabled)
					{
						int count3 = ruleSet.Count;
						for (int j = 0; j < count3; j++)
						{
							ControllerMapEnabler.Rule rule = ruleSet[j];
							if (rule != null)
							{
								for (int k = 0; k < count2; k++)
								{
									ControllerMap controllerMap = list[k];
									if (controllerMap.enabled != rule.enable && rule.Matches(controllerMap))
									{
										controllerMap.enabled = rule.enable;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x000489C4 File Offset: 0x00046BC4
		public void LoadDefaults()
		{
			if (ReInput._id != this.ympmlAVJzntFrkNIsoAttzFzLxho)
			{
				ReInput.CheckInitialized(this.ympmlAVJzntFrkNIsoAttzFzLxho);
				return;
			}
			List<ControllerMapEnabler.RuleSet> list = new List<ControllerMapEnabler.RuleSet>();
			int num = (this.nrOrEEHWaoNOKaKqdnYSXGRBydzF != null && this.nrOrEEHWaoNOKaKqdnYSXGRBydzF.bqHtFIxpavLkErbgxTBMWGEDWbYB != null) ? this.nrOrEEHWaoNOKaKqdnYSXGRBydzF.bqHtFIxpavLkErbgxTBMWGEDWbYB.Length : 0;
			for (int i = 0; i < num; i++)
			{
				ControllerMapEnabler.RuleSet controllerMapEnablerRuleSetInstance = ReInput.mapping.GetControllerMapEnablerRuleSetInstance(this.nrOrEEHWaoNOKaKqdnYSXGRBydzF.bqHtFIxpavLkErbgxTBMWGEDWbYB[i].BDveskHydnddWigsUMoiWbCyxPyOA);
				if (controllerMapEnablerRuleSetInstance == null)
				{
					Logger.LogError("Invalid Map Enabler Manager Rule Set is assigned to Player. This should not be possible. If you are seeing this error, this is a sign of serialized data corruption, usually caused by a bad source control merge.");
				}
				else
				{
					controllerMapEnablerRuleSetInstance.enabled = this.nrOrEEHWaoNOKaKqdnYSXGRBydzF.bqHtFIxpavLkErbgxTBMWGEDWbYB[i].lHwbtaVQOiciQAdrqQuDlHJSwVPIA;
					list.Add(controllerMapEnablerRuleSetInstance);
				}
			}
			if (this.nrOrEEHWaoNOKaKqdnYSXGRBydzF != null)
			{
				this.UapbdhDcwUEEudwhzvoFHZNddPhcA = this.nrOrEEHWaoNOKaKqdnYSXGRBydzF.FbdYHxRmampVzfgEDCVwRNPVYABN;
			}
			this.vMpZVNJQqbdprECjMjvpwSZRYQBi = list;
			this.Apply();
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x00048A94 File Offset: 0x00046C94
		public string ToXmlString()
		{
			if (ReInput._id != this.ympmlAVJzntFrkNIsoAttzFzLxho)
			{
				ReInput.CheckInitialized(this.ympmlAVJzntFrkNIsoAttzFzLxho);
				return string.Empty;
			}
			string result;
			try
			{
				result = this.zPDRDxkbmGFATDUBhZlybWVZKQam().ToXmlString(true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + base.GetType().Name + " to XML. " + ex.Message);
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x00048B10 File Offset: 0x00046D10
		public string ToJsonString()
		{
			if (ReInput._id != this.ympmlAVJzntFrkNIsoAttzFzLxho)
			{
				ReInput.CheckInitialized(this.ympmlAVJzntFrkNIsoAttzFzLxho);
				return string.Empty;
			}
			string result;
			try
			{
				result = this.zPDRDxkbmGFATDUBhZlybWVZKQam().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + base.GetType().Name + " to JSON. " + ex.Message);
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x00048B8C File Offset: 0x00046D8C
		public bool ImportXml(string xmlString)
		{
			if (ReInput._id != this.ympmlAVJzntFrkNIsoAttzFzLxho)
			{
				ReInput.CheckInitialized(this.ympmlAVJzntFrkNIsoAttzFzLxho);
				return false;
			}
			bool result;
			try
			{
				this.qJMHSWqjFXRSDHNYfVqDeDtptVis(SerializedObject.FromXml(base.GetType(), xmlString));
				this.Apply();
				result = true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error importing " + base.GetType().Name + " data from XML. " + ex.Message);
				result = false;
			}
			return result;
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x00048C10 File Offset: 0x00046E10
		public bool ImportJson(string jsonString)
		{
			if (ReInput._id != this.ympmlAVJzntFrkNIsoAttzFzLxho)
			{
				ReInput.CheckInitialized(this.ympmlAVJzntFrkNIsoAttzFzLxho);
				return false;
			}
			bool result;
			try
			{
				this.qJMHSWqjFXRSDHNYfVqDeDtptVis(SerializedObject.FromJson(base.GetType(), jsonString));
				this.Apply();
				result = true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error importing " + base.GetType().Name + " data from JSON. " + ex.Message);
				result = false;
			}
			return result;
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x00048C94 File Offset: 0x00046E94
		private SerializedObject zPDRDxkbmGFATDUBhZlybWVZKQam()
		{
			SerializedObject serializedObject = new SerializedObject(base.GetType(), SerializedObject.ObjectType.Object);
			this.yNuidTEwqgpZJtJvANiOGWUHplzA(serializedObject);
			return serializedObject;
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x00048CB8 File Offset: 0x00046EB8
		private void yNuidTEwqgpZJtJvANiOGWUHplzA(SerializedObject A_1)
		{
			if (A_1.xmlInfo == null)
			{
				A_1.xmlInfo = new SerializedObject.XmlInfo();
			}
			A_1.Add<int>("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			A_1.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.LNgACPpwshkKROSusbBaVylbemLP
			{
				icHQGefQbedChDWtubHCUkbucRzbb = "dataVersion",
				hQsdIPBPqieQLwIOlxlBAUDVYhDFA = 1.ToString()
			});
			A_1.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.LNgACPpwshkKROSusbBaVylbemLP
			{
				RYjXkEgviKdbPKjefiQAbwFNRXTlA = "xmlns",
				icHQGefQbedChDWtubHCUkbucRzbb = "xsi",
				YulEumEWpPNPEIqyPwfvMWtcRrsFA = null,
				hQsdIPBPqieQLwIOlxlBAUDVYhDFA = "http://www.w3.org/2001/XMLSchema-instance"
			});
			A_1.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.LNgACPpwshkKROSusbBaVylbemLP
			{
				RYjXkEgviKdbPKjefiQAbwFNRXTlA = "xsi",
				icHQGefQbedChDWtubHCUkbucRzbb = "schemaLocation",
				YulEumEWpPNPEIqyPwfvMWtcRrsFA = null,
				hQsdIPBPqieQLwIOlxlBAUDVYhDFA = string.Format("{0} {1}{2}{3}{4}{5}", new object[]
				{
					"http://guavaman.com/rewired",
					"http://guavaman.com/schemas/rewired/",
					"1.0",
					"/",
					base.GetType().Name,
					".xsd"
				})
			});
			A_1.Add<bool>("enabled", this.UapbdhDcwUEEudwhzvoFHZNddPhcA, SerializedObject.FieldOptions.None);
			A_1.Add<List<ControllerMapEnabler.RuleSet>>("ruleSets", this.vMpZVNJQqbdprECjMjvpwSZRYQBi, SerializedObject.FieldOptions.None);
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x00048DF8 File Offset: 0x00046FF8
		private bool qJMHSWqjFXRSDHNYfVqDeDtptVis(SerializedObject A_1)
		{
			this.UapbdhDcwUEEudwhzvoFHZNddPhcA = false;
			this.vMpZVNJQqbdprECjMjvpwSZRYQBi = null;
			A_1.TryGetDeserializedValueByRef<bool>("enabled", ref this.UapbdhDcwUEEudwhzvoFHZNddPhcA);
			List<ControllerMapEnabler.RuleSet> list = new List<ControllerMapEnabler.RuleSet>();
			A_1.TryGetDeserializedValueByRef<List<ControllerMapEnabler.RuleSet>>("ruleSets", ref list);
			this.vMpZVNJQqbdprECjMjvpwSZRYQBi = list;
			return true;
		}

		// Token: 0x040007AF RID: 1967
		private bool UapbdhDcwUEEudwhzvoFHZNddPhcA;

		// Token: 0x040007B0 RID: 1968
		private Player gqGLbLOQYQLwCJdWqiKOdMEofydR;

		// Token: 0x040007B1 RID: 1969
		private ControllerMapEnabler.YqpaJJElEihfpIGutrHkMZgMkOuC nrOrEEHWaoNOKaKqdnYSXGRBydzF;

		// Token: 0x040007B2 RID: 1970
		private readonly int ympmlAVJzntFrkNIsoAttzFzLxho;

		// Token: 0x040007B3 RID: 1971
		private List<ControllerMapEnabler.RuleSet> vMpZVNJQqbdprECjMjvpwSZRYQBi;

		// Token: 0x02000122 RID: 290
		[Preserve]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Rule : IDeepCloneable
		{
			// Token: 0x06000B27 RID: 2855 RVA: 0x0000B0D1 File Offset: 0x000092D1
			public Rule()
			{
				this._enable = true;
				this._categoryIds = EmptyObjects<int>.array;
				this._layoutIds = EmptyObjects<int>.array;
				this._controllerSetSelector = new ControllerSetSelector(ControllerSetSelector.Type.ControllerType);
			}

			// Token: 0x06000B28 RID: 2856 RVA: 0x00048E44 File Offset: 0x00047044
			public Rule(ControllerMapEnabler.Rule A_1)
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("source");
				}
				this._tag = A_1._tag;
				this._enable = A_1._enable;
				this._categoryIds = ArrayTools.ShallowCopy<int>(A_1._categoryIds);
				this._layoutIds = ArrayTools.ShallowCopy<int>(A_1._layoutIds);
				this._controllerSetSelector = MiscTools.DeepClone<ControllerSetSelector>(A_1._controllerSetSelector);
				this._preInitCategoryNames = ArrayTools.ShallowCopy<string>(A_1._preInitCategoryNames);
				this._preInitLayoutNames = ArrayTools.ShallowCopy<string>(A_1._preInitLayoutNames);
			}

			// Token: 0x06000B29 RID: 2857 RVA: 0x0000B102 File Offset: 0x00009302
			internal Rule(string A_1, bool A_2, int[] A_3, int[] A_4, ControllerSetSelector A_5)
			{
				this._tag = A_1;
				this._enable = A_2;
				this._categoryIds = A_3;
				this._layoutIds = A_4;
				this._controllerSetSelector = A_5;
			}

			// Token: 0x17000365 RID: 869
			// (get) Token: 0x06000B2A RID: 2858 RVA: 0x0000B12F File Offset: 0x0000932F
			internal bool appliesToAllLayouts
			{
				get
				{
					return this._layoutIds == null || this._layoutIds.Length == 0;
				}
			}

			// Token: 0x17000366 RID: 870
			// (get) Token: 0x06000B2B RID: 2859 RVA: 0x0000B145 File Offset: 0x00009345
			// (set) Token: 0x06000B2C RID: 2860 RVA: 0x0000B14D File Offset: 0x0000934D
			public string tag
			{
				get
				{
					return this._tag;
				}
				set
				{
					this._tag = value;
				}
			}

			// Token: 0x17000367 RID: 871
			// (get) Token: 0x06000B2D RID: 2861 RVA: 0x0000B156 File Offset: 0x00009356
			// (set) Token: 0x06000B2E RID: 2862 RVA: 0x0000B15E File Offset: 0x0000935E
			public bool enable
			{
				get
				{
					return this._enable;
				}
				set
				{
					this._enable = value;
				}
			}

			// Token: 0x17000368 RID: 872
			// (get) Token: 0x06000B2F RID: 2863 RVA: 0x00048ED4 File Offset: 0x000470D4
			// (set) Token: 0x06000B30 RID: 2864 RVA: 0x0000B167 File Offset: 0x00009367
			public ControllerSetSelector controllerSetSelector
			{
				get
				{
					ControllerSetSelector result;
					if ((result = this._controllerSetSelector) == null)
					{
						result = (this._controllerSetSelector = new ControllerSetSelector(ControllerSetSelector.Type.ControllerType));
					}
					return result;
				}
				set
				{
					if (value == null)
					{
						value = new ControllerSetSelector(ControllerSetSelector.Type.ControllerType);
					}
					this._controllerSetSelector = value;
				}
			}

			// Token: 0x17000369 RID: 873
			// (get) Token: 0x06000B31 RID: 2865 RVA: 0x00048EFC File Offset: 0x000470FC
			// (set) Token: 0x06000B32 RID: 2866 RVA: 0x0000B17B File Offset: 0x0000937B
			public int[] categoryIds
			{
				get
				{
					this.Initialize();
					int[] result;
					if ((result = this._categoryIds) == null)
					{
						result = (this._categoryIds = EmptyObjects<int>.array);
					}
					return result;
				}
				set
				{
					if (value == null)
					{
						value = EmptyObjects<int>.array;
					}
					this._categoryIds = value;
					this._preInitCategoryNames = null;
				}
			}

			// Token: 0x1700036A RID: 874
			// (get) Token: 0x06000B33 RID: 2867 RVA: 0x00048F28 File Offset: 0x00047128
			// (set) Token: 0x06000B34 RID: 2868 RVA: 0x0000B195 File Offset: 0x00009395
			public int[] layoutIds
			{
				get
				{
					this.Initialize();
					int[] result;
					if ((result = this._layoutIds) == null)
					{
						result = (this._layoutIds = EmptyObjects<int>.array);
					}
					return result;
				}
				set
				{
					if (value == null)
					{
						value = EmptyObjects<int>.array;
					}
					this._layoutIds = value;
					this._preInitLayoutNames = null;
					if (value != null || value.Length != 0)
					{
						this.CheckNoControllerTypeError();
					}
				}
			}

			// Token: 0x1700036B RID: 875
			// (get) Token: 0x06000B35 RID: 2869 RVA: 0x0000B1BC File Offset: 0x000093BC
			// (set) Token: 0x06000B36 RID: 2870 RVA: 0x0000B1DF File Offset: 0x000093DF
			public int categoryId
			{
				get
				{
					this.Initialize();
					if (this._categoryIds == null || this._categoryIds.Length == 0)
					{
						return -1;
					}
					return this.categoryIds[0];
				}
				set
				{
					if (value < 0)
					{
						this._categoryIds = EmptyObjects<int>.array;
					}
					else
					{
						if (this._categoryIds == null || this._categoryIds.Length == 0)
						{
							this._categoryIds = new int[1];
						}
						this._categoryIds[0] = value;
					}
					this._preInitCategoryNames = null;
				}
			}

			// Token: 0x1700036C RID: 876
			// (get) Token: 0x06000B37 RID: 2871 RVA: 0x0000B21F File Offset: 0x0000941F
			// (set) Token: 0x06000B38 RID: 2872 RVA: 0x00048F54 File Offset: 0x00047154
			public int layoutId
			{
				get
				{
					this.Initialize();
					if (this._layoutIds == null || this._layoutIds.Length == 0)
					{
						return -1;
					}
					return this.layoutIds[0];
				}
				set
				{
					if (value < 0)
					{
						this._layoutIds = EmptyObjects<int>.array;
					}
					else
					{
						if (this._layoutIds == null || this._layoutIds.Length == 0)
						{
							this._layoutIds = new int[1];
						}
						this._layoutIds[0] = value;
					}
					if (value >= 0)
					{
						this.CheckNoControllerTypeError();
					}
					this._preInitLayoutNames = null;
				}
			}

			// Token: 0x1700036D RID: 877
			// (get) Token: 0x06000B39 RID: 2873 RVA: 0x00048FAC File Offset: 0x000471AC
			// (set) Token: 0x06000B3A RID: 2874 RVA: 0x00049034 File Offset: 0x00047234
			public string[] categoryNames
			{
				get
				{
					if (!ReInput.isReady)
					{
						if (this._preInitCategoryNames == null)
						{
							return EmptyObjects<string>.array;
						}
						return this._preInitCategoryNames;
					}
					else
					{
						this.Initialize();
						if (this._categoryIds == null)
						{
							return EmptyObjects<string>.array;
						}
						string[] array = new string[this._categoryIds.Length];
						for (int i = 0; i < this._categoryIds.Length; i++)
						{
							InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(this._categoryIds[i]);
							array[i] = ((mapCategory != null) ? mapCategory.name : "INVALID");
						}
						return array;
					}
				}
				set
				{
					if (!ReInput.isReady)
					{
						this._preInitCategoryNames = ((value != null && value.Length != 0) ? value : null);
						this._categoryIds = EmptyObjects<int>.array;
						return;
					}
					if (value == null || value.Length == 0)
					{
						this._preInitCategoryNames = null;
						this._categoryIds = EmptyObjects<int>.array;
						return;
					}
					List<int> list = new List<int>(value.Length);
					for (int i = 0; i < value.Length; i++)
					{
						if (!string.IsNullOrEmpty(value[i]))
						{
							int mapCategoryId = ReInput.mapping.GetMapCategoryId(value[i]);
							if (mapCategoryId >= 0)
							{
								list.Add(mapCategoryId);
							}
							else
							{
								Logger.LogWarning("Map Category \"" + value[i] + "\" does not exist.");
							}
						}
					}
					this._categoryIds = list.ToArray();
				}
			}

			// Token: 0x1700036E RID: 878
			// (get) Token: 0x06000B3B RID: 2875 RVA: 0x000490E0 File Offset: 0x000472E0
			// (set) Token: 0x06000B3C RID: 2876 RVA: 0x00049170 File Offset: 0x00047370
			public string[] layoutNames
			{
				get
				{
					if (!ReInput.isReady)
					{
						if (this._preInitLayoutNames == null)
						{
							return EmptyObjects<string>.array;
						}
						return this._preInitLayoutNames;
					}
					else
					{
						this.Initialize();
						if (this._layoutIds == null)
						{
							return EmptyObjects<string>.array;
						}
						string[] array = new string[this._layoutIds.Length];
						for (int i = 0; i < this._layoutIds.Length; i++)
						{
							InputLayout layout = ReInput.mapping.GetLayout(this.controllerSetSelector.controllerType, this._layoutIds[i]);
							array[i] = ((layout != null) ? layout.name : "INVALID");
						}
						return array;
					}
				}
				set
				{
					if (!ReInput.isReady)
					{
						if (value != null && value.Length != 0)
						{
							this.CheckNoControllerTypeError();
						}
						this._preInitLayoutNames = ((value != null && value.Length != 0) ? value : null);
						this._layoutIds = EmptyObjects<int>.array;
						return;
					}
					if (value == null || value.Length == 0)
					{
						this._preInitLayoutNames = null;
						this._layoutIds = EmptyObjects<int>.array;
						return;
					}
					this.CheckNoControllerTypeError();
					List<int> list = new List<int>(value.Length);
					for (int i = 0; i < value.Length; i++)
					{
						if (!string.IsNullOrEmpty(value[i]))
						{
							int layoutId = ReInput.mapping.GetLayoutId(this.controllerSetSelector.controllerType, value[i]);
							if (layoutId >= 0)
							{
								list.Add(layoutId);
							}
							else
							{
								Logger.LogWarning("Layout \"" + value[i] + "\" does not exist.");
							}
						}
					}
					this._layoutIds = list.ToArray();
				}
			}

			// Token: 0x1700036F RID: 879
			// (get) Token: 0x06000B3D RID: 2877 RVA: 0x00049238 File Offset: 0x00047438
			// (set) Token: 0x06000B3E RID: 2878 RVA: 0x000492A4 File Offset: 0x000474A4
			public string categoryName
			{
				get
				{
					if (!ReInput.isReady)
					{
						if (this._preInitCategoryNames == null || this._preInitCategoryNames.Length == 0)
						{
							return null;
						}
						return this._preInitCategoryNames[0];
					}
					else
					{
						this.Initialize();
						if (this._categoryIds == null || this._categoryIds.Length == 0)
						{
							return null;
						}
						InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(this._categoryIds[0]);
						if (mapCategory == null)
						{
							return "INVALID";
						}
						return mapCategory.name;
					}
				}
				set
				{
					if (!ReInput.isReady)
					{
						object preInitCategoryNames;
						if (string.IsNullOrEmpty(value))
						{
							preInitCategoryNames = null;
						}
						else
						{
							(preInitCategoryNames = new string[1])[0] = value;
						}
						this._preInitCategoryNames = preInitCategoryNames;
						this._categoryIds = EmptyObjects<int>.array;
						return;
					}
					if (string.IsNullOrEmpty(value))
					{
						this._preInitCategoryNames = null;
						this._categoryIds = EmptyObjects<int>.array;
						return;
					}
					int mapCategoryId = ReInput.mapping.GetMapCategoryId(value);
					if (mapCategoryId >= 0)
					{
						this.categoryId = mapCategoryId;
						return;
					}
					Logger.LogWarning("Map Category \"" + value + "\" does not exist.");
				}
			}

			// Token: 0x17000370 RID: 880
			// (get) Token: 0x06000B3F RID: 2879 RVA: 0x00049328 File Offset: 0x00047528
			// (set) Token: 0x06000B40 RID: 2880 RVA: 0x000493A0 File Offset: 0x000475A0
			public string layoutName
			{
				get
				{
					if (!ReInput.isReady)
					{
						if (this._preInitLayoutNames == null || this._preInitLayoutNames.Length == 0)
						{
							return null;
						}
						return this._preInitLayoutNames[0];
					}
					else
					{
						this.Initialize();
						if (this._layoutIds == null || this._layoutIds.Length == 0)
						{
							return null;
						}
						InputLayout layout = ReInput.mapping.GetLayout(this.controllerSetSelector.controllerType, this._layoutIds[0]);
						if (layout == null)
						{
							return "INVALID";
						}
						return layout.name;
					}
				}
				set
				{
					if (!ReInput.isReady)
					{
						if (!string.IsNullOrEmpty(value))
						{
							this.CheckNoControllerTypeError();
						}
						object preInitLayoutNames;
						if (string.IsNullOrEmpty(value))
						{
							preInitLayoutNames = null;
						}
						else
						{
							(preInitLayoutNames = new string[1])[0] = value;
						}
						this._preInitLayoutNames = preInitLayoutNames;
						this._layoutIds = EmptyObjects<int>.array;
						return;
					}
					if (string.IsNullOrEmpty(value))
					{
						this._preInitLayoutNames = null;
						this._layoutIds = EmptyObjects<int>.array;
						return;
					}
					this.CheckNoControllerTypeError();
					int layoutId = ReInput.mapping.GetLayoutId(this.controllerSetSelector.controllerType, value);
					if (layoutId >= 0)
					{
						this.layoutId = layoutId;
						return;
					}
					Logger.LogWarning("Map Layout \"" + value + "\" does not exist.");
				}
			}

			// Token: 0x17000371 RID: 881
			// (get) Token: 0x06000B41 RID: 2881 RVA: 0x00049444 File Offset: 0x00047644
			internal bool isValid
			{
				get
				{
					if (this._controllerSetSelector == null)
					{
						return false;
					}
					if (!ReInput.isReady)
					{
						return true;
					}
					this.Initialize();
					if (this._categoryIds != null && this._categoryIds.Length != 0)
					{
						bool flag = false;
						for (int i = 0; i < this._categoryIds.Length; i++)
						{
							if (ReInput.mapping.GetMapCategory(this._categoryIds[i]) != null)
							{
								flag = true;
							}
						}
						if (!flag)
						{
							return false;
						}
					}
					if (this._layoutIds != null && this._layoutIds.Length != 0)
					{
						bool flag2 = false;
						for (int j = 0; j < this._layoutIds.Length; j++)
						{
							if (ReInput.mapping.GetLayout(this._controllerSetSelector.controllerType, this._layoutIds[j]) != null)
							{
								flag2 = true;
							}
						}
						if (!flag2)
						{
							return false;
						}
					}
					return true;
				}
			}

			// Token: 0x06000B42 RID: 2882 RVA: 0x000494F8 File Offset: 0x000476F8
			internal bool Matches(ControllerMap map)
			{
				return map != null && this.isValid && (this._categoryIds == null || this._categoryIds.Length == 0 || ArrayTools.Contains<int>(this._categoryIds, map.categoryId)) && (this._layoutIds == null || this._layoutIds.Length == 0 || ArrayTools.Contains<int>(this._layoutIds, map.layoutId)) && this._controllerSetSelector.Matches(map.controller);
			}

			// Token: 0x06000B43 RID: 2883 RVA: 0x00049578 File Offset: 0x00047778
			private void Initialize()
			{
				if (!ReInput.isReady)
				{
					return;
				}
				if (this._controllerSetSelector == null)
				{
					return;
				}
				if (this._categoryIds == null)
				{
					this._categoryIds = EmptyObjects<int>.array;
				}
				if (this._preInitCategoryNames != null && this._preInitCategoryNames.Length != 0)
				{
					List<int> list = new List<int>(this._preInitCategoryNames.Length);
					for (int i = 0; i < this._preInitCategoryNames.Length; i++)
					{
						if (!string.IsNullOrEmpty(this._preInitCategoryNames[i]))
						{
							int mapCategoryId = ReInput.mapping.GetMapCategoryId(this._preInitCategoryNames[i]);
							if (mapCategoryId >= 0)
							{
								list.Add(mapCategoryId);
							}
							else
							{
								Logger.LogWarning("Map Category \"" + this._preInitCategoryNames[i] + "\" does not exist.");
							}
						}
					}
					this._categoryIds = list.ToArray();
					this._preInitCategoryNames = null;
				}
				if (this._preInitLayoutNames != null && this._preInitLayoutNames.Length != 0)
				{
					this.CheckNoControllerTypeError();
					List<int> list2 = new List<int>(this._preInitLayoutNames.Length);
					for (int j = 0; j < this._preInitLayoutNames.Length; j++)
					{
						if (!string.IsNullOrEmpty(this._preInitLayoutNames[j]))
						{
							int layoutId = ReInput.mapping.GetLayoutId(this._controllerSetSelector.controllerType, this._preInitLayoutNames[j]);
							if (layoutId >= 0)
							{
								list2.Add(layoutId);
							}
							else
							{
								Logger.LogWarning("Map Layout \"" + this._preInitLayoutNames[j] + "\" does not exist.");
							}
						}
					}
					this._layoutIds = list2.ToArray();
					this._preInitLayoutNames = null;
				}
			}

			// Token: 0x06000B44 RID: 2884 RVA: 0x000496F0 File Offset: 0x000478F0
			private void CheckNoControllerTypeError()
			{
				if (this._controllerSetSelector == null)
				{
					return;
				}
				if (!this._controllerSetSelector.IbmnYivTUUXRLmzaaAGPWTFtAPLI)
				{
					Logger.LogWarning(string.Concat(new string[]
					{
						"A Layout should not be set when using ",
						typeof(ControllerSetSelector.Type).FullName,
						".",
						this._controllerSetSelector.type.ToString(),
						" because each Controller type has its own unique Layouts."
					}), true);
				}
			}

			// Token: 0x06000B45 RID: 2885 RVA: 0x0000B242 File Offset: 0x00009442
			object IDeepCloneable.DeepClone()
			{
				return new ControllerMapEnabler.Rule(this);
			}

			// Token: 0x040007B4 RID: 1972
			[SerializeField]
			[Serialize(Name = "tag")]
			private string _tag;

			// Token: 0x040007B5 RID: 1973
			[SerializeField]
			[Serialize(Name = "enable")]
			private bool _enable;

			// Token: 0x040007B6 RID: 1974
			[SerializeField]
			[Serialize(Name = "categoryIds")]
			private int[] _categoryIds;

			// Token: 0x040007B7 RID: 1975
			[SerializeField]
			[Serialize(Name = "layoutIds")]
			private int[] _layoutIds;

			// Token: 0x040007B8 RID: 1976
			[SerializeField]
			[Serialize(Name = "controllerSetSelector")]
			private ControllerSetSelector _controllerSetSelector;

			// Token: 0x040007B9 RID: 1977
			[NonSerialized]
			private string[] _preInitCategoryNames;

			// Token: 0x040007BA RID: 1978
			[NonSerialized]
			private string[] _preInitLayoutNames;
		}

		// Token: 0x02000123 RID: 291
		[Preserve]
		[SerializationType(SerializationTypeAttribute.SerializationType.Object)]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class RuleSet : IList<ControllerMapEnabler.Rule>, ICollection<ControllerMapEnabler.Rule>, IEnumerable<ControllerMapEnabler.Rule>, IEnumerable, IDeepCloneable
		{
			// Token: 0x17000372 RID: 882
			// (get) Token: 0x06000B46 RID: 2886 RVA: 0x0000B24A File Offset: 0x0000944A
			// (set) Token: 0x06000B47 RID: 2887 RVA: 0x0000B252 File Offset: 0x00009452
			public bool enabled
			{
				get
				{
					return this._enabled;
				}
				set
				{
					this._enabled = value;
				}
			}

			// Token: 0x17000373 RID: 883
			// (get) Token: 0x06000B48 RID: 2888 RVA: 0x0000B25B File Offset: 0x0000945B
			// (set) Token: 0x06000B49 RID: 2889 RVA: 0x0000B263 File Offset: 0x00009463
			public string tag
			{
				get
				{
					return this._tag;
				}
				set
				{
					this._tag = value;
				}
			}

			// Token: 0x17000374 RID: 884
			// (get) Token: 0x06000B4A RID: 2890 RVA: 0x0000B26C File Offset: 0x0000946C
			// (set) Token: 0x06000B4B RID: 2891 RVA: 0x0000B274 File Offset: 0x00009474
			public List<ControllerMapEnabler.Rule> rules
			{
				get
				{
					return this._rules;
				}
				set
				{
					this._rules = value;
					this.CheckList();
				}
			}

			// Token: 0x06000B4C RID: 2892 RVA: 0x0000B283 File Offset: 0x00009483
			internal RuleSet(bool A_1, string A_2, List<ControllerMapEnabler.Rule> A_3) : this()
			{
				this._enabled = A_1;
				this._tag = A_2;
				this._rules = A_3;
				this.CheckList();
			}

			// Token: 0x06000B4D RID: 2893 RVA: 0x0000B2A6 File Offset: 0x000094A6
			public RuleSet()
			{
				this._enabled = true;
				this._rules = new List<ControllerMapEnabler.Rule>();
			}

			// Token: 0x06000B4E RID: 2894 RVA: 0x0004976C File Offset: 0x0004796C
			public RuleSet(ControllerMapEnabler.RuleSet A_1)
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("source");
				}
				this._enabled = A_1._enabled;
				this._tag = A_1._tag;
				this._rules = MiscTools.DeepClone<ControllerMapEnabler.Rule>(A_1._rules);
				this.CheckList();
			}

			// Token: 0x06000B4F RID: 2895 RVA: 0x000497BC File Offset: 0x000479BC
			public ControllerMapEnabler.Rule Find(Predicate<ControllerMapEnabler.Rule> predicate)
			{
				if (predicate == null)
				{
					throw new ArgumentNullException("predicate");
				}
				int num = (this._rules != null) ? this._rules.Count : 0;
				for (int i = 0; i < num; i++)
				{
					try
					{
						if (predicate(this._rules[i]))
						{
							return this._rules[i];
						}
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMapEnabler.RuleSet.Find", exception);
					}
				}
				return null;
			}

			// Token: 0x06000B50 RID: 2896 RVA: 0x00049844 File Offset: 0x00047A44
			public ControllerMapEnabler.Rule FindLast(Predicate<ControllerMapEnabler.Rule> predicate)
			{
				if (predicate == null)
				{
					throw new ArgumentNullException("predicate");
				}
				for (int i = ((this._rules != null) ? this._rules.Count : 0) - 1; i >= 0; i--)
				{
					try
					{
						if (predicate(this._rules[i]))
						{
							return this._rules[i];
						}
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMapEnabler.RuleSet.FindLast", exception);
					}
				}
				return null;
			}

			// Token: 0x06000B51 RID: 2897 RVA: 0x000498CC File Offset: 0x00047ACC
			public int FindIndex(Predicate<ControllerMapEnabler.Rule> predicate)
			{
				if (predicate == null)
				{
					throw new ArgumentNullException("predicate");
				}
				int num = (this._rules != null) ? this._rules.Count : 0;
				for (int i = 0; i < num; i++)
				{
					try
					{
						if (predicate(this._rules[i]))
						{
							return i;
						}
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMapEnabler.RuleSet.FindIndex", exception);
					}
				}
				return -1;
			}

			// Token: 0x06000B52 RID: 2898 RVA: 0x00049948 File Offset: 0x00047B48
			public int FindLastIndex(Predicate<ControllerMapEnabler.Rule> predicate)
			{
				if (predicate == null)
				{
					throw new ArgumentNullException("predicate");
				}
				for (int i = ((this._rules != null) ? this._rules.Count : 0) - 1; i >= 0; i--)
				{
					try
					{
						if (predicate(this._rules[i]))
						{
							return i;
						}
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMapEnabler.RuleSet.FindLastIndex", exception);
					}
				}
				return -1;
			}

			// Token: 0x06000B53 RID: 2899 RVA: 0x0000B2C0 File Offset: 0x000094C0
			public int IndexOf(ControllerMapEnabler.Rule item)
			{
				this.CheckList();
				return this._rules.Count;
			}

			// Token: 0x06000B54 RID: 2900 RVA: 0x0000B2D3 File Offset: 0x000094D3
			public void Insert(int index, ControllerMapEnabler.Rule item)
			{
				this.CheckList();
				this._rules.Insert(index, item);
			}

			// Token: 0x06000B55 RID: 2901 RVA: 0x0000B2E8 File Offset: 0x000094E8
			public void RemoveAt(int index)
			{
				this.CheckList();
				this._rules.RemoveAt(index);
			}

			// Token: 0x17000375 RID: 885
			public ControllerMapEnabler.Rule this[int index]
			{
				get
				{
					this.CheckList();
					return this._rules[index];
				}
				set
				{
					this.CheckList();
					this._rules[index] = value;
				}
			}

			// Token: 0x06000B58 RID: 2904 RVA: 0x0000B325 File Offset: 0x00009525
			public void Add(ControllerMapEnabler.Rule item)
			{
				this.CheckList();
				this._rules.Add(item);
			}

			// Token: 0x06000B59 RID: 2905 RVA: 0x0000B339 File Offset: 0x00009539
			public void Clear()
			{
				this.CheckList();
				this._rules.Clear();
			}

			// Token: 0x06000B5A RID: 2906 RVA: 0x0000B34C File Offset: 0x0000954C
			public bool Contains(ControllerMapEnabler.Rule item)
			{
				this.CheckList();
				return this._rules.Contains(item);
			}

			// Token: 0x06000B5B RID: 2907 RVA: 0x0000B360 File Offset: 0x00009560
			public void CopyTo(ControllerMapEnabler.Rule[] array, int arrayIndex)
			{
				this.CheckList();
				this._rules.CopyTo(array, arrayIndex);
			}

			// Token: 0x17000376 RID: 886
			// (get) Token: 0x06000B5C RID: 2908 RVA: 0x0000B2C0 File Offset: 0x000094C0
			public int Count
			{
				get
				{
					this.CheckList();
					return this._rules.Count;
				}
			}

			// Token: 0x17000377 RID: 887
			// (get) Token: 0x06000B5D RID: 2909 RVA: 0x0000B375 File Offset: 0x00009575
			bool ICollection<ControllerMapEnabler.Rule>.IsReadOnly
			{
				get
				{
					this.CheckList();
					return ((ICollection<ControllerMapEnabler.Rule>)this._rules).IsReadOnly;
				}
			}

			// Token: 0x06000B5E RID: 2910 RVA: 0x0000B388 File Offset: 0x00009588
			public bool Remove(ControllerMapEnabler.Rule item)
			{
				this.CheckList();
				return this._rules.Remove(item);
			}

			// Token: 0x06000B5F RID: 2911 RVA: 0x0000B39C File Offset: 0x0000959C
			public IEnumerator<ControllerMapEnabler.Rule> GetEnumerator()
			{
				this.CheckList();
				return this._rules.GetEnumerator();
			}

			// Token: 0x06000B60 RID: 2912 RVA: 0x0000B39C File Offset: 0x0000959C
			IEnumerator IEnumerable.GetEnumerator()
			{
				this.CheckList();
				return this._rules.GetEnumerator();
			}

			// Token: 0x06000B61 RID: 2913 RVA: 0x0000B3B4 File Offset: 0x000095B4
			object IDeepCloneable.DeepClone()
			{
				return new ControllerMapEnabler.RuleSet(this);
			}

			// Token: 0x06000B62 RID: 2914 RVA: 0x0000B3BC File Offset: 0x000095BC
			private void CheckList()
			{
				if (this._rules == null)
				{
					this._rules = new List<ControllerMapEnabler.Rule>();
				}
			}

			// Token: 0x040007BB RID: 1979
			private const string className = "ControllerMapEnabler.RuleSet";

			// Token: 0x040007BC RID: 1980
			[SerializeField]
			[Serialize(Name = "enabled")]
			private bool _enabled;

			// Token: 0x040007BD RID: 1981
			[SerializeField]
			[Serialize(Name = "tag")]
			private string _tag;

			// Token: 0x040007BE RID: 1982
			[SerializeField]
			[Serialize(Name = "rules")]
			private List<ControllerMapEnabler.Rule> _rules;
		}

		// Token: 0x02000124 RID: 292
		internal class YqpaJJElEihfpIGutrHkMZgMkOuC
		{
			// Token: 0x06000B63 RID: 2915 RVA: 0x0000B3D1 File Offset: 0x000095D1
			public YqpaJJElEihfpIGutrHkMZgMkOuC(bool A_1, JjxttxsSyopWvkcsgVXYLeVlEgvS[] A_2)
			{
				this.FbdYHxRmampVzfgEDCVwRNPVYABN = A_1;
				this.bqHtFIxpavLkErbgxTBMWGEDWbYB = A_2;
			}

			// Token: 0x040007BF RID: 1983
			public bool FbdYHxRmampVzfgEDCVwRNPVYABN;

			// Token: 0x040007C0 RID: 1984
			public JjxttxsSyopWvkcsgVXYLeVlEgvS[] bqHtFIxpavLkErbgxTBMWGEDWbYB;
		}
	}
}
