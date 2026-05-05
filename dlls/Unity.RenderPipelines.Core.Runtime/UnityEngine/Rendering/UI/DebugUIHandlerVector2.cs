using System;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x0200013B RID: 315
	public class DebugUIHandlerVector2 : DebugUIHandlerWidget
	{
		// Token: 0x06000956 RID: 2390 RVA: 0x0002AC64 File Offset: 0x00028E64
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			this.m_Field = base.CastWidget<DebugUI.Vector2Field>();
			this.m_Container = base.GetComponent<DebugUIHandlerContainer>();
			this.nameLabel.text = this.m_Field.displayName;
			this.fieldX.getter = (() => this.m_Field.GetValue().x);
			this.fieldX.setter = delegate(float x)
			{
				this.SetValue(x, true, false);
			};
			this.fieldX.nextUIHandler = this.fieldY;
			this.SetupSettings(this.fieldX);
			this.fieldY.getter = (() => this.m_Field.GetValue().y);
			this.fieldY.setter = delegate(float x)
			{
				this.SetValue(x, false, true);
			};
			this.fieldY.previousUIHandler = this.fieldX;
			this.SetupSettings(this.fieldY);
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x0002AD3C File Offset: 0x00028F3C
		private void SetValue(float v, bool x = false, bool y = false)
		{
			Vector2 value = this.m_Field.GetValue();
			if (x)
			{
				value.x = v;
			}
			if (y)
			{
				value.y = v;
			}
			this.m_Field.SetValue(value);
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x0002AD78 File Offset: 0x00028F78
		private void SetupSettings(DebugUIHandlerIndirectFloatField field)
		{
			field.parentUIHandler = this;
			field.incStepGetter = (() => this.m_Field.incStep);
			field.incStepMultGetter = (() => this.m_Field.incStepMult);
			field.decimalsGetter = (() => (float)this.m_Field.decimals);
			field.Init();
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0002ADC8 File Offset: 0x00028FC8
		public override bool OnSelection(bool fromNext, DebugUIHandlerWidget previous)
		{
			if (fromNext || !this.valueToggle.isOn)
			{
				this.nameLabel.color = this.colorSelected;
			}
			else if (this.valueToggle.isOn)
			{
				if (this.m_Container.IsDirectChild(previous))
				{
					this.nameLabel.color = this.colorSelected;
				}
				else
				{
					DebugUIHandlerWidget lastItem = this.m_Container.GetLastItem();
					DebugManager.instance.ChangeSelection(lastItem, false);
				}
			}
			return true;
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0002AE3F File Offset: 0x0002903F
		public override void OnDeselection()
		{
			this.nameLabel.color = this.colorDefault;
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0002AE52 File Offset: 0x00029052
		public override void OnIncrement(bool fast)
		{
			this.valueToggle.isOn = true;
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0002AE60 File Offset: 0x00029060
		public override void OnDecrement(bool fast)
		{
			this.valueToggle.isOn = false;
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0002AE6E File Offset: 0x0002906E
		public override void OnAction()
		{
			this.valueToggle.isOn = !this.valueToggle.isOn;
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x0002AE8C File Offset: 0x0002908C
		public override DebugUIHandlerWidget Next()
		{
			if (!this.valueToggle.isOn || this.m_Container == null)
			{
				return base.Next();
			}
			DebugUIHandlerWidget firstItem = this.m_Container.GetFirstItem();
			if (firstItem == null)
			{
				return base.Next();
			}
			return firstItem;
		}

		// Token: 0x0400057A RID: 1402
		public Text nameLabel;

		// Token: 0x0400057B RID: 1403
		public UIFoldout valueToggle;

		// Token: 0x0400057C RID: 1404
		public DebugUIHandlerIndirectFloatField fieldX;

		// Token: 0x0400057D RID: 1405
		public DebugUIHandlerIndirectFloatField fieldY;

		// Token: 0x0400057E RID: 1406
		private DebugUI.Vector2Field m_Field;

		// Token: 0x0400057F RID: 1407
		private DebugUIHandlerContainer m_Container;
	}
}
