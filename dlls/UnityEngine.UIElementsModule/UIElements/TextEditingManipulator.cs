using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200036A RID: 874
	internal class TextEditingManipulator
	{
		// Token: 0x170006BF RID: 1727
		// (get) Token: 0x06001CF8 RID: 7416 RVA: 0x000704E0 File Offset: 0x0006E6E0
		private bool touchScreenTextFieldChanged
		{
			get
			{
				bool touchScreenTextFieldInitialized = this.m_TouchScreenTextFieldInitialized;
				TextEditingUtilities textEditingUtilities = this.editingUtilities;
				bool? flag = (textEditingUtilities != null) ? new bool?(textEditingUtilities.TouchScreenKeyboardShouldBeUsed()) : null;
				return !(touchScreenTextFieldInitialized == flag.GetValueOrDefault() & flag != null);
			}
		}

		// Token: 0x06001CF9 RID: 7417 RVA: 0x00070528 File Offset: 0x0006E728
		public TextEditingManipulator(TextElement textElement)
		{
			this.m_TextElement = textElement;
			this.editingUtilities = new TextEditingUtilities(textElement.selectingManipulator.m_SelectingUtilities, textElement.uitkTextHandle, textElement.text);
			this.InitTextEditorEventHandler();
		}

		// Token: 0x06001CFA RID: 7418 RVA: 0x00070574 File Offset: 0x0006E774
		private void InitTextEditorEventHandler()
		{
			TextEditingUtilities textEditingUtilities = this.editingUtilities;
			this.m_TouchScreenTextFieldInitialized = (textEditingUtilities != null && textEditingUtilities.TouchScreenKeyboardShouldBeUsed());
			bool touchScreenTextFieldInitialized = this.m_TouchScreenTextFieldInitialized;
			if (touchScreenTextFieldInitialized)
			{
				this.editingEventHandler = new TouchScreenTextEditorEventHandler(this.m_TextElement, this.editingUtilities);
			}
			else
			{
				this.editingEventHandler = new KeyboardTextEditorEventHandler(this.m_TextElement, this.editingUtilities);
			}
		}

		// Token: 0x06001CFB RID: 7419 RVA: 0x000705D8 File Offset: 0x0006E7D8
		internal void ExecuteDefaultActionAtTarget(EventBase evt)
		{
			bool isReadOnly = this.m_TextElement.edition.isReadOnly;
			if (!isReadOnly)
			{
				FocusInEvent focusInEvent = evt as FocusInEvent;
				if (focusInEvent == null)
				{
					FocusOutEvent focusOutEvent = evt as FocusOutEvent;
					if (focusOutEvent != null)
					{
						this.OnFocusOutEvent(focusOutEvent);
					}
				}
				else
				{
					this.OnFocusInEvent(focusInEvent);
				}
				TextEditorEventHandler textEditorEventHandler = this.editingEventHandler;
				if (textEditorEventHandler != null)
				{
					textEditorEventHandler.ExecuteDefaultActionAtTarget(evt);
				}
			}
		}

		// Token: 0x06001CFC RID: 7420 RVA: 0x00070644 File Offset: 0x0006E844
		private void OnFocusInEvent(FocusInEvent _)
		{
			this.m_TextElement.edition.SaveValueAndText();
			this.m_TextElement.focusController.selectedTextElement = this.m_TextElement;
			bool touchScreenTextFieldChanged = this.touchScreenTextFieldChanged;
			if (touchScreenTextFieldChanged)
			{
				this.InitTextEditorEventHandler();
			}
			bool flag = this.m_HardwareKeyboardPoller == null;
			if (flag)
			{
				this.m_HardwareKeyboardPoller = this.m_TextElement.schedule.Execute(delegate()
				{
					bool touchScreenTextFieldChanged2 = this.touchScreenTextFieldChanged;
					if (touchScreenTextFieldChanged2)
					{
						this.InitTextEditorEventHandler();
						this.m_TextElement.Blur();
					}
				}).Every(250L);
			}
			else
			{
				this.m_HardwareKeyboardPoller.Resume();
			}
		}

		// Token: 0x06001CFD RID: 7421 RVA: 0x000706D7 File Offset: 0x0006E8D7
		private void OnFocusOutEvent(FocusOutEvent _)
		{
			IVisualElementScheduledItem hardwareKeyboardPoller = this.m_HardwareKeyboardPoller;
			if (hardwareKeyboardPoller != null)
			{
				hardwareKeyboardPoller.Pause();
			}
			this.editingUtilities.OnBlur();
		}

		// Token: 0x04000C37 RID: 3127
		private TextElement m_TextElement;

		// Token: 0x04000C38 RID: 3128
		internal TextEditorEventHandler editingEventHandler;

		// Token: 0x04000C39 RID: 3129
		internal TextEditingUtilities editingUtilities;

		// Token: 0x04000C3A RID: 3130
		private bool m_TouchScreenTextFieldInitialized;

		// Token: 0x04000C3B RID: 3131
		private IVisualElementScheduledItem m_HardwareKeyboardPoller = null;
	}
}
