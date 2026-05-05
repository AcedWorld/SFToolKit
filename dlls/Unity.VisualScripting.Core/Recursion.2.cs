using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000161 RID: 353
	public sealed class Recursion : Recursion<object>
	{
		// Token: 0x06000959 RID: 2393 RVA: 0x000285E1 File Offset: 0x000267E1
		private Recursion()
		{
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x0600095A RID: 2394 RVA: 0x000285E9 File Offset: 0x000267E9
		// (set) Token: 0x0600095B RID: 2395 RVA: 0x000285F0 File Offset: 0x000267F0
		public static int defaultMaxDepth { get; set; } = 100;

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x0600095C RID: 2396 RVA: 0x000285F8 File Offset: 0x000267F8
		// (set) Token: 0x0600095D RID: 2397 RVA: 0x000285FF File Offset: 0x000267FF
		public static bool safeMode { get; set; }

		// Token: 0x0600095E RID: 2398 RVA: 0x00028607 File Offset: 0x00026807
		internal static void OnRuntimeMethodLoad()
		{
			Recursion.safeMode = (Application.isEditor || Debug.isDebugBuild);
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x0002861D File Offset: 0x0002681D
		protected override void Free()
		{
			GenericPool<Recursion>.Free(this);
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x00028625 File Offset: 0x00026825
		public new static Recursion New()
		{
			return Recursion.New(Recursion.defaultMaxDepth);
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x00028634 File Offset: 0x00026834
		public new static Recursion New(int maxDepth)
		{
			if (!Recursion.safeMode)
			{
				return null;
			}
			if (maxDepth < 1)
			{
				throw new ArgumentException("Max recursion depth must be at least one.", "maxDepth");
			}
			Recursion recursion = GenericPool<Recursion>.New(() => new Recursion());
			recursion.maxDepth = maxDepth;
			return recursion;
		}
	}
}
