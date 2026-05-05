using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000103 RID: 259
	public class GenericPoser : Poser
	{
		// Token: 0x060008BE RID: 2238 RVA: 0x00038A90 File Offset: 0x00036C90
		[ContextMenu("Auto-Mapping")]
		public override void AutoMapping()
		{
			if (this.poseRoot == null)
			{
				this.maps = new GenericPoser.Map[0];
				return;
			}
			this.maps = new GenericPoser.Map[0];
			Transform[] componentsInChildren = base.transform.GetComponentsInChildren<Transform>();
			Transform[] componentsInChildren2 = this.poseRoot.GetComponentsInChildren<Transform>();
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				Transform targetNamed = this.GetTargetNamed(componentsInChildren[i].name, componentsInChildren2);
				if (targetNamed != null)
				{
					Array.Resize<GenericPoser.Map>(ref this.maps, this.maps.Length + 1);
					this.maps[this.maps.Length - 1] = new GenericPoser.Map(componentsInChildren[i], targetNamed);
				}
			}
			this.StoreDefaultState();
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x00038B38 File Offset: 0x00036D38
		protected override void InitiatePoser()
		{
			this.StoreDefaultState();
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x00038B40 File Offset: 0x00036D40
		protected override void UpdatePoser()
		{
			if (this.weight <= 0f)
			{
				return;
			}
			if (this.localPositionWeight <= 0f && this.localRotationWeight <= 0f)
			{
				return;
			}
			if (this.poseRoot == null)
			{
				return;
			}
			float localRotationWeight = this.localRotationWeight * this.weight;
			float localPositionWeight = this.localPositionWeight * this.weight;
			for (int i = 0; i < this.maps.Length; i++)
			{
				this.maps[i].Update(localRotationWeight, localPositionWeight);
			}
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x00038BC4 File Offset: 0x00036DC4
		protected override void FixPoserTransforms()
		{
			for (int i = 0; i < this.maps.Length; i++)
			{
				this.maps[i].FixTransform();
			}
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x00038BF4 File Offset: 0x00036DF4
		private void StoreDefaultState()
		{
			for (int i = 0; i < this.maps.Length; i++)
			{
				this.maps[i].StoreDefaultState();
			}
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x00038C24 File Offset: 0x00036E24
		private Transform GetTargetNamed(string tName, Transform[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].name == tName)
				{
					return array[i];
				}
			}
			return null;
		}

		// Token: 0x0400080F RID: 2063
		public GenericPoser.Map[] maps;

		// Token: 0x02000104 RID: 260
		[Serializable]
		public class Map
		{
			// Token: 0x060008C5 RID: 2245 RVA: 0x00038C5C File Offset: 0x00036E5C
			public Map(Transform bone, Transform target)
			{
				this.bone = bone;
				this.target = target;
				this.StoreDefaultState();
			}

			// Token: 0x060008C6 RID: 2246 RVA: 0x00038C78 File Offset: 0x00036E78
			public void StoreDefaultState()
			{
				this.defaultLocalPosition = this.bone.localPosition;
				this.defaultLocalRotation = this.bone.localRotation;
			}

			// Token: 0x060008C7 RID: 2247 RVA: 0x00038C9C File Offset: 0x00036E9C
			public void FixTransform()
			{
				this.bone.localPosition = this.defaultLocalPosition;
				this.bone.localRotation = this.defaultLocalRotation;
			}

			// Token: 0x060008C8 RID: 2248 RVA: 0x00038CC0 File Offset: 0x00036EC0
			public void Update(float localRotationWeight, float localPositionWeight)
			{
				this.bone.localRotation = Quaternion.Lerp(this.bone.localRotation, this.target.localRotation, localRotationWeight);
				this.bone.localPosition = Vector3.Lerp(this.bone.localPosition, this.target.localPosition, localPositionWeight);
			}

			// Token: 0x04000810 RID: 2064
			public Transform bone;

			// Token: 0x04000811 RID: 2065
			public Transform target;

			// Token: 0x04000812 RID: 2066
			private Vector3 defaultLocalPosition;

			// Token: 0x04000813 RID: 2067
			private Quaternion defaultLocalRotation;
		}
	}
}
