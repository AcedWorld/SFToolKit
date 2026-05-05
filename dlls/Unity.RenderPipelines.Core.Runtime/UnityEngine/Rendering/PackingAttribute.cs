using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000B2 RID: 178
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class PackingAttribute : Attribute
	{
		// Token: 0x0600055A RID: 1370 RVA: 0x0001B900 File Offset: 0x00019B00
		public PackingAttribute(string[] displayNames, FieldPacking packingScheme = FieldPacking.NoPacking, int bitSize = 32, int offsetInSource = 0, float minValue = 0f, float maxValue = 1f, bool isDirection = false, bool sRGBDisplay = false, bool checkIsNormalized = false, string preprocessor = "")
		{
			this.displayNames = displayNames;
			this.packingScheme = packingScheme;
			this.offsetInSource = offsetInSource;
			this.isDirection = isDirection;
			this.sRGBDisplay = sRGBDisplay;
			this.checkIsNormalized = checkIsNormalized;
			this.sizeInBits = bitSize;
			this.range = new float[]
			{
				minValue,
				maxValue
			};
			this.preprocessor = preprocessor;
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x0001B968 File Offset: 0x00019B68
		public PackingAttribute(string displayName = "", FieldPacking packingScheme = FieldPacking.NoPacking, int bitSize = 0, int offsetInSource = 0, float minValue = 0f, float maxValue = 1f, bool isDirection = false, bool sRGBDisplay = false, bool checkIsNormalized = false, string preprocessor = "")
		{
			this.displayNames = new string[1];
			this.displayNames[0] = displayName;
			this.packingScheme = packingScheme;
			this.offsetInSource = offsetInSource;
			this.isDirection = isDirection;
			this.sRGBDisplay = sRGBDisplay;
			this.checkIsNormalized = checkIsNormalized;
			this.sizeInBits = bitSize;
			this.range = new float[]
			{
				minValue,
				maxValue
			};
			this.preprocessor = preprocessor;
		}

		// Token: 0x040003EA RID: 1002
		public string[] displayNames;

		// Token: 0x040003EB RID: 1003
		public float[] range;

		// Token: 0x040003EC RID: 1004
		public FieldPacking packingScheme;

		// Token: 0x040003ED RID: 1005
		public int offsetInSource;

		// Token: 0x040003EE RID: 1006
		public int sizeInBits;

		// Token: 0x040003EF RID: 1007
		public bool isDirection;

		// Token: 0x040003F0 RID: 1008
		public bool sRGBDisplay;

		// Token: 0x040003F1 RID: 1009
		public bool checkIsNormalized;

		// Token: 0x040003F2 RID: 1010
		public string preprocessor;
	}
}
