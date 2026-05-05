using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	// Token: 0x02000099 RID: 153
	public class ControllerTemplateMap
	{
		// Token: 0x06000623 RID: 1571 RVA: 0x0003A1BC File Offset: 0x000383BC
		internal ControllerTemplateMap(Guid A_1)
		{
			this.eIiksMZAMSUoUUOJgodAUMWyhYlT = ControllerTemplateMap.ahwLZKKKkhgsJqzQavxCxFNpbzNe++;
			this.UJNPGOmeeLRMeAYqeWoErpsQCFLy = ReInput._id;
			this.ePYyJhtCYctdsfRlGylxfbcTdyVR = A_1;
			this.lRezZqtOoQbZheWmGvTfIKTEovy = new List<ControllerTemplateActionElementMap>();
			this.kpQsCYjauUQaxiiuoxMpQrDQHZCV = new ReadOnlyCollection<ControllerTemplateActionElementMap>(this.lRezZqtOoQbZheWmGvTfIKTEovy);
			this.QYYAQIuUnBqLSvZYTRbSxcfHlIOb = true;
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x00007232 File Offset: 0x00005432
		internal ControllerTemplateMap(Guid A_1, int A_2, int A_3, int A_4) : this(A_1)
		{
			this.GRtzdsJyfiWJtCyjEQeDPJdVgQpc = A_2;
			this.RkJYdzGeeWwCfpcpAGZKeamfCGCMA = A_3;
			this.WErGVWftgDiuLKjYKGHrIWzhehUv = A_4;
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000625 RID: 1573 RVA: 0x00007251 File Offset: 0x00005451
		public int id
		{
			get
			{
				if (ReInput._id != this.UJNPGOmeeLRMeAYqeWoErpsQCFLy)
				{
					ReInput.CheckInitialized(this.UJNPGOmeeLRMeAYqeWoErpsQCFLy);
					return -1;
				}
				return this.eIiksMZAMSUoUUOJgodAUMWyhYlT;
			}
		}

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000626 RID: 1574 RVA: 0x00007274 File Offset: 0x00005474
		public Guid templateTypeGuid
		{
			get
			{
				if (ReInput._id != this.UJNPGOmeeLRMeAYqeWoErpsQCFLy)
				{
					ReInput.CheckInitialized(this.UJNPGOmeeLRMeAYqeWoErpsQCFLy);
					return Guid.Empty;
				}
				return this.ePYyJhtCYctdsfRlGylxfbcTdyVR;
			}
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000627 RID: 1575 RVA: 0x0000729B File Offset: 0x0000549B
		// (set) Token: 0x06000628 RID: 1576 RVA: 0x000072BE File Offset: 0x000054BE
		public bool enabled
		{
			get
			{
				if (ReInput._id != this.UJNPGOmeeLRMeAYqeWoErpsQCFLy)
				{
					ReInput.CheckInitialized(this.UJNPGOmeeLRMeAYqeWoErpsQCFLy);
					return false;
				}
				return this.QYYAQIuUnBqLSvZYTRbSxcfHlIOb;
			}
			set
			{
				this.QYYAQIuUnBqLSvZYTRbSxcfHlIOb = value;
			}
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000629 RID: 1577 RVA: 0x000072C7 File Offset: 0x000054C7
		// (set) Token: 0x0600062A RID: 1578 RVA: 0x000072EA File Offset: 0x000054EA
		public int categoryId
		{
			get
			{
				if (ReInput._id != this.UJNPGOmeeLRMeAYqeWoErpsQCFLy)
				{
					ReInput.CheckInitialized(this.UJNPGOmeeLRMeAYqeWoErpsQCFLy);
					return -1;
				}
				return this.GRtzdsJyfiWJtCyjEQeDPJdVgQpc;
			}
			internal set
			{
				this.GRtzdsJyfiWJtCyjEQeDPJdVgQpc = value;
			}
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x0600062B RID: 1579 RVA: 0x000072F3 File Offset: 0x000054F3
		// (set) Token: 0x0600062C RID: 1580 RVA: 0x00007316 File Offset: 0x00005516
		public int layoutId
		{
			get
			{
				if (ReInput._id != this.UJNPGOmeeLRMeAYqeWoErpsQCFLy)
				{
					ReInput.CheckInitialized(this.UJNPGOmeeLRMeAYqeWoErpsQCFLy);
					return -1;
				}
				return this.RkJYdzGeeWwCfpcpAGZKeamfCGCMA;
			}
			internal set
			{
				this.RkJYdzGeeWwCfpcpAGZKeamfCGCMA = value;
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x0600062D RID: 1581 RVA: 0x0000731F File Offset: 0x0000551F
		public IList<ControllerTemplateActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != this.UJNPGOmeeLRMeAYqeWoErpsQCFLy)
				{
					ReInput.CheckInitialized(this.UJNPGOmeeLRMeAYqeWoErpsQCFLy);
					return EmptyObjects<ControllerTemplateActionElementMap>.EmptyReadOnlyIListT;
				}
				return this.kpQsCYjauUQaxiiuoxMpQrDQHZCV;
			}
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0003A220 File Offset: 0x00038420
		public string ToXmlString()
		{
			if (ReInput._id != this.UJNPGOmeeLRMeAYqeWoErpsQCFLy)
			{
				ReInput.CheckInitialized(this.UJNPGOmeeLRMeAYqeWoErpsQCFLy);
				return string.Empty;
			}
			string result;
			try
			{
				result = this.bbRyFggHdIALITwRLaQKFZZyEkMz().ToXmlString(true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + base.GetType().Name + " to XML. " + ex.Message);
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x0003A29C File Offset: 0x0003849C
		public string ToJsonString()
		{
			if (ReInput._id != this.UJNPGOmeeLRMeAYqeWoErpsQCFLy)
			{
				ReInput.CheckInitialized(this.UJNPGOmeeLRMeAYqeWoErpsQCFLy);
				return string.Empty;
			}
			string result;
			try
			{
				result = this.bbRyFggHdIALITwRLaQKFZZyEkMz().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + base.GetType().Name + " to JSON. " + ex.Message);
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x0003A318 File Offset: 0x00038518
		public ControllerMap ToControllerMap(Controller controller)
		{
			if (ReInput._id != this.UJNPGOmeeLRMeAYqeWoErpsQCFLy)
			{
				ReInput.CheckInitialized(this.UJNPGOmeeLRMeAYqeWoErpsQCFLy);
				return null;
			}
			if (controller == null)
			{
				throw new ArgumentNullException("controller");
			}
			IControllerTemplate template = controller.GetTemplate(this.ePYyJhtCYctdsfRlGylxfbcTdyVR);
			if (template == null)
			{
				Logger.LogError("The Controller does not implement the expected Controller Template.");
				return null;
			}
			ControllerMap controllerMap = ControllerMap.nPcWPeGGLvrSGPqQhGYxyqQuLzOb(controller.type);
			controllerMap.categoryId = this.GRtzdsJyfiWJtCyjEQeDPJdVgQpc;
			controllerMap.layoutId = this.RkJYdzGeeWwCfpcpAGZKeamfCGCMA;
			if (this.WErGVWftgDiuLKjYKGHrIWzhehUv >= 0)
			{
				controllerMap.sourceMapId = this.WErGVWftgDiuLKjYKGHrIWzhehUv;
			}
			controllerMap.controllerId = controller.id;
			controllerMap.enabled = this.QYYAQIuUnBqLSvZYTRbSxcfHlIOb;
			controllerMap.hardwareGuid = controller.legQjhUclFMVpVFTfXDlmJRWuUQj;
			using (TempListPool.TList<ActionElementMap> tlist = TempListPool.GetTList<ActionElementMap>())
			{
				List<ActionElementMap> list = tlist.list;
				for (int i = 0; i < this.lRezZqtOoQbZheWmGvTfIKTEovy.Count; i++)
				{
					this.lRezZqtOoQbZheWmGvTfIKTEovy[i].fxTCoIAkSoRBinmNwhajAGxLwrqL(template, list, false);
					for (int j = 0; j < list.Count; j++)
					{
						controllerMap.SNSempsrfLhzSBkFeitYdlebhkwZB(list[j]);
					}
				}
			}
			return controllerMap;
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0003A448 File Offset: 0x00038648
		internal virtual void BEQefKWxYOzKOgMXWZvDzGTeyHiU(SerializedObject A_1)
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
				icHQGefQbedChDWtubHCUkbucRzbb = "templateTypeGuid",
				hQsdIPBPqieQLwIOlxlBAUDVYhDFA = this.ePYyJhtCYctdsfRlGylxfbcTdyVR.ToString()
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
			A_1.Add<Guid>("templateTypeGuid", this.ePYyJhtCYctdsfRlGylxfbcTdyVR, SerializedObject.FieldOptions.None);
			A_1.Add<bool>("enabled", this.QYYAQIuUnBqLSvZYTRbSxcfHlIOb, SerializedObject.FieldOptions.None);
			A_1.Add<int>("categoryId", this.GRtzdsJyfiWJtCyjEQeDPJdVgQpc, SerializedObject.FieldOptions.None);
			A_1.Add<int>("layoutId", this.RkJYdzGeeWwCfpcpAGZKeamfCGCMA, SerializedObject.FieldOptions.None);
			A_1.Add<int>("sourceMapId", this.WErGVWftgDiuLKjYKGHrIWzhehUv, SerializedObject.FieldOptions.None);
			int count = this.lRezZqtOoQbZheWmGvTfIKTEovy.Count;
			List<object> list = new List<object>();
			A_1.Add<List<object>>("elementMaps", list, SerializedObject.FieldOptions.None);
			for (int i = 0; i < count; i++)
			{
				if (this.lRezZqtOoQbZheWmGvTfIKTEovy[i] != null)
				{
					list.Add(this.lRezZqtOoQbZheWmGvTfIKTEovy[i].etIsOuaCTBfPgCTYKdwleZoTvQZs());
				}
			}
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x0003A654 File Offset: 0x00038854
		internal virtual void TieGLGFBznmIoZSulfjcKtQltgJg(SerializedObject A_1)
		{
			this.rHWpOvMEHnLgPGCuTqWsYBYbbTRA();
			A_1.TryGetDeserializedValueByRef<bool>("enabled", ref this.QYYAQIuUnBqLSvZYTRbSxcfHlIOb);
			A_1.TryGetDeserializedValueByRef<int>("categoryId", ref this.GRtzdsJyfiWJtCyjEQeDPJdVgQpc);
			A_1.TryGetDeserializedValueByRef<int>("layoutId", ref this.RkJYdzGeeWwCfpcpAGZKeamfCGCMA);
			A_1.TryGetDeserializedValueByRef<int>("sourceMapId", ref this.WErGVWftgDiuLKjYKGHrIWzhehUv);
			SerializedObject serializedObject = null;
			if (A_1.TryGetDeserializedValueByRef<SerializedObject>("elementMaps", ref serializedObject) && serializedObject != null)
			{
				for (int i = 0; i < serializedObject.count; i++)
				{
					SerializedObject serializedObject2;
					if (serializedObject.TryGetDeserializedValue<SerializedObject>(i, out serializedObject2) || serializedObject2 == null)
					{
						ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.NoxPmyDPGOtGBKxlxcLyFrCmOhcf(serializedObject2);
						if (controllerTemplateActionElementMap != null)
						{
							this.wGiCZcFTesGTMmlvYShgrpCRWrtF(controllerTemplateActionElementMap);
						}
					}
				}
			}
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x00007346 File Offset: 0x00005546
		private void rHWpOvMEHnLgPGCuTqWsYBYbbTRA()
		{
			this.QYYAQIuUnBqLSvZYTRbSxcfHlIOb = true;
			this.GRtzdsJyfiWJtCyjEQeDPJdVgQpc = -1;
			this.RkJYdzGeeWwCfpcpAGZKeamfCGCMA = -1;
			this.WErGVWftgDiuLKjYKGHrIWzhehUv = -1;
			this.lRezZqtOoQbZheWmGvTfIKTEovy.Clear();
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x0003A6F4 File Offset: 0x000388F4
		private SerializedObject bbRyFggHdIALITwRLaQKFZZyEkMz()
		{
			SerializedObject serializedObject = new SerializedObject(base.GetType(), SerializedObject.ObjectType.Object);
			this.BEQefKWxYOzKOgMXWZvDzGTeyHiU(serializedObject);
			return serializedObject;
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x0000736F File Offset: 0x0000556F
		internal void wGiCZcFTesGTMmlvYShgrpCRWrtF(ControllerTemplateActionElementMap A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			this.lRezZqtOoQbZheWmGvTfIKTEovy.Add(A_1);
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0003A718 File Offset: 0x00038918
		internal static ControllerTemplateMap yOtzURshwPfXiMNWqELktsJsfyEV(IControllerTemplate A_0, ControllerMap A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("controllerMap");
			}
			if (A_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			if (!ReInput.isReady)
			{
				throw new Exception("Rewired is not initialized.");
			}
			Controller controller = ReInput.controllers.GetController(A_1.controllerType, A_1.controllerId);
			if (controller == null)
			{
				Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", true);
				return null;
			}
			if (!controller.ImplementsTemplate(A_0.typeGuid))
			{
				Logger.LogError("The Controller does not implement the Controller Template.", true);
				return null;
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(A_0.typeGuid);
			controllerTemplateMap.QYYAQIuUnBqLSvZYTRbSxcfHlIOb = A_1.enabled;
			controllerTemplateMap.GRtzdsJyfiWJtCyjEQeDPJdVgQpc = A_1.categoryId;
			controllerTemplateMap.RkJYdzGeeWwCfpcpAGZKeamfCGCMA = A_1.layoutId;
			controllerTemplateMap.WErGVWftgDiuLKjYKGHrIWzhehUv = A_1.sourceMapId;
			using (TempListPool.TList<ControllerTemplateElementTarget> tlist = TempListPool.GetTList<ControllerTemplateElementTarget>())
			{
				List<ControllerTemplateElementTarget> list = tlist.list;
				foreach (ActionElementMap actionElementMap in A_1.AllMaps)
				{
					if (A_0.GetElementTargets(actionElementMap, list) > 0)
					{
						for (int i = 0; i < list.Count; i++)
						{
							controllerTemplateMap.wGiCZcFTesGTMmlvYShgrpCRWrtF(ControllerTemplateActionElementMap.DYLcqAHncfFhhJFBBgcMHJFHVeYA(list[i], actionElementMap));
						}
					}
				}
			}
			return controllerTemplateMap;
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x0003A870 File Offset: 0x00038A70
		public static ControllerTemplateMap FromXml(string xmlString)
		{
			ControllerTemplateMap result;
			try
			{
				result = ControllerTemplateMap.HCXaSIxwGkwvkxQMzvAPYOqQWVNI(SerializedObject.FromXml(typeof(ControllerTemplateMap), xmlString));
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating ControllerTemplateMap from XML! " + ex.Message);
				result = null;
			}
			return result;
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x0003A8C0 File Offset: 0x00038AC0
		public static ControllerTemplateMap FromJson(string jsonString)
		{
			ControllerTemplateMap result;
			try
			{
				result = ControllerTemplateMap.HCXaSIxwGkwvkxQMzvAPYOqQWVNI(SerializedObject.FromJson(typeof(ControllerTemplateMap), jsonString));
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating ControllerTemplateMap from JSON! " + ex.Message);
				result = null;
			}
			return result;
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x0003A910 File Offset: 0x00038B10
		private static ControllerTemplateMap HCXaSIxwGkwvkxQMzvAPYOqQWVNI(SerializedObject A_0)
		{
			Guid guid;
			if (!A_0.TryGetDeserializedValue<Guid>("templateTypeGuid", out guid))
			{
				throw new Exception();
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(guid);
			controllerTemplateMap.TieGLGFBznmIoZSulfjcKtQltgJg(A_0);
			return controllerTemplateMap;
		}

		// Token: 0x040003BE RID: 958
		private readonly int UJNPGOmeeLRMeAYqeWoErpsQCFLy;

		// Token: 0x040003BF RID: 959
		private readonly int eIiksMZAMSUoUUOJgodAUMWyhYlT;

		// Token: 0x040003C0 RID: 960
		private readonly Guid ePYyJhtCYctdsfRlGylxfbcTdyVR;

		// Token: 0x040003C1 RID: 961
		private readonly List<ControllerTemplateActionElementMap> lRezZqtOoQbZheWmGvTfIKTEovy;

		// Token: 0x040003C2 RID: 962
		private readonly ReadOnlyCollection<ControllerTemplateActionElementMap> kpQsCYjauUQaxiiuoxMpQrDQHZCV;

		// Token: 0x040003C3 RID: 963
		private bool QYYAQIuUnBqLSvZYTRbSxcfHlIOb;

		// Token: 0x040003C4 RID: 964
		private int GRtzdsJyfiWJtCyjEQeDPJdVgQpc;

		// Token: 0x040003C5 RID: 965
		private int RkJYdzGeeWwCfpcpAGZKeamfCGCMA;

		// Token: 0x040003C6 RID: 966
		private int WErGVWftgDiuLKjYKGHrIWzhehUv = -1;

		// Token: 0x040003C7 RID: 967
		private static int ahwLZKKKkhgsJqzQavxCxFNpbzNe;
	}
}
