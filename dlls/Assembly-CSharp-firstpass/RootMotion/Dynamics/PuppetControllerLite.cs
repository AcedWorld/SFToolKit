using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000076 RID: 118
	public class PuppetControllerLite : MonoBehaviour, ICollisionEventListener
	{
		// Token: 0x060003CB RID: 971 RVA: 0x000170B4 File Offset: 0x000152B4
		private void Start()
		{
			foreach (MuscleLite muscleLite in this.puppetMaster.muscles)
			{
				CollisionEventBroadcaster collisionEventBroadcaster = muscleLite.joint.gameObject.AddComponent<CollisionEventBroadcaster>();
				collisionEventBroadcaster.listener = this;
				collisionEventBroadcaster.muscle = muscleLite;
			}
		}

		// Token: 0x060003CC RID: 972 RVA: 0x000170FC File Offset: 0x000152FC
		private bool NeedToUpdate()
		{
			PuppetControllerLite.Group[] array = this.groups;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].enabled)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0001712C File Offset: 0x0001532C
		private void FixedUpdate()
		{
			if (!this.NeedToUpdate())
			{
				return;
			}
			float num = 0f;
			foreach (PuppetControllerLite.Group group in this.groups)
			{
				group.Update(this.puppetMaster);
				num = Mathf.Max(num, group.mappingWeight);
			}
			MuscleLite[] muscles = this.puppetMaster.muscles;
			for (int i = 0; i < muscles.Length; i++)
			{
				muscles[i].mappingWeightMlp = num;
			}
		}

		// Token: 0x060003CE RID: 974 RVA: 0x000171A0 File Offset: 0x000153A0
		public void OnCollisionEnterEvent(Collision collision, CollisionEventBroadcaster broadcaster)
		{
			this.ProcessCollisionEvent(collision, broadcaster);
		}

		// Token: 0x060003CF RID: 975 RVA: 0x000171A0 File Offset: 0x000153A0
		public void OnCollisionStayEvent(Collision collision, CollisionEventBroadcaster broadcaster)
		{
			this.ProcessCollisionEvent(collision, broadcaster);
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x000171AC File Offset: 0x000153AC
		private void ProcessCollisionEvent(Collision collision, CollisionEventBroadcaster broadcaster)
		{
			if (collision.collider.transform.root == base.transform)
			{
				return;
			}
			if (!LayerMaskExtensions.Contains(this.collisionLayers, collision.collider.gameObject.layer))
			{
				return;
			}
			PuppetControllerLite.Group[] array = this.groups;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].TryDamage(collision, broadcaster);
			}
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0000223E File Offset: 0x0000043E
		public void OnCollisionExitEvent(Collision collision, CollisionEventBroadcaster broadcaster)
		{
		}

		// Token: 0x0400035B RID: 859
		public PuppetMasterLite puppetMaster;

		// Token: 0x0400035C RID: 860
		public LayerMask collisionLayers;

		// Token: 0x0400035D RID: 861
		[Tooltip("When the puppet is touched, sets pin weight and muscle weight values for these groups.")]
		public PuppetControllerLite.Group[] groups = new PuppetControllerLite.Group[0];

		// Token: 0x02000077 RID: 119
		[Serializable]
		public class Group
		{
			// Token: 0x1700006D RID: 109
			// (get) Token: 0x060003D3 RID: 979 RVA: 0x00017228 File Offset: 0x00015428
			// (set) Token: 0x060003D4 RID: 980 RVA: 0x00017230 File Offset: 0x00015430
			public bool enabled { get; private set; }

			// Token: 0x1700006E RID: 110
			// (get) Token: 0x060003D5 RID: 981 RVA: 0x00017239 File Offset: 0x00015439
			// (set) Token: 0x060003D6 RID: 982 RVA: 0x00017241 File Offset: 0x00015441
			public float mappingWeight { get; private set; }

			// Token: 0x060003D7 RID: 983 RVA: 0x0001724C File Offset: 0x0001544C
			public void TryDamage(Collision collision, CollisionEventBroadcaster broadcaster)
			{
				bool flag = false;
				for (int i = 0; i < this.indices.Length; i++)
				{
					if (broadcaster.muscle.index == this.indices[i])
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return;
				}
				this.damTime = Time.time;
				this.enabled = true;
			}

			// Token: 0x060003D8 RID: 984 RVA: 0x000172A0 File Offset: 0x000154A0
			public void Update(PuppetMasterLite puppetMaster)
			{
				if (!this.enabled)
				{
					return;
				}
				bool flag = puppetMaster.pinWeight <= 0f;
				float num = (Time.time > this.damTime + 0.2f) ? 0f : 1f;
				if (flag)
				{
					num = 1f;
				}
				float num2 = num;
				if (flag)
				{
					num2 = 1f;
				}
				float smoothTime = (num > this.dam) ? this.blendInTime : this.blendOutTime;
				this.dam = Mathf.SmoothDamp(this.dam, num, ref this.damV, smoothTime);
				if (num < this.dam && this.dam < 0.001f)
				{
					this.dam = 0f;
				}
				float smoothTime2 = (num2 > this.map) ? this.blendInTime : this.blendOutTime;
				this.map = Mathf.SmoothDamp(this.map, num2, ref this.mapV, smoothTime2);
				if (num2 < this.map && this.map < 0.001f)
				{
					this.map = 0f;
				}
				if (flag)
				{
					this.dam = Mathf.Min(this.dam, this.map);
				}
				float num3 = flag ? 0f : (this.drag * this.map);
				float angularDrag = flag ? 0.05f : (this.drag * this.map);
				this.mappingWeight = Mathf.Lerp(0f, 1f, this.map);
				for (int i = 0; i < this.indices.Length; i++)
				{
					int num4 = this.indices[i];
					puppetMaster.muscles[num4].pinWeightMlp = Mathf.Lerp(1f, this.pinWeightMlp, this.dam);
					puppetMaster.muscles[num4].muscleWeightMlp = Mathf.Lerp(1f, this.muscleWeightMlp, this.dam);
					puppetMaster.muscles[num4].rigidbody.drag = num3;
					puppetMaster.muscles[num4].rigidbody.angularDrag = angularDrag;
				}
				if (this.dam <= 0f && this.map < 0f)
				{
					this.enabled = false;
				}
			}

			// Token: 0x0400035E RID: 862
			public string name;

			// Token: 0x0400035F RID: 863
			[Tooltip("The muscle groups to apply this pinWeightMlp and muscleWeightMlp to.")]
			public int[] indices = new int[0];

			// Token: 0x04000360 RID: 864
			[Range(0f, 1f)]
			public float pinWeightMlp = 0.5f;

			// Token: 0x04000361 RID: 865
			[Range(0f, 1f)]
			public float muscleWeightMlp = 0.5f;

			// Token: 0x04000362 RID: 866
			[Tooltip("When the puppet is touched, sets muscle Rigidbody drag to this value to reduce the rubber chicken effect.")]
			public float drag = 2f;

			// Token: 0x04000363 RID: 867
			[Tooltip("The time of blending in this script's effects when the puppet is touched.")]
			public float blendInTime = 0.05f;

			// Token: 0x04000364 RID: 868
			[Tooltip("The time of blending out this script's effects when the puppet is not touched any more.")]
			public float blendOutTime = 1f;

			// Token: 0x04000367 RID: 871
			private float dam;

			// Token: 0x04000368 RID: 872
			private float damTime = -100f;

			// Token: 0x04000369 RID: 873
			private float damV;

			// Token: 0x0400036A RID: 874
			private float map;

			// Token: 0x0400036B RID: 875
			private float mapV;
		}
	}
}
