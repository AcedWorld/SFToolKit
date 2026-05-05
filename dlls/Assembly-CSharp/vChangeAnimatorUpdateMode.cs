using System;
using Invector;
using UnityEngine;

// Token: 0x02000034 RID: 52
public class vChangeAnimatorUpdateMode : MonoBehaviour
{
	// Token: 0x060000AF RID: 175 RVA: 0x000081E2 File Offset: 0x000063E2
	public void Reset()
	{
		this.animator = base.GetComponentInParent<Animator>();
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x000081F0 File Offset: 0x000063F0
	private void Start()
	{
		if (!this.animator)
		{
			this.animator = base.GetComponentInParent<Animator>();
		}
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x0000820B File Offset: 0x0000640B
	public void ChangeToUnscaledTime()
	{
		if (Time.timeScale == 0f)
		{
			vTime.useUnscaledTime = true;
			this.animator.updateMode = AnimatorUpdateMode.UnscaledTime;
		}
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x0000822B File Offset: 0x0000642B
	public void ChangeToAnimatePhysics()
	{
		this.animator.updateMode = AnimatorUpdateMode.AnimatePhysics;
		vTime.useUnscaledTime = false;
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x0000823F File Offset: 0x0000643F
	public void ChangeToInitialState()
	{
		this.animator.updateMode = this.initialState;
		vTime.useUnscaledTime = (this.initialState == AnimatorUpdateMode.UnscaledTime);
	}

	// Token: 0x04000104 RID: 260
	public Animator animator;

	// Token: 0x04000105 RID: 261
	private readonly AnimatorUpdateMode initialState = AnimatorUpdateMode.AnimatePhysics;
}
