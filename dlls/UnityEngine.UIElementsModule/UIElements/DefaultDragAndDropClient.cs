using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UnityEngine.UIElements
{
	// Token: 0x02000161 RID: 353
	internal class DefaultDragAndDropClient : DragAndDropData, IDragAndDrop
	{
		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000B82 RID: 2946 RVA: 0x0002DADB File Offset: 0x0002BCDB
		public override DragVisualMode visualMode
		{
			get
			{
				return this.m_VisualMode;
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000B83 RID: 2947 RVA: 0x0002DAE3 File Offset: 0x0002BCE3
		public override object source
		{
			get
			{
				return this.GetGenericData("__unity-drag-and-drop__source-view");
			}
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000B84 RID: 2948 RVA: 0x0002DAF0 File Offset: 0x0002BCF0
		public override IEnumerable<Object> unityObjectReferences
		{
			get
			{
				return this.m_UnityObjectReferences;
			}
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x0002DAF8 File Offset: 0x0002BCF8
		public override object GetGenericData(string key)
		{
			return this.m_GenericData.ContainsKey(key) ? this.m_GenericData[key] : null;
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x0002DB27 File Offset: 0x0002BD27
		public override void SetGenericData(string key, object value)
		{
			this.m_GenericData[key] = value;
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x0002DB38 File Offset: 0x0002BD38
		public void StartDrag(StartDragArgs args, Vector3 pointerPosition)
		{
			bool flag = args.unityObjectReferences != null;
			if (flag)
			{
				this.m_UnityObjectReferences = args.unityObjectReferences.ToArray<Object>();
			}
			this.m_VisualMode = args.visualMode;
			foreach (object obj in args.genericData)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				this.m_GenericData[(string)dictionaryEntry.Key] = dictionaryEntry.Value;
			}
			bool flag2 = string.IsNullOrWhiteSpace(args.title);
			if (!flag2)
			{
				VisualElement visualElement = this.source as VisualElement;
				VisualElement visualElement2 = (visualElement != null) ? visualElement.panel.visualTree : null;
				bool flag3 = visualElement2 == null;
				if (!flag3)
				{
					if (this.m_DraggedInfoLabel == null)
					{
						this.m_DraggedInfoLabel = new Label
						{
							pickingMode = PickingMode.Ignore,
							style = 
							{
								position = Position.Absolute
							}
						};
					}
					this.m_DraggedInfoLabel.text = args.title;
					this.m_DraggedInfoLabel.style.top = pointerPosition.y;
					this.m_DraggedInfoLabel.style.left = pointerPosition.x;
					visualElement2.Add(this.m_DraggedInfoLabel);
				}
			}
		}

		// Token: 0x06000B88 RID: 2952 RVA: 0x0002DCAC File Offset: 0x0002BEAC
		public void UpdateDrag(Vector3 pointerPosition)
		{
			bool flag = this.m_DraggedInfoLabel == null;
			if (!flag)
			{
				this.m_DraggedInfoLabel.style.top = pointerPosition.y;
				this.m_DraggedInfoLabel.style.left = pointerPosition.x;
			}
		}

		// Token: 0x06000B89 RID: 2953 RVA: 0x00003CD2 File Offset: 0x00001ED2
		public void AcceptDrag()
		{
		}

		// Token: 0x06000B8A RID: 2954 RVA: 0x0002DD01 File Offset: 0x0002BF01
		public void SetVisualMode(DragVisualMode mode)
		{
			this.m_VisualMode = mode;
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x0002DD0B File Offset: 0x0002BF0B
		public void DragCleanup()
		{
			this.m_UnityObjectReferences = null;
			Hashtable genericData = this.m_GenericData;
			if (genericData != null)
			{
				genericData.Clear();
			}
			this.SetVisualMode(DragVisualMode.None);
			Label draggedInfoLabel = this.m_DraggedInfoLabel;
			if (draggedInfoLabel != null)
			{
				draggedInfoLabel.RemoveFromHierarchy();
			}
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000B8C RID: 2956 RVA: 0x0002DD41 File Offset: 0x0002BF41
		public DragAndDropData data
		{
			get
			{
				return this;
			}
		}

		// Token: 0x0400056F RID: 1391
		private readonly Hashtable m_GenericData = new Hashtable();

		// Token: 0x04000570 RID: 1392
		private Label m_DraggedInfoLabel;

		// Token: 0x04000571 RID: 1393
		private DragVisualMode m_VisualMode;

		// Token: 0x04000572 RID: 1394
		private IEnumerable<Object> m_UnityObjectReferences;
	}
}
