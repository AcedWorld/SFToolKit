using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000006 RID: 6
	public sealed class ArrayCloner : Cloner<Array>
	{
		// Token: 0x06000012 RID: 18 RVA: 0x000021BD File Offset: 0x000003BD
		public override bool Handles(Type type)
		{
			return type.IsArray;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000021C5 File Offset: 0x000003C5
		public override Array ConstructClone(Type type, Array original)
		{
			return Array.CreateInstance(type.GetElementType(), 0);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000021D4 File Offset: 0x000003D4
		public override void FillClone(Type type, ref Array clone, Array original, CloningContext context)
		{
			int length = original.GetLength(0);
			clone = Array.CreateInstance(type.GetElementType(), length);
			for (int i = 0; i < length; i++)
			{
				clone.SetValue(Cloning.Clone(context, original.GetValue(i)), i);
			}
		}
	}
}
