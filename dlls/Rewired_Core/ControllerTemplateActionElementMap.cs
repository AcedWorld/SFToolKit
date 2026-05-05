using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	// Token: 0x0200007C RID: 124
	public abstract class ControllerTemplateActionElementMap
	{
		// Token: 0x06000557 RID: 1367 RVA: 0x000399EC File Offset: 0x00037BEC
		internal ControllerTemplateActionElementMap(ControllerTemplateElementType A_1)
		{
			if (!InputTools.IsMappableType(A_1))
			{
				throw new ArgumentException(A_1.ToString() + " is not a supported mappable Controller Template element type.");
			}
			this.zqReonEkDFceWsaDwejOQRSEPLyfb = A_1;
			this.GdVgGvSoDNXDSJXFndgSVYimdATr = ControllerTemplateActionElementMap.cGkKUVwoHOcHIjEjmaNAjUuvdMSwA++;
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x00006C22 File Offset: 0x00004E22
		internal ControllerTemplateActionElementMap(ControllerTemplateElementType A_1, int A_2, ActionElementMap A_3) : this(A_1)
		{
			if (A_3 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			this.ycPSUSovKPxUFUrmPrlsNWeHPdmj = A_3._actionId;
			this.KAAgyeSxoinAWvOwCTbWEtnemCPf = A_2;
			this.oUeWqjdYeTmzWQArnyjLDmHOEfocA = A_3.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA;
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x00006C58 File Offset: 0x00004E58
		internal ControllerTemplateActionElementMap(ControllerTemplateElementType A_1, int A_2, int A_3, bool A_4) : this(A_1)
		{
			this.ycPSUSovKPxUFUrmPrlsNWeHPdmj = A_3;
			this.KAAgyeSxoinAWvOwCTbWEtnemCPf = A_2;
			this.oUeWqjdYeTmzWQArnyjLDmHOEfocA = A_4;
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x000033F4 File Offset: 0x000015F4
		protected ControllerTemplateActionElementMap(ActionElementMap A_1)
		{
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x0600055B RID: 1371 RVA: 0x00006C77 File Offset: 0x00004E77
		public int id
		{
			get
			{
				return this.GdVgGvSoDNXDSJXFndgSVYimdATr;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x0600055C RID: 1372 RVA: 0x00006C7F File Offset: 0x00004E7F
		public ControllerTemplateElementType elementType
		{
			get
			{
				return this.zqReonEkDFceWsaDwejOQRSEPLyfb;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x0600055D RID: 1373 RVA: 0x00006C87 File Offset: 0x00004E87
		// (set) Token: 0x0600055E RID: 1374 RVA: 0x00006C8F File Offset: 0x00004E8F
		public bool enabled
		{
			get
			{
				return this.oUeWqjdYeTmzWQArnyjLDmHOEfocA;
			}
			set
			{
				this.oUeWqjdYeTmzWQArnyjLDmHOEfocA = value;
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x0600055F RID: 1375 RVA: 0x00006C98 File Offset: 0x00004E98
		// (set) Token: 0x06000560 RID: 1376 RVA: 0x00006CA0 File Offset: 0x00004EA0
		public int actionId
		{
			get
			{
				return this.ycPSUSovKPxUFUrmPrlsNWeHPdmj;
			}
			set
			{
				this.ycPSUSovKPxUFUrmPrlsNWeHPdmj = value;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000561 RID: 1377 RVA: 0x00006CA9 File Offset: 0x00004EA9
		// (set) Token: 0x06000562 RID: 1378 RVA: 0x00006CB1 File Offset: 0x00004EB1
		public int elementIdentifierId
		{
			get
			{
				return this.KAAgyeSxoinAWvOwCTbWEtnemCPf;
			}
			set
			{
				this.KAAgyeSxoinAWvOwCTbWEtnemCPf = value;
			}
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x00039A40 File Offset: 0x00037C40
		internal int fxTCoIAkSoRBinmNwhajAGxLwrqL(IControllerTemplate A_1, List<ActionElementMap> A_2, bool A_3)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			if (A_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!A_3)
			{
				A_2.Clear();
			}
			int num = this.VBvMPBqQbHvYTtEMCPcEHJGBJrrq(A_1, A_2, A_3);
			if (num == 0)
			{
				return 0;
			}
			int num2 = A_2.Count - num;
			for (int i = 0; i < num; i++)
			{
				int index = num2 + i;
				A_2[index].kTSqOiiDvdcWOlxiGdgtHFRoGHcqA = this.oUeWqjdYeTmzWQArnyjLDmHOEfocA;
				A_2[index]._actionId = this.ycPSUSovKPxUFUrmPrlsNWeHPdmj;
			}
			return num;
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x00039AC0 File Offset: 0x00037CC0
		internal SerializedObject etIsOuaCTBfPgCTYKdwleZoTvQZs()
		{
			SerializedObject serializedObject = new SerializedObject(base.GetType(), SerializedObject.ObjectType.Object);
			this.mEATukXKPLHbiHGkfoVdJuPIKKdC(serializedObject);
			return serializedObject;
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x00039AE4 File Offset: 0x00037CE4
		internal virtual void mEATukXKPLHbiHGkfoVdJuPIKKdC(SerializedObject A_1)
		{
			A_1.Add<ControllerTemplateElementType>("elementType", this.zqReonEkDFceWsaDwejOQRSEPLyfb, SerializedObject.FieldOptions.None);
			A_1.Add<bool>("enabled", this.oUeWqjdYeTmzWQArnyjLDmHOEfocA, SerializedObject.FieldOptions.None);
			A_1.Add<int>("elementIdentifierId", this.KAAgyeSxoinAWvOwCTbWEtnemCPf, SerializedObject.FieldOptions.None);
			A_1.Add<int>("actionId", this.ycPSUSovKPxUFUrmPrlsNWeHPdmj, SerializedObject.FieldOptions.None);
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x00006CBA File Offset: 0x00004EBA
		internal virtual void hkpHsVfUqBDRlVupCwuOZlRPAMBQ(SerializedObject A_1)
		{
			this.mpVKJbRltDdLLEfkGfbkXPJxPWLBb();
			A_1.TryGetDeserializedValueByRef<bool>("enabled", ref this.oUeWqjdYeTmzWQArnyjLDmHOEfocA);
			A_1.TryGetDeserializedValueByRef<int>("elementIdentifierId", ref this.KAAgyeSxoinAWvOwCTbWEtnemCPf);
			A_1.TryGetDeserializedValueByRef<int>("actionId", ref this.ycPSUSovKPxUFUrmPrlsNWeHPdmj);
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x00006CF8 File Offset: 0x00004EF8
		internal virtual void mpVKJbRltDdLLEfkGfbkXPJxPWLBb()
		{
			this.oUeWqjdYeTmzWQArnyjLDmHOEfocA = true;
			this.KAAgyeSxoinAWvOwCTbWEtnemCPf = -1;
			this.ycPSUSovKPxUFUrmPrlsNWeHPdmj = -1;
		}

		// Token: 0x06000568 RID: 1384
		internal abstract int CcOQYjOMlOLAPohuRpLSiSOWHRx(IControllerTemplateElementSource, List<ActionElementMap>, bool);

		// Token: 0x06000569 RID: 1385 RVA: 0x00039B3C File Offset: 0x00037D3C
		private int VBvMPBqQbHvYTtEMCPcEHJGBJrrq(IControllerTemplate A_1, List<ActionElementMap> A_2, bool A_3)
		{
			if (A_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!A_3)
			{
				A_2.Clear();
			}
			IControllerTemplateElement element = A_1.GetElement(this.KAAgyeSxoinAWvOwCTbWEtnemCPf);
			if (element == null)
			{
				return 0;
			}
			IControllerTemplateElementSource source = element.source;
			if (source == null)
			{
				return 0;
			}
			return this.CcOQYjOMlOLAPohuRpLSiSOWHRx(source, A_2, A_3);
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x00039B88 File Offset: 0x00037D88
		internal static ControllerTemplateActionElementMap NoxPmyDPGOtGBKxlxcLyFrCmOhcf(SerializedObject A_0)
		{
			if (A_0 == null)
			{
				return null;
			}
			ControllerTemplateElementType controllerTemplateElementType;
			if (!A_0.TryGetDeserializedValue<ControllerTemplateElementType>("elementType", out controllerTemplateElementType))
			{
				return null;
			}
			if (controllerTemplateElementType == ControllerTemplateElementType.Axis)
			{
				return new ControllerTemplateActionAxisMap(A_0);
			}
			if (controllerTemplateElementType != ControllerTemplateElementType.Button)
			{
				throw new NotImplementedException();
			}
			return new ControllerTemplateActionButtonMap(A_0);
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x00039BC8 File Offset: 0x00037DC8
		internal static ControllerTemplateActionElementMap DYLcqAHncfFhhJFBBgcMHJFHVeYA(ControllerTemplateElementTarget A_0, ActionElementMap A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (A_0.elementType == ControllerTemplateElementType.Axis)
			{
				return new ControllerTemplateActionAxisMap(A_0.element.id, A_0.axisRange, A_1);
			}
			if (A_0.elementType == ControllerTemplateElementType.Button)
			{
				return new ControllerTemplateActionButtonMap(A_0.element.id, A_1);
			}
			throw new NotImplementedException();
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x00039C28 File Offset: 0x00037E28
		internal static ControllerTemplateActionElementMap ltvevvAbFrYvfZCxtACIcyrVkcYAA(ActionElementMap A_0)
		{
			if (A_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			ControllerTemplateElementType controllerTemplateElementType = gRvITEHjKMrWaeGYEmAHofbpCtEU.CkKlzxvjUXxuZLFtnYQkTRGMtKjm(A_0._elementType, false);
			if (!InputTools.IsMappableType(controllerTemplateElementType))
			{
				return null;
			}
			if (controllerTemplateElementType == ControllerTemplateElementType.Axis)
			{
				return new ControllerTemplateActionAxisMap(A_0._elementIdentifierId, A_0._actionId, A_0._axisRange, A_0._axisContribution, A_0._invert, A_0.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA);
			}
			if (controllerTemplateElementType == ControllerTemplateElementType.Button)
			{
				return new ControllerTemplateActionButtonMap(A_0._elementIdentifierId, A_0._actionId, A_0._axisContribution, A_0.kTSqOiiDvdcWOlxiGdgtHFRoGHcqA);
			}
			throw new NotImplementedException();
		}

		// Token: 0x04000396 RID: 918
		private readonly int GdVgGvSoDNXDSJXFndgSVYimdATr;

		// Token: 0x04000397 RID: 919
		private readonly ControllerTemplateElementType zqReonEkDFceWsaDwejOQRSEPLyfb;

		// Token: 0x04000398 RID: 920
		private bool oUeWqjdYeTmzWQArnyjLDmHOEfocA;

		// Token: 0x04000399 RID: 921
		private int ycPSUSovKPxUFUrmPrlsNWeHPdmj;

		// Token: 0x0400039A RID: 922
		private int KAAgyeSxoinAWvOwCTbWEtnemCPf;

		// Token: 0x0400039B RID: 923
		private static int cGkKUVwoHOcHIjEjmaNAjUuvdMSwA;
	}
}
