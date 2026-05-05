using System;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x0200012A RID: 298
	public class DebugUIHandlerIndirectFloatField : DebugUIHandlerWidget
	{
		// Token: 0x060008E8 RID: 2280 RVA: 0x000295F3 File Offset: 0x000277F3
		public void Init()
		{
			this.UpdateValueLabel();
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x000295FB File Offset: 0x000277FB
		public override bool OnSelection(bool fromNext, DebugUIHandlerWidget previous)
		{
			this.nameLabel.color = this.colorSelected;
			this.valueLabel.color = this.colorSelected;
			return true;
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x00029620 File Offset: 0x00027820
		public override void OnDeselection()
		{
			this.nameLabel.color = this.colorDefault;
			this.valueLabel.color = this.colorDefault;
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x00029644 File Offset: 0x00027844
		public override void OnIncrement(bool fast)
		{
			this.ChangeValue(fast, 1f);
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x00029652 File Offset: 0x00027852
		public override void OnDecrement(bool fast)
		{
			this.ChangeValue(fast, -1f);
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x00029660 File Offset: 0x00027860
		private void ChangeValue(bool fast, float multiplier)
		{
			float num = this.getter();
			num += this.incStepGetter() * (fast ? this.incStepMultGetter() : 1f) * multiplier;
			this.setter(num);
			this.UpdateValueLabel();
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x000296B4 File Offset: 0x000278B4
		private void UpdateValueLabel()
		{
			if (this.valueLabel != null)
			{
				this.valueLabel.text = this.getter().ToString("N" + this.decimalsGetter().ToString());
			}
		}

		// Token: 0x04000537 RID: 1335
		public Text nameLabel;

		// Token: 0x04000538 RID: 1336
		public Text valueLabel;

		// Token: 0x04000539 RID: 1337
		public Func<float> getter;

		// Token: 0x0400053A RID: 1338
		public Action<float> setter;

		// Token: 0x0400053B RID: 1339
		public Func<float> incStepGetter;

		// Token: 0x0400053C RID: 1340
		public Func<float> incStepMultGetter;

		// Token: 0x0400053D RID: 1341
		public Func<float> decimalsGetter;
	}
}
