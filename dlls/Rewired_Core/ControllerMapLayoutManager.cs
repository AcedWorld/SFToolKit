using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired
{
	// Token: 0x02000125 RID: 293
	public sealed class ControllerMapLayoutManager
	{
		// Token: 0x14000012 RID: 18
		// (add) Token: 0x06000B64 RID: 2916 RVA: 0x0000B3E7 File Offset: 0x000095E7
		// (remove) Token: 0x06000B65 RID: 2917 RVA: 0x0000B400 File Offset: 0x00009600
		internal event Action gYghhSbDMOeCeEtDXeIDvARayRydA
		{
			add
			{
				this.xYJNqLpooRFkWzNaSCLekMLUJhfc = (Action)Delegate.Combine(this.xYJNqLpooRFkWzNaSCLekMLUJhfc, value);
			}
			remove
			{
				this.xYJNqLpooRFkWzNaSCLekMLUJhfc = (Action)Delegate.Remove(this.xYJNqLpooRFkWzNaSCLekMLUJhfc, value);
			}
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x000499C4 File Offset: 0x00047BC4
		internal ControllerMapLayoutManager(Player A_1, ControllerMapLayoutManager.YuRWKBhEFGtHaIyXShqNamLdASyj A_2)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("player");
			}
			if (A_2 == null)
			{
				throw new ArgumentNullException("startingSettings");
			}
			this.gEfbSCIktKWKlEMmAgLHxlkrMDtbA = ReInput.id;
			this.rjyFNjCUIGLAMRvRevhMgRhGFOLp = A_1;
			this.nJiDJFUwVRlfaFlIoyncaFzWycdV = A_2;
		}

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000B67 RID: 2919 RVA: 0x0000B419 File Offset: 0x00009619
		// (set) Token: 0x06000B68 RID: 2920 RVA: 0x0000B421 File Offset: 0x00009621
		public bool enabled
		{
			get
			{
				return this.kwFypBfSoEZZZezjncJwBeifCKzfA;
			}
			set
			{
				this.kwFypBfSoEZZZezjncJwBeifCKzfA = value;
				if (value)
				{
					this.Apply();
				}
			}
		}

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06000B69 RID: 2921 RVA: 0x0000B433 File Offset: 0x00009633
		// (set) Token: 0x06000B6A RID: 2922 RVA: 0x0000B43B File Offset: 0x0000963B
		public bool loadFromUserDataStore
		{
			get
			{
				return this.miJDBTnawxNwBhyoOmDoNfKemRfG;
			}
			set
			{
				this.miJDBTnawxNwBhyoOmDoNfKemRfG = value;
			}
		}

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x06000B6B RID: 2923 RVA: 0x0000B444 File Offset: 0x00009644
		// (set) Token: 0x06000B6C RID: 2924 RVA: 0x0000B44C File Offset: 0x0000964C
		public List<ControllerMapLayoutManager.RuleSet> ruleSets
		{
			get
			{
				return this.mrNJuseZhjruxDPUxIvIJzMDiCbm;
			}
			set
			{
				if (value == null)
				{
					value = new List<ControllerMapLayoutManager.RuleSet>();
				}
				this.mrNJuseZhjruxDPUxIvIJzMDiCbm = value;
			}
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x00049A14 File Offset: 0x00047C14
		public void Apply()
		{
			if (ReInput._id != this.gEfbSCIktKWKlEMmAgLHxlkrMDtbA)
			{
				ReInput.CheckInitialized(this.gEfbSCIktKWKlEMmAgLHxlkrMDtbA);
				return;
			}
			Action action = this.xYJNqLpooRFkWzNaSCLekMLUJhfc;
			if (action != null)
			{
				action();
			}
			if (!this.kwFypBfSoEZZZezjncJwBeifCKzfA)
			{
				return;
			}
			if (this.mrNJuseZhjruxDPUxIvIJzMDiCbm == null)
			{
				return;
			}
			int count = this.mrNJuseZhjruxDPUxIvIJzMDiCbm.Count;
			if (count == 0)
			{
				return;
			}
			using (TempListPool.TList<ControllerMap> tlist = TempListPool.GetTList<ControllerMap>())
			{
				List<ControllerMap> list = tlist.list;
				using (TempListPool.TList<Controller> tlist2 = TempListPool.GetTList<Controller>())
				{
					List<Controller> list2 = tlist2.list;
					if (!list2.Contains(ReInput.controllers.Keyboard))
					{
						list2.Add(ReInput.controllers.Keyboard);
					}
					if (!list2.Contains(ReInput.controllers.Mouse))
					{
						list2.Add(ReInput.controllers.Mouse);
					}
					this.rjyFNjCUIGLAMRvRevhMgRhGFOLp.controllers.maps.GetAllMaps(list);
					list2.AddRange(this.rjyFNjCUIGLAMRvRevhMgRhGFOLp.controllers.Controllers);
					IControllerMapStore controllerMapStore = ReInput.userDataStore as IControllerMapStore;
					for (int i = 0; i < count; i++)
					{
						ControllerMapLayoutManager.RuleSet ruleSet = this.mrNJuseZhjruxDPUxIvIJzMDiCbm[i];
						if (ruleSet != null && ruleSet.enabled)
						{
							int count2 = ruleSet.Count;
							for (int j = 0; j < count2; j++)
							{
								ControllerMapLayoutManager.Rule rule = ruleSet[j];
								if (rule != null && rule.isValid)
								{
									for (int k = list.Count - 1; k >= 0; k--)
									{
										ControllerMap controllerMap = list[k];
										if (rule.controllerSetSelector.Matches(controllerMap.controller) && ArrayTools.Contains<int>(rule.categoryIds, controllerMap.categoryId) && controllerMap.layoutId != rule.layoutId)
										{
											list.RemoveAt(k);
											this.rjyFNjCUIGLAMRvRevhMgRhGFOLp.controllers.maps.RemoveMap(controllerMap.controllerType, controllerMap.controllerId, controllerMap.id);
										}
									}
									foreach (Controller controller in this.rjyFNjCUIGLAMRvRevhMgRhGFOLp.controllers.Controllers)
									{
										if (rule.controllerSetSelector.Matches(controller))
										{
											int[] categoryIds = rule.categoryIds;
											for (int l = 0; l < categoryIds.Length; l++)
											{
												ControllerMap controllerMap2 = this.rjyFNjCUIGLAMRvRevhMgRhGFOLp.controllers.maps.GetMap(controller, categoryIds[l], rule.layoutId);
												if (controllerMap2 == null)
												{
													if (this.miJDBTnawxNwBhyoOmDoNfKemRfG && controllerMapStore != null)
													{
														try
														{
															controllerMap2 = controllerMapStore.LoadControllerMap(this.rjyFNjCUIGLAMRvRevhMgRhGFOLp.id, controller.identifier, categoryIds[l], rule.layoutId);
														}
														catch (Exception exception)
														{
															ReInput.HandleExternalInterfaceException(typeof(ControllerMapLayoutManager).Name, exception);
														}
														if (controllerMap2 != null)
														{
															this.rjyFNjCUIGLAMRvRevhMgRhGFOLp.controllers.maps.AddMap(controller, controllerMap2);
															goto IL_2E7;
														}
													}
													this.rjyFNjCUIGLAMRvRevhMgRhGFOLp.controllers.maps.LoadMap(controller.type, controller.id, categoryIds[l], rule.layoutId, true);
												}
												IL_2E7:;
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

		// Token: 0x06000B6E RID: 2926 RVA: 0x00049DCC File Offset: 0x00047FCC
		public void LoadDefaults()
		{
			if (ReInput._id != this.gEfbSCIktKWKlEMmAgLHxlkrMDtbA)
			{
				ReInput.CheckInitialized(this.gEfbSCIktKWKlEMmAgLHxlkrMDtbA);
				return;
			}
			List<ControllerMapLayoutManager.RuleSet> list = new List<ControllerMapLayoutManager.RuleSet>();
			int num = (this.nJiDJFUwVRlfaFlIoyncaFzWycdV != null && this.nJiDJFUwVRlfaFlIoyncaFzWycdV.ZuGvAfVesjNJcpiugzMduexwimQT != null) ? this.nJiDJFUwVRlfaFlIoyncaFzWycdV.ZuGvAfVesjNJcpiugzMduexwimQT.Length : 0;
			for (int i = 0; i < num; i++)
			{
				ControllerMapLayoutManager.RuleSet controllerMapLayoutManagerRuleSetInstance = ReInput.mapping.GetControllerMapLayoutManagerRuleSetInstance(this.nJiDJFUwVRlfaFlIoyncaFzWycdV.ZuGvAfVesjNJcpiugzMduexwimQT[i].BDveskHydnddWigsUMoiWbCyxPyOA);
				if (controllerMapLayoutManagerRuleSetInstance == null)
				{
					Logger.LogError("Invalid Layout Manager Rule Set is assigned to Player. This should not be possible. If you are seeing this error, this is a sign of serialized data corruption, usually caused by a bad source control merge.");
				}
				else
				{
					controllerMapLayoutManagerRuleSetInstance.enabled = this.nJiDJFUwVRlfaFlIoyncaFzWycdV.ZuGvAfVesjNJcpiugzMduexwimQT[i].lHwbtaVQOiciQAdrqQuDlHJSwVPIA;
					list.Add(controllerMapLayoutManagerRuleSetInstance);
				}
			}
			if (this.nJiDJFUwVRlfaFlIoyncaFzWycdV != null)
			{
				this.kwFypBfSoEZZZezjncJwBeifCKzfA = this.nJiDJFUwVRlfaFlIoyncaFzWycdV.NTdOyRaeSLCehctOJaeSBNqFdVzTA;
				this.miJDBTnawxNwBhyoOmDoNfKemRfG = this.nJiDJFUwVRlfaFlIoyncaFzWycdV.hAddRgohCZBCDPYQgFDEUEwkLWzJ;
			}
			this.mrNJuseZhjruxDPUxIvIJzMDiCbm = list;
			this.Apply();
		}

		// Token: 0x06000B6F RID: 2927 RVA: 0x00049EB0 File Offset: 0x000480B0
		public string ToXmlString()
		{
			if (ReInput._id != this.gEfbSCIktKWKlEMmAgLHxlkrMDtbA)
			{
				ReInput.CheckInitialized(this.gEfbSCIktKWKlEMmAgLHxlkrMDtbA);
				return string.Empty;
			}
			string result;
			try
			{
				result = this.BIoPmWPCiGGklELyspzCarJUyXWGA().ToXmlString(true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + base.GetType().Name + " to XML. " + ex.Message);
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000B70 RID: 2928 RVA: 0x00049F2C File Offset: 0x0004812C
		public string ToJsonString()
		{
			if (ReInput._id != this.gEfbSCIktKWKlEMmAgLHxlkrMDtbA)
			{
				ReInput.CheckInitialized(this.gEfbSCIktKWKlEMmAgLHxlkrMDtbA);
				return string.Empty;
			}
			string result;
			try
			{
				result = this.BIoPmWPCiGGklELyspzCarJUyXWGA().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + base.GetType().Name + " to JSON. " + ex.Message);
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x00049FA8 File Offset: 0x000481A8
		public bool ImportXml(string xmlString)
		{
			if (ReInput._id != this.gEfbSCIktKWKlEMmAgLHxlkrMDtbA)
			{
				ReInput.CheckInitialized(this.gEfbSCIktKWKlEMmAgLHxlkrMDtbA);
				return false;
			}
			bool result;
			try
			{
				this.PpFsLbZfwEaFsiStGsWpixeJEPahb(SerializedObject.FromXml(base.GetType(), xmlString));
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

		// Token: 0x06000B72 RID: 2930 RVA: 0x0004A02C File Offset: 0x0004822C
		public bool ImportJson(string jsonString)
		{
			if (ReInput._id != this.gEfbSCIktKWKlEMmAgLHxlkrMDtbA)
			{
				ReInput.CheckInitialized(this.gEfbSCIktKWKlEMmAgLHxlkrMDtbA);
				return false;
			}
			bool result;
			try
			{
				this.PpFsLbZfwEaFsiStGsWpixeJEPahb(SerializedObject.FromJson(base.GetType(), jsonString));
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

		// Token: 0x06000B73 RID: 2931 RVA: 0x0004A0B0 File Offset: 0x000482B0
		private SerializedObject BIoPmWPCiGGklELyspzCarJUyXWGA()
		{
			SerializedObject serializedObject = new SerializedObject(base.GetType(), SerializedObject.ObjectType.Object);
			this.zvqGTLxwwVlDmhMfvNmwlrvYKmfw(serializedObject);
			return serializedObject;
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x0004A0D4 File Offset: 0x000482D4
		private void zvqGTLxwwVlDmhMfvNmwlrvYKmfw(SerializedObject A_1)
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
			A_1.Add<bool>("enabled", this.kwFypBfSoEZZZezjncJwBeifCKzfA, SerializedObject.FieldOptions.None);
			A_1.Add<bool>("loadFromUserDataStore", this.miJDBTnawxNwBhyoOmDoNfKemRfG, SerializedObject.FieldOptions.None);
			A_1.Add<List<ControllerMapLayoutManager.RuleSet>>("ruleSets", this.mrNJuseZhjruxDPUxIvIJzMDiCbm, SerializedObject.FieldOptions.None);
		}

		// Token: 0x06000B75 RID: 2933 RVA: 0x0004A224 File Offset: 0x00048424
		private bool PpFsLbZfwEaFsiStGsWpixeJEPahb(SerializedObject A_1)
		{
			this.kwFypBfSoEZZZezjncJwBeifCKzfA = false;
			this.mrNJuseZhjruxDPUxIvIJzMDiCbm = null;
			A_1.TryGetDeserializedValueByRef<bool>("enabled", ref this.kwFypBfSoEZZZezjncJwBeifCKzfA);
			A_1.TryGetDeserializedValueByRef<bool>("loadFromUserDataStore", ref this.miJDBTnawxNwBhyoOmDoNfKemRfG);
			List<ControllerMapLayoutManager.RuleSet> list = new List<ControllerMapLayoutManager.RuleSet>();
			A_1.TryGetDeserializedValueByRef<List<ControllerMapLayoutManager.RuleSet>>("ruleSets", ref list);
			this.mrNJuseZhjruxDPUxIvIJzMDiCbm = list;
			return true;
		}

		// Token: 0x040007C1 RID: 1985
		private bool kwFypBfSoEZZZezjncJwBeifCKzfA;

		// Token: 0x040007C2 RID: 1986
		private bool miJDBTnawxNwBhyoOmDoNfKemRfG = true;

		// Token: 0x040007C3 RID: 1987
		private Player rjyFNjCUIGLAMRvRevhMgRhGFOLp;

		// Token: 0x040007C4 RID: 1988
		private ControllerMapLayoutManager.YuRWKBhEFGtHaIyXShqNamLdASyj nJiDJFUwVRlfaFlIoyncaFzWycdV;

		// Token: 0x040007C5 RID: 1989
		private readonly int gEfbSCIktKWKlEMmAgLHxlkrMDtbA;

		// Token: 0x040007C6 RID: 1990
		private List<ControllerMapLayoutManager.RuleSet> mrNJuseZhjruxDPUxIvIJzMDiCbm;

		// Token: 0x040007C7 RID: 1991
		private Action xYJNqLpooRFkWzNaSCLekMLUJhfc;

		// Token: 0x02000126 RID: 294
		internal class YuRWKBhEFGtHaIyXShqNamLdASyj
		{
			// Token: 0x06000B76 RID: 2934 RVA: 0x0000B45F File Offset: 0x0000965F
			public YuRWKBhEFGtHaIyXShqNamLdASyj(bool A_1, bool A_2, JjxttxsSyopWvkcsgVXYLeVlEgvS[] A_3)
			{
				this.NTdOyRaeSLCehctOJaeSBNqFdVzTA = A_1;
				this.hAddRgohCZBCDPYQgFDEUEwkLWzJ = A_2;
				this.ZuGvAfVesjNJcpiugzMduexwimQT = A_3;
			}

			// Token: 0x040007C8 RID: 1992
			public bool NTdOyRaeSLCehctOJaeSBNqFdVzTA;

			// Token: 0x040007C9 RID: 1993
			public bool hAddRgohCZBCDPYQgFDEUEwkLWzJ;

			// Token: 0x040007CA RID: 1994
			public JjxttxsSyopWvkcsgVXYLeVlEgvS[] ZuGvAfVesjNJcpiugzMduexwimQT;
		}

		// Token: 0x02000127 RID: 295
		[Preserve]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class Rule : IDeepCloneable
		{
			// Token: 0x06000B77 RID: 2935 RVA: 0x0000B47C File Offset: 0x0000967C
			public Rule()
			{
				this._categoryIds = EmptyObjects<int>.array;
				this._layoutId = -1;
				this._controllerSetSelector = new ControllerSetSelector(ControllerSetSelector.Type.ControllerType);
			}

			// Token: 0x06000B78 RID: 2936 RVA: 0x0004A280 File Offset: 0x00048480
			public Rule(ControllerMapLayoutManager.Rule A_1)
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("source");
				}
				this._tag = A_1._tag;
				this._categoryIds = ArrayTools.ShallowCopy<int>(A_1._categoryIds);
				this._layoutId = A_1._layoutId;
				this._controllerSetSelector = MiscTools.DeepClone<ControllerSetSelector>(A_1._controllerSetSelector);
				this._preInitCategoryNames = ArrayTools.ShallowCopy<string>(A_1._preInitCategoryNames);
				this._preInitLayoutName = A_1._preInitLayoutName;
			}

			// Token: 0x06000B79 RID: 2937 RVA: 0x0000B4A2 File Offset: 0x000096A2
			internal Rule(string A_1, int[] A_2, int A_3, ControllerSetSelector A_4)
			{
				this._tag = A_1;
				this._categoryIds = A_2;
				this._layoutId = A_3;
				this._controllerSetSelector = A_4;
			}

			// Token: 0x1700037B RID: 891
			// (get) Token: 0x06000B7A RID: 2938 RVA: 0x0000B4C7 File Offset: 0x000096C7
			// (set) Token: 0x06000B7B RID: 2939 RVA: 0x0000B4CF File Offset: 0x000096CF
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

			// Token: 0x1700037C RID: 892
			// (get) Token: 0x06000B7C RID: 2940 RVA: 0x0004A2F8 File Offset: 0x000484F8
			// (set) Token: 0x06000B7D RID: 2941 RVA: 0x0004A320 File Offset: 0x00048520
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
					if (!value.IbmnYivTUUXRLmzaaAGPWTFtAPLI)
					{
						Logger.LogError(value.type.ToString() + " is not allowed. Each Controller Type has its own unique Layouts and a single Layout cannot be set for all Controller Types. ControllerSelector.type has been changed to ControllerSelector.Type.ControllerType.", true);
						value.type = ControllerSetSelector.Type.ControllerType;
					}
					this._controllerSetSelector = value;
				}
			}

			// Token: 0x1700037D RID: 893
			// (get) Token: 0x06000B7E RID: 2942 RVA: 0x0000B4D8 File Offset: 0x000096D8
			// (set) Token: 0x06000B7F RID: 2943 RVA: 0x0000B4FB File Offset: 0x000096FB
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

			// Token: 0x1700037E RID: 894
			// (get) Token: 0x06000B80 RID: 2944 RVA: 0x0004A374 File Offset: 0x00048574
			// (set) Token: 0x06000B81 RID: 2945 RVA: 0x0000B53B File Offset: 0x0000973B
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

			// Token: 0x1700037F RID: 895
			// (get) Token: 0x06000B82 RID: 2946 RVA: 0x0000B555 File Offset: 0x00009755
			// (set) Token: 0x06000B83 RID: 2947 RVA: 0x0000B563 File Offset: 0x00009763
			public int layoutId
			{
				get
				{
					this.Initialize();
					return this._layoutId;
				}
				set
				{
					if (value < 0)
					{
						value = -1;
					}
					this._layoutId = value;
					this._preInitLayoutName = null;
				}
			}

			// Token: 0x17000380 RID: 896
			// (get) Token: 0x06000B84 RID: 2948 RVA: 0x0004A3A0 File Offset: 0x000485A0
			// (set) Token: 0x06000B85 RID: 2949 RVA: 0x0004A40C File Offset: 0x0004860C
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

			// Token: 0x17000381 RID: 897
			// (get) Token: 0x06000B86 RID: 2950 RVA: 0x0004A490 File Offset: 0x00048690
			// (set) Token: 0x06000B87 RID: 2951 RVA: 0x0004A518 File Offset: 0x00048718
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

			// Token: 0x17000382 RID: 898
			// (get) Token: 0x06000B88 RID: 2952 RVA: 0x0004A5C4 File Offset: 0x000487C4
			// (set) Token: 0x06000B89 RID: 2953 RVA: 0x0004A610 File Offset: 0x00048810
			public string layoutName
			{
				get
				{
					if (!ReInput.isReady)
					{
						return this._preInitLayoutName;
					}
					this.Initialize();
					InputLayout layout = ReInput.mapping.GetLayout(this.controllerSetSelector.controllerType, this._layoutId);
					if (layout == null)
					{
						return "INVALID";
					}
					return layout.name;
				}
				set
				{
					if (!ReInput.isReady)
					{
						this._preInitLayoutName = value;
						this._layoutId = -1;
						return;
					}
					if (string.IsNullOrEmpty(value))
					{
						this._preInitLayoutName = null;
						this._layoutId = -1;
						return;
					}
					this.layoutId = ReInput.mapping.GetLayoutId(this.controllerSetSelector.controllerType, value);
					if (this._layoutId < 0)
					{
						Logger.LogWarning(this.controllerSetSelector.controllerType.ToString() + " Layout \"" + value + "\" does not exist.");
					}
				}
			}

			// Token: 0x17000383 RID: 899
			// (get) Token: 0x06000B8A RID: 2954 RVA: 0x0004A6A0 File Offset: 0x000488A0
			internal bool isValid
			{
				get
				{
					if (this._controllerSetSelector == null)
					{
						return false;
					}
					this.Initialize();
					if (this._categoryIds == null || this._categoryIds.Length == 0)
					{
						return false;
					}
					if (!ReInput.isReady)
					{
						return this._categoryIds[0] >= 0 && this._layoutId >= 0;
					}
					bool flag = false;
					for (int i = 0; i < this._categoryIds.Length; i++)
					{
						if (ReInput.mapping.GetMapCategory(this._categoryIds[i]) != null)
						{
							flag = true;
						}
					}
					return flag && ReInput.mapping.GetLayout(this._controllerSetSelector.controllerType, this._layoutId) != null;
				}
			}

			// Token: 0x06000B8B RID: 2955 RVA: 0x0004A740 File Offset: 0x00048940
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
				if (!string.IsNullOrEmpty(this._preInitLayoutName))
				{
					this.layoutName = this._preInitLayoutName;
					this._preInitLayoutName = null;
				}
			}

			// Token: 0x06000B8C RID: 2956 RVA: 0x0000B57A File Offset: 0x0000977A
			object IDeepCloneable.DeepClone()
			{
				return new ControllerMapLayoutManager.Rule(this);
			}

			// Token: 0x040007CB RID: 1995
			[SerializeField]
			[Serialize(Name = "tag")]
			private string _tag;

			// Token: 0x040007CC RID: 1996
			[SerializeField]
			[Serialize(Name = "categoryIds")]
			private int[] _categoryIds;

			// Token: 0x040007CD RID: 1997
			[SerializeField]
			[Serialize(Name = "layoutId")]
			private int _layoutId;

			// Token: 0x040007CE RID: 1998
			[SerializeField]
			[Serialize(Name = "controllerSetSelector")]
			private ControllerSetSelector _controllerSetSelector;

			// Token: 0x040007CF RID: 1999
			[NonSerialized]
			private string[] _preInitCategoryNames;

			// Token: 0x040007D0 RID: 2000
			[NonSerialized]
			private string _preInitLayoutName;
		}

		// Token: 0x02000128 RID: 296
		[Preserve]
		[SerializationType(SerializationTypeAttribute.SerializationType.Object)]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Serializable]
		public sealed class RuleSet : IList<ControllerMapLayoutManager.Rule>, ICollection<ControllerMapLayoutManager.Rule>, IEnumerable<ControllerMapLayoutManager.Rule>, IEnumerable, IDeepCloneable
		{
			// Token: 0x17000384 RID: 900
			// (get) Token: 0x06000B8D RID: 2957 RVA: 0x0000B582 File Offset: 0x00009782
			// (set) Token: 0x06000B8E RID: 2958 RVA: 0x0000B58A File Offset: 0x0000978A
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

			// Token: 0x17000385 RID: 901
			// (get) Token: 0x06000B8F RID: 2959 RVA: 0x0000B593 File Offset: 0x00009793
			// (set) Token: 0x06000B90 RID: 2960 RVA: 0x0000B59B File Offset: 0x0000979B
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

			// Token: 0x17000386 RID: 902
			// (get) Token: 0x06000B91 RID: 2961 RVA: 0x0000B5A4 File Offset: 0x000097A4
			// (set) Token: 0x06000B92 RID: 2962 RVA: 0x0000B5AC File Offset: 0x000097AC
			public List<ControllerMapLayoutManager.Rule> rules
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

			// Token: 0x06000B93 RID: 2963 RVA: 0x0000B5BB File Offset: 0x000097BB
			internal RuleSet(bool A_1, string A_2, List<ControllerMapLayoutManager.Rule> A_3) : this()
			{
				this._enabled = A_1;
				this._tag = A_2;
				this._rules = A_3;
				this.CheckList();
			}

			// Token: 0x06000B94 RID: 2964 RVA: 0x0000B5DE File Offset: 0x000097DE
			public RuleSet()
			{
				this._enabled = true;
				this._rules = new List<ControllerMapLayoutManager.Rule>();
			}

			// Token: 0x06000B95 RID: 2965 RVA: 0x0004A824 File Offset: 0x00048A24
			public RuleSet(ControllerMapLayoutManager.RuleSet A_1)
			{
				if (A_1 == null)
				{
					throw new ArgumentNullException("source");
				}
				this._enabled = A_1._enabled;
				this._tag = A_1._tag;
				this._rules = MiscTools.DeepClone<ControllerMapLayoutManager.Rule>(A_1._rules);
				this.CheckList();
			}

			// Token: 0x06000B96 RID: 2966 RVA: 0x0004A874 File Offset: 0x00048A74
			public ControllerMapLayoutManager.Rule Find(Predicate<ControllerMapLayoutManager.Rule> predicate)
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
						ReInput.HandleCallbackException("ControllerMapLayoutManager.RuleSet.Find", exception);
					}
				}
				return null;
			}

			// Token: 0x06000B97 RID: 2967 RVA: 0x0004A8FC File Offset: 0x00048AFC
			public ControllerMapLayoutManager.Rule FindLast(Predicate<ControllerMapLayoutManager.Rule> predicate)
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
						ReInput.HandleCallbackException("ControllerMapLayoutManager.RuleSet.FindLast", exception);
					}
				}
				return null;
			}

			// Token: 0x06000B98 RID: 2968 RVA: 0x0004A984 File Offset: 0x00048B84
			public int FindIndex(Predicate<ControllerMapLayoutManager.Rule> predicate)
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
						ReInput.HandleCallbackException("ControllerMapLayoutManager.RuleSet.FindIndex", exception);
					}
				}
				return -1;
			}

			// Token: 0x06000B99 RID: 2969 RVA: 0x0004AA00 File Offset: 0x00048C00
			public int FindLastIndex(Predicate<ControllerMapLayoutManager.Rule> predicate)
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
						ReInput.HandleCallbackException("ControllerMapLayoutManager.RuleSet.FindLastIndex", exception);
					}
				}
				return -1;
			}

			// Token: 0x06000B9A RID: 2970 RVA: 0x0000B5F8 File Offset: 0x000097F8
			public int IndexOf(ControllerMapLayoutManager.Rule item)
			{
				this.CheckList();
				return this._rules.Count;
			}

			// Token: 0x06000B9B RID: 2971 RVA: 0x0000B60B File Offset: 0x0000980B
			public void Insert(int index, ControllerMapLayoutManager.Rule item)
			{
				this.CheckList();
				this._rules.Insert(index, item);
			}

			// Token: 0x06000B9C RID: 2972 RVA: 0x0000B620 File Offset: 0x00009820
			public void RemoveAt(int index)
			{
				this.CheckList();
				this._rules.RemoveAt(index);
			}

			// Token: 0x17000387 RID: 903
			public ControllerMapLayoutManager.Rule this[int index]
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

			// Token: 0x06000B9F RID: 2975 RVA: 0x0000B65D File Offset: 0x0000985D
			public void Add(ControllerMapLayoutManager.Rule item)
			{
				this.CheckList();
				this._rules.Add(item);
			}

			// Token: 0x06000BA0 RID: 2976 RVA: 0x0000B671 File Offset: 0x00009871
			public void Clear()
			{
				this.CheckList();
				this._rules.Clear();
			}

			// Token: 0x06000BA1 RID: 2977 RVA: 0x0000B684 File Offset: 0x00009884
			public bool Contains(ControllerMapLayoutManager.Rule item)
			{
				this.CheckList();
				return this._rules.Contains(item);
			}

			// Token: 0x06000BA2 RID: 2978 RVA: 0x0000B698 File Offset: 0x00009898
			public void CopyTo(ControllerMapLayoutManager.Rule[] array, int arrayIndex)
			{
				this.CheckList();
				this._rules.CopyTo(array, arrayIndex);
			}

			// Token: 0x17000388 RID: 904
			// (get) Token: 0x06000BA3 RID: 2979 RVA: 0x0000B5F8 File Offset: 0x000097F8
			public int Count
			{
				get
				{
					this.CheckList();
					return this._rules.Count;
				}
			}

			// Token: 0x17000389 RID: 905
			// (get) Token: 0x06000BA4 RID: 2980 RVA: 0x0000B6AD File Offset: 0x000098AD
			bool ICollection<ControllerMapLayoutManager.Rule>.IsReadOnly
			{
				get
				{
					this.CheckList();
					return ((ICollection<ControllerMapLayoutManager.Rule>)this._rules).IsReadOnly;
				}
			}

			// Token: 0x06000BA5 RID: 2981 RVA: 0x0000B6C0 File Offset: 0x000098C0
			public bool Remove(ControllerMapLayoutManager.Rule item)
			{
				this.CheckList();
				return this._rules.Remove(item);
			}

			// Token: 0x06000BA6 RID: 2982 RVA: 0x0000B6D4 File Offset: 0x000098D4
			public IEnumerator<ControllerMapLayoutManager.Rule> GetEnumerator()
			{
				this.CheckList();
				return this._rules.GetEnumerator();
			}

			// Token: 0x06000BA7 RID: 2983 RVA: 0x0000B6D4 File Offset: 0x000098D4
			IEnumerator IEnumerable.GetEnumerator()
			{
				this.CheckList();
				return this._rules.GetEnumerator();
			}

			// Token: 0x06000BA8 RID: 2984 RVA: 0x0000B6EC File Offset: 0x000098EC
			object IDeepCloneable.DeepClone()
			{
				return new ControllerMapLayoutManager.RuleSet(this);
			}

			// Token: 0x06000BA9 RID: 2985 RVA: 0x0000B6F4 File Offset: 0x000098F4
			private void CheckList()
			{
				if (this._rules == null)
				{
					this._rules = new List<ControllerMapLayoutManager.Rule>();
				}
			}

			// Token: 0x040007D1 RID: 2001
			private const string className = "ControllerMapLayoutManager.RuleSet";

			// Token: 0x040007D2 RID: 2002
			[SerializeField]
			[Serialize(Name = "enabled")]
			private bool _enabled;

			// Token: 0x040007D3 RID: 2003
			[SerializeField]
			[Serialize(Name = "tag")]
			private string _tag;

			// Token: 0x040007D4 RID: 2004
			[SerializeField]
			[Serialize(Name = "rules")]
			private List<ControllerMapLayoutManager.Rule> _rules;
		}
	}
}
