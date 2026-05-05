using System;
using System.Collections.Generic;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x0200002A RID: 42
	[AddComponentMenu("VFX/Property Binders/Hierarchy to Attribute Map Binder")]
	[VFXBinder("Point Cache/Hierarchy to Attribute Map")]
	internal class VFXHierarchyAttributeMapBinder : VFXBinderBase
	{
		// Token: 0x060000E7 RID: 231 RVA: 0x000070C2 File Offset: 0x000052C2
		protected override void OnEnable()
		{
			base.OnEnable();
			this.UpdateHierarchy();
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000070D0 File Offset: 0x000052D0
		private void OnValidate()
		{
			this.UpdateHierarchy();
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000070D8 File Offset: 0x000052D8
		private void UpdateHierarchy()
		{
			this.bones = this.ChildrenOf(this.HierarchyRoot, this.MaximumDepth);
			int count = this.bones.Count;
			this.position = new Texture2D(count, 1, TextureFormat.RGBAHalf, false, true);
			this.targetPosition = new Texture2D(count, 1, TextureFormat.RGBAHalf, false, true);
			this.radius = new Texture2D(count, 1, TextureFormat.RHalf, false, true);
			this.UpdateData();
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00007144 File Offset: 0x00005344
		private List<VFXHierarchyAttributeMapBinder.Bone> ChildrenOf(Transform source, uint depth)
		{
			List<VFXHierarchyAttributeMapBinder.Bone> list = new List<VFXHierarchyAttributeMapBinder.Bone>();
			if (source == null)
			{
				return list;
			}
			foreach (object obj in source)
			{
				Transform transform = (Transform)obj;
				list.Add(new VFXHierarchyAttributeMapBinder.Bone
				{
					source = source.transform,
					target = transform.transform,
					sourceRadius = this.DefaultRadius,
					targetRadius = this.DefaultRadius
				});
				if (depth > 0U)
				{
					list.AddRange(this.ChildrenOf(transform, depth - 1U));
				}
			}
			return list;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00007200 File Offset: 0x00005400
		private void UpdateData()
		{
			int count = this.bones.Count;
			if (this.position.width != count)
			{
				return;
			}
			List<Color> list = new List<Color>();
			List<Color> list2 = new List<Color>();
			List<Color> list3 = new List<Color>();
			for (int i = 0; i < count; i++)
			{
				VFXHierarchyAttributeMapBinder.Bone bone = this.bones[i];
				list.Add(new Color(bone.source.position.x, bone.source.position.y, bone.source.position.z, 1f));
				list2.Add(new Color(bone.target.position.x, bone.target.position.y, bone.target.position.z, 1f));
				list3.Add(new Color(bone.sourceRadius, 0f, 0f, 1f));
			}
			this.position.SetPixels(list.ToArray());
			this.targetPosition.SetPixels(list2.ToArray());
			this.radius.SetPixels(list3.ToArray());
			this.position.Apply();
			this.targetPosition.Apply();
			this.radius.Apply();
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000735C File Offset: 0x0000555C
		public override bool IsValid(VisualEffect component)
		{
			return this.HierarchyRoot != null && component.HasTexture(this.m_PositionMap) && component.HasTexture(this.m_TargetPositionMap) && component.HasTexture(this.m_RadiusPositionMap) && component.HasUInt(this.m_BoneCount);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000073C4 File Offset: 0x000055C4
		public override void UpdateBinding(VisualEffect component)
		{
			this.UpdateData();
			component.SetTexture(this.m_PositionMap, this.position);
			component.SetTexture(this.m_TargetPositionMap, this.targetPosition);
			component.SetTexture(this.m_RadiusPositionMap, this.radius);
			component.SetUInt(this.m_BoneCount, (uint)this.bones.Count);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00007438 File Offset: 0x00005638
		public override string ToString()
		{
			return string.Format("Hierarchy: {0} -> {1}", (this.HierarchyRoot == null) ? "(null)" : this.HierarchyRoot.name, this.m_PositionMap);
		}

		// Token: 0x040000A4 RID: 164
		[VFXPropertyBinding(new string[]
		{
			"System.UInt32"
		})]
		[SerializeField]
		protected ExposedProperty m_BoneCount = "BoneCount";

		// Token: 0x040000A5 RID: 165
		[VFXPropertyBinding(new string[]
		{
			"UnityEngine.Texture2D"
		})]
		[SerializeField]
		protected ExposedProperty m_PositionMap = "PositionMap";

		// Token: 0x040000A6 RID: 166
		[VFXPropertyBinding(new string[]
		{
			"UnityEngine.Texture2D"
		})]
		[SerializeField]
		protected ExposedProperty m_TargetPositionMap = "TargetPositionMap";

		// Token: 0x040000A7 RID: 167
		[VFXPropertyBinding(new string[]
		{
			"UnityEngine.Texture2D"
		})]
		[SerializeField]
		protected ExposedProperty m_RadiusPositionMap = "RadiusPositionMap";

		// Token: 0x040000A8 RID: 168
		public Transform HierarchyRoot;

		// Token: 0x040000A9 RID: 169
		public float DefaultRadius = 0.1f;

		// Token: 0x040000AA RID: 170
		public uint MaximumDepth = 3U;

		// Token: 0x040000AB RID: 171
		public VFXHierarchyAttributeMapBinder.RadiusMode Radius;

		// Token: 0x040000AC RID: 172
		private Texture2D position;

		// Token: 0x040000AD RID: 173
		private Texture2D targetPosition;

		// Token: 0x040000AE RID: 174
		private Texture2D radius;

		// Token: 0x040000AF RID: 175
		private List<VFXHierarchyAttributeMapBinder.Bone> bones;

		// Token: 0x02000065 RID: 101
		public enum RadiusMode
		{
			// Token: 0x040001E9 RID: 489
			Fixed,
			// Token: 0x040001EA RID: 490
			Interpolate
		}

		// Token: 0x02000066 RID: 102
		private struct Bone
		{
			// Token: 0x040001EB RID: 491
			public Transform source;

			// Token: 0x040001EC RID: 492
			public float sourceRadius;

			// Token: 0x040001ED RID: 493
			public Transform target;

			// Token: 0x040001EE RID: 494
			public float targetRadius;
		}
	}
}
