using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Invector
{
	// Token: 0x02000353 RID: 851
	[vClassHeader("Body Snapping Control", true, "icon_v2", false, "", openClose = false)]
	public class vBodySnappingControl : vMonoBehaviour
	{
		// Token: 0x0600115A RID: 4442 RVA: 0x0005DCDE File Offset: 0x0005BEDE
		protected virtual void Reset()
		{
			this.LoadBones();
		}

		// Token: 0x0600115B RID: 4443 RVA: 0x0005DCE8 File Offset: 0x0005BEE8
		public virtual void LoadBones()
		{
			Animator componentInParent = base.GetComponentInParent<Animator>();
			List<vBodyStruct.Bone> bones = this.bodyStruct ? this.bodyStruct.bones : vBodyStruct.GetHumanBones();
			if (this.bodyStruct)
			{
				List<vBodySnappingControl.vBoneTransformSnapping> list = this.boneSnappingList.FindAll((vBodySnappingControl.vBoneTransformSnapping _b) => !bones.Exists((vBodyStruct.Bone _b2) => _b2.name.Equals(_b.name)));
				for (int j = 0; j < list.Count; j++)
				{
					this.boneSnappingList.Remove(list[j]);
				}
			}
			if (bones.Count > 0)
			{
				int i2;
				int i;
				for (i = 0; i < bones.Count; i = i2 + 1)
				{
					Transform bone;
					if (bones[i].isHuman && componentInParent && componentInParent.isHuman)
					{
						bone = componentInParent.GetBoneTransform(bones[i].humanBone);
					}
					else
					{
						bone = this.GetBoneByName(bones[i].genericBone);
					}
					vBodySnappingControl.vBoneTransformSnapping vBoneTransformSnapping = this.boneSnappingList.Find((vBodySnappingControl.vBoneTransformSnapping _b) => _b.name.Equals(bones[i].name));
					if (vBoneTransformSnapping == null)
					{
						vBoneTransformSnapping = new vBodySnappingControl.vBoneTransformSnapping();
						vBoneTransformSnapping.name = bones[i].name;
						vBoneTransformSnapping.bone = bone;
						this.boneSnappingList.Add(vBoneTransformSnapping);
					}
					else
					{
						vBoneTransformSnapping.bone = bone;
					}
					i2 = i;
				}
			}
			this.boneSnappingList = (from x in this.boneSnappingList
			orderby x.bone != null && x.name.ToUpper().Contains("LEFT"), x.bone != null && x.name.ToUpper().Contains("RIGHT")
			select x).ToList<vBodySnappingControl.vBoneTransformSnapping>();
			if (!Application.isPlaying)
			{
				this.bonesIsLoaded = true;
			}
		}

		// Token: 0x0600115C RID: 4444 RVA: 0x0005DF1D File Offset: 0x0005C11D
		protected virtual void Awake()
		{
			this.LoadBones();
			this.SnapAll();
		}

		// Token: 0x0600115D RID: 4445 RVA: 0x0005DF2C File Offset: 0x0005C12C
		public virtual void SnapAll()
		{
			foreach (vBodySnappingControl.vBoneTransformSnapping vBoneTransformSnapping in this.boneSnappingList)
			{
				vBoneTransformSnapping.Snap();
			}
		}

		// Token: 0x0600115E RID: 4446 RVA: 0x0005DF7C File Offset: 0x0005C17C
		public virtual Transform GetBone(string name)
		{
			if (!this.bonesIsLoaded)
			{
				this.LoadBones();
			}
			vBodySnappingControl.vBoneTransformSnapping vBoneTransformSnapping = this.boneSnappingList.Find((vBodySnappingControl.vBoneTransformSnapping b) => b.name.Equals(name));
			if (vBoneTransformSnapping == null)
			{
				return null;
			}
			return vBoneTransformSnapping.bone;
		}

		// Token: 0x0600115F RID: 4447 RVA: 0x0005DFC8 File Offset: 0x0005C1C8
		protected virtual Transform GetBoneByName(string name)
		{
			Animator componentInParent = base.GetComponentInParent<Animator>();
			if (!componentInParent)
			{
				return null;
			}
			Transform transform = componentInParent.GetBoneTransform(HumanBodyBones.Hips);
			if (transform == null)
			{
				transform = componentInParent.transform;
			}
			List<Transform> list = transform.gameObject.GetComponentsInChildren<Transform>(true).vToList<Transform>();
			Transform result = null;
			if (list.Count > 0 && !string.IsNullOrEmpty(name.Trim()))
			{
				string[] nameSplited = name.Trim().Split(';', StringSplitOptions.None);
				result = list.Find((Transform child) => this.ContainsName(nameSplited, child.gameObject.name.Trim()));
			}
			return result;
		}

		// Token: 0x06001160 RID: 4448 RVA: 0x0005E060 File Offset: 0x0005C260
		protected virtual bool ContainsName(string[] nameSplited, string targetName)
		{
			bool result = false;
			for (int i = 0; i < nameSplited.Length; i++)
			{
				if (targetName.Contains(nameSplited[i]))
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x04001755 RID: 5973
		[vButton("Create New BodyStruct", "NewBodyStruct", typeof(vBodySnappingControl), false)]
		[vButton("Load Bones", "LoadBones", typeof(vBodySnappingControl), false)]
		public vBodyStruct bodyStruct;

		// Token: 0x04001756 RID: 5974
		public bool showLabels;

		// Token: 0x04001757 RID: 5975
		[HideInInspector]
		public List<vBodySnappingControl.vBoneTransformSnapping> boneSnappingList = new List<vBodySnappingControl.vBoneTransformSnapping>();

		// Token: 0x04001758 RID: 5976
		private bool bonesIsLoaded;

		// Token: 0x02000354 RID: 852
		[Serializable]
		public class vBoneTransformSnapping
		{
			// Token: 0x06001162 RID: 4450 RVA: 0x0005E0A0 File Offset: 0x0005C2A0
			public void Snap()
			{
				if (this.bone && this.target)
				{
					if (Application.isPlaying && this.target.parent != this.bone)
					{
						this.target.parent = this.bone;
						this.onSnap.Invoke();
					}
					this.target.rotation = this.targetRotation;
					this.target.position = this.bone.position;
				}
			}

			// Token: 0x17000342 RID: 834
			// (get) Token: 0x06001163 RID: 4451 RVA: 0x0005E12C File Offset: 0x0005C32C
			public Quaternion targetRotation
			{
				get
				{
					Quaternion result = Quaternion.LookRotation(Vector3.forward);
					Vector3 direction = Vector3.forward;
					if (this.bone && this.target && this.bone.parent)
					{
						switch (this.orientation)
						{
						case vBodySnappingControl.vBoneTransformSnapping.Orientation.Back:
							direction = Vector3.back;
							break;
						case vBodySnappingControl.vBoneTransformSnapping.Orientation.Right:
							direction = Vector3.right;
							break;
						case vBodySnappingControl.vBoneTransformSnapping.Orientation.Left:
							direction = Vector3.left;
							break;
						case vBodySnappingControl.vBoneTransformSnapping.Orientation.Up:
							direction = Vector3.up;
							break;
						case vBodySnappingControl.vBoneTransformSnapping.Orientation.Down:
							direction = Vector3.down;
							break;
						}
						result = Quaternion.LookRotation(this.bone.TransformDirection(direction), this.bone.up);
					}
					return result;
				}
			}

			// Token: 0x04001759 RID: 5977
			public string name;

			// Token: 0x0400175A RID: 5978
			public Transform bone;

			// Token: 0x0400175B RID: 5979
			public Transform target;

			// Token: 0x0400175C RID: 5980
			public vBodySnappingControl.vBoneTransformSnapping.Orientation orientation;

			// Token: 0x0400175D RID: 5981
			public UnityEvent onSnap;

			// Token: 0x02000355 RID: 853
			public enum Orientation
			{
				// Token: 0x0400175F RID: 5983
				Forward,
				// Token: 0x04001760 RID: 5984
				Back,
				// Token: 0x04001761 RID: 5985
				Right,
				// Token: 0x04001762 RID: 5986
				Left,
				// Token: 0x04001763 RID: 5987
				Up,
				// Token: 0x04001764 RID: 5988
				Down
			}
		}
	}
}
