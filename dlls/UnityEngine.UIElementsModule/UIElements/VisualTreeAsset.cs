using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine.Assertions;

namespace UnityEngine.UIElements
{
	// Token: 0x020003DD RID: 989
	[HelpURL("UIE-VisualTree-landing")]
	[Serializable]
	public class VisualTreeAsset : ScriptableObject
	{
		// Token: 0x1700078A RID: 1930
		// (get) Token: 0x0600205E RID: 8286 RVA: 0x0007A350 File Offset: 0x00078550
		// (set) Token: 0x0600205F RID: 8287 RVA: 0x0007A368 File Offset: 0x00078568
		public bool importedWithErrors
		{
			get
			{
				return this.m_ImportedWithErrors;
			}
			internal set
			{
				this.m_ImportedWithErrors = value;
			}
		}

		// Token: 0x1700078B RID: 1931
		// (get) Token: 0x06002060 RID: 8288 RVA: 0x0007A374 File Offset: 0x00078574
		// (set) Token: 0x06002061 RID: 8289 RVA: 0x0007A38C File Offset: 0x0007858C
		public bool importedWithWarnings
		{
			get
			{
				return this.m_ImportedWithWarnings;
			}
			internal set
			{
				this.m_ImportedWithWarnings = value;
			}
		}

		// Token: 0x06002062 RID: 8290 RVA: 0x0007A398 File Offset: 0x00078598
		internal int GetNextChildSerialNumber()
		{
			List<VisualElementAsset> visualElementAssets = this.m_VisualElementAssets;
			int num = (visualElementAssets != null) ? visualElementAssets.Count : 0;
			int num2 = num;
			List<TemplateAsset> templateAssets = this.m_TemplateAssets;
			num = num2 + ((templateAssets != null) ? templateAssets.Count : 0);
			int num3 = num;
			List<VisualTreeAsset.UxmlObjectEntry> uxmlObjectEntries = this.m_UxmlObjectEntries;
			return num3 + ((uxmlObjectEntries != null) ? uxmlObjectEntries.Count : 0);
		}

		// Token: 0x1700078C RID: 1932
		// (get) Token: 0x06002063 RID: 8291 RVA: 0x0007A3E8 File Offset: 0x000785E8
		public IEnumerable<VisualTreeAsset> templateDependencies
		{
			get
			{
				bool flag = this.m_Usings == null || this.m_Usings.Count == 0;
				if (flag)
				{
					yield break;
				}
				HashSet<VisualTreeAsset> sent = new HashSet<VisualTreeAsset>();
				foreach (VisualTreeAsset.UsingEntry entry in this.m_Usings)
				{
					bool flag2 = entry.asset != null && !sent.Contains(entry.asset);
					if (flag2)
					{
						sent.Add(entry.asset);
						yield return entry.asset;
					}
					else
					{
						bool flag3 = !string.IsNullOrEmpty(entry.path);
						if (flag3)
						{
							VisualTreeAsset vta = Panel.LoadResource(entry.path, typeof(VisualTreeAsset), GUIUtility.pixelsPerPoint) as VisualTreeAsset;
							bool flag4 = vta != null && !sent.Contains(entry.asset);
							if (flag4)
							{
								sent.Add(entry.asset);
								yield return vta;
							}
							vta = null;
						}
					}
					entry = default(VisualTreeAsset.UsingEntry);
				}
				List<VisualTreeAsset.UsingEntry>.Enumerator enumerator = default(List<VisualTreeAsset.UsingEntry>.Enumerator);
				yield break;
				yield break;
			}
		}

		// Token: 0x1700078D RID: 1933
		// (get) Token: 0x06002064 RID: 8292 RVA: 0x0007A408 File Offset: 0x00078608
		public IEnumerable<StyleSheet> stylesheets
		{
			get
			{
				HashSet<StyleSheet> sent = new HashSet<StyleSheet>();
				foreach (VisualElementAsset vea in this.m_VisualElementAssets)
				{
					bool hasStylesheets = vea.hasStylesheets;
					if (hasStylesheets)
					{
						foreach (StyleSheet stylesheet in vea.stylesheets)
						{
							bool flag = !sent.Contains(stylesheet);
							if (flag)
							{
								sent.Add(stylesheet);
								yield return stylesheet;
							}
							stylesheet = null;
						}
						List<StyleSheet>.Enumerator enumerator2 = default(List<StyleSheet>.Enumerator);
					}
					bool hasStylesheetPaths = vea.hasStylesheetPaths;
					if (hasStylesheetPaths)
					{
						foreach (string stylesheetPath in vea.stylesheetPaths)
						{
							StyleSheet stylesheet2 = Panel.LoadResource(stylesheetPath, typeof(StyleSheet), GUIUtility.pixelsPerPoint) as StyleSheet;
							bool flag2 = stylesheet2 != null && !sent.Contains(stylesheet2);
							if (flag2)
							{
								sent.Add(stylesheet2);
								yield return stylesheet2;
							}
							stylesheet2 = null;
							stylesheetPath = null;
						}
						List<string>.Enumerator enumerator3 = default(List<string>.Enumerator);
					}
					vea = null;
				}
				List<VisualElementAsset>.Enumerator enumerator = default(List<VisualElementAsset>.Enumerator);
				yield break;
				yield break;
			}
		}

		// Token: 0x1700078E RID: 1934
		// (get) Token: 0x06002065 RID: 8293 RVA: 0x0007A428 File Offset: 0x00078628
		// (set) Token: 0x06002066 RID: 8294 RVA: 0x0007A440 File Offset: 0x00078640
		internal List<VisualElementAsset> visualElementAssets
		{
			get
			{
				return this.m_VisualElementAssets;
			}
			set
			{
				this.m_VisualElementAssets = value;
			}
		}

		// Token: 0x1700078F RID: 1935
		// (get) Token: 0x06002067 RID: 8295 RVA: 0x0007A44C File Offset: 0x0007864C
		// (set) Token: 0x06002068 RID: 8296 RVA: 0x0007A464 File Offset: 0x00078664
		internal List<TemplateAsset> templateAssets
		{
			get
			{
				return this.m_TemplateAssets;
			}
			set
			{
				this.m_TemplateAssets = value;
			}
		}

		// Token: 0x17000790 RID: 1936
		// (get) Token: 0x06002069 RID: 8297 RVA: 0x0007A46E File Offset: 0x0007866E
		internal List<VisualTreeAsset.UxmlObjectEntry> uxmlObjectEntries
		{
			get
			{
				return this.m_UxmlObjectEntries;
			}
		}

		// Token: 0x17000791 RID: 1937
		// (get) Token: 0x0600206A RID: 8298 RVA: 0x0007A476 File Offset: 0x00078676
		internal List<int> uxmlObjectIds
		{
			get
			{
				return this.m_UxmlObjectIds;
			}
		}

		// Token: 0x0600206B RID: 8299 RVA: 0x0007A480 File Offset: 0x00078680
		internal void RegisterUxmlObject(UxmlObjectAsset uxmlObjectAsset)
		{
			if (this.m_UxmlObjectEntries == null)
			{
				this.m_UxmlObjectEntries = new List<VisualTreeAsset.UxmlObjectEntry>();
			}
			if (this.m_UxmlObjectIds == null)
			{
				this.m_UxmlObjectIds = new List<int>();
			}
			VisualTreeAsset.UxmlObjectEntry uxmlObjectEntry = this.GetUxmlObjectEntry(uxmlObjectAsset.parentId);
			bool flag = uxmlObjectEntry.uxmlObjectAssets != null;
			if (flag)
			{
				uxmlObjectEntry.uxmlObjectAssets.Add(uxmlObjectAsset);
			}
			else
			{
				this.m_UxmlObjectEntries.Add(new VisualTreeAsset.UxmlObjectEntry(uxmlObjectAsset.parentId, new List<UxmlObjectAsset>
				{
					uxmlObjectAsset
				}));
				this.m_UxmlObjectIds.Add(uxmlObjectAsset.id);
			}
		}

		// Token: 0x0600206C RID: 8300 RVA: 0x0007A518 File Offset: 0x00078718
		internal List<T> GetUxmlObjects<T>(IUxmlAttributes asset, CreationContext cc) where T : new()
		{
			bool flag = this.m_UxmlObjectEntries == null;
			List<T> result;
			if (flag)
			{
				result = null;
			}
			else
			{
				UxmlAsset uxmlAsset = asset as UxmlAsset;
				bool flag2 = uxmlAsset != null;
				if (flag2)
				{
					VisualTreeAsset.UxmlObjectEntry uxmlObjectEntry = this.GetUxmlObjectEntry(uxmlAsset.id);
					bool flag3 = uxmlObjectEntry.uxmlObjectAssets != null;
					if (flag3)
					{
						List<T> list = null;
						foreach (UxmlObjectAsset uxmlObjectAsset in uxmlObjectEntry.uxmlObjectAssets)
						{
							IBaseUxmlObjectFactory uxmlObjectFactory = this.GetUxmlObjectFactory(uxmlObjectAsset);
							IUxmlObjectFactory<T> uxmlObjectFactory2 = uxmlObjectFactory as IUxmlObjectFactory<T>;
							bool flag4 = uxmlObjectFactory2 == null;
							if (!flag4)
							{
								T item = uxmlObjectFactory2.CreateObject(uxmlObjectAsset, cc);
								bool flag5 = list == null;
								if (flag5)
								{
									list = new List<T>
									{
										item
									};
								}
								else
								{
									list.Add(item);
								}
							}
						}
						return list;
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x0600206D RID: 8301 RVA: 0x0007A61C File Offset: 0x0007881C
		internal bool AssetEntryExists(string path, Type type)
		{
			bool flag = this.m_AssetEntries == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				foreach (VisualTreeAsset.AssetEntry assetEntry in this.m_AssetEntries)
				{
					bool flag2 = assetEntry.path == path && assetEntry.type == type;
					if (flag2)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x0600206E RID: 8302 RVA: 0x0007A6AC File Offset: 0x000788AC
		internal void RegisterAssetEntry(string path, Type type, Object asset)
		{
			if (this.m_AssetEntries == null)
			{
				this.m_AssetEntries = new List<VisualTreeAsset.AssetEntry>();
			}
			this.m_AssetEntries.Add(new VisualTreeAsset.AssetEntry(path, type, asset));
		}

		// Token: 0x0600206F RID: 8303 RVA: 0x0007A6D8 File Offset: 0x000788D8
		internal T GetAsset<T>(string path) where T : Object
		{
			foreach (VisualTreeAsset.AssetEntry assetEntry in this.m_AssetEntries)
			{
				bool flag = assetEntry.path.Equals(path) && assetEntry.type == typeof(T);
				if (flag)
				{
					return assetEntry.asset as T;
				}
			}
			return default(T);
		}

		// Token: 0x06002070 RID: 8304 RVA: 0x0007A778 File Offset: 0x00078978
		internal VisualTreeAsset.UxmlObjectEntry GetUxmlObjectEntry(int id)
		{
			bool flag = this.m_UxmlObjectEntries != null;
			if (flag)
			{
				foreach (VisualTreeAsset.UxmlObjectEntry uxmlObjectEntry in this.m_UxmlObjectEntries)
				{
					bool flag2 = uxmlObjectEntry.parentId == id;
					if (flag2)
					{
						return uxmlObjectEntry;
					}
				}
			}
			return default(VisualTreeAsset.UxmlObjectEntry);
		}

		// Token: 0x06002071 RID: 8305 RVA: 0x0007A7FC File Offset: 0x000789FC
		private IBaseUxmlObjectFactory GetUxmlObjectFactory(UxmlObjectAsset uxmlObjectAsset)
		{
			List<IBaseUxmlObjectFactory> list;
			bool flag = !UxmlObjectFactoryRegistry.TryGetFactories(uxmlObjectAsset.fullTypeName, out list);
			IBaseUxmlObjectFactory result;
			if (flag)
			{
				Debug.LogErrorFormat("Element '{0}' has no registered factory method.", new object[]
				{
					uxmlObjectAsset.fullTypeName
				});
				result = null;
			}
			else
			{
				IBaseUxmlObjectFactory baseUxmlObjectFactory = null;
				CreationContext cc = new CreationContext(null, this, null);
				foreach (IBaseUxmlObjectFactory baseUxmlObjectFactory2 in list)
				{
					bool flag2 = baseUxmlObjectFactory2.AcceptsAttributeBag(uxmlObjectAsset, cc);
					if (flag2)
					{
						baseUxmlObjectFactory = baseUxmlObjectFactory2;
						break;
					}
				}
				bool flag3 = baseUxmlObjectFactory == null;
				if (flag3)
				{
					Debug.LogErrorFormat("Element '{0}' has a no factory that accept the set of XML attributes specified.", new object[]
					{
						uxmlObjectAsset.fullTypeName
					});
					result = null;
				}
				else
				{
					result = baseUxmlObjectFactory;
				}
			}
			return result;
		}

		// Token: 0x17000792 RID: 1938
		// (get) Token: 0x06002072 RID: 8306 RVA: 0x0007A8D4 File Offset: 0x00078AD4
		// (set) Token: 0x06002073 RID: 8307 RVA: 0x0007A8EC File Offset: 0x00078AEC
		internal List<VisualTreeAsset.SlotDefinition> slots
		{
			get
			{
				return this.m_Slots;
			}
			set
			{
				this.m_Slots = value;
			}
		}

		// Token: 0x17000793 RID: 1939
		// (get) Token: 0x06002074 RID: 8308 RVA: 0x0007A8F8 File Offset: 0x00078AF8
		// (set) Token: 0x06002075 RID: 8309 RVA: 0x0007A910 File Offset: 0x00078B10
		internal int contentContainerId
		{
			get
			{
				return this.m_ContentContainerId;
			}
			set
			{
				this.m_ContentContainerId = value;
			}
		}

		// Token: 0x06002076 RID: 8310 RVA: 0x0007A91C File Offset: 0x00078B1C
		public TemplateContainer Instantiate()
		{
			TemplateContainer templateContainer = new TemplateContainer(base.name);
			try
			{
				this.CloneTree(templateContainer, VisualTreeAsset.s_TemporarySlotInsertionPoints, null);
			}
			finally
			{
				VisualTreeAsset.s_TemporarySlotInsertionPoints.Clear();
			}
			return templateContainer;
		}

		// Token: 0x06002077 RID: 8311 RVA: 0x0007A96C File Offset: 0x00078B6C
		public TemplateContainer Instantiate(string bindingPath)
		{
			TemplateContainer templateContainer = this.Instantiate();
			templateContainer.bindingPath = bindingPath;
			return templateContainer;
		}

		// Token: 0x06002078 RID: 8312 RVA: 0x0007A990 File Offset: 0x00078B90
		public TemplateContainer CloneTree()
		{
			return this.Instantiate();
		}

		// Token: 0x06002079 RID: 8313 RVA: 0x0007A9A8 File Offset: 0x00078BA8
		public TemplateContainer CloneTree(string bindingPath)
		{
			return this.Instantiate(bindingPath);
		}

		// Token: 0x0600207A RID: 8314 RVA: 0x0007A9C4 File Offset: 0x00078BC4
		public void CloneTree(VisualElement target)
		{
			int num;
			int num2;
			this.CloneTree(target, out num, out num2);
		}

		// Token: 0x0600207B RID: 8315 RVA: 0x0007A9E0 File Offset: 0x00078BE0
		public void CloneTree(VisualElement target, out int firstElementIndex, out int elementAddedCount)
		{
			bool flag = target == null;
			if (flag)
			{
				throw new ArgumentNullException("target");
			}
			firstElementIndex = target.childCount;
			try
			{
				this.CloneTree(target, VisualTreeAsset.s_TemporarySlotInsertionPoints, null);
			}
			finally
			{
				elementAddedCount = target.childCount - firstElementIndex;
				VisualTreeAsset.s_TemporarySlotInsertionPoints.Clear();
			}
		}

		// Token: 0x0600207C RID: 8316 RVA: 0x0007AA44 File Offset: 0x00078C44
		internal void CloneTree(VisualElement target, Dictionary<string, VisualElement> slotInsertionPoints, List<TemplateAsset.AttributeOverride> attributeOverrides)
		{
			bool flag = target == null;
			if (flag)
			{
				throw new ArgumentNullException("target");
			}
			bool flag2 = (this.visualElementAssets == null || this.visualElementAssets.Count <= 0) && (this.templateAssets == null || this.templateAssets.Count <= 0);
			if (!flag2)
			{
				TemplateContainer templateContainer = target as TemplateContainer;
				bool flag3 = templateContainer != null;
				if (flag3)
				{
					templateContainer.templateSource = this;
				}
				Dictionary<int, List<VisualElementAsset>> dictionary = new Dictionary<int, List<VisualElementAsset>>();
				int num = (this.visualElementAssets == null) ? 0 : this.visualElementAssets.Count;
				int num2 = (this.templateAssets == null) ? 0 : this.templateAssets.Count;
				for (int i = 0; i < num + num2; i++)
				{
					VisualElementAsset visualElementAsset = (i < num) ? this.visualElementAssets[i] : this.templateAssets[i - num];
					List<VisualElementAsset> list;
					bool flag4 = !dictionary.TryGetValue(visualElementAsset.parentId, out list);
					if (flag4)
					{
						list = new List<VisualElementAsset>();
						dictionary.Add(visualElementAsset.parentId, list);
					}
					list.Add(visualElementAsset);
				}
				List<VisualElementAsset> list2;
				dictionary.TryGetValue(0, out list2);
				bool flag5 = list2 == null || list2.Count == 0;
				if (!flag5)
				{
					Debug.Assert(list2.Count == 1);
					VisualElementAsset visualElementAsset2 = list2[0];
					VisualTreeAsset.AssignClassListFromAssetToElement(visualElementAsset2, target);
					VisualTreeAsset.AssignStyleSheetFromAssetToElement(visualElementAsset2, target);
					list2.Clear();
					dictionary.TryGetValue(visualElementAsset2.id, out list2);
					bool flag6 = list2 == null || list2.Count == 0;
					if (!flag6)
					{
						list2.Sort(new Comparison<VisualElementAsset>(VisualTreeAsset.CompareForOrder));
						foreach (VisualElementAsset visualElementAsset3 in list2)
						{
							Assert.IsNotNull<VisualElementAsset>(visualElementAsset3);
							VisualElement visualElement = this.CloneSetupRecursively(visualElementAsset3, dictionary, new CreationContext(slotInsertionPoints, attributeOverrides, this, target));
							bool flag7 = visualElement == null;
							if (!flag7)
							{
								visualElement.visualTreeAssetSource = this;
								target.hierarchy.Add(visualElement);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600207D RID: 8317 RVA: 0x0007AC94 File Offset: 0x00078E94
		private VisualElement CloneSetupRecursively(VisualElementAsset root, Dictionary<int, List<VisualElementAsset>> idToChildren, CreationContext context)
		{
			bool skipClone = root.skipClone;
			VisualElement result;
			if (skipClone)
			{
				result = null;
			}
			else
			{
				VisualElement visualElement = VisualTreeAsset.Create(root, context);
				bool flag = visualElement == null;
				if (flag)
				{
					result = null;
				}
				else
				{
					bool flag2 = root.id == context.visualTreeAsset.contentContainerId;
					if (flag2)
					{
						bool flag3 = context.target is TemplateContainer;
						if (flag3)
						{
							((TemplateContainer)context.target).SetContentContainer(visualElement);
						}
						else
						{
							Debug.LogError("Trying to clone a VisualTreeAsset with a custom content container into a element which is not a template container");
						}
					}
					string key;
					bool flag4 = context.slotInsertionPoints != null && this.TryGetSlotInsertionPoint(root.id, out key);
					if (flag4)
					{
						context.slotInsertionPoints.Add(key, visualElement);
					}
					bool flag5 = root.ruleIndex != -1;
					if (flag5)
					{
						bool flag6 = this.inlineSheet == null;
						if (flag6)
						{
							Debug.LogWarning("VisualElementAsset has a RuleIndex but no inlineStyleSheet");
						}
						else
						{
							StyleRule rule = this.inlineSheet.rules[root.ruleIndex];
							visualElement.SetInlineRule(this.inlineSheet, rule);
						}
					}
					bool flag7 = root.ruleIndex != -1;
					if (flag7)
					{
						bool flag8 = this.inlineSheet == null;
						if (flag8)
						{
							Debug.LogWarning("VisualElementAsset has a RuleIndex but no inlineStyleSheet");
						}
						else
						{
							StyleRule rule2 = this.inlineSheet.rules[root.ruleIndex];
							visualElement.SetInlineRule(this.inlineSheet, rule2);
						}
					}
					TemplateAsset templateAsset = root as TemplateAsset;
					List<VisualElementAsset> list;
					bool flag9 = idToChildren.TryGetValue(root.id, out list);
					if (flag9)
					{
						list.Sort(new Comparison<VisualElementAsset>(VisualTreeAsset.CompareForOrder));
						using (List<VisualElementAsset>.Enumerator enumerator = list.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								VisualElementAsset childVea = enumerator.Current;
								VisualElement visualElement2 = this.CloneSetupRecursively(childVea, idToChildren, context);
								bool flag10 = visualElement2 == null;
								if (!flag10)
								{
									bool flag11 = templateAsset == null;
									if (flag11)
									{
										visualElement.Add(visualElement2);
									}
									else
									{
										int num = (templateAsset.slotUsages == null) ? -1 : templateAsset.slotUsages.FindIndex((VisualTreeAsset.SlotUsageEntry u) => u.assetId == childVea.id);
										bool flag12 = num != -1;
										if (flag12)
										{
											string slotName = templateAsset.slotUsages[num].slotName;
											Assert.IsFalse(string.IsNullOrEmpty(slotName), "a lost name should not be null or empty, this probably points to an importer or serialization bug");
											VisualElement visualElement3;
											bool flag13 = context.slotInsertionPoints == null || !context.slotInsertionPoints.TryGetValue(slotName, out visualElement3);
											if (flag13)
											{
												Debug.LogErrorFormat("Slot '{0}' was not found. Existing slots: {1}", new object[]
												{
													slotName,
													(context.slotInsertionPoints == null) ? string.Empty : string.Join(", ", context.slotInsertionPoints.Keys.ToArray<string>())
												});
												visualElement.Add(visualElement2);
											}
											else
											{
												visualElement3.Add(visualElement2);
											}
										}
										else
										{
											visualElement.Add(visualElement2);
										}
									}
								}
							}
						}
					}
					bool flag14 = templateAsset != null && context.slotInsertionPoints != null;
					if (flag14)
					{
						context.slotInsertionPoints.Clear();
					}
					result = visualElement;
				}
			}
			return result;
		}

		// Token: 0x0600207E RID: 8318 RVA: 0x0007AFE4 File Offset: 0x000791E4
		private static int CompareForOrder(VisualElementAsset a, VisualElementAsset b)
		{
			return a.orderInDocument.CompareTo(b.orderInDocument);
		}

		// Token: 0x0600207F RID: 8319 RVA: 0x0007B008 File Offset: 0x00079208
		internal bool TryGetSlotInsertionPoint(int insertionPointId, out string slotName)
		{
			bool flag = this.m_Slots == null;
			bool result;
			if (flag)
			{
				slotName = null;
				result = false;
			}
			else
			{
				for (int i = 0; i < this.m_Slots.Count; i++)
				{
					VisualTreeAsset.SlotDefinition slotDefinition = this.m_Slots[i];
					bool flag2 = slotDefinition.insertionPointId == insertionPointId;
					if (flag2)
					{
						slotName = slotDefinition.name;
						return true;
					}
				}
				slotName = null;
				result = false;
			}
			return result;
		}

		// Token: 0x06002080 RID: 8320 RVA: 0x0007B07C File Offset: 0x0007927C
		internal VisualTreeAsset ResolveTemplate(string templateName)
		{
			bool flag = this.m_Usings == null || this.m_Usings.Count == 0;
			VisualTreeAsset result;
			if (flag)
			{
				result = null;
			}
			else
			{
				int num = this.m_Usings.BinarySearch(new VisualTreeAsset.UsingEntry(templateName, string.Empty), VisualTreeAsset.UsingEntry.comparer);
				bool flag2 = num < 0;
				if (flag2)
				{
					result = null;
				}
				else
				{
					bool flag3 = this.m_Usings[num].asset;
					if (flag3)
					{
						result = this.m_Usings[num].asset;
					}
					else
					{
						string path = this.m_Usings[num].path;
						result = (Panel.LoadResource(path, typeof(VisualTreeAsset), GUIUtility.pixelsPerPoint) as VisualTreeAsset);
					}
				}
			}
			return result;
		}

		// Token: 0x06002081 RID: 8321 RVA: 0x0007B138 File Offset: 0x00079338
		internal static VisualElement Create(VisualElementAsset asset, CreationContext ctx)
		{
			VisualTreeAsset.<>c__DisplayClass65_0 CS$<>8__locals1;
			CS$<>8__locals1.asset = asset;
			List<IUxmlFactory> list;
			bool flag = !VisualElementFactoryRegistry.TryGetValue(CS$<>8__locals1.asset.fullTypeName, out list);
			if (flag)
			{
				bool flag2 = CS$<>8__locals1.asset.fullTypeName.StartsWith("UnityEngine.Experimental.UIElements.") || CS$<>8__locals1.asset.fullTypeName.StartsWith("UnityEditor.Experimental.UIElements.");
				if (flag2)
				{
					string fullTypeName = CS$<>8__locals1.asset.fullTypeName.Replace(".Experimental.UIElements", ".UIElements");
					bool flag3 = !VisualElementFactoryRegistry.TryGetValue(fullTypeName, out list);
					if (flag3)
					{
						return VisualTreeAsset.<Create>g__CreateError|65_0(ref CS$<>8__locals1);
					}
				}
				else
				{
					bool flag4 = CS$<>8__locals1.asset.fullTypeName == "UXML";
					if (!flag4)
					{
						return VisualTreeAsset.<Create>g__CreateError|65_0(ref CS$<>8__locals1);
					}
					VisualElementFactoryRegistry.TryGetValue(typeof(UxmlRootElementFactory).Namespace + "." + CS$<>8__locals1.asset.fullTypeName, out list);
				}
			}
			IUxmlFactory uxmlFactory = null;
			foreach (IUxmlFactory uxmlFactory2 in list)
			{
				bool flag5 = uxmlFactory2.AcceptsAttributeBag(CS$<>8__locals1.asset, ctx);
				if (flag5)
				{
					uxmlFactory = uxmlFactory2;
					break;
				}
			}
			bool flag6 = uxmlFactory == null;
			VisualElement result;
			if (flag6)
			{
				Debug.LogErrorFormat("Element '{0}' has a no factory that accept the set of XML attributes specified.", new object[]
				{
					CS$<>8__locals1.asset.fullTypeName
				});
				result = new Label(string.Format("Type with no factory: '{0}'", CS$<>8__locals1.asset.fullTypeName));
			}
			else
			{
				VisualElement visualElement = uxmlFactory.Create(CS$<>8__locals1.asset, ctx);
				bool flag7 = visualElement != null;
				if (flag7)
				{
					VisualTreeAsset.AssignClassListFromAssetToElement(CS$<>8__locals1.asset, visualElement);
					VisualTreeAsset.AssignStyleSheetFromAssetToElement(CS$<>8__locals1.asset, visualElement);
				}
				result = visualElement;
			}
			return result;
		}

		// Token: 0x06002082 RID: 8322 RVA: 0x0007B320 File Offset: 0x00079520
		private static void AssignClassListFromAssetToElement(VisualElementAsset asset, VisualElement element)
		{
			bool flag = asset.classes != null;
			if (flag)
			{
				for (int i = 0; i < asset.classes.Length; i++)
				{
					element.AddToClassList(asset.classes[i]);
				}
			}
		}

		// Token: 0x06002083 RID: 8323 RVA: 0x0007B368 File Offset: 0x00079568
		private static void AssignStyleSheetFromAssetToElement(VisualElementAsset asset, VisualElement element)
		{
			bool hasStylesheetPaths = asset.hasStylesheetPaths;
			if (hasStylesheetPaths)
			{
				for (int i = 0; i < asset.stylesheetPaths.Count; i++)
				{
					element.AddStyleSheetPath(asset.stylesheetPaths[i]);
				}
			}
			bool hasStylesheets = asset.hasStylesheets;
			if (hasStylesheets)
			{
				for (int j = 0; j < asset.stylesheets.Count; j++)
				{
					bool flag = asset.stylesheets[j] != null;
					if (flag)
					{
						element.styleSheets.Add(asset.stylesheets[j]);
					}
				}
			}
		}

		// Token: 0x17000794 RID: 1940
		// (get) Token: 0x06002084 RID: 8324 RVA: 0x0007B418 File Offset: 0x00079618
		// (set) Token: 0x06002085 RID: 8325 RVA: 0x0007B430 File Offset: 0x00079630
		public int contentHash
		{
			get
			{
				return this.m_ContentHash;
			}
			set
			{
				this.m_ContentHash = value;
			}
		}

		// Token: 0x06002088 RID: 8328 RVA: 0x0007B450 File Offset: 0x00079650
		[CompilerGenerated]
		internal static VisualElement <Create>g__CreateError|65_0(ref VisualTreeAsset.<>c__DisplayClass65_0 A_0)
		{
			Debug.LogErrorFormat("Element '{0}' has no registered factory method.", new object[]
			{
				A_0.asset.fullTypeName
			});
			return new Label(string.Format("Unknown type: '{0}'", A_0.asset.fullTypeName));
		}

		// Token: 0x04000D53 RID: 3411
		internal static string LinkedVEAInTemplatePropertyName = "--unity-linked-vea-in-template";

		// Token: 0x04000D54 RID: 3412
		[SerializeField]
		private bool m_ImportedWithErrors;

		// Token: 0x04000D55 RID: 3413
		[SerializeField]
		private bool m_ImportedWithWarnings;

		// Token: 0x04000D56 RID: 3414
		private static readonly Dictionary<string, VisualElement> s_TemporarySlotInsertionPoints = new Dictionary<string, VisualElement>();

		// Token: 0x04000D57 RID: 3415
		[SerializeField]
		private List<VisualTreeAsset.UsingEntry> m_Usings;

		// Token: 0x04000D58 RID: 3416
		[SerializeField]
		internal StyleSheet inlineSheet;

		// Token: 0x04000D59 RID: 3417
		[SerializeField]
		private List<VisualElementAsset> m_VisualElementAssets;

		// Token: 0x04000D5A RID: 3418
		[SerializeField]
		private List<TemplateAsset> m_TemplateAssets;

		// Token: 0x04000D5B RID: 3419
		[SerializeField]
		private List<VisualTreeAsset.UxmlObjectEntry> m_UxmlObjectEntries;

		// Token: 0x04000D5C RID: 3420
		[SerializeField]
		private List<int> m_UxmlObjectIds;

		// Token: 0x04000D5D RID: 3421
		[SerializeField]
		private List<VisualTreeAsset.AssetEntry> m_AssetEntries;

		// Token: 0x04000D5E RID: 3422
		[SerializeField]
		private List<VisualTreeAsset.SlotDefinition> m_Slots;

		// Token: 0x04000D5F RID: 3423
		[SerializeField]
		private int m_ContentContainerId;

		// Token: 0x04000D60 RID: 3424
		[SerializeField]
		private int m_ContentHash;

		// Token: 0x020003DE RID: 990
		[Serializable]
		internal struct UsingEntry
		{
			// Token: 0x06002089 RID: 8329 RVA: 0x0007B49B File Offset: 0x0007969B
			public UsingEntry(string alias, string path)
			{
				this.alias = alias;
				this.path = path;
				this.asset = null;
			}

			// Token: 0x0600208A RID: 8330 RVA: 0x0007B4B3 File Offset: 0x000796B3
			public UsingEntry(string alias, VisualTreeAsset asset)
			{
				this.alias = alias;
				this.path = null;
				this.asset = asset;
			}

			// Token: 0x04000D61 RID: 3425
			internal static readonly IComparer<VisualTreeAsset.UsingEntry> comparer = new VisualTreeAsset.UsingEntryComparer();

			// Token: 0x04000D62 RID: 3426
			[SerializeField]
			public string alias;

			// Token: 0x04000D63 RID: 3427
			[SerializeField]
			public string path;

			// Token: 0x04000D64 RID: 3428
			[SerializeField]
			public VisualTreeAsset asset;
		}

		// Token: 0x020003DF RID: 991
		private class UsingEntryComparer : IComparer<VisualTreeAsset.UsingEntry>
		{
			// Token: 0x0600208C RID: 8332 RVA: 0x0007B4D8 File Offset: 0x000796D8
			public int Compare(VisualTreeAsset.UsingEntry x, VisualTreeAsset.UsingEntry y)
			{
				return string.CompareOrdinal(x.alias, y.alias);
			}
		}

		// Token: 0x020003E0 RID: 992
		[Serializable]
		internal struct SlotDefinition
		{
			// Token: 0x04000D65 RID: 3429
			[SerializeField]
			public string name;

			// Token: 0x04000D66 RID: 3430
			[SerializeField]
			public int insertionPointId;
		}

		// Token: 0x020003E1 RID: 993
		[Serializable]
		internal struct SlotUsageEntry
		{
			// Token: 0x0600208E RID: 8334 RVA: 0x0007B4FB File Offset: 0x000796FB
			public SlotUsageEntry(string slotName, int assetId)
			{
				this.slotName = slotName;
				this.assetId = assetId;
			}

			// Token: 0x04000D67 RID: 3431
			[SerializeField]
			public string slotName;

			// Token: 0x04000D68 RID: 3432
			[SerializeField]
			public int assetId;
		}

		// Token: 0x020003E2 RID: 994
		[Serializable]
		internal struct UxmlObjectEntry
		{
			// Token: 0x0600208F RID: 8335 RVA: 0x0007B50C File Offset: 0x0007970C
			public UxmlObjectEntry(int parentId, List<UxmlObjectAsset> uxmlObjectAssets)
			{
				this.parentId = parentId;
				this.uxmlObjectAssets = uxmlObjectAssets;
			}

			// Token: 0x04000D69 RID: 3433
			[SerializeField]
			public int parentId;

			// Token: 0x04000D6A RID: 3434
			[SerializeField]
			public List<UxmlObjectAsset> uxmlObjectAssets;
		}

		// Token: 0x020003E3 RID: 995
		[Serializable]
		private struct AssetEntry
		{
			// Token: 0x17000795 RID: 1941
			// (get) Token: 0x06002090 RID: 8336 RVA: 0x0007B520 File Offset: 0x00079720
			public Type type
			{
				get
				{
					Type result;
					if ((result = this.m_CachedType) == null)
					{
						result = (this.m_CachedType = Type.GetType(this.typeFullName));
					}
					return result;
				}
			}

			// Token: 0x06002091 RID: 8337 RVA: 0x0007B54B File Offset: 0x0007974B
			public AssetEntry(string path, Type type, Object asset)
			{
				this.path = path;
				this.typeFullName = type.AssemblyQualifiedName;
				this.asset = asset;
				this.m_CachedType = type;
			}

			// Token: 0x04000D6B RID: 3435
			[SerializeField]
			public string path;

			// Token: 0x04000D6C RID: 3436
			[SerializeField]
			public string typeFullName;

			// Token: 0x04000D6D RID: 3437
			[SerializeField]
			public Object asset;

			// Token: 0x04000D6E RID: 3438
			private Type m_CachedType;
		}
	}
}
