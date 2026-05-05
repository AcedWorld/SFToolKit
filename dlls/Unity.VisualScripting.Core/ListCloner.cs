using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x0200000C RID: 12
	public sealed class ListCloner : Cloner<IList>
	{
		// Token: 0x0600002A RID: 42 RVA: 0x0000249D File Offset: 0x0000069D
		public override bool Handles(Type type)
		{
			return typeof(IList).IsAssignableFrom(type);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000024B0 File Offset: 0x000006B0
		public override void FillClone(Type type, ref IList clone, IList original, CloningContext context)
		{
			if (context.tryPreserveInstances)
			{
				for (int i = 0; i < original.Count; i++)
				{
					object original2 = original[i];
					if (i < clone.Count)
					{
						object value = clone[i];
						Cloning.CloneInto(context, ref value, original2);
						clone[i] = value;
					}
					else
					{
						clone.Add(Cloning.Clone(context, original2));
					}
				}
				return;
			}
			for (int j = 0; j < original.Count; j++)
			{
				object original3 = original[j];
				clone.Add(Cloning.Clone(context, original3));
			}
		}
	}
}
