using System;
using System.Collections.Generic;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.UIElements
{
	// Token: 0x02000109 RID: 265
	[MovedFrom(true, "UnityEditor.UIElements", "UnityEditor.UIElementsModule", null)]
	public class PopupField<T> : BasePopupField<T, T>
	{
		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000911 RID: 2321 RVA: 0x0002335C File Offset: 0x0002155C
		// (set) Token: 0x06000912 RID: 2322 RVA: 0x00023374 File Offset: 0x00021574
		public virtual Func<T, string> formatSelectedValueCallback
		{
			get
			{
				return this.m_FormatSelectedValueCallback;
			}
			set
			{
				this.m_FormatSelectedValueCallback = value;
				base.textElement.text = this.GetValueToDisplay();
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000913 RID: 2323 RVA: 0x00023390 File Offset: 0x00021590
		// (set) Token: 0x06000914 RID: 2324 RVA: 0x000233A8 File Offset: 0x000215A8
		public virtual Func<T, string> formatListItemCallback
		{
			get
			{
				return this.m_FormatListItemCallback;
			}
			set
			{
				this.m_FormatListItemCallback = value;
			}
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x000233B4 File Offset: 0x000215B4
		internal override string GetValueToDisplay()
		{
			bool flag = this.m_FormatSelectedValueCallback != null;
			string result;
			if (flag)
			{
				result = this.m_FormatSelectedValueCallback(this.value);
			}
			else
			{
				bool flag2 = this.value != null;
				if (flag2)
				{
					T value = this.value;
					result = UIElementsUtility.ParseMenuName(value.ToString());
				}
				else
				{
					result = string.Empty;
				}
			}
			return result;
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x0002341C File Offset: 0x0002161C
		internal override string GetListItemToDisplay(T value)
		{
			bool flag = this.m_FormatListItemCallback != null;
			string result;
			if (flag)
			{
				result = this.m_FormatListItemCallback(value);
			}
			else
			{
				result = ((value != null && this.m_Choices.Contains(value)) ? value.ToString() : string.Empty);
			}
			return result;
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000917 RID: 2327 RVA: 0x00023474 File Offset: 0x00021674
		// (set) Token: 0x06000918 RID: 2328 RVA: 0x0002348C File Offset: 0x0002168C
		public override T value
		{
			get
			{
				return base.value;
			}
			set
			{
				List<T> choices = this.m_Choices;
				this.m_Index = ((choices != null) ? choices.IndexOf(value) : -1);
				base.value = value;
			}
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x000234B0 File Offset: 0x000216B0
		public override void SetValueWithoutNotify(T newValue)
		{
			List<T> choices = this.m_Choices;
			this.m_Index = ((choices != null) ? choices.IndexOf(newValue) : -1);
			base.SetValueWithoutNotify(newValue);
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x0600091A RID: 2330 RVA: 0x000234D4 File Offset: 0x000216D4
		// (set) Token: 0x0600091B RID: 2331 RVA: 0x000234EC File Offset: 0x000216EC
		public int index
		{
			get
			{
				return this.m_Index;
			}
			set
			{
				bool flag = value != this.m_Index;
				if (flag)
				{
					this.m_Index = value;
					bool flag2 = this.m_Index >= 0 && this.m_Index < this.m_Choices.Count;
					if (flag2)
					{
						this.value = this.m_Choices[this.m_Index];
					}
					else
					{
						this.value = default(T);
					}
				}
			}
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x00023560 File Offset: 0x00021760
		public PopupField() : this(null)
		{
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x0002356B File Offset: 0x0002176B
		public PopupField(string label = null) : base(label)
		{
			base.AddToClassList(PopupField<T>.ussClassName);
			base.labelElement.AddToClassList(PopupField<T>.labelUssClassName);
			base.visualInput.AddToClassList(PopupField<T>.inputUssClassName);
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x000235AB File Offset: 0x000217AB
		public PopupField(List<T> choices, T defaultValue, Func<T, string> formatSelectedValueCallback = null, Func<T, string> formatListItemCallback = null) : this(null, choices, defaultValue, formatSelectedValueCallback, formatListItemCallback)
		{
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x000235BC File Offset: 0x000217BC
		public PopupField(string label, List<T> choices, T defaultValue, Func<T, string> formatSelectedValueCallback = null, Func<T, string> formatListItemCallback = null) : this(label)
		{
			bool flag = defaultValue == null;
			if (flag)
			{
				throw new ArgumentNullException("defaultValue");
			}
			this.choices = choices;
			bool flag2 = !this.m_Choices.Contains(defaultValue);
			if (flag2)
			{
				throw new ArgumentException(string.Format("Default value {0} is not present in the list of possible values", defaultValue));
			}
			this.SetValueWithoutNotify(defaultValue);
			this.formatListItemCallback = formatListItemCallback;
			this.formatSelectedValueCallback = formatSelectedValueCallback;
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x00023635 File Offset: 0x00021835
		public PopupField(List<T> choices, int defaultIndex, Func<T, string> formatSelectedValueCallback = null, Func<T, string> formatListItemCallback = null) : this(null, choices, defaultIndex, formatSelectedValueCallback, formatListItemCallback)
		{
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x00023645 File Offset: 0x00021845
		public PopupField(string label, List<T> choices, int defaultIndex, Func<T, string> formatSelectedValueCallback = null, Func<T, string> formatListItemCallback = null) : this(label)
		{
			this.choices = choices;
			this.SetIndexWithoutNotify(defaultIndex);
			this.formatListItemCallback = formatListItemCallback;
			this.formatSelectedValueCallback = formatSelectedValueCallback;
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x00023674 File Offset: 0x00021874
		internal override void AddMenuItems(IGenericMenu menu)
		{
			bool flag = menu == null;
			if (flag)
			{
				throw new ArgumentNullException("menu");
			}
			bool flag2 = this.m_Choices == null;
			if (!flag2)
			{
				using (List<T>.Enumerator enumerator = this.m_Choices.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						T item = enumerator.Current;
						bool isChecked = EqualityComparer<T>.Default.Equals(item, this.value) && !base.showMixedValue;
						menu.AddItem(this.GetListItemToDisplay(item), isChecked, delegate()
						{
							this.ChangeValueFromMenu(item);
						});
					}
				}
			}
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x00023744 File Offset: 0x00021944
		internal void SetIndexWithoutNotify(int index)
		{
			this.m_Index = index;
			bool flag = this.m_Index >= 0 && this.m_Index < this.m_Choices.Count;
			if (flag)
			{
				this.SetValueWithoutNotify(this.m_Choices[this.m_Index]);
			}
			else
			{
				this.SetValueWithoutNotify(default(T));
			}
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x000237A6 File Offset: 0x000219A6
		private void ChangeValueFromMenu(T menuItem)
		{
			this.value = menuItem;
		}

		// Token: 0x04000411 RID: 1041
		internal const int kPopupFieldDefaultIndex = -1;

		// Token: 0x04000412 RID: 1042
		private int m_Index = -1;

		// Token: 0x04000413 RID: 1043
		public new static readonly string ussClassName = "unity-popup-field";

		// Token: 0x04000414 RID: 1044
		public new static readonly string labelUssClassName = PopupField<T>.ussClassName + "__label";

		// Token: 0x04000415 RID: 1045
		public new static readonly string inputUssClassName = PopupField<T>.ussClassName + "__input";
	}
}
