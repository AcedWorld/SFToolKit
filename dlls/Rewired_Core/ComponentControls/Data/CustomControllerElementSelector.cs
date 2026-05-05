using System;
using System.Collections.Generic;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	// Token: 0x02000426 RID: 1062
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[Serializable]
	public sealed class CustomControllerElementSelector
	{
		// Token: 0x17000A17 RID: 2583
		// (get) Token: 0x06002ABF RID: 10943 RVA: 0x00020CF0 File Offset: 0x0001EEF0
		// (set) Token: 0x06002AC0 RID: 10944 RVA: 0x00020CF8 File Offset: 0x0001EEF8
		public CustomControllerElementSelector.ElementType elementType
		{
			get
			{
				return this._elementType;
			}
			set
			{
				if (this._elementType == value)
				{
					return;
				}
				this._elementType = value;
				this.ClearCache();
			}
		}

		// Token: 0x17000A18 RID: 2584
		// (get) Token: 0x06002AC1 RID: 10945 RVA: 0x00020D11 File Offset: 0x0001EF11
		// (set) Token: 0x06002AC2 RID: 10946 RVA: 0x00020D19 File Offset: 0x0001EF19
		public CustomControllerElementSelector.SelectorType selectorType
		{
			get
			{
				return this._selectorType;
			}
			set
			{
				if (this._selectorType == value)
				{
					return;
				}
				this._selectorType = value;
				this.ClearCache();
			}
		}

		// Token: 0x17000A19 RID: 2585
		// (get) Token: 0x06002AC3 RID: 10947 RVA: 0x00020D32 File Offset: 0x0001EF32
		// (set) Token: 0x06002AC4 RID: 10948 RVA: 0x00020D3A File Offset: 0x0001EF3A
		public string elementName
		{
			get
			{
				return this._elementName;
			}
			set
			{
				if (this._elementName == value)
				{
					return;
				}
				this._elementName = value;
				this.ClearCache();
			}
		}

		// Token: 0x17000A1A RID: 2586
		// (get) Token: 0x06002AC5 RID: 10949 RVA: 0x00020D58 File Offset: 0x0001EF58
		// (set) Token: 0x06002AC6 RID: 10950 RVA: 0x00020D60 File Offset: 0x0001EF60
		public int elementIndex
		{
			get
			{
				return this._elementIndex;
			}
			set
			{
				if (this._elementIndex == value)
				{
					return;
				}
				this._elementIndex = value;
				this.ClearCache();
			}
		}

		// Token: 0x17000A1B RID: 2587
		// (get) Token: 0x06002AC7 RID: 10951 RVA: 0x00020D79 File Offset: 0x0001EF79
		// (set) Token: 0x06002AC8 RID: 10952 RVA: 0x00020D81 File Offset: 0x0001EF81
		public int elementId
		{
			get
			{
				return this._elementId;
			}
			set
			{
				if (this._elementId == value)
				{
					return;
				}
				this._elementId = value;
				this.ClearCache();
			}
		}

		// Token: 0x17000A1C RID: 2588
		// (get) Token: 0x06002AC9 RID: 10953 RVA: 0x0009B8E0 File Offset: 0x00099AE0
		public bool isAssigned
		{
			get
			{
				switch (this.selectorType)
				{
				case CustomControllerElementSelector.SelectorType.Name:
					return !string.IsNullOrEmpty(this._elementName);
				case CustomControllerElementSelector.SelectorType.Index:
					return this._elementIndex >= 0;
				case CustomControllerElementSelector.SelectorType.Id:
					return this._elementId >= 0;
				default:
					throw new NotImplementedException();
				}
			}
		}

		// Token: 0x06002ACA RID: 10954 RVA: 0x0009B938 File Offset: 0x00099B38
		public int GetElementIndex(CustomController customController)
		{
			if (customController == null)
			{
				return -1;
			}
			if (this.cLOCdHksooqTrUrLJsiKxtPZKpEw >= 0 && this.cLOCdHksooqTrUrLJsiKxtPZKpEw != customController.id)
			{
				this.ClearCache();
			}
			if (this.UrkmyKvwIVrlXewwFknwTXiRLlKN >= 0)
			{
				return this.UrkmyKvwIVrlXewwFknwTXiRLlKN;
			}
			this.cLOCdHksooqTrUrLJsiKxtPZKpEw = customController.id;
			switch (this._selectorType)
			{
			case CustomControllerElementSelector.SelectorType.Name:
			{
				if (this._elementName == null)
				{
					return -1;
				}
				IList<ControllerElementIdentifier> list = this.IwUglkSPDjVSLMObGKcOmdMIFpsJA(customController, this._elementType);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].name.Equals(this._elementName))
					{
						this.UrkmyKvwIVrlXewwFknwTXiRLlKN = i;
						break;
					}
				}
				break;
			}
			case CustomControllerElementSelector.SelectorType.Index:
			{
				if (this._elementIndex < 0)
				{
					return -1;
				}
				IList<ControllerElementIdentifier> list = this.IwUglkSPDjVSLMObGKcOmdMIFpsJA(customController, this._elementType);
				if (this._elementIndex >= list.Count)
				{
					return -1;
				}
				this.UrkmyKvwIVrlXewwFknwTXiRLlKN = this._elementIndex;
				break;
			}
			case CustomControllerElementSelector.SelectorType.Id:
			{
				IList<ControllerElementIdentifier> list = this.IwUglkSPDjVSLMObGKcOmdMIFpsJA(customController, this._elementType);
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].id == this._elementId)
					{
						this.UrkmyKvwIVrlXewwFknwTXiRLlKN = j;
						break;
					}
				}
				break;
			}
			default:
				throw new NotImplementedException();
			}
			return this.UrkmyKvwIVrlXewwFknwTXiRLlKN;
		}

		// Token: 0x06002ACB RID: 10955 RVA: 0x0009BA78 File Offset: 0x00099C78
		public string GetSelectorFormattedString()
		{
			switch (this.selectorType)
			{
			case CustomControllerElementSelector.SelectorType.Name:
				return "Name: " + this._elementName;
			case CustomControllerElementSelector.SelectorType.Index:
				return "Index: " + this._elementIndex.ToString();
			case CustomControllerElementSelector.SelectorType.Id:
				return "Id: " + this._elementId.ToString();
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x06002ACC RID: 10956 RVA: 0x00020D9A File Offset: 0x0001EF9A
		private IList<ControllerElementIdentifier> IwUglkSPDjVSLMObGKcOmdMIFpsJA(CustomController A_1, CustomControllerElementSelector.ElementType A_2)
		{
			if (A_2 == CustomControllerElementSelector.ElementType.Axis)
			{
				return A_1.AxisElementIdentifiers;
			}
			if (A_2 != CustomControllerElementSelector.ElementType.Button)
			{
				throw new NotImplementedException();
			}
			return A_1.ButtonElementIdentifiers;
		}

		// Token: 0x06002ACD RID: 10957 RVA: 0x00020DB8 File Offset: 0x0001EFB8
		public void ClearCache()
		{
			this.cLOCdHksooqTrUrLJsiKxtPZKpEw = -1;
			this.UrkmyKvwIVrlXewwFknwTXiRLlKN = -1;
		}

		// Token: 0x04001882 RID: 6274
		[Tooltip("The target Custom Controller element type.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementSelector.ElementType _elementType;

		// Token: 0x04001883 RID: 6275
		[Tooltip("The method to use to look up the target Custom Controller element.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementSelector.SelectorType _selectorType = CustomControllerElementSelector.SelectorType.Id;

		// Token: 0x04001884 RID: 6276
		[Tooltip("The target Custom Controller element name.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _elementName;

		// Token: 0x04001885 RID: 6277
		[Tooltip("The target Custom Controller element index.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(-1, 2147483647)]
		private int _elementIndex;

		// Token: 0x04001886 RID: 6278
		[Tooltip("The target Custom Controller element id.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(-1, 2147483647)]
		private int _elementId = -1;

		// Token: 0x04001887 RID: 6279
		[HideInInspector]
		private int cLOCdHksooqTrUrLJsiKxtPZKpEw = -1;

		// Token: 0x04001888 RID: 6280
		[HideInInspector]
		private int UrkmyKvwIVrlXewwFknwTXiRLlKN = -1;

		// Token: 0x02000427 RID: 1063
		[CustomObfuscation(rename = false)]
		public enum ElementType
		{
			// Token: 0x0400188A RID: 6282
			Axis,
			// Token: 0x0400188B RID: 6283
			Button
		}

		// Token: 0x02000428 RID: 1064
		[CustomObfuscation(rename = false)]
		public enum SelectorType
		{
			// Token: 0x0400188D RID: 6285
			Name,
			// Token: 0x0400188E RID: 6286
			Index,
			// Token: 0x0400188F RID: 6287
			Id
		}
	}
}
