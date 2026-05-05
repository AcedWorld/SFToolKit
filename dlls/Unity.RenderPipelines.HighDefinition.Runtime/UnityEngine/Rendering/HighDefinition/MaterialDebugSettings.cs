using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine.Rendering.HighDefinition.Attributes;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000049 RID: 73
	[Serializable]
	public class MaterialDebugSettings
	{
		// Token: 0x06000226 RID: 550 RVA: 0x0000C804 File Offset: 0x0000AA04
		static MaterialDebugSettings()
		{
			MaterialDebugSettings.BuildDebugRepresentation();
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000C87C File Offset: 0x0000AA7C
		private static void FillWithProperties(Type type, ref List<GUIContent> debugViewMaterialStringsList, ref List<int> debugViewMaterialValuesList, string className = "")
		{
			GenerateHLSL customAttribute = type.GetCustomAttribute<GenerateHLSL>();
			if (!customAttribute.needParamDebug)
			{
				return;
			}
			List<ValueTuple<GUIContent, int>> list;
			using (ListPool<ValueTuple<GUIContent, int>>.Get(out list))
			{
				FieldInfo[] fields = type.GetFields();
				int num = 0;
				foreach (FieldInfo fieldInfo in fields)
				{
					List<string> list2 = new List<string>();
					if (Attribute.IsDefined(fieldInfo, typeof(PackingAttribute)))
					{
						foreach (PackingAttribute packingAttribute in (PackingAttribute[])fieldInfo.GetCustomAttributes(typeof(PackingAttribute), false))
						{
							list2.AddRange(packingAttribute.displayNames);
						}
					}
					else
					{
						list2.Add(fieldInfo.Name);
					}
					if (Attribute.IsDefined(fieldInfo, typeof(SurfaceDataAttributes)))
					{
						SurfaceDataAttributes[] array3 = (SurfaceDataAttributes[])fieldInfo.GetCustomAttributes(typeof(SurfaceDataAttributes), false);
						if (array3[0].displayNames.Length != 0 && array3[0].displayNames[0] != "")
						{
							list2.Clear();
							list2.AddRange(array3[0].displayNames);
						}
					}
					foreach (string str in list2)
					{
						list.Add(new ValueTuple<GUIContent, int>(new GUIContent(className + str), customAttribute.paramDefinesStart + num));
						num++;
					}
				}
				foreach (ValueTuple<GUIContent, int> valueTuple in from t in list
				orderby t.Item1.text
				select t)
				{
					GUIContent item = valueTuple.Item1;
					int item2 = valueTuple.Item2;
					debugViewMaterialStringsList.Add(item);
					debugViewMaterialValuesList.Add(item2);
				}
			}
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000CAB4 File Offset: 0x0000ACB4
		private static void FillWithPropertiesEnum(Type type, ref List<GUIContent> debugViewMaterialStringsList, ref List<int> debugViewMaterialValuesList, string prefix)
		{
			string[] names = Enum.GetNames(type);
			int num = 0;
			foreach (object obj in Enum.GetValues(type))
			{
				string text = prefix + names[num];
				debugViewMaterialStringsList.Add(new GUIContent(text));
				debugViewMaterialValuesList.Add((int)obj);
				num++;
			}
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000CB38 File Offset: 0x0000AD38
		private static List<MaterialDebugSettings.MaterialItem> GetAllMaterialDatas()
		{
			List<RenderPipelineMaterial> renderPipelineMaterialList = HDUtils.GetRenderPipelineMaterialList();
			foreach (RenderPipelineMaterial renderPipelineMaterial in renderPipelineMaterialList)
			{
				if (renderPipelineMaterial.IsDefferedMaterial())
				{
					renderPipelineMaterial.GetType().GetNestedType("BSDFData");
				}
			}
			List<MaterialDebugSettings.MaterialItem> list = new List<MaterialDebugSettings.MaterialItem>();
			int num = 0;
			int num2 = 0;
			foreach (RenderPipelineMaterial renderPipelineMaterial2 in renderPipelineMaterialList)
			{
				Type type = renderPipelineMaterial2.GetType();
				MaterialDebugSettings.MaterialItem materialItem = new MaterialDebugSettings.MaterialItem
				{
					className = type.Name + "/",
					surfaceDataType = type.GetNestedType("SurfaceData"),
					bsdfDataType = type.GetNestedType("BSDFData")
				};
				num += materialItem.surfaceDataType.GetFields().Length;
				num2 += materialItem.bsdfDataType.GetFields().Length;
				list.Add(materialItem);
			}
			return list;
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000CC5C File Offset: 0x0000AE5C
		private static void BuildDebugRepresentation()
		{
			if (!MaterialDebugSettings.isDebugViewMaterialInit)
			{
				List<MaterialDebugSettings.MaterialItem> allMaterialDatas = MaterialDebugSettings.GetAllMaterialDatas();
				MaterialDebugSettings.FillMaterialsInfos(allMaterialDatas);
				List<GUIContent> list = new List<GUIContent>();
				List<int> list2 = new List<int>();
				List<GUIContent> list3 = new List<GUIContent>();
				List<int> list4 = new List<int>();
				List<GUIContent> list5 = new List<GUIContent>();
				List<int> list6 = new List<int>();
				List<GUIContent> list7 = new List<GUIContent>();
				List<int> list8 = new List<int>();
				List<GUIContent> list9 = new List<GUIContent>();
				List<int> list10 = new List<int>();
				list.Add(new GUIContent("None"));
				list2.Add(0);
				foreach (MaterialDebugSettings.MaterialItem materialItem in allMaterialDatas)
				{
					MaterialDebugSettings.FillWithProperties(materialItem.bsdfDataType, ref list, ref list2, materialItem.className);
				}
				MaterialDebugSettings.FillWithPropertiesEnum(typeof(DebugViewVarying), ref list3, ref list4, "");
				MaterialDebugSettings.FillWithPropertiesEnum(typeof(DebugViewProperties), ref list5, ref list6, "");
				MaterialDebugSettings.FillWithPropertiesEnum(typeof(DebugViewGbuffer), ref list9, ref list10, "");
				MaterialDebugSettings.FillWithProperties(typeof(Lit.BSDFData), ref list9, ref list10, "");
				MaterialDebugSettings.debugViewEngineStrings = list.ToArray();
				MaterialDebugSettings.debugViewEngineValues = list2.ToArray();
				MaterialDebugSettings.debugViewMaterialVaryingStrings = list3.ToArray();
				MaterialDebugSettings.debugViewMaterialVaryingValues = list4.ToArray();
				MaterialDebugSettings.debugViewMaterialPropertiesStrings = list5.ToArray();
				MaterialDebugSettings.debugViewMaterialPropertiesValues = list6.ToArray();
				MaterialDebugSettings.debugViewMaterialTextureStrings = list7.ToArray();
				MaterialDebugSettings.debugViewMaterialTextureValues = list8.ToArray();
				MaterialDebugSettings.debugViewMaterialGBufferStrings = list9.ToArray();
				MaterialDebugSettings.debugViewMaterialGBufferValues = list10.ToArray();
				Dictionary<MaterialSharedProperty, List<int>> dictionary = new Dictionary<MaterialSharedProperty, List<int>>
				{
					{
						MaterialSharedProperty.Albedo,
						new List<int>()
					},
					{
						MaterialSharedProperty.Normal,
						new List<int>()
					},
					{
						MaterialSharedProperty.Smoothness,
						new List<int>()
					},
					{
						MaterialSharedProperty.AmbientOcclusion,
						new List<int>()
					},
					{
						MaterialSharedProperty.Metal,
						new List<int>()
					},
					{
						MaterialSharedProperty.Specular,
						new List<int>()
					},
					{
						MaterialSharedProperty.Alpha,
						new List<int>()
					}
				};
				int paramDefinesStart = typeof(Builtin.BuiltinData).GetCustomAttribute<GenerateHLSL>().paramDefinesStart;
				int num = 0;
				foreach (FieldInfo fieldInfo in typeof(Builtin.BuiltinData).GetFields())
				{
					if (Attribute.IsDefined(fieldInfo, typeof(MaterialSharedPropertyMappingAttribute)))
					{
						MaterialSharedPropertyMappingAttribute[] array2 = (MaterialSharedPropertyMappingAttribute[])fieldInfo.GetCustomAttributes(typeof(MaterialSharedPropertyMappingAttribute), false);
						dictionary[array2[0].property].Add(paramDefinesStart + num);
					}
					SurfaceDataAttributes[] array3 = (SurfaceDataAttributes[])fieldInfo.GetCustomAttributes(typeof(SurfaceDataAttributes), false);
					if (array3.Length != 0)
					{
						num += array3[0].displayNames.Length;
					}
				}
				foreach (MaterialDebugSettings.MaterialItem materialItem2 in allMaterialDatas)
				{
					GenerateHLSL customAttribute = materialItem2.surfaceDataType.GetCustomAttribute<GenerateHLSL>();
					paramDefinesStart = customAttribute.paramDefinesStart;
					if (customAttribute.needParamDebug)
					{
						FieldInfo[] fields = materialItem2.surfaceDataType.GetFields();
						num = 0;
						foreach (FieldInfo fieldInfo2 in fields)
						{
							if (Attribute.IsDefined(fieldInfo2, typeof(MaterialSharedPropertyMappingAttribute)))
							{
								MaterialSharedPropertyMappingAttribute[] array4 = (MaterialSharedPropertyMappingAttribute[])fieldInfo2.GetCustomAttributes(typeof(MaterialSharedPropertyMappingAttribute), false);
								dictionary[array4[0].property].Add(paramDefinesStart + num);
							}
							SurfaceDataAttributes[] array5 = (SurfaceDataAttributes[])fieldInfo2.GetCustomAttributes(typeof(SurfaceDataAttributes), false);
							if (array5.Length != 0)
							{
								num += array5[0].displayNames.Length;
							}
						}
						if (!(materialItem2.bsdfDataType == null))
						{
							GenerateHLSL customAttribute2 = materialItem2.bsdfDataType.GetCustomAttribute<GenerateHLSL>();
							paramDefinesStart = customAttribute2.paramDefinesStart;
							if (customAttribute2.needParamDebug)
							{
								FieldInfo[] fields2 = materialItem2.bsdfDataType.GetFields();
								num = 0;
								foreach (FieldInfo fieldInfo3 in fields2)
								{
									if (Attribute.IsDefined(fieldInfo3, typeof(MaterialSharedPropertyMappingAttribute)))
									{
										MaterialSharedPropertyMappingAttribute[] array6 = (MaterialSharedPropertyMappingAttribute[])fieldInfo3.GetCustomAttributes(typeof(MaterialSharedPropertyMappingAttribute), false);
										dictionary[array6[0].property].Add(paramDefinesStart + num++);
									}
									SurfaceDataAttributes[] array7 = (SurfaceDataAttributes[])fieldInfo3.GetCustomAttributes(typeof(SurfaceDataAttributes), false);
									if (array7.Length != 0)
									{
										num += array7[0].displayNames.Length;
									}
								}
							}
						}
					}
				}
				foreach (MaterialSharedProperty key in dictionary.Keys)
				{
					MaterialDebugSettings.s_MaterialPropertyMap[key] = dictionary[key].ToArray();
				}
				MaterialDebugSettings.isDebugViewMaterialInit = true;
			}
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000D178 File Offset: 0x0000B378
		private static void FillMaterialsInfos(List<MaterialDebugSettings.MaterialItem> materialItems)
		{
			List<GUIContent> list;
			using (ListPool<GUIContent>.Get(out list))
			{
				List<int> list2;
				using (ListPool<int>.Get(out list2))
				{
					list.Add(new GUIContent("None"));
					list2.Add(0);
					MaterialDebugSettings.FillWithProperties(typeof(Builtin.BuiltinData), ref list, ref list2, "Common/");
					foreach (MaterialDebugSettings.MaterialItem materialItem in materialItems)
					{
						MaterialDebugSettings.FillWithProperties(materialItem.surfaceDataType, ref list, ref list2, materialItem.className);
					}
					MaterialDebugSettings.debugViewMaterialStrings = list.ToArray();
					MaterialDebugSettings.debugViewMaterialValues = list2.ToArray();
				}
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600022C RID: 556 RVA: 0x0000D264 File Offset: 0x0000B464
		// (set) Token: 0x0600022D RID: 557 RVA: 0x0000D26C File Offset: 0x0000B46C
		public int[] debugViewMaterial
		{
			get
			{
				return this.m_DebugViewMaterial;
			}
			internal set
			{
				int num = (value != null) ? value.Length : 0;
				if (num > 10)
				{
					Debug.LogError(string.Format("DebugViewMaterialBuffer is cannot handle {0} elements. Only first {1} are kept.", num, 10));
				}
				int num2 = Mathf.Min(10, num);
				if (num2 == 0)
				{
					this.m_DebugViewMaterial[0] = 1;
					this.m_DebugViewMaterial[1] = 0;
					return;
				}
				this.m_DebugViewMaterial[0] = num2;
				for (int i = 0; i < num2; i++)
				{
					this.m_DebugViewMaterial[i + 1] = value[i];
				}
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600022E RID: 558 RVA: 0x0000D2E5 File Offset: 0x0000B4E5
		public int debugViewEngine
		{
			get
			{
				return this.m_DebugViewEngine;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600022F RID: 559 RVA: 0x0000D2ED File Offset: 0x0000B4ED
		public DebugViewVarying debugViewVarying
		{
			get
			{
				return this.m_DebugViewVarying;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000230 RID: 560 RVA: 0x0000D2F5 File Offset: 0x0000B4F5
		public DebugViewProperties debugViewProperties
		{
			get
			{
				return this.m_DebugViewProperties;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000231 RID: 561 RVA: 0x0000D2FD File Offset: 0x0000B4FD
		public int debugViewGBuffer
		{
			get
			{
				return this.m_DebugViewGBuffer;
			}
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0000D308 File Offset: 0x0000B508
		internal float[] GetDebugMaterialIndexes()
		{
			int num = this.m_DebugViewMaterial[0];
			MaterialDebugSettings.s_DebugViewMaterialOffsetedBuffer[0] = (float)num;
			for (int i = 1; i <= num; i++)
			{
				MaterialDebugSettings.s_DebugViewMaterialOffsetedBuffer[i] = (float)(this.m_DebugViewGBuffer + this.m_DebugViewMaterial[i] + this.m_DebugViewEngine + this.m_DebugViewVarying + (int)this.m_DebugViewProperties);
			}
			return MaterialDebugSettings.s_DebugViewMaterialOffsetedBuffer;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000D364 File Offset: 0x0000B564
		public void DisableMaterialDebug()
		{
			this.debugViewMaterialCommonValue = MaterialSharedProperty.None;
			this.m_DebugViewMaterial[0] = 1;
			this.m_DebugViewMaterial[1] = 0;
			this.m_DebugViewEngine = 0;
			this.m_DebugViewVarying = DebugViewVarying.None;
			this.m_DebugViewProperties = DebugViewProperties.None;
			this.m_DebugViewGBuffer = 0;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000D39B File Offset: 0x0000B59B
		public void SetDebugViewCommonMaterialProperty(MaterialSharedProperty value)
		{
			if (value != MaterialSharedProperty.None)
			{
				this.DisableMaterialDebug();
				this.materialEnumIndex = 0;
			}
			this.debugViewMaterial = ((value == MaterialSharedProperty.None) ? null : MaterialDebugSettings.s_MaterialPropertyMap[value]);
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000D3C4 File Offset: 0x0000B5C4
		public void SetDebugViewMaterial(int value)
		{
			this.debugViewMaterialCommonValue = MaterialSharedProperty.None;
			if (value != 0)
			{
				this.DisableMaterialDebug();
				this.m_DebugViewMaterial[0] = 1;
				this.m_DebugViewMaterial[1] = value;
				return;
			}
			this.m_DebugViewMaterial[0] = 1;
			this.m_DebugViewMaterial[1] = 0;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000D3FB File Offset: 0x0000B5FB
		public void SetDebugViewEngine(int value)
		{
			if (value != 0)
			{
				this.DisableMaterialDebug();
			}
			this.m_DebugViewEngine = value;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000D40D File Offset: 0x0000B60D
		public void SetDebugViewVarying(DebugViewVarying value)
		{
			if (value != DebugViewVarying.None)
			{
				this.DisableMaterialDebug();
			}
			this.m_DebugViewVarying = value;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000D41F File Offset: 0x0000B61F
		public void SetDebugViewProperties(DebugViewProperties value)
		{
			if (value != DebugViewProperties.None)
			{
				this.DisableMaterialDebug();
			}
			this.m_DebugViewProperties = value;
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0000D431 File Offset: 0x0000B631
		public void SetDebugViewGBuffer(int value)
		{
			if (value != 0)
			{
				this.DisableMaterialDebug();
			}
			this.m_DebugViewGBuffer = value;
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000D443 File Offset: 0x0000B643
		public bool IsDebugGBufferEnabled()
		{
			return this.m_DebugViewGBuffer != 0;
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0000D450 File Offset: 0x0000B650
		public bool IsDebugViewMaterialEnabled()
		{
			int[] debugViewMaterial = this.m_DebugViewMaterial;
			int num = (debugViewMaterial != null) ? debugViewMaterial[0] : 0;
			bool flag = false;
			for (int i = 1; i <= num; i++)
			{
				flag |= (this.m_DebugViewMaterial[i] != 0);
			}
			return flag;
		}

		// Token: 0x0600023C RID: 572 RVA: 0x0000D48A File Offset: 0x0000B68A
		public bool IsDebugDisplayEnabled()
		{
			return this.m_DebugViewEngine != 0 || this.IsDebugViewMaterialEnabled() || this.m_DebugViewVarying != DebugViewVarying.None || this.m_DebugViewProperties != DebugViewProperties.None || this.IsDebugGBufferEnabled();
		}

		// Token: 0x04000202 RID: 514
		private static bool isDebugViewMaterialInit = false;

		// Token: 0x04000203 RID: 515
		internal static GUIContent[] debugViewMaterialStrings = null;

		// Token: 0x04000204 RID: 516
		internal static int[] debugViewMaterialValues = null;

		// Token: 0x04000205 RID: 517
		internal static GUIContent[] debugViewEngineStrings = null;

		// Token: 0x04000206 RID: 518
		internal static int[] debugViewEngineValues = null;

		// Token: 0x04000207 RID: 519
		internal static GUIContent[] debugViewMaterialVaryingStrings = null;

		// Token: 0x04000208 RID: 520
		internal static int[] debugViewMaterialVaryingValues = null;

		// Token: 0x04000209 RID: 521
		internal static GUIContent[] debugViewMaterialPropertiesStrings = null;

		// Token: 0x0400020A RID: 522
		internal static int[] debugViewMaterialPropertiesValues = null;

		// Token: 0x0400020B RID: 523
		internal static GUIContent[] debugViewMaterialTextureStrings = null;

		// Token: 0x0400020C RID: 524
		internal static int[] debugViewMaterialTextureValues = null;

		// Token: 0x0400020D RID: 525
		public static GUIContent[] debugViewMaterialGBufferStrings = null;

		// Token: 0x0400020E RID: 526
		public static int[] debugViewMaterialGBufferValues = null;

		// Token: 0x0400020F RID: 527
		private static Dictionary<MaterialSharedProperty, int[]> s_MaterialPropertyMap = new Dictionary<MaterialSharedProperty, int[]>();

		// Token: 0x04000210 RID: 528
		public MaterialSharedProperty debugViewMaterialCommonValue;

		// Token: 0x04000211 RID: 529
		public Color materialValidateLowColor = new Color(1f, 0f, 0f);

		// Token: 0x04000212 RID: 530
		public Color materialValidateHighColor = new Color(0f, 0f, 1f);

		// Token: 0x04000213 RID: 531
		public Color materialValidateTrueMetalColor = new Color(1f, 1f, 0f);

		// Token: 0x04000214 RID: 532
		public bool materialValidateTrueMetal;

		// Token: 0x04000215 RID: 533
		private const int kDebugViewMaterialBufferLength = 10;

		// Token: 0x04000216 RID: 534
		private static float[] s_DebugViewMaterialOffsetedBuffer = new float[11];

		// Token: 0x04000217 RID: 535
		private int[] m_DebugViewMaterial = new int[11];

		// Token: 0x04000218 RID: 536
		private int m_DebugViewEngine;

		// Token: 0x04000219 RID: 537
		private DebugViewVarying m_DebugViewVarying;

		// Token: 0x0400021A RID: 538
		private DebugViewProperties m_DebugViewProperties;

		// Token: 0x0400021B RID: 539
		private int m_DebugViewGBuffer;

		// Token: 0x0400021C RID: 540
		internal int materialEnumIndex;

		// Token: 0x02000264 RID: 612
		internal class MaterialItem
		{
			// Token: 0x04001B03 RID: 6915
			public string className;

			// Token: 0x04001B04 RID: 6916
			public Type surfaceDataType;

			// Token: 0x04001B05 RID: 6917
			public Type bsdfDataType;
		}
	}
}
