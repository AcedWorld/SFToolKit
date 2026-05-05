using System;
using System.Collections.Generic;
using System.ComponentModel;
using Rewired.Data.Mapping;
using Rewired.Internal.Localization;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Data
{
	// Token: 0x0200024F RID: 591
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[Serializable]
	public sealed class CustomController_Editor
	{
		// Token: 0x17000661 RID: 1633
		// (get) Token: 0x06001AF7 RID: 6903 RVA: 0x00015D44 File Offset: 0x00013F44
		// (set) Token: 0x06001AF8 RID: 6904 RVA: 0x00015D4C File Offset: 0x00013F4C
		public string name
		{
			get
			{
				return this._name;
			}
			internal set
			{
				this._name = value;
			}
		}

		// Token: 0x17000662 RID: 1634
		// (get) Token: 0x06001AF9 RID: 6905 RVA: 0x00015D55 File Offset: 0x00013F55
		// (set) Token: 0x06001AFA RID: 6906 RVA: 0x00015D5D File Offset: 0x00013F5D
		public string descriptiveName
		{
			get
			{
				return this._descriptiveName;
			}
			internal set
			{
				this._descriptiveName = value;
			}
		}

		// Token: 0x17000663 RID: 1635
		// (get) Token: 0x06001AFB RID: 6907 RVA: 0x00015D66 File Offset: 0x00013F66
		// (set) Token: 0x06001AFC RID: 6908 RVA: 0x00015D6E File Offset: 0x00013F6E
		public int id
		{
			get
			{
				return this._id;
			}
			internal set
			{
				this._id = value;
			}
		}

		// Token: 0x17000664 RID: 1636
		// (get) Token: 0x06001AFD RID: 6909 RVA: 0x00015D77 File Offset: 0x00013F77
		// (set) Token: 0x06001AFE RID: 6910 RVA: 0x00015D84 File Offset: 0x00013F84
		public Guid typeGuid
		{
			get
			{
				return StringTools.ToGuid(this._typeGuidString);
			}
			internal set
			{
				this._typeGuidString = value.ToString();
			}
		}

		// Token: 0x17000665 RID: 1637
		// (get) Token: 0x06001AFF RID: 6911 RVA: 0x00015D99 File Offset: 0x00013F99
		// (set) Token: 0x06001B00 RID: 6912 RVA: 0x00015DA1 File Offset: 0x00013FA1
		internal string typeGuidString
		{
			get
			{
				return this._typeGuidString;
			}
			set
			{
				this._typeGuidString = value;
			}
		}

		// Token: 0x17000666 RID: 1638
		// (get) Token: 0x06001B01 RID: 6913 RVA: 0x00015DAA File Offset: 0x00013FAA
		// (set) Token: 0x06001B02 RID: 6914 RVA: 0x00015DB2 File Offset: 0x00013FB2
		public string key
		{
			get
			{
				return this._key;
			}
			set
			{
				this._key = value;
			}
		}

		// Token: 0x17000667 RID: 1639
		// (get) Token: 0x06001B03 RID: 6915 RVA: 0x00015DBB File Offset: 0x00013FBB
		// (set) Token: 0x06001B04 RID: 6916 RVA: 0x00015DC3 File Offset: 0x00013FC3
		public List<ControllerElementIdentifier> elementIdentifiers
		{
			get
			{
				return this._elementIdentifiers;
			}
			internal set
			{
				this._elementIdentifiers = value;
			}
		}

		// Token: 0x17000668 RID: 1640
		// (get) Token: 0x06001B05 RID: 6917 RVA: 0x00015DCC File Offset: 0x00013FCC
		public List<CustomController_Editor.Axis> axes
		{
			get
			{
				return this._axes;
			}
		}

		// Token: 0x17000669 RID: 1641
		// (get) Token: 0x06001B06 RID: 6918 RVA: 0x00015DD4 File Offset: 0x00013FD4
		public List<CustomController_Editor.Button> buttons
		{
			get
			{
				return this._buttons;
			}
		}

		// Token: 0x1700066A RID: 1642
		// (get) Token: 0x06001B07 RID: 6919 RVA: 0x00015DDC File Offset: 0x00013FDC
		public int buttonCount
		{
			get
			{
				if (this.buttons == null)
				{
					return 0;
				}
				return this.buttons.Count;
			}
		}

		// Token: 0x1700066B RID: 1643
		// (get) Token: 0x06001B08 RID: 6920 RVA: 0x00015DF3 File Offset: 0x00013FF3
		public int axisCount
		{
			get
			{
				if (this.axes == null)
				{
					return 0;
				}
				return this.axes.Count;
			}
		}

		// Token: 0x1700066C RID: 1644
		// (get) Token: 0x06001B09 RID: 6921 RVA: 0x00015E0A File Offset: 0x0001400A
		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				if (this._elementIdentifiers == null)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < this._elementIdentifiers.Count; i = num + 1)
				{
					yield return this._elementIdentifiers[i];
					num = i;
				}
				yield break;
			}
		}

		// Token: 0x06001B0A RID: 6922 RVA: 0x00015E1A File Offset: 0x0001401A
		public CustomController_Editor()
		{
			this._axes = new List<CustomController_Editor.Axis>();
			this._buttons = new List<CustomController_Editor.Button>();
			this._elementIdentifiers = new List<ControllerElementIdentifier>();
		}

		// Token: 0x06001B0B RID: 6923 RVA: 0x00074738 File Offset: 0x00072938
		public CustomController_Editor(CustomController_Editor A_1)
		{
			this._name = A_1._name;
			this._descriptiveName = A_1._descriptiveName;
			this._id = A_1._id;
			this._typeGuidString = A_1._typeGuidString;
			this._key = A_1._key;
			if (A_1._elementIdentifiers != null)
			{
				this._elementIdentifiers = new List<ControllerElementIdentifier>(A_1._elementIdentifiers.Count);
				for (int i = 0; i < A_1._elementIdentifiers.Count; i++)
				{
					this._elementIdentifiers.Add(A_1._elementIdentifiers[i].Clone());
				}
			}
			if (A_1._axes != null)
			{
				this._axes = new List<CustomController_Editor.Axis>(A_1._axes.Count);
				for (int j = 0; j < A_1._axes.Count; j++)
				{
					this._axes.Add((CustomController_Editor.Axis)A_1._axes[j].Clone());
				}
			}
			if (A_1._buttons != null)
			{
				this._buttons = new List<CustomController_Editor.Button>(A_1._buttons.Count);
				for (int k = 0; k < A_1._buttons.Count; k++)
				{
					this._buttons.Add((CustomController_Editor.Button)A_1._buttons[k].Clone());
				}
			}
			this._elementIdentifierIdCounter = A_1._elementIdentifierIdCounter;
		}

		// Token: 0x06001B0C RID: 6924 RVA: 0x00015E43 File Offset: 0x00014043
		public CustomController_Editor Clone()
		{
			return new CustomController_Editor(this);
		}

		// Token: 0x06001B0D RID: 6925 RVA: 0x00074890 File Offset: 0x00072A90
		public string[] GetElementIdentifierNames()
		{
			int num = (this._elementIdentifiers != null) ? this._elementIdentifiers.Count : 0;
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = this._elementIdentifiers[i].nonLocalizedName;
			}
			return array;
		}

		// Token: 0x06001B0E RID: 6926 RVA: 0x000748DC File Offset: 0x00072ADC
		public int[] GetElementIdentifierIds()
		{
			int num = (this._elementIdentifiers != null) ? this._elementIdentifiers.Count : 0;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = this._elementIdentifiers[i].id;
			}
			return array;
		}

		// Token: 0x06001B0F RID: 6927 RVA: 0x00074928 File Offset: 0x00072B28
		public string[] GetElementIdentifierNamesTypeSorted()
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			int axisCount = this.axisCount;
			for (int i = 0; i < axisCount; i++)
			{
				int num = this.IndexOfElementIdentifier(this.axes[i].elementIdentifierId);
				if (num >= 0)
				{
					list2.Add(this._elementIdentifiers[num].nonLocalizedName);
				}
			}
			int buttonCount = this.buttonCount;
			for (int j = 0; j < buttonCount; j++)
			{
				int num2 = this.IndexOfElementIdentifier(this.buttons[j].elementIdentifierId);
				if (num2 >= 0)
				{
					list.Add(this._elementIdentifiers[num2].nonLocalizedName);
				}
			}
			return ListTools.Combine<string>(list2, list).ToArray();
		}

		// Token: 0x06001B10 RID: 6928 RVA: 0x000749EC File Offset: 0x00072BEC
		public int[] GetElementIdentifierIdsTypeSorted()
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			int axisCount = this.axisCount;
			for (int i = 0; i < axisCount; i++)
			{
				list2.Add(this.axes[i].elementIdentifierId);
			}
			int buttonCount = this.buttonCount;
			for (int j = 0; j < buttonCount; j++)
			{
				list.Add(this.buttons[j].elementIdentifierId);
			}
			return ListTools.Combine<int>(list2, list).ToArray();
		}

		// Token: 0x06001B11 RID: 6929 RVA: 0x00074A70 File Offset: 0x00072C70
		public ControllerElementIdentifier[] GetElementIdentifiersTypeSorted()
		{
			List<ControllerElementIdentifier> list = new List<ControllerElementIdentifier>();
			List<ControllerElementIdentifier> list2 = new List<ControllerElementIdentifier>();
			int axisCount = this.axisCount;
			for (int i = 0; i < axisCount; i++)
			{
				int num = this.IndexOfElementIdentifier(this.axes[i].elementIdentifierId);
				if (num >= 0)
				{
					list2.Add(this._elementIdentifiers[num]);
				}
			}
			int buttonCount = this.buttonCount;
			for (int j = 0; j < buttonCount; j++)
			{
				int num2 = this.IndexOfElementIdentifier(this.buttons[j].elementIdentifierId);
				if (num2 >= 0)
				{
					list.Add(this._elementIdentifiers[num2]);
				}
			}
			return ListTools.Combine<ControllerElementIdentifier>(list2, list).ToArray();
		}

		// Token: 0x06001B12 RID: 6930 RVA: 0x00074B28 File Offset: 0x00072D28
		public bool ContainsElementIdentifier(int id)
		{
			int num = (this._elementIdentifiers != null) ? this._elementIdentifiers.Count : 0;
			for (int i = 0; i < num; i++)
			{
				if (this._elementIdentifiers[i].id == id)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001B13 RID: 6931 RVA: 0x00074B70 File Offset: 0x00072D70
		public int IndexOfElementIdentifier(int id)
		{
			int num = (this._elementIdentifiers != null) ? this._elementIdentifiers.Count : 0;
			for (int i = 0; i < num; i++)
			{
				if (this._elementIdentifiers[i].id == id)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001B14 RID: 6932 RVA: 0x00074BB8 File Offset: 0x00072DB8
		public ControllerElementIdentifier GetElementIdentifier(int id)
		{
			int num = this.IndexOfElementIdentifier(id);
			if (num < 0)
			{
				return null;
			}
			return this._elementIdentifiers[num];
		}

		// Token: 0x06001B15 RID: 6933 RVA: 0x00074BE0 File Offset: 0x00072DE0
		internal ControllerElementType GetEffectiveElementIdentifierType(int elementIdentifierId)
		{
			ControllerElementIdentifier elementIdentifier = this.GetElementIdentifier(elementIdentifierId);
			if (elementIdentifier == null)
			{
				return ControllerElementType.Axis;
			}
			for (int i = 0; i < this.axisCount; i++)
			{
				if (this.axes[i].elementIdentifierId == elementIdentifier.id)
				{
					return ControllerElementType.Axis;
				}
			}
			for (int j = 0; j < this.buttonCount; j++)
			{
				if (this.buttons[j].elementIdentifierId == elementIdentifier.id)
				{
					return ControllerElementType.Button;
				}
			}
			return elementIdentifier.elementType;
		}

		// Token: 0x06001B16 RID: 6934 RVA: 0x00074C58 File Offset: 0x00072E58
		internal bool GetEffectiveAxisRange(int elementIdentifierId, out AxisRange axisRange)
		{
			ControllerElementIdentifier elementIdentifier = this.GetElementIdentifier(elementIdentifierId);
			if (elementIdentifier == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			for (int i = 0; i < this.axisCount; i++)
			{
				if (this.axes[i].elementIdentifierId == elementIdentifier.id)
				{
					axisRange = this.axes[i].range;
					if (this.axes[i].invert)
					{
						axisRange = InputTools.InvertAxisRange(axisRange);
					}
					return true;
				}
			}
			axisRange = AxisRange.Full;
			return false;
		}

		// Token: 0x06001B17 RID: 6935 RVA: 0x00074CD4 File Offset: 0x00072ED4
		public string[] GetButtonNames()
		{
			int num = (this._buttons != null) ? this._buttons.Count : 0;
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = this._buttons[i].name;
			}
			return array;
		}

		// Token: 0x06001B18 RID: 6936 RVA: 0x00074D20 File Offset: 0x00072F20
		public int[] GetButtonElementIdentifierIds()
		{
			int num = (this._buttons != null) ? this._buttons.Count : 0;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = this._buttons[i].elementIdentifierId;
			}
			return array;
		}

		// Token: 0x06001B19 RID: 6937 RVA: 0x00074D6C File Offset: 0x00072F6C
		public string[] GetAxisNames()
		{
			int num = (this._axes != null) ? this._axes.Count : 0;
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = this._axes[i].name;
			}
			return array;
		}

		// Token: 0x06001B1A RID: 6938 RVA: 0x00074DB8 File Offset: 0x00072FB8
		public int[] GetAxisElementIdentifierIds()
		{
			int num = (this._axes != null) ? this._axes.Count : 0;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = this._axes[i].elementIdentifierId;
			}
			return array;
		}

		// Token: 0x06001B1B RID: 6939 RVA: 0x00074E04 File Offset: 0x00073004
		public string[] GetElementNames<T>() where T : CustomController_Editor.Element
		{
			if (typeof(T) == typeof(CustomController_Editor.Axis))
			{
				return this.GetAxisNames();
			}
			if (typeof(T) == typeof(CustomController_Editor.Button))
			{
				return this.GetButtonNames();
			}
			throw new NotImplementedException();
		}

		// Token: 0x06001B1C RID: 6940 RVA: 0x00015E4B File Offset: 0x0001404B
		public string[] GetElementNames(ControllerElementType type)
		{
			if (type == ControllerElementType.Axis)
			{
				return this.GetAxisNames();
			}
			if (type == ControllerElementType.Button)
			{
				return this.GetButtonNames();
			}
			throw new NotImplementedException();
		}

		// Token: 0x06001B1D RID: 6941 RVA: 0x00015E67 File Offset: 0x00014067
		public int[] GetElementElementIdentifierIds(ControllerElementType type)
		{
			if (type == ControllerElementType.Axis)
			{
				return this.GetAxisElementIdentifierIds();
			}
			if (type == ControllerElementType.Button)
			{
				return this.GetButtonElementIdentifierIds();
			}
			throw new NotImplementedException();
		}

		// Token: 0x06001B1E RID: 6942 RVA: 0x00074E50 File Offset: 0x00073050
		public T GetElement<T>(int index) where T : CustomController_Editor.Element
		{
			if (index < 0)
			{
				return default(T);
			}
			if (typeof(T) == typeof(CustomController_Editor.Axis))
			{
				if (index >= this.axisCount)
				{
					return default(T);
				}
				return this._axes[index] as T;
			}
			else
			{
				if (typeof(T) != typeof(CustomController_Editor.Button))
				{
					throw new NotImplementedException();
				}
				if (index >= this.buttonCount)
				{
					return default(T);
				}
				return this._buttons[index] as T;
			}
		}

		// Token: 0x06001B1F RID: 6943 RVA: 0x00015E83 File Offset: 0x00014083
		public void AddElement(ControllerElementType type)
		{
			if (type == ControllerElementType.Axis)
			{
				this.AddAxis();
				return;
			}
			this.AddButton();
		}

		// Token: 0x06001B20 RID: 6944 RVA: 0x00015E95 File Offset: 0x00014095
		public void AddAxis()
		{
			this.axes.Add((CustomController_Editor.Axis)this.mGMdBsyxmWfMmrtVvjkQdtxDyPgb(ControllerElementType.Axis));
		}

		// Token: 0x06001B21 RID: 6945 RVA: 0x00015EAE File Offset: 0x000140AE
		public void AddButton()
		{
			this.buttons.Add((CustomController_Editor.Button)this.mGMdBsyxmWfMmrtVvjkQdtxDyPgb(ControllerElementType.Button));
		}

		// Token: 0x06001B22 RID: 6946 RVA: 0x00015EC7 File Offset: 0x000140C7
		public void InsertElement(ControllerElementType type, int index)
		{
			if (type == ControllerElementType.Axis)
			{
				this.InsertAxis(index);
				return;
			}
			this.InsertButton(index);
		}

		// Token: 0x06001B23 RID: 6947 RVA: 0x00015EDB File Offset: 0x000140DB
		public void InsertAxis(int index)
		{
			if (index < 0 || index >= this.axes.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.axes.Insert(index, (CustomController_Editor.Axis)this.mGMdBsyxmWfMmrtVvjkQdtxDyPgb(ControllerElementType.Axis));
		}

		// Token: 0x06001B24 RID: 6948 RVA: 0x00015F12 File Offset: 0x00014112
		public void InsertButton(int index)
		{
			if (index < 0 || index >= this.buttons.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.buttons.Insert(index, (CustomController_Editor.Button)this.mGMdBsyxmWfMmrtVvjkQdtxDyPgb(ControllerElementType.Button));
		}

		// Token: 0x06001B25 RID: 6949 RVA: 0x00015F49 File Offset: 0x00014149
		public void DeleteElement(ControllerElementType type, int index)
		{
			if (type == ControllerElementType.Axis)
			{
				this.DeleteElement<CustomController_Editor.Axis>(index);
				return;
			}
			if (type == ControllerElementType.Button)
			{
				this.DeleteElement<CustomController_Editor.Button>(index);
				return;
			}
			throw new NotImplementedException();
		}

		// Token: 0x06001B26 RID: 6950 RVA: 0x00074EF0 File Offset: 0x000730F0
		public void DeleteElement<T>(int index) where T : CustomController_Editor.Element
		{
			if (index < 0)
			{
				return;
			}
			T t;
			if (typeof(T) == typeof(CustomController_Editor.Axis))
			{
				if (index >= this.axisCount)
				{
					return;
				}
				t = (this._axes[index] as T);
				this._axes.RemoveAt(index);
			}
			else
			{
				if (typeof(T) != typeof(CustomController_Editor.Button))
				{
					throw new NotImplementedException();
				}
				if (index >= this.buttonCount)
				{
					return;
				}
				t = (this._buttons[index] as T);
				this._buttons.RemoveAt(index);
			}
			if (this._elementIdentifiers != null)
			{
				for (int i = this._elementIdentifiers.Count - 1; i >= 0; i--)
				{
					if (this._elementIdentifiers[i].id == t.elementIdentifierId)
					{
						this._elementIdentifiers.RemoveAt(i);
					}
				}
			}
		}

		// Token: 0x06001B27 RID: 6951 RVA: 0x00074FDC File Offset: 0x000731DC
		public bool ReorderElement(ControllerElementType type, int index, bool offsetDown, bool offsetNow)
		{
			if (type == ControllerElementType.Axis)
			{
				List<CustomController_Editor.Axis> axes = this._axes;
				return axes != null && index >= 0 && index < axes.Count && ListTools.OffsetAtIndex<CustomController_Editor.Axis>(axes, index, offsetDown, offsetNow);
			}
			if (type == ControllerElementType.Button)
			{
				List<CustomController_Editor.Button> buttons = this._buttons;
				return buttons != null && index >= 0 && index < buttons.Count && ListTools.OffsetAtIndex<CustomController_Editor.Button>(buttons, index, offsetDown, offsetNow);
			}
			throw new NotImplementedException();
		}

		// Token: 0x06001B28 RID: 6952 RVA: 0x00015F67 File Offset: 0x00014167
		public void DuplicateElement(ControllerElementType type, int index)
		{
			if (type == ControllerElementType.Axis)
			{
				this.plfvKApLcZknlNibSmAiSZshfDjG<CustomController_Editor.Axis>(index, this.axes);
				return;
			}
			if (type == ControllerElementType.Button)
			{
				this.plfvKApLcZknlNibSmAiSZshfDjG<CustomController_Editor.Button>(index, this.buttons);
				return;
			}
			throw new NotImplementedException();
		}

		// Token: 0x06001B29 RID: 6953 RVA: 0x00075040 File Offset: 0x00073240
		private void plfvKApLcZknlNibSmAiSZshfDjG<\u0001>(int A_1, List<\u0001> A_2) where \u0001 : CustomController_Editor.Element
		{
			if (A_2 == null || A_1 < 0 || A_1 >= A_2.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			\u0001 u = A_2[A_1];
			string text = StringTools.IterateName(u.name, -1, this.GetElementNames<\u0001>());
			ControllerElementIdentifier controllerElementIdentifier = this.drbQoiAWFCIIjwqDRPGpEevXYCqj(u.elementIdentifierId, text);
			if (controllerElementIdentifier == null)
			{
				Logger.LogError("Element identifier is missing! Element cannot be duplicated!");
				return;
			}
			\u0001 u2 = (\u0001)((object)u.Clone());
			u2.elementIdentifierId = controllerElementIdentifier.id;
			u2.name = text;
			if (A_1 == A_2.Count - 1)
			{
				A_2.Add(u2);
				return;
			}
			A_2.Insert(A_1 + 1, u2);
		}

		// Token: 0x06001B2A RID: 6954 RVA: 0x000750F4 File Offset: 0x000732F4
		private ControllerElementIdentifier drbQoiAWFCIIjwqDRPGpEevXYCqj(int A_1, string A_2)
		{
			if (!this.ContainsElementIdentifier(A_1))
			{
				return null;
			}
			int num = this.IndexOfElementIdentifier(A_1);
			int elementIdentifierIdCounter = this._elementIdentifierIdCounter;
			this._elementIdentifierIdCounter++;
			ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier(new ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps
			{
				id = elementIdentifierIdCounter,
				name = A_2,
				positiveName = this._elementIdentifiers[num].positiveName,
				negativeName = this._elementIdentifiers[num].negativeName,
				key = this._elementIdentifiers[num].key,
				positiveKey = this._elementIdentifiers[num].positiveKey,
				negativeKey = this._elementIdentifiers[num].negativeKey,
				elementType = this._elementIdentifiers[num].elementType,
				compoundElementType = this._elementIdentifiers[num].compoundElementType
			});
			if (num == this._elementIdentifiers.Count - 1)
			{
				this._elementIdentifiers.Add(controllerElementIdentifier);
			}
			else
			{
				this._elementIdentifiers.Insert(num + 1, controllerElementIdentifier);
			}
			return controllerElementIdentifier;
		}

		// Token: 0x06001B2B RID: 6955 RVA: 0x00075214 File Offset: 0x00073414
		private CustomController_Editor.Element mGMdBsyxmWfMmrtVvjkQdtxDyPgb(ControllerElementType A_1)
		{
			if (A_1 == ControllerElementType.Axis)
			{
				string text = StringTools.IterateName("Axis ", -1, this.GetAxisNames());
				ControllerElementIdentifier controllerElementIdentifier = this.yrhBiSNkXmFezcxdWfBOjuhnwmnNA(A_1, text, string.Empty, string.Empty, this.key, string.Empty, string.Empty);
				return new CustomController_Editor.Axis(text)
				{
					elementIdentifierId = controllerElementIdentifier.id
				};
			}
			if (A_1 == ControllerElementType.Button)
			{
				string text2 = StringTools.IterateName("Button ", -1, this.GetButtonNames());
				ControllerElementIdentifier controllerElementIdentifier2 = this.yrhBiSNkXmFezcxdWfBOjuhnwmnNA(A_1, text2, string.Empty, string.Empty, this.key, string.Empty, string.Empty);
				return new CustomController_Editor.Button(text2)
				{
					elementIdentifierId = controllerElementIdentifier2.id
				};
			}
			throw new NotImplementedException();
		}

		// Token: 0x06001B2C RID: 6956 RVA: 0x000752C0 File Offset: 0x000734C0
		private ControllerElementIdentifier yrhBiSNkXmFezcxdWfBOjuhnwmnNA(ControllerElementType A_1, string A_2, string A_3, string A_4, string A_5, string A_6, string A_7)
		{
			int elementIdentifierIdCounter = this._elementIdentifierIdCounter;
			this._elementIdentifierIdCounter++;
			ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier(new ControllerElementIdentifier.vNIqbrYzBBGsknBKgoQEcoARaWps
			{
				id = elementIdentifierIdCounter,
				name = A_2,
				positiveName = A_3,
				negativeName = A_4,
				key = A_5,
				positiveKey = A_6,
				negativeKey = A_7,
				elementType = A_1
			});
			this._elementIdentifiers.Add(controllerElementIdentifier);
			return controllerElementIdentifier;
		}

		// Token: 0x06001B2D RID: 6957 RVA: 0x00075338 File Offset: 0x00073538
		internal HardwareControllerMap_Game CreateGameHardwareMap()
		{
			int axisCount = this.axisCount;
			int buttonCount = this.buttonCount;
			int[] array = new int[buttonCount];
			int[] array2 = new int[axisCount];
			AxisCalibrationData[] array3 = new AxisCalibrationData[axisCount];
			AxisRange[] array4 = new AxisRange[axisCount];
			HardwareAxisInfo[] array5 = new HardwareAxisInfo[axisCount];
			HardwareButtonInfo[] array6 = new HardwareButtonInfo[buttonCount];
			for (int i = 0; i < buttonCount; i++)
			{
				array[i] = this._buttons[i].elementIdentifierId;
				array6[i] = new HardwareButtonInfo();
			}
			for (int j = 0; j < axisCount; j++)
			{
				array2[j] = this._axes[j].elementIdentifierId;
				array3[j] = new AxisCalibrationData(true, this._axes[j].deadZone, this._axes[j].zero, this._axes[j].min, this._axes[j].max, this._axes[j].invert, !this._axes[j].doNotCalibrateRange, this._axes[j].sensitivityType, this._axes[j].sensitivity, UnityTools.Copy(this._axes[j].sensitivityCurve));
				array4[j] = this._axes[j].range;
				array5[j] = (MiscTools.DeepClone<HardwareAxisInfo>(this._axes[j].axisInfo) ?? HardwareAxisInfo.Default);
			}
			ControllerElementIdentifier[] elementIdentifiersTypeSorted = this.GetElementIdentifiersTypeSorted();
			ControllerElementIdentifier[] array7 = new ControllerElementIdentifier[elementIdentifiersTypeSorted.Length];
			for (int k = 0; k < array7.Length; k++)
			{
				if (elementIdentifiersTypeSorted[k] != null)
				{
					array7[k] = new ControllerElementIdentifier(elementIdentifiersTypeSorted[k]);
				}
			}
			List<string> list = new List<string>
			{
				this._key
			};
			DeviceLocalizationInfo deviceLocalizationInfo = new DeviceLocalizationInfo(ControllerType.Custom, false, this.typeGuid, list, null);
			return new HardwareControllerMap_Game(this._name, deviceLocalizationInfo, this._id, array7, array, array2, array3, array4, array5, array6, null);
		}

		// Token: 0x04000F76 RID: 3958
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		// Token: 0x04000F77 RID: 3959
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _descriptiveName;

		// Token: 0x04000F78 RID: 3960
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		// Token: 0x04000F79 RID: 3961
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _typeGuidString;

		// Token: 0x04000F7A RID: 3962
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _key;

		// Token: 0x04000F7B RID: 3963
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerElementIdentifier> _elementIdentifiers;

		// Token: 0x04000F7C RID: 3964
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<CustomController_Editor.Axis> _axes;

		// Token: 0x04000F7D RID: 3965
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<CustomController_Editor.Button> _buttons;

		// Token: 0x04000F7E RID: 3966
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _elementIdentifierIdCounter;

		// Token: 0x02000250 RID: 592
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Serializable]
		public abstract class Element
		{
			// Token: 0x06001B2E RID: 6958 RVA: 0x000033F4 File Offset: 0x000015F4
			public Element()
			{
			}

			// Token: 0x06001B2F RID: 6959 RVA: 0x00015F91 File Offset: 0x00014191
			public Element(string A_1, int A_2)
			{
				this.name = A_1;
				this.elementIdentifierId = A_2;
			}

			// Token: 0x06001B30 RID: 6960
			public abstract CustomController_Editor.Element Clone();

			// Token: 0x04000F7F RID: 3967
			public int elementIdentifierId;

			// Token: 0x04000F80 RID: 3968
			public string name;
		}

		// Token: 0x02000251 RID: 593
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Serializable]
		public sealed class Button : CustomController_Editor.Element
		{
			// Token: 0x06001B31 RID: 6961 RVA: 0x00015FA7 File Offset: 0x000141A7
			public Button()
			{
			}

			// Token: 0x06001B32 RID: 6962 RVA: 0x00015FAF File Offset: 0x000141AF
			public Button(string A_1) : base(A_1, -1)
			{
			}

			// Token: 0x06001B33 RID: 6963 RVA: 0x00015FB9 File Offset: 0x000141B9
			public Button(string A_1, int A_2) : base(A_1, A_2)
			{
			}

			// Token: 0x06001B34 RID: 6964 RVA: 0x00015FC3 File Offset: 0x000141C3
			public Button(CustomController_Editor.Button A_1) : base(A_1.name, A_1.elementIdentifierId)
			{
			}

			// Token: 0x06001B35 RID: 6965 RVA: 0x00015FD7 File Offset: 0x000141D7
			public override CustomController_Editor.Element Clone()
			{
				return new CustomController_Editor.Button(this);
			}
		}

		// Token: 0x02000252 RID: 594
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Serializable]
		public sealed class Axis : CustomController_Editor.Element
		{
			// Token: 0x06001B36 RID: 6966 RVA: 0x00015FDF File Offset: 0x000141DF
			public Axis()
			{
			}

			// Token: 0x06001B37 RID: 6967 RVA: 0x00075554 File Offset: 0x00073754
			public Axis(string A_1) : base(A_1, -1)
			{
				this.range = AxisRange.Full;
				this.invert = false;
				this.deadZone = 0f;
				this.zero = 0f;
				this.min = -1f;
				this.max = 1f;
				this.sensitivity = 1f;
				this.sensitivityType = AxisSensitivityType.Multiplier;
				this.sensitivityCurve = AnimationCurve.Linear(-1f, 1f, 1f, 1f);
				this.axisInfo = new HardwareAxisInfo(AxisCoordinateMode.Absolute, false, -1f, SpecialAxisType.None);
			}

			// Token: 0x06001B38 RID: 6968 RVA: 0x00075600 File Offset: 0x00073800
			[Obsolete("This constructor should not longer be used.", false)]
			public Axis(string A_1, string A_2, string A_3, int A_4, AxisRange A_5, bool A_6, float A_7, float A_8, float A_9, float A_10, bool A_11, HardwareAxisInfo A_12) : base(A_1, A_4)
			{
				this.range = A_5;
				this.invert = A_6;
				this.deadZone = A_7;
				this.zero = A_8;
				this.min = A_9;
				this.max = A_10;
				this.doNotCalibrateRange = A_11;
				this.axisInfo = (MiscTools.DeepClone<HardwareAxisInfo>(A_12) ?? HardwareAxisInfo.Default);
				this.sensitivity = 1f;
				this.sensitivityType = AxisSensitivityType.Multiplier;
				this.sensitivityCurve = AnimationCurve.Linear(-1f, 1f, 1f, 1f);
			}

			// Token: 0x06001B39 RID: 6969 RVA: 0x000756AC File Offset: 0x000738AC
			public Axis(CustomController_Editor.Axis A_1) : base(A_1.name, A_1.elementIdentifierId)
			{
				this.range = A_1.range;
				this.invert = A_1.invert;
				this.deadZone = A_1.deadZone;
				this.zero = A_1.zero;
				this.min = A_1.min;
				this.max = A_1.max;
				this.doNotCalibrateRange = A_1.doNotCalibrateRange;
				this.sensitivity = A_1.sensitivity;
				this.sensitivityType = A_1.sensitivityType;
				this.sensitivityCurve = UnityTools.Copy(A_1.sensitivityCurve);
				this.axisInfo = (MiscTools.DeepClone<HardwareAxisInfo>(A_1.axisInfo) ?? HardwareAxisInfo.Default);
			}

			// Token: 0x06001B3A RID: 6970 RVA: 0x00015FFD File Offset: 0x000141FD
			public override CustomController_Editor.Element Clone()
			{
				return new CustomController_Editor.Axis(this);
			}

			// Token: 0x04000F81 RID: 3969
			public AxisRange range;

			// Token: 0x04000F82 RID: 3970
			public bool invert;

			// Token: 0x04000F83 RID: 3971
			public float deadZone;

			// Token: 0x04000F84 RID: 3972
			public float zero;

			// Token: 0x04000F85 RID: 3973
			public float min;

			// Token: 0x04000F86 RID: 3974
			public float max;

			// Token: 0x04000F87 RID: 3975
			public bool doNotCalibrateRange;

			// Token: 0x04000F88 RID: 3976
			public AxisSensitivityType sensitivityType;

			// Token: 0x04000F89 RID: 3977
			public float sensitivity = 1f;

			// Token: 0x04000F8A RID: 3978
			public AnimationCurve sensitivityCurve;

			// Token: 0x04000F8B RID: 3979
			public HardwareAxisInfo axisInfo = HardwareAxisInfo.Default;
		}
	}
}
