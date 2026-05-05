using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000338 RID: 824
	public class vAnimatorParameter
	{
		// Token: 0x060010F3 RID: 4339 RVA: 0x0005BE6C File Offset: 0x0005A06C
		public static implicit operator int(vAnimatorParameter a)
		{
			if (a.isValid)
			{
				return a._parameter.nameHash;
			}
			return -1;
		}

		// Token: 0x060010F4 RID: 4340 RVA: 0x0005BE83 File Offset: 0x0005A083
		public vAnimatorParameter(Animator animator, string parameter)
		{
			if (animator && animator.ContainsParam(parameter))
			{
				this._parameter = animator.GetValidParameter(parameter);
				this.isValid = true;
				return;
			}
			this.isValid = false;
		}

		// Token: 0x040016DB RID: 5851
		private readonly AnimatorControllerParameter _parameter;

		// Token: 0x040016DC RID: 5852
		public readonly bool isValid;
	}
}
