using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200016D RID: 365
	public static class ObjectVariables
	{
		// Token: 0x060009B2 RID: 2482 RVA: 0x00029230 File Offset: 0x00027430
		public static VariableDeclarations Declarations(GameObject source, bool autoAddComponent, bool throwOnMissing)
		{
			Ensure.That("source").IsNotNull<GameObject>(source);
			Variables variables = source.GetComponent<Variables>();
			if (variables == null && autoAddComponent)
			{
				variables = source.AddComponent<Variables>();
			}
			if (variables != null)
			{
				return variables.declarations;
			}
			if (throwOnMissing)
			{
				throw new InvalidOperationException("Game object '" + source.name + "' does not have variables.");
			}
			return null;
		}
	}
}
