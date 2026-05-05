using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000004 RID: 4
	public abstract class Cloner<T> : ICloner
	{
		// Token: 0x06000005 RID: 5
		public abstract bool Handles(Type type);

		// Token: 0x06000006 RID: 6 RVA: 0x000020D6 File Offset: 0x000002D6
		void ICloner.BeforeClone(Type type, object original)
		{
			this.BeforeClone(type, (T)((object)original));
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000020E5 File Offset: 0x000002E5
		public virtual void BeforeClone(Type type, T original)
		{
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000020E7 File Offset: 0x000002E7
		object ICloner.ConstructClone(Type type, object original)
		{
			return this.ConstructClone(type, (T)((object)original));
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000020FB File Offset: 0x000002FB
		public virtual T ConstructClone(Type type, T original)
		{
			return (T)((object)Activator.CreateInstance(type, true));
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000210C File Offset: 0x0000030C
		void ICloner.FillClone(Type type, ref object clone, object original, CloningContext context)
		{
			T t = (T)((object)clone);
			this.FillClone(type, ref t, (T)((object)original), context);
			clone = t;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000213A File Offset: 0x0000033A
		public virtual void FillClone(Type type, ref T clone, T original, CloningContext context)
		{
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000213C File Offset: 0x0000033C
		void ICloner.AfterClone(Type type, object clone)
		{
			this.AfterClone(type, (T)((object)clone));
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000214B File Offset: 0x0000034B
		public virtual void AfterClone(Type type, T clone)
		{
		}
	}
}
