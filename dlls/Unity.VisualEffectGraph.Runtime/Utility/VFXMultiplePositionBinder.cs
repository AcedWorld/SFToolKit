using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace UnityEngine.VFX.Utility
{
	// Token: 0x02000031 RID: 49
	[AddComponentMenu("VFX/Property Binders/Multiple Position Binder")]
	[VFXBinder("Point Cache/Multiple Position Binder")]
	internal class VFXMultiplePositionBinder : VFXBinderBase
	{
		// Token: 0x0600012D RID: 301 RVA: 0x00007F34 File Offset: 0x00006134
		protected override void OnEnable()
		{
			base.OnEnable();
			this.UpdateTexture();
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00007F42 File Offset: 0x00006142
		public override bool IsValid(VisualEffect component)
		{
			return this.Targets != null && component.HasTexture(this.PositionMapProperty) && component.HasInt(this.PositionCountProperty);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00007F74 File Offset: 0x00006174
		public override void UpdateBinding(VisualEffect component)
		{
			if (this.EveryFrame || Application.isEditor)
			{
				this.UpdateTexture();
			}
			component.SetTexture(this.PositionMapProperty, this.positionMap);
			component.SetInt(this.PositionCountProperty, this.count);
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00007FC4 File Offset: 0x000061C4
		private void UpdateTexture()
		{
			if (this.Targets == null || this.Targets.Length == 0)
			{
				return;
			}
			List<Vector3> list = new List<Vector3>();
			foreach (GameObject gameObject in this.Targets)
			{
				if (gameObject != null)
				{
					list.Add(gameObject.transform.position);
				}
			}
			this.count = list.Count;
			if (this.positionMap == null || this.positionMap.width != this.count)
			{
				this.positionMap = new Texture2D(this.count, 1, TextureFormat.RGBAFloat, false);
			}
			List<Color> list2 = new List<Color>();
			foreach (Vector3 vector in list)
			{
				list2.Add(new Color(vector.x, vector.y, vector.z));
			}
			this.positionMap.name = base.gameObject.name + "_PositionMap";
			this.positionMap.filterMode = FilterMode.Point;
			this.positionMap.wrapMode = TextureWrapMode.Repeat;
			this.positionMap.SetPixels(list2.ToArray(), 0);
			this.positionMap.Apply();
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00008118 File Offset: 0x00006318
		public override string ToString()
		{
			return string.Format("Multiple Position Binder ({0} positions)", this.count);
		}

		// Token: 0x040000DA RID: 218
		[VFXPropertyBinding(new string[]
		{
			"UnityEngine.Texture2D"
		})]
		[FormerlySerializedAs("PositionMapParameter")]
		public ExposedProperty PositionMapProperty = "PositionMap";

		// Token: 0x040000DB RID: 219
		[VFXPropertyBinding(new string[]
		{
			"System.Int32"
		})]
		[FormerlySerializedAs("PositionCountParameter")]
		public ExposedProperty PositionCountProperty = "PositionCount";

		// Token: 0x040000DC RID: 220
		public GameObject[] Targets;

		// Token: 0x040000DD RID: 221
		public bool EveryFrame;

		// Token: 0x040000DE RID: 222
		private Texture2D positionMap;

		// Token: 0x040000DF RID: 223
		private int count;
	}
}
