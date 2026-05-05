using System;
using RootMotion.Dynamics;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class Skeleton : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private void Start()
	{
		PuppetMaster puppetMaster = this.puppetMaster;
		puppetMaster.OnMuscleRemoved = (PuppetMaster.MuscleDelegate)Delegate.Combine(puppetMaster.OnMuscleRemoved, new PuppetMaster.MuscleDelegate(this.OnMuscleDisconnected));
		PuppetMaster puppetMaster2 = this.puppetMaster;
		puppetMaster2.OnMuscleDisconnected = (PuppetMaster.MuscleDelegate)Delegate.Combine(puppetMaster2.OnMuscleDisconnected, new PuppetMaster.MuscleDelegate(this.OnMuscleDisconnected));
	}

	// Token: 0x06000002 RID: 2 RVA: 0x000020AB File Offset: 0x000002AB
	public void OnRebuild()
	{
		this.animator.SetFloat("Legs", 2f);
		this.animator.Play("Move", 0, 0f);
		this.leftLegRemoved = false;
		this.rightLegRemoved = false;
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000020E8 File Offset: 0x000002E8
	private void OnMuscleDisconnected(Muscle m)
	{
		bool flag = false;
		if (this.IsLegMuscle(m, out flag))
		{
			if (flag)
			{
				this.leftLegRemoved = true;
			}
			else
			{
				this.rightLegRemoved = true;
			}
			if (this.leftLegRemoved && this.rightLegRemoved)
			{
				this.puppetMaster.state = PuppetMaster.State.Dead;
				return;
			}
			this.animator.SetFloat("Legs", 1f);
		}
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00002148 File Offset: 0x00000348
	private bool IsLegMuscle(Muscle m, out bool isLeft)
	{
		isLeft = false;
		ConfigurableJoint[] array = this.leftLeg;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == m.joint)
			{
				isLeft = true;
				return true;
			}
		}
		array = this.rightLeg;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == m.joint)
			{
				isLeft = false;
				return true;
			}
		}
		return false;
	}

	// Token: 0x04000001 RID: 1
	public Animator animator;

	// Token: 0x04000002 RID: 2
	public PuppetMaster puppetMaster;

	// Token: 0x04000003 RID: 3
	public ConfigurableJoint[] leftLeg;

	// Token: 0x04000004 RID: 4
	public ConfigurableJoint[] rightLeg;

	// Token: 0x04000005 RID: 5
	private bool leftLegRemoved;

	// Token: 0x04000006 RID: 6
	private bool rightLegRemoved;
}
