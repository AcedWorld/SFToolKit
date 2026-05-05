using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000061 RID: 97
	[HelpURL("http://root-motion.com/puppetmasterdox/html/page6.html")]
	[AddComponentMenu("Scripts/RootMotion.Dynamics/PuppetMaster/Prop Root")]
	public class PropRoot : MonoBehaviour
	{
		// Token: 0x060002D7 RID: 727 RVA: 0x0000FE62 File Offset: 0x0000E062
		[ContextMenu("User Manual")]
		private void OpenUserManual()
		{
			Application.OpenURL("http://root-motion.com/puppetmasterdox/html/page6.html");
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0000FE6E File Offset: 0x0000E06E
		[ContextMenu("Scrpt Reference")]
		private void OpenScriptReference()
		{
			Application.OpenURL("http://root-motion.com/puppetmasterdox/html/class_root_motion_1_1_dynamics_1_1_prop_root.html");
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000FE7C File Offset: 0x0000E07C
		public void DropImmediate()
		{
			if (this.lastProp == null)
			{
				return;
			}
			this.puppetMaster.RemoveMuscleRecursive(this.lastProp.muscle, true, false, MuscleRemoveMode.Sever);
			this.lastProp.Drop();
			this.currentProp = null;
			this.lastProp = null;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0000FECA File Offset: 0x0000E0CA
		private void Awake()
		{
			Debug.LogWarning("PropRoot and Prop system is deprecated. Please see the 'Prop' demo to learn about the new easier and much more performance-efficient PropMuscle and PuppetMasterProp system.", base.transform);
			if (this.currentProp != null)
			{
				this.currentProp.StartPickedUp(this);
			}
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000FEF8 File Offset: 0x0000E0F8
		private void Update()
		{
			if (!this.fixedUpdateCalled)
			{
				return;
			}
			if (this.currentProp != null && this.lastProp == this.currentProp && this.currentProp.muscle.connectedBody == null)
			{
				this.currentProp.Drop();
				this.currentProp = null;
				this.lastProp = null;
			}
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000FF60 File Offset: 0x0000E160
		private void FixedUpdate()
		{
			this.fixedUpdateCalled = true;
			if (this.currentProp == this.lastProp)
			{
				return;
			}
			if (this.currentProp != null && !this.currentProp.initiated)
			{
				return;
			}
			if (this.currentProp == null)
			{
				this.puppetMaster.RemoveMuscleRecursive(this.lastProp.muscle, true, false, MuscleRemoveMode.Sever);
				this.lastProp.Drop();
			}
			if (this.lastProp == null)
			{
				this.AttachProp(this.currentProp);
			}
			if (this.lastProp != null && this.currentProp != null)
			{
				this.puppetMaster.RemoveMuscleRecursive(this.lastProp.muscle, true, false, MuscleRemoveMode.Sever);
				this.AttachProp(this.currentProp);
			}
			this.lastProp = this.currentProp;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00010040 File Offset: 0x0000E240
		private void AttachProp(Prop prop)
		{
			prop.transform.position = base.transform.position;
			prop.transform.rotation = base.transform.rotation;
			prop.PickUp(this);
			this.puppetMaster.AddMuscle(prop.muscle, prop.transform, this.connectTo, base.transform, prop.muscleProps, false, prop.forceLayers);
			if (prop.additionalPin != null && prop.additionalPinTarget != null)
			{
				this.puppetMaster.AddMuscle(prop.additionalPin, prop.additionalPinTarget, prop.muscle.GetComponent<Rigidbody>(), prop.transform, new Muscle.Props(prop.additionalPinWeight, 0f, 0f, 0f, Muscle.Group.Prop), true, prop.forceLayers);
			}
		}

		// Token: 0x0400029D RID: 669
		[Tooltip("Reference to the PuppetMaster component.")]
		public PuppetMaster puppetMaster;

		// Token: 0x0400029E RID: 670
		[Tooltip("If a prop is connected, what will its joint be connected to?")]
		public Rigidbody connectTo;

		// Token: 0x0400029F RID: 671
		[Tooltip("Is there a Prop connected to this PropRoot? Simply assign this value to connect, replace or drop props.")]
		public Prop currentProp;

		// Token: 0x040002A0 RID: 672
		private Prop lastProp;

		// Token: 0x040002A1 RID: 673
		private bool fixedUpdateCalled;
	}
}
