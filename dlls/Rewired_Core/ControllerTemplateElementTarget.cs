using System;

namespace Rewired
{
	// Token: 0x02000080 RID: 128
	public struct ControllerTemplateElementTarget
	{
		// Token: 0x0600058A RID: 1418 RVA: 0x00006EFE File Offset: 0x000050FE
		internal ControllerTemplateElementTarget(IControllerTemplateElement A_1, AxisRange A_2)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("element");
			}
			this.MTQcEcoipYOKLkYtDfkgMnnMfqrGA = A_1;
			this.CTowgNGZhTsocCyfvHdRihbtAkjN = A_2;
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x00006F1C File Offset: 0x0000511C
		public ControllerTemplateElementTarget(ControllerTemplateElementTarget A_1)
		{
			this.MTQcEcoipYOKLkYtDfkgMnnMfqrGA = A_1.MTQcEcoipYOKLkYtDfkgMnnMfqrGA;
			this.CTowgNGZhTsocCyfvHdRihbtAkjN = A_1.CTowgNGZhTsocCyfvHdRihbtAkjN;
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x0600058C RID: 1420 RVA: 0x00006F36 File Offset: 0x00005136
		// (set) Token: 0x0600058D RID: 1421 RVA: 0x00006F3E File Offset: 0x0000513E
		public AxisRange axisRange
		{
			get
			{
				return this.CTowgNGZhTsocCyfvHdRihbtAkjN;
			}
			set
			{
				this.CTowgNGZhTsocCyfvHdRihbtAkjN = value;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x0600058E RID: 1422 RVA: 0x00006F47 File Offset: 0x00005147
		public ControllerTemplateElementType elementType
		{
			get
			{
				if (this.MTQcEcoipYOKLkYtDfkgMnnMfqrGA == null)
				{
					return ControllerTemplateElementType.Axis;
				}
				return this.MTQcEcoipYOKLkYtDfkgMnnMfqrGA.type;
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x0600058F RID: 1423 RVA: 0x00039FF0 File Offset: 0x000381F0
		public string descriptiveName
		{
			get
			{
				if (this.MTQcEcoipYOKLkYtDfkgMnnMfqrGA == null)
				{
					return string.Empty;
				}
				ControllerTemplateElementType type = this.MTQcEcoipYOKLkYtDfkgMnnMfqrGA.type;
				if (type == ControllerTemplateElementType.Axis)
				{
					return ((IControllerTemplateAxis)this.MTQcEcoipYOKLkYtDfkgMnnMfqrGA).GetDescriptiveName(this.CTowgNGZhTsocCyfvHdRihbtAkjN);
				}
				if (type != ControllerTemplateElementType.Button)
				{
					return this.MTQcEcoipYOKLkYtDfkgMnnMfqrGA.descriptiveName;
				}
				return ((IControllerTemplateButton)this.MTQcEcoipYOKLkYtDfkgMnnMfqrGA).descriptiveName;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000590 RID: 1424 RVA: 0x00006F5E File Offset: 0x0000515E
		// (set) Token: 0x06000591 RID: 1425 RVA: 0x00006F66 File Offset: 0x00005166
		public IControllerTemplateElement element
		{
			get
			{
				return this.MTQcEcoipYOKLkYtDfkgMnnMfqrGA;
			}
			set
			{
				this.MTQcEcoipYOKLkYtDfkgMnnMfqrGA = value;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000592 RID: 1426 RVA: 0x00006F6F File Offset: 0x0000516F
		public IControllerTemplate template
		{
			get
			{
				if (this.MTQcEcoipYOKLkYtDfkgMnnMfqrGA == null)
				{
					return null;
				}
				return (this.MTQcEcoipYOKLkYtDfkgMnnMfqrGA as IControllerTemplateElement_Internal).parent;
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000593 RID: 1427 RVA: 0x00006F8B File Offset: 0x0000518B
		public bool hasTarget
		{
			get
			{
				return this.MTQcEcoipYOKLkYtDfkgMnnMfqrGA != null;
			}
		}

		// Token: 0x040003A5 RID: 933
		private IControllerTemplateElement MTQcEcoipYOKLkYtDfkgMnnMfqrGA;

		// Token: 0x040003A6 RID: 934
		private AxisRange CTowgNGZhTsocCyfvHdRihbtAkjN;
	}
}
