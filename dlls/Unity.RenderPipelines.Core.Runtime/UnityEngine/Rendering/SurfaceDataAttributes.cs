using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000B0 RID: 176
	[AttributeUsage(AttributeTargets.Field)]
	public class SurfaceDataAttributes : Attribute
	{
		// Token: 0x06000557 RID: 1367 RVA: 0x0001B864 File Offset: 0x00019A64
		public SurfaceDataAttributes(string displayName = "", bool isDirection = false, bool sRGBDisplay = false, FieldPrecision precision = FieldPrecision.Default, bool checkIsNormalized = false, string preprocessor = "")
		{
			this.displayNames = new string[1];
			this.displayNames[0] = displayName;
			this.isDirection = isDirection;
			this.sRGBDisplay = sRGBDisplay;
			this.precision = precision;
			this.checkIsNormalized = checkIsNormalized;
			this.preprocessor = preprocessor;
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x0001B8B2 File Offset: 0x00019AB2
		public SurfaceDataAttributes(string[] displayNames, bool isDirection = false, bool sRGBDisplay = false, FieldPrecision precision = FieldPrecision.Default, bool checkIsNormalized = false, string preprocessor = "")
		{
			this.displayNames = displayNames;
			this.isDirection = isDirection;
			this.sRGBDisplay = sRGBDisplay;
			this.precision = precision;
			this.checkIsNormalized = checkIsNormalized;
			this.preprocessor = preprocessor;
		}

		// Token: 0x040003E2 RID: 994
		public string[] displayNames;

		// Token: 0x040003E3 RID: 995
		public bool isDirection;

		// Token: 0x040003E4 RID: 996
		public bool sRGBDisplay;

		// Token: 0x040003E5 RID: 997
		public FieldPrecision precision;

		// Token: 0x040003E6 RID: 998
		public bool checkIsNormalized;

		// Token: 0x040003E7 RID: 999
		public string preprocessor;
	}
}
