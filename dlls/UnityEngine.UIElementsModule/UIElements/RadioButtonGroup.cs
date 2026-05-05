using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000116 RID: 278
	public class RadioButtonGroup : BaseField<int>, IGroupBox
	{
		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000959 RID: 2393 RVA: 0x00024158 File Offset: 0x00022358
		// (set) Token: 0x0600095A RID: 2394 RVA: 0x00024178 File Offset: 0x00022378
		public IEnumerable<string> choices
		{
			get
			{
				foreach (RadioButton radioButton in this.m_RadioButtons)
				{
					yield return radioButton.text;
					radioButton = null;
				}
				List<RadioButton>.Enumerator enumerator = default(List<RadioButton>.Enumerator);
				yield break;
				yield break;
			}
			set
			{
				bool flag = !value.HasValues();
				if (flag)
				{
					this.m_RadioButtonContainer.Clear();
					bool flag2 = base.panel != null;
					if (!flag2)
					{
						foreach (RadioButton control in this.m_RadioButtons)
						{
							control.UnregisterValueChangedCallback(this.m_RadioButtonValueChangedCallback);
						}
						this.m_RadioButtons.Clear();
					}
				}
				else
				{
					int num = 0;
					foreach (string text in value)
					{
						bool flag3 = num < this.m_RadioButtons.Count;
						if (flag3)
						{
							this.m_RadioButtons[num].text = text;
							this.m_RadioButtonContainer.Insert(num, this.m_RadioButtons[num]);
						}
						else
						{
							RadioButton radioButton = new RadioButton
							{
								text = text
							};
							radioButton.RegisterValueChangedCallback(this.m_RadioButtonValueChangedCallback);
							this.m_RadioButtons.Add(radioButton);
							this.m_RadioButtonContainer.Add(radioButton);
						}
						num++;
					}
					int num2 = this.m_RadioButtons.Count - 1;
					for (int i = num2; i >= num; i--)
					{
						this.m_RadioButtons[i].RemoveFromHierarchy();
					}
					this.UpdateRadioButtons();
				}
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x0600095B RID: 2395 RVA: 0x00024324 File Offset: 0x00022524
		public override VisualElement contentContainer
		{
			get
			{
				return this.m_RadioButtonContainer ?? this;
			}
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x00024331 File Offset: 0x00022531
		public RadioButtonGroup() : this(null, null)
		{
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x00024340 File Offset: 0x00022540
		public RadioButtonGroup(string label, List<string> radioButtonChoices = null) : base(label, null)
		{
			base.AddToClassList(RadioButtonGroup.ussClassName);
			VisualElement visualInput = base.visualInput;
			VisualElement visualElement = new VisualElement();
			visualElement.name = RadioButtonGroup.containerUssClassName;
			VisualElement child = visualElement;
			this.m_RadioButtonContainer = visualElement;
			visualInput.Add(child);
			this.m_RadioButtonContainer.AddToClassList(RadioButtonGroup.containerUssClassName);
			this.m_RadioButtonValueChangedCallback = new EventCallback<ChangeEvent<bool>>(this.RadioButtonValueChangedCallback);
			this.choices = radioButtonChoices;
			this.value = -1;
			base.visualInput.focusable = false;
			base.delegatesFocus = true;
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x000243DC File Offset: 0x000225DC
		private void RadioButtonValueChangedCallback(ChangeEvent<bool> evt)
		{
			bool newValue = evt.newValue;
			if (newValue)
			{
				this.value = this.m_RadioButtons.IndexOf(evt.target as RadioButton);
				evt.StopPropagation();
			}
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x0002441A File Offset: 0x0002261A
		public override void SetValueWithoutNotify(int newValue)
		{
			base.SetValueWithoutNotify(newValue);
			this.UpdateRadioButtons();
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x0002442C File Offset: 0x0002262C
		private void UpdateRadioButtons()
		{
			bool flag = this.value >= 0 && this.value < this.m_RadioButtons.Count;
			if (flag)
			{
				this.m_RadioButtons[this.value].value = true;
			}
			else
			{
				foreach (RadioButton radioButton in this.m_RadioButtons)
				{
					radioButton.value = false;
				}
			}
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x000244C8 File Offset: 0x000226C8
		void IGroupBox.OnOptionAdded(IGroupBoxOption option)
		{
			RadioButton radioButton = option as RadioButton;
			bool flag = radioButton == null;
			if (flag)
			{
				throw new ArgumentException("[UI Toolkit] Internal group box error. Expected a radio button element. Please report this using Help -> Report a bug...");
			}
			bool flag2 = this.m_RadioButtons.Contains(radioButton);
			if (!flag2)
			{
				radioButton.RegisterValueChangedCallback(this.m_RadioButtonValueChangedCallback);
				int num = this.m_RadioButtonContainer.IndexOf(radioButton);
				bool flag3 = num < 0 || num > this.m_RadioButtons.Count;
				if (flag3)
				{
					this.m_RadioButtons.Add(radioButton);
					this.m_RadioButtonContainer.Add(radioButton);
				}
				else
				{
					this.m_RadioButtons.Insert(num, radioButton);
				}
			}
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x00024568 File Offset: 0x00022768
		void IGroupBox.OnOptionRemoved(IGroupBoxOption option)
		{
			RadioButton radioButton = option as RadioButton;
			bool flag = radioButton == null;
			if (flag)
			{
				throw new ArgumentException("[UI Toolkit] Internal group box error. Expected a radio button element. Please report this using Help -> Report a bug...");
			}
			int num = this.m_RadioButtons.IndexOf(radioButton);
			radioButton.UnregisterValueChangedCallback(this.m_RadioButtonValueChangedCallback);
			this.m_RadioButtons.Remove(radioButton);
			bool flag2 = this.value == num;
			if (flag2)
			{
				this.value = -1;
			}
		}

		// Token: 0x04000438 RID: 1080
		public new static readonly string ussClassName = "unity-radio-button-group";

		// Token: 0x04000439 RID: 1081
		public static readonly string containerUssClassName = RadioButtonGroup.ussClassName + "__container";

		// Token: 0x0400043A RID: 1082
		private List<RadioButton> m_RadioButtons = new List<RadioButton>();

		// Token: 0x0400043B RID: 1083
		private EventCallback<ChangeEvent<bool>> m_RadioButtonValueChangedCallback;

		// Token: 0x0400043C RID: 1084
		private VisualElement m_RadioButtonContainer;

		// Token: 0x02000117 RID: 279
		public new class UxmlFactory : UxmlFactory<RadioButtonGroup, RadioButtonGroup.UxmlTraits>
		{
		}

		// Token: 0x02000118 RID: 280
		public new class UxmlTraits : BaseFieldTraits<int, UxmlIntAttributeDescription>
		{
			// Token: 0x06000965 RID: 2405 RVA: 0x000245F8 File Offset: 0x000227F8
			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				base.Init(ve, bag, cc);
				RadioButtonGroup radioButtonGroup = (RadioButtonGroup)ve;
				radioButtonGroup.choices = BaseField<int>.UxmlTraits.ParseChoiceList(this.m_Choices.GetValueFromBag(bag, cc));
			}

			// Token: 0x0400043D RID: 1085
			private UxmlStringAttributeDescription m_Choices = new UxmlStringAttributeDescription
			{
				name = "choices"
			};
		}
	}
}
