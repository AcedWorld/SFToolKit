using System;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x0200013C RID: 316
	public class DebugUIHandlerVector3 : DebugUIHandlerWidget
	{
		// Token: 0x06000967 RID: 2407 RVA: 0x0002AF44 File Offset: 0x00029144
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			this.m_Field = base.CastWidget<DebugUI.Vector3Field>();
			this.m_Container = base.GetComponent<DebugUIHandlerContainer>();
			this.nameLabel.text = this.m_Field.displayName;
			this.fieldX.getter = (() => this.m_Field.GetValue().x);
			this.fieldX.setter = delegate(float v)
			{
				this.SetValue(v, true, false, false);
			};
			this.fieldX.nextUIHandler = this.fieldY;
			this.SetupSettings(this.fieldX);
			this.fieldY.getter = (() => this.m_Field.GetValue().y);
			this.fieldY.setter = delegate(float v)
			{
				this.SetValue(v, false, true, false);
			};
			this.fieldY.previousUIHandler = this.fieldX;
			this.fieldY.nextUIHandler = this.fieldZ;
			this.SetupSettings(this.fieldY);
			this.fieldZ.getter = (() => this.m_Field.GetValue().z);
			this.fieldZ.setter = delegate(float v)
			{
				this.SetValue(v, false, false, true);
			};
			this.fieldZ.previousUIHandler = this.fieldY;
			this.SetupSettings(this.fieldZ);
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x0002B078 File Offset: 0x00029278
		private void SetValue(float v, bool x = false, bool y = false, bool z = false)
		{
			Vector3 value = this.m_Field.GetValue();
			if (x)
			{
				value.x = v;
			}
			if (y)
			{
				value.y = v;
			}
			if (z)
			{
				value.z = v;
			}
			this.m_Field.SetValue(value);
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x0002B0C0 File Offset: 0x000292C0
		private void SetupSettings(DebugUIHandlerIndirectFloatField field)
		{
			field.parentUIHandler = this;
			field.incStepGetter = (() => this.m_Field.incStep);
			field.incStepMultGetter = (() => this.m_Field.incStepMult);
			field.decimalsGetter = (() => (float)this.m_Field.decimals);
			field.Init();
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x0002B110 File Offset: 0x00029310
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

		// Token: 0x0600096B RID: 2411 RVA: 0x0002B187 File Offset: 0x00029387
		public override void OnDeselection()
		{
			this.nameLabel.color = this.colorDefault;
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x0002B19A File Offset: 0x0002939A
		public override void OnIncrement(bool fast)
		{
			this.valueToggle.isOn = true;
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x0002B1A8 File Offset: 0x000293A8
		public override void OnDecrement(bool fast)
		{
			this.valueToggle.isOn = false;
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x0002B1B6 File Offset: 0x000293B6
		public override void OnAction()
		{
			this.valueToggle.isOn = !this.valueToggle.isOn;
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x0002B1D4 File Offset: 0x000293D4
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

		// Token: 0x04000580 RID: 1408
		public Text nameLabel;

		// Token: 0x04000581 RID: 1409
		public UIFoldout valueToggle;

		// Token: 0x04000582 RID: 1410
		public DebugUIHandlerIndirectFloatField fieldX;

		// Token: 0x04000583 RID: 1411
		public DebugUIHandlerIndirectFloatField fieldY;

		// Token: 0x04000584 RID: 1412
		public DebugUIHandlerIndirectFloatField fieldZ;

		// Token: 0x04000585 RID: 1413
		private DebugUI.Vector3Field m_Field;

		// Token: 0x04000586 RID: 1414
		private DebugUIHandlerContainer m_Container;
	}
}
