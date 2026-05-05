using System;

namespace Unity.VisualScripting.FullSerializer.Internal
{
	// Token: 0x020001B2 RID: 434
	public struct fsVersionedType
	{
		// Token: 0x06000B97 RID: 2967 RVA: 0x00031221 File Offset: 0x0002F421
		public object Migrate(object ancestorInstance)
		{
			return Activator.CreateInstance(this.ModelType, new object[]
			{
				ancestorInstance
			});
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x00031238 File Offset: 0x0002F438
		public override string ToString()
		{
			string[] array = new string[7];
			array[0] = "fsVersionedType [ModelType=";
			int num = 1;
			Type modelType = this.ModelType;
			array[num] = ((modelType != null) ? modelType.ToString() : null);
			array[2] = ", VersionString=";
			array[3] = this.VersionString;
			array[4] = ", Ancestors.Length=";
			array[5] = this.Ancestors.Length.ToString();
			array[6] = "]";
			return string.Concat(array);
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x000312A1 File Offset: 0x0002F4A1
		public static bool operator ==(fsVersionedType a, fsVersionedType b)
		{
			return a.ModelType == b.ModelType;
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x000312B4 File Offset: 0x0002F4B4
		public static bool operator !=(fsVersionedType a, fsVersionedType b)
		{
			return a.ModelType != b.ModelType;
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x000312C7 File Offset: 0x0002F4C7
		public override bool Equals(object obj)
		{
			return obj is fsVersionedType && this.ModelType == ((fsVersionedType)obj).ModelType;
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x000312E9 File Offset: 0x0002F4E9
		public override int GetHashCode()
		{
			return this.ModelType.GetHashCode();
		}

		// Token: 0x040002CC RID: 716
		public fsVersionedType[] Ancestors;

		// Token: 0x040002CD RID: 717
		public string VersionString;

		// Token: 0x040002CE RID: 718
		public Type ModelType;
	}
}
