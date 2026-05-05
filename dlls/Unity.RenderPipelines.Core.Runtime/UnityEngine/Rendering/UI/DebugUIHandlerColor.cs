using System;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x02000121 RID: 289
	public class DebugUIHandlerColor : DebugUIHandlerWidget
	{
		// Token: 0x060008A5 RID: 2213 RVA: 0x00028630 File Offset: 0x00026830
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			this.m_Field = base.CastWidget<DebugUI.ColorField>();
			this.m_Container = base.GetComponent<DebugUIHandlerContainer>();
			this.nameLabel.text = this.m_Field.displayName;
			this.fieldR.getter = (() => this.m_Field.GetValue().r);
			this.fieldR.setter = delegate(float x)
			{
				this.SetValue(x, true, false, false, false);
			};
			this.fieldR.nextUIHandler = this.fieldG;
			this.SetupSettings(this.fieldR);
			this.fieldG.getter = (() => this.m_Field.GetValue().g);
			this.fieldG.setter = delegate(float x)
			{
				this.SetValue(x, false, true, false, false);
			};
			this.fieldG.previousUIHandler = this.fieldR;
			this.fieldG.nextUIHandler = this.fieldB;
			this.SetupSettings(this.fieldG);
			this.fieldB.getter = (() => this.m_Field.GetValue().b);
			this.fieldB.setter = delegate(float x)
			{
				this.SetValue(x, false, false, true, false);
			};
			this.fieldB.previousUIHandler = this.fieldG;
			this.fieldB.nextUIHandler = (this.m_Field.showAlpha ? this.fieldA : null);
			this.SetupSettings(this.fieldB);
			this.fieldA.gameObject.SetActive(this.m_Field.showAlpha);
			this.fieldA.getter = (() => this.m_Field.GetValue().a);
			this.fieldA.setter = delegate(float x)
			{
				this.SetValue(x, false, false, false, true);
			};
			this.fieldA.previousUIHandler = this.fieldB;
			this.SetupSettings(this.fieldA);
			this.UpdateColor();
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x000287F4 File Offset: 0x000269F4
		private void SetValue(float x, bool r = false, bool g = false, bool b = false, bool a = false)
		{
			Color value = this.m_Field.GetValue();
			if (r)
			{
				value.r = x;
			}
			if (g)
			{
				value.g = x;
			}
			if (b)
			{
				value.b = x;
			}
			if (a)
			{
				value.a = x;
			}
			this.m_Field.SetValue(value);
			this.UpdateColor();
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x00028850 File Offset: 0x00026A50
		private void SetupSettings(DebugUIHandlerIndirectFloatField field)
		{
			field.parentUIHandler = this;
			field.incStepGetter = (() => this.m_Field.incStep);
			field.incStepMultGetter = (() => this.m_Field.incStepMult);
			field.decimalsGetter = (() => (float)this.m_Field.decimals);
			field.Init();
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x000288A0 File Offset: 0x00026AA0
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

		// Token: 0x060008A9 RID: 2217 RVA: 0x00028917 File Offset: 0x00026B17
		public override void OnDeselection()
		{
			this.nameLabel.color = this.colorDefault;
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x0002892A File Offset: 0x00026B2A
		public override void OnIncrement(bool fast)
		{
			this.valueToggle.isOn = true;
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x00028938 File Offset: 0x00026B38
		public override void OnDecrement(bool fast)
		{
			this.valueToggle.isOn = false;
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x00028946 File Offset: 0x00026B46
		public override void OnAction()
		{
			this.valueToggle.isOn = !this.valueToggle.isOn;
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x00028961 File Offset: 0x00026B61
		internal void UpdateColor()
		{
			if (this.colorImage != null)
			{
				this.colorImage.color = this.m_Field.GetValue();
			}
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x00028988 File Offset: 0x00026B88
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

		// Token: 0x04000518 RID: 1304
		public Text nameLabel;

		// Token: 0x04000519 RID: 1305
		public UIFoldout valueToggle;

		// Token: 0x0400051A RID: 1306
		public Image colorImage;

		// Token: 0x0400051B RID: 1307
		public DebugUIHandlerIndirectFloatField fieldR;

		// Token: 0x0400051C RID: 1308
		public DebugUIHandlerIndirectFloatField fieldG;

		// Token: 0x0400051D RID: 1309
		public DebugUIHandlerIndirectFloatField fieldB;

		// Token: 0x0400051E RID: 1310
		public DebugUIHandlerIndirectFloatField fieldA;

		// Token: 0x0400051F RID: 1311
		private DebugUI.ColorField m_Field;

		// Token: 0x04000520 RID: 1312
		private DebugUIHandlerContainer m_Container;
	}
}
