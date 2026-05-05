using System;
using Rewired.ComponentControls.Data;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	// Token: 0x020003E0 RID: 992
	[DisallowMultipleComponent]
	[Serializable]
	public abstract class CustomControllerControl : ComponentControl
	{
		// Token: 0x17000957 RID: 2391
		// (get) Token: 0x060027C7 RID: 10183 RVA: 0x0001DC67 File Offset: 0x0001BE67
		internal CustomController WoSgDjfaOkuapKqTxSyHHZPJULte
		{
			get
			{
				return base.rzibFgeNisiPtdkXZKqxOinxAYdp() as CustomController;
			}
		}

		// Token: 0x060027C8 RID: 10184 RVA: 0x0001DC74 File Offset: 0x0001BE74
		[CustomObfuscation(rename = false)]
		internal CustomControllerControl()
		{
		}

		// Token: 0x17000958 RID: 2392
		// (get) Token: 0x060027C9 RID: 10185 RVA: 0x0001DC7C File Offset: 0x0001BE7C
		internal override bool sDyfdeIGxyTDdSPFEMsLcAADnlbVB
		{
			get
			{
				return base.rzibFgeNisiPtdkXZKqxOinxAYdp() as CustomController != null;
			}
		}

		// Token: 0x060027CA RID: 10186 RVA: 0x0001DC8F File Offset: 0x0001BE8F
		internal virtual void SsfxZPZhDDtylHZYnTMQyawFtfbC()
		{
			base.INuthIKcEuhqoHwVvPwrfQAYzEbmA();
			if (!this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
			{
				return;
			}
			this.cNZWoxfKivbErakyPToildyvcWAkA();
			this.WoSgDjfaOkuapKqTxSyHHZPJULte.InputSourceUpdateEvent += this.yNQgzmaiOQyYqcxPGBHndZYcamYOA;
		}

		// Token: 0x060027CB RID: 10187 RVA: 0x0001DCBD File Offset: 0x0001BEBD
		internal virtual void dDJGenyHMNqOIuUSedhLaBWSdtrkA()
		{
			base.cNZWoxfKivbErakyPToildyvcWAkA();
			if (!this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
			{
				return;
			}
			this.WoSgDjfaOkuapKqTxSyHHZPJULte.InputSourceUpdateEvent -= this.yNQgzmaiOQyYqcxPGBHndZYcamYOA;
		}

		// Token: 0x060027CC RID: 10188 RVA: 0x0001DCE5 File Offset: 0x0001BEE5
		[CustomObfuscation(rename = false)]
		internal override IComponentController FindController()
		{
			return UnityTools.GetComponentInSelfOrParents<CustomController>(base.transform);
		}

		// Token: 0x060027CD RID: 10189 RVA: 0x0001DCF2 File Offset: 0x0001BEF2
		[CustomObfuscation(rename = false)]
		internal override Type GetRequiredControllerType()
		{
			return typeof(CustomController);
		}

		// Token: 0x060027CE RID: 10190 RVA: 0x00096098 File Offset: 0x00094298
		internal void WiKtlIjluObCctWuxDsizpItcifHA(CustomControllerElementTargetSet A_1, float A_2, float A_3)
		{
			if (!this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
			{
				return;
			}
			if (A_1 == null)
			{
				return;
			}
			CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat = A_1 as CustomControllerElementTargetSetForFloat;
			if (customControllerElementTargetSetForFloat != null)
			{
				if (!customControllerElementTargetSetForFloat.splitValue)
				{
					this.PWmLYvndNHvDBTyGJhqHxFTzsJeT(customControllerElementTargetSetForFloat.target, A_2, A_3);
					return;
				}
				this.PWmLYvndNHvDBTyGJhqHxFTzsJeT(customControllerElementTargetSetForFloat.positiveTarget, A_2, A_3);
				this.PWmLYvndNHvDBTyGJhqHxFTzsJeT(customControllerElementTargetSetForFloat.negativeTarget, A_2, A_3);
				return;
			}
			else
			{
				CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean = A_1 as CustomControllerElementTargetSetForBoolean;
				if (customControllerElementTargetSetForBoolean != null)
				{
					this.PWmLYvndNHvDBTyGJhqHxFTzsJeT(customControllerElementTargetSetForBoolean.target, A_2, A_3);
					return;
				}
				return;
			}
		}

		// Token: 0x060027CF RID: 10191 RVA: 0x0009610C File Offset: 0x0009430C
		internal void wxsDJwhBGhAlFpbeoLzNoYvIriVe(CustomControllerElementTargetSet A_1, bool A_2)
		{
			if (!this.sDyfdeIGxyTDdSPFEMsLcAADnlbVB)
			{
				return;
			}
			if (A_1 == null)
			{
				return;
			}
			CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean = A_1 as CustomControllerElementTargetSetForBoolean;
			if (customControllerElementTargetSetForBoolean != null)
			{
				this.XqsaWGEGmOwUClTAwWBEdpXuabnOA(customControllerElementTargetSetForBoolean.target, A_2);
				return;
			}
			CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat = A_1 as CustomControllerElementTargetSetForFloat;
			if (customControllerElementTargetSetForFloat == null)
			{
				return;
			}
			if (!customControllerElementTargetSetForFloat.splitValue)
			{
				this.XqsaWGEGmOwUClTAwWBEdpXuabnOA(customControllerElementTargetSetForFloat.target, A_2);
				return;
			}
			this.XqsaWGEGmOwUClTAwWBEdpXuabnOA(customControllerElementTargetSetForFloat.positiveTarget, A_2);
			this.XqsaWGEGmOwUClTAwWBEdpXuabnOA(customControllerElementTargetSetForFloat.negativeTarget, A_2);
		}

		// Token: 0x060027D0 RID: 10192
		internal abstract void NoDfoutjzRlNHhrwttFiSRGrfrvh();

		// Token: 0x060027D1 RID: 10193 RVA: 0x0009617C File Offset: 0x0009437C
		private void PWmLYvndNHvDBTyGJhqHxFTzsJeT(CustomControllerElementTarget A_1, float A_2, float A_3)
		{
			if (A_1 == null)
			{
				return;
			}
			CustomControllerElementSelector.ElementType elementType = A_1.element.elementType;
			if (elementType == CustomControllerElementSelector.ElementType.Axis)
			{
				switch (A_1.valueRange)
				{
				case CustomControllerElementTarget.ValueRange.Full:
					if (A_1.invert)
					{
						A_2 *= -1f;
					}
					break;
				case CustomControllerElementTarget.ValueRange.Positive:
					if (A_2 < 0f)
					{
						A_2 = 0f;
					}
					if (A_1.valueContribution == Pole.Negative)
					{
						A_2 *= -1f;
					}
					break;
				case CustomControllerElementTarget.ValueRange.Negative:
					if (A_2 > 0f)
					{
						A_2 = 0f;
					}
					if (A_1.valueContribution == Pole.Positive)
					{
						A_2 *= -1f;
					}
					break;
				}
				this.WoSgDjfaOkuapKqTxSyHHZPJULte.SetAxisValue(A_1.element, A_2);
				return;
			}
			if (elementType != CustomControllerElementSelector.ElementType.Button)
			{
				throw new NotImplementedException();
			}
			switch (A_1.valueRange)
			{
			case CustomControllerElementTarget.ValueRange.Positive:
				if (A_2 < 0f)
				{
					A_2 = 0f;
				}
				break;
			case CustomControllerElementTarget.ValueRange.Negative:
				if (A_2 > 0f)
				{
					A_2 = 0f;
				}
				break;
			}
			this.WoSgDjfaOkuapKqTxSyHHZPJULte.SetButtonValue(A_1.element, MathTools.Abs(A_2) >= MathTools.Abs(A_3));
		}

		// Token: 0x060027D2 RID: 10194 RVA: 0x00096290 File Offset: 0x00094490
		private void XqsaWGEGmOwUClTAwWBEdpXuabnOA(CustomControllerElementTarget A_1, bool A_2)
		{
			if (A_1 == null)
			{
				return;
			}
			CustomControllerElementSelector.ElementType elementType = A_1.element.elementType;
			if (elementType == CustomControllerElementSelector.ElementType.Axis)
			{
				float num = A_2 ? 1f : 0f;
				if (A_1.valueRange == CustomControllerElementTarget.ValueRange.Full)
				{
					if (A_1.invert)
					{
						num *= -1f;
					}
				}
				else if (A_1.valueContribution == Pole.Negative)
				{
					num *= -1f;
				}
				this.WoSgDjfaOkuapKqTxSyHHZPJULte.SetAxisValue(A_1.element, num);
				return;
			}
			if (elementType != CustomControllerElementSelector.ElementType.Button)
			{
				throw new NotImplementedException();
			}
			this.WoSgDjfaOkuapKqTxSyHHZPJULte.SetButtonValue(A_1.element, A_2);
		}

		// Token: 0x060027D3 RID: 10195 RVA: 0x0001DCFE File Offset: 0x0001BEFE
		private void yNQgzmaiOQyYqcxPGBHndZYcamYOA()
		{
			if (base.lNeyItEtilEMWcbsGCemarSXLpofb() || !base.IUGIIGfBqvDUFgNIMGdfUHjibbKRA())
			{
				return;
			}
			this.NoDfoutjzRlNHhrwttFiSRGrfrvh();
		}
	}
}
