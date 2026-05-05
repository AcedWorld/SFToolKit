using System;
using Rewired;

// Token: 0x0200007F RID: 127
internal sealed class zzIYMvAnMtpiMJyIjwvHCSyknhJk : IControllerTemplateElementSource, IControllerTemplateAxisSource, IControllerTemplateButtonSource
{
	// Token: 0x06000582 RID: 1410 RVA: 0x00039F8C File Offset: 0x0003818C
	internal zzIYMvAnMtpiMJyIjwvHCSyknhJk(ControllerTemplateElementType A_1, bool A_2, IControllerElementTarget A_3, IControllerElementTarget A_4, IControllerElementTarget A_5)
	{
		if (A_3 == null)
		{
			throw new ArgumentNullException("target");
		}
		if (A_5 == null)
		{
			throw new ArgumentNullException("positiveTarget");
		}
		if (A_4 == null)
		{
			throw new ArgumentNullException("negativeTarget");
		}
		this.EOGGlSJzBFMKdomauqdgLsoaQABjb = A_1;
		this.IXTlNdGXzjinXMEBVxUhEQRCGxnw = A_2;
		this.FmrobwjWkFdVChySzAvemhsSBuyFA = A_3;
		this.BtagROWIzMypZLOlxGspPcVbZqrU = A_4;
		this.zIPvLmOThjcNgnVOZcMvlqpwEvMY = A_5;
	}

	// Token: 0x170001A0 RID: 416
	// (get) Token: 0x06000583 RID: 1411 RVA: 0x00006EB8 File Offset: 0x000050B8
	ControllerTemplateElementSourceType IControllerTemplateElementSource.type
	{
		get
		{
			return gRvITEHjKMrWaeGYEmAHofbpCtEU.hJNAZHESiCJKfmEEpOgaeJWFLauL(this.EOGGlSJzBFMKdomauqdgLsoaQABjb, false);
		}
	}

	// Token: 0x170001A1 RID: 417
	// (get) Token: 0x06000584 RID: 1412 RVA: 0x00006EC6 File Offset: 0x000050C6
	bool IControllerTemplateAxisSource.splitAxis
	{
		get
		{
			return this.IXTlNdGXzjinXMEBVxUhEQRCGxnw;
		}
	}

	// Token: 0x170001A2 RID: 418
	// (get) Token: 0x06000585 RID: 1413 RVA: 0x00006ECE File Offset: 0x000050CE
	IControllerElementTarget IControllerTemplateAxisSource.fullTarget
	{
		get
		{
			return this.FmrobwjWkFdVChySzAvemhsSBuyFA;
		}
	}

	// Token: 0x170001A3 RID: 419
	// (get) Token: 0x06000586 RID: 1414 RVA: 0x00006ED6 File Offset: 0x000050D6
	IControllerElementTarget IControllerTemplateAxisSource.positiveTarget
	{
		get
		{
			return this.BtagROWIzMypZLOlxGspPcVbZqrU;
		}
	}

	// Token: 0x170001A4 RID: 420
	// (get) Token: 0x06000587 RID: 1415 RVA: 0x00006EDE File Offset: 0x000050DE
	IControllerElementTarget IControllerTemplateAxisSource.negativeTarget
	{
		get
		{
			return this.zIPvLmOThjcNgnVOZcMvlqpwEvMY;
		}
	}

	// Token: 0x170001A5 RID: 421
	// (get) Token: 0x06000588 RID: 1416 RVA: 0x00006ECE File Offset: 0x000050CE
	IControllerElementTarget IControllerTemplateButtonSource.target
	{
		get
		{
			return this.FmrobwjWkFdVChySzAvemhsSBuyFA;
		}
	}

	// Token: 0x06000589 RID: 1417 RVA: 0x00006EE6 File Offset: 0x000050E6
	internal static zzIYMvAnMtpiMJyIjwvHCSyknhJk yrzChbkVXxwXGNJCzvAAxbUdkGAE(ControllerTemplateElementType A_0)
	{
		return new zzIYMvAnMtpiMJyIjwvHCSyknhJk(A_0, false, CQMiAtCKCBeBxcvQtMWaEstcdgFPA.UIqjeqmzUiHebZMfbNoSZczTEyep(), CQMiAtCKCBeBxcvQtMWaEstcdgFPA.UIqjeqmzUiHebZMfbNoSZczTEyep(), CQMiAtCKCBeBxcvQtMWaEstcdgFPA.UIqjeqmzUiHebZMfbNoSZczTEyep());
	}

	// Token: 0x040003A0 RID: 928
	private ControllerTemplateElementType EOGGlSJzBFMKdomauqdgLsoaQABjb;

	// Token: 0x040003A1 RID: 929
	private bool IXTlNdGXzjinXMEBVxUhEQRCGxnw;

	// Token: 0x040003A2 RID: 930
	private IControllerElementTarget FmrobwjWkFdVChySzAvemhsSBuyFA;

	// Token: 0x040003A3 RID: 931
	private IControllerElementTarget BtagROWIzMypZLOlxGspPcVbZqrU;

	// Token: 0x040003A4 RID: 932
	private IControllerElementTarget zIPvLmOThjcNgnVOZcMvlqpwEvMY;
}
