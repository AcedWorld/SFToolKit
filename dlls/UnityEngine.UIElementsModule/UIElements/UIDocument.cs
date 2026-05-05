using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace UnityEngine.UIElements
{
	// Token: 0x02000258 RID: 600
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[HelpURL("UIE-get-started-with-runtime-ui")]
	[AddComponentMenu("UI Toolkit/UI Document")]
	[DefaultExecutionOrder(-100)]
	public sealed class UIDocument : MonoBehaviour
	{
		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06001126 RID: 4390 RVA: 0x0003DEE0 File Offset: 0x0003C0E0
		// (set) Token: 0x06001127 RID: 4391 RVA: 0x0003DEF8 File Offset: 0x0003C0F8
		public PanelSettings panelSettings
		{
			get
			{
				return this.m_PanelSettings;
			}
			set
			{
				bool flag = this.parentUI == null;
				if (flag)
				{
					bool flag2 = this.m_PanelSettings == value;
					if (flag2)
					{
						this.m_PreviousPanelSettings = this.m_PanelSettings;
						return;
					}
					bool flag3 = this.m_PanelSettings != null;
					if (flag3)
					{
						this.m_PanelSettings.DetachUIDocument(this);
					}
					this.m_PanelSettings = value;
					bool flag4 = this.m_PanelSettings != null;
					if (flag4)
					{
						this.m_PanelSettings.AttachAndInsertUIDocumentToVisualTree(this);
					}
				}
				else
				{
					Assert.AreEqual<PanelSettings>(this.parentUI.m_PanelSettings, value);
					this.m_PanelSettings = this.parentUI.m_PanelSettings;
				}
				bool flag5 = this.m_ChildrenContent != null;
				if (flag5)
				{
					foreach (UIDocument uidocument in this.m_ChildrenContent.m_AttachedUIDocuments)
					{
						uidocument.panelSettings = this.m_PanelSettings;
					}
				}
				this.m_PreviousPanelSettings = this.m_PanelSettings;
			}
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06001128 RID: 4392 RVA: 0x0003E01C File Offset: 0x0003C21C
		// (set) Token: 0x06001129 RID: 4393 RVA: 0x0003E024 File Offset: 0x0003C224
		public UIDocument parentUI
		{
			get
			{
				return this.m_ParentUI;
			}
			private set
			{
				this.m_ParentUI = value;
			}
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x0600112A RID: 4394 RVA: 0x0003E030 File Offset: 0x0003C230
		// (set) Token: 0x0600112B RID: 4395 RVA: 0x0003E048 File Offset: 0x0003C248
		public VisualTreeAsset visualTreeAsset
		{
			get
			{
				return this.sourceAsset;
			}
			set
			{
				this.sourceAsset = value;
				this.RecreateUI();
			}
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x0600112C RID: 4396 RVA: 0x0003E05C File Offset: 0x0003C25C
		public VisualElement rootVisualElement
		{
			get
			{
				return this.m_RootVisualElement;
			}
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x0600112D RID: 4397 RVA: 0x0003E074 File Offset: 0x0003C274
		internal int firstChildInserIndex
		{
			get
			{
				return this.m_FirstChildInsertIndex;
			}
		}

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x0600112E RID: 4398 RVA: 0x0003E07C File Offset: 0x0003C27C
		// (set) Token: 0x0600112F RID: 4399 RVA: 0x0003E084 File Offset: 0x0003C284
		public float sortingOrder
		{
			get
			{
				return this.m_SortingOrder;
			}
			set
			{
				bool flag = this.m_SortingOrder == value;
				if (!flag)
				{
					this.m_SortingOrder = value;
					this.ApplySortingOrder();
				}
			}
		}

		// Token: 0x06001130 RID: 4400 RVA: 0x0003E0B0 File Offset: 0x0003C2B0
		internal void ApplySortingOrder()
		{
			this.AddRootVisualElementToTree();
		}

		// Token: 0x06001131 RID: 4401 RVA: 0x0003E0BA File Offset: 0x0003C2BA
		private UIDocument()
		{
			this.m_UIDocumentCreationIndex = UIDocument.s_CurrentUIDocumentCounter++;
		}

		// Token: 0x06001132 RID: 4402 RVA: 0x0003E0F7 File Offset: 0x0003C2F7
		private void Awake()
		{
			this.SetupFromHierarchy();
		}

		// Token: 0x06001133 RID: 4403 RVA: 0x0003E104 File Offset: 0x0003C304
		private void OnEnable()
		{
			bool flag = this.parentUI != null && this.m_PanelSettings == null;
			if (flag)
			{
				this.m_PanelSettings = this.parentUI.m_PanelSettings;
			}
			bool flag2 = this.m_RootVisualElement == null;
			if (flag2)
			{
				this.RecreateUI();
			}
			else
			{
				this.AddRootVisualElementToTree();
			}
		}

		// Token: 0x06001134 RID: 4404 RVA: 0x0003E168 File Offset: 0x0003C368
		private void SetupFromHierarchy()
		{
			bool flag = this.parentUI != null;
			if (flag)
			{
				this.parentUI.RemoveChild(this);
			}
			this.parentUI = this.FindUIDocumentParent();
		}

		// Token: 0x06001135 RID: 4405 RVA: 0x0003E1A4 File Offset: 0x0003C3A4
		private UIDocument FindUIDocumentParent()
		{
			Transform transform = base.transform;
			Transform parent = transform.parent;
			bool flag = parent != null;
			if (flag)
			{
				UIDocument[] componentsInParent = parent.GetComponentsInParent<UIDocument>(true);
				bool flag2 = componentsInParent != null && componentsInParent.Length != 0;
				if (flag2)
				{
					return componentsInParent[0];
				}
			}
			return null;
		}

		// Token: 0x06001136 RID: 4406 RVA: 0x0003E1F8 File Offset: 0x0003C3F8
		internal void Reset()
		{
			bool flag = this.parentUI == null;
			if (flag)
			{
				PanelSettings previousPanelSettings = this.m_PreviousPanelSettings;
				if (previousPanelSettings != null)
				{
					previousPanelSettings.DetachUIDocument(this);
				}
				this.panelSettings = null;
			}
			this.SetupFromHierarchy();
			bool flag2 = this.parentUI != null;
			if (flag2)
			{
				this.m_PanelSettings = this.parentUI.m_PanelSettings;
				this.AddRootVisualElementToTree();
			}
			else
			{
				bool flag3 = this.m_PanelSettings != null;
				if (flag3)
				{
					this.AddRootVisualElementToTree();
				}
			}
		}

		// Token: 0x06001137 RID: 4407 RVA: 0x0003E280 File Offset: 0x0003C480
		private void AddChildAndInsertContentToVisualTree(UIDocument child)
		{
			bool flag = this.m_ChildrenContent == null;
			if (flag)
			{
				this.m_ChildrenContent = new UIDocumentList();
			}
			else
			{
				this.m_ChildrenContent.RemoveFromListAndFromVisualTree(child);
			}
			this.m_ChildrenContent.AddToListAndToVisualTree(child, this.m_RootVisualElement, this.m_FirstChildInsertIndex);
		}

		// Token: 0x06001138 RID: 4408 RVA: 0x0003E2D2 File Offset: 0x0003C4D2
		private void RemoveChild(UIDocument child)
		{
			UIDocumentList childrenContent = this.m_ChildrenContent;
			if (childrenContent != null)
			{
				childrenContent.RemoveFromListAndFromVisualTree(child);
			}
		}

		// Token: 0x06001139 RID: 4409 RVA: 0x0003E2E8 File Offset: 0x0003C4E8
		private void RecreateUI()
		{
			bool flag = this.m_RootVisualElement != null;
			if (flag)
			{
				this.RemoveFromHierarchy();
				this.m_RootVisualElement = null;
			}
			bool flag2 = this.sourceAsset != null;
			if (flag2)
			{
				this.m_RootVisualElement = this.sourceAsset.Instantiate();
				bool flag3 = this.m_RootVisualElement == null;
				if (flag3)
				{
					Debug.LogError("The UXML file set for the UIDocument could not be cloned.");
				}
			}
			bool flag4 = this.m_RootVisualElement == null;
			if (flag4)
			{
				this.m_RootVisualElement = new TemplateContainer
				{
					name = base.gameObject.name + "-container"
				};
			}
			else
			{
				this.m_RootVisualElement.name = base.gameObject.name + "-container";
			}
			this.m_RootVisualElement.pickingMode = PickingMode.Ignore;
			bool isActiveAndEnabled = base.isActiveAndEnabled;
			if (isActiveAndEnabled)
			{
				this.AddRootVisualElementToTree();
			}
			this.m_FirstChildInsertIndex = this.m_RootVisualElement.childCount;
			bool flag5 = this.m_ChildrenContent != null;
			if (flag5)
			{
				bool flag6 = this.m_ChildrenContentCopy == null;
				if (flag6)
				{
					this.m_ChildrenContentCopy = new List<UIDocument>(this.m_ChildrenContent.m_AttachedUIDocuments);
				}
				else
				{
					this.m_ChildrenContentCopy.AddRange(this.m_ChildrenContent.m_AttachedUIDocuments);
				}
				foreach (UIDocument uidocument in this.m_ChildrenContentCopy)
				{
					bool isActiveAndEnabled2 = uidocument.isActiveAndEnabled;
					if (isActiveAndEnabled2)
					{
						bool flag7 = uidocument.m_RootVisualElement == null;
						if (flag7)
						{
							uidocument.RecreateUI();
						}
						else
						{
							this.AddChildAndInsertContentToVisualTree(uidocument);
						}
					}
				}
				this.m_ChildrenContentCopy.Clear();
			}
			this.SetupRootClassList();
		}

		// Token: 0x0600113A RID: 4410 RVA: 0x0003E4C4 File Offset: 0x0003C6C4
		private void SetupRootClassList()
		{
			VisualElement rootVisualElement = this.m_RootVisualElement;
			if (rootVisualElement != null)
			{
				rootVisualElement.EnableInClassList("unity-ui-document__root", this.parentUI == null);
			}
		}

		// Token: 0x0600113B RID: 4411 RVA: 0x0003E4EC File Offset: 0x0003C6EC
		private void AddRootVisualElementToTree()
		{
			bool flag = !base.enabled;
			if (!flag)
			{
				bool flag2 = this.parentUI != null;
				if (flag2)
				{
					this.parentUI.AddChildAndInsertContentToVisualTree(this);
				}
				else
				{
					bool flag3 = this.m_PanelSettings != null;
					if (flag3)
					{
						this.m_PanelSettings.AttachAndInsertUIDocumentToVisualTree(this);
					}
				}
			}
		}

		// Token: 0x0600113C RID: 4412 RVA: 0x0003E54C File Offset: 0x0003C74C
		private void RemoveFromHierarchy()
		{
			bool flag = this.parentUI != null;
			if (flag)
			{
				this.parentUI.RemoveChild(this);
			}
			else
			{
				bool flag2 = this.m_PanelSettings != null;
				if (flag2)
				{
					this.m_PanelSettings.DetachUIDocument(this);
				}
			}
		}

		// Token: 0x0600113D RID: 4413 RVA: 0x0003E59C File Offset: 0x0003C79C
		private void OnDisable()
		{
			bool flag = this.m_RootVisualElement != null;
			if (flag)
			{
				this.RemoveFromHierarchy();
				this.m_RootVisualElement = null;
			}
		}

		// Token: 0x0600113E RID: 4414 RVA: 0x0003E5C8 File Offset: 0x0003C7C8
		private void OnTransformChildrenChanged()
		{
			bool flag = this.m_ChildrenContent != null;
			if (flag)
			{
				bool flag2 = this.m_ChildrenContentCopy == null;
				if (flag2)
				{
					this.m_ChildrenContentCopy = new List<UIDocument>(this.m_ChildrenContent.m_AttachedUIDocuments);
				}
				else
				{
					this.m_ChildrenContentCopy.AddRange(this.m_ChildrenContent.m_AttachedUIDocuments);
				}
				foreach (UIDocument uidocument in this.m_ChildrenContentCopy)
				{
					uidocument.ReactToHierarchyChanged();
				}
				this.m_ChildrenContentCopy.Clear();
			}
		}

		// Token: 0x0600113F RID: 4415 RVA: 0x0003E680 File Offset: 0x0003C880
		private void OnTransformParentChanged()
		{
			this.ReactToHierarchyChanged();
		}

		// Token: 0x06001140 RID: 4416 RVA: 0x0003E68C File Offset: 0x0003C88C
		internal void ReactToHierarchyChanged()
		{
			this.SetupFromHierarchy();
			bool flag = this.parentUI != null;
			if (flag)
			{
				this.panelSettings = this.parentUI.m_PanelSettings;
			}
			VisualElement rootVisualElement = this.m_RootVisualElement;
			if (rootVisualElement != null)
			{
				rootVisualElement.RemoveFromHierarchy();
			}
			this.AddRootVisualElementToTree();
			this.SetupRootClassList();
		}

		// Token: 0x04000790 RID: 1936
		internal const string k_RootStyleClassName = "unity-ui-document__root";

		// Token: 0x04000791 RID: 1937
		internal const string k_VisualElementNameSuffix = "-container";

		// Token: 0x04000792 RID: 1938
		private const int k_DefaultSortingOrder = 0;

		// Token: 0x04000793 RID: 1939
		private static int s_CurrentUIDocumentCounter;

		// Token: 0x04000794 RID: 1940
		internal readonly int m_UIDocumentCreationIndex;

		// Token: 0x04000795 RID: 1941
		[SerializeField]
		private PanelSettings m_PanelSettings;

		// Token: 0x04000796 RID: 1942
		private PanelSettings m_PreviousPanelSettings = null;

		// Token: 0x04000797 RID: 1943
		[SerializeField]
		private UIDocument m_ParentUI;

		// Token: 0x04000798 RID: 1944
		private UIDocumentList m_ChildrenContent = null;

		// Token: 0x04000799 RID: 1945
		private List<UIDocument> m_ChildrenContentCopy = null;

		// Token: 0x0400079A RID: 1946
		[SerializeField]
		private VisualTreeAsset sourceAsset;

		// Token: 0x0400079B RID: 1947
		private VisualElement m_RootVisualElement;

		// Token: 0x0400079C RID: 1948
		private int m_FirstChildInsertIndex;

		// Token: 0x0400079D RID: 1949
		[SerializeField]
		private float m_SortingOrder = 0f;
	}
}
