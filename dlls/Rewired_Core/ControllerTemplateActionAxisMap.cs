using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	// Token: 0x0200007E RID: 126
	public sealed class ControllerTemplateActionAxisMap : ControllerTemplateActionElementMap
	{
		// Token: 0x06000576 RID: 1398 RVA: 0x00006D9F File Offset: 0x00004F9F
		internal ControllerTemplateActionAxisMap(SerializedObject A_1) : base(ControllerTemplateElementType.Axis)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("serializedObject");
			}
			this.hkpHsVfUqBDRlVupCwuOZlRPAMBQ(A_1);
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x00006DBD File Offset: 0x00004FBD
		internal ControllerTemplateActionAxisMap(int A_1, AxisRange A_2, ActionElementMap A_3) : base(ControllerTemplateElementType.Axis, A_1, A_3)
		{
			this.lcEguEMZOwyumNbiWaCIHdkMfSyw = A_2;
			this.EcHsqENhTtBaOuCijBIdzZfDpLdP = A_3.axisContribution;
			this.hEYtTGzeGijFFDAltBseEmdJPgdkb = A_3._invert;
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x00006DE7 File Offset: 0x00004FE7
		internal ControllerTemplateActionAxisMap(int A_1, int A_2, AxisRange A_3, Pole A_4, bool A_5, bool A_6) : base(ControllerTemplateElementType.Axis, A_1, A_2, A_6)
		{
			this.lcEguEMZOwyumNbiWaCIHdkMfSyw = A_3;
			this.EcHsqENhTtBaOuCijBIdzZfDpLdP = A_4;
			this.hEYtTGzeGijFFDAltBseEmdJPgdkb = A_5;
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000579 RID: 1401 RVA: 0x00006E0B File Offset: 0x0000500B
		public AxisRange axisRange
		{
			get
			{
				return this.lcEguEMZOwyumNbiWaCIHdkMfSyw;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x0600057A RID: 1402 RVA: 0x00006E13 File Offset: 0x00005013
		public Pole axisContribution
		{
			get
			{
				return this.EcHsqENhTtBaOuCijBIdzZfDpLdP;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x0600057B RID: 1403 RVA: 0x00006E1B File Offset: 0x0000501B
		public bool invert
		{
			get
			{
				return this.hEYtTGzeGijFFDAltBseEmdJPgdkb;
			}
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x00006E23 File Offset: 0x00005023
		internal void pDAjqFyxBOycOqFWUAXfFwNrgiTC(SerializedObject A_1)
		{
			base.mEATukXKPLHbiHGkfoVdJuPIKKdC(A_1);
			A_1.Add<Pole>("axisContribution", this.EcHsqENhTtBaOuCijBIdzZfDpLdP, SerializedObject.FieldOptions.None);
			A_1.Add<AxisRange>("axisRange", this.lcEguEMZOwyumNbiWaCIHdkMfSyw, SerializedObject.FieldOptions.None);
			A_1.Add<bool>("invert", this.hEYtTGzeGijFFDAltBseEmdJPgdkb, SerializedObject.FieldOptions.None);
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x00006E62 File Offset: 0x00005062
		internal void zyQaMjdSuTurrqvStbUIgKrhPBXyb(SerializedObject A_1)
		{
			base.hkpHsVfUqBDRlVupCwuOZlRPAMBQ(A_1);
			A_1.TryGetDeserializedValueByRef<Pole>("axisContribution", ref this.EcHsqENhTtBaOuCijBIdzZfDpLdP);
			A_1.TryGetDeserializedValueByRef<AxisRange>("axisRange", ref this.lcEguEMZOwyumNbiWaCIHdkMfSyw);
			A_1.TryGetDeserializedValueByRef<bool>("invert", ref this.hEYtTGzeGijFFDAltBseEmdJPgdkb);
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x00006EA1 File Offset: 0x000050A1
		internal void lYLaISFJuloPXMtRMhEDghtjKJVic()
		{
			this.lcEguEMZOwyumNbiWaCIHdkMfSyw = AxisRange.Full;
			this.EcHsqENhTtBaOuCijBIdzZfDpLdP = Pole.Positive;
			this.hEYtTGzeGijFFDAltBseEmdJPgdkb = false;
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x00039D50 File Offset: 0x00037F50
		internal int RazdhHDGLAXjfFUKAhAjbcImJLIZ(IControllerTemplateElementSource A_1, List<ActionElementMap> A_2, bool A_3)
		{
			IControllerTemplateAxisSource controllerTemplateAxisSource = A_1 as IControllerTemplateAxisSource;
			if (controllerTemplateAxisSource == null)
			{
				return 0;
			}
			int num = 0;
			if (this.lcEguEMZOwyumNbiWaCIHdkMfSyw == AxisRange.Full)
			{
				if (controllerTemplateAxisSource.splitAxis)
				{
					ActionElementMap actionElementMap = this.UcikakWpsFXrZZNuGMSCRduWzcUq(controllerTemplateAxisSource.positiveTarget, this.hEYtTGzeGijFFDAltBseEmdJPgdkb ? AxisRange.Negative : AxisRange.Positive, this.EcHsqENhTtBaOuCijBIdzZfDpLdP);
					if (actionElementMap != null)
					{
						A_2.Add(actionElementMap);
						num++;
					}
					actionElementMap = this.UcikakWpsFXrZZNuGMSCRduWzcUq(controllerTemplateAxisSource.negativeTarget, this.hEYtTGzeGijFFDAltBseEmdJPgdkb ? AxisRange.Positive : AxisRange.Negative, this.EcHsqENhTtBaOuCijBIdzZfDpLdP);
					if (actionElementMap != null)
					{
						A_2.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = this.UcikakWpsFXrZZNuGMSCRduWzcUq(controllerTemplateAxisSource.fullTarget, AxisRange.Full, this.EcHsqENhTtBaOuCijBIdzZfDpLdP);
					if (actionElementMap != null)
					{
						A_2.Add(actionElementMap);
						num++;
					}
				}
			}
			else if (controllerTemplateAxisSource.splitAxis)
			{
				if (this.lcEguEMZOwyumNbiWaCIHdkMfSyw == AxisRange.Positive)
				{
					ActionElementMap actionElementMap = this.ZElZJVeLlJlrtodOZGTFKLTgpNPMA(controllerTemplateAxisSource.positiveTarget, Pole.Positive, this.EcHsqENhTtBaOuCijBIdzZfDpLdP);
					if (actionElementMap != null)
					{
						A_2.Add(actionElementMap);
						num++;
					}
				}
				else
				{
					ActionElementMap actionElementMap = this.ZElZJVeLlJlrtodOZGTFKLTgpNPMA(controllerTemplateAxisSource.negativeTarget, Pole.Negative, this.EcHsqENhTtBaOuCijBIdzZfDpLdP);
					if (actionElementMap != null)
					{
						A_2.Add(actionElementMap);
						num++;
					}
				}
			}
			else
			{
				ActionElementMap actionElementMap = this.ZElZJVeLlJlrtodOZGTFKLTgpNPMA(controllerTemplateAxisSource.fullTarget, (this.lcEguEMZOwyumNbiWaCIHdkMfSyw == AxisRange.Negative) ? Pole.Negative : Pole.Positive, this.EcHsqENhTtBaOuCijBIdzZfDpLdP);
				if (actionElementMap != null)
				{
					A_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x00039E94 File Offset: 0x00038094
		private ActionElementMap UcikakWpsFXrZZNuGMSCRduWzcUq(IControllerElementTarget A_1, AxisRange A_2, Pole A_3)
		{
			if (A_1 == null || A_1.element == null)
			{
				return null;
			}
			ControllerElementType elementType = A_1.elementType;
			AxisRange axisRange = A_1.axisRange;
			ActionElementMap actionElementMap = new ActionElementMap();
			actionElementMap._elementIdentifierId = A_1.elementIdentifierId;
			actionElementMap._elementType = elementType;
			actionElementMap._axisRange = axisRange;
			if (axisRange == AxisRange.Full)
			{
				if (elementType == ControllerElementType.Axis)
				{
					actionElementMap._invert = this.hEYtTGzeGijFFDAltBseEmdJPgdkb;
				}
				else if (elementType == ControllerElementType.Button)
				{
					actionElementMap._axisContribution = A_3;
				}
			}
			else if (elementType == ControllerElementType.Axis || elementType == ControllerElementType.Button)
			{
				Pole axisContribution = (A_2 == AxisRange.Negative) ? Pole.Negative : Pole.Positive;
				actionElementMap._axisContribution = axisContribution;
			}
			return actionElementMap;
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x00039F18 File Offset: 0x00038118
		private ActionElementMap ZElZJVeLlJlrtodOZGTFKLTgpNPMA(IControllerElementTarget A_1, Pole A_2, Pole A_3)
		{
			if (A_1 == null || A_1.element == null)
			{
				return null;
			}
			ControllerElementType elementType = A_1.elementType;
			AxisRange axisRange = A_1.axisRange;
			ActionElementMap actionElementMap = new ActionElementMap();
			actionElementMap._elementIdentifierId = A_1.elementIdentifierId;
			actionElementMap._elementType = elementType;
			actionElementMap._axisRange = axisRange;
			if (elementType == ControllerElementType.Axis && axisRange == AxisRange.Full)
			{
				actionElementMap._axisRange = ((A_2 == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative);
				actionElementMap._axisContribution = A_3;
			}
			else if (elementType == ControllerElementType.Axis || elementType == ControllerElementType.Button)
			{
				actionElementMap._axisContribution = A_3;
			}
			return actionElementMap;
		}

		// Token: 0x0400039D RID: 925
		private AxisRange lcEguEMZOwyumNbiWaCIHdkMfSyw;

		// Token: 0x0400039E RID: 926
		private Pole EcHsqENhTtBaOuCijBIdzZfDpLdP;

		// Token: 0x0400039F RID: 927
		private bool hEYtTGzeGijFFDAltBseEmdJPgdkb;
	}
}
