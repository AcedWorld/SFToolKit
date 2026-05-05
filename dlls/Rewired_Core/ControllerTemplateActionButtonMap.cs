using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	// Token: 0x0200007D RID: 125
	public sealed class ControllerTemplateActionButtonMap : ControllerTemplateActionElementMap
	{
		// Token: 0x0600056D RID: 1389 RVA: 0x00006D0F File Offset: 0x00004F0F
		internal ControllerTemplateActionButtonMap(SerializedObject A_1) : base(ControllerTemplateElementType.Button)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("serializedObject");
			}
			this.hkpHsVfUqBDRlVupCwuOZlRPAMBQ(A_1);
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x00006D2D File Offset: 0x00004F2D
		internal ControllerTemplateActionButtonMap(int A_1, ActionElementMap A_2) : base(ControllerTemplateElementType.Button, A_1, A_2)
		{
			this.WuWAZphvbYRdMwStRGHEElYlqdStA = A_2.axisContribution;
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x00006D44 File Offset: 0x00004F44
		internal ControllerTemplateActionButtonMap(int A_1, int A_2, Pole A_3, bool A_4) : base(ControllerTemplateElementType.Button, A_1, A_2, A_4)
		{
			this.WuWAZphvbYRdMwStRGHEElYlqdStA = A_3;
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000570 RID: 1392 RVA: 0x00006D58 File Offset: 0x00004F58
		public Pole axisContribution
		{
			get
			{
				return this.WuWAZphvbYRdMwStRGHEElYlqdStA;
			}
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x00006D60 File Offset: 0x00004F60
		internal void aiPyFyOOvUaLHWAQIEgQBPVwZntlA(SerializedObject A_1)
		{
			base.mEATukXKPLHbiHGkfoVdJuPIKKdC(A_1);
			A_1.Add<Pole>("axisContribution", this.WuWAZphvbYRdMwStRGHEElYlqdStA, SerializedObject.FieldOptions.None);
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x00006D7B File Offset: 0x00004F7B
		internal void ZHGDGAcrokKOpFRjKEkkBbHvLidOc(SerializedObject A_1)
		{
			base.hkpHsVfUqBDRlVupCwuOZlRPAMBQ(A_1);
			A_1.TryGetDeserializedValueByRef<Pole>("axisContribution", ref this.WuWAZphvbYRdMwStRGHEElYlqdStA);
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x00006D96 File Offset: 0x00004F96
		internal void UBXHpaTpIVTQnXnnbeJVpjgXWfiX()
		{
			this.WuWAZphvbYRdMwStRGHEElYlqdStA = Pole.Positive;
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x00039CB0 File Offset: 0x00037EB0
		internal int bMguSuMjAHmITSdJlWEakoNYczCDA(IControllerTemplateElementSource A_1, List<ActionElementMap> A_2, bool A_3)
		{
			IControllerTemplateButtonSource controllerTemplateButtonSource = A_1 as IControllerTemplateButtonSource;
			if (controllerTemplateButtonSource == null)
			{
				return 0;
			}
			int num = 0;
			ActionElementMap actionElementMap = this.VKMMSnNyNfkdUpUfMNaHjwXlKXJI(controllerTemplateButtonSource.target, this.WuWAZphvbYRdMwStRGHEElYlqdStA);
			if (actionElementMap != null)
			{
				A_2.Add(actionElementMap);
				num++;
			}
			return num;
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x00039CF0 File Offset: 0x00037EF0
		private ActionElementMap VKMMSnNyNfkdUpUfMNaHjwXlKXJI(IControllerElementTarget A_1, Pole A_2)
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
			if ((elementType != ControllerElementType.Axis || axisRange != AxisRange.Full) && (elementType == ControllerElementType.Axis || elementType == ControllerElementType.Button))
			{
				actionElementMap._axisContribution = A_2;
			}
			return actionElementMap;
		}

		// Token: 0x0400039C RID: 924
		private Pole WuWAZphvbYRdMwStRGHEElYlqdStA;
	}
}
