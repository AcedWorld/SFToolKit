using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x0200034B RID: 843
	[Serializable]
	public abstract class vAnimatorSetValue<T> : StateMachineBehaviour where T : IConvertible
	{
		// Token: 0x06001149 RID: 4425 RVA: 0x0005D9EC File Offset: 0x0005BBEC
		protected virtual T GetEnterValue()
		{
			return this.enterValue;
		}

		// Token: 0x0600114A RID: 4426 RVA: 0x0005D9F4 File Offset: 0x0005BBF4
		protected virtual T GetExitValue()
		{
			return this.exitValue;
		}

		// Token: 0x0600114B RID: 4427 RVA: 0x0005D9FC File Offset: 0x0005BBFC
		public sealed override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (this.setOnEnter)
			{
				if (typeof(T).Equals(typeof(int)))
				{
					animator.SetInteger(this.animatorParameter, (int)((object)this.GetEnterValue()));
					return;
				}
				if (typeof(T).Equals(typeof(float)))
				{
					animator.SetFloat(this.animatorParameter, (float)((object)this.GetEnterValue()));
					return;
				}
				if (typeof(T).Equals(typeof(bool)))
				{
					animator.SetBool(this.animatorParameter, (bool)((object)this.GetEnterValue()));
				}
			}
		}

		// Token: 0x0600114C RID: 4428 RVA: 0x0005DABC File Offset: 0x0005BCBC
		public sealed override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (this.setOnExit)
			{
				if (typeof(T).Equals(typeof(int)))
				{
					animator.SetInteger(this.animatorParameter, (int)((object)this.GetExitValue()));
					return;
				}
				if (typeof(T).Equals(typeof(float)))
				{
					animator.SetFloat(this.animatorParameter, (float)((object)this.GetExitValue()));
					return;
				}
				if (typeof(T).Equals(typeof(bool)))
				{
					animator.SetBool(this.animatorParameter, (bool)((object)this.GetExitValue()));
				}
			}
		}

		// Token: 0x04001732 RID: 5938
		public string animatorParameter = "My Animator Parameter";

		// Token: 0x04001733 RID: 5939
		public bool setOnEnter;

		// Token: 0x04001734 RID: 5940
		[vHideInInspector("setOnEnter", false)]
		public T enterValue;

		// Token: 0x04001735 RID: 5941
		public bool setOnExit;

		// Token: 0x04001736 RID: 5942
		[vHideInInspector("setOnExit", false)]
		public T exitValue;
	}
}
