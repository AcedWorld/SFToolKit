using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x0200005A RID: 90
	[AddComponentMenu("Scripts/RootMotion.Dynamics/PuppetMaster/Muscle Collision Broadcaster")]
	public class MuscleCollisionBroadcaster : MonoBehaviour
	{
		// Token: 0x06000289 RID: 649 RVA: 0x0000E5EC File Offset: 0x0000C7EC
		public void Hit(float unPin, Vector3 force, Vector3 position)
		{
			if (!base.enabled)
			{
				return;
			}
			BehaviourBase[] behaviours = this.puppetMaster.behaviours;
			for (int i = 0; i < behaviours.Length; i++)
			{
				behaviours[i].OnMuscleHit(new MuscleHit(this.muscleIndex, unPin, force, position));
			}
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000E632 File Offset: 0x0000C832
		private bool IsSelf(Collider c)
		{
			return c.transform.IsChildOf(this.puppetMaster.transform);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000E64C File Offset: 0x0000C84C
		private void OnCollisionEnter(Collision collision)
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.puppetMaster == null)
			{
				return;
			}
			if (this.IsSelf(collision.collider))
			{
				return;
			}
			if (this.puppetMaster.muscles[this.muscleIndex].state.isDisconnected)
			{
				return;
			}
			BehaviourBase[] behaviours = this.puppetMaster.behaviours;
			for (int i = 0; i < behaviours.Length; i++)
			{
				behaviours[i].OnMuscleCollision(new MuscleCollision(this.muscleIndex, collision, false));
			}
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000E6D0 File Offset: 0x0000C8D0
		private void OnCollisionStay(Collision collision)
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.puppetMaster == null)
			{
				return;
			}
			if (Singleton<PuppetMasterSettings>.instance != null && !Singleton<PuppetMasterSettings>.instance.collisionStayMessages)
			{
				return;
			}
			if (this.IsSelf(collision.collider))
			{
				return;
			}
			if (this.puppetMaster.muscles[this.muscleIndex].state.isDisconnected)
			{
				return;
			}
			BehaviourBase[] behaviours = this.puppetMaster.behaviours;
			for (int i = 0; i < behaviours.Length; i++)
			{
				behaviours[i].OnMuscleCollision(new MuscleCollision(this.muscleIndex, collision, true));
			}
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000E76C File Offset: 0x0000C96C
		private void OnCollisionExit(Collision collision)
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.puppetMaster == null)
			{
				return;
			}
			if (Singleton<PuppetMasterSettings>.instance != null && !Singleton<PuppetMasterSettings>.instance.collisionExitMessages)
			{
				return;
			}
			if (this.IsSelf(collision.collider))
			{
				return;
			}
			if (this.puppetMaster.muscles[this.muscleIndex].state.isDisconnected)
			{
				return;
			}
			BehaviourBase[] behaviours = this.puppetMaster.behaviours;
			for (int i = 0; i < behaviours.Length; i++)
			{
				behaviours[i].OnMuscleCollisionExit(new MuscleCollision(this.muscleIndex, collision, false));
			}
		}

		// Token: 0x0400026F RID: 623
		[HideInInspector]
		public PuppetMaster puppetMaster;

		// Token: 0x04000270 RID: 624
		[HideInInspector]
		public int muscleIndex;

		// Token: 0x04000271 RID: 625
		private const string onMuscleHit = "OnMuscleHit";

		// Token: 0x04000272 RID: 626
		private const string onMuscleCollision = "OnMuscleCollision";

		// Token: 0x04000273 RID: 627
		private const string onMuscleCollisionExit = "OnMuscleCollisionExit";

		// Token: 0x04000274 RID: 628
		private MuscleCollisionBroadcaster otherBroadcaster;
	}
}
