using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000339 RID: 825
	public static class vAnimatorParameterHelper
	{
		// Token: 0x060010F5 RID: 4341 RVA: 0x0005BEB8 File Offset: 0x0005A0B8
		public static AnimatorControllerParameter GetValidParameter(this Animator _Anim, string _ParamName)
		{
			foreach (AnimatorControllerParameter animatorControllerParameter in _Anim.parameters)
			{
				if (animatorControllerParameter.name == _ParamName)
				{
					return animatorControllerParameter;
				}
			}
			return null;
		}

		// Token: 0x060010F6 RID: 4342 RVA: 0x0005BEF0 File Offset: 0x0005A0F0
		public static bool ContainsParam(this Animator _Anim, string _ParamName)
		{
			AnimatorControllerParameter[] parameters = _Anim.parameters;
			for (int i = 0; i < parameters.Length; i++)
			{
				if (parameters[i].name == _ParamName)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060010F7 RID: 4343 RVA: 0x0005BF28 File Offset: 0x0005A128
		public static bool HasParameterOfType(this Animator self, string name, AnimatorControllerParameterType type)
		{
			if (null == self)
			{
				return false;
			}
			foreach (AnimatorControllerParameter animatorControllerParameter in self.parameters)
			{
				if (animatorControllerParameter.type == type && animatorControllerParameter.name == name)
				{
					return true;
				}
			}
			return false;
		}
	}
}
