using System;
using System.Collections.Generic;
using UnityEngine.TextCore.Text;

namespace UnityEngine.UIElements
{
	// Token: 0x0200036F RID: 879
	public class TextElement : BindableElement, ITextElement, INotifyValueChanged<string>, ITextEdition, ITextElementExperimentalFeatures, IExperimentalFeatures, ITextSelection
	{
		// Token: 0x06001D36 RID: 7478 RVA: 0x00072354 File Offset: 0x00070554
		public TextElement()
		{
			base.requireMeasureFunction = true;
			base.tabIndex = -1;
			this.uitkTextHandle = new UITKTextHandle(this);
			base.AddToClassList(TextElement.ussClassName);
			base.generateVisualContent = (Action<MeshGenerationContext>)Delegate.Combine(base.generateVisualContent, new Action<MeshGenerationContext>(this.OnGenerateVisualContent));
			base.RegisterCallback<GeometryChangedEvent>(new EventCallback<GeometryChangedEvent>(this.OnGeometryChanged), TrickleDown.NoTrickleDown);
		}

		// Token: 0x170006C6 RID: 1734
		// (get) Token: 0x06001D37 RID: 7479 RVA: 0x00072463 File Offset: 0x00070663
		// (set) Token: 0x06001D38 RID: 7480 RVA: 0x0007246B File Offset: 0x0007066B
		internal UITKTextHandle uitkTextHandle { get; set; }

		// Token: 0x06001D39 RID: 7481 RVA: 0x00072474 File Offset: 0x00070674
		private void OnGeometryChanged(GeometryChangedEvent e)
		{
			this.UpdateVisibleText();
		}

		// Token: 0x170006C7 RID: 1735
		// (get) Token: 0x06001D3A RID: 7482 RVA: 0x0007247E File Offset: 0x0007067E
		// (set) Token: 0x06001D3B RID: 7483 RVA: 0x00072486 File Offset: 0x00070686
		public virtual string text
		{
			get
			{
				return ((INotifyValueChanged<string>)this).value;
			}
			set
			{
				((INotifyValueChanged<string>)this).value = value;
			}
		}

		// Token: 0x170006C8 RID: 1736
		// (get) Token: 0x06001D3C RID: 7484 RVA: 0x00072490 File Offset: 0x00070690
		// (set) Token: 0x06001D3D RID: 7485 RVA: 0x00072498 File Offset: 0x00070698
		public bool enableRichText
		{
			get
			{
				return this.m_EnableRichText;
			}
			set
			{
				bool flag = this.m_EnableRichText == value;
				if (!flag)
				{
					this.m_EnableRichText = value;
					base.MarkDirtyRepaint();
				}
			}
		}

		// Token: 0x170006C9 RID: 1737
		// (get) Token: 0x06001D3E RID: 7486 RVA: 0x000724C3 File Offset: 0x000706C3
		// (set) Token: 0x06001D3F RID: 7487 RVA: 0x000724CC File Offset: 0x000706CC
		public bool parseEscapeSequences
		{
			get
			{
				return this.m_ParseEscapeSequences;
			}
			set
			{
				bool flag = this.m_ParseEscapeSequences == value;
				if (!flag)
				{
					this.m_ParseEscapeSequences = value;
					base.MarkDirtyRepaint();
				}
			}
		}

		// Token: 0x170006CA RID: 1738
		// (get) Token: 0x06001D40 RID: 7488 RVA: 0x000724F7 File Offset: 0x000706F7
		// (set) Token: 0x06001D41 RID: 7489 RVA: 0x00072500 File Offset: 0x00070700
		public bool displayTooltipWhenElided
		{
			get
			{
				return this.m_DisplayTooltipWhenElided;
			}
			set
			{
				bool flag = this.m_DisplayTooltipWhenElided != value;
				if (flag)
				{
					this.m_DisplayTooltipWhenElided = value;
					this.UpdateVisibleText();
					base.MarkDirtyRepaint();
				}
			}
		}

		// Token: 0x170006CB RID: 1739
		// (get) Token: 0x06001D42 RID: 7490 RVA: 0x00072535 File Offset: 0x00070735
		// (set) Token: 0x06001D43 RID: 7491 RVA: 0x0007253D File Offset: 0x0007073D
		public bool isElided { get; private set; }

		// Token: 0x06001D44 RID: 7492 RVA: 0x00072548 File Offset: 0x00070748
		internal void OnGenerateVisualContent(MeshGenerationContext mgc)
		{
			this.UpdateVisibleText();
			mgc.Text(this);
			bool flag = this.ShouldElide() && this.uitkTextHandle.TextLibraryCanElide();
			if (flag)
			{
				this.isElided = this.uitkTextHandle.IsElided();
			}
			this.UpdateTooltip();
			bool flag2 = this.selection.HasSelection() && this.selectingManipulator.HasFocus();
			if (flag2)
			{
				this.DrawHighlighting(mgc);
			}
			else
			{
				bool flag3 = !this.edition.isReadOnly && this.selection.isSelectable && this.selectingManipulator.RevealCursor();
				if (flag3)
				{
					this.DrawCaret(mgc);
				}
			}
		}

		// Token: 0x06001D45 RID: 7493 RVA: 0x000725F8 File Offset: 0x000707F8
		internal string ElideText(string drawText, string ellipsisText, float width, TextOverflowPosition textOverflowPosition)
		{
			float num = base.resolvedStyle.paddingRight;
			bool flag = float.IsNaN(num);
			if (flag)
			{
				num = 0f;
			}
			float num2 = Mathf.Clamp(num, 1f / base.scaledPixelsPerPoint, 1f);
			Vector2 vector = this.MeasureTextSize(drawText, 0f, VisualElement.MeasureMode.Undefined, 0f, VisualElement.MeasureMode.Undefined);
			bool flag2 = vector.x <= width + num2 || string.IsNullOrEmpty(ellipsisText);
			string result;
			if (flag2)
			{
				result = drawText;
			}
			else
			{
				string text = (drawText.Length > 1) ? ellipsisText : drawText;
				Vector2 vector2 = this.MeasureTextSize(text, 0f, VisualElement.MeasureMode.Undefined, 0f, VisualElement.MeasureMode.Undefined);
				bool flag3 = vector2.x >= width;
				if (flag3)
				{
					result = text;
				}
				else
				{
					int num3 = drawText.Length - 1;
					int num4 = -1;
					string text2 = drawText;
					int i = (textOverflowPosition == TextOverflowPosition.Start) ? 1 : 0;
					int num5 = (textOverflowPosition == TextOverflowPosition.Start || textOverflowPosition == TextOverflowPosition.Middle) ? num3 : (num3 - 1);
					int num6 = (i + num5) / 2;
					while (i <= num5)
					{
						bool flag4 = textOverflowPosition == TextOverflowPosition.Start;
						if (flag4)
						{
							text2 = ellipsisText + drawText.Substring(num6, num3 - (num6 - 1));
						}
						else
						{
							bool flag5 = textOverflowPosition == TextOverflowPosition.End;
							if (flag5)
							{
								text2 = drawText.Substring(0, num6) + ellipsisText;
							}
							else
							{
								bool flag6 = textOverflowPosition == TextOverflowPosition.Middle;
								if (flag6)
								{
									text2 = ((num6 - 1 <= 0) ? "" : drawText.Substring(0, num6 - 1)) + ellipsisText + ((num3 - (num6 - 1) <= 0) ? "" : drawText.Substring(num3 - (num6 - 1)));
								}
							}
						}
						vector = this.MeasureTextSize(text2, 0f, VisualElement.MeasureMode.Undefined, 0f, VisualElement.MeasureMode.Undefined);
						bool flag7 = Math.Abs(vector.x - width) < 1E-30f;
						if (flag7)
						{
							return text2;
						}
						bool flag8 = textOverflowPosition == TextOverflowPosition.Start;
						if (flag8)
						{
							bool flag9 = vector.x > width;
							if (flag9)
							{
								bool flag10 = num4 == num6 - 1;
								if (flag10)
								{
									return ellipsisText + drawText.Substring(num4, num3 - (num4 - 1));
								}
								i = num6 + 1;
							}
							else
							{
								num5 = num6 - 1;
								num4 = num6;
							}
						}
						else
						{
							bool flag11 = textOverflowPosition == TextOverflowPosition.End || textOverflowPosition == TextOverflowPosition.Middle;
							if (flag11)
							{
								bool flag12 = vector.x > width;
								if (flag12)
								{
									bool flag13 = num4 == num6 - 1;
									if (flag13)
									{
										bool flag14 = textOverflowPosition == TextOverflowPosition.End;
										if (flag14)
										{
											return drawText.Substring(0, num4) + ellipsisText;
										}
										return drawText.Substring(0, Mathf.Max(num4 - 1, 0)) + ellipsisText + drawText.Substring(num3 - Mathf.Max(num4 - 1, 0));
									}
									else
									{
										num5 = num6 - 1;
									}
								}
								else
								{
									i = num6 + 1;
									num4 = num6;
								}
							}
						}
						num6 = (i + num5) / 2;
					}
					result = text2;
				}
			}
			return result;
		}

		// Token: 0x06001D46 RID: 7494 RVA: 0x000728D0 File Offset: 0x00070AD0
		private void UpdateTooltip()
		{
			bool flag = this.displayTooltipWhenElided && this.isElided;
			bool flag2 = flag;
			if (flag2)
			{
				base.tooltip = this.text;
				this.m_WasElided = true;
			}
			else
			{
				bool wasElided = this.m_WasElided;
				if (wasElided)
				{
					base.tooltip = null;
					this.m_WasElided = false;
				}
			}
		}

		// Token: 0x06001D47 RID: 7495 RVA: 0x00072928 File Offset: 0x00070B28
		private void UpdateVisibleText()
		{
			bool flag = this.ShouldElide();
			bool flag2 = flag && this.uitkTextHandle.TextLibraryCanElide();
			if (!flag2)
			{
				bool flag3 = flag;
				if (flag3)
				{
					this.elidedText = this.ElideText(this.text, TextElement.k_EllipsisText, base.contentRect.width, base.computedStyle.unityTextOverflowPosition);
					this.isElided = (flag && this.elidedText != this.text);
				}
				else
				{
					this.isElided = false;
				}
			}
		}

		// Token: 0x06001D48 RID: 7496 RVA: 0x000729B8 File Offset: 0x00070BB8
		private bool ShouldElide()
		{
			return base.computedStyle.textOverflow == TextOverflow.Ellipsis && base.computedStyle.overflow == OverflowInternal.Hidden;
		}

		// Token: 0x170006CC RID: 1740
		// (get) Token: 0x06001D49 RID: 7497 RVA: 0x000729E9 File Offset: 0x00070BE9
		internal bool hasFocus
		{
			get
			{
				bool result;
				if (base.elementPanel != null)
				{
					FocusController focusController = base.elementPanel.focusController;
					result = (((focusController != null) ? focusController.GetLeafFocusedElement() : null) == this);
				}
				else
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x06001D4A RID: 7498 RVA: 0x00072A10 File Offset: 0x00070C10
		public Vector2 MeasureTextSize(string textToMeasure, float width, VisualElement.MeasureMode widthMode, float height, VisualElement.MeasureMode heightMode)
		{
			return TextUtilities.MeasureVisualElementTextSize(this, textToMeasure, width, widthMode, height, heightMode);
		}

		// Token: 0x06001D4B RID: 7499 RVA: 0x00072A30 File Offset: 0x00070C30
		protected internal override Vector2 DoMeasure(float desiredWidth, VisualElement.MeasureMode widthMode, float desiredHeight, VisualElement.MeasureMode heightMode)
		{
			return this.MeasureTextSize(this.renderedText, desiredWidth, widthMode, desiredHeight, heightMode);
		}

		// Token: 0x170006CD RID: 1741
		// (get) Token: 0x06001D4C RID: 7500 RVA: 0x00072A53 File Offset: 0x00070C53
		// (set) Token: 0x06001D4D RID: 7501 RVA: 0x00072A64 File Offset: 0x00070C64
		string INotifyValueChanged<string>.value
		{
			get
			{
				return this.m_Text ?? string.Empty;
			}
			set
			{
				bool flag = this.m_Text != value;
				if (flag)
				{
					bool flag2 = base.panel != null;
					if (flag2)
					{
						using (ChangeEvent<string> pooled = ChangeEvent<string>.GetPooled(this.text, value))
						{
							pooled.target = this;
							((INotifyValueChanged<string>)this).SetValueWithoutNotify(value);
							this.SendEvent(pooled);
						}
					}
					else
					{
						((INotifyValueChanged<string>)this).SetValueWithoutNotify(value);
					}
				}
			}
		}

		// Token: 0x06001D4E RID: 7502 RVA: 0x00072AE4 File Offset: 0x00070CE4
		void INotifyValueChanged<string>.SetValueWithoutNotify(string newValue)
		{
			newValue = ((ITextEdition)this).CullString(newValue);
			bool flag = this.m_Text != newValue;
			if (flag)
			{
				this.renderedText = newValue;
				this.m_Text = newValue;
				base.IncrementVersion(VersionChangeType.Layout | VersionChangeType.Repaint);
				bool flag2 = !string.IsNullOrEmpty(base.viewDataKey);
				if (flag2)
				{
					base.SaveViewData();
				}
			}
			bool flag3 = this.editingManipulator != null;
			if (flag3)
			{
				this.editingManipulator.editingUtilities.text = newValue;
			}
		}

		// Token: 0x170006CE RID: 1742
		// (get) Token: 0x06001D4F RID: 7503 RVA: 0x0002DD41 File Offset: 0x0002BF41
		internal ITextEdition edition
		{
			get
			{
				return this;
			}
		}

		// Token: 0x170006CF RID: 1743
		// (get) Token: 0x06001D50 RID: 7504 RVA: 0x00072B60 File Offset: 0x00070D60
		// (set) Token: 0x06001D51 RID: 7505 RVA: 0x00072B68 File Offset: 0x00070D68
		bool ITextEdition.multiline
		{
			get
			{
				return this.m_Multiline;
			}
			set
			{
				bool flag = value != this.m_Multiline;
				if (flag)
				{
					bool flag2 = !this.edition.isReadOnly;
					if (flag2)
					{
						this.editingManipulator.editingUtilities.multiline = value;
					}
					this.m_Multiline = value;
				}
			}
		}

		// Token: 0x170006D0 RID: 1744
		// (get) Token: 0x06001D52 RID: 7506 RVA: 0x00072BB2 File Offset: 0x00070DB2
		TouchScreenKeyboard ITextEdition.touchScreenKeyboard
		{
			get
			{
				return this.m_TouchScreenKeyboard;
			}
		}

		// Token: 0x170006D1 RID: 1745
		// (get) Token: 0x06001D53 RID: 7507 RVA: 0x00072BBA File Offset: 0x00070DBA
		// (set) Token: 0x06001D54 RID: 7508 RVA: 0x00072BC2 File Offset: 0x00070DC2
		TouchScreenKeyboardType ITextEdition.keyboardType
		{
			get
			{
				return this.m_KeyboardType;
			}
			set
			{
				this.m_KeyboardType = value;
			}
		}

		// Token: 0x170006D2 RID: 1746
		// (get) Token: 0x06001D55 RID: 7509 RVA: 0x00072BCC File Offset: 0x00070DCC
		// (set) Token: 0x06001D56 RID: 7510 RVA: 0x00072C10 File Offset: 0x00070E10
		bool ITextEdition.hideMobileInput
		{
			get
			{
				RuntimePlatform platform = Application.platform;
				RuntimePlatform runtimePlatform = platform;
				if (runtimePlatform <= RuntimePlatform.Android)
				{
					if (runtimePlatform != RuntimePlatform.IPhonePlayer && runtimePlatform != RuntimePlatform.Android)
					{
						goto IL_32;
					}
				}
				else if (runtimePlatform != RuntimePlatform.WebGLPlayer && runtimePlatform != RuntimePlatform.tvOS)
				{
					goto IL_32;
				}
				return this.m_HideMobileInput;
				IL_32:
				return true;
			}
			set
			{
				RuntimePlatform platform = Application.platform;
				RuntimePlatform runtimePlatform = platform;
				if (runtimePlatform <= RuntimePlatform.Android)
				{
					if (runtimePlatform != RuntimePlatform.IPhonePlayer && runtimePlatform != RuntimePlatform.Android)
					{
						goto IL_32;
					}
				}
				else if (runtimePlatform != RuntimePlatform.WebGLPlayer && runtimePlatform != RuntimePlatform.tvOS)
				{
					goto IL_32;
				}
				this.m_HideMobileInput = value;
				return;
				IL_32:
				this.m_HideMobileInput = true;
			}
		}

		// Token: 0x170006D3 RID: 1747
		// (get) Token: 0x06001D57 RID: 7511 RVA: 0x00072C58 File Offset: 0x00070E58
		// (set) Token: 0x06001D58 RID: 7512 RVA: 0x00072C70 File Offset: 0x00070E70
		bool ITextEdition.isReadOnly
		{
			get
			{
				return this.m_IsReadOnly || !base.enabledInHierarchy;
			}
			set
			{
				bool flag = value == this.m_IsReadOnly;
				if (!flag)
				{
					this.editingManipulator = (value ? null : new TextEditingManipulator(this));
					this.m_IsReadOnly = value;
				}
			}
		}

		// Token: 0x06001D59 RID: 7513 RVA: 0x00072CA8 File Offset: 0x00070EA8
		private void ProcessMenuCommand(string command)
		{
			using (ExecuteCommandEvent pooled = CommandEventBase<ExecuteCommandEvent>.GetPooled(command))
			{
				pooled.target = this;
				this.SendEvent(pooled);
			}
		}

		// Token: 0x06001D5A RID: 7514 RVA: 0x00072CEC File Offset: 0x00070EEC
		private void Cut(DropdownMenuAction a)
		{
			this.ProcessMenuCommand("Cut");
		}

		// Token: 0x06001D5B RID: 7515 RVA: 0x00072CFB File Offset: 0x00070EFB
		private void Copy(DropdownMenuAction a)
		{
			this.ProcessMenuCommand("Copy");
		}

		// Token: 0x06001D5C RID: 7516 RVA: 0x00072D0A File Offset: 0x00070F0A
		private void Paste(DropdownMenuAction a)
		{
			this.ProcessMenuCommand("Paste");
		}

		// Token: 0x06001D5D RID: 7517 RVA: 0x00072D1C File Offset: 0x00070F1C
		private void BuildContextualMenu(ContextualMenuPopulateEvent evt)
		{
			bool flag = ((evt != null) ? evt.target : null) is TextElement;
			if (flag)
			{
				bool flag2 = !this.edition.isReadOnly;
				if (flag2)
				{
					evt.menu.AppendAction("Cut", new Action<DropdownMenuAction>(this.Cut), new Func<DropdownMenuAction, DropdownMenuAction.Status>(this.CutActionStatus), null);
					evt.menu.AppendAction("Copy", new Action<DropdownMenuAction>(this.Copy), new Func<DropdownMenuAction, DropdownMenuAction.Status>(this.CopyActionStatus), null);
					evt.menu.AppendAction("Paste", new Action<DropdownMenuAction>(this.Paste), new Func<DropdownMenuAction, DropdownMenuAction.Status>(this.PasteActionStatus), null);
				}
				else
				{
					evt.menu.AppendAction("Copy", new Action<DropdownMenuAction>(this.Copy), new Func<DropdownMenuAction, DropdownMenuAction.Status>(this.CopyActionStatus), null);
				}
			}
		}

		// Token: 0x06001D5E RID: 7518 RVA: 0x00072E08 File Offset: 0x00071008
		private DropdownMenuAction.Status CutActionStatus(DropdownMenuAction a)
		{
			return (base.enabledInHierarchy && this.selection.HasSelection() && !this.edition.isPassword) ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled;
		}

		// Token: 0x06001D5F RID: 7519 RVA: 0x00072E40 File Offset: 0x00071040
		private DropdownMenuAction.Status CopyActionStatus(DropdownMenuAction a)
		{
			return ((!base.enabledInHierarchy || this.selection.HasSelection()) && !this.edition.isPassword) ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled;
		}

		// Token: 0x06001D60 RID: 7520 RVA: 0x00072E78 File Offset: 0x00071078
		private DropdownMenuAction.Status PasteActionStatus(DropdownMenuAction a)
		{
			bool flag = this.editingManipulator.editingUtilities.CanPaste();
			return base.enabledInHierarchy ? (flag ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled) : DropdownMenuAction.Status.Hidden;
		}

		// Token: 0x06001D61 RID: 7521 RVA: 0x00072EB0 File Offset: 0x000710B0
		[EventInterest(new Type[]
		{
			typeof(ContextualMenuPopulateEvent),
			typeof(FocusInEvent),
			typeof(FocusOutEvent),
			typeof(KeyDownEvent),
			typeof(KeyUpEvent),
			typeof(FocusEvent),
			typeof(BlurEvent),
			typeof(ValidateCommandEvent),
			typeof(ExecuteCommandEvent),
			typeof(PointerDownEvent),
			typeof(PointerUpEvent),
			typeof(PointerMoveEvent),
			typeof(NavigationMoveEvent),
			typeof(NavigationSubmitEvent),
			typeof(NavigationCancelEvent)
		})]
		protected override void ExecuteDefaultActionAtTarget(EventBase evt)
		{
			bool isSelectable = this.selection.isSelectable;
			if (isSelectable)
			{
				TextEditingManipulator textEditingManipulator = this.editingManipulator;
				bool flag = textEditingManipulator != null && textEditingManipulator.editingUtilities.TouchScreenKeyboardShouldBeUsed();
				bool flag2 = !flag || (flag && this.edition.hideMobileInput);
				if (flag2)
				{
					TextSelectingManipulator selectingManipulator = this.selectingManipulator;
					if (selectingManipulator != null)
					{
						selectingManipulator.ExecuteDefaultActionAtTarget(evt);
					}
				}
				bool flag3 = !this.edition.isReadOnly;
				if (flag3)
				{
					TextEditingManipulator textEditingManipulator2 = this.editingManipulator;
					if (textEditingManipulator2 != null)
					{
						textEditingManipulator2.ExecuteDefaultActionAtTarget(evt);
					}
				}
				BaseVisualElementPanel elementPanel = base.elementPanel;
				if (elementPanel != null)
				{
					ContextualMenuManager contextualMenuManager = elementPanel.contextualMenuManager;
					if (contextualMenuManager != null)
					{
						contextualMenuManager.DisplayMenuIfEventMatches(evt, this);
					}
				}
				long? num = (evt != null) ? new long?(evt.eventTypeId) : null;
				long num2 = EventBase<ContextualMenuPopulateEvent>.TypeId();
				bool flag4 = num.GetValueOrDefault() == num2 & num != null;
				if (flag4)
				{
					ContextualMenuPopulateEvent contextualMenuPopulateEvent = evt as ContextualMenuPopulateEvent;
					int count = contextualMenuPopulateEvent.menu.MenuItems().Count;
					this.BuildContextualMenu(contextualMenuPopulateEvent);
					bool flag5 = count > 0 && contextualMenuPopulateEvent.menu.MenuItems().Count > count;
					if (flag5)
					{
						contextualMenuPopulateEvent.menu.InsertSeparator(null, count);
					}
				}
			}
		}

		// Token: 0x170006D4 RID: 1748
		// (get) Token: 0x06001D62 RID: 7522 RVA: 0x00072FF3 File Offset: 0x000711F3
		// (set) Token: 0x06001D63 RID: 7523 RVA: 0x00072FFB File Offset: 0x000711FB
		int ITextEdition.maxLength
		{
			get
			{
				return this.m_MaxLength;
			}
			set
			{
				this.m_MaxLength = value;
				this.text = this.edition.CullString(this.text);
			}
		}

		// Token: 0x170006D5 RID: 1749
		// (get) Token: 0x06001D64 RID: 7524 RVA: 0x0007301D File Offset: 0x0007121D
		// (set) Token: 0x06001D65 RID: 7525 RVA: 0x00073025 File Offset: 0x00071225
		bool ITextEdition.isDelayed { get; set; }

		// Token: 0x06001D66 RID: 7526 RVA: 0x00073030 File Offset: 0x00071230
		void ITextEdition.ResetValueAndText()
		{
			this.m_OriginalText = (this.text = null);
		}

		// Token: 0x06001D67 RID: 7527 RVA: 0x0007304F File Offset: 0x0007124F
		void ITextEdition.SaveValueAndText()
		{
			this.m_OriginalText = this.text;
		}

		// Token: 0x06001D68 RID: 7528 RVA: 0x0007305E File Offset: 0x0007125E
		void ITextEdition.RestoreValueAndText()
		{
			this.text = this.m_OriginalText;
		}

		// Token: 0x170006D6 RID: 1750
		// (get) Token: 0x06001D69 RID: 7529 RVA: 0x0007306E File Offset: 0x0007126E
		// (set) Token: 0x06001D6A RID: 7530 RVA: 0x00073076 File Offset: 0x00071276
		Func<char, bool> ITextEdition.AcceptCharacter { get; set; }

		// Token: 0x170006D7 RID: 1751
		// (get) Token: 0x06001D6B RID: 7531 RVA: 0x0007307F File Offset: 0x0007127F
		// (set) Token: 0x06001D6C RID: 7532 RVA: 0x00073087 File Offset: 0x00071287
		Action<bool> ITextEdition.UpdateScrollOffset { get; set; }

		// Token: 0x170006D8 RID: 1752
		// (get) Token: 0x06001D6D RID: 7533 RVA: 0x00073090 File Offset: 0x00071290
		// (set) Token: 0x06001D6E RID: 7534 RVA: 0x00073098 File Offset: 0x00071298
		Action ITextEdition.UpdateValueFromText { get; set; }

		// Token: 0x170006D9 RID: 1753
		// (get) Token: 0x06001D6F RID: 7535 RVA: 0x000730A1 File Offset: 0x000712A1
		// (set) Token: 0x06001D70 RID: 7536 RVA: 0x000730A9 File Offset: 0x000712A9
		Action ITextEdition.UpdateTextFromValue { get; set; }

		// Token: 0x170006DA RID: 1754
		// (get) Token: 0x06001D71 RID: 7537 RVA: 0x000730B2 File Offset: 0x000712B2
		// (set) Token: 0x06001D72 RID: 7538 RVA: 0x000730BA File Offset: 0x000712BA
		Action ITextEdition.MoveFocusToCompositeRoot { get; set; }

		// Token: 0x06001D73 RID: 7539 RVA: 0x000730C4 File Offset: 0x000712C4
		void ITextEdition.UpdateText(string value)
		{
			bool flag = this.m_TouchScreenKeyboard != null && this.m_TouchScreenKeyboard.text != value;
			if (flag)
			{
				this.m_TouchScreenKeyboard.text = value;
			}
			bool flag2 = this.text != value;
			if (flag2)
			{
				using (InputEvent pooled = InputEvent.GetPooled(this.text, value))
				{
					pooled.target = base.parent;
					((INotifyValueChanged<string>)this).SetValueWithoutNotify(value);
					VisualElement parent = base.parent;
					if (parent != null)
					{
						parent.SendEvent(pooled);
					}
				}
			}
		}

		// Token: 0x06001D74 RID: 7540 RVA: 0x00073168 File Offset: 0x00071368
		string ITextEdition.CullString(string s)
		{
			int maxLength = this.edition.maxLength;
			bool flag = maxLength >= 0 && s != null && s.Length > maxLength;
			string result;
			if (flag)
			{
				result = s.Substring(0, maxLength);
			}
			else
			{
				result = s;
			}
			return result;
		}

		// Token: 0x170006DB RID: 1755
		// (get) Token: 0x06001D75 RID: 7541 RVA: 0x000731A9 File Offset: 0x000713A9
		// (set) Token: 0x06001D76 RID: 7542 RVA: 0x000731B4 File Offset: 0x000713B4
		char ITextEdition.maskChar
		{
			get
			{
				return this.m_MaskChar;
			}
			set
			{
				bool flag = this.m_MaskChar != value;
				if (flag)
				{
					this.m_MaskChar = value;
					bool isPassword = this.edition.isPassword;
					if (isPassword)
					{
						base.IncrementVersion(VersionChangeType.Repaint);
					}
				}
			}
		}

		// Token: 0x170006DC RID: 1756
		// (get) Token: 0x06001D77 RID: 7543 RVA: 0x000731F8 File Offset: 0x000713F8
		private char effectiveMaskChar
		{
			get
			{
				return this.edition.isPassword ? this.m_MaskChar : '\0';
			}
		}

		// Token: 0x170006DD RID: 1757
		// (get) Token: 0x06001D78 RID: 7544 RVA: 0x00073210 File Offset: 0x00071410
		// (set) Token: 0x06001D79 RID: 7545 RVA: 0x00073218 File Offset: 0x00071418
		bool ITextEdition.isPassword
		{
			get
			{
				return this.m_IsPassword;
			}
			set
			{
				bool flag = this.m_IsPassword != value;
				if (flag)
				{
					this.m_IsPassword = value;
					base.IncrementVersion(VersionChangeType.Repaint);
				}
			}
		}

		// Token: 0x170006DE RID: 1758
		// (get) Token: 0x06001D7A RID: 7546 RVA: 0x0007324B File Offset: 0x0007144B
		// (set) Token: 0x06001D7B RID: 7547 RVA: 0x00073253 File Offset: 0x00071453
		bool ITextEdition.autoCorrection
		{
			get
			{
				return this.m_AutoCorrection;
			}
			set
			{
				this.m_AutoCorrection = value;
			}
		}

		// Token: 0x170006DF RID: 1759
		// (get) Token: 0x06001D7C RID: 7548 RVA: 0x0007325C File Offset: 0x0007145C
		// (set) Token: 0x06001D7D RID: 7549 RVA: 0x000732BF File Offset: 0x000714BF
		internal string renderedText
		{
			get
			{
				bool flag = this.effectiveMaskChar > '\0';
				string result;
				if (flag)
				{
					result = "".PadLeft(this.text.Length, this.effectiveMaskChar) + "​";
				}
				else
				{
					result = (string.IsNullOrEmpty(this.m_RenderedText) ? "​" : this.m_RenderedText);
				}
				return result;
			}
			set
			{
				this.m_RenderedText = value + "​";
			}
		}

		// Token: 0x170006E0 RID: 1760
		// (get) Token: 0x06001D7E RID: 7550 RVA: 0x000732D2 File Offset: 0x000714D2
		internal string originalText
		{
			get
			{
				return this.m_OriginalText;
			}
		}

		// Token: 0x170006E1 RID: 1761
		// (get) Token: 0x06001D7F RID: 7551 RVA: 0x0002DD41 File Offset: 0x0002BF41
		public new ITextElementExperimentalFeatures experimental
		{
			get
			{
				return this;
			}
		}

		// Token: 0x06001D80 RID: 7552 RVA: 0x000732DA File Offset: 0x000714DA
		void ITextElementExperimentalFeatures.SetRenderedText(string renderedText)
		{
			this.renderedText = renderedText;
		}

		// Token: 0x170006E2 RID: 1762
		// (get) Token: 0x06001D81 RID: 7553 RVA: 0x0002DD41 File Offset: 0x0002BF41
		public ITextSelection selection
		{
			get
			{
				return this;
			}
		}

		// Token: 0x170006E3 RID: 1763
		// (get) Token: 0x06001D82 RID: 7554 RVA: 0x000732E5 File Offset: 0x000714E5
		// (set) Token: 0x06001D83 RID: 7555 RVA: 0x000732F8 File Offset: 0x000714F8
		bool ITextSelection.isSelectable
		{
			get
			{
				return this.m_IsSelectable && base.focusable;
			}
			set
			{
				bool flag = value == this.m_IsSelectable;
				if (!flag)
				{
					base.focusable = value;
					this.m_IsSelectable = value;
				}
			}
		}

		// Token: 0x170006E4 RID: 1764
		// (get) Token: 0x06001D84 RID: 7556 RVA: 0x00073324 File Offset: 0x00071524
		// (set) Token: 0x06001D85 RID: 7557 RVA: 0x00073344 File Offset: 0x00071544
		int ITextSelection.cursorIndex
		{
			get
			{
				return this.selection.isSelectable ? this.selectingManipulator.cursorIndex : -1;
			}
			set
			{
				bool isSelectable = this.selection.isSelectable;
				if (isSelectable)
				{
					this.selectingManipulator.cursorIndex = value;
				}
			}
		}

		// Token: 0x170006E5 RID: 1765
		// (get) Token: 0x06001D86 RID: 7558 RVA: 0x0007336E File Offset: 0x0007156E
		// (set) Token: 0x06001D87 RID: 7559 RVA: 0x0007338C File Offset: 0x0007158C
		int ITextSelection.selectIndex
		{
			get
			{
				return this.selection.isSelectable ? this.selectingManipulator.selectIndex : -1;
			}
			set
			{
				bool isSelectable = this.selection.isSelectable;
				if (isSelectable)
				{
					this.selectingManipulator.selectIndex = value;
				}
			}
		}

		// Token: 0x06001D88 RID: 7560 RVA: 0x000733B8 File Offset: 0x000715B8
		void ITextSelection.SelectAll()
		{
			bool isSelectable = this.selection.isSelectable;
			if (isSelectable)
			{
				this.selectingManipulator.m_SelectingUtilities.SelectAll();
			}
		}

		// Token: 0x06001D89 RID: 7561 RVA: 0x000733E8 File Offset: 0x000715E8
		void ITextSelection.SelectNone()
		{
			bool isSelectable = this.selection.isSelectable;
			if (isSelectable)
			{
				this.selectingManipulator.m_SelectingUtilities.SelectNone();
			}
		}

		// Token: 0x06001D8A RID: 7562 RVA: 0x00073418 File Offset: 0x00071618
		void ITextSelection.SelectRange(int cursorIndex, int selectionIndex)
		{
			bool isSelectable = this.selection.isSelectable;
			if (isSelectable)
			{
				this.selectingManipulator.m_SelectingUtilities.cursorIndex = cursorIndex;
				this.selectingManipulator.m_SelectingUtilities.selectIndex = selectionIndex;
			}
		}

		// Token: 0x06001D8B RID: 7563 RVA: 0x0007345C File Offset: 0x0007165C
		bool ITextSelection.HasSelection()
		{
			return this.selection.isSelectable && this.selectingManipulator.HasSelection();
		}

		// Token: 0x170006E6 RID: 1766
		// (get) Token: 0x06001D8C RID: 7564 RVA: 0x00073489 File Offset: 0x00071689
		// (set) Token: 0x06001D8D RID: 7565 RVA: 0x00073491 File Offset: 0x00071691
		bool ITextSelection.doubleClickSelectsWord { get; set; } = true;

		// Token: 0x170006E7 RID: 1767
		// (get) Token: 0x06001D8E RID: 7566 RVA: 0x0007349A File Offset: 0x0007169A
		// (set) Token: 0x06001D8F RID: 7567 RVA: 0x000734A2 File Offset: 0x000716A2
		bool ITextSelection.tripleClickSelectsLine { get; set; } = true;

		// Token: 0x170006E8 RID: 1768
		// (get) Token: 0x06001D90 RID: 7568 RVA: 0x000734AB File Offset: 0x000716AB
		// (set) Token: 0x06001D91 RID: 7569 RVA: 0x000734B3 File Offset: 0x000716B3
		bool ITextSelection.selectAllOnFocus { get; set; } = false;

		// Token: 0x170006E9 RID: 1769
		// (get) Token: 0x06001D92 RID: 7570 RVA: 0x000734BC File Offset: 0x000716BC
		// (set) Token: 0x06001D93 RID: 7571 RVA: 0x000734C4 File Offset: 0x000716C4
		bool ITextSelection.selectAllOnMouseUp { get; set; } = false;

		// Token: 0x170006EA RID: 1770
		// (get) Token: 0x06001D94 RID: 7572 RVA: 0x000734D0 File Offset: 0x000716D0
		Vector2 ITextSelection.cursorPosition
		{
			get
			{
				return this.uitkTextHandle.GetCursorPositionFromStringIndexUsingLineHeight(this.selection.cursorIndex, false, true) + base.contentRect.min;
			}
		}

		// Token: 0x170006EB RID: 1771
		// (get) Token: 0x06001D95 RID: 7573 RVA: 0x00073508 File Offset: 0x00071708
		float ITextSelection.lineHeightAtCursorPosition
		{
			get
			{
				return this.uitkTextHandle.GetLineHeightFromCharacterIndex(this.selection.cursorIndex);
			}
		}

		// Token: 0x06001D96 RID: 7574 RVA: 0x00073520 File Offset: 0x00071720
		void ITextSelection.MoveTextEnd()
		{
			bool isSelectable = this.selection.isSelectable;
			if (isSelectable)
			{
				this.selectingManipulator.m_SelectingUtilities.MoveTextEnd();
			}
		}

		// Token: 0x170006EC RID: 1772
		// (get) Token: 0x06001D97 RID: 7575 RVA: 0x0007354E File Offset: 0x0007174E
		// (set) Token: 0x06001D98 RID: 7576 RVA: 0x00073558 File Offset: 0x00071758
		Color ITextSelection.selectionColor
		{
			get
			{
				return this.m_SelectionColor;
			}
			set
			{
				bool flag = this.m_SelectionColor == value;
				if (!flag)
				{
					this.m_SelectionColor = value;
					base.MarkDirtyRepaint();
				}
			}
		}

		// Token: 0x170006ED RID: 1773
		// (get) Token: 0x06001D99 RID: 7577 RVA: 0x00073586 File Offset: 0x00071786
		// (set) Token: 0x06001D9A RID: 7578 RVA: 0x00073590 File Offset: 0x00071790
		Color ITextSelection.cursorColor
		{
			get
			{
				return this.m_CursorColor;
			}
			set
			{
				bool flag = this.m_CursorColor == value;
				if (!flag)
				{
					this.m_CursorColor = value;
					base.MarkDirtyRepaint();
				}
			}
		}

		// Token: 0x170006EE RID: 1774
		// (get) Token: 0x06001D9B RID: 7579 RVA: 0x000735BE File Offset: 0x000717BE
		// (set) Token: 0x06001D9C RID: 7580 RVA: 0x000735CB File Offset: 0x000717CB
		private Color cursorColor
		{
			get
			{
				return this.selection.cursorColor;
			}
			set
			{
				this.selection.cursorColor = value;
			}
		}

		// Token: 0x170006EF RID: 1775
		// (get) Token: 0x06001D9D RID: 7581 RVA: 0x000735DA File Offset: 0x000717DA
		// (set) Token: 0x06001D9E RID: 7582 RVA: 0x000735E4 File Offset: 0x000717E4
		float ITextSelection.cursorWidth
		{
			get
			{
				return this.m_CursorWidth;
			}
			set
			{
				bool flag = Mathf.Approximately(this.m_CursorWidth, value);
				if (!flag)
				{
					this.m_CursorWidth = value;
					base.MarkDirtyRepaint();
				}
			}
		}

		// Token: 0x170006F0 RID: 1776
		// (get) Token: 0x06001D9F RID: 7583 RVA: 0x00073614 File Offset: 0x00071814
		internal TextSelectingManipulator selectingManipulator
		{
			get
			{
				TextSelectingManipulator result;
				if ((result = this.m_SelectingManipulator) == null)
				{
					result = (this.m_SelectingManipulator = new TextSelectingManipulator(this));
				}
				return result;
			}
		}

		// Token: 0x06001DA0 RID: 7584 RVA: 0x0007363C File Offset: 0x0007183C
		private void DrawHighlighting(MeshGenerationContext mgc)
		{
			Color playmodeTintColor = (base.panel.contextType == ContextType.Editor) ? UIElementsUtility.editorPlayModeTintColor : Color.white;
			int index = Math.Min(this.selection.cursorIndex, this.selection.selectIndex);
			int index2 = Math.Max(this.selection.cursorIndex, this.selection.selectIndex);
			Vector2 vector = this.uitkTextHandle.GetCursorPositionFromStringIndexUsingLineHeight(index, false, true);
			Vector2 vector2 = this.uitkTextHandle.GetCursorPositionFromStringIndexUsingLineHeight(index2, false, true);
			int lineNumber = this.uitkTextHandle.GetLineNumber(index);
			int lineNumber2 = this.uitkTextHandle.GetLineNumber(index2);
			float lineHeight = this.uitkTextHandle.GetLineHeight(lineNumber);
			Vector2 min = base.contentRect.min;
			bool flag = this.m_TouchScreenKeyboard != null && this.m_HideMobileInput;
			if (flag)
			{
				TextInfo textInfo = this.uitkTextHandle.textInfo;
				int num = (this.selection.selectIndex < this.selection.cursorIndex) ? textInfo.textElementInfo[this.selection.selectIndex].index : textInfo.textElementInfo[this.selection.cursorIndex].index;
				int length = (this.selection.selectIndex < this.selection.cursorIndex) ? (this.selection.cursorIndex - num) : (this.selection.selectIndex - num);
				this.m_TouchScreenKeyboard.selection = new RangeInt(num, length);
			}
			bool flag2 = lineNumber == lineNumber2;
			if (flag2)
			{
				vector += min;
				vector2 += min;
				mgc.Rectangle(new MeshGenerationContextUtils.RectangleParams
				{
					rect = new Rect(vector.x, vector.y - lineHeight, vector2.x - vector.x, lineHeight),
					color = this.selection.selectionColor,
					playmodeTintColor = playmodeTintColor
				});
			}
			else
			{
				for (int i = lineNumber; i <= lineNumber2; i++)
				{
					bool flag3 = i == lineNumber;
					if (flag3)
					{
						int lastCharacterAt = this.GetLastCharacterAt(i);
						vector2 = this.uitkTextHandle.GetCursorPositionFromStringIndexUsingLineHeight(lastCharacterAt, true, true);
					}
					else
					{
						bool flag4 = i == lineNumber2;
						if (flag4)
						{
							int firstCharacterIndex = this.uitkTextHandle.textInfo.lineInfo[i].firstCharacterIndex;
							vector = this.uitkTextHandle.GetCursorPositionFromStringIndexUsingLineHeight(firstCharacterIndex, false, true);
							vector2 = this.uitkTextHandle.GetCursorPositionFromStringIndexUsingLineHeight(index2, true, true);
						}
						else
						{
							bool flag5 = i != lineNumber && i != lineNumber2;
							if (flag5)
							{
								int firstCharacterIndex = this.uitkTextHandle.textInfo.lineInfo[i].firstCharacterIndex;
								vector = this.uitkTextHandle.GetCursorPositionFromStringIndexUsingLineHeight(firstCharacterIndex, false, true);
								int lastCharacterAt = this.GetLastCharacterAt(i);
								vector2 = this.uitkTextHandle.GetCursorPositionFromStringIndexUsingLineHeight(lastCharacterAt, true, true);
							}
						}
					}
					vector += min;
					vector2 += min;
					mgc.Rectangle(new MeshGenerationContextUtils.RectangleParams
					{
						rect = new Rect(vector.x, vector.y - lineHeight, vector2.x - vector.x, lineHeight),
						color = this.selection.selectionColor,
						playmodeTintColor = playmodeTintColor
					});
				}
			}
		}

		// Token: 0x06001DA1 RID: 7585 RVA: 0x000739B0 File Offset: 0x00071BB0
		internal void DrawCaret(MeshGenerationContext mgc)
		{
			Color playmodeTintColor = (base.panel.contextType == ContextType.Editor) ? UIElementsUtility.editorPlayModeTintColor : Color.white;
			float characterHeightFromIndex = this.uitkTextHandle.GetCharacterHeightFromIndex(this.selection.cursorIndex);
			float width = AlignmentUtils.CeilToPixelGrid(this.selection.cursorWidth, base.scaledPixelsPerPoint, -0.02f);
			mgc.Rectangle(new MeshGenerationContextUtils.RectangleParams
			{
				rect = new Rect(this.selection.cursorPosition.x, this.selection.cursorPosition.y - characterHeightFromIndex, width, characterHeightFromIndex),
				color = this.selection.cursorColor,
				playmodeTintColor = playmodeTintColor
			});
		}

		// Token: 0x06001DA2 RID: 7586 RVA: 0x00073A68 File Offset: 0x00071C68
		private int GetLastCharacterAt(int lineIndex)
		{
			int num = this.uitkTextHandle.textInfo.lineInfo[lineIndex].lastCharacterIndex;
			int firstCharacterIndex = this.uitkTextHandle.textInfo.lineInfo[lineIndex].firstCharacterIndex;
			TextElementInfo textElementInfo = this.uitkTextHandle.textInfo.textElementInfo[num];
			while (textElementInfo.character == '\n' || textElementInfo.character == '\r')
			{
				bool flag = num > firstCharacterIndex;
				if (!flag)
				{
					break;
				}
				num--;
				textElementInfo = this.uitkTextHandle.textInfo.textElementInfo[num];
			}
			return num;
		}

		// Token: 0x04000C4E RID: 3150
		public static readonly string ussClassName = "unity-text-element";

		// Token: 0x04000C50 RID: 3152
		private string m_Text = string.Empty;

		// Token: 0x04000C51 RID: 3153
		private bool m_EnableRichText = true;

		// Token: 0x04000C52 RID: 3154
		private bool m_ParseEscapeSequences = true;

		// Token: 0x04000C53 RID: 3155
		private bool m_DisplayTooltipWhenElided = true;

		// Token: 0x04000C55 RID: 3157
		internal static readonly string k_EllipsisText = "...";

		// Token: 0x04000C56 RID: 3158
		internal string elidedText;

		// Token: 0x04000C57 RID: 3159
		private bool m_WasElided;

		// Token: 0x04000C58 RID: 3160
		internal TextEditingManipulator editingManipulator;

		// Token: 0x04000C59 RID: 3161
		private bool m_Multiline;

		// Token: 0x04000C5A RID: 3162
		internal TouchScreenKeyboard m_TouchScreenKeyboard;

		// Token: 0x04000C5B RID: 3163
		internal TouchScreenKeyboardType m_KeyboardType = TouchScreenKeyboardType.Default;

		// Token: 0x04000C5C RID: 3164
		private bool m_HideMobileInput;

		// Token: 0x04000C5D RID: 3165
		private bool m_IsReadOnly = true;

		// Token: 0x04000C5E RID: 3166
		private int m_MaxLength = -1;

		// Token: 0x04000C65 RID: 3173
		private string m_RenderedText;

		// Token: 0x04000C66 RID: 3174
		private string m_OriginalText;

		// Token: 0x04000C67 RID: 3175
		private char m_MaskChar;

		// Token: 0x04000C68 RID: 3176
		private bool m_IsPassword;

		// Token: 0x04000C69 RID: 3177
		private bool m_AutoCorrection;

		// Token: 0x04000C6A RID: 3178
		private TextSelectingManipulator m_SelectingManipulator;

		// Token: 0x04000C6B RID: 3179
		private bool m_IsSelectable;

		// Token: 0x04000C70 RID: 3184
		private Color m_SelectionColor = new Color(0.239f, 0.502f, 0.875f, 0.65f);

		// Token: 0x04000C71 RID: 3185
		private Color m_CursorColor = new Color(0.706f, 0.706f, 0.706f, 1f);

		// Token: 0x04000C72 RID: 3186
		private float m_CursorWidth = 1f;

		// Token: 0x02000370 RID: 880
		public new class UxmlFactory : UxmlFactory<TextElement, TextElement.UxmlTraits>
		{
		}

		// Token: 0x02000371 RID: 881
		public new class UxmlTraits : BindableElement.UxmlTraits
		{
			// Token: 0x170006F1 RID: 1777
			// (get) Token: 0x06001DA5 RID: 7589 RVA: 0x00073B38 File Offset: 0x00071D38
			public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
			{
				get
				{
					yield break;
				}
			}

			// Token: 0x06001DA6 RID: 7590 RVA: 0x00073B58 File Offset: 0x00071D58
			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				base.Init(ve, bag, cc);
				TextElement textElement = (TextElement)ve;
				textElement.text = this.m_Text.GetValueFromBag(bag, cc);
				textElement.enableRichText = this.m_EnableRichText.GetValueFromBag(bag, cc);
				textElement.parseEscapeSequences = this.m_ParseEscapeSequences.GetValueFromBag(bag, cc);
				textElement.displayTooltipWhenElided = this.m_DisplayTooltipWhenElided.GetValueFromBag(bag, cc);
			}

			// Token: 0x04000C73 RID: 3187
			private UxmlStringAttributeDescription m_Text = new UxmlStringAttributeDescription
			{
				name = "text"
			};

			// Token: 0x04000C74 RID: 3188
			private UxmlBoolAttributeDescription m_EnableRichText = new UxmlBoolAttributeDescription
			{
				name = "enable-rich-text",
				defaultValue = true
			};

			// Token: 0x04000C75 RID: 3189
			private UxmlBoolAttributeDescription m_ParseEscapeSequences = new UxmlBoolAttributeDescription
			{
				name = "parse-escape-sequences",
				defaultValue = false
			};

			// Token: 0x04000C76 RID: 3190
			private UxmlBoolAttributeDescription m_DisplayTooltipWhenElided = new UxmlBoolAttributeDescription
			{
				name = "display-tooltip-when-elided"
			};
		}
	}
}
